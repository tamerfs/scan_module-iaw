using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Threading;

// Token: 0x02000054 RID: 84
public sealed class GClass92 : GClass11
{
	// Token: 0x06000331 RID: 817 RVA: 0x0004FB20 File Offset: 0x0004DD20
	public GClass92(byte byte_9, List<GClass104> list_6, List<GClass104> list_7)
	{
		byte[] array = new byte[4];
		array[0] = 3;
		array[1] = 23;
		this.byte_8 = array;
		this.string_22 = new string[]
		{
			"00 00 00 20 45 78 99 11 23 44 55 99",
			"00 00 00 38 22 99 12 65 29 81 02 00",
			"00 00 00 95 18 24 76 4A 6B 1F 00 00"
		};
		this.string_23 = " <";
		this.string_24 = "> Sent: ";
		this.string_25 = " <";
		this.string_26 = "> ERROR: Invalid echo: ";
		this.string_27 = "Invalid echo!";
		this.string_28 = "Received: ";
		this.string_29 = "[";
		this.string_30 = "] ";
		base..ctor();
		this.byte_0 = byte_9;
		this.list_0 = list_7;
		this.list_1 = list_6;
	}

	// Token: 0x06000332 RID: 818 RVA: 0x0004FCA0 File Offset: 0x0004DEA0
	public override void vmethod_1()
	{
		try
		{
			this.byte_3[1] = this.byte_0;
			this.double_1 = 0.0245;
			this.double_3 = 0.0495;
			this.int_1 = 0;
			int num = 0;
			byte b = 239;
			this.bool_6 = false;
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
				for (int j = 0; j < 20; j++)
				{
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(100);
				}
				GClass126.smethod_2("Testing mode!", 1);
				for (int k = 0; k < this.list_1.Count; k++)
				{
					GClass104 gclass = this.list_1[k];
					string text = this.r4(array[k], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
					gclass.method_1(text);
					if (gclass.int_2 == 10455)
					{
						this.string_7 = text;
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_60))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				base.method_36();
				throw new Exception("1");
			}
			try
			{
				this.serialPort_0 = new SerialPort(GClass125.smethod_55(), 10400, Parity.None, 8, StopBits.One);
				this.serialPort_0.WriteBufferSize = 2;
				this.serialPort_0.WriteTimeout = 5000;
				this.serialPort_0.ReceivedBytesThreshold = 1000;
				this.serialPort_0.Handshake = Handshake.None;
				this.serialPort_0.Open();
				GClass126.smethod_2("Serial port opened!", 1);
			}
			catch (Exception ex)
			{
				this.string_8 = ex.Message;
				GClass126.smethod_2(ex.Message, 1);
				throw new Exception("0");
			}
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			int l = 6;
			if (this.string_0 == "BPCM00")
			{
				l = 0;
			}
			if (this.genum0_0 != (GEnum0)0)
			{
				l = 1;
			}
			while (l > 0)
			{
				try
				{
					this.bool_7 = false;
					long num2 = 0L;
					GClass126.smethod_2("Fast wake up start", 1);
					this.serialPort_0.ReadTimeout = 1;
					num2 = GClass126.stopwatch_0.ElapsedTicks;
					this.serialPort_0.BreakState = true;
					while ((double)GClass126.stopwatch_0.ElapsedTicks < (double)num2 + 0.01 * (double)Stopwatch.Frequency)
					{
						Thread.Sleep(1);
					}
					while ((double)GClass126.stopwatch_0.ElapsedTicks < (double)num2 + this.double_1 * (double)Stopwatch.Frequency)
					{
					}
					this.serialPort_0.BreakState = false;
					while ((double)GClass126.stopwatch_0.ElapsedTicks < (double)num2 + 0.03 * (double)Stopwatch.Frequency)
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
					while ((double)GClass126.stopwatch_0.ElapsedTicks < (double)num2 + this.double_3 * (double)Stopwatch.Frequency)
					{
					}
					this.serialPort_0.Write(this.byte_3, 0, 1);
					GClass126.smethod_2("Sent: " + GClass127.smethod_23(this.byte_3[0]), 0);
					byte b2 = (byte)this.serialPort_0.ReadByte();
					this.int_0 = GClass126.smethod_1();
					num = this.int_0 + 8000;
					if (this.byte_3[0] != b2)
					{
						throw new Exception("ERROR: Invalid echo!");
					}
					for (int m = 1; m < this.byte_3.Length; m++)
					{
						GClass126.smethod_2(this.method_56(this.byte_3[m]), 0);
					}
					byte byte_ = this.method_55(this.byte_3);
					GClass126.smethod_2(this.method_56(byte_), 0);
					byte[] array2 = this.method_59();
					if (array2.Length >= 4)
					{
						if (array2[1] == 193)
						{
							b = array2[2];
							this.serialPort_0.ReadTimeout = 100;
							int num3 = 3;
							if (GClass125.smethod_63() != 0)
							{
								if (l != 1)
								{
									if (GClass125.smethod_63() == 1)
									{
										byte[] array3 = new byte[3];
										array3[0] = 2;
										array3[1] = 131;
										array2 = this.method_54(array3);
										if (array2.Length == 8)
										{
											array2[1] = 131;
											array2[2] = 3;
											array2 = this.method_54(array2);
										}
										num3 = 2;
										goto IL_5D9;
									}
									if (GClass125.smethod_63() == 2)
									{
										array2 = this.method_54(new byte[]
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
										goto IL_5D9;
									}
									if (GClass125.smethod_63() == 3)
									{
										array2 = this.method_54(new byte[]
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
										goto IL_5D9;
									}
									goto IL_5D9;
								}
							}
							array2 = this.method_54(new byte[]
							{
								2,
								131,
								1
							});
							IL_5D9:
							array2 = this.method_54(new byte[]
							{
								2,
								131,
								2
							});
							if (array2.Length < 8)
							{
								GClass126.smethod_2("WARNING: Unable to read timing data!", 1);
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
							l = 0;
							continue;
						}
					}
					GClass126.smethod_2("ERROR: Invalid wakeup response!", 1);
					throw new Exception("Invalid wakeup response!");
				}
				catch (Exception)
				{
					this.serialPort_0.BreakState = false;
					l--;
					if (l == 0)
					{
						throw new Exception("1");
					}
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					if (l == 4)
					{
						this.double_1 = 0.0247;
						this.double_3 = 0.0498;
					}
					else if (l == 3)
					{
						this.double_1 = 0.0243;
						this.double_3 = 0.0492;
					}
					else if (l == 2)
					{
						this.double_1 = 0.024;
						this.double_3 = 0.0488;
					}
					else if (l == 1)
					{
						this.double_1 = 0.0236;
						this.double_3 = 0.048;
					}
					for (int n = 0; n < 50; n++)
					{
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
				}
			}
			if (this.string_0 == "BPCM00")
			{
				l = 6;
				int num4 = 130;
				int num5 = 200;
				while (l > 0)
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
						for (int num6 = -1; num6 < bitArray.Length; num6++)
						{
							if (num6 == -1)
							{
								this.serialPort_0.RtsEnable = true;
								this.serialPort_0.BreakState = true;
							}
							else
							{
								this.serialPort_0.RtsEnable = !bitArray[num6];
								this.serialPort_0.BreakState = !bitArray[num6];
							}
							while (this.int_0 + num4 > GClass126.smethod_1())
							{
								Thread.Sleep(10);
							}
							while (this.int_0 + num5 > GClass126.smethod_1())
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
						this.serialPort_0.ReadTimeout = 500;
						this.int_0 = GClass126.smethod_1();
						GClass126.smethod_2("Waiting ECU response...", 1);
						byte b3 = (byte)this.serialPort_0.ReadByte();
						GClass126.smethod_2("Sync: " + GClass127.smethod_23(b3), 0);
						if (b3 != 85)
						{
							GClass126.smethod_2("ERROR: Invalid synchronization byte", 1);
							throw new Exception("Invalid synchronization byte");
						}
						byte b4 = (byte)this.serialPort_0.ReadByte();
						GClass126.smethod_2("K1: " + GClass127.smethod_23(b4), 0);
						byte b5 = (byte)this.serialPort_0.ReadByte();
						GClass126.smethod_2("K2: " + GClass127.smethod_23(b5), 0);
						b = b4;
						byte b6 = b5;
						b6 ^= byte.MaxValue;
						this.int_0 = GClass126.smethod_1();
						this.int_5 = 25;
						GClass126.smethod_2(this.method_56(b6), 0);
						this.int_5 = 8;
						byte b7 = (byte)this.serialPort_0.ReadByte();
						b7 ^= byte.MaxValue;
						GClass126.smethod_2("AC: " + GClass127.smethod_23(b7), 0);
						this.serialPort_0.ReadTimeout = 350;
						l = 0;
					}
					catch (Exception)
					{
						this.serialPort_0.BreakState = false;
						if (this.genum0_0 != (GEnum0)0)
						{
							l = 1;
						}
						l--;
						if (l == 0)
						{
							throw new Exception("1");
						}
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
						for (int num7 = 0; num7 < 25; num7++)
						{
							if (GClass126.bool_25)
							{
								throw new Exception("ESC");
							}
							Thread.Sleep(100);
						}
						if (l == 5)
						{
							num5 = 198;
						}
						else if (l == 4)
						{
							num5 = 196;
						}
						else if (l == 3)
						{
							num5 = 202;
						}
						else if (l == 2)
						{
							num5 = 198;
						}
						else if (l == 1)
						{
							num4 = 130;
							num5 = 199;
						}
					}
				}
			}
			GClass126.smethod_2("ECU wakeup completed", 1);
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			if (this.genum0_0 == (GEnum0)0)
			{
				Thread thread = new Thread(new ThreadStart(this.method_61));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_60))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				Thread.Sleep(100);
			}
			for (int num8 = 0; num8 < this.list_1.Count; num8++)
			{
				GClass104 gclass2 = this.list_1[num8];
				string text2 = this.vmethod_0(gclass2.byte_0[0], gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6);
				gclass2.method_1(text2);
				if (gclass2.int_2 == 10455)
				{
					this.string_7 = text2;
					GClass126.smethod_2("ECU ISO Code: " + text2, 0);
				}
			}
			if (this.genum0_0 == (GEnum0)2)
			{
				Thread.Sleep(200);
				this.list_4 = this.r1();
			}
			if (this.genum0_0 == (GEnum0)4)
			{
				Thread.Sleep(100);
				this.r2();
				Thread.Sleep(100);
				this.list_4 = this.r1();
			}
			if (this.genum0_0 != (GEnum0)0)
			{
				base.method_30(false);
			}
			else
			{
				if (GClass125.int_18[1] == 0 && GClass126.bool_13)
				{
					bool flag = true;
					if (GClass125.smethod_5().StartsWith(GClass122.smethod_2()))
					{
						GClass126.bool_13 = false;
					}
					else if (GClass125.int_18[4] == 4)
					{
						GClass126.bool_13 = false;
					}
					else
					{
						flag = false;
					}
					if (flag)
					{
						GClass126.smethod_2(">Start 36", 0);
					}
				}
				this.bool_0 = true;
				base.method_36();
				for (;;)
				{
					if (num <= GClass126.smethod_1())
					{
						if (!this.bool_2)
						{
							break;
						}
					}
					if (this.bool_1)
					{
						break;
					}
					Thread.Sleep(20);
				}
				if (!this.bool_1)
				{
					if (this.string_7 == "7C 86 02 98 F1")
					{
						b = 233;
					}
					if (b == 239)
					{
						this.bool_7 = false;
						this.bool_6 = true;
					}
					else if (b == 233)
					{
						this.bool_6 = false;
					}
					else if (b == 235)
					{
						this.bool_6 = false;
					}
					else
					{
						GClass126.smethod_2("WARNING: Unsupported message format!!!", 1);
					}
				}
			}
		}
		catch (Exception ex2)
		{
			if (ex2.Message == "ESC")
			{
				this.string_8 = GClass121.smethod_6("6060");
			}
			if (ex2.Message == "1")
			{
				this.string_8 = "No ECU response";
			}
			GClass126.smethod_2(ex2.Message, 2);
			GClass126.smethod_2("Terminate 4", 1);
			this.r0(ex2.Message != "1" && ex2.Message != "0" && ex2.Message != "ESC", ex2.Message == "ESC");
		}
	}

	// Token: 0x06000333 RID: 819 RVA: 0x00050AF0 File Offset: 0x0004ECF0
	private bool method_45()
	{
		return this.method_46() ?? this.method_46();
	}

	// Token: 0x06000334 RID: 820 RVA: 0x00050B10 File Offset: 0x0004ED10
	private bool method_46()
	{
		this.int_10++;
		if (this.int_10 > 20)
		{
			return false;
		}
		for (int i = 0; i < 10; i++)
		{
			if (this.bool_1)
			{
				return false;
			}
			Thread.Sleep(10);
		}
		this.bool_6 = false;
		this.bool_7 = false;
		bool result;
		try
		{
			long num = 0L;
			GClass126.smethod_2("Fast wake up start", 1);
			this.serialPort_0.ReadTimeout = 1;
			num = GClass126.stopwatch_0.ElapsedTicks;
			this.serialPort_0.BreakState = true;
			while ((double)GClass126.stopwatch_0.ElapsedTicks < (double)num + 0.01 * (double)Stopwatch.Frequency)
			{
				Thread.Sleep(1);
			}
			while ((double)GClass126.stopwatch_0.ElapsedTicks < (double)num + 0.0245 * (double)Stopwatch.Frequency)
			{
			}
			this.serialPort_0.BreakState = false;
			while ((double)GClass126.stopwatch_0.ElapsedTicks < (double)num + 0.03 * (double)Stopwatch.Frequency)
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
			while ((double)GClass126.stopwatch_0.ElapsedTicks < (double)num + 0.0495 * (double)Stopwatch.Frequency)
			{
			}
			this.serialPort_0.Write(this.byte_3, 0, 1);
			GClass126.smethod_2("Sent: " + GClass127.smethod_23(this.byte_3[0]), 0);
			byte b = (byte)this.serialPort_0.ReadByte();
			this.int_0 = GClass126.smethod_1();
			if (this.byte_3[0] != b)
			{
				throw new Exception("ERROR: Invalid echo!");
			}
			for (int j = 1; j < this.byte_3.Length; j++)
			{
				GClass126.smethod_2(this.method_56(this.byte_3[j]), 0);
			}
			byte byte_ = this.method_55(this.byte_3);
			GClass126.smethod_2(this.method_56(byte_), 0);
			byte[] array = this.method_59();
			if (array.Length < 4 || array[1] != 193)
			{
				GClass126.smethod_2("ERROR: Invalid wakeup response!", 1);
				throw new Exception("Invalid wakeup response!");
			}
			this.serialPort_0.ReadTimeout = 100;
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

	// Token: 0x06000335 RID: 821 RVA: 0x0004A968 File Offset: 0x00048B68
	public override void r0(bool bool_8, bool bool_9)
	{
		if (this.bool_1)
		{
			return;
		}
		GClass126.smethod_2("Terminating " + (bool_8 ? "with reconnect" : ""), 1);
		if (GClass126.bool_0 && !bool_9)
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
		base.method_32(bool_9);
	}

	// Token: 0x06000336 RID: 822 RVA: 0x00050DA8 File Offset: 0x0004EFA8
	public override List<GClass102> r1()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_5;
		}
		else
		{
			array = this.method_54(this.byte_6);
		}
		if (array.Length < 3)
		{
			GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
			return null;
		}
		int num = (int)array[2];
		int num2 = 0;
		int num3 = 3;
		while (num2 < num && num3 < array.Length - 2)
		{
			GClass102 gclass = new GClass102();
			gclass.string_0 = GClass127.smethod_11(new byte[]
			{
				array[num3],
				array[num3 + 1]
			}).Replace(" ", "");
			gclass.byte_0 = array[num3 + 2];
			gclass.string_5 = this.method_47(gclass.byte_0);
			gclass.string_6 = this.method_48(gclass.byte_0);
			gclass.string_7 = this.method_49(gclass.byte_0);
			gclass.bool_0 = ((gclass.byte_0 & 96) == 96);
			string str = "";
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
			gclass.string_2 = str + GClass127.smethod_11(new byte[]
			{
				array[num3] & 63,
				array[num3 + 1]
			}).Replace(" ", "");
			if ((gclass.byte_0 & 8) != 0)
			{
				GClass102 gclass2 = gclass;
				gclass2.string_3 = gclass2.string_3 + GClass121.smethod_6("3065") + " ";
			}
			else if ((gclass.byte_0 & 4) != 0)
			{
				GClass102 gclass3 = gclass;
				gclass3.string_3 = gclass3.string_3 + GClass121.smethod_6("3066") + " ";
			}
			else if ((gclass.byte_0 & 2) != 0)
			{
				GClass102 gclass4 = gclass;
				gclass4.string_3 = gclass4.string_3 + GClass121.smethod_6("3067") + " ";
			}
			else if ((gclass.byte_0 & 1) != 0)
			{
				GClass102 gclass5 = gclass;
				gclass5.string_3 = gclass5.string_3 + GClass121.smethod_6("3068") + " ";
			}
			if ((gclass.byte_0 & 96) == 0)
			{
				GClass102 gclass6 = gclass;
				gclass6.string_3 = gclass6.string_3 + GClass121.smethod_6("3075") + " ";
			}
			else if ((gclass.byte_0 & 96) == 32)
			{
				GClass102 gclass7 = gclass;
				gclass7.string_3 = gclass7.string_3 + GClass121.smethod_6("3076") + " ";
			}
			else if ((gclass.byte_0 & 96) == 64)
			{
				GClass102 gclass8 = gclass;
				gclass8.string_3 = gclass8.string_3 + GClass121.smethod_6("3077") + " ";
			}
			else if ((gclass.byte_0 & 96) == 96)
			{
				GClass102 gclass9 = gclass;
				gclass9.string_3 = gclass9.string_3 + GClass121.smethod_6("3078") + " ";
			}
			if ((gclass.byte_0 & 128) == 0)
			{
				GClass102 gclass10 = gclass;
				gclass10.string_3 = gclass10.string_3 + GClass121.smethod_6("3073") + " ";
			}
			else
			{
				GClass102 gclass11 = gclass;
				gclass11.string_3 = gclass11.string_3 + GClass121.smethod_6("3074") + " ";
			}
			list.Add(gclass);
			num3 += 3;
		}
		return list;
	}

	// Token: 0x06000337 RID: 823 RVA: 0x00009148 File Offset: 0x00007348
	private string method_47(byte byte_9)
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

	// Token: 0x06000338 RID: 824 RVA: 0x000091A4 File Offset: 0x000073A4
	private string method_48(byte byte_9)
	{
		string result = "";
		if ((byte_9 & 96) == 0)
		{
			result = GClass121.smethod_6("3052");
		}
		else if ((byte_9 & 96) == 32)
		{
			result = GClass121.smethod_6("3053");
		}
		else if ((byte_9 & 96) == 64)
		{
			result = GClass121.smethod_6("3054");
		}
		else if ((byte_9 & 96) == 96)
		{
			result = GClass121.smethod_6("3055");
		}
		return result;
	}

	// Token: 0x06000339 RID: 825 RVA: 0x00006FC4 File Offset: 0x000051C4
	private string method_49(byte byte_9)
	{
		string result = "";
		if ((byte_9 & 128) != 0)
		{
			result = GClass121.smethod_6("3051");
		}
		return result;
	}

	// Token: 0x0600033A RID: 826 RVA: 0x00051124 File Offset: 0x0004F324
	public override void r2()
	{
		if (GClass126.bool_0)
		{
			this.byte_5 = new byte[]
			{
				2,
				88,
				0,
				90
			};
			return;
		}
		byte[] array = this.method_54(this.byte_7);
		if (array.Length < 3 || array[1] != 84)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x0600033B RID: 827 RVA: 0x00051178 File Offset: 0x0004F378
	public override void r7(List<GClass102> list_6, List<GClass104> list_7)
	{
		if (list_6 != null && list_7 != null && list_6.Count != 0 && list_7.Count != 0)
		{
			int num = this.string_22.Length;
			SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
			foreach (GClass102 gclass in list_6)
			{
				if (!(gclass.string_4 != ""))
				{
					if (num > 0)
					{
						num--;
					}
					sortedList.Clear();
					try
					{
						foreach (GClass104 gclass2 in list_7)
						{
							if (gclass2.string_1.Contains("*") || gclass2.string_1.Contains("[" + gclass.string_0 + "]"))
							{
								string text = GClass127.smethod_11(gclass2.byte_0[0]);
								text = text.Replace("00 00", gclass.string_0);
								byte[] byte_ = GClass127.smethod_32(text);
								byte[] value = new byte[0];
								if (GClass126.bool_0)
								{
									value = GClass127.smethod_32(this.string_22[num]);
								}
								else if (sortedList.ContainsKey(text))
								{
									value = sortedList[text];
								}
								else
								{
									value = this.method_54(byte_);
									sortedList.Add(text, value);
								}
								gclass2.method_1(this.r4(value, gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
								GClass102 gclass3 = gclass;
								gclass3.string_4 = string.Concat(new string[]
								{
									gclass3.string_4,
									gclass2.string_0,
									": ",
									gclass2.method_0(),
									" ",
									gclass2.string_3,
									Environment.NewLine
								});
							}
						}
						if (gclass.string_4 != "")
						{
							gclass.string_4 = GClass121.smethod_6("3047") + Environment.NewLine + gclass.string_4;
						}
					}
					catch (Exception)
					{
						GClass126.smethod_2("ERROR: Error reading DTC details", 0);
					}
				}
			}
			return;
		}
	}

	// Token: 0x0600033C RID: 828 RVA: 0x00051404 File Offset: 0x0004F604
	protected override void r3(GClass104 gclass104_1)
	{
		if (GClass126.bool_0)
		{
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
			return;
		}
		else
		{
			if (gclass104_1.string_2.Contains("FUNC"))
			{
				this.method_51(gclass104_1);
				return;
			}
			if (gclass104_1.string_2.Contains("RWUSERENTRY"))
			{
				this.method_52(gclass104_1);
				return;
			}
			this.method_50(gclass104_1);
			return;
		}
	}

	// Token: 0x0600033D RID: 829 RVA: 0x000514C0 File Offset: 0x0004F6C0
	private void method_50(GClass104 gclass104_1)
	{
		int num = 20;
		if (gclass104_1.string_2.Contains("0.5SEC"))
		{
			num = 5;
		}
		else if (gclass104_1.string_2.Contains("1SEC"))
		{
			num = 10;
		}
		else if (gclass104_1.string_2.Contains("20SEC"))
		{
			num = 200;
		}
		else if (gclass104_1.string_2.Contains("50SEC"))
		{
			num = 500;
		}
		else if (gclass104_1.string_2.Contains("NOWAIT"))
		{
			num = 0;
		}
		else if (gclass104_1.byte_0.Length == 2)
		{
			num = 3 * num;
		}
		else if (gclass104_1.byte_0.Length == 1)
		{
			num = 4 * num;
		}
		bool flag = gclass104_1.string_2.Contains("EXECANY");
		bool flag2 = gclass104_1.byte_0.Length > 1 && !gclass104_1.string_2.Contains("NOABORT");
		bool flag3 = gclass104_1.string_2.Contains("LASTCMDBITRESULT");
		if (gclass104_1.string_2.Contains("NOKEEPALIVE"))
		{
			this.bool_3 = true;
		}
		string a = "";
		string a2 = "";
		for (int i = 0; i < gclass104_1.byte_0.Length; i++)
		{
			if (gclass104_1.byte_0[i][0] == 255)
			{
				int num2 = 10 * (256 * (int)gclass104_1.byte_0[i][1] + (int)gclass104_1.byte_0[i][2]);
				for (int j = 0; j < num2; j++)
				{
					if (GClass126.bool_25)
					{
						break;
					}
					Thread.Sleep(100);
				}
			}
			else if (gclass104_1.byte_0[i][0] == 254)
			{
				int num3 = (int)gclass104_1.byte_0[i][2];
				int num4 = (int)gclass104_1.byte_0[i][1];
				string text = gclass104_1.string_5[num3].Substring(4);
				if (num4 == 0)
				{
					base.method_26(text);
				}
				else if (num4 == 1)
				{
					base.method_26(text);
					GClass126.bool_24 = false;
					for (int k = 0; k < 600; k++)
					{
						if (GClass126.bool_25 && flag2)
						{
							GClass126.smethod_2(GClass121.smethod_6("6081"), 2);
							this.method_54(gclass104_1.byte_0[gclass104_1.byte_0.Length - 1]);
							base.method_28(false, GClass121.smethod_6("6082"), " ");
							return;
						}
						if (GClass126.bool_24)
						{
							break;
						}
						Thread.Sleep(100);
					}
				}
			}
			else
			{
				byte[] array = this.method_54(gclass104_1.byte_0[i]);
				if (a == "" && (array.Length == 0 || (array.Length > 1 && array[1] == 127)))
				{
					if (array.Length < 4)
					{
						a = "";
					}
					else if (array[3] == 34)
					{
						a = GClass121.smethod_6("6053");
					}
					else if (array[3] == 17)
					{
						a = GClass121.smethod_6("6054");
					}
					else if (array[3] == 49)
					{
						a = GClass121.smethod_6("6507");
					}
					else if (array[3] == 120)
					{
						a = GClass121.smethod_6("6502");
					}
					else if (array[3] == 16)
					{
						a = GClass121.smethod_6("6503");
					}
					else if (array[3] == 18)
					{
						a = GClass121.smethod_6("6504");
					}
					else if (array[3] == 33)
					{
						a = GClass121.smethod_6("6505");
					}
					else if (array[3] == 36)
					{
						a = "Incorrect sequence";
					}
					else if (array[3] == 129)
					{
						a = "RPM too high";
					}
					else if (array[3] == 130)
					{
						a = "RPM too low";
					}
					else if (array[3] == 131)
					{
						a = "Engine running";
					}
					else if (array[3] == 132)
					{
						a = "Engine not running";
					}
					else if (array[3] == 133)
					{
						a = "Engine run time not enough";
					}
					else if (array[3] == 134)
					{
						a = "Temperature too high";
					}
					else if (array[3] == 135)
					{
						a = "Temperature too low";
					}
					else if (array[3] == 136)
					{
						a = "Vehicle speed too high";
					}
					else if (array[3] == 137)
					{
						a = "Vehicle speed too low";
					}
					else if (array[3] == 138)
					{
						a = "Throttle/pedal too high";
					}
					else if (array[3] == 139)
					{
						a = "Throttle/pedal too low";
					}
					else if (array[3] == 140)
					{
						a = "Transmission in Neutral";
					}
					else if (array[3] == 141)
					{
						a = "Transmission in gear";
					}
					else if (array[3] == 143)
					{
						a = "Brake pedal";
					}
					else if (array[3] == 144)
					{
						a = "Transmission not in Park";
					}
					else if (array[3] == 145)
					{
						a = "Torque converter locked";
					}
					else if (array[3] == 146)
					{
						a = "Voltage too high";
					}
					else if (array[3] == 147)
					{
						a = "Voltage too low";
					}
					else
					{
						a = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
					}
					if (!flag)
					{
						base.method_28(false, GClass121.smethod_6("6052"), a);
						this.bool_3 = false;
						return;
					}
				}
				if (i < gclass104_1.byte_0.Length - 1 || gclass104_1.byte_0.Length == 1)
				{
					for (int l = 0; l < num; l++)
					{
						if (GClass126.bool_25 && flag2)
						{
							GClass126.smethod_2(GClass121.smethod_6("6081"), 2);
							array = this.method_54(gclass104_1.byte_0[gclass104_1.byte_0.Length - 1]);
							base.method_28(false, GClass121.smethod_6("6082"), " ");
							this.bool_3 = false;
							return;
						}
						Thread.Sleep(100);
					}
				}
				if (i == gclass104_1.byte_0.Length - 1 && flag3)
				{
					a2 = GClass121.smethod_6("6056");
					if (array.Length > 2 + gclass104_1.int_0 && gclass104_1.string_5.Length != 0)
					{
						byte b = array[3 + gclass104_1.int_0];
						int m = 0;
						while (m < gclass104_1.string_5.Length)
						{
							byte b2 = byte.Parse(gclass104_1.string_5[m].Substring(0, 2), NumberStyles.HexNumber);
							byte b3 = byte.Parse(gclass104_1.string_5[m].Substring(2, 2), NumberStyles.HexNumber);
							if ((b & b2) != b3)
							{
								if (m != gclass104_1.string_5.Length - 1)
								{
									m++;
									continue;
								}
							}
							a2 = gclass104_1.string_5[m].Substring(4);
							break;
						}
					}
				}
			}
		}
		this.bool_3 = false;
		if (a2 != "")
		{
			base.method_28(false, GClass121.smethod_6("6051"), a2);
			return;
		}
		if (a == "" || flag)
		{
			base.method_28(false, GClass121.smethod_6("6051"), a);
			return;
		}
		base.method_28(false, GClass121.smethod_6("6052"), a);
	}

	// Token: 0x0600033E RID: 830 RVA: 0x00051BBC File Offset: 0x0004FDBC
	private void method_51(GClass104 gclass104_1)
	{
		byte[] array = this.method_54(gclass104_1.byte_0[0]);
		if (array.Length > 1 && array[1] == 127)
		{
			string text = "";
			if (array.Length < 4)
			{
				text = "";
			}
			else if (array[3] == 34)
			{
				text = GClass121.smethod_6("6053");
			}
			else if (array[3] == 17)
			{
				text = GClass121.smethod_6("6054");
			}
			else if (array[3] == 18)
			{
				text = GClass121.smethod_6("6504");
			}
			else if (array[3] == 49)
			{
				text = GClass121.smethod_6("6507");
			}
			else if (array[3] == 33)
			{
				text = GClass121.smethod_6("6505");
			}
			else if (array[3] > 0)
			{
				text = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
			}
			base.method_28(false, GClass121.smethod_6("6052"), text);
			return;
		}
		byte[] array2 = new byte[3];
		array2[0] = 2;
		array2[1] = 51;
		byte[] array3 = array2;
		array3[2] = gclass104_1.byte_0[0][2];
		byte[] array4 = new byte[3];
		array4[0] = 2;
		array4[1] = 50;
		byte[] array5 = array4;
		array5[2] = gclass104_1.byte_0[0][2];
		if (gclass104_1.byte_0.Length > 1)
		{
			array3 = GClass127.smethod_32(GClass127.smethod_11(gclass104_1.byte_0[1]));
		}
		if (gclass104_1.byte_0.Length > 2)
		{
			array5 = GClass127.smethod_32(GClass127.smethod_11(gclass104_1.byte_0[2]));
		}
		int num = 1800;
		bool flag = true;
		IL_1ED:
		while (num > 0 && flag)
		{
			for (int i = 0; i < 5; i++)
			{
				if (GClass126.bool_25)
				{
					GClass126.smethod_2("Aborting routine...", 2);
					array = this.method_54(array5);
					num = 0;
					IL_195:
					GClass126.smethod_2("Checking routine status..", 1);
					array = this.method_54(array3);
					if (this.int_1 > 0 && array.Length == 0)
					{
						Thread.Sleep(10);
						array = this.method_54(array3);
					}
					if (array.Length <= 3 || array[1] != 127 || array[2] != 51 || (array[3] != 33 && array[3] != 35))
					{
						flag = false;
					}
					num--;
					goto IL_1ED;
				}
				Thread.Sleep(100);
			}
			goto IL_195;
		}
		string text2 = GClass121.smethod_6("6056");
		if (gclass104_1.byte_0.Length > 3)
		{
			if (gclass104_1.string_2.Contains("FUNCW"))
			{
				text2 = this.vmethod_0(gclass104_1.byte_0[3], "bitw", gclass104_1.int_0, gclass104_1.int_1, gclass104_1.string_5, gclass104_1.string_6);
			}
			else
			{
				text2 = this.vmethod_0(gclass104_1.byte_0[3], "bits", gclass104_1.int_0, gclass104_1.int_1, gclass104_1.string_5, gclass104_1.string_6);
			}
		}
		else if (array.Length > 3 && array[1] == 115)
		{
			if (gclass104_1.string_5.Length != 0 && gclass104_1.string_2.Contains("FUNCW") && array.Length > 4)
			{
				byte b = array[3];
				byte b2 = array[4];
				this.string_10 = GClass127.smethod_23(b);
				text2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b) + GClass127.smethod_23(b2);
				int j = 0;
				while (j < gclass104_1.string_5.Length)
				{
					byte b3 = byte.Parse(gclass104_1.string_5[j].Substring(0, 2), NumberStyles.HexNumber);
					byte b4 = byte.Parse(gclass104_1.string_5[j].Substring(2, 2), NumberStyles.HexNumber);
					byte b5 = byte.Parse(gclass104_1.string_5[j].Substring(4, 2), NumberStyles.HexNumber);
					byte b6 = byte.Parse(gclass104_1.string_5[j].Substring(6, 2), NumberStyles.HexNumber);
					if ((b & b3) != b5 || (b2 & b4) != b6)
					{
						if (j != gclass104_1.string_5.Length - 1)
						{
							j++;
							continue;
						}
					}
					text2 = gclass104_1.string_5[j].Substring(8);
					break;
				}
			}
			else if (gclass104_1.string_5.Length != 0 && !gclass104_1.string_2.Contains("FUNCW"))
			{
				byte b7 = array[3];
				if (gclass104_1.int_0 == 2 && array.Length > 4)
				{
					b7 = array[4];
				}
				this.string_10 = GClass127.smethod_23(b7);
				text2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b7);
				int k = 0;
				while (k < gclass104_1.string_5.Length)
				{
					byte b8 = byte.Parse(gclass104_1.string_5[k].Substring(0, 2), NumberStyles.HexNumber);
					byte b9 = byte.Parse(gclass104_1.string_5[k].Substring(2, 2), NumberStyles.HexNumber);
					if ((b7 & b8) != b9)
					{
						if (k != gclass104_1.string_5.Length - 1)
						{
							k++;
							continue;
						}
					}
					text2 = gclass104_1.string_5[k].Substring(4);
					break;
				}
			}
			else if (array.Length == 4)
			{
				text2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
			}
			else if (array.Length == 5)
			{
				text2 = string.Concat(new string[]
				{
					GClass121.smethod_6("6055"),
					" ",
					GClass127.smethod_23(array[3]),
					" ",
					GClass127.smethod_23(array[4])
				});
			}
			else if (array.Length > 5)
			{
				text2 = string.Concat(new string[]
				{
					GClass121.smethod_6("6055"),
					" ",
					GClass127.smethod_23(array[3]),
					" ",
					GClass127.smethod_23(array[4]),
					" ",
					GClass127.smethod_23(array[5])
				});
			}
		}
		base.method_28(true, GClass121.smethod_6("6051"), text2);
	}

	// Token: 0x0600033F RID: 831 RVA: 0x00052168 File Offset: 0x00050368
	private void method_52(GClass104 gclass104_1)
	{
		byte[] array = this.method_54(gclass104_1.byte_0[0]);
		if (array.Length < 4)
		{
			string text = "";
			base.method_28(false, GClass121.smethod_6("6052"), text);
			return;
		}
		for (int i = 3; i < gclass104_1.byte_0[1].Length; i++)
		{
			byte b = 0;
			if (array.Length > i)
			{
				b = array[i];
			}
			if (gclass104_1.int_0 <= i - 2 && gclass104_1.int_0 + gclass104_1.int_1 > i - 2)
			{
				byte b2 = gclass104_1.byte_0[1][i];
				byte b3 = byte.Parse(gclass104_1.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
				if (gclass104_1.string_2.Contains("RWUSERENTRYH"))
				{
					b3 = byte.MaxValue;
				}
				b3 ^= byte.MaxValue;
				b &= b3;
				b |= b2;
			}
			gclass104_1.byte_0[1][i] = b;
			if (gclass104_1.string_2.Contains("RWUSERENTRYA") && gclass104_1.byte_0.Length > 2)
			{
				gclass104_1.byte_0[2][i] = b;
			}
			if (gclass104_1.string_2.Contains("RWUSERENTRYA") && gclass104_1.byte_0.Length > 3)
			{
				gclass104_1.byte_0[3][i] = b;
			}
		}
		Thread.Sleep(1000);
		array = this.method_54(gclass104_1.byte_0[1]);
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_54(gclass104_1.byte_0[1]);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_54(gclass104_1.byte_0[1]);
		}
		if (array.Length != 0)
		{
			if (array.Length <= 1 || array[1] != 127)
			{
				int num = 5;
				if (gclass104_1.string_2.Contains("0.5SEC"))
				{
					num = 5;
				}
				else if (gclass104_1.string_2.Contains("1SEC"))
				{
					num = 10;
				}
				else if (gclass104_1.string_2.Contains("20SEC"))
				{
					num = 200;
				}
				else if (gclass104_1.string_2.Contains("50SEC"))
				{
					num = 500;
				}
				else if (gclass104_1.string_2.Contains("NOWAIT"))
				{
					num = 0;
				}
				bool flag = gclass104_1.string_2.Contains("EXECANY");
				for (int j = 2; j < gclass104_1.byte_0.Length; j++)
				{
					array = this.method_54(gclass104_1.byte_0[j]);
					if (!flag)
					{
						if (array.Length != 0)
						{
							if (array.Length <= 1 || array[1] != 127)
							{
								goto IL_264;
							}
						}
						string text2 = "";
						if (array.Length > 3 && array[3] == 34)
						{
							text2 = GClass121.smethod_6("6053");
						}
						else if (array.Length > 3 && array[3] == 17)
						{
							text2 = GClass121.smethod_6("6054");
						}
						base.method_28(false, GClass121.smethod_6("6052"), text2);
						return;
					}
					IL_264:
					if (j < gclass104_1.byte_0.Length - 1 || gclass104_1.byte_0.Length == 1)
					{
						for (int k = 0; k < num; k++)
						{
							Thread.Sleep(100);
						}
					}
				}
				Thread.Sleep(600);
				base.method_28(false, GClass121.smethod_6("6051"), "");
				return;
			}
		}
		string text3 = "";
		if (array.Length > 3 && array[3] == 34)
		{
			text3 = GClass121.smethod_6("6053");
		}
		else if (array.Length > 3 && array[3] == 17)
		{
			text3 = GClass121.smethod_6("6054");
		}
		base.method_28(false, GClass121.smethod_6("6052"), text3);
	}

	// Token: 0x06000340 RID: 832 RVA: 0x000524DC File Offset: 0x000506DC
	public override string vmethod_0(byte[] byte_9, string string_31, int int_11, int int_12, string[] string_32, string string_33)
	{
		byte[] array = this.method_54(byte_9);
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_54(byte_9);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_54(byte_9);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_54(byte_9);
		}
		if (array.Length == 0)
		{
			array = this.method_54(byte_9);
		}
		if (string_31 == "raw")
		{
			return GClass127.smethod_11(array);
		}
		return this.r4(array, string_31, int_11, int_12, string_32, string_33);
	}

	// Token: 0x06000341 RID: 833 RVA: 0x00052574 File Offset: 0x00050774
	private byte[] method_53(byte[] byte_9)
	{
		string text = "";
		while (GClass126.smethod_1() < this.int_0 + this.int_7)
		{
			Thread.Sleep(1);
		}
		this.serialPort_0.ReadExisting();
		byte b = 0;
		List<byte> list = new List<byte>();
		try
		{
			byte b2 = byte_9[0];
			if (this.bool_7)
			{
				b2 = 0;
			}
			if (!this.bool_6)
			{
				b2 |= 128;
			}
			text = this.method_57(b2);
			b += b2;
			list.Add(b2);
			if (!this.bool_6)
			{
				text += this.method_57(this.byte_0);
				b += this.byte_0;
				text += this.method_57(241);
				b += 241;
				list.Add(this.byte_0);
				list.Add(241);
			}
			if (this.bool_7)
			{
				b2 = byte_9[0];
				text = this.method_57(b2);
				b += b2;
				list.Add(b2);
			}
			for (int i = 1; i < byte_9.Length; i++)
			{
				text += this.method_57(byte_9[i]);
				b += byte_9[i];
				list.Add(byte_9[i]);
			}
			text += this.method_57(b);
			list.Add(b);
		}
		finally
		{
			GClass126.smethod_2(text, 0);
		}
		this.method_58(list.ToArray());
		return this.method_59();
	}

	// Token: 0x06000342 RID: 834 RVA: 0x000526D8 File Offset: 0x000508D8
	private byte[] method_54(byte[] byte_9)
	{
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			byte[] array = this.method_53(byte_9);
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_53(byte_9);
			}
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_53(byte_9);
			}
			if (array.Length > 3 && array[1] == 127 && array[3] == 120)
			{
				this.serialPort_0.ReadTimeout = this.int_8;
				try
				{
					GClass126.smethod_2("Waiting pending answer ...", 1);
					while (array.Length > 3 && array[1] == 127)
					{
						if (array[3] != 120)
						{
							break;
						}
						array = this.method_59();
					}
				}
				catch (Exception)
				{
				}
				if (array.Length > 2 && array[1] != 127)
				{
					GClass126.smethod_2("Success!", 1);
				}
				this.method_53(this.byte_4);
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
				GClass126.smethod_2(ex.Message + "(3)", 1);
				if (this.int_1 > 3)
				{
					if (!this.method_45())
					{
						this.bool_2 = false;
						GClass126.smethod_2("Terminate 5", 1);
						base.method_30(true);
					}
				}
				else
				{
					this.int_1++;
					try
					{
						for (int i = 0; i < 20; i++)
						{
							this.serialPort_0.ReadByte();
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

	// Token: 0x06000343 RID: 835 RVA: 0x00010BD0 File Offset: 0x0000EDD0
	private byte method_55(byte[] byte_9)
	{
		byte b = 0;
		for (int i = 0; i < byte_9.Length; i++)
		{
			b += byte_9[i];
		}
		return b;
	}

	// Token: 0x06000344 RID: 836 RVA: 0x00037A54 File Offset: 0x00035C54
	public override string r4(byte[] byte_9, string string_31, int int_11, int int_12, string[] string_32, string string_33)
	{
		string result = "";
		int_11 += 2;
		if (byte_9.Length <= int_11)
		{
			return result;
		}
		if (byte_9[1] == 127)
		{
			return result;
		}
		int num = byte_9.Length - int_11;
		if (int_12 < num)
		{
			num = int_12;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_9[i + int_11];
		}
		return base.method_33(array, string_31, string_32, string_33);
	}

	// Token: 0x06000345 RID: 837 RVA: 0x000528BC File Offset: 0x00050ABC
	private string method_56(byte byte_9)
	{
		while (GClass126.smethod_1() < this.int_0 + this.int_5)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_9
		}, 0, 1);
		this.int_0 = GClass126.smethod_1();
		string text = this.string_23 + this.int_0.ToString() + this.string_24 + GClass127.smethod_23(byte_9);
		byte b = (byte)this.serialPort_0.ReadByte();
		int num = GClass126.smethod_1() - this.int_0;
		this.int_0 += num / 2;
		if (num > 15)
		{
			this.int_3 = 25;
		}
		if (byte_9 != b)
		{
			text = string.Concat(new string[]
			{
				text,
				this.string_25,
				this.int_0.ToString(),
				this.string_26,
				GClass127.smethod_23(b)
			});
			throw new Exception(this.string_27);
		}
		return text;
	}

	// Token: 0x06000346 RID: 838 RVA: 0x000529AC File Offset: 0x00050BAC
	private string method_57(byte byte_9)
	{
		if (!GClass125.smethod_65())
		{
			return this.method_56(byte_9);
		}
		while (GClass126.smethod_1() < this.int_0 + this.int_5)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_9
		}, 0, 1);
		this.int_0 = GClass126.smethod_1() + 1;
		return this.string_23 + this.int_0.ToString() + this.string_24 + GClass127.smethod_23(byte_9);
	}

