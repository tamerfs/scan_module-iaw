using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x0200008A RID: 138
public sealed class GClass67 : Panel
{
	// Token: 0x0600050B RID: 1291 RVA: 0x000942C4 File Offset: 0x000924C4
	public GClass67()
	{
		this.method_0();
		this.vScrollBar.Value = 0;
		this.vScrollBar.Maximum = 0;
		this.vScrollBar.Enabled = false;
		this.label1.Visible = true;
		this.int_0 = this.label1.Height;
		this.label1.Visible = false;
		int num = base.Height / this.int_0;
		float width = (float)(this.tableLayoutPanel.Width - 40) * 0.65f;
		float width2 = (float)(this.tableLayoutPanel.Width - 40) * 0.35f;
		this.tableLayoutPanel.ColumnCount = 3;
		this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40f));
		this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, width));
		this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, width2));
		this.list_0.Clear();
		this.list_1.Clear();
		this.list_2.Clear();
		this.tableLayoutPanel.RowCount = num;
		for (int i = 0; i < num; i++)
		{
			this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, (float)this.int_0));
			this.list_0.Add(new GClass54());
			this.list_0[i].Dock = DockStyle.Fill;
			this.list_0[i].CheckAlign = ContentAlignment.MiddleCenter;
			this.list_0[i].Margin = new Padding(0);
			this.list_0[i].method_1(i);
			this.list_0[i].MouseDoubleClick += this.method_7;
			this.list_0[i].MouseClick += this.method_6;
			this.tableLayoutPanel.Controls.Add(this.list_0[i]);
			this.list_1.Add(new GClass1());
			this.list_1[i].Dock = DockStyle.Fill;
			this.list_1[i].ForeColor = Color.Navy;
			this.list_1[i].TextAlign = ContentAlignment.MiddleLeft;
			this.list_1[i].Margin = new Padding(0);
			this.list_1[i].method_1(i);
			this.list_1[i].MouseDoubleClick += this.method_5;
			this.list_1[i].MouseClick += this.method_4;
			this.tableLayoutPanel.Controls.Add(this.list_1[i]);
			this.list_2.Add(new GClass1());
			this.list_2[i].Dock = DockStyle.Fill;
			this.list_2[i].ForeColor = Color.Navy;
			this.list_2[i].TextAlign = ContentAlignment.MiddleLeft;
			this.list_2[i].Margin = new Padding(0);
			this.list_2[i].method_1(i);
			this.list_2[i].MouseDoubleClick += this.method_5;
			this.list_2[i].MouseClick += this.method_4;
			this.tableLayoutPanel.Controls.Add(this.list_2[i]);
		}
	}

	// Token: 0x0600050C RID: 1292 RVA: 0x000946DC File Offset: 0x000928DC
	private void GClass67_Paint(object sender, PaintEventArgs e)
	{
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
				if (this.int_1 == i + value && this.list_0[i].BackColor != this.color_0)
				{
					this.list_0[i].BackColor = this.color_0;
					this.list_1[i].BackColor = this.color_0;
					this.list_2[i].BackColor = this.color_0;
				}
				else if (this.int_1 != i + value && this.list_0[i].BackColor != this.color_1)
				{
					this.list_0[i].BackColor = this.color_1;
					this.list_1[i].BackColor = this.color_1;
					this.list_2[i].BackColor = this.color_1;
				}
			}
		}
	}

	// Token: 0x0600050D RID: 1293 RVA: 0x000949F4 File Offset: 0x00092BF4
	private void method_0()
	{
		this.vScrollBar = new VScrollBar();
		this.tableLayoutPanel = new GClass68();
		this.label1 = new Label();
		base.SuspendLayout();
		this.tableLayoutPanel.Dock = DockStyle.Fill;
		this.tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
		this.tableLayoutPanel.ColumnCount = 0;
		this.tableLayoutPanel.Name = "tableLayoutPanel";
		this.tableLayoutPanel.RowCount = 0;
		this.tableLayoutPanel.TabIndex = 1;
		this.tableLayoutPanel.MouseMove += this.tableLayoutPanel_MouseMove;
		this.tableLayoutPanel.MouseDown += this.tableLayoutPanel_MouseDown;
		this.tableLayoutPanel.MouseUp += this.tableLayoutPanel_MouseUp;
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
		base.BorderStyle = BorderStyle.FixedSingle;
		base.Controls.Add(this.tableLayoutPanel);
		base.Controls.Add(this.vScrollBar);
		base.Controls.Add(this.label1);
		base.Paint += this.GClass67_Paint;
		base.Resize += this.GClass67_Resize;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x0600050E RID: 1294 RVA: 0x00078804 File Offset: 0x00076A04
	// (set) Token: 0x0600050F RID: 1295 RVA: 0x00003976 File Offset: 0x00001B76
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
			this.GClass67_Resize(null, null);
		}
	}

	// Token: 0x06000510 RID: 1296 RVA: 0x00094BE4 File Offset: 0x00092DE4
	public void method_1(bool bool_0)
	{
		if (bool_0)
		{
			this.int_1 += this.tableLayoutPanel.RowCount;
		}
		else
		{
			this.int_1++;
		}
		if (this.int_1 >= GClass3.list_0.Count)
		{
			this.int_1 = GClass3.list_0.Count - 1;
		}
		if (this.int_1 >= this.tableLayoutPanel.RowCount + this.vScrollBar.Value)
		{
			this.vScrollBar.Value = this.int_1 - this.tableLayoutPanel.RowCount + 1;
		}
		base.Invalidate();
	}

	// Token: 0x06000511 RID: 1297 RVA: 0x00094C8C File Offset: 0x00092E8C
	public void method_2(bool bool_0)
	{
		if (bool_0)
		{
			this.int_1 -= this.tableLayoutPanel.RowCount;
		}
		else
		{
			this.int_1--;
		}
		if (this.int_1 < 0)
		{
			this.int_1 = 0;
		}
		if (this.int_1 < this.vScrollBar.Value)
		{
			this.vScrollBar.Value = this.int_1;
		}
		base.Invalidate();
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x00094D0C File Offset: 0x00092F0C
	public void method_3()
	{
		if (this.int_1 < GClass3.list_0.Count)
		{
			GClass3.list_0[this.int_1].bool_0 = !GClass3.list_0[this.int_1].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x06000513 RID: 1299 RVA: 0x00094D64 File Offset: 0x00092F64
	private void GClass67_Resize(object sender, EventArgs e)
	{
		this.label1.Visible = true;
		this.int_0 = this.label1.Height;
		this.label1.Visible = false;
		int num = base.Height / this.int_0;
		float width = (float)(this.tableLayoutPanel.Width - 40) * 0.65f;
		float num2 = (float)(this.tableLayoutPanel.Width - 40) * 0.35f;
		this.tableLayoutPanel.ColumnStyles[0].Width = 40f;
		this.tableLayoutPanel.ColumnStyles[1].Width = width;
		this.tableLayoutPanel.ColumnStyles[2].Width = width;
		if (this.tableLayoutPanel.RowCount < num)
		{
			int rowCount = this.tableLayoutPanel.RowCount;
			this.tableLayoutPanel.RowCount = num;
			for (int i = rowCount - 1; i < num; i++)
			{
				this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, (float)(this.int_0 - 1)));
				this.list_0.Add(new GClass54());
				this.list_0[i].Dock = DockStyle.Fill;
				this.list_0[i].CheckAlign = ContentAlignment.MiddleCenter;
				this.list_0[i].Margin = new Padding(0);
				this.list_0[i].method_1(i);
				this.list_0[i].MouseDoubleClick += this.method_7;
				this.list_0[i].MouseClick += this.method_6;
				this.tableLayoutPanel.Controls.Add(this.list_0[i]);
				this.list_1.Add(new GClass1());
				this.list_1[i].Dock = DockStyle.Fill;
				this.list_1[i].ForeColor = Color.Navy;
				this.list_1[i].TextAlign = ContentAlignment.MiddleLeft;
				this.list_1[i].Margin = new Padding(0);
				this.list_1[i].method_1(i);
				this.list_1[i].MouseDoubleClick += this.method_5;
				this.list_1[i].MouseClick += this.method_4;
				this.tableLayoutPanel.Controls.Add(this.list_1[i]);
				this.list_2.Add(new GClass1());
				this.list_2[i].Dock = DockStyle.Fill;
				this.list_2[i].ForeColor = Color.Navy;
				this.list_2[i].TextAlign = ContentAlignment.MiddleLeft;
				this.list_2[i].Margin = new Padding(0);
				this.list_2[i].method_1(i);
				this.list_2[i].MouseDoubleClick += this.method_5;
				this.list_2[i].MouseClick += this.method_4;
				this.tableLayoutPanel.Controls.Add(this.list_2[i]);
			}
		}
		if (sender == null)
		{
			foreach (object obj in ((IEnumerable)this.tableLayoutPanel.RowStyles))
			{
				RowStyle rowStyle = (RowStyle)obj;
				rowStyle.Height = (float)(this.int_0 - 1);
			}
		}
		int num3 = GClass3.list_0.Count - this.tableLayoutPanel.RowCount + 1;
		if (num3 > 0)
		{
			this.vScrollBar.Enabled = true;
			this.vScrollBar.Maximum = GClass3.list_0.Count;
			this.vScrollBar.LargeChange = this.tableLayoutPanel.RowCount;
		}
		else
		{
			this.vScrollBar.Enabled = false;
			this.vScrollBar.Value = 0;
			this.vScrollBar.Maximum = 0;
		}
		base.Invalidate();
	}

	// Token: 0x06000514 RID: 1300 RVA: 0x00003372 File Offset: 0x00001572
	private void vScrollBar_ValueChanged(object sender, EventArgs e)
	{
		base.Invalidate();
	}

	// Token: 0x06000515 RID: 1301 RVA: 0x000951C0 File Offset: 0x000933C0
	private void tableLayoutPanel_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.X > (int)this.tableLayoutPanel.ColumnStyles[0].Width - 10 && e.X < (int)this.tableLayoutPanel.ColumnStyles[0].Width + 10)
		{
			Cursor.Current = Cursors.VSplit;
			this.int_3 = 0;
			this.int_2 = e.X;
		}
		else if (e.X > (int)this.tableLayoutPanel.ColumnStyles[0].Width + (int)this.tableLayoutPanel.ColumnStyles[1].Width - 10 && e.X < (int)this.tableLayoutPanel.ColumnStyles[0].Width + (int)this.tableLayoutPanel.ColumnStyles[1].Width + 10)
		{
			Cursor.Current = Cursors.VSplit;
			this.int_3 = 1;
			this.int_2 = e.X;
		}
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x00003987 File Offset: 0x00001B87
	private void tableLayoutPanel_MouseUp(object sender, MouseEventArgs e)
	{
		if (this.int_2 > 0)
		{
			Cursor.Current = Cursors.Default;
			this.int_2 = -1;
		}
	}

	// Token: 0x06000517 RID: 1303 RVA: 0x000952D4 File Offset: 0x000934D4
	private void tableLayoutPanel_MouseMove(object sender, MouseEventArgs e)
	{
		if (this.int_2 > 0 && this.int_3 == 0)
		{
			this.tableLayoutPanel.ColumnStyles[this.int_3].Width = (float)e.X;
		}
		else if (this.int_2 > 0 && this.int_3 == 1)
		{
			this.tableLayoutPanel.ColumnStyles[this.int_3].Width = (float)e.X - this.tableLayoutPanel.ColumnStyles[0].Width;
		}
		else if (e.X > (int)this.tableLayoutPanel.ColumnStyles[0].Width - 10 && e.X < (int)this.tableLayoutPanel.ColumnStyles[0].Width + 10)
		{
			Cursor.Current = Cursors.VSplit;
		}
		else if (e.X > (int)this.tableLayoutPanel.ColumnStyles[0].Width + (int)this.tableLayoutPanel.ColumnStyles[1].Width - 10 && e.X < (int)this.tableLayoutPanel.ColumnStyles[0].Width + (int)this.tableLayoutPanel.ColumnStyles[1].Width + 10)
		{
			Cursor.Current = Cursors.VSplit;
		}
		else
		{
			Cursor.Current = Cursors.Default;
		}
	}

	// Token: 0x06000518 RID: 1304 RVA: 0x00095468 File Offset: 0x00093668
	private void method_4(object sender, MouseEventArgs e)
	{
		int num = ((GClass1)sender).method_0();
		this.int_1 = num + this.vScrollBar.Value;
		base.Invalidate();
	}

	// Token: 0x06000519 RID: 1305 RVA: 0x0009549C File Offset: 0x0009369C
	private void method_5(object sender, MouseEventArgs e)
	{
		int num = ((GClass1)sender).method_0();
		this.int_1 = num + this.vScrollBar.Value;
		if (this.int_1 < GClass3.list_0.Count)
		{
			GClass3.list_0[this.int_1].bool_0 = !GClass3.list_0[this.int_1].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x0600051A RID: 1306 RVA: 0x00095514 File Offset: 0x00093714
	private void method_6(object sender, MouseEventArgs e)
	{
		int num = ((GClass54)sender).method_0();
		this.int_1 = num + this.vScrollBar.Value;
		if (this.int_1 < GClass3.list_0.Count)
		{
			GClass3.list_0[this.int_1].bool_0 = !GClass3.list_0[this.int_1].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x00095514 File Offset: 0x00093714
	private void method_7(object sender, MouseEventArgs e)
	{
		int num = ((GClass54)sender).method_0();
		this.int_1 = num + this.vScrollBar.Value;
		if (this.int_1 < GClass3.list_0.Count)
		{
			GClass3.list_0[this.int_1].bool_0 = !GClass3.list_0[this.int_1].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x04000665 RID: 1637
	private VScrollBar vScrollBar;

	// Token: 0x04000666 RID: 1638
	private GClass68 tableLayoutPanel;

	// Token: 0x04000667 RID: 1639
	private Label label1;

	// Token: 0x04000668 RID: 1640
	private int int_0 = 0;

	// Token: 0x04000669 RID: 1641
	private int int_1 = -1;

	// Token: 0x0400066A RID: 1642
	private int int_2 = -1;

	// Token: 0x0400066B RID: 1643
	private int int_3 = 0;

	// Token: 0x0400066C RID: 1644
	private List<GClass54> list_0 = new List<GClass54>();

	// Token: 0x0400066D RID: 1645
	private List<GClass1> list_1 = new List<GClass1>();

	// Token: 0x0400066E RID: 1646
	private List<GClass1> list_2 = new List<GClass1>();

	// Token: 0x0400066F RID: 1647
	private Color color_0 = Color.FromArgb(255, 255, 128);

	// Token: 0x04000670 RID: 1648
	private Color color_1 = Color.White;

	// Token: 0x04000671 RID: 1649
	private Color color_2 = Color.Red;

	// Token: 0x04000672 RID: 1650
	private Color color_3 = Color.Navy;
}
