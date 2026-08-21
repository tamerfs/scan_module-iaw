using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

// Token: 0x0200001E RID: 30
public sealed class GClass24 : GClass19
{
	// Token: 0x0600012F RID: 303 RVA: 0x00034C14 File Offset: 0x00032E14
	public GClass24(byte byte_6, List<GClass58> list_4, List<GClass58> list_5)
	{
		this.byte_0 = byte_6;
		this.list_0 = list_5;
		this.list_1 = list_4;
	}

	// Token: 0x06000130 RID: 304 RVA: 0x00034DE8 File Offset: 0x00032FE8
	public override void vmethod_1(GEnum0 genum0_0)
	{
		try
		{
			if (genum0_0 == (GEnum0)0)
			{
				for (int i = 0; i < 5; i++)
				{
					if (GClass3.bool_14)
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(100);
				}
			}
			if (GClass3.bool_0)
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
				GClass3.smethod_2("Testing mode!", 1);
				this.string_3 = "26 86 9B 02 9E";
				for (int i = 0; i < this.list_1.Count; i++)
				{
					GClass58 gclass = this.list_1[i];
					if (gclass.byte_0[0][0] == 0)
					{
						gclass.method_1(this.string_3);
					}
					else
					{
						gclass.method_1(this.vmethod_7(array[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_39))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				base.method_28();
				throw new Exception("1");
			}
			try
			{
				this.serialPort_0 = new SerialPort(GClass61.smethod_39(), GClass61.smethod_41(), Parity.None, 8, StopBits.One);
				this.serialPort_0.WriteBufferSize = 2;
				this.serialPort_0.ReceivedBytesThreshold = 1000;
				this.serialPort_0.Handshake = Handshake.None;
				this.serialPort_0.NewLine = "\n\r";
				this.serialPort_0.Open();
				GClass3.smethod_2("Serial port opened!", 1);
				GClass3.smethod_2("Init ELM and Wakeup ECU.", 1);
				this.serialPort_0.ReadTimeout = 3000;
				this.serialPort_0.WriteLine("ATZ");
				GClass3.smethod_2("Init ELM327 interface", 1);
				string text = this.method_38();
				if (!text.Contains("ELM32"))
				{
					GClass3.smethod_2("Invalid ELM interface!", 1);
				}
				this.serialPort_0.ReadTimeout = 1000;
				this.method_37("ATE0");
				this.method_37("ATL0");
				this.method_37("ATSP4");
				this.method_37("STIBR4800");
				this.method_37("STIMCS1");
				this.method_37("ATKW0");
				this.method_37("ATIIA " + GClass16.smethod_0(this.byte_0));
				Thread.Sleep(100);
				Thread.Sleep(100);
				this.method_37("ATSH 010000");
				this.method_37("ATSI");
				string text2 = this.method_37("ATKW");
				Thread.Sleep(100);
				this.method_37("00 02");
				Thread.Sleep(100);
				this.string_3 = text2.Replace("1:", string.Empty).Replace("2:", string.Empty).Replace("3:", string.Empty).Replace("4:", string.Empty).Replace("5:", string.Empty).Replace(">", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
				try
				{
					this.string_3 = GClass16.smethod_1(GClass16.smethod_2(this.string_3));
				}
				catch (Exception)
				{
				}
				GClass3.smethod_2("ECU ISO Code: " + this.string_3, 2);
			}
			catch (Exception ex)
			{
				GClass3.smethod_2(ex.Message, 1);
				throw new Exception("0");
			}
			GClass3.smethod_2("ECU wakeup completed", 1);
			if (GClass3.bool_14)
			{
				throw new Exception("ESC");
			}
			if (genum0_0 == (GEnum0)0)
			{
				Thread thread = new Thread(new ThreadStart(this.method_40));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_39))
				{
					Priority = ThreadPriority.Highest
				}.Start();
			}
			for (int i = 0; i < this.list_1.Count; i++)
			{
				GClass58 gclass = this.list_1[i];
				if (gclass.byte_0[0][0] == 0)
				{
					gclass.method_1(this.string_3);
				}
				else
				{
					gclass.method_1(this.vmethod_0(gclass.byte_0[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
			}
			if (genum0_0 != (GEnum0)0)
			{
				base.method_22(false);
			}
			else
			{
				this.bool_0 = true;
				base.method_28();
			}
		}
		catch (Exception ex2)
		{
			GClass3.smethod_2(ex2.Message, 2);
			GClass3.smethod_2("Terminate 4", 1);
			base.method_22(ex2.Message != "0");
		}
	}

	// Token: 0x06000131 RID: 305 RVA: 0x00035328 File Offset: 0x00033528
	public override void vmethod_2(bool bool_5, bool bool_6)
	{
		if (!this.bool_1)
		{
			GClass3.smethod_2("Terminating " + (bool_5 ? "with reconnect" : string.Empty), 1);
			if (!GClass3.bool_0 || bool_6)
			{
				this.bool_1 = true;
				this.bool_0 = false;
				Thread.Sleep(500);
				if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
				{
					try
					{
						this.method_37("ATPC");
						this.serialPort_0.Close();
						GClass3.smethod_2("Serial port closed!", 1);
					}
					catch (Exception ex)
					{
						GClass3.smethod_2("ERROR: Failed to close serial port: " + ex.Message, 1);
					}
					GClass3.smethod_2("-------------------------------------", 1);
					GClass3.smethod_2(" ", 1);
				}
				base.method_29(bool_6);
			}
		}
	}

	// Token: 0x06000132 RID: 306 RVA: 0x00035410 File Offset: 0x00033610
	public override List<GClass64> vmethod_3()
	{
		List<GClass64> list = new List<GClass64>();
		byte[] array;
		if (GClass3.bool_0)
		{
			array = this.byte_3;
		}
		else
		{
			array = this.method_36(this.byte_4);
		}
		List<GClass64> result;
		if (array.Length < 2 || array[1] != 252)
		{
			GClass3.smethod_2("ERROR: Error reading stored DTC codes", 1);
			result = null;
		}
		else
		{
			for (int i = 2; i < array.Length - 1; i += 5)
			{
				GClass64 gclass = new GClass64();
				gclass.string_0 = GClass16.smethod_1(new byte[]
				{
					array[i]
				}).Replace(" ", string.Empty);
				gclass.byte_0 = array[i + 1];
				gclass.byte_1 = array[i + 4];
				gclass.string_4 = string.Empty;
				gclass.string_5 = string.Empty;
				gclass.string_6 = string.Empty;
				gclass.string_1 = GClass16.smethod_1(new byte[]
				{
					array[i]
				}).Replace(" ", string.Empty);
				string text = GClass62.smethod_1("3099");
				if ((int)(gclass.byte_0 & 31) <= this.string_7.Length)
				{
					text = this.string_7[(int)(gclass.byte_0 & 31)];
				}
				gclass.string_4 = text;
				GClass64 gclass2 = gclass;
				string string_ = gclass2.string_2;
				gclass2.string_2 = string.Concat(new string[]
				{
					string_,
					GClass62.smethod_1("3070"),
					" ",
					text,
					"\r\n"
				});
				string text2 = string.Empty;
				if ((gclass.byte_0 & 128) != 0)
				{
					text2 += GClass62.smethod_1("3060");
				}
				if ((gclass.byte_0 & 64) != 0)
				{
					text2 = text2 + ((text2.Length > 0) ? " / " : string.Empty) + GClass62.smethod_1("3061");
				}
				if ((gclass.byte_0 & 32) != 0)
				{
					text2 = text2 + ((text2.Length > 0) ? " / " : string.Empty) + GClass62.smethod_1("3062");
				}
				gclass.string_5 = text2;
				GClass64 gclass3 = gclass;
				string_ = gclass3.string_2;
				gclass3.string_2 = string.Concat(new string[]
				{
					string_,
					GClass62.smethod_1("3071"),
					" ",
					text2,
					"\r\n"
				});
				GClass64 gclass4 = gclass;
				object string_2 = gclass4.string_2;
				gclass4.string_2 = string.Concat(new object[]
				{
					string_2,
					GClass62.smethod_1("3072"),
					" ",
					gclass.byte_1,
					"\r\n"
				});
				gclass.string_6 = string.Concat(gclass.byte_1);
				list.Add(gclass);
			}
			result = list;
		}
		return result;
	}

	// Token: 0x06000133 RID: 307 RVA: 0x00018938 File Offset: 0x00016B38
	private string method_33(byte byte_6)
	{
		string result = string.Empty;
		if ((byte_6 & 8) != 0)
		{
			result = GClass62.smethod_1("3056");
		}
		else if ((byte_6 & 4) != 0)
		{
			result = GClass62.smethod_1("3057");
		}
		else if ((byte_6 & 2) != 0)
		{
			result = GClass62.smethod_1("3058");
		}
		else if ((byte_6 & 1) != 0)
		{
			result = GClass62.smethod_1("3059");
		}
		return result;
	}

	// Token: 0x06000134 RID: 308 RVA: 0x0003570C File Offset: 0x0003390C
	public override void vmethod_5()
	{
		if (GClass3.bool_0)
		{
			this.byte_3 = new byte[]
			{
				2,
				252
			};
		}
		else
		{
			byte[] array = this.method_36(this.byte_5);
			if (array.Length < 2 || array[1] != 9)
			{
				GClass3.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
	}

	// Token: 0x06000135 RID: 309 RVA: 0x0003576C File Offset: 0x0003396C
	protected override void vmethod_6(GClass58 gclass58_1)
	{
		if (GClass3.bool_0)
		{
			Thread.Sleep(3000);
			if (gclass58_1.string_2.Contains("FUNC"))
			{
				base.method_31(true, GClass62.smethod_1("6051"), GClass62.smethod_1("6055") + " 00");
			}
			else
			{
				base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
			}
		}
		else
		{
			this.method_34(gclass58_1);
		}
	}

	// Token: 0x06000136 RID: 310 RVA: 0x000357E8 File Offset: 0x000339E8
	private void method_34(GClass58 gclass58_1)
	{
		byte[] array = this.method_36(gclass58_1.byte_0[0]);
		if (array.Length == 0 || (array.Length > 1 && array[1] != 9))
		{
			string empty = string.Empty;
			base.method_31(false, GClass62.smethod_1("6052"), empty);
			Thread.Sleep(1800);
		}
		else
		{
			if (gclass58_1.byte_0.Length > 2)
			{
				for (int i = 1; i < gclass58_1.byte_0.Length; i++)
				{
					Thread.Sleep(2000);
					this.method_36(gclass58_1.byte_0[i]);
				}
			}
			else if (gclass58_1.byte_0.Length == 2)
			{
				for (int i = 1; i < gclass58_1.byte_0.Length; i++)
				{
					Thread.Sleep(6000);
					Thread.Sleep(2000);
					this.method_36(gclass58_1.byte_0[i]);
				}
			}
			else
			{
				Thread.Sleep(9000);
			}
			base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
		}
	}

	// Token: 0x06000137 RID: 311 RVA: 0x000358F0 File Offset: 0x00033AF0
	public override string vmethod_0(byte[] byte_6, string string_8, int int_12, int int_13, string[] string_9, string string_10)
	{
		byte[] array = this.method_36(byte_6);
		return this.vmethod_7(array, string_8, int_12, int_13, string_9, string_10);
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00035918 File Offset: 0x00033B18
	private byte[] method_35(byte[] byte_6)
	{
		byte[] array = new byte[byte_6.Length];
		byte b = 0;
		for (int i = 0; i < byte_6.Length; i++)
		{
			if (i > 0)
			{
				array[i - 1] = byte_6[i];
			}
			b += byte_6[i];
		}
		array[array.Length - 1] = b;
		this.serialPort_0.WriteLine(GClass16.smethod_1(array));
		GClass3.smethod_2("Send: " + GClass16.smethod_1(array), 0);
		string text = this.method_38();
		int num = 0;
		while (num < text.Length && text[num] != '\r' && text[num] != '\n' && text[num] != '>')
		{
			num++;
		}
		string string_ = "00" + text.Substring(0, num);
		return GClass16.smethod_2(string_);
	}

	// Token: 0x06000139 RID: 313 RVA: 0x000359F4 File Offset: 0x00033BF4
	private byte[] method_36(byte[] byte_6)
	{
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			this.int_0 = GClass3.smethod_1();
			byte[] array = this.method_35(byte_6);
			this.int_0 = GClass3.smethod_1();
			this.bool_2 = false;
			result = array;
		}
		catch (Exception ex)
		{
			if (!this.bool_1)
			{
				GClass3.smethod_2(ex.Message + "(3)", 1);
				this.bool_2 = false;
				GClass3.smethod_2("Terminate 5", 1);
				base.method_22(true);
			}
			this.bool_2 = false;
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x0600013A RID: 314 RVA: 0x00035A9C File Offset: 0x00033C9C
	public override string vmethod_7(byte[] byte_6, string string_8, int int_12, int int_13, string[] string_9, string string_10)
	{
		string text = string.Empty;
		int_12++;
		string result;
		if (byte_6.Length <= int_12)
		{
			result = text;
		}
		else
		{
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
			text = base.method_32(array, string_8, string_9, string_10);
			result = text;
		}
		return result;
	}

	// Token: 0x0600013B RID: 315 RVA: 0x00035B08 File Offset: 0x00033D08
	private string method_37(string string_8)
	{
		this.serialPort_0.WriteLine(string_8);
		GClass3.smethod_2("Command: " + string_8, 0);
		string text = this.method_38();
		GClass3.smethod_2("Response: " + text, 0);
		if (!text.Contains("OK"))
		{
			GClass3.smethod_2("[" + string_8 + "] failed!", 0);
		}
		return text;
	}

	// Token: 0x0600013C RID: 316 RVA: 0x00019A98 File Offset: 0x00017C98
	private string method_38()
	{
		string text = string.Empty;
		while (!text.EndsWith(">"))
		{
			text += (char)this.serialPort_0.ReadByte();
		}
		GClass3.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x0600013D RID: 317 RVA: 0x00035B70 File Offset: 0x00033D70
	private void method_39()
	{
		GClass3.smethod_2("PM started", 1);
		GClass3.int_2 = 0;
		while (!this.bool_1)
		{
			Thread.Sleep(50);
			if ((this.serialPort_0 != null && this.serialPort_0.IsOpen) || GClass3.bool_0)
			{
				if (GClass3.smethod_1() <= GClass3.int_2 + GClass3.int_4 || this.bool_2)
				{
					continue;
				}
				GClass3.int_2 = GClass3.smethod_1();
				if (!GClass3.bool_11)
				{
					Thread.Sleep(100);
					continue;
				}
				for (int i = 0; i < this.list_0.Count; i++)
				{
					GClass58 gclass = this.list_0[i];
					if (gclass.bool_0)
					{
						if (GClass3.bool_0)
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
							gclass.method_1(string.Concat(this.random_0.Next(0, 100)));
							if (gclass.byte_0[0].Length == 3)
							{
								if (gclass.byte_0[0][2] == 1)
								{
									gclass.method_1(this.vmethod_7(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 2)
								{
									gclass.method_1(this.vmethod_7(array[1], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 3)
								{
									gclass.method_1(this.vmethod_7(array[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 4)
								{
									gclass.method_1(this.vmethod_7(array[3], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 5)
								{
									gclass.method_1(this.vmethod_7(array[4], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 6)
								{
									gclass.method_1(this.vmethod_7(array[5], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else
								{
									gclass.method_1(this.vmethod_7(array[5], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
							}
							else if (gclass.string_2.StartsWith("bit"))
							{
								gclass.method_1(this.vmethod_7(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							Thread.Sleep(this.int_9);
						}
						else
						{
							gclass.method_1(this.vmethod_0(gclass.byte_0[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							if (this.bool_1)
							{
								GClass3.smethod_2("PM stopped(2)", 1);
								return;
							}
						}
					}
				}
				if (GClass3.bool_7)
				{
					List<GClass64> list = this.vmethod_3();
					string text = string.Empty;
					for (int j = 0; j < list.Count; j++)
					{
						text = text + list[j].method_0() + " ";
					}
					this.string_6 = text;
				}
				else
				{
					this.string_6 = string.Empty;
				}
				if (GClass3.bool_4 && GClass3.list_1.Count > 0)
				{
					GClass3.smethod_0().method_2(GClass3.smethod_1());
				}
				this.bool_3 = true;
				int num = GClass3.smethod_1() - GClass3.int_2;
				if (num > GClass3.int_5)
				{
					GClass3.int_5 = num;
				}
				if (!GClass3.bool_4)
				{
					if (num < GClass3.int_5)
					{
						GClass3.int_5 = num;
					}
					GClass3.int_4 = GClass3.int_5;
					continue;
				}
				continue;
			}
			else
			{
				GClass3.smethod_2("PM stopped(1)", 1);
			}
			return;
		}
		GClass3.smethod_2("PM stopped", 1);
	}

	// Token: 0x0600013E RID: 318 RVA: 0x0003606C File Offset: 0x0003426C
	private void method_40()
	{
		GClass3.smethod_2("KA started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(20);
			if (this.serialPort_0 == null || !this.serialPort_0.IsOpen)
			{
				GClass3.smethod_2("KA stopped(1)", 1);
				return;
			}
			if (GClass3.smethod_1() > this.int_0 + this.int_11 && !this.bool_2)
			{
				byte[] array = this.method_36(this.byte_2);
				if (array.Length < 2 || array[1] != 9)
				{
					GClass3.smethod_2("KA response error!", 1);
					if (array.Length == 0 && this.int_1 > 1)
					{
						GClass3.smethod_2("Terminate 7", 1);
						base.method_22(true);
					}
				}
			}
		}
		GClass3.smethod_2("KA stopped", 1);
	}

	// Token: 0x04000118 RID: 280
	private int int_5 = 2000;

	// Token: 0x04000119 RID: 281
	private int int_6 = 3;

	// Token: 0x0400011A RID: 282
	private int int_7 = 1000;

	// Token: 0x0400011B RID: 283
	private int int_8 = 3;

	// Token: 0x0400011C RID: 284
	private int int_9 = 40;

	// Token: 0x0400011D RID: 285
	private int int_10 = 3;

	// Token: 0x0400011E RID: 286
	private int int_11 = 350;

	// Token: 0x0400011F RID: 287
	private byte[] byte_2 = new byte[]
	{
		2,
		9
	};

	// Token: 0x04000120 RID: 288
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

	// Token: 0x04000121 RID: 289
	private byte[] byte_4 = new byte[]
	{
		2,
		7
	};

	// Token: 0x04000122 RID: 290
	private byte[] byte_5 = new byte[]
	{
		2,
		5
	};

	// Token: 0x04000123 RID: 291
	private string[] string_7 = new string[]
	{
		GClass62.smethod_1("3080"),
		GClass62.smethod_1("3081"),
		GClass62.smethod_1("3082"),
		GClass62.smethod_1("3083"),
		GClass62.smethod_1("3084"),
		GClass62.smethod_1("3085"),
		GClass62.smethod_1("3086"),
		GClass62.smethod_1("3087"),
		GClass62.smethod_1("3088"),
		GClass62.smethod_1("3089"),
		GClass62.smethod_1("3090"),
		GClass62.smethod_1("3091"),
		GClass62.smethod_1("3092"),
		GClass62.smethod_1("3093"),
		GClass62.smethod_1("3094"),
		GClass62.smethod_1("3095"),
		GClass62.smethod_1("3096"),
		GClass62.smethod_1("3097"),
		GClass62.smethod_1("3098")
	};
}
