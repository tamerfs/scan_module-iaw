using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x02000022 RID: 34
public abstract class GClass85 : GClass11
{
	// Token: 0x0600021D RID: 541 RVA: 0x000381DC File Offset: 0x000363DC
	protected void method_45()
	{
		if (GClass126.bool_0)
		{
			byte[][] array = new byte[][]
			{
				new byte[]
				{
					26,
					0,
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
					3
				},
				new byte[]
				{
					26,
					0,
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
					3
				},
				new byte[]
				{
					14,
					0,
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
					3
				},
				new byte[]
				{
					13,
					246,
					52,
					57,
					57,
					51,
					48,
					50,
					49,
					54,
					50,
					48,
					51,
					57,
					54,
					53,
					53,
					51,
					55,
					50,
					50,
					50,
					55,
					48,
					48,
					32,
					52,
					48,
					52,
					32,
					54,
					52
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
					gclass.method_1(this.string_7);
				}
				else
				{
					gclass.method_1(this.r4(array[3], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
			}
			this.bool_1 = false;
			this.bool_0 = true;
			new Thread(new ThreadStart(this.method_51))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_36();
			throw new Exception("1");
		}
	}

	// Token: 0x0600021E RID: 542
	protected abstract void r6();

	// Token: 0x0600021F RID: 543 RVA: 0x00038334 File Offset: 0x00036534
	public override void vmethod_1()
	{
		try
		{
			GClass126.smethod_2("-----------------------", 0);
			GClass126.smethod_2("Control module (71): " + GClass127.smethod_23(this.byte_0), 0);
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
				if (GClass126.bool_25)
				{
					throw new Exception("ESC");
				}
				if (this.genum0_0 == (GEnum0)0)
				{
					Thread thread = new Thread(new ThreadStart(this.method_52));
					thread.Priority = ThreadPriority.Highest;
					this.bool_1 = false;
					thread.Start();
					new Thread(new ThreadStart(this.method_51))
					{
						Priority = ThreadPriority.Highest
					}.Start();
				}
				for (int j = 0; j < this.list_1.Count; j++)
				{
					GClass104 gclass = this.list_1[j];
					if (gclass.byte_0[0][0] == 0)
					{
						gclass.method_1(this.string_7);
					}
					else
					{
						gclass.method_1(this.vmethod_0(gclass.byte_0[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					}
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

	// Token: 0x06000220 RID: 544 RVA: 0x000385D8 File Offset: 0x000367D8
	public List<GClass102> method_46()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_6;
		}
		else
		{
			array = this.method_50(this.byte_7);
		}
		if (array.Length >= 2)
		{
			if (array[1] == 252 || array[1] == 9)
			{
				try
				{
					for (int i = 2; i < array.Length - 2; i += 3)
					{
						GClass102 gclass = new GClass102();
						gclass.string_0 = GClass127.smethod_11(new byte[]
						{
							array[i + 1]
						}).Replace(" ", "");
						gclass.byte_0 = array[i];
						gclass.byte_1 = array[i + 2];
						gclass.string_5 = "";
						gclass.string_6 = "";
						gclass.string_7 = "";
						gclass.string_2 = GClass127.smethod_11(new byte[]
						{
							array[i + 1]
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
						if (gclass.string_0 != "FF")
						{
							list.Add(gclass);
						}
					}
				}
				catch (Exception ex)
				{
					GClass126.smethod_2("ERROR READING DTC: " + ex.Message, 0);
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x06000221 RID: 545 RVA: 0x000388E0 File Offset: 0x00036AE0
	public override List<GClass102> r1()
	{
		if (this.string_0 == "MA1.7.3")
		{
			return this.method_46();
		}
		if (this.string_0 == "M1.7X01")
		{
			return this.method_46();
		}
		if (this.string_0 == "M1.7X02")
		{
			return this.method_46();
		}
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_5;
		}
		else
		{
			array = this.method_50(this.byte_7);
		}
		if (array.Length >= 2)
		{
			if (array[1] == 252 || array[1] == 9)
			{
				try
				{
					for (int i = 2; i < array.Length - 3; i += 5)
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
						if ((int)(gclass.byte_0 & 31) <= this.string_22.Length)
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
					}
				}
				catch (Exception ex)
				{
					GClass126.smethod_2("ERROR READING DTC: " + ex.Message, 0);
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x06000222 RID: 546 RVA: 0x00009148 File Offset: 0x00007348
	private string method_47(byte byte_10)
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

	// Token: 0x06000223 RID: 547 RVA: 0x00038C20 File Offset: 0x00036E20
	public override void r2()
	{
		if (GClass126.bool_0)
		{
			this.byte_5 = new byte[]
			{
				2,
				252
			};
			return;
		}
		byte[] array = this.method_50(this.byte_8);
		if (array.Length < 2 || array[1] != 9)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x06000224 RID: 548 RVA: 0x00038C74 File Offset: 0x00036E74
	protected override void r3(GClass104 gclass104_1)
	{
		if (!GClass126.bool_0)
		{
			this.method_48(gclass104_1);
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

	// Token: 0x06000225 RID: 549 RVA: 0x00038CFC File Offset: 0x00036EFC
	private void method_48(GClass104 gclass104_1)
	{
		byte[] array = this.method_50(gclass104_1.byte_0[0]);
		if (array.Length != 0)
		{
			if (array.Length <= 1 || array[1] == 9)
			{
				if (gclass104_1.byte_0.Length > 2)
				{
					for (int i = 1; i < gclass104_1.byte_0.Length; i++)
					{
						if (!gclass104_1.string_2.Contains("NOWAIT"))
						{
							Thread.Sleep(2000);
						}
						this.method_50(gclass104_1.byte_0[i]);
					}
				}
				else if (gclass104_1.byte_0.Length == 2)
				{
					for (int j = 1; j < gclass104_1.byte_0.Length; j++)
					{
						if (!gclass104_1.string_2.Contains("NOWAIT"))
						{
							Thread.Sleep(6000);
						}
						if (!gclass104_1.string_2.Contains("NOWAIT"))
						{
							Thread.Sleep(2000);
						}
						this.method_50(gclass104_1.byte_0[j]);
					}
				}
				else if (!gclass104_1.string_2.Contains("NOWAIT"))
				{
					Thread.Sleep(9000);
				}
				base.method_28(false, GClass121.smethod_6("6051"), "");
				return;
			}
		}
		string string_ = "";
		base.method_28(false, GClass121.smethod_6("6052"), string_);
		if (!gclass104_1.string_2.Contains("NOWAIT"))
		{
			Thread.Sleep(1800);
		}
	}

	// Token: 0x06000226 RID: 550 RVA: 0x00038E50 File Offset: 0x00037050
	public override string vmethod_0(byte[] byte_10, string string_23, int int_13, int int_14, string[] string_24, string string_25)
	{
		byte[] array = this.method_50(byte_10);
		if (array.Length == 0)
		{
			array = this.method_50(byte_10);
		}
		if (array.Length == 0)
		{
			array = this.method_50(byte_10);
		}
		if (string_23 == "raw")
		{
			return GClass127.smethod_11(array);
		}
		return this.r4(array, string_23, int_13, int_14, string_24, string_25);
	}

	// Token: 0x06000227 RID: 551 RVA: 0x00038EA0 File Offset: 0x000370A0
	private byte[] method_49(byte[] byte_10)
	{
		List<byte> list = new List<byte>();
		if (byte_10.Length < 4)
		{
			return new byte[0];
		}
		byte[] array = new byte[byte_10.Length - 3];
		for (int i = 2; i < byte_10.Length - 1; i++)
		{
			array[i - 2] = byte_10[i];
		}
		if (GClass125.smethod_49() && byte_10.Length == 5 && byte_10[1] == 255 && byte_10[2] == 255)
		{
			this.r9("ATGR" + GClass127.smethod_23(byte_10[3]));
		}
		else if (GClass125.smethod_49() && byte_10.Length == 4 && byte_10[0] == 3 && byte_10[2] == 9)
		{
			this.r9("ATGR07");
		}
		else if (GClass125.smethod_49())
		{
			this.r9(GClass127.smethod_11(array) + "1");
		}
		else
		{
			this.r9(GClass127.smethod_11(array));
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
			string text2 = text.Substring(0, num);
			if (GClass125.smethod_49())
			{
				text2 += "03";
			}
			byte[] array2 = GClass127.smethod_32(text2);
			if (array2.Length != 0)
			{
				list.Add((byte)(array2.Length + 2));
			}
			for (int j = 0; j < array2.Length - 1; j++)
			{
				list.Add(array2[j]);
			}
			text = text.Substring(num + 1);
			while (text.Length > 2)
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
				if (num <= 1)
				{
					break;
				}
				text2 = text.Substring(0, num);
				if (GClass125.smethod_49())
				{
					text2 += "03";
				}
				array2 = GClass127.smethod_32(text2);
				if (array2.Length > 2)
				{
					for (int k = 1; k < array2.Length - 1; k++)
					{
						list.Add(array2[k]);
					}
				}
				text = text.Substring(num + 1);
			}
			if (list.Count > 0)
			{
				list.Add(3);
			}
			return list.ToArray();
		}
		throw new Exception("DISCONNECTED");
	}

	// Token: 0x06000228 RID: 552 RVA: 0x000390FC File Offset: 0x000372FC
	protected byte[] method_50(byte[] byte_10)
	{
		byte[] array = new byte[0];
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			if (GClass125.smethod_44() == 4 || GClass125.smethod_44() == 5)
			{
				while (this.int_0 + this.int_12 > GClass126.smethod_1())
				{
				}
			}
			this.int_0 = GClass126.smethod_1();
			array = this.method_49(byte_10);
			GClass126.smethod_2("DECODED RESPONSE: " + GClass127.smethod_11(array), 0);
			this.int_1 = 0;
		}
		catch (Exception ex)
		{
			if (!this.bool_1)
			{
				GClass126.smethod_2(ex.Message + "(3)", 1);
				this.bool_2 = false;
				this.int_1++;
				if (this.int_1 > 2)
				{
					GClass126.smethod_2("Terminate 5", 1);
					base.method_30(true);
				}
			}
			array = new byte[0];
		}
		finally
		{
			this.bool_2 = false;
		}
		return array;
	}

	// Token: 0x06000229 RID: 553 RVA: 0x000325E4 File Offset: 0x000307E4
	public override string r4(byte[] byte_10, string string_23, int int_13, int int_14, string[] string_24, string string_25)
	{
		string result = "";
		int_13++;
		if (byte_10.Length <= int_13)
		{
			return result;
		}
		int num = byte_10.Length - int_13;
		if (int_14 < num)
		{
			num = int_14;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_10[i + int_13];
		}
		return base.method_33(array, string_23, string_24, string_25);
	}

	// Token: 0x0600022A RID: 554 RVA: 0x000391FC File Offset: 0x000373FC
	private void method_51()
	{
		GClass126.smethod_2("PM started", 1);
		GClass126.int_3 = 0;
		int num = 0;
		SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
		while (!this.bool_1)
		{
			Thread.Sleep(50);
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
									byte[] value = this.method_50(gclass.byte_0[0]);
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

	// Token: 0x0600022B RID: 555 RVA: 0x000397F0 File Offset: 0x000379F0
	private void method_52()
	{
		if (GClass125.smethod_44() != 4)
		{
			if (GClass125.smethod_44() != 5)
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
									goto IL_7D;
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
					IL_7D:
					if (GClass126.smethod_1() > this.int_0 + this.int_11 && !this.bool_2)
					{
						byte[] array = this.method_50(this.byte_3);
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
				return;
			}
		}
	}

	// Token: 0x0400018B RID: 395
	private int int_5 = 2000;

	// Token: 0x0400018C RID: 396
	private int int_6 = 3;

	// Token: 0x0400018D RID: 397
	private int int_7 = 1000;

	// Token: 0x0400018E RID: 398
	private int int_8 = 3;

	// Token: 0x0400018F RID: 399
	private int int_9 = 41;

	// Token: 0x04000190 RID: 400
	private int int_10 = 3;

	// Token: 0x04000191 RID: 401
	private int int_11 = 420;

	// Token: 0x04000192 RID: 402
	private int int_12 = 280;

	// Token: 0x04000193 RID: 403
	private byte[] byte_3 = new byte[]
	{
		3,
		0,
		9,
		3
	};

	// Token: 0x04000194 RID: 404
	protected byte[] byte_4 = new byte[]
	{
		3,
		0,
		9,
		3
	};

	// Token: 0x04000195 RID: 405
	private byte[] byte_5 = new byte[]
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

	// Token: 0x04000196 RID: 406
	private byte[] byte_6 = new byte[]
	{
		21,
		252,
		70,
		58,
		17,
		2,
		10,
		155
	};

	// Token: 0x04000197 RID: 407
	private byte[] byte_7 = new byte[]
	{
		3,
		0,
		7,
		3
	};

	// Token: 0x04000198 RID: 408
	private byte[] byte_8 = new byte[]
	{
		3,
		0,
		5,
		3
	};

	// Token: 0x04000199 RID: 409
	private byte byte_9;

	// Token: 0x0400019A RID: 410
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
		GClass121.smethod_6("3098")
	};
}
