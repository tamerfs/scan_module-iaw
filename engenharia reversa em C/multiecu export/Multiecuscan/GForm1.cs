using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000094 RID: 148
public partial class GForm1 : Form
{
	// Token: 0x06000489 RID: 1161 RVA: 0x00002F0A File Offset: 0x0000110A
	private void GForm1_FormClosing(object sender, FormClosingEventArgs e)
	{
	}

	// Token: 0x0600048A RID: 1162 RVA: 0x000A41B4 File Offset: 0x000A23B4
	private void button_0_Click(object sender, EventArgs e)
	{
		string text = this.textBox_0.Text;
		string text2 = "";
		try
		{
			text2 = GClass127.smethod_11(GClass127.smethod_32(text));
			if (!text.ToUpper().Replace(" ", "").Equals(text2.ToUpper().Replace(" ", "")))
			{
				throw new Exception("error");
			}
		}
		catch (Exception)
		{
			text2 = "";
		}
		if (text2 == "")
		{
			MessageBox.Show(GClass107.smethod_3(78783), GClass107.smethod_3(78815), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			base.DialogResult = DialogResult.None;
			return;
		}
		if (this.string_0.Length > 70 && text2.Length > 70 && !this.string_0.ToUpper().Substring(0, 70).Equals(text2.ToUpper().Substring(0, 70)) && MessageBox.Show(GClass107.smethod_3(78834), GClass107.smethod_3(78851), MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) != DialogResult.OK)
		{
			base.DialogResult = DialogResult.None;
			return;
		}
		byte[] array = GClass127.smethod_32(this.string_0);
		byte[] array2 = GClass127.smethod_32(text2);
		if (array.Length != array2.Length && MessageBox.Show(GClass107.smethod_3(78872), GClass107.smethod_3(78877), MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) != DialogResult.OK)
		{
			base.DialogResult = DialogResult.None;
			return;
		}
		if (array2.Length < 34 && MessageBox.Show(GClass107.smethod_3(78920), GClass107.smethod_3(78941), MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) != DialogResult.OK)
		{
			base.DialogResult = DialogResult.None;
			return;
		}
		this.string_0 = this.textBox_0.Text;
	}

	// Token: 0x0600048B RID: 1163 RVA: 0x00003B08 File Offset: 0x00001D08
	public GForm1(string string_1)
	{
		this.method_1();
		this.string_0 = string_1;
		this.textBox_0.Text = this.string_0;
	}

	// Token: 0x0600048C RID: 1164 RVA: 0x00003B39 File Offset: 0x00001D39
	public string method_0()
	{
		return this.string_0;
	}

	// Token: 0x0600048D RID: 1165 RVA: 0x000A4350 File Offset: 0x000A2550
	private void timer_0_Tick(object sender, EventArgs e)
	{
		int num = this.textBox_0.SelectionStart;
		if (num != this.int_0)
		{
			this.int_0 = num;
			num = num / 3 + 1;
			this.label_0.Text = GClass107.smethod_3(78962) + num.ToString();
		}
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x000A43A0 File Offset: 0x000A25A0
	private void method_1()
	{
		this.icontainer_0 = new Container();
		this.textBox_0 = new TextBox();
		this.button_0 = new Button();
		this.label_0 = new Label();
		this.timer_0 = new Timer(this.icontainer_0);
		base.SuspendLayout();
		this.textBox_0.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_0.Font = new Font(GClass107.smethod_3(80307), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.textBox_0.ForeColor = Color.Navy;
		this.textBox_0.Location = new Point(14, 15);
		this.textBox_0.Margin = new Padding(3, 4, 3, 4);
		this.textBox_0.Multiline = true;
		this.textBox_0.Name = GClass107.smethod_3(80343);
		this.textBox_0.ScrollBars = ScrollBars.Vertical;
		this.textBox_0.Size = new Size(810, 468);
		this.textBox_0.TabIndex = 0;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(720, 506);
		this.button_0.Margin = new Padding(3, 4, 3, 4);
		this.button_0.Name = GClass107.smethod_3(80384);
		this.button_0.Size = new Size(104, 34);
		this.button_0.TabIndex = 2;
		this.button_0.Tag = "8199";
		this.button_0.Text = "OK";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.label_0.AutoSize = true;
		this.label_0.Font = new Font(GClass107.smethod_3(80389), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_0.ForeColor = Color.Red;
		this.label_0.Location = new Point(12, 505);
		this.label_0.Name = GClass107.smethod_3(80416);
		this.label_0.Size = new Size(80, 27);
		this.label_0.TabIndex = 3;
		this.label_0.Text = GClass107.smethod_3(80432);
		this.timer_0.Enabled = true;
		this.timer_0.Interval = 250;
		this.timer_0.Tick += this.timer_0_Tick;
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.AutoSize = true;
		base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		base.ClientSize = new Size(837, 555);
		base.ControlBox = false;
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.textBox_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Margin = new Padding(3, 4, 3, 4);
		base.Name = GClass107.smethod_3(80480);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = GClass107.smethod_3(80490);
		base.FormClosing += this.GForm1_FormClosing;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000308 RID: 776
	private string string_0 = "";

	// Token: 0x04000309 RID: 777
	private int int_0;

	// Token: 0x0400030B RID: 779
	private TextBox textBox_0;

	// Token: 0x0400030C RID: 780
	private Button button_0;

	// Token: 0x0400030D RID: 781
	private Label label_0;

	// Token: 0x0400030E RID: 782
	private Timer timer_0;
}
