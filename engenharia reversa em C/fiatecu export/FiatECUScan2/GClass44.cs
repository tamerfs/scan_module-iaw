using System;
using System.IO.Ports;

// Token: 0x0200007E RID: 126
public sealed class GClass44 : GClass40
{
	// Token: 0x0600049D RID: 1181 RVA: 0x0008B9DC File Offset: 0x00089BDC
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
			GClass3.smethod_2("Init CANtieCAR and Wakeup ECU.", 1);
			if (GClass61.smethod_38())
			{
				this.serialPort_0.ReadTimeout = 6000;
			}
			else
			{
				this.serialPort_0.ReadTimeout = 3000;
			}
			base.method_42("ATZ");
			GClass3.smethod_2("Init CANtieCAR interface", 1);
			string text = base.method_44();
			if (!text.Contains("FiatECUScan v3.4+"))
			{
				GClass3.smethod_2("Invalid CANtieCAR interface!", 1);
				throw new Exception("Invalid CANtieCAR interface!");
			}
			this.serialPort_0.ReadTimeout = 2000;
			base.method_43("ATE0");
			base.method_43("ATL0");
			base.method_43("ATH0");
			base.method_43("ATS0");
			base.method_43("ATAL");
			base.method_43("ATCRA " + this.string_1);
			base.method_43("ATSH 7B0");
			base.method_43("ATSPC");
			string text2 = base.method_43("ATMC6E");
			base.method_43("ATBI");
			base.method_43("ATAT1");
			base.method_43("ATST28");
			string text3 = base.method_43("ATAT?");
			byte[] array = base.method_41(this.byte_3);
			if (array.Length < 3 || array[1] != 80 || array[2] != 129 || !text2.Contains("OK") || !text3.Contains("ms"))
			{
				throw new Exception("CANtieCAR->ECU Connection failed!");
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
