using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Threading;

namespace IawModuleScan
{
    // cmd 0x31 = leitura de valor (1 ou 2 bytes); cmd 0x32 = bloco de 12 bytes (estados/flags)
    record Sensor(string Name, byte Cmd, byte Id, Func<byte[], string> Format);

    class Program
    {
        const string PORT_NAME = "COM4";
        const int BAUD_RATE = 4800;
        static readonly bool DEBUG = false;  // true = mostra TX/RX/ACK em hex
        const int GAP_MS = 90;     // o MultiEcuScan espera >= ~60 ms após o último byte da ECU

        static SerialPort _port = null!;
        static readonly Stopwatch _clock = Stopwatch.StartNew();
        static long _lastRx = 0;

        static int U(byte[] p) => p.Aggregate(0, (a, b) => (a << 8) | b);
        static string Bin(byte[] p) => Convert.ToString(U(p), 2).PadLeft(8, '0');

        // "(aprox.)" = conversão ainda sendo calibrada; "raw" = ainda sem conversão
        static readonly Sensor[] Sensors =
        {
            new("Tensão da bateria",              0x31, 0x08, p => $"{U(p) * 0.0628:F2} V"),
            new("Rotações do motor",              0x31, 0x00, p => $"{U(p) * 25} rpm"),
            new("Temperatura da água",            0x31, 0x06, p => $"{U(p) - 40} °C"),
            new("Temperatura do ar",              0x31, 0x05, p => $"{U(p) - 40} °C"),
            new("Avanço da ignição",              0x31, 0x02, p => $"{U(p) * 0.5:F1} deg"),
            new("Red. avanço detonação cil 1",    0x31, 0x2A, p => $"raw {U(p)}"),
            new("Red. avanço detonação cil 2",    0x31, 0x2B, p => $"raw {U(p)}"),
            new("Red. avanço detonação cil 3",    0x31, 0x2C, p => $"raw {U(p)}"),
            new("Red. avanço detonação cil 4",    0x31, 0x2E, p => $"raw {U(p)}"),   // a ECU responde NACK
            new("Tempo da injeção",               0x31, 0x01, p => $"{U(p) * 0.00326:F4} ms (aprox.)"),
            new("Tempo de injeção cil 1",         0x31, 0x22, p => $"{U(p) * 0.00326:F4} ms (aprox.)"),
            new("Tempo de injeção cil 2",         0x31, 0x23, p => $"{U(p) * 0.00326:F4} ms (aprox.)"),
            new("Tempo de injeção cil 3",         0x31, 0x24, p => $"{U(p) * 0.00326:F4} ms (aprox.)"),
            new("Tempo de injeção cil 4",         0x31, 0x25, p => $"{U(p) * 0.00326:F4} ms (aprox.)"),
            new("Tempo de carga bobina 1",        0x31, 0x32, p => $"{U(p) * 0.00326:F4} ms (aprox.)"),
            new("Tempo de carga bobina 2",        0x31, 0x33, p => $"{U(p) * 0.00326:F4} ms (aprox.)"),
            new("Sensor de detonação",            0x31, 0x21, p => $"raw {U(p)}"),
            new("Carga do motor",                 0x31, 0x1D, p => $"{U(p) * 5.2:F2} mg/i"),
            new("Pressão de admissão",            0x31, 0x03, p => $"{U(p)} mbar"),
            new("Ângulo borboleta",               0x31, 0x07, p => $"{U(p) * 0.44:F2} deg (aprox.)"),
            new("Abert. atuador marcha lenta",    0x32, 0x09, p => $"{p[0] / 5.0:F2} % (aprox.), passos {p[0]}"),
            new("Posição motor passo-a-passo",    0x31, 0x0F, p => $"{U(p)} steps (provável)"),
            new("Abert. marcha lenta adaptativa", 0x31, 0x14, p => $"raw {(short)U(p)} (signed)"),
            new("Abert. adaptativa climat.",      0x31, 0x15, p => $"raw {U(p)}"),
            new("Tensão da sonda lambda",         0x31, 0x1B, p => $"{U(p) * 0.0049:F3} V"),
            new("Integrador sonda lambda",        0x31, 0x0C, p => $"{U(p) / 64.0:F3} (aprox.)"),
            new("Estado da sonda lambda",         0x31, 0x0B, p => $"bits {Bin(p)}"),
            new("RPM marcha lenta desejada",      0x31, 0x12, p => $"{U(p) * 7.93:F0} rpm (aprox.)"),
            new("Abert. válvula anti-evap.",      0x32, 0x08, p => "bloco"),
            new("Bloco estados A/C, cód. univ., central", 0x32, 0x04, p => "bloco"),
            new("Pressão atmosférica",            0x31, 0x04, p => $"{U(p)} mbar"),
            new("Partida do motor (bloco)",       0x32, 0x0A, p => "bloco"),
        };

