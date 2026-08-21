using System;

// Token: 0x02000033 RID: 51
public sealed class GClass41 : GClass40
{
	// Token: 0x0600029F RID: 671 RVA: 0x00041228 File Offset: 0x0003F428
	protected override void r6()
	{
		try
		{
			base.method_42();
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			if (this.string_2 == "CCAN29")
			{
				this.ra("AT PP 2C SV 01");
				this.ra("AT PP 2C ON");
				this.ra("AT PP 2D SV 01");
				this.ra("AT PP 2D ON");
				this.ra("AT PP 2E SV 40");
				this.ra("AT PP 2E ON");
				this.ra("AT PP 2F SV 01");
				this.ra("AT PP 2F ON");
				this.r9("ATZ");
				this.rb();
				this.ra("ATSPC");
			}
			else if (this.string_2 == "BCAN29")
			{
				this.ra("AT PP 2C SV 01");
				this.ra("AT PP 2C ON");
				this.ra("AT PP 2D SV 0A");
				this.ra("AT PP 2D ON");
				this.ra("AT PP 2E SV 40");
				this.ra("AT PP 2E ON");
				this.ra("AT PP 2F SV 0A");
				this.ra("AT PP 2F ON");
				this.r9("ATZ");
				this.rb();
				this.ra("ATSPC");
			}
			else if (this.string_2 == "BHCAN29")
			{
				this.ra("AT PP 2C SV 01");
				this.ra("AT PP 2C ON");
				this.ra("AT PP 2D SV 04");
				this.ra("AT PP 2D ON");
				this.ra("AT PP 2E SV 40");
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
			this.ra("ATCP 18");
			this.ra("ATAT1");
			this.ra("ATSTFE");
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
