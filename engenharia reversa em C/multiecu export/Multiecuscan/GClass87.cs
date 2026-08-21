using System;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;

// Token: 0x02000066 RID: 102
public sealed class GClass87 : GClass85
{
	// Token: 0x060003A4 RID: 932 RVA: 0x0005D918 File Offset: 0x0005BB18
	protected override void r6()
	{
		try
		{
			if (GClass125.smethod_48())
			{
				this.tcpClient_0 = new TcpClient();
				this.tcpClient_0.Connect(GClass125.smethod_50(), GClass125.smethod_51());
				if (!this.tcpClient_0.Connected)
				{
					throw new Exception("WiFi device not connected!");
				}
				GClass126.smethod_2("WiFi device connect successfull!", 0);
				this.string_12 = "\r";
				for (int i = 0; i < 5; i++)
				{
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(100);
				}
			}
			else
			{
				this.serialPort_0 = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
				this.serialPort_0.WriteBufferSize = 2;
				this.serialPort_0.WriteTimeout = 5000;
				this.serialPort_0.ReceivedBytesThreshold = 1000;
				this.serialPort_0.Handshake = Handshake.None;
				this.serialPort_0.NewLine = "\r";
				this.serialPort_0.Open();
				GClass126.smethod_2("Serial port opened!", 1);
				this.serialPort_0.ReadTimeout = 5000;
			}
			GClass126.smethod_2("Init OBDKey and Wakeup ECU.", 1);
			this.r9("ATZ");
			GClass126.smethod_2("Init OBDKey interface", 1);
			if (!this.rb().Contains("OBDKey"))
			{
				GClass126.smethod_2("Invalid OBDKey interface!", 1);
				throw new Exception("Invalid OBDKey interface!");
			}
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 3000;
			}
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATSP3");
			this.ra("ATT1");
			this.ra("ATSH4607" + GClass127.smethod_23(this.byte_0));
			this.ra("ATI5");
			this.ra("ATW4");
			Thread.Sleep(200);
			string text = this.ra("ATKB");
			this.string_7 = text.Replace("1:", "").Replace("2:", "").Replace("3:", "").Replace("4:", "").Replace("5:", "").Replace(">", "").Replace("\r", "").Replace("\n", "");
			try
			{
				this.string_7 = GClass127.smethod_11(GClass127.smethod_32(this.string_7));
			}
			catch (Exception)
			{
			}
			GClass126.smethod_2("ECU ISO Code: " + this.string_7, 0);
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			throw new Exception("0");
		}
		GClass126.smethod_2("ECU wakeup completed", 1);
	}
}
