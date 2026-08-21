using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x0200001D RID: 29
public abstract class GClass70 : GClass11
{
	// Token: 0x060001C1 RID: 449 RVA: 0x0002EDA0 File Offset: 0x0002CFA0
	private byte[] method_45(byte[] byte_9)
	{
		if (this.serialPort_0 != null && this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		List<byte> list = new List<byte>();
		if (byte_9.Length < 1)
		{
			return new byte[0];
		}
		List<byte[]> list2 = new List<byte[]>();
		list2.Add(new byte[byte_9.Length]);
		for (int i = 0; i < byte_9.Length; i++)
		{
			list2[0][i] = byte_9[i];
		}
		if (list2.Count <= 1)
		{
			if (list2.Count == 1 && GClass125.smethod_49() && list2[0].Length == 2 && list2[0][0] == 255)
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
		}
		this.int_0 = GClass126.smethod_1();
		string text = this.rb();
		text = text.TrimStart(this.char_1);
		if (text.Contains("NO DATA") || text.Contains("ERROR") || text.Contains("BUFFER") || text.Contains("WRONG") || text.Contains("?"))
		{
			if (!this.bool_0)
			{
				if (text.Contains("WRONG"))
				{
					this.string_8 = "WRONG PINS";
				}
				else
				{
					this.string_9 = text.Replace("\r", "").Replace("\n", "").Replace(">", "");
				}
			}
			return new byte[0];
		}
		string[] array = text.Split(this.char_2);
		List<string> list3 = new List<string>();
		for (int j = 0; j < array.Length; j++)
		{
			if (!GClass127.smethod_35(array[j], this.string_22 + "7F0?78") && !GClass127.smethod_35(array[j], this.string_22 + "037F0?78") && GClass127.smethod_35(array[j], this.string_22) && array[j].Length >= 2)
			{
				list3.Add(array[j]);
				GClass126.smethod_2("Line " + list3.Count.ToString() + ": " + array[j], 0);
			}
		}
		if (list3.Count == 0)
		{
			return new byte[0];
		}
		if (list3[0].Length == 3 && (list3[0][0] == '0' || list3[0][0] == '1'))
		{
			byte item = 0;
			try
			{
				item = GClass127.smethod_32(list3[0].Substring(1))[0];
				if (list3[0][0] != '0')
				{
					item = byte.MaxValue;
				}
			}
			catch (Exception)
			{
			}
			list.Add(item);
			for (int k = 1; k < list3.Count; k++)
			{
				if (list3[k].Length > 2 && list3[k][1] == ':')
				{
					byte[] array2 = GClass127.smethod_32(list3[k].Substring(2));
					for (int l = 0; l < array2.Length; l++)
					{
						list.Add(array2[l]);
					}
				}
			}
		}
		else if (GClass127.smethod_35(list3[0], this.string_22) && this.string_22.StartsWith("8"))
		{
			byte b = GClass127.smethod_32(list3[0])[0];
			b -= 128;
			string str = list3[0].Substring(this.string_22.Length, 4);
			byte[] array3 = GClass127.smethod_32(list3[0].Substring(this.string_22.Length));
			if (array3.Length != 0)
			{
				list.Add(0);
			}
			int num = 0;
			while (num < array3.Length && num < (int)b)
			{
				list.Add(array3[num]);
				num++;
			}
			for (int m = 1; m < list3.Count; m++)
			{
				if (GClass127.smethod_35(list3[m], this.string_22 + str))
				{
					b = GClass127.smethod_32(list3[m])[0];
					b -= 128;
					array3 = GClass127.smethod_32(list3[m].Substring(this.string_22.Length));
					int num2 = 3;
					while (num2 < array3.Length && num2 < (int)b)
					{
						list.Add(array3[num2]);
						num2++;
					}
				}
			}
		}
		else
		{
			byte[] array4 = GClass127.smethod_32(list3[0]);
			if (array4.Length == 0)
			{
				return new byte[0];
			}
			list.Add((byte)array4.Length);
			for (int n = 0; n < array4.Length; n++)
			{
				list.Add(array4[n]);
			}
		}
		GClass126.smethod_2("DECODED RESPONSE: " + GClass127.smethod_11(list.ToArray()), 0);
		byte[] array5 = list.ToArray();
		if (list.Count > 0 && list[0] > 0 && list[0] < 255 && (int)list[0] < list.Count - 1)
		{
			array5 = new byte[(int)(list[0] + 1)];
			for (int num3 = 0; num3 <= (int)list[0]; num3++)
			{
				array5[num3] = list[num3];
			}
			GClass126.smethod_2("CLEANED RESPONSE: " + GClass127.smethod_11(array5), 0);
		}
		return array5;
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x0002F384 File Offset: 0x0002D584
	protected void method_46()
	{
		if (GClass126.bool_0)
		{
			for (int i = 0; i < 20; i++)
			{
				if (GClass126.bool_25)
				{
					throw new Exception("ESC");
				}
				Thread.Sleep(100);
			}
			int num = 0;
			byte[] array = GClass127.smethod_32("06 41 00 98 3B 00 11");
			if (array.Length > 5)
			{
				this.method_49(array[3], num);
				num += 8;
				this.method_49(array[4], num);
				num += 8;
				this.method_49(array[5], num);
				num += 8;
				this.method_49(array[6], num);
				num += 8;
			}
			if (this.byte_8[32] != 0)
			{
				array = GClass127.smethod_32("06 41 20 A0 12 20 01");
				if (array.Length > 5)
				{
					this.method_49(array[3], num);
					num += 8;
					this.method_49(array[4], num);
					num += 8;
					this.method_49(array[5], num);
					num += 8;
					this.method_49(array[6], num);
					num += 8;
				}
			}
			if (this.byte_8[64] != 0)
			{
				array = GClass127.smethod_32("06 41 40 80 C0 00 00");
				if (array.Length > 5)
				{
					this.method_49(array[3], num);
					num += 8;
					this.method_49(array[4], num);
					num += 8;
					this.method_49(array[5], num);
					num += 8;
					this.method_49(array[6], num);
					num += 8;
				}
			}
			List<GClass104> list = new List<GClass104>();
			for (int j = 0; j < this.list_0.Count; j++)
			{
				if (this.byte_8[(int)this.list_0[j].byte_0[0][1]] != 0)
				{
					list.Add(this.list_0[j]);
				}
			}
			this.list_0.Clear();
			foreach (GClass104 item in list)
			{
				this.list_0.Add(item);
			}
			GClass126.smethod_2("Testing mode!", 1);
			for (int k = 0; k < this.list_1.Count; k++)
			{
				GClass104 gclass = this.list_1[k];
				string text = "";
				if (GClass127.smethod_11(gclass.byte_0[0]) == "09 02")
				{
					text = this.r4(GClass127.smethod_32("14 49 02 01 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20"), gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				else if (GClass127.smethod_11(gclass.byte_0[0]) == "09 04")
				{
					text = this.r4(GClass127.smethod_32("13 49 04 01 31 39 34 32 50 31 32 35 20 20 20 00 00 00 00 00"), gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6);
				}
				gclass.method_1(text);
				if (gclass.int_2 == 10455)
				{
					this.string_7 = text;
				}
			}
			this.bool_1 = false;
			this.bool_0 = true;
			new Thread(new ThreadStart(this.method_52))
			{
				Priority = ThreadPriority.Highest
			}.Start();
			base.method_36();
			throw new Exception("1");
		}
	}

	// Token: 0x060001C3 RID: 451
	protected abstract void r6();

	// Token: 0x060001C4 RID: 452 RVA: 0x00006F88 File Offset: 0x00005188
	private string method_47(byte byte_9)
	{
		string result = "";
		if ((byte_9 & 9) == 8)
		{
			result = GClass121.smethod_6("3054");
		}
		else if ((byte_9 & 1) == 1)
		{
			result = GClass121.smethod_6("3062");
		}
		return result;
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x0002F69C File Offset: 0x0002D89C
	public override string vmethod_0(byte[] byte_9, string string_23, int int_6, int int_7, string[] string_24, string string_25)
	{
		byte[] byte_10 = this.method_51(byte_9);
		if (string_23 == "raw")
		{
			return GClass127.smethod_11(byte_10);
		}
		return this.r4(byte_10, string_23, int_6, int_7, string_24, string_25);
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x0002F6D4 File Offset: 0x0002D8D4
	private void method_48(GClass104 gclass104_1)
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
		for (int i = 0; i < gclass104_1.byte_0.Length; i++)
		{
			byte[] array = this.method_51(gclass104_1.byte_0[i]);
			if (!flag)
			{
				if (array.Length != 0)
				{
					if (array.Length <= 1 || array[1] != 127)
					{
						goto IL_FD;
					}
				}
				string string_;
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
				else if (array[3] == 49)
				{
					string_ = GClass121.smethod_6("6507");
				}
				else if (array[3] == 120)
				{
					string_ = GClass121.smethod_6("6502");
				}
				else if (array[3] == 16)
				{
					string_ = GClass121.smethod_6("6503");
				}
				else if (array[3] == 18)
				{
					string_ = GClass121.smethod_6("6504");
				}
				else if (array[3] == 33)
				{
					string_ = GClass121.smethod_6("6505");
				}
				else if (array[3] == 36)
				{
					string_ = "Incorrect sequence";
				}
				else if (array[3] == 129)
				{
					string_ = "RPM too high";
				}
				else if (array[3] == 130)
				{
					string_ = "RPM too low";
				}
				else if (array[3] == 131)
				{
					string_ = "Engine running";
				}
				else if (array[3] == 132)
				{
					string_ = "Engine not running";
				}
				else if (array[3] == 133)
				{
					string_ = "Engine run time not enough";
				}
				else if (array[3] == 134)
				{
					string_ = "Temperature too high";
				}
				else if (array[3] == 135)
				{
					string_ = "Temperature too low";
				}
				else if (array[3] == 136)
				{
					string_ = "Vehicle speed too high";
				}
				else if (array[3] == 137)
				{
					string_ = "Vehicle speed too low";
				}
				else if (array[3] == 138)
				{
					string_ = "Throttle/pedal too high";
				}
				else if (array[3] == 139)
				{
					string_ = "Throttle/pedal too low";
				}
				else if (array[3] == 140)
				{
					string_ = "Transmission in Neutral";
				}
				else if (array[3] == 141)
				{
					string_ = "Transmission in gear";
				}
				else if (array[3] == 143)
				{
					string_ = "Brake pedal";
				}
				else if (array[3] == 144)
				{
					string_ = "Transmission not in Park";
				}
				else if (array[3] == 145)
				{
					string_ = "Torque converter locked";
				}
				else if (array[3] == 146)
				{
					string_ = "Voltage too high";
				}
				else if (array[3] == 147)
				{
					string_ = "Voltage too low";
				}
				else
				{
					string_ = GClass121.smethod_6("6055") + " " + GClass127.smethod_23(array[3]);
				}
				base.method_28(false, GClass121.smethod_6("6052"), string_);
				return;
			}
			IL_FD:
			if (i < gclass104_1.byte_0.Length - 1 || gclass104_1.byte_0.Length == 1)
			{
				for (int j = 0; j < num; j++)
				{
					if (GClass126.bool_25 && flag2)
					{
						GClass126.smethod_2(GClass121.smethod_6("6081"), 2);
						array = this.method_51(gclass104_1.byte_0[gclass104_1.byte_0.Length - 1]);
						base.method_28(false, GClass121.smethod_6("6082"), " ");
						return;
					}
					Thread.Sleep(100);
				}
			}
		}
		base.method_28(false, GClass121.smethod_6("6051"), "");
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x00002F0A File Offset: 0x0000110A
	public override void r7(List<GClass102> list_6, List<GClass104> list_7)
	{
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x0002FB20 File Offset: 0x0002DD20
	public override string r4(byte[] byte_9, string string_23, int int_6, int int_7, string[] string_24, string string_25)
	{
		string result = "";
		int_6 += 2;
		if (byte_9.Length <= int_6)
		{
			return result;
		}
		if (byte_9[1] == 127 && string_23 != "hex3")
		{
			return result;
		}
		int num = byte_9.Length - int_6;
		if (int_7 < num)
		{
			num = int_7;
		}
		byte[] array = new byte[num];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = byte_9[i + int_6];
		}
		GClass126.smethod_2("CLEANED BYTES: " + GClass127.smethod_11(array), 0);
		return base.method_33(array, string_23, string_24, string_25);
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x0002FBA8 File Offset: 0x0002DDA8
	protected override void r3(GClass104 gclass104_1)
	{
		if (!GClass126.bool_0 && !(GClass123.string_2 != GClass123.string_3))
		{
			this.method_48(gclass104_1);
			return;
		}
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
	}

	// Token: 0x060001CA RID: 458 RVA: 0x0002FC40 File Offset: 0x0002DE40
	private void method_49(byte byte_9, int int_6)
	{
		if ((byte_9 & 128) == 0)
		{
			this.byte_8[int_6 + 1] = 0;
		}
		else
		{
			this.byte_8[int_6 + 1] = 1;
		}
		if ((byte_9 & 64) == 0)
		{
			this.byte_8[int_6 + 2] = 0;
		}
		else
		{
			this.byte_8[int_6 + 2] = 1;
		}
		if ((byte_9 & 32) == 0)
		{
			this.byte_8[int_6 + 3] = 0;
		}
		else
		{
			this.byte_8[int_6 + 3] = 1;
		}
		if ((byte_9 & 16) == 0)
		{
			this.byte_8[int_6 + 4] = 0;
		}
		else
		{
			this.byte_8[int_6 + 4] = 1;
		}
		if ((byte_9 & 8) == 0)
		{
			this.byte_8[int_6 + 5] = 0;
		}
		else
		{
			this.byte_8[int_6 + 5] = 1;
		}
		if ((byte_9 & 4) == 0)
		{
			this.byte_8[int_6 + 6] = 0;
		}
		else
		{
			this.byte_8[int_6 + 6] = 1;
		}
		if ((byte_9 & 2) == 0)
		{
			this.byte_8[int_6 + 7] = 0;
		}
		else
		{
			this.byte_8[int_6 + 7] = 1;
		}
		if ((byte_9 & 1) == 0)
		{
			this.byte_8[int_6 + 8] = 0;
			return;
		}
		this.byte_8[int_6 + 8] = 1;
	}

	// Token: 0x060001CB RID: 459 RVA: 0x0002FD3C File Offset: 0x0002DF3C
	public override void vmethod_1()
	{
		try
		{
			GClass126.smethod_2("-----------------------", 0);
			GClass126.smethod_2("Control module (OBDII): " + GClass127.smethod_23(this.byte_0), 0);
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
				this.method_46();
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
				Thread thread = new Thread(new ThreadStart(this.method_53));
				thread.Priority = ThreadPriority.Highest;
				this.bool_1 = false;
				thread.Start();
				new Thread(new ThreadStart(this.method_52))
				{
					Priority = ThreadPriority.Highest
				}.Start();
			}
			int num = 0;
			byte[] array = this.method_51(GClass127.smethod_32("0100"));
			if (array.Length > 5)
			{
				this.method_49(array[3], num);
				num += 8;
				this.method_49(array[4], num);
				num += 8;
				this.method_49(array[5], num);
				num += 8;
				this.method_49(array[6], num);
				num += 8;
			}
			if (this.byte_8[32] != 0)
			{
				array = this.method_51(GClass127.smethod_32("0120"));
				if (array.Length > 5)
				{
					this.method_49(array[3], num);
					num += 8;
					this.method_49(array[4], num);
					num += 8;
					this.method_49(array[5], num);
					num += 8;
					this.method_49(array[6], num);
					num += 8;
				}
			}
			if (this.byte_8[64] != 0)
			{
				array = this.method_51(GClass127.smethod_32("0140"));
				if (array.Length > 5)
				{
					this.method_49(array[3], num);
					num += 8;
					this.method_49(array[4], num);
					num += 8;
					this.method_49(array[5], num);
					num += 8;
					this.method_49(array[6], num);
					num += 8;
				}
			}
			if (this.byte_8[96] != 0)
			{
				array = this.method_51(GClass127.smethod_32("0160"));
				if (array.Length > 5)
				{
					this.method_49(array[3], num);
					num += 8;
					this.method_49(array[4], num);
					num += 8;
					this.method_49(array[5], num);
					num += 8;
					this.method_49(array[6], num);
					num += 8;
				}
			}
			if (this.byte_8[128] != 0)
			{
				array = this.method_51(GClass127.smethod_32("0180"));
				if (array.Length > 5)
				{
					this.method_49(array[3], num);
					num += 8;
					this.method_49(array[4], num);
					num += 8;
					this.method_49(array[5], num);
					num += 8;
					this.method_49(array[6], num);
					num += 8;
				}
			}
			if (this.byte_8[160] != 0)
			{
				array = this.method_51(GClass127.smethod_32("01A0"));
				if (array.Length > 5)
				{
					this.method_49(array[3], num);
					num += 8;
					this.method_49(array[4], num);
					num += 8;
					this.method_49(array[5], num);
					num += 8;
					this.method_49(array[6], num);
					num += 8;
				}
			}
			if (this.byte_8[192] != 0)
			{
				array = this.method_51(GClass127.smethod_32("01C0"));
				if (array.Length > 5)
				{
					this.method_49(array[3], num);
					num += 8;
					this.method_49(array[4], num);
					num += 8;
					this.method_49(array[5], num);
					num += 8;
					this.method_49(array[6], num);
					num += 8;
				}
			}
			List<GClass104> list = new List<GClass104>();
			for (int j = 0; j < this.list_0.Count; j++)
			{
				if (this.byte_8[(int)this.list_0[j].byte_0[0][1]] != 0)
				{
					list.Add(this.list_0[j]);
				}
			}
			this.list_0.Clear();
			foreach (GClass104 item in list)
			{
				this.list_0.Add(item);
			}
			SortedList<string, byte[]> sortedList = new SortedList<string, byte[]>();
			for (int k = 0; k < this.list_1.Count; k++)
			{
				GClass104 gclass = this.list_1[k];
				if (sortedList.ContainsKey(GClass127.smethod_11(gclass.byte_0[0])))
				{
					byte[] array2 = sortedList[GClass127.smethod_11(gclass.byte_0[0])];
					gclass.method_1(this.r4(array2, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
				}
				else
				{
					byte[] value = this.method_51(gclass.byte_0[0]);
					gclass.method_1(this.r4(value, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
					sortedList.Add(GClass127.smethod_11(gclass.byte_0[0]), value);
				}
				if (gclass.int_2 == 10455)
				{
					this.string_7 = gclass.method_0();
					GClass126.smethod_2("ECU ISO Code: " + gclass.method_0(), 0);
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

	// Token: 0x060001CC RID: 460 RVA: 0x00006FC4 File Offset: 0x000051C4
	private string method_50(byte byte_9)
	{
		string result = "";
		if ((byte_9 & 128) != 0)
		{
			result = GClass121.smethod_6("3051");
		}
		return result;
	}

	// Token: 0x060001CD RID: 461 RVA: 0x000303B0 File Offset: 0x0002E5B0
	public override void r2()
	{
		if (!GClass126.bool_0 && !(GClass123.string_2 != GClass123.string_3))
		{
			byte[] array = this.method_51(this.byte_7);
			if (array.Length < 2 || array[1] != 68)
			{
				GClass126.smethod_2("ERROR: Error clearing stored DTCs", 1);
			}
			return;
		}
		byte[] array2 = new byte[3];
		array2[0] = 2;
		array2[1] = 67;
		this.byte_5 = array2;
	}

	// Token: 0x060001CE RID: 462 RVA: 0x00030410 File Offset: 0x0002E610
	protected byte[] method_51(byte[] byte_9)
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
			byte[] array = this.method_45(byte_9);
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
					GClass126.smethod_2("Terminate 5", 1);
					base.method_30(true);
				}
			}
			this.bool_2 = false;
			result = new byte[0];
		}
		return result;
	}

	// Token: 0x060001CF RID: 463 RVA: 0x000304D4 File Offset: 0x0002E6D4
	public override List<GClass102> r1()
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
		if (array.Length < 3 || array[1] != 67)
		{
			array = this.method_51(this.byte_6);
		}
		if (array.Length >= 3)
		{
			if (array[1] == 67)
			{
				for (int i = 2; i < array.Length - 2; i += 2)
				{
					GClass102 gclass = new GClass102();
					gclass.string_0 = GClass127.smethod_11(new byte[]
					{
						array[i],
						array[i + 1]
					}).Replace(" ", "");
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
					}).Replace(" ", "");
					if (gclass.string_0 != "0000")
					{
						list.Add(gclass);
					}
				}
				return list;
			}
		}
		GClass126.smethod_2("ERROR: Error reading stored DTC codes", 1);
		return null;
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x00030640 File Offset: 0x0002E840
	private void method_52()
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
								gclass.method_1(this.random_0.Next(0, 100).ToString() ?? "");
								Thread.Sleep(50);
							}
							else
							{
								if (sortedList.ContainsKey(GClass127.smethod_11(gclass.byte_0[0])))
								{
									byte[] array = sortedList[GClass127.smethod_11(gclass.byte_0[0])];
									gclass.method_1(this.r4(array, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
								}
								else
								{
									byte[] array2 = this.method_51(gclass.byte_0[0]);
									gclass.method_1(this.r4(array2, gclass.string_2, gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
									sortedList.Add(GClass127.smethod_11(gclass.byte_0[0]), array2);
									if (array2.Length != 0)
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

	// Token: 0x060001D1 RID: 465 RVA: 0x000309C4 File Offset: 0x0002EBC4
	private void method_53()
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
				if (!this.bool_3 && (array.Length < 2 || array[1] != 65))
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

	// Token: 0x060001D2 RID: 466 RVA: 0x00030B24 File Offset: 0x0002ED24
	protected GClass70()
	{
		byte[] array = new byte[2];
		array[0] = 1;
		this.byte_3 = array;
		byte[] array2 = new byte[2];
		array2[0] = 1;
		this.byte_4 = array2;
		this.byte_5 = new byte[]
		{
			5,
			67,
			5,
			33,
			3,
			128
		};
		this.byte_6 = new byte[]
		{
			3
		};
		this.byte_7 = new byte[]
		{
			4
		};
		this.byte_8 = new byte[256];
		this.char_1 = new char[]
		{
			'\r',
			'\n',
			' '
		};
		this.char_2 = new char[]
		{
			'\r',
			'\n',
			'>'
		};
		base..ctor();
	}

	// Token: 0x04000144 RID: 324
	protected string string_22 = "";

	// Token: 0x04000145 RID: 325
	protected int int_5 = 5000;

	// Token: 0x04000146 RID: 326
	protected byte[] byte_3;

	// Token: 0x04000147 RID: 327
	protected byte[] byte_4;

	// Token: 0x04000148 RID: 328
	protected byte[] byte_5;

	// Token: 0x04000149 RID: 329
	protected byte[] byte_6;

	// Token: 0x0400014A RID: 330
	protected byte[] byte_7;

	// Token: 0x0400014B RID: 331
	protected byte[] byte_8;

	// Token: 0x0400014C RID: 332
	private char[] char_1;

	// Token: 0x0400014D RID: 333
	private char[] char_2;
}
