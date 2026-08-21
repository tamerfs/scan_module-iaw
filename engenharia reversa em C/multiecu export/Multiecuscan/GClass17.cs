using System;

// Token: 0x02000072 RID: 114
public sealed class GClass17 : GClass12
{
	// Token: 0x060003D3 RID: 979 RVA: 0x000635A8 File Offset: 0x000617A8
	protected override void r6()
	{
		try
		{
			base.method_23("", "");
			if (this.string_3 == "19")
			{
				this.ra("VTSET_CAN B,81,0A,LS_CAN");
			}
			else
			{
				this.ra("VTSET_CAN B,81,0A,HS_CAN");
			}
			this.ra("VTSWGPGT1");
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			this.ra("ATAL");
			this.ra("ATS0");
			string text = this.ra(string.Concat(new string[]
			{
				"VT SET_HD 7B0-",
				GClass127.smethod_23(this.byte_0),
				", ",
				this.string_2,
				"-F1, 80"
			}));
			this.ra("VTSET_CAN_FC " + GClass127.smethod_23(this.byte_0) + " 30 FF 00, 1, 7B0");
			this.ra("VTSWGP FCAN1");
			string text2 = this.ra("ATSPB");
			this.bool_6 = true;
			byte[] array = base.method_46(this.byte_4);
			if (array.Length < 3 || array[1] != 80 || array[2] != 129)
			{
				if (!text2.Contains("OK") && !text.Contains("OK"))
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
