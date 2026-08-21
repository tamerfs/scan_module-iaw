using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

// Token: 0x020000C4 RID: 196
public static class GClass123
{
	// Token: 0x060006EE RID: 1774 RVA: 0x000E7D58 File Offset: 0x000E5F58
	public static int smethod_0()
	{
		GClass126.byte_0 = new byte[0];
		if (GClass126.byte_3[3] == 165)
		{
			GClass126.byte_0 = new byte[GClass123.byte_0.Length];
			for (int i = 0; i < GClass123.byte_0.Length; i++)
			{
				GClass126.byte_0[GClass123.byte_0.Length - i - 1] = GClass123.byte_0[i];
			}
		}
		return GClass126.byte_3.Length;
	}

	// Token: 0x060006EF RID: 1775 RVA: 0x000049D9 File Offset: 0x00002BD9
	public static GClass105 smethod_1()
	{
		if (GClass123.list_1.Count < GClass123.int_8 + 1)
		{
			return null;
		}
		return GClass123.list_1[GClass123.int_8];
	}

	// Token: 0x060006F0 RID: 1776 RVA: 0x000049FF File Offset: 0x00002BFF
	public static int smethod_2()
	{
		return (int)GClass123.stopwatch_0.ElapsedMilliseconds;
	}

	// Token: 0x060006F1 RID: 1777 RVA: 0x000E7DC0 File Offset: 0x000E5FC0
	public static int smethod_3(string string_6)
	{
		int num = 3;
		if (string_6 == "multiecuscan.exe" || string_6 == "multiecuscan.vshost.exe")
		{
			num -= 2;
		}
		GClass123.int_1 = num;
		return num;
	}

	// Token: 0x060006F2 RID: 1778 RVA: 0x000E7DF4 File Offset: 0x000E5FF4
	public static void smethod_4(string string_6, int int_10)
	{
		if (int_10 == 0 || int_10 == 1 || int_10 == 2 || int_10 == 3 || int_10 == 4 || int_10 == 5)
		{
			GClass123.stringBuilder_0.Append(string.Concat(new string[]
			{
				"[",
				GClass123.stopwatch_0.ElapsedMilliseconds.ToString(),
				"] ",
				string_6,
				Environment.NewLine
			}));
			if (int_10 >= 2)
			{
				GClass123.stringBuilder_1.Append(string_6 + Environment.NewLine);
			}
		}
	}

	// Token: 0x060006F3 RID: 1779 RVA: 0x00004A0C File Offset: 0x00002C0C
	public static void smethod_5()
	{
		GClass123.stringBuilder_1 = new StringBuilder();
	}

	// Token: 0x060006F4 RID: 1780 RVA: 0x00004A18 File Offset: 0x00002C18
	public static void smethod_6()
	{
		GClass123.stringBuilder_0 = new StringBuilder();
	}

	// Token: 0x060006F5 RID: 1781 RVA: 0x00004A24 File Offset: 0x00002C24
	public static string smethod_7()
	{
		return GClass123.stringBuilder_0.ToString();
	}

	// Token: 0x060006F6 RID: 1782 RVA: 0x00004A30 File Offset: 0x00002C30
	public static int smethod_8()
	{
		return GClass123.stringBuilder_0.Length;
	}

	// Token: 0x060006F7 RID: 1783 RVA: 0x00002F0A File Offset: 0x0000110A
	public static void smethod_9()
	{
	}

	// Token: 0x060006F8 RID: 1784 RVA: 0x00002F0A File Offset: 0x0000110A
	public static void smethod_10()
	{
	}

	// Token: 0x040005FA RID: 1530
	public static bool bool_0 = false;

	// Token: 0x040005FB RID: 1531
	public static string string_0 = "Multiecuscan";

	// Token: 0x040005FC RID: 1532
	private const int int_0 = 99;

	// Token: 0x040005FD RID: 1533
	private const bool bool_1 = true;

	// Token: 0x040005FE RID: 1534
	private const bool bool_2 = true;

