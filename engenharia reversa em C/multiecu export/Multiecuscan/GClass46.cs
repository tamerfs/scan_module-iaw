using System;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;

// Token: 0x02000047 RID: 71
public sealed class GClass46 : GClass44
{
	// Token: 0x060002D0 RID: 720 RVA: 0x00046EA8 File Offset: 0x000450A8
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
				for (int i = 0; i < 5; i++)
				{
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(100);
				}
				this.string_12 = "\r";
			}
			else
			{
				this.serialPort_0 = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
				this.serialPort_0.WriteBufferSize = 2;
				this.serialPort_0.WriteTimeout = 5000;
				this.serialPort_0.ReceivedBytesThreshold = 1000;
				this.serialPort_0.ReadBufferSize = 1000;
				this.serialPort_0.Handshake = Handshake.None;
				this.serialPort_0.NewLine = "\r";
				this.serialPort_0.Open();
				GClass126.smethod_2("Serial port opened!", 1);
			}
			GClass126.smethod_2("Checking 500 kbps CAN...", 1);
			this.r9("ATZ");
			if (!this.rb().Contains("ELM32"))
			{
				GClass126.smethod_2("Invalid ELM interface!", 1);
			}
			this.ra("AT PP 2C SV 61");
			this.ra("AT PP 2C ON");
			this.ra("AT PP 2D SV 01");
			this.ra("AT PP 2D ON");
			this.r9("ATZ");
			this.rb();
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 2000;
			}
			this.ra("ATSPB");
			this.ra("ATH1");
			this.ra("ATAL");
			this.ra("ATD0");
			this.ra("ATS0");
			this.ra("ATL0");
			this.ra("ATE0");
			this.r9("ATMA");
			string text = "";
			string text2 = "";
			try
			{
				text = base.method_46();
				text2 = base.method_46();
			}
			catch (Exception)
			{
			}
			this.r9("");
			try
			{
				this.rb();
				this.rb();
			}
			catch (Exception)
			{
			}
			if (text.Length > 3 && !text.Contains("ERROR") && !text.Contains("STOP") && text2.Length > 3 && !text2.Contains("ERROR") && !text2.Contains("STOP"))
			{
				GClass126.smethod_2("500kbps CAN detected", 1);
				this.string_10 = "xx/500";
			}
			GClass126.smethod_2("Checking 125 kbps CAN...", 1);
			if (this.serialPort_0 != null)
			{
				if (GClass125.smethod_46())
				{
					this.serialPort_0.ReadTimeout = 6000;
				}
				else
				{
					this.serialPort_0.ReadTimeout = 3000;
				}
			}
			this.r9("ATZ");
			this.rb();
			this.ra("AT PP 2C SV 61");
			this.ra("AT PP 2C ON");
			this.ra("AT PP 2D SV 04");
			this.ra("AT PP 2D ON");
			this.r9("ATZ");
			this.rb();
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 2000;
			}
			this.ra("ATSPB");
			this.ra("ATH1");
			this.ra("ATAL");
			this.ra("ATD0");
			this.ra("ATS0");
			this.ra("ATL0");
			this.ra("ATE0");
			this.r9("ATMA");
			try
			{
				text = base.method_46();
				text2 = base.method_46();
			}
			catch (Exception)
			{
			}
			this.r9("");
			try
			{
				this.rb();
				this.rb();
			}
			catch (Exception)
			{
			}
			if (text.Length > 3 && !text.Contains("ERROR") && !text.Contains("STOP") && text2.Length > 3 && !text2.Contains("ERROR") && !text2.Contains("STOP"))
			{
				GClass126.smethod_2("125kbps CAN detected", 1);
				this.string_10 = "xx/125";
			}
			GClass126.smethod_2("Checking 50 kbps CAN...", 1);
			if (this.serialPort_0 != null)
			{
				if (GClass125.smethod_46())
				{
					this.serialPort_0.ReadTimeout = 6000;
				}
				else
				{
					this.serialPort_0.ReadTimeout = 3000;
				}
			}
			this.r9("ATZ");
			this.rb();
			this.ra("AT PP 2C SV 61");
			this.ra("AT PP 2C ON");
			this.ra("AT PP 2D SV 0A");
			this.ra("AT PP 2D ON");
			this.r9("ATZ");
			this.rb();
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 2000;
			}
			this.ra("ATSPB");
			this.ra("ATH1");
			this.ra("ATAL");
			this.ra("ATD0");
			this.ra("ATS0");
			this.ra("ATL0");
			this.ra("ATE0");
			this.r9("ATMA");
			try
			{
				text = base.method_46();
				text2 = base.method_46();
			}
			catch (Exception)
			{
			}
			this.r9("");
			try
			{
				this.rb();
				this.rb();
			}
			catch (Exception)
			{
			}
			if (text.Length > 3 && !text.Contains("ERROR") && !text.Contains("STOP") && text2.Length > 3 && !text2.Contains("ERROR") && !text2.Contains("STOP"))
			{
				GClass126.smethod_2("50kbps CAN detected", 1);
				this.string_10 = "xx/50";
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
