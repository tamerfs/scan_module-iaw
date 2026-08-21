using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

// Token: 0x02000015 RID: 21
public abstract class GClass18 : GClass11
{
	// Token: 0x06000127 RID: 295 RVA: 0x0001CD8C File Offset: 0x0001AF8C
	protected void method_45()
	{
		if (GClass126.bool_0)
		{
			this.bool_1 = false;
			this.bool_0 = true;
			new Thread(new ThreadStart(this.method_49))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_36();
			throw new Exception("1");
		}
	}

	// Token: 0x06000128 RID: 296
	protected abstract void r6();

	// Token: 0x06000129 RID: 297 RVA: 0x0001CDDC File Offset: 0x0001AFDC
	public override void vmethod_1()
	{
		try
		{
			GClass126.smethod_2("-----------------------", 0);
			GClass126.smethod_2("Control module (CAN11MON)", 0);
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
				Thread thread = new Thread(new ThreadStart(this.method_50));
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_49)).Start();
			}
			SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
			for (int j = 0; j < this.list_1.Count; j++)
			{
				GClass104 gclass = this.list_1[j];
				if (sortedList.ContainsKey(GClass127.smethod_11(gclass.byte_0[0])))
				{
					byte[] byte_ = sortedList[GClass127.smethod_11(gclass.byte_0[0])];
					gclass.method_1(this.r4(byte_, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
				else
				{
					byte[] array = this.method_47(gclass.byte_0[0]);
					gclass.method_1(this.r4(array, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					sortedList.Add(GClass127.smethod_11(gclass.byte_0[0]), array);
				}
				if (gclass.int_2 == 10455)
				{
					this.string_7 = gclass.method_0();
					GClass126.smethod_2("ECU ISO Code: " + gclass.method_0(), 0);
				}
			}
			if (this.genum0_0 != (GEnum0)0)
			{
				base.method_30(false);
			}
			else if (GClass126.bool_13 && GClass125.smethod_5().ToUpper().StartsWith("72345-67890-A"))
			{
				this.string_8 = "Data file corrupted!";
				base.method_30(false);
			}
			else
			{
				if (GClass123.bool_13 && GClass126.bool_13 && GClass123.int_6 == 0)
				{
					bool flag = true;
					if (GClass125.smethod_5().StartsWith(GClass122.smethod_2()))
					{
						GClass126.bool_13 = false;
					}
					else if (GClass125.int_18[4] == 4)
					{
						GClass126.bool_13 = false;
					}
					else
					{
						flag = false;
					}
					if (flag)
					{
						GClass126.smethod_2(">Start 35", 0);
					}
				}
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

	// Token: 0x0600012A RID: 298 RVA: 0x0001D0F0 File Offset: 0x0001B2F0
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
		if (this.tcpClient_0 != null && this.tcpClient_0.Connected)
		{
			try
			{
				this.ra("\rATPC");
			}
			catch (Exception)
			{
			}
			try
			{
				this.tcpClient_0.Close();
				this.tcpClient_0 = null;
			}
			catch (Exception ex)
			{
				GClass126.smethod_2("ERROR: Failed to close TCP connection: " + ex.Message, 1);
			}
		}
		if (this.bluetoothLEDevice_0 != null)
		{
			if (this.gattDeviceService_0 != null)
			{
				try
				{
					this.ra("\rATPC");
				}
				catch (Exception)
				{
				}
				try
				{
					this.gattDeviceService_0.Session.Dispose();
					this.gattDeviceService_0.Dispose();
					this.gattDeviceService_0 = null;
					GClass126.smethod_2("BLE gatt service closed!", 0);
				}
				catch (Exception ex2)
				{
					GClass126.smethod_2("ERROR: Failed to close BLE service: " + ex2.Message, 1);
				}
			}
			try
			{
				this.bluetoothLEDevice_0.Dispose();
				this.bluetoothLEDevice_0 = null;
				GClass126.smethod_2("BLE device closed!", 0);
			}
			catch (Exception ex3)
			{
				GClass126.smethod_2("ERROR: Failed to close BLE connection: " + ex3.Message, 1);
			}
		}
		if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
		{
			try
			{
				this.serialPort_0.ReadTimeout = 100;
				this.serialPort_0.WriteTimeout = 200;
				if (GClass125.smethod_44() == 4)
				{
					this.ra("\rATZ");
				}
				else if (GClass125.smethod_44() == 11)
				{
					this.ra("\r");
					Thread.Sleep(50);
					this.ra("ATZ");
				}
				else
				{
					this.ra("\rATPC");
				}
			}
			catch (Exception)
			{
			}
			try
			{
				this.serialPort_0.Close();
				GClass126.smethod_2("Serial port closed!", 1);
				this.serialPort_0 = null;
			}
			catch (Exception ex4)
			{
				GClass126.smethod_2("ERROR: Failed to close serial port: " + ex4.Message, 1);
			}
		}
		GClass126.smethod_2("-------------------------------------", 1);
		GClass126.smethod_2(" ", 1);
		base.method_32(bool_8);
	}

	// Token: 0x0600012B RID: 299 RVA: 0x00002F03 File Offset: 0x00001103
	public override List<GClass102> r1()
	{
		return new List<GClass102>();
	}

	// Token: 0x0600012C RID: 300 RVA: 0x00002F0A File Offset: 0x0000110A
	public override void r2()
	{
	}

	// Token: 0x0600012D RID: 301 RVA: 0x00002F0A File Offset: 0x0000110A
	public override void r7(List<GClass102> list_6, List<GClass104> list_7)
	{
	}

	// Token: 0x0600012E RID: 302 RVA: 0x0001D37C File Offset: 0x0001B57C
	protected override void r3(GClass104 gclass104_1)
	{
		if (GClass126.bool_0)
		{
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
			return;
		}
		else
		{
			if (gclass104_1.string_2.Contains("RWUSERENTRY"))
			{
				this.method_46(gclass104_1);
				return;
			}
			base.method_28(false, GClass121.smethod_6("6052"), "");
			return;
		}
	}

	// Token: 0x0600012F RID: 303 RVA: 0x0001D42C File Offset: 0x0001B62C
	private void method_46(GClass104 gclass104_1)
	{
		byte[] array = gclass104_1.byte_0[0];
		if (array.Length < 4)
		{
			string text = "";
			base.method_28(false, GClass121.smethod_6("6052"), text);
			return;
		}
		for (int i = 2; i < gclass104_1.byte_0[1].Length; i++)
		{
			byte b = 0;
			if (array.Length > i)
			{
				b = array[i];
			}
			if (gclass104_1.int_0 <= i - 1 && gclass104_1.int_0 + gclass104_1.int_1 > i - 1)
			{
				byte b2 = gclass104_1.byte_0[1][i];
				byte b3 = byte.Parse(gclass104_1.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
				b3 ^= byte.MaxValue;
				b &= b3;
				b |= b2;
			}
			gclass104_1.byte_0[1][i] = b;
			if (gclass104_1.byte_0.Length > 2)
			{
				gclass104_1.byte_0[2][i] = b;
			}
		}
		this.bool_6 = true;
		int num = 1000;
		while (this.bool_2 && num > 0)
		{
			Thread.Sleep(1);
			num--;
		}
		if (this.bool_2)
		{
			this.bool_6 = false;
			string text2 = "";
			base.method_28(false, GClass121.smethod_6("6052"), text2);
			return;
		}
		string text3 = "";
		try
		{
			this.r9("");
			try
			{
				this.rb();
				this.rb();
			}
			catch (Exception)
			{
			}
			string text4 = GClass127.smethod_11(gclass104_1.byte_0[1]).Replace(" ", "");
			string str = text4.Substring(1, 3);
			string text5 = text4.Substring(4);
			text3 = this.ra("ATSH " + str);
			this.r9(text5);
			string text6 = base.method_4();
			if (!text6.EndsWith(">"))
			{
				text6 = base.method_4();
			}
			if (!text6.EndsWith(">"))
			{
				text6 = base.method_4();
			}
			if (!text6.EndsWith(">"))
			{
				text6 = base.method_4();
			}
			if (!text6.EndsWith(">"))
			{
				text6 = base.method_4();
			}
			if (!text6.EndsWith(">"))
			{
				text6 = base.method_4();
			}
			if (gclass104_1.byte_0.Length > 2)
			{
				this.r9("ATMA");
				text6 = base.method_4();
				if (!text6.EndsWith(">"))
				{
					text6 = base.method_4();
				}
				if (!text6.EndsWith(">"))
				{
					text6 = base.method_4();
				}
				if (!text6.EndsWith(">"))
				{
					text6 = base.method_4();
				}
				if (!text6.EndsWith(">"))
				{
					text6 = base.method_4();
				}
				if (!text6.EndsWith(">"))
				{
					text6 = base.method_4();
				}
				this.r9("");
				try
				{
					this.rb();
					this.rb();
				}
				catch (Exception)
				{
				}
				string text7 = GClass127.smethod_11(gclass104_1.byte_0[2]).Replace(" ", "");
				str = text7.Substring(1, 3);
				text5 = text7.Substring(4);
				text3 = this.ra("ATSH " + str);
				this.r9(text5);
				text6 = base.method_4();
				if (!text6.EndsWith(">"))
				{
					text6 = base.method_4();
				}
				if (!text6.EndsWith(">"))
				{
					text6 = base.method_4();
				}
				if (!text6.EndsWith(">"))
				{
					text6 = base.method_4();
				}
				if (!text6.EndsWith(">"))
				{
					text6 = base.method_4();
				}
				if (!text6.EndsWith(">"))
				{
					text6 = base.method_4();
				}
			}
		}
		catch (Exception)
		{
			text3 = "";
		}
		this.r9("ATMA");
		this.bool_6 = false;
		if (!text3.Contains("OK"))
		{
			string text8 = "CAN ERROR";
			base.method_28(false, GClass121.smethod_6("6052"), text8);
			return;
		}
		Thread.Sleep(500);
		base.method_28(false, GClass121.smethod_6("6051"), "");
	}

	// Token: 0x06000130 RID: 304 RVA: 0x0001D868 File Offset: 0x0001BA68
	public override string vmethod_0(byte[] byte_3, string string_40, int int_5, int int_6, string[] string_41, string string_42)
	{
		byte[] array = this.method_47(byte_3);
		if (string_40 == "raw")
		{
			return GClass127.smethod_11(array);
		}
		return this.r4(array, string_40, int_5 + 2, int_6, string_41, string_42);
	}

	// Token: 0x06000131 RID: 305 RVA: 0x0001D8A4 File Offset: 0x0001BAA4
	protected byte[] method_47(byte[] byte_3)
	{
		byte[] result;
		try
		{
			byte[] array = new byte[0];
			foreach (GClass104 gclass in this.list_2)
			{
				if (GClass127.smethod_11(gclass.byte_0[0]) == GClass127.smethod_11(byte_3))
				{
					try
					{
						array = gclass.byte_0[0];
					}
					catch (Exception)
					{
					}
				}
			}
			result = array;
		}
		catch (Exception)
		{
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x06000132 RID: 306 RVA: 0x0001D948 File Offset: 0x0001BB48
	public override string r4(byte[] byte_3, string string_40, int int_5, int int_6, string[] string_41, string string_42)
	{
		string result = "";
		int_5--;
		if (byte_3.Length <= int_5)
		{
			return result;
		}
		int num = byte_3.Length - int_5;
		if (int_6 < num)
		{
			num = int_6;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_3[i + int_5];
		}
		return base.method_33(array, string_40, string_41, string_42);
	}

	// Token: 0x06000133 RID: 307 RVA: 0x0001D9A4 File Offset: 0x0001BBA4
	private void method_48(string string_40)
	{
		if (string_40.Length < 3)
		{
			return;
		}
		foreach (GClass104 gclass in this.list_0)
		{
			if (this.bool_1)
			{
				break;
			}
			if (string_40.StartsWith(gclass.string_8))
			{
				byte[] byte_ = GClass127.smethod_32(string_40.Substring(gclass.string_8.Length));
				string string_41 = this.r4(byte_, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				if (!gclass.string_0.StartsWith("CALCDT"))
				{
					gclass.method_1(string_41);
				}
				if (GClass126.bool_12 && GClass126.smethod_1() > GClass126.int_3 + GClass126.int_5)
				{
					if (GClass126.list_1.Count > 0)
					{
						GClass126.smethod_0().method_2(GClass126.smethod_1());
					}
					GClass126.int_3 = GClass126.smethod_1();
					if (GClass126.int_5 < 50)
					{
						GClass126.int_5 = 50;
					}
				}
				this.bool_4 = true;
				GClass126.int_6 = 50;
				if (!GClass126.bool_12)
				{
					GClass126.int_5 = GClass126.int_6;
				}
			}
		}
		foreach (GClass104 gclass2 in this.list_2)
		{
			if (this.bool_1)
			{
				break;
			}
			if (string_40.StartsWith(gclass2.string_8) && gclass2.byte_0.Length >= 2 && gclass2.byte_0[0].Length >= 3)
			{
				byte[] array = GClass127.smethod_32(string_40.Substring(gclass2.string_8.Length));
				int num = 0;
				while (num < array.Length && num + 2 < gclass2.byte_0[0].Length)
				{
					gclass2.byte_0[0][num + 2] = array[num];
					num++;
				}
				gclass2.method_1(this.r4(array, gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
			}
		}
	}

	// Token: 0x06000134 RID: 308 RVA: 0x0001DBE8 File Offset: 0x0001BDE8
	private void method_49()
	{
		GClass126.smethod_2("PM started", 1);
		GClass126.int_3 = GClass126.smethod_1();
		int num = 0;
		while (!this.bool_1)
		{
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
								goto IL_71;
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
			IL_71:
			if (this.bool_6)
			{
				this.bool_2 = false;
			}
			else
			{
				this.bool_2 = true;
				if (GClass126.bool_0)
				{
					Thread.Sleep(2);
					string text = this.string_39[num];
					text = text.Trim(this.char_1);
					num++;
					if (num >= this.string_39.Length)
					{
						num = 0;
					}
					this.method_48(text);
				}
				else
				{
					string text = ">";
					try
					{
						text = base.method_4();
						if (!text.Contains("aiting") && text.Length > 1)
						{
							this.int_1 = 0;
						}
					}
					catch (Exception)
					{
						this.int_1++;
						if (this.int_1 > 10)
						{
							base.method_30(false);
						}
					}
					text = text.Trim(this.char_1);
					if (text.StartsWith(">"))
					{
						if (!this.bool_1)
						{
							this.r9("");
							try
							{
								this.rb();
								this.rb();
							}
							catch (Exception)
							{
							}
							if (!this.bool_1)
							{
								this.r9("ATMA");
								goto IL_170;
							}
						}
						IL_1E3:
						GClass126.smethod_2("PM stopped", 1);
						return;
					}
					IL_170:
					if ((GClass125.smethod_44() == 4 || GClass125.smethod_44() == 5 || GClass125.smethod_44() == 10) && text.Length > 1)
					{
						text = text.Substring(1);
					}
					try
					{
						this.method_48(text);
					}
					catch (Exception)
					{
						GClass126.smethod_2("ERROR: line processing", 0);
					}
				}
			}
		}
		goto IL_1E3;
	}

	// Token: 0x06000135 RID: 309 RVA: 0x00002F0C File Offset: 0x0000110C
	private void method_50()
	{
		GClass126.smethod_2("KA started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(200);
		}
		GClass126.smethod_2("KA stopped", 1);
	}

	// Token: 0x040000EC RID: 236
	protected string string_22 = "Waiting FC...";

	// Token: 0x040000ED RID: 237
	protected string string_23 = "NO DATA";

	// Token: 0x040000EE RID: 238
	protected string string_24 = "ERROR";

	// Token: 0x040000EF RID: 239
	protected string string_25 = "?";

	// Token: 0x040000F0 RID: 240
	protected string string_26 = "F130";

	// Token: 0x040000F1 RID: 241
	protected string string_27 = " 00";

	// Token: 0x040000F2 RID: 242
	protected string string_28 = " 30 FF 00";

	// Token: 0x040000F3 RID: 243
	protected string string_29 = "F1";

	// Token: 0x040000F4 RID: 244
	protected string string_30 = "DECODED RESPONSE: ";

	// Token: 0x040000F5 RID: 245
	protected string string_31 = "ATST01";

	// Token: 0x040000F6 RID: 246
	protected string string_32 = "ATST02";

	// Token: 0x040000F7 RID: 247
	protected string string_33 = "ATST03";

	// Token: 0x040000F8 RID: 248
	protected string string_34 = "ATST05";

	// Token: 0x040000F9 RID: 249
	protected string string_35 = "ATST07";

	// Token: 0x040000FA RID: 250
	protected string string_36 = "ATST09";

	// Token: 0x040000FB RID: 251
	protected string string_37 = "ATST99";

	// Token: 0x040000FC RID: 252
	protected string string_38 = "ATSTFF";

	// Token: 0x040000FD RID: 253
	private string[] string_39 = new string[]
	{
		"2A0015A0060",
		"2810000C06A0B002F00",
		"3800800405600380D05",
		"2810000C06A046C1B00",
		"2A00043007B",
		"2860008006315E01770",
		"3800800405600380D05",
		"2A00101007F",
		"3800800405600380D05",
		"2810000C06A0F243800",
		"2A00116007F",
		"6E311B520F009",
		"60300037753807D0000",
		"6432500020307000340",
		"663000C000002000000",
		"683133623012014",
		"6B345AA03FF00000000"
	};

	// Token: 0x040000FE RID: 254
	private char[] char_1 = new char[]
	{
		'\r',
		'\n',
		' '
	};

	// Token: 0x040000FF RID: 255
	private char[] char_2 = new char[]
	{
		'|'
	};

	// Token: 0x04000100 RID: 256
	private bool bool_6;
}
