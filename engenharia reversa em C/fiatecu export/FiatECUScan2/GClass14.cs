using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Threading;

// Token: 0x02000092 RID: 146
public sealed class GClass14 : GClass4
{
	// Token: 0x06000542 RID: 1346 RVA: 0x0009C7D4 File Offset: 0x0009A9D4
	public GClass14(byte byte_7, List<GClass58> list_3, List<GClass58> list_4)
	{
		this.byte_0 = byte_7;
		this.list_0 = list_4;
		this.list_1 = list_3;
	}

	// Token: 0x06000543 RID: 1347 RVA: 0x0009C904 File Offset: 0x0009AB04
	public override void vmethod_1(FormNotify formNotify_0, bool bool_6)
	{
		try
		{
			this.byte_2[1] = this.byte_0;
			this.int_1 = 0;
			int num = 0;
			byte b = 239;
			this.bool_5 = false;
			if (!bool_6)
			{
				for (int i = 0; i < 5; i++)
				{
					if (formNotify_0 != null && formNotify_0.method_0())
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
				Thread.Sleep(2000);
				GClass3.smethod_2("Testing mode!", 1);
				for (int i = 0; i < this.list_1.Count; i++)
				{
					GClass58 gclass = this.list_1[i];
					string text = this.vmethod_6(array[i], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
					gclass.method_1(text);
					if (gclass.int_2 == 1770)
					{
						this.string_1 = text;
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_46))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				base.method_26();
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
				this.string_2 = ex.Message;
				GClass3.smethod_2(ex.Message, 1);
				throw new Exception("0");
			}
			if (formNotify_0 != null && formNotify_0.method_0())
			{
				throw new Exception("ESC");
			}
			int j = 4;
			if (bool_6)
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
						GClass3.smethod_2(this.method_42(this.byte_2[i]), 0);
					}
					byte byte_ = this.method_41(this.byte_2);
					GClass3.smethod_2(this.method_42(byte_), 0);
					byte[] array2 = this.method_45();
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
						array2 = this.method_40(new byte[]
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
						array2 = this.method_40(array3);
						if (array2.Length == 8)
						{
							array2[1] = 131;
							array2[2] = 3;
							array2 = this.method_40(array2);
						}
						num3 = 2;
					}
					else if (GClass61.smethod_47() == 2)
					{
						array2 = this.method_40(new byte[]
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
						array2 = this.method_40(new byte[]
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
					array2 = this.method_40(new byte[]
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
					if (formNotify_0 != null && formNotify_0.method_0())
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(5000);
				}
			}
			GClass3.smethod_2("ECU wakeup completed", 1);
			if (formNotify_0 != null && formNotify_0.method_0())
			{
				throw new Exception("ESC");
			}
			if (!bool_6)
			{
				Thread thread = new Thread(new ThreadStart(this.method_47));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_46))
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
					this.string_1 = text;
					GClass3.smethod_2("ECU ISO Code: " + text, 2);
				}
			}
			if (bool_6)
			{
				base.method_21(false);
			}
			else
			{
				this.bool_0 = true;
				base.method_26();
				while ((num > GClass3.smethod_1() || this.bool_2) && !this.bool_1)
				{
					Thread.Sleep(20);
				}
				if (!this.bool_1)
				{
					if (this.string_1 == "7C 86 02 98 F1")
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
				this.string_2 = "Aborted by user";
			}
			if (ex2.Message == "1")
			{
				this.string_2 = "No ECU response";
			}
			GClass3.smethod_2(ex2.Message, 2);
			GClass3.smethod_2("Terminate 4", 1);
			base.method_21(ex2.Message != "1" && ex2.Message != "0" && ex2.Message != "ESC");
		}
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x0009D250 File Offset: 0x0009B450
	private bool method_31()
	{
		return this.method_32() ?? this.method_32();
	}

	// Token: 0x06000545 RID: 1349 RVA: 0x0009D270 File Offset: 0x0009B470
	private bool method_32()
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
					GClass3.smethod_2(this.method_42(this.byte_2[i]), 0);
				}
				byte byte_ = this.method_41(this.byte_2);
				GClass3.smethod_2(this.method_42(byte_), 0);
				byte[] array = this.method_45();
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

	// Token: 0x06000546 RID: 1350 RVA: 0x0001F078 File Offset: 0x0001D278
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
				base.method_27(bool_7);
			}
		}
	}

	// Token: 0x06000547 RID: 1351 RVA: 0x0009D524 File Offset: 0x0009B724
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
			array = this.method_40(this.byte_5);
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
				gclass.string_4 = this.method_33(gclass.byte_0);
				gclass.string_5 = this.method_34(gclass.byte_0);
				gclass.string_6 = this.method_35(gclass.byte_0);
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

	// Token: 0x06000548 RID: 1352 RVA: 0x00018938 File Offset: 0x00016B38
	private string method_33(byte byte_7)
	{
		string result = string.Empty;
		if ((byte_7 & 8) != 0)
		{
			result = GClass62.smethod_1("3056");
		}
		else if ((byte_7 & 4) != 0)
		{
			result = GClass62.smethod_1("3057");
		}
		else if ((byte_7 & 2) != 0)
		{
			result = GClass62.smethod_1("3058");
		}
		else if ((byte_7 & 1) != 0)
		{
			result = GClass62.smethod_1("3059");
		}
		return result;
	}

	// Token: 0x06000549 RID: 1353 RVA: 0x000189A0 File Offset: 0x00016BA0
	private string method_34(byte byte_7)
	{
		string result = string.Empty;
		if ((byte_7 & 96) == 0)
		{
			result = GClass62.smethod_1("3052");
		}
		else if ((byte_7 & 96) == 32)
		{
			result = GClass62.smethod_1("3053");
		}
		else if ((byte_7 & 96) == 64)
		{
			result = GClass62.smethod_1("3054");
		}
		else if ((byte_7 & 96) == 96)
		{
			result = GClass62.smethod_1("3055");
		}
		return result;
	}

	// Token: 0x0600054A RID: 1354 RVA: 0x00018A1C File Offset: 0x00016C1C
	private string method_35(byte byte_7)
	{
		string result = string.Empty;
		if ((byte_7 & 128) != 0)
		{
			result = GClass62.smethod_1("3051");
		}
		return result;
	}

	// Token: 0x0600054B RID: 1355 RVA: 0x0009D8F0 File Offset: 0x0009BAF0
	public override void vmethod_4()
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
			byte[] array = this.method_40(this.byte_6);
			if (array.Length < 3 || array[1] != 84)
			{
				GClass3.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
	}

	// Token: 0x0600054C RID: 1356 RVA: 0x0009D94C File Offset: 0x0009BB4C
	protected override void vmethod_5(GClass58 gclass58_1)
	{
		if (GClass3.bool_0)
		{
			Thread.Sleep(3000);
			if (gclass58_1.string_2.Contains("FUNC"))
			{
				base.method_29(true, GClass62.smethod_1("6051"), GClass62.smethod_1("6055") + " 00");
			}
			else
			{
				base.method_29(false, GClass62.smethod_1("6051"), string.Empty);
			}
		}
		else if (gclass58_1.string_2.Contains("FUNC"))
		{
			this.method_37(gclass58_1);
		}
		else if (gclass58_1.string_2.Contains("RWUSERENTRY"))
		{
			this.method_38(gclass58_1);
		}
		else
		{
			this.method_36(gclass58_1);
		}
	}

	// Token: 0x0600054D RID: 1357 RVA: 0x0009DA04 File Offset: 0x0009BC04
	private void method_36(GClass58 gclass58_1)
	{
		byte[] array = this.method_40(gclass58_1.byte_0[0]);
		int num = 2000;
		if (!gclass58_1.string_2.Contains("0.5SEC"))
		{
			if (!gclass58_1.string_2.Contains("1SEC"))
			{
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
					base.method_29(false, GClass62.smethod_1("6052"), text);
					return;
				}
				if (gclass58_1.string_2.Contains("IORESULT"))
				{
					int i = 60;
					if (gclass58_1.string_2.Contains("WAITY"))
					{
						while (i > 0 && !GClass3.bool_13)
						{
							Thread.Sleep(500);
							i--;
						}
					}
					else
					{
						Thread.Sleep(10000);
					}
					string text2 = GClass62.smethod_1("6052");
					string text3 = string.Empty;
					if (i > 0)
					{
						text2 = GClass62.smethod_1("6051");
						text3 = GClass62.smethod_1("6055") + this.vmethod_0(gclass58_1.byte_0[1], "bits", gclass58_1.int_0, gclass58_1.int_1, gclass58_1.string_5, gclass58_1.string_6);
					}
					base.method_29(false, text2, text3);
					return;
				}
				if (gclass58_1.byte_0.Length > 2)
				{
					for (int i = 1; i < gclass58_1.byte_0.Length; i++)
					{
						Thread.Sleep(num);
						this.method_40(gclass58_1.byte_0[i]);
					}
				}
				else if (gclass58_1.byte_0.Length == 2)
				{
					for (int i = 1; i < gclass58_1.byte_0.Length; i++)
					{
						Thread.Sleep(num);
						if (num > 1000)
						{
							Thread.Sleep(3 * num);
						}
						this.method_40(gclass58_1.byte_0[i]);
					}
				}
				else
				{
					Thread.Sleep(num);
					if (num > 1000)
					{
						Thread.Sleep(4 * num);
					}
				}
			}
		}
		base.method_29(false, GClass62.smethod_1("6051"), string.Empty);
	}

	// Token: 0x0600054E RID: 1358 RVA: 0x0009DC74 File Offset: 0x0009BE74
	private void method_37(GClass58 gclass58_1)
	{
		byte[] array = this.method_40(gclass58_1.byte_0[0]);
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
			base.method_29(false, GClass62.smethod_1("6052"), text);
		}
		else
		{
			byte[] array2 = new byte[3];
			array2[0] = 2;
			array2[1] = 51;
			byte[] array3 = array2;
			array3[2] = gclass58_1.byte_0[0][2];
			int num = 1800;
			bool flag = true;
			while (num > 0 && flag)
			{
				Thread.Sleep(500);
				GClass3.smethod_2("Checking routine status..", 1);
				array = this.method_40(array3);
				if (array.Length <= 3 || array[1] != 127 || array[2] != 51 || (array[3] != 33 && array[3] != 35))
				{
					flag = false;
				}
				num--;
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
			base.method_29(true, GClass62.smethod_1("6051"), text2);
		}
	}

	// Token: 0x0600054F RID: 1359 RVA: 0x0009DF9C File Offset: 0x0009C19C
	private void method_38(GClass58 gclass58_1)
	{
		byte[] array = this.method_40(gclass58_1.byte_0[0]);
		if (array.Length < 4)
		{
			string text = string.Empty;
			base.method_29(false, GClass62.smethod_1("6052"), text);
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
			array = this.method_40(gclass58_1.byte_0[1]);
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_40(gclass58_1.byte_0[1]);
			}
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_40(gclass58_1.byte_0[1]);
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
				base.method_29(false, GClass62.smethod_1("6052"), text);
			}
			else
			{
				Thread.Sleep(1000);
				base.method_29(false, GClass62.smethod_1("6051"), string.Empty);
			}
		}
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x0009E184 File Offset: 0x0009C384
	public override string vmethod_0(byte[] byte_7, string string_13, int int_11, int int_12, string[] string_14, string string_15)
	{
		byte[] array = this.method_40(byte_7);
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_40(byte_7);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_40(byte_7);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_40(byte_7);
		}
		if (array.Length == 0)
		{
			array = this.method_40(byte_7);
		}
		return this.vmethod_6(array, string_13, int_11, int_12, string_14, string_15);
	}

	// Token: 0x06000551 RID: 1361 RVA: 0x0009E22C File Offset: 0x0009C42C
	private byte[] method_39(byte[] byte_7)
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
			byte b2 = byte_7[0];
			if (!this.bool_5)
			{
				b2 |= 128;
			}
			str = this.method_43(b2);
			b += b2;
			list.Add(b2);
			if (!this.bool_5)
			{
				str += this.method_43(this.byte_0);
				b += this.byte_0;
				str += this.method_43(241);
				b += 241;
				list.Add(this.byte_0);
				list.Add(241);
			}
			for (int i = 1; i < byte_7.Length; i++)
			{
				str += this.method_43(byte_7[i]);
				b += byte_7[i];
				list.Add(byte_7[i]);
			}
			str += this.method_43(b);
			list.Add(b);
		}
		finally
		{
			GClass3.smethod_2(str, 0);
		}
		this.method_44(list.ToArray());
		return this.method_45();
	}

	// Token: 0x06000552 RID: 1362 RVA: 0x0009E370 File Offset: 0x0009C570
	private byte[] method_40(byte[] byte_7)
	{
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			byte[] array = this.method_39(byte_7);
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_39(byte_7);
			}
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_39(byte_7);
			}
			if (array.Length > 3 && array[1] == 127 && array[3] == 120)
			{
				this.serialPort_0.ReadTimeout = this.int_8;
				try
				{
					GClass3.smethod_2("Waiting pending answer ...", 1);
					while (array.Length > 3 && array[1] == 127 && array[3] == 120)
					{
						array = this.method_45();
					}
				}
				catch (Exception)
				{
				}
				if (array.Length > 2 && array[1] != 127)
				{
					GClass3.smethod_2("Success!", 1);
				}
				this.method_39(this.byte_3);
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
					if (!this.method_31())
					{
						this.bool_2 = false;
						GClass3.smethod_2("Terminate 5", 1);
						base.method_21(true);
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

	// Token: 0x06000553 RID: 1363 RVA: 0x00020014 File Offset: 0x0001E214
	private byte method_41(byte[] byte_7)
	{
		byte b = 0;
		for (int i = 0; i < byte_7.Length; i++)
		{
			b += byte_7[i];
		}
		return b;
	}

	// Token: 0x06000554 RID: 1364 RVA: 0x0005E56C File Offset: 0x0005C76C
	public override string vmethod_6(byte[] byte_7, string string_13, int int_11, int int_12, string[] string_14, string string_15)
	{
		string text = string.Empty;
		int_11 += 2;
		string result;
		if (byte_7.Length <= int_11)
		{
			result = text;
		}
		else if (byte_7[1] == 127)
		{
			result = text;
		}
		else
		{
			int num = byte_7.Length - int_11;
			if (int_12 < num)
			{
				num = int_12;
			}
			byte[] array = new byte[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = byte_7[i + int_11];
			}
			text = base.method_30(array, string_13, string_14, string_15);
			result = text;
		}
		return result;
	}

	// Token: 0x06000555 RID: 1365 RVA: 0x0009E57C File Offset: 0x0009C77C
	private string method_42(byte byte_7)
	{
		string text = string.Empty;
		while (GClass3.smethod_1() < this.int_0 + this.int_5)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_7
		}, 0, 1);
		this.int_0 = GClass3.smethod_1();
		text = string.Concat(new object[]
		{
			this.string_5,
			this.int_0,
			this.string_6,
			GClass16.smethod_0(byte_7)
		});
		byte b = (byte)this.serialPort_0.ReadByte();
		int num = GClass3.smethod_1() - this.int_0;
		this.int_0 += num / 2;
		if (num > 15)
		{
			this.int_3 = 25;
		}
		if (byte_7 != b)
		{
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				this.string_7,
				this.int_0,
				this.string_8,
				GClass16.smethod_0(b)
			});
			throw new Exception(this.string_9);
		}
		return text;
	}

	// Token: 0x06000556 RID: 1366 RVA: 0x0009E698 File Offset: 0x0009C898
	private string method_43(byte byte_7)
	{
		string result;
		if (!GClass61.smethod_49())
		{
			result = this.method_42(byte_7);
		}
		else
		{
			while (GClass3.smethod_1() < this.int_0 + this.int_5)
			{
			}
			this.serialPort_0.Write(new byte[]
			{
				byte_7
			}, 0, 1);
			this.int_0 = GClass3.smethod_1() + 1;
			result = string.Concat(new object[]
			{
				this.string_5,
				this.int_0,
				this.string_6,
				GClass16.smethod_0(byte_7)
			});
		}
		return result;
	}

	// Token: 0x06000557 RID: 1367 RVA: 0x0009E72C File Offset: 0x0009C92C
	private void method_44(byte[] byte_7)
	{
		if (GClass61.smethod_49())
		{
			bool flag = true;
			for (int i = 0; i < byte_7.Length; i++)
			{
				byte b = (byte)this.serialPort_0.ReadByte();
				if (byte_7[i] != b)
				{
					GClass3.smethod_2("ERROR: Invalid echo: " + GClass16.smethod_0(byte_7[i]) + "->" + GClass16.smethod_0(b), 0);
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

	// Token: 0x06000558 RID: 1368 RVA: 0x0009E7B8 File Offset: 0x0009C9B8
	private byte[] method_45()
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
			str = this.string_11 + GClass16.smethod_0(b3) + this.string_12;
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
		GClass3.smethod_2(this.string_10 + str + GClass16.smethod_1(array), 0);
		if (b2 != b4)
		{
			GClass3.smethod_2("ERROR: Invalid response checksum! [" + GClass16.smethod_0(b4) + "]", 0);
			throw new Exception("Invalid response checksum! [" + GClass16.smethod_0(b4) + "]");
		}
		return array;
	}

	// Token: 0x06000559 RID: 1369 RVA: 0x0009E8E0 File Offset: 0x0009CAE0
	private void method_46()
	{
		GClass3.smethod_2("PM started", 1);
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
								gclass.method_1(this.vmethod_6(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							else if (gclass.string_2.StartsWith("bits"))
							{
								gclass.method_1(this.vmethod_6(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							else if (gclass.string_2.StartsWith("bitchars"))
							{
								gclass.method_1(this.vmethod_6(array[7], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							Thread.Sleep(this.int_7);
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
					this.string_4 = text;
				}
				else
				{
					this.string_4 = string.Empty;
				}
				if (GClass3.bool_4 && GClass3.list_1.Count > 0)
				{
					GClass3.smethod_0().method_3(GClass3.int_2, this.string_4);
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

	// Token: 0x0600055A RID: 1370 RVA: 0x0009ECD0 File Offset: 0x0009CED0
	private void method_47()
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
				byte[] array = this.method_40(this.byte_3);
				if (array.Length < 2 || array[0] != 1 || array[1] != 126)
				{
					array = this.method_40(this.byte_3);
					if (array.Length < 2 || array[0] != 1 || array[1] != 126)
					{
						GClass3.smethod_2("KA response error!", 1);
						if (array.Length == 0 && this.int_1 > 2 && !this.method_31())
						{
							GClass3.smethod_2("Terminate 7", 1);
							base.method_21(true);
						}
					}
				}
			}
		}
		GClass3.smethod_2("KA stopped", 1);
	}

	// Token: 0x04000690 RID: 1680
	private int int_5 = 8;

	// Token: 0x04000691 RID: 1681
	private int int_6 = 50;

	// Token: 0x04000692 RID: 1682
	private int int_7 = 70;

	// Token: 0x04000693 RID: 1683
	private int int_8 = 5000;

	// Token: 0x04000694 RID: 1684
	private int int_9 = 800;

	// Token: 0x04000695 RID: 1685
	private byte[] byte_2 = new byte[]
	{
		129,
		0,
		241,
		129
	};

	// Token: 0x04000696 RID: 1686
	private byte[] byte_3 = new byte[]
	{
		1,
		62
	};

	// Token: 0x04000697 RID: 1687
	private bool bool_5 = true;

	// Token: 0x04000698 RID: 1688
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

	// Token: 0x04000699 RID: 1689
	private byte[] byte_5 = new byte[]
	{
		4,
		24,
		0,
		byte.MaxValue,
		0
	};

	// Token: 0x0400069A RID: 1690
	private byte[] byte_6 = new byte[]
	{
		3,
		20,
		byte.MaxValue,
		0
	};

	// Token: 0x0400069B RID: 1691
	private int int_10 = 0;

	// Token: 0x0400069C RID: 1692
	private string string_5 = " <";

	// Token: 0x0400069D RID: 1693
	private string string_6 = "> Sent: ";

	// Token: 0x0400069E RID: 1694
	private string string_7 = " <";

	// Token: 0x0400069F RID: 1695
	private string string_8 = "> ERROR: Invalid echo: ";

	// Token: 0x040006A0 RID: 1696
	private string string_9 = "Invalid echo!";

	// Token: 0x040006A1 RID: 1697
	private string string_10 = "Received: ";

	// Token: 0x040006A2 RID: 1698
	private string string_11 = "[";

	// Token: 0x040006A3 RID: 1699
	private string string_12 = "] ";
}
