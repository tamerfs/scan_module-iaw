using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Management;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Multiecuscan;

// Token: 0x020000C8 RID: 200
public static class GClass127
{
	// Token: 0x060007B2 RID: 1970 RVA: 0x000F1480 File Offset: 0x000EF680
	public static void smethod_0()
	{
		bool flag = true;
		if (GClass125.smethod_5().Length == 18 && GClass125.smethod_5()[5] == '-' && GClass125.smethod_5()[11] == '-')
		{
			flag = true;
		}
		else if (GClass125.smethod_5().Length == 21 && GClass125.smethod_5()[8] == '-' && GClass125.smethod_5()[14] == '-')
		{
			flag = true;
		}
		else
		{
			GClass126.bool_13 = false;
		}
		string value = "730C7-06414-78";
		string a = "30";
		string text = GClass125.smethod_5();
		string value2 = "72345-67890-AB";
		if (GClass125.smethod_1())
		{
			if (!GClass126.bool_20)
			{
				GClass126.bool_20 = true;
			}
			GClass126.bool_13 = (a == GClass127.smethod_23(48));
			GClass126.bool_13 = !GClass126.bool_13;
		}
		if (GClass123.string_2 != GClass123.string_3)
		{
			GClass126.smethod_2(">Start 37", 0);
			GClass126.bool_13 = (a == GClass127.smethod_23(45));
		}
		string value3 = "1120D-DB05C-D8BA";
		if (GClass125.smethod_5().StartsWith(value))
		{
			GClass126.bool_13 = false;
		}
		if (GClass125.smethod_5().StartsWith(value2))
		{
			GClass126.bool_13 = false;
		}
		if (GClass125.smethod_5().StartsWith(value3))
		{
			GClass126.bool_13 = false;
		}
		if (GClass125.smethod_5() == "730C7-06414-786E33" && GClass127.smethod_16() == "730174727509-0173")
		{
			flag = false;
		}
		if (GClass125.smethod_5() == "730C7-06414-786E18" && GClass127.smethod_16() == "727205770000-0806")
		{
			flag = false;
		}
		if (GClass125.smethod_5() == "730C7-06414-786E18" && GClass127.smethod_16() == "080109030504-0773")
		{
			flag = false;
		}
		if (!flag)
		{
			GClass123.int_6++;
		}
		if (GClass125.smethod_11().Length > 0)
		{
			return;
		}
		GClass126.smethod_2("Start XLC", 0);
		if (!GClass126.bool_13 && !GClass126.bool_17)
		{
			text = GClass127.smethod_16() + text.Replace("5", "");
			text = text.Replace("-", "").ToUpper();
			List<string> list = new List<string>();
			for (int i = 0; i < list.Count; i++)
			{
				if (text == list[i])
				{
					GClass126.bool_13 = true;
					GClass126.bool_18 = true;
					break;
				}
			}
		}
		GClass126.smethod_2("End XLC", 0);
	}

	// Token: 0x060007B3 RID: 1971 RVA: 0x00004A71 File Offset: 0x00002C71
	public static string smethod_1(object object_0, string string_13)
	{
		if (object_0 == null)
		{
			return string_13;
		}
		return object_0.ToString();
	}

	// Token: 0x060007B4 RID: 1972 RVA: 0x000F16D0 File Offset: 0x000EF8D0
	public static string smethod_2(string string_13, string string_14)
	{
		if (string_13.Length < 16)
		{
			string_13 += "30383936363339323634393236344141";
		}
		string_13 = string_13.Substring(0, 16);
		byte[] array = GClass127.smethod_32(string_13);
		byte[] array2 = new byte[array.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = array[array.Length - i - 1];
		}
		bool flag = string_14 != GClass125.smethod_5();
		string text = GClass127.smethod_16().Replace("-", "");
		if (string_14.StartsWith("MP-"))
		{
			text = "55000081";
		}
		text = text + " F F F F " + string_14.Replace("-", "").Replace("MP", "");
		byte[] buffer = GClass127.smethod_32("00");
		try
		{
			buffer = GClass127.smethod_32(text);
		}
		catch (Exception)
		{
			buffer = GClass127.smethod_32("F F F F F F F F" + string_14.ToUpper().Replace("-", "").Replace("M", "").Replace("P", ""));
		}
		byte[] array3 = GClass127.smethod_32("6A606A197B056117");
		if (GClass125.smethod_101(18).Name.EndsWith("0000") && !flag)
		{
			array3 = GClass127.smethod_32("2B796A291B256457");
		}
		if (string_14.Length == 18 && string_14[5] == '-' && string_14[11] == '-' && (GClass125.smethod_11().Length == 0 || flag))
		{
			try
			{
				string_14 = string_14.Replace("-", "");
				if (array3[0] == 106)
				{
					array3 = GClass127.smethod_32(string_14);
				}
			}
			catch (Exception)
			{
			}
		}
		int num = 0;
		while (num < array2.Length && num < array3.Length)
		{
			byte[] array4 = array2;
			int num2 = num;
			array4[num2] ^= array3[num];
			num++;
		}
		byte[] byte_ = SHA1.Create().ComputeHash(buffer);
		GClass126.string_8 = GClass127.smethod_11(array2).Replace(" ", "");
		string text2 = GClass127.smethod_50("en", byte_);
		string text3 = Encoding.ASCII.GetString(array2);
		int length = text3.Length;
		if (text2.Length > 20)
		{
			GClass126.bool_18 = (text.Length > 0 && text.Length < 200);
			text3 += text2;
		}
		return GClass127.smethod_11(array2).Replace(" ", "");
	}

	// Token: 0x060007B5 RID: 1973 RVA: 0x000F1958 File Offset: 0x000EFB58
	public static string smethod_3(string string_13)
	{
		byte[] array = GClass127.smethod_32(string_13);
		int num = 0;
		int num2 = 0;
		while (num2 < array.Length && num2 < 13)
		{
			byte[] array2 = array;
			int num3 = num2;
			array2[num3] ^= GClass126.byte_3[num];
			num++;
			if (num >= GClass126.byte_3.Length)
			{
				num = 0;
			}
			num2++;
		}
		return Encoding.ASCII.GetString(array);
	}

	// Token: 0x060007B6 RID: 1974 RVA: 0x000051F5 File Offset: 0x000033F5
	public static string smethod_4()
	{
		return Process.GetCurrentProcess().MainModule.ModuleName;
	}

