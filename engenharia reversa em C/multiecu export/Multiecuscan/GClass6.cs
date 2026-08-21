using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

// Token: 0x0200000F RID: 15
public sealed class GClass6 : GClass0
{
	// Token: 0x060000A3 RID: 163 RVA: 0x0000F024 File Offset: 0x0000D224
	public GClass6(byte byte_9, List<GClass104> list_3, List<GClass104> list_4)
	{
		this.byte_0 = byte_9;
		this.list_0 = list_4;
		this.list_1 = list_3;
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x0000F308 File Offset: 0x0000D508
	public override void vmethod_1(GForm9 gform9_0, bool bool_5)
	{
		try
		{
			this.int_1 = 0;
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
				byte[][] array = new byte[][]
				{
					new byte[]
					{
						26,
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
						54
					},
					new byte[]
					{
						26,
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
						69
					},
					new byte[]
					{
						14,
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
						78
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
						gclass.method_1(this.r4(array[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_34))
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
			int m = 4;
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
					GClass126.smethod_2("5bps wake up start (" + GClass127.smethod_23(this.byte_0) + ")...", 1);
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
					GClass126.smethod_2(this.method_30(b9), 0);
					if (m == 1)
					{
						byte b10 = (byte)this.serialPort_0.ReadByte();
						GClass126.smethod_2("Response: " + GClass127.smethod_23(b10), 0);
					}
					else
					{
						this.method_33();
					}
					this.serialPort_0.ReadTimeout = 350;
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
				Thread thread = new Thread(new ThreadStart(this.method_35));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_34))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				for (int num = 0; num < this.list_1.Count; num++)
				{
					GClass104 gclass2 = this.list_1[num];
					if (gclass2.byte_0[0][0] == 0)
					{
						gclass2.method_1(this.string_1);
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

	// Token: 0x060000A5 RID: 165 RVA: 0x00002EB2 File Offset: 0x000010B2
	private bool method_21()
	{
		return this.method_22();
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x0000FA94 File Offset: 0x0000DC94
	private bool method_22()
	{
		this.int_12++;
		if (this.int_12 > 5)
		{
			return false;
		}
		for (int i = 0; i < 18; i++)
		{
			if (this.bool_1)
			{
				return false;
			}
			Thread.Sleep(100);
		}
		bool result;
		try
		{
			BitArray bitArray = new BitArray(new byte[]
			{
				this.byte_0
			});
			this.int_0 = GClass126.smethod_1();
			this.serialPort_0.ReadTimeout = 1;
			GClass126.smethod_2("5bps wake up start (" + GClass127.smethod_23(this.byte_0) + ")...", 1);
			for (int j = -1; j < bitArray.Length; j++)
			{
				if (j == -1)
				{
					this.serialPort_0.RtsEnable = true;
					this.serialPort_0.BreakState = true;
				}
				else
				{
					this.serialPort_0.RtsEnable = !bitArray[j];
					this.serialPort_0.BreakState = !bitArray[j];
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
			byte b9 = b4;
			b9 ^= byte.MaxValue;
			this.int_0 = GClass126.smethod_1();
			GClass126.smethod_2(this.method_30(b9), 0);
			this.method_33();
			this.serialPort_0.ReadTimeout = 350;
			return true;
		}
		catch (Exception)
		{
			try
			{
				this.serialPort_0.BreakState = false;
			}
			catch (Exception)
			{
			}
			result = false;
		}
		return result;
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x0000FD9C File Offset: 0x0000DF9C
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

	// Token: 0x060000A8 RID: 168 RVA: 0x0000FE68 File Offset: 0x0000E068
	public List<GClass102> method_23()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_4;
		}
		else
		{
			array = this.method_27(this.byte_6);
		}
		if (array.Length >= 18)
		{
			if (array[1] == 252)
			{
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						if ((array[2 + i] & this.byte_8[j]) != 0 || (array[10 + i] & this.byte_8[j]) != 0)
						{
							try
							{
								GClass102 gclass = new GClass102();
								byte b = (byte)(i * 8 + (j + 1));
								gclass.string_0 = GClass127.smethod_23(b);
								gclass.byte_0 = (((array[10 + i] & this.byte_8[j]) > 0) ? 1 : 0);
								GClass102 gclass2 = gclass;
								gclass2.byte_0 += (((array[2 + i] & this.byte_8[j]) != 0) ? 10 : 0);
								gclass.byte_1 = 32;
								gclass.string_5 = "";
								gclass.string_6 = "";
								gclass.string_7 = "";
								gclass.string_2 = "";
								string text = "";
								if (gclass.byte_0 == 1)
								{
									text = GClass121.smethod_6("3062");
								}
								else if (gclass.byte_0 == 10)
								{
									text = GClass121.smethod_6("3053");
								}
								else if (gclass.byte_0 == 11)
								{
									text = GClass121.smethod_6("3062") + "/" + GClass121.smethod_6("3053");
								}
								string str = "";
								if (gclass.byte_0 == 1)
								{
									str = GClass121.smethod_6("3077");
								}
								else if (gclass.byte_0 == 10)
								{
									str = GClass121.smethod_6("3076");
								}
								else if (gclass.byte_0 == 11)
								{
									str = GClass121.smethod_6("3078");
								}
								gclass.string_6 = text;
								GClass102 gclass3 = gclass;
								gclass3.string_3 = gclass3.string_3 + str + "\r\n";
								list.Add(gclass);
								goto IL_1FF;
							}
							catch (Exception)
							{
								GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
								goto IL_1FF;
							}
							break;
						}
						IL_1FF:;
					}
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x000100A8 File Offset: 0x0000E2A8
	public List<GClass102> method_24()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array = this.byte_3;
		int num = 10;
		while (array.Length > 3 && num > 0)
		{
			if (GClass126.bool_0)
			{
				array = this.byte_3;
			}
			else
			{
				array = this.method_27(this.byte_6);
			}
			if (array.Length < 2 && num == 10)
			{
				GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
				return null;
			}
			for (int i = 2; i < array.Length - 5; i += 5)
			{
				try
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
					bool flag = false;
					using (List<GClass102>.Enumerator enumerator = list.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current.string_0 == gclass.string_0)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						list.Add(gclass);
					}
					goto IL_31B;
				}
				catch (Exception)
				{
					GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
					goto IL_31B;
				}
				break;
				IL_31B:;
			}
			num--;
		}
		return list;
	}

	// Token: 0x060000AA RID: 170 RVA: 0x0001041C File Offset: 0x0000E61C
	public override List<GClass102> r1()
	{
		if (this.string_0 == "ABSTEVES")
		{
			return this.method_23();
		}
		if (this.string_0 == "HTCHI")
		{
			return this.method_24();
		}
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0 && this.string_0 == "TD100")
		{
			array = this.byte_5;
		}
		else if (GClass126.bool_0)
		{
			array = this.byte_3;
		}
		else
		{
			array = this.method_27(this.byte_6);
		}
		if (array.Length >= 2)
		{
			if (array[1] == 252)
			{
				int i = 2;
				while (i < array.Length - 4)
				{
					try
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
						goto IL_2FD;
					}
					catch (Exception)
					{
						GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
						goto IL_2FD;
					}
					IL_2F4:
					i++;
					continue;
					IL_2FD:
					i += 5;
					if (this.string_0 == "TD100")
					{
						goto IL_2F4;
					}
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x060000AB RID: 171 RVA: 0x00009148 File Offset: 0x00007348
	private string method_25(byte byte_9)
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

	// Token: 0x060000AC RID: 172 RVA: 0x0001076C File Offset: 0x0000E96C
	public override void r2()
	{
		if (GClass126.bool_0)
		{
			this.byte_3 = new byte[]
			{
				2,
				252
			};
			return;
		}
		byte[] array = this.method_27(this.byte_7);
		if (array.Length < 2 || array[1] != 9)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x060000AD RID: 173 RVA: 0x000107C0 File Offset: 0x0000E9C0
	protected override void r3(GClass104 gclass104_1)
	{
		if (!GClass126.bool_0)
		{
			this.method_26(gclass104_1);
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

	// Token: 0x060000AE RID: 174 RVA: 0x00010834 File Offset: 0x0000EA34
	private void method_26(GClass104 gclass104_1)
	{
		byte[] array = this.method_27(gclass104_1.byte_0[0]);
		if (array.Length != 0)
		{
			if (array.Length <= 1 || array[1] == 9)
			{
				if (gclass104_1.byte_0.Length > 2)
				{
					for (int i = 1; i < gclass104_1.byte_0.Length; i++)
					{
						Thread.Sleep(2000);
						this.method_27(gclass104_1.byte_0[i]);
					}
				}
				else if (gclass104_1.byte_0.Length == 2)
				{
					for (int j = 1; j < gclass104_1.byte_0.Length; j++)
					{
						Thread.Sleep(6000);
						Thread.Sleep(2000);
						this.method_27(gclass104_1.byte_0[j]);
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

	// Token: 0x060000AF RID: 175 RVA: 0x00010928 File Offset: 0x0000EB28
	public override string vmethod_0(byte[] byte_9, string string_12, int int_13, int int_14, string[] string_13, string string_14)
	{
		byte[] array = this.method_27(byte_9);
		if (array.Length == 0)
		{
			array = this.method_27(byte_9);
		}
		return this.r4(array, string_12, int_13, int_14, string_13, string_14);
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x00010958 File Offset: 0x0000EB58
	private byte[] method_27(byte[] byte_9)
	{
		List<byte> list = new List<byte>();
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			byte[] array = this.method_28(byte_9);
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i]);
			}
			int num = 10;
			while (array.Length != 0 && array[1] != 9 && num > 0)
			{
				array = this.method_28(this.byte_2);
				if (array.Length > 2)
				{
					for (int j = 2; j < array.Length; j++)
					{
						list.Add(array[j]);
					}
				}
				num--;
			}
			if (array.Length == 0)
			{
				array = this.method_28(this.byte_2);
				list.Clear();
			}
		}
		finally
		{
			this.bool_2 = false;
		}
		return list.ToArray();
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x00010A20 File Offset: 0x0000EC20
	private byte[] method_28(byte[] byte_9)
	{
		string text = "";
		byte[] result;
		try
		{
			byte b = 0;
			while (GClass126.smethod_1() < this.int_0 + this.int_10)
			{
				Thread.Sleep(1);
			}
			this.serialPort_0.ReadExisting();
			byte b2 = byte_9[0];
			text = this.method_31(b2);
			b += b2;
			byte[] array = new byte[byte_9.Length + 1];
			array[0] = byte_9[0];
			for (int i = 1; i < byte_9.Length; i++)
			{
				text += this.method_31(byte_9[i]);
				b += byte_9[i];
				array[i] = byte_9[i];
			}
			text += this.method_31(b);
			array[byte_9.Length] = b;
			GClass126.smethod_2(text, 0);
			text = "";
			this.method_32(array);
			byte[] array2 = this.method_33();
			this.int_1 = 0;
			result = array2;
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
				if (this.int_1 > 1)
				{
					if (!this.method_21())
					{
						this.bool_2 = false;
						GClass126.smethod_2("Terminate 5", 1);
						base.method_11(true);
					}
					else
					{
						this.int_1 = 2;
					}
				}
				else
				{
					this.int_1++;
					this.serialPort_0.ReadTimeout = 100;
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
					this.serialPort_0.ReadTimeout = 350;
				}
			}
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x00010BD0 File Offset: 0x0000EDD0
	private byte method_29(byte[] byte_9)
	{
		byte b = 0;
		for (int i = 0; i < byte_9.Length; i++)
		{
			b += byte_9[i];
		}
		return b;
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x0000D0C4 File Offset: 0x0000B2C4
	public override string r4(byte[] byte_9, string string_12, int int_13, int int_14, string[] string_13, string string_14)
	{
		string result = "";
		int_13++;
		if (byte_9.Length <= int_13)
		{
			return result;
		}
		int num = byte_9.Length - int_13;
		if (int_14 < num)
		{
			num = int_14;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_9[i + int_13];
		}
		return base.method_20(array, string_12, string_13, string_14);
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x00010BF8 File Offset: 0x0000EDF8
	private string method_30(byte byte_9)
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
			throw new Exception(this.string_10);
		}
		return text;
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x00010CE8 File Offset: 0x0000EEE8
	private string method_31(byte byte_9)
	{
		if (!GClass125.smethod_65())
		{
			return this.method_30(byte_9);
		}
		while (GClass126.smethod_1() < this.int_0 + this.int_8)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_9
		}, 0, 1);
		this.int_0 = GClass126.smethod_1() + 1;
		return this.string_6 + this.int_0.ToString() + this.string_7 + GClass127.smethod_23(byte_9);
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x00010D60 File Offset: 0x0000EF60
	private void method_32(byte[] byte_9)
	{
		if (!GClass125.smethod_65())
		{
			return;
		}
		bool flag = true;
		for (int i = 0; i < byte_9.Length; i++)
		{
			byte b = (byte)this.serialPort_0.ReadByte();
			if (byte_9[i] != b)
			{
				GClass126.smethod_2("ERROR: Invalid echo: " + GClass127.smethod_23(byte_9[i]) + "->" + GClass127.smethod_23(b), 0);
				flag = false;
			}
		}
		if (this.int_0 + 25 < GClass126.smethod_1())
		{
			this.int_3 = 25;
		}
		if (!flag)
		{
			throw new Exception("Invalid echo!");
		}
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x00010DE4 File Offset: 0x0000EFE4
	private byte[] method_33()
	{
		byte b = (byte)this.serialPort_0.ReadByte();
		byte b2 = 0 + b;
		byte[] array = new byte[(int)b];
		array[0] = b;
		b -= 1;
		if (b == 0)
		{
			return array;
		}
		for (int i = 0; i < (int)b; i++)
		{
			array[i + 1] = (byte)this.serialPort_0.ReadByte();
			b2 += array[i + 1];
		}
		byte b3 = (byte)this.serialPort_0.ReadByte();
		this.int_0 = GClass126.smethod_1();
		GClass126.smethod_2(this.string_11 + GClass127.smethod_11(array), 0);
		if (b2 != b3)
		{
			GClass126.smethod_2("ERROR: Invalid response checksum! [" + GClass127.smethod_23(b3) + "]", 0);
			throw new Exception("Invalid response checksum! [" + GClass127.smethod_23(b3) + "]");
		}
		return array;
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00010EB0 File Offset: 0x0000F0B0
	private void method_34()
	{
		GClass126.smethod_2("PM started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(60);
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
										251,
										0,
										145
									},
									new byte[]
									{
										4,
										251,
										0,
										198
									},
									new byte[]
									{
										4,
										251,
										0,
										15
									},
									new byte[]
									{
										4,
										251,
										0,
										92
									},
									new byte[]
									{
										4,
										251,
										0,
										229
									},
									new byte[]
									{
										4,
										251,
										0,
										128
									},
									new byte[]
									{
										6,
										90,
										153,
										32,
										3,
										7,
										19
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

	// Token: 0x060000B9 RID: 185 RVA: 0x00011354 File Offset: 0x0000F554
	private void method_35()
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
				byte[] array = this.method_27(this.byte_2);
				if (array.Length < 2 || array[0] != 2 || array[1] != 9)
				{
					array = this.method_27(this.byte_2);
					if (array.Length < 2 || array[0] != 2 || array[1] != 9)
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
		}
		GClass126.smethod_2("KA stopped", 1);
	}

	// Token: 0x04000062 RID: 98
	private int int_5 = 2000;

	// Token: 0x04000063 RID: 99
	private int int_6 = 3;

	// Token: 0x04000064 RID: 100
	private int int_7 = 1000;

	// Token: 0x04000065 RID: 101
	private int int_8 = 3;

	// Token: 0x04000066 RID: 102
	private int int_9 = 41;

	// Token: 0x04000067 RID: 103
	private int int_10 = 3;

	// Token: 0x04000068 RID: 104
	private int int_11 = 400;

	// Token: 0x04000069 RID: 105
	private byte[] byte_2 = new byte[]
	{
		2,
		9
	};

	// Token: 0x0400006A RID: 106
	private byte[] byte_3 = new byte[]
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

	// Token: 0x0400006B RID: 107
	private byte[] byte_4 = new byte[]
	{
		10,
		252,
		0,
		0,
		1,
		0,
		0,
		0,
		0,
		1,
		0,
		0,
		1,
		0,
		0,
		0,
		128,
		0,
		0,
		0,
		31,
		0,
		0,
		0,
		0
	};

	// Token: 0x0400006C RID: 108
	private byte[] byte_5 = new byte[]
	{
		8,
		252,
		6,
		6,
		54,
		0,
		0,
		65,
		13,
		2,
		85,
		0,
		0,
		64,
		18,
		108,
		183,
		1,
		64,
		64
	};

	// Token: 0x0400006D RID: 109
	private byte[] byte_6 = new byte[]
	{
		2,
		7
	};

	// Token: 0x0400006E RID: 110
	private byte[] byte_7 = new byte[]
	{
		2,
		5
	};

	// Token: 0x0400006F RID: 111
	private int int_12;

	// Token: 0x04000070 RID: 112
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
		GClass121.smethod_6("3098"),
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		""
	};

	// Token: 0x04000071 RID: 113
	private byte[] byte_8 = new byte[]
	{
		1,
		2,
		4,
		8,
		16,
		32,
		64,
		128
	};

	// Token: 0x04000072 RID: 114
	private string string_6 = " <";

	// Token: 0x04000073 RID: 115
	private string string_7 = "> Sent: ";

	// Token: 0x04000074 RID: 116
	private string string_8 = " <";

	// Token: 0x04000075 RID: 117
	private string string_9 = "> ERROR: Invalid echo: ";

	// Token: 0x04000076 RID: 118
	private string string_10 = "Invalid echo!";

	// Token: 0x04000077 RID: 119
	private string string_11 = "Received: ";
}
