using System;

// Token: 0x0200004F RID: 79
public sealed class GClass38 : GClass36
{
	// Token: 0x060002EE RID: 750 RVA: 0x000493A0 File Offset: 0x000475A0
	protected override void r6()
	{
		try
		{
			base.method_23("40", "0A");
			this.ra("ATSPB");
			this.ra("ATH1");
			this.ra("ATAL");
			this.ra("ATD0");
			this.ra("ATS0");
			this.ra("ATL0");
			this.ra("ATE0");
			this.r9("ATMA");
			if (base.method_4().Length < 4)
			{
				throw new Exception("ELM327->CAN Connection failed!");
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
