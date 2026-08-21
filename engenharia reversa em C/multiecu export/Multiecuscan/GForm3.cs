using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

// Token: 0x02000096 RID: 150
public partial class GForm3 : Form
{
	// Token: 0x06000497 RID: 1175 RVA: 0x00003B7F File Offset: 0x00001D7F
	public GForm3()
	{
		this.method_1();
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x000A6224 File Offset: 0x000A4424
	private void GForm3_Shown(object sender, EventArgs e)
	{
		this.progressBar_0.Maximum = 30;
		this.progressBar_0.Value = 0;
		this.timer_0.Enabled = true;
		this.button_0.Text = GClass121.smethod_6("8198");
		this.label_0.Text = GClass121.smethod_6("8301");
		this.textBox_0.Text = GClass121.smethod_6("8302");
		this.bool_0 = false;
		new Thread(new ThreadStart(this.method_0)).Start();
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x00003B98 File Offset: 0x00001D98
	private void button_0_Click(object sender, EventArgs e)
	{
		this.bool_0 = true;
		Thread.Sleep(200);
		base.Close();
	}

	// Token: 0x0600049A RID: 1178 RVA: 0x000A62B4 File Offset: 0x000A44B4
	private void method_0()
	{
		while (!this.bool_0)
		{
			this.bool_1 = GClass96.smethod_12();
			this.string_0 = GClass96.smethod_15();
			if (this.bool_1 && !this.bool_0 && this.string_0 == "")
			{
				for (int i = 0; i < 40; i++)
				{
					if (!this.bool_0)
					{
						Thread.Sleep(50);
					}
				}
				this.string_0 = GClass96.smethod_15();
			}
			if (this.bool_1 || this.string_0 != "")
			{
				this.bool_1 = true;
				IL_AF:
				this.bool_0 = true;
				return;
			}
			for (int j = 0; j < 20; j++)
			{
				if (!this.bool_0)
				{
					Thread.Sleep(50);
				}
			}
		}
		goto IL_AF;
	}

	// Token: 0x0600049B RID: 1179 RVA: 0x000A6378 File Offset: 0x000A4578
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (this.progressBar_0.Value < this.progressBar_0.Maximum)
		{
			ProgressBar progressBar = this.progressBar_0;
			int value = progressBar.Value;
			progressBar.Value = value + 1;
		}
		else
		{
			this.progressBar_0.Value = 0;
		}
		if (this.bool_1 && this.bool_0)
		{
			Thread.Sleep(200);
			base.Close();
		}
	}

	// Token: 0x0600049C RID: 1180 RVA: 0x00003BB1 File Offset: 0x00001DB1
	private void GForm3_FormClosing(object sender, FormClosingEventArgs e)
	{
		this.timer_0.Enabled = false;
	}

	// Token: 0x0600049E RID: 1182 RVA: 0x000A63E0 File Offset: 0x000A45E0
	private void method_1()
	{
		this.icontainer_0 = new Container();
		this.progressBar_0 = new ProgressBar();
		this.button_0 = new Button();
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		base.SuspendLayout();
		this.progressBar_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.progressBar_0.Location = new Point(12, 38);
		this.progressBar_0.Name = GClass107.smethod_3(83842);
		this.progressBar_0.Size = new Size(418, 23);
		this.progressBar_0.TabIndex = 0;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Location = new Point(315, 138);
		this.button_0.Name = GClass107.smethod_3(83872);
		this.button_0.Size = new Size(115, 27);
		this.button_0.TabIndex = 25;
		this.button_0.Text = GClass107.smethod_3(83888);
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.label_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 16);
		this.label_0.Name = GClass107.smethod_3(83918);
		this.label_0.Size = new Size(204, 16);
		this.label_0.TabIndex = 26;
		this.label_0.Text = GClass107.smethod_3(83943);
		this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.BackColor = Color.White;
		this.textBox_0.BorderStyle = BorderStyle.None;
		this.textBox_0.Location = new Point(12, 67);
		this.textBox_0.Multiline = true;
		this.textBox_0.Name = GClass107.smethod_3(83959);
		this.textBox_0.ReadOnly = true;
		this.textBox_0.Size = new Size(418, 65);
		this.textBox_0.TabIndex = 27;
		this.textBox_0.Text = GClass107.smethod_3(83988) + GClass107.smethod_3(84023);
		this.textBox_0.TextAlign = HorizontalAlignment.Center;
		this.timer_0.Interval = 300;
		this.timer_0.Tick += this.timer_0_Tick;
		base.AutoScaleDimensions = new SizeF(8f, 16f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.White;
		base.ClientSize = new Size(442, 177);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.progressBar_0);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Name = GClass107.smethod_3(84033);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		this.Text = GClass107.smethod_3(84039);
		base.Shown += this.GForm3_Shown;
		base.FormClosing += this.GForm3_FormClosing;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x0400032A RID: 810
	private bool bool_0;

	// Token: 0x0400032B RID: 811
	public bool bool_1;

	// Token: 0x0400032C RID: 812
	public string string_0 = "";

	// Token: 0x0400032E RID: 814
	private ProgressBar progressBar_0;

	// Token: 0x0400032F RID: 815
	private Button button_0;

	// Token: 0x04000330 RID: 816
	private Label label_0;

	// Token: 0x04000331 RID: 817
	private TextBox textBox_0;

	// Token: 0x04000332 RID: 818
	private System.Windows.Forms.Timer timer_0;
}
