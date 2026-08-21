using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FiatECUScan2;

// Token: 0x02000088 RID: 136
public sealed partial class FormTemplates : Form
{
	// Token: 0x060004F1 RID: 1265 RVA: 0x00003923 File Offset: 0x00001B23
	public FormTemplates(List<SimpleValueData> list_0)
	{
		this.InitializeComponent();
		this.dgvTemplates.DataSource = list_0;
	}

	// Token: 0x060004F2 RID: 1266 RVA: 0x000026DC File Offset: 0x000008DC
	private void buttonOK_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x060004F3 RID: 1267 RVA: 0x00003944 File Offset: 0x00001B44
	private void FormTemplates_Shown(object sender, EventArgs e)
	{
		this.dgvTemplates.Refresh();
	}
}
