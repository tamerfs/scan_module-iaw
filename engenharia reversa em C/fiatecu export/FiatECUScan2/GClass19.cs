using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

// Token: 0x02000021 RID: 33
public abstract class GClass19
{
	// Token: 0x06000157 RID: 343 RVA: 0x000388A4 File Offset: 0x00036AA4
	public static GClass19 smethod_0(string string_7, string string_8, byte byte_2, List<GClass58> list_4, List<GClass58> list_5, string string_9)
	{
		GClass19 gclass = null;
		string text = string.Empty;
		switch (GClass61.smethod_36())
		{
		case 1:
			text = "KL";
			break;
		case 2:
		case 3:
			text = "ELM";
			break;
		case 4:
		case 5:
			text = "OKEY";
			break;
		case 6:
			text = "CTC";
			break;
		case 7:
			text = "OLNK";
			break;
		}
		if (GClass3.bool_2 && text != string.Empty)
		{
			text = "CTC";
		}
		if (!GClass3.bool_2 && text == "CTC")
		{
			text = string.Empty;
		}
		text = text + "_" + string_7;
		string text2 = text;
		switch (text2)
		{
		case "KL_KWP2000Fast":
			gclass = new GClass49(byte_2, list_4, list_5);
			break;
		case "KL_ISO9141":
			gclass = new GClass32(byte_2, list_4, list_5);
			break;
		case "KL_KWP71":
			gclass = new GClass48(byte_2, list_4, list_5);
			break;
		case "KL_KWP01":
			gclass = new GClass51(byte_2, list_4, list_5);
			break;
		case "ELM_KWP2000Fast":
			gclass = new GClass22();
			break;
		case "ELM_ISO9141":
			gclass = null;
			break;
		case "ELM_KWP71":
			gclass = null;
			break;
		case "ELM_KWP01":
			gclass = null;
			break;
		case "ELM_BCAN":
			gclass = new GClass43();
			break;
		case "ELM_BCAN29":
			gclass = new GClass35();
			break;
		case "ELM_CCAN29":
			gclass = new GClass34();
			break;
		case "OKEY_KWP2000Fast":
			gclass = new GClass23();
			break;
		case "OKEY_ISO9141":
			gclass = new GClass29();
			break;
		case "OKEY_KWP71":
			gclass = new GClass26();
			break;
		case "OKEY_KWP01":
			gclass = new GClass51(byte_2, list_4, list_5);
			break;
		case "OKEY_BCAN":
			gclass = new GClass41();
			break;
		case "OKEY_BCAN29":
			gclass = new GClass38();
			break;
		case "OKEY_CCAN29":
			gclass = new GClass39();
			break;
		case "CTC_KWP2000Fast":
			gclass = new GClass21();
			break;
		case "CTC_ISO9141":
			gclass = new GClass30();
			break;
		case "CTC_KWP71":
			gclass = new GClass27();
			break;
		case "CTC_KWP01":
			gclass = new GClass47();
			break;
		case "CTC_BCAN":
			gclass = new GClass44();
			break;
		case "CTC_BCAN29":
			gclass = new GClass36();
			break;
		case "CTC_CCAN29":
			gclass = new GClass37();
			break;
		case "OLNK_KWP2000Fast":
			gclass = new GClass22();
			break;
		case "OLNK_ISO9141":
			gclass = new GClass31();
			break;
		case "OLNK_KWP71":
			gclass = null;
			break;
		case "OLNK_KWP01":
			gclass = null;
			break;
		case "OLNK_BCAN":
			gclass = new GClass42();
			break;
		case "OLNK_BCAN29":
			gclass = new GClass35();
			break;
		case "OLNK_CCAN29":
			gclass = new GClass34();
			break;
		}
		if (gclass != null)
		{
			gclass.byte_0 = byte_2;
			gclass.string_1 = string_8;
			gclass.list_0 = list_5;
			gclass.list_1 = list_4;
			gclass.string_2 = string_9;
		}
		return gclass;
	}

	// Token: 0x06000158 RID: 344 RVA: 0x00002BF1 File Offset: 0x00000DF1
	public bool method_0()
	{
		return this.bool_3;
	}

	// Token: 0x06000159 RID: 345 RVA: 0x00002BF9 File Offset: 0x00000DF9
	public void method_1(bool bool_5)
	{
		this.bool_3 = bool_5;
	}

