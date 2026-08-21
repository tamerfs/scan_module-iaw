using System;

// Token: 0x02000068 RID: 104
public sealed class GClass16 : GClass12
{
	// Token: 0x060003A8 RID: 936 RVA: 0x0005DF48 File Offset: 0x0005C148
	protected override void r6()
	{
		try
		{
			base.method_23("81", "0A");
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			this.ra("ATAL");
			this.ra("ATSPB");
			this.ra("ATS0");
			this.ra("ATCAF0");
			this.ra("ATCFC0");
			this.ra("ATCRA " + this.string_2);
			this.ra("ATSH 7B0");
			this.ra("ATAT1");
			this.string_22 = "ATST28";
			this.ra(this.string_22);
			byte[] array = base.method_46(this.byte_4);
			if (array.Length < 3 || array[1] != 80 || array[2] != 129)
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
