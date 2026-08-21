using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x020000BF RID: 191
public class GClass119 : Panel
{
	// Token: 0x0600064C RID: 1612 RVA: 0x000E1114 File Offset: 0x000DF314
	public GClass119()
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
			this.list_0.Add(new GClass110());
			this.list_0[i].Dock = DockStyle.Fill;
			this.list_0[i].CheckAlign = ContentAlignment.MiddleCenter;
			this.list_0[i].Margin = new Padding(0);
			this.list_0[i].method_1(i);
			this.list_0[i].MouseDoubleClick += this.method_7;
			this.list_0[i].MouseClick += this.method_6;
			this.tableLayoutPanel.Controls.Add(this.list_0[i]);
			this.list_1.Add(new GClass112());
			this.list_1[i].Dock = DockStyle.Fill;
			this.list_1[i].ForeColor = Color.Navy;
			this.list_1[i].TextAlign = ContentAlignment.MiddleLeft;
			this.list_1[i].Margin = new Padding(0);
			this.list_1[i].method_1(i);
			this.list_1[i].MouseDoubleClick += this.method_5;
			this.list_1[i].MouseClick += this.method_4;
			this.tableLayoutPanel.Controls.Add(this.list_1[i]);
			this.list_2.Add(new GClass112());
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

	// Token: 0x0600064D RID: 1613 RVA: 0x000E151C File Offset: 0x000DF71C
	private void GClass119_Paint(object sender, PaintEventArgs e)
	{
		List<GClass104> list = GClass126.list_0;
		if (list.Count == 0)
		{
			return;
		}
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
				this.list_1[i].Text = "";
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
				this.list_2[i].Text = "";
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

	// Token: 0x0600064E RID: 1614 RVA: 0x000E1810 File Offset: 0x000DFA10
	private void method_0()
	{
		this.vScrollBar = new VScrollBar();
		this.tableLayoutPanel = new GClass114();
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
		this.label1.Tag = "";
		this.label1.Text = "Test Message";
		this.label1.Padding = new Padding(0, 2, 0, 2);
		base.BorderStyle = BorderStyle.FixedSingle;
		base.Controls.Add(this.tableLayoutPanel);
		base.Controls.Add(this.vScrollBar);
		base.Controls.Add(this.label1);
		base.Paint += this.GClass119_Paint;
		base.Resize += this.GClass119_Resize;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x1700001F RID: 31
	// (get) Token: 0x0600064F RID: 1615 RVA: 0x000045A2 File Offset: 0x000027A2
	// (set) Token: 0x06000650 RID: 1616 RVA: 0x000045AA File Offset: 0x000027AA
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
			this.GClass119_Resize(null, null);
		}
	}