	// Token: 0x060007B7 RID: 1975 RVA: 0x000E8148 File Offset: 0x000E6348
	public static byte[][] smethod_5(string string_13)
	{
		List<byte[]> list = new List<byte[]>();
		string text = string_13.Replace(" ", "");
		int i = 0;
		List<byte> list2 = new List<byte>();
		while (i < text.Length - 1)
		{
			if (text[i] == ',')
			{
				list.Add(list2.ToArray());
				list2 = new List<byte>();
				i++;
			}
			list2.Add(byte.Parse(text.Substring(i, 2), NumberStyles.HexNumber));
			i += 2;
		}
		list.Add(list2.ToArray());
		return list.ToArray();
	}

	// Token: 0x060007B8 RID: 1976 RVA: 0x00005206 File Offset: 0x00003406
	private static string smethod_6()
	{
		return GClass126.string_2.Replace("CurVerNum", "ExternalFunc") + "?id=" + GClass125.smethod_5();
	}

	// Token: 0x060007B9 RID: 1977 RVA: 0x00004A96 File Offset: 0x00002C96
	private static string smethod_7(string string_13)
	{
		return new StreamReader(WebRequest.Create(new Uri(string_13)).GetResponse().GetResponseStream()).ReadToEnd();
	}

	// Token: 0x060007BA RID: 1978 RVA: 0x000F19B0 File Offset: 0x000EFBB0
	private static string smethod_8(byte[] byte_2)
	{
		int num = 20;
		if (byte_2.Length == 28)
		{
			num = byte_2.Length - 1;
		}
		if (!GClass126.bool_17)
		{
			GClass127.byte_1 = 0;
		}
		for (int i = 0; i < byte_2.Length; i++)
		{
			if (i < num)
			{
				GClass127.byte_1 += byte_2[i];
			}
			else if (GClass127.byte_1 != byte_2[i])
			{
				throw new Exception(GClass127.string_0);
			}
		}
		if (num > 21)
		{
			return GClass127.smethod_11(byte_2).Substring(0, GClass127.int_3);
		}
		return GClass127.smethod_11(byte_2).Substring(0, GClass127.int_2);
	}

