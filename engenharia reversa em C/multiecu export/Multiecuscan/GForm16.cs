using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

// Token: 0x020000B9 RID: 185
public partial class GForm16 : Form
{
	// Token: 0x0600060D RID: 1549 RVA: 0x000DA52C File Offset: 0x000D872C
	public GForm16()
	{
		this.method_4();
		for (int i = 0; i < 2; i++)
		{
			if (GClass125.smethod_38(i) > 1)
			{
				this.string_1 = GClass125.smethod_40(i);
				this.int_0 = GClass125.smethod_42(i);
				this.int_1 = GClass125.smethod_38(i);
				return;
			}
		}
	}

	// Token: 0x0600060E RID: 1550 RVA: 0x000DA5AC File Offset: 0x000D87AC
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!this.bool_0)
		{
			this.bool_0 = true;
			this.textBox_0.Text = this.string_0;
			this.textBox_0.SelectionStart = this.textBox_0.Text.Length;
			this.textBox_0.ScrollToCaret();
		}
		this.button_1.Text = (this.bool_1 ? GClass107.smethod_3(150216) : GClass107.smethod_3(150219));
	}

	// Token: 0x0600060F RID: 1551 RVA: 0x000DA628 File Offset: 0x000D8828
	private string method_0()
	{
		string text = "";
		while (!text.EndsWith(">") && text.Length < 250)
		{
			text += ((char)this.serialPort_0.ReadByte()).ToString();
		}
		return text;
	}

	// Token: 0x06000610 RID: 1552 RVA: 0x000DA674 File Offset: 0x000D8874
	private string method_1(string string_2, bool bool_3)
	{
		this.method_3(string_2);
		if (bool_3)
		{
			this.string_0 = this.string_0 + GClass107.smethod_3(150166) + string_2 + Environment.NewLine;
		}
		this.bool_0 = false;
		string text = this.method_0();
		if (bool_3)
		{
			this.string_0 = string.Concat(new string[]
			{
				this.string_0,
				GClass107.smethod_3(150182),
				text,
				Environment.NewLine,
				Environment.NewLine
			});
		}
		this.bool_0 = false;
		return text;
	}

	// Token: 0x06000611 RID: 1553 RVA: 0x000DA700 File Offset: 0x000D8900
	private void method_2()
	{
		if (this.int_1 == 5)
		{
			Thread.Sleep(4000);
		}
		if (this.int_1 == 4 || this.int_1 == 5)
		{
			this.string_0 = this.string_0 + GClass107.smethod_3(149784) + Environment.NewLine;
			this.bool_0 = false;
			GClass96.smethod_2(true, this.string_1, this.int_0);
			Thread.Sleep(4000);
		}
		try
		{
			this.serialPort_0 = new SerialPort(this.string_1, this.int_0, Parity.None, 8, StopBits.One);
			this.serialPort_0.WriteBufferSize = 2;
			this.serialPort_0.WriteTimeout = 2000;
			this.serialPort_0.ReceivedBytesThreshold = 1000;
			this.serialPort_0.Handshake = Handshake.None;
			if (this.int_1 != 4)
			{
				if (this.int_1 != 5)
				{
					this.serialPort_0.NewLine = GClass107.smethod_3(149820);
					goto IL_F6;
				}
			}
			this.serialPort_0.NewLine = "\r";
			IL_F6:
			this.serialPort_0.Open();
			int num = GClass126.smethod_1();
			this.serialPort_0.ReadTimeout = 2000;
			this.method_1("ATZ", true);
			if (this.int_1 == 4)
			{
				this.serialPort_0.ReadTimeout = 100;
				this.method_3(GClass107.smethod_3(149861));
				string text = ((char)this.serialPort_0.ReadByte()).ToString() ?? "";
				while (!text.Contains(GClass107.smethod_3(149904)) && !text.Contains("?") && text.Length < 20)
				{
					text += ((char)this.serialPort_0.ReadByte()).ToString();
				}
				this.serialPort_0.BaudRate = 250000;
				this.serialPort_0.ReadTimeout = 100;
				text = (((char)this.serialPort_0.ReadByte()).ToString() ?? "");
				while (!text.Contains("\r") && text.Length < 20)
				{
					text += ((char)this.serialPort_0.ReadByte()).ToString();
				}
				this.method_1("", false);
			}
			if (this.int_1 == 11)
			{
				this.string_0 = this.string_0 + GClass107.smethod_3(149946) + Environment.NewLine;
				this.bool_0 = false;
				this.serialPort_0.ReadTimeout = 100;
				this.method_3(GClass107.smethod_3(149947));
				string text2 = ((char)this.serialPort_0.ReadByte()).ToString() ?? "";
				while (!text2.Contains(GClass107.smethod_3(149961)) && !text2.Contains("?") && text2.Length < 20)
				{
					text2 += ((char)this.serialPort_0.ReadByte()).ToString();
				}
				this.serialPort_0.BaudRate = 115200;
				this.serialPort_0.ReadTimeout = 100;
				text2 = (((char)this.serialPort_0.ReadByte()).ToString() ?? "");
				while (!text2.Contains("\r") && text2.Length < 20)
				{
					text2 += ((char)this.serialPort_0.ReadByte()).ToString();
				}
				this.method_1("", false);
			}
			this.serialPort_0.ReadTimeout = 2000;
			string text3 = this.method_1("ATI", true);
			text3 = this.method_1(GClass107.smethod_3(150003), true);
			text3 = this.method_1(GClass107.smethod_3(150051), true);
			text3 = this.method_1(GClass107.smethod_3(150067), true);
			text3 = this.method_1(GClass107.smethod_3(150105), true);
			this.method_3(GClass107.smethod_3(150125));
			while (!this.bool_2)
			{
				text3 = this.serialPort_0.ReadExisting();
				if (text3 != "")
				{
					this.string_0 = this.string_0 + string.Format(GClass107.smethod_3(150159), GClass126.smethod_1() - num) + text3;
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

	// Token: 0x06000612 RID: 1554 RVA: 0x000DABE0 File Offset: 0x000D8DE0
	private void method_3(string string_2)
	{
		for (int i = 0; i < string_2.Length; i++)
		{
			this.serialPort_0.Write(string_2.Substring(i, 1));
		}
		this.serialPort_0.Write(this.serialPort_0.NewLine);
	}

	// Token: 0x06000613 RID: 1555 RVA: 0x00002F0A File Offset: 0x0000110A
	private void button_0_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x06000614 RID: 1556 RVA: 0x000DAC28 File Offset: 0x000D8E28
	private void button_1_Click(object sender, EventArgs e)
	{
		if (!this.bool_1)
		{
			this.bool_1 = true;
			if ((this.int_1 == 4 || this.int_1 == 5) && !GClass96.smethod_4(this.string_1, this.int_0))
			{
				new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("1074"), GClass121.smethod_6("1075"), true, 0).ShowDialog();
			}
			new Thread(new ThreadStart(this.method_2)).Start();
			return;
		}
		this.bool_2 = true;
	}

	// Token: 0x06000615 RID: 1557 RVA: 0x000DACB4 File Offset: 0x000D8EB4
	private void GForm16_FormClosing(object sender, FormClosingEventArgs e)
	{
		this.bool_2 = true;
		int num = 100;
		while (this.bool_1 && num > 0)
		{
			Thread.Sleep(100);
			num--;
		}
	}

	// Token: 0x06000617 RID: 1559 RVA: 0x000DACE4 File Offset: 0x000D8EE4
	private void method_4()
	{
		this.icontainer_0 = new Container();
		this.textBox_0 = new TextBox();
		this.button_0 = new Button();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.button_1 = new Button();
		base.SuspendLayout();
		this.textBox_0.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_0.Location = new Point(12, 12);
		this.textBox_0.Multiline = true;
		this.textBox_0.Name = GClass107.smethod_3(152131);
		this.textBox_0.ScrollBars = ScrollBars.Vertical;
		this.textBox_0.Size = new Size(440, 377);
		this.textBox_0.TabIndex = 0;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(186, 404);
		this.button_0.Name = GClass107.smethod_3(152154);
		this.button_0.Size = new Size(92, 27);
		this.button_0.TabIndex = 2;
		this.button_0.Tag = "8199";
		this.button_0.Text = "OK";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.timer_0.Enabled = true;
		this.timer_0.Interval = 200;
		this.timer_0.Tick += this.timer_0_Tick;
		this.button_1.Location = new Point(12, 404);
		this.button_1.Name = GClass107.smethod_3(152173);
		this.button_1.Size = new Size(106, 27);
		this.button_1.TabIndex = 3;
		this.button_1.Text = GClass107.smethod_3(152218);
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		base.AutoScaleDimensions = new SizeF(8f, 16f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.AutoSize = true;
		base.ClientSize = new Size(465, 444);
		base.ControlBox = false;
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.textBox_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Name = GClass107.smethod_3(152267);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = GClass107.smethod_3(152273);
		base.FormClosing += this.GForm16_FormClosing;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000542 RID: 1346
	private SerialPort serialPort_0;

	// Token: 0x04000543 RID: 1347
	private string string_0 = "";

	// Token: 0x04000544 RID: 1348
	private bool bool_0;

	// Token: 0x04000545 RID: 1349
	private string string_1 = GClass107.smethod_3(149752);

	// Token: 0x04000546 RID: 1350
	private int int_0 = 9600;

	// Token: 0x04000547 RID: 1351
	private int int_1 = 2;

	// Token: 0x04000548 RID: 1352
	private bool bool_1;

	// Token: 0x04000549 RID: 1353
	private bool bool_2;

	// Token: 0x0400054B RID: 1355
	private TextBox textBox_0;

	// Token: 0x0400054C RID: 1356
	private Button button_0;

	// Token: 0x0400054D RID: 1357
	private System.Windows.Forms.Timer timer_0;

	// Token: 0x0400054E RID: 1358
	private Button button_1;
}
