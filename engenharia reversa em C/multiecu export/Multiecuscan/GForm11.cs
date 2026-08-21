using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x020000AD RID: 173
public partial class GForm11 : Form
{
	// Token: 0x060005A6 RID: 1446 RVA: 0x000CDF40 File Offset: 0x000CC140
	public GForm11(string string_3, string string_4, string string_5, GClass104 gclass104_1, GClass11 gclass11_1)
	{
		this.method_9();
		GClass126.bool_24 = false;
		GClass126.bool_25 = false;
		this.string_0 = string_3;
		this.string_1 = string_4;
		this.string_2 = string_5;
		this.gclass104_0 = gclass104_1;
		this.gclass11_0 = gclass11_1;
		this.bool_2 = string_4.Equals(GClass121.smethod_6("1052"));
		this.label_1.Font = new Font(GClass125.smethod_28().FontFamily, this.label_1.Font.Size, this.label_1.Font.Style);
		this.label_0.Font = GClass125.smethod_28();
		this.label_2.Font = GClass125.smethod_28();
		this.label_1.Text = string_3;
		this.label_0.Text = string_4 + (this.bool_2 ? " ..." : "");
		this.label_2.Text = string_5;
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
		for (int i = gclass104_1.string_5.Length; i > 0; i--)
		{
			Button button = new Button();
			button.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			button.AutoSize = true;
			button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			button.FlatAppearance.BorderSize = 2;
			button.Font = GClass125.smethod_28();
			button.ForeColor = Color.Navy;
			button.FlatAppearance.BorderSize = 2;
			button.ImageKey = "KeyNew_" + i.ToString() + ".png";
			button.ImageList = this.imageList_0;
			button.Location = new Point(3, 3);
			button.Margin = new Padding(0, 0, 10, 0);
			button.MaximumSize = new Size(0, 46);
			button.MinimumSize = new Size(0, 46);
			button.Name = "btnAct" + i.ToString();
			button.Size = new Size(275, 46);
			button.TabIndex = 10 + i;
			button.Tag = "F" + (i - 1).ToString();
			button.Text = gclass104_1.string_5[i - 1].Substring(4);
			button.TextImageRelation = TextImageRelation.ImageBeforeText;
			button.UseVisualStyleBackColor = false;
			button.Click += this.method_7;
			this.flowLayoutPanel_0.Controls.Add(button);
		}
	}

