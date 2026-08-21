using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Threading;

// Token: 0x0200006D RID: 109
public sealed class GClass49 : GClass19
{
	// Token: 0x06000358 RID: 856 RVA: 0x00070538 File Offset: 0x0006E738
	public GClass49(byte byte_8, List<GClass58> list_4, List<GClass58> list_5)
	{
		byte[] array = new byte[4];
		array[0] = 3;
		array[1] = 23;
		this.byte_7 = array;
		this.int_10 = 0;
		this.string_7 = new string[]
		{
			"00 00 00 20 45 78 99 11 23 44 55 99",
			"00 00 00 38 22 99 12 65 29 81 02 00",
			"00 00 00 95 18 24 76 4A 6B 1F 00 00"
		};
		this.string_8 = " <";
		this.string_9 = "> Sent: ";
		this.string_10 = " <";
		this.string_11 = "> ERROR: Invalid echo: ";
		this.string_12 = "Invalid echo!";
		this.string_13 = "Received: ";
		this.string_14 = "[";
		this.string_15 = "] ";
		base..ctor();
		this.byte_0 = byte_8;
		this.list_0 = list_5;
		this.list_1 = list_4;
	}

	// Token: 0x06000359 RID: 857 RVA: 0x000706A4 File Offset: 0x0006E8A4
	public override void vmethod_1(GEnum0 genum0_0)
	{
		try
		{
			this.byte_2[1] = this.byte_0;
			this.int_1 = 0;
			int num = 0;
			byte b = 239;
			this.bool_5 = false;
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
						7,
						90,
						151,
						253,
						134,
						21,
						1,
						110
					},
					new byte[]
					{
						13,
						90,
						145,
						53,
						53,
						49,
						56,
						56,
						50,
						49,
						52,
						32,
						32,
						32
					},
					new byte[]
					{
						13,
						90,
						146,
						48,
						50,
						56,
						49,
						48,
						49,
						49,
						52,
						50,
						49,
						32
					},
					new byte[]
					{
						3,
						90,
						147,
						0
					},
					new byte[]
					{
						13,
						90,
						148,
						49,
						48,
						51,
						55,
						51,
						54,
						55,
						55,
						57,
						48,
						32
					},
					new byte[]
					{
						4,
						90,
						149,
						160,
						68
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
				for (int i = 0; i < 20; i++)
				{
					if (GClass3.bool_14)
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(100);
				}
				GClass3.smethod_2("Testing mode!", 1);
				for (int i = 0; i < this.list_1.Count; i++)
				{
					GClass58 gclass = this.list_1[i];
					string text = this.vmethod_7(array[i], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
					gclass.method_1(text);
					if (gclass.int_2 == 1770)
					{
						this.string_3 = text;
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_48))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				base.method_28();
				throw new Exception("1");
			}
			try
			{
				this.serialPort_0 = new SerialPort(GClass61.smethod_39(), 10400, Parity.None, 8, StopBits.One);
				this.serialPort_0.WriteBufferSize = 2;
				this.serialPort_0.ReceivedBytesThreshold = 1000;
				this.serialPort_0.Handshake = Handshake.None;
				this.serialPort_0.Open();
				GClass3.smethod_2("Serial port opened!", 1);
			}
			catch (Exception ex)
			{
				this.string_4 = ex.Message;
				GClass3.smethod_2(ex.Message, 1);
				throw new Exception("0");
			}
			if (GClass3.bool_14)
			{
				throw new Exception("ESC");
			}
			int j = 4;
			if (genum0_0 != (GEnum0)0)
			{
				j = 1;
			}
			while (j > 0)
			{
				try
				{
					long num2 = 0L;
					GClass3.smethod_2("Fast wake up start", 1);
					this.serialPort_0.ReadTimeout = 1;
					num2 = GClass3.stopwatch_0.ElapsedTicks;
					this.serialPort_0.BreakState = true;
					while ((double)GClass3.stopwatch_0.ElapsedTicks < (double)num2 + 0.01 * (double)Stopwatch.Frequency)
					{
						Thread.Sleep(1);
					}
					while ((double)GClass3.stopwatch_0.ElapsedTicks < (double)num2 + 0.0245 * (double)Stopwatch.Frequency)
					{
					}
					this.serialPort_0.BreakState = false;
					while ((double)GClass3.stopwatch_0.ElapsedTicks < (double)num2 + 0.03 * (double)Stopwatch.Frequency)
					{
						Thread.Sleep(1);
					}
					try
					{
						this.serialPort_0.ReadExisting();
					}
					catch (Exception)
					{
					}
					this.serialPort_0.ReadTimeout = 1000;
					while ((double)GClass3.stopwatch_0.ElapsedTicks < (double)num2 + 0.0495 * (double)Stopwatch.Frequency)
					{
					}
					this.serialPort_0.Write(this.byte_2, 0, 1);
					GClass3.smethod_2("Sent: " + GClass16.smethod_0(this.byte_2[0]), 0);
					byte b2 = (byte)this.serialPort_0.ReadByte();
					this.int_0 = GClass3.smethod_1();
					num = this.int_0 + 8000;
					if (this.byte_2[0] != b2)
					{
						throw new Exception("ERROR: Invalid echo!");
					}
					for (int i = 1; i < this.byte_2.Length; i++)
					{
						GClass3.smethod_2(this.method_44(this.byte_2[i]), 0);
					}
					byte byte_ = this.method_43(this.byte_2);
					GClass3.smethod_2(this.method_44(byte_), 0);
					byte[] array2 = this.method_47();
					if (array2.Length < 4 || array2[1] != 193)
					{
						GClass3.smethod_2("ERROR: Invalid wakeup response!", 1);
						throw new Exception("Invalid wakeup response!");
					}
					b = array2[2];
					this.serialPort_0.ReadTimeout = 100;
					int num3 = 3;
					if (GClass61.smethod_47() == 0 || j == 1)
					{
						array2 = this.method_42(new byte[]
						{
							2,
							131,
							1
						});
					}
					else if (GClass61.smethod_47() == 1)
					{
						byte[] array3 = new byte[3];
						array3[0] = 2;
						array3[1] = 131;
						array2 = this.method_42(array3);
						if (array2.Length == 8)
						{
							array2[1] = 131;
							array2[2] = 3;
							array2 = this.method_42(array2);
						}
						num3 = 2;
					}
					else if (GClass61.smethod_47() == 2)
					{
						array2 = this.method_42(new byte[]
						{
							7,
							131,
							3,
							2,
							2,
							4,
							20,
							2
						});
						num3 = 2;
					}
					else if (GClass61.smethod_47() == 3)
					{
						array2 = this.method_42(new byte[]
						{
							7,
							131,
							3,
							60,
							4,
							110,
							20,
							10
						});
						num3 = 4;
					}
					array2 = this.method_42(new byte[]
					{
						2,
						131,
						2
					});
					if (array2.Length < 8)
					{
						GClass3.smethod_2("WARNING: Unable to read timing data!", 1);
					}
					else
					{
						this.int_5 = (int)(array2[7] / 2) + num3;
						this.int_6 = (int)(array2[4] * 25 + 20);
						this.int_7 = (int)(array2[5] / 2) + num3;
						this.int_9 = (int)(array2[6] * 80);
						this.int_8 = (int)(array2[6] * 250);
						if (this.int_9 > 4000)
						{
							this.int_9 = 4000;
						}
						this.serialPort_0.ReadTimeout = this.int_6 + 20;
					}
					j = 0;
				}
				catch (Exception)
				{
					this.serialPort_0.BreakState = false;
					j--;
					if (j == 0)
					{
						throw new Exception("1");
					}
					if (GClass3.bool_14)
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(5000);
				}
			}
			GClass3.smethod_2("ECU wakeup completed", 1);
			if (GClass3.bool_14)
			{
				throw new Exception("ESC");
			}
			if (genum0_0 == (GEnum0)0)
			{
				Thread thread = new Thread(new ThreadStart(this.method_49));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_48))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				Thread.Sleep(100);
			}
			for (int i = 0; i < this.list_1.Count; i++)
			{
				GClass58 gclass = this.list_1[i];
				string text = this.vmethod_0(gclass.byte_0[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				gclass.method_1(text);
				if (gclass.int_2 == 1770)
				{
					this.string_3 = text;
					GClass3.smethod_2("ECU ISO Code: " + text, 2);
				}
			}
			if (genum0_0 == (GEnum0)2)
			{
				Thread.Sleep(200);
				this.list_3 = this.vmethod_3();
			}
			if (genum0_0 != (GEnum0)0)
			{
				base.method_22(false);
			}
			else
			{
				this.bool_0 = true;
				base.method_28();
				while ((num > GClass3.smethod_1() || this.bool_2) && !this.bool_1)
				{
					Thread.Sleep(20);
				}
				if (!this.bool_1)
				{
					if (this.string_3 == "7C 86 02 98 F1")
					{
						b = 233;
					}
					if (b == 239)
					{
						this.bool_5 = true;
					}
					else if (b == 233)
					{
						this.bool_5 = false;
					}
					else
					{
						GClass3.smethod_2("WARNING: Unsupported message format!!!", 1);
					}
				}
			}
		}
		catch (Exception ex2)
		{
			if (ex2.Message == "ESC")
			{
				this.string_4 = "Aborted by user";
			}
			if (ex2.Message == "1")
			{
				this.string_4 = "No ECU response";
			}
			GClass3.smethod_2(ex2.Message, 2);
			GClass3.smethod_2("Terminate 4", 1);
			base.method_22(ex2.Message != "1" && ex2.Message != "0" && ex2.Message != "ESC");
		}
	}

