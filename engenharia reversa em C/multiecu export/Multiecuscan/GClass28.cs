using System;

// Token: 0x02000043 RID: 67
public sealed class GClass28 : GClass23
{
	// Token: 0x060002C8 RID: 712 RVA: 0x00046900 File Offset: 0x00044B00
	protected override void r6()
	{
		try
		{
			base.method_23("01", "04");
			if (this.string_2 != "F4")
			{
				this.ra("ATV1");
			}
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			this.ra("ATSPB");
			this.ra("ATS0");
			this.ra("ATAL");
			this.ra("ATCP 18");
			this.ra("ATCRA 18DA" + this.string_2 + GClass127.smethod_23(this.byte_0));
			this.ra("ATSH DA" + GClass127.smethod_23(this.byte_0) + this.string_2);
			this.ra("ATAT1");
			this.ra("ATST99");
			byte[] array = base.method_51(this.byte_4);
			if (array.Length == 0 && this.string_2 != "F4")
			{
				this.ra("ATV0");
				array = base.method_51(this.byte_4);
			}
			if (array.Length < 3 || array[1] != 80 || array[2] != 3)
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
