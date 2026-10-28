"""Sensores do painel: BMP280/BME280 (I2C), MPU6050 (I2C) e DS18B20 (1-Wire).

Cada sensor tem uma classe real e uma simulada (Mock*) com o mesmo método run(),
para testar o painel sem o hardware.
"""
import glob
import math
import struct
import time

# =====================================================================
#  BMP280 / BME280
# =====================================================================
# Aceita chip id 0x58 (BMP280) e 0x60 (BME280). Muitas placas da China vêm trocadas;
# só o BME280 (0x60) tem umidade.


def t_fine_of(cal, adc_t):
    t1, t2, t3 = cal[:3]
    v1 = (adc_t / 16384.0 - t1 / 1024.0) * t2
    v2 = ((adc_t / 131072.0 - t1 / 8192.0) ** 2) * t3
    return v1 + v2


def compensate(cal, adc_t, adc_p):
    """Fórmulas em ponto flutuante do datasheet Bosch. Devolve (temp °C, pressão Pa)."""
    _, _, _, p1, p2, p3, p4, p5, p6, p7, p8, p9 = cal
    t_fine = t_fine_of(cal, adc_t)
    temp = t_fine / 5120.0

    v1 = t_fine / 2.0 - 64000.0
    v2 = v1 * v1 * p6 / 32768.0
    v2 = v2 + v1 * p5 * 2.0
    v2 = v2 / 4.0 + p4 * 65536.0
    v1 = (p3 * v1 * v1 / 524288.0 + p2 * v1) / 524288.0
    v1 = (1.0 + v1 / 32768.0) * p1
    if v1 == 0:
        return temp, 0.0
    p = 1048576.0 - adc_p
    p = (p - v2 / 4096.0) * 6250.0 / v1
    v1 = p9 * p * p / 2147483648.0
    v2 = p * p8 / 32768.0
    p = p + (v1 + v2 + p7) / 16.0
    return temp, p


def compensate_humidity(calh, adc_h, t_fine):
    """Umidade relativa (%) do BME280, fórmula em ponto flutuante do datasheet."""
    h1, h2, h3, h4, h5, h6 = calh
    v = t_fine - 76800.0
    v = (adc_h - (h4 * 64.0 + h5 / 16384.0 * v)) * (
        h2 / 65536.0 * (1.0 + h6 / 67108864.0 * v * (1.0 + h3 / 67108864.0 * v)))
    v = v * (1.0 - h1 * v / 524288.0)
    return max(0.0, min(100.0, v))


def altitude_m(pressure_hpa, qnh_hpa=1013.25):
    return 44330.0 * (1.0 - (pressure_hpa / qnh_hpa) ** (1.0 / 5.255))


def dew_point_c(temp_c, rh_pct):
    """Ponto de orvalho (Magnus). 25 °C e 60 % -> 16,7 °C."""
    if rh_pct <= 0:
        return None
    a, b = 17.62, 243.12
    g = math.log(rh_pct / 100.0) + a * temp_c / (b + temp_c)
    return b * g / (a - g)