	// Token: 0x0600035A RID: 858 RVA: 0x00071024 File Offset: 0x0006F224
	private bool method_33()
	{
		return this.method_34() ?? this.method_34();
	}

	// Token: 0x0600035B RID: 859 RVA: 0x00071044 File Offset: 0x0006F244
	private bool method_34()
	{
		this.int_10++;
		bool result;
		if (this.int_10 > 20)
		{
			result = false;
		}
		else
		{
			for (int i = 0; i < 10; i++)
			{
				if (this.bool_1)
				{
					return false;
				}
				Thread.Sleep(10);
			}
			this.bool_5 = false;
			try
			{
				long num = 0L;
				GClass3.smethod_2("Fast wake up start", 1);
				this.serialPort_0.ReadTimeout = 1;
				num = GClass3.stopwatch_0.ElapsedTicks;
				this.serialPort_0.BreakState = true;
				while ((double)GClass3.stopwatch_0.ElapsedTicks < (double)num + 0.01 * (double)Stopwatch.Frequency)
				{
					Thread.Sleep(1);
				}
				while ((double)GClass3.stopwatch_0.ElapsedTicks < (double)num + 0.0245 * (double)Stopwatch.Frequency)
				{
				}
				this.serialPort_0.BreakState = false;
				while ((double)GClass3.stopwatch_0.ElapsedTicks < (double)num + 0.03 * (double)Stopwatch.Frequency)
				{
					Thread.Sleep(1);
				}
				try
				{
					this.serialPort_0.ReadExisting();
				}
				catch (Exception)
				{
				}
				this.serialPort_0.ReadTimeout = 1000;
				while ((double)GClass3.stopwatch_0.ElapsedTicks < (double)num + 0.0495 * (double)Stopwatch.Frequency)
				{
				}
				this.serialPort_0.Write(this.byte_2, 0, 1);
				GClass3.smethod_2("Sent: " + GClass16.smethod_0(this.byte_2[0]), 0);
				byte b = (byte)this.serialPort_0.ReadByte();
				this.int_0 = GClass3.smethod_1();
				if (this.byte_2[0] != b)
				{
					throw new Exception("ERROR: Invalid echo!");
				}
				for (int i = 1; i < this.byte_2.Length; i++)
				{
					GClass3.smethod_2(this.method_44(this.byte_2[i]), 0);
				}
				byte byte_ = this.method_43(this.byte_2);
				GClass3.smethod_2(this.method_44(byte_), 0);
				byte[] array = this.method_47();
				if (array.Length < 4 || array[1] != 193)
				{
					GClass3.smethod_2("ERROR: Invalid wakeup response!", 1);
					throw new Exception("Invalid wakeup response!");
				}
				this.serialPort_0.ReadTimeout = 100;
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
				return false;
			}
			result = true;
		}
		return result;
	}

