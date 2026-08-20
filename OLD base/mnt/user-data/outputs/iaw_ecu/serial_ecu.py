"""
Comunicacao de baixo nivel com modulos de injecao Fiat / Magneti-Marelli IAW
via interface KKL (K-line), usando slow-init estilo ISO9141 a 5 baud.

IMPORTANTE: os valores de endereco/keyword abaixo sao os mais comuns usados
pela familia IAW-6F/8F/16F/18F/18FD (mesma familia geral de protocolo
documentada no projeto open-source "IAW Scan 2", licenca BSD-3-Clause:
https://github.com/TzOk83/IES2). O seu modulo (1ABG.81/5526 HH) pode ter
pequenas variacoes de timing/keyword - se o handshake falhar, vale abrir o
codigo-fonte desse projeto (pasta IES_2/) e comparar com a familia de ECU
mais proxima da sua antes de ajustar as constantes aqui.
"""

import time
from typing import Optional

import serial


class IawEcu:
    def __init__(
        self,
        port: str,
        address: int = 0x33,
        baudrate: int = 10400,
        timeout: float = 2.0,
    ):
        self.port_name = port
        self.address = address
        self.baudrate = baudrate
        self.timeout = timeout
        self.ser: Optional[serial.Serial] = None

    def open(self):
        self.ser = serial.Serial(
            self.port_name,
            baudrate=self.baudrate,
            bytesize=8,
            parity=serial.PARITY_NONE,
            stopbits=1,
            timeout=self.timeout,
        )

    def close(self):
        if self.ser and self.ser.is_open:
            self.ser.close()

    def _slow_init_send_address(self):
        """Bit-bang do byte de endereco do ECU a 5 bps via break_condition (linha K)."""
        bit_time = 0.2  # 1/5 baud = 200 ms por bit
        bits = [0]  # start bit (nivel baixo)
        bits += [(self.address >> i) & 1 for i in range(8)]
        bits.append(1)  # stop bit (nivel alto)
        for bit in bits:
            self.ser.break_condition = bit == 0
            time.sleep(bit_time)
        self.ser.break_condition = False

    def connect(self) -> bytes:
        """Executa o handshake de slow-init. Retorna as 2 keywords recebidas do ECU."""
        self.open()
        time.sleep(2.5)  # intervalo minimo de silencio antes do slow-init
        self._slow_init_send_address()

        self.ser.reset_input_buffer()

        sync = self._read_bytes(1, wait=0.3)
        if not sync or sync[0] != 0x55:
            raise ConnectionError(f"Sincronismo nao recebido (esperado 0x55, veio {sync!r})")

        kw = self._read_bytes(2, wait=0.3)
        if len(kw) != 2:
            raise ConnectionError("Keywords (KW1/KW2) nao recebidas")

        # Tester ecoa o complemento de KW2; ECU deve responder com o
        # complemento do byte de endereco enviado no slow-init.
        self._write_bytes(bytes([(~kw[1]) & 0xFF]))
        addr_echo = self._read_bytes(1, wait=0.3)
        if not addr_echo or addr_echo[0] != ((~self.address) & 0xFF):
            raise ConnectionError(f"ECU nao ecoou o complemento do endereco (veio {addr_echo!r})")

        return kw

    def _write_bytes(self, data: bytes):
        self.ser.write(data)
        self.ser.flush()

    def _read_bytes(self, n: int, wait: Optional[float] = None) -> bytes:
        if wait:
            time.sleep(wait)
        return self.ser.read(n)

    @staticmethod
    def checksum(data: bytes) -> int:
        return sum(data) & 0xFF

    def send_frame(self, payload: bytes, response_len: int = 64) -> bytes:
        """Monta um frame [tamanho][payload...][checksum], envia e devolve a resposta crua.

        O formato exato de payload/checksum pode variar por sub-familia do IAW -
        ajuste aqui depois de confirmar o comando certo para o seu ECU.
        """
        frame = bytes([len(payload)]) + payload
        frame += bytes([self.checksum(frame)])
        self._write_bytes(frame)
        return self._read_bytes(response_len, wait=0.1)