"""
serial_iaw.py
--------------
Comunicação de baixo nível com o modulo de injecao Marelli IAW
(protocolo K-line, iniciacao "slow init" a 5 baud, muito parecido
com ISO 9141-2 / KWP71) via cabo KKL 409.1 (chip CH340/CH341).

Nao existe biblioteca Python pronta para o protocolo Marelli IAW
especificamente (o IAW Scan2, open-source, e em C# e nao da pra
importar em Python). O que existe de reaproveitavel sao
implementacoes do transporte K-line/ISO9141 genericas (ex.:
projeto OBD9141 em C++/Arduino, ou libs KWP2000 em Python feitas
para OBD2 padrao). A parte generica (handshake, framing, checksum)
esta implementada abaixo. A parte especifica do seu modulo
(quais PIDs/servicos ele aceita) precisa ser descoberta por
tentativa e erro ou documentacao da comunidade Marelli/Fiat.

Uso basico:
    from serial_iaw import IAWConnection

    conn = IAWConnection("/dev/ttyUSB0")   # ou "COM5" no Windows
    conn.connect()
    resp = conn.send_request(bytes([0x69, 0x0]))  # exemplo de request
    print(resp)
"""

import serial
import time


class IAWConnection:
    def __init__(self, port, ecu_addr=0x33, kline_baud=10400, timeout=2.0):
        self.port = port
        self.ecu_addr = ecu_addr
        self.kline_baud = kline_baud
        self.timeout = timeout
        self.ser = None

    # ------------------------------------------------------------------
    # Etapa 1: slow init a 5 baud
    # ------------------------------------------------------------------
    def _slow_init(self):
        """
        Abre a porta a 5 baud e manda o byte de endereco do ECU
        (0x33 e o padrao ISO9141; alguns Marelli usam outro valor,
        ajuste se nao houver resposta). Depois reabre a porta na
        velocidade normal de comunicacao.
        """
        init_ser = serial.Serial(
            self.port, baudrate=5, bytesize=8,
            parity=serial.PARITY_NONE, stopbits=1, timeout=self.timeout
        )
        init_ser.write(bytes([self.ecu_addr]))
        init_ser.flush()
        # tempo para o byte inteiro sair a 5 baud (~2s por byte)
        time.sleep(2.2)
        init_ser.close()

        self.ser = serial.Serial(
            self.port, baudrate=self.kline_baud, bytesize=8,
            parity=serial.PARITY_NONE, stopbits=1, timeout=self.timeout
        )

    # ------------------------------------------------------------------
    # Etapa 2: handshake de sincronismo (keywords)
    # ------------------------------------------------------------------
    def connect(self):
        self._slow_init()

        sync = self.ser.read(1)
        if sync != b"\x55":
            raise ConnectionError(
                f"Nao recebi o byte de sync 0x55 do modulo (recebi {sync!r}). "
                "Confira o pino K-line, o adaptador 3-pinos e o baudrate."
            )

        kw = self.ser.read(2)
        if len(kw) != 2:
            raise ConnectionError("Nao recebi as 2 keywords do modulo.")
        kw1, kw2 = kw[0], kw[1]

        # tester deve ecoar o complemento de kw2 dentro de uma janela curta
        time.sleep(0.03)
        self.ser.write(bytes([(~kw2) & 0xFF]))
        self.ser.flush()

        # ECU deve responder com o complemento do endereco enviado
        ack = self.ser.read(1)
        if ack != bytes([(~self.ecu_addr) & 0xFF]):
            raise ConnectionError(
                f"Handshake nao confirmado (esperava {(~self.ecu_addr) & 0xFF:#x}, "
                f"recebi {ack!r}). Keywords recebidas: {kw1:#x} {kw2:#x}"
            )

        print(f"Conectado! Keywords: {kw1:#x} {kw2:#x}")
        return kw1, kw2

    # ------------------------------------------------------------------
    # Envio de frame / leitura de resposta
    # ------------------------------------------------------------------
    @staticmethod
    def _checksum(data: bytes) -> int:
        return sum(data) & 0xFF

    def send_request(self, payload: bytes) -> bytes:
        """
        Monta um frame simples [len][payload...][checksum] e le a resposta.
        O formato exato de frame/servicos do seu modulo pode variar -
        isso e um ponto de partida para voce testar e ajustar.
        """
        if self.ser is None:
            raise RuntimeError("Chame connect() antes de enviar requests.")

        frame = bytes([len(payload)]) + payload
        frame += bytes([self._checksum(frame)])

        self.ser.reset_input_buffer()
        self.ser.write(frame)
        self.ser.flush()

        time.sleep(0.05)
        response = self.ser.read(64)
        return response

    def close(self):
        if self.ser:
            self.ser.close()


if __name__ == "__main__":
    import sys

    port = sys.argv[1] if len(sys.argv) > 1 else "/dev/ttyUSB0"
    conn = IAWConnection(port)
    try:
        conn.connect()
        # Requisicao de teste - ajuste conforme for descobrindo os
        # comandos que o seu modulo aceita.
        resp = conn.send_request(bytes([0x69, 0x00]))
        print("Resposta bruta:", resp.hex())
    finally:
        conn.close()
