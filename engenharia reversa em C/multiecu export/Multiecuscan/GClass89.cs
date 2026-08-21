using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

// Token: 0x02000051 RID: 81
public sealed class GClass89 : GClass11
{
	// Token: 0x060002F2 RID: 754 RVA: 0x00049550 File Offset: 0x00047750
	public GClass89(byte byte_13, List<GClass104> list_6, List<GClass104> list_7)
	{
		this.byte_0 = byte_13;
		this.list_0 = list_7;
		this.list_1 = list_6;
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x000498C4 File Offset: 0x00047AC4
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
				for (int j = 0; j < 20; j++)
				{
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(100);
				}
				GClass126.smethod_2("Testing mode!", 1);
				this.string_7 = "AE 80 08 02 0D";
				for (int k = 0; k < this.list_1.Count; k++)
				{
					GClass104 gclass = this.list_1[k];
					if (gclass.byte_0[0][0] == 0)
					{
						gclass.method_1(this.r4(GClass127.smethod_32("00 00 " + this.string_7), gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					}
					else if (this.string_0 == "CLIMA25")
					{
						gclass.method_1(this.r4(GClass127.smethod_32("1B AE AA 55 CC 33 00 3C 41 32 14 97 02 77 01 16 23 80 79 10 AE 00 90 32 32 AA 08"), gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					}
					else
					{
						gclass.method_1(this.r4(array[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_61))
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
				if (!(this.string_0 == "EVCU00") && !(this.string_0 == "OBCM00"))
				{
					this.serialPort_0 = new SerialPort(GClass125.smethod_55(), 4800, Parity.None, 8, StopBits.One);
				}
				else
				{
					this.serialPort_0 = new SerialPort(GClass125.smethod_55(), 9600, Parity.None, 8, StopBits.One);
				}
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
			if (this.string_0 == "IAW1AF")
			{
				this.int_7 = 2050;
				this.int_11 = 150;
			}
			else if (this.string_0 == "ROOF2")
			{
				this.int_8 = 5;
				this.int_11 = 180;
			}
			else if (this.string_0 == "EVCU00")
			{
				this.int_8 = 10;
				this.int_11 = 320;
				this.int_10 = 10;
			}
			int n = 6;
			int num = 130;
			int num2 = 200;
			while (n > 0)
			{
				try
				{
					BitArray bitArray = new BitArray(new byte[]
					{
						this.byte_0
					});
					this.int_0 = GClass126.smethod_1();
					this.serialPort_0.ReadTimeout = 1;
					GClass126.smethod_2("5bps wake up start (" + GClass127.smethod_23(this.byte_0) + ")...", 1);
					for (int num3 = -1; num3 < bitArray.Length; num3++)
					{
						if (num3 == -1)
						{
							this.serialPort_0.RtsEnable = true;
							this.serialPort_0.BreakState = true;
						}
						else
						{
							this.serialPort_0.RtsEnable = !bitArray[num3];
							this.serialPort_0.BreakState = !bitArray[num3];
						}
						while (this.int_0 + num > GClass126.smethod_1())
						{
							Thread.Sleep(10);
						}
						while (this.int_0 + num2 > GClass126.smethod_1())
						{
						}
						this.int_0 = GClass126.smethod_1();
					}
					this.serialPort_0.RtsEnable = false;
					this.serialPort_0.BreakState = false;
					try
					{
						this.serialPort_0.ReadExisting();
					}
					catch (Exception)
					{
					}
					this.serialPort_0.ReadTimeout = this.int_7;
					this.int_0 = GClass126.smethod_1();
					GClass126.smethod_2("Waiting ECU response...", 1);
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
					GClass126.smethod_2("c1: " + GClass127.smethod_23(b5), 0);
					b2 += b5;
					byte b6 = (byte)this.serialPort_0.ReadByte();
					GClass126.smethod_2("c2: " + GClass127.smethod_23(b6), 0);
					b2 += b6;
					byte b7 = (byte)this.serialPort_0.ReadByte();
					GClass126.smethod_2("CR: " + GClass127.smethod_23(b7), 0);
					byte b8 = b7;
					b7 &= 127;
					b2 &= 127;
					if (b7 != b2)
					{
						GClass126.smethod_2("ERROR: Invalid checksum", 1);
						throw new Exception("Invalid checksum");
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
					byte b9 = b4;
					b9 ^= byte.MaxValue;
					this.int_0 = GClass126.smethod_1();
					if (this.string_0 == "ROOF2")
					{
						this.int_8 = 20;
					}
					if (this.string_0 != "IAW1AF" && n > 1)
					{
						GClass126.smethod_2(this.method_57(b9), 0);
					}
					if (this.string_0 == "ROOF2")
					{
						this.int_8 = 5;
					}
					if (this.string_0 != "IAW1AF" && n > 0)
					{
						if (n == 3)
						{
							byte byte_ = (byte)this.serialPort_0.ReadByte();
							GClass126.smethod_2("Response: " + GClass127.smethod_23(byte_), 0);
						}
						else
						{
							if (n == 2)
							{
								this.serialPort_0.ReadTimeout = 180;
							}
							else if (n == 1)
							{
								this.serialPort_0.ReadTimeout = 60;
							}
							try
							{
								this.method_60();
							}
							catch (Exception)
							{
								GClass126.smethod_2("No identification after init!", 0);
							}
						}
					}
					this.serialPort_0.ReadTimeout = this.int_11 - 20;
					n = 0;
				}
				catch (Exception)
				{
					this.serialPort_0.BreakState = false;
					if (this.genum0_0 != (GEnum0)0)
					{
						n = 1;
					}
					n--;
					if (n == 0)
					{
						throw new Exception("1");
					}
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					for (int num4 = 0; num4 < 25; num4++)
					{
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
					if (n == 5)
					{
						num2 = 198;
					}
					else if (n == 4)
					{
						num2 = 196;
					}
					else if (n == 3)
					{
						num2 = 202;
					}
					else if (n == 2)
					{
						num2 = 198;
					}
					else if (n == 1)
					{
						num = 130;
						num2 = 199;
					}
				}
			}
			GClass126.smethod_2("ECU wakeup completed", 1);
			if (this.string_0 == "CLIMA25" || this.string_0 == "IAW1AF")
			{
				this.byte_3 = GClass127.smethod_32("03 09 00 0C");
				this.byte_10 = GClass127.smethod_32("03 50 00 53");
				this.byte_11 = GClass127.smethod_32("03 60 00 63");
				this.bool_6 = true;
				this.method_55(GClass127.smethod_32("03 34 51 88"));
				this.method_55(GClass127.smethod_32("04 00 00 00 04"));
			}
			if (this.string_0 == "VAS974")
			{
				this.byte_10 = GClass127.smethod_32("03 10 06");
				this.byte_11 = GClass127.smethod_32("06 02 01 00 04 00");
				this.int_11 = 100;
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
				Thread thread = new Thread(new ThreadStart(this.method_62));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_61))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				for (int num5 = 0; num5 < this.list_1.Count; num5++)
				{
					GClass104 gclass2 = this.list_1[num5];
					if (gclass2.byte_0[0][0] == 0)
					{
						gclass2.method_1(this.r4(GClass127.smethod_32("00 00 " + this.string_7), gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
					}
					else
					{
						gclass2.method_1(this.vmethod_0(gclass2.byte_0[0], gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
					}
				}
				this.bool_0 = true;
				base.method_36();
			}
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

	// Token: 0x060002F4 RID: 756 RVA: 0x0000325A File Offset: 0x0000145A
	private bool method_45()
	{
		return this.method_46();
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x0004A4CC File Offset: 0x000486CC
	private bool method_46()
	{
		this.int_12++;
		if (this.int_12 > 5)
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
		if (this.string_0 == "EVCU00" && this.int_12 > 1)
		{
			this.int_8 = 10;
			this.int_11 = 160;
			this.int_10 = 10;
		}
		bool result;
		try
		{
			BitArray bitArray = new BitArray(new byte[]
			{
				this.byte_0
			});
			this.int_0 = GClass126.smethod_1();
			this.serialPort_0.ReadTimeout = 1;
			GClass126.smethod_2("5bps wake up start (" + GClass127.smethod_23(this.byte_0) + ")...", 1);
			for (int j = -1; j < bitArray.Length; j++)
			{
				if (j == -1)
				{
					this.serialPort_0.RtsEnable = true;
					this.serialPort_0.BreakState = true;
				}
				else
				{
					this.serialPort_0.RtsEnable = !bitArray[j];
					this.serialPort_0.BreakState = !bitArray[j];
				}
				while (this.int_0 + 130 > GClass126.smethod_1())
				{
					Thread.Sleep(10);
				}
				while (this.int_0 + 200 > GClass126.smethod_1())
				{
				}
				this.int_0 = GClass126.smethod_1();
			}
			this.serialPort_0.RtsEnable = false;
			this.serialPort_0.BreakState = false;
			try
			{
				this.serialPort_0.ReadExisting();
			}
			catch (Exception)
			{
			}
			this.serialPort_0.ReadTimeout = this.int_7;
			this.int_0 = GClass126.smethod_1();
			GClass126.smethod_2("Waiting ECU response...", 1);
			byte b = (byte)this.serialPort_0.ReadByte();
			byte b2 = 0 + b;
			if (b != 85)
			{
				GClass126.smethod_2("ERROR: Invalid synchronization byte", 1);
				throw new Exception("Invalid synchronization byte");
			}
			byte b3 = (byte)this.serialPort_0.ReadByte();
			b2 += b3;
			byte b4 = (byte)this.serialPort_0.ReadByte();
			b2 += b4;
			byte b5 = (byte)this.serialPort_0.ReadByte();
			b2 += b5;
			byte b6 = (byte)this.serialPort_0.ReadByte();
			b2 += b6;
			byte b8;
			byte b7 = (b8 = (byte)this.serialPort_0.ReadByte()) & 127;
			b2 &= 127;
			if (b7 != b2)
			{
				GClass126.smethod_2("ERROR: Invalid checksum", 1);
				throw new Exception("Invalid checksum");
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
			byte b9 = b4;
			b9 ^= byte.MaxValue;
			this.int_0 = GClass126.smethod_1();
			if (this.string_0 == "ROOF2")
			{
				this.int_8 = 20;
			}
			if (this.string_0 != "IAW1AF")
			{
				GClass126.smethod_2(this.method_57(b9), 0);
			}
			if (this.string_0 == "ROOF2")
			{
				this.int_8 = 5;
			}
			if (this.string_0 != "IAW1AF" && this.string_0 != "CLIMA25")
			{
				this.serialPort_0.ReadTimeout = 185;
				try
				{
					this.method_60();
				}
				catch (Exception)
				{
					GClass126.smethod_2("No identification after init!", 0);
				}
			}
			this.serialPort_0.ReadTimeout = this.int_11 - 20;
			goto IL_384;
		}
		catch (Exception)
		{
			try
			{
				this.serialPort_0.BreakState = false;
			}
			catch (Exception)
			{
			}
			result = false;
		}
		return result;
		IL_384:
		if (this.string_0 == "CLIMA25" || this.string_0 == "IAW1AF")
		{
			this.byte_3 = GClass127.smethod_32("03 09 00 0C");
			this.byte_10 = GClass127.smethod_32("03 50 00 53");
			this.byte_11 = GClass127.smethod_32("03 60 00 63");
			this.bool_6 = true;
			this.method_55(GClass127.smethod_32("03 34 51 88"));
			this.method_55(GClass127.smethod_32("04 00 00 00 04"));
		}
		if (this.string_0 == "EVCU00" && this.int_12 < 3)
		{
			Thread.Sleep(300);
		}
		return true;
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x0004A968 File Offset: 0x00048B68
	public override void r0(bool bool_7, bool bool_8)
	{
		if (this.bool_1)
		{
			return;
		}
		GClass126.smethod_2("Terminating " + (bool_7 ? "with reconnect" : ""), 1);
		if (GClass126.bool_0 && !bool_8)
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
		base.method_32(bool_8);
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x0004AA34 File Offset: 0x00048C34
	public List<GClass102> method_47()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_5;
		}
		else
		{
			array = this.method_54(this.byte_10);
		}
		if (array.Length >= 18)
		{
			if (array[1] == 252)
			{
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						if ((array[2 + i] & this.byte_12[j]) != 0 || (array[10 + i] & this.byte_12[j]) != 0)
						{
							try
							{
								GClass102 gclass = new GClass102();
								byte byte_ = (byte)(i * 8 + (j + 1));
								gclass.string_0 = GClass127.smethod_23(byte_);
								gclass.byte_0 = (((array[10 + i] & this.byte_12[j]) > 0) ? 1 : 0);
								GClass102 gclass2 = gclass;
								gclass2.byte_0 += (((array[2 + i] & this.byte_12[j]) != 0) ? 10 : 0);
								gclass.byte_1 = 32;
								gclass.string_5 = "";
								gclass.string_6 = "";
								gclass.string_7 = "";
								gclass.string_2 = "";
								string string_ = "";
								if (gclass.byte_0 == 1)
								{
									string_ = GClass121.smethod_6("3062");
								}
								else if (gclass.byte_0 == 10)
								{
									string_ = GClass121.smethod_6("3053");
								}
								else if (gclass.byte_0 == 11)
								{
									string_ = GClass121.smethod_6("3062") + "/" + GClass121.smethod_6("3053");
								}
								string str = "";
								if (gclass.byte_0 == 1)
								{
									str = GClass121.smethod_6("3077");
								}
								else if (gclass.byte_0 == 10)
								{
									str = GClass121.smethod_6("3076");
								}
								else if (gclass.byte_0 == 11)
								{
									str = GClass121.smethod_6("3078");
								}
								gclass.string_6 = string_;
								GClass102 gclass3 = gclass;
								gclass3.string_3 = gclass3.string_3 + str + "\r\n";
								list.Add(gclass);
								goto IL_1FF;
							}
							catch (Exception)
							{
								GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
								goto IL_1FF;
							}
							break;
						}
						IL_1FF:;
					}
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x0004AC74 File Offset: 0x00048E74
	public List<GClass102> method_48()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_7;
		}
		else
		{
			array = this.method_54(this.byte_10);
		}
		if (array.Length < 2)
		{
			GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
			return null;
		}
		for (int i = 2; i < array.Length; i++)
		{
			if (array[i] != 0)
			{
				try
				{
					GClass102 gclass = new GClass102();
					gclass.string_0 = ((i - 1 < 10) ? "0" : "") + (i - 1).ToString();
					gclass.byte_0 = array[i];
					gclass.byte_1 = 32;
					gclass.string_5 = "";
					gclass.string_6 = "";
					gclass.string_7 = "";
					gclass.string_2 = "";
					string string_ = GClass121.smethod_6("3062");
					if (gclass.byte_0 == 1)
					{
						string_ = GClass121.smethod_6("3054");
					}
					gclass.string_6 = string_;
					list.Add(gclass);
				}
				catch (Exception)
				{
					GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
				}
			}
		}
		return list;
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x0004AD94 File Offset: 0x00048F94
	public List<GClass102> method_49()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_8;
		}
		else
		{
			array = this.method_54(this.byte_10);
		}
		if (array.Length >= 20)
		{
			if (array[1] == 175)
			{
				for (int i = 0; i < this.int_14.Length; i++)
				{
					if (array.Length >= this.int_15[this.int_15.Length - 1])
					{
						for (int j = 0; j < 8; j++)
						{
							if ((array[2 + this.int_14[i]] & this.byte_12[j]) != 0 || (array[2 + this.int_15[i]] & this.byte_12[j]) != 0)
							{
								try
								{
									GClass102 gclass = new GClass102();
									gclass.string_0 = i.ToString() + (j + 1).ToString();
									gclass.byte_0 = (((array[2 + this.int_13[i]] & this.byte_12[j]) > 0) ? 1 : 0);
									GClass102 gclass2 = gclass;
									gclass2.byte_0 += (((array[2 + this.int_14[i]] & this.byte_12[j]) != 0) ? 2 : 0);
									GClass102 gclass3 = gclass;
									gclass3.byte_0 += (((array[2 + this.int_15[i]] & this.byte_12[j]) != 0) ? 4 : 0);
									gclass.byte_1 = 32;
									gclass.string_5 = "";
									gclass.string_6 = "";
									gclass.string_7 = "";
									gclass.string_2 = "";
									string string_ = "";
									if ((gclass.byte_0 & 1) == 1)
									{
										string_ = GClass121.smethod_6("3062");
									}
									else if ((gclass.byte_0 & 4) == 4)
									{
										string_ = GClass121.smethod_6("3053");
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
									else if ((gclass.byte_0 & 4) == 4)
									{
										str = GClass121.smethod_6("3076");
									}
									else if ((gclass.byte_0 & 2) == 2)
									{
										str = GClass121.smethod_6("3075");
									}
									gclass.string_6 = string_;
									GClass102 gclass4 = gclass;
									gclass4.string_3 = gclass4.string_3 + str + "\r\n";
									list.Add(gclass);
									goto IL_25E;
								}
								catch (Exception)
								{
									GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
									goto IL_25E;
								}
								break;
							}
							IL_25E:;
						}
					}
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x060002FA RID: 762 RVA: 0x0004B034 File Offset: 0x00049234
	public List<GClass102> method_50()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array = this.byte_4;
		int num = 10;
		while (array.Length > 3 && num > 0)
		{
			if (GClass126.bool_0)
			{
				array = this.byte_4;
			}
			else
			{
				array = this.method_54(this.byte_10);
			}
			if (array.Length < 2 && num == 10)
			{
				GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
				return null;
			}
			for (int i = 2; i < array.Length - 5; i += 5)
			{
				try
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
					bool flag = false;
					using (List<GClass102>.Enumerator enumerator = list.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current.string_0 == gclass.string_0)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						list.Add(gclass);
					}
					goto IL_31B;
				}
				catch (Exception)
				{
					GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
					goto IL_31B;
				}
				break;
				IL_31B:;
			}
			num--;
		}
		return list;
	}

	// Token: 0x060002FB RID: 763 RVA: 0x0004B3A8 File Offset: 0x000495A8
	public List<GClass102> method_51()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_9;
		}
		else
		{
			array = this.method_54(this.byte_10);
		}
		if (array.Length >= 2)
		{
			if (array[1] == 252)
			{
				for (int i = 2; i < array.Length - 2; i += 3)
				{
					try
					{
						GClass102 gclass = new GClass102();
						gclass.string_0 = GClass127.smethod_11(new byte[]
						{
							array[i]
						}).Replace(" ", "");
						gclass.byte_0 = array[i + 1];
						gclass.byte_1 = array[i + 2];
						gclass.string_5 = "";
						gclass.string_6 = "";
						gclass.string_7 = "";
						gclass.string_2 = GClass127.smethod_11(new byte[]
						{
							array[i]
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
						list.Add(gclass);
					}
					catch (Exception)
					{
						GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
					}
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x060002FC RID: 764 RVA: 0x0004B688 File Offset: 0x00049888
	public override List<GClass102> r1()
	{
		if (this.string_0 == "ABSTEVES")
		{
			return this.method_47();
		}
		if (this.string_0 == "HTCHI")
		{
			return this.method_50();
		}
		if (this.string_0 == "CLIMA25")
		{
			return this.method_48();
		}
		if (this.string_0 == "IAW1AF")
		{
			return this.method_49();
		}
		if (this.string_0 == "EVCU00")
		{
			return this.method_51();
		}
		if (this.string_0 == "OBCM00")
		{
			return this.method_51();
		}
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0 && this.string_0 == "TD100")
		{
			array = this.byte_6;
		}
		else if (GClass126.bool_0)
		{
			array = this.byte_4;
		}
		else
		{
			array = this.method_54(this.byte_10);
		}
		if (array.Length >= 2)
		{
			if (array[1] == 252)
			{
				int i = 2;
				while (i < array.Length - 4)
				{
					try
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
						list.Add(gclass);
						goto IL_361;
					}
					catch (Exception)
					{
						GClass126.smethod_2("ERROR: Exception while reading error codes.", 0);
						goto IL_361;
					}
					IL_358:
					i++;
					continue;
					IL_361:
					i += 5;
					if (this.string_0 == "TD100")
					{
						goto IL_358;
					}
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x060002FD RID: 765 RVA: 0x00009148 File Offset: 0x00007348
	private string method_52(byte byte_13)
	{
		string result = "";
		if ((byte_13 & 8) != 0)
		{
			result = GClass121.smethod_6("3056");
		}
		else if ((byte_13 & 4) != 0)
		{
			result = GClass121.smethod_6("3057");
		}
		else if ((byte_13 & 2) != 0)
		{
			result = GClass121.smethod_6("3058");
		}
		else if ((byte_13 & 1) != 0)
		{
			result = GClass121.smethod_6("3059");
		}
		return result;
	}

	// Token: 0x060002FE RID: 766 RVA: 0x0004BA3C File Offset: 0x00049C3C
	public override void r2()
	{
		if (GClass126.bool_0)
		{
			this.byte_4 = new byte[]
			{
				2,
				252
			};
			return;
		}
		byte[] array = this.method_54(this.byte_11);
		if (array.Length < 2 || array[1] != 9)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x060002FF RID: 767 RVA: 0x0004BA90 File Offset: 0x00049C90
	protected override void r3(GClass104 gclass104_1)
	{
		if (!GClass126.bool_0)
		{
			this.method_53(gclass104_1);
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

	// Token: 0x06000300 RID: 768 RVA: 0x0004BB18 File Offset: 0x00049D18
	private void method_53(GClass104 gclass104_1)
	{
		byte[] array = this.method_54(gclass104_1.byte_0[0]);
		bool flag = false;
		if (array.Length == 0)
		{
			flag = true;
		}
		else if (this.string_0 == "EVCU00" && GClass127.smethod_11(array) == "02 0B")
		{
			flag = false;
		}
		else if (this.string_0 == "EVCU00" && GClass127.smethod_11(array) == "03 E8 FF")
		{
			flag = false;
		}
		else if (array.Length > 1 && array[1] != 9 && array[1] != 13)
		{
			flag = true;
		}
		if (GClass127.smethod_11(gclass104_1.byte_0[0]) == "06 02 01 00 01 01" && GClass127.smethod_11(array) == "05 ED 00 01 FF")
		{
			flag = false;
		}
		if (flag)
		{
			string text = "";
			base.method_28(false, GClass121.smethod_6("6052"), text);
			for (int i = 0; i < 18; i++)
			{
				if (!GClass126.bool_25)
				{
					Thread.Sleep(100);
				}
			}
			return;
		}
		if (gclass104_1.byte_0.Length > 2)
		{
			for (int j = 1; j < gclass104_1.byte_0.Length; j++)
			{
				for (int k = 0; k < 20; k++)
				{
					if (!GClass126.bool_25)
					{
						Thread.Sleep(100);
					}
				}
				this.method_54(gclass104_1.byte_0[j]);
			}
		}
		else if (gclass104_1.byte_0.Length == 2)
		{
			for (int l = 1; l < gclass104_1.byte_0.Length; l++)
			{
				for (int m = 0; m < 80; m++)
				{
					if (!GClass126.bool_25)
					{
						Thread.Sleep(100);
					}
				}
				this.method_54(gclass104_1.byte_0[l]);
			}
		}
		else
		{
			for (int n = 0; n < 100; n++)
			{
				if (!GClass126.bool_25)
				{
					Thread.Sleep(100);
				}
			}
		}
		base.method_28(false, GClass121.smethod_6("6051"), "");
	}

	// Token: 0x06000301 RID: 769 RVA: 0x0004BCE4 File Offset: 0x00049EE4
	public override string vmethod_0(byte[] byte_13, string string_29, int int_16, int int_17, string[] string_30, string string_31)
	{
		byte[] array = this.method_54(byte_13);
		if (array.Length == 0)
		{
			array = this.method_54(byte_13);
		}
		if (string_29 == "raw")
		{
			return GClass127.smethod_11(array);
		}
		return this.r4(array, string_29, int_16, int_17, string_30, string_31);
	}

	// Token: 0x06000302 RID: 770 RVA: 0x0004BD28 File Offset: 0x00049F28
	private byte[] method_54(byte[] byte_13)
	{
		List<byte> list = new List<byte>();
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			byte[] array = this.method_55(byte_13);
			int num = array.Length;
			if (this.string_0 == "IAW1AF")
			{
				num--;
			}
			for (int i = 0; i < num; i++)
			{
				list.Add(array[i]);
			}
			int num2 = 10;
			if (this.string_0 == "CLIMA25")
			{
				num2 = 0;
			}
			while (array.Length != 0 && array[1] != 9 && num2 > 0)
			{
				array = this.method_55(this.byte_3);
				num = array.Length;
				if (this.string_0 == "IAW1AF")
				{
					num--;
				}
				if (num > 2)
				{
					for (int j = 2; j < num; j++)
					{
						list.Add(array[j]);
					}
				}
				num2--;
			}
			if (array.Length == 0)
			{
				array = this.method_55(this.byte_3);
				list.Clear();
			}
		}
		finally
		{
			this.bool_2 = false;
		}
		return list.ToArray();
	}

	// Token: 0x06000303 RID: 771 RVA: 0x0004BE38 File Offset: 0x0004A038
	private byte[] method_55(byte[] byte_13)
	{
		string text = "";
		byte[] result;
		try
		{
			byte b = 0;
			while (GClass126.smethod_1() < this.int_0 + this.int_10)
			{
				Thread.Sleep(1);
			}
			this.serialPort_0.ReadExisting();
			byte b2 = byte_13[0];
			text = this.method_58(b2);
			b += b2;
			byte[] array = new byte[byte_13.Length + 1];
			array[0] = byte_13[0];
			for (int i = 1; i < byte_13.Length; i++)
			{
				text += this.method_58(byte_13[i]);
				b += byte_13[i];
				array[i] = byte_13[i];
			}
			if (this.string_0 != "CLIMA25" && this.string_0 != "IAW1AF")
			{
				text += this.method_58(b);
				array[byte_13.Length] = b;
			}
			GClass126.smethod_2(text, 0);
			text = "";
			this.method_59(array);
			byte[] array2 = this.method_60();
			this.int_1 = 0;
			result = array2;
		}
		catch (Exception ex)
		{
			if (!this.bool_1)
			{
				if (text != "")
				{
					GClass126.smethod_2(text, 0);
				}
				GClass126.smethod_2(ex.Message + "(3)", 1);
				if (this.int_1 > 1)
				{
					if (!this.method_45())
					{
						this.bool_2 = false;
						GClass126.smethod_2("Terminate 5", 1);
						base.method_30(true);
					}
					else
					{
						this.int_1 = 2;
					}
				}
				else
				{
					this.int_1++;
					try
					{
						this.serialPort_0.ReadTimeout = 100;
						for (int j = 0; j < 20; j++)
						{
							this.serialPort_0.ReadByte();
						}
					}
					catch (Exception)
					{
					}
					try
					{
						this.serialPort_0.ReadTimeout = 350;
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

	// Token: 0x06000304 RID: 772 RVA: 0x00010BD0 File Offset: 0x0000EDD0
	private byte method_56(byte[] byte_13)
	{
		byte b = 0;
		for (int i = 0; i < byte_13.Length; i++)
		{
			b += byte_13[i];
		}
		return b;
	}

	// Token: 0x06000305 RID: 773 RVA: 0x000325E4 File Offset: 0x000307E4
	public override string r4(byte[] byte_13, string string_29, int int_16, int int_17, string[] string_30, string string_31)
	{
		string result = "";
		int_16++;
		if (byte_13.Length <= int_16)
		{
			return result;
		}
		int num = byte_13.Length - int_16;
		if (int_17 < num)
		{
			num = int_17;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_13[i + int_16];
		}
		return base.method_33(array, string_29, string_30, string_31);
	}

	// Token: 0x06000306 RID: 774 RVA: 0x0004C020 File Offset: 0x0004A220
	private string method_57(byte byte_13)
	{
		while (GClass126.smethod_1() < this.int_0 + this.int_8)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_13
		}, 0, 1);
		this.int_0 = GClass126.smethod_1();
		string text = this.string_23 + this.int_0.ToString() + this.string_24 + GClass127.smethod_23(byte_13);
		byte b = (byte)this.serialPort_0.ReadByte();
		int num = GClass126.smethod_1() - this.int_0;
		this.int_0 += num / 3;
		if (num > 15)
		{
			this.int_3 = 25;
		}
		if (byte_13 != b)
		{
			text = string.Concat(new string[]
			{
				text,
				this.string_23,
				this.int_0.ToString(),
				this.string_26,
				GClass127.smethod_23(b)
			});
			throw new Exception(this.string_27);
		}
		return text;
	}

	// Token: 0x06000307 RID: 775 RVA: 0x0004C110 File Offset: 0x0004A310
	private string method_58(byte byte_13)
	{
		if (!GClass125.smethod_65())
		{
			return this.method_57(byte_13);
		}
		while (GClass126.smethod_1() < this.int_0 + this.int_8)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_13
		}, 0, 1);
		this.int_0 = GClass126.smethod_1() + 1;
		return this.string_23 + this.int_0.ToString() + this.string_24 + GClass127.smethod_23(byte_13);
	}

	// Token: 0x06000308 RID: 776 RVA: 0x0004C188 File Offset: 0x0004A388
	private void method_59(byte[] byte_13)
	{
		if (!GClass125.smethod_65())
		{
			return;
		}
		bool flag = true;
		for (int i = 0; i < byte_13.Length; i++)
		{
			byte b = (byte)this.serialPort_0.ReadByte();
			if (byte_13[i] != b)
			{
				GClass126.smethod_2("ERROR: Invalid echo: " + GClass127.smethod_23(byte_13[i]) + "->" + GClass127.smethod_23(b), 0);
				flag = false;
			}
		}
		if (this.int_0 + 25 < GClass126.smethod_1())
		{
			this.int_3 = 25;
		}
		if (!flag)
		{
			throw new Exception("Invalid echo!");
		}
	}

	// Token: 0x06000309 RID: 777 RVA: 0x0004C20C File Offset: 0x0004A40C
	private byte[] method_60()
	{
		byte b = (byte)this.serialPort_0.ReadByte();
		byte b2 = 0 + b;
		byte[] array = new byte[(int)b];
		array[0] = b;
		b -= 1;
		if (b == 0)
		{
			return array;
		}
		for (int i = 0; i < (int)b; i++)
		{
			array[i + 1] = (byte)this.serialPort_0.ReadByte();
			if (!this.bool_6 || i < (int)(b - 1))
			{
				b2 += array[i + 1];
			}
		}
		byte b3 = (byte)this.serialPort_0.ReadByte();
		this.int_0 = GClass126.smethod_1();
		GClass126.smethod_2(this.string_28 + GClass127.smethod_11(array), 0);
		if (b2 != b3)
		{
			GClass126.smethod_2("ERROR: Invalid response checksum! [" + GClass127.smethod_23(b3) + "]", 0);
		}
		return array;
	}

	// Token: 0x0600030A RID: 778 RVA: 0x0004C2CC File Offset: 0x0004A4CC
	private void method_61()
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

	// Token: 0x0600030B RID: 779 RVA: 0x0004C7A0 File Offset: 0x0004A9A0
	private void method_62()
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
			if (GClass126.smethod_1() > this.int_0 + this.int_11 && !this.bool_2)
			{
				byte[] array = this.method_54(this.byte_3);
				if (array.Length < 2 || array[1] != 9)
				{
					array = this.method_54(this.byte_3);
					if (array.Length < 2 || array[1] != 9)
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

	// Token: 0x040001EA RID: 490
	private int int_5 = 2000;

	// Token: 0x040001EB RID: 491
	private int int_6 = 3;

	// Token: 0x040001EC RID: 492
	private int int_7 = 1200;

	// Token: 0x040001ED RID: 493
	private int int_8 = 3;

	// Token: 0x040001EE RID: 494
	private int int_9 = 41;

	// Token: 0x040001EF RID: 495
	private int int_10 = 3;

	// Token: 0x040001F0 RID: 496
	private int int_11 = 380;

	// Token: 0x040001F1 RID: 497
	private byte[] byte_3 = new byte[]
	{
		2,
		9
	};

	// Token: 0x040001F2 RID: 498
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

	// Token: 0x040001F3 RID: 499
	private byte[] byte_5 = new byte[]
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

	// Token: 0x040001F4 RID: 500
	private byte[] byte_6 = new byte[]
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

	// Token: 0x040001F5 RID: 501
	private byte[] byte_7 = new byte[]
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

	// Token: 0x040001F6 RID: 502
	private byte[] byte_8 = new byte[]
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
		0,
		1,
		0,
		0,
		0,
		0,
		0,
		0
	};

	// Token: 0x040001F7 RID: 503
	private byte[] byte_9 = new byte[]
	{
		8,
		252,
		3,
		11,
		59,
		2,
		6,
		59
	};

	// Token: 0x040001F8 RID: 504
	private byte[] byte_10 = new byte[]
	{
		2,
		7
	};

	// Token: 0x040001F9 RID: 505
	private byte[] byte_11 = new byte[]
	{
		2,
		5
	};

	// Token: 0x040001FA RID: 506
	private bool bool_6;

	// Token: 0x040001FB RID: 507
	private int int_12;

	// Token: 0x040001FC RID: 508
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
		GClass121.smethod_6("3098"),
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		"",
		""
	};

	// Token: 0x040001FD RID: 509
	private byte[] byte_12 = new byte[]
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

	// Token: 0x040001FE RID: 510
	private int[] int_13 = new int[]
	{
		0,
		1,
		2,
		9,
		10,
		11,
		18,
		21,
		24
	};

	// Token: 0x040001FF RID: 511
	private int[] int_14 = new int[]
	{
		3,
		4,
		5,
		12,
		13,
		14,
		19,
		22,
		25
	};

	// Token: 0x04000200 RID: 512
	private int[] int_15 = new int[]
	{
		6,
		7,
		8,
		15,
		16,
		17,
		20,
		23,
		26
	};

	// Token: 0x04000201 RID: 513
	private string string_23 = " <";

	// Token: 0x04000202 RID: 514
	private string string_24 = "> Sent: ";

	// Token: 0x04000203 RID: 515
	private string string_25 = " <";

	// Token: 0x04000204 RID: 516
	private string string_26 = "> ERROR: Invalid echo: ";

	// Token: 0x04000205 RID: 517
	private string string_27 = "Invalid echo!";

	// Token: 0x04000206 RID: 518
	private string string_28 = "Received: ";
}
