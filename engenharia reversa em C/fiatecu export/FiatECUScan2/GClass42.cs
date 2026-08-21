using System;
using System.IO.Ports;

// Token: 0x0200002E RID: 46
public sealed class GClass42 : GClass40
{
	// Token: 0x06000205 RID: 517 RVA: 0x0005B27C File Offset: 0x0005947C
	protected override void vmethod_8()
	{
		try
		{
			this.serialPort_0 = new SerialPort(GClass61.smethod_39(), GClass61.smethod_41(), Parity.None, 8, StopBits.One);
			this.serialPort_0.WriteBufferSize = 2;
			this.serialPort_0.ReceivedBytesThreshold = 1000;
			this.serialPort_0.ReadBufferSize = 1000;
			this.serialPort_0.Handshake = Handshake.None;
			this.serialPort_0.NewLine = "\n\r";
			this.serialPort_0.Open();
			GClass3.smethod_2("Serial port opened!", 1);
			GClass3.smethod_2("Init ELM and Wakeup ECU.", 1);
			if (GClass61.smethod_38())
			{
				this.serialPort_0.ReadTimeout = 6000;
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
			base.method_43("AT PP 2C SV 81");
			base.method_43("AT PP 2C ON");
			base.method_43("AT PP 2D SV 0A");
			base.method_43("AT PP 2D ON");
			base.method_42("ATZ");
			text = base.method_44();
			this.serialPort_0.ReadTimeout = 2000;
			base.method_43("ATE0");
			base.method_43("ATL0");
			base.method_43("ATH0");
			base.method_43("ATAL");
			base.method_43("ATSPB");
			base.method_43("ATS0");
			base.method_43("ATCAF0");
			base.method_43("ATCFC0");
			base.method_43("ATCRA " + this.string_1);
			base.method_43("ATSH 7B0");
			base.method_43("ATAT1");
			this.string_7 = "ATST28";
			base.method_43(this.string_7);
			byte[] array = base.method_41(this.byte_3);
			if (array.Length < 3 || array[1] != 80 || array[2] != 129)
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
