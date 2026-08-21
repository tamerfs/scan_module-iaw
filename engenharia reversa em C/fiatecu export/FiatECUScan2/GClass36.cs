using System;
using System.IO.Ports;

// Token: 0x02000071 RID: 113
public sealed class GClass36 : GClass33
{
	// Token: 0x060003A2 RID: 930 RVA: 0x000778A0 File Offset: 0x00075AA0
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
			GClass3.smethod_2("Init CANtieCAR and Wakeup ECU.", 1);
			if (GClass61.smethod_38())
			{
				this.serialPort_0.ReadTimeout = 5000;
			}
			else
			{
				this.serialPort_0.ReadTimeout = 3000;
			}
			base.method_43("ATZ");
			GClass3.smethod_2("Init CANtieCAR interface", 1);
			string text = base.method_45();
			if (!text.Contains("FiatECUScan v3.4+"))
			{
				GClass3.smethod_2("Invalid CANtieCAR interface!", 1);
				throw new Exception("Invalid CANtieCAR interface!");
			}
			if (!GClass3.bool_12)
			{
				base.method_44("AT PP 2C SV 41");
				base.method_44("AT PP 2C ON");
				base.method_44("AT PP 2D SV 0A");
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
			string text2 = base.method_44("ATMC19");
			if (!GClass3.bool_12)
			{
				base.method_44("ATST82");
			}
			else
			{
				base.method_44("ATST21");
			}
			string text3 = base.method_44("ATAT?");
			byte[] array = base.method_42(this.byte_3);
			if (array.Length < 3 || array[1] != 80 || array[2] != 3 || !text2.Contains("OK") || !text3.Contains("ms"))
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
