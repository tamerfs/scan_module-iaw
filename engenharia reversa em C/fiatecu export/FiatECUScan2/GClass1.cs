using System;
using System.Windows.Forms;

// Token: 0x02000004 RID: 4
public sealed class GClass1 : Label
{
	// Token: 0x0600000D RID: 13 RVA: 0x00002777 File Offset: 0x00000977
	public GClass1()
	{
		this.AutoSize = false;
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000058C8 File Offset: 0x00003AC8
	public int method_0()
	{
		return this.int_0;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x0000278D File Offset: 0x0000098D
	public void method_1(int int_1)
	{
		this.int_0 = int_1;
	}

	// Token: 0x0400001C RID: 28
	private int int_0 = 0;
}
