using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x0200005D RID: 93
public sealed partial class FormDisclaimer : Form
{
	// Token: 0x06000287 RID: 647 RVA: 0x00002F80 File Offset: 0x00001180
	public FormDisclaimer()
	{
		this.InitializeComponent();
		this.rtbDisclaimer.Rtf = Class16.smethod_3();
	}

	// Token: 0x0600028A RID: 650 RVA: 0x00002FCA File Offset: 0x000011CA
	private void btnClose_Click(object sender, EventArgs e)
	{
		GClass61.smethod_54(this.chkShow.Checked);
	}

	// Token: 0x0600028B RID: 651 RVA: 0x00002FDC File Offset: 0x000011DC
	private void rtbDisclaimer_LinkClicked(object sender, LinkClickedEventArgs e)
	{
		Process.Start(e.LinkText);
	}

	// Token: 0x0600028C RID: 652 RVA: 0x00002FEA File Offset: 0x000011EA
	private void lblLink_MouseClick(object sender, MouseEventArgs e)
	{
		Process.Start("http://www.fiatecuscan.net/Register.aspx");
	}

	// Token: 0x0600028D RID: 653 RVA: 0x00002FF7 File Offset: 0x000011F7
	private void label3_MouseClick(object sender, MouseEventArgs e)
	{
		Process.Start("http://www.fiatecuscan.net/Distributors.aspx");
	}
}
