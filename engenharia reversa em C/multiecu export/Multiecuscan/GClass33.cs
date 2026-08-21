using System;

// Token: 0x02000071 RID: 113
public sealed class GClass33 : GClass23
{
	// Token: 0x060003D1 RID: 977 RVA: 0x000633C4 File Offset: 0x000615C4
	protected override void r6()
	{
		try
		{
			base.method_23("", "");
			if (this.string_3 == "19")
			{
				this.ra("VTSET_CAN B,01,0A,LS_CAN");
			}
			else
			{
				this.ra("VTSET_CAN B,01,0A,HS_CAN");
			}
			this.ra("VTSWGPGT1");
			if (this.string_2 != "F4")
			{
				this.ra("ATV1");
			}
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			string text = this.ra("ATSPB");
			this.ra("ATS0");
			this.ra("ATCP 18");
			string text2 = this.ra("ATCRA 18DA" + this.string_2 + GClass127.smethod_23(this.byte_0));
			this.ra("ATSH DA" + GClass127.smethod_23(this.byte_0) + this.string_2);
			this.ra("ATAT1");
			this.ra("ATSTF0");
			byte[] array = base.method_51(this.byte_4);
			if (array.Length == 0 && this.string_2 != "F4")
			{
				this.ra("ATV0");
				array = base.method_51(this.byte_4);
			}
			if (array.Length < 3 || array[1] != 80 || array[2] != 3)
			{
				if (!text.Contains("OK") && !text2.Contains("OK"))
				{
					this.string_9 = "ATCRA FAILED";
				}
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
