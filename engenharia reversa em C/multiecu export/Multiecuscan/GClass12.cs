using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

// Token: 0x02000014 RID: 20
public abstract class GClass12 : GClass11
{
	// Token: 0x06000111 RID: 273 RVA: 0x000196FC File Offset: 0x000178FC
	public override void vmethod_1()
	{
		try
		{
			GClass126.smethod_2("-----------------------", 0);
			GClass126.smethod_2("Control module (CAN11): " + GClass127.smethod_23(this.byte_0), 0);
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
				this.method_51();
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
				Thread thread = new Thread(new ThreadStart(this.method_55));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_54))
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
					byte[] value = this.method_46(gclass.byte_0[0]);
					gclass.method_1(this.r4(value, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					sortedList.Add(GClass127.smethod_11(gclass.byte_0[0]), value);
				}
				if (gclass.int_2 == 10455)
				{
					this.string_7 = gclass.method_0();
					GClass126.smethod_2("ECU ISO Code: " + gclass.method_0(), 0);
				}
			}
			if (this.genum0_0 == (GEnum0)3)
			{
				Thread.Sleep(200);
				byte[] byte_ = this.method_46(this.gclass104_0.byte_0[0]);
				this.string_10 = GClass127.smethod_11(byte_);
				this.method_46(GClass127.smethod_32("02 21 2A"));
				this.method_46(GClass127.smethod_32("02 21 AA"));
				this.method_46(GClass127.smethod_32("02 21 2D"));
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
			else if (GClass126.bool_13 && GClass123.int_5 == 500 && GClass126.smethod_1() > 38125)
			{
				GClass126.smethod_2(">Start 35", 0);
				this.string_8 = "Data file corrupted!";
				base.method_30(false);
			}
			else
			{
				if (GClass123.bool_13 && GClass126.bool_13 && GClass123.int_6 == 0)
				{
					bool flag = true;
					if (GClass125.smethod_5().StartsWith(GClass122.smethod_2()))
					{
						GClass126.bool_13 = false;
					}
					else if (GClass125.int_18[4] == 4)
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

	// Token: 0x06000112 RID: 274 RVA: 0x00019AEC File Offset: 0x00017CEC
	private void method_45(GClass104 gclass104_1)
	{
		byte[] array = this.method_46(gclass104_1.byte_0[0]);
		if (array.Length < 4)
		{
			string text = "";
			base.method_28(false, GClass121.smethod_6("6052"), text);
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
				if (gclass104_1.string_2.Contains("RWUSERENTRYH"))
				{
					b3 = byte.MaxValue;
				}
				b3 ^= byte.MaxValue;
				b &= b3;
				b |= b2;
			}
			gclass104_1.byte_0[1][i] = b;
		}
		Thread.Sleep(1000);
		array = this.method_46(gclass104_1.byte_0[1]);
		if (array.Length != 0)
		{
			if (array.Length <= 1 || array[1] != 127)
			{
				int num = 5;
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
				bool flag = gclass104_1.string_2.Contains("EXECANY");
				for (int j = 2; j < gclass104_1.byte_0.Length; j++)
				{
					array = this.method_46(gclass104_1.byte_0[j]);
					if (!flag)
					{
						if (array.Length != 0)
						{
							if (array.Length <= 1 || array[1] != 127)
							{
								goto IL_1CA;
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
						base.method_28(false, GClass121.smethod_6("6052"), text2);
						return;
					}
					IL_1CA:
					if (j < gclass104_1.byte_0.Length - 1 || gclass104_1.byte_0.Length == 1)
					{
						for (int k = 0; k < num; k++)
						{
							Thread.Sleep(100);
						}
					}
				}
				Thread.Sleep(600);
				base.method_28(false, GClass121.smethod_6("6051"), "");
				return;
			}
		}
		string text3 = "";
		if (array.Length > 3 && array[3] == 34)
		{
			text3 = GClass121.smethod_6("6053");
		}
		else if (array.Length > 3 && array[3] == 17)
		{
			text3 = GClass121.smethod_6("6054");
		}
		base.method_28(false, GClass121.smethod_6("6052"), text3);
	}

	// Token: 0x06000113 RID: 275 RVA: 0x00019DC4 File Offset: 0x00017FC4
	protected byte[] method_46(byte[] byte_8)
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
			byte[] array = this.r8(byte_8);
			if (array.Length == 0 || (array.Length > 3 && array[1] == 127 && array[3] == 33))
			{
				Thread.Sleep(100);
				array = this.r8(byte_8);
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
					this.string_8 = "DE";
					GClass126.smethod_2("Terminate 5", 1);
					base.method_30(true);
				}
			}
			this.bool_2 = false;
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x06000114 RID: 276 RVA: 0x00019EBC File Offset: 0x000180BC
	public override string r4(byte[] byte_8, string string_42, int int_6, int int_7, string[] string_43, string string_44)
	{
		string result = "";
		int_6 += 2;
		if (byte_8.Length <= int_6)
		{
			return result;
		}
		if (byte_8[1] == 127 && string_42 != "hex3")
		{
			return result;
		}
		int num = byte_8.Length - int_6;
		if (int_7 < num)
		{
			num = int_7;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_8[i + int_6];
		}
		return base.method_33(array, string_42, string_43, string_44);
	}

	// Token: 0x06000115 RID: 277 RVA: 0x00006FC4 File Offset: 0x000051C4
	private string method_47(byte byte_8)
	{
		string result = "";
		if ((byte_8 & 128) != 0)
		{
			result = GClass121.smethod_6("3051");
		}
		return result;
	}

	// Token: 0x06000116 RID: 278 RVA: 0x00019F2C File Offset: 0x0001812C
	private void method_48(GClass104 gclass104_1)
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
		bool flag3 = gclass104_1.string_2.Contains("LASTCMDBITRESULT");
		if (gclass104_1.string_2.Contains("NOKEEPALIVE"))
		{
			this.bool_3 = true;
		}
		string a = "";
		string a2 = "";
		for (int i = 0; i < gclass104_1.byte_0.Length; i++)
		{
			if (gclass104_1.byte_0[i][0] == 255)
			{
				int num2 = 10 * (256 * (int)gclass104_1.byte_0[i][1] + (int)gclass104_1.byte_0[i][2]);
				for (int j = 0; j < num2; j++)
				{
					if (GClass126.bool_25)
					{
						break;
					}
					Thread.Sleep(100);
				}
			}
			else if (gclass104_1.byte_0[i][0] == 254)
			{
				int num3 = (int)gclass104_1.byte_0[i][2];
				int num4 = (int)gclass104_1.byte_0[i][1];
				string text = gclass104_1.string_5[num3].Substring(4);
				if (num4 == 0)
				{
					base.method_26(text);
				}
				else if (num4 == 1)
				{
					base.method_26(text);
					GClass126.bool_24 = false;
					for (int k = 0; k < 600; k++)
					{
						if (GClass126.bool_25 && flag2)
						{
							GClass126.smethod_2(GClass121.smethod_6("6081"), 2);
							this.method_46(gclass104_1.byte_0[gclass104_1.byte_0.Length - 1]);
							base.method_28(false, GClass121.smethod_6("6082"), " ");
							return;
						}
						if (GClass126.bool_24)
						{
							break;
						}
						Thread.Sleep(100);
					}
				}
			}
			else
			{
				byte[] array = this.method_46(gclass104_1.byte_0[i]);
				if (a == "" && (array.Length == 0 || (array.Length > 1 && array[1] == 127)))
				{
					if (array.Length < 4)
					{
						a = "";
					}
					else if (array[3] == 34)
					{
						a = GClass121.smethod_6("6053");
					}
					else if (array[3] == 17)
					{
						a = GClass121.smethod_6("6054");
					}
					else if (array[3] == 49)
					{
						a = GClass121.smethod_6("6507");
					}
					else if (array[3] == 120)
					{
						a = GClass121.smethod_6("6502");
					}
					else if (array[3] == 16)
					{
						a = GClass121.smethod_6("6503");
					}
					else if (array[3] == 18)
					{
						a = GClass121.smethod_6("6504");
					}
					else if (array[3] == 33)
					{
						a = GClass121.smethod_6("6505");
					}
					else if (array[3] == 36)
					{
						a = "Incorrect sequence";
					}
					else if (array[3] == 129)
					{
						a = "RPM too high";
					}
					else if (array[3] == 130)
					{
						a = "RPM too low";
					}
					else if (array[3] == 131)
					{
						a = "Engine running";
					}
					else if (array[3] == 132)
					{
						a = "Engine not running";
					}
					else if (array[3] == 133)
					{
						a = "Engine run time not enough";
					}
					else if (array[3] == 134)
					{
						a = "Temperature too high";
					}
					else if (array[3] == 135)
					{
						a = "Temperature too low";
					}
					else if (array[3] == 136)
					{
						a = "Vehicle speed too high";
					}
					else if (array[3] == 137)
					{
						a = "Vehicle speed too low";
					}
					else if (array[3] == 138)
					{
						a = "Throttle/pedal too high";
					}
					else if (array[3] == 139)
					{
						a = "Throttle/pedal too low";
					}
					else if (array[3] == 140)
					{
						a = "Transmission in Neutral";
					}
					else if (array[3] == 141)
					{
						a = "Transmission in gear";
					}
					else if (array[3] == 143)
					{
						a = "Brake pedal";
					}
					else if (array[3] == 144)
					{
						a = "Transmission not in Park";
					}
					else if (array[3] == 145)
					{
						a = "Torque converter locked";
					}
					else if (array[3] == 146)
					{
						a = "Voltage too high";
					}
					else if (array[3] == 147)
					{
						a = "Voltage too low";
					}
					else
					{
						a = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
					}
					if (!flag)
					{
						base.method_28(false, GClass121.smethod_6("6052"), a);
						this.bool_3 = false;
						return;
					}
				}
				if (i < gclass104_1.byte_0.Length - 1 || gclass104_1.byte_0.Length == 1)
				{
					for (int l = 0; l < num; l++)
					{
						if (GClass126.bool_25 && flag2)
						{
							GClass126.smethod_2(GClass121.smethod_6("6081"), 2);
							array = this.method_46(gclass104_1.byte_0[gclass104_1.byte_0.Length - 1]);
							base.method_28(false, GClass121.smethod_6("6082"), " ");
							this.bool_3 = false;
							return;
						}
						Thread.Sleep(100);
					}
				}
				if (i == gclass104_1.byte_0.Length - 1 && flag3)
				{
					a2 = GClass121.smethod_6("6056");
					if (array.Length > 2 + gclass104_1.int_0 && gclass104_1.string_5.Length != 0)
					{
						byte b = array[3 + gclass104_1.int_0];
						int m = 0;
						while (m < gclass104_1.string_5.Length)
						{
							byte b2 = byte.Parse(gclass104_1.string_5[m].Substring(0, 2), NumberStyles.HexNumber);
							byte b3 = byte.Parse(gclass104_1.string_5[m].Substring(2, 2), NumberStyles.HexNumber);
							if ((b & b2) != b3)
							{
								if (m != gclass104_1.string_5.Length - 1)
								{
									m++;
									continue;
								}
							}
							a2 = gclass104_1.string_5[m].Substring(4);
							break;
						}
					}
				}
			}
		}
		this.bool_3 = false;
		if (a2 != "")
		{
			base.method_28(false, GClass121.smethod_6("6051"), a2);
			return;
		}
		if (a == "" || flag)
		{
			base.method_28(false, GClass121.smethod_6("6051"), a);
			return;
		}
		base.method_28(false, GClass121.smethod_6("6052"), a);
	}

	// Token: 0x06000117 RID: 279 RVA: 0x0001A628 File Offset: 0x00018828
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
			if (gclass104_1.string_2.Contains("FUNC"))
			{
				this.method_53(gclass104_1);
				return;
			}
			if (gclass104_1.string_2.Contains("RWANDXOR"))
			{
				this.method_49(gclass104_1);
				return;
			}
			if (gclass104_1.string_2.Contains("RWUSERENTRY"))
			{
				this.method_45(gclass104_1);
				return;
			}
			this.method_48(gclass104_1);
			return;
		}
	}

