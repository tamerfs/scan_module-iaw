using System;
using System.IO.Ports;

// Token: 0x02000028 RID: 40
public sealed class GClass34 : GClass33
{
	// Token: 0x060001C1 RID: 449 RVA: 0x00053938 File Offset: 0x00051B38
	protected override void vmethod_8()
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
			base.method_43("ATZ");
			GClass3.smethod_2("Init ELM327 interface", 1);
			string text = base.method_45();
			if (!text.Contains("ELM32"))
			{
				GClass3.smethod_2("Invalid ELM interface!", 1);
			}
			if (!GClass3.bool_12)
			{
				base.method_44("AT PP 2C SV 41");
				base.method_44("AT PP 2C ON");
				base.method_44("AT PP 2D SV 01");
				base.method_44("AT PP 2D ON");
				base.method_43("ATZ");
				text = base.method_45();
			}
			if (GClass61.smethod_38())
			{
				this.serialPort_0.ReadTimeout = 2000;
			}
			else
			{
				this.serialPort_0.ReadTimeout = 1500;
			}
			base.method_44("ATE0");
			base.method_44("ATL0");
			base.method_44("ATH0");
			if (GClass3.bool_12)
			{
				base.method_44("ATSP7");
			}
			else
			{
				base.method_44("ATSPB");
			}
			base.method_44("ATS0");
			base.method_44("ATAL");
			base.method_44("ATCP 18");
			base.method_44("ATCRA 18DAF1" + GClass16.smethod_0(this.byte_0));
			base.method_44("ATSH DA" + GClass16.smethod_0(this.byte_0) + "F1");
			base.method_44("ATAT1");
			if (!GClass3.bool_12)
			{
				base.method_44("ATST99");
			}
			else
			{
				base.method_44("ATST21");
			}
			byte[] array = base.method_42(this.byte_3);
			if (array.Length < 3 || array[1] != 80 || array[2] != 3)
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
