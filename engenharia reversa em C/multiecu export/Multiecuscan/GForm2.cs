using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000095 RID: 149
public partial class GForm2 : Form
{
	// Token: 0x06000490 RID: 1168 RVA: 0x000A4714 File Offset: 0x000A2914
	public GForm2(string string_1, string string_2, string[] string_3, int int_1)
	{
		this.method_2();
		this.label_0.Text = string_1;
		this.string_0 = string_3;
		this.int_0 = int_1;
		this.button_1.Enabled = true;
		this.label_0.Font = GClass125.smethod_28();
		this.button_0.Font = GClass125.smethod_28();
		this.button_1.Font = GClass125.smethod_28();
		this.comboBox_0 = new ComboBox[]
		{
			this.comboBox_1,
			this.comboBox_2,
			this.comboBox_3,
			this.comboBox_4,
			this.comboBox_5,
			this.comboBox_6,
			this.comboBox_7,
			this.comboBox_8,
			this.comboBox_9,
			this.comboBox_10,
			this.comboBox_11,
			this.comboBox_12,
			this.comboBox_13,
			this.comboBox_14,
			this.comboBox_15,
			this.comboBox_16,
			this.comboBox_17
		};
		for (int i = 0; i < this.comboBox_0.Length; i++)
		{
			this.comboBox_0[i].Items.Clear();
			if (i < int_1)
			{
				for (int j = 0; j < string_3.Length; j++)
				{
					this.comboBox_0[i].Items.Add(string_3[j]);
				}
				if (int_1 == 1)
				{
					this.comboBox_0[i].SelectedItem = string_2;
				}
				if (string_2.Length > i)
				{
					this.comboBox_0[i].SelectedItem = string_2.Substring(i, 1);
				}
				else
				{
					this.comboBox_0[i].SelectedIndex = 0;
				}
			}
			else
			{
				this.comboBox_0[i].Visible = false;
			}
		}
		if (int_1 == 1)
		{
			this.comboBox_0[0].Width = this.comboBox_16.Location.X + this.comboBox_16.Width - this.comboBox_1.Location.X;
		}
		this.comboBox_0[0].Focus();
	}

