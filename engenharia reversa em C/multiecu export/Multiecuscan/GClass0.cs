using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

// Token: 0x02000008 RID: 8
public abstract class GClass0
{
	// Token: 0x06000014 RID: 20 RVA: 0x0000543C File Offset: 0x0000363C
	public static GClass0 smethod_0(string string_5, string string_6, byte byte_2, List<GClass104> list_3, List<GClass104> list_4)
	{
		if (GClass125.smethod_44() == 1)
		{
			if (string_5 == "KWP2000Fast")
			{
				return new GClass7(byte_2, list_3, list_4);
			}
			if (string_5 == "KWP71")
			{
				return new GClass8(byte_2, list_3, list_4);
			}
		}
		else if (GClass125.smethod_44() == 2 || GClass125.smethod_44() == 3)
		{
			if (string_5 == "KWP2000Fast")
			{
				return new GClass5(byte_2, list_3, list_4);
			}
			if (string_5 == "ISO9141")
			{
				return null;
			}
			if (string_5 == "KWP71")
			{
				return null;
			}
			if (string_5 == "BCAN")
			{
				return new GClass2(byte_2, string_6, list_3, list_4);
			}
			if (string_5 == "BCAN29")
			{
				return new GClass1(byte_2, string_6, list_3, list_4);
			}
			if (string_5 == "CCAN29")
			{
				return new GClass3(byte_2, string_6, list_3, list_4);
			}
		}
		return null;
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002D40 File Offset: 0x00000F40
	public bool method_0()
	{
		return this.bool_3;
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00002D48 File Offset: 0x00000F48
	public void method_1(bool bool_5)
	{
		this.bool_3 = bool_5;
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002D51 File Offset: 0x00000F51
	public int method_2()
	{
		return this.int_3;
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002D59 File Offset: 0x00000F59
	public void method_3(int int_5)
	{
		this.int_3 = int_5;
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002D62 File Offset: 0x00000F62
	public string method_4()
	{
		return this.string_1;
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00002D6A File Offset: 0x00000F6A
	public string method_5()
	{
		return this.string_4;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00002D72 File Offset: 0x00000F72
	public string method_6()
	{
		return this.string_2;
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00002D7A File Offset: 0x00000F7A
	public string method_7()
	{
		return this.string_3;
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00002D82 File Offset: 0x00000F82
	public bool method_8()
	{
		return this.bool_4;
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00002D8A File Offset: 0x00000F8A
	public bool method_9()
	{
		return this.bool_0 && !this.bool_1;
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00002D9F File Offset: 0x00000F9F
	public bool method_10()
	{
		return this.bool_2;
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000020 RID: 32 RVA: 0x00002DA7 File Offset: 0x00000FA7
	// (set) Token: 0x06000021 RID: 33 RVA: 0x00002DAF File Offset: 0x00000FAF
	public string ModuleID
	{
		get
		{
			return this.string_0;
		}
		set
		{
			this.string_0 = value;
		}
	}

	// Token: 0x14000001 RID: 1
	// (add) Token: 0x06000022 RID: 34 RVA: 0x00005510 File Offset: 0x00003710
	// (remove) Token: 0x06000023 RID: 35 RVA: 0x00005548 File Offset: 0x00003748
	public event GDelegate4 Event_0
	{
		[CompilerGenerated]
		add
		{
			GDelegate4 gdelegate = this.gdelegate4_0;
			GDelegate4 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate4 value2 = (GDelegate4)Delegate.Combine(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate4>(ref this.gdelegate4_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
		[CompilerGenerated]
		remove
		{
			GDelegate4 gdelegate = this.gdelegate4_0;
			GDelegate4 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate4 value2 = (GDelegate4)Delegate.Remove(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate4>(ref this.gdelegate4_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
	}

	// Token: 0x14000002 RID: 2
	// (add) Token: 0x06000024 RID: 36 RVA: 0x00005580 File Offset: 0x00003780
	// (remove) Token: 0x06000025 RID: 37 RVA: 0x000055B8 File Offset: 0x000037B8
	public event GDelegate3 Event_1
	{
		[CompilerGenerated]
		add
		{
			GDelegate3 gdelegate = this.gdelegate3_0;
			GDelegate3 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate3 value2 = (GDelegate3)Delegate.Combine(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate3>(ref this.gdelegate3_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
		[CompilerGenerated]
		remove
		{
			GDelegate3 gdelegate = this.gdelegate3_0;
			GDelegate3 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate3 value2 = (GDelegate3)Delegate.Remove(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate3>(ref this.gdelegate3_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
	}

	// Token: 0x14000003 RID: 3
	// (add) Token: 0x06000026 RID: 38 RVA: 0x000055F0 File Offset: 0x000037F0
	// (remove) Token: 0x06000027 RID: 39 RVA: 0x00005628 File Offset: 0x00003828
	public event GDelegate5 Event_2
	{
		[CompilerGenerated]
		add
		{
			GDelegate5 gdelegate = this.gdelegate5_0;
			GDelegate5 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate5 value2 = (GDelegate5)Delegate.Combine(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate5>(ref this.gdelegate5_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
		[CompilerGenerated]
		remove
		{
			GDelegate5 gdelegate = this.gdelegate5_0;
			GDelegate5 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate5 value2 = (GDelegate5)Delegate.Remove(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate5>(ref this.gdelegate5_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
	}

	// Token: 0x14000004 RID: 4
	// (add) Token: 0x06000028 RID: 40 RVA: 0x00005660 File Offset: 0x00003860
	// (remove) Token: 0x06000029 RID: 41 RVA: 0x00005698 File Offset: 0x00003898
	public event GDelegate5 Event_3
	{
		[CompilerGenerated]
		add
		{
			GDelegate5 gdelegate = this.gdelegate5_1;
			GDelegate5 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate5 value2 = (GDelegate5)Delegate.Combine(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate5>(ref this.gdelegate5_1, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
		[CompilerGenerated]
		remove
		{
			GDelegate5 gdelegate = this.gdelegate5_1;
			GDelegate5 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate5 value2 = (GDelegate5)Delegate.Remove(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate5>(ref this.gdelegate5_1, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00002DB8 File Offset: 0x00000FB8
	public void method_11(bool bool_5)
	{
		this.r0(bool_5, false);
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00002DC2 File Offset: 0x00000FC2
	public void method_12(GClass104 gclass104_1)
	{
		GClass0.Class0 @class = new GClass0.Class0();
		@class.<>4__this = this;
		@class.command = gclass104_1;
		new Thread(new ThreadStart(@class.method_0)).Start();
	}

	// Token: 0x0600002C RID: 44
	public abstract string vmethod_0(byte[] byte_2, string string_5, int int_5, int int_6, string[] string_6, string string_7);

	// Token: 0x0600002D RID: 45
	public abstract void vmethod_1(GForm9 gform9_0, bool bool_5);

	// Token: 0x0600002E RID: 46 RVA: 0x00002DEC File Offset: 0x00000FEC
	public void method_13()
	{
		this.vmethod_1(null, true);
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00002DF6 File Offset: 0x00000FF6
	public void method_14(GClass104 gclass104_1)
	{
		this.method_15(gclass104_1, 0);
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00002E00 File Offset: 0x00001000
	public void method_15(GClass104 gclass104_1, int int_5)
	{
		this.gclass104_0 = gclass104_1;
		this.int_4 = int_5;
		this.vmethod_1(null, true);
	}

	// Token: 0x06000031 RID: 49
	public abstract void r0(bool bool_5, bool bool_6);

	// Token: 0x06000032 RID: 50
	public abstract List<GClass102> r1();

	// Token: 0x06000033 RID: 51
	public abstract void r2();

	// Token: 0x06000034 RID: 52
	protected abstract void r3(GClass104 gclass104_1);

	// Token: 0x06000035 RID: 53
	public abstract string r4(byte[] byte_2, string string_5, int int_5, int int_6, string[] string_6, string string_7);

	// Token: 0x06000036 RID: 54 RVA: 0x000056D0 File Offset: 0x000038D0
	protected void method_16()
	{
		if (this.gdelegate4_0 != null)
		{
			this.gdelegate4_0(this, new GEventArgs3());
		}
		if (!GClass126.bool_15 && GClass125.smethod_101(19).B == 0)
		{
			this.bool_1 = true;
		}
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00002E18 File Offset: 0x00001018
	protected void method_17(bool bool_5)
	{
		if (this.gdelegate3_0 != null)
		{
			this.gdelegate3_0(this, new GEventArgs4(bool_5));
		}
		if (!GClass126.bool_0 && GClass126.int_1 > 5)
		{
			GClass125.smethod_102(19, Color.Black);
		}
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00002E4F File Offset: 0x0000104F
	protected void method_18(string string_5)
	{
		if (this.gdelegate5_0 != null)
		{
			this.gdelegate5_0(this, new GEventArgs5(false, string_5, ""));
		}
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00002E71 File Offset: 0x00001071
	protected void method_19(bool bool_5, string string_5, string string_6)
	{
		if (this.gdelegate5_1 != null && this.method_9())
		{
			this.gdelegate5_1(this, new GEventArgs5(bool_5, string_5, string_6));
		}
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00005718 File Offset: 0x00003918
	protected string method_20(byte[] byte_2, string string_5, string[] string_6, string string_7)
	{
		string text = "";
		if (string_5 == "str")
		{
			text = Encoding.ASCII.GetString(byte_2);
		}
		else if (string_5 == "date")
		{
			if (byte_2.Length == 4)
			{
				text = string.Concat(new string[]
				{
					GClass127.smethod_23(byte_2[2]),
					"/",
					GClass127.smethod_23(byte_2[3]),
					"/",
					GClass127.smethod_23(byte_2[0]),
					GClass127.smethod_23(byte_2[1])
				});
			}
			else
			{
				text = GClass127.smethod_11(byte_2);
			}
		}
		else if (string_5 == "hex")
		{
			text = GClass127.smethod_11(byte_2);
		}
		else if (string_5 == "hex2")
		{
			text = GClass127.smethod_11(byte_2).Replace(" ", "");
		}
		else if (string_5 == "hex3")
		{
			text = GClass127.smethod_11(byte_2).Replace(" ", "");
		}
		else
		{
			if (string_5.StartsWith("num"))
			{
				decimal d = 0m;
				decimal num = 1m;
				if (byte_2.Length == 2 && string_5.StartsWith("numw"))
				{
					d = 256 * (int)byte_2[1] + (int)byte_2[0];
				}
				else if (byte_2.Length == 1)
				{
					d = byte_2[0];
					if (string_5.StartsWith("nums") && d >= 128m)
					{
						d = (int)((byte_2[0] & 127) - 128);
					}
				}
				else if (byte_2.Length == 2)
				{
					d = 256 * (int)byte_2[0] + (int)byte_2[1];
					if (string_5.StartsWith("nums") && d >= 32768m)
					{
						d = 256 * (int)(byte_2[0] & 127) + (int)byte_2[1] - 32768;
					}
				}
				else if (byte_2.Length == 3)
				{
					d = 65536 * (int)byte_2[0] + 256 * (int)byte_2[1] + (int)byte_2[2];
				}
				else if (byte_2.Length == 4)
				{
					d = 16777216 * (int)byte_2[0] + 65536 * (int)byte_2[1] + 256 * (int)byte_2[2] + (int)byte_2[3];
				}
				else
				{
					for (int i = byte_2.Length - 1; i >= 0; i--)
					{
						d = byte_2[i] * num;
						num *= 256m;
					}
				}
				num = 1m;
				decimal d2 = 0m;
				int num2 = 0;
				List<string> list = new List<string>();
				StringBuilder stringBuilder = new StringBuilder();
				for (int j = 0; j < string_5.Length; j++)
				{
					if (string_5[j] == ',')
					{
						list.Add(stringBuilder.ToString());
						stringBuilder = new StringBuilder();
					}
					else
					{
						stringBuilder.Append(string_5[j]);
					}
				}
				list.Add(stringBuilder.ToString());
				try
				{
					if (list.Count > 1)
					{
						num2 = GClass127.smethod_37(list[1]);
					}
					if (list.Count > 2)
					{
						num = Convert.ToDecimal(list[2], NumberFormatInfo.InvariantInfo);
					}
					if (list.Count > 3)
					{
						d2 = Convert.ToDecimal(list[3], NumberFormatInfo.InvariantInfo);
					}
					d = d * num + d2;
					decimal d3 = this.decimal_0[num2];
					d /= d3;
					if (GClass125.smethod_71() && (string_7 == "km" || string_7 == "km/h"))
					{
						d *= 0.621371192237m;
					}
					text = d.ToString("F" + num2.ToString());
					goto IL_A4A;
				}
				catch (Exception)
				{
					GClass126.smethod_2("Parameter format error", 1);
					goto IL_A4A;
				}
			}
			if (string_5 == "bits")
			{
				byte b = byte_2[0];
				int k = 0;
				while (k < string_6.Length)
				{
					byte b2 = byte.Parse(string_6[k].Substring(0, 2), NumberStyles.HexNumber);
					byte b3 = byte.Parse(string_6[k].Substring(2, 2), NumberStyles.HexNumber);
					if ((b & b2) != b3)
					{
						if (k != string_6.Length - 1)
						{
							k++;
							continue;
						}
					}
					text = string_6[k].Substring(4);
					break;
				}
			}
			else if (string_5 == "bitchars")
			{
				text = "";
				int l = 0;
				IL_4E4:
				while (l < byte_2.Length)
				{
					byte b4 = byte_2[l];
					int m = 0;
					while (m < string_6.Length)
					{
						byte b5 = byte.Parse(string_6[m].Substring(0, 2), NumberStyles.HexNumber);
						byte b6 = byte.Parse(string_6[m].Substring(2, 2), NumberStyles.HexNumber);
						if ((b4 & b5) != b6)
						{
							if (m != string_6.Length - 1)
							{
								m++;
								continue;
							}
						}
						text += string_6[m].Substring(4);
						IL_4DE:
						l++;
						goto IL_4E4;
					}
					goto IL_4DE;
				}
			}
			else if (string_5 == "vernum")
			{
				text = GClass127.smethod_11(byte_2);
				if (text.Length == 2)
				{
					text = text[0].ToString() + "." + text[1].ToString();
				}
			}
			else if (string_5 == "date9141")
			{
				if (byte_2.Length == 3)
				{
					try
					{
						int year = ((byte_2[0] < 70) ? 2000 : 1900) + (int)byte_2[0];
						int num3 = (int)(byte_2[1] * 16 + byte_2[2] / 16);
						DateTime dateTime = new DateTime(year, 1, 1);
						dateTime.AddDays((double)num3);
						text = dateTime.ToString("MM/dd/yyyy");
						goto IL_A4A;
					}
					catch (Exception)
					{
						text = "";
						goto IL_A4A;
					}
				}
				text = GClass127.smethod_11(byte_2);
			}
			else if (string_5 == "date6")
			{
				if (byte_2.Length == 6)
				{
					text = string.Concat(new string[]
					{
						GClass127.smethod_23(byte_2[1]),
						"/",
						GClass127.smethod_23(byte_2[3]),
						"/",
						GClass127.smethod_23(byte_2[4]),
						GClass127.smethod_23(byte_2[5])
					});
				}
				else
				{
					text = GClass127.smethod_11(byte_2);
				}
			}
			else
			{
				if (string_5.StartsWith("equ"))
				{
					decimal num4 = 0m;
					decimal d4 = 0m;
					decimal d5 = 0m;
					decimal d6 = 0m;
					decimal d7 = 0m;
					int num5 = 0;
					if (byte_2.Length == 1)
					{
						num4 = byte_2[0];
						if (string_5.StartsWith("equs") && num4 > 128m)
						{
							num4 = (int)((byte_2[0] & 127) - 128);
						}
					}
					else if (byte_2.Length == 2)
					{
						num4 = 256 * (int)byte_2[0] + (int)byte_2[1];
						if (string_5.StartsWith("equs") && num4 > 32768m)
						{
							num4 = 256 * (int)(byte_2[0] & 127) + (int)byte_2[1] - 32768;
						}
					}
					List<string> list2 = new List<string>();
					StringBuilder stringBuilder2 = new StringBuilder();
					for (int n = 0; n < string_5.Length; n++)
					{
						if (string_5[n] == ',')
						{
							list2.Add(stringBuilder2.ToString());
							stringBuilder2 = new StringBuilder();
						}
						else
						{
							stringBuilder2.Append(string_5[n]);
						}
					}
					list2.Add(stringBuilder2.ToString());
					try
					{
						if (list2.Count > 1)
						{
							num5 = GClass127.smethod_37(list2[1]);
						}
						if (list2.Count > 2)
						{
							d4 = Convert.ToDecimal(list2[2], NumberFormatInfo.InvariantInfo);
						}
						if (list2.Count > 3)
						{
							d5 = Convert.ToDecimal(list2[3], NumberFormatInfo.InvariantInfo);
						}
						if (list2.Count > 4)
						{
							d6 = Convert.ToDecimal(list2[4], NumberFormatInfo.InvariantInfo);
						}
						if (list2.Count > 5)
						{
							d7 = Convert.ToDecimal(list2[5], NumberFormatInfo.InvariantInfo);
						}
						text = (d4 * (num4 * num4 * num4) + d5 * (num4 * num4) + d6 * num4 + d7).ToString("F" + num5.ToString());
						goto IL_A4A;
					}
					catch (Exception)
					{
						GClass126.smethod_2("Parameter format error", 1);
						goto IL_A4A;
					}
				}
				if (string_5.StartsWith("cond1"))
				{
					decimal num6 = 0m;
					decimal d8 = 0m;
					decimal d9 = 0m;
					decimal d10 = 0m;
					decimal d11 = 0m;
					decimal d12 = 0m;
					decimal d13 = 0m;
					int num7 = 0;
					if (byte_2.Length == 2 || byte_2.Length == 1)
					{
						num6 = byte_2[0];
						if (byte_2.Length == 1)
						{
							d8 = num6;
						}
						else
						{
							d8 = byte_2[1];
						}
						List<string> list3 = new List<string>();
						StringBuilder stringBuilder3 = new StringBuilder();
						for (int num8 = 0; num8 < string_5.Length; num8++)
						{
							if (string_5[num8] == ',')
							{
								list3.Add(stringBuilder3.ToString());
								stringBuilder3 = new StringBuilder();
							}
							else
							{
								stringBuilder3.Append(string_5[num8]);
							}
						}
						list3.Add(stringBuilder3.ToString());
						try
						{
							if (list3.Count > 1)
							{
								num7 = GClass127.smethod_37(list3[1]);
							}
							if (list3.Count > 2)
							{
								d9 = Convert.ToDecimal(list3[2], NumberFormatInfo.InvariantInfo);
							}
							if (list3.Count > 3)
							{
								d10 = Convert.ToDecimal(list3[3], NumberFormatInfo.InvariantInfo);
							}
							if (list3.Count > 4)
							{
								d11 = Convert.ToDecimal(list3[4], NumberFormatInfo.InvariantInfo);
							}
							if (list3.Count > 5)
							{
								d12 = Convert.ToDecimal(list3[5], NumberFormatInfo.InvariantInfo);
							}
							if (list3.Count > 6)
							{
								d13 = Convert.ToDecimal(list3[6], NumberFormatInfo.InvariantInfo);
							}
							text = ((d8 < d9) ? (d8 * d10 + d11) : (num6 * d12 + d13)).ToString("F" + num7.ToString());
						}
						catch (Exception)
						{
							GClass126.smethod_2("Parameter format error", 1);
						}
					}
				}
			}
		}
		IL_A4A:
		if (GClass126.bool_0)
		{
			return text;
		}
		if (GClass126.int_1 != 0 && GClass126.smethod_1() > 19111 + 7595 * GClass126.int_1)
		{
			GClass126.smethod_2("ERROR: PRILICHA NA KRAKNATA", 0);
			text = "";
			if (this.bool_1)
			{
				return text;
			}
			GClass126.smethod_2("Terminating...", 1);
			this.bool_1 = true;
			this.bool_0 = false;
			Thread.Sleep(850);
			if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
			{
				try
				{
					this.serialPort_0.Close();
					GClass126.smethod_2("Serial port closed!", 1);
				}
				catch (Exception ex)
				{
					GClass126.smethod_2("ERROR: Failed to close serial port: " + ex.Message, 1);
				}
				GClass126.smethod_2("-------------------------------------", 1);
				GClass126.smethod_2(" ", 1);
			}
			if (GClass126.int_1 < 12)
			{
				this.method_17(true);
			}
		}
		return text;
	}

	// Token: 0x04000005 RID: 5
	protected byte byte_0;

	// Token: 0x04000006 RID: 6
	protected bool bool_0;

	// Token: 0x04000007 RID: 7
	protected bool bool_1;

	// Token: 0x04000008 RID: 8
	protected bool bool_2;

	// Token: 0x04000009 RID: 9
	protected int int_0;

	// Token: 0x0400000A RID: 10
	protected string string_0 = "";

	// Token: 0x0400000B RID: 11
	protected List<GClass104> list_0;

	// Token: 0x0400000C RID: 12
	protected List<GClass104> list_1;

	// Token: 0x0400000D RID: 13
	protected bool bool_3 = true;

	// Token: 0x0400000E RID: 14
	protected int int_1;

	// Token: 0x0400000F RID: 15
	protected int int_2;

	// Token: 0x04000010 RID: 16
	protected int int_3;

	// Token: 0x04000011 RID: 17
	protected List<string> list_2 = new List<string>();

	// Token: 0x04000012 RID: 18
	protected string string_1 = "";

	// Token: 0x04000013 RID: 19
	protected string string_2 = "";

	// Token: 0x04000014 RID: 20
	protected string string_3 = "";

	// Token: 0x04000015 RID: 21
	protected bool bool_4 = true;

	// Token: 0x04000016 RID: 22
	protected string string_4 = "";

	// Token: 0x04000017 RID: 23
	protected Random random_0 = new Random();

	// Token: 0x04000018 RID: 24
	protected SerialPort serialPort_0;

	// Token: 0x04000019 RID: 25
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

	// Token: 0x0400001A RID: 26
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

	// Token: 0x0400001B RID: 27
	protected GClass104 gclass104_0;

	// Token: 0x0400001C RID: 28
	protected int int_4;

	// Token: 0x0400001D RID: 29
	[CompilerGenerated]
	private GDelegate4 gdelegate4_0;

	// Token: 0x0400001E RID: 30
	[CompilerGenerated]
	private GDelegate3 gdelegate3_0;

	// Token: 0x0400001F RID: 31
	[CompilerGenerated]
	private GDelegate5 gdelegate5_0;

	// Token: 0x04000020 RID: 32
	[CompilerGenerated]
	private GDelegate5 gdelegate5_1;

	// Token: 0x02000009 RID: 9
	[CompilerGenerated]
	private sealed class Class0
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00002E9F File Offset: 0x0000109F
		internal void method_0()
		{
			this.<>4__this.r3(this.command);
		}

		// Token: 0x04000021 RID: 33
		public GClass0 <>4__this;

		// Token: 0x04000022 RID: 34
		public GClass104 command;
	}
}
