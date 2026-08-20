# Testes

Formato recomendado:

## TEST-001 — descrição

- Data:
- Hardware:
- Software:
- Porta:
- Configuração:
- Ação:
- Resultado:
- Captura:
- Interpretação:
- Confiança:
- Próximo teste:

## TEST-002 — Teste de conexão e temporizadores do MultiECUScan

- Data: 20/08/2026
- Hardware: cabo VagCom/KKL com CH340, COM5, adaptador Fiat de 3 pinos; medições de alimentação e linhas registradas em `docs/HARDWARE.md`.
- Software: MultiECUScan; Free Serial Port Monitor.
- Porta: COM5.
- Configuração: teste iniciado pelo botão de conexão e repetido em Configurações; captura IRP/serial nas visões line, table e dump.
- Ação: executar a conexão e o teste de interface, incluindo latência com 200 bytes e timers de 1000 ms e 250 ms.
- Resultado informado pelo MultiECUScan:

```text
VagCom/KKL

Testing latency with 200 bytes of data...
Min latency: 2
Max latency: 4

Testing timers...
(The acceptable tolerance for results is ~5 ms)

System supports high resolution timer.

Testing timer with 1000 ms...
..result: 1008 ms

Testing timer with 250 ms...
O tempo limite da operação acabou.
```

- Evidência observada nos logs: a sessão abre a COM5 em 9600 baud, envia `00` e recebe `00`; depois reabre em 4800 baud e executa alterações de RTS/DTR e pulsos de `BREAK`. No encerramento há uma escrita de 30 bytes, seguida por leitura de 1 byte com `STATUS_TIMEOUT`, limpeza da porta e fechamento.
- Capturas:
	- `data/captures/log port monitor multiecuscan line view.log`
	- `data/captures/log port monitor multiecuscan table view.log`
	- `data/captures/log port monitor multiecuscan dump view.log`
- Interpretação: o teste de conexão foi capturado e a interface respondeu à sondagem inicial. O timeout final ocorreu durante uma leitura sem resposta após a escrita de teste de 30 bytes; pela posição no encerramento e pela mensagem exibida, é provavelmente o teste de timer de 250 ms, não uma confirmação de falha do handshake da ECU. A sequência não deve ser usada como prova de que o comando de 30 bytes foi aceito pela ECU.
- Confiança: Alta para bytes, baudrates, sinais e `STATUS_TIMEOUT` observados nos logs; Média para associar esse timeout especificamente ao timer de 250 ms, pois a associação depende da ordem da interface do MultiECUScan.
- Próximo teste: separar em capturas independentes o botão Conectar e o teste de Configurações; correlacionar cada sessão com horário e resultado exibido, e verificar se há resposta da ECU após o slow-init antes de analisar o teste de timer.

## TEST-003 — Primeira execução Python com a COM5 reconectada

- Data: 20/08/2026
- Hardware: cabo VagCom/KKL com CH340 na COM5; ECU reconectada.
- Software: Python do `.venv`, `pySerial` e código do projeto.
- Porta: COM5.
- Configuração: `main.py` executado sem argumento, usando o método `uart`.
- Ação: abrir a porta, executar a sondagem em 9600 baud e tentar o slow-init em 5 baud.
- Resultado: a COM5 abriu; a sondagem enviou `00` e recebeu `00`. O slow-init enviou `33` a 5 baud, mas o programa recebeu somente `33` como eco e não encontrou o sincronismo `55`; o handshake não foi concluído.
- Captura:
	- `data/captures/serial_capture_20260820_134312.jsonl`
	- `data/captures/serial_capture_20260820_134314.jsonl`
	- `data/captures/serial_spy_20260820_134312.log`
	- `data/captures/serial_spy_20260820_134314.log`
- Interpretação: a falha de porta foi resolvida e o logger capturou a sessão. O eco `33` demonstra atividade no caminho serial, mas não confirma que o ECU recebeu o endereço no formato esperado. O método `uart` não reproduziu a resposta `00 00` seguida de `55` observada nos logs do MultiECUScan.
- Confiança: Alta para abertura da COM5, bytes TX/RX e ausência de `55` na captura; Média para atribuir a causa ao método de slow-init, pois ainda não foram testados os modos de controle RTS/BREAK nesta execução.
- Próximo teste: executar `main.py break_rts`, pois a captura real do MultiECUScan mostra RTS e `BREAK` alternados durante o slow-init; comparar o JSONL gerado com `serial_capture_20260820_134314.jsonl`.

