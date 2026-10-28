# Projeto em Python para Raspberry Pi

Esta versão foi preparada para rodar no Raspberry Pi: `ecu.py` conversa com a ECU e `main.py` disponibiliza o painel.

## Por que Python, e não C#?

O Pi Zero W original usa CPU ARMv6, enquanto o .NET roda em ARMv7 ou mais recente. No Zero 2 W, C# seria uma opção, mas como o protocolo já está decodificado, manter tudo em um processo Python é mais simples.

## Como funciona

- `ecu.py` implementa o protocolo: slow init, chave, ACK dos blocos e conversões.
- A leitura rápida (RPM, injeção, lambda e MAP) acontece em todo ciclo. Os sensores lentos (temperaturas, bateria, carga e outros) são alternados, um por ciclo.
- `main.py` lê a ECU em uma thread e guarda os dados em um dicionário compartilhado.
- Um servidor Flask envia os dados ao celular em tempo real; o painel é aberto no navegador.
- GPS e BMP280/BME280 funcionam em threads separadas e publicam dados usando `update({...})`.
- O painel usa Server-Sent Events e uma página sem dependências externas. Assim, evita-se o peso do Plotly Dash e não é necessária internet no carro; o celular desenha os gráficos.

## Recursos implementados

### ECU

O protocolo foi portado para Python, incluindo slow init, chave, ACK dos blocos e conversões dos sensores.

### GPS

`gps.py` lê o NEO-M8N pela UART, valida o checksum das sentenças NMEA e publica velocidade, rumo, latitude/longitude, altitude, satélites e HDOP. Parado, o GPS pode oscilar cerca de 0,3 km/h; valores abaixo de 1 km/h são zerados para não indicar movimento. Também há um `MockGps`.

### Barômetro

`bmp280.py` lê o sensor por I2C e publica temperatura da cabine, pressão em hPa e altitude barométrica. A conta foi conferida com o exemplo numérico do datasheet da Bosch (25,08 °C e 1006,53 hPa).

O código aceita BMP280 e BME280. Algumas placas vendidas como “BMP280” podem usar o chip BME280. Também há um `MockBmp`.

### Viagem e registro

- A distância é calculada pela integração da velocidade do GPS; os litros são estimados pelo consumo, e o painel mostra o km/L médio.
- Os dados da viagem são salvos em `trip.json`, para persistirem quando o Pi for desligado.
- O botão **Zerar viagem** limpa os dados da viagem.
- A opção `--log viagem.csv` grava uma linha por segundo com os principais valores. Esse arquivo pode ser usado para calibrar o consumo.

## Testes e limitações conhecidos

### Testes realizados

- As funções do protocolo foram testadas com frames reais das capturas.
- A leitura completa foi testada contra uma ECU simulada com eco, reproduzindo os valores do log: 13,00 V, 875 rpm e 61 °C.
- O servidor em modo simulado foi iniciado e o painel e o stream foram conferidos.
- Os testes offline (`tests.py`) passam, e a simulação completa também foi executada.
- O cálculo do BMP280 foi conferido com o exemplo do datasheet da Bosch.

### Ainda não testado

A porta serial real no Linux e a leitura da ECU em Python ainda precisam ser testadas. O principal risco técnico é o timing do slow init (break de 200 ms por bit) no Linux com o CH340.

### Limite de atualização

A leitura do protocolo chega a aproximadamente três sensores por segundo, limite semelhante ao do MultiEcuScan. Por isso, o RPM atualiza a cada cerca de 1,5 segundo. Isso é suficiente para um painel de uso normal.

## Como testar e validar

### 1. Testar no PC com simulação

Instale as dependências e inicie a ECU, o GPS e o BMP simulados:

```bash
pip install flask pyserial
python main.py --simulate
```

### 2. Testar a ECU real no PC

Com o carro ligado, confirme primeiro a comunicação Python antes de levar o projeto ao Pi:

```bash
python main.py --port COM3 --debug
```

