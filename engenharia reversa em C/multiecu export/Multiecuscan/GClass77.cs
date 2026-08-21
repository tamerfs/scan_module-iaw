using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x0200001F RID: 31
public abstract class GClass77 : GClass11
{
	// Token: 0x060001E8 RID: 488 RVA: 0x00033044 File Offset: 0x00031244
	protected void method_45()
	{
		if (GClass126.bool_0)
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
				if (GClass126.bool_25)
				{
					throw new Exception("ESC");
				}
				Thread.Sleep(100);
			}
			GClass126.smethod_2("Testing mode!", 1);
			this.string_7 = "A7 86 02 97 9B";
			for (int j = 0; j < this.list_1.Count; j++)
			{
				GClass104 gclass = this.list_1[j];
				if (gclass.byte_0[0][0] == 0)
				{
					gclass.method_1(this.string_7);
				}
				else
				{
					gclass.method_1(this.r4(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
			}
			this.bool_1 = false;
			this.bool_0 = true;
			new Thread(new ThreadStart(this.method_53))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_36();
			throw new Exception("1");
		}
	}

	// Token: 0x060001E9 RID: 489
	protected abstract void r6();

	// Token: 0x060001EA RID: 490 RVA: 0x00033184 File Offset: 0x00031384
	public override void vmethod_1()
	{
		try
		{
			GClass126.smethod_2("-----------------------", 0);
			GClass126.smethod_2("Control module (01): " + GClass127.smethod_23(this.byte_0), 0);
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
			if (this.string_0 == "ABG23")
			{
				this.int_11 = 26;
				this.int_9 = 0;
			}
			if (this.genum0_0 == (GEnum0)0)
			{
				Thread thread = new Thread(new ThreadStart(this.method_54));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_53))
				{
					Priority = ThreadPriority.AboveNormal
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
				this.bool_0 = true;
				base.method_36();
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

	// Token: 0x060001EB RID: 491 RVA: 0x00002F47 File Offset: 0x00001147
	private bool method_46()
	{
		return this.method_47();
	}

	// Token: 0x060001EC RID: 492 RVA: 0x00033420 File Offset: 0x00031620
	private bool method_47()
	{
		this.int_12++;
		if (this.int_12 > 7)
		{
			return false;
		}
		for (int i = 0; i < 18; i++)
		{
			if (this.bool_1)
			{
				return false;
			}
			Thread.Sleep(100);
		}
		return this.ra("ATGR01").Contains("..OK");
	}

	// Token: 0x060001ED RID: 493 RVA: 0x00033480 File Offset: 0x00031680
	public List<GClass102> method_48()
	{
		List<GClass102> list = new List<GClass102>();
		List<byte> list2 = new List<byte>();
		for (int i = 0; i < this.string_25.Length; i++)
		{
			byte[] array;
			if (GClass126.bool_0)
			{
				array = GClass127.smethod_32(this.string_22[i]);
			}
			else
			{
				array = this.method_52(GClass127.smethod_32(this.string_25[i]));
			}
			if (array.Length == 4 && array[0] == GClass127.smethod_32(this.string_25[i])[3])
			{
				for (int j = 0; j < 8; j++)
				{
					if ((array[2] & this.byte_6[j]) != 0)
					{
						byte b = this.byte_4[i];
						b += (byte)(j + 1);
						list2.Add(b);
					}
				}
			}
			else
			{
				GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
			}
		}
		for (int k = 0; k < list2.Count; k++)
		{
			try
			{
				if (list2[k] > 0)
				{
					GClass102 gclass = new GClass102();
					byte b2 = list2[k];
					b2 &= 127;
					gclass.string_0 = GClass127.smethod_11(new byte[]
					{
						b2
					}).Replace(" ", "");
					gclass.byte_0 = 1;
					gclass.byte_1 = 0;
					gclass.string_5 = "";
					gclass.string_6 = "";
					gclass.string_7 = "";
					gclass.string_2 = GClass127.smethod_11(new byte[]
					{
						b2
					}).Replace(" ", "");
					gclass.string_5 = GClass121.smethod_6("3062");
					list.Add(gclass);
				}
			}
			catch (Exception)
			{
				GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
			}
		}
		return list;
	}

	// Token: 0x060001EE RID: 494 RVA: 0x0003363C File Offset: 0x0003183C
	public List<GClass102> method_49()
	{
		List<GClass102> list = new List<GClass102>();
		List<byte> list2 = new List<byte>();
		for (int i = 0; i < this.string_24.Length; i++)
		{
			byte[] array;
			if (GClass126.bool_0)
			{
				array = GClass127.smethod_32(this.string_22[i]);
			}
			else
			{
				array = this.method_52(GClass127.smethod_32(this.string_24[i]));
			}
			if (array.Length == 4)
			{
				for (int j = 0; j < 8; j++)
				{
					if ((array[2] & this.byte_6[j]) != 0)
					{
						byte b = this.byte_4[i];
						b += (byte)(j + 1);
						list2.Add(b);
					}
				}
			}
			else
			{
				GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
			}
		}
		for (int k = 0; k < list2.Count; k++)
		{
			try
			{
				if (list2[k] > 0)
				{
					GClass102 gclass = new GClass102();
					byte b2 = list2[k];
					b2 &= 127;
					bool flag = b2 != list2[k];
					gclass.string_0 = GClass127.smethod_11(new byte[]
					{
						b2
					}).Replace(" ", "");
					gclass.byte_0 = ((flag > false) ? 1 : 0);
					gclass.byte_1 = 0;
					gclass.string_5 = "";
					gclass.string_6 = "";
					gclass.string_7 = "";
					gclass.string_2 = GClass127.smethod_11(new byte[]
					{
						b2
					}).Replace(" ", "");
					gclass.string_5 = (flag ? GClass121.smethod_6("3062") : GClass121.smethod_6("3061"));
					list.Add(gclass);
				}
			}
			catch (Exception)
			{
				GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
			}
		}
		return list;
	}

	// Token: 0x060001EF RID: 495 RVA: 0x00033808 File Offset: 0x00031A08
	public override List<GClass102> r1()
	{
		if (this.string_0 == "ABG22")
		{
			return this.method_49();
		}
		if (this.string_0 == "ABG23")
		{
			return this.method_48();
		}
		List<GClass102> list = new List<GClass102>();
		List<byte> list2 = new List<byte>();
		for (int i = 0; i < this.string_23.Length; i++)
		{
			byte[] array;
			if (GClass126.bool_0)
			{
				array = GClass127.smethod_32(this.string_22[i]);
			}
			else
			{
				array = this.method_52(GClass127.smethod_32(this.string_23[i]));
			}
			if (array.Length == 4)
			{
				for (int j = 0; j < 8; j++)
				{
					if ((array[2] & this.byte_6[j]) != 0)
					{
						byte b = this.byte_4[i];
						b += (byte)(j + 1);
						list2.Add(b);
					}
				}
			}
			else
			{
				GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
			}
		}
		for (int k = 0; k < list2.Count; k++)
		{
			try
			{
				if (list2[k] > 0)
				{
					GClass102 gclass = new GClass102();
					byte b2 = list2[k];
					b2 &= 127;
					bool flag = b2 != list2[k];
					gclass.string_0 = GClass127.smethod_11(new byte[]
					{
						b2
					}).Replace(" ", "");
					gclass.byte_0 = ((flag > false) ? 1 : 0);
					gclass.byte_1 = 0;
					gclass.string_5 = "";
					gclass.string_6 = "";
					gclass.string_7 = "";
					gclass.string_2 = GClass127.smethod_11(new byte[]
					{
						b2
					}).Replace(" ", "");
					gclass.string_5 = (flag ? GClass121.smethod_6("3062") : GClass121.smethod_6("3061"));
					list.Add(gclass);
				}
			}
			catch (Exception)
			{
				GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
			}
		}
		return list;
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x00033A08 File Offset: 0x00031C08
	public override void r2()
	{
		if (GClass126.bool_0)
		{
			this.string_22 = new string[]
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
			return;
		}
		if (this.string_0 == "ABG23")
		{
			this.method_52(GClass127.smethod_32("07 00 FF 02 FD"));
			this.method_52(GClass127.smethod_32("01 01 03"));
			this.bool_2 = true;
			if (!this.method_46())
			{
				this.bool_2 = false;
				GClass126.smethod_2("Terminate 5a", 1);
				base.method_30(true);
			}
			this.bool_2 = false;
			this.method_52(GClass127.smethod_32("04 02 FD 02 FD 00 FF"));
			this.method_52(GClass127.smethod_32("04 02 FD 09 F6 00 FF"));
			this.method_52(GClass127.smethod_32("04 02 FD 19 E6 00 FF"));
			this.method_52(GClass127.smethod_32("04 02 FD 0B F4 00 FF"));
			this.method_52(GClass127.smethod_32("04 02 FD 1F E0 AA 55"));
			Thread.Sleep(1000);
			return;
		}
		byte[] array = this.method_52(this.byte_5);
		if (array.Length < 4 || array[3] != 170)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x00033B7C File Offset: 0x00031D7C
	protected override void r3(GClass104 gclass104_1)
	{
		if (!GClass126.bool_0)
		{
			this.method_50(gclass104_1);
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

	// Token: 0x060001F2 RID: 498 RVA: 0x00033C04 File Offset: 0x00031E04
	private void method_50(GClass104 gclass104_1)
	{
		this.method_52(gclass104_1.byte_0[0]);
		for (int i = 0; i < 100; i++)
		{
			if (!GClass126.bool_25)
			{
				Thread.Sleep(100);
			}
		}
		base.method_28(false, GClass121.smethod_6("6051"), "");
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x00033C54 File Offset: 0x00031E54
	public override string vmethod_0(byte[] byte_7, string string_26, int int_13, int int_14, string[] string_27, string string_28)
	{
		byte[] byte_8 = this.method_52(byte_7);
		if (string_26 == "raw")
		{
			return GClass127.smethod_11(byte_8);
		}
		return this.r4(byte_8, string_26, int_13, int_14, string_27, string_28);
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x00033C8C File Offset: 0x00031E8C
	private byte[] method_51(byte[] byte_7)
	{
		if (byte_7.Length < 2)
		{
			return new byte[0];
		}
		byte[] array = new byte[byte_7.Length - 1];
		for (int i = 1; i < byte_7.Length; i++)
		{
			array[i - 1] = byte_7[i];
		}
		while (GClass126.smethod_1() < this.int_0 + this.int_9)
		{
			Thread.Sleep(1);
		}
		if (GClass125.smethod_49() && byte_7.Length == 5 && byte_7[1] == 255 && byte_7[2] == 255 && byte_7[3] == 255)
		{
			this.r9("ATGR" + GClass127.smethod_23(byte_7[4]));
		}
		else if (GClass125.smethod_49() && byte_7.Length == 5 && byte_7[1] == 3 && byte_7[2] == 252 && byte_7[3] == 0 && byte_7[4] == 255)
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
			string string_ = text.Substring(0, num);
			this.int_0 = GClass126.smethod_1();
			return GClass127.smethod_32(string_);
		}
		throw new Exception("Received ERROR or NO DATA!");
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x00033E08 File Offset: 0x00032008
	private byte[] method_52(byte[] byte_7)
	{
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			byte[] array = this.method_51(byte_7);
			this.bool_2 = false;
			GClass126.smethod_2("DECODED RESPONSE: " + GClass127.smethod_11(array), 0);
			result = array;
		}
		catch (Exception ex)
		{
			if (!this.bool_1)
			{
				GClass126.smethod_2(ex.Message + "(3)", 1);
				if (!this.method_46())
				{
					this.bool_2 = false;
					GClass126.smethod_2("Terminate 5", 1);
					base.method_30(true);
				}
			}
			this.bool_2 = false;
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x000325E4 File Offset: 0x000307E4
	public override string r4(byte[] byte_7, string string_26, int int_13, int int_14, string[] string_27, string string_28)
	{
		string result = "";
		int_13++;
		if (byte_7.Length <= int_13)
		{
			return result;
		}
		int num = byte_7.Length - int_13;
		if (int_14 < num)
		{
			num = int_14;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_7[i + int_13];
		}
		return base.method_33(array, string_26, string_27, string_28);
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x00033EB8 File Offset: 0x000320B8
	private void method_53()
	{
		GClass126.smethod_2("PM started", 1);
		GClass126.int_3 = 0;
		int num = 0;
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
								goto IL_74;
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
			IL_74:
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
								gclass.method_1(this.random_0.Next(0, 100).ToString() ?? "");
								if (gclass.string_2.StartsWith("bit"))
								{
									gclass.method_1(this.r4(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								Thread.Sleep(this.int_9);
							}
							else
							{
								gclass.method_1(this.vmethod_0(gclass.byte_0[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
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
				}
			}
		}
		GClass126.smethod_2("PM stopped", 1);
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x0003421C File Offset: 0x0003241C
	private void method_54()
	{
		GClass126.smethod_2("KA started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(10);
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
							goto IL_65;
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
			IL_65:
			if (GClass126.smethod_1() > this.int_0 + this.int_11 && !this.bool_2)
			{
				byte[] array = this.method_52(this.byte_3);
				if (array.Length < 4 || array[0] != 0)
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
	}

	// Token: 0x04000162 RID: 354
	private int int_5 = 2000;

	// Token: 0x04000163 RID: 355
	private int int_6 = 3;

	// Token: 0x04000164 RID: 356
	private int int_7 = 1000;

	// Token: 0x04000165 RID: 357
	private int int_8 = 5;

	// Token: 0x04000166 RID: 358
	private int int_9 = 40;

	// Token: 0x04000167 RID: 359
	private int int_10 = 5;

	// Token: 0x04000168 RID: 360
	private int int_11 = 200;

	// Token: 0x04000169 RID: 361
	private byte[] byte_3 = new byte[]
	{
		4,
		3,
		252,
		0,
		byte.MaxValue
	};

	// Token: 0x0400016A RID: 362
	private string[] string_22 = new string[]
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

	// Token: 0x0400016B RID: 363
	private string[] string_23 = new string[]
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

	// Token: 0x0400016C RID: 364
	private string[] string_24 = new string[]
	{
		"04 03 FC 00 FF",
		"04 03 FC 01 FE",
		"04 03 FC 02 FD",
		"04 03 FC 04 FB",
		"04 03 FC 05 FA",
		"04 03 FC 06 F9"
	};

	// Token: 0x0400016D RID: 365
	private string[] string_25 = new string[]
	{
		"04 03 FC 02 FD",
		"04 03 FC 0B F4"
	};

	// Token: 0x0400016E RID: 366
	private byte[] byte_4 = new byte[]
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

	// Token: 0x0400016F RID: 367
	private byte[] byte_5 = new byte[]
	{
		4,
		4,
		251,
		4,
		251
	};

	// Token: 0x04000170 RID: 368
	private int int_12;

	// Token: 0x04000171 RID: 369
	private byte[] byte_6 = new byte[]
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
}
