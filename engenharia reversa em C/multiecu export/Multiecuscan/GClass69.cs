using System;

// Token: 0x02000048 RID: 72
public sealed class GClass69 : GClass67
{
	// Token: 0x060002D2 RID: 722 RVA: 0x00047548 File Offset: 0x00045748
	protected override void r6()
	{
		try
		{
			if (this.string_2 == "CCANPN")
			{
				base.method_41("81", "01", "80", "01");
			}
			else if (this.string_2 == "BHCANPN")
			{
				base.method_41("81", "04", "80", "04");
			}
			else
			{
				base.method_23("", "");
			}
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			this.ra("ATAL");
			this.ra("ATS0");
			this.ra("ATCP 18");
			this.ra("ATAT0");
			this.ra("ATST22");
			this.ra("ATSPC");
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_8 = ex.Message;
			throw new Exception("Connection failed!");
		}
	}
}
