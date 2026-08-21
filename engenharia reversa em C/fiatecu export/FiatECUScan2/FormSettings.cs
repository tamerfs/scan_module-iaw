using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

// Token: 0x02000060 RID: 96
public sealed partial class FormSettings : Form
{
	// Token: 0x060002A5 RID: 677 RVA: 0x00065A68 File Offset: 0x00063C68
	public FormSettings()
	{
		this.InitializeComponent();
		string[] array = GClass62.smethod_5();
		string[] array2 = GClass62.smethod_6();
		this.cbUILang.Items.Clear();
		for (int i = 0; i < array2.Length; i++)
		{
			this.cbUILang.Items.Add(array2[i]);
		}
		this.cbDataLang.Items.Clear();
		for (int i = 0; i < array.Length; i++)
		{
			this.cbDataLang.Items.Add(array[i]);
		}
		this.cbDataLang.SelectedItem = GClass61.smethod_14();
		this.cbUILang.SelectedItem = GClass61.smethod_12();
		this.chkShowAvailablePorts.Checked = GClass61.smethod_43();
		this.method_2(null, null);
		this.cbKWPTimings.SelectedIndex = GClass61.smethod_47();
		this.chkShowAdapterMessage.Checked = GClass61.smethod_45();
		this.chkHighLatency.Checked = GClass61.smethod_49();
		this.cbScreenRepaint.SelectedIndex = GClass61.smethod_51();
		this.chkShowMiles.Checked = GClass61.smethod_55();
		this.cbInterfaceType.Items.Clear();
		this.cbInterfaceType2.Items.Clear();
		this.cbInterfaceType3.Items.Clear();
		this.cbInterfaceType4.Items.Clear();
		for (int i = 0; i < GClass61.string_0.Length; i++)
		{
			if ((!GClass3.bool_2 || i == 6 || i == 0) && (GClass3.bool_2 || i != 6))
			{
				this.cbInterfaceType.Items.Add(GClass61.string_0[i]);
				this.cbInterfaceType2.Items.Add(GClass61.string_0[i]);
				this.cbInterfaceType3.Items.Add(GClass61.string_0[i]);
				this.cbInterfaceType4.Items.Add(GClass61.string_0[i]);
			}
		}
		this.cbInterfaceType.SelectedIndex = 0;
		this.cbInterfaceType.SelectedItem = GClass61.string_0[(GClass61.smethod_30(0) < GClass61.string_0.Length) ? GClass61.smethod_30(0) : 0];
		this.cbSerialPort.SelectedItem = GClass61.smethod_32(0);
		this.cbPortSpeed.SelectedItem = string.Concat(GClass61.smethod_34(0));
		this.cbInterfaceType2.SelectedIndex = 0;
		this.cbInterfaceType2.SelectedItem = GClass61.string_0[(GClass61.smethod_30(1) < GClass61.string_0.Length) ? GClass61.smethod_30(1) : 0];
		this.cbSerialPort2.SelectedItem = GClass61.smethod_32(1);
		this.cbPortSpeed2.SelectedItem = string.Concat(GClass61.smethod_34(1));
		this.cbInterfaceType3.SelectedIndex = 0;
		this.cbInterfaceType3.SelectedItem = GClass61.string_0[(GClass61.smethod_30(2) < GClass61.string_0.Length) ? GClass61.smethod_30(2) : 0];
		this.cbSerialPort3.SelectedItem = GClass61.smethod_32(2);
		this.cbPortSpeed3.SelectedItem = string.Concat(GClass61.smethod_34(2));
		this.cbInterfaceType4.SelectedIndex = 0;
		this.cbInterfaceType4.SelectedItem = GClass61.string_0[(GClass61.smethod_30(3) < GClass61.string_0.Length) ? GClass61.smethod_30(3) : 0];
		this.cbSerialPort4.SelectedItem = GClass61.smethod_32(3);
		this.cbPortSpeed4.SelectedItem = string.Concat(GClass61.smethod_34(3));
		this.cbCSVSeparator.SelectedItem = GClass61.smethod_10();
		this.tbCSVFolder.Text = GClass61.smethod_24();
		this.tbLogFolder.Text = GClass61.smethod_26();
		this.lblUIF1.Text = GClass16.smethod_32(GClass61.smethod_18());
		this.lblUIF1.Font = GClass61.smethod_18();
		this.lblUIF2.Text = GClass16.smethod_32(GClass61.smethod_20());
		this.lblUIF2.Font = GClass61.smethod_20();
		this.panelGC1.BackColor = GClass61.smethod_69(0);
		this.panelGC2.BackColor = GClass61.smethod_69(1);
		this.panelGC3.BackColor = GClass61.smethod_69(2);
		this.panelGC4.BackColor = GClass61.smethod_69(3);
		this.panelGC5.BackColor = GClass61.smethod_69(4);
		this.panelGC6.BackColor = GClass61.smethod_69(5);
		this.panelGC7.BackColor = GClass61.smethod_69(6);
		this.panelGC8.BackColor = GClass61.smethod_69(7);
		this.panelBC.BackColor = GClass61.smethod_71();
		this.panelGC.BackColor = GClass61.smethod_73();
		this.cbLineThickness.SelectedItem = string.Concat(GClass61.smethod_77());
		this.lblYF.Text = GClass16.smethod_32(GClass61.smethod_79());
		this.lblYF.Font = GClass61.smethod_79();
		this.lblXF.Text = GClass16.smethod_32(GClass61.smethod_81());
		this.lblXF.Font = GClass61.smethod_81();
		this.lblXF.ForeColor = GClass61.smethod_75();
		this.lblPF.Text = GClass16.smethod_32(GClass61.smethod_83());
		this.lblPF.Font = GClass61.smethod_83();
		this.lblXF.BackColor = GClass61.smethod_71();
		this.cbDataLang.Enabled = GClass3.bool_3;
		if (!this.cbDataLang.Enabled)
		{
			this.cbDataLang.SelectedItem = "English";
		}
		this.method_1();
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x00065FE8 File Offset: 0x000641E8
	private int method_0(string string_0)
	{
		int result = 0;
		for (int i = 0; i < GClass61.string_0.Length; i++)
		{
			if (GClass61.string_0[i] == string_0)
			{
				result = i;
				return result;
			}
		}
		return result;
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x00066024 File Offset: 0x00064224
	private void buttonOk_Click(object sender, EventArgs e)
	{
		GClass61.smethod_31(0, this.method_0(GClass16.smethod_3(this.cbInterfaceType.SelectedItem)));
		GClass61.smethod_31(1, this.method_0(GClass16.smethod_3(this.cbInterfaceType2.SelectedItem)));
		GClass61.smethod_31(2, this.method_0(GClass16.smethod_3(this.cbInterfaceType3.SelectedItem)));
		GClass61.smethod_31(3, this.method_0(GClass16.smethod_3(this.cbInterfaceType4.SelectedItem)));
		GClass61.smethod_33(0, GClass16.smethod_4(this.cbSerialPort.SelectedItem, GClass61.smethod_32(0)));
		GClass61.smethod_33(1, GClass16.smethod_4(this.cbSerialPort2.SelectedItem, GClass61.smethod_32(1)));
		GClass61.smethod_33(2, GClass16.smethod_4(this.cbSerialPort3.SelectedItem, GClass61.smethod_32(2)));
		GClass61.smethod_33(3, GClass16.smethod_4(this.cbSerialPort4.SelectedItem, GClass61.smethod_32(3)));
		GClass61.smethod_35(0, GClass16.smethod_5(this.cbPortSpeed.SelectedItem.ToString()));
		GClass61.smethod_35(1, GClass16.smethod_5(this.cbPortSpeed2.SelectedItem.ToString()));
		GClass61.smethod_35(2, GClass16.smethod_5(this.cbPortSpeed3.SelectedItem.ToString()));
		GClass61.smethod_35(3, GClass16.smethod_5(this.cbPortSpeed4.SelectedItem.ToString()));
		GClass61.smethod_44(this.chkShowAvailablePorts.Checked);
		GClass61.smethod_48(this.cbKWPTimings.SelectedIndex);
		GClass61.smethod_50(this.chkHighLatency.Checked);
		GClass61.smethod_52(this.cbScreenRepaint.SelectedIndex);
		GClass61.smethod_46(this.chkShowAdapterMessage.Checked);
		GClass61.smethod_56(this.chkShowMiles.Checked);
		GClass61.smethod_11((string)this.cbCSVSeparator.SelectedItem);
		GClass61.smethod_25(this.tbCSVFolder.Text);
		GClass61.smethod_27(this.tbLogFolder.Text);
		GClass61.smethod_70(0, this.panelGC1.BackColor);
		GClass61.smethod_70(1, this.panelGC2.BackColor);
		GClass61.smethod_70(2, this.panelGC3.BackColor);
		GClass61.smethod_70(3, this.panelGC4.BackColor);
		GClass61.smethod_70(4, this.panelGC5.BackColor);
		GClass61.smethod_70(5, this.panelGC6.BackColor);
		GClass61.smethod_70(6, this.panelGC7.BackColor);
		GClass61.smethod_70(7, this.panelGC8.BackColor);
		GClass61.smethod_72(this.panelBC.BackColor);
		GClass61.smethod_74(this.panelGC.BackColor);
		GClass61.smethod_78(GClass16.smethod_5(this.cbLineThickness.SelectedItem));
		GClass61.smethod_80(this.lblYF.Font);
		GClass61.smethod_82(this.lblXF.Font);
		GClass61.smethod_84(this.lblPF.Font);
		GClass61.smethod_76(this.lblXF.ForeColor);
		GClass61.smethod_13(this.cbUILang.SelectedItem.ToString());
		GClass61.smethod_15(this.cbDataLang.SelectedItem.ToString());
		GClass61.smethod_19(this.lblUIF1.Font);
		GClass61.smethod_21(this.lblUIF2.Font);
		GClass62.smethod_8(GClass61.smethod_12(), GClass61.smethod_14());
		GClass61.smethod_106();
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x00066370 File Offset: 0x00064570
	private void buttonChangeYF_Click(object sender, EventArgs e)
	{
		this.fontDialog_0.Font = this.lblYF.Font;
		this.fontDialog_0.ShowColor = false;
		if (this.fontDialog_0.ShowDialog() == DialogResult.OK)
		{
			this.lblYF.Text = GClass16.smethod_32(this.fontDialog_0.Font);
			this.lblYF.Font = this.fontDialog_0.Font;
		}
	}

	// Token: 0x060002A9 RID: 681 RVA: 0x000663E4 File Offset: 0x000645E4
	private void buttonChangeXF_Click(object sender, EventArgs e)
	{
		this.fontDialog_0.Font = this.lblXF.Font;
		this.fontDialog_0.Color = this.lblXF.ForeColor;
		this.fontDialog_0.ShowColor = true;
		if (this.fontDialog_0.ShowDialog() == DialogResult.OK)
		{
			this.lblXF.Text = GClass16.smethod_32(this.fontDialog_0.Font);
			this.lblXF.Font = this.fontDialog_0.Font;
			this.lblXF.ForeColor = this.fontDialog_0.Color;
		}
	}

	// Token: 0x060002AA RID: 682 RVA: 0x00066484 File Offset: 0x00064684
	private void buttonChangePF_Click(object sender, EventArgs e)
	{
		this.fontDialog_0.Font = this.lblPF.Font;
		this.fontDialog_0.ShowColor = false;
		if (this.fontDialog_0.ShowDialog() == DialogResult.OK)
		{
			this.lblPF.Text = GClass16.smethod_32(this.fontDialog_0.Font);
			this.lblPF.Font = this.fontDialog_0.Font;
		}
	}

	// Token: 0x060002AB RID: 683 RVA: 0x000664F8 File Offset: 0x000646F8
	private void panelGC1_Click(object sender, EventArgs e)
	{
		this.colorDialog_0.Color = ((Panel)sender).BackColor;
		if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
		{
			((Panel)sender).BackColor = this.colorDialog_0.Color;
			this.lblXF.BackColor = this.panelBC.BackColor;
		}
	}

	// Token: 0x060002AC RID: 684 RVA: 0x0006655C File Offset: 0x0006475C
	private void method_1()
	{
		List<Control> list = FormSettings.smethod_0(this, 1);
		foreach (Control control in list)
		{
			if (control.Tag != null)
			{
				string text = GClass62.smethod_1(control.Tag.ToString());
				string text2 = GClass62.smethod_1(control.Tag.ToString() + "T");
				if (text2 != null && text2 != string.Empty && (control is Button || control is CheckBox || control is ComboBox || control is TextBox))
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
		string text3 = GClass62.smethod_1("8192");
		if (text3 != null)
		{
			this.tabPageSettingsGeneral.Text = text3;
		}
		text3 = GClass62.smethod_1("8193");
		if (text3 != null)
		{
			this.tabPageSettingsGraph.Text = text3;
		}
		text3 = GClass62.smethod_1("8194");
		if (text3 != null)
		{
			this.tabPageSettingsInterfaces.Text = text3;
		}
		text3 = GClass62.smethod_1("8191");
		if (text3 != null)
		{
			this.Text = text3;
		}
	}

	// Token: 0x060002AD RID: 685 RVA: 0x00066754 File Offset: 0x00064954
	public static List<Control> smethod_0(Control control_0, int int_0)
	{
		List<Control> list = new List<Control>();
		if (int_0 < 10)
		{
			foreach (object obj in control_0.Controls)
			{
				Control control = (Control)obj;
				list.AddRange(FormSettings.smethod_0(control, int_0 + 1));
				list.Add(control);
			}
		}
		return list;
	}

	// Token: 0x060002AE RID: 686 RVA: 0x00003039 File Offset: 0x00001239
	private void cbUILang_SelectedIndexChanged(object sender, EventArgs e)
	{
		GClass62.smethod_9(this.cbUILang.SelectedItem.ToString());
		this.method_1();
	}

	// Token: 0x060002AF RID: 687 RVA: 0x00003056 File Offset: 0x00001256
	private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
	{
		GClass62.smethod_9(GClass61.smethod_12());
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x000667D8 File Offset: 0x000649D8
	private void cbInterfaceType_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.buttonTest.Visible = (this.cbInterfaceType.SelectedIndex > 0);
		this.buttonTest2.Visible = (this.cbInterfaceType2.SelectedIndex > 0);
		this.buttonTest3.Visible = (this.cbInterfaceType3.SelectedIndex > 0);
		this.buttonTest4.Visible = (this.cbInterfaceType4.SelectedIndex > 0);
		this.cbPortSpeed.Visible = (this.method_0((string)this.cbInterfaceType.SelectedItem) > 1);
		this.cbPortSpeed2.Visible = (this.method_0((string)this.cbInterfaceType2.SelectedItem) > 1);
		this.cbPortSpeed3.Visible = (this.method_0((string)this.cbInterfaceType3.SelectedItem) > 1);
		this.cbPortSpeed4.Visible = (this.method_0((string)this.cbInterfaceType4.SelectedItem) > 1);
		this.label3.Visible = this.cbPortSpeed.Visible;
		this.label21.Visible = this.cbPortSpeed2.Visible;
		this.label24.Visible = this.cbPortSpeed3.Visible;
		this.label27.Visible = this.cbPortSpeed4.Visible;
		this.cbSerialPort.Visible = (this.cbInterfaceType.SelectedIndex > 0);
		this.cbSerialPort2.Visible = (this.cbInterfaceType2.SelectedIndex > 0);
		this.cbSerialPort3.Visible = (this.cbInterfaceType3.SelectedIndex > 0);
		this.cbSerialPort4.Visible = (this.cbInterfaceType4.SelectedIndex > 0);
		this.label1.Visible = (this.cbInterfaceType.SelectedIndex > 0);
		this.label20.Visible = (this.cbInterfaceType2.SelectedIndex > 0);
		this.label23.Visible = (this.cbInterfaceType3.SelectedIndex > 0);
		this.label26.Visible = (this.cbInterfaceType4.SelectedIndex > 0);
		this.cbKWPTimings.Visible = (this.method_0(GClass16.smethod_3(this.cbInterfaceType.SelectedItem)) == 1 || this.method_0(GClass16.smethod_3(this.cbInterfaceType2.SelectedItem)) == 1 || this.method_0(GClass16.smethod_3(this.cbInterfaceType3.SelectedItem)) == 1 || this.method_0(GClass16.smethod_3(this.cbInterfaceType4.SelectedItem)) == 1);
		this.label8.Visible = this.cbKWPTimings.Visible;
		if (((ComboBox)sender).Name == "cbInterfaceType" && this.method_0(GClass16.smethod_3(this.cbInterfaceType.SelectedItem)) > 1)
		{
			if (this.method_0(GClass16.smethod_3(this.cbInterfaceType.SelectedItem)) == 2)
			{
				this.cbPortSpeed.SelectedIndex = 2;
			}
			else if (this.method_0(GClass16.smethod_3(this.cbInterfaceType.SelectedItem)) == 4)
			{
				this.cbPortSpeed.SelectedIndex = 0;
			}
			else
			{
				this.cbPortSpeed.SelectedIndex = 4;
			}
		}
		else if (((ComboBox)sender).Name == "cbInterfaceType2" && this.method_0(GClass16.smethod_3(this.cbInterfaceType2.SelectedItem)) > 1)
		{
			if (this.method_0(GClass16.smethod_3(this.cbInterfaceType2.SelectedItem)) == 2)
			{
				this.cbPortSpeed2.SelectedIndex = 2;
			}
			else if (this.method_0(GClass16.smethod_3(this.cbInterfaceType2.SelectedItem)) == 4)
			{
				this.cbPortSpeed2.SelectedIndex = 0;
			}
			else
			{
				this.cbPortSpeed2.SelectedIndex = 4;
			}
		}
		else if (((ComboBox)sender).Name == "cbInterfaceType3" && this.method_0(GClass16.smethod_3(this.cbInterfaceType3.SelectedItem)) > 1)
		{
			if (this.method_0(GClass16.smethod_3(this.cbInterfaceType3.SelectedItem)) == 2)
			{
				this.cbPortSpeed3.SelectedIndex = 2;
			}
			else if (this.method_0(GClass16.smethod_3(this.cbInterfaceType3.SelectedItem)) == 4)
			{
				this.cbPortSpeed3.SelectedIndex = 0;
			}
			else
			{
				this.cbPortSpeed3.SelectedIndex = 4;
			}
		}
		else if (((ComboBox)sender).Name == "cbInterfaceType4" && this.method_0(GClass16.smethod_3(this.cbInterfaceType4.SelectedItem)) > 1)
		{
			if (this.method_0(GClass16.smethod_3(this.cbInterfaceType4.SelectedItem)) == 2)
			{
				this.cbPortSpeed4.SelectedIndex = 2;
			}
			else if (this.method_0(GClass16.smethod_3(this.cbInterfaceType4.SelectedItem)) == 4)
			{
				this.cbPortSpeed4.SelectedIndex = 0;
			}
			else
			{
				this.cbPortSpeed4.SelectedIndex = 4;
			}
		}
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x00066D14 File Offset: 0x00064F14
	private void buttonChangeUIF1_Click(object sender, EventArgs e)
	{
		this.fontDialog_0.Font = this.lblUIF1.Font;
		this.fontDialog_0.ShowColor = false;
		if (this.fontDialog_0.ShowDialog() == DialogResult.OK)
		{
			this.lblUIF1.Text = GClass16.smethod_32(this.fontDialog_0.Font);
			this.lblUIF1.Font = this.fontDialog_0.Font;
		}
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x00066D88 File Offset: 0x00064F88
	private void buttonChangeUIF2_Click(object sender, EventArgs e)
	{
		this.fontDialog_0.Font = this.lblUIF2.Font;
		this.fontDialog_0.ShowColor = false;
		if (this.fontDialog_0.ShowDialog() == DialogResult.OK)
		{
			this.lblUIF2.Text = GClass16.smethod_32(this.fontDialog_0.Font);
			this.lblUIF2.Font = this.fontDialog_0.Font;
		}
	}

	// Token: 0x060002B3 RID: 691 RVA: 0x00066DFC File Offset: 0x00064FFC
	private void method_2(object sender, EventArgs e)
	{
		string selectedItem = GClass16.smethod_4(this.cbSerialPort.SelectedItem, GClass61.smethod_32(0));
		string selectedItem2 = GClass16.smethod_4(this.cbSerialPort2.SelectedItem, GClass61.smethod_32(1));
		string selectedItem3 = GClass16.smethod_4(this.cbSerialPort3.SelectedItem, GClass61.smethod_32(2));
		string selectedItem4 = GClass16.smethod_4(this.cbSerialPort4.SelectedItem, GClass61.smethod_32(3));
		if (this.chkShowAvailablePorts.Checked)
		{
			this.cbSerialPort.Items.Clear();
			this.cbSerialPort2.Items.Clear();
			this.cbSerialPort3.Items.Clear();
			this.cbSerialPort4.Items.Clear();
			string[] portNames = SerialPort.GetPortNames();
			int i = 1;
			IL_1B3:
			while (i < 31)
			{
				for (int j = 0; j < portNames.Length; j++)
				{
					if ((i < 4 && portNames[j] == "COM" + i) || (i > 3 && portNames[j].StartsWith("COM" + i)))
					{
						this.cbSerialPort.Items.Add("COM" + i);
						this.cbSerialPort2.Items.Add("COM" + i);
						this.cbSerialPort3.Items.Add("COM" + i);
						this.cbSerialPort4.Items.Add("COM" + i);
						IL_1AD:
						i++;
						goto IL_1B3;
					}
				}
				goto IL_1AD;
			}
		}
		else
		{
			this.cbSerialPort.Items.Clear();
			this.cbSerialPort2.Items.Clear();
			this.cbSerialPort3.Items.Clear();
			this.cbSerialPort4.Items.Clear();
			for (int i = 1; i < 31; i++)
			{
				this.cbSerialPort.Items.Add("COM" + i);
				this.cbSerialPort2.Items.Add("COM" + i);
				this.cbSerialPort3.Items.Add("COM" + i);
				this.cbSerialPort4.Items.Add("COM" + i);
			}
		}
		this.cbSerialPort.SelectedItem = selectedItem;
		this.cbSerialPort2.SelectedItem = selectedItem2;
		this.cbSerialPort3.SelectedItem = selectedItem3;
		this.cbSerialPort4.SelectedItem = selectedItem4;
	}

	// Token: 0x060002B4 RID: 692 RVA: 0x000670E0 File Offset: 0x000652E0
	private void buttonScanInterface_Click(object sender, EventArgs e)
	{
		FormLookupInterfaces formLookupInterfaces = new FormLookupInterfaces();
		if (formLookupInterfaces.ShowDialog() == DialogResult.OK)
		{
			if (formLookupInterfaces.list_0.Count > 0)
			{
				this.cbInterfaceType.SelectedItem = GClass61.string_0[formLookupInterfaces.list_0[0]];
				this.cbSerialPort.SelectedItem = formLookupInterfaces.list_1[0];
				this.cbPortSpeed.SelectedItem = formLookupInterfaces.list_2[0];
			}
			else
			{
				this.cbInterfaceType.SelectedIndex = 0;
			}
			if (formLookupInterfaces.list_0.Count > 1)
			{
				this.cbInterfaceType2.SelectedItem = GClass61.string_0[formLookupInterfaces.list_0[1]];
				this.cbSerialPort2.SelectedItem = formLookupInterfaces.list_1[1];
				this.cbPortSpeed2.SelectedItem = formLookupInterfaces.list_2[1];
			}
			else
			{
				this.cbInterfaceType2.SelectedIndex = 0;
			}
			if (formLookupInterfaces.list_0.Count > 3)
			{
				this.cbInterfaceType3.SelectedItem = GClass61.string_0[formLookupInterfaces.list_0[2]];
				this.cbSerialPort3.SelectedItem = formLookupInterfaces.list_1[2];
				this.cbPortSpeed3.SelectedItem = formLookupInterfaces.list_2[2];
			}
			else
			{
				this.cbInterfaceType3.SelectedIndex = 0;
			}
			if (formLookupInterfaces.list_0.Count > 3)
			{
				this.cbInterfaceType4.SelectedItem = GClass61.string_0[formLookupInterfaces.list_0[3]];
				this.cbSerialPort4.SelectedItem = formLookupInterfaces.list_1[3];
				this.cbPortSpeed4.SelectedItem = formLookupInterfaces.list_2[3];
			}
			else
			{
				this.cbInterfaceType4.SelectedIndex = 0;
			}
		}
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x000672C8 File Offset: 0x000654C8
	private void buttonTest_Click(object sender, EventArgs e)
	{
		Cursor.Current = Cursors.WaitCursor;
		new FormTestELMConnection(this.cbSerialPort.SelectedItem.ToString(), GClass16.smethod_5(this.cbPortSpeed.SelectedItem.ToString()), this.method_0(this.cbInterfaceType.SelectedItem.ToString())).ShowDialog();
		Cursor.Current = Cursors.Default;
	}

	// Token: 0x060002B6 RID: 694 RVA: 0x00067330 File Offset: 0x00065530
	private void buttonTest2_Click(object sender, EventArgs e)
	{
		Cursor.Current = Cursors.WaitCursor;
		new FormTestELMConnection(this.cbSerialPort2.SelectedItem.ToString(), GClass16.smethod_5(this.cbPortSpeed2.SelectedItem.ToString()), this.method_0(this.cbInterfaceType2.SelectedItem.ToString())).ShowDialog();
		Cursor.Current = Cursors.Default;
	}

	// Token: 0x060002B7 RID: 695 RVA: 0x00067398 File Offset: 0x00065598
	private void buttonTest3_Click(object sender, EventArgs e)
	{
		Cursor.Current = Cursors.WaitCursor;
		new FormTestELMConnection(this.cbSerialPort3.SelectedItem.ToString(), GClass16.smethod_5(this.cbPortSpeed3.SelectedItem.ToString()), this.method_0(this.cbInterfaceType3.SelectedItem.ToString())).ShowDialog();
		Cursor.Current = Cursors.Default;
	}

	// Token: 0x060002B8 RID: 696 RVA: 0x00067400 File Offset: 0x00065600
	private void buttonTest4_Click(object sender, EventArgs e)
	{
		Cursor.Current = Cursors.WaitCursor;
		new FormTestELMConnection(this.cbSerialPort4.SelectedItem.ToString(), GClass16.smethod_5(this.cbPortSpeed4.SelectedItem.ToString()), this.method_0(this.cbInterfaceType4.SelectedItem.ToString())).ShowDialog();
		Cursor.Current = Cursors.Default;
	}

	// Token: 0x060002B9 RID: 697 RVA: 0x00003062 File Offset: 0x00001262
	private void buttonClearRecent_Click(object sender, EventArgs e)
	{
		GClass61.smethod_67(string.Empty);
	}
}
