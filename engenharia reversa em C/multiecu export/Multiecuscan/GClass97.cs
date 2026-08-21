using System;
using System.Data;
using System.IO;
using System.Text;

// Token: 0x02000079 RID: 121
public class GClass97
{
	// Token: 0x060003E1 RID: 993 RVA: 0x0000339E File Offset: 0x0000159E
	public GClass97()
	{
		this.method_0();
		this.method_4();
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x000033C9 File Offset: 0x000015C9
	public GClass97(string string_0)
	{
		this.method_0();
		this.method_2(string_0);
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x00064180 File Offset: 0x00062380
	private void method_0()
	{
		this.dataTable_0 = new DataTable();
		this.dataTable_0.Columns.Add("CmdType", typeof(int));
		this.dataTable_0.Columns.Add("ModuleID", typeof(string));
		this.dataTable_0.Columns.Add("Commands", typeof(string));
		this.dataTable_0.Columns.Add("StartByte", typeof(int));
		this.dataTable_0.Columns.Add("NumOfBytes", typeof(int));
		this.dataTable_0.Columns.Add("ParamName", typeof(string));
		this.dataTable_0.Columns.Add("ResultFormat", typeof(string));
		this.dataTable_0.Columns.Add("Units", typeof(string));
		this.dataTable_0.Columns.Add("MsgExec", typeof(string));
		this.dataTable_0.Columns.Add("BitResults", typeof(string));
		this.dataTable_0.Columns.Add("Description", typeof(string));
		this.dataTable_0.Columns.Add("MessageID", typeof(int));
		this.dataTable_0.Columns.Add("DescID", typeof(int));
		if (this.dataTable_0.Columns.Count > 8)
		{
			this.byte_0 = GClass126.byte_2;
		}
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x00064364 File Offset: 0x00062564
	private string method_1(byte[] byte_1)
	{
		int num = 0;
		for (int i = 0; i < byte_1.Length; i++)
		{
			int num2 = i;
			byte_1[num2] ^= this.byte_0[num];
			num++;
			if (num >= this.byte_0.Length)
			{
				num = 0;
			}
		}
		return Encoding.Unicode.GetString(byte_1);
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x000643B4 File Offset: 0x000625B4
	private void method_2(string string_0)
	{
		int num = 0;
		byte[] array = new byte[12];
		if (!GClass126.bool_13)
		{
			GClass125.smethod_23(GClass121.smethod_5()[0]);
		}
		for (int i = 0; i < GClass127.smethod_51().Length; i++)
		{
			if (GClass127.smethod_51()[i].StartsWith("lang"))
			{
				num++;
			}
			if (num != 0 && (num != 2 || num > 3) && num != 3 && !GClass127.smethod_51()[i].StartsWith("lang0"))
			{
				FileStream fileStream = new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.smethod_51()[i] + ".dat", FileMode.Open, FileAccess.Read);
				GClass126.smethod_2("LOAD DATA: Len0" + 1.ToString() + ": " + fileStream.Length.ToString(), 0);
				fileStream.Seek((long)GClass126.int_10, SeekOrigin.Begin);
				fileStream.Read(array, 0, array.Length);
				fileStream.Seek((long)GClass126.int_9, SeekOrigin.Begin);
				for (int j = 0; j < array.Length; j++)
				{
					byte[] array2 = array;
					int num2 = j;
					array2[num2] ^= 173;
				}
				if (GClass127.smethod_11(array) != GClass126.string_4 && !GClass126.bool_10)
				{
					GClass126.bool_13 = false;
				}
				byte[] array3 = new byte[28];
				int[] array4 = new int[14];
				while (fileStream.Position < fileStream.Length)
				{
					fileStream.Read(array3, 0, array3.Length);
					byte[] array5 = array3;
					int num3 = 27;
					array5[num3] ^= array3[1];
					byte[] array6 = array3;
					int num4 = 26;
					array6[num4] ^= array3[0];
					byte[] array7 = array3;
					int num5 = 25;
					array7[num5] ^= array3[2];
					byte[] array8 = array3;
					int num6 = 24;
					array8[num6] ^= array3[1];
					byte[] array9 = array3;
					int num7 = 14;
					array9[num7] ^= array3[15];
					byte[] array10 = array3;
					int num8 = 21;
					array10[num8] ^= array3[15];
					byte[] array11 = array3;
					int num9 = 19;
					array11[num9] ^= array3[14];
					byte[] array12 = array3;
					int num10 = 18;
					array12[num10] ^= array3[14];
					byte[] array13 = array3;
					int num11 = 23;
					array13[num11] ^= array3[12];
					byte[] array14 = array3;
					int num12 = 16;
					array14[num12] ^= array3[13];
					byte[] array15 = array3;
					int num13 = 23;
					array15[num13] ^= array3[22];
					byte[] array16 = array3;
					int num14 = 20;
					array16[num14] ^= array3[21];
					byte[] array17 = array3;
					int num15 = 17;
					array17[num15] ^= array3[20];
					byte[] array18 = array3;
					int num16 = 15;
					array18[num16] ^= array3[13];
					byte[] array19 = array3;
					int num17 = 15;
					array19[num17] ^= array3[12];
					byte[] array20 = array3;
					int num18 = 2;
					array20[num18] ^= array3[3];
					byte[] array21 = array3;
					int num19 = 9;
					array21[num19] ^= array3[3];
					byte[] array22 = array3;
					int num20 = 7;
					array22[num20] ^= array3[2];
					byte[] array23 = array3;
					int num21 = 6;
					array23[num21] ^= array3[2];
					byte[] array24 = array3;
					int num22 = 11;
					array24[num22] ^= array3[0];
					byte[] array25 = array3;
					int num23 = 4;
					array25[num23] ^= array3[1];
					byte[] array26 = array3;
					int num24 = 11;
					array26[num24] ^= array3[10];
					byte[] array27 = array3;
					int num25 = 8;
					array27[num25] ^= array3[9];
					byte[] array28 = array3;
					int num26 = 5;
					array28[num26] ^= array3[8];
					byte[] array29 = array3;
					int num27 = 3;
					array29[num27] ^= array3[1];
					byte[] array30 = array3;
					int num28 = 3;
					array30[num28] ^= array3[0];
					array4[0] = (int)array3[8] + 256 * (int)array3[0];
					array4[1] = (int)array3[3] + 256 * (int)array3[2];
					array4[2] = (int)array3[6] + 256 * (int)array3[10];
					array4[3] = (int)array3[1] + 256 * (int)array3[7];
					array4[4] = (int)array3[11] + 256 * (int)array3[5];
					array4[5] = (int)array3[9] + 256 * (int)array3[4];
					array4[6] = (int)array3[20] + 256 * (int)array3[12];
					array4[7] = (int)array3[15] + 256 * (int)array3[14];
					array4[8] = (int)array3[18] + 256 * (int)array3[22];
					array4[9] = (int)array3[13] + 256 * (int)array3[19];
					array4[10] = (int)array3[23] + 256 * (int)array3[17];
					array4[11] = (int)array3[21] + 256 * (int)array3[16];
					array4[12] = (int)array3[24] + 256 * (int)array3[25];
					array4[13] = (int)array3[26] + 256 * (int)array3[27];
					byte[] array31 = new byte[array4[1]];
					byte[] array32 = new byte[array4[2]];
					byte[] array33 = new byte[array4[3]];
					byte[] array34 = new byte[array4[4]];
					byte[] array35 = new byte[array4[5]];
					byte[] array36 = new byte[array4[6]];
					byte[] array37 = new byte[array4[7]];
					byte[] array38 = new byte[array4[8]];
					byte[] array39 = new byte[array4[9]];
					byte[] array40 = new byte[array4[10]];
					byte[] array41 = new byte[array4[11]];
					byte[] array42 = new byte[array4[12]];
					byte[] array43 = new byte[array4[13]];
					fileStream.Read(array31, 0, array31.Length);
					fileStream.Read(array32, 0, array32.Length);
					array32 = GClass103.smethod_0(array32);
					fileStream.Read(array33, 0, array33.Length);
					fileStream.Read(array34, 0, array34.Length);
					fileStream.Read(array35, 0, array35.Length);
					fileStream.Read(array36, 0, array36.Length);
					fileStream.Read(array37, 0, array37.Length);
					fileStream.Read(array38, 0, array38.Length);
					fileStream.Read(array39, 0, array39.Length);
					fileStream.Read(array40, 0, array40.Length);
					fileStream.Read(array41, 0, array41.Length);
					fileStream.Read(array42, 0, array42.Length);
					fileStream.Read(array43, 0, array43.Length);
					if (!(Encoding.Unicode.GetString(array32) != string_0))
					{
						array31 = GClass103.smethod_0(array31);
						array33 = GClass103.smethod_0(array33);
						array34 = GClass103.smethod_0(array34);
						array35 = GClass103.smethod_0(array35);
						array36 = GClass103.smethod_0(array36);
						array37 = GClass103.smethod_0(array37);
						array38 = GClass103.smethod_0(array38);
						array39 = GClass103.smethod_0(array39);
						array40 = GClass103.smethod_0(array40);
						array41 = GClass103.smethod_0(array41);
						array42 = GClass103.smethod_0(array42);
						array43 = GClass103.smethod_0(array43);
						this.dataTable_0.Rows.Add(new object[]
						{
							GClass127.smethod_37(Encoding.Unicode.GetString(array31)),
							Encoding.Unicode.GetString(array32),
							this.method_1(array33),
							GClass127.smethod_37(Encoding.Unicode.GetString(array34)),
							GClass127.smethod_37(Encoding.Unicode.GetString(array35)),
							this.method_1(array36),
							this.method_1(array37),
							this.method_1(array38),
							Encoding.Unicode.GetString(array39),
							this.method_1(array40),
							this.method_1(array41),
							GClass127.smethod_37(Encoding.Unicode.GetString(array42)),
							GClass127.smethod_37(Encoding.Unicode.GetString(array43))
						});
					}
				}
				fileStream.Close();
			}
		}
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x00064B00 File Offset: 0x00062D00
	private void method_3(string string_0, string string_1)
	{
		int num = 0;
		int num2 = 0;
		if (!GClass126.bool_13)
		{
			GClass125.smethod_23(GClass121.smethod_5()[0]);
		}
		num--;
		for (int i = 0; i < GClass127.smethod_51().Length; i++)
		{
			if (GClass127.smethod_51()[i].StartsWith("lang"))
			{
				num2++;
			}
			if (num2 == 1)
			{
				num++;
			}
			if (num2 > 1)
			{
				num = num2 + 1;
			}
			if (num2 == 0)
			{
				num = num2 - 2;
			}
			if (num2 != 0 && (num2 != 2 || num2 > 3) && num2 != 3 && !GClass127.smethod_51()[i].StartsWith("lang0"))
			{
				FileStream fileStream = new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.smethod_51()[i] + ".dat", FileMode.Open, FileAccess.Read);
				byte[] array = new byte[26];
				int[] array2 = new int[13];
				while (fileStream.Position < fileStream.Length)
				{
					fileStream.Read(array, 0, array.Length);
					byte[] array3 = array;
					int num3 = 25;
					array3[num3] ^= array[2];
					byte[] array4 = array;
					int num4 = 24;
					array4[num4] ^= array[1];
					byte[] array5 = array;
					int num5 = 14;
					array5[num5] ^= array[15];
					byte[] array6 = array;
					int num6 = 21;
					array6[num6] ^= array[15];
					byte[] array7 = array;
					int num7 = 19;
					array7[num7] ^= array[14];
					byte[] array8 = array;
					int num8 = 18;
					array8[num8] ^= array[14];
					byte[] array9 = array;
					int num9 = 23;
					array9[num9] ^= array[12];
					byte[] array10 = array;
					int num10 = 16;
					array10[num10] ^= array[13];
					byte[] array11 = array;
					int num11 = 23;
					array11[num11] ^= array[22];
					byte[] array12 = array;
					int num12 = 20;
					array12[num12] ^= array[21];
					byte[] array13 = array;
					int num13 = 17;
					array13[num13] ^= array[20];
					byte[] array14 = array;
					int num14 = 15;
					array14[num14] ^= array[13];
					byte[] array15 = array;
					int num15 = 15;
					array15[num15] ^= array[12];
					byte[] array16 = array;
					int num16 = 2;
					array16[num16] ^= array[3];
					byte[] array17 = array;
					int num17 = 9;
					array17[num17] ^= array[3];
					byte[] array18 = array;
					int num18 = 7;
					array18[num18] ^= array[2];
					byte[] array19 = array;
					int num19 = 6;
					array19[num19] ^= array[2];
					byte[] array20 = array;
					int num20 = 11;
					array20[num20] ^= array[0];
					byte[] array21 = array;
					int num21 = 4;
					array21[num21] ^= array[1];
					byte[] array22 = array;
					int num22 = 11;
					array22[num22] ^= array[10];
					byte[] array23 = array;
					int num23 = 8;
					array23[num23] ^= array[9];
					byte[] array24 = array;
					int num24 = 5;
					array24[num24] ^= array[8];
					byte[] array25 = array;
					int num25 = 3;
					array25[num25] ^= array[1];
					byte[] array26 = array;
					int num26 = 3;
					array26[num26] ^= array[0];
					array2[0] = (int)array[8] + 256 * (int)array[0];
					array2[1] = (int)array[3] + 256 * (int)array[2];
					array2[2] = (int)array[6] + 256 * (int)array[10];
					array2[3] = (int)array[1] + 256 * (int)array[7];
					array2[4] = (int)array[11] + 256 * (int)array[5];
					array2[5] = (int)array[9] + 256 * (int)array[4];
					array2[6] = (int)array[20] + 256 * (int)array[12];
					array2[7] = (int)array[15] + 256 * (int)array[14];
					array2[8] = (int)array[18] + 256 * (int)array[22];
					array2[9] = (int)array[13] + 256 * (int)array[19];
					array2[10] = (int)array[23] + 256 * (int)array[17];
					array2[11] = (int)array[21] + 256 * (int)array[16];
					array2[12] = (int)array[24] + 256 * (int)array[25];
					byte[] array27 = new byte[array2[1]];
					byte[] array28 = new byte[array2[2]];
					byte[] array29 = new byte[array2[3]];
					byte[] array30 = new byte[array2[4]];
					byte[] array31 = new byte[array2[5]];
					byte[] array32 = new byte[array2[6]];
					byte[] array33 = new byte[array2[7]];
					byte[] array34 = new byte[array2[8]];
					byte[] array35 = new byte[array2[9]];
					byte[] array36 = new byte[array2[10]];
					byte[] array37 = new byte[array2[11]];
					byte[] array38 = new byte[array2[12]];
					fileStream.Read(array27, 0, array27.Length);
					fileStream.Read(array28, 0, array28.Length);
					array28 = GClass103.smethod_0(array28);
					fileStream.Read(array29, 0, array29.Length);
					fileStream.Read(array30, 0, array30.Length);
					fileStream.Read(array31, 0, array31.Length);
					fileStream.Read(array32, 0, array32.Length);
					fileStream.Read(array33, 0, array33.Length);
					fileStream.Read(array34, 0, array34.Length);
					fileStream.Read(array35, 0, array35.Length);
					fileStream.Read(array36, 0, array36.Length);
					fileStream.Read(array37, 0, array37.Length);
					fileStream.Read(array38, 0, array38.Length);
					if (!(Encoding.Unicode.GetString(array28) != string_0))
					{
						if (GClass121.smethod_5()[num] != GClass125.smethod_22())
						{
							break;
						}
						array27 = GClass103.smethod_0(array27);
						array29 = GClass103.smethod_0(array29);
						array30 = GClass103.smethod_0(array30);
						array31 = GClass103.smethod_0(array31);
						array32 = GClass103.smethod_0(array32);
						array33 = GClass103.smethod_0(array33);
						array34 = GClass103.smethod_0(array34);
						array35 = GClass103.smethod_0(array35);
						array36 = GClass103.smethod_0(array36);
						array37 = GClass103.smethod_0(array37);
						array38 = GClass103.smethod_0(array38);
						this.dataTable_0.Rows.Add(new object[]
						{
							GClass127.smethod_37(Encoding.Unicode.GetString(array27)),
							Encoding.Unicode.GetString(array28),
							Encoding.Unicode.GetString(array29),
							GClass127.smethod_37(Encoding.Unicode.GetString(array30)),
							GClass127.smethod_37(Encoding.Unicode.GetString(array31)),
							Encoding.Unicode.GetString(array32),
							Encoding.Unicode.GetString(array33),
							Encoding.Unicode.GetString(array34),
							Encoding.Unicode.GetString(array35),
							Encoding.Unicode.GetString(array36),
							Encoding.Unicode.GetString(array37),
							GClass127.smethod_37(Encoding.Unicode.GetString(array38))
						});
					}
				}
				fileStream.Close();
			}
		}
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x0006517C File Offset: 0x0006337C
	private void method_4()
	{
		this.dataTable_0.Rows.Add(new object[]
		{
			1,
			"JTD4",
			"02 1A 97",
			1,
			5,
			"ECU ISO code",
			"hex",
			"",
			"",
			"",
			"No decription available",
			"Y",
			1816
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			1,
			"JTD4",
			"02 1A 91",
			1,
			11,
			"FIAT drawing number",
			"str",
			"",
			"",
			"",
			"No decription available",
			1817
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			1,
			"JTD4",
			"02 1A 92",
			1,
			11,
			"Hardware number",
			"str",
			"",
			"",
			"",
			"No decription available",
			1840
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			1,
			"JTD4",
			"02 1A 93",
			1,
			1,
			"Hardware version",
			"hex2",
			"",
			"",
			"",
			"No decription available",
			1781
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			1,
			"JTD4",
			"02 1A 94",
			1,
			11,
			"Software number",
			"str",
			"",
			"",
			"",
			"No decription available",
			1841
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			1,
			"JTD4",
			"02 1A 95",
			1,
			2,
			"Software version",
			"hex2",
			"",
			"",
			"",
			"No decription available",
			1782
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			1,
			"JTD4",
			"02 1A 96",
			1,
			6,
			"Homologation number",
			"str",
			"",
			"",
			"",
			"No decription available",
			1818
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 3E",
			1,
			2,
			"Boost Pressure",
			"num,0",
			"mBar",
			"",
			"",
			"Shows the Boost Pressure in mBar as signalled by the Boost Pressure Sensor.",
			1809
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 3D",
			1,
			2,
			"Desired Boost Pressure",
			"num,0",
			"mBar",
			"",
			"",
			"Boost Pressure (Calculated).",
			1808
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 3C",
			1,
			2,
			"Actual EGR",
			"num,2",
			"%",
			"",
			"",
			"This item shows the Actual EGR operating rate in %.",
			1744
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 4F",
			1,
			2,
			"Capacitor 1 Voltage",
			"num,3,99.747",
			"V",
			"",
			"",
			"The Injector/capacitor Control voltage is shown.\r\nCAUTION: The injector voltage is between 50 and 80 Volts. Take the necessary precautions when working on or close to any of the fuel injection components or circuitry. The high voltage can be stored in capacitors in the ECU long after the system has been powered down or disconnected.\r\nWARNING: Do not attempt to test the injectors with low voltage (e.g. 12V) methods. Permanent damage to the injectors may occur",
			1667
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 49",
			1,
			2,
			"Pedal Pos. Track 1",
			"num,3,4.8876",
			"V",
			"",
			"",
			"This item shows the Accelerator Pedal Position signal from the indicated track of the potentiometer.\r\nNOTE for some systems sensors with two tracks: If the ECU detects a fault in one circuit after a check, the system is swithced to the other one alone. The Throttle reaction speed is reduced and the opening is limited -gasoline motor- to about half of the range.\r\nIf both of the circuits are damaged anc the acceptability check fails, the Throttle position is limited to idle.",
			1812
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 4A",
			1,
			2,
			"Pedal Pos. Track 2",
			"num,3,4.8876",
			"V",
			"",
			"",
			"This item shows the Accelerator Pedal Position signal from the indicated track of the potentiometer.\r\nNOTE for some systems sensors with two tracks: If the ECU detects a fault in one circuit after a check, the system is swithced to the other one alone. The Throttle reaction speed is reduced and the opening is limited -gasoline motor- to about half of the range.\r\nIf both of the circuits are damaged anc the acceptability check fails, the Throttle position is limited to idle.",
			1813
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 44",
			1,
			2,
			"Vehicle speed",
			"num,2",
			"km/h",
			"",
			"",
			"Vehicle Speed in km/h",
			1988
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 41",
			1,
			2,
			"Air Temperature",
			"num,1,1,-2731.4",
			"°C",
			"",
			"",
			"Intake air temperature shown in °C.",
			2003
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 4D",
			1,
			2,
			"Air temperature signal",
			"num,3,4.8876",
			"V",
			"",
			"",
			"It displays the signal coming from the MAF temperature sensor in Volts.",
			1765
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 40",
			1,
			2,
			"Baro Pressure",
			"num,0",
			"mBar",
			"",
			"",
			"Displays the atmospheric pressure value received from a barometric sensor mounted inside the ECU.",
			1771
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 47",
			1,
			2,
			"Baro Pressure signal",
			"num,3,4.8876",
			"V",
			"",
			"",
			"Displays the sensor signal in Volt/mV/Ohm/mA.",
			1787
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 4C",
			1,
			2,
			"Engine Temperature Signal",
			"num,3,4.8876",
			"V",
			"",
			"",
			"It displays the signal coming from the engine temperature sensor in Volts.",
			1764
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 46",
			2,
			1,
			"Engine/ECU stop",
			"bits",
			"",
			"",
			"0400Not active|0404Active",
			"No help available at present",
			2085
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 43",
			1,
			2,
			"Battery Voltage",
			"num,3,23.612",
			"V",
			"",
			"",
			"Battery voltage, shown in Volts.",
			1557
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 C7",
			2,
			1,
			"Injector 1 Class",
			"bits",
			"",
			"",
			"0300Unclassified|0301Class 1|0302Class 2|0303Class 3",
			"Not available",
			2110
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 C7",
			2,
			1,
			"Injector 2 Class",
			"bits",
			"",
			"",
			"0C00Unclassified|0C04Class 1|0C08Class 2|0C0CClass 3",
			"Not available",
			2111
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 C7",
			2,
			1,
			"Injector 3 Class",
			"bits",
			"",
			"",
			"3000Unclassified|3010Class 1|3020Class 2|3030Class 3",
			"Not available",
			2112
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 C7",
			2,
			1,
			"Injector 4 Class",
			"bits",
			"",
			"",
			"C000Unclassified|C040Class 1|C080Class 2|C0C0Class 3",
			"Not available",
			2113
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 C7",
			1,
			1,
			"Injector 5 Class (for 2.4 only)",
			"bits",
			"",
			"",
			"FF00Unclassified|FFFFClass 1|FFFFClass 2|FFFFClass 3",
			"Not available",
			2114
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 45",
			1,
			1,
			"A/C press. sw. 1st lev.",
			"bits",
			"",
			"",
			"0400Not active|0404Active",
			"The function indicates the A/C pressure switch control operation rate.",
			1833
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 45",
			1,
			1,
			"A/C press. sw. 2nd lev.",
			"bits",
			"",
			"",
			"1000Not active|1010Active",
			"The function indicates the A/C pressure switch control operation rate.",
			1834
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 52",
			1,
			1,
			"Glow Indicator Light",
			"bits",
			"",
			"",
			"FF27ON|FF00OFF",
			"It indicates that the ECU is giving a command to the glow plugs pre-heating lamp in the instrument board.",
			1795
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 53",
			1,
			1,
			"Malfunction Indicator Light",
			"bits",
			"",
			"",
			"FF27ON|FF00OFF",
			"It indicates that the ECU is giving a command for the injection system breakdown lamp in the instrument board",
			1638
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 54",
			1,
			1,
			"Engine Overheat light",
			"bits",
			"",
			"",
			"FF27ON|FF00OFF",
			"Indicates that the ECU is operating the engine overheat lamp in the dashboard.",
			2143
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 55",
			1,
			1,
			"Fuel Pump",
			"bits",
			"",
			"",
			"FF27Active|FF00Not active",
			"It displays the ECU control for the fule pump relay",
			1430
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 56",
			1,
			1,
			"Fan 1st Speed",
			"bits",
			"",
			"",
			"FF27Active|FF00Not active",
			"This item shows the operating status of the engine cooling fan 1st, 2nd and 3rd stage.",
			1829
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 57",
			1,
			1,
			"Fan 2nd Speed",
			"bits",
			"",
			"",
			"FF27Active|FF00Not active",
			"This item shows the operating status of the engine cooling fan 1st, 2nd and 3rd stage.",
			1830
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 58",
			1,
			1,
			"A/C Compressor",
			"bits",
			"",
			"",
			"FF27Active|FF00Not active",
			"It enables when the ECU receives the compressor signal enabled from the relevant relay or by the A/C system pressure gauge",
			2022
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 45",
			1,
			1,
			"Brake Pedal Position",
			"bits",
			"",
			"",
			"0100Released|0101Pressed",
			"This item indicates the Brake Pedal depressed/released status",
			2099
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 45",
			1,
			1,
			"Ignition Key Position",
			"bits",
			"",
			"",
			"8000Stop|8080MAR",
			"It indicates that the ECU receiving the Ignition Switch feed (second release, + 15)",
			1745
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 45",
			2,
			1,
			"Clutch pedal",
			"bits",
			"",
			"",
			"0100Released|0101Pressed",
			"This item indicates the Clutch Pedal Depressed/Released status.",
			1789
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 45",
			2,
			1,
			"A/C Request",
			"bits",
			"",
			"",
			"0200Deactivated|0202Active",
			"It enables when the ECU receives the signal asking for the A/C system enabling by the driver",
			1749
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 46",
			2,
			1,
			"EGR Command",
			"bits",
			"",
			"",
			"4000Not active|4040Active",
			"This item shows the EGR valve operation as controlled by the ECU.",
			1794
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 01",
			1,
			1,
			"Immobilizer: key status",
			"bits",
			"",
			"",
			"0800Programmed|0808Not programmed",
			"When active, this data item indicates that the key programming procedure has been carried out",
			1756
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 01",
			1,
			1,
			"Engine Start Permission",
			"bits",
			"",
			"",
			"1000Allowed|1010Not allowed",
			"This item is an Immobilizer function, indicating if the ECU permits the starting, depending on that the correct key code is received.",
			2021
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 66",
			1,
			2,
			"3rd piston deactivation (if present)",
			"bits",
			"",
			"",
			"FF27Active|FF00Not active",
			"The JTD Common rail fuel pump has three fuel supplying cylinders: When idling, it should only use two cyliinders in the pump to supply engine fuel.",
			2033
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 45",
			1,
			1,
			"Preheating C.U. diagnostics",
			"bits",
			"",
			"",
			"0202OK|0200Not OK",
			"Not available",
			1815
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 45",
			2,
			1,
			"Cruise Switch",
			"bits",
			"",
			"",
			"2020ON|2000OFF",
			"When ON, the cruise speed set by the driver will be maintained automatically.",
			1857
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 45",
			2,
			1,
			"Set Cruise acceler.(+)",
			"bits",
			"",
			"",
			"0404Requested|0400Not requested",
			"When 'Requested', the vehicle speed set in the Cruise Control can be increased.",
			1859
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 45",
			2,
			1,
			"Set Cruise deceler.(-)",
			"bits",
			"",
			"",
			"0808Requested|0800Not requested",
			"When 'Requested', the vehicle speed set in the Cruise Control can be decreased.",
			1860
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 45",
			2,
			1,
			"Cruise restore button (RCL)",
			"bits",
			"",
			"",
			"1010Pressed|1000Released",
			"When pressed, it will return the vehicle to the last speed value stored by the Cruise Control.",
			1858
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 46",
			2,
			1,
			"Cruise control",
			"bits",
			"",
			"",
			"0202Active|0200Not active",
			"Not available",
			1220
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 59",
			1,
			1,
			"Cruise Control Indicator Light",
			"bits",
			"",
			"",
			"FF27ON|FF00OFF",
			"Shows the status of the cruise control lamp on the instrument panel.",
			1421
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 5B",
			2,
			1,
			"Cruise Disable Cause",
			"bits",
			"",
			"",
			"FF27ON|FF00OFF",
			"Not available",
			1873
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 5C",
			1,
			2,
			"Target Cruise Speed",
			"num,2",
			"km/h",
			"",
			"FF27ON|FF00OFF",
			"Not available",
			1869
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 5D",
			1,
			2,
			"Cruise Fuel Quantity",
			"num,1",
			"mg/i",
			"",
			"",
			"Quantity of diesel needed to maintain the vehicle speed set by the cruise control.",
			1870
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 45",
			1,
			1,
			"Oil Pressure Status",
			"bits",
			"",
			"",
			"2020OK|2000Not OK",
			"Not available",
			1922
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 62",
			1,
			1,
			"Oil Pressure Indicator",
			"bits",
			"",
			"",
			"FF27ON|FF00OFF",
			"Not available",
			2145
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 45",
			1,
			1,
			"Water in fuel",
			"bits",
			"",
			"",
			"4040Present|4000Not present",
			"Not available",
			1974
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 69",
			1,
			1,
			"Water in fuel (2)",
			"bits",
			"",
			"",
			"FF27ON|FF00OFF",
			"Not available",
			1970
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 56",
			1,
			1,
			"Fan PWM",
			"num,2",
			"%",
			"",
			"",
			"Not available",
			2037
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 64",
			1,
			1,
			"A/C Pressure",
			"num,3",
			"bar",
			"",
			"",
			"Not available",
			2062
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 03 07",
			1,
			2,
			"Fuel Pump",
			"str",
			"",
			"6207",
			"",
			"This function allows the actuation of the installed components. Observe the correct functioning of the selected device",
			1430
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 0C 07",
			1,
			2,
			"EGR Control",
			"str",
			"",
			"6210",
			"",
			"This function allows the actuation of the installed components. Observe the correct functioning of the selected device",
			2168
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 07 07",
			1,
			2,
			"Glow Plug relay",
			"str",
			"",
			"6209",
			"",
			"This function allows the actuation of the installed components. Observe the correct functioning of the selected device",
			2160
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 01 07",
			1,
			2,
			"A/C Compressor Relay",
			"str",
			"",
			"6209",
			"",
			"This function allows the actuation of the installed components. Observe the correct functioning of the selected device",
			1729
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 14 07",
			1,
			2,
			"Fuel filter heater relay",
			"str",
			"",
			"6209",
			"",
			"This function allows the actuation of the installed components. Observe the correct functioning of the selected device",
			1961
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 0D 07",
			1,
			2,
			"Fuel Pressure Regulator",
			"str",
			"",
			"6217",
			"",
			"This function allows the actuation of the installed components. Observe the correct functioning of the selected device",
			1232
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 02 07",
			1,
			2,
			"Fan 1st Speed",
			"str",
			"",
			"6218",
			"",
			"The relay for the engine cooling fans is set for the second speed (fast).\r\nRemark: if the A/C system is not installed the fan may run at one speed only",
			2117
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 10 07",
			1,
			2,
			"Inlet circ.throttle S.V.",
			"str",
			"",
			"6217",
			"",
			"This function operates the Inlet Manifold Flow Control Throttle solenoid",
			2101
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 05 07",
			1,
			2,
			"Malf. Indicator Light",
			"num,???",
			"",
			"6222",
			"",
			"The Malfunctioning Indicator light in the dashboard is actuated.",
			1638
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 06 07",
			1,
			2,
			"Glow Plug check light",
			"num,???",
			"",
			"6214",
			"",
			"This function allows the actuation of the installed components. Observe the correct functioning of the selected device",
			2132
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 0E 07",
			1,
			2,
			"Cruise lamp",
			"num,???",
			"",
			"6217",
			"",
			"This function allows the actuation of the installed components. Observe the correct functioning of the selected device",
			1421
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 08 07",
			1,
			2,
			"Coolant temperature light",
			"num,???",
			"",
			"6217",
			"",
			"This function allows the actuation of the installed components. Observe the correct functioning of the selected device",
			1624
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 17 07",
			1,
			2,
			"Fuel filter water light",
			"num,???",
			"",
			"6217",
			"",
			"This function allows the actuation of the installed components. Observe the correct functioning of the selected device",
			1970
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 0F 07",
			1,
			2,
			"Oil Pressure Light",
			"num,???",
			"",
			"6211",
			"",
			"This function allows the actuation of the installed components. Observe the correct functioning of the selected device",
			1874
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 0B 07",
			1,
			2,
			"Boost Control Solenoid",
			"str",
			"",
			"6217",
			"",
			"This function allows the actuation of the installed components. Observe the correct functioning of the selected device",
			2094
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 04 07",
			1,
			2,
			"Fan 2nd Speed",
			"str",
			"",
			"6219",
			"",
			"The relay for the engine cooling fans is set for the first speed (slow).\r\nRemark: if the A/C system is not installed the fan may run at one speed only",
			2118
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			3,
			"JTD4",
			"03 30 11 07",
			1,
			2,
			"3rd piston deactivation (if present)",
			"str",
			"",
			"6210",
			"",
			"The JTD Common rail fuel pump has three fuel supplying cylinders: When idling, it should only use two cyliinders in the pump to supply engine fuel.",
			1925
		});
	}

	// Token: 0x04000297 RID: 663
	public DataTable dataTable_0;

	// Token: 0x04000298 RID: 664
	private byte[] byte_0 = new byte[]
	{
		5,
		4,
		3,
		2,
		1,
		0
	};
}
