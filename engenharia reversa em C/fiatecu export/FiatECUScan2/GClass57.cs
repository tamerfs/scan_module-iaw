using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

// Token: 0x0200005C RID: 92
public static class GClass57
{
	// Token: 0x0600027E RID: 638 RVA: 0x0006306C File Offset: 0x0006126C
	public static GClass0 smethod_0()
	{
		GClass0 result;
		if (GClass57.list_1.Count < GClass57.int_7 + 1)
		{
			result = null;
		}
		else
		{
			result = GClass57.list_1[GClass57.int_7];
		}
		return result;
	}

	// Token: 0x0600027F RID: 639 RVA: 0x000630A8 File Offset: 0x000612A8
	public static int smethod_1()
	{
		return (int)GClass57.stopwatch_0.ElapsedMilliseconds;
	}

	// Token: 0x06000280 RID: 640 RVA: 0x000630C4 File Offset: 0x000612C4
	public static void smethod_2(string string_6, int int_9)
	{
		if (int_9 == 0 || int_9 == 1 || int_9 == 2 || int_9 == 3 || int_9 == 4 || int_9 == 5)
		{
			GClass57.stringBuilder_0.Append(string.Concat(new object[]
			{
				"[",
				GClass57.stopwatch_0.ElapsedMilliseconds,
				"] ",
				string_6,
				Environment.NewLine
			}));
			if (int_9 >= 2)
			{
				GClass57.stringBuilder_1.Append(string_6 + Environment.NewLine);
			}
		}
	}

	// Token: 0x06000281 RID: 641 RVA: 0x00002F68 File Offset: 0x00001168
	public static void smethod_3()
	{
		GClass57.stringBuilder_1 = new StringBuilder();
	}

	// Token: 0x06000282 RID: 642 RVA: 0x00002F74 File Offset: 0x00001174
	public static void smethod_4()
	{
		GClass57.stringBuilder_0 = new StringBuilder();
	}

	// Token: 0x06000283 RID: 643 RVA: 0x00063154 File Offset: 0x00061354
	public static string smethod_5()
	{
		return GClass57.stringBuilder_0.ToString();
	}

	// Token: 0x06000284 RID: 644 RVA: 0x00063170 File Offset: 0x00061370
	public static int smethod_6()
	{
		return GClass57.stringBuilder_0.Length;
	}

	// Token: 0x06000285 RID: 645 RVA: 0x0006318C File Offset: 0x0006138C
	public static void smethod_7()
	{
		if (GClass57.stringBuilder_1.Length >= 5 && GClass57.bool_1)
		{
			DateTime now = DateTime.Now;
			try
			{
				StreamWriter streamWriter = new StreamWriter(string.Concat(new string[]
				{
					GClass61.smethod_26(),
					"\\FESLog_",
					now.ToString("yyMMddHHmm"),
					"_",
					GClass3.string_2.Replace("/", string.Empty),
					".txt"
				}));
				streamWriter.Write(GClass57.stringBuilder_1.ToString());
				streamWriter.Close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000286 RID: 646 RVA: 0x000026DC File Offset: 0x000008DC
	public static void smethod_8()
	{
	}

	// Token: 0x040003C7 RID: 967
	public static bool bool_0 = false;

	// Token: 0x040003C8 RID: 968
	public static string string_0 = "FiatECUScan";

	// Token: 0x040003C9 RID: 969
	public static StringBuilder stringBuilder_0 = new StringBuilder();

	// Token: 0x040003CA RID: 970
	public static StringBuilder stringBuilder_1 = new StringBuilder();

	// Token: 0x040003CB RID: 971
	public static string string_1 = "http://www.fiatecuscan.net/CheckCurVerNum.aspx";

	// Token: 0x040003CC RID: 972
	public static int int_0 = 0;

	// Token: 0x040003CD RID: 973
	public static int[] int_1 = new int[]
	{
		3000,
		2000,
		1000,
		750,
		600,
		500,
		400,
		350,
		300,
		280,
		250,
		220,
		200,
		180,
		150,
		141,
		133,
		120,
		100,
		86,
		80,
		75,
		71,
		67
	};

	// Token: 0x040003CE RID: 974
	public static int int_2 = 0;

	// Token: 0x040003CF RID: 975
	public static int int_3 = 0;

	// Token: 0x040003D0 RID: 976
	public static int int_4 = 500;

	// Token: 0x040003D1 RID: 977
	public static int int_5 = 0;

	// Token: 0x040003D2 RID: 978
	public static int int_6 = 0;

	// Token: 0x040003D3 RID: 979
	public static bool bool_1 = false;

	// Token: 0x040003D4 RID: 980
	public static bool bool_2 = false;

	// Token: 0x040003D5 RID: 981
	public static bool bool_3 = false;

	// Token: 0x040003D6 RID: 982
	public static bool bool_4 = true;

	// Token: 0x040003D7 RID: 983
	public static bool bool_5 = false;

	// Token: 0x040003D8 RID: 984
	public static bool bool_6 = false;

	// Token: 0x040003D9 RID: 985
	public static List<GClass58> list_0 = new List<GClass58>();

	// Token: 0x040003DA RID: 986
	public static bool bool_7 = false;

	// Token: 0x040003DB RID: 987
	public static bool bool_8 = false;

	// Token: 0x040003DC RID: 988
	public static List<GClass0> list_1 = new List<GClass0>();

	// Token: 0x040003DD RID: 989
	public static int int_7 = 0;

	// Token: 0x040003DE RID: 990
	public static Stopwatch stopwatch_0;

	// Token: 0x040003DF RID: 991
	public static string string_2 = string.Empty;

	// Token: 0x040003E0 RID: 992
	public static string string_3 = string.Empty;

	// Token: 0x040003E1 RID: 993
	public static string string_4 = string.Empty;

	// Token: 0x040003E2 RID: 994
	public static int int_8 = -1;

	// Token: 0x040003E3 RID: 995
	public static string string_5 = "74126-E079B-627D07";

	// Token: 0x040003E4 RID: 996
	public static bool bool_9 = false;
}
