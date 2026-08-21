using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x020000C0 RID: 192
public class GClass120 : Panel
{
	// Token: 0x0600065D RID: 1629 RVA: 0x000E231C File Offset: 0x000E051C
	public GClass120()
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
			this.list_0.Add(new GClass110());
			this.list_0[i].Location = new Point(0, num);
			this.list_0[i].Size = new Size(this.int_1[0], this.int_0 - 1);
			this.list_0[i].CheckAlign = ContentAlignment.MiddleCenter;
			this.list_0[i].Margin = new Padding(0);
			this.list_0[i].method_1(i);
			this.list_0[i].MouseDoubleClick += this.method_7;
			this.list_0[i].MouseClick += this.method_6;
			base.Controls.Add(this.list_0[i]);
			this.list_1.Add(new GClass112());
			this.list_1[i].Location = new Point(this.int_1[0] + 1, num);
			this.list_1[i].Size = new Size(this.int_1[1], this.int_0 - 1);
			this.list_1[i].ForeColor = Color.Navy;
			this.list_1[i].TextAlign = ContentAlignment.MiddleLeft;
			this.list_1[i].Margin = new Padding(0);
			this.list_1[i].method_1(i);
			this.list_1[i].MouseDoubleClick += this.method_5;
			this.list_1[i].MouseClick += this.method_4;
			base.Controls.Add(this.list_1[i]);
			this.list_2.Add(new GClass112());
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

