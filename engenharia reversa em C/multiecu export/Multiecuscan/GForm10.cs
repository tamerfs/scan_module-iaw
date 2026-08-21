using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Multiecuscan;

// Token: 0x020000AB RID: 171
public partial class GForm10 : Form
{
	// Token: 0x0600058F RID: 1423 RVA: 0x000CC840 File Offset: 0x000CAA40
	public GForm10(string string_3, string string_4, string string_5, bool bool_8, int int_2, List<TableDataRowP> list_0)
	{
		this.method_10();
		GClass126.bool_24 = false;
		GClass126.bool_25 = false;
		this.string_0 = string_3;
		this.string_1 = string_4;
		this.string_2 = string_5;
		this.bool_6 = string_4.Equals(GClass121.smethod_6("1052"));
		this.label_1.Font = new Font(GClass125.smethod_28().FontFamily, this.label_1.Font.Size, this.label_1.Font.Style);
		this.label_0.Font = GClass125.smethod_28();
		this.label_2.Font = GClass125.smethod_28();
		this.label_1.Text = string_3;
		this.label_0.Text = string_4 + (this.bool_6 ? " ..." : "");
		this.label_2.Text = string_5;
		this.bool_3 = bool_8;
		this.int_1 = int_2;
		this.float_0 = this.label_1.Font.Size;
		this.float_1 = this.label_0.Font.Size;
		this.float_2 = this.label_2.Font.Size;
		this.button_1.Font = GClass125.smethod_28();
		this.button_2.Font = GClass125.smethod_28();
		this.button_0.Font = GClass125.smethod_28();
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
		this.dataGridView_0.DataSource = list_0;
	}

