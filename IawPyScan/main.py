"""Painel em tempo real: ECU + GPS + barômetro -> dashboard web no celular.

Abra no celular:  http://<ip-do-pi>:8000
Teste sem hardware: python3 main.py --simulate
Só o GPS/BMP simulados, ECU real: python3 main.py --gps mock --bmp mock
"""
import argparse
import csv
import json
import math
import os
import random
import threading
import time

from flask import Flask, Response, jsonify, request

from lib.fuel import FuelLedger

HERE = os.path.dirname(os.path.abspath(__file__))
TRIP_FILE = os.path.join(HERE, "trip.json")

# ---------------- estado compartilhado ----------------
_state = {}
_lock = threading.RLock()
CFG = {}
trip = {"dist_m": 0.0, "fuel_l": 0.0, "secs": 0.0}
FUEL = None  # livro-caixa do combustível, criado em main()


def update(values):
    now = time.time()
    with _lock:
        for k, v in values.items():
            _state[k] = {"v": v, "t": now}
        _derive(now)


def snapshot():
    with _lock:
        return {k: dict(x) for k, x in _state.items()}


def _fresh(key, max_age, now=None):
    now = now or time.time()
    x = _state.get(key)
    return x["v"] if x and now - x["t"] < max_age else None


def _derive(now):
    """Consumo instantâneo. Chamar com _lock adquirido."""
    t_cab, rh = _fresh("temp_cabine", 10, now), _fresh("umidade_pct", 10, now)
    if t_cab is not None and rh:
        from lib.sensors import dew_point_c
        dew = dew_point_c(t_cab, rh)
        if dew is not None:
            _state["ponto_orvalho"] = {"v": round(dew, 1), "t": now}
            t_ext = _fresh("temp_externa", 15, now)
            if t_ext is not None:  # vidro frio ~ temperatura de fora (pior caso)
                _state["margem_embacar"] = {"v": round(t_ext - dew, 1), "t": now}
    inj, rpm = _fresh("inj_ms", 8, now), _fresh("rpm", 8, now)
    if inj is None or rpm is None:
        return
    eff = max(inj - CFG["dead_ms"], 0) / 1000.0                    # s por pulso
    cc_s = eff * (CFG["flow_cc_min"] / 60.0) * CFG["cyl"] * rpm / 120.0
    lph = cc_s * 3.6 * (FUEL.k if FUEL else 1.0)                                     # L/h
    _state["consumo_lh"] = {"v": round(lph, 2), "t": now}
    speed = _fresh("vel_kmh", 3, now)
    if speed is not None and speed > 3 and lph > 0.05:
        _state["consumo_kml"] = {"v": round(speed / lph, 1), "t": now}


# ---------------- viagem (distância, litros, km/L) ----------------
def load_trip():
    try:
        with open(TRIP_FILE) as f:
            trip.update(json.load(f))
    except (OSError, ValueError):
        pass


def save_trip():
    try:
        with open(TRIP_FILE, "w") as f:
            json.dump(trip, f)
    except OSError:
        pass


def fuel_keys():
    """Estado do combustível com os nomes usados no painel."""
    st = FUEL.status()
    names = {"remaining_l": "comb_l", "autonomia_km": "autonomia_km", "since_km": "abast_km",
             "since_kml": "abast_kml", "k": "fator_k"}
    out = {names[k]: v for k, v in st.items() if k in names}
    if "reserva" in st:
        out["comb_reserva"] = 1 if st["reserva"] else 0
    return out


def trip_worker(stop):
    last = last_save = time.time()
    while not stop.is_set():
        time.sleep(0.5)
        now = time.time()
        dt, last = min(now - last, 2.0), now
        with _lock:
            spd = _fresh("vel_kmh", 3, now)
            lph = _fresh("consumo_lh", 8, now)
            rpm = _fresh("rpm", 8, now)
            d_km = d_l = 0.0
            if spd is not None and spd > 1.5:
                d_km = spd / 3.6 * dt / 1000.0          # integra a velocidade do GPS
                trip["dist_m"] += d_km * 1000.0
            if lph is not None and rpm and rpm > 300:   # motor ligado
                d_l = lph * dt / 3600.0
                trip["fuel_l"] += d_l
                trip["secs"] += dt
            FUEL.add(d_km, d_l)
            km, fuel = trip["dist_m"] / 1000.0, trip["fuel_l"]
            out = {"trip_km": round(km, 2), "trip_fuel_l": round(fuel, 2),
                   "trip_min": round(trip["secs"] / 60.0, 1)}
            if km > 0.2 and fuel > 0.02:
                out["trip_kml"] = round(km / fuel, 1)
        out.update(fuel_keys())
        update(out)
        if now - last_save > 10:
            last_save = now
            save_trip()
            FUEL.save()


