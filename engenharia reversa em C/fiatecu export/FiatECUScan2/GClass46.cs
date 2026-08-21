using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x02000056 RID: 86
public abstract class GClass46 : GClass19
{
	// Token: 0x06000246 RID: 582 RVA: 0x0005EE10 File Offset: 0x0005D010
	protected void method_33()
	{
		if (GClass3.bool_0)
		{
			byte[][] array = new byte[][]
			{
				new byte[]
				{
					1,
					2,
					151,
					50,
					48,
					9,
					37,
					0,
					96,
					101,
					103,
					103
				},
				new byte[]
				{
					11,
					244,
					170,
					80
				},
				new byte[]
				{
					11,
					244,
					byte.MaxValue,
					0
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
			this.string_3 = "A7 86 02 97 9B";
			for (int i = 0; i < this.list_1.Count; i++)
			{
				GClass58 gclass = this.list_1[i];
				if (gclass.byte_0[0][0] == 0)
				{
					gclass.method_1(this.string_3);
				}
				else
				{
					gclass.method_1(this.vmethod_7(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
			}
			this.bool_1 = false;
			this.bool_0 = true;
			new Thread(new ThreadStart(this.method_41))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_28();
			throw new Exception("1");
		}
	}

	// Token: 0x06000247 RID: 583
	protected abstract void vmethod_8(GEnum0 genum0_0);

	// Token: 0x06000248 RID: 584 RVA: 0x0005EF68 File Offset: 0x0005D168
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
			if (genum0_0 == (GEnum0)0)
			{
				Thread thread = new Thread(new ThreadStart(this.method_42));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_41))
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

	// Token: 0x06000249 RID: 585 RVA: 0x0005F12C File Offset: 0x0005D32C
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
							this.method_39("ATZ");
						}
						else
						{
							this.method_39("ATPC");
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

	// Token: 0x0600024A RID: 586 RVA: 0x0005F254 File Offset: 0x0005D454
	public List<GClass64> method_34()
	{
		List<GClass64> list = new List<GClass64>();
		List<byte> list2 = new List<byte>();
		for (int i = 0; i < this.string_9.Length; i++)
		{
			byte[] array;
			if (GClass3.bool_0)
			{
				array = GClass16.smethod_2(this.string_7[i]);
			}
			else
			{
				array = this.method_37(GClass16.smethod_2(this.string_9[i]));
			}
			if (array.Length == 4)
			{
				for (int j = 0; j < 8; j++)
				{
					if ((array[2] & this.byte_5[j]) != 0)
					{
						byte b = this.byte_3[i];
						b += (byte)(j + 1);
						list2.Add(b);
					}
				}
			}
			else
			{
				GClass3.smethod_2("ERROR: Error reading stored DTC codes", 1);
			}
		}
		for (int k = 0; k < list2.Count; k++)
		{
			try
			{
				if (list2[k] > 0)
				{
					GClass64 gclass = new GClass64();
					byte b = list2[k];
					b &= 127;
					bool flag = b != list2[k];
					gclass.string_0 = GClass16.smethod_1(new byte[]
					{
						b
					}).Replace(" ", string.Empty);
					gclass.byte_0 = (flag ? 1 : 0);
					gclass.byte_1 = 0;
					gclass.string_4 = string.Empty;
					gclass.string_5 = string.Empty;
					gclass.string_6 = string.Empty;
					gclass.string_1 = GClass16.smethod_1(new byte[]
					{
						b
					}).Replace(" ", string.Empty);
					gclass.string_4 = (flag ? GClass62.smethod_1("3062") : GClass62.smethod_1("3061"));
					list.Add(gclass);
				}
			}
			catch (Exception)
			{
				GClass3.smethod_2("ERROR: Exception while reading error codes.", 0);
			}
		}
		return list;
	}

	// Token: 0x0600024B RID: 587 RVA: 0x0005F44C File Offset: 0x0005D64C
	public override List<GClass64> vmethod_3()
	{
		List<GClass64> result;
		if (this.string_0 == "ABG22")
		{
			result = this.method_34();
		}
		else
		{
			List<GClass64> list = new List<GClass64>();
			List<byte> list2 = new List<byte>();
			for (int i = 0; i < this.string_8.Length; i++)
			{
				byte[] array;
				if (GClass3.bool_0)
				{
					array = GClass16.smethod_2(this.string_7[i]);
				}
				else
				{
					array = this.method_37(GClass16.smethod_2(this.string_8[i]));
				}
				if (array.Length == 4)
				{
					for (int j = 0; j < 8; j++)
					{
						if ((array[2] & this.byte_5[j]) != 0)
						{
							byte b = this.byte_3[i];
							b += (byte)(j + 1);
							list2.Add(b);
						}
					}
				}
				else
				{
					GClass3.smethod_2("ERROR: Error reading stored DTC codes", 1);
				}
			}
			for (int k = 0; k < list2.Count; k++)
			{
				try
				{
					if (list2[k] > 0)
					{
						GClass64 gclass = new GClass64();
						byte b = list2[k];
						b &= 127;
						bool flag = b != list2[k];
						gclass.string_0 = GClass16.smethod_1(new byte[]
						{
							b
						}).Replace(" ", string.Empty);
						gclass.byte_0 = (flag ? 1 : 0);
						gclass.byte_1 = 0;
						gclass.string_4 = string.Empty;
						gclass.string_5 = string.Empty;
						gclass.string_6 = string.Empty;
						gclass.string_1 = GClass16.smethod_1(new byte[]
						{
							b
						}).Replace(" ", string.Empty);
						gclass.string_4 = (flag ? GClass62.smethod_1("3062") : GClass62.smethod_1("3061"));
						list.Add(gclass);
					}
				}
				catch (Exception)
				{
					GClass3.smethod_2("ERROR: Exception while reading error codes.", 0);
				}
			}
			result = list;
		}
		return result;
	}

	// Token: 0x0600024C RID: 588 RVA: 0x0005F668 File Offset: 0x0005D868
	public override void vmethod_5()
	{
		if (GClass3.bool_0)
		{
			this.string_7 = new string[]
			{
				"00 00 00 FF",
				"00 00 00 FF",
				"00 00 00 FF",
				"00 00 00 FF",
				"00 00 00 FF",
				"00 00 00 FF",
				"00 00 00 FF",
				"00 00 00 FF",
				"00 00 00 FF",
				"00 00 82 FF",
				"00 00 00 FF",
				"00 00 00 FF"
			};
		}
		else
		{
			byte[] array = this.method_37(this.byte_4);
			if (array.Length < 4 || array[3] != 170)
			{
				GClass3.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
	}

	// Token: 0x0600024D RID: 589 RVA: 0x0005F720 File Offset: 0x0005D920
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
			this.method_35(gclass58_1);
		}
	}

	// Token: 0x0600024E RID: 590 RVA: 0x0005F79C File Offset: 0x0005D99C
	private void method_35(GClass58 gclass58_1)
	{
		this.method_37(gclass58_1.byte_0[0]);
		for (int i = 0; i < 100; i++)
		{
			if (!GClass3.bool_14)
			{
				Thread.Sleep(100);
			}
		}
		base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
	}

	// Token: 0x0600024F RID: 591 RVA: 0x0005F7EC File Offset: 0x0005D9EC
	public override string vmethod_0(byte[] byte_6, string string_18, int int_12, int int_13, string[] string_19, string string_20)
	{
		byte[] array = this.method_37(byte_6);
		return this.vmethod_7(array, string_18, int_12, int_13, string_19, string_20);
	}

	// Token: 0x06000250 RID: 592 RVA: 0x0005F814 File Offset: 0x0005DA14
	private byte[] method_36(byte[] byte_6)
	{
		byte[] result;
		if (byte_6.Length < 2)
		{
			result = new byte[0];
		}
		else
		{
			byte[] array = new byte[byte_6.Length - 1];
			for (int i = 1; i < byte_6.Length; i++)
			{
				array[i - 1] = byte_6[i];
			}
			this.method_38(GClass16.smethod_1(array));
			string text = this.method_40();
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

	// Token: 0x06000251 RID: 593 RVA: 0x0005F8F0 File Offset: 0x0005DAF0
	private byte[] method_37(byte[] byte_6)
	{
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			this.int_0 = GClass3.smethod_1();
			byte[] array = this.method_36(byte_6);
			this.int_0 = GClass3.smethod_1();
			this.bool_2 = false;
			GClass3.smethod_2("DECODED RESPONSE: " + GClass16.smethod_1(array), 0);
			result = array;
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

	// Token: 0x06000252 RID: 594 RVA: 0x00035A9C File Offset: 0x00033C9C
	public override string vmethod_7(byte[] byte_6, string string_18, int int_12, int int_13, string[] string_19, string string_20)
	{
		string text = string.Empty;
		int_12++;
		string result;
		if (byte_6.Length <= int_12)
		{
			result = text;
		}
		else
		{
			int num = byte_6.Length - int_12;
			if (int_13 < num)
			{
				num = int_13;
			}
			byte[] array = new byte[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = byte_6[i + int_12];
			}
			text = base.method_32(array, string_18, string_19, string_20);
			result = text;
		}
		return result;
	}

	// Token: 0x06000253 RID: 595 RVA: 0x0005F9B0 File Offset: 0x0005DBB0
	protected void method_38(string string_18)
	{
		string text = string_18.Replace(this.string_10, this.string_11);
		GClass3.smethod_2(this.string_12 + text, 0);
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

	// Token: 0x06000254 RID: 596 RVA: 0x0005FA34 File Offset: 0x0005DC34
	protected string method_39(string string_18)
	{
		if (this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		this.method_38(string_18);
		string text = this.method_40();
		if (!text.Contains(this.string_13))
		{
			GClass3.smethod_2(this.string_14 + string_18 + this.string_15, 0);
			if (GClass61.smethod_38())
			{
				this.method_38(string_18);
				text = this.method_40();
			}
		}
		this.int_0 = GClass3.smethod_1();
		return text;
	}

	// Token: 0x06000255 RID: 597 RVA: 0x0005FABC File Offset: 0x0005DCBC
	protected string method_40()
	{
		string text = this.string_11;
		while (!text.EndsWith(this.string_16))
		{
			text += (char)this.serialPort_0.ReadByte();
		}
		GClass3.smethod_2(this.string_17 + text, 0);
		return text;
	}

	// Token: 0x06000256 RID: 598 RVA: 0x0005FB10 File Offset: 0x0005DD10
	private void method_41()
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
									69,
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
							if (gclass.string_2.StartsWith("bit"))
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

	// Token: 0x06000257 RID: 599 RVA: 0x0005FE30 File Offset: 0x0005E030
	private void method_42()
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
				byte[] array = this.method_37(this.byte_2);
				if (array.Length < 4 || array[0] != 0)
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

	// Token: 0x04000398 RID: 920
	private int int_5 = 2000;

	// Token: 0x04000399 RID: 921
	private int int_6 = 3;

	// Token: 0x0400039A RID: 922
	private int int_7 = 1000;

	// Token: 0x0400039B RID: 923
	private int int_8 = 3;

	// Token: 0x0400039C RID: 924
	private int int_9 = 40;

	// Token: 0x0400039D RID: 925
	private int int_10 = 3;

	// Token: 0x0400039E RID: 926
	private int int_11 = 200;

	// Token: 0x0400039F RID: 927
	private byte[] byte_2 = new byte[]
	{
		4,
		3,
		252,
		0,
		byte.MaxValue
	};

	// Token: 0x040003A0 RID: 928
	private string[] string_7 = new string[]
	{
		"00 00 00 FF",
		"00 00 00 FF",
		"00 00 02 FF",
		"00 00 10 FF",
		"00 00 00 FF",
		"00 00 00 FF",
		"00 00 00 FF",
		"00 00 00 FF",
		"00 00 00 FF",
		"00 00 82 FF",
		"00 00 00 FF",
		"00 00 80 FF"
	};

	// Token: 0x040003A1 RID: 929
	private string[] string_8 = new string[]
	{
		"04 03 FC 00 FF",
		"04 03 FC 01 FE",
		"04 03 FC 02 FD",
		"04 03 FC 04 FB",
		"04 03 FC 05 FA",
		"04 03 FC 06 F9",
		"04 03 FC 0D F2",
		"04 03 FC 0E F1",
		"04 03 FC 1D F2",
		"04 03 FC 1E F1",
		"04 03 FC 1F F2",
		"04 03 FC 20 F1"
	};

	// Token: 0x040003A2 RID: 930
	private string[] string_9 = new string[]
	{
		"04 03 FC 00 FF",
		"04 03 FC 01 FE",
		"04 03 FC 02 FD",
		"04 03 FC 04 FB",
		"04 03 FC 05 FA",
		"04 03 FC 06 F9"
	};

	// Token: 0x040003A3 RID: 931
	private byte[] byte_3 = new byte[]
	{
		128,
		136,
		144,
		0,
		8,
		16,
		152,
		160,
		152,
		160,
		24,
		32
	};

	// Token: 0x040003A4 RID: 932
	private byte[] byte_4 = new byte[]
	{
		4,
		4,
		251,
		4,
		251
	};

	// Token: 0x040003A5 RID: 933
	private byte[] byte_5 = new byte[]
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

	// Token: 0x040003A6 RID: 934
	private string string_10 = " ";

	// Token: 0x040003A7 RID: 935
	private string string_11 = string.Empty;

	// Token: 0x040003A8 RID: 936
	private string string_12 = "Send: ";

	// Token: 0x040003A9 RID: 937
	private string string_13 = "OK";

	// Token: 0x040003AA RID: 938
	private string string_14 = "[";

	// Token: 0x040003AB RID: 939
	private string string_15 = "] failed!";

	// Token: 0x040003AC RID: 940
	private string string_16 = ">";

	// Token: 0x040003AD RID: 941
	private string string_17 = "Response: ";
}
