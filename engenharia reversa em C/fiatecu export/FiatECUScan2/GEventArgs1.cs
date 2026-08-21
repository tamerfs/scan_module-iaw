using System;

// Token: 0x02000007 RID: 7
public sealed class GEventArgs1 : EventArgs
{
	// Token: 0x0600001D RID: 29 RVA: 0x000027C8 File Offset: 0x000009C8
	public GEventArgs1(bool bool_1)
	{
		this.bool_0 = bool_1;
	}

	// Token: 0x0600001E RID: 30 RVA: 0x000027D7 File Offset: 0x000009D7
	public bool method_0()
	{
		return this.bool_0;
	}

	// Token: 0x04000025 RID: 37
	private bool bool_0;
}