	// Token: 0x040005FF RID: 1535
	private const bool bool_3 = true;

	// Token: 0x04000600 RID: 1536
	private const bool bool_4 = true;

	// Token: 0x04000601 RID: 1537
	private const bool bool_5 = true;

	// Token: 0x04000602 RID: 1538
	private const bool bool_6 = true;

	// Token: 0x04000603 RID: 1539
	public const bool bool_7 = false;

	// Token: 0x04000604 RID: 1540
	private const bool bool_8 = false;

	// Token: 0x04000605 RID: 1541
	private const bool bool_9 = false;

	// Token: 0x04000606 RID: 1542
	public static StringBuilder stringBuilder_0 = new StringBuilder();

	// Token: 0x04000607 RID: 1543
	public static StringBuilder stringBuilder_1 = new StringBuilder();

	// Token: 0x04000608 RID: 1544
	public static string string_1 = "https://www.multiecuscan.net/CheckCurVerNum.aspx";

	// Token: 0x04000609 RID: 1545
	public static int int_1 = 0;

	// Token: 0x0400060A RID: 1546
	public static int[] int_2 = new int[]
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

	// Token: 0x0400060B RID: 1547
	public static int int_3 = 0;

	// Token: 0x0400060C RID: 1548
	public static int int_4 = 0;

	// Token: 0x0400060D RID: 1549
	public static int int_5 = 500;

	// Token: 0x0400060E RID: 1550
	public static int int_6 = 0;

	// Token: 0x0400060F RID: 1551
	public static int int_7 = 0;

	// Token: 0x04000610 RID: 1552
	public static bool bool_10 = false;

	// Token: 0x04000611 RID: 1553
	public static bool bool_11 = false;

	// Token: 0x04000612 RID: 1554
	public static bool bool_12 = false;

	// Token: 0x04000613 RID: 1555
	public static bool bool_13 = true;

	// Token: 0x04000614 RID: 1556
	public static bool bool_14 = false;

	// Token: 0x04000615 RID: 1557
	public static bool bool_15 = false;

	// Token: 0x04000616 RID: 1558
	public static List<GClass104> list_0 = new List<GClass104>();

	// Token: 0x04000617 RID: 1559
	public static bool bool_16 = false;

	// Token: 0x04000618 RID: 1560
	public static bool bool_17 = false;

	// Token: 0x04000619 RID: 1561
	public static List<GClass105> list_1 = new List<GClass105>();

	// Token: 0x0400061A RID: 1562
	public static int int_8 = 0;

	// Token: 0x0400061B RID: 1563
	public static Stopwatch stopwatch_0;

	// Token: 0x0400061C RID: 1564
	public static string string_2 = "";

	// Token: 0x0400061D RID: 1565
	public static string string_3 = "";

	// Token: 0x0400061E RID: 1566
	public static string string_4 = "";

	// Token: 0x0400061F RID: 1567
	public static int int_9 = -1;

	// Token: 0x04000620 RID: 1568
	public static string string_5 = "730C7-06414-786E19";

	// Token: 0x04000621 RID: 1569
	public static byte[] byte_0 = GClass127.smethod_32("45 46 47");

	// Token: 0x04000622 RID: 1570
	public static byte[] byte_1 = GClass127.smethod_32("55 83 82 8A 4E E9 7C F7 32 20 CB C6 67 AC B4 30 EB 1C B0 9D");

	// Token: 0x04000623 RID: 1571
	public static byte[] byte_2 = GClass127.smethod_32("1E B7 59 A3 B3 CD AB 55 82 EE 3F 6B F7 BC DC 06 B5 AB 6B FC");

	// Token: 0x04000624 RID: 1572
	public static byte[] byte_3 = GClass127.smethod_32("A8 1D C5 B7 77 BB B3 70 46 71 09 4D B2 37 6D F3 39 9D C9 1C");

	// Token: 0x04000625 RID: 1573
	public static bool bool_18 = false;
}