### 3. Testar no Raspberry Pi

O usuário precisa estar no grupo `dialout` para acessar a porta serial:

```bash
python3 main.py --port /dev/ttyUSB0
```

Depois, abra `http://<ip-do-pi>:8000` no celular.

### Combinações com simuladores

```bash
# ECU, GPS e BMP simulados
python3 main.py --simulate

# ECU real, GPS e BMP simulados
python3 main.py --gps mock --bmp mock
```

### Quando os sensores chegarem

```bash
python3 main.py --gps /dev/serial0 --bmp real
```

## Hardware

### Raspberry Pi Zero W

- O Pi Zero W tem duas portas micro-USB. A porta de dados, na borda, recebe o cabo KKL por meio de um adaptador OTG.
- A porta `PWR IN` recebe os 5 V de um conversor 12→5 V.
- O NEO-M8N usa a UART do Pi, compartilhada com o Bluetooth no Zero W. Será necessário liberar essa UART antes de usá-la.

### BMP280/BME280

- O BMP280 não mede umidade. Para medir umidade, é necessário um BME280; apesar da aparência semelhante, é outro chip.
- Habilite o I2C no Pi usando `raspi-config` e ligue o sensor em 3,3 V, SDA (GPIO2) e SCL (GPIO3).
- O endereço I2C padrão é `0x76`; para `0x77`, use `--bmp-addr 0x77`.

### GPS NEO-M8N

O NEO-M8N sai de fábrica a 9600 baud. No Pi Zero W, será necessário liberar a UART compartilhada com o Bluetooth.

## Consumo e calibração

O painel calcula L/h a partir da injeção e do RPM. O km/L passa a ser calculado quando o GPS está disponível.

A estimativa usa tempo de injeção útil, vazão do bico, número de cilindros e RPM (`RPM/120`). Os valores padrão ainda são aproximados:

- Vazão: `150 cc/min` (`--flow 150`)
- Tempo morto: `0,8 ms` (`--dead 0.8`)
- Escala: `0,00326 ms` por unidade

Calibre com um tanque cheio: mantenha `--log` ligado e, a cada abastecimento, ajuste `--k` pela relação entre os litros reais e os estimados. Em marcha lenta com o motor quente, cerca de 0,9 L/h é um valor plausível.

## Outras informações que podem ser mostradas

### Já possíveis com os dados disponíveis

- **Alertas:** água acima de 104 °C, bateria abaixo de 12 V, lambda sem oscilar ou integrador fora da faixa.
- **Picos e tempo:** RPM máximo da viagem, velocidade máxima e tempo parado com o motor ligado.
- **Autonomia:** estimada com base no tanque; é necessário informar o nível de combustível a cada abastecimento.
- **Checagem cruzada:** comparar a pressão atmosférica da ECU (854 mbar) com a leitura do BMP280 para conferir a conversão.
- **Inclinação:** estimada pela variação da altitude do GPS e do barômetro.

### Dependem de mais trabalho ou dados

- **Códigos de falha:** o MultiEcuScan envia `03 50 00 53` para ler erros, mas só foi capturado o caso sem falhas. Para decodificar códigos, é necessária uma captura com uma falha ativa. Uma possibilidade é desconectar um sensor sem importância com o carro desligado.
- **Estado do A/C:** só poderá ser confirmado depois que o kit for instalado.

## Próximo passo recomendado

Antes de levar o projeto ao Pi, rode a ECU real no PC com `python main.py --port COM3 --debug` e confira o log. A comunicação serial real no Linux ainda não foi validada.

## Preparar o Raspberry Pi (uma vez)

```bash
sudo apt update && sudo apt install -y python3-venv i2c-tools git
cd ~/scan_module-iaw/IawPyScan
python3 -m venv .venv && .venv/bin/pip install -r requirements.txt
sudo usermod -aG dialout,i2c $USER        # porta serial e I2C sem sudo (sair e entrar de novo)
sudo raspi-config nonint do_i2c 0         # habilita I2C
sudo raspi-config nonint do_serial_cons 1 # tira o console da serial
sudo raspi-config nonint do_serial_hw 0   # habilita a UART de hardware
```

