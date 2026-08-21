using System;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;

// Token: 0x02000065 RID: 101
public sealed class GClass84 : GClass81
{
	// Token: 0x060003A2 RID: 930 RVA: 0x0000335D File Offset: 0x0000155D
	public GClass84()
	{
		this.int_6 = 70;
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x0005D55C File Offset: 0x0005B75C
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
			if (GClass125.smethod_44() == 4)
			{
				this.serialPort_0.ReadTimeout = 100;
				this.r9("ATBRD16");
				string text = ((char)this.serialPort_0.ReadByte()).ToString() ?? "";
				while (!text.Contains("OK\r") && !text.Contains("?") && text.Length < 20)
				{
					text += ((char)this.serialPort_0.ReadByte()).ToString();
				}
				this.serialPort_0.BaudRate = 250000;
				this.serialPort_0.ReadTimeout = 80;
				text = (((char)this.serialPort_0.ReadByte()).ToString() ?? "");
				while (!text.Contains("\r") && text.Length < 20)
				{
					text += ((char)this.serialPort_0.ReadByte()).ToString();
				}
				this.ra("");
			}
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 5000;
			}
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATIB10");
			this.ra("ATSP5");
			this.ra("ATAL");
			this.ra("ATS0");
			this.ra("ATCEA 00");
			this.ra("ATSH 81" + GClass127.smethod_23(this.byte_0) + "F1");
			Thread.Sleep(100);
			string text2 = this.ra("1A97");
			if (this.ra("ATKW").Replace(" ", "").Contains("1:EA"))
			{
				this.ra("ATSH 80" + GClass127.smethod_23(this.byte_0) + "F1");
			}
			if (!text2.Contains("OK"))
			{
				throw new Exception("OBDKey->ECU Connection failed!");
			}
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 1000;
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_8 = ex.Message;
			throw new Exception("0");
		}
		GClass126.smethod_2("ECU wakeup completed", 1);
	}
}
