"""Leitura da ECU Marelli IAW 1AB via K-Line (cabo KKL/CH340).

Protocolo decodificado das capturas USB do MultiEcuScan:
  frame   = [size][cmd][args...][sumHi][sumLo]   (soma de 16 bits de tudo antes do checksum)
  resposta= [size][~cmd][valor...][sumHi][sumLo]  (~0x31 = 0xCE, ~0x32 = 0xCD)
  NACK    = 03 0A 00 0D
  Cada bloco recebido da ECU precisa ser confirmado com 03 09 00 0C (ACK).
"""
import time

import serial

BAUD = 4800
ACK_FRAME = bytes([0x03, 0x09, 0x00, 0x0C])


def build_frame(cmd, *args):
    f = [len(args) + 3, cmd, *args]
    s = sum(f)
    f += [(s >> 8) & 0xFF, s & 0xFF]
    return bytes(f)


def checksum_ok(f):
    if len(f) < 4:
        return False
    s = sum(f[:-2])
    return f[-2] == ((s >> 8) & 0xFF) and f[-1] == (s & 0xFF)


def u(payload):
    """payload big-endian -> inteiro"""
    return int.from_bytes(payload, "big")


# nome: (cmd, id, conversão). Conversões confirmadas nas capturas / prints do MultiEcuScan.
SENSORS = {
    "rpm":          (0x31, 0x00, lambda p: u(p) * 25),
    "bateria_v":    (0x31, 0x08, lambda p: u(p) * 0.0628),
    "temp_agua":    (0x31, 0x06, lambda p: u(p) - 40),
    "temp_ar":      (0x31, 0x05, lambda p: u(p) - 40),
    "avanco_deg":   (0x31, 0x02, lambda p: u(p) * 0.5),
    "inj_ms":       (0x31, 0x01, lambda p: u(p) * 0.00326),   # aprox.
    "map_mbar":     (0x31, 0x03, lambda p: u(p)),
    "atm_mbar":     (0x31, 0x04, lambda p: u(p)),
    "carga_mgi":    (0x31, 0x1D, lambda p: u(p) * 5.2),
    "borboleta":    (0x31, 0x07, lambda p: u(p) * 0.44),      # aprox.
    "lambda_v":     (0x31, 0x1B, lambda p: u(p) * 0.0049),
    "integrador":   (0x31, 0x0C, lambda p: u(p) / 64.0),      # aprox.
    "passos":       (0x31, 0x0F, lambda p: u(p)),
}

# a leitura é ~3 sensores/s (limite do protocolo, o MultiEcuScan tem o mesmo):
# os rápidos entram em todo ciclo, os lentos revezam 1 por ciclo.
FAST = ["rpm", "inj_ms", "lambda_v", "map_mbar"]
SLOW = ["bateria_v", "temp_agua", "temp_ar", "carga_mgi", "avanco_deg",
        "borboleta", "integrador", "passos", "atm_mbar"]


