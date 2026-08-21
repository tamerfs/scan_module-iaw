using System;
using System.IO.Ports;

// Token: 0x02000053 RID: 83
public sealed class GClass22 : GClass20
{
	// Token: 0x06000221 RID: 545 RVA: 0x0005BDC4 File Offset: 0x00059FC4
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
			GClass3.smethod_2("Init ELM and Wakeup ECU.", 1);
			if (GClass61.smethod_38())
			{
				this.serialPort_0.ReadTimeout = 5000;
			}
			else
			{
				this.serialPort_0.ReadTimeout = 3000;
			}
			base.method_42("ATZ");
			GClass3.smethod_2("Init ELM327 interface", 1);
			string text = base.method_44();
			if (!text.Contains("ELM32"))
			{
				GClass3.smethod_2("Invalid ELM interface!", 1);
			}
			if (GClass61.smethod_38())
			{
				this.serialPort_0.ReadTimeout = 2000;
			}
			else
			{
				this.serialPort_0.ReadTimeout = 1000;
			}
			base.method_43("ATE0");
			base.method_43("ATL0");
			base.method_43("ATIB10");
			base.method_43("ATSP5");
			base.method_43("ATS0");
			base.method_43("ATAL");
			base.method_43("ATST 62");
			base.method_43("ATSH 81" + GClass16.smethod_0(this.byte_0) + "F1");
			string text2 = base.method_43("1A97");
			if (!text2.Contains("OK"))
			{
				throw new Exception("ELM327->ECU Connection failed!");
			}
		}
		catch (Exception ex)
		{
			GClass3.smethod_2(ex.Message, 1);
			this.string_4 = ex.Message;
			throw new Exception("0");
		}
		GClass3.smethod_2("ECU wakeup completed", 1);
	}
}
