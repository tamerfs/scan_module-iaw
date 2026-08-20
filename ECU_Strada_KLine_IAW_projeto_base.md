# Projeto ECU Fiat Strada — K-Line / IAW 1AB / 1AF
## Histórico técnico, linha de investigação e arquitetura do diagnóstico

> Documento-base para continuidade do projeto por diferentes IAs/agentes.
> Objetivo: preservar contexto, decisões, hipóteses, testes realizados e próximos passos sem depender da memória de uma única conversa.

---

## 1. Objetivo do projeto

Investigar e desenvolver uma solução própria em Python para comunicação e diagnóstico da ECU da **Fiat Strada 1999 1.6 16V High Torque**, utilizando a interface **K-Line**, o conector OBD/Fiat e os dados observados no software de diagnóstico original.

A estratégia definida é:

1. mapear eletricamente os conectores;
2. identificar corretamente a ECU e sua variante;
3. observar o protocolo utilizado pelo software original;
4. capturar TX/RX em hexadecimal;
5. entender inicialização, handshake, comandos e respostas;
6. reproduzir a comunicação em Python;
7. adicionar um logger/analisador próprio baseado em `pySerial`;
8. posteriormente interpretar os frames e criar funções de diagnóstico.

O objetivo não é apenas "ler a porta COM", mas chegar a uma compreensão reproduzível da comunicação:

```text
PC
 │
 ├── software original
 │       │
 │       └── COM / driver Windows
 │               │
 │               └── interface K-Line
 │                       │
 │                       └── OBD / chicote
 │                               │
 │                               └── ECU
 │
 └── nosso software Python
         │
         ├── pySerial
         ├── logger
         ├── K-Line
         ├── decoder
         └── diagnóstico
```

---

# 2. Contexto da investigação elétrica

Foi realizada uma investigação de continuidade entre o conector OBD-II, o conector Fiat de 3 pinos e o chicote.

Registros fornecidos durante os testes:

- Jacaré positivo apresentou continuidade com o **pino 08 da fileira inferior do OBD-II**, contando da esquerda para a direita conforme a orientação utilizada no teste.
- Jacaré negativo apresentou continuidade com os **pinos 04 e 05 da fileira superior do OBD-II** e com o **pino 02 (central) do conector Fiat de 3 pinos**.
- O **pino 07 da fileira superior do OBD-II** apresentou continuidade com o **pino 03 do conector Fiat de 3 pinos**, contando da esquerda para a direita com a trava voltada para baixo.
- Também foram registradas outras correspondências entre os pinos durante a comparação, devendo os números exatos ser preservados a partir dos registros/medições originais antes de assumir qualquer pinagem como definitiva.

### Regra importante

Os números acima devem ser tratados como **resultado de medição**, não como pinagem universal Fiat.

Antes de conectar sinais de forma definitiva, confirmar:

- orientação física do conector;
- numeração;
- alimentação;
- massa;
- linha K;
- continuidade até ECU;
- tensão em repouso;
- comportamento da linha durante comunicação.

---

# 3. Comparação IAW 1AB / 1AF

Uma das etapas do projeto foi comparar as famílias/variantes de ECU identificadas como **IAW 1AB e IAW 1AF**.

A investigação deve manter separadas:

- identificação física da ECU;
- identificação da família IAW;
- identificação do software/firmware;
- protocolo efetivamente observado;
- pinagem da ECU;
- pinagem do conector Fiat;
- pinagem OBD-II;
- comportamento elétrico da K-Line.

Não assumir que duas ECUs visualmente semelhantes utilizem exatamente a mesma comunicação.

### Princípio adotado

A identificação documental serve para formar hipóteses.

A **captura real do tráfego** é a evidência principal para reconstruir o protocolo usado pelo veículo/software específico.

---

# 4. Por que comparar monitores seriais

O projeto precisa observar mais do que caracteres recebidos pela porta.

Os requisitos levantados foram:

- Read data
- `IRP_MJ_READ`
- Hex dump
- Capture buffer
- Show transferred data
- I/O data
- `IRP_MJ_WRITE`
- IOCTL
- timestamps
- TX/RX
- configuração da porta

