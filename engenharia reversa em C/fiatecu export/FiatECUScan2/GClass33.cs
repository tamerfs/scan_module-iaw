using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

// Token: 0x0200002A RID: 42
public abstract class GClass33 : GClass19
{
	// Token: 0x060001C5 RID: 453 RVA: 0x00053BF8 File Offset: 0x00051DF8
	protected GClass33()
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
		this.char_0 = new char[]
		{
			'\r',
			'\n',
			' '
		};
		base..ctor();
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x00053CA0 File Offset: 0x00051EA0
	protected void method_33()
	{
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
				string text = string.Empty;
				if (GClass16.smethod_1(gclass.byte_0[0]) == "03 22 40 A1")
				{
					text = this.vmethod_7(array2[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else if (GClass16.smethod_1(gclass.byte_0[0]) == "03 22 40 A2")
				{
					text = this.vmethod_7(array2[1], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else if (GClass16.smethod_1(gclass.byte_0[0]) == "03 22 20 23")
				{
					text = this.vmethod_7(array2[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else if (i < array.Length)
				{
					text = this.vmethod_7(array[i], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else
				{
					text = this.vmethod_7(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				gclass.method_1(text);
				if (gclass.int_2 == 1770)
				{
					this.string_3 = text;
				}
			}
			this.bool_1 = false;
			this.bool_0 = true;
			new Thread(new ThreadStart(this.method_46))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_28();
			throw new Exception("1");
		}
	}

	// Token: 0x060001C7 RID: 455
	protected abstract void vmethod_8();

	// Token: 0x060001C8 RID: 456 RVA: 0x00053FD8 File Offset: 0x000521D8
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
				Thread thread = new Thread(new ThreadStart(this.method_47));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_46))
				{
					Priority = ThreadPriority.Highest
				}.Start();
			}
			this.method_42(new byte[]
			{
				3,
				34,
				32,
				35
			});
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
					byte[] value = this.method_42(gclass.byte_0[0]);
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
				byte[] byte_ = this.method_42(this.gclass58_0.byte_0[0]);
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

	// Token: 0x060001C9 RID: 457 RVA: 0x00054330 File Offset: 0x00052530
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
							this.method_44("ATZ");
						}
						else
						{
							this.method_44("ATPC");
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

	// Token: 0x060001CA RID: 458 RVA: 0x00054458 File Offset: 0x00052658
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
			array = this.method_42(this.byte_5);
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
				gclass.string_4 = this.method_34(byte_);
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

	// Token: 0x060001CB RID: 459 RVA: 0x000546F4 File Offset: 0x000528F4
	private string method_34(byte byte_7)
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

	// Token: 0x060001CC RID: 460 RVA: 0x00054794 File Offset: 0x00052994
	private string method_35(byte byte_7)
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

	// Token: 0x060001CD RID: 461 RVA: 0x00018A1C File Offset: 0x00016C1C
	private string method_36(byte byte_7)
	{
		string result = string.Empty;
		if ((byte_7 & 128) != 0)
		{
			result = GClass62.smethod_1("3051");
		}
		return result;
	}

	// Token: 0x060001CE RID: 462 RVA: 0x000547DC File Offset: 0x000529DC
	public override void vmethod_5()
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
			byte[] array = this.method_42(this.byte_6);
			if (array.Length < 2 || array[1] != 84)
			{
				GClass3.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
	}

	// Token: 0x060001CF RID: 463 RVA: 0x00054838 File Offset: 0x00052A38
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

	// Token: 0x060001D0 RID: 464 RVA: 0x000548F0 File Offset: 0x00052AF0
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
			byte[] array = this.method_42(gclass58_1.byte_0[i]);
			if ((flag || array.Length != 0) && (array.Length <= 1 || array[1] != 127))
			{
				if (i < gclass58_1.byte_0.Length - 1 || gclass58_1.byte_0.Length == 1)
				{
					for (int j = 0; j < num; j++)
					{
						if (GClass3.bool_14 && flag2)
						{
							GClass3.smethod_2(GClass62.smethod_1("6081"), 2);
							array = this.method_42(gclass58_1.byte_0[gclass58_1.byte_0.Length - 1]);
							base.method_31(false, GClass62.smethod_1("6082"), " ");
							return;
						}
						Thread.Sleep(100);
					}
				}
				i++;
				continue;
			}
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
			return;
		}
		base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x00054AF4 File Offset: 0x00052CF4
	private void method_38(GClass58 gclass58_1)
	{
		byte[] array = this.method_42(gclass58_1.byte_0[0]);
		if ((array.Length == 0 || (array.Length > 1 && array[1] == 127)) && array.Length > 3 && array[3] == 120)
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
			else if (array.Length > 3 && array[3] > 0)
			{
				string_ = GClass62.smethod_1("6055") + " " + GClass16.smethod_0(array[3]);
			}
			base.method_31(false, GClass62.smethod_1("6052"), string_);
		}
		else
		{
			byte[] array2 = new byte[]
			{
				4,
				49,
				3,
				0,
				0
			};
			array2[3] = gclass58_1.byte_0[0][3];
			array2[4] = gclass58_1.byte_0[0][4];
			byte[] array3 = new byte[]
			{
				4,
				49,
				2,
				0,
				0
			};
			array3[3] = gclass58_1.byte_0[0][3];
			array3[4] = gclass58_1.byte_0[0][4];
			int num = 1800;
			bool flag = true;
			IL_1CC:
			while (num > 0 && flag)
			{
				for (int i = 0; i < 5; i++)
				{
					if (GClass3.bool_14)
					{
						GClass3.smethod_2("Aborting execution...", 2);
						array = this.method_42(array3);
						num = 0;
						IL_181:
						GClass3.smethod_2("Checking routine status...", 1);
						array = this.method_42(array2);
						if (array.Length <= 3 || array[1] != 127 || (array[3] != 33 && array[3] != 35))
						{
							flag = false;
						}
						num--;
						goto IL_1CC;
					}
					Thread.Sleep(100);
				}
				goto IL_181;
			}
			string string_2 = GClass62.smethod_1("6056");
			if (array.Length > 4 && array[1] == 113)
			{
				if (gclass58_1.string_5.Length > 0)
				{
					byte b = array[4];
					this.string_5 = GClass16.smethod_0(array[4]);
					string_2 = GClass62.smethod_1("6055") + " " + GClass16.smethod_0(array[4]);
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
				else if (array.Length == 5)
				{
					string_2 = GClass62.smethod_1("6055") + " " + GClass16.smethod_0(array[4]);
				}
				else if (array.Length == 6)
				{
					string_2 = string.Concat(new string[]
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
					string_2 = string.Concat(new string[]
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
			base.method_31(true, GClass62.smethod_1("6051"), string_2);
		}
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x00054ED0 File Offset: 0x000530D0
	private void method_39(GClass58 gclass58_1)
	{
		byte[] array = this.method_42(gclass58_1.byte_0[0]);
		if (array.Length < 4)
		{
			string string_ = string.Empty;
			base.method_31(false, GClass62.smethod_1("6052"), string_);
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
			array = this.method_42(gclass58_1.byte_0[1]);
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

	// Token: 0x060001D3 RID: 467 RVA: 0x00055064 File Offset: 0x00053264
	public override string vmethod_0(byte[] byte_7, string string_7, int int_6, int int_7, string[] string_8, string string_9)
	{
		byte[] array = this.method_42(byte_7);
		return this.vmethod_7(array, string_7, int_6, int_7, string_8, string_9);
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x0005508C File Offset: 0x0005328C
	private byte[] method_40(byte[] byte_7)
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
				list2.Add(new byte[byte_7.Length]);
				for (int i = 0; i < byte_7.Length; i++)
				{
					list2[0][i] = byte_7[i];
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
				this.method_44("ATCAF0");
				this.method_44("ATST03");
			}
			this.method_43(GClass16.smethod_1(list2[0]));
			this.int_0 = GClass3.smethod_1();
			if (list2.Count > 1 && !GClass3.bool_12)
			{
				GClass3.smethod_2("Waiting FC...", 0);
				string text = this.method_45();
				if (text.Contains("NO DATA") || text.Contains("ERROR") || text.Contains("?") || !text.StartsWith("30"))
				{
					this.method_44("ATST99");
					return new byte[0];
				}
				for (int j = 1; j < list2.Count; j++)
				{
					if (j == list2.Count - 1)
					{
						this.method_44("ATST99");
					}
					this.method_43(GClass16.smethod_1(list2[j]));
					this.int_0 = GClass3.smethod_1();
					if (j < list2.Count - 1)
					{
						this.method_45();
					}
				}
			}
			string text2 = this.method_45();
			text2 = text2.TrimStart(this.char_0);
			if (list2.Count > 1 && !GClass3.bool_12)
			{
				this.method_44("ATCAF1");
			}
			if (text2.Contains("NO DATA") || text2.Contains("ERROR") || text2.Contains("?"))
			{
				result = new byte[0];
			}
			else
			{
				int num2;
				while (text2.StartsWith("7F2278") || text2.StartsWith("7F1978") || text2.StartsWith("7F1478") || text2.StartsWith("7F2E78") || text2.StartsWith("037F2278") || text2.StartsWith("037F1978") || text2.StartsWith("037F1478") || text2.StartsWith("037F2E78"))
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

	// Token: 0x060001D5 RID: 469 RVA: 0x000556BC File Offset: 0x000538BC
	private byte[] method_41(byte[] byte_7)
	{
		byte[] result;
		if (GClass61.smethod_36() == 4 || GClass61.smethod_36() == 5)
		{
			result = this.method_40(byte_7);
		}
		else
		{
			if (this.serialPort_0.BytesToRead > 0)
			{
				this.serialPort_0.ReadExisting();
			}
			List<byte> list = new List<byte>();
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
					int num = byte_7.Length - 1;
					if (num > 255)
					{
						num -= 256;
						list2[0][0] = 17;
						byte_7[0] = (byte)num;
					}
					int num2 = 0;
					int i = 1;
					while (i < list2[0].Length && num2 < byte_7.Length)
					{
						list2[0][i] = byte_7[num2];
						num2++;
						i++;
					}
					byte b = 33;
					while (num2 < byte_7.Length && b < 47)
					{
						list2.Add(new byte[(byte_7.Length - num2 > 7) ? 8 : (byte_7.Length - num2 + 1)]);
						int index = list2.Count - 1;
						list2[index][0] = b;
						b += 1;
						i = 1;
						while (i < list2[index].Length && num2 < byte_7.Length)
						{
							list2[index][i] = byte_7[num2];
							num2++;
							i++;
						}
					}
				}
				if (list2.Count > 1 && !GClass3.bool_12)
				{
					this.method_44("ATCAF0");
					this.method_44("ATAT0");
					this.method_44("ATST03");
					this.method_43(GClass16.smethod_1(list2[0]) + " 1");
				}
				else
				{
					this.method_43(GClass16.smethod_1(list2[0]));
				}
				this.int_0 = GClass3.smethod_1();
				if (list2.Count > 1 && !GClass3.bool_12)
				{
					GClass3.smethod_2("Waiting FC...", 0);
					string text = this.method_45();
					if (text.Contains("NO DATA") || text.Contains("ERROR") || text.Contains("?") || !text.StartsWith("30"))
					{
						this.method_44("ATST99");
						return new byte[0];
					}
					for (int j = 1; j < list2.Count; j++)
					{
						if (j == list2.Count - 1)
						{
							this.method_44("ATST99");
							this.method_43(GClass16.smethod_1(list2[j]));
						}
						else
						{
							this.method_43(GClass16.smethod_1(list2[j]) + " 0");
						}
						this.int_0 = GClass3.smethod_1();
						if (j < list2.Count - 1)
						{
							this.method_45();
						}
					}
				}
				string text2 = this.method_45();
				text2 = text2.TrimStart(this.char_0);
				if (list2.Count > 1 && !GClass3.bool_12)
				{
					this.method_44("ATCAF1");
					this.method_44("ATAT1");
				}
				if (text2.Contains("NO DATA") || text2.Contains("ERROR") || text2.Contains("?"))
				{
					result = new byte[0];
				}
				else
				{
					int num3;
					while (text2.StartsWith("7F2278") || text2.StartsWith("7F1978") || text2.StartsWith("7F1478") || text2.StartsWith("7F2E78") || text2.StartsWith("037F2278") || text2.StartsWith("037F1978") || text2.StartsWith("037F1478") || text2.StartsWith("037F2E78"))
					{
						num3 = 0;
						while (num3 < text2.Length && text2[num3] != '\r' && text2[num3] != '\n' && text2[num3] != '>')
						{
							num3++;
						}
						text2 = text2.Substring(num3 + 1);
					}
					num3 = 0;
					while (num3 < text2.Length && text2[num3] != '\r' && text2[num3] != '\n' && text2[num3] != '>')
					{
						num3++;
					}
					string text3 = text2.Substring(0, num3).Trim();
					text2 = text2.Substring(num3 + 1);
					if (text3.Length == 3 && (text3[0] == '0' || text3[0] == '1'))
					{
						byte item = 0;
						try
						{
							item = GClass16.smethod_2(text3.Substring(1))[0];
							if (text3[0] != '0')
							{
								item = byte.MaxValue;
							}
						}
						catch (Exception)
						{
						}
						list.Add(item);
						while (text2.Length > 2 && text2[1] == ':')
						{
							num3 = 0;
							while (num3 < text2.Length && text2[num3] != '\r' && text2[num3] != '\n' && text2[num3] != '>')
							{
								num3++;
							}
							if (num3 > 2)
							{
								text3 = text2.Substring(2, num3 - 2);
								byte[] array = GClass16.smethod_2(text3);
								for (int i = 0; i < array.Length; i++)
								{
									list.Add(array[i]);
								}
							}
							text2 = text2.Substring(num3 + 1);
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
		}
		return result;
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x00055DC0 File Offset: 0x00053FC0
	protected byte[] method_42(byte[] byte_7)
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
			byte[] array = this.method_41(byte_7);
			if (array.Length == 0 || (array.Length > 3 && array[1] == 127 && array[3] == 33))
			{
				array = this.method_41(byte_7);
			}
			if (array.Length == 0 || (array.Length > 3 && array[1] == 127 && array[3] == 33))
			{
				Thread.Sleep(100);
				array = this.method_41(byte_7);
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

	// Token: 0x060001D7 RID: 471 RVA: 0x00055EC8 File Offset: 0x000540C8
	public override string vmethod_7(byte[] byte_7, string string_7, int int_6, int int_7, string[] string_8, string string_9)
	{
		string text = string.Empty;
		int_6 += 3;
		string result;
		if (byte_7.Length <= int_6)
		{
			result = text;
		}
		else if (byte_7[1] == 127 && string_7 != "hex3")
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
			text = base.method_32(array, string_7, string_8, string_9);
			result = text;
		}
		return result;
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x00055F54 File Offset: 0x00054154
	protected void method_43(string string_7)
	{
		GClass3.smethod_2("Send: " + string_7, 0);
		for (int i = 0; i < string_7.Length; i++)
		{
			this.serialPort_0.Write(string_7.Substring(i, 1));
		}
		this.serialPort_0.Write(this.serialPort_0.NewLine);
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x00055FB0 File Offset: 0x000541B0
	protected string method_44(string string_7)
	{
		this.method_43(string_7);
		string text = this.method_45();
		if (!text.Contains("OK"))
		{
			GClass3.smethod_2("[" + string_7 + "] failed!", 0);
			if (GClass61.smethod_38())
			{
				this.method_43(string_7);
				text = this.method_45();
			}
		}
		this.int_0 = GClass3.smethod_1();
		return text;
	}

	// Token: 0x060001DA RID: 474 RVA: 0x00019A98 File Offset: 0x00017C98
	protected string method_45()
	{
		string text = string.Empty;
		while (!text.EndsWith(">"))
		{
			text += (char)this.serialPort_0.ReadByte();
		}
		GClass3.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x060001DB RID: 475 RVA: 0x00056014 File Offset: 0x00054214
	private void method_46()
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
								byte[] value = this.method_42(gclass.byte_0[0]);
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

	// Token: 0x060001DC RID: 476 RVA: 0x000564C0 File Offset: 0x000546C0
	private void method_47()
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
				byte[] array = this.method_42(this.byte_2);
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

	// Token: 0x04000191 RID: 401
	protected int int_5 = 2000;

	// Token: 0x04000192 RID: 402
	protected byte[] byte_2;

	// Token: 0x04000193 RID: 403
	protected byte[] byte_3;

	// Token: 0x04000194 RID: 404
	protected byte[] byte_4;

	// Token: 0x04000195 RID: 405
	protected byte[] byte_5;

	// Token: 0x04000196 RID: 406
	protected byte[] byte_6;

	// Token: 0x04000197 RID: 407
	private char[] char_0;
}
