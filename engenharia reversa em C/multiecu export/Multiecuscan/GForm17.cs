using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x020000BA RID: 186
public partial class GForm17 : Form
{
	// Token: 0x06000618 RID: 1560 RVA: 0x000DAFC4 File Offset: 0x000D91C4
	public GForm17(string string_1, string string_2, string string_3, string[] string_4, int int_1)
	{
		this.method_2();
		this.label_0.Text = string_1;
		this.label_1.Text = string_2;
		this.string_0 = string_4;
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
				for (int j = 0; j < string_4.Length; j++)
				{
					this.comboBox_0[i].Items.Add(string_4[j]);
				}
				if (int_1 == 1)
				{
					this.comboBox_0[i].SelectedItem = string_3;
				}
				if (string_3.Length > i)
				{
					this.comboBox_0[i].SelectedItem = string_3.Substring(i, 1);
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

	// Token: 0x06000619 RID: 1561 RVA: 0x00002F0A File Offset: 0x0000110A
	private void button_1_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x0600061A RID: 1562 RVA: 0x00002F0A File Offset: 0x0000110A
	private void method_0(object sender, EventArgs e)
	{
	}

	// Token: 0x0600061B RID: 1563 RVA: 0x000DB204 File Offset: 0x000D9404
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

	// Token: 0x0600061C RID: 1564 RVA: 0x000DB2E4 File Offset: 0x000D94E4
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

	// Token: 0x0600061D RID: 1565 RVA: 0x000DB358 File Offset: 0x000D9558
	private void button_2_Click(object sender, EventArgs e)
	{
		string text = GClass126.string_12;
		bool flag = GClass125.smethod_101(19).B == 0;
		string string_ = GClass126.string_1;
		string text2 = ((!flag) ? "" : "B") + ((GClass123.int_7 > 2) ? "F" : "") + ((GClass123.int_1 != 1) ? "F" : "");
		string text3 = ((!GClass126.bool_13) ? "" : "R") + GClass126.int_7.ToString();
		byte[] array = GClass127.smethod_32(text);
		for (int i = 0; i < array.Length; i++)
		{
			byte[] array2 = array;
			int num = i;
			array2[num] ^= 49;
			text += GClass127.smethod_23(array[i]);
			if (i == 5 || i == 9 || i == 14)
			{
				text += "-";
			}
		}
		string text4 = text.Substring(array.Length * 2);
		GClass127.smethod_39();
		Process.Start(string.Concat(new string[]
		{
			"https://www.multiecuscan.net/PurchaseSpecialFunction.aspx?token=",
			GClass125.smethod_91(),
			"&id1=",
			string_,
			text2,
			text3,
			text4,
			"&id2=",
			GClass126.bool_13 ? GClass125.smethod_5() : "-"
		}));
	}

	// Token: 0x0600061F RID: 1567 RVA: 0x000DB4A8 File Offset: 0x000D96A8
	private void method_2()
	{
		this.panel_0 = new Panel();
		this.label_1 = new Label();
		this.button_2 = new Button();
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
		this.panel_0.Controls.Add(this.label_1);
		this.panel_0.Controls.Add(this.button_2);
		this.panel_0.Controls.Add(this.tableLayoutPanel_0);
		this.panel_0.Controls.Add(this.panel_1);
		this.panel_0.Controls.Add(this.label_0);
		this.panel_0.ForeColor = Color.Red;
		this.panel_0.Location = new Point(14, 15);
		this.panel_0.Margin = new Padding(3, 4, 3, 4);
		this.panel_0.Name = GClass107.smethod_3(153777);
		this.panel_0.Size = new Size(955, 352);
		this.panel_0.TabIndex = 1;
		this.label_1.AutoSize = true;
		this.label_1.Font = new Font(GClass107.smethod_3(153819), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_1.ForeColor = Color.White;
		this.label_1.Location = new Point(30, 143);
		this.label_1.Name = GClass107.smethod_3(153851);
		this.label_1.Size = new Size(617, 26);
		this.label_1.TabIndex = 10;
		this.label_1.Text = GClass107.smethod_3(153853);
		this.button_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.button_2.AutoSize = true;
		this.button_2.BackColor = Color.WhiteSmoke;
		this.button_2.DialogResult = DialogResult.Cancel;
		this.button_2.Font = new Font(GClass107.smethod_3(153859), 13.8f, FontStyle.Bold);
		this.button_2.ForeColor = Color.Navy;
		this.button_2.Location = new Point(37, 173);
		this.button_2.Margin = new Padding(3, 4, 3, 4);
		this.button_2.Name = GClass107.smethod_3(153862);
		this.button_2.Size = new Size(880, 52);
		this.button_2.TabIndex = 9;
		this.button_2.Tag = "6408";
		this.button_2.Text = GClass107.smethod_3(153899);
		this.button_2.UseVisualStyleBackColor = false;
		this.button_2.Click += this.button_2_Click;
		this.tableLayoutPanel_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.tableLayoutPanel_0.ColumnCount = 2;
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 22f));
		this.tableLayoutPanel_0.Controls.Add(this.button_0, 0, 0);
		this.tableLayoutPanel_0.Controls.Add(this.button_1, 1, 0);
		this.tableLayoutPanel_0.Location = new Point(34, 270);
		this.tableLayoutPanel_0.Margin = new Padding(3, 4, 3, 4);
		this.tableLayoutPanel_0.Name = GClass107.smethod_3(153919);
		this.tableLayoutPanel_0.RowCount = 1;
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.Size = new Size(885, 60);
		this.tableLayoutPanel_0.TabIndex = 8;
		this.button_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.button_0.AutoSize = true;
		this.button_0.BackColor = Color.WhiteSmoke;
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Font = new Font(GClass107.smethod_3(153939), 13.8f, FontStyle.Bold);
		this.button_0.ForeColor = Color.Red;
		this.button_0.Location = new Point(3, 4);
		this.button_0.Margin = new Padding(3, 4, 3, 4);
		this.button_0.Name = GClass107.smethod_3(153975);
		this.button_0.Size = new Size(436, 52);
		this.button_0.TabIndex = 2;
		this.button_0.Tag = "8198";
		this.button_0.Text = GClass107.smethod_3(154006);
		this.button_0.UseVisualStyleBackColor = false;
		this.button_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.button_1.AutoSize = true;
		this.button_1.BackColor = Color.WhiteSmoke;
		this.button_1.DialogResult = DialogResult.OK;
		this.button_1.Font = new Font(GClass107.smethod_3(154021), 13.8f, FontStyle.Bold);
		this.button_1.ForeColor = Color.Green;
		this.button_1.Location = new Point(445, 4);
		this.button_1.Margin = new Padding(3, 4, 3, 4);
		this.button_1.Name = GClass107.smethod_3(154041);
		this.button_1.Size = new Size(437, 52);
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
		this.panel_1.Name = GClass107.smethod_3(154054);
		this.panel_1.Size = new Size(883, 60);
		this.panel_1.TabIndex = 0;
		this.comboBox_1.BackColor = Color.White;
		this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_1.FlatStyle = FlatStyle.Flat;
		this.comboBox_1.Font = new Font(GClass107.smethod_3(154101), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_1.ForeColor = Color.Green;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(8, 10);
		this.comboBox_1.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_1.Name = GClass107.smethod_3(154129);
		this.comboBox_1.Size = new Size(50, 34);
		this.comboBox_1.TabIndex = 0;
		this.comboBox_1.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_2.BackColor = Color.White;
		this.comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_2.FlatStyle = FlatStyle.Flat;
		this.comboBox_2.Font = new Font(GClass107.smethod_3(154161), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_2.ForeColor = Color.Green;
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Location = new Point(59, 10);
		this.comboBox_2.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_2.Name = GClass107.smethod_3(154179);
		this.comboBox_2.Size = new Size(50, 34);
		this.comboBox_2.TabIndex = 1;
		this.comboBox_2.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_3.BackColor = Color.White;
		this.comboBox_3.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_3.FlatStyle = FlatStyle.Flat;
		this.comboBox_3.Font = new Font(GClass107.smethod_3(154208), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_3.ForeColor = Color.Green;
		this.comboBox_3.FormattingEnabled = true;
		this.comboBox_3.Location = new Point(110, 10);
		this.comboBox_3.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_3.Name = GClass107.smethod_3(154222);
		this.comboBox_3.Size = new Size(50, 34);
		this.comboBox_3.TabIndex = 2;
		this.comboBox_3.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_4.BackColor = Color.White;
		this.comboBox_4.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_4.FlatStyle = FlatStyle.Flat;
		this.comboBox_4.Font = new Font(GClass107.smethod_3(154247), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_4.ForeColor = Color.Green;
		this.comboBox_4.FormattingEnabled = true;
		this.comboBox_4.Location = new Point(161, 10);
		this.comboBox_4.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_4.Name = GClass107.smethod_3(154285);
		this.comboBox_4.Size = new Size(50, 34);
		this.comboBox_4.TabIndex = 3;
		this.comboBox_4.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_5.BackColor = Color.White;
		this.comboBox_5.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_5.FlatStyle = FlatStyle.Flat;
		this.comboBox_5.Font = new Font(GClass107.smethod_3(154298), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_5.ForeColor = Color.Green;
		this.comboBox_5.FormattingEnabled = true;
		this.comboBox_5.Location = new Point(212, 10);
		this.comboBox_5.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_5.Name = GClass107.smethod_3(154311);
		this.comboBox_5.Size = new Size(50, 34);
		this.comboBox_5.TabIndex = 4;
		this.comboBox_5.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_6.BackColor = Color.White;
		this.comboBox_6.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_6.FlatStyle = FlatStyle.Flat;
		this.comboBox_6.Font = new Font(GClass107.smethod_3(154318), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_6.ForeColor = Color.Green;
		this.comboBox_6.FormattingEnabled = true;
		this.comboBox_6.Location = new Point(263, 10);
		this.comboBox_6.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_6.Name = GClass107.smethod_3(154325);
		this.comboBox_6.Size = new Size(50, 34);
		this.comboBox_6.TabIndex = 5;
		this.comboBox_6.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_7.BackColor = Color.White;
		this.comboBox_7.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_7.FlatStyle = FlatStyle.Flat;
		this.comboBox_7.Font = new Font(GClass107.smethod_3(154373), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_7.ForeColor = Color.Green;
		this.comboBox_7.FormattingEnabled = true;
		this.comboBox_7.Location = new Point(314, 10);
		this.comboBox_7.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_7.Name = GClass107.smethod_3(154384);
		this.comboBox_7.Size = new Size(50, 34);
		this.comboBox_7.TabIndex = 6;
		this.comboBox_7.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_8.BackColor = Color.White;
		this.comboBox_8.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_8.FlatStyle = FlatStyle.Flat;
		this.comboBox_8.Font = new Font(GClass107.smethod_3(154411), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_8.ForeColor = Color.Green;
		this.comboBox_8.FormattingEnabled = true;
		this.comboBox_8.Location = new Point(365, 10);
		this.comboBox_8.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_8.Name = GClass107.smethod_3(154415);
		this.comboBox_8.Size = new Size(50, 34);
		this.comboBox_8.TabIndex = 7;
		this.comboBox_8.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_9.BackColor = Color.White;
		this.comboBox_9.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_9.FlatStyle = FlatStyle.Flat;
		this.comboBox_9.Font = new Font(GClass107.smethod_3(154451), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_9.ForeColor = Color.Green;
		this.comboBox_9.FormattingEnabled = true;
		this.comboBox_9.Location = new Point(416, 10);
		this.comboBox_9.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_9.Name = GClass107.smethod_3(154487);
		this.comboBox_9.Size = new Size(50, 34);
		this.comboBox_9.TabIndex = 8;
		this.comboBox_9.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_10.BackColor = Color.White;
		this.comboBox_10.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_10.FlatStyle = FlatStyle.Flat;
		this.comboBox_10.Font = new Font(GClass107.smethod_3(154522), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_10.ForeColor = Color.Green;
		this.comboBox_10.FormattingEnabled = true;
		this.comboBox_10.Location = new Point(467, 10);
		this.comboBox_10.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_10.Name = GClass107.smethod_3(154535);
		this.comboBox_10.Size = new Size(50, 34);
		this.comboBox_10.TabIndex = 9;
		this.comboBox_10.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_11.BackColor = Color.White;
		this.comboBox_11.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_11.FlatStyle = FlatStyle.Flat;
		this.comboBox_11.Font = new Font(GClass107.smethod_3(154540), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_11.ForeColor = Color.Green;
		this.comboBox_11.FormattingEnabled = true;
		this.comboBox_11.Location = new Point(518, 10);
		this.comboBox_11.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_11.Name = GClass107.smethod_3(154549);
		this.comboBox_11.Size = new Size(50, 34);
		this.comboBox_11.TabIndex = 10;
		this.comboBox_11.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_12.BackColor = Color.White;
		this.comboBox_12.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_12.FlatStyle = FlatStyle.Flat;
		this.comboBox_12.Font = new Font(GClass107.smethod_3(154580), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_12.ForeColor = Color.Green;
		this.comboBox_12.FormattingEnabled = true;
		this.comboBox_12.Location = new Point(569, 10);
		this.comboBox_12.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_12.Name = GClass107.smethod_3(154621);
		this.comboBox_12.Size = new Size(50, 34);
		this.comboBox_12.TabIndex = 11;
		this.comboBox_12.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_13.BackColor = Color.White;
		this.comboBox_13.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_13.FlatStyle = FlatStyle.Flat;
		this.comboBox_13.Font = new Font(GClass107.smethod_3(154663), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_13.ForeColor = Color.Green;
		this.comboBox_13.FormattingEnabled = true;
		this.comboBox_13.Location = new Point(620, 10);
		this.comboBox_13.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_13.Name = GClass107.smethod_3(154676);
		this.comboBox_13.Size = new Size(50, 34);
		this.comboBox_13.TabIndex = 12;
		this.comboBox_13.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_14.BackColor = Color.White;
		this.comboBox_14.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_14.FlatStyle = FlatStyle.Flat;
		this.comboBox_14.Font = new Font(GClass107.smethod_3(154677), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_14.ForeColor = Color.Green;
		this.comboBox_14.FormattingEnabled = true;
		this.comboBox_14.Location = new Point(671, 10);
		this.comboBox_14.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_14.Name = GClass107.smethod_3(154678);
		this.comboBox_14.Size = new Size(50, 34);
		this.comboBox_14.TabIndex = 13;
		this.comboBox_14.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_15.BackColor = Color.White;
		this.comboBox_15.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_15.FlatStyle = FlatStyle.Flat;
		this.comboBox_15.Font = new Font(GClass107.smethod_3(154692), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_15.ForeColor = Color.Green;
		this.comboBox_15.FormattingEnabled = true;
		this.comboBox_15.Location = new Point(722, 10);
		this.comboBox_15.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_15.Name = GClass107.smethod_3(154713);
		this.comboBox_15.Size = new Size(50, 34);
		this.comboBox_15.TabIndex = 14;
		this.comboBox_15.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_16.BackColor = Color.White;
		this.comboBox_16.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_16.FlatStyle = FlatStyle.Flat;
		this.comboBox_16.Font = new Font(GClass107.smethod_3(154748), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_16.ForeColor = Color.Green;
		this.comboBox_16.FormattingEnabled = true;
		this.comboBox_16.Location = new Point(773, 10);
		this.comboBox_16.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_16.Name = GClass107.smethod_3(154767);
		this.comboBox_16.Size = new Size(50, 34);
		this.comboBox_16.TabIndex = 15;
		this.comboBox_16.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.comboBox_17.BackColor = Color.White;
		this.comboBox_17.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_17.FlatStyle = FlatStyle.Flat;
		this.comboBox_17.Font = new Font(GClass107.smethod_3(154800), 11f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_17.ForeColor = Color.Green;
		this.comboBox_17.FormattingEnabled = true;
		this.comboBox_17.Location = new Point(824, 10);
		this.comboBox_17.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_17.Name = GClass107.smethod_3(154846);
		this.comboBox_17.Size = new Size(50, 34);
		this.comboBox_17.TabIndex = 16;
		this.comboBox_17.SelectedIndexChanged += this.comboBox_17_SelectedIndexChanged;
		this.label_0.AutoSize = true;
		this.label_0.Font = new Font(GClass107.smethod_3(154895), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_0.Location = new Point(30, 18);
		this.label_0.Name = GClass107.smethod_3(154940);
		this.label_0.Size = new Size(258, 38);
		this.label_0.TabIndex = 0;
		this.label_0.Text = GClass107.smethod_3(154976);
		base.AcceptButton = this.button_1;
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.Red;
		base.CancelButton = this.button_0;
		base.ClientSize = new Size(982, 382);
		base.Controls.Add(this.panel_0);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = GClass107.smethod_3(155004);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = GClass107.smethod_3(155025);
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		this.tableLayoutPanel_0.ResumeLayout(false);
		this.tableLayoutPanel_0.PerformLayout();
		this.panel_1.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	// Token: 0x0400054F RID: 1359
	private string[] string_0 = new string[0];

	// Token: 0x04000550 RID: 1360
	private int int_0;

	// Token: 0x04000551 RID: 1361
	private ComboBox[] comboBox_0 = new ComboBox[0];

	// Token: 0x04000553 RID: 1363
	private Panel panel_0;

	// Token: 0x04000554 RID: 1364
	private Label label_0;

	// Token: 0x04000555 RID: 1365
	private Button button_0;

	// Token: 0x04000556 RID: 1366
	private Button button_1;

	// Token: 0x04000557 RID: 1367
	private ComboBox comboBox_1;

	// Token: 0x04000558 RID: 1368
	private ComboBox comboBox_2;

	// Token: 0x04000559 RID: 1369
	private ComboBox comboBox_3;

	// Token: 0x0400055A RID: 1370
	private ComboBox comboBox_4;

	// Token: 0x0400055B RID: 1371
	private ComboBox comboBox_5;

	// Token: 0x0400055C RID: 1372
	private ComboBox comboBox_6;

	// Token: 0x0400055D RID: 1373
	private ComboBox comboBox_7;

	// Token: 0x0400055E RID: 1374
	private ComboBox comboBox_8;

	// Token: 0x0400055F RID: 1375
	private ComboBox comboBox_9;

	// Token: 0x04000560 RID: 1376
	private ComboBox comboBox_10;

	// Token: 0x04000561 RID: 1377
	private ComboBox comboBox_11;

	// Token: 0x04000562 RID: 1378
	private ComboBox comboBox_12;

	// Token: 0x04000563 RID: 1379
	private ComboBox comboBox_13;

	// Token: 0x04000564 RID: 1380
	private ComboBox comboBox_14;

	// Token: 0x04000565 RID: 1381
	private ComboBox comboBox_15;

	// Token: 0x04000566 RID: 1382
	private ComboBox comboBox_16;

	// Token: 0x04000567 RID: 1383
	private ComboBox comboBox_17;

	// Token: 0x04000568 RID: 1384
	private Panel panel_1;

	// Token: 0x04000569 RID: 1385
	private TableLayoutPanel tableLayoutPanel_0;

	// Token: 0x0400056A RID: 1386
	private Label label_1;

	// Token: 0x0400056B RID: 1387
	private Button button_2;
}
