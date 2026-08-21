using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000072 RID: 114
public sealed class GClass60 : Panel
{
	// Token: 0x060003A3 RID: 931 RVA: 0x00077B8C File Offset: 0x00075D8C
	public GClass60()
	{
		this.DoubleBuffered = true;
		this.method_0();
		this.vScrollBar.Value = 0;
		this.vScrollBar.Maximum = 0;
		this.vScrollBar.Enabled = false;
		this.label1.Visible = true;
		this.int_0 = this.label1.Height;
		this.label1.Visible = false;
		this.int_2 = base.Height / this.int_0;
		this.int_1[1] = (int)((float)(base.Width - this.vScrollBar.Width - this.int_1[0]) * 0.65f);
		this.int_1[2] = (int)((float)(base.Width - this.vScrollBar.Width - this.int_1[0]) * 0.35f);
		this.list_0.Clear();
		this.list_1.Clear();
		this.list_2.Clear();
		this.list_3.Clear();
		for (int i = 0; i < this.int_2; i++)
		{
			int num = i * this.int_0;
			this.list_0.Add(new GClass54());
			this.list_0[i].Location = new Point(0, num);
			this.list_0[i].Size = new Size(this.int_1[0], this.int_0 - 1);
			this.list_0[i].CheckAlign = ContentAlignment.MiddleCenter;
			this.list_0[i].Margin = new Padding(0);
			this.list_0[i].method_1(i);
			this.list_0[i].MouseDoubleClick += this.method_7;
			this.list_0[i].MouseClick += this.method_6;
			base.Controls.Add(this.list_0[i]);
			this.list_1.Add(new GClass1());
			this.list_1[i].Location = new Point(this.int_1[0] + 1, num);
			this.list_1[i].Size = new Size(this.int_1[1], this.int_0 - 1);
			this.list_1[i].ForeColor = Color.Navy;
			this.list_1[i].TextAlign = ContentAlignment.MiddleLeft;
			this.list_1[i].Margin = new Padding(0);
			this.list_1[i].method_1(i);
			this.list_1[i].MouseDoubleClick += this.method_5;
			this.list_1[i].MouseClick += this.method_4;
			base.Controls.Add(this.list_1[i]);
			this.list_2.Add(new GClass1());
			this.list_2[i].Location = new Point(this.int_1[0] + this.int_1[1] + 2, num);
			this.list_2[i].Size = new Size(this.int_1[2], this.int_0 - 1);
			this.list_2[i].ForeColor = Color.Navy;
			this.list_2[i].TextAlign = ContentAlignment.MiddleLeft;
			this.list_2[i].Margin = new Padding(0);
			this.list_2[i].method_1(i);
			this.list_2[i].MouseDoubleClick += this.method_5;
			this.list_2[i].MouseClick += this.method_4;
			base.Controls.Add(this.list_2[i]);
			this.list_3.Add(new Panel());
			this.list_3[i].Location = new Point(0, num + this.int_0);
			this.list_3[i].Size = new Size(base.Width, 1);
			this.list_3[i].BackColor = SystemColors.ControlDark;
			base.Controls.Add(this.list_3[i]);
		}
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x000780B8 File Offset: 0x000762B8
	private void GClass60_Paint(object sender, PaintEventArgs e)
	{
		base.SuspendLayout();
		if (this.bool_1)
		{
			this.panelVLine0.Location = new Point(this.int_1[0], 0);
			this.panelVLine0.Size = new Size(1, base.Height);
			this.panelVLine1.Location = new Point(this.int_1[0] + this.int_1[1], 0);
			this.panelVLine1.Size = new Size(1, base.Height);
			for (int i = 0; i < this.list_0.Count; i++)
			{
				int num = i * this.int_0;
				this.list_0[i].Location = new Point(0, num);
				this.list_0[i].Size = new Size(this.int_1[0], this.int_0 - 1);
				this.list_1[i].Location = new Point(this.int_1[0] + 1, num);
				this.list_1[i].Size = new Size(this.int_1[1], this.int_0 - 1);
				this.list_2[i].Location = new Point(this.int_1[0] + this.int_1[1] + 2, num);
				this.list_2[i].Size = new Size(this.int_1[2], this.int_0 - 1);
				this.list_3[i].Size = new Size(base.Width, 1);
				this.list_3[i].Location = new Point(0, num + this.int_0);
			}
			this.bool_1 = false;
		}
		List<GClass58> list = GClass3.list_0;
		if (list.Count != 0)
		{
			int value = this.vScrollBar.Value;
			for (int i = 0; i < this.list_0.Count; i++)
			{
				if (list.Count <= i + value)
				{
					this.list_0[i].Visible = false;
				}
				else
				{
					this.list_0[i].Visible = true;
					if (this.list_0[i].Checked != list[i + value].bool_0)
					{
						this.list_0[i].Checked = list[i + value].bool_0;
					}
				}
				if (list.Count <= i + value)
				{
					this.list_1[i].Text = string.Empty;
				}
				else
				{
					this.list_1[i].ForeColor = (list[i + value].bool_0 ? this.color_2 : this.color_3);
					if (this.list_1[i].Text != list[i + value].string_0)
					{
						this.list_1[i].Text = list[i + value].string_0;
					}
				}
				if (list.Count <= i + value)
				{
					this.list_2[i].Text = string.Empty;
				}
				else
				{
					this.list_2[i].ForeColor = (list[i + value].bool_0 ? this.color_2 : this.color_3);
					if (this.list_2[i].Text != list[i + value].method_0() + " " + list[i + value].string_3)
					{
						this.list_2[i].Text = list[i + value].method_0() + " " + list[i + value].string_3;
					}
				}
				if (this.int_3 == i + value && this.list_0[i].BackColor != this.color_0)
				{
					this.list_0[i].BackColor = this.color_0;
					this.list_1[i].BackColor = this.color_0;
					this.list_2[i].BackColor = this.color_0;
				}
				else if (this.int_3 != i + value && this.list_0[i].BackColor != this.color_1)
				{
					this.list_0[i].BackColor = this.color_1;
					this.list_1[i].BackColor = this.color_1;
					this.list_2[i].BackColor = this.color_1;
				}
			}
			base.ResumeLayout();
		}
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x00078594 File Offset: 0x00076794
	private void method_0()
	{
		this.vScrollBar = new VScrollBar();
		this.label1 = new Label();
		this.panelVLine0 = new Panel();
		this.panelVLine1 = new Panel();
		base.SuspendLayout();
		this.vScrollBar.Dock = DockStyle.Right;
		this.vScrollBar.Name = "vScrollBar";
		this.vScrollBar.TabIndex = 1;
		this.vScrollBar.ValueChanged += this.vScrollBar_ValueChanged;
		this.label1.AutoSize = true;
		this.label1.ForeColor = Color.White;
		this.label1.Location = new Point(1, 1);
		this.label1.Name = "label1";
		this.label1.TabIndex = 15;
		this.label1.Tag = string.Empty;
		this.label1.Text = "Test Message";
		this.label1.Padding = new Padding(0, 2, 0, 2);
		this.panelVLine0.BackColor = SystemColors.ControlDark;
		this.panelVLine0.Location = new Point(0, 0);
		this.panelVLine0.Size = new Size(1, 10);
		this.panelVLine0.Name = "panelVLine0";
		this.panelVLine0.Cursor = Cursors.SizeWE;
		this.panelVLine1.BackColor = SystemColors.ControlDark;
		this.panelVLine1.Location = new Point(10, 0);
		this.panelVLine1.Size = new Size(1, 10);
		this.panelVLine1.Name = "panelVLine1";
		this.panelVLine1.Cursor = Cursors.SizeWE;
		this.panelVLine1.MouseDown += this.panelVLine1_MouseDown;
		this.panelVLine1.MouseUp += this.panelVLine1_MouseUp;
		this.panelVLine1.MouseMove += this.panelVLine1_MouseMove;
		this.AutoSize = false;
		base.BorderStyle = BorderStyle.FixedSingle;
		base.Controls.Add(this.vScrollBar);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.panelVLine0);
		base.Controls.Add(this.panelVLine1);
		base.Paint += this.GClass60_Paint;
		base.Resize += this.GClass60_Resize;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x060003A6 RID: 934 RVA: 0x00078804 File Offset: 0x00076A04
	// (set) Token: 0x060003A7 RID: 935 RVA: 0x00003361 File Offset: 0x00001561
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
			this.GClass60_Resize(null, null);
		}
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x0007881C File Offset: 0x00076A1C
	public void method_1(bool bool_2)
	{
		if (bool_2)
		{
			this.int_3 += this.int_2;
		}
		else
		{
			this.int_3++;
		}
		if (this.int_3 >= GClass3.list_0.Count)
		{
			this.int_3 = GClass3.list_0.Count - 1;
		}
		if (this.int_3 >= this.int_2 + this.vScrollBar.Value)
		{
			this.vScrollBar.Value = this.int_3 - this.int_2 + 1;
		}
		base.Invalidate();
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x000788B4 File Offset: 0x00076AB4
	public void method_2(bool bool_2)
	{
		if (bool_2)
		{
			this.int_3 -= this.int_2;
		}
		else
		{
			this.int_3--;
		}
		if (this.int_3 < 0)
		{
			this.int_3 = 0;
		}
		if (this.int_3 < this.vScrollBar.Value)
		{
			this.vScrollBar.Value = this.int_3;
		}
		base.Invalidate();
	}

	// Token: 0x060003AA RID: 938 RVA: 0x00078930 File Offset: 0x00076B30
	public void method_3()
	{
		if (this.int_3 < GClass3.list_0.Count)
		{
			GClass3.list_0[this.int_3].bool_0 = !GClass3.list_0[this.int_3].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x060003AB RID: 939 RVA: 0x00078988 File Offset: 0x00076B88
	private void GClass60_Resize(object sender, EventArgs e)
	{
		this.label1.Visible = true;
		this.int_0 = this.label1.Height;
		this.label1.Visible = false;
		int num = this.int_2;
		this.int_2 = base.Height / this.int_0;
		float num2 = (this.int_1[1] + this.int_1[2] == 0) ? 0.65f : ((float)this.int_1[1] / (float)(this.int_1[1] + this.int_1[2]));
		float num3 = (this.int_1[1] + this.int_1[2] == 0) ? 0.35f : ((float)this.int_1[2] / (float)(this.int_1[1] + this.int_1[2]));
		this.int_1[1] = (int)((float)(base.Width - this.vScrollBar.Width - this.int_1[0]) * num2);
		this.int_1[2] = (int)((float)(base.Width - this.vScrollBar.Width - this.int_1[0]) * num3);
		if (num < this.int_2)
		{
			for (int i = num - 1; i < this.int_2; i++)
			{
				int num4 = i * this.int_0;
				this.list_0.Add(new GClass54());
				this.list_0[i].Location = new Point(0, num4);
				this.list_0[i].Size = new Size(this.int_1[0], this.int_0 - 1);
				this.list_0[i].CheckAlign = ContentAlignment.MiddleCenter;
				this.list_0[i].Margin = new Padding(0);
				this.list_0[i].method_1(i);
				this.list_0[i].MouseDoubleClick += this.method_7;
				this.list_0[i].MouseClick += this.method_6;
				base.Controls.Add(this.list_0[i]);
				this.list_1.Add(new GClass1());
				this.list_1[i].Location = new Point(this.int_1[0] + 1, num4);
				this.list_1[i].Size = new Size(this.int_1[1], this.int_0 - 1);
				this.list_1[i].ForeColor = Color.Navy;
				this.list_1[i].TextAlign = ContentAlignment.MiddleLeft;
				this.list_1[i].Margin = new Padding(0);
				this.list_1[i].method_1(i);
				this.list_1[i].MouseDoubleClick += this.method_5;
				this.list_1[i].MouseClick += this.method_4;
				base.Controls.Add(this.list_1[i]);
				this.list_2.Add(new GClass1());
				this.list_2[i].Location = new Point(this.int_1[0] + this.int_1[1] + 2, num4);
				this.list_2[i].Size = new Size(this.int_1[2], this.int_0 - 1);
				this.list_2[i].ForeColor = Color.Navy;
				this.list_2[i].TextAlign = ContentAlignment.MiddleLeft;
				this.list_2[i].Margin = new Padding(0);
				this.list_2[i].method_1(i);
				this.list_2[i].MouseDoubleClick += this.method_5;
				this.list_2[i].MouseClick += this.method_4;
				base.Controls.Add(this.list_2[i]);
				this.list_3.Add(new Panel());
				this.list_3[i].Location = new Point(0, num4 + this.int_0);
				this.list_3[i].Size = new Size(base.Width, 1);
				this.list_3[i].BackColor = SystemColors.ControlDark;
				base.Controls.Add(this.list_3[i]);
			}
		}
		this.bool_1 = true;
		int num5 = GClass3.list_0.Count - this.int_2 + 1;
		if (num5 > 0)
		{
			this.vScrollBar.Enabled = true;
			this.vScrollBar.Maximum = GClass3.list_0.Count;
			this.vScrollBar.LargeChange = this.int_2;
		}
		else
		{
			this.vScrollBar.Enabled = false;
			this.vScrollBar.Value = 0;
			this.vScrollBar.Maximum = 0;
		}
		base.Invalidate();
	}

	// Token: 0x060003AC RID: 940 RVA: 0x00003372 File Offset: 0x00001572
	private void vScrollBar_ValueChanged(object sender, EventArgs e)
	{
		base.Invalidate();
	}

	// Token: 0x060003AD RID: 941 RVA: 0x0000337A File Offset: 0x0000157A
	private void panelVLine1_MouseDown(object sender, MouseEventArgs e)
	{
		this.int_5 = this.int_1[1];
		this.bool_0 = true;
	}

	// Token: 0x060003AE RID: 942 RVA: 0x00003391 File Offset: 0x00001591
	private void panelVLine1_MouseUp(object sender, MouseEventArgs e)
	{
		this.bool_0 = false;
	}

	// Token: 0x060003AF RID: 943 RVA: 0x00078EA4 File Offset: 0x000770A4
	private void panelVLine1_MouseMove(object sender, MouseEventArgs e)
	{
		if (this.bool_0)
		{
			this.int_1[1] = this.int_5 + e.X;
			if (this.int_1[1] < 10)
			{
				this.int_1[1] = 10;
			}
			if (this.int_1[0] + this.int_1[1] + this.vScrollBar.Width + 10 > base.Width)
			{
				this.int_1[1] = base.Width - this.vScrollBar.Width - this.int_1[0] - 10;
			}
			this.int_1[2] = base.Width - this.vScrollBar.Width - this.int_1[0] - this.int_1[1];
			this.bool_1 = true;
			base.Invalidate();
		}
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x00078F7C File Offset: 0x0007717C
	private void method_4(object sender, MouseEventArgs e)
	{
		int num = ((GClass1)sender).method_0();
		this.int_3 = num + this.vScrollBar.Value;
		base.Invalidate();
	}

	// Token: 0x060003B1 RID: 945 RVA: 0x00078FB0 File Offset: 0x000771B0
	private void method_5(object sender, MouseEventArgs e)
	{
		int num = ((GClass1)sender).method_0();
		this.int_3 = num + this.vScrollBar.Value;
		if (this.int_3 < GClass3.list_0.Count)
		{
			GClass3.list_0[this.int_3].bool_0 = !GClass3.list_0[this.int_3].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x060003B2 RID: 946 RVA: 0x00079028 File Offset: 0x00077228
	private void method_6(object sender, MouseEventArgs e)
	{
		int num = ((GClass54)sender).method_0();
		this.int_3 = num + this.vScrollBar.Value;
		if (this.int_3 < GClass3.list_0.Count)
		{
			GClass3.list_0[this.int_3].bool_0 = !GClass3.list_0[this.int_3].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x00079028 File Offset: 0x00077228
	private void method_7(object sender, MouseEventArgs e)
	{
		int num = ((GClass54)sender).method_0();
		this.int_3 = num + this.vScrollBar.Value;
		if (this.int_3 < GClass3.list_0.Count)
		{
			GClass3.list_0[this.int_3].bool_0 = !GClass3.list_0[this.int_3].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x04000526 RID: 1318
	private VScrollBar vScrollBar;

	// Token: 0x04000527 RID: 1319
	private Label label1;

	// Token: 0x04000528 RID: 1320
	private Panel panelVLine0;

	// Token: 0x04000529 RID: 1321
	private Panel panelVLine1;

	// Token: 0x0400052A RID: 1322
	private int int_0 = 0;

	// Token: 0x0400052B RID: 1323
	private int[] int_1 = new int[]
	{
		40,
		300,
		100
	};

	// Token: 0x0400052C RID: 1324
	private int int_2 = 0;

	// Token: 0x0400052D RID: 1325
	private int int_3 = -1;

	// Token: 0x0400052E RID: 1326
	private int int_4 = -1;

	// Token: 0x0400052F RID: 1327
	private int int_5 = 0;

	// Token: 0x04000530 RID: 1328
	private bool bool_0 = false;

	// Token: 0x04000531 RID: 1329
	private bool bool_1 = false;

	// Token: 0x04000532 RID: 1330
	private List<GClass54> list_0 = new List<GClass54>();

	// Token: 0x04000533 RID: 1331
	private List<GClass1> list_1 = new List<GClass1>();

	// Token: 0x04000534 RID: 1332
	private List<GClass1> list_2 = new List<GClass1>();

	// Token: 0x04000535 RID: 1333
	private List<Panel> list_3 = new List<Panel>();

	// Token: 0x04000536 RID: 1334
	private Color color_0 = Color.FromArgb(255, 255, 128);

	// Token: 0x04000537 RID: 1335
	private Color color_1 = Color.White;

	// Token: 0x04000538 RID: 1336
	private Color color_2 = Color.Red;

	// Token: 0x04000539 RID: 1337
	private Color color_3 = Color.Navy;

	// Token: 0x0400053A RID: 1338
	private int int_6 = 0;
}
