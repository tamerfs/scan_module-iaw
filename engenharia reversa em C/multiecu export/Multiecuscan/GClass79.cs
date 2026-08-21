using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x02000020 RID: 32
public abstract class GClass79 : GClass11
{
	// Token: 0x060001FA RID: 506 RVA: 0x00034510 File Offset: 0x00032710
	protected void method_45()
	{
		if (GClass126.bool_0)
		{
			byte[][] array = new byte[][]
			{
				new byte[]
				{
					49,
					50,
					55,
					50,
					48,
					57,
					53,
					48,
					48,
					53,
					55,
					55
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
			this.string_7 = "31 80 0D 16 29";
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
			new Thread(new ThreadStart(this.method_50))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_36();
			throw new Exception("1");
		}
	}

	// Token: 0x060001FB RID: 507
	protected abstract void r6();

	// Token: 0x060001FC RID: 508 RVA: 0x00034650 File Offset: 0x00032850
	public override void vmethod_1()
	{
		try
		{
			GClass126.smethod_2("-----------------------", 0);
			GClass126.smethod_2("Control module (IAW): " + GClass127.smethod_23(this.byte_0), 0);
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
			if (this.genum0_0 == (GEnum0)0)
			{
				Thread thread = new Thread(new ThreadStart(this.method_51));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_50))
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

	// Token: 0x060001FD RID: 509 RVA: 0x000348CC File Offset: 0x00032ACC
	private List<GClass102> method_46()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array = GClass127.smethod_32(this.string_27);
		byte[] array2 = GClass127.smethod_32(this.string_22);
		if (GClass126.bool_0)
		{
			array2 = GClass127.smethod_32(this.string_22);
		}
		else
		{
			array2 = this.method_49(array);
		}
		if (array2.Length != array.Length && !GClass126.bool_0)
		{
			GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
			return null;
		}
		GClass126.smethod_2("Error block: " + GClass127.smethod_11(array2), 0);
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				if ((array2[i] & this.byte_5[j]) != 0)
				{
					try
					{
						GClass102 gclass = new GClass102();
						gclass.string_0 = i.ToString() + (j + 1).ToString();
						gclass.byte_0 = (((array2[i] & this.byte_5[j]) > 0) ? 1 : 0);
						gclass.byte_1 = 0;
						gclass.string_5 = "";
						gclass.string_6 = "";
						gclass.string_7 = "";
						gclass.string_2 = "";
						string string_ = "";
						if ((gclass.byte_0 & 1) == 1)
						{
							string_ = GClass121.smethod_6("3062");
						}
						string str = "";
						if ((gclass.byte_0 & 1) == 1)
						{
							str = GClass121.smethod_6("3078");
						}
						gclass.string_6 = string_;
						GClass102 gclass2 = gclass;
						gclass2.string_3 = gclass2.string_3 + str + "\r\n";
						list.Add(gclass);
						goto IL_195;
					}
					catch (Exception)
					{
						GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
						goto IL_195;
					}
					break;
				}
				IL_195:;
			}
		}
		return list;
	}

