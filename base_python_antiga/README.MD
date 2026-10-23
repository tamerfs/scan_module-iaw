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
