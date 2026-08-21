using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

// Token: 0x02000055 RID: 85
public sealed class GClass93 : GClass11
{
	// Token: 0x0600034B RID: 843 RVA: 0x00053154 File Offset: 0x00051354
	public GClass93(byte byte_10, List<GClass104> list_6, List<GClass104> list_7)
	{
		this.byte_0 = byte_10;
		this.list_0 = list_7;
		this.list_1 = list_6;
	}

	// Token: 0x0600034C RID: 844 RVA: 0x000533C4 File Offset: 0x000515C4
	public override void vmethod_1()
	{
		try
		{
			this.int_1 = 0;
			byte[] array = new byte[0];
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
				byte[][] array2 = new byte[][]
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
				for (int j = 0; j < 20; j++)
				{
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(100);
				}
				GClass126.smethod_2("Testing mode!", 1);
				this.string_7 = "26 86 9B 02 9E";
				for (int k = 0; k < this.list_1.Count; k++)
				{
					GClass104 gclass = this.list_1[k];
					if (gclass.byte_0[0][0] == 0)
					{
						gclass.method_1(this.string_7);
					}
					else
					{
						gclass.method_1(this.r4(array2[3], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_54))
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
				this.serialPort_0 = new SerialPort(GClass125.smethod_55(), 4800, Parity.None, 8, StopBits.One);
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
			int n = 6;
			int num = 130;
			int num2 = 200;
			if (this.genum0_0 != (GEnum0)0)
			{
				n = 1;
			}
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
					GClass126.smethod_2("5bps wake up start 71 (" + GClass127.smethod_23(this.byte_0) + ")...", 1);
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
					GClass126.smethod_2(this.method_52(b9), 0);
					this.byte_9 = 1;
					List<byte> list = new List<byte>();
					string string_ = "";
					array = this.method_53(ref string_);
					GClass126.smethod_2(string_, 0);
					if (array.Length != 0)
					{
						for (int num4 = 0; num4 < array.Length; num4++)
						{
							list.Add(array[num4]);
						}
					}
					array = this.method_48(this.byte_4);
					if (array.Length > 2)
					{
						for (int num5 = 2; num5 < array.Length; num5++)
						{
							list.Add(array[num5]);
						}
					}
					array = list.ToArray();
					this.serialPort_0.ReadTimeout = 350;
					n = 0;
				}
				catch (Exception)
				{
					this.serialPort_0.BreakState = false;
					n--;
					if (n == 0)
					{
						throw new Exception("1");
					}
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					for (int num6 = 0; num6 < 25; num6++)
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
						num2 = 204;
					}
					else if (n == 2)
					{
						num2 = 194;
					}
					else if (n == 1)
					{
						num = 100;
						num2 = 192;
					}
				}
			}
			GClass126.smethod_2("ECU wakeup completed", 1);
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
				Thread thread = new Thread(new ThreadStart(this.method_55));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_54))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				for (int num7 = 0; num7 < this.list_1.Count; num7++)
				{
					GClass104 gclass2 = this.list_1[num7];
					if (gclass2.byte_0[0][0] == 0)
					{
						gclass2.method_1(this.string_7);
					}
					else if (gclass2.byte_0[0].Length > 2 && array.Length != 0 && gclass2.byte_0[0][0] == 3 && gclass2.byte_0[0][2] == 0)
					{
						gclass2.method_1(this.r4(array, gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
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

	// Token: 0x0600034D RID: 845 RVA: 0x0004A968 File Offset: 0x00048B68
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

	// Token: 0x0600034E RID: 846 RVA: 0x00053DA4 File Offset: 0x00051FA4
	public List<GClass102> method_45()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_6;
		}
		else
		{
			array = this.method_48(this.byte_7);
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

	// Token: 0x0600034F RID: 847 RVA: 0x000540AC File Offset: 0x000522AC
	public override List<GClass102> r1()
	{
		if (this.string_0 == "MA1.7.3")
		{
			return this.method_45();
		}
		if (this.string_0 == "M1.7X01")
		{
			return this.method_45();
		}
		if (this.string_0 == "M1.7X02")
		{
			return this.method_45();
		}
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_5;
		}
		else
		{
			array = this.method_48(this.byte_7);
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

	// Token: 0x06000350 RID: 848 RVA: 0x00009148 File Offset: 0x00007348
	private string method_46(byte byte_10)
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

	// Token: 0x06000351 RID: 849 RVA: 0x000543EC File Offset: 0x000525EC
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
		try
		{
			this.serialPort_0.ReadTimeout = 950;
			byte[] array = this.method_48(this.byte_8);
			if (array.Length < 2 || array[1] != 9)
			{
				GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
			this.serialPort_0.ReadTimeout = 350;
		}
		catch (Exception ex)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 0);
			GClass126.smethod_2(ex.Message, 0);
			GClass126.smethod_2(ex.StackTrace, 0);
		}
	}

	// Token: 0x06000352 RID: 850 RVA: 0x00054498 File Offset: 0x00052698
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

	// Token: 0x06000353 RID: 851 RVA: 0x00054520 File Offset: 0x00052720
	private void method_47(GClass104 gclass104_1)
	{
		byte[] array = this.method_48(gclass104_1.byte_0[0]);
		if (array.Length != 0)
		{
			if (array.Length <= 1 || array[1] == 9)
			{
				if (gclass104_1.byte_0.Length > 2)
				{
					for (int i = 1; i < gclass104_1.byte_0.Length; i++)
					{
						bool flag = false;
						if (gclass104_1.byte_0[i].Length > 4 && gclass104_1.byte_0[i][2] == 2)
						{
							flag = true;
						}
						if (!gclass104_1.string_2.Contains("NOWAIT") && !flag)
						{
							Thread.Sleep(3000);
						}
						this.method_48(gclass104_1.byte_0[i]);
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
						this.method_48(gclass104_1.byte_0[j]);
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
		string text = "";
		base.method_28(false, GClass121.smethod_6("6052"), text);
		if (!gclass104_1.string_2.Contains("NOWAIT"))
		{
			Thread.Sleep(1800);
		}
	}

	// Token: 0x06000354 RID: 852 RVA: 0x00054698 File Offset: 0x00052898
	public override string vmethod_0(byte[] byte_10, string string_33, int int_12, int int_13, string[] string_34, string string_35)
	{
		byte[] array = this.method_48(byte_10);
		if (array.Length == 0)
		{
			array = this.method_48(byte_10);
		}
		return this.r4(array, string_33, int_12, int_13, string_34, string_35);
	}

	// Token: 0x06000355 RID: 853 RVA: 0x000546C8 File Offset: 0x000528C8
	private byte[] method_48(byte[] byte_10)
	{
		List<byte> list = new List<byte>();
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			byte[] array = this.method_49(byte_10);
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i]);
			}
			int num = 10;
			while (array.Length != 0 && array[1] != 9 && num > 0)
			{
				array = this.method_49(this.byte_4);
				if (array.Length > 2)
				{
					for (int j = 2; j < array.Length; j++)
					{
						list.Add(array[j]);
					}
				}
				num--;
			}
		}
		finally
		{
			this.bool_2 = false;
		}
		return list.ToArray();
	}

	// Token: 0x06000356 RID: 854 RVA: 0x0005477C File Offset: 0x0005297C
	private byte[] method_49(byte[] byte_10)
	{
		string text = "";
		byte[] result;
		try
		{
			while (GClass126.smethod_1() < this.int_0 + this.int_10)
			{
				Thread.Sleep(1);
			}
			this.serialPort_0.ReadExisting();
			byte byte_11 = byte_10[0];
			text = this.method_52(byte_11);
			byte b = (byte)this.serialPort_0.ReadByte();
			this.int_0 = GClass126.smethod_1();
			if (b != this.method_50(byte_11))
			{
				text = text + " <ERROR: Invalid ack byte! [" + GClass127.smethod_23(b) + "]>";
			}
			byte_10[1] = this.byte_9;
			this.byte_9 += 1;
			for (int i = 1; i < byte_10.Length - 1; i++)
			{
				text += this.method_52(byte_10[i]);
				byte b2 = (byte)this.serialPort_0.ReadByte();
				this.int_0 = GClass126.smethod_1();
				if (b2 != this.method_50(byte_10[i]))
				{
					text = text + " <ERROR: Invalid ack byte! [" + GClass127.smethod_23(b2) + "]>";
				}
			}
			text += this.method_52(3);
			GClass126.smethod_2(text, 0);
			text = "";
			byte[] array = this.method_53(ref text);
			GClass126.smethod_2(text, 0);
			text = "";
			this.int_1 = 0;
			result = array;
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
				if (this.int_1 > 3)
				{
					this.bool_2 = false;
					GClass126.smethod_2("Terminate 5", 1);
					base.method_30(true);
				}
				this.int_1++;
				try
				{
					this.serialPort_0.ReadTimeout = 90;
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
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x06000357 RID: 855 RVA: 0x00002EBA File Offset: 0x000010BA
	private byte method_50(byte byte_10)
	{
		return byte.MaxValue - byte_10;
	}

	// Token: 0x06000358 RID: 856 RVA: 0x00010BD0 File Offset: 0x0000EDD0
	private byte method_51(byte[] byte_10)
	{
		byte b = 0;
		for (int i = 0; i < byte_10.Length; i++)
		{
			b += byte_10[i];
		}
		return b;
	}

	// Token: 0x06000359 RID: 857 RVA: 0x000325E4 File Offset: 0x000307E4
	public override string r4(byte[] byte_10, string string_33, int int_12, int int_13, string[] string_34, string string_35)
	{
		string result = "";
		int_12++;
		if (byte_10.Length <= int_12)
		{
			return result;
		}
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
		return base.method_33(array, string_33, string_34, string_35);
	}

	// Token: 0x0600035A RID: 858 RVA: 0x000549B8 File Offset: 0x00052BB8
	private string method_52(byte byte_10)
	{
		while (GClass126.smethod_1() < this.int_0 + this.int_8)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_10
		}, 0, 1);
		this.int_0 = GClass126.smethod_1();
		string text = this.string_23 + this.int_0.ToString() + this.string_24 + GClass127.smethod_23(byte_10);
		byte b = (byte)this.serialPort_0.ReadByte();
		int num = GClass126.smethod_1() - this.int_0;
		this.int_0 += num / 3;
		if (num > 15)
		{
			this.int_3 = 25;
		}
		if (byte_10 != b)
		{
			text = string.Concat(new string[]
			{
				text,
				this.string_23,
				this.int_0.ToString(),
				this.string_26,
				GClass127.smethod_23(b)
			});
		}
		return text;
	}

	// Token: 0x0600035B RID: 859 RVA: 0x00054A9C File Offset: 0x00052C9C
	private byte[] method_53(ref string string_33)
	{
		byte b = (byte)this.serialPort_0.ReadByte();
		this.int_0 = GClass126.smethod_1();
		string_33 += this.method_52(this.method_50(b));
		if (b > 127)
		{
			string_33 = string_33 + " <ERROR: Invalid message length! [" + GClass127.smethod_23(b) + "]>";
			return new byte[0];
		}
		byte[] array = new byte[(int)(b - 1)];
		array[0] = b;
		b -= 2;
		byte b2 = (byte)this.serialPort_0.ReadByte();
		this.int_0 = GClass126.smethod_1();
		string_33 += this.method_52(this.method_50(b2));
		for (int i = 0; i < (int)b; i++)
		{
			array[i + 1] = (byte)this.serialPort_0.ReadByte();
			this.int_0 = GClass126.smethod_1();
			string_33 += this.method_52(this.method_50(array[i + 1]));
		}
		byte b3 = (byte)this.serialPort_0.ReadByte();
		this.int_0 = GClass126.smethod_1();
		this.int_0 = GClass126.smethod_1();
		string_33 = string.Concat(new string[]
		{
			string_33,
			this.string_23,
			this.int_0.ToString(),
			this.string_28,
			GClass127.smethod_11(array)
		});
		if (this.byte_9 != b2)
		{
			string_33 = string.Concat(new string[]
			{
				string_33,
				this.string_29,
				GClass127.smethod_23(this.byte_9),
				this.string_30,
				GClass127.smethod_23(b2),
				this.string_31
			});
			if (this.byte_9 != b2 + 1 && this.byte_9 != b2 + 2 && this.byte_9 != b2 + 3 && this.byte_9 != b2 - 1 && this.byte_9 != b2 - 2)
			{
				if (this.byte_9 != b2 - 3)
				{
					b2 = this.byte_9;
					b2 += 1;
					goto IL_1E2;
				}
			}
			this.byte_9 = b2;
		}
		IL_1E2:
		b2 += 1;
		this.byte_9 = b2;
		if (b3 != 3)
		{
			string_33 = string_33 + this.string_32 + GClass127.smethod_23(b3) + this.string_31;
		}
		return array;
	}

	// Token: 0x0600035C RID: 860 RVA: 0x00054CB8 File Offset: 0x00052EB8
	private void method_54()
	{
		GClass126.smethod_2("PM started", 1);
		GClass126.int_3 = 0;
		int num = 0;
		while (!this.bool_1)
		{
			Thread.Sleep(80);
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
										0,
										251,
										0,
										3
									},
									new byte[]
									{
										4,
										0,
										251,
										0,
										3
									},
									new byte[]
									{
										4,
										0,
										251,
										0,
										3
									},
									new byte[]
									{
										4,
										0,
										251,
										0,
										3
									},
									new byte[]
									{
										4,
										0,
										251,
										0,
										3
									},
									new byte[]
									{
										4,
										0,
										251,
										0,
										3
									},
									new byte[]
									{
										7,
										0,
										90,
										153,
										32,
										3,
										7,
										3
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

	// Token: 0x0600035D RID: 861 RVA: 0x0005518C File Offset: 0x0005338C
	private void method_55()
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
				byte[] array = this.method_48(this.byte_3);
				if (array.Length < 2 || array[0] != 3 || array[1] != 9)
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
		GClass126.smethod_2("KA stopped", 1);
	}

	// Token: 0x0400024E RID: 590
	private int int_5 = 2000;

	// Token: 0x0400024F RID: 591
	private int int_6 = 3;

	// Token: 0x04000250 RID: 592
	private int int_7 = 1000;

	// Token: 0x04000251 RID: 593
	private int int_8 = 3;

	// Token: 0x04000252 RID: 594
	private int int_9 = 41;

	// Token: 0x04000253 RID: 595
	private int int_10 = 3;

	// Token: 0x04000254 RID: 596
	private int int_11 = 420;

	// Token: 0x04000255 RID: 597
	private byte[] byte_3 = new byte[]
	{
		3,
		0,
		9,
		3
	};

	// Token: 0x04000256 RID: 598
	private byte[] byte_4 = new byte[]
	{
		3,
		0,
		9,
		3
	};

	// Token: 0x04000257 RID: 599
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

	// Token: 0x04000258 RID: 600
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

	// Token: 0x04000259 RID: 601
	private byte[] byte_7 = new byte[]
	{
		3,
		0,
		7,
		3
	};

	// Token: 0x0400025A RID: 602
	private byte[] byte_8 = new byte[]
	{
		3,
		0,
		5,
		3
	};

	// Token: 0x0400025B RID: 603
	private byte byte_9;

	// Token: 0x0400025C RID: 604
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

	// Token: 0x0400025D RID: 605
	private string string_23 = " <";

	// Token: 0x0400025E RID: 606
	private string string_24 = "> Sent: ";

	// Token: 0x0400025F RID: 607
	private string string_25 = " <";

	// Token: 0x04000260 RID: 608
	private string string_26 = "> ERROR: Invalid echo: ";

	// Token: 0x04000261 RID: 609
	private string string_27 = "Invalid echo!";

	// Token: 0x04000262 RID: 610
	private string string_28 = "> Received: ";

	// Token: 0x04000263 RID: 611
	private string string_29 = " <ERROR: Invalid KWP71 counter! [";

	// Token: 0x04000264 RID: 612
	private string string_30 = "!=";

	// Token: 0x04000265 RID: 613
	private string string_31 = "]>";

	// Token: 0x04000266 RID: 614
	private string string_32 = " <ERROR: Invalid end of message! [";
}
