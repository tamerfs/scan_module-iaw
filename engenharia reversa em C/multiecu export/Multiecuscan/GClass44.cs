using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x02000019 RID: 25
public abstract class GClass44 : GClass11
{
	// Token: 0x06000176 RID: 374
	protected abstract void r6();

	// Token: 0x06000177 RID: 375 RVA: 0x00026584 File Offset: 0x00024784
	public override void vmethod_1()
	{
		try
		{
			GClass126.smethod_2("-----------------------", 0);
			GClass126.smethod_2("Control module (CANDETECT)", 0);
			for (int i = 0; i < 5; i++)
			{
				if (GClass126.bool_25)
				{
					throw new Exception("ESC");
				}
				Thread.Sleep(100);
			}
			this.r6();
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			base.method_30(false);
		}
		catch (Exception ex)
		{
			if (ex.Message == "ESC")
			{
				this.string_8 = GClass121.smethod_6("6060");
			}
			GClass126.smethod_2(ex.Message, 2);
			GClass126.smethod_2("Terminate 4", 1);
			this.r0(ex.Message != "0", ex.Message == "ESC");
		}
	}

	// Token: 0x06000178 RID: 376 RVA: 0x00026660 File Offset: 0x00024860
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
		if (GClass125.smethod_48())
		{
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
				}
				catch (Exception ex)
				{
					GClass126.smethod_2("ERROR: Failed to close TCP connection: " + ex.Message, 1);
				}
				GClass126.smethod_2("-------------------------------------", 1);
				GClass126.smethod_2(" ", 1);
			}
		}
		else if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
		{
			try
			{
				this.serialPort_0.ReadTimeout = 100;
				if (GClass125.smethod_44() == 4)
				{
					this.ra("\rATZ");
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
			}
			catch (Exception ex2)
			{
				GClass126.smethod_2("ERROR: Failed to close serial port: " + ex2.Message, 1);
			}
			GClass126.smethod_2("-------------------------------------", 1);
			GClass126.smethod_2(" ", 1);
		}
		base.method_32(bool_7);
	}

	// Token: 0x06000179 RID: 377 RVA: 0x00002F03 File Offset: 0x00001103
	public override List<GClass102> r1()
	{
		return new List<GClass102>();
	}

	// Token: 0x0600017A RID: 378 RVA: 0x00002F0A File Offset: 0x0000110A
	public override void r2()
	{
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00002F0A File Offset: 0x0000110A
	public override void r7(List<GClass102> list_6, List<GClass104> list_7)
	{
	}

	// Token: 0x0600017C RID: 380 RVA: 0x00002F0A File Offset: 0x0000110A
	protected override void r3(GClass104 gclass104_1)
	{
	}

	// Token: 0x0600017D RID: 381 RVA: 0x00002F38 File Offset: 0x00001138
	public override string vmethod_0(byte[] byte_3, string string_40, int int_5, int int_6, string[] string_41, string string_42)
	{
		return "";
	}

	// Token: 0x0600017E RID: 382 RVA: 0x00002F3F File Offset: 0x0000113F
	protected byte[] method_45(byte[] byte_3)
	{
		return new byte[0];
	}

	// Token: 0x0600017F RID: 383 RVA: 0x0001D948 File Offset: 0x0001BB48
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

	// Token: 0x06000180 RID: 384 RVA: 0x000267F4 File Offset: 0x000249F4
	protected string method_46()
	{
		if (GClass125.smethod_48())
		{
			return this.method_47();
		}
		if (this.serialPort_0 == null)
		{
			return "";
		}
		string text = "";
		while (!text.EndsWith(">") && !text.EndsWith("\r") && !text.EndsWith("\n") && text.Length < 100)
		{
			text += ((char)this.serialPort_0.ReadByte()).ToString();
		}
		GClass126.smethod_2("Read line: " + text, 0);
		return text;
	}

	// Token: 0x06000181 RID: 385 RVA: 0x00026884 File Offset: 0x00024A84
	private string method_47()
	{
		string text = "";
		long num = (long)(GClass126.smethod_1() + 3500);
		while (!text.EndsWith(">") && !text.EndsWith("\r") && !text.EndsWith("\n") && text.Length < 250 && num > (long)GClass126.smethod_1())
		{
			if (this.tcpClient_0.Client.Available > 0)
			{
				int num2 = this.tcpClient_0.GetStream().ReadByte();
				if (num2 != -1)
				{
					text += ((char)num2).ToString();
				}
				num = (long)(GClass126.smethod_1() + 2500);
			}
			else
			{
				Thread.Sleep(1);
			}
		}
		GClass126.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x0400011A RID: 282
	protected string string_22 = "Waiting FC...";

	// Token: 0x0400011B RID: 283
	protected string string_23 = "NO DATA";

	// Token: 0x0400011C RID: 284
	protected string string_24 = "ERROR";

	// Token: 0x0400011D RID: 285
	protected string string_25 = "?";

	// Token: 0x0400011E RID: 286
	protected string string_26 = "F130";

	// Token: 0x0400011F RID: 287
	protected string string_27 = " 00";

	// Token: 0x04000120 RID: 288
	protected string string_28 = " 30 FF 00";

	// Token: 0x04000121 RID: 289
	protected string string_29 = "F1";

	// Token: 0x04000122 RID: 290
	protected string string_30 = "DECODED RESPONSE: ";

	// Token: 0x04000123 RID: 291
	protected string string_31 = "ATST01";

	// Token: 0x04000124 RID: 292
	protected string string_32 = "ATST02";

	// Token: 0x04000125 RID: 293
	protected string string_33 = "ATST03";

	// Token: 0x04000126 RID: 294
	protected string string_34 = "ATST05";

	// Token: 0x04000127 RID: 295
	protected string string_35 = "ATST07";

	// Token: 0x04000128 RID: 296
	protected string string_36 = "ATST09";

	// Token: 0x04000129 RID: 297
	protected string string_37 = "ATST99";

	// Token: 0x0400012A RID: 298
	protected string string_38 = "ATSTFF";

	// Token: 0x0400012B RID: 299
	private const string string_39 = "Read line: ";
}
