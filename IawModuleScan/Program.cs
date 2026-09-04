// executar primeiro o 'dotnet add package System.IO.Ports'

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
            Console.WriteLine("--- IAW 1ABG Diagnostic Tool v2 (C#) ---");
            _timer.Start();

            _port = new SerialPort(PORT_NAME, BAUD_RATE, Parity.None, 8, StopBits.One);
            _port.ReadTimeout = 2000;

            try
            {
                Log("Abrindo porta e alimentando cabo (DTR=On)...");
                _port.Open();
                _port.DtrEnable = true; // Essencial para alimentar o chip CH340
                _port.RtsEnable = false; // Começa em repouso (12V)

                // 1. Despertar da Interface
                PerformWakeup();

                // 2. Tentar Slow Init com endereço 0x33 (Padrão Marelli)
                // Se falhar, você pode trocar para 0x10 aqui em um segundo teste.
                if (PerformSlowInit(0x10))
                {
                    Log("SUCESSO! ECU respondeu.");
                    // Chave de conexão observada no MES
                    SendConnectionKey();
                }
                else
                {
                    Log("ECU não respondeu ao 0x33. Verifique a ignição ou tente o endereço 0x10.");
                }
            }
            catch (Exception ex)
            {
                Log($"ERRO: {ex.Message}");
            }
            finally
            {
                _port.Close();
                Log("Fim da sessão.");
            }
        }

        static void Log(string message) => Console.WriteLine($"[{_timer.ElapsedMilliseconds / 1000.0:F3}s] {message}");

        static void PerformWakeup()
        {
            _port.BaudRate = 9600;
            Log("Sondagem 9600 baud...");
            _port.Write(new byte[] { 0x00 }, 0, 1);
            Thread.Sleep(100);
            if (_port.BytesToRead > 0) Log($"Resposta Interface: 0x{_port.ReadByte():X2}");
            
            _port.Close();
            Log("Silêncio de 2s...");
            Thread.Sleep(2000);
            _port.BaudRate = BAUD_RATE;
            _port.Open();
            _port.DtrEnable = true;
        }

        static bool PerformSlowInit(byte address)
        {
            Log($"Iniciando Slow Init no endereço 0x{address:X2} (5 Baud)...");
            
            // Limpa lixo do buffer antes de começar
            _port.DiscardInBuffer();

            // LSB first: Start(0), 8 bits, Stop(1)
            List<int> bits = new List<int> { 0 };
            for (int i = 0; i < 8; i++) bits.Add((address >> i) & 1);
            bits.Add(1);

            Stopwatch bitTimer = new Stopwatch();

            foreach (int bit in bits)
            {
                bitTimer.Restart();
                bool isLow = (bit == 0);
                
                // No KKL/CH340: BreakState e RTS controlam o nível da linha K
                _port.BreakState = isLow;
                _port.RtsEnable = isLow;

                // Aguarda exatamente 200ms por bit
                while (bitTimer.ElapsedMilliseconds < 200) { /* Busy wait para precisão */ }
            }

            // Garante linha em repouso (12V / High)
            _port.BreakState = false;
            _port.RtsEnable = false;
            
            Log("Aguardando 0x55 (Hunting mode)...");
            
            // Dá um tempo curto para o eco do próprio endereço chegar e descarta
            Thread.Sleep(100);
            _port.DiscardInBuffer();

            long limit = _timer.ElapsedMilliseconds + 3000;
            while (_timer.ElapsedMilliseconds < limit)
            {
                if (_port.BytesToRead > 0)
                {
                    byte b = (byte)_port.ReadByte();
                    Log($"[DEBUG RX] Byte recebido: 0x{b:X2}");
                    
                    if (b == 0x55)
                    {
                        Log("!!! Sincronismo 0x55 detectado !!!");
                        byte[] iso = new byte[5];
                        // Lê os 5 bytes do ISO Code
                        for (int i = 0; i < 5; i++) iso[i] = (byte)_port.ReadByte();
                        Log($"ISO Code: {BitConverter.ToString(iso).Replace("-", " ")}");
                        return true;
                    }
                }
                Thread.Sleep(5);
            }
            return false;
        }

        static void SendConnectionKey()
        {
            byte[] key = { 0x03, 0x34, 0x51, 0x88 };
            Log("Enviando Chave de Conexão...");
            foreach (byte b in key)
            {
                _port.Write(new byte[] { b }, 0, 1);
                Thread.Sleep(20);
                if (_port.BytesToRead > 0) _port.ReadByte(); // Descarta eco
            }
            Log("Chave enviada. Aguardando confirmação...");
            // Aqui você leria a resposta da ECU (espelhamento)
        }
    }
}