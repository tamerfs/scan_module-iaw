using System;

// Token: 0x0200006B RID: 107
public sealed class GClass55 : GClass47
{
	// Token: 0x060003AE RID: 942 RVA: 0x0005E3B4 File Offset: 0x0005C5B4
	protected override void r6()
	{
		try
		{
			base.method_23("81", "01");
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			this.ra("ATSPB");
			this.ra("ATS0");
			this.ra("ATAL");
			this.ra("ATCRA " + this.string_2.Substring(3, 3));
			this.ra("ATSH " + this.string_2.Substring(0, 3));
			this.ra("ATAT0");
			this.ra("ATST19");
			this.ra("ATFCSH " + this.string_2.Substring(0, 3));
			this.ra("ATFCSD 30 00 00");
			this.ra("ATFCSM 1");
			this.ra("STCAFCP " + this.string_2.Substring(0, 3) + "," + this.string_2.Substring(3, 3));
			byte[] array = base.method_54(this.byte_4);
			if (array.Length > 3 && array[1] == 127 && array[3] == 18)
			{
				array = base.method_54(GClass127.smethod_32("021092"));
			}
			if (array.Length > 3 && array[1] == 127 && array[3] == 18)
			{
				array = base.method_54(GClass127.smethod_32("0210C0"));
			}
			if (array.Length < 3 || array[1] != 80)
			{
				throw new Exception("ELM327->ECU Connection failed!");
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