A distinção fundamental é entre:

### Nível de aplicação/serial

```text
TX → bytes enviados
RX ← bytes recebidos
```

e:

### Nível do Windows I/O

```text
IRP_MJ_READ
IRP_MJ_WRITE
IOCTL_SERIAL_*
buffers
status
I/O requests
```

Um terminal serial comum não necessariamente mostra os IRPs.

---

# 5. Free Serial Port Monitor

Foi escolhido inicialmente o **Free Serial Port Monitor**, já instalado no computador.

A conclusão da investigação foi que ele deve ser explorado antes de trocar de ferramenta.

O que interessa verificar na interface:

- Request View;
- Data View;
- hexadecimal;
- READ;
- WRITE;
- IOCTL;
- buffers;
- parâmetros;
- timestamps;
- status;
- configuração da COM.

### Estratégia

Não alterar o software original.

Primeiro iniciar a captura, depois abrir o programa de diagnóstico e registrar uma sessão completa.

Fluxo:

```text
1. iniciar monitor
2. iniciar captura
3. abrir software original
4. selecionar COM
5. conectar à ECU
6. deixar a inicialização acontecer
7. executar uma função simples
8. interromper captura
9. salvar o log
```

---

# 6. Por que o tráfego do software original é importante

O software original é uma espécie de "oráculo" para a engenharia reversa.

Se capturarmos:

```text
TX:
AA BB CC DD

RX:
11 22 33 44
```

podemos correlacionar:

```text
ação realizada no software
        ↓
mensagem TX
        ↓
resposta RX
```

Por exemplo:

```text
Conectar
   ↓
sequência de inicialização

Ler identificação
   ↓
TX específico
   ↓
RX específico

Ler RPM
   ↓
TX específico
   ↓
RX contendo dados
```

Isso permite transformar tráfego bruto em protocolo documentado.

---

# 7. Limitação do Python / pySerial

Foi decidido adicionar `pySerial` ao projeto.

Ele é adequado para quando **nosso próprio Python controla a porta serial**.

Podemos obter:

- leitura;
- escrita;
- bytes;
- HEX;
- tamanho;
- timestamp;
- configuração serial;
- timeout;
- DTR;
- RTS;
- logs;
- tratamento de erro.

Também existe no pySerial o mecanismo `spy://`, útil para depuração das operações seriais feitas pelo próprio código Python.

### Limitação fundamental

`pySerial` não substitui um monitor de IRP do Windows.

Se o software original estiver usando:

```text
Programa original
      ↓
Windows
      ↓
driver COM
      ↓
interface K-Line
```

nosso Python não consegue simplesmente abrir a mesma COM e enxergar os `IRP_MJ_READ/WRITE` que outro processo está gerando.

Normalmente a porta também é aberta de forma exclusiva.

Portanto:

```text
pySerial
   ↓
excelente para NOSSO programa

monitor de IRP
   ↓
necessário/útil para observar OUTRO programa
```

---

# 8. Arquitetura Python definida

Foi proposta a seguinte estrutura:

```text
nosso_projeto/
│
├── main.py
├── ecu.py
├── kline.py
├── obd.py
├── serial_logger.py
├── protocol.py
└── logs/
    ├── raw/
    ├── decoded/
    └── sessions/
```

### `serial_logger.py`

Responsabilidade:

- registrar TX;
- registrar RX;
- timestamp;
- HEX;
- tamanho;
- parâmetros;
- eventos da porta;
- erros;
- salvar sessão.

Exemplo conceitual:

```text
[23:14:02.135] OPEN COM3
[23:14:02.140] BAUD 10400
[23:14:02.140] DTR = LOW

[23:14:02.251] TX  81 10 F1 81
[23:14:02.267] RX  83 F1 10 C1
```

---

# 9. Separação entre logger e protocolo

O logger deve registrar o que aconteceu sem necessariamente tentar interpretar tudo.

Arquitetura recomendada:

```text
pySerial
   ↓
serial_logger.py
   ↓
raw capture
   ↓
kline.py
   ↓
frame decoder
   ↓
protocol.py
   ↓
ECU commands
   ↓
ecu.py
   ↓
diagnóstico
```

Isso evita destruir informação original durante a interpretação.

O log bruto deve sempre ser preservado.

---

# 10. Formato de log recomendado

Além de um `.txt` legível, utilizar um formato estruturado como JSON.

Exemplo:

```json
{
  "timestamp": "2026-08-20T10:00:00.123",
  "direction": "TX",
  "port": "COM3",
  "baudrate": 10400,
  "data": "81 10 F1 81",
  "length": 4
}
```

Idealmente registrar também:

- timestamp monotônico;
- timestamp humano;
- direção;
- bytes;
- comprimento;
- porta;
- baudrate;
- parity;
- stop bits;
- DTR;
- RTS;
- evento;
- erro;
- intervalo desde a mensagem anterior.

---

# 11. Timing é informação de protocolo

Não registrar somente:

```text
TX = bytes
RX = bytes
```

Registrar também:

```text
t0 → TX
t1 → RX
Δt = t1 - t0
```

Isso é especialmente importante em K-Line.

Uma sequência pode depender de:

- atraso entre bytes;
- atraso entre frames;
- timeout;
- resposta dentro de determinada janela;
- inicialização;
- wake-up;
- handshake.

Portanto, o timestamp faz parte da evidência.

---

# 12. Dois modos de operação

## Modo A — engenharia reversa

```text
Software original
        ↓
monitor serial/IRP
        ↓
TX/RX
        ↓
logs
        ↓
análise
        ↓
documentação do protocolo
```

## Modo B — nosso diagnóstico

```text
Python
  ↓
pySerial
  ↓
K-Line
  ↓
ECU
  ↓
resposta
  ↓
decoder
  ↓
diagnóstico
```

Os dois modos são complementares.

---

# 13. Fluxo de engenharia reversa

A ordem recomendada é:

### Fase 1 — elétrica

- confirmar ECU;
- confirmar conectores;
- confirmar alimentação;
- confirmar massas;
- confirmar K-Line;
- verificar tensão da linha;
- não aplicar sinais sem confirmação.

### Fase 2 — software original

- identificar COM;
- identificar configuração serial;
- iniciar captura;
- conectar;
- registrar inicialização;
- registrar uma operação simples;
- repetir operações individualmente.

### Fase 3 — classificação

Para cada mensagem:

```text
timestamp
direção
bytes
tamanho
intervalo
ação realizada
resposta
```

### Fase 4 — hipótese de protocolo

Identificar:

- header;
- source;
- target;
- comando;
- dados;
- checksum;
- comprimento;
- resposta;
- erros.

### Fase 5 — reprodução

Implementar somente depois de possuir evidência suficiente:

```text
kline.py
protocol.py
ecu.py
```

### Fase 6 — validação

Comparar:

```text
software original TX
vs
nosso Python TX
```

e:

```text
software original RX
vs
nosso Python RX
```

---

# 14. Regra de ouro da engenharia reversa

Não assumir que um byte significa algo apenas porque parece lógico.

Exemplo:

```text
TX:
81 10 F1 81
```

Não declarar imediatamente:

```text
81 = header
10 = source
F1 = destination
81 = command
```

Isso é apenas uma hipótese.

A confirmação deve vir de:

- repetição;
- comparação de mensagens;
- variação de parâmetros;
- documentação;
- resposta da ECU;
- checksum;
- timing.

---

# 15. Matriz de evidências

Recomenda-se manter uma tabela:

| ID | Ação | TX | RX | Timing | Hipótese | Confiança |
|---|---|---|---|---|---|---|
| 001 | Conectar | ... | ... | ... | Inicialização | Alta |
| 002 | Identificação | ... | ... | ... | Read ID | Média |
| 003 | RPM | ... | ... | ... | Read RPM | Média |

### Níveis

**Alta**
- confirmado por múltiplos testes.

**Média**
- forte correlação, mas ainda não validado.