# ---------------- fontes ----------------
def _retry(name, fn, stop):
    while not stop.is_set():
        try:
            fn()
        except Exception as e:  # noqa: BLE001
            print(f"[{name}] erro: {e} - tentando de novo em 3s", flush=True)
            time.sleep(3)


def ecu_worker(port, stop):
    from lib.ecu import Ecu

    def once():
        ecu = Ecu(port, gap_s=CFG["gap"], debug=CFG["debug"])
        try:
            print(f"[ecu] conectando em {port}...", flush=True)
            ecu.connect()
            print("[ecu] sessão ativa", flush=True)
            update({"ecu_ok": True})
            ecu.poll_forever(update, stop)
        except Exception:
            update({"ecu_ok": False})
            raise
        finally:
            ecu.close()
    _retry("ecu", once, stop)


def ecu_simulator(stop):
    t0 = time.time()
    while not stop.is_set():
        t = time.time() - t0
        rpm = 850 + 40 * math.sin(t / 3) + (2500 * max(0, math.sin(t / 12)) ** 2)
        update({
            "ecu_ok": True, "rpm": round(rpm / 25) * 25,
            "bateria_v": round(12.6 + 0.2 * math.sin(t), 2),
            "temp_agua": 88, "temp_ar": 41, "avanco_deg": 7.5,
            "map_mbar": int(300 + rpm / 20), "atm_mbar": 854, "carga_mgi": 52,
            "inj_ms": round(3.2 + rpm / 2000, 3),
            "lambda_v": round(0.45 + 0.4 * math.sin(t * 2), 3),
        })
        time.sleep(0.4)


def gps_worker(mode, baud, stop):
    if mode == "mock":
        from lib.gps import MockGps
        MockGps().run(update, stop)
    else:
        from lib.gps import Gps
        _retry("gps", lambda: Gps(mode, baud).run(update, stop), stop)


def bmp_worker(mode, bus, addr, qnh, stop):
    if mode == "mock":
        from lib.sensors import MockBmp
        MockBmp().run(update, stop, qnh)
    else:
        from lib.sensors import Bmp280
        _retry("bmp", lambda: Bmp280(bus, addr).run(update, stop, qnh), stop)


def imu_worker(mode, bus, addr, axes, stop):
    if mode == "mock":
        from lib.sensors import MockImu
        MockImu().run(update, stop)
    else:
        from lib.sensors import Mpu6050
        _retry("imu", lambda: Mpu6050(bus, addr, axes).run(update, stop), stop)


def ds_worker(mode, names, stop):
    if mode == "mock":
        from lib.sensors import MockDs
        MockDs(names).run(update, stop)
    else:
        from lib.sensors import Ds18b20
        _retry("ds", lambda: Ds18b20(names).run(update, stop), stop)


def oil_worker(mode, bus, addr, range_bar, stop):
    if mode == "mock":
        from lib.sensors import MockOil
        MockOil().run(update, stop)
    else:
        from lib.sensors import OilPressure
        _retry("oleo", lambda: OilPressure(bus, addr, range_bar).run(update, stop), stop)


LOG_COLS = ["rpm", "vel_kmh", "temp_agua", "bateria_v", "map_mbar", "lambda_v", "inj_ms",
            "avanco_deg", "carga_mgi", "consumo_lh", "trip_km", "trip_fuel_l",
            "temp_cabine", "umidade_pct", "pressao_hpa", "alt_baro_m", "alt_gps_m", "lat", "lon", "sats",
            "temp_externa", "temp_oleo", "oleo_bar", "acc_long_g", "acc_lat_g", "inclinacao_deg",
            "comb_l", "autonomia_km"]


