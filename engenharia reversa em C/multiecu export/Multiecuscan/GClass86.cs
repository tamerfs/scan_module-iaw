using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x0200003E RID: 62
public sealed class GClass86 : GClass85
{
	// Token: 0x060002BD RID: 701 RVA: 0x0004597C File Offset: 0x00043B7C
	private List<byte> method_53()
	{
		int num = 1600;
		List<string> list = new List<string>();
		list.Add(GClass107.smethod_3(185541) + GClass127.smethod_23(this.byte_0) + GClass107.smethod_3(185587));
		list.Add(GClass107.smethod_3(185609));
		list.Add(GClass107.smethod_3(185652));
		list.Add(GClass107.smethod_3(185668));
		list.Add(GClass107.smethod_3(185678));
		list.Add(GClass107.smethod_3(185726));
		list.Add(GClass107.smethod_3(185734));
		list.Add("091");
		list.Add(GClass107.smethod_3(185766));
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
				if (gclass.byte_0.Length == 1 && gclass.byte_0[0].Length > 3)
				{
					byte[] array = new byte[gclass.byte_0[0].Length - 3];
					for (int i = 2; i < gclass.byte_0[0].Length - 1; i++)
					{
						array[i - 2] = gclass.byte_0[0][i];
					}
					string text = GClass127.smethod_11(array).Replace(" ", "") + "1";
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
					GClass104 gclass2 = gclass;
					byte[][] array2 = new byte[1][];
					int num3 = 0;
					byte[] array3 = new byte[]
					{
						4,
						byte.MaxValue,
						byte.MaxValue,
						0,
						3
					};
					array3[3] = (byte)num2;
					array2[num3] = array3;
					gclass2.byte_0 = array2;
				}
			}
			foreach (GClass104 gclass3 in this.list_0)
			{
				if (list.Count > 250)
				{
					break;
				}
				if (num < 10)
				{
					break;
				}
				if (gclass3.byte_0.Length == 1 && gclass3.byte_0[0].Length > 2)
				{
					byte[] array4 = new byte[gclass3.byte_0[0].Length - 3];
					for (int j = 2; j < gclass3.byte_0[0].Length - 1; j++)
					{
						array4[j - 2] = gclass3.byte_0[0][j];
					}
					string text2 = GClass127.smethod_11(array4).Replace(" ", "") + "1";
					int num4;
					if (list.Contains(text2))
					{
						num4 = list.IndexOf(text2);
					}
					else
					{
						list.Add(text2);
						num4 = (int)((byte)(list.Count - 1));
						num -= text2.Length + 1;
					}
					GClass104 gclass4 = gclass3;
					byte[][] array5 = new byte[1][];
					int num5 = 0;
					byte[] array6 = new byte[]
					{
						4,
						byte.MaxValue,
						byte.MaxValue,
						0,
						3
					};
					array6[3] = (byte)num4;
					array5[num5] = array6;
					gclass4.byte_0 = array5;
				}
			}
		}
		GClass126.smethod_2(GClass107.smethod_3(185802) + num.ToString(), 0);
		return GClass96.smethod_16(list);
	}

	// Token: 0x060002BE RID: 702 RVA: 0x00045D00 File Offset: 0x00043F00
	protected override void r6()
	{
		List<byte> list_ = this.method_53();
		try
		{
			base.method_42();
			if (this.serialPort_0 != null)
			{
				if (GClass125.smethod_46())
				{
					this.serialPort_0.ReadTimeout = 3800;
				}
				else
				{
					this.serialPort_0.ReadTimeout = 3800;
				}
			}
			string text = "OK";
			if (!base.method_22(list_).Contains("OK"))
			{
				throw new Exception(GClass107.smethod_3(185835));
			}
			this.ra(GClass107.smethod_3(185864));
			this.ra(GClass107.smethod_3(185873));
			this.ra(GClass107.smethod_3(185879));
			this.ra(GClass107.smethod_3(185902));
			this.ra(GClass107.smethod_3(185919));
			this.ra(GClass107.smethod_3(185937));
			int i = 1;
			if (this.genum0_0 != (GEnum0)0)
			{
				i = 0;
			}
			while (i > -1)
			{
				if (!(this.string_3 == "70") && !(this.string_3 == ""))
				{
					if (this.string_3 == "10")
					{
						text = this.ra(GClass107.smethod_3(185944));
					}
					else if (this.string_3 == "30")
					{
						text = this.ra(GClass107.smethod_3(185984));
					}
					else if (this.string_3 == "90")
					{
						text = this.ra(GClass107.smethod_3(185999));
					}
					else if (this.string_3 == "C0")
					{
						text = this.ra(GClass107.smethod_3(186020));
					}
					else
					{
						text = this.ra(GClass107.smethod_3(186060) + this.string_3);
					}
				}
				string text2 = this.ra(GClass107.smethod_3(186066));
				Thread.Sleep(100);
				string text3 = this.ra(GClass107.smethod_3(186081));
				this.ra(GClass107.smethod_3(186115));
				if (this.genum0_0 == (GEnum0)0 && !text3.Contains(GClass107.smethod_3(186145)) && this.string_3 != "70" && this.string_3 != "" && i == 0)
				{
					Thread.Sleep(200);
					text = this.ra(GClass107.smethod_3(186178));
					Thread.Sleep(100);
					text3 = this.ra(GClass107.smethod_3(186196));
				}
				if (this.genum0_0 == (GEnum0)0 && !text3.Contains(GClass107.smethod_3(186230)) && this.string_3 != "70" && this.string_3 != "10" && this.string_3 != "" && i == 0)
				{
					Thread.Sleep(200);
					text = this.ra(GClass107.smethod_3(186235));
					Thread.Sleep(100);
					text3 = this.ra(GClass107.smethod_3(186242));
				}
				string text4 = "09";
				Thread.Sleep(50);
				if (i == 1)
				{
					Thread.Sleep(150);
				}
				this.ra(text4);
				Thread.Sleep(100);
				if (i == 1)
				{
					Thread.Sleep(120);
				}
				if (this.ra(text4).Replace(" ", "").Contains(text4) && text.Contains("OK") && text2.Contains("ms"))
				{
					i = 0;
				}
				else
				{
					this.ra(GClass107.smethod_3(186278));
					if (i == 0)
					{
						IL_448:
						throw new Exception(GClass107.smethod_3(186279));
					}
					Thread.Sleep(5000);
				}
				i--;
			}
			string text5 = this.ra(GClass107.smethod_3(186290));
			this.string_7 = text5.Replace("1:", "").Replace("2:", "").Replace("3:", "").Replace("4:", "").Replace("C:", "").Replace(">", "").Replace("\r", "").Replace("\n", "");
			try
			{
				this.string_7 = GClass127.smethod_11(GClass127.smethod_32(this.string_7));
				goto IL_458;
			}
			catch (Exception)
			{
				goto IL_458;
			}
			goto IL_448;
			IL_458:
			GClass126.smethod_2(GClass107.smethod_3(186317) + this.string_7, 0);
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			throw new Exception("0");
		}
		GClass126.smethod_2(GClass107.smethod_3(186346), 1);
	}
}
