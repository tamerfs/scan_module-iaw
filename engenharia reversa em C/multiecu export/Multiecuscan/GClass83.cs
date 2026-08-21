using System;

// Token: 0x0200004E RID: 78
public sealed class GClass83 : GClass81
{
	// Token: 0x060002EC RID: 748 RVA: 0x00049214 File Offset: 0x00047414
	protected override void r6()
	{
		try
		{
			base.method_23("", "");
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATIB10");
			this.ra("ATSP5");
			this.ra("ATS0");
			this.ra("ATAL");
			this.ra("ATST 62");
			this.ra("ATSH 81" + GClass127.smethod_23(this.byte_0) + "F1");
			this.ra("ATH0");
			string text = this.ra("1A97");
			if (this.ra("ATKW").Replace(" ", "").Contains(":EA"))
			{
				this.ra("ATSH 80" + GClass127.smethod_23(this.byte_0) + "F1");
			}
			if (!text.Contains("OK"))
			{
				this.string_9 = text.Replace("\r", "").Replace("\n", "").Replace(">", "");
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
