using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

// Token: 0x0200002B RID: 43
public abstract class GClass40 : GClass19
{
	// Token: 0x060001DE RID: 478 RVA: 0x00056744 File Offset: 0x00054944
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
			byte[][] array2 = new byte[][]
			{
				new byte[]
				{
					0,
					97,
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
					0
				},
				new byte[]
				{
					0,
					97,
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
					2,
					3,
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
					97,
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
					3,
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
				string string_ = string.Empty;
				if (GClass16.smethod_1(gclass.byte_0[0]) == "02 21 A1")
				{
					string_ = this.vmethod_7(array2[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else if (GClass16.smethod_1(gclass.byte_0[0]) == "02 21 A2")
				{
					string_ = this.vmethod_7(array2[1], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else if (GClass16.smethod_1(gclass.byte_0[0]) == "02 21 23")
				{
					string_ = this.vmethod_7(array2[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else if (i < array.Length)
				{
					string_ = this.vmethod_7(array[i], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else
				{
					string_ = this.vmethod_7(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				gclass.method_1(string_);
				if (gclass.int_2 == 1770)
				{
					this.string_3 = string_;
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

	// Token: 0x060001DF RID: 479
	protected abstract void vmethod_8();

	// Token: 0x060001E0 RID: 480 RVA: 0x00056A7C File Offset: 0x00054C7C
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
				this.vmethod_8();
			}
			if (GClass3.bool_14)
			{
				throw new Exception("ESC");
			}
			if (genum0_0 == (GEnum0)0)
			{
				Thread thread = new Thread(new ThreadStart(this.method_46));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_45))
				{
					Priority = ThreadPriority.Highest
				}.Start();
			}
			SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
			for (int i = 0; i < this.list_1.Count; i++)
			{
				GClass58 gclass = this.list_1[i];
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
				if (gclass.int_2 == 1770)
				{
					this.string_3 = gclass.method_0();
					GClass3.smethod_2("ECU ISO Code: " + gclass.method_0(), 2);
				}
			}
			if (genum0_0 == (GEnum0)3)
			{
				Thread.Sleep(200);
				byte[] byte_ = this.method_41(this.gclass58_0.byte_0[0]);
				this.string_5 = GClass16.smethod_1(byte_);
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
			GClass3.smethod_2(ex.Message, 2);
			GClass3.smethod_2("Terminate 4", 1);
			base.method_22(ex.Message != "0");
		}
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x00056D44 File Offset: 0x00054F44
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
				base.method_29(bool_7);
			}
		}
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x00056E6C File Offset: 0x0005506C
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
			array = this.method_41(this.byte_5);
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

	// Token: 0x060001E3 RID: 483 RVA: 0x00018938 File Offset: 0x00016B38
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

	// Token: 0x060001E4 RID: 484 RVA: 0x000189A0 File Offset: 0x00016BA0
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

	// Token: 0x060001E5 RID: 485 RVA: 0x00018A1C File Offset: 0x00016C1C
	private string method_36(byte byte_7)
	{
		string result = string.Empty;
		if ((byte_7 & 128) != 0)
		{
			result = GClass62.smethod_1("3051");
		}
		return result;
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x00057238 File Offset: 0x00055438
	public override void vmethod_5()
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
			byte[] array = this.method_41(this.byte_6);
			if (array.Length < 3 || array[1] != 84)
			{
				GClass3.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x00057294 File Offset: 0x00055494
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
		else if (gclass58_1.string_2.Contains("RWANDXOR"))
		{
			this.method_39(gclass58_1);
		}
		else if (gclass58_1.string_2.Contains("RWUSERENTRY"))
		{
			this.method_40(gclass58_1);
		}
		else
		{
			this.method_37(gclass58_1);
		}
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x0005736C File Offset: 0x0005556C
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
		bool flag2 = gclass58_1.byte_0.Length > 1 && !gclass58_1.string_2.Contains("NOABORT");
		int i = 0;
		while (i < gclass58_1.byte_0.Length)
		{
			byte[] array = this.method_41(gclass58_1.byte_0[i]);
			if ((flag || array.Length != 0) && (array.Length <= 1 || array[1] != 127))
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
			string text = string.Empty;
			if (array.Length > 3 && array[3] == 34)
			{
				text = GClass62.smethod_1("6053");
			}
			else if (array.Length > 3 && array[3] == 17)
			{
				text = GClass62.smethod_1("6054");
			}
			base.method_31(false, GClass62.smethod_1("6052"), text);
			return;
		}
		base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x00057570 File Offset: 0x00055770
	private void method_38(GClass58 gclass58_1)
	{
		byte[] array = this.method_41(gclass58_1.byte_0[0]);
		if ((array.Length == 0 || (array.Length > 1 && array[1] == 127)) && array.Length > 3 && array[3] == 120)
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
			else if (array.Length > 3 && array[3] > 0)
			{
				text = GClass62.smethod_1("6055") + " " + GClass16.smethod_0(array[3]);
			}
			base.method_31(false, GClass62.smethod_1("6052"), text);
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
			IL_1BC:
			while (num > 0 && flag)
			{
				for (int i = 0; i < 5; i++)
				{
					if (GClass3.bool_14)
					{
						GClass3.smethod_2("Aborting routine...", 1);
						array = this.method_41(array4);
						num = 0;
						IL_16A:
						GClass3.smethod_2("Checking routine status..", 1);
						array = this.method_41(array3);
						if (array.Length <= 3 || array[1] != 127 || array[2] != 51 || (array[3] != 33 && array[3] != 35))
						{
							flag = false;
						}
						num--;
						goto IL_1BC;
					}
					Thread.Sleep(100);
				}
				goto IL_16A;
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
					this.string_5 = GClass16.smethod_0(array[3]);
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
			base.method_31(true, GClass62.smethod_1("6051"), text2);
		}
	}

	// Token: 0x060001EA RID: 490 RVA: 0x00057958 File Offset: 0x00055B58
	private void method_39(GClass58 gclass58_1)
	{
		byte[] array = this.method_41(gclass58_1.byte_0[0]);
		if (array.Length < 4)
		{
			string text = string.Empty;
			base.method_31(false, GClass62.smethod_1("6052"), text);
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
			array = this.method_41(gclass58_1.byte_0[1]);
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
				base.method_31(false, GClass62.smethod_1("6052"), text);
			}
			else
			{
				Thread.Sleep(1000);
				base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
			}
		}
	}

	// Token: 0x060001EB RID: 491 RVA: 0x00057AA0 File Offset: 0x00055CA0
	private void method_40(GClass58 gclass58_1)
	{
		byte[] array = this.method_41(gclass58_1.byte_0[0]);
		if (array.Length < 4)
		{
			string text = string.Empty;
			base.method_31(false, GClass62.smethod_1("6052"), text);
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
				string text = string.Empty;
				if (array.Length > 3 && array[3] == 34)
				{
					text = GClass62.smethod_1("6053");
				}
				else if (array.Length > 3 && array[3] == 17)
				{
					text = GClass62.smethod_1("6054");
				}
				base.method_31(false, GClass62.smethod_1("6052"), text);
			}
			else
			{
				Thread.Sleep(1000);
				base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
			}
		}
	}

	// Token: 0x060001EC RID: 492 RVA: 0x00057C34 File Offset: 0x00055E34
	public override string vmethod_0(byte[] byte_7, string string_33, int int_6, int int_7, string[] string_34, string string_35)
	{
		byte[] array = this.method_41(byte_7);
		return this.vmethod_7(array, string_33, int_6, int_7, string_34, string_35);
	}

	// Token: 0x060001ED RID: 493 RVA: 0x00057C5C File Offset: 0x00055E5C
	protected virtual byte[] vmethod_9(byte[] byte_7)
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
			if (byte_7.Length < 8)
			{
				list2.Add(new byte[byte_7.Length - 1]);
				for (int i = 1; i < byte_7.Length; i++)
				{
					list2[0][i - 1] = byte_7[i];
				}
			}
			else
			{
				list2.Add(new byte[8]);
				list2[0][0] = this.byte_0;
				list2[0][1] = 16;
				int num = 0;
				int i = 2;
				while (i < list2[0].Length && num < byte_7.Length)
				{
					list2[0][i] = byte_7[num];
					num++;
					i++;
				}
				byte b = 32;
				while (num < byte_7.Length && b < 47)
				{
					list2.Add(new byte[(byte_7.Length - num > 6) ? 8 : (byte_7.Length - num + 2)]);
					int index = list2.Count - 1;
					list2[index][0] = this.byte_0;
					list2[index][1] = b;
					b += 1;
					i = 2;
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
				this.method_43("ATCAF0");
				this.method_43("ATCEA");
			}
			if (list2.Count > 1 && this.int_4 != 0 && !GClass3.bool_12)
			{
				if (this.int_4 == 1)
				{
					this.method_43(this.string_21);
				}
				else
				{
					this.method_43(this.string_20);
				}
			}
			this.method_42(GClass16.smethod_1(list2[0]));
			this.int_0 = GClass3.smethod_1();
			if (list2.Count > 1 && !GClass3.bool_12)
			{
				GClass3.smethod_2("Waiting FC...", 0);
				string text = this.method_44();
				if (this.int_4 == 0 && (text.Contains(this.string_10) || text.Contains(this.string_11) || text.Contains(this.string_12) || !text.Contains(this.string_13)))
				{
					return new byte[0];
				}
				if (this.int_4 != 0 && !GClass3.bool_12)
				{
					this.method_43(this.string_18);
				}
				else if (GClass61.smethod_36() == 2)
				{
					this.method_43(this.string_19);
				}
				else
				{
					this.method_43(this.string_18);
				}
				for (int j = 1; j < list2.Count; j++)
				{
					if (j == list2.Count - 1)
					{
						if (this.int_4 == 0)
						{
							this.method_43(this.string_23);
						}
						else
						{
							this.method_43(this.string_24);
						}
					}
					this.method_42(GClass16.smethod_1(list2[j]));
					this.int_0 = GClass3.smethod_1();
					if (j < list2.Count - 1)
					{
						this.method_44();
					}
				}
			}
			string text2 = this.method_44();
			if (this.int_4 != 0 && text2.Contains(this.string_10))
			{
				this.method_42(GClass16.smethod_0(this.byte_0) + this.string_14);
				text2 = this.method_44();
				if (this.int_4 != 0 && text2.Contains(this.string_10))
				{
					this.method_42(GClass16.smethod_0(this.byte_0) + this.string_14);
					text2 = this.method_44();
				}
			}
			if (list2.Count > 1 && !GClass3.bool_12)
			{
				this.method_43(this.string_7);
				this.method_43("ATCAF1");
				this.method_43("ATCEA " + GClass16.smethod_0(this.byte_0));
			}
			if (text2.Contains("NO DATA") || text2.Contains("ERROR") || text2.Contains("?"))
			{
				result = new byte[0];
			}
			else
			{
				int num2;
				while (text2.StartsWith("7F2178") || text2.StartsWith("7F3078"))
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
				string text3 = text2.Substring(0, num2).Trim();
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

	// Token: 0x060001EE RID: 494 RVA: 0x00058390 File Offset: 0x00056590
	protected virtual byte[] vmethod_10(byte[] byte_7)
	{
		byte[] result;
		if (this.bool_5)
		{
			result = this.vmethod_9(byte_7);
		}
		else
		{
			if (this.serialPort_0.BytesToRead > 0)
			{
				this.serialPort_0.ReadExisting();
			}
			List<byte[]> list = new List<byte[]>();
			if (byte_7.Length < 8)
			{
				list.Add(new byte[byte_7.Length + 1]);
				list[0][0] = this.byte_0;
				for (int i = 0; i < byte_7.Length; i++)
				{
					list[0][i + 1] = byte_7[i];
				}
			}
			else
			{
				list.Add(new byte[8]);
				list[0][0] = this.byte_0;
				list[0][1] = 16;
				int num = 0;
				int i = 2;
				while (i < list[0].Length && num < byte_7.Length)
				{
					list[0][i] = byte_7[num];
					num++;
					i++;
				}
				byte b = 32;
				while (num < byte_7.Length && b < 47)
				{
					list.Add(new byte[(byte_7.Length - num > 6) ? 8 : (byte_7.Length - num + 2)]);
					int index = list.Count - 1;
					list[index][0] = this.byte_0;
					list[index][1] = b;
					b += 1;
					i = 2;
					while (i < list[index].Length && num < byte_7.Length)
					{
						list[index][i] = byte_7[num];
						num++;
						i++;
					}
				}
			}
			if (list.Count > 1)
			{
				if (this.int_4 != 0 && !GClass3.bool_12)
				{
					if (this.int_4 == 1)
					{
						this.method_43(this.string_21);
					}
					else
					{
						this.method_43(this.string_20);
					}
				}
				this.method_43("ATAT0");
			}
			bool flag = false;
			if (list[0].Length > 2 && (list[0][2] == 33 || list[0][2] == 26 || list[0][2] == 62))
			{
				this.method_42(GClass16.smethod_1(list[0]) + " 1");
			}
			else if (list.Count > 1)
			{
				this.method_42(GClass16.smethod_1(list[0]) + " 1");
			}
			else
			{
				flag = true;
				this.method_42(GClass16.smethod_1(list[0]));
			}
			this.int_0 = GClass3.smethod_1();
			if (list.Count > 1)
			{
				GClass3.smethod_2(this.string_9, 0);
				string text = this.method_44();
				if (!flag && text.Contains(this.string_12))
				{
					flag = true;
					Thread.Sleep(250);
					this.method_42(GClass16.smethod_1(list[0]));
					text = this.method_44();
				}
				if (this.int_4 == 0 && (text.Contains(this.string_10) || text.Contains(this.string_11) || text.Contains(this.string_12) || !text.Contains(this.string_13)))
				{
					return new byte[0];
				}
				if (this.int_4 != 0 && !GClass3.bool_12)
				{
					this.method_43(this.string_18);
				}
				else if (!GClass61.smethod_38())
				{
					this.method_43(this.string_19);
				}
				else
				{
					this.method_43(this.string_18);
				}
				for (int j = 1; j < list.Count; j++)
				{
					if (j == list.Count - 1)
					{
						if (this.int_4 == 0)
						{
							this.method_43(this.string_23);
						}
						else
						{
							this.method_43(this.string_24);
						}
						this.method_42(GClass16.smethod_1(list[j]));
					}
					else if (flag)
					{
						this.method_42(GClass16.smethod_1(list[j]));
					}
					else
					{
						this.method_42(GClass16.smethod_1(list[j]) + " 0");
					}
					this.int_0 = GClass3.smethod_1();
					if (j < list.Count - 1)
					{
						this.method_44();
					}
				}
			}
			string text2 = this.method_44();
			if (this.int_4 != 0 && text2.Contains(this.string_10))
			{
				this.method_42(GClass16.smethod_0(this.byte_0) + this.string_14);
				text2 = this.method_44();
				if (this.int_4 != 0 && text2.Contains(this.string_10))
				{
					this.method_42(GClass16.smethod_0(this.byte_0) + this.string_14);
					text2 = this.method_44();
				}
			}
			if (list.Count > 1)
			{
				this.method_43(this.string_7);
				this.method_43("ATAT1");
			}
			if (text2.Contains(this.string_10) || text2.Contains(this.string_11) || text2.Contains(this.string_12))
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
						this.method_42(GClass16.smethod_0(this.byte_0) + this.string_15);
						text2 = this.method_44();
						while (text2.StartsWith(this.string_16))
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
					GClass3.smethod_2(this.string_17 + GClass16.smethod_1(list2.ToArray()), 0);
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
		}
		return result;
	}

	// Token: 0x060001EF RID: 495 RVA: 0x00058B44 File Offset: 0x00056D44
	protected byte[] method_41(byte[] byte_7)
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
			byte[] array = this.vmethod_10(byte_7);
			if (array.Length == 0)
			{
				Thread.Sleep(100);
				array = this.vmethod_10(byte_7);
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

	// Token: 0x060001F0 RID: 496 RVA: 0x00058C08 File Offset: 0x00056E08
	public override string vmethod_7(byte[] byte_7, string string_33, int int_6, int int_7, string[] string_34, string string_35)
	{
		string text = string.Empty;
		int_6 += 2;
		string result;
		if (byte_7.Length <= int_6)
		{
			result = text;
		}
		else if (byte_7[1] == 127 && string_33 != "hex3")
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
			text = base.method_32(array, string_33, string_34, string_35);
			result = text;
		}
		return result;
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x00058C94 File Offset: 0x00056E94
	protected void method_42(string string_33)
	{
		string text = string_33.Replace(this.string_25, this.string_26);
		GClass3.smethod_2(this.string_27 + text, 0);
		if (GClass61.smethod_36() == 2 || GClass61.smethod_36() == 4)
		{
			this.serialPort_0.WriteLine(text);
		}
		else
		{
			for (int i = 0; i < text.Length; i++)
			{
				this.serialPort_0.Write(text.Substring(i, 1));
			}
			this.serialPort_0.Write(this.serialPort_0.NewLine);
		}
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x00058D28 File Offset: 0x00056F28
	protected string method_43(string string_33)
	{
		if (this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		this.method_42(string_33);
		string text = this.method_44();
		if (!text.Contains(this.string_28))
		{
			GClass3.smethod_2(this.string_29 + string_33 + this.string_30, 0);
			if (GClass61.smethod_38())
			{
				this.method_42(string_33);
				text = this.method_44();
			}
		}
		this.int_0 = GClass3.smethod_1();
		return text;
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x00058DB0 File Offset: 0x00056FB0
	protected string method_44()
	{
		string text = this.string_26;
		while (!text.EndsWith(this.string_31))
		{
			text += (char)this.serialPort_0.ReadByte();
		}
		GClass3.smethod_2(this.string_32 + text, 0);
		return text;
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x00058E04 File Offset: 0x00057004
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
								gclass.method_1(this.vmethod_7(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							else if (gclass.string_2.StartsWith("bits"))
							{
								gclass.method_1(this.vmethod_7(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							else if (gclass.string_2.StartsWith("bitchars"))
							{
								gclass.method_1(this.vmethod_7(array[6], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							else if (gclass.string_0 == "Coolant Temperature")
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

	// Token: 0x060001F5 RID: 501 RVA: 0x000592B0 File Offset: 0x000574B0
	private void method_46()
	{
		GClass3.smethod_2("KA started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(100);
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
					if (array.Length == 0)
					{
						GClass3.smethod_2("Terminate 7", 1);
						base.method_22(true);
					}
				}
			}
		}
		GClass3.smethod_2("KA stopped", 1);
	}

	// Token: 0x04000198 RID: 408
	protected int int_5 = 1000;

	// Token: 0x04000199 RID: 409
	protected byte[] byte_2 = new byte[]
	{
		1,
		62
	};

	// Token: 0x0400019A RID: 410
	protected byte[] byte_3 = new byte[]
	{
		2,
		16,
		129
	};

	// Token: 0x0400019B RID: 411
	protected byte[] byte_4 = new byte[]
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

	// Token: 0x0400019C RID: 412
	protected byte[] byte_5 = new byte[]
	{
		4,
		24,
		0,
		byte.MaxValue,
		0
	};

	// Token: 0x0400019D RID: 413
	protected byte[] byte_6 = new byte[]
	{
		3,
		20,
		byte.MaxValue,
		0
	};

	// Token: 0x0400019E RID: 414
	protected string string_7 = "ATST28";

	// Token: 0x0400019F RID: 415
	protected string string_8 = "ATST35";

	// Token: 0x040001A0 RID: 416
	protected bool bool_5 = false;

	// Token: 0x040001A1 RID: 417
	protected string string_9 = "Waiting FC...";

	// Token: 0x040001A2 RID: 418
	protected string string_10 = "NO DATA";

	// Token: 0x040001A3 RID: 419
	protected string string_11 = "ERROR";

	// Token: 0x040001A4 RID: 420
	protected string string_12 = "?";

	// Token: 0x040001A5 RID: 421
	protected string string_13 = "F130";

	// Token: 0x040001A6 RID: 422
	protected string string_14 = " 00";

	// Token: 0x040001A7 RID: 423
	protected string string_15 = " 30 FF 00";

	// Token: 0x040001A8 RID: 424
	protected string string_16 = "F1";

	// Token: 0x040001A9 RID: 425
	protected string string_17 = "DECODED RESPONSE: ";

	// Token: 0x040001AA RID: 426
	protected string string_18 = "ATST01";

	// Token: 0x040001AB RID: 427
	protected string string_19 = "ATST03";

	// Token: 0x040001AC RID: 428
	protected string string_20 = "ATST05";

	// Token: 0x040001AD RID: 429
	protected string string_21 = "ATST07";

	// Token: 0x040001AE RID: 430
	protected string string_22 = "ATST09";

	// Token: 0x040001AF RID: 431
	protected string string_23 = "ATST99";

	// Token: 0x040001B0 RID: 432
	protected string string_24 = "ATSTFF";

	// Token: 0x040001B1 RID: 433
	private string string_25 = " ";

	// Token: 0x040001B2 RID: 434
	private string string_26 = string.Empty;

	// Token: 0x040001B3 RID: 435
	private string string_27 = "Send: ";

	// Token: 0x040001B4 RID: 436
	private string string_28 = "OK";

	// Token: 0x040001B5 RID: 437
	private string string_29 = "[";

	// Token: 0x040001B6 RID: 438
	private string string_30 = "] failed!";

	// Token: 0x040001B7 RID: 439
	private string string_31 = ">";

	// Token: 0x040001B8 RID: 440
	private string string_32 = "Response: ";
}
