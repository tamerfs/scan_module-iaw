using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

// Token: 0x0200006F RID: 111
public sealed class GClass51 : GClass19
{
	// Token: 0x0600037E RID: 894 RVA: 0x00074AC4 File Offset: 0x00072CC4
	public GClass51(byte byte_6, List<GClass58> list_4, List<GClass58> list_5)
	{
		this.byte_0 = byte_6;
		this.list_0 = list_5;
		this.list_1 = list_4;
	}

	// Token: 0x0600037F RID: 895 RVA: 0x00074CF4 File Offset: 0x00072EF4
	public override void vmethod_1(GEnum0 genum0_0)
	{
		try
		{
			this.int_1 = 0;
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
				new Thread(new ThreadStart(this.method_42))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				base.method_28();
				throw new Exception("1");
			}
			if (GClass61.smethod_36() == 4 || GClass61.smethod_36() == 5)
			{
				if (GClass61.smethod_36() == 5)
				{
					for (int i = 0; i < 25; i++)
					{
						if (GClass3.bool_14)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
				}
				GClass55.smethod_0();
				Thread.Sleep(500);
				if (GClass61.smethod_36() == 5)
				{
					for (int i = 0; i < 35; i++)
					{
						if (GClass3.bool_14)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
				}
			}
			try
			{
				this.serialPort_0 = new SerialPort(GClass61.smethod_39(), 1200, Parity.None, 8, StopBits.One);
				this.serialPort_0.WriteBufferSize = 2;
				this.serialPort_0.ReceivedBytesThreshold = 1000;
				this.serialPort_0.Handshake = Handshake.None;
				this.serialPort_0.Open();
				GClass3.smethod_2("Serial port opened!", 1);
			}
			catch (Exception ex)
			{
				this.string_4 = ex.Message;
				GClass3.smethod_2(ex.Message, 1);
				throw new Exception("0");
			}
			if (GClass3.bool_14)
			{
				throw new Exception("ESC");
			}
			int j = 3;
			if (genum0_0 != (GEnum0)0)
			{
				j = 1;
			}
			while (j > 0)
			{
				try
				{
					BitArray bitArray = new BitArray(new byte[]
					{
						this.byte_0
					});
					this.int_0 = GClass3.smethod_1();
					this.serialPort_0.ReadTimeout = 1;
					GClass3.smethod_2("5bps wake up start (" + GClass16.smethod_0(this.byte_0) + ")...", 1);
					for (int i = -1; i < bitArray.Length; i++)
					{
						if (i == -1)
						{
							this.serialPort_0.RtsEnable = true;
							this.serialPort_0.BreakState = true;
						}
						else
						{
							this.serialPort_0.RtsEnable = !bitArray[i];
							this.serialPort_0.BreakState = !bitArray[i];
						}
						while (this.int_0 + 130 > GClass3.smethod_1())
						{
							Thread.Sleep(10);
						}
						while (this.int_0 + 200 > GClass3.smethod_1())
						{
						}
						this.int_0 = GClass3.smethod_1();
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
					this.int_0 = GClass3.smethod_1();
					GClass3.smethod_2("Waiting ECU response...", 1);
					byte b = (byte)this.serialPort_0.ReadByte();
					GClass3.smethod_2("Sync: " + GClass16.smethod_0(b), 0);
					byte b2 = 0 + b;
					if (b != 85)
					{
						GClass3.smethod_2("ERROR: Invalid synchronization byte", 1);
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
					byte b7 = (byte)this.serialPort_0.ReadByte();
					byte b8 = b7;
					b7 &= 127;
					b2 &= 127;
					if (b7 != b2)
					{
						GClass3.smethod_2("ERROR: Invalid checksum", 1);
						throw new Exception("Invalid checksum");
					}
					this.string_3 = GClass16.smethod_1(new byte[]
					{
						b3,
						b4,
						b5,
						b6,
						b8
					});
					GClass3.smethod_2("ECU ISO Code: " + this.string_3, 2);
					this.int_0 = GClass3.smethod_1();
					this.serialPort_0.ReadTimeout = 400;
					j = 0;
				}
				catch (Exception)
				{
					this.serialPort_0.BreakState = false;
					j--;
					if (j == 0)
					{
						throw new Exception("1");
					}
					if (GClass3.bool_14)
					{
						throw new Exception("ESC");
					}
					for (int i = 0; i < 25; i++)
					{
						if (GClass3.bool_14)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
				}
			}
			GClass3.smethod_2("ECU wakeup completed", 1);
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
				Thread thread = new Thread(new ThreadStart(this.method_43));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_42))
				{
					Priority = ThreadPriority.Highest
				}.Start();
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
				this.bool_0 = true;
				base.method_28();
			}
		}
		catch (Exception ex2)
		{
			if (ex2.Message == "ESC")
			{
				this.string_4 = "Aborted by user";
			}
			if (ex2.Message == "1")
			{
				this.string_4 = "No ECU response";
			}
			GClass3.smethod_2(ex2.Message, 2);
			GClass3.smethod_2("Terminate 4", 1);
			base.method_22(ex2.Message != "1" && ex2.Message != "0" && ex2.Message != "ESC");
		}
	}

	// Token: 0x06000380 RID: 896 RVA: 0x00003324 File Offset: 0x00001524
	private bool method_33()
	{
		return this.method_34();
	}

	// Token: 0x06000381 RID: 897 RVA: 0x00075508 File Offset: 0x00073708
	private bool method_34()
	{
		this.int_12++;
		bool result;
		if (this.int_12 > 5)
		{
			result = false;
		}
		else
		{
			for (int i = 0; i < 18; i++)
			{
				if (this.bool_1)
				{
					return false;
				}
				Thread.Sleep(100);
			}
			try
			{
				BitArray bitArray = new BitArray(new byte[]
				{
					this.byte_0
				});
				this.int_0 = GClass3.smethod_1();
				this.serialPort_0.ReadTimeout = 1;
				GClass3.smethod_2("5bps wake up start (" + GClass16.smethod_0(this.byte_0) + ")...", 1);
				for (int i = -1; i < bitArray.Length; i++)
				{
					if (i == -1)
					{
						this.serialPort_0.RtsEnable = true;
						this.serialPort_0.BreakState = true;
					}
					else
					{
						this.serialPort_0.RtsEnable = !bitArray[i];
						this.serialPort_0.BreakState = !bitArray[i];
					}
					while (this.int_0 + 130 > GClass3.smethod_1())
					{
						Thread.Sleep(10);
					}
					while (this.int_0 + 200 > GClass3.smethod_1())
					{
					}
					this.int_0 = GClass3.smethod_1();
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
				this.int_0 = GClass3.smethod_1();
				GClass3.smethod_2("Waiting ECU response...", 1);
				byte b = (byte)this.serialPort_0.ReadByte();
				byte b2 = 0 + b;
				if (b != 85)
				{
					GClass3.smethod_2("ERROR: Invalid synchronization byte", 1);
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
				byte b7 = (byte)this.serialPort_0.ReadByte();
				byte b8 = b7;
				b7 &= 127;
				b2 &= 127;
				if (b7 != b2)
				{
					GClass3.smethod_2("ERROR: Invalid checksum", 1);
					throw new Exception("Invalid checksum");
				}
				this.string_3 = GClass16.smethod_1(new byte[]
				{
					b3,
					b4,
					b5,
					b6,
					b8
				});
				this.serialPort_0.ReadTimeout = 400;
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
				return false;
			}
			result = true;
		}
		return result;
	}

	// Token: 0x06000382 RID: 898 RVA: 0x00051ED8 File Offset: 0x000500D8
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

	// Token: 0x06000383 RID: 899 RVA: 0x00075818 File Offset: 0x00073A18
	public List<GClass64> method_35()
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

	// Token: 0x06000384 RID: 900 RVA: 0x00075A10 File Offset: 0x00073C10
	public override List<GClass64> vmethod_3()
	{
		List<GClass64> result;
		if (this.string_0 == "ABG22")
		{
			result = this.method_35();
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

	// Token: 0x06000385 RID: 901 RVA: 0x00075C2C File Offset: 0x00073E2C
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

	// Token: 0x06000386 RID: 902 RVA: 0x0000332C File Offset: 0x0000152C
	protected override void vmethod_6(GClass58 gclass58_1)
	{
		if (GClass3.bool_0)
		{
			Thread.Sleep(3000);
			base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
		}
		else
		{
			this.method_36(gclass58_1);
		}
	}

	// Token: 0x06000387 RID: 903 RVA: 0x00075CE4 File Offset: 0x00073EE4
	private void method_36(GClass58 gclass58_1)
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

	// Token: 0x06000388 RID: 904 RVA: 0x00075D34 File Offset: 0x00073F34
	public override string vmethod_0(byte[] byte_6, string string_16, int int_13, int int_14, string[] string_17, string string_18)
	{
		byte[] array = this.method_37(byte_6);
		if (array.Length == 0)
		{
			array = this.method_37(byte_6);
		}
		return this.vmethod_7(array, string_16, int_13, int_14, string_17, string_18);
	}

	// Token: 0x06000389 RID: 905 RVA: 0x00075D70 File Offset: 0x00073F70
	private byte[] method_37(byte[] byte_6)
	{
		byte[] result = new byte[0];
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			result = this.method_38(byte_6);
		}
		finally
		{
			this.bool_2 = false;
		}
		return result;
	}

	// Token: 0x0600038A RID: 906 RVA: 0x00075DC4 File Offset: 0x00073FC4
	private byte[] method_38(byte[] byte_6)
	{
		string text = string.Empty;
		byte[] result;
		try
		{
			while (GClass3.smethod_1() < this.int_0 + this.int_10)
			{
				Thread.Sleep(1);
			}
			this.serialPort_0.ReadExisting();
			byte int_ = byte_6[0];
			for (int i = 1; i < byte_6.Length; i++)
			{
				text += this.method_40(byte_6[i]);
			}
			GClass3.smethod_2(text, 0);
			text = string.Empty;
			byte[] array = this.method_41((int)int_);
			this.int_1 = 0;
			result = array;
		}
		catch (Exception ex)
		{
			if (!this.bool_1)
			{
				if (text != string.Empty)
				{
					GClass3.smethod_2(text, 0);
				}
				GClass3.smethod_2(ex.Message + "(3)", 1);
				if (this.int_1 > 1)
				{
					if (!this.method_33())
					{
						this.bool_2 = false;
						GClass3.smethod_2("Terminate 5", 1);
						base.method_22(true);
					}
					else
					{
						this.int_1 = 2;
					}
				}
				else
				{
					this.int_1++;
					this.serialPort_0.ReadTimeout = 100;
					try
					{
						for (int i = 0; i < 10; i++)
						{
							byte b = (byte)this.serialPort_0.ReadByte();
						}
					}
					catch (Exception)
					{
					}
					this.serialPort_0.ReadTimeout = 400;
				}
			}
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x0600038B RID: 907 RVA: 0x00020014 File Offset: 0x0001E214
	private byte method_39(byte[] byte_6)
	{
		byte b = 0;
		for (int i = 0; i < byte_6.Length; i++)
		{
			b += byte_6[i];
		}
		return b;
	}

	// Token: 0x0600038C RID: 908 RVA: 0x00035A9C File Offset: 0x00033C9C
	public override string vmethod_7(byte[] byte_6, string string_16, int int_13, int int_14, string[] string_17, string string_18)
	{
		string text = string.Empty;
		int_13++;
		string result;
		if (byte_6.Length <= int_13)
		{
			result = text;
		}
		else
		{
			int num = byte_6.Length - int_13;
			if (int_14 < num)
			{
				num = int_14;
			}
			byte[] array = new byte[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = byte_6[i + int_13];
			}
			text = base.method_32(array, string_16, string_17, string_18);
			result = text;
		}
		return result;
	}

	// Token: 0x0600038D RID: 909 RVA: 0x00075F34 File Offset: 0x00074134
	private string method_40(byte byte_6)
	{
		string text = string.Empty;
		while (GClass3.smethod_1() < this.int_0 + this.int_8)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_6
		}, 0, 1);
		this.int_0 = GClass3.smethod_1();
		text = string.Concat(new object[]
		{
			this.string_10,
			this.int_0,
			this.string_11,
			GClass16.smethod_0(byte_6)
		});
		byte b = (byte)this.serialPort_0.ReadByte();
		int num = GClass3.smethod_1() - this.int_0;
		this.int_0 += num / 3;
		if (num > 15)
		{
			this.int_3 = 25;
		}
		if (byte_6 != b)
		{
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				this.string_10,
				this.int_0,
				this.string_13,
				GClass16.smethod_0(b)
			});
			throw new Exception(this.string_14);
		}
		return text;
	}

	// Token: 0x0600038E RID: 910 RVA: 0x00076050 File Offset: 0x00074250
	private byte[] method_41(int int_13)
	{
		byte[] array = new byte[int_13];
		byte[] result;
		if (int_13 == 0)
		{
			result = array;
		}
		else
		{
			for (int i = 0; i < int_13; i++)
			{
				array[i] = (byte)this.serialPort_0.ReadByte();
			}
			this.int_0 = GClass3.smethod_1();
			GClass3.smethod_2(this.string_15 + GClass16.smethod_1(array), 0);
			result = array;
		}
		return result;
	}

	// Token: 0x0600038F RID: 911 RVA: 0x000760B4 File Offset: 0x000742B4
	private void method_42()
	{
		GClass3.smethod_2("PM started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(60);
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

	// Token: 0x06000390 RID: 912 RVA: 0x000763D0 File Offset: 0x000745D0
	private void method_43()
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
					array = this.method_37(this.byte_2);
					if (array.Length < 4 || array[0] != 0)
					{
						GClass3.smethod_2("KA response error!", 1);
						if (array.Length == 0 && this.int_1 > 2)
						{
							GClass3.smethod_2("Terminate 7", 1);
							base.method_22(true);
						}
					}
				}
			}
		}
		GClass3.smethod_2("KA stopped", 1);
	}

