"""GPS NEO-M8N por UART (NMEA, 9600 baud de fábrica). Também tem um GPS simulado."""
import math
import random
import time

KNOT_KMH = 1.852


def nmea_ok(line):
    """Valida o checksum XOR de '$....*HH'."""
    if not line.startswith("$") or "*" not in line:
        return False
    body, _, cs = line[1:].partition("*")
    x = 0
    for ch in body:
        x ^= ord(ch)
    try:
        return x == int(cs[:2], 16)
    except ValueError:
        return False


def _deg(val, hemi):
    if not val:
        return None
    v = float(val)
    d = int(v // 100)
    r = d + (v - d * 100) / 60.0
    return -r if hemi in ("S", "W") else r


def _f(x):
    try:
        return float(x)
    except (TypeError, ValueError):
        return None


def parse(line):
    """Converte uma sentença NMEA válida em dict (ou None se não interessa)."""
    f = line[1:line.index("*")].split(",")
    kind = f[0][-3:]
    if kind == "RMC" and len(f) > 8:
        fix = f[2] == "A"
        out = {"gps_fix": fix}
        if fix:
            speed = _f(f[7])
            out.update(lat=_deg(f[3], f[4]), lon=_deg(f[5], f[6]),
                       vel_kmh=(speed * KNOT_KMH if speed is not None else None),
                       rumo=_f(f[8]))
        return out
    if kind == "GGA" and len(f) > 9:
        out = {"sats": int(f[7] or 0)}
        hdop, alt = _f(f[8]), _f(f[9])
        if hdop is not None:
            out["hdop"] = hdop
        if alt is not None and f[6] not in ("", "0"):
            out["alt_gps_m"] = alt
        return out
    return None


class Gps:
    def __init__(self, port="/dev/serial0", baud=9600):
        self.port, self.baud = port, baud

    def run(self, publish, stop):
        import serial
        with serial.Serial(self.port, self.baud, timeout=1) as s:
            while not stop.is_set():
                line = s.readline().decode("ascii", "ignore").strip()
                if not nmea_ok(line):
                    continue
                d = parse(line)
                if not d:
                    continue
                # parado o GPS oscila ~0,3 km/h: não mostrar isso como movimento
                if d.get("vel_kmh") is not None and d["vel_kmh"] < 1.0:
                    d["vel_kmh"] = 0.0
                publish(d)


class MockGps:
    """Percurso falso: acelera, cruza, para no 'semáforo'."""
    def run(self, publish, stop):
        t0 = time.time()
        lat, lon = -22.0, -46.0
        last = t0
        while not stop.is_set():
            now = time.time()
            t = now - t0
            speed = max(0.0, 45 + 35 * math.sin(t / 25.0))
            dt, last = now - last, now
            lat += (speed / 3.6 * dt) / 111_000.0
            publish({"gps_fix": True, "vel_kmh": round(speed + random.uniform(-0.3, 0.3), 1),
                     "lat": lat, "lon": lon, "rumo": 0.0, "sats": 9, "hdop": 1.1,
                     "alt_gps_m": round(1050 + 5 * math.sin(t / 40.0), 1)})
            time.sleep(1.0)