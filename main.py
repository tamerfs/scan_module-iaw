"""
Ponto de entrada: conecta no modulo IAW via cabo KKL 409.1 e testa o handshake.

Antes de rodar:
    pip install pyserial

Ajuste PORT abaixo para a porta serial do seu cabo:
    Windows: veja no Gerenciador de Dispositivos > Portas (COM & LPT), ex "COM5"
    Linux / Raspberry Pi: normalmente "/dev/ttyUSB0"
"""

import sys
from functools import partial

import serial

# Antes: os imports relativos exigiam executar este arquivo como parte de um
# pacote e causavam erro ao usar `python main.py`. Agora os imports absolutos
# permitem a execucao direta prevista para este ponto de entrada.
from src.serial_iaw import IawEcu
from src.serial_logger import SerialLogger

PORT = "COM5"  # <-- troque para a porta correta

# "uart" (baudrate literal 5bps) ou "break" (bit-bang via break_condition).
# Pode sobrescrever passando na linha de comando: python main.py break
SLOW_INIT_METHOD = sys.argv[1] if len(sys.argv) > 1 else "uart"


def print_ecu_identification():
    print("Identificacao conhecida da ECU:")
    for name, value in IawEcu.IDENTIFICATION.items():
        print(f"  {name}: {value}")


def main():
    print_ecu_identification()
    print(f"Metodo de slow-init: {SLOW_INIT_METHOD}")
    # Antes: IawEcu(PORT) abria serial.Serial diretamente e SerialLogger era
    # apenas importado, deixando o trafego sem captura estruturada. Agora a
    # fabrica injeta o logger no mesmo caminho usado pelo protocolo.
    logger_factory = partial(SerialLogger, capture_dir="data/captures")
    ecu = IawEcu(PORT, serial_factory=logger_factory)
    try:
        iso_code = ecu.connect_iaw_scan(slow_init_method=SLOW_INIT_METHOD)
        if iso_code is None:
            print("Handshake nao concluido. Consulte os diagnosticos acima.")
            return

        print(f"Handshake OK! ISO code recebido: {iso_code}")

        if not ecu.send_connection_key():
            print("Chave de conexao (03 34 51 88) nao foi confirmada pelo ECU.")
            return

        print("Conexao estabelecida!")

        # Requisicao de teste generica - o comando/payload real depende da
        # sub-familia do IAW. Comece só validando se o handshake acima
        # funciona; depois ajuste o payload aqui.
        resposta = ecu.send_frame(bytes([0x01]))
        print(f"Resposta bruta: {resposta.hex()}")

    except serial.SerialException as e:
        print(f"Erro de pyserial na porta {PORT}: {e}")
        print("Falha de biblioteca ou hardware; o traceback sera mantido para depuracao.")
        raise
    finally:
        ecu.close()


if __name__ == "__main__":
    print('chamado o init e logo apos a funcao main()')
    main()