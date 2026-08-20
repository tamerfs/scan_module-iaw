# Projeto ECU K-Line / IAW

## Objetivo

Construir uma ferramenta Python para investigar, reproduzir e diagnosticar a comunicação K-Line da ECU Fiat.

## Estratégia

1. Confirmar hardware e pinagem.
2. Capturar o software original.
3. Registrar TX/RX e timing.
4. Identificar estrutura dos frames.
5. Validar hipóteses.
6. Implementar K-Line/protocolo em Python.
7. Comparar nosso tráfego com o software original.

## Estado atual

- Interface K-Line em investigação.
- Free Serial Port Monitor disponível para observar o software original.
- `pySerial` será usado pelo nosso software.
- O `spy://` será usado para registrar operações feitas pelo nosso próprio código.
- Captura de IRP do software de terceiros continua sendo responsabilidade do monitor/driver do Windows.

## Princípio

Observar → registrar → formular hipótese → testar → validar → implementar.
