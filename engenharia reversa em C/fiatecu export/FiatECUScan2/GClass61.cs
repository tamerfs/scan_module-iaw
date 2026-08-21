using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Microsoft.Win32;

// Token: 0x0200007D RID: 125
public static class GClass61
{
	// Token: 0x06000430 RID: 1072 RVA: 0x00089FC0 File Offset: 0x000881C0
	// Note: this type is marked as 'beforefieldinit'.
	static GClass61()
	{
		int[] array = new int[4];
		array[0] = 1;
		GClass61.int_7 = array;
		GClass61.string_7 = new string[]
		{
			"COM1",
			"COM1",
			"COM1",
			"COM1"
		};
		GClass61.int_8 = new int[]
		{
			38400,
			38400,
			38400,
			38400
		};
		GClass61.int_9 = 0;
		GClass61.bool_3 = false;
		GClass61.int_10 = 0;
		GClass61.bool_4 = true;
		GClass61.color_0 = new Color[]
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
		GClass61.color_1 = Color.White;
		GClass61.color_2 = Color.DarkGray;
		GClass61.color_3 = Color.Black;
		GClass61.int_11 = 1;
		GClass61.font_0 = new Font("Arial", 6f, FontStyle.Regular);
		GClass61.font_1 = new Font("Arial", 7f, FontStyle.Regular);
		GClass61.font_2 = new Font("Arial", 10f, FontStyle.Bold);
		GClass61.int_12 = 1;
		GClass61.string_9 = "English";
		GClass61.string_10 = "English";
		GClass61.string_11 = "Bulgarian";
		GClass61.font_3 = new Font("Arial", 16.2f, FontStyle.Bold);
		GClass61.font_4 = new Font("Arial", 13.8f, FontStyle.Bold);
		GClass61.string_12 = "Tab";
		GClass61.string_13 = string.Empty;
		GClass61.string_14 = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
		GClass61.string_15 = "730C7-06414-786E19";
		GClass61.string_16 = string.Empty;
		GClass61.long_0 = 123000L;
		GClass61.string_17 = ".";
		GClass61.string_18 = ".";
		GClass61.string_19 = "Proba123";
		GClass61.string_20 = string.Empty;
		int[][] array2 = new int[10][];
		array2[0] = new int[]
		{
			1989,
			1802,
			1872,
			1804
		};
		array2[1] = new int[]
		{
			1989,
			1804,
			1809
		};
		array2[2] = new int[]
		{
			1989,
			1988
		};
		array2[3] = new int[]
		{
			1807,
			1806
		};
		int[][] array3 = array2;
		int num = 4;
		array = new int[1];
		array3[num] = array;
		int[][] array4 = array2;
		int num2 = 5;
		array = new int[1];
		array4[num2] = array;
		int[][] array5 = array2;
		int num3 = 6;
		array = new int[1];
		array5[num3] = array;
		int[][] array6 = array2;
		int num4 = 7;
		array = new int[1];
		array6[num4] = array;
		int[][] array7 = array2;
		int num5 = 8;
		array = new int[1];
		array7[num5] = array;
		int[][] array8 = array2;
		int num6 = 9;
		array = new int[1];
		array8[num6] = array;
		GClass61.int_13 = array2;
		GClass61.string_21 = new string[]
		{
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty
		};
		GClass61.string_22 = " ";
		GClass61.string_23 = string.Empty;
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x0008A4B8 File Offset: 0x000886B8
	public static void smethod_0()
	{
		if (!GClass61.smethod_1())
		{
			int[] array = GClass61.int_13[0];
			List<int> list = new List<int>();
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i]);
			}
			list.Add(1024);
			GClass61.int_13[0] = list.ToArray();
		}
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x0008A50C File Offset: 0x0008870C
	public static bool smethod_1()
	{
		int[] array = GClass61.int_13[0];
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

	// Token: 0x06000433 RID: 1075 RVA: 0x0008A548 File Offset: 0x00088748
	public static void smethod_2()
	{
		if (GClass61.smethod_1())
		{
			int[] array = GClass61.int_13[0];
			List<int> list = new List<int>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != 1024)
				{
					list.Add(array[i]);
				}
			}
			GClass61.int_13[0] = list.ToArray();
		}
	}

	// Token: 0x06000434 RID: 1076 RVA: 0x0008A5A0 File Offset: 0x000887A0
	public static string smethod_3()
	{
		return GClass61.string_14;
	}

	// Token: 0x06000435 RID: 1077 RVA: 0x000035C3 File Offset: 0x000017C3
	public static void smethod_4(string string_24)
	{
		GClass61.string_14 = string_24;
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x0008A5B4 File Offset: 0x000887B4
	public static string smethod_5()
	{
		return GClass61.string_15;
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x000035CB File Offset: 0x000017CB
	public static void smethod_6(string string_24)
	{
		GClass61.string_15 = string_24;
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x0008A5C8 File Offset: 0x000887C8
	public static string smethod_7()
	{
		return GClass61.string_16;
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x0008A5DC File Offset: 0x000887DC
	public static void smethod_8(string string_24)
	{
		if (string_24 == string.Empty)
		{
			GClass61.smethod_2();
			GClass61.string_16 = string.Empty;
		}
		else
		{
			GClass61.string_16 = string_24;
		}
		if (GClass61.string_16 == string.Empty)
		{
			GClass61.smethod_70(8, Color.Navy);
		}
		if (GClass61.string_16 == string.Empty)
		{
			GClass61.smethod_70(9, Color.Blue);
		}
	}

	// Token: 0x0600043A RID: 1082 RVA: 0x000035D3 File Offset: 0x000017D3
	public static bool smethod_9()
	{
		GClass61.smethod_70(9, Color.Blue);
		return GClass61.string_16 == string.Empty;
	}

	// Token: 0x0600043B RID: 1083 RVA: 0x0008A650 File Offset: 0x00088850
	public static string smethod_10()
	{
		return GClass61.string_12;
	}

	// Token: 0x0600043C RID: 1084 RVA: 0x000035F0 File Offset: 0x000017F0
	public static void smethod_11(string string_24)
	{
		GClass61.string_12 = string_24;
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x0008A664 File Offset: 0x00088864
	public static string smethod_12()
	{
		return GClass61.string_9;
	}

	// Token: 0x0600043E RID: 1086 RVA: 0x000035F8 File Offset: 0x000017F8
	public static void smethod_13(string string_24)
	{
		GClass61.string_9 = string_24;
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x0008A678 File Offset: 0x00088878
	public static string smethod_14()
	{
		return GClass61.string_10;
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x00003600 File Offset: 0x00001800
	public static void smethod_15(string string_24)
	{
		GClass61.string_10 = string_24;
	}

	// Token: 0x06000441 RID: 1089 RVA: 0x0008A68C File Offset: 0x0008888C
	public static string smethod_16()
	{
		return GClass61.string_11;
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x00003608 File Offset: 0x00001808
	public static void smethod_17(string string_24)
	{
		GClass61.string_11 = string_24;
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x0008A6A0 File Offset: 0x000888A0
	public static Font smethod_18()
	{
		return GClass61.font_3;
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x00003610 File Offset: 0x00001810
	public static void smethod_19(Font font_5)
	{
		GClass61.font_3 = font_5;
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x0008A6B4 File Offset: 0x000888B4
	public static Font smethod_20()
	{
		return GClass61.font_4;
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x00003618 File Offset: 0x00001818
	public static void smethod_21(Font font_5)
	{
		GClass61.font_4 = font_5;
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x0008A6C8 File Offset: 0x000888C8
	public static string smethod_22()
	{
		return GClass61.string_8;
	}

	// Token: 0x06000448 RID: 1096 RVA: 0x00003620 File Offset: 0x00001820
	public static void smethod_23(string string_24)
	{
		GClass61.string_8 = string_24;
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x0008A6DC File Offset: 0x000888DC
	public static string smethod_24()
	{
		return GClass61.string_17;
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x00003628 File Offset: 0x00001828
	public static void smethod_25(string string_24)
	{
		GClass61.string_17 = string_24;
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x0008A6F0 File Offset: 0x000888F0
	public static string smethod_26()
	{
		return GClass61.string_18;
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x00003630 File Offset: 0x00001830
	public static void smethod_27(string string_24)
	{
		GClass61.string_18 = string_24;
	}

	// Token: 0x0600044D RID: 1101 RVA: 0x0008A704 File Offset: 0x00088904
	public static string smethod_28()
	{
		return GClass61.string_1;
	}

	// Token: 0x0600044E RID: 1102 RVA: 0x00003638 File Offset: 0x00001838
	public static void smethod_29(string string_24)
	{
		GClass61.string_1 = string_24;
	}

	// Token: 0x0600044F RID: 1103 RVA: 0x0008A718 File Offset: 0x00088918
	public static int smethod_30(int int_14)
	{
		int result;
		if (int_14 > 3 || int_14 < 0)
		{
			result = 0;
		}
		else
		{
			result = GClass61.int_7[int_14];
		}
		return result;
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x00003640 File Offset: 0x00001840
	public static void smethod_31(int int_14, int int_15)
	{
		if (int_14 <= 3 && int_14 >= 0)
		{
			GClass61.int_7[int_14] = int_15;
		}
	}

	// Token: 0x06000451 RID: 1105 RVA: 0x0008A744 File Offset: 0x00088944
	public static string smethod_32(int int_14)
	{
		string result;
		if (int_14 > 3 || int_14 < 0)
		{
			result = "COM1";
		}
		else
		{
			result = GClass61.string_7[int_14];
		}
		return result;
	}

	// Token: 0x06000452 RID: 1106 RVA: 0x0000365A File Offset: 0x0000185A
	public static void smethod_33(int int_14, string string_24)
	{
		if (int_14 <= 3 && int_14 >= 0)
		{
			GClass61.string_7[int_14] = string_24;
		}
	}

	// Token: 0x06000453 RID: 1107 RVA: 0x0008A774 File Offset: 0x00088974
	public static int smethod_34(int int_14)
	{
		int result;
		if (int_14 > 3 || int_14 < 0)
		{
			result = 0;
		}
		else
		{
			result = GClass61.int_8[int_14];
		}
		return result;
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x00003674 File Offset: 0x00001874
	public static void smethod_35(int int_14, int int_15)
	{
		if (int_14 <= 3 && int_14 >= 0)
		{
			GClass61.int_8[int_14] = int_15;
		}
	}

	// Token: 0x06000455 RID: 1109 RVA: 0x0008A7A0 File Offset: 0x000889A0
	public static int smethod_36()
	{
		return GClass61.int_5;
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x0000368E File Offset: 0x0000188E
	public static void smethod_37(int int_14)
	{
		GClass61.int_5 = int_14;
	}

	// Token: 0x06000457 RID: 1111 RVA: 0x00003696 File Offset: 0x00001896
	public static bool smethod_38()
	{
		return GClass61.int_5 == 3 || GClass61.int_5 == 5;
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x0008A7B4 File Offset: 0x000889B4
	public static string smethod_39()
	{
		return GClass61.string_6;
	}

	// Token: 0x06000459 RID: 1113 RVA: 0x000036AB File Offset: 0x000018AB
	public static void smethod_40(string string_24)
	{
		GClass61.string_6 = string_24;
	}

	// Token: 0x0600045A RID: 1114 RVA: 0x0008A7C8 File Offset: 0x000889C8
	public static int smethod_41()
	{
		return GClass61.int_6;
	}

	// Token: 0x0600045B RID: 1115 RVA: 0x000036B3 File Offset: 0x000018B3
	public static void smethod_42(int int_14)
	{
		GClass61.int_6 = int_14;
	}

	// Token: 0x0600045C RID: 1116 RVA: 0x000036BB File Offset: 0x000018BB
	public static bool smethod_43()
	{
		return GClass61.bool_0;
	}

	// Token: 0x0600045D RID: 1117 RVA: 0x000036C2 File Offset: 0x000018C2
	public static void smethod_44(bool bool_5)
	{
		GClass61.bool_0 = bool_5;
	}

	// Token: 0x0600045E RID: 1118 RVA: 0x000036CA File Offset: 0x000018CA
	public static bool smethod_45()
	{
		return GClass61.bool_1;
	}

	// Token: 0x0600045F RID: 1119 RVA: 0x000036D1 File Offset: 0x000018D1
	public static void smethod_46(bool bool_5)
	{
		GClass61.bool_1 = bool_5;
	}

	// Token: 0x06000460 RID: 1120 RVA: 0x0008A7DC File Offset: 0x000889DC
	public static int smethod_47()
	{
		return GClass61.int_9;
	}

	// Token: 0x06000461 RID: 1121 RVA: 0x000036D9 File Offset: 0x000018D9
	public static void smethod_48(int int_14)
	{
		GClass61.int_9 = int_14;
	}

	// Token: 0x06000462 RID: 1122 RVA: 0x000036E1 File Offset: 0x000018E1
	public static bool smethod_49()
	{
		return GClass61.bool_3;
	}

	// Token: 0x06000463 RID: 1123 RVA: 0x000036E8 File Offset: 0x000018E8
	public static void smethod_50(bool bool_5)
	{
		GClass61.bool_3 = bool_5;
	}

	// Token: 0x06000464 RID: 1124 RVA: 0x0008A7F0 File Offset: 0x000889F0
	public static int smethod_51()
	{
		return GClass61.int_12;
	}

	// Token: 0x06000465 RID: 1125 RVA: 0x000036F0 File Offset: 0x000018F0
	public static void smethod_52(int int_14)
	{
		GClass61.int_12 = int_14;
	}

	// Token: 0x06000466 RID: 1126 RVA: 0x000036F8 File Offset: 0x000018F8
	public static bool smethod_53()
	{
		return GClass61.bool_4;
	}

	// Token: 0x06000467 RID: 1127 RVA: 0x000036FF File Offset: 0x000018FF
	public static void smethod_54(bool bool_5)
	{
		GClass61.bool_4 = bool_5;
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x00003707 File Offset: 0x00001907
	public static bool smethod_55()
	{
		return GClass61.bool_2;
	}

	// Token: 0x06000469 RID: 1129 RVA: 0x0000370E File Offset: 0x0000190E
	public static void smethod_56(bool bool_5)
	{
		GClass61.bool_2 = bool_5;
	}

	// Token: 0x0600046A RID: 1130 RVA: 0x0008A804 File Offset: 0x00088A04
	public static int smethod_57()
	{
		return GClass61.int_10;
	}

	// Token: 0x0600046B RID: 1131 RVA: 0x00003716 File Offset: 0x00001916
	public static void smethod_58(int int_14)
	{
		GClass61.int_10 = int_14;
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x0008A818 File Offset: 0x00088A18
	public static string smethod_59()
	{
		return GClass61.string_15 + "_" + GClass61.string_13;
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x0000371E File Offset: 0x0000191E
	public static void smethod_60(string string_24)
	{
		if (string_24.Length > 10)
		{
			GClass61.string_13 = string_24.Substring(0, 9);
		}
		else
		{
			GClass61.string_13 = string_24;
		}
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x0008A83C File Offset: 0x00088A3C
	public static long smethod_61()
	{
		return GClass61.long_0;
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x00003745 File Offset: 0x00001945
	public static void smethod_62(long long_1)
	{
		GClass61.long_0 = long_1;
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x0008A850 File Offset: 0x00088A50
	public static string smethod_63()
	{
		return GClass61.string_19;
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x0000374D File Offset: 0x0000194D
	public static void smethod_64(string string_24)
	{
		GClass61.string_19 = string_24;
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x0000321B File Offset: 0x0000141B
	public static bool smethod_65()
	{
		return !GClass61.smethod_16().ToLower().Contains("fiatecuscan2.exe");
	}

	// Token: 0x06000473 RID: 1139 RVA: 0x0008A864 File Offset: 0x00088A64
	public static string smethod_66()
	{
		return GClass61.string_20;
	}

	// Token: 0x06000474 RID: 1140 RVA: 0x00003755 File Offset: 0x00001955
	public static void smethod_67(string string_24)
	{
		GClass61.string_20 = string_24;
	}

	// Token: 0x06000475 RID: 1141 RVA: 0x0008A878 File Offset: 0x00088A78
	public static void smethod_68(int int_14)
	{
		if (GClass61.string_20.Length > 0)
		{
			GClass61.string_20 += ",";
			GClass61.string_20 = GClass61.string_20.Replace("(" + int_14 + "),", string.Empty);
		}
		object obj = GClass61.string_20;
		GClass61.string_20 = string.Concat(new object[]
		{
			obj,
			"(",
			int_14,
			")"
		});
		int i = 0;
		for (int j = 0; j < GClass61.string_20.Length; j++)
		{
			if (GClass61.string_20[j] == ',')
			{
				i++;
			}
		}
		while (i > 20)
		{
			GClass61.string_20 = GClass61.string_20.Substring(GClass61.string_20.IndexOf(",") + 1);
			i--;
		}
	}

	// Token: 0x06000476 RID: 1142 RVA: 0x0008A968 File Offset: 0x00088B68
	public static Color smethod_69(int int_14)
	{
		Color result;
		if (int_14 < GClass61.color_0.Length)
		{
			result = GClass61.color_0[int_14];
		}
		else
		{
			result = GClass61.color_0[GClass61.color_0.Length - 1];
		}
		return result;
	}

	// Token: 0x06000477 RID: 1143 RVA: 0x0000375D File Offset: 0x0000195D
	public static void smethod_70(int int_14, Color color_4)
	{
		if (int_14 < GClass61.color_0.Length)
		{
			GClass61.color_0[int_14] = color_4;
		}
	}

	// Token: 0x06000478 RID: 1144 RVA: 0x0008A9B4 File Offset: 0x00088BB4
	public static Color smethod_71()
	{
		return GClass61.color_1;
	}

	// Token: 0x06000479 RID: 1145 RVA: 0x0000377F File Offset: 0x0000197F
	public static void smethod_72(Color color_4)
	{
		GClass61.color_1 = color_4;
	}

	// Token: 0x0600047A RID: 1146 RVA: 0x0008A9C8 File Offset: 0x00088BC8
	public static Color smethod_73()
	{
		return GClass61.color_2;
	}

	// Token: 0x0600047B RID: 1147 RVA: 0x00003787 File Offset: 0x00001987
	public static void smethod_74(Color color_4)
	{
		GClass61.color_2 = color_4;
	}

	// Token: 0x0600047C RID: 1148 RVA: 0x0008A9DC File Offset: 0x00088BDC
	public static Color smethod_75()
	{
		return GClass61.color_3;
	}

	// Token: 0x0600047D RID: 1149 RVA: 0x0000378F File Offset: 0x0000198F
	public static void smethod_76(Color color_4)
	{
		GClass61.color_3 = color_4;
	}

	// Token: 0x0600047E RID: 1150 RVA: 0x0008A9F0 File Offset: 0x00088BF0
	public static int smethod_77()
	{
		return GClass61.int_11;
	}

	// Token: 0x0600047F RID: 1151 RVA: 0x00003797 File Offset: 0x00001997
	public static void smethod_78(int int_14)
	{
		GClass61.int_11 = int_14;
	}

	// Token: 0x06000480 RID: 1152 RVA: 0x0008AA04 File Offset: 0x00088C04
	public static Font smethod_79()
	{
		return GClass61.font_0;
	}

	// Token: 0x06000481 RID: 1153 RVA: 0x0000379F File Offset: 0x0000199F
	public static void smethod_80(Font font_5)
	{
		GClass61.font_0 = font_5;
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x0008AA18 File Offset: 0x00088C18
	public static Font smethod_81()
	{
		return GClass61.font_1;
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x000037A7 File Offset: 0x000019A7
	public static void smethod_82(Font font_5)
	{
		GClass61.font_1 = font_5;
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x0008AA2C File Offset: 0x00088C2C
	public static Font smethod_83()
	{
		return GClass61.font_2;
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x000037AF File Offset: 0x000019AF
	public static void smethod_84(Font font_5)
	{
		GClass61.font_2 = font_5;
	}

	// Token: 0x06000486 RID: 1158 RVA: 0x0008AA40 File Offset: 0x00088C40
	public static int[] smethod_85(int int_14)
	{
		return GClass61.int_13[int_14];
	}

	// Token: 0x06000487 RID: 1159 RVA: 0x000037B7 File Offset: 0x000019B7
	public static void smethod_86(int int_14, int[] int_15)
	{
		GClass61.int_13[int_14] = int_15;
	}

	// Token: 0x06000488 RID: 1160 RVA: 0x0008AA58 File Offset: 0x00088C58
	public static string smethod_87(int int_14)
	{
		return GClass61.string_21[int_14];
	}

	// Token: 0x06000489 RID: 1161 RVA: 0x000037C1 File Offset: 0x000019C1
	public static void smethod_88(int int_14, string string_24)
	{
		GClass61.string_21[int_14] = string_24;
	}

	// Token: 0x0600048A RID: 1162 RVA: 0x0008AA70 File Offset: 0x00088C70
	private static void smethod_89(string string_24, Font font_5)
	{
		GClass61.smethod_93(string_24, string.Concat(new object[]
		{
			font_5.Name,
			";",
			font_5.Style,
			";",
			font_5.SizeInPoints,
			"pt"
		}), RegistryValueKind.String);
	}

	// Token: 0x0600048B RID: 1163 RVA: 0x000037CB File Offset: 0x000019CB
	private static void smethod_90(string string_24, Color color_4)
	{
		GClass61.smethod_93(string_24, color_4.ToArgb(), RegistryValueKind.DWord);
	}

	// Token: 0x0600048C RID: 1164 RVA: 0x000037E0 File Offset: 0x000019E0
	private static void smethod_91(string string_24, int int_14)
	{
		GClass61.smethod_93(string_24, int_14, RegistryValueKind.DWord);
	}

	// Token: 0x0600048D RID: 1165 RVA: 0x000037EF File Offset: 0x000019EF
	private static void smethod_92(string string_24, string string_25)
	{
		GClass61.smethod_93(string_24, string_25, RegistryValueKind.String);
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x0006C974 File Offset: 0x0006AB74
	private static void smethod_93(string string_24, object object_0, RegistryValueKind registryValueKind_0)
	{
		using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software", true))
		{
			using (RegistryKey registryKey2 = registryKey.OpenSubKey("FiatECUScan", true))
			{
				if (registryKey2 == null)
				{
					using (RegistryKey registryKey3 = registryKey.CreateSubKey("FiatECUScan"))
					{
						registryKey3.SetValue(string_24, object_0, registryValueKind_0);
						goto IL_54;
					}
				}
				registryKey2.SetValue(string_24, object_0, registryValueKind_0);
				IL_54:;
			}
		}
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x0008AAD0 File Offset: 0x00088CD0
	private static int smethod_94(string string_24, int int_14)
	{
		object obj = GClass61.smethod_98(string_24);
		int result;
		if (obj == null)
		{
			result = int_14;
		}
		else
		{
			result = (int)obj;
		}
		return result;
	}

	// Token: 0x06000490 RID: 1168 RVA: 0x0008AAFC File Offset: 0x00088CFC
	private static string smethod_95(string string_24, string string_25)
	{
		object obj = GClass61.smethod_98(string_24);
		string result;
		if (obj == null)
		{
			result = string_25;
		}
		else
		{
			result = (string)obj;
		}
		return result;
	}

	// Token: 0x06000491 RID: 1169 RVA: 0x0008AB28 File Offset: 0x00088D28
	private static Color smethod_96(string string_24, Color color_4)
	{
		object obj = GClass61.smethod_98(string_24);
		Color result;
		if (obj == null)
		{
			result = color_4;
		}
		else
		{
			result = Color.FromArgb((int)obj);
		}
		return result;
	}

	// Token: 0x06000492 RID: 1170 RVA: 0x0008AB58 File Offset: 0x00088D58
	private static Font smethod_97(string string_24, Font font_5)
	{
		object obj = GClass61.smethod_98(string_24);
		Font result;
		if (obj == null)
		{
			result = font_5;
		}
		else
		{
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
					emSize = (float)Convert.ToDouble(text.Substring(text.LastIndexOf(";") + 1).Replace("pt", string.Empty));
				}
			}
			catch (Exception)
			{
			}
			result = new Font(familyName, emSize, style);
		}
		return result;
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x0006CBC0 File Offset: 0x0006ADC0
	private static object smethod_98(string string_24)
	{
		object result;
		using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software"))
		{
			using (RegistryKey registryKey2 = registryKey.OpenSubKey("FiatECUScan"))
			{
				if (registryKey2 == null)
				{
					result = null;
				}
				else
				{
					result = registryKey2.GetValue(string_24);
				}
			}
		}
		return result;
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x0008AC74 File Offset: 0x00088E74
	public static void smethod_99()
	{
		try
		{
			GClass61.int_7[0] = GClass61.smethod_94("Interface 1 Type", GClass61.int_7[0]);
			GClass61.int_7[0] = GClass61.smethod_94("Interface 1 Type Ex", GClass61.int_7[0]);
			GClass61.string_7[0] = GClass61.smethod_95("Interface 1 Port", GClass61.string_7[0]);
			GClass61.int_8[0] = GClass61.smethod_94("Interface 1 Port Speed", GClass61.int_8[0]);
			GClass61.int_7[1] = GClass61.smethod_94("Interface 2 Type", GClass61.int_7[1]);
			GClass61.int_7[1] = GClass61.smethod_94("Interface 2 Type Ex", GClass61.int_7[1]);
			GClass61.string_7[1] = GClass61.smethod_95("Interface 2 Port", GClass61.string_7[1]);
			GClass61.int_8[1] = GClass61.smethod_94("Interface 2 Port Speed", GClass61.int_8[1]);
			GClass61.int_7[2] = GClass61.smethod_94("Interface 3 Type", GClass61.int_7[2]);
			GClass61.int_7[2] = GClass61.smethod_94("Interface 3 Type Ex", GClass61.int_7[2]);
			GClass61.string_7[2] = GClass61.smethod_95("Interface 3 Port", GClass61.string_7[2]);
			GClass61.int_8[2] = GClass61.smethod_94("Interface 3 Port Speed", GClass61.int_8[2]);
			GClass61.int_7[3] = GClass61.smethod_94("Interface 4 Type", GClass61.int_7[3]);
			GClass61.int_7[3] = GClass61.smethod_94("Interface 4 Type Ex", GClass61.int_7[3]);
			GClass61.string_7[3] = GClass61.smethod_95("Interface 4 Port", GClass61.string_7[3]);
			GClass61.int_8[3] = GClass61.smethod_94("Interface 4 Port Speed", GClass61.int_8[3]);
			GClass61.color_0[0] = GClass61.smethod_96("Parameter Color 1", GClass61.color_0[0]);
			GClass61.color_0[1] = GClass61.smethod_96("Parameter Color 2", GClass61.color_0[1]);
			GClass61.color_0[2] = GClass61.smethod_96("Parameter Color 3", GClass61.color_0[2]);
			GClass61.color_0[3] = GClass61.smethod_96("Parameter Color 4", GClass61.color_0[3]);
			GClass61.color_0[4] = GClass61.smethod_96("Parameter Color 5", GClass61.color_0[4]);
			GClass61.color_0[5] = GClass61.smethod_96("Parameter Color 6", GClass61.color_0[5]);
			GClass61.color_0[6] = GClass61.smethod_96("Parameter Color 7", GClass61.color_0[6]);
			GClass61.color_0[7] = GClass61.smethod_96("Parameter Color 8", GClass61.color_0[7]);
			GClass61.color_1 = GClass61.smethod_96("Graph Back Color", GClass61.color_1);
			GClass61.color_2 = GClass61.smethod_96("Graph Grid Color", GClass61.color_2);
			GClass61.color_3 = GClass61.smethod_96("Graph X-Axis Color", GClass61.color_3);
			GClass61.int_11 = GClass61.smethod_94("Graph Line Thickness", GClass61.int_11);
			GClass61.font_1 = GClass61.smethod_97("Graph X-Axis Font", GClass61.font_1);
			GClass61.font_0 = GClass61.smethod_97("Graph Y-Axis Font", GClass61.font_0);
			GClass61.font_2 = GClass61.smethod_97("Graph Parameter Font", GClass61.font_2);
			GClass61.bool_0 = (GClass61.smethod_94("Show Available Ports Only", GClass61.bool_0 ? 1 : 0) == 1);
			GClass61.int_9 = GClass61.smethod_94("KWP2000 Timings", GClass61.int_9);
			GClass61.bool_1 = (GClass61.smethod_94("Show Adapter Message", GClass61.bool_1 ? 1 : 0) == 1);
			GClass61.bool_3 = (GClass61.smethod_94("High Latency mode", GClass61.bool_3 ? 1 : 0) == 1);
			GClass61.bool_2 = (GClass61.smethod_94("Convert KMs to Miles", GClass61.bool_2 ? 1 : 0) == 1);
			GClass61.int_12 = GClass61.smethod_94("Screen Repaint Interval", GClass61.int_12);
			GClass61.bool_4 = (GClass61.smethod_94("Show Disclaimer", GClass61.bool_4 ? 1 : 0) == 1);
			GClass61.int_10 = GClass61.smethod_94("Last Selection", GClass61.int_10);
			GClass61.string_9 = GClass61.smethod_95("UI Language", GClass61.string_9);
			GClass61.string_10 = GClass61.smethod_95("Data Language", GClass61.string_10);
			GClass61.font_3 = GClass61.smethod_97("UI Font 1", GClass61.font_3);
			GClass61.font_4 = GClass61.smethod_97("UI Font 2", GClass61.font_4);
			GClass61.string_12 = GClass61.smethod_95("CSV Separator", GClass61.string_12);
			GClass61.string_17 = GClass61.smethod_95("Export Folder", GClass61.string_17);
			GClass61.string_18 = GClass61.smethod_95("LOG Folder", GClass61.string_18);
			GClass61.color_0[8] = GClass61.smethod_96("Parameter Color 9", GClass61.color_0[8]);
			GClass61.color_0[9] = GClass61.smethod_96("Parameter Color 10", GClass61.color_0[9]);
			GClass61.string_15 = GClass61.smethod_95("Lic Number", GClass61.string_15);
			GClass61.string_16 = GClass61.smethod_95("Removal Key", GClass61.string_16);
			GClass61.string_20 = GClass61.smethod_95("Recent Vehicles", string.Empty);
			return;
		}
		catch (Exception value)
		{
		}
		try
		{
			FileStream fileStream = new FileStream(GClass61.string_8 + "\\" + GClass61.string_1.Replace(GClass61.string_4, GClass61.string_5), FileMode.Open, FileAccess.Read);
			GClass61.string_19 = GClass61.string_19 + GClass61.smethod_103(fileStream, (long)GClass61.int_0) + GClass61.smethod_103(fileStream, (long)GClass61.int_1) + GClass61.smethod_103(fileStream, (long)GClass61.int_2);
			GClass61.long_0 = fileStream.Length;
			fileStream.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x0008B280 File Offset: 0x00089480
	private static string smethod_100(int int_14)
	{
		string text = string.Empty;
		for (int i = 0; i < GClass61.int_13[int_14].Length; i++)
		{
			text = text + ((i > 0) ? "," : string.Empty) + GClass61.int_13[int_14][i];
		}
		return text;
	}

	// Token: 0x06000496 RID: 1174 RVA: 0x0008B2D4 File Offset: 0x000894D4
	public static void smethod_101()
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(GClass61.string_8 + "\\" + GClass61.string_2);
			for (int i = 0; i < 10; i++)
			{
				streamWriter.WriteLine(i + "=" + GClass61.smethod_100(i));
			}
			streamWriter.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x06000497 RID: 1175 RVA: 0x0008B348 File Offset: 0x00089548
	public static void smethod_102()
	{
		GClass61.string_19 = string.Empty;
		char[] separator = new char[]
		{
			','
		};
		try
		{
			Stream stream = File.OpenRead(GClass61.string_8 + "\\" + GClass61.string_2);
			StreamReader streamReader = new StreamReader(stream);
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				if (text[1] == '=' && text.Length > 2)
				{
					int num = Convert.ToInt32(text.Substring(0, 1));
					text = text.Substring(2);
					string[] array = text.Split(separator);
					GClass61.int_13[num] = new int[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						GClass61.int_13[num][i] = Convert.ToInt32(array[i]);
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
			FileStream fileStream = new FileStream(GClass61.string_8 + "\\" + GClass61.string_1.Replace(GClass61.string_4, GClass61.string_5), FileMode.Open, FileAccess.Read);
			GClass61.string_19 = GClass61.string_19 + GClass61.smethod_103(fileStream, (long)GClass61.int_0) + GClass61.smethod_103(fileStream, (long)GClass61.int_1) + GClass61.smethod_103(fileStream, (long)GClass61.int_2);
			GClass61.long_0 = fileStream.Length;
			fileStream.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x0008B4D4 File Offset: 0x000896D4
	private static string smethod_103(FileStream fileStream_0, long long_1)
	{
		byte[] array = new byte[GClass61.int_4];
		fileStream_0.Seek(long_1, SeekOrigin.Begin);
		fileStream_0.Read(array, 0, array.Length);
		return GClass16.smethod_1(array).Replace(GClass61.string_22, GClass61.string_23);
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x0008B518 File Offset: 0x00089718
	public static void smethod_104()
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(GClass61.string_8 + "\\" + GClass61.string_3, false, Encoding.Unicode);
			for (int i = 0; i < 10; i++)
			{
				streamWriter.WriteLine(i + "=" + GClass61.string_21[i]);
			}
			streamWriter.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x0600049A RID: 1178 RVA: 0x0008B594 File Offset: 0x00089794
	public static void smethod_105()
	{
		char[] array = new char[]
		{
			','
		};
		try
		{
			Stream stream = File.OpenRead(GClass61.string_8 + "\\" + GClass61.string_3);
			StreamReader streamReader = new StreamReader(stream);
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				if (text[1] == '=' && text.Length > 2)
				{
					int num = Convert.ToInt32(text.Substring(0, 1));
					GClass61.string_21[num] = text.Substring(2);
				}
			}
			streamReader.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x0600049B RID: 1179 RVA: 0x0008B640 File Offset: 0x00089840
	public static void smethod_106()
	{
		try
		{
			GClass61.smethod_91("Interface 1 Type Ex", GClass61.int_7[0]);
			GClass61.smethod_92("Interface 1 Port", GClass61.string_7[0]);
			GClass61.smethod_91("Interface 1 Port Speed", GClass61.int_8[0]);
			GClass61.smethod_91("Interface 2 Type Ex", GClass61.int_7[1]);
			GClass61.smethod_92("Interface 2 Port", GClass61.string_7[1]);
			GClass61.smethod_91("Interface 2 Port Speed", GClass61.int_8[1]);
			GClass61.smethod_91("Interface 3 Type Ex", GClass61.int_7[2]);
			GClass61.smethod_92("Interface 3 Port", GClass61.string_7[2]);
			GClass61.smethod_91("Interface 3 Port Speed", GClass61.int_8[2]);
			GClass61.smethod_91("Interface 4 Type Ex", GClass61.int_7[3]);
			GClass61.smethod_92("Interface 4 Port", GClass61.string_7[3]);
			GClass61.smethod_91("Interface 4 Port Speed", GClass61.int_8[3]);
			GClass61.smethod_91("Show Available Ports Only", GClass61.bool_0 ? 1 : 0);
			GClass61.smethod_91("KWP2000 Timings", GClass61.int_9);
			GClass61.smethod_91("Show Adapter Message", GClass61.bool_1 ? 1 : 0);
			GClass61.smethod_91("High Latency mode", GClass61.bool_3 ? 1 : 0);
			GClass61.smethod_91("Convert KMs to Miles", GClass61.bool_2 ? 1 : 0);
			GClass61.smethod_91("Screen Repaint Interval", GClass61.int_12);
			GClass61.smethod_91("Show Disclaimer", GClass61.bool_4 ? 1 : 0);
			GClass61.smethod_91("Last Selection", GClass61.int_10);
			GClass61.smethod_92("UI Language", GClass61.string_9);
			GClass61.smethod_92("Data Language", GClass61.string_10);
			GClass61.smethod_89("UI Font 1", GClass61.font_3);
			GClass61.smethod_89("UI Font 2", GClass61.font_4);
			GClass61.smethod_92("CSV Separator", GClass61.string_12);
			GClass61.smethod_92("Export Folder", GClass61.string_17);
			GClass61.smethod_92("LOG Folder", GClass61.string_18);
			GClass61.smethod_90("Parameter Color 1", GClass61.color_0[0]);
			GClass61.smethod_90("Parameter Color 2", GClass61.color_0[1]);
			GClass61.smethod_90("Parameter Color 3", GClass61.color_0[2]);
			GClass61.smethod_90("Parameter Color 4", GClass61.color_0[3]);
			GClass61.smethod_90("Parameter Color 5", GClass61.color_0[4]);
			GClass61.smethod_90("Parameter Color 6", GClass61.color_0[5]);
			GClass61.smethod_90("Parameter Color 7", GClass61.color_0[6]);
			GClass61.smethod_90("Parameter Color 8", GClass61.color_0[7]);
			GClass61.smethod_90("Parameter Color 9", GClass61.color_0[8]);
			GClass61.smethod_90("Parameter Color 10", GClass61.color_0[9]);
			GClass61.smethod_90("Graph Back Color", GClass61.color_1);
			GClass61.smethod_90("Graph Grid Color", GClass61.color_2);
			GClass61.smethod_90("Graph X-Axis Color", GClass61.color_3);
			GClass61.smethod_91("Graph Line Thickness", GClass61.int_11);
			GClass61.smethod_89("Graph X-Axis Font", GClass61.font_1);
			GClass61.smethod_89("Graph Y-Axis Font", GClass61.font_0);
			GClass61.smethod_89("Graph Parameter Font", GClass61.font_2);
			GClass61.smethod_92("Lic Number", GClass61.string_15);
			GClass61.smethod_92("Removal Key", GClass61.string_16);
			GClass61.smethod_92("Recent Vehicles", GClass61.string_20);
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x040005F9 RID: 1529
	public static string[] string_0 = new string[]
	{
		"None",
		"K-Line / VAGCOM",
		"ELM 327 1.3+",
		"ELM 327 v1.3+ (Bluetooth)",
		"OBDKey 1.40",
		"OBDKey 1.40 (Bluetooth)",
		"CANtieCAR (USB/Bluetooth)",
		"OBDLink (USB/Bluetooth)"
	};

	// Token: 0x040005FA RID: 1530
	private static string string_1 = "FiatECUScan.ini";

	// Token: 0x040005FB RID: 1531
	private static string string_2 = "FES_Templates.ini";

	// Token: 0x040005FC RID: 1532
	private static string string_3 = "FES_Tags.ini";

	// Token: 0x040005FD RID: 1533
	private static int int_0 = 127;

	// Token: 0x040005FE RID: 1534
	private static int int_1 = 160;

	// Token: 0x040005FF RID: 1535
	private static int int_2 = 1401333;

	// Token: 0x04000600 RID: 1536
	private static int int_3 = 15;

	// Token: 0x04000601 RID: 1537
	private static int int_4 = 16;

	// Token: 0x04000602 RID: 1538
	private static string string_4 = ".ini";

	// Token: 0x04000603 RID: 1539
	private static string string_5 = "2.exe";

	// Token: 0x04000604 RID: 1540
	private static int int_5 = 1;

	// Token: 0x04000605 RID: 1541
	private static string string_6 = "COM9";

	// Token: 0x04000606 RID: 1542
	private static int int_6 = 38400;

	// Token: 0x04000607 RID: 1543
	private static bool bool_0 = true;

	// Token: 0x04000608 RID: 1544
	private static bool bool_1 = true;

	// Token: 0x04000609 RID: 1545
	private static bool bool_2 = false;

	// Token: 0x0400060A RID: 1546
	private static int[] int_7;

	// Token: 0x0400060B RID: 1547
	private static string[] string_7;

	// Token: 0x0400060C RID: 1548
	private static int[] int_8;

	// Token: 0x0400060D RID: 1549
	private static int int_9;

	// Token: 0x0400060E RID: 1550
	private static bool bool_3;

	// Token: 0x0400060F RID: 1551
	private static int int_10;

	// Token: 0x04000610 RID: 1552
	private static bool bool_4;

	// Token: 0x04000611 RID: 1553
	private static Color[] color_0;

	// Token: 0x04000612 RID: 1554
	private static Color color_1;

	// Token: 0x04000613 RID: 1555
	private static Color color_2;

	// Token: 0x04000614 RID: 1556
	private static Color color_3;

	// Token: 0x04000615 RID: 1557
	private static int int_11;

	// Token: 0x04000616 RID: 1558
	private static Font font_0;

	// Token: 0x04000617 RID: 1559
	private static Font font_1;

	// Token: 0x04000618 RID: 1560
	private static Font font_2;

	// Token: 0x04000619 RID: 1561
	private static int int_12;

	// Token: 0x0400061A RID: 1562
	private static string string_8;

	// Token: 0x0400061B RID: 1563
	private static string string_9;

	// Token: 0x0400061C RID: 1564
	private static string string_10;

	// Token: 0x0400061D RID: 1565
	private static string string_11;

	// Token: 0x0400061E RID: 1566
	private static Font font_3;

	// Token: 0x0400061F RID: 1567
	private static Font font_4;

	// Token: 0x04000620 RID: 1568
	private static string string_12;

	// Token: 0x04000621 RID: 1569
	private static string string_13;

	// Token: 0x04000622 RID: 1570
	private static string string_14;

	// Token: 0x04000623 RID: 1571
	private static string string_15;

	// Token: 0x04000624 RID: 1572
	private static string string_16;

	// Token: 0x04000625 RID: 1573
	private static long long_0;

	// Token: 0x04000626 RID: 1574
	private static string string_17;

	// Token: 0x04000627 RID: 1575
	private static string string_18;

	// Token: 0x04000628 RID: 1576
	private static string string_19;

	// Token: 0x04000629 RID: 1577
	private static string string_20;

	// Token: 0x0400062A RID: 1578
	private static int[][] int_13;

	// Token: 0x0400062B RID: 1579
	private static string[] string_21;

	// Token: 0x0400062C RID: 1580
	private static string string_22;

	// Token: 0x0400062D RID: 1581
	private static string string_23;
}