        static void Log(string m) => Console.WriteLine($"[{_clock.ElapsedMilliseconds / 1000.0:F3}s] {m}");
        static string Hex(IEnumerable<byte> b) => BitConverter.ToString(b.ToArray());

        static void Main()
        {
            _port = new SerialPort(PORT_NAME, BAUD_RATE, Parity.None, 8, StopBits.One) { ReadTimeout = 100 };
            try
            {
                _port.Open();
                _port.DtrEnable = true;
                _port.RtsEnable = false;

                if (!SlowInit(0x10)) { Log("Slow init falhou."); return; }
                if (!StartSession()) { Log("Sessão não iniciou."); return; }

                Log("Sessão ativa. Ctrl+C para sair.");
                while (true)
                {
                    foreach (var s in Sensors)
                    {
                        var p = Query(s.Cmd, s.Id, out string status);
                        string shown = p is null ? status : s.Format(p);
                        string raw = p is null ? "" : $"  [{Hex(p)}]";
                        Console.WriteLine($"{s.Cmd:X2}:{s.Id:X2} {s.Name,-40} {shown}{raw}");
                        DrainAcks(); // ACK do bloco recebido (03 09 00 0C)
                    }
                    Console.WriteLine("----");
                }
            }
            catch (Exception ex) { Log($"ERRO: {ex.Message}"); }
            finally { if (_port.IsOpen) _port.Close(); }
        }

        // ---------- Frames ----------
        // [size][cmd][args...][sumHi][sumLo]; size = (cmd+args) + 2; soma de 16 bits de tudo antes do checksum
        static byte[] BuildFrame(byte cmd, params byte[] args)
        {
            var f = new List<byte> { (byte)(1 + args.Length + 2), cmd };
            f.AddRange(args);
            int sum = f.Sum(b => b);
            f.Add((byte)(sum >> 8));
            f.Add((byte)sum);
            return f.ToArray();
        }

        static bool ChecksumOk(byte[] f)
        {
            if (f.Length < 4) return false;
            int sum = f.Take(f.Length - 2).Sum(b => b);
            return f[^2] == (byte)(sum >> 8) && f[^1] == (byte)sum;
        }

        // Envia byte a byte e consome o eco do cabo (como o MultiEcuScan faz)
        static void SendFrame(byte[] frame)
        {
            // não transmitir logo após a ECU falar: espera o intervalo mínimo
            while (_clock.ElapsedMilliseconds - _lastRx < GAP_MS) Thread.Sleep(1);

            if (DEBUG) Log($"TX -> {Hex(frame)}");
            foreach (byte b in frame)
            {
                _port.Write(new[] { b }, 0, 1);
                ReadByteTimeout(100); // eco
            }
        }

        static int ReadByteTimeout(int ms)
        {
            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < ms)
            {
                if (_port.BytesToRead > 0)
                {
                    int b = _port.ReadByte();
                    _lastRx = _clock.ElapsedMilliseconds;
                    return b;
                }
                Thread.Yield();
            }
            return -1;
        }

