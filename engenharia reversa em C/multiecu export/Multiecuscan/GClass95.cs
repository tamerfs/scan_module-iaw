using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

// Token: 0x02000070 RID: 112
public sealed class GClass95 : GClass11
{
	// Token: 0x060003C5 RID: 965 RVA: 0x00061A90 File Offset: 0x0005FC90
	public GClass95(byte byte_10, string string_24, List<GClass104> list_8, List<GClass104> list_9, string string_25)
	{
		this.byte_0 = byte_10;
		this.string_22 = string_24;
		this.list_0 = list_9;
		this.list_1 = list_8;
		this.string_3 = string_25;
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x00061B48 File Offset: 0x0005FD48
	public override void vmethod_1()
	{
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
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			if (GClass125.smethod_44() == 5)
			{
				for (int j = 0; j < 40; j++)
				{
					Thread.Sleep(100);
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
				}
			}
			GClass11.smethod_0(this.string_23, this.string_22, this.byte_0, this.list_7, this.list_0, this.string_3, null).method_0();
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			for (int k = 0; k < this.list_7.Count; k++)
			{
				if (this.list_7[k].string_1 == "DATA1")
				{
					this.byte_2 = GClass127.smethod_32(this.list_7[k].method_0());
				}
				else if (this.list_7[k].string_1 == "DATA2")
				{
					this.byte_3 = GClass127.smethod_32(this.list_7[k].method_0());
				}
				else if (this.list_7[k].string_1 == "DATA3")
				{
					this.byte_4 = GClass127.smethod_32(this.list_7[k].method_0());
				}
			}
			bool flag = this.byte_2.Length > 25;
			bool flag2 = this.byte_2.Length == 0 && this.byte_3.Length == 0 && this.byte_4.Length == 0;
			if (GClass125.smethod_46())
			{
				for (int l = 0; l < 40; l++)
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
				GClass11.smethod_0(this.string_23, this.string_22, this.byte_0, this.list_7, this.list_0, this.string_3, null).method_0();
				if (GClass126.bool_25)
				{
					throw new Exception("ESC");
				}
				for (int m = 0; m < this.list_7.Count; m++)
				{
					if (this.list_7[m].string_1 == "DATA1")
					{
						if (GClass127.smethod_11(this.byte_2) != this.list_7[m].method_0())
						{
							flag = false;
							break;
						}
					}
					else if (this.list_7[m].string_1 == "DATA2")
					{
						if (GClass127.smethod_11(this.byte_3) != this.list_7[m].method_0())
						{
							flag = false;
							break;
						}
					}
					else if (this.list_7[m].string_1 == "DATA3" && GClass127.smethod_11(this.byte_4) != this.list_7[m].method_0())
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
					for (int n = 0; n < 40; n++)
					{
						Thread.Sleep(100);
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
					}
				}
				GClass11.smethod_0(this.string_23, this.string_22, this.byte_0, this.list_7, this.list_0, this.string_3, null).method_0();
				if (GClass126.bool_25)
				{
					throw new Exception("ESC");
				}
				for (int num = 0; num < this.list_7.Count; num++)
				{
					if (this.list_7[num].string_1 == "DATA1")
					{
						if (GClass127.smethod_11(this.byte_2) != this.list_7[num].method_0())
						{
							flag = false;
							break;
						}
					}
					else if (this.list_7[num].string_1 == "DATA2")
					{
						if (GClass127.smethod_11(this.byte_3) != this.list_7[num].method_0())
						{
							flag = false;
							break;
						}
					}
					else if (this.list_7[num].string_1 == "DATA3" && GClass127.smethod_11(this.byte_4) != this.list_7[num].method_0())
					{
						flag = false;
						break;
					}
				}
			}
			if (!flag && this.byte_2.Length < 26 && GClass126.bool_19)
			{
				flag = true;
				this.byte_2 = GClass127.smethod_32(GClass127.smethod_11(this.byte_2) + " 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
			}
			if (!flag)
			{
				if (this.byte_2.Length < 10 && !flag2)
				{
					GClass126.smethod_2("Empty PROXI file in Body Computer (BCM)!", 2);
					this.string_8 = "Empty PROXI file in Body Computer (BCM)!";
				}
				else if (flag2)
				{
					if (this.byte_0 == 85)
					{
						GClass126.smethod_2("Failed to connect to Instrument Panel (IPC)", 2);
						this.string_8 = "Failed to connect to Instrument Panel (IPC)";
					}
					else
					{
						GClass126.smethod_2("Failed to connect to Body Computer (BCM)", 2);
						this.string_8 = "Failed to connect to Body Computer (BCM)";
					}
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
			this.byte_5[0] = this.byte_4[8];
			this.byte_5[1] = this.byte_4[9];
			this.byte_5[2] = this.byte_4[10];
			this.byte_5[3] = this.byte_4[11];
			this.byte_6[0] = this.byte_2[28];
			this.byte_6[1] = this.byte_2[27];
			this.byte_6[2] = this.byte_2[26];
			this.byte_6[3] = this.byte_2[25];
			this.byte_7[0] = this.byte_4[12];
			this.byte_7[1] = this.byte_4[13];
			this.byte_7[2] = this.byte_4[14];
			this.byte_7[3] = this.byte_4[15];
			this.byte_9[0] = this.byte_4[16];
			this.byte_9[1] = this.byte_4[17];
			this.byte_9[2] = this.byte_4[18];
			this.byte_9[3] = this.byte_4[19];
			this.byte_8[0] = this.byte_2[32];
			this.byte_8[1] = this.byte_2[31];
			this.byte_8[2] = this.byte_2[30];
			this.byte_8[3] = this.byte_2[29];
			this.bool_6 = (this.byte_4[12] == this.byte_4[16] && this.byte_4[13] == this.byte_4[17] && this.byte_4[14] == this.byte_4[18] && this.byte_4[15] == this.byte_4[19] && this.byte_4[12] == this.byte_2[32] && this.byte_4[13] == this.byte_2[31] && this.byte_4[14] == this.byte_2[30] && this.byte_4[15] == this.byte_2[29] && this.byte_4[8] == this.byte_2[28] && this.byte_4[9] == this.byte_2[27] && this.byte_4[10] == this.byte_2[26] && this.byte_4[11] == this.byte_2[25]);
			this.byte_2[28] = this.byte_4[8];
			this.byte_2[27] = this.byte_4[9];
			this.byte_2[26] = this.byte_4[10];
			this.byte_2[25] = this.byte_4[11];
			this.byte_2[32] = this.byte_4[12];
			this.byte_2[31] = this.byte_4[13];
			this.byte_2[30] = this.byte_4[14];
			this.byte_2[29] = this.byte_4[15];
			this.list_1.Clear();
			this.list_0.Clear();
			byte[][] byte_ = new byte[][]
			{
				new byte[1]
			};
			string[] string_ = new string[0];
			for (int num2 = 0; num2 < this.list_6.Count; num2++)
			{
				GClass104 gclass = this.list_6[num2];
				byte b = byte.Parse(gclass.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
				bool flag3 = (this.byte_6[gclass.int_0 - 1] & b) > 0;
				bool flag4 = (this.byte_5[gclass.int_0 - 1] & b) > 0;
				bool flag5 = (this.byte_7[gclass.int_0 - 1] & b) > 0;
				bool flag6 = (this.byte_9[gclass.int_0 - 1] & b) > 0;
				if (flag3 || flag4 || flag5 || flag6)
				{
					this.list_1.Add(new GClass104(byte_, 1, 1, gclass.string_0, "", "", "", string_, ""));
					string text = "-";
					if (flag3 && flag4)
					{
						if (flag5 && flag6)
						{
							text = GClass121.smethod_6("1214");
						}
						else if (flag5 && !flag6)
						{
							text = GClass121.smethod_6("1215");
							this.list_1[this.list_1.Count - 1].string_2 = "ERROR";
						}
						else
						{
							text = GClass121.smethod_6("1213");
						}
					}
					else if (!flag3 && flag4)
					{
						text = GClass121.smethod_6("1211");
						this.int_5++;
						if (flag5 && flag6)
						{
							text = text + " / " + GClass121.smethod_6("1214");
						}
						else if (flag5 && !flag6)
						{
							text = text + " / " + GClass121.smethod_6("1215");
						}
						this.list_1[this.list_1.Count - 1].string_2 = "ERROR";
					}
					else if (flag3 && !flag4)
					{
						text = GClass121.smethod_6("1212");
						this.int_6++;
						this.list_1[this.list_1.Count - 1].string_2 = "ERROR";
					}
					this.list_1[this.list_1.Count - 1].method_1(text);
					GClass126.smethod_2(gclass.string_0, 2);
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

	// Token: 0x060003C7 RID: 967 RVA: 0x0000337F File Offset: 0x0000157F
	public override void r0(bool bool_7, bool bool_8)
	{
		base.method_32(bool_8);
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x00002F03 File Offset: 0x00001103
	public override List<GClass102> r1()
	{
		return new List<GClass102>();
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x00002F0A File Offset: 0x0000110A
	public override void r2()
	{
	}

	// Token: 0x060003CA RID: 970 RVA: 0x0006280C File Offset: 0x00060A0C
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
				this.method_46(gclass104_1);
			}
			return;
		}
	}

	// Token: 0x060003CB RID: 971 RVA: 0x000628C0 File Offset: 0x00060AC0
	private void method_45(GClass104 gclass104_1)
	{
		Thread.Sleep(500);
		GClass126.smethod_2(GClass121.smethod_6("1094"), 2);
		byte[] array = new byte[this.byte_2.Length + 3];
		array[0] = (byte)(array.Length - 1);
		array[1] = 59;
		array[2] = 35;
		for (int i = 0; i < this.byte_2.Length; i++)
		{
			array[i + 3] = this.byte_2[i];
		}
		byte[] array2 = new byte[this.byte_2.Length + 3];
		array2[0] = (byte)(array2.Length - 1);
		array2[1] = 59;
		array2[2] = 35;
		for (int j = 3; j < array2.Length; j++)
		{
			if (j - 3 < this.byte_2.Length)
			{
				array2[j] = this.byte_2[j - 3];
			}
			else
			{
				array2[j] = 0;
			}
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
		GClass104 gclass2 = new GClass104();
		gclass2.byte_0 = new byte[][]
		{
			array2
		};
		gclass2.int_0 = 1;
		gclass2.int_1 = 1;
		gclass2.string_0 = "Setup";
		gclass2.string_2 = "hex";
		gclass2.string_3 = "";
		gclass2.string_4 = "";
		gclass2.string_5 = new string[]
		{
			""
		};
		gclass2.string_1 = "";
		gclass2.int_2 = 10455;
		byte[] array3 = new byte[this.byte_2.Length + 4];
		array3[0] = (byte)(array3.Length - 1);
		array3[1] = 46;
		array3[2] = 32;
		array3[3] = 35;
		for (int k = 0; k < this.byte_2.Length; k++)
		{
			array3[k + 4] = this.byte_2[k];
		}
		GClass104 gclass3 = new GClass104();
		gclass3.byte_0 = new byte[][]
		{
			array3
		};
		gclass3.int_0 = 1;
		gclass3.int_1 = 1;
		gclass3.string_0 = "Setup";
		gclass3.string_2 = "hex";
		gclass3.string_3 = "";
		gclass3.string_4 = "";
		gclass3.string_5 = new string[]
		{
			""
		};
		gclass3.string_1 = "";
		gclass3.int_2 = 10455;
		bool flag = true;
		string a = "";
		int l = 0;
		while (l < this.list_6.Count)
		{
			GClass104 gclass4 = this.list_6[l];
			byte b = byte.Parse(gclass4.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
			bool flag2 = true;
			if (!GClass126.bool_25)
			{
				if ((this.byte_7[gclass4.int_0 - 1] & b) != 0)
				{
					byte b2 = byte.Parse(gclass4.string_2.Substring(0, 2), NumberStyles.HexNumber);
					string text = gclass4.string_2.Substring(2);
					string text2 = "";
					base.method_26(GClass121.smethod_6("1091") + " " + gclass4.string_0);
					GClass11 gclass5 = GClass11.smethod_0(this.string_23, text, b2, this.list_7, this.list_0, this.string_3, null);
					gclass5.method_37(gclass);
					if (GClass126.bool_25)
					{
						GClass126.smethod_2("Aborting PROXI Alignment...", 1);
						a = GClass121.smethod_6("6082");
						flag = false;
						break;
					}
					Thread.Sleep(1000);
					if (gclass5.method_16().Length < 5 || gclass5.method_16().Contains("7F 3B"))
					{
						if (text2 == "" && gclass5.method_16().Length > 4)
						{
							text2 = gclass5.method_16();
						}
						Thread.Sleep(2000);
						gclass5 = GClass11.smethod_0(this.string_23, text, b2, this.list_7, this.list_0, this.string_3, null);
						gclass5.method_37(gclass2);
						if (GClass126.bool_25)
						{
							GClass126.smethod_2("Aborting PROXI Alignment...", 1);
							a = GClass121.smethod_6("6082");
							flag = false;
							break;
						}
						if ((gclass5.method_16().Length < 5 || gclass5.method_16().Contains("7F 3B")) && !gclass5.method_16().Contains("7F 3B 78"))
						{
							if (text2 == "" && gclass5.method_16().Length > 4)
							{
								text2 = gclass5.method_16();
							}
							Thread.Sleep(2000);
							gclass5 = GClass11.smethod_0(this.string_23, text, b2, this.list_7, this.list_0, this.string_3, null);
							gclass5.method_39(gclass, 1);
							if (gclass5.method_16().Length < 5 || gclass5.method_16().Contains("7F 3B") || gclass5.method_16().Contains("7F 00"))
							{
								if (text2 == "" && gclass5.method_16().Length > 4)
								{
									text2 = gclass5.method_16();
								}
								Thread.Sleep(2000);
								if (b2 == 1)
								{
									gclass5 = GClass11.smethod_0("BCAN29", "F1", 192, this.list_7, this.list_0, this.string_3, null);
									gclass5.method_39(gclass3, 4);
								}
								else
								{
									gclass5 = GClass11.smethod_0(this.string_23, text, b2, this.list_7, this.list_0, this.string_3, null);
									gclass5.method_39(gclass, 2);
								}
								if (gclass5.method_16().Length < 5 || gclass5.method_16().Contains("7F 3B") || gclass5.method_16().Contains("7F 00"))
								{
									if (text2 == "" && gclass5.method_16().Length > 4)
									{
										text2 = gclass5.method_16();
									}
									Thread.Sleep(2000);
									gclass5 = GClass11.smethod_0(this.string_23, text, b2, this.list_7, this.list_0, this.string_3, null);
									gclass5.method_39(gclass, 3);
									if (gclass5.method_16().Length < 5 || gclass5.method_16().Contains("7F 3B") || gclass5.method_16().Contains("7F 00"))
									{
										if (text2 == "" && gclass5.method_16().Length > 4)
										{
											text2 = gclass5.method_16();
										}
										Thread.Sleep(2000);
										if (b2 == 1)
										{
											gclass5 = GClass11.smethod_0("BCAN29", "F1", 192, this.list_7, this.list_0, this.string_3, null);
											gclass5.method_39(gclass3, 4);
										}
										else
										{
											gclass5 = GClass11.smethod_0(this.string_23, text, b2, this.list_7, this.list_0, this.string_3, null);
											gclass5.method_39(gclass, 4);
										}
										Thread.Sleep(1000);
										if (gclass5.method_16().Length < 5 || gclass5.method_16().Contains("7F 3B") || gclass5.method_16().Contains("7F 00"))
										{
											if (text2 == "" && gclass5.method_16().Length > 4)
											{
												text2 = gclass5.method_16();
											}
											flag2 = false;
											flag = false;
										}
									}
								}
							}
						}
					}
					string text3 = GClass121.smethod_6("6501");
					if (text2 == "")
					{
						text3 = GClass121.smethod_6("6502");
					}
					else if (text2.Contains("7F 3B 10"))
					{
						text3 = GClass121.smethod_6("6503");
					}
					else if (text2.Contains("7F 3B 12"))
					{
						text3 = GClass121.smethod_6("6504");
					}
					else if (text2.Contains("7F 3B 21"))
					{
						text3 = GClass121.smethod_6("6505");
					}
					else if (text2.Contains("7F 3B 22"))
					{
						text3 = GClass121.smethod_6("6506");
					}
					else if (text2.Contains("7F 3B 31"))
					{
						text3 = GClass121.smethod_6("6507");
					}
					else if (text2.Contains("7F 3B A0"))
					{
						text3 = GClass121.smethod_6("6508");
					}
					else if (text2.Contains("7F 3B A1"))
					{
						text3 = GClass121.smethod_6("6509");
					}
					string str = GClass121.smethod_6("1092");
					if (flag2)
					{
						GClass126.smethod_2(string.Concat(new string[]
						{
							GClass121.smethod_6("1091"),
							" ",
							gclass4.string_0,
							" ",
							GClass121.smethod_6("1092"),
							"!"
						}), 2);
					}
					else
					{
						if (a == "")
						{
							a = string.Concat(new string[]
							{
								gclass4.string_0,
								" ",
								GClass121.smethod_6("1093"),
								"! - ",
								text3
							});
						}
						str = GClass121.smethod_6("1093") + "! - " + text3;
						GClass126.smethod_2(string.Concat(new string[]
						{
							GClass121.smethod_6("1091"),
							" ",
							gclass4.string_0,
							" ",
							GClass121.smethod_6("1093"),
							"! - ",
							text3
						}), 2);
					}
					base.method_26(gclass4.string_0 + "... " + str);
					Thread.Sleep(5000);
				}
				l++;
				continue;
			}
			GClass126.smethod_2("Aborting PROXI Alignment...", 1);
			a = GClass121.smethod_6("6082");
			flag = false;
			IL_9B3:
			Thread.Sleep(1000);
			this.bool_5 = flag;
			try
			{
				string text4 = string.Concat(new string[]
				{
					"FL_",
					DateTime.Now.ToString("yyMMddHHmmss"),
					"_",
					GClass126.string_7,
					"_PROXI.txt"
				});
				text4 = text4.Replace("/", "").Replace("\\", "");
				FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://ftp.multiecuscan.net/" + text4);
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
			if (!flag)
			{
				base.method_28(false, GClass121.smethod_6("6052"), a);
				return;
			}
			base.method_28(false, GClass121.smethod_6("6051"), "");
			return;
		}
		goto IL_9B3;
	}

	// Token: 0x060003CC RID: 972 RVA: 0x0005FAC4 File Offset: 0x0005DCC4
	private void method_46(GClass104 gclass104_1)
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

	// Token: 0x060003CD RID: 973 RVA: 0x00003376 File Offset: 0x00001576
	private byte method_47(byte byte_10, byte byte_11)
	{
		return (byte_10 ^ byte_11) & byte_10;
	}

	// Token: 0x060003CE RID: 974 RVA: 0x0000336D File Offset: 0x0000156D
	private byte method_48(byte byte_10, byte byte_11)
	{
		return (byte_10 ^ byte_11) & byte_11;
	}

	// Token: 0x060003CF RID: 975 RVA: 0x00003388 File Offset: 0x00001588
	public override string vmethod_0(byte[] byte_10, string string_24, int int_7, int int_8, string[] string_25, string string_26)
	{
		return this.r4(this.byte_2, string_24, int_7, int_8, string_25, string_26);
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x00061A3C File Offset: 0x0005FC3C
	public override string r4(byte[] byte_10, string string_24, int int_7, int int_8, string[] string_25, string string_26)
	{
		int_7--;
		int num = byte_10.Length - int_7;
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
			array[i] = byte_10[i + int_7];
		}
		return base.method_33(array, string_24, string_25, string_26);
	}

	// Token: 0x04000289 RID: 649
	private string string_22 = "7B0";

	// Token: 0x0400028A RID: 650
	private List<GClass104> list_6 = new List<GClass104>();

	// Token: 0x0400028B RID: 651
	private List<GClass104> list_7 = new List<GClass104>();

	// Token: 0x0400028C RID: 652
	private string string_23 = "BCAN";

	// Token: 0x0400028D RID: 653
	private byte[] byte_3 = new byte[0];

	// Token: 0x0400028E RID: 654
	private byte[] byte_4 = new byte[0];

	// Token: 0x0400028F RID: 655
	private byte[] byte_5 = new byte[4];

	// Token: 0x04000290 RID: 656
	private byte[] byte_6 = new byte[4];

	// Token: 0x04000291 RID: 657
	private byte[] byte_7 = new byte[4];

	// Token: 0x04000292 RID: 658
	private byte[] byte_8 = new byte[4];

	// Token: 0x04000293 RID: 659
	private byte[] byte_9 = new byte[4];

	// Token: 0x04000294 RID: 660
	public int int_5;

	// Token: 0x04000295 RID: 661
	public int int_6;

	// Token: 0x04000296 RID: 662
	public bool bool_6;
}
