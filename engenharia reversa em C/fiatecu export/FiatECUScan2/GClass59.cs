using System;
using System.Drawing;
using System.IO;
using System.Text;
using Microsoft.Win32;

// Token: 0x02000062 RID: 98
public static class GClass59
{
	// Token: 0x060002C5 RID: 709 RVA: 0x0006BFE8 File Offset: 0x0006A1E8
	// Note: this type is marked as 'beforefieldinit'.
	static GClass59()
	{
		int[] array = new int[4];
		array[0] = 1;
		GClass59.int_7 = array;
		GClass59.string_6 = new string[]
		{
			"COM1",
			"COM1",
			"COM1",
			"COM1"
		};
		GClass59.int_8 = new int[]
		{
			38400,
			38400,
			38400,
			38400
		};
		GClass59.int_9 = 0;
		GClass59.bool_3 = false;
		GClass59.int_10 = 0;
		GClass59.bool_4 = true;
		GClass59.color_0 = new Color[]
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
		GClass59.color_1 = Color.White;
		GClass59.color_2 = Color.DarkGray;
		GClass59.color_3 = Color.Black;
		GClass59.int_11 = 1;
		GClass59.font_0 = new Font("Arial", 6f, FontStyle.Regular);
		GClass59.font_1 = new Font("Arial", 7f, FontStyle.Regular);
		GClass59.font_2 = new Font("Arial", 10f, FontStyle.Bold);
		GClass59.int_12 = 1;
		GClass59.string_8 = "English";
		GClass59.string_9 = "English";
		GClass59.string_10 = "Bulgarian";
		GClass59.font_3 = new Font("Arial", 16.2f, FontStyle.Bold);
		GClass59.font_4 = new Font("Arial", 13.8f, FontStyle.Bold);
		GClass59.string_11 = "Tab";
		GClass59.string_12 = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
		GClass59.string_13 = "730C7-06414-786E19";
		GClass59.string_14 = string.Empty;
		GClass59.long_0 = 123000L;
		GClass59.string_15 = ".";
		GClass59.string_16 = ".";
		GClass59.string_17 = "Proba123";
		GClass59.string_18 = string.Empty;
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
		GClass59.int_13 = array2;
		GClass59.string_19 = new string[]
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
		GClass59.string_20 = " ";
		GClass59.string_21 = string.Empty;
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x0006C488 File Offset: 0x0006A688
	public static string smethod_0()
	{
		return GClass59.string_12;
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x000030C5 File Offset: 0x000012C5
	public static void smethod_1(string string_22)
	{
		GClass59.string_12 = string_22;
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x0006C49C File Offset: 0x0006A69C
	public static string smethod_2()
	{
		return GClass59.string_13;
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x000030CD File Offset: 0x000012CD
	public static void smethod_3(string string_22)
	{
		GClass59.string_13 = string_22;
	}

	// Token: 0x060002CA RID: 714 RVA: 0x0006C4B0 File Offset: 0x0006A6B0
	public static string smethod_4()
	{
		return GClass59.string_14;
	}

	// Token: 0x060002CB RID: 715 RVA: 0x0006C4C4 File Offset: 0x0006A6C4
	public static void smethod_5(string string_22)
	{
		GClass59.string_14 = string_22;
		if (GClass59.string_14 == string.Empty)
		{
			GClass59.smethod_64(8, Color.Navy);
		}
		if (GClass59.string_14 == string.Empty)
		{
			GClass59.smethod_64(9, Color.Blue);
		}
	}

	// Token: 0x060002CC RID: 716 RVA: 0x000030D5 File Offset: 0x000012D5
	public static bool smethod_6()
	{
		GClass59.smethod_64(9, Color.Blue);
		return GClass59.string_14 == string.Empty;
	}

	// Token: 0x060002CD RID: 717 RVA: 0x0006C518 File Offset: 0x0006A718
	public static string smethod_7()
	{
		return GClass59.string_11;
	}

	// Token: 0x060002CE RID: 718 RVA: 0x000030F2 File Offset: 0x000012F2
	public static void smethod_8(string string_22)
	{
		GClass59.string_11 = string_22;
	}

	// Token: 0x060002CF RID: 719 RVA: 0x0006C52C File Offset: 0x0006A72C
	public static string smethod_9()
	{
		return GClass59.string_8;
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x000030FA File Offset: 0x000012FA
	public static void smethod_10(string string_22)
	{
		GClass59.string_8 = string_22;
	}

	// Token: 0x060002D1 RID: 721 RVA: 0x0006C540 File Offset: 0x0006A740
	public static string smethod_11()
	{
		return GClass59.string_9;
	}

	// Token: 0x060002D2 RID: 722 RVA: 0x00003102 File Offset: 0x00001302
	public static void smethod_12(string string_22)
	{
		GClass59.string_9 = string_22;
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x0006C554 File Offset: 0x0006A754
	public static string smethod_13()
	{
		return GClass59.string_10;
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x0000310A File Offset: 0x0000130A
	public static void smethod_14(string string_22)
	{
		GClass59.string_10 = string_22;
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x0006C568 File Offset: 0x0006A768
	public static Font smethod_15()
	{
		return GClass59.font_3;
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x00003112 File Offset: 0x00001312
	public static void smethod_16(Font font_5)
	{
		GClass59.font_3 = font_5;
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x0006C57C File Offset: 0x0006A77C
	public static Font smethod_17()
	{
		return GClass59.font_4;
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x0000311A File Offset: 0x0000131A
	public static void smethod_18(Font font_5)
	{
		GClass59.font_4 = font_5;
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x0006C590 File Offset: 0x0006A790
	public static string smethod_19()
	{
		return GClass59.string_7;
	}

	// Token: 0x060002DA RID: 730 RVA: 0x00003122 File Offset: 0x00001322
	public static void smethod_20(string string_22)
	{
		GClass59.string_7 = string_22;
	}

	// Token: 0x060002DB RID: 731 RVA: 0x0006C5A4 File Offset: 0x0006A7A4
	public static string smethod_21()
	{
		return GClass59.string_15;
	}

	// Token: 0x060002DC RID: 732 RVA: 0x0000312A File Offset: 0x0000132A
	public static void smethod_22(string string_22)
	{
		GClass59.string_15 = string_22;
	}

	// Token: 0x060002DD RID: 733 RVA: 0x0006C5B8 File Offset: 0x0006A7B8
	public static string smethod_23()
	{
		return GClass59.string_16;
	}

	// Token: 0x060002DE RID: 734 RVA: 0x00003132 File Offset: 0x00001332
	public static void smethod_24(string string_22)
	{
		GClass59.string_16 = string_22;
	}

	// Token: 0x060002DF RID: 735 RVA: 0x0006C5CC File Offset: 0x0006A7CC
	public static string smethod_25()
	{
		return GClass59.string_0;
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x0000313A File Offset: 0x0000133A
	public static void smethod_26(string string_22)
	{
		GClass59.string_0 = string_22;
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x0006C5E0 File Offset: 0x0006A7E0
	public static int smethod_27(int int_14)
	{
		int result;
		if (int_14 > 3 || int_14 < 0)
		{
			result = 0;
		}
		else
		{
			result = GClass59.int_7[int_14];
		}
		return result;
	}

	// Token: 0x060002E2 RID: 738 RVA: 0x00003142 File Offset: 0x00001342
	public static void smethod_28(int int_14, int int_15)
	{
		if (int_14 <= 3 && int_14 >= 0)
		{
			GClass59.int_7[int_14] = int_15;
		}
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x0006C60C File Offset: 0x0006A80C
	public static string smethod_29(int int_14)
	{
		string result;
		if (int_14 > 3 || int_14 < 0)
		{
			result = "COM1";
		}
		else
		{
			result = GClass59.string_6[int_14];
		}
		return result;
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x0000315C File Offset: 0x0000135C
	public static void smethod_30(int int_14, string string_22)
	{
		if (int_14 <= 3 && int_14 >= 0)
		{
			GClass59.string_6[int_14] = string_22;
		}
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x0006C63C File Offset: 0x0006A83C
	public static int smethod_31(int int_14)
	{
		int result;
		if (int_14 > 3 || int_14 < 0)
		{
			result = 0;
		}
		else
		{
			result = GClass59.int_8[int_14];
		}
		return result;
	}

	// Token: 0x060002E6 RID: 742 RVA: 0x00003176 File Offset: 0x00001376
	public static void smethod_32(int int_14, int int_15)
	{
		if (int_14 <= 3 && int_14 >= 0)
		{
			GClass59.int_8[int_14] = int_15;
		}
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x0006C668 File Offset: 0x0006A868
	public static int smethod_33()
	{
		return GClass59.int_5;
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x00003190 File Offset: 0x00001390
	public static void smethod_34(int int_14)
	{
		GClass59.int_5 = int_14;
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x0006C67C File Offset: 0x0006A87C
	public static string smethod_35()
	{
		return GClass59.string_5;
	}

	// Token: 0x060002EA RID: 746 RVA: 0x00003198 File Offset: 0x00001398
	public static void smethod_36(string string_22)
	{
		GClass59.string_5 = string_22;
	}

	// Token: 0x060002EB RID: 747 RVA: 0x0006C690 File Offset: 0x0006A890
	public static int smethod_37()
	{
		return GClass59.int_6;
	}

	// Token: 0x060002EC RID: 748 RVA: 0x000031A0 File Offset: 0x000013A0
	public static void smethod_38(int int_14)
	{
		GClass59.int_6 = int_14;
	}

	// Token: 0x060002ED RID: 749 RVA: 0x000031A8 File Offset: 0x000013A8
	public static bool smethod_39()
	{
		return GClass59.bool_0;
	}

	// Token: 0x060002EE RID: 750 RVA: 0x000031AF File Offset: 0x000013AF
	public static void smethod_40(bool bool_5)
	{
		GClass59.bool_0 = bool_5;
	}

	// Token: 0x060002EF RID: 751 RVA: 0x000031B7 File Offset: 0x000013B7
	public static bool smethod_41()
	{
		return GClass59.bool_1;
	}

	// Token: 0x060002F0 RID: 752 RVA: 0x000031BE File Offset: 0x000013BE
	public static void smethod_42(bool bool_5)
	{
		GClass59.bool_1 = bool_5;
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x0006C6A4 File Offset: 0x0006A8A4
	public static int smethod_43()
	{
		return GClass59.int_9;
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x000031C6 File Offset: 0x000013C6
	public static void smethod_44(int int_14)
	{
		GClass59.int_9 = int_14;
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x000031CE File Offset: 0x000013CE
	public static bool smethod_45()
	{
		return GClass59.bool_3;
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x000031D5 File Offset: 0x000013D5
	public static void smethod_46(bool bool_5)
	{
		GClass59.bool_3 = bool_5;
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x0006C6B8 File Offset: 0x0006A8B8
	public static int smethod_47()
	{
		return GClass59.int_12;
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x000031DD File Offset: 0x000013DD
	public static void smethod_48(int int_14)
	{
		GClass59.int_12 = int_14;
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x000031E5 File Offset: 0x000013E5
	public static bool smethod_49()
	{
		return GClass59.bool_4;
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x000031EC File Offset: 0x000013EC
	public static void smethod_50(bool bool_5)
	{
		GClass59.bool_4 = bool_5;
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x000031F4 File Offset: 0x000013F4
	public static bool smethod_51()
	{
		return GClass59.bool_2;
	}

	// Token: 0x060002FA RID: 762 RVA: 0x000031FB File Offset: 0x000013FB
	public static void smethod_52(bool bool_5)
	{
		GClass59.bool_2 = bool_5;
	}

	// Token: 0x060002FB RID: 763 RVA: 0x0006C6CC File Offset: 0x0006A8CC
	public static int smethod_53()
	{
		return GClass59.int_10;
	}

	// Token: 0x060002FC RID: 764 RVA: 0x00003203 File Offset: 0x00001403
	public static void smethod_54(int int_14)
	{
		GClass59.int_10 = int_14;
	}

	// Token: 0x060002FD RID: 765 RVA: 0x0006C6E0 File Offset: 0x0006A8E0
	public static long smethod_55()
	{
		return GClass59.long_0;
	}

	// Token: 0x060002FE RID: 766 RVA: 0x0000320B File Offset: 0x0000140B
	public static void smethod_56(long long_1)
	{
		GClass59.long_0 = long_1;
	}

	// Token: 0x060002FF RID: 767 RVA: 0x0006C6F4 File Offset: 0x0006A8F4
	public static string smethod_57()
	{
		return GClass59.string_17;
	}

	// Token: 0x06000300 RID: 768 RVA: 0x00003213 File Offset: 0x00001413
	public static void smethod_58(string string_22)
	{
		GClass59.string_17 = string_22;
	}

	// Token: 0x06000301 RID: 769 RVA: 0x0000321B File Offset: 0x0000141B
	public static bool smethod_59()
	{
		return !GClass61.smethod_16().ToLower().Contains("fiatecuscan2.exe");
	}

	// Token: 0x06000302 RID: 770 RVA: 0x0006C708 File Offset: 0x0006A908
	public static string smethod_60()
	{
		return GClass59.string_18;
	}

	// Token: 0x06000303 RID: 771 RVA: 0x00003234 File Offset: 0x00001434
	public static void smethod_61(string string_22)
	{
		GClass59.string_18 = string_22;
	}

	// Token: 0x06000304 RID: 772 RVA: 0x0006C71C File Offset: 0x0006A91C
	public static void smethod_62(int int_14)
	{
		if (GClass59.string_18.Length > 0)
		{
			GClass59.string_18 += ",";
			GClass59.string_18 = GClass59.string_18.Replace("(" + int_14 + "),", string.Empty);
		}
		object obj = GClass59.string_18;
		GClass59.string_18 = string.Concat(new object[]
		{
			obj,
			"(",
			int_14,
			")"
		});
		int i = 0;
		for (int j = 0; j < GClass59.string_18.Length; j++)
		{
			if (GClass59.string_18[j] == ',')
			{
				i++;
			}
		}
		while (i > 20)
		{
			GClass59.string_18 = GClass59.string_18.Substring(GClass59.string_18.IndexOf(",") + 1);
			i--;
		}
	}

	// Token: 0x06000305 RID: 773 RVA: 0x0006C80C File Offset: 0x0006AA0C
	public static Color smethod_63(int int_14)
	{
		Color result;
		if (int_14 < GClass59.color_0.Length)
		{
			result = GClass59.color_0[int_14];
		}
		else
		{
			result = GClass59.color_0[GClass59.color_0.Length - 1];
		}
		return result;
	}

	// Token: 0x06000306 RID: 774 RVA: 0x0000323C File Offset: 0x0000143C
	public static void smethod_64(int int_14, Color color_4)
	{
		if (int_14 < GClass59.color_0.Length)
		{
			GClass59.color_0[int_14] = color_4;
		}
	}

	// Token: 0x06000307 RID: 775 RVA: 0x0006C858 File Offset: 0x0006AA58
	public static Color smethod_65()
	{
		return GClass59.color_1;
	}

	// Token: 0x06000308 RID: 776 RVA: 0x0000325E File Offset: 0x0000145E
	public static void smethod_66(Color color_4)
	{
		GClass59.color_1 = color_4;
	}

	// Token: 0x06000309 RID: 777 RVA: 0x0006C86C File Offset: 0x0006AA6C
	public static Color smethod_67()
	{
		return GClass59.color_2;
	}

	// Token: 0x0600030A RID: 778 RVA: 0x00003266 File Offset: 0x00001466
	public static void smethod_68(Color color_4)
	{
		GClass59.color_2 = color_4;
	}

	// Token: 0x0600030B RID: 779 RVA: 0x0006C880 File Offset: 0x0006AA80
	public static Color smethod_69()
	{
		return GClass59.color_3;
	}

	// Token: 0x0600030C RID: 780 RVA: 0x0000326E File Offset: 0x0000146E
	public static void smethod_70(Color color_4)
	{
		GClass59.color_3 = color_4;
	}

	// Token: 0x0600030D RID: 781 RVA: 0x0006C894 File Offset: 0x0006AA94
	public static int smethod_71()
	{
		return GClass59.int_11;
	}

	// Token: 0x0600030E RID: 782 RVA: 0x00003276 File Offset: 0x00001476
	public static void smethod_72(int int_14)
	{
		GClass59.int_11 = int_14;
	}

	// Token: 0x0600030F RID: 783 RVA: 0x0006C8A8 File Offset: 0x0006AAA8
	public static Font smethod_73()
	{
		return GClass59.font_0;
	}

	// Token: 0x06000310 RID: 784 RVA: 0x0000327E File Offset: 0x0000147E
	public static void smethod_74(Font font_5)
	{
		GClass59.font_0 = font_5;
	}

	// Token: 0x06000311 RID: 785 RVA: 0x0006C8BC File Offset: 0x0006AABC
	public static Font smethod_75()
	{
		return GClass59.font_1;
	}

	// Token: 0x06000312 RID: 786 RVA: 0x00003286 File Offset: 0x00001486
	public static void smethod_76(Font font_5)
	{
		GClass59.font_1 = font_5;
	}

	// Token: 0x06000313 RID: 787 RVA: 0x0006C8D0 File Offset: 0x0006AAD0
	public static Font smethod_77()
	{
		return GClass59.font_2;
	}

	// Token: 0x06000314 RID: 788 RVA: 0x0000328E File Offset: 0x0000148E
	public static void smethod_78(Font font_5)
	{
		GClass59.font_2 = font_5;
	}

	// Token: 0x06000315 RID: 789 RVA: 0x0006C8E4 File Offset: 0x0006AAE4
	public static int[] smethod_79(int int_14)
	{
		return GClass59.int_13[int_14];
	}

	// Token: 0x06000316 RID: 790 RVA: 0x00003296 File Offset: 0x00001496
	public static void smethod_80(int int_14, int[] int_15)
	{
		GClass59.int_13[int_14] = int_15;
	}

	// Token: 0x06000317 RID: 791 RVA: 0x0006C8FC File Offset: 0x0006AAFC
	public static string smethod_81(int int_14)
	{
		return GClass59.string_19[int_14];
	}

	// Token: 0x06000318 RID: 792 RVA: 0x000032A0 File Offset: 0x000014A0
	public static void smethod_82(int int_14, string string_22)
	{
		GClass59.string_19[int_14] = string_22;
	}

	// Token: 0x06000319 RID: 793 RVA: 0x0006C914 File Offset: 0x0006AB14
	private static void smethod_83(string string_22, Font font_5)
	{
		GClass59.smethod_87(string_22, string.Concat(new object[]
		{
			font_5.Name,
			";",
			font_5.Style,
			";",
			font_5.SizeInPoints,
			"pt"
		}), RegistryValueKind.String);
	}

	// Token: 0x0600031A RID: 794 RVA: 0x000032AA File Offset: 0x000014AA
	private static void smethod_84(string string_22, Color color_4)
	{
		GClass59.smethod_87(string_22, color_4.ToArgb(), RegistryValueKind.DWord);
	}

	// Token: 0x0600031B RID: 795 RVA: 0x000032BF File Offset: 0x000014BF
	private static void smethod_85(string string_22, int int_14)
	{
		GClass59.smethod_87(string_22, int_14, RegistryValueKind.DWord);
	}

	// Token: 0x0600031C RID: 796 RVA: 0x000032CE File Offset: 0x000014CE
	private static void smethod_86(string string_22, string string_23)
	{
		GClass59.smethod_87(string_22, string_23, RegistryValueKind.String);
	}

	// Token: 0x0600031D RID: 797 RVA: 0x0006C974 File Offset: 0x0006AB74
	private static void smethod_87(string string_22, object object_0, RegistryValueKind registryValueKind_0)
	{
		using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software", true))
		{
			using (RegistryKey registryKey2 = registryKey.OpenSubKey("FiatECUScan", true))
			{
				if (registryKey2 == null)
				{
					using (RegistryKey registryKey3 = registryKey.CreateSubKey("FiatECUScan"))
					{
						registryKey3.SetValue(string_22, object_0, registryValueKind_0);
						goto IL_54;
					}
				}
				registryKey2.SetValue(string_22, object_0, registryValueKind_0);
				IL_54:;
			}
		}
	}

	// Token: 0x0600031E RID: 798 RVA: 0x0006CA1C File Offset: 0x0006AC1C
	private static int smethod_88(string string_22, int int_14)
	{
		object obj = GClass59.smethod_92(string_22);
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

	// Token: 0x0600031F RID: 799 RVA: 0x0006CA48 File Offset: 0x0006AC48
	private static string smethod_89(string string_22, string string_23)
	{
		object obj = GClass59.smethod_92(string_22);
		string result;
		if (obj == null)
		{
			result = string_23;
		}
		else
		{
			result = (string)obj;
		}
		return result;
	}

	// Token: 0x06000320 RID: 800 RVA: 0x0006CA74 File Offset: 0x0006AC74
	private static Color smethod_90(string string_22, Color color_4)
	{
		object obj = GClass59.smethod_92(string_22);
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

	// Token: 0x06000321 RID: 801 RVA: 0x0006CAA4 File Offset: 0x0006ACA4
	private static Font smethod_91(string string_22, Font font_5)
	{
		object obj = GClass59.smethod_92(string_22);
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

	// Token: 0x06000322 RID: 802 RVA: 0x0006CBC0 File Offset: 0x0006ADC0
	private static object smethod_92(string string_22)
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
					result = registryKey2.GetValue(string_22);
				}
			}
		}
		return result;
	}

	// Token: 0x06000323 RID: 803 RVA: 0x0006CC38 File Offset: 0x0006AE38
	public static void smethod_93()
	{
		try
		{
			if (GClass59.smethod_88("Interface 1 Type", -1) == -1)
			{
				GClass59.int_7[0] = GClass59.smethod_88("Interface Type", GClass59.int_7[0]);
				GClass59.string_6[0] = GClass59.smethod_89("Interface Port", GClass59.string_6[0]);
				GClass59.int_8[0] = GClass59.smethod_88("Port Speed", GClass59.int_8[0]);
			}
			else
			{
				GClass59.int_7[0] = GClass59.smethod_88("Interface 1 Type", GClass59.int_7[0]);
				GClass59.string_6[0] = GClass59.smethod_89("Interface 1 Port", GClass59.string_6[0]);
				GClass59.int_8[0] = GClass59.smethod_88("Interface 1 Port Speed", GClass59.int_8[0]);
				GClass59.int_7[1] = GClass59.smethod_88("Interface 2 Type", GClass59.int_7[1]);
				GClass59.string_6[1] = GClass59.smethod_89("Interface 2 Port", GClass59.string_6[1]);
				GClass59.int_8[1] = GClass59.smethod_88("Interface 2 Port Speed", GClass59.int_8[1]);
				GClass59.int_7[2] = GClass59.smethod_88("Interface 3 Type", GClass59.int_7[2]);
				GClass59.string_6[2] = GClass59.smethod_89("Interface 3 Port", GClass59.string_6[2]);
				GClass59.int_8[2] = GClass59.smethod_88("Interface 3 Port Speed", GClass59.int_8[2]);
				GClass59.int_7[3] = GClass59.smethod_88("Interface 4 Type", GClass59.int_7[3]);
				GClass59.string_6[3] = GClass59.smethod_89("Interface 4 Port", GClass59.string_6[3]);
				GClass59.int_8[3] = GClass59.smethod_88("Interface 4 Port Speed", GClass59.int_8[3]);
				GClass59.color_0[0] = GClass59.smethod_90("Parameter Color 1", GClass59.color_0[0]);
				GClass59.color_0[1] = GClass59.smethod_90("Parameter Color 2", GClass59.color_0[1]);
				GClass59.color_0[2] = GClass59.smethod_90("Parameter Color 3", GClass59.color_0[2]);
				GClass59.color_0[3] = GClass59.smethod_90("Parameter Color 4", GClass59.color_0[3]);
				GClass59.color_0[4] = GClass59.smethod_90("Parameter Color 5", GClass59.color_0[4]);
				GClass59.color_0[5] = GClass59.smethod_90("Parameter Color 6", GClass59.color_0[5]);
				GClass59.color_0[6] = GClass59.smethod_90("Parameter Color 7", GClass59.color_0[6]);
				GClass59.color_0[7] = GClass59.smethod_90("Parameter Color 8", GClass59.color_0[7]);
				GClass59.color_1 = GClass59.smethod_90("Graph Back Color", GClass59.color_1);
				GClass59.color_2 = GClass59.smethod_90("Graph Grid Color", GClass59.color_2);
				GClass59.color_3 = GClass59.smethod_90("Graph X-Axis Color", GClass59.color_3);
				GClass59.int_11 = GClass59.smethod_88("Graph Line Thickness", GClass59.int_11);
				GClass59.font_1 = GClass59.smethod_91("Graph X-Axis Font", GClass59.font_1);
				GClass59.font_0 = GClass59.smethod_91("Graph Y-Axis Font", GClass59.font_0);
				GClass59.font_2 = GClass59.smethod_91("Graph Parameter Font", GClass59.font_2);
			}
			GClass59.bool_0 = (GClass59.smethod_88("Show Available Ports Only", GClass59.bool_0 ? 1 : 0) == 1);
			GClass59.int_9 = GClass59.smethod_88("KWP2000 Timings", GClass59.int_9);
			GClass59.bool_1 = (GClass59.smethod_88("Show Adapter Message", GClass59.bool_1 ? 1 : 0) == 1);
			GClass59.bool_3 = (GClass59.smethod_88("High Latency mode", GClass59.bool_3 ? 1 : 0) == 1);
			GClass59.bool_2 = (GClass59.smethod_88("Convert KMs to Miles", GClass59.bool_2 ? 1 : 0) == 1);
			GClass59.int_12 = GClass59.smethod_88("Screen Repaint Interval", GClass59.int_12);
			GClass59.bool_4 = (GClass59.smethod_88("Show Disclaimer", GClass59.bool_4 ? 1 : 0) == 1);
			GClass59.int_10 = GClass59.smethod_88("Last Selection", GClass59.int_10);
			GClass59.string_8 = GClass59.smethod_89("UI Language", GClass59.string_8);
			GClass59.string_9 = GClass59.smethod_89("Data Language", GClass59.string_9);
			GClass59.font_3 = GClass59.smethod_91("UI Font 1", GClass59.font_3);
			GClass59.font_4 = GClass59.smethod_91("UI Font 2", GClass59.font_4);
			GClass59.string_11 = GClass59.smethod_89("CSV Separator", GClass59.string_11);
			GClass59.string_15 = GClass59.smethod_89("Export Folder", GClass59.string_15);
			GClass59.string_16 = GClass59.smethod_89("LOG Folder", GClass59.string_16);
			GClass59.color_0[8] = GClass59.smethod_90("Parameter Color 9", GClass59.color_0[8]);
			GClass59.color_0[9] = GClass59.smethod_90("Parameter Color 10", GClass59.color_0[9]);
			GClass59.string_13 = GClass59.smethod_89("Lic Number", GClass59.string_13);
			GClass59.string_14 = GClass59.smethod_89("Removal Key", GClass59.string_14);
			GClass59.string_18 = GClass59.smethod_89("Recent Vehicles", string.Empty);
			return;
		}
		catch (Exception value)
		{
		}
		try
		{
			FileStream fileStream = new FileStream(GClass59.string_7 + "\\" + GClass59.string_0.Replace(GClass59.string_3, GClass59.string_4), FileMode.Open, FileAccess.Read);
			GClass59.string_17 = GClass59.string_17 + GClass59.smethod_97(fileStream, (long)GClass59.int_0) + GClass59.smethod_97(fileStream, (long)GClass59.int_1) + GClass59.smethod_97(fileStream, (long)GClass59.int_2);
			GClass59.long_0 = fileStream.Length;
			fileStream.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x06000324 RID: 804 RVA: 0x0006D244 File Offset: 0x0006B444
	private static string smethod_94(int int_14)
	{
		string text = string.Empty;
		for (int i = 0; i < GClass59.int_13[int_14].Length; i++)
		{
			text = text + ((i > 0) ? "," : string.Empty) + GClass59.int_13[int_14][i];
		}
		return text;
	}

	// Token: 0x06000325 RID: 805 RVA: 0x0006D298 File Offset: 0x0006B498
	public static void smethod_95()
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(GClass59.string_7 + "\\" + GClass59.string_1);
			for (int i = 0; i < 10; i++)
			{
				streamWriter.WriteLine(i + "=" + GClass59.smethod_94(i));
			}
			streamWriter.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x06000326 RID: 806 RVA: 0x0006D30C File Offset: 0x0006B50C
	public static void smethod_96()
	{
		GClass59.string_17 = string.Empty;
		char[] separator = new char[]
		{
			','
		};
		try
		{
			Stream stream = File.OpenRead(GClass59.string_7 + "\\" + GClass59.string_1);
			StreamReader streamReader = new StreamReader(stream);
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				if (text[1] == '=' && text.Length > 2)
				{
					int num = Convert.ToInt32(text.Substring(0, 1));
					text = text.Substring(2);
					string[] array = text.Split(separator);
					GClass59.int_13[num] = new int[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						GClass59.int_13[num][i] = Convert.ToInt32(array[i]);
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
			FileStream fileStream = new FileStream(GClass59.string_7 + "\\" + GClass59.string_0.Replace(GClass59.string_3, GClass59.string_4), FileMode.Open, FileAccess.Read);
			GClass59.string_17 = GClass59.string_17 + GClass59.smethod_97(fileStream, (long)GClass59.int_0) + GClass59.smethod_97(fileStream, (long)GClass59.int_1) + GClass59.smethod_97(fileStream, (long)GClass59.int_2);
			GClass59.long_0 = fileStream.Length;
			fileStream.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x06000327 RID: 807 RVA: 0x0006D498 File Offset: 0x0006B698
	private static string smethod_97(FileStream fileStream_0, long long_1)
	{
		byte[] array = new byte[GClass59.int_4];
		fileStream_0.Seek(long_1, SeekOrigin.Begin);
		fileStream_0.Read(array, 0, array.Length);
		return GClass16.smethod_1(array).Replace(GClass59.string_20, GClass59.string_21);
	}

	// Token: 0x06000328 RID: 808 RVA: 0x0006D4DC File Offset: 0x0006B6DC
	public static void smethod_98()
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(GClass59.string_7 + "\\" + GClass59.string_2, false, Encoding.Unicode);
			for (int i = 0; i < 10; i++)
			{
				streamWriter.WriteLine(i + "=" + GClass59.string_19[i]);
			}
			streamWriter.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x06000329 RID: 809 RVA: 0x0006D558 File Offset: 0x0006B758
	public static void smethod_99()
	{
		char[] array = new char[]
		{
			','
		};
		try
		{
			Stream stream = File.OpenRead(GClass59.string_7 + "\\" + GClass59.string_2);
			StreamReader streamReader = new StreamReader(stream);
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				if (text[1] == '=' && text.Length > 2)
				{
					int num = Convert.ToInt32(text.Substring(0, 1));
					GClass59.string_19[num] = text.Substring(2);
				}
			}
			streamReader.Close();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x0600032A RID: 810 RVA: 0x0006D604 File Offset: 0x0006B804
	public static void smethod_100()
	{
		try
		{
			GClass59.smethod_85("Interface 1 Type", GClass59.int_7[0]);
			GClass59.smethod_86("Interface 1 Port", GClass59.string_6[0]);
			GClass59.smethod_85("Interface 1 Port Speed", GClass59.int_8[0]);
			GClass59.smethod_85("Interface 2 Type", GClass59.int_7[1]);
			GClass59.smethod_86("Interface 2 Port", GClass59.string_6[1]);
			GClass59.smethod_85("Interface 2 Port Speed", GClass59.int_8[1]);
			GClass59.smethod_85("Interface 3 Type", GClass59.int_7[2]);
			GClass59.smethod_86("Interface 3 Port", GClass59.string_6[2]);
			GClass59.smethod_85("Interface 3 Port Speed", GClass59.int_8[2]);
			GClass59.smethod_85("Interface 4 Type", GClass59.int_7[3]);
			GClass59.smethod_86("Interface 4 Port", GClass59.string_6[3]);
			GClass59.smethod_85("Interface 4 Port Speed", GClass59.int_8[3]);
			GClass59.smethod_85("Show Available Ports Only", GClass59.bool_0 ? 1 : 0);
			GClass59.smethod_85("KWP2000 Timings", GClass59.int_9);
			GClass59.smethod_85("Show Adapter Message", GClass59.bool_1 ? 1 : 0);
			GClass59.smethod_85("High Latency mode", GClass59.bool_3 ? 1 : 0);
			GClass59.smethod_85("Convert KMs to Miles", GClass59.bool_2 ? 1 : 0);
			GClass59.smethod_85("Screen Repaint Interval", GClass59.int_12);
			GClass59.smethod_85("Show Disclaimer", GClass59.bool_4 ? 1 : 0);
			GClass59.smethod_85("Last Selection", GClass59.int_10);
			GClass59.smethod_86("UI Language", GClass59.string_8);
			GClass59.smethod_86("Data Language", GClass59.string_9);
			GClass59.smethod_83("UI Font 1", GClass59.font_3);
			GClass59.smethod_83("UI Font 2", GClass59.font_4);
			GClass59.smethod_86("CSV Separator", GClass59.string_11);
			GClass59.smethod_86("Export Folder", GClass59.string_15);
			GClass59.smethod_86("LOG Folder", GClass59.string_16);
			GClass59.smethod_84("Parameter Color 1", GClass59.color_0[0]);
			GClass59.smethod_84("Parameter Color 2", GClass59.color_0[1]);
			GClass59.smethod_84("Parameter Color 3", GClass59.color_0[2]);
			GClass59.smethod_84("Parameter Color 4", GClass59.color_0[3]);
			GClass59.smethod_84("Parameter Color 5", GClass59.color_0[4]);
			GClass59.smethod_84("Parameter Color 6", GClass59.color_0[5]);
			GClass59.smethod_84("Parameter Color 7", GClass59.color_0[6]);
			GClass59.smethod_84("Parameter Color 8", GClass59.color_0[7]);
			GClass59.smethod_84("Parameter Color 9", GClass59.color_0[8]);
			GClass59.smethod_84("Parameter Color 10", GClass59.color_0[9]);
			GClass59.smethod_84("Graph Back Color", GClass59.color_1);
			GClass59.smethod_84("Graph Grid Color", GClass59.color_2);
			GClass59.smethod_84("Graph X-Axis Color", GClass59.color_3);
			GClass59.smethod_85("Graph Line Thickness", GClass59.int_11);
			GClass59.smethod_83("Graph X-Axis Font", GClass59.font_1);
			GClass59.smethod_83("Graph Y-Axis Font", GClass59.font_0);
			GClass59.smethod_83("Graph Parameter Font", GClass59.font_2);
			GClass59.smethod_86("Lic Number", GClass59.string_13);
			GClass59.smethod_86("Removal Key", GClass59.string_14);
			GClass59.smethod_86("Recent Vehicles", GClass59.string_18);
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	// Token: 0x04000487 RID: 1159
	private static string string_0 = "FiatECUScan.ini";

	// Token: 0x04000488 RID: 1160
	private static string string_1 = "FES_Templates.ini";

	// Token: 0x04000489 RID: 1161
	private static string string_2 = "FES_Tags.ini";

	// Token: 0x0400048A RID: 1162
	private static int int_0 = 127;

	// Token: 0x0400048B RID: 1163
	private static int int_1 = 160;

	// Token: 0x0400048C RID: 1164
	private static int int_2 = 1401333;

	// Token: 0x0400048D RID: 1165
	private static int int_3 = 15;

	// Token: 0x0400048E RID: 1166
	private static int int_4 = 16;

	// Token: 0x0400048F RID: 1167
	private static string string_3 = ".ini";

	// Token: 0x04000490 RID: 1168
	private static string string_4 = "2.exe";

	// Token: 0x04000491 RID: 1169
	private static int int_5 = 1;

	// Token: 0x04000492 RID: 1170
	private static string string_5 = "COM9";

	// Token: 0x04000493 RID: 1171
	private static int int_6 = 38400;

	// Token: 0x04000494 RID: 1172
	private static bool bool_0 = true;

	// Token: 0x04000495 RID: 1173
	private static bool bool_1 = true;

	// Token: 0x04000496 RID: 1174
	private static bool bool_2 = false;

	// Token: 0x04000497 RID: 1175
	private static int[] int_7;

	// Token: 0x04000498 RID: 1176
	private static string[] string_6;

	// Token: 0x04000499 RID: 1177
	private static int[] int_8;

	// Token: 0x0400049A RID: 1178
	private static int int_9;

	// Token: 0x0400049B RID: 1179
	private static bool bool_3;

	// Token: 0x0400049C RID: 1180
	private static int int_10;

	// Token: 0x0400049D RID: 1181
	private static bool bool_4;

	// Token: 0x0400049E RID: 1182
	private static Color[] color_0;

	// Token: 0x0400049F RID: 1183
	private static Color color_1;

	// Token: 0x040004A0 RID: 1184
	private static Color color_2;

	// Token: 0x040004A1 RID: 1185
	private static Color color_3;

	// Token: 0x040004A2 RID: 1186
	private static int int_11;

	// Token: 0x040004A3 RID: 1187
	private static Font font_0;

	// Token: 0x040004A4 RID: 1188
	private static Font font_1;

	// Token: 0x040004A5 RID: 1189
	private static Font font_2;

	// Token: 0x040004A6 RID: 1190
	private static int int_12;

	// Token: 0x040004A7 RID: 1191
	private static string string_7;

	// Token: 0x040004A8 RID: 1192
	private static string string_8;

	// Token: 0x040004A9 RID: 1193
	private static string string_9;

	// Token: 0x040004AA RID: 1194
	private static string string_10;

	// Token: 0x040004AB RID: 1195
	private static Font font_3;

	// Token: 0x040004AC RID: 1196
	private static Font font_4;

	// Token: 0x040004AD RID: 1197
	private static string string_11;

	// Token: 0x040004AE RID: 1198
	private static string string_12;

	// Token: 0x040004AF RID: 1199
	private static string string_13;

	// Token: 0x040004B0 RID: 1200
	private static string string_14;

	// Token: 0x040004B1 RID: 1201
	private static long long_0;

	// Token: 0x040004B2 RID: 1202
	private static string string_15;

	// Token: 0x040004B3 RID: 1203
	private static string string_16;

	// Token: 0x040004B4 RID: 1204
	private static string string_17;

	// Token: 0x040004B5 RID: 1205
	private static string string_18;

	// Token: 0x040004B6 RID: 1206
	private static int[][] int_13;

	// Token: 0x040004B7 RID: 1207
	private static string[] string_19;

	// Token: 0x040004B8 RID: 1208
	private static string string_20;

	// Token: 0x040004B9 RID: 1209
	private static string string_21;
}
