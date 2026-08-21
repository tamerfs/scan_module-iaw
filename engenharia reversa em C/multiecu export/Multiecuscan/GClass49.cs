using System;
using System.Collections.Generic;

// Token: 0x02000035 RID: 53
public sealed class GClass49 : GClass47
{
	// Token: 0x060002A3 RID: 675 RVA: 0x00042184 File Offset: 0x00040384
	private List<byte> method_57()
	{
		int num = 1600;
		List<string> list = new List<string>();
		list.Add(string.Concat(new string[]
		{
			GClass107.smethod_3(172033),
			this.string_2.Substring(3, 3),
			GClass107.smethod_3(172079),
			this.string_2.Substring(0, 3),
			GClass107.smethod_3(172108),
			this.string_2.Substring(0, 3),
			GClass107.smethod_3(172150)
		}));
		list.Add(GClass127.smethod_11(this.byte_4).Substring(3).Replace(" ", ""));
		list.Add(GClass107.smethod_3(172164));
		list.Add(GClass107.smethod_3(172196));
		list.Add(GClass107.smethod_3(172222));
		list.Add(GClass107.smethod_3(172227));
		list.Add(GClass107.smethod_3(172263));
		list.Add(GClass107.smethod_3(172271));
		if (this.genum0_0 == (GEnum0)0)
		{
			foreach (GClass104 gclass in this.list_1)
			{
				if (list.Count > 100)
				{
					break;
				}
				if (num < 80)
				{
					break;
				}
				if (gclass.byte_0.Length == 1)
				{
					string text = GClass127.smethod_11(gclass.byte_0[0]);
					if (text.Length > 4)
					{
						text = text.Substring(3).Replace(" ", "");
					}
					int num2;
					if (list.Contains(text))
					{
						num2 = list.IndexOf(text);
					}
					else
					{
						list.Add(text);
						num2 = (int)((byte)(list.Count - 1));
						num -= text.Length + 1;
					}
					gclass.byte_0 = new byte[][]
					{
						new byte[]
						{
							2,
							byte.MaxValue,
							(byte)num2
						}
					};
				}
			}
			foreach (GClass104 gclass2 in this.list_0)
			{
				if (list.Count > 250)
				{
					break;
				}
				if (num < 10)
				{
					break;
				}
				if (gclass2.byte_0.Length == 1)
				{
					string text2 = GClass127.smethod_11(gclass2.byte_0[0]);
					if (text2.Length > 4)
					{
						text2 = text2.Substring(3).Replace(" ", "");
					}
					int num3;
					if (list.Contains(text2))
					{
						num3 = list.IndexOf(text2);
					}
					else
					{
						list.Add(text2);
						num3 = (int)((byte)(list.Count - 1));
						num -= text2.Length + 1;
					}
					gclass2.byte_0 = new byte[][]
					{
						new byte[]
						{
							2,
							byte.MaxValue,
							(byte)num3
						}
					};
				}
			}
		}
		GClass126.smethod_2(GClass107.smethod_3(172282) + num.ToString(), 0);
		return GClass96.smethod_16(list);
	}

	// Token: 0x060002A4 RID: 676 RVA: 0x000424C4 File Offset: 0x000406C4
	protected override void r6()
	{
		List<byte> list_ = this.method_57();
		try
		{
			base.method_42();
			if (!base.method_22(list_).Contains("OK"))
			{
				throw new Exception(GClass107.smethod_3(172322));
			}
			this.ra(GClass107.smethod_3(172326));
			string text = this.ra(GClass107.smethod_3(172335));
			string text2 = this.ra(GClass107.smethod_3(172340));
			byte[] array = base.method_54(GClass127.smethod_32(GClass107.smethod_3(172342)));
			if (array.Length > 3 && array[1] == 127 && array[3] == 18)
			{
				array = base.method_54(GClass127.smethod_32("021092"));
			}
			if (array.Length > 3 && array[1] == 127 && array[3] == 18)
			{
				array = base.method_54(GClass127.smethod_32(GClass107.smethod_3(172372)));
			}
			if (array.Length < 3 || array[1] != 80 || !text.Contains("OK") || !text2.Contains("ms"))
			{
				throw new Exception(GClass107.smethod_3(172416));
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_8 = ex.Message;
			throw new Exception("0");
		}
		GClass126.smethod_2(GClass107.smethod_3(172452), 1);
	}
}