Em `/boot/firmware/config.txt` (em sistemas mais antigos: `/boot/config.txt`) acrescente:

```
dtoverlay=disable-bt   # libera a UART principal para o GPS (desliga o Bluetooth; o Wi-Fi continua)
dtoverlay=w1-gpio      # DS18B20 no GPIO4
```

Reinicie e confira:

```bash
i2cdetect -y 1                       # esperado: 0x76 (BME280) e 0x68 (MPU6050)
ls /dev/ttyUSB0 /dev/serial0         # cabo KKL e GPS
cat /dev/serial0                     # deve aparecer texto $GNRMC... (GPS a céu aberto)
cat /sys/bus/w1/devices/28-*/w1_slave
python3 -m lib.tests                 # testes sem hardware
```

### Ligações (tudo em 3,3 V)

| Sensor | Pinos |
|---|---|
| BME280 e MPU6050 | VCC 3,3 V, GND, SDA (GPIO2), SCL (GPIO3). BME280 em 0x76, MPU6050 em 0x68 |
| NEO-M8N | VCC, GND, TX do módulo no RXD (GPIO15), RX do módulo no TXD (GPIO14) |
| DS18B20 | vermelho 3,3 V, preto GND, amarelo no GPIO4, resistor 4,7 kΩ entre amarelo e 3,3 V |

### MPU6050: eixos
Considere X = frente do carro, Y = esquerda, Z = para cima. Se a placa ficar montada diferente, use
`--imu-map` (ex.: `--imu-map -y,x,z`). A calibração acontece nos primeiros segundos: o carro precisa estar
**parado**. A inclinação é relativa à posição em que o Pi foi ligado.

### DS18B20: nomes
O programa mostra os IDs ao iniciar (`[ds] 28-... -> temp_externa`). Com dois sensores, aqueça um com a mão
e use `--ds-names 28-xxxx=temp_oleo,28-yyyy=temp_externa`.

### Comando completo
```bash
.venv/bin/python main.py --port /dev/ttyUSB0 --gps /dev/serial0 --bmp real --imu real --ds real --oil real --tank 51 --log ~/viagem.csv
```
Teste de cada sensor isolado: troque `real` por `mock` nos que ainda não estiverem ligados.

### Wi-Fi sem internet (hotspot do próprio Pi)
```bash
sudo nmcli device wifi hotspot ifname wlan0 ssid Strada password 'troque-esta-senha'
```
O celular conecta nessa rede e abre `http://10.42.0.1:8000`.

### Iniciar sozinho
Na pasta `IawPyScan`, depois de criar o `.venv`:
```bash
./instalar_servico.sh
```
O script descobre seu usuário e a pasta sozinho (não precisa editar nada) e instala o serviço `strada`.
Por padrão ele usa os sensores já ligados; pra incluir o óleo: `./instalar_servico.sh --args "--port /dev/ttyUSB0 --gps /dev/serial0 --bmp real --imu real --ds real --oil real --tank 51 --log ~/viagem.csv"`.
Logs: `journalctl -u strada -f`. Reiniciar: `sudo systemctl restart strada`.

## Tela cheia no HDMI (sem navegador)

O Pi Zero W (ARMv6, sem NEON) **não roda Chromium nem Firefox**, e nenhum navegador moderno. Em vez de insistir,
o `display.py` desenha o painel direto na tela com pygame (sem navegador, bem mais leve) lendo o mesmo servidor.
O celular continua usando a página web normalmente.

```bash
sudo apt install -y python3-pygame       # usar o python3 do sistema, não o .venv
python3 display.py --windowed            # teste em janela (com o main.py rodando)
```

