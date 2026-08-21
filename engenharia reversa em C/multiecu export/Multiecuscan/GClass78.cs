using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x0200003C RID: 60
public sealed class GClass78 : GClass77
{
	// Token: 0x060002B7 RID: 695 RVA: 0x00044B0C File Offset: 0x00042D0C
	private List<byte> method_55()
	{
		int num = 1600;
		List<string> list = new List<string>();
		list.Add(GClass107.smethod_3(182312) + GClass127.smethod_23(this.byte_0) + GClass107.smethod_3(182335));
		list.Add(GClass107.smethod_3(182375));
		list.Add(GClass107.smethod_3(182393));
		list.Add(GClass107.smethod_3(182426));
		list.Add(GClass107.smethod_3(182427));
		list.Add(GClass107.smethod_3(182438));
		list.Add(GClass107.smethod_3(182448));
		list.Add(GClass107.smethod_3(182477));
		list.Add(GClass107.smethod_3(182497));
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
				if (gclass.byte_0.Length == 1 && gclass.byte_0[0].Length > 4)
				{
					byte[] array = new byte[gclass.byte_0[0].Length - 1];
					for (int i = 1; i < gclass.byte_0[0].Length; i++)
					{
						array[i - 1] = gclass.byte_0[0][i];
					}
					string text = GClass127.smethod_11(array).Replace(" ", "") + "1";
					list.Add(text);
					num -= text.Length + 1;
					gclass.byte_0 = new byte[][]
					{
						new byte[]
						{
							4,
							byte.MaxValue,
							byte.MaxValue,
							byte.MaxValue,
							0
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
				if (gclass2.byte_0.Length == 1 && gclass2.byte_0[0].Length > 2)
				{
					byte[] array2 = new byte[gclass2.byte_0[0].Length - 1];
					for (int j = 1; j < gclass2.byte_0[0].Length; j++)
					{
						array2[j - 1] = gclass2.byte_0[0][j];
					}
					string text2 = GClass127.smethod_11(array2).Replace(" ", "") + "1";
					list.Add(text2);
					num -= text2.Length + 1;
					gclass2.byte_0 = new byte[][]
					{
						new byte[]
						{
							4,
							byte.MaxValue,
							byte.MaxValue,
							byte.MaxValue,
							0
						}
					};
				}
			}
		}
		GClass126.smethod_2(GClass107.smethod_3(182506) + num.ToString(), 0);
		return GClass96.smethod_16(list);
	}

	// Token: 0x060002B8 RID: 696 RVA: 0x00044E3C File Offset: 0x0004303C
	protected override void r6()
	{
		List<byte> list_ = this.method_55();
		try
		{
			base.method_42();
			if (this.serialPort_0 != null)
			{
				if (GClass125.smethod_46())
				{
					this.serialPort_0.ReadTimeout = 3000;
				}
				else
				{
					this.serialPort_0.ReadTimeout = 3000;
				}
			}
			string text = "OK";
			if (!base.method_22(list_).Contains("OK"))
			{
				throw new Exception(GClass107.smethod_3(182522));
			}
			this.ra(GClass107.smethod_3(182566));
			if (!(this.string_3 == "70") && !(this.string_3 == ""))
			{
				if (this.string_3 == "10")
				{
					text = this.ra(GClass107.smethod_3(182581));
				}
				else if (this.string_3 == "30")
				{
					text = this.ra(GClass107.smethod_3(182620));
				}
				else if (this.string_3 == "90")
				{
					text = this.ra(GClass107.smethod_3(182665));
				}
				else if (this.string_3 == "C0")
				{
					text = this.ra(GClass107.smethod_3(182707));
				}
				else
				{
					text = this.ra(GClass107.smethod_3(182730) + this.string_3);
				}
			}
			string text2 = this.ra(GClass107.smethod_3(182742));
			Thread.Sleep(100);
			string text3 = this.ra(GClass107.smethod_3(182746));
			if (this.genum0_0 == (GEnum0)0 && !text3.Contains(GClass107.smethod_3(182778)) && this.string_3 != "70" && this.string_3 != "")
			{
				Thread.Sleep(200);
				text = this.ra(GClass107.smethod_3(182823));
				Thread.Sleep(100);
				text3 = this.ra(GClass107.smethod_3(182871));
			}
			if (this.genum0_0 == (GEnum0)0 && !text3.Contains(GClass107.smethod_3(182907)) && this.string_3 != "70" && this.string_3 != "30" && this.string_3 != "")
			{
				Thread.Sleep(200);
				text = this.ra(GClass107.smethod_3(182919));
				Thread.Sleep(100);
				text3 = this.ra(GClass107.smethod_3(182923));
			}
			if (!text3.Contains(GClass107.smethod_3(182931)) || !text.Contains("OK") || !text2.Contains("ms"))
			{
				throw new Exception(GClass107.smethod_3(182968));
			}
			string text4 = this.ra(GClass107.smethod_3(183014));
			this.string_7 = text4.Replace("1:", "").Replace("2:", "").Replace("3:", "").Replace("4:", "").Replace("C:", "").Replace(">", "").Replace("\r", "").Replace("\n", "");
			try
			{
				this.string_7 = GClass127.smethod_11(GClass127.smethod_32(this.string_7));
			}
			catch (Exception)
			{
			}
			GClass126.smethod_2(GClass107.smethod_3(183030) + this.string_7, 0);
			if (this.string_0 != GClass107.smethod_3(183053))
			{
				Thread.Sleep(100);
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			throw new Exception("0");
		}
		GClass126.smethod_2(GClass107.smethod_3(183089), 1);
	}
}