	// Token: 0x0600015A RID: 346 RVA: 0x00038D0C File Offset: 0x00036F0C
	public int method_2()
	{
		return this.int_3;
	}

	// Token: 0x0600015B RID: 347 RVA: 0x00002C02 File Offset: 0x00000E02
	public void method_3(int int_5)
	{
		this.int_3 = int_5;
	}

	// Token: 0x0600015C RID: 348 RVA: 0x00038D24 File Offset: 0x00036F24
	public string method_4()
	{
		return this.string_3;
	}

	// Token: 0x0600015D RID: 349 RVA: 0x00038D3C File Offset: 0x00036F3C
	public List<GClass64> method_5()
	{
		return this.list_3;
	}

	// Token: 0x0600015E RID: 350 RVA: 0x00038D54 File Offset: 0x00036F54
	public string method_6()
	{
		return this.string_6;
	}

	// Token: 0x0600015F RID: 351 RVA: 0x00038D6C File Offset: 0x00036F6C
	public string method_7()
	{
		return this.string_4;
	}

	// Token: 0x06000160 RID: 352 RVA: 0x00038D84 File Offset: 0x00036F84
	public string method_8()
	{
		return this.string_5;
	}

	// Token: 0x06000161 RID: 353 RVA: 0x00002C0B File Offset: 0x00000E0B
	public bool method_9()
	{
		return this.bool_4;
	}

	// Token: 0x06000162 RID: 354 RVA: 0x00002C13 File Offset: 0x00000E13
	public bool method_10()
	{
		return this.bool_0 && !this.bool_1;
	}

	// Token: 0x06000163 RID: 355 RVA: 0x00002C29 File Offset: 0x00000E29
	public bool method_11()
	{
		return this.bool_2;
	}

	// Token: 0x06000164 RID: 356 RVA: 0x00038D9C File Offset: 0x00036F9C
	public string method_12()
	{
		return this.string_0;
	}

	// Token: 0x06000165 RID: 357 RVA: 0x00002C31 File Offset: 0x00000E31
	public void method_13(string string_7)
	{
		this.string_0 = string_7;
	}

	// Token: 0x06000166 RID: 358 RVA: 0x00002C3A File Offset: 0x00000E3A
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_14(GDelegate4 gdelegate4_1)
	{
		this.gdelegate4_0 = (GDelegate4)Delegate.Combine(this.gdelegate4_0, gdelegate4_1);
	}

	// Token: 0x06000167 RID: 359 RVA: 0x00002C53 File Offset: 0x00000E53
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_15(GDelegate4 gdelegate4_1)
	{
		this.gdelegate4_0 = (GDelegate4)Delegate.Remove(this.gdelegate4_0, gdelegate4_1);
	}

	// Token: 0x06000168 RID: 360 RVA: 0x00002C6C File Offset: 0x00000E6C
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_16(GDelegate3 gdelegate3_1)
	{
		this.gdelegate3_0 = (GDelegate3)Delegate.Combine(this.gdelegate3_0, gdelegate3_1);
	}

	// Token: 0x06000169 RID: 361 RVA: 0x00002C85 File Offset: 0x00000E85
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_17(GDelegate3 gdelegate3_1)
	{
		this.gdelegate3_0 = (GDelegate3)Delegate.Remove(this.gdelegate3_0, gdelegate3_1);
	}

	// Token: 0x0600016A RID: 362 RVA: 0x00002C9E File Offset: 0x00000E9E
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_18(GDelegate5 gdelegate5_2)
	{
		this.gdelegate5_0 = (GDelegate5)Delegate.Combine(this.gdelegate5_0, gdelegate5_2);
	}

	// Token: 0x0600016B RID: 363 RVA: 0x00002CB7 File Offset: 0x00000EB7
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_19(GDelegate5 gdelegate5_2)
	{
		this.gdelegate5_0 = (GDelegate5)Delegate.Remove(this.gdelegate5_0, gdelegate5_2);
	}

	// Token: 0x0600016C RID: 364 RVA: 0x00002CD0 File Offset: 0x00000ED0
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_20(GDelegate5 gdelegate5_2)
	{
		this.gdelegate5_1 = (GDelegate5)Delegate.Combine(this.gdelegate5_1, gdelegate5_2);
	}

