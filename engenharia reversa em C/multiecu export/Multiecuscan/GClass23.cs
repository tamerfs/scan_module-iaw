using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

// Token: 0x02000016 RID: 22
public abstract class GClass23 : GClass11
{
	// Token: 0x06000137 RID: 311 RVA: 0x0001DFA0 File Offset: 0x0001C1A0
	public override void r2()
	{
		if (this.string_0 == "GPEC410" || this.string_0 == "GPEC413" || this.string_0 == "GPEC413HEV")
		{
			this.method_46();
		}
		if (!GClass126.bool_0 && !(GClass123.string_2 != GClass123.string_3))
		{
			byte[] array = this.method_51(this.byte_7);
			if (array.Length < 2 || array[1] != 84)
			{
				GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
			return;
		}
		this.byte_5 = new byte[]
		{
			3,
			89,
			2,
			207
		};
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00009148 File Offset: 0x00007348
	private string method_45(byte byte_12)
	{
		string result = "";
		if ((byte_12 & 8) != 0)
		{
			result = GClass121.smethod_6("3056");
		}
		else if ((byte_12 & 4) != 0)
		{
			result = GClass121.smethod_6("3057");
		}
		else if ((byte_12 & 2) != 0)
		{
			result = GClass121.smethod_6("3058");
		}
		else if ((byte_12 & 1) != 0)
		{
			result = GClass121.smethod_6("3059");
		}
		return result;
	}

	// Token: 0x06000139 RID: 313 RVA: 0x0001E040 File Offset: 0x0001C240
	public override void vmethod_1()
	{
		try
		{
			GClass126.smethod_2("-----------------------", 0);
			GClass126.smethod_2("Control module (CAN29): " + GClass127.smethod_23(this.byte_0), 0);
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
				this.method_55();
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
				Thread thread = new Thread(new ThreadStart(this.method_63));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_62))
				{
					Priority = ThreadPriority.Highest
				}.Start();
			}
			this.method_51(new byte[]
			{
				3,
				34,
				32,
				35
			});
			this.method_51(new byte[]
			{
				3,
				34,
				32,
				36
			});
			byte[] array = new byte[3];
			array[0] = 2;
			array[1] = 62;
			this.method_51(array);
			SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
			for (int j = 0; j < this.list_1.Count; j++)
			{
				GClass104 gclass = this.list_1[j];
				if (sortedList.ContainsKey(GClass127.smethod_11(gclass.byte_0[0])))
				{
					byte[] array2 = sortedList[GClass127.smethod_11(gclass.byte_0[0])];
					gclass.method_1(this.r4(array2, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
				else
				{
					byte[] array3 = this.method_51(gclass.byte_0[0]);
					gclass.method_1(this.r4(array3, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					if (gclass.int_2 == 10455 && gclass.string_2 == "hex")
					{
						if (GClass127.smethod_11(array3) == "03 7F 22 31" || GClass127.smethod_11(array3) == "08 62 F1 A5 FF FF FF FF FF" || GClass127.smethod_11(array3) == "08 62 F1 A5 20 20 20 20 20" || GClass127.smethod_11(array3) == "08 62 F1 A5 00 00 00 00 00")
						{
							array3 = this.method_51(GClass127.smethod_32("03 22 F1 00"));
							gclass.method_1(this.r4(array3, "isovarver", 2, 2, gclass.string_5, gclass.string_6));
						}
						if (GClass127.smethod_11(array3) == "03 7F 22 12")
						{
							array3 = this.method_51(GClass127.smethod_32("02 1A 87"));
							gclass.method_1(this.r4(array3, "isovarver", 2, 2, gclass.string_5, gclass.string_6));
						}
					}
					sortedList.Add(GClass127.smethod_11(gclass.byte_0[0]), array3);
				}
				if (gclass.int_2 == 10455)
				{
					this.string_7 = gclass.method_0();
					GClass126.smethod_2("ECU ISO Code: " + gclass.method_0(), 0);
				}
			}
			if (this.genum0_0 == (GEnum0)3)
			{
				Thread.Sleep(200);
				byte[] byte_ = this.method_51(this.gclass104_0.byte_0[0]);
				this.string_10 = GClass127.smethod_11(byte_);
				string text = GClass127.smethod_11(this.method_51(GClass127.smethod_32("03 22 10 2A")));
				this.method_51(GClass127.smethod_32("03 22 40 AA"));
				if (this.string_10 == "" && text.Contains("6E 20 23"))
				{
					this.string_10 = text;
				}
				else if (text.Contains("0C 62 10 2A"))
				{
					this.string_9 = text;
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
			else if (GClass126.bool_13 && GClass125.smethod_5().ToUpper().StartsWith("72345-67890-A"))
			{
				GClass126.smethod_2(">Start 35", 0);
				this.string_8 = "Data file corrupted!";
				base.method_30(false);
			}
			else
			{
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
			if (ex.Message != "0" && ex.Message != "1")
			{
				GClass126.smethod_2(ex.Message, 2);
			}
			GClass126.smethod_2("Terminate 4", 1);
			this.r0(ex.Message != "0", ex.Message == "ESC");
		}
	}

	// Token: 0x0600013A RID: 314 RVA: 0x0001E544 File Offset: 0x0001C744
	private void method_46()
	{
		if (GClass126.bool_0)
		{
			this.byte_5 = new byte[]
			{
				2,
				88,
				0,
				90
			};
			return;
		}
		byte[] array = this.method_51(this.byte_10);
		if (array.Length < 3 || array[1] != 84)
		{
			GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
		}
	}

	// Token: 0x0600013B RID: 315 RVA: 0x0001E598 File Offset: 0x0001C798
	private void method_47(GClass104 gclass104_1)
	{
		int num = 0;
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
		else if (gclass104_1.string_2.Contains("30SEC"))
		{
			num = 300;
		}
		else if (gclass104_1.string_2.Contains("50SEC"))
		{
			num = 500;
		}
		else if (gclass104_1.string_2.Contains("NOWAIT"))
		{
			num = 0;
		}
		byte[] array = this.method_51(gclass104_1.byte_0[0]);
		if (array.Length > 3 && array[1] == 127 && array[3] != 120)
		{
			string text = "";
			if (array[3] == 34)
			{
				text = GClass121.smethod_6("6053");
			}
			else if (array[3] == 17)
			{
				text = GClass121.smethod_6("6054");
			}
			else if (array[3] == 18)
			{
				text = GClass121.smethod_6("6504");
			}
			else if (array[3] == 49)
			{
				text = GClass121.smethod_6("6507");
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
			else if (array[3] > 0)
			{
				text = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
			}
			base.method_28(false, GClass121.smethod_6("6052"), text);
			return;
		}
		byte[] array2 = new byte[]
		{
			4,
			49,
			3,
			0,
			0
		};
		byte[] array3 = new byte[]
		{
			4,
			49,
			2,
			0,
			0
		};
		array2[3] = gclass104_1.byte_0[0][3];
		array2[4] = gclass104_1.byte_0[0][4];
		array3[3] = gclass104_1.byte_0[0][3];
		array3[4] = gclass104_1.byte_0[0][4];
		if (gclass104_1.byte_0.Length > 1)
		{
			array2 = GClass127.smethod_32(GClass127.smethod_11(gclass104_1.byte_0[1]));
		}
		if (gclass104_1.byte_0.Length > 2)
		{
			array3 = GClass127.smethod_32(GClass127.smethod_11(gclass104_1.byte_0[2]));
		}
		int num2 = 0;
		while (num2 < num && !GClass126.bool_25)
		{
			Thread.Sleep(100);
			num2++;
		}
		int num3 = 1800;
		bool flag = true;
		IL_471:
		while (num3 > 0 && flag)
		{
			for (int i = 0; i < 5; i++)
			{
				if (GClass126.bool_25)
				{
					GClass126.smethod_2("Aborting execution...", 2);
					array = this.method_51(array3);
					num3 = 0;
					IL_3FB:
					GClass126.smethod_2("Checking routine status...", 1);
					array = this.method_51(array2);
					if (array.Length == 0)
					{
						Thread.Sleep(800);
						if (this.bool_1)
						{
							return;
						}
						array = this.method_51(array2);
					}
					if (array.Length <= 3 || array[1] != 127 || (array[3] != 33 && array[3] != 35 && array[3] != 120))
					{
						flag = false;
						if (array.Length > 3 && array[1] == 127)
						{
							Thread.Sleep(1000);
						}
					}
					num3--;
					goto IL_471;
				}
				Thread.Sleep(100);
			}
			goto IL_3FB;
		}
		string text2 = GClass121.smethod_6("6056");
		if (gclass104_1.byte_0.Length > 3)
		{
			if (gclass104_1.string_2.Contains("FUNCW"))
			{
				text2 = this.vmethod_0(gclass104_1.byte_0[3], "bitw", gclass104_1.int_0, gclass104_1.int_1, gclass104_1.string_5, gclass104_1.string_6);
			}
			else
			{
				text2 = this.vmethod_0(gclass104_1.byte_0[3], "bits", gclass104_1.int_0, gclass104_1.int_1, gclass104_1.string_5, gclass104_1.string_6);
			}
		}
		else if (array.Length > 5 && array[1] == 113)
		{
			if (gclass104_1.string_5.Length != 0 && gclass104_1.string_2.Contains("FUNCW") && array.Length > 6)
			{
				byte b = array[5];
				byte b2 = array[6];
				this.string_10 = GClass127.smethod_23(b) + GClass127.smethod_23(b2);
				text2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b) + GClass127.smethod_23(b2);
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
					text2 = gclass104_1.string_5[j].Substring(8);
					break;
				}
			}
			else if (gclass104_1.string_5.Length != 0 && !gclass104_1.string_2.Contains("FUNCW"))
			{
				byte b7 = array[5];
				if (gclass104_1.byte_0[0][0] == 5 && array.Length > 6)
				{
					b7 = array[6];
				}
				this.string_10 = GClass127.smethod_23(b7);
				text2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b7);
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
					text2 = gclass104_1.string_5[k].Substring(4);
					break;
				}
			}
			else if (array.Length == 6)
			{
				text2 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[5]);
			}
			else if (array.Length == 7)
			{
				text2 = string.Concat(new string[]
				{
					GClass121.smethod_6("6055"),
					" ",
					GClass127.smethod_23(array[5]),
					" ",
					GClass127.smethod_23(array[6])
				});
			}
			else if (array.Length > 7)
			{
				text2 = string.Concat(new string[]
				{
					GClass121.smethod_6("6055"),
					" ",
					GClass127.smethod_23(array[5]),
					" ",
					GClass127.smethod_23(array[6]),
					" ",
					GClass127.smethod_23(array[7])
				});
			}
		}
		base.method_28(true, GClass121.smethod_6("6051"), text2);
	}

	// Token: 0x0600013C RID: 316 RVA: 0x0001EDDC File Offset: 0x0001CFDC
	private void method_48(GClass104 gclass104_1)
	{
		byte[] array = this.method_51(gclass104_1.byte_0[0]);
		if (array.Length > 3 && array[1] == 127 && array[3] != 120)
		{
			string text = "";
			if (array[3] == 34)
			{
				text = GClass121.smethod_6("6053");
			}
			else if (array[3] == 17)
			{
				text = GClass121.smethod_6("6054");
			}
			else if (array[3] == 18)
			{
				text = GClass121.smethod_6("6504");
			}
			else if (array[3] == 49)
			{
				text = GClass121.smethod_6("6507");
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
			else if (array[3] > 0)
			{
				text = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
			}
			base.method_28(false, GClass121.smethod_6("6052"), text);
			return;
		}
		string string_ = "00 00 00 00 00 00 00 00 00 00 00 00 00";
		if (gclass104_1.byte_0.Length > 3)
		{
			string_ = GClass127.smethod_11(gclass104_1.byte_0[3]);
		}
		byte[] array2 = GClass127.smethod_32(string_);
		string b = "";
		if (gclass104_1.byte_0.Length > 4)
		{
			b = GClass127.smethod_11(gclass104_1.byte_0[4]);
		}
		string b2 = "";
		if (gclass104_1.byte_0.Length > 5)
		{
			b2 = GClass127.smethod_11(gclass104_1.byte_0[5]);
		}
		string text2 = "";
		if (gclass104_1.byte_0.Length > 6)
		{
			text2 = GClass127.smethod_11(gclass104_1.byte_0[6]);
		}
		bool flag = gclass104_1.string_2.Contains("FSTATUS");
		int num = 6;
		int num2 = 1800;
		bool flag2 = true;
		IL_67D:
		while (num2 > 0 && flag2)
		{
			for (int i = 0; i < 5 * num; i++)
			{
				if (GClass126.bool_25)
				{
					GClass126.smethod_2("Aborting routine...", 1);
					array = this.method_51(gclass104_1.byte_0[2]);
					num2 = 0;
					IL_35E:
					num = 1;
					GClass126.smethod_2("Checking routine status..", 1);
					array = this.method_51(gclass104_1.byte_0[1]);
					byte[] array3 = new byte[array.Length];
					for (int j = 0; j < array3.Length; j++)
					{
						byte b3 = array[j];
						if (array2.Length > j)
						{
							b3 &= array2[j];
						}
						array3[j] = b3;
					}
					string a = GClass127.smethod_11(array3);
					if (array.Length > 3 && array[1] == 127 && (array[3] == 33 || array[3] == 35 || array[3] == 120))
					{
						if (array[3] == 120)
						{
							num = 4;
						}
					}
					else if (!(a == b) && !(a == b2) && (!(a != text2) || !(text2 != "")))
					{
						flag2 = false;
					}
					if (flag)
					{
						string text3 = "";
						if (array.Length > 5)
						{
							if (gclass104_1.string_5.Length != 0 && gclass104_1.string_2.Contains("FUNCEXW") && array.Length > 6)
							{
								byte b4 = array[5];
								byte b5 = array[6];
								this.string_10 = GClass127.smethod_23(b4) + GClass127.smethod_23(b5);
								text3 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b4) + GClass127.smethod_23(b5);
								int k = 0;
								while (k < gclass104_1.string_5.Length)
								{
									byte b6 = byte.Parse(gclass104_1.string_5[k].Substring(0, 2), NumberStyles.HexNumber);
									byte b7 = byte.Parse(gclass104_1.string_5[k].Substring(2, 2), NumberStyles.HexNumber);
									byte b8 = byte.Parse(gclass104_1.string_5[k].Substring(4, 2), NumberStyles.HexNumber);
									byte b9 = byte.Parse(gclass104_1.string_5[k].Substring(6, 2), NumberStyles.HexNumber);
									if ((b4 & b6) != b8 || (b5 & b7) != b9)
									{
										if (k != gclass104_1.string_5.Length - 1)
										{
											k++;
											continue;
										}
									}
									text3 = gclass104_1.string_5[k].Substring(8);
									break;
								}
							}
							else if (gclass104_1.string_5.Length != 0 && !gclass104_1.string_2.Contains("FUNCEXW"))
							{
								byte b10 = array[5];
								if (gclass104_1.int_0 == 2 && array.Length > 6)
								{
									b10 = array[6];
								}
								this.string_10 = GClass127.smethod_23(b10);
								text3 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b10);
								int l = 0;
								while (l < gclass104_1.string_5.Length)
								{
									byte b11 = byte.Parse(gclass104_1.string_5[l].Substring(0, 2), NumberStyles.HexNumber);
									byte b12 = byte.Parse(gclass104_1.string_5[l].Substring(2, 2), NumberStyles.HexNumber);
									if ((b10 & b11) != b12)
									{
										if (l != gclass104_1.string_5.Length - 1)
										{
											l++;
											continue;
										}
									}
									text3 = gclass104_1.string_5[l].Substring(4);
									break;
								}
							}
						}
						if (text3.Length > 0)
						{
							base.method_26(text3);
						}
					}
					num2 -= num;
					goto IL_67D;
				}
				Thread.Sleep(100);
			}
			goto IL_35E;
		}
		string text4 = GClass121.smethod_6("6056");
		if (array.Length > 5)
		{
			if (gclass104_1.string_5.Length != 0 && gclass104_1.string_2.Contains("FUNCEXW") && array.Length > 6)
			{
				byte b13 = array[4 + gclass104_1.int_0];
				byte b14 = array[5 + gclass104_1.int_0];
				this.string_10 = GClass127.smethod_23(b13) + GClass127.smethod_23(b14);
				text4 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b13) + GClass127.smethod_23(b14);
				int m = 0;
				while (m < gclass104_1.string_5.Length)
				{
					byte b15 = byte.Parse(gclass104_1.string_5[m].Substring(0, 2), NumberStyles.HexNumber);
					byte b16 = byte.Parse(gclass104_1.string_5[m].Substring(2, 2), NumberStyles.HexNumber);
					byte b17 = byte.Parse(gclass104_1.string_5[m].Substring(4, 2), NumberStyles.HexNumber);
					byte b18 = byte.Parse(gclass104_1.string_5[m].Substring(6, 2), NumberStyles.HexNumber);
					if ((b13 & b15) != b17 || (b14 & b16) != b18)
					{
						if (m != gclass104_1.string_5.Length - 1)
						{
							m++;
							continue;
						}
					}
					text4 = gclass104_1.string_5[m].Substring(8);
					break;
				}
			}
			else if (gclass104_1.string_5.Length != 0 && !gclass104_1.string_2.Contains("FUNCEXW"))
			{
				byte b19 = array[4 + gclass104_1.int_0];
				if (gclass104_1.int_0 == 2 && array.Length > 6)
				{
					b19 = array[6];
				}
				this.string_10 = GClass127.smethod_23(b19);
				text4 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(b19);
				int n = 0;
				while (n < gclass104_1.string_5.Length)
				{
					byte b20 = byte.Parse(gclass104_1.string_5[n].Substring(0, 2), NumberStyles.HexNumber);
					byte b21 = byte.Parse(gclass104_1.string_5[n].Substring(2, 2), NumberStyles.HexNumber);
					if ((b19 & b20) != b21)
					{
						if (n != gclass104_1.string_5.Length - 1)
						{
							n++;
							continue;
						}
					}
					text4 = gclass104_1.string_5[n].Substring(4);
					break;
				}
			}
			else if (array.Length == 6)
			{
				text4 = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[5]);
			}
			else if (array.Length == 7)
			{
				text4 = string.Concat(new string[]
				{
					GClass121.smethod_6("6055"),
					" ",
					GClass127.smethod_23(array[5]),
					" ",
					GClass127.smethod_23(array[6])
				});
			}
			else if (array.Length > 7)
			{
				text4 = string.Concat(new string[]
				{
					GClass121.smethod_6("6055"),
					" ",
					GClass127.smethod_23(array[5]),
					" ",
					GClass127.smethod_23(array[6]),
					" ",
					GClass127.smethod_23(array[7])
				});
			}
		}
		base.method_28(true, GClass121.smethod_6("6051"), text4);
	}