	// Token: 0x06000491 RID: 1169 RVA: 0x00002F0A File Offset: 0x0000110A
	private void button_1_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x06000492 RID: 1170 RVA: 0x00002F0A File Offset: 0x0000110A
	private void method_0(object sender, EventArgs e)
	{
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x000A4944 File Offset: 0x000A2B44
	public int[] method_1()
	{
		ComboBox[] array = new ComboBox[]
		{
			this.comboBox_1,
			this.comboBox_2,
			this.comboBox_3,
			this.comboBox_4,
			this.comboBox_5,
			this.comboBox_6,
			this.comboBox_7,
			this.comboBox_8,
			this.comboBox_9,
			this.comboBox_10,
			this.comboBox_11,
			this.comboBox_12,
			this.comboBox_13,
			this.comboBox_14,
			this.comboBox_15,
			this.comboBox_16,
			this.comboBox_17
		};
		int[] array2 = new int[this.int_0];
		for (int i = 0; i < this.int_0; i++)
		{
			array2[i] = array[i].SelectedIndex;
		}
		return array2;
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x000A4A24 File Offset: 0x000A2C24
	private void comboBox_17_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (sender == null)
		{
			return;
		}
		ComboBox comboBox = (ComboBox)sender;
		if (!comboBox.Visible)
		{
			return;
		}
		int i = 0;
		while (i < this.comboBox_0.Length - 1)
		{
			if (!(this.comboBox_0[i].Name == comboBox.Name))
			{
				i++;
			}
			else
			{
				if (this.comboBox_0[i + 1].Visible)
				{
					this.comboBox_0[i + 1].Focus();
					return;
				}
				return;
			}
		}
	}

	// Token: 0x06000496 RID: 1174 RVA: 0x000A4A98 File Offset: 0x000A2C98
	private void method_2()
	{
		this.panel_0 = new Panel();
		this.tableLayoutPanel_0 = new TableLayoutPanel();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.panel_1 = new Panel();
		this.comboBox_1 = new ComboBox();
		this.comboBox_2 = new ComboBox();
		this.comboBox_3 = new ComboBox();
		this.comboBox_4 = new ComboBox();
		this.comboBox_5 = new ComboBox();
		this.comboBox_6 = new ComboBox();
		this.comboBox_7 = new ComboBox();
		this.comboBox_8 = new ComboBox();
		this.comboBox_9 = new ComboBox();
		this.comboBox_10 = new ComboBox();
		this.comboBox_11 = new ComboBox();
		this.comboBox_12 = new ComboBox();
		this.comboBox_13 = new ComboBox();
		this.comboBox_14 = new ComboBox();
		this.comboBox_15 = new ComboBox();
		this.comboBox_16 = new ComboBox();
		this.comboBox_17 = new ComboBox();
		this.label_0 = new Label();
		this.panel_0.SuspendLayout();
		this.tableLayoutPanel_0.SuspendLayout();
		this.panel_1.SuspendLayout();
		base.SuspendLayout();
		this.panel_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_0.BackColor = Color.Black;
		this.panel_0.Controls.Add(this.tableLayoutPanel_0);
		this.panel_0.Controls.Add(this.panel_1);
		this.panel_0.Controls.Add(this.label_0);
		this.panel_0.ForeColor = Color.Red;
		this.panel_0.Location = new Point(14, 15);
		this.panel_0.Margin = new Padding(3, 4, 3, 4);
		this.panel_0.Name = GClass107.smethod_3(81155);
		this.panel_0.Size = new Size(955, 242);
		this.panel_0.TabIndex = 1;
		this.tableLayoutPanel_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.tableLayoutPanel_0.ColumnCount = 2;
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 22f));
		this.tableLayoutPanel_0.Controls.Add(this.button_0, 0, 0);
		this.tableLayoutPanel_0.Controls.Add(this.button_1, 1, 0);
		this.tableLayoutPanel_0.Location = new Point(34, 160);
		this.tableLayoutPanel_0.Margin = new Padding(3, 4, 3, 4);
		this.tableLayoutPanel_0.Name = GClass107.smethod_3(81181);
		this.tableLayoutPanel_0.RowCount = 1;
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.Size = new Size(885, 60);
		this.tableLayoutPanel_0.TabIndex = 8;
		this.button_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.button_0.AutoSize = true;
		this.button_0.BackColor = Color.WhiteSmoke;
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Font = new Font(GClass107.smethod_3(81189), 13.8f, FontStyle.Bold);
		this.button_0.ForeColor = Color.Red;
		this.button_0.Location = new Point(3, 4);
		this.button_0.Margin = new Padding(3, 4, 3, 4);
		this.button_0.Name = GClass107.smethod_3(81194);
		this.button_0.Size = new Size(411, 52);
		this.button_0.TabIndex = 2;
		this.button_0.Tag = "8198";
		this.button_0.Text = GClass107.smethod_3(81211);
		this.button_0.UseVisualStyleBackColor = false;
		this.button_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.button_1.AutoSize = true;
		this.button_1.BackColor = Color.WhiteSmoke;
		this.button_1.DialogResult = DialogResult.OK;
		this.button_1.Font = new Font(GClass107.smethod_3(81245), 13.8f, FontStyle.Bold);
		this.button_1.ForeColor = Color.Green;
		this.button_1.Location = new Point(420, 4);
		this.button_1.Margin = new Padding(3, 4, 3, 4);
		this.button_1.Name = GClass107.smethod_3(81284);
		this.button_1.Size = new Size(411, 52);
		this.button_1.TabIndex = 1;
		this.button_1.Tag = "8199";
		this.button_1.Text = "OK";
		this.button_1.UseVisualStyleBackColor = false;
		this.button_1.Click += this.button_1_Click;
		this.panel_1.BorderStyle = BorderStyle.FixedSingle;
		this.panel_1.Controls.Add(this.comboBox_1);
		this.panel_1.Controls.Add(this.comboBox_2);
		this.panel_1.Controls.Add(this.comboBox_3);
		this.panel_1.Controls.Add(this.comboBox_4);
		this.panel_1.Controls.Add(this.comboBox_5);
		this.panel_1.Controls.Add(this.comboBox_6);
		this.panel_1.Controls.Add(this.comboBox_7);
		this.panel_1.Controls.Add(this.comboBox_8);
		this.panel_1.Controls.Add(this.comboBox_9);
		this.panel_1.Controls.Add(this.comboBox_10);
		this.panel_1.Controls.Add(this.comboBox_11);
		this.panel_1.Controls.Add(this.comboBox_12);
		this.panel_1.Controls.Add(this.comboBox_13);
		this.panel_1.Controls.Add(this.comboBox_14);
		this.panel_1.Controls.Add(this.comboBox_15);
		this.panel_1.Controls.Add(this.comboBox_16);
		this.panel_1.Controls.Add(this.comboBox_17);
		this.panel_1.Location = new Point(34, 70);
		this.panel_1.Margin = new Padding(3, 4, 3, 4);
		this.panel_1.Name = GClass107.smethod_3(81307);
		this.panel_1.Size = new Size(883, 60);
		this.panel_1.TabIndex = 0;
		this.comboBox_1.BackColor = Color.White;
		this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_1.FlatStyle = FlatStyle.Flat;
		this.comboBox_1.Font = new Font(GClass107.smethod_3(81332), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_1.ForeColor = Color.Green;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(8, 10);
		this.comboBox_1.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_1.Name = GClass107.smethod_3(81368);
		this.comboBox_1.Size = new Size(50, 37);
		this.comboBox_1.TabIndex = 0;
		this.comboBox_1.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_2.BackColor = Color.White;
		this.comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_2.FlatStyle = FlatStyle.Flat;
		this.comboBox_2.Font = new Font(GClass107.smethod_3(81373), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_2.ForeColor = Color.Green;
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Location = new Point(59, 10);
		this.comboBox_2.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_2.Name = GClass107.smethod_3(81375);
		this.comboBox_2.Size = new Size(50, 37);
		this.comboBox_2.TabIndex = 1;
		this.comboBox_2.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_3.BackColor = Color.White;
		this.comboBox_3.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_3.FlatStyle = FlatStyle.Flat;
		this.comboBox_3.Font = new Font(GClass107.smethod_3(81418), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_3.ForeColor = Color.Green;
		this.comboBox_3.FormattingEnabled = true;
		this.comboBox_3.Location = new Point(110, 10);
		this.comboBox_3.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_3.Name = GClass107.smethod_3(81461);
		this.comboBox_3.Size = new Size(50, 37);
		this.comboBox_3.TabIndex = 2;
		this.comboBox_3.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_4.BackColor = Color.White;
		this.comboBox_4.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_4.FlatStyle = FlatStyle.Flat;
		this.comboBox_4.Font = new Font(GClass107.smethod_3(81466), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_4.ForeColor = Color.Green;
		this.comboBox_4.FormattingEnabled = true;
		this.comboBox_4.Location = new Point(161, 10);
		this.comboBox_4.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_4.Name = GClass107.smethod_3(81490);
		this.comboBox_4.Size = new Size(50, 37);
		this.comboBox_4.TabIndex = 3;
		this.comboBox_4.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_5.BackColor = Color.White;
		this.comboBox_5.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_5.FlatStyle = FlatStyle.Flat;
		this.comboBox_5.Font = new Font(GClass107.smethod_3(81501), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_5.ForeColor = Color.Green;
		this.comboBox_5.FormattingEnabled = true;
		this.comboBox_5.Location = new Point(212, 10);
		this.comboBox_5.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_5.Name = GClass107.smethod_3(81536);
		this.comboBox_5.Size = new Size(50, 37);
		this.comboBox_5.TabIndex = 4;
		this.comboBox_5.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_6.BackColor = Color.White;
		this.comboBox_6.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_6.FlatStyle = FlatStyle.Flat;
		this.comboBox_6.Font = new Font(GClass107.smethod_3(81559), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_6.ForeColor = Color.Green;
		this.comboBox_6.FormattingEnabled = true;
		this.comboBox_6.Location = new Point(263, 10);
		this.comboBox_6.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_6.Name = GClass107.smethod_3(81602);
		this.comboBox_6.Size = new Size(50, 37);
		this.comboBox_6.TabIndex = 5;
		this.comboBox_6.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_7.BackColor = Color.White;
		this.comboBox_7.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_7.FlatStyle = FlatStyle.Flat;
		this.comboBox_7.Font = new Font(GClass107.smethod_3(81640), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_7.ForeColor = Color.Green;
		this.comboBox_7.FormattingEnabled = true;
		this.comboBox_7.Location = new Point(314, 10);
		this.comboBox_7.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_7.Name = GClass107.smethod_3(81670);
		this.comboBox_7.Size = new Size(50, 37);
		this.comboBox_7.TabIndex = 6;
		this.comboBox_7.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_8.BackColor = Color.White;
		this.comboBox_8.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_8.FlatStyle = FlatStyle.Flat;
		this.comboBox_8.Font = new Font(GClass107.smethod_3(81686), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_8.ForeColor = Color.Green;
		this.comboBox_8.FormattingEnabled = true;
		this.comboBox_8.Location = new Point(365, 10);
		this.comboBox_8.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_8.Name = GClass107.smethod_3(81689);
		this.comboBox_8.Size = new Size(50, 37);
		this.comboBox_8.TabIndex = 7;
		this.comboBox_8.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_9.BackColor = Color.White;
		this.comboBox_9.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_9.FlatStyle = FlatStyle.Flat;
		this.comboBox_9.Font = new Font(GClass107.smethod_3(81717), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_9.ForeColor = Color.Green;
		this.comboBox_9.FormattingEnabled = true;
		this.comboBox_9.Location = new Point(416, 10);
		this.comboBox_9.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_9.Name = GClass107.smethod_3(81746);
		this.comboBox_9.Size = new Size(50, 37);
		this.comboBox_9.TabIndex = 8;
		this.comboBox_9.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_10.BackColor = Color.White;
		this.comboBox_10.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_10.FlatStyle = FlatStyle.Flat;
		this.comboBox_10.Font = new Font(GClass107.smethod_3(81786), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_10.ForeColor = Color.Green;
		this.comboBox_10.FormattingEnabled = true;
		this.comboBox_10.Location = new Point(467, 10);
		this.comboBox_10.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_10.Name = GClass107.smethod_3(81820);
		this.comboBox_10.Size = new Size(50, 37);
		this.comboBox_10.TabIndex = 9;
		this.comboBox_10.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_11.BackColor = Color.White;
		this.comboBox_11.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_11.FlatStyle = FlatStyle.Flat;
		this.comboBox_11.Font = new Font(GClass107.smethod_3(81843), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_11.ForeColor = Color.Green;
		this.comboBox_11.FormattingEnabled = true;
		this.comboBox_11.Location = new Point(518, 10);
		this.comboBox_11.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_11.Name = GClass107.smethod_3(81850);
		this.comboBox_11.Size = new Size(50, 37);
		this.comboBox_11.TabIndex = 10;
		this.comboBox_11.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_12.BackColor = Color.White;
		this.comboBox_12.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_12.FlatStyle = FlatStyle.Flat;
		this.comboBox_12.Font = new Font(GClass107.smethod_3(81885), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_12.ForeColor = Color.Green;
		this.comboBox_12.FormattingEnabled = true;
		this.comboBox_12.Location = new Point(569, 10);
		this.comboBox_12.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_12.Name = GClass107.smethod_3(81907);
		this.comboBox_12.Size = new Size(50, 37);
		this.comboBox_12.TabIndex = 11;
		this.comboBox_12.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_13.BackColor = Color.White;
		this.comboBox_13.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_13.FlatStyle = FlatStyle.Flat;
		this.comboBox_13.Font = new Font(GClass107.smethod_3(81914), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_13.ForeColor = Color.Green;
		this.comboBox_13.FormattingEnabled = true;
		this.comboBox_13.Location = new Point(620, 10);
		this.comboBox_13.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_13.Name = GClass107.smethod_3(81960);
		this.comboBox_13.Size = new Size(50, 37);
		this.comboBox_13.TabIndex = 12;
		this.comboBox_13.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_14.BackColor = Color.White;
		this.comboBox_14.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_14.FlatStyle = FlatStyle.Flat;
		this.comboBox_14.Font = new Font(GClass107.smethod_3(81977), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_14.ForeColor = Color.Green;
		this.comboBox_14.FormattingEnabled = true;
		this.comboBox_14.Location = new Point(671, 10);
		this.comboBox_14.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_14.Name = GClass107.smethod_3(81995);
		this.comboBox_14.Size = new Size(50, 37);
		this.comboBox_14.TabIndex = 13;
		this.comboBox_14.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_15.BackColor = Color.White;
		this.comboBox_15.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_15.FlatStyle = FlatStyle.Flat;
		this.comboBox_15.Font = new Font(GClass107.smethod_3(82042), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_15.ForeColor = Color.Green;
		this.comboBox_15.FormattingEnabled = true;
		this.comboBox_15.Location = new Point(722, 10);
		this.comboBox_15.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_15.Name = GClass107.smethod_3(82069);
		this.comboBox_15.Size = new Size(50, 37);
		this.comboBox_15.TabIndex = 14;
		this.comboBox_15.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_16.BackColor = Color.White;
		this.comboBox_16.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_16.FlatStyle = FlatStyle.Flat;
		this.comboBox_16.Font = new Font(GClass107.smethod_3(82072), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_16.ForeColor = Color.Green;
		this.comboBox_16.FormattingEnabled = true;
		this.comboBox_16.Location = new Point(773, 10);
		this.comboBox_16.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_16.Name = GClass107.smethod_3(82105);
		this.comboBox_16.Size = new Size(50, 37);
		this.comboBox_16.TabIndex = 15;
		this.comboBox_16.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_17.BackColor = Color.White;
		this.comboBox_17.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_17.FlatStyle = FlatStyle.Flat;
		this.comboBox_17.Font = new Font(GClass107.smethod_3(82136), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_17.ForeColor = Color.Green;
		this.comboBox_17.FormattingEnabled = true;
		this.comboBox_17.Location = new Point(824, 10);
		this.comboBox_17.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_17.Name = GClass107.smethod_3(82167);
		this.comboBox_17.Size = new Size(50, 37);
		this.comboBox_17.TabIndex = 16;
		this.comboBox_17.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.label_0.AutoSize = true;
		this.label_0.Font = new Font(GClass107.smethod_3(82185), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_0.Location = new Point(30, 18);
		this.label_0.Name = GClass107.smethod_3(82220);
		this.label_0.Size = new Size(258, 38);
		this.label_0.TabIndex = 0;
		this.label_0.Text = GClass107.smethod_3(82237);
		base.AcceptButton = this.button_1;
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.Red;
		base.CancelButton = this.button_0;
		base.ClientSize = new Size(982, 272);
		base.Controls.Add(this.panel_0);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = GClass107.smethod_3(82274);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = GClass107.smethod_3(82313);
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		this.tableLayoutPanel_0.ResumeLayout(false);
		this.tableLayoutPanel_0.PerformLayout();
		this.panel_1.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	// Token: 0x0400030F RID: 783
	private string[] string_0 = new string[0];

	// Token: 0x04000310 RID: 784
	private int int_0;

	// Token: 0x04000311 RID: 785
	private ComboBox[] comboBox_0 = new ComboBox[0];

	// Token: 0x04000313 RID: 787
	private Panel panel_0;

	// Token: 0x04000314 RID: 788
	private Label label_0;

	// Token: 0x04000315 RID: 789
	private Button button_0;

	// Token: 0x04000316 RID: 790
	private Button button_1;

	// Token: 0x04000317 RID: 791
	private ComboBox comboBox_1;

	// Token: 0x04000318 RID: 792
	private ComboBox comboBox_2;

	// Token: 0x04000319 RID: 793
	private ComboBox comboBox_3;

	// Token: 0x0400031A RID: 794
	private ComboBox comboBox_4;

	// Token: 0x0400031B RID: 795
	private ComboBox comboBox_5;

	// Token: 0x0400031C RID: 796
	private ComboBox comboBox_6;

	// Token: 0x0400031D RID: 797
	private ComboBox comboBox_7;

	// Token: 0x0400031E RID: 798
	private ComboBox comboBox_8;

	// Token: 0x0400031F RID: 799
	private ComboBox comboBox_9;

	// Token: 0x04000320 RID: 800
	private ComboBox comboBox_10;

	// Token: 0x04000321 RID: 801
	private ComboBox comboBox_11;

	// Token: 0x04000322 RID: 802
	private ComboBox comboBox_12;

	// Token: 0x04000323 RID: 803
	private ComboBox comboBox_13;

	// Token: 0x04000324 RID: 804
	private ComboBox comboBox_14;

	// Token: 0x04000325 RID: 805
	private ComboBox comboBox_15;

	// Token: 0x04000326 RID: 806
	private ComboBox comboBox_16;

	// Token: 0x04000327 RID: 807
	private ComboBox comboBox_17;

	// Token: 0x04000328 RID: 808
	private Panel panel_1;

	// Token: 0x04000329 RID: 809
	private TableLayoutPanel tableLayoutPanel_0;
}
