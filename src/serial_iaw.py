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
from typing import Any, Callable, Optional
import serial
from serial.tools import list_ports

class IawEcu:
    IAW_SCAN_COMM_BAUD = 4800
    SLOW_INIT_BIT_TIME = 0.2
    SLOW_INIT_RESPONSE_TIMEOUT = 4.0 # Janela generosa como no código C
    COMMON_BAUDRATES = (10400, 9600, 4800, 19200, 38400, 57600, 115200)
    
    # Dados de referência para IAW 1AB / 1AF
    IDENTIFICATION = {
        "family": "Magneti Marelli IAW 1AB / 1AF",
        "iso_code": "B0 86 83 15 23",
        "interface": "VagCom/KKL USB (CH340)",
    }

    def __init__(
        self,
        port: str,
        address: int = 0x33,
        baudrate: int = 10400,
        timeout: float = 2.0,
        line_state: bool = True,
        serial_factory: Callable[..., Any] = serial.Serial,
    ):
        self.port_name = port
        self.address = address
        self.baudrate = baudrate
        self.timeout = timeout
        self.line_state = line_state
        self.serial_factory = serial_factory
        self.ser: Optional[serial.Serial] = None
        self.diagnostics = []
        self.diagnostic_started = None

    @staticmethod
    def available_ports():
        return list(list_ports.comports())

    def _diagnostic(self, message: str):
        self.diagnostics.append(message)
        elapsed = ""
        if self.diagnostic_started is not None:
            elapsed = f" +{time.monotonic() - self.diagnostic_started:.3f}s"
        print(f"[DIAGNOSTICO{elapsed}] {message}")

    def open(self):
        """Abre ou reabre a porta serial garantindo a alimentação do cabo."""
        if self.ser is None:
            self.ser = self.serial_factory(
                port=self.port_name,
                baudrate=self.baudrate,
                timeout=self.timeout,
            )
        else:
            # Atualiza baudrate no objeto (importante para SerialLogger registrar)
            self.ser.baudrate = self.baudrate
            if not self.ser.is_open:
                self.ser.open()
        
        # Alimenta o circuito do adaptador KKL
        self.ser.dtr = self.line_state
        self.ser.rts = self.line_state
        return self.ser

    def close(self):
        if self.ser and self.ser.is_open:
            self.ser.close()

    def _serial_state(self) -> str:
        if not self.ser or not self.ser.is_open: return "CLOSED"
        return f"Baud={self.ser.baudrate} RTS={int(self.ser.rts)} DTR={int(self.ser.dtr)} BRK={int(self.ser.break_condition)}"

    def _slow_init_send_address_break_rts(self):
        """Bit-bang RTS+BREAK sincronizados (padrão MultiECUScan)."""
        if self.ser is None or not self.ser.is_open:
            raise RuntimeError("Chame open() antes do slow-init.")

        # Garante alimentação durante o processo
        self.ser.dtr = self.line_state
        
        bit_time = self.SLOW_INIT_BIT_TIME
        bits = [0]  # start bit (LOW)
        bits += [(self.address >> i) & 1 for i in range(8)]
        bits.append(1)  # stop bit (HIGH)
        
        self._diagnostic(f"Iniciando pulso 5 baud no endereço 0x{self.address:02X}...")

        for index, bit in enumerate(bits):
            # No KKL: RTS/BREAK em True = Nível Baixo na linha K
            asserted = (bit == 0)
            self.ser.rts = asserted
            self.ser.break_condition = asserted
            time.sleep(bit_time)

        # Restaura estado de repouso (Linha K em HIGH)
        self.ser.break_condition = False
        self.ser.rts = self.line_state
        self._diagnostic(f"Slow-init finalizado. Estado: {self._serial_state()}")

    def connect_iaw_scan(self, slow_init_method: str = "break_rts") -> Optional[str]:
        """Handshake KWP71 completo seguindo a engenharia reversa."""
        self.diagnostics.clear()
        self.diagnostic_started = time.monotonic()
        self._diagnostic(f"Conectando ECU na porta {self.port_name}...")

        # 1. Sondagem de Interface (9600 baud)
        self.baudrate = 9600
        self.open()
        self._write_bytes(bytes([0x00]))
        res = self._read_bytes(1, wait=0.05)
        self._diagnostic(f"Sondagem (9600): enviou 00, recebeu {res.hex() or 'nada'}")
        self.close()
        
        # Pausa obrigatória de silêncio observada no monitor (2s)
        time.sleep(2.0)

        # 2. Inicialização Lenta (4800 baud)
        self.baudrate = self.IAW_SCAN_COMM_BAUD
        self.open()
        
        if slow_init_method == "break_rts":
            self._slow_init_send_address_break_rts()
        else:
            self._slow_init_send_address_uart()

        # 3. Caça ao Sincronismo 0x55 (KWP71)
        self._diagnostic("Aguardando sincronismo 0x55...")
        start_wait = time.monotonic()
        packet = b""
        
        while (time.monotonic() - start_wait) < self.SLOW_INIT_RESPONSE_TIMEOUT:
            if self.ser.in_waiting > 0:
                byte = self.ser.read(1)
                if byte == b"\x55":
                    # Encontrou o início! Lê o ISO (5 bytes) + Checksum (1 byte)
                    packet = byte + self.ser.read(5)
                    break
            time.sleep(0.01)

        if not packet or len(packet) < 6:
            self._diagnostic(f"Falha: ECU não respondeu. Recebido: {packet.hex().upper() or 'vazio'}")
            return None

        # 4. Validação de Checksum (Soma dos 5 primeiros bytes & 0x7F)
        checksum_calc = sum(packet[:5]) & 0x7F
        checksum_recv = packet[5] & 0x7F
        
        self._diagnostic(f"Pacote KWP71: {packet.hex().upper()}")
        
        if checksum_calc != checksum_recv:
            self._diagnostic(f"Aviso: Checksum divergente (Esperado: {checksum_calc:02X}, Recebido: {checksum_recv:02X})")

        iso_code = packet[1:6].hex().upper()
        self._diagnostic(f"Handshake OK! ISO: {iso_code}")
        return iso_code

    # Chave de segurança para liberar diagnóstico na família IAW 1ABG
    CONNECTION_KEY = bytes([0x03, 0x34, 0x51, 0x88])

    def send_connection_key(self) -> bool:
        """Envia a sequência 03 34 51 88 e valida o espelhamento da ECU."""
        self._diagnostic(f"Enviando Connection Key: {self.CONNECTION_KEY.hex().upper()}")
        
        # Envia os 3 primeiros bytes e espera eco simples
        for byte in self.CONNECTION_KEY[:-1]:
            self._write_bytes(bytes([byte]))
            echo = self._read_bytes(1, wait=0.05)
            if not echo or echo[0] != byte:
                self._diagnostic(f"Falha na chave: Enviado {byte:02X}, Eco {echo.hex() or 'nada'}")
                return False

        # Envia o último byte
        last_byte = self.CONNECTION_KEY[-1]
        self._write_bytes(bytes([last_byte]))
        
        # A resposta final deve ser: o eco do ultimo byte + os 4 bytes da chave repetidos
        # Total 5 bytes de resposta
        response = self._read_bytes(5, wait=0.1)
        self._diagnostic(f"Confirmação da chave: {response.hex().upper()}")

        if len(response) < 5 or response[1:] != self.CONNECTION_KEY:
            self._diagnostic("Erro: ECU não confirmou a chave de segurança.")
            return False

        self._diagnostic("Conexão de diagnóstico ATIVA.")
        return True

    def send_frame(self, payload: bytes, response_len: int = 64) -> bytes:
        """Envia comando no formato [Tamanho][Dados][Checksum]."""
        # Formato comum KWP71: Payload + Checksum (Soma dos bytes)
        frame = bytes([len(payload)]) + payload
        frame += bytes([sum(frame) & 0xFF])
        
        self.ser.reset_input_buffer()
        self._write_bytes(frame)
        
        # O adaptador costuma ecoar o que escrevemos
        echo = self._read_bytes(len(frame))
        
        # Resposta real da ECU
        return self._read_bytes(response_len, wait=0.1)

    def _write_bytes(self, data: bytes):
        self.ser.write(data)
        self.ser.flush()

    def _read_bytes(self, n: int, wait: Optional[float] = None) -> bytes:
        if wait: time.sleep(wait)
        return self.ser.read(n)

    def _slow_init_send_address_uart(self):
        """Método alternativo via hardware UART (5 baud)."""
        original_baud = self.ser.baudrate
        self.ser.baudrate = 5
        self.ser.write(bytes([self.address]))
        self.ser.flush()
        time.sleep(2.2)
        self.ser.baudrate = original_baud