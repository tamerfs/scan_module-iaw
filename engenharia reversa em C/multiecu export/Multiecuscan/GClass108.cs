using System;

// Token: 0x02000089 RID: 137
public class GClass108
{
	// Token: 0x0600045F RID: 1119 RVA: 0x00003929 File Offset: 0x00001B29
	public GClass108(GClass104 gclass104_1)
	{
		this.gclass104_0 = gclass104_1;
	}

	// Token: 0x06000460 RID: 1120 RVA: 0x00003938 File Offset: 0x00001B38
	public string method_0()
	{
		return this.gclass104_0.string_0;
	}

	// Token: 0x06000461 RID: 1121 RVA: 0x00003945 File Offset: 0x00001B45
	public void method_1(string string_0)
	{
		this.gclass104_0.string_0 = string_0;
	}

	// Token: 0x06000462 RID: 1122 RVA: 0x00003953 File Offset: 0x00001B53
	public string method_2()
	{
		return this.gclass104_0.method_0() + " " + this.gclass104_0.string_3;
	}

	// Token: 0x06000463 RID: 1123 RVA: 0x00003975 File Offset: 0x00001B75
	public void method_3(string string_0)
	{
		this.gclass104_0.method_1(string_0);
	}

	// Token: 0x06000464 RID: 1124 RVA: 0x00003983 File Offset: 0x00001B83
	public GClass104 method_4()
	{
		return this.gclass104_0;
	}

	// Token: 0x040002F5 RID: 757
	private GClass104 gclass104_0;
}
