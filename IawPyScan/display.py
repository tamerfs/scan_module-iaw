"""Painel em tela cheia no HDMI, sem navegador (o Pi Zero W não roda Chromium/Firefox).

Lê o mesmo servidor do painel web (main.py precisa estar rodando).
  python3 display.py                  # tela cheia
  python3 display.py --windowed       # janela, para testar no PC
Teclas: ESC ou Q sai.

No Pi:  sudo apt install -y python3-pygame   (use o python3 do sistema, não o .venv)
"""
import argparse
import json
import threading
import time
import urllib.request

import pygame

BG, PANEL = (11, 15, 20), (18, 25, 35)
TXT, DIM = (232, 238, 245), (110, 125, 140)
OK, WARN, BAD, ACC = (74, 222, 128), (251, 191, 36), (248, 113, 113), (96, 165, 250)


class Feed:
    """Busca /api/state em segundo plano (a tela nunca trava esperando a rede)."""

    def __init__(self, url):
        self.url, self.data, self.online = url.rstrip("/") + "/api/state", {}, False
        threading.Thread(target=self._loop, daemon=True).start()

    def _loop(self):
        while True:
            try:
                with urllib.request.urlopen(self.url, timeout=1.0) as r:
                    self.data = json.load(r)
                self.online = True
            except Exception:  # noqa: BLE001
                self.online = False
            time.sleep(0.3)

    def get(self, key, max_age=6.0):
        x = self.data.get(key)
        if x is None or time.time() - x["t"] > max_age:
            return None
        return x["v"]


def fmt(v, d=0):
    return "—" if v is None else f"{v:.{d}f}"


def build_alerts(f):
    a = []
    if not f.online:
        a.append("SEM CONEXÃO COM O PAINEL")
    elif not f.get("ecu_ok", 60):
        a.append("ECU OFFLINE")
    t = f.get("temp_agua")
    if t is not None and t > 104:
        a.append(f"ÁGUA {t:.0f} °C")
    b = f.get("bateria_v")
    if b is not None and b < 12.0:
        a.append(f"BATERIA {b:.1f} V")
    o, rpm = f.get("oleo_bar"), f.get("rpm")
    if o is not None and o < 0.5 and rpm and rpm > 600:
        a.append(f"PRESSÃO DO ÓLEO {o:.1f} bar")
    if f.get("comb_reserva", 60) == 1:
        a.append("RESERVA DE COMBUSTÍVEL")
    m = f.get("margem_embacar")
    if m is not None and m < 2:
        a.append("RISCO DE EMBAÇAR")
    return a


