using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x0200003A RID: 58
public sealed class GClass74 : GClass73
{
	// Token: 0x060002B1 RID: 689 RVA: 0x000435B4 File Offset: 0x000417B4
	private List<byte> method_58()
	{
		int num = 1600;
		List<string> list = new List<string>();
		list.Add(GClass107.smethod_3(178077) + GClass127.smethod_23(this.byte_0) + GClass107.smethod_3(178100));
		list.Add(GClass107.smethod_3(178141));
		list.Add(GClass107.smethod_3(178176));
		list.Add(GClass107.smethod_3(178205));
		list.Add(GClass107.smethod_3(178228));
		list.Add(GClass107.smethod_3(178252));
		list.Add(GClass107.smethod_3(178260));
		list.Add(GClass107.smethod_3(178302));
		list.Add(GClass107.smethod_3(178337));
		list.Add(GClass107.smethod_3(178343));
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
				if (gclass.byte_0.Length == 1 && gclass.byte_0[0].Length > 2)
				{
					byte b = 0;
					for (int i = 0; i < gclass.byte_0[0].Length; i++)
					{
						b += gclass.byte_0[0][i];
					}
					string text = GClass127.smethod_11(gclass.byte_0[0]);
					if (this.string_0 != GClass107.smethod_3(178383) && this.string_0 != GClass107.smethod_3(178420))
					{
						text += GClass127.smethod_23(b);
					}
					if (text.Length > 4)
					{
						text = text.Replace(" ", "") + "1";
					}
					int num2;
					if (list.Contains(text))
					{
						num2 = list.IndexOf(text);
					}
					else
					{
						list.Add(text);
						num2 = (int)((byte)(list.Count - 1));
						num -= text.Length + 1;
					}
					gclass.byte_0 = new byte[][]
					{
						new byte[]
						{
							byte.MaxValue,
							byte.MaxValue,
							(byte)num2
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
				if (gclass2.byte_0.Length == 1 && gclass2.byte_0[0].Length > 2)
				{
					byte b2 = 0;
					for (int j = 0; j < gclass2.byte_0[0].Length; j++)
					{
						b2 += gclass2.byte_0[0][j];
					}
					string text2 = GClass127.smethod_11(gclass2.byte_0[0]);
					if (this.string_0 != GClass107.smethod_3(178431) && this.string_0 != GClass107.smethod_3(178462))
					{
						text2 += GClass127.smethod_23(b2);
					}
					if (text2.Length > 4)
					{
						text2 = text2.Replace(" ", "") + "1";
					}
					int num3;
					if (list.Contains(text2))
					{
						num3 = list.IndexOf(text2);
					}
					else
					{
						list.Add(text2);
						num3 = (int)((byte)(list.Count - 1));
						num -= text2.Length + 1;
					}
					num -= text2.Length + 1;
					gclass2.byte_0 = new byte[][]
					{
						new byte[]
						{
							byte.MaxValue,
							byte.MaxValue,
							(byte)num3
						}
					};
				}
			}
		}
		GClass126.smethod_2(GClass107.smethod_3(178489) + num.ToString(), 0);
		return GClass96.smethod_16(list);
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x000439E0 File Offset: 0x00041BE0
	protected override void r6()
	{
		List<byte> list_ = this.method_58();
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
				throw new Exception(GClass107.smethod_3(178535));
			}
			this.ra(GClass107.smethod_3(178561));
			if (this.string_0 == GClass107.smethod_3(178583) || this.string_0 == GClass107.smethod_3(178597))
			{
				this.ra(GClass107.smethod_3(178634));
			}
			this.ra(GClass107.smethod_3(178644));
			this.ra(GClass107.smethod_3(178658));
			this.ra(GClass107.smethod_3(178672));
			this.ra(GClass107.smethod_3(178695));
			this.ra(GClass107.smethod_3(178740));
			if (!(this.string_3 == "70") && !(this.string_3 == ""))
			{
				if (this.string_3 == "10")
				{
					text = this.ra(GClass107.smethod_3(178783));
				}
				else if (this.string_3 == "30")
				{
					text = this.ra(GClass107.smethod_3(178826));
				}
				else if (this.string_3 == "90")
				{
					text = this.ra(GClass107.smethod_3(178831));
				}
				else if (this.string_3 == "C0")
				{
					text = this.ra(GClass107.smethod_3(178836));
				}
				else if (this.string_3 == "B0")
				{
					text = this.ra(GClass107.smethod_3(178868));
				}
				else
				{
					text = this.ra(GClass107.smethod_3(178900) + this.string_3);
				}
			}
			string text2 = this.ra(GClass107.smethod_3(178920));
			Thread.Sleep(100);
			string text3 = this.ra(GClass107.smethod_3(178965));
			if (this.genum0_0 == (GEnum0)0 && !text3.Contains(GClass107.smethod_3(178985)))
			{
				Thread.Sleep(300);
				text3 = this.ra(GClass107.smethod_3(179029));
			}
			if (this.genum0_0 == (GEnum0)0 && !text3.Contains(GClass107.smethod_3(179041)) && this.string_3 != "70" && this.string_3 != "")
			{
				Thread.Sleep(200);
				text = this.ra(GClass107.smethod_3(179073));
				Thread.Sleep(100);
				text3 = this.ra(GClass107.smethod_3(179103));
			}
			if (this.genum0_0 == (GEnum0)0 && !text3.Contains(GClass107.smethod_3(179110)) && this.string_3 != "70" && this.string_3 != "10" && this.string_3 != "")
			{
				Thread.Sleep(200);
				text = this.ra(GClass107.smethod_3(179151));
				Thread.Sleep(100);
				text3 = this.ra(GClass107.smethod_3(179194));
			}
			if (this.genum0_0 == (GEnum0)0 && !text3.Contains(GClass107.smethod_3(179214)) && this.string_3 != "70" && this.string_3 != "30" && this.string_3 != "")
			{
				Thread.Sleep(200);
				text = this.ra(GClass107.smethod_3(179229));
				Thread.Sleep(100);
				text3 = this.ra(GClass107.smethod_3(179274));
			}
			if (this.genum0_0 == (GEnum0)0 && !text3.Contains(GClass107.smethod_3(179313)) && this.string_3 != "70" && this.string_3 != "C0" && this.string_3 != "")
			{
				Thread.Sleep(200);
				text = this.ra(GClass107.smethod_3(179344));
				Thread.Sleep(100);
				text3 = this.ra(GClass107.smethod_3(179368));
			}
			string text4 = "0209";
			if (!(this.string_0 == GClass107.smethod_3(179397)) && !(this.string_0 == GClass107.smethod_3(179443)))
			{
				if (!text3.Contains(GClass107.smethod_3(179606)))
				{
					Thread.Sleep(50);
					this.ra(GClass107.smethod_3(179616));
				}
			}
			else
			{
				if (this.string_0 == GClass107.smethod_3(179475))
				{
					this.ra(GClass107.smethod_3(179493));
				}
				if (this.string_0 == GClass107.smethod_3(179498))
				{
					this.ra(GClass107.smethod_3(179539));
				}
				Thread.Sleep(50);
				this.ra("033451881");
				Thread.Sleep(30);
				this.ra("04000000041");
				text4 = GClass107.smethod_3(179566);
			}
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			string text5 = this.ra(GClass107.smethod_3(179644));
			this.string_7 = text5.Replace("1:", "").Replace("2:", "").Replace("3:", "").Replace("4:", "").Replace("C:", "").Replace(">", "").Replace("\r", "").Replace("\n", "");
			byte b = 0;
			try
			{
				byte[] array = GClass127.smethod_32(this.string_7);
				this.string_7 = GClass127.smethod_11(array);
				b = array[1];
				b ^= byte.MaxValue;
			}
			catch (Exception)
			{
				this.string_7 = "";
			}
			GClass126.smethod_2(GClass107.smethod_3(179657) + this.string_7, 0);
			if (this.string_0 != GClass107.smethod_3(179691) && this.string_0 != GClass107.smethod_3(179720))
			{
				this.ra(GClass127.smethod_23(b));
				Thread.Sleep(50);
				this.ra(GClass107.smethod_3(179750));
				string text6 = this.ra(text4 + "0B");
				Thread.Sleep(50);
				this.ra(GClass107.smethod_3(179753));
				if (text6.Contains(GClass107.smethod_3(179790)))
				{
					for (int i = 0; i < 20; i++)
					{
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
					this.ra(GClass107.smethod_3(179794));
					text3 = this.ra(GClass107.smethod_3(179817));
					this.ra(GClass107.smethod_3(179838));
					this.int_0 = GClass126.smethod_1();
					while (GClass126.smethod_1() < this.int_0 + 400)
					{
						Thread.Sleep(10);
					}
					text6 = this.ra(text4 + "0B1");
					this.int_0 = GClass126.smethod_1();
					while (GClass126.smethod_1() < this.int_0 + 250)
					{
						Thread.Sleep(10);
					}
				}
				if (text6.Contains(GClass107.smethod_3(179879)))
				{
					for (int j = 0; j < 20; j++)
					{
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
					this.ra(GClass107.smethod_3(179920));
					text3 = this.ra(GClass107.smethod_3(179957));
					this.ra(GClass107.smethod_3(179973));
					this.int_0 = GClass126.smethod_1();
					while (GClass126.smethod_1() < this.int_0 + 250)
					{
						Thread.Sleep(10);
					}
					this.ra(text4 + "0B1");
					this.int_0 = GClass126.smethod_1();
					while (GClass126.smethod_1() < this.int_0 + 200)
					{
						Thread.Sleep(10);
					}
				}
			}
			string text7 = this.ra(text4 + ((text4 == GClass107.smethod_3(179988)) ? "1" : "0B1"));
			if (!text7.Replace(" ", "").Contains(text4))
			{
				text7 = this.ra(text4 + ((text4 == GClass107.smethod_3(180033)) ? "1" : "0B1"));
			}
			if (!text7.Replace(" ", "").Contains(text4))
			{
				text7 = this.ra(text4 + ((text4 == GClass107.smethod_3(180048)) ? "1" : "0B1"));
			}
			if (!text7.Replace(" ", "").Contains(text4) || !text.Contains("OK") || !text2.Contains("ms"))
			{
				this.ra(GClass107.smethod_3(180071));
				this.string_9 = text3.Replace("\r", "").Replace("\n", "").Replace(">", "");
				throw new Exception(GClass107.smethod_3(180114));
			}
			Thread.Sleep(10);
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			throw new Exception("0");
		}
		GClass126.smethod_2(GClass107.smethod_3(180153), 1);
	}
}
