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
            Console.WriteLine("--- IAW 1ABG Scanner v9 (Burst Mode) ---");
            _timer.Start();

            _port = new SerialPort(PORT_NAME, BAUD_RATE, Parity.None, 8, StopBits.One);
            _port.ReadTimeout = 1000;
            _port.WriteTimeout = 500;

            try
            {
                Log("Abrindo porta...");
                _port.Open();
                _port.DtrEnable = true;
                _port.RtsEnable = false;

                // 1. Handshake
                if (PerformSlowInit(0x10))
                {
                    Log("Handshake OK! Autenticando rapidamente...");

                    // 2. Autenticação
                    if (SendConnectionKey())
                    {
                        Log("Sessão ATIVA! Solicitando dados imediatamente...");
                        
                        // O protocolo KWP71 Marelli é sequencial.
                        // Vamos tentar os 3 comandos mais comuns para essa ECU.
                        // 0x0F (Status), 0x01 (ID), 0x0B (Sensores)
                        byte[] sequence = { 0x0F, 0x01, 0x0B };

                        foreach (byte cmd in sequence)
                        {
                            if (ExecuteIawCommand(cmd)) 
                            {
                                Log($"Sucesso no comando 0x{cmd:X2}!");
                                Thread.Sleep(200); // Pequena pausa entre comandos bem-sucedidos
                            }
                            else {
                                Log($"Sem resposta para 0x{cmd:X2}.");
                            }
                        }
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
                if (_port.BytesToRead > 0)
                {
                    if (_port.ReadByte() == 0x55)
                    {
                        for (int i = 0; i < 5; i++) _port.ReadByte();
                        return true;
                    }
                }
                Thread.Sleep(5);
            }
            return false;
        }

        static bool SendConnectionKey()
        {
            byte[] key = { 0x03, 0x34, 0x51, 0x88 };
            try {
                _port.DiscardInBuffer();
                foreach (byte b in key)
                {
                    _port.Write(new byte[] { b }, 0, 1);
                    // Lê o eco imediatamente para não sujar o buffer
                    DateTime st = DateTime.Now;
                    while (_port.BytesToRead == 0 && (DateTime.Now - st).TotalMilliseconds < 100) { }
                    if (_port.BytesToRead > 0) _port.ReadByte(); 
                }
                Thread.Sleep(100);
                if (_port.BytesToRead >= 4) {
                    _port.DiscardInBuffer(); // Limpa confirmação para o próximo passo
                    return true;
                }
            } catch { }
            return false;
        }

        static bool ExecuteIawCommand(byte cmd)
        {
            Log($"TX -> 0x{cmd:X2}");
            _port.DiscardInBuffer();
            
            // Envia o comando
            _port.Write(new byte[] { cmd }, 0, 1);
            
            // 1. Limpa o eco (o byte volta pelo cabo)
            DateTime start = DateTime.Now;
            while (_port.BytesToRead == 0 && (DateTime.Now - start).TotalMilliseconds < 200) { }
            if (_port.BytesToRead > 0) _port.ReadByte();

            // 2. Aguarda o Complemento (ACK)
            byte expectedAck = (byte)(cmd ^ 0xFF);
            start = DateTime.Now;
            while (_port.BytesToRead == 0 && (DateTime.Now - start).TotalMilliseconds < 500) { }
            
            if (_port.BytesToRead > 0)
            {
                byte ack = (byte)_port.ReadByte();
                if (ack == expectedAck)
                {
                    Log($"ACK OK (0x{ack:X2})! Autorizando envio...");
                    // 3. Envia 0x03 para liberar o bloco de dados
                    _port.Write(new byte[] { 0x03 }, 0, 1);
                    Thread.Sleep(20);
                    if (_port.BytesToRead > 0) _port.ReadByte(); // Limpa eco do 0x03

                    // 4. Lê o tamanho e o bloco
                    Thread.Sleep(100);
                    if (_port.BytesToRead > 0)
                    {
                        byte size = (byte)_port.ReadByte();
                        byte[] data = new byte[size];
                        int read = 0;
                        while (read < size) {
                            if (_port.BytesToRead > 0) { data[read] = (byte)_port.ReadByte(); read++; }
                        }
                        Log($"RX <- {BitConverter.ToString(data)}");
                        return true;
                    }
                }
                else {
                    Log($"ACK Inesperado: 0x{ack:X2}");
                }
            }
            return false;
        }
    }
}