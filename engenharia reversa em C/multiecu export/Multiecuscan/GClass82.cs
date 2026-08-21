using System;
using System.Collections.Generic;

// Token: 0x0200003D RID: 61
public sealed class GClass82 : GClass81
{
	// Token: 0x060002BA RID: 698 RVA: 0x00045244 File Offset: 0x00043444
	private List<byte> method_56()
	{
		int num = 1600;
		string value = "1A";
		string value2 = "21";
		List<string> list = new List<string>();
		list.Add(GClass107.smethod_3(184243) + GClass127.smethod_23(this.byte_0) + "F1");
		list.Add(GClass107.smethod_3(184248));
		list.Add(GClass107.smethod_3(184289));
		list.Add(GClass107.smethod_3(184326));
		list.Add(GClass107.smethod_3(184337));
		list.Add(GClass107.smethod_3(184373));
		list.Add(GClass107.smethod_3(184402));
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
					if (text.Length > 4)
					{
						text = text.Substring(3).Replace(" ", "");
					}
					if (text.StartsWith(value) || text.StartsWith(value2))
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
					if (text2.StartsWith(value) || text2.StartsWith(value2))
					{
						text2 += "1";
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
							byte.MaxValue,
							(byte)num3
						}
					};
				}
			}
		}
		GClass126.smethod_2(GClass107.smethod_3(184426) + num.ToString(), 0);
		return GClass96.smethod_16(list);
	}

	// Token: 0x060002BB RID: 699 RVA: 0x00045568 File Offset: 0x00043768
	protected override void r6()
	{
		List<byte> list_ = this.method_56();
		try
		{
			base.method_42();
			if (!base.method_22(list_).Contains("OK"))
			{
				throw new Exception(GClass107.smethod_3(184450));
			}
			this.ra(GClass107.smethod_3(184490));
			string text = this.ra(GClass107.smethod_3(184516));
			string text2;
			if (this.string_3 == "10")
			{
				text2 = this.ra(GClass107.smethod_3(184536));
			}
			else if (this.string_3 == "30")
			{
				text2 = this.ra(GClass107.smethod_3(184580));
			}
			else if (this.string_3 == "70")
			{
				text2 = this.ra(GClass107.smethod_3(184626));
			}
			else if (this.string_3 == "90")
			{
				text2 = this.ra(GClass107.smethod_3(184643));
			}
			else if (this.string_3 == "C0")
			{
				text2 = this.ra(GClass107.smethod_3(184665));
			}
			else
			{
				text2 = this.ra(GClass107.smethod_3(184691) + this.string_3);
			}
			string text3 = this.ra(GClass107.smethod_3(184716));
			if (this.genum0_0 == (GEnum0)0 && !text3.Contains("OK") && this.string_3 != "70" && this.string_3 != "")
			{
				text2 = this.ra(GClass107.smethod_3(184734));
				text3 = this.ra(GClass107.smethod_3(184756));
			}
			if (this.genum0_0 == (GEnum0)0 && !text3.Contains("OK") && this.string_3 != "70" && this.string_3 != "10" && this.string_3 != "")
			{
				text2 = this.ra(GClass107.smethod_3(184794));
				text3 = this.ra(GClass107.smethod_3(184842));
			}
			if (this.genum0_0 == (GEnum0)0 && !text3.Contains("OK") && this.string_3 != "70" && this.string_3 != "C0" && this.string_3 != "")
			{
				text2 = this.ra(GClass107.smethod_3(184864));
				text3 = this.ra(GClass107.smethod_3(184888));
			}
			if (this.genum0_0 == (GEnum0)0 && !text3.Contains("OK") && this.string_3 != "70" && this.string_3 != "90" && this.string_3 != "")
			{
				text2 = this.ra(GClass107.smethod_3(184892));
				text3 = this.ra(GClass107.smethod_3(184898));
			}
			if (text3.Contains("OK") && this.ra("ATKW").Replace(" ", "").Contains(":EA"))
			{
				this.ra(GClass107.smethod_3(184928) + GClass127.smethod_23(this.byte_0) + "F1");
				this.bool_6 = true;
			}
			if (!text3.Contains("OK") || !text2.Contains("OK") || !text.Contains("ms"))
			{
				this.string_9 = text3.Replace("\r", "").Replace("\n", "").Replace(">", "");
				throw new Exception(GClass107.smethod_3(184971));
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_8 = ex.Message;
			throw new Exception("0");
		}
		GClass126.smethod_2(GClass107.smethod_3(184994), 1);
	}
}
