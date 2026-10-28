"""Livro-caixa do combustível: quanto tem no tanque, autonomia e calibração automática.

Como funciona
  - O programa estima o gasto pelo tempo de injeção (ECU) e desconta do tanque.
  - Você informa cada abastecimento (litros e se encheu até a bomba desarmar).
  - Abastecimento CHEIO zera a incerteza (tanque = capacidade) e, se o anterior também foi
    cheio, os litros colocados são o gasto real desde então: isso calibra o fator k.
  - Abastecimento PARCIAL só soma os litros ao que o programa acha que sobrou.
"""
import json
import os
import threading

MIN_CAL_L = 10.0        # só calibra com pelo menos 10 L estimados desde o último cheio
RATIO_RANGE = (0.5, 2.0)  # razão real/estimado fora disso é erro de digitação ou falha
ALPHA = 0.7             # peso da nova calibração (1.0 = substitui)


class FuelLedger:
    def __init__(self, path, capacity_l=None, reserve_l=None, k=None):
        self.path = path
        self._lock = threading.RLock()
        self.d = {"capacity_l": 50.0, "reserve_l": 6.0, "k": 1.0,
                  "remaining_l": None,        # None = ainda não informado
                  "since_est_l": 0.0,         # litros estimados desde o último abastecimento
                  "since_km": 0.0,            # km rodados desde o último abastecimento
                  "baseline_full": False,     # o último abastecimento foi cheio?
                  "history": []}
        self.load()
        # argumentos da linha de comando, quando informados, valem sobre o arquivo salvo
        for key, val in (("capacity_l", capacity_l), ("reserve_l", reserve_l), ("k", k)):
            if val is not None:
                self.d[key] = val

    # ---------- persistência ----------
    def load(self):
        try:
            with open(self.path) as f:
                self.d.update(json.load(f))
        except (OSError, ValueError):
            pass

    def save(self):
        with self._lock:
            tmp = self.path + ".tmp"
            try:
                with open(tmp, "w") as f:
                    json.dump(self.d, f)
                os.replace(tmp, self.path)   # troca atômica: queda de energia não corrompe
            except OSError:
                pass

    # ---------- leitura ----------
    @property
    def k(self):
        return self.d["k"]

    def status(self):
        with self._lock:
            d = self.d
            out = {"capacity_l": d["capacity_l"], "k": round(d["k"], 3),
                   "since_km": round(d["since_km"], 1)}
            rem = d["remaining_l"]
            if rem is not None:
                out["remaining_l"] = round(max(rem, 0.0), 1)
                out["reserva"] = rem <= d["reserve_l"]
            if d["since_km"] >= 5 and d["since_est_l"] > 0.2:
                kml = d["since_km"] / d["since_est_l"]
                out["since_kml"] = round(kml, 1)
                if rem is not None:
                    out["autonomia_km"] = round(max(rem, 0.0) * kml, 0)
            return out

    # ---------- eventos ----------
    def add(self, km, liters):
        """Chamado a cada ciclo pelo painel: km rodados e litros estimados gastos."""
        with self._lock:
            self.d["since_km"] += km
            self.d["since_est_l"] += liters
            if self.d["remaining_l"] is not None:
                self.d["remaining_l"] -= liters

    def fill(self, liters, full):
        """Registra abastecimento. Devolve (ok, mensagem)."""
        with self._lock:
            d = self.d
            if not 0.5 <= liters <= d["capacity_l"] + 5:
                return False, f"litros inválidos ({liters}); capacidade {d['capacity_l']} L"
            msg = ""
            if full:
                if d["baseline_full"] and d["since_est_l"] >= MIN_CAL_L:
                    ratio = liters / d["since_est_l"]
                    if RATIO_RANGE[0] <= ratio <= RATIO_RANGE[1]:
                        k_new = d["k"] * ratio
                        d["k"] = d["k"] * (1 - ALPHA) + k_new * ALPHA
                        msg = (f"calibrado: gasto real {liters:.1f} L contra {d['since_est_l']:.1f} L "
                               f"estimados -> k = {d['k']:.3f}")
                    else:
                        msg = "calibração ignorada (diferença grande demais, confira os litros)"
                else:
                    msg = "primeiro abastecimento cheio: referência definida, sem calibração ainda"
                d["remaining_l"] = d["capacity_l"]
                d["baseline_full"] = True
            else:
                if d["remaining_l"] is None:
                    return False, "informe antes o nível atual (ajustar nível) ou encha o tanque"
                d["remaining_l"] = min(d["capacity_l"], d["remaining_l"] + liters)
                d["baseline_full"] = False
                msg = "parcial: nível somado, sem calibração"
            d["since_est_l"] = 0.0
            d["since_km"] = 0.0
            d["history"] = (d["history"] + [{"l": liters, "full": bool(full)}])[-30:]
        self.save()
        return True, msg

    def set_remaining(self, liters):
        with self._lock:
            if not 0 <= liters <= self.d["capacity_l"]:
                return False, f"valor fora de 0 a {self.d['capacity_l']} L"
            self.d["remaining_l"] = float(liters)
            self.d["baseline_full"] = False
        self.save()
        return True, "nível ajustado (calibração desativada até o próximo cheio)"
