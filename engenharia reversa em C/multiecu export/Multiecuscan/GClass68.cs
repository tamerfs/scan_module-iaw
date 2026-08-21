using System;

// Token: 0x02000037 RID: 55
public sealed class GClass68 : GClass67
{
	// Token: 0x060002A9 RID: 681 RVA: 0x00042A84 File Offset: 0x00040C84
	protected override void r6()
	{
		try
		{
			base.method_42();
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			if (this.string_2 == "CCANPN")
			{
				this.ra("AT PP 2C SV 81");
				this.ra("AT PP 2C ON");
				this.ra("AT PP 2D SV 01");
				this.ra("AT PP 2D ON");
				this.ra("AT PP 2E SV 80");
				this.ra("AT PP 2E ON");
				this.ra("AT PP 2F SV 01");
				this.ra("AT PP 2F ON");
				this.r9("ATZ");
				this.rb();
				this.ra("ATSPC");
			}
			else if (this.string_2 == "BHCANPN")
			{
				this.ra("AT PP 2C SV 81");
				this.ra("AT PP 2C ON");
				this.ra("AT PP 2D SV 04");
				this.ra("AT PP 2D ON");
				this.ra("AT PP 2E SV 80");
				this.ra("AT PP 2E ON");
				this.ra("AT PP 2F SV 04");
				this.ra("AT PP 2F ON");
				this.r9("ATZ");
				this.rb();
				this.ra("ATSPC");
			}
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			this.ra("ATAL");
			this.ra("ATS0");
			this.ra("ATAT0");
			this.ra("ATST22");
			this.ra("ATMC" + this.string_3);
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_8 = ex.Message;
			throw new Exception("Connection failed!");
		}
	}
}
