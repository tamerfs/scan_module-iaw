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
            Console.WriteLine("--- IAW 1ABG Scanner v15 (The Collector) ---");
            _timer.Start();

            _port = new SerialPort(PORT_NAME, BAUD_RATE, Parity.None, 8, StopBits.One);
            _port.ReadTimeout = 2000;

            try
            {
                Log("Iniciando...");
                _port.Open();
                _port.DtrEnable = true;
                _port.RtsEnable = false;

                if (PerformSlowInit(0x10))
                {
                    Log("Handshake OK! Autenticando...");
                    if (SendKeyAndSync())
                    {
                        Log("Sessão ATIVA!");
                        
                        // Tentaremos ler a tabela de sensores repetidamente
                        for (int i = 1; i <= 3; i++)
                        {
                            Log($"\n--- Ciclo de Leitura #{i} ---");
                            CollectEcuData();
                            Thread.Sleep(1000);
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
            Thread.Sleep(300);
            return _port.BytesToRead >= 4;
        }

        static void CollectEcuData()
        {
            // 1. Solicita comando 0x08
            byte[] cmdFrame = { 0x02, 0x08, 0x0A };
            _port.DiscardInBuffer();
            _port.Write(cmdFrame, 0, 3);
            Log("TX -> Pedido 0x08 enviado.");

            // 2. Aguarda a ECU enviar o frame de Busy (03 0A 00 0D)
            Thread.Sleep(300);
            
            if (_port.BytesToRead > 0)
            {
                byte[] response1 = new byte[_port.BytesToRead];
                _port.Read(response1, 0, response1.Length);
                Log($"RX 1 (Resposta ao comando) -> {BitConverter.ToString(response1)}");

                // Se a ECU respondeu (mesmo que seja eco + dados), enviamos o gatilho 0x03
                Log("Enviando gatilho 0x03...");
                _port.Write(new byte[] { 0x03 }, 0, 1);

                // 3. COLETA CRÍTICA: Aguarda 1 segundo e lê TUDO o que a ECU enviou
                Thread.Sleep(1000);
                
                if (_port.BytesToRead > 0)
                {
                    byte[] rawData = new byte[_port.BytesToRead];
                    _port.Read(rawData, 0, rawData.Length);
                    Log($"COLETA BRUTA ({rawData.Length} bytes) -> {BitConverter.ToString(rawData)}");

                    // Procura o início de um frame de sensores (geralmente começa com o tamanho, ex: 1F ou 20)
                    // No IAW 1.6 16V a tabela costuma ter 31 (0x1F) ou 32 (0x20) bytes.
                    if (rawData.Length > 20)
                    {
                        Log("!!! TABELA IDENTIFICADA NO BLOCO !!!");
                        // Tentativa de decifrar baseada no seu print (11.8V | 0 RPM | 48C)
                        // Vamos procurar onde os valores fazem sentido.
                        ParseIawData(rawData);
                    }
                }
                else
                {
                    Log("A ECU não enviou dados após o gatilho 0x03.");
                }
            }
            else
            {
                Log("A ECU não reagiu ao comando 0x08.");
            }
        }

        static void ParseIawData(byte[] raw)
        {
            try {
                // Remove o eco do 0x03 se ele estiver no início
                byte[] data = raw;
                if (data[0] == 0x03 && data.Length > 20) data = data.Skip(1).ToArray();

                // Se o primeiro byte for o tamanho (ex: 1F), pulamos ele para chegar nos dados
                int offset = 0;
                if (data[0] > 0x10 && data[0] < 0x30) offset = 1;

                // Mapeamento provável para IAW 1ABG:
                // Bateria: Geralmente Byte 10 ou 12. RPM: Byte 1 e 2. Água: Byte 3.
                // Como não temos certeza do índice, vamos imprimir os candidatos:
                Console.WriteLine("\n--- VALORES ENCONTRADOS ---");
                Console.WriteLine($"Bateria (Candidato 1): {data[offset + 10] * 0.065:F2}V");
                Console.WriteLine($"Bateria (Candidato 2): {data[offset + 11] * 0.065:F2}V");
                
                int rpmMSB = data[offset + 1];
                int rpmLSB = data[offset + 2];
                Console.WriteLine($"RPM (Calculado): {(rpmMSB << 8 | rpmLSB)}"); // Algumas usam 2 bytes
                Console.WriteLine($"RPM (Simples): {data[offset + 1] * 40}"); // Outras usam 1 byte
                
                Console.WriteLine($"Temp Água: {data[offset + 3] - 40}°C");
                Console.WriteLine("---------------------------\n");
            } catch {
                Log("Não foi possível processar os dados brutos ainda.");
            }
        }
    }
}