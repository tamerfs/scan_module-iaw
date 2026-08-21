using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x02000020 RID: 32
public abstract class GClass25 : GClass19
{
	// Token: 0x06000143 RID: 323 RVA: 0x00036EF8 File Offset: 0x000350F8
	protected void method_33()
	{
		if (GClass3.bool_0)
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
				else
				{
					gclass.method_1(this.vmethod_7(array[3], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
			}
			this.bool_1 = false;
			this.bool_0 = true;
			new Thread(new ThreadStart(this.method_42))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_28();
			throw new Exception("1");
		}
	}

	// Token: 0x06000144 RID: 324
	protected abstract void vmethod_8(GEnum0 genum0_0);

	// Token: 0x06000145 RID: 325 RVA: 0x00037068 File Offset: 0x00035268
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
				if (GClass3.bool_14)
				{
					throw new Exception("ESC");
				}
				if (genum0_0 == (GEnum0)0)
				{
					Thread thread = new Thread(new ThreadStart(this.method_43));
					thread.Priority = ThreadPriority.Highest;
					this.bool_1 = false;
					thread.Start();
					new Thread(new ThreadStart(this.method_42))
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
		}
		catch (Exception ex)
		{
			GClass3.smethod_2(ex.Message, 2);
			GClass3.smethod_2("Terminate 4", 1);
			base.method_22(ex.Message != "0");
		}
	}

