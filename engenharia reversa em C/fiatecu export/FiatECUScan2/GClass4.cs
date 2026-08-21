using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

// Token: 0x02000013 RID: 19
public abstract class GClass4
{
	// Token: 0x06000098 RID: 152 RVA: 0x00020B80 File Offset: 0x0001ED80
	public static GClass4 smethod_0(string string_5, string string_6, byte byte_2, List<GClass58> list_3, List<GClass58> list_4)
	{
		if (GClass61.smethod_36() == 1)
		{
			if (string_5 == "KWP2000Fast")
			{
				return new GClass14(byte_2, list_3, list_4);
			}
			if (string_5 == "KWP71")
			{
				return new GClass13(byte_2, list_3, list_4);
			}
		}
		else if (GClass61.smethod_36() == 2 || GClass61.smethod_36() == 3)
		{
			if (string_5 == "KWP2000Fast")
			{
				return new GClass7(byte_2, list_3, list_4);
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
				return new GClass9(byte_2, string_6, list_3, list_4);
			}
			if (string_5 == "BCAN29")
			{
				return new GClass12(byte_2, string_6, list_3, list_4);
			}
			if (string_5 == "CCAN29")
			{
				return new GClass8(byte_2, string_6, list_3, list_4);
			}
		}
		return null;
	}

	// Token: 0x06000099 RID: 153 RVA: 0x000028F2 File Offset: 0x00000AF2
	public bool method_0()
	{
		return this.bool_3;
	}

	// Token: 0x0600009A RID: 154 RVA: 0x000028FA File Offset: 0x00000AFA
	public void method_1(bool bool_5)
	{
		this.bool_3 = bool_5;
	}

	// Token: 0x0600009B RID: 155 RVA: 0x00020C98 File Offset: 0x0001EE98
	public int method_2()
	{
		return this.int_3;
	}

	// Token: 0x0600009C RID: 156 RVA: 0x00002903 File Offset: 0x00000B03
	public void method_3(int int_5)
	{
		this.int_3 = int_5;
	}

	// Token: 0x0600009D RID: 157 RVA: 0x00020CB0 File Offset: 0x0001EEB0
	public string method_4()
	{
		return this.string_1;
	}

	// Token: 0x0600009E RID: 158 RVA: 0x00020CC8 File Offset: 0x0001EEC8
	public string method_5()
	{
		return this.string_4;
	}

