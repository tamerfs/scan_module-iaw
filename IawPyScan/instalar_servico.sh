#!/usr/bin/env bash
# Instala o painel como serviço usando o usuário e a pasta ATUAIS (evita o erro 217/USER).
#   ./instalar_servico.sh                  painel (main.py) sobe sozinho ao ligar o Pi
#   ./instalar_servico.sh --display        + tela cheia no HDMI sem navegador (display.py, modo console)
#   ./instalar_servico.sh --print          só mostra os arquivos, não instala
#   ./instalar_servico.sh --args "..."     troca os argumentos do main.py
set -euo pipefail

DIR="$(cd "$(dirname "$0")" && pwd)"
USER_NAME="${SUDO_USER:-$(id -un)}"
HOME_DIR="$(getent passwd "$USER_NAME" | cut -d: -f6)"
ARGS="--port /dev/ttyUSB0 --gps /dev/serial0 --bmp real --imu real --ds real --tank 51 --log $HOME_DIR/viagem.csv"
DISPLAY_UNIT=0; PRINT=0
while [ $# -gt 0 ]; do
  case "$1" in
    --display) DISPLAY_UNIT=1 ;;
    --print) PRINT=1 ;;
    --args) shift; ARGS="$1" ;;
    *) echo "opção desconhecida: $1"; exit 1 ;;
  esac
  shift
done

[ -x "$DIR/.venv/bin/python" ] || echo "AVISO: $DIR/.venv não existe (python3 -m venv .venv && .venv/bin/pip install -r requirements.txt)" >&2

main_unit() { cat << UNIT
[Unit]
Description=Painel Strada (ECU + GPS + sensores)
After=network.target

[Service]
User=$USER_NAME
WorkingDirectory=$DIR
ExecStart=$DIR/.venv/bin/python main.py $ARGS
Restart=always
RestartSec=5

[Install]
WantedBy=multi-user.target
UNIT
}

display_unit() { cat << UNIT
[Unit]
Description=Painel Strada em tela cheia (HDMI)
After=strada.service
Wants=strada.service

[Service]
User=$USER_NAME
SupplementaryGroups=video render input
WorkingDirectory=$DIR
Environment=SDL_VIDEODRIVER=kmsdrm
ExecStart=/usr/bin/python3 $DIR/display.py
Restart=always
RestartSec=3

[Install]
WantedBy=multi-user.target
UNIT
}

if [ "$PRINT" = 1 ]; then
  echo "# ---- /etc/systemd/system/strada.service ----"; main_unit
  [ "$DISPLAY_UNIT" = 1 ] && { echo; echo "# ---- /etc/systemd/system/strada-display.service ----"; display_unit; }
  exit 0
fi

main_unit | sudo tee /etc/systemd/system/strada.service > /dev/null
UNITS="strada"
if [ "$DISPLAY_UNIT" = 1 ]; then
  display_unit | sudo tee /etc/systemd/system/strada-display.service > /dev/null
  UNITS="strada strada-display"
  echo "Para o HDMI sem desktop:  sudo apt install -y python3-pygame && sudo systemctl set-default multi-user.target"
fi
sudo systemctl daemon-reload
sudo systemctl enable --now $UNITS
sleep 2
systemctl --no-pager --lines=5 status $UNITS || true
echo "Logs ao vivo:  journalctl -u strada -f"
