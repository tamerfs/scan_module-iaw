using System;

// Token: 0x0200003F RID: 63
public sealed class GClass37 : GClass36
{
	// Token: 0x060002C1 RID: 705 RVA: 0x000461DC File Offset: 0x000443DC
	protected override void r6()
	{
		try
		{
			base.method_42();
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 3500;
			}
			this.ra(GClass107.smethod_3(186442));
			this.ra(GClass107.smethod_3(186473));
			this.ra(GClass107.smethod_3(186481));
			this.ra(GClass107.smethod_3(186505));
			this.r9("ATZ");
			this.rb();
			if (this.serialPort_0 != null)
			{
				if (GClass125.smethod_46())
				{
					this.serialPort_0.ReadTimeout = 2000;
				}
				else
				{
					this.serialPort_0.ReadTimeout = 1800;
				}
			}
			string text;
			if (this.string_3 == "6E")
			{
				text = "OK";
			}
			else
			{
				text = this.ra(GClass107.smethod_3(186523));
			}
			this.ra("ATI");
			string text2 = this.ra(GClass107.smethod_3(186565));
			this.ra(GClass107.smethod_3(186596));
			this.ra(GClass107.smethod_3(186635));
			this.ra(GClass107.smethod_3(186644));
			this.ra(GClass107.smethod_3(186683));
			this.ra(GClass107.smethod_3(186700));
			this.ra(GClass107.smethod_3(186702));
			this.ra(GClass107.smethod_3(186739));
			this.r9(GClass107.smethod_3(186777));
			if (base.method_4().Length < 4 || !text.Contains("OK") || !text2.Contains("ms"))
			{
				throw new Exception(GClass107.smethod_3(186800));
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_8 = ex.Message;
			throw new Exception("0");
		}
		GClass126.smethod_2(GClass107.smethod_3(186803), 1);
	}
}
