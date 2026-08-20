# Hardware

## Veículo

Fiat Strada 1999 1.6 16V High Torque.

## Investigação

Há medições de continuidade envolvendo OBD-II e conector Fiat de 3 pinos. Os números devem ser tratados como resultados de medição e reconfirmados antes de qualquer conexão definitiva.

## Continuidade medida — adaptador Fiat 3 pinos

Medição informada em 19/08/2026, com a trava do OBD-II voltada para baixo:

| Origem | Destino | Interpretação |
|---|---|---|
| Jacaré positivo | OBD-II pino 16 (8ª posição da fileira inferior) | +12 V |
| Jacaré negativo | OBD-II pinos 4 e 5; Fiat pino 2 | Terra |
| Fiat pino 3 | OBD-II pino 7 | K-line |
| Fiat pino 1 | OBD-II pino 15 | L-line |

Esta continuidade é compatível com o adaptador Fiat de 3 pinos esperado e elimina o
adaptador como suspeito principal, mas não substitui uma nova medição caso haja dúvida
sobre a orientação física dos conectores.

## Não assumir

- pinagem por aparência;
- equivalência entre variantes IAW;
- alimentação/K-Line sem medição;
- documentação genérica como substituta de medição real.