        static byte[]? ReadFrame(int timeoutMs)
        {
            int first;
            var sw = Stopwatch.StartNew();
            do { first = ReadByteTimeout(20); } // ignora 0x00 solto
            while ((first == 0 || first == -1) && sw.ElapsedMilliseconds < timeoutMs);
            if (first <= 0) return null;

            var f = new List<byte> { (byte)first };
            for (int i = 0; i < first; i++)
            {
                int b = ReadByteTimeout(100); // ECU manda ~1 byte / 12 ms
                if (b < 0) return null;
                f.Add((byte)b);
            }
            return f.ToArray();
        }

        // Protocolo em blocos: cada bloco de dados da ECU precisa ser confirmado com
        // 03 09 00 0C. A ECU manda blocos pendentes até responder com o mesmo ACK.
        static void DrainAcks()
        {
            for (int i = 0; i < 6; i++)
            {
                SendFrame(BuildFrame(0x09));
                var f = ReadFrame(300);
                if (DEBUG) Log($"  ack <- {(f is null ? "nada" : Hex(f))}");
                if (f is null || (f.Length == 4 && f[1] == 0x09)) break;
            }
        }

        // ---------- Leitura ----------
        // Devolve só o payload (sem size, sem complemento do cmd, sem checksum)
        static byte[]? Query(byte cmd, byte id, out string status)
        {
            _port.DiscardInBuffer();
            SendFrame(BuildFrame(cmd, id));
            var r = ReadFrame(400);
            if (DEBUG) Log($"RX <- {(r is null ? "nada" : Hex(r))}");

            status = "sem resposta";
            if (r is null) return null;
            if (r.Length == 4 && r[1] == 0x0A) { status = "NACK (sem dado)"; return null; } // 03 0A 00 0D

            // resposta positiva: segundo byte = complemento do comando (31 -> CE, 32 -> CD)
            if (!ChecksumOk(r) || r[1] != (byte)(cmd ^ 0xFF))
            {
                status = $"frame inesperado: {Hex(r)}";
                return null;
            }
            status = "ok";
            return r[2..^2];
        }

        // ---------- Inicialização ----------
        static bool SlowInit(byte address)
        {
            _port.DiscardInBuffer();
            var bits = new List<int> { 0 };
            for (int i = 0; i < 8; i++) bits.Add((address >> i) & 1);
            bits.Add(1);

            var bitTimer = new Stopwatch();
            foreach (int bit in bits)
            {
                bitTimer.Restart();
                _port.BreakState = _port.RtsEnable = (bit == 0);
                while (bitTimer.ElapsedMilliseconds < 200) { }
            }
            _port.BreakState = _port.RtsEnable = false;

            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < 3000)
            {
                if (_port.BytesToRead > 0 && _port.ReadByte() == 0x55)
                {
                    var burst = new List<byte>();
                    int b;
                    while ((b = ReadByteTimeout(500)) >= 0) burst.Add((byte)b);
                    Log($"Sync 55 + burst: {Hex(burst)} (esperado B0-86-83-15-23)");
                    return true;
                }
                Thread.Sleep(5);
            }
            return false;
        }

        static bool StartSession()
        {
            // chave que o MultiEcuScan envia; a ECU devolve o mesmo frame
            byte[] key = { 0x03, 0x34, 0x51, 0x88 };
            SendFrameRaw(key);
            var ack = ReadFrame(500);
            Log($"Chave -> {(ack is null ? "sem resposta" : Hex(ack))}");

            SendFrame(BuildFrame(0x00, 0x00));   // 04 00 00 00 04
            var a = ReadFrame(500);
            Log($"Init 1 -> {(a is null ? "sem resposta" : Hex(a))}");
            DrainAcks();

            SendFrame(BuildFrame(0x51, 0x02));   // 04 51 02 00 57 (identificação)
            var b = ReadFrame(500);
            Log($"Init 2 -> {(b is null ? "sem resposta" : Hex(b))}");
            DrainAcks();
            return a is not null;
        }

        // A chave não segue o checksum de 16 bits, então vai crua
        static void SendFrameRaw(byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                _port.Write(new[] { b }, 0, 1);
                ReadByteTimeout(100);
            }
        }
    }
}