class Bmp280:
    def __init__(self, bus=1, addr=0x76):
        self.bus_n, self.addr = bus, addr
        self.bus = None
        self.cal = None
        self.calh = None
        self.chip = None

    def init(self):
        from smbus2 import SMBus
        self.bus = SMBus(self.bus_n)
        self.chip = self.bus.read_byte_data(self.addr, 0xD0)
        if self.chip not in (0x58, 0x60):
            raise IOError(f"chip id inesperado: 0x{self.chip:02X} (esperado 0x58/0x60)")
        raw = bytes(self.bus.read_i2c_block_data(self.addr, 0x88, 24))
        self.cal = struct.unpack("<HhhHhhhhhhhh", raw)
        if self.chip == 0x60:  # BME280: calibração da umidade
            h1 = self.bus.read_byte_data(self.addr, 0xA1)
            e = bytes(self.bus.read_i2c_block_data(self.addr, 0xE1, 7))
            h2 = struct.unpack("<h", e[0:2])[0]
            h3 = e[2]
            h4 = (struct.unpack("b", e[3:4])[0] << 4) | (e[4] & 0x0F)
            h5 = (struct.unpack("b", e[5:6])[0] << 4) | (e[4] >> 4)
            h6 = struct.unpack("b", e[6:7])[0]
            self.calh = (h1, h2, h3, h4, h5, h6)
            self.bus.write_byte_data(self.addr, 0xF2, 0x01)  # umidade x1 (antes do 0xF4)
        self.bus.write_byte_data(self.addr, 0xF5, 0x48)  # standby 125 ms, filtro x4
        self.bus.write_byte_data(self.addr, 0xF4, 0x4F)  # temp x2, pressão x4, modo normal
        time.sleep(0.1)
        return self.chip

    def read(self):
        """(°C, hPa, % ou None)"""
        n = 8 if self.calh else 6
        d = self.bus.read_i2c_block_data(self.addr, 0xF7, n)
        adc_p = (d[0] << 12) | (d[1] << 4) | (d[2] >> 4)
        adc_t = (d[3] << 12) | (d[4] << 4) | (d[5] >> 4)
        t, p = compensate(self.cal, adc_t, adc_p)
        rh = None
        if self.calh:
            rh = compensate_humidity(self.calh, (d[6] << 8) | d[7], t_fine_of(self.cal, adc_t))
        return t, p / 100.0, rh

    def run(self, publish, stop, qnh=1013.25):
        chip = self.init()
        print(f"[bmp] chip 0x{chip:02X} ({'BME280' if chip == 0x60 else 'BMP280, sem umidade'})",
              flush=True)
        while not stop.is_set():
            t, p, rh = self.read()
            out = {"temp_cabine": round(t, 1), "pressao_hpa": round(p, 1),
                   "alt_baro_m": round(altitude_m(p, qnh), 0)}
            if rh is not None:
                out["umidade_pct"] = round(rh, 0)
            publish(out)
            time.sleep(1.0)


class MockBmp:
    def run(self, publish, stop, qnh=1013.25):
        t0 = time.time()
        while not stop.is_set():
            t = time.time() - t0
            p = 912.0 + 0.4 * math.sin(t / 30.0)
            publish({"temp_cabine": round(27 + 3 * (1 - math.exp(-t / 120.0)), 1),
                     "pressao_hpa": round(p, 1), "alt_baro_m": round(altitude_m(p, qnh), 0),
                     "umidade_pct": round(55 + 10 * math.sin(t / 60.0), 0)})
            time.sleep(1.0)


# =====================================================================
#  MPU6050 (acelerômetro/giroscópio)
# =====================================================================
# Eixos do carro: X = frente, Y = esquerda, Z = para cima.
# --imu-map diz como os eixos da placa viram os do carro (ex.: "-y,x,z").

def parse_axes(spec):
    """'x,-y,z' -> [(índice, sinal), ...] para (frente, esquerda, cima)."""
    out = []
    for tok in spec.replace(" ", "").lower().split(","):
        sign = -1.0 if tok.startswith("-") else 1.0
        out.append(("xyz".index(tok.lstrip("+-")), sign))
    if len(out) != 3 or len({i for i, _ in out}) != 3:
        raise ValueError("--imu-map precisa ter x, y e z uma vez cada, ex.: x,y,z ou -y,x,z")
    return out


def map_axes(raw_g, axes):
    return tuple(raw_g[i] * s for i, s in axes)