## TEST-004 — Captura IRP das tentativas Python

- Data: 20/08/2026
- Hardware: cabo VagCom/KKL com CH340 na COM5; ECU conectada.
- Software: Python do projeto e Free Serial Port Monitor.
- Porta: COM5.
- Configuração: duas tentativas do `main.py` sem argumento, usando `uart`; o monitor capturou as operações do processo Python.
- Ação: executar a sondagem da interface e o slow-init do endereço `0x33`.
- Resultado observado: nas duas sessões, o Python abriu a COM5 em 9600 baud, enviou `00` e recebeu `00`, fechou a porta e reabriu em 4800 baud. Em seguida mudou para 5 baud e escreveu `33`; após restaurar 4800 baud, recebeu `33` e encerrou sem receber `55`.
- Diferença relevante: os logs Python não contêm `IOCTL_SERIAL_SET_BREAK_ON` nem `IOCTL_SERIAL_SET_BREAK_OFF`. Os logs do MultiECUScan contêm esses pulsos durante o slow-init, junto com RTS.
- Capturas:
	- `data/captures/log port monitor python code line view.log`
	- `data/captures/log port monitor python code table view.log`
	- `data/captures/log port monitor python code dump view.log`
- Interpretação: a interação do Python com a COM5 está sendo transmitida e capturada corretamente. A ausência de `BREAK` confirma que o teste realizado foi o método UART a 5 baud, não a sequência RTS+BREAK observada no MultiECUScan. O byte `33` recebido é compatível com eco da transmissão, mas não demonstra resposta válida do ECU.
- Confiança: Alta para a sequência de abertura, baudrates, bytes, ausência de BREAK e encerramento; Média para classificar `33` como eco, pois o log serial não identifica sozinho a origem elétrica desse byte.
- Próximo teste: executar `main.py break_rts` e confirmar no monitor a presença de `IOCTL_SERIAL_SET_BREAK_ON/OFF` alternados com RTS antes de avaliar o resultado do handshake.

## TEST-005 — Execução Python com `break_rts`

- Data: 20/08/2026
- Hardware: cabo VagCom/KKL com CH340 na COM5; ECU conectada.
- Software: Python do projeto e Free Serial Port Monitor.
- Porta: COM5.
- Configuração: `main.py break_rts`; exportação do monitor na pasta `data/captures/python monitor port logs/`.
- Ação: executar a sondagem em 9600 baud e o slow-init com RTS e `break_condition` alternados por bit.
- Resultado observado: a sondagem enviou `00` e recebeu `00`. Na segunda abertura em 4800 baud, o Python desativou DTR e executou pulsos RTS/BREAK. O ECU respondeu `00 00`; depois o Python recebeu mais um `00`, não recebeu `55` e encerrou após os timeouts de leitura.
- Evidência adicional: o `table view.csv` contém `IOCTL_SERIAL_SET_BREAK_ON/OFF` alternados com `IOCTL_SERIAL_SET_RTS/CLR_RTS`. O `dump view.txt` mostra os pulsos RTS e os bytes `00 00`/`00`, mas não lista os IOCTLs BREAK individualmente; para esse detalhe, o CSV é a fonte apropriada.
- Capturas:
	- `data/captures/python monitor port logs/line view.txt`
	- `data/captures/python monitor port logs/table view.csv`
	- `data/captures/python monitor port logs/dump view.txt`
	- `data/captures/serial_capture_20260820_135638.jsonl`
	- `data/captures/serial_capture_20260820_135706.jsonl`
- Interpretação: o Python agora reproduz a forma elétrica de slow-init observada no MultiECUScan e obtém a resposta inicial `00 00`, uma melhora objetiva sobre o método `uart`, que recebia apenas `33`. Ainda não há confirmação de handshake porque o byte de sincronismo `55` não apareceu. O próximo ponto a investigar é a temporização após `00 00` e a condição de linha/baudrate usada antes da chegada do `55`.
- Confiança: Alta para a presença de BREAK/RTS, os bytes `00 00` e a ausência de `55` nas capturas; Média para concluir que a temporização é a única diferença restante, pois ainda há diferenças de estado DTR/RTS e configuração de leitura a comparar com a sessão MultiECUScan.
- Próximo teste: comparar os timestamps e estados de linha do período imediatamente após `00 00` com a captura MultiECUScan, testar a mesma sequência com DTR inicialmente desligado e preservar cada variação em uma captura separada.

