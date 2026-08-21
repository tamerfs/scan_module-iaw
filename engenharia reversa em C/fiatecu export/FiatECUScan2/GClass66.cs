using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

// Token: 0x02000084 RID: 132
public sealed class GClass66
{
	// Token: 0x060004D4 RID: 1236 RVA: 0x0008F0A0 File Offset: 0x0008D2A0
	private void method_0()
	{
		this.dataTable_0 = new DataTable();
		this.dataTable_0.Columns.Add("CmdType", typeof(int));
		this.dataTable_0.Columns.Add("ModuleID", typeof(string));
		this.dataTable_0.Columns.Add("Commands", typeof(string));
		this.dataTable_0.Columns.Add("StartByte", typeof(int));
		this.dataTable_0.Columns.Add("NumOfBytes", typeof(int));
		this.dataTable_0.Columns.Add("ParamName", typeof(string));
		this.dataTable_0.Columns.Add("ResultFormat", typeof(string));
		this.dataTable_0.Columns.Add("Units", typeof(string));
		this.dataTable_0.Columns.Add("MsgExec", typeof(string));
		this.dataTable_0.Columns.Add("BitResults", typeof(string));
		this.dataTable_0.Columns.Add("Description", typeof(string));
		this.dataTable_0.Columns.Add("MessageID", typeof(int));
	}

	// Token: 0x060004D5 RID: 1237 RVA: 0x0008F238 File Offset: 0x0008D438
	public static byte[] smethod_0(byte[] byte_0)
	{
		return GClass66.smethod_1(byte_0, false);
	}

	// Token: 0x060004D6 RID: 1238 RVA: 0x0008F250 File Offset: 0x0008D450
	public static byte[] smethod_1(byte[] byte_0, bool bool_0)
	{
		List<byte> list = new List<byte>();
		byte[] array = new byte[2];
		byte b = (byte)GClass66.int_4[1];
		for (int i = 0; i < byte_0.Length - 1; i++)
		{
			b += byte_0[i];
		}
		if (b != byte_0[byte_0.Length - 1])
		{
			throw new Exception("Data file error2!");
		}
		byte[] result;
		if (bool_0)
		{
			result = null;
		}
		else
		{
			byte b2 = byte_0[byte_0.Length - 2];
			int j = 0;
			int num = 0;
			while (j < byte_0.Length - 2)
			{
				if (GClass66.int_3[num] > GClass66.int_3[13])
				{
					int num2 = j;
					byte_0[num2] ^= (byte)GClass66.int_4[num];
					int num3 = j + 2;
					byte_0[num3] ^= (byte)GClass66.int_4[num + 1];
					int num4 = j + 2;
					byte_0[num4] ^= byte_0[j + 1];
					array[1] = byte_0[j];
					array[0] = byte_0[j + 2];
				}
				else
				{
					int num5 = j + 1;
					byte_0[num5] ^= (byte)GClass66.int_4[num];
					int num6 = j + 2;
					byte_0[num6] ^= (byte)GClass66.int_4[num + 1];
					int num7 = j + 2;
					byte_0[num7] ^= byte_0[j + 1];
					array[1] = byte_0[j + 1];
					array[0] = byte_0[j + 2];
				}
				if (GClass66.int_5[num] > GClass66.int_5[13])
				{
					j++;
				}
				j += 3;
				num += 2;
				if (num >= GClass66.int_4.Length)
				{
					num = 0;
				}
				list.Insert(0, array[1]);
				list.Insert(0, array[0]);
			}
			b2 = (byte)GClass66.int_4[0];
			for (int i = 0; i < list.Count; i++)
			{
				b2 += list[i];
			}
			if (b2 != byte_0[byte_0.Length - 2])
			{
				throw new Exception("Data file error1!");
			}
			result = list.ToArray();
		}
		return result;
	}

