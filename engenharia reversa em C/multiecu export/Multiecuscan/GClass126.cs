using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

// Token: 0x020000C7 RID: 199
public static class GClass126
{
	// Token: 0x060007A2 RID: 1954 RVA: 0x0000515E File Offset: 0x0000335E
	public static GClass105 smethod_0()
	{
		if (GClass126.list_1.Count < GClass126.int_11 + 1)
		{
			return null;
		}
		return GClass126.list_1[GClass126.int_11];
	}

	// Token: 0x060007A3 RID: 1955 RVA: 0x00005184 File Offset: 0x00003384
	public static int smethod_1()
	{
		return (int)GClass126.stopwatch_0.ElapsedMilliseconds;
	}

	// Token: 0x060007A4 RID: 1956 RVA: 0x000F0F44 File Offset: 0x000EF144
	public static void smethod_2(string string_15, int int_14)
	{
		if (int_14 == 0 || int_14 == 1 || int_14 == 2 || int_14 == 3 || int_14 == 4 || int_14 == 5)
		{
			GClass126.stringBuilder_0.Append(string.Concat(new string[]
			{
				"[",
				GClass126.stopwatch_0.ElapsedMilliseconds.ToString(),
				"] ",
				string_15,
				Environment.NewLine
			}));
			if (int_14 >= 2)
			{
				GClass126.stringBuilder_1.Append(string_15 + Environment.NewLine);
			}
		}
	}

	// Token: 0x060007A5 RID: 1957 RVA: 0x000F0FCC File Offset: 0x000EF1CC
	public static void smethod_3()
	{
		int num = 0;
		while (num < GClass126.byte_1.Length && GClass126.byte_1[num] == 0)
		{
			num++;
		}
		if (num != GClass126.byte_1.Length)
		{
			GClass126.byte_1[2 * num + 21] = 0;
		}
	}

	// Token: 0x060007A6 RID: 1958 RVA: 0x000F100C File Offset: 0x000EF20C
	public static void smethod_4(string string_15, int int_14)
	{
		if (!GClass126.bool_21 && GClass125.smethod_11().Length > 0)
		{
			GClass125.smethod_70(false);
		}
		else if (!GClass126.bool_21)
		{
			GClass125.smethod_85(GClass125.smethod_69());
		}
		else if (GClass126.bool_10)
		{
			GClass125.smethod_85(GClass125.smethod_69());
		}
		GClass126.bool_13 = GClass126.bool_21;
	}

	// Token: 0x060007A7 RID: 1959 RVA: 0x00005191 File Offset: 0x00003391
	public static void smethod_5()
	{
		GClass126.stringBuilder_1 = new StringBuilder(4096);
		if (GClass126.stringBuilder_0.Length > 1048575)
		{
			GClass126.smethod_6();
		}
	}

	// Token: 0x060007A8 RID: 1960 RVA: 0x000051B8 File Offset: 0x000033B8
	public static void smethod_6()
	{
		GClass126.stringBuilder_0 = new StringBuilder(4096);
	}

	// Token: 0x060007A9 RID: 1961 RVA: 0x000051C9 File Offset: 0x000033C9
	public static string smethod_7()
	{
		return GClass126.stringBuilder_0.ToString();
	}

	// Token: 0x060007AA RID: 1962 RVA: 0x000051D5 File Offset: 0x000033D5
	public static int smethod_8()
	{
		return GClass126.stringBuilder_0.Length;
	}

	// Token: 0x060007AB RID: 1963 RVA: 0x000051E1 File Offset: 0x000033E1
	public static int smethod_9()
	{
		return GClass126.stringBuilder_1.Length;
	}

	// Token: 0x060007AC RID: 1964 RVA: 0x000051ED File Offset: 0x000033ED
	public static void smethod_10(bool bool_26)
	{
		GClass126.bool_13 = bool_26;
	}

