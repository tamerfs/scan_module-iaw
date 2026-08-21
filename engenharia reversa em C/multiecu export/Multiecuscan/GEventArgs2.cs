using System;

// Token: 0x02000004 RID: 4
public class GEventArgs2 : EventArgs
{
	// Token: 0x06000004 RID: 4 RVA: 0x00002D0B File Offset: 0x00000F0B
	public GEventArgs2(bool bool_1, string string_2, string string_3)
	{
		this.bool_0 = bool_1;
		this.string_0 = string_2;
		this.string_1 = string_3;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002D28 File Offset: 0x00000F28
	public bool method_0()
	{
		return this.bool_0;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002D30 File Offset: 0x00000F30
	public string method_1()
	{
		return this.string_0;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002D38 File Offset: 0x00000F38
	public string method_2()
	{
		return this.string_1;
	}

	// Token: 0x04000002 RID: 2
	private bool bool_0;

	// Token: 0x04000003 RID: 3
	private string string_0;

	// Token: 0x04000004 RID: 4
	private string string_1;
}
