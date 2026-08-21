using System;

// Token: 0x02000008 RID: 8
public sealed class GEventArgs2 : EventArgs
{
	// Token: 0x0600001F RID: 31 RVA: 0x000027DF File Offset: 0x000009DF
	public GEventArgs2(bool bool_1, string string_2, string string_3)
	{
		this.bool_0 = bool_1;
		this.string_0 = string_2;
		this.string_1 = string_3;
	}

	// Token: 0x06000020 RID: 32 RVA: 0x000027FC File Offset: 0x000009FC
	public bool method_0()
	{
		return this.bool_0;
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00017F94 File Offset: 0x00016194
	public string method_1()
	{
		return this.string_0;
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00017FAC File Offset: 0x000161AC
	public string method_2()
	{
		return this.string_1;
	}

	// Token: 0x04000026 RID: 38
	private bool bool_0;

	// Token: 0x04000027 RID: 39
	private string string_0;

	// Token: 0x04000028 RID: 40
	private string string_1;
}
