using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Globalization;
using System.Resources;

// Token: 0x0200008E RID: 142
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
[DebuggerNonUserCode]
internal sealed class Class16
{
	// Token: 0x06000521 RID: 1313 RVA: 0x00002A8A File Offset: 0x00000C8A
	internal Class16()
	{
	}

	// Token: 0x06000522 RID: 1314 RVA: 0x00095C0C File Offset: 0x00093E0C
	internal static ResourceManager smethod_0()
	{
		if (object.ReferenceEquals(Class16.resourceManager_0, null))
		{
			ResourceManager resourceManager = new ResourceManager("FiatECUScan2.Properties.Resources", typeof(Class16).Assembly);
			Class16.resourceManager_0 = resourceManager;
		}
		return Class16.resourceManager_0;
	}

	// Token: 0x06000523 RID: 1315 RVA: 0x00095C50 File Offset: 0x00093E50
	internal static CultureInfo smethod_1()
	{
		return Class16.cultureInfo_0;
	}

	// Token: 0x06000524 RID: 1316 RVA: 0x000039B7 File Offset: 0x00001BB7
	internal static void smethod_2(CultureInfo cultureInfo_1)
	{
		Class16.cultureInfo_0 = cultureInfo_1;
	}

	// Token: 0x06000525 RID: 1317 RVA: 0x00095C64 File Offset: 0x00093E64
	internal static string smethod_3()
	{
		return Class16.smethod_0().GetString("StringDisclaimer", Class16.cultureInfo_0);
	}

	// Token: 0x04000673 RID: 1651
	private static ResourceManager resourceManager_0;

	// Token: 0x04000674 RID: 1652
	private static CultureInfo cultureInfo_0;
}
