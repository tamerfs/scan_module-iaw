using System;

// Token: 0x02000078 RID: 120
public sealed class GClass39 : GClass36
{
	// Token: 0x060003DF RID: 991 RVA: 0x00064044 File Offset: 0x00062244
	protected override void r6()
	{
		try
		{
			base.method_23("", "");
			this.ra("VTSET_CAN B,01,0A,LS_CAN");
			if (this.string_3 == "6E")
			{
				this.ra("VTSET_CAN C,40,0A,HS_CAN");
			}
			else
			{
				this.ra("VTSET_CAN C,40,0A,LS_CAN");
			}
			if (this.string_2 != "F4")
			{
				this.ra("ATV1");
			}
			this.ra("ATSPB");
			this.ra("ATL0");
			this.ra("ATE0");
			this.ra("ATH1");
			this.ra("ATSPC");
			this.ra("ATAL");
			this.ra("ATD0");
			this.ra("ATS0");
			this.r9("ATMA");
			if (base.method_4().Length < 4)
			{
				throw new Exception("vLinker MS->CAN Connection failed!");
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
