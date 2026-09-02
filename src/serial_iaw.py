import time
from typing import Any, Callable, Optional
import serial
from serial.tools import list_ports

class IawEcu:
    IAW_SCAN_COMM_BAUD = 4800
    SLOW_INIT_BIT_TIME = 0.200 # 200ms por bit (5 baud)
    SLOW_INIT_RESPONSE_TIMEOUT = 6.0 # Janela estendida para análise

    def __init__(
        self,
        port: str,
        address: int = 0x33,
        baudrate: int = 10400,
        timeout: float = 2.0,
        line_state: bool = False, # DTR em False conforme TEST-005
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

    def _diagnostic(self, message: str):
        elapsed = f" +{time.monotonic() - self.diagnostic_started:.3f}s" if self.diagnostic_started else ""
        print(f"[DIAGNOSTICO{elapsed}] {message}")

    def open(self):
        if self.ser is None:
            self.ser = self.serial_factory(port=self.port_name, baudrate=self.baudrate, timeout=self.timeout)
        else:
            self.ser.baudrate = self.baudrate
            if not self.ser.is_open: self.ser.open()
        
        self.ser.dtr = self.line_state 
        self.ser.rts = False
        return self.ser

    def _serial_state(self) -> str:
        if not self.ser or not self.ser.is_open: return "CLOSED"
        return f"RTS={int(self.ser.rts)} DTR={int(self.ser.dtr)} BRK={int(self.ser.break_condition)}"

    def close(self):
        if self.ser and self.ser.is_open: self.ser.close()

    def _slow_init_send_address_break_rts(self):
        """Bit-bang RTS+BREAK com estabilização prévia."""
        self.ser.dtr = False 
        
        # 1. Estabilização: Garante linha em HIGH (RTS/BRK=0) antes de começar
        self.ser.rts = False
        self.ser.break_condition = False
        self._diagnostic("Estabilizando linha (HIGH) por 500ms...")
        time.sleep(0.5)

        bit_time = self.SLOW_INIT_BIT_TIME
        bits = [0]  # start bit
        bits += [(self.address >> i) & 1 for i in range(8)]
        bits.append(1)  # stop bit
        
        self._diagnostic(f"Enviando 5-baud addr 0x{self.address:02X}: {''.join(str(b) for b in bits)}")

        for index, bit in enumerate(bits):
            # Asserted (True) = 0V na linha K
            is_low = (bit == 0)
            self.ser.rts = is_low
            self.ser.break_condition = is_low
            # Log minimalista para não atrasar o timing do bit
            # print(f" Bit {index} ({bit})") 
            time.sleep(bit_time)

        # Finaliza: Linha em HIGH
        self.ser.break_condition = False
        self.ser.rts = False
        self._diagnostic(f"Slow-init finalizado. Estado final: {self._serial_state()}")

    def connect_iaw_scan(self, slow_init_method: str = "break_rts") -> Optional[str]:
        self.diagnostic_started = time.monotonic()
        self._diagnostic(f"Iniciando sequência IAW (MES Clone) na porta {self.port_name}")

        # 1. Sondagem Inicial (Handles separados como no MES)
        self.baudrate = 9600
        self.open()
        self.ser.write(bytes([0x00]))
        res = self.ser.read(1)
        self._diagnostic(f"Sondagem 9600: TX=00, RX={res.hex() or 'nada'}")
        self.close()
        
        # 2. Silêncio de 5 segundos (exatamente como no log MES Sessão 7 -> Sessão 8)
        self._diagnostic("Aguardando 5s de silêncio (padrão MES)...")
        time.sleep(5.0)

        # 3. Preparação para Slow-Init
        self.baudrate = 4800
        self.open()
        self.ser.reset_input_buffer() # Limpa resquícios da sondagem

        # Executa o pulso
        self._slow_init_send_address_break_rts()

        # 4. Captura e Análise de Resposta
        self._diagnostic("Aguardando resposta da ECU... (procurando 0x55)")
        
        start_wait = time.monotonic()
        packet = b""
        
        # Vamos ler tudo o que chegar para analisar o padrão de ruído
        while (time.monotonic() - start_wait) < self.SLOW_INIT_RESPONSE_TIMEOUT:
            if self.ser.in_waiting > 0:
                ts = time.monotonic() - self.diagnostic_started
                byte = self.ser.read(1)
                
                # Print de alta visibilidade para cada byte recebido
                print(f"[RX @ {ts:07.3f}s] Byte: 0x{byte.hex().upper()}")
                
                if byte == b"\x55" and not packet:
                    self._diagnostic("!!! Sincronismo 0x55 ENCONTRADO !!!")
                    packet = byte + self.ser.read(5)
                    # Não paramos o loop para ver se vem mais lixo depois, 
                    # ou podemos dar break se quisermos ser rápidos
                    break 
            
            time.sleep(0.001) # Check rápido (1ms)

        if not packet or len(packet) < 6:
            self._diagnostic("Falha: Sincronismo 0x55 não detectado.")
            return None

        iso_code = packet[1:6].hex().upper()
        self._diagnostic(f"Handshake KWP71 SUCESSO! ISO: {iso_code}")
        return iso_code

    # Métodos simplificados para teste
    def send_connection_key(self) -> bool:
        key = bytes([0x03, 0x34, 0x51, 0x88])
        for b in key[:-1]:
            self.ser.write(bytes([b]))
            if self.ser.read(1) != bytes([b]): return False
        self.ser.write(bytes([key[-1]]))
        return len(self.ser.read(5)) == 5

    def send_frame(self, payload: bytes) -> bytes:
        frame = bytes([len(payload)]) + payload
        frame += bytes([sum(frame) & 0xFF])
        self.ser.write(frame)
        self.ser.read(len(frame))
        return self.ser.read(64)