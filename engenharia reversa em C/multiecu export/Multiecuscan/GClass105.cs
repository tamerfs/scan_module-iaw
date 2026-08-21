using System;
using System.Collections.Generic;

// Token: 0x02000084 RID: 132
public class GClass105
{
	// Token: 0x06000444 RID: 1092 RVA: 0x00099698 File Offset: 0x00097898
	public GClass105(string string_1, List<GClass104> list_9)
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
			this.list_6.Add("");
			this.list_7.Add("");
		}
		this.list_3 = new List<GClass106>();
		this.int_0 = -1;
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x000037B6 File Offset: 0x000019B6
	public void method_0(string string_1)
	{
		if (this.list_3.Count == 0)
		{
			return;
		}
		this.list_3[this.list_3.Count - 1].string_0 = string_1;
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x000037E4 File Offset: 0x000019E4
	public void method_1(string string_1)
	{
		if (this.list_3.Count == 0)
		{
			return;
		}
		this.list_3[this.list_3.Count - 1].string_1 = string_1;
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x00003812 File Offset: 0x00001A12
	public void method_2(int int_3)
	{
		this.method_3(int_3, "");
	}

	// Token: 0x06000448 RID: 1096 RVA: 0x000997E0 File Offset: 0x000979E0
	public void method_3(int int_3, string string_1)
	{
		if (this.int_0 == -1)
		{
			this.int_0 = int_3;
		}
		this.int_1 = int_3 - this.int_0;
		this.list_3.Add(new GClass106(this.list_8, int_3 - this.int_0, string_1));
		decimal num = 0m;
		for (int i = 0; i < this.list_8.Count; i++)
		{
			num = this.list_3[this.list_3.Count - 1].list_1[i];
			string value = this.list_3[this.list_3.Count - 1].list_0[i];
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

	// Token: 0x040002DD RID: 733
	public int int_0 = -1;

	// Token: 0x040002DE RID: 734
	public int int_1;

	// Token: 0x040002DF RID: 735
	public string string_0;

	// Token: 0x040002E0 RID: 736
	public bool bool_0;

	// Token: 0x040002E1 RID: 737
	public int int_2 = 1;

	// Token: 0x040002E2 RID: 738
	public List<string> list_0 = new List<string>();

	// Token: 0x040002E3 RID: 739
	public List<string> list_1 = new List<string>();

	// Token: 0x040002E4 RID: 740
	public List<bool[]> list_2 = new List<bool[]>();

	// Token: 0x040002E5 RID: 741
	public List<GClass106> list_3;

	// Token: 0x040002E6 RID: 742
	public List<decimal> list_4 = new List<decimal>();

	// Token: 0x040002E7 RID: 743
	public List<decimal> list_5 = new List<decimal>();

	// Token: 0x040002E8 RID: 744
	public List<string> list_6 = new List<string>();

	// Token: 0x040002E9 RID: 745
	public List<string> list_7 = new List<string>();

	// Token: 0x040002EA RID: 746
	public List<GClass104> list_8 = new List<GClass104>();
}
