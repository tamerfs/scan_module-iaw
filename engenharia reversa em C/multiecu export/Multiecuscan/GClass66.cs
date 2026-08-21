using System;

// Token: 0x02000075 RID: 117
public sealed class GClass66 : GClass57
{
	// Token: 0x060003D9 RID: 985 RVA: 0x00063AAC File Offset: 0x00061CAC
	protected override void r6()
	{
		try
		{
			base.method_23("", "");
			if (this.string_3 == "3B")
			{
				this.ra("VTSET_CAN B,81,04,MS_CAN");
			}
			else
			{
				this.ra("VTSET_CAN B,81,04,HS_CAN");
			}
			this.ra("VTSWGPGT1");
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			this.ra("ATSPB");
			this.ra("ATS0");
			this.ra("ATAL");
			this.ra("ATCRA " + this.string_2.Substring(3, 3));
			this.ra("ATSH " + this.string_2.Substring(0, 3));
			this.ra("ATST25");
			this.ra("VTFCTRA " + this.string_2.Substring(0, 3) + "," + this.string_2.Substring(3, 3));
			byte[] array = base.method_54(this.byte_4);
			if (array.Length < 3 || array[1] != 80 || array[2] != 146)
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
