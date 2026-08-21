using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

// Token: 0x0200004D RID: 77
public sealed class GClass88 : GClass11
{
	// Token: 0x060002DC RID: 732 RVA: 0x00047D70 File Offset: 0x00045F70
	public GClass88(byte byte_7, List<GClass104> list_6, List<GClass104> list_7)
	{
		this.byte_0 = byte_7;
		this.list_0 = list_7;
		this.list_1 = list_6;
	}

	// Token: 0x060002DD RID: 733 RVA: 0x00047F3C File Offset: 0x0004613C
	public override void vmethod_1()
	{
		try
		{
			if (this.genum0_0 == (GEnum0)0)
			{
				for (int i = 0; i < 5; i++)
				{
					if (GClass126.bool_25)
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
				this.string_7 = "26 86 9B 02 9E";
				for (int j = 0; j < this.list_1.Count; j++)
				{
					GClass104 gclass = this.list_1[j];
					if (gclass.byte_0[0][0] == 0)
					{
						gclass.method_1(this.r4(GClass127.smethod_32("00 00 " + this.string_7), gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					}
					else
					{
						gclass.method_1(this.r4(array[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_51))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				base.method_36();
				throw new Exception("1");
			}
			try
			{
				this.serialPort_0 = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
				this.serialPort_0.WriteBufferSize = 2;
				this.serialPort_0.WriteTimeout = 5000;
				this.serialPort_0.ReceivedBytesThreshold = 1000;
				this.serialPort_0.Handshake = Handshake.None;
				this.serialPort_0.NewLine = "\n\r";
				this.serialPort_0.Open();
				GClass126.smethod_2("Serial port opened!", 1);
				GClass126.smethod_2("Init ELM and Wakeup ECU.", 1);
				this.serialPort_0.ReadTimeout = 3000;
				this.serialPort_0.WriteLine("ATZ");
				GClass126.smethod_2("Init ELM327 interface", 1);
				if (!this.method_50().Contains("ELM32"))
				{
					GClass126.smethod_2("Invalid ELM interface!", 1);
				}
				this.serialPort_0.ReadTimeout = 1000;
				this.method_49("ATE0");
				this.method_49("ATL0");
				this.method_49("ATSP4");
				this.method_49("STIBR4800");
				this.method_49("STIMCS1");
				this.method_49("ATKW0");
				this.method_49("ATIIA " + GClass127.smethod_23(this.byte_0));
				Thread.Sleep(100);
				Thread.Sleep(100);
				this.method_49("ATSH 010000");
				this.method_49("ATSI");
				string text = this.method_49("ATKW");
				Thread.Sleep(100);
				this.method_49("00 02");
				Thread.Sleep(100);
				this.string_7 = text.Replace("1:", "").Replace("2:", "").Replace("3:", "").Replace("4:", "").Replace("5:", "").Replace(">", "").Replace("\r", "").Replace("\n", "");
				try
				{
					this.string_7 = GClass127.smethod_11(GClass127.smethod_32(this.string_7));
				}
				catch (Exception)
				{
				}
				GClass126.smethod_2("ECU ISO Code: " + this.string_7, 0);
			}
			catch (Exception ex)
			{
				GClass126.smethod_2(ex.Message, 1);
				throw new Exception("0");
			}
			GClass126.smethod_2("ECU wakeup completed", 1);
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			if (this.genum0_0 == (GEnum0)0)
			{
				Thread thread = new Thread(new ThreadStart(this.method_52));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_51))
				{
					Priority = ThreadPriority.Highest
				}.Start();
			}
			for (int k = 0; k < this.list_1.Count; k++)
			{
				GClass104 gclass2 = this.list_1[k];
				if (gclass2.byte_0[0][0] == 0)
				{
					gclass2.method_1(this.r4(GClass127.smethod_32("00 00 " + this.string_7), gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
				}
				else
				{
					gclass2.method_1(this.vmethod_0(gclass2.byte_0[0], gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
				}
			}
			if (this.genum0_0 != (GEnum0)0)
			{
				base.method_30(false);
			}
			else
			{
				this.bool_0 = true;
				base.method_36();
			}
		}
		catch (Exception ex2)
		{
			if (ex2.Message != "0" && ex2.Message != "1")
			{
				GClass126.smethod_2(ex2.Message, 2);
			}
			GClass126.smethod_2("Terminate 4", 1);
			base.method_30(ex2.Message != "0");
		}
	}

	// Token: 0x060002DE RID: 734 RVA: 0x00048504 File Offset: 0x00046704
	public override void r0(bool bool_6, bool bool_7)
	{
		if (this.bool_1)
		{
			return;
		}
		GClass126.smethod_2("Terminating " + (bool_6 ? "with reconnect" : ""), 1);
		if (GClass126.bool_0 && !bool_7)
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
				this.method_49("ATPC");
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
		base.method_32(bool_7);
	}

	// Token: 0x060002DF RID: 735 RVA: 0x000485DC File Offset: 0x000467DC
	public override List<GClass102> r1()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_4;
		}
		else
		{
			array = this.method_48(this.byte_5);
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
					if ((int)(gclass.byte_0 & 31) <= this.string_22.Length)
					{
						text = this.string_22[(int)(gclass.byte_0 & 31)];
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

	// Token: 0x060002E0 RID: 736 RVA: 0x00009148 File Offset: 0x00007348
	private string method_45(byte byte_7)
	{
		string result = "";
		if ((byte_7 & 8) != 0)
		{
			result = GClass121.smethod_6("3056");
		}
		else if ((byte_7 & 4) != 0)
		{
			result = GClass121.smethod_6("3057");
		}
		else if ((byte_7 & 2) != 0)
		{
			result = GClass121.smethod_6("3058");
		}
		else if ((byte_7 & 1) != 0)
		{
			result = GClass121.smethod_6("3059");
		}
		return result;
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x00048890 File Offset: 0x00046A90
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
		byte[] array = this.method_48(this.byte_6);
		if (array.Length < 2 || array[1] != 9)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x060002E2 RID: 738 RVA: 0x000488E4 File Offset: 0x00046AE4
	protected override void r3(GClass104 gclass104_1)
	{
		if (!GClass126.bool_0)
		{
			this.method_46(gclass104_1);
			return;
		}
		if (!gclass104_1.string_2.Contains("NOWAIT"))
		{
			Thread.Sleep(3000);
		}
		if (gclass104_1.string_2.Contains("FUNC"))
		{
			base.method_28(true, GClass121.smethod_6("6051"), GClass121.smethod_6("6055") + " 00");
			return;
		}
		base.method_28(false, GClass121.smethod_6("6051"), "");
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x0004896C File Offset: 0x00046B6C
	private void method_46(GClass104 gclass104_1)
	{
		byte[] array = this.method_48(gclass104_1.byte_0[0]);
		if (array.Length != 0)
		{
			if (array.Length <= 1 || array[1] == 9)
			{
				if (gclass104_1.byte_0.Length > 2)
				{
					for (int i = 1; i < gclass104_1.byte_0.Length; i++)
					{
						Thread.Sleep(2000);
						this.method_48(gclass104_1.byte_0[i]);
					}
				}
				else if (gclass104_1.byte_0.Length == 2)
				{
					for (int j = 1; j < gclass104_1.byte_0.Length; j++)
					{
						Thread.Sleep(6000);
						Thread.Sleep(2000);
						this.method_48(gclass104_1.byte_0[j]);
					}
				}
				else
				{
					Thread.Sleep(9000);
				}
				base.method_28(false, GClass121.smethod_6("6051"), "");
				return;
			}
		}
		string string_ = "";
		base.method_28(false, GClass121.smethod_6("6052"), string_);
		Thread.Sleep(1800);
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x00048A60 File Offset: 0x00046C60
	public override string vmethod_0(byte[] byte_7, string string_23, int int_12, int int_13, string[] string_24, string string_25)
	{
		byte[] array = this.method_48(byte_7);
		return this.r4(array, string_23, int_12, int_13, string_24, string_25);
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x00048A84 File Offset: 0x00046C84
	private byte[] method_47(byte[] byte_7)
	{
		byte[] array = new byte[byte_7.Length];
		byte b = 0;
		for (int i = 0; i < byte_7.Length; i++)
		{
			if (i > 0)
			{
				array[i - 1] = byte_7[i];
			}
			b += byte_7[i];
		}
		array[array.Length - 1] = b;
		this.serialPort_0.WriteLine(GClass127.smethod_11(array));
		GClass126.smethod_2("Send: " + GClass127.smethod_11(array), 0);
		string text = this.method_50();
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

	// Token: 0x060002E6 RID: 742 RVA: 0x00048B48 File Offset: 0x00046D48
	private byte[] method_48(byte[] byte_7)
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
			byte[] array = this.method_47(byte_7);
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
				base.method_30(true);
			}
			this.bool_2 = false;
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x000325E4 File Offset: 0x000307E4
	public override string r4(byte[] byte_7, string string_23, int int_12, int int_13, string[] string_24, string string_25)
	{
		string result = "";
		int_12++;
		if (byte_7.Length <= int_12)
		{
			return result;
		}
		int num = byte_7.Length - int_12;
		if (int_13 < num)
		{
			num = int_13;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_7[i + int_12];
		}
		return base.method_33(array, string_23, string_24, string_25);
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x00048BF0 File Offset: 0x00046DF0
	private string method_49(string string_23)
	{
		this.serialPort_0.WriteLine(string_23);
		GClass126.smethod_2("Command: " + string_23, 0);
		string text = this.method_50();
		GClass126.smethod_2("Response: " + text, 0);
		if (!text.Contains("OK"))
		{
			GClass126.smethod_2("[" + string_23 + "] failed!", 0);
		}
		return text;
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x00048C58 File Offset: 0x00046E58
	private string method_50()
	{
		string text = "";
		while (!text.EndsWith(">"))
		{
			text += ((char)this.serialPort_0.ReadByte()).ToString();
		}
		GClass126.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x060002EA RID: 746 RVA: 0x00048CA8 File Offset: 0x00046EA8
	private void method_51()
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
						if (list != null)
						{
							string text = "";
							for (int j = 0; j < list.Count; j++)
							{
								text = text + list[j].method_0() + " ";
							}
							this.string_11 = text;
						}
					}
					else
					{
						this.string_11 = "";
					}
					if (GClass126.bool_12 && GClass126.list_1.Count > 0)
					{
						GClass126.smethod_0().method_2(GClass126.smethod_1());
					}
					this.bool_4 = true;
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

	// Token: 0x060002EB RID: 747 RVA: 0x00049158 File Offset: 0x00047358
	private void method_52()
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
				byte[] array = this.method_48(this.byte_3);
				if (array.Length < 2 || array[1] != 9)
				{
					GClass126.smethod_2("KA response error!", 1);
					if (array.Length == 0 && this.int_1 > 1)
					{
						GClass126.smethod_2("Terminate 7", 1);
						base.method_30(true);
					}
				}
			}
		}
		GClass126.smethod_2("KA stopped", 1);
	}

	// Token: 0x040001DE RID: 478
	private int int_5 = 2000;

	// Token: 0x040001DF RID: 479
	private int int_6 = 3;

	// Token: 0x040001E0 RID: 480
	private int int_7 = 1000;

	// Token: 0x040001E1 RID: 481
	private int int_8 = 3;

	// Token: 0x040001E2 RID: 482
	private int int_9 = 40;

	// Token: 0x040001E3 RID: 483
	private int int_10 = 3;

	// Token: 0x040001E4 RID: 484
	private int int_11 = 350;

	// Token: 0x040001E5 RID: 485
	private byte[] byte_3 = new byte[]
	{
		2,
		9
	};

	// Token: 0x040001E6 RID: 486
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

	// Token: 0x040001E7 RID: 487
	private byte[] byte_5 = new byte[]
	{
		2,
		7
	};

	// Token: 0x040001E8 RID: 488
	private byte[] byte_6 = new byte[]
	{
		2,
		5
	};

	// Token: 0x040001E9 RID: 489
	private string[] string_22 = new string[]
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
