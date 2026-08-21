using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

// Token: 0x02000053 RID: 83
public sealed class GClass91 : GClass11
{
	// Token: 0x06000320 RID: 800 RVA: 0x0004E500 File Offset: 0x0004C700
	public GClass91(byte byte_6, List<GClass104> list_6, List<GClass104> list_7)
	{
		this.byte_0 = byte_6;
		this.list_0 = list_7;
		this.list_1 = list_6;
	}

	// Token: 0x06000321 RID: 801 RVA: 0x0004E628 File Offset: 0x0004C828
	public override void vmethod_1()
	{
		try
		{
			this.int_1 = 0;
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
				for (int j = 0; j < 20; j++)
				{
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(100);
				}
				GClass126.smethod_2("Testing mode!", 1);
				this.string_7 = "31 80 0D 16 29";
				for (int k = 0; k < this.list_1.Count; k++)
				{
					GClass104 gclass = this.list_1[k];
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
				new Thread(new ThreadStart(this.method_52))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				base.method_36();
				throw new Exception("1");
			}
			if (GClass125.smethod_44() == 4 || GClass125.smethod_44() == 5)
			{
				if (GClass125.smethod_44() == 5)
				{
					for (int l = 0; l < 25; l++)
					{
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
				}
				GClass96.smethod_0();
				Thread.Sleep(500);
				if (GClass125.smethod_44() == 5)
				{
					for (int m = 0; m < 35; m++)
					{
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
				}
			}
			try
			{
				this.serialPort_0 = new SerialPort(GClass125.smethod_55(), 1200, Parity.None, 8, StopBits.One);
				this.serialPort_0.WriteBufferSize = 2;
				this.serialPort_0.WriteTimeout = 5000;
				this.serialPort_0.ReceivedBytesThreshold = 1000;
				this.serialPort_0.Handshake = Handshake.None;
				this.serialPort_0.Open();
				GClass126.smethod_2("Serial port opened!", 1);
			}
			catch (Exception ex)
			{
				this.string_8 = ex.Message;
				GClass126.smethod_2(ex.Message, 1);
				throw new Exception("0");
			}
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			this.int_0 = GClass126.smethod_1();
			GClass126.smethod_2("Waiting ECU response...", 1);
			this.serialPort_0.ReadTimeout = this.int_7;
			while (GClass126.smethod_1() < this.int_0 + 8000)
			{
				try
				{
					byte b = (byte)this.serialPort_0.ReadByte();
					GClass126.smethod_2("Sync: " + GClass127.smethod_23(b), 0);
					byte b2 = 0 + b;
					if (b != 85)
					{
						GClass126.smethod_2("ERROR: Invalid synchronization byte", 1);
						throw new Exception("Invalid synchronization byte");
					}
					byte b3 = (byte)this.serialPort_0.ReadByte();
					GClass126.smethod_2("K1: " + GClass127.smethod_23(b3), 0);
					b2 += b3;
					byte b4 = (byte)this.serialPort_0.ReadByte();
					GClass126.smethod_2("K2: " + GClass127.smethod_23(b4), 0);
					b2 += b4;
					byte b5 = (byte)this.serialPort_0.ReadByte();
					GClass126.smethod_2("C1: " + GClass127.smethod_23(b5), 0);
					b2 += b5;
					byte b6 = (byte)this.serialPort_0.ReadByte();
					GClass126.smethod_2("C2: " + GClass127.smethod_23(b6), 0);
					b2 += b6;
					byte b7 = (byte)this.serialPort_0.ReadByte();
					GClass126.smethod_2("CS: " + GClass127.smethod_23(b7), 0);
					this.int_0 = GClass126.smethod_1();
					byte b8 = b7;
					b7 &= 127;
					b2 &= 127;
					if (b7 != b2)
					{
						GClass126.smethod_2("ERROR: Invalid checksum", 1);
					}
					this.string_7 = GClass127.smethod_11(new byte[]
					{
						b3,
						b4,
						b5,
						b6,
						b8
					});
					GClass126.smethod_2("ECU ISO Code: " + this.string_7, 0);
					break;
				}
				catch (Exception)
				{
					Thread.Sleep(10);
				}
				if (!GClass126.bool_25)
				{
					continue;
				}
				throw new Exception("ESC");
				IL_493:
				this.int_0 += 550;
				this.method_50(15);
				this.int_0 += 110;
				this.method_50(170);
				this.int_0 += 110;
				this.method_50(204);
				this.int_0 += 115;
				GClass126.smethod_2("ECU wakeup completed", 1);
				this.serialPort_0.BaudRate = 7812;
				this.serialPort_0.ReadTimeout = this.int_11;
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
					return;
				}
				if (GClass126.bool_25)
				{
					throw new Exception("ESC");
				}
				Thread thread = new Thread(new ThreadStart(this.method_53));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_52))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				for (int n = 0; n < this.list_1.Count; n++)
				{
					GClass104 gclass2 = this.list_1[n];
					if (gclass2.byte_0[0][0] == 0)
					{
						gclass2.method_1(this.string_7);
					}
					else
					{
						gclass2.method_1(this.vmethod_0(gclass2.byte_0[0], gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
					}
				}
				this.bool_0 = true;
				base.method_36();
				return;
			}
			goto IL_493;
		}
		catch (Exception ex2)
		{
			if (ex2.Message == "ESC")
			{
				this.string_8 = GClass121.smethod_6("6060");
			}
			if (ex2.Message == "1")
			{
				this.string_8 = "No ECU response";
			}
			GClass126.smethod_2(ex2.Message, 2);
			GClass126.smethod_2("Terminate 4", 1);
			this.r0(ex2.Message != "1" && ex2.Message != "0" && ex2.Message != "ESC", ex2.Message == "ESC");
		}
	}

	// Token: 0x06000322 RID: 802 RVA: 0x0004A968 File Offset: 0x00048B68
	public override void r0(bool bool_6, bool bool_7)
	{
		if (this.bool_1)
		{
			return;
		}
		GClass126.smethod_2("Terminating " + (bool_6 ? "with reconnect" : ""), 1);
		if (GClass126.bool_0 && !bool_7)
		{
			return;
		}
		this.bool_1 = true;
		this.bool_0 = false;
		Thread.Sleep(500);
		if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
		{
			try
			{
				this.serialPort_0.Close();
				GClass126.smethod_2("Serial port closed!", 1);
			}
			catch (Exception ex)
			{
				GClass126.smethod_2("ERROR: Failed to close serial port: " + ex.Message, 1);
			}
			GClass126.smethod_2("-------------------------------------", 1);
			GClass126.smethod_2(" ", 1);
		}
		base.method_32(bool_7);
	}

	// Token: 0x06000323 RID: 803 RVA: 0x0004ED8C File Offset: 0x0004CF8C
	private List<GClass102> method_45()
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
			array2 = this.method_47(array);
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

	// Token: 0x06000324 RID: 804 RVA: 0x0004EF4C File Offset: 0x0004D14C
	public override List<GClass102> r1()
	{
		if (this.string_0 == "IAWG7XX")
		{
			return this.method_45();
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
			array2 = this.method_47(array);
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

	// Token: 0x06000325 RID: 805 RVA: 0x0004F218 File Offset: 0x0004D418
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
			byte b = 0;
			int num = 0;
			while (num < 120 && !GClass126.bool_25)
			{
				this.int_0 = GClass126.smethod_1();
				try
				{
					b = this.method_51();
					break;
				}
				catch (Exception)
				{
				}
				num++;
			}
			this.method_48(new byte[]
			{
				this.byte_4[2]
			});
			if (b != 255)
			{
				GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
		finally
		{
			this.bool_2 = false;
		}
	}

	// Token: 0x06000326 RID: 806 RVA: 0x0004F300 File Offset: 0x0004D500
	protected override void r3(GClass104 gclass104_1)
	{
		if (GClass126.bool_0)
		{
			if (!gclass104_1.string_2.Contains("NOWAIT"))
			{
				Thread.Sleep(3000);
			}
			base.method_28(false, GClass121.smethod_6("6051"), "");
			return;
		}
		this.method_46(gclass104_1);
	}

	// Token: 0x06000327 RID: 807 RVA: 0x0004F350 File Offset: 0x0004D550
	private void method_46(GClass104 gclass104_1)
	{
		byte b = 0;
		bool flag = false;
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
					int i = 0;
					while (i < 120)
					{
						if (!GClass126.bool_25)
						{
							this.int_0 = GClass126.smethod_1();
							try
							{
								b = this.method_51();
								break;
							}
							catch (Exception)
							{
							}
							i++;
							continue;
						}
						flag = true;
						IL_7B:
						this.method_48(gclass104_1.byte_0[2]);
						goto IL_B8;
					}
					goto IL_7B;
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
		IL_B8:
		if (flag)
		{
			base.method_28(false, GClass121.smethod_6("6082"), " ");
			return;
		}
		if (b == 255)
		{
			base.method_28(false, GClass121.smethod_6("6051"), "");
			return;
		}
		string text = "";
		base.method_28(false, GClass121.smethod_6("6052"), text);
	}

	// Token: 0x06000328 RID: 808 RVA: 0x0004F484 File Offset: 0x0004D684
	public override string vmethod_0(byte[] byte_6, string string_34, int int_12, int int_13, string[] string_35, string string_36)
	{
		byte[] array = this.method_47(byte_6);
		if (array.Length == 0)
		{
			array = this.method_47(byte_6);
		}
		return this.r4(array, string_34, int_12, int_13, string_35, string_36);
	}

	// Token: 0x06000329 RID: 809 RVA: 0x0004F4B4 File Offset: 0x0004D6B4
	private byte[] method_47(byte[] byte_6)
	{
		byte[] result = new byte[0];
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			result = this.method_48(byte_6);
		}
		finally
		{
			this.bool_2 = false;
		}
		return result;
	}

	// Token: 0x0600032A RID: 810 RVA: 0x0004F504 File Offset: 0x0004D704
	private byte[] method_48(byte[] byte_6)
	{
		byte[] result;
		try
		{
			byte[] array = new byte[byte_6.Length];
			while (GClass126.smethod_1() < this.int_0 + this.int_10)
			{
				Thread.Sleep(1);
			}
			this.serialPort_0.ReadExisting();
			for (int i = 0; i < byte_6.Length; i++)
			{
				this.method_50(byte_6[i]);
				array[i] = this.method_51();
			}
			this.int_1 = 0;
			result = array;
		}
		catch (Exception ex)
		{
			if (!this.bool_1)
			{
				GClass126.smethod_2(ex.Message + "(3)", 1);
				if (this.int_1 > 1)
				{
					this.bool_2 = false;
					GClass126.smethod_2("Terminate 5", 1);
					base.method_30(true);
				}
				else
				{
					this.int_1++;
					try
					{
						this.serialPort_0.ReadTimeout = 100;
						for (int j = 0; j < 10; j++)
						{
							this.serialPort_0.ReadByte();
						}
					}
					catch (Exception)
					{
					}
					try
					{
						this.serialPort_0.ReadTimeout = this.int_7;
					}
					catch (Exception)
					{
					}
				}
			}
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x0600032B RID: 811 RVA: 0x00010BD0 File Offset: 0x0000EDD0
	private byte method_49(byte[] byte_6)
	{
		byte b = 0;
		for (int i = 0; i < byte_6.Length; i++)
		{
			b += byte_6[i];
		}
		return b;
	}

	// Token: 0x0600032C RID: 812 RVA: 0x0001D948 File Offset: 0x0001BB48
	public override string r4(byte[] byte_6, string string_34, int int_12, int int_13, string[] string_35, string string_36)
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
		return base.method_33(array, string_34, string_35, string_36);
	}

	// Token: 0x0600032D RID: 813 RVA: 0x0004F640 File Offset: 0x0004D840
	private void method_50(byte byte_6)
	{
		while (GClass126.smethod_1() < this.int_0 + this.int_8)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_6
		}, 0, 1);
		this.int_0 = GClass126.smethod_1();
		GClass126.smethod_2("Sent: " + GClass127.smethod_23(byte_6), 0);
		byte b = (byte)this.serialPort_0.ReadByte();
		int num = GClass126.smethod_1() - this.int_0;
		this.int_0 += num / 3;
		if (num > 15)
		{
			this.int_3 = 25;
		}
		if (byte_6 != b)
		{
			GClass126.smethod_2("ERROR: Invalid echo: " + GClass127.smethod_23(b), 0);
			throw new Exception(this.string_32);
		}
	}

	// Token: 0x0600032E RID: 814 RVA: 0x0004F6F8 File Offset: 0x0004D8F8
	private byte method_51()
	{
		byte b = (byte)this.serialPort_0.ReadByte();
		this.int_0 = GClass126.smethod_1();
		GClass126.smethod_2(this.string_33 + GClass127.smethod_23(b), 0);
		return b;
	}

	// Token: 0x0600032F RID: 815 RVA: 0x0004F738 File Offset: 0x0004D938
	private void method_52()
	{
		GClass126.smethod_2("PM started", 1);
		GClass126.int_3 = 0;
		int num = 0;
		while (!this.bool_1)
		{
			Thread.Sleep(60);
			if ((this.serialPort_0 == null || !this.serialPort_0.IsOpen) && !GClass126.bool_0)
			{
				GClass126.smethod_2("PM stopped(1)", 1);
				return;
			}
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

	// Token: 0x06000330 RID: 816 RVA: 0x0004FA50 File Offset: 0x0004DC50
	private void method_53()
	{
		GClass126.smethod_2("KA started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(20);
			if (this.serialPort_0 == null || !this.serialPort_0.IsOpen)
			{
				GClass126.smethod_2("KA stopped(1)", 1);
				return;
			}
			if (GClass126.smethod_1() > this.int_0 + this.int_7 && !this.bool_2)
			{
				byte[] array = this.method_47(this.byte_3);
				if (array.Length < 1)
				{
					array = this.method_47(this.byte_3);
					if (array.Length < 1)
					{
						GClass126.smethod_2("KA response error!", 1);
						if (array.Length == 0 && this.int_1 > 2)
						{
							GClass126.smethod_2("Terminate 7", 1);
							base.method_30(true);
						}
					}
				}
			}
		}
		GClass126.smethod_2("KA stopped", 1);
	}

	// Token: 0x0400021D RID: 541
	private int int_5 = 2000;

	// Token: 0x0400021E RID: 542
	private int int_6 = 3;

	// Token: 0x0400021F RID: 543
	private int int_7 = 1000;

	// Token: 0x04000220 RID: 544
	private int int_8 = 3;

	// Token: 0x04000221 RID: 545
	private int int_9 = 41;

	// Token: 0x04000222 RID: 546
	private int int_10 = 5;

	// Token: 0x04000223 RID: 547
	private int int_11 = 400;

	// Token: 0x04000224 RID: 548
	private byte[] byte_3 = new byte[]
	{
		1
	};

	// Token: 0x04000225 RID: 549
	private string string_22 = "00 00 00 00 00 00 00 02 00 00";

	// Token: 0x04000226 RID: 550
	private string string_23 = "71 30 31 32 33 72 39 3A 3B 3C";

	// Token: 0x04000227 RID: 551
	private string string_24 = "71 10 11 12 72 14 15 16";

	// Token: 0x04000228 RID: 552
	private string string_25 = "10 11 12 14 15 16";

	// Token: 0x04000229 RID: 553
	private string string_26 = "30 31 32 33 39 3A 3B 3C";

	// Token: 0x0400022A RID: 554
	private string string_27 = "10 11 12";

	// Token: 0x0400022B RID: 555
	private byte[] byte_4 = new byte[]
	{
		170,
		132,
		byte.MaxValue
	};

	// Token: 0x0400022C RID: 556
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

	// Token: 0x0400022D RID: 557
	private string string_28 = " <";

	// Token: 0x0400022E RID: 558
	private string string_29 = "> Sent: ";

	// Token: 0x0400022F RID: 559
	private string string_30 = " <";

	// Token: 0x04000230 RID: 560
	private string string_31 = "> ERROR: Invalid echo: ";

	// Token: 0x04000231 RID: 561
	private string string_32 = "Invalid echo!";

	// Token: 0x04000232 RID: 562
	private string string_33 = "Received: ";
}
