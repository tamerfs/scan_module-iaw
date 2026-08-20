# Leitura do módulo IAW (Fiat Strada 1999) via KKL 409.1

## Identificação obtida no MultiECUScan

O teste realizado em 19/08/2026 detectou a interface `VagCom/KKL` no `COM5`,
com conversor `USB-SERIAL CH340`, e identificou a seguinte ECU:

- Família: Magneti Marelli IAW 1AB / 1AF
- ECU ISO code: `B0 86 83 15 23`
- FIAT drawing number: `861448460000`
- Data de programação: `24/07/2012`

O MultiECUScan apresentou estas aplicações compatíveis para essa identificação:

- Fiat Bravo/Brava 1.6 16V, IAW 1AF
- Fiat Marea 1.6 16V, IAW 1AB ou 1AF
- Fiat Palio Gasolina 1.6 16V, IAW 1AB

Esses resultados representam possibilidades de aplicação; não é possível
determinar o veículo exato apenas pelo ISO code informado.

## 1. Driver do cabo (chip CH340/CH341)

Cabos KKL 409.1 "chineses" costumam vir com o chip **CH340** ou o **CH341**
operando em modo serial — os dois são compatíveis com o mesmo pacote de
driver da WCH (**CH341SER**), então é normal que o instalador específico do
CH340 falhe e o do CH341 funcione: na prática eles cobrem o mesmo hardware.

Checklist rápido:
1. Abra o **Gerenciador de Dispositivos** → **Portas (COM e LPT)**. Se
   aparecer algo como `USB-SERIAL CH340 (COMx)` sem ícone de erro, o driver
   já está funcional — o erro do instalador do CH340 pode ser ignorado.
2. Se aparecer com um ícone de alerta (Código 10 ou similar), desinstale
   qualquer driver antigo, baixe o **CH341SER** direto do site oficial da
   WCH (não o que vem no CD/pendrive do cabo — é a fonte mais comum de vírus
   nesses kits) e reinstale.
3. Anote o nome da porta (`COMx` no Windows, `/dev/ttyUSB0` no Linux/Pi) —
   é o `PORT` que o script usa.

## 2. Sobre usar um projeto open-source pronto

O **IAW Scan 2** (https://github.com/TzOk83/IES2, licença BSD-3-Clause) é o
projeto mais maduro para essa família de ECU e usa exatamente o mesmo
hardware que você tem (KKL/VAG-COM 409.1 + adaptador 3 pinos Fiat). Ele é
escrito em **C# / .NET 2.0**, então não dá pra "importar" direto no seu
código Python — mas vale muito a pena:

- Baixar o código-fonte e abrir a pasta `IES_2/` para conferir os bytes de
  keyword, endereço e os comandos usados pela sub-família de IAW mais
  próxima da sua (o projeto cobre IAW-6F/8F/16F/18F/18FD/04K/1G7; seu
  1ABG.81/5526 HH não está na lista exata, mas é da mesma geração de
  protocolo Marelli via K-line).
- Usar o próprio programa (rodando numa VM Windows ou PC com .NET) como
  referência para validar se o seu ECU responde ao protocolo, antes de
  depurar o script Python.

## 3. O que os scripts aqui fazem

- `serial_iaw.py`: implementa a identificação conhecida, a validação da porta,
  a inicialização observada no MultiECUScan e a varredura de baudrates comuns
  como fallback. Para esta ECU, o modo principal usa `7680 baud`, executa o
  slow-init do endereço `0x33` via `break_condition`, recebe `00 00` e depois
  lê espontaneamente `55 B0 86 83 15 23`.
  O handshake alternativo de "slow-init" a 5 baud
  (envio bit a bit do endereço do ECU via `break_condition`), a leitura do
  byte de sincronismo (`0x55`) + keywords, e o envio de frames com checksum
  simples.
- `main.py`: ponto de entrada de teste — exibe a identificação, procura o
  baudrate que responde e imprime o que a ECU devolve.

Por padrão, o script usa `COM5` no Windows. No Raspberry Pi Zero W, altere
`PORT` para a porta criada pelo adaptador, normalmente `/dev/ttyUSB0` ou
`/dev/ttyUSB1`. O baudrate não precisa ser informado manualmente: o script
usa primeiro a sequência observada no MultiECUScan. A configuração `9600`
exibida nas propriedades do CH340 é apenas o padrão da interface; o script
altera a velocidade da porta durante a comunicação.

**Isso é um esqueleto, não uma solução testada.** Os valores exatos de
timing e de comandos variam entre sub-famílias do IAW. Se o handshake falhar:
- Confirme a pinagem: o cabo 3 pinos Fiat normalmente usa K-line, L-line,
  +12V e GND — o L-line às vezes precisa estar presente só na inicialização.
- Tente rodar com o carro com o contato ligado (chave na posição II), não
  só bateria.
- Se possível, capture os sinais na linha K com um analisador lógico barato
  (ex. um clone Saleae de 8 canais) pra comparar contra o que o IAW Scan 2
  gera quando você testa com ele.

## 4. Próximos passos (Etapa 2 — Raspberry Pi Zero W)

Depois que o handshake funcionar no PC, portar é essencialmente trocar a
`PORT` para `/dev/ttyUSB0` no Raspbian — o pyserial funciona igual em
ARM. Daí dá pra:
- Rodar o script como serviço (`systemd`) disparado na inicialização.
- Expor os dados localmente via um servidor Flask leve na rede Wi-Fi do Pi.
- Ou usar Bluetooth (PyBluez / BLE GATT) para mandar os dados pro celular.
