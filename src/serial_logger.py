"""
Serial logger for the ECU K-Line project.

Uses pySerial's spy:// URL handler to record operations performed
by THIS Python application.

Important:
- It does not capture another process' COM traffic.
- It does not expose Windows IRP_MJ_READ/WRITE.
- It preserves pySerial's human-readable spy output and can additionally
  emit structured JSONL events from the wrapper.
"""

from __future__ import annotations

import json
import time
from datetime import datetime, timezone
from pathlib import Path
from typing import Optional

import serial


class SerialLogger:
    """Thin wrapper around pySerial + spy://."""

    def __init__(
        self,
        port: str,
        baudrate: int,
        capture_dir: str = "data/captures",
        timeout: float = 1.0,
        bytesize: int = serial.EIGHTBITS,
        parity: str = serial.PARITY_NONE,
        stopbits: float = serial.STOPBITS_ONE,
        write_timeout: Optional[float] = 1.0,
        rtscts: bool = False,
        dsrdtr: bool = False,
    ) -> None:
        self.capture_dir = Path(capture_dir)
        self.capture_dir.mkdir(parents=True, exist_ok=True)

        stamp = datetime.now().strftime("%Y%m%d_%H%M%S")
        self.spy_file = self.capture_dir / f"serial_spy_{stamp}.log"
        self.jsonl_file = self.capture_dir / f"serial_capture_{stamp}.jsonl"

        # pySerial's spy:// wraps the native serial implementation.
        # `all` includes otherwise-hidden in_waiting/empty read calls.
        spy_url = f"spy://{port}?file={self.spy_file}&all"
        self.serial = serial.serial_for_url(
            spy_url,
            baudrate=baudrate,
            bytesize=bytesize,
            parity=parity,
            stopbits=stopbits,
            timeout=timeout,
            write_timeout=write_timeout,
            rtscts=rtscts,
            dsrdtr=dsrdtr,
        )

        self._write_event(
            "OPEN",
            {
                "port": port,
                "baudrate": baudrate,
                "bytesize": bytesize,
                "parity": parity,
                "stopbits": stopbits,
                "timeout": timeout,
                "write_timeout": write_timeout,
                "rtscts": rtscts,
                "dsrdtr": dsrdtr,
                "spy_log": str(self.spy_file),
            },
        )

    @staticmethod
    def _hex(data: bytes) -> str:
        return data.hex(" ").upper()

    # Antes: o logger expunha apenas read/write e nao podia substituir
    # serial.Serial no protocolo. Agora estas propriedades encaminham estados
    # da porta e registram as mudancas feitas durante o slow-init.
    @property
    def is_open(self) -> bool:
        return self.serial.is_open

    @property
    def in_waiting(self) -> int:
        return self.serial.in_waiting

    @property
    def port(self):
        return self.serial.port

    @port.setter
    def port(self, value) -> None:
        self.serial.port = value

    @property
    def baudrate(self):
        return self.serial.baudrate

    @baudrate.setter
    def baudrate(self, value) -> None:
        old_value = self.serial.baudrate
        self.serial.baudrate = value
        if old_value != value:
            self._write_event("BAUDRATE", {"value": value, "previous": old_value})

    @property
    def timeout(self):
        return self.serial.timeout

    @timeout.setter
    def timeout(self, value) -> None:
        self.serial.timeout = value
        self._write_event("TIMEOUT", {"value": value})

    @property
    def rts(self):
        return self.serial.rts

    @rts.setter
    def rts(self, value: bool) -> None:
        self.serial.rts = value
        self._write_event("RTS", {"value": value})

    @property
    def dtr(self):
        return self.serial.dtr

    @dtr.setter
    def dtr(self, value: bool) -> None:
        self.serial.dtr = value
        self._write_event("DTR", {"value": value})

    @property
    def rtscts(self) -> bool:
        return self.serial.rtscts

    @rtscts.setter
    def rtscts(self, value: bool) -> None:
        self.serial.rtscts = value
        self._write_event("RTSCTS", {"value": value})

    @property
    def dsrdtr(self) -> bool:
        return self.serial.dsrdtr

    @dsrdtr.setter
    def dsrdtr(self, value: bool) -> None:
        self.serial.dsrdtr = value
        self._write_event("DSRDTR", {"value": value})

    @property
    def break_condition(self):
        return self.serial.break_condition

    @break_condition.setter
    def break_condition(self, value: bool) -> None:
        self.serial.break_condition = value
        self._write_event("BREAK", {"value": value})

    def _write_event(self, event: str, payload: dict) -> None:
        record = {
            "timestamp_utc": datetime.now(timezone.utc).isoformat(),
            "monotonic_ns": time.monotonic_ns(),
            "event": event,
            **payload,
        }
        with self.jsonl_file.open("a", encoding="utf-8") as f:
            f.write(json.dumps(record, ensure_ascii=False) + "\n")

    def write(self, data: bytes) -> int:
        started = time.monotonic_ns()
        count = self.serial.write(data)
        ended = time.monotonic_ns()

        self._write_event(
            "TX",
            {
                "data_hex": self._hex(data),
                "length": len(data),
                "written": count,
                "duration_ns": ended - started,
            },
        )
        return count

    def read(self, size: int = 1) -> bytes:
        started = time.monotonic_ns()
        data = self.serial.read(size)
        ended = time.monotonic_ns()

        self._write_event(
            "RX",
            {
                "data_hex": self._hex(data),
                "length": len(data),
                "requested": size,
                "duration_ns": ended - started,
            },
        )
        return data

    def read_all(self) -> bytes:
        started = time.monotonic_ns()
        data = self.serial.read_all()
        ended = time.monotonic_ns()

        self._write_event(
            "RX_ALL",
            {
                "data_hex": self._hex(data),
                "length": len(data),
                "duration_ns": ended - started,
            },
        )
        return data

    def flush(self) -> None:
        self.serial.flush()
        self._write_event("FLUSH", {})

    def set_dtr(self, value: bool) -> None:
        self.dtr = value

    def set_rts(self, value: bool) -> None:
        self.rts = value

    def reset_input_buffer(self) -> None:
        self.serial.reset_input_buffer()
        self._write_event("RESET_INPUT_BUFFER", {})

    def reset_output_buffer(self) -> None:
        self.serial.reset_output_buffer()
        self._write_event("RESET_OUTPUT_BUFFER", {})

    def close(self) -> None:
        if self.serial.is_open:
            self.serial.close()
            self._write_event("CLOSE", {})

    def __enter__(self) -> "SerialLogger":
        return self

    def __exit__(self, exc_type, exc, tb) -> None:
        self.close()


if __name__ == "__main__":
    import argparse

    parser = argparse.ArgumentParser(description="ECU K-Line serial capture")
    parser.add_argument("port", help="COM port, e.g. COM3")
    parser.add_argument("--baudrate", type=int, default=10400)
    parser.add_argument("--timeout", type=float, default=1.0)
    args = parser.parse_args()

    print(f"Opening {args.port} at {args.baudrate} baud")

    with SerialLogger(
        args.port,
        args.baudrate,
        timeout=args.timeout,
    ) as ser:
        print(f"Spy log: {ser.spy_file}")
        print(f"JSONL:    {ser.jsonl_file}")
        print("Logger ready. Use this module from the ECU/K-Line code.")
