using System;

// Token: 0x02000076 RID: 118
public sealed class GClass43 : GClass40
{
	// Token: 0x060003DB RID: 987 RVA: 0x00063C40 File Offset: 0x00061E40
	protected override void r6()
	{
		try
		{
			base.method_23("", "");
			if (this.string_2 == "CCAN29" && this.string_3 == "CD")
			{
				this.ra("VTSET_CAN B,01,01,CH_CAN");
				this.ra("VTSET_CAN C,40,01,CH_CAN");
			}
			else if (this.string_2 == "CCAN29")
			{
				this.ra("VTSET_CAN B,01,01,HS_CAN");
				this.ra("VTSET_CAN C,40,01,HS_CAN");
			}
			else if (this.string_2 == "BCAN29" && this.string_3 == "19")
			{
				this.ra("VTSET_CAN B,01,0A,LS_CAN");
				this.ra("VTSET_CAN C,40,0A,LS_CAN");
			}
			else if (this.string_2 == "BCAN29")
			{
				this.ra("VTSET_CAN B,01,0A,HS_CAN");
				this.ra("VTSET_CAN C,40,0A,HS_CAN");
			}
			else if (this.string_2 == "BHCAN29")
			{
				this.ra("VTSET_CAN B,01,04,MS_CAN");
				this.ra("VTSET_CAN C,40,04,MS_CAN");
			}
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			this.ra("ATAL");
			this.ra("ATS0");
			this.ra("ATSPB");
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
