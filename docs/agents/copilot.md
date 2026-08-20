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
