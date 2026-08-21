using System;

// Token: 0x02000040 RID: 64
public sealed class GClass19 : GClass18
{
	// Token: 0x060002C3 RID: 707 RVA: 0x000463F0 File Offset: 0x000445F0
	protected override void r6()
	{
		try
		{
			base.method_42();
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 3500;
			}
			this.ra(GClass107.smethod_3(188515));
			this.ra(GClass107.smethod_3(188538));
			this.ra(GClass107.smethod_3(188579));
			this.ra(GClass107.smethod_3(188586));
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
			string text = "OK";
			this.ra("ATI");
			string text2 = this.ra(GClass107.smethod_3(188595));
			this.ra(GClass107.smethod_3(188630));
			this.ra(GClass107.smethod_3(188657));
			this.ra(GClass107.smethod_3(188688));
			this.ra(GClass107.smethod_3(188712));
			this.ra(GClass107.smethod_3(188740));
			this.ra(GClass107.smethod_3(188770));
			this.ra(GClass107.smethod_3(188817));
			this.r9(GClass107.smethod_3(188846));
			if (base.method_4().Length < 4 || !text.Contains("OK") || !text2.Contains("ms"))
			{
				throw new Exception(GClass107.smethod_3(188894));
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_8 = ex.Message;
			throw new Exception("0");
		}
		GClass126.smethod_2(GClass107.smethod_3(188923), 1);
	}
}