**Tela cheia fixa, ao ligar (modo console, recomendado: libera ~100 MB de RAM do desktop):**
```bash
./instalar_servico.sh --display
sudo systemctl set-default multi-user.target     # boot sem desktop
sudo reboot
```
Se a tela ficar preta, teste à mão (com o desktop parado): `SDL_VIDEODRIVER=kmsdrm python3 display.py`.
Para voltar ao desktop: `sudo systemctl set-default graphical.target`.

**Se preferir manter o desktop:** inicie o `display.py` na sessão gráfica (autostart) sem definir `SDL_VIDEODRIVER`:
`python3 /home/SEU_USUARIO/scan_module-iaw/IawPyScan/display.py`. Descubra o tipo de sessão com `echo $XDG_SESSION_TYPE`.

Sair da tela cheia: tecla `Esc` ou `Q`. Quer ver um navegador de verdade no HDMI? Troque o Pi Zero W pelo
**Pi Zero 2 W** (mesmo tamanho, CPU de 64 bits com NEON); aí Chromium e até .NET passam a rodar.

## Combustível: no tanque, autonomia e calibração

Na tela, **Abasteci** e **Ajustar nível**. O programa estima o gasto pela injeção e desconta do tanque.

- **Abasteci + "tanque cheio"** (encheu até a bomba desarmar): o tanque passa a valer a capacidade. Se o
  abastecimento anterior também foi cheio, os litros colocados são o gasto real desde então e o fator `k`
  é recalibrado sozinho (exige pelo menos 10 L estimados no intervalo). Quanto mais longo o intervalo, melhor.
- **Abasteci + parcial**: soma os litros ao que o programa acha que tem. Não calibra.
- **Ajustar nível**: você diz quantos litros acha que tem (use se esqueceu de registrar um abastecimento).
- **Autonomia** = litros no tanque x média km/L desde o último abastecimento (aparece depois de 5 km).
- Alerta de reserva abaixo de `--reserve` litros (padrão 6). Capacidade: `--tank 51` (padrão 50; confira a do seu carro).
- Tudo fica salvo em `fuel.json` e sobrevive a desligar o Pi.

Dica: pra calibrar bem, encha sempre até a bomba desarmar, do mesmo jeito, no mesmo posto/bomba.

## Pressão do óleo (sensor 0,5-4,5 V + ADS1115)

**Este é o único item que mexe no circuito de óleo do motor.** Se não tiver segurança, peça a um mecânico
para montar o adaptador. Um vazamento de óleo derruba a pressão e pode fundir o motor.

- **Onde ligar:** em um adaptador em T no furo do interruptor de pressão original (o da luz do painel). A luz continua
  funcionando e o sensor novo vai no outro braço do T. Confirme a rosca do seu motor antes de comprar o adaptador.
- **Sensor:** transdutor automotivo 0-10 bar, saída 0,5-4,5 V, alimentação 5 V, rosca compatível com o T.
  Instale longe do coletor de escape e com o conector voltado para baixo (evita acúmulo de água).
- **Nunca** leve mangueira de óleo para dentro da cabine.
- **Circuito** (ADS1115 alimentado em **3,3 V**; o Pi só aguenta 3,3 V):

```
sinal do sensor --[10k]--+--[20k]-- GND      -> ADS1115 A0
+5 V do sensor  --[10k]--+--[20k]-- GND      -> ADS1115 A1   (mesmo divisor)
ADS1115: VDD 3,3 V, GND, SDA (GPIO2), SCL (GPIO3), ADDR em GND (0x48)
```

O programa usa A0/A1 (ratiométrico), então variações da fonte de 5 V não alteram a pressão. GND do sensor,
do conversor 12->5 V e do Pi devem ser o mesmo.

- **Rodar:** `--oil real` (use `--oil-range 10` conforme o sensor; testar sem hardware: `--oil mock`).
- **Alerta:** o valor fica vermelho se a pressão cair abaixo de 0,5 bar com o motor acima de 600 rpm. Esse limite é
  provisório: registre algumas semanas (`--log`) para ver o que é normal no seu motor, quente e frio, e ajuste.

