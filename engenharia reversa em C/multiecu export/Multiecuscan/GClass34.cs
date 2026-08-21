using System;

// Token: 0x02000073 RID: 115
public sealed class GClass34 : GClass23
{
	// Token: 0x060003D5 RID: 981 RVA: 0x0006375C File Offset: 0x0006195C
	protected override void r6()
	{
		try
		{
			base.method_23("01", "04");
			if (this.string_3 == "3B")
			{
				this.ra("VTSET_CAN B,01,04,MS_CAN");
			}
			else
			{
				this.ra("VTSET_CAN B,01,04,HS_CAN");
			}
			this.ra("VTSWGPGT1");
			if (this.string_2 != "F4")
			{
				this.ra("ATV1");
			}
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			this.ra("ATSPB");
			this.ra("ATS0");
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
				throw new Exception("vLinker MS->ECU Connection failed!");
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
