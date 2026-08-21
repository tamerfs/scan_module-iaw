using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Microsoft.Win32;

// Token: 0x020000C6 RID: 198
public static class GClass125
{
	// Token: 0x06000716 RID: 1814 RVA: 0x000EF164 File Offset: 0x000ED364
	public static void smethod_0()
	{
		if (!GClass125.smethod_1())
		{
			int[] array = GClass125.int_33[0];
			List<int> list = new List<int>();
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i]);
			}
			list.Add(1024);
			GClass125.int_33[0] = list.ToArray();
		}
	}

	// Token: 0x06000717 RID: 1815 RVA: 0x000EF1B8 File Offset: 0x000ED3B8
	public static bool smethod_1()
	{
		int[] array = GClass125.int_33[0];
		bool result = false;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == 1024)
			{
				result = true;
				return result;
			}
		}
		return result;
	}

	// Token: 0x06000718 RID: 1816 RVA: 0x000EF1F0 File Offset: 0x000ED3F0
	public static void smethod_2()
	{
		if (GClass125.smethod_1())
		{
			int[] array = GClass125.int_33[0];
			List<int> list = new List<int>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != 1024)
				{
					list.Add(array[i]);
				}
			}
			GClass125.int_33[0] = list.ToArray();
		}
	}

	// Token: 0x06000719 RID: 1817 RVA: 0x00004AD5 File Offset: 0x00002CD5
	public static string smethod_3()
	{
		return GClass125.string_22;
	}

	// Token: 0x0600071A RID: 1818 RVA: 0x00004ADC File Offset: 0x00002CDC
	public static void smethod_4(string string_39)
	{
		GClass125.string_22 = string_39;
	}

	// Token: 0x0600071B RID: 1819 RVA: 0x00004AE4 File Offset: 0x00002CE4
	public static string smethod_5()
	{
		return GClass125.string_23;
	}

	// Token: 0x0600071C RID: 1820 RVA: 0x00004AEB File Offset: 0x00002CEB
	public static void smethod_6(string string_39)
	{
		GClass125.string_23 = string_39;
		GClass125.string_24 = "";
		GClass125.string_25 = "";
	}

	// Token: 0x0600071D RID: 1821 RVA: 0x00004B07 File Offset: 0x00002D07
	public static string smethod_7()
	{
		if (GClass125.string_24.ToUpper().StartsWith("MP-") && GClass125.string_24.Length > 17 && GClass125.string_24.Length < 29)
		{
			return GClass125.string_24;
		}
		return "";
	}

	// Token: 0x0600071E RID: 1822 RVA: 0x00004B46 File Offset: 0x00002D46
	public static void smethod_8(string string_39)
	{
		if (string_39.StartsWith("MP-"))
		{
			GClass125.string_24 = string_39;
			return;
		}
		GClass125.string_24 = "";
	}

	// Token: 0x0600071F RID: 1823 RVA: 0x00004B66 File Offset: 0x00002D66
	public static string smethod_9()
	{
		if (GClass125.string_25.ToUpper().StartsWith("MP-") && GClass125.string_25.Length > 17 && GClass125.string_25.Length < 29)
		{
			return GClass125.string_25;
		}
		return "";
	}

	// Token: 0x06000720 RID: 1824 RVA: 0x00004BA5 File Offset: 0x00002DA5
	public static void smethod_10(string string_39)
	{
		if (string_39.StartsWith("MP-"))
		{
			GClass125.string_25 = string_39;
			return;
		}
		GClass125.string_25 = "";
	}

	// Token: 0x06000721 RID: 1825 RVA: 0x00004BC5 File Offset: 0x00002DC5
	public static string smethod_11()
	{
		return GClass125.string_28;
	}

	// Token: 0x06000722 RID: 1826 RVA: 0x000EF240 File Offset: 0x000ED440
	public static void smethod_12(string string_39)
	{
		if (string_39 == "")
		{
			GClass125.smethod_2();
			GClass125.string_28 = "";
		}
		else
		{
			GClass125.string_28 = string_39;
		}
		if (GClass125.string_28 == "")
		{
			GClass125.smethod_102(18, Color.Navy);
		}
		if (GClass125.string_28 == "")
		{
			GClass125.smethod_102(19, Color.Blue);
		}
	}

	// Token: 0x06000723 RID: 1827 RVA: 0x00004BCC File Offset: 0x00002DCC
	public static string smethod_13()
	{
		return GClass125.string_29;
	}

	// Token: 0x06000724 RID: 1828 RVA: 0x00004BD3 File Offset: 0x00002DD3
	public static void smethod_14(string string_39)
	{
		GClass125.string_29 = string_39;
	}

	// Token: 0x06000725 RID: 1829 RVA: 0x00004BDB File Offset: 0x00002DDB
	public static bool smethod_15()
	{
		GClass125.smethod_102(19, Color.Blue);
		GClass126.int_8++;
		return GClass125.string_28 == "";
	}

	// Token: 0x06000726 RID: 1830 RVA: 0x00004C04 File Offset: 0x00002E04
	public static string smethod_16()
	{
		return GClass125.string_30;
	}

	// Token: 0x06000727 RID: 1831 RVA: 0x00004C0B File Offset: 0x00002E0B
	public static void smethod_17(string string_39)
	{
		if (GClass125.string_30.Length == 0 || string_39 == "")
		{
			GClass125.string_30 = string_39;
		}
	}

	// Token: 0x06000728 RID: 1832 RVA: 0x00004C2C File Offset: 0x00002E2C
	public static string smethod_18()
	{
		return GClass125.string_19;
	}

	// Token: 0x06000729 RID: 1833 RVA: 0x00004C33 File Offset: 0x00002E33
	public static void smethod_19(string string_39)
	{
		GClass125.string_19 = string_39;
	}

	// Token: 0x0600072A RID: 1834 RVA: 0x00004C3B File Offset: 0x00002E3B
	public static string smethod_20()
	{
		return GClass125.string_16;
	}

	// Token: 0x0600072B RID: 1835 RVA: 0x00004C42 File Offset: 0x00002E42
	public static void smethod_21(string string_39)
	{
		GClass125.string_16 = string_39;
	}

	// Token: 0x0600072C RID: 1836 RVA: 0x00004C4A File Offset: 0x00002E4A
	public static string smethod_22()
	{
		return GClass125.string_17;
	}

	// Token: 0x0600072D RID: 1837 RVA: 0x00004C51 File Offset: 0x00002E51
	public static void smethod_23(string string_39)
	{
		GClass125.string_17 = string_39;
	}

	// Token: 0x0600072E RID: 1838 RVA: 0x00004C59 File Offset: 0x00002E59
	public static string smethod_24()
	{
		return GClass125.string_18;
	}

	// Token: 0x0600072F RID: 1839 RVA: 0x00004C60 File Offset: 0x00002E60
	public static void smethod_25(string string_39)
	{
		GClass125.string_18 = string_39;
	}

	// Token: 0x06000730 RID: 1840 RVA: 0x00004C68 File Offset: 0x00002E68
	public static Font smethod_26()
	{
		return GClass125.font_3;
	}

	// Token: 0x06000731 RID: 1841 RVA: 0x00004C6F File Offset: 0x00002E6F
	public static void smethod_27(Font font_5)
	{
		GClass125.font_3 = font_5;
	}

	// Token: 0x06000732 RID: 1842 RVA: 0x00004C77 File Offset: 0x00002E77
	public static Font smethod_28()
	{
		return GClass125.font_4;
	}

	// Token: 0x06000733 RID: 1843 RVA: 0x00004C7E File Offset: 0x00002E7E
	public static void smethod_29(Font font_5)
	{
		GClass125.font_4 = font_5;
	}

	// Token: 0x06000734 RID: 1844 RVA: 0x00004C86 File Offset: 0x00002E86
	public static string smethod_30()
	{
		return GClass125.string_15;
	}

	// Token: 0x06000735 RID: 1845 RVA: 0x00004C8D File Offset: 0x00002E8D
	public static void smethod_31(string string_39)
	{
		GClass125.string_15 = string_39;
		if (!GClass122.smethod_13().ToLower().EndsWith("multiecuscan.exe"))
		{
			GClass123.int_7 = 9;
		}
	}

	// Token: 0x06000736 RID: 1846 RVA: 0x00004CB2 File Offset: 0x00002EB2
	public static string smethod_32()
	{
		return GClass125.string_32;
	}

	// Token: 0x06000737 RID: 1847 RVA: 0x00004CB9 File Offset: 0x00002EB9
	public static void smethod_33(string string_39)
	{
		GClass125.string_32 = string_39;
	}

	// Token: 0x06000738 RID: 1848 RVA: 0x00004CC1 File Offset: 0x00002EC1
	public static string smethod_34()
	{
		return GClass125.string_33;
	}

	// Token: 0x06000739 RID: 1849 RVA: 0x00004CC8 File Offset: 0x00002EC8
	public static void smethod_35(string string_39)
	{
		GClass125.string_33 = string_39;
	}

	// Token: 0x0600073A RID: 1850 RVA: 0x00004CD0 File Offset: 0x00002ED0
	public static string smethod_36()
	{
		return GClass125.string_2;
	}

	// Token: 0x0600073B RID: 1851 RVA: 0x00004CD7 File Offset: 0x00002ED7
	public static void smethod_37(string string_39)
	{
		GClass125.string_2 = string_39;
	}

	// Token: 0x0600073C RID: 1852 RVA: 0x00004CDF File Offset: 0x00002EDF
	public static int smethod_38(int int_34)
	{
		if (int_34 <= 3 && int_34 >= 0)
		{
			return GClass125.int_26[int_34];
		}
		return 0;
	}

	// Token: 0x0600073D RID: 1853 RVA: 0x00004CF2 File Offset: 0x00002EF2
	public static void smethod_39(int int_34, int int_35)
	{
		if (int_34 <= 3 && int_34 >= 0)
		{
			GClass125.int_26[int_34] = int_35;
			return;
		}
	}

	// Token: 0x0600073E RID: 1854 RVA: 0x00004D05 File Offset: 0x00002F05
	public static string smethod_40(int int_34)
	{
		if (int_34 <= 3 && int_34 >= 0)
		{
			return GClass125.string_14[int_34];
		}
		return "COM1";
	}

	// Token: 0x0600073F RID: 1855 RVA: 0x00004D1C File Offset: 0x00002F1C
	public static void smethod_41(int int_34, string string_39)
	{
		if (int_34 <= 3 && int_34 >= 0)
		{
			GClass125.string_14[int_34] = string_39;
			return;
		}
	}

	// Token: 0x06000740 RID: 1856 RVA: 0x00004D2F File Offset: 0x00002F2F
	public static int smethod_42(int int_34)
	{
		if (int_34 <= 3 && int_34 >= 0)
		{
			return GClass125.int_27[int_34];
		}
		return 0;
	}

	// Token: 0x06000741 RID: 1857 RVA: 0x00004D42 File Offset: 0x00002F42
	public static void smethod_43(int int_34, int int_35)
	{
		if (int_34 <= 3 && int_34 >= 0)
		{
			GClass125.int_27[int_34] = int_35;
			return;
		}
	}

	// Token: 0x06000742 RID: 1858 RVA: 0x00004D55 File Offset: 0x00002F55
	public static int smethod_44()
	{
		return GClass125.int_24;
	}

	// Token: 0x06000743 RID: 1859 RVA: 0x00004D5C File Offset: 0x00002F5C
	public static void smethod_45(int int_34)
	{
		GClass125.int_24 = int_34;
	}

	// Token: 0x06000744 RID: 1860 RVA: 0x00004D64 File Offset: 0x00002F64
	public static bool smethod_46()
	{
		return GClass125.int_24 == 3 || GClass125.int_24 == 5 || GClass125.int_24 == 15;
	}

	// Token: 0x06000745 RID: 1861 RVA: 0x00004D81 File Offset: 0x00002F81
	public static bool smethod_47()
	{
		return !GClass125.smethod_48() && !GClass125.smethod_52();
	}

	// Token: 0x06000746 RID: 1862 RVA: 0x00004D94 File Offset: 0x00002F94
	public static bool smethod_48()
	{
		return GClass125.string_13.StartsWith("IP");
	}

	// Token: 0x06000747 RID: 1863 RVA: 0x00004DA5 File Offset: 0x00002FA5
	public static bool smethod_49()
	{
		return GClass125.int_24 == 6 || GClass125.int_24 == 13;
	}

	// Token: 0x06000748 RID: 1864 RVA: 0x000EF2AC File Offset: 0x000ED4AC
	public static string smethod_50()
	{
		int num = GClass125.string_13.IndexOf(':');
		if (num >= 10 && num <= 18)
		{
			return GClass125.string_13.Substring(2, num - 2);
		}
		return "";
	}

	// Token: 0x06000749 RID: 1865 RVA: 0x000EF2E4 File Offset: 0x000ED4E4
	public static int smethod_51()
	{
		int num = GClass125.string_13.IndexOf(':');
		if (num >= 10 && num <= 18)
		{
			return GClass127.smethod_37(GClass125.string_13.Substring(num + 1));
		}
		return 0;
	}

	// Token: 0x0600074A RID: 1866 RVA: 0x00004DBA File Offset: 0x00002FBA
	public static bool smethod_52()
	{
		return GClass125.string_13.StartsWith("BLE");
	}

	// Token: 0x0600074B RID: 1867 RVA: 0x00004DCB File Offset: 0x00002FCB
	public static string smethod_53()
	{
		if (GClass125.string_13.Length < 4)
		{
			return "";
		}
		return GClass125.string_13.Substring(3);
	}

	// Token: 0x0600074C RID: 1868 RVA: 0x00004DEB File Offset: 0x00002FEB
	public static void smethod_54(string string_39)
	{
		if (string_39.Length > 2)
		{
			GClass125.string_13 = "BLE" + string_39;
			return;
		}
		GClass125.string_13 = "";
	}

	// Token: 0x0600074D RID: 1869 RVA: 0x00004E11 File Offset: 0x00003011
	public static string smethod_55()
	{
		return GClass125.string_13;
	}

	// Token: 0x0600074E RID: 1870 RVA: 0x00004E18 File Offset: 0x00003018
	public static void smethod_56(string string_39)
	{
		GClass125.string_13 = string_39;
	}

	// Token: 0x0600074F RID: 1871 RVA: 0x00004E20 File Offset: 0x00003020
	public static int smethod_57()
	{
		return GClass125.int_25;
	}

	// Token: 0x06000750 RID: 1872 RVA: 0x00004E27 File Offset: 0x00003027
	public static void smethod_58(int int_34)
	{
		GClass125.int_25 = int_34;
	}

	// Token: 0x06000751 RID: 1873 RVA: 0x00004E2F File Offset: 0x0000302F
	public static bool smethod_59()
	{
		return GClass125.bool_1;
	}

	// Token: 0x06000752 RID: 1874 RVA: 0x00004E36 File Offset: 0x00003036
	public static void smethod_60(bool bool_9)
	{
		GClass125.bool_1 = bool_9;
	}

	// Token: 0x06000753 RID: 1875 RVA: 0x00004E3E File Offset: 0x0000303E
	public static bool smethod_61()
	{
		return GClass125.bool_2;
	}

	// Token: 0x06000754 RID: 1876 RVA: 0x00004E45 File Offset: 0x00003045
	public static void smethod_62(bool bool_9)
	{
		GClass125.bool_2 = bool_9;
	}

	// Token: 0x06000755 RID: 1877 RVA: 0x00004E4D File Offset: 0x0000304D
	public static int smethod_63()
	{
		return GClass125.int_28;
	}

	// Token: 0x06000756 RID: 1878 RVA: 0x00004E54 File Offset: 0x00003054
	public static void smethod_64(int int_34)
	{
		GClass125.int_28 = int_34;
	}

	// Token: 0x06000757 RID: 1879 RVA: 0x00004E5C File Offset: 0x0000305C
	public static bool smethod_65()
	{
		return GClass125.bool_8;
	}

	// Token: 0x06000758 RID: 1880 RVA: 0x00004E63 File Offset: 0x00003063
	public static void smethod_66(bool bool_9)
	{
		GClass125.bool_8 = bool_9;
	}

	// Token: 0x06000759 RID: 1881 RVA: 0x00004E6B File Offset: 0x0000306B
	public static int smethod_67()
	{
		return GClass125.int_32;
	}

	// Token: 0x0600075A RID: 1882 RVA: 0x00004E72 File Offset: 0x00003072
	public static void smethod_68(int int_34)
	{
		GClass125.int_32 = int_34;
	}

	// Token: 0x0600075B RID: 1883 RVA: 0x00004E7A File Offset: 0x0000307A
	public static bool smethod_69()
	{
		return GClass125.int_30 == 1 || GClass125.int_30 == 9;
	}

	// Token: 0x0600075C RID: 1884 RVA: 0x00004E8F File Offset: 0x0000308F
	public static void smethod_70(bool bool_9)
	{
		if (GClass125.int_30 < 6 && bool_9)
		{
			GClass125.int_30 = 1;
			return;
		}
		if (GClass125.int_30 < 3 && !bool_9)
		{
			GClass125.int_30 = 0;
			return;
		}
		GClass125.int_30 = (bool_9 ? 9 : 8);
	}

	// Token: 0x0600075D RID: 1885 RVA: 0x00004EC3 File Offset: 0x000030C3
	public static bool smethod_71()
	{
		return GClass125.bool_3;
	}

	// Token: 0x0600075E RID: 1886 RVA: 0x00004ECA File Offset: 0x000030CA
	public static void smethod_72(bool bool_9)
	{
		GClass125.bool_3 = bool_9;
	}

	// Token: 0x0600075F RID: 1887 RVA: 0x00004ED2 File Offset: 0x000030D2
	public static bool smethod_73()
	{
		return GClass125.bool_4;
	}

	// Token: 0x06000760 RID: 1888 RVA: 0x00004ED9 File Offset: 0x000030D9
	public static void smethod_74(bool bool_9)
	{
		GClass125.bool_4 = bool_9;
	}

	// Token: 0x06000761 RID: 1889 RVA: 0x00004EE1 File Offset: 0x000030E1
	public static bool smethod_75()
	{
		return GClass125.bool_5;
	}

	// Token: 0x06000762 RID: 1890 RVA: 0x00004EE8 File Offset: 0x000030E8
	public static void smethod_76(bool bool_9)
	{
		GClass125.bool_5 = bool_9;
	}

	// Token: 0x06000763 RID: 1891 RVA: 0x00004EF0 File Offset: 0x000030F0
	public static bool smethod_77()
	{
		return GClass125.bool_6;
	}

	// Token: 0x06000764 RID: 1892 RVA: 0x00004EF7 File Offset: 0x000030F7
	public static void smethod_78(bool bool_9)
	{
		GClass125.bool_6 = bool_9;
	}

	// Token: 0x06000765 RID: 1893 RVA: 0x00004EFF File Offset: 0x000030FF
	public static bool smethod_79()
	{
		return GClass125.bool_7;
	}

	// Token: 0x06000766 RID: 1894 RVA: 0x00004F06 File Offset: 0x00003106
	public static void smethod_80(bool bool_9)
	{
		GClass125.bool_7 = bool_9;
	}

	// Token: 0x06000767 RID: 1895 RVA: 0x00004F0E File Offset: 0x0000310E
	public static int smethod_81()
	{
		return GClass125.int_29;
	}

	// Token: 0x06000768 RID: 1896 RVA: 0x00004F15 File Offset: 0x00003115
	public static void smethod_82(int int_34)
	{
		GClass125.int_29 = int_34;
	}

	// Token: 0x06000769 RID: 1897 RVA: 0x00004F1D File Offset: 0x0000311D
	public static void smethod_83(string string_39)
	{
		if (string_39 == "MODEL")
		{
			GClass125.bool_3 = false;
			return;
		}
		if (string_39 == "MAKE")
		{
			GClass125.bool_3 = true;
			return;
		}
		GClass125.string_23 = "";
	}

	// Token: 0x0600076A RID: 1898 RVA: 0x00004F51 File Offset: 0x00003151
	public static bool smethod_84()
	{
		return GClass125.int_30 == 8 || GClass125.int_30 == 9 || GClass125.int_30 == 5 || GClass125.int_30 == 7;
	}

	// Token: 0x0600076B RID: 1899 RVA: 0x00004F76 File Offset: 0x00003176
	public static void smethod_85(bool bool_9)
	{
		GClass125.int_30 = (bool_9 ? 9 : 8);
	}

	// Token: 0x0600076C RID: 1900 RVA: 0x00004F85 File Offset: 0x00003185
	public static string smethod_86()
	{
		return GClass125.string_23 + "_" + GClass125.string_20;
	}

	// Token: 0x0600076D RID: 1901 RVA: 0x00004F9B File Offset: 0x0000319B
	public static void smethod_87(string string_39)
	{
		if (string_39.Length > 10)
		{
			GClass125.string_20 = string_39.Substring(0, 9);
			return;
		}
		GClass125.string_20 = string_39;
	}

	// Token: 0x0600076E RID: 1902 RVA: 0x00004FBC File Offset: 0x000031BC
	public static string smethod_88()
	{
		return GClass125.string_24 + "_" + GClass125.string_20;
	}

	// Token: 0x0600076F RID: 1903 RVA: 0x00004FD2 File Offset: 0x000031D2
	public static void smethod_89(string string_39)
	{
		if (string_39.Length > 14)
		{
			GClass125.string_20 = string_39.Substring(0, 9);
			return;
		}
		GClass125.string_20 = string_39;
	}

	// Token: 0x06000770 RID: 1904 RVA: 0x00004FF3 File Offset: 0x000031F3
	public static string smethod_90()
	{
		return GClass125.string_25 + "_" + GClass125.string_20;
	}

	// Token: 0x06000771 RID: 1905 RVA: 0x00005009 File Offset: 0x00003209
	public static string smethod_91()
	{
		return GClass125.string_21;
	}

	// Token: 0x06000772 RID: 1906 RVA: 0x00005010 File Offset: 0x00003210
	public static void smethod_92(string string_39)
	{
		GClass125.string_21 = string_39;
	}

	// Token: 0x06000773 RID: 1907 RVA: 0x00005018 File Offset: 0x00003218
	public static long smethod_93()
	{
		return GClass125.long_0;
	}

	// Token: 0x06000774 RID: 1908 RVA: 0x0000501F File Offset: 0x0000321F
	public static void smethod_94(long long_1)
	{
		GClass125.long_0 = long_1;
	}

	// Token: 0x06000775 RID: 1909 RVA: 0x00005027 File Offset: 0x00003227
	public static string smethod_95()
	{
		return GClass125.string_34;
	}

	// Token: 0x06000776 RID: 1910 RVA: 0x0000502E File Offset: 0x0000322E
	public static void smethod_96(string string_39)
	{
		GClass125.string_34 = string_39;
	}

	// Token: 0x06000777 RID: 1911 RVA: 0x00005036 File Offset: 0x00003236
	public static bool smethod_97()
	{
		return !GClass125.string_18.ToLower().Contains("multiecuscan.exe");
	}

	// Token: 0x06000778 RID: 1912 RVA: 0x0000504F File Offset: 0x0000324F
	public static string smethod_98()
	{
		return GClass125.string_35;
	}

	// Token: 0x06000779 RID: 1913 RVA: 0x00005056 File Offset: 0x00003256
	public static void smethod_99(string string_39)
	{
		GClass125.string_35 = string_39;
	}

	// Token: 0x0600077A RID: 1914 RVA: 0x000EF31C File Offset: 0x000ED51C
	public static void smethod_100(int int_34)
	{
		if (GClass125.string_35.Length > 0)
		{
			GClass125.string_35 += ",";
			GClass125.string_35 = GClass125.string_35.Replace("(" + int_34.ToString() + "),", "");
		}
		GClass125.string_35 = GClass125.string_35 + "(" + int_34.ToString() + ")";
		int i = 0;
		for (int j = 0; j < GClass125.string_35.Length; j++)
		{
			if (GClass125.string_35[j] == ',')
			{
				i++;
			}
		}
		while (i > 20)
		{
			GClass125.string_35 = GClass125.string_35.Substring(GClass125.string_35.IndexOf(",") + 1);
			i--;
		}
	}

	// Token: 0x0600077B RID: 1915 RVA: 0x0000505E File Offset: 0x0000325E
	public static Color smethod_101(int int_34)
	{
		if (int_34 < GClass125.color_0.Length)
		{
			return GClass125.color_0[int_34];
		}
		return GClass125.color_0[GClass125.color_0.Length - 1];
	}

	// Token: 0x0600077C RID: 1916 RVA: 0x00005089 File Offset: 0x00003289
	public static void smethod_102(int int_34, Color color_4)
	{
		if (int_34 < GClass125.color_0.Length)
		{
			GClass125.color_0[int_34] = color_4;
		}
	}

	// Token: 0x0600077D RID: 1917 RVA: 0x000050A1 File Offset: 0x000032A1
	public static Color smethod_103()
	{
		return GClass125.color_1;
	}

	// Token: 0x0600077E RID: 1918 RVA: 0x000050A8 File Offset: 0x000032A8
	public static void smethod_104(Color color_4)
	{
		GClass125.color_1 = color_4;
	}

	// Token: 0x0600077F RID: 1919 RVA: 0x000050B0 File Offset: 0x000032B0
	public static Color smethod_105()
	{
		return GClass125.color_2;
	}

	// Token: 0x06000780 RID: 1920 RVA: 0x000050B7 File Offset: 0x000032B7
	public static void smethod_106(Color color_4)
	{
		GClass125.color_2 = color_4;
	}

	// Token: 0x06000781 RID: 1921 RVA: 0x000050BF File Offset: 0x000032BF
	public static Color smethod_107()
	{
		return GClass125.color_3;
	}

	// Token: 0x06000782 RID: 1922 RVA: 0x000050C6 File Offset: 0x000032C6
	public static void smethod_108(Color color_4)
	{
		GClass125.color_3 = color_4;
	}

	// Token: 0x06000783 RID: 1923 RVA: 0x000050CE File Offset: 0x000032CE
	public static int smethod_109()
	{
		return GClass125.int_31;
	}

	// Token: 0x06000784 RID: 1924 RVA: 0x000050D5 File Offset: 0x000032D5
	public static void smethod_110(int int_34)
	{
		GClass125.int_31 = int_34;
	}

	// Token: 0x06000785 RID: 1925 RVA: 0x000050DD File Offset: 0x000032DD
	public static Font smethod_111()
	{
		return GClass125.font_0;
	}

	// Token: 0x06000786 RID: 1926 RVA: 0x000050E4 File Offset: 0x000032E4
	public static void smethod_112(Font font_5)
	{
		GClass125.font_0 = font_5;
	}

	// Token: 0x06000787 RID: 1927 RVA: 0x000050EC File Offset: 0x000032EC
	public static Font smethod_113()
	{
		return GClass125.font_1;
	}

	// Token: 0x06000788 RID: 1928 RVA: 0x000050F3 File Offset: 0x000032F3
	public static void smethod_114(Font font_5)
	{
		GClass125.font_1 = font_5;
	}

	// Token: 0x06000789 RID: 1929 RVA: 0x000050FB File Offset: 0x000032FB
	public static Font smethod_115()
	{
		return GClass125.font_2;
	}

	// Token: 0x0600078A RID: 1930 RVA: 0x00005102 File Offset: 0x00003302
	public static void smethod_116(Font font_5)
	{
		GClass125.font_2 = font_5;
	}

	// Token: 0x0600078B RID: 1931 RVA: 0x0000510A File Offset: 0x0000330A
	public static int[] smethod_117(int int_34)
	{
		return GClass125.int_33[int_34];
	}

	// Token: 0x0600078C RID: 1932 RVA: 0x00005113 File Offset: 0x00003313
	public static void smethod_118(int int_34, int[] int_35)
	{
		GClass125.int_33[int_34] = int_35;
	}

	// Token: 0x0600078D RID: 1933 RVA: 0x0000511D File Offset: 0x0000331D
	public static string smethod_119(int int_34)
	{
		return GClass125.string_36[int_34];
	}

	// Token: 0x0600078E RID: 1934 RVA: 0x00005126 File Offset: 0x00003326
	public static void smethod_120(int int_34, string string_39)
	{
		GClass125.string_36[int_34] = string_39;
	}

	// Token: 0x0600078F RID: 1935 RVA: 0x000EF3EC File Offset: 0x000ED5EC
	private static void smethod_121(string string_39, Font font_5)
	{
		GClass125.smethod_125(string_39, string.Concat(new string[]
		{
			font_5.Name,
			";",
			font_5.Style.ToString(),
			";",
			Convert.ToInt32(10f * font_5.SizeInPoints).ToString(),
			";",
			font_5.SizeInPoints.ToString(),
			"pt"
		}), RegistryValueKind.String);
	}

	// Token: 0x06000790 RID: 1936 RVA: 0x00005130 File Offset: 0x00003330
	private static void smethod_122(string string_39, Color color_4)
	{
		GClass125.smethod_125(string_39, color_4.ToArgb(), RegistryValueKind.DWord);
	}

	// Token: 0x06000791 RID: 1937 RVA: 0x00005145 File Offset: 0x00003345
	private static void smethod_123(string string_39, int int_34)
	{
		GClass125.smethod_125(string_39, int_34, RegistryValueKind.DWord);
	}

	// Token: 0x06000792 RID: 1938 RVA: 0x00005154 File Offset: 0x00003354
	private static void smethod_124(string string_39, string string_40)
	{
		GClass125.smethod_125(string_39, string_40, RegistryValueKind.String);
	}

	// Token: 0x06000793 RID: 1939 RVA: 0x000E6A68 File Offset: 0x000E4C68
	private static void smethod_125(string string_39, object object_0, RegistryValueKind registryValueKind_0)
	{
		using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software", true))
		{
			using (RegistryKey registryKey2 = registryKey.OpenSubKey("Multiecuscan", true))
			{
				if (registryKey2 == null)
				{
					using (RegistryKey registryKey3 = registryKey.CreateSubKey("Multiecuscan"))
					{
						registryKey3.SetValue(string_39, object_0, registryValueKind_0);
						return;
					}
				}
				registryKey2.SetValue(string_39, object_0, registryValueKind_0);
			}
		}
	}

	// Token: 0x06000794 RID: 1940 RVA: 0x000EF478 File Offset: 0x000ED678
	private static int smethod_126(string string_39, int int_34)
	{
		object obj = GClass125.smethod_130(string_39);
		if (obj == null)
		{
			return int_34;
		}
		return (int)obj;
	}

	// Token: 0x06000795 RID: 1941 RVA: 0x000EF498 File Offset: 0x000ED698
	private static string smethod_127(string string_39, string string_40)
	{
		object obj = GClass125.smethod_130(string_39);
		if (obj == null)
		{
			return string_40;
		}
		return (string)obj;
	}

	// Token: 0x06000796 RID: 1942 RVA: 0x000EF4B8 File Offset: 0x000ED6B8
	private static Color smethod_128(string string_39, Color color_4)
	{
		object obj = GClass125.smethod_130(string_39);
		if (obj == null)
		{
			return color_4;
		}
		return Color.FromArgb((int)obj);
	}

	// Token: 0x06000797 RID: 1943 RVA: 0x000EF4DC File Offset: 0x000ED6DC
	private static Font smethod_129(string string_39, Font font_5)
	{
		object obj = GClass125.smethod_130(string_39);
		if (obj == null)
		{
			return font_5;
		}
		string text = (string)obj;
		string[] array = text.Split(new char[]
		{
			';'
		});
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
		if (array.Length != 0)
		{
			familyName = array[0];
		}
		try
		{
			if (array.Length > 3)
			{
				emSize = (float)(Convert.ToDouble(array[2]) / 10.0);
			}
			else
			{
				emSize = (float)Convert.ToDouble(array[2].Replace("pt", ""));
			}
		}
		catch (Exception)
		{
		}
		return new Font(familyName, emSize, style);
	}

	// Token: 0x06000798 RID: 1944 RVA: 0x000EF5D0 File Offset: 0x000ED7D0
	private static object smethod_130(string string_39)
	{
		object value;
		using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software"))
		{
			using (RegistryKey registryKey2 = registryKey.OpenSubKey("Multiecuscan"))
			{
				value = registryKey2.GetValue(string_39);
			}
		}
		return value;
	}

	// Token: 0x06000799 RID: 1945 RVA: 0x000EF634 File Offset: 0x000ED834
	public static void smethod_131()
	{
		try
		{
			GClass125.int_24 = GClass125.smethod_126("Interface 0 Type Ex", GClass125.int_24);
			GClass125.string_13 = GClass125.smethod_127("Interface 0 Port", GClass125.string_13);
			GClass125.int_25 = GClass125.smethod_126("Interface 0 Port Speed", GClass125.int_25);
			GClass125.int_26[0] = GClass125.smethod_126("Interface 1 Type", GClass125.int_26[0]);
			GClass125.int_26[0] = GClass125.smethod_126("Interface 1 Type Ex", GClass125.int_26[0]);
			GClass125.string_14[0] = GClass125.smethod_127("Interface 1 Port", GClass125.string_14[0]);
			GClass125.int_27[0] = GClass125.smethod_126("Interface 1 Port Speed", GClass125.int_27[0]);
			GClass125.int_26[1] = GClass125.smethod_126("Interface 2 Type", GClass125.int_26[1]);
			GClass125.int_26[1] = GClass125.smethod_126("Interface 2 Type Ex", GClass125.int_26[1]);
			GClass125.string_14[1] = GClass125.smethod_127("Interface 2 Port", GClass125.string_14[1]);
			GClass125.int_27[1] = GClass125.smethod_126("Interface 2 Port Speed", GClass125.int_27[1]);
			GClass125.int_26[2] = GClass125.smethod_126("Interface 3 Type", GClass125.int_26[2]);
			GClass125.int_26[2] = GClass125.smethod_126("Interface 3 Type Ex", GClass125.int_26[2]);
			GClass125.string_14[2] = GClass125.smethod_127("Interface 3 Port", GClass125.string_14[2]);
			GClass125.int_27[2] = GClass125.smethod_126("Interface 3 Port Speed", GClass125.int_27[2]);
			GClass125.int_26[3] = GClass125.smethod_126("Interface 4 Type", GClass125.int_26[3]);
			GClass125.int_26[3] = GClass125.smethod_126("Interface 4 Type Ex", GClass125.int_26[3]);
			GClass125.string_14[3] = GClass125.smethod_127("Interface 4 Port", GClass125.string_14[3]);
			GClass125.int_27[3] = GClass125.smethod_126("Interface 4 Port Speed", GClass125.int_27[3]);
			if (GClass125.int_26[0] == 8)
			{
				GClass125.int_26[0] = 2;
			}
			if (GClass125.int_26[1] == 8)
			{
				GClass125.int_26[1] = 2;
			}
			if (GClass125.int_26[2] == 8)
			{
				GClass125.int_26[2] = 2;
			}
			if (GClass125.int_26[3] == 8)
			{
				GClass125.int_26[3] = 2;
			}
			GClass125.color_0[0] = GClass125.smethod_128("Parameter Color 1", GClass125.color_0[0]);
			GClass125.color_0[1] = GClass125.smethod_128("Parameter Color 2", GClass125.color_0[1]);
			GClass125.color_0[2] = GClass125.smethod_128("Parameter Color 3", GClass125.color_0[2]);
			GClass125.color_0[3] = GClass125.smethod_128("Parameter Color 4", GClass125.color_0[3]);
			GClass125.color_0[4] = GClass125.smethod_128("Parameter Color 5", GClass125.color_0[4]);
			GClass125.color_0[5] = GClass125.smethod_128("Parameter Color 6", GClass125.color_0[5]);
			GClass125.color_0[6] = GClass125.smethod_128("Parameter Color 7", GClass125.color_0[6]);
			GClass125.color_0[7] = GClass125.smethod_128("Parameter Color 8", GClass125.color_0[7]);
			GClass125.color_0[8] = GClass125.smethod_128("Parameter Color 9", GClass125.color_0[8]);
			GClass125.color_0[9] = GClass125.smethod_128("Parameter Color 10", GClass125.color_0[9]);
			GClass125.color_0[10] = GClass125.smethod_128("Parameter Color 11", GClass125.color_0[10]);
			GClass125.color_0[11] = GClass125.smethod_128("Parameter Color 12", GClass125.color_0[11]);
			GClass125.color_0[12] = GClass125.smethod_128("Parameter Color 13", GClass125.color_0[12]);
			GClass125.color_0[13] = GClass125.smethod_128("Parameter Color 14", GClass125.color_0[13]);
			GClass125.color_0[14] = GClass125.smethod_128("Parameter Color 15", GClass125.color_0[14]);
			GClass125.color_0[15] = GClass125.smethod_128("Parameter Color 16", GClass125.color_0[15]);
			GClass125.color_0[16] = GClass125.smethod_128("Parameter Color 17", GClass125.color_0[16]);
			GClass125.color_0[17] = GClass125.smethod_128("Parameter Color 18", GClass125.color_0[17]);
			GClass125.color_0[18] = GClass125.smethod_128("Parameter Color 19", GClass125.color_0[18]);
			GClass125.color_0[19] = GClass125.smethod_128("Parameter Color 20", GClass125.color_0[19]);
			GClass125.color_1 = GClass125.smethod_128("Graph Back Color", GClass125.color_1);
			GClass125.color_2 = GClass125.smethod_128("Graph Grid Color", GClass125.color_2);
			GClass125.color_3 = GClass125.smethod_128("Graph X-Axis Color", GClass125.color_3);
			GClass125.int_31 = GClass125.smethod_126("Graph Line Thickness", GClass125.int_31);
			GClass125.font_1 = GClass125.smethod_129("Graph X-Axis Font", GClass125.font_1);
			GClass125.font_0 = GClass125.smethod_129("Graph Y-Axis Font", GClass125.font_0);
			GClass125.font_2 = GClass125.smethod_129("Graph Parameter Font", GClass125.font_2);
			GClass125.bool_1 = (GClass125.smethod_126("Auto Detect Interface", (GClass125.bool_0 > false) ? 1 : 0) == 1);
			GClass125.bool_1 = (GClass125.smethod_126("Show Available Ports Only", (GClass125.bool_1 > false) ? 1 : 0) == 1);
			GClass125.int_28 = GClass125.smethod_126("KWP2000 Timings", GClass125.int_28);
			GClass125.bool_2 = (GClass125.smethod_126("Show Adapter Message", (GClass125.bool_2 > false) ? 1 : 0) == 1);
			GClass125.bool_8 = (GClass125.smethod_126("High Latency mode", (GClass125.bool_8 > false) ? 1 : 0) == 1);
			GClass125.bool_3 = (GClass125.smethod_126("Convert KMs to Miles", (GClass125.bool_3 > false) ? 1 : 0) == 1);
			GClass125.bool_4 = (GClass125.smethod_126("Convert C to F", (GClass125.bool_4 > false) ? 1 : 0) == 1);
			GClass125.bool_5 = (GClass125.smethod_126("Convert BAR to PSI", (GClass125.bool_5 > false) ? 1 : 0) == 1);
			GClass125.bool_6 = (GClass125.smethod_126("Convert KG to LB", (GClass125.bool_6 > false) ? 1 : 0) == 1);
			GClass125.bool_7 = (GClass125.smethod_126("Convert MM to IN", (GClass125.bool_7 > false) ? 1 : 0) == 1);
			GClass125.int_32 = GClass125.smethod_126("Screen Repaint Interval", GClass125.int_32);
			GClass125.int_30 = GClass125.smethod_126("Show Disclaimer", GClass125.int_30);
			GClass125.int_29 = GClass125.smethod_126("Last Selection", GClass125.int_29);
			GClass125.string_16 = GClass125.smethod_127("UI Language", GClass125.string_16);
			GClass125.string_17 = GClass125.smethod_127("Data Language", GClass125.string_17);
			GClass125.font_3 = GClass125.smethod_129("UI Font 1", GClass125.font_3);
			GClass125.font_4 = GClass125.smethod_129("UI Font 2", GClass125.font_4);
			GClass125.string_19 = GClass125.smethod_127("CSV Separator", GClass125.string_19);
			GClass125.string_32 = GClass125.smethod_127("Export Folder", GClass125.string_32);
			GClass125.string_33 = GClass125.smethod_127("LOG Folder", GClass125.string_33);
			GClass125.string_23 = GClass125.smethod_127("Lic Number", GClass125.string_23);
			GClass125.string_24 = GClass125.smethod_127("Lic Number M", GClass125.string_24);
			GClass125.string_25 = GClass125.smethod_127("Lic Number D", GClass125.string_25);
			GClass125.string_28 = GClass125.smethod_127("Removal Key", GClass125.string_28);
			GClass125.string_29 = GClass125.smethod_127("Removal KeyH", GClass125.string_29);
			GClass125.string_21 = GClass125.smethod_127("Purchase Token", GClass125.string_21);
			GClass125.string_31 = GClass125.smethod_127("CANtieCAR Serial", GClass125.string_31);
			GClass125.string_35 = GClass125.smethod_127("Recent Vehicles", "");
			int num = GClass125.string_35.IndexOf(";");
			if (num > -1)
			{
				try
				{
					string[] array = GClass125.string_35.Substring(num + 1).Replace("(", "").Replace(")", "").Split(new char[]
					{
						','
					});
					byte[] array2 = new byte[array.Length - 1];
					byte[] bytes = Encoding.ASCII.GetBytes(GClass125.string_23);
					GClass125.string_35 = GClass125.string_35.Substring(0, num);
					byte b = 0;
					int num2 = GClass127.smethod_37(array[array2.Length]);
					for (int i = 0; i < bytes.Length; i++)
					{
						b += bytes[i];
					}
					num2 -= 350;
					for (int j = 0; j < array2.Length; j++)
					{
						int num3 = GClass127.smethod_37(array[j]);
						if (bytes.Length > j)
						{
							num3 -= (int)bytes[j];
						}
						if (num3 >= 256 || num3 <= 0)
						{
							throw new Exception("Byte overflow: " + num3.ToString());
						}
						array2[j] = (byte)num3;
						b += array2[j];
					}
					num2 = num2 - 100 - (int)b;
					if (num2 != 0)
					{
						throw new Exception("Byte error: " + num2.ToString());
					}
					GClass125.string_30 = Encoding.ASCII.GetString(array2);
				}
				catch (Exception ex)
				{
					GClass126.smethod_2("ERROR02: " + ex.Message, 0);
				}
			}
			return;
		}
		catch (Exception)
		{
		}
		try
		{
			FileStream fileStream = new FileStream(GClass125.string_15 + "\\" + GClass125.string_2.Replace(GClass125.string_11, GClass125.string_12), FileMode.Open, FileAccess.Read);
			GClass125.string_34 = GClass125.string_34 + GClass125.smethod_135(fileStream, (long)GClass125.int_19) + GClass125.smethod_135(fileStream, (long)GClass125.int_20) + GClass125.smethod_135(fileStream, (long)GClass125.int_21);
			GClass125.long_0 = fileStream.Length;
			fileStream.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x0600079A RID: 1946 RVA: 0x000F000C File Offset: 0x000EE20C
	private static string smethod_132(int int_34)
	{
		string text = "";
		for (int i = 0; i < GClass125.int_33[int_34].Length; i++)
		{
			text = text + ((i > 0) ? "," : "") + GClass125.int_33[int_34][i].ToString();
		}
		return text;
	}

	// Token: 0x0600079B RID: 1947 RVA: 0x000F0060 File Offset: 0x000EE260
	public static void smethod_133()
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(GClass125.string_15 + "\\" + GClass125.string_3);
			for (int i = 0; i < 10; i++)
			{
				streamWriter.WriteLine(i.ToString() + "=" + GClass125.smethod_132(i));
			}
			streamWriter.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x0600079C RID: 1948 RVA: 0x000F00D4 File Offset: 0x000EE2D4
	public static void smethod_134()
	{
		GClass125.string_34 = "";
		char[] separator = new char[]
		{
			','
		};
		try
		{
			StreamReader streamReader = new StreamReader(File.OpenRead(GClass125.string_15 + "\\" + GClass125.string_3));
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				if (text[1] == '=' && text.Length > 2)
				{
					int num = Convert.ToInt32(text.Substring(0, 1));
					text = text.Substring(2);
					string[] array = text.Split(separator);
					GClass125.int_33[num] = new int[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						GClass125.int_33[num][i] = Convert.ToInt32(array[i]);
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
			FileStream fileStream = new FileStream(GClass125.string_15 + "\\" + GClass125.string_2.Replace(GClass125.string_11, GClass125.string_12), FileMode.Open, FileAccess.Read);
			GClass125.string_34 = GClass125.string_34 + GClass125.smethod_135(fileStream, (long)GClass125.int_19) + GClass125.smethod_135(fileStream, (long)GClass125.int_20) + GClass125.smethod_135(fileStream, (long)GClass125.int_21);
			GClass125.long_0 = fileStream.Length;
			fileStream.Close();
		}
		catch (Exception value2)
		{
			Console.WriteLine(value2);
		}
	}

	// Token: 0x0600079D RID: 1949 RVA: 0x000F0238 File Offset: 0x000EE438
	private static string smethod_135(FileStream fileStream_0, long long_1)
	{
		byte[] array = new byte[GClass125.int_23];
		fileStream_0.Seek(long_1, SeekOrigin.Begin);
		fileStream_0.Read(array, 0, array.Length);
		return GClass127.smethod_11(array).Replace(GClass125.string_37, GClass125.string_38);
	}

	// Token: 0x0600079E RID: 1950 RVA: 0x000F027C File Offset: 0x000EE47C
	public static void smethod_136()
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(GClass125.string_15 + "\\" + GClass125.string_4, false, Encoding.Unicode);
			for (int i = 0; i < 10; i++)
			{
				streamWriter.WriteLine(i.ToString() + "=" + GClass125.string_36[i]);
			}
			streamWriter.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x0600079F RID: 1951 RVA: 0x000F02F4 File Offset: 0x000EE4F4
	public static void smethod_137()
	{
		(new char[1])[0] = ',';
		try
		{
			StreamReader streamReader = new StreamReader(File.OpenRead(GClass125.string_15 + "\\" + GClass125.string_4));
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				if (text[1] == '=' && text.Length > 2)
				{
					int num = Convert.ToInt32(text.Substring(0, 1));
					GClass125.string_36[num] = text.Substring(2);
				}
			}
			streamReader.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x060007A0 RID: 1952 RVA: 0x000F0388 File Offset: 0x000EE588
	public static void smethod_138()
	{
		try
		{
			GClass125.smethod_123("Auto Detect Interface", (GClass125.bool_0 > false) ? 1 : 0);
			GClass125.smethod_123("Interface 0 Type Ex", GClass125.int_24);
			GClass125.smethod_124("Interface 0 Port", GClass125.string_13);
			GClass125.smethod_123("Interface 0 Port Speed", GClass125.int_25);
			GClass125.smethod_123("Interface 1 Type Ex", GClass125.int_26[0]);
			GClass125.smethod_124("Interface 1 Port", GClass125.string_14[0]);
			GClass125.smethod_123("Interface 1 Port Speed", GClass125.int_27[0]);
			GClass125.smethod_123("Interface 2 Type Ex", GClass125.int_26[1]);
			GClass125.smethod_124("Interface 2 Port", GClass125.string_14[1]);
			GClass125.smethod_123("Interface 2 Port Speed", GClass125.int_27[1]);
			GClass125.smethod_123("Interface 3 Type Ex", GClass125.int_26[2]);
			GClass125.smethod_124("Interface 3 Port", GClass125.string_14[2]);
			GClass125.smethod_123("Interface 3 Port Speed", GClass125.int_27[2]);
			GClass125.smethod_123("Interface 4 Type Ex", GClass125.int_26[3]);
			GClass125.smethod_124("Interface 4 Port", GClass125.string_14[3]);
			GClass125.smethod_123("Interface 4 Port Speed", GClass125.int_27[3]);
			GClass125.smethod_123("Show Available Ports Only", (GClass125.bool_1 > false) ? 1 : 0);
			GClass125.smethod_123("KWP2000 Timings", GClass125.int_28);
			GClass125.smethod_123("Show Adapter Message", (GClass125.bool_2 > false) ? 1 : 0);
			GClass125.smethod_123("High Latency mode", (GClass125.bool_8 > false) ? 1 : 0);
			GClass125.smethod_123("Convert KMs to Miles", (GClass125.bool_3 > false) ? 1 : 0);
			GClass125.smethod_123("Convert C to F", (GClass125.bool_4 > false) ? 1 : 0);
			GClass125.smethod_123("Convert BAR to PSI", (GClass125.bool_5 > false) ? 1 : 0);
			GClass125.smethod_123("Convert KG to LB", (GClass125.bool_6 > false) ? 1 : 0);
			GClass125.smethod_123("Convert MM to IN", (GClass125.bool_7 > false) ? 1 : 0);
			GClass125.smethod_123("Screen Repaint Interval", GClass125.int_32);
			GClass125.smethod_123("Show Disclaimer", GClass125.int_30);
			GClass125.smethod_123("Last Selection", GClass125.int_29);
			GClass125.smethod_124("UI Language", GClass125.string_16);
			GClass125.smethod_124("Data Language", GClass125.string_17);
			GClass125.smethod_121("UI Font 1", GClass125.font_3);
			GClass125.smethod_121("UI Font 2", GClass125.font_4);
			GClass125.smethod_124("CSV Separator", GClass125.string_19);
			GClass125.smethod_124("Export Folder", GClass125.string_32);
			GClass125.smethod_124("LOG Folder", GClass125.string_33);
			GClass125.smethod_122("Parameter Color 1", GClass125.color_0[0]);
			GClass125.smethod_122("Parameter Color 2", GClass125.color_0[1]);
			GClass125.smethod_122("Parameter Color 3", GClass125.color_0[2]);
			GClass125.smethod_122("Parameter Color 4", GClass125.color_0[3]);
			GClass125.smethod_122("Parameter Color 5", GClass125.color_0[4]);
			GClass125.smethod_122("Parameter Color 6", GClass125.color_0[5]);
			GClass125.smethod_122("Parameter Color 7", GClass125.color_0[6]);
			GClass125.smethod_122("Parameter Color 8", GClass125.color_0[7]);
			GClass125.smethod_122("Parameter Color 9", GClass125.color_0[8]);
			GClass125.smethod_122("Parameter Color 10", GClass125.color_0[9]);
			GClass125.smethod_122("Parameter Color 11", GClass125.color_0[10]);
			GClass125.smethod_122("Parameter Color 12", GClass125.color_0[11]);
			GClass125.smethod_122("Parameter Color 13", GClass125.color_0[12]);
			GClass125.smethod_122("Parameter Color 14", GClass125.color_0[13]);
			GClass125.smethod_122("Parameter Color 15", GClass125.color_0[14]);
			GClass125.smethod_122("Parameter Color 16", GClass125.color_0[15]);
			GClass125.smethod_122("Parameter Color 17", GClass125.color_0[16]);
			GClass125.smethod_122("Parameter Color 18", GClass125.color_0[17]);
			GClass125.smethod_122("Parameter Color 19", GClass125.color_0[18]);
			GClass125.smethod_122("Parameter Color 20", GClass125.color_0[19]);
			GClass125.smethod_122("Graph Back Color", GClass125.color_1);
			GClass125.smethod_122("Graph Grid Color", GClass125.color_2);
			GClass125.smethod_122("Graph X-Axis Color", GClass125.color_3);
			GClass125.smethod_123("Graph Line Thickness", GClass125.int_31);
			GClass125.smethod_121("Graph X-Axis Font", GClass125.font_1);
			GClass125.smethod_121("Graph Y-Axis Font", GClass125.font_0);
			GClass125.smethod_121("Graph Parameter Font", GClass125.font_2);
			GClass125.smethod_124("Lic Number", GClass125.string_23);
			GClass125.smethod_124("Lic Number M", GClass125.string_24);
			GClass125.smethod_124("Lic Number D", GClass125.string_25);
			GClass125.smethod_124("Removal Key", GClass125.string_28);
			GClass125.smethod_124("Removal KeyH", GClass125.string_29);
			GClass125.smethod_124("Purchase Token", GClass125.string_21);
			GClass125.smethod_124("CANtieCAR Serial", GClass125.string_31);
			byte[] bytes = Encoding.ASCII.GetBytes(GClass125.string_30);
			byte[] bytes2 = Encoding.ASCII.GetBytes(GClass125.string_23);
			byte b = 0;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(";");
			for (int i = 0; i < bytes.Length; i++)
			{
				b += bytes[i];
				if (bytes2.Length > i)
				{
					stringBuilder.Append("(" + ((int)(bytes[i] + bytes2[i])).ToString() + "),");
				}
				else
				{
					stringBuilder.Append("(" + bytes[i].ToString() + "),");
				}
			}
			for (int j = 0; j < bytes2.Length; j++)
			{
				b += bytes2[j];
			}
			stringBuilder.Append("(" + (450 + (int)b).ToString() + ")");
			if (bytes2.Length == 0 || bytes.Length == 0)
			{
				stringBuilder = new StringBuilder();
			}
			GClass125.smethod_124("Recent Vehicles", GClass125.string_35 + stringBuilder.ToString());
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x060007A1 RID: 1953 RVA: 0x000F0988 File Offset: 0x000EEB88
	// Note: this type is marked as 'beforefieldinit'.
	static GClass125()
	{
		int[] array = new int[4];
		array[0] = 16;
		GClass125.int_26 = array;
		GClass125.string_14 = new string[]
		{
			"COM1",
			"COM1",
			"COM1",
			"COM1"
		};
		GClass125.int_27 = new int[]
		{
			38400,
			38400,
			38400,
			38400
		};
		GClass125.int_28 = 0;
		GClass125.bool_8 = false;
		GClass125.int_29 = 0;
		GClass125.int_30 = 9;
		GClass125.color_0 = new Color[]
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
			Color.Navy,
			Color.Blue,
			Color.Red,
			Color.HotPink,
			Color.Gray
		};
		GClass125.color_1 = Color.White;
		GClass125.color_2 = Color.DarkGray;
		GClass125.color_3 = Color.Black;
		GClass125.int_31 = 1;
		GClass125.font_0 = new Font("Arial", 6f, FontStyle.Regular);
		GClass125.font_1 = new Font("Arial", 7f, FontStyle.Regular);
		GClass125.font_2 = new Font("Arial", 10f, FontStyle.Bold);
		GClass125.int_32 = 1;
		GClass125.string_16 = "English";
		GClass125.string_17 = "English";
		GClass125.string_18 = "Bulgarian";
		GClass125.font_3 = new Font("Arial", 16.2f, FontStyle.Bold);
		GClass125.font_4 = new Font("Arial", 13.8f, FontStyle.Bold);
		GClass125.string_19 = "Tab";
		GClass125.string_20 = "";
		GClass125.string_21 = "";
		GClass125.string_22 = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
		GClass125.string_23 = "730C7-06414-786E19";
		GClass125.string_24 = "";
		GClass125.string_25 = "";
		GClass125.string_26 = "";
		GClass125.string_27 = "";
		GClass125.string_28 = "";
		GClass125.string_29 = "-";
		GClass125.string_30 = "";
		GClass125.string_31 = "";
		GClass125.long_0 = 123000L;
		GClass125.string_32 = ".";
		GClass125.string_33 = ".";
		GClass125.string_34 = "Proba123";
		GClass125.string_35 = "";
		GClass125.int_33 = new int[][]
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
		GClass125.string_36 = new string[]
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
		GClass125.string_37 = " ";
		GClass125.string_38 = "";
	}

	// Token: 0x0400062A RID: 1578
	public const int int_0 = 0;

	// Token: 0x0400062B RID: 1579
	public const int int_1 = 1;

	// Token: 0x0400062C RID: 1580
	public const int int_2 = 2;

	// Token: 0x0400062D RID: 1581
	public const int int_3 = 3;

	// Token: 0x0400062E RID: 1582
	public const int int_4 = 4;

	// Token: 0x0400062F RID: 1583
	public const int int_5 = 5;

	// Token: 0x04000630 RID: 1584
	public const int int_6 = 6;

	// Token: 0x04000631 RID: 1585
	public const int int_7 = 7;

	// Token: 0x04000632 RID: 1586
	public const int int_8 = 8;

	// Token: 0x04000633 RID: 1587
	public const int int_9 = 9;

	// Token: 0x04000634 RID: 1588
	public const int int_10 = 10;

	// Token: 0x04000635 RID: 1589
	public const int int_11 = 11;

	// Token: 0x04000636 RID: 1590
	public const int int_12 = 12;

	// Token: 0x04000637 RID: 1591
	public const int int_13 = 13;

	// Token: 0x04000638 RID: 1592
	public const int int_14 = 14;

	// Token: 0x04000639 RID: 1593
	public const int int_15 = 15;

	// Token: 0x0400063A RID: 1594
	public const int int_16 = 16;

	// Token: 0x0400063B RID: 1595
	public const int int_17 = 1024;

	// Token: 0x0400063C RID: 1596
	public static string string_0 = "";

	// Token: 0x0400063D RID: 1597
	public static string[] string_1 = new string[]
	{
		"None",
		"K-Line / VAGCOM (USB/RS232)",
		"ELM 327 / OBD Direct-Protect / Generic OBD (USB)",
		"ELM 327 / Generic OBD (Bluetooth)",
		"OBDKey (USB)",
		"OBDKey (Bluetooth)",
		"CANtieCAR (USB/Bluetooth)",
		"OBDLink / Vgate vLinker (USB/Bluetooth)",
		"OBD-Direct/Protect",
		"ELM 327 / Generic OBD (WiFi)",
		"OBDKey (WiFi)",
		"ELM 327 (USB) in HIGH SPEED mode",
		"OBDLink / Vgate vLinker (WiFi)",
		"CANtieCAR (WiFi)",
		"Auto Detect ELM327/OBDLink/Vgate",
		"Vgate vLinker MS (Bluetooth)",
		"Auto-detect"
	};

	// Token: 0x0400063E RID: 1598
	public static int[] int_18 = new int[]
	{
		0,
		1,
		2,
		3,
		4,
		5,
		6,
		7,
		8,
		9
	};

	// Token: 0x0400063F RID: 1599
	public static bool bool_0 = true;

	// Token: 0x04000640 RID: 1600
	private static string string_2 = "Multiecuscan.ini";

	// Token: 0x04000641 RID: 1601
	private static string string_3 = "FES_Templates.ini";

	// Token: 0x04000642 RID: 1602
	private static string string_4 = "FES_Tags.ini";

	// Token: 0x04000643 RID: 1603
	public static string string_5 = "49535343-FE7D-4AE5-8FA9-9FAFD205E455";

	// Token: 0x04000644 RID: 1604
	public static string string_6 = "49535343-1E4D-4BD9-BA61-23C647249616";

	// Token: 0x04000645 RID: 1605
	public static string string_7 = "49535343-8841-43F4-A8D4-ECBE34729BB3";

	// Token: 0x04000646 RID: 1606
	public static string string_8 = "E7810A71-73AE-499D-8C15-FAA9AEF0C3F2";

	// Token: 0x04000647 RID: 1607
	public static string string_9 = "BEF8D6C9-9C21-4C9E-B632-BD58C1009F9F";

	// Token: 0x04000648 RID: 1608
	public static string string_10 = "BEF8D6C9-9C21-4C9E-B632-BD58C1009F9F";

	// Token: 0x04000649 RID: 1609
	private static int int_19 = 127;

	// Token: 0x0400064A RID: 1610
	private static int int_20 = 160;

	// Token: 0x0400064B RID: 1611
	private static int int_21 = 1401333;

	// Token: 0x0400064C RID: 1612
	private static int int_22 = 15;

	// Token: 0x0400064D RID: 1613
	private static int int_23 = 16;

	// Token: 0x0400064E RID: 1614
	private static string string_11 = ".ini";

	// Token: 0x0400064F RID: 1615
	private static string string_12 = ".exe";

	// Token: 0x04000650 RID: 1616
	private static int int_24 = 1;

	// Token: 0x04000651 RID: 1617
	private static string string_13 = "COM9";

	// Token: 0x04000652 RID: 1618
	private static int int_25 = 38400;

	// Token: 0x04000653 RID: 1619
	private static bool bool_1 = true;

	// Token: 0x04000654 RID: 1620
	private static bool bool_2 = true;

	// Token: 0x04000655 RID: 1621
	private static bool bool_3 = false;

	// Token: 0x04000656 RID: 1622
	private static bool bool_4 = false;

	// Token: 0x04000657 RID: 1623
	private static bool bool_5 = false;

	// Token: 0x04000658 RID: 1624
	private static bool bool_6 = false;

	// Token: 0x04000659 RID: 1625
	private static bool bool_7 = false;

	// Token: 0x0400065A RID: 1626
	private static int[] int_26;

	// Token: 0x0400065B RID: 1627
	private static string[] string_14;

	// Token: 0x0400065C RID: 1628
	private static int[] int_27;

	// Token: 0x0400065D RID: 1629
	private static int int_28;

	// Token: 0x0400065E RID: 1630
	private static bool bool_8;

	// Token: 0x0400065F RID: 1631
	private static int int_29;

	// Token: 0x04000660 RID: 1632
	private static int int_30;

	// Token: 0x04000661 RID: 1633
	private static Color[] color_0;

	// Token: 0x04000662 RID: 1634
	private static Color color_1;

	// Token: 0x04000663 RID: 1635
	private static Color color_2;

	// Token: 0x04000664 RID: 1636
	private static Color color_3;

	// Token: 0x04000665 RID: 1637
	private static int int_31;

	// Token: 0x04000666 RID: 1638
	private static Font font_0;

	// Token: 0x04000667 RID: 1639
	private static Font font_1;

	// Token: 0x04000668 RID: 1640
	private static Font font_2;

	// Token: 0x04000669 RID: 1641
	private static int int_32;

	// Token: 0x0400066A RID: 1642
	private static string string_15;

	// Token: 0x0400066B RID: 1643
	private static string string_16;

	// Token: 0x0400066C RID: 1644
	private static string string_17;

	// Token: 0x0400066D RID: 1645
	private static string string_18;

	// Token: 0x0400066E RID: 1646
	private static Font font_3;

	// Token: 0x0400066F RID: 1647
	private static Font font_4;

	// Token: 0x04000670 RID: 1648
	private static string string_19;

	// Token: 0x04000671 RID: 1649
	private static string string_20;

	// Token: 0x04000672 RID: 1650
	private static string string_21;

	// Token: 0x04000673 RID: 1651
	private static string string_22;

	// Token: 0x04000674 RID: 1652
	private static string string_23;

	// Token: 0x04000675 RID: 1653
	private static string string_24;

	// Token: 0x04000676 RID: 1654
	private static string string_25;

	// Token: 0x04000677 RID: 1655
	private static string string_26;

	// Token: 0x04000678 RID: 1656
	private static string string_27;

	// Token: 0x04000679 RID: 1657
	private static string string_28;

	// Token: 0x0400067A RID: 1658
	private static string string_29;

	// Token: 0x0400067B RID: 1659
	private static string string_30;

	// Token: 0x0400067C RID: 1660
	public static string string_31;

	// Token: 0x0400067D RID: 1661
	private static long long_0;

	// Token: 0x0400067E RID: 1662
	private static string string_32;

	// Token: 0x0400067F RID: 1663
	private static string string_33;

	// Token: 0x04000680 RID: 1664
	private static string string_34;

	// Token: 0x04000681 RID: 1665
	private static string string_35;

	// Token: 0x04000682 RID: 1666
	private static int[][] int_33;

	// Token: 0x04000683 RID: 1667
	private static string[] string_36;

	// Token: 0x04000684 RID: 1668
	private static string string_37;

	// Token: 0x04000685 RID: 1669
	private static string string_38;
}
