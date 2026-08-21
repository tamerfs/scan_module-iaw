using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x02000024 RID: 36
public abstract class GClass28 : GClass19
{
	// Token: 0x06000189 RID: 393 RVA: 0x0004ED10 File Offset: 0x0004CF10
	protected void method_33()
	{
		if (GClass3.bool_0)
		{
			byte[][] array = new byte[][]
			{
				new byte[]
				{
					26,
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
					54
				},
				new byte[]
				{
					26,
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
					69
				},
				new byte[]
				{
					14,
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
					78
				}
			};
			for (int i = 0; i < 20; i++)
			{
				if (GClass3.bool_14)
				{
					throw new Exception("ESC");
				}
				Thread.Sleep(100);
			}
			GClass3.smethod_2("Testing mode!", 1);
			this.string_3 = "26 86 9B 02 9E";
			for (int i = 0; i < this.list_1.Count; i++)
			{
				GClass58 gclass = this.list_1[i];
				if (gclass.byte_0[0][0] == 0)
				{
					gclass.method_1(this.string_3);
				}
				else if (this.string_0 == "CLIMA25")
				{
					gclass.method_1(this.vmethod_7(GClass16.smethod_2("1B AE AA 55 CC 33 00 3C 41 32 14 97 02 77 01 16 23 80 79 10 AE 00 90 32 32 AA 08"), gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
				else
				{
					gclass.method_1(this.vmethod_7(array[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
			}
			this.bool_1 = false;
			this.bool_0 = true;
			new Thread(new ThreadStart(this.method_46))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_28();
			throw new Exception("1");
		}
	}

	// Token: 0x0600018A RID: 394
	protected abstract void vmethod_8(GEnum0 genum0_0);

	// Token: 0x0600018B RID: 395 RVA: 0x0004EEBC File Offset: 0x0004D0BC
	public override void vmethod_1(GEnum0 genum0_0)
	{
		try
		{
			if (genum0_0 == (GEnum0)0)
			{
				for (int i = 0; i < 5; i++)
				{
					if (GClass3.bool_14)
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(100);
				}
			}
			if (GClass3.bool_0)
			{
				this.method_33();
			}
			else
			{
				this.vmethod_8(genum0_0);
			}
			if (GClass3.bool_14)
			{
				throw new Exception("ESC");
			}
			if (this.string_0 == "CLIMA25")
			{
				this.byte_2 = GClass16.smethod_2("03 09 00");
				this.byte_7 = GClass16.smethod_2("03 50 00");
				this.byte_8 = GClass16.smethod_2("03 60 00");
			}
			if (genum0_0 == (GEnum0)0)
			{
				Thread thread = new Thread(new ThreadStart(this.method_47));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_46))
				{
					Priority = ThreadPriority.Highest
				}.Start();
			}
			for (int i = 0; i < this.list_1.Count; i++)
			{
				GClass58 gclass = this.list_1[i];
				if (gclass.byte_0[0][0] == 0)
				{
					gclass.method_1(this.string_3);
				}
				else
				{
					gclass.method_1(this.vmethod_0(gclass.byte_0[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
			}
			if (genum0_0 == (GEnum0)2)
			{
				Thread.Sleep(200);
				this.list_3 = this.vmethod_3();
			}
			if (genum0_0 != (GEnum0)0)
			{
				base.method_22(false);
			}
			else
			{
				this.bool_0 = true;
				base.method_28();
			}
		}
		catch (Exception ex)
		{
			GClass3.smethod_2(ex.Message, 2);
			GClass3.smethod_2("Terminate 4", 1);
			base.method_22(ex.Message != "0");
		}
	}

	// Token: 0x0600018C RID: 396 RVA: 0x0004F0C4 File Offset: 0x0004D2C4
	public override void vmethod_2(bool bool_5, bool bool_6)
	{
		if (!this.bool_1)
		{
			GClass3.smethod_2("Terminating " + (bool_5 ? "with reconnect" : string.Empty), 1);
			if (!GClass3.bool_0 || bool_6)
			{
				this.bool_1 = true;
				this.bool_0 = false;
				Thread.Sleep(500);
				if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
				{
					try
					{
						this.serialPort_0.ReadTimeout = 100;
						if (GClass61.smethod_36() == 4)
						{
							this.method_44("ATZ");
						}
						else
						{
							this.method_44("ATPC");
						}
					}
					catch (Exception)
					{
					}
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
				base.method_29(bool_6);
			}
		}
	}

	// Token: 0x0600018D RID: 397 RVA: 0x0004F1EC File Offset: 0x0004D3EC
	public List<GClass64> method_34()
	{
		List<GClass64> list = new List<GClass64>();
		byte[] array;
		if (GClass3.bool_0)
		{
			array = this.byte_4;
		}
		else
		{
			array = this.method_42(this.byte_7);
		}
		List<GClass64> result;
		if (array.Length < 18 || array[1] != 252)
		{
			GClass3.smethod_2("ERROR: Error reading stored DTC codes", 1);
			result = null;
		}
		else
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if ((array[2 + i] & this.byte_9[j]) != 0 || (array[10 + i] & this.byte_9[j]) != 0)
					{
						try
						{
							GClass64 gclass = new GClass64();
							byte byte_ = (byte)(i * 8 + (j + 1));
							gclass.string_0 = GClass16.smethod_0(byte_);
							gclass.byte_0 = (((array[10 + i] & this.byte_9[j]) != 0) ? 1 : 0);
							GClass64 gclass2 = gclass;
							gclass2.byte_0 += (((array[2 + i] & this.byte_9[j]) != 0) ? 10 : 0);
							gclass.byte_1 = 32;
							gclass.string_4 = string.Empty;
							gclass.string_5 = string.Empty;
							gclass.string_6 = string.Empty;
							gclass.string_1 = string.Empty;
							string string_ = string.Empty;
							if (gclass.byte_0 == 1)
							{
								string_ = GClass62.smethod_1("3062");
							}
							else if (gclass.byte_0 == 10)
							{
								string_ = GClass62.smethod_1("3053");
							}
							else if (gclass.byte_0 == 11)
							{
								string_ = GClass62.smethod_1("3062") + "/" + GClass62.smethod_1("3053");
							}
							string str = string.Empty;
							if (gclass.byte_0 == 1)
							{
								str = GClass62.smethod_1("3077");
							}
							else if (gclass.byte_0 == 10)
							{
								str = GClass62.smethod_1("3076");
							}
							else if (gclass.byte_0 == 11)
							{
								str = GClass62.smethod_1("3078");
							}
							gclass.string_5 = string_;
							GClass64 gclass3 = gclass;
							gclass3.string_2 = gclass3.string_2 + str + "\r\n";
							list.Add(gclass);
							goto IL_243;
						}
						catch (Exception)
						{
							GClass3.smethod_2("ERROR: Exception while reading error codes.", 0);
							goto IL_243;
						}
						break;
					}
					IL_243:;
				}
			}
			result = list;
		}
		return result;
	}

	// Token: 0x0600018E RID: 398 RVA: 0x0004F468 File Offset: 0x0004D668
	public List<GClass64> method_35()
	{
		List<GClass64> list = new List<GClass64>();
		byte[] array;
		if (GClass3.bool_0)
		{
			array = this.byte_6;
		}
		else
		{
			array = this.method_42(this.byte_7);
		}
		List<GClass64> result;
		if (array.Length < 2)
		{
			GClass3.smethod_2("ERROR: Error reading stored DTC codes", 1);
			result = null;
		}
		else
		{
			for (int i = 2; i < array.Length - 1; i++)
			{
				if (array[i] != 0)
				{
					try
					{
						GClass64 gclass = new GClass64();
						gclass.string_0 = ((i - 1 < 10) ? "0" : string.Empty) + (i - 1);
						gclass.byte_0 = array[i];
						gclass.byte_1 = 32;
						gclass.string_4 = string.Empty;
						gclass.string_5 = string.Empty;
						gclass.string_6 = string.Empty;
						gclass.string_1 = string.Empty;
						string string_ = GClass62.smethod_1("3062");
						if (gclass.byte_0 == 1)
						{
							string_ = GClass62.smethod_1("3054");
						}
						gclass.string_5 = string_;
						list.Add(gclass);
					}
					catch (Exception)
					{
						GClass3.smethod_2("ERROR: Exception while reading error codes.", 0);
					}
				}
			}
			result = list;
		}
		return result;
	}

	// Token: 0x0600018F RID: 399 RVA: 0x0004F5A8 File Offset: 0x0004D7A8
	public List<GClass64> method_36()
	{
		List<GClass64> list = new List<GClass64>();
		byte[] array = this.byte_3;
		int num = 10;
		while (array.Length > 3 && num > 0)
		{
			if (GClass3.bool_0)
			{
				array = this.byte_3;
			}
			else
			{
				array = this.method_42(this.byte_7);
			}
			if (array.Length < 2 && num == 10)
			{
				GClass3.smethod_2("ERROR: Error reading stored DTC codes", 1);
				return null;
			}
			for (int i = 2; i < array.Length - 5; i += 5)
			{
				try
				{
					GClass64 gclass = new GClass64();
					gclass.string_0 = GClass16.smethod_1(new byte[]
					{
						array[i]
					}).Replace(" ", string.Empty);
					gclass.byte_0 = array[i + 1];
					gclass.byte_1 = array[i + 4];
					gclass.string_4 = string.Empty;
					gclass.string_5 = string.Empty;
					gclass.string_6 = string.Empty;
					gclass.string_1 = GClass16.smethod_1(new byte[]
					{
						array[i]
					}).Replace(" ", string.Empty);
					string text = GClass62.smethod_1("3099");
					if ((int)(gclass.byte_0 & 31) < this.string_7.Length)
					{
						text = this.string_7[(int)(gclass.byte_0 & 31)];
					}
					gclass.string_4 = text;
					GClass64 gclass2 = gclass;
					string string_ = gclass2.string_2;
					gclass2.string_2 = string.Concat(new string[]
					{
						string_,
						GClass62.smethod_1("3070"),
						" ",
						text,
						"\r\n"
					});
					string text2 = string.Empty;
					if ((gclass.byte_0 & 128) != 0)
					{
						text2 += GClass62.smethod_1("3060");
					}
					if ((gclass.byte_0 & 64) != 0)
					{
						text2 = text2 + ((text2.Length > 0) ? " / " : string.Empty) + GClass62.smethod_1("3061");
					}
					if ((gclass.byte_0 & 32) != 0)
					{
						text2 = text2 + ((text2.Length > 0) ? " / " : string.Empty) + GClass62.smethod_1("3062");
					}
					gclass.string_5 = text2;
					GClass64 gclass3 = gclass;
					string_ = gclass3.string_2;
					gclass3.string_2 = string.Concat(new string[]
					{
						string_,
						GClass62.smethod_1("3071"),
						" ",
						text2,
						"\r\n"
					});
					GClass64 gclass4 = gclass;
					object string_2 = gclass4.string_2;
					gclass4.string_2 = string.Concat(new object[]
					{
						string_2,
						GClass62.smethod_1("3072"),
						" ",
						gclass.byte_1,
						"\r\n"
					});
					gclass.string_6 = string.Concat(gclass.byte_1);
					bool flag = false;
					foreach (GClass64 gclass5 in list)
					{
						if (gclass5.string_0 == gclass.string_0)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						list.Add(gclass);
					}
					goto IL_367;
				}
				catch (Exception)
				{
					GClass3.smethod_2("ERROR: Exception while reading error codes.", 0);
					goto IL_367;
				}
				break;
				IL_367:;
			}
			num--;
		}
		return list;
	}

	// Token: 0x06000190 RID: 400 RVA: 0x0004F970 File Offset: 0x0004DB70
	public override List<GClass64> vmethod_3()
	{
		List<GClass64> result;
		if (this.string_0 == "ABSTEVES")
		{
			result = this.method_34();
		}
		else if (this.string_0 == "HTCHI")
		{
			result = this.method_36();
		}
		else if (this.string_0 == "CLIMA25")
		{
			result = this.method_35();
		}
		else
		{
			List<GClass64> list = new List<GClass64>();
			byte[] array;
			if (GClass3.bool_0 && this.string_0 == "TD100")
			{
				array = this.byte_5;
			}
			else if (GClass3.bool_0)
			{
				array = this.byte_3;
			}
			else
			{
				array = this.method_42(this.byte_7);
			}
			if (array.Length < 2 || array[1] != 252)
			{
				GClass3.smethod_2("ERROR: Error reading stored DTC codes", 1);
				result = null;
			}
			else
			{
				int i = 2;
				while (i < array.Length - 4)
				{
					try
					{
						GClass64 gclass = new GClass64();
						gclass.string_0 = GClass16.smethod_1(new byte[]
						{
							array[i]
						}).Replace(" ", string.Empty);
						gclass.byte_0 = array[i + 1];
						gclass.byte_1 = array[i + 4];
						gclass.string_4 = string.Empty;
						gclass.string_5 = string.Empty;
						gclass.string_6 = string.Empty;
						gclass.string_1 = GClass16.smethod_1(new byte[]
						{
							array[i]
						}).Replace(" ", string.Empty);
						string text = GClass62.smethod_1("3099");
						if ((int)(gclass.byte_0 & 31) < this.string_7.Length)
						{
							text = this.string_7[(int)(gclass.byte_0 & 31)];
						}
						gclass.string_4 = text;
						GClass64 gclass2 = gclass;
						string string_ = gclass2.string_2;
						gclass2.string_2 = string.Concat(new string[]
						{
							string_,
							GClass62.smethod_1("3070"),
							" ",
							text,
							"\r\n"
						});
						string text2 = string.Empty;
						if ((gclass.byte_0 & 128) != 0)
						{
							text2 += GClass62.smethod_1("3060");
						}
						if ((gclass.byte_0 & 64) != 0)
						{
							text2 = text2 + ((text2.Length > 0) ? " / " : string.Empty) + GClass62.smethod_1("3061");
						}
						if ((gclass.byte_0 & 32) != 0)
						{
							text2 = text2 + ((text2.Length > 0) ? " / " : string.Empty) + GClass62.smethod_1("3062");
						}
						gclass.string_5 = text2;
						GClass64 gclass3 = gclass;
						string_ = gclass3.string_2;
						gclass3.string_2 = string.Concat(new string[]
						{
							string_,
							GClass62.smethod_1("3071"),
							" ",
							text2,
							"\r\n"
						});
						GClass64 gclass4 = gclass;
						object string_2 = gclass4.string_2;
						gclass4.string_2 = string.Concat(new object[]
						{
							string_2,
							GClass62.smethod_1("3072"),
							" ",
							gclass.byte_1,
							"\r\n"
						});
						gclass.string_6 = string.Concat(gclass.byte_1);
						list.Add(gclass);
						goto IL_397;
					}
					catch (Exception ex)
					{
						GClass3.smethod_2("ERROR: Exception while reading error codes: " + ex.Message, 0);
						goto IL_397;
					}
					IL_38E:
					i++;
					continue;
					IL_397:
					i += 5;
					if (this.string_0 == "TD100")
					{
						goto IL_38E;
					}
				}
				result = list;
			}
		}
		return result;
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00018938 File Offset: 0x00016B38
	private string method_37(byte byte_10)
	{
		string result = string.Empty;
		if ((byte_10 & 8) != 0)
		{
			result = GClass62.smethod_1("3056");
		}
		else if ((byte_10 & 4) != 0)
		{
			result = GClass62.smethod_1("3057");
		}
		else if ((byte_10 & 2) != 0)
		{
			result = GClass62.smethod_1("3058");
		}
		else if ((byte_10 & 1) != 0)
		{
			result = GClass62.smethod_1("3059");
		}
		return result;
	}

	// Token: 0x06000192 RID: 402 RVA: 0x0004FD54 File Offset: 0x0004DF54
	public override void vmethod_5()
	{
		if (GClass3.bool_0)
		{
			this.byte_3 = new byte[]
			{
				2,
				252
			};
		}
		else
		{
			byte[] array = this.method_42(this.byte_8);
			if (array.Length < 2 || array[1] != 9)
			{
				GClass3.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
	}

	// Token: 0x06000193 RID: 403 RVA: 0x0004FDB4 File Offset: 0x0004DFB4
	protected override void vmethod_6(GClass58 gclass58_1)
	{
		if (GClass3.bool_0)
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
		else
		{
			this.method_38(gclass58_1);
		}
	}

	// Token: 0x06000194 RID: 404 RVA: 0x0004FE30 File Offset: 0x0004E030
	private void method_38(GClass58 gclass58_1)
	{
		byte[] array = this.method_42(gclass58_1.byte_0[0]);
		if (array.Length == 0 || (array.Length > 1 && array[1] != 9 && array[1] != 13))
		{
			string empty = string.Empty;
			base.method_31(false, GClass62.smethod_1("6052"), empty);
			for (int i = 0; i < 18; i++)
			{
				if (!GClass3.bool_14)
				{
					Thread.Sleep(100);
				}
			}
		}
		else
		{
			if (gclass58_1.byte_0.Length > 2)
			{
				for (int j = 1; j < gclass58_1.byte_0.Length; j++)
				{
					for (int i = 0; i < 20; i++)
					{
						if (!GClass3.bool_14)
						{
							Thread.Sleep(100);
						}
					}
					this.method_42(gclass58_1.byte_0[j]);
				}
			}
			else if (gclass58_1.byte_0.Length == 2)
			{
				for (int j = 1; j < gclass58_1.byte_0.Length; j++)
				{
					for (int i = 0; i < 80; i++)
					{
						if (!GClass3.bool_14)
						{
							Thread.Sleep(100);
						}
					}
					this.method_42(gclass58_1.byte_0[j]);
				}
			}
			else
			{
				for (int i = 0; i < 100; i++)
				{
					if (!GClass3.bool_14)
					{
						Thread.Sleep(100);
					}
				}
			}
			base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
		}
	}

	// Token: 0x06000195 RID: 405 RVA: 0x0004FF80 File Offset: 0x0004E180
	public override string vmethod_0(byte[] byte_10, string string_16, int int_12, int int_13, string[] string_17, string string_18)
	{
		byte[] array = this.method_42(byte_10);
		return this.vmethod_7(array, string_16, int_12, int_13, string_17, string_18);
	}

	// Token: 0x06000196 RID: 406 RVA: 0x0004FFA8 File Offset: 0x0004E1A8
	private byte[] method_39(byte[] byte_10)
	{
		byte[] array = new byte[byte_10.Length + 1];
		byte b = 0;
		for (int i = 0; i < byte_10.Length; i++)
		{
			array[i] = byte_10[i];
			b += byte_10[i];
		}
		array[array.Length - 1] = b;
		this.method_43(GClass16.smethod_1(array));
		string text = this.method_45();
		byte[] result;
		if (text.Contains("NO DATA") || text.Contains("ERROR"))
		{
			result = new byte[0];
		}
		else
		{
			int num = 0;
			while (num < text.Length && text[num] != '\r' && text[num] != '\n' && text[num] != '>')
			{
				num++;
			}
			string text2 = text.Substring(0, num);
			result = GClass16.smethod_2(text2);
		}
		return result;
	}

	// Token: 0x06000197 RID: 407 RVA: 0x00050080 File Offset: 0x0004E280
	private byte[] method_40(byte[] byte_10)
	{
		byte[] array = new byte[byte_10.Length];
		byte b = 0;
		for (int i = 0; i < byte_10.Length; i++)
		{
			if (i > 0)
			{
				array[i - 1] = byte_10[i];
			}
			b += byte_10[i];
		}
		array[array.Length - 1] = b;
		this.method_43(GClass16.smethod_1(array));
		string text = this.method_45();
		byte[] result;
		if (text.Contains("NO DATA") || text.Contains("ERROR"))
		{
			result = new byte[0];
		}
		else
		{
			int num = 0;
			while (num < text.Length && text[num] != '\r' && text[num] != '\n' && text[num] != '>')
			{
				num++;
			}
			string text2 = "00" + text.Substring(0, num);
			result = GClass16.smethod_2(text2);
		}
		return result;
	}

	// Token: 0x06000198 RID: 408 RVA: 0x0005016C File Offset: 0x0004E36C
	private byte[] method_41(byte[] byte_10)
	{
		byte[] result;
		if (GClass61.smethod_36() == 4 || GClass61.smethod_36() == 5)
		{
			result = this.method_39(byte_10);
		}
		else if (GClass61.smethod_36() == 7)
		{
			result = this.method_40(byte_10);
		}
		else
		{
			this.method_43(GClass16.smethod_1(byte_10));
			string text = this.method_45();
			if (text.Contains("NO DATA") || text.Contains("ERROR"))
			{
				result = new byte[0];
			}
			else
			{
				int num = 0;
				while (num < text.Length && text[num] != '\r' && text[num] != '\n' && text[num] != '>')
				{
					num++;
				}
				string text2 = text.Substring(0, num);
				result = GClass16.smethod_2(text2);
			}
		}
		return result;
	}

	// Token: 0x06000199 RID: 409 RVA: 0x00050244 File Offset: 0x0004E444
	private byte[] method_42(byte[] byte_10)
	{
		List<byte> list = new List<byte>();
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			this.int_0 = GClass3.smethod_1();
			byte[] array = this.method_41(byte_10);
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i]);
			}
			int num = 10;
			if (this.string_0 == "CLIMA25")
			{
				num = 0;
			}
			if (array.Length < 6)
			{
				num = 0;
			}
			while (array.Length > 0 && array[1] != 9 && num > 0)
			{
				array = this.method_41(this.byte_2);
				if (array.Length > 2)
				{
					for (int i = 2; i < array.Length; i++)
					{
						list.Add(array[i]);
					}
				}
				num--;
			}
			this.int_0 = GClass3.smethod_1();
			this.bool_2 = false;
			GClass3.smethod_2("DECODED RESPONSE: " + GClass16.smethod_1(list.ToArray()), 0);
			result = list.ToArray();
		}
		catch (Exception ex)
		{
			if (!this.bool_1)
			{
				GClass3.smethod_2(ex.Message + "(3)", 1);
				this.bool_2 = false;
				GClass3.smethod_2("Terminate 5", 1);
				base.method_22(true);
			}
			this.bool_2 = false;
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x0600019A RID: 410 RVA: 0x00035A9C File Offset: 0x00033C9C
	public override string vmethod_7(byte[] byte_10, string string_16, int int_12, int int_13, string[] string_17, string string_18)
	{
		string text = string.Empty;
		int_12++;
		string result;
		if (byte_10.Length <= int_12)
		{
			result = text;
		}
		else
		{
			int num = byte_10.Length - int_12;
			if (int_13 < num)
			{
				num = int_13;
			}
			byte[] array = new byte[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = byte_10[i + int_12];
			}
			text = base.method_32(array, string_16, string_17, string_18);
			result = text;
		}
		return result;
	}

	// Token: 0x0600019B RID: 411 RVA: 0x000503A8 File Offset: 0x0004E5A8
	protected void method_43(string string_16)
	{
		string text = string_16.Replace(this.string_8, this.string_9);
		GClass3.smethod_2(this.string_10 + text, 0);
		if (!GClass61.smethod_38())
		{
			this.serialPort_0.WriteLine(text);
		}
		else
		{
			for (int i = 0; i < text.Length; i++)
			{
				this.serialPort_0.Write(text.Substring(i, 1));
			}
			this.serialPort_0.Write(this.serialPort_0.NewLine);
		}
	}

	// Token: 0x0600019C RID: 412 RVA: 0x0005042C File Offset: 0x0004E62C
	protected string method_44(string string_16)
	{
		if (this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		this.method_43(string_16);
		string text = this.method_45();
		if (!text.Contains(this.string_11))
		{
			GClass3.smethod_2(this.string_12 + string_16 + this.string_13, 0);
			if (GClass61.smethod_38())
			{
				this.method_43(string_16);
				text = this.method_45();
			}
		}
		this.int_0 = GClass3.smethod_1();
		return text;
	}

	// Token: 0x0600019D RID: 413 RVA: 0x000504B4 File Offset: 0x0004E6B4
	protected string method_45()
	{
		string text = this.string_9;
		while (!text.EndsWith(this.string_14))
		{
			text += (char)this.serialPort_0.ReadByte();
		}
		GClass3.smethod_2(this.string_15 + text, 0);
		return text;
	}

	// Token: 0x0600019E RID: 414 RVA: 0x00050508 File Offset: 0x0004E708
	private void method_46()
	{
		GClass3.smethod_2("PM started", 1);
		GClass3.int_2 = 0;
		while (!this.bool_1)
		{
			Thread.Sleep(50);
			if ((this.serialPort_0 != null && this.serialPort_0.IsOpen) || GClass3.bool_0)
			{
				if (GClass3.smethod_1() <= GClass3.int_2 + GClass3.int_4 || this.bool_2)
				{
					continue;
				}
				GClass3.int_2 = GClass3.smethod_1();
				if (!GClass3.bool_11)
				{
					Thread.Sleep(100);
					continue;
				}
				for (int i = 0; i < this.list_0.Count; i++)
				{
					GClass58 gclass = this.list_0[i];
					if (gclass.bool_0)
					{
						if (GClass3.bool_0)
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
							gclass.method_1(string.Concat(this.random_0.Next(0, 100)));
							if (gclass.byte_0[0].Length == 3)
							{
								if (gclass.byte_0[0][2] == 1)
								{
									gclass.method_1(this.vmethod_7(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 2)
								{
									gclass.method_1(this.vmethod_7(array[1], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 3)
								{
									gclass.method_1(this.vmethod_7(array[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 4)
								{
									gclass.method_1(this.vmethod_7(array[3], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 5)
								{
									gclass.method_1(this.vmethod_7(array[4], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 6)
								{
									gclass.method_1(this.vmethod_7(array[5], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else
								{
									gclass.method_1(this.vmethod_7(array[5], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
							}
							else if (gclass.string_2.StartsWith("bit"))
							{
								gclass.method_1(this.vmethod_7(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							}
							Thread.Sleep(this.int_9);
						}
						else
						{
							gclass.method_1(this.vmethod_0(gclass.byte_0[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
							if (this.bool_1)
							{
								GClass3.smethod_2("PM stopped(2)", 1);
								return;
							}
						}
					}
				}
				if (GClass3.bool_7)
				{
					List<GClass64> list = this.vmethod_3();
					string text = string.Empty;
					for (int j = 0; j < list.Count; j++)
					{
						text = text + list[j].method_0() + " ";
					}
					this.string_6 = text;
				}
				else
				{
					this.string_6 = string.Empty;
				}
				if (GClass3.bool_4 && GClass3.list_1.Count > 0)
				{
					GClass3.smethod_0().method_2(GClass3.smethod_1());
				}
				this.bool_3 = true;
				int num = GClass3.smethod_1() - GClass3.int_2;
				if (num > GClass3.int_5)
				{
					GClass3.int_5 = num;
				}
				if (!GClass3.bool_4)
				{
					if (num < GClass3.int_5)
					{
						GClass3.int_5 = num;
					}
					GClass3.int_4 = GClass3.int_5;
					continue;
				}
				continue;
			}
			else
			{
				GClass3.smethod_2("PM stopped(1)", 1);
			}
			return;
		}
		GClass3.smethod_2("PM stopped", 1);
	}

	// Token: 0x0600019F RID: 415 RVA: 0x00050A04 File Offset: 0x0004EC04
	private void method_47()
	{
		GClass3.smethod_2("KA started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(20);
			if (this.serialPort_0 == null || !this.serialPort_0.IsOpen)
			{
				GClass3.smethod_2("KA stopped(1)", 1);
				return;
			}
			if (GClass3.smethod_1() > this.int_0 + this.int_11 && !this.bool_2)
			{
				byte[] array = this.method_42(this.byte_2);
				if (array.Length < 2 || array[1] != 9)
				{
					GClass3.smethod_2("KA response error!", 1);
					if (array.Length == 0 && this.int_1 > 1)
					{
						GClass3.smethod_2("Terminate 7", 1);
						base.method_22(true);
					}
				}
			}
		}
		GClass3.smethod_2("KA stopped", 1);
	}

	// Token: 0x0400015F RID: 351
	private int int_5 = 2000;

	// Token: 0x04000160 RID: 352
	private int int_6 = 3;

	// Token: 0x04000161 RID: 353
	private int int_7 = 1000;

	// Token: 0x04000162 RID: 354
	private int int_8 = 3;

	// Token: 0x04000163 RID: 355
	private int int_9 = 40;

	// Token: 0x04000164 RID: 356
	private int int_10 = 3;

	// Token: 0x04000165 RID: 357
	private int int_11 = 200;

	// Token: 0x04000166 RID: 358
	private byte[] byte_2 = new byte[]
	{
		2,
		9
	};

	// Token: 0x04000167 RID: 359
	private byte[] byte_3 = new byte[]
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

	// Token: 0x04000168 RID: 360
	private byte[] byte_4 = new byte[]
	{
		10,
		252,
		0,
		0,
		1,
		0,
		0,
		0,
		0,
		1,
		0,
		0,
		1,
		0,
		0,
		0,
		128,
		0,
		0,
		0,
		31,
		0,
		0,
		0,
		0
	};

	// Token: 0x04000169 RID: 361
	private byte[] byte_5 = new byte[]
	{
		8,
		252,
		6,
		6,
		54,
		0,
		0,
		65,
		13,
		2,
		85,
		0,
		0,
		64,
		18,
		108,
		183,
		1,
		64,
		64
	};

	// Token: 0x0400016A RID: 362
	private byte[] byte_6 = new byte[]
	{
		19,
		175,
		0,
		1,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		1,
		0,
		0,
		0,
		0,
		0,
		0
	};

	// Token: 0x0400016B RID: 363
	private byte[] byte_7 = new byte[]
	{
		2,
		7
	};

	// Token: 0x0400016C RID: 364
	private byte[] byte_8 = new byte[]
	{
		2,
		5
	};

	// Token: 0x0400016D RID: 365
	private string[] string_7 = new string[]
	{
		GClass62.smethod_1("3080"),
		GClass62.smethod_1("3081"),
		GClass62.smethod_1("3082"),
		GClass62.smethod_1("3083"),
		GClass62.smethod_1("3084"),
		GClass62.smethod_1("3085"),
		GClass62.smethod_1("3086"),
		GClass62.smethod_1("3087"),
		GClass62.smethod_1("3088"),
		GClass62.smethod_1("3089"),
		GClass62.smethod_1("3090"),
		GClass62.smethod_1("3091"),
		GClass62.smethod_1("3092"),
		GClass62.smethod_1("3093"),
		GClass62.smethod_1("3094"),
		GClass62.smethod_1("3095"),
		GClass62.smethod_1("3096"),
		GClass62.smethod_1("3097"),
		GClass62.smethod_1("3098"),
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty
	};

	// Token: 0x0400016E RID: 366
	private byte[] byte_9 = new byte[]
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

	// Token: 0x0400016F RID: 367
	private string string_8 = " ";

	// Token: 0x04000170 RID: 368
	private string string_9 = string.Empty;

	// Token: 0x04000171 RID: 369
	private string string_10 = "Send: ";

	// Token: 0x04000172 RID: 370
	private string string_11 = "OK";

	// Token: 0x04000173 RID: 371
	private string string_12 = "[";

	// Token: 0x04000174 RID: 372
	private string string_13 = "] failed!";

	// Token: 0x04000175 RID: 373
	private string string_14 = ">";

	// Token: 0x04000176 RID: 374
	private string string_15 = "Response: ";
}
