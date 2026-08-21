using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Threading;

// Token: 0x02000010 RID: 16
public sealed class GClass7 : GClass0
{
	// Token: 0x060000BA RID: 186 RVA: 0x0001143C File Offset: 0x0000F63C
	public GClass7(byte byte_7, List<GClass104> list_3, List<GClass104> list_4)
	{
		this.byte_0 = byte_7;
		this.list_0 = list_4;
		this.list_1 = list_3;
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00011564 File Offset: 0x0000F764
	public override void vmethod_1(GForm9 gform9_0, bool bool_6)
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
				GClass126.smethod_2("Testing mode!", 1);
				for (int j = 0; j < this.list_1.Count; j++)
				{
					GClass104 gclass = this.list_1[j];
					string string_ = this.r4(array[j], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
					gclass.method_1(string_);
					if (gclass.int_2 == 10455)
					{
						this.string_1 = string_;
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_36))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				base.method_16();
				throw new Exception("1");
			}
			try
			{
				this.serialPort_0 = new SerialPort(GClass125.smethod_55(), 10400, Parity.None, 8, StopBits.One);
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
			int k = 4;
			if (bool_6)
			{
				k = 1;
			}
			while (k > 0)
			{
				try
				{
					long num2 = 0L;
					GClass126.smethod_2("Fast wake up start", 1);
					this.serialPort_0.ReadTimeout = 1;
					num2 = GClass126.stopwatch_0.ElapsedTicks;
					this.serialPort_0.BreakState = true;
					while ((double)GClass126.stopwatch_0.ElapsedTicks < (double)num2 + 0.01 * (double)Stopwatch.Frequency)
					{
						Thread.Sleep(1);
					}
					while ((double)GClass126.stopwatch_0.ElapsedTicks < (double)num2 + 0.0245 * (double)Stopwatch.Frequency)
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
					while ((double)GClass126.stopwatch_0.ElapsedTicks < (double)num2 + 0.0495 * (double)Stopwatch.Frequency)
					{
					}
					this.serialPort_0.Write(this.byte_2, 0, 1);
					GClass126.smethod_2("Sent: " + GClass127.smethod_23(this.byte_2[0]), 0);
					byte b2 = (byte)this.serialPort_0.ReadByte();
					this.int_0 = GClass126.smethod_1();
					num = this.int_0 + 8000;
					if (this.byte_2[0] != b2)
					{
						throw new Exception("ERROR: Invalid echo!");
					}
					for (int l = 1; l < this.byte_2.Length; l++)
					{
						GClass126.smethod_2(this.method_32(this.byte_2[l]), 0);
					}
					byte byte_ = this.method_31(this.byte_2);
					GClass126.smethod_2(this.method_32(byte_), 0);
					byte[] array2 = this.method_35();
					if (array2.Length >= 4)
					{
						if (array2[1] == 193)
						{
							b = array2[2];
							this.serialPort_0.ReadTimeout = 100;
							int num3 = 3;
							if (GClass125.smethod_63() != 0)
							{
								if (k != 1)
								{
									if (GClass125.smethod_63() == 1)
									{
										byte[] array3 = new byte[3];
										array3[0] = 2;
										array3[1] = 131;
										array2 = this.method_30(array3);
										if (array2.Length == 8)
										{
											array2[1] = 131;
											array2[2] = 3;
											array2 = this.method_30(array2);
										}
										num3 = 2;
										goto IL_51D;
									}
									if (GClass125.smethod_63() == 2)
									{
										array2 = this.method_30(new byte[]
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
										goto IL_51D;
									}
									if (GClass125.smethod_63() == 3)
									{
										array2 = this.method_30(new byte[]
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
										goto IL_51D;
									}
									goto IL_51D;
								}
							}
							array2 = this.method_30(new byte[]
							{
								2,
								131,
								1
							});
							IL_51D:
							array2 = this.method_30(new byte[]
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
							k = 0;
							continue;
						}
					}
					GClass126.smethod_2("ERROR: Invalid wakeup response!", 1);
					throw new Exception("Invalid wakeup response!");
				}
				catch (Exception)
				{
					this.serialPort_0.BreakState = false;
					k--;
					if (k == 0)
					{
						throw new Exception("1");
					}
					if (gform9_0 != null && gform9_0.method_0())
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(5000);
				}
			}
			GClass126.smethod_2("ECU wakeup completed", 1);
			if (gform9_0 != null && gform9_0.method_0())
			{
				throw new Exception("ESC");
			}
			if (!bool_6)
			{
				Thread thread = new Thread(new ThreadStart(this.method_37));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_36))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				Thread.Sleep(100);
			}
			for (int m = 0; m < this.list_1.Count; m++)
			{
				GClass104 gclass2 = this.list_1[m];
				string text = this.vmethod_0(gclass2.byte_0[0], gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6);
				gclass2.method_1(text);
				if (gclass2.int_2 == 1770)
				{
					this.string_1 = text;
					GClass126.smethod_2("ECU ISO Code: " + text, 2);
				}
			}
			if (bool_6)
			{
				base.method_11(false);
			}
			else
			{
				this.bool_0 = true;
				base.method_16();
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
						GClass126.smethod_2("WARNING: Unsupported message format!!!", 1);
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
			GClass126.smethod_2(ex2.Message, 2);
			GClass126.smethod_2("Terminate 4", 1);
			base.method_11(ex2.Message != "1" && ex2.Message != "0" && ex2.Message != "ESC");
		}
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00011E28 File Offset: 0x00010028
	private bool method_21()
	{
		return this.method_22() ?? this.method_22();
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00011E48 File Offset: 0x00010048
	private bool method_22()
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
		this.bool_5 = false;
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
			this.serialPort_0.Write(this.byte_2, 0, 1);
			GClass126.smethod_2("Sent: " + GClass127.smethod_23(this.byte_2[0]), 0);
			byte b = (byte)this.serialPort_0.ReadByte();
			this.int_0 = GClass126.smethod_1();
			if (this.byte_2[0] != b)
			{
				throw new Exception("ERROR: Invalid echo!");
			}
			for (int j = 1; j < this.byte_2.Length; j++)
			{
				GClass126.smethod_2(this.method_32(this.byte_2[j]), 0);
			}
			byte byte_ = this.method_31(this.byte_2);
			GClass126.smethod_2(this.method_32(byte_), 0);
			byte[] array = this.method_35();
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

	// Token: 0x060000BE RID: 190 RVA: 0x0000FD9C File Offset: 0x0000DF9C
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
		base.method_17(bool_7);
	}

	// Token: 0x060000BF RID: 191 RVA: 0x000120D8 File Offset: 0x000102D8
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
			array = this.method_30(this.byte_5);
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
			gclass.string_5 = this.method_23(gclass.byte_0);
			gclass.string_6 = this.method_24(gclass.byte_0);
			gclass.string_7 = this.method_25(gclass.byte_0);
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

	// Token: 0x060000C0 RID: 192 RVA: 0x00009148 File Offset: 0x00007348
	private string method_23(byte byte_7)
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

	// Token: 0x060000C1 RID: 193 RVA: 0x000091A4 File Offset: 0x000073A4
	private string method_24(byte byte_7)
	{
		string result = "";
		if ((byte_7 & 96) == 0)
		{
			result = GClass121.smethod_6("3052");
		}
		else if ((byte_7 & 96) == 32)
		{
			result = GClass121.smethod_6("3053");
		}
		else if ((byte_7 & 96) == 64)
		{
			result = GClass121.smethod_6("3054");
		}
		else if ((byte_7 & 96) == 96)
		{
			result = GClass121.smethod_6("3055");
		}
		return result;
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x00006FC4 File Offset: 0x000051C4
	private string method_25(byte byte_7)
	{
		string result = "";
		if ((byte_7 & 128) != 0)
		{
			result = GClass121.smethod_6("3051");
		}
		return result;
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x0001243C File Offset: 0x0001063C
	public override void r2()
	{
		if (GClass126.bool_0)
		{
			this.byte_4 = new byte[]
			{
				2,
				88,
				0,
				90
			};
			return;
		}
		byte[] array = this.method_30(this.byte_6);
		if (array.Length < 3 || array[1] != 84)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x00012490 File Offset: 0x00010690
	protected override void r3(GClass104 gclass104_1)
	{
		if (GClass126.bool_0)
		{
			Thread.Sleep(3000);
			if (gclass104_1.string_2.Contains("FUNC"))
			{
				base.method_19(true, GClass121.smethod_6("6051"), GClass121.smethod_6("6055") + " 00");
				return;
			}
			base.method_19(false, GClass121.smethod_6("6051"), "");
			return;
		}
		else
		{
			if (gclass104_1.string_2.Contains("FUNC"))
			{
				this.method_27(gclass104_1);
				return;
			}
			if (gclass104_1.string_2.Contains("RWUSERENTRY"))
			{
				this.method_28(gclass104_1);
				return;
			}
			this.method_26(gclass104_1);
			return;
		}
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00012538 File Offset: 0x00010738
	private void method_26(GClass104 gclass104_1)
	{
		byte[] array = this.method_30(gclass104_1.byte_0[0]);
		int num = 2000;
		if (!gclass104_1.string_2.Contains("0.5SEC"))
		{
			if (!gclass104_1.string_2.Contains("1SEC"))
			{
				if (array.Length != 0)
				{
					if (array.Length <= 1 || array[1] != 127)
					{
						if (gclass104_1.string_2.Contains("IORESULT"))
						{
							int num2 = 60;
							if (gclass104_1.string_2.Contains("WAITY"))
							{
								while (num2 > 0 && !GClass126.bool_24)
								{
									Thread.Sleep(500);
									num2--;
								}
							}
							else
							{
								Thread.Sleep(10000);
							}
							string text = GClass121.smethod_6("6052");
							string text2 = "";
							if (num2 > 0)
							{
								text = GClass121.smethod_6("6051");
								text2 = GClass121.smethod_6("6055") + this.vmethod_0(gclass104_1.byte_0[1], "bits", gclass104_1.int_0, gclass104_1.int_1, gclass104_1.string_5, gclass104_1.string_6);
							}
							base.method_19(false, text, text2);
							return;
						}
						if (gclass104_1.byte_0.Length > 2)
						{
							for (int i = 1; i < gclass104_1.byte_0.Length; i++)
							{
								Thread.Sleep(num);
								this.method_30(gclass104_1.byte_0[i]);
							}
							goto IL_1BE;
						}
						if (gclass104_1.byte_0.Length == 2)
						{
							for (int j = 1; j < gclass104_1.byte_0.Length; j++)
							{
								Thread.Sleep(num);
								if (num > 1000)
								{
									Thread.Sleep(3 * num);
								}
								this.method_30(gclass104_1.byte_0[j]);
							}
							goto IL_1BE;
						}
						Thread.Sleep(num);
						if (num > 1000)
						{
							Thread.Sleep(4 * num);
							goto IL_1BE;
						}
						goto IL_1BE;
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
				base.method_19(false, GClass121.smethod_6("6052"), text3);
				return;
			}
		}
		IL_1BE:
		base.method_19(false, GClass121.smethod_6("6051"), "");
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x00012764 File Offset: 0x00010964
	private void method_27(GClass104 gclass104_1)
	{
		byte[] array = this.method_30(gclass104_1.byte_0[0]);
		if (array.Length > 1 && array[1] == 127)
		{
			string text = "";
			if (array.Length > 3 && array[3] == 34)
			{
				text = GClass121.smethod_6("6053");
			}
			else if (array.Length > 3 && array[3] == 17)
			{
				text = GClass121.smethod_6("6054");
			}
			base.method_19(false, GClass121.smethod_6("6052"), text);
			return;
		}
		byte[] array2 = new byte[3];
		array2[0] = 2;
		array2[1] = 51;
		byte[] array3 = array2;
		array3[2] = gclass104_1.byte_0[0][2];
		int num = 1800;
		bool flag = true;
		while (num > 0 && flag)
		{
			Thread.Sleep(500);
			GClass126.smethod_2("Checking routine status..", 1);
			array = this.method_30(array3);
			if (array.Length <= 3 || array[1] != 127 || array[2] != 51 || (array[3] != 33 && array[3] != 35))
			{
				flag = false;
			}
			num--;
		}
		string text2 = GClass121.smethod_6("6056");
		if (array.Length > 3 && array[1] == 115)
		{
			if (gclass104_1.string_5.Length != 0)
			{
				byte b = array[3];
				if (gclass104_1.int_0 == 2 && array.Length > 4)
				{
					b = array[4];
				}
				text2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
				int i = 0;
				while (i < gclass104_1.string_5.Length)
				{
					byte b2 = byte.Parse(gclass104_1.string_5[i].Substring(0, 2), NumberStyles.HexNumber);
					byte b3 = byte.Parse(gclass104_1.string_5[i].Substring(2, 2), NumberStyles.HexNumber);
					if ((b & b2) != b3)
					{
						if (i != gclass104_1.string_5.Length - 1)
						{
							i++;
							continue;
						}
					}
					text2 = gclass104_1.string_5[i].Substring(4);
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
		base.method_19(true, GClass121.smethod_6("6051"), text2);
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x00012A18 File Offset: 0x00010C18
	private void method_28(GClass104 gclass104_1)
	{
		byte[] array = this.method_30(gclass104_1.byte_0[0]);
		if (array.Length < 4)
		{
			string text = "";
			base.method_19(false, GClass121.smethod_6("6052"), text);
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
				b3 ^= byte.MaxValue;
				b &= b3;
				b |= b2;
			}
			gclass104_1.byte_0[1][i] = b;
		}
		Thread.Sleep(1000);
		array = this.method_30(gclass104_1.byte_0[1]);
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_30(gclass104_1.byte_0[1]);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_30(gclass104_1.byte_0[1]);
		}
		if (array.Length != 0)
		{
			if (array.Length <= 1 || array[1] != 127)
			{
				Thread.Sleep(1000);
				base.method_19(false, GClass121.smethod_6("6051"), "");
				return;
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
		base.method_19(false, GClass121.smethod_6("6052"), text2);
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x00012BC0 File Offset: 0x00010DC0
	public override string vmethod_0(byte[] byte_7, string string_13, int int_11, int int_12, string[] string_14, string string_15)
	{
		byte[] array = this.method_30(byte_7);
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_30(byte_7);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_30(byte_7);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_30(byte_7);
		}
		if (array.Length == 0)
		{
			array = this.method_30(byte_7);
		}
		return this.r4(array, string_13, int_11, int_12, string_14, string_15);
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00012C44 File Offset: 0x00010E44
	private byte[] method_29(byte[] byte_7)
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
			byte b2 = byte_7[0];
			if (!this.bool_5)
			{
				b2 |= 128;
			}
			text = this.method_33(b2);
			b += b2;
			list.Add(b2);
			if (!this.bool_5)
			{
				text += this.method_33(this.byte_0);
				b += this.byte_0;
				text += this.method_33(241);
				b += 241;
				list.Add(this.byte_0);
				list.Add(241);
			}
			for (int i = 1; i < byte_7.Length; i++)
			{
				text += this.method_33(byte_7[i]);
				b += byte_7[i];
				list.Add(byte_7[i]);
			}
			text += this.method_33(b);
			list.Add(b);
		}
		finally
		{
			GClass126.smethod_2(text, 0);
		}
		this.method_34(list.ToArray());
		return this.method_35();
	}

	// Token: 0x060000CA RID: 202 RVA: 0x00012D80 File Offset: 0x00010F80
	private byte[] method_30(byte[] byte_7)
	{
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			byte[] array = this.method_29(byte_7);
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_29(byte_7);
			}
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_29(byte_7);
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
						array = this.method_35();
					}
				}
				catch (Exception)
				{
				}
				if (array.Length > 2 && array[1] != 127)
				{
					GClass126.smethod_2("Success!", 1);
				}
				this.method_29(this.byte_3);
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
					if (!this.method_21())
					{
						this.bool_2 = false;
						GClass126.smethod_2("Terminate 5", 1);
						base.method_11(true);
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

	// Token: 0x060000CB RID: 203 RVA: 0x00010BD0 File Offset: 0x0000EDD0
	private byte method_31(byte[] byte_7)
	{
		byte b = 0;
		for (int i = 0; i < byte_7.Length; i++)
		{
			b += byte_7[i];
		}
		return b;
	}

	// Token: 0x060000CC RID: 204 RVA: 0x0000EA68 File Offset: 0x0000CC68
	public override string r4(byte[] byte_7, string string_13, int int_11, int int_12, string[] string_14, string string_15)
	{
		string result = "";
		int_11 += 2;
		if (byte_7.Length <= int_11)
		{
			return result;
		}
		if (byte_7[1] == 127)
		{
			return result;
		}
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
		return base.method_20(array, string_13, string_14, string_15);
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00012F64 File Offset: 0x00011164
	private string method_32(byte byte_7)
	{
		while (GClass126.smethod_1() < this.int_0 + this.int_5)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_7
		}, 0, 1);
		this.int_0 = GClass126.smethod_1();
		string text = this.string_5 + this.int_0.ToString() + this.string_6 + GClass127.smethod_23(byte_7);
		byte b = (byte)this.serialPort_0.ReadByte();
		int num = GClass126.smethod_1() - this.int_0;
		this.int_0 += num / 2;
		if (num > 15)
		{
			this.int_3 = 25;
		}
		if (byte_7 != b)
		{
			text = string.Concat(new string[]
			{
				text,
				this.string_7,
				this.int_0.ToString(),
				this.string_8,
				GClass127.smethod_23(b)
			});
			throw new Exception(this.string_9);
		}
		return text;
	}

	// Token: 0x060000CE RID: 206 RVA: 0x00013054 File Offset: 0x00011254
	private string method_33(byte byte_7)
	{
		if (!GClass125.smethod_65())
		{
			return this.method_32(byte_7);
		}
		while (GClass126.smethod_1() < this.int_0 + this.int_5)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_7
		}, 0, 1);
		this.int_0 = GClass126.smethod_1() + 1;
		return this.string_5 + this.int_0.ToString() + this.string_6 + GClass127.smethod_23(byte_7);
	}

	// Token: 0x060000CF RID: 207 RVA: 0x000130CC File Offset: 0x000112CC
	private void method_34(byte[] byte_7)
	{
		if (!GClass125.smethod_65())
		{
			return;
		}
		bool flag = true;
		for (int i = 0; i < byte_7.Length; i++)
		{
			byte b = (byte)this.serialPort_0.ReadByte();
			if (byte_7[i] != b)
			{
				GClass126.smethod_2("ERROR: Invalid echo: " + GClass127.smethod_23(byte_7[i]) + "->" + GClass127.smethod_23(b), 0);
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

	// Token: 0x060000D0 RID: 208 RVA: 0x00013150 File Offset: 0x00011350
	private byte[] method_35()
	{
		byte b = (byte)this.serialPort_0.ReadByte();
		byte b2 = 0 + b;
		string str = "";
		if (b >= 128)
		{
			b &= 63;
			b2 += (byte)this.serialPort_0.ReadByte();
			byte b3 = (byte)this.serialPort_0.ReadByte();
			b2 += b3;
			str = this.string_11 + GClass127.smethod_23(b3) + this.string_12;
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
		GClass126.smethod_2(this.string_10 + str + GClass127.smethod_11(array), 0);
		if (b2 != b4)
		{
			GClass126.smethod_2("ERROR: Invalid response checksum! [" + GClass127.smethod_23(b4) + "]", 0);
			throw new Exception("Invalid response checksum! [" + GClass127.smethod_23(b4) + "]");
		}
		return array;
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x0001326C File Offset: 0x0001146C
	private void method_36()
	{
		GClass126.smethod_2("PM started", 1);
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
				Thread.Sleep(60);
			}
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
						GClass126.smethod_0().method_3(GClass126.int_3, this.string_4);
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

	// Token: 0x060000D2 RID: 210 RVA: 0x00013620 File Offset: 0x00011820
	private void method_37()
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
				byte[] array = this.method_30(this.byte_3);
				if (array.Length < 2 || array[0] != 1 || array[1] != 126)
				{
					array = this.method_30(this.byte_3);
					if (array.Length < 2 || array[0] != 1 || array[1] != 126)
					{
						GClass126.smethod_2("KA response error!", 1);
						if (array.Length == 0 && this.int_1 > 2 && !this.method_21())
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

	// Token: 0x04000078 RID: 120
	private int int_5 = 8;

	// Token: 0x04000079 RID: 121
	private int int_6 = 50;

	// Token: 0x0400007A RID: 122
	private int int_7 = 70;

	// Token: 0x0400007B RID: 123
	private int int_8 = 5000;

	// Token: 0x0400007C RID: 124
	private int int_9 = 800;

	// Token: 0x0400007D RID: 125
	private byte[] byte_2 = new byte[]
	{
		129,
		0,
		241,
		129
	};

	// Token: 0x0400007E RID: 126
	private byte[] byte_3 = new byte[]
	{
		1,
		62
	};

	// Token: 0x0400007F RID: 127
	private bool bool_5 = true;

	// Token: 0x04000080 RID: 128
	private const double double_0 = 0.01;

	// Token: 0x04000081 RID: 129
	private const double double_1 = 0.0245;

	// Token: 0x04000082 RID: 130
	private const double double_2 = 0.03;

	// Token: 0x04000083 RID: 131
	private const double double_3 = 0.0495;

	// Token: 0x04000084 RID: 132
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

	// Token: 0x04000085 RID: 133
	private byte[] byte_5 = new byte[]
	{
		4,
		24,
		0,
		byte.MaxValue,
		0
	};

	// Token: 0x04000086 RID: 134
	private byte[] byte_6 = new byte[]
	{
		3,
		20,
		byte.MaxValue,
		0
	};

	// Token: 0x04000087 RID: 135
	private int int_10;

	// Token: 0x04000088 RID: 136
	private string string_5 = " <";

	// Token: 0x04000089 RID: 137
	private string string_6 = "> Sent: ";

	// Token: 0x0400008A RID: 138
	private string string_7 = " <";

	// Token: 0x0400008B RID: 139
	private string string_8 = "> ERROR: Invalid echo: ";

	// Token: 0x0400008C RID: 140
	private string string_9 = "Invalid echo!";

	// Token: 0x0400008D RID: 141
	private string string_10 = "Received: ";

	// Token: 0x0400008E RID: 142
	private string string_11 = "[";

	// Token: 0x0400008F RID: 143
	private string string_12 = "] ";
}
