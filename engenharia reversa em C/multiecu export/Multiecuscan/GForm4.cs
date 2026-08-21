using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Multiecuscan.Properties;

// Token: 0x02000097 RID: 151
public partial class GForm4 : Form
{
	// Token: 0x0600049F RID: 1183 RVA: 0x00003BDE File Offset: 0x00001DDE
	public GForm4()
	{
		this.method_0();
		this.richTextBox_0.Rtf = Resources.StringDisclaimer;
	}

	// Token: 0x060004A0 RID: 1184 RVA: 0x00003BFC File Offset: 0x00001DFC
	private void button_0_Click(object sender, EventArgs e)
	{
		GClass125.smethod_70(this.checkBox_0.Checked);
	}

	// Token: 0x060004A1 RID: 1185 RVA: 0x00003C0E File Offset: 0x00001E0E
	private void richTextBox_0_LinkClicked(object sender, LinkClickedEventArgs e)
	{
		Process.Start(e.LinkText);
	}

	// Token: 0x060004A2 RID: 1186 RVA: 0x00003C1C File Offset: 0x00001E1C
	private void label_2_MouseClick(object sender, MouseEventArgs e)
	{
		Process.Start("https://www.multiecuscan.net/Register.aspx");
	}

	// Token: 0x060004A3 RID: 1187 RVA: 0x00003C29 File Offset: 0x00001E29
	private void label_3_MouseClick(object sender, MouseEventArgs e)
	{
		Process.Start("https://www.multiecuscan.net/Distributors.aspx");
	}

	// Token: 0x060004A5 RID: 1189 RVA: 0x000A6784 File Offset: 0x000A4984
	private void method_0()
	{
		this.checkBox_0 = new CheckBox();
		this.button_0 = new Button();
		this.panel_0 = new Panel();
		this.richTextBox_0 = new RichTextBox();
		this.textBox_0 = new TextBox();
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.label_2 = new Label();
		this.label_3 = new Label();
		this.panel_0.SuspendLayout();
		base.SuspendLayout();
		this.checkBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Checked = true;
		this.checkBox_0.CheckState = CheckState.Checked;
		this.checkBox_0.Location = new Point(12, 450);
		this.checkBox_0.Name = GClass107.smethod_3(85568);
		this.checkBox_0.Size = new Size(244, 20);
		this.checkBox_0.TabIndex = 0;
		this.checkBox_0.Text = GClass107.smethod_3(85612);
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(465, 445);
		this.button_0.Name = GClass107.smethod_3(85618);
		this.button_0.Size = new Size(97, 27);
		this.button_0.TabIndex = 1;
		this.button_0.Text = GClass107.smethod_3(85619);
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.panel_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_0.BorderStyle = BorderStyle.FixedSingle;
		this.panel_0.Controls.Add(this.richTextBox_0);
		this.panel_0.Location = new Point(12, 76);
		this.panel_0.Name = GClass107.smethod_3(85638);
		this.panel_0.Size = new Size(550, 256);
		this.panel_0.TabIndex = 2;
		this.richTextBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_0.BorderStyle = BorderStyle.None;
		this.richTextBox_0.Location = new Point(3, 3);
		this.richTextBox_0.Name = GClass107.smethod_3(85639);
		this.richTextBox_0.ReadOnly = true;
		this.richTextBox_0.Size = new Size(542, 248);
		this.richTextBox_0.TabIndex = 1;
		this.richTextBox_0.Text = "";
		this.richTextBox_0.LinkClicked += this.richTextBox_0_LinkClicked;
		this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.BackColor = Color.Red;
		this.textBox_0.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_0.Font = new Font(GClass107.smethod_3(85672), 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.textBox_0.ForeColor = Color.White;
		this.textBox_0.Location = new Point(12, 12);
		this.textBox_0.Multiline = true;
		this.textBox_0.Name = GClass107.smethod_3(85717);
		this.textBox_0.ReadOnly = true;
		this.textBox_0.Size = new Size(550, 58);
		this.textBox_0.TabIndex = 3;
		this.textBox_0.Text = GClass107.smethod_3(85764) + GClass107.smethod_3(85791);
		this.textBox_0.TextAlign = HorizontalAlignment.Center;
		this.label_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_0.AutoSize = true;
		this.label_0.Font = new Font(GClass107.smethod_3(85828), 9.216f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_0.ForeColor = Color.Red;
		this.label_0.Location = new Point(9, 343);
		this.label_0.Name = GClass107.smethod_3(85854);
		this.label_0.Size = new Size(504, 19);
		this.label_0.TabIndex = 4;
		this.label_0.Text = GClass107.smethod_3(85887);
		this.label_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_1.AutoSize = true;
		this.label_1.Font = new Font(GClass107.smethod_3(85920), 9.216f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_1.ForeColor = Color.Red;
		this.label_1.Location = new Point(9, 395);
		this.label_1.Name = GClass107.smethod_3(85960);
		this.label_1.Size = new Size(401, 19);
		this.label_1.TabIndex = 5;
		this.label_1.Text = GClass107.smethod_3(85973);
		this.label_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_2.AutoSize = true;
		this.label_2.Cursor = Cursors.Hand;
		this.label_2.Font = new Font(GClass107.smethod_3(85980), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_2.ForeColor = Color.Navy;
		this.label_2.Location = new Point(34, 365);
		this.label_2.Name = GClass107.smethod_3(85993);
		this.label_2.Size = new Size(319, 19);
		this.label_2.TabIndex = 29;
		this.label_2.Text = GClass107.smethod_3(86024);
		this.label_2.MouseClick += this.label_2_MouseClick;
		this.label_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_3.AutoSize = true;
		this.label_3.Cursor = Cursors.Hand;
		this.label_3.Font = new Font(GClass107.smethod_3(86060), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_3.ForeColor = Color.Navy;
		this.label_3.Location = new Point(34, 418);
		this.label_3.Name = GClass107.smethod_3(86101);
		this.label_3.Size = new Size(346, 19);
		this.label_3.TabIndex = 30;
		this.label_3.Text = GClass107.smethod_3(86141);
		this.label_3.MouseClick += this.label_3_MouseClick;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(8f, 16f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(574, 484);
		base.Controls.Add(this.label_3);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.panel_0);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.checkBox_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = GClass107.smethod_3(86189);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		this.Text = GClass107.smethod_3(86236);
		this.panel_0.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000334 RID: 820
	private CheckBox checkBox_0;

	// Token: 0x04000335 RID: 821
	private Button button_0;

	// Token: 0x04000336 RID: 822
	private Panel panel_0;

	// Token: 0x04000337 RID: 823
	private RichTextBox richTextBox_0;

	// Token: 0x04000338 RID: 824
	private TextBox textBox_0;

	// Token: 0x04000339 RID: 825
	private Label label_0;

	// Token: 0x0400033A RID: 826
	private Label label_1;

	// Token: 0x0400033B RID: 827
	private Label label_2;

	// Token: 0x0400033C RID: 828
	private Label label_3;
}
