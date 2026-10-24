"""Testes sem hardware: python3 tests.py"""
import threading
import time

import bmp280
import ecu
import gps
from ecu import Ecu, SENSORS, build_frame, checksum_ok

# ---- ECU: frames reais das capturas e dos seus logs ----
assert build_frame(0x31, 0x08).hex() == "04310800" "3d"
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
assert Ecu(gap_s=0.01).__class__ and e.query(0x31, 0x2E) is None      # NACK
print("ECU ok")

# ---- BMP280: exemplo numérico do datasheet Bosch (25,08 °C / 100653,27 Pa) ----
cal = (27504, 26435, -1000, 36477, -10685, 3024, 2855, 140, -7, 15500, -14600, 6000)
t, p = bmp280.compensate(cal, 519888, 415148)
assert abs(t - 25.08) < 0.01 and abs(p - 100653.27) < 0.5, (t, p)
assert abs(bmp280.altitude_m(1013.25)) < 0.01 and 880 < bmp280.altitude_m(900) < 1000
print("BMP280 ok", round(t, 2), "°C", round(p / 100, 2), "hPa")


# ---- GPS: sentenças NMEA com checksum calculado ----
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
assert abs(d["vel_kmh"] - 21.6 * 1.852) < 0.01 and abs(d["lat"] + (22 + 27.5 / 60)) < 1e-9 and abs(d["lon"] + (46 + 8.4 / 60)) < 1e-9
g = gps.parse(gga)
assert g["sats"] == 9 and g["hdop"] == 1.1 and g["alt_gps_m"] == 1050.4
assert gps.parse(nofix) == {"gps_fix": False}
print("GPS ok")