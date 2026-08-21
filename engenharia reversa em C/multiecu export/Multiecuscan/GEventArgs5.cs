using System;

// Token: 0x02000025 RID: 37
public class GEventArgs5 : EventArgs
{
	// Token: 0x06000230 RID: 560 RVA: 0x00002F66 File Offset: 0x00001166
	public GEventArgs5(bool bool_1, string string_2, string string_3)
	{
		this.bool_0 = bool_1;
		this.string_0 = string_2;
		this.string_1 = string_3;
	}

	// Token: 0x06000231 RID: 561 RVA: 0x00002F83 File Offset: 0x00001183
	public bool method_0()
	{
		return this.bool_0;
	}

	// Token: 0x06000232 RID: 562 RVA: 0x00002F8B File Offset: 0x0000118B
	public string method_1()
	{
		return this.string_0;
	}

	// Token: 0x06000233 RID: 563 RVA: 0x00002F93 File Offset: 0x00001193
	public string method_2()
	{
		return this.string_1;
	}

	// Token: 0x0400019C RID: 412
	private bool bool_0;

	// Token: 0x0400019D RID: 413
	private string string_0;

	// Token: 0x0400019E RID: 414
	private string string_1;
}
