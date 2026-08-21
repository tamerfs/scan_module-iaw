using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Multiecuscan;

// Token: 0x0200007D RID: 125
internal static class Class7
{
	// Token: 0x060003FC RID: 1020 RVA: 0x00003448 File Offset: 0x00001648
	internal static void smethod_0(List<GClass101> list_0)
	{
		list_0.Sort(new Comparison<GClass101>(Class7.Class8.<>9.method_0));
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x0000346F File Offset: 0x0000166F
	internal static void smethod_1(List<TableDataRowP> list_0)
	{
		list_0.Sort(new Comparison<TableDataRowP>(Class7.Class8.<>9.method_1));
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x00003496 File Offset: 0x00001696
	internal static void smethod_2(List<TableDataRowP> list_0)
	{
		list_0.Sort(new Comparison<TableDataRowP>(Class7.Class8.<>9.method_2));
	}

	// Token: 0x0200007E RID: 126
	[CompilerGenerated]
	[Serializable]
	private sealed class Class8
	{
		// Token: 0x06000401 RID: 1025 RVA: 0x000034C9 File Offset: 0x000016C9
		internal int method_0(GClass101 p1, GClass101 p2)
		{
			if (p1.decimal_0 == p2.decimal_0)
			{
				return p1.int_0.CompareTo(p2.int_0);
			}
			return p1.decimal_0.CompareTo(p2.decimal_0);
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00003501 File Offset: 0x00001701
		internal int method_1(TableDataRowP p1, TableDataRowP p2)
		{
			return p1.Name.CompareTo(p2.Name);
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00098DC4 File Offset: 0x00096FC4
		internal int method_2(TableDataRowP p1, TableDataRowP p2)
		{
			string text = p1.getDataItem().string_3;
			string text2 = p2.getDataItem().string_3;
			if (p1.getDataItem().string_3 == "")
			{
				text = "ZZZZZZZZZZZZZZZ";
			}
			if (p2.getDataItem().string_3 == "")
			{
				text2 = "ZZZZZZZZZZZZZZZ";
			}
			if (text == text2)
			{
				return p1.Name.CompareTo(p2.Name);
			}
			return text.CompareTo(text2);
		}

		// Token: 0x040002AE RID: 686
		public static readonly Class7.Class8 <>9 = new Class7.Class8();

		// Token: 0x040002AF RID: 687
		public static Comparison<GClass101> <>9__0_0;

		// Token: 0x040002B0 RID: 688
		public static Comparison<TableDataRowP> <>9__1_0;

		// Token: 0x040002B1 RID: 689
		public static Comparison<TableDataRowP> <>9__2_0;
	}
}
