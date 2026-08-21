using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

// Token: 0x0200006F RID: 111
public sealed class GClass94 : GClass11
{
	// Token: 0x060003B9 RID: 953 RVA: 0x0005EC40 File Offset: 0x0005CE40
	private void method_45(GClass104 gclass104_1)
	{
		Thread.Sleep(500);
		GClass126.smethod_2(GClass121.smethod_6("1094"), 2);
		byte[] array = new byte[this.byte_2.Length + 4];
		array[0] = (byte)(array.Length - 1);
		array[1] = 46;
		array[2] = 32;
		array[3] = 35;
		for (int i = 0; i < this.byte_2.Length; i++)
		{
			array[i + 4] = this.byte_2[i];
		}
		GClass104 gclass = new GClass104();
		gclass.byte_0 = new byte[][]
		{
			array
		};
		gclass.int_0 = 1;
		gclass.int_1 = 1;
		gclass.string_0 = "Setup";
		gclass.string_2 = "hex";
		gclass.string_3 = "";
		gclass.string_4 = "";
		gclass.string_5 = new string[]
		{
			""
		};
		gclass.string_1 = "";
		gclass.int_2 = 10455;
		if (this.string_0.StartsWith("PROXIX"))
		{
			ushort num = 0;
			ushort num2 = 1;
			for (int j = array.Length - 1; j > 28; j--)
			{
				for (int k = 0; k < 8; k++)
				{
					bool flag = (num2 & 1) == 1;
					num2 = (ushort)(num2 >> 1);
					if (flag)
					{
						num2 ^= 33800;
					}
					if ((array[j] & this.byte_10[k]) != 0)
					{
						num ^= num2;
					}
				}
			}
			string text = "000000" + num.ToString();
			if (GClass123.string_2 == GClass123.string_3)
			{
				array[10] = Convert.ToByte(text[text.Length - 5]);
				array[11] = Convert.ToByte(text[text.Length - 4]);
				array[12] = Convert.ToByte(text[text.Length - 3]);
				array[13] = Convert.ToByte(text[text.Length - 2]);
				array[14] = Convert.ToByte(text[text.Length - 1]);
			}
		}
		bool flag2 = true;
		bool flag3 = true;
		string text2 = "";
		int num3 = -1;
		GClass126.smethod_2("NEW PROXI DATA:", 0);
		GClass126.smethod_2(GClass127.smethod_11(array), 0);
		for (int l = 0; l < this.list_6.Count; l++)
		{
			GClass104 gclass2 = this.list_6[l];
			byte b = byte.Parse(gclass2.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
			bool flag4 = true;
			if ((this.byte_7[gclass2.int_0 - 1] & b) != 0)
			{
				byte b2 = byte.Parse(gclass2.string_2.Substring(0, 2), NumberStyles.HexNumber);
				string a = gclass2.string_2.Substring(2);
				string text3 = "";
				byte[] array2 = new byte[0];
				int num4;
				GClass11 gclass3;
				if (a == "50")
				{
					num4 = 3;
					gclass3 = GClass11.smethod_0("BCAN29", this.string_2, b2, this.list_7, this.list_0, "19", null);
				}
				else if (a == "500")
				{
					num4 = 0;
					gclass3 = GClass11.smethod_0("CCAN29", this.string_2, b2, this.list_7, this.list_0, "6E", null);
				}
				else if (a == "125")
				{
					num4 = 5;
					gclass3 = GClass11.smethod_0("BHCAN29", this.string_2, b2, this.list_7, this.list_0, "3B", null);
				}
				else
				{
					num4 = 6;
					if (flag3)
					{
						gclass3 = GClass11.smethod_0("CCAN29", this.string_2, b2, this.list_7, this.list_0, "CD", null);
					}
					else
					{
						gclass3 = GClass11.smethod_0("CCAN29", this.string_2, b2, this.list_7, this.list_0, "6E", null);
					}
				}
				gclass3.ModuleID = this.string_0;
				if (num3 == -1)
				{
					num3 = num4;
				}
				if (num3 != num4 && !GClass125.smethod_49() && GClass125.smethod_44() != 15)
				{
					num3 = num4;
					string string_ = "";
					if (num4 == 0)
					{
						string_ = string.Format(GClass121.smethod_6("1049"), "6/14");
					}
					else if (num4 == 3)
					{
						string_ = string.Format(GClass121.smethod_6("1043"), "1/9");
					}
					else if (num4 == 5)
					{
						string_ = string.Format(GClass121.smethod_6("1047"), "3/11");
					}
					else if (num4 == 6)
					{
						string_ = string.Format(GClass121.smethod_6("1048"), "12/13");
					}
					base.method_38(false, string_, GClass121.smethod_6("1059"));
					int num5 = 600;
					while (num5 > 0 && !GClass126.bool_24)
					{
						Thread.Sleep(100);
					}
				}
				base.method_38(true, GClass121.smethod_6(gclass104_1.string_4), GClass121.smethod_6("1091") + " " + gclass2.string_0);
				gclass3.method_37(gclass);
				if (gclass3.method_15() == "WRONG PINS" && num3 != num4 && num4 == 6 && GClass125.smethod_49())
				{
					num3 = num4;
					flag3 = false;
					string string_2 = string.Format(GClass121.smethod_6("1048"), "12/13");
					base.method_38(false, string_2, GClass121.smethod_6("1059"));
					int num6 = 600;
					while (num6 > 0 && !GClass126.bool_24)
					{
						Thread.Sleep(100);
					}
					base.method_38(true, GClass121.smethod_6(gclass104_1.string_4), GClass121.smethod_6("1091") + " " + gclass2.string_0);
					gclass3 = GClass11.smethod_0("CCAN29", this.string_2, b2, this.list_7, this.list_0, "6E", null);
					gclass3.ModuleID = this.string_0;
					gclass3.method_37(gclass);
				}
				if (gclass3.method_16().Length < 5)
				{
					Thread.Sleep(2000);
					if (a == "50")
					{
						gclass3 = GClass11.smethod_0("BCAN29", this.string_2, b2, this.list_7, this.list_0, "19", null);
					}
					else if (a == "500")
					{
						gclass3 = GClass11.smethod_0("CCAN29", this.string_2, b2, this.list_7, this.list_0, "6E", null);
					}
					else if (a == "125")
					{
						gclass3 = GClass11.smethod_0("BHCAN29", this.string_2, b2, this.list_7, this.list_0, "3B", null);
					}
					else if (flag3)
					{
						gclass3 = GClass11.smethod_0("CCAN29", this.string_2, b2, this.list_7, this.list_0, "CD", null);
					}
					else
					{
						gclass3 = GClass11.smethod_0("CCAN29", this.string_2, b2, this.list_7, this.list_0, "6E", null);
					}
					gclass3.ModuleID = this.string_0;
					gclass3.method_39(gclass, 1);
				}
				if ((gclass3.method_16().Length < 5 || gclass3.method_16().Contains("7F 2E")) && !gclass3.method_16().Contains("7F 2E 78"))
				{
					if (text3 == "" && gclass3.method_16().Length > 4)
					{
						text3 = gclass3.method_16();
					}
					try
					{
						array2 = GClass127.smethod_32(gclass3.method_15());
						goto IL_B67;
					}
					catch (Exception)
					{
						array2 = new byte[0];
						goto IL_B67;
					}
					goto IL_742;
					IL_B67:
					flag4 = false;
					flag2 = false;
				}
				IL_742:
				string text4 = GClass121.smethod_6("6501");
				if (text3 == "")
				{
					text4 = GClass121.smethod_6("6502");
				}
				else if (text3.Contains("7F 2E 10"))
				{
					text4 = GClass121.smethod_6("6503");
				}
				else if (text3.Contains("7F 2E 12"))
				{
					text4 = GClass121.smethod_6("6504");
				}
				else if (text3.Contains("7F 2E 21"))
				{
					text4 = GClass121.smethod_6("6505");
				}
				else if (text3.Contains("7F 2E 22"))
				{
					text4 = GClass121.smethod_6("6506");
				}
				else if (text3.Contains("7F 2E 31"))
				{
					text4 = GClass121.smethod_6("6507");
				}
				else if (text3.Contains("7F 2E A0"))
				{
					text4 = GClass121.smethod_6("6508");
				}
				else if (text3.Contains("7F 2E A1"))
				{
					text4 = GClass121.smethod_6("6509");
				}
				string str = GClass121.smethod_6("1092");
				if (flag4)
				{
					GClass126.smethod_2(string.Concat(new string[]
					{
						GClass121.smethod_6("1091"),
						" ",
						gclass2.string_0,
						" ",
						GClass121.smethod_6("1092"),
						"!"
					}), 2);
				}
				else
				{
					if (text2 == "")
					{
						text2 = string.Concat(new string[]
						{
							gclass2.string_0,
							" ",
							GClass121.smethod_6("1093"),
							"! - ",
							text4
						});
					}
					str = GClass121.smethod_6("1093") + "! - " + text4;
					GClass126.smethod_2(string.Concat(new string[]
					{
						GClass121.smethod_6("1091"),
						" ",
						gclass2.string_0,
						" ",
						GClass121.smethod_6("1093"),
						"! - ",
						text4
					}), 2);
					string text5 = "";
					try
					{
						if (array2.Length == 13 && array2[1] == 98 && array2[2] == 16 && array2[3] == 42)
						{
							if (array2[5] != 0 && array2[6] != 0)
							{
								byte b3 = this.byte_2[(int)(array2[5] - 1)];
								b3 ^= array2[6];
								text5 = string.Concat(new string[]
								{
									text5,
									"   [102A] errors: Byte ",
									array2[5].ToString(),
									": ",
									GClass127.smethod_23(this.byte_2[(int)(array2[5] - 1)]),
									"->",
									GClass127.smethod_23(b3),
									" "
								});
							}
							if (array2[8] != 0 && array2[9] != 0)
							{
								byte b4 = this.byte_2[(int)(array2[8] - 1)];
								b4 ^= array2[9];
								text5 = string.Concat(new string[]
								{
									text5,
									"| Byte ",
									array2[8].ToString(),
									": ",
									GClass127.smethod_23(this.byte_2[(int)(array2[8] - 1)]),
									"->",
									GClass127.smethod_23(b4),
									" "
								});
							}
							if (array2[11] != 0 && array2[12] != 0)
							{
								byte b5 = this.byte_2[(int)(array2[11] - 1)];
								b5 ^= array2[12];
								text5 = string.Concat(new string[]
								{
									text5,
									"| Byte ",
									array2[11].ToString(),
									": ",
									GClass127.smethod_23(this.byte_2[(int)(array2[11] - 1)]),
									"->",
									GClass127.smethod_23(b5),
									" "
								});
							}
							if (text5 != "")
							{
								GClass126.smethod_2(text5, 2);
							}
						}
					}
					catch (Exception)
					{
					}
				}
				base.method_26(gclass2.string_0 + "... " + str);
				Thread.Sleep(2500);
			}
		}
		Thread.Sleep(1000);
		this.bool_5 = flag2;
		try
		{
			string text6 = string.Concat(new string[]
			{
				"FL_",
				DateTime.Now.ToString("yyMMddHHmmss"),
				"_",
				GClass126.string_7,
				"_PROXI.txt"
			});
			text6 = text6.Replace("/", "").Replace("\\", "");
			FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://ftp.multiecuscan.net/" + text6);
			ftpWebRequest.Method = "STOR";
			ftpWebRequest.Credentials = new NetworkCredential("reports", "reports");
			Stream requestStream = ftpWebRequest.GetRequestStream();
			try
			{
				byte[] bytes = Encoding.Unicode.GetBytes(GClass126.smethod_7());
				requestStream.Write(bytes, 0, bytes.Length);
			}
			finally
			{
				requestStream.Close();
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2("Failed to send diagnostic report: " + ex.Message, 0);
		}
		if (!flag2)
		{
			base.method_28(false, GClass121.smethod_6("6052"), text2);
			return;
		}
		base.method_28(false, GClass121.smethod_6("6051"), "");
	}

	// Token: 0x060003BA RID: 954 RVA: 0x0005F948 File Offset: 0x0005DB48
	public GClass94(string string_22, byte byte_11, string string_23, List<GClass104> list_8, List<GClass104> list_9, string string_24)
	{
		this.string_1 = string_22;
		this.byte_0 = byte_11;
		this.string_2 = string_23;
		this.list_0 = list_9;
		this.list_1 = list_8;
		this.string_3 = string_24;
	}

	// Token: 0x060003BB RID: 955 RVA: 0x0005FA10 File Offset: 0x0005DC10
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
			if (gclass104_1.string_2.Contains("PROXYPROC"))
			{
				this.method_45(gclass104_1);
				return;
			}
			if (gclass104_1.string_2.Contains("RWUSERENTRY"))
			{
				this.method_48(gclass104_1);
			}
			return;
		}
	}