	// Token: 0x0600009F RID: 159 RVA: 0x00020CE0 File Offset: 0x0001EEE0
	public string method_6()
	{
		return this.string_2;
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00020CF8 File Offset: 0x0001EEF8
	public string method_7()
	{
		return this.string_3;
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x0000290C File Offset: 0x00000B0C
	public bool method_8()
	{
		return this.bool_4;
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x00002914 File Offset: 0x00000B14
	public bool method_9()
	{
		return this.bool_0 && !this.bool_1;
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x0000292A File Offset: 0x00000B2A
	public bool method_10()
	{
		return this.bool_2;
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x00020D10 File Offset: 0x0001EF10
	public string method_11()
	{
		return this.string_0;
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x00002932 File Offset: 0x00000B32
	public void method_12(string string_5)
	{
		this.string_0 = string_5;
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x0000293B File Offset: 0x00000B3B
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_13(GDelegate4 gdelegate4_1)
	{
		this.gdelegate4_0 = (GDelegate4)Delegate.Combine(this.gdelegate4_0, gdelegate4_1);
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x00002954 File Offset: 0x00000B54
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_14(GDelegate4 gdelegate4_1)
	{
		this.gdelegate4_0 = (GDelegate4)Delegate.Remove(this.gdelegate4_0, gdelegate4_1);
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x0000296D File Offset: 0x00000B6D
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_15(GDelegate3 gdelegate3_1)
	{
		this.gdelegate3_0 = (GDelegate3)Delegate.Combine(this.gdelegate3_0, gdelegate3_1);
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x00002986 File Offset: 0x00000B86
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_16(GDelegate3 gdelegate3_1)
	{
		this.gdelegate3_0 = (GDelegate3)Delegate.Remove(this.gdelegate3_0, gdelegate3_1);
	}

	// Token: 0x060000AA RID: 170 RVA: 0x0000299F File Offset: 0x00000B9F
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_17(GDelegate5 gdelegate5_2)
	{
		this.gdelegate5_0 = (GDelegate5)Delegate.Combine(this.gdelegate5_0, gdelegate5_2);
	}

	// Token: 0x060000AB RID: 171 RVA: 0x000029B8 File Offset: 0x00000BB8
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_18(GDelegate5 gdelegate5_2)
	{
		this.gdelegate5_0 = (GDelegate5)Delegate.Remove(this.gdelegate5_0, gdelegate5_2);
	}

	// Token: 0x060000AC RID: 172 RVA: 0x000029D1 File Offset: 0x00000BD1
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_19(GDelegate5 gdelegate5_2)
	{
		this.gdelegate5_1 = (GDelegate5)Delegate.Combine(this.gdelegate5_1, gdelegate5_2);
	}

	// Token: 0x060000AD RID: 173 RVA: 0x000029EA File Offset: 0x00000BEA
	[MethodImpl(MethodImplOptions.Synchronized)]
	public void method_20(GDelegate5 gdelegate5_2)
	{
		this.gdelegate5_1 = (GDelegate5)Delegate.Remove(this.gdelegate5_1, gdelegate5_2);
	}

	// Token: 0x060000AE RID: 174 RVA: 0x00002A03 File Offset: 0x00000C03
	public void method_21(bool bool_5)
	{
		this.vmethod_2(bool_5, false);
	}

	// Token: 0x060000AF RID: 175 RVA: 0x00020D28 File Offset: 0x0001EF28
	public void method_22(GClass58 gclass58_1)
	{
		Thread thread = new Thread(new ThreadStart(new GClass4.Class0
		{
			gclass58_0 = gclass58_1,
			gclass4_0 = this
		}.method_0));
		thread.Start();
	}

	// Token: 0x060000B0 RID: 176
	public abstract string vmethod_0(byte[] byte_2, string string_5, int int_5, int int_6, string[] string_6, string string_7);

	// Token: 0x060000B1 RID: 177
	public abstract void vmethod_1(FormNotify formNotify_0, bool bool_5);

	// Token: 0x060000B2 RID: 178 RVA: 0x00002A0D File Offset: 0x00000C0D
	public void method_23()
	{
		this.vmethod_1(null, true);
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x00002A17 File Offset: 0x00000C17
	public void method_24(GClass58 gclass58_1)
	{
		this.method_25(gclass58_1, 0);
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x00002A21 File Offset: 0x00000C21
	public void method_25(GClass58 gclass58_1, int int_5)
	{
		this.gclass58_0 = gclass58_1;
		this.int_4 = int_5;
		this.vmethod_1(null, true);
	}

	// Token: 0x060000B5 RID: 181
	public abstract void vmethod_2(bool bool_5, bool bool_6);

	// Token: 0x060000B6 RID: 182
	public abstract List<GClass64> vmethod_3();

	// Token: 0x060000B7 RID: 183
	public abstract void vmethod_4();

	// Token: 0x060000B8 RID: 184
	protected abstract void vmethod_5(GClass58 gclass58_1);

	// Token: 0x060000B9 RID: 185
	public abstract string vmethod_6(byte[] byte_2, string string_5, int int_5, int int_6, string[] string_6, string string_7);

	// Token: 0x060000BA RID: 186 RVA: 0x00020D64 File Offset: 0x0001EF64
	protected void method_26()
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

	// Token: 0x060000BB RID: 187 RVA: 0x00020DB8 File Offset: 0x0001EFB8
	protected void method_27(bool bool_5)
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

	// Token: 0x060000BC RID: 188 RVA: 0x00002A39 File Offset: 0x00000C39
	protected void method_28(string string_5)
	{
		if (this.gdelegate5_0 != null)
		{
			this.gdelegate5_0(this, new GEventArgs5(false, string_5, string.Empty));
		}
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00002A5E File Offset: 0x00000C5E
	protected void method_29(bool bool_5, string string_5, string string_6)
	{
		if (this.gdelegate5_1 != null && this.method_9())
		{
			this.gdelegate5_1(this, new GEventArgs5(bool_5, string_5, string_6));
		}
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00020E08 File Offset: 0x0001F008
	protected string method_30(byte[] byte_2, string string_5, string[] string_6, string string_7)
	{
		string text = string.Empty;
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
		else if (string_5 == "hex")
		{
			text = GClass16.smethod_1(byte_2);
		}
		else if (string_5 == "hex2")
		{
			text = GClass16.smethod_1(byte_2).Replace(" ", string.Empty);
		}
		else if (string_5 == "hex3")
		{
			text = GClass16.smethod_1(byte_2).Replace(" ", string.Empty);
		}
		else
		{
			if (string_5.StartsWith("num"))
			{
				decimal num = 0m;
				decimal num2 = 1m;
				if (byte_2.Length == 2 && string_5.StartsWith("numw"))
				{
					num = 256 * (int)byte_2[1] + (int)byte_2[0];
				}
				else if (byte_2.Length == 1)
				{
					num = byte_2[0];
					if (string_5.StartsWith("nums") && num >= 128m)
					{
						num = (int)((byte_2[0] & 127) - 128);
					}
				}
				else if (byte_2.Length == 2)
				{
					num = 256 * (int)byte_2[0] + (int)byte_2[1];
					if (string_5.StartsWith("nums") && num >= 32768m)
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
				for (int i = 0; i < string_5.Length; i++)
				{
					if (string_5[i] == ',')
					{
						list.Add(stringBuilder.ToString());
						stringBuilder = new StringBuilder();
					}
					else
					{
						stringBuilder.Append(string_5[i]);
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
					if (GClass61.smethod_55() && (string_7 == "km" || string_7 == "km/h"))
					{
						num *= 0.621371192237m;
					}
					text = num.ToString("F" + num3);
					goto IL_B71;
				}
				catch (Exception)
				{
					GClass3.smethod_2("Parameter format error", 1);
					goto IL_B71;
				}
			}
			if (string_5 == "bits")
			{
				byte b = byte_2[0];
				for (int i = 0; i < string_6.Length; i++)
				{
					byte b2 = byte.Parse(string_6[i].Substring(0, 2), NumberStyles.HexNumber);
					byte b3 = byte.Parse(string_6[i].Substring(2, 2), NumberStyles.HexNumber);
					if ((b & b2) == b3 || i == string_6.Length - 1)
					{
						text = string_6[i].Substring(4);
						break;
					}
				}
			}
			else if (string_5 == "bitchars")
			{
				text = string.Empty;
				int j = 0;
				IL_568:
				while (j < byte_2.Length)
				{
					byte b = byte_2[j];
					for (int i = 0; i < string_6.Length; i++)
					{
						byte b2 = byte.Parse(string_6[i].Substring(0, 2), NumberStyles.HexNumber);
						byte b3 = byte.Parse(string_6[i].Substring(2, 2), NumberStyles.HexNumber);
						if ((b & b2) == b3 || i == string_6.Length - 1)
						{
							text += string_6[i].Substring(4);
							IL_562:
							j++;
							goto IL_568;
						}
					}
					goto IL_562;
				}
			}
			else if (string_5 == "vernum")
			{
				text = GClass16.smethod_1(byte_2);
				if (text.Length == 2)
				{
					text = text[0] + "." + text[1];
				}
			}
			else if (string_5 == "date9141")
			{
				if (byte_2.Length == 3)
				{
					try
					{
						int year = ((byte_2[0] < 70) ? 2000 : 1900) + (int)byte_2[0];
						int num4 = (int)(byte_2[1] * 16 + byte_2[2] / 16);
						DateTime dateTime = new DateTime(year, 1, 1);
						dateTime.AddDays((double)num4);
						text = dateTime.ToString("MM/dd/yyyy");
						goto IL_B71;
					}
					catch (Exception)
					{
						text = string.Empty;
						goto IL_B71;
					}
				}
				text = GClass16.smethod_1(byte_2);
			}
			else if (string_5 == "date6")
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
				if (string_5.StartsWith("equ"))
				{
					decimal num = 0m;
					decimal num5 = 0m;
					decimal num6 = 0m;
					decimal num7 = 0m;
					decimal d3 = 0m;
					int num3 = 0;
					if (byte_2.Length == 1)
					{
						num = byte_2[0];
						if (string_5.StartsWith("equs") && num > 128m)
						{
							num = (int)((byte_2[0] & 127) - 128);
						}
					}
					else if (byte_2.Length == 2)
					{
						num = 256 * (int)byte_2[0] + (int)byte_2[1];
						if (string_5.StartsWith("equs") && num > 32768m)
						{
							num = 256 * (int)(byte_2[0] & 127) + (int)byte_2[1] - 32768;
						}
					}
					List<string> list = new List<string>();
					StringBuilder stringBuilder = new StringBuilder();
					for (int i = 0; i < string_5.Length; i++)
					{
						if (string_5[i] == ',')
						{
							list.Add(stringBuilder.ToString());
							stringBuilder = new StringBuilder();
						}
						else
						{
							stringBuilder.Append(string_5[i]);
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
							num5 = Convert.ToDecimal(list[2], NumberFormatInfo.InvariantInfo);
						}
						if (list.Count > 3)
						{
							num6 = Convert.ToDecimal(list[3], NumberFormatInfo.InvariantInfo);
						}
						if (list.Count > 4)
						{
							num7 = Convert.ToDecimal(list[4], NumberFormatInfo.InvariantInfo);
						}
						if (list.Count > 5)
						{
							d3 = Convert.ToDecimal(list[5], NumberFormatInfo.InvariantInfo);
						}
						num = num5 * (num * num * num) + num6 * (num * num) + num7 * num + d3;
						decimal d2 = this.decimal_0[num3];
						text = num.ToString("F" + num3);
						goto IL_B71;
					}
					catch (Exception)
					{
						GClass3.smethod_2("Parameter format error", 1);
						goto IL_B71;
					}
				}
				if (string_5.StartsWith("cond1"))
				{
					decimal num5 = 0m;
					decimal num6 = 0m;
					decimal num7 = 0m;
					decimal d3 = 0m;
					decimal d4 = 0m;
					int num3 = 0;
					if (byte_2.Length == 2 || byte_2.Length == 1)
					{
						decimal num8 = byte_2[0];
						decimal d5;
						if (byte_2.Length == 1)
						{
							d5 = num8;
						}
						else
						{
							d5 = byte_2[1];
						}
						List<string> list = new List<string>();
						StringBuilder stringBuilder = new StringBuilder();
						for (int i = 0; i < string_5.Length; i++)
						{
							if (string_5[i] == ',')
							{
								list.Add(stringBuilder.ToString());
								stringBuilder = new StringBuilder();
							}
							else
							{
								stringBuilder.Append(string_5[i]);
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
								num5 = Convert.ToDecimal(list[2], NumberFormatInfo.InvariantInfo);
							}
							if (list.Count > 3)
							{
								num6 = Convert.ToDecimal(list[3], NumberFormatInfo.InvariantInfo);
							}
							if (list.Count > 4)
							{
								num7 = Convert.ToDecimal(list[4], NumberFormatInfo.InvariantInfo);
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
							text = ((d5 < num5) ? (d5 * num6 + num7) : (num8 * d3 + d4)).ToString("F" + num3);
						}
						catch (Exception)
						{
							GClass3.smethod_2("Parameter format error", 1);
						}
					}
				}
			}
		}
		IL_B71:
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
					this.method_27(true);
				}
			}
			result = text;
		}
		return result;
	}

	// Token: 0x040000AB RID: 171
	protected byte byte_0 = 0;

	// Token: 0x040000AC RID: 172
	protected bool bool_0 = false;

	// Token: 0x040000AD RID: 173
	protected bool bool_1 = false;

	// Token: 0x040000AE RID: 174
	protected bool bool_2 = false;

	// Token: 0x040000AF RID: 175
	protected int int_0 = 0;

	// Token: 0x040000B0 RID: 176
	protected string string_0 = string.Empty;

	// Token: 0x040000B1 RID: 177
	protected List<GClass58> list_0 = null;

	// Token: 0x040000B2 RID: 178
	protected List<GClass58> list_1 = null;

	// Token: 0x040000B3 RID: 179
	protected bool bool_3 = true;

	// Token: 0x040000B4 RID: 180
	protected int int_1 = 0;

	// Token: 0x040000B5 RID: 181
	protected int int_2 = 0;

	// Token: 0x040000B6 RID: 182
	protected int int_3 = 0;

	// Token: 0x040000B7 RID: 183
	protected List<string> list_2 = new List<string>();

	// Token: 0x040000B8 RID: 184
	protected string string_1 = string.Empty;

	// Token: 0x040000B9 RID: 185
	protected string string_2 = string.Empty;

	// Token: 0x040000BA RID: 186
	protected string string_3 = string.Empty;

	// Token: 0x040000BB RID: 187
	protected bool bool_4 = true;

	// Token: 0x040000BC RID: 188
	protected string string_4 = string.Empty;

	// Token: 0x040000BD RID: 189
	protected Random random_0 = new Random();

	// Token: 0x040000BE RID: 190
	protected SerialPort serialPort_0;

	// Token: 0x040000BF RID: 191
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

	// Token: 0x040000C0 RID: 192
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

	// Token: 0x040000C1 RID: 193
	protected GClass58 gclass58_0 = null;

	// Token: 0x040000C2 RID: 194
	protected int int_4 = 0;

	// Token: 0x040000C3 RID: 195
	private GDelegate4 gdelegate4_0;

	// Token: 0x040000C4 RID: 196
	private GDelegate3 gdelegate3_0;

	// Token: 0x040000C5 RID: 197
	private GDelegate5 gdelegate5_0;

	// Token: 0x040000C6 RID: 198
	private GDelegate5 gdelegate5_1;

	// Token: 0x02000014 RID: 20
	private sealed class Class0
	{
		// Token: 0x060000C0 RID: 192 RVA: 0x00002A92 File Offset: 0x00000C92
		public void method_0()
		{
			this.gclass4_0.vmethod_5(this.gclass58_0);
		}

		// Token: 0x040000C7 RID: 199
		public GClass4 gclass4_0;

		// Token: 0x040000C8 RID: 200
		public GClass58 gclass58_0;
	}
}
