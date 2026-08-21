using System;
using System.Threading;

// Token: 0x0200006D RID: 109
public sealed class GClass76 : GClass73
{
	// Token: 0x060003B2 RID: 946 RVA: 0x0005E72C File Offset: 0x0005C92C
	protected override void r6()
	{
		try
		{
			base.method_23("", "");
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 3000;
			}
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATSP4");
			this.ra("ATIB48");
			this.ra("STPBR4800");
			this.ra("STIMCS0");
			this.ra("STPCB0");
			this.ra("ATKW0");
			this.ra("ATIIA " + GClass127.smethod_23(this.byte_0));
			this.ra("ATH0");
			this.ra("ATSW00");
			this.ra("ATSH 010000");
			this.ra("STIP4 500");
			Thread.Sleep(100);
			this.ra("ATSI");
			string text = this.ra("ATKW");
			this.string_7 = text.Replace("1:", "").Replace("2:", "").Replace("3:", "").Replace("4:", "").Replace("C:", "").Replace(">", "").Replace("\r", "").Replace("\n", "");
			try
			{
				this.string_7 = GClass127.smethod_11(GClass127.smethod_32(this.string_7));
			}
			catch (Exception)
			{
			}
			GClass126.smethod_2("ECU ISO Code: " + this.string_7, 0);
			this.ra("STIP4 6");
			this.ra("STPO");
			string text2 = "090B";
			if (this.string_0 == "CLIMA25" || this.string_0 == "IAW1AF")
			{
				this.ra("345188");
				this.ra("00000004");
				text2 = "09000C";
			}
			this.ra(text2 + "1");
			Thread.Sleep(100);
			if (!this.ra(text2 + "1").Replace(" ", "").Contains(text2))
			{
				throw new Exception("Connection failed!");
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_7 = "";
			throw new Exception("0");
		}
		GClass126.smethod_2("ECU wakeup completed", 1);
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x0005E9EC File Offset: 0x0005CBEC
	private string method_58()
	{
		if (GClass125.smethod_48())
		{
			return this.method_59();
		}
		if (GClass125.smethod_52())
		{
			return this.method_60();
		}
		string text = "";
		while (!text.EndsWith(">") && text.Length < 17)
		{
			text += ((char)this.serialPort_0.ReadByte()).ToString();
			text = text.Replace("\r", "").Replace("\n", "");
		}
		GClass126.smethod_2("Response:" + text, 0);
		return text;
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x0005EA84 File Offset: 0x0005CC84
	private string method_59()
	{
		string text = "";
		long num = (long)(GClass126.smethod_1() + 3500);
		while (!text.EndsWith(">") && num > (long)GClass126.smethod_1() && text.Length < 17)
		{
			if (this.tcpClient_0.Client.Available > 0)
			{
				int num2 = this.tcpClient_0.GetStream().ReadByte();
				if (num2 != -1)
				{
					text += ((char)num2).ToString();
					text = text.Replace("\r", "").Replace("\n", "");
				}
				num = (long)(GClass126.smethod_1() + 2500);
			}
			else
			{
				Thread.Sleep(5);
			}
		}
		if (text == "" && num <= (long)GClass126.smethod_1())
		{
			throw new Exception("TCP timeout!");
		}
		GClass126.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x0005EB74 File Offset: 0x0005CD74
	private string method_60()
	{
		string text = "";
		long num = (long)(GClass126.smethod_1() + 3500);
		while (!text.EndsWith(">") && num > (long)GClass126.smethod_1() && text.Length < 17)
		{
			if (this.stringBuilder_0.Length > 0)
			{
				text += this.stringBuilder_0[0].ToString();
				text = text.Replace("\r", "").Replace("\n", "");
				this.stringBuilder_0.Remove(0, 1);
				num = (long)(GClass126.smethod_1() + 2500);
			}
			else
			{
				Thread.Sleep(5);
			}
		}
		GClass126.smethod_2("Response: " + text, 0);
		return text;
	}
}
