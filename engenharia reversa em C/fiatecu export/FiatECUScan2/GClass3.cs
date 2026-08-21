using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

// Token: 0x0200000F RID: 15
public static class GClass3
{
	// Token: 0x06000060 RID: 96 RVA: 0x0001CD38 File Offset: 0x0001AF38
	public static GClass0 smethod_0()
	{
		GClass0 result;
		if (GClass3.list_1.Count < GClass3.int_7 + 1)
		{
			result = null;
		}
		else
		{
			result = GClass3.list_1[GClass3.int_7];
		}
		return result;
	}

	// Token: 0x06000061 RID: 97 RVA: 0x0001CD74 File Offset: 0x0001AF74
	public static int smethod_1()
	{
		return (int)GClass3.stopwatch_0.ElapsedMilliseconds;
	}

	// Token: 0x06000062 RID: 98 RVA: 0x0001CD90 File Offset: 0x0001AF90
	public static void smethod_2(string string_8, int int_9)
	{
		if (int_9 == 0 || int_9 == 1 || int_9 == 2 || int_9 == 3 || int_9 == 4 || int_9 == 5)
		{
			GClass3.stringBuilder_0.Append(string.Concat(new object[]
			{
				"[",
				GClass3.stopwatch_0.ElapsedMilliseconds,
				"] ",
				string_8,
				Environment.NewLine
			}));
			if (int_9 >= 2)
			{
				GClass3.stringBuilder_1.Append(string_8 + Environment.NewLine);
			}
		}
	}

	// Token: 0x06000063 RID: 99 RVA: 0x0001CE20 File Offset: 0x0001B020
	public static void smethod_3()
	{
		int num = 0;
		while (num < GClass3.byte_0.Length && GClass3.byte_0[num] == 0)
		{
			num++;
		}
		if (num != GClass3.byte_0.Length)
		{
			GClass3.byte_0[2 * num + 21] = 0;
		}
	}

	// Token: 0x06000064 RID: 100 RVA: 0x0000280C File Offset: 0x00000A0C
	public static void smethod_4()
	{
		GClass3.stringBuilder_1 = new StringBuilder();
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00002818 File Offset: 0x00000A18
	public static void smethod_5()
	{
		GClass3.stringBuilder_0 = new StringBuilder();
	}

	// Token: 0x06000066 RID: 102 RVA: 0x0001CE68 File Offset: 0x0001B068
	public static string smethod_6()
	{
		return GClass3.stringBuilder_0.ToString();
	}

	// Token: 0x06000067 RID: 103 RVA: 0x0001CE84 File Offset: 0x0001B084
	public static int smethod_7()
	{
		return GClass3.stringBuilder_0.Length;
	}

	// Token: 0x06000068 RID: 104 RVA: 0x0001CEA0 File Offset: 0x0001B0A0
	public static void smethod_8()
	{
		if (GClass3.stringBuilder_1.Length >= 5 && GClass3.bool_3)
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
				streamWriter.Write(GClass3.stringBuilder_1.ToString());
				streamWriter.Close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000069 RID: 105 RVA: 0x000026DC File Offset: 0x000008DC
	public static void smethod_9()
	{
	}

	// Token: 0x04000052 RID: 82
	public static bool bool_0 = false;

	// Token: 0x04000053 RID: 83
	public static string string_0 = "FiatECUScan";

	// Token: 0x04000054 RID: 84
	public static StringBuilder stringBuilder_0 = new StringBuilder();

	// Token: 0x04000055 RID: 85
	public static StringBuilder stringBuilder_1 = new StringBuilder();

	// Token: 0x04000056 RID: 86
	public static string string_1 = "http://www.fiatecuscan.net/CheckCurVerNum.aspx";

	// Token: 0x04000057 RID: 87
	public static bool bool_1 = false;

	// Token: 0x04000058 RID: 88
	public static int int_0 = 0;

	// Token: 0x04000059 RID: 89
	public static bool bool_2 = false;

	// Token: 0x0400005A RID: 90
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

	// Token: 0x0400005B RID: 91
	public static int int_2 = 0;

	// Token: 0x0400005C RID: 92
	public static int int_3 = 0;

	// Token: 0x0400005D RID: 93
	public static int int_4 = 500;

	// Token: 0x0400005E RID: 94
	public static int int_5 = 0;

	// Token: 0x0400005F RID: 95
	public static int int_6 = 0;

	// Token: 0x04000060 RID: 96
	public static bool bool_3 = false;

	// Token: 0x04000061 RID: 97
	public static bool bool_4 = false;

	// Token: 0x04000062 RID: 98
	public static bool bool_5 = false;

	// Token: 0x04000063 RID: 99
	public static bool bool_6 = true;

	// Token: 0x04000064 RID: 100
	public static bool bool_7 = false;

	// Token: 0x04000065 RID: 101
	public static bool bool_8 = true;

	// Token: 0x04000066 RID: 102
	public static bool bool_9 = false;

	// Token: 0x04000067 RID: 103
	public static bool bool_10 = false;

	// Token: 0x04000068 RID: 104
	public static List<GClass58> list_0 = new List<GClass58>();

	// Token: 0x04000069 RID: 105
	public static bool bool_11 = false;

	// Token: 0x0400006A RID: 106
	public static bool bool_12 = false;

	// Token: 0x0400006B RID: 107
	public static List<GClass0> list_1 = new List<GClass0>();

	// Token: 0x0400006C RID: 108
	public static int int_7 = 0;

	// Token: 0x0400006D RID: 109
	public static Stopwatch stopwatch_0;

	// Token: 0x0400006E RID: 110
	public static string string_2 = string.Empty;

	// Token: 0x0400006F RID: 111
	public static string string_3 = string.Empty;

	// Token: 0x04000070 RID: 112
	public static string string_4 = string.Empty;

	// Token: 0x04000071 RID: 113
	public static string string_5 = string.Empty;

	// Token: 0x04000072 RID: 114
	public static string string_6 = string.Empty;

	// Token: 0x04000073 RID: 115
	public static int int_8 = -1;

	// Token: 0x04000074 RID: 116
	public static string string_7 = "74126-E079B-627D07";

	// Token: 0x04000075 RID: 117
	public static byte[] byte_0 = GClass16.smethod_2("EB D5 FD 7F E4 11 76 0F 00 CE D7 36 34 C6 DA A6 8D D6 A5 B8");

	// Token: 0x04000076 RID: 118
	public static byte[] byte_1 = GClass16.smethod_2("36 60 31 D6 A5 A4 EB A4 9F B0 C5 0D 08 F9 EA FF 0B 1F 20 23");

	// Token: 0x04000077 RID: 119
	public static byte[] byte_2 = GClass16.smethod_2("A8 1D C5 B7 77 BB B3 70 46 71 09 4D B2 37 6D F3 39 9D C9 1C");

	// Token: 0x04000078 RID: 120
	public static bool bool_13 = false;

	// Token: 0x04000079 RID: 121
	public static bool bool_14 = false;
}
