using System;

// Token: 0x0200007F RID: 127
public class GClass101
{
	// Token: 0x06000404 RID: 1028 RVA: 0x00003514 File Offset: 0x00001714
	public GClass101(int int_1, decimal decimal_1)
	{
		this.int_0 = int_1;
		this.decimal_0 = decimal_1;
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x0000352A File Offset: 0x0000172A
	public override string ToString()
	{
		return this.decimal_0.ToString() ?? "";
	}

	// Token: 0x040002B2 RID: 690
	public int int_0;

	// Token: 0x040002B3 RID: 691
	public decimal decimal_0;
}
