using System;
using System.Drawing;
using System.IO;
using System.Text;
using Microsoft.Win32;

// Token: 0x020000C3 RID: 195
public static class GClass122
{
	// Token: 0x06000688 RID: 1672 RVA: 0x00004692 File Offset: 0x00002892
	public static string smethod_0()
	{
		return GClass122.string_13;
	}

	// Token: 0x06000689 RID: 1673 RVA: 0x00004699 File Offset: 0x00002899
	public static void smethod_1(string string_23)
	{
		GClass122.string_13 = string_23;
	}

	// Token: 0x0600068A RID: 1674 RVA: 0x000046A1 File Offset: 0x000028A1
	public static string smethod_2()
	{
		return GClass122.string_14.Substring(0, 14);
	}

	// Token: 0x0600068B RID: 1675 RVA: 0x000046B0 File Offset: 0x000028B0
	public static void smethod_3(string string_23)
	{
		GClass122.string_14 = string_23;
		GClass126.string_14 = string_23;
	}

	// Token: 0x0600068C RID: 1676 RVA: 0x000046BE File Offset: 0x000028BE
	public static string smethod_4()
	{
		return GClass122.string_15;
	}

	// Token: 0x0600068D RID: 1677 RVA: 0x000E68E0 File Offset: 0x000E4AE0
	public static void smethod_5(string string_23)
	{
		GClass122.string_15 = string_23;
		if (GClass122.string_15 == "")
		{
			GClass122.smethod_64(18, Color.Navy);
		}
		if (GClass122.string_15 == "")
		{
			GClass122.smethod_64(19, Color.Blue);
		}
	}

	// Token: 0x0600068E RID: 1678 RVA: 0x000046C5 File Offset: 0x000028C5
	public static bool smethod_6()
	{
		GClass122.smethod_64(19, Color.Blue);
		return GClass122.string_15 == "";
	}

	// Token: 0x0600068F RID: 1679 RVA: 0x000046E2 File Offset: 0x000028E2
	public static string smethod_7()
	{
		return GClass122.string_12;
	}

	// Token: 0x06000690 RID: 1680 RVA: 0x000046E9 File Offset: 0x000028E9
	public static void smethod_8(string string_23)
	{
		GClass122.string_12 = string_23;
	}

	// Token: 0x06000691 RID: 1681 RVA: 0x000046F1 File Offset: 0x000028F1
	public static string smethod_9()
	{
		return GClass122.string_9;
	}

	// Token: 0x06000692 RID: 1682 RVA: 0x000046F8 File Offset: 0x000028F8
	public static void smethod_10(string string_23)
	{
		GClass122.string_9 = string_23;
	}

	// Token: 0x06000693 RID: 1683 RVA: 0x00004700 File Offset: 0x00002900
	public static string smethod_11()
	{
		return GClass122.string_10;
	}

	// Token: 0x06000694 RID: 1684 RVA: 0x00004707 File Offset: 0x00002907
	public static void smethod_12(string string_23)
	{
		GClass122.string_10 = string_23;
	}

	// Token: 0x06000695 RID: 1685 RVA: 0x0000470F File Offset: 0x0000290F
	public static string smethod_13()
	{
		return GClass122.string_11;
	}

	// Token: 0x06000696 RID: 1686 RVA: 0x00004716 File Offset: 0x00002916
	public static void smethod_14(string string_23)
	{
		GClass122.string_11 = string_23;
	}

	// Token: 0x06000697 RID: 1687 RVA: 0x0000471E File Offset: 0x0000291E
	public static Font smethod_15()
	{
		return GClass122.font_3;
	}

	// Token: 0x06000698 RID: 1688 RVA: 0x00004725 File Offset: 0x00002925
	public static void smethod_16(Font font_5)
	{
		GClass122.font_3 = font_5;
	}

	// Token: 0x06000699 RID: 1689 RVA: 0x0000472D File Offset: 0x0000292D
	public static Font smethod_17()
	{
		return GClass122.font_4;
	}

	// Token: 0x0600069A RID: 1690 RVA: 0x00004734 File Offset: 0x00002934
	public static void smethod_18(Font font_5)
	{
		GClass122.font_4 = font_5;
	}

	// Token: 0x0600069B RID: 1691 RVA: 0x0000473C File Offset: 0x0000293C
	public static string smethod_19()
	{
		return GClass122.string_8;
	}

	// Token: 0x0600069C RID: 1692 RVA: 0x00004743 File Offset: 0x00002943
	public static void smethod_20(string string_23)
	{
		GClass122.string_8 = string_23;
	}

	// Token: 0x0600069D RID: 1693 RVA: 0x0000474B File Offset: 0x0000294B
	public static string smethod_21()
	{
		return GClass122.string_16;
	}

	// Token: 0x0600069E RID: 1694 RVA: 0x00004752 File Offset: 0x00002952
	public static void smethod_22(string string_23)
	{
		GClass122.string_16 = string_23;
	}

	// Token: 0x0600069F RID: 1695 RVA: 0x0000475A File Offset: 0x0000295A
	public static string smethod_23()
	{
		return GClass122.string_17;
	}

	// Token: 0x060006A0 RID: 1696 RVA: 0x00004761 File Offset: 0x00002961
	public static void smethod_24(string string_23)
	{
		GClass122.string_17 = string_23;
	}

	// Token: 0x060006A1 RID: 1697 RVA: 0x00004769 File Offset: 0x00002969
	public static string smethod_25()
	{
		return GClass122.string_0;
	}

