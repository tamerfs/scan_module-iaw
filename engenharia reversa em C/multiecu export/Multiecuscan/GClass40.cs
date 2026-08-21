using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x02000018 RID: 24
public abstract class GClass40 : GClass11
{
	// Token: 0x06000163 RID: 355
	protected abstract void r6();

	// Token: 0x06000164 RID: 356 RVA: 0x00024640 File Offset: 0x00022840
	public override void vmethod_1()
	{
		try
		{
			GClass126.smethod_2("-----------------------", 0);
			GClass126.smethod_2("Control module (CANSCAN): " + this.string_2 + "/" + this.string_3, 0);
			for (int i = 0; i < 5; i++)
			{
				if (GClass126.bool_25)
				{
					IL_767:
					throw new Exception("ESC");
				}
				Thread.Sleep(100);
			}
			this.r6();
			this.ra("ATCSM1");
			this.ra("ATH1");
			this.ra("ATD0");
			this.ra("ATV1");
			this.r9("ATMA");
			int num = 0;
			int num2 = GClass126.smethod_1();
			try
			{
				for (int j = 0; j < 5; j++)
				{
					string text = base.method_4();
					if (text.Length > 3 && !text.Contains("ERROR") && !text.Contains("STOP") && !text.Contains("RTR"))
					{
						num++;
					}
					if (GClass126.smethod_1() > num2 + 5000)
					{
						break;
					}
				}
			}
			catch (Exception)
			{
			}
			this.r9("");
			try
			{
				this.rb();
			}
			catch (Exception)
			{
			}
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			if (num > 2)
			{
				this.ra("ATH0");
				string string_ = this.string_2;
				if (GClass125.smethod_44() == 15)
				{
					this.ra("ATSPB");
				}
				else if (this.string_2 == "CCAN29")
				{
					this.ra("ATSP7");
				}
				else if (this.string_2 == "BCAN29")
				{
					this.ra("ATSPB");
				}
				else if (this.string_2 == "BHCAN29")
				{
					this.ra("ATSPB");
				}
				using (List<GClass100>.Enumerator enumerator = this.list_5.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						GClass100 gclass = enumerator.Current;
						bool flag = false;
						if (!(gclass.string_3 != string_) && (!(gclass.string_5 != this.string_3) || !GClass125.smethod_49()) && !(gclass.string_3 != string_) && (!(gclass.string_5 != this.string_3) || GClass125.smethod_44() != 15))
						{
							this.ra("ATCRA 18DA" + gclass.string_4 + GClass127.smethod_23(gclass.byte_0));
							this.ra("ATSH DA" + GClass127.smethod_23(gclass.byte_0) + gclass.string_4);
							if (gclass.string_4 == "F4")
							{
								this.ra("ATV0");
								this.ra("ATFCSH 18DA" + GClass127.smethod_23(gclass.byte_0) + gclass.string_4);
								this.ra("ATFCSD 30 00 00");
								this.ra("ATFCSM 1");
							}
							else
							{
								this.ra("ATV1");
								this.ra("ATFCSH 18DA" + GClass127.smethod_23(gclass.byte_0) + gclass.string_4);
								this.ra("ATFCSD 30 00 00");
								this.ra("ATFCSM 0");
							}
							this.ra("ATST99");
							byte[] array = this.method_54(GClass127.smethod_32("021003"));
							if (GClass126.bool_25)
							{
								throw new Exception("ESC");
							}
							if (array.Length > 3 && array[1] == 127 && array[3] == 18)
							{
								array = this.method_54(GClass127.smethod_32("021092"));
							}
							if (array.Length == 0 && gclass.string_4 != "F4")
							{
								this.ra("ATV0");
								array = this.method_54(GClass127.smethod_32("021003"));
								if (array.Length > 3 && array[1] == 127 && array[3] == 18)
								{
									array = this.method_54(GClass127.smethod_32("021092"));
									flag = true;
								}
							}
							if (array.Length > 2 && array[1] == 80)
							{
								this.string_2 = gclass.string_4;
								this.byte_0 = gclass.byte_0;
								SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
								for (int k = 0; k < this.list_1.Count; k++)
								{
									GClass104 gclass2 = this.list_1[k];
									if (GClass126.bool_25)
									{
										throw new Exception("ESC");
									}
									if (sortedList.ContainsKey(GClass127.smethod_11(gclass2.byte_0[0])))
									{
										byte[] array2 = sortedList[GClass127.smethod_11(gclass2.byte_0[0])];
										gclass2.method_1(this.r4(array2, gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
									}
									else
									{
										byte[] array3 = this.method_54(gclass2.byte_0[0]);
										gclass2.method_1(this.r4(array3, gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
										if (gclass2.int_2 == 10455 && gclass2.string_2 == "hex")
										{
											if (GClass127.smethod_11(array3) == "03 7F 22 31" || GClass127.smethod_11(array3) == "08 62 F1 A5 FF FF FF FF FF" || GClass127.smethod_11(array3) == "08 62 F1 A5 20 20 20 20 20" || GClass127.smethod_11(array3) == "08 62 F1 A5 00 00 00 00 00" || gclass.string_4 == "F4" || gclass.byte_0 == 66 || gclass.byte_0 == 67 || gclass.byte_0 == 68 || gclass.byte_0 == 69 || gclass.byte_0 == 71 || gclass.byte_0 == 72)
											{
												array3 = this.method_54(GClass127.smethod_32("03 22 F1 00"));
												gclass2.method_1(this.r4(array3, "isovarver", 2, 2, gclass2.string_5, gclass2.string_6));
											}
											if (GClass127.smethod_11(array3) == "03 7F 22 12")
											{
												array3 = this.method_54(GClass127.smethod_32("02 1A 87"));
												gclass2.method_1(this.r4(array3, "isovarver", 2, 2, gclass2.string_5, gclass2.string_6));
												flag = true;
											}
										}
										sortedList.Add(GClass127.smethod_11(gclass2.byte_0[0]), array3);
									}
									if (gclass2.int_2 == 10455)
									{
										this.string_7 = gclass2.method_0();
									}
								}
								if (this.genum0_0 == (GEnum0)2)
								{
									Thread.Sleep(100);
									if (flag)
									{
										gclass.list_3 = this.method_48();
									}
									else
									{
										gclass.list_3 = this.r1();
									}
								}
								gclass.string_0 = this.string_7;
								gclass.list_0 = this.list_1;
								GClass126.smethod_2("CAN MODULE FOUND: " + gclass.string_1 + " / " + gclass.string_2, 0);
								GClass126.smethod_2(string.Concat(new string[]
								{
									string_,
									",",
									GClass127.smethod_23(gclass.byte_0),
									",",
									gclass.string_4
								}), 0);
								GClass126.smethod_2("CAN MODULE ISO CODE: " + this.string_7, 0);
								base.method_25(gclass);
							}
						}
					}
					goto IL_772;
				}
				goto IL_767;
			}
			IL_772:;
		}
		catch (Exception ex)
		{
			if (ex.Message == "ESC")
			{
				this.string_8 = GClass121.smethod_6("6060");
			}
			GClass126.smethod_2(ex.Message, 2);
			GClass126.smethod_2("Terminate 4", 1);
		}
		base.method_30(false);
	}

	// Token: 0x06000165 RID: 357 RVA: 0x00024E68 File Offset: 0x00023068
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
			array = this.method_54(this.byte_4);
		}
		if (array.Length < 3 || array[1] != 89)
		{
			array = this.method_54(this.byte_4);
		}
		if (array.Length >= 3)
		{
			if (array[1] == 89)
			{
				for (int i = 4; i < array.Length - 2; i += 4)
				{
					GClass102 gclass = new GClass102();
					gclass.string_0 = GClass127.smethod_11(new byte[]
					{
						array[i],
						array[i + 1]
					}).Replace(" ", "");
					gclass.string_1 = GClass127.smethod_11(new byte[]
					{
						array[i],
						array[i + 1],
						array[i + 2]
					}).Replace(" ", "");
					gclass.byte_0 = array[i + 3];
					byte byte_ = array[i + 2];
					gclass.string_5 = this.method_45(byte_);
					gclass.string_6 = this.method_46(gclass.byte_0);
					gclass.string_7 = this.method_47(gclass.byte_0);
					gclass.bool_0 = ((gclass.byte_0 & 1) == 1);
					string str = "";
					if ((array[i] & 192) == 0)
					{
						str = "P";
					}
					else if ((array[i] & 192) == 64)
					{
						str = "C";
					}
					else if ((array[i] & 192) == 128)
					{
						str = "B";
					}
					else if ((array[i] & 192) == 192)
					{
						str = "U";
					}
					gclass.string_2 = str + GClass127.smethod_11(new byte[]
					{
						array[i] & 63,
						array[i + 1]
					}).Replace(" ", "") + "-" + GClass127.smethod_23(array[i + 2]);
					if ((gclass.byte_0 & 9) == 8)
					{
						GClass102 gclass2 = gclass;
						gclass2.string_3 = gclass2.string_3 + GClass121.smethod_6("3077") + " ";
					}
					else if ((gclass.byte_0 & 1) == 1)
					{
						GClass102 gclass3 = gclass;
						gclass3.string_3 = gclass3.string_3 + GClass121.smethod_6("3078") + " ";
					}
					if ((gclass.byte_0 & 128) == 0)
					{
						GClass102 gclass4 = gclass;
						gclass4.string_3 = gclass4.string_3 + GClass121.smethod_6("3073") + " ";
					}
					else
					{
						GClass102 gclass5 = gclass;
						gclass5.string_3 = gclass5.string_3 + GClass121.smethod_6("3074") + " ";
					}
					list.Add(gclass);
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x06000166 RID: 358 RVA: 0x000210C0 File Offset: 0x0001F2C0
	private string method_45(byte byte_10)
	{
		string result = "";
		if (byte_10 == 1)
		{
			result = GClass121.smethod_6("3101");
		}
		else if (byte_10 == 2)
		{
			result = GClass121.smethod_6("3102");
		}
		else if (byte_10 == 3)
		{
			result = GClass121.smethod_6("3103");
		}
		else if (byte_10 == 7)
		{
			result = GClass121.smethod_6("3104");
		}
		else if (byte_10 == 8)
		{
			result = GClass121.smethod_6("3105");
		}
		else if (byte_10 == 9)
		{
			result = GClass121.smethod_6("3106");
		}
		else if (byte_10 == 17)
		{
			result = GClass121.smethod_6("3107");
		}
		else if (byte_10 == 18)
		{
			result = GClass121.smethod_6("3108");
		}
		else if (byte_10 == 19)
		{
			result = GClass121.smethod_6("3109");
		}
		else if (byte_10 == 20)
		{
			result = GClass121.smethod_6("3110");
		}
		else if (byte_10 == 21)
		{
			result = GClass121.smethod_6("3111");
		}
		else if (byte_10 == 22)
		{
			result = GClass121.smethod_6("3112");
		}
		else if (byte_10 == 23)
		{
			result = GClass121.smethod_6("3113");
		}
		else if (byte_10 == 24)
		{
			result = GClass121.smethod_6("3114");
		}
		else if (byte_10 == 25)
		{
			result = GClass121.smethod_6("3115");
		}
		else if (byte_10 == 26)
		{
			result = GClass121.smethod_6("3116");
		}
		else if (byte_10 == 27)
		{
			result = GClass121.smethod_6("3117");
		}
		else if (byte_10 == 28)
		{
			result = GClass121.smethod_6("3118");
		}
		else if (byte_10 == 29)
		{
			result = GClass121.smethod_6("3119");
		}
		else if (byte_10 == 30)
		{
			result = GClass121.smethod_6("3120");
		}
		else if (byte_10 == 31)
		{
			result = GClass121.smethod_6("3121");
		}
		else if (byte_10 == 33)
		{
			result = GClass121.smethod_6("3122");
		}
		else if (byte_10 == 34)
		{
			result = GClass121.smethod_6("3123");
		}
		else if (byte_10 == 35)
		{
			result = GClass121.smethod_6("3124");
		}
		else if (byte_10 == 36)
		{
			result = GClass121.smethod_6("3125");
		}
		else if (byte_10 == 37)
		{
			result = GClass121.smethod_6("3126");
		}
		else if (byte_10 == 38)
		{
			result = GClass121.smethod_6("3127");
		}
		else if (byte_10 == 39)
		{
			result = GClass121.smethod_6("3128");
		}
		else if (byte_10 == 40)
		{
			result = GClass121.smethod_6("3129");
		}
		else if (byte_10 == 41)
		{
			result = GClass121.smethod_6("3130");
		}
		else if (byte_10 == 42)
		{
			result = GClass121.smethod_6("3131");
		}
		else if (byte_10 == 43)
		{
			result = GClass121.smethod_6("3132");
		}
		else if (byte_10 == 44)
		{
			result = GClass121.smethod_6("3133");
		}
		else if (byte_10 == 45)
		{
			result = GClass121.smethod_6("3134");
		}
		else if (byte_10 == 47)
		{
			result = GClass121.smethod_6("3135");
		}
		else if (byte_10 == 49)
		{
			result = GClass121.smethod_6("3136");
		}
		else if (byte_10 == 50)
		{
			result = GClass121.smethod_6("3137");
		}
		else if (byte_10 == 51)
		{
			result = GClass121.smethod_6("3138");
		}
		else if (byte_10 == 52)
		{
			result = GClass121.smethod_6("3139");
		}
		else if (byte_10 == 53)
		{
			result = GClass121.smethod_6("3140");
		}
		else if (byte_10 == 54)
		{
			result = GClass121.smethod_6("3141");
		}
		else if (byte_10 == 55)
		{
			result = GClass121.smethod_6("3142");
		}
		else if (byte_10 == 56)
		{
			result = GClass121.smethod_6("3143");
		}
		else if (byte_10 == 57)
		{
			result = GClass121.smethod_6("3144");
		}
		else if (byte_10 == 58)
		{
			result = GClass121.smethod_6("3145");
		}
		else if (byte_10 == 59)
		{
			result = GClass121.smethod_6("3146");
		}
		else if (byte_10 == 60)
		{
			result = GClass121.smethod_6("3147");
		}
		else if (byte_10 == 65)
		{
			result = GClass121.smethod_6("3148");
		}
		else if (byte_10 == 66)
		{
			result = GClass121.smethod_6("3149");
		}
		else if (byte_10 == 67)
		{
			result = GClass121.smethod_6("3150");
		}
		else if (byte_10 == 68)
		{
			result = GClass121.smethod_6("3151");
		}
		else if (byte_10 == 69)
		{
			result = GClass121.smethod_6("3152");
		}
		else if (byte_10 == 70)
		{
			result = GClass121.smethod_6("3153");
		}
		else if (byte_10 == 71)
		{
			result = GClass121.smethod_6("3154");
		}
		else if (byte_10 == 72)
		{
			result = GClass121.smethod_6("3155");
		}
		else if (byte_10 == 73)
		{
			result = GClass121.smethod_6("3156");
		}
		else if (byte_10 == 74)
		{
			result = GClass121.smethod_6("3157");
		}
		else if (byte_10 == 75)
		{
			result = GClass121.smethod_6("3158");
		}
		else if (byte_10 == 76)
		{
			result = GClass121.smethod_6("3159");
		}
		else if (byte_10 == 77)
		{
			result = GClass121.smethod_6("3160");
		}
		else if (byte_10 == 81)
		{
			result = GClass121.smethod_6("3161");
		}
		else if (byte_10 == 84)
		{
			result = GClass121.smethod_6("3162");
		}
		else if (byte_10 == 85)
		{
			result = GClass121.smethod_6("3163");
		}
		else if (byte_10 == 86)
		{
			result = GClass121.smethod_6("3164");
		}
		else if (byte_10 == 97)
		{
			result = GClass121.smethod_6("3165");
		}
		else if (byte_10 == 98)
		{
			result = GClass121.smethod_6("3166");
		}
		else if (byte_10 == 99)
		{
			result = GClass121.smethod_6("3167");
		}
		else if (byte_10 == 100)
		{
			result = GClass121.smethod_6("3168");
		}
		else if (byte_10 == 101)
		{
			result = GClass121.smethod_6("3169");
		}
		else if (byte_10 == 102)
		{
			result = GClass121.smethod_6("3170");
		}
		else if (byte_10 == 103)
		{
			result = GClass121.smethod_6("3171");
		}
		else if (byte_10 == 104)
		{
			result = GClass121.smethod_6("3172");
		}
		else if (byte_10 == 113)
		{
			result = GClass121.smethod_6("3173");
		}
		else if (byte_10 == 114)
		{
			result = GClass121.smethod_6("3174");
		}
		else if (byte_10 == 115)
		{
			result = GClass121.smethod_6("3175");
		}
		else if (byte_10 == 116)
		{
			result = GClass121.smethod_6("3176");
		}
		else if (byte_10 == 118)
		{
			result = GClass121.smethod_6("3177");
		}
		else if (byte_10 == 119)
		{
			result = GClass121.smethod_6("3178");
		}
		else if (byte_10 == 120)
		{
			result = GClass121.smethod_6("3179");
		}
		else if (byte_10 == 121)
		{
			result = GClass121.smethod_6("3180");
		}
		else if (byte_10 == 122)
		{
			result = GClass121.smethod_6("3181");
		}
		else if (byte_10 == 123)
		{
			result = GClass121.smethod_6("3182");
		}
		else if (byte_10 == 129)
		{
			result = GClass121.smethod_6("3183");
		}
		else if (byte_10 == 130)
		{
			result = GClass121.smethod_6("3184");
		}
		else if (byte_10 == 131)
		{
			result = GClass121.smethod_6("3185");
		}
		else if (byte_10 == 132)
		{
			result = GClass121.smethod_6("3186");
		}
		else if (byte_10 == 133)
		{
			result = GClass121.smethod_6("3187");
		}
		else if (byte_10 == 134)
		{
			result = GClass121.smethod_6("3188");
		}
		else if (byte_10 == 135)
		{
			result = GClass121.smethod_6("3189");
		}
		else if (byte_10 == 136)
		{
			result = GClass121.smethod_6("3190");
		}
		else if (byte_10 == 143)
		{
			result = GClass121.smethod_6("3191");
		}
		else if (byte_10 == 146)
		{
			result = GClass121.smethod_6("3192");
		}
		else if (byte_10 == 147)
		{
			result = GClass121.smethod_6("3193");
		}
		else if (byte_10 == 148)
		{
			result = GClass121.smethod_6("3194");
		}
		else if (byte_10 == 149)
		{
			result = GClass121.smethod_6("3195");
		}
		else if (byte_10 == 150)
		{
			result = GClass121.smethod_6("3196");
		}
		else if (byte_10 == 151)
		{
			result = GClass121.smethod_6("3197");
		}
		else if (byte_10 == 152)
		{
			result = GClass121.smethod_6("3198");
		}
		else if (byte_10 == 154)
		{
			result = GClass121.smethod_6("3199");
		}
		else if (byte_10 == 155)
		{
			result = GClass121.smethod_6("3200");
		}
		else if (byte_10 == 156)
		{
			result = GClass121.smethod_6("3201");
		}
		else if (byte_10 == 157)
		{
			result = GClass121.smethod_6("3202");
		}
		else if (byte_10 == 159)
		{
			result = GClass121.smethod_6("3203");
		}
		else if (byte_10 == 194)
		{
			result = GClass121.smethod_6("3204");
		}
		return result;
	}

	// Token: 0x06000167 RID: 359 RVA: 0x00006F88 File Offset: 0x00005188
	private string method_46(byte byte_10)
	{
		string result = "";
		if ((byte_10 & 9) == 8)
		{
			result = GClass121.smethod_6("3054");
		}
		else if ((byte_10 & 1) == 1)
		{
			result = GClass121.smethod_6("3062");
		}
		return result;
	}

	// Token: 0x06000168 RID: 360 RVA: 0x00006FC4 File Offset: 0x000051C4
	private string method_47(byte byte_10)
	{
		string result = "";
		if ((byte_10 & 128) != 0)
		{
			result = GClass121.smethod_6("3051");
		}
		return result;
	}

	// Token: 0x06000169 RID: 361 RVA: 0x00025118 File Offset: 0x00023318
	private List<GClass102> method_48()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_3;
		}
		else
		{
			array = this.method_54(this.byte_7);
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
			gclass.string_5 = this.method_49(gclass.byte_0);
			gclass.string_6 = this.method_50(gclass.byte_0);
			gclass.string_7 = this.method_51(gclass.byte_0);
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

	// Token: 0x0600016A RID: 362 RVA: 0x00009148 File Offset: 0x00007348
	private string method_49(byte byte_10)
	{
		string result = "";
		if ((byte_10 & 8) != 0)
		{
			result = GClass121.smethod_6("3056");
		}
		else if ((byte_10 & 4) != 0)
		{
			result = GClass121.smethod_6("3057");
		}
		else if ((byte_10 & 2) != 0)
		{
			result = GClass121.smethod_6("3058");
		}
		else if ((byte_10 & 1) != 0)
		{
			result = GClass121.smethod_6("3059");
		}
		return result;
	}

	// Token: 0x0600016B RID: 363 RVA: 0x000091A4 File Offset: 0x000073A4
	private string method_50(byte byte_10)
	{
		string result = "";
		if ((byte_10 & 96) == 0)
		{
			result = GClass121.smethod_6("3052");
		}
		else if ((byte_10 & 96) == 32)
		{
			result = GClass121.smethod_6("3053");
		}
		else if ((byte_10 & 96) == 64)
		{
			result = GClass121.smethod_6("3054");
		}
		else if ((byte_10 & 96) == 96)
		{
			result = GClass121.smethod_6("3055");
		}
		return result;
	}

	// Token: 0x0600016C RID: 364 RVA: 0x00006FC4 File Offset: 0x000051C4
	private string method_51(byte byte_10)
	{
		string result = "";
		if ((byte_10 & 128) != 0)
		{
			result = GClass121.smethod_6("3051");
		}
		return result;
	}

	// Token: 0x0600016D RID: 365 RVA: 0x00002F0A File Offset: 0x0000110A
	public override void r2()
	{
	}

	// Token: 0x0600016E RID: 366 RVA: 0x00002F0A File Offset: 0x0000110A
	public override void r7(List<GClass102> list_6, List<GClass104> list_7)
	{
	}

	// Token: 0x0600016F RID: 367 RVA: 0x00002F0A File Offset: 0x0000110A
	protected override void r3(GClass104 gclass104_1)
	{
	}

	// Token: 0x06000170 RID: 368 RVA: 0x00025490 File Offset: 0x00023690
	public override string vmethod_0(byte[] byte_10, string string_22, int int_5, int int_6, string[] string_23, string string_24)
	{
		byte[] byte_11 = this.method_54(byte_10);
		if (string_22 == "raw")
		{
			return GClass127.smethod_11(byte_11);
		}
		return this.r4(byte_11, string_22, int_5, int_6, string_23, string_24);
	}

	// Token: 0x06000171 RID: 369 RVA: 0x000254C8 File Offset: 0x000236C8
	private byte[] method_52(byte[] byte_10)
	{
		if (this.serialPort_0 != null && this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		List<byte> list = new List<byte>();
		if (byte_10.Length < 2)
		{
			return new byte[0];
		}
		List<byte[]> list2 = new List<byte[]>();
		if (byte_10.Length < 9)
		{
			if (this.string_1 == "CCAN29")
			{
				list2.Add(new byte[byte_10.Length - 1]);
				for (int i = 0; i < byte_10.Length - 1; i++)
				{
					list2[0][i] = byte_10[i + 1];
				}
			}
			else
			{
				list2.Add(new byte[byte_10.Length]);
				for (int j = 0; j < byte_10.Length; j++)
				{
					list2[0][j] = byte_10[j];
				}
			}
		}
		else
		{
			list2.Add(new byte[8]);
			list2[0][0] = 16;
			int num = 0;
			int num2 = 1;
			while (num2 < list2[0].Length && num < byte_10.Length)
			{
				list2[0][num2] = byte_10[num];
				num++;
				num2++;
			}
			byte b = 33;
			while (num < byte_10.Length && b < 47)
			{
				list2.Add(new byte[(byte_10.Length - num > 7) ? 8 : (byte_10.Length - num + 1)]);
				int index = list2.Count - 1;
				list2[index][0] = b;
				b += 1;
				int num3 = 1;
				while (num3 < list2[index].Length && num < byte_10.Length)
				{
					list2[index][num3] = byte_10[num];
					num++;
					num3++;
				}
			}
		}
		if (list2.Count > 1)
		{
			this.ra("ATCAF0");
			this.ra("ATST03");
		}
		this.r9(GClass127.smethod_11(list2[0]));
		this.int_0 = GClass126.smethod_1();
		if (list2.Count > 1)
		{
			GClass126.smethod_2("Waiting FC...", 0);
			string text = this.rb();
			if (text.Contains("NO DATA") || text.Contains("ERROR") || text.Contains("?") || !text.StartsWith("30"))
			{
				this.ra("ATST99");
				return new byte[0];
			}
			for (int k = 1; k < list2.Count; k++)
			{
				if (k == list2.Count - 1)
				{
					this.ra("ATSTF0");
				}
				this.r9(GClass127.smethod_11(list2[k]));
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
			this.ra("ATCAF1");
		}
		if (!text2.Contains("NO DATA") && !text2.Contains("ERROR") && !text2.Contains("?"))
		{
			int num4;
			while (text2.StartsWith("7F2278") || text2.StartsWith("7F1978") || text2.StartsWith("7F1478") || text2.StartsWith("7F2E78") || text2.StartsWith("7F2F78") || text2.StartsWith("7F1078") || text2.StartsWith("037F2278") || text2.StartsWith("037F1978") || text2.StartsWith("037F1478") || text2.StartsWith("037F2E78") || text2.StartsWith("037F2F78") || text2.StartsWith("037F1078"))
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
			if (text3.Length == 3 && text3[0] == '0')
			{
				byte item = 0;
				try
				{
					item = GClass127.smethod_32(text3.Substring(1))[0];
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

	// Token: 0x06000172 RID: 370 RVA: 0x00025ADC File Offset: 0x00023CDC
	private byte[] method_53(byte[] byte_10)
	{
		if (GClass125.smethod_44() != 4)
		{
			if (GClass125.smethod_44() != 5)
			{
				if (this.serialPort_0 != null && this.serialPort_0.BytesToRead > 0)
				{
					this.serialPort_0.ReadExisting();
				}
				List<byte> list = new List<byte>();
				if (byte_10.Length < 2)
				{
					return new byte[0];
				}
				List<byte[]> list2 = new List<byte[]>();
				if (byte_10.Length < 9)
				{
					list2.Add(new byte[byte_10.Length - 1]);
					for (int i = 0; i < byte_10.Length - 1; i++)
					{
						list2[0][i] = byte_10[i + 1];
					}
				}
				else
				{
					list2.Add(new byte[8]);
					list2[0][0] = 16;
					int num = byte_10.Length - 1;
					if (num > 255)
					{
						num -= 256;
						list2[0][0] = 17;
						byte_10[0] = (byte)num;
					}
					int j = 0;
					int num2 = 1;
					while (num2 < list2[0].Length && j < byte_10.Length)
					{
						list2[0][num2] = byte_10[j];
						j++;
						num2++;
					}
					byte b = 33;
					while (j < byte_10.Length)
					{
						list2.Add(new byte[(byte_10.Length - j > 7) ? 8 : (byte_10.Length - j + 1)]);
						int index = list2.Count - 1;
						list2[index][0] = b;
						b += 1;
						if (b > 47)
						{
							b = 32;
						}
						int num3 = 1;
						while (num3 < list2[index].Length && j < byte_10.Length)
						{
							list2[index][num3] = byte_10[j];
							j++;
							num3++;
						}
					}
				}
				if (list2.Count > 1)
				{
					if (GClass125.smethod_49())
					{
						this.ra("ATCAF0");
						this.ra("ATAT0");
						this.ra("ATST20");
						this.r9(GClass127.smethod_11(list2[0]) + " 1");
					}
					else
					{
						this.ra("ATCAF0");
						this.ra("ATAT0");
						this.ra("ATST10");
						this.r9(GClass127.smethod_11(list2[0]));
					}
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
						if (GClass125.smethod_49())
						{
							this.ra("ATGR05");
						}
						else
						{
							this.ra("ATCAF1");
							this.ra("ATAT1");
						}
						this.ra("ATST99");
						return new byte[0];
					}
					if (list2.Count > 1 && GClass125.smethod_49())
					{
						this.ra("ATST03");
					}
					for (int k = 1; k < list2.Count; k++)
					{
						if (k == list2.Count - 1)
						{
							this.ra("ATSTFE");
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
						this.ra("ATAT1");
					}
				}
				if (!text2.Contains("NO DATA") && !text2.Contains("ERROR") && !text2.Contains("BUFFER") && !text2.Contains("WRONG") && !text2.Contains("?"))
				{
					int num4;
					while (text2.StartsWith("7F2278") || text2.StartsWith("7F1978") || text2.StartsWith("7F1478") || text2.StartsWith("7F2E78") || text2.StartsWith("7F2F78") || text2.StartsWith("7F1078") || text2.StartsWith("037F2278") || text2.StartsWith("037F1978") || text2.StartsWith("037F1478") || text2.StartsWith("037F2E78") || text2.StartsWith("037F2F78") || text2.StartsWith("037F1078"))
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
						if (array2.Length == 0)
						{
							return new byte[0];
						}
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
				if (!this.bool_0)
				{
					if (text2.Contains("WRONG"))
					{
						this.string_8 = "WRONG PINS";
					}
					else
					{
						this.string_9 = text2.Replace("\r", "").Replace("\n", "").Replace(">", "");
					}
				}
				return new byte[0];
			}
		}
		return this.method_52(byte_10);
	}

	// Token: 0x06000173 RID: 371 RVA: 0x00026294 File Offset: 0x00024494
	protected byte[] method_54(byte[] byte_10)
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
			byte[] array = this.method_53(byte_10);
			if (byte_10.Length > 1)
			{
				if (((byte_10[1] == 20 || byte_10[1] == 25 || byte_10[1] == 34 || byte_10[1] == 255) && array.Length == 0) || (array.Length > 3 && array[1] == 127 && array[3] == 33))
				{
					Thread.Sleep(100);
					if (GClass125.smethod_49() || GClass125.smethod_44() == 2 || GClass125.smethod_44() == 3 || GClass125.smethod_44() == 11 || GClass125.smethod_44() == 9 || GClass125.smethod_44() == 7 || GClass125.smethod_44() == 12 || GClass125.smethod_44() == 15)
					{
						this.ra("ATSTF0");
					}
					array = this.method_53(byte_10);
				}
				if ((byte_10[1] == 20 || byte_10[1] == 25 || byte_10[1] == 34) && array.Length == 0)
				{
					Thread.Sleep(100);
					array = this.method_53(byte_10);
				}
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
				try
				{
					if (this.serialPort_0 != null)
					{
						this.serialPort_0.WriteLine("");
						int readTimeout = this.serialPort_0.ReadTimeout;
						this.serialPort_0.ReadTimeout = 100;
						try
						{
							this.rb();
							this.rb();
						}
						catch (Exception)
						{
						}
						this.serialPort_0.ReadTimeout = readTimeout;
					}
				}
				catch (Exception)
				{
				}
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

	// Token: 0x06000174 RID: 372 RVA: 0x00021050 File Offset: 0x0001F250
	public override string r4(byte[] byte_10, string string_22, int int_5, int int_6, string[] string_23, string string_24)
	{
		string result = "";
		int_5 += 3;
		if (byte_10.Length <= int_5)
		{
			return result;
		}
		if (byte_10[1] == 127 && string_22 != "hex3")
		{
			return result;
		}
		int num = byte_10.Length - int_5;
		if (int_6 < num)
		{
			num = int_6;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_10[i + int_5];
		}
		return base.method_33(array, string_22, string_23, string_24);
	}

	// Token: 0x06000175 RID: 373 RVA: 0x000264B8 File Offset: 0x000246B8
	protected GClass40()
	{
		byte[] array = new byte[4];
		array[0] = 3;
		array[1] = 23;
		this.byte_9 = array;
		this.char_1 = new char[]
		{
			'\r',
			'\n',
			' '
		};
		base..ctor();
	}

	// Token: 0x04000112 RID: 274
	protected byte[] byte_3 = new byte[]
	{
		7,
		89,
		2,
		207,
		129,
		16,
		21,
		14,
		6,
		138,
		104,
		9
	};

	// Token: 0x04000113 RID: 275
	protected byte[] byte_4 = new byte[]
	{
		3,
		25,
		2,
		13
	};

	// Token: 0x04000114 RID: 276
	protected byte[] byte_5 = new byte[]
	{
		4,
		20,
		byte.MaxValue,
		byte.MaxValue,
		byte.MaxValue
	};

	// Token: 0x04000115 RID: 277
	protected byte[] byte_6 = new byte[]
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

	// Token: 0x04000116 RID: 278
	protected byte[] byte_7 = new byte[]
	{
		4,
		24,
		0,
		byte.MaxValue,
		0
	};

	// Token: 0x04000117 RID: 279
	protected byte[] byte_8 = new byte[]
	{
		3,
		20,
		byte.MaxValue,
		0
	};

	// Token: 0x04000118 RID: 280
	protected byte[] byte_9;

	// Token: 0x04000119 RID: 281
	private char[] char_1;
}
