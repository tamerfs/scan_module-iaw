using System;
using System.Collections.Generic;

// Token: 0x02000032 RID: 50
public sealed class GClass58 : GClass57
{
	// Token: 0x0600029C RID: 668 RVA: 0x00040D24 File Offset: 0x0003EF24
	private List<byte> method_57()
	{
		int num = 1600;
		List<string> list = new List<string>();
		list.Add(string.Concat(new string[]
		{
			GClass107.smethod_3(170378),
			this.string_2.Substring(3, 3),
			GClass107.smethod_3(170389),
			this.string_2.Substring(0, 3),
			GClass107.smethod_3(170424),
			this.string_2.Substring(0, 3),
			GClass107.smethod_3(170458)
		}));
		list.Add(GClass127.smethod_11(this.byte_4).Substring(3).Replace(" ", ""));
		list.Add(GClass107.smethod_3(170479));
		list.Add(GClass107.smethod_3(170522));
		list.Add(GClass107.smethod_3(170565));
		list.Add(GClass107.smethod_3(170583));
		list.Add(GClass107.smethod_3(170586));
		list.Add(GClass107.smethod_3(170602));
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
		GClass126.smethod_2(GClass107.smethod_3(170604) + num.ToString(), 0);
		return GClass96.smethod_16(list);
	}

	// Token: 0x0600029D RID: 669 RVA: 0x00041064 File Offset: 0x0003F264
	protected override void r6()
	{
		List<byte> list_ = this.method_57();
		try
		{
			base.method_42();
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 3500;
			}
			this.ra(GClass107.smethod_3(170626));
			this.ra(GClass107.smethod_3(170634));
			this.ra(GClass107.smethod_3(170654));
			this.ra(GClass107.smethod_3(170656));
			this.r9("ATZ");
			this.rb();
			if (this.serialPort_0 != null)
			{
				if (GClass125.smethod_46())
				{
					this.serialPort_0.ReadTimeout = 2000;
				}
				else
				{
					this.serialPort_0.ReadTimeout = 1800;
				}
			}
			if (!base.method_22(list_).Contains("OK"))
			{
				throw new Exception(GClass107.smethod_3(170695));
			}
			this.ra(GClass107.smethod_3(170713));
			string text = this.ra(GClass107.smethod_3(170749));
			string text2 = this.ra(GClass107.smethod_3(170780));
			byte[] array = base.method_54(GClass127.smethod_32(GClass107.smethod_3(170803)));
			if (array.Length < 3 || array[1] != 80 || array[2] != 146 || !text.Contains("OK") || !text2.Contains("ms"))
			{
				throw new Exception(GClass107.smethod_3(170827));
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_8 = ex.Message;
			throw new Exception("0");
		}
		GClass126.smethod_2(GClass107.smethod_3(170837), 1);
	}
}
