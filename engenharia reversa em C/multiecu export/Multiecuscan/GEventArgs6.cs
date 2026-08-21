using System;

// Token: 0x02000026 RID: 38
public class GEventArgs6 : EventArgs
{
	// Token: 0x06000234 RID: 564 RVA: 0x00002F9B File Offset: 0x0000119B
	public GEventArgs6(GClass100 gclass100_1)
	{
		this.gclass100_0 = gclass100_1;
	}

	// Token: 0x06000235 RID: 565 RVA: 0x00002FAA File Offset: 0x000011AA
	public GClass100 method_0()
	{
		return this.gclass100_0;
	}

	// Token: 0x0400019F RID: 415
	private GClass100 gclass100_0;
}
