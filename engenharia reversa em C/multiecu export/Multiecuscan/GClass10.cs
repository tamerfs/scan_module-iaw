using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Threading;

// Token: 0x02000013 RID: 19
public sealed class GClass10 : GClass0
{
	// Token: 0x060000FB RID: 251 RVA: 0x00017344 File Offset: 0x00015544
	public GClass10(byte byte_7, string string_32, List<GClass104> list_3, List<GClass104> list_4)
	{
		this.byte_0 = byte_7;
		this.string_5 = string_32;
		this.list_0 = list_4;
		this.list_1 = list_3;
	}

	// Token: 0x060000FC RID: 252 RVA: 0x0001751C File Offset: 0x0001571C
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
					if (gclass.int_2 == 1770)
					{
						this.string_1 = string_;
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_33))
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
				this.serialPort_0.NewLine = "\r";
				this.serialPort_0.Open();
				GClass126.smethod_2("Serial port opened!", 1);
				GClass126.smethod_2("Init OBDKey and Wakeup ECU.", 1);
				this.serialPort_0.ReadTimeout = 5000;
				this.method_30("ATZ");
				GClass126.smethod_2("Init OBDKey interface", 1);
				if (!this.method_32().Contains("OBDKey"))
				{
					GClass126.smethod_2("Invalid OBDKey interface!", 1);
					throw new Exception("Invalid OBDKey interface!");
				}
				if (GClass125.smethod_44() == 4)
				{
					this.serialPort_0.ReadTimeout = 100;
					this.method_30("ATBRD16");
					string text = ((char)this.serialPort_0.ReadByte()).ToString() ?? "";
					while (!text.Contains("OK\r") && !text.Contains("?") && text.Length < 20)
					{
						text += ((char)this.serialPort_0.ReadByte()).ToString();
					}
					this.serialPort_0.BaudRate = 250000;
					this.serialPort_0.ReadTimeout = 80;
					text = (((char)this.serialPort_0.ReadByte()).ToString() ?? "");
					while (!text.Contains("\r") && text.Length < 20)
					{
						text += ((char)this.serialPort_0.ReadByte()).ToString();
					}
					this.method_31("");
				}
				this.serialPort_0.ReadTimeout = 1200;
				this.method_31("ATE0");
				this.method_31("ATL0");
				this.method_31("ATH0");
				this.method_31("ATSPC");
				this.method_31("ATS0");
				this.method_31("ATCAF0");
				this.method_31("ATCFC0");
				this.method_31("ATCRA " + this.string_5);
				this.method_31("ATSH 7B0");
				this.method_31("ATAT1");
				if (GClass125.smethod_44() == 5)
				{
					this.string_6 = "ATST29";
					this.string_7 = "ATST30";
				}
				this.method_31(this.string_6);
				this.method_31("ATBI");
				byte[] array2 = this.method_29(this.byte_3);
				if (array2.Length < 3 || array2[1] != 80 || array2[2] != 129)
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
				Thread thread = new Thread(new ThreadStart(this.method_34));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_33))
				{
					Priority = ThreadPriority.Highest
				}.Start();
			}
			SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
			sortedList.Add(GClass127.smethod_11(new byte[]
			{
				2,
				33,
				162
			}), this.method_29(new byte[]
			{
				2,
				33,
				162
			}));
			sortedList.Add(GClass127.smethod_11(new byte[]
			{
				2,
				33,
				35
			}), this.method_29(new byte[]
			{
				2,
				33,
				35
			}));
			for (int k = 0; k < this.list_1.Count; k++)
			{
				GClass104 gclass2 = this.list_1[k];
				if (sortedList.ContainsKey(GClass127.smethod_11(gclass2.byte_0[0])))
				{
					byte[] array3 = sortedList[GClass127.smethod_11(gclass2.byte_0[0])];
					gclass2.method_1(this.r4(array3, gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
				}
				else
				{
					byte[] value = this.method_29(gclass2.byte_0[0]);
					gclass2.method_1(this.r4(value, gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
					sortedList.Add(GClass127.smethod_11(gclass2.byte_0[0]), value);
				}
				if (gclass2.int_2 == 1770)
				{
					this.string_1 = gclass2.method_0();
					GClass126.smethod_2("ECU ISO Code: " + gclass2.method_0(), 2);
				}
			}
			if (bool_5 && this.gclass104_0 != null)
			{
				Thread.Sleep(200);
				byte[] array4 = this.method_29(this.gclass104_0.byte_0[0]);
				this.string_3 = GClass127.smethod_11(array4);
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

	// Token: 0x060000FD RID: 253 RVA: 0x00017C78 File Offset: 0x00015E78
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
				this.serialPort_0.ReadTimeout = 100;
				if (GClass125.smethod_44() == 4)
				{
					this.method_31("ATZ");
				}
				else
				{
					this.method_31("ATPC");
				}
			}
			catch (Exception)
			{
			}
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

	// Token: 0x060000FE RID: 254 RVA: 0x00017D88 File Offset: 0x00015F88
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
			array = this.method_29(this.byte_5);
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
			gclass.string_5 = this.method_21(gclass.byte_0);
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

	// Token: 0x060000FF RID: 255 RVA: 0x00009148 File Offset: 0x00007348
	private string method_21(byte byte_7)
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

	// Token: 0x06000100 RID: 256 RVA: 0x000091A4 File Offset: 0x000073A4
	private string method_22(byte byte_7)
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

	// Token: 0x06000101 RID: 257 RVA: 0x00006FC4 File Offset: 0x000051C4
	private string method_23(byte byte_7)
	{
		string result = "";
		if ((byte_7 & 128) != 0)
		{
			result = GClass121.smethod_6("3051");
		}
		return result;
	}

	// Token: 0x06000102 RID: 258 RVA: 0x000180EC File Offset: 0x000162EC
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
		byte[] array = this.method_29(this.byte_6);
		if (array.Length < 3 || array[1] != 84)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x06000103 RID: 259 RVA: 0x00018140 File Offset: 0x00016340
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
			if (gclass104_1.string_2.Contains("RWANDXOR"))
			{
				this.method_26(gclass104_1);
				return;
			}
			if (gclass104_1.string_2.Contains("RWUSERENTRY"))
			{
				this.method_27(gclass104_1);
				return;
			}
			this.method_24(gclass104_1);
			return;
		}
	}

	// Token: 0x06000104 RID: 260 RVA: 0x00018204 File Offset: 0x00016404
	private void method_24(GClass104 gclass104_1)
	{
		byte[] array = this.method_29(gclass104_1.byte_0[0]);
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
		if (gclass104_1.byte_0.Length > 2)
		{
			if (array.Length > 1 && array[1] != 127)
			{
				num2++;
			}
			for (int i = 1; i < gclass104_1.byte_0.Length; i++)
			{
				Thread.Sleep(num);
				array = this.method_29(gclass104_1.byte_0[i]);
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
				array = this.method_29(gclass104_1.byte_0[j]);
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

	// Token: 0x06000105 RID: 261 RVA: 0x000183EC File Offset: 0x000165EC
	private void method_25(GClass104 gclass104_1)
	{
		byte[] array = this.method_29(gclass104_1.byte_0[0]);
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
			array = this.method_29(array3);
			if (array.Length <= 3 || array[1] != 127 || array[2] != 51 || (array[3] != 33 && array[3] != 35))
			{
				flag = false;
			}
			num--;
		}
		string text = GClass121.smethod_6("6056");
		if (array.Length > 3 && array[1] == 115)
		{
			if (gclass104_1.string_5.Length != 0)
			{
				byte b = array[3];
				if (gclass104_1.int_0 == 2 && array.Length > 4)
				{
					b = array[4];
				}
				this.string_3 = GClass127.smethod_23(array[3]);
				text = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
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
					text = gclass104_1.string_5[i].Substring(4);
					break;
				}
			}
			else if (array.Length == 4)
			{
				text = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
			}
			else if (array.Length == 5)
			{
				text = string.Concat(new string[]
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
				text = string.Concat(new string[]
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
		base.method_19(true, GClass121.smethod_6("6051"), text);
	}

	// Token: 0x06000106 RID: 262 RVA: 0x00018654 File Offset: 0x00016854
	private void method_26(GClass104 gclass104_1)
	{
		byte[] array = this.method_29(gclass104_1.byte_0[0]);
		if (array.Length < 4)
		{
			string text = "";
			base.method_19(false, GClass121.smethod_6("6052"), text);
			return;
		}
		byte b = array[3];
		byte b2 = byte.Parse(gclass104_1.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
		byte b3 = byte.Parse(gclass104_1.string_5[0].Substring(2, 2), NumberStyles.HexNumber);
		b &= b2;
		b ^= b3;
		Thread.Sleep(1000);
		gclass104_1.byte_0[1][3] = b;
		array = this.method_29(gclass104_1.byte_0[1]);
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

	// Token: 0x06000107 RID: 263 RVA: 0x0001877C File Offset: 0x0001697C
	private void method_27(GClass104 gclass104_1)
	{
		byte[] array = this.method_29(gclass104_1.byte_0[0]);
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
		array = this.method_29(gclass104_1.byte_0[1]);
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

	// Token: 0x06000108 RID: 264 RVA: 0x000188DC File Offset: 0x00016ADC
	public override string vmethod_0(byte[] byte_7, string string_32, int int_6, int int_7, string[] string_33, string string_34)
	{
		byte[] array = this.method_29(byte_7);
		return this.r4(array, string_32, int_6, int_7, string_33, string_34);
	}

	// Token: 0x06000109 RID: 265 RVA: 0x00018900 File Offset: 0x00016B00
	private byte[] method_28(byte[] byte_7)
	{
		if (this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		List<byte[]> list = new List<byte[]>();
		if (byte_7.Length < 8)
		{
			list.Add(new byte[8]);
			list[0][0] = this.byte_0;
			for (int i = 0; i < list[0].Length - 1; i++)
			{
				if (i < byte_7.Length)
				{
					list[0][i + 1] = byte_7[i];
				}
				else
				{
					list[0][i + 1] = 0;
				}
			}
		}
		else
		{
			list.Add(new byte[8]);
			list[0][0] = this.byte_0;
			list[0][1] = 16;
			int num = 0;
			for (int j = 2; j < list[0].Length; j++)
			{
				if (num < byte_7.Length)
				{
					list[0][j] = byte_7[num];
					num++;
				}
				else
				{
					list[0][j] = 0;
				}
			}
			byte b = 32;
			while (num < byte_7.Length && b < 47)
			{
				list.Add(new byte[8]);
				int index = list.Count - 1;
				list[index][0] = this.byte_0;
				list[index][1] = b;
				b += 1;
				for (int k = 2; k < list[index].Length; k++)
				{
					if (num < byte_7.Length)
					{
						list[index][k] = byte_7[num];
						num++;
					}
					else
					{
						list[index][k] = 0;
					}
				}
			}
		}
		if (list.Count > 1 && this.int_4 != 0 && !GClass126.bool_23)
		{
			if (this.int_4 == 1)
			{
				this.method_31(this.string_21);
			}
			else
			{
				this.method_31(this.string_20);
			}
		}
		this.method_30(GClass127.smethod_11(list[0]));
		this.int_0 = GClass126.smethod_1();
		if (list.Count > 1)
		{
			GClass126.smethod_2(this.string_8, 0);
			string text = this.method_32();
			if (this.int_4 == 0 && (text.Contains(this.string_9) || text.Contains(this.string_10) || text.Contains(this.string_11) || !text.Contains(this.string_12)))
			{
				return new byte[0];
			}
			if (this.int_4 != 0 && !GClass126.bool_23)
			{
				this.method_31(this.string_17);
			}
			else if (GClass125.smethod_44() == 4)
			{
				this.method_31(this.string_19);
			}
			else
			{
				this.method_31(this.string_17);
			}
			for (int l = 1; l < list.Count; l++)
			{
				if (l == list.Count - 1)
				{
					if (this.int_4 == 0)
					{
						this.method_31(this.string_22);
					}
					else
					{
						this.method_31(this.string_23);
					}
				}
				this.method_30(GClass127.smethod_11(list[l]));
				this.int_0 = GClass126.smethod_1();
				if (l < list.Count - 1)
				{
					this.method_32();
				}
			}
		}
		string text2 = this.method_32();
		if (this.int_4 != 0 && text2.Contains(this.string_9))
		{
			this.method_30(GClass127.smethod_23(this.byte_0) + this.string_13);
			text2 = this.method_32();
			if (this.int_4 != 0 && text2.Contains(this.string_9))
			{
				this.method_30(GClass127.smethod_23(this.byte_0) + this.string_13);
				text2 = this.method_32();
			}
		}
		if (list.Count > 1)
		{
			this.method_31(this.string_6);
		}
		if (!text2.Contains(this.string_9) && !text2.Contains(this.string_10) && !text2.Contains(this.string_11))
		{
			int num2 = 0;
			while (num2 < text2.Length && text2[num2] != '\r' && text2[num2] != '\n')
			{
				if (text2[num2] == '>')
				{
					break;
				}
				num2++;
			}
			byte[] array = GClass127.smethod_32(text2.Substring(0, num2));
			if (array.Length >= 2)
			{
				if (array[0] == 241)
				{
					List<byte> list2 = new List<byte>();
					if (array[1] < 16)
					{
						for (int m = 1; m < array.Length; m++)
						{
							list2.Add(array[m]);
						}
					}
					else if (array[1] >= 16 && array[1] < 32)
					{
						for (int n = 2; n < array.Length; n++)
						{
							list2.Add(array[n]);
						}
						if (GClass125.smethod_44() == 4)
						{
							this.method_31(this.string_7);
						}
						this.method_30(GClass127.smethod_23(this.byte_0) + this.string_14);
						text2 = this.method_32();
						if (GClass125.smethod_44() == 4)
						{
							this.method_31(this.string_6);
						}
						if (GClass125.smethod_44() == 5 && text2.Contains(this.string_9))
						{
							this.method_30(GClass127.smethod_11(list[0]));
							this.int_0 = GClass126.smethod_1();
							while (this.int_0 + 180 > GClass126.smethod_1())
							{
							}
							this.method_30(GClass127.smethod_23(this.byte_0) + this.string_14);
							text2 = this.method_32();
							if (!text2.Contains(this.string_9) && !text2.Contains(this.string_10) && !text2.Contains(this.string_11))
							{
								num2 = 0;
								while (num2 < text2.Length && text2[num2] != '\r' && text2[num2] != '\n')
								{
									if (text2[num2] == '>')
									{
										break;
									}
									num2++;
								}
								array = GClass127.smethod_32(text2.Substring(0, num2));
								if (array.Length >= 2)
								{
									if (array[0] == 241)
									{
										list2.Clear();
										for (int num3 = 2; num3 < array.Length; num3++)
										{
											list2.Add(array[num3]);
										}
										text2 = this.method_32();
										goto IL_678;
									}
								}
								return new byte[0];
							}
							return new byte[0];
						}
						IL_678:
						while (text2.StartsWith(this.string_15))
						{
							num2 = 0;
							while (num2 < text2.Length && text2[num2] != '\r' && text2[num2] != '\n')
							{
								if (text2[num2] == '>')
								{
									break;
								}
								num2++;
							}
							string text3 = text2.Substring(0, num2);
							text2 = text2.Substring(num2 + 1);
							array = GClass127.smethod_32(text3);
							if (array.Length > 2 && array[0] == 241 && array[1] >= 32)
							{
								for (int num4 = 2; num4 < array.Length; num4++)
								{
									list2.Add(array[num4]);
								}
							}
						}
					}
					GClass126.smethod_2(this.string_16 + GClass127.smethod_11(list2.ToArray()), 0);
					byte[] array2 = new byte[0];
					if (list2.Count > 0 && list2[0] > 0 && (int)list2[0] < list2.Count)
					{
						array2 = new byte[(int)(list2[0] + 1)];
						for (int num5 = 0; num5 <= (int)list2[0]; num5++)
						{
							array2[num5] = list2[num5];
						}
					}
					return array2;
				}
			}
			return new byte[0];
		}
		return new byte[0];
	}

	// Token: 0x0600010A RID: 266 RVA: 0x00019028 File Offset: 0x00017228
	private byte[] method_29(byte[] byte_7)
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
			byte[] array = this.method_28(byte_7);
			if (array.Length == 0)
			{
				Thread.Sleep(100);
				array = this.method_28(byte_7);
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

	// Token: 0x0600010B RID: 267 RVA: 0x0000A088 File Offset: 0x00008288
	public override string r4(byte[] byte_7, string string_32, int int_6, int int_7, string[] string_33, string string_34)
	{
		string result = "";
		int_6 += 2;
		if (byte_7.Length <= int_6)
		{
			return result;
		}
		if (byte_7[1] == 127 && string_32 != "hex3")
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
		return base.method_20(array, string_32, string_33, string_34);
	}

	// Token: 0x0600010C RID: 268 RVA: 0x000190E4 File Offset: 0x000172E4
	private void method_30(string string_32)
	{
		if (GClass125.smethod_44() == 5)
		{
			GClass126.smethod_2(this.string_26 + string_32.Replace(this.string_24, this.string_25), 0);
			this.serialPort_0.WriteLine(string_32.Replace(this.string_24, this.string_25));
			return;
		}
		GClass126.smethod_2(this.string_26 + string_32, 0);
		this.serialPort_0.WriteLine(string_32);
	}

	// Token: 0x0600010D RID: 269 RVA: 0x00002EC4 File Offset: 0x000010C4
	private void method_31(string string_32)
	{
		this.method_30(string_32);
		if (!this.method_32().Contains(this.string_27))
		{
			GClass126.smethod_2(this.string_28 + string_32 + this.string_29, 0);
		}
		this.int_0 = GClass126.smethod_1();
	}

	// Token: 0x0600010E RID: 270 RVA: 0x00019158 File Offset: 0x00017358
	private string method_32()
	{
		string text = this.string_25;
		while (!text.EndsWith(this.string_30))
		{
			text += ((char)this.serialPort_0.ReadByte()).ToString();
		}
		GClass126.smethod_2(this.string_31 + text, 0);
		return text;
	}

	// Token: 0x0600010F RID: 271 RVA: 0x000191AC File Offset: 0x000173AC
	private void method_33()
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
									byte[] value = this.method_29(gclass.byte_0[0]);
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

	// Token: 0x06000110 RID: 272 RVA: 0x00019620 File Offset: 0x00017820
	private void method_34()
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
				byte[] array = this.method_29(this.byte_2);
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

	// Token: 0x040000B0 RID: 176
	private string string_5 = "7B0";

	// Token: 0x040000B1 RID: 177
	private int int_5 = 1000;

	// Token: 0x040000B2 RID: 178
	private byte[] byte_2 = new byte[]
	{
		1,
		62
	};

	// Token: 0x040000B3 RID: 179
	private byte[] byte_3 = new byte[]
	{
		2,
		16,
		129
	};

	// Token: 0x040000B4 RID: 180
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
		48
	};

	// Token: 0x040000B5 RID: 181
	private byte[] byte_5 = new byte[]
	{
		4,
		24,
		0,
		byte.MaxValue,
		0
	};

	// Token: 0x040000B6 RID: 182
	private byte[] byte_6 = new byte[]
	{
		3,
		20,
		byte.MaxValue,
		0
	};

	// Token: 0x040000B7 RID: 183
	private string string_6 = "ATST28";

	// Token: 0x040000B8 RID: 184
	private string string_7 = "ATST35";

	// Token: 0x040000B9 RID: 185
	private string string_8 = "Waiting FC...";

	// Token: 0x040000BA RID: 186
	private string string_9 = "NO DATA";

	// Token: 0x040000BB RID: 187
	private string string_10 = "ERROR";

	// Token: 0x040000BC RID: 188
	private string string_11 = "?";

	// Token: 0x040000BD RID: 189
	private string string_12 = "F130";

	// Token: 0x040000BE RID: 190
	private string string_13 = " 00";

	// Token: 0x040000BF RID: 191
	private string string_14 = " 30 FF 00 00 00 00 00";

	// Token: 0x040000C0 RID: 192
	private string string_15 = "F1";

	// Token: 0x040000C1 RID: 193
	private string string_16 = "DECODED RESPONSE: ";

	// Token: 0x040000C2 RID: 194
	private string string_17 = "ATST01";

	// Token: 0x040000C3 RID: 195
	private string string_18 = "ATST03";

	// Token: 0x040000C4 RID: 196
	private string string_19 = "ATST05";

	// Token: 0x040000C5 RID: 197
	private string string_20 = "ATST07";

	// Token: 0x040000C6 RID: 198
	private string string_21 = "ATST09";

	// Token: 0x040000C7 RID: 199
	private string string_22 = "ATST99";

	// Token: 0x040000C8 RID: 200
	private string string_23 = "ATSTFF";

	// Token: 0x040000C9 RID: 201
	private string string_24 = " ";

	// Token: 0x040000CA RID: 202
	private string string_25 = "";

	// Token: 0x040000CB RID: 203
	private string string_26 = "Send: ";

	// Token: 0x040000CC RID: 204
	private string string_27 = "OK";

	// Token: 0x040000CD RID: 205
	private string string_28 = "[";

	// Token: 0x040000CE RID: 206
	private string string_29 = "] failed!";

	// Token: 0x040000CF RID: 207
	private string string_30 = ">";

	// Token: 0x040000D0 RID: 208
	private string string_31 = "Response: ";
}
