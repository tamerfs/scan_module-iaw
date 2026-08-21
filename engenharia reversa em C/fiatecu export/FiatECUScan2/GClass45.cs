using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

// Token: 0x0200002D RID: 45
public sealed class GClass45 : GClass19
{
	// Token: 0x060001F8 RID: 504 RVA: 0x00059624 File Offset: 0x00057824
	public GClass45(byte byte_11, string string_9, List<GClass58> list_6, List<GClass58> list_7)
	{
		this.byte_0 = byte_11;
		this.string_7 = string_9;
		this.list_0 = list_7;
		this.list_1 = list_6;
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x00059704 File Offset: 0x00057904
	public override void vmethod_1(GEnum0 genum0_0)
	{
		Thread.Sleep(500);
		foreach (GClass58 gclass in this.list_0)
		{
			GClass58 gclass;
			this.list_4.Add(gclass);
		}
		foreach (GClass58 gclass in this.list_1)
		{
			GClass58 gclass;
			this.list_5.Add(gclass);
		}
		if (GClass61.smethod_36() == 4 || GClass61.smethod_36() == 5)
		{
			GClass55.smethod_1(false);
		}
		GClass3.smethod_2(GClass62.smethod_1("1084"), 2);
		try
		{
			if (GClass61.smethod_36() == 5)
			{
				for (int i = 0; i < 40; i++)
				{
					Thread.Sleep(100);
					if (GClass3.bool_14)
					{
						throw new Exception("ESC");
					}
				}
			}
			GClass19 gclass2 = GClass19.smethod_0(this.string_8, this.string_7, this.byte_0, this.list_5, this.list_0, "19");
			gclass2.method_24();
			if (GClass3.bool_14)
			{
				throw new Exception("ESC");
			}
			for (int i = 0; i < this.list_5.Count; i++)
			{
				if (this.list_5[i].string_1 == "DATA1")
				{
					this.byte_2 = GClass16.smethod_2(this.list_5[i].method_0());
				}
				else if (this.list_5[i].string_1 == "DATA2")
				{
					this.byte_3 = GClass16.smethod_2(this.list_5[i].method_0());
				}
				else if (this.list_5[i].string_1 == "DATA3")
				{
					this.byte_4 = GClass16.smethod_2(this.list_5[i].method_0());
				}
			}
			bool flag = this.byte_2.Length > 25;
			if (GClass61.smethod_38())
			{
				for (int i = 0; i < 40; i++)
				{
					Thread.Sleep(100);
					if (GClass3.bool_14)
					{
						throw new Exception("ESC");
					}
				}
			}
			if (flag)
			{
				gclass2 = GClass19.smethod_0(this.string_8, this.string_7, this.byte_0, this.list_5, this.list_0, "19");
				gclass2.method_24();
				if (GClass3.bool_14)
				{
					throw new Exception("ESC");
				}
				for (int i = 0; i < this.list_5.Count; i++)
				{
					if (this.list_5[i].string_1 == "DATA1")
					{
						if (GClass16.smethod_1(this.byte_2) != this.list_5[i].method_0())
						{
							flag = false;
							break;
						}
					}
					else if (this.list_5[i].string_1 == "DATA2")
					{
						if (GClass16.smethod_1(this.byte_3) != this.list_5[i].method_0())
						{
							flag = false;
							break;
						}
					}
					else if (this.list_5[i].string_1 == "DATA3" && GClass16.smethod_1(this.byte_4) != this.list_5[i].method_0())
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				if (GClass61.smethod_38())
				{
					for (int i = 0; i < 40; i++)
					{
						Thread.Sleep(100);
						if (GClass3.bool_14)
						{
							throw new Exception("ESC");
						}
					}
				}
				gclass2 = GClass19.smethod_0(this.string_8, this.string_7, this.byte_0, this.list_5, this.list_0, "19");
				gclass2.method_24();
				if (GClass3.bool_14)
				{
					throw new Exception("ESC");
				}
				for (int i = 0; i < this.list_5.Count; i++)
				{
					if (this.list_5[i].string_1 == "DATA1")
					{
						if (GClass16.smethod_1(this.byte_2) != this.list_5[i].method_0())
						{
							flag = false;
							break;
						}
					}
					else if (this.list_5[i].string_1 == "DATA2")
					{
						if (GClass16.smethod_1(this.byte_3) != this.list_5[i].method_0())
						{
							flag = false;
							break;
						}
					}
					else if (this.list_5[i].string_1 == "DATA3" && GClass16.smethod_1(this.byte_4) != this.list_5[i].method_0())
					{
						flag = false;
						break;
					}
				}
			}
			if (!flag)
			{
				GClass3.smethod_2(GClass62.smethod_1("1085"), 2);
				this.string_4 = GClass62.smethod_1("1085");
				throw new Exception("1");
			}
			GClass3.smethod_2("CAN CONFIGURATION DATA:", 2);
			GClass3.smethod_2(GClass16.smethod_1(this.byte_3), 2);
			GClass3.smethod_2(GClass16.smethod_1(this.byte_4), 2);
			GClass3.smethod_2(GClass16.smethod_1(this.byte_2), 2);
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
			this.byte_8[0] = this.byte_2[40];
			this.byte_8[1] = this.byte_2[39];
			this.byte_8[2] = this.byte_2[38];
			this.byte_8[3] = this.byte_2[37];
			this.byte_8[4] = this.byte_2[36];
			this.byte_8[5] = this.byte_2[35];
			this.byte_8[6] = this.byte_2[34];
			this.byte_8[7] = this.byte_2[33];
			this.byte_9[0] = this.method_35(this.byte_5[0], this.byte_6[0]);
			this.byte_9[1] = this.method_35(this.byte_5[1], this.byte_6[1]);
			this.byte_9[2] = this.method_35(this.byte_5[2], this.byte_6[2]);
			this.byte_9[3] = this.method_35(this.byte_5[3], this.byte_6[3]);
			this.byte_9[4] = this.method_35(this.byte_5[4], this.byte_6[4]);
			this.byte_9[5] = this.method_35(this.byte_5[5], this.byte_6[5]);
			this.byte_9[6] = this.method_35(this.byte_5[6], this.byte_6[6]);
			this.byte_9[7] = this.method_35(this.byte_5[7], this.byte_6[7]);
			this.byte_10[0] = this.method_36(this.byte_5[0], this.byte_6[0]);
			this.byte_10[1] = this.method_36(this.byte_5[1], this.byte_6[1]);
			this.byte_10[2] = this.method_36(this.byte_5[2], this.byte_6[2]);
			this.byte_10[3] = this.method_36(this.byte_5[3], this.byte_6[3]);
			this.byte_10[4] = this.method_36(this.byte_5[4], this.byte_6[4]);
			this.byte_10[5] = this.method_36(this.byte_5[5], this.byte_6[5]);
			this.byte_10[6] = this.method_36(this.byte_5[6], this.byte_6[6]);
			this.byte_10[7] = this.method_36(this.byte_5[7], this.byte_6[7]);
			this.bool_5 = (this.byte_4[24] == this.byte_4[32] && this.byte_4[25] == this.byte_4[33] && this.byte_4[26] == this.byte_4[34] && this.byte_4[27] == this.byte_4[35] && this.byte_4[28] == this.byte_4[36] && this.byte_4[29] == this.byte_4[37] && this.byte_4[30] == this.byte_4[38] && this.byte_4[31] == this.byte_4[39] && this.byte_4[24] == this.byte_2[33] && this.byte_4[25] == this.byte_2[34] && this.byte_4[26] == this.byte_2[35] && this.byte_4[27] == this.byte_2[36] && this.byte_4[28] == this.byte_2[37] && this.byte_4[29] == this.byte_2[38] && this.byte_4[30] == this.byte_2[39] && this.byte_4[31] == this.byte_2[40] && this.byte_4[16] == this.byte_2[25] && this.byte_4[17] == this.byte_2[26] && this.byte_4[18] == this.byte_2[27] && this.byte_4[19] == this.byte_2[28] && this.byte_4[20] == this.byte_2[29] && this.byte_4[21] == this.byte_2[30] && this.byte_4[22] == this.byte_2[31] && this.byte_4[23] == this.byte_2[32]);
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
			this.list_1.Clear();
			this.list_0.Clear();
			byte[][] array = new byte[1][];
			byte[][] array2 = array;
			int num = 0;
			byte[] array3 = new byte[1];
			array2[num] = array3;
			byte[][] byte_ = array;
			string[] string_ = new string[0];
			this.list_1.Add(new GClass58(byte_, 1, 1, GClass62.smethod_1("1086"), "header", string.Empty, string.Empty, string_, string.Empty));
			GClass3.smethod_2(GClass62.smethod_1("1086"), 2);
			for (int i = 0; i < this.list_4.Count; i++)
			{
				GClass58 gclass = this.list_4[i];
				byte b = byte.Parse(gclass.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
				if ((this.byte_6[gclass.int_0 - 1] & b) != 0)
				{
					this.list_1.Add(new GClass58(byte_, 1, 1, gclass.string_0, string.Empty, string.Empty, string.Empty, string_, string.Empty));
					GClass3.smethod_2(gclass.string_0, 2);
				}
			}
			this.list_1.Add(new GClass58(byte_, 1, 1, string.Empty, string.Empty, string.Empty, string.Empty, string_, string.Empty));
			this.list_1.Add(new GClass58(byte_, 1, 1, GClass62.smethod_1("1087"), "header", string.Empty, string.Empty, string_, string.Empty));
			GClass3.smethod_2(GClass62.smethod_1("1087"), 2);
			for (int i = 0; i < this.list_4.Count; i++)
			{
				GClass58 gclass = this.list_4[i];
				byte b = byte.Parse(gclass.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
				if ((this.byte_5[gclass.int_0 - 1] & b) != 0)
				{
					this.list_1.Add(new GClass58(byte_, 1, 1, gclass.string_0, string.Empty, string.Empty, string.Empty, string_, string.Empty));
					GClass3.smethod_2(gclass.string_0, 2);
				}
			}
			bool flag2 = false;
			for (int i = 0; i < this.list_4.Count; i++)
			{
				GClass58 gclass = this.list_4[i];
				byte b = byte.Parse(gclass.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
				if ((this.byte_9[gclass.int_0 - 1] & b) != 0)
				{
					this.int_5++;
					if (!flag2)
					{
						flag2 = true;
						this.list_1.Add(new GClass58(byte_, 1, 1, string.Empty, string.Empty, string.Empty, string.Empty, string_, string.Empty));
						this.list_1.Add(new GClass58(byte_, 1, 1, GClass62.smethod_1("1088"), "header", string.Empty, string.Empty, string_, string.Empty));
						GClass3.smethod_2(GClass62.smethod_1("1088"), 2);
					}
					this.list_1.Add(new GClass58(byte_, 1, 1, gclass.string_0, string.Empty, string.Empty, string.Empty, string_, string.Empty));
					GClass3.smethod_2(gclass.string_0, 2);
				}
			}
			flag2 = false;
			for (int i = 0; i < this.list_4.Count; i++)
			{
				GClass58 gclass = this.list_4[i];
				byte b = byte.Parse(gclass.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
				if ((this.byte_10[gclass.int_0 - 1] & b) != 0)
				{
					this.int_6++;
					if (!flag2)
					{
						flag2 = true;
						this.list_1.Add(new GClass58(byte_, 1, 1, string.Empty, string.Empty, string.Empty, string.Empty, string_, string.Empty));
						this.list_1.Add(new GClass58(byte_, 1, 1, GClass62.smethod_1("1089"), "header", string.Empty, string.Empty, string_, string.Empty));
						GClass3.smethod_2(GClass62.smethod_1("1089"), 2);
					}
					this.list_1.Add(new GClass58(byte_, 1, 1, gclass.string_0, string.Empty, string.Empty, string.Empty, string_, string.Empty));
					GClass3.smethod_2(gclass.string_0, 2);
				}
			}
			this.list_1.Add(new GClass58(byte_, 1, 1, string.Empty, string.Empty, string.Empty, string.Empty, string_, string.Empty));
			this.list_1.Add(new GClass58(byte_, 1, 1, GClass62.smethod_1("1090"), "header", string.Empty, string.Empty, string_, string.Empty));
			GClass3.smethod_2(GClass62.smethod_1("1090"), 2);
			for (int i = 0; i < this.list_4.Count; i++)
			{
				GClass58 gclass = this.list_4[i];
				byte b = byte.Parse(gclass.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
				if ((this.byte_7[gclass.int_0 - 1] & b) != 0)
				{
					this.list_1.Add(new GClass58(byte_, 1, 1, gclass.string_0, string.Empty, string.Empty, string.Empty, string_, string.Empty));
					GClass3.smethod_2(gclass.string_0, 2);
				}
			}
			if (GClass3.bool_14)
			{
				throw new Exception("ESC");
			}
			this.bool_0 = true;
			base.method_28();
		}
		catch (Exception ex)
		{
			if (ex.Message == "ESC")
			{
				this.string_4 = "Aborted by user";
			}
			GClass3.smethod_2(ex.Message, 2);
			GClass3.smethod_2("Terminate 4", 1);
			base.method_22(false);
		}
	}

	// Token: 0x060001FA RID: 506 RVA: 0x00002E33 File Offset: 0x00001033
	public override void vmethod_2(bool bool_6, bool bool_7)
	{
		base.method_29(bool_7);
	}

	// Token: 0x060001FB RID: 507 RVA: 0x0005AA10 File Offset: 0x00058C10
	public override List<GClass64> vmethod_3()
	{
		return new List<GClass64>();
	}

	// Token: 0x060001FC RID: 508 RVA: 0x000026DC File Offset: 0x000008DC
	public override void vmethod_5()
	{
	}

	// Token: 0x060001FD RID: 509 RVA: 0x0005AA24 File Offset: 0x00058C24
	protected override void vmethod_6(GClass58 gclass58_1)
	{
		if (GClass3.bool_0 || GClass3.bool_12)
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
		else if (gclass58_1.string_2.Contains("PROXYPROC"))
		{
			this.method_33(gclass58_1);
		}
		else if (gclass58_1.string_2.Contains("RWUSERENTRY"))
		{
			this.method_34(gclass58_1);
		}
	}

	// Token: 0x060001FE RID: 510 RVA: 0x0005AAE0 File Offset: 0x00058CE0
	private void method_33(GClass58 gclass58_1)
	{
		Thread.Sleep(500);
		GClass3.smethod_2(GClass62.smethod_1("1094"), 2);
		byte[] array = new byte[this.byte_2.Length + 4];
		array[0] = (byte)(array.Length - 1);
		array[1] = 46;
		array[2] = 32;
		array[3] = 35;
		for (int i = 0; i < this.byte_2.Length; i++)
		{
			array[i + 4] = this.byte_2[i];
		}
		GClass58 gclass = new GClass58();
		gclass.byte_0 = new byte[][]
		{
			array
		};
		gclass.int_0 = 1;
		gclass.int_1 = 1;
		gclass.string_0 = "Setup";
		gclass.string_2 = "hex";
		gclass.string_3 = string.Empty;
		gclass.string_4 = string.Empty;
		gclass.string_5 = new string[]
		{
			string.Empty
		};
		gclass.string_1 = string.Empty;
		gclass.int_2 = 1770;
		bool flag = true;
		string a = string.Empty;
		for (int i = 0; i < this.list_4.Count; i++)
		{
			GClass58 gclass2 = this.list_4[i];
			byte b = byte.Parse(gclass2.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
			bool flag2 = true;
			if ((this.byte_7[gclass2.int_0 - 1] & b) != 0)
			{
				byte b2 = byte.Parse(gclass2.string_2.Substring(0, 2), NumberStyles.HexNumber);
				string a2 = gclass2.string_2.Substring(2);
				string text = string.Empty;
				base.method_30(GClass62.smethod_1("1091") + " " + gclass2.string_0);
				GClass19 gclass3;
				if (a2 == "50")
				{
					gclass3 = GClass19.smethod_0("BCAN29", string.Empty, b2, this.list_5, this.list_0, "19");
				}
				else
				{
					gclass3 = GClass19.smethod_0("CCAN29", string.Empty, b2, this.list_5, this.list_0, "19");
				}
				gclass3.method_26(gclass);
				if ((gclass3.method_8().Length < 5 || gclass3.method_8().Contains("7F 2E")) && !gclass3.method_8().Contains("7F 2E 78"))
				{
					if (text == string.Empty && gclass3.method_8().Length > 4)
					{
						text = gclass3.method_8();
					}
					flag2 = false;
					flag = false;
				}
				string text2 = GClass62.smethod_1("6501");
				if (text == string.Empty)
				{
					text2 = GClass62.smethod_1("6502");
				}
				else if (text.Contains("7F 2E 10"))
				{
					text2 = GClass62.smethod_1("6503");
				}
				else if (text.Contains("7F 2E 12"))
				{
					text2 = GClass62.smethod_1("6504");
				}
				else if (text.Contains("7F 2E 21"))
				{
					text2 = GClass62.smethod_1("6505");
				}
				else if (text.Contains("7F 2E 22"))
				{
					text2 = GClass62.smethod_1("6506");
				}
				else if (text.Contains("7F 2E 31"))
				{
					text2 = GClass62.smethod_1("6507");
				}
				else if (text.Contains("7F 2E A0"))
				{
					text2 = GClass62.smethod_1("6508");
				}
				else if (text.Contains("7F 2E A1"))
				{
					text2 = GClass62.smethod_1("6509");
				}
				string str = GClass62.smethod_1("1092");
				if (flag2)
				{
					GClass3.smethod_2(string.Concat(new string[]
					{
						GClass62.smethod_1("1091"),
						" ",
						gclass2.string_0,
						" ",
						GClass62.smethod_1("1092"),
						"!"
					}), 2);
				}
				else
				{
					if (a == string.Empty)
					{
						a = string.Concat(new string[]
						{
							gclass2.string_0,
							" ",
							GClass62.smethod_1("1093"),
							"! - ",
							text2
						});
					}
					str = GClass62.smethod_1("1093") + "! - " + text2;
					GClass3.smethod_2(string.Concat(new string[]
					{
						GClass62.smethod_1("1091"),
						" ",
						gclass2.string_0,
						" ",
						GClass62.smethod_1("1093"),
						"! - ",
						text2
					}), 2);
				}
				base.method_30(gclass2.string_0 + "... " + str);
				Thread.Sleep(5000);
			}
		}
		Thread.Sleep(1000);
		this.bool_4 = flag;
		try
		{
			string text3 = string.Concat(new string[]
			{
				"FL_",
				DateTime.Now.ToString("yyMMddHHmmss"),
				"_",
				GClass3.string_2,
				"_PROXI.txt"
			});
			text3 = text3.Replace("/", string.Empty).Replace("\\", string.Empty);
			FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://ftp.fiatecuscan.net/" + text3);
			ftpWebRequest.Method = "STOR";
			ftpWebRequest.Credentials = new NetworkCredential("reports", "reports");
			Stream requestStream = ftpWebRequest.GetRequestStream();
			try
			{
				byte[] bytes = Encoding.Unicode.GetBytes(GClass3.smethod_6());
				requestStream.Write(bytes, 0, bytes.Length);
			}
			finally
			{
				requestStream.Close();
			}
		}
		catch (Exception ex)
		{
			GClass3.smethod_2("Failed to send diagnostic report: " + ex.Message, 0);
		}
		if (!flag)
		{
			base.method_31(false, GClass62.smethod_1("6052"), a);
		}
		else
		{
			base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
		}
	}

	// Token: 0x060001FF RID: 511 RVA: 0x0005B120 File Offset: 0x00059320
	private void method_34(GClass58 gclass58_1)
	{
		for (int i = gclass58_1.int_0 - 1; i < gclass58_1.int_0 + gclass58_1.int_1 - 1; i++)
		{
			byte b = 0;
			if (this.byte_2.Length > i)
			{
				b = this.byte_2[i];
			}
			byte b2 = gclass58_1.byte_0[1][i + 3];
			byte b3 = byte.Parse(gclass58_1.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
			b3 ^= byte.MaxValue;
			b &= b3;
			b |= b2;
			this.byte_2[i] = b;
		}
		base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
	}

	// Token: 0x06000200 RID: 512 RVA: 0x0005B1C4 File Offset: 0x000593C4
	private byte method_35(byte byte_11, byte byte_12)
	{
		byte b = byte_11 ^ byte_12;
		return b & byte_11;
	}

	// Token: 0x06000201 RID: 513 RVA: 0x0005B1E0 File Offset: 0x000593E0
	private byte method_36(byte byte_11, byte byte_12)
	{
		byte b = byte_11 ^ byte_12;
		return b & byte_12;
	}

	// Token: 0x06000202 RID: 514 RVA: 0x0005B1FC File Offset: 0x000593FC
	public override string vmethod_0(byte[] byte_11, string string_9, int int_7, int int_8, string[] string_10, string string_11)
	{
		return this.vmethod_7(this.byte_2, string_9, int_7, int_8, string_10, string_11);
	}

	// Token: 0x06000203 RID: 515 RVA: 0x0005B220 File Offset: 0x00059420
	public override string vmethod_7(byte[] byte_11, string string_9, int int_7, int int_8, string[] string_10, string string_11)
	{
		string empty = string.Empty;
		int_7--;
		int num = byte_11.Length - int_7;
		if (int_8 < num)
		{
			num = int_8;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_11[i + int_7];
		}
		return base.method_32(array, string_9, string_10, string_11);
	}

	// Token: 0x040001B9 RID: 441
	private string string_7 = string.Empty;

	// Token: 0x040001BA RID: 442
	private List<GClass58> list_4 = new List<GClass58>();

	// Token: 0x040001BB RID: 443
	private List<GClass58> list_5 = new List<GClass58>();

	// Token: 0x040001BC RID: 444
	private string string_8 = "BCAN29";

	// Token: 0x040001BD RID: 445
	private byte[] byte_2 = new byte[0];

	// Token: 0x040001BE RID: 446
	private byte[] byte_3 = new byte[0];

	// Token: 0x040001BF RID: 447
	private byte[] byte_4 = new byte[0];

	// Token: 0x040001C0 RID: 448
	private byte[] byte_5 = new byte[8];

	// Token: 0x040001C1 RID: 449
	private byte[] byte_6 = new byte[8];

	// Token: 0x040001C2 RID: 450
	private byte[] byte_7 = new byte[8];

	// Token: 0x040001C3 RID: 451
	private byte[] byte_8 = new byte[8];

	// Token: 0x040001C4 RID: 452
	private byte[] byte_9 = new byte[8];

	// Token: 0x040001C5 RID: 453
	private byte[] byte_10 = new byte[8];

	// Token: 0x040001C6 RID: 454
	public int int_5 = 0;

	// Token: 0x040001C7 RID: 455
	public int int_6 = 0;

	// Token: 0x040001C8 RID: 456
	public bool bool_5 = false;
}
