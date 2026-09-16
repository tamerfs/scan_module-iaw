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
                        
                        ScanCommands();
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

                    Log("SYNC 55 recebido. Só escutando por 500ms, sem enviar nada...");
                    var bytes = new List<byte>();
                    DateTime start = DateTime.Now;
                    while ((DateTime.Now - start).TotalMilliseconds < 500)
                    {
                        if (_port.BytesToRead > 0)
                        {
                            bytes.Add((byte)_port.ReadByte());
                            start = DateTime.Now; // reinicia a janela a cada byte novo
                        }
                    }
                    Log($"Burst espontâneo da ECU ({bytes.Count} bytes): {BitConverter.ToString(bytes.ToArray())}");
                    return true;
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

        static void ScanCommands()
        {
            for (int c = 0x00; c <= 0x30; c++)
            {
                byte cmd = (byte)c;
                byte checksum = (byte)(0x02 + cmd);
                byte[] req = { 0x02, cmd, checksum };

                _port.DiscardInBuffer();
                _port.Write(req, 0, 3);

                // descarta o eco (3 bytes)
                for (int i = 0; i < 3; i++) ReadByteBlocking(200);

                // espera por uma resposta real
                var resp = new List<byte>();
                DateTime start = DateTime.Now;
                while ((DateTime.Now - start).TotalMilliseconds < 400)
                {
                    if (_port.BytesToRead > 0)
                    {
                        resp.Add((byte)_port.ReadByte());
                        start = DateTime.Now;
                    }
                }

                if (resp.Count > 0)
                    Log($"CMD {cmd:X2} -> {resp.Count} bytes: {BitConverter.ToString(resp.ToArray())}");
                else
                    Log($"CMD {cmd:X2} -> (sem resposta)");

                Thread.Sleep(50);
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