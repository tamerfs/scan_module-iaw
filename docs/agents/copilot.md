# Copilot — Contribuições

## 2026-08-20

### Análise inicial do repositório

- Confirmado que o código vigente fica em `src/` e que `OLD base/` deve ser usado como arquivo histórico de versões, scripts e logs.
- Identificado que os logs do MultiECUScan são a evidência primária mais confiável disponível; scripts antigos, frames e checksums não validados devem permanecer como referências experimentais.
- Confirmado que `src/serial_logger.py` registra somente o tráfego do próprio código Python por meio de `pySerial`/`spy://`; ele não substitui a captura IRP de outro processo.
- Mantido o princípio de trabalho documentado: observar, registrar, formular hipótese, testar, validar e implementar.

### Processo de alteração

- Antes de modificar código principal, consultar a documentação, as evidências e o histórico relevante.
- Toda alteração em código principal deve comentar o comportamento anterior e explicar por que ele foi modificado.
- Preservar evidências brutas e indicar o nível de confiança de interpretações e resultados.

### Integração do SerialLogger

- Alterado `IawEcu` para aceitar uma fábrica de porta serial, mantendo `serial.Serial` como padrão e permitindo injetar `SerialLogger` sem alterar o protocolo.
- Alterado `SerialLogger` para encaminhar os estados usados pelo protocolo (`baudrate`, `timeout`, RTS, DTR, break, abertura e bytes disponíveis) e registrar essas mudanças no JSONL.
- Alterado `main.py` para injetar o logger no mesmo caminho de comunicação da ECU. A captura fica em `data/captures/` e registra o tráfego do próprio Python, não operações de outros processos.
- Validação local com porta simulada confirmou a geração do JSONL e o registro de TX, RX, estados de linha, baudrate e fechamento. O handshake físico ainda depende do hardware e não foi executado.

### Correção de execução do ponto de entrada

- `main.py` usava imports relativos (`from .src...`) e falhava quando executado diretamente com `python main.py`. Os imports foram alterados para `from src...`, mantendo a forma de execução documentada na raiz do projeto.
- A importação foi validada com `import main` e a compilação dos módulos passou; a execução física ainda depende da COM5 e da ECU conectadas.

### Avaliação dos logs Python

- A captura IRP confirmou que o Python abre a COM5, envia `00`/recebe `00`, depois envia `33` em 5 baud e recebe `33` sem obter `55`.
- Os logs Python não mostram `IOCTL_SERIAL_SET_BREAK_ON/OFF`; isso diferencia a execução `uart` da sequência RTS+BREAK observada no MultiECUScan e orienta o próximo teste com `break_rts`.

### Avaliação da execução `break_rts`

- O CSV do monitor confirmou `SET_BREAK_ON/OFF` alternado com RTS, validando que o método `break_rts` chegou ao driver serial.
- A ECU respondeu `00 00`, mas o Python recebeu somente mais um `00` e não encontrou `55`; isso é avanço parcial em relação ao método UART, mas ainda não é handshake concluído.
- A diferença de formato foi registrada: o CSV expõe os IOCTLs BREAK, enquanto o dump textual resume principalmente estados RTS e bytes.

### Repetição com chave ligada

- O teste `main.py break_rts` foi repetido com a chave de contato ligada.
- A captura confirmou novamente `00`/`00` na sondagem, BREAK/RTS no slow-init, resposta `00 00` seguida de `00` e ausência de `55`.
- O resultado não mudou; a condição de ignição foi informada pelo procedimento, não medida diretamente pelo monitor.

### Repetição com motor ligado

- O teste `main.py break_rts` foi repetido com o motor ligado e o monitor capturando.
- O JSONL confirmou novamente sondagem `00`/`00`, BREAK/RTS, resposta `00 00`, um `00` adicional e ausência de `55`.
- A captura IRP exportada pelo monitor para esta sessão ainda está pendente; o resultado Python foi registrado separadamente em `TEST-007`.

### Comparação conjunta MultiECUScan/Python

- Na captura conjunta, a autoria foi determinada pelos eventos `Opened by` e pelos horários: quatro sessões do `Multiecuscan.exe` ocorreram antes de duas sessões do `python.exe`.
- O log conjunto identificou a escrita ASCII de 30 bytes do teste de linha e distinguiu essa operação das sessões Python posteriores, que registraram sondagem e slow-init.
- A rodada foi registrada como `TEST-008`; não é necessário separar pastas quando abertura, processo, sequência e fechamento estão preservados.

### Reanálise das quatro aberturas

- A decomposição do CSV mostrou que uma ação `CONNECT` usa uma sondagem curta e uma sessão principal longa; uma ação `TEST` usa uma sessão de latência com 202 ecos `AA` e outra sessão para os 30 bytes ASCII.
- A interpretação anterior foi refinada: quatro aberturas não representam quatro ações do usuário.
- A lógica Python deve ser comparada principalmente com a Sessão 2, que recebe `00 00`, `55`, ISO code e chave; as sessões de latência e teste de linha não devem ser confundidas com o handshake.

### Novo CONNECT isolado

- A captura acumulada recebeu duas novas sessões do `Multiecuscan.exe`: sondagem às 14:28:51 e sessão principal às 14:29:00.
- A sessão principal repetiu a anterior: `00 00`, `55`, ISO code `B0 86 83 15 23`, chave `03 34 51 88` e consultas, sem teste `AA` ou escrita ASCII de 30 bytes.
- A janela fechar sozinha é compatível com o fim/encerramento da sessão; o log mostra que a conexão foi concluída antes do fechamento.

### Ampliação do SerialLogger

- Antes: `IawEcu` atribuía `rtscts` e `dsrdtr`, mas `SerialLogger` não encaminhava esses atributos à porta interna; a captura não permitia confirmar esses estados.
- Agora: `SerialLogger` encaminha e registra `rtscts`/`dsrdtr` como eventos `RTSCTS`/`DSRDTR`, e `_serial_state()` inclui esses valores no diagnóstico.
- Validação com porta simulada confirmou que as propriedades chegam à porta interna e que as mudanças são exportadas para o JSONL. Ainda é necessário repetir o teste físico para comparar esses estados com a Sessão 8 do MultiECUScan.

### Resultado do teste após a ampliação

- O Port Monitor confirmou duas sessões Python às 14:35:49 e 14:35:52; a sessão de slow-init registrou BREAK/RTS, `00 00`, `00` e timeouts.
- O JSONL passou a registrar `RTSCTS=False` e `DSRDTR=False`, mas o handshake ainda não alcança `55`.
- A correção aumentou a observabilidade; não foi considerada correção do protocolo. O próximo passo é comparar os estados pós-`00 00` por timestamp com a Sessão 8 do MultiECUScan.

### Regra de autoria das sessões

- A autoria de uma comunicação será determinada pelos próprios logs, não pela pasta ou pelo nome do arquivo exportado.
- Para distinguir executores, usar horário, porta, sequência de eventos e principalmente o caminho do processo no evento de abertura (`Multiecuscan.exe` ou `python.exe`).