class Ecu:
    def __init__(self, port="/dev/ttyUSB0", gap_s=0.07, debug=False):
        self.port = port
        self.gap_s = gap_s
        self.debug = debug
        self.ser = None
        self._last_rx = 0.0

    # ---------- baixo nível ----------
    def open(self):
        self.ser = serial.Serial(self.port, BAUD, bytesize=8, parity="N",
                                 stopbits=1, timeout=0.1)
        self.ser.dtr = True
        self.ser.rts = False

    def close(self):
        if self.ser and self.ser.is_open:
            self.ser.close()

    def _log(self, msg):
        if self.debug:
            print(f"[ecu] {msg}", flush=True)

    def _read_byte(self, timeout):
        self.ser.timeout = timeout
        b = self.ser.read(1)
        if b:
            self._last_rx = time.monotonic()
            return b[0]
        return None

    def _send(self, frame, check_echo=True):
        # não transmitir logo depois da ECU falar
        wait = self.gap_s - (time.monotonic() - self._last_rx)
        if wait > 0:
            time.sleep(wait)
        self._log(f"TX {frame.hex(' ')}")
        for b in frame:
            self.ser.write(bytes([b]))
            self._read_byte(0.1)  # eco do cabo

    def _read_frame(self, timeout=0.4):
        deadline = time.monotonic() + timeout
        first = None
        while time.monotonic() < deadline:
            b = self._read_byte(0.02)
            if b:  # ignora None e 0x00 solto
                first = b
                break
        if first is None:
            return None
        frame = [first]
        for _ in range(first):
            b = self._read_byte(0.1)
            if b is None:
                return None
            frame.append(b)
        frame = bytes(frame)
        self._log(f"RX {frame.hex(' ')}")
        return frame

    def drain_acks(self):
        """Confirma o bloco recebido; repete até a ECU devolver o mesmo ACK."""
        for _ in range(6):
            self._send(ACK_FRAME)
            f = self._read_frame(0.3)
            if f is None or (len(f) == 4 and f[1] == 0x09):
                return

    # ---------- inicialização ----------
    def slow_init(self, address=0x10):
        ser = self.ser
        ser.reset_input_buffer()
        bits = [0] + [(address >> i) & 1 for i in range(8)] + [1]
        for bit in bits:
            t0 = time.perf_counter()
            level = bit == 0
            ser.break_condition = level
            ser.rts = level
            time.sleep(0.18)
            while time.perf_counter() - t0 < 0.2:
                pass
        ser.break_condition = False
        ser.rts = False

        deadline = time.monotonic() + 3.0
        while time.monotonic() < deadline:
            if self._read_byte(0.05) == 0x55:
                burst = bytearray()
                while True:
                    b = self._read_byte(0.5)
                    if b is None:
                        break
                    burst.append(b)
                self._log(f"sync 55 + burst {bytes(burst).hex(' ')}")
                return bytes(burst) == bytes.fromhex("b086831523")
        return False

    def start_session(self):
        # chave que o MultiEcuScan envia; a ECU devolve o mesmo frame
        for b in bytes([0x03, 0x34, 0x51, 0x88]):
            self.ser.write(bytes([b]))
            self._read_byte(0.1)
        self._read_frame(0.5)

        self._send(build_frame(0x00, 0x00))
        ok = self._read_frame(0.5) is not None
        self.drain_acks()

        self._send(build_frame(0x51, 0x02))  # identificação
        self._read_frame(0.5)
        self.drain_acks()
        return ok

    def connect(self):
        self.open()
        if not self.slow_init():
            raise IOError("slow init falhou (ECU não respondeu o sync 55)")
        if not self.start_session():
            raise IOError("sessão não iniciou")

    # ---------- leitura ----------
    def query(self, cmd, ident):
        """Devolve o payload (bytes) ou None (sem resposta / NACK)."""
        self.ser.reset_input_buffer()
        self._send(build_frame(cmd, ident))
        r = self._read_frame(0.4)
        if r is None:
            return None
        if len(r) == 4 and r[1] == 0x0A:  # NACK
            return None
        if not checksum_ok(r) or r[1] != (cmd ^ 0xFF):
            self._log(f"frame inesperado {r.hex(' ')}")
            return None
        return r[2:-2]

    def read(self, name):
        cmd, ident, conv = SENSORS[name]
        payload = self.query(cmd, ident)
        value = conv(payload) if payload else None
        self.drain_acks()
        return value

    def poll_forever(self, publish, stop):
        """Loop de leitura: publish(dict) a cada sensor lido. Reconecta se a sessão cair."""
        slow_i = 0
        misses = 0
        while not stop.is_set():
            names = FAST + [SLOW[slow_i % len(SLOW)]]
            slow_i += 1
            for name in names:
                if stop.is_set():
                    return
                v = self.read(name)
                if v is None:
                    misses += 1
                else:
                    misses = 0
                    publish({name: v})
            if misses >= 6:
                raise IOError("ECU parou de responder")