	// Token: 0x0600013D RID: 317 RVA: 0x0001F7B0 File Offset: 0x0001D9B0
	public override string vmethod_0(byte[] byte_12, string string_24, int int_6, int int_7, string[] string_25, string string_26)
	{
		byte[] byte_13 = this.method_51(byte_12);
		if (string_24 == "raw")
		{
			return GClass127.smethod_11(byte_13);
		}
		return this.r4(byte_13, string_24, int_6, int_7, string_25, string_26);
	}

	// Token: 0x0600013E RID: 318 RVA: 0x0001F7E8 File Offset: 0x0001D9E8
	private byte[] method_49(byte[] byte_12)
	{
		if (this.serialPort_0 != null && this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		List<byte> list = new List<byte>();
		if (byte_12.Length < 2)
		{
			return new byte[0];
		}
		List<byte[]> list2 = new List<byte[]>();
		if (byte_12.Length < 9)
		{
			if (this.string_1 == "CCAN29")
			{
				list2.Add(new byte[byte_12.Length - 1]);
				for (int i = 0; i < byte_12.Length - 1; i++)
				{
					list2[0][i] = byte_12[i + 1];
				}
			}
			else
			{
				list2.Add(new byte[byte_12.Length]);
				for (int j = 0; j < byte_12.Length; j++)
				{
					list2[0][j] = byte_12[j];
				}
			}
		}
		else
		{
			list2.Add(new byte[8]);
			list2[0][0] = 16;
			int num = 0;
			int num2 = 1;
			while (num2 < list2[0].Length && num < byte_12.Length)
			{
				list2[0][num2] = byte_12[num];
				num++;
				num2++;
			}
			byte b = 33;
			while (num < byte_12.Length && b < 47)
			{
				list2.Add(new byte[(byte_12.Length - num > 7) ? 8 : (byte_12.Length - num + 1)]);
				int index = list2.Count - 1;
				list2[index][0] = b;
				b += 1;
				int num3 = 1;
				while (num3 < list2[index].Length && num < byte_12.Length)
				{
					list2[index][num3] = byte_12[num];
					num++;
					num3++;
				}
			}
		}
		if (list2.Count > 1)
		{
			this.ra("ATCAF0");
			this.ra("ATST03");
		}
		this.r9(GClass127.smethod_11(list2[0]));
		this.int_0 = GClass126.smethod_1();
		if (list2.Count > 1)
		{
			GClass126.smethod_2("Waiting FC...", 0);
			string text = this.rb();
			if (text.Contains("NO DATA") || text.Contains("ERROR") || text.Contains("?") || !text.StartsWith("30"))
			{
				this.ra("ATST99");
				return new byte[0];
			}
			for (int k = 1; k < list2.Count; k++)
			{
				if (k == list2.Count - 1)
				{
					this.ra("ATSTF0");
				}
				this.r9(GClass127.smethod_11(list2[k]));
				this.int_0 = GClass126.smethod_1();
				if (k < list2.Count - 1)
				{
					this.rb();
				}
			}
		}
		string text2 = this.rb();
		text2 = text2.TrimStart(this.char_1);
		if (list2.Count > 1)
		{
			this.ra("ATCAF1");
		}
		if (!text2.Contains("NO DATA") && !text2.Contains("ERROR") && !text2.Contains("?"))
		{
			int num4;
			while (text2.StartsWith("7F2278") || text2.StartsWith("7F1978") || text2.StartsWith("7F1478") || text2.StartsWith("7F2E78") || text2.StartsWith("7F2F78") || text2.StartsWith("7F1078") || text2.StartsWith("037F2278") || text2.StartsWith("037F1978") || text2.StartsWith("037F1478") || text2.StartsWith("037F2E78") || text2.StartsWith("037F2F78") || text2.StartsWith("037F1078"))
			{
				num4 = 0;
				while (num4 < text2.Length && text2[num4] != '\r' && text2[num4] != '\n')
				{
					if (text2[num4] == '>')
					{
						break;
					}
					num4++;
				}
				text2 = text2.Substring(num4 + 1);
			}
			num4 = 0;
			while (num4 < text2.Length && text2[num4] != '\r' && text2[num4] != '\n')
			{
				if (text2[num4] == '>')
				{
					break;
				}
				num4++;
			}
			string text3 = text2.Substring(0, num4).Trim();
			text2 = text2.Substring(num4 + 1);
			if (text3.Length == 3 && text3[0] == '0')
			{
				byte item = 0;
				try
				{
					item = GClass127.smethod_32(text3.Substring(1))[0];
				}
				catch (Exception)
				{
				}
				list.Add(item);
				while (text2.Length > 2)
				{
					if (text2[1] != ':')
					{
						break;
					}
					num4 = 0;
					while (num4 < text2.Length && text2[num4] != '\r' && text2[num4] != '\n')
					{
						if (text2[num4] == '>')
						{
							break;
						}
						num4++;
					}
					if (num4 > 2)
					{
						text3 = text2.Substring(2, num4 - 2);
						byte[] array = GClass127.smethod_32(text3);
						for (int l = 0; l < array.Length; l++)
						{
							list.Add(array[l]);
						}
					}
					text2 = text2.Substring(num4 + 1);
				}
			}
			else
			{
				byte[] array2 = GClass127.smethod_32(text3);
				list.Add((byte)array2.Length);
				for (int m = 0; m < array2.Length; m++)
				{
					list.Add(array2[m]);
				}
			}
			GClass126.smethod_2("DECODED RESPONSE: " + GClass127.smethod_11(list.ToArray()), 0);
			byte[] array3 = list.ToArray();
			if (list.Count > 0 && list[0] > 0 && list[0] < 255 && (int)list[0] < list.Count - 1)
			{
				array3 = new byte[(int)(list[0] + 1)];
				for (int n = 0; n <= (int)list[0]; n++)
				{
					array3[n] = list[n];
				}
				GClass126.smethod_2("CLEANED RESPONSE: " + GClass127.smethod_11(array3), 0);
			}
			return array3;
		}
		return new byte[0];
	}

	// Token: 0x0600013F RID: 319 RVA: 0x0001FDFC File Offset: 0x0001DFFC
	public override List<GClass102> r1()
	{
		if (!(this.string_0 == "GPEC410") && !(this.string_0 == "GPEC413") && !(this.string_0 == "GPEC413HEV"))
		{
			List<GClass102> list = new List<GClass102>();
			byte[] array;
			if (GClass126.bool_0)
			{
				array = this.byte_5;
			}
			else
			{
				array = this.method_51(this.byte_6);
			}
			if (array.Length < 3 || array[1] != 89)
			{
				array = this.method_51(this.byte_6);
			}
			if (array.Length >= 3)
			{
				if (array[1] == 89)
				{
					for (int i = 4; i < array.Length - 2; i += 4)
					{
						GClass102 gclass = new GClass102();
						gclass.string_0 = GClass127.smethod_11(new byte[]
						{
							array[i],
							array[i + 1]
						}).Replace(" ", "");
						gclass.string_1 = GClass127.smethod_11(new byte[]
						{
							array[i],
							array[i + 1],
							array[i + 2]
						}).Replace(" ", "");
						gclass.byte_0 = array[i + 3];
						byte byte_ = array[i + 2];
						gclass.string_5 = this.method_56(byte_);
						gclass.string_6 = this.method_54(gclass.byte_0);
						gclass.string_7 = this.method_50(gclass.byte_0);
						gclass.bool_0 = ((gclass.byte_0 & 1) == 1);
						string str = "";
						if ((array[i] & 192) == 0)
						{
							str = "P";
						}
						else if ((array[i] & 192) == 64)
						{
							str = "C";
						}
						else if ((array[i] & 192) == 128)
						{
							str = "B";
						}
						else if ((array[i] & 192) == 192)
						{
							str = "U";
						}
						gclass.string_2 = str + GClass127.smethod_11(new byte[]
						{
							array[i] & 63,
							array[i + 1]
						}).Replace(" ", "") + "-" + GClass127.smethod_23(array[i + 2]);
						if ((gclass.byte_0 & 9) == 8)
						{
							GClass102 gclass2 = gclass;
							gclass2.string_3 = gclass2.string_3 + GClass121.smethod_6("3077") + " ";
						}
						else if ((gclass.byte_0 & 1) == 1)
						{
							GClass102 gclass3 = gclass;
							gclass3.string_3 = gclass3.string_3 + GClass121.smethod_6("3078") + " ";
						}
						if ((gclass.byte_0 & 128) == 0)
						{
							GClass102 gclass4 = gclass;
							gclass4.string_3 = gclass4.string_3 + GClass121.smethod_6("3073") + " ";
						}
						else
						{
							GClass102 gclass5 = gclass;
							gclass5.string_3 = gclass5.string_3 + GClass121.smethod_6("3074") + " ";
						}
						list.Add(gclass);
					}
					return list;
				}
			}
			GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
			GClass126.smethod_2("Force KA", 1);
			this.int_0 -= this.int_5;
			if (!this.bool_1)
			{
				Thread.Sleep(200);
			}
			return null;
		}
		return this.method_57();
	}

	// Token: 0x06000140 RID: 320 RVA: 0x00006FC4 File Offset: 0x000051C4
	private string method_50(byte byte_12)
	{
		string result = "";
		if ((byte_12 & 128) != 0)
		{
			result = GClass121.smethod_6("3051");
		}
		return result;
	}

	// Token: 0x06000141 RID: 321 RVA: 0x00020124 File Offset: 0x0001E324
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
						if (list_7.Count > 0 && list_7[0].byte_0.Length == 1)
						{
							GClass126.smethod_2("Processing DTC details (type 1)", 0);
							foreach (GClass104 gclass2 in list_7)
							{
								if (gclass2.string_1.Contains("*") || gclass2.string_1.Contains("[" + gclass.string_0 + "]"))
								{
									string text = GClass127.smethod_11(gclass2.byte_0[0]);
									text = text.Replace("00 00 00 00", gclass.string_1 + " 00");
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
										value = this.method_51(byte_);
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
					}
					catch (Exception)
					{
						GClass126.smethod_2("ERROR: Error reading DTC details (type 1)", 0);
					}
					try
					{
						if (list_7.Count > 0 && list_7[0].byte_0.Length > 2)
						{
							GClass126.smethod_2("Processing DTC details (type 2)", 0);
							byte[] byte_2 = GClass127.smethod_32(GClass127.smethod_11(list_7[0].byte_0[0]).Replace("00 00 00 00", gclass.string_1 + " 00"));
							byte[] array = new byte[0];
							if (GClass126.bool_0)
							{
								array = GClass127.smethod_32(this.string_23);
							}
							else
							{
								array = this.method_51(byte_2);
							}
							if (array.Length > 15)
							{
								int num2 = (int)array[8];
								bool flag = true;
								int num3 = 9;
								byte b = 0;
								byte b2 = 0;
								byte b3 = 0;
								while (num2 > 0 && flag && num3 < array.Length)
								{
									b = array[num3];
									b2 = array[num3 + 1];
									flag = false;
									foreach (GClass104 gclass4 in list_7)
									{
										if (gclass4.byte_0[1][0] == b && gclass4.byte_0[1][1] == b2)
										{
											flag = true;
											b3 = gclass4.byte_0[2][0];
											gclass4.method_1(this.r4(array, gclass4.string_2, num3 + gclass4.int_0 - 2, gclass4.int_1, gclass4.string_5, gclass4.string_6));
											if (!gclass4.string_1.Contains("[hidden]"))
											{
												GClass102 gclass3 = gclass;
												gclass3.string_4 = string.Concat(new string[]
												{
													gclass3.string_4,
													gclass4.string_0,
													": ",
													gclass4.method_0(),
													" ",
													gclass4.string_3,
													Environment.NewLine
												});
											}
										}
									}
									if (!flag)
									{
										GClass126.smethod_2("UNKNOWN DTC DETAILS IDENTIFIER: " + GClass127.smethod_23(b) + GClass127.smethod_23(b2), 0);
										if (array.Length > num3 + 6)
										{
											foreach (GClass104 gclass5 in list_7)
											{
												if (gclass5.byte_0[1][0] == array[num3 + 3] && gclass5.byte_0[1][1] == array[num3 + 4])
												{
													flag = true;
													b3 = 1;
												}
												else if (gclass5.byte_0[1][0] == array[num3 + 4] && gclass5.byte_0[1][1] == array[num3 + 5])
												{
													flag = true;
													b3 = 2;
												}
												else
												{
													if (gclass5.byte_0[1][0] != array[num3 + 5] || gclass5.byte_0[1][1] != array[num3 + 6])
													{
														continue;
													}
													flag = true;
													b3 = 3;
												}
												break;
											}
										}
									}
									num3 = num3 + 2 + (int)b3;
									num2--;
								}
							}
						}
					}
					catch (Exception ex)
					{
						GClass126.smethod_2("ERROR: Error reading DTC details (type 2): " + ex.Message, 0);
					}
				}
			}
			return;
		}
	}

	// Token: 0x06000142 RID: 322 RVA: 0x00020734 File Offset: 0x0001E934
	protected byte[] method_51(byte[] byte_12)
	{
		byte[] result;
		try
		{
			while (this.bool_2)
			{
				Thread.Sleep(1);
			}
			this.bool_2 = true;
			this.int_0 = GClass126.smethod_1();
			byte[] array = this.method_59(byte_12);
			if (byte_12.Length > 1)
			{
				if (((byte_12[1] == 20 || byte_12[1] == 25 || byte_12[1] == 34 || byte_12[1] == 255) && array.Length == 0) || (array.Length > 3 && array[1] == 127 && array[3] == 33))
				{
					Thread.Sleep(100);
					if (GClass125.smethod_49() || GClass125.smethod_44() == 2 || GClass125.smethod_44() == 3 || GClass125.smethod_44() == 11 || GClass125.smethod_44() == 9 || GClass125.smethod_44() == 7 || GClass125.smethod_44() == 12 || GClass125.smethod_44() == 15)
					{
						this.ra("ATSTF0");
					}
					array = this.method_59(byte_12);
				}
				if ((byte_12[1] == 20 || byte_12[1] == 25 || byte_12[1] == 34) && array.Length == 0)
				{
					Thread.Sleep(100);
					array = this.method_59(byte_12);
				}
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
				try
				{
					if (this.serialPort_0 != null)
					{
						this.serialPort_0.WriteLine("");
						int readTimeout = this.serialPort_0.ReadTimeout;
						this.serialPort_0.ReadTimeout = 100;
						try
						{
							this.rb();
							this.rb();
						}
						catch (Exception)
						{
						}
						this.serialPort_0.ReadTimeout = readTimeout;
					}
				}
				catch (Exception)
				{
				}
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

	// Token: 0x06000143 RID: 323 RVA: 0x00020964 File Offset: 0x0001EB64
	private void method_52(GClass104 gclass104_1)
	{
		byte[] array = base.method_35();
		if (!gclass104_1.string_2.Contains("SECURITY29EX") || array.Length == 0)
		{
			array = this.method_51(gclass104_1.byte_0[0]);
		}
		GClass126.smethod_2("Current Value: " + GClass127.smethod_11(array), 0);
		if (array.Length < 4)
		{
			string text = "";
			base.method_28(false, GClass121.smethod_6("6052"), text);
			return;
		}
		for (int i = 4; i < gclass104_1.byte_0[1].Length; i++)
		{
			byte b = 0;
			if (gclass104_1.string_2.Contains("SPEEDLIMIT"))
			{
				b = gclass104_1.byte_0[1][i];
			}
			else if (array.Length > i)
			{
				b = array[i];
			}
			if (gclass104_1.int_0 <= i - 3 && gclass104_1.int_0 + gclass104_1.int_1 > i - 3)
			{
				byte b2 = gclass104_1.byte_0[1][i];
				byte b3 = byte.Parse(gclass104_1.string_5[0].Substring(0, 2), NumberStyles.HexNumber);
				if (i == 5 && gclass104_1.string_2.Contains("RWUSERENTRY29W"))
				{
					b3 = byte.Parse(gclass104_1.string_5[0].Substring(2, 2), NumberStyles.HexNumber);
				}
				if (gclass104_1.string_2.Contains("RWUSERENTRY29H"))
				{
					b3 = byte.MaxValue;
				}
				b3 ^= byte.MaxValue;
				b &= b3;
				b |= b2;
			}
			gclass104_1.byte_0[1][i] = b;
		}
		Thread.Sleep(1000);
		array = this.method_51(gclass104_1.byte_0[1]);
		if (array.Length != 0)
		{
			if (array.Length <= 1 || array[1] != 127)
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
					array = this.method_51(gclass104_1.byte_0[j]);
					if (!flag)
					{
						if (array.Length != 0)
						{
							if (array.Length <= 1 || array[1] != 127)
							{
								goto IL_256;
							}
						}
						string text2 = "";
						if (array.Length > 3 && array[3] == 34)
						{
							text2 = GClass121.smethod_6("6053");
						}
						else if (array.Length > 3 && array[3] == 17)
						{
							text2 = GClass121.smethod_6("6054");
						}
						else if (array.Length > 3 && array[3] == 49)
						{
							text2 = GClass121.smethod_6("6507");
						}
						else if (array.Length > 3 && array[3] == 120)
						{
							text2 = GClass121.smethod_6("6502");
						}
						else if (array.Length > 3 && array[3] == 16)
						{
							text2 = GClass121.smethod_6("6503");
						}
						base.method_28(false, GClass121.smethod_6("6052"), text2);
						return;
					}
					IL_256:
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
		}
		string text3 = "";
		if (array.Length > 3 && array[3] == 34)
		{
			text3 = GClass121.smethod_6("6053");
		}
		else if (array.Length > 3 && array[3] == 17)
		{
			text3 = GClass121.smethod_6("6054");
		}
		base.method_28(false, GClass121.smethod_6("6052"), text3);
	}

	// Token: 0x06000144 RID: 324 RVA: 0x000091A4 File Offset: 0x000073A4
	private string method_53(byte byte_12)
	{
		string result = "";
		if ((byte_12 & 96) == 0)
		{
			result = GClass121.smethod_6("3052");
		}
		else if ((byte_12 & 96) == 32)
		{
			result = GClass121.smethod_6("3053");
		}
		else if ((byte_12 & 96) == 64)
		{
			result = GClass121.smethod_6("3054");
		}
		else if ((byte_12 & 96) == 96)
		{
			result = GClass121.smethod_6("3055");
		}
		return result;
	}

	// Token: 0x06000145 RID: 325 RVA: 0x00006F88 File Offset: 0x00005188
	private string method_54(byte byte_12)
	{
		string result = "";
		if ((byte_12 & 9) == 8)
		{
			result = GClass121.smethod_6("3054");
		}
		else if ((byte_12 & 1) == 1)
		{
			result = GClass121.smethod_6("3062");
		}
		return result;
	}

	// Token: 0x06000146 RID: 326 RVA: 0x00020D18 File Offset: 0x0001EF18
	protected void method_55()
	{
		if (GClass126.bool_0)
		{
			byte[][] array = new byte[][]
			{
				new byte[]
				{
					8,
					98,
					241,
					165,
					124,
					134,
					79,
					byte.MaxValue,
					byte.MaxValue
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
				}
			};
			byte[][] array2 = new byte[][]
			{
				GClass127.smethod_32("2B 62 40 A1 6F 00 00 04 02 00 00 00 6F 00 00 04 02 00 00 00 01 00 00 00 02 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00"),
				GClass127.smethod_32("2B 62 40 A2 6F 00 00 04 02 00 00 00 09 00 00 04 02 00 00 00 6F 00 00 04 02 00 00 00 09 00 00 04 02 00 00 00 01 00 00 04 02 00 00 00"),
				GClass127.smethod_32("58 62 20 23 33 38 31 39 39 30 30 35 31 34 34 4F 55 54 50 55 54 2D 4A 49 54 20 06 07 13 6F 01 00 04 02 00 00 00 09 00 00 04 02 00 00 00 C1 00 03 07 3F 00 2A 20 A3 80 00 06 00 00 00 94 06 03 02 00 00 00 00 00 0A 10 05 04 00 00 00 00 00 00 00 00 00 11 0D 50 00 10 00 00")
			};
			if (this.string_0.StartsWith("PROXIX"))
			{
				array2 = new byte[][]
				{
					GClass127.smethod_32("43 62 40 A1 4F 0C 40 C5 38 40 1D 02 60 48 42 00 84 00 01 20 4F 0C 40 C5 30 40 1D 02 20 48 02 00 84 00 00 00 01 00 00 40 00 00 00 00 00 00 02 00 00 00 00 00 01 00 00 00 00 00 00 00 00 08 02 00 00 00 00 00"),
					GClass127.smethod_32("53 62 40 A2 4F 0C 40 C5 38 40 1D 02 60 48 42 00 84 00 01 20 4F 0C 40 45 18 40 1D 02 20 40 02 00 84 00 00 00 4F 0C 40 C5 30 40 1D 02 20 48 02 00 84 00 00 00 4F 0C 40 45 10 40 1D 02 20 40 02 00 84 00 00 00 4D 0C 40 45 10 40 1D 02 20 40 00 00 00 00 00 00"),
					GClass127.smethod_32("EE 62 20 23 30 36 36 33 39 30 36 34 35 38 37 4F 55 54 50 55 54 2D 53 49 54 20 23 04 07 4F 0C 40 C5 38 40 1D 02 60 48 42 00 84 00 01 20 4F 0C 40 45 18 40 1D 02 20 40 02 00 84 00 00 00 00 F2 E9 06 C9 80 08 61 50 22 69 57 40 10 78 01 A2 1E 04 7A C0 7E 63 28 31 03 C1 F8 9C 83 25 00 34 43 05 00 04 82 0E 63 00 00 20 04 00 99 01 73 EB 04 07 B5 01 73 20 08 A8 08 00 D1 14 6B 00 FF 00 59 15 18 CA 00 49 00 03 3A 2F DB 80 C9 03 01 00 80 82 03 04 1B 40 18 21 37 A4 71 00 00 00 00 00 00 00 81 07 C2 00 00 00 38 4D 07 A5 0D 04 00 58 11 00 00 62 00 80 01 40 10 00 08 00 00 00 05 00 00 00 10 00 00 00 C0 20 00 00 00 01 00 00 21 01 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00")
				};
			}
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
				string text;
				if (GClass127.smethod_11(gclass.byte_0[0]) == "03 22 40 A1")
				{
					text = this.r4(array2[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else if (GClass127.smethod_11(gclass.byte_0[0]) == "03 22 40 A2")
				{
					text = this.r4(array2[1], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else if (GClass127.smethod_11(gclass.byte_0[0]) == "03 22 20 23")
				{
					text = this.r4(array2[2], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else if (j < array.Length)
				{
					text = this.r4(array[j], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else
				{
					text = this.r4(array[0], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				gclass.method_1(text);
				if (gclass.int_2 == 10455)
				{
					this.string_7 = text;
				}
			}
			this.bool_1 = false;
			this.bool_0 = true;
			new Thread(new ThreadStart(this.method_62))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_36();
			throw new Exception("1");
		}
	}

	// Token: 0x06000147 RID: 327
	protected abstract void r6();

	// Token: 0x06000148 RID: 328 RVA: 0x00021050 File Offset: 0x0001F250
	public override string r4(byte[] byte_12, string string_24, int int_6, int int_7, string[] string_25, string string_26)
	{
		string result = "";
		int_6 += 3;
		if (byte_12.Length <= int_6)
		{
			return result;
		}
		if (byte_12[1] == 127 && string_24 != "hex3")
		{
			return result;
		}
		int num = byte_12.Length - int_6;
		if (int_7 < num)
		{
			num = int_7;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_12[i + int_6];
		}
		return base.method_33(array, string_24, string_25, string_26);
	}

	// Token: 0x06000149 RID: 329 RVA: 0x000210C0 File Offset: 0x0001F2C0
	private string method_56(byte byte_12)
	{
		string result = "";
		if (byte_12 == 1)
		{
			result = GClass121.smethod_6("3101");
		}
		else if (byte_12 == 2)
		{
			result = GClass121.smethod_6("3102");
		}
		else if (byte_12 == 3)
		{
			result = GClass121.smethod_6("3103");
		}
		else if (byte_12 == 7)
		{
			result = GClass121.smethod_6("3104");
		}
		else if (byte_12 == 8)
		{
			result = GClass121.smethod_6("3105");
		}
		else if (byte_12 == 9)
		{
			result = GClass121.smethod_6("3106");
		}
		else if (byte_12 == 17)
		{
			result = GClass121.smethod_6("3107");
		}
		else if (byte_12 == 18)
		{
			result = GClass121.smethod_6("3108");
		}
		else if (byte_12 == 19)
		{
			result = GClass121.smethod_6("3109");
		}
		else if (byte_12 == 20)
		{
			result = GClass121.smethod_6("3110");
		}
		else if (byte_12 == 21)
		{
			result = GClass121.smethod_6("3111");
		}
		else if (byte_12 == 22)
		{
			result = GClass121.smethod_6("3112");
		}
		else if (byte_12 == 23)
		{
			result = GClass121.smethod_6("3113");
		}
		else if (byte_12 == 24)
		{
			result = GClass121.smethod_6("3114");
		}
		else if (byte_12 == 25)
		{
			result = GClass121.smethod_6("3115");
		}
		else if (byte_12 == 26)
		{
			result = GClass121.smethod_6("3116");
		}
		else if (byte_12 == 27)
		{
			result = GClass121.smethod_6("3117");
		}
		else if (byte_12 == 28)
		{
			result = GClass121.smethod_6("3118");
		}
		else if (byte_12 == 29)
		{
			result = GClass121.smethod_6("3119");
		}
		else if (byte_12 == 30)
		{
			result = GClass121.smethod_6("3120");
		}
		else if (byte_12 == 31)
		{
			result = GClass121.smethod_6("3121");
		}
		else if (byte_12 == 33)
		{
			result = GClass121.smethod_6("3122");
		}
		else if (byte_12 == 34)
		{
			result = GClass121.smethod_6("3123");
		}
		else if (byte_12 == 35)
		{
			result = GClass121.smethod_6("3124");
		}
		else if (byte_12 == 36)
		{
			result = GClass121.smethod_6("3125");
		}
		else if (byte_12 == 37)
		{
			result = GClass121.smethod_6("3126");
		}
		else if (byte_12 == 38)
		{
			result = GClass121.smethod_6("3127");
		}
		else if (byte_12 == 39)
		{
			result = GClass121.smethod_6("3128");
		}
		else if (byte_12 == 40)
		{
			result = GClass121.smethod_6("3129");
		}
		else if (byte_12 == 41)
		{
			result = GClass121.smethod_6("3130");
		}
		else if (byte_12 == 42)
		{
			result = GClass121.smethod_6("3131");
		}
		else if (byte_12 == 43)
		{
			result = GClass121.smethod_6("3132");
		}
		else if (byte_12 == 44)
		{
			result = GClass121.smethod_6("3133");
		}
		else if (byte_12 == 45)
		{
			result = GClass121.smethod_6("3134");
		}
		else if (byte_12 == 47)
		{
			result = GClass121.smethod_6("3135");
		}
		else if (byte_12 == 49)
		{
			result = GClass121.smethod_6("3136");
		}
		else if (byte_12 == 50)
		{
			result = GClass121.smethod_6("3137");
		}
		else if (byte_12 == 51)
		{
			result = GClass121.smethod_6("3138");
		}
		else if (byte_12 == 52)
		{
			result = GClass121.smethod_6("3139");
		}
		else if (byte_12 == 53)
		{
			result = GClass121.smethod_6("3140");
		}
		else if (byte_12 == 54)
		{
			result = GClass121.smethod_6("3141");
		}
		else if (byte_12 == 55)
		{
			result = GClass121.smethod_6("3142");
		}
		else if (byte_12 == 56)
		{
			result = GClass121.smethod_6("3143");
		}
		else if (byte_12 == 57)
		{
			result = GClass121.smethod_6("3144");
		}
		else if (byte_12 == 58)
		{
			result = GClass121.smethod_6("3145");
		}
		else if (byte_12 == 59)
		{
			result = GClass121.smethod_6("3146");
		}
		else if (byte_12 == 60)
		{
			result = GClass121.smethod_6("3147");
		}
		else if (byte_12 == 65)
		{
			result = GClass121.smethod_6("3148");
		}
		else if (byte_12 == 66)
		{
			result = GClass121.smethod_6("3149");
		}
		else if (byte_12 == 67)
		{
			result = GClass121.smethod_6("3150");
		}
		else if (byte_12 == 68)
		{
			result = GClass121.smethod_6("3151");
		}
		else if (byte_12 == 69)
		{
			result = GClass121.smethod_6("3152");
		}
		else if (byte_12 == 70)
		{
			result = GClass121.smethod_6("3153");
		}
		else if (byte_12 == 71)
		{
			result = GClass121.smethod_6("3154");
		}
		else if (byte_12 == 72)
		{
			result = GClass121.smethod_6("3155");
		}
		else if (byte_12 == 73)
		{
			result = GClass121.smethod_6("3156");
		}
		else if (byte_12 == 74)
		{
			result = GClass121.smethod_6("3157");
		}
		else if (byte_12 == 75)
		{
			result = GClass121.smethod_6("3158");
		}
		else if (byte_12 == 76)
		{
			result = GClass121.smethod_6("3159");
		}
		else if (byte_12 == 77)
		{
			result = GClass121.smethod_6("3160");
		}
		else if (byte_12 == 81)
		{
			result = GClass121.smethod_6("3161");
		}
		else if (byte_12 == 84)
		{
			result = GClass121.smethod_6("3162");
		}
		else if (byte_12 == 85)
		{
			result = GClass121.smethod_6("3163");
		}
		else if (byte_12 == 86)
		{
			result = GClass121.smethod_6("3164");
		}
		else if (byte_12 == 97)
		{
			result = GClass121.smethod_6("3165");
		}
		else if (byte_12 == 98)
		{
			result = GClass121.smethod_6("3166");
		}
		else if (byte_12 == 99)
		{
			result = GClass121.smethod_6("3167");
		}
		else if (byte_12 == 100)
		{
			result = GClass121.smethod_6("3168");
		}
		else if (byte_12 == 101)
		{
			result = GClass121.smethod_6("3169");
		}
		else if (byte_12 == 102)
		{
			result = GClass121.smethod_6("3170");
		}
		else if (byte_12 == 103)
		{
			result = GClass121.smethod_6("3171");
		}
		else if (byte_12 == 104)
		{
			result = GClass121.smethod_6("3172");
		}
		else if (byte_12 == 113)
		{
			result = GClass121.smethod_6("3173");
		}
		else if (byte_12 == 114)
		{
			result = GClass121.smethod_6("3174");
		}
		else if (byte_12 == 115)
		{
			result = GClass121.smethod_6("3175");
		}
		else if (byte_12 == 116)
		{
			result = GClass121.smethod_6("3176");
		}
		else if (byte_12 == 118)
		{
			result = GClass121.smethod_6("3177");
		}
		else if (byte_12 == 119)
		{
			result = GClass121.smethod_6("3178");
		}
		else if (byte_12 == 120)
		{
			result = GClass121.smethod_6("3179");
		}
		else if (byte_12 == 121)
		{
			result = GClass121.smethod_6("3180");
		}
		else if (byte_12 == 122)
		{
			result = GClass121.smethod_6("3181");
		}
		else if (byte_12 == 123)
		{
			result = GClass121.smethod_6("3182");
		}
		else if (byte_12 == 129)
		{
			result = GClass121.smethod_6("3183");
		}
		else if (byte_12 == 130)
		{
			result = GClass121.smethod_6("3184");
		}
		else if (byte_12 == 131)
		{
			result = GClass121.smethod_6("3185");
		}
		else if (byte_12 == 132)
		{
			result = GClass121.smethod_6("3186");
		}
		else if (byte_12 == 133)
		{
			result = GClass121.smethod_6("3187");
		}
		else if (byte_12 == 134)
		{
			result = GClass121.smethod_6("3188");
		}
		else if (byte_12 == 135)
		{
			result = GClass121.smethod_6("3189");
		}
		else if (byte_12 == 136)
		{
			result = GClass121.smethod_6("3190");
		}
		else if (byte_12 == 143)
		{
			result = GClass121.smethod_6("3191");
		}
		else if (byte_12 == 146)
		{
			result = GClass121.smethod_6("3192");
		}
		else if (byte_12 == 147)
		{
			result = GClass121.smethod_6("3193");
		}
		else if (byte_12 == 148)
		{
			result = GClass121.smethod_6("3194");
		}
		else if (byte_12 == 149)
		{
			result = GClass121.smethod_6("3195");
		}
		else if (byte_12 == 150)
		{
			result = GClass121.smethod_6("3196");
		}
		else if (byte_12 == 151)
		{
			result = GClass121.smethod_6("3197");
		}
		else if (byte_12 == 152)
		{
			result = GClass121.smethod_6("3198");
		}
		else if (byte_12 == 154)
		{
			result = GClass121.smethod_6("3199");
		}
		else if (byte_12 == 155)
		{
			result = GClass121.smethod_6("3200");
		}
		else if (byte_12 == 156)
		{
			result = GClass121.smethod_6("3201");
		}
		else if (byte_12 == 157)
		{
			result = GClass121.smethod_6("3202");
		}
		else if (byte_12 == 159)
		{
			result = GClass121.smethod_6("3203");
		}
		else if (byte_12 == 194)
		{
			result = GClass121.smethod_6("3204");
		}
		return result;
	}

	// Token: 0x0600014A RID: 330 RVA: 0x00021984 File Offset: 0x0001FB84
	private List<GClass102> method_57()
	{
		List<GClass102> list = new List<GClass102>();
		byte[] array;
		if (GClass126.bool_0)
		{
			array = this.byte_5;
		}
		else
		{
			array = this.method_51(this.byte_9);
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
			gclass.string_5 = this.method_45(gclass.byte_0);
			gclass.string_6 = this.method_53(gclass.byte_0);
			gclass.string_7 = this.method_60(gclass.byte_0);
			gclass.bool_0 = ((gclass.byte_0 & 1) == 1);
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

	// Token: 0x0600014B RID: 331 RVA: 0x00021D2C File Offset: 0x0001FF2C
	private void method_58(GClass104 gclass104_1)
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
		string a = "";
		string a2 = "";
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
				string text = gclass104_1.string_5[num3].Substring(4);
				if (num4 == 0)
				{
					base.method_26(text);
				}
				else if (num4 == 1)
				{
					base.method_26(text);
					GClass126.bool_24 = false;
					for (int k = 0; k < 600; k++)
					{
						if (GClass126.bool_25 && flag2)
						{
							GClass126.smethod_2(GClass121.smethod_6("6081"), 2);
							this.method_51(gclass104_1.byte_0[gclass104_1.byte_0.Length - 1]);
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
				byte[] array = this.method_51(gclass104_1.byte_0[i]);
				if (a == "" && (array.Length == 0 || (array.Length > 1 && array[1] == 127)))
				{
					if (array.Length < 4)
					{
						a = "";
					}
					else if (array[3] == 34)
					{
						a = GClass121.smethod_6("6053");
					}
					else if (array[3] == 17)
					{
						a = GClass121.smethod_6("6054");
					}
					else if (array[3] == 49)
					{
						a = GClass121.smethod_6("6507");
					}
					else if (array[3] == 120)
					{
						a = GClass121.smethod_6("6502");
					}
					else if (array[3] == 16)
					{
						a = GClass121.smethod_6("6503");
					}
					else if (array[3] == 18)
					{
						a = GClass121.smethod_6("6504");
					}
					else if (array[3] == 33)
					{
						a = GClass121.smethod_6("6505");
					}
					else if (array[3] == 36)
					{
						a = "Incorrect sequence";
					}
					else if (array[3] == 129)
					{
						a = "RPM too high";
					}
					else if (array[3] == 130)
					{
						a = "RPM too low";
					}
					else if (array[3] == 131)
					{
						a = "Engine running";
					}
					else if (array[3] == 132)
					{
						a = "Engine not running";
					}
					else if (array[3] == 133)
					{
						a = "Engine run time not enough";
					}
					else if (array[3] == 134)
					{
						a = "Temperature too high";
					}
					else if (array[3] == 135)
					{
						a = "Temperature too low";
					}
					else if (array[3] == 136)
					{
						a = "Vehicle speed too high";
					}
					else if (array[3] == 137)
					{
						a = "Vehicle speed too low";
					}
					else if (array[3] == 138)
					{
						a = "Throttle/pedal too high";
					}
					else if (array[3] == 139)
					{
						a = "Throttle/pedal too low";
					}
					else if (array[3] == 140)
					{
						a = "Transmission in Neutral";
					}
					else if (array[3] == 141)
					{
						a = "Transmission in gear";
					}
					else if (array[3] == 143)
					{
						a = "Brake pedal";
					}
					else if (array[3] == 144)
					{
						a = "Transmission not in Park";
					}
					else if (array[3] == 145)
					{
						a = "Torque converter locked";
					}
					else if (array[3] == 146)
					{
						a = "Voltage too high";
					}
					else if (array[3] == 147)
					{
						a = "Voltage too low";
					}
					else
					{
						a = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
					}
					if (!flag)
					{
						base.method_28(false, GClass121.smethod_6("6052"), a);
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
							array = this.method_51(gclass104_1.byte_0[gclass104_1.byte_0.Length - 1]);
							base.method_28(false, GClass121.smethod_6("6082"), " ");
							this.bool_3 = false;
							return;
						}
						Thread.Sleep(100);
					}
				}
				if (i == gclass104_1.byte_0.Length - 1 && flag3)
				{
					a2 = GClass121.smethod_6("6056");
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
							a2 = gclass104_1.string_5[m].Substring(4);
							break;
						}
					}
				}
			}
		}
		this.bool_3 = false;
		if (a2 != "")
		{
			base.method_28(false, GClass121.smethod_6("6051"), a2);
			return;
		}
		if (a == "" || flag)
		{
			base.method_28(false, GClass121.smethod_6("6051"), a);
			return;
		}
		base.method_28(false, GClass121.smethod_6("6052"), a);
	}

	// Token: 0x0600014C RID: 332 RVA: 0x00022428 File Offset: 0x00020628
	protected override void r3(GClass104 gclass104_1)
	{
		if (!GClass126.bool_0 && !(GClass123.string_2 != GClass123.string_3))
		{
			if (gclass104_1.string_2.Contains("FUNCEX"))
			{
				this.method_48(gclass104_1);
				return;
			}
			if (gclass104_1.string_2.Contains("FUNC"))
			{
				this.method_47(gclass104_1);
				return;
			}
			if (gclass104_1.string_2.Contains("RWREADCURRENTVALUE"))
			{
				this.method_61(gclass104_1);
				return;
			}
			if (gclass104_1.string_2.Contains("RWUSERENTRY"))
			{
				this.method_52(gclass104_1);
				return;
			}
			this.method_58(gclass104_1);
			return;
		}
		else
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
	}

	// Token: 0x0600014D RID: 333 RVA: 0x0002252C File Offset: 0x0002072C
	private byte[] method_59(byte[] byte_12)
	{
		if (GClass125.smethod_44() != 4)
		{
			if (GClass125.smethod_44() != 5)
			{
				if (this.serialPort_0 != null && this.serialPort_0.BytesToRead > 0)
				{
					this.serialPort_0.ReadExisting();
				}
				List<byte> list = new List<byte>();
				if (byte_12.Length < 2)
				{
					return new byte[0];
				}
				List<byte[]> list2 = new List<byte[]>();
				if (GClass125.smethod_44() == 15)
				{
					list2.Add(new byte[byte_12.Length - 1]);
					for (int i = 0; i < byte_12.Length - 1; i++)
					{
						list2[0][i] = byte_12[i + 1];
					}
				}
				else if (byte_12.Length < 9)
				{
					list2.Add(new byte[byte_12.Length - 1]);
					for (int j = 0; j < byte_12.Length - 1; j++)
					{
						list2[0][j] = byte_12[j + 1];
					}
				}
				else
				{
					list2.Add(new byte[8]);
					list2[0][0] = 16;
					int num = byte_12.Length - 1;
					if (num > 255)
					{
						num -= 256;
						list2[0][0] = 17;
						byte_12[0] = (byte)num;
					}
					int k = 0;
					int num2 = 1;
					while (num2 < list2[0].Length && k < byte_12.Length)
					{
						list2[0][num2] = byte_12[k];
						k++;
						num2++;
					}
					byte b = 33;
					while (k < byte_12.Length)
					{
						list2.Add(new byte[(byte_12.Length - k > 7) ? 8 : (byte_12.Length - k + 1)]);
						int index = list2.Count - 1;
						list2[index][0] = b;
						b += 1;
						if (b > 47)
						{
							b = 32;
						}
						int num3 = 1;
						while (num3 < list2[index].Length && k < byte_12.Length)
						{
							list2[index][num3] = byte_12[k];
							k++;
							num3++;
						}
					}
				}
				bool flag = false;
				if (list2.Count > 1)
				{
					if (GClass125.smethod_49())
					{
						this.ra("ATGR06");
						this.r9(GClass127.smethod_11(list2[0]) + " 1");
					}
					else
					{
						this.ra("ATCAF0");
						this.ra("ATAT0");
						if (this.int_4 == 1)
						{
							this.ra("ATST08");
						}
						else
						{
							this.ra("ATST10");
						}
						this.r9(GClass127.smethod_11(list2[0]) + " 1");
					}
				}
				else if (list2.Count == 1 && GClass125.smethod_49() && list2[0].Length == 2 && list2[0][0] == 255)
				{
					this.r9("ATGR" + GClass127.smethod_23(list2[0][1]));
				}
				else if (list2.Count == 1 && GClass125.smethod_49() && list2[0].Length == 2 && list2[0][0] == 62 && list2[0][1] == 0)
				{
					this.r9("ATGR07");
				}
				else
				{
					this.r9(GClass127.smethod_11(list2[0]));
				}
				this.int_0 = GClass126.smethod_1();
				if (list2.Count > 1)
				{
					GClass126.smethod_2("Waiting FC...", 0);
					string text = this.rb();
					if (!flag && text.Contains("?"))
					{
						flag = true;
						Thread.Sleep(250);
						this.r9(GClass127.smethod_11(list2[0]));
						this.int_0 = GClass126.smethod_1();
						text = this.rb();
					}
					if (text.Contains("NO DATA") || text.Contains("ERROR") || text.Contains("?") || !text.StartsWith("30"))
					{
						if (GClass125.smethod_49())
						{
							this.ra("ATGR05");
						}
						else
						{
							this.ra("ATCAF1");
							this.ra("ATAT1");
						}
						this.ra("ATST99");
						return new byte[0];
					}
					int num4 = 0;
					int num5 = 0;
					while (num5 < text.Length && text[num5] != '\r' && text[num5] != '\n')
					{
						if (text[num5] == '>')
						{
							break;
						}
						num5++;
					}
					byte[] array = GClass127.smethod_32(text.Substring(0, num5));
					if (array.Length > 2 && array[0] == 48 && array[2] != 0)
					{
						num4 = (int)(array[2] + 2);
					}
					GClass126.smethod_2("Separation Time: " + num4.ToString(), 0);
					if (list2.Count > 1 && GClass125.smethod_49())
					{
						this.ra("ATST03");
					}
					for (int l = 1; l < list2.Count; l++)
					{
						while (this.int_0 + num4 > GClass126.smethod_1())
						{
						}
						if (l == list2.Count - 1)
						{
							this.ra("ATSTFE");
							this.r9(GClass127.smethod_11(list2[l]));
						}
						else if (!flag)
						{
							this.r9(GClass127.smethod_11(list2[l]) + " 0");
						}
						else
						{
							this.r9(GClass127.smethod_11(list2[l]));
						}
						this.int_0 = GClass126.smethod_1();
						if (l < list2.Count - 1)
						{
							this.rb();
						}
					}
				}
				string text2 = this.rb();
				text2 = text2.TrimStart(this.char_1);
				if (list2.Count > 1)
				{
					if (GClass125.smethod_49())
					{
						this.ra("ATGR05");
					}
					else
					{
						this.ra("ATCAF1");
						this.ra("ATAT1");
					}
				}
				if (!text2.Contains("NO DATA") && !text2.Contains("ERROR") && !text2.Contains("BUFFER") && !text2.Contains("WRONG") && !text2.Contains("?"))
				{
					string text3 = "";
					int num6;
					while (text2.StartsWith("7F2278") || text2.StartsWith("7F3178") || text2.StartsWith("7F1978") || text2.StartsWith("7F1478") || text2.StartsWith("7F2E78") || text2.StartsWith("7F2F78") || text2.StartsWith("7F1078") || text2.StartsWith("037F2278") || text2.StartsWith("037F1978") || text2.StartsWith("037F1478") || text2.StartsWith("037F2E78") || text2.StartsWith("037F2F78") || text2.StartsWith("037F1078"))
					{
						num6 = 0;
						while (num6 < text2.Length && text2[num6] != '\r' && text2[num6] != '\n')
						{
							if (text2[num6] == '>')
							{
								break;
							}
							num6++;
						}
						text3 = text2.Substring(0, num6).Trim();
						text2 = text2.Substring(num6 + 1);
					}
					num6 = 0;
					while (num6 < text2.Length && text2[num6] != '\r' && text2[num6] != '\n')
					{
						if (text2[num6] == '>')
						{
							break;
						}
						num6++;
					}
					string text4 = text2.Substring(0, num6).Trim();
					text2 = text2.Substring(num6 + 1);
					if (text4.Length == 3 && (text4[0] == '0' || text4[0] == '1'))
					{
						byte item = 0;
						try
						{
							item = GClass127.smethod_32(text4.Substring(1))[0];
							if (text4[0] != '0')
							{
								item = byte.MaxValue;
							}
						}
						catch (Exception)
						{
						}
						list.Add(item);
						while (text2.Length > 2)
						{
							if (text2[1] != ':')
							{
								break;
							}
							num6 = 0;
							while (num6 < text2.Length && text2[num6] != '\r' && text2[num6] != '\n')
							{
								if (text2[num6] == '>')
								{
									break;
								}
								num6++;
							}
							if (num6 > 2)
							{
								text4 = text2.Substring(2, num6 - 2);
								byte[] array2 = GClass127.smethod_32(text4);
								for (int m = 0; m < array2.Length; m++)
								{
									list.Add(array2[m]);
								}
							}
							text2 = text2.Substring(num6 + 1);
						}
					}
					else
					{
						byte[] array3 = GClass127.smethod_32(text4);
						if (array3.Length == 0 && text3.Length > 4)
						{
							array3 = GClass127.smethod_32(text3);
						}
						if (array3.Length == 0)
						{
							return new byte[0];
						}
						if (list2.Count == 1)
						{
							list.Add((byte)array3.Length);
						}
						for (int n = 0; n < array3.Length; n++)
						{
							list.Add(array3[n]);
						}
					}
					GClass126.smethod_2("DECODED RESPONSE: " + GClass127.smethod_11(list.ToArray()), 0);
					byte[] array4 = list.ToArray();
					if (list.Count > 0 && list[0] > 0 && list[0] < 255 && (int)list[0] < list.Count - 1)
					{
						array4 = new byte[(int)(list[0] + 1)];
						for (int num7 = 0; num7 <= (int)list[0]; num7++)
						{
							array4[num7] = list[num7];
						}
						GClass126.smethod_2("CLEANED RESPONSE: " + GClass127.smethod_11(array4), 0);
					}
					return array4;
				}
				if (!this.bool_0)
				{
					if (text2.Contains("WRONG"))
					{
						this.string_8 = "WRONG PINS";
					}
					else
					{
						this.string_9 = text2.Replace("\r", "").Replace("\n", "").Replace(">", "");
					}
				}
				return new byte[0];
			}
		}
		return this.method_49(byte_12);
	}

	// Token: 0x0600014E RID: 334 RVA: 0x00006FC4 File Offset: 0x000051C4
	private string method_60(byte byte_12)
	{
		string result = "";
		if ((byte_12 & 128) != 0)
		{
			result = GClass121.smethod_6("3051");
		}
		return result;
	}

	// Token: 0x0600014F RID: 335 RVA: 0x00022F2C File Offset: 0x0002112C
	private void method_61(GClass104 gclass104_1)
	{
		byte[] byte_ = this.method_51(gclass104_1.byte_0[0]);
		base.method_3(byte_);
		GClass126.smethod_2("Current value read: " + GClass127.smethod_11(byte_), 0);
	}

	// Token: 0x06000150 RID: 336 RVA: 0x00022F68 File Offset: 0x00021168
	private void method_62()
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
										3,
										97,
										50,
										118
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
									gclass.method_1(this.r4(array[6], gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else if (gclass.string_0 == "Coolant Temperature")
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
									byte[] array3 = this.method_51(gclass.byte_0[0]);
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

	// Token: 0x06000151 RID: 337 RVA: 0x000234D8 File Offset: 0x000216D8
	private void method_63()
	{
		GClass126.smethod_2("KA started", 1);
		while (!this.bool_1)
		{
			Thread.Sleep(100);
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
				byte[] array = this.method_51(this.byte_3);
				if (!this.bool_3 && (array.Length < 2 || array[1] != 126))
				{
					GClass126.smethod_2("KA response error!", 1);
					if (array.Length == 0)
					{
						array = this.method_51(this.byte_3);
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

	// Token: 0x06000152 RID: 338 RVA: 0x00023638 File Offset: 0x00021838
	protected GClass23()
	{
		byte[] array = new byte[3];
		array[0] = 2;
		array[1] = 62;
		this.byte_3 = array;
		this.byte_4 = new byte[]
		{
			2,
			16,
			3
		};
		this.byte_5 = new byte[]
		{
			7,
			89,
			2,
			207,
			129,
			16,
			21,
			14,
			6,
			138,
			104,
			9
		};
		this.byte_6 = new byte[]
		{
			3,
			25,
			2,
			13
		};
		this.byte_7 = new byte[]
		{
			4,
			20,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue
		};
		this.byte_8 = new byte[]
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
			48
		};
		this.byte_9 = new byte[]
		{
			4,
			24,
			0,
			byte.MaxValue,
			0
		};
		this.byte_10 = new byte[]
		{
			3,
			20,
			byte.MaxValue,
			0
		};
		byte[] array2 = new byte[4];
		array2[0] = 3;
		array2[1] = 23;
		this.byte_11 = array2;
		this.string_22 = new string[]
		{
			"4F 59 04 04 03 13 0F 00 12 10 08 00 00 61 7F 10 09 00 01 20 0A 55 0A 60 82 13 10 00 0C A8 19 24 00 00 10 03 12 8E 18 D0 08 97 19 47 16 80 19 46 16 30 19 5A 03 C8 19 59 03 F0 19 3C 03 CB 19 3D 02 D8 10 02 00 00 19 1E 09 19 20 E0 19 49 31 62",
			"4F 59 04 04 03 13 0F 00 12 10 08 00 00 61 7F 10 09 00 01 20 0A 55 0A 60 82 13 10 00 0C A8 19 24 00 00 10 03 12 8E 18 D0 08 97 19 47 16 80 19 46 16 30 19 5A 03 C8 19 59 03 F0 19 3C 03 CB 19 3D 02 D8 10 02 00 00 19 1E 09 19 20 E0 19 49 31 62",
			"4F 59 04 04 03 13 0F 00 12 10 08 00 00 61 7F 10 09 00 01 20 0A 55 0A 60 82 13 10 00 0C A8 19 24 00 00 10 03 12 8E 18 D0 08 97 19 47 16 80 19 46 16 30 19 5A 03 C8 19 59 03 F0 19 3C 03 CB 19 3D 02 D8 10 02 00 00 19 1E 09 19 20 E0 19 49 31 62"
		};
		this.string_23 = "67 59 04 06 8A 68 08 00 19 10 08 00 00 7B 5E 10 09 00 00 20 0A 14 D4 60 82 68 10 00 00 00 19 1D 00 18 10 04 3F 71 19 1E 00 19 20 20 18 D0 00 00 19 3C 01 90 19 56 03 AB 10 03 08 7F 19 3F 00 00 19 5A 00 00 19 35 08 FC 18 9C 00 00 18 9B 00 00 19 65 08 51 19 0B 00 00 19 50 BC 8C 19 4D 00 19 55 00 18 AE C0 19 67 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
		this.char_1 = new char[]
		{
			'\r',
			'\n',
			' '
		};
		base..ctor();
	}

	// Token: 0x04000101 RID: 257
	protected int int_5 = 2000;

	// Token: 0x04000102 RID: 258
	protected byte[] byte_3;

	// Token: 0x04000103 RID: 259
	protected byte[] byte_4;

	// Token: 0x04000104 RID: 260
	protected byte[] byte_5;

	// Token: 0x04000105 RID: 261
	protected byte[] byte_6;

	// Token: 0x04000106 RID: 262
	protected byte[] byte_7;

	// Token: 0x04000107 RID: 263
	protected byte[] byte_8;

	// Token: 0x04000108 RID: 264
	protected byte[] byte_9;

	// Token: 0x04000109 RID: 265
	protected byte[] byte_10;

	// Token: 0x0400010A RID: 266
	protected byte[] byte_11;

	// Token: 0x0400010B RID: 267
	private string[] string_22;

	// Token: 0x0400010C RID: 268
	private string string_23;

	// Token: 0x0400010D RID: 269
	private char[] char_1;
}
