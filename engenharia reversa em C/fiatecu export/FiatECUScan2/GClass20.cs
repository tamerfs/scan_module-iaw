using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

// Token: 0x0200000A RID: 10
public abstract class GClass20 : GClass19
{
	// Token: 0x06000027 RID: 39 RVA: 0x00017FC4 File Offset: 0x000161C4
	protected GClass20()
	{
		byte[] array = new byte[4];
		array[0] = 3;
		array[1] = 23;
		this.byte_6 = array;
		this.string_7 = new string[]
		{
			"0C 57 01 01 10 61 24 A7 1D 08 2D FF 40",
			"00 00 00 38 22 99 12 65 29 81 02 00",
			"00 00 00 95 18 24 76 4A 6B 1F 00 00"
		};
		base..ctor();
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00018084 File Offset: 0x00016284
	protected void method_33()
	{
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
			new Thread(new ThreadStart(this.method_45))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_28();
			throw new Exception("1");
		}
	}

	// Token: 0x06000029 RID: 41
	protected abstract void vmethod_8(GEnum0 genum0_0);

	// Token: 0x0600002A RID: 42 RVA: 0x00018234 File Offset: 0x00016434
	public override void vmethod_1(GEnum0 genum0_0)
	{
		try
		{
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
				this.method_33();
			}
			else
			{
				this.vmethod_8(genum0_0);
			}
			if (GClass3.bool_14)
			{
				throw new Exception("ESC");
			}
			if (genum0_0 == (GEnum0)0)
			{
				this.method_41(new byte[]
				{
					2,
					131,
					1
				});
				Thread thread = new Thread(new ThreadStart(this.method_46));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_45))
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
			}
		}
		catch (Exception ex)
		{
			if (ex.Message == "ESC")
			{
				this.string_4 = "Aborted by user";
			}
			GClass3.smethod_2(ex.Message, 1);
			GClass3.smethod_2("Terminate 4", 1);
			base.method_22(ex.Message != "0");
		}
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00018444 File Offset: 0x00016644
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
							this.method_43("ATZ");
						}
						else
						{
							this.method_43("ATPC");
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
				base.method_29(bool_6);
			}
		}
	}

	// Token: 0x0600002C RID: 44 RVA: 0x0001856C File Offset: 0x0001676C
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
			array = this.method_41(this.byte_4);
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
				gclass.string_4 = this.method_34(gclass.byte_0);
				gclass.string_5 = this.method_35(gclass.byte_0);
				gclass.string_6 = this.method_36(gclass.byte_0);
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

	// Token: 0x0600002D RID: 45 RVA: 0x00018938 File Offset: 0x00016B38
	private string method_34(byte byte_7)
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

	// Token: 0x0600002E RID: 46 RVA: 0x000189A0 File Offset: 0x00016BA0
	private string method_35(byte byte_7)
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

	// Token: 0x0600002F RID: 47 RVA: 0x00018A1C File Offset: 0x00016C1C
	private string method_36(byte byte_7)
	{
		string result = string.Empty;
		if ((byte_7 & 128) != 0)
		{
			result = GClass62.smethod_1("3051");
		}
		return result;
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00018A4C File Offset: 0x00016C4C
	public override void vmethod_5()
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
			byte[] array = this.method_41(this.byte_5);
			if (array.Length < 3 || array[1] != 84)
			{
				GClass3.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00018AA8 File Offset: 0x00016CA8
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
									value = this.method_41(byte_);
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

	// Token: 0x06000032 RID: 50 RVA: 0x00018D50 File Offset: 0x00016F50
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
			this.method_38(gclass58_1);
		}
		else if (gclass58_1.string_2.Contains("RWUSERENTRY"))
		{
			this.method_39(gclass58_1);
		}
		else
		{
			this.method_37(gclass58_1);
		}
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00018E08 File Offset: 0x00017008
	private void method_37(GClass58 gclass58_1)
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
			byte[] array = this.method_41(gclass58_1.byte_0[i]);
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
								array = this.method_41(gclass58_1.byte_0[gclass58_1.byte_0.Length - 1]);
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
				string string_ = string.Empty;
				if (num2 > 0)
				{
					text = GClass62.smethod_1("6051");
					string_ = GClass62.smethod_1("6055") + this.vmethod_0(gclass58_1.byte_0[1], "bits", gclass58_1.int_0, gclass58_1.int_1, gclass58_1.string_5, gclass58_1.string_6);
				}
				base.method_31(false, text, string_);
			}
			else
			{
				string string_2 = string.Empty;
				if (array.Length > 3 && array[3] == 34)
				{
					string_2 = GClass62.smethod_1("6053");
				}
				else if (array.Length > 3 && array[3] == 17)
				{
					string_2 = GClass62.smethod_1("6054");
				}
				base.method_31(false, GClass62.smethod_1("6052"), string_2);
			}
			return;
		}
		base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
	}

	// Token: 0x06000034 RID: 52 RVA: 0x000190F4 File Offset: 0x000172F4
	private void method_38(GClass58 gclass58_1)
	{
		byte[] array = this.method_41(gclass58_1.byte_0[0]);
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
			base.method_31(false, GClass62.smethod_1("6052"), string_);
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
						array = this.method_41(array4);
						num = 0;
						IL_114:
						GClass3.smethod_2("Checking routine status..", 1);
						array = this.method_41(array3);
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
			base.method_31(true, GClass62.smethod_1("6051"), string_2);
		}
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00019478 File Offset: 0x00017678
	private void method_39(GClass58 gclass58_1)
	{
		byte[] array = this.method_41(gclass58_1.byte_0[0]);
		if (array.Length < 4)
		{
			string string_ = string.Empty;
			base.method_31(false, GClass62.smethod_1("6052"), string_);
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
			array = this.method_41(gclass58_1.byte_0[1]);
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
				base.method_31(false, GClass62.smethod_1("6052"), string_);
			}
			else
			{
				Thread.Sleep(1000);
				base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
			}
		}
	}

	// Token: 0x06000036 RID: 54 RVA: 0x0001960C File Offset: 0x0001780C
	public override string vmethod_0(byte[] byte_7, string string_8, int int_7, int int_8, string[] string_9, string string_10)
	{
		byte[] array = this.method_41(byte_7);
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_41(byte_7);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_41(byte_7);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_41(byte_7);
		}
		return this.vmethod_7(array, string_8, int_7, int_8, string_9, string_10);
	}

	// Token: 0x06000037 RID: 55 RVA: 0x000196A0 File Offset: 0x000178A0
	private byte[] method_40(byte[] byte_7)
	{
		if (this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		byte[] array = new byte[byte_7.Length - 1];
		for (int i = 1; i < byte_7.Length; i++)
		{
			array[i - 1] = byte_7[i];
		}
		if (array.Length > 0 && (array[0] == 33 || array[0] == 26 || array[0] == 62))
		{
			this.method_42(GClass16.smethod_1(array) + " 1");
		}
		else
		{
			this.method_42(GClass16.smethod_1(array));
		}
		string text = this.method_44();
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

	// Token: 0x06000038 RID: 56 RVA: 0x00019810 File Offset: 0x00017A10
	private byte[] method_41(byte[] byte_7)
	{
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			if (GClass61.smethod_36() == 4 || GClass61.smethod_36() == 5)
			{
				while (this.int_0 + this.int_6 > GClass3.smethod_1())
				{
				}
			}
			this.int_0 = GClass3.smethod_1();
			byte[] array = this.method_40(byte_7);
			if (array.Length == 0 || (array.Length > 3 && array[1] == 127 && array[3] == 33))
			{
				array = this.method_40(byte_7);
			}
			if (array.Length == 0 || (array.Length > 3 && array[1] == 127 && array[3] == 33))
			{
				Thread.Sleep(100);
				array = this.method_40(byte_7);
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
				base.method_22(true);
			}
			this.bool_2 = false;
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00019948 File Offset: 0x00017B48
	public override string vmethod_7(byte[] byte_7, string string_8, int int_7, int int_8, string[] string_9, string string_10)
	{
		string text = string.Empty;
		int_7 += 2;
		string result;
		if (byte_7.Length <= int_7)
		{
			result = text;
		}
		else if (byte_7[1] == 127)
		{
			result = text;
		}
		else
		{
			int num = byte_7.Length - int_7;
			if (int_8 < num)
			{
				num = int_8;
			}
			byte[] array = new byte[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = byte_7[i + int_7];
			}
			text = base.method_32(array, string_8, string_9, string_10);
			result = text;
		}
		return result;
	}

	// Token: 0x0600003A RID: 58 RVA: 0x000199C4 File Offset: 0x00017BC4
	protected void method_42(string string_8)
	{
		GClass3.smethod_2("Send: " + string_8, 0);
		if (GClass61.smethod_38())
		{
			for (int i = 0; i < string_8.Length; i++)
			{
				this.serialPort_0.Write(string_8.Substring(i, 1));
			}
			this.serialPort_0.Write(this.serialPort_0.NewLine);
		}
		else
		{
			this.serialPort_0.WriteLine(string_8);
		}
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00019A38 File Offset: 0x00017C38
	protected string method_43(string string_8)
	{
		this.method_42(string_8);
		string text = this.method_44();
		if (!text.Contains("OK"))
		{
			GClass3.smethod_2("[" + string_8 + "] failed!", 0);
			if (GClass61.smethod_38())
			{
				text = this.method_44();
			}
		}
		this.int_0 = GClass3.smethod_1();
		return text;
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00019A98 File Offset: 0x00017C98
	protected string method_44()
	{
		string text = string.Empty;
		while (!text.EndsWith(">"))
		{
			text += (char)this.serialPort_0.ReadByte();
		}
		GClass3.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00019AEC File Offset: 0x00017CEC
	private void method_45()
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
							Thread.Sleep(50);
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
								byte[] value = this.method_41(gclass.byte_0[0]);
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

	// Token: 0x0600003E RID: 62 RVA: 0x00019F38 File Offset: 0x00018138
	private void method_46()
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
				byte[] array = this.method_41(this.byte_2);
				if (array.Length < 2 || array[1] != 126)
				{
					GClass3.smethod_2("KA response error!", 1);
					this.int_1++;
					if (array.Length == 0 && this.int_1 > 1)
					{
						GClass3.smethod_2("Terminate 7", 1);
						base.method_22(true);
					}
				}
			}
		}
		GClass3.smethod_2("KA stopped", 1);
	}

	// Token: 0x04000029 RID: 41
	private int int_5 = 1000;

	// Token: 0x0400002A RID: 42
	private byte[] byte_2 = new byte[]
	{
		1,
		62
	};

	// Token: 0x0400002B RID: 43
	protected int int_6 = 0;

	// Token: 0x0400002C RID: 44
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

	// Token: 0x0400002D RID: 45
	private byte[] byte_4 = new byte[]
	{
		4,
		24,
		0,
		byte.MaxValue,
		0
	};

	// Token: 0x0400002E RID: 46
	private byte[] byte_5 = new byte[]
	{
		3,
		20,
		byte.MaxValue,
		0
	};

	// Token: 0x0400002F RID: 47
	private byte[] byte_6;

	// Token: 0x04000030 RID: 48
	private string[] string_7;
}
