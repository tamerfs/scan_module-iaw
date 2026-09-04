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
            Console.WriteLine("--- IAW 1ABG Visual Scanner v22 ---");
            _timer.Start();

            _port = new SerialPort(PORT_NAME, BAUD_RATE, Parity.None, 8, StopBits.One);
            _port.ReadTimeout = 1000;

            try
            {
                Log("Abrindo porta...");
                _port.Open();
                _port.DtrEnable = true; 
                _port.RtsEnable = false;

                if (PerformSlowInit(0x10))
                {
                    Log("Handshake OK! Autenticando...");
                    if (SendKeyAndSync())
                    {
                        Log("SESSÃO ATIVA! Iniciando loop de leitura...");
                        
                        int falhasConsecutivas = 0;
                        while (falhasConsecutivas < 5)
                        {
                            if (ExecuteDiagnosticCycle())
                            {
                                falhasConsecutivas = 0;
                                Thread.Sleep(200); // Frequência de atualização
                            }
                            else
                            {
                                falhasConsecutivas++;
                                Log($"Tentativa de recuperação {falhasConsecutivas}/5...");
                                Thread.Sleep(500);
                            }
                        }
                        Log("Muitas falhas na sequência. Encerrando.");
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"ERRO: {ex.Message}");
            }
            finally
            {
                _port.Close();
                Log("Fim.");
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
                if (_port.BytesToRead > 0 && _port.ReadByte() == 0x55)
                {
                    for (int i = 0; i < 5; i++) _port.ReadByte();
                    return true;
                }
                Thread.Sleep(10);
            }
            return false;
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
            Thread.Sleep(200);
            if (_port.BytesToRead >= 4)
            {
                byte[] sync = new byte[_port.BytesToRead];
                _port.Read(sync, 0, sync.Length);
                Log($"ECU Sincronizada: {BitConverter.ToString(sync)}");
                return true;
            }
            return false;
        }

        static bool ExecuteDiagnosticCycle()
        {
            // 1. Enviar Pedido de Dados (02-01-03)
            // No log v13, este comando retornou o Status 0A
            byte[] cmd = { 0x02, 0x01, 0x03 };
            _port.DiscardInBuffer();
            Log($"TX -> {BitConverter.ToString(cmd)}");
            _port.Write(cmd, 0, 3);

            // 2. Aguarda resposta da ECU (Devemos ver o eco de 3 bytes + Frame de 4 bytes)
            // Total: 7 bytes. Se recebermos o 0x0A, avançamos.
            byte[] response = CaptureFrame(7, 800);
            if (response == null) { Log("Sem resposta ao comando 01."); return false; }

            Log($"RX (Bruto) <- {BitConverter.ToString(response)}");

            if (response.Contains((byte)0x0A))
            {
                // 3. Enviar Gatilho 0x03 para descarregar a tabela
                Log("Gatilho 0x03 enviado.");
                _port.Write(new byte[] { 0x03 }, 0, 1);
                
                // 4. Captura a Tabela de Sensores
                // Esperamos o eco do 0x03 + Frame de Dados (Tamanho costuma ser 0x1F ou 0x20)
                byte[] table = CaptureFrame(20, 1000); 
                if (table != null)
                {
                    Log($"TABELA RECEBIDA: {BitConverter.ToString(table)}");
                    ParseData(table);
                    return true;
                }
            }
            return false;
        }

        static byte[] CaptureFrame(int minBytes, int timeoutMs)
        {
            DateTime limit = DateTime.Now.AddMilliseconds(timeoutMs);
            while (DateTime.Now < limit)
            {
                if (_port.BytesToRead >= minBytes)
                {
                    byte[] buf = new byte[_port.BytesToRead];
                    _port.Read(buf, 0, buf.Length);
                    return buf;
                }
                Thread.Sleep(10);
            }
            return null;
        }

        static void ParseData(byte[] raw)
        {
            // Localiza o frame de dados real (pula ecos)
            // O frame de dados IAW começa com o tamanho (ex: 1F ou 20)
            int startIdx = -1;
            for (int i = 0; i < raw.Length; i++)
            {
                if (raw[i] == 0x1F || raw[i] == 0x20 || raw[i] == 0x21) { startIdx = i; break; }
            }

            if (startIdx != -1 && raw.Length > startIdx + 15)
            {
                byte[] d = raw.Skip(startIdx).ToArray();
                try {
                    // Índices baseados na IAW 1ABG.81
                    double bateria = d[11] * 0.065;
                    int rpm = d[2] * 40; // Se o motor estiver parado, será 0
                    int agua = d[4] - 40;
                    int ar = d[5] - 40;

                    Console.WriteLine("\n************************************");
                    Console.WriteLine($"  BATERIA: {bateria:F2}V");
                    Console.WriteLine($"  RPM:     {rpm}");
                    Console.WriteLine($"  ÁGUA:    {agua}°C");
                    Console.WriteLine($"  AR:      {ar}°C");
                    Console.WriteLine("************************************\n");
                } catch { Log("Erro ao decifrar bytes da tabela."); }
            }
        }
    }

    public static class Ext {
        public static bool Contains(this byte[] arr, byte val) => arr.Any(b => b == val);
    }
}