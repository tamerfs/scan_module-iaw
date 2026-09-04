# ECU K-Line / IAW Diagnostic Project

Projeto de engenharia reversa e desenvolvimento de diagnóstico para ECU Fiat via K-Line.

## Estrutura

dados:
-> base: o [IawScan2](https://github.com/nortio/IawScan2) (open-source) é em C# compilado pra Windows
-> modelo consulta: [codigo fonte do MultiECUScan em C#](https://github.com/tamerfs/scan_module-iaw/tree/652df4893d6e5baee70e227e07ca9f34a03967a3/engenharia%20reversa%20em%20C)
nele vamos buscar todas as variaveis para conexão com o magnetic marelli IAW 1AB com o cabo VagCom/KKL409.1  com CH340, COM5
por exemplo:

```C

// Token: 0x060003F5 RID: 1013 RVA: 0x0007DB8C File Offset: 0x0007BD8C
private void method_7()
{
GClass126.smethod_2("data 2.1", 0);
this.dataTable_3.BeginLoadData();
this.method_6("3890|281|1|Magneti Marelli IAW 1AB Injection (1.6 16V)|IAW1AF|ISO9141|10||0|900|438");
this.method_6("4129|301|1|Magneti Marelli IAW 1AB Injection (1.6 16V)|IAW1AF|ISO9141|10||0|900|438");
}
com base em tudo isso construa um codigo simples mas com logs de debugg para podermos conectar e ler as informações do modulo de ingeção
```

## Regra

Evidência bruta deve ser preservada. Hipóteses não devem ser registradas como fatos.

## Novas alterações 2026-09-03

Faz sentido mudar para C#. O gerenciamento de tempo da porta serial no Windows via .NET (System.IO.Ports) costuma ser mais estável para bit-banging do que o wrapper do Python, e como o IawScan2 e o MultiECUScan foram escritos em C#, fica muito mais fácil traduzir a lógica de "baixo nível".
Com base nos dados do MultiECUScan (IAW1AF/ISO9141) e na estrutura do IawScan2, aqui está um código funcional em C# para realizar o Handshake e a leitura inicial.
Projeto C# (Console Application)
Você precisará adicionar a referência System.IO.Ports (via NuGet ou referências do projeto).


Para migrar de Windows para Linux (Raspberry Pi OS) usando C# (.NET), a estrutura do código permanece quase idêntica, desde que você use o .NET 6, 7 ou 8. O .NET é multiplataforma e a biblioteca System.IO.Ports funciona bem no Linux.
As principais diferenças são estratégicas e de configuração de sistema, não de lógica de programação. Aqui estão os pontos de atenção:

1. Nome da Porta (A maior mudança)
No Windows você usa COM5. No Raspberry Pi, o adaptador CH340 será reconhecido pelo kernel como um dispositivo TTY.
Windows: COM5
Linux: Geralmente /dev/ttyUSB0 (ou /dev/ttyAMA0 se estiver nos pinos GPIO).

2. Permissões de Acesso
No Windows, se a porta estiver livre, você a abre. No Linux, o seu usuário precisa de permissão para tocar no hardware.
Você deve adicionar seu usuário ao grupo dialout:
code
Bash
sudo usermod -a -G dialout $USER
(É necessário deslogar e logar novamente para surtir efeito).

3. O Bit-Banging (BreakState) no Linux
A propriedade _port.BreakState no .NET para Linux traduz-se para chamadas de sistema ioctl (TIOCSBRK / TIOCCBRK).
Vantagem do Pi: O kernel Linux costuma ter um controle de timing para portas seriais USB mais preciso que o Windows "comum". Isso faz com que os 200ms do Slow Init sejam mais estáveis no Raspberry Pi.
Atenção: Alguns adaptadores CH340 muito baratos podem ignorar o comando de "Break" no driver padrão do Linux. Se o código não funcionar no Pi, a solução é manipular o pino TX como um GPIO comum, mas isso raramente é necessário.

4. Estrutura de Código "Universal" (Windows/Linux)
Para que o seu código rode em ambos sem precisar ser reescrito, você pode usar uma verificação simples:

    ```Cs
    using System.Runtime.InteropServices;

    // ... dentro do Main ...

    string portName;
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
        portName = "COM5";
    } else {
        portName = "/dev/ttyUSB0"; // Nome padrão no Raspberry Pi
    }

    _port = new SerialPort(portName, BAUD_RATE, Parity.None, 8, StopBits.One);
    ```

5. Dependências (.NET no Pi)
Para rodar no Raspberry Pi, você não usa o ".NET Framework" antigo (que é só Windows). Você deve usar o .NET 6+.
Instale o SDK do .NET no Pi.
Ao compilar, o NuGet baixará a versão da biblioteca System.IO.Ports que contém a implementação nativa para Linux (libSystem.IO.Ports.Native.so), que já vem inclusa no pacote.
Resumo: O que muda na prática?
A lógica de:
Abrir 9600 -> Enviar 00 -> Fechar
Abrir 4800 -> Bit-bang 5 baud -> Ler 0x55
É exatamente a mesma. O C# abstrai a complexidade do sistema operacional para você.

Dica extra para o Raspberry Pi:

Se você planeja deixar isso rodando como um módulo fixo no carro, o Raspberry Pi permite que você use os pinos de hardware (GPIO 14 e 15) diretamente com um conversor de nível (K-Line Transceiver como o L9637D), eliminando o cabo USB e tornando a comunicação ainda mais robusta e rápida.

## comandos a enviar a ecu

Comando 0x01: Solicita Identificação (ID).
Comando 0x0B: Solicita a Tabela de Sensores (RPM, Temperatura, etc.).
Comando 0x07: Lê erros na memória (DTCs).
