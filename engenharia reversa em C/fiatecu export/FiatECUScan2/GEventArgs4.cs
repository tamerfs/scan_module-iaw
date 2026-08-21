using System;

// Token: 0x02000066 RID: 102
public sealed class GEventArgs4 : EventArgs
{
	// Token: 0x06000330 RID: 816 RVA: 0x000032E8 File Offset: 0x000014E8
	public GEventArgs4(bool bool_1)
	{
		this.bool_0 = bool_1;
	}

	// Token: 0x06000331 RID: 817 RVA: 0x000032F7 File Offset: 0x000014F7
	public bool method_0()
	{
		return this.bool_0;
	}

	// Token: 0x040004BA RID: 1210
	private bool bool_0;
}
