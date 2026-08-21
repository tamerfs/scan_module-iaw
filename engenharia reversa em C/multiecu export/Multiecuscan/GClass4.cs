using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

// Token: 0x0200000D RID: 13
public sealed class GClass4 : GClass0
{
	// Token: 0x0600007E RID: 126 RVA: 0x0000C3F0 File Offset: 0x0000A5F0
	public GClass4(byte byte_6, List<GClass104> list_3, List<GClass104> list_4)
	{
		this.byte_0 = byte_6;
		this.list_0 = list_4;
		this.list_1 = list_3;
	}

	// Token: 0x0600007F RID: 127 RVA: 0x0000C5BC File Offset: 0x0000A7BC
	public override void vmethod_1(GForm9 gform9_0, bool bool_5)
	{
		try
		{
			for (int i = 0; i < 5; i++)
			{
				if (gform9_0 != null && gform9_0.method_0())
				{
					throw new Exception("ESC");
				}
				Thread.Sleep(100);
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
				new Thread(new ThreadStart(this.method_27))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				base.method_16();
				throw new Exception("1");
			}
			try
			{
				this.serialPort_0 = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
				this.serialPort_0.WriteBufferSize = 2;
				this.serialPort_0.ReceivedBytesThreshold = 1000;
				this.serialPort_0.Handshake = Handshake.None;
				this.serialPort_0.NewLine = "\n\r";
				this.serialPort_0.Open();
				GClass126.smethod_2("Serial port opened!", 1);
				GClass126.smethod_2("Init ELM and Wakeup ECU.", 1);
				this.serialPort_0.ReadTimeout = 3000;
				this.serialPort_0.WriteLine("ATZ");
				GClass126.smethod_2("Init ELM327 interface", 1);
				if (!this.method_26().Contains("ELM32"))
				{
					GClass126.smethod_2("Invalid ELM interface!", 1);
				}
				this.serialPort_0.ReadTimeout = 1000;
				this.method_25("ATE0");
				this.method_25("ATL0");
				this.method_25("ATSP4");
				this.method_25("ATIB48");
				this.method_25("ATIIA " + GClass127.smethod_23(this.byte_0));
				this.method_25("ATH0");
				Thread.Sleep(100);
				this.method_25("ATKW0");
				Thread.Sleep(100);
				this.method_25("ATSI");
				Thread.Sleep(100);
				this.method_25("ATKW");
				this.method_25("ATBD");
				if (!this.method_25("00").Contains("OK"))
				{
					throw new Exception("Connection failed!");
				}
			}
			catch (Exception ex)
			{
				GClass126.smethod_2(ex.Message, 1);
				throw new Exception("0");
			}
			GClass126.smethod_2("ECU wakeup completed", 1);
			if (gform9_0 != null && gform9_0.method_0())
			{
				throw new Exception("ESC");
			}
			Thread thread = new Thread(new ThreadStart(this.method_28));
			thread.Priority = ThreadPriority.Highest;
			this.bool_1 = false;
			thread.Start();
			new Thread(new ThreadStart(this.method_27))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			for (int k = 0; k < this.list_1.Count; k++)
			{
				GClass104 gclass2 = this.list_1[k];
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
		catch (Exception ex2)
		{
			GClass126.smethod_2(ex2.Message, 2);
			GClass126.smethod_2("Terminate 4", 1);
			base.method_11(ex2.Message != "0");
		}
	}

	// Token: 0x06000080 RID: 128 RVA: 0x0000CA08 File Offset: 0x0000AC08
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
				this.method_25("ATPC");
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

	// Token: 0x06000081 RID: 129 RVA: 0x0000CAE0 File Offset: 0x0000ACE0
	public override List<GClass102> r1()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_3;
		}
		else
		{
			array = this.method_24(this.byte_4);
		}
		if (array.Length >= 2)
		{
			if (array[1] == 252)
			{
				for (int i = 2; i < array.Length - 1; i += 5)
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
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x06000082 RID: 130 RVA: 0x00009148 File Offset: 0x00007348
	private string method_21(byte byte_6)
	{
		string result = "";
		if ((byte_6 & 8) != 0)
		{
			result = GClass121.smethod_6("3056");
		}
		else if ((byte_6 & 4) != 0)
		{
			result = GClass121.smethod_6("3057");
		}
		else if ((byte_6 & 2) != 0)
		{
			result = GClass121.smethod_6("3058");
		}
		else if ((byte_6 & 1) != 0)
		{
			result = GClass121.smethod_6("3059");
		}
		return result;
	}

	// Token: 0x06000083 RID: 131 RVA: 0x0000CD94 File Offset: 0x0000AF94
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
		byte[] array = this.method_24(this.byte_5);
		if (array.Length < 2 || array[1] != 9)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x06000084 RID: 132 RVA: 0x0000CDE8 File Offset: 0x0000AFE8
	protected override void r3(GClass104 gclass104_1)
	{
		if (!GClass126.bool_0)
		{
			this.method_22(gclass104_1);
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

	// Token: 0x06000085 RID: 133 RVA: 0x0000CE5C File Offset: 0x0000B05C
	private void method_22(GClass104 gclass104_1)
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
		string string_ = "";
		base.method_19(false, GClass121.smethod_6("6052"), string_);
		Thread.Sleep(1800);
	}

	// Token: 0x06000086 RID: 134 RVA: 0x0000CF50 File Offset: 0x0000B150
	public override string vmethod_0(byte[] byte_6, string string_6, int int_12, int int_13, string[] string_7, string string_8)
	{
		byte[] array = this.method_24(byte_6);
		return this.r4(array, string_6, int_12, int_13, string_7, string_8);
	}

	// Token: 0x06000087 RID: 135 RVA: 0x0000CF74 File Offset: 0x0000B174
	private byte[] method_23(byte[] byte_6)
	{
		byte[] array = new byte[byte_6.Length - 1];
		for (int i = 1; i < byte_6.Length; i++)
		{
			array[i - 1] = byte_6[i];
		}
		this.serialPort_0.WriteLine(GClass127.smethod_11(array));
		GClass126.smethod_2("Send: " + GClass127.smethod_11(array), 0);
		string text = this.method_26();
		int num = 0;
		while (num < text.Length && text[num] != '\r' && text[num] != '\n')
		{
			if (text[num] == '>')
			{
				break;
			}
			num++;
		}
		return GClass127.smethod_32("00" + text.Substring(0, num));
	}

	// Token: 0x06000088 RID: 136 RVA: 0x0000D01C File Offset: 0x0000B21C
	private byte[] method_24(byte[] byte_6)
	{
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			this.int_0 = GClass126.smethod_1();
			byte[] array = this.method_23(byte_6);
			this.int_0 = GClass126.smethod_1();
			this.bool_2 = false;
			result = array;
		}
		catch (Exception ex)
		{
			if (!this.bool_1)
			{
				GClass126.smethod_2(ex.Message + "(3)", 1);
				this.bool_2 = false;
				GClass126.smethod_2("Terminate 5", 1);
				base.method_11(true);
			}
			this.bool_2 = false;
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x06000089 RID: 137 RVA: 0x0000D0C4 File Offset: 0x0000B2C4
	public override string r4(byte[] byte_6, string string_6, int int_12, int int_13, string[] string_7, string string_8)
	{
		string result = "";
		int_12++;
		if (byte_6.Length <= int_12)
		{
			return result;
		}
		int num = byte_6.Length - int_12;
		if (int_13 < num)
		{
			num = int_13;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_6[i + int_12];
		}
		return base.method_20(array, string_6, string_7, string_8);
	}

	// Token: 0x0600008A RID: 138 RVA: 0x0000D120 File Offset: 0x0000B320
	private string method_25(string string_6)
	{
		this.serialPort_0.WriteLine(string_6);
		GClass126.smethod_2("Command: " + string_6, 0);
		string text = this.method_26();
		GClass126.smethod_2("Response: " + text, 0);
		if (!text.Contains("OK"))
		{
			GClass126.smethod_2("[" + string_6 + "] failed!", 0);
		}
		return text;
	}

	// Token: 0x0600008B RID: 139 RVA: 0x00007D98 File Offset: 0x00005F98
	private string method_26()
	{
		string text = "";
		while (!text.EndsWith(">"))
		{
			text += ((char)this.serialPort_0.ReadByte()).ToString();
		}
		GClass126.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x0600008C RID: 140 RVA: 0x0000D188 File Offset: 0x0000B388
	private void method_27()
	{
		GClass126.smethod_2("PM started", 1);
		GClass126.int_3 = 0;
		while (!this.bool_1)
		{
			Thread.Sleep(50);
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

	// Token: 0x0600008D RID: 141 RVA: 0x0000D634 File Offset: 0x0000B834
	private void method_28()
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
				if (array.Length < 2 || array[1] != 9)
				{
					GClass126.smethod_2("KA response error!", 1);
					if (array.Length == 0 && this.int_1 > 1)
					{
						GClass126.smethod_2("Terminate 7", 1);
						base.method_11(true);
					}
				}
			}
		}
		GClass126.smethod_2("KA stopped", 1);
	}

	// Token: 0x04000051 RID: 81
	private int int_5 = 2000;

	// Token: 0x04000052 RID: 82
	private int int_6 = 3;

	// Token: 0x04000053 RID: 83
	private int int_7 = 1000;

	// Token: 0x04000054 RID: 84
	private int int_8 = 3;

	// Token: 0x04000055 RID: 85
	private int int_9 = 40;

	// Token: 0x04000056 RID: 86
	private int int_10 = 3;

	// Token: 0x04000057 RID: 87
	private int int_11 = 350;

	// Token: 0x04000058 RID: 88
	private byte[] byte_2 = new byte[]
	{
		2,
		9
	};

	// Token: 0x04000059 RID: 89
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

	// Token: 0x0400005A RID: 90
	private byte[] byte_4 = new byte[]
	{
		2,
		7
	};

	// Token: 0x0400005B RID: 91
	private byte[] byte_5 = new byte[]
	{
		2,
		5
	};

	// Token: 0x0400005C RID: 92
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
}