	// Token: 0x06000146 RID: 326 RVA: 0x00037254 File Offset: 0x00035454
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
							this.method_40("ATZ");
						}
						else
						{
							this.method_40("ATPC");
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

	// Token: 0x06000147 RID: 327 RVA: 0x0003737C File Offset: 0x0003557C
	public List<GClass64> method_34()
	{
		List<GClass64> list = new List<GClass64>();
		byte[] array;
		if (GClass3.bool_0)
		{
			array = this.byte_5;
		}
		else
		{
			array = this.method_38(this.byte_6);
		}
		List<GClass64> result;
		if (array.Length < 2 || (array[1] != 252 && array[1] != 9))
		{
			GClass3.smethod_2("ERROR: Error reading stored DTC codes", 1);
			result = null;
		}
		else
		{
			try
			{
				for (int i = 2; i < array.Length - 2; i += 3)
				{
					GClass64 gclass = new GClass64();
					gclass.string_0 = GClass16.smethod_1(new byte[]
					{
						array[i + 1]
					}).Replace(" ", string.Empty);
					gclass.byte_0 = array[i];
					gclass.byte_1 = array[i + 2];
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
				}
			}
			catch (Exception ex)
			{
				GClass3.smethod_2("ERROR READING DTC: " + ex.Message, 0);
			}
			result = list;
		}
		return result;
	}

	// Token: 0x06000148 RID: 328 RVA: 0x000376C0 File Offset: 0x000358C0
	public override List<GClass64> vmethod_3()
	{
		List<GClass64> result;
		if (this.string_0 == "MA1.7.3")
		{
			result = this.method_34();
		}
		else
		{
			List<GClass64> list = new List<GClass64>();
			byte[] array;
			if (GClass3.bool_0)
			{
				array = this.byte_4;
			}
			else
			{
				array = this.method_38(this.byte_6);
			}
			if (array.Length < 2 || (array[1] != 252 && array[1] != 9))
			{
				GClass3.smethod_2("ERROR: Error reading stored DTC codes", 1);
				result = null;
			}
			else
			{
				try
				{
					for (int i = 2; i < array.Length - 3; i += 5)
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
						if ((int)(gclass.byte_0 & 31) <= this.string_7.Length)
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
					}
				}
				catch (Exception ex)
				{
					GClass3.smethod_2("ERROR READING DTC: " + ex.Message, 0);
				}
				result = list;
			}
		}
		return result;
	}

	// Token: 0x06000149 RID: 329 RVA: 0x00018938 File Offset: 0x00016B38
	private string method_35(byte byte_9)
	{
		string result = string.Empty;
		if ((byte_9 & 8) != 0)
		{
			result = GClass62.smethod_1("3056");
		}
		else if ((byte_9 & 4) != 0)
		{
			result = GClass62.smethod_1("3057");
		}
		else if ((byte_9 & 2) != 0)
		{
			result = GClass62.smethod_1("3058");
		}
		else if ((byte_9 & 1) != 0)
		{
			result = GClass62.smethod_1("3059");
		}
		return result;
	}

	// Token: 0x0600014A RID: 330 RVA: 0x00037A20 File Offset: 0x00035C20
	public override void vmethod_5()
	{
		if (GClass3.bool_0)
		{
			this.byte_4 = new byte[]
			{
				2,
				252
			};
		}
		else
		{
			byte[] array = this.method_38(this.byte_7);
			if (array.Length < 2 || array[1] != 9)
			{
				GClass3.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
	}

	// Token: 0x0600014B RID: 331 RVA: 0x00037A80 File Offset: 0x00035C80
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
			this.method_36(gclass58_1);
		}
	}

	// Token: 0x0600014C RID: 332 RVA: 0x00037AFC File Offset: 0x00035CFC
	private void method_36(GClass58 gclass58_1)
	{
		byte[] array = this.method_38(gclass58_1.byte_0[0]);
		if (array.Length == 0 || (array.Length > 1 && array[1] != 9))
		{
			string empty = string.Empty;
			base.method_31(false, GClass62.smethod_1("6052"), empty);
			Thread.Sleep(1800);
		}
		else
		{
			if (gclass58_1.byte_0.Length > 2)
			{
				for (int i = 1; i < gclass58_1.byte_0.Length; i++)
				{
					Thread.Sleep(2000);
					this.method_38(gclass58_1.byte_0[i]);
				}
			}
			else if (gclass58_1.byte_0.Length == 2)
			{
				for (int i = 1; i < gclass58_1.byte_0.Length; i++)
				{
					Thread.Sleep(6000);
					Thread.Sleep(2000);
					this.method_38(gclass58_1.byte_0[i]);
				}
			}
			else
			{
				Thread.Sleep(9000);
			}
			base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
		}
	}

	// Token: 0x0600014D RID: 333 RVA: 0x00037C04 File Offset: 0x00035E04
	public override string vmethod_0(byte[] byte_9, string string_16, int int_13, int int_14, string[] string_17, string string_18)
	{
		byte[] array = this.method_38(byte_9);
		if (array.Length == 0)
		{
			array = this.method_38(byte_9);
		}
		if (array.Length == 0)
		{
			array = this.method_38(byte_9);
		}
		return this.vmethod_7(array, string_16, int_13, int_14, string_17, string_18);
	}

	// Token: 0x0600014E RID: 334 RVA: 0x00037C50 File Offset: 0x00035E50
	private byte[] method_37(byte[] byte_9)
	{
		List<byte> list = new List<byte>();
		byte[] result;
		if (byte_9.Length < 4)
		{
			result = new byte[0];
		}
		else
		{
			byte[] array = new byte[byte_9.Length - 3];
			for (int i = 2; i < byte_9.Length - 1; i++)
			{
				array[i - 2] = byte_9[i];
			}
			this.method_39(GClass16.smethod_1(array));
			string text = this.method_41();
			if (text.Contains("NO DATA") || text.Contains("ERROR"))
			{
				throw new Exception("DISCONNECTED");
			}
			int num = 0;
			while (num < text.Length && text[num] != '\r' && text[num] != '\n' && text[num] != '>')
			{
				num++;
			}
			string str = text.Substring(0, num);
			if (GClass61.smethod_36() == 6)
			{
				str += "03";
			}
			byte[] array2 = GClass16.smethod_2(str);
			if (array2.Length > 0)
			{
				list.Add((byte)(array2.Length + 2));
			}
			for (int i = 0; i < array2.Length - 1; i++)
			{
				list.Add(array2[i]);
			}
			text = text.Substring(num + 1);
			while (text.Length > 2)
			{
				num = 0;
				while (num < text.Length && text[num] != '\r' && text[num] != '\n' && text[num] != '>')
				{
					num++;
				}
				if (num <= 1)
				{
					break;
				}
				str = text.Substring(0, num);
				if (GClass61.smethod_36() == 6)
				{
					str += "03";
				}
				array2 = GClass16.smethod_2(str);
				if (array2.Length > 2)
				{
					for (int i = 1; i < array2.Length - 1; i++)
					{
						list.Add(array2[i]);
					}
				}
				text = text.Substring(num + 1);
			}
			if (list.Count > 0)
			{
				list.Add(3);
			}
			result = list.ToArray();
		}
		return result;
	}

	// Token: 0x0600014F RID: 335 RVA: 0x00037E88 File Offset: 0x00036088
	protected byte[] method_38(byte[] byte_9)
	{
		byte[] array = new byte[0];
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			if (GClass61.smethod_36() == 4 || GClass61.smethod_36() == 5)
			{
				while (this.int_0 + this.int_12 > GClass3.smethod_1())
				{
				}
			}
			this.int_0 = GClass3.smethod_1();
			array = this.method_37(byte_9);
			GClass3.smethod_2("DECODED RESPONSE: " + GClass16.smethod_1(array), 0);
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
			array = new byte[0];
		}
		finally
		{
			this.bool_2 = false;
		}
		return array;
	}

	// Token: 0x06000150 RID: 336 RVA: 0x00035A9C File Offset: 0x00033C9C
	public override string vmethod_7(byte[] byte_9, string string_16, int int_13, int int_14, string[] string_17, string string_18)
	{
		string text = string.Empty;
		int_13++;
		string result;
		if (byte_9.Length <= int_13)
		{
			result = text;
		}
		else
		{
			int num = byte_9.Length - int_13;
			if (int_14 < num)
			{
				num = int_14;
			}
			byte[] array = new byte[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = byte_9[i + int_13];
			}
			text = base.method_32(array, string_16, string_17, string_18);
			result = text;
		}
		return result;
	}

	// Token: 0x06000151 RID: 337 RVA: 0x00037F7C File Offset: 0x0003617C
	protected void method_39(string string_16)
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

	// Token: 0x06000152 RID: 338 RVA: 0x00038000 File Offset: 0x00036200
	protected string method_40(string string_16)
	{
		if (this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		this.method_39(string_16);
		string text = this.method_41();
		if (!text.Contains(this.string_11))
		{
			GClass3.smethod_2(this.string_12 + string_16 + this.string_13, 0);
			if (GClass61.smethod_38())
			{
				this.method_39(string_16);
				text = this.method_41();
			}
		}
		this.int_0 = GClass3.smethod_1();
		return text;
	}

	// Token: 0x06000153 RID: 339 RVA: 0x00038088 File Offset: 0x00036288
	protected string method_41()
	{
		string text = this.string_9;
		while (!text.EndsWith(this.string_14))
		{
			text += (char)this.serialPort_0.ReadByte();
		}
		GClass3.smethod_2(this.string_15 + text, 0);
		return text;
	}

	// Token: 0x06000154 RID: 340 RVA: 0x000380DC File Offset: 0x000362DC
	private void method_42()
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

	// Token: 0x06000155 RID: 341 RVA: 0x000385D8 File Offset: 0x000367D8
	private void method_43()
	{
		if (GClass61.smethod_36() != 4 && GClass61.smethod_36() != 5)
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
					byte[] array = this.method_38(this.byte_2);
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
	}

	// Token: 0x04000125 RID: 293
	private int int_5 = 2000;

	// Token: 0x04000126 RID: 294
	private int int_6 = 3;

	// Token: 0x04000127 RID: 295
	private int int_7 = 1000;

	// Token: 0x04000128 RID: 296
	private int int_8 = 3;

	// Token: 0x04000129 RID: 297
	private int int_9 = 41;

	// Token: 0x0400012A RID: 298
	private int int_10 = 3;

	// Token: 0x0400012B RID: 299
	private int int_11 = 420;

	// Token: 0x0400012C RID: 300
	private int int_12 = 280;

	// Token: 0x0400012D RID: 301
	private byte[] byte_2 = new byte[]
	{
		3,
		0,
		9,
		3
	};

	// Token: 0x0400012E RID: 302
	protected byte[] byte_3 = new byte[]
	{
		3,
		0,
		9,
		3
	};

	// Token: 0x0400012F RID: 303
	private byte[] byte_4 = new byte[]
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

	// Token: 0x04000130 RID: 304
	private byte[] byte_5 = new byte[]
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

	// Token: 0x04000131 RID: 305
	private byte[] byte_6 = new byte[]
	{
		3,
		0,
		7,
		3
	};

	// Token: 0x04000132 RID: 306
	private byte[] byte_7 = new byte[]
	{
		3,
		0,
		5,
		3
	};

	// Token: 0x04000133 RID: 307
	private byte byte_8 = 0;

	// Token: 0x04000134 RID: 308
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
		GClass62.smethod_1("3098")
	};

	// Token: 0x04000135 RID: 309
	private string string_8 = " ";

	// Token: 0x04000136 RID: 310
	private string string_9 = string.Empty;

	// Token: 0x04000137 RID: 311
	private string string_10 = "Send: ";

	// Token: 0x04000138 RID: 312
	private string string_11 = "OK";

	// Token: 0x04000139 RID: 313
	private string string_12 = "[";

	// Token: 0x0400013A RID: 314
	private string string_13 = "] failed!";

	// Token: 0x0400013B RID: 315
	private string string_14 = ">";

	// Token: 0x0400013C RID: 316
	private string string_15 = "Response: ";
}
