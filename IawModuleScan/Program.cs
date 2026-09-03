// executar primeiro o 'dotnet add package System.IO.Ports'

using System;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.Linq;


namespace IawDiagnosticTool
{
    class Program
    {
        // Configurações extraídas da engenharia reversa (IAW 1AB / 1AF)
        const string PORT_NAME = "COM5";
        const int BAUD_RATE = 4800; // Velocidade padrão IAW KWP71
        const byte ECU_ADDRESS = 0x33; // Endereço 5-baud padrão Fiat/Marelli
        const int BIT_TIME_MS = 200;   // 200ms = 5 Baud

        static SerialPort _port = null!;
        static Stopwatch _timer = new Stopwatch();

        static void Main(string[] args)
        {
            Console.WriteLine("--- IAW 1ABG Diagnostic Tool (C# Version) ---");
            Console.WriteLine($"Config: {PORT_NAME}, 4800bps, Addr: 0x{ECU_ADDRESS:X2}");

            _port = new SerialPort(PORT_NAME, BAUD_RATE, Parity.None, 8, StopBits.One);
            _port.ReadTimeout = 3000;
            _port.WriteTimeout = 1000;

            try
            {
                _timer.Start();
                Log("Abrindo porta...");
                _port.Open();

                // 1. Despertar (Sondagem 9600 como no MES)
                PerformWakeup();

                // 2. Slow Init (Bit-bang 5 Baud)
                if (PerformSlowInit())
                {
                    Log("Handshake KWP71 concluído com sucesso!");
                    
                    // 3. Chave de Conexão (Sequência MES)
                    if (SendConnectionKey())
                    {
                        Log("Sessão de diagnóstico aberta. Lendo dados...");
                        ReadEcuInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"ERRO FATAL: {ex.Message}");
            }
            finally
            {
                if (_port.IsOpen) _port.Close();
                Log("Porta fechada. Pressione qualquer tecla para sair.");
                Console.ReadKey();
            }
        }

        static void Log(string message)
        {
            Console.WriteLine($"[{_timer.ElapsedMilliseconds / 1000.0:F3}s] {message}");
        }

        static void PerformWakeup()
        {
            Log("Iniciando sondagem de interface (9600 baud)...");
            _port.BaudRate = 9600;
            _port.RtsEnable = true;
            _port.DtrEnable = true;

            _port.Write(new byte[] { 0x00 }, 0, 1);
            Thread.Sleep(50);
            
            if (_port.BytesToRead > 0)
            {
                byte res = (byte)_port.ReadByte();
                Log($"Resposta da interface: 0x{res:X2}");
            }

            _port.Close();
            Log("Aguardando silêncio de 2 segundos...");
            Thread.Sleep(2000);
            _port.BaudRate = BAUD_RATE;
            _port.Open();
        }

        static bool PerformSlowInit()
        {
            Log("Executando Slow Init (5 Baud) via BreakState...");
            
            // Garantir que DTR está False como no seu TEST-005 que teve sucesso parcial
            _port.DtrEnable = false; 
            _port.RtsEnable = false;

            // Bit-bang do endereço 0x33 (LSB first)
            // Start bit (0), 8 bits de dados, Stop bit (1)
            byte[] bits = new byte[10];
            bits[0] = 0; // Start
            for (int i = 0; i < 8; i++) bits[i + 1] = (byte)((ECU_ADDRESS >> i) & 1);
            bits[9] = 1; // Stop

            foreach (var bit in bits)
            {
                // No KKL: BreakState = true coloca a linha em 0V
                _port.BreakState = (bit == 0);
                // O MultiECUScan alterna RTS junto com o Break em alguns drivers
                _port.RtsEnable = (bit == 0); 
                
                Thread.Sleep(BIT_TIME_MS);
            }

            _port.BreakState = false;
            _port.RtsEnable = false;
            Log("Fim do Slow Init. Aguardando 0x55 (Sincronismo)...");

            // Busca faminta pelo 0x55
            long limit = _timer.ElapsedMilliseconds + 4000;
            while (_timer.ElapsedMilliseconds < limit)
            {
                if (_port.BytesToRead > 0)
                {
                    byte b = (byte)_port.ReadByte();
                    if (b == 0x55)
                    {
                        Log("Sincronismo 0x55 recebido!");
                        byte[] iso = new byte[5];
                        for (int i = 0; i < 5; i++) iso[i] = (byte)_port.ReadByte();
                        Log($"ISO Code Detectado: {BitConverter.ToString(iso).Replace("-", " ")}");
                        return true;
                    }
                }
                Thread.Sleep(10);
            }

            Log("Falha: ECU não enviou 0x55.");
            return false;
        }

        static bool SendConnectionKey()
        {
            byte[] key = { 0x03, 0x34, 0x51, 0x88 };
            Log($"Enviando chave de conexão: {BitConverter.ToString(key)}");

            try {
                for (int i = 0; i < 3; i++)
                {
                    _port.Write(key, i, 1);
                    int echo = _port.ReadByte(); // Aguarda eco
                }
                _port.Write(key, 3, 1);
                
                byte[] response = new byte[5];
                for (int i = 0; i < 5; i++) response[i] = (byte)_port.ReadByte();
                
                Log($"Resposta da chave: {BitConverter.ToString(response)}");
                return response.Skip(1).SequenceEqual(key);
            }
            catch { return false; }
        }

        static void ReadEcuInfo()
        {
            // Comando 0x01: Identificação no protocolo KWP71
            byte[] command = { 0x01, 0x01 }; // [Tamanho][Dados]
            byte checksum = (byte)(command.Sum(b => b) & 0xFF);
            byte[] frame = { 0x01, 0x01, checksum };

            Log("Solicitando identificação...");
            _port.Write(frame, 0, 3);
            
            // Ler eco e resposta
            Thread.Sleep(200);
            if (_port.BytesToRead > 0)
            {
                byte[] buffer = new byte[_port.BytesToRead];
                _port.Read(buffer, 0, buffer.Length);
                Log($"Dados Recebidos (Hex): {BitConverter.ToString(buffer)}");
            }
        }
    }
}