	// Token: 0x0600016D RID: 365 RVA: 0x00002CE9 File Offset: 0x00000EE9
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_21(GDelegate5 gdelegate5_2)
	{
		this.gdelegate5_1 = (GDelegate5)Delegate.Remove(this.gdelegate5_1, gdelegate5_2);
	}

	// Token: 0x0600016E RID: 366 RVA: 0x00002D02 File Offset: 0x00000F02
	public void method_22(bool bool_5)
	{
		this.vmethod_2(bool_5, false);
	}

	// Token: 0x0600016F RID: 367 RVA: 0x00038DB4 File Offset: 0x00036FB4
	public void method_23(GClass58 gclass58_1)
	{
		Thread thread = new Thread(new ThreadStart(new GClass19.Class2
		{
			gclass58_0 = gclass58_1,
			gclass19_0 = this
		}.method_0));
		thread.Start();
	}

	// Token: 0x06000170 RID: 368
	public abstract string vmethod_0(byte[] byte_2, string string_7, int int_5, int int_6, string[] string_8, string string_9);

	// Token: 0x06000171 RID: 369
	public abstract void vmethod_1(GEnum0 genum0_0);

	// Token: 0x06000172 RID: 370 RVA: 0x00002D0C File Offset: 0x00000F0C
	public void method_24()
	{
		GClass3.bool_14 = false;
		this.vmethod_1((GEnum0)1);
	}

	// Token: 0x06000173 RID: 371 RVA: 0x00002D1B File Offset: 0x00000F1B
	public void method_25()
	{
		GClass3.bool_14 = false;
		this.vmethod_1((GEnum0)2);
	}

	// Token: 0x06000174 RID: 372 RVA: 0x00002D2A File Offset: 0x00000F2A
	public void method_26(GClass58 gclass58_1)
	{
		this.method_27(gclass58_1, 0);
	}

	// Token: 0x06000175 RID: 373 RVA: 0x00002D34 File Offset: 0x00000F34
	public void method_27(GClass58 gclass58_1, int int_5)
	{
		this.gclass58_0 = gclass58_1;
		this.int_4 = int_5;
		this.vmethod_1((GEnum0)3);
	}

	// Token: 0x06000176 RID: 374
	public abstract void vmethod_2(bool bool_5, bool bool_6);

	// Token: 0x06000177 RID: 375
	public abstract List<GClass64> vmethod_3();

	// Token: 0x06000178 RID: 376 RVA: 0x000026DC File Offset: 0x000008DC
	public virtual void vmethod_4(List<GClass64> list_4, List<GClass58> list_5)
	{
	}

	// Token: 0x06000179 RID: 377
	public abstract void vmethod_5();

	// Token: 0x0600017A RID: 378
	protected abstract void vmethod_6(GClass58 gclass58_1);

	// Token: 0x0600017B RID: 379
	public abstract string vmethod_7(byte[] byte_2, string string_7, int int_5, int int_6, string[] string_8, string string_9);

	// Token: 0x0600017C RID: 380 RVA: 0x00038DF0 File Offset: 0x00036FF0
	protected void method_28()
	{
		if (this.gdelegate4_0 != null)
		{
			this.gdelegate4_0(this, new GEventArgs3());
		}
		if (!GClass3.bool_6 && GClass61.smethod_69(9).B == 0)
		{
			this.bool_1 = true;
		}
	}

	// Token: 0x0600017D RID: 381 RVA: 0x00038E44 File Offset: 0x00037044
	protected void method_29(bool bool_5)
	{
		if (this.gdelegate3_0 != null)
		{
			this.gdelegate3_0(this, new GEventArgs4(bool_5));
		}
		if (!GClass3.bool_0 && GClass3.int_0 > 5)
		{
			GClass61.smethod_70(9, Color.Black);
		}
	}

	// Token: 0x0600017E RID: 382 RVA: 0x00002D4B File Offset: 0x00000F4B
	protected void method_30(string string_7)
	{
		if (this.gdelegate5_0 != null)
		{
			this.gdelegate5_0(this, new GEventArgs5(false, string_7, string.Empty));
		}
	}