	// Token: 0x06000118 RID: 280 RVA: 0x0001A6FC File Offset: 0x000188FC
	public override string vmethod_0(byte[] byte_8, string string_42, int int_6, int int_7, string[] string_43, string string_44)
	{
		byte[] byte_9 = this.method_46(byte_8);
		if (string_42 == "raw")
		{
			return GClass127.smethod_11(byte_9);
		}
		return this.r4(byte_9, string_42, int_6, int_7, string_43, string_44);
	}

	// Token: 0x06000119 RID: 281 RVA: 0x0001A734 File Offset: 0x00018934
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
			array = this.method_46(this.byte_6);
		}
		if (array.Length < 3)
		{
			GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
			GClass126.smethod_2("Force KA", 1);
			this.int_0 -= this.int_5;
			if (!this.bool_1)
			{
				Thread.Sleep(200);
			}
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
			gclass.string_5 = this.method_52(gclass.byte_0);
			gclass.string_6 = this.method_50(gclass.byte_0);
			gclass.string_7 = this.method_47(gclass.byte_0);
			gclass.bool_0 = ((gclass.byte_0 & 96) == 96);
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

	// Token: 0x0600011A RID: 282 RVA: 0x0001AAE0 File Offset: 0x00018CE0
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
		byte[] array = this.method_46(this.byte_7);
		if (array.Length < 3 || array[1] != 84)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x0600011B RID: 283 RVA: 0x0001AB34 File Offset: 0x00018D34
	private void method_49(GClass104 gclass104_1)
	{
		byte[] array = this.method_46(gclass104_1.byte_0[0]);
		if (array.Length < 4)
		{
			string text = "";
			base.method_28(false, GClass121.smethod_6("6052"), text);
			return;
		}
		byte b = array[3];
		byte b2 = byte.Parse(gclass104_1.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
		byte b3 = byte.Parse(gclass104_1.string_5[0].Substring(2, 2), NumberStyles.HexNumber);
		b &= b2;
		b ^= b3;
		Thread.Sleep(1000);
		gclass104_1.byte_0[1][3] = b;
		array = this.method_46(gclass104_1.byte_0[1]);
		if (array.Length != 0)
		{
			if (array.Length <= 1 || array[1] != 127)
			{
				Thread.Sleep(1000);
				base.method_28(false, GClass121.smethod_6("6051"), "");
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
		base.method_28(false, GClass121.smethod_6("6052"), text2);
	}

	// Token: 0x0600011C RID: 284 RVA: 0x000091A4 File Offset: 0x000073A4
	private string method_50(byte byte_8)
	{
		string result = "";
		if ((byte_8 & 96) == 0)
		{
			result = GClass121.smethod_6("3052");
		}
		else if ((byte_8 & 96) == 32)
		{
			result = GClass121.smethod_6("3053");
		}
		else if ((byte_8 & 96) == 64)
		{
			result = GClass121.smethod_6("3054");
		}
		else if ((byte_8 & 96) == 96)
		{
			result = GClass121.smethod_6("3055");
		}
		return result;
	}

	// Token: 0x0600011D RID: 285 RVA: 0x0001AC5C File Offset: 0x00018E5C
	protected virtual byte[] r5(byte[] byte_8)
	{
		if (this.serialPort_0 != null && this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		List<byte> list = new List<byte>();
		if (byte_8.Length < 2)
		{
			return new byte[0];
		}
		List<byte[]> list2 = new List<byte[]>();
		list2.Add(new byte[byte_8.Length - 1]);
		for (int i = 1; i < byte_8.Length; i++)
		{
			list2[0][i - 1] = byte_8[i];
		}
		this.r9(GClass127.smethod_11(list2[0]));
		this.int_0 = GClass126.smethod_1();
		string text = this.rb();
		if (this.int_4 != 0 && text.Contains(this.string_25))
		{
			this.r9(GClass127.smethod_23(this.byte_0) + this.string_29);
			text = this.rb();
			if (this.int_4 != 0 && text.Contains(this.string_25))
			{
				this.r9(GClass127.smethod_23(this.byte_0) + this.string_29);
				text = this.rb();
			}
		}
		if (!text.Contains("NO DATA") && !text.Contains("ERROR") && !text.Contains("?"))
		{
			int num;
			while (text.StartsWith("7F2178") || text.StartsWith("7F1478") || text.StartsWith("7F1878") || text.StartsWith("7F1A78") || text.StartsWith("7F3B78") || text.StartsWith("7F3078"))
			{
				num = 0;
				while (num < text.Length && text[num] != '\r' && text[num] != '\n')
				{
					if (text[num] == '>')
					{
						break;
					}
					num++;
				}
				text = text.Substring(num + 1);
			}
			num = 0;
			while (num < text.Length && text[num] != '\r' && text[num] != '\n')
			{
				if (text[num] == '>')
				{
					break;
				}
				num++;
			}
			string text2 = text.Substring(0, num).Trim();
			text = text.Substring(num + 1);
			if (text2.Length == 3 && text2[0] == '0')
			{
				byte item = 0;
				try
				{
					item = GClass127.smethod_32(text2.Substring(1))[0];
				}
				catch (Exception)
				{
				}
				list.Add(item);
				while (text.Length > 2)
				{
					if (text[1] != ':')
					{
						break;
					}
					num = 0;
					while (num < text.Length && text[num] != '\r' && text[num] != '\n')
					{
						if (text[num] == '>')
						{
							break;
						}
						num++;
					}
					if (num > 2)
					{
						text2 = text.Substring(2, num - 2);
						byte[] array = GClass127.smethod_32(text2);
						for (int j = 0; j < array.Length; j++)
						{
							list.Add(array[j]);
						}
					}
					text = text.Substring(num + 1);
				}
			}
			else
			{
				byte[] array2 = GClass127.smethod_32(text2);
				list.Add((byte)array2.Length);
				for (int k = 0; k < array2.Length; k++)
				{
					list.Add(array2[k]);
				}
			}
			GClass126.smethod_2("DECODED RESPONSE: " + GClass127.smethod_11(list.ToArray()), 0);
			byte[] array3 = list.ToArray();
			if (list.Count > 0 && list[0] > 0 && list[0] < 255 && (int)list[0] < list.Count - 1)
			{
				array3 = new byte[(int)(list[0] + 1)];
				for (int l = 0; l <= (int)list[0]; l++)
				{
					array3[l] = list[l];
				}
				GClass126.smethod_2("CLEANED RESPONSE: " + GClass127.smethod_11(array3), 0);
			}
			return array3;
		}
		return new byte[0];
	}

	// Token: 0x0600011E RID: 286 RVA: 0x0001B048 File Offset: 0x00019248
	protected void method_51()
	{
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
			byte[][] array2 = new byte[][]
			{
				GClass127.smethod_32("16 61 A1 05 72 9F DB 05 72 9F DB 01 22 03 4B 00 00 04 00 00 00 00 00 00"),
				GClass127.smethod_32("16 61 A2 05 62 9F DB 00 22 05 09 05 62 9F DB 00 22 05 89 00 22 05 01 00"),
				GClass127.smethod_32("4E 61 23 30 34 31 39 34 30 30 30 33 39 30 4F 55 54 50 55 54 2D 4A 49 54 20 05 05 27 FF 97 32 05 89 05 22 00 C3 00 01 07 B7 00 19 17 00 00 84 06 01 00 01 00 00 00 00 53 40 4B")
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
				if (GClass127.smethod_11(gclass.byte_0[0]) == "02 21 A1")
				{
					text = this.r4(array2[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else if (GClass127.smethod_11(gclass.byte_0[0]) == "02 21 A2")
				{
					text = this.r4(array2[1], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else if (GClass127.smethod_11(gclass.byte_0[0]) == "02 21 23")
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
			new Thread(new ThreadStart(this.method_54))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_36();
			throw new Exception("1");
		}
	}

	// Token: 0x0600011F RID: 287
	protected abstract void r6();

	// Token: 0x06000120 RID: 288 RVA: 0x00009148 File Offset: 0x00007348
	private string method_52(byte byte_8)
	{
		string result = "";
		if ((byte_8 & 8) != 0)
		{
			result = GClass121.smethod_6("3056");
		}
		else if ((byte_8 & 4) != 0)
		{
			result = GClass121.smethod_6("3057");
		}
		else if ((byte_8 & 2) != 0)
		{
			result = GClass121.smethod_6("3058");
		}
		else if ((byte_8 & 1) != 0)
		{
			result = GClass121.smethod_6("3059");
		}
		return result;
	}

	// Token: 0x06000121 RID: 289 RVA: 0x0001B340 File Offset: 0x00019540
	public override void r7(List<GClass102> list_6, List<GClass104> list_7)
	{
		if (list_6 != null && list_7 != null && list_6.Count != 0 && list_7.Count != 0)
		{
			int num = this.string_41.Length;
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
									value = GClass127.smethod_32(this.string_41[num]);
								}
								else if (sortedList.ContainsKey(text))
								{
									value = sortedList[text];
								}
								else
								{
									value = this.method_46(byte_);
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

	// Token: 0x06000122 RID: 290 RVA: 0x0001B5CC File Offset: 0x000197CC
	private void method_53(GClass104 gclass104_1)
	{
		byte[] array = this.method_46(gclass104_1.byte_0[0]);
		if (array.Length > 3 && array[1] == 127 && array[3] != 120)
		{
			string text = "";
			if (array[3] == 34)
			{
				text = GClass121.smethod_6("6053");
			}
			else if (array[3] == 17)
			{
				text = GClass121.smethod_6("6054");
			}
			else if (array[3] == 18)
			{
				text = GClass121.smethod_6("6504");
			}
			else if (array[3] == 49)
			{
				text = GClass121.smethod_6("6507");
			}
			else if (array[3] == 33)
			{
				text = GClass121.smethod_6("6505");
			}
			else if (array[3] > 0)
			{
				text = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
			}
			base.method_28(false, GClass121.smethod_6("6052"), text);
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
		if (gclass104_1.byte_0.Length > 1)
		{
			array3 = GClass127.smethod_32(GClass127.smethod_11(gclass104_1.byte_0[1]));
		}
		if (gclass104_1.byte_0.Length > 2)
		{
			array5 = GClass127.smethod_32(GClass127.smethod_11(gclass104_1.byte_0[2]));
		}
		int num = 1800;
		bool flag = true;
		IL_1EA:
		while (num > 0 && flag)
		{
			for (int i = 0; i < 5; i++)
			{
				if (GClass126.bool_25)
				{
					GClass126.smethod_2("Aborting routine...", 2);
					array = this.method_46(array5);
					num = 0;
					IL_18D:
					GClass126.smethod_2("Checking routine status..", 1);
					array = this.method_46(array3);
					if (array.Length == 0)
					{
						Thread.Sleep(800);
						if (this.bool_1)
						{
							return;
						}
						array = this.method_46(array3);
					}
					if (array.Length <= 3 || array[1] != 127 || array[2] != 51 || (array[3] != 33 && array[3] != 35))
					{
						flag = false;
					}
					num--;
					goto IL_1EA;
				}
				Thread.Sleep(100);
			}
			goto IL_18D;
		}
		string str = GClass121.smethod_6("6056");
		if (gclass104_1.byte_0.Length > 3)
		{
			if (gclass104_1.string_2.Contains("FUNCW"))
			{
				str = this.vmethod_0(gclass104_1.byte_0[3], "bitw", gclass104_1.int_0, gclass104_1.int_1, gclass104_1.string_5, gclass104_1.string_6);
			}
			else
			{
				str = this.vmethod_0(gclass104_1.byte_0[3], "bits", gclass104_1.int_0, gclass104_1.int_1, gclass104_1.string_5, gclass104_1.string_6);
			}
		}
		else if (array.Length > 3 && array[1] == 115)
		{
			if (gclass104_1.string_5.Length != 0 && gclass104_1.string_2.Contains("FUNCW") && array.Length > 4)
			{
				byte b = array[3];
				byte b2 = array[4];
				this.string_10 = GClass127.smethod_23(b) + GClass127.smethod_23(b2);
				str = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b) + GClass127.smethod_23(b2);
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
					str = gclass104_1.string_5[j].Substring(8);
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
				str = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b7);
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
					str = gclass104_1.string_5[k].Substring(4);
					GClass126.smethod_2("DECODED RESULT CODE: " + this.string_10 + " - " + str, 0);
					break;
				}
			}
			else if (array.Length == 4)
			{
				str = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
			}
			else if (array.Length == 5)
			{
				str = string.Concat(new string[]
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
				str = string.Concat(new string[]
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
		base.method_28(true, GClass121.smethod_6("6051"), str);
	}

	// Token: 0x06000123 RID: 291 RVA: 0x0001BBA0 File Offset: 0x00019DA0
	protected virtual byte[] r8(byte[] byte_8)
	{
		if (this.bool_6)
		{
			return this.r5(byte_8);
		}
		if (this.serialPort_0 != null && this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		List<byte[]> list = new List<byte[]>();
		if (byte_8.Length < 8)
		{
			list.Add(new byte[byte_8.Length + 1]);
			list[0][0] = this.byte_0;
			for (int i = 0; i < byte_8.Length; i++)
			{
				list[0][i + 1] = byte_8[i];
			}
		}
		else
		{
			list.Add(new byte[8]);
			list[0][0] = this.byte_0;
			list[0][1] = 16;
			int j = 0;
			int num = 2;
			while (num < list[0].Length && j < byte_8.Length)
			{
				list[0][num] = byte_8[j];
				j++;
				num++;
			}
			byte b = 32;
			while (j < byte_8.Length)
			{
				list.Add(new byte[(byte_8.Length - j > 6) ? 8 : (byte_8.Length - j + 2)]);
				int index = list.Count - 1;
				list[index][0] = this.byte_0;
				list[index][1] = b;
				b += 1;
				if (b > 47)
				{
					b = 32;
				}
				int num2 = 2;
				while (num2 < list[index].Length && j < byte_8.Length)
				{
					list[index][num2] = byte_8[j];
					j++;
					num2++;
				}
			}
		}
		if (list.Count > 1)
		{
			if (this.int_4 != 0)
			{
				if (this.int_4 == 1)
				{
					this.ra(this.string_37);
				}
				else if (this.int_4 == 3)
				{
					this.ra(this.string_35);
				}
				else if (this.int_4 == 4)
				{
					this.ra(this.string_34);
				}
				else
				{
					this.ra(this.string_36);
				}
			}
			this.ra("ATAT0");
		}
		bool flag = false;
		if (list.Count == 1 && GClass125.smethod_49() && list[0].Length == 3 && list[0][1] == 255)
		{
			this.r9("ATGR" + GClass127.smethod_23(list[0][2]));
		}
		else if (list.Count == 1 && GClass125.smethod_49() && list[0].Length == 3 && byte_8[1] == 1 && byte_8[2] == 62)
		{
			this.r9("ATGR07");
		}
		else if (list[0].Length > 2 && (list[0][2] == 33 || list[0][2] == 26 || list[0][2] == 62 || list[0][2] == 24 || list[0][2] == 23))
		{
			this.r9(GClass127.smethod_11(list[0]) + " 1");
		}
		else if (list.Count > 1)
		{
			this.r9(GClass127.smethod_11(list[0]) + " 1");
		}
		else
		{
			flag = true;
			this.r9(GClass127.smethod_11(list[0]));
		}
		this.int_0 = GClass126.smethod_1();
		if (list.Count > 1)
		{
			GClass126.smethod_2(this.string_24, 0);
			string text = this.rb();
			if (!flag && text.Contains(this.string_27))
			{
				flag = true;
				Thread.Sleep(250);
				this.r9(GClass127.smethod_11(list[0]));
				this.int_0 = GClass126.smethod_1();
				text = this.rb();
			}
			if (this.int_4 == 0 && (text.Contains(this.string_25) || text.Contains(this.string_26) || text.Contains(this.string_27) || !text.Contains(this.string_28)))
			{
				return new byte[0];
			}
			int num3 = 0;
			int num4 = 0;
			while (num4 < text.Length && text[num4] != '\r' && text[num4] != '\n')
			{
				if (text[num4] == '>')
				{
					break;
				}
				num4++;
			}
			byte[] array = GClass127.smethod_32(text.Substring(0, num4));
			if (array.Length > 3 && array[1] == 48 && array[3] != 0)
			{
				num3 = (int)(array[3] + 1);
			}
			GClass126.smethod_2("Separation Time: " + num3.ToString(), 0);
			if (this.int_4 != 0)
			{
				this.ra(this.string_33);
			}
			else if (!GClass125.smethod_46())
			{
				this.ra(this.string_35);
			}
			else
			{
				this.ra(this.string_33);
			}
			for (int k = 1; k < list.Count; k++)
			{
				while (this.int_0 + num3 > GClass126.smethod_1())
				{
				}
				if (k == list.Count - 1)
				{
					if (this.int_4 == 0)
					{
						this.ra(this.string_39);
					}
					else
					{
						this.ra(this.string_40);
					}
					this.r9(GClass127.smethod_11(list[k]));
				}
				else if (flag)
				{
					this.r9(GClass127.smethod_11(list[k]));
				}
				else
				{
					this.r9(GClass127.smethod_11(list[k]) + " 0");
				}
				this.int_0 = GClass126.smethod_1();
				if (k < list.Count - 1)
				{
					this.rb();
				}
			}
		}
		string text2 = this.rb();
		if (list.Count == 1 && !flag && text2.Contains(this.string_27))
		{
			Thread.Sleep(250);
			this.r9(GClass127.smethod_11(list[0]));
			this.int_0 = GClass126.smethod_1();
			text2 = this.rb();
		}
		if (list.Count > 1 && this.int_4 != 0 && text2.Contains(this.string_25))
		{
			this.r9(GClass127.smethod_23(this.byte_0) + this.string_29);
			text2 = this.rb();
			if (this.int_4 != 0 && text2.Contains(this.string_25))
			{
				this.r9(GClass127.smethod_23(this.byte_0) + this.string_29);
				text2 = this.rb();
			}
		}
		if (list.Count > 1)
		{
			this.ra(this.string_22);
			this.ra("ATAT1");
		}
		if (!text2.Contains(this.string_25) && !text2.Contains(this.string_26) && !text2.Contains(this.string_27))
		{
			int num5;
			while (text2.StartsWith("F1037F2178") || text2.StartsWith("F1037F1A78") || text2.StartsWith("F1037F1478") || text2.StartsWith("F1037F1878") || text2.StartsWith("F1037F3B78"))
			{
				num5 = 0;
				while (num5 < text2.Length && text2[num5] != '\r' && text2[num5] != '\n')
				{
					if (text2[num5] == '>')
					{
						break;
					}
					num5++;
				}
				text2 = text2.Substring(num5 + 1);
			}
			num5 = 0;
			while (num5 < text2.Length && text2[num5] != '\r' && text2[num5] != '\n')
			{
				if (text2[num5] == '>')
				{
					break;
				}
				num5++;
			}
			byte[] array2 = GClass127.smethod_32(text2.Substring(0, num5));
			if (array2.Length >= 2)
			{
				if (array2[0] == 241)
				{
					List<byte> list2 = new List<byte>();
					if (array2[1] < 16)
					{
						for (int l = 1; l < array2.Length; l++)
						{
							list2.Add(array2[l]);
						}
					}
					else if (array2[1] >= 16 && array2[1] < 32)
					{
						for (int m = 2; m < array2.Length; m++)
						{
							list2.Add(array2[m]);
						}
						this.r9(GClass127.smethod_23(this.byte_0) + this.string_30);
						text2 = this.rb();
						while (text2.StartsWith(this.string_31))
						{
							num5 = 0;
							while (num5 < text2.Length && text2[num5] != '\r' && text2[num5] != '\n')
							{
								if (text2[num5] == '>')
								{
									break;
								}
								num5++;
							}
							string string_ = text2.Substring(0, num5);
							text2 = text2.Substring(num5 + 1);
							array2 = GClass127.smethod_32(string_);
							if (array2.Length > 2 && array2[0] == 241 && array2[1] >= 32)
							{
								for (int n = 2; n < array2.Length; n++)
								{
									list2.Add(array2[n]);
								}
							}
						}
					}
					GClass126.smethod_2(this.string_32 + GClass127.smethod_11(list2.ToArray()), 0);
					byte[] array3 = list2.ToArray();
					if (list2.Count > 0 && list2[0] > 0 && list2[0] < 255 && (int)list2[0] < list2.Count - 1)
					{
						array3 = new byte[(int)(list2[0] + 1)];
						for (int num6 = 0; num6 <= (int)list2[0]; num6++)
						{
							array3[num6] = list2[num6];
						}
						GClass126.smethod_2("CLEANED RESPONSE: " + GClass127.smethod_11(array3), 0);
					}
					return array3;
				}
			}
			return new byte[0];
		}
		if (!this.bool_0)
		{
			this.string_9 = text2.Replace("\r", "").Replace("\n", "").Replace(">", "");
		}
		return new byte[0];
	}

	// Token: 0x06000124 RID: 292 RVA: 0x0001C534 File Offset: 0x0001A734
	private void method_54()
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
									byte[] array3 = this.method_46(gclass.byte_0[0]);
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

	// Token: 0x06000125 RID: 293 RVA: 0x0001CAA4 File Offset: 0x0001ACA4
	private void method_55()
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
				byte[] array = this.method_46(this.byte_3);
				if (!this.bool_3 && (array.Length < 2 || array[1] != 126))
				{
					GClass126.smethod_2("KA response error!", 1);
					if (array.Length == 0)
					{
						array = this.method_46(this.byte_3);
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

	// Token: 0x040000D1 RID: 209
	protected int int_5 = 1000;

	// Token: 0x040000D2 RID: 210
	protected byte[] byte_3 = new byte[]
	{
		1,
		62
	};

	// Token: 0x040000D3 RID: 211
	protected byte[] byte_4 = new byte[]
	{
		2,
		16,
		129
	};

	// Token: 0x040000D4 RID: 212
	protected byte[] byte_5 = new byte[]
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

	// Token: 0x040000D5 RID: 213
	protected byte[] byte_6 = new byte[]
	{
		4,
		24,
		0,
		byte.MaxValue,
		0
	};

	// Token: 0x040000D6 RID: 214
	protected byte[] byte_7 = new byte[]
	{
		3,
		20,
		byte.MaxValue,
		0
	};

	// Token: 0x040000D7 RID: 215
	protected string string_22 = "ATST29";

	// Token: 0x040000D8 RID: 216
	protected string string_23 = "ATST35";

	// Token: 0x040000D9 RID: 217
	protected bool bool_6;

	// Token: 0x040000DA RID: 218
	protected string string_24 = "Waiting FC...";

	// Token: 0x040000DB RID: 219
	protected string string_25 = "NO DATA";

	// Token: 0x040000DC RID: 220
	protected string string_26 = "ERROR";

	// Token: 0x040000DD RID: 221
	protected string string_27 = "?";

	// Token: 0x040000DE RID: 222
	protected string string_28 = "F130";

	// Token: 0x040000DF RID: 223
	protected string string_29 = " 00";

	// Token: 0x040000E0 RID: 224
	protected string string_30 = " 30 FF 00";

	// Token: 0x040000E1 RID: 225
	protected string string_31 = "F1";

	// Token: 0x040000E2 RID: 226
	protected string string_32 = "DECODED RESPONSE: ";

	// Token: 0x040000E3 RID: 227
	protected string string_33 = "ATST01";

	// Token: 0x040000E4 RID: 228
	protected string string_34 = "ATST02";

	// Token: 0x040000E5 RID: 229
	protected string string_35 = "ATST03";

	// Token: 0x040000E6 RID: 230
	protected string string_36 = "ATST05";

	// Token: 0x040000E7 RID: 231
	protected string string_37 = "ATST07";

	// Token: 0x040000E8 RID: 232
	protected string string_38 = "ATST09";

	// Token: 0x040000E9 RID: 233
	protected string string_39 = "ATST99";

	// Token: 0x040000EA RID: 234
	protected string string_40 = "ATSTFF";

	// Token: 0x040000EB RID: 235
	private string[] string_41 = new string[]
	{
		"0C 57 01 01 10 61 24 A7 1D 08 2D FF 40",
		"00 00 00 38 22 99 12 65 29 81 02 00",
		"00 00 00 95 18 24 76 4A 6B 1F 00 00"
	};
}
