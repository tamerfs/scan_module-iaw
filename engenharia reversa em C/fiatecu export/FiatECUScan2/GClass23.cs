using System;
using System.IO.Ports;
using System.Threading;

// Token: 0x02000063 RID: 99
public sealed class GClass23 : GClass20
{
	// Token: 0x0600032B RID: 811 RVA: 0x000032D8 File Offset: 0x000014D8
	public GClass23()
	{
		this.int_6 = 70;
	}

	// Token: 0x0600032C RID: 812 RVA: 0x0006D9A0 File Offset: 0x0006BBA0
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
			base.method_42("ATZ");
			GClass3.smethod_2("Init OBDKey interface", 1);
			string text = base.method_44();
			if (!text.Contains("OBDKey"))
			{
				GClass3.smethod_2("Invalid OBDKey interface!", 1);
				throw new Exception("Invalid OBDKey interface!");
			}
			if (GClass61.smethod_36() == 4)
			{
				this.serialPort_0.ReadTimeout = 100;
				base.method_42("ATBRD16");
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
				base.method_43(string.Empty);
			}
			this.serialPort_0.ReadTimeout = 5000;
			base.method_43("ATE0");
			base.method_43("ATL0");
			base.method_43("ATIB10");
			base.method_43("ATSP5");
			base.method_43("ATAL");
			base.method_43("ATS0");
			base.method_43("ATSH 81" + GClass16.smethod_0(this.byte_0) + "F1");
			Thread.Sleep(100);
			string text3 = base.method_43("1A97");
			if (!text3.Contains("OK"))
			{
				throw new Exception("OBDKey->ECU Connection failed!");
			}
			this.serialPort_0.ReadTimeout = 1000;
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
