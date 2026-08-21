using System;
using System.IO.Ports;
using System.Threading;

// Token: 0x02000026 RID: 38
public sealed class GClass29 : GClass28
{
	// Token: 0x060001A7 RID: 423 RVA: 0x00050B40 File Offset: 0x0004ED40
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
				this.serialPort_0.WriteLine("ATBRD16");
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
			this.serialPort_0.ReadTimeout = 3000;
			base.method_44("ATE0");
			base.method_44("ATL0");
			base.method_44("ATIIA " + GClass16.smethod_0(this.byte_0));
			base.method_44("ATSP3");
			base.method_44("ATIB48");
			if (this.string_0 == "CLIMA25")
			{
				base.method_44("ATWM 03345188");
			}
			else
			{
				base.method_44("ATWM 02090B");
			}
			base.method_44("ATT1");
			base.method_44("ATI5");
			base.method_44("ATI0");
			Thread.Sleep(100);
			base.method_44("ATK");
			string text3 = base.method_44("ATKB");
			string text4 = "02090B";
			if (this.string_0 == "CLIMA25")
			{
				base.method_44("03345188");
				base.method_44("0400000004");
				text4 = "0309000C";
			}
			Thread.Sleep(100);
			string text5 = base.method_44(text4);
			if (!text5.Replace(" ", string.Empty).Contains(text4))
			{
				throw new Exception("Connection failed!");
			}
			this.string_3 = text3.Replace("1:", string.Empty).Replace("2:", string.Empty).Replace("3:", string.Empty).Replace("4:", string.Empty).Replace("5:", string.Empty).Replace(">", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
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
