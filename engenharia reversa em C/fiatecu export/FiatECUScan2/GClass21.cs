using System;
using System.IO.Ports;

// Token: 0x0200000C RID: 12
public sealed class GClass21 : GClass20
{
	// Token: 0x06000044 RID: 68 RVA: 0x0001A01C File Offset: 0x0001821C
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
			if (GClass61.smethod_38())
			{
				this.serialPort_0.ReadTimeout = 5000;
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
			base.method_43("ATAT1");
			base.method_43("ATST 62");
			base.method_43("ATSH 81" + GClass16.smethod_0(this.byte_0) + "F1");
			string text2 = base.method_43("ATAT?");
			string text3 = "OK";
			if (this.string_2 != "70" && this.string_2 != string.Empty)
			{
				text3 = base.method_43("ATMI" + this.string_2);
			}
			string text4 = base.method_43("ATFI");
			if (genum0_0 == (GEnum0)0 && !text4.Contains("OK") && this.string_2 != "70" && this.string_2 != string.Empty)
			{
				text3 = base.method_43("ATMI70");
				text4 = base.method_43("ATFI");
			}
			if (genum0_0 == (GEnum0)0 && !text4.Contains("OK") && this.string_2 != "70" && this.string_2 != "10" && this.string_2 != string.Empty)
			{
				text3 = base.method_43("ATMI10");
				text4 = base.method_43("ATFI");
			}
			if (genum0_0 == (GEnum0)0 && !text4.Contains("OK") && this.string_2 != "70" && this.string_2 != "C0" && this.string_2 != string.Empty)
			{
				text3 = base.method_43("ATMIC0");
				text4 = base.method_43("ATFI");
			}
			if (genum0_0 == (GEnum0)0 && !text4.Contains("OK") && this.string_2 != "70" && this.string_2 != "90" && this.string_2 != string.Empty)
			{
				text3 = base.method_43("ATMI90");
				text4 = base.method_43("ATFI");
			}
			if (!text4.Contains("OK") || !text3.Contains("OK") || !text2.Contains("ms"))
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
