using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

// Token: 0x02000021 RID: 33
public abstract class GClass81 : GClass11
{
	// Token: 0x06000209 RID: 521 RVA: 0x00035A88 File Offset: 0x00033C88
	protected void method_45()
	{
		if (GClass126.bool_0)
		{
			byte[][] array = new byte[][]
			{
				new byte[]
				{
					7,
					90,
					151,
					253,
					134,
					21,
					1,
					110
				},
				new byte[]
				{
					13,
					90,
					145,
					53,
					53,
					49,
					56,
					56,
					50,
					49,
					52,
					32,
					32,
					32
				},
				new byte[]
				{
					13,
					90,
					146,
					48,
					50,
					56,
					49,
					48,
					49,
					49,
					52,
					50,
					49,
					32
				},
				new byte[]
				{
					3,
					90,
					147,
					0
				},
				new byte[]
				{
					13,
					90,
					148,
					49,
					48,
					51,
					55,
					51,
					54,
					55,
					55,
					57,
					48,
					32
				},
				new byte[]
				{
					4,
					90,
					149,
					160,
					68
				},
				new byte[]
				{
					6,
					90,
					153,
					32,
					3,
					7,
					19
				},
				new byte[]
				{
					6,
					90,
					153,
					32,
					3,
					7,
					19
				},
				new byte[]
				{
					6,
					90,
					153,
					32,
					3,
					7,
					19
				},
				new byte[]
				{
					6,
					90,
					153,
					32,
					3,
					7,
					19
				},
				new byte[]
				{
					6,
					90,
					153,
					32,
					3,
					7,
					19
				},
				new byte[]
				{
					6,
					90,
					153,
					32,
					3,
					7,
					19
				},
				new byte[]
				{
					6,
					90,
					153,
					32,
					3,
					7,
					19
				}
			};
			for (int i = 0; i < 20; i++)
			{
				if (GClass126.bool_25)
				{
					throw new Exception("ESC");
				}
				Thread.Sleep(100);
			}
			GClass126.smethod_2("Testing mode!", 1);
			for (int j = 0; j < this.list_1.Count; j++)
			{
				GClass104 gclass = this.list_1[j];
				string text = this.r4(array[j], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				gclass.method_1(text);
				if (gclass.int_2 == 10455)
				{
					this.string_7 = text;
				}
			}
			this.bool_1 = false;
			this.bool_0 = true;
			new Thread(new ThreadStart(this.method_54))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_36();
			throw new Exception("1");
		}
	}

	// Token: 0x0600020A RID: 522
	protected abstract void r6();

	// Token: 0x0600020B RID: 523 RVA: 0x00035C8C File Offset: 0x00033E8C
	public override void vmethod_1()
	{
		try
		{
			GClass126.smethod_2("-------------------------", 0);
			GClass126.smethod_2("Control module (KWP2000): " + GClass127.smethod_23(this.byte_0), 0);
			if (this.genum0_0 == (GEnum0)0)
			{
				for (int i = 0; i < 5; i++)
				{
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(100);
				}
			}
			if (GClass126.bool_0)
			{
				this.method_45();
			}
			else
			{
				this.r6();
			}
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			if (this.genum0_0 == (GEnum0)0)
			{
				this.method_53(new byte[]
				{
					2,
					131,
					1
				});
				Thread thread = new Thread(new ThreadStart(this.method_55));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_54))
				{
					Priority = ThreadPriority.Highest
				}.Start();
			}
			for (int j = 0; j < this.list_1.Count; j++)
			{
				GClass104 gclass = this.list_1[j];
				string text = this.vmethod_0(gclass.byte_0[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				gclass.method_1(text);
				if (gclass.int_2 == 10455)
				{
					this.string_7 = text;
					GClass126.smethod_2("ECU ISO Code: " + text, 0);
				}
			}
			if (this.genum0_0 == (GEnum0)2)
			{
				Thread.Sleep(200);
				this.list_4 = this.r1();
			}
			if (this.genum0_0 == (GEnum0)4)
			{
				Thread.Sleep(100);
				this.r2();
				Thread.Sleep(100);
				this.list_4 = this.r1();
			}
			if (this.genum0_0 != (GEnum0)0)
			{
				base.method_30(false);
			}
			else
			{
				if (GClass125.int_18[1] == 0 && GClass126.bool_13 && GClass123.int_6 == 0)
				{
					bool flag = true;
					if (GClass125.smethod_5().StartsWith(GClass122.smethod_2()))
					{
						GClass126.bool_13 = false;
					}
					else if (GClass125.int_18[4] == 4)
					{
						GClass126.bool_13 = false;
					}
					else
					{
						flag = false;
					}
					if (flag)
					{
						GClass126.smethod_2(">Start 36", 0);
					}
				}
				this.bool_0 = true;
				base.method_36();
			}
		}
		catch (Exception ex)
		{
			if (ex.Message == "ESC")
			{
				this.string_8 = GClass121.smethod_6("6060");
			}
			GClass126.smethod_2(ex.Message, 1);
			GClass126.smethod_2("Terminate 4", 1);
			this.r0(ex.Message != "0", ex.Message == "ESC");
		}
	}

	// Token: 0x0600020C RID: 524 RVA: 0x00035F38 File Offset: 0x00034138
	public override List<GClass102> r1()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_4;
		}
		else
		{
			array = this.method_53(this.byte_5);
		}
		if (array.Length < 3)
		{
			GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
			GClass126.smethod_2("Force KA", 1);
			this.int_0 -= this.int_5;
			if (!this.bool_1)
			{
				Thread.Sleep(200);
			}
			return null;
		}
		int num = (int)array[2];
		int num2 = 0;
		int num3 = 3;
		while (num2 < num && num3 < array.Length - 2)
		{
			GClass102 gclass = new GClass102();
			gclass.string_0 = GClass127.smethod_11(new byte[]
			{
				array[num3],
				array[num3 + 1]
			}).Replace(" ", "");
			gclass.byte_0 = array[num3 + 2];
			gclass.string_5 = this.method_46(gclass.byte_0);
			gclass.string_6 = this.method_47(gclass.byte_0);
			gclass.string_7 = this.method_48(gclass.byte_0);
			gclass.bool_0 = ((gclass.byte_0 & 96) == 96);
			string str = "";
			if ((array[num3] & 192) == 0)
			{
				str = "P";
			}
			else if ((array[num3] & 192) == 64)
			{
				str = "C";
			}
			else if ((array[num3] & 192) == 128)
			{
				str = "B";
			}
			else if ((array[num3] & 192) == 192)
			{
				str = "U";
			}
			gclass.string_2 = str + GClass127.smethod_11(new byte[]
			{
				array[num3] & 63,
				array[num3 + 1]
			}).Replace(" ", "");
			if ((gclass.byte_0 & 8) != 0)
			{
				GClass102 gclass2 = gclass;
				gclass2.string_3 = gclass2.string_3 + GClass121.smethod_6("3065") + " ";
			}
			else if ((gclass.byte_0 & 4) != 0)
			{
				GClass102 gclass3 = gclass;
				gclass3.string_3 = gclass3.string_3 + GClass121.smethod_6("3066") + " ";
			}
			else if ((gclass.byte_0 & 2) != 0)
			{
				GClass102 gclass4 = gclass;
				gclass4.string_3 = gclass4.string_3 + GClass121.smethod_6("3067") + " ";
			}
			else if ((gclass.byte_0 & 1) != 0)
			{
				GClass102 gclass5 = gclass;
				gclass5.string_3 = gclass5.string_3 + GClass121.smethod_6("3068") + " ";
			}
			if ((gclass.byte_0 & 96) == 0)
			{
				GClass102 gclass6 = gclass;
				gclass6.string_3 = gclass6.string_3 + GClass121.smethod_6("3075") + " ";
			}
			else if ((gclass.byte_0 & 96) == 32)
			{
				GClass102 gclass7 = gclass;
				gclass7.string_3 = gclass7.string_3 + GClass121.smethod_6("3076") + " ";
			}
			else if ((gclass.byte_0 & 96) == 64)
			{
				GClass102 gclass8 = gclass;
				gclass8.string_3 = gclass8.string_3 + GClass121.smethod_6("3077") + " ";
			}
			else if ((gclass.byte_0 & 96) == 96)
			{
				GClass102 gclass9 = gclass;
				gclass9.string_3 = gclass9.string_3 + GClass121.smethod_6("3078") + " ";
			}
			if ((gclass.byte_0 & 128) == 0)
			{
				GClass102 gclass10 = gclass;
				gclass10.string_3 = gclass10.string_3 + GClass121.smethod_6("3073") + " ";
			}
			else
			{
				GClass102 gclass11 = gclass;
				gclass11.string_3 = gclass11.string_3 + GClass121.smethod_6("3074") + " ";
			}
			list.Add(gclass);
			num3 += 3;
		}
		return list;
	}

	// Token: 0x0600020D RID: 525 RVA: 0x00009148 File Offset: 0x00007348
	private string method_46(byte byte_8)
	{
		string result = "";
		if ((byte_8 & 8) != 0)
		{
			result = GClass121.smethod_6("3056");
		}
		else if ((byte_8 & 4) != 0)
		{
			result = GClass121.smethod_6("3057");
		}
		else if ((byte_8 & 2) != 0)
		{
			result = GClass121.smethod_6("3058");
		}
		else if ((byte_8 & 1) != 0)
		{
			result = GClass121.smethod_6("3059");
		}
		return result;
	}

	// Token: 0x0600020E RID: 526 RVA: 0x000091A4 File Offset: 0x000073A4
	private string method_47(byte byte_8)
	{
		string result = "";
		if ((byte_8 & 96) == 0)
		{
			result = GClass121.smethod_6("3052");
		}
		else if ((byte_8 & 96) == 32)
		{
			result = GClass121.smethod_6("3053");
		}
		else if ((byte_8 & 96) == 64)
		{
			result = GClass121.smethod_6("3054");
		}
		else if ((byte_8 & 96) == 96)
		{
			result = GClass121.smethod_6("3055");
		}
		return result;
	}

	// Token: 0x0600020F RID: 527 RVA: 0x00006FC4 File Offset: 0x000051C4
	private string method_48(byte byte_8)
	{
		string result = "";
		if ((byte_8 & 128) != 0)
		{
			result = GClass121.smethod_6("3051");
		}
		return result;
	}

	// Token: 0x06000210 RID: 528 RVA: 0x000362E4 File Offset: 0x000344E4
	public override void r2()
	{
		if (GClass126.bool_0)
		{
			this.byte_4 = new byte[]
			{
				2,
				88,
				0,
				90
			};
			return;
		}
		byte[] array = this.method_53(this.byte_6);
		if (array.Length < 3 || array[1] != 84)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x06000211 RID: 529 RVA: 0x00036338 File Offset: 0x00034538
	public override void r7(List<GClass102> list_6, List<GClass104> list_7)
	{
		if (list_6 != null && list_7 != null && list_6.Count != 0 && list_7.Count != 0)
		{
			int num = this.string_22.Length;
			SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
			foreach (GClass102 gclass in list_6)
			{
				if (!(gclass.string_4 != ""))
				{
					if (num > 0)
					{
						num--;
					}
					sortedList.Clear();
					try
					{
						foreach (GClass104 gclass2 in list_7)
						{
							if (gclass2.string_1.Contains("*") || gclass2.string_1.Contains("[" + gclass.string_0 + "]"))
							{
								string text = GClass127.smethod_11(gclass2.byte_0[0]);
								text = text.Replace("00 00", gclass.string_0);
								byte[] byte_ = GClass127.smethod_32(text);
								byte[] value = new byte[0];
								if (GClass126.bool_0)
								{
									value = GClass127.smethod_32(this.string_22[num]);
								}
								else if (sortedList.ContainsKey(text))
								{
									value = sortedList[text];
								}
								else
								{
									value = this.method_53(byte_);
									sortedList.Add(text, value);
								}
								gclass2.method_1(this.r4(value, gclass2.string_2, gclass2.int_0, gclass2.int_1, gclass2.string_5, gclass2.string_6));
								GClass102 gclass3 = gclass;
								gclass3.string_4 = string.Concat(new string[]
								{
									gclass3.string_4,
									gclass2.string_0,
									": ",
									gclass2.method_0(),
									" ",
									gclass2.string_3,
									Environment.NewLine
								});
							}
						}
						if (gclass.string_4 != "")
						{
							gclass.string_4 = GClass121.smethod_6("3047") + Environment.NewLine + gclass.string_4;
						}
					}
					catch (Exception)
					{
						GClass126.smethod_2("ERROR: Error reading DTC details", 0);
					}
				}
			}
			return;
		}
	}

	// Token: 0x06000212 RID: 530 RVA: 0x000365C4 File Offset: 0x000347C4
	protected override void r3(GClass104 gclass104_1)
	{
		if (GClass126.bool_0)
		{
			if (!gclass104_1.string_2.Contains("NOWAIT"))
			{
				Thread.Sleep(3000);
			}
			if (gclass104_1.string_2.Contains("FUNC"))
			{
				base.method_28(true, GClass121.smethod_6("6051"), GClass121.smethod_6("6055") + " 00");
				return;
			}
			base.method_28(false, GClass121.smethod_6("6051"), "");
			return;
		}
		else
		{
			if (gclass104_1.string_2.Contains("FUNC"))
			{
				this.method_50(gclass104_1);
				return;
			}
			if (gclass104_1.string_2.Contains("RWUSERENTRY"))
			{
				this.method_51(gclass104_1);
				return;
			}
			this.method_49(gclass104_1);
			return;
		}
	}

	// Token: 0x06000213 RID: 531 RVA: 0x00036680 File Offset: 0x00034880
	private void method_49(GClass104 gclass104_1)
	{
		int num = 20;
		if (gclass104_1.string_2.Contains("0.5SEC"))
		{
			num = 5;
		}
		else if (gclass104_1.string_2.Contains("1SEC"))
		{
			num = 10;
		}
		else if (gclass104_1.string_2.Contains("20SEC"))
		{
			num = 200;
		}
		else if (gclass104_1.string_2.Contains("50SEC"))
		{
			num = 500;
		}
		else if (gclass104_1.string_2.Contains("NOWAIT"))
		{
			num = 0;
		}
		else if (gclass104_1.byte_0.Length == 2)
		{
			num = 3 * num;
		}
		else if (gclass104_1.byte_0.Length == 1)
		{
			num = 4 * num;
		}
		bool flag = gclass104_1.string_2.Contains("EXECANY");
		bool flag2 = gclass104_1.byte_0.Length > 1 && !gclass104_1.string_2.Contains("NOABORT");
		bool flag3 = gclass104_1.string_2.Contains("LASTCMDBITRESULT");
		if (gclass104_1.string_2.Contains("NOKEEPALIVE"))
		{
			this.bool_3 = true;
		}
		string text = "";
		string text2 = "";
		for (int i = 0; i < gclass104_1.byte_0.Length; i++)
		{
			if (gclass104_1.byte_0[i][0] == 255)
			{
				int num2 = 10 * (256 * (int)gclass104_1.byte_0[i][1] + (int)gclass104_1.byte_0[i][2]);
				for (int j = 0; j < num2; j++)
				{
					if (GClass126.bool_25)
					{
						break;
					}
					Thread.Sleep(100);
				}
			}
			else if (gclass104_1.byte_0[i][0] == 254)
			{
				int num3 = (int)gclass104_1.byte_0[i][2];
				int num4 = (int)gclass104_1.byte_0[i][1];
				string text3 = gclass104_1.string_5[num3].Substring(4);
				if (num4 == 0)
				{
					base.method_26(text3);
				}
				else if (num4 == 1)
				{
					base.method_26(text3);
					GClass126.bool_24 = false;
					for (int k = 0; k < 600; k++)
					{
						if (GClass126.bool_25 && flag2)
						{
							GClass126.smethod_2(GClass121.smethod_6("6081"), 2);
							this.method_53(gclass104_1.byte_0[gclass104_1.byte_0.Length - 1]);
							base.method_28(false, GClass121.smethod_6("6082"), " ");
							return;
						}
						if (GClass126.bool_24)
						{
							break;
						}
						Thread.Sleep(100);
					}
				}
			}
			else
			{
				byte[] array = this.method_53(gclass104_1.byte_0[i]);
				if (text == "" && (array.Length == 0 || (array.Length > 1 && array[1] == 127)))
				{
					if (array.Length < 4)
					{
						text = "";
					}
					else if (array[3] == 34)
					{
						text = GClass121.smethod_6("6053");
					}
					else if (array[3] == 17)
					{
						text = GClass121.smethod_6("6054");
					}
					else if (array[3] == 49)
					{
						text = GClass121.smethod_6("6507");
					}
					else if (array[3] == 120)
					{
						text = GClass121.smethod_6("6502");
					}
					else if (array[3] == 16)
					{
						text = GClass121.smethod_6("6503");
					}
					else if (array[3] == 18)
					{
						text = GClass121.smethod_6("6504");
					}
					else if (array[3] == 33)
					{
						text = GClass121.smethod_6("6505");
					}
					else if (array[3] == 36)
					{
						text = "Incorrect sequence";
					}
					else if (array[3] == 129)
					{
						text = "RPM too high";
					}
					else if (array[3] == 130)
					{
						text = "RPM too low";
					}
					else if (array[3] == 131)
					{
						text = "Engine running";
					}
					else if (array[3] == 132)
					{
						text = "Engine not running";
					}
					else if (array[3] == 133)
					{
						text = "Engine run time not enough";
					}
					else if (array[3] == 134)
					{
						text = "Temperature too high";
					}
					else if (array[3] == 135)
					{
						text = "Temperature too low";
					}
					else if (array[3] == 136)
					{
						text = "Vehicle speed too high";
					}
					else if (array[3] == 137)
					{
						text = "Vehicle speed too low";
					}
					else if (array[3] == 138)
					{
						text = "Throttle/pedal too high";
					}
					else if (array[3] == 139)
					{
						text = "Throttle/pedal too low";
					}
					else if (array[3] == 140)
					{
						text = "Transmission in Neutral";
					}
					else if (array[3] == 141)
					{
						text = "Transmission in gear";
					}
					else if (array[3] == 143)
					{
						text = "Brake pedal";
					}
					else if (array[3] == 144)
					{
						text = "Transmission not in Park";
					}
					else if (array[3] == 145)
					{
						text = "Torque converter locked";
					}
					else if (array[3] == 146)
					{
						text = "Voltage too high";
					}
					else if (array[3] == 147)
					{
						text = "Voltage too low";
					}
					else
					{
						text = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
					}
					if (!flag)
					{
						base.method_28(false, GClass121.smethod_6("6052"), text);
						this.bool_3 = false;
						return;
					}
				}
				if (i < gclass104_1.byte_0.Length - 1 || gclass104_1.byte_0.Length == 1)
				{
					for (int l = 0; l < num; l++)
					{
						if (GClass126.bool_25 && flag2)
						{
							GClass126.smethod_2(GClass121.smethod_6("6081"), 2);
							array = this.method_53(gclass104_1.byte_0[gclass104_1.byte_0.Length - 1]);
							base.method_28(false, GClass121.smethod_6("6082"), " ");
							this.bool_3 = false;
							return;
						}
						Thread.Sleep(100);
					}
				}
				if (i == gclass104_1.byte_0.Length - 1 && flag3)
				{
					text2 = GClass121.smethod_6("6056");
					if (array.Length > 2 + gclass104_1.int_0 && gclass104_1.string_5.Length != 0)
					{
						byte b = array[3 + gclass104_1.int_0];
						int m = 0;
						while (m < gclass104_1.string_5.Length)
						{
							byte b2 = byte.Parse(gclass104_1.string_5[m].Substring(0, 2), NumberStyles.HexNumber);
							byte b3 = byte.Parse(gclass104_1.string_5[m].Substring(2, 2), NumberStyles.HexNumber);
							if ((b & b2) != b3)
							{
								if (m != gclass104_1.string_5.Length - 1)
								{
									m++;
									continue;
								}
							}
							text2 = gclass104_1.string_5[m].Substring(4);
							break;
						}
					}
				}
			}
		}
		this.bool_3 = false;
		if (text2 != "")
		{
			base.method_28(false, GClass121.smethod_6("6051"), text2);
			return;
		}
		if (text == "" || flag)
		{
			base.method_28(false, GClass121.smethod_6("6051"), text);
			return;
		}
		base.method_28(false, GClass121.smethod_6("6052"), text);
	}

	// Token: 0x06000214 RID: 532 RVA: 0x00036D7C File Offset: 0x00034F7C
	private void method_50(GClass104 gclass104_1)
	{
		byte[] array = this.method_53(gclass104_1.byte_0[0]);
		if (array.Length > 1 && array[1] == 127)
		{
			string string_ = "";
			if (array.Length < 4)
			{
				string_ = "";
			}
			else if (array[3] == 34)
			{
				string_ = GClass121.smethod_6("6053");
			}
			else if (array[3] == 17)
			{
				string_ = GClass121.smethod_6("6054");
			}
			else if (array[3] == 18)
			{
				string_ = GClass121.smethod_6("6504");
			}
			else if (array[3] == 49)
			{
				string_ = GClass121.smethod_6("6507");
			}
			else if (array[3] == 33)
			{
				string_ = GClass121.smethod_6("6505");
			}
			else if (array[3] > 0)
			{
				string_ = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
			}
			base.method_28(false, GClass121.smethod_6("6052"), string_);
			return;
		}
		byte[] array2 = new byte[3];
		array2[0] = 2;
		array2[1] = 51;
		byte[] array3 = array2;
		array3[2] = gclass104_1.byte_0[0][2];
		byte[] array4 = new byte[3];
		array4[0] = 2;
		array4[1] = 50;
		byte[] array5 = array4;
		array5[2] = gclass104_1.byte_0[0][2];
		if (gclass104_1.byte_0.Length > 1)
		{
			array3 = GClass127.smethod_32(GClass127.smethod_11(gclass104_1.byte_0[1]));
		}
		if (gclass104_1.byte_0.Length > 2)
		{
			array5 = GClass127.smethod_32(GClass127.smethod_11(gclass104_1.byte_0[2]));
		}
		int num = 1800;
		bool flag = true;
		IL_1F2:
		while (num > 0 && flag)
		{
			for (int i = 0; i < 5; i++)
			{
				if (GClass126.bool_25)
				{
					GClass126.smethod_2("Aborting routine...", 2);
					array = this.method_53(array5);
					num = 0;
					IL_195:
					GClass126.smethod_2("Checking routine status..", 1);
					array = this.method_53(array3);
					if (array.Length == 0)
					{
						Thread.Sleep(800);
						if (this.bool_1)
						{
							return;
						}
						array = this.method_53(array3);
					}
					if (array.Length <= 3 || array[1] != 127 || array[2] != 51 || (array[3] != 33 && array[3] != 35))
					{
						flag = false;
					}
					num--;
					goto IL_1F2;
				}
				Thread.Sleep(100);
			}
			goto IL_195;
		}
		string string_2 = GClass121.smethod_6("6056");
		if (gclass104_1.byte_0.Length > 3)
		{
			if (gclass104_1.string_2.Contains("FUNCW"))
			{
				string_2 = this.vmethod_0(gclass104_1.byte_0[3], "bitw", gclass104_1.int_0, gclass104_1.int_1, gclass104_1.string_5, gclass104_1.string_6);
			}
			else
			{
				string_2 = this.vmethod_0(gclass104_1.byte_0[3], "bits", gclass104_1.int_0, gclass104_1.int_1, gclass104_1.string_5, gclass104_1.string_6);
			}
		}
		else if (array.Length > 3 && array[1] == 115)
		{
			if (gclass104_1.string_5.Length != 0 && gclass104_1.string_2.Contains("FUNCW") && array.Length > 4)
			{
				byte b = array[3];
				byte b2 = array[4];
				this.string_10 = GClass127.smethod_23(b);
				string_2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b) + GClass127.smethod_23(b2);
				int j = 0;
				while (j < gclass104_1.string_5.Length)
				{
					byte b3 = byte.Parse(gclass104_1.string_5[j].Substring(0, 2), NumberStyles.HexNumber);
					byte b4 = byte.Parse(gclass104_1.string_5[j].Substring(2, 2), NumberStyles.HexNumber);
					byte b5 = byte.Parse(gclass104_1.string_5[j].Substring(4, 2), NumberStyles.HexNumber);
					byte b6 = byte.Parse(gclass104_1.string_5[j].Substring(6, 2), NumberStyles.HexNumber);
					if ((b & b3) != b5 || (b2 & b4) != b6)
					{
						if (j != gclass104_1.string_5.Length - 1)
						{
							j++;
							continue;
						}
					}
					string_2 = gclass104_1.string_5[j].Substring(8);
					break;
				}
			}
			else if (gclass104_1.string_5.Length != 0 && !gclass104_1.string_2.Contains("FUNCW"))
			{
				byte b7 = array[3];
				if (gclass104_1.int_0 == 2 && array.Length > 4)
				{
					b7 = array[4];
				}
				this.string_10 = GClass127.smethod_23(b7);
				string_2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b7);
				int k = 0;
				while (k < gclass104_1.string_5.Length)
				{
					byte b8 = byte.Parse(gclass104_1.string_5[k].Substring(0, 2), NumberStyles.HexNumber);
					byte b9 = byte.Parse(gclass104_1.string_5[k].Substring(2, 2), NumberStyles.HexNumber);
					if ((b7 & b8) != b9)
					{
						if (k != gclass104_1.string_5.Length - 1)
						{
							k++;
							continue;
						}
					}
					string_2 = gclass104_1.string_5[k].Substring(4);
					break;
				}
			}
			else if (array.Length == 4)
			{
				string_2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
			}
			else if (array.Length == 5)
			{
				string_2 = string.Concat(new string[]
				{
					GClass121.smethod_6("6055"),
					" ",
					GClass127.smethod_23(array[3]),
					" ",
					GClass127.smethod_23(array[4])
				});
			}
			else if (array.Length > 5)
			{
				string_2 = string.Concat(new string[]
				{
					GClass121.smethod_6("6055"),
					" ",
					GClass127.smethod_23(array[3]),
					" ",
					GClass127.smethod_23(array[4]),
					" ",
					GClass127.smethod_23(array[5])
				});
			}
		}
		base.method_28(true, GClass121.smethod_6("6051"), string_2);
	}

	// Token: 0x06000215 RID: 533 RVA: 0x00037330 File Offset: 0x00035530
	private void method_51(GClass104 gclass104_1)
	{
		byte[] array = this.method_53(gclass104_1.byte_0[0]);
		if (array.Length < 4)
		{
			string string_ = "";
			base.method_28(false, GClass121.smethod_6("6052"), string_);
			return;
		}
		for (int i = 3; i < gclass104_1.byte_0[1].Length; i++)
		{
			byte b = 0;
			if (array.Length > i)
			{
				b = array[i];
			}
			if (gclass104_1.int_0 <= i - 2 && gclass104_1.int_0 + gclass104_1.int_1 > i - 2)
			{
				byte b2 = gclass104_1.byte_0[1][i];
				byte b3 = byte.Parse(gclass104_1.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
				if (gclass104_1.string_2.Contains("RWUSERENTRYH"))
				{
					b3 = byte.MaxValue;
				}
				b3 ^= byte.MaxValue;
				b &= b3;
				b |= b2;
			}
			gclass104_1.byte_0[1][i] = b;
			if (gclass104_1.string_2.Contains("RWUSERENTRYA") && gclass104_1.byte_0.Length > 2)
			{
				gclass104_1.byte_0[2][i] = b;
			}
			if (gclass104_1.string_2.Contains("RWUSERENTRYA") && gclass104_1.byte_0.Length > 3)
			{
				gclass104_1.byte_0[3][i] = b;
			}
		}
		Thread.Sleep(1000);
		array = this.method_53(gclass104_1.byte_0[1]);
		if (array.Length != 0 && (array.Length <= 1 || array[1] != 127) && (array.Length != 1 || array[0] != 0 || gclass104_1.byte_0[1].Length <= 8))
		{
			int num = 5;
			if (gclass104_1.string_2.Contains("0.5SEC"))
			{
				num = 5;
			}
			else if (gclass104_1.string_2.Contains("1SEC"))
			{
				num = 10;
			}
			else if (gclass104_1.string_2.Contains("20SEC"))
			{
				num = 200;
			}
			else if (gclass104_1.string_2.Contains("50SEC"))
			{
				num = 500;
			}
			else if (gclass104_1.string_2.Contains("NOWAIT"))
			{
				num = 0;
			}
			bool flag = gclass104_1.string_2.Contains("EXECANY");
			for (int j = 2; j < gclass104_1.byte_0.Length; j++)
			{
				array = this.method_53(gclass104_1.byte_0[j]);
				if (!flag)
				{
					if (array.Length != 0)
					{
						if (array.Length <= 1 || array[1] != 127)
						{
							goto IL_237;
						}
					}
					string string_2 = "";
					if (array.Length > 3 && array[3] == 34)
					{
						string_2 = GClass121.smethod_6("6053");
					}
					else if (array.Length > 3 && array[3] == 17)
					{
						string_2 = GClass121.smethod_6("6054");
					}
					base.method_28(false, GClass121.smethod_6("6052"), string_2);
					return;
				}
				IL_237:
				if (j < gclass104_1.byte_0.Length - 1 || gclass104_1.byte_0.Length == 1)
				{
					for (int k = 0; k < num; k++)
					{
						Thread.Sleep(100);
					}
				}
			}
			Thread.Sleep(600);
			base.method_28(false, GClass121.smethod_6("6051"), "");
			return;
		}
		string string_3 = "";
		if (array.Length > 3 && array[3] == 34)
		{
			string_3 = GClass121.smethod_6("6053");
		}
		else if (array.Length > 3 && array[3] == 17)
		{
			string_3 = GClass121.smethod_6("6054");
		}
		else if (array.Length == 1 && array[0] == 0 && gclass104_1.byte_0[1].Length > 8)
		{
			string_3 = "The interface does not support this operation!";
		}
		base.method_28(false, GClass121.smethod_6("6052"), string_3);
	}

	// Token: 0x06000216 RID: 534 RVA: 0x00037698 File Offset: 0x00035898
	public override string vmethod_0(byte[] byte_8, string string_23, int int_7, int int_8, string[] string_24, string string_25)
	{
		byte[] array = this.method_53(byte_8);
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_53(byte_8);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_53(byte_8);
		}
		if (array.Length > 3 && array[1] == 127 && array[3] == 33)
		{
			array = this.method_53(byte_8);
		}
		if (string_23 == "raw")
		{
			return GClass127.smethod_11(array);
		}
		return this.r4(array, string_23, int_7, int_8, string_24, string_25);
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00037724 File Offset: 0x00035924
	private byte[] method_52(byte[] byte_8)
	{
		if (this.serialPort_0 != null && this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		if (GClass125.smethod_49() && byte_8.Length == 2 && byte_8[0] == 255)
		{
			this.r9("ATGR" + GClass127.smethod_23(byte_8[1]));
		}
		else if (GClass125.smethod_49() && byte_8.Length == 2 && byte_8[0] == 1 && byte_8[1] == 62)
		{
			this.r9("ATGR07");
		}
		else
		{
			byte[] array = new byte[byte_8.Length - 1];
			for (int i = 1; i < byte_8.Length; i++)
			{
				array[i - 1] = byte_8[i];
			}
			if (array.Length != 0 && (array[0] == 33 || array[0] == 26 || array[0] == 62))
			{
				this.r9(GClass127.smethod_11(array) + " 1");
			}
			else
			{
				this.r9(GClass127.smethod_11(array));
			}
		}
		string text = this.rb();
		if (!text.Contains("NO DATA") && !text.Contains("ERROR"))
		{
			string text2 = "";
			StringBuilder stringBuilder = new StringBuilder();
			int j = 0;
			while (j < text.Length)
			{
				if (text[j] == '\r' || text[j] == '\n')
				{
					goto IL_150;
				}
				if (text[j] == '>')
				{
					goto IL_150;
				}
				stringBuilder.Append(text[j]);
				IL_166:
				j++;
				continue;
				IL_150:
				if (stringBuilder.Length > 1)
				{
					text2 = stringBuilder.ToString();
				}
				stringBuilder = new StringBuilder();
				goto IL_166;
			}
			if (!this.bool_6)
			{
				text2 = "00" + text2;
			}
			GClass126.smethod_2("DECODED RESPONSE: " + text2, 0);
			return GClass127.smethod_32(text2);
		}
		if (!this.bool_0)
		{
			this.string_9 = text.Replace("\r", "").Replace("\n", "").Replace(">", "");
		}
		return new byte[0];
	}

	// Token: 0x06000218 RID: 536 RVA: 0x00037918 File Offset: 0x00035B18
	private byte[] method_53(byte[] byte_8)
	{
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			if (GClass125.smethod_44() == 4 || GClass125.smethod_44() == 5)
			{
				while (this.int_0 + this.int_6 > GClass126.smethod_1())
				{
				}
			}
			this.int_0 = GClass126.smethod_1();
			byte[] array = this.method_52(byte_8);
			if (array.Length == 0 || (array.Length > 3 && array[1] == 127 && array[3] == 33))
			{
				array = this.method_52(byte_8);
			}
			if (array.Length == 0 || (array.Length > 3 && array[1] == 127 && array[3] == 33))
			{
				Thread.Sleep(100);
				array = this.method_52(byte_8);
			}
			this.int_0 = GClass126.smethod_1();
			this.int_1 = 0;
			this.bool_2 = false;
			result = array;
		}
		catch (Exception ex)
		{
			if (!this.bool_1)
			{
				GClass126.smethod_2(ex.Message + "(3)", 1);
				this.int_1++;
				this.bool_2 = false;
				if (this.int_1 > 3)
				{
					this.string_8 = "DE";
					GClass126.smethod_2("Terminate 5", 1);
					base.method_30(true);
				}
			}
			this.bool_2 = false;
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x06000219 RID: 537 RVA: 0x00037A54 File Offset: 0x00035C54
	public override string r4(byte[] byte_8, string string_23, int int_7, int int_8, string[] string_24, string string_25)
	{
		string result = "";
		int_7 += 2;
		if (byte_8.Length <= int_7)
		{
			return result;
		}
		if (byte_8[1] == 127)
		{
			return result;
		}
		int num = byte_8.Length - int_7;
		if (int_8 < num)
		{
			num = int_8;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_8[i + int_7];
		}
		return base.method_33(array, string_23, string_24, string_25);
	}

	// Token: 0x0600021A RID: 538 RVA: 0x00037AB8 File Offset: 0x00035CB8
	private void method_54()
	{
		GClass126.smethod_2("PM started", 1);
		GClass126.int_3 = 0;
		int num = 0;
		long num2 = 0L;
		SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
		while (!this.bool_1)
		{
			Thread.Sleep(40);
			if (!GClass126.bool_0)
			{
				if (GClass125.smethod_48())
				{
					if (this.tcpClient_0 == null)
					{
						GClass126.smethod_2("PM stopped(1)", 1);
						return;
					}
				}
				else
				{
					if (GClass125.smethod_52())
					{
						if (this.bluetoothLEDevice_0 != null)
						{
							if (this.gattDeviceService_0 != null)
							{
								goto IL_84;
							}
						}
						GClass126.smethod_2("PM stopped(1)", 1);
						return;
					}
					if (this.serialPort_0 == null || !this.serialPort_0.IsOpen)
					{
						GClass126.smethod_2("PM stopped(1)", 1);
						return;
					}
				}
			}
			IL_84:
			if (GClass126.smethod_1() > GClass126.int_3 + GClass126.int_5 && !this.bool_2)
			{
				GClass126.int_3 = GClass126.smethod_1();
				num++;
				if (!GClass126.bool_22)
				{
					num = 0;
					Thread.Sleep(100);
				}
				else
				{
					for (int i = 0; i < this.list_0.Count; i++)
					{
						GClass104 gclass = this.list_0[i];
						if (gclass.bool_0 && (!GClass126.bool_12 || num % gclass.int_3 == 0))
						{
							if (GClass126.bool_0)
							{
								byte[][] array = new byte[][]
								{
									new byte[]
									{
										4,
										97,
										72,
										1,
										14
									},
									new byte[]
									{
										13,
										90,
										145,
										53,
										53,
										49,
										56,
										56,
										50,
										49,
										52,
										32,
										32,
										32
									},
									new byte[]
									{
										13,
										90,
										146,
										48,
										50,
										56,
										49,
										48,
										49,
										49,
										52,
										50,
										49,
										32
									},
									new byte[]
									{
										3,
										90,
										147,
										0
									},
									new byte[]
									{
										13,
										90,
										148,
										49,
										48,
										51,
										55,
										51,
										54,
										55,
										55,
										57,
										48,
										32
									},
									new byte[]
									{
										4,
										90,
										149,
										160,
										68
									},
									new byte[]
									{
										6,
										90,
										153,
										32,
										3,
										7,
										19
									},
									new byte[]
									{
										6,
										90,
										5,
										9,
										17,
										31,
										37,
										9,
										17,
										31,
										33,
										21
									}
								};
								gclass.method_1(this.random_0.Next(0, 100).ToString() ?? "");
								if (gclass.string_3 == "V")
								{
									gclass.method_1(this.r4(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.string_2.StartsWith("bits"))
								{
									gclass.method_1(this.r4(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.string_2.StartsWith("bitchars"))
								{
									gclass.method_1(this.r4(array[7], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								Thread.Sleep(50);
							}
							else
							{
								if (sortedList.ContainsKey(GClass127.smethod_11(gclass.byte_0[0])))
								{
									byte[] array2 = sortedList[GClass127.smethod_11(gclass.byte_0[0])];
									gclass.method_1(this.r4(array2, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else
								{
									byte[] array3 = this.method_53(gclass.byte_0[0]);
									gclass.method_1(this.r4(array3, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									sortedList.Add(GClass127.smethod_11(gclass.byte_0[0]), array3);
									if (array3.Length != 0)
									{
										num2 = (long)GClass126.smethod_1();
									}
									if ((long)GClass126.smethod_1() > num2 + 5000L)
									{
										GClass126.smethod_2("Force KA", 1);
										this.int_0 -= this.int_5;
										if (!this.bool_1)
										{
											Thread.Sleep(200);
										}
									}
								}
								if (this.bool_1)
								{
									GClass126.smethod_2("PM stopped(2)", 1);
									return;
								}
							}
						}
					}
					if (GClass126.bool_16)
					{
						List<GClass102> list = this.r1();
						if (list != null)
						{
							string text = "";
							for (int j = 0; j < list.Count; j++)
							{
								text = text + list[j].method_0() + " ";
							}
							this.string_11 = text;
						}
					}
					else
					{
						this.string_11 = "";
					}
					if (GClass126.bool_12 && GClass126.list_1.Count > 0)
					{
						GClass126.smethod_0().method_2(GClass126.smethod_1());
					}
					this.bool_4 = true;
					int num3 = GClass126.smethod_1() - GClass126.int_3;
					if (num3 > GClass126.int_6)
					{
						GClass126.int_6 = num3;
					}
					if (!GClass126.bool_12)
					{
						if (num3 < GClass126.int_6)
						{
							GClass126.int_6 = num3;
						}
						GClass126.int_5 = GClass126.int_6;
					}
					sortedList.Clear();
				}
			}
		}
		GClass126.smethod_2("PM stopped", 1);
	}

	// Token: 0x0600021B RID: 539 RVA: 0x00037FC8 File Offset: 0x000361C8
	private void method_55()
	{
		GClass126.smethod_2("KA started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(20);
			if (GClass125.smethod_48())
			{
				if (this.tcpClient_0 == null)
				{
					GClass126.smethod_2("KA stopped(1)", 1);
					GClass126.smethod_2("Terminate 8", 1);
					base.method_30(true);
					return;
				}
			}
			else
			{
				if (GClass125.smethod_52())
				{
					if (this.bluetoothLEDevice_0 != null)
					{
						if (this.gattDeviceService_0 != null)
						{
							goto IL_65;
						}
					}
					GClass126.smethod_2("KA stopped(1)", 1);
					GClass126.smethod_2("Terminate 8", 1);
					base.method_30(true);
					return;
				}
				if (this.serialPort_0 == null || !this.serialPort_0.IsOpen)
				{
					GClass126.smethod_2("KA stopped(1)", 1);
					GClass126.smethod_2("Terminate 8", 1);
					base.method_30(true);
					return;
				}
			}
			IL_65:
			if (GClass126.smethod_1() > this.int_0 + this.int_5 && !this.bool_2)
			{
				byte[] array = this.method_53(this.byte_3);
				if (!this.bool_3 && (array.Length < 2 || array[1] != 126))
				{
					GClass126.smethod_2("KA response error!", 1);
					if (array.Length == 0)
					{
						array = this.method_53(this.byte_3);
						if (array.Length == 0)
						{
							this.string_8 = "KA";
							GClass126.smethod_2("Terminate 7", 1);
							base.method_30(true);
						}
					}
				}
			}
		}
		GClass126.smethod_2("KA stopped", 1);
	}

	// Token: 0x0600021C RID: 540 RVA: 0x00038128 File Offset: 0x00036328
	protected GClass81()
	{
		byte[] array = new byte[4];
		array[0] = 3;
		array[1] = 23;
		this.byte_7 = array;
		this.string_22 = new string[]
		{
			"0C 57 01 01 10 61 24 A7 1D 08 2D FF 40",
			"00 00 00 38 22 99 12 65 29 81 02 00",
			"00 00 00 95 18 24 76 4A 6B 1F 00 00"
		};
		base..ctor();
	}

	// Token: 0x04000182 RID: 386
	private int int_5 = 1000;

	// Token: 0x04000183 RID: 387
	private byte[] byte_3 = new byte[]
	{
		1,
		62
	};

	// Token: 0x04000184 RID: 388
	protected int int_6;

	// Token: 0x04000185 RID: 389
	private byte[] byte_4 = new byte[]
	{
		5,
		88,
		3,
		7,
		4,
		56,
		21,
		85,
		50,
		2,
		53,
		48,
		161
	};

	// Token: 0x04000186 RID: 390
	private byte[] byte_5 = new byte[]
	{
		4,
		24,
		0,
		byte.MaxValue,
		0
	};

	// Token: 0x04000187 RID: 391
	private byte[] byte_6 = new byte[]
	{
		3,
		20,
		byte.MaxValue,
		0
	};

	// Token: 0x04000188 RID: 392
	private byte[] byte_7;

	// Token: 0x04000189 RID: 393
	protected bool bool_6;

	// Token: 0x0400018A RID: 394
	private string[] string_22;
}