	// Token: 0x060007AD RID: 1965 RVA: 0x000F1064 File Offset: 0x000EF264
	public static void smethod_11()
	{
		if (GClass126.stringBuilder_1.Length < 5)
		{
			return;
		}
		if (!GClass126.bool_13)
		{
			return;
		}
		DateTime now = DateTime.Now;
		try
		{
			StreamWriter streamWriter = new StreamWriter(string.Concat(new string[]
			{
				GClass125.smethod_34(),
				"\\FESLog_",
				now.ToString("yyMMddHHmm"),
				"_",
				GClass126.string_7.Replace("/", ""),
				".txt"
			}));
			streamWriter.Write(GClass126.stringBuilder_1.ToString());
			streamWriter.Close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060007AE RID: 1966 RVA: 0x000F1110 File Offset: 0x000EF310
	public static void smethod_12()
	{
		if (GClass126.stringBuilder_1.Length < 5)
		{
			return;
		}
		if (!GClass126.bool_13)
		{
			return;
		}
		DateTime now = DateTime.Now;
		try
		{
			StreamWriter streamWriter = new StreamWriter(GClass125.smethod_34() + "\\SCAN_" + now.ToString("yyMMddHHmm") + ".txt");
			streamWriter.Write(GClass126.stringBuilder_1.ToString());
			streamWriter.Close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060007AF RID: 1967 RVA: 0x000F1188 File Offset: 0x000EF388
	public static void smethod_13()
	{
		try
		{
			string text = string.Concat(new string[]
			{
				"FL_",
				DateTime.Now.ToString("yyMMddHHmmss"),
				"_",
				GClass126.string_7,
				"_CRASH4E.txt"
			});
			text = text.Replace("/", "").Replace("\\", "");
			FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://ftp.multiecuscan.net/" + text);
			ftpWebRequest.Method = "STOR";
			ftpWebRequest.Credentials = new NetworkCredential("reports", "reports");
			Stream requestStream = ftpWebRequest.GetRequestStream();
			try
			{
				byte[] bytes = Encoding.Unicode.GetBytes(GClass126.smethod_7());
				requestStream.Write(bytes, 0, bytes.Length);
			}
			finally
			{
				requestStream.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060007B0 RID: 1968 RVA: 0x00002F0A File Offset: 0x0000110A
	public static void smethod_14()
	{
	}

	// Token: 0x04000686 RID: 1670
	public static bool bool_0 = false;

	// Token: 0x04000687 RID: 1671
	public static string string_0 = "Multiecuscan";

	// Token: 0x04000688 RID: 1672
	public static string string_1 = "";

	// Token: 0x04000689 RID: 1673
	private const int int_0 = 99;

	// Token: 0x0400068A RID: 1674
	private const bool bool_1 = true;

	// Token: 0x0400068B RID: 1675
	private const bool bool_2 = true;

	// Token: 0x0400068C RID: 1676
	private const bool bool_3 = true;

	// Token: 0x0400068D RID: 1677
	private const bool bool_4 = true;

	// Token: 0x0400068E RID: 1678
	private const bool bool_5 = true;

	// Token: 0x0400068F RID: 1679
	private const bool bool_6 = true;

	// Token: 0x04000690 RID: 1680
	public const bool bool_7 = false;

	// Token: 0x04000691 RID: 1681
	private const bool bool_8 = false;

	// Token: 0x04000692 RID: 1682
	private const bool bool_9 = true;

	// Token: 0x04000693 RID: 1683
	public static StringBuilder stringBuilder_0 = new StringBuilder();

	// Token: 0x04000694 RID: 1684
	public static StringBuilder stringBuilder_1 = new StringBuilder();

	// Token: 0x04000695 RID: 1685
	public static string string_2 = "https://www.multiecuscan.net/CheckCurVerNum.aspx";

	// Token: 0x04000696 RID: 1686
	public static string string_3 = "Multiecuscan stopped due to unknown error. You can send us a crash report which will help to fix this issue in future releases. Do you want to send crash report to Multiecuscan?";

	// Token: 0x04000697 RID: 1687
	public static bool bool_10 = false;

	// Token: 0x04000698 RID: 1688
	public static int int_1 = 0;

	// Token: 0x04000699 RID: 1689
	public static bool bool_11 = false;

	// Token: 0x0400069A RID: 1690
	public static int[] int_2 = new int[]
	{
		1,
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

	// Token: 0x0400069B RID: 1691
	public static int int_3 = 0;

	// Token: 0x0400069C RID: 1692
	public static int int_4 = 0;

	// Token: 0x0400069D RID: 1693
	public static int int_5 = 500;

	// Token: 0x0400069E RID: 1694
	public static int int_6 = 0;

	// Token: 0x0400069F RID: 1695
	public static int int_7 = 0;

	// Token: 0x040006A0 RID: 1696
	public static int int_8 = 0;

	// Token: 0x040006A1 RID: 1697
	public static bool bool_12 = false;

	// Token: 0x040006A2 RID: 1698
	public static bool bool_13 = false;

	// Token: 0x040006A3 RID: 1699
	public static bool bool_14 = false;

	// Token: 0x040006A4 RID: 1700
	public static bool bool_15 = true;

	// Token: 0x040006A5 RID: 1701
	public static bool bool_16 = false;

	// Token: 0x040006A6 RID: 1702
	public static bool bool_17 = true;

	// Token: 0x040006A7 RID: 1703
	public static bool bool_18 = false;

	// Token: 0x040006A8 RID: 1704
	public static bool bool_19 = false;

	// Token: 0x040006A9 RID: 1705
	public static bool bool_20 = false;

	// Token: 0x040006AA RID: 1706
	public static bool bool_21 = false;

	// Token: 0x040006AB RID: 1707
	public static int int_9 = 8191;

	// Token: 0x040006AC RID: 1708
	public static int int_10 = 40;

	// Token: 0x040006AD RID: 1709
	public static string string_4 = "";

	// Token: 0x040006AE RID: 1710
	public static List<GClass104> list_0 = new List<GClass104>();

	// Token: 0x040006AF RID: 1711
	public static bool bool_22 = false;

	// Token: 0x040006B0 RID: 1712
	public static bool bool_23 = false;

	// Token: 0x040006B1 RID: 1713
	public static List<GClass105> list_1 = new List<GClass105>();

	// Token: 0x040006B2 RID: 1714
	public static int int_11 = 0;

	// Token: 0x040006B3 RID: 1715
	public static Stopwatch stopwatch_0;

	// Token: 0x040006B4 RID: 1716
	public static string string_5 = "";

	// Token: 0x040006B5 RID: 1717
	public static string string_6 = "";

	// Token: 0x040006B6 RID: 1718
	public static string string_7 = "";

	// Token: 0x040006B7 RID: 1719
	public static string string_8 = "";

	// Token: 0x040006B8 RID: 1720
	public static string string_9 = "";

	// Token: 0x040006B9 RID: 1721
	public static string string_10 = "";

	// Token: 0x040006BA RID: 1722
	public static string string_11 = "";

	// Token: 0x040006BB RID: 1723
	public static int int_12 = -1;

	// Token: 0x040006BC RID: 1724
	public static int int_13 = -1;

	// Token: 0x040006BD RID: 1725
	public static string string_12 = "74126-E079B-627D07";

	// Token: 0x040006BE RID: 1726
	public static byte[] byte_0 = GClass127.smethod_32("55 AA 5A A5");

	// Token: 0x040006BF RID: 1727
	public static byte[] byte_1 = GClass127.smethod_32("C4 1C B9 A5 A4 4F F8 93 6E 11 81 B9 17 5A F2 CB 44 77 6E 03");

	// Token: 0x040006C0 RID: 1728
	public static byte[] byte_2 = GClass127.smethod_32("1E B7 59 A3 B3 CD AB 55 82 EE 3F 6B F7 BC DC 06 B5 AB 6B FC");

	// Token: 0x040006C1 RID: 1729
	public static byte[] byte_3 = GClass127.smethod_32("55 AA 5A A5");

	// Token: 0x040006C2 RID: 1730
	public static string[] string_13 = new string[]
	{
		"NOi0cG",
		"guT4^!$3",
		"eJRe8~",
		"i*3G0l;|",
		"kQM)VX",
		"ur!uHi"
	};

	// Token: 0x040006C3 RID: 1731
	public static bool bool_24 = false;

	// Token: 0x040006C4 RID: 1732
	public static bool bool_25 = false;

	// Token: 0x040006C5 RID: 1733
	public static string string_14 = "730C7-06414-786E19";
}