	// Token: 0x0600017F RID: 383 RVA: 0x00002D70 File Offset: 0x00000F70
	protected void method_31(bool bool_5, string string_7, string string_8)
	{
		if (this.gdelegate5_1 != null && this.method_10())
		{
			this.gdelegate5_1(this, new GEventArgs5(bool_5, string_7, string_8));
		}
	}

	// Token: 0x06000180 RID: 384 RVA: 0x00038E94 File Offset: 0x00037094
	protected string method_32(byte[] byte_2, string string_7, string[] string_8, string string_9)
	{
		string text = string.Empty;
		if (string_7 == "str")
		{
			text = Encoding.ASCII.GetString(byte_2);
		}
		else if (string_7 == "date")
		{
			if (byte_2.Length == 4)
			{
				text = string.Concat(new string[]
				{
					GClass16.smethod_0(byte_2[2]),
					"/",
					GClass16.smethod_0(byte_2[3]),
					"/",
					GClass16.smethod_0(byte_2[0]),
					GClass16.smethod_0(byte_2[1])
				});
			}
			else
			{
				text = GClass16.smethod_1(byte_2);
			}
		}
		else if (string_7 == "hex")
		{
			text = GClass16.smethod_1(byte_2);
		}
		else if (string_7 == "hex2")
		{
			text = GClass16.smethod_1(byte_2).Replace(" ", string.Empty);
		}
		else if (string_7 == "hex2r")
		{
			byte[] array = new byte[byte_2.Length];
			for (int i = 0; i < byte_2.Length; i++)
			{
				array[byte_2.Length - i - 1] = byte_2[i];
			}
			text = GClass16.smethod_1(array).Replace(" ", string.Empty);
		}
		else if (string_7 == "hex3")
		{
			text = GClass16.smethod_1(byte_2).Replace(" ", string.Empty);
		}
		else
		{
			if (string_7.StartsWith("num"))
			{
				decimal num = 0m;
				decimal num2 = 1m;
				if (byte_2.Length == 2 && string_7.StartsWith("numw"))
				{
					num = 256 * (int)byte_2[1] + (int)byte_2[0];
				}
				else if (byte_2.Length == 1)
				{
					num = byte_2[0];
					if (string_7.StartsWith("nums") && num >= 128m)
					{
						num = (int)((byte_2[0] & 127) - 128);
					}
				}
				else if (byte_2.Length == 2)
				{
					num = 256 * (int)byte_2[0] + (int)byte_2[1];
					if (string_7.StartsWith("nums") && num >= 32768m)
					{
						num = 256 * (int)(byte_2[0] & 127) + (int)byte_2[1] - 32768;
					}
				}
				else if (byte_2.Length == 3)
				{
					num = 65536 * (int)byte_2[0] + 256 * (int)byte_2[1] + (int)byte_2[2];
				}
				else if (byte_2.Length == 4)
				{
					num = 16777216 * (int)byte_2[0] + 65536 * (int)byte_2[1] + 256 * (int)byte_2[2] + (int)byte_2[3];
				}
				else
				{
					for (int i = byte_2.Length - 1; i >= 0; i--)
					{
						num = byte_2[i] * num2;
						num2 *= 256m;
					}
				}
				num2 = 1m;
				decimal d = 0m;
				int num3 = 0;
				List<string> list = new List<string>();
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < string_7.Length; i++)
				{
					if (string_7[i] == ',')
					{
						list.Add(stringBuilder.ToString());
						stringBuilder = new StringBuilder();
					}
					else
					{
						stringBuilder.Append(string_7[i]);
					}
				}
				list.Add(stringBuilder.ToString());
				try
				{
					if (list.Count > 1)
					{
						num3 = GClass16.smethod_5(list[1]);
					}
					if (list.Count > 2)
					{
						num2 = Convert.ToDecimal(list[2], NumberFormatInfo.InvariantInfo);
					}
					if (list.Count > 3)
					{
						d = Convert.ToDecimal(list[3], NumberFormatInfo.InvariantInfo);
					}
					num = num * num2 + d;
					decimal d2 = this.decimal_0[num3];
					num /= d2;
					if (GClass61.smethod_55() && (string_9 == "km" || string_9 == "km/h"))
					{
						num *= 0.621371192237m;
					}
					text = num.ToString("F" + num3);
					goto IL_D23;
				}
				catch (Exception)
				{
					GClass3.smethod_2("Parameter format error", 1);
					goto IL_D23;
				}
			}
			if (string_7 == "bits")
			{
				byte b = byte_2[0];
				for (int i = 0; i < string_8.Length; i++)
				{
					byte b2 = byte.Parse(string_8[i].Substring(0, 2), NumberStyles.HexNumber);
					byte b3 = byte.Parse(string_8[i].Substring(2, 2), NumberStyles.HexNumber);
					if ((b & b2) == b3 || i == string_8.Length - 1)
					{
						text = string_8[i].Substring(4);
						break;
					}
				}
			}
			else if (string_7 == "bitchars")
			{
				text = string.Empty;
				int j = 0;
				IL_5B2:
				while (j < byte_2.Length)
				{
					byte b = byte_2[j];
					for (int i = 0; i < string_8.Length; i++)
					{
						byte b2 = byte.Parse(string_8[i].Substring(0, 2), NumberStyles.HexNumber);
						byte b3 = byte.Parse(string_8[i].Substring(2, 2), NumberStyles.HexNumber);
						if ((b & b2) == b3 || i == string_8.Length - 1)
						{
							text += string_8[i].Substring(4);
							IL_5AC:
							j++;
							goto IL_5B2;
						}
					}
					goto IL_5AC;
				}
			}
			else if (string_7 == "vernum")
			{
				text = GClass16.smethod_1(byte_2);
				if (text.Length == 2)
				{
					text = text[0] + "." + text[1];
				}
			}
			else if (string_7 == "date9141")
			{
				if (byte_2.Length == 3)
				{
					try
					{
						int year = ((byte_2[0] < 70) ? 2000 : 1900) + (int)byte_2[0];
						int num4 = (int)(byte_2[1] * 16 + byte_2[2] / 16);
						DateTime dateTime = new DateTime(year, 1, 1);
						dateTime = dateTime.AddDays((double)num4);
						text = dateTime.ToString("dd/MM/yyyy");
						goto IL_D23;
					}
					catch (Exception)
					{
						text = string.Empty;
						goto IL_D23;
					}
				}
				text = GClass16.smethod_1(byte_2);
			}
			else if (string_7 == "datekw01")
			{
				if (byte_2.Length == 3)
				{
					try
					{
						int num5 = GClass16.smethod_5(GClass16.smethod_0(byte_2[0]));
						int num6 = GClass16.smethod_5(GClass16.smethod_0(byte_2[1]));
						int num7 = GClass16.smethod_5(GClass16.smethod_0(byte_2[2]));
						int year = ((num5 < 70) ? 2000 : 1900) + num5;
						int num4 = num6 * 10 + num7 / 10;
						DateTime dateTime = new DateTime(year, 1, 1);
						dateTime = dateTime.AddDays((double)num4);
						text = dateTime.ToString("dd/MM/yyyy");
						goto IL_D23;
					}
					catch (Exception)
					{
						text = string.Empty;
						goto IL_D23;
					}
				}
				text = GClass16.smethod_1(byte_2);
			}
			else if (string_7 == "datehsn")
			{
				if (byte_2.Length == 3)
				{
					try
					{
						int num5 = GClass16.smethod_5(GClass16.smethod_0(byte_2[0]));
						int num6 = GClass16.smethod_5(GClass16.smethod_0(byte_2[1]));
						int num7 = GClass16.smethod_5(GClass16.smethod_0(byte_2[2]));
						int year = ((num5 < 70) ? 2000 : 1900) + num5;
						int num4 = num6 * 100 + num7;
						DateTime dateTime = new DateTime(year, 1, 1);
						dateTime = dateTime.AddDays((double)num4);
						text = dateTime.ToString("dd/MM/yyyy");
						goto IL_D23;
					}
					catch (Exception)
					{
						text = string.Empty;
						goto IL_D23;
					}
				}
				text = GClass16.smethod_1(byte_2);
			}
			else if (string_7 == "date6")
			{
				if (byte_2.Length == 6)
				{
					text = string.Concat(new string[]
					{
						GClass16.smethod_0(byte_2[1]),
						"/",
						GClass16.smethod_0(byte_2[3]),
						"/",
						GClass16.smethod_0(byte_2[4]),
						GClass16.smethod_0(byte_2[5])
					});
				}
				else
				{
					text = GClass16.smethod_1(byte_2);
				}
			}
			else
			{
				if (string_7.StartsWith("equ"))
				{
					decimal num = 0m;
					decimal num8 = 0m;
					decimal num9 = 0m;
					decimal num10 = 0m;
					decimal d3 = 0m;
					int num3 = 0;
					if (byte_2.Length == 1)
					{
						num = byte_2[0];
						if (string_7.StartsWith("equs") && num > 128m)
						{
							num = (int)((byte_2[0] & 127) - 128);
						}
					}
					else if (byte_2.Length == 2)
					{
						num = 256 * (int)byte_2[0] + (int)byte_2[1];
						if (string_7.StartsWith("equs") && num > 32768m)
						{
							num = 256 * (int)(byte_2[0] & 127) + (int)byte_2[1] - 32768;
						}
					}
					List<string> list = new List<string>();
					StringBuilder stringBuilder = new StringBuilder();
					for (int i = 0; i < string_7.Length; i++)
					{
						if (string_7[i] == ',')
						{
							list.Add(stringBuilder.ToString());
							stringBuilder = new StringBuilder();
						}
						else
						{
							stringBuilder.Append(string_7[i]);
						}
					}
					list.Add(stringBuilder.ToString());
					try
					{
						if (list.Count > 1)
						{
							num3 = GClass16.smethod_5(list[1]);
						}
						if (list.Count > 2)
						{
							num8 = Convert.ToDecimal(list[2], NumberFormatInfo.InvariantInfo);
						}
						if (list.Count > 3)
						{
							num9 = Convert.ToDecimal(list[3], NumberFormatInfo.InvariantInfo);
						}
						if (list.Count > 4)
						{
							num10 = Convert.ToDecimal(list[4], NumberFormatInfo.InvariantInfo);
						}
						if (list.Count > 5)
						{
							d3 = Convert.ToDecimal(list[5], NumberFormatInfo.InvariantInfo);
						}
						num = num8 * (num * num * num) + num9 * (num * num) + num10 * num + d3;
						decimal d2 = this.decimal_0[num3];
						text = num.ToString("F" + num3);
						goto IL_D23;
					}
					catch (Exception)
					{
						GClass3.smethod_2("Parameter format error", 1);
						goto IL_D23;
					}
				}
				if (string_7.StartsWith("cond1"))
				{
					decimal num8 = 0m;
					decimal num9 = 0m;
					decimal num10 = 0m;
					decimal d3 = 0m;
					decimal d4 = 0m;
					int num3 = 0;
					if (byte_2.Length == 2 || byte_2.Length == 1)
					{
						decimal num11 = byte_2[0];
						decimal d5;
						if (byte_2.Length == 1)
						{
							d5 = num11;
						}
						else
						{
							d5 = byte_2[1];
						}
						List<string> list = new List<string>();
						StringBuilder stringBuilder = new StringBuilder();
						for (int i = 0; i < string_7.Length; i++)
						{
							if (string_7[i] == ',')
							{
								list.Add(stringBuilder.ToString());
								stringBuilder = new StringBuilder();
							}
							else
							{
								stringBuilder.Append(string_7[i]);
							}
						}
						list.Add(stringBuilder.ToString());
						try
						{
							if (list.Count > 1)
							{
								num3 = GClass16.smethod_5(list[1]);
							}
							if (list.Count > 2)
							{
								num8 = Convert.ToDecimal(list[2], NumberFormatInfo.InvariantInfo);
							}
							if (list.Count > 3)
							{
								num9 = Convert.ToDecimal(list[3], NumberFormatInfo.InvariantInfo);
							}
							if (list.Count > 4)
							{
								num10 = Convert.ToDecimal(list[4], NumberFormatInfo.InvariantInfo);
							}
							if (list.Count > 5)
							{
								d3 = Convert.ToDecimal(list[5], NumberFormatInfo.InvariantInfo);
							}
							if (list.Count > 6)
							{
								d4 = Convert.ToDecimal(list[6], NumberFormatInfo.InvariantInfo);
							}
							decimal d2 = this.decimal_0[num3];
							text = ((d5 < num8) ? (d5 * num9 + num10) : (num11 * d3 + d4)).ToString("F" + num3);
						}
						catch (Exception)
						{
							GClass3.smethod_2("Parameter format error", 1);
						}
					}
				}
			}
		}
		IL_D23:
		string result;
		if (GClass3.bool_0)
		{
			result = text;
		}
		else
		{
			if (GClass3.int_0 != 0 && GClass3.smethod_1() > 19111 + 7595 * GClass3.int_0)
			{
				GClass3.smethod_2("ERROR: PRILICHA NA KRAKNATA", 0);
				text = string.Empty;
				if (this.bool_1)
				{
					return text;
				}
				GClass3.smethod_2("Terminating...", 1);
				this.bool_1 = true;
				this.bool_0 = false;
				Thread.Sleep(850);
				if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
				{
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
				if (GClass3.int_0 < 12)
				{
					this.method_29(true);
				}
			}
			result = text;
		}
		return result;
	}

