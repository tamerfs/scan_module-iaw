using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

// Token: 0x02000011 RID: 17
public sealed class GClass8 : GClass0
{
	// Token: 0x060000D3 RID: 211 RVA: 0x00013710 File Offset: 0x00011910
	public GClass8(byte byte_9, List<GClass104> list_3, List<GClass104> list_4)
	{
		this.byte_0 = byte_9;
		this.list_0 = list_4;
		this.list_1 = list_3;
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x00013980 File Offset: 0x00011B80
	public override void vmethod_1(GForm9 gform9_0, bool bool_5)
	{
		try
		{
			this.int_1 = 0;
			byte[] array = new byte[0];
			if (!bool_5)
			{
				for (int i = 0; i < 5; i++)
				{
					if (gform9_0 != null && gform9_0.method_0())
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(100);
				}
			}
			if (GClass126.bool_0)
			{
				byte[][] array2 = new byte[][]
				{
					new byte[]
					{
						26,
						0,
						246,
						95,
						68,
						53,
						104,
						95,
						95,
						65,
						56,
						95,
						95,
						65,
						48,
						52,
						54,
						52,
						55,
						51,
						57,
						56,
						52,
						51,
						50,
						57,
						3
					},
					new byte[]
					{
						26,
						0,
						246,
						95,
						68,
						53,
						109,
						95,
						95,
						65,
						68,
						95,
						95,
						66,
						48,
						52,
						54,
						53,
						51,
						52,
						55,
						48,
						52,
						51,
						57,
						57,
						55,
						3
					},
					new byte[]
					{
						14,
						0,
						246,
						20,
						7,
						3,
						22,
						16,
						16,
						6,
						0,
						81,
						113,
						24,
						22,
						3
					},
					new byte[]
					{
						13,
						246,
						52,
						57,
						57,
						51,
						48,
						50,
						49,
						54,
						50,
						48,
						51,
						57,
						54,
						53,
						53,
						51,
						55,
						50,
						50,
						50,
						55,
						48,
						48,
						32,
						52,
						48,
						52,
						32,
						54,
						52
					}
				};
				Thread.Sleep(2000);
				GClass126.smethod_2("Testing mode!", 1);
				this.string_1 = "26 86 9B 02 9E";
				for (int j = 0; j < this.list_1.Count; j++)
				{
					GClass104 gclass = this.list_1[j];
					if (gclass.byte_0[0][0] == 0)
					{
						gclass.method_1(this.string_1);
					}
					else
					{
						gclass.method_1(this.r4(array2[3], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_30))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				base.method_16();
				throw new Exception("1");
			}
			if (GClass125.smethod_44() == 4 || GClass125.smethod_44() == 5)
			{
				if (GClass125.smethod_44() == 5)
				{
					for (int k = 0; k < 25; k++)
					{
						if (gform9_0 != null && gform9_0.method_0())
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
				}
				GClass96.smethod_0();
				Thread.Sleep(500);
				if (GClass125.smethod_44() == 5)
				{
					for (int l = 0; l < 35; l++)
					{
						if (gform9_0 != null && gform9_0.method_0())
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
				}
			}
			try
			{
				this.serialPort_0 = new SerialPort(GClass125.smethod_55(), 4800, Parity.None, 8, StopBits.One);
				this.serialPort_0.WriteBufferSize = 2;
				this.serialPort_0.ReceivedBytesThreshold = 1000;
				this.serialPort_0.Handshake = Handshake.None;
				this.serialPort_0.Open();
				GClass126.smethod_2("Serial port opened!", 1);
			}
			catch (Exception ex)
			{
				this.string_2 = ex.Message;
				GClass126.smethod_2(ex.Message, 1);
				throw new Exception("0");
			}
			if (gform9_0 != null && gform9_0.method_0())
			{
				throw new Exception("ESC");
			}
			int m = 3;
			if (bool_5)
			{
				m = 1;
			}
			while (m > 0)
			{
				try
				{
					BitArray bitArray = new BitArray(new byte[]
					{
						this.byte_0
					});
					this.int_0 = GClass126.smethod_1();
					this.serialPort_0.ReadTimeout = 1;
					GClass126.smethod_2("5bps wake up start 71 (" + GClass127.smethod_23(this.byte_0) + ")...", 1);
					for (int n = -1; n < bitArray.Length; n++)
					{
						if (n == -1)
						{
							this.serialPort_0.RtsEnable = true;
							this.serialPort_0.BreakState = true;
						}
						else
						{
							this.serialPort_0.RtsEnable = !bitArray[n];
							this.serialPort_0.BreakState = !bitArray[n];
						}
						while (this.int_0 + 130 > GClass126.smethod_1())
						{
							Thread.Sleep(10);
						}
						while (this.int_0 + 200 > GClass126.smethod_1())
						{
						}
						this.int_0 = GClass126.smethod_1();
					}
					this.serialPort_0.RtsEnable = false;
					this.serialPort_0.BreakState = false;
					try
					{
						this.serialPort_0.ReadExisting();
					}
					catch (Exception)
					{
					}
					this.serialPort_0.ReadTimeout = this.int_7;
					this.int_0 = GClass126.smethod_1();
					GClass126.smethod_2("Waiting ECU response...", 1);
					byte b = (byte)this.serialPort_0.ReadByte();
					byte b2 = 0 + b;
					if (b != 85)
					{
						GClass126.smethod_2("ERROR: Invalid synchronization byte", 1);
						throw new Exception("Invalid synchronization byte");
					}
					byte b3 = (byte)this.serialPort_0.ReadByte();
					b2 += b3;
					byte b4 = (byte)this.serialPort_0.ReadByte();
					b2 += b4;
					byte b5 = (byte)this.serialPort_0.ReadByte();
					b2 += b5;
					byte b6 = (byte)this.serialPort_0.ReadByte();
					b2 += b6;
					byte b8;
					byte b7 = (b8 = (byte)this.serialPort_0.ReadByte()) & 127;
					b2 &= 127;
					if (b7 != b2)
					{
						GClass126.smethod_2("ERROR: Invalid checksum", 1);
						throw new Exception("Invalid checksum");
					}
					this.string_1 = GClass127.smethod_11(new byte[]
					{
						b3,
						b4,
						b5,
						b6,
						b8
					});
					GClass126.smethod_2("ECU ISO Code: " + this.string_1, 2);
					byte b9 = b4;
					b9 ^= byte.MaxValue;
					this.int_0 = GClass126.smethod_1();
					GClass126.smethod_2(this.method_28(b9), 0);
					this.byte_8 = 1;
					List<byte> list = new List<byte>();
					string text = "";
					array = this.method_29(ref text);
					GClass126.smethod_2(text, 0);
					if (array.Length != 0)
					{
						for (int num = 0; num < array.Length; num++)
						{
							list.Add(array[num]);
						}
					}
					array = this.method_24(this.byte_3);
					if (array.Length > 2)
					{
						for (int num2 = 2; num2 < array.Length; num2++)
						{
							list.Add(array[num2]);
						}
					}
					array = list.ToArray();
					this.serialPort_0.ReadTimeout = 250;
					m = 0;
				}
				catch (Exception)
				{
					this.serialPort_0.BreakState = false;
					m--;
					if (m == 0)
					{
						throw new Exception("1");
					}
					if (gform9_0 != null && gform9_0.method_0())
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(2500);
				}
			}
			GClass126.smethod_2("ECU wakeup completed", 1);
			if (bool_5)
			{
				base.method_11(false);
			}
			else
			{
				if (gform9_0 != null && gform9_0.method_0())
				{
					throw new Exception("ESC");
				}
				Thread thread = new Thread(new ThreadStart(this.method_31));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_30))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				for (int num3 = 0; num3 < this.list_1.Count; num3++)
				{
					GClass104 gclass2 = this.list_1[num3];
					if (gclass2.byte_0[0][0] == 0)
					{
						gclass2.method_1(this.string_1);
					}
					else if (gclass2.byte_0[0].Length > 2 && array.Length != 0 && gclass2.byte_0[0][0] == 3 && gclass2.byte_0[0][2] == 0)
					{
						gclass2.method_1(this.r4(array, gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
					}
					else
					{
						gclass2.method_1(this.vmethod_0(gclass2.byte_0[0], gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
					}
				}
				this.bool_0 = true;
				base.method_16();
			}
		}
		catch (Exception ex2)
		{
			if (ex2.Message == "ESC")
			{
				this.string_2 = "Aborted by user";
			}
			if (ex2.Message == "1")
			{
				this.string_2 = "No ECU response";
			}
			GClass126.smethod_2(ex2.Message, 2);
			GClass126.smethod_2("Terminate 4", 1);
			base.method_11(ex2.Message != "1" && ex2.Message != "0" && ex2.Message != "ESC");
		}
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x0000FD9C File Offset: 0x0000DF9C
	public override void r0(bool bool_5, bool bool_6)
	{
		if (this.bool_1)
		{
			return;
		}
		GClass126.smethod_2("Terminating " + (bool_5 ? "with reconnect" : ""), 1);
		if (GClass126.bool_0 && !bool_6)
		{
			return;
		}
		this.bool_1 = true;
		this.bool_0 = false;
		Thread.Sleep(500);
		if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
		{
			try
			{
				this.serialPort_0.Close();
				GClass126.smethod_2("Serial port closed!", 1);
			}
			catch (Exception ex)
			{
				GClass126.smethod_2("ERROR: Failed to close serial port: " + ex.Message, 1);
			}
			GClass126.smethod_2("-------------------------------------", 1);
			GClass126.smethod_2(" ", 1);
		}
		base.method_17(bool_6);
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x000141E4 File Offset: 0x000123E4
	public List<GClass102> method_21()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_5;
		}
		else
		{
			array = this.method_24(this.byte_6);
		}
		if (array.Length >= 2)
		{
			if (array[1] == 252 || array[1] == 9)
			{
				try
				{
					for (int i = 2; i < array.Length - 2; i += 3)
					{
						GClass102 gclass = new GClass102();
						gclass.string_0 = GClass127.smethod_11(new byte[]
						{
							array[i + 1]
						}).Replace(" ", "");
						gclass.byte_0 = array[i];
						gclass.byte_1 = array[i + 2];
						gclass.string_5 = "";
						gclass.string_6 = "";
						gclass.string_7 = "";
						gclass.string_2 = GClass127.smethod_11(new byte[]
						{
							array[i]
						}).Replace(" ", "");
						string text = GClass121.smethod_6("3099");
						if ((int)(gclass.byte_0 & 31) < this.string_5.Length)
						{
							text = this.string_5[(int)(gclass.byte_0 & 31)];
						}
						gclass.string_5 = text;
						GClass102 gclass2 = gclass;
						gclass2.string_3 = string.Concat(new string[]
						{
							gclass2.string_3,
							GClass121.smethod_6("3070"),
							" ",
							text,
							"\r\n"
						});
						string text2 = "";
						if ((gclass.byte_0 & 128) != 0)
						{
							text2 += GClass121.smethod_6("3060");
						}
						if ((gclass.byte_0 & 64) != 0)
						{
							text2 = text2 + ((text2.Length > 0) ? " / " : "") + GClass121.smethod_6("3061");
						}
						if ((gclass.byte_0 & 32) != 0)
						{
							text2 = text2 + ((text2.Length > 0) ? " / " : "") + GClass121.smethod_6("3062");
						}
						gclass.string_6 = text2;
						gclass2 = gclass;
						gclass2.string_3 = string.Concat(new string[]
						{
							gclass2.string_3,
							GClass121.smethod_6("3071"),
							" ",
							text2,
							"\r\n"
						});
						gclass2 = gclass;
						gclass2.string_3 = string.Concat(new string[]
						{
							gclass2.string_3,
							GClass121.smethod_6("3072"),
							" ",
							gclass.byte_1.ToString(),
							"\r\n"
						});
						gclass.string_7 = (gclass.byte_1.ToString() ?? "");
						list.Add(gclass);
					}
				}
				catch (Exception ex)
				{
					GClass126.smethod_2("ERROR READING DTC: " + ex.Message, 0);
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x000144D8 File Offset: 0x000126D8
	public override List<GClass102> r1()
	{
		if (this.string_0 == "MA1.7.3")
		{
			return this.method_21();
		}
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_4;
		}
		else
		{
			array = this.method_24(this.byte_6);
		}
		if (array.Length >= 2)
		{
			if (array[1] == 252 || array[1] == 9)
			{
				try
				{
					for (int i = 2; i < array.Length - 3; i += 5)
					{
						GClass102 gclass = new GClass102();
						gclass.string_0 = GClass127.smethod_11(new byte[]
						{
							array[i]
						}).Replace(" ", "");
						gclass.byte_0 = array[i + 1];
						gclass.byte_1 = array[i + 4];
						gclass.string_5 = "";
						gclass.string_6 = "";
						gclass.string_7 = "";
						gclass.string_2 = GClass127.smethod_11(new byte[]
						{
							array[i]
						}).Replace(" ", "");
						string text = GClass121.smethod_6("3099");
						if ((int)(gclass.byte_0 & 31) <= this.string_5.Length)
						{
							text = this.string_5[(int)(gclass.byte_0 & 31)];
						}
						gclass.string_5 = text;
						GClass102 gclass2 = gclass;
						gclass2.string_3 = string.Concat(new string[]
						{
							gclass2.string_3,
							GClass121.smethod_6("3070"),
							" ",
							text,
							"\r\n"
						});
						string text2 = "";
						if ((gclass.byte_0 & 128) != 0)
						{
							text2 += GClass121.smethod_6("3060");
						}
						if ((gclass.byte_0 & 64) != 0)
						{
							text2 = text2 + ((text2.Length > 0) ? " / " : "") + GClass121.smethod_6("3061");
						}
						if ((gclass.byte_0 & 32) != 0)
						{
							text2 = text2 + ((text2.Length > 0) ? " / " : "") + GClass121.smethod_6("3062");
						}
						gclass.string_6 = text2;
						gclass2 = gclass;
						gclass2.string_3 = string.Concat(new string[]
						{
							gclass2.string_3,
							GClass121.smethod_6("3071"),
							" ",
							text2,
							"\r\n"
						});
						gclass2 = gclass;
						gclass2.string_3 = string.Concat(new string[]
						{
							gclass2.string_3,
							GClass121.smethod_6("3072"),
							" ",
							gclass.byte_1.ToString(),
							"\r\n"
						});
						gclass.string_7 = (gclass.byte_1.ToString() ?? "");
						list.Add(gclass);
					}
				}
				catch (Exception ex)
				{
					GClass126.smethod_2("ERROR READING DTC: " + ex.Message, 0);
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00009148 File Offset: 0x00007348
	private string method_22(byte byte_9)
	{
		string result = "";
		if ((byte_9 & 8) != 0)
		{
			result = GClass121.smethod_6("3056");
		}
		else if ((byte_9 & 4) != 0)
		{
			result = GClass121.smethod_6("3057");
		}
		else if ((byte_9 & 2) != 0)
		{
			result = GClass121.smethod_6("3058");
		}
		else if ((byte_9 & 1) != 0)
		{
			result = GClass121.smethod_6("3059");
		}
		return result;
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x000147E8 File Offset: 0x000129E8
	public override void r2()
	{
		if (GClass126.bool_0)
		{
			this.byte_4 = new byte[]
			{
				2,
				252
			};
			return;
		}
		byte[] array = this.method_24(this.byte_7);
		if (array.Length < 2 || array[1] != 9)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x060000DA RID: 218 RVA: 0x0001483C File Offset: 0x00012A3C
	protected override void r3(GClass104 gclass104_1)
	{
		if (!GClass126.bool_0)
		{
			this.method_23(gclass104_1);
			return;
		}
		Thread.Sleep(3000);
		if (gclass104_1.string_2.Contains("FUNC"))
		{
			base.method_19(true, GClass121.smethod_6("6051"), GClass121.smethod_6("6055") + " 00");
			return;
		}
		base.method_19(false, GClass121.smethod_6("6051"), "");
	}

	// Token: 0x060000DB RID: 219 RVA: 0x000148B0 File Offset: 0x00012AB0
	private void method_23(GClass104 gclass104_1)
	{
		byte[] array = this.method_24(gclass104_1.byte_0[0]);
		if (array.Length != 0)
		{
			if (array.Length <= 1 || array[1] == 9)
			{
				if (gclass104_1.byte_0.Length > 2)
				{
					for (int i = 1; i < gclass104_1.byte_0.Length; i++)
					{
						Thread.Sleep(2000);
						this.method_24(gclass104_1.byte_0[i]);
					}
				}
				else if (gclass104_1.byte_0.Length == 2)
				{
					for (int j = 1; j < gclass104_1.byte_0.Length; j++)
					{
						Thread.Sleep(6000);
						Thread.Sleep(2000);
						this.method_24(gclass104_1.byte_0[j]);
					}
				}
				else
				{
					Thread.Sleep(9000);
				}
				base.method_19(false, GClass121.smethod_6("6051"), "");
				return;
			}
		}
		string text = "";
		base.method_19(false, GClass121.smethod_6("6052"), text);
		Thread.Sleep(1800);
	}

	// Token: 0x060000DC RID: 220 RVA: 0x000149A4 File Offset: 0x00012BA4
	public override string vmethod_0(byte[] byte_9, string string_16, int int_12, int int_13, string[] string_17, string string_18)
	{
		byte[] array = this.method_24(byte_9);
		if (array.Length == 0)
		{
			array = this.method_24(byte_9);
		}
		return this.r4(array, string_16, int_12, int_13, string_17, string_18);
	}

	// Token: 0x060000DD RID: 221 RVA: 0x000149D4 File Offset: 0x00012BD4
	private byte[] method_24(byte[] byte_9)
	{
		List<byte> list = new List<byte>();
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			byte[] array = this.method_25(byte_9);
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i]);
			}
			int num = 10;
			while (array.Length != 0 && array[1] != 9 && num > 0)
			{
				array = this.method_25(this.byte_3);
				if (array.Length > 2)
				{
					for (int j = 2; j < array.Length; j++)
					{
						list.Add(array[j]);
					}
				}
				num--;
			}
		}
		finally
		{
			this.bool_2 = false;
		}
		return list.ToArray();
	}

	// Token: 0x060000DE RID: 222 RVA: 0x00014A88 File Offset: 0x00012C88
	private byte[] method_25(byte[] byte_9)
	{
		string text = "";
		byte[] result;
		try
		{
			while (GClass126.smethod_1() < this.int_0 + this.int_10)
			{
				Thread.Sleep(1);
			}
			this.serialPort_0.ReadExisting();
			byte byte_10 = byte_9[0];
			text = this.method_28(byte_10);
			byte b = (byte)this.serialPort_0.ReadByte();
			this.int_0 = GClass126.smethod_1();
			if (b != this.method_26(byte_10))
			{
				text = text + " <ERROR: Invalid ack byte! [" + GClass127.smethod_23(b) + "]>";
			}
			byte_9[1] = this.byte_8;
			this.byte_8 += 1;
			for (int i = 1; i < byte_9.Length - 1; i++)
			{
				text += this.method_28(byte_9[i]);
				byte b2 = (byte)this.serialPort_0.ReadByte();
				this.int_0 = GClass126.smethod_1();
				if (b2 != this.method_26(byte_9[i]))
				{
					text = text + " <ERROR: Invalid ack byte! [" + GClass127.smethod_23(b2) + "]>";
				}
			}
			text += this.method_28(3);
			GClass126.smethod_2(text, 0);
			text = "";
			byte[] array = this.method_29(ref text);
			GClass126.smethod_2(text, 0);
			text = "";
			this.int_1 = 0;
			result = array;
		}
		catch (Exception ex)
		{
			if (!this.bool_1)
			{
				if (text != "")
				{
					GClass126.smethod_2(text, 0);
				}
				GClass126.smethod_2(ex.Message + "(3)", 1);
				if (this.int_1 > 3)
				{
					this.bool_2 = false;
					GClass126.smethod_2("Terminate 5", 1);
					base.method_11(true);
				}
				this.int_1++;
				this.serialPort_0.ReadTimeout = 90;
				try
				{
					for (int j = 0; j < 20; j++)
					{
						this.serialPort_0.ReadByte();
					}
				}
				catch (Exception)
				{
				}
				this.serialPort_0.ReadTimeout = 250;
			}
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x060000DF RID: 223 RVA: 0x00002EBA File Offset: 0x000010BA
	private byte method_26(byte byte_9)
	{
		return byte.MaxValue - byte_9;
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x00010BD0 File Offset: 0x0000EDD0
	private byte method_27(byte[] byte_9)
	{
		byte b = 0;
		for (int i = 0; i < byte_9.Length; i++)
		{
			b += byte_9[i];
		}
		return b;
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x0000D0C4 File Offset: 0x0000B2C4
	public override string r4(byte[] byte_9, string string_16, int int_12, int int_13, string[] string_17, string string_18)
	{
		string result = "";
		int_12++;
		if (byte_9.Length <= int_12)
		{
			return result;
		}
		int num = byte_9.Length - int_12;
		if (int_13 < num)
		{
			num = int_13;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_9[i + int_12];
		}
		return base.method_20(array, string_16, string_17, string_18);
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x00014CA4 File Offset: 0x00012EA4
	private string method_28(byte byte_9)
	{
		while (GClass126.smethod_1() < this.int_0 + this.int_8)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_9
		}, 0, 1);
		this.int_0 = GClass126.smethod_1();
		string text = this.string_6 + this.int_0.ToString() + this.string_7 + GClass127.smethod_23(byte_9);
		byte b = (byte)this.serialPort_0.ReadByte();
		int num = GClass126.smethod_1() - this.int_0;
		this.int_0 += num / 3;
		if (num > 15)
		{
			this.int_3 = 25;
		}
		if (byte_9 != b)
		{
			text = string.Concat(new string[]
			{
				text,
				this.string_6,
				this.int_0.ToString(),
				this.string_9,
				GClass127.smethod_23(b)
			});
		}
		return text;
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x00014D88 File Offset: 0x00012F88
	private byte[] method_29(ref string string_16)
	{
		byte b = (byte)this.serialPort_0.ReadByte();
		this.int_0 = GClass126.smethod_1();
		string_16 += this.method_28(this.method_26(b));
		if (b > 127)
		{
			string_16 = string_16 + " <ERROR: Invalid message length! [" + GClass127.smethod_23(b) + "]>";
			return new byte[0];
		}
		byte[] array = new byte[(int)(b - 1)];
		array[0] = b;
		b -= 2;
		byte b2 = (byte)this.serialPort_0.ReadByte();
		this.int_0 = GClass126.smethod_1();
		string_16 += this.method_28(this.method_26(b2));
		for (int i = 0; i < (int)b; i++)
		{
			array[i + 1] = (byte)this.serialPort_0.ReadByte();
			this.int_0 = GClass126.smethod_1();
			string_16 += this.method_28(this.method_26(array[i + 1]));
		}
		byte b3 = (byte)this.serialPort_0.ReadByte();
		this.int_0 = GClass126.smethod_1();
		this.int_0 = GClass126.smethod_1();
		string_16 = string.Concat(new string[]
		{
			string_16,
			this.string_6,
			this.int_0.ToString(),
			this.string_11,
			GClass127.smethod_11(array)
		});
		if (this.byte_8 != b2)
		{
			string_16 = string.Concat(new string[]
			{
				string_16,
				this.string_12,
				GClass127.smethod_23(this.byte_8),
				this.string_13,
				GClass127.smethod_23(b2),
				this.string_14
			});
			if (this.byte_8 != b2 + 1 && this.byte_8 != b2 + 2 && this.byte_8 != b2 + 3 && this.byte_8 != b2 - 1 && this.byte_8 != b2 - 2)
			{
				if (this.byte_8 != b2 - 3)
				{
					b2 = this.byte_8;
					b2 += 1;
					goto IL_1E2;
				}
			}
			this.byte_8 = b2;
		}
		IL_1E2:
		b2 += 1;
		this.byte_8 = b2;
		if (b3 != 3)
		{
			string_16 = string_16 + this.string_15 + GClass127.smethod_23(b3) + this.string_14;
		}
		return array;
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x00014FA4 File Offset: 0x000131A4
	private void method_30()
	{
		GClass126.smethod_2("PM started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(80);
			if ((this.serialPort_0 == null || !this.serialPort_0.IsOpen) && !GClass126.bool_0)
			{
				GClass126.smethod_2("PM stopped(1)", 1);
				return;
			}
			if (GClass126.smethod_1() > GClass126.int_3 + GClass126.int_5 && !this.bool_2)
			{
				GClass126.int_3 = GClass126.smethod_1();
				if (!GClass126.bool_22)
				{
					Thread.Sleep(100);
				}
				else
				{
					for (int i = 0; i < this.list_0.Count; i++)
					{
						GClass104 gclass = this.list_0[i];
						if (gclass.bool_0)
						{
							if (GClass126.bool_0)
							{
								byte[][] array = new byte[][]
								{
									new byte[]
									{
										4,
										0,
										251,
										0,
										3
									},
									new byte[]
									{
										4,
										0,
										251,
										0,
										3
									},
									new byte[]
									{
										4,
										0,
										251,
										0,
										3
									},
									new byte[]
									{
										4,
										0,
										251,
										0,
										3
									},
									new byte[]
									{
										4,
										0,
										251,
										0,
										3
									},
									new byte[]
									{
										4,
										0,
										251,
										0,
										3
									},
									new byte[]
									{
										7,
										0,
										90,
										153,
										32,
										3,
										7,
										3
									}
								};
								gclass.method_1(this.random_0.Next(0, 100).ToString() ?? "");
								if (gclass.byte_0[0].Length == 3)
								{
									if (gclass.byte_0[0][2] == 1)
									{
										gclass.method_1(this.r4(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									}
									else if (gclass.byte_0[0][2] == 2)
									{
										gclass.method_1(this.r4(array[1], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									}
									else if (gclass.byte_0[0][2] == 3)
									{
										gclass.method_1(this.r4(array[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									}
									else if (gclass.byte_0[0][2] == 4)
									{
										gclass.method_1(this.r4(array[3], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									}
									else if (gclass.byte_0[0][2] == 5)
									{
										gclass.method_1(this.r4(array[4], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									}
									else if (gclass.byte_0[0][2] == 6)
									{
										gclass.method_1(this.r4(array[5], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									}
									else
									{
										gclass.method_1(this.r4(array[5], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									}
								}
								else if (gclass.string_2.StartsWith("bit"))
								{
									gclass.method_1(this.r4(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								Thread.Sleep(this.int_9);
							}
							else
							{
								gclass.method_1(this.vmethod_0(gclass.byte_0[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								if (this.bool_1)
								{
									GClass126.smethod_2("PM stopped(2)", 1);
									return;
								}
							}
						}
					}
					if (GClass126.bool_16)
					{
						List<GClass102> list = this.r1();
						string text = "";
						for (int j = 0; j < list.Count; j++)
						{
							text = text + list[j].method_0() + " ";
						}
						this.string_4 = text;
					}
					else
					{
						this.string_4 = "";
					}
					if (GClass126.bool_12 && GClass126.list_1.Count > 0)
					{
						GClass126.smethod_0().method_2(GClass126.smethod_1());
					}
					this.bool_3 = true;
					int num = GClass126.smethod_1() - GClass126.int_3;
					if (num > GClass126.int_6)
					{
						GClass126.int_6 = num;
					}
					if (!GClass126.bool_12)
					{
						if (num < GClass126.int_6)
						{
							GClass126.int_6 = num;
						}
						GClass126.int_5 = GClass126.int_6;
					}
				}
			}
		}
		GClass126.smethod_2("PM stopped", 1);
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x00015448 File Offset: 0x00013648
	private void method_31()
	{
		GClass126.smethod_2("KA started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(20);
			if (this.serialPort_0 == null || !this.serialPort_0.IsOpen)
			{
				GClass126.smethod_2("KA stopped(1)", 1);
				return;
			}
			if (GClass126.smethod_1() > this.int_0 + this.int_11 && !this.bool_2)
			{
				byte[] array = this.method_24(this.byte_2);
				if (array.Length < 2 || array[0] != 3 || array[1] != 9)
				{
					GClass126.smethod_2("KA response error!", 1);
					if (array.Length == 0 && this.int_1 > 2)
					{
						GClass126.smethod_2("Terminate 7", 1);
						base.method_11(true);
					}
				}
			}
		}
		GClass126.smethod_2("KA stopped", 1);
	}

	// Token: 0x04000090 RID: 144
	private int int_5 = 2000;

	// Token: 0x04000091 RID: 145
	private int int_6 = 3;

	// Token: 0x04000092 RID: 146
	private int int_7 = 1000;

	// Token: 0x04000093 RID: 147
	private int int_8 = 3;

	// Token: 0x04000094 RID: 148
	private int int_9 = 41;

	// Token: 0x04000095 RID: 149
	private int int_10 = 3;

	// Token: 0x04000096 RID: 150
	private int int_11 = 420;

	// Token: 0x04000097 RID: 151
	private byte[] byte_2 = new byte[]
	{
		3,
		0,
		9,
		3
	};

	// Token: 0x04000098 RID: 152
	private byte[] byte_3 = new byte[]
	{
		3,
		0,
		9,
		3
	};

	// Token: 0x04000099 RID: 153
	private byte[] byte_4 = new byte[]
	{
		21,
		252,
		60,
		75,
		49,
		115,
		8,
		14,
		71,
		55,
		161,
		147,
		14,
		97,
		63,
		167,
		170,
		2,
		70,
		81,
		188,
		160
	};

	// Token: 0x0400009A RID: 154
	private byte[] byte_5 = new byte[]
	{
		21,
		252,
		70,
		58,
		17,
		2,
		10,
		155
	};

	// Token: 0x0400009B RID: 155
	private byte[] byte_6 = new byte[]
	{
		3,
		0,
		7,
		3
	};

	// Token: 0x0400009C RID: 156
	private byte[] byte_7 = new byte[]
	{
		3,
		0,
		5,
		3
	};

	// Token: 0x0400009D RID: 157
	private byte byte_8;

	// Token: 0x0400009E RID: 158
	private string[] string_5 = new string[]
	{
		GClass121.smethod_6("3080"),
		GClass121.smethod_6("3081"),
		GClass121.smethod_6("3082"),
		GClass121.smethod_6("3083"),
		GClass121.smethod_6("3084"),
		GClass121.smethod_6("3085"),
		GClass121.smethod_6("3086"),
		GClass121.smethod_6("3087"),
		GClass121.smethod_6("3088"),
		GClass121.smethod_6("3089"),
		GClass121.smethod_6("3090"),
		GClass121.smethod_6("3091"),
		GClass121.smethod_6("3092"),
		GClass121.smethod_6("3093"),
		GClass121.smethod_6("3094"),
		GClass121.smethod_6("3095"),
		GClass121.smethod_6("3096"),
		GClass121.smethod_6("3097"),
		GClass121.smethod_6("3098")
	};

	// Token: 0x0400009F RID: 159
	private string string_6 = " <";

	// Token: 0x040000A0 RID: 160
	private string string_7 = "> Sent: ";

	// Token: 0x040000A1 RID: 161
	private string string_8 = " <";

	// Token: 0x040000A2 RID: 162
	private string string_9 = "> ERROR: Invalid echo: ";

	// Token: 0x040000A3 RID: 163
	private string string_10 = "Invalid echo!";

	// Token: 0x040000A4 RID: 164
	private string string_11 = "> Received: ";

	// Token: 0x040000A5 RID: 165
	private string string_12 = " <ERROR: Invalid KWP71 counter! [";

	// Token: 0x040000A6 RID: 166
	private string string_13 = "!=";

	// Token: 0x040000A7 RID: 167
	private string string_14 = "]>";

	// Token: 0x040000A8 RID: 168
	private string string_15 = " <ERROR: Invalid end of message! [";
}
