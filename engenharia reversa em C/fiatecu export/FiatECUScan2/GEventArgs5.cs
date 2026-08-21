using System;

// Token: 0x02000067 RID: 103
public sealed class GEventArgs5 : EventArgs
{
	// Token: 0x06000332 RID: 818 RVA: 0x000032FF File Offset: 0x000014FF
	public GEventArgs5(bool bool_1, string string_2, string string_3)
	{
		this.bool_0 = bool_1;
		this.string_0 = string_2;
		this.string_1 = string_3;
	}

	// Token: 0x06000333 RID: 819 RVA: 0x0000331C File Offset: 0x0000151C
	public bool method_0()
	{
		return this.bool_0;
	}

	// Token: 0x06000334 RID: 820 RVA: 0x0006DEA4 File Offset: 0x0006C0A4
	public string method_1()
	{
		return this.string_0;
	}

	// Token: 0x06000335 RID: 821 RVA: 0x0006DEBC File Offset: 0x0006C0BC
	public string method_2()
	{
		return this.string_1;
	}

	// Token: 0x040004BB RID: 1211
	private bool bool_0;

	// Token: 0x040004BC RID: 1212
	private string string_0;

	// Token: 0x040004BD RID: 1213
	private string string_1;
}
