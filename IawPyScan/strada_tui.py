#!/usr/bin/env python3
"""Painel de terminal (estilo máquinas antigas). Só biblioteca padrão; não altera o resto do projeto.

Só LÊ o /api/state do servidor Flask (main.py precisa estar rodando).
  python3 strada_tui.py             tela do terminal (SSH do celular, console do HDMI)
  python3 strada_tui.py --once      imprime um instantâneo e sai   (ex.: watch -n1 python3 strada_tui.py --once)
  python3 strada_tui.py --plain     uma linha por segundo, sem curses (log, pipe, tail)
  python3 strada_tui.py --ascii     sem acentos nem "°" (fontes simples do console)
Teclas: q ou Esc sai.
"""
import argparse
import curses
import json
import locale
import threading
import time
import unicodedata
import urllib.request

# (chave, rótulo, unidade, casas, idade máxima em s antes de "escurecer")
# Sensores lentos da ECU são lidos 1 a cada ~20 s: ficam escuros só depois de 45 s.
ROWS = [
    ("rpm", "ROTAÇÃO", "rpm", 0, 6),
    ("vel_kmh", "VELOCIDADE", "km/h", 0, 6),
    ("temp_agua", "ÁGUA", "°C", 0, 45),
    ("bateria_v", "BATERIA", "V", 1, 45),
    ("map_mbar", "PRESSÃO ADM.", "mbar", 0, 8),
    ("lambda_v", "LAMBDA", "V", 2, 8),
    ("inj_ms", "INJEÇÃO", "ms", 2, 8),
    ("avanco_deg", "AVANÇO", "°", 1, 45),
    ("carga_mgi", "CARGA", "mg/i", 0, 45),
    ("temp_ar", "AR ADMISSÃO", "°C", 0, 45),
    ("consumo_lh", "CONSUMO", "L/h", 2, 10),
    ("consumo_kml", "CONSUMO", "km/L", 1, 10),
    ("trip_km", "VIAGEM", "km", 2, 60),
    ("trip_kml", "MÉDIA VIAGEM", "km/L", 1, 60),
    ("comb_l", "TANQUE", "L", 1, 60),
    ("autonomia_km", "AUTONOMIA", "km", 0, 60),
    ("oleo_bar", "ÓLEO", "bar", 1, 8),
    ("temp_cabine", "CABINE", "°C", 1, 10),
]
ALWAYS = {"rpm", "temp_agua", "bateria_v", "map_mbar", "lambda_v", "inj_ms", "avanco_deg",
          "carga_mgi", "temp_ar"}  # sempre aparecem; os outros só depois do primeiro valor
RPM_MAX = 6500.0


def plain(s, ascii_only):
    if not ascii_only:
        return s
    s = s.replace("°", "o")
    return "".join(c for c in unicodedata.normalize("NFD", s) if unicodedata.category(c) != "Mn")


class Feed:
    def __init__(self, url, every=1.0):
        self.url, self.every = url.rstrip("/") + "/api/state", every
        self.data, self.online, self.seen = {}, False, set(ALWAYS)
        threading.Thread(target=self._loop, daemon=True).start()

    def _loop(self):
        while True:
            try:
                with urllib.request.urlopen(self.url, timeout=2.0) as r:
                    self.data = json.load(r)
                self.seen |= set(self.data)
                self.online = True
            except Exception:  # noqa: BLE001
                self.online = False
            time.sleep(self.every)

    def get(self, key):
        """(valor, idade em s) ou (None, None)."""
        x = self.data.get(key)
        if x is None:
            return None, None
        return x["v"], max(0.0, time.time() - x["t"])

    def ecu_alive(self):
        v, age = self.get("ecu_ok")
        r, rage = self.get("rpm")
        return bool((v and age is not None and age < 15) or (r is not None and rage < 15))

    def alerts(self):
        a = []
        if not self.online:
            return ["SEM CONEXAO COM O SERVIDOR (main.py esta rodando?)"]
        if not self.ecu_alive():
            a.append("ECU OFFLINE")
        t, _ = self.get("temp_agua")
        if t is not None and t > 104:
            a.append(f"AGUA {t:.0f} C")
        b, _ = self.get("bateria_v")
        if b is not None and b < 12.0:
            a.append(f"BATERIA {b:.1f} V")
        o, _ = self.get("oleo_bar")
        r, _ = self.get("rpm")
        if o is not None and o < 0.5 and r and r > 600:
            a.append(f"OLEO {o:.1f} bar")
        if (self.get("comb_reserva")[0] or 0) == 1:
            a.append("RESERVA DE COMBUSTIVEL")
        return a


def rows_for(feed, ascii_only):
    out = []
    for key, label, unit, dec, max_age in ROWS:
        if key not in feed.seen:
            continue
        v, age = feed.get(key)
        val = "--" if v is None else f"{v:.{dec}f}"
        age_s = "" if age is None else (f"{age:.0f}s" if age < 100 else ">99s")
        out.append((key, plain(label, ascii_only), val, plain(unit, ascii_only), age_s,
                    v is None or age > max_age))
    return out