	// Token: 0x0400013D RID: 317
	protected byte byte_0 = 0;

	// Token: 0x0400013E RID: 318
	protected bool bool_0 = false;

	// Token: 0x0400013F RID: 319
	protected bool bool_1 = false;

	// Token: 0x04000140 RID: 320
	protected bool bool_2 = false;

	// Token: 0x04000141 RID: 321
	protected int int_0 = 0;

	// Token: 0x04000142 RID: 322
	protected string string_0 = string.Empty;

	// Token: 0x04000143 RID: 323
	protected string string_1 = string.Empty;

	// Token: 0x04000144 RID: 324
	protected string string_2 = string.Empty;

	// Token: 0x04000145 RID: 325
	protected List<GClass58> list_0 = null;

	// Token: 0x04000146 RID: 326
	protected List<GClass58> list_1 = null;

	// Token: 0x04000147 RID: 327
	protected bool bool_3 = true;

	// Token: 0x04000148 RID: 328
	protected int int_1 = 0;

	// Token: 0x04000149 RID: 329
	protected int int_2 = 0;

	// Token: 0x0400014A RID: 330
	protected int int_3 = 0;

	// Token: 0x0400014B RID: 331
	protected List<string> list_2 = new List<string>();

	// Token: 0x0400014C RID: 332
	protected string string_3 = string.Empty;

