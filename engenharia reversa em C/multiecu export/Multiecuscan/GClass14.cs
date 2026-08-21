using System;

// Token: 0x02000042 RID: 66
public sealed class GClass14 : GClass12
{
	// Token: 0x060002C6 RID: 710 RVA: 0x00046790 File Offset: 0x00044990
	protected override void r6()
	{
		try
		{
			base.method_23("81", "0A");
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			this.ra("ATAL");
			string text = this.ra("ATSPB");
			this.ra("ATS0");
			this.ra("ATCAF0");
			this.ra("ATCFC0");
			string text2 = this.ra("ATCRA " + this.string_2);
			this.ra("ATSH 7B0");
			this.ra("ATAT1");
			if (GClass125.smethod_46())
			{
				this.string_22 = "ATST27";
			}
			this.ra(this.string_22);
			byte[] array = base.method_46(this.byte_4);
			if (array.Length < 3 || array[1] != 80 || array[2] != 129)
			{
				if (!text.Contains("OK") && !text2.Contains("OK"))
				{
					this.string_9 = "ATCRA FAILED";
				}
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