	// Token: 0x0600035C RID: 860 RVA: 0x00051ED8 File Offset: 0x000500D8
	public override void vmethod_2(bool bool_6, bool bool_7)
	{
		if (!this.bool_1)
		{
			GClass3.smethod_2("Terminating " + (bool_6 ? "with reconnect" : string.Empty), 1);
			if (!GClass3.bool_0 || bool_7)
			{
				this.bool_1 = true;
				this.bool_0 = false;
				Thread.Sleep(500);
				if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
				{
					try
					{
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
				base.method_29(bool_7);
			}
		}
	}

	// Token: 0x0600035D RID: 861 RVA: 0x000712F8 File Offset: 0x0006F4F8
	public override List<GClass64> vmethod_3()
	{
		List<GClass64> list = new List<GClass64>();
		byte[] array;
		if (GClass3.bool_0)
		{
			array = this.byte_4;
		}
		else
		{
			array = this.method_42(this.byte_5);
		}
		List<GClass64> result;
		if (array.Length < 3)
		{
			GClass3.smethod_2("ERROR: Error reading stored DTC codes", 1);
			result = null;
		}
		else
		{
			int num = (int)array[2];
			int num2 = 0;
			int num3 = 3;
			while (num2 < num && num3 < array.Length - 2)
			{
				GClass64 gclass = new GClass64();
				gclass.string_0 = GClass16.smethod_1(new byte[]
				{
					array[num3],
					array[num3 + 1]
				}).Replace(" ", string.Empty);
				gclass.byte_0 = array[num3 + 2];
				gclass.string_4 = this.method_35(gclass.byte_0);
				gclass.string_5 = this.method_36(gclass.byte_0);
				gclass.string_6 = this.method_37(gclass.byte_0);
				string str = string.Empty;
				if ((array[num3] & 192) == 0)
				{
					str = "P";
				}
				else if ((array[num3] & 192) == 64)
				{
					str = "C";
				}
				else if ((array[num3] & 192) == 128)
				{
					str = "B";
				}
				else if ((array[num3] & 192) == 192)
				{
					str = "U";
				}
				gclass.string_1 = str + GClass16.smethod_1(new byte[]
				{
					array[num3] & 63,
					array[num3 + 1]
				}).Replace(" ", string.Empty);
				if ((gclass.byte_0 & 8) != 0)
				{
					GClass64 gclass2 = gclass;
					gclass2.string_2 = gclass2.string_2 + GClass62.smethod_1("3065") + " ";
				}
				else if ((gclass.byte_0 & 4) != 0)
				{
					GClass64 gclass3 = gclass;
					gclass3.string_2 = gclass3.string_2 + GClass62.smethod_1("3066") + " ";
				}
				else if ((gclass.byte_0 & 2) != 0)
				{
					GClass64 gclass4 = gclass;
					gclass4.string_2 = gclass4.string_2 + GClass62.smethod_1("3067") + " ";
				}
				else if ((gclass.byte_0 & 1) != 0)
				{
					GClass64 gclass5 = gclass;
					gclass5.string_2 = gclass5.string_2 + GClass62.smethod_1("3068") + " ";
				}
				if ((gclass.byte_0 & 96) == 0)
				{
					GClass64 gclass6 = gclass;
					gclass6.string_2 = gclass6.string_2 + GClass62.smethod_1("3075") + " ";
				}
				else if ((gclass.byte_0 & 96) == 32)
				{
					GClass64 gclass7 = gclass;
					gclass7.string_2 = gclass7.string_2 + GClass62.smethod_1("3076") + " ";
				}
				else if ((gclass.byte_0 & 96) == 64)
				{
					GClass64 gclass8 = gclass;
					gclass8.string_2 = gclass8.string_2 + GClass62.smethod_1("3077") + " ";
				}
				else if ((gclass.byte_0 & 96) == 96)
				{
					GClass64 gclass9 = gclass;
					gclass9.string_2 = gclass9.string_2 + GClass62.smethod_1("3078") + " ";
				}
				if ((gclass.byte_0 & 128) == 0)
				{
					GClass64 gclass10 = gclass;
					gclass10.string_2 = gclass10.string_2 + GClass62.smethod_1("3073") + " ";
				}
				else
				{
					GClass64 gclass11 = gclass;
					gclass11.string_2 = gclass11.string_2 + GClass62.smethod_1("3074") + " ";
				}
				list.Add(gclass);
				num3 += 3;
			}
			result = list;
		}
		return result;
	}

	// Token: 0x0600035E RID: 862 RVA: 0x00018938 File Offset: 0x00016B38
	private string method_35(byte byte_8)
	{
		string result = string.Empty;
		if ((byte_8 & 8) != 0)
		{
			result = GClass62.smethod_1("3056");
		}
		else if ((byte_8 & 4) != 0)
		{
			result = GClass62.smethod_1("3057");
		}
		else if ((byte_8 & 2) != 0)
		{
			result = GClass62.smethod_1("3058");
		}
		else if ((byte_8 & 1) != 0)
		{
			result = GClass62.smethod_1("3059");
		}
		return result;
	}

	// Token: 0x0600035F RID: 863 RVA: 0x000189A0 File Offset: 0x00016BA0
	private string method_36(byte byte_8)
	{
		string result = string.Empty;
		if ((byte_8 & 96) == 0)
		{
			result = GClass62.smethod_1("3052");
		}
		else if ((byte_8 & 96) == 32)
		{
			result = GClass62.smethod_1("3053");
		}
		else if ((byte_8 & 96) == 64)
		{
			result = GClass62.smethod_1("3054");
		}
		else if ((byte_8 & 96) == 96)
		{
			result = GClass62.smethod_1("3055");
		}
		return result;
	}

	// Token: 0x06000360 RID: 864 RVA: 0x00018A1C File Offset: 0x00016C1C
	private string method_37(byte byte_8)
	{
		string result = string.Empty;
		if ((byte_8 & 128) != 0)
		{
			result = GClass62.smethod_1("3051");
		}
		return result;
	}

	// Token: 0x06000361 RID: 865 RVA: 0x000716C4 File Offset: 0x0006F8C4
	public override void vmethod_5()
	{
		if (GClass3.bool_0)
		{
			this.byte_4 = new byte[]
			{
				2,
				88,
				0,
				90
			};
		}
		else
		{
			byte[] array = this.method_42(this.byte_6);
			if (array.Length < 3 || array[1] != 84)
			{
				GClass3.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
	}

	// Token: 0x06000362 RID: 866 RVA: 0x00071720 File Offset: 0x0006F920
	public override void vmethod_4(List<GClass64> list_4, List<GClass58> list_5)
	{
		if (list_4 != null && list_5 != null && list_4.Count != 0 && list_5.Count != 0)
		{
			int num = this.string_7.Length;
			SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
			foreach (GClass64 gclass in list_4)
			{
				if (!(gclass.string_3 != string.Empty))
				{
					if (num > 0)
					{
						num--;
					}
					sortedList.Clear();
					try
					{
						foreach (GClass58 gclass2 in list_5)
						{
							if (gclass2.string_1.Contains("*") || gclass2.string_1.Contains("[" + gclass.string_0 + "]"))
							{
								string text = GClass16.smethod_1(gclass2.byte_0[0]);
								text = text.Replace("00 00", gclass.string_0);
								byte[] byte_ = GClass16.smethod_2(text);
								byte[] value = new byte[0];
								if (GClass3.bool_0)
								{
									value = GClass16.smethod_2(this.string_7[num]);
								}
								else if (sortedList.ContainsKey(text))
								{
									value = sortedList[text];
								}
								else
								{
									value = this.method_42(byte_);
									sortedList.Add(text, value);
								}
								gclass2.method_1(this.vmethod_7(value, gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
								GClass64 gclass3 = gclass;
								string string_ = gclass3.string_3;
								gclass3.string_3 = string.Concat(new string[]
								{
									string_,
									gclass2.string_0,
									": ",
									gclass2.method_0(),
									" ",
									gclass2.string_3,
									Environment.NewLine
								});
							}
						}
						if (gclass.string_3 != string.Empty)
						{
							gclass.string_3 = GClass62.smethod_1("3047") + Environment.NewLine + gclass.string_3;
						}
					}
					catch (Exception)
					{
						GClass3.smethod_2("ERROR: Error reading DTC details", 0);
					}
				}
			}
		}
	}

	// Token: 0x06000363 RID: 867 RVA: 0x000719C8 File Offset: 0x0006FBC8
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
		else if (gclass58_1.string_2.Contains("FUNC"))
		{
			this.method_39(gclass58_1);
		}
		else if (gclass58_1.string_2.Contains("RWUSERENTRY"))
		{
			this.method_40(gclass58_1);
		}
		else
		{
			this.method_38(gclass58_1);
		}
	}

	// Token: 0x06000364 RID: 868 RVA: 0x00071A80 File Offset: 0x0006FC80
	private void method_38(GClass58 gclass58_1)
	{
		int num = 20;
		if (gclass58_1.string_2.Contains("0.5SEC"))
		{
			num = 5;
		}
		else if (gclass58_1.string_2.Contains("1SEC"))
		{
			num = 10;
		}
		if (num > 10 && gclass58_1.byte_0.Length == 2)
		{
			num = 3 * num;
		}
		if (num > 10 && gclass58_1.byte_0.Length == 1)
		{
			num = 4 * num;
		}
		bool flag = gclass58_1.string_2.Contains("EXECANY");
		bool flag3;
		bool flag2 = !(flag3 = gclass58_1.string_2.Contains("IORESULT")) && gclass58_1.byte_0.Length > 1 && !gclass58_1.string_2.Contains("NOABORT");
		int i = 0;
		while (i < gclass58_1.byte_0.Length)
		{
			byte[] array = this.method_42(gclass58_1.byte_0[i]);
			if ((flag || array.Length != 0) && (array.Length <= 1 || array[1] != 127))
			{
				if (!flag3)
				{
					if (i < gclass58_1.byte_0.Length - 1 || gclass58_1.byte_0.Length == 1)
					{
						for (int j = 0; j < num; j++)
						{
							if (GClass3.bool_14 && flag2)
							{
								GClass3.smethod_2(GClass62.smethod_1("6081"), 2);
								array = this.method_42(gclass58_1.byte_0[gclass58_1.byte_0.Length - 1]);
								base.method_31(false, GClass62.smethod_1("6082"), " ");
								return;
							}
							Thread.Sleep(100);
						}
					}
					i++;
					continue;
				}
				int num2 = 60;
				if (gclass58_1.string_2.Contains("WAITY"))
				{
					while (num2 > 0 && !GClass3.bool_13)
					{
						Thread.Sleep(500);
						num2--;
					}
				}
				else
				{
					Thread.Sleep(10000);
				}
				string text = GClass62.smethod_1("6052");
				string text2 = string.Empty;
				if (num2 > 0)
				{
					text = GClass62.smethod_1("6051");
					text2 = GClass62.smethod_1("6055") + this.vmethod_0(gclass58_1.byte_0[1], "bits", gclass58_1.int_0, gclass58_1.int_1, gclass58_1.string_5, gclass58_1.string_6);
				}
				base.method_31(false, text, text2);
			}
			else
			{
				string text3 = string.Empty;
				if (array.Length > 3 && array[3] == 34)
				{
					text3 = GClass62.smethod_1("6053");
				}
				else if (array.Length > 3 && array[3] == 17)
				{
					text3 = GClass62.smethod_1("6054");
				}
				base.method_31(false, GClass62.smethod_1("6052"), text3);
			}
			return;
		}
		base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
	}

	// Token: 0x06000365 RID: 869 RVA: 0x00071D6C File Offset: 0x0006FF6C
	private void method_39(GClass58 gclass58_1)
	{
		byte[] array = this.method_42(gclass58_1.byte_0[0]);
		if (array.Length > 1 && array[1] == 127)
		{
			string text = string.Empty;
			if (array.Length > 3 && array[3] == 34)
			{
				text = GClass62.smethod_1("6053");
			}
			else if (array.Length > 3 && array[3] == 17)
			{
				text = GClass62.smethod_1("6054");
			}
			base.method_31(false, GClass62.smethod_1("6052"), text);
		}
		else
		{
			byte[] array2 = new byte[3];
			array2[0] = 2;
			array2[1] = 51;
			byte[] array3 = array2;
			array3[2] = gclass58_1.byte_0[0][2];
			array2 = new byte[3];
			array2[0] = 2;
			array2[1] = 50;
			byte[] array4 = array2;
			array4[2] = gclass58_1.byte_0[0][2];
			int num = 1800;
			bool flag = true;
			IL_166:
			while (num > 0 && flag)
			{
				for (int i = 0; i < 5; i++)
				{
					if (GClass3.bool_14)
					{
						GClass3.smethod_2("Aborting routine...", 1);
						array = this.method_42(array4);
						num = 0;
						IL_114:
						GClass3.smethod_2("Checking routine status..", 1);
						array = this.method_42(array3);
						if (array.Length <= 3 || array[1] != 127 || array[2] != 51 || (array[3] != 33 && array[3] != 35))
						{
							flag = false;
						}
						num--;
						goto IL_166;
					}
					Thread.Sleep(100);
				}
				goto IL_114;
			}
			string text2 = GClass62.smethod_1("6056");
			if (array.Length > 3 && array[1] == 115)
			{
				if (gclass58_1.string_5.Length > 0)
				{
					byte b = array[3];
					if (gclass58_1.int_0 == 2 && array.Length > 4)
					{
						b = array[4];
					}
					text2 = GClass62.smethod_1("6055") + " " + GClass16.smethod_0(array[3]);
					for (int i = 0; i < gclass58_1.string_5.Length; i++)
					{
						byte b2 = byte.Parse(gclass58_1.string_5[i].Substring(0, 2), NumberStyles.HexNumber);
						byte b3 = byte.Parse(gclass58_1.string_5[i].Substring(2, 2), NumberStyles.HexNumber);
						if ((b & b2) == b3 || i == gclass58_1.string_5.Length - 1)
						{
							text2 = gclass58_1.string_5[i].Substring(4);
							break;
						}
					}
				}
				else if (array.Length == 4)
				{
					text2 = GClass62.smethod_1("6055") + " " + GClass16.smethod_0(array[3]);
				}
				else if (array.Length == 5)
				{
					text2 = string.Concat(new string[]
					{
						GClass62.smethod_1("6055"),
						" ",
						GClass16.smethod_0(array[3]),
						" ",
						GClass16.smethod_0(array[4])
					});
				}
				else if (array.Length > 5)
				{
					text2 = string.Concat(new string[]
					{
						GClass62.smethod_1("6055"),
						" ",
						GClass16.smethod_0(array[3]),
						" ",
						GClass16.smethod_0(array[4]),
						" ",
						GClass16.smethod_0(array[5])
					});
				}
			}
			base.method_31(true, GClass62.smethod_1("6051"), text2);
		}
	}

	// Token: 0x06000366 RID: 870 RVA: 0x000720F0 File Offset: 0x000702F0
	private void method_40(GClass58 gclass58_1)
	{
		byte[] array = this.method_42(gclass58_1.byte_0[0]);
		if (array.Length < 4)
		{
			string text = string.Empty;
			base.method_31(false, GClass62.smethod_1("6052"), text);
		}
		else
		{
			for (int i = 3; i < gclass58_1.byte_0[1].Length; i++)
			{
				byte b = 0;
				if (array.Length > i)
				{
					b = array[i];
				}
				if (gclass58_1.int_0 <= i - 2 && gclass58_1.int_0 + gclass58_1.int_1 > i - 2)
				{
					byte b2 = gclass58_1.byte_0[1][i];
					byte b3 = byte.Parse(gclass58_1.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
					b3 ^= byte.MaxValue;
					b &= b3;
					b |= b2;
				}
				gclass58_1.byte_0[1][i] = b;
			}
			Thread.Sleep(1000);
			array = this.method_42(gclass58_1.byte_0[1]);
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_42(gclass58_1.byte_0[1]);
			}
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_42(gclass58_1.byte_0[1]);
			}
			if (array.Length == 0 || (array.Length > 1 && array[1] == 127))
			{
				string text = string.Empty;
				if (array.Length > 3 && array[3] == 34)
				{
					text = GClass62.smethod_1("6053");
				}
				else if (array.Length > 3 && array[3] == 17)
				{
					text = GClass62.smethod_1("6054");
				}
				base.method_31(false, GClass62.smethod_1("6052"), text);
			}
			else
			{
				Thread.Sleep(1000);
				base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
			}
		}
	}

	// Token: 0x06000367 RID: 871 RVA: 0x000722D8 File Offset: 0x000704D8
	public override string vmethod_0(byte[] byte_8, string string_16, int int_11, int int_12, string[] string_17, string string_18)
	{
		byte[] array = this.method_42(byte_8);
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_42(byte_8);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_42(byte_8);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_42(byte_8);
		}
		if (array.Length == 0)
		{
			array = this.method_42(byte_8);
		}
		return this.vmethod_7(array, string_16, int_11, int_12, string_17, string_18);
	}

	// Token: 0x06000368 RID: 872 RVA: 0x00072380 File Offset: 0x00070580
	private byte[] method_41(byte[] byte_8)
	{
		string str = string.Empty;
		while (GClass3.smethod_1() < this.int_0 + this.int_7)
		{
			Thread.Sleep(1);
		}
		this.serialPort_0.ReadExisting();
		byte b = 0;
		List<byte> list = new List<byte>();
		try
		{
			byte b2 = byte_8[0];
			if (!this.bool_5)
			{
				b2 |= 128;
			}
			str = this.method_45(b2);
			b += b2;
			list.Add(b2);
			if (!this.bool_5)
			{
				str += this.method_45(this.byte_0);
				b += this.byte_0;
				str += this.method_45(241);
				b += 241;
				list.Add(this.byte_0);
				list.Add(241);
			}
			for (int i = 1; i < byte_8.Length; i++)
			{
				str += this.method_45(byte_8[i]);
				b += byte_8[i];
				list.Add(byte_8[i]);
			}
			str += this.method_45(b);
			list.Add(b);
		}
		finally
		{
			GClass3.smethod_2(str, 0);
		}
		this.method_46(list.ToArray());
		return this.method_47();
	}

	// Token: 0x06000369 RID: 873 RVA: 0x000724C4 File Offset: 0x000706C4
	private byte[] method_42(byte[] byte_8)
	{
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			byte[] array = this.method_41(byte_8);
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_41(byte_8);
			}
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_41(byte_8);
			}
			if (array.Length > 3 && array[1] == 127 && array[3] == 120)
			{
				this.serialPort_0.ReadTimeout = this.int_8;
				try
				{
					GClass3.smethod_2("Waiting pending answer ...", 1);
					while (array.Length > 3 && array[1] == 127 && array[3] == 120)
					{
						array = this.method_47();
					}
				}
				catch (Exception)
				{
				}
				if (array.Length > 2 && array[1] != 127)
				{
					GClass3.smethod_2("Success!", 1);
				}
				this.method_41(this.byte_3);
				this.serialPort_0.ReadTimeout = this.int_6 + 20;
			}
			this.bool_2 = false;
			this.int_1 = 0;
			result = array;
		}
		catch (Exception ex)
		{
			if (!this.bool_1)
			{
				GClass3.smethod_2(ex.Message + "(3)", 1);
				if (this.int_1 > 3)
				{
					if (!this.method_33())
					{
						this.bool_2 = false;
						GClass3.smethod_2("Terminate 5", 1);
						base.method_22(true);
					}
				}
				else
				{
					this.int_1++;
					try
					{
						for (int i = 0; i < 20; i++)
						{
							byte b = (byte)this.serialPort_0.ReadByte();
						}
					}
					catch (Exception)
					{
					}
				}
			}
			this.bool_2 = false;
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x0600036A RID: 874 RVA: 0x00020014 File Offset: 0x0001E214
	private byte method_43(byte[] byte_8)
	{
		byte b = 0;
		for (int i = 0; i < byte_8.Length; i++)
		{
			b += byte_8[i];
		}
		return b;
	}

	// Token: 0x0600036B RID: 875 RVA: 0x00019948 File Offset: 0x00017B48
	public override string vmethod_7(byte[] byte_8, string string_16, int int_11, int int_12, string[] string_17, string string_18)
	{
		string text = string.Empty;
		int_11 += 2;
		string result;
		if (byte_8.Length <= int_11)
		{
			result = text;
		}
		else if (byte_8[1] == 127)
		{
			result = text;
		}
		else
		{
			int num = byte_8.Length - int_11;
			if (int_12 < num)
			{
				num = int_12;
			}
			byte[] array = new byte[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = byte_8[i + int_11];
			}
			text = base.method_32(array, string_16, string_17, string_18);
			result = text;
		}
		return result;
	}

	// Token: 0x0600036C RID: 876 RVA: 0x000726D0 File Offset: 0x000708D0
	private string method_44(byte byte_8)
	{
		string text = string.Empty;
		while (GClass3.smethod_1() < this.int_0 + this.int_5)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_8
		}, 0, 1);
		this.int_0 = GClass3.smethod_1();
		text = string.Concat(new object[]
		{
			this.string_8,
			this.int_0,
			this.string_9,
			GClass16.smethod_0(byte_8)
		});
		byte b = (byte)this.serialPort_0.ReadByte();
		int num = GClass3.smethod_1() - this.int_0;
		this.int_0 += num / 2;
		if (num > 15)
		{
			this.int_3 = 25;
		}
		if (byte_8 != b)
		{
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				this.string_10,
				this.int_0,
				this.string_11,
				GClass16.smethod_0(b)
			});
			throw new Exception(this.string_12);
		}
		return text;
	}

	// Token: 0x0600036D RID: 877 RVA: 0x000727EC File Offset: 0x000709EC
	private string method_45(byte byte_8)
	{
		string result;
		if (!GClass61.smethod_49())
		{
			result = this.method_44(byte_8);
		}
		else
		{
			while (GClass3.smethod_1() < this.int_0 + this.int_5)
			{
			}
			this.serialPort_0.Write(new byte[]
			{
				byte_8
			}, 0, 1);
			this.int_0 = GClass3.smethod_1() + 1;
			result = string.Concat(new object[]
			{
				this.string_8,
				this.int_0,
				this.string_9,
				GClass16.smethod_0(byte_8)
			});
		}
		return result;
	}

	// Token: 0x0600036E RID: 878 RVA: 0x00072880 File Offset: 0x00070A80
	private void method_46(byte[] byte_8)
	{
		if (GClass61.smethod_49())
		{
			bool flag = true;
			for (int i = 0; i < byte_8.Length; i++)
			{
				byte b = (byte)this.serialPort_0.ReadByte();
				if (byte_8[i] != b)
				{
					GClass3.smethod_2("ERROR: Invalid echo: " + GClass16.smethod_0(byte_8[i]) + "->" + GClass16.smethod_0(b), 0);
					flag = false;
				}
			}
			if (this.int_0 + 20 < GClass3.smethod_1())
			{
				this.int_3 = 25;
			}
			if (!flag)
			{
				throw new Exception("Invalid echo!");
			}
		}
	}

	// Token: 0x0600036F RID: 879 RVA: 0x0007290C File Offset: 0x00070B0C
	private byte[] method_47()
	{
		byte b = (byte)this.serialPort_0.ReadByte();
		byte b2 = 0 + b;
		string str = string.Empty;
		if (b >= 128)
		{
			b &= 63;
			b2 += (byte)this.serialPort_0.ReadByte();
			byte b3 = (byte)this.serialPort_0.ReadByte();
			b2 += b3;
			str = this.string_14 + GClass16.smethod_0(b3) + this.string_15;
		}
		byte[] array = new byte[(int)(b + 1)];
		array[0] = b;
		for (int i = 0; i < (int)b; i++)
		{
			array[i + 1] = (byte)this.serialPort_0.ReadByte();
			b2 += array[i + 1];
		}
		byte b4 = (byte)this.serialPort_0.ReadByte();
		this.int_0 = GClass3.smethod_1();
		GClass3.smethod_2(this.string_13 + str + GClass16.smethod_1(array), 0);
		if (b2 != b4)
		{
			GClass3.smethod_2("ERROR: Invalid response checksum! [" + GClass16.smethod_0(b4) + "]", 0);
			throw new Exception("Invalid response checksum! [" + GClass16.smethod_0(b4) + "]");
		}
		return array;
	}

	// Token: 0x06000370 RID: 880 RVA: 0x00072A34 File Offset: 0x00070C34
	private void method_48()
	{
		GClass3.smethod_2("PM started", 1);
		GClass3.int_2 = 0;
		SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
		while (!this.bool_1)
		{
			if (GClass61.smethod_47() == 2)
			{
				Thread.Sleep(10);
			}
			else if (GClass61.smethod_47() == 1)
			{
				Thread.Sleep(30);
			}
			else
			{
				Thread.Sleep(60);
			}
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
									97,
									72,
									1,
									14
								},
								new byte[]
								{
									13,
									90,
									145,
									53,
									53,
									49,
									56,
									56,
									50,
									49,
									52,
									32,
									32,
									32
								},
								new byte[]
								{
									13,
									90,
									146,
									48,
									50,
									56,
									49,
									48,
									49,
									49,
									52,
									50,
									49,
									32
								},
								new byte[]
								{
									3,
									90,
									147,
									0
								},
								new byte[]
								{
									13,
									90,
									148,
									49,
									48,
									51,
									55,
									51,
									54,
									55,
									55,
									57,
									48,
									32
								},
								new byte[]
								{
									4,
									90,
									149,
									160,
									68
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
								},
								new byte[]
								{
									6,
									90,
									5,
									9,
									17,
									31,
									37,
									9,
									17,
									31,
									33,
									21
								}
							};
							gclass.method_1(string.Concat(this.random_0.Next(0, 100)));
							if (gclass.string_3 == "V")
							{
								gclass.method_1(this.vmethod_7(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							else if (gclass.string_2.StartsWith("bits"))
							{
								gclass.method_1(this.vmethod_7(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							else if (gclass.string_2.StartsWith("bitchars"))
							{
								gclass.method_1(this.vmethod_7(array[7], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							Thread.Sleep(this.int_7);
						}
						else
						{
							if (sortedList.ContainsKey(GClass16.smethod_1(gclass.byte_0[0])))
							{
								byte[] value = sortedList[GClass16.smethod_1(gclass.byte_0[0])];
								gclass.method_1(this.vmethod_7(value, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							else
							{
								byte[] value = this.method_42(gclass.byte_0[0]);
								gclass.method_1(this.vmethod_7(value, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								sortedList.Add(GClass16.smethod_1(gclass.byte_0[0]), value);
							}
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
					GClass3.smethod_0().method_3(GClass3.int_2, this.string_6);
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
				}
				sortedList.Clear();
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

	// Token: 0x06000371 RID: 881 RVA: 0x00072EB8 File Offset: 0x000710B8
	private void method_49()
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
			if (GClass3.smethod_1() > this.int_0 + this.int_9 && !this.bool_2)
			{
				byte[] array = this.method_42(this.byte_3);
				if (array.Length < 2 || array[0] != 1 || array[1] != 126)
				{
					array = this.method_42(this.byte_3);
					if (array.Length < 2 || array[0] != 1 || array[1] != 126)
					{
						GClass3.smethod_2("KA response error!", 1);
						if (array.Length == 0 && this.int_1 > 2 && !this.method_33())
						{
							GClass3.smethod_2("Terminate 7", 1);
							base.method_22(true);
						}
					}
				}
			}
		}
		GClass3.smethod_2("KA stopped", 1);
	}

	// Token: 0x040004DF RID: 1247
	private int int_5 = 8;

	// Token: 0x040004E0 RID: 1248
	private int int_6 = 50;

	// Token: 0x040004E1 RID: 1249
	private int int_7 = 70;

	// Token: 0x040004E2 RID: 1250
	private int int_8 = 5000;

	// Token: 0x040004E3 RID: 1251
	private int int_9 = 800;

	// Token: 0x040004E4 RID: 1252
	private byte[] byte_2 = new byte[]
	{
		129,
		0,
		241,
		129
	};

	// Token: 0x040004E5 RID: 1253
	private byte[] byte_3 = new byte[]
	{
		1,
		62
	};

	// Token: 0x040004E6 RID: 1254
	private bool bool_5 = true;

	// Token: 0x040004E7 RID: 1255
	private byte[] byte_4 = new byte[]
	{
		5,
		88,
		3,
		7,
		4,
		56,
		21,
		85,
		50,
		2,
		53,
		48,
		161
	};

	// Token: 0x040004E8 RID: 1256
	private byte[] byte_5 = new byte[]
	{
		4,
		24,
		0,
		byte.MaxValue,
		0
	};

	// Token: 0x040004E9 RID: 1257
	private byte[] byte_6 = new byte[]
	{
		3,
		20,
		byte.MaxValue,
		0
	};

	// Token: 0x040004EA RID: 1258
	private byte[] byte_7;

	// Token: 0x040004EB RID: 1259
	private int int_10;

	// Token: 0x040004EC RID: 1260
	private string[] string_7;

	// Token: 0x040004ED RID: 1261
	private string string_8;

	// Token: 0x040004EE RID: 1262
	private string string_9;

	// Token: 0x040004EF RID: 1263
	private string string_10;

	// Token: 0x040004F0 RID: 1264
	private string string_11;

	// Token: 0x040004F1 RID: 1265
	private string string_12;

	// Token: 0x040004F2 RID: 1266
	private string string_13;

	// Token: 0x040004F3 RID: 1267
	private string string_14;

	// Token: 0x040004F4 RID: 1268
	private string string_15;
}