def log_worker(path, stop):
    """CSV a cada 1 s: serve para calibrar o consumo e revisar a viagem depois."""
    new = not os.path.exists(path)
    with open(path, "a", newline="") as fh:
        w = csv.writer(fh)
        if new:
            w.writerow(["hora"] + LOG_COLS)
        while not stop.is_set():
            time.sleep(1.0)
            s = snapshot()
            now = time.time()
            row = [time.strftime("%Y-%m-%d %H:%M:%S")]
            for c in LOG_COLS:
                x = s.get(c)
                row.append(x["v"] if x and now - x["t"] < 10 else "")
            w.writerow(row)
            fh.flush()


# ---------------- web ----------------
app = Flask(__name__)

PAGE = """<!doctype html><html lang="pt-br"><head><meta charset="utf-8">
<meta name="viewport" content="width=device-width,initial-scale=1">
<title>Strada</title><style>
body{margin:0;background:#0b0f14;color:#e8eef5;font-family:system-ui,sans-serif}
header{display:flex;justify-content:space-between;align-items:center;padding:10px 14px;background:#121923}
#st{font-weight:600}.ok{color:#4ade80}.bad{color:#f87171}
button{background:#243244;color:#e8eef5;border:0;border-radius:8px;padding:8px 12px}
.bar{display:flex;flex-wrap:wrap;gap:8px;padding:8px 14px;background:#121923}
.grid{display:grid;grid-template-columns:repeat(auto-fit,minmax(150px,1fr));gap:10px;padding:12px}
.tile{background:#121923;border-radius:12px;padding:12px}
.tile .n{font-size:.8rem;color:#8fa3b8}.tile .v{font-size:2rem;font-weight:700}
.tile .u{font-size:.9rem;color:#8fa3b8;margin-left:4px}.stale .v{color:#556}
.warn .v{color:#fbbf24}.hot .v{color:#f87171}h2{margin:6px 14px 0;font-size:.9rem;color:#8fa3b8}
</style></head><body>
<header><div>Strada</div><div id="st" class="bad">sem dados</div></header>
<div class="bar"><button onclick="fill()">Abasteci</button>
<button onclick="setFuel()">Ajustar nível</button>
<button onclick="if(confirm('Zerar a viagem?'))fetch('/api/reset_trip',{method:'POST'})">Zerar viagem</button></div>
<div id="root"></div><script>
const G=[["Motor",[["rpm","Rotação","rpm",0],["temp_agua","Água","°C",0],["bateria_v","Bateria","V",2],
["oleo_bar","Pressão do óleo","bar",1],["map_mbar","Pressão admissão","mbar",0],["lambda_v","Sonda lambda","V",2],["inj_ms","Injeção","ms",2],
["avanco_deg","Avanço","°",1],["carga_mgi","Carga","mg/i",0],["temp_ar","Ar admissão","°C",0]]],
["Combustível",[["comb_l","No tanque","L",1],["autonomia_km","Autonomia","km",0],["abast_km","Desde o abastecimento","km",0],
["abast_kml","Média desde abastec.","km/L",1],["fator_k","Calibração (k)","",3]]],
["Movimento e consumo",[["vel_kmh","Velocidade","km/h",0],["consumo_lh","Consumo","L/h",2],["consumo_kml","Consumo agora","km/L",1],
["trip_km","Viagem","km",2],["trip_fuel_l","Combustível","L",2],["trip_kml","Média da viagem","km/L",1],["trip_min","Tempo ligado","min",0]]],
["Ambiente",[["temp_cabine","Cabine","°C",1],["umidade_pct","Umidade cabine","%",0],["ponto_orvalho","Ponto de orvalho","°C",1],
["margem_embacar","Margem anti-embaçar","°C",1],["temp_externa","Temperatura externa","°C",1],["temp_oleo","Óleo (cárter)","°C",0],
["pressao_hpa","Pressão (BME/BMP)","hPa",1],["alt_baro_m","Altitude baro.","m",0],["alt_gps_m","Altitude GPS","m",0],["sats","Satélites","",0]]],
["Dinâmica",[["acc_long_g","Aceleração","g",2],["acc_lat_g","Lateral","g",2],["inclinacao_deg","Inclinação","°",1]]]];
const root=document.getElementById("root"),T=[];
G.forEach(([title,items])=>{root.insertAdjacentHTML("beforeend",`<h2>${title}</h2><div class="grid">`+
items.map(([k,n,u])=>`<div class="tile stale" id="t_${k}"><div class="n">${n}</div><div><span class="v">—</span><span class="u">${u}</span></div></div>`).join("")+`</div>`);
items.forEach(i=>T.push(i));});
const es=new EventSource("/stream"),st=document.getElementById("st");
es.onmessage=e=>{const s=JSON.parse(e.data),now=Date.now()/1000,ok=s.ecu_ok&&s.ecu_ok.v;
st.textContent=ok?"ECU conectada":"ECU offline";st.className=ok?"ok":"bad";
T.forEach(([k,n,u,d])=>{const el=document.getElementById("t_"+k),x=s[k];if(!x)return;
el.classList.toggle("stale",now-x.t>((k.startsWith("trip")||k.startsWith("comb")||k.startsWith("abast")||k=="autonomia_km"||k=="fator_k")?60:6));
el.querySelector(".v").textContent=Number(x.v).toFixed(d);
el.classList.toggle("hot",k=="temp_agua"&&x.v>104);el.classList.toggle("warn",(k=="bateria_v"&&x.v<12)||(k=="margem_embacar"&&x.v<2)||(k=="temp_oleo"&&x.v>115)||(k=="comb_l"&&s.comb_reserva&&s.comb_reserva.v==1)||(k=="oleo_bar"&&x.v<0.5&&s.rpm&&s.rpm.v>600));});};
const post=(u,b)=>fetch(u,{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify(b)}).then(r=>r.json()).then(j=>alert(j.msg||(j.ok?"ok":"erro")));
function fill(){const l=prompt("Quantos litros colocou?");if(!l)return;
const full=confirm("Encheu até a bomba desarmar?\nOK = tanque cheio (calibra o consumo)\nCancelar = abastecimento parcial");post("/api/fill",{liters:l,full});}
function setFuel(){const l=prompt("Quantos litros tem no tanque agora?");if(!l)return;post("/api/set_fuel",{liters:l});}
es.onerror=()=>{st.textContent="sem conexão";st.className="bad"};
</script></body></html>"""