	// Token: 0x0600065E RID: 1630 RVA: 0x000E281C File Offset: 0x000E0A1C
	private void GClass120_Paint(object sender, PaintEventArgs e)
	{
		base.SuspendLayout();
		if (this.bool_1)
		{
			this.panel_0.Location = new Point(this.int_1[0], 0);
			this.panel_0.Size = new Size(1, base.Height);
			this.panel_1.Location = new Point(this.int_1[0] + this.int_1[1], 0);
			this.panel_1.Size = new Size(1, base.Height);
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
		List<GClass104> list = GClass126.list_0;
		if (list.Count == 0)
		{
			return;
		}
		int value = this.vScrollBar.Value;
		for (int j = 0; j < this.list_0.Count; j++)
		{
			if (list.Count <= j + value)
			{
				this.list_0[j].Visible = false;
			}
			else
			{
				this.list_0[j].Visible = true;
				if (this.list_0[j].Checked != list[j + value].bool_0)
				{
					this.list_0[j].Checked = list[j + value].bool_0;
				}
			}
			if (list.Count <= j + value)
			{
				this.list_1[j].Text = "";
			}
			else
			{
				this.list_1[j].ForeColor = (list[j + value].bool_0 ? this.color_2 : this.color_3);
				if (this.list_1[j].Text != list[j + value].string_0)
				{
					this.list_1[j].Text = list[j + value].string_0;
				}
			}
			if (list.Count <= j + value)
			{
				this.list_2[j].Text = "";
			}
			else
			{
				this.list_2[j].ForeColor = (list[j + value].bool_0 ? this.color_2 : this.color_3);
				if (this.list_2[j].Text != list[j + value].method_0() + " " + list[j + value].string_3)
				{
					this.list_2[j].Text = list[j + value].method_0() + " " + list[j + value].string_3;
				}
			}
			if (this.int_3 == j + value && this.list_0[j].BackColor != this.color_0)
			{
				this.list_0[j].BackColor = this.color_0;
				this.list_1[j].BackColor = this.color_0;
				this.list_2[j].BackColor = this.color_0;
			}
			else if (this.int_3 != j + value && this.list_0[j].BackColor != this.color_1)
			{
				this.list_0[j].BackColor = this.color_1;
				this.list_1[j].BackColor = this.color_1;
				this.list_2[j].BackColor = this.color_1;
			}
		}
		base.ResumeLayout();
	}

	// Token: 0x0600065F RID: 1631 RVA: 0x000E2CF4 File Offset: 0x000E0EF4
	private void method_0()
	{
		this.vScrollBar = new VScrollBar();
		this.label1 = new Label();
		this.panel_0 = new Panel();
		this.panel_1 = new Panel();
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
		this.label1.Tag = "";
		this.label1.Text = "Test Message";
		this.label1.Padding = new Padding(0, 2, 0, 2);
		this.panel_0.BackColor = SystemColors.ControlDark;
		this.panel_0.Location = new Point(0, 0);
		this.panel_0.Size = new Size(1, 10);
		this.panel_0.Name = "panelVLine0";
		this.panel_0.Cursor = Cursors.SizeWE;
		this.panel_1.BackColor = SystemColors.ControlDark;
		this.panel_1.Location = new Point(10, 0);
		this.panel_1.Size = new Size(1, 10);
		this.panel_1.Name = "panelVLine1";
		this.panel_1.Cursor = Cursors.SizeWE;
		this.panel_1.MouseDown += this.panel_1_MouseDown;
		this.panel_1.MouseUp += this.panel_1_MouseUp;
		this.panel_1.MouseMove += this.panel_1_MouseMove;
		this.AutoSize = false;
		base.BorderStyle = BorderStyle.FixedSingle;
		base.Controls.Add(this.vScrollBar);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.panel_0);
		base.Controls.Add(this.panel_1);
		base.Paint += this.GClass120_Paint;
		base.Resize += this.GClass120_Resize;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x17000020 RID: 32
	// (get) Token: 0x06000660 RID: 1632 RVA: 0x000045A2 File Offset: 0x000027A2
	// (set) Token: 0x06000661 RID: 1633 RVA: 0x000045DF File Offset: 0x000027DF
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
			this.GClass120_Resize(null, null);
		}
	}

	// Token: 0x06000662 RID: 1634 RVA: 0x000E2F64 File Offset: 0x000E1164
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
		if (this.int_3 >= GClass126.list_0.Count)
		{
			this.int_3 = GClass126.list_0.Count - 1;
		}
		if (this.int_3 >= this.int_2 + this.vScrollBar.Value)
		{
			this.vScrollBar.Value = this.int_3 - this.int_2 + 1;
		}
		base.Invalidate();
	}

	// Token: 0x06000663 RID: 1635 RVA: 0x000E2FF8 File Offset: 0x000E11F8
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

	// Token: 0x06000664 RID: 1636 RVA: 0x000E3068 File Offset: 0x000E1268
	public void method_3()
	{
		if (this.int_3 < GClass126.list_0.Count)
		{
			GClass126.list_0[this.int_3].bool_0 = !GClass126.list_0[this.int_3].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x06000665 RID: 1637 RVA: 0x000E30BC File Offset: 0x000E12BC
	private void GClass120_Resize(object sender, EventArgs e)
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
				this.list_0.Add(new GClass110());
				this.list_0[i].Location = new Point(0, num4);
				this.list_0[i].Size = new Size(this.int_1[0], this.int_0 - 1);
				this.list_0[i].CheckAlign = ContentAlignment.MiddleCenter;
				this.list_0[i].Margin = new Padding(0);
				this.list_0[i].method_1(i);
				this.list_0[i].MouseDoubleClick += this.method_7;
				this.list_0[i].MouseClick += this.method_6;
				base.Controls.Add(this.list_0[i]);
				this.list_1.Add(new GClass112());
				this.list_1[i].Location = new Point(this.int_1[0] + 1, num4);
				this.list_1[i].Size = new Size(this.int_1[1], this.int_0 - 1);
				this.list_1[i].ForeColor = Color.Navy;
				this.list_1[i].TextAlign = ContentAlignment.MiddleLeft;
				this.list_1[i].Margin = new Padding(0);
				this.list_1[i].method_1(i);
				this.list_1[i].MouseDoubleClick += this.method_5;
				this.list_1[i].MouseClick += this.method_4;
				base.Controls.Add(this.list_1[i]);
				this.list_2.Add(new GClass112());
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
		if (GClass126.list_0.Count - this.int_2 + 1 > 0)
		{
			this.vScrollBar.Enabled = true;
			this.vScrollBar.Maximum = GClass126.list_0.Count;
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

	// Token: 0x06000666 RID: 1638 RVA: 0x000045BB File Offset: 0x000027BB
	private void vScrollBar_ValueChanged(object sender, EventArgs e)
	{
		base.Invalidate();
	}

	// Token: 0x06000667 RID: 1639 RVA: 0x000045F0 File Offset: 0x000027F0
	private void panel_1_MouseDown(object sender, MouseEventArgs e)
	{
		this.int_5 = this.int_1[1];
		this.bool_0 = true;
	}

	// Token: 0x06000668 RID: 1640 RVA: 0x00004607 File Offset: 0x00002807
	private void panel_1_MouseUp(object sender, MouseEventArgs e)
	{
		this.bool_0 = false;
	}

	// Token: 0x06000669 RID: 1641 RVA: 0x000E35C8 File Offset: 0x000E17C8
	private void panel_1_MouseMove(object sender, MouseEventArgs e)
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

	// Token: 0x0600066A RID: 1642 RVA: 0x000E3694 File Offset: 0x000E1894
	private void method_4(object sender, MouseEventArgs e)
	{
		int num = ((GClass112)sender).method_0();
		this.int_3 = num + this.vScrollBar.Value;
		base.Invalidate();
	}

	// Token: 0x0600066B RID: 1643 RVA: 0x000E36C8 File Offset: 0x000E18C8
	private void method_5(object sender, MouseEventArgs e)
	{
		int num = ((GClass112)sender).method_0();
		this.int_3 = num + this.vScrollBar.Value;
		if (this.int_3 < GClass126.list_0.Count)
		{
			GClass126.list_0[this.int_3].bool_0 = !GClass126.list_0[this.int_3].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x0600066C RID: 1644 RVA: 0x000E373C File Offset: 0x000E193C
	private void method_6(object sender, MouseEventArgs e)
	{
		int num = ((GClass110)sender).method_0();
		this.int_3 = num + this.vScrollBar.Value;
		if (this.int_3 < GClass126.list_0.Count)
		{
			GClass126.list_0[this.int_3].bool_0 = !GClass126.list_0[this.int_3].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x0600066D RID: 1645 RVA: 0x000E373C File Offset: 0x000E193C
	private void method_7(object sender, MouseEventArgs e)
	{
		int num = ((GClass110)sender).method_0();
		this.int_3 = num + this.vScrollBar.Value;
		if (this.int_3 < GClass126.list_0.Count)
		{
			GClass126.list_0[this.int_3].bool_0 = !GClass126.list_0[this.int_3].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x040005A4 RID: 1444
	private VScrollBar vScrollBar;

	// Token: 0x040005A5 RID: 1445
	private Label label1;

	// Token: 0x040005A6 RID: 1446
	private Panel panel_0;

	// Token: 0x040005A7 RID: 1447
	private Panel panel_1;

	// Token: 0x040005A8 RID: 1448
	private int int_0;

	// Token: 0x040005A9 RID: 1449
	private int[] int_1 = new int[]
	{
		40,
		300,
		100
	};

	// Token: 0x040005AA RID: 1450
	private int int_2;

	// Token: 0x040005AB RID: 1451
	private int int_3 = -1;

	// Token: 0x040005AC RID: 1452
	private int int_4 = -1;

	// Token: 0x040005AD RID: 1453
	private int int_5;

	// Token: 0x040005AE RID: 1454
	private bool bool_0;

	// Token: 0x040005AF RID: 1455
	private bool bool_1;

	// Token: 0x040005B0 RID: 1456
	private List<GClass110> list_0 = new List<GClass110>();

	// Token: 0x040005B1 RID: 1457
	private List<GClass112> list_1 = new List<GClass112>();

	// Token: 0x040005B2 RID: 1458
	private List<GClass112> list_2 = new List<GClass112>();

	// Token: 0x040005B3 RID: 1459
	private List<Panel> list_3 = new List<Panel>();

	// Token: 0x040005B4 RID: 1460
	private Color color_0 = Color.FromArgb(255, 255, 128);

	// Token: 0x040005B5 RID: 1461
	private Color color_1 = Color.White;

	// Token: 0x040005B6 RID: 1462
	private Color color_2 = Color.Red;

	// Token: 0x040005B7 RID: 1463
	private Color color_3 = Color.Navy;

	// Token: 0x040005B8 RID: 1464
	private int int_6;
}
