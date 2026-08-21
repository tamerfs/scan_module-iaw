using System;

// Token: 0x02000074 RID: 116
public sealed class GClass56 : GClass47
{
	// Token: 0x060003D7 RID: 983 RVA: 0x0006391C File Offset: 0x00061B1C
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
