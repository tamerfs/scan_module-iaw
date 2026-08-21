using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

// Token: 0x0200001C RID: 28
public sealed partial class FormDetectCTC : Form
{
	// Token: 0x06000126 RID: 294 RVA: 0x00002B60 File Offset: 0x00000D60
	public FormDetectCTC()
	{
		this.InitializeComponent();
	}

	// Token: 0x06000129 RID: 297 RVA: 0x00034AB4 File Offset: 0x00032CB4
	private void FormDetectCTC_Shown(object sender, EventArgs e)
	{
		this.progressBar1.Maximum = 30;
		this.progressBar1.Value = 0;
		this.timer_0.Enabled = true;
		this.buttonCancel.Text = GClass62.smethod_1("8198");
		this.label1.Text = GClass62.smethod_1("8301");
		this.textBox1.Text = GClass62.smethod_1("8302");
		new Thread(new ThreadStart(this.method_0)).Start();
	}

	// Token: 0x0600012A RID: 298 RVA: 0x00002BA8 File Offset: 0x00000DA8
	private void buttonCancel_Click(object sender, EventArgs e)
	{
		this.bool_0 = true;
		Thread.Sleep(150);
		base.Close();
	}

	// Token: 0x0600012B RID: 299 RVA: 0x00034B3C File Offset: 0x00032D3C
	private void method_0()
	{
		while (!this.bool_0)
		{
			this.bool_1 = GClass55.smethod_8();
			if (this.bool_1 && !this.bool_0)
			{
				GClass55.smethod_9();
			}
			if (this.bool_1)
			{
				break;
			}
			for (int i = 0; i < 10; i++)
			{
				if (!this.bool_0)
				{
					Thread.Sleep(60);
				}
			}
		}
	}

	// Token: 0x0600012C RID: 300 RVA: 0x00034BA4 File Offset: 0x00032DA4
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (this.progressBar1.Value < this.progressBar1.Maximum)
		{
			this.progressBar1.Value++;
		}
		else
		{
			this.progressBar1.Value = 0;
		}
		if (this.bool_1)
		{
			this.bool_0 = true;
			Thread.Sleep(150);
			base.Close();
		}
	}

	// Token: 0x0600012D RID: 301 RVA: 0x00002BC1 File Offset: 0x00000DC1
	private void FormDetectCTC_FormClosing(object sender, FormClosingEventArgs e)
	{
		this.timer_0.Enabled = false;
	}

	// Token: 0x04000116 RID: 278
	private bool bool_0 = false;

	// Token: 0x04000117 RID: 279
	public bool bool_1 = false;
}