## TEST-006 — Repetição com chave de contato ligada

- Data: 20/08/2026
- Hardware: cabo VagCom/KKL com CH340 na COM5; ECU conectada; chave de contato ligada durante o teste, conforme procedimento informado.
- Software: Python do projeto, `pySerial` e Free Serial Port Monitor.
- Porta: COM5.
- Configuração: `main.py break_rts`.
- Ação: repetir a sondagem e o slow-init RTS/BREAK após ligar a chave de contato.
- Resultado: a COM5 abriu; a sondagem enviou `00` e recebeu `00`. O slow-init executou BREAK/RTS, recebeu `00 00` e depois mais um `00`. O byte `55` não foi recebido e o handshake não foi concluído.
- Capturas:
	- `data/captures/serial_capture_20260820_140559.jsonl`
	- `data/captures/serial_capture_20260820_140601.jsonl`
	- `data/captures/serial_spy_20260820_140559.log`
	- `data/captures/serial_spy_20260820_140601.log`
- Interpretação: ligar a chave não alterou o resultado desta repetição. O caminho serial e a resposta inicial `00 00` continuam funcionando, mas a ECU não apresentou o sincronismo `55` dentro da janela de espera atual.
- Confiança: Alta para os bytes, pulsos e ausência de `55`; Média para concluir que a chave ligada não tem efeito, pois o estado da ignição foi informado pelo procedimento e não medido pelo monitor.
- Próximo teste: comparar detalhadamente a configuração pós-`00 00` com o MultiECUScan e corrigir o encaminhamento de `rtscts`/`dsrdtr` no `SerialLogger` antes de novas variações de timing.

## TEST-007 — Repetição com motor ligado

- Data: 20/08/2026
- Hardware: cabo VagCom/KKL com CH340 na COM5; motor ligado durante o teste, conforme procedimento informado.
- Software: Python do projeto, `pySerial` e Free Serial Port Monitor em captura.
- Porta: COM5.
- Configuração: `main.py break_rts`.
- Ação: repetir a sondagem e o slow-init RTS/BREAK com o motor em funcionamento.
- Resultado: a COM5 abriu; a sondagem enviou `00` e recebeu `00`. O slow-init executou BREAK/RTS, recebeu `00 00` e depois mais um `00`. O byte `55` não foi recebido e o handshake não foi concluído.
- Captura Python:
	- `data/captures/serial_capture_20260820_140752.jsonl`
	- `data/captures/serial_capture_20260820_140754.jsonl`
	- `data/captures/serial_spy_20260820_140752.log`
	- `data/captures/serial_spy_20260820_140754.log`
- Captura do Port Monitor: aguardando a exportação dos arquivos correspondentes a esta sessão; os arquivos anteriores não devem ser reutilizados como se fossem desta execução.
- Interpretação: ligar o motor não alterou os bytes recebidos nem permitiu a chegada do sincronismo `55`. O teste confirma novamente que a comunicação alcança a etapa `00 00`, mas não permite concluir se a causa restante é temporização, estado da linha, configuração serial ou resposta da ECU.
- Confiança: Alta para os eventos registrados pelo JSONL; Média para qualquer conclusão sobre o efeito elétrico do motor até comparar a captura IRP correspondente.
- Próximo teste: exportar os três formatos do Port Monitor desta sessão e comparar a janela `00 00` → `55` com os testes `TEST-005` e `TEST-006`.

## TEST-008 — Comparação sequencial MultiECUScan e Python na mesma captura