class Mpu6050:
    LSB_PER_G = 8192.0  # faixa ±4 g

    def __init__(self, bus=1, addr=0x68, axes="x,y,z"):
        self.bus_n, self.addr = bus, addr
        self.axes = parse_axes(axes)
        self.bus = None
        self.offset = (0.0, 0.0, 0.0)

    def init(self):
        from smbus2 import SMBus
        self.bus = SMBus(self.bus_n)
        who = self.bus.read_byte_data(self.addr, 0x75)
        if who not in (0x68, 0x70, 0x71, 0x72, 0x73):
            raise IOError(f"WHO_AM_I inesperado: 0x{who:02X}")
        self.bus.write_byte_data(self.addr, 0x6B, 0x00)  # sai do modo sleep
        self.bus.write_byte_data(self.addr, 0x1A, 0x03)  # filtro digital ~44 Hz
        self.bus.write_byte_data(self.addr, 0x1C, 0x08)  # ±4 g
        time.sleep(0.1)
        return who

    def read_g(self):
        d = bytes(self.bus.read_i2c_block_data(self.addr, 0x3B, 6))
        raw = [v / self.LSB_PER_G for v in struct.unpack(">hhh", d)]
        return map_axes(raw, self.axes)

    def _mean(self, seconds, hz=50):
        n = max(1, int(seconds * hz))
        acc = [0.0, 0.0, 0.0]
        for _ in range(n):
            g = self.read_g()
            for i in range(3):
                acc[i] += g[i]
            time.sleep(1.0 / hz)
        return tuple(a / n for a in acc)

    def run(self, publish, stop):
        who = self.init()
        print(f"[imu] MPU 0x{who:02X} ok - calibrando 1 s (carro PARADO)", flush=True)
        m = self._mean(1.0)
        self.offset = (m[0], m[1], m[2] - 1.0)  # zera a posição de partida (1 g para cima)
        incl = 0.0
        while not stop.is_set():
            g = self._mean(0.5)  # média de 0,5 s tira a vibração do motor
            ax, ay, az = (g[i] - self.offset[i] for i in range(3))
            if abs(ax) < 0.05 and abs(ay) < 0.1:  # só estima rampa em velocidade constante
                incl = math.degrees(math.atan2(ax, az))
            publish({"acc_long_g": round(ax, 2), "acc_lat_g": round(ay, 2),
                     "inclinacao_deg": round(incl, 1)})


class MockImu:
    def run(self, publish, stop):
        t0 = time.time()
        while not stop.is_set():
            t = time.time() - t0
            publish({"acc_long_g": round(0.15 * math.sin(t / 5.0), 2),
                     "acc_lat_g": round(0.2 * math.sin(t / 9.0), 2),
                     "inclinacao_deg": round(3 * math.sin(t / 30.0), 1)})
            time.sleep(0.5)


# =====================================================================
#  DS18B20 (1-Wire)
# =====================================================================
# Ligação: vermelho 3,3 V, preto GND, amarelo (dados) no GPIO4 + resistor 4,7 kΩ entre
# dados e 3,3 V. No Pi: adicionar `dtoverlay=w1-gpio` em /boot/firmware/config.txt.

def parse_w1(text):
    """Texto de /sys/bus/w1/devices/28-*/w1_slave -> °C (ou None se leitura inválida)."""
    lines = text.strip().splitlines()
    if len(lines) < 2 or not lines[0].strip().endswith("YES") or "t=" not in lines[1]:
        return None
    v = int(lines[1].split("t=")[-1]) / 1000.0
    if v == 85.0 or not -55.0 <= v <= 125.0:  # 85 °C = valor de power-on, descarte
        return None
    return v


def parse_ds_names(spec):
    """'28-abc=temp_oleo,temp_externa' -> (por_id, posicionais)"""
    by_id, order = {}, []
    for tok in [t.strip() for t in spec.split(",") if t.strip()]:
        if "=" in tok:
            k, v = tok.split("=", 1)
            by_id[k.strip()] = v.strip()
        else:
            order.append(tok)
    return by_id, order


class Ds18b20:
    def __init__(self, names="temp_externa", base="/sys/bus/w1/devices"):
        self.base = base
        self.by_id, self.order = parse_ds_names(names)

    def devices(self):
        return sorted(glob.glob(f"{self.base}/28-*"))

    def key_for(self, dev_id, pos):
        if dev_id in self.by_id:
            return self.by_id[dev_id]
        return self.order[pos] if pos < len(self.order) else f"temp_ds{pos + 1}"

    def run(self, publish, stop):
        devs = self.devices()
        if not devs:
            raise IOError("nenhum DS18B20 em /sys/bus/w1/devices (w1-gpio habilitado? resistor 4,7k?)")
        for i, d in enumerate(devs):
            dev_id = d.rsplit("/", 1)[-1]
            print(f"[ds] {dev_id} -> {self.key_for(dev_id, i)}", flush=True)
        while not stop.is_set():
            for i, d in enumerate(devs):
                dev_id = d.rsplit("/", 1)[-1]
                with open(f"{d}/w1_slave") as f:  # a leitura bloqueia ~750 ms
                    v = parse_w1(f.read())
                if v is not None:
                    publish({self.key_for(dev_id, i): round(v, 1)})
            time.sleep(1.0)


