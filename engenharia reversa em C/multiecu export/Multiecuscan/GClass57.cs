using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

// Token: 0x0200001B RID: 27
public abstract class GClass57 : GClass11
{
	// Token: 0x06000198 RID: 408 RVA: 0x00029F2C File Offset: 0x0002812C
	protected void method_45()
	{
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
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0
				}
			};
			for (int i = 0; i < 20; i++)
			{
				if (GClass126.bool_25)
				{
					throw new Exception("ESC");
				}
				Thread.Sleep(100);
			}
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
					this.string_7 = text;
				}
			}
			this.bool_1 = false;
			this.bool_0 = true;
			new Thread(new ThreadStart(this.method_55))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_36();
			throw new Exception("1");
		}
	}

	// Token: 0x06000199 RID: 409
	protected abstract void r6();

	// Token: 0x0600019A RID: 410 RVA: 0x0002A23C File Offset: 0x0002843C
	public override void vmethod_1()
	{
		try
		{
			GClass126.smethod_2("-----------------------", 0);
			GClass126.smethod_2("Control module (CANPNKWP): " + this.string_2.Substring(0, 3), 0);
			if (this.genum0_0 == (GEnum0)0)
			{
				for (int i = 0; i < 5; i++)
				{
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(100);
				}
			}
			if (GClass126.bool_0)
			{
				this.method_45();
			}
			else
			{
				this.r6();
			}
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			if (this.genum0_0 == (GEnum0)0)
			{
				Thread thread = new Thread(new ThreadStart(this.method_56));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_55))
				{
					Priority = ThreadPriority.Highest
				}.Start();
			}
			SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
			for (int j = 0; j < this.list_1.Count; j++)
			{
				GClass104 gclass = this.list_1[j];
				if (sortedList.ContainsKey(GClass127.smethod_11(gclass.byte_0[0])))
				{
					byte[] array = sortedList[GClass127.smethod_11(gclass.byte_0[0])];
					gclass.method_1(this.r4(array, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
				else
				{
					byte[] value = this.method_54(gclass.byte_0[0]);
					gclass.method_1(this.r4(value, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					sortedList.Add(GClass127.smethod_11(gclass.byte_0[0]), value);
				}
				if (gclass.int_2 == 10455 && gclass.method_0() != "")
				{
					this.string_7 = gclass.method_0();
					GClass126.smethod_2("ECU ISO Code: " + gclass.method_0(), 0);
				}
			}
			if (this.genum0_0 == (GEnum0)3)
			{
				Thread.Sleep(200);
				byte[] byte_ = this.method_54(this.gclass104_0.byte_0[0]);
				this.string_10 = GClass127.smethod_11(byte_);
			}
			if (this.genum0_0 == (GEnum0)2)
			{
				Thread.Sleep(200);
				this.list_4 = this.r1();
			}
			if (this.genum0_0 == (GEnum0)4)
			{
				Thread.Sleep(100);
				this.r2();
				Thread.Sleep(100);
				this.list_4 = this.r1();
			}
			if (this.genum0_0 != (GEnum0)0)
			{
				base.method_30(false);
			}
			else if (GClass126.bool_13 && GClass125.smethod_5().ToUpper().StartsWith("72345-67890-A"))
			{
				this.string_8 = "Data file corrupted!";
				base.method_30(false);
			}
			else
			{
				if (GClass123.bool_13 && GClass126.bool_13)
				{
					bool flag = true;
					if (GClass125.smethod_5().StartsWith(GClass122.smethod_2()))
					{
						GClass126.bool_13 = false;
					}
					else
					{
						flag = false;
					}
					if (flag)
					{
						GClass126.smethod_2(">Start 35", 0);
					}
				}
				this.bool_0 = true;
				base.method_36();
			}
		}
		catch (Exception ex)
		{
			if (ex.Message == "ESC")
			{
				this.string_8 = GClass121.smethod_6("6060");
			}
			if (ex.Message != "0" && ex.Message != "1")
			{
				GClass126.smethod_2(ex.Message, 2);
			}
			GClass126.smethod_2("Terminate 4", 1);
			this.r0(ex.Message != "0", ex.Message == "ESC");
		}
	}

	// Token: 0x0600019B RID: 411 RVA: 0x0002A5E8 File Offset: 0x000287E8
	public override List<GClass102> r1()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_5;
		}
		else
		{
			array = this.method_54(this.byte_6);
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
			gclass.string_5 = this.method_46(gclass.byte_0);
			gclass.string_6 = this.method_47(gclass.byte_0);
			gclass.string_7 = this.method_48(gclass.byte_0);
			gclass.bool_0 = ((gclass.byte_0 & 1) == 1);
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

	// Token: 0x0600019C RID: 412 RVA: 0x00009148 File Offset: 0x00007348
	private string method_46(byte byte_9)
	{
		string result = "";
		if ((byte_9 & 8) != 0)
		{
			result = GClass121.smethod_6("3056");
		}
		else if ((byte_9 & 4) != 0)
		{
			result = GClass121.smethod_6("3057");
		}
		else if ((byte_9 & 2) != 0)
		{
			result = GClass121.smethod_6("3058");
		}
		else if ((byte_9 & 1) != 0)
		{
			result = GClass121.smethod_6("3059");
		}
		return result;
	}

	// Token: 0x0600019D RID: 413 RVA: 0x000091A4 File Offset: 0x000073A4
	private string method_47(byte byte_9)
	{
		string result = "";
		if ((byte_9 & 96) == 0)
		{
			result = GClass121.smethod_6("3052");
		}
		else if ((byte_9 & 96) == 32)
		{
			result = GClass121.smethod_6("3053");
		}
		else if ((byte_9 & 96) == 64)
		{
			result = GClass121.smethod_6("3054");
		}
		else if ((byte_9 & 96) == 96)
		{
			result = GClass121.smethod_6("3055");
		}
		return result;
	}

	// Token: 0x0600019E RID: 414 RVA: 0x00006FC4 File Offset: 0x000051C4
	private string method_48(byte byte_9)
	{
		string result = "";
		if ((byte_9 & 128) != 0)
		{
			result = GClass121.smethod_6("3051");
		}
		return result;
	}

	// Token: 0x0600019F RID: 415 RVA: 0x0002A960 File Offset: 0x00028B60
	public override void r2()
	{
		if (GClass126.bool_0)
		{
			this.byte_5 = new byte[]
			{
				2,
				88,
				0,
				90
			};
			return;
		}
		byte[] array = this.method_54(this.byte_7);
		if (array.Length < 3 || array[1] != 84)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x0002A9B4 File Offset: 0x00028BB4
	public override void r7(List<GClass102> list_6, List<GClass104> list_7)
	{
		if (list_6 != null && list_7 != null && list_6.Count != 0 && list_7.Count != 0)
		{
			int num = this.string_22.Length;
			SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
			foreach (GClass102 gclass in list_6)
			{
				if (!(gclass.string_4 != ""))
				{
					if (num > 0)
					{
						num--;
					}
					sortedList.Clear();
					try
					{
						foreach (GClass104 gclass2 in list_7)
						{
							if (gclass2.string_1.Contains("*") || gclass2.string_1.Contains("[" + gclass.string_0 + "]"))
							{
								string text = GClass127.smethod_11(gclass2.byte_0[0]);
								text = text.Replace("00 00", gclass.string_0);
								byte[] byte_ = GClass127.smethod_32(text);
								byte[] value = new byte[0];
								if (GClass126.bool_0)
								{
									value = GClass127.smethod_32(this.string_22[num]);
								}
								else if (sortedList.ContainsKey(text))
								{
									value = sortedList[text];
								}
								else
								{
									value = this.method_54(byte_);
									sortedList.Add(text, value);
								}
								gclass2.method_1(this.r4(value, gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
								GClass102 gclass3 = gclass;
								gclass3.string_4 = string.Concat(new string[]
								{
									gclass3.string_4,
									gclass2.string_0,
									": ",
									gclass2.method_0(),
									" ",
									gclass2.string_3,
									Environment.NewLine
								});
							}
						}
						if (gclass.string_4 != "")
						{
							gclass.string_4 = GClass121.smethod_6("3047") + Environment.NewLine + gclass.string_4;
						}
					}
					catch (Exception)
					{
						GClass126.smethod_2("ERROR: Error reading DTC details", 0);
					}
				}
			}
			return;
		}
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x0002AC40 File Offset: 0x00028E40
	protected override void r3(GClass104 gclass104_1)
	{
		if (GClass126.bool_0)
		{
			if (!gclass104_1.string_2.Contains("NOWAIT"))
			{
				Thread.Sleep(3000);
			}
			if (gclass104_1.string_2.Contains("FUNC"))
			{
				base.method_28(true, GClass121.smethod_6("6051"), GClass121.smethod_6("6055") + " 00");
				return;
			}
			base.method_28(false, GClass121.smethod_6("6051"), "");
			return;
		}
		else
		{
			if (gclass104_1.string_2.Contains("FUNCEX"))
			{
				this.method_51(gclass104_1);
				return;
			}
			if (gclass104_1.string_2.Contains("FUNC"))
			{
				this.method_50(gclass104_1);
				return;
			}
			if (gclass104_1.string_2.Contains("RWUSERENTRY"))
			{
				this.method_52(gclass104_1);
				return;
			}
			this.method_49(gclass104_1);
			return;
		}
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x0002AD14 File Offset: 0x00028F14
	private void method_49(GClass104 gclass104_1)
	{
		int num = 20;
		if (gclass104_1.string_2.Contains("0.5SEC"))
		{
			num = 5;
		}
		else if (gclass104_1.string_2.Contains("1SEC"))
		{
			num = 10;
		}
		else if (gclass104_1.string_2.Contains("20SEC"))
		{
			num = 200;
		}
		else if (gclass104_1.string_2.Contains("50SEC"))
		{
			num = 500;
		}
		else if (gclass104_1.string_2.Contains("NOWAIT"))
		{
			num = 0;
		}
		else if (gclass104_1.byte_0.Length == 2)
		{
			num = 3 * num;
		}
		else if (gclass104_1.byte_0.Length == 1)
		{
			num = 4 * num;
		}
		bool flag = gclass104_1.string_2.Contains("EXECANY");
		bool flag2 = gclass104_1.byte_0.Length > 1 && !gclass104_1.string_2.Contains("NOABORT");
		for (int i = 0; i < gclass104_1.byte_0.Length; i++)
		{
			byte[] array = this.method_54(gclass104_1.byte_0[i]);
			if (!flag)
			{
				if (array.Length != 0)
				{
					if (array.Length <= 1 || array[1] != 127)
					{
						goto IL_FD;
					}
				}
				string string_ = "";
				if (array.Length > 3 && array[3] == 34)
				{
					string_ = GClass121.smethod_6("6053");
				}
				else if (array.Length > 3 && array[3] == 17)
				{
					string_ = GClass121.smethod_6("6054");
				}
				base.method_28(false, GClass121.smethod_6("6052"), string_);
				return;
			}
			IL_FD:
			if (i < gclass104_1.byte_0.Length - 1 || gclass104_1.byte_0.Length == 1)
			{
				for (int j = 0; j < num; j++)
				{
					if (GClass126.bool_25 && flag2)
					{
						GClass126.smethod_2(GClass121.smethod_6("6081"), 2);
						array = this.method_54(gclass104_1.byte_0[gclass104_1.byte_0.Length - 1]);
						base.method_28(false, GClass121.smethod_6("6082"), " ");
						return;
					}
					Thread.Sleep(100);
				}
			}
		}
		base.method_28(false, GClass121.smethod_6("6051"), "");
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x0002AF14 File Offset: 0x00029114
	private void method_50(GClass104 gclass104_1)
	{
		byte[] array = this.method_54(gclass104_1.byte_0[0]);
		if (array.Length > 3 && array[1] == 127 && array[3] != 120)
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
			else if (array.Length > 3 && array[3] == 18)
			{
				string_ = GClass121.smethod_6("6504");
			}
			else if (array.Length > 3 && array[3] == 49)
			{
				string_ = GClass121.smethod_6("6507");
			}
			else if (array.Length > 3 && array[3] == 33)
			{
				string_ = GClass121.smethod_6("6505");
			}
			else if (array.Length > 3 && array[3] > 0)
			{
				string_ = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
			}
			base.method_28(false, GClass121.smethod_6("6052"), string_);
			return;
		}
		byte[] array2 = new byte[3];
		array2[0] = 2;
		array2[1] = 51;
		byte[] array3 = array2;
		array3[2] = gclass104_1.byte_0[0][2];
		byte[] array4 = new byte[3];
		array4[0] = 2;
		array4[1] = 50;
		byte[] array5 = array4;
		array5[2] = gclass104_1.byte_0[0][2];
		int num = 1800;
		bool flag = true;
		IL_1B1:
		while (num > 0 && flag)
		{
			for (int i = 0; i < 5; i++)
			{
				if (GClass126.bool_25)
				{
					GClass126.smethod_2("Aborting execution...", 2);
					array = this.method_54(array5);
					num = 0;
					IL_175:
					GClass126.smethod_2("Checking routine status...", 1);
					array = this.method_54(array3);
					if (array.Length <= 3 || array[1] != 127 || array[2] != 51 || (array[3] != 33 && array[3] != 35))
					{
						flag = false;
					}
					num--;
					goto IL_1B1;
				}
				Thread.Sleep(100);
			}
			goto IL_175;
		}
		string string_2 = GClass121.smethod_6("6056");
		if (array.Length > 3 && array[1] == 115)
		{
			if (gclass104_1.string_5.Length != 0 && gclass104_1.string_2.Contains("FUNCW") && array.Length > 4)
			{
				byte b = array[3];
				byte b2 = array[4];
				this.string_10 = GClass127.smethod_23(b);
				string_2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b) + GClass127.smethod_23(b2);
				int j = 0;
				while (j < gclass104_1.string_5.Length)
				{
					byte b3 = byte.Parse(gclass104_1.string_5[j].Substring(0, 2), NumberStyles.HexNumber);
					byte b4 = byte.Parse(gclass104_1.string_5[j].Substring(2, 2), NumberStyles.HexNumber);
					byte b5 = byte.Parse(gclass104_1.string_5[j].Substring(4, 2), NumberStyles.HexNumber);
					byte b6 = byte.Parse(gclass104_1.string_5[j].Substring(6, 2), NumberStyles.HexNumber);
					if ((b & b3) != b5 || (b2 & b4) != b6)
					{
						if (j != gclass104_1.string_5.Length - 1)
						{
							j++;
							continue;
						}
					}
					string_2 = gclass104_1.string_5[j].Substring(8);
					break;
				}
			}
			else if (gclass104_1.string_5.Length != 0 && !gclass104_1.string_2.Contains("FUNCW"))
			{
				byte b7 = array[3];
				if (gclass104_1.int_0 == 2 && array.Length > 4)
				{
					b7 = array[4];
				}
				this.string_10 = GClass127.smethod_23(b7);
				string_2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b7);
				int k = 0;
				while (k < gclass104_1.string_5.Length)
				{
					byte b8 = byte.Parse(gclass104_1.string_5[k].Substring(0, 2), NumberStyles.HexNumber);
					byte b9 = byte.Parse(gclass104_1.string_5[k].Substring(2, 2), NumberStyles.HexNumber);
					if ((b7 & b8) != b9)
					{
						if (k != gclass104_1.string_5.Length - 1)
						{
							k++;
							continue;
						}
					}
					string_2 = gclass104_1.string_5[k].Substring(4);
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
		base.method_28(true, GClass121.smethod_6("6051"), string_2);
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x0002B400 File Offset: 0x00029600
	private void method_51(GClass104 gclass104_1)
	{
		byte[] array = this.method_54(gclass104_1.byte_0[0]);
		if (array.Length > 3 && array[1] == 127 && array[3] != 120)
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
			else if (array.Length > 3 && array[3] == 18)
			{
				string_ = GClass121.smethod_6("6504");
			}
			else if (array.Length > 3 && array[3] == 49)
			{
				string_ = GClass121.smethod_6("6507");
			}
			else if (array.Length > 3 && array[3] == 33)
			{
				string_ = GClass121.smethod_6("6505");
			}
			else if (array.Length > 3 && array[3] > 0)
			{
				string_ = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
			}
			base.method_28(false, GClass121.smethod_6("6052"), string_);
			return;
		}
		string string_2 = "00 00 00 00 00 00 00 00 00 00 00 00 00";
		if (gclass104_1.byte_0.Length > 3)
		{
			string_2 = GClass127.smethod_11(gclass104_1.byte_0[3]);
		}
		byte[] array2 = GClass127.smethod_32(string_2);
		string b = "";
		if (gclass104_1.byte_0.Length > 4)
		{
			b = GClass127.smethod_11(gclass104_1.byte_0[4]);
		}
		string b2 = "";
		if (gclass104_1.byte_0.Length > 5)
		{
			b2 = GClass127.smethod_11(gclass104_1.byte_0[5]);
		}
		string text = "";
		if (gclass104_1.byte_0.Length > 6)
		{
			text = GClass127.smethod_11(gclass104_1.byte_0[6]);
		}
		bool flag = gclass104_1.string_2.Contains("FSTATUS");
		int num = 1800;
		bool flag2 = true;
		IL_4C1:
		while (num > 0 && flag2)
		{
			for (int i = 0; i < 5; i++)
			{
				if (GClass126.bool_25)
				{
					GClass126.smethod_2("Aborting routine...", 1);
					array = this.method_54(gclass104_1.byte_0[2]);
					num = 0;
					IL_1E0:
					GClass126.smethod_2("Checking routine status..", 1);
					array = this.method_54(gclass104_1.byte_0[1]);
					byte[] array3 = new byte[array.Length];
					for (int j = 0; j < array3.Length; j++)
					{
						byte b3 = array[j];
						if (array2.Length > j)
						{
							b3 &= array2[j];
						}
						array3[j] = b3;
					}
					string a = GClass127.smethod_11(array3);
					if (!(a == b) && !(a == b2) && (!(a != text) || !(text != "")))
					{
						flag2 = false;
					}
					if (flag)
					{
						string text2 = "";
						if (array.Length > 3)
						{
							if (gclass104_1.string_5.Length != 0 && gclass104_1.string_2.Contains("FUNCEXW") && array.Length > 4)
							{
								byte b4 = array[3];
								byte b5 = array[4];
								this.string_10 = GClass127.smethod_23(b4);
								text2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b4) + GClass127.smethod_23(b5);
								int k = 0;
								while (k < gclass104_1.string_5.Length)
								{
									byte b6 = byte.Parse(gclass104_1.string_5[k].Substring(0, 2), NumberStyles.HexNumber);
									byte b7 = byte.Parse(gclass104_1.string_5[k].Substring(2, 2), NumberStyles.HexNumber);
									byte b8 = byte.Parse(gclass104_1.string_5[k].Substring(4, 2), NumberStyles.HexNumber);
									byte b9 = byte.Parse(gclass104_1.string_5[k].Substring(6, 2), NumberStyles.HexNumber);
									if ((b4 & b6) != b8 || (b5 & b7) != b9)
									{
										if (k != gclass104_1.string_5.Length - 1)
										{
											k++;
											continue;
										}
									}
									text2 = gclass104_1.string_5[k].Substring(8);
									break;
								}
							}
							else if (gclass104_1.string_5.Length != 0 && !gclass104_1.string_2.Contains("FUNCEXW"))
							{
								byte b10 = array[3];
								if (gclass104_1.int_0 == 2 && array.Length > 4)
								{
									b10 = array[4];
								}
								this.string_10 = GClass127.smethod_23(b10);
								text2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b10);
								int l = 0;
								while (l < gclass104_1.string_5.Length)
								{
									byte b11 = byte.Parse(gclass104_1.string_5[l].Substring(0, 2), NumberStyles.HexNumber);
									byte b12 = byte.Parse(gclass104_1.string_5[l].Substring(2, 2), NumberStyles.HexNumber);
									if ((b10 & b11) != b12)
									{
										if (l != gclass104_1.string_5.Length - 1)
										{
											l++;
											continue;
										}
									}
									text2 = gclass104_1.string_5[l].Substring(4);
									break;
								}
							}
						}
						if (text2.Length > 0)
						{
							base.method_26(text2);
						}
					}
					num--;
					goto IL_4C1;
				}
				Thread.Sleep(100);
			}
			goto IL_1E0;
		}
		string string_3 = GClass121.smethod_6("6056");
		if (array.Length > 3)
		{
			if (gclass104_1.string_5.Length != 0 && gclass104_1.string_2.Contains("FUNCEXW") && array.Length > 4)
			{
				byte b13 = array[3];
				byte b14 = array[4];
				this.string_10 = GClass127.smethod_23(b13);
				string_3 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b13) + GClass127.smethod_23(b14);
				int m = 0;
				while (m < gclass104_1.string_5.Length)
				{
					byte b15 = byte.Parse(gclass104_1.string_5[m].Substring(0, 2), NumberStyles.HexNumber);
					byte b16 = byte.Parse(gclass104_1.string_5[m].Substring(2, 2), NumberStyles.HexNumber);
					byte b17 = byte.Parse(gclass104_1.string_5[m].Substring(4, 2), NumberStyles.HexNumber);
					byte b18 = byte.Parse(gclass104_1.string_5[m].Substring(6, 2), NumberStyles.HexNumber);
					if ((b13 & b15) != b17 || (b14 & b16) != b18)
					{
						if (m != gclass104_1.string_5.Length - 1)
						{
							m++;
							continue;
						}
					}
					string_3 = gclass104_1.string_5[m].Substring(8);
					break;
				}
			}
			else if (gclass104_1.string_5.Length != 0 && !gclass104_1.string_2.Contains("FUNCEXW"))
			{
				byte b19 = array[3];
				if (gclass104_1.int_0 == 2 && array.Length > 4)
				{
					b19 = array[4];
				}
				this.string_10 = GClass127.smethod_23(b19);
				string_3 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b19);
				int n = 0;
				while (n < gclass104_1.string_5.Length)
				{
					byte b20 = byte.Parse(gclass104_1.string_5[n].Substring(0, 2), NumberStyles.HexNumber);
					byte b21 = byte.Parse(gclass104_1.string_5[n].Substring(2, 2), NumberStyles.HexNumber);
					if ((b19 & b20) != b21)
					{
						if (n != gclass104_1.string_5.Length - 1)
						{
							n++;
							continue;
						}
					}
					string_3 = gclass104_1.string_5[n].Substring(4);
					break;
				}
			}
			else if (array.Length == 4)
			{
				string_3 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
			}
			else if (array.Length == 5)
			{
				string_3 = string.Concat(new string[]
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
				string_3 = string.Concat(new string[]
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
		base.method_28(true, GClass121.smethod_6("6051"), string_3);
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x0002BBF8 File Offset: 0x00029DF8
	private void method_52(GClass104 gclass104_1)
	{
		byte[] array = this.method_54(gclass104_1.byte_0[0]);
		if (array.Length < 4)
		{
			string string_ = "";
			base.method_28(false, GClass121.smethod_6("6052"), string_);
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
		array = this.method_54(gclass104_1.byte_0[1]);
		if (array.Length != 0)
		{
			if (array.Length <= 1 || array[1] != 127)
			{
				Thread.Sleep(1000);
				base.method_28(false, GClass121.smethod_6("6051"), "");
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
		base.method_28(false, GClass121.smethod_6("6052"), string_2);
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x0002BD58 File Offset: 0x00029F58
	public override string vmethod_0(byte[] byte_9, string string_23, int int_6, int int_7, string[] string_24, string string_25)
	{
		byte[] byte_10 = this.method_54(byte_9);
		if (string_23 == "raw")
		{
			return GClass127.smethod_11(byte_10);
		}
		return this.r4(byte_10, string_23, int_6, int_7, string_24, string_25);
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x0002BD90 File Offset: 0x00029F90
	private byte[] method_53(byte[] byte_9)
	{
		if (this.serialPort_0 != null && this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		List<byte> list = new List<byte>();
		if (byte_9.Length < 2)
		{
			return new byte[0];
		}
		List<byte[]> list2 = new List<byte[]>();
		if (byte_9.Length < 9)
		{
			list2.Add(new byte[byte_9.Length - 1]);
			for (int i = 0; i < byte_9.Length - 1; i++)
			{
				list2[0][i] = byte_9[i + 1];
			}
		}
		else
		{
			list2.Add(new byte[8]);
			list2[0][0] = 16;
			int num = byte_9.Length - 1;
			if (num > 255)
			{
				num -= 256;
				list2[0][0] = 17;
				byte_9[0] = (byte)num;
			}
			int j = 0;
			int num2 = 1;
			while (num2 < list2[0].Length && j < byte_9.Length)
			{
				list2[0][num2] = byte_9[j];
				j++;
				num2++;
			}
			byte b = 33;
			while (j < byte_9.Length)
			{
				list2.Add(new byte[(byte_9.Length - j > 7) ? 8 : (byte_9.Length - j + 1)]);
				int index = list2.Count - 1;
				list2[index][0] = b;
				b += 1;
				if (b > 47)
				{
					b = 32;
				}
				int num3 = 1;
				while (num3 < list2[index].Length && j < byte_9.Length)
				{
					list2[index][num3] = byte_9[j];
					j++;
					num3++;
				}
			}
		}
		if (list2.Count > 1)
		{
			if (GClass125.smethod_49())
			{
				this.ra("ATGR06");
			}
			else
			{
				this.ra("ATCAF0");
				this.ra("ATAT0");
				this.ra("ATST03");
			}
			this.r9(GClass127.smethod_11(list2[0]));
		}
		else if (list2.Count == 1 && GClass125.smethod_49() && list2[0].Length == 2 && list2[0][0] == 255)
		{
			this.r9("ATGR" + GClass127.smethod_23(list2[0][1]));
		}
		else if (list2.Count == 1 && GClass125.smethod_49() && list2[0].Length == 2 && list2[0][0] == 62 && list2[0][1] == 0)
		{
			this.r9("ATGR07");
		}
		else
		{
			this.r9(GClass127.smethod_11(list2[0]));
		}
		this.int_0 = GClass126.smethod_1();
		if (list2.Count > 1)
		{
			GClass126.smethod_2("Waiting FC...", 0);
			string text = this.rb();
			if (text.Contains("NO DATA") || text.Contains("ERROR") || text.Contains("?") || !text.StartsWith("30"))
			{
				this.ra("ATST26");
				if (GClass125.smethod_49())
				{
					this.ra("ATGR05");
				}
				else
				{
					this.ra("ATCAF1");
					this.ra("ATAT0");
				}
				return new byte[0];
			}
			for (int k = 1; k < list2.Count; k++)
			{
				if (k == list2.Count - 1)
				{
					this.ra("ATST26");
					this.r9(GClass127.smethod_11(list2[k]));
				}
				else
				{
					this.r9(GClass127.smethod_11(list2[k]));
				}
				this.int_0 = GClass126.smethod_1();
				if (k < list2.Count - 1)
				{
					this.rb();
				}
			}
		}
		string text2 = this.rb();
		text2 = text2.TrimStart(this.char_1);
		if (list2.Count > 1)
		{
			if (GClass125.smethod_49())
			{
				this.ra("ATGR05");
			}
			else
			{
				this.ra("ATCAF1");
				this.ra("ATAT0");
			}
		}
		if (!text2.Contains("NO DATA") && !text2.Contains("ERROR") && !text2.Contains("?"))
		{
			int num4;
			while (text2.StartsWith("7F2178") || text2.StartsWith("7F1A78") || text2.StartsWith("7F1878") || text2.StartsWith("7F1478") || text2.StartsWith("7F1078") || text2.StartsWith("037F2178") || text2.StartsWith("037F1A78") || text2.StartsWith("037F1878") || text2.StartsWith("037F1478") || text2.StartsWith("037F1078"))
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
			string text3 = text2.Substring(0, num4).Trim();
			text2 = text2.Substring(num4 + 1);
			if (text3.Length == 3 && (text3[0] == '0' || text3[0] == '1'))
			{
				byte item = 0;
				try
				{
					item = GClass127.smethod_32(text3.Substring(1))[0];
					if (text3[0] != '0')
					{
						item = byte.MaxValue;
					}
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
						for (int l = 0; l < array.Length; l++)
						{
							list.Add(array[l]);
						}
					}
					text2 = text2.Substring(num4 + 1);
				}
			}
			else
			{
				byte[] array2 = GClass127.smethod_32(text3);
				list.Add((byte)array2.Length);
				for (int m = 0; m < array2.Length; m++)
				{
					list.Add(array2[m]);
				}
			}
			GClass126.smethod_2("DECODED RESPONSE: " + GClass127.smethod_11(list.ToArray()), 0);
			byte[] array3 = list.ToArray();
			if (list.Count > 0 && list[0] > 0 && list[0] < 255 && (int)list[0] < list.Count - 1)
			{
				array3 = new byte[(int)(list[0] + 1)];
				for (int n = 0; n <= (int)list[0]; n++)
				{
					array3[n] = list[n];
				}
				GClass126.smethod_2("CLEANED RESPONSE: " + GClass127.smethod_11(array3), 0);
			}
			return array3;
		}
		return new byte[0];
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x0002C4C0 File Offset: 0x0002A6C0
	protected byte[] method_54(byte[] byte_9)
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
			byte[] array = this.method_53(byte_9);
			if ((array.Length == 0 && byte_9[1] != 16) || (array.Length > 3 && array[1] == 127 && array[3] == 33))
			{
				array = this.method_53(byte_9);
			}
			if ((array.Length == 0 && byte_9[1] != 16) || (array.Length > 3 && array[1] == 127 && array[3] == 33))
			{
				Thread.Sleep(100);
				array = this.method_53(byte_9);
			}
			this.int_0 = GClass126.smethod_1();
			this.int_1 = 0;
			this.bool_2 = false;
			result = array;
		}
		catch (Exception ex)
		{
			if (!this.bool_1)
			{
				GClass126.smethod_2(ex.Message + "(3)", 1);
				this.int_1++;
				this.bool_2 = false;
				if (this.int_1 > 3)
				{
					GClass126.smethod_2("Terminate 5", 1);
					base.method_30(true);
				}
			}
			this.bool_2 = false;
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x00019EBC File Offset: 0x000180BC
	public override string r4(byte[] byte_9, string string_23, int int_6, int int_7, string[] string_24, string string_25)
	{
		string result = "";
		int_6 += 2;
		if (byte_9.Length <= int_6)
		{
			return result;
		}
		if (byte_9[1] == 127 && string_23 != "hex3")
		{
			return result;
		}
		int num = byte_9.Length - int_6;
		if (int_7 < num)
		{
			num = int_7;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_9[i + int_6];
		}
		return base.method_33(array, string_23, string_24, string_25);
	}

	// Token: 0x060001AA RID: 426 RVA: 0x0002C5DC File Offset: 0x0002A7DC
	private void method_55()
	{
		GClass126.smethod_2("PM started", 1);
		GClass126.int_3 = 0;
		int num = 0;
		long num2 = 0L;
		SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
		while (!this.bool_1)
		{
			Thread.Sleep(40);
			if (!GClass126.bool_0)
			{
				if (GClass125.smethod_48())
				{
					if (this.tcpClient_0 == null)
					{
						GClass126.smethod_2("PM stopped(1)", 1);
						return;
					}
				}
				else
				{
					if (GClass125.smethod_52())
					{
						if (this.bluetoothLEDevice_0 != null)
						{
							if (this.gattDeviceService_0 != null)
							{
								goto IL_84;
							}
						}
						GClass126.smethod_2("PM stopped(1)", 1);
						return;
					}
					if (this.serialPort_0 == null || !this.serialPort_0.IsOpen)
					{
						GClass126.smethod_2("PM stopped(1)", 1);
						return;
					}
				}
			}
			IL_84:
			if (GClass126.smethod_1() > GClass126.int_3 + GClass126.int_5 && !this.bool_2)
			{
				GClass126.int_3 = GClass126.smethod_1();
				num++;
				if (!GClass126.bool_22)
				{
					num = 0;
					Thread.Sleep(100);
				}
				else
				{
					for (int i = 0; i < this.list_0.Count; i++)
					{
						GClass104 gclass = this.list_0[i];
						if (gclass.bool_0 && (!GClass126.bool_12 || num % gclass.int_3 == 0))
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
									byte[] array3 = this.method_54(gclass.byte_0[0]);
									gclass.method_1(this.r4(array3, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									sortedList.Add(GClass127.smethod_11(gclass.byte_0[0]), array3);
									if (array3.Length != 0)
									{
										num2 = (long)GClass126.smethod_1();
									}
									if ((long)GClass126.smethod_1() > num2 + 5000L)
									{
										GClass126.smethod_2("Force KA", 1);
										this.int_0 -= this.int_5;
										if (!this.bool_1)
										{
											Thread.Sleep(200);
										}
									}
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
						if (list != null)
						{
							string text = "";
							for (int j = 0; j < list.Count; j++)
							{
								text = text + list[j].method_0() + " ";
							}
							this.string_11 = text;
						}
					}
					else
					{
						this.string_11 = "";
					}
					if (GClass126.bool_12 && GClass126.list_1.Count > 0)
					{
						GClass126.smethod_0().method_2(GClass126.smethod_1());
					}
					this.bool_4 = true;
					int num3 = GClass126.smethod_1() - GClass126.int_3;
					if (num3 > GClass126.int_6)
					{
						GClass126.int_6 = num3;
					}
					if (!GClass126.bool_12)
					{
						if (num3 < GClass126.int_6)
						{
							GClass126.int_6 = num3;
						}
						GClass126.int_5 = GClass126.int_6;
					}
					sortedList.Clear();
				}
			}
		}
		GClass126.smethod_2("PM stopped", 1);
	}

	// Token: 0x060001AB RID: 427 RVA: 0x0002CB4C File Offset: 0x0002AD4C
	private void method_56()
	{
		GClass126.smethod_2("KA started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(100);
			if (GClass125.smethod_48())
			{
				if (this.tcpClient_0 == null)
				{
					GClass126.smethod_2("KA stopped(1)", 1);
					GClass126.smethod_2("Terminate 8", 1);
					base.method_30(true);
					return;
				}
			}
			else
			{
				if (GClass125.smethod_52())
				{
					if (this.bluetoothLEDevice_0 != null)
					{
						if (this.gattDeviceService_0 != null)
						{
							goto IL_65;
						}
					}
					GClass126.smethod_2("KA stopped(1)", 1);
					GClass126.smethod_2("Terminate 8", 1);
					base.method_30(true);
					return;
				}
				if (this.serialPort_0 == null || !this.serialPort_0.IsOpen)
				{
					GClass126.smethod_2("KA stopped(1)", 1);
					GClass126.smethod_2("Terminate 8", 1);
					base.method_30(true);
					return;
				}
			}
			IL_65:
			if (GClass126.smethod_1() > this.int_0 + this.int_5 && !this.bool_2)
			{
				byte[] array = this.method_54(this.byte_3);
				if (!this.bool_3 && (array.Length < 2 || array[1] != 126))
				{
					GClass126.smethod_2("KA response error!", 1);
					if (array.Length == 0)
					{
						array = this.method_54(this.byte_3);
						if (array.Length == 0)
						{
							this.string_8 = "KA";
							GClass126.smethod_2("Terminate 7", 1);
							base.method_30(true);
						}
					}
				}
			}
		}
		GClass126.smethod_2("KA stopped", 1);
	}

	// Token: 0x060001AC RID: 428 RVA: 0x0002CCAC File Offset: 0x0002AEAC
	protected GClass57()
	{
		byte[] array = new byte[3];
		array[0] = 2;
		array[1] = 62;
		this.byte_3 = array;
		this.byte_4 = new byte[]
		{
			2,
			16,
			146
		};
		this.byte_5 = new byte[]
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
		this.byte_6 = new byte[]
		{
			4,
			24,
			0,
			byte.MaxValue,
			0
		};
		this.byte_7 = new byte[]
		{
			3,
			20,
			byte.MaxValue,
			0
		};
		byte[] array2 = new byte[4];
		array2[0] = 3;
		array2[1] = 23;
		this.byte_8 = array2;
		this.string_22 = new string[]
		{
			"0C 57 01 01 10 61 24 A7 1D 08 2D FF 40",
			"00 00 00 38 22 99 12 65 29 81 02 00",
			"00 00 00 95 18 24 76 4A 6B 1F 00 00"
		};
		this.char_1 = new char[]
		{
			'\r',
			'\n',
			' '
		};
		base..ctor();
	}

	// Token: 0x04000134 RID: 308
	protected int int_5 = 2000;

	// Token: 0x04000135 RID: 309
	protected byte[] byte_3;

	// Token: 0x04000136 RID: 310
	protected byte[] byte_4;

	// Token: 0x04000137 RID: 311
	protected byte[] byte_5;

	// Token: 0x04000138 RID: 312
	protected byte[] byte_6;

	// Token: 0x04000139 RID: 313
	protected byte[] byte_7;

	// Token: 0x0400013A RID: 314
	protected byte[] byte_8;

	// Token: 0x0400013B RID: 315
	private string[] string_22;

	// Token: 0x0400013C RID: 316
	private char[] char_1;
}
