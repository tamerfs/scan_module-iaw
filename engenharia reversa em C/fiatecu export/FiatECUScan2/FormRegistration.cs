using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000061 RID: 97
public sealed partial class FormRegistration : Form
{
	// Token: 0x060002BC RID: 700 RVA: 0x0006B030 File Offset: 0x00069230
	public FormRegistration()
	{
		this.InitializeComponent();
	}

	// Token: 0x060002BF RID: 703 RVA: 0x0006BA70 File Offset: 0x00069C70
	private void method_0()
	{
		this.lblLink.Visible = false;
		this.tbRemoval.Text = GClass61.smethod_7();
		this.tbRemoval.Visible = (GClass61.smethod_7().Length > 0);
		if (GClass3.bool_2 && GClass3.bool_3)
		{
			this.textBox4.Text = this.string_0[2];
			this.textBox4.ForeColor = Color.Navy;
			this.tbSerial.ReadOnly = true;
			this.tbSerial.Text = GClass61.smethod_5();
			this.buttonActivate.Enabled = false;
		}
		else if (GClass3.bool_3)
		{
			this.textBox4.Text = this.string_0[0];
			this.textBox4.ForeColor = Color.Green;
			this.tbSerial.ReadOnly = true;
			this.tbSerial.Text = GClass61.smethod_5();
			this.buttonActivate.Enabled = false;
		}
		else
		{
			this.textBox4.Text = this.string_0[1];
			this.textBox4.ForeColor = Color.Red;
			this.tbSerial.ReadOnly = false;
			this.tbSerial.Text = string.Empty;
			this.buttonActivate.Enabled = true;
		}
		this.buttonDeactivate.Enabled = !this.buttonActivate.Enabled;
		if (this.buttonDeactivate.Enabled && GClass3.bool_2)
		{
			this.textBox3.Text = "You can deactivate current license of FiatECUScan on this computer and activate a different license by using the 'Deactivate' button.";
		}
		else if (this.buttonDeactivate.Enabled)
		{
			this.textBox3.Text = "You can deactivate this installation of FiatECUScan and move it to another computer. Use the 'Deactivate' button to generate a Removal Key, and then use that key to obtain a new License Key.";
		}
		if (!this.buttonDeactivate.Enabled && this.tbRemoval.Visible)
		{
			this.textBox3.Text = "This installation of FiatECUSCan is DEACTIVATED. Use these Hardware, License and Removal keys to obtain a new License Key at ";
			this.lblLink.Visible = true;
			this.tbSerial.Text = GClass61.smethod_5();
		}
		this.label3.Visible = this.tbRemoval.Visible;
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x0006BC80 File Offset: 0x00069E80
	private void buttonActivate_Click(object sender, EventArgs e)
	{
		GClass16.smethod_9().Replace("5", "-");
		string text = GClass16.smethod_21(GClass3.string_7, this.tbSerial.Text);
		string text2 = this.tbSerial.Text.ToUpper();
		if (text2.StartsWith("MP-"))
		{
			FormDetectCTC formDetectCTC = new FormDetectCTC();
			formDetectCTC.ShowDialog();
			if (!formDetectCTC.bool_1)
			{
				MessageBox.Show("CANtieCAR not found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				base.DialogResult = DialogResult.None;
				return;
			}
		}
		string text3 = GClass62.smethod_17(string.Empty, text);
		if (text3.StartsWith(text))
		{
			GClass61.smethod_6(this.tbSerial.Text);
			GClass61.smethod_8(string.Empty);
			GClass61.smethod_15(GClass61.smethod_12());
			base.DialogResult = DialogResult.OK;
		}
		else if (!GClass3.bool_8 && !GClass3.bool_3)
		{
			text2 = this.string_3 + text2.Replace("5", string.Empty);
			text2 = text2.Replace("-", string.Empty);
			List<string> list = GClass16.smethod_23();
			for (int i = 0; i < list.Count; i++)
			{
				if (text2 == list[i])
				{
					text3 = text;
					GClass61.smethod_6(this.tbSerial.Text);
					break;
				}
			}
		}
		if (text3 != text)
		{
			MessageBox.Show("Invalid License Key!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			base.DialogResult = DialogResult.None;
		}
		else
		{
			GClass61.smethod_8(string.Empty);
			base.DialogResult = DialogResult.OK;
		}
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x000026DC File Offset: 0x000008DC
	private void buttonExit_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x0006BE10 File Offset: 0x0006A010
	private void FormRegistration_Shown(object sender, EventArgs e)
	{
		string text = GClass3.string_7;
		byte[] array = GClass16.smethod_2(text);
		this.method_0();
		for (int i = 0; i < array.Length; i++)
		{
			byte[] array2 = array;
			int num = i;
			array2[num] ^= 49;
			text += GClass16.smethod_0(array[i]);
			if (i == 5 || i == 9 || i == 14)
			{
				text += "-";
			}
		}
		this.tbKey.Text = text.Substring(array.Length * 2);
		if (GClass3.bool_2 && GClass3.bool_3)
		{
			this.textBox4.Text = this.string_0[2];
			this.textBox4.ForeColor = Color.Green;
			this.tbSerial.ReadOnly = true;
			this.tbSerial.Text = GClass61.smethod_5();
			this.buttonActivate.Enabled = false;
		}
		else if (GClass3.bool_3)
		{
			this.textBox4.Text = this.string_0[0];
			this.textBox4.ForeColor = Color.Green;
			this.tbSerial.ReadOnly = true;
			this.tbSerial.Text = GClass61.smethod_5();
			this.buttonActivate.Enabled = false;
		}
		this.string_3 = text.Substring(array.Length * 2);
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x0006BF64 File Offset: 0x0006A164
	private void buttonDeactivate_Click(object sender, EventArgs e)
	{
		string text = this.string_1;
		if (GClass3.bool_2 && GClass3.bool_3)
		{
			text = this.string_2;
		}
		if (MessageBox.Show(text, "License", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
		{
			if (!GClass3.bool_2)
			{
				GClass61.smethod_8(GClass16.smethod_14(GClass3.string_7));
				this.tbRemoval.Text = GClass61.smethod_7();
			}
			else
			{
				GClass61.smethod_6(string.Empty);
			}
			GClass3.bool_3 = false;
			this.method_0();
		}
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x000030B8 File Offset: 0x000012B8
	private void lblLink_MouseClick(object sender, MouseEventArgs e)
	{
		Process.Start("http://www.fiatecuscan.net/TransferLicense.aspx");
	}

	// Token: 0x04000483 RID: 1155
	private string[] string_0 = new string[]
	{
		"REGISTERED",
		"UNREGISTERED",
		"MULTIPLEXED"
	};

	// Token: 0x04000484 RID: 1156
	private string string_1 = "This action will remove the FiatECUScan license from this computer. You can use the generated Removal Key to obtain a new License Key.";

	// Token: 0x04000485 RID: 1157
	private string string_2 = "This action will remove the FiatECUScan license from this computer. You will be able to enter a new License Key (either different or the same) after that.";

	// Token: 0x04000486 RID: 1158
	private string string_3 = string.Empty;
}