	// Token: 0x060005A7 RID: 1447 RVA: 0x000CE418 File Offset: 0x000CC618
	private void GForm11_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && !e.Alt && !e.Control)
		{
			e.Handled = true;
			GClass126.bool_25 = true;
			this.method_8(this.gclass104_0.string_5.Length - 1);
			return;
		}
		if (e.KeyCode == Keys.D1 && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.method_8(0);
			return;
		}
		if (e.KeyCode == Keys.D2 && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.method_8(1);
			return;
		}
		if (e.KeyCode == Keys.D3 && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.method_8(2);
			return;
		}
		if (e.KeyCode == Keys.D4 && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.method_8(3);
			return;
		}
		if (e.KeyCode == Keys.D5 && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.method_8(4);
			return;
		}
		if (e.KeyCode == Keys.D6 && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.method_8(5);
			return;
		}
		if (e.KeyCode == Keys.D7 && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.method_8(6);
			return;
		}
		if (e.KeyCode == Keys.D8 && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.method_8(7);
		}
	}

	// Token: 0x060005A8 RID: 1448 RVA: 0x0000421A File Offset: 0x0000241A
	public void method_0(string string_3)
	{
		this.string_0 = string_3;
		this.bool_0 = true;
	}

	// Token: 0x060005A9 RID: 1449 RVA: 0x0000422A File Offset: 0x0000242A
	public string method_1()
	{
		return this.string_0;
	}

	// Token: 0x060005AA RID: 1450 RVA: 0x00004232 File Offset: 0x00002432
	public void method_2(string string_3)
	{
		this.string_1 = string_3;
		this.bool_1 = true;
	}

	// Token: 0x060005AB RID: 1451 RVA: 0x00004242 File Offset: 0x00002442
	public string method_3()
	{
		return this.string_1;
	}

	// Token: 0x060005AC RID: 1452 RVA: 0x0000424A File Offset: 0x0000244A
	public void method_4(string string_3)
	{
		this.string_2 = string_3;
		this.bool_3 = true;
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x0000425A File Offset: 0x0000245A
	public void method_5(string string_3, string string_4, string string_5, bool bool_5, int int_1)
	{
		base.Invoke(new GForm11.Delegate14(this.method_6), new object[]
		{
			string_3,
			string_4,
			string_5,
			bool_5,
			int_1
		});
	}

	// Token: 0x060005AE RID: 1454 RVA: 0x000CE5AC File Offset: 0x000CC7AC
	public void method_6(string string_3, string string_4, string string_5, bool bool_5, int int_1)
	{
		this.string_1 = this.string_1 + "  " + string_3;
		this.label_0.Text = this.string_1;
		if (GClass126.bool_25)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
		this.bool_4 = false;
		this.int_0 = 0;
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

	// Token: 0x060005AF RID: 1455 RVA: 0x000CE834 File Offset: 0x000CCA34
	private void timer_0_Tick(object sender, EventArgs e)
	{
		this.int_0 += this.timer_0.Interval;
		if (this.int_0 > 120000)
		{
			this.method_8(this.gclass104_0.string_5.Length - 1);
		}
		if (!base.Visible)
		{
			return;
		}
		if (this.gclass11_0 != null && !this.gclass11_0.method_18())
		{
			base.Close();
		}
		if (this.bool_2)
		{
			Label label = this.label_0;
			label.Text += ".";
			if (this.label_0.Text.Length > this.string_1.Length + 6)
			{
				this.label_0.Text = this.string_1 + " .";
			}
		}
		if (this.bool_0)
		{
			this.label_1.Text = this.string_0;
			this.label_1.Location = new Point((this.panel_0.Width - this.label_1.Width) / 2, this.label_1.Location.Y);
		}
		if (this.bool_1)
		{
			this.label_0.Text = this.string_1;
			this.label_0.Location = new Point((this.panel_0.Width - this.label_0.Width) / 2, this.label_0.Location.Y);
		}
		if (this.bool_3)
		{
			this.label_2.Text = this.string_2;
			this.label_2.Location = new Point((this.panel_0.Width - this.label_2.Width) / 2, this.label_2.Location.Y);
		}
	}

	// Token: 0x060005B0 RID: 1456 RVA: 0x000CE9FC File Offset: 0x000CCBFC
	private void method_7(object sender, EventArgs e)
	{
		int int_ = GClass127.smethod_37(((Button)sender).Tag.ToString().Replace("F", ""));
		this.method_8(int_);
	}

	// Token: 0x060005B1 RID: 1457 RVA: 0x000CEA38 File Offset: 0x000CCC38
	private void method_8(int int_1)
	{
		if (int_1 >= this.gclass104_0.string_5.Length)
		{
			return;
		}
		if (int_1 == this.gclass104_0.string_5.Length - 1)
		{
			GClass126.bool_25 = true;
		}
		if (this.bool_4 && !GClass126.bool_25)
		{
			return;
		}
		string text = this.gclass104_0.string_5[int_1];
		byte[] array = GClass127.smethod_32(string.Concat(new string[]
		{
			"0",
			text.Substring(0, 1),
			"0",
			text.Substring(1, 1),
			"0",
			text.Substring(2, 1),
			"0",
			text.Substring(3, 1)
		}));
		List<byte[]> list = new List<byte[]>();
		for (int i = 0; i < 4; i++)
		{
			if (array[i] > 0)
			{
				if ((int)(array[i] - 1) >= this.gclass104_0.byte_0.Length)
				{
					return;
				}
				list.Add(this.gclass104_0.byte_0[(int)(array[i] - 1)]);
			}
		}
		if (list.Count > 0)
		{
			this.string_1 = text.Substring(4) + "...";
			this.bool_1 = true;
			GClass104 gclass = new GClass104();
			gclass.byte_0 = list.ToArray();
			gclass.string_2 = "NOWAIT";
			gclass.string_4 = this.gclass104_0.string_4;
			gclass.string_0 = this.gclass104_0.string_0;
			gclass.int_1 = this.gclass104_0.int_1;
			gclass.int_2 = this.gclass104_0.int_2;
			gclass.int_0 = this.gclass104_0.int_0;
			this.bool_4 = true;
			if (this.gclass11_0 != null)
			{
				this.gclass11_0.method_27(gclass);
			}
		}
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x00004295 File Offset: 0x00002495
	private void GForm11_FormClosed(object sender, FormClosedEventArgs e)
	{
		this.timer_0.Stop();
	}

	// Token: 0x060005B4 RID: 1460 RVA: 0x000CEBF0 File Offset: 0x000CCDF0
	private void method_9()
	{
		this.icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GForm11));
		this.panel_0 = new Panel();
		this.label_2 = new Label();
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.timer_0 = new Timer(this.icontainer_0);
		this.panel_1 = new Panel();
		this.imageList_0 = new ImageList(this.icontainer_0);
		this.flowLayoutPanel_0 = new FlowLayoutPanel();
		this.panel_0.SuspendLayout();
		this.panel_1.SuspendLayout();
		base.SuspendLayout();
		this.panel_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_0.BackColor = Color.Black;
		this.panel_0.Controls.Add(this.label_2);
		this.panel_0.Controls.Add(this.label_0);
		this.panel_0.Controls.Add(this.label_1);
		this.panel_0.ForeColor = Color.Navy;
		this.panel_0.Location = new Point(14, 15);
		this.panel_0.Margin = new Padding(3, 4, 3, 4);
		this.panel_0.Name = GClass107.smethod_3(135721);
		this.panel_0.Size = new Size(924, 200);
		this.panel_0.TabIndex = 0;
		this.label_2.AutoSize = true;
		this.label_2.Font = new Font(GClass107.smethod_3(135729), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_2.ForeColor = Color.White;
		this.label_2.Location = new Point(86, 141);
		this.label_2.Name = GClass107.smethod_3(135744);
		this.label_2.Size = new Size(258, 38);
		this.label_2.TabIndex = 2;
		this.label_2.Text = GClass107.smethod_3(135771);
		this.label_0.AutoSize = true;
		this.label_0.Font = new Font(GClass107.smethod_3(135812), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_0.ForeColor = Color.White;
		this.label_0.Location = new Point(86, 95);
		this.label_0.Name = GClass107.smethod_3(135834);
		this.label_0.Size = new Size(258, 38);
		this.label_0.TabIndex = 1;
		this.label_0.Text = GClass107.smethod_3(135852);
		this.label_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.label_1.AutoSize = true;
		this.label_1.BackColor = Color.Transparent;
		this.label_1.Font = new Font(GClass107.smethod_3(135877), 28.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_1.ForeColor = Color.Red;
		this.label_1.Location = new Point(39, 18);
		this.label_1.Name = GClass107.smethod_3(135925);
		this.label_1.Size = new Size(452, 66);
		this.label_1.TabIndex = 0;
		this.label_1.Text = GClass107.smethod_3(135968);
		this.label_1.TextAlign = ContentAlignment.MiddleCenter;
		this.timer_0.Enabled = true;
		this.timer_0.Interval = 400;
		this.timer_0.Tick += this.timer_0_Tick;
		this.panel_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_1.BackColor = Color.White;
		this.panel_1.Controls.Add(this.flowLayoutPanel_0);
		this.panel_1.Location = new Point(0, 231);
		this.panel_1.Margin = new Padding(3, 4, 3, 4);
		this.panel_1.Name = GClass107.smethod_3(135978);
		this.panel_1.Size = new Size(951, 78);
		this.panel_1.TabIndex = 1;
		this.imageList_0.ImageStream = (ImageListStreamer)componentResourceManager.GetObject(GClass107.smethod_3(136014));
		this.imageList_0.TransparentColor = Color.Transparent;
		this.imageList_0.Images.SetKeyName(0, GClass107.smethod_3(136048));
		this.imageList_0.Images.SetKeyName(1, GClass107.smethod_3(136070));
		this.imageList_0.Images.SetKeyName(2, GClass107.smethod_3(136078));
		this.imageList_0.Images.SetKeyName(3, GClass107.smethod_3(136082));
		this.imageList_0.Images.SetKeyName(4, GClass107.smethod_3(136108));
		this.imageList_0.Images.SetKeyName(5, GClass107.smethod_3(136139));
		this.imageList_0.Images.SetKeyName(6, GClass107.smethod_3(136175));
		this.imageList_0.Images.SetKeyName(7, GClass107.smethod_3(136219));
		this.imageList_0.Images.SetKeyName(8, GClass107.smethod_3(136232));
		this.flowLayoutPanel_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.flowLayoutPanel_0.FlowDirection = FlowDirection.RightToLeft;
		this.flowLayoutPanel_0.Location = new Point(0, 12);
		this.flowLayoutPanel_0.Name = GClass107.smethod_3(136264);
		this.flowLayoutPanel_0.Size = new Size(951, 60);
		this.flowLayoutPanel_0.TabIndex = 8;
		this.flowLayoutPanel_0.WrapContents = false;
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
		base.Name = GClass107.smethod_3(136274);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		base.FormClosed += this.GForm11_FormClosed;
		base.KeyUp += this.GForm11_KeyUp;
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		this.panel_1.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	// Token: 0x0400048F RID: 1167
	private string string_0;

	// Token: 0x04000490 RID: 1168
	private bool bool_0;

	// Token: 0x04000491 RID: 1169
	private string string_1;

	// Token: 0x04000492 RID: 1170
	private bool bool_1;

	// Token: 0x04000493 RID: 1171
	private bool bool_2;

	// Token: 0x04000494 RID: 1172
	private string string_2;

	// Token: 0x04000495 RID: 1173
	private bool bool_3;

	// Token: 0x04000496 RID: 1174
	private int int_0;

	// Token: 0x04000497 RID: 1175
	private float float_0;

	// Token: 0x04000498 RID: 1176
	private float float_1;

	// Token: 0x04000499 RID: 1177
	private float float_2;

	// Token: 0x0400049A RID: 1178
	private GClass104 gclass104_0;

	// Token: 0x0400049B RID: 1179
	private GClass11 gclass11_0;

	// Token: 0x0400049C RID: 1180
	private bool bool_4;

	// Token: 0x0400049E RID: 1182
	private Panel panel_0;

	// Token: 0x0400049F RID: 1183
	private Label label_0;

	// Token: 0x040004A0 RID: 1184
	private Label label_1;

	// Token: 0x040004A1 RID: 1185
	private Label label_2;

	// Token: 0x040004A2 RID: 1186
	private Timer timer_0;

	// Token: 0x040004A3 RID: 1187
	private Panel panel_1;

	// Token: 0x040004A4 RID: 1188
	private ImageList imageList_0;

	// Token: 0x040004A5 RID: 1189
	private FlowLayoutPanel flowLayoutPanel_0;

	// Token: 0x020000AE RID: 174
	// (Invoke) Token: 0x060005B6 RID: 1462
	private delegate void Delegate14(string message1, string message2, string message3, bool closeOnKeyPress, int autoCloseTimeMS);
}