	// Token: 0x060001FE RID: 510 RVA: 0x00034A8C File Offset: 0x00032C8C
	public override List<GClass102> r1()
	{
		if (this.string_0 == "IAWG7XX")
		{
			return this.method_46();
		}
		List<GClass102> list = new List<GClass102>();
		byte[] array = GClass127.smethod_32(this.string_23);
		if (this.string_0 == "IAW16F")
		{
			array = GClass127.smethod_32(this.string_24);
		}
		if (this.string_0 == "IAW06F")
		{
			array = GClass127.smethod_32(this.string_25);
		}
		if (this.string_0 == "IAW06FE")
		{
			array = GClass127.smethod_32(this.string_25);
		}
		if (this.string_0 == "IAW08F")
		{
			array = GClass127.smethod_32(this.string_26);
		}
		byte[] array2 = GClass127.smethod_32(this.string_22);
		if (GClass126.bool_0)
		{
			array2 = GClass127.smethod_32(this.string_22);
		}
		else
		{
			array2 = this.method_49(array);
		}
		if (array2.Length != array.Length && !GClass126.bool_0)
		{
			GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
			return null;
		}
		GClass126.smethod_2("Error block: " + GClass127.smethod_11(array2), 0);
		int num = array.Length / 2;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				if ((array2[i] & this.byte_5[j]) != 0 || (array2[i + num] & this.byte_5[j]) != 0)
				{
					try
					{
						GClass102 gclass = new GClass102();
						gclass.string_0 = i.ToString() + (j + 1).ToString();
						gclass.byte_0 = (((array2[i] & this.byte_5[j]) > 0) ? 1 : 0);
						GClass102 gclass2 = gclass;
						gclass2.byte_0 += (((array2[i + num] & this.byte_5[j]) != 0) ? 2 : 0);
						gclass.byte_1 = 0;
						gclass.string_5 = "";
						gclass.string_6 = "";
						gclass.string_7 = "";
						gclass.string_2 = "";
						string string_ = "";
						if ((gclass.byte_0 & 1) == 1)
						{
							string_ = GClass121.smethod_6("3062");
						}
						else if ((gclass.byte_0 & 2) == 2)
						{
							string_ = GClass121.smethod_6("3054");
						}
						string str = "";
						if ((gclass.byte_0 & 1) == 1)
						{
							str = GClass121.smethod_6("3078");
						}
						else if ((gclass.byte_0 & 2) == 2)
						{
							str = GClass121.smethod_6("3075");
						}
						gclass.string_6 = string_;
						GClass102 gclass3 = gclass;
						gclass3.string_3 = gclass3.string_3 + str + "\r\n";
						list.Add(gclass);
						goto IL_295;
					}
					catch (Exception)
					{
						GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
						goto IL_295;
					}
					break;
				}
				IL_295:;
			}
		}
		return list;
	}

	// Token: 0x060001FF RID: 511 RVA: 0x00034D58 File Offset: 0x00032F58
	public override void r2()
	{
		if (GClass126.bool_0)
		{
			this.string_22 = "00 00 00 00 00 00 00 00 00 00";
			return;
		}
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			this.method_48(new byte[]
			{
				this.byte_4[0]
			});
			this.method_48(new byte[]
			{
				this.byte_4[1]
			});
			this.r9("ATMA");
			this.int_0 = GClass126.smethod_1();
			string text = "";
			while (!text.EndsWith("FF") && GClass126.smethod_1() < this.int_0 + 32000 && !GClass126.bool_25)
			{
				try
				{
					if (GClass125.smethod_48())
					{
						if (this.tcpClient_0.Client.Available > 0)
						{
							byte b = (byte)this.tcpClient_0.GetStream().ReadByte();
							string str = text;
							char c = (char)b;
							text = str + c.ToString();
						}
					}
					else if (GClass125.smethod_52())
					{
						if (this.stringBuilder_0.Length > 0)
						{
							text += this.stringBuilder_0[0].ToString();
							this.stringBuilder_0.Remove(0, 1);
						}
					}
					else
					{
						text += ((char)this.serialPort_0.ReadByte()).ToString();
					}
					GClass126.smethod_2("Received: " + text[text.Length - 1].ToString(), 0);
				}
				catch (Exception)
				{
				}
			}
			this.ra("");
			this.ra("ATGR01");
			this.method_48(new byte[]
			{
				this.byte_4[2]
			});
			if (!text.EndsWith("FF"))
			{
				GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2("ERROR: " + ex.Message, 0);
		}
		finally
		{
			this.bool_2 = false;
		}
	}

	// Token: 0x06000200 RID: 512 RVA: 0x00034F90 File Offset: 0x00033190
	protected override void r3(GClass104 gclass104_1)
	{
		if (!GClass126.bool_0)
		{
			this.method_47(gclass104_1);
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

	// Token: 0x06000201 RID: 513 RVA: 0x00035018 File Offset: 0x00033218
	private void method_47(GClass104 gclass104_1)
	{
		bool flag = false;
		string text = "";
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			byte[] array = this.method_48(gclass104_1.byte_0[0]);
			if (array.Length >= 1)
			{
				if (array[0] == 170)
				{
					this.method_48(gclass104_1.byte_0[1]);
					this.r9("ATMA");
					this.int_0 = GClass126.smethod_1();
					while (!text.EndsWith("FF") && !text.EndsWith("EE") && GClass126.smethod_1() < this.int_0 + 35000)
					{
						if (GClass126.bool_25)
						{
							flag = true;
							break;
						}
						try
						{
							if (GClass125.smethod_48())
							{
								if (this.tcpClient_0.Client.Available > 0)
								{
									byte b = (byte)this.tcpClient_0.GetStream().ReadByte();
									string str = text;
									char c = (char)b;
									text = str + c.ToString();
								}
							}
							else if (GClass125.smethod_52())
							{
								if (this.stringBuilder_0.Length > 0)
								{
									text += this.stringBuilder_0[0].ToString();
									this.stringBuilder_0.Remove(0, 1);
								}
							}
							else
							{
								text += ((char)this.serialPort_0.ReadByte()).ToString();
							}
							GClass126.smethod_2("Received: " + text[text.Length - 1].ToString(), 0);
						}
						catch (Exception)
						{
						}
					}
					this.ra("");
					this.ra("ATGR01");
					this.method_48(gclass104_1.byte_0[2]);
					goto IL_1D6;
				}
			}
			this.bool_2 = false;
			base.method_28(false, GClass121.smethod_6("6052"), GClass121.smethod_6("6053"));
			return;
		}
		finally
		{
			this.bool_2 = false;
		}
		IL_1D6:
		if (flag)
		{
			base.method_28(false, GClass121.smethod_6("6082"), " ");
			return;
		}
		if (text.EndsWith("FF"))
		{
			base.method_28(false, GClass121.smethod_6("6051"), "");
			return;
		}
		string text2 = "";
		base.method_28(false, GClass121.smethod_6("6052"), text2);
	}

	// Token: 0x06000202 RID: 514 RVA: 0x00035288 File Offset: 0x00033488
	public override string vmethod_0(byte[] byte_6, string string_28, int int_12, int int_13, string[] string_29, string string_30)
	{
		byte[] byte_7 = this.method_49(byte_6);
		if (string_28 == "raw")
		{
			return GClass127.smethod_11(byte_7);
		}
		return this.r4(byte_7, string_28, int_12, int_13, string_29, string_30);
	}

	// Token: 0x06000203 RID: 515 RVA: 0x000352C0 File Offset: 0x000334C0
	private byte[] method_48(byte[] byte_6)
	{
		while (GClass126.smethod_1() < this.int_0 + this.int_9)
		{
			Thread.Sleep(1);
		}
		if (GClass125.smethod_49() && byte_6.Length == 5 && byte_6[1] == 255 && byte_6[2] == 255 && byte_6[3] == 255)
		{
			this.r9("ATGR" + GClass127.smethod_23(byte_6[4]));
		}
		else if (GClass125.smethod_49() && byte_6.Length == 1 && byte_6[0] == 1)
		{
			this.r9("ATGR07");
		}
		else
		{
			if (GClass125.smethod_49())
			{
				byte[] array = new byte[byte_6.Length];
				for (int i = 0; i < byte_6.Length; i++)
				{
					this.r9(GClass127.smethod_23(byte_6[i]) + "1");
					string text = this.rb();
					if (text.Contains("NO DATA") || text.Contains("ERROR"))
					{
						return new byte[0];
					}
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
					array[i] = GClass127.smethod_32(string_)[0];
				}
				return array;
			}
			this.r9(GClass127.smethod_11(byte_6));
		}
		string text2 = this.rb();
		if (!text2.Contains("NO DATA") && !text2.Contains("ERROR"))
		{
			int num2 = 0;
			while (num2 < text2.Length && text2[num2] != '\r' && text2[num2] != '\n')
			{
				if (text2[num2] == '>')
				{
					break;
				}
				num2++;
			}
			string string_2 = text2.Substring(0, num2);
			this.int_0 = GClass126.smethod_1();
			return GClass127.smethod_32(string_2);
		}
		return new byte[0];
	}

	// Token: 0x06000204 RID: 516 RVA: 0x000354A4 File Offset: 0x000336A4
	private byte[] method_49(byte[] byte_6)
	{
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			byte[] array = this.method_48(byte_6);
			this.bool_2 = false;
			GClass126.smethod_2("DECODED RESPONSE: " + GClass127.smethod_11(array), 0);
			result = array;
		}
		catch (Exception ex)
		{
			if (!this.bool_1)
			{
				GClass126.smethod_2(ex.Message + "(3)", 1);
				this.bool_2 = false;
				GClass126.smethod_2("Terminate 5", 1);
				base.method_30(true);
			}
			this.bool_2 = false;
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x06000205 RID: 517 RVA: 0x0001D948 File Offset: 0x0001BB48
	public override string r4(byte[] byte_6, string string_28, int int_12, int int_13, string[] string_29, string string_30)
	{
		string result = "";
		int_12--;
		if (byte_6.Length <= int_12)
		{
			return result;
		}
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
		return base.method_33(array, string_28, string_29, string_30);
	}

	// Token: 0x06000206 RID: 518 RVA: 0x0003554C File Offset: 0x0003374C
	private void method_50()
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

	// Token: 0x06000207 RID: 519 RVA: 0x000358B0 File Offset: 0x00033AB0
	private void method_51()
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
				byte[] array = this.method_49(this.byte_3);
				if (array.Length < 1)
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

	// Token: 0x04000172 RID: 370
	private int int_5 = 2000;

	// Token: 0x04000173 RID: 371
	private int int_6 = 3;

	// Token: 0x04000174 RID: 372
	private int int_7 = 1000;

	// Token: 0x04000175 RID: 373
	private int int_8 = 3;

	// Token: 0x04000176 RID: 374
	private int int_9 = 6;

	// Token: 0x04000177 RID: 375
	private int int_10 = 3;

	// Token: 0x04000178 RID: 376
	private int int_11 = 1000;

	// Token: 0x04000179 RID: 377
	private byte[] byte_3 = new byte[]
	{
		1
	};

	// Token: 0x0400017A RID: 378
	private string string_22 = "00 00 00 00 00 00 00 02 00 00";

	// Token: 0x0400017B RID: 379
	private string string_23 = "71 30 31 32 33 72 39 3A 3B 3C";

	// Token: 0x0400017C RID: 380
	private string string_24 = "71 10 11 12 72 14 15 16";

	// Token: 0x0400017D RID: 381
	private string string_25 = "10 11 12 14 15 16";

	// Token: 0x0400017E RID: 382
	private string string_26 = "30 31 32 33 39 3A 3B 3C";

	// Token: 0x0400017F RID: 383
	private string string_27 = "10 11 12";

	// Token: 0x04000180 RID: 384
	private byte[] byte_4 = new byte[]
	{
		170,
		132,
		byte.MaxValue
	};

	// Token: 0x04000181 RID: 385
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
}
