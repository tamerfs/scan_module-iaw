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