	// Token: 0x0400014D RID: 333
	protected string string_4 = string.Empty;

	// Token: 0x0400014E RID: 334
	protected string string_5 = string.Empty;

	// Token: 0x0400014F RID: 335
	protected bool bool_4 = true;

	// Token: 0x04000150 RID: 336
	protected string string_6 = string.Empty;

	// Token: 0x04000151 RID: 337
	protected List<GClass64> list_3 = null;

	// Token: 0x04000152 RID: 338
	protected Random random_0 = new Random();

	// Token: 0x04000153 RID: 339
	protected SerialPort serialPort_0;

	// Token: 0x04000154 RID: 340
	protected byte[] byte_1 = new byte[]
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

	// Token: 0x04000155 RID: 341
	protected decimal[] decimal_0 = new decimal[]
	{
		1m,
		10m,
		100m,
		1000m,
		10000m,
		100000m,
		1000000m,
		10000000m,
		100000000m,
		1000000000m
	};

	// Token: 0x04000156 RID: 342
	protected GClass58 gclass58_0 = null;

	// Token: 0x04000157 RID: 343
	protected int int_4 = 0;

	// Token: 0x04000158 RID: 344
	private GDelegate4 gdelegate4_0;

	// Token: 0x04000159 RID: 345
	private GDelegate3 gdelegate3_0;

	// Token: 0x0400015A RID: 346
	private GDelegate5 gdelegate5_0;

	// Token: 0x0400015B RID: 347
	private GDelegate5 gdelegate5_1;

	// Token: 0x02000022 RID: 34
	private sealed class Class2
	{
		// Token: 0x06000182 RID: 386 RVA: 0x00002D9C File Offset: 0x00000F9C
		public void method_0()
		{
			this.gclass19_0.vmethod_6(this.gclass58_0);
		}

		// Token: 0x0400015C RID: 348
		public GClass19 gclass19_0;

		// Token: 0x0400015D RID: 349
		public GClass58 gclass58_0;
	}
}
