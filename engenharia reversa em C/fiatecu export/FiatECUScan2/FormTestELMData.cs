using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

// Token: 0x02000057 RID: 87
public sealed partial class FormTestELMData : Form
{
	// Token: 0x06000258 RID: 600 RVA: 0x0005FF08 File Offset: 0x0005E108
	public FormTestELMData()
	{
		this.InitializeComponent();
		for (int i = 0; i < 4; i++)
		{
			if (GClass61.smethod_30(i) > 1)
			{
				this.string_1 = GClass61.smethod_32(i);
				this.int_0 = GClass61.smethod_34(i);
				this.int_1 = GClass61.smethod_30(i);
				return;
			}
		}
	}

	// Token: 0x06000259 RID: 601 RVA: 0x0005FFA8 File Offset: 0x0005E1A8
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
			int num = GClass3.smethod_1();
			this.serialPort_0.ReadTimeout = 2000;
			this.method_2("ATZ", true);
			if (this.int_1 == 4)
			{
				this.serialPort_0.ReadTimeout = 100;
				this.method_1("ATBRD16");
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
				this.method_2(string.Empty, false);
			}
			this.serialPort_0.ReadTimeout = 2000;
			string text2 = string.Empty;
			text2 = this.method_2("ATI", true);
			text2 = this.method_2("ATSPC", true);
			text2 = this.method_2("ATH1", true);
			text2 = this.method_2("ATD1", true);
			text2 = this.method_2("ATL1", true);
			this.method_1("ATMA");
			while (!this.bool_2)
			{
				text2 = this.serialPort_0.ReadExisting();
				if (text2 != string.Empty)
				{
					this.string_0 = this.string_0 + string.Format("[{0:000000}] ", GClass3.smethod_1() - num) + text2;
				}
				this.bool_0 = false;
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
		this.bool_1 = false;
	}

	// Token: 0x0600025A RID: 602 RVA: 0x00060334 File Offset: 0x0005E534
	private void method_1(string string_2)
	{
		for (int i = 0; i < string_2.Length; i++)
		{
			this.serialPort_0.Write(string_2.Substring(i, 1));
		}
		this.serialPort_0.Write(this.serialPort_0.NewLine);
	}

	// Token: 0x0600025B RID: 603 RVA: 0x00060380 File Offset: 0x0005E580
	private string method_2(string string_2, bool bool_3)
	{
		this.method_1(string_2);
		if (bool_3)
		{
			this.string_0 = this.string_0 + "COMMAND: " + string_2 + Environment.NewLine;
		}
		this.bool_0 = false;
		string text = this.method_3();
		if (bool_3)
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

	// Token: 0x0600025C RID: 604 RVA: 0x00060410 File Offset: 0x0005E610
	private string method_3()
	{
		string text = string.Empty;
		while (!text.EndsWith(">") && text.Length < 250)
		{
			text += (char)this.serialPort_0.ReadByte();
		}
		return text;
	}

	// Token: 0x0600025D RID: 605 RVA: 0x00060464 File Offset: 0x0005E664
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!this.bool_0)
		{
			this.bool_0 = true;
			this.textBox1.Text = this.string_0;
			this.textBox1.SelectionStart = this.textBox1.Text.Length;
			this.textBox1.ScrollToCaret();
		}
		this.buttonStart.Text = (this.bool_1 ? "Stop" : "Start");
	}

	// Token: 0x0600025E RID: 606 RVA: 0x000026DC File Offset: 0x000008DC
	private void buttonOk_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x0600025F RID: 607 RVA: 0x000604D8 File Offset: 0x0005E6D8
	private void buttonStart_Click(object sender, EventArgs e)
	{
		if (!this.bool_1)
		{
			this.bool_1 = true;
			if ((this.int_1 == 4 || this.int_1 == 5) && !GClass55.smethod_4(this.string_1, this.int_0))
			{
				FormNotify formNotify = new FormNotify(GClass62.smethod_1("1070"), GClass62.smethod_1("1074"), GClass62.smethod_1("1075"), true, 0);
				formNotify.ShowDialog();
			}
			new Thread(new ThreadStart(this.method_0)).Start();
		}
		else
		{
			this.bool_2 = true;
		}
	}

	// Token: 0x06000260 RID: 608 RVA: 0x00060570 File Offset: 0x0005E770
	private void FormTestELMData_FormClosing(object sender, FormClosingEventArgs e)
	{
		this.bool_2 = true;
		int num = 100;
		while (this.bool_1 && num > 0)
		{
			Thread.Sleep(100);
			num--;
		}
	}

	// Token: 0x040003AE RID: 942
	private SerialPort serialPort_0;

	// Token: 0x040003AF RID: 943
	private string string_0 = string.Empty;

	// Token: 0x040003B0 RID: 944
	private bool bool_0 = false;

	// Token: 0x040003B1 RID: 945
	private string string_1 = "COM1";

	// Token: 0x040003B2 RID: 946
	private int int_0 = 9600;

	// Token: 0x040003B3 RID: 947
	private int int_1 = 2;

	// Token: 0x040003B4 RID: 948
	private bool bool_1 = false;

	// Token: 0x040003B5 RID: 949
	private bool bool_2 = false;
}
