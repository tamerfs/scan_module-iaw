using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x02000038 RID: 56
public sealed class GClass26 : GClass23
{
	// Token: 0x060002AB RID: 683 RVA: 0x00042C94 File Offset: 0x00040E94
	private List<byte> method_64()
	{
		int num = 1600;
		List<string> list = new List<string>();
		list.Add(string.Concat(new string[]
		{
			GClass107.smethod_3(174759),
			this.string_2,
			GClass127.smethod_23(this.byte_0),
			GClass107.smethod_3(174785),
			GClass127.smethod_23(this.byte_0),
			this.string_2,
			GClass107.smethod_3(174796)
		}));
		list.Add(GClass127.smethod_11(this.byte_4).Substring(3).Replace(" ", ""));
		list.Add(GClass107.smethod_3(174811));
		list.Add(GClass107.smethod_3(174826));
		list.Add(GClass107.smethod_3(174872));
		list.Add(GClass107.smethod_3(174902));
		list.Add(GClass107.smethod_3(174950));
		list.Add(GClass107.smethod_3(174980));
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
		GClass126.smethod_2(GClass107.smethod_3(174994) + num.ToString(), 0);
		return GClass96.smethod_16(list);
	}

	// Token: 0x060002AC RID: 684 RVA: 0x00042FC8 File Offset: 0x000411C8
	protected override void r6()
	{
		List<byte> list_ = this.method_64();
		try
		{
			base.method_42();
			if (!base.method_22(list_).Contains("OK"))
			{
				throw new Exception(GClass107.smethod_3(175029));
			}
			this.ra(GClass107.smethod_3(175031));
			if (this.string_2 == "F4")
			{
				this.ra(GClass107.smethod_3(175060));
				this.ra(GClass107.smethod_3(175098) + GClass127.smethod_23(this.byte_0) + this.string_2);
				this.ra(GClass107.smethod_3(175120));
				this.ra(GClass107.smethod_3(175134));
			}
			string text;
			if (this.string_3 == "CD")
			{
				text = this.ra(GClass107.smethod_3(175148));
			}
			else
			{
				text = this.ra(GClass107.smethod_3(175151));
			}
			string text2 = this.ra(GClass107.smethod_3(175165));
			byte[] array = base.method_51(GClass127.smethod_32(GClass107.smethod_3(175193)));
			if (array.Length > 3 && array[1] == 127 && array[3] == 18)
			{
				array = base.method_51(GClass127.smethod_32("021092"));
			}
			if (array.Length == 0 && this.string_8 == GClass107.smethod_3(175198) && this.genum0_0 == (GEnum0)0)
			{
				string string_ = string.Format(GClass121.smethod_6("1048"), GClass107.smethod_3(175226));
				base.method_38(false, string_, GClass121.smethod_6("1059"));
				int num = 600;
				while (num > 0 && !GClass126.bool_24)
				{
					Thread.Sleep(100);
				}
				text = this.ra(GClass107.smethod_3(175260));
				array = base.method_51(GClass127.smethod_32(GClass107.smethod_3(175286)));
			}
			else if (array.Length == 0 && this.string_8 == GClass107.smethod_3(175295) && this.genum0_0 == (GEnum0)3)
			{
				this.string_9 = this.string_8;
			}
			else if (array.Length == 0 && this.string_2 != "F4")
			{
				this.ra(GClass107.smethod_3(175329));
				array = base.method_51(GClass127.smethod_32(GClass107.smethod_3(175348)));
				if (array.Length > 3 && array[1] == 127 && array[3] == 18)
				{
					array = base.method_51(GClass127.smethod_32("021092"));
				}
			}
			if (array.Length < 3 || array[1] != 80 || !text.Contains("OK") || !text2.Contains("ms"))
			{
				throw new Exception(GClass107.smethod_3(175365));
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_8 = ex.Message;
			throw new Exception("0");
		}
		GClass126.smethod_2(GClass107.smethod_3(175369), 1);
	}
}