- Data: 20/08/2026
- Hardware: cabo VagCom/KKL com CH340 na COM5; motor ligado durante a rodada, conforme procedimento informado.
- Software: MultiECUScan, Python do projeto e Free Serial Port Monitor.
- Porta: COM5.
- Critério de identificação: as sessões foram classificadas pelo horário e pelo processo exibido no log, não pelo nome da pasta. O monitor registrou quatro aberturas por `C:\Program Files (x86)\Multiecuscan\Multiecuscan.exe` entre 14:19:39 e 14:20:07 e duas aberturas por `C:\Users\tamer\AppData\Roaming\uv\python\cpython-3.14-windows-x86_64-none\python.exe` entre 14:20:51 e 14:20:56.
- Ação: executar as operações do MultiECUScan em sequência, incluindo o teste de linha, e depois executar `main.py break_rts`.
- Resultado MultiECUScan: o log mostra várias sessões com leituras e escritas; também registra a escrita dos 30 bytes ASCII `123456789012345678901234567890`, correspondente ao teste de linha. O encerramento inclui leitura sem dados com `STATUS_TIMEOUT`.
- Resultado Python: as duas sessões abriram e fecharam a COM5. A captura JSONL correspondente registra sondagem `00`/`00`; na sessão principal, BREAK/RTS, resposta `00 00`, um `00` adicional e ausência de `55` até o timeout.
- Captura conjunta: `data/captures/monitor port logs redirecionamento/` (`line view.txt`, `table view.csv`, `dump view.txt` e `terminal view.txt`). Capturas Python associadas: `serial_capture_20260820_142051.jsonl` e `serial_capture_20260820_142053.jsonl`.
- Interpretação: a captura única permite distinguir os executores pelos próprios eventos de abertura e seus horários. O MultiECUScan executou a conexão/teste de linha antes do Python; o Python não foi responsável pelos bytes ASCII de 30 bytes, pois sua sessão posterior contém a sequência de sondagem e slow-init. A comparação confirma que não houve mistura de autoria apesar de as operações terem sido exportadas juntas.
- Confiança: Alta para a autoria, ordem temporal, abertura/fechamento e escrita ASCII de 30 bytes; Alta para a sequência Python registrada em JSONL; Média para mapear cada uma das quatro sessões MultiECUScan a um botão específico, porque os eventos foram executados consecutivamente sem uma etiqueta explícita no log.
- Próximo teste: manter a captura conjunta, mas registrar no horário do monitor uma marca externa entre Conectar e Teste de linha; não é necessário separar as pastas, desde que cada sessão tenha abertura, processo, eventos e fechamento preservados.

## TEST-009 — Decomposição das quatro aberturas do MultiECUScan

- Data: 20/08/2026
- Fonte: mesma captura conjunta de `data/captures/monitor port logs redirecionamento/`, classificada pelo processo e pelos horários dos eventos.
- Correção da interpretação anterior: quatro aberturas não significam quatro ações do usuário. Elas são compatíveis com uma ação `CONNECT` e uma ação `TEST`.
- Sessão 1 — 14:19:39: abertura curta pelo `Multiecuscan.exe`; TX `00`, RX `00`, fechamento imediato. Esta é uma sondagem inicial da interface.
- Sessão 2 — 14:19:44 até 14:19:54: abertura longa pelo `Multiecuscan.exe`; recebeu `00 00`, `55`, ISO code `B0 86 83 15 23`, executou a chave `03 34 51 88` byte a byte e realizou consultas posteriores. Esta é a sessão principal do `CONNECT`.
- Sessão 3 — 14:20:05 até 14:20:07: abertura pelo `Multiecuscan.exe`; executou 202 escritas/leitura de `AA` com eco. Esta é a medição de latência do `TEST`.
- Sessão 4 — 14:20:07: abertura curta pelo `Multiecuscan.exe`; transmitiu os 30 bytes ASCII `123456789012345678901234567890` e terminou com leitura `STATUS_TIMEOUT`. Esta é o teste de linha de 30 bytes.
- Sessões Python posteriores: 14:20:51 e 14:20:53; a primeira fez TX/RX `00`, a segunda executou BREAK/RTS e recebeu `00 00` seguido de `00`, sem `55`.
- Interpretação: o MultiECUScan separa sondagem, conexão, latência e teste de linha em handles/sessões diferentes. Nossa implementação Python já reproduz a sondagem e tenta reproduzir o slow-init, mas não reproduz ainda a sessão principal completa: no log de referência, após `00 00` surge `55` e depois o ISO code; no Python, após `00 00` surge apenas `00` e timeout.
- Confiança: Alta para a decomposição por processo, horário, bytes, contagem de operações e fechamento; Média para associar formalmente cada sessão à etiqueta visual `CONNECT` ou `TEST`, embora a sequência operacional e os padrões de dados sustentem essa associação.
- Próximo teste: comparar a configuração e a sequência de IOCTLs da Sessão 2, especialmente entre o fim do BREAK e o primeiro `55`, com o método `_slow_init_send_address_break_rts()` e a leitura `prefix` do Python.

