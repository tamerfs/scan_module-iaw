using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

// Token: 0x02000015 RID: 21
public sealed partial class FormTestELMConnection : Form
{
	// Token: 0x060000C1 RID: 193 RVA: 0x00021B04 File Offset: 0x0001FD04
	public FormTestELMConnection(string string_2, int int_2, int int_3)
	{
		this.InitializeComponent();
		this.string_1 = string_2;
		this.int_0 = int_2;
		this.int_1 = int_3;
		if ((int_3 == 4 || int_3 == 5) && !GClass55.smethod_4(string_2, int_2))
		{
			FormNotify formNotify = new FormNotify(GClass62.smethod_1("1070"), GClass62.smethod_1("1074"), GClass62.smethod_1("1075"), true, 0);
			formNotify.ShowDialog();
		}
		if (int_3 == 1)
		{
			new Thread(new ThreadStart(this.method_1)).Start();
		}
		else
		{
			new Thread(new ThreadStart(this.method_0)).Start();
		}
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x00021E00 File Offset: 0x00020000
	private void method_0()
	{
		if (this.int_1 == 5)
		{
			Thread.Sleep(4000);
		}
		if (this.int_1 == 4 || this.int_1 == 5)
		{
			this.string_0 = this.string_0 + "OBDKey..." + Environment.NewLine;
			this.bool_0 = false;
			GClass55.smethod_2(true, this.string_1, this.int_0);
			Thread.Sleep(4000);
		}
		try
		{
			this.serialPort_0 = new SerialPort(this.string_1, this.int_0, Parity.None, 8, StopBits.One);
			this.serialPort_0.WriteBufferSize = 2;
			this.serialPort_0.WriteTimeout = 2000;
			this.serialPort_0.ReceivedBytesThreshold = 1000;
			this.serialPort_0.Handshake = Handshake.None;
			if (this.int_1 == 4 || this.int_1 == 5)
			{
				this.serialPort_0.NewLine = "\r";
			}
			else
			{
				this.serialPort_0.NewLine = "\n\r";
			}
			this.serialPort_0.Open();
			this.serialPort_0.ReadTimeout = 2000;
			this.method_4("ATZ", true);
			if (this.int_1 == 4)
			{
				this.serialPort_0.ReadTimeout = 100;
				this.method_3("ATBRD16");
				string text = string.Concat((char)this.serialPort_0.ReadByte());
				while (!text.Contains("OK\r") && !text.Contains("?") && text.Length < 20)
				{
					text += (char)this.serialPort_0.ReadByte();
				}
				this.serialPort_0.BaudRate = 250000;
				this.serialPort_0.ReadTimeout = 100;
				text = string.Concat((char)this.serialPort_0.ReadByte());
				while (!text.Contains("\r") && text.Length < 20)
				{
					text += (char)this.serialPort_0.ReadByte();
				}
				this.method_4(string.Empty, false);
			}
			this.serialPort_0.ReadTimeout = 1000;
			string text2 = string.Empty;
			bool flag = true;
			bool flag2 = true;
			bool flag3 = false;
			text2 = this.method_4("ATI", true);
			if (text2.Contains("OBDKey"))
			{
				flag3 = true;
			}
			text2 = this.method_4("ATE0", true);
			if (!text2.Contains("OK"))
			{
				flag = false;
			}
			text2 = this.method_4("ATL0", true);
			if (!text2.Contains("OK"))
			{
				flag = false;
			}
			text2 = this.method_4("ATH0", true);
			if (!text2.Contains("OK"))
			{
				flag = false;
			}
			text2 = this.method_4("ATSPC", true);
			if (!text2.Contains("OK"))
			{
				flag = false;
			}
			text2 = this.method_4("ATS0", true);
			if (!text2.Contains("OK"))
			{
				flag = false;
			}
			text2 = this.method_4("ATCAF0", true);
			if (!text2.Contains("OK"))
			{
				flag = false;
			}
			text2 = this.method_4("ATCFC0", true);
			if (!text2.Contains("OK"))
			{
				flag = false;
			}
			text2 = this.method_4("ATCRA 7B0", true);
			if (!text2.Contains("OK"))
			{
				flag = false;
			}
			text2 = this.method_4("ATSH 7B0", true);
			if (!text2.Contains("OK"))
			{
				flag = false;
			}
			text2 = this.method_4("ATAT1", true);
			if (!text2.Contains("OK"))
			{
				flag = false;
			}
			text2 = this.method_4("ATST41", true);
			if (!text2.Contains("OK"))
			{
				flag = false;
			}
			text2 = this.method_4("ATBI", true);
			if (!text2.Contains("OK"))
			{
				flag = false;
			}
			text2 = this.method_4("ATSP4", false);
			if (!text2.Contains("OK"))
			{
				flag2 = false;
			}
			text2 = this.method_4("ATIB48", false);
			if (!text2.Contains("OK"))
			{
				flag2 = false;
			}
			try
			{
				this.serialPort_0.ReadTimeout = 100;
				text2 = this.method_4("ATZ", false);
			}
			catch (Exception)
			{
			}
			if (flag3)
			{
				this.string_0 = (this.string_0 ?? string.Empty);
			}
			else if (flag && flag2)
			{
				this.string_0 = this.string_0 + GClass62.smethod_1("1202") + Environment.NewLine;
			}
			else if (flag)
			{
				this.string_0 = this.string_0 + GClass62.smethod_1("1201") + Environment.NewLine;
			}
			else
			{
				this.string_0 = this.string_0 + GClass62.smethod_1("1200") + Environment.NewLine;
			}
			this.bool_0 = false;
		}
		catch (Exception ex)
		{
			this.string_0 = this.string_0 + ex.Message + Environment.NewLine;
			this.bool_0 = false;
		}
		finally
		{
			try
			{
				this.serialPort_0.Close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00022358 File Offset: 0x00020558
	private void method_1()
	{
		try
		{
			this.serialPort_0 = new SerialPort(this.string_1, this.int_0, Parity.None, 8, StopBits.One);
			this.serialPort_0.WriteBufferSize = 2;
			this.serialPort_0.WriteTimeout = 2000;
			this.serialPort_0.ReceivedBytesThreshold = 1000;
			this.serialPort_0.Handshake = Handshake.None;
			this.serialPort_0.Open();
			this.serialPort_0.ReadTimeout = 100;
			this.string_0 = this.string_0 + "VagCom/KKL" + Environment.NewLine;
			this.string_0 += Environment.NewLine;
			this.string_0 = this.string_0 + "Testing latency with 200 bytes of data..." + Environment.NewLine;
			this.bool_0 = false;
			this.method_2(170);
			this.method_2(170);
			int num = 1000;
			int num2 = 0;
			for (int i = 0; i < 200; i++)
			{
				int num3 = GClass3.smethod_1();
				this.method_2(170);
				int num4 = GClass3.smethod_1() - num3;
				if (num4 < num)
				{
					num = num4;
				}
				if (num4 > num2)
				{
					num2 = num4;
				}
			}
			object obj = this.string_0;
			this.string_0 = string.Concat(new object[]
			{
				obj,
				"Min latency: ",
				num,
				Environment.NewLine
			});
			obj = this.string_0;
			this.string_0 = string.Concat(new object[]
			{
				obj,
				"Max latency: ",
				num2,
				Environment.NewLine
			});
			this.string_0 += Environment.NewLine;
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
			this.string_0 = this.string_0 + "Testing timers..." + Environment.NewLine;
			this.string_0 = this.string_0 + "(The acceptable tolerance for results is ~5 ms)" + Environment.NewLine;
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
			if (Stopwatch.IsHighResolution)
			{
				this.string_0 = this.string_0 + "System supports high resolution timer." + Environment.NewLine;
			}
			else
			{
				this.string_0 = this.string_0 + "System DOES NOT support high resolution timer!!! This system may not work properly with VagCom/KKL interface!!!" + Environment.NewLine;
			}
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
			this.string_0 = this.string_0 + "Testing timer with 1000 ms..." + Environment.NewLine;
			this.bool_0 = false;
			Thread.Sleep(50);
			int num5 = GClass3.smethod_1();
			Thread.Sleep(1000);
			int num6 = GClass3.smethod_1() - num5;
			obj = this.string_0;
			this.string_0 = string.Concat(new object[]
			{
				obj,
				"..result: ",
				num6,
				" ms",
				Environment.NewLine
			});
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
			this.serialPort_0.Close();
			this.string_0 = this.string_0 + "Testing timer with 250 ms..." + Environment.NewLine;
			this.bool_0 = false;
			this.serialPort_0 = new SerialPort(this.string_1, 1200, Parity.None, 8, StopBits.One);
			this.serialPort_0.WriteBufferSize = 2;
			this.serialPort_0.WriteTimeout = 2000;
			this.serialPort_0.ReceivedBytesThreshold = 1000;
			this.serialPort_0.Handshake = Handshake.None;
			this.serialPort_0.Open();
			this.serialPort_0.ReadTimeout = 250;
			num5 = GClass3.smethod_1();
			this.serialPort_0.Write("123456789012345678901234567890");
			for (int i = 0; i < 30; i++)
			{
				byte b = (byte)this.serialPort_0.ReadByte();
			}
			num6 = GClass3.smethod_1() - num5 - 2;
			obj = this.string_0;
			this.string_0 = string.Concat(new object[]
			{
				obj,
				"..result: ",
				num6,
				" ms",
				Environment.NewLine
			});
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
			this.string_0 = this.string_0 + "Testing timer with 750 ms..." + Environment.NewLine;
			this.bool_0 = false;
			num5 = GClass3.smethod_1();
			this.serialPort_0.Write("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
			for (int i = 0; i < 90; i++)
			{
				byte b2 = (byte)this.serialPort_0.ReadByte();
			}
			num6 = GClass3.smethod_1() - num5 - 2;
			obj = this.string_0;
			this.string_0 = string.Concat(new object[]
			{
				obj,
				"..result: ",
				num6,
				" ms",
				Environment.NewLine
			});
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
			this.string_0 = this.string_0 + "Testing timer with 100 ms..." + Environment.NewLine;
			this.bool_0 = false;
			num5 = GClass3.smethod_1();
			this.serialPort_0.Write("1234567890123456789012");
			for (int i = 0; i < 12; i++)
			{
				byte b3 = (byte)this.serialPort_0.ReadByte();
			}
			num6 = GClass3.smethod_1() - num5 - 2;
			obj = this.string_0;
			this.string_0 = string.Concat(new object[]
			{
				obj,
				"..result: ",
				num6,
				" ms",
				Environment.NewLine
			});
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
		}
		catch (Exception ex)
		{
			this.string_0 = this.string_0 + ex.Message + Environment.NewLine;
			this.bool_0 = false;
		}
		finally
		{
			try
			{
				this.serialPort_0.Close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x000229F0 File Offset: 0x00020BF0
	private void method_2(byte byte_0)
	{
		this.serialPort_0.Write(new byte[]
		{
			byte_0
		}, 0, 1);
		byte b = (byte)this.serialPort_0.ReadByte();
		if (byte_0 != b)
		{
			this.string_0 = this.string_0 + "DATA ERROR!!!" + Environment.NewLine;
			this.bool_0 = false;
		}
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x00022A4C File Offset: 0x00020C4C
	private void method_3(string string_2)
	{
		for (int i = 0; i < string_2.Length; i++)
		{
			this.serialPort_0.Write(string_2.Substring(i, 1));
		}
		this.serialPort_0.Write(this.serialPort_0.NewLine);
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x00022A98 File Offset: 0x00020C98
	private string method_4(string string_2, bool bool_1)
	{
		this.method_3(string_2);
		if (bool_1)
		{
			this.string_0 = this.string_0 + "COMMAND: " + string_2 + Environment.NewLine;
		}
		this.bool_0 = false;
		string text = this.method_5();
		if (bool_1)
		{
			string text2 = this.string_0;
			this.string_0 = string.Concat(new string[]
			{
				text2,
				"RESPONSE: ",
				text,
				Environment.NewLine,
				Environment.NewLine
			});
		}
		this.bool_0 = false;
		return text;
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00022B28 File Offset: 0x00020D28
	private string method_5()
	{
		string text = string.Empty;
		while (!text.EndsWith(">") && text.Length < 250)
		{
			text += (char)this.serialPort_0.ReadByte();
		}
		return text;
	}

	// Token: 0x060000CA RID: 202 RVA: 0x00022B7C File Offset: 0x00020D7C
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!this.bool_0)
		{
			this.bool_0 = true;
			this.textBox1.Text = this.string_0;
			this.textBox1.SelectionStart = this.textBox1.Text.Length;
			this.textBox1.ScrollToCaret();
		}
	}

	// Token: 0x060000CB RID: 203 RVA: 0x000026DC File Offset: 0x000008DC
	private void buttonOk_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x040000CD RID: 205
	private SerialPort serialPort_0;

	// Token: 0x040000CE RID: 206
	private string string_0 = string.Empty;

	// Token: 0x040000CF RID: 207
	private bool bool_0 = false;

	// Token: 0x040000D0 RID: 208
	private string string_1 = "COM1";

	// Token: 0x040000D1 RID: 209
	private int int_0 = 9600;

	// Token: 0x040000D2 RID: 210
	private int int_1 = 2;
}
