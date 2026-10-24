"""Barômetro BMP280 por I2C (pressão + temperatura da cabine). Também tem simulado.

Aceita chip id 0x58 (BMP280) e 0x60 (BME280): muitas placas 'BMP280' da China vêm
com o BME280, e para pressão/temperatura a conta é a mesma.
"""
import math
import struct
import time


def compensate(cal, adc_t, adc_p):
    """Fórmulas em ponto flutuante do datasheet Bosch. Devolve (temp °C, pressão Pa)."""
    t1, t2, t3, p1, p2, p3, p4, p5, p6, p7, p8, p9 = cal
    v1 = (adc_t / 16384.0 - t1 / 1024.0) * t2
    v2 = ((adc_t / 131072.0 - t1 / 8192.0) ** 2) * t3
    t_fine = v1 + v2
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


def altitude_m(pressure_hpa, qnh_hpa=1013.25):
    return 44330.0 * (1.0 - (pressure_hpa / qnh_hpa) ** (1.0 / 5.255))


class Bmp280:
    def __init__(self, bus=1, addr=0x76):
        self.bus_n, self.addr = bus, addr
        self.bus = None
        self.cal = None

    def init(self):
        from smbus2 import SMBus
        self.bus = SMBus(self.bus_n)
        chip = self.bus.read_byte_data(self.addr, 0xD0)
        if chip not in (0x58, 0x60):
            raise IOError(f"chip id inesperado: 0x{chip:02X} (esperado 0x58/0x60)")
        raw = bytes(self.bus.read_i2c_block_data(self.addr, 0x88, 24))
        self.cal = struct.unpack("<HhhHhhhhhhhh", raw)
        self.bus.write_byte_data(self.addr, 0xF5, 0x48)  # standby 125 ms, filtro x4
        self.bus.write_byte_data(self.addr, 0xF4, 0x4F)  # temp x2, pressão x4, modo normal
        time.sleep(0.1)
        return chip

    def read(self):
        d = self.bus.read_i2c_block_data(self.addr, 0xF7, 6)
        adc_p = (d[0] << 12) | (d[1] << 4) | (d[2] >> 4)
        adc_t = (d[3] << 12) | (d[4] << 4) | (d[5] >> 4)
        t, p = compensate(self.cal, adc_t, adc_p)
        return t, p / 100.0  # °C, hPa

    def run(self, publish, stop, qnh=1013.25):
        chip = self.init()
        print(f"[bmp] chip 0x{chip:02X} ok", flush=True)
        while not stop.is_set():
            t, p = self.read()
            publish({"temp_cabine": round(t, 1), "pressao_hpa": round(p, 1),
                     "alt_baro_m": round(altitude_m(p, qnh), 0)})
            time.sleep(1.0)


class MockBmp:
    def run(self, publish, stop, qnh=1013.25):
        t0 = time.time()
        while not stop.is_set():
            t = time.time() - t0
            p = 912.0 + 0.4 * math.sin(t / 30.0)
            publish({"temp_cabine": round(27 + 3 * (1 - math.exp(-t / 120.0)), 1),
                     "pressao_hpa": round(p, 1), "alt_baro_m": round(altitude_m(p, qnh), 0)})
            time.sleep(1.0)