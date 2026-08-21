using System;

// Token: 0x02000025 RID: 37
public sealed class GClass53
{
	// Token: 0x060001A0 RID: 416 RVA: 0x00002DD8 File Offset: 0x00000FD8
	public GClass53(GClass58 gclass58_1)
	{
		this.gclass58_0 = gclass58_1;
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x00050ADC File Offset: 0x0004ECDC
	public string method_0()
	{
		return this.gclass58_0.string_0;
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x00002DE7 File Offset: 0x00000FE7
	public void method_1(string string_0)
	{
		this.gclass58_0.string_0 = string_0;
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x00050AF8 File Offset: 0x0004ECF8
	public string method_2()
	{
		return this.gclass58_0.method_0() + " " + this.gclass58_0.string_3;
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x00002DF5 File Offset: 0x00000FF5
	public void method_3(string string_0)
	{
		this.gclass58_0.method_1(string_0);
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x00050B28 File Offset: 0x0004ED28
	public GClass58 method_4()
	{
		return this.gclass58_0;
	}

	// Token: 0x04000177 RID: 375
	private GClass58 gclass58_0;
}
