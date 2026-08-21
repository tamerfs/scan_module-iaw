using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Management;
using System.Media;
using System.Threading;
using System.Windows.Forms;

// Token: 0x020000B3 RID: 179
public partial class GForm13 : Form
{
	// Token: 0x060005D0 RID: 1488 RVA: 0x000D146C File Offset: 0x000CF66C
	private void button_3_Click(object sender, EventArgs e)
	{
		this.fontDialog_0.Font = this.label_9.Font;
		this.fontDialog_0.Color = this.label_9.ForeColor;
		this.fontDialog_0.ShowColor = true;
		if (this.fontDialog_0.ShowDialog() == DialogResult.OK)
		{
			this.label_9.Text = GClass127.smethod_49(this.fontDialog_0.Font);
			this.label_9.Font = this.fontDialog_0.Font;
			this.label_9.ForeColor = this.fontDialog_0.Color;
		}
	}

	// Token: 0x060005D1 RID: 1489 RVA: 0x00002F0A File Offset: 0x0000110A
	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
	}

	// Token: 0x060005D2 RID: 1490 RVA: 0x000D1508 File Offset: 0x000CF708
	private bool method_0(string string_0)
	{
		int num = this.method_1(string_0);
		return num == 6 || num == 7 || num == 15;
	}

	// Token: 0x060005D3 RID: 1491 RVA: 0x00004380 File Offset: 0x00002580
	private void GForm13_FormClosing(object sender, FormClosingEventArgs e)
	{
		this.bool_0 = false;
		GClass121.smethod_0(GClass125.smethod_20());
	}

	// Token: 0x060005D4 RID: 1492 RVA: 0x000D152C File Offset: 0x000CF72C
	private void button_8_Click(object sender, EventArgs e)
	{
		Cursor.Current = Cursors.WaitCursor;
		try
		{
			if (!this.method_3((string)this.comboBox_9.SelectedItem))
			{
				new GForm15(GClass127.smethod_1(this.comboBox_8.SelectedItem, "       ").Substring(0, 6).Trim(), GClass127.smethod_37(this.comboBox_10.SelectedItem.ToString()), this.method_1(this.comboBox_9.SelectedItem.ToString())).ShowDialog();
			}
			else
			{
				new GForm15("IP" + this.textBox_2.Text, 0, this.method_1(this.comboBox_9.SelectedItem.ToString())).ShowDialog();
			}
		}
		catch (Exception)
		{
		}
		Cursor.Current = Cursors.Default;
	}

	// Token: 0x060005D5 RID: 1493 RVA: 0x000D160C File Offset: 0x000CF80C
	private int method_1(string string_0)
	{
		int result = 0;
		for (int i = 0; i < GClass125.string_1.Length; i++)
		{
			if (GClass125.string_1[i] == string_0)
			{
				result = i;
				return result;
			}
		}
		return result;
	}

	// Token: 0x060005D6 RID: 1494 RVA: 0x000D1644 File Offset: 0x000CF844
	private void button_7_Click(object sender, EventArgs e)
	{
		Cursor.Current = Cursors.WaitCursor;
		try
		{
			if (!this.method_3((string)this.comboBox_6.SelectedItem))
			{
				new GForm15(GClass127.smethod_1(this.comboBox_5.SelectedItem, "       ").Substring(0, 6).Trim(), GClass127.smethod_37(this.comboBox_7.SelectedItem.ToString()), this.method_1(this.comboBox_6.SelectedItem.ToString())).ShowDialog();
			}
			else
			{
				new GForm15("IP" + this.textBox_3.Text, 0, this.method_1(this.comboBox_6.SelectedItem.ToString())).ShowDialog();
			}
		}
		catch (Exception)
		{
		}
		Cursor.Current = Cursors.Default;
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x000D1724 File Offset: 0x000CF924
	private void method_2()
	{
		foreach (Control control in GForm13.smethod_0(this, 1))
		{
			if (control.Tag != null)
			{
				string text = GClass121.smethod_6(control.Tag.ToString());
				string text2 = GClass121.smethod_6(control.Tag.ToString() + "T");
				if (text2 != null && text2 != "" && (control is Button || control is CheckBox || control is ComboBox || control is TextBox))
				{
					this.toolTip_0.SetToolTip(control, text2.Replace("\\r", Environment.NewLine));
				}
				if (text != null)
				{
					if (control is Label)
					{
						((Label)control).Text = text;
					}
					if (control is Button)
					{
						((Button)control).Text = text;
					}
					if (control is CheckBox)
					{
						((CheckBox)control).Text = text;
					}
					if (control is GroupBox)
					{
						((GroupBox)control).Text = " " + text + " ";
					}
				}
			}
		}
		string text3 = GClass121.smethod_6("8192");
		if (text3 != null)
		{
			this.tabPage_0.Text = text3;
		}
		text3 = GClass121.smethod_6("8193");
		if (text3 != null)
		{
			this.tabPage_1.Text = text3;
		}
		text3 = GClass121.smethod_6("8194");
		if (text3 != null)
		{
			this.tabPage_2.Text = text3;
		}
		text3 = GClass121.smethod_6("8195");
		if (text3 != null)
		{
			this.tabPage_3.Text = text3;
		}
		text3 = GClass121.smethod_6("8191");
		if (text3 != null)
		{
			this.Text = text3;
		}
	}

	// Token: 0x060005D8 RID: 1496 RVA: 0x000D18EC File Offset: 0x000CFAEC
	private void button_0_Click(object sender, EventArgs e)
	{
		GClass125.smethod_39(0, this.method_1(GClass127.smethod_48(this.comboBox_6.SelectedItem)));
		GClass125.smethod_39(1, this.method_1(GClass127.smethod_48(this.comboBox_9.SelectedItem)));
		if (this.comboBox_5.Visible || this.textBox_3.Visible)
		{
			GClass125.smethod_41(0, this.textBox_3.Visible ? ("IP" + this.textBox_3.Text) : GClass127.smethod_1(this.comboBox_5.SelectedItem, GClass125.smethod_40(0) + "    ").Substring(0, 6).Trim());
		}
		if (this.comboBox_8.Visible || this.textBox_2.Visible)
		{
			GClass125.smethod_41(1, this.textBox_2.Visible ? ("IP" + this.textBox_2.Text) : GClass127.smethod_1(this.comboBox_8.SelectedItem, GClass125.smethod_40(1) + "    ").Substring(0, 6).Trim());
		}
		GClass125.smethod_43(0, GClass127.smethod_37(this.comboBox_7.SelectedItem));
		GClass125.smethod_43(1, GClass127.smethod_37(this.comboBox_10.SelectedItem));
		GClass125.smethod_45(0);
		GClass125.smethod_60(this.checkBox_0.Checked);
		GClass125.smethod_64(this.comboBox_4.SelectedIndex);
		GClass125.smethod_66(this.checkBox_2.Checked);
		GClass125.smethod_68(this.comboBox_11.SelectedIndex);
		GClass125.smethod_62(this.checkBox_1.Checked);
		GClass125.smethod_72(!this.radioButton_1.Checked);
		GClass125.smethod_74(!this.radioButton_3.Checked);
		GClass125.smethod_76(!this.radioButton_9.Checked);
		GClass125.smethod_78(!this.radioButton_7.Checked);
		GClass125.smethod_80(!this.radioButton_5.Checked);
		GClass125.smethod_19((string)this.comboBox_3.SelectedItem);
		GClass125.smethod_33(this.textBox_0.Text);
		GClass125.smethod_35(this.textBox_1.Text);
		GClass125.smethod_102(0, this.panel_7.BackColor);
		GClass125.smethod_102(1, this.panel_6.BackColor);
		GClass125.smethod_102(2, this.panel_5.BackColor);
		GClass125.smethod_102(3, this.panel_4.BackColor);
		GClass125.smethod_102(4, this.panel_3.BackColor);
		GClass125.smethod_102(5, this.panel_2.BackColor);
		GClass125.smethod_102(6, this.panel_1.BackColor);
		GClass125.smethod_102(7, this.panel_0.BackColor);
		GClass125.smethod_102(8, this.panel_17.BackColor);
		GClass125.smethod_102(9, this.panel_16.BackColor);
		GClass125.smethod_102(10, this.panel_15.BackColor);
		GClass125.smethod_102(11, this.panel_14.BackColor);
		GClass125.smethod_102(12, this.panel_13.BackColor);
		GClass125.smethod_102(13, this.panel_12.BackColor);
		GClass125.smethod_102(14, this.panel_11.BackColor);
		GClass125.smethod_102(15, this.panel_10.BackColor);
		GClass125.smethod_104(this.panel_9.BackColor);
		GClass125.smethod_106(this.panel_8.BackColor);
		GClass125.smethod_110(GClass127.smethod_37(this.comboBox_2.SelectedItem));
		GClass125.smethod_112(this.label_11.Font);
		GClass125.smethod_114(this.label_9.Font);
		GClass125.smethod_116(this.label_7.Font);
		GClass125.smethod_108(this.label_9.ForeColor);
		GClass125.smethod_21(this.comboBox_0.SelectedItem.ToString());
		GClass125.smethod_23(this.comboBox_1.SelectedItem.ToString());
		GClass125.smethod_27(this.label_17.Font);
		GClass125.smethod_29(this.label_15.Font);
		GClass121.smethod_11(GClass125.smethod_20(), GClass125.smethod_22());
		GClass125.smethod_138();
	}

	// Token: 0x060005D9 RID: 1497 RVA: 0x000D1D14 File Offset: 0x000CFF14
	public GForm13()
	{
		this.method_6();
		string[] array = GClass121.smethod_5();
		string[] array2 = GClass121.smethod_9();
		this.comboBox_0.Items.Clear();
		for (int i = 0; i < array2.Length; i++)
		{
			this.comboBox_0.Items.Add(array2[i]);
		}
		this.comboBox_1.Items.Clear();
		for (int j = 0; j < array.Length; j++)
		{
			this.comboBox_1.Items.Add(array[j]);
		}
		this.comboBox_1.SelectedItem = GClass125.smethod_22();
		this.comboBox_0.SelectedItem = GClass125.smethod_20();
		this.checkBox_0.Checked = true;
		this.checkBox_0.Enabled = false;
		new Thread(new ThreadStart(this.method_4)).Start();
		this.comboBox_4.SelectedIndex = GClass125.smethod_63();
		this.checkBox_1.Checked = GClass125.smethod_61();
		this.checkBox_2.Checked = GClass125.smethod_65();
		this.comboBox_11.SelectedIndex = GClass125.smethod_67();
		if (GClass125.smethod_71())
		{
			this.radioButton_0.Checked = true;
		}
		else
		{
			this.radioButton_1.Checked = true;
		}
		if (GClass125.smethod_73())
		{
			this.radioButton_2.Checked = true;
		}
		else
		{
			this.radioButton_3.Checked = true;
		}
		if (GClass125.smethod_75())
		{
			this.radioButton_8.Checked = true;
		}
		else
		{
			this.radioButton_9.Checked = true;
		}
		if (GClass125.smethod_77())
		{
			this.radioButton_6.Checked = true;
		}
		else
		{
			this.radioButton_7.Checked = true;
		}
		if (GClass125.smethod_79())
		{
			this.radioButton_4.Checked = true;
		}
		else
		{
			this.radioButton_5.Checked = true;
		}
		this.comboBox_6.Items.Clear();
		this.comboBox_9.Items.Clear();
		int[] array3 = new int[]
		{
			16,
			1,
			2,
			3,
			9,
			11,
			7,
			12,
			15,
			4,
			5,
			10
		};
		int[] array4 = new int[]
		{
			0,
			1,
			2,
			3,
			9,
			11,
			7,
			12,
			15,
			4,
			5,
			10
		};
		if (GClass126.bool_10)
		{
			array3 = new int[]
			{
				16,
				6
			};
			array4 = new int[]
			{
				13
			};
		}
		foreach (int num in array3)
		{
			this.comboBox_6.Items.Add(GClass125.string_1[num]);
		}
		foreach (int num2 in array4)
		{
			this.comboBox_9.Items.Add(GClass125.string_1[num2]);
		}
		this.comboBox_6.SelectedIndex = 0;
		this.comboBox_6.SelectedItem = GClass125.string_1[(GClass125.smethod_38(0) < GClass125.string_1.Length) ? GClass125.smethod_38(0) : 16];
		this.comboBox_7.SelectedItem = (GClass125.smethod_42(0).ToString() ?? "");
		this.comboBox_9.SelectedIndex = 0;
		this.comboBox_9.SelectedItem = GClass125.string_1[(GClass125.smethod_38(1) < GClass125.string_1.Length) ? GClass125.smethod_38(1) : 0];
		this.comboBox_10.SelectedItem = (GClass125.smethod_42(1).ToString() ?? "");
		this.textBox_3.Text = (GClass125.smethod_40(0).StartsWith("IP") ? GClass125.smethod_40(0).Replace("IP", "") : "0.0.0.0:0");
		this.textBox_2.Text = (GClass125.smethod_40(1).StartsWith("IP") ? GClass125.smethod_40(1).Replace("IP", "") : "0.0.0.0:0");
		this.comboBox_9.Enabled = !GClass126.bool_10;
		this.comboBox_3.SelectedItem = GClass125.smethod_18();
		this.textBox_0.Text = GClass125.smethod_32();
		this.textBox_1.Text = GClass125.smethod_34();
		this.label_17.Text = GClass127.smethod_49(GClass125.smethod_26());
		this.label_17.Font = GClass125.smethod_26();
		this.label_15.Text = GClass127.smethod_49(GClass125.smethod_28());
		this.label_15.Font = GClass125.smethod_28();
		this.panel_7.BackColor = GClass125.smethod_101(0);
		this.panel_6.BackColor = GClass125.smethod_101(1);
		this.panel_5.BackColor = GClass125.smethod_101(2);
		this.panel_4.BackColor = GClass125.smethod_101(3);
		this.panel_3.BackColor = GClass125.smethod_101(4);
		this.panel_2.BackColor = GClass125.smethod_101(5);
		this.panel_1.BackColor = GClass125.smethod_101(6);
		this.panel_0.BackColor = GClass125.smethod_101(7);
		this.panel_17.BackColor = GClass125.smethod_101(8);
		this.panel_16.BackColor = GClass125.smethod_101(9);
		this.panel_15.BackColor = GClass125.smethod_101(10);
		this.panel_14.BackColor = GClass125.smethod_101(11);
		this.panel_13.BackColor = GClass125.smethod_101(12);
		this.panel_12.BackColor = GClass125.smethod_101(13);
		this.panel_11.BackColor = GClass125.smethod_101(14);
		this.panel_10.BackColor = GClass125.smethod_101(15);
		this.panel_9.BackColor = GClass125.smethod_103();
		this.panel_8.BackColor = GClass125.smethod_105();
		this.comboBox_2.SelectedItem = (GClass125.smethod_109().ToString() ?? "");
		this.label_11.Text = GClass127.smethod_49(GClass125.smethod_111());
		this.label_11.Font = GClass125.smethod_111();
		this.label_9.Text = GClass127.smethod_49(GClass125.smethod_113());
		this.label_9.Font = GClass125.smethod_113();
		this.label_9.ForeColor = GClass125.smethod_107();
		this.label_7.Text = GClass127.smethod_49(GClass125.smethod_115());
		this.label_7.Font = GClass125.smethod_115();
		this.label_9.BackColor = GClass125.smethod_103();
		this.comboBox_1.Enabled = GClass126.bool_13;
		if (!this.comboBox_1.Enabled)
		{
			this.comboBox_1.SelectedItem = GClass107.smethod_3(140176);
		}
		if (GClass126.bool_10)
		{
			this.checkBox_2.Visible = false;
		}
		this.method_2();
	}

	// Token: 0x060005DA RID: 1498 RVA: 0x000D2388 File Offset: 0x000D0588
	private void button_2_Click(object sender, EventArgs e)
	{
		this.fontDialog_0.Font = this.label_7.Font;
		this.fontDialog_0.ShowColor = false;
		if (this.fontDialog_0.ShowDialog() == DialogResult.OK)
		{
			this.label_7.Text = GClass127.smethod_49(this.fontDialog_0.Font);
			this.label_7.Font = this.fontDialog_0.Font;
		}
	}

	// Token: 0x060005DB RID: 1499 RVA: 0x000D23F8 File Offset: 0x000D05F8
	public static List<Control> smethod_0(Control control_0, int int_0)
	{
		List<Control> list = new List<Control>();
		if (int_0 < 10)
		{
			foreach (object obj in control_0.Controls)
			{
				Control control = (Control)obj;
				list.AddRange(GForm13.smethod_0(control, int_0 + 1));
				list.Add(control);
			}
		}
		return list;
	}

	// Token: 0x060005DC RID: 1500 RVA: 0x00004393 File Offset: 0x00002593
	private void button_10_Click(object sender, EventArgs e)
	{
		GClass125.smethod_99("");
	}

	// Token: 0x060005DD RID: 1501 RVA: 0x000D2470 File Offset: 0x000D0670
	private void button_5_Click(object sender, EventArgs e)
	{
		this.fontDialog_0.Font = this.label_15.Font;
		this.fontDialog_0.ShowColor = false;
		if (this.fontDialog_0.ShowDialog() == DialogResult.OK)
		{
			this.label_15.Text = GClass127.smethod_49(this.fontDialog_0.Font);
			this.label_15.Font = this.fontDialog_0.Font;
		}
	}

	// Token: 0x060005DE RID: 1502 RVA: 0x000D24E0 File Offset: 0x000D06E0
	private void comboBox_6_SelectedIndexChanged(object sender, EventArgs e)
	{
		new Thread(new ThreadStart(this.method_4)).Start();
		this.button_7.Visible = (this.comboBox_6.SelectedIndex > 0);
		this.button_8.Visible = (this.comboBox_9.SelectedIndex > 0);
		this.groupBox_1.Visible = (this.comboBox_6.SelectedIndex > 0);
		this.checkBox_0.Visible = (this.comboBox_6.SelectedIndex > 0);
		bool flag = this.method_3((string)this.comboBox_6.SelectedItem);
		bool flag2 = this.method_3((string)this.comboBox_9.SelectedItem);
		this.textBox_3.Visible = flag;
		this.textBox_2.Visible = flag2;
		this.comboBox_5.Visible = (!flag && this.comboBox_6.SelectedIndex > 0 && this.method_1((string)this.comboBox_6.SelectedItem) != 14);
		this.comboBox_8.Visible = (!flag2 && this.comboBox_9.SelectedIndex > 0 && this.method_1((string)this.comboBox_9.SelectedItem) != 14);
		this.comboBox_7.Visible = (!flag && this.method_1((string)this.comboBox_6.SelectedItem) > 1 && !GClass126.bool_10 && this.comboBox_5.Visible);
		this.comboBox_10.Visible = (!flag2 && this.method_1((string)this.comboBox_9.SelectedItem) > 1 && !GClass126.bool_10 && this.comboBox_8.Visible);
		this.label_26.Visible = flag;
		this.label_25.Visible = flag2;
		this.label_21.Visible = this.comboBox_5.Visible;
		this.label_23.Visible = this.comboBox_8.Visible;
		bool visible = this.method_1(GClass127.smethod_48(this.comboBox_6.SelectedItem)) == 1 || this.method_1(GClass127.smethod_48(this.comboBox_9.SelectedItem)) == 1 || this.method_1(GClass127.smethod_48(this.comboBox_6.SelectedItem)) == 6 || this.method_1(GClass127.smethod_48(this.comboBox_9.SelectedItem)) == 6;
		this.comboBox_4.Visible = visible;
		this.label_19.Visible = visible;
		this.checkBox_2.Visible = visible;
		if (!(((ComboBox)sender).Name == GClass107.smethod_3(140184)) || this.method_1(GClass127.smethod_48(this.comboBox_6.SelectedItem)) <= 1)
		{
			if (((ComboBox)sender).Name == GClass107.smethod_3(140304) && this.method_1(GClass127.smethod_48(this.comboBox_9.SelectedItem)) > 1)
			{
				if (this.method_1(GClass127.smethod_48(this.comboBox_9.SelectedItem)) == 2)
				{
					this.comboBox_10.SelectedIndex = 2;
					return;
				}
				if (this.method_1(GClass127.smethod_48(this.comboBox_9.SelectedItem)) == 4)
				{
					this.comboBox_10.SelectedIndex = 0;
					return;
				}
				if (this.method_1(GClass127.smethod_48(this.comboBox_9.SelectedItem)) == 8)
				{
					this.comboBox_10.SelectedIndex = 2;
					return;
				}
				if (this.method_1(GClass127.smethod_48(this.comboBox_9.SelectedItem)) == 9)
				{
					this.textBox_2.Text = GClass107.smethod_3(140334);
					return;
				}
				if (this.method_1(GClass127.smethod_48(this.comboBox_9.SelectedItem)) == 10)
				{
					this.textBox_2.Text = GClass107.smethod_3(140335);
					return;
				}
				if (this.method_1(GClass127.smethod_48(this.comboBox_9.SelectedItem)) == 11)
				{
					this.comboBox_10.SelectedIndex = 2;
					return;
				}
				if (this.method_1(GClass127.smethod_48(this.comboBox_9.SelectedItem)) == 12)
				{
					this.textBox_2.Text = GClass107.smethod_3(140369);
					return;
				}
				if (this.method_1(GClass127.smethod_48(this.comboBox_9.SelectedItem)) == 13)
				{
					this.textBox_2.Text = GClass107.smethod_3(140400);
					return;
				}
				this.comboBox_10.SelectedIndex = 4;
			}
			return;
		}
		if (this.method_1(GClass127.smethod_48(this.comboBox_6.SelectedItem)) == 2)
		{
			this.comboBox_7.SelectedIndex = 2;
			return;
		}
		if (this.method_1(GClass127.smethod_48(this.comboBox_6.SelectedItem)) == 4)
		{
			this.comboBox_7.SelectedIndex = 0;
			return;
		}
		if (this.method_1(GClass127.smethod_48(this.comboBox_6.SelectedItem)) == 8)
		{
			this.comboBox_7.SelectedIndex = 2;
			return;
		}
		if (this.method_1(GClass127.smethod_48(this.comboBox_6.SelectedItem)) == 9)
		{
			this.textBox_3.Text = GClass107.smethod_3(140224);
			return;
		}
		if (this.method_1(GClass127.smethod_48(this.comboBox_6.SelectedItem)) == 10)
		{
			this.textBox_3.Text = GClass107.smethod_3(140236);
			return;
		}
		if (this.method_1(GClass127.smethod_48(this.comboBox_6.SelectedItem)) == 11)
		{
			this.comboBox_7.SelectedIndex = 2;
			return;
		}
		if (this.method_1(GClass127.smethod_48(this.comboBox_6.SelectedItem)) == 12)
		{
			this.textBox_3.Text = GClass107.smethod_3(140264);
			return;
		}
		if (this.method_1(GClass127.smethod_48(this.comboBox_6.SelectedItem)) == 13)
		{
			this.textBox_3.Text = GClass107.smethod_3(140283);
			return;
		}
		this.comboBox_7.SelectedIndex = 4;
	}

	// Token: 0x060005DF RID: 1503 RVA: 0x000D2AB0 File Offset: 0x000D0CB0
	private void button_9_Click(object sender, EventArgs e)
	{
		GForm6 gform = new GForm6();
		if (gform.ShowDialog() == DialogResult.OK)
		{
			if (GClass126.bool_10 && gform.list_0.Count <= 1)
			{
				if (gform.list_0.Count == 1)
				{
					this.comboBox_5.SelectedItem = gform.list_1[0];
					this.comboBox_7.SelectedItem = (gform.list_2[0].ToString() ?? "");
					return;
				}
			}
			else if (!GClass126.bool_10)
			{
				if (gform.list_0.Count > 0)
				{
					this.comboBox_6.SelectedItem = GClass125.string_1[gform.list_0[0]];
					string value = gform.list_1[0] + " ";
					for (int i = 0; i < this.comboBox_5.Items.Count; i++)
					{
						if (GClass127.smethod_48(this.comboBox_5.Items[i]).StartsWith(value))
						{
							this.comboBox_5.SelectedIndex = i;
						}
					}
					this.comboBox_7.SelectedItem = (gform.list_2[0].ToString() ?? "");
				}
				else
				{
					this.comboBox_6.SelectedIndex = 0;
				}
				if (gform.list_0.Count > 1)
				{
					this.comboBox_9.SelectedItem = GClass125.string_1[gform.list_0[1]];
					string value = gform.list_1[1] + " ";
					for (int j = 0; j < this.comboBox_8.Items.Count; j++)
					{
						if (GClass127.smethod_48(this.comboBox_8.Items[j]).StartsWith(value))
						{
							this.comboBox_8.SelectedIndex = j;
						}
					}
					this.comboBox_10.SelectedItem = (gform.list_2[1].ToString() ?? "");
					return;
				}
				this.comboBox_9.SelectedIndex = 0;
			}
		}
	}

	// Token: 0x060005E0 RID: 1504 RVA: 0x000D2CCC File Offset: 0x000D0ECC
	private bool method_3(string string_0)
	{
		int num = this.method_1(string_0);
		return num == 9 || num == 10 || num == 13 || num == 12;
	}

	// Token: 0x060005E1 RID: 1505 RVA: 0x000D2CF8 File Offset: 0x000D0EF8
	private void button_4_Click(object sender, EventArgs e)
	{
		this.fontDialog_0.Font = this.label_11.Font;
		this.fontDialog_0.ShowColor = false;
		if (this.fontDialog_0.ShowDialog() == DialogResult.OK)
		{
			this.label_11.Text = GClass127.smethod_49(this.fontDialog_0.Font);
			this.label_11.Font = this.fontDialog_0.Font;
		}
	}

	// Token: 0x060005E2 RID: 1506 RVA: 0x000D2D68 File Offset: 0x000D0F68
	private void method_4()
	{
		List<string> list = new List<string>();
		try
		{
			ManagementObjectCollection managementObjectCollection;
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(GClass107.smethod_3(140448)))
			{
				managementObjectCollection = managementObjectSearcher.Get();
			}
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator())
			{
				IL_129:
				while (enumerator.MoveNext())
				{
					ManagementBaseObject managementBaseObject = enumerator.Current;
					string text = (string)managementBaseObject.GetPropertyValue(GClass107.smethod_3(140453));
					string text2 = text.Substring(text.LastIndexOf(GClass107.smethod_3(140497))).Replace("(", string.Empty).Replace(")", string.Empty);
					for (int i = 250; i > 0; i--)
					{
						if (text2.Contains("COM" + i.ToString()))
						{
							text2 = "COM" + i.ToString() + ((i > 99) ? " " : ((i > 9) ? "  " : "   "));
							IL_F4:
							list.Add(text2 + "(" + text.Substring(0, text.LastIndexOf(GClass107.smethod_3(140527))).Trim() + ")");
							goto IL_129;
						}
					}
					goto IL_F4;
				}
			}
			managementObjectCollection.Dispose();
		}
		catch (Exception)
		{
		}
		List<string> list2 = new List<string>();
		string[] portNames = SerialPort.GetPortNames();
		int j = 250;
		IL_222:
		while (j > 0)
		{
			bool flag = false;
			for (int k = 0; k < list.Count; k++)
			{
				if (list[k].StartsWith("COM" + j.ToString() + " "))
				{
					list2.Add(list[k]);
					list[k] = "";
					flag = true;
					IL_1C4:
					for (int l = 0; l < portNames.Length; l++)
					{
						if (portNames[l].StartsWith("COM" + j.ToString()))
						{
							if (!flag)
							{
								list2.Add("COM" + j.ToString() + "   ");
							}
							portNames[l] = "";
							IL_21C:
							j--;
							goto IL_222;
						}
					}
					goto IL_21C;
				}
			}
			goto IL_1C4;
		}
		int num = 20;
		while (!this.bool_0 && num > 0)
		{
			num--;
			Thread.Sleep(100);
		}
		if (this.bool_0)
		{
			base.Invoke(new GForm13.Delegate16(this.method_5), new object[]
			{
				list2
			});
		}
	}

	// Token: 0x060005E3 RID: 1507 RVA: 0x000D3030 File Offset: 0x000D1230
	private void method_5(List<string> list_0)
	{
		bool flag = this.method_0((string)this.comboBox_6.SelectedItem);
		bool flag2 = this.method_0((string)this.comboBox_9.SelectedItem);
		string text = GClass127.smethod_1(this.comboBox_5.SelectedItem, GClass125.smethod_40(0) + "    ").Substring(0, 6);
		string text2 = GClass127.smethod_1(this.comboBox_8.SelectedItem, GClass125.smethod_40(1) + "    ").Substring(0, 6);
		this.comboBox_5.Items.Clear();
		this.comboBox_8.Items.Clear();
		if (flag)
		{
			this.comboBox_5.Items.Add(GClass107.smethod_3(140572));
			if (text.StartsWith("BLE"))
			{
				this.comboBox_5.SelectedIndex = 0;
			}
		}
		if (flag2)
		{
			this.comboBox_8.Items.Add(GClass107.smethod_3(140596));
			if (text2.StartsWith("BLE"))
			{
				this.comboBox_8.SelectedIndex = 0;
			}
		}
		for (int i = list_0.Count - 1; i >= 0; i--)
		{
			this.comboBox_5.Items.Add(list_0[i]);
			this.comboBox_8.Items.Add(list_0[i]);
			if (list_0[i].StartsWith(text))
			{
				this.comboBox_5.SelectedIndex = this.comboBox_5.Items.Count - 1;
			}
			if (list_0[i].StartsWith(text2))
			{
				this.comboBox_8.SelectedIndex = this.comboBox_8.Items.Count - 1;
			}
		}
	}

	// Token: 0x060005E4 RID: 1508 RVA: 0x0000439F File Offset: 0x0000259F
	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		GClass121.smethod_0(this.comboBox_0.SelectedItem.ToString());
		this.method_2();
	}

	// Token: 0x060005E5 RID: 1509 RVA: 0x000D31E8 File Offset: 0x000D13E8
	private void button_6_Click(object sender, EventArgs e)
	{
		this.fontDialog_0.Font = this.label_17.Font;
		this.fontDialog_0.ShowColor = false;
		if (this.fontDialog_0.ShowDialog() == DialogResult.OK)
		{
			this.label_17.Text = GClass127.smethod_49(this.fontDialog_0.Font);
			this.label_17.Font = this.fontDialog_0.Font;
		}
	}

	// Token: 0x060005E6 RID: 1510 RVA: 0x000D3258 File Offset: 0x000D1458
	private void panel_7_Click(object sender, EventArgs e)
	{
		this.colorDialog_0.Color = ((Panel)sender).BackColor;
		if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
		{
			((Panel)sender).BackColor = this.colorDialog_0.Color;
			this.label_9.BackColor = this.panel_9.BackColor;
		}
	}

	// Token: 0x060005E7 RID: 1511 RVA: 0x000D32B8 File Offset: 0x000D14B8
	private void textBox_3_Validating(object sender, CancelEventArgs e)
	{
		string text = ((TextBox)sender).Text;
		try
		{
			string[] array = text.Split(new char[]
			{
				':'
			});
			string[] array2 = array[0].Split(new char[]
			{
				'.'
			});
			if (array.Length == 2 && array2.Length == 4)
			{
				int num = Convert.ToInt32(array2[0]);
				int num2 = Convert.ToInt32(array2[1]);
				int num3 = Convert.ToInt32(array2[2]);
				int num4 = Convert.ToInt32(array2[3]);
				int num5 = Convert.ToInt32(array[1]);
				if (num >= 0 && num <= 255 && num2 >= 0 && num2 <= 255 && num3 >= 0 && num3 <= 255 && num4 >= 0 && num4 <= 255 && num5 >= 0 && num5 <= 65535)
				{
					return;
				}
			}
		}
		catch (Exception)
		{
		}
		e.Cancel = true;
		SystemSounds.Beep.Play();
		((TextBox)sender).SelectAll();
	}

	// Token: 0x060005E8 RID: 1512 RVA: 0x000043BC File Offset: 0x000025BC
	private void GForm13_Shown(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	// Token: 0x060005EA RID: 1514 RVA: 0x000D33AC File Offset: 0x000D15AC
	private void method_6()
	{
		this.icontainer_0 = new Container();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.label_1 = new Label();
		this.comboBox_1 = new ComboBox();
		this.label_0 = new Label();
		this.comboBox_0 = new ComboBox();
		this.tabControl_0 = new TabControl();
		this.tabPage_0 = new TabPage();
		this.groupBox_3 = new GroupBox();
		this.comboBox_3 = new ComboBox();
		this.textBox_0 = new TextBox();
		this.label_13 = new Label();
		this.label_14 = new Label();
		this.label_12 = new Label();
		this.textBox_1 = new TextBox();
		this.groupBox_2 = new GroupBox();
		this.button_10 = new Button();
		this.comboBox_11 = new ComboBox();
		this.label_24 = new Label();
		this.checkBox_1 = new CheckBox();
		this.button_5 = new Button();
		this.label_15 = new Label();
		this.label_16 = new Label();
		this.button_6 = new Button();
		this.label_18 = new Label();
		this.label_17 = new Label();
		this.tabPage_2 = new TabPage();
		this.groupBox_4 = new GroupBox();
		this.checkBox_2 = new CheckBox();
		this.comboBox_4 = new ComboBox();
		this.label_19 = new Label();
		this.button_9 = new Button();
		this.groupBox_1 = new GroupBox();
		this.label_25 = new Label();
		this.textBox_2 = new TextBox();
		this.button_8 = new Button();
		this.label_22 = new Label();
		this.comboBox_8 = new ComboBox();
		this.label_23 = new Label();
		this.comboBox_9 = new ComboBox();
		this.comboBox_10 = new ComboBox();
		this.groupBox_0 = new GroupBox();
		this.label_26 = new Label();
		this.textBox_3 = new TextBox();
		this.button_7 = new Button();
		this.label_20 = new Label();
		this.comboBox_5 = new ComboBox();
		this.label_21 = new Label();
		this.comboBox_6 = new ComboBox();
		this.comboBox_7 = new ComboBox();
		this.checkBox_0 = new CheckBox();
		this.tabPage_1 = new TabPage();
		this.panel_10 = new Panel();
		this.comboBox_2 = new ComboBox();
		this.panel_11 = new Panel();
		this.label_6 = new Label();
		this.panel_12 = new Panel();
		this.button_2 = new Button();
		this.panel_13 = new Panel();
		this.label_7 = new Label();
		this.panel_14 = new Panel();
		this.label_8 = new Label();
		this.panel_15 = new Panel();
		this.button_3 = new Button();
		this.panel_16 = new Panel();
		this.label_9 = new Label();
		this.panel_17 = new Panel();
		this.label_10 = new Label();
		this.button_4 = new Button();
		this.label_11 = new Label();
		this.label_5 = new Label();
		this.label_3 = new Label();
		this.panel_8 = new Panel();
		this.label_4 = new Label();
		this.panel_9 = new Panel();
		this.panel_0 = new Panel();
		this.panel_1 = new Panel();
		this.panel_2 = new Panel();
		this.panel_3 = new Panel();
		this.panel_4 = new Panel();
		this.panel_5 = new Panel();
		this.panel_6 = new Panel();
		this.panel_7 = new Panel();
		this.label_2 = new Label();
		this.tabPage_3 = new TabPage();
		this.groupBox_7 = new GroupBox();
		this.radioButton_4 = new RadioButton();
		this.radioButton_5 = new RadioButton();
		this.groupBox_8 = new GroupBox();
		this.radioButton_6 = new RadioButton();
		this.radioButton_7 = new RadioButton();
		this.groupBox_9 = new GroupBox();
		this.radioButton_8 = new RadioButton();
		this.radioButton_9 = new RadioButton();
		this.groupBox_6 = new GroupBox();
		this.radioButton_2 = new RadioButton();
		this.radioButton_3 = new RadioButton();
		this.groupBox_5 = new GroupBox();
		this.radioButton_0 = new RadioButton();
		this.radioButton_1 = new RadioButton();
		this.fontDialog_0 = new FontDialog();
		this.colorDialog_0 = new ColorDialog();
		this.toolTip_0 = new ToolTip(this.icontainer_0);
		this.tabControl_0.SuspendLayout();
		this.tabPage_0.SuspendLayout();
		this.groupBox_3.SuspendLayout();
		this.groupBox_2.SuspendLayout();
		this.tabPage_2.SuspendLayout();
		this.groupBox_4.SuspendLayout();
		this.groupBox_1.SuspendLayout();
		this.groupBox_0.SuspendLayout();
		this.tabPage_1.SuspendLayout();
		this.tabPage_3.SuspendLayout();
		this.groupBox_7.SuspendLayout();
		this.groupBox_8.SuspendLayout();
		this.groupBox_9.SuspendLayout();
		this.groupBox_6.SuspendLayout();
		this.groupBox_5.SuspendLayout();
		base.SuspendLayout();
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(603, 598);
		this.button_0.Margin = new Padding(3, 4, 3, 4);
		this.button_0.Name = GClass107.smethod_3(142192);
		this.button_0.Size = new Size(119, 34);
		this.button_0.TabIndex = 1;
		this.button_0.Tag = "8199";
		this.button_0.Text = "OK";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(477, 598);
		this.button_1.Margin = new Padding(3, 4, 3, 4);
		this.button_1.Name = GClass107.smethod_3(142227);
		this.button_1.Size = new Size(119, 34);
		this.button_1.TabIndex = 2;
		this.button_1.Tag = "8198";
		this.button_1.Text = GClass107.smethod_3(142236);
		this.button_1.UseVisualStyleBackColor = true;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(17, 78);
		this.label_1.Name = GClass107.smethod_3(142258);
		this.label_1.Size = new Size(111, 20);
		this.label_1.TabIndex = 12;
		this.label_1.Tag = "8105";
		this.label_1.Text = GClass107.smethod_3(142259);
		this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Items.AddRange(new object[]
		{
			GClass107.smethod_3(142299)
		});
		this.comboBox_1.Location = new Point(174, 74);
		this.comboBox_1.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_1.Name = GClass107.smethod_3(142305);
		this.comboBox_1.Size = new Size(494, 28);
		this.comboBox_1.TabIndex = 1;
		this.comboBox_1.Tag = "8105";
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(17, 40);
		this.label_0.Name = GClass107.smethod_3(142328);
		this.label_0.Size = new Size(93, 20);
		this.label_0.TabIndex = 10;
		this.label_0.Tag = "8104";
		this.label_0.Text = GClass107.smethod_3(142343);
		this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Items.AddRange(new object[]
		{
			GClass107.smethod_3(142392)
		});
		this.comboBox_0.Location = new Point(174, 36);
		this.comboBox_0.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_0.Name = GClass107.smethod_3(142438);
		this.comboBox_0.Size = new Size(494, 28);
		this.comboBox_0.TabIndex = 0;
		this.comboBox_0.Tag = "8104";
		this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
		this.tabControl_0.Controls.Add(this.tabPage_0);
		this.tabControl_0.Controls.Add(this.tabPage_2);
		this.tabControl_0.Controls.Add(this.tabPage_1);
		this.tabControl_0.Controls.Add(this.tabPage_3);
		this.tabControl_0.Location = new Point(14, 15);
		this.tabControl_0.Margin = new Padding(3, 4, 3, 4);
		this.tabControl_0.Name = GClass107.smethod_3(142446);
		this.tabControl_0.SelectedIndex = 0;
		this.tabControl_0.Size = new Size(712, 575);
		this.tabControl_0.TabIndex = 0;
		this.tabPage_0.Controls.Add(this.groupBox_3);
		this.tabPage_0.Controls.Add(this.groupBox_2);
		this.tabPage_0.Location = new Point(4, 29);
		this.tabPage_0.Margin = new Padding(3, 4, 3, 4);
		this.tabPage_0.Name = GClass107.smethod_3(142468);
		this.tabPage_0.Padding = new Padding(3, 4, 3, 4);
		this.tabPage_0.Size = new Size(704, 542);
		this.tabPage_0.TabIndex = 0;
		this.tabPage_0.Text = GClass107.smethod_3(142485);
		this.tabPage_0.UseVisualStyleBackColor = true;
		this.groupBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_3.Controls.Add(this.comboBox_3);
		this.groupBox_3.Controls.Add(this.textBox_0);
		this.groupBox_3.Controls.Add(this.label_13);
		this.groupBox_3.Controls.Add(this.label_14);
		this.groupBox_3.Controls.Add(this.label_12);
		this.groupBox_3.Controls.Add(this.textBox_1);
		this.groupBox_3.Location = new Point(7, 384);
		this.groupBox_3.Margin = new Padding(3, 4, 3, 4);
		this.groupBox_3.Name = GClass107.smethod_3(142498);
		this.groupBox_3.Padding = new Padding(3, 4, 3, 4);
		this.groupBox_3.Size = new Size(690, 147);
		this.groupBox_3.TabIndex = 44;
		this.groupBox_3.TabStop = false;
		this.groupBox_3.Tag = "8129";
		this.groupBox_3.Text = GClass107.smethod_3(142530);
		this.comboBox_3.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_3.FormattingEnabled = true;
		this.comboBox_3.Items.AddRange(new object[]
		{
			"Tab",
			";",
			","
		});
		this.comboBox_3.Location = new Point(173, 32);
		this.comboBox_3.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_3.Name = GClass107.smethod_3(142532);
		this.comboBox_3.Size = new Size(122, 28);
		this.comboBox_3.TabIndex = 0;
		this.comboBox_3.Tag = "8106";
		this.textBox_0.Location = new Point(173, 67);
		this.textBox_0.Margin = new Padding(3, 4, 3, 4);
		this.textBox_0.Name = GClass107.smethod_3(142551);
		this.textBox_0.Size = new Size(495, 26);
		this.textBox_0.TabIndex = 1;
		this.textBox_0.Tag = "8107";
		this.label_13.AutoSize = true;
		this.label_13.Location = new Point(16, 35);
		this.label_13.Name = GClass107.smethod_3(142565);
		this.label_13.Size = new Size(117, 20);
		this.label_13.TabIndex = 16;
		this.label_13.Tag = "8106";
		this.label_13.Text = GClass107.smethod_3(142601);
		this.label_14.AutoSize = true;
		this.label_14.Location = new Point(16, 105);
		this.label_14.Name = GClass107.smethod_3(142616);
		this.label_14.Size = new Size(92, 20);
		this.label_14.TabIndex = 19;
		this.label_14.Tag = "8108";
		this.label_14.Text = GClass107.smethod_3(142637);
		this.label_12.AutoSize = true;
		this.label_12.Location = new Point(16, 71);
		this.label_12.Name = GClass107.smethod_3(142645);
		this.label_12.Size = new Size(91, 20);
		this.label_12.TabIndex = 17;
		this.label_12.Tag = "8107";
		this.label_12.Text = GClass107.smethod_3(142659);
		this.textBox_1.Location = new Point(173, 102);
		this.textBox_1.Margin = new Padding(3, 4, 3, 4);
		this.textBox_1.Name = GClass107.smethod_3(142670);
		this.textBox_1.Size = new Size(495, 26);
		this.textBox_1.TabIndex = 2;
		this.textBox_1.Tag = "8108";
		this.groupBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_2.Controls.Add(this.button_10);
		this.groupBox_2.Controls.Add(this.comboBox_11);
		this.groupBox_2.Controls.Add(this.label_24);
		this.groupBox_2.Controls.Add(this.checkBox_1);
		this.groupBox_2.Controls.Add(this.comboBox_0);
		this.groupBox_2.Controls.Add(this.button_5);
		this.groupBox_2.Controls.Add(this.label_0);
		this.groupBox_2.Controls.Add(this.label_15);
		this.groupBox_2.Controls.Add(this.comboBox_1);
		this.groupBox_2.Controls.Add(this.label_16);
		this.groupBox_2.Controls.Add(this.label_1);
		this.groupBox_2.Controls.Add(this.button_6);
		this.groupBox_2.Controls.Add(this.label_18);
		this.groupBox_2.Controls.Add(this.label_17);
		this.groupBox_2.Location = new Point(7, 6);
		this.groupBox_2.Margin = new Padding(3, 4, 3, 4);
		this.groupBox_2.Name = GClass107.smethod_3(142695);
		this.groupBox_2.Padding = new Padding(3, 4, 3, 4);
		this.groupBox_2.Size = new Size(690, 369);
		this.groupBox_2.TabIndex = 43;
		this.groupBox_2.TabStop = false;
		this.groupBox_2.Tag = "8128";
		this.groupBox_2.Text = GClass107.smethod_3(142743);
		this.button_10.Location = new Point(20, 328);
		this.button_10.Margin = new Padding(3, 4, 3, 4);
		this.button_10.Name = GClass107.smethod_3(142760);
		this.button_10.Size = new Size(648, 34);
		this.button_10.TabIndex = 31;
		this.button_10.Tag = "8134";
		this.button_10.Text = GClass107.smethod_3(142773);
		this.button_10.UseVisualStyleBackColor = true;
		this.button_10.Click += this.button_10_Click;
		this.comboBox_11.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_11.FormattingEnabled = true;
		this.comboBox_11.Items.AddRange(new object[]
		{
			GClass107.smethod_3(142791),
			GClass107.smethod_3(142825),
			GClass107.smethod_3(142848)
		});
		this.comboBox_11.Location = new Point(174, 222);
		this.comboBox_11.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_11.Name = GClass107.smethod_3(142895);
		this.comboBox_11.Size = new Size(235, 28);
		this.comboBox_11.TabIndex = 29;
		this.comboBox_11.Tag = "8132";
		this.label_24.AutoSize = true;
		this.label_24.Location = new Point(17, 226);
		this.label_24.Name = GClass107.smethod_3(142933);
		this.label_24.Size = new Size(113, 20);
		this.label_24.TabIndex = 30;
		this.label_24.Tag = "8132";
		this.label_24.Text = GClass107.smethod_3(142971);
		this.checkBox_1.AutoSize = true;
		this.checkBox_1.Location = new Point(20, 266);
		this.checkBox_1.Margin = new Padding(3, 4, 3, 4);
		this.checkBox_1.Name = GClass107.smethod_3(142986);
		this.checkBox_1.Size = new Size(466, 24);
		this.checkBox_1.TabIndex = 27;
		this.checkBox_1.Tag = "8130";
		this.checkBox_1.Text = GClass107.smethod_3(143026);
		this.checkBox_1.UseVisualStyleBackColor = true;
		this.button_5.Location = new Point(548, 168);
		this.button_5.Margin = new Padding(3, 4, 3, 4);
		this.button_5.Name = GClass107.smethod_3(143031);
		this.button_5.Size = new Size(120, 34);
		this.button_5.TabIndex = 3;
		this.button_5.Tag = "8118";
		this.button_5.Text = GClass107.smethod_3(143038);
		this.button_5.UseVisualStyleBackColor = true;
		this.button_5.Click += this.button_5_Click;
		this.label_15.AutoSize = true;
		this.label_15.Location = new Point(170, 175);
		this.label_15.Name = GClass107.smethod_3(143087);
		this.label_15.Size = new Size(71, 20);
		this.label_15.TabIndex = 26;
		this.label_15.Text = GClass107.smethod_3(143094);
		this.label_16.AutoSize = true;
		this.label_16.Location = new Point(17, 174);
		this.label_16.Name = GClass107.smethod_3(143099);
		this.label_16.Size = new Size(76, 20);
		this.label_16.TabIndex = 25;
		this.label_16.Tag = "8120";
		this.label_16.Text = GClass107.smethod_3(143104);
		this.button_6.Location = new Point(548, 119);
		this.button_6.Margin = new Padding(3, 4, 3, 4);
		this.button_6.Name = GClass107.smethod_3(143125);
		this.button_6.Size = new Size(120, 34);
		this.button_6.TabIndex = 2;
		this.button_6.Tag = "8118";
		this.button_6.Text = GClass107.smethod_3(143158);
		this.button_6.UseVisualStyleBackColor = true;
		this.button_6.Click += this.button_6_Click;
		this.label_18.AutoSize = true;
		this.label_18.Location = new Point(17, 125);
		this.label_18.Name = GClass107.smethod_3(143200);
		this.label_18.Size = new Size(76, 20);
		this.label_18.TabIndex = 23;
		this.label_18.Tag = "8119";
		this.label_18.Text = GClass107.smethod_3(143212);
		this.label_17.AutoSize = true;
		this.label_17.Location = new Point(170, 126);
		this.label_17.Name = GClass107.smethod_3(143226);
		this.label_17.Size = new Size(71, 20);
		this.label_17.TabIndex = 24;
		this.label_17.Text = GClass107.smethod_3(143261);
		this.tabPage_2.Controls.Add(this.groupBox_4);
		this.tabPage_2.Controls.Add(this.button_9);
		this.tabPage_2.Controls.Add(this.groupBox_1);
		this.tabPage_2.Controls.Add(this.groupBox_0);
		this.tabPage_2.Controls.Add(this.checkBox_0);
		this.tabPage_2.Location = new Point(4, 29);
		this.tabPage_2.Margin = new Padding(3, 4, 3, 4);
		this.tabPage_2.Name = GClass107.smethod_3(143283);
		this.tabPage_2.Padding = new Padding(3, 4, 3, 4);
		this.tabPage_2.Size = new Size(704, 542);
		this.tabPage_2.TabIndex = 2;
		this.tabPage_2.Text = GClass107.smethod_3(143325);
		this.tabPage_2.UseVisualStyleBackColor = true;
		this.groupBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_4.Controls.Add(this.checkBox_2);
		this.groupBox_4.Controls.Add(this.comboBox_4);
		this.groupBox_4.Controls.Add(this.label_19);
		this.groupBox_4.Location = new Point(7, 267);
		this.groupBox_4.Margin = new Padding(3, 4, 3, 4);
		this.groupBox_4.Name = GClass107.smethod_3(143336);
		this.groupBox_4.Padding = new Padding(3, 4, 3, 4);
		this.groupBox_4.Size = new Size(690, 62);
		this.groupBox_4.TabIndex = 45;
		this.groupBox_4.TabStop = false;
		this.groupBox_4.Tag = "";
		this.groupBox_4.Text = GClass107.smethod_3(143368);
		this.checkBox_2.AutoSize = true;
		this.checkBox_2.Location = new Point(479, 26);
		this.checkBox_2.Margin = new Padding(3, 4, 3, 4);
		this.checkBox_2.Name = GClass107.smethod_3(143405);
		this.checkBox_2.Size = new Size(166, 24);
		this.checkBox_2.TabIndex = 40;
		this.checkBox_2.Tag = "8133";
		this.checkBox_2.Text = GClass107.smethod_3(143446);
		this.checkBox_2.UseVisualStyleBackColor = true;
		this.comboBox_4.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_4.FormattingEnabled = true;
		this.comboBox_4.Items.AddRange(new object[]
		{
			GClass107.smethod_3(143465),
			GClass107.smethod_3(143493),
			GClass107.smethod_3(143538),
			GClass107.smethod_3(143550)
		});
		this.comboBox_4.Location = new Point(176, 24);
		this.comboBox_4.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_4.Name = GClass107.smethod_3(143576);
		this.comboBox_4.Size = new Size(252, 28);
		this.comboBox_4.TabIndex = 0;
		this.comboBox_4.Tag = "8122";
		this.label_19.AutoSize = true;
		this.label_19.Location = new Point(18, 28);
		this.label_19.Name = GClass107.smethod_3(143617);
		this.label_19.Size = new Size(138, 20);
		this.label_19.TabIndex = 39;
		this.label_19.Tag = "8122";
		this.label_19.Text = GClass107.smethod_3(143655);
		this.button_9.Location = new Point(362, 501);
		this.button_9.Margin = new Padding(3, 4, 3, 4);
		this.button_9.Name = GClass107.smethod_3(143666);
		this.button_9.Size = new Size(335, 34);
		this.button_9.TabIndex = 1;
		this.button_9.Tag = "8127";
		this.button_9.Text = GClass107.smethod_3(143713);
		this.button_9.UseVisualStyleBackColor = true;
		this.button_9.Click += this.button_9_Click;
		this.groupBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_1.Controls.Add(this.label_25);
		this.groupBox_1.Controls.Add(this.textBox_2);
		this.groupBox_1.Controls.Add(this.button_8);
		this.groupBox_1.Controls.Add(this.label_22);
		this.groupBox_1.Controls.Add(this.comboBox_8);
		this.groupBox_1.Controls.Add(this.label_23);
		this.groupBox_1.Controls.Add(this.comboBox_9);
		this.groupBox_1.Controls.Add(this.comboBox_10);
		this.groupBox_1.Location = new Point(7, 123);
		this.groupBox_1.Margin = new Padding(3, 4, 3, 4);
		this.groupBox_1.Name = GClass107.smethod_3(143729);
		this.groupBox_1.Padding = new Padding(3, 4, 3, 4);
		this.groupBox_1.Size = new Size(690, 100);
		this.groupBox_1.TabIndex = 43;
		this.groupBox_1.TabStop = false;
		this.groupBox_1.Tag = "8124";
		this.groupBox_1.Text = GClass107.smethod_3(143753);
		this.label_25.AutoSize = true;
		this.label_25.Location = new Point(18, 64);
		this.label_25.Name = GClass107.smethod_3(143763);
		this.label_25.Size = new Size(87, 20);
		this.label_25.TabIndex = 47;
		this.label_25.Tag = "8110";
		this.label_25.Text = GClass107.smethod_3(143797);
		this.textBox_2.Location = new Point(176, 60);
		this.textBox_2.Margin = new Padding(3, 4, 3, 4);
		this.textBox_2.Name = GClass107.smethod_3(143825);
		this.textBox_2.Size = new Size(380, 26);
		this.textBox_2.TabIndex = 46;
		this.textBox_2.Tag = "8110";
		this.textBox_2.Validating += this.textBox_3_Validating;
		this.button_8.Location = new Point(575, 22);
		this.button_8.Margin = new Padding(3, 4, 3, 4);
		this.button_8.Name = GClass107.smethod_3(143873);
		this.button_8.Size = new Size(96, 34);
		this.button_8.TabIndex = 2;
		this.button_8.Tag = "8197";
		this.button_8.Text = GClass107.smethod_3(143915);
		this.button_8.UseVisualStyleBackColor = true;
		this.button_8.Click += this.button_8_Click;
		this.label_22.AutoSize = true;
		this.label_22.Location = new Point(18, 29);
		this.label_22.Name = GClass107.smethod_3(143962);
		this.label_22.Size = new Size(107, 20);
		this.label_22.TabIndex = 41;
		this.label_22.Tag = "8101";
		this.label_22.Text = GClass107.smethod_3(143975);
		this.comboBox_8.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_8.FormattingEnabled = true;
		this.comboBox_8.Location = new Point(176, 60);
		this.comboBox_8.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_8.Name = GClass107.smethod_3(143989);
		this.comboBox_8.Size = new Size(380, 28);
		this.comboBox_8.TabIndex = 1;
		this.comboBox_8.Tag = "8102";
		this.label_23.AutoSize = true;
		this.label_23.Location = new Point(18, 64);
		this.label_23.Name = GClass107.smethod_3(144019);
		this.label_23.Size = new Size(81, 20);
		this.label_23.TabIndex = 40;
		this.label_23.Tag = "8102";
		this.label_23.Text = GClass107.smethod_3(144029);
		this.comboBox_9.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_9.FormattingEnabled = true;
		this.comboBox_9.Items.AddRange(new object[]
		{
			GClass107.smethod_3(144045),
			GClass107.smethod_3(144081),
			GClass107.smethod_3(144111),
			GClass107.smethod_3(144129),
			GClass107.smethod_3(144143),
			GClass107.smethod_3(144177),
			GClass107.smethod_3(144208),
			GClass107.smethod_3(144248)
		});
		this.comboBox_9.Location = new Point(176, 25);
		this.comboBox_9.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_9.Name = GClass107.smethod_3(144273);
		this.comboBox_9.Size = new Size(380, 28);
		this.comboBox_9.TabIndex = 0;
		this.comboBox_9.Tag = "8101";
		this.comboBox_9.SelectedIndexChanged += this.comboBox_6_SelectedIndexChanged;
		this.comboBox_10.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_10.FormattingEnabled = true;
		this.comboBox_10.Items.AddRange(new object[]
		{
			"9600",
			"19200",
			"38400",
			"57600",
			"115200",
			"128000",
			"256000"
		});
		this.comboBox_10.Location = new Point(575, 60);
		this.comboBox_10.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_10.Name = GClass107.smethod_3(144297);
		this.comboBox_10.Size = new Size(95, 28);
		this.comboBox_10.TabIndex = 3;
		this.comboBox_10.Tag = "8103";
		this.groupBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_0.Controls.Add(this.label_26);
		this.groupBox_0.Controls.Add(this.textBox_3);
		this.groupBox_0.Controls.Add(this.button_7);
		this.groupBox_0.Controls.Add(this.label_20);
		this.groupBox_0.Controls.Add(this.comboBox_5);
		this.groupBox_0.Controls.Add(this.label_21);
		this.groupBox_0.Controls.Add(this.comboBox_6);
		this.groupBox_0.Controls.Add(this.comboBox_7);
		this.groupBox_0.Location = new Point(7, 17);
		this.groupBox_0.Margin = new Padding(3, 4, 3, 4);
		this.groupBox_0.Name = GClass107.smethod_3(144337);
		this.groupBox_0.Padding = new Padding(3, 4, 3, 4);
		this.groupBox_0.Size = new Size(690, 100);
		this.groupBox_0.TabIndex = 42;
		this.groupBox_0.TabStop = false;
		this.groupBox_0.Tag = "8123";
		this.groupBox_0.Text = GClass107.smethod_3(144348);
		this.label_26.AutoSize = true;
		this.label_26.Location = new Point(18, 64);
		this.label_26.Name = GClass107.smethod_3(144395);
		this.label_26.Size = new Size(87, 20);
		this.label_26.TabIndex = 46;
		this.label_26.Tag = "8110";
		this.label_26.Text = GClass107.smethod_3(144414);
		this.textBox_3.Location = new Point(176, 60);
		this.textBox_3.Margin = new Padding(3, 4, 3, 4);
		this.textBox_3.Name = GClass107.smethod_3(144450);
		this.textBox_3.Size = new Size(380, 26);
		this.textBox_3.TabIndex = 45;
		this.textBox_3.Tag = "8110";
		this.textBox_3.Validating += this.textBox_3_Validating;
		this.button_7.Location = new Point(575, 22);
		this.button_7.Margin = new Padding(3, 4, 3, 4);
		this.button_7.Name = GClass107.smethod_3(144495);
		this.button_7.Size = new Size(96, 34);
		this.button_7.TabIndex = 2;
		this.button_7.Tag = "8197";
		this.button_7.Text = GClass107.smethod_3(144537);
		this.button_7.UseVisualStyleBackColor = true;
		this.button_7.Click += this.button_7_Click;
		this.label_20.AutoSize = true;
		this.label_20.Location = new Point(18, 29);
		this.label_20.Name = GClass107.smethod_3(144568);
		this.label_20.Size = new Size(107, 20);
		this.label_20.TabIndex = 41;
		this.label_20.Tag = "8101";
		this.label_20.Text = GClass107.smethod_3(144577);
		this.comboBox_5.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_5.FormattingEnabled = true;
		this.comboBox_5.Location = new Point(176, 60);
		this.comboBox_5.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_5.Name = GClass107.smethod_3(144596);
		this.comboBox_5.Size = new Size(380, 28);
		this.comboBox_5.TabIndex = 1;
		this.comboBox_5.Tag = "8102";
		this.label_21.AutoSize = true;
		this.label_21.Location = new Point(18, 64);
		this.label_21.Name = GClass107.smethod_3(144640);
		this.label_21.Size = new Size(81, 20);
		this.label_21.TabIndex = 40;
		this.label_21.Tag = "8102";
		this.label_21.Text = GClass107.smethod_3(144647);
		this.comboBox_6.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_6.FormattingEnabled = true;
		this.comboBox_6.Items.AddRange(new object[]
		{
			GClass107.smethod_3(144653),
			GClass107.smethod_3(144663),
			GClass107.smethod_3(144695),
			GClass107.smethod_3(144722),
			GClass107.smethod_3(144757),
			GClass107.smethod_3(144794),
			GClass107.smethod_3(144824),
			GClass107.smethod_3(144868)
		});
		this.comboBox_6.Location = new Point(176, 25);
		this.comboBox_6.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_6.Name = GClass107.smethod_3(144916);
		this.comboBox_6.Size = new Size(380, 28);
		this.comboBox_6.TabIndex = 0;
		this.comboBox_6.Tag = "8101";
		this.comboBox_6.SelectedIndexChanged += this.comboBox_6_SelectedIndexChanged;
		this.comboBox_7.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_7.FormattingEnabled = true;
		this.comboBox_7.Items.AddRange(new object[]
		{
			"9600",
			"19200",
			"38400",
			"57600",
			"115200",
			"128000",
			"256000"
		});
		this.comboBox_7.Location = new Point(575, 60);
		this.comboBox_7.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_7.Name = GClass107.smethod_3(144935);
		this.comboBox_7.Size = new Size(95, 28);
		this.comboBox_7.TabIndex = 3;
		this.comboBox_7.Tag = "8103";
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Location = new Point(7, 231);
		this.checkBox_0.Margin = new Padding(3, 4, 3, 4);
		this.checkBox_0.Name = GClass107.smethod_3(144942);
		this.checkBox_0.Size = new Size(212, 24);
		this.checkBox_0.TabIndex = 0;
		this.checkBox_0.Tag = "8121";
		this.checkBox_0.Text = GClass107.smethod_3(144973);
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
		this.tabPage_1.Controls.Add(this.panel_10);
		this.tabPage_1.Controls.Add(this.comboBox_2);
		this.tabPage_1.Controls.Add(this.panel_11);
		this.tabPage_1.Controls.Add(this.label_6);
		this.tabPage_1.Controls.Add(this.panel_12);
		this.tabPage_1.Controls.Add(this.button_2);
		this.tabPage_1.Controls.Add(this.panel_13);
		this.tabPage_1.Controls.Add(this.label_7);
		this.tabPage_1.Controls.Add(this.panel_14);
		this.tabPage_1.Controls.Add(this.label_8);
		this.tabPage_1.Controls.Add(this.panel_15);
		this.tabPage_1.Controls.Add(this.button_3);
		this.tabPage_1.Controls.Add(this.panel_16);
		this.tabPage_1.Controls.Add(this.label_9);
		this.tabPage_1.Controls.Add(this.panel_17);
		this.tabPage_1.Controls.Add(this.label_10);
		this.tabPage_1.Controls.Add(this.button_4);
		this.tabPage_1.Controls.Add(this.label_11);
		this.tabPage_1.Controls.Add(this.label_5);
		this.tabPage_1.Controls.Add(this.label_3);
		this.tabPage_1.Controls.Add(this.panel_8);
		this.tabPage_1.Controls.Add(this.label_4);
		this.tabPage_1.Controls.Add(this.panel_9);
		this.tabPage_1.Controls.Add(this.panel_0);
		this.tabPage_1.Controls.Add(this.panel_1);
		this.tabPage_1.Controls.Add(this.panel_2);
		this.tabPage_1.Controls.Add(this.panel_3);
		this.tabPage_1.Controls.Add(this.panel_4);
		this.tabPage_1.Controls.Add(this.panel_5);
		this.tabPage_1.Controls.Add(this.panel_6);
		this.tabPage_1.Controls.Add(this.panel_7);
		this.tabPage_1.Controls.Add(this.label_2);
		this.tabPage_1.Location = new Point(4, 29);
		this.tabPage_1.Margin = new Padding(3, 4, 3, 4);
		this.tabPage_1.Name = GClass107.smethod_3(144977);
		this.tabPage_1.Padding = new Padding(3, 4, 3, 4);
		this.tabPage_1.Size = new Size(704, 542);
		this.tabPage_1.TabIndex = 1;
		this.tabPage_1.Text = GClass107.smethod_3(145019);
		this.tabPage_1.UseVisualStyleBackColor = true;
		this.panel_10.BorderStyle = BorderStyle.FixedSingle;
		this.panel_10.Location = new Point(618, 62);
		this.panel_10.Margin = new Padding(3, 4, 3, 4);
		this.panel_10.Name = GClass107.smethod_3(145034);
		this.panel_10.Size = new Size(46, 30);
		this.panel_10.TabIndex = 8;
		this.panel_10.Click += this.panel_7_Click;
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Items.AddRange(new object[]
		{
			"1",
			"2",
			"3",
			"4"
		});
		this.comboBox_2.Location = new Point(254, 306);
		this.comboBox_2.Margin = new Padding(3, 4, 3, 4);
		this.comboBox_2.Name = GClass107.smethod_3(145077);
		this.comboBox_2.Size = new Size(96, 28);
		this.comboBox_2.TabIndex = 3;
		this.panel_11.BorderStyle = BorderStyle.FixedSingle;
		this.panel_11.Location = new Point(566, 62);
		this.panel_11.Margin = new Padding(3, 4, 3, 4);
		this.panel_11.Name = GClass107.smethod_3(145089);
		this.panel_11.Size = new Size(46, 30);
		this.panel_11.TabIndex = 10;
		this.panel_11.Click += this.panel_7_Click;
		this.label_6.AutoSize = true;
		this.label_6.Location = new Point(22, 310);
		this.label_6.Name = GClass107.smethod_3(145097);
		this.label_6.Size = new Size(114, 20);
		this.label_6.TabIndex = 17;
		this.label_6.Tag = "8117";
		this.label_6.Text = GClass107.smethod_3(145104);
		this.panel_12.BorderStyle = BorderStyle.FixedSingle;
		this.panel_12.Location = new Point(514, 62);
		this.panel_12.Margin = new Padding(3, 4, 3, 4);
		this.panel_12.Name = GClass107.smethod_3(145124);
		this.panel_12.Size = new Size(46, 30);
		this.panel_12.TabIndex = 11;
		this.panel_12.Click += this.panel_7_Click;
		this.button_2.Location = new Point(544, 259);
		this.button_2.Margin = new Padding(3, 4, 3, 4);
		this.button_2.Name = GClass107.smethod_3(145146);
		this.button_2.Size = new Size(120, 34);
		this.button_2.TabIndex = 2;
		this.button_2.Tag = "8118";
		this.button_2.Text = GClass107.smethod_3(145187);
		this.button_2.UseVisualStyleBackColor = true;
		this.button_2.Click += this.button_2_Click;
		this.panel_13.BorderStyle = BorderStyle.FixedSingle;
		this.panel_13.Location = new Point(462, 62);
		this.panel_13.Margin = new Padding(3, 4, 3, 4);
		this.panel_13.Name = GClass107.smethod_3(145220);
		this.panel_13.Size = new Size(46, 30);
		this.panel_13.TabIndex = 12;
		this.panel_13.Click += this.panel_7_Click;
		this.label_7.AutoSize = true;
		this.label_7.Location = new Point(254, 265);
		this.label_7.Name = GClass107.smethod_3(145269);
		this.label_7.Size = new Size(71, 20);
		this.label_7.TabIndex = 15;
		this.label_7.Text = GClass107.smethod_3(145305);
		this.panel_14.BorderStyle = BorderStyle.FixedSingle;
		this.panel_14.Location = new Point(410, 62);
		this.panel_14.Margin = new Padding(3, 4, 3, 4);
		this.panel_14.Name = GClass107.smethod_3(145314);
		this.panel_14.Size = new Size(46, 30);
		this.panel_14.TabIndex = 9;
		this.panel_14.Click += this.panel_7_Click;
		this.label_8.AutoSize = true;
		this.label_8.Location = new Point(22, 265);
		this.label_8.Name = GClass107.smethod_3(145327);
		this.label_8.Size = new Size(120, 20);
		this.label_8.TabIndex = 14;
		this.label_8.Tag = "8116";
		this.label_8.Text = GClass107.smethod_3(145374);
		this.panel_15.BorderStyle = BorderStyle.FixedSingle;
		this.panel_15.Location = new Point(358, 62);
		this.panel_15.Margin = new Padding(3, 4, 3, 4);
		this.panel_15.Name = GClass107.smethod_3(145379);
		this.panel_15.Size = new Size(46, 30);
		this.panel_15.TabIndex = 6;
		this.panel_15.Click += this.panel_7_Click;
		this.button_3.Location = new Point(544, 218);
		this.button_3.Margin = new Padding(3, 4, 3, 4);
		this.button_3.Name = GClass107.smethod_3(145411);
		this.button_3.Size = new Size(120, 34);
		this.button_3.TabIndex = 1;
		this.button_3.Tag = "8118";
		this.button_3.Text = GClass107.smethod_3(145417);
		this.button_3.UseVisualStyleBackColor = true;
		this.button_3.Click += this.button_3_Click;
		this.panel_16.BorderStyle = BorderStyle.FixedSingle;
		this.panel_16.Location = new Point(306, 62);
		this.panel_16.Margin = new Padding(3, 4, 3, 4);
		this.panel_16.Name = GClass107.smethod_3(145428);
		this.panel_16.Size = new Size(46, 30);
		this.panel_16.TabIndex = 7;
		this.panel_16.Click += this.panel_7_Click;
		this.label_9.AutoSize = true;
		this.label_9.Location = new Point(254, 224);
		this.label_9.Name = GClass107.smethod_3(145444);
		this.label_9.Size = new Size(71, 20);
		this.label_9.TabIndex = 12;
		this.label_9.Text = GClass107.smethod_3(145454);
		this.panel_17.BorderStyle = BorderStyle.FixedSingle;
		this.panel_17.Location = new Point(254, 62);
		this.panel_17.Margin = new Padding(3, 4, 3, 4);
		this.panel_17.Name = GClass107.smethod_3(145484);
		this.panel_17.Size = new Size(46, 30);
		this.panel_17.TabIndex = 5;
		this.panel_17.Click += this.panel_7_Click;
		this.label_10.AutoSize = true;
		this.label_10.Location = new Point(22, 224);
		this.label_10.Name = GClass107.smethod_3(145505);
		this.label_10.Size = new Size(91, 20);
		this.label_10.TabIndex = 11;
		this.label_10.Tag = "8115";
		this.label_10.Text = GClass107.smethod_3(145540);
		this.button_4.Location = new Point(544, 176);
		this.button_4.Margin = new Padding(3, 4, 3, 4);
		this.button_4.Name = GClass107.smethod_3(145576);
		this.button_4.Size = new Size(120, 34);
		this.button_4.TabIndex = 0;
		this.button_4.Tag = "8118";
		this.button_4.Text = GClass107.smethod_3(145624);
		this.button_4.UseVisualStyleBackColor = true;
		this.button_4.Click += this.button_4_Click;
		this.label_11.AutoSize = true;
		this.label_11.Location = new Point(254, 182);
		this.label_11.Name = GClass107.smethod_3(145668);
		this.label_11.Size = new Size(71, 20);
		this.label_11.TabIndex = 9;
		this.label_11.Text = GClass107.smethod_3(145679);
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(22, 182);
		this.label_5.Name = GClass107.smethod_3(145709);
		this.label_5.Size = new Size(91, 20);
		this.label_5.TabIndex = 8;
		this.label_5.Tag = "8114";
		this.label_5.Text = GClass107.smethod_3(145735);
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(22, 144);
		this.label_3.Name = GClass107.smethod_3(145757);
		this.label_3.Size = new Size(80, 20);
		this.label_3.TabIndex = 7;
		this.label_3.Tag = "8113";
		this.label_3.Text = GClass107.smethod_3(145761);
		this.panel_8.BorderStyle = BorderStyle.FixedSingle;
		this.panel_8.Location = new Point(254, 141);
		this.panel_8.Margin = new Padding(3, 4, 3, 4);
		this.panel_8.Name = GClass107.smethod_3(145777);
		this.panel_8.Size = new Size(46, 30);
		this.panel_8.TabIndex = 6;
		this.panel_8.Click += this.panel_7_Click;
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(22, 106);
		this.label_4.Name = GClass107.smethod_3(145793);
		this.label_4.Size = new Size(136, 20);
		this.label_4.TabIndex = 5;
		this.label_4.Tag = "8112";
		this.label_4.Text = GClass107.smethod_3(145837);
		this.panel_9.BorderStyle = BorderStyle.FixedSingle;
		this.panel_9.Location = new Point(254, 104);
		this.panel_9.Margin = new Padding(3, 4, 3, 4);
		this.panel_9.Name = GClass107.smethod_3(145867);
		this.panel_9.Size = new Size(46, 30);
		this.panel_9.TabIndex = 4;
		this.panel_9.Click += this.panel_7_Click;
		this.panel_0.BorderStyle = BorderStyle.FixedSingle;
		this.panel_0.Location = new Point(618, 25);
		this.panel_0.Margin = new Padding(3, 4, 3, 4);
		this.panel_0.Name = GClass107.smethod_3(145916);
		this.panel_0.Size = new Size(46, 30);
		this.panel_0.TabIndex = 4;
		this.panel_0.Click += this.panel_7_Click;
		this.panel_1.BorderStyle = BorderStyle.FixedSingle;
		this.panel_1.Location = new Point(566, 25);
		this.panel_1.Margin = new Padding(3, 4, 3, 4);
		this.panel_1.Name = GClass107.smethod_3(145935);
		this.panel_1.Size = new Size(46, 30);
		this.panel_1.TabIndex = 4;
		this.panel_1.Click += this.panel_7_Click;
		this.panel_2.BorderStyle = BorderStyle.FixedSingle;
		this.panel_2.Location = new Point(514, 25);
		this.panel_2.Margin = new Padding(3, 4, 3, 4);
		this.panel_2.Name = GClass107.smethod_3(145936);
		this.panel_2.Size = new Size(46, 30);
		this.panel_2.TabIndex = 4;
		this.panel_2.Click += this.panel_7_Click;
		this.panel_3.BorderStyle = BorderStyle.FixedSingle;
		this.panel_3.Location = new Point(462, 25);
		this.panel_3.Margin = new Padding(3, 4, 3, 4);
		this.panel_3.Name = GClass107.smethod_3(145949);
		this.panel_3.Size = new Size(46, 30);
		this.panel_3.TabIndex = 4;
		this.panel_3.Click += this.panel_7_Click;
		this.panel_4.BorderStyle = BorderStyle.FixedSingle;
		this.panel_4.Location = new Point(410, 25);
		this.panel_4.Margin = new Padding(3, 4, 3, 4);
		this.panel_4.Name = GClass107.smethod_3(145973);
		this.panel_4.Size = new Size(46, 30);
		this.panel_4.TabIndex = 4;
		this.panel_4.Click += this.panel_7_Click;
		this.panel_5.BorderStyle = BorderStyle.FixedSingle;
		this.panel_5.Location = new Point(358, 25);
		this.panel_5.Margin = new Padding(3, 4, 3, 4);
		this.panel_5.Name = GClass107.smethod_3(146007);
		this.panel_5.Size = new Size(46, 30);
		this.panel_5.TabIndex = 4;
		this.panel_5.Click += this.panel_7_Click;
		this.panel_6.BorderStyle = BorderStyle.FixedSingle;
		this.panel_6.Location = new Point(306, 25);
		this.panel_6.Margin = new Padding(3, 4, 3, 4);
		this.panel_6.Name = GClass107.smethod_3(146021);
		this.panel_6.Size = new Size(46, 30);
		this.panel_6.TabIndex = 4;
		this.panel_6.Click += this.panel_7_Click;
		this.panel_7.BorderStyle = BorderStyle.FixedSingle;
		this.panel_7.Location = new Point(254, 25);
		this.panel_7.Margin = new Padding(3, 4, 3, 4);
		this.panel_7.Name = GClass107.smethod_3(146048);
		this.panel_7.Size = new Size(46, 30);
		this.panel_7.TabIndex = 3;
		this.panel_7.Click += this.panel_7_Click;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(22, 30);
		this.label_2.Name = GClass107.smethod_3(146081);
		this.label_2.Size = new Size(132, 20);
		this.label_2.TabIndex = 2;
		this.label_2.Tag = "8111";
		this.label_2.Text = GClass107.smethod_3(146122);
		this.tabPage_3.Controls.Add(this.groupBox_7);
		this.tabPage_3.Controls.Add(this.groupBox_8);
		this.tabPage_3.Controls.Add(this.groupBox_9);
		this.tabPage_3.Controls.Add(this.groupBox_6);
		this.tabPage_3.Controls.Add(this.groupBox_5);
		this.tabPage_3.Location = new Point(4, 29);
		this.tabPage_3.Margin = new Padding(3, 4, 3, 4);
		this.tabPage_3.Name = GClass107.smethod_3(146149);
		this.tabPage_3.Padding = new Padding(3, 4, 3, 4);
		this.tabPage_3.Size = new Size(704, 542);
		this.tabPage_3.TabIndex = 3;
		this.tabPage_3.Text = GClass107.smethod_3(146174);
		this.tabPage_3.UseVisualStyleBackColor = true;
		this.groupBox_7.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_7.Controls.Add(this.radioButton_4);
		this.groupBox_7.Controls.Add(this.radioButton_5);
		this.groupBox_7.Location = new Point(17, 331);
		this.groupBox_7.Name = GClass107.smethod_3(146206);
		this.groupBox_7.Size = new Size(664, 70);
		this.groupBox_7.TabIndex = 4;
		this.groupBox_7.TabStop = false;
		this.radioButton_4.AutoSize = true;
		this.radioButton_4.Location = new Point(239, 33);
		this.radioButton_4.Name = GClass107.smethod_3(146246);
		this.radioButton_4.Size = new Size(64, 24);
		this.radioButton_4.TabIndex = 1;
		this.radioButton_4.TabStop = true;
		this.radioButton_4.Text = GClass107.smethod_3(146262);
		this.radioButton_4.UseVisualStyleBackColor = true;
		this.radioButton_5.AutoSize = true;
		this.radioButton_5.Location = new Point(23, 33);
		this.radioButton_5.Name = GClass107.smethod_3(146276);
		this.radioButton_5.Size = new Size(81, 24);
		this.radioButton_5.TabIndex = 0;
		this.radioButton_5.TabStop = true;
		this.radioButton_5.Text = GClass107.smethod_3(146322);
		this.radioButton_5.UseVisualStyleBackColor = true;
		this.groupBox_8.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_8.Controls.Add(this.radioButton_6);
		this.groupBox_8.Controls.Add(this.radioButton_7);
		this.groupBox_8.Location = new Point(17, 255);
		this.groupBox_8.Name = GClass107.smethod_3(146338);
		this.groupBox_8.Size = new Size(664, 70);
		this.groupBox_8.TabIndex = 3;
		this.groupBox_8.TabStop = false;
		this.radioButton_6.AutoSize = true;
		this.radioButton_6.Location = new Point(239, 33);
		this.radioButton_6.Name = GClass107.smethod_3(146381);
		this.radioButton_6.Size = new Size(79, 24);
		this.radioButton_6.TabIndex = 1;
		this.radioButton_6.TabStop = true;
		this.radioButton_6.Text = GClass107.smethod_3(146393);
		this.radioButton_6.UseVisualStyleBackColor = true;
		this.radioButton_7.AutoSize = true;
		this.radioButton_7.Location = new Point(23, 33);
		this.radioButton_7.Name = GClass107.smethod_3(146437);
		this.radioButton_7.Size = new Size(93, 24);
		this.radioButton_7.TabIndex = 0;
		this.radioButton_7.TabStop = true;
		this.radioButton_7.Text = GClass107.smethod_3(146445);
		this.radioButton_7.UseVisualStyleBackColor = true;
		this.groupBox_9.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_9.Controls.Add(this.radioButton_8);
		this.groupBox_9.Controls.Add(this.radioButton_9);
		this.groupBox_9.Location = new Point(17, 179);
		this.groupBox_9.Name = GClass107.smethod_3(146471);
		this.groupBox_9.Size = new Size(664, 70);
		this.groupBox_9.TabIndex = 2;
		this.groupBox_9.TabStop = false;
		this.radioButton_8.AutoSize = true;
		this.radioButton_8.Location = new Point(239, 33);
		this.radioButton_8.Name = GClass107.smethod_3(146480);
		this.radioButton_8.Size = new Size(54, 24);
		this.radioButton_8.TabIndex = 1;
		this.radioButton_8.TabStop = true;
		this.radioButton_8.Text = "psi";
		this.radioButton_8.UseVisualStyleBackColor = true;
		this.radioButton_9.AutoSize = true;
		this.radioButton_9.Location = new Point(23, 33);
		this.radioButton_9.Name = GClass107.smethod_3(146492);
		this.radioButton_9.Size = new Size(57, 24);
		this.radioButton_9.TabIndex = 0;
		this.radioButton_9.TabStop = true;
		this.radioButton_9.Text = "bar";
		this.radioButton_9.UseVisualStyleBackColor = true;
		this.groupBox_6.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_6.Controls.Add(this.radioButton_2);
		this.groupBox_6.Controls.Add(this.radioButton_3);
		this.groupBox_6.Location = new Point(17, 103);
		this.groupBox_6.Name = GClass107.smethod_3(146502);
		this.groupBox_6.Size = new Size(664, 70);
		this.groupBox_6.TabIndex = 1;
		this.groupBox_6.TabStop = false;
		this.radioButton_2.AutoSize = true;
		this.radioButton_2.Location = new Point(239, 33);
		this.radioButton_2.Name = GClass107.smethod_3(146544);
		this.radioButton_2.Size = new Size(49, 24);
		this.radioButton_2.TabIndex = 1;
		this.radioButton_2.TabStop = true;
		this.radioButton_2.Text = "°F";
		this.radioButton_2.UseVisualStyleBackColor = true;
		this.radioButton_3.AutoSize = true;
		this.radioButton_3.Location = new Point(23, 33);
		this.radioButton_3.Name = GClass107.smethod_3(146560);
		this.radioButton_3.Size = new Size(50, 24);
		this.radioButton_3.TabIndex = 0;
		this.radioButton_3.TabStop = true;
		this.radioButton_3.Text = "°C";
		this.radioButton_3.UseVisualStyleBackColor = true;
		this.groupBox_5.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_5.Controls.Add(this.radioButton_0);
		this.groupBox_5.Controls.Add(this.radioButton_1);
		this.groupBox_5.Location = new Point(17, 27);
		this.groupBox_5.Name = GClass107.smethod_3(146571);
		this.groupBox_5.Size = new Size(664, 70);
		this.groupBox_5.TabIndex = 0;
		this.groupBox_5.TabStop = false;
		this.radioButton_0.AutoSize = true;
		this.radioButton_0.Location = new Point(239, 33);
		this.radioButton_0.Name = GClass107.smethod_3(146616);
		this.radioButton_0.Size = new Size(89, 24);
		this.radioButton_0.TabIndex = 1;
		this.radioButton_0.TabStop = true;
		this.radioButton_0.Text = GClass107.smethod_3(146637);
		this.radioButton_0.UseVisualStyleBackColor = true;
		this.radioButton_1.AutoSize = true;
		this.radioButton_1.Location = new Point(23, 33);
		this.radioButton_1.Name = GClass107.smethod_3(146679);
		this.radioButton_1.Size = new Size(97, 24);
		this.radioButton_1.TabIndex = 0;
		this.radioButton_1.TabStop = true;
		this.radioButton_1.Text = GClass107.smethod_3(146697);
		this.radioButton_1.UseVisualStyleBackColor = true;
		this.toolTip_0.AutoPopDelay = 20000;
		this.toolTip_0.InitialDelay = 500;
		this.toolTip_0.IsBalloon = true;
		this.toolTip_0.ReshowDelay = 100;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.AutoSize = true;
		base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(738, 642);
		base.Controls.Add(this.tabControl_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Margin = new Padding(3, 4, 3, 4);
		base.Name = GClass107.smethod_3(146714);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		this.Text = GClass107.smethod_3(146720);
		base.FormClosing += this.GForm13_FormClosing;
		base.Shown += this.GForm13_Shown;
		this.tabControl_0.ResumeLayout(false);
		this.tabPage_0.ResumeLayout(false);
		this.groupBox_3.ResumeLayout(false);
		this.groupBox_3.PerformLayout();
		this.groupBox_2.ResumeLayout(false);
		this.groupBox_2.PerformLayout();
		this.tabPage_2.ResumeLayout(false);
		this.tabPage_2.PerformLayout();
		this.groupBox_4.ResumeLayout(false);
		this.groupBox_4.PerformLayout();
		this.groupBox_1.ResumeLayout(false);
		this.groupBox_1.PerformLayout();
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		this.tabPage_1.ResumeLayout(false);
		this.tabPage_1.PerformLayout();
		this.tabPage_3.ResumeLayout(false);
		this.groupBox_7.ResumeLayout(false);
		this.groupBox_7.PerformLayout();
		this.groupBox_8.ResumeLayout(false);
		this.groupBox_8.PerformLayout();
		this.groupBox_9.ResumeLayout(false);
		this.groupBox_9.PerformLayout();
		this.groupBox_6.ResumeLayout(false);
		this.groupBox_6.PerformLayout();
		this.groupBox_5.ResumeLayout(false);
		this.groupBox_5.PerformLayout();
		base.ResumeLayout(false);
	}

	// Token: 0x040004C2 RID: 1218
	private bool bool_0;

	// Token: 0x040004C4 RID: 1220
	private Button button_0;

	// Token: 0x040004C5 RID: 1221
	private Button button_1;

	// Token: 0x040004C6 RID: 1222
	private Label label_0;

	// Token: 0x040004C7 RID: 1223
	private ComboBox comboBox_0;

	// Token: 0x040004C8 RID: 1224
	private Label label_1;

	// Token: 0x040004C9 RID: 1225
	private ComboBox comboBox_1;

	// Token: 0x040004CA RID: 1226
	private TabControl tabControl_0;

	// Token: 0x040004CB RID: 1227
	private TabPage tabPage_0;

	// Token: 0x040004CC RID: 1228
	private TabPage tabPage_1;

	// Token: 0x040004CD RID: 1229
	private Panel panel_0;

	// Token: 0x040004CE RID: 1230
	private Panel panel_1;

	// Token: 0x040004CF RID: 1231
	private Panel panel_2;

	// Token: 0x040004D0 RID: 1232
	private Panel panel_3;

	// Token: 0x040004D1 RID: 1233
	private Panel panel_4;

	// Token: 0x040004D2 RID: 1234
	private Panel panel_5;

	// Token: 0x040004D3 RID: 1235
	private Panel panel_6;

	// Token: 0x040004D4 RID: 1236
	private Panel panel_7;

	// Token: 0x040004D5 RID: 1237
	private Label label_2;

	// Token: 0x040004D6 RID: 1238
	private Label label_3;

	// Token: 0x040004D7 RID: 1239
	private Panel panel_8;

	// Token: 0x040004D8 RID: 1240
	private Label label_4;

	// Token: 0x040004D9 RID: 1241
	private Panel panel_9;

	// Token: 0x040004DA RID: 1242
	private Label label_5;

	// Token: 0x040004DB RID: 1243
	private ComboBox comboBox_2;

	// Token: 0x040004DC RID: 1244
	private Label label_6;

	// Token: 0x040004DD RID: 1245
	private Button button_2;

	// Token: 0x040004DE RID: 1246
	private Label label_7;

	// Token: 0x040004DF RID: 1247
	private Label label_8;

	// Token: 0x040004E0 RID: 1248
	private Button button_3;

	// Token: 0x040004E1 RID: 1249
	private Label label_9;

	// Token: 0x040004E2 RID: 1250
	private Label label_10;

	// Token: 0x040004E3 RID: 1251
	private Button button_4;

	// Token: 0x040004E4 RID: 1252
	private Label label_11;

	// Token: 0x040004E5 RID: 1253
	private Label label_12;

	// Token: 0x040004E6 RID: 1254
	private Label label_13;

	// Token: 0x040004E7 RID: 1255
	private TextBox textBox_0;

	// Token: 0x040004E8 RID: 1256
	private FontDialog fontDialog_0;

	// Token: 0x040004E9 RID: 1257
	private ColorDialog colorDialog_0;

	// Token: 0x040004EA RID: 1258
	private Label label_14;

	// Token: 0x040004EB RID: 1259
	private TextBox textBox_1;

	// Token: 0x040004EC RID: 1260
	private ComboBox comboBox_3;

	// Token: 0x040004ED RID: 1261
	private Button button_5;

	// Token: 0x040004EE RID: 1262
	private Label label_15;

	// Token: 0x040004EF RID: 1263
	private Label label_16;

	// Token: 0x040004F0 RID: 1264
	private Button button_6;

	// Token: 0x040004F1 RID: 1265
	private Label label_17;

	// Token: 0x040004F2 RID: 1266
	private Label label_18;

	// Token: 0x040004F3 RID: 1267
	private TabPage tabPage_2;

	// Token: 0x040004F4 RID: 1268
	private Label label_19;

	// Token: 0x040004F5 RID: 1269
	private ComboBox comboBox_4;

	// Token: 0x040004F6 RID: 1270
	private CheckBox checkBox_0;

	// Token: 0x040004F7 RID: 1271
	private GroupBox groupBox_0;

	// Token: 0x040004F8 RID: 1272
	private Button button_7;

	// Token: 0x040004F9 RID: 1273
	private Label label_20;

	// Token: 0x040004FA RID: 1274
	private ComboBox comboBox_5;

	// Token: 0x040004FB RID: 1275
	private Label label_21;

	// Token: 0x040004FC RID: 1276
	private ComboBox comboBox_6;

	// Token: 0x040004FD RID: 1277
	private ComboBox comboBox_7;

	// Token: 0x040004FE RID: 1278
	private GroupBox groupBox_1;

	// Token: 0x040004FF RID: 1279
	private Button button_8;

	// Token: 0x04000500 RID: 1280
	private Label label_22;

	// Token: 0x04000501 RID: 1281
	private ComboBox comboBox_8;

	// Token: 0x04000502 RID: 1282
	private Label label_23;

	// Token: 0x04000503 RID: 1283
	private ComboBox comboBox_9;

	// Token: 0x04000504 RID: 1284
	private ComboBox comboBox_10;

	// Token: 0x04000505 RID: 1285
	private Button button_9;

	// Token: 0x04000506 RID: 1286
	private GroupBox groupBox_2;

	// Token: 0x04000507 RID: 1287
	private GroupBox groupBox_3;

	// Token: 0x04000508 RID: 1288
	private GroupBox groupBox_4;

	// Token: 0x04000509 RID: 1289
	private ToolTip toolTip_0;

	// Token: 0x0400050A RID: 1290
	private CheckBox checkBox_1;

	// Token: 0x0400050B RID: 1291
	private ComboBox comboBox_11;

	// Token: 0x0400050C RID: 1292
	private Label label_24;

	// Token: 0x0400050D RID: 1293
	private CheckBox checkBox_2;

	// Token: 0x0400050E RID: 1294
	private Button button_10;

	// Token: 0x0400050F RID: 1295
	private TextBox textBox_2;

	// Token: 0x04000510 RID: 1296
	private TextBox textBox_3;

	// Token: 0x04000511 RID: 1297
	private Label label_25;

	// Token: 0x04000512 RID: 1298
	private Label label_26;

	// Token: 0x04000513 RID: 1299
	private Panel panel_10;

	// Token: 0x04000514 RID: 1300
	private Panel panel_11;

	// Token: 0x04000515 RID: 1301
	private Panel panel_12;

	// Token: 0x04000516 RID: 1302
	private Panel panel_13;

	// Token: 0x04000517 RID: 1303
	private Panel panel_14;

	// Token: 0x04000518 RID: 1304
	private Panel panel_15;

	// Token: 0x04000519 RID: 1305
	private Panel panel_16;

	// Token: 0x0400051A RID: 1306
	private Panel panel_17;

	// Token: 0x0400051B RID: 1307
	private TabPage tabPage_3;

	// Token: 0x0400051C RID: 1308
	private GroupBox groupBox_5;

	// Token: 0x0400051D RID: 1309
	private RadioButton radioButton_0;

	// Token: 0x0400051E RID: 1310
	private RadioButton radioButton_1;

	// Token: 0x0400051F RID: 1311
	private GroupBox groupBox_6;

	// Token: 0x04000520 RID: 1312
	private RadioButton radioButton_2;

	// Token: 0x04000521 RID: 1313
	private RadioButton radioButton_3;

	// Token: 0x04000522 RID: 1314
	private GroupBox groupBox_7;

	// Token: 0x04000523 RID: 1315
	private RadioButton radioButton_4;

	// Token: 0x04000524 RID: 1316
	private RadioButton radioButton_5;

	// Token: 0x04000525 RID: 1317
	private GroupBox groupBox_8;

	// Token: 0x04000526 RID: 1318
	private RadioButton radioButton_6;

	// Token: 0x04000527 RID: 1319
	private RadioButton radioButton_7;

	// Token: 0x04000528 RID: 1320
	private GroupBox groupBox_9;

	// Token: 0x04000529 RID: 1321
	private RadioButton radioButton_8;

	// Token: 0x0400052A RID: 1322
	private RadioButton radioButton_9;

	// Token: 0x020000B4 RID: 180
	// (Invoke) Token: 0x060005EC RID: 1516
	private delegate void Delegate16(List<string> ports);
}
