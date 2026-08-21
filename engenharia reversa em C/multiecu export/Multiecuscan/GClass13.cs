using System;
using System.Collections.Generic;

// Token: 0x0200002F RID: 47
public sealed class GClass13 : GClass12
{
	// Token: 0x06000294 RID: 660 RVA: 0x0003FCC4 File Offset: 0x0003DEC4
	private List<byte> method_56()
	{
		int num = 1600;
		string str = GClass127.smethod_23(this.byte_0);
		string value = "1A";
		string value2 = "21";
		List<string> list = new List<string>();
		list.Add(GClass107.smethod_3(165538) + this.string_2 + GClass107.smethod_3(165566));
		list.Add(str + GClass127.smethod_11(this.byte_4).Replace(" ", ""));
		list.Add(GClass107.smethod_3(165590));
		list.Add(GClass107.smethod_3(165627));
		list.Add(GClass107.smethod_3(165671));
		list.Add(GClass107.smethod_3(165714));
		list.Add(GClass107.smethod_3(165721));
		list.Add("3E1");
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
					if (!(text == ""))
					{
						string text2 = text.Substring(3);
						if (text.Length > 4)
						{
							text = str + text.Replace(" ", "");
						}
						if (text2.StartsWith(value) || text2.StartsWith(value2))
						{
							text += "1";
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
								byte.MaxValue,
								(byte)num2
							}
						};
					}
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
					string text3 = GClass127.smethod_11(gclass2.byte_0[0]);
					if (!(text3 == ""))
					{
						string text4 = text3.Substring(3);
						if (text3.Length > 4)
						{
							text3 = str + text3.Replace(" ", "");
						}
						if (text4.StartsWith(value) || text4.StartsWith(value2))
						{
							text3 += "1";
						}
						int num3;
						if (list.Contains(text3))
						{
							num3 = list.IndexOf(text3);
						}
						else
						{
							list.Add(text3);
							num3 = (int)((byte)(list.Count - 1));
							num -= text3.Length + 1;
						}
						gclass2.byte_0 = new byte[][]
						{
							new byte[]
							{
								byte.MaxValue,
								(byte)num3
							}
						};
					}
				}
			}
		}
		GClass126.smethod_2(GClass107.smethod_3(165767) + num.ToString(), 0);
		return GClass96.smethod_16(list);
	}

	// Token: 0x06000295 RID: 661 RVA: 0x0004006C File Offset: 0x0003E26C
	protected override void r6()
	{
		List<byte> list_ = this.method_56();
		try
		{
			base.method_42();
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 3500;
			}
			this.ra(GClass107.smethod_3(165797));
			this.ra(GClass107.smethod_3(165811));
			this.ra(GClass107.smethod_3(165824));
			this.ra(GClass107.smethod_3(165828));
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
			string text = "OK";
			if (!base.method_22(list_).Contains("OK"))
			{
				throw new Exception(GClass107.smethod_3(165844));
			}
			this.ra(GClass107.smethod_3(165870));
			if (this.string_3 == "19")
			{
				this.ra(GClass107.smethod_3(165898));
			}
			else
			{
				text = this.ra(GClass107.smethod_3(165924));
			}
			string text2 = this.ra(GClass107.smethod_3(165942));
			this.string_22 = GClass107.smethod_3(165966);
			this.ra(GClass107.smethod_3(165980));
			byte[] array = base.method_46(GClass127.smethod_32(GClass107.smethod_3(165998)));
			if (array.Length < 3 || array[1] != 80 || array[2] != 129 || !text.Contains("OK") || !text2.Contains("ms"))
			{
				throw new Exception(GClass107.smethod_3(166002));
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_8 = ex.Message;
			throw new Exception("0");
		}
		GClass126.smethod_2(GClass107.smethod_3(166034), 1);
	}
}