	// Token: 0x06000590 RID: 1424 RVA: 0x000CCBDC File Offset: 0x000CADDC
	private void GForm10_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.bool_0 = true;
			GClass126.bool_25 = true;
			return;
		}
		if (e.KeyCode == Keys.Y && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.bool_1 = true;
			this.bool_2 = false;
			GClass126.bool_24 = true;
			if (this.bool_3)
			{
				base.DialogResult = DialogResult.OK;
				base.Close();
				return;
			}
		}
		else if (e.KeyCode == Keys.N && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.bool_2 = true;
			this.bool_1 = false;
			if (this.bool_3)
			{
				base.DialogResult = DialogResult.OK;
				base.Close();
			}
		}
	}

	// Token: 0x06000591 RID: 1425 RVA: 0x000040FC File Offset: 0x000022FC
	public bool method_0()
	{
		return this.bool_0;
	}

	// Token: 0x06000592 RID: 1426 RVA: 0x00004104 File Offset: 0x00002304
	public bool method_1()
	{
		return this.bool_1;
	}

	// Token: 0x06000593 RID: 1427 RVA: 0x0000410C File Offset: 0x0000230C
	public bool method_2()
	{
		return this.bool_2;
	}

	// Token: 0x06000594 RID: 1428 RVA: 0x00004114 File Offset: 0x00002314
	public void method_3(string string_3)
	{
		this.string_0 = string_3;
		this.bool_4 = true;
	}

	// Token: 0x06000595 RID: 1429 RVA: 0x00004124 File Offset: 0x00002324
	public string method_4()
	{
		return this.string_0;
	}

	// Token: 0x06000596 RID: 1430 RVA: 0x0000412C File Offset: 0x0000232C
	public void method_5(string string_3)
	{
		this.string_1 = string_3;
		this.bool_5 = true;
	}

	// Token: 0x06000597 RID: 1431 RVA: 0x0000413C File Offset: 0x0000233C
	public string method_6()
	{
		return this.string_1;
	}

	// Token: 0x06000598 RID: 1432 RVA: 0x00004144 File Offset: 0x00002344
	public void method_7(string string_3)
	{
		this.string_2 = string_3;
		this.bool_7 = true;
	}

	// Token: 0x06000599 RID: 1433 RVA: 0x00004154 File Offset: 0x00002354
	public void method_8(string string_3, string string_4, string string_5, bool bool_8, int int_2)
	{
		base.Invoke(new GForm10.Delegate13(this.method_9), new object[]
		{
			string_3,
			string_4,
			string_5,
			bool_8,
			int_2
		});
	}

	// Token: 0x0600059A RID: 1434 RVA: 0x000CCCA8 File Offset: 0x000CAEA8
	public void method_9(string string_3, string string_4, string string_5, bool bool_8, int int_2)
	{
		this.string_0 = string_3;
		this.string_1 = string_4;
		this.string_2 = string_5;
		this.bool_6 = string_4.Equals(GClass121.smethod_6("1052"));
		this.label_1.Text = string_3;
		this.label_0.Text = string_4 + (this.bool_6 ? " ..." : "");
		this.label_2.Text = string_5;
		this.bool_3 = bool_8;
		this.int_0 = 0;
		this.int_1 = int_2;
		this.bool_0 = false;
		this.bool_1 = false;
		this.bool_2 = false;
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

	// Token: 0x0600059B RID: 1435 RVA: 0x000CCF78 File Offset: 0x000CB178
	private void timer_0_Tick(object sender, EventArgs e)
	{
		this.int_0 += this.timer_0.Interval;
		if (this.int_1 > 0 && (this.int_0 > this.int_1 || this.bool_0))
		{
			base.Close();
		}
		if (!base.Visible)
		{
			return;
		}
		if (this.bool_6)
		{
			Label label = this.label_0;
			label.Text += ".";
			if (this.label_0.Text.Length > this.string_1.Length + 6)
			{
				this.label_0.Text = this.string_1 + " .";
			}
		}
		this.dataGridView_0.Invalidate();
		if (this.bool_4)
		{
			this.label_1.Text = this.string_0;
			this.label_1.Location = new Point((this.panel_0.Width - this.label_1.Width) / 2, this.label_1.Location.Y);
		}
		if (this.bool_5)
		{
			this.label_0.Text = this.string_1;
			this.label_0.Location = new Point((this.panel_0.Width - this.label_0.Width) / 2, this.label_0.Location.Y);
		}
		if (this.bool_7)
		{
			this.label_2.Text = this.string_2;
			this.label_2.Location = new Point((this.panel_0.Width - this.label_2.Width) / 2, this.label_2.Location.Y);
		}
	}

	// Token: 0x0600059C RID: 1436 RVA: 0x0000418F File Offset: 0x0000238F
	private void button_1_Click(object sender, EventArgs e)
	{
		this.bool_2 = true;
		this.bool_1 = false;
		if (this.bool_3)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
	}

	// Token: 0x0600059D RID: 1437 RVA: 0x000041B4 File Offset: 0x000023B4
	private void button_2_Click(object sender, EventArgs e)
	{
		this.bool_0 = true;
		GClass126.bool_25 = true;
	}

	// Token: 0x0600059E RID: 1438 RVA: 0x000041C3 File Offset: 0x000023C3
	private void button_0_Click(object sender, EventArgs e)
	{
		this.bool_1 = true;
		this.bool_2 = false;
		GClass126.bool_24 = true;
		if (this.bool_3)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
	}

	// Token: 0x0600059F RID: 1439 RVA: 0x000041EE File Offset: 0x000023EE
	private void GForm10_FormClosed(object sender, FormClosedEventArgs e)
	{
		this.timer_0.Stop();
	}

	// Token: 0x060005A1 RID: 1441 RVA: 0x000CD134 File Offset: 0x000CB334
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
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.panel_0.SuspendLayout();
		this.tableLayoutPanel_0.SuspendLayout();
		this.panel_1.SuspendLayout();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		base.SuspendLayout();
		this.panel_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_0.BackColor = Color.Black;
		this.panel_0.Controls.Add(this.label_2);
		this.panel_0.Controls.Add(this.label_0);
		this.panel_0.Controls.Add(this.label_1);
		this.panel_0.ForeColor = Color.Red;
		this.panel_0.Location = new Point(14, 15);
		this.panel_0.Margin = new Padding(3, 4, 3, 4);
		this.panel_0.Name = GClass107.smethod_3(134699);
		this.panel_0.Size = new Size(924, 200);
		this.panel_0.TabIndex = 0;
		this.label_2.AutoSize = true;
		this.label_2.Font = new Font(GClass107.smethod_3(134720), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_2.ForeColor = Color.White;
		this.label_2.Location = new Point(86, 141);
		this.label_2.Name = GClass107.smethod_3(134760);
		this.label_2.Size = new Size(258, 38);
		this.label_2.TabIndex = 2;
		this.label_2.Text = GClass107.smethod_3(134795);
		this.label_0.AutoSize = true;
		this.label_0.Font = new Font(GClass107.smethod_3(134815), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_0.ForeColor = Color.White;
		this.label_0.Location = new Point(86, 95);
		this.label_0.Name = GClass107.smethod_3(134855);
		this.label_0.Size = new Size(258, 38);
		this.label_0.TabIndex = 1;
		this.label_0.Text = GClass107.smethod_3(134871);
		this.label_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.label_1.AutoSize = true;
		this.label_1.BackColor = Color.Transparent;
		this.label_1.Font = new Font(GClass107.smethod_3(134907), 28.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_1.Location = new Point(39, 18);
		this.label_1.Name = GClass107.smethod_3(134921);
		this.label_1.Size = new Size(452, 66);
		this.label_1.TabIndex = 0;
		this.label_1.Text = GClass107.smethod_3(134941);
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
		this.tableLayoutPanel_0.Name = GClass107.smethod_3(134982);
		this.tableLayoutPanel_0.RowCount = 1;
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.Size = new Size(951, 60);
		this.tableLayoutPanel_0.TabIndex = 7;
		this.button_2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.button_2.AutoSize = true;
		this.button_2.BackColor = Color.WhiteSmoke;
		this.button_2.Font = new Font(GClass107.smethod_3(135005), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_2.ForeColor = Color.Black;
		this.button_2.ImageKey = GClass107.smethod_3(135036);
		this.button_2.Location = new Point(320, 4);
		this.button_2.Margin = new Padding(3, 4, 3, 4);
		this.button_2.Name = GClass107.smethod_3(135083);
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
		this.button_1.Font = new Font(GClass107.smethod_3(135131), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_1.ForeColor = Color.Red;
		this.button_1.ImageKey = GClass107.smethod_3(135153);
		this.button_1.Location = new Point(3, 4);
		this.button_1.Margin = new Padding(3, 4, 3, 4);
		this.button_1.Name = GClass107.smethod_3(135193);
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
		this.button_0.Font = new Font(GClass107.smethod_3(135234), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_0.ForeColor = Color.Green;
		this.button_0.ImageKey = GClass107.smethod_3(135265);
		this.button_0.Location = new Point(637, 4);
		this.button_0.Margin = new Padding(3, 4, 3, 4);
		this.button_0.Name = GClass107.smethod_3(135300);
		this.button_0.Size = new Size(311, 52);
		this.button_0.TabIndex = 5;
		this.button_0.Tag = "";
		this.button_0.Text = "Y";
		this.button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_0.UseVisualStyleBackColor = false;
		this.button_0.Click += this.button_0_Click;
		this.timer_0.Enabled = true;
		this.timer_0.Interval = 800;
		this.timer_0.Tick += this.timer_0_Tick;
		this.panel_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_1.BackColor = Color.White;
		this.panel_1.Controls.Add(this.dataGridView_0);
		this.panel_1.Controls.Add(this.tableLayoutPanel_0);
		this.panel_1.Location = new Point(0, 230);
		this.panel_1.Margin = new Padding(3, 4, 3, 4);
		this.panel_1.Name = GClass107.smethod_3(135335);
		this.panel_1.Size = new Size(951, 404);
		this.panel_1.TabIndex = 1;
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.AllowUserToResizeRows = false;
		this.dataGridView_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_0.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
		this.dataGridView_0.BackgroundColor = Color.White;
		this.dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.ColumnHeadersVisible = false;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewCheckBoxColumn_0,
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1
		});
		this.dataGridView_0.Location = new Point(6, 78);
		this.dataGridView_0.Margin = new Padding(3, 4, 3, 4);
		this.dataGridView_0.MultiSelect = false;
		this.dataGridView_0.Name = GClass107.smethod_3(135366);
		this.dataGridView_0.ReadOnly = true;
		this.dataGridView_0.RowHeadersVisible = false;
		this.dataGridView_0.RowTemplate.DefaultCellStyle.BackColor = Color.White;
		this.dataGridView_0.RowTemplate.DefaultCellStyle.Font = new Font(GClass107.smethod_3(135377), 10.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.dataGridView_0.RowTemplate.DefaultCellStyle.ForeColor = Color.Navy;
		this.dataGridView_0.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 128);
		this.dataGridView_0.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Navy;
		this.dataGridView_0.RowTemplate.Height = 24;
		this.dataGridView_0.ScrollBars = ScrollBars.Vertical;
		this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_0.ShowEditingIcon = false;
		this.dataGridView_0.Size = new Size(939, 320);
		this.dataGridView_0.StandardTab = true;
		this.dataGridView_0.TabIndex = 8;
		this.dataGridView_0.Tag = "3";
		this.dataGridViewCheckBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		this.dataGridViewCheckBoxColumn_0.DataPropertyName = GClass107.smethod_3(135383);
		this.dataGridViewCheckBoxColumn_0.HeaderText = GClass107.smethod_3(135405);
		this.dataGridViewCheckBoxColumn_0.MinimumWidth = 40;
		this.dataGridViewCheckBoxColumn_0.Name = GClass107.smethod_3(135435);
		this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
		this.dataGridViewCheckBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewCheckBoxColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewCheckBoxColumn_0.Visible = false;
		this.dataGridViewCheckBoxColumn_0.Width = 40;
		this.dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = GClass107.smethod_3(135436);
		this.dataGridViewTextBoxColumn_0.FillWeight = 70f;
		this.dataGridViewTextBoxColumn_0.HeaderText = GClass107.smethod_3(135444);
		this.dataGridViewTextBoxColumn_0.Name = GClass107.smethod_3(135474);
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = GClass107.smethod_3(135510);
		this.dataGridViewTextBoxColumn_1.FillWeight = 30f;
		this.dataGridViewTextBoxColumn_1.HeaderText = GClass107.smethod_3(135527);
		this.dataGridViewTextBoxColumn_1.Name = GClass107.smethod_3(135536);
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.AutoSize = true;
		this.BackColor = Color.Red;
		base.ClientSize = new Size(951, 632);
		base.ControlBox = false;
		base.Controls.Add(this.panel_1);
		base.Controls.Add(this.panel_0);
		base.FormBorderStyle = FormBorderStyle.None;
		base.KeyPreview = true;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = GClass107.smethod_3(135537);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		base.FormClosed += this.GForm10_FormClosed;
		base.KeyUp += this.GForm10_KeyUp;
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		this.tableLayoutPanel_0.ResumeLayout(false);
		this.tableLayoutPanel_0.PerformLayout();
		this.panel_1.ResumeLayout(false);
		((ISupportInitialize)this.dataGridView_0).EndInit();
		base.ResumeLayout(false);
	}

	// Token: 0x04000470 RID: 1136
	private bool bool_0;

	// Token: 0x04000471 RID: 1137
	private bool bool_1;

	// Token: 0x04000472 RID: 1138
	private bool bool_2;

	// Token: 0x04000473 RID: 1139
	private bool bool_3;

	// Token: 0x04000474 RID: 1140
	private string string_0;

	// Token: 0x04000475 RID: 1141
	private bool bool_4;

	// Token: 0x04000476 RID: 1142
	private string string_1;

	// Token: 0x04000477 RID: 1143
	private bool bool_5;

	// Token: 0x04000478 RID: 1144
	private bool bool_6;

	// Token: 0x04000479 RID: 1145
	private string string_2;

	// Token: 0x0400047A RID: 1146
	private bool bool_7;

	// Token: 0x0400047B RID: 1147
	private int int_0;

	// Token: 0x0400047C RID: 1148
	private int int_1;

	// Token: 0x0400047D RID: 1149
	private float float_0;

	// Token: 0x0400047E RID: 1150
	private float float_1;

	// Token: 0x0400047F RID: 1151
	private float float_2;

	// Token: 0x04000481 RID: 1153
	private Panel panel_0;

	// Token: 0x04000482 RID: 1154
	private Label label_0;

	// Token: 0x04000483 RID: 1155
	private Label label_1;

	// Token: 0x04000484 RID: 1156
	private Label label_2;

	// Token: 0x04000485 RID: 1157
	private Timer timer_0;

	// Token: 0x04000486 RID: 1158
	private Button button_0;

	// Token: 0x04000487 RID: 1159
	private Button button_1;

	// Token: 0x04000488 RID: 1160
	private TableLayoutPanel tableLayoutPanel_0;

	// Token: 0x04000489 RID: 1161
	private Button button_2;

	// Token: 0x0400048A RID: 1162
	private Panel panel_1;

	// Token: 0x0400048B RID: 1163
	private DataGridView dataGridView_0;

	// Token: 0x0400048C RID: 1164
	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	// Token: 0x0400048D RID: 1165
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	// Token: 0x0400048E RID: 1166
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	// Token: 0x020000AC RID: 172
	// (Invoke) Token: 0x060005A3 RID: 1443
	private delegate void Delegate13(string message1, string message2, string message3, bool closeOnKeyPress, int autoCloseTimeMS);
}
