using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Threading;

// Token: 0x0200000D RID: 13
public sealed class GClass5 : GClass4
{
	// Token: 0x06000045 RID: 69 RVA: 0x0001A418 File Offset: 0x00018618
	public GClass5(byte byte_7, string string_32, List<GClass58> list_3, List<GClass58> list_4)
	{
		this.byte_0 = byte_7;
		this.string_5 = string_32;
		this.list_0 = list_4;
		this.list_1 = list_3;
	}

	// Token: 0x06000046 RID: 70 RVA: 0x0001A5F0 File Offset: 0x000187F0
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
					string string_ = this.vmethod_6(array[i], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
					gclass.method_1(string_);
					if (gclass.int_2 == 1770)
					{
						this.string_1 = string_;
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_43))
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
				this.serialPort_0.NewLine = "\r";
				this.serialPort_0.Open();
				GClass3.smethod_2("Serial port opened!", 1);
				GClass3.smethod_2("Init OBDKey and Wakeup ECU.", 1);
				this.serialPort_0.ReadTimeout = 5000;
				this.method_40("ATZ");
				GClass3.smethod_2("Init OBDKey interface", 1);
				string text = this.method_42();
				if (!text.Contains("OBDKey"))
				{
					GClass3.smethod_2("Invalid OBDKey interface!", 1);
					throw new Exception("Invalid OBDKey interface!");
				}
				if (GClass61.smethod_36() == 4)
				{
					this.serialPort_0.ReadTimeout = 100;
					this.method_40("ATBRD16");
					string text2 = string.Concat((char)this.serialPort_0.ReadByte());
					while (!text2.Contains("OK\r") && !text2.Contains("?") && text2.Length < 20)
					{
						text2 += (char)this.serialPort_0.ReadByte();
					}
					this.serialPort_0.BaudRate = 250000;
					this.serialPort_0.ReadTimeout = 80;
					text2 = string.Concat((char)this.serialPort_0.ReadByte());
					while (!text2.Contains("\r") && text2.Length < 20)
					{
						text2 += (char)this.serialPort_0.ReadByte();
					}
					this.method_41(string.Empty);
				}
				this.serialPort_0.ReadTimeout = 1200;
				this.method_41("ATE0");
				this.method_41("ATL0");
				this.method_41("ATH0");
				this.method_41("ATSPC");
				this.method_41("ATS0");
				this.method_41("ATCAF0");
				this.method_41("ATCFC0");
				this.method_41("ATCRA " + this.string_5);
				this.method_41("ATSH 7B0");
				this.method_41("ATAT1");
				if (GClass61.smethod_36() == 5)
				{
					this.string_6 = "ATST29";
					this.string_7 = "ATST30";
				}
				this.method_41(this.string_6);
				this.method_41("ATBI");
				byte[] array2 = this.method_39(this.byte_3);
				if (array2.Length < 3 || array2[1] != 80 || array2[2] != 129)
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
				Thread thread = new Thread(new ThreadStart(this.method_44));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_43))
				{
					Priority = ThreadPriority.Highest
				}.Start();
			}
			SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
			sortedList.Add(GClass16.smethod_1(new byte[]
			{
				2,
				33,
				162
			}), this.method_39(new byte[]
			{
				2,
				33,
				162
			}));
			sortedList.Add(GClass16.smethod_1(new byte[]
			{
				2,
				33,
				35
			}), this.method_39(new byte[]
			{
				2,
				33,
				35
			}));
			for (int i = 0; i < this.list_1.Count; i++)
			{
				GClass58 gclass = this.list_1[i];
				if (sortedList.ContainsKey(GClass16.smethod_1(gclass.byte_0[0])))
				{
					byte[] value = sortedList[GClass16.smethod_1(gclass.byte_0[0])];
					gclass.method_1(this.vmethod_6(value, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
				else
				{
					byte[] value = this.method_39(gclass.byte_0[0]);
					gclass.method_1(this.vmethod_6(value, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					sortedList.Add(GClass16.smethod_1(gclass.byte_0[0]), value);
				}
				if (gclass.int_2 == 1770)
				{
					this.string_1 = gclass.method_0();
					GClass3.smethod_2("ECU ISO Code: " + gclass.method_0(), 2);
				}
			}
			if (bool_5 && this.gclass58_0 != null)
			{
				Thread.Sleep(200);
				byte[] byte_ = this.method_39(this.gclass58_0.byte_0[0]);
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

	// Token: 0x06000047 RID: 71 RVA: 0x0001AD7C File Offset: 0x00018F7C
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
						this.serialPort_0.ReadTimeout = 100;
						if (GClass61.smethod_36() == 4)
						{
							this.method_41("ATZ");
						}
						else
						{
							this.method_41("ATPC");
						}
					}
					catch (Exception)
					{
					}
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
				base.method_27(bool_6);
			}
		}
	}

	// Token: 0x06000048 RID: 72 RVA: 0x0001AEA0 File Offset: 0x000190A0
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
			array = this.method_39(this.byte_5);
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

	// Token: 0x06000049 RID: 73 RVA: 0x00018938 File Offset: 0x00016B38
	private string method_31(byte byte_7)
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

	// Token: 0x0600004A RID: 74 RVA: 0x000189A0 File Offset: 0x00016BA0
	private string method_32(byte byte_7)
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

	// Token: 0x0600004B RID: 75 RVA: 0x00018A1C File Offset: 0x00016C1C
	private string method_33(byte byte_7)
	{
		string result = string.Empty;
		if ((byte_7 & 128) != 0)
		{
			result = GClass62.smethod_1("3051");
		}
		return result;
	}

	// Token: 0x0600004C RID: 76 RVA: 0x0001B26C File Offset: 0x0001946C
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
			byte[] array = this.method_39(this.byte_6);
			if (array.Length < 3 || array[1] != 84)
			{
				GClass3.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
	}

	// Token: 0x0600004D RID: 77 RVA: 0x0001B2C8 File Offset: 0x000194C8
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
		else if (gclass58_1.string_2.Contains("RWANDXOR"))
		{
			this.method_36(gclass58_1);
		}
		else if (gclass58_1.string_2.Contains("RWUSERENTRY"))
		{
			this.method_37(gclass58_1);
		}
		else
		{
			this.method_34(gclass58_1);
		}
	}

	// Token: 0x0600004E RID: 78 RVA: 0x0001B3A0 File Offset: 0x000195A0
	private void method_34(GClass58 gclass58_1)
	{
		byte[] array = this.method_39(gclass58_1.byte_0[0]);
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
			if (gclass58_1.byte_0.Length > 2)
			{
				if (array.Length > 1 && array[1] != 127)
				{
					num2++;
				}
				for (int i = 1; i < gclass58_1.byte_0.Length; i++)
				{
					Thread.Sleep(num);
					array = this.method_39(gclass58_1.byte_0[i]);
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
					array = this.method_39(gclass58_1.byte_0[i]);
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

	// Token: 0x0600004F RID: 79 RVA: 0x0001B5EC File Offset: 0x000197EC
	private void method_35(GClass58 gclass58_1)
	{
		byte[] array = this.method_39(gclass58_1.byte_0[0]);
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
			array = this.method_39(array3);
			if (array.Length <= 3 || array[1] != 127 || array[2] != 51 || (array[3] != 33 && array[3] != 35))
			{
				flag = false;
			}
			num--;
		}
		string text = GClass62.smethod_1("6056");
		if (array.Length > 3 && array[1] == 115)
		{
			if (gclass58_1.string_5.Length > 0)
			{
				byte b = array[3];
				if (gclass58_1.int_0 == 2 && array.Length > 4)
				{
					b = array[4];
				}
				this.string_3 = GClass16.smethod_0(array[3]);
				text = GClass62.smethod_1("6055") + " " + GClass16.smethod_0(array[3]);
				for (int i = 0; i < gclass58_1.string_5.Length; i++)
				{
					byte b2 = byte.Parse(gclass58_1.string_5[i].Substring(0, 2), NumberStyles.HexNumber);
					byte b3 = byte.Parse(gclass58_1.string_5[i].Substring(2, 2), NumberStyles.HexNumber);
					if ((b & b2) == b3 || i == gclass58_1.string_5.Length - 1)
					{
						text = gclass58_1.string_5[i].Substring(4);
						break;
					}
				}
			}
			else if (array.Length == 4)
			{
				text = GClass62.smethod_1("6055") + " " + GClass16.smethod_0(array[3]);
			}
			else if (array.Length == 5)
			{
				text = string.Concat(new string[]
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
				text = string.Concat(new string[]
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
		base.method_29(true, GClass62.smethod_1("6051"), text);
	}

	// Token: 0x06000050 RID: 80 RVA: 0x0001B8A8 File Offset: 0x00019AA8
	private void method_36(GClass58 gclass58_1)
	{
		byte[] array = this.method_39(gclass58_1.byte_0[0]);
		if (array.Length < 4)
		{
			string text = string.Empty;
			base.method_29(false, GClass62.smethod_1("6052"), text);
		}
		else
		{
			byte b = array[3];
			byte b2 = byte.Parse(gclass58_1.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
			byte b3 = byte.Parse(gclass58_1.string_5[0].Substring(2, 2), NumberStyles.HexNumber);
			b &= b2;
			b ^= b3;
			Thread.Sleep(1000);
			gclass58_1.byte_0[1][3] = b;
			array = this.method_39(gclass58_1.byte_0[1]);
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

	// Token: 0x06000051 RID: 81 RVA: 0x0001B9F0 File Offset: 0x00019BF0
	private void method_37(GClass58 gclass58_1)
	{
		byte[] array = this.method_39(gclass58_1.byte_0[0]);
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
			array = this.method_39(gclass58_1.byte_0[1]);
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

	// Token: 0x06000052 RID: 82 RVA: 0x0001BB84 File Offset: 0x00019D84
	public override string vmethod_0(byte[] byte_7, string string_32, int int_6, int int_7, string[] string_33, string string_34)
	{
		byte[] array = this.method_39(byte_7);
		return this.vmethod_6(array, string_32, int_6, int_7, string_33, string_34);
	}

	// Token: 0x06000053 RID: 83 RVA: 0x0001BBAC File Offset: 0x00019DAC
	private byte[] method_38(byte[] byte_7)
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
			for (int i = 2; i < list[0].Length; i++)
			{
				if (num < byte_7.Length)
				{
					list[0][i] = byte_7[num];
					num++;
				}
				else
				{
					list[0][i] = 0;
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
				for (int i = 2; i < list[index].Length; i++)
				{
					if (num < byte_7.Length)
					{
						list[index][i] = byte_7[num];
						num++;
					}
					else
					{
						list[index][i] = 0;
					}
				}
			}
		}
		if (list.Count > 1 && this.int_4 != 0 && !GClass3.bool_12)
		{
			if (this.int_4 == 1)
			{
				this.method_41(this.string_21);
			}
			else
			{
				this.method_41(this.string_20);
			}
		}
		this.method_40(GClass16.smethod_1(list[0]));
		this.int_0 = GClass3.smethod_1();
		if (list.Count > 1)
		{
			GClass3.smethod_2(this.string_8, 0);
			string text = this.method_42();
			if (this.int_4 == 0 && (text.Contains(this.string_9) || text.Contains(this.string_10) || text.Contains(this.string_11) || !text.Contains(this.string_12)))
			{
				return new byte[0];
			}
			if (this.int_4 != 0 && !GClass3.bool_12)
			{
				this.method_41(this.string_17);
			}
			else if (GClass61.smethod_36() == 4)
			{
				this.method_41(this.string_19);
			}
			else
			{
				this.method_41(this.string_17);
			}
			for (int j = 1; j < list.Count; j++)
			{
				if (j == list.Count - 1)
				{
					if (this.int_4 == 0)
					{
						this.method_41(this.string_22);
					}
					else
					{
						this.method_41(this.string_23);
					}
				}
				this.method_40(GClass16.smethod_1(list[j]));
				this.int_0 = GClass3.smethod_1();
				if (j < list.Count - 1)
				{
					this.method_42();
				}
			}
		}
		string text2 = this.method_42();
		if (this.int_4 != 0 && text2.Contains(this.string_9))
		{
			this.method_40(GClass16.smethod_0(this.byte_0) + this.string_13);
			text2 = this.method_42();
			if (this.int_4 != 0 && text2.Contains(this.string_9))
			{
				this.method_40(GClass16.smethod_0(this.byte_0) + this.string_13);
				text2 = this.method_42();
			}
		}
		if (list.Count > 1)
		{
			this.method_41(this.string_6);
		}
		byte[] result;
		if (text2.Contains(this.string_9) || text2.Contains(this.string_10) || text2.Contains(this.string_11))
		{
			result = new byte[0];
		}
		else
		{
			int num2 = 0;
			while (num2 < text2.Length && text2[num2] != '\r' && text2[num2] != '\n' && text2[num2] != '>')
			{
				num2++;
			}
			string text3 = text2.Substring(0, num2);
			byte[] array = GClass16.smethod_2(text3);
			if (array.Length < 2 || array[0] != 241)
			{
				result = new byte[0];
			}
			else
			{
				List<byte> list2 = new List<byte>();
				if (array[1] < 16)
				{
					for (int i = 1; i < array.Length; i++)
					{
						list2.Add(array[i]);
					}
				}
				else if (array[1] >= 16 && array[1] < 32)
				{
					for (int i = 2; i < array.Length; i++)
					{
						list2.Add(array[i]);
					}
					if (GClass61.smethod_36() == 4)
					{
						this.method_41(this.string_7);
					}
					this.method_40(GClass16.smethod_0(this.byte_0) + this.string_14);
					text2 = this.method_42();
					if (GClass61.smethod_36() == 4)
					{
						this.method_41(this.string_6);
					}
					if (GClass61.smethod_36() == 5 && text2.Contains(this.string_9))
					{
						this.method_40(GClass16.smethod_1(list[0]));
						this.int_0 = GClass3.smethod_1();
						while (this.int_0 + 180 > GClass3.smethod_1())
						{
						}
						this.method_40(GClass16.smethod_0(this.byte_0) + this.string_14);
						text2 = this.method_42();
						if (text2.Contains(this.string_9) || text2.Contains(this.string_10) || text2.Contains(this.string_11))
						{
							return new byte[0];
						}
						num2 = 0;
						while (num2 < text2.Length && text2[num2] != '\r' && text2[num2] != '\n' && text2[num2] != '>')
						{
							num2++;
						}
						text3 = text2.Substring(0, num2);
						array = GClass16.smethod_2(text3);
						if (array.Length < 2 || array[0] != 241)
						{
							return new byte[0];
						}
						list2.Clear();
						for (int i = 2; i < array.Length; i++)
						{
							list2.Add(array[i]);
						}
						text2 = this.method_42();
					}
					while (text2.StartsWith(this.string_15))
					{
						num2 = 0;
						text3 = string.Empty;
						while (num2 < text2.Length && text2[num2] != '\r' && text2[num2] != '\n' && text2[num2] != '>')
						{
							num2++;
						}
						text3 = text2.Substring(0, num2);
						text2 = text2.Substring(num2 + 1);
						array = GClass16.smethod_2(text3);
						if (array.Length > 2 && array[0] == 241 && array[1] >= 32)
						{
							for (int i = 2; i < array.Length; i++)
							{
								list2.Add(array[i]);
							}
						}
					}
				}
				GClass3.smethod_2(this.string_16 + GClass16.smethod_1(list2.ToArray()), 0);
				byte[] array2 = new byte[0];
				if (list2.Count > 0 && list2[0] > 0 && (int)list2[0] < list2.Count)
				{
					array2 = new byte[(int)(list2[0] + 1)];
					for (int i = 0; i <= (int)list2[0]; i++)
					{
						array2[i] = list2[i];
					}
				}
				result = array2;
			}
		}
		return result;
	}

	// Token: 0x06000054 RID: 84 RVA: 0x0001C3D8 File Offset: 0x0001A5D8
	private byte[] method_39(byte[] byte_7)
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
			byte[] array = this.method_38(byte_7);
			if (array.Length == 0)
			{
				Thread.Sleep(100);
				array = this.method_38(byte_7);
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

	// Token: 0x06000055 RID: 85 RVA: 0x0001C49C File Offset: 0x0001A69C
	public override string vmethod_6(byte[] byte_7, string string_32, int int_6, int int_7, string[] string_33, string string_34)
	{
		string text = string.Empty;
		int_6 += 2;
		string result;
		if (byte_7.Length <= int_6)
		{
			result = text;
		}
		else if (byte_7[1] == 127 && string_32 != "hex3")
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
			text = base.method_30(array, string_32, string_33, string_34);
			result = text;
		}
		return result;
	}

	// Token: 0x06000056 RID: 86 RVA: 0x0001C528 File Offset: 0x0001A728
	private void method_40(string string_32)
	{
		if (GClass61.smethod_36() == 5)
		{
			GClass3.smethod_2(this.string_26 + string_32.Replace(this.string_24, this.string_25), 0);
			this.serialPort_0.WriteLine(string_32.Replace(this.string_24, this.string_25));
		}
		else
		{
			GClass3.smethod_2(this.string_26 + string_32, 0);
			this.serialPort_0.WriteLine(string_32);
		}
	}

	// Token: 0x06000057 RID: 87 RVA: 0x0001C5A4 File Offset: 0x0001A7A4
	private void method_41(string string_32)
	{
		this.method_40(string_32);
		string text = this.method_42();
		if (!text.Contains(this.string_27))
		{
			GClass3.smethod_2(this.string_28 + string_32 + this.string_29, 0);
		}
		this.int_0 = GClass3.smethod_1();
	}

	// Token: 0x06000058 RID: 88 RVA: 0x0001C5F0 File Offset: 0x0001A7F0
	private string method_42()
	{
		string text = this.string_25;
		while (!text.EndsWith(this.string_30))
		{
			text += (char)this.serialPort_0.ReadByte();
		}
		GClass3.smethod_2(this.string_31 + text, 0);
		return text;
	}

	// Token: 0x06000059 RID: 89 RVA: 0x0001C644 File Offset: 0x0001A844
	private void method_43()
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
								byte[] value = this.method_39(gclass.byte_0[0]);
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

	// Token: 0x0600005A RID: 90 RVA: 0x0001CAF0 File Offset: 0x0001ACF0
	private void method_44()
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
				byte[] array = this.method_39(this.byte_2);
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

	// Token: 0x04000031 RID: 49
	private string string_5 = "7B0";

	// Token: 0x04000032 RID: 50
	private int int_5 = 1000;

	// Token: 0x04000033 RID: 51
	private byte[] byte_2 = new byte[]
	{
		1,
		62
	};

	// Token: 0x04000034 RID: 52
	private byte[] byte_3 = new byte[]
	{
		2,
		16,
		129
	};

	// Token: 0x04000035 RID: 53
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

	// Token: 0x04000036 RID: 54
	private byte[] byte_5 = new byte[]
	{
		4,
		24,
		0,
		byte.MaxValue,
		0
	};

	// Token: 0x04000037 RID: 55
	private byte[] byte_6 = new byte[]
	{
		3,
		20,
		byte.MaxValue,
		0
	};

	// Token: 0x04000038 RID: 56
	private string string_6 = "ATST28";

	// Token: 0x04000039 RID: 57
	private string string_7 = "ATST35";

	// Token: 0x0400003A RID: 58
	private string string_8 = "Waiting FC...";

	// Token: 0x0400003B RID: 59
	private string string_9 = "NO DATA";

	// Token: 0x0400003C RID: 60
	private string string_10 = "ERROR";

	// Token: 0x0400003D RID: 61
	private string string_11 = "?";

	// Token: 0x0400003E RID: 62
	private string string_12 = "F130";

	// Token: 0x0400003F RID: 63
	private string string_13 = " 00";

	// Token: 0x04000040 RID: 64
	private string string_14 = " 30 FF 00 00 00 00 00";

	// Token: 0x04000041 RID: 65
	private string string_15 = "F1";

	// Token: 0x04000042 RID: 66
	private string string_16 = "DECODED RESPONSE: ";

	// Token: 0x04000043 RID: 67
	private string string_17 = "ATST01";

	// Token: 0x04000044 RID: 68
	private string string_18 = "ATST03";

	// Token: 0x04000045 RID: 69
	private string string_19 = "ATST05";

	// Token: 0x04000046 RID: 70
	private string string_20 = "ATST07";

	// Token: 0x04000047 RID: 71
	private string string_21 = "ATST09";

	// Token: 0x04000048 RID: 72
	private string string_22 = "ATST99";

	// Token: 0x04000049 RID: 73
	private string string_23 = "ATSTFF";

	// Token: 0x0400004A RID: 74
	private string string_24 = " ";

	// Token: 0x0400004B RID: 75
	private string string_25 = string.Empty;

	// Token: 0x0400004C RID: 76
	private string string_26 = "Send: ";

	// Token: 0x0400004D RID: 77
	private string string_27 = "OK";

	// Token: 0x0400004E RID: 78
	private string string_28 = "[";

	// Token: 0x0400004F RID: 79
	private string string_29 = "] failed!";

	// Token: 0x04000050 RID: 80
	private string string_30 = ">";

	// Token: 0x04000051 RID: 81
	private string string_31 = "Response: ";
}
