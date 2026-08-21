using System;
using System.Collections.Generic;

// Token: 0x02000058 RID: 88
public sealed class GClass56
{
	// Token: 0x06000263 RID: 611 RVA: 0x0006086C File Offset: 0x0005EA6C
	public GClass56(List<GClass58> list_2, int int_1, string string_2)
	{
		this.int_0 = int_1;
		this.string_1 = string_2;
		decimal item = 0m;
		for (int i = 0; i < list_2.Count; i++)
		{
			this.list_0.Add(list_2[i].method_0());
			item = 0m;
			try
			{
				item = Convert.ToDecimal(list_2[i].method_0());
			}
			catch (Exception)
			{
			}
			this.list_1.Add(item);
		}
	}

	// Token: 0x040003BB RID: 955
	public int int_0;

	// Token: 0x040003BC RID: 956
	public string string_0 = string.Empty;

	// Token: 0x040003BD RID: 957
	public string string_1 = string.Empty;

	// Token: 0x040003BE RID: 958
	public List<string> list_0 = new List<string>();

	// Token: 0x040003BF RID: 959
	public List<decimal> list_1 = new List<decimal>();
}
