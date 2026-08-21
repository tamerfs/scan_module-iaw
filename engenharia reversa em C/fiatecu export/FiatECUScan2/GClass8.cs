using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Threading;

// Token: 0x0200005B RID: 91
public sealed class GClass8 : GClass4
{
	// Token: 0x06000268 RID: 616 RVA: 0x00060F7C File Offset: 0x0005F17C
	public GClass8(byte byte_7, string string_6, List<GClass58> list_3, List<GClass58> list_4)
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
			1,
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

	// Token: 0x06000269 RID: 617 RVA: 0x00061038 File Offset: 0x0005F238
	public override void vmethod_1(FormNotify formNotify_0, bool bool_5)
	{
		try
		{
			if (!bool_5)
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
				Thread.Sleep(2000);
				GClass3.smethod_2("Testing mode!", 1);
				for (int i = 0; i < this.list_1.Count; i++)
				{
					GClass58 gclass = this.list_1[i];
					string text = string.Empty;
					if (i < array.Length)
					{
						text = this.vmethod_6(array[i], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
					}
					else
					{
						text = this.vmethod_6(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
					}
					gclass.method_1(text);
					if (gclass.int_2 == 1770)
					{
						this.string_1 = text;
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_42))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				base.method_26();
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
				if (GClass61.smethod_36() == 3)
				{
					this.serialPort_0.ReadTimeout = 5000;
				}
				else
				{
					this.serialPort_0.ReadTimeout = 3000;
				}
				this.method_39("ATZ");
				GClass3.smethod_2("Init ELM327 interface", 1);
				string text2 = this.method_41();
				if (!text2.Contains("ELM32"))
				{
					GClass3.smethod_2("Invalid ELM interface!", 1);
				}
				if (!GClass3.bool_12)
				{
					this.method_40("AT PP 2C SV 41");
					this.method_40("AT PP 2C ON");
					this.method_40("AT PP 2D SV 01");
					this.method_40("AT PP 2D ON");
					this.method_39("ATZ");
					text2 = this.method_41();
				}
				if (GClass61.smethod_36() == 3)
				{
					this.serialPort_0.ReadTimeout = 2000;
				}
				else
				{
					this.serialPort_0.ReadTimeout = 1500;
				}
				this.method_40("ATE0");
				this.method_40("ATL0");
				this.method_40("ATH0");
				if (GClass3.bool_12)
				{
					this.method_40("ATSP7");
				}
				else
				{
					this.method_40("ATSPB");
				}
				this.method_40("ATS0");
				this.method_40("ATCP 18");
				this.method_40("ATCRA 18DAF1" + GClass16.smethod_0(this.byte_0));
				this.method_40("ATSH DA" + GClass16.smethod_0(this.byte_0) + "F1");
				this.method_40("ATAT1");
				if (!GClass3.bool_12)
				{
					this.method_40("ATST99");
				}
				else
				{
					this.method_40("ATST21");
				}
				byte[] array2 = this.method_38(this.byte_3);
				if (array2.Length < 3 || array2[1] != 80 || array2[2] != 3)
				{
					throw new Exception("ELM327->ECU Connection failed!");
				}
			}
			catch (Exception ex)
			{
				GClass3.smethod_2(ex.Message, 1);
				this.string_2 = ex.Message;
				throw new Exception("0");
			}
			GClass3.smethod_2("ECU wakeup completed", 1);
			if (formNotify_0 != null && formNotify_0.method_0())
			{
				throw new Exception("ESC");
			}
			if (!bool_5)
			{
				Thread thread = new Thread(new ThreadStart(this.method_43));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_42))
				{
					Priority = ThreadPriority.Highest
				}.Start();
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
			if (bool_5 && this.gclass58_0 != null)
			{
				Thread.Sleep(200);
				byte[] byte_ = this.method_38(this.gclass58_0.byte_0[0]);
				this.string_3 = GClass16.smethod_1(byte_);
			}
			if (bool_5)
			{
				base.method_21(false);
			}
			else
			{
				this.bool_0 = true;
				base.method_26();
			}
		}
		catch (Exception ex2)
		{
			if (ex2.Message == "ESC")
			{
				this.string_2 = "Aborted by user";
			}
			GClass3.smethod_2(ex2.Message, 2);
			GClass3.smethod_2("Terminate 4", 1);
			base.method_21(ex2.Message != "0");
		}
	}

