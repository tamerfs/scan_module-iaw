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

## Regra de correlação das capturas

Não separar ou atribuir sessões somente pelo nome da pasta. Os logs devem ser
correlacionados por horário, porta, sequência de eventos e caminho do processo
responsável pela comunicação. O campo de abertura do monitor (`Opened by`) deve
ser usado para distinguir `Multiecuscan.exe` de `python.exe`; a pasta é apenas o
destino de armazenamento da exportação.

## Estado atual

- Interface K-Line em investigação.
- Free Serial Port Monitor disponível para observar o software original.
- `pySerial` será usado pelo nosso software.
- O `spy://` será usado para registrar operações feitas pelo nosso próprio código.
- Captura de IRP do software de terceiros continua sendo responsabilidade do monitor/driver do Windows.
- O MultiECUScan foi observado na `COM5`; a configuração inicial registrada foi 4800 baud, 8N1.
- O próximo marco é uma captura passiva completa do MultiECUScan: dados de `IRP_MJ_WRITE`,
  `IRP_MJ_READ`, IOCTLs e seus intervalos. Não reproduzir comandos na ECU antes disso.

## Configuração de captura adotada

Os prints de Preferências do Free Serial Port Monitor recebidos em 20/08/2026 passam a
ser a referência de configuração. Para uma captura forense, usar representação
hexadecimal, timestamps absolutos e as colunas de função/direção/tamanho/porta.
Desativar a opção de mesclar dados por 250 ms: ela é útil para leitura humana, mas
perde a delimitação e o timing dos requests que precisamos comparar.

## Princípio

Observar → registrar → formular hipótese → testar → validar → implementar.
