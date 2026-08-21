using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

// Token: 0x0200005E RID: 94
public sealed class GClass48 : GClass19
{
	// Token: 0x0600028E RID: 654 RVA: 0x000639CC File Offset: 0x00061BCC
	public GClass48(byte byte_9, List<GClass58> list_4, List<GClass58> list_5)
	{
		this.byte_0 = byte_9;
		this.list_0 = list_5;
		this.list_1 = list_4;
	}

	// Token: 0x0600028F RID: 655 RVA: 0x00063C44 File Offset: 0x00061E44
	public override void vmethod_1(GEnum0 genum0_0)
	{
		try
		{
			this.int_1 = 0;
			byte[] array = new byte[0];
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
						gclass.method_1(this.vmethod_7(array2[3], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
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
					GClass3.smethod_2("5bps wake up start 71 (" + GClass16.smethod_0(this.byte_0) + ")...", 1);
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
					GClass3.smethod_2("ECU ISO Code: " + this.string_3, 2);
					byte b9 = b4;
					b9 ^= byte.MaxValue;
					this.int_0 = GClass3.smethod_1();
					GClass3.smethod_2(this.method_40(b9), 0);
					this.byte_8 = 1;
					List<byte> list = new List<byte>();
					string empty = string.Empty;
					array = this.method_41(ref empty);
					GClass3.smethod_2(empty, 0);
					if (array.Length > 0)
					{
						for (int i = 0; i < array.Length; i++)
						{
							list.Add(array[i]);
						}
					}
					array = this.method_36(this.byte_3);
					if (array.Length > 2)
					{
						for (int i = 2; i < array.Length; i++)
						{
							list.Add(array[i]);
						}
					}
					array = list.ToArray();
					this.serialPort_0.ReadTimeout = 250;
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
					Thread.Sleep(2500);
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
					else if (gclass.byte_0[0].Length > 2 && array.Length > 0 && gclass.byte_0[0][0] == 3 && gclass.byte_0[0][2] == 0)
					{
						gclass.method_1(this.vmethod_7(array, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
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

	// Token: 0x06000290 RID: 656 RVA: 0x00051ED8 File Offset: 0x000500D8
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

	// Token: 0x06000291 RID: 657 RVA: 0x000644C8 File Offset: 0x000626C8
	public List<GClass64> method_33()
	{
		List<GClass64> list = new List<GClass64>();
		byte[] array;
		if (GClass3.bool_0)
		{
			array = this.byte_5;
		}
		else
		{
			array = this.method_36(this.byte_6);
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

	// Token: 0x06000292 RID: 658 RVA: 0x0006480C File Offset: 0x00062A0C
	public override List<GClass64> vmethod_3()
	{
		List<GClass64> result;
		if (this.string_0 == "MA1.7.3")
		{
			result = this.method_33();
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
				array = this.method_36(this.byte_6);
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

	// Token: 0x06000293 RID: 659 RVA: 0x00018938 File Offset: 0x00016B38
	private string method_34(byte byte_9)
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

	// Token: 0x06000294 RID: 660 RVA: 0x00064B6C File Offset: 0x00062D6C
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
			byte[] array = this.method_36(this.byte_7);
			if (array.Length < 2 || array[1] != 9)
			{
				GClass3.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
		}
	}

	// Token: 0x06000295 RID: 661 RVA: 0x00064BCC File Offset: 0x00062DCC
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

	// Token: 0x06000296 RID: 662 RVA: 0x00064C48 File Offset: 0x00062E48
	private void method_35(GClass58 gclass58_1)
	{
		byte[] array = this.method_36(gclass58_1.byte_0[0]);
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
					this.method_36(gclass58_1.byte_0[i]);
				}
			}
			else if (gclass58_1.byte_0.Length == 2)
			{
				for (int i = 1; i < gclass58_1.byte_0.Length; i++)
				{
					Thread.Sleep(6000);
					Thread.Sleep(2000);
					this.method_36(gclass58_1.byte_0[i]);
				}
			}
			else
			{
				Thread.Sleep(9000);
			}
			base.method_31(false, GClass62.smethod_1("6051"), string.Empty);
		}
	}

	// Token: 0x06000297 RID: 663 RVA: 0x00064D50 File Offset: 0x00062F50
	public override string vmethod_0(byte[] byte_9, string string_18, int int_12, int int_13, string[] string_19, string string_20)
	{
		byte[] array = this.method_36(byte_9);
		if (array.Length == 0)
		{
			array = this.method_36(byte_9);
		}
		return this.vmethod_7(array, string_18, int_12, int_13, string_19, string_20);
	}

	// Token: 0x06000298 RID: 664 RVA: 0x00064D8C File Offset: 0x00062F8C
	private byte[] method_36(byte[] byte_9)
	{
		List<byte> list = new List<byte>();
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			byte[] array = this.method_37(byte_9);
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i]);
			}
			int num = 10;
			while (array.Length > 0 && array[1] != 9 && num > 0)
			{
				array = this.method_37(this.byte_3);
				if (array.Length > 2)
				{
					for (int i = 2; i < array.Length; i++)
					{
						list.Add(array[i]);
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

	// Token: 0x06000299 RID: 665 RVA: 0x00064E50 File Offset: 0x00063050
	private byte[] method_37(byte[] byte_9)
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
			byte byte_10 = byte_9[0];
			text = this.method_40(byte_10);
			byte b = (byte)this.serialPort_0.ReadByte();
			this.int_0 = GClass3.smethod_1();
			if (b != this.method_38(byte_10))
			{
				text = text + " <ERROR: Invalid ack byte! [" + GClass16.smethod_0(b) + "]>";
			}
			byte_9[1] = this.byte_8;
			this.byte_8 += 1;
			for (int i = 1; i < byte_9.Length - 1; i++)
			{
				text += this.method_40(byte_9[i]);
				byte b2 = (byte)this.serialPort_0.ReadByte();
				this.int_0 = GClass3.smethod_1();
				if (b2 != this.method_38(byte_9[i]))
				{
					text = text + " <ERROR: Invalid ack byte! [" + GClass16.smethod_0(b2) + "]>";
				}
			}
			text += this.method_40(3);
			GClass3.smethod_2(text, 0);
			text = string.Empty;
			byte[] array = this.method_41(ref text);
			GClass3.smethod_2(text, 0);
			text = string.Empty;
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
				if (this.int_1 > 3)
				{
					this.bool_2 = false;
					GClass3.smethod_2("Terminate 5", 1);
					base.method_22(true);
				}
				this.int_1++;
				this.serialPort_0.ReadTimeout = 90;
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
				this.serialPort_0.ReadTimeout = 250;
			}
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x0600029A RID: 666 RVA: 0x00065080 File Offset: 0x00063280
	private byte method_38(byte byte_9)
	{
		return byte.MaxValue - byte_9;
	}

	// Token: 0x0600029B RID: 667 RVA: 0x00020014 File Offset: 0x0001E214
	private byte method_39(byte[] byte_9)
	{
		byte b = 0;
		for (int i = 0; i < byte_9.Length; i++)
		{
			b += byte_9[i];
		}
		return b;
	}

	// Token: 0x0600029C RID: 668 RVA: 0x00035A9C File Offset: 0x00033C9C
	public override string vmethod_7(byte[] byte_9, string string_18, int int_12, int int_13, string[] string_19, string string_20)
	{
		string text = string.Empty;
		int_12++;
		string result;
		if (byte_9.Length <= int_12)
		{
			result = text;
		}
		else
		{
			int num = byte_9.Length - int_12;
			if (int_13 < num)
			{
				num = int_13;
			}
			byte[] array = new byte[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = byte_9[i + int_12];
			}
			text = base.method_32(array, string_18, string_19, string_20);
			result = text;
		}
		return result;
	}

	// Token: 0x0600029D RID: 669 RVA: 0x000650A0 File Offset: 0x000632A0
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
			this.string_8,
			this.int_0,
			this.string_9,
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
				this.string_8,
				this.int_0,
				this.string_11,
				GClass16.smethod_0(b)
			});
		}
		return text;
	}

	// Token: 0x0600029E RID: 670 RVA: 0x000651B0 File Offset: 0x000633B0
	private byte[] method_41(ref string string_18)
	{
		byte b = (byte)this.serialPort_0.ReadByte();
		this.int_0 = GClass3.smethod_1();
		string_18 += this.method_40(this.method_38(b));
		byte[] result;
		if (b > 127)
		{
			string_18 = string_18 + " <ERROR: Invalid message length! [" + GClass16.smethod_0(b) + "]>";
			result = new byte[0];
		}
		else
		{
			byte[] array = new byte[(int)(b - 1)];
			array[0] = b;
			b -= 2;
			byte b2 = (byte)this.serialPort_0.ReadByte();
			this.int_0 = GClass3.smethod_1();
			string_18 += this.method_40(this.method_38(b2));
			for (int i = 0; i < (int)b; i++)
			{
				array[i + 1] = (byte)this.serialPort_0.ReadByte();
				this.int_0 = GClass3.smethod_1();
				string_18 += this.method_40(this.method_38(array[i + 1]));
			}
			byte b3 = (byte)this.serialPort_0.ReadByte();
			this.int_0 = GClass3.smethod_1();
			this.int_0 = GClass3.smethod_1();
			object obj = string_18;
			string_18 = string.Concat(new object[]
			{
				obj,
				this.string_8,
				this.int_0,
				this.string_13,
				GClass16.smethod_1(array)
			});
			if (this.byte_8 != b2)
			{
				string text = string_18;
				string_18 = string.Concat(new string[]
				{
					text,
					this.string_14,
					GClass16.smethod_0(this.byte_8),
					this.string_15,
					GClass16.smethod_0(b2),
					this.string_16
				});
				if (this.byte_8 == b2 + 1 || this.byte_8 == b2 + 2 || this.byte_8 == b2 + 3 || this.byte_8 == b2 - 1 || this.byte_8 == b2 - 2 || this.byte_8 == b2 - 3)
				{
					this.byte_8 = b2;
				}
				else
				{
					b2 = this.byte_8;
					b2 += 1;
				}
			}
			b2 += 1;
			this.byte_8 = b2;
			if (b3 != 3)
			{
				string_18 = string_18 + this.string_17 + GClass16.smethod_0(b3) + this.string_16;
			}
			result = array;
		}
		return result;
	}

	// Token: 0x0600029F RID: 671 RVA: 0x00065404 File Offset: 0x00063604
	private void method_42()
	{
		GClass3.smethod_2("PM started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(80);
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

	// Token: 0x060002A0 RID: 672 RVA: 0x000658F8 File Offset: 0x00063AF8
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
				byte[] array = this.method_36(this.byte_2);
				if (array.Length < 2 || array[0] != 3 || array[1] != 9)
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
		GClass3.smethod_2("KA stopped", 1);
	}

	// Token: 0x040003EF RID: 1007
	private int int_5 = 2000;

	// Token: 0x040003F0 RID: 1008
	private int int_6 = 3;

	// Token: 0x040003F1 RID: 1009
	private int int_7 = 1000;

	// Token: 0x040003F2 RID: 1010
	private int int_8 = 3;

	// Token: 0x040003F3 RID: 1011
	private int int_9 = 41;

	// Token: 0x040003F4 RID: 1012
	private int int_10 = 3;

	// Token: 0x040003F5 RID: 1013
	private int int_11 = 420;

	// Token: 0x040003F6 RID: 1014
	private byte[] byte_2 = new byte[]
	{
		3,
		0,
		9,
		3
	};

	// Token: 0x040003F7 RID: 1015
	private byte[] byte_3 = new byte[]
	{
		3,
		0,
		9,
		3
	};

	// Token: 0x040003F8 RID: 1016
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

	// Token: 0x040003F9 RID: 1017
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

	// Token: 0x040003FA RID: 1018
	private byte[] byte_6 = new byte[]
	{
		3,
		0,
		7,
		3
	};

	// Token: 0x040003FB RID: 1019
	private byte[] byte_7 = new byte[]
	{
		3,
		0,
		5,
		3
	};

	// Token: 0x040003FC RID: 1020
	private byte byte_8 = 0;

	// Token: 0x040003FD RID: 1021
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

	// Token: 0x040003FE RID: 1022
	private string string_8 = " <";

	// Token: 0x040003FF RID: 1023
	private string string_9 = "> Sent: ";

	// Token: 0x04000400 RID: 1024
	private string string_10 = " <";

	// Token: 0x04000401 RID: 1025
	private string string_11 = "> ERROR: Invalid echo: ";

	// Token: 0x04000402 RID: 1026
	private string string_12 = "Invalid echo!";

	// Token: 0x04000403 RID: 1027
	private string string_13 = "> Received: ";

	// Token: 0x04000404 RID: 1028
	private string string_14 = " <ERROR: Invalid KWP71 counter! [";

	// Token: 0x04000405 RID: 1029
	private string string_15 = "!=";

	// Token: 0x04000406 RID: 1030
	private string string_16 = "]>";

	// Token: 0x04000407 RID: 1031
	private string string_17 = " <ERROR: Invalid end of message! [";
}
