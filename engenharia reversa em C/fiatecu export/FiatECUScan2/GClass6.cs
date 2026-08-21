using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

// Token: 0x02000012 RID: 18
public sealed class GClass6 : GClass4
{
	// Token: 0x06000080 RID: 128 RVA: 0x0001E230 File Offset: 0x0001C430
	public GClass6(byte byte_9, List<GClass58> list_3, List<GClass58> list_4)
	{
		this.byte_0 = byte_9;
		this.list_0 = list_4;
		this.list_1 = list_3;
	}

	// Token: 0x06000081 RID: 129 RVA: 0x0001E524 File Offset: 0x0001C724
	public override void vmethod_1(FormNotify formNotify_0, bool bool_5)
	{
		try
		{
			this.int_1 = 0;
			if (!bool_5)
			{
				for (int i = 0; i < 5; i++)
				{
					if (formNotify_0 != null && formNotify_0.method_0())
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
				Thread.Sleep(2000);
				GClass3.smethod_2("Testing mode!", 1);
				this.string_1 = "26 86 9B 02 9E";
				for (int i = 0; i < this.list_1.Count; i++)
				{
					GClass58 gclass = this.list_1[i];
					if (gclass.byte_0[0][0] == 0)
					{
						gclass.method_1(this.string_1);
					}
					else
					{
						gclass.method_1(this.vmethod_6(array[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					}
				}
				this.bool_1 = false;
				this.bool_0 = true;
				new Thread(new ThreadStart(this.method_44))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				base.method_26();
				throw new Exception("1");
			}
			if (GClass61.smethod_36() == 4 || GClass61.smethod_36() == 5)
			{
				if (GClass61.smethod_36() == 5)
				{
					for (int i = 0; i < 25; i++)
					{
						if (formNotify_0 != null && formNotify_0.method_0())
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
						if (formNotify_0 != null && formNotify_0.method_0())
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
				}
			}
			try
			{
				this.serialPort_0 = new SerialPort(GClass61.smethod_39(), 4800, Parity.None, 8, StopBits.One);
				this.serialPort_0.WriteBufferSize = 2;
				this.serialPort_0.ReceivedBytesThreshold = 1000;
				this.serialPort_0.Handshake = Handshake.None;
				this.serialPort_0.Open();
				GClass3.smethod_2("Serial port opened!", 1);
			}
			catch (Exception ex)
			{
				this.string_2 = ex.Message;
				GClass3.smethod_2(ex.Message, 1);
				throw new Exception("0");
			}
			if (formNotify_0 != null && formNotify_0.method_0())
			{
				throw new Exception("ESC");
			}
			int j = 4;
			if (bool_5)
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
					this.string_1 = GClass16.smethod_1(new byte[]
					{
						b3,
						b4,
						b5,
						b6,
						b8
					});
					GClass3.smethod_2("ECU ISO Code: " + this.string_1, 2);
					byte b9 = b4;
					b9 ^= byte.MaxValue;
					this.int_0 = GClass3.smethod_1();
					GClass3.smethod_2(this.method_40(b9), 0);
					if (j == 1)
					{
						byte byte_ = (byte)this.serialPort_0.ReadByte();
						GClass3.smethod_2("Response: " + GClass16.smethod_0(byte_), 0);
					}
					else
					{
						this.method_43();
					}
					this.serialPort_0.ReadTimeout = 350;
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
					if (formNotify_0 != null && formNotify_0.method_0())
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(2500);
				}
			}
			GClass3.smethod_2("ECU wakeup completed", 1);
			if (bool_5)
			{
				base.method_21(false);
			}
			else
			{
				if (formNotify_0 != null && formNotify_0.method_0())
				{
					throw new Exception("ESC");
				}
				Thread thread = new Thread(new ThreadStart(this.method_45));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_44))
				{
					Priority = ThreadPriority.Highest
				}.Start();
				for (int i = 0; i < this.list_1.Count; i++)
				{
					GClass58 gclass = this.list_1[i];
					if (gclass.byte_0[0][0] == 0)
					{
						gclass.method_1(this.string_1);
					}
					else
					{
						gclass.method_1(this.vmethod_0(gclass.byte_0[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					}
				}
				this.bool_0 = true;
				base.method_26();
			}
		}
		catch (Exception ex2)
		{
			if (ex2.Message == "ESC")
			{
				this.string_2 = "Aborted by user";
			}
			if (ex2.Message == "1")
			{
				this.string_2 = "No ECU response";
			}
			GClass3.smethod_2(ex2.Message, 2);
			GClass3.smethod_2("Terminate 4", 1);
			base.method_21(ex2.Message != "1" && ex2.Message != "0" && ex2.Message != "ESC");
		}
	}

	// Token: 0x06000082 RID: 130 RVA: 0x000028EA File Offset: 0x00000AEA
	private bool method_31()
	{
		return this.method_32();
	}

	// Token: 0x06000083 RID: 131 RVA: 0x0001ED38 File Offset: 0x0001CF38
	private bool method_32()
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
				this.string_1 = GClass16.smethod_1(new byte[]
				{
					b3,
					b4,
					b5,
					b6,
					b8
				});
				byte b9 = b4;
				b9 ^= byte.MaxValue;
				this.int_0 = GClass3.smethod_1();
				GClass3.smethod_2(this.method_40(b9), 0);
				this.method_43();
				this.serialPort_0.ReadTimeout = 350;
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

	// Token: 0x06000084 RID: 132 RVA: 0x0001F078 File Offset: 0x0001D278
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
				base.method_27(bool_6);
			}
		}
	}

	// Token: 0x06000085 RID: 133 RVA: 0x0001F154 File Offset: 0x0001D354
	public List<GClass64> method_33()
	{
		List<GClass64> list = new List<GClass64>();
		byte[] array;
		if (GClass3.bool_0)
		{
			array = this.byte_4;
		}
		else
		{
			array = this.method_37(this.byte_6);
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
					if ((array[2 + i] & this.byte_8[j]) != 0 || (array[10 + i] & this.byte_8[j]) != 0)
					{
						try
						{
							GClass64 gclass = new GClass64();
							byte byte_ = (byte)(i * 8 + (j + 1));
							gclass.string_0 = GClass16.smethod_0(byte_);
							gclass.byte_0 = (((array[10 + i] & this.byte_8[j]) != 0) ? 1 : 0);
							GClass64 gclass2 = gclass;
							gclass2.byte_0 += (((array[2 + i] & this.byte_8[j]) != 0) ? 10 : 0);
							gclass.byte_1 = 32;
							gclass.string_4 = string.Empty;
							gclass.string_5 = string.Empty;
							gclass.string_6 = string.Empty;
							gclass.string_1 = string.Empty;
							string text = string.Empty;
							if (gclass.byte_0 == 1)
							{
								text = GClass62.smethod_1("3062");
							}
							else if (gclass.byte_0 == 10)
							{
								text = GClass62.smethod_1("3053");
							}
							else if (gclass.byte_0 == 11)
							{
								text = GClass62.smethod_1("3062") + "/" + GClass62.smethod_1("3053");
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
							gclass.string_5 = text;
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

	// Token: 0x06000086 RID: 134 RVA: 0x0001F3D0 File Offset: 0x0001D5D0
	public List<GClass64> method_34()
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
				array = this.method_37(this.byte_6);
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
					if ((int)(gclass.byte_0 & 31) < this.string_5.Length)
					{
						text = this.string_5[(int)(gclass.byte_0 & 31)];
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

	// Token: 0x06000087 RID: 135 RVA: 0x0001F798 File Offset: 0x0001D998
	public override List<GClass64> vmethod_3()
	{
		List<GClass64> result;
		if (this.string_0 == "ABSTEVES")
		{
			result = this.method_33();
		}
		else if (this.string_0 == "HTCHI")
		{
			result = this.method_34();
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
				array = this.method_37(this.byte_6);
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
						if ((int)(gclass.byte_0 & 31) < this.string_5.Length)
						{
							text = this.string_5[(int)(gclass.byte_0 & 31)];
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
						goto IL_369;
					}
					catch (Exception)
					{
						GClass3.smethod_2("ERROR: Exception while reading error codes.", 0);
						goto IL_369;
					}
					IL_360:
					i++;
					continue;
					IL_369:
					i += 5;
					if (this.string_0 == "TD100")
					{
						goto IL_360;
					}
				}
				result = list;
			}
		}
		return result;
	}

	// Token: 0x06000088 RID: 136 RVA: 0x00018938 File Offset: 0x00016B38
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

	// Token: 0x06000089 RID: 137 RVA: 0x0001FB4C File Offset: 0x0001DD4C
	public override void vmethod_4()
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
			byte[] array = this.method_37(this.byte_7);
			if (array.Length < 2 || array[1] != 9)
			{
				GClass3.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
	}

	// Token: 0x0600008A RID: 138 RVA: 0x0001FBAC File Offset: 0x0001DDAC
	protected override void vmethod_5(GClass58 gclass58_1)
	{
		if (GClass3.bool_0)
		{
			Thread.Sleep(3000);
			if (gclass58_1.string_2.Contains("FUNC"))
			{
				base.method_29(true, GClass62.smethod_1("6051"), GClass62.smethod_1("6055") + " 00");
			}
			else
			{
				base.method_29(false, GClass62.smethod_1("6051"), string.Empty);
			}
		}
		else
		{
			this.method_36(gclass58_1);
		}
	}

	// Token: 0x0600008B RID: 139 RVA: 0x0001FC28 File Offset: 0x0001DE28
	private void method_36(GClass58 gclass58_1)
	{
		byte[] array = this.method_37(gclass58_1.byte_0[0]);
		if (array.Length == 0 || (array.Length > 1 && array[1] != 9))
		{
			string empty = string.Empty;
			base.method_29(false, GClass62.smethod_1("6052"), empty);
			Thread.Sleep(1800);
		}
		else
		{
			if (gclass58_1.byte_0.Length > 2)
			{
				for (int i = 1; i < gclass58_1.byte_0.Length; i++)
				{
					Thread.Sleep(2000);
					this.method_37(gclass58_1.byte_0[i]);
				}
			}
			else if (gclass58_1.byte_0.Length == 2)
			{
				for (int i = 1; i < gclass58_1.byte_0.Length; i++)
				{
					Thread.Sleep(6000);
					Thread.Sleep(2000);
					this.method_37(gclass58_1.byte_0[i]);
				}
			}
			else
			{
				Thread.Sleep(9000);
			}
			base.method_29(false, GClass62.smethod_1("6051"), string.Empty);
		}
	}

	// Token: 0x0600008C RID: 140 RVA: 0x0001FD30 File Offset: 0x0001DF30
	public override string vmethod_0(byte[] byte_9, string string_12, int int_13, int int_14, string[] string_13, string string_14)
	{
		byte[] array = this.method_37(byte_9);
		if (array.Length == 0)
		{
			array = this.method_37(byte_9);
		}
		return this.vmethod_6(array, string_12, int_13, int_14, string_13, string_14);
	}

	// Token: 0x0600008D RID: 141 RVA: 0x0001FD6C File Offset: 0x0001DF6C
	private byte[] method_37(byte[] byte_9)
	{
		List<byte> list = new List<byte>();
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			byte[] array = this.method_38(byte_9);
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i]);
			}
			int num = 10;
			while (array.Length > 0 && array[1] != 9 && num > 0)
			{
				array = this.method_38(this.byte_2);
				if (array.Length > 2)
				{
					for (int i = 2; i < array.Length; i++)
					{
						list.Add(array[i]);
					}
				}
				num--;
			}
			if (array.Length == 0)
			{
				array = this.method_38(this.byte_2);
				list.Clear();
			}
		}
		finally
		{
			this.bool_2 = false;
		}
		return list.ToArray();
	}

	// Token: 0x0600008E RID: 142 RVA: 0x0001FE50 File Offset: 0x0001E050
	private byte[] method_38(byte[] byte_9)
	{
		string text = string.Empty;
		byte[] result;
		try
		{
			byte b = 0;
			while (GClass3.smethod_1() < this.int_0 + this.int_10)
			{
				Thread.Sleep(1);
			}
			this.serialPort_0.ReadExisting();
			byte b2 = byte_9[0];
			text = this.method_41(b2);
			b += b2;
			byte[] array = new byte[byte_9.Length + 1];
			array[0] = byte_9[0];
			for (int i = 1; i < byte_9.Length; i++)
			{
				text += this.method_41(byte_9[i]);
				b += byte_9[i];
				array[i] = byte_9[i];
			}
			text += this.method_41(b);
			array[byte_9.Length] = b;
			GClass3.smethod_2(text, 0);
			text = string.Empty;
			this.method_42(array);
			byte[] array2 = this.method_43();
			this.int_1 = 0;
			result = array2;
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
					if (!this.method_31())
					{
						this.bool_2 = false;
						GClass3.smethod_2("Terminate 5", 1);
						base.method_21(true);
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
						for (int i = 0; i < 20; i++)
						{
							byte b3 = (byte)this.serialPort_0.ReadByte();
						}
					}
					catch (Exception)
					{
					}
					this.serialPort_0.ReadTimeout = 350;
				}
			}
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00020014 File Offset: 0x0001E214
	private byte method_39(byte[] byte_9)
	{
		byte b = 0;
		for (int i = 0; i < byte_9.Length; i++)
		{
			b += byte_9[i];
		}
		return b;
	}

	// Token: 0x06000090 RID: 144 RVA: 0x00020040 File Offset: 0x0001E240
	public override string vmethod_6(byte[] byte_9, string string_12, int int_13, int int_14, string[] string_13, string string_14)
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
			text = base.method_30(array, string_12, string_13, string_14);
			result = text;
		}
		return result;
	}

	// Token: 0x06000091 RID: 145 RVA: 0x000200AC File Offset: 0x0001E2AC
	private string method_40(byte byte_9)
	{
		string text = string.Empty;
		while (GClass3.smethod_1() < this.int_0 + this.int_8)
		{
		}
		this.serialPort_0.Write(new byte[]
		{
			byte_9
		}, 0, 1);
		this.int_0 = GClass3.smethod_1();
		text = string.Concat(new object[]
		{
			this.string_6,
			this.int_0,
			this.string_7,
			GClass16.smethod_0(byte_9)
		});
		byte b = (byte)this.serialPort_0.ReadByte();
		int num = GClass3.smethod_1() - this.int_0;
		this.int_0 += num / 3;
		if (num > 15)
		{
			this.int_3 = 25;
		}
		if (byte_9 != b)
		{
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				this.string_6,
				this.int_0,
				this.string_9,
				GClass16.smethod_0(b)
			});
			throw new Exception(this.string_10);
		}
		return text;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x000201C8 File Offset: 0x0001E3C8
	private string method_41(byte byte_9)
	{
		string result;
		if (!GClass61.smethod_49())
		{
			result = this.method_40(byte_9);
		}
		else
		{
			while (GClass3.smethod_1() < this.int_0 + this.int_8)
			{
			}
			this.serialPort_0.Write(new byte[]
			{
				byte_9
			}, 0, 1);
			this.int_0 = GClass3.smethod_1() + 1;
			result = string.Concat(new object[]
			{
				this.string_6,
				this.int_0,
				this.string_7,
				GClass16.smethod_0(byte_9)
			});
		}
		return result;
	}

	// Token: 0x06000093 RID: 147 RVA: 0x0002025C File Offset: 0x0001E45C
	private void method_42(byte[] byte_9)
	{
		if (GClass61.smethod_49())
		{
			bool flag = true;
			for (int i = 0; i < byte_9.Length; i++)
			{
				byte b = (byte)this.serialPort_0.ReadByte();
				if (byte_9[i] != b)
				{
					GClass3.smethod_2("ERROR: Invalid echo: " + GClass16.smethod_0(byte_9[i]) + "->" + GClass16.smethod_0(b), 0);
					flag = false;
				}
			}
			if (this.int_0 + 25 < GClass3.smethod_1())
			{
				this.int_3 = 25;
			}
			if (!flag)
			{
				throw new Exception("Invalid echo!");
			}
		}
	}

	// Token: 0x06000094 RID: 148 RVA: 0x000202E8 File Offset: 0x0001E4E8
	private byte[] method_43()
	{
		byte b = (byte)this.serialPort_0.ReadByte();
		byte b2 = 0 + b;
		byte[] array = new byte[(int)b];
		array[0] = b;
		b -= 1;
		byte[] result;
		if (b == 0)
		{
			result = array;
		}
		else
		{
			for (int i = 0; i < (int)b; i++)
			{
				array[i + 1] = (byte)this.serialPort_0.ReadByte();
				b2 += array[i + 1];
			}
			byte b3 = (byte)this.serialPort_0.ReadByte();
			this.int_0 = GClass3.smethod_1();
			GClass3.smethod_2(this.string_11 + GClass16.smethod_1(array), 0);
			if (b2 != b3)
			{
				GClass3.smethod_2("ERROR: Invalid response checksum! [" + GClass16.smethod_0(b3) + "]", 0);
				throw new Exception("Invalid response checksum! [" + GClass16.smethod_0(b3) + "]");
			}
			result = array;
		}
		return result;
	}

	// Token: 0x06000095 RID: 149 RVA: 0x000203CC File Offset: 0x0001E5CC
	private void method_44()
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
									gclass.method_1(this.vmethod_6(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 2)
								{
									gclass.method_1(this.vmethod_6(array[1], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 3)
								{
									gclass.method_1(this.vmethod_6(array[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 4)
								{
									gclass.method_1(this.vmethod_6(array[3], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 5)
								{
									gclass.method_1(this.vmethod_6(array[4], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.byte_0[0][2] == 6)
								{
									gclass.method_1(this.vmethod_6(array[5], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else
								{
									gclass.method_1(this.vmethod_6(array[5], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
							}
							else if (gclass.string_2.StartsWith("bit"))
							{
								gclass.method_1(this.vmethod_6(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
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
					this.string_4 = text;
				}
				else
				{
					this.string_4 = string.Empty;
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

	// Token: 0x06000096 RID: 150 RVA: 0x000208C0 File Offset: 0x0001EAC0
	private void method_45()
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
				if (array.Length < 2 || array[0] != 2 || array[1] != 9)
				{
					array = this.method_37(this.byte_2);
					if (array.Length < 2 || array[0] != 2 || array[1] != 9)
					{
						GClass3.smethod_2("KA response error!", 1);
						if (array.Length == 0 && this.int_1 > 2)
						{
							GClass3.smethod_2("Terminate 7", 1);
							base.method_21(true);
						}
					}
				}
			}
		}
		GClass3.smethod_2("KA stopped", 1);
	}

	// Token: 0x04000095 RID: 149
	private int int_5 = 2000;

	// Token: 0x04000096 RID: 150
	private int int_6 = 3;

	// Token: 0x04000097 RID: 151
	private int int_7 = 1000;

	// Token: 0x04000098 RID: 152
	private int int_8 = 3;

	// Token: 0x04000099 RID: 153
	private int int_9 = 41;

	// Token: 0x0400009A RID: 154
	private int int_10 = 3;

	// Token: 0x0400009B RID: 155
	private int int_11 = 400;

	// Token: 0x0400009C RID: 156
	private byte[] byte_2 = new byte[]
	{
		2,
		9
	};

	// Token: 0x0400009D RID: 157
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

	// Token: 0x0400009E RID: 158
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

	// Token: 0x0400009F RID: 159
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

	// Token: 0x040000A0 RID: 160
	private byte[] byte_6 = new byte[]
	{
		2,
		7
	};

	// Token: 0x040000A1 RID: 161
	private byte[] byte_7 = new byte[]
	{
		2,
		5
	};

	// Token: 0x040000A2 RID: 162
	private int int_12 = 0;

	// Token: 0x040000A3 RID: 163
	private string[] string_5 = new string[]
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

	// Token: 0x040000A4 RID: 164
	private byte[] byte_8 = new byte[]
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

	// Token: 0x040000A5 RID: 165
	private string string_6 = " <";

	// Token: 0x040000A6 RID: 166
	private string string_7 = "> Sent: ";

	// Token: 0x040000A7 RID: 167
	private string string_8 = " <";

	// Token: 0x040000A8 RID: 168
	private string string_9 = "> ERROR: Invalid echo: ";

	// Token: 0x040000A9 RID: 169
	private string string_10 = "Invalid echo!";

	// Token: 0x040000AA RID: 170
	private string string_11 = "Received: ";
}