## TEST-010 — Novo CONNECT isolado do MultiECUScan

- Data: 20/08/2026
- Fonte: atualização posterior da captura acumulada em `data/captures/monitor port logs redirecionamento/`.
- Ação informada: executar somente `CONNECT` no MultiECUScan; não executar o teste de COM/linha.
- Sessão 7 — 14:28:51: sondagem curta pelo `Multiecuscan.exe`, TX `00`, RX `00`, fechamento.
- Sessão 8 — 14:29:00 até 14:29:10: sessão principal pelo `Multiecuscan.exe`, com 107 escritas e 248 leituras, sem `STATUS_TIMEOUT`; recebeu `00 00`, `55`, ISO code `B0 86 83 15 23`, executou `03 34 51 88` com ecos e realizou consultas posteriores.
- Comparação com `TEST-009`: a Sessão 8 repete o padrão da Sessão 2 anterior, inclusive contagem de escritas/leitura e sequência principal. Não há nesta rodada a sessão de 202 ecos `AA` nem a escrita dos 30 bytes ASCII do teste de linha.
- Interpretação: o fechamento automático da janela não indica, por si só, falha de conexão. O log mostra que o CONNECT alcançou o handshake, recebeu o ISO code, confirmou a chave e executou consultas antes de fechar a porta. A janela visual fecha depois que a operação termina ou perde a sessão, mas o log preserva o resultado.
- Confiança: Alta para processo, horários, ausência do teste de linha, sequência de handshake e fechamento; Média para afirmar por que a interface visual fecha, pois o motivo da aplicação não aparece no log serial.
- Comparação com Python: o MultiECUScan obtém `00 00 -> 55 -> B0 86 83 15 23`; o Python `break_rts` obtém `00 00 -> 00 -> timeout`. A diferença continua localizada depois do slow-init, antes do `55`.
- Próximo teste: usar a Sessão 8 como referência principal e comparar seus IOCTLs/estados imediatamente após `00 00` com os eventos do `serial_capture_20260820_142053.jsonl`, sem incluir sessões de latência ou teste de linha.

## TEST-011 — Python após ampliação do logger

- Data: 20/08/2026
- Processo identificado no Port Monitor: `C:\Users\tamer\AppData\Roaming\uv\python\cpython-3.14-windows-x86_64-none\python.exe`.
- Sessão de sondagem: 14:35:49–14:35:50; uma escrita `00`, uma leitura `00` e fechamento.
- Sessão de slow-init: 14:35:52–14:35:57; zero escritas de dados, 29 leituras, 27 com timeout, 5 `SET_BREAK_ON`, 6 `SET_BREAK_OFF`, 9 `SET_RTS` e 8 `CLR_RTS`; dados recebidos `00 00` e depois `00`.
- Captura estruturada: `data/captures/serial_capture_20260820_143549.jsonl` e `data/captures/serial_capture_20260820_143552.jsonl`.
- Resultado: a ampliação do logger registrou `RTSCTS=False` e `DSRDTR=False` antes do slow-init. O handshake continuou sem receber `55`.
- Comparação com a Sessão 8 do MultiECUScan: o processo original recebe `00 00`, depois `55`, ISO code e chave; o Python recebe `00 00`, depois `00` e entra em timeout. O Python agora tem observabilidade suficiente dos estados básicos, mas ainda não reproduz o comportamento do original.
- Interpretação: a correção do logger foi validada como captura, não como correção de protocolo. A diferença permanece na janela posterior ao `00 00`; a contagem maior de `SET_RTS` no Python deve ser comparada com a sequência exata do MultiECUScan antes de qualquer novo ajuste.
- Confiança: Alta para processo, horários, estados JSONL, IOCTLs, bytes e timeouts; Média para atribuir a causa ao número de transições RTS, pois a sequência completa de estados DTR/flow-control do MultiECUScan ainda precisa ser alinhada por timestamp.
- Próximo teste: extrair lado a lado os eventos desde o fim do último BREAK até o primeiro `55` da Sessão 8 e até o primeiro timeout Python, incluindo DTR, RTS, BREAK, baudrate, `rtscts`, `dsrdtr`, timeout e purges.
