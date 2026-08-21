using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000017 RID: 23
public sealed partial class FormDataEntry : Form
{
	// Token: 0x060000D4 RID: 212 RVA: 0x000236C0 File Offset: 0x000218C0
	public FormDataEntry(string string_1, string string_2, string[] string_3, int int_1)
	{
		this.InitializeComponent();
		this.lblMessage1.Text = string_1;
		this.string_0 = string_3;
		this.int_0 = int_1;
		this.buttonOk.Enabled = true;
		this.comboBox_0 = new ComboBox[]
		{
			this.cbChar1,
			this.cbChar2,
			this.cbChar3,
			this.cbChar4,
			this.cbChar5,
			this.cbChar6,
			this.cbChar7,
			this.cbChar8,
			this.cbChar9
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
			this.comboBox_0[0].Width = 520;
		}
		this.comboBox_0[0].Focus();
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x000026DC File Offset: 0x000008DC
	private void buttonOk_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x000026DC File Offset: 0x000008DC
	private void method_0(object sender, EventArgs e)
	{
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00023868 File Offset: 0x00021A68
	public int[] method_1()
	{
		ComboBox[] array = new ComboBox[]
		{
			this.cbChar1,
			this.cbChar2,
			this.cbChar3,
			this.cbChar4,
			this.cbChar5,
			this.cbChar6,
			this.cbChar7,
			this.cbChar8,
			this.cbChar9
		};
		int[] array2 = new int[this.int_0];
		for (int i = 0; i < this.int_0; i++)
		{
			array2[i] = array[i].SelectedIndex;
		}
		return array2;
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00023900 File Offset: 0x00021B00
	private void cbChar5_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (sender != null)
		{
			ComboBox comboBox = (ComboBox)sender;
			if (comboBox.Visible)
			{
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
							break;
						}
						break;
					}
				}
			}
		}
	}

	// Token: 0x040000DC RID: 220
	private string[] string_0 = new string[0];

	// Token: 0x040000DD RID: 221
	private int int_0 = 0;

	// Token: 0x040000DE RID: 222
	private ComboBox[] comboBox_0 = new ComboBox[0];
}