class MockDs:
    def __init__(self, names="temp_externa,temp_oleo"):
        _, self.order = parse_ds_names(names)

    def run(self, publish, stop):
        t0 = time.time()
        while not stop.is_set():
            t = time.time() - t0
            for i, k in enumerate(self.order or ["temp_externa"]):
                base = 24 + 2 * math.sin(t / 60.0) if "extern" in k else 60 + 30 * (1 - math.exp(-t / 300.0))
                publish({k: round(base, 1)})
            time.sleep(1.0)


# =====================================================================
#  Pressão do óleo: sensor 0,5-4,5 V (ratiométrico, 5 V) + ADS1115
# =====================================================================
# Circuito (ADS1115 alimentado em 3,3 V, nunca em 5 V, senão o I2C queima o Pi):
#   sinal do sensor --[10k]--+--[20k]-- GND      -> ADS1115 A0
#   +5 V do sensor  --[10k]--+--[20k]-- GND      -> ADS1115 A1   (mesmo divisor!)
# Como os dois divisores são iguais, ratio = A0/A1 não depende do valor deles nem de a
# fonte de 5 V oscilar (sensor ratiométrico: 10 % a 90 % da alimentação = 0 a fundo de escala).

def oil_bar(v_sig, v_sup, range_bar=10.0):
    """Pressão em bar a partir de A0 (sinal) e A1 (alimentação), ambos já divididos."""
    if v_sup is None or v_sup < 0.3:
        return None                      # sem alimentação lida
    ratio = v_sig / v_sup
    if ratio < 0.08 or ratio > 0.95:
        return None                      # fio solto ou em curto: não inventar valor
    return max(0.0, (ratio - 0.1) / 0.8 * range_bar)


class Ads1115:
    def __init__(self, bus=1, addr=0x48):
        self.bus_n, self.addr, self.bus = bus, addr, None

    def init(self):
        from smbus2 import SMBus
        self.bus = SMBus(self.bus_n)
        self.read_v(0)  # falha aqui se o chip não responde

    def read_v(self, ch):
        """Tensão (V) no canal ch (0-3), faixa ±4,096 V, 128 amostras/s."""
        cfg = 0x8000 | ((0b100 + ch) << 12) | (0b001 << 9) | (1 << 8) | (0b100 << 5) | 0b11
        self.bus.write_i2c_block_data(self.addr, 0x01, [cfg >> 8, cfg & 0xFF])
        time.sleep(0.012)
        d = bytes(self.bus.read_i2c_block_data(self.addr, 0x00, 2))
        return struct.unpack(">h", d)[0] * 4.096 / 32768.0


class OilPressure:
    def __init__(self, bus=1, addr=0x48, range_bar=10.0):
        self.bus, self.addr, self.range_bar = bus, addr, range_bar

    def run(self, publish, stop):
        ads = Ads1115(self.bus, self.addr)
        ads.init()
        print("[oleo] ADS1115 ok", flush=True)
        ema, faulty = None, False
        while not stop.is_set():
            p = oil_bar(ads.read_v(0), ads.read_v(1), self.range_bar)
            if p is None:
                if not faulty:
                    print("[oleo] leitura inválida (fio solto/curto ou sem 5 V)", flush=True)
                faulty = True
            else:
                faulty = False
                ema = p if ema is None else ema * 0.7 + p * 0.3   # filtra o ruído
                publish({"oleo_bar": round(ema, 2)})
            time.sleep(0.4)


class MockOil:
    def run(self, publish, stop):
        t0 = time.time()
        while not stop.is_set():
            t = time.time() - t0
            publish({"oleo_bar": round(2.2 + 1.4 * math.sin(t / 8.0), 2)})
            time.sleep(0.5)
