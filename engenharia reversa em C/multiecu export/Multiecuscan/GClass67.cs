using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x0200001C RID: 28
public abstract class GClass67 : GClass11
{
	// Token: 0x060001AD RID: 429
	protected abstract void r6();

	// Token: 0x060001AE RID: 430 RVA: 0x0002CD8C File Offset: 0x0002AF8C
	public override void vmethod_1()
	{
		try
		{
			GClass126.smethod_2("-----------------------", 0);
			GClass126.smethod_2("Control module (CANSCANPN): " + this.string_2 + "/" + this.string_3, 0);
			for (int i = 0; i < 5; i++)
			{
				if (GClass126.bool_25)
				{
					IL_6C8:
					throw new Exception("ESC");
				}
				Thread.Sleep(100);
			}
			this.r6();
			this.ra("ATCSM1");
			this.ra("ATH1");
			this.ra("ATD0");
			this.ra("ATV0");
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
				this.ra("ATH0");
				string string_ = this.string_2;
				if (this.string_2 == "CCANPN")
				{
					this.ra("ATSP6");
				}
				else if (this.string_2 == "BHCANPN")
				{
					this.ra("ATSPB");
				}
				using (List<GClass100>.Enumerator enumerator = this.list_5.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						GClass100 gclass = enumerator.Current;
						if (!(gclass.string_3 != string_) && (!(gclass.string_5 != this.string_3) || !GClass125.smethod_49()) && !(gclass.string_3 != string_) && (!(gclass.string_5 != this.string_3) || GClass125.smethod_44() != 15))
						{
							this.ra("ATCRA " + gclass.string_4.Substring(3, 3));
							this.ra("ATSH " + gclass.string_4.Substring(0, 3));
							this.ra("ATV0");
							this.ra("ATFCSH " + gclass.string_4.Substring(0, 3));
							this.ra("ATFCSD 30 00 00");
							this.ra("ATFCSM 1");
							this.ra("ATST28");
							this.bool_6 = false;
							this.bool_7 = false;
							byte[] array = this.method_53(GClass127.smethod_32("021003"));
							if (GClass126.bool_25)
							{
								throw new Exception("ESC");
							}
							if (array.Length > 3 && array[1] == 127 && array[3] == 18)
							{
								this.bool_6 = true;
								array = this.method_53(GClass127.smethod_32("021092"));
							}
							if (array.Length > 3 && array[1] == 127 && array[3] == 18)
							{
								this.bool_6 = false;
								this.bool_7 = true;
								array = this.method_53(GClass127.smethod_32("0210C0"));
							}
							if (array.Length > 2 && array[1] == 80)
							{
								this.string_2 = gclass.string_4;
								this.byte_0 = gclass.byte_0;
								SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
								for (int k = 0; k < this.list_1.Count; k++)
								{
									GClass104 gclass2 = this.list_1[k];
									if ((!(gclass.string_4 != "620504") || !gclass2.string_0.StartsWith("CF")) && (!this.bool_6 || gclass2.string_0.StartsWith("KWP")) && (!this.bool_7 || gclass2.string_0.StartsWith("RNO")) && (this.bool_6 || !gclass2.string_0.StartsWith("KWP")) && (this.bool_7 || !gclass2.string_0.StartsWith("RNO")))
									{
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
											byte[] array3 = this.method_53(gclass2.byte_0[0]);
											gclass2.method_1(this.r4(array3, gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
											if (gclass2.int_2 == 10455 && gclass2.string_2 == "isopn")
											{
												if (GClass127.smethod_11(array3) == "03 7F 22 12" || GClass127.smethod_11(array3) == "03 7F 22 31")
												{
													array3 = this.method_53(GClass127.smethod_32("02 1A 87"));
													gclass2.method_1(this.r4(array3, "isopn", 2, 2, gclass2.string_5, gclass2.string_6));
												}
												if (GClass127.smethod_11(array3) == "03 7F 1A 11")
												{
													array3 = this.method_53(GClass127.smethod_32("03 22 F1 12"));
													gclass2.method_1(this.r4(array3, "str", 1, 10, gclass2.string_5, gclass2.string_6));
												}
											}
											sortedList.Add(GClass127.smethod_11(gclass2.byte_0[0]), array3);
										}
										if (gclass2.int_2 == 10455)
										{
											this.string_7 = gclass2.method_0();
										}
									}
								}
								if (this.genum0_0 == (GEnum0)2)
								{
									Thread.Sleep(200);
									gclass.list_3 = this.r1();
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
					goto IL_6D3;
				}
				goto IL_6C8;
			}
			IL_6D3:;
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

	// Token: 0x060001AF RID: 431 RVA: 0x0002D514 File Offset: 0x0002B714
	public override List<GClass102> r1()
	{
		if (this.bool_6)
		{
			return this.method_48();
		}
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_3;
		}
		else
		{
			array = this.method_53(this.byte_4);
		}
		if (array.Length < 3)
		{
			GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
			return null;
		}
		int num = (int)array[2];
		int num2 = 0;
		int num3 = 4;
		while (num2 < num && num3 < array.Length - 2)
		{
			GClass102 gclass = new GClass102();
			gclass.string_0 = GClass127.smethod_11(new byte[]
			{
				array[num3],
				array[num3 + 1]
			}).Replace(" ", "");
			gclass.string_1 = GClass127.smethod_11(new byte[]
			{
				array[num3],
				array[num3 + 1],
				array[num3 + 2]
			}).Replace(" ", "");
			gclass.byte_0 = array[num3 + 3];
			byte byte_ = array[num3 + 2];
			gclass.string_5 = this.method_45(byte_);
			gclass.string_6 = this.method_46(gclass.byte_0);
			gclass.string_7 = this.method_47(gclass.byte_0);
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
			num3 += 4;
		}
		return list;
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x00006F08 File Offset: 0x00005108
	private string method_45(byte byte_7)
	{
		string result = "";
		if (byte_7 == 17)
		{
			result = GClass121.smethod_6("3082");
		}
		else if (byte_7 == 18)
		{
			result = GClass121.smethod_6("3083");
		}
		else if (byte_7 == 19)
		{
			result = GClass121.smethod_6("3081");
		}
		else if (byte_7 == 20)
		{
			result = GClass121.smethod_6("3089");
		}
		else if (byte_7 == 21)
		{
			result = GClass121.smethod_6("3085");
		}
		else if (byte_7 == 22)
		{
			result = GClass121.smethod_6("3084");
		}
		return result;
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x00006F88 File Offset: 0x00005188
	private string method_46(byte byte_7)
	{
		string result = "";
		if ((byte_7 & 9) == 8)
		{
			result = GClass121.smethod_6("3054");
		}
		else if ((byte_7 & 1) == 1)
		{
			result = GClass121.smethod_6("3062");
		}
		return result;
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x00006FC4 File Offset: 0x000051C4
	private string method_47(byte byte_7)
	{
		string result = "";
		if ((byte_7 & 128) != 0)
		{
			result = GClass121.smethod_6("3051");
		}
		return result;
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x0002D7BC File Offset: 0x0002B9BC
	public List<GClass102> method_48()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_3;
		}
		else
		{
			array = this.method_53(this.byte_6);
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
			gclass.string_7 = this.method_47(gclass.byte_0);
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

	// Token: 0x060001B4 RID: 436 RVA: 0x00009148 File Offset: 0x00007348
	private string method_49(byte byte_7)
	{
		string result = "";
		if ((byte_7 & 8) != 0)
		{
			result = GClass121.smethod_6("3056");
		}
		else if ((byte_7 & 4) != 0)
		{
			result = GClass121.smethod_6("3057");
		}
		else if ((byte_7 & 2) != 0)
		{
			result = GClass121.smethod_6("3058");
		}
		else if ((byte_7 & 1) != 0)
		{
			result = GClass121.smethod_6("3059");
		}
		return result;
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x000091A4 File Offset: 0x000073A4
	private string method_50(byte byte_7)
	{
		string result = "";
		if ((byte_7 & 96) == 0)
		{
			result = GClass121.smethod_6("3052");
		}
		else if ((byte_7 & 96) == 32)
		{
			result = GClass121.smethod_6("3053");
		}
		else if ((byte_7 & 96) == 64)
		{
			result = GClass121.smethod_6("3054");
		}
		else if ((byte_7 & 96) == 96)
		{
			result = GClass121.smethod_6("3055");
		}
		return result;
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x00002F0A File Offset: 0x0000110A
	public override void r2()
	{
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00002F0A File Offset: 0x0000110A
	public override void r7(List<GClass102> list_6, List<GClass104> list_7)
	{
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x00002F0A File Offset: 0x0000110A
	protected override void r3(GClass104 gclass104_1)
	{
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x0002DB34 File Offset: 0x0002BD34
	public override string vmethod_0(byte[] byte_7, string string_22, int int_5, int int_6, string[] string_23, string string_24)
	{
		byte[] byte_8 = this.method_53(byte_7);
		if (string_22 == "raw")
		{
			return GClass127.smethod_11(byte_8);
		}
		return this.r4(byte_8, string_22, int_5, int_6, string_23, string_24);
	}

	// Token: 0x060001BA RID: 442 RVA: 0x0002DB6C File Offset: 0x0002BD6C
	private byte[] method_51(byte[] byte_7)
	{
		if (this.bool_6)
		{
			return this.method_52(byte_7);
		}
		if (this.serialPort_0 != null && this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		List<byte> list = new List<byte>();
		if (byte_7.Length < 2)
		{
			return new byte[0];
		}
		List<byte[]> list2 = new List<byte[]>();
		if (byte_7.Length < 9)
		{
			list2.Add(new byte[byte_7.Length - 1]);
			for (int i = 0; i < byte_7.Length - 1; i++)
			{
				list2[0][i] = byte_7[i + 1];
			}
		}
		else
		{
			list2.Add(new byte[8]);
			list2[0][0] = 16;
			int num = byte_7.Length - 1;
			if (num > 255)
			{
				num -= 256;
				list2[0][0] = 17;
				byte_7[0] = (byte)num;
			}
			int j = 0;
			int num2 = 1;
			while (num2 < list2[0].Length && j < byte_7.Length)
			{
				list2[0][num2] = byte_7[j];
				j++;
				num2++;
			}
			byte b = 33;
			while (j < byte_7.Length)
			{
				list2.Add(new byte[(byte_7.Length - j > 7) ? 8 : (byte_7.Length - j + 1)]);
				int index = list2.Count - 1;
				list2[index][0] = b;
				b += 1;
				if (b > 47)
				{
					b = 32;
				}
				int num3 = 1;
				while (num3 < list2[index].Length && j < byte_7.Length)
				{
					list2[index][num3] = byte_7[j];
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
			if (text.Contains("NO DATA"))
			{
				Thread.Sleep(150);
				this.ra("ATST09");
				Thread.Sleep(100);
				this.r9(GClass127.smethod_11(list2[0]));
				this.int_0 = GClass126.smethod_1();
				GClass126.smethod_2("Waiting FC2...", 0);
				text = this.rb();
			}
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
			while (text2.StartsWith("7F2278") || text2.StartsWith("7F1978") || text2.StartsWith("7F1478") || text2.StartsWith("7F2E78") || text2.StartsWith("7F1078") || text2.StartsWith("037F2278") || text2.StartsWith("037F1978") || text2.StartsWith("037F1478") || text2.StartsWith("037F2E78") || text2.StartsWith("037F1078"))
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

	// Token: 0x060001BB RID: 443 RVA: 0x0002E304 File Offset: 0x0002C504
	private byte[] method_52(byte[] byte_7)
	{
		if (this.serialPort_0 != null && this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		List<byte> list = new List<byte>();
		if (byte_7.Length < 2)
		{
			return new byte[0];
		}
		List<byte[]> list2 = new List<byte[]>();
		if (byte_7.Length < 9)
		{
			list2.Add(new byte[byte_7.Length - 1]);
			for (int i = 0; i < byte_7.Length - 1; i++)
			{
				list2[0][i] = byte_7[i + 1];
			}
		}
		else
		{
			list2.Add(new byte[8]);
			list2[0][0] = 16;
			int num = byte_7.Length - 1;
			if (num > 255)
			{
				num -= 256;
				list2[0][0] = 17;
				byte_7[0] = (byte)num;
			}
			int j = 0;
			int num2 = 1;
			while (num2 < list2[0].Length && j < byte_7.Length)
			{
				list2[0][num2] = byte_7[j];
				j++;
				num2++;
			}
			byte b = 33;
			while (j < byte_7.Length)
			{
				list2.Add(new byte[(byte_7.Length - j > 7) ? 8 : (byte_7.Length - j + 1)]);
				int index = list2.Count - 1;
				list2[index][0] = b;
				b += 1;
				if (b > 47)
				{
					b = 32;
				}
				int num3 = 1;
				while (num3 < list2[index].Length && j < byte_7.Length)
				{
					list2[index][num3] = byte_7[j];
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

	// Token: 0x060001BC RID: 444 RVA: 0x0002EA34 File Offset: 0x0002CC34
	protected byte[] method_53(byte[] byte_7)
	{
		if (this.bool_6)
		{
			return this.method_54(byte_7);
		}
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			this.int_0 = GClass126.smethod_1();
			byte[] array = this.method_51(byte_7);
			if (byte_7.Length > 1)
			{
				if (((byte_7[1] == 20 || byte_7[1] == 25 || byte_7[1] == 34) && array.Length == 0) || (array.Length > 3 && array[1] == 127 && array[3] == 33))
				{
					Thread.Sleep(100);
					array = this.method_51(byte_7);
				}
				if ((byte_7[1] == 20 || byte_7[1] == 25 || byte_7[1] == 34) && array.Length == 0)
				{
					Thread.Sleep(100);
					array = this.method_51(byte_7);
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

	// Token: 0x060001BD RID: 445 RVA: 0x0002EB74 File Offset: 0x0002CD74
	protected byte[] method_54(byte[] byte_7)
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
			byte[] array = this.method_51(byte_7);
			if ((array.Length == 0 && byte_7[1] != 16) || (array.Length > 3 && array[1] == 127 && array[3] == 33))
			{
				array = this.method_51(byte_7);
			}
			if ((array.Length == 0 && byte_7[1] != 16) || (array.Length > 3 && array[1] == 127 && array[3] == 33))
			{
				Thread.Sleep(100);
				array = this.method_51(byte_7);
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

	// Token: 0x060001BE RID: 446 RVA: 0x0002EC90 File Offset: 0x0002CE90
	public override string r4(byte[] byte_7, string string_22, int int_5, int int_6, string[] string_23, string string_24)
	{
		if (this.bool_6)
		{
			return this.method_55(byte_7, string_22, int_5, int_6, string_23, string_24);
		}
		string result = "";
		int_5 += 3;
		if (byte_7.Length <= int_5)
		{
			return result;
		}
		if (byte_7[1] == 127 && string_22 != "hex3")
		{
			return result;
		}
		int num = byte_7.Length - int_5;
		if (int_6 < num)
		{
			num = int_6;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_7[i + int_5];
		}
		return base.method_33(array, string_22, string_23, string_24);
	}

	// Token: 0x060001BF RID: 447 RVA: 0x00019EBC File Offset: 0x000180BC
	public string method_55(byte[] byte_7, string string_22, int int_5, int int_6, string[] string_23, string string_24)
	{
		string result = "";
		int_5 += 2;
		if (byte_7.Length <= int_5)
		{
			return result;
		}
		if (byte_7[1] == 127 && string_22 != "hex3")
		{
			return result;
		}
		int num = byte_7.Length - int_5;
		if (int_6 < num)
		{
			num = int_6;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_7[i + int_5];
		}
		return base.method_33(array, string_22, string_23, string_24);
	}

	// Token: 0x0400013D RID: 317
	protected bool bool_6;

	// Token: 0x0400013E RID: 318
	protected bool bool_7;

	// Token: 0x0400013F RID: 319
	protected byte[] byte_3 = new byte[]
	{
		7,
		89,
		2,
		207,
		129,
		16,
		21,
		14
	};

	// Token: 0x04000140 RID: 320
	protected byte[] byte_4 = new byte[]
	{
		3,
		25,
		2,
		8
	};

	// Token: 0x04000141 RID: 321
	protected byte[] byte_5 = new byte[]
	{
		4,
		20,
		byte.MaxValue,
		byte.MaxValue,
		byte.MaxValue
	};

	// Token: 0x04000142 RID: 322
	protected byte[] byte_6 = new byte[]
	{
		4,
		24,
		0,
		byte.MaxValue,
		0
	};

	// Token: 0x04000143 RID: 323
	private char[] char_1 = new char[]
	{
		'\r',
		'\n',
		' '
	};
}
