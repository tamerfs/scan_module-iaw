using System;
using System.Collections.Generic;

// Token: 0x02000085 RID: 133
public class GClass106
{
	// Token: 0x06000449 RID: 1097 RVA: 0x0009993C File Offset: 0x00097B3C
	public GClass106(List<GClass104> list_2, int int_1, string string_2)
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

	// Token: 0x040002EB RID: 747
	public int int_0;

	// Token: 0x040002EC RID: 748
	public string string_0 = "";

	// Token: 0x040002ED RID: 749
	public string string_1 = "";

	// Token: 0x040002EE RID: 750
	public List<string> list_0 = new List<string>();

	// Token: 0x040002EF RID: 751
	public List<decimal> list_1 = new List<decimal>();
}
