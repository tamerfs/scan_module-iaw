using System;
using System.Collections.Generic;

// Token: 0x02000039 RID: 57
public sealed class GClass71 : GClass70
{
	// Token: 0x060002AE RID: 686 RVA: 0x000432CC File Offset: 0x000414CC
	private List<byte> method_54()
	{
		int num = 1600;
		List<string> list = new List<string>();
		list.Add(GClass107.smethod_3(175746));
		list.Add(GClass107.smethod_3(175775) + GClass127.smethod_23(this.byte_0) + GClass107.smethod_3(175791));
		list.Add("ATE0\rATL0\rATH0\rATS0\rATAL\rATCP18\rATCRA" + this.string_2.Substring(0, 3) + "\rATSP6\rATFCSH" + this.string_2.Substring(0, 3));
		list.Add(GClass127.smethod_11(this.byte_4).Replace(" ", ""));
		list.Add(GClass107.smethod_3(175792));
		list.Add(GClass107.smethod_3(175804));
		list.Add(GClass107.smethod_3(175853));
		list.Add(GClass107.smethod_3(175854));
		GClass126.smethod_2(GClass107.smethod_3(175884) + num.ToString(), 0);
		return GClass96.smethod_16(list);
	}

	// Token: 0x060002AF RID: 687 RVA: 0x000433D0 File Offset: 0x000415D0
	protected override void r6()
	{
		List<byte> list_ = this.method_54();
		try
		{
			base.method_42();
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 3500;
			}
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
				throw new Exception(GClass107.smethod_3(175903));
			}
			byte[] array = new byte[0];
			this.ra(GClass107.smethod_3(175937));
			string text = this.ra(GClass107.smethod_3(175948));
			string text2 = this.ra("0100");
			if (text2.Contains("OK") || text2.Contains("4100"))
			{
				this.string_22 = GClass107.smethod_3(175971) + this.string_2.Substring(3, 2);
				array = base.method_51(this.byte_4);
			}
			if (array.Length == 0)
			{
				this.ra(GClass107.smethod_3(176000));
				this.string_22 = "";
				array = base.method_51(this.byte_4);
			}
			if (array.Length == 0)
			{
				this.ra(GClass107.smethod_3(176044));
				this.string_22 = "";
				array = base.method_51(this.byte_4);
			}
			if (array.Length < 3 || array[1] != 65 || array[2] != 0 || !text.Contains("ms"))
			{
				throw new Exception(GClass107.smethod_3(176070));
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_8 = ex.Message;
			throw new Exception("0");
		}
		GClass126.smethod_2(GClass107.smethod_3(176075), 1);
	}
}