def draw(screen, fonts, f):
    w, h = screen.get_size()
    screen.fill(BG)
    big, mid, small, tiny = fonts

    def text(s, font, color, x, y, anchor="topleft"):
        img = font.render(s, True, color)
        r = img.get_rect(**{anchor: (x, y)})
        screen.blit(img, r)
        return r

    pad = int(h * 0.025)
    # barra superior
    text("STRADA", small, DIM, pad, pad)
    ok = f.online and f.get("ecu_ok", 60)
    text("ECU conectada" if ok else "ECU offline", small, OK if ok else BAD, w - pad, pad, "topright")

    # coluna esquerda: RPM e velocidade
    lw = int(w * 0.46)
    top = int(h * 0.11)
    rpm = f.get("rpm")
    text("ROTAÇÃO", tiny, DIM, pad, top)
    text(fmt(rpm), big, TXT, pad, top + int(h * 0.04))
    bar = pygame.Rect(pad, top + int(h * 0.27), lw - pad, int(h * 0.045))
    pygame.draw.rect(screen, PANEL, bar, border_radius=8)
    if rpm:
        frac = min(rpm / 6500.0, 1.0)
        col = BAD if rpm > 5500 else WARN if rpm > 4500 else ACC
        pygame.draw.rect(screen, col, (bar.x, bar.y, int(bar.w * frac), bar.h), border_radius=8)
    spd = f.get("vel_kmh")
    text("VELOCIDADE", tiny, DIM, pad, top + int(h * 0.36))
    r = text(fmt(spd), big, TXT, pad, top + int(h * 0.40))
    text("km/h", small, DIM, r.right + pad // 2, r.bottom - int(h * 0.05), "bottomleft")

    # grade de medidores à direita
    kml = f.get("consumo_kml")
    cons = (fmt(kml, 1), "km/L") if kml is not None else (fmt(f.get("consumo_lh"), 1), "L/h")
    agua, bat, oleo = f.get("temp_agua"), f.get("bateria_v"), f.get("oleo_bar")
    tiles = [
        ("ÁGUA", fmt(agua), "°C", BAD if (agua or 0) > 104 else TXT),
        ("BATERIA", fmt(bat, 1), "V", WARN if (bat or 99) < 12 else TXT),
        ("ÓLEO", fmt(oleo, 1), "bar", BAD if (oleo is not None and oleo < 0.5 and (rpm or 0) > 600) else TXT),
        ("CONSUMO", cons[0], cons[1], TXT),
        ("TANQUE", fmt(f.get("comb_l", 60), 1), "L", WARN if f.get("comb_reserva", 60) == 1 else TXT),
        ("AUTONOMIA", fmt(f.get("autonomia_km", 60)), "km", TXT),
        ("MÉDIA VIAGEM", fmt(f.get("trip_kml", 60), 1), "km/L", TXT),
        ("CABINE", fmt(f.get("temp_cabine"), 1), "°C", TXT),
    ]
    gx, gy = lw + pad, top
    cols, rows = 2, 4
    gw, gh = w - gx - pad, int(h * 0.74)
    cw, ch = (gw - pad * (cols - 1)) // cols, (gh - pad * (rows - 1)) // rows
    for i, (label, val, unit, col) in enumerate(tiles):
        x = gx + (i % cols) * (cw + pad)
        y = gy + (i // cols) * (ch + pad)
        pygame.draw.rect(screen, PANEL, (x, y, cw, ch), border_radius=12)
        text(label, tiny, DIM, x + pad, y + pad // 2)
        r = text(val, mid, col if val != "—" else DIM, x + pad, y + ch - pad // 2, "bottomleft")
        text(unit, tiny, DIM, r.right + pad // 2, r.bottom - 4, "bottomleft")

    # faixa de alertas
    alerts = build_alerts(f)
    strip = pygame.Rect(0, h - int(h * 0.09), w, int(h * 0.09))
    if alerts:
        blink = int(time.time() * 2) % 2 == 0
        pygame.draw.rect(screen, (120, 25, 25) if blink else (80, 18, 18), strip)
        text("  |  ".join(alerts), small, TXT, w // 2, strip.centery, "center")
    else:
        text("tudo normal", tiny, DIM, w // 2, strip.centery, "center")


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--url", default="http://127.0.0.1:8000")
    ap.add_argument("--windowed", action="store_true")
    ap.add_argument("--size", default="800x480", help="só no modo janela")
    ap.add_argument("--shot", default="", help="salva uma captura PNG após 3 s e sai (teste)")
    a = ap.parse_args()

    pygame.init()
    pygame.mouse.set_visible(False)
    if a.windowed or a.shot:
        w, h = (int(x) for x in a.size.split("x"))
        screen = pygame.display.set_mode((w, h))
    else:
        screen = pygame.display.set_mode((0, 0), pygame.FULLSCREEN)
    h = screen.get_height()
    fonts = tuple(pygame.font.Font(None, max(14, int(h * k))) for k in (0.30, 0.16, 0.075, 0.05))
    feed, clock, t0 = Feed(a.url), pygame.time.Clock(), time.time()

    while True:
        for e in pygame.event.get():
            if e.type == pygame.QUIT or (e.type == pygame.KEYDOWN and e.key in (pygame.K_ESCAPE, pygame.K_q)):
                return
        draw(screen, fonts, feed)
        pygame.display.flip()
        if a.shot and time.time() - t0 > 3:
            pygame.image.save(screen, a.shot)
            return
        clock.tick(10)  # 10 quadros/s bastam e poupam a CPU do Zero


if __name__ == "__main__":
    main()