	// Token: 0x060007BB RID: 1979 RVA: 0x000F1A3C File Offset: 0x000EFC3C
	public static void smethod_9()
	{
		GClass126.smethod_2("LENC4", 0);
		GClass126.string_13[0] + GClass126.string_13[2] + GClass126.string_13[3];
		string str = string.Concat(new string[]
		{
			GClass127.string_3,
			"S",
			GClass127.string_2,
			".",
			GClass127.string_4,
			"x",
			GClass127.string_4
		});
		FileStream fileStream = new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.string_10[4] + ".dat", FileMode.Open, FileAccess.Read);
		byte[] array = SHA1.Create().ComputeHash(fileStream);
		GClass125.string_0 = GClass127.smethod_11(array);
		fileStream.Close();
		int num = 0;
		while (num < array.Length && num < GClass126.byte_1.Length)
		{
			byte[] array2 = GClass126.byte_1;
			int num2 = num;
			array2[num2] ^= array[num];
			if (num % 2 == 1)
			{
				byte[] array3 = array;
				int num3 = num;
				array3[num3] &= 30;
			}
			else
			{
				byte[] array4 = array;
				int num4 = num;
				array4[num4] &= 61;
			}
			num++;
		}
		fileStream = new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.string_10[7] + ".dat", FileMode.Open, FileAccess.Read);
		byte[] array5 = SHA1.Create().ComputeHash(fileStream);
		fileStream.Close();
		int num5 = 0;
		while (num5 < array5.Length && num5 < GClass126.byte_1.Length)
		{
			if (num5 % 2 == 1)
			{
				byte[] array6 = array5;
				int num6 = num5;
				array6[num6] &= 30;
			}
			else
			{
				byte[] array7 = array5;
				int num7 = num5;
				array7[num7] &= 61;
			}
			num5++;
		}
		fileStream = new FileStream(GClass125.smethod_30() + "\\Multie" + str, FileMode.Open, FileAccess.Read);
		byte[] array8 = SHA1.Create().ComputeHash(fileStream);
		fileStream.Close();
		int num8 = 0;
		while (num8 < array8.Length && num8 < GClass126.byte_2.Length)
		{
			if (num8 % 2 == 1)
			{
				byte[] array9 = array8;
				int num9 = num8;
				array9[num9] &= 15;
			}
			else
			{
				byte[] array10 = array8;
				int num10 = num8;
				array10[num10] &= 27;
			}
			byte[] byte_ = GClass126.byte_2;
			int num11 = num8;
			byte_[num11] ^= array8[num8];
			num8++;
		}
		List<byte> list = new List<byte>();
		for (int i = 0; i < array.Length; i++)
		{
			list.Add(array[i]);
		}
		for (int j = 0; j < array8.Length; j++)
		{
			list.Add(array8[j]);
		}
		for (int k = 0; k < array5.Length; k++)
		{
			list.Add(array5[k]);
		}
		GClass126.smethod_2("LENC5", 0);
		GClass126.byte_2 = list.ToArray();
	}

	// Token: 0x060007BC RID: 1980 RVA: 0x000E803C File Offset: 0x000E623C
	public static long smethod_10(object object_0)
	{
		if (object_0 == null)
		{
			return 0L;
		}
		long result = 0L;
		try
		{
			result = Convert.ToInt64(object_0);
		}
		catch (Exception)
		{
		}
		return result;
	}

	// Token: 0x060007BD RID: 1981 RVA: 0x0000522B File Offset: 0x0000342B
	public static string smethod_11(byte[] byte_2)
	{
		return BitConverter.ToString(byte_2).Replace(GClass127.string_5, GClass127.string_6);
	}

	// Token: 0x060007BE RID: 1982 RVA: 0x000F1CC4 File Offset: 0x000EFEC4
	public static string smethod_12(string string_13)
	{
		string text = "";
		byte[] array = new byte[18];
		long num = (long)(array.Length * 10);
		GClass126.smethod_2("LCENC1", 0);
		string text2 = GClass127.smethod_11(GClass127.smethod_32(string_13));
		GClass127.byte_1 = 0;
		num *= 700L;
		FileStream fileStream = new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.string_10[4] + ".dat", FileMode.Open, FileAccess.Read);
		long num2 = fileStream.Length;
		if (num2 > num)
		{
			num2 = num;
		}
		while (fileStream.Position < num2)
		{
			fileStream.Read(array, 0, array.Length);
			if (GClass127.smethod_55(array) == text2)
			{
				text = text2;
			}
		}
		fileStream.Close();
		text = text.Replace(" ", "");
		text = text.Replace("P", "p").Replace("I", "i");
		GClass126.smethod_2("LCENC2", 0);
		return text;
	}

	// Token: 0x060007BF RID: 1983 RVA: 0x000F1DB4 File Offset: 0x000EFFB4
	public static string smethod_13(string string_13)
	{
		bool flag = string_13.Contains("BL");
		string_13 = string_13.Replace("BL", "");
		bool flag2 = string_13.Contains("BT");
		string_13 = string_13.Replace("BT", "");
		if (flag || flag2)
		{
			GClass125.smethod_85(true);
		}
		bool flag3 = string_13.Contains("BM");
		string_13 = string_13.Replace("BM", "");
		bool flag4 = string_13.Contains("BD");
		string_13 = string_13.Replace("BD", "");
		if (flag2)
		{
			GClass125.smethod_102(18, Color.Black);
		}
		if (flag4)
		{
			GClass125.smethod_83("FIAT|ALFA|LANCIA");
		}
		if (flag3)
		{
			GClass125.smethod_0();
		}
		if (flag)
		{
			GClass125.smethod_102(19, Color.Black);
		}
		return string_13;
	}

	// Token: 0x060007C0 RID: 1984 RVA: 0x000EF054 File Offset: 0x000ED254
	public static List<TableDataRowE> smethod_14(List<GClass102> list_0)
	{
		List<TableDataRowE> list = new List<TableDataRowE>();
		for (int i = 0; i < list_0.Count; i++)
		{
			list.Add(new TableDataRowE(list_0[i]));
		}
		return list;
	}

	// Token: 0x060007C1 RID: 1985 RVA: 0x000F1E74 File Offset: 0x000F0074
	public static string smethod_15(string string_13)
	{
		ManagementObject managementObject = new ManagementObject(GClass127.string_7 + "=\"" + string_13 + ":\"");
		managementObject.Get();
		string result = managementObject[GClass127.string_8].ToString();
		managementObject.Dispose();
		return result;
	}

	// Token: 0x060007C2 RID: 1986 RVA: 0x000EEE3C File Offset: 0x000ED03C
	public static string smethod_16()
	{
		string text = GClass126.string_12;
		byte[] array = GClass127.smethod_32(text);
		for (int i = 0; i < array.Length; i++)
		{
			byte[] array2 = array;
			int num = i;
			array2[num] ^= 49;
			text += GClass127.smethod_23(array[i]);
			if (i == 5 || i == 9 || i == 14)
			{
				text += "-";
			}
		}
		return text.Substring(array.Length * 2);
	}

	// Token: 0x060007C3 RID: 1987 RVA: 0x000F1EB8 File Offset: 0x000F00B8
	public static string smethod_17()
	{
		string text = GClass126.string_12;
		bool flag = GClass125.smethod_101(19).B == 0;
		string text2 = GClass126.string_2 + "?id=" + GClass126.string_1;
		string text3 = ((!flag) ? "" : "B") + ((GClass123.int_7 > 2) ? "F" : "") + ((GClass123.int_1 != 1) ? "F" : "");
		string text4 = (!GClass126.bool_13) ? "" : "R";
		string text5 = GClass126.int_7.ToString() ?? "";
		string text6 = (GClass126.bool_13 || !GClass125.smethod_5().StartsWith("730C7-06414-7")) ? ("&r=" + GClass125.smethod_5()) : "";
		string text7 = (GClass126.bool_13 || !(GClass125.smethod_11() != "")) ? "" : ("&r=" + GClass125.smethod_11());
		string text8 = "&h=" + GClass126.string_11;
		string text9 = string.Concat(new string[]
		{
			"&w=",
			Environment.OSVersion.Version.Major.ToString(),
			".",
			Environment.OSVersion.Version.Minor.ToString(),
			".",
			Environment.OSVersion.Version.Build.ToString()
		});
		byte[] array = GClass127.smethod_32(text);
		for (int i = 0; i < array.Length; i++)
		{
			byte[] array2 = array;
			int num = i;
			array2[num] ^= 49;
			text += GClass127.smethod_23(array[i]);
			if (i == 5 || i == 9 || i == 14)
			{
				text += "-";
			}
		}
		string text10 = text.Substring(array.Length * 2);
		return string.Concat(new string[]
		{
			text2,
			text3,
			text4,
			text5,
			text10,
			text6,
			(text6 == "") ? text7 : "",
			text8,
			text9
		});
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x000F20F4 File Offset: 0x000F02F4
	public static byte[] smethod_18(byte[] byte_2, string string_13, string string_14, int int_5)
	{
		byte[] result = new byte[8];
		try
		{
			string text = GClass126.string_12;
			bool flag = GClass125.smethod_101(19).B == 0;
			string text2 = GClass126.string_1;
			string text3 = ((!flag) ? "" : "B") + ((GClass123.int_7 > 2) ? "F" : "") + ((GClass123.int_1 != 1) ? "F" : "");
			string text4 = ((!GClass126.bool_13) ? "" : "R") + GClass126.int_7.ToString();
			byte[] array = GClass127.smethod_32(text);
			for (int i = 0; i < array.Length; i++)
			{
				byte[] array2 = array;
				int num = i;
				array2[num] ^= 49;
				text += GClass127.smethod_23(array[i]);
				if (i == 5 || i == 9 || i == 14)
				{
					text += "-";
				}
			}
			string text5 = text.Substring(array.Length * 2);
			string text6 = "{\n";
			text6 = string.Concat(new string[]
			{
				text6,
				"\"HardwareKey\":\"",
				text2,
				text3,
				text4,
				text5,
				"\",\n"
			});
			text6 = text6 + "\"LicenseKey\":\"" + (GClass126.bool_13 ? GClass125.smethod_5() : "-") + "\",\n";
			text6 = text6 + "\"DeviceID\":\"" + string_13 + "\",\n";
			text6 = text6 + "\"PurchaseToken\":\"" + GClass125.smethod_91() + "\",\n";
			text6 += "\"FunctionType\":\"105\",\n";
			text6 = text6 + "\"Module\":\"" + string_14 + "\",\n";
			text6 = text6 + "\"Address\":\"" + int_5.ToString() + "\",\n";
			text6 = text6 + "\"RequestData\":\"" + GClass127.smethod_11(byte_2) + "\"\n";
			text6 += "}";
			byte[] bytes = Encoding.UTF8.GetBytes(text6);
			WebRequest webRequest = WebRequest.Create(GClass127.smethod_6());
			webRequest.Method = "POST";
			webRequest.ContentType = "application/json";
			webRequest.ContentLength = (long)bytes.Length;
			using (Stream requestStream = webRequest.GetRequestStream())
			{
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Flush();
			}
			GClass126.smethod_2("CALCSKV: Data sent to server", 0);
			WebResponse response = webRequest.GetResponse();
			string text7 = "";
			using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
			{
				text7 = streamReader.ReadToEnd().Trim();
			}
			GClass126.smethod_2("CALCSKV: Server response: " + text7, 0);
			string[] array3 = text7.Split(new char[]
			{
				'*'
			});
			if (array3.Length != 2)
			{
				if (text7.Contains("00000001"))
				{
					return GClass127.smethod_32("01");
				}
				if (text7.Contains("00000002"))
				{
					return GClass127.smethod_32("02");
				}
				if (text7.Contains("00000003"))
				{
					return GClass127.smethod_32("03");
				}
				if (text7.Contains("00000099"))
				{
					return GClass127.smethod_32("99");
				}
			}
			if (array3[1] != "00000000")
			{
				return GClass127.smethod_32("99");
			}
			result = GClass127.smethod_32(array3[0]);
		}
		catch (Exception ex)
		{
			GClass126.smethod_2("CALCSKV: Failed to connect to server (1): " + ex.Message, 0);
			return GClass127.smethod_32("11");
		}
		return result;
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x000E81D0 File Offset: 0x000E63D0
	public static string smethod_19(string string_13)
	{
		string text = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		GClass125.smethod_102(18, Color.Black);
		return GClass121.smethod_10(string_13, text);
	}

	// Token: 0x060007C6 RID: 1990 RVA: 0x000F24D0 File Offset: 0x000F06D0
	private static string smethod_20(byte[] byte_2)
	{
		List<byte> list = new List<byte>();
		byte b = 0;
		for (int i = 0; i < byte_2.Length; i++)
		{
			if (i % 2 == 0)
			{
				list.Add(byte_2[i]);
			}
			else
			{
				b += byte_2[i];
			}
		}
		list.Add(b);
		return GClass127.smethod_11(list.ToArray());
	}

	// Token: 0x060007C7 RID: 1991 RVA: 0x000F251C File Offset: 0x000F071C
	public static string smethod_21(string string_13, string string_14)
	{
		if (string_13.Length < 16)
		{
			string_13 += "30383936363339323634393236344141";
		}
		string_13 = string_13.Substring(0, 16);
		byte[] array = GClass127.smethod_32(string_13);
		byte[] array2 = new byte[array.Length];
		byte b = 170;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = array[array.Length - i - 1];
		}
		bool flag = string_14 != GClass125.smethod_5();
		string text = "FF";
		string text2 = "";
		byte[] array3 = GClass127.smethod_32("6A606A197B056117");
		if (GClass125.smethod_101(18).Name.EndsWith("0000") && !flag)
		{
			array3 = GClass127.smethod_32("2B796A291B256457");
		}
		if (string_14.Length > 4 && string_14.ToUpper()[0] == 'M' && string_14.ToUpper()[1] == 'P')
		{
			text2 = string_14.Substring(0, 3);
			string_14 = string_14.Substring(3);
			text += text;
		}
		if (string_14.Length == 18 && string_14[5] == '-' && string_14[11] == '-' && (GClass125.smethod_11().Length == 0 || flag))
		{
			try
			{
				string_14 = string_14.Replace("-", "");
				if (array3[0] == 106)
				{
					array3 = GClass127.smethod_32(string_14);
				}
				b = 0;
				GClass126.bool_10 = (text.Length == 4);
			}
			catch (Exception)
			{
			}
		}
		byte[] byte_ = GClass127.smethod_41(array2);
		if (text2.Length == 3)
		{
			byte_ = GClass127.smethod_32(text);
		}
		byte[] array4 = GClass127.smethod_26(GClass127.smethod_32(GClass127.smethod_11(byte_) + GClass127.smethod_11(array3)));
		List<byte> list = new List<byte>();
		for (int j = 0; j < array4.Length; j++)
		{
			if (j % 2 == 0)
			{
				list.Add(array4[j]);
			}
			else
			{
				b += array4[j];
			}
		}
		list.Add(b);
		GClass123.string_2 = GClass127.smethod_11(list.ToArray());
		return GClass127.smethod_11(list.ToArray()).Replace(" ", "");
	}

	// Token: 0x060007C8 RID: 1992 RVA: 0x00005242 File Offset: 0x00003442
	public static bool smethod_22(string string_13, string string_14)
	{
		GClass125.smethod_15();
		return string_13 == string_14;
	}

	// Token: 0x060007C9 RID: 1993 RVA: 0x00005251 File Offset: 0x00003451
	public static string smethod_23(byte byte_2)
	{
		return GClass127.smethod_11(new byte[]
		{
			byte_2
		});
	}

	// Token: 0x060007CA RID: 1994 RVA: 0x000F2738 File Offset: 0x000F0938
	public static bool smethod_24()
	{
		string s = GClass125.smethod_86() + "_" + GClass126.string_9;
		byte[] array = Encoding.ASCII.GetBytes(s);
		byte[] array2 = GClass127.smethod_28(array);
		string s2 = GClass125.smethod_88() + "_" + GClass126.string_9;
		string text = GClass127.smethod_12(GClass127.smethod_20(array2));
		if (text.Length < 10)
		{
			if (array2.Length > 5)
			{
				array2 = GClass127.smethod_28(Encoding.ASCII.GetBytes(s2));
			}
			text = GClass127.smethod_12(GClass127.smethod_20(array2));
		}
		s2 = GClass125.smethod_90() + "_" + GClass126.string_9;
		if (text.Length < 10)
		{
			if (array2.Length > 8)
			{
				array2 = GClass127.smethod_28(Encoding.ASCII.GetBytes(s2));
			}
			text = GClass127.smethod_12(GClass127.smethod_20(array2));
		}
		if (text.Length < 10)
		{
			return false;
		}
		array = GClass127.smethod_32(text);
		int[] array3 = new int[5];
		int num = 0;
		while (num < array.Length && num < GClass126.byte_3.Length)
		{
			byte[] byte_ = GClass126.byte_3;
			int num2 = num;
			byte_[num2] ^= array[num];
			array3[1] += (int)GClass126.byte_3[num];
			if (GClass126.byte_3.Length > array.Length + num)
			{
				byte[] byte_2 = GClass126.byte_3;
				int num3 = array.Length + num;
				byte_2[num3] ^= array[num];
				array3[2] += (int)GClass126.byte_3[array.Length + num];
			}
			else
			{
				array3[2] += num;
			}
			if (GClass126.byte_3.Length > 2 * array.Length + num)
			{
				byte[] byte_3 = GClass126.byte_3;
				int num4 = 2 * array.Length + num;
				byte_3[num4] ^= array[num];
				array3[3] += (int)GClass126.byte_3[2 * array.Length + num];
			}
			else
			{
				array3[3] += num;
			}
			num++;
		}
		for (int i = 0; i < array3.Length - 1; i++)
		{
			if (i != 0 && array3[i] == 0)
			{
				GClass126.smethod_2("CTV" + i.ToString(), 0);
			}
		}
		return array3[1] == 0 || array3[2] == 0 || array3[3] == 0;
	}

	// Token: 0x060007CB RID: 1995 RVA: 0x000F2960 File Offset: 0x000F0B60
	public static string smethod_25()
	{
		string text = "";
		GClass123.int_5++;
		try
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_PhysicalMedia");
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				if (text == "")
				{
					text = GClass127.smethod_48(managementObject.Properties["SerialNumber"].Value);
				}
			}
			managementObjectCollection.Dispose();
			managementObjectCollection = null;
			managementObjectSearcher.Dispose();
			managementObjectSearcher = null;
			text = text.Trim();
		}
		catch (Exception ex)
		{
			GClass126.smethod_2("ERROR(1):" + ex.Message, 0);
		}
		if (text == "")
		{
			text = "X";
		}
		if (text.Length > 12)
		{
			text = text.Substring(0, 12);
		}
		return GClass127.smethod_11(Encoding.ASCII.GetBytes(text));
	}

	// Token: 0x060007CC RID: 1996 RVA: 0x00005262 File Offset: 0x00003462
	public static byte[] smethod_26(byte[] byte_2)
	{
		return SHA1.Create().ComputeHash(byte_2);
	}

	// Token: 0x060007CD RID: 1997 RVA: 0x000F2A6C File Offset: 0x000F0C6C
	public static string smethod_27(string string_13)
	{
		GClass123.int_5++;
		ManagementObject managementObject = new ManagementObject(GClass127.string_7 + "=\"" + string_13 + ":\"");
		managementObject.Get();
		string text = managementObject[GClass127.string_8].ToString();
		GClass125.smethod_17(managementObject["Size"].ToString());
		managementObject.Dispose();
		if (text.Length > 8)
		{
			text = text.Substring(0, 8);
		}
		string text2 = GClass125.smethod_16();
		byte[] bytes = Encoding.ASCII.GetBytes(text);
		byte[] bytes2 = Encoding.ASCII.GetBytes(text2);
		byte b = 0;
		for (int i = 0; i < bytes2.Length; i++)
		{
			b += bytes2[i];
		}
		byte[] bytes3 = Encoding.ASCII.GetBytes(text2 + "VIJ0GO0TOZI0MASTER0E01234567890123456789");
		for (int j = 0; j < text.Length; j++)
		{
			byte[] array = bytes;
			int num = j;
			array[num] += bytes3[j];
			byte[] array2 = bytes;
			int num2 = j;
			array2[num2] ^= bytes3[j + 8];
		}
		return GClass127.smethod_11(bytes) + GClass127.smethod_23(b);
	}

	// Token: 0x060007CE RID: 1998 RVA: 0x0000526F File Offset: 0x0000346F
	public static byte[] smethod_28(byte[] byte_2)
	{
		return SHA256.Create().ComputeHash(byte_2);
	}

	// Token: 0x060007CF RID: 1999 RVA: 0x000F2B84 File Offset: 0x000F0D84
	public static decimal smethod_29(decimal decimal_0, string string_13)
	{
		decimal num = decimal_0;
		if (GClass125.smethod_71() && (string_13 == "km" || string_13 == "km/h"))
		{
			num /= 0.621371192237m;
		}
		if (GClass125.smethod_73() && string_13 == "°c")
		{
			num = (num - 32m) / 1.8m;
		}
		if (GClass125.smethod_75())
		{
			if (string_13 == "bar")
			{
				num /= 14.5037738m;
			}
			if (string_13 == "mbar")
			{
				num /= 0.0145037738m;
			}
		}
		if (GClass125.smethod_77() && (string_13 == "kg" || string_13 == "kg/h"))
		{
			num /= 2.20462262185m;
		}
		if (GClass125.smethod_79())
		{
			if (string_13 == "mm")
			{
				num /= 0.03937007874m;
			}
			if (string_13 == "m" || string_13 == "m/sec²")
			{
				num /= 3.28084m;
			}
			if (string_13 == "mm³/i")
			{
				num /= 0.000061023744m;
			}
		}
		return num;
	}

	// Token: 0x060007D0 RID: 2000 RVA: 0x00004A7E File Offset: 0x00002C7E
	public static byte[] smethod_30(long long_0)
	{
		return BitConverter.GetBytes(long_0);
	}

	// Token: 0x060007D1 RID: 2001 RVA: 0x000EF01C File Offset: 0x000ED21C
	public static List<TableDataRowP> smethod_31(List<GClass104> list_0)
	{
		List<TableDataRowP> list = new List<TableDataRowP>();
		for (int i = 0; i < list_0.Count; i++)
		{
			list.Add(new TableDataRowP(list_0[i]));
		}
		return list;
	}

	// Token: 0x060007D2 RID: 2002 RVA: 0x000F2D04 File Offset: 0x000F0F04
	public static byte[] smethod_32(string string_13)
	{
		List<byte> list = new List<byte>();
		string text = string_13.Replace(GClass127.string_6, GClass127.string_1);
		for (int i = 0; i < text.Length - 1; i += 2)
		{
			list.Add(byte.Parse(text.Substring(i, 2), NumberStyles.HexNumber));
		}
		return list.ToArray();
	}

	// Token: 0x060007D3 RID: 2003 RVA: 0x0000527C File Offset: 0x0000347C
	public static string smethod_33()
	{
		return GClass127.string_10[5];
	}

	// Token: 0x060007D4 RID: 2004 RVA: 0x000F2D5C File Offset: 0x000F0F5C
	public static void smethod_34(ref byte[] byte_2, byte[] byte_3)
	{
		byte[] array = new byte[256];
		byte[] array2 = new byte[256];
		int i;
		for (i = 0; i < 256; i++)
		{
			array[i] = (byte)i;
			array2[i] = byte_3[i % byte_3.GetLength(0)];
		}
		int num = 0;
		for (i = 0; i < 256; i++)
		{
			num = (num + (int)array[i] + (int)array2[i]) % 256;
			byte b = array[i];
			array[i] = array[num];
			array[num] = b;
		}
		int num2 = 0;
		num = 0;
		i = num2;
		for (int j = 0; j < byte_2.GetLength(0); j++)
		{
			i = (i + 1) % 256;
			num = (num + (int)array[i]) % 256;
			byte b = array[i];
			array[i] = array[num];
			array[num] = b;
			int num3 = (int)(array[i] + array[num]) % 256;
			byte[] array3 = byte_2;
			int num4 = j;
			array3[num4] ^= array[num3];
		}
	}

	// Token: 0x060007D5 RID: 2005 RVA: 0x000F2E40 File Offset: 0x000F1040
	public static bool smethod_35(string string_13, string string_14)
	{
		if (string_14.Length > string_13.Length)
		{
			return false;
		}
		for (int i = 0; i < string_14.Length; i++)
		{
			if (string_13[i] != string_14[i] && string_14[i] != '?')
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060007D6 RID: 2006 RVA: 0x00005285 File Offset: 0x00003485
	public static string smethod_36(string string_13)
	{
		return GClass127.smethod_20(GClass127.smethod_28(Encoding.ASCII.GetBytes(string_13)));
	}

	// Token: 0x060007D7 RID: 2007 RVA: 0x000E8008 File Offset: 0x000E6208
	public static int smethod_37(object object_0)
	{
		if (object_0 == null)
		{
			return 0;
		}
		int result = 0;
		try
		{
			result = Convert.ToInt32(object_0);
		}
		catch (Exception)
		{
		}
		return result;
	}

	// Token: 0x060007D8 RID: 2008 RVA: 0x000F2E90 File Offset: 0x000F1090
	public static bool smethod_38()
	{
		bool flag = false;
		if (GClass125.smethod_5() == "70050-A0100-0E6277" && GClass127.smethod_16() == "020306017272-0207")
		{
			flag = true;
		}
		if (GClass125.smethod_5() == "0E650-56664-677D77" && GClass127.smethod_16() == "770707010770-0273")
		{
			flag = true;
		}
		if (flag)
		{
			GClass126.bool_13 = !flag;
		}
		return flag;
	}

	// Token: 0x060007D9 RID: 2009 RVA: 0x000F2EF4 File Offset: 0x000F10F4
	public static void smethod_39()
	{
		string text = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
		Random random = new Random();
		string text2 = "";
		for (int i = 0; i < 16; i++)
		{
			text2 += text[random.Next(1, text.Length) - 1].ToString();
		}
		GClass125.smethod_92(text2);
	}

	// Token: 0x060007DA RID: 2010 RVA: 0x000F2F4C File Offset: 0x000F114C
	public static string smethod_40(string string_13)
	{
		byte[] array = GClass127.smethod_32(string_13);
		int num = 0;
		byte b = 0;
		byte b2 = 38 - array[array.Length - 1];
		b2 -= 4;
		for (int i = 0; i < array.Length; i++)
		{
			if (i < 13 || b2 != b)
			{
				byte[] array2 = array;
				int num2 = i;
				array2[num2] ^= GClass126.byte_3[num];
				num++;
				if (num < GClass126.byte_0.Length)
				{
					num = 0;
				}
				if (num >= GClass126.byte_3.Length)
				{
					num = 0;
				}
				if (i < 13)
				{
					b2 += array[i];
				}
			}
		}
		return Encoding.ASCII.GetString(array, 0, array.Length - 1);
	}

	// Token: 0x060007DB RID: 2011 RVA: 0x000F2FE4 File Offset: 0x000F11E4
	public static byte[] smethod_41(byte[] byte_2)
	{
		byte[] array = new byte[]
		{
			0,
			0
		};
		byte[] array2 = GClass127.smethod_28(byte_2);
		for (int i = 0; i < array2.Length; i++)
		{
			if (array[0] + array2[i] > 255)
			{
				byte[] array3 = array;
				int num = 1;
				array3[num] += 1;
			}
			byte[] array4 = array;
			int num2 = 0;
			array4[num2] += array2[i];
		}
		byte[] array5 = array;
		int num3 = 1;
		array5[num3] &= 15;
		return array;
	}

	// Token: 0x060007DC RID: 2012 RVA: 0x000F3050 File Offset: 0x000F1250
	public static bool smethod_42()
	{
		try
		{
			string text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			GClass123.smethod_3(GClass127.smethod_4().ToLower());
			string string_ = GClass127.smethod_7(GClass127.smethod_17());
			GClass125.int_18[1] = 0;
			int num = GClass127.smethod_37(GClass127.smethod_13(string_).Replace(".", ""));
			GClass126.int_12 = num;
			if (GClass127.smethod_37(text.Replace(".", "")) < num)
			{
				return true;
			}
		}
		catch (Exception)
		{
			GClass125.int_18[0] = 1;
			GClass126.smethod_2(">Start 00", 0);
			GClass123.bool_13 = GClass126.bool_23;
			return false;
		}
		return false;
	}

	// Token: 0x060007DD RID: 2013 RVA: 0x000F3108 File Offset: 0x000F1308
	public static string smethod_43()
	{
		string text = "";
		try
		{
			text = GClass127.smethod_27("C");
		}
		catch (Exception)
		{
		}
		if (text.Length < 12)
		{
			try
			{
				text = GClass127.smethod_27("D");
			}
			catch (Exception)
			{
			}
		}
		if (text.Length < 12)
		{
			try
			{
				text = GClass127.smethod_25().Trim();
			}
			catch (Exception)
			{
			}
		}
		if (text.Length < 12)
		{
			try
			{
				text = GClass125.smethod_3().Substring(10);
				if (text.Length > 12)
				{
					text = text.Substring(0, 12);
				}
				text = GClass127.smethod_11(Encoding.ASCII.GetBytes(text));
			}
			catch (Exception)
			{
			}
		}
		return text;
	}

	// Token: 0x060007DE RID: 2014 RVA: 0x000F31D8 File Offset: 0x000F13D8
	public static void smethod_44(ref byte[] byte_2)
	{
		List<byte> list = new List<byte>();
		for (int i = 0; i < GClass126.string_13.Length; i++)
		{
			if (GClass126.string_13[i].Length != 8)
			{
				list.AddRange(Encoding.ASCII.GetBytes(GClass126.string_13[i]));
			}
		}
		list.AddRange(Encoding.ASCII.GetBytes(GClass126.string_9));
		GClass127.smethod_34(ref byte_2, list.ToArray());
	}

	// Token: 0x060007DF RID: 2015 RVA: 0x000F3244 File Offset: 0x000F1444
	public static decimal smethod_45(decimal decimal_0, string string_13)
	{
		decimal num = decimal_0;
		if (GClass125.smethod_71() && (string_13 == "km" || string_13 == "km/h"))
		{
			num *= 0.621371192237m;
		}
		if (GClass125.smethod_73() && string_13 == "°c")
		{
			num = num * 1.8m + 32m;
		}
		if (GClass125.smethod_75())
		{
			if (string_13 == "bar")
			{
				num *= 14.5037738m;
			}
			if (string_13 == "mbar")
			{
				num *= 0.0145037738m;
			}
		}
		if (GClass125.smethod_77() && (string_13 == "kg" || string_13 == "kg/h"))
		{
			num *= 2.20462262185m;
		}
		if (GClass125.smethod_79())
		{
			if (string_13 == "mm")
			{
				num *= 0.03937007874m;
			}
			if (string_13 == "m" || string_13 == "m/sec²")
			{
				num *= 3.28084m;
			}
			if (string_13 == "mm³/i")
			{
				num *= 0.000061023744m;
			}
		}
		return num;
	}

	// Token: 0x060007E0 RID: 2016 RVA: 0x000F33C4 File Offset: 0x000F15C4
	public static string smethod_46()
	{
		string text = GClass127.smethod_53("");
		string text2 = text.Replace(" ", "");
		byte[] array = GClass127.smethod_32(text2);
		for (int i = 0; i < array.Length; i++)
		{
			byte[] array2 = array;
			int num = i;
			array2[num] ^= 49;
			text2 += GClass127.smethod_23(array[i]);
			if (i == 5)
			{
				text2 += "-";
			}
			else
			{
				if (i != 9)
				{
					if (i != 14)
					{
						if (i == 14)
						{
							text2 += "-";
							goto IL_81;
						}
						goto IL_81;
					}
				}
				text2 += "-";
			}
			IL_81:;
		}
		GClass126.string_11 = text2.Substring(array.Length + array.Length);
		return text;
	}

	// Token: 0x060007E1 RID: 2017 RVA: 0x000F3470 File Offset: 0x000F1670
	public static string[] smethod_47(string string_13)
	{
		List<string> list = new List<string>();
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < string_13.Length; i++)
		{
			if (string_13[i] == '|')
			{
				list.Add(stringBuilder.ToString().Substring(0, 8) + GClass121.smethod_16(stringBuilder.ToString().Substring(8)));
				stringBuilder = new StringBuilder();
			}
			else
			{
				stringBuilder.Append(string_13[i]);
			}
		}
		if (stringBuilder.Length > 8)
		{
			list.Add(stringBuilder.ToString().Substring(0, 8) + GClass121.smethod_16(stringBuilder.ToString().Substring(8)));
		}
		return list.ToArray();
	}

	// Token: 0x060007E2 RID: 2018 RVA: 0x0000529C File Offset: 0x0000349C
	public static string smethod_48(object object_0)
	{
		return GClass127.smethod_1(object_0, "");
	}

	// Token: 0x060007E3 RID: 2019 RVA: 0x000EF08C File Offset: 0x000ED28C
	public static string smethod_49(Font font_0)
	{
		return string.Concat(new string[]
		{
			font_0.Name,
			" ",
			font_0.Style.ToString(),
			", ",
			font_0.SizeInPoints.ToString("F1"),
			" pt"
		});
	}

	// Token: 0x060007E4 RID: 2020 RVA: 0x000F351C File Offset: 0x000F171C
	public static string smethod_50(string string_13, byte[] byte_2)
	{
		string text = "";
		byte[] array = new byte[21];
		GClass126.smethod_2("LENCe1", 0);
		GClass127.smethod_32("00");
		string text2 = GClass127.smethod_11(byte_2);
		GClass127.byte_1 = 0;
		FileStream fileStream = new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.string_10[7] + ".dat", FileMode.Open, FileAccess.Read);
		long length = fileStream.Length;
		fileStream.Seek(0L, SeekOrigin.Begin);
		while (fileStream.Position < length)
		{
			fileStream.Read(array, 0, array.Length);
			if (GClass127.smethod_8(array) == text2)
			{
				text = text2;
			}
		}
		fileStream.Close();
		text = text.Replace(" ", "");
		text = text.Replace("M", "N");
		GClass126.smethod_2("LENCe2", 0);
		return text.Replace("Z", "T");
	}

	// Token: 0x060007E5 RID: 2021 RVA: 0x000052A9 File Offset: 0x000034A9
	public static string[] smethod_51()
	{
		return GClass127.string_10;
	}

	// Token: 0x060007E6 RID: 2022 RVA: 0x000F3604 File Offset: 0x000F1804
	public static string smethod_52()
	{
		string text = "";
		try
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_PhysicalMedia");
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				if (text == "")
				{
					text = GClass127.smethod_48(managementObject.Properties["SerialNumber"].Value);
				}
			}
			managementObjectCollection.Dispose();
			managementObjectCollection = null;
			managementObjectSearcher.Dispose();
			managementObjectSearcher = null;
			text = text.Trim();
		}
		catch (Exception ex)
		{
			GClass126.smethod_2("ERROR(1):" + ex.Message, 0);
		}
		if (text == "")
		{
			text = "X";
		}
		if (text.Length > 10)
		{
			text = text.Substring(0, 10);
		}
		return GClass127.smethod_11(Encoding.ASCII.GetBytes(text)).Replace(" ", "");
	}

	// Token: 0x060007E7 RID: 2023 RVA: 0x000F3714 File Offset: 0x000F1914
	public static string smethod_53(string string_13)
	{
		string text = string_13;
		try
		{
			text = GClass127.smethod_15("C");
		}
		catch (Exception)
		{
		}
		if (text.Length < 3)
		{
			try
			{
				text = GClass127.smethod_15("D");
			}
			catch (Exception)
			{
			}
		}
		if (text.Length < 3)
		{
			try
			{
				text = GClass127.smethod_52().Trim();
			}
			catch (Exception)
			{
			}
		}
		if (text.Length < 3)
		{
			try
			{
				text = GClass125.smethod_3().Substring(10);
			}
			catch (Exception)
			{
			}
		}
		if (text.Length > 12)
		{
			text = text.Substring(0, 12);
		}
		return GClass127.smethod_11(Encoding.ASCII.GetBytes(text));
	}

	// Token: 0x060007E8 RID: 2024 RVA: 0x000E81F8 File Offset: 0x000E63F8
	public static string[] smethod_54(string string_13)
	{
		List<string> list = new List<string>();
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < string_13.Length; i++)
		{
			if (string_13[i] == '|')
			{
				list.Add(stringBuilder.ToString().Substring(0, 4) + GClass121.smethod_16(stringBuilder.ToString().Substring(4)));
				stringBuilder = new StringBuilder();
			}
			else
			{
				stringBuilder.Append(string_13[i]);
			}
		}
		if (stringBuilder.Length > 4)
		{
			list.Add(stringBuilder.ToString().Substring(0, 4) + GClass121.smethod_16(stringBuilder.ToString().Substring(4)));
		}
		return list.ToArray();
	}

	// Token: 0x060007E9 RID: 2025 RVA: 0x000F37D8 File Offset: 0x000F19D8
	private static string smethod_55(byte[] byte_2)
	{
		int num = 11;
		if (byte_2.Length == 18)
		{
			num = byte_2.Length - 1;
		}
		if (!GClass126.bool_17)
		{
			GClass127.byte_1 = 0;
		}
		for (int i = 0; i < byte_2.Length; i++)
		{
			if (i < num)
			{
				GClass127.byte_1 += byte_2[i];
			}
			else if (GClass127.byte_1 != byte_2[i])
			{
				throw new Exception(GClass127.string_0);
			}
		}
		if (num > 12)
		{
			return GClass127.smethod_11(byte_2).Substring(0, GClass127.int_1);
		}
		return GClass127.smethod_11(byte_2).Substring(0, GClass127.int_0);
	}

	// Token: 0x060007EA RID: 2026 RVA: 0x000F3864 File Offset: 0x000F1A64
	private static string smethod_56(byte[] byte_2)
	{
		if (!GClass126.bool_17)
		{
			GClass127.byte_0 = 0;
		}
		for (int i = 0; i < byte_2.Length; i++)
		{
			if (i < 11)
			{
				GClass127.byte_0 += byte_2[i];
			}
			else if (GClass127.byte_0 != byte_2[i])
			{
				throw new Exception(GClass127.string_0);
			}
		}
		return GClass127.smethod_11(byte_2).Substring(0, GClass127.int_4);
	}

	// Token: 0x060007EB RID: 2027 RVA: 0x000F38CC File Offset: 0x000F1ACC
	public static string smethod_57(string string_13, string string_14)
	{
		string text = "";
		long num = 700L;
		byte[] array = new byte[12];
		int num2 = 1;
		while (num2 < GClass127.string_10.Length && !(GClass127.string_10[num2].ToLower() == string_13.ToLower()))
		{
			num2++;
		}
		GClass126.smethod_2("LENC1", 0);
		num = 180L * num;
		string text2 = GClass127.smethod_11(GClass127.smethod_32(string_14));
		GClass127.byte_0 = 0;
		if (GClass122.smethod_13() != GClass125.smethod_24())
		{
			throw new Exception("Data decode failed!");
		}
		FileStream fileStream = new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.string_10[4] + ".dat", FileMode.Open, FileAccess.Read);
		long length = fileStream.Length;
		byte[] array2 = new byte[length];
		fileStream.Read(array2, 0, (int)length);
		fileStream.Close();
		GClass126.smethod_2("LOAD DATA: Len0" + 5.ToString() + ": " + length.ToString(), 0);
		GClass126.int_9 = (int)(length - num);
		byte[] byte_ = SHA1.Create().ComputeHash(array2);
		int num3 = (int)num;
		while ((long)num3 < length - 11L)
		{
			for (int i = 0; i < 12; i++)
			{
				array[i] = array2[num3++];
			}
			string a = GClass127.smethod_56(array);
			if (a == text2)
			{
				GClass126.int_10 = num3 - (int)num - 12;
				if (GClass125.string_0 == GClass127.smethod_11(byte_))
				{
					GClass123.string_3 = a;
				}
				text = text2;
				GClass125.int_18[4]++;
				GClass126.string_4 = GClass127.smethod_11(array);
			}
		}
		array2 = new byte[1];
		text = text.Replace(" ", "");
		text = text.Replace("V", "J");
		GClass126.smethod_2("LENC2", 0);
		GClass126.bool_10 = (GClass126.bool_10 && !(text == ""));
		return text.Replace("Z", "T");
	}

	// Token: 0x040006C6 RID: 1734
	private static int int_0 = 32;

	// Token: 0x040006C7 RID: 1735
	private static int int_1 = 50;

	// Token: 0x040006C8 RID: 1736
	private static string string_0 = "CS failed";

	// Token: 0x040006C9 RID: 1737
	private static string string_1 = "";

	// Token: 0x040006CA RID: 1738
	private static int int_2 = 59;

	// Token: 0x040006CB RID: 1739
	private static int int_3 = 80;

	// Token: 0x040006CC RID: 1740
	private static string string_2 = "can";

	// Token: 0x040006CD RID: 1741
	private static string string_3 = "CU";

	// Token: 0x040006CE RID: 1742
	private static string string_4 = "e";

	// Token: 0x040006CF RID: 1743
	private static string string_5 = "-";

	// Token: 0x040006D0 RID: 1744
	private static string string_6 = " ";

	// Token: 0x040006D1 RID: 1745
	private static string string_7 = "win32_logicaldisk.deviceid";

	// Token: 0x040006D2 RID: 1746
	private static string string_8 = "VolumeSerialNumber";

	// Token: 0x040006D3 RID: 1747
	public static string string_9 = ".vshost";

	// Token: 0x040006D4 RID: 1748
	private static string[] string_10 = new string[]
	{
		"data03",
		"lang01",
		"data01",
		"lang02",
		"data05",
		"data04",
		"lang03",
		"data06",
		"data02"
	};

	// Token: 0x040006D5 RID: 1749
	private static byte byte_0 = 0;

	// Token: 0x040006D6 RID: 1750
	private static int int_4 = 32;

	// Token: 0x040006D7 RID: 1751
	public static string string_11 = "multiecuscan";

	// Token: 0x040006D8 RID: 1752
	public static string string_12 = ".exe";

	// Token: 0x040006D9 RID: 1753
	private static byte byte_1 = 0;
}
