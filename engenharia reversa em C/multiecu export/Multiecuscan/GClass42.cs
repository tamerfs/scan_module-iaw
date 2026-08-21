using System;

// Token: 0x02000046 RID: 70
public sealed class GClass42 : GClass40
{
	// Token: 0x060002CE RID: 718 RVA: 0x00046D50 File Offset: 0x00044F50
	protected override void r6()
	{
		try
		{
			if (this.string_2 == "CCAN29")
			{
				base.method_41("01", "01", "40", "01");
			}
			else if (this.string_2 == "BCAN29")
			{
				base.method_41("01", "0A", "40", "0A");
			}
			else if (this.string_2 == "BHCAN29")
			{
				base.method_41("01", "04", "40", "04");
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
			this.ra("ATAT1");
			this.ra("ATSTFE");
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
