using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x0200003B RID: 59
public sealed class GClass80 : GClass79
{
	// Token: 0x060002B4 RID: 692 RVA: 0x00044420 File Offset: 0x00042620
	private List<byte> method_52()
	{
		int num = 1600;
		List<string> list = new List<string>();
		list.Add(GClass107.smethod_3(180936) + GClass127.smethod_23(this.byte_0) + GClass107.smethod_3(180969));
		list.Add(GClass107.smethod_3(180983));
		list.Add(GClass107.smethod_3(181003));
		list.Add(GClass107.smethod_3(181018));
		list.Add("AA0");
		list.Add("0F0");
		list.Add(GClass107.smethod_3(181027));
		list.Add("011");
		list.Add(GClass107.smethod_3(181050));
		if (this.genum0_0 == (GEnum0)0)
		{
			foreach (GClass104 gclass in this.list_1)
			{
				if (list.Count > 100)
				{
					break;
				}
				if (num < 80)
				{
					break;
				}
				if (gclass.byte_0.Length == 1 && gclass.byte_0[0].Length == 1 && gclass.byte_0[0][0] != 0)
				{
					string text = GClass127.smethod_11(gclass.byte_0[0]).Replace(" ", "") + "1";
					list.Add(text);
					num -= text.Length + 1;
					gclass.byte_0 = new byte[][]
					{
						new byte[]
						{
							4,
							byte.MaxValue,
							byte.MaxValue,
							byte.MaxValue,
							0
						}
					};
				}
			}
			foreach (GClass104 gclass2 in this.list_0)
			{
				if (list.Count > 250)
				{
					break;
				}
				if (num < 10)
				{
					break;
				}
				if (gclass2.byte_0.Length == 1 && gclass2.byte_0[0].Length == 1)
				{
					string text2 = GClass127.smethod_11(gclass2.byte_0[0]).Replace(" ", "") + "1";
					list.Add(text2);
					num -= text2.Length + 1;
					gclass2.byte_0 = new byte[][]
					{
						new byte[]
						{
							4,
							byte.MaxValue,
							byte.MaxValue,
							byte.MaxValue,
							0
						}
					};
				}
			}
		}
		GClass126.smethod_2(GClass107.smethod_3(181064) + num.ToString(), 0);
		return GClass96.smethod_16(list);
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x000446D4 File Offset: 0x000428D4
	protected override void r6()
	{
		List<byte> list_ = this.method_52();
		try
		{
			base.method_42();
			if (this.serialPort_0 != null)
			{
				if (GClass125.smethod_46())
				{
					this.serialPort_0.ReadTimeout = 3000;
				}
				else
				{
					this.serialPort_0.ReadTimeout = 3000;
				}
			}
			string text = "OK";
			if (!base.method_22(list_).Contains("OK"))
			{
				throw new Exception(GClass107.smethod_3(181092));
			}
			this.ra(GClass107.smethod_3(181120));
			text = this.ra(GClass107.smethod_3(181139));
			if (!text.Contains("OK"))
			{
				this.string_8 = GClass107.smethod_3(181168);
			}
			string text2 = this.ra(GClass107.smethod_3(181202));
			Thread.Sleep(100);
			this.ra(GClass107.smethod_3(181235));
			this.r9(GClass107.smethod_3(181254));
			this.int_0 = GClass126.smethod_1();
			string text3 = "";
			bool flag = false;
			this.string_7 = "";
			while (!flag && GClass126.smethod_1() < this.int_0 + 12000 && !GClass126.bool_25)
			{
				try
				{
					if (GClass125.smethod_48())
					{
						if (this.tcpClient_0.Client.Available > 0)
						{
							int num = this.tcpClient_0.GetStream().ReadByte();
							if (num > 32)
							{
								text3 += ((char)num).ToString();
							}
							GClass126.smethod_2(GClass107.smethod_3(181300) + GClass127.smethod_23((byte)num), 0);
						}
						else
						{
							Thread.Sleep(1);
						}
					}
					else if (GClass125.smethod_52())
					{
						if (this.stringBuilder_0.Length > 0)
						{
							text3 += this.stringBuilder_0[0].ToString();
							this.stringBuilder_0.Remove(0, 1);
						}
						else
						{
							Thread.Sleep(1);
						}
					}
					else
					{
						byte b = (byte)this.serialPort_0.ReadByte();
						if (b > 32)
						{
							string str = text3;
							char c = (char)b;
							text3 = str + c.ToString();
						}
						GClass126.smethod_2(GClass107.smethod_3(181328) + GClass127.smethod_23(b), 0);
					}
				}
				catch (Exception)
				{
				}
				if (text3.Length > 11)
				{
					if (text3.Substring(text3.Length - 12, 2) == "55")
					{
						flag = true;
					}
					GClass126.smethod_2(GClass107.smethod_3(181339) + text3, 0);
					try
					{
						this.string_7 = GClass127.smethod_11(GClass127.smethod_32(text3.Substring(2)));
						GClass126.smethod_2(GClass107.smethod_3(181379) + this.string_7, 0);
					}
					catch (Exception)
					{
					}
				}
			}
			this.ra("");
			this.ra(GClass107.smethod_3(181411));
			for (int i = 0; i < 5; i++)
			{
				if (GClass126.bool_25)
				{
					throw new Exception("ESC");
				}
				Thread.Sleep(100);
			}
			this.ra(GClass107.smethod_3(181423));
			this.int_0 = GClass126.smethod_1();
			while (GClass126.smethod_1() < this.int_0 + 100)
			{
			}
			this.ra(GClass107.smethod_3(181445));
			this.int_0 = GClass126.smethod_1();
			while (GClass126.smethod_1() < this.int_0 + 100)
			{
			}
			this.ra("CC0");
			this.ra(GClass107.smethod_3(181463));
			Thread.Sleep(120);
			if (this.ra("011").Contains(GClass107.smethod_3(181503)) || !text.Contains("OK") || !text2.Contains("ms"))
			{
				throw new Exception(GClass107.smethod_3(181536));
			}
			Thread.Sleep(100);
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			throw new Exception("0");
		}
		GClass126.smethod_2(GClass107.smethod_3(181577), 1);
	}
}
