using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Text;
using System.Threading;

// Token: 0x02000055 RID: 85
public sealed class GClass7 : GClass4
{
	// Token: 0x06000230 RID: 560 RVA: 0x0005CFE8 File Offset: 0x0005B1E8
	public GClass7(byte byte_6, List<GClass58> list_3, List<GClass58> list_4)
	{
		this.byte_0 = byte_6;
		this.list_0 = list_4;
		this.list_1 = list_3;
	}

	// Token: 0x06000231 RID: 561 RVA: 0x0005D078 File Offset: 0x0005B278
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
				if (GClass61.smethod_36() == 3)
				{
					this.serialPort_0.ReadTimeout = 2000;
				}
				else
				{
					this.serialPort_0.ReadTimeout = 1000;
				}
				this.method_40("ATE0");
				this.method_40("ATL0");
				this.method_40("ATIB10");
				this.method_40("ATSP5");
				this.method_40("ATS0");
				this.method_40("ATSH 81" + GClass16.smethod_0(this.byte_0) + "F1");
				string text3 = this.method_40("1A97");
				if (!text3.Contains("OK"))
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
			GClass3.smethod_2(ex2.Message, 1);
			GClass3.smethod_2("Terminate 4", 1);
			base.method_21(ex2.Message != "0");
		}
	}

	// Token: 0x06000232 RID: 562 RVA: 0x0005D594 File Offset: 0x0005B794
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

	// Token: 0x06000233 RID: 563 RVA: 0x0005D67C File Offset: 0x0005B87C
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
			array = this.method_38(this.byte_4);
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
				gclass.string_4 = this.method_31(gclass.byte_0);
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

	// Token: 0x06000234 RID: 564 RVA: 0x00018938 File Offset: 0x00016B38
	private string method_31(byte byte_6)
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

	// Token: 0x06000235 RID: 565 RVA: 0x000189A0 File Offset: 0x00016BA0
	private string method_32(byte byte_6)
	{
		string result = string.Empty;
		if ((byte_6 & 96) == 0)
		{
			result = GClass62.smethod_1("3052");
		}
		else if ((byte_6 & 96) == 32)
		{
			result = GClass62.smethod_1("3053");
		}
		else if ((byte_6 & 96) == 64)
		{
			result = GClass62.smethod_1("3054");
		}
		else if ((byte_6 & 96) == 96)
		{
			result = GClass62.smethod_1("3055");
		}
		return result;
	}

	// Token: 0x06000236 RID: 566 RVA: 0x00018A1C File Offset: 0x00016C1C
	private string method_33(byte byte_6)
	{
		string result = string.Empty;
		if ((byte_6 & 128) != 0)
		{
			result = GClass62.smethod_1("3051");
		}
		return result;
	}

	// Token: 0x06000237 RID: 567 RVA: 0x0005DA48 File Offset: 0x0005BC48
	public override void vmethod_4()
	{
		if (GClass3.bool_0)
		{
			this.byte_3 = new byte[]
			{
				2,
				88,
				0,
				90
			};
		}
		else
		{
			byte[] array = this.method_38(this.byte_5);
			if (array.Length < 3 || array[1] != 84)
			{
				GClass3.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
	}

	// Token: 0x06000238 RID: 568 RVA: 0x0005DAA4 File Offset: 0x0005BCA4
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

	// Token: 0x06000239 RID: 569 RVA: 0x0005DB5C File Offset: 0x0005BD5C
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
		else if (gclass58_1.string_2.Contains("IORESULT"))
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
			string string_2 = GClass62.smethod_1("6052");
			string string_3 = string.Empty;
			if (i > 0)
			{
				string_2 = GClass62.smethod_1("6051");
				string_3 = GClass62.smethod_1("6055") + this.vmethod_0(gclass58_1.byte_0[1], "bits", gclass58_1.int_0, gclass58_1.int_1, gclass58_1.string_5, gclass58_1.string_6);
			}
			base.method_29(false, string_2, string_3);
		}
		else
		{
			if (gclass58_1.byte_0.Length > 2)
			{
				for (int i = 1; i < gclass58_1.byte_0.Length; i++)
				{
					Thread.Sleep(num);
					this.method_38(gclass58_1.byte_0[i]);
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
					this.method_38(gclass58_1.byte_0[i]);
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
			base.method_29(false, GClass62.smethod_1("6051"), string.Empty);
		}
	}

	// Token: 0x0600023A RID: 570 RVA: 0x0005DDC4 File Offset: 0x0005BFC4
	private void method_35(GClass58 gclass58_1)
	{
		byte[] array = this.method_38(gclass58_1.byte_0[0]);
		if (array.Length > 1 && array[1] == 127)
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
				array = this.method_38(array3);
				if (array.Length <= 3 || array[1] != 127 || array[2] != 51 || (array[3] != 33 && array[3] != 35))
				{
					flag = false;
				}
				num--;
			}
			string string_2 = GClass62.smethod_1("6056");
			if (array.Length > 3 && array[1] == 115)
			{
				if (gclass58_1.string_5.Length > 0)
				{
					byte b = array[3];
					if (gclass58_1.int_0 == 2 && array.Length > 4)
					{
						b = array[4];
					}
					string_2 = GClass62.smethod_1("6055") + " " + GClass16.smethod_0(array[3]);
					for (int i = 0; i < gclass58_1.string_5.Length; i++)
					{
						byte b2 = byte.Parse(gclass58_1.string_5[i].Substring(0, 2), NumberStyles.HexNumber);
						byte b3 = byte.Parse(gclass58_1.string_5[i].Substring(2, 2), NumberStyles.HexNumber);
						if ((b & b2) == b3 || i == gclass58_1.string_5.Length - 1)
						{
							string_2 = gclass58_1.string_5[i].Substring(4);
							break;
						}
					}
				}
				else if (array.Length == 4)
				{
					string_2 = GClass62.smethod_1("6055") + " " + GClass16.smethod_0(array[3]);
				}
				else if (array.Length == 5)
				{
					string_2 = string.Concat(new string[]
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
					string_2 = string.Concat(new string[]
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
			base.method_29(true, GClass62.smethod_1("6051"), string_2);
		}
	}

	// Token: 0x0600023B RID: 571 RVA: 0x0005E0EC File Offset: 0x0005C2EC
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

	// Token: 0x0600023C RID: 572 RVA: 0x0005E280 File Offset: 0x0005C480
	public override string vmethod_0(byte[] byte_6, string string_5, int int_6, int int_7, string[] string_6, string string_7)
	{
		byte[] array = this.method_38(byte_6);
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_38(byte_6);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_38(byte_6);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_38(byte_6);
		}
		return this.vmethod_6(array, string_5, int_6, int_7, string_6, string_7);
	}

	// Token: 0x0600023D RID: 573 RVA: 0x0005E314 File Offset: 0x0005C514
	private byte[] method_37(byte[] byte_6)
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
		this.method_39(GClass16.smethod_1(array));
		string text = this.method_41();
		byte[] result;
		if (text.Contains("NO DATA") || text.Contains("ERROR"))
		{
			result = new byte[0];
		}
		else
		{
			string text2 = string.Empty;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == '\r' || text[i] == '\n' || text[i] == '>')
				{
					if (stringBuilder.Length > 1)
					{
						text2 = stringBuilder.ToString();
					}
					stringBuilder = new StringBuilder();
				}
				else
				{
					stringBuilder.Append(text[i]);
				}
			}
			text2 = "00" + text2;
			GClass3.smethod_2("DECODED RESPONSE: " + text2, 0);
			result = GClass16.smethod_2(text2);
		}
		return result;
	}

	// Token: 0x0600023E RID: 574 RVA: 0x0005E448 File Offset: 0x0005C648
	private byte[] method_38(byte[] byte_6)
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
			byte[] array = this.method_37(byte_6);
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_37(byte_6);
			}
			if (array.Length > 3 && array[1] == 127 && array[3] == 33)
			{
				array = this.method_37(byte_6);
			}
			if (GClass61.smethod_36() == 3)
			{
				if (array.Length == 0)
				{
					array = this.method_37(byte_6);
				}
				if (array.Length == 0)
				{
					array = this.method_37(byte_6);
				}
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

	// Token: 0x0600023F RID: 575 RVA: 0x0005E56C File Offset: 0x0005C76C
	public override string vmethod_6(byte[] byte_6, string string_5, int int_6, int int_7, string[] string_6, string string_7)
	{
		string text = string.Empty;
		int_6 += 2;
		string result;
		if (byte_6.Length <= int_6)
		{
			result = text;
		}
		else if (byte_6[1] == 127)
		{
			result = text;
		}
		else
		{
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
			text = base.method_30(array, string_5, string_6, string_7);
			result = text;
		}
		return result;
	}

	// Token: 0x06000240 RID: 576 RVA: 0x0005E5E8 File Offset: 0x0005C7E8
	private void method_39(string string_5)
	{
		GClass3.smethod_2("Send: " + string_5, 0);
		if (GClass61.smethod_36() == 3)
		{
			for (int i = 0; i < string_5.Length; i++)
			{
				this.serialPort_0.Write(string_5.Substring(i, 1));
			}
			this.serialPort_0.Write(this.serialPort_0.NewLine);
		}
		else
		{
			this.serialPort_0.WriteLine(string_5);
		}
	}

	// Token: 0x06000241 RID: 577 RVA: 0x0005E660 File Offset: 0x0005C860
	private string method_40(string string_5)
	{
		this.method_39(string_5);
		string text = this.method_41();
		GClass3.smethod_2("Response: " + text, 0);
		if (!text.Contains("OK"))
		{
			GClass3.smethod_2("[" + string_5 + "] failed!", 0);
			if (GClass61.smethod_36() == 3)
			{
				text = this.method_41();
				GClass3.smethod_2("Response: " + text, 0);
			}
		}
		this.int_0 = GClass3.smethod_1();
		return text;
	}

	// Token: 0x06000242 RID: 578 RVA: 0x0005E6E4 File Offset: 0x0005C8E4
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

	// Token: 0x06000243 RID: 579 RVA: 0x0005E738 File Offset: 0x0005C938
	private void method_42()
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
							Thread.Sleep(50);
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

	// Token: 0x06000244 RID: 580 RVA: 0x0005EAF8 File Offset: 0x0005CCF8
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

	// Token: 0x04000393 RID: 915
	private int int_5 = 1000;

	// Token: 0x04000394 RID: 916
	private byte[] byte_2 = new byte[]
	{
		1,
		62
	};

	// Token: 0x04000395 RID: 917
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

	// Token: 0x04000396 RID: 918
	private byte[] byte_4 = new byte[]
	{
		4,
		24,
		0,
		byte.MaxValue,
		0
	};

	// Token: 0x04000397 RID: 919
	private byte[] byte_5 = new byte[]
	{
		3,
		20,
		byte.MaxValue,
		0
	};
}
