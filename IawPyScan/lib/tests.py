"""Testes sem hardware. Na pasta IawPyScan:  python3 -m lib.tests"""
import os
import sys
import threading
import time
import types

sys.path.insert(0, os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

from lib import gps, sensors  # noqa: E402
from lib.ecu import Ecu, SENSORS, build_frame, checksum_ok  # noqa: E402

# ---------------- ECU: frames reais das capturas e dos seus logs ----------------
assert build_frame(0x31, 0x08).hex() == "0431080" "03d"
assert build_frame(0x09).hex() == "0309000c"
assert build_frame(0x51, 0x02).hex() == "0451020057"
for h in ("04cecf01a1", "04ce2300f5", "05ce050300db", "05ce035a0130"):
    assert checksum_ok(bytes.fromhex(h)), h

VALUES = {0x08: b"\xcf", 0x00: b"\x23", 0x06: b"\x65", 0x05: b"\x3f", 0x01: b"\x05\x03",
          0x1D: b"\x0f", 0x04: b"\x03\x5a", 0x03: b"\x01\x73", 0x1B: b"\x1a", 0x02: b"\x0f",
          0x07: b"\x01", 0x0C: b"\x8a", 0x0F: b"\x27"}


class FakeSerial:  # K-Line com eco
    def __init__(self):
        self.buf, self.acc, self.timeout, self.acks = bytearray(), [], 0.1, 0
        self.dtr = self.rts = self.break_condition = False
        self.is_open = True

    def write(self, data):
        for b in data:
            self.buf.append(b)
            self.acc.append(b)
            if len(self.acc) == self.acc[0] + 1:
                f, self.acc = bytes(self.acc), []
                assert checksum_ok(f)
                if f == bytes([3, 9, 0, 12]):
                    self.acks += 1
                    self.buf += f
                elif f[2] not in VALUES:
                    self.buf += bytes([3, 0x0A, 0, 0x0D])
                else:
                    pl = VALUES[f[2]]
                    r = [len(pl) + 3, f[1] ^ 0xFF, *pl]
                    s = sum(r)
                    self.buf += bytes(r + [(s >> 8) & 255, s & 255])

    def read(self, n=1):
        t0 = time.time()
        while not self.buf and time.time() - t0 < self.timeout:
            time.sleep(0.001)
        return bytes([self.buf.pop(0)]) if self.buf else b""

    def reset_input_buffer(self):
        self.buf.clear()

    def close(self):
        self.is_open = False


e = Ecu(gap_s=0.01)
e.ser = FakeSerial()
got = {n: e.read(n) for n in SENSORS}
assert round(got["bateria_v"], 2) == 13.0 and got["rpm"] == 875
assert got["temp_agua"] == 61 and got["temp_ar"] == 23 and got["atm_mbar"] == 858
assert got["map_mbar"] == 371 and got["carga_mgi"] == 78.0
assert e.ser.acks >= len(SENSORS)
assert e.query(0x31, 0x2E) is None  # NACK
print("ECU ok")

# ---------------- BMP280: exemplo numérico do datasheet Bosch ----------------
CAL = (27504, 26435, -1000, 36477, -10685, 3024, 2855, 140, -7, 15500, -14600, 6000)
t, p = sensors.compensate(CAL, 519888, 415148)
assert abs(t - 25.08) < 0.01 and abs(p - 100653.27) < 0.5, (t, p)
assert abs(sensors.altitude_m(1013.25)) < 0.01 and 880 < sensors.altitude_m(900) < 1000
print("BMP280 ok", round(t, 2), "°C", round(p / 100, 2), "hPa")

# ---------------- BME280: umidade, ponto de orvalho e leitura I2C simulada ----------------
dp = sensors.dew_point_c(25.0, 60.0)
assert abs(dp - 16.7) < 0.1, dp
CALH = (75, 366, 0, 312, 50, 30)
tf = sensors.t_fine_of(CAL, 519888)
hs = [sensors.compensate_humidity(CALH, a, tf) for a in range(20000, 40000, 2000)]
assert all(0.0 <= h <= 100.0 for h in hs) and hs == sorted(hs), hs  # limitada e crescente


class FakeBus:
    def __init__(self, bus=1):
        import struct
        self.regs = {0xD0: 0x60, 0xA1: 75}
        self.blocks = {
            0x88: struct.pack("<HhhHhhhhhhhh", *CAL),
            0xE1: bytes([0x6E, 0x01, 0, 0x13, 0x28, 0x03, 30]),   # H2=366 H3=0 H4=312 H5=50 H6=30
            0xF7: bytes([0x65, 0x5A, 0xC0, 0x7E, 0xED, 0x00, 0x7D, 0x00]),
            0x3B: bytes([0, 0, 0, 0, 0x20, 0x00]),   # ax=0, ay=0, az=+1,0 g (0x2000 / 8192)
        }
        self.writes = []

    def read_byte_data(self, a, r): return self.regs.get(r, 0x68)
    def write_byte_data(self, a, r, v): self.writes.append((r, v))
    def read_i2c_block_data(self, a, r, n): return list(self.blocks[r][:n])


fake = types.ModuleType("smbus2")
fake.SMBus = FakeBus
sys.modules["smbus2"] = fake

bme = sensors.Bmp280()
assert bme.init() == 0x60 and bme.calh == (75, 366, 0, 312, 50, 30), bme.calh
assert (0xF2, 0x01) in bme.bus.writes and bme.bus.writes.index((0xF2, 0x01)) < bme.bus.writes.index((0xF4, 0x4F))
tt, pp, rh = bme.read()
assert 20 < tt < 40 and 700 < pp < 1100 and 0 <= rh <= 100, (tt, pp, rh)
print("BME280 ok", round(tt, 1), "°C", round(pp, 1), "hPa", round(rh), "%")

# ---------------- MPU6050: eixos e conversão ----------------
assert sensors.map_axes((1, 2, 3), sensors.parse_axes("-y,x,z")) == (-2.0, 1.0, 3.0)
try:
    sensors.parse_axes("x,x,z")
    raise AssertionError("deveria rejeitar eixo repetido")
except ValueError:
    pass
imu = sensors.Mpu6050()
imu.init()
gx, gy, gz = imu.read_g()
assert (gx, gy) == (0.0, 0.0) and abs(gz - 1.0) < 1e-9, (gx, gy, gz)
print("MPU6050 ok")

# ---------------- DS18B20 ----------------
ok = "72 01 4b 46 7f ff 0e 10 57 : crc=57 YES\n72 01 4b 46 7f ff 0e 10 57 t=23125\n"
assert sensors.parse_w1(ok) == 23.125
assert sensors.parse_w1(ok.replace("YES", "NO")) is None
assert sensors.parse_w1(ok.replace("t=23125", "t=85000")) is None
ds = sensors.Ds18b20("28-aaa=temp_oleo,temp_externa")
assert ds.key_for("28-aaa", 0) == "temp_oleo" and ds.key_for("28-bbb", 0) == "temp_externa"
assert ds.key_for("28-ccc", 3) == "temp_ds4"
print("DS18B20 ok")

# ---------------- GPS: sentenças NMEA com checksum calculado ----------------
def nmea(body):
    x = 0
    for ch in body:
        x ^= ord(ch)
    return f"${body}*{x:02X}"


rmc = nmea("GNRMC,123519.00,A,2227.5000,S,04608.4000,W,021.6,084.4,230394,,,A")
gga = nmea("GNGGA,123519.00,2227.5000,S,04608.4000,W,1,09,1.1,1050.4,M,0.0,M,,")
nofix = nmea("GNRMC,123519.00,V,,,,,,,230394,,,N")
assert gps.nmea_ok(rmc) and not gps.nmea_ok(rmc.replace("021.6", "021.7"))
d = gps.parse(rmc)
assert abs(d["vel_kmh"] - 21.6 * 1.852) < 0.01
assert abs(d["lat"] + (22 + 27.5 / 60)) < 1e-9 and abs(d["lon"] + (46 + 8.4 / 60)) < 1e-9
g = gps.parse(gga)
assert g["sats"] == 9 and g["hdop"] == 1.1 and g["alt_gps_m"] == 1050.4
assert gps.parse(nofix) == {"gps_fix": False}
print("GPS ok")

# ---------------- Pressão do óleo (ADS1115 + divisores iguais) ----------------
import struct  # noqa: E402

DIV = 2.0 / 3.0   # 10k + 20k


class FakeAds:
    def __init__(self, bus=1):
        self.volts, self.ch = {}, 0

    def write_i2c_block_data(self, a, reg, data):
        if reg == 0x01:
            self.ch = ((data[0] << 8 | data[1]) >> 12 & 7) - 4

    def read_i2c_block_data(self, a, reg, n):
        return list(struct.pack(">h", int(self.volts[self.ch] * 32768 / 4.096)))


def sensor_volts(bar, vsup, rng=10.0):
    """O que o ADS1115 enxerga (A0, A1) para uma pressão e uma alimentação."""
    vsig = (0.1 + 0.8 * bar / rng) * vsup
    return vsig * DIV, vsup * DIV


for bar, vsup in ((0.0, 5.0), (3.0, 5.0), (3.0, 4.8), (10.0, 5.1)):
    v0, v1 = sensor_volts(bar, vsup)
    assert abs(sensors.oil_bar(v0, v1) - bar) < 1e-9, (bar, vsup)   # alimentação oscilando não muda o resultado
assert sensors.oil_bar(0.0, 3.3) is None       # fio de sinal solto/curto
assert sensors.oil_bar(1.0, 0.0) is None       # sem 5 V
assert sensors.oil_bar(3.3, 3.3) is None       # sinal colado na alimentação

fake.SMBus = FakeAds
ads = sensors.Ads1115()
ads.bus = FakeAds()
ads.bus.volts = {0: 1.1333333, 1: 3.3333333}
assert abs(ads.read_v(0) - 1.1333) < 0.001 and abs(ads.read_v(1) - 3.3333) < 0.001
assert abs(sensors.oil_bar(ads.read_v(0), ads.read_v(1)) - 3.0) < 0.01
print("Pressão do óleo ok")

# ---------------- Livro-caixa do combustível ----------------
import tempfile  # noqa: E402
from lib.fuel import FuelLedger  # noqa: E402

path = os.path.join(tempfile.mkdtemp(), "fuel.json")
fl = FuelLedger(path, capacity_l=50)
assert "remaining_l" not in fl.status() and not fl.fill(20, False)[0]
assert fl.fill(40, True)[0] and fl.status()["remaining_l"] == 50.0
fl.add(300, 30.0)
st = fl.status()
assert abs(st["remaining_l"] - 20) < 1e-9 and st["since_kml"] == 10.0 and st["autonomia_km"] == 200.0
assert fl.fill(33.0, True)[0] and abs(fl.k - 1.07) < 1e-9        # real 33 L contra 30 L estimados
assert not fl.fill(500, True)[0]                                   # erro de digitação
fl.add(100, 9.0)
assert fl.fill(10, False)[0] and fl.d["baseline_full"] is False   # parcial não calibra
assert fl.set_remaining(5)[0] and fl.status()["reserva"] is True
fl.save()
assert abs(FuelLedger(path).k - fl.k) < 1e-9 and FuelLedger(path, k=1.5).k == 1.5
print("Combustível ok")