	// Token: 0x060003BC RID: 956 RVA: 0x0000336D File Offset: 0x0000156D
	private byte method_46(byte byte_11, byte byte_12)
	{
		return (byte_11 ^ byte_12) & byte_12;
	}

	// Token: 0x060003BD RID: 957 RVA: 0x00002F03 File Offset: 0x00001103
	public override List<GClass102> r1()
	{
		return new List<GClass102>();
	}

	// Token: 0x060003BE RID: 958 RVA: 0x00003376 File Offset: 0x00001576
	private byte method_47(byte byte_11, byte byte_12)
	{
		return (byte_11 ^ byte_12) & byte_11;
	}

	// Token: 0x060003BF RID: 959 RVA: 0x0005FAC4 File Offset: 0x0005DCC4
	private void method_48(GClass104 gclass104_1)
	{
		for (int i = gclass104_1.int_0 - 1; i < gclass104_1.int_0 + gclass104_1.int_1 - 1; i++)
		{
			byte b = 0;
			if (this.byte_2.Length > i)
			{
				b = this.byte_2[i];
			}
			byte b2 = gclass104_1.byte_0[1][i + 3];
			byte b3 = byte.Parse(gclass104_1.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
			b3 ^= byte.MaxValue;
			b &= b3;
			b |= b2;
			this.byte_2[i] = b;
		}
		Thread.Sleep(1000);
		base.method_28(false, GClass121.smethod_6("6051"), "");
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x0005FB6C File Offset: 0x0005DD6C
	public override void vmethod_1()
	{
		Thread.Sleep(500);
		foreach (GClass104 item in this.list_0)
		{
			this.list_6.Add(item);
		}
		foreach (GClass104 item2 in this.list_1)
		{
			this.list_7.Add(item2);
		}
		if (GClass125.smethod_44() == 4 || GClass125.smethod_44() == 5 || GClass125.smethod_44() == 10)
		{
			GClass96.smethod_1(false);
		}
		GClass126.smethod_2(GClass121.smethod_6("1084"), 2);
		try
		{
			if (GClass125.smethod_44() == 5)
			{
				for (int i = 0; i < 40; i++)
				{
					Thread.Sleep(100);
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
				}
			}
			GClass11 gclass = GClass11.smethod_0(this.string_1, this.string_2, this.byte_0, this.list_7, this.list_0, this.string_3, null);
			gclass.ModuleID = this.string_0;
			gclass.method_0();
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			for (int j = 0; j < this.list_7.Count; j++)
			{
				if (this.list_7[j].string_1 == "DATA1")
				{
					this.byte_2 = GClass127.smethod_32(this.list_7[j].method_0());
				}
				else if (this.list_7[j].string_1 == "DATA2")
				{
					this.byte_3 = GClass127.smethod_32(this.list_7[j].method_0());
				}
				else if (this.list_7[j].string_1 == "DATA3")
				{
					this.byte_4 = GClass127.smethod_32(this.list_7[j].method_0());
				}
			}
			bool flag = this.byte_2.Length > 25;
			bool flag2 = this.byte_2.Length == 0 && this.byte_3.Length == 0 && this.byte_4.Length == 0;
			if (GClass125.smethod_46())
			{
				for (int k = 0; k < 40; k++)
				{
					Thread.Sleep(100);
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
				}
			}
			if (flag)
			{
				GClass11 gclass2 = GClass11.smethod_0(this.string_1, this.string_2, this.byte_0, this.list_7, this.list_0, this.string_3, null);
				gclass2.ModuleID = this.string_0;
				gclass2.method_0();
				if (GClass126.bool_25)
				{
					throw new Exception("ESC");
				}
				for (int l = 0; l < this.list_7.Count; l++)
				{
					if (this.list_7[l].string_1 == "DATA1")
					{
						if (GClass127.smethod_11(this.byte_2) != this.list_7[l].method_0())
						{
							flag = false;
							break;
						}
					}
					else if (this.list_7[l].string_1 == "DATA2")
					{
						if (GClass127.smethod_11(this.byte_3) != this.list_7[l].method_0())
						{
							flag = false;
							break;
						}
					}
					else if (this.list_7[l].string_1 == "DATA3" && GClass127.smethod_11(this.byte_4) != this.list_7[l].method_0())
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				if (GClass125.smethod_46())
				{
					for (int m = 0; m < 40; m++)
					{
						Thread.Sleep(100);
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
					}
				}
				GClass11 gclass3 = GClass11.smethod_0(this.string_1, this.string_2, this.byte_0, this.list_7, this.list_0, this.string_3, null);
				gclass3.ModuleID = this.string_0;
				gclass3.method_0();
				if (GClass126.bool_25)
				{
					throw new Exception("ESC");
				}
				for (int n = 0; n < this.list_7.Count; n++)
				{
					if (this.list_7[n].string_1 == "DATA1")
					{
						if (GClass127.smethod_11(this.byte_2) != this.list_7[n].method_0())
						{
							flag = false;
							break;
						}
					}
					else if (this.list_7[n].string_1 == "DATA2")
					{
						if (GClass127.smethod_11(this.byte_3) != this.list_7[n].method_0())
						{
							flag = false;
							break;
						}
					}
					else if (this.list_7[n].string_1 == "DATA3" && GClass127.smethod_11(this.byte_4) != this.list_7[n].method_0())
					{
						flag = false;
						break;
					}
				}
			}
			if (!flag && this.byte_2.Length < 26 && GClass126.bool_19)
			{
				flag = true;
				this.byte_2 = GClass127.smethod_32(GClass127.smethod_11(this.byte_2) + " 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
			}
			if (!flag)
			{
				if (this.string_0.StartsWith("PROXIX") && (GClass125.smethod_44() == 2 || GClass125.smethod_44() == 3 || GClass125.smethod_44() == 8))
				{
					GClass126.smethod_2("Interface too slow. Try to configure as ELM 327 (USB) in HIGH SPEED mode!", 2);
					this.string_8 = "Interface too slow. Try to configure as ELM 327 (USB) in HIGH SPEED mode!";
				}
				else if (this.byte_2.Length < 10 && !flag2)
				{
					GClass126.smethod_2("Empty PROXI file in Body Computer (BCM)!", 2);
					this.string_8 = "Empty PROXI file in Body Computer (BCM)!";
				}
				else if (flag2)
				{
					GClass126.smethod_2("Failed to connect to Body Computer (BCM)", 2);
					this.string_8 = "Failed to connect to Body Computer (BCM)";
				}
				else
				{
					GClass126.smethod_2(GClass121.smethod_6("1085"), 2);
					this.string_8 = GClass121.smethod_6("1085");
				}
				throw new Exception("1");
			}
			GClass126.smethod_2("CAN CONFIGURATION DATA:", 2);
			GClass126.smethod_2(GClass127.smethod_11(this.byte_3), 2);
			GClass126.smethod_2(GClass127.smethod_11(this.byte_4), 2);
			GClass126.smethod_2(GClass127.smethod_11(this.byte_2), 2);
			if (this.string_0.StartsWith("PROXIX"))
			{
				this.byte_5[0] = this.byte_4[47];
				this.byte_5[1] = this.byte_4[46];
				this.byte_5[2] = this.byte_4[45];
				this.byte_5[3] = this.byte_4[44];
				this.byte_5[4] = this.byte_4[43];
				this.byte_5[5] = this.byte_4[42];
				this.byte_5[6] = this.byte_4[41];
				this.byte_5[7] = this.byte_4[40];
				this.byte_5[8] = this.byte_4[39];
				this.byte_5[9] = this.byte_4[38];
				this.byte_5[10] = this.byte_4[37];
				this.byte_5[11] = this.byte_4[36];
				this.byte_5[12] = this.byte_4[35];
				this.byte_5[13] = this.byte_4[34];
				this.byte_5[14] = this.byte_4[33];
				this.byte_5[15] = this.byte_4[32];
				this.byte_6[0] = this.byte_2[40];
				this.byte_6[1] = this.byte_2[39];
				this.byte_6[2] = this.byte_2[38];
				this.byte_6[3] = this.byte_2[37];
				this.byte_6[4] = this.byte_2[36];
				this.byte_6[5] = this.byte_2[35];
				this.byte_6[6] = this.byte_2[34];
				this.byte_6[7] = this.byte_2[33];
				this.byte_6[8] = this.byte_2[32];
				this.byte_6[9] = this.byte_2[31];
				this.byte_6[10] = this.byte_2[30];
				this.byte_6[11] = this.byte_2[29];
				this.byte_6[12] = this.byte_2[28];
				this.byte_6[13] = this.byte_2[27];
				this.byte_6[14] = this.byte_2[26];
				this.byte_6[15] = this.byte_2[25];
				this.byte_7[0] = this.byte_4[63];
				this.byte_7[1] = this.byte_4[62];
				this.byte_7[2] = this.byte_4[61];
				this.byte_7[3] = this.byte_4[60];
				this.byte_7[4] = this.byte_4[59];
				this.byte_7[5] = this.byte_4[58];
				this.byte_7[6] = this.byte_4[57];
				this.byte_7[7] = this.byte_4[56];
				this.byte_7[8] = this.byte_4[55];
				this.byte_7[9] = this.byte_4[54];
				this.byte_7[10] = this.byte_4[53];
				this.byte_7[11] = this.byte_4[52];
				this.byte_7[12] = this.byte_4[51];
				this.byte_7[13] = this.byte_4[50];
				this.byte_7[14] = this.byte_4[49];
				this.byte_7[15] = this.byte_4[48];
				this.byte_9[0] = this.byte_4[79];
				this.byte_9[1] = this.byte_4[78];
				this.byte_9[2] = this.byte_4[77];
				this.byte_9[3] = this.byte_4[76];
				this.byte_9[4] = this.byte_4[75];
				this.byte_9[5] = this.byte_4[74];
				this.byte_9[6] = this.byte_4[73];
				this.byte_9[7] = this.byte_4[72];
				this.byte_9[8] = this.byte_4[71];
				this.byte_9[9] = this.byte_4[70];
				this.byte_9[10] = this.byte_4[69];
				this.byte_9[11] = this.byte_4[68];
				this.byte_9[12] = this.byte_4[67];
				this.byte_9[13] = this.byte_4[66];
				this.byte_9[14] = this.byte_4[65];
				this.byte_9[15] = this.byte_4[64];
				this.byte_8[0] = this.byte_2[56];
				this.byte_8[1] = this.byte_2[55];
				this.byte_8[2] = this.byte_2[54];
				this.byte_8[3] = this.byte_2[53];
				this.byte_8[4] = this.byte_2[52];
				this.byte_8[5] = this.byte_2[51];
				this.byte_8[6] = this.byte_2[50];
				this.byte_8[7] = this.byte_2[49];
				this.byte_8[8] = this.byte_2[48];
				this.byte_8[9] = this.byte_2[47];
				this.byte_8[10] = this.byte_2[46];
				this.byte_8[11] = this.byte_2[45];
				this.byte_8[12] = this.byte_2[44];
				this.byte_8[13] = this.byte_2[43];
				this.byte_8[14] = this.byte_2[42];
				this.byte_8[15] = this.byte_2[41];
				this.bool_6 = (this.byte_4[48] == this.byte_4[64] && this.byte_4[49] == this.byte_4[65] && this.byte_4[50] == this.byte_4[66] && this.byte_4[51] == this.byte_4[67] && this.byte_4[52] == this.byte_4[68] && this.byte_4[53] == this.byte_4[69] && this.byte_4[54] == this.byte_4[70] && this.byte_4[55] == this.byte_4[71] && this.byte_4[56] == this.byte_4[72] && this.byte_4[57] == this.byte_4[73] && this.byte_4[58] == this.byte_4[74] && this.byte_4[59] == this.byte_4[75] && this.byte_4[60] == this.byte_4[76] && this.byte_4[61] == this.byte_4[77] && this.byte_4[62] == this.byte_4[78] && this.byte_4[63] == this.byte_4[79] && this.byte_4[48] == this.byte_2[41] && this.byte_4[49] == this.byte_2[42] && this.byte_4[50] == this.byte_2[43] && this.byte_4[51] == this.byte_2[44] && this.byte_4[52] == this.byte_2[45] && this.byte_4[53] == this.byte_2[46] && this.byte_4[54] == this.byte_2[47] && this.byte_4[55] == this.byte_2[48] && this.byte_4[56] == this.byte_2[49] && this.byte_4[57] == this.byte_2[50] && this.byte_4[58] == this.byte_2[51] && this.byte_4[59] == this.byte_2[52] && this.byte_4[60] == this.byte_2[53] && this.byte_4[61] == this.byte_2[54] && this.byte_4[62] == this.byte_2[55] && this.byte_4[63] == this.byte_2[56] && this.byte_4[32] == this.byte_2[25] && this.byte_4[33] == this.byte_2[26] && this.byte_4[34] == this.byte_2[27] && this.byte_4[35] == this.byte_2[28] && this.byte_4[36] == this.byte_2[29] && this.byte_4[37] == this.byte_2[30] && this.byte_4[38] == this.byte_2[31] && this.byte_4[39] == this.byte_2[32] && this.byte_4[40] == this.byte_2[33] && this.byte_4[41] == this.byte_2[34] && this.byte_4[42] == this.byte_2[35] && this.byte_4[43] == this.byte_2[36] && this.byte_4[44] == this.byte_2[37] && this.byte_4[45] == this.byte_2[38] && this.byte_4[46] == this.byte_2[39] && this.byte_4[47] == this.byte_2[40]);
				this.byte_2[40] = this.byte_4[47];
				this.byte_2[39] = this.byte_4[46];
				this.byte_2[38] = this.byte_4[45];
				this.byte_2[37] = this.byte_4[44];
				this.byte_2[36] = this.byte_4[43];
				this.byte_2[35] = this.byte_4[42];
				this.byte_2[34] = this.byte_4[41];
				this.byte_2[33] = this.byte_4[40];
				this.byte_2[32] = this.byte_4[39];
				this.byte_2[31] = this.byte_4[38];
				this.byte_2[30] = this.byte_4[37];
				this.byte_2[29] = this.byte_4[36];
				this.byte_2[28] = this.byte_4[35];
				this.byte_2[27] = this.byte_4[34];
				this.byte_2[26] = this.byte_4[33];
				this.byte_2[25] = this.byte_4[32];
				this.byte_2[56] = this.byte_4[63];
				this.byte_2[55] = this.byte_4[62];
				this.byte_2[54] = this.byte_4[61];
				this.byte_2[53] = this.byte_4[60];
				this.byte_2[52] = this.byte_4[59];
				this.byte_2[51] = this.byte_4[58];
				this.byte_2[50] = this.byte_4[57];
				this.byte_2[49] = this.byte_4[56];
				this.byte_2[48] = this.byte_4[55];
				this.byte_2[47] = this.byte_4[54];
				this.byte_2[46] = this.byte_4[53];
				this.byte_2[45] = this.byte_4[52];
				this.byte_2[44] = this.byte_4[51];
				this.byte_2[43] = this.byte_4[50];
				this.byte_2[42] = this.byte_4[49];
				this.byte_2[41] = this.byte_4[48];
			}
			else
			{
				this.byte_5[0] = this.byte_4[23];
				this.byte_5[1] = this.byte_4[22];
				this.byte_5[2] = this.byte_4[21];
				this.byte_5[3] = this.byte_4[20];
				this.byte_5[4] = this.byte_4[19];
				this.byte_5[5] = this.byte_4[18];
				this.byte_5[6] = this.byte_4[17];
				this.byte_5[7] = this.byte_4[16];
				this.byte_6[0] = this.byte_2[32];
				this.byte_6[1] = this.byte_2[31];
				this.byte_6[2] = this.byte_2[30];
				this.byte_6[3] = this.byte_2[29];
				this.byte_6[4] = this.byte_2[28];
				this.byte_6[5] = this.byte_2[27];
				this.byte_6[6] = this.byte_2[26];
				this.byte_6[7] = this.byte_2[25];
				this.byte_7[0] = this.byte_4[31];
				this.byte_7[1] = this.byte_4[30];
				this.byte_7[2] = this.byte_4[29];
				this.byte_7[3] = this.byte_4[28];
				this.byte_7[4] = this.byte_4[27];
				this.byte_7[5] = this.byte_4[26];
				this.byte_7[6] = this.byte_4[25];
				this.byte_7[7] = this.byte_4[24];
				this.byte_9[0] = this.byte_4[39];
				this.byte_9[1] = this.byte_4[38];
				this.byte_9[2] = this.byte_4[37];
				this.byte_9[3] = this.byte_4[36];
				this.byte_9[4] = this.byte_4[35];
				this.byte_9[5] = this.byte_4[34];
				this.byte_9[6] = this.byte_4[33];
				this.byte_9[7] = this.byte_4[32];
				this.byte_8[0] = this.byte_2[40];
				this.byte_8[1] = this.byte_2[39];
				this.byte_8[2] = this.byte_2[38];
				this.byte_8[3] = this.byte_2[37];
				this.byte_8[4] = this.byte_2[36];
				this.byte_8[5] = this.byte_2[35];
				this.byte_8[6] = this.byte_2[34];
				this.byte_8[7] = this.byte_2[33];
				this.bool_6 = (this.byte_4[24] == this.byte_4[32] && this.byte_4[25] == this.byte_4[33] && this.byte_4[26] == this.byte_4[34] && this.byte_4[27] == this.byte_4[35] && this.byte_4[28] == this.byte_4[36] && this.byte_4[29] == this.byte_4[37] && this.byte_4[30] == this.byte_4[38] && this.byte_4[31] == this.byte_4[39] && this.byte_4[24] == this.byte_2[33] && this.byte_4[25] == this.byte_2[34] && this.byte_4[26] == this.byte_2[35] && this.byte_4[27] == this.byte_2[36] && this.byte_4[28] == this.byte_2[37] && this.byte_4[29] == this.byte_2[38] && this.byte_4[30] == this.byte_2[39] && this.byte_4[31] == this.byte_2[40] && this.byte_4[16] == this.byte_2[25] && this.byte_4[17] == this.byte_2[26] && this.byte_4[18] == this.byte_2[27] && this.byte_4[19] == this.byte_2[28] && this.byte_4[20] == this.byte_2[29] && this.byte_4[21] == this.byte_2[30] && this.byte_4[22] == this.byte_2[31] && this.byte_4[23] == this.byte_2[32]);
				this.byte_2[32] = this.byte_4[23];
				this.byte_2[31] = this.byte_4[22];
				this.byte_2[30] = this.byte_4[21];
				this.byte_2[29] = this.byte_4[20];
				this.byte_2[28] = this.byte_4[19];
				this.byte_2[27] = this.byte_4[18];
				this.byte_2[26] = this.byte_4[17];
				this.byte_2[25] = this.byte_4[16];
				this.byte_2[40] = this.byte_4[31];
				this.byte_2[39] = this.byte_4[30];
				this.byte_2[38] = this.byte_4[29];
				this.byte_2[37] = this.byte_4[28];
				this.byte_2[36] = this.byte_4[27];
				this.byte_2[35] = this.byte_4[26];
				this.byte_2[34] = this.byte_4[25];
				this.byte_2[33] = this.byte_4[24];
			}
			if (this.string_0.StartsWith("PROXI3E") || this.string_0.StartsWith("PROXI3U"))
			{
				byte b = 16;
				byte b2 = 239;
				byte b3 = 2;
				byte b4 = 253;
				byte b5 = 16;
				bool flag3 = (this.byte_5[3] & 16) > 0;
				bool flag4 = (this.byte_6[3] & 2) > 0;
				bool flag5 = (this.byte_8[3] & 2) > 0;
				if (flag3)
				{
					byte[] byte_ = this.byte_2;
					int num = 29;
					byte_[num] |= b3;
					byte[] byte_2 = this.byte_2;
					int num2 = 37;
					byte_2[num2] |= b3;
				}
				if (this.string_0.StartsWith("PROXI3E"))
				{
					byte[] byte_3 = this.byte_2;
					int num3 = 29;
					byte_3[num3] |= b5;
				}
				else
				{
					byte[] byte_4 = this.byte_2;
					int num4 = 29;
					byte_4[num4] &= b2;
					byte[] byte_5 = this.byte_2;
					int num5 = 37;
					byte_5[num5] &= b2;
				}
				byte[] array = this.byte_6;
				int num6 = 3;
				array[num6] &= b4;
				byte[] array2 = this.byte_8;
				int num7 = 3;
				array2[num7] &= b4;
				byte[] array3 = this.byte_6;
				int num8 = 3;
				array3[num8] &= b2;
				byte[] array4 = this.byte_8;
				int num9 = 3;
				array4[num9] &= b2;
				if (flag4)
				{
					byte[] array5 = this.byte_6;
					int num10 = 3;
					array5[num10] |= b;
				}
				if (flag5)
				{
					byte[] array6 = this.byte_8;
					int num11 = 3;
					array6[num11] |= b;
				}
			}
			if (this.string_0.StartsWith("PROXIX4") || this.string_0.StartsWith("PROXIX5BEV"))
			{
				byte b6 = 1;
				if ((this.byte_5[15] & 1) > 0)
				{
					byte[] array7 = this.byte_5;
					int num12 = 1;
					array7[num12] |= b6;
					byte[] byte_6 = this.byte_2;
					int num13 = 39;
					byte_6[num13] |= b6;
				}
			}
			if (this.string_0.StartsWith("PROXIX5BEV"))
			{
				byte b7 = 64;
				byte b8 = 32;
				if ((this.byte_5[7] & 1) > 0)
				{
					byte[] array8 = this.byte_5;
					int num14 = 0;
					array8[num14] |= b8;
					byte[] array9 = this.byte_5;
					int num15 = 7;
					array9[num15] |= b7;
					byte[] byte_7 = this.byte_2;
					int num16 = 40;
					byte_7[num16] |= b8;
					byte[] byte_8 = this.byte_2;
					int num17 = 33;
					byte_8[num17] |= b7;
				}
			}
			if (this.string_0.StartsWith("PROXIX4"))
			{
				byte b9 = 64;
				byte b10 = 32;
				byte b11 = 64;
				if ((this.byte_5[3] & 4) > 0)
				{
					byte[] array10 = this.byte_5;
					int num18 = 0;
					array10[num18] |= b10;
					byte[] array11 = this.byte_5;
					int num19 = 5;
					array11[num19] |= b11;
					byte[] array12 = this.byte_5;
					int num20 = 7;
					array12[num20] |= b9;
					byte[] byte_9 = this.byte_2;
					int num21 = 40;
					byte_9[num21] |= b10;
					byte[] byte_10 = this.byte_2;
					int num22 = 35;
					byte_10[num22] |= b11;
					byte[] byte_11 = this.byte_2;
					int num23 = 33;
					byte_11[num23] |= b9;
				}
			}
			this.list_1.Clear();
			this.list_0.Clear();
			byte[][] byte_12 = new byte[][]
			{
				new byte[1]
			};
			string[] string_ = new string[0];
			for (int num24 = 0; num24 < this.list_6.Count; num24++)
			{
				GClass104 gclass4 = this.list_6[num24];
				byte b12 = byte.Parse(gclass4.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
				bool flag6 = (this.byte_6[gclass4.int_0 - 1] & b12) > 0;
				bool flag7 = (this.byte_5[gclass4.int_0 - 1] & b12) > 0;
				bool flag8 = (this.byte_7[gclass4.int_0 - 1] & b12) > 0;
				bool flag9 = (this.byte_9[gclass4.int_0 - 1] & b12) > 0;
				if (flag6 || flag7 || flag8 || flag9)
				{
					this.list_1.Add(new GClass104(byte_12, 1, 1, gclass4.string_0, "", "", "", string_, ""));
					if (gclass4.string_0.Contains("(SGW)") && flag7)
					{
						this.bool_7 = true;
					}
					string text = "-";
					if (flag6 && flag7)
					{
						if (flag8 && flag9)
						{
							text = GClass121.smethod_6("1214");
						}
						else if (flag8 && !flag9)
						{
							text = GClass121.smethod_6("1215");
							this.list_1[this.list_1.Count - 1].string_2 = "ERROR";
						}
						else
						{
							text = GClass121.smethod_6("1213");
						}
					}
					else if (!flag6 && flag7)
					{
						text = GClass121.smethod_6("1211");
						this.int_5++;
						if (flag8 && flag9)
						{
							text = text + " / " + GClass121.smethod_6("1214");
						}
						else if (flag8 && !flag9)
						{
							text = text + " / " + GClass121.smethod_6("1215");
						}
						this.list_1[this.list_1.Count - 1].string_2 = "ERROR";
					}
					else if (flag6 && !flag7)
					{
						text = GClass121.smethod_6("1212");
						this.int_6++;
						this.list_1[this.list_1.Count - 1].string_2 = "ERROR";
					}
					this.list_1[this.list_1.Count - 1].method_1(text);
					GClass126.smethod_2(gclass4.string_0, 2);
				}
			}
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			this.bool_0 = true;
			base.method_36();
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
			base.method_30(false);
		}
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x00002F0A File Offset: 0x0000110A
	public override void r2()
	{
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x0000337F File Offset: 0x0000157F
	public override void r0(bool bool_8, bool bool_9)
	{
		base.method_32(bool_9);
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x00003388 File Offset: 0x00001588
	public override string vmethod_0(byte[] byte_11, string string_22, int int_7, int int_8, string[] string_23, string string_24)
	{
		return this.r4(this.byte_2, string_22, int_7, int_8, string_23, string_24);
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x00061A3C File Offset: 0x0005FC3C
	public override string r4(byte[] byte_11, string string_22, int int_7, int int_8, string[] string_23, string string_24)
	{
		int_7--;
		int num = byte_11.Length - int_7;
		if (num < 0)
		{
			return "";
		}
		if (int_8 < num)
		{
			num = int_8;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_11[i + int_7];
		}
		return base.method_33(array, string_22, string_23, string_24);
	}

	// Token: 0x0400027B RID: 635
	private List<GClass104> list_6 = new List<GClass104>();

	// Token: 0x0400027C RID: 636
	private List<GClass104> list_7 = new List<GClass104>();

	// Token: 0x0400027D RID: 637
	private byte[] byte_3 = new byte[0];

	// Token: 0x0400027E RID: 638
	private byte[] byte_4 = new byte[0];

	// Token: 0x0400027F RID: 639
	private byte[] byte_5 = new byte[16];

	// Token: 0x04000280 RID: 640
	private byte[] byte_6 = new byte[16];

	// Token: 0x04000281 RID: 641
	private byte[] byte_7 = new byte[16];

	// Token: 0x04000282 RID: 642
	private byte[] byte_8 = new byte[16];

	// Token: 0x04000283 RID: 643
	private byte[] byte_9 = new byte[16];

	// Token: 0x04000284 RID: 644
	public int int_5;

	// Token: 0x04000285 RID: 645
	public int int_6;

	// Token: 0x04000286 RID: 646
	public bool bool_6;

	// Token: 0x04000287 RID: 647
	public bool bool_7;

	// Token: 0x04000288 RID: 648
	private byte[] byte_10 = new byte[]
	{
		128,
		64,
		32,
		16,
		8,
		4,
		2,
		1
	};
}
