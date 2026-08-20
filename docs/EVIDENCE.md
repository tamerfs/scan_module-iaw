# Evidências

A evidência primária deve permanecer separada das interpretações.

Fontes possíveis:

- medição elétrica;
- captura serial;
- captura IRP/IOCTL;
- documentação técnica;
- código;
- teste reproduzível.

Nunca transformar uma hipótese em fato sem validação.

## Identificação do executor

As pastas e os nomes de exportação não determinam quem executou uma sessão.
Cada captura deve ser classificada pelos próprios dados do log, considerando:

- horário absoluto e sequência dos eventos;
- porta serial envolvida;
- processo e caminho exibidos no evento de abertura (`Opened by` ou equivalente);
- função, direção, bytes, IOCTLs e encerramento da sessão.

O processo identificado no log é a fonte de autoria da comunicação. Por exemplo,
`Multiecuscan.exe` identifica o MultiECUScan e `python.exe` identifica o executor
Python, independentemente da pasta onde os arquivos foram salvos. Quando houver
mais de uma sessão, correlacionar abertura, operações e fechamento pelo intervalo
de tempo antes de interpretar os bytes.
