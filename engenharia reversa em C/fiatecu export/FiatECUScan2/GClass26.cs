using System;
using System.IO.Ports;
using System.Threading;

// Token: 0x02000059 RID: 89
public sealed class GClass26 : GClass25
{
	// Token: 0x06000265 RID: 613 RVA: 0x00060924 File Offset: 0x0005EB24
	protected override void vmethod_8(GEnum0 genum0_0)
	{
		try
		{
			this.serialPort_0 = new SerialPort(GClass61.smethod_39(), GClass61.smethod_41(), Parity.None, 8, StopBits.One);
			this.serialPort_0.WriteBufferSize = 2;
			this.serialPort_0.ReceivedBytesThreshold = 1000;
			this.serialPort_0.Handshake = Handshake.None;
			this.serialPort_0.NewLine = "\r";
			this.serialPort_0.Open();
			GClass3.smethod_2("Serial port opened!", 1);
			GClass3.smethod_2("Init OBDKey and Wakeup ECU.", 1);
			this.serialPort_0.ReadTimeout = 5000;
			base.method_39("ATZ");
			GClass3.smethod_2("Init OBDKey interface", 1);
			string text = base.method_41();
			if (!text.Contains("OBDKey"))
			{
				GClass3.smethod_2("Invalid OBDKey interface!", 1);
				throw new Exception("Invalid OBDKey interface!");
			}
			this.serialPort_0.ReadTimeout = 3000;
			base.method_40("ATE0");
			base.method_40("ATL0");
			base.method_40("ATSP3");
			base.method_40("ATT1");
			base.method_40("ATSH4607" + GClass16.smethod_0(this.byte_0));
			base.method_40("ATI5");
			base.method_40("ATW4");
			Thread.Sleep(200);
			string text2 = base.method_40("ATKB");
			this.string_3 = text2.Replace("1:", string.Empty).Replace("2:", string.Empty).Replace("3:", string.Empty).Replace("4:", string.Empty).Replace("5:", string.Empty).Replace(">", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
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