# ---------------------------------------------------------------- modos sem curses
def run_once(feed, ascii_only):
    time.sleep(1.2)  # espera a primeira leitura
    print(plain("STRADA  ", ascii_only) + ("ECU conectada" if feed.ecu_alive() else "ECU OFFLINE"))
    for _, label, val, unit, age, stale in rows_for(feed, ascii_only):
        print(f"{label:<14}{val:>9} {unit:<5} {age:>5}{'  (velho)' if stale else ''}")
    for a in feed.alerts():
        print("!!", a)


def run_plain(feed, ascii_only, every):
    time.sleep(1.2)  # espera a primeira leitura (senão sai uma linha vazia)
    while True:
        parts = [f"{k}={v}" for k, _, v, _, _, st in rows_for(feed, ascii_only) if v != "--"]
        print(time.strftime("%H:%M:%S"), " ".join(parts), flush=True)
        time.sleep(every)


# ---------------------------------------------------------------- curses
def run_curses(stdscr, feed, ascii_only):
    curses.curs_set(0)
    stdscr.timeout(500)  # redesenha 2x por segundo: leve para o Zero
    G = Y = R = curses.A_NORMAL
    if curses.has_colors():
        curses.start_color()
        curses.use_default_colors()
        for i, c in enumerate((curses.COLOR_GREEN, curses.COLOR_YELLOW, curses.COLOR_RED), 1):
            curses.init_pair(i, c, -1)
        G, Y, R = curses.color_pair(1), curses.color_pair(2), curses.color_pair(3)

    def put(y, x, s, attr=0):
        h, w = stdscr.getmaxyx()
        if 0 <= y < h and 0 <= x < w - 1:
            try:
                stdscr.addnstr(y, x, s, w - x - 1, attr)
            except curses.error:
                pass

    while True:
        ch = stdscr.getch()
        if ch in (ord("q"), ord("Q"), 27):
            return
        stdscr.erase()
        h, w = stdscr.getmaxyx()
        ok = feed.online and feed.ecu_alive()
        put(0, 1, plain("STRADA", ascii_only), G | curses.A_BOLD)
        put(0, 10, "ECU OK" if ok else "ECU OFFLINE", (G if ok else R) | curses.A_BOLD)
        put(0, max(w - 10, 20), time.strftime("%H:%M:%S"), G | curses.A_DIM)
        put(1, 0, "=" * (w - 1), G | curses.A_DIM)

        # barra de rotação
        rpm, rage = feed.get("rpm")
        label = f" RPM {0 if rpm is None else rpm:>5.0f} "
        bw = max(10, w - len(label) - 4)
        n = 0 if not rpm else int(min(rpm / RPM_MAX, 1.0) * bw)
        attr = (R if (rpm or 0) > 5500 else Y if (rpm or 0) > 4500 else G) | curses.A_BOLD
        put(2, 1, "[" + "#" * n + "." * (bw - n) + "]", attr)
        put(2, bw + 4, label.strip(), attr)

        rows = [r for r in rows_for(feed, ascii_only) if r[0] != "rpm"]
        two = w >= 76
        colw = (w - 3) // 2 if two else w - 2
        per = (len(rows) + 1) // 2 if two else len(rows)
        for i, (_, lab, val, unit, age, stale) in enumerate(rows):
            col, row = (i // per, i % per) if two else (0, i)
            x, y = 1 + col * (colw + 1), 4 + row
            attr = (G | curses.A_DIM) if stale else (G | curses.A_BOLD)
            put(y, x, f"{lab:<13}{val:>8} {unit:<5}{age:>5}", attr)

        ybot = min(h - 3, 4 + per + 1)
        put(ybot, 0, "=" * (w - 1), G | curses.A_DIM)
        al = feed.alerts()
        blink = int(time.time() * 2) % 2 == 0
        if al:
            put(ybot + 1, 1, "!! " + "  |  ".join(al), R | (curses.A_BOLD if blink else 0))
        else:
            put(ybot + 1, 1, "tudo normal", G | curses.A_DIM)
        put(h - 1, 1, "q sair   escuro = valor antigo (sensor lento ou sem leitura)", G | curses.A_DIM)
        stdscr.refresh()


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--url", default="http://127.0.0.1:8000")
    ap.add_argument("--once", action="store_true")
    ap.add_argument("--plain", action="store_true")
    ap.add_argument("--ascii", action="store_true", help="sem acentos e sem °")
    ap.add_argument("--every", type=float, default=1.0, help="intervalo da busca/linha, em s")
    a = ap.parse_args()
    feed = Feed(a.url, a.every)
    try:
        if a.once:
            run_once(feed, a.ascii)
        elif a.plain:
            run_plain(feed, a.ascii, a.every)
        else:
            locale.setlocale(locale.LC_ALL, "")
            curses.wrapper(run_curses, feed, a.ascii)
    except (KeyboardInterrupt, BrokenPipeError):
        pass


if __name__ == "__main__":
    main()
