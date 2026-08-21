using System;

// Token: 0x02000003 RID: 3
public class GEventArgs1 : EventArgs
{
	// Token: 0x06000002 RID: 2 RVA: 0x00002CF4 File Offset: 0x00000EF4
	public GEventArgs1(bool bool_1)
	{
		this.bool_0 = bool_1;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002D03 File Offset: 0x00000F03
	public bool method_0()
	{
		return this.bool_0;
	}

	// Token: 0x04000001 RID: 1
	private bool bool_0;
}
