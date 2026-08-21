using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

// Token: 0x02000052 RID: 82
public sealed class GClass90 : GClass11
{
	// Token: 0x0600030C RID: 780 RVA: 0x0004C87C File Offset: 0x0004AA7C
	public GClass90(byte byte_7, List<GClass104> list_6, List<GClass104> list_7)
	{
		this.byte_0 = byte_7;
		this.list_0 = list_7;
		this.list_1 = list_6;
	}

	// Token: 0x0600030D RID: 781 RVA: 0x0004CABC File Offset: 0x0004ACBC
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
				for (int j = 0; j < 20; j++)
				{
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(100);
				}
				GClass126.smethod_2("Testing mode!", 1);
				this.string_7 = "A7 86 02 97 9B";
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
				new Thread(new ThreadStart(this.method_55))
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
					this.int_0 = GClass126.smethod_1();
					this.serialPort_0.ReadTimeout = 400;
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
			if (this.string_0 == "ABG23")
			{
				this.int_11 = 46;
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
				Thread thread = new Thread(new ThreadStart(this.method_56));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_55))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				for (int num5 = 0; num5 < this.list_1.Count; num5++)
				{
					GClass104 gclass2 = this.list_1[num5];
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

	// Token: 0x0600030E RID: 782 RVA: 0x00003262 File Offset: 0x00001462
	private bool method_45()
	{
		return this.method_46();
	}

	// Token: 0x0600030F RID: 783 RVA: 0x0004D31C File Offset: 0x0004B51C
	private bool method_46()
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
			this.serialPort_0.ReadTimeout = 400;
			return true;
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
	}

	// Token: 0x06000310 RID: 784 RVA: 0x0004A968 File Offset: 0x00048B68
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

	// Token: 0x06000311 RID: 785 RVA: 0x0004D5F4 File Offset: 0x0004B7F4
	public List<GClass102> method_47()
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
				array = this.method_50(GClass127.smethod_32(this.string_25[i]));
				if (array.Length != 4)
				{
					array = this.method_50(GClass127.smethod_32(this.string_25[i]));
				}
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

	// Token: 0x06000312 RID: 786 RVA: 0x0004D7B8 File Offset: 0x0004B9B8
	public List<GClass102> method_48()
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
				array = this.method_50(GClass127.smethod_32(this.string_24[i]));
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

	// Token: 0x06000313 RID: 787 RVA: 0x0004D984 File Offset: 0x0004BB84
	public override List<GClass102> r1()
	{
		if (this.string_0 == "ABG22")
		{
			return this.method_48();
		}
		if (this.string_0 == "ABG23")
		{
			return this.method_47();
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
				array = this.method_50(GClass127.smethod_32(this.string_23[i]));
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

	// Token: 0x06000314 RID: 788 RVA: 0x0004DB84 File Offset: 0x0004BD84
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
			this.method_50(GClass127.smethod_32("07 00 FF 02 FD"));
			this.method_50(GClass127.smethod_32("01 01 03"));
			this.bool_2 = true;
			if (!this.method_45())
			{
				this.bool_2 = false;
				GClass126.smethod_2("Terminate 5a", 1);
				base.method_30(true);
			}
			this.bool_2 = false;
			this.method_50(GClass127.smethod_32("04 02 FD 02 FD 00 FF"));
			this.method_50(GClass127.smethod_32("04 02 FD 09 F6 00 FF"));
			this.method_50(GClass127.smethod_32("04 02 FD 19 E6 00 FF"));
			this.method_50(GClass127.smethod_32("04 02 FD 0B F4 00 FF"));
			this.method_50(GClass127.smethod_32("04 02 FD 1F E0 AA 55"));
			Thread.Sleep(1000);
			return;
		}
		byte[] array = this.method_50(this.byte_5);
		if (array.Length < 4 || array[3] != 170)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x06000315 RID: 789 RVA: 0x0004DCF8 File Offset: 0x0004BEF8
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
		this.method_49(gclass104_1);
	}

	// Token: 0x06000316 RID: 790 RVA: 0x0004DD48 File Offset: 0x0004BF48
	private void method_49(GClass104 gclass104_1)
	{
		this.method_50(gclass104_1.byte_0[0]);
		for (int i = 0; i < 100; i++)
		{
			if (!GClass126.bool_25)
			{
				Thread.Sleep(100);
			}
		}
		base.method_28(false, GClass121.smethod_6("6051"), "");
	}

	// Token: 0x06000317 RID: 791 RVA: 0x0004DD98 File Offset: 0x0004BF98
	public override string vmethod_0(byte[] byte_7, string string_32, int int_13, int int_14, string[] string_33, string string_34)
	{
		byte[] array = this.method_50(byte_7);
		if (array.Length == 0)
		{
			array = this.method_50(byte_7);
		}
		return this.r4(array, string_32, int_13, int_14, string_33, string_34);
	}

	// Token: 0x06000318 RID: 792 RVA: 0x0004DDC8 File Offset: 0x0004BFC8
	private byte[] method_50(byte[] byte_7)
	{
		byte[] result = new byte[0];
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			result = this.method_51(byte_7);
		}
		finally
		{
			this.bool_2 = false;
		}
		return result;
	}

	// Token: 0x06000319 RID: 793 RVA: 0x0004DE18 File Offset: 0x0004C018
	private byte[] method_51(byte[] byte_7)
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
			byte int_ = byte_7[0];
			for (int i = 1; i < byte_7.Length; i++)
			{
				text += this.method_53(byte_7[i]);
			}
			GClass126.smethod_2(text, 0);
			text = "";
			byte[] array = this.method_54((int)int_);
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
						this.serialPort_0.ReadTimeout = 400;
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

	// Token: 0x0600031A RID: 794 RVA: 0x00010BD0 File Offset: 0x0000EDD0
	private byte method_52(byte[] byte_7)
	{
		byte b = 0;
		for (int i = 0; i < byte_7.Length; i++)
		{
			b += byte_7[i];
		}
		return b;
	}

	// Token: 0x0600031B RID: 795 RVA: 0x000325E4 File Offset: 0x000307E4
	public override string r4(byte[] byte_7, string string_32, int int_13, int int_14, string[] string_33, string string_34)
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
		return base.method_33(array, string_32, string_33, string_34);
	}

	// Token: 0x0600031C RID: 796 RVA: 0x0004DF8C File Offset: 0x0004C18C
	private string method_53(byte byte_7)
	{
		while (GClass126.smethod_1() < this.int_0 + this.int_8)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_7
		}, 0, 1);
		this.int_0 = GClass126.smethod_1();
		string text = this.string_26 + this.int_0.ToString() + this.string_27 + GClass127.smethod_23(byte_7);
		byte b = (byte)this.serialPort_0.ReadByte();
		int num = GClass126.smethod_1() - this.int_0;
		this.int_0 += num / 3;
		if (num > 15)
		{
			this.int_3 = 25;
		}
		if (byte_7 != b)
		{
			text = string.Concat(new string[]
			{
				text,
				this.string_26,
				this.int_0.ToString(),
				this.string_29,
				GClass127.smethod_23(b)
			});
			throw new Exception(this.string_30);
		}
		return text;
	}

	// Token: 0x0600031D RID: 797 RVA: 0x0004E07C File Offset: 0x0004C27C
	private byte[] method_54(int int_13)
	{
		byte[] array = new byte[int_13];
		if (int_13 == 0)
		{
			return array;
		}
		int num = 0;
		try
		{
			for (int i = 0; i < int_13; i++)
			{
				array[i] = (byte)this.serialPort_0.ReadByte();
				num++;
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2("Less bytes received [" + num.ToString() + "]", 0);
			if (num == 0)
			{
				throw ex;
			}
		}
		this.int_0 = GClass126.smethod_1();
		GClass126.smethod_2(this.string_31 + GClass127.smethod_11(array), 0);
		return array;
	}

	// Token: 0x0600031E RID: 798 RVA: 0x0004E110 File Offset: 0x0004C310
	private void method_55()
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

	// Token: 0x0600031F RID: 799 RVA: 0x0004E428 File Offset: 0x0004C628
	private void method_56()
	{
		GClass126.smethod_2("KA started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(10);
			if (this.serialPort_0 == null || !this.serialPort_0.IsOpen)
			{
				GClass126.smethod_2("KA stopped(1)", 1);
				return;
			}
			if (GClass126.smethod_1() > this.int_0 + this.int_11 && !this.bool_2)
			{
				byte[] array = this.method_50(this.byte_3);
				if (array.Length < 4 || array[0] != 0)
				{
					array = this.method_50(this.byte_3);
					if (array.Length < 4 || array[0] != 0)
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

	// Token: 0x04000207 RID: 519
	private int int_5 = 2000;

	// Token: 0x04000208 RID: 520
	private int int_6 = 3;

	// Token: 0x04000209 RID: 521
	private int int_7 = 1000;

	// Token: 0x0400020A RID: 522
	private int int_8 = 5;

	// Token: 0x0400020B RID: 523
	private int int_9 = 41;

	// Token: 0x0400020C RID: 524
	private int int_10 = 9;

	// Token: 0x0400020D RID: 525
	private int int_11 = 180;

	// Token: 0x0400020E RID: 526
	private byte[] byte_3 = new byte[]
	{
		4,
		3,
		252,
		0,
		byte.MaxValue
	};

	// Token: 0x0400020F RID: 527
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

	// Token: 0x04000210 RID: 528
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

	// Token: 0x04000211 RID: 529
	private string[] string_24 = new string[]
	{
		"04 03 FC 00 FF",
		"04 03 FC 01 FE",
		"04 03 FC 02 FD",
		"04 03 FC 04 FB",
		"04 03 FC 05 FA",
		"04 03 FC 06 F9"
	};

	// Token: 0x04000212 RID: 530
	private string[] string_25 = new string[]
	{
		"04 03 FC 02 FD",
		"04 03 FC 0B F4"
	};

	// Token: 0x04000213 RID: 531
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

	// Token: 0x04000214 RID: 532
	private byte[] byte_5 = new byte[]
	{
		4,
		4,
		251,
		4,
		251
	};

	// Token: 0x04000215 RID: 533
	private int int_12;

	// Token: 0x04000216 RID: 534
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

	// Token: 0x04000217 RID: 535
	private string string_26 = " <";

	// Token: 0x04000218 RID: 536
	private string string_27 = "> Sent: ";

	// Token: 0x04000219 RID: 537
	private string string_28 = " <";

	// Token: 0x0400021A RID: 538
	private string string_29 = "> ERROR: Invalid echo: ";

	// Token: 0x0400021B RID: 539
	private string string_30 = "Invalid echo!";

	// Token: 0x0400021C RID: 540
	private string string_31 = "Received: ";
}
