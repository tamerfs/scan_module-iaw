import sys
import time
from functools import partial
import serial
from src.serial_iaw import IawEcu
from src.serial_logger import SerialLogger

PORT = "COM3" 
# Método identificado na engenharia reversa como o correto (RTS + BREAK sincronizados)
DEFAULT_METHOD = "break_rts" 
SLOW_INIT_METHOD = sys.argv[1] if len(sys.argv) > 1 else DEFAULT_METHOD

def main():
    print(f"--- Iniciando Conexão ECU IAW 1ABG ---")
    print(f"Método: {SLOW_INIT_METHOD}")

    # Logger configurado para salvar na pasta data/captures
    logger_factory = partial(SerialLogger, capture_dir="data/captures")
    ecu = IawEcu(PORT, serial_factory=logger_factory)

    try:
        # 1. Handshake KWP71 (Despertar + Slow Init)
        print("Aguardando ISO Code...")
        iso_code = ecu.connect_iaw_scan(slow_init_method=SLOW_INIT_METHOD)
        
        if iso_code is None:
            print("\n[ERRO] Handshake falhou. A ECU não enviou o sincronismo 0x55.")
            return

        print(f"\n[SUCESSO] ISO Code: {iso_code}")
        time.sleep(0.2) # Pausa de estabilização

        # 2. Chave de Conexão (Obrigatório para IAW 1AB/1AF)
        print("Enviando chave de segurança (03 34 51 88)...")
        if not ecu.send_connection_key():
            print("[ERRO] Chave de conexão não confirmada pela ECU.")
            return

        print("[OK] Conexão Total Estabelecida!")

        # 3. Teste de Leitura (Frame 0x01 - Identificação)
        print("\nSolicitando dados da ECU...")
        res = ecu.send_frame(bytes([0x01]))
        if res:
            print(f"Resposta: {res.hex().upper()}")

    except serial.SerialException as e:
        print(f"\n[ERRO SERIAL] Verifique o cabo na porta {PORT}: {e}")
    except Exception as e:
        print(f"\n[ERRO] {e}")
    finally:
        ecu.close()
        print("\nSessão encerrada.")

if __name__ == "__main__":
    main()