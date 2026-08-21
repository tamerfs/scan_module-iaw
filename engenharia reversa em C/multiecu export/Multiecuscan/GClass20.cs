using System;

// Token: 0x02000050 RID: 80
public sealed class GClass20 : GClass18
{
	// Token: 0x060002F0 RID: 752 RVA: 0x00049478 File Offset: 0x00047678
	protected override void r6()
	{
		try
		{
			base.method_23("80", "0A");
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
