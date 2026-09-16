using System;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace IawModuleScan
{
    class Program
    {
        const string PORT_NAME = "COM5";
        const int BAUD_RATE = 4800;
        static SerialPort _port = null!;
        static Stopwatch _timer = new Stopwatch();

        static void Main(string[] args)
        {
            Console.WriteLine("--- IAW 1ABG Forensic Scanner v24 ---");
            _timer.Start();

            _port = new SerialPort(PORT_NAME, BAUD_RATE, Parity.None, 8, StopBits.One);
            _port.ReadTimeout = 1000;

            try
            {
                Log("Conectando...");
                _port.Open();
                _port.DtrEnable = true;
                _port.RtsEnable = false;

                if (PerformSlowInit(0x10))
                {
                    Log("Handshake OK! Autenticando...");
                    if (SendKeyAndSync())
                    {
                        Log("SESSÃO ATIVA! Entrando em modo de escuta...");
                        
                        // Envia pedido inicial
                        RequestSensorsV24();

                        // Loop de monitoramento de linha
                        MonitorLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"ERRO NO LOOP: {ex.Message}");
            }
            finally
            {
                _port.Close();
                Log("Fim.");
                Console.WriteLine("Pressione qualquer tecla para sair...");
                Console.ReadKey();
            }
        }

        static void Log(string message) => Console.WriteLine($"[{_timer.ElapsedMilliseconds / 1000.0:F3}s] {message}");

    static bool PerformSlowInit(byte address)
    {
        _port.DiscardInBuffer();
        List<int> bits = new List<int> { 0 };
        for (int i = 0; i < 8; i++) bits.Add((address >> i) & 1);
        bits.Add(1);
        Stopwatch bitTimer = new Stopwatch();
        foreach (int bit in bits)
        {
            bitTimer.Restart();
            _port.BreakState = _port.RtsEnable = (bit == 0);
            while (bitTimer.ElapsedMilliseconds < 200) { }
        }
        _port.BreakState = _port.RtsEnable = false;

        long limit = _timer.ElapsedMilliseconds + 3000;
        while (_timer.ElapsedMilliseconds < limit)
        {
            if (_port.BytesToRead > 0)
            {
                int sync = _port.ReadByte();
                if (sync != 0x55) continue;

                byte kb1 = ReadByteBlocking(300);
                byte kb2 = ReadByteBlocking(300);
                Log($"SYNC 55, KB1={kb1:X2}, KB2={kb2:X2}");

                // Responde com o complemento de KB2
                byte inv = (byte)(~kb2);
                Thread.Sleep(30); // dentro da janela W4 (~25-50ms)
                _port.Write(new byte[] { inv }, 0, 1);

                byte addrComplement = ReadByteBlocking(300);
                Log($"Resposta da ECU ao complemento: {addrComplement:X2} (esperado: {(byte)(~address):X2})");

                return addrComplement == (byte)(~address);
            }
            Thread.Sleep(10);
        }
        return false;
    }

    static byte ReadByteBlocking(int timeoutMs)
    {
        DateTime start = DateTime.Now;
        while (_port.BytesToRead == 0 && (DateTime.Now - start).TotalMilliseconds < timeoutMs) { }
        return _port.BytesToRead > 0 ? (byte)_port.ReadByte() : (byte)0x00;
    }
        static bool SendKeyAndSync()
        {
            byte[] key = { 0x03, 0x34, 0x51, 0x88 };
            _port.DiscardInBuffer();
            foreach (byte b in key)
            {
                _port.Write(new byte[] { b }, 0, 1);
                DateTime st = DateTime.Now;
                while (_port.BytesToRead == 0 && (DateTime.Now - st).TotalMilliseconds < 200) { }
                if (_port.BytesToRead > 0) _port.ReadByte(); 
            }
            Thread.Sleep(300);
            return _port.BytesToRead >= 4;
        }

        static void RequestSensorsV24()
        {
            byte[] cmd = { 0x02, 0x08, 0x0A };
            _port.DiscardInBuffer();
            Log($"TX -> {BitConverter.ToString(cmd)}");
            _port.Write(cmd, 0, 3);
        }

        static void MonitorLine()
        {
            Log("Monitorando tráfego... (Aguardando resposta da ECU)");
            Stopwatch sw = Stopwatch.StartNew();
            
            while (sw.Elapsed.TotalSeconds < 20)
            {
                if (_port.BytesToRead > 0)
                {
                    byte b = (byte)_port.ReadByte();
                    
                    // Se detectar o início do frame de status da ECU (03-0A...)
                    if (b == 0x03)
                    {
                        byte[] frame = new byte[3];
                        for (int i = 0; i < 3; i++)
                        {
                            DateTime wait = DateTime.Now;
                            while (_port.BytesToRead == 0 && (DateTime.Now - wait).TotalMilliseconds < 300) { }
                            if (_port.BytesToRead == 0) { Log("Timeout aguardando status frame"); return; }
                            frame[i] = (byte)_port.ReadByte();
                        }
                        byte cmd = frame[0], data = frame[1], cs = frame[2];
                        Log($"STATUS ECU: Size 03, ID {cmd:X2}, Val {data:X2}, CS {cs:X2}");

                        if (cmd == 0x0A)
                        {
                            Log("Confirmado Status 0A. Enviando Gatilho 0x03...");
                            _port.Write(new byte[] { 0x03 }, 0, 1);
                            Thread.Sleep(5);
                            if (_port.BytesToRead > 0) _port.ReadByte(); // descarta eco do trigger
                        }
                    }
                    // Se detectar um frame grande (Size 0x1F = 31 bytes ou 0x20 = 32)
                    else if (b == 0x1F || b == 0x20)
                    {
                        byte size = b;
                        byte[] payload = new byte[size - 1];
                        Log($"Detectado Frame de Dados: Tamanho {size}");
                        
                        for (int i = 0; i < payload.Length; i++)
                        {
                            DateTime wait = DateTime.Now;
                            while (_port.BytesToRead == 0 && (DateTime.Now - wait).TotalMilliseconds < 500) { }
                            payload[i] = (byte)_port.ReadByte();
                        }
                        
                        Log($"CONTEÚDO: {BitConverter.ToString(payload)}");
                        
                        if (payload.Length >= 15) {
                            ParseDataV24(payload);
                            // Envia 0x03 de novo para manter a ECU mandando
                            _port.Write(new byte[] { 0x03 }, 0, 1);
                            RequestSensorsV24(); // Pede nova tabela
                        }
                    }
                    else
                    {
                        // Qualquer outro byte solto (eco ou lixo)
                        Console.WriteLine($"[HEX BRUTO]: {b:X2}");
                    }
                }
                Thread.Sleep(1);
            }
        }

        static void ParseDataV24(byte[] d)
        {
            try {
                // Mapeamento IAW 1ABG (Padrão KWP71)
                // d[0] costuma ser o ID do comando de volta (08)
                double bat = d[11] * 0.065;
                int rpm = d[2] * 40;
                int agua = d[4] - 40;
                
                Console.WriteLine("\n************************************");
                Console.WriteLine($"  BATERIA: {bat:F2}V  |  RPM: {rpm}");
                Console.WriteLine($"  ÁGUA:    {agua}°C");
                Console.WriteLine("************************************\n");
            } catch { }
        }
    }
}