	// Token: 0x060006A2 RID: 1698 RVA: 0x00004770 File Offset: 0x00002970
	public static void smethod_26(string string_23)
	{
		GClass122.string_0 = string_23;
	}

	// Token: 0x060006A3 RID: 1699 RVA: 0x00004778 File Offset: 0x00002978
	public static int smethod_27(int int_14)
	{
		if (int_14 <= 3 && int_14 >= 0)
		{
			return GClass122.int_7[int_14];
		}
		return 0;
	}

	// Token: 0x060006A4 RID: 1700 RVA: 0x0000478B File Offset: 0x0000298B
	public static void smethod_28(int int_14, int int_15)
	{
		if (int_14 <= 3 && int_14 >= 0)
		{
			GClass122.int_7[int_14] = int_15;
			return;
		}
	}

	// Token: 0x060006A5 RID: 1701 RVA: 0x0000479E File Offset: 0x0000299E
	public static string smethod_29(int int_14)
	{
		if (int_14 <= 3 && int_14 >= 0)
		{
			return GClass122.string_7[int_14];
		}
		return "COM1";
	}

	// Token: 0x060006A6 RID: 1702 RVA: 0x000047B5 File Offset: 0x000029B5
	public static void smethod_30(int int_14, string string_23)
	{
		if (int_14 <= 3 && int_14 >= 0)
		{
			GClass122.string_7[int_14] = string_23;
			return;
		}
	}

	// Token: 0x060006A7 RID: 1703 RVA: 0x000047C8 File Offset: 0x000029C8
	public static int smethod_31(int int_14)
	{
		if (int_14 <= 3 && int_14 >= 0)
		{
			return GClass122.int_8[int_14];
		}
		return 0;
	}

	// Token: 0x060006A8 RID: 1704 RVA: 0x000047DB File Offset: 0x000029DB
	public static void smethod_32(int int_14, int int_15)
	{
		if (int_14 <= 3 && int_14 >= 0)
		{
			GClass122.int_8[int_14] = int_15;
			return;
		}
	}

	// Token: 0x060006A9 RID: 1705 RVA: 0x000047EE File Offset: 0x000029EE
	public static int smethod_33()
	{
		return GClass122.int_5;
	}

	// Token: 0x060006AA RID: 1706 RVA: 0x000047F5 File Offset: 0x000029F5
	public static void smethod_34(int int_14)
	{
		GClass122.int_5 = int_14;
	}

	// Token: 0x060006AB RID: 1707 RVA: 0x000047FD File Offset: 0x000029FD
	public static string smethod_35()
	{
		return GClass122.string_6;
	}

	// Token: 0x060006AC RID: 1708 RVA: 0x00004804 File Offset: 0x00002A04
	public static void smethod_36(string string_23)
	{
		GClass122.string_6 = string_23;
	}

	// Token: 0x060006AD RID: 1709 RVA: 0x0000480C File Offset: 0x00002A0C
	public static int smethod_37()
	{
		return GClass122.int_6;
	}

	// Token: 0x060006AE RID: 1710 RVA: 0x00004813 File Offset: 0x00002A13
	public static void smethod_38(int int_14)
	{
		GClass122.int_6 = int_14;
	}

	// Token: 0x060006AF RID: 1711 RVA: 0x0000481B File Offset: 0x00002A1B
	public static bool smethod_39()
	{
		return GClass122.bool_0;
	}

	// Token: 0x060006B0 RID: 1712 RVA: 0x00004822 File Offset: 0x00002A22
	public static void smethod_40(bool bool_5)
	{
		GClass122.bool_0 = bool_5;
	}

	// Token: 0x060006B1 RID: 1713 RVA: 0x0000482A File Offset: 0x00002A2A
	public static bool smethod_41()
	{
		return GClass122.bool_1;
	}

	// Token: 0x060006B2 RID: 1714 RVA: 0x00004831 File Offset: 0x00002A31
	public static void smethod_42(bool bool_5)
	{
		GClass122.bool_1 = bool_5;
	}

	// Token: 0x060006B3 RID: 1715 RVA: 0x00004839 File Offset: 0x00002A39
	public static int smethod_43()
	{
		return GClass122.int_9;
	}

	// Token: 0x060006B4 RID: 1716 RVA: 0x00004840 File Offset: 0x00002A40
	public static void smethod_44(int int_14)
	{
		GClass122.int_9 = int_14;
	}

	// Token: 0x060006B5 RID: 1717 RVA: 0x00004848 File Offset: 0x00002A48
	public static bool smethod_45()
	{
		return GClass122.bool_3;
	}

	// Token: 0x060006B6 RID: 1718 RVA: 0x0000484F File Offset: 0x00002A4F
	public static void smethod_46(bool bool_5)
	{
		GClass122.bool_3 = bool_5;
	}

	// Token: 0x060006B7 RID: 1719 RVA: 0x00004857 File Offset: 0x00002A57
	public static int smethod_47()
	{
		return GClass122.int_12;
	}

	// Token: 0x060006B8 RID: 1720 RVA: 0x0000485E File Offset: 0x00002A5E
	public static void smethod_48(int int_14)
	{
		GClass122.int_12 = int_14;
	}

	// Token: 0x060006B9 RID: 1721 RVA: 0x00004866 File Offset: 0x00002A66
	public static bool smethod_49()
	{
		return GClass122.bool_4;
	}