@app.route("/")
def index():
    return PAGE


@app.route("/api/state")
def api_state():
    return jsonify(snapshot())


@app.route("/api/reset_trip", methods=["POST"])
def reset_trip():
    with _lock:
        trip.update(dist_m=0.0, fuel_l=0.0, secs=0.0)
        for k in ("trip_km", "trip_fuel_l", "trip_kml", "trip_min"):
            _state.pop(k, None)
    save_trip()
    return jsonify(ok=True)


def _num(v):
    try:
        return float(str(v).replace(",", "."))
    except ValueError:
        return None


@app.route("/api/fill", methods=["POST"])
def api_fill():
    data = request.get_json(silent=True) or {}
    liters = _num(data.get("liters"))
    if liters is None:
        return jsonify(ok=False, msg="litros inválidos"), 400
    ok, msg = FUEL.fill(liters, bool(data.get("full")))
    if ok:
        update(fuel_keys())
    return jsonify(ok=ok, msg=msg), (200 if ok else 400)


@app.route("/api/set_fuel", methods=["POST"])
def api_set_fuel():
    data = request.get_json(silent=True) or {}
    liters = _num(data.get("liters"))
    if liters is None:
        return jsonify(ok=False, msg="litros inválidos"), 400
    ok, msg = FUEL.set_remaining(liters)
    if ok:
        update(fuel_keys())
    return jsonify(ok=ok, msg=msg), (200 if ok else 400)


