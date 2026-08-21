using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Threading;

// Token: 0x0200000A RID: 10
public sealed class GClass1 : GClass0
{
	// Token: 0x0600003E RID: 62 RVA: 0x000063C0 File Offset: 0x000045C0
	public GClass1(byte byte_7, string string_6, List<GClass104> list_3, List<GClass104> list_4)
	{
		byte[] array = new byte[3];
		array[0] = 2;
		array[1] = 62;
		this.byte_2 = array;
		this.byte_3 = new byte[]
		{
			2,
			16,
			3
		};
		this.byte_4 = new byte[]
		{
			7,
			89,
			2,
			207,
			129,
			16,
			21,
			14
		};
		this.byte_5 = new byte[]
		{
			3,
			25,
			2,
			8
		};
		this.byte_6 = new byte[]
		{
			4,
			20,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue
		};
		base..ctor();
		this.byte_0 = byte_7;
		this.string_5 = string_6;
		this.list_0 = list_4;
		this.list_1 = list_3;
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00006478 File Offset: 0x00004678
	public override void vmethod_1(GForm9 gform9_0, bool bool_5)
	{
		try
		{
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
						8,
						98,
						241,
						165,
						124,
						134,
						79,
						byte.MaxValue,
						byte.MaxValue
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
				byte[][] array2 = new byte[][]
				{
					new byte[]
					{
						0,
						98,
						64,
						161,
						0,
						2,
						3,
						127,
						0,
						2,
						3,
						127,
						0,
						0,
						0,
						3,
						0,
						0,
						0,
						2,
						0,
						0,
						0,
						0,
						0,
						0,
						2,
						3,
						127,
						0,
						0,
						0,
						9,
						0,
						3,
						240,
						127,
						0,
						0,
						0,
						9,
						0,
						0,
						0,
						9,
						0
					},
					new byte[]
					{
						0,
						98,
						64,
						162,
						0,
						2,
						3,
						127,
						0,
						0,
						0,
						9,
						0,
						3,
						240,
						127,
						0,
						0,
						0,
						9,
						0,
						0,
						0,
						9,
						0,
						0,
						2,
						3,
						127,
						0,
						0,
						0,
						9,
						0,
						3,
						240,
						127,
						0,
						0,
						0,
						9,
						0,
						0,
						0,
						9,
						0
					},
					new byte[]
					{
						0,
						98,
						32,
						35,
						48,
						52,
						49,
						57,
						50,
						48,
						49,
						52,
						55,
						56,
						52,
						84,
						69,
						82,
						77,
						58,
						51,
						55,
						32,
						32,
						32,
						32,
						3,
						7,
						36,
						127,
						7,
						2,
						0,
						9,
						0,
						0,
						0,
						195,
						16,
						0,
						0,
						0,
						20,
						22,
						0,
						0,
						0,
						68,
						6,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						17,
						80,
						83,
						0,
						0
					}
				};
				Thread.Sleep(2000);
				GClass126.smethod_2("Testing mode!", 1);
				for (int j = 0; j < this.list_1.Count; j++)
				{
					GClass104 gclass = this.list_1[j];
					string text;
					if (GClass127.smethod_11(gclass.byte_0[0]) == "03 22 40 A1")
					{
						text = this.r4(array2[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
					}
					else if (GClass127.smethod_11(gclass.byte_0[0]) == "03 22 40 A2")
					{
						text = this.r4(array2[1], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
					}
					else if (GClass127.smethod_11(gclass.byte_0[0]) == "03 22 20 23")
					{
						text = this.r4(array2[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
					}
					else if (j < array.Length)
					{
						text = this.r4(array[j], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
					}
					else
					{
						text = this.r4(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
					}
					gclass.method_1(text);
					if (gclass.int_2 == 10455)
					{
						this.string_1 = text;
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_32))
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
				if (GClass125.smethod_44() == 3)
				{
					this.serialPort_0.ReadTimeout = 5000;
				}
				else
				{
					this.serialPort_0.ReadTimeout = 3000;
				}
				this.method_29("ATZ");
				GClass126.smethod_2("Init ELM327 interface", 1);
				if (!this.method_31().Contains("ELM32"))
				{
					GClass126.smethod_2("Invalid ELM interface!", 1);
				}
				if (!GClass126.bool_23)
				{
					this.method_30("AT PP 2C SV 41");
					this.method_30("AT PP 2C ON");
					this.method_30("AT PP 2D SV 0A");
					this.method_30("AT PP 2D ON");
					this.method_29("ATZ");
					this.method_31();
				}
				if (GClass125.smethod_44() == 3)
				{
					this.serialPort_0.ReadTimeout = 2000;
				}
				else
				{
					this.serialPort_0.ReadTimeout = 1500;
				}
				this.method_30("ATE0");
				this.method_30("ATL0");
				this.method_30("ATH0");
				if (GClass126.bool_23)
				{
					this.method_30("ATSP7");
				}
				else
				{
					this.method_30("ATSPB");
				}
				this.method_30("ATS0");
				this.method_30("ATCP 18");
				this.method_30("ATCRA 18DAF1" + GClass127.smethod_23(this.byte_0));
				this.method_30("ATSH DA" + GClass127.smethod_23(this.byte_0) + "F1");
				this.method_30("ATAT1");
				if (!GClass126.bool_23)
				{
					this.method_30("ATST99");
				}
				else
				{
					this.method_30("ATST21");
				}
				byte[] array3 = this.method_28(this.byte_3);
				if (array3.Length < 3 || array3[1] != 80 || array3[2] != 3)
				{
					throw new Exception("ELM327->ECU Connection failed!");
				}
			}
			catch (Exception ex)
			{
				GClass126.smethod_2(ex.Message, 1);
				this.string_2 = ex.Message;
				throw new Exception("0");
			}
			GClass126.smethod_2("ECU wakeup completed", 1);
			if (gform9_0 != null && gform9_0.method_0())
			{
				throw new Exception("ESC");
			}
			if (!bool_5)
			{
				Thread thread = new Thread(new ThreadStart(this.method_33));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_32))
				{
					Priority = ThreadPriority.Highest
				}.Start();
			}
			for (int k = 0; k < this.list_1.Count; k++)
			{
				GClass104 gclass2 = this.list_1[k];
				string text2 = this.vmethod_0(gclass2.byte_0[0], gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6);
				gclass2.method_1(text2);
				if (gclass2.int_2 == 10455)
				{
					this.string_1 = text2;
					GClass126.smethod_2("ECU ISO Code: " + text2, 2);
				}
			}
			if (bool_5 && this.gclass104_0 != null)
			{
				Thread.Sleep(200);
				byte[] array4 = this.method_28(this.gclass104_0.byte_0[0]);
				this.string_3 = GClass127.smethod_11(array4);
			}
			if (bool_5 && this.gclass104_0 != null)
			{
				byte[] array5 = this.method_28(this.gclass104_0.byte_0[0]);
				this.string_3 = GClass127.smethod_11(array5);
			}
			if (bool_5)
			{
				base.method_11(false);
			}
			else
			{
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
			GClass126.smethod_2(ex2.Message, 2);
			GClass126.smethod_2("Terminate 4", 1);
			base.method_11(ex2.Message != "0");
		}
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00006BE4 File Offset: 0x00004DE4
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
				this.method_30("ATPC");
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

	// Token: 0x06000041 RID: 65 RVA: 0x00006CBC File Offset: 0x00004EBC
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
			array = this.method_28(this.byte_5);
		}
		if (array.Length < 3)
		{
			GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
			return null;
		}
		int num = (int)array[2];
		int num2 = 0;
		int num3 = 4;
		while (num2 < num && num3 < array.Length - 2)
		{
			GClass102 gclass = new GClass102();
			gclass.string_0 = GClass127.smethod_11(new byte[]
			{
				array[num3],
				array[num3 + 1]
			}).Replace(" ", "");
			gclass.byte_0 = array[num3 + 3];
			byte byte_ = array[num3 + 2];
			gclass.string_5 = this.method_21(byte_);
			gclass.string_6 = this.method_22(gclass.byte_0);
			gclass.string_7 = this.method_23(gclass.byte_0);
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
			if ((gclass.byte_0 & 9) == 8)
			{
				GClass102 gclass2 = gclass;
				gclass2.string_3 = gclass2.string_3 + GClass121.smethod_6("3077") + " ";
			}
			else if ((gclass.byte_0 & 1) == 1)
			{
				GClass102 gclass3 = gclass;
				gclass3.string_3 = gclass3.string_3 + GClass121.smethod_6("3078") + " ";
			}
			if ((gclass.byte_0 & 128) == 0)
			{
				GClass102 gclass4 = gclass;
				gclass4.string_3 = gclass4.string_3 + GClass121.smethod_6("3073") + " ";
			}
			else
			{
				GClass102 gclass5 = gclass;
				gclass5.string_3 = gclass5.string_3 + GClass121.smethod_6("3074") + " ";
			}
			list.Add(gclass);
			num3 += 4;
		}
		return list;
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00006F08 File Offset: 0x00005108
	private string method_21(byte byte_7)
	{
		string result = "";
		if (byte_7 == 17)
		{
			result = GClass121.smethod_6("3082");
		}
		else if (byte_7 == 18)
		{
			result = GClass121.smethod_6("3083");
		}
		else if (byte_7 == 19)
		{
			result = GClass121.smethod_6("3081");
		}
		else if (byte_7 == 20)
		{
			result = GClass121.smethod_6("3089");
		}
		else if (byte_7 == 21)
		{
			result = GClass121.smethod_6("3085");
		}
		else if (byte_7 == 22)
		{
			result = GClass121.smethod_6("3084");
		}
		return result;
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00006F88 File Offset: 0x00005188
	private string method_22(byte byte_7)
	{
		string result = "";
		if ((byte_7 & 9) == 8)
		{
			result = GClass121.smethod_6("3054");
		}
		else if ((byte_7 & 1) == 1)
		{
			result = GClass121.smethod_6("3062");
		}
		return result;
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00006FC4 File Offset: 0x000051C4
	private string method_23(byte byte_7)
	{
		string result = "";
		if ((byte_7 & 128) != 0)
		{
			result = GClass121.smethod_6("3051");
		}
		return result;
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00006FEC File Offset: 0x000051EC
	public override void r2()
	{
		if (GClass126.bool_0)
		{
			this.byte_4 = new byte[]
			{
				3,
				89,
				2,
				207
			};
			return;
		}
		byte[] array = this.method_28(this.byte_6);
		if (array.Length < 2 || array[1] != 84)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00007040 File Offset: 0x00005240
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
				this.method_25(gclass104_1);
				return;
			}
			if (gclass104_1.string_2.Contains("RWUSERENTRY"))
			{
				this.method_26(gclass104_1);
				return;
			}
			this.method_24(gclass104_1);
			return;
		}
	}

	// Token: 0x06000047 RID: 71 RVA: 0x000070E8 File Offset: 0x000052E8
	private void method_24(GClass104 gclass104_1)
	{
		byte[] array = this.method_28(gclass104_1.byte_0[0]);
		int num = 2000;
		if (gclass104_1.string_2.Contains("0.5SEC"))
		{
			num = 500;
		}
		else if (gclass104_1.string_2.Contains("1SEC"))
		{
			num = 1000;
		}
		bool flag = gclass104_1.string_2.Contains("EXECANY");
		int num2 = 0;
		if ((!flag && array.Length == 0) || (array.Length > 1 && array[1] == 127))
		{
			string string_ = "";
			if (array.Length > 3 && array[3] == 34)
			{
				string_ = GClass121.smethod_6("6053");
			}
			else if (array.Length > 3 && array[3] == 17)
			{
				string_ = GClass121.smethod_6("6054");
			}
			base.method_19(false, GClass121.smethod_6("6052"), string_);
			return;
		}
		if (gclass104_1.byte_0.Length > 2)
		{
			if (array.Length > 1 && array[1] != 127)
			{
				num2++;
			}
			for (int i = 1; i < gclass104_1.byte_0.Length; i++)
			{
				Thread.Sleep(num);
				array = this.method_28(gclass104_1.byte_0[i]);
				if (array.Length > 1 && array[1] != 127)
				{
					num2++;
				}
			}
		}
		else if (gclass104_1.byte_0.Length == 2)
		{
			if (array.Length > 1 && array[1] != 127)
			{
				num2++;
			}
			for (int j = 1; j < gclass104_1.byte_0.Length; j++)
			{
				Thread.Sleep(num);
				if (num > 1000)
				{
					Thread.Sleep(3 * num);
				}
				array = this.method_28(gclass104_1.byte_0[j]);
				if (array.Length > 1 && array[1] != 127)
				{
					num2++;
				}
			}
		}
		else
		{
			if (array.Length > 1 && array[1] != 127)
			{
				num2++;
			}
			Thread.Sleep(num);
			if (num > 1000)
			{
				Thread.Sleep(4 * num);
			}
		}
		if (num2 == 0)
		{
			base.method_19(false, GClass121.smethod_6("6052"), "");
			return;
		}
		base.method_19(false, GClass121.smethod_6("6051"), "");
	}

	// Token: 0x06000048 RID: 72 RVA: 0x000072D0 File Offset: 0x000054D0
	private void method_25(GClass104 gclass104_1)
	{
		byte[] array = this.method_28(gclass104_1.byte_0[0]);
		byte[] array2 = new byte[]
		{
			5,
			49,
			3,
			0,
			0,
			0
		};
		array2[3] = gclass104_1.byte_0[0][3];
		array2[4] = gclass104_1.byte_0[0][4];
		array2[5] = gclass104_1.byte_0[0][5];
		int num = 1800;
		bool flag = true;
		while (num > 0 && flag)
		{
			Thread.Sleep(500);
			GClass126.smethod_2("Checking routine status..", 1);
			array = this.method_28(array2);
			if (array.Length <= 3 || array[1] != 127 || (array[3] != 33 && array[3] != 35))
			{
				flag = false;
			}
			num--;
		}
		string string_ = GClass121.smethod_6("6056");
		if (array.Length > 4 && array[1] == 113)
		{
			if (gclass104_1.string_5.Length != 0)
			{
				byte b = array[4];
				this.string_3 = GClass127.smethod_23(array[4]);
				string_ = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[4]);
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
					string_ = gclass104_1.string_5[i].Substring(4);
					break;
				}
			}
			else if (array.Length == 5)
			{
				string_ = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[4]);
			}
			else if (array.Length == 6)
			{
				string_ = string.Concat(new string[]
				{
					GClass121.smethod_6("6055"),
					" ",
					GClass127.smethod_23(array[4]),
					" ",
					GClass127.smethod_23(array[5])
				});
			}
			else if (array.Length > 6)
			{
				string_ = string.Concat(new string[]
				{
					GClass121.smethod_6("6055"),
					" ",
					GClass127.smethod_23(array[4]),
					" ",
					GClass127.smethod_23(array[5]),
					" ",
					GClass127.smethod_23(array[6])
				});
			}
		}
		base.method_19(true, GClass121.smethod_6("6051"), string_);
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00007538 File Offset: 0x00005738
	private void method_26(GClass104 gclass104_1)
	{
		byte[] array = this.method_28(gclass104_1.byte_0[0]);
		if (array.Length < 4)
		{
			string string_ = "";
			base.method_19(false, GClass121.smethod_6("6052"), string_);
			return;
		}
		for (int i = 4; i < gclass104_1.byte_0[1].Length; i++)
		{
			byte b = 0;
			if (array.Length > i)
			{
				b = array[i];
			}
			if (gclass104_1.int_0 <= i - 3 && gclass104_1.int_0 + gclass104_1.int_1 > i - 3)
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
		array = this.method_28(gclass104_1.byte_0[1]);
		if (array.Length != 0)
		{
			if (array.Length <= 1 || array[1] != 127)
			{
				Thread.Sleep(1000);
				base.method_19(false, GClass121.smethod_6("6051"), "");
				return;
			}
		}
		string string_2 = "";
		if (array.Length > 3 && array[3] == 34)
		{
			string_2 = GClass121.smethod_6("6053");
		}
		else if (array.Length > 3 && array[3] == 17)
		{
			string_2 = GClass121.smethod_6("6054");
		}
		base.method_19(false, GClass121.smethod_6("6052"), string_2);
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00007698 File Offset: 0x00005898
	public override string vmethod_0(byte[] byte_7, string string_6, int int_6, int int_7, string[] string_7, string string_8)
	{
		byte[] array = this.method_28(byte_7);
		return this.r4(array, string_6, int_6, int_7, string_7, string_8);
	}

	// Token: 0x0600004B RID: 75 RVA: 0x000076BC File Offset: 0x000058BC
	private byte[] method_27(byte[] byte_7)
	{
		if (this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		List<byte> list = new List<byte>();
		if (byte_7.Length < 2)
		{
			return new byte[0];
		}
		List<byte[]> list2 = new List<byte[]>();
		if (byte_7.Length < 9)
		{
			list2.Add(new byte[byte_7.Length - 1]);
			for (int i = 0; i < byte_7.Length - 1; i++)
			{
				list2[0][i] = byte_7[i + 1];
			}
		}
		else
		{
			list2.Add(new byte[8]);
			list2[0][0] = 16;
			int num = 0;
			int num2 = 1;
			while (num2 < list2[0].Length && num < byte_7.Length)
			{
				list2[0][num2] = byte_7[num];
				num++;
				num2++;
			}
			byte b = 33;
			while (num < byte_7.Length && b < 47)
			{
				list2.Add(new byte[(byte_7.Length - num > 7) ? 8 : (byte_7.Length - num + 1)]);
				int index = list2.Count - 1;
				list2[index][0] = b;
				b += 1;
				int num3 = 1;
				while (num3 < list2[index].Length && num < byte_7.Length)
				{
					list2[index][num3] = byte_7[num];
					num++;
					num3++;
				}
			}
		}
		if (list2.Count > 1 && !GClass126.bool_23)
		{
			this.method_30("ATCAF0");
			this.method_30("ATST03");
		}
		this.method_29(GClass127.smethod_11(list2[0]));
		this.int_0 = GClass126.smethod_1();
		if (list2.Count > 1 && !GClass126.bool_23)
		{
			GClass126.smethod_2("Waiting FC...", 0);
			string text = this.method_31();
			if (text.Contains("NO DATA") || text.Contains("ERROR") || text.Contains("?") || !text.StartsWith("30"))
			{
				this.method_30("ATST99");
				return new byte[0];
			}
			for (int j = 1; j < list2.Count; j++)
			{
				if (j == list2.Count - 1)
				{
					this.method_30("ATST99");
				}
				this.method_29(GClass127.smethod_11(list2[j]));
				this.int_0 = GClass126.smethod_1();
				if (j < list2.Count - 1)
				{
					this.method_31();
				}
			}
		}
		string text2 = this.method_31();
		if (list2.Count > 1 && !GClass126.bool_23)
		{
			this.method_30("ATCAF1");
		}
		if (!text2.Contains("NO DATA") && !text2.Contains("ERROR") && !text2.Contains("?"))
		{
			int num4;
			while (text2.StartsWith("7F2278") || text2.StartsWith("7F1978"))
			{
				num4 = 0;
				while (num4 < text2.Length && text2[num4] != '\r' && text2[num4] != '\n')
				{
					if (text2[num4] == '>')
					{
						break;
					}
					num4++;
				}
				text2 = text2.Substring(num4 + 1);
			}
			num4 = 0;
			while (num4 < text2.Length && text2[num4] != '\r' && text2[num4] != '\n')
			{
				if (text2[num4] == '>')
				{
					break;
				}
				num4++;
			}
			string text3 = text2.Substring(0, num4);
			text2 = text2.Substring(num4 + 1);
			if (text3.Length == 3 && text3[0] == '0')
			{
				byte item = 0;
				try
				{
					item = GClass127.smethod_32(text3.Substring(1))[0];
				}
				catch (Exception)
				{
				}
				list.Add(item);
				while (text2.Length > 2)
				{
					if (text2[1] != ':')
					{
						break;
					}
					num4 = 0;
					while (num4 < text2.Length && text2[num4] != '\r' && text2[num4] != '\n')
					{
						if (text2[num4] == '>')
						{
							break;
						}
						num4++;
					}
					if (num4 > 2)
					{
						text3 = text2.Substring(2, num4 - 2);
						byte[] array = GClass127.smethod_32(text3);
						for (int k = 0; k < array.Length; k++)
						{
							list.Add(array[k]);
						}
					}
					text2 = text2.Substring(num4 + 1);
				}
			}
			else
			{
				byte[] array2 = GClass127.smethod_32(text3);
				list.Add((byte)array2.Length);
				for (int l = 0; l < array2.Length; l++)
				{
					list.Add(array2[l]);
				}
			}
			GClass126.smethod_2("DECODED RESPONSE: " + GClass127.smethod_11(list.ToArray()), 0);
			byte[] array3 = new byte[0];
			if (list.Count > 0 && list[0] > 0 && (int)list[0] < list.Count)
			{
				array3 = new byte[(int)(list[0] + 1)];
				for (int m = 0; m <= (int)list[0]; m++)
				{
					array3[m] = list[m];
				}
			}
			return array3;
		}
		return new byte[0];
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00007BBC File Offset: 0x00005DBC
	private byte[] method_28(byte[] byte_7)
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
			byte[] array = this.method_27(byte_7);
			if (array.Length == 0)
			{
				array = this.method_27(byte_7);
			}
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

	// Token: 0x0600004D RID: 77 RVA: 0x00007C70 File Offset: 0x00005E70
	public override string r4(byte[] byte_7, string string_6, int int_6, int int_7, string[] string_7, string string_8)
	{
		string result = "";
		int_6 += 3;
		if (byte_7.Length <= int_6)
		{
			return result;
		}
		if (byte_7[1] == 127 && string_6 != "hex3")
		{
			return result;
		}
		int num = byte_7.Length - int_6;
		if (int_7 < num)
		{
			num = int_7;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_7[i + int_6];
		}
		return base.method_20(array, string_6, string_7, string_8);
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00007CE0 File Offset: 0x00005EE0
	private void method_29(string string_6)
	{
		GClass126.smethod_2("Send: " + string_6, 0);
		for (int i = 0; i < string_6.Length; i++)
		{
			this.serialPort_0.Write(string_6.Substring(i, 1));
		}
		this.serialPort_0.Write(this.serialPort_0.NewLine);
	}

	// Token: 0x0600004F RID: 79 RVA: 0x00007D38 File Offset: 0x00005F38
	private void method_30(string string_6)
	{
		this.method_29(string_6);
		if (!this.method_31().Contains("OK"))
		{
			GClass126.smethod_2("[" + string_6 + "] failed!", 0);
			if (GClass125.smethod_44() == 3)
			{
				this.method_29(string_6);
				this.method_31();
			}
		}
		this.int_0 = GClass126.smethod_1();
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00007D98 File Offset: 0x00005F98
	private string method_31()
	{
		string text = "";
		while (!text.EndsWith(">"))
		{
			text += ((char)this.serialPort_0.ReadByte()).ToString();
		}
		GClass126.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00007DE8 File Offset: 0x00005FE8
	private void method_32()
	{
		GClass126.smethod_2("PM started", 1);
		GClass126.int_3 = 0;
		SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
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
										3,
										97,
										50,
										118
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
									gclass.method_1(this.r4(array[6], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.string_0 == "Coolant Temperature")
								{
									gclass.method_1(this.r4(array[7], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								Thread.Sleep(50);
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
									byte[] value = this.method_28(gclass.byte_0[0]);
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
					sortedList.Clear();
				}
			}
		}
		GClass126.smethod_2("PM stopped", 1);
	}

	// Token: 0x06000052 RID: 82 RVA: 0x0000825C File Offset: 0x0000645C
	private void method_33()
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
			if (GClass126.smethod_1() > this.int_0 + this.int_5 && !this.bool_2)
			{
				byte[] array = this.method_28(this.byte_2);
				if (array.Length >= 2)
				{
					if (array[1] == 126)
					{
						this.int_1 = 0;
						continue;
					}
				}
				GClass126.smethod_2("KA response error!", 1);
				this.int_1++;
				if (array.Length == 0 && this.int_1 > 1)
				{
					GClass126.smethod_2("Terminate 7", 1);
					base.method_11(true);
				}
			}
		}
		GClass126.smethod_2("KA stopped", 1);
	}

	// Token: 0x04000023 RID: 35
	private string string_5 = "7B0";

	// Token: 0x04000024 RID: 36
	private int int_5 = 2000;

	// Token: 0x04000025 RID: 37
	private byte[] byte_2;

	// Token: 0x04000026 RID: 38
	private byte[] byte_3;

	// Token: 0x04000027 RID: 39
	private byte[] byte_4;

	// Token: 0x04000028 RID: 40
	private byte[] byte_5;

	// Token: 0x04000029 RID: 41
	private byte[] byte_6;
}
