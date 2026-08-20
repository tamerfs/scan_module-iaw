"""
Comunicacao de baixo nivel com modulos de injecao Fiat / Magneti-Marelli IAW
via interface KKL (K-line), usando slow-init estilo ISO9141 a 5 baud.

IMPORTANTE: os valores de endereco/keyword abaixo sao os mais comuns usados
pela familia IAW-6F/8F/16F/18F/18FD (mesma familia geral de protocolo
documentada no projeto open-source "IAW Scan 2", licenca BSD-3-Clause:
https://github.com/TzOk83/IES2). O seu modulo (1ABG.81/5526 HH) pode ter
pequenas variacoes de timing/keyword - se o handshake falhar, vale abrir o
codigo-fonte desse projeto (pasta IES_2/) e comparar com a familia de ECU
mais proxima da sua antes de ajustar as constantes aqui.
"""

import time
from typing import Optional
import serial
from serial.tools import list_ports

class IawEcu:
    IAW_SCAN_COMM_BAUD = 4800
    SLOW_INIT_BIT_TIME = 0.2
    SLOW_INIT_RESPONSE_TIMEOUT = 3.0
    COMMON_BAUDRATES = (10400, 9600, 4800, 19200, 38400, 57600, 115200)
    IDENTIFICATION = {
        "family": "Magneti Marelli IAW 1AB / 1AF",
        "iso_code": "B0 86 83 15 23",
        "fiat_drawing_number": "861448460000",
        "programming_date": "24/07/2012",
        "interface": "VagCom/KKL USB/RS232 com CH340",
    }

    def __init__(
        self,
        port: str,
        address: int = 0x33,
        baudrate: int = 10400,
        timeout: float = 2.0,
        line_state: bool = True,
    ):
        self.port_name = port
        self.address = address
        self.baudrate = baudrate
        self.timeout = timeout
        # Muitos clones de cabo KKL/409.1 usam DTR/RTS para alimentar o
        # circuito que habilita o driver da linha K. Default True: muda
        # para False se voce confirmar que seu cabo nao precisa disso.
        self.line_state = line_state
        self.ser: Optional[serial.Serial] = None
        self.diagnostics = []
        self.diagnostic_started = None

    @staticmethod
    def available_ports():
        """Retorna as portas seriais detectadas no sistema operacional."""
        return list(list_ports.comports())

    def validate_port(self) -> bool:
        """Valida a porta configurada e explica como corrigir o problema."""
        available_ports = self.available_ports()
        port_found = any(
            item.device == self.port_name
            or item.device.lower() == self.port_name.lower()
            for item in available_ports
        )
        if port_found:
            return True

        print(f"Erro: a porta {self.port_name} nao foi encontrada.")
        if available_ports:
            print("Portas detectadas:")
            for item in available_ports:
                print(f"  - {item.device}: {item.description}")
        else:
            print("Nenhuma porta serial foi detectada.")
        print("Conecte o cabo e confira a porta no sistema operacional.")
        return False

    def _diagnostic(self, message: str):
        self.diagnostics.append(message)
        elapsed = ""
        if self.diagnostic_started is not None:
            elapsed = f" +{time.monotonic() - self.diagnostic_started:.3f}s"
        print(f"[DIAGNOSTICO{elapsed}] {message}")

    def _serial_state(self) -> str:
        """Retorna o estado observavel da porta para diagnostico."""
        if self.ser is None:
            return "porta=nenhuma"
        return (
            f"porta_aberta={self.ser.is_open}, baudrate={self.ser.baudrate}, "
            f"rts={self.ser.rts}, dtr={self.ser.dtr}, break={self.ser.break_condition}, "
            f"bytes_disponiveis={self.ser.in_waiting}"
        )

    def open(self):
        self.ser = serial.Serial(
            port=None,
            baudrate=self.baudrate,
            bytesize=8,
            parity=serial.PARITY_NONE,
            stopbits=1,
            timeout=self.timeout,
            rtscts=False,
            dsrdtr=False,
        )
        self.ser.port = self.port_name
        self.ser.rts = self.line_state
        self.ser.dtr = self.line_state
        self.ser.open()
        self._diagnostic(f"Porta aberta: {self._serial_state()}.")

    def close(self):
        if self.ser and self.ser.is_open:
            self.ser.close()

    def _slow_init_send_address(self):
        """Bit-bang do byte de endereco do ECU a 5 bps via break_condition (linha K).

        MANTIDO para referencia/testes, mas nao usado por padrao: varios
        clones CH340/CH341 ignoram SetCommBreak silenciosamente, entao esse
        metodo pode nao chegar a transmitir nada de verdade na linha K.
        Veja _slow_init_send_address_uart() para o metodo recomendado.
        """
        bit_time = self.SLOW_INIT_BIT_TIME
        bits = [0]  # start bit (nivel baixo)
        bits += [(self.address >> i) & 1 for i in range(8)]
        bits.append(1)  # stop bit (nivel alto)
        self._diagnostic(f"Slow-init bits={''.join(str(bit) for bit in bits)}.")
        for index, bit in enumerate(bits):
            self.ser.break_condition = bit == 0
            self._diagnostic(
                f"Slow-init bit {index + 1}/{len(bits)} valor={bit}: {self._serial_state()}."
            )
            time.sleep(bit_time)
        self.ser.break_condition = False
        self.ser.rts = self.line_state
        self._diagnostic(f"Slow-init finalizado: {self._serial_state()}.")

    def _slow_init_send_address_ctrl(self, line: str = "rts", invert: bool = False):
        """Bit-bang do byte de endereco via uma linha de controle (RTS ou
        DTR) em vez da UART/TX. Varios cabos KKL/409.1 usam essas linhas
        pra desenhar o pulso de 5 baud na linha K, contornando a
        limitacao de baudrate minima da UART do chip USB-serial - e o log
        do MultiECUScan sugere ser esse o caso aqui (a transmissao do
        endereco nunca aparece como "Written data" no monitor de porta).

        line: "rts" ou "dtr". invert: inverte a polaridade (0/1) caso a
        primeira tentativa nao funcione - nao temos como saber de antemao
        qual polaridade o cabo espera.
        """
        if self.ser is None or not self.ser.is_open:
            raise RuntimeError("Chame open() antes de _slow_init_send_address_ctrl().")

        bit_time = self.SLOW_INIT_BIT_TIME
        bits = [0]  # start bit (nivel baixo)
        bits += [(self.address >> i) & 1 for i in range(8)]
        bits.append(1)  # stop bit (nivel alto)
        self._diagnostic(f"Slow-init via {line} (invert={invert}) bits={''.join(str(b) for b in bits)}.")

        def set_line(level_low: bool):
            value = level_low
            if invert:
                value = not value
            if line == "dtr":
                self.ser.dtr = value
            else:
                self.ser.rts = value

        for index, bit in enumerate(bits):
            set_line(bit == 0)
            self._diagnostic(
                f"Slow-init bit {index + 1}/{len(bits)} valor={bit}: {self._serial_state()}."
            )
            time.sleep(bit_time)

        set_line(False)
        self._diagnostic(f"Slow-init via {line} finalizado: {self._serial_state()}.")

    def _slow_init_send_address_break_rts(self):
        """Bit-bang alternando RTS e break_condition JUNTOS, sincronizados
        por bit (DTR fica desligado o tempo todo): bit 0 = RTS ligado +
        BREAK ligado; bit 1 = RTS desligado + BREAK desligado. Padrao
        identificado no log de IOCTLs (IOCTL_SERIAL_SET_RTS sempre
        acompanhado de IOCTL_SERIAL_SET_BREAK_ON, e IOCTL_SERIAL_CLR_RTS
        sempre acompanhado de IOCTL_SERIAL_SET_BREAK_OFF) capturado numa
        conexao real e bem-sucedida do MultiECUScan com esse mesmo cabo.
        """
        if self.ser is None or not self.ser.is_open:
            raise RuntimeError("Chame open() antes de _slow_init_send_address_break_rts().")

        self.ser.dtr = False
        bit_time = self.SLOW_INIT_BIT_TIME
        bits = [0]  # start bit
        bits += [(self.address >> i) & 1 for i in range(8)]
        bits.append(1)  # stop bit
        self._diagnostic(f"Slow-init via RTS+BREAK combinados, bits={''.join(str(b) for b in bits)}.")

        for index, bit in enumerate(bits):
            asserted = bit == 0
            self.ser.rts = asserted
            self.ser.break_condition = asserted
            self._diagnostic(
                f"Slow-init bit {index + 1}/{len(bits)} valor={bit}: {self._serial_state()}."
            )
            time.sleep(bit_time)

        self.ser.rts = False
        self.ser.break_condition = False
        self._diagnostic(f"Slow-init via RTS+BREAK finalizado: {self._serial_state()}.")

    def _slow_init_send_address_uart(self):
        """Envia o byte de endereco a 5 baud trocando a baudrate da MESMA
        porta ja aberta (sem fechar/reabrir), escrevendo o byte
        normalmente e deixando o hardware da UART modular o sinal - em
        vez de simular via break_condition.

        Fechar e reabrir a porta USB-serial no meio do processo (como a
        versao anterior deste metodo fazia, usando uma porta separada)
        pode resetar o driver CH340 bem no momento em que o ECU espera o
        sinal - o MultiECUScan mantem a porta aberta o tempo todo durante
        o slow-init, entao replicamos isso aqui.

        Precisa ser chamado com a porta principal (self.ser) JA ABERTA.
        """
        if self.ser is None or not self.ser.is_open:
            raise RuntimeError("Chame open() antes de _slow_init_send_address_uart().")

        original_baud = self.ser.baudrate
        self._diagnostic(f"Trocando baudrate para 5 (era {original_baud}) para enviar endereco 0x{self.address:02X}.")
        self.ser.baudrate = 5
        self.ser.write(bytes([self.address]))
        self.ser.flush()
        # 10 bits (start+8+stop) a 5 baud = 2s; margem extra por seguranca
        time.sleep(2.2)
        self.ser.baudrate = original_baud
        self._diagnostic(f"Byte de endereco enviado a 5 baud (UART real); baudrate restaurada para {original_baud}.")

    def _handshake_once(self) -> Optional[bytes]:
        """Executa uma tentativa de handshake na porta ja aberta."""
        self._diagnostic(
            f"Parametros: address=0x{self.address:02X}, baudrate={self.baudrate}, timeout={self.timeout}s."
        )
        time.sleep(2.5)  # intervalo minimo de silencio antes do slow-init
        self._slow_init_send_address_uart()
        self._diagnostic("Slow-init enviado.")

        self.ser.reset_input_buffer()

        sync = self._read_bytes(1, wait=0.3)
        if not sync or sync[0] != 0x55:
            self._diagnostic(f"Sincronismo nao recebido: esperado 0x55, recebido {sync.hex() or 'nenhum byte' }.")
            return None
        self._diagnostic(f"Sincronismo recebido: {sync.hex()}.")

        kw = self._read_bytes(2, wait=0.3)
        if len(kw) != 2:
            self._diagnostic(f"Keywords incompletas: recebido {kw.hex() or 'nenhum byte'}.")
            return None
        self._diagnostic(f"Keywords recebidas: {kw.hex()}.")

        # Tester ecoa o complemento de KW2; ECU deve responder com o
        # complemento do byte de endereco enviado no slow-init.
        self._write_bytes(bytes([(~kw[1]) & 0xFF]))
        self._diagnostic(f"Resposta KW2 enviada: {((~kw[1]) & 0xFF):02X}.")
        addr_echo = self._read_bytes(1, wait=0.3)
        if not addr_echo or addr_echo[0] != ((~self.address) & 0xFF):
            self._diagnostic(
                f"Pareamento falhou: esperado complemento do endereco {((~self.address) & 0xFF):02X}, "
                f"recebido {addr_echo.hex() or 'nenhum byte'}."
            )
            return None

        self._diagnostic(f"Pareamento confirmado: {addr_echo.hex()}.")
        return kw

    def connect(self) -> Optional[bytes]:
        """Executa o handshake; falhas de protocolo viram diagnostico."""
        self.diagnostics.clear()
        self._diagnostic(f"Iniciando handshake na porta {self.port_name}.")
        self.open()
        return self._handshake_once()

    def _query_with_echo(self, request: int) -> Optional[int]:
        """Envia uma consulta KWP simples e descarta o eco do adaptador."""
        self.ser.reset_input_buffer()
        self._write_bytes(bytes([request]))
        response = self._read_bytes(2, wait=0.005)
        if len(response) != 2:
            self._diagnostic(f"Consulta 0x{request:02X}: resposta incompleta {response.hex() or 'nenhuma'}.")
            return None
        if response[0] != request:
            self._diagnostic(f"Consulta 0x{request:02X}: eco inesperado {response[0]:02X}.")
            return None
        self._diagnostic(f"Consulta 0x{request:02X}: resposta {response[1]:02X}.")
        return response[1]

    def connect_iaw_scan(self, slow_init_method: str = "uart") -> Optional[str]:
        """Conecta reproduzindo a sequencia observada no MultiECUScan.

        slow_init_method:
            "uart"          - troca a baudrate da porta ja aberta para 5 (padrao)
            "break"         - bit-bang via break_condition (TX)
            "rts"           - bit-bang via RTS
            "rts_inverted"  - bit-bang via RTS com polaridade invertida
            "dtr"           - bit-bang via DTR
            "dtr_inverted"  - bit-bang via DTR com polaridade invertida
            "break_rts"     - RTS+break_condition juntos (padrao real do
                               MultiECUScan identificado no log de IOCTLs)
        """
        self.diagnostics.clear()
        self.diagnostic_started = time.monotonic()
        self._diagnostic(f"Iniciando modo IAW Scan 2 na porta {self.port_name}.")

        self.baudrate = 9600
        self.open()
        self._diagnostic("Executando despertar da interface em 9600 baud: 00.")
        self._write_bytes(bytes([0x00]))
        wake_response = self._read_bytes(1, wait=0.05)
        self._diagnostic(f"Resposta do despertar: {wake_response.hex() or 'nenhuma'}.")
        self.close()
        # No log real do MultiECUScan ha ~2s de silencio entre o fechamento
        # da sondagem inicial e a reabertura da porta para o slow-init de
        # verdade (18:22:42 -> 18:22:44). 0.5s nao e suficiente e o ECU
        # ignora a tentativa seguinte.
        time.sleep(2.0)

        self.baudrate = self.IAW_SCAN_COMM_BAUD
        self.open()
        self.ser.rtscts = False
        self.ser.dsrdtr = False
        self._diagnostic(f"RTS/DTR mantidos em {self.line_state} antes do slow-init.")
        self._diagnostic("Baudrate de comunicacao/slow-init configurado em 4800.")

        self._diagnostic("Executando uma unica inicializacao lenta do endereco 0x33.")
        if slow_init_method == "break":
            self._slow_init_send_address()
        elif slow_init_method == "rts":
            self._slow_init_send_address_ctrl("rts", invert=False)
        elif slow_init_method == "rts_inverted":
            self._slow_init_send_address_ctrl("rts", invert=True)
        elif slow_init_method == "dtr":
            self._slow_init_send_address_ctrl("dtr", invert=False)
        elif slow_init_method == "dtr_inverted":
            self._slow_init_send_address_ctrl("dtr", invert=True)
        elif slow_init_method == "break_rts":
            self._slow_init_send_address_break_rts()
        else:
            self._slow_init_send_address_uart()

        prefix = self._read_bytes(2, wait=0.1)
        self._diagnostic(
            f"Resposta inicial apos slow-init: {prefix.hex() or 'nenhuma'}; {self._serial_state()}."
        )

        sync_and_iso = bytearray(prefix)
        self._diagnostic(
            f"Aguardando ate {self.SLOW_INIT_RESPONSE_TIMEOUT:.1f} segundos pelo sincronismo 0x55."
        )
        deadline = time.monotonic() + self.SLOW_INIT_RESPONSE_TIMEOUT
        original_timeout = self.ser.timeout
        self.ser.timeout = 0.1
        try:
            while time.monotonic() < deadline:
                value = self._read_bytes(1)
                if not value:
                    continue
                sync_and_iso.extend(value)
                self._diagnostic(f"Byte recebido durante espera: {value.hex()}; {self._serial_state()}.")
                if value[0] == 0x55:
                    break
        finally:
            self.ser.timeout = original_timeout

        if not sync_and_iso or 0x55 not in sync_and_iso:
            self._diagnostic(f"Sincronismo nao encontrado: recebido {sync_and_iso.hex() or 'nenhum byte'}.")
            return None

        iso_tail = self._read_bytes(5, wait=0.1)
        if len(iso_tail) != 5:
            self._diagnostic(f"ISO code incompleto: recebido {iso_tail.hex() or 'nenhum byte'}.")
            return None

        iso_code = iso_tail.hex().upper()
        self._diagnostic(f"ISO code recebido: {iso_code}.")
        return iso_code

    # Sequencia observada no log do MultiECUScan logo apos o ISO code:
    # enviada byte a byte (cada um ecoado pelo cabo), e o ECU confirma
    # ecoando os mesmos 4 bytes de volta apos o ultimo. Nos testes ate
    # agora essa sequencia veio sempre identica (03 34 51 88); se em
    # capturas futuras ela mudar, provavelmente depende do ISO code lido.
    CONNECTION_KEY = bytes([0x03, 0x34, 0x51, 0x88])

    def send_connection_key(self) -> bool:
        """Envia a chave de conexao pos-ISO-code e confirma o eco do ECU.

        Deve ser chamado logo apos connect_iaw_scan() retornar um iso_code
        valido, na mesma sessao/porta aberta (nao feche a porta entre os dois).
        """
        self._diagnostic(f"Enviando chave de conexao: {self.CONNECTION_KEY.hex()}.")
        for byte in self.CONNECTION_KEY[:-1]:
            self._write_bytes(bytes([byte]))
            echo = self._read_bytes(1, wait=0.05)
            self._diagnostic(f"Enviado {byte:02X}, eco recebido {echo.hex() or 'nenhum'}.")
            if not echo or echo[0] != byte:
                self._diagnostic("Eco divergente durante a chave de conexao.")
                return False

        last = self.CONNECTION_KEY[-1]
        self._write_bytes(bytes([last]))
        # depois do ultimo byte: 1 byte de eco proprio + 4 bytes de
        # confirmacao do ECU (a propria chave espelhada de volta)
        response = self._read_bytes(1 + len(self.CONNECTION_KEY), wait=0.1)
        self._diagnostic(f"Resposta final da chave de conexao: {response.hex() or 'nenhuma'}.")

        if len(response) < 1 + len(self.CONNECTION_KEY):
            self._diagnostic("Resposta incompleta - conexao nao confirmada.")
            return False

        own_echo, confirmation = response[0], response[1:]
        if own_echo != last or confirmation != self.CONNECTION_KEY:
            self._diagnostic(
                f"Confirmacao inesperada: esperava eco {last:02X} + {self.CONNECTION_KEY.hex()}, "
                f"recebi {own_echo:02X} + {confirmation.hex()}."
            )
            return False

        self._diagnostic("Conexao confirmada pelo ECU.")
        return True

    def scan_baudrates(self, baudrates=None) -> Optional[tuple[int, bytes]]:
        """Testa baudrates comuns e retorna (baudrate, keywords) ao parear."""
        if not self.validate_port():
            return None

        rates = tuple(baudrates or self.COMMON_BAUDRATES)
        self.diagnostics.clear()
        self._diagnostic(f"Iniciando varredura de baudrates: {rates}.")

        for rate in rates:
            self.close()
            self.baudrate = rate
            self._diagnostic(f"Testando baudrate {rate}.")
            try:
                self.open()
                keywords = self._handshake_once()
            except serial.SerialException:
                self.close()
                raise

            if keywords is not None:
                self._diagnostic(f"Baudrate encontrado: {rate}.")
                return rate, keywords

            self.close()

        self._diagnostic("Nenhum baudrate testado concluiu o pareamento.")
        return None

    def _write_bytes(self, data: bytes):
        self.ser.write(data)
        self.ser.flush()

    def _read_bytes(self, n: int, wait: Optional[float] = None) -> bytes:
        if wait:
            time.sleep(wait)
        return self.ser.read(n)

    @staticmethod
    def checksum(data: bytes) -> int:
        return sum(data) & 0xFF

    def send_frame(self, payload: bytes, response_len: int = 64) -> bytes:
        """Monta um frame [tamanho][payload...][checksum], envia e devolve a resposta crua.

        O formato exato de payload/checksum pode variar por sub-familia do IAW -
        ajuste aqui depois de confirmar o comando certo para o seu ECU.
        """
        frame = bytes([len(payload)]) + payload
        frame += bytes([self.checksum(frame)])
        self._write_bytes(frame)
        return self._read_bytes(response_len, wait=0.1)