	// Token: 0x060004D7 RID: 1239 RVA: 0x0008F464 File Offset: 0x0008D664
	public static string smethod_2(string string_3)
	{
		string text = string.Empty;
		int num = 0;
		int num2 = 0;
		int num3 = 4;
		for (int i = 1; i < GClass66.int_4.Length; i++)
		{
			if (GClass66.int_4[i].ToString() == GClass66.int_5.ToString())
			{
				num = i;
				IL_4E:
				int num4 = 0;
				while (num4 < GClass16.smethod_10().Length && num > 18)
				{
					if (GClass16.smethod_10()[num4].StartsWith("lang"))
					{
						num2++;
					}
					else
					{
						FileStream fileStream = new FileStream(GClass61.smethod_22() + "\\Files\\" + GClass16.smethod_10()[num4] + ".dat", FileMode.Open, FileAccess.Read);
						fileStream.Close();
					}
					num4++;
				}
				FileStream fileStream2 = new FileStream(string.Concat(new object[]
				{
					GClass61.smethod_22(),
					GClass66.string_0,
					GClass66.string_2,
					num3,
					GClass66.string_1
				}), FileMode.Open, FileAccess.Read);
				int num5 = 0;
				byte[] array = new byte[4];
				while (fileStream2.Position < fileStream2.Length)
				{
					fileStream2.Read(array, 0, array.Length);
					byte[] array2 = array;
					int num6 = 1;
					array2[num6] ^= array[2];
					byte[] array3 = array;
					int num7 = 3;
					array3[num7] ^= array[1];
					byte[] array4 = array;
					int num8 = 3;
					array4[num8] ^= array[0];
					int num9 = (int)array[1] + 256 * (int)array[3];
					if (num5 > 1000)
					{
						break;
					}
					num5++;
					byte[] array5 = new byte[num9];
					fileStream2.Read(array5, 0, array5.Length);
					array5 = GClass66.smethod_0(array5);
					text = GClass16.smethod_1(array5).Replace(" ", string.Empty);
					if (text.StartsWith(string_3))
					{
						break;
					}
				}
				fileStream2.Close();
				return text;
			}
		}
		goto IL_4E;
	}

	// Token: 0x04000648 RID: 1608
	public DataTable dataTable_0;

	// Token: 0x04000649 RID: 1609
	private static int[] int_0 = new int[]
	{
		7,
		2,
		5,
		1,
		4,
		8,
		2,
		5,
		2,
		9,
		8,
		3,
		3,
		5
	};

	// Token: 0x0400064A RID: 1610
	private static int[] int_1 = new int[]
	{
		71,
		18,
		23,
		183,
		202,
		5,
		156,
		36,
		177,
		78,
		154,
		99,
		165,
		157
	};

	// Token: 0x0400064B RID: 1611
	private static int[] int_2 = new int[]
	{
		22,
		111,
		124,
		160,
		4,
		156,
		34,
		67,
		98,
		77,
		45,
		101,
		167,
		106
	};

	// Token: 0x0400064C RID: 1612
	private static int[] int_3 = new int[]
	{
		7,
		3,
		6,
		6,
		8,
		4,
		8,
		5,
		2,
		2,
		4,
		3,
		5,
		4
	};

	// Token: 0x0400064D RID: 1613
	private static int[] int_4 = new int[]
	{
		12,
		23,
		213,
		190,
		221,
		111,
		59,
		31,
		167,
		68,
		89,
		115,
		153,
		14
	};

	// Token: 0x0400064E RID: 1614
	private static int[] int_5 = new int[]
	{
		115,
		121,
		44,
		60,
		85,
		119,
		121,
		49,
		139,
		31,
		145,
		211,
		118,
		73
	};

	// Token: 0x0400064F RID: 1615
	private static string string_0 = "\\Files\\";

	// Token: 0x04000650 RID: 1616
	private static string string_1 = ".dat";

	// Token: 0x04000651 RID: 1617
	private static string string_2 = "data0";
}