@app.route("/stream")
def stream():
    def gen():
        while True:
            yield f"data: {json.dumps(snapshot())}\n\n"
            time.sleep(0.5)
    return Response(gen(), mimetype="text/event-stream",
                    headers={"Cache-Control": "no-cache", "X-Accel-Buffering": "no"})


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--port", default="/dev/ttyUSB0", help="porta do cabo KKL")
    ap.add_argument("--simulate", action="store_true", help="ECU, GPS e BMP falsos")
    ap.add_argument("--gps", default="off", help="off | mock | /dev/serial0 (porta do NEO-M8N)")
    ap.add_argument("--gps-baud", type=int, default=9600)
    ap.add_argument("--bmp", default="off", help="off | mock | real")
    ap.add_argument("--i2c-bus", type=int, default=1)
    ap.add_argument("--bmp-addr", default="0x76", help="0x76 ou 0x77")
    ap.add_argument("--qnh", type=float, default=1013.25, help="pressão ao nível do mar p/ altitude")
    ap.add_argument("--imu", default="off", help="off | mock | real (MPU6050)")
    ap.add_argument("--imu-addr", default="0x68")
    ap.add_argument("--imu-map", default="x,y,z",
                    help="eixos da placa -> frente,esquerda,cima do carro (ex.: -y,x,z)")
    ap.add_argument("--ds", default="off", help="off | mock | real (DS18B20)")
    ap.add_argument("--ds-names", default="temp_externa",
                    help="nomes na ordem dos sensores ou ID=nome (ex.: 28-abc=temp_oleo,temp_externa)")
    ap.add_argument("--http", type=int, default=8000)
    ap.add_argument("--log", default="", help="grava CSV a cada 1 s (ex.: viagem.csv)")
    ap.add_argument("--new-trip", action="store_true", help="começa com a viagem zerada")
    ap.add_argument("--debug", action="store_true", help="mostra TX/RX da ECU")
    ap.add_argument("--gap", type=float, default=0.07, help="intervalo mínimo após a ECU (s)")
    # consumo: CALIBRAR com abastecimento (tanque cheio a tanque cheio)
    ap.add_argument("--flow", type=float, default=150.0, help="vazão do bico, cc/min (conferir!)")
    ap.add_argument("--dead", type=float, default=0.8, help="tempo morto do bico, ms")
    ap.add_argument("--cyl", type=int, default=4)
    ap.add_argument("--k", type=float, default=None,
                    help="fator de calibração do consumo (normalmente automático, pelos abastecimentos cheios)")
    ap.add_argument("--tank", type=float, default=None, help="capacidade do tanque em litros (padrão 50)")
    ap.add_argument("--reserve", type=float, default=None, help="alerta de reserva em litros (padrão 6)")
    ap.add_argument("--fuel-file", default=os.path.join(HERE, "fuel.json"))
    ap.add_argument("--oil", default="off", help="off | mock | real (sensor de pressão + ADS1115)")
    ap.add_argument("--oil-addr", default="0x48")
    ap.add_argument("--oil-range", type=float, default=10.0, help="fundo de escala do sensor, bar")
    a = ap.parse_args()
    CFG.update(flow_cc_min=a.flow, dead_ms=a.dead, cyl=a.cyl, gap=a.gap, debug=a.debug)
    global FUEL
    FUEL = FuelLedger(a.fuel_file, capacity_l=a.tank, reserve_l=a.reserve, k=a.k)

    if not a.new_trip:
        load_trip()
    stop = threading.Event()

    def start(fn, *args):
        threading.Thread(target=fn, args=args, daemon=True).start()

    if a.simulate:
        start(ecu_simulator, stop)
        a.gps = a.gps if a.gps != "off" else "mock"
        a.bmp = a.bmp if a.bmp != "off" else "mock"
        a.imu = a.imu if a.imu != "off" else "mock"
        a.ds = a.ds if a.ds != "off" else "mock"
        a.oil = a.oil if a.oil != "off" else "mock"
        if a.ds_names == "temp_externa":
            a.ds_names = "temp_externa,temp_oleo"
    else:
        start(ecu_worker, a.port, stop)
    if a.gps != "off":
        start(gps_worker, a.gps, a.gps_baud, stop)
    if a.bmp != "off":
        start(bmp_worker, a.bmp, a.i2c_bus, int(a.bmp_addr, 0), a.qnh, stop)
    if a.imu != "off":
        start(imu_worker, a.imu, a.i2c_bus, int(a.imu_addr, 0), a.imu_map, stop)
    if a.ds != "off":
        start(ds_worker, a.ds, a.ds_names, stop)
    if a.oil != "off":
        start(oil_worker, a.oil, a.i2c_bus, int(a.oil_addr, 0), a.oil_range, stop)
    start(trip_worker, stop)
    if a.log:
        start(log_worker, a.log, stop)

    app.run(host="0.0.0.0", port=a.http, threaded=True)


if __name__ == "__main__":
    main()