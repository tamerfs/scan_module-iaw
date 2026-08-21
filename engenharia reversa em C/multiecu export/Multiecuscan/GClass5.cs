using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Text;
using System.Threading;

// Token: 0x0200000E RID: 14
public sealed class GClass5 : GClass0
{
	// Token: 0x0600008E RID: 142 RVA: 0x0000D6F0 File Offset: 0x0000B8F0
	public GClass5(byte byte_6, List<GClass104> list_3, List<GClass104> list_4)
	{
		this.byte_0 = byte_6;
		this.list_0 = list_4;
		this.list_1 = list_3;
	}

	// Token: 0x0600008F RID: 143 RVA: 0x0000D780 File Offset: 0x0000B980
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
					string text = this.r4(array[j], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
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
				if (GClass125.smethod_44() == 3)
				{
					this.serialPort_0.ReadTimeout = 2000;
				}
				else
				{
					this.serialPort_0.ReadTimeout = 1000;
				}
				this.method_30("ATE0");
				this.method_30("ATL0");
				this.method_30("ATIB10");
				this.method_30("ATSP5");
				this.method_30("ATS0");
				this.method_30("ATSH 81" + GClass127.smethod_23(this.byte_0) + "F1");
				if (!this.method_30("1A97").Contains("OK"))
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
			GClass126.smethod_2(ex2.Message, 1);
			GClass126.smethod_2("Terminate 4", 1);
			base.method_11(ex2.Message != "0");
		}
	}

	// Token: 0x06000090 RID: 144 RVA: 0x0000DC64 File Offset: 0x0000BE64
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

	// Token: 0x06000091 RID: 145 RVA: 0x0000DD3C File Offset: 0x0000BF3C
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
			array = this.method_28(this.byte_4);
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

	// Token: 0x06000092 RID: 146 RVA: 0x00009148 File Offset: 0x00007348
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

	// Token: 0x06000093 RID: 147 RVA: 0x000091A4 File Offset: 0x000073A4
	private string method_22(byte byte_6)
	{
		string result = "";
		if ((byte_6 & 96) == 0)
		{
			result = GClass121.smethod_6("3052");
		}
		else if ((byte_6 & 96) == 32)
		{
			result = GClass121.smethod_6("3053");
		}
		else if ((byte_6 & 96) == 64)
		{
			result = GClass121.smethod_6("3054");
		}
		else if ((byte_6 & 96) == 96)
		{
			result = GClass121.smethod_6("3055");
		}
		return result;
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00006FC4 File Offset: 0x000051C4
	private string method_23(byte byte_6)
	{
		string result = "";
		if ((byte_6 & 128) != 0)
		{
			result = GClass121.smethod_6("3051");
		}
		return result;
	}

	// Token: 0x06000095 RID: 149 RVA: 0x0000E0A0 File Offset: 0x0000C2A0
	public override void r2()
	{
		if (GClass126.bool_0)
		{
			this.byte_3 = new byte[]
			{
				2,
				88,
				0,
				90
			};
			return;
		}
		byte[] array = this.method_28(this.byte_5);
		if (array.Length < 3 || array[1] != 84)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x06000096 RID: 150 RVA: 0x0000E0F4 File Offset: 0x0000C2F4
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

	// Token: 0x06000097 RID: 151 RVA: 0x0000E19C File Offset: 0x0000C39C
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
					string string_ = GClass121.smethod_6("6052");
					string string_2 = "";
					if (num2 > 0)
					{
						string_ = GClass121.smethod_6("6051");
						string_2 = GClass121.smethod_6("6055") + this.vmethod_0(gclass104_1.byte_0[1], "bits", gclass104_1.int_0, gclass104_1.int_1, gclass104_1.string_5, gclass104_1.string_6);
					}
					base.method_19(false, string_, string_2);
					return;
				}
				if (gclass104_1.byte_0.Length > 2)
				{
					for (int i = 1; i < gclass104_1.byte_0.Length; i++)
					{
						Thread.Sleep(num);
						this.method_28(gclass104_1.byte_0[i]);
					}
				}
				else if (gclass104_1.byte_0.Length == 2)
				{
					for (int j = 1; j < gclass104_1.byte_0.Length; j++)
					{
						Thread.Sleep(num);
						if (num > 1000)
						{
							Thread.Sleep(3 * num);
						}
						this.method_28(gclass104_1.byte_0[j]);
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
				base.method_19(false, GClass121.smethod_6("6051"), "");
				return;
			}
		}
		string string_3 = "";
		if (array.Length > 3 && array[3] == 34)
		{
			string_3 = GClass121.smethod_6("6053");
		}
		else if (array.Length > 3 && array[3] == 17)
		{
			string_3 = GClass121.smethod_6("6054");
		}
		base.method_19(false, GClass121.smethod_6("6052"), string_3);
	}

	// Token: 0x06000098 RID: 152 RVA: 0x0000E3C0 File Offset: 0x0000C5C0
	private void method_25(GClass104 gclass104_1)
	{
		byte[] array = this.method_28(gclass104_1.byte_0[0]);
		if (array.Length > 1 && array[1] == 127)
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
			array = this.method_28(array3);
			if (array.Length <= 3 || array[1] != 127 || array[2] != 51 || (array[3] != 33 && array[3] != 35))
			{
				flag = false;
			}
			num--;
		}
		string string_2 = GClass121.smethod_6("6056");
		if (array.Length > 3 && array[1] == 115)
		{
			if (gclass104_1.string_5.Length != 0)
			{
				byte b = array[3];
				if (gclass104_1.int_0 == 2 && array.Length > 4)
				{
					b = array[4];
				}
				string_2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
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
					string_2 = gclass104_1.string_5[i].Substring(4);
					break;
				}
			}
			else if (array.Length == 4)
			{
				string_2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
			}
			else if (array.Length == 5)
			{
				string_2 = string.Concat(new string[]
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
				string_2 = string.Concat(new string[]
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
		base.method_19(true, GClass121.smethod_6("6051"), string_2);
	}

	// Token: 0x06000099 RID: 153 RVA: 0x0000E674 File Offset: 0x0000C874
	private void method_26(GClass104 gclass104_1)
	{
		byte[] array = this.method_28(gclass104_1.byte_0[0]);
		if (array.Length < 4)
		{
			string string_ = "";
			base.method_19(false, GClass121.smethod_6("6052"), string_);
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

	// Token: 0x0600009A RID: 154 RVA: 0x0000E7D4 File Offset: 0x0000C9D4
	public override string vmethod_0(byte[] byte_6, string string_5, int int_6, int int_7, string[] string_6, string string_7)
	{
		byte[] array = this.method_28(byte_6);
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_28(byte_6);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_28(byte_6);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_28(byte_6);
		}
		return this.r4(array, string_5, int_6, int_7, string_6, string_7);
	}

	// Token: 0x0600009B RID: 155 RVA: 0x0000E84C File Offset: 0x0000CA4C
	private byte[] method_27(byte[] byte_6)
	{
		if (this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		byte[] array = new byte[byte_6.Length - 1];
		for (int i = 1; i < byte_6.Length; i++)
		{
			array[i - 1] = byte_6[i];
		}
		this.method_29(GClass127.smethod_11(array));
		string text = this.method_31();
		if (!text.Contains("NO DATA") && !text.Contains("ERROR"))
		{
			string text2 = "";
			StringBuilder stringBuilder = new StringBuilder();
			int j = 0;
			while (j < text.Length)
			{
				if (text[j] == '\r' || text[j] == '\n')
				{
					goto IL_BC;
				}
				if (text[j] == '>')
				{
					goto IL_BC;
				}
				stringBuilder.Append(text[j]);
				IL_D2:
				j++;
				continue;
				IL_BC:
				if (stringBuilder.Length > 1)
				{
					text2 = stringBuilder.ToString();
				}
				stringBuilder = new StringBuilder();
				goto IL_D2;
			}
			text2 = "00" + text2;
			GClass126.smethod_2("DECODED RESPONSE: " + text2, 0);
			return GClass127.smethod_32(text2);
		}
		return new byte[0];
	}

	// Token: 0x0600009C RID: 156 RVA: 0x0000E968 File Offset: 0x0000CB68
	private byte[] method_28(byte[] byte_6)
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
			byte[] array = this.method_27(byte_6);
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_27(byte_6);
			}
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_27(byte_6);
			}
			if (GClass125.smethod_44() == 3)
			{
				if (array.Length == 0)
				{
					array = this.method_27(byte_6);
				}
				if (array.Length == 0)
				{
					array = this.method_27(byte_6);
				}
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

	// Token: 0x0600009D RID: 157 RVA: 0x0000EA68 File Offset: 0x0000CC68
	public override string r4(byte[] byte_6, string string_5, int int_6, int int_7, string[] string_6, string string_7)
	{
		string result = "";
		int_6 += 2;
		if (byte_6.Length <= int_6)
		{
			return result;
		}
		if (byte_6[1] == 127)
		{
			return result;
		}
		int num = byte_6.Length - int_6;
		if (int_7 < num)
		{
			num = int_7;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_6[i + int_6];
		}
		return base.method_20(array, string_5, string_6, string_7);
	}

	// Token: 0x0600009E RID: 158 RVA: 0x0000EACC File Offset: 0x0000CCCC
	private void method_29(string string_5)
	{
		GClass126.smethod_2("Send: " + string_5, 0);
		if (GClass125.smethod_44() == 3)
		{
			for (int i = 0; i < string_5.Length; i++)
			{
				this.serialPort_0.Write(string_5.Substring(i, 1));
			}
			this.serialPort_0.Write(this.serialPort_0.NewLine);
			return;
		}
		this.serialPort_0.WriteLine(string_5);
	}

	// Token: 0x0600009F RID: 159 RVA: 0x0000EB3C File Offset: 0x0000CD3C
	private string method_30(string string_5)
	{
		this.method_29(string_5);
		string text = this.method_31();
		GClass126.smethod_2("Response: " + text, 0);
		if (!text.Contains("OK"))
		{
			GClass126.smethod_2("[" + string_5 + "] failed!", 0);
			if (GClass125.smethod_44() == 3)
			{
				text = this.method_31();
				GClass126.smethod_2("Response: " + text, 0);
			}
		}
		this.int_0 = GClass126.smethod_1();
		return text;
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00007D98 File Offset: 0x00005F98
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

	// Token: 0x060000A1 RID: 161 RVA: 0x0000EBB8 File Offset: 0x0000CDB8
	private void method_32()
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
								Thread.Sleep(50);
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

	// Token: 0x060000A2 RID: 162 RVA: 0x0000EF48 File Offset: 0x0000D148
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

	// Token: 0x0400005D RID: 93
	private int int_5 = 1000;

	// Token: 0x0400005E RID: 94
	private byte[] byte_2 = new byte[]
	{
		1,
		62
	};

	// Token: 0x0400005F RID: 95
	private byte[] byte_3 = new byte[]
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

	// Token: 0x04000060 RID: 96
	private byte[] byte_4 = new byte[]
	{
		4,
		24,
		0,
		byte.MaxValue,
		0
	};

	// Token: 0x04000061 RID: 97
	private byte[] byte_5 = new byte[]
	{
		3,
		20,
		byte.MaxValue,
		0
	};
}