	// Token: 0x0600026A RID: 618 RVA: 0x00061688 File Offset: 0x0005F888
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
						this.method_40("ATPC");
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
				base.method_27(bool_6);
			}
		}
	}

	// Token: 0x0600026B RID: 619 RVA: 0x00061770 File Offset: 0x0005F970
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
			array = this.method_38(this.byte_5);
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
			int num3 = 4;
			while (num2 < num && num3 < array.Length - 2)
			{
				GClass64 gclass = new GClass64();
				gclass.string_0 = GClass16.smethod_1(new byte[]
				{
					array[num3],
					array[num3 + 1]
				}).Replace(" ", string.Empty);
				gclass.byte_0 = array[num3 + 3];
				byte byte_ = array[num3 + 2];
				gclass.string_4 = this.method_31(byte_);
				gclass.string_5 = this.method_32(gclass.byte_0);
				gclass.string_6 = this.method_33(gclass.byte_0);
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
				if ((gclass.byte_0 & 9) == 8)
				{
					GClass64 gclass2 = gclass;
					gclass2.string_2 = gclass2.string_2 + GClass62.smethod_1("3077") + " ";
				}
				else if ((gclass.byte_0 & 1) == 1)
				{
					GClass64 gclass3 = gclass;
					gclass3.string_2 = gclass3.string_2 + GClass62.smethod_1("3078") + " ";
				}
				if ((gclass.byte_0 & 128) == 0)
				{
					GClass64 gclass4 = gclass;
					gclass4.string_2 = gclass4.string_2 + GClass62.smethod_1("3073") + " ";
				}
				else
				{
					GClass64 gclass5 = gclass;
					gclass5.string_2 = gclass5.string_2 + GClass62.smethod_1("3074") + " ";
				}
				list.Add(gclass);
				num3 += 4;
			}
			result = list;
		}
		return result;
	}

	// Token: 0x0600026C RID: 620 RVA: 0x000546F4 File Offset: 0x000528F4
	private string method_31(byte byte_7)
	{
		string result = string.Empty;
		if (byte_7 == 17)
		{
			result = GClass62.smethod_1("3082");
		}
		else if (byte_7 == 18)
		{
			result = GClass62.smethod_1("3083");
		}
		else if (byte_7 == 19)
		{
			result = GClass62.smethod_1("3081");
		}
		else if (byte_7 == 20)
		{
			result = GClass62.smethod_1("3089");
		}
		else if (byte_7 == 21)
		{
			result = GClass62.smethod_1("3085");
		}
		else if (byte_7 == 22)
		{
			result = GClass62.smethod_1("3084");
		}
		return result;
	}

	// Token: 0x0600026D RID: 621 RVA: 0x00054794 File Offset: 0x00052994
	private string method_32(byte byte_7)
	{
		string result = string.Empty;
		if ((byte_7 & 9) == 8)
		{
			result = GClass62.smethod_1("3054");
		}
		else if ((byte_7 & 1) == 1)
		{
			result = GClass62.smethod_1("3062");
		}
		return result;
	}

	// Token: 0x0600026E RID: 622 RVA: 0x00018A1C File Offset: 0x00016C1C
	private string method_33(byte byte_7)
	{
		string result = string.Empty;
		if ((byte_7 & 128) != 0)
		{
			result = GClass62.smethod_1("3051");
		}
		return result;
	}

	// Token: 0x0600026F RID: 623 RVA: 0x00061A0C File Offset: 0x0005FC0C
	public override void vmethod_4()
	{
		if (GClass3.bool_0)
		{
			this.byte_4 = new byte[]
			{
				3,
				89,
				2,
				207
			};
		}
		else
		{
			byte[] array = this.method_38(this.byte_6);
			if (array.Length < 2 || array[1] != 84)
			{
				GClass3.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
	}

	// Token: 0x06000270 RID: 624 RVA: 0x00061A68 File Offset: 0x0005FC68
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
			this.method_35(gclass58_1);
		}
		else if (gclass58_1.string_2.Contains("RWUSERENTRY"))
		{
			this.method_36(gclass58_1);
		}
		else
		{
			this.method_34(gclass58_1);
		}
	}

	// Token: 0x06000271 RID: 625 RVA: 0x00061B20 File Offset: 0x0005FD20
	private void method_34(GClass58 gclass58_1)
	{
		byte[] array = this.method_38(gclass58_1.byte_0[0]);
		int num = 2000;
		if (gclass58_1.string_2.Contains("0.5SEC"))
		{
			num = 500;
		}
		else if (gclass58_1.string_2.Contains("1SEC"))
		{
			num = 1000;
		}
		bool flag = gclass58_1.string_2.Contains("EXECANY");
		int num2 = 0;
		if ((!flag && array.Length == 0) || (array.Length > 1 && array[1] == 127))
		{
			string string_ = string.Empty;
			if (array.Length > 3 && array[3] == 34)
			{
				string_ = GClass62.smethod_1("6053");
			}
			else if (array.Length > 3 && array[3] == 17)
			{
				string_ = GClass62.smethod_1("6054");
			}
			base.method_29(false, GClass62.smethod_1("6052"), string_);
		}
		else
		{
			if (gclass58_1.byte_0.Length > 2)
			{
				if (array.Length > 1 && array[1] != 127)
				{
					num2++;
				}
				for (int i = 1; i < gclass58_1.byte_0.Length; i++)
				{
					Thread.Sleep(num);
					array = this.method_38(gclass58_1.byte_0[i]);
					if (array.Length > 1 && array[1] != 127)
					{
						num2++;
					}
				}
			}
			else if (gclass58_1.byte_0.Length == 2)
			{
				if (array.Length > 1 && array[1] != 127)
				{
					num2++;
				}
				for (int i = 1; i < gclass58_1.byte_0.Length; i++)
				{
					Thread.Sleep(num);
					if (num > 1000)
					{
						Thread.Sleep(3 * num);
					}
					array = this.method_38(gclass58_1.byte_0[i]);
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
				base.method_29(false, GClass62.smethod_1("6052"), string.Empty);
			}
			else
			{
				base.method_29(false, GClass62.smethod_1("6051"), string.Empty);
			}
		}
	}

	// Token: 0x06000272 RID: 626 RVA: 0x00061D6C File Offset: 0x0005FF6C
	private void method_35(GClass58 gclass58_1)
	{
		byte[] array = this.method_38(gclass58_1.byte_0[0]);
		byte[] array2 = new byte[]
		{
			5,
			49,
			3,
			0,
			0,
			0
		};
		array2[3] = gclass58_1.byte_0[0][3];
		array2[4] = gclass58_1.byte_0[0][4];
		array2[5] = gclass58_1.byte_0[0][5];
		int num = 1800;
		bool flag = true;
		while (num > 0 && flag)
		{
			Thread.Sleep(500);
			GClass3.smethod_2("Checking routine status..", 1);
			array = this.method_38(array2);
			if (array.Length <= 3 || array[1] != 127 || (array[3] != 33 && array[3] != 35))
			{
				flag = false;
			}
			num--;
		}
		string string_ = GClass62.smethod_1("6056");
		if (array.Length > 4 && array[1] == 113)
		{
			if (gclass58_1.string_5.Length > 0)
			{
				byte b = array[4];
				this.string_3 = GClass16.smethod_0(array[4]);
				string_ = GClass62.smethod_1("6055") + " " + GClass16.smethod_0(array[4]);
				for (int i = 0; i < gclass58_1.string_5.Length; i++)
				{
					byte b2 = byte.Parse(gclass58_1.string_5[i].Substring(0, 2), NumberStyles.HexNumber);
					byte b3 = byte.Parse(gclass58_1.string_5[i].Substring(2, 2), NumberStyles.HexNumber);
					if ((b & b2) == b3 || i == gclass58_1.string_5.Length - 1)
					{
						string_ = gclass58_1.string_5[i].Substring(4);
						break;
					}
				}
			}
			else if (array.Length == 5)
			{
				string_ = GClass62.smethod_1("6055") + " " + GClass16.smethod_0(array[4]);
			}
			else if (array.Length == 6)
			{
				string_ = string.Concat(new string[]
				{
					GClass62.smethod_1("6055"),
					" ",
					GClass16.smethod_0(array[4]),
					" ",
					GClass16.smethod_0(array[5])
				});
			}
			else if (array.Length > 6)
			{
				string_ = string.Concat(new string[]
				{
					GClass62.smethod_1("6055"),
					" ",
					GClass16.smethod_0(array[4]),
					" ",
					GClass16.smethod_0(array[5]),
					" ",
					GClass16.smethod_0(array[6])
				});
			}
		}
		base.method_29(true, GClass62.smethod_1("6051"), string_);
	}

	// Token: 0x06000273 RID: 627 RVA: 0x0006201C File Offset: 0x0006021C
	private void method_36(GClass58 gclass58_1)
	{
		byte[] array = this.method_38(gclass58_1.byte_0[0]);
		if (array.Length < 4)
		{
			string string_ = string.Empty;
			base.method_29(false, GClass62.smethod_1("6052"), string_);
		}
		else
		{
			for (int i = 4; i < gclass58_1.byte_0[1].Length; i++)
			{
				byte b = 0;
				if (array.Length > i)
				{
					b = array[i];
				}
				if (gclass58_1.int_0 <= i - 3 && gclass58_1.int_0 + gclass58_1.int_1 > i - 3)
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
			array = this.method_38(gclass58_1.byte_0[1]);
			if (array.Length == 0 || (array.Length > 1 && array[1] == 127))
			{
				string string_ = string.Empty;
				if (array.Length > 3 && array[3] == 34)
				{
					string_ = GClass62.smethod_1("6053");
				}
				else if (array.Length > 3 && array[3] == 17)
				{
					string_ = GClass62.smethod_1("6054");
				}
				base.method_29(false, GClass62.smethod_1("6052"), string_);
			}
			else
			{
				Thread.Sleep(1000);
				base.method_29(false, GClass62.smethod_1("6051"), string.Empty);
			}
		}
	}

	// Token: 0x06000274 RID: 628 RVA: 0x000621B0 File Offset: 0x000603B0
	public override string vmethod_0(byte[] byte_7, string string_6, int int_6, int int_7, string[] string_7, string string_8)
	{
		byte[] array = this.method_38(byte_7);
		return this.vmethod_6(array, string_6, int_6, int_7, string_7, string_8);
	}

	// Token: 0x06000275 RID: 629 RVA: 0x000621D8 File Offset: 0x000603D8
	private byte[] method_37(byte[] byte_7)
	{
		if (this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		List<byte> list = new List<byte>();
		byte[] result;
		if (byte_7.Length < 2)
		{
			result = new byte[0];
		}
		else
		{
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
				int i = 1;
				while (i < list2[0].Length && num < byte_7.Length)
				{
					list2[0][i] = byte_7[num];
					num++;
					i++;
				}
				byte b = 33;
				while (num < byte_7.Length && b < 47)
				{
					list2.Add(new byte[(byte_7.Length - num > 7) ? 8 : (byte_7.Length - num + 1)]);
					int index = list2.Count - 1;
					list2[index][0] = b;
					b += 1;
					i = 1;
					while (i < list2[index].Length && num < byte_7.Length)
					{
						list2[index][i] = byte_7[num];
						num++;
						i++;
					}
				}
			}
			if (list2.Count > 1 && !GClass3.bool_12)
			{
				this.method_40("ATCAF0");
				this.method_40("ATST03");
			}
			this.method_39(GClass16.smethod_1(list2[0]));
			this.int_0 = GClass3.smethod_1();
			if (list2.Count > 1 && !GClass3.bool_12)
			{
				GClass3.smethod_2("Waiting FC...", 0);
				string text = this.method_41();
				if (text.Contains("NO DATA") || text.Contains("ERROR") || text.Contains("?") || !text.StartsWith("30"))
				{
					this.method_40("ATST99");
					return new byte[0];
				}
				for (int j = 1; j < list2.Count; j++)
				{
					if (j == list2.Count - 1)
					{
						this.method_40("ATST99");
					}
					this.method_39(GClass16.smethod_1(list2[j]));
					this.int_0 = GClass3.smethod_1();
					if (j < list2.Count - 1)
					{
						this.method_41();
					}
				}
			}
			string text2 = this.method_41();
			if (list2.Count > 1 && !GClass3.bool_12)
			{
				this.method_40("ATCAF1");
			}
			if (text2.Contains("NO DATA") || text2.Contains("ERROR") || text2.Contains("?"))
			{
				result = new byte[0];
			}
			else
			{
				int num2;
				while (text2.StartsWith("7F2278") || text2.StartsWith("7F1978"))
				{
					num2 = 0;
					while (num2 < text2.Length && text2[num2] != '\r' && text2[num2] != '\n' && text2[num2] != '>')
					{
						num2++;
					}
					text2 = text2.Substring(num2 + 1);
				}
				num2 = 0;
				while (num2 < text2.Length && text2[num2] != '\r' && text2[num2] != '\n' && text2[num2] != '>')
				{
					num2++;
				}
				string text3 = text2.Substring(0, num2);
				text2 = text2.Substring(num2 + 1);
				if (text3.Length == 3 && text3[0] == '0')
				{
					byte item = 0;
					try
					{
						item = GClass16.smethod_2(text3.Substring(1))[0];
					}
					catch (Exception)
					{
					}
					list.Add(item);
					while (text2.Length > 2 && text2[1] == ':')
					{
						num2 = 0;
						while (num2 < text2.Length && text2[num2] != '\r' && text2[num2] != '\n' && text2[num2] != '>')
						{
							num2++;
						}
						if (num2 > 2)
						{
							text3 = text2.Substring(2, num2 - 2);
							byte[] array = GClass16.smethod_2(text3);
							for (int i = 0; i < array.Length; i++)
							{
								list.Add(array[i]);
							}
						}
						text2 = text2.Substring(num2 + 1);
					}
				}
				else
				{
					byte[] array = GClass16.smethod_2(text3);
					list.Add((byte)array.Length);
					for (int i = 0; i < array.Length; i++)
					{
						list.Add(array[i]);
					}
				}
				GClass3.smethod_2("DECODED RESPONSE: " + GClass16.smethod_1(list.ToArray()), 0);
				byte[] array2 = new byte[0];
				if (list.Count > 0 && list[0] > 0 && (int)list[0] < list.Count)
				{
					array2 = new byte[(int)(list[0] + 1)];
					for (int i = 0; i <= (int)list[0]; i++)
					{
						array2[i] = list[i];
					}
				}
				result = array2;
			}
		}
		return result;
	}

	// Token: 0x06000276 RID: 630 RVA: 0x00062784 File Offset: 0x00060984
	private byte[] method_38(byte[] byte_7)
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
			byte[] array = this.method_37(byte_7);
			if (array.Length == 0 || (array.Length > 3 && array[1] == 127 && array[3] == 33))
			{
				array = this.method_37(byte_7);
			}
			if (array.Length == 0 || (array.Length > 3 && array[1] == 127 && array[3] == 33))
			{
				Thread.Sleep(100);
				array = this.method_37(byte_7);
			}
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
				base.method_21(true);
			}
			this.bool_2 = false;
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x06000277 RID: 631 RVA: 0x0006288C File Offset: 0x00060A8C
	public override string vmethod_6(byte[] byte_7, string string_6, int int_6, int int_7, string[] string_7, string string_8)
	{
		string text = string.Empty;
		int_6 += 3;
		string result;
		if (byte_7.Length <= int_6)
		{
			result = text;
		}
		else if (byte_7[1] == 127 && string_6 != "hex3")
		{
			result = text;
		}
		else
		{
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
			text = base.method_30(array, string_6, string_7, string_8);
			result = text;
		}
		return result;
	}

	// Token: 0x06000278 RID: 632 RVA: 0x00062918 File Offset: 0x00060B18
	private void method_39(string string_6)
	{
		GClass3.smethod_2("Send: " + string_6, 0);
		for (int i = 0; i < string_6.Length; i++)
		{
			this.serialPort_0.Write(string_6.Substring(i, 1));
		}
		this.serialPort_0.Write(this.serialPort_0.NewLine);
	}

	// Token: 0x06000279 RID: 633 RVA: 0x00062974 File Offset: 0x00060B74
	private void method_40(string string_6)
	{
		this.method_39(string_6);
		string text = this.method_41();
		if (!text.Contains("OK"))
		{
			GClass3.smethod_2("[" + string_6 + "] failed!", 0);
			if (GClass61.smethod_36() == 3)
			{
				this.method_39(string_6);
				text = this.method_41();
			}
		}
		this.int_0 = GClass3.smethod_1();
	}

	// Token: 0x0600027A RID: 634 RVA: 0x0005E6E4 File Offset: 0x0005C8E4
	private string method_41()
	{
		string text = string.Empty;
		while (!text.EndsWith(">"))
		{
			text += (char)this.serialPort_0.ReadByte();
		}
		GClass3.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x0600027B RID: 635 RVA: 0x000629D8 File Offset: 0x00060BD8
	private void method_42()
	{
		GClass3.smethod_2("PM started", 1);
		GClass3.int_2 = 0;
		SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
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
								gclass.method_1(this.vmethod_6(array[6], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							else if (gclass.string_0 == "Coolant Temperature")
							{
								gclass.method_1(this.vmethod_6(array[7], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							Thread.Sleep(50);
						}
						else
						{
							if (sortedList.ContainsKey(GClass16.smethod_1(gclass.byte_0[0])))
							{
								byte[] value = sortedList[GClass16.smethod_1(gclass.byte_0[0])];
								gclass.method_1(this.vmethod_6(value, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							else
							{
								byte[] value = this.method_38(gclass.byte_0[0]);
								gclass.method_1(this.vmethod_6(value, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
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
					this.string_4 = text;
				}
				else
				{
					this.string_4 = string.Empty;
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

	// Token: 0x0600027C RID: 636 RVA: 0x00062E84 File Offset: 0x00061084
	private void method_43()
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
			if (GClass3.smethod_1() > this.int_0 + this.int_5 && !this.bool_2)
			{
				byte[] array = this.method_38(this.byte_2);
				if (array.Length < 2 || array[1] != 126)
				{
					GClass3.smethod_2("KA response error!", 1);
					this.int_1++;
					if (array.Length == 0 && this.int_1 > 1)
					{
						GClass3.smethod_2("Terminate 7", 1);
						base.method_21(true);
					}
				}
				else
				{
					this.int_1 = 0;
				}
			}
		}
		GClass3.smethod_2("KA stopped", 1);
	}

	// Token: 0x040003C0 RID: 960
	private string string_5 = "7B0";

	// Token: 0x040003C1 RID: 961
	private int int_5 = 2000;

	// Token: 0x040003C2 RID: 962
	private byte[] byte_2;

	// Token: 0x040003C3 RID: 963
	private byte[] byte_3;

	// Token: 0x040003C4 RID: 964
	private byte[] byte_4;

	// Token: 0x040003C5 RID: 965
	private byte[] byte_5;

	// Token: 0x040003C6 RID: 966
	private byte[] byte_6;
}
