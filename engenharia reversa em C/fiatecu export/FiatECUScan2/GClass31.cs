using System;
using System.IO.Ports;
using System.Threading;

// Token: 0x02000086 RID: 134
public sealed class GClass31 : GClass28
{
	// Token: 0x060004DB RID: 1243 RVA: 0x0008FAB4 File Offset: 0x0008DCB4
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
			GClass3.smethod_2("Init OBDLink and Wakeup ECU.", 1);
			this.serialPort_0.ReadTimeout = 5000;
			base.method_43("ATZ");
			GClass3.smethod_2("Init OBDLink interface", 1);
			string text = base.method_45();
			if (!text.Contains("ELM32"))
			{
				GClass3.smethod_2("Invalid OBDLink interface!", 1);
			}
			this.serialPort_0.ReadTimeout = 3000;
			base.method_44("ATE0");
			base.method_44("ATL0");
			base.method_44("ATSP4");
			base.method_44("STIBR4800");
			base.method_44("STIMCS1");
			base.method_44("ATKW0");
			base.method_44("ATIIA " + GClass16.smethod_0(this.byte_0));
			base.method_44("ATH0");
			base.method_44("ATSW00");
			base.method_44("ATSH 010000");
			Thread.Sleep(100);
			base.method_44("ATSI");
			string text2 = "090B";
			if (this.string_0 == "CLIMA25")
			{
				base.method_44("345188");
				base.method_44("00000004");
				text2 = "09000C";
			}
			base.method_44(text2);
			Thread.Sleep(100);
			string text3 = base.method_44(text2);
			if (!text3.Replace(" ", string.Empty).Contains(text2))
			{
				throw new Exception("Connection failed!");
			}
			string text4 = base.method_44("ATKW");
			this.string_3 = text4.Replace("1:", string.Empty).Replace("2:", string.Empty).Replace("3:", string.Empty).Replace("4:", string.Empty).Replace("C:", string.Empty).Replace(">", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
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
