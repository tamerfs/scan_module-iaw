using System;
using System.Collections.Generic;

// Token: 0x02000003 RID: 3
public sealed class GClass0
{
	// Token: 0x06000008 RID: 8 RVA: 0x00005600 File Offset: 0x00003800
	public GClass0(string string_1, List<GClass58> list_9)
	{
		this.string_0 = string_1;
		for (int i = 0; i < list_9.Count; i++)
		{
			this.list_8.Add(list_9[i]);
			this.list_0.Add(list_9[i].string_0);
			this.list_1.Add(list_9[i].string_3);
			this.list_2.Add(new bool[]
			{
				true,
				true,
				true,
				true
			});
			this.list_4.Add(0m);
			this.list_5.Add(0m);
			this.list_6.Add(string.Empty);
			this.list_7.Add(string.Empty);
		}
		this.list_3 = new List<GClass56>();
		this.int_0 = -1;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002703 File Offset: 0x00000903
	public void method_0(string string_1)
	{
		if (this.list_3.Count != 0)
		{
			this.list_3[this.list_3.Count - 1].string_0 = string_1;
		}
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002736 File Offset: 0x00000936
	public void method_1(string string_1)
	{
		if (this.list_3.Count != 0)
		{
			this.list_3[this.list_3.Count - 1].string_1 = string_1;
		}
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002769 File Offset: 0x00000969
	public void method_2(int int_3)
	{
		this.method_3(int_3, string.Empty);
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00005758 File Offset: 0x00003958
	public void method_3(int int_3, string string_1)
	{
		if (this.int_0 == -1)
		{
			this.int_0 = int_3;
		}
		this.int_1 = int_3 - this.int_0;
		this.list_3.Add(new GClass56(this.list_8, int_3 - this.int_0, string_1));
		string value = string.Empty;
		for (int i = 0; i < this.list_8.Count; i++)
		{
			decimal num = this.list_3[this.list_3.Count - 1].list_1[i];
			value = this.list_3[this.list_3.Count - 1].list_0[i];
			if (this.list_3.Count == 1)
			{
				this.list_4[i] = num;
				this.list_5[i] = num;
				this.list_6[i] = value;
				this.list_7[i] = value;
			}
			else
			{
				if (this.list_4[i] > num)
				{
					this.list_4[i] = num;
					this.list_6[i] = value;
				}
				if (this.list_5[i] < num)
				{
					this.list_5[i] = num;
					this.list_7[i] = value;
				}
			}
		}
	}

	// Token: 0x0400000E RID: 14
	public int int_0 = -1;

	// Token: 0x0400000F RID: 15
	public int int_1 = 0;

	// Token: 0x04000010 RID: 16
	public string string_0;

	// Token: 0x04000011 RID: 17
	public bool bool_0 = false;

	// Token: 0x04000012 RID: 18
	public int int_2 = 1;

	// Token: 0x04000013 RID: 19
	public List<string> list_0 = new List<string>();

	// Token: 0x04000014 RID: 20
	public List<string> list_1 = new List<string>();

	// Token: 0x04000015 RID: 21
	public List<bool[]> list_2 = new List<bool[]>();

	// Token: 0x04000016 RID: 22
	public List<GClass56> list_3;

	// Token: 0x04000017 RID: 23
	public List<decimal> list_4 = new List<decimal>();

	// Token: 0x04000018 RID: 24
	public List<decimal> list_5 = new List<decimal>();

	// Token: 0x04000019 RID: 25
	public List<string> list_6 = new List<string>();

	// Token: 0x0400001A RID: 26
	public List<string> list_7 = new List<string>();

	// Token: 0x0400001B RID: 27
	public List<GClass58> list_8 = new List<GClass58>();
}
