using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000098 RID: 152
public partial class GForm5 : Form
{
	// Token: 0x060004A6 RID: 1190 RVA: 0x00003C55 File Offset: 0x00001E55
	public GForm5()
	{
		this.method_4();
	}

	// Token: 0x060004A7 RID: 1191 RVA: 0x000A6F90 File Offset: 0x000A5190
	private void GForm5_Shown(object sender, EventArgs e)
	{
		this.button_0.Text = GClass121.smethod_6("8198");
		this.button_1.Text = GClass121.smethod_6("8199");
		this.label_1.Text = GClass121.smethod_6("1002");
		this.label_0.Text = GClass121.smethod_6("1003");
	}

	// Token: 0x060004A8 RID: 1192 RVA: 0x00002F0A File Offset: 0x0000110A
	private void method_0(object sender, EventArgs e)
	{
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x00003C63 File Offset: 0x00001E63
	public string method_1()
	{
		return this.comboBox_0.Text;
	}

	// Token: 0x060004AA RID: 1194 RVA: 0x00003C70 File Offset: 0x00001E70
	public string method_2()
	{
		return this.textBox_0.Text;
	}

	// Token: 0x060004AB RID: 1195 RVA: 0x00003C7D File Offset: 0x00001E7D
	public string method_3()
	{
		return this.comboBox_1.Text;
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x00002F0A File Offset: 0x0000110A
	private void button_1_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x060004AE RID: 1198 RVA: 0x000A6FF4 File Offset: 0x000A51F4
	private void method_4()
	{
		this.textBox_0 = new TextBox();
		this.label_0 = new Label();
		this.comboBox_0 = new ComboBox();
		this.label_1 = new Label();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.comboBox_1 = new ComboBox();
		base.SuspendLayout();
		this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.BackColor = Color.WhiteSmoke;
		this.textBox_0.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_0.Location = new Point(179, 61);
		this.textBox_0.Margin = new Padding(3, 4, 3, 4);
		this.textBox_0.Name = GClass107.smethod_3(87884);
		this.textBox_0.Size = new Size(505, 26);
		this.textBox_0.TabIndex = 1;
		this.textBox_0.Tag = "";
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(25, 64);
		this.label_0.Name = GClass107.smethod_3(87889);
		this.label_0.Size = new Size(110, 20);
		this.label_0.TabIndex = 37;
		this.label_0.Tag = "1003";
		this.label_0.Text = GClass107.smethod_3(87935);
		this.comboBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBox_0.BackColor = Color.WhiteSmoke;
		this.comboBox_0.FlatStyle = FlatStyle.Flat;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Items.AddRange(new object[]
		{
			GClass107.smethod_3(87975),
			GClass107.smethod_3(87992),
			GClass107.smethod_3(88023),
			GClass107.smethod_3(88031),
			GClass107.smethod_3(88073),
			GClass107.smethod_3(88074),
			GClass107.smethod_3(88089)
		});
		this.comboBox_0.Location = new Point(179, 25);
		this.comboBox_0.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_0.Name = GClass107.smethod_3(88127);
		this.comboBox_0.Size = new Size(505, 28);
		this.comboBox_0.TabIndex = 0;
		this.comboBox_0.Tag = "";
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(25, 28);
		this.label_1.Name = GClass107.smethod_3(88153);
		this.label_1.Size = new Size(48, 20);
		this.label_1.TabIndex = 36;
		this.label_1.Tag = "1002";
		this.label_1.Text = GClass107.smethod_3(88184);
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_0.BackColor = Color.WhiteSmoke;
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Location = new Point(439, 137);
		this.button_0.Margin = new Padding(3, 4, 3, 4);
		this.button_0.Name = GClass107.smethod_3(88232);
		this.button_0.Size = new Size(119, 34);
		this.button_0.TabIndex = 3;
		this.button_0.Tag = "8198";
		this.button_0.Text = GClass107.smethod_3(88266);
		this.button_0.UseVisualStyleBackColor = false;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.BackColor = Color.WhiteSmoke;
		this.button_1.DialogResult = DialogResult.OK;
		this.button_1.Location = new Point(565, 137);
		this.button_1.Margin = new Padding(3, 4, 3, 4);
		this.button_1.Name = GClass107.smethod_3(88299);
		this.button_1.Size = new Size(119, 34);
		this.button_1.TabIndex = 2;
		this.button_1.Tag = "8199";
		this.button_1.Text = "OK";
		this.button_1.UseVisualStyleBackColor = false;
		this.button_1.Click += this.button_1_Click;
		this.comboBox_1.BackColor = Color.WhiteSmoke;
		this.comboBox_1.FlatStyle = FlatStyle.Flat;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Items.AddRange(new object[]
		{
			"1998",
			"1999",
			"2000",
			"2001",
			"2002",
			"2003",
			"2004",
			"2005",
			"2006",
			"2007",
			"2008",
			"2009",
			"2010",
			"2011",
			"2012",
			"2013",
			"2014"
		});
		this.comboBox_1.Location = new Point(179, 95);
		this.comboBox_1.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_1.Name = GClass107.smethod_3(88341);
		this.comboBox_1.Size = new Size(214, 28);
		this.comboBox_1.TabIndex = 38;
		this.comboBox_1.Tag = "";
		base.AcceptButton = this.button_1;
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.White;
		base.CancelButton = this.button_0;
		base.ClientSize = new Size(709, 195);
		base.Controls.Add(this.comboBox_1);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.button_1);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Margin = new Padding(3, 4, 3, 4);
		base.Name = GClass107.smethod_3(88382);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		this.Text = GClass107.smethod_3(88398);
		base.Shown += this.GForm5_Shown;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x0400033E RID: 830
	private TextBox textBox_0;

	// Token: 0x0400033F RID: 831
	private Label label_0;

	// Token: 0x04000340 RID: 832
	private ComboBox comboBox_0;

	// Token: 0x04000341 RID: 833
	private Label label_1;

	// Token: 0x04000342 RID: 834
	private Button button_0;

	// Token: 0x04000343 RID: 835
	private Button button_1;

	// Token: 0x04000344 RID: 836
	private ComboBox comboBox_1;
}
