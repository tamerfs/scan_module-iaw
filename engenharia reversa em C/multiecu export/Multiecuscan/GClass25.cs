using System;
using System.Collections.Generic;

// Token: 0x02000030 RID: 48
public sealed class GClass25 : GClass23
{
	// Token: 0x06000296 RID: 662 RVA: 0x00040274 File Offset: 0x0003E474
	private List<byte> method_64()
	{
		int num = 1600;
		List<string> list = new List<string>();
		list.Add(string.Concat(new string[]
		{
			GClass107.smethod_3(167271),
			this.string_2,
			GClass127.smethod_23(this.byte_0),
			GClass107.smethod_3(167319),
			GClass127.smethod_23(this.byte_0),
			this.string_2,
			GClass107.smethod_3(167341)
		}));
		list.Add(GClass127.smethod_11(this.byte_4).Substring(3).Replace(" ", ""));
		list.Add(GClass107.smethod_3(167361));
		list.Add(GClass107.smethod_3(167380));
		list.Add(GClass107.smethod_3(167422));
		list.Add(GClass107.smethod_3(167461));
		list.Add(GClass107.smethod_3(167497));
		list.Add(GClass107.smethod_3(167543));
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
		GClass126.smethod_2(GClass107.smethod_3(167580) + num.ToString(), 0);
		return GClass96.smethod_16(list);
	}

	// Token: 0x06000297 RID: 663 RVA: 0x000405A8 File Offset: 0x0003E7A8
	protected override void r6()
	{
		List<byte> list_ = this.method_64();
		try
		{
			base.method_42();
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 3500;
			}
			this.ra(GClass107.smethod_3(167623));
			this.ra(GClass107.smethod_3(167665));
			this.ra(GClass107.smethod_3(167682));
			this.ra(GClass107.smethod_3(167715));
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
				throw new Exception(GClass107.smethod_3(167723));
			}
			this.ra(GClass107.smethod_3(167732));
			if (this.string_2 == "F4")
			{
				this.ra(GClass107.smethod_3(167737));
				this.ra(GClass107.smethod_3(167748) + GClass127.smethod_23(this.byte_0) + this.string_2);
				this.ra(GClass107.smethod_3(167776));
				this.ra(GClass107.smethod_3(167777));
			}
			else
			{
				this.ra(GClass107.smethod_3(167779));
			}
			string text = this.ra(GClass107.smethod_3(167824));
			string text2 = this.ra(GClass107.smethod_3(167838));
			byte[] array = base.method_51(GClass127.smethod_32(GClass107.smethod_3(167840)));
			if (array.Length == 0 && this.string_2 != "F4")
			{
				this.ra(GClass107.smethod_3(167893));
				array = base.method_51(GClass127.smethod_32(GClass107.smethod_3(167918)));
			}
			if (array.Length < 3 || array[1] != 80 || array[2] != 3 || !text.Contains("OK") || !text2.Contains("ms"))
			{
				throw new Exception(GClass107.smethod_3(167955));
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_8 = ex.Message;
			throw new Exception("0");
		}
		GClass126.smethod_2(GClass107.smethod_3(167976), 1);
	}
}