	// Token: 0x060006BA RID: 1722 RVA: 0x0000486D File Offset: 0x00002A6D
	public static void smethod_50(bool bool_5)
	{
		GClass122.bool_4 = bool_5;
	}

	// Token: 0x060006BB RID: 1723 RVA: 0x00004875 File Offset: 0x00002A75
	public static bool smethod_51()
	{
		return GClass122.bool_2;
	}

	// Token: 0x060006BC RID: 1724 RVA: 0x0000487C File Offset: 0x00002A7C
	public static void smethod_52(bool bool_5)
	{
		GClass122.bool_2 = bool_5;
	}

	// Token: 0x060006BD RID: 1725 RVA: 0x00004884 File Offset: 0x00002A84
	public static int smethod_53()
	{
		return GClass122.int_10;
	}

	// Token: 0x060006BE RID: 1726 RVA: 0x0000488B File Offset: 0x00002A8B
	public static void smethod_54(int int_14)
	{
		GClass122.int_10 = int_14;
	}

	// Token: 0x060006BF RID: 1727 RVA: 0x00004893 File Offset: 0x00002A93
	public static long smethod_55()
	{
		return GClass122.long_0;
	}

	// Token: 0x060006C0 RID: 1728 RVA: 0x0000489A File Offset: 0x00002A9A
	public static void smethod_56(long long_1)
	{
		GClass122.long_0 = long_1;
	}

	// Token: 0x060006C1 RID: 1729 RVA: 0x000048A2 File Offset: 0x00002AA2
	public static string smethod_57()
	{
		return GClass122.string_18;
	}

