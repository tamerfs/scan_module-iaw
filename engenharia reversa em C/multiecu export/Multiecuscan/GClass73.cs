using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x0200001E RID: 30
public abstract class GClass73 : GClass11
{
	// Token: 0x060001D3 RID: 467 RVA: 0x00030BE4 File Offset: 0x0002EDE4
	protected void method_45()
	{
		if (GClass126.bool_0)
		{
			byte[][] array = new byte[][]
			{
				new byte[]
				{
					26,
					246,
					95,
					68,
					53,
					104,
					95,
					95,
					65,
					56,
					95,
					95,
					65,
					48,
					52,
					54,
					52,
					55,
					51,
					57,
					56,
					52,
					51,
					50,
					57,
					54
				},
				new byte[]
				{
					26,
					246,
					95,
					68,
					53,
					109,
					95,
					95,
					65,
					68,
					95,
					95,
					66,
					48,
					52,
					54,
					53,
					51,
					52,
					55,
					48,
					52,
					51,
					57,
					57,
					55,
					69
				},
				new byte[]
				{
					14,
					246,
					20,
					7,
					3,
					22,
					16,
					16,
					6,
					0,
					81,
					113,
					24,
					22,
					78
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
			this.string_7 = "26 86 9B 02 9E";
			for (int j = 0; j < this.list_1.Count; j++)
			{
				GClass104 gclass = this.list_1[j];
				if (gclass.byte_0[0][0] == 0)
				{
					gclass.method_1(this.r4(GClass127.smethod_32("00 00 " + this.string_7), gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
				else if (this.string_0 == "CLIMA25")
				{
					gclass.method_1(this.r4(GClass127.smethod_32("1B AE AA 55 CC 33 00 3C 41 32 14 97 02 77 01 16 23 80 79 10 AE 00 90 32 32 AA 08"), gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
				else
				{
					gclass.method_1(this.r4(array[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
			}
			this.bool_1 = false;
			this.bool_0 = true;
			new Thread(new ThreadStart(this.method_56))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_36();
			throw new Exception("1");
		}
	}

	// Token: 0x060001D4 RID: 468
	protected abstract void r6();

	// Token: 0x060001D5 RID: 469 RVA: 0x00030DA8 File Offset: 0x0002EFA8
	public override void vmethod_1()
	{
		try
		{
			GClass126.smethod_2("-----------------------", 0);
			GClass126.smethod_2("Control module (ISO9141): " + GClass127.smethod_23(this.byte_0), 0);
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
			base.method_33(GClass127.smethod_32("00"), "hex2", new string[]
			{
				""
			}, "");
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
			if (this.string_0 == "CLIMA25" || this.string_0 == "IAW1AF")
			{
				this.byte_3 = GClass127.smethod_32("03 09 00 0C");
				this.byte_9 = GClass127.smethod_32("03 50 00 53");
				this.byte_10 = GClass127.smethod_32("03 60 00 63");
				this.int_11 = 100;
			}
			if (this.string_0 == "VAS974")
			{
				this.byte_9 = GClass127.smethod_32("03 10 06");
				this.byte_10 = GClass127.smethod_32("06 02 01 00 04 00");
				this.int_11 = 100;
			}
			if (this.genum0_0 == (GEnum0)0)
			{
				Thread thread = new Thread(new ThreadStart(this.method_57));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_56))
				{
					Priority = ThreadPriority.Highest
				}.Start();
			}
			for (int j = 0; j < this.list_1.Count; j++)
			{
				GClass104 gclass = this.list_1[j];
				if (gclass.byte_0[0][0] == 0)
				{
					gclass.method_1(this.r4(GClass127.smethod_32("00 00 " + this.string_7), gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
				else
				{
					gclass.method_1(this.vmethod_0(gclass.byte_0[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
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
			else
			{
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

	// Token: 0x060001D6 RID: 470 RVA: 0x000310F4 File Offset: 0x0002F2F4
	public List<GClass102> method_46()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_5;
		}
		else
		{
			array = this.method_55(this.byte_9);
		}
		if (array.Length >= 18)
		{
			if (array[1] == 252)
			{
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						if ((array[2 + i] & this.byte_11[j]) != 0 || (array[10 + i] & this.byte_11[j]) != 0)
						{
							try
							{
								GClass102 gclass = new GClass102();
								byte byte_ = (byte)(i * 8 + (j + 1));
								gclass.string_0 = GClass127.smethod_23(byte_);
								gclass.byte_0 = (((array[10 + i] & this.byte_11[j]) > 0) ? 1 : 0);
								GClass102 gclass2 = gclass;
								gclass2.byte_0 += (((array[2 + i] & this.byte_11[j]) != 0) ? 10 : 0);
								gclass.byte_1 = 32;
								gclass.string_5 = "";
								gclass.string_6 = "";
								gclass.string_7 = "";
								gclass.string_2 = "";
								string string_ = "";
								if (gclass.byte_0 == 1)
								{
									string_ = GClass121.smethod_6("3062");
								}
								else if (gclass.byte_0 == 10)
								{
									string_ = GClass121.smethod_6("3053");
								}
								else if (gclass.byte_0 == 11)
								{
									string_ = GClass121.smethod_6("3062") + "/" + GClass121.smethod_6("3053");
								}
								string str = "";
								if (gclass.byte_0 == 1)
								{
									str = GClass121.smethod_6("3077");
								}
								else if (gclass.byte_0 == 10)
								{
									str = GClass121.smethod_6("3076");
								}
								else if (gclass.byte_0 == 11)
								{
									str = GClass121.smethod_6("3078");
								}
								gclass.string_6 = string_;
								GClass102 gclass3 = gclass;
								gclass3.string_3 = gclass3.string_3 + str + "\r\n";
								list.Add(gclass);
								goto IL_1FF;
							}
							catch (Exception)
							{
								GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
								goto IL_1FF;
							}
							break;
						}
						IL_1FF:;
					}
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x00031334 File Offset: 0x0002F534
	public List<GClass102> method_47()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_7;
		}
		else
		{
			array = this.method_55(this.byte_9);
		}
		if (array.Length < 2)
		{
			GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
			return null;
		}
		for (int i = 2; i < array.Length - 1; i++)
		{
			if (array[i] != 0)
			{
				try
				{
					GClass102 gclass = new GClass102();
					gclass.string_0 = ((i - 1 < 10) ? "0" : "") + (i - 1).ToString();
					gclass.byte_0 = array[i];
					gclass.byte_1 = 32;
					gclass.string_5 = "";
					gclass.string_6 = "";
					gclass.string_7 = "";
					gclass.string_2 = "";
					string string_ = GClass121.smethod_6("3062");
					if (gclass.byte_0 == 1)
					{
						string_ = GClass121.smethod_6("3054");
					}
					gclass.string_6 = string_;
					list.Add(gclass);
				}
				catch (Exception)
				{
					GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
				}
			}
		}
		return list;
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x00031454 File Offset: 0x0002F654
	public List<GClass102> method_48()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_8;
		}
		else
		{
			array = this.method_55(this.byte_9);
		}
		if (array.Length >= 20)
		{
			if (array[1] == 175)
			{
				for (int i = 0; i < this.int_13.Length; i++)
				{
					if (array.Length >= this.int_14[this.int_14.Length - 1])
					{
						for (int j = 0; j < 8; j++)
						{
							if ((array[2 + this.int_13[i]] & this.byte_11[j]) != 0 || (array[2 + this.int_14[i]] & this.byte_11[j]) != 0)
							{
								try
								{
									GClass102 gclass = new GClass102();
									gclass.string_0 = i.ToString() + (j + 1).ToString();
									gclass.byte_0 = (((array[2 + this.int_12[i]] & this.byte_11[j]) > 0) ? 1 : 0);
									GClass102 gclass2 = gclass;
									gclass2.byte_0 += (((array[2 + this.int_13[i]] & this.byte_11[j]) != 0) ? 2 : 0);
									GClass102 gclass3 = gclass;
									gclass3.byte_0 += (((array[2 + this.int_14[i]] & this.byte_11[j]) != 0) ? 4 : 0);
									gclass.byte_1 = 32;
									gclass.string_5 = "";
									gclass.string_6 = "";
									gclass.string_7 = "";
									gclass.string_2 = "";
									string string_ = "";
									if ((gclass.byte_0 & 1) == 1)
									{
										string_ = GClass121.smethod_6("3062");
									}
									else if ((gclass.byte_0 & 4) == 4)
									{
										string_ = GClass121.smethod_6("3053");
									}
									else if ((gclass.byte_0 & 2) == 2)
									{
										string_ = GClass121.smethod_6("3054");
									}
									string str = "";
									if ((gclass.byte_0 & 1) == 1)
									{
										str = GClass121.smethod_6("3078");
									}
									else if ((gclass.byte_0 & 4) == 4)
									{
										str = GClass121.smethod_6("3076");
									}
									else if ((gclass.byte_0 & 2) == 2)
									{
										str = GClass121.smethod_6("3075");
									}
									gclass.string_6 = string_;
									GClass102 gclass4 = gclass;
									gclass4.string_3 = gclass4.string_3 + str + "\r\n";
									list.Add(gclass);
									goto IL_25E;
								}
								catch (Exception)
								{
									GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
									goto IL_25E;
								}
								break;
							}
							IL_25E:;
						}
					}
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x000316F4 File Offset: 0x0002F8F4
	public List<GClass102> method_49()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array = this.byte_4;
		int num = 10;
		while (array.Length > 3 && num > 0)
		{
			if (GClass126.bool_0)
			{
				array = this.byte_4;
			}
			else
			{
				array = this.method_55(this.byte_9);
			}
			if (array.Length < 2 && num == 10)
			{
				GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
				return null;
			}
			for (int i = 2; i < array.Length - 5; i += 5)
			{
				try
				{
					GClass102 gclass = new GClass102();
					gclass.string_0 = GClass127.smethod_11(new byte[]
					{
						array[i]
					}).Replace(" ", "");
					gclass.byte_0 = array[i + 1];
					gclass.byte_1 = array[i + 4];
					gclass.string_5 = "";
					gclass.string_6 = "";
					gclass.string_7 = "";
					gclass.string_2 = GClass127.smethod_11(new byte[]
					{
						array[i]
					}).Replace(" ", "");
					string text = GClass121.smethod_6("3099");
					if ((int)(gclass.byte_0 & 31) < this.string_22.Length)
					{
						text = this.string_22[(int)(gclass.byte_0 & 31)];
					}
					gclass.string_5 = text;
					GClass102 gclass2 = gclass;
					gclass2.string_3 = string.Concat(new string[]
					{
						gclass2.string_3,
						GClass121.smethod_6("3070"),
						" ",
						text,
						"\r\n"
					});
					string text2 = "";
					if ((gclass.byte_0 & 128) != 0)
					{
						text2 += GClass121.smethod_6("3060");
					}
					if ((gclass.byte_0 & 64) != 0)
					{
						text2 = text2 + ((text2.Length > 0) ? " / " : "") + GClass121.smethod_6("3061");
					}
					if ((gclass.byte_0 & 32) != 0)
					{
						text2 = text2 + ((text2.Length > 0) ? " / " : "") + GClass121.smethod_6("3062");
					}
					gclass.string_6 = text2;
					gclass2 = gclass;
					gclass2.string_3 = string.Concat(new string[]
					{
						gclass2.string_3,
						GClass121.smethod_6("3071"),
						" ",
						text2,
						"\r\n"
					});
					gclass2 = gclass;
					gclass2.string_3 = string.Concat(new string[]
					{
						gclass2.string_3,
						GClass121.smethod_6("3072"),
						" ",
						gclass.byte_1.ToString(),
						"\r\n"
					});
					gclass.string_7 = (gclass.byte_1.ToString() ?? "");
					bool flag = false;
					using (List<GClass102>.Enumerator enumerator = list.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current.string_0 == gclass.string_0)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						list.Add(gclass);
					}
					goto IL_31B;
				}
				catch (Exception)
				{
					GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
					goto IL_31B;
				}
				break;
				IL_31B:;
			}
			num--;
		}
		return list;
	}

	// Token: 0x060001DA RID: 474 RVA: 0x00031A68 File Offset: 0x0002FC68
	public override List<GClass102> r1()
	{
		if (this.string_0 == "ABSTEVES")
		{
			return this.method_46();
		}
		if (this.string_0 == "HTCHI")
		{
			return this.method_49();
		}
		if (this.string_0 == "CLIMA25")
		{
			return this.method_47();
		}
		if (this.string_0 == "IAW1AF")
		{
			return this.method_48();
		}
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0 && this.string_0 == "TD100")
		{
			array = this.byte_6;
		}
		else if (GClass126.bool_0)
		{
			array = this.byte_4;
		}
		else
		{
			array = this.method_55(this.byte_9);
		}
		if (array.Length >= 2)
		{
			if (array[1] == 252)
			{
				int i = 2;
				while (i < array.Length - 4)
				{
					try
					{
						GClass102 gclass = new GClass102();
						gclass.string_0 = GClass127.smethod_11(new byte[]
						{
							array[i]
						}).Replace(" ", "");
						gclass.byte_0 = array[i + 1];
						gclass.byte_1 = array[i + 4];
						gclass.string_5 = "";
						gclass.string_6 = "";
						gclass.string_7 = "";
						gclass.string_2 = GClass127.smethod_11(new byte[]
						{
							array[i]
						}).Replace(" ", "");
						string text = GClass121.smethod_6("3099");
						if ((int)(gclass.byte_0 & 31) < this.string_22.Length)
						{
							text = this.string_22[(int)(gclass.byte_0 & 31)];
						}
						gclass.string_5 = text;
						GClass102 gclass2 = gclass;
						gclass2.string_3 = string.Concat(new string[]
						{
							gclass2.string_3,
							GClass121.smethod_6("3070"),
							" ",
							text,
							"\r\n"
						});
						string text2 = "";
						if ((gclass.byte_0 & 128) != 0)
						{
							text2 += GClass121.smethod_6("3060");
						}
						if ((gclass.byte_0 & 64) != 0)
						{
							text2 = text2 + ((text2.Length > 0) ? " / " : "") + GClass121.smethod_6("3061");
						}
						if ((gclass.byte_0 & 32) != 0)
						{
							text2 = text2 + ((text2.Length > 0) ? " / " : "") + GClass121.smethod_6("3062");
						}
						gclass.string_6 = text2;
						gclass2 = gclass;
						gclass2.string_3 = string.Concat(new string[]
						{
							gclass2.string_3,
							GClass121.smethod_6("3071"),
							" ",
							text2,
							"\r\n"
						});
						gclass2 = gclass;
						gclass2.string_3 = string.Concat(new string[]
						{
							gclass2.string_3,
							GClass121.smethod_6("3072"),
							" ",
							gclass.byte_1.ToString(),
							"\r\n"
						});
						gclass.string_7 = (gclass.byte_1.ToString() ?? "");
						list.Add(gclass);
						goto IL_33C;
					}
					catch (Exception ex)
					{
						GClass126.smethod_2("ERROR: Exception while reading error codes: " + ex.Message, 0);
						goto IL_33C;
					}
					IL_333:
					i++;
					continue;
					IL_33C:
					i += 5;
					if (this.string_0 == "TD100")
					{
						goto IL_333;
					}
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x060001DB RID: 475 RVA: 0x00009148 File Offset: 0x00007348
	private string method_50(byte byte_12)
	{
		string result = "";
		if ((byte_12 & 8) != 0)
		{
			result = GClass121.smethod_6("3056");
		}
		else if ((byte_12 & 4) != 0)
		{
			result = GClass121.smethod_6("3057");
		}
		else if ((byte_12 & 2) != 0)
		{
			result = GClass121.smethod_6("3058");
		}
		else if ((byte_12 & 1) != 0)
		{
			result = GClass121.smethod_6("3059");
		}
		return result;
	}

	// Token: 0x060001DC RID: 476 RVA: 0x00031DF8 File Offset: 0x0002FFF8
	public override void r2()
	{
		if (GClass126.bool_0)
		{
			this.byte_4 = new byte[]
			{
				2,
				252
			};
			return;
		}
		byte[] array = this.method_55(this.byte_10);
		if (array.Length < 2 || array[1] != 9)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x060001DD RID: 477 RVA: 0x00031E4C File Offset: 0x0003004C
	protected override void r3(GClass104 gclass104_1)
	{
		if (!GClass126.bool_0)
		{
			this.method_51(gclass104_1);
			return;
		}
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
	}

	// Token: 0x060001DE RID: 478 RVA: 0x00031ED4 File Offset: 0x000300D4
	private void method_51(GClass104 gclass104_1)
	{
		byte[] array = this.method_55(gclass104_1.byte_0[0]);
		bool flag = false;
		if (array.Length == 0)
		{
			flag = true;
		}
		else if (array.Length > 1 && array[1] != 9 && array[1] != 13)
		{
			flag = true;
		}
		if (GClass127.smethod_11(gclass104_1.byte_0[0]) == "06 02 01 00 01 01" && GClass127.smethod_11(array) == "05 ED 00 01 FF")
		{
			flag = false;
		}
		if (flag)
		{
			string string_ = "";
			base.method_28(false, GClass121.smethod_6("6052"), string_);
			for (int i = 0; i < 18; i++)
			{
				if (!GClass126.bool_25)
				{
					Thread.Sleep(100);
				}
			}
			return;
		}
		if (gclass104_1.byte_0.Length > 2)
		{
			for (int j = 1; j < gclass104_1.byte_0.Length; j++)
			{
				for (int k = 0; k < 20; k++)
				{
					if (!GClass126.bool_25)
					{
						Thread.Sleep(100);
					}
				}
				this.method_55(gclass104_1.byte_0[j]);
			}
		}
		else if (gclass104_1.byte_0.Length == 2)
		{
			for (int l = 1; l < gclass104_1.byte_0.Length; l++)
			{
				for (int m = 0; m < 80; m++)
				{
					if (!GClass126.bool_25)
					{
						Thread.Sleep(100);
					}
				}
				this.method_55(gclass104_1.byte_0[l]);
			}
		}
		else
		{
			for (int n = 0; n < 100; n++)
			{
				if (!GClass126.bool_25)
				{
					Thread.Sleep(100);
				}
			}
		}
		base.method_28(false, GClass121.smethod_6("6051"), "");
	}

	// Token: 0x060001DF RID: 479 RVA: 0x00032050 File Offset: 0x00030250
	public override string vmethod_0(byte[] byte_12, string string_23, int int_15, int int_16, string[] string_24, string string_25)
	{
		byte[] byte_13 = this.method_55(byte_12);
		if (string_23 == "raw")
		{
			return GClass127.smethod_11(byte_13);
		}
		return this.r4(byte_13, string_23, int_15, int_16, string_24, string_25);
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x00032088 File Offset: 0x00030288
	private byte[] method_52(byte[] byte_12)
	{
		byte[] array = new byte[byte_12.Length + 1];
		byte b = 0;
		for (int i = 0; i < byte_12.Length; i++)
		{
			array[i] = byte_12[i];
			b += byte_12[i];
		}
		array[array.Length - 1] = b;
		this.r9(GClass127.smethod_11(array));
		string text = this.rb();
		if (!text.Contains("NO DATA") && !text.Contains("ERROR"))
		{
			int num = 0;
			while (num < text.Length && text[num] != '\r' && text[num] != '\n')
			{
				if (text[num] == '>')
				{
					break;
				}
				num++;
			}
			return GClass127.smethod_32(text.Substring(0, num));
		}
		return new byte[0];
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x00032144 File Offset: 0x00030344
	private byte[] method_53(byte[] byte_12)
	{
		while (GClass126.smethod_1() < this.int_0 + this.int_9)
		{
			Thread.Sleep(1);
		}
		byte b = 0;
		byte[] array = new byte[byte_12.Length - 1];
		for (int i = 0; i < byte_12.Length; i++)
		{
			if (i > 0)
			{
				array[i - 1] = byte_12[i];
			}
			b += byte_12[i];
		}
		if (!(this.string_0 == "CLIMA25") && !(this.string_0 == "IAW1AF"))
		{
			this.r9(GClass127.smethod_11(array) + GClass127.smethod_23(b));
		}
		else
		{
			this.r9(GClass127.smethod_11(array));
		}
		string text = this.rb();
		if (!text.Contains("NO DATA") && !text.Contains("ERROR"))
		{
			text = text.Replace("\r", "").Replace("\n", "");
			int num = 0;
			while (num < text.Length && text[num] != '\r' && text[num] != '\n')
			{
				if (text[num] == '>')
				{
					break;
				}
				num++;
			}
			string string_ = text.Substring(0, num);
			this.int_0 = GClass126.smethod_1();
			return GClass127.smethod_32(string_);
		}
		return new byte[0];
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x00032284 File Offset: 0x00030484
	private byte[] method_54(byte[] byte_12)
	{
		if (GClass125.smethod_44() != 4 && GClass125.smethod_44() != 5)
		{
			if (GClass125.smethod_44() != 10)
			{
				if (GClass125.smethod_44() != 7)
				{
					if (GClass125.smethod_44() != 12)
					{
						while (GClass126.smethod_1() < this.int_0 + this.int_9)
						{
							Thread.Sleep(1);
						}
						if (GClass125.smethod_49() && byte_12.Length == 3 && byte_12[0] == 255 && byte_12[1] == 255)
						{
							this.r9("ATGR" + GClass127.smethod_23(byte_12[2]));
						}
						else if (GClass125.smethod_49() && byte_12.Length == 2 && byte_12[0] == 2 && byte_12[1] == 9)
						{
							this.r9("ATGR07");
						}
						else if (GClass125.smethod_49())
						{
							byte b = 0;
							for (int i = 0; i < byte_12.Length; i++)
							{
								b += byte_12[i];
							}
							if (!(this.string_0 == "CLIMA25") && !(this.string_0 == "IAW1AF"))
							{
								this.r9(GClass127.smethod_11(byte_12) + GClass127.smethod_23(b) + "1");
							}
							else
							{
								this.r9(GClass127.smethod_11(byte_12) + "1");
							}
						}
						else
						{
							this.r9(GClass127.smethod_11(byte_12));
						}
						string text = this.rb();
						if (!text.Contains("NO DATA") && !text.Contains("ERROR"))
						{
							int num = 0;
							while (num < text.Length && text[num] != '\r' && text[num] != '\n')
							{
								if (text[num] == '>')
								{
									break;
								}
								num++;
							}
							string string_ = text.Substring(0, num);
							this.int_0 = GClass126.smethod_1();
							return GClass127.smethod_32(string_);
						}
						return new byte[0];
					}
				}
				return this.method_53(byte_12);
			}
		}
		return this.method_52(byte_12);
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x00032458 File Offset: 0x00030658
	private byte[] method_55(byte[] byte_12)
	{
		List<byte> list = new List<byte>();
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			byte[] array = this.method_54(byte_12);
			int num = array.Length;
			if (this.string_0 == "IAW1AF")
			{
				num -= 2;
			}
			else
			{
				num--;
			}
			for (int i = 0; i < num; i++)
			{
				list.Add(array[i]);
			}
			int num2 = 10;
			if (this.string_0 == "CLIMA25")
			{
				num2 = 0;
			}
			if (array.Length < 6)
			{
				num2 = 0;
			}
			while (array.Length != 0 && array[1] != 9 && num2 > 0)
			{
				array = this.method_54(this.byte_3);
				num = array.Length;
				if (this.string_0 == "IAW1AF")
				{
					num -= 2;
				}
				else
				{
					num--;
				}
				if (num > 2)
				{
					for (int j = 2; j < num; j++)
					{
						list.Add(array[j]);
					}
				}
				num2--;
			}
			this.int_0 = GClass126.smethod_1();
			this.bool_2 = false;
			GClass126.smethod_2("DECODED RESPONSE: " + GClass127.smethod_11(list.ToArray()), 0);
			result = list.ToArray();
		}
		catch (Exception ex)
		{
			if (!this.bool_1)
			{
				GClass126.smethod_2(ex.Message + "(3)", 1);
				this.bool_2 = false;
				GClass126.smethod_2("Terminate 5", 1);
				base.method_30(true);
			}
			this.bool_2 = false;
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x000325E4 File Offset: 0x000307E4
	public override string r4(byte[] byte_12, string string_23, int int_15, int int_16, string[] string_24, string string_25)
	{
		string result = "";
		int_15++;
		if (byte_12.Length <= int_15)
		{
			return result;
		}
		int num = byte_12.Length - int_15;
		if (int_16 < num)
		{
			num = int_16;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_12[i + int_15];
		}
		return base.method_33(array, string_23, string_24, string_25);
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x00032640 File Offset: 0x00030840
	private void method_56()
	{
		GClass126.smethod_2("PM started", 1);
		GClass126.int_3 = 0;
		int num = 0;
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
								goto IL_7A;
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
			IL_7A:
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
										251,
										0,
										145
									},
									new byte[]
									{
										4,
										251,
										0,
										198
									},
									new byte[]
									{
										4,
										251,
										0,
										15
									},
									new byte[]
									{
										4,
										251,
										0,
										92
									},
									new byte[]
									{
										4,
										251,
										0,
										229
									},
									new byte[]
									{
										4,
										251,
										0,
										128
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
								gclass.method_1(this.random_0.Next(0, 100).ToString() ?? "");
								if (gclass.byte_0[0].Length == 3)
								{
									if (gclass.byte_0[0][2] == 1)
									{
										gclass.method_1(this.r4(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									}
									else if (gclass.byte_0[0][2] == 2)
									{
										gclass.method_1(this.r4(array[1], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									}
									else if (gclass.byte_0[0][2] == 3)
									{
										gclass.method_1(this.r4(array[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									}
									else if (gclass.byte_0[0][2] == 4)
									{
										gclass.method_1(this.r4(array[3], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									}
									else if (gclass.byte_0[0][2] == 5)
									{
										gclass.method_1(this.r4(array[4], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									}
									else if (gclass.byte_0[0][2] == 6)
									{
										gclass.method_1(this.r4(array[5], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									}
									else
									{
										gclass.method_1(this.r4(array[5], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									}
								}
								else if (gclass.string_2.StartsWith("bit"))
								{
									gclass.method_1(this.r4(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								Thread.Sleep(this.int_9);
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
									byte[] value = this.method_55(gclass.byte_0[0]);
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
					int num2 = GClass126.smethod_1() - GClass126.int_3;
					if (num2 > GClass126.int_6)
					{
						GClass126.int_6 = num2;
					}
					if (!GClass126.bool_12)
					{
						if (num2 < GClass126.int_6)
						{
							GClass126.int_6 = num2;
						}
						GClass126.int_5 = GClass126.int_6;
					}
					sortedList.Clear();
				}
			}
		}
		GClass126.smethod_2("PM stopped", 1);
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x00032C34 File Offset: 0x00030E34
	private void method_57()
	{
		GClass126.smethod_2("KA started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(20);
			if (GClass125.smethod_48())
			{
				if (this.tcpClient_0 == null)
				{
					GClass126.smethod_2("KA stopped(1)", 1);
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
					return;
				}
				if (this.serialPort_0 == null || !this.serialPort_0.IsOpen)
				{
					GClass126.smethod_2("KA stopped(1)", 1);
					return;
				}
			}
			IL_65:
			if (GClass126.smethod_1() > this.int_0 + this.int_11 && !this.bool_2)
			{
				byte[] array = this.method_55(this.byte_3);
				if (array.Length < 2 || array[1] != 9)
				{
					GClass126.smethod_2("KA response error!", 1);
					if (array.Length == 0 && this.int_1 > 1)
					{
						GClass126.smethod_2("Terminate 7", 1);
						base.method_30(true);
					}
				}
			}
		}
		GClass126.smethod_2("KA stopped", 1);
	}

	// Token: 0x0400014E RID: 334
	private int int_5 = 2000;

	// Token: 0x0400014F RID: 335
	private int int_6 = 3;

	// Token: 0x04000150 RID: 336
	private int int_7 = 1000;

	// Token: 0x04000151 RID: 337
	private int int_8 = 3;

	// Token: 0x04000152 RID: 338
	private int int_9 = 40;

	// Token: 0x04000153 RID: 339
	private int int_10 = 3;

	// Token: 0x04000154 RID: 340
	private int int_11 = 185;

	// Token: 0x04000155 RID: 341
	private byte[] byte_3 = new byte[]
	{
		2,
		9
	};

	// Token: 0x04000156 RID: 342
	private byte[] byte_4 = new byte[]
	{
		21,
		252,
		60,
		75,
		49,
		115,
		8,
		14,
		71,
		55,
		161,
		147,
		14,
		97,
		63,
		167,
		170,
		2,
		70,
		81,
		188,
		160
	};

	// Token: 0x04000157 RID: 343
	private byte[] byte_5 = new byte[]
	{
		10,
		252,
		0,
		0,
		1,
		0,
		0,
		0,
		0,
		1,
		0,
		0,
		1,
		0,
		0,
		0,
		128,
		0,
		0,
		0,
		31,
		0,
		0,
		0,
		0
	};

	// Token: 0x04000158 RID: 344
	private byte[] byte_6 = new byte[]
	{
		8,
		252,
		6,
		6,
		54,
		0,
		0,
		65,
		13,
		2,
		85,
		0,
		0,
		64,
		18,
		108,
		183,
		1,
		64,
		64
	};

	// Token: 0x04000159 RID: 345
	private byte[] byte_7 = new byte[]
	{
		19,
		175,
		0,
		1,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		1,
		0,
		0,
		0,
		0,
		0,
		0
	};

	// Token: 0x0400015A RID: 346
	private byte[] byte_8 = new byte[]
	{
		19,
		175,
		0,
		1,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		1,
		0,
		0,
		0,
		0,
		0,
		0,
		1,
		0,
		0,
		0,
		0,
		0,
		0
	};

	// Token: 0x0400015B RID: 347
	private byte[] byte_9 = new byte[]
	{
		2,
		7
	};

	// Token: 0x0400015C RID: 348
	private byte[] byte_10 = new byte[]
	{
		2,
		5
	};

	// Token: 0x0400015D RID: 349
	private string[] string_22 = new string[]
	{
		GClass121.smethod_6("3080"),
		GClass121.smethod_6("3081"),
		GClass121.smethod_6("3082"),
		GClass121.smethod_6("3083"),
		GClass121.smethod_6("3084"),
		GClass121.smethod_6("3085"),
		GClass121.smethod_6("3086"),
		GClass121.smethod_6("3087"),
		GClass121.smethod_6("3088"),
		GClass121.smethod_6("3089"),
		GClass121.smethod_6("3090"),
		GClass121.smethod_6("3091"),
		GClass121.smethod_6("3092"),
		GClass121.smethod_6("3093"),
		GClass121.smethod_6("3094"),
		GClass121.smethod_6("3095"),
		GClass121.smethod_6("3096"),
		GClass121.smethod_6("3097"),
		GClass121.smethod_6("3098"),
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		""
	};

	// Token: 0x0400015E RID: 350
	private byte[] byte_11 = new byte[]
	{
		1,
		2,
		4,
		8,
		16,
		32,
		64,
		128
	};

	// Token: 0x0400015F RID: 351
	private int[] int_12 = new int[]
	{
		0,
		1,
		2,
		9,
		10,
		11,
		18,
		21,
		24
	};

	// Token: 0x04000160 RID: 352
	private int[] int_13 = new int[]
	{
		3,
		4,
		5,
		12,
		13,
		14,
		19,
		22,
		25
	};

	// Token: 0x04000161 RID: 353
	private int[] int_14 = new int[]
	{
		6,
		7,
		8,
		15,
		16,
		17,
		20,
		23,
		26
	};
}
