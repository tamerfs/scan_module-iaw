using System;
using System.Runtime.InteropServices;

// Token: 0x020000EE RID: 238
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple = true, Inherited = false)]
[ComVisible(true)]
internal sealed class Attribute0 : Attribute
{
	// Token: 0x06000808 RID: 2056 RVA: 0x000053CF File Offset: 0x000035CF
	public bool method_0()
	{
		return this.bool_0;
	}

	// Token: 0x06000809 RID: 2057 RVA: 0x000053D7 File Offset: 0x000035D7
	public void method_1(bool bool_3)
	{
		this.bool_0 = bool_3;
	}

	// Token: 0x0600080A RID: 2058 RVA: 0x000053E0 File Offset: 0x000035E0
	public bool method_2()
	{
		return this.bool_1;
	}

	// Token: 0x0600080B RID: 2059 RVA: 0x000053E8 File Offset: 0x000035E8
	public void method_3(bool bool_3)
	{
		this.bool_1 = bool_3;
	}

	// Token: 0x0600080C RID: 2060 RVA: 0x000053F1 File Offset: 0x000035F1
	public string method_4()
	{
		return this.string_0;
	}

	// Token: 0x0600080D RID: 2061 RVA: 0x000053F9 File Offset: 0x000035F9
	public void method_5(string string_1)
	{
		this.string_0 = string_1;
	}

	// Token: 0x0600080E RID: 2062 RVA: 0x00005402 File Offset: 0x00003602
	public bool method_6()
	{
		return this.bool_2;
	}

	// Token: 0x0600080F RID: 2063 RVA: 0x0000540A File Offset: 0x0000360A
	public void method_7(bool bool_3)
	{
		this.bool_2 = bool_3;
	}

	// Token: 0x040007A6 RID: 1958
	private bool bool_0 = true;

	// Token: 0x040007A7 RID: 1959
	private bool bool_1 = true;

	// Token: 0x040007A8 RID: 1960
	private bool bool_2 = true;

	// Token: 0x040007A9 RID: 1961
	private string string_0 = "";
}
