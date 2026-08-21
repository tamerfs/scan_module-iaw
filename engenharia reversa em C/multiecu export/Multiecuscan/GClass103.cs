using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

// Token: 0x02000081 RID: 129
public class GClass103
{
	// Token: 0x06000413 RID: 1043 RVA: 0x00098F34 File Offset: 0x00097134
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

	// Token: 0x06000414 RID: 1044 RVA: 0x00003595 File Offset: 0x00001795
	public static byte[] smethod_0(byte[] byte_0)
	{
		return GClass103.smethod_1(byte_0, false);
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x000990D8 File Offset: 0x000972D8
	public static byte[] smethod_1(byte[] byte_0, bool bool_0)
	{
		List<byte> list = new List<byte>();
		byte[] array = new byte[2];
		byte b = (byte)GClass103.int_3[1];
		for (int i = 0; i < byte_0.Length - 1; i++)
		{
			b += byte_0[i];
		}
		if (b != byte_0[byte_0.Length - 1])
		{
			throw new Exception("Data file error2!");
		}
		if (bool_0)
		{
			return null;
		}
		byte b2 = byte_0[byte_0.Length - 2];
		int j = 0;
		int num = 0;
		while (j < byte_0.Length - 2)
		{
			if (GClass103.int_0[num] > GClass103.int_0[13])
			{
				int num2 = j;
				byte_0[num2] ^= (byte)GClass103.int_3[num];
				int num3 = j + 2;
				byte_0[num3] ^= (byte)GClass103.int_3[num + 1];
				int num4 = j + 2;
				byte_0[num4] ^= byte_0[j + 1];
				array[1] = byte_0[j];
				array[0] = byte_0[j + 2];
			}
			else
			{
				int num5 = j + 1;
				byte_0[num5] ^= (byte)GClass103.int_3[num];
				int num6 = j + 2;
				byte_0[num6] ^= (byte)GClass103.int_3[num + 1];
				int num7 = j + 2;
				byte_0[num7] ^= byte_0[j + 1];
				array[1] = byte_0[j + 1];
				array[0] = byte_0[j + 2];
			}
			if (GClass103.int_5[num] > GClass103.int_5[13])
			{
				j++;
			}
			j += 3;
			num += 2;
			if (num >= GClass103.int_3.Length)
			{
				num = 0;
			}
			list.Insert(0, array[1]);
			list.Insert(0, array[0]);
		}
		b2 = (byte)GClass103.int_3[0];
		for (int k = 0; k < list.Count; k++)
		{
			b2 += list[k];
		}
		if (b2 != byte_0[byte_0.Length - 2])
		{
			throw new Exception("Data file error1!");
		}
		return list.ToArray();
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x000992A0 File Offset: 0x000974A0
	public static string smethod_2(string string_3)
	{
		string text = "";
		int num = 0;
		int num2 = 0;
		int num3 = 4;
		for (int i = 1; i < GClass103.int_3.Length; i++)
		{
			if (GClass103.int_3[i].ToString() == GClass103.int_5.ToString())
			{
				num = i;
				IL_49:
				int num4 = 0;
				while (num4 < GClass127.smethod_51().Length && num > 18)
				{
					if (GClass127.smethod_51()[num4].StartsWith("lang"))
					{
						num2++;
					}
					else
					{
						new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.smethod_51()[num4] + ".dat", FileMode.Open, FileAccess.Read).Close();
					}
					num4++;
				}
				FileStream fileStream = new FileStream(string.Concat(new string[]
				{
					GClass125.smethod_30(),
					GClass103.string_0,
					GClass103.string_2,
					num3.ToString(),
					GClass103.string_1
				}), FileMode.Open, FileAccess.Read);
				int num5 = 0;
				byte[] array = new byte[4];
				while (fileStream.Position < fileStream.Length)
				{
					fileStream.Read(array, 0, array.Length);
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
					fileStream.Read(array5, 0, array5.Length);
					array5 = GClass103.smethod_0(array5);
					text = GClass127.smethod_11(array5).Replace(" ", "");
					if (text.StartsWith(string_3))
					{
						break;
					}
				}
				fileStream.Close();
				return text;
			}
		}
		goto IL_49;
	}

	// Token: 0x040002C1 RID: 705
	public DataTable dataTable_0;

	// Token: 0x040002C2 RID: 706
	private static int[] int_0 = new int[]
	{
		7,
		9,
		6,
		7,
		3,
		4,
		8,
		2,
		2,
		1,
		7,
		3,
		1,
		6
	};

	// Token: 0x040002C3 RID: 707
	private static int[] int_1 = new int[]
	{
		7,
		4,
		6,
		7,
		8,
		4,
		8,
		7,
		2,
		1,
		8,
		3,
		1,
		4
	};

	// Token: 0x040002C4 RID: 708
	private static int[] int_2 = new int[]
	{
		122,
		142,
		13,
		90,
		21,
		211,
		159,
		231,
		127,
		168,
		189,
		11,
		13,
		14
	};

	// Token: 0x040002C5 RID: 709
	private static int[] int_3 = new int[]
	{
		12,
		23,
		213,
		245,
		221,
		46,
		59,
		31,
		167,
		68,
		168,
		115,
		46,
		14
	};

	// Token: 0x040002C6 RID: 710
	private static int[] int_4 = new int[]
	{
		11,
		221,
		144,
		96,
		185,
		19,
		12,
		149,
		239,
		231,
		45,
		21,
		18,
		173
	};

	// Token: 0x040002C7 RID: 711
	private static int[] int_5 = new int[]
	{
		24,
		121,
		44,
		60,
		12,
		119,
		121,
		49,
		11,
		178,
		145,
		211,
		118,
		5
	};

	// Token: 0x040002C8 RID: 712
	private static string string_0 = "\\Files\\";

	// Token: 0x040002C9 RID: 713
	private static string string_1 = ".dat";

	// Token: 0x040002CA RID: 714
	private static string string_2 = "data0";
}