	// Token: 0x06000651 RID: 1617 RVA: 0x000E1A00 File Offset: 0x000DFC00
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
		if (this.int_1 >= GClass126.list_0.Count)
		{
			this.int_1 = GClass126.list_0.Count - 1;
		}
		if (this.int_1 >= this.tableLayoutPanel.RowCount + this.vScrollBar.Value)
		{
			this.vScrollBar.Value = this.int_1 - this.tableLayoutPanel.RowCount + 1;
		}
		base.Invalidate();
	}

	// Token: 0x06000652 RID: 1618 RVA: 0x000E1AA0 File Offset: 0x000DFCA0
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

	// Token: 0x06000653 RID: 1619 RVA: 0x000E1B14 File Offset: 0x000DFD14
	public void method_3()
	{
		if (this.int_1 < GClass126.list_0.Count)
		{
			GClass126.list_0[this.int_1].bool_0 = !GClass126.list_0[this.int_1].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x06000654 RID: 1620 RVA: 0x000E1B68 File Offset: 0x000DFD68
	private void GClass119_Resize(object sender, EventArgs e)
	{
		this.label1.Visible = true;
		this.int_0 = this.label1.Height;
		this.label1.Visible = false;
		int num = base.Height / this.int_0;
		float width = (float)(this.tableLayoutPanel.Width - 40) * 0.65f;
		int width2 = this.tableLayoutPanel.Width;
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
				this.list_0.Add(new GClass110());
				this.list_0[i].Dock = DockStyle.Fill;
				this.list_0[i].CheckAlign = ContentAlignment.MiddleCenter;
				this.list_0[i].Margin = new Padding(0);
				this.list_0[i].method_1(i);
				this.list_0[i].MouseDoubleClick += this.method_7;
				this.list_0[i].MouseClick += this.method_6;
				this.tableLayoutPanel.Controls.Add(this.list_0[i]);
				this.list_1.Add(new GClass112());
				this.list_1[i].Dock = DockStyle.Fill;
				this.list_1[i].ForeColor = Color.Navy;
				this.list_1[i].TextAlign = ContentAlignment.MiddleLeft;
				this.list_1[i].Margin = new Padding(0);
				this.list_1[i].method_1(i);
				this.list_1[i].MouseDoubleClick += this.method_5;
				this.list_1[i].MouseClick += this.method_4;
				this.tableLayoutPanel.Controls.Add(this.list_1[i]);
				this.list_2.Add(new GClass112());
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
				((RowStyle)obj).Height = (float)(this.int_0 - 1);
			}
		}
		if (GClass126.list_0.Count - this.tableLayoutPanel.RowCount + 1 > 0)
		{
			this.vScrollBar.Enabled = true;
			this.vScrollBar.Maximum = GClass126.list_0.Count;
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

	// Token: 0x06000655 RID: 1621 RVA: 0x000045BB File Offset: 0x000027BB
	private void vScrollBar_ValueChanged(object sender, EventArgs e)
	{
		base.Invalidate();
	}

	// Token: 0x06000656 RID: 1622 RVA: 0x000E1F98 File Offset: 0x000E0198
	private void tableLayoutPanel_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.X > (int)this.tableLayoutPanel.ColumnStyles[0].Width - 10 && e.X < (int)this.tableLayoutPanel.ColumnStyles[0].Width + 10)
		{
			Cursor.Current = Cursors.VSplit;
			this.int_3 = 0;
			this.int_2 = e.X;
			return;
		}
		if (e.X > (int)this.tableLayoutPanel.ColumnStyles[0].Width + (int)this.tableLayoutPanel.ColumnStyles[1].Width - 10 && e.X < (int)this.tableLayoutPanel.ColumnStyles[0].Width + (int)this.tableLayoutPanel.ColumnStyles[1].Width + 10)
		{
			Cursor.Current = Cursors.VSplit;
			this.int_3 = 1;
			this.int_2 = e.X;
		}
	}

	// Token: 0x06000657 RID: 1623 RVA: 0x000045C3 File Offset: 0x000027C3
	private void tableLayoutPanel_MouseUp(object sender, MouseEventArgs e)
	{
		if (this.int_2 > 0)
		{
			Cursor.Current = Cursors.Default;
			this.int_2 = -1;
		}
	}

	// Token: 0x06000658 RID: 1624 RVA: 0x000E2098 File Offset: 0x000E0298
	private void tableLayoutPanel_MouseMove(object sender, MouseEventArgs e)
	{
		if (this.int_2 > 0 && this.int_3 == 0)
		{
			this.tableLayoutPanel.ColumnStyles[this.int_3].Width = (float)e.X;
			return;
		}
		if (this.int_2 > 0 && this.int_3 == 1)
		{
			this.tableLayoutPanel.ColumnStyles[this.int_3].Width = (float)e.X - this.tableLayoutPanel.ColumnStyles[0].Width;
			return;
		}
		if (e.X > (int)this.tableLayoutPanel.ColumnStyles[0].Width - 10 && e.X < (int)this.tableLayoutPanel.ColumnStyles[0].Width + 10)
		{
			Cursor.Current = Cursors.VSplit;
			return;
		}
		if (e.X > (int)this.tableLayoutPanel.ColumnStyles[0].Width + (int)this.tableLayoutPanel.ColumnStyles[1].Width - 10 && e.X < (int)this.tableLayoutPanel.ColumnStyles[0].Width + (int)this.tableLayoutPanel.ColumnStyles[1].Width + 10)
		{
			Cursor.Current = Cursors.VSplit;
			return;
		}
		Cursor.Current = Cursors.Default;
	}

	// Token: 0x06000659 RID: 1625 RVA: 0x000E2200 File Offset: 0x000E0400
	private void method_4(object sender, MouseEventArgs e)
	{
		int num = ((GClass112)sender).method_0();
		this.int_1 = num + this.vScrollBar.Value;
		base.Invalidate();
	}

	// Token: 0x0600065A RID: 1626 RVA: 0x000E2234 File Offset: 0x000E0434
	private void method_5(object sender, MouseEventArgs e)
	{
		int num = ((GClass112)sender).method_0();
		this.int_1 = num + this.vScrollBar.Value;
		if (this.int_1 < GClass126.list_0.Count)
		{
			GClass126.list_0[this.int_1].bool_0 = !GClass126.list_0[this.int_1].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x0600065B RID: 1627 RVA: 0x000E22A8 File Offset: 0x000E04A8
	private void method_6(object sender, MouseEventArgs e)
	{
		int num = ((GClass110)sender).method_0();
		this.int_1 = num + this.vScrollBar.Value;
		if (this.int_1 < GClass126.list_0.Count)
		{
			GClass126.list_0[this.int_1].bool_0 = !GClass126.list_0[this.int_1].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x0600065C RID: 1628 RVA: 0x000E22A8 File Offset: 0x000E04A8
	private void method_7(object sender, MouseEventArgs e)
	{
		int num = ((GClass110)sender).method_0();
		this.int_1 = num + this.vScrollBar.Value;
		if (this.int_1 < GClass126.list_0.Count)
		{
			GClass126.list_0[this.int_1].bool_0 = !GClass126.list_0[this.int_1].bool_0;
		}
		base.Invalidate();
	}

	// Token: 0x04000596 RID: 1430
	private VScrollBar vScrollBar;

	// Token: 0x04000597 RID: 1431
	private GClass114 tableLayoutPanel;

	// Token: 0x04000598 RID: 1432
	private Label label1;

	// Token: 0x04000599 RID: 1433
	private int int_0;

	// Token: 0x0400059A RID: 1434
	private int int_1 = -1;

	// Token: 0x0400059B RID: 1435
	private int int_2 = -1;

	// Token: 0x0400059C RID: 1436
	private int int_3;

	// Token: 0x0400059D RID: 1437
	private List<GClass110> list_0 = new List<GClass110>();

	// Token: 0x0400059E RID: 1438
	private List<GClass112> list_1 = new List<GClass112>();

	// Token: 0x0400059F RID: 1439
	private List<GClass112> list_2 = new List<GClass112>();

	// Token: 0x040005A0 RID: 1440
	private Color color_0 = Color.FromArgb(255, 255, 128);

	// Token: 0x040005A1 RID: 1441
	private Color color_1 = Color.White;

	// Token: 0x040005A2 RID: 1442
	private Color color_2 = Color.Red;

	// Token: 0x040005A3 RID: 1443
	private Color color_3 = Color.Navy;
}