	// Token: 0x060006C2 RID: 1730 RVA: 0x000048A9 File Offset: 0x00002AA9
	public static void smethod_58(string string_23)
	{
		GClass122.string_18 = string_23;
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x000048B1 File Offset: 0x00002AB1
	public static bool smethod_59()
	{
		return !GClass125.smethod_24().ToLower().Contains("multiecuscan.exe");
	}

	// Token: 0x060006C4 RID: 1732 RVA: 0x000048CA File Offset: 0x00002ACA
	public static string smethod_60()
	{
		return GClass122.string_19;
	}

	// Token: 0x060006C5 RID: 1733 RVA: 0x000048D1 File Offset: 0x00002AD1
	public static void smethod_61(string string_23)
	{
		GClass122.string_19 = string_23;
	}

	// Token: 0x060006C6 RID: 1734 RVA: 0x000E6930 File Offset: 0x000E4B30
	public static void smethod_62(int int_14)
	{
		if (GClass122.string_19.Length > 0)
		{
			GClass122.string_19 += ",";
			GClass122.string_19 = GClass122.string_19.Replace("(" + int_14.ToString() + "),", "");
		}
		GClass122.string_19 = GClass122.string_19 + "(" + int_14.ToString() + ")";
		int i = 0;
		for (int j = 0; j < GClass122.string_19.Length; j++)
		{
			if (GClass122.string_19[j] == ',')
			{
				i++;
			}
		}
		while (i > 20)
		{
			GClass122.string_19 = GClass122.string_19.Substring(GClass122.string_19.IndexOf(",") + 1);
			i--;
		}
	}

	// Token: 0x060006C7 RID: 1735 RVA: 0x000048D9 File Offset: 0x00002AD9
	public static Color smethod_63(int int_14)
	{
		if (int_14 < GClass122.color_0.Length)
		{
			return GClass122.color_0[int_14];
		}
		return GClass122.color_0[GClass122.color_0.Length - 1];
	}

	// Token: 0x060006C8 RID: 1736 RVA: 0x00004904 File Offset: 0x00002B04
	public static void smethod_64(int int_14, Color color_4)
	{
		if (int_14 < GClass122.color_0.Length)
		{
			GClass122.color_0[int_14] = color_4;
		}
	}

	// Token: 0x060006C9 RID: 1737 RVA: 0x0000491C File Offset: 0x00002B1C
	public static Color smethod_65()
	{
		return GClass122.color_1;
	}

	// Token: 0x060006CA RID: 1738 RVA: 0x00004923 File Offset: 0x00002B23
	public static void smethod_66(Color color_4)
	{
		GClass122.color_1 = color_4;
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x0000492B File Offset: 0x00002B2B
	public static Color smethod_67()
	{
		return GClass122.color_2;
	}

	// Token: 0x060006CC RID: 1740 RVA: 0x00004932 File Offset: 0x00002B32
	public static void smethod_68(Color color_4)
	{
		GClass122.color_2 = color_4;
	}

	// Token: 0x060006CD RID: 1741 RVA: 0x0000493A File Offset: 0x00002B3A
	public static Color smethod_69()
	{
		return GClass122.color_3;
	}

	// Token: 0x060006CE RID: 1742 RVA: 0x00004941 File Offset: 0x00002B41
	public static void smethod_70(Color color_4)
	{
		GClass122.color_3 = color_4;
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x00004949 File Offset: 0x00002B49
	public static int smethod_71()
	{
		return GClass122.int_11;
	}

	// Token: 0x060006D0 RID: 1744 RVA: 0x00004950 File Offset: 0x00002B50
	public static void smethod_72(int int_14)
	{
		GClass122.int_11 = int_14;
	}

	// Token: 0x060006D1 RID: 1745 RVA: 0x00004958 File Offset: 0x00002B58
	public static Font smethod_73()
	{
		return GClass122.font_0;
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x0000495F File Offset: 0x00002B5F
	public static void smethod_74(Font font_5)
	{
		GClass122.font_0 = font_5;
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x00004967 File Offset: 0x00002B67
	public static Font smethod_75()
	{
		return GClass122.font_1;
	}

	// Token: 0x060006D4 RID: 1748 RVA: 0x0000496E File Offset: 0x00002B6E
	public static void smethod_76(Font font_5)
	{
		GClass122.font_1 = font_5;
	}

	// Token: 0x060006D5 RID: 1749 RVA: 0x00004976 File Offset: 0x00002B76
	public static Font smethod_77()
	{
		return GClass122.font_2;
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x0000497D File Offset: 0x00002B7D
	public static void smethod_78(Font font_5)
	{
		GClass122.font_2 = font_5;
	}

	// Token: 0x060006D7 RID: 1751 RVA: 0x00004985 File Offset: 0x00002B85
	public static int[] smethod_79(int int_14)
	{
		return GClass122.int_13[int_14];
	}

	// Token: 0x060006D8 RID: 1752 RVA: 0x0000498E File Offset: 0x00002B8E
	public static void smethod_80(int int_14, int[] int_15)
	{
		GClass122.int_13[int_14] = int_15;
	}

	// Token: 0x060006D9 RID: 1753 RVA: 0x00004998 File Offset: 0x00002B98
	public static string smethod_81(int int_14)
	{
		return GClass122.string_20[int_14];
	}

	// Token: 0x060006DA RID: 1754 RVA: 0x000049A1 File Offset: 0x00002BA1
	public static void smethod_82(int int_14, string string_23)
	{
		GClass122.string_20[int_14] = string_23;
	}

	// Token: 0x060006DB RID: 1755 RVA: 0x000E6A00 File Offset: 0x000E4C00
	private static void smethod_83(string string_23, Font font_5)
	{
		GClass122.smethod_87(string_23, string.Concat(new string[]
		{
			font_5.Name,
			";",
			font_5.Style.ToString(),
			";",
			font_5.SizeInPoints.ToString(),
			"pt"
		}), RegistryValueKind.String);
	}

	// Token: 0x060006DC RID: 1756 RVA: 0x000049AB File Offset: 0x00002BAB
	private static void smethod_84(string string_23, Color color_4)
	{
		GClass122.smethod_87(string_23, color_4.ToArgb(), RegistryValueKind.DWord);
	}

	// Token: 0x060006DD RID: 1757 RVA: 0x000049C0 File Offset: 0x00002BC0
	private static void smethod_85(string string_23, int int_14)
	{
		GClass122.smethod_87(string_23, int_14, RegistryValueKind.DWord);
	}

	// Token: 0x060006DE RID: 1758 RVA: 0x000049CF File Offset: 0x00002BCF
	private static void smethod_86(string string_23, string string_24)
	{
		GClass122.smethod_87(string_23, string_24, RegistryValueKind.String);
	}

	// Token: 0x060006DF RID: 1759 RVA: 0x000E6A68 File Offset: 0x000E4C68
	private static void smethod_87(string string_23, object object_0, RegistryValueKind registryValueKind_0)
	{
		using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software", true))
		{
			using (RegistryKey registryKey2 = registryKey.OpenSubKey("Multiecuscan", true))
			{
				if (registryKey2 == null)
				{
					using (RegistryKey registryKey3 = registryKey.CreateSubKey("Multiecuscan"))
					{
						registryKey3.SetValue(string_23, object_0, registryValueKind_0);
						return;
					}
				}
				registryKey2.SetValue(string_23, object_0, registryValueKind_0);
			}
		}
	}

	// Token: 0x060006E0 RID: 1760 RVA: 0x000E6B00 File Offset: 0x000E4D00
	private static int smethod_88(string string_23, int int_14)
	{
		object obj = GClass122.smethod_92(string_23);
		if (obj == null)
		{
			return int_14;
		}
		return (int)obj;
	}

	// Token: 0x060006E1 RID: 1761 RVA: 0x000E6B20 File Offset: 0x000E4D20
	private static string smethod_89(string string_23, string string_24)
	{
		object obj = GClass122.smethod_92(string_23);
		if (obj == null)
		{
			return string_24;
		}
		return (string)obj;
	}

	// Token: 0x060006E2 RID: 1762 RVA: 0x000E6B40 File Offset: 0x000E4D40
	private static Color smethod_90(string string_23, Color color_4)
	{
		object obj = GClass122.smethod_92(string_23);
		if (obj == null)
		{
			return color_4;
		}
		return Color.FromArgb((int)obj);
	}

	// Token: 0x060006E3 RID: 1763 RVA: 0x000E6B64 File Offset: 0x000E4D64
	private static Font smethod_91(string string_23, Font font_5)
	{
		object obj = GClass122.smethod_92(string_23);
		if (obj == null)
		{
			return font_5;
		}
		string text = (string)obj;
		string familyName = "Arial";
		float emSize = 5f;
		FontStyle style = FontStyle.Regular;
		if (text.ToLower().Contains("italic"))
		{
			style = FontStyle.Italic;
		}
		if (text.ToLower().Contains("bold"))
		{
			style = FontStyle.Bold;
		}
		if (text.ToLower().Contains("bold") && text.ToLower().Contains("italic"))
		{
			style = FontStyle.Regular;
		}
		if (text.IndexOf(";") > 0)
		{
			familyName = text.Substring(0, text.IndexOf(";"));
		}
		try
		{
			if (text.LastIndexOf(";") > 0)
			{
				emSize = (float)Convert.ToDouble(text.Substring(text.LastIndexOf(";") + 1).Replace("pt", ""));
			}
		}
		catch (Exception)
		{
		}
		return new Font(familyName, emSize, style);
	}

	// Token: 0x060006E4 RID: 1764 RVA: 0x000E6C5C File Offset: 0x000E4E5C
	private static object smethod_92(string string_23)
	{
		object result;
		using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software"))
		{
			using (RegistryKey registryKey2 = registryKey.OpenSubKey("Multiecuscan"))
			{
				if (registryKey2 == null)
				{
					result = null;
				}
				else
				{
					result = registryKey2.GetValue(string_23);
				}
			}
		}
		return result;
	}

	// Token: 0x060006E5 RID: 1765 RVA: 0x000E6CC8 File Offset: 0x000E4EC8
	public static void smethod_93()
	{
		try
		{
			if (GClass122.smethod_88("Interface 1 Type", -1) == -1)
			{
				GClass122.int_7[0] = GClass122.smethod_88("Interface Type", GClass122.int_7[0]);
				GClass122.string_7[0] = GClass122.smethod_89("Interface Port", GClass122.string_7[0]);
				GClass122.int_8[0] = GClass122.smethod_88("Port Speed", GClass122.int_8[0]);
			}
			else
			{
				GClass122.int_7[0] = GClass122.smethod_88("Interface 1 Type", GClass122.int_7[0]);
				GClass122.string_7[0] = GClass122.smethod_89("Interface 1 Port", GClass122.string_7[0]);
				GClass122.int_8[0] = GClass122.smethod_88("Interface 1 Port Speed", GClass122.int_8[0]);
				GClass122.int_7[1] = GClass122.smethod_88("Interface 2 Type", GClass122.int_7[1]);
				GClass122.string_7[1] = GClass122.smethod_89("Interface 2 Port", GClass122.string_7[1]);
				GClass122.int_8[1] = GClass122.smethod_88("Interface 2 Port Speed", GClass122.int_8[1]);
				GClass122.int_7[2] = GClass122.smethod_88("Interface 3 Type", GClass122.int_7[2]);
				GClass122.string_7[2] = GClass122.smethod_89("Interface 3 Port", GClass122.string_7[2]);
				GClass122.int_8[2] = GClass122.smethod_88("Interface 3 Port Speed", GClass122.int_8[2]);
				GClass122.int_7[3] = GClass122.smethod_88("Interface 4 Type", GClass122.int_7[3]);
				GClass122.string_7[3] = GClass122.smethod_89("Interface 4 Port", GClass122.string_7[3]);
				GClass122.int_8[3] = GClass122.smethod_88("Interface 4 Port Speed", GClass122.int_8[3]);
				GClass122.color_0[0] = GClass122.smethod_90("Parameter Color 1", GClass122.color_0[0]);
				GClass122.color_0[1] = GClass122.smethod_90("Parameter Color 2", GClass122.color_0[1]);
				GClass122.color_0[2] = GClass122.smethod_90("Parameter Color 3", GClass122.color_0[2]);
				GClass122.color_0[3] = GClass122.smethod_90("Parameter Color 4", GClass122.color_0[3]);
				GClass122.color_0[4] = GClass122.smethod_90("Parameter Color 5", GClass122.color_0[4]);
				GClass122.color_0[5] = GClass122.smethod_90("Parameter Color 6", GClass122.color_0[5]);
				GClass122.color_0[6] = GClass122.smethod_90("Parameter Color 7", GClass122.color_0[6]);
				GClass122.color_0[7] = GClass122.smethod_90("Parameter Color 8", GClass122.color_0[7]);
				GClass122.color_1 = GClass122.smethod_90("Graph Back Color", GClass122.color_1);
				GClass122.color_2 = GClass122.smethod_90("Graph Grid Color", GClass122.color_2);
				GClass122.color_3 = GClass122.smethod_90("Graph X-Axis Color", GClass122.color_3);
				GClass122.int_11 = GClass122.smethod_88("Graph Line Thickness", GClass122.int_11);
				GClass122.font_1 = GClass122.smethod_91("Graph X-Axis Font", GClass122.font_1);
				GClass122.font_0 = GClass122.smethod_91("Graph Y-Axis Font", GClass122.font_0);
				GClass122.font_2 = GClass122.smethod_91("Graph Parameter Font", GClass122.font_2);
			}
			GClass122.bool_0 = (GClass122.smethod_88("Show Available Ports Only", (GClass122.bool_0 > false) ? 1 : 0) == 1);
			GClass122.int_9 = GClass122.smethod_88("KWP2000 Timings", GClass122.int_9);
			GClass122.bool_1 = (GClass122.smethod_88("Show Adapter Message", (GClass122.bool_1 > false) ? 1 : 0) == 1);
			GClass122.bool_3 = (GClass122.smethod_88("High Latency mode", (GClass122.bool_3 > false) ? 1 : 0) == 1);
			GClass122.bool_2 = (GClass122.smethod_88("Convert KMs to Miles", (GClass122.bool_2 > false) ? 1 : 0) == 1);
			GClass122.int_12 = GClass122.smethod_88("Screen Repaint Interval", GClass122.int_12);
			GClass122.bool_4 = (GClass122.smethod_88("Show Disclaimer", (GClass122.bool_4 > false) ? 1 : 0) == 1);
			GClass122.int_10 = GClass122.smethod_88("Last Selection", GClass122.int_10);
			GClass122.string_9 = GClass122.smethod_89("UI Language", GClass122.string_9);
			GClass122.string_10 = GClass122.smethod_89("Data Language", GClass122.string_10);
			GClass122.font_3 = GClass122.smethod_91("UI Font 1", GClass122.font_3);
			GClass122.font_4 = GClass122.smethod_91("UI Font 2", GClass122.font_4);
			GClass122.string_12 = GClass122.smethod_89("CSV Separator", GClass122.string_12);
			GClass122.string_16 = GClass122.smethod_89("Export Folder", GClass122.string_16);
			GClass122.string_17 = GClass122.smethod_89("LOG Folder", GClass122.string_17);
			GClass122.color_0[8] = GClass122.smethod_90("Parameter Color 9", GClass122.color_0[8]);
			GClass122.color_0[9] = GClass122.smethod_90("Parameter Color 10", GClass122.color_0[9]);
			GClass122.string_14 = GClass122.smethod_89("Lic Number", GClass122.string_14);
			GClass122.string_15 = GClass122.smethod_89("Removal Key", GClass122.string_15);
			GClass122.string_19 = GClass122.smethod_89("Recent Vehicles", "");
			return;
		}
		catch (Exception)
		{
		}
		try
		{
			FileStream fileStream = new FileStream(GClass122.string_8 + "\\" + GClass122.string_0.Replace(GClass122.string_4, GClass122.string_5), FileMode.Open, FileAccess.Read);
			GClass122.string_18 = GClass122.string_18 + GClass122.smethod_97(fileStream, (long)GClass122.int_0) + GClass122.smethod_97(fileStream, (long)GClass122.int_1) + GClass122.smethod_97(fileStream, (long)GClass122.int_2);
			GClass122.long_0 = fileStream.Length;
			fileStream.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x060006E6 RID: 1766 RVA: 0x000E7258 File Offset: 0x000E5458
	private static string smethod_94(int int_14)
	{
		string text = "";
		for (int i = 0; i < GClass122.int_13[int_14].Length; i++)
		{
			text = text + ((i > 0) ? "," : "") + GClass122.int_13[int_14][i].ToString();
		}
		return text;
	}

	// Token: 0x060006E7 RID: 1767 RVA: 0x000E72AC File Offset: 0x000E54AC
	public static void smethod_95()
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(GClass122.string_8 + "\\" + GClass122.string_1);
			for (int i = 0; i < 10; i++)
			{
				streamWriter.WriteLine(i.ToString() + "=" + GClass122.smethod_94(i));
			}
			streamWriter.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x060006E8 RID: 1768 RVA: 0x000E7320 File Offset: 0x000E5520
	public static void smethod_96()
	{
		GClass122.string_18 = "";
		char[] separator = new char[]
		{
			','
		};
		try
		{
			StreamReader streamReader = new StreamReader(File.OpenRead(GClass122.string_8 + "\\" + GClass122.string_1));
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				if (text[1] == '=' && text.Length > 2)
				{
					int num = Convert.ToInt32(text.Substring(0, 1));
					text = text.Substring(2);
					string[] array = text.Split(separator);
					GClass122.int_13[num] = new int[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						GClass122.int_13[num][i] = Convert.ToInt32(array[i]);
					}
				}
			}
			streamReader.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
		try
		{
			FileStream fileStream = new FileStream(GClass122.string_8 + "\\" + GClass122.string_0.Replace(GClass122.string_4, GClass122.string_5), FileMode.Open, FileAccess.Read);
			GClass122.string_18 = GClass122.string_18 + GClass122.smethod_97(fileStream, (long)GClass122.int_0) + GClass122.smethod_97(fileStream, (long)GClass122.int_1) + GClass122.smethod_97(fileStream, (long)GClass122.int_2);
			GClass122.long_0 = fileStream.Length;
			fileStream.Close();
		}
		catch (Exception value2)
		{
			Console.WriteLine(value2);
		}
	}

	// Token: 0x060006E9 RID: 1769 RVA: 0x000E7484 File Offset: 0x000E5684
	private static string smethod_97(FileStream fileStream_0, long long_1)
	{
		byte[] array = new byte[GClass122.int_4];
		fileStream_0.Seek(long_1, SeekOrigin.Begin);
		fileStream_0.Read(array, 0, array.Length);
		return GClass127.smethod_11(array).Replace(GClass122.string_21, GClass122.string_22);
	}

	// Token: 0x060006EA RID: 1770 RVA: 0x000E74C8 File Offset: 0x000E56C8
	public static void smethod_98()
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(GClass122.string_8 + "\\" + GClass122.string_2, false, Encoding.Unicode);
			for (int i = 0; i < 10; i++)
			{
				streamWriter.WriteLine(i.ToString() + "=" + GClass122.string_20[i]);
			}
			streamWriter.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x060006EB RID: 1771 RVA: 0x000E7540 File Offset: 0x000E5740
	public static void smethod_99()
	{
		(new char[1])[0] = ',';
		try
		{
			StreamReader streamReader = new StreamReader(File.OpenRead(GClass122.string_8 + "\\" + GClass122.string_2));
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				if (text[1] == '=' && text.Length > 2)
				{
					int num = Convert.ToInt32(text.Substring(0, 1));
					GClass122.string_20[num] = text.Substring(2);
				}
			}
			streamReader.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x060006EC RID: 1772 RVA: 0x000E75D4 File Offset: 0x000E57D4
	public static void smethod_100()
	{
		try
		{
			GClass122.smethod_85("Interface 1 Type", GClass122.int_7[0]);
			GClass122.smethod_86("Interface 1 Port", GClass122.string_7[0]);
			GClass122.smethod_85("Interface 1 Port Speed", GClass122.int_8[0]);
			GClass122.smethod_85("Interface 2 Type", GClass122.int_7[1]);
			GClass122.smethod_86("Interface 2 Port", GClass122.string_7[1]);
			GClass122.smethod_85("Interface 2 Port Speed", GClass122.int_8[1]);
			GClass122.smethod_85("Interface 3 Type", GClass122.int_7[2]);
			GClass122.smethod_86("Interface 3 Port", GClass122.string_7[2]);
			GClass122.smethod_85("Interface 3 Port Speed", GClass122.int_8[2]);
			GClass122.smethod_85("Interface 4 Type", GClass122.int_7[3]);
			GClass122.smethod_86("Interface 4 Port", GClass122.string_7[3]);
			GClass122.smethod_85("Interface 4 Port Speed", GClass122.int_8[3]);
			GClass122.smethod_85("Show Available Ports Only", (GClass122.bool_0 > false) ? 1 : 0);
			GClass122.smethod_85("KWP2000 Timings", GClass122.int_9);
			GClass122.smethod_85("Show Adapter Message", (GClass122.bool_1 > false) ? 1 : 0);
			GClass122.smethod_85("High Latency mode", (GClass122.bool_3 > false) ? 1 : 0);
			GClass122.smethod_85("Convert KMs to Miles", (GClass122.bool_2 > false) ? 1 : 0);
			GClass122.smethod_85("Screen Repaint Interval", GClass122.int_12);
			GClass122.smethod_85("Show Disclaimer", (GClass122.bool_4 > false) ? 1 : 0);
			GClass122.smethod_85("Last Selection", GClass122.int_10);
			GClass122.smethod_86("UI Language", GClass122.string_9);
			GClass122.smethod_86("Data Language", GClass122.string_10);
			GClass122.smethod_83("UI Font 1", GClass122.font_3);
			GClass122.smethod_83("UI Font 2", GClass122.font_4);
			GClass122.smethod_86("CSV Separator", GClass122.string_12);
			GClass122.smethod_86("Export Folder", GClass122.string_16);
			GClass122.smethod_86("LOG Folder", GClass122.string_17);
			GClass122.smethod_84("Parameter Color 1", GClass122.color_0[0]);
			GClass122.smethod_84("Parameter Color 2", GClass122.color_0[1]);
			GClass122.smethod_84("Parameter Color 3", GClass122.color_0[2]);
			GClass122.smethod_84("Parameter Color 4", GClass122.color_0[3]);
			GClass122.smethod_84("Parameter Color 5", GClass122.color_0[4]);
			GClass122.smethod_84("Parameter Color 6", GClass122.color_0[5]);
			GClass122.smethod_84("Parameter Color 7", GClass122.color_0[6]);
			GClass122.smethod_84("Parameter Color 8", GClass122.color_0[7]);
			GClass122.smethod_84("Parameter Color 9", GClass122.color_0[8]);
			GClass122.smethod_84("Parameter Color 10", GClass122.color_0[9]);
			GClass122.smethod_84("Graph Back Color", GClass122.color_1);
			GClass122.smethod_84("Graph Grid Color", GClass122.color_2);
			GClass122.smethod_84("Graph X-Axis Color", GClass122.color_3);
			GClass122.smethod_85("Graph Line Thickness", GClass122.int_11);
			GClass122.smethod_83("Graph X-Axis Font", GClass122.font_1);
			GClass122.smethod_83("Graph Y-Axis Font", GClass122.font_0);
			GClass122.smethod_83("Graph Parameter Font", GClass122.font_2);
			GClass122.smethod_86("Lic Number", GClass122.string_14);
			GClass122.smethod_86("Removal Key", GClass122.string_15);
			GClass122.smethod_86("Recent Vehicles", GClass122.string_19);
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x060006ED RID: 1773 RVA: 0x000E792C File Offset: 0x000E5B2C
	// Note: this type is marked as 'beforefieldinit'.
	static GClass122()
	{
		int[] array = new int[4];
		array[0] = 1;
		GClass122.int_7 = array;
		GClass122.string_7 = new string[]
		{
			"COM1",
			"COM1",
			"COM1",
			"COM1"
		};
		GClass122.int_8 = new int[]
		{
			38400,
			38400,
			38400,
			38400
		};
		GClass122.int_9 = 0;
		GClass122.bool_3 = false;
		GClass122.int_10 = 0;
		GClass122.bool_4 = true;
		GClass122.color_0 = new Color[]
		{
			Color.Blue,
			Color.Red,
			Color.Green,
			Color.Orange,
			Color.DarkCyan,
			Color.DarkBlue,
			Color.Pink,
			Color.DarkRed,
			Color.Navy,
			Color.Blue,
			Color.Red,
			Color.LavenderBlush,
			Color.Navy,
			Color.OrangeRed,
			Color.SeaGreen,
			Color.SandyBrown,
			Color.MediumSlateBlue,
			Color.Indigo,
			Color.HotPink,
			Color.Gray
		};
		GClass122.color_1 = Color.White;
		GClass122.color_2 = Color.DarkGray;
		GClass122.color_3 = Color.Black;
		GClass122.int_11 = 1;
		GClass122.font_0 = new Font("Arial", 6f, FontStyle.Regular);
		GClass122.font_1 = new Font("Arial", 7f, FontStyle.Regular);
		GClass122.font_2 = new Font("Arial", 10f, FontStyle.Bold);
		GClass122.int_12 = 1;
		GClass122.string_9 = "English";
		GClass122.string_10 = "English";
		GClass122.string_11 = "Bulgarian";
		GClass122.font_3 = new Font("Arial", 16.2f, FontStyle.Bold);
		GClass122.font_4 = new Font("Arial", 13.8f, FontStyle.Bold);
		GClass122.string_12 = "Tab";
		GClass122.string_13 = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
		GClass122.string_14 = "730C7-06414-786E19";
		GClass122.string_15 = "";
		GClass122.long_0 = 123000L;
		GClass122.string_16 = ".";
		GClass122.string_17 = ".";
		GClass122.string_18 = "Proba123";
		GClass122.string_19 = "";
		GClass122.int_13 = new int[][]
		{
			new int[]
			{
				1989,
				1802,
				1872,
				1804
			},
			new int[]
			{
				1989,
				1804,
				1809
			},
			new int[]
			{
				1989,
				1988
			},
			new int[]
			{
				1807,
				1806
			},
			new int[1],
			new int[1],
			new int[1],
			new int[1],
			new int[1],
			new int[1]
		};
		GClass122.string_20 = new string[]
		{
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};
		GClass122.string_21 = " ";
		GClass122.string_22 = "";
	}

	// Token: 0x040005C6 RID: 1478
	private static string string_0 = "Multiecuscan.enable";

	// Token: 0x040005C7 RID: 1479
	private static string string_1 = "FES_Templates.ini";

	// Token: 0x040005C8 RID: 1480
	private static string string_2 = "FES_Tags.ini";

	// Token: 0x040005C9 RID: 1481
	public static string string_3 = "730C7-06414-786E";

	// Token: 0x040005CA RID: 1482
	private static int int_0 = 127;

	// Token: 0x040005CB RID: 1483
	private static int int_1 = 160;

	// Token: 0x040005CC RID: 1484
	private static int int_2 = 1401333;

	// Token: 0x040005CD RID: 1485
	private static int int_3 = 15;

	// Token: 0x040005CE RID: 1486
	private static int int_4 = 16;

	// Token: 0x040005CF RID: 1487
	private static string string_4 = ".ini";

	// Token: 0x040005D0 RID: 1488
	private static string string_5 = "2.exe";

	// Token: 0x040005D1 RID: 1489
	private static int int_5 = 1;

	// Token: 0x040005D2 RID: 1490
	private static string string_6 = "COM9";

	// Token: 0x040005D3 RID: 1491
	private static int int_6 = 38400;

	// Token: 0x040005D4 RID: 1492
	private static bool bool_0 = true;

	// Token: 0x040005D5 RID: 1493
	private static bool bool_1 = true;

	// Token: 0x040005D6 RID: 1494
	private static bool bool_2 = false;

	// Token: 0x040005D7 RID: 1495
	private static int[] int_7;

	// Token: 0x040005D8 RID: 1496
	private static string[] string_7;

	// Token: 0x040005D9 RID: 1497
	private static int[] int_8;

	// Token: 0x040005DA RID: 1498
	private static int int_9;

	// Token: 0x040005DB RID: 1499
	private static bool bool_3;

	// Token: 0x040005DC RID: 1500
	private static int int_10;

	// Token: 0x040005DD RID: 1501
	private static bool bool_4;

	// Token: 0x040005DE RID: 1502
	private static Color[] color_0;

	// Token: 0x040005DF RID: 1503
	private static Color color_1;

	// Token: 0x040005E0 RID: 1504
	private static Color color_2;

	// Token: 0x040005E1 RID: 1505
	private static Color color_3;

	// Token: 0x040005E2 RID: 1506
	private static int int_11;

	// Token: 0x040005E3 RID: 1507
	private static Font font_0;

	// Token: 0x040005E4 RID: 1508
	private static Font font_1;

	// Token: 0x040005E5 RID: 1509
	private static Font font_2;

	// Token: 0x040005E6 RID: 1510
	private static int int_12;

	// Token: 0x040005E7 RID: 1511
	private static string string_8;

	// Token: 0x040005E8 RID: 1512
	private static string string_9;

	// Token: 0x040005E9 RID: 1513
	private static string string_10;

	// Token: 0x040005EA RID: 1514
	private static string string_11;

	// Token: 0x040005EB RID: 1515
	private static Font font_3;

	// Token: 0x040005EC RID: 1516
	private static Font font_4;

	// Token: 0x040005ED RID: 1517
	private static string string_12;

	// Token: 0x040005EE RID: 1518
	private static string string_13;

	// Token: 0x040005EF RID: 1519
	private static string string_14;

	// Token: 0x040005F0 RID: 1520
	private static string string_15;

	// Token: 0x040005F1 RID: 1521
	private static long long_0;

	// Token: 0x040005F2 RID: 1522
	private static string string_16;

	// Token: 0x040005F3 RID: 1523
	private static string string_17;

	// Token: 0x040005F4 RID: 1524
	private static string string_18;

	// Token: 0x040005F5 RID: 1525
	private static string string_19;

	// Token: 0x040005F6 RID: 1526
	private static int[][] int_13;

	// Token: 0x040005F7 RID: 1527
	private static string[] string_20;

	// Token: 0x040005F8 RID: 1528
	private static string string_21;

	// Token: 0x040005F9 RID: 1529
	private static string string_22;
}
