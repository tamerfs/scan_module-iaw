using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x020000A9 RID: 169
public partial class GForm9 : Form
{
	// Token: 0x06000575 RID: 1397 RVA: 0x00003FF9 File Offset: 0x000021F9
	public GForm9()
	{
		this.method_10();
	}

	// Token: 0x06000576 RID: 1398 RVA: 0x000CB4D8 File Offset: 0x000C96D8
	public GForm9(string string_3, string string_4, string string_5, bool bool_9, int int_2)
	{
		this.method_10();
		GClass126.bool_24 = false;
		GClass126.bool_25 = false;
		this.string_0 = string_3;
		this.string_1 = string_4;
		this.string_2 = string_5;
		this.bool_7 = string_4.Equals(GClass121.smethod_6("1052"));
		this.label_1.Font = new Font(GClass125.smethod_28().FontFamily, this.label_1.Font.Size, this.label_1.Font.Style);
		this.label_0.Font = GClass125.smethod_28();
		this.label_2.Font = GClass125.smethod_28();
		this.button_1.Font = GClass125.smethod_28();
		this.button_2.Font = GClass125.smethod_28();
		this.button_0.Font = GClass125.smethod_28();
		this.label_1.Text = string_3;
		this.label_0.Text = string_4 + (this.bool_7 ? " ..." : "");
		this.label_2.Text = string_5;
		this.bool_4 = bool_9;
		this.int_1 = int_2;
		this.float_0 = this.label_1.Font.Size;
		this.float_1 = this.label_0.Font.Size;
		this.float_2 = this.label_2.Font.Size;
		int num = Screen.PrimaryScreen.Bounds.Width;
		if (num < 640)
		{
			num = 640;
		}
		int num2 = (int)((double)num * 0.9);
		int num3 = (int)((double)num * 0.7);
		if (this.label_1.Width > num2)
		{
			float num4 = (float)num2 / (float)this.label_1.Width;
			this.label_1.Font = new Font(this.label_1.Font.FontFamily, this.float_0 * num4, FontStyle.Bold);
		}
		if (this.label_0.Width > num2)
		{
			float num5 = (float)num2 / (float)this.label_0.Width;
			this.label_0.Font = new Font(this.label_0.Font.FontFamily, this.float_1 * num5, FontStyle.Bold);
		}
		if (this.label_2.Width > num2)
		{
			float num6 = (float)num2 / (float)this.label_2.Width;
			this.label_2.Font = new Font(this.label_2.Font.FontFamily, this.float_2 * num6, FontStyle.Bold);
		}
		int num7 = this.label_1.Width;
		if (this.label_0.Width > num7)
		{
			num7 = this.label_0.Width;
		}
		if (this.label_2.Width > num7)
		{
			num7 = this.label_2.Width;
		}
		num7 += 80;
		base.Width = ((num7 < num3) ? num3 : num7);
		this.label_1.Location = new Point((this.panel_0.Width - this.label_1.Width) / 2, this.label_1.Location.Y);
		this.label_0.Location = new Point((this.panel_0.Width - this.label_0.Width) / 2, this.label_0.Location.Y);
		this.label_2.Location = new Point((this.panel_0.Width - this.label_2.Width) / 2, this.label_2.Location.Y);
	}

