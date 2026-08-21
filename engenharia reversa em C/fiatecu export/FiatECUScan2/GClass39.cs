using System;
using System.IO.Ports;

// Token: 0x0200008D RID: 141
public sealed class GClass39 : GClass33
{
	// Token: 0x06000520 RID: 1312 RVA: 0x000958C4 File Offset: 0x00093AC4
	protected override void vmethod_8()
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
			if (GClass61.smethod_38())
			{
				this.serialPort_0.ReadTimeout = 5000;
			}
			else
			{
				this.serialPort_0.ReadTimeout = 3000;
			}
			base.method_43("ATZ");
			GClass3.smethod_2("Init OBDKey interface", 1);
			string text = base.method_45();
			if (!text.Contains("OBDKey"))
			{
				GClass3.smethod_2("Invalid OBDKey interface!", 1);
				throw new Exception("Invalid OBDKey interface!");
			}
			if (GClass61.smethod_36() == 4)
			{
				this.serialPort_0.ReadTimeout = 100;
				base.method_43("ATBRD16");
				string text2 = string.Concat((char)this.serialPort_0.ReadByte());
				while (!text2.Contains("OK\r") && !text2.Contains("?") && text2.Length < 20)
				{
					text2 += (char)this.serialPort_0.ReadByte();
				}
				this.serialPort_0.BaudRate = 250000;
				this.serialPort_0.ReadTimeout = 80;
				text2 = string.Concat((char)this.serialPort_0.ReadByte());
				while (!text2.Contains("\r") && text2.Length < 20)
				{
					text2 += (char)this.serialPort_0.ReadByte();
				}
				base.method_44(string.Empty);
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
			base.method_44("ATSP7");
			base.method_44("ATS0");
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
			base.method_44("ATV1");
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