	// Token: 0x04000505 RID: 1285
	private int int_5 = 2000;

	// Token: 0x04000506 RID: 1286
	private int int_6 = 3;

	// Token: 0x04000507 RID: 1287
	private int int_7 = 1000;

	// Token: 0x04000508 RID: 1288
	private int int_8 = 3;

	// Token: 0x04000509 RID: 1289
	private int int_9 = 41;

	// Token: 0x0400050A RID: 1290
	private int int_10 = 3;

	// Token: 0x0400050B RID: 1291
	private int int_11 = 400;

	// Token: 0x0400050C RID: 1292
	private byte[] byte_2 = new byte[]
	{
		4,
		3,
		252,
		0,
		byte.MaxValue
	};

	// Token: 0x0400050D RID: 1293
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

	// Token: 0x0400050E RID: 1294
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

	// Token: 0x0400050F RID: 1295
	private string[] string_9 = new string[]
	{
		"04 03 FC 00 FF",
		"04 03 FC 01 FE",
		"04 03 FC 02 FD",
		"04 03 FC 04 FB",
		"04 03 FC 05 FA",
		"04 03 FC 06 F9"
	};

	// Token: 0x04000510 RID: 1296
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

	// Token: 0x04000511 RID: 1297
	private byte[] byte_4 = new byte[]
	{
		4,
		4,
		251,
		4,
		251
	};

	// Token: 0x04000512 RID: 1298
	private int int_12 = 0;

	// Token: 0x04000513 RID: 1299
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

	// Token: 0x04000514 RID: 1300
	private string string_10 = " <";

	// Token: 0x04000515 RID: 1301
	private string string_11 = "> Sent: ";

	// Token: 0x04000516 RID: 1302
	private string string_12 = " <";

	// Token: 0x04000517 RID: 1303
	private string string_13 = "> ERROR: Invalid echo: ";

	// Token: 0x04000518 RID: 1304
	private string string_14 = "Invalid echo!";

	// Token: 0x04000519 RID: 1305
	private string string_15 = "Received: ";
}