	// Token: 0x06000347 RID: 839 RVA: 0x00052A24 File Offset: 0x00050C24
	private void method_58(byte[] byte_9)
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
		if (this.int_0 + 20 < GClass126.smethod_1())
		{
			this.int_3 = 25;
		}
		if (!flag)
		{
			throw new Exception("Invalid echo!");
		}
	}

	// Token: 0x06000348 RID: 840 RVA: 0x00052AA8 File Offset: 0x00050CA8
	private byte[] method_59()
	{
		bool flag = false;
		byte b = (byte)this.serialPort_0.ReadByte();
		byte b2 = 0 + b;
		string str = "";
		if (b >= 128)
		{
			b &= 63;
			b2 += (byte)this.serialPort_0.ReadByte();
			byte b3 = (byte)this.serialPort_0.ReadByte();
			b2 += b3;
			str = this.string_29 + GClass127.smethod_23(b3) + this.string_30;
			if (b == 0)
			{
				b = (byte)this.serialPort_0.ReadByte();
				b2 += b;
				flag = true;
			}
		}
		byte[] array = new byte[(int)(b + 1)];
		array[0] = b;
		for (int i = 0; i < (int)b; i++)
		{
			array[i + 1] = (byte)this.serialPort_0.ReadByte();
			b2 += array[i + 1];
		}
		byte b4 = (byte)this.serialPort_0.ReadByte();
		this.int_0 = GClass126.smethod_1();
		GClass126.smethod_2(this.string_28 + str + GClass127.smethod_11(array), 0);
		if (b2 != b4)
		{
			GClass126.smethod_2("ERROR: Invalid response checksum! [" + GClass127.smethod_23(b4) + "]", 0);
		}
		if (flag && !this.bool_7)
		{
			this.bool_7 = true;
		}
		return array;
	}

	// Token: 0x06000349 RID: 841 RVA: 0x00052BD8 File Offset: 0x00050DD8
	private void method_60()
	{
		GClass126.smethod_2("PM started", 1);
		GClass126.int_3 = 0;
		int num = 0;
		SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
		while (!this.bool_1)
		{
			if (GClass125.smethod_63() == 2)
			{
				Thread.Sleep(10);
			}
			else if (GClass125.smethod_63() == 1)
			{
				Thread.Sleep(30);
			}
			else
			{
				Thread.Sleep(50);
			}
			if ((this.serialPort_0 == null || !this.serialPort_0.IsOpen) && !GClass126.bool_0)
			{
				GClass126.smethod_2("PM stopped(1)", 1);
				return;
			}
			if (GClass126.smethod_1() > GClass126.int_3 + GClass126.int_5 && !this.bool_2)
			{
				GClass126.int_3 = GClass126.smethod_1();
				num++;
				if (!GClass126.bool_22)
				{
					num = 0;
					Thread.Sleep(100);
				}
				else
				{
					for (int i = 0; i < this.list_0.Count; i++)
					{
						GClass104 gclass = this.list_0[i];
						if (gclass.bool_0 && (!GClass126.bool_12 || num % gclass.int_3 == 0))
						{
							if (GClass126.bool_0)
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
								gclass.method_1(this.random_0.Next(0, 100).ToString() ?? "");
								if (gclass.string_3 == "V")
								{
									gclass.method_1(this.r4(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.string_2.StartsWith("bits"))
								{
									gclass.method_1(this.r4(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.string_2.StartsWith("bitchars"))
								{
									gclass.method_1(this.r4(array[7], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								Thread.Sleep(this.int_7);
							}
							else
							{
								if (sortedList.ContainsKey(GClass127.smethod_11(gclass.byte_0[0])))
								{
									byte[] array2 = sortedList[GClass127.smethod_11(gclass.byte_0[0])];
									gclass.method_1(this.r4(array2, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else
								{
									byte[] value = this.method_54(gclass.byte_0[0]);
									gclass.method_1(this.r4(value, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									sortedList.Add(GClass127.smethod_11(gclass.byte_0[0]), value);
								}
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
						GClass126.smethod_0().method_3(GClass126.int_3, this.string_11);
					}
					this.bool_4 = true;
					int num2 = GClass126.smethod_1() - GClass126.int_3;
					if (num2 > GClass126.int_6)
					{
						GClass126.int_6 = num2;
					}
					if (!GClass126.bool_12)
					{
						if (num2 < GClass126.int_6)
						{
							GClass126.int_6 = num2;
						}
						GClass126.int_5 = GClass126.int_6;
					}
					sortedList.Clear();
				}
			}
		}
		GClass126.smethod_2("PM stopped", 1);
	}

	// Token: 0x0600034A RID: 842 RVA: 0x00053064 File Offset: 0x00051264
	private void method_61()
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
			if (GClass126.smethod_1() > this.int_0 + this.int_9 && !this.bool_2)
			{
				byte[] array = this.method_54(this.byte_4);
				if (array.Length < 2 || array[0] != 1 || array[1] != 126)
				{
					array = this.method_54(this.byte_4);
					if (array.Length < 2 || array[0] != 1 || array[1] != 126)
					{
						GClass126.smethod_2("KA response error!", 1);
						if (array.Length == 0 && this.int_1 > 2 && !this.method_45())
						{
							GClass126.smethod_2("Terminate 7", 1);
							base.method_30(true);
						}
					}
				}
			}
		}
		GClass126.smethod_2("KA stopped", 1);
	}

	// Token: 0x04000233 RID: 563
	private int int_5 = 8;

	// Token: 0x04000234 RID: 564
	private int int_6 = 50;

	// Token: 0x04000235 RID: 565
	private int int_7 = 70;

	// Token: 0x04000236 RID: 566
	private int int_8 = 5000;

	// Token: 0x04000237 RID: 567
	private int int_9 = 800;

	// Token: 0x04000238 RID: 568
	private byte[] byte_3 = new byte[]
	{
		129,
		0,
		241,
		129
	};

	// Token: 0x04000239 RID: 569
	private byte[] byte_4 = new byte[]
	{
		1,
		62
	};

	// Token: 0x0400023A RID: 570
	private bool bool_6 = true;

	// Token: 0x0400023B RID: 571
	private bool bool_7;

	// Token: 0x0400023C RID: 572
	private const double double_0 = 0.01;

	// Token: 0x0400023D RID: 573
	private double double_1 = 0.0245;

	// Token: 0x0400023E RID: 574
	private const double double_2 = 0.03;

	// Token: 0x0400023F RID: 575
	private double double_3 = 0.0495;

	// Token: 0x04000240 RID: 576
	private byte[] byte_5 = new byte[]
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

	// Token: 0x04000241 RID: 577
	private byte[] byte_6 = new byte[]
	{
		4,
		24,
		0,
		byte.MaxValue,
		0
	};

	// Token: 0x04000242 RID: 578
	private byte[] byte_7 = new byte[]
	{
		3,
		20,
		byte.MaxValue,
		0
	};

	// Token: 0x04000243 RID: 579
	private byte[] byte_8;

	// Token: 0x04000244 RID: 580
	private int int_10;

	// Token: 0x04000245 RID: 581
	private string[] string_22;

	// Token: 0x04000246 RID: 582
	private string string_23;

	// Token: 0x04000247 RID: 583
	private string string_24;

	// Token: 0x04000248 RID: 584
	private string string_25;

	// Token: 0x04000249 RID: 585
	private string string_26;

	// Token: 0x0400024A RID: 586
	private string string_27;

	// Token: 0x0400024B RID: 587
	private string string_28;

	// Token: 0x0400024C RID: 588
	private string string_29;

	// Token: 0x0400024D RID: 589
	private string string_30;
}