**Baixa**
- hipótese baseada em padrão.

Isso é importante para evitar que uma hipótese de uma IA vire "fato" em uma versão futura do projeto.

---

# 16. Como diferentes IAs devem consumir este documento

Este Markdown deve ser tratado como **memória técnica versionada**, não como verdade absoluta.

Cada IA que trabalhar no projeto deve:

1. ler este documento;
2. distinguir fatos de hipóteses;
3. preservar medições originais;
4. não sobrescrever evidências com interpretações;
5. indicar novas hipóteses;
6. registrar testes realizados;
7. registrar resultado;
8. atualizar o nível de confiança;
9. preservar incompatibilidades entre fontes.

---

# 17. Formato recomendado para futuras contribuições de IA

```markdown
## Nova evidência — YYYY-MM-DD

### Fonte
Descrição da fonte.

### Observação
O que foi realmente observado.

### Dados brutos
```text
TX: ...
RX: ...
```

### Interpretação
Hipótese sobre o significado.

### Confiança
Alta / Média / Baixa.

### Teste necessário
O que ainda precisa ser confirmado.

### Impacto no projeto
O que muda na arquitetura/protocolo.
```

---

# 18. O que NÃO fazer

- Não assumir pinagem sem medição.
- Não assumir protocolo apenas por nome da ECU.
- Não apagar logs brutos.
- Não modificar o software original sem necessidade.
- Não misturar TX/RX de sessões diferentes sem identificação.
- Não ignorar timing.
- Não testar comandos potencialmente destrutivos sem entender previamente seu efeito.
- Não tratar uma interpretação de IA como evidência primária.
- Não substituir medições por documentação genérica.

---

# 19. Próximo passo imediato

O próximo passo é operar o **Free Serial Port Monitor já instalado** e descobrir exatamente quais informações ele apresenta.

Capturar uma sessão do software original:

```text
CAPTURE START
    ↓
software original
    ↓
conexão ECU
    ↓
inicialização
    ↓
uma função simples
    ↓
CAPTURE STOP
```

Depois analisar:

```text
IRP_MJ_READ
IRP_MJ_WRITE
IOCTL
HEX
BUFFER
TIMESTAMP
STATUS
```

Em paralelo, preparar:

```text
serial_logger.py
```

usando `pySerial`.

---

# 20. Estado atual do projeto

### Confirmado

- O projeto envolve a Fiat Strada 1999 1.6 16V High Torque.
- A comunicação investigada utiliza K-Line.
- Existe investigação de conectores OBD-II e Fiat de 3 pinos.
- O Free Serial Port Monitor está instalado.
- `pySerial` será incorporado ao projeto.
- O objetivo é desenvolver uma ferramenta Python própria.
- O software original será utilizado como referência para engenharia reversa.
- TX/RX em HEX e timing são dados fundamentais.

### Ainda precisa ser confirmado

- pinagem final completa;
- identificação definitiva da variante IAW relevante;
- configuração serial exata;
- sequência de inicialização;
- protocolo completo;
- estrutura dos frames;
- checksum;
- comandos de diagnóstico;
- interpretação dos dados;
- capacidade de reproduzir a sessão com Python.

---

# 21. Visão final

O projeto não deve ser tratado simplesmente como:

> "fazer um programa que leia a ECU".

A meta é construir uma cadeia reproduzível:

```text
ELÉTRICA
   ↓
K-LINE
   ↓
CAPTURA
   ↓
TX/RX
   ↓
TIMING
   ↓
FRAME
   ↓
PROTOCOLO
   ↓
COMANDO
   ↓
RESPOSTA
   ↓
DECODER
   ↓
DIAGNÓSTICO
   ↓
FERRAMENTA PYTHON
```

A estratégia central é:

**observar primeiro → registrar evidência → formular hipótese → testar → validar → implementar.**

Assim, o projeto pode evoluir de uma simples captura serial para uma ferramenta própria de diagnóstico da ECU, mantendo os dados brutos e o histórico necessários para que outras IAs possam continuar a investigação sem reconstruir todo o raciocínio do zero.
