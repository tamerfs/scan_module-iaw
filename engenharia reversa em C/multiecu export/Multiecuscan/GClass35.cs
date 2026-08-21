using System;

// Token: 0x02000077 RID: 119
public sealed class GClass35 : GClass23
{
	// Token: 0x060003DD RID: 989 RVA: 0x00063E1C File Offset: 0x0006201C
	protected override void r6()
	{
		try
		{
			base.method_23("", "");
			if (this.string_3 == "CD")
			{
				this.ra("VTSET_CAN B,01,01,CH_CAN");
			}
			else
			{
				this.ra("VTSET_CAN B,01,01,HS_CAN");
			}
			this.ra("VTSWGPGT1");
			if (this.string_2 != "F4")
			{
				this.ra("ATV1");
			}
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			string text = this.ra("ATSPB");
			this.ra("ATS0");
			this.ra("ATCP 18");
			string text2 = this.ra("ATCRA 18DA" + this.string_2 + GClass127.smethod_23(this.byte_0));
			this.ra("ATSH DA" + GClass127.smethod_23(this.byte_0) + this.string_2);
			this.ra("ATAT1");
			this.ra("ATST99");
			byte[] array = base.method_51(this.byte_4);
			if (array.Length > 3 && array[1] == 127 && array[3] == 18)
			{
				array = base.method_51(GClass127.smethod_32("021092"));
			}
			if (array.Length == 0 && this.string_2 != "F4")
			{
				this.ra("ATV0");
				array = base.method_51(this.byte_4);
				if (array.Length > 3 && array[1] == 127 && array[3] == 18)
				{
					array = base.method_51(GClass127.smethod_32("021092"));
				}
			}
			if (array.Length < 3 || array[1] != 80)
			{
				if (!text.Contains("OK") && !text2.Contains("OK"))
				{
					this.string_9 = "ATCRA FAILED";
				}
				throw new Exception("vLinker MS->ECU Connection failed!");
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_8 = ex.Message;
			throw new Exception("0");
		}
		GClass126.smethod_2("ECU wakeup completed", 1);
	}
}
