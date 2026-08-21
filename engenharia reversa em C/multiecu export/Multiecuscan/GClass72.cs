using System;

// Token: 0x0200004C RID: 76
public sealed class GClass72 : GClass70
{
	// Token: 0x060002DA RID: 730 RVA: 0x00047B60 File Offset: 0x00045D60
	protected override void r6()
	{
		try
		{
			base.method_23("", "");
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH1");
			this.ra("ATS0");
			this.ra("ATAL");
			byte[] array = new byte[0];
			string text = this.ra("ATSP5");
			this.ra("ATST80");
			string text2 = "OK";
			string text3 = this.ra("0100");
			if (text3.Contains("OK") || text3.Contains("4100"))
			{
				this.string_22 = "8?F1" + this.string_2.Substring(3, 2);
				array = base.method_51(this.byte_4);
			}
			if (array.Length == 0)
			{
				text = this.ra("ATSP7");
				this.ra("ATH0");
				this.ra("ATCP18");
				text2 = this.ra("ATCRA 18DAF1" + GClass127.smethod_23(this.byte_0));
				this.string_22 = "";
				array = base.method_51(this.byte_4);
			}
			if (array.Length == 0)
			{
				text = this.ra("ATSP6");
				this.ra("ATH0");
				text2 = this.ra("ATCRA " + this.string_2.Substring(0, 3));
				this.string_22 = "";
				array = base.method_51(this.byte_4);
			}
			if (array.Length < 3 || array[1] != 65 || array[2] != 0)
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