	// Token: 0x06000577 RID: 1399 RVA: 0x00004007 File Offset: 0x00002207
	private void GForm9_Shown(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	// Token: 0x06000578 RID: 1400 RVA: 0x00004010 File Offset: 0x00002210
	private void GForm9_FormClosing(object sender, FormClosingEventArgs e)
	{
		this.bool_0 = false;
	}

	// Token: 0x06000579 RID: 1401 RVA: 0x000CB864 File Offset: 0x000C9A64
	private void GForm9_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.bool_1 = true;
			GClass126.bool_25 = true;
			return;
		}
		if (e.KeyCode == Keys.Y && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.bool_2 = true;
			this.bool_3 = false;
			GClass126.bool_24 = true;
			if (this.bool_4)
			{
				base.DialogResult = DialogResult.OK;
				base.Close();
				return;
			}
		}
		else if (e.KeyCode == Keys.N && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.bool_3 = true;
			this.bool_2 = false;
			if (this.bool_4)
			{
				base.DialogResult = DialogResult.OK;
				base.Close();
			}
		}
	}

	// Token: 0x0600057A RID: 1402 RVA: 0x00004019 File Offset: 0x00002219
	public bool method_0()
	{
		return this.bool_1;
	}

	// Token: 0x0600057B RID: 1403 RVA: 0x00004021 File Offset: 0x00002221
	public bool method_1()
	{
		return this.bool_2;
	}

	// Token: 0x0600057C RID: 1404 RVA: 0x00004029 File Offset: 0x00002229
	public bool method_2()
	{
		return this.bool_3;
	}

	// Token: 0x0600057D RID: 1405 RVA: 0x00004031 File Offset: 0x00002231
	public void method_3(string string_3)
	{
		this.string_0 = string_3;
		this.bool_5 = true;
	}

	// Token: 0x0600057E RID: 1406 RVA: 0x00004041 File Offset: 0x00002241
	public string method_4()
	{
		return this.string_0;
	}

	// Token: 0x0600057F RID: 1407 RVA: 0x00004049 File Offset: 0x00002249
	public void method_5(string string_3)
	{
		this.string_1 = string_3;
		this.bool_6 = true;
	}

	// Token: 0x06000580 RID: 1408 RVA: 0x00004059 File Offset: 0x00002259
	public string method_6()
	{
		return this.string_1;
	}

	// Token: 0x06000581 RID: 1409 RVA: 0x00004061 File Offset: 0x00002261
	public void method_7(string string_3)
	{
		this.string_2 = string_3;
		this.bool_8 = true;
	}

	// Token: 0x06000582 RID: 1410 RVA: 0x000CB930 File Offset: 0x000C9B30
	public void method_8(string string_3, string string_4, string string_5, bool bool_9, int int_2)
	{
		if (this.bool_0)
		{
			base.Invoke(new GForm9.Delegate12(this.method_9), new object[]
			{
				string_3,
				string_4,
				string_5,
				bool_9,
				int_2
			});
		}
	}

	// Token: 0x06000583 RID: 1411 RVA: 0x000CB980 File Offset: 0x000C9B80
	public void method_9(string string_3, string string_4, string string_5, bool bool_9, int int_2)
	{
		this.string_0 = string_3;
		this.string_1 = string_4;
		this.string_2 = string_5;
		this.bool_7 = string_4.Equals(GClass121.smethod_6("1052"));
		this.label_1.Text = string_3;
		this.label_0.Text = string_4 + (this.bool_7 ? " ..." : "");
		this.label_2.Text = string_5;
		this.bool_4 = bool_9;
		this.int_0 = 0;
		this.int_1 = int_2;
		this.bool_1 = false;
		this.bool_2 = false;
		this.bool_3 = false;
		GClass126.bool_24 = false;
		GClass126.bool_25 = false;
		int num = Screen.PrimaryScreen.Bounds.Width;
		if (num < 640)
		{
			num = 640;
		}
		int num2 = (int)((double)num * 0.9);
		int num3 = (int)((double)num * 0.7);
		if (this.label_1.Width > num2)
		{
			float num4 = (float)num2 / (float)this.label_1.Width;
			this.label_1.Font = new Font(this.label_1.Font.FontFamily, this.float_0 * num4, FontStyle.Bold);
		}
		if (this.label_0.Width > num2)
		{
			float num5 = (float)num2 / (float)this.label_0.Width;
			this.label_0.Font = new Font(this.label_0.Font.FontFamily, this.float_1 * num5, FontStyle.Bold);
		}
		if (this.label_2.Width > num2)
		{
			float num6 = (float)num2 / (float)this.label_2.Width;
			this.label_2.Font = new Font(this.label_2.Font.FontFamily, this.float_2 * num6, FontStyle.Bold);
		}
		int num7 = this.label_1.Width;
		if (this.label_0.Width > num7)
		{
			num7 = this.label_0.Width;
		}
		if (this.label_2.Width > num7)
		{
			num7 = this.label_2.Width;
		}
		num7 += 80;
		base.Width = ((num7 < num3) ? num3 : num7);
		this.label_1.Location = new Point((this.panel_0.Width - this.label_1.Width) / 2, this.label_1.Location.Y);
		this.label_0.Location = new Point((this.panel_0.Width - this.label_0.Width) / 2, this.label_0.Location.Y);
		this.label_2.Location = new Point((this.panel_0.Width - this.label_2.Width) / 2, this.label_2.Location.Y);
	}

	// Token: 0x06000584 RID: 1412 RVA: 0x000CBC50 File Offset: 0x000C9E50
	private void timer_0_Tick(object sender, EventArgs e)
	{
		this.int_0 += this.timer_0.Interval;
		if (this.int_1 > 0 && (this.int_0 > this.int_1 || this.bool_1))
		{
			base.Close();
		}
		if (!base.Visible)
		{
			return;
		}
		if (this.bool_7)
		{
			Label label = this.label_0;
			label.Text += ".";
			if (this.label_0.Text.Length > this.string_1.Length + 6)
			{
				this.label_0.Text = this.string_1 + " .";
			}
		}
		if (this.bool_5)
		{
			this.label_1.Text = this.string_0;
			this.label_1.Location = new Point((this.panel_0.Width - this.label_1.Width) / 2, this.label_1.Location.Y);
		}
		if (this.bool_6)
		{
			this.label_0.Text = this.string_1;
			this.label_0.Location = new Point((this.panel_0.Width - this.label_0.Width) / 2, this.label_0.Location.Y);
		}
		if (this.bool_8)
		{
			this.label_2.Text = this.string_2;
			this.label_2.Location = new Point((this.panel_0.Width - this.label_2.Width) / 2, this.label_2.Location.Y);
		}
	}

	// Token: 0x06000585 RID: 1413 RVA: 0x00004071 File Offset: 0x00002271
	private void button_1_Click(object sender, EventArgs e)
	{
		this.bool_3 = true;
		this.bool_2 = false;
		if (this.bool_4)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
	}

	// Token: 0x06000586 RID: 1414 RVA: 0x00004096 File Offset: 0x00002296
	private void button_2_Click(object sender, EventArgs e)
	{
		this.bool_1 = true;
		GClass126.bool_25 = true;
	}

	// Token: 0x06000587 RID: 1415 RVA: 0x000040A5 File Offset: 0x000022A5
	private void button_0_Click(object sender, EventArgs e)
	{
		this.bool_2 = true;
		this.bool_3 = false;
		GClass126.bool_24 = true;
		if (this.bool_4)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
	}

	// Token: 0x06000588 RID: 1416 RVA: 0x000040D0 File Offset: 0x000022D0
	private void GForm9_FormClosed(object sender, FormClosedEventArgs e)
	{
		this.timer_0.Stop();
	}

	// Token: 0x0600058A RID: 1418 RVA: 0x000CBE00 File Offset: 0x000CA000
	private void method_10()
	{
		this.icontainer_0 = new Container();
		this.panel_0 = new Panel();
		this.label_2 = new Label();
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.tableLayoutPanel_0 = new TableLayoutPanel();
		this.button_2 = new Button();
		this.button_1 = new Button();
		this.button_0 = new Button();
		this.timer_0 = new Timer(this.icontainer_0);
		this.panel_1 = new Panel();
		this.panel_0.SuspendLayout();
		this.tableLayoutPanel_0.SuspendLayout();
		this.panel_1.SuspendLayout();
		base.SuspendLayout();
		this.panel_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_0.BackColor = Color.Black;
		this.panel_0.Controls.Add(this.label_2);
		this.panel_0.Controls.Add(this.label_0);
		this.panel_0.Controls.Add(this.label_1);
		this.panel_0.ForeColor = Color.Red;
		this.panel_0.Location = new Point(14, 15);
		this.panel_0.Margin = new Padding(3, 4, 3, 4);
		this.panel_0.Name = GClass107.smethod_3(133785);
		this.panel_0.Size = new Size(924, 200);
		this.panel_0.TabIndex = 0;
		this.label_2.AutoSize = true;
		this.label_2.Font = new Font(GClass107.smethod_3(133795), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_2.ForeColor = Color.White;
		this.label_2.Location = new Point(86, 141);
		this.label_2.Name = GClass107.smethod_3(133813);
		this.label_2.Size = new Size(258, 38);
		this.label_2.TabIndex = 2;
		this.label_2.Text = GClass107.smethod_3(133841);
		this.label_0.AutoSize = true;
		this.label_0.Font = new Font(GClass107.smethod_3(133846), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_0.ForeColor = Color.White;
		this.label_0.Location = new Point(86, 95);
		this.label_0.Name = GClass107.smethod_3(133859);
		this.label_0.Size = new Size(258, 38);
		this.label_0.TabIndex = 1;
		this.label_0.Text = GClass107.smethod_3(133870);
		this.label_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.label_1.AutoSize = true;
		this.label_1.BackColor = Color.Transparent;
		this.label_1.Font = new Font(GClass107.smethod_3(133883), 28.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_1.Location = new Point(39, 18);
		this.label_1.Name = GClass107.smethod_3(133917);
		this.label_1.Size = new Size(452, 66);
		this.label_1.TabIndex = 0;
		this.label_1.Text = GClass107.smethod_3(133929);
		this.label_1.TextAlign = ContentAlignment.MiddleCenter;
		this.tableLayoutPanel_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.tableLayoutPanel_0.ColumnCount = 3;
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
		this.tableLayoutPanel_0.Controls.Add(this.button_2, 1, 0);
		this.tableLayoutPanel_0.Controls.Add(this.button_1, 0, 0);
		this.tableLayoutPanel_0.Controls.Add(this.button_0, 2, 0);
		this.tableLayoutPanel_0.Location = new Point(0, 10);
		this.tableLayoutPanel_0.Margin = new Padding(3, 4, 3, 4);
		this.tableLayoutPanel_0.Name = GClass107.smethod_3(133941);
		this.tableLayoutPanel_0.RowCount = 1;
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.Size = new Size(951, 60);
		this.tableLayoutPanel_0.TabIndex = 7;
		this.button_2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.button_2.AutoSize = true;
		this.button_2.BackColor = Color.WhiteSmoke;
		this.button_2.Font = new Font(GClass107.smethod_3(133955), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_2.ForeColor = Color.Black;
		this.button_2.ImageKey = GClass107.smethod_3(133956);
		this.button_2.Location = new Point(320, 4);
		this.button_2.Margin = new Padding(3, 4, 3, 4);
		this.button_2.Name = GClass107.smethod_3(133965);
		this.button_2.Size = new Size(311, 52);
		this.button_2.TabIndex = 7;
		this.button_2.Tag = "";
		this.button_2.Text = "ESC";
		this.button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_2.UseVisualStyleBackColor = false;
		this.button_2.Click += this.button_2_Click;
		this.button_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.button_1.AutoSize = true;
		this.button_1.BackColor = Color.WhiteSmoke;
		this.button_1.Font = new Font(GClass107.smethod_3(133980), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_1.ForeColor = Color.Red;
		this.button_1.ImageKey = GClass107.smethod_3(134000);
		this.button_1.Location = new Point(3, 4);
		this.button_1.Margin = new Padding(3, 4, 3, 4);
		this.button_1.Name = GClass107.smethod_3(134007);
		this.button_1.Size = new Size(311, 52);
		this.button_1.TabIndex = 6;
		this.button_1.Tag = "";
		this.button_1.Text = "N";
		this.button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_1.UseVisualStyleBackColor = false;
		this.button_1.Click += this.button_1_Click;
		this.button_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.button_0.AutoSize = true;
		this.button_0.BackColor = Color.WhiteSmoke;
		this.button_0.Font = new Font(GClass107.smethod_3(134033), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_0.ForeColor = Color.Green;
		this.button_0.ImageKey = GClass107.smethod_3(134049);
		this.button_0.Location = new Point(637, 4);
		this.button_0.Margin = new Padding(3, 4, 3, 4);
		this.button_0.Name = GClass107.smethod_3(134072);
		this.button_0.Size = new Size(311, 52);
		this.button_0.TabIndex = 5;
		this.button_0.Tag = "";
		this.button_0.Text = "Y";
		this.button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_0.UseVisualStyleBackColor = false;
		this.button_0.Click += this.button_0_Click;
		this.timer_0.Enabled = true;
		this.timer_0.Interval = 400;
		this.timer_0.Tick += this.timer_0_Tick;
		this.panel_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_1.BackColor = Color.White;
		this.panel_1.Controls.Add(this.tableLayoutPanel_0);
		this.panel_1.Location = new Point(0, 231);
		this.panel_1.Margin = new Padding(3, 4, 3, 4);
		this.panel_1.Name = GClass107.smethod_3(134090);
		this.panel_1.Size = new Size(951, 78);
		this.panel_1.TabIndex = 1;
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.AutoSize = true;
		this.BackColor = Color.Red;
		base.ClientSize = new Size(951, 308);
		base.ControlBox = false;
		base.Controls.Add(this.panel_1);
		base.Controls.Add(this.panel_0);
		base.FormBorderStyle = FormBorderStyle.None;
		base.KeyPreview = true;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = GClass107.smethod_3(134119);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		base.FormClosing += this.GForm9_FormClosing;
		base.Shown += this.GForm9_Shown;
		base.FormClosed += this.GForm9_FormClosed;
		base.KeyUp += this.GForm9_KeyUp;
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		this.tableLayoutPanel_0.ResumeLayout(false);
		this.tableLayoutPanel_0.PerformLayout();
		this.panel_1.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	// Token: 0x04000454 RID: 1108
	private bool bool_0;

	// Token: 0x04000455 RID: 1109
	private bool bool_1;

	// Token: 0x04000456 RID: 1110
	private bool bool_2;

	// Token: 0x04000457 RID: 1111
	private bool bool_3;

	// Token: 0x04000458 RID: 1112
	private bool bool_4;

	// Token: 0x04000459 RID: 1113
	private string string_0;

	// Token: 0x0400045A RID: 1114
	private bool bool_5;

	// Token: 0x0400045B RID: 1115
	private string string_1;

	// Token: 0x0400045C RID: 1116
	private bool bool_6;

	// Token: 0x0400045D RID: 1117
	private bool bool_7;

	// Token: 0x0400045E RID: 1118
	private string string_2;

	// Token: 0x0400045F RID: 1119
	private bool bool_8;

	// Token: 0x04000460 RID: 1120
	private int int_0;

	// Token: 0x04000461 RID: 1121
	private int int_1;

	// Token: 0x04000462 RID: 1122
	private float float_0;

	// Token: 0x04000463 RID: 1123
	private float float_1;

	// Token: 0x04000464 RID: 1124
	private float float_2;

	// Token: 0x04000466 RID: 1126
	private Panel panel_0;

	// Token: 0x04000467 RID: 1127
	private Label label_0;

	// Token: 0x04000468 RID: 1128
	private Label label_1;

	// Token: 0x04000469 RID: 1129
	private Label label_2;

	// Token: 0x0400046A RID: 1130
	private Timer timer_0;

	// Token: 0x0400046B RID: 1131
	private Button button_0;

	// Token: 0x0400046C RID: 1132
	private Button button_1;

	// Token: 0x0400046D RID: 1133
	private TableLayoutPanel tableLayoutPanel_0;

	// Token: 0x0400046E RID: 1134
	private Button button_2;

	// Token: 0x0400046F RID: 1135
	private Panel panel_1;

	// Token: 0x020000AA RID: 170
	// (Invoke) Token: 0x0600058C RID: 1420
	private delegate void Delegate12(string message1, string message2, string message3, bool closeOnKeyPress, int autoCloseTimeMS);
}
