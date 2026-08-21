using System;
using System.IO.Ports;
using System.Threading;

// Token: 0x0200008F RID: 143
public sealed class GClass27 : GClass25
{
	// Token: 0x06000527 RID: 1319 RVA: 0x00095C88 File Offset: 0x00093E88
	protected override void vmethod_8(GEnum0 genum0_0)
	{
		try
		{
			this.serialPort_0 = new SerialPort(GClass61.smethod_39(), GClass61.smethod_41(), Parity.None, 8, StopBits.One);
			this.serialPort_0.WriteBufferSize = 2;
			this.serialPort_0.ReceivedBytesThreshold = 1000;
			this.serialPort_0.Handshake = Handshake.None;
			this.serialPort_0.NewLine = "\n\r";
			this.serialPort_0.Open();
			GClass3.smethod_2("Serial port opened!", 1);
			GClass3.smethod_2("Init CANtieCAR and Wakeup ECU.", 1);
			this.serialPort_0.ReadTimeout = 5000;
			base.method_39("ATZ");
			GClass3.smethod_2("Init CANtieCAR interface", 1);
			string text = base.method_41();
			if (!text.Contains("FiatECUScan v3.4+"))
			{
				GClass3.smethod_2("Invalid CANtieCAR interface!", 1);
				throw new Exception("Invalid CANtieCAR interface!");
			}
			this.serialPort_0.ReadTimeout = 3000;
			string text2 = "OK";
			base.method_40("ATE0");
			base.method_40("ATL0");
			base.method_40("ATSPW");
			base.method_40("ATIB48");
			base.method_40("ATIIA " + GClass16.smethod_0(this.byte_0));
			if (this.string_2 != "70" && this.string_2 != string.Empty)
			{
				text2 = base.method_40("ATMI" + this.string_2);
			}
			base.method_40("ATH0");
			base.method_40("ATIF");
			base.method_40("ATSW00");
			string text3 = base.method_40("ATAT?");
			Thread.Sleep(100);
			string text4 = base.method_40("ATSI");
			if (genum0_0 == (GEnum0)0 && !text4.Contains("..OK") && this.string_2 != "70" && this.string_2 != string.Empty)
			{
				Thread.Sleep(200);
				text2 = base.method_40("ATMI 70");
				Thread.Sleep(100);
				text4 = base.method_40("ATSI");
			}
			if (genum0_0 == (GEnum0)0 && !text4.Contains("..OK") && this.string_2 != "70" && this.string_2 != "10" && this.string_2 != string.Empty)
			{
				Thread.Sleep(200);
				text2 = base.method_40("ATMI 10");
				Thread.Sleep(100);
				text4 = base.method_40("ATSI");
			}
			string text5 = "09";
			base.method_40(text5);
			Thread.Sleep(100);
			string text6 = base.method_40(text5);
			if (!text6.Replace(" ", string.Empty).Contains(text5) || !text2.Contains("OK") || !text3.Contains("ms"))
			{
				throw new Exception("CANtieCAR->ECU Connection failed!");
			}
			string text7 = base.method_40("ATKW");
			this.string_3 = text7.Replace("1:", string.Empty).Replace("2:", string.Empty).Replace("3:", string.Empty).Replace("4:", string.Empty).Replace("C:", string.Empty).Replace(">", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
			try
			{
				this.string_3 = GClass16.smethod_1(GClass16.smethod_2(this.string_3));
			}
			catch (Exception)
			{
			}
			GClass3.smethod_2("ECU ISO Code: " + this.string_3, 2);
		}
		catch (Exception ex)
		{
			GClass3.smethod_2(ex.Message, 1);
			throw new Exception("0");
		}
		GClass3.smethod_2("ECU wakeup completed", 1);
	}
}
