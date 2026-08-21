using System;

// Token: 0x02000024 RID: 36
public class GEventArgs4 : EventArgs
{
	// Token: 0x0600022E RID: 558 RVA: 0x00002F4F File Offset: 0x0000114F
	public GEventArgs4(bool bool_1)
	{
		this.bool_0 = bool_1;
	}

	// Token: 0x0600022F RID: 559 RVA: 0x00002F5E File Offset: 0x0000115E
	public bool method_0()
	{
		return this.bool_0;
	}

	// Token: 0x0400019B RID: 411
	private bool bool_0;
}
