using System;
using System.IO.Ports;

// Token: 0x02000034 RID: 52
public sealed class GClass45 : GClass44
{
	// Token: 0x060002A1 RID: 673 RVA: 0x000414DC File Offset: 0x0003F6DC
	protected override void r6()
	{
		try
		{
			this.serialPort_0 = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
			this.serialPort_0.WriteBufferSize = 2;
			this.serialPort_0.WriteTimeout = 5000;
			this.serialPort_0.ReceivedBytesThreshold = 1000;
			this.serialPort_0.ReadBufferSize = 1000;
			this.serialPort_0.Handshake = Handshake.None;
			this.serialPort_0.NewLine = "\n\r";
			this.serialPort_0.Open();
			GClass126.smethod_2("Serial port opened!", 1);
			GClass126.smethod_2("Init CANtieCAR and Wakeup ECU.", 1);
			if (GClass125.smethod_46())
			{
				this.serialPort_0.ReadTimeout = 6000;
			}
			else
			{
				this.serialPort_0.ReadTimeout = 3000;
			}
			this.r9("ATZ");
			GClass126.smethod_2("Init CANtieCAR interface - PINS " + this.string_3, 1);
			if (!this.rb().Contains("ECUScan v3.4+"))
			{
				GClass126.smethod_2("Invalid CANtieCAR interface!", 1);
			}
			GClass126.smethod_2("Checking 11/500 kbps CAN...", 1);
			this.ra("AT PP 2C SV 80");
			this.ra("AT PP 2C ON");
			this.ra("AT PP 2D SV 01");
			this.ra("AT PP 2D ON");
			this.r9("ATZ");
			this.rb();
			if (GClass125.smethod_47())
			{
				this.serialPort_0.ReadTimeout = 500;
			}
			this.ra("ATCSM1");
			this.ra("ATSPB");
			this.ra("ATMC" + this.string_3);
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
				GClass126.smethod_2("11/500kbps CAN detected", 1);
				this.string_10 = "11/500";
			}
			GClass126.smethod_2("Checking 29/500 kbps CAN...", 1);
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
			this.ra("AT PP 2C SV 40");
			this.ra("AT PP 2C ON");
			this.ra("AT PP 2D SV 01");
			this.ra("AT PP 2D ON");
			this.r9("ATZ");
			this.rb();
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 500;
			}
			this.ra("ATCSM1");
			this.ra("ATSPB");
			this.ra("ATMC" + this.string_3);
			this.ra("ATH1");
			this.ra("ATAL");
			this.ra("ATD0");
			this.ra("ATS0");
			this.ra("ATL0");
			this.ra("ATE0");
			this.r9("ATMA");
			text = "";
			text2 = "";
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
				GClass126.smethod_2("29/500kbps CAN detected", 1);
				this.string_10 = "29/500";
			}
			GClass126.smethod_2("Checking 11/125 kbps CAN...", 1);
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
			this.ra("AT PP 2C SV 80");
			this.ra("AT PP 2C ON");
			this.ra("AT PP 2D SV 04");
			this.ra("AT PP 2D ON");
			this.r9("ATZ");
			this.rb();
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 500;
			}
			this.ra("ATCSM1");
			this.ra("ATSPB");
			this.ra("ATMC" + this.string_3);
			this.ra("ATH1");
			this.ra("ATAL");
			this.ra("ATD0");
			this.ra("ATS0");
			this.ra("ATL0");
			this.ra("ATE0");
			this.r9("ATMA");
			text = "";
			text2 = "";
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
				GClass126.smethod_2("11/125kbps CAN detected", 1);
				this.string_10 = "11/125";
			}
			GClass126.smethod_2("Checking 29/125 kbps CAN...", 1);
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
			this.ra("AT PP 2C SV 40");
			this.ra("AT PP 2C ON");
			this.ra("AT PP 2D SV 04");
			this.ra("AT PP 2D ON");
			this.r9("ATZ");
			this.rb();
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 500;
			}
			this.ra("ATCSM1");
			this.ra("ATSPB");
			this.ra("ATMC" + this.string_3);
			this.ra("ATH1");
			this.ra("ATAL");
			this.ra("ATD0");
			this.ra("ATS0");
			this.ra("ATL0");
			this.ra("ATE0");
			this.r9("ATMA");
			text = "";
			text2 = "";
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
				GClass126.smethod_2("29/125kbps CAN detected", 1);
				this.string_10 = "29/125";
			}
			GClass126.smethod_2("Checking 11/50 kbps CAN...", 1);
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
			this.ra("AT PP 2C SV 80");
			this.ra("AT PP 2C ON");
			this.ra("AT PP 2D SV 0A");
			this.ra("AT PP 2D ON");
			this.r9("ATZ");
			this.rb();
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 500;
			}
			this.ra("ATCSM1");
			this.ra("ATSPB");
			this.ra("ATMC" + this.string_3);
			this.ra("ATH1");
			this.ra("ATAL");
			this.ra("ATD0");
			this.ra("ATS0");
			this.ra("ATL0");
			this.ra("ATE0");
			this.r9("ATMA");
			text = "";
			text2 = "";
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
				GClass126.smethod_2("11/50kbps CAN detected", 1);
				this.string_10 = "11/50";
			}
			GClass126.smethod_2("Checking 29/50 kbps CAN...", 1);
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
			this.ra("AT PP 2C SV 40");
			this.ra("AT PP 2C ON");
			this.ra("AT PP 2D SV 0A");
			this.ra("AT PP 2D ON");
			this.r9("ATZ");
			this.rb();
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 500;
			}
			this.ra("ATCSM1");
			this.ra("ATSPB");
			this.ra("ATMC" + this.string_3);
			this.ra("ATH1");
			this.ra("ATAL");
			this.ra("ATD0");
			this.ra("ATS0");
			this.ra("ATL0");
			this.ra("ATE0");
			this.r9("ATMA");
			text = "";
			text2 = "";
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
				GClass126.smethod_2("29/50kbps CAN detected", 1);
				this.string_10 = "29/50";
			}
			this.ra("ATZ");
			if (this.string_10 != "")
			{
				GClass126.smethod_2("CAN NETWORK DETECTED " + this.string_10 + " on pins " + this.string_3, 1);
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
