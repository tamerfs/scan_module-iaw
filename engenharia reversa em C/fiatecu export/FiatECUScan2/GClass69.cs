using System;
using System.Data;
using System.IO;
using System.Text;

// Token: 0x02000090 RID: 144
public sealed class GClass69
{
	// Token: 0x06000528 RID: 1320 RVA: 0x000039BF File Offset: 0x00001BBF
	public GClass69()
	{
		this.method_0();
		this.method_4();
	}

	// Token: 0x06000529 RID: 1321 RVA: 0x000039EA File Offset: 0x00001BEA
	public GClass69(string string_0)
	{
		this.method_0();
		this.method_2(string_0);
	}

	// Token: 0x0600052A RID: 1322 RVA: 0x00096094 File Offset: 0x00094294
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
		if (this.dataTable_0.Columns.Count > 7)
		{
			this.byte_0 = GClass3.byte_1;
		}
	}

	// Token: 0x0600052B RID: 1323 RVA: 0x00096250 File Offset: 0x00094450
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

	// Token: 0x0600052C RID: 1324 RVA: 0x000962B0 File Offset: 0x000944B0
	private void method_2(string string_0)
	{
		int num = 0;
		if (!GClass3.bool_3)
		{
			GClass61.smethod_15(GClass62.smethod_5()[0]);
		}
		for (int i = 0; i < GClass16.smethod_10().Length; i++)
		{
			if (GClass16.smethod_10()[i].StartsWith("lang"))
			{
				num++;
			}
			if (num != 0 && (num != 2 || num > 3) && num != 3 && !GClass16.smethod_10()[i].StartsWith("lang0"))
			{
				FileStream fileStream = new FileStream(GClass61.smethod_22() + "\\Files\\" + GClass16.smethod_10()[i] + ".dat", FileMode.Open, FileAccess.Read);
				byte[] array = new byte[26];
				int[] array2 = new int[13];
				while (fileStream.Position < fileStream.Length)
				{
					fileStream.Read(array, 0, array.Length);
					byte[] array3 = array;
					int num2 = 25;
					array3[num2] ^= array[2];
					byte[] array4 = array;
					int num3 = 24;
					array4[num3] ^= array[1];
					byte[] array5 = array;
					int num4 = 14;
					array5[num4] ^= array[15];
					byte[] array6 = array;
					int num5 = 21;
					array6[num5] ^= array[15];
					byte[] array7 = array;
					int num6 = 19;
					array7[num6] ^= array[14];
					byte[] array8 = array;
					int num7 = 18;
					array8[num7] ^= array[14];
					byte[] array9 = array;
					int num8 = 23;
					array9[num8] ^= array[12];
					byte[] array10 = array;
					int num9 = 16;
					array10[num9] ^= array[13];
					byte[] array11 = array;
					int num10 = 23;
					array11[num10] ^= array[22];
					byte[] array12 = array;
					int num11 = 20;
					array12[num11] ^= array[21];
					byte[] array13 = array;
					int num12 = 17;
					array13[num12] ^= array[20];
					byte[] array14 = array;
					int num13 = 15;
					array14[num13] ^= array[13];
					byte[] array15 = array;
					int num14 = 15;
					array15[num14] ^= array[12];
					byte[] array16 = array;
					int num15 = 2;
					array16[num15] ^= array[3];
					byte[] array17 = array;
					int num16 = 9;
					array17[num16] ^= array[3];
					byte[] array18 = array;
					int num17 = 7;
					array18[num17] ^= array[2];
					byte[] array19 = array;
					int num18 = 6;
					array19[num18] ^= array[2];
					byte[] array20 = array;
					int num19 = 11;
					array20[num19] ^= array[0];
					byte[] array21 = array;
					int num20 = 4;
					array21[num20] ^= array[1];
					byte[] array22 = array;
					int num21 = 11;
					array22[num21] ^= array[10];
					byte[] array23 = array;
					int num22 = 8;
					array23[num22] ^= array[9];
					byte[] array24 = array;
					int num23 = 5;
					array24[num23] ^= array[8];
					byte[] array25 = array;
					int num24 = 3;
					array25[num24] ^= array[1];
					byte[] array26 = array;
					int num25 = 3;
					array26[num25] ^= array[0];
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
					array28 = GClass66.smethod_0(array28);
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
						array27 = GClass66.smethod_0(array27);
						array29 = GClass66.smethod_0(array29);
						array30 = GClass66.smethod_0(array30);
						array31 = GClass66.smethod_0(array31);
						array32 = GClass66.smethod_0(array32);
						array33 = GClass66.smethod_0(array33);
						array34 = GClass66.smethod_0(array34);
						array35 = GClass66.smethod_0(array35);
						array36 = GClass66.smethod_0(array36);
						array37 = GClass66.smethod_0(array37);
						array38 = GClass66.smethod_0(array38);
						this.dataTable_0.Rows.Add(new object[]
						{
							GClass16.smethod_5(Encoding.Unicode.GetString(array27)),
							Encoding.Unicode.GetString(array28),
							this.method_1(array29),
							GClass16.smethod_5(Encoding.Unicode.GetString(array30)),
							GClass16.smethod_5(Encoding.Unicode.GetString(array31)),
							this.method_1(array32),
							this.method_1(array33),
							this.method_1(array34),
							Encoding.Unicode.GetString(array35),
							this.method_1(array36),
							this.method_1(array37),
							GClass16.smethod_5(Encoding.Unicode.GetString(array38))
						});
					}
				}
				fileStream.Close();
			}
		}
	}

	// Token: 0x0600052D RID: 1325 RVA: 0x00096968 File Offset: 0x00094B68
	private void method_3(string string_0, string string_1)
	{
		int num = 0;
		int num2 = 0;
		if (!GClass3.bool_3)
		{
			GClass61.smethod_15(GClass62.smethod_5()[0]);
		}
		num--;
		for (int i = 0; i < GClass16.smethod_10().Length; i++)
		{
			if (GClass16.smethod_10()[i].StartsWith("lang"))
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
			if (num2 != 0 && (num2 != 2 || num2 > 3) && num2 != 3 && !GClass16.smethod_10()[i].StartsWith("lang0"))
			{
				FileStream fileStream = new FileStream(GClass61.smethod_22() + "\\Files\\" + GClass16.smethod_10()[i] + ".dat", FileMode.Open, FileAccess.Read);
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
					array28 = GClass66.smethod_0(array28);
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
						if (GClass62.smethod_5()[num] != GClass61.smethod_14())
						{
							break;
						}
						array27 = GClass66.smethod_0(array27);
						array29 = GClass66.smethod_0(array29);
						array30 = GClass66.smethod_0(array30);
						array31 = GClass66.smethod_0(array31);
						array32 = GClass66.smethod_0(array32);
						array33 = GClass66.smethod_0(array33);
						array34 = GClass66.smethod_0(array34);
						array35 = GClass66.smethod_0(array35);
						array36 = GClass66.smethod_0(array36);
						array37 = GClass66.smethod_0(array37);
						array38 = GClass66.smethod_0(array38);
						this.dataTable_0.Rows.Add(new object[]
						{
							GClass16.smethod_5(Encoding.Unicode.GetString(array27)),
							Encoding.Unicode.GetString(array28),
							Encoding.Unicode.GetString(array29),
							GClass16.smethod_5(Encoding.Unicode.GetString(array30)),
							GClass16.smethod_5(Encoding.Unicode.GetString(array31)),
							Encoding.Unicode.GetString(array32),
							Encoding.Unicode.GetString(array33),
							Encoding.Unicode.GetString(array34),
							Encoding.Unicode.GetString(array35),
							Encoding.Unicode.GetString(array36),
							Encoding.Unicode.GetString(array37),
							GClass16.smethod_5(Encoding.Unicode.GetString(array38))
						});
					}
				}
				fileStream.Close();
			}
		}
	}

	// Token: 0x0600052E RID: 1326 RVA: 0x000970CC File Offset: 0x000952CC
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
			string.Empty,
			string.Empty,
			string.Empty,
			"No decription available",
			1770
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
			string.Empty,
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
			string.Empty,
			"No decription available",
			1818
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			1,
			"JTD4",
			"02 1A 99",
			1,
			4,
			"ECU programming date",
			"date",
			string.Empty,
			string.Empty,
			string.Empty,
			"No decription available",
			1819
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 03",
			1,
			3,
			"Odometer",
			"num,1",
			"km",
			string.Empty,
			string.Empty,
			"Shows actual number of km covered by vehicle. The value is stored in engine ECU. It ensures the exact number of km covered by the vehicle with maximum of 3% tolerance.  ",
			2004
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 08",
			1,
			1,
			"Engine overrevs",
			"num,0",
			string.Empty,
			string.Empty,
			string.Empty,
			"Number of engine overrev events. An overrev event occures when engine RPM exceeds a predefined limit. ",
			1950
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 09",
			1,
			2,
			"Max overrev time",
			"num,0,10",
			"ms",
			string.Empty,
			string.Empty,
			"Maximum time of engine running at high RPM. ",
			1851
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 0A",
			1,
			1,
			"Max engine speed",
			"num,0,40",
			"rpm",
			string.Empty,
			string.Empty,
			"No help available.",
			1688
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 0C",
			1,
			3,
			"Odometer at last rewrite",
			"num,1",
			"km",
			string.Empty,
			string.Empty,
			"Shows actual number of km covered by vehicle. The value is stored in engine ECU. It ensures the exact number of km covered by the vehicle with maximum of 3% tolerance.  ",
			1823
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 5F",
			1,
			2,
			"Fuel Temperature",
			"num,1,1,-2731.4",
			"°C",
			string.Empty,
			string.Empty,
			"Fuel temperature measured at fuel filter shown in °C.",
			1784
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 30",
			1,
			2,
			"Engine Speed",
			"num,0",
			"rpm",
			string.Empty,
			string.Empty,
			"Engine speed shown in crankshaft revolutions/min.",
			1989
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 36",
			1,
			2,
			"Fuel Metering",
			"num,2",
			"mg/i",
			string.Empty,
			string.Empty,
			"Fuel Quantity, shown in Milligrams/cycle.",
			1802
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 60",
			1,
			2,
			"Pre-injection fuel quantity",
			"num,1",
			"mg/i",
			string.Empty,
			string.Empty,
			"Pilot injection fuel quantity, shown in Milligrams/cycle.",
			1871
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 61",
			1,
			2,
			"Total Fuel Quantity",
			"num,2",
			"mg/i",
			string.Empty,
			string.Empty,
			"Fuel Quantity, shown in Milligrams/cycle.",
			1872
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 38",
			1,
			2,
			"Fuel Pressure",
			"num,1",
			"bar",
			string.Empty,
			string.Empty,
			"This item shows the Fuel Rail Pressure. Typical pressure values are about 400 Bar under light engine load up to max. 1350 Bar under heavy load. (Higher pressure may be used in later system versions: check if necessary)",
			1804
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 48",
			1,
			2,
			"Fuel Pressure Signal",
			"num,3,4.8876",
			"V",
			string.Empty,
			string.Empty,
			"Displays the sensor signal in Volt/mV/Ohm/mA.",
			1811
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 37",
			1,
			2,
			"Desired Fuel Pressure",
			"num,1",
			"bar",
			string.Empty,
			string.Empty,
			"The basic injection pressure set by the ECU is shown.",
			1803
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 39",
			1,
			2,
			"Fuel Pressure Regulator",
			"num,2",
			"%",
			string.Empty,
			string.Empty,
			"Fuel Pressure Regulator position/opening/control signal, shown in %.",
			1805
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 35",
			1,
			2,
			"Pre-injection Time",
			"num,3,0.976",
			"ms",
			string.Empty,
			string.Empty,
			"This item shows the Injection Time in Milliseconds.\r\nPlease Note: The opening time of the High Pressure Direct Injection (Common Rail) systems are very short due to the high system pressures, up to 1350 Bar. They can not be compared to the values of the electronic injections with lower system pressure.",
			1801
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 34",
			1,
			2,
			"Injection Time",
			"num,3,0.976",
			"ms",
			string.Empty,
			string.Empty,
			"This item shows the Injection Time in Milliseconds.\r\nPlease Note: The opening time of the High Pressure Direct Injection (Common Rail) systems are very short due to the high system pressures, up to 1350 Bar. They can not be compared to the values of the electronic injections with lower system pressure.",
			1800
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 32",
			1,
			2,
			"Injection Timing",
			"nums,2,2.344",
			"deg.",
			string.Empty,
			string.Empty,
			"The Injection Timing value is displayed in degrees.",
			1798
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 33",
			1,
			2,
			"Pre-Injection Timing",
			"nums,2,2.344",
			"deg.",
			string.Empty,
			string.Empty,
			"Pre-Injection Timing value in crankshaft degrees.",
			1799
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 01",
			1,
			1,
			"Universal Code",
			"bits",
			string.Empty,
			string.Empty,
			"2828Received|2808Not received|2800Not enabled",
			"This Immobilizer parameter shows the Universal code which is used temporarily to allow the starting of the car, when the Engine and Immobilizer ECUs are new and no keys have been programmed yet. (State RECEIVED)\r\nOnce the keys have been programmed (at the new car delivery) the universal code gets disabled and the status changes to the normal (PROGRAMMED ECU).\r\nIf the keys have not been programmed yet and the universal code is not received, NOT RECEIVED will appear. NOTE: Three different conditions may occur:\r\n- Received: Blank Electronic Key ECU and ECU with no error on the Electronic Key.\r\n- Not received: Blank Electronic Key ECU and ECU with errors in the Electronic Key\r\n- Disabled: Electronic Key ECU and ECU already programmed.",
			2023
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 3F",
			1,
			2,
			"Boost Control/Sol.",
			"num,2",
			"%",
			string.Empty,
			string.Empty,
			"This item shows the control value in percentage the ECU sends to the Overboost Valve to regulate the pressure. The value depends on the engine operating conditions at the time when the maximum power is required.",
			1810
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 46",
			2,
			1,
			"Boost Control/Sol.",
			"bits",
			string.Empty,
			string.Empty,
			"8000Not active|8080Active",
			"The function indicates the OVERBOOST strategy On/Off status.",
			2092
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
			"Displays the sensor signal in Volt/mV/Ohm/mA.",
			1787
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 3B",
			1,
			2,
			"Intake Air Quantity",
			"num,1",
			"mg/i",
			string.Empty,
			string.Empty,
			"Intake Air Quantity per cylinder.\r\nNOTE: the value is NOT valid for control units with SW C91 & C92.",
			1807
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 3A",
			1,
			2,
			"Desired Intake Air Quantity",
			"num,1",
			"mg/i",
			string.Empty,
			string.Empty,
			"The value shows calculated fuel injection amount or intake air quantity in mg/stroke.",
			1806
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 4E",
			1,
			2,
			"Air Flow Signal",
			"num,3,4.8876",
			"V",
			string.Empty,
			string.Empty,
			"Shows the Intake Air Flow Meter signal in Volts.",
			1785
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 51",
			1,
			1,
			"Glow plug heater module",
			"bits",
			string.Empty,
			string.Empty,
			"FF27Active|FF00Not active",
			"This item shows the Glow Control module activating the Pre- and Afterglow functions",
			1318
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 45",
			1,
			1,
			"CAN data line",
			"bits",
			string.Empty,
			string.Empty,
			"0800Not OK|0808OK",
			"When active, this function indicates that the CAN BUS self check has passed",
			1975
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 31",
			1,
			2,
			"Gas Pedal Position",
			"num,2",
			"%",
			string.Empty,
			string.Empty,
			"It displays the gas foot pedal position in percentage",
			1747
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			2,
			"JTD4",
			"02 21 42",
			1,
			2,
			"Engine Temperature",
			"num,1,1,-2731.4",
			"°C",
			string.Empty,
			string.Empty,
			"Engine temperature shown in °C.",
			1986
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			string.Empty,
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
			string.Empty,
			"6207",
			string.Empty,
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
			string.Empty,
			"6210",
			string.Empty,
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
			string.Empty,
			"6209",
			string.Empty,
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
			string.Empty,
			"6209",
			string.Empty,
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
			string.Empty,
			"6209",
			string.Empty,
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
			string.Empty,
			"6217",
			string.Empty,
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
			string.Empty,
			"6218",
			string.Empty,
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
			string.Empty,
			"6217",
			string.Empty,
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
			string.Empty,
			"6222",
			string.Empty,
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
			string.Empty,
			"6214",
			string.Empty,
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
			string.Empty,
			"6217",
			string.Empty,
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
			string.Empty,
			"6217",
			string.Empty,
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
			string.Empty,
			"6217",
			string.Empty,
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
			string.Empty,
			"6211",
			string.Empty,
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
			string.Empty,
			"6217",
			string.Empty,
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
			string.Empty,
			"6219",
			string.Empty,
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
			string.Empty,
			"6210",
			string.Empty,
			"The JTD Common rail fuel pump has three fuel supplying cylinders: When idling, it should only use two cyliinders in the pump to supply engine fuel.",
			1925
		});
	}

	// Token: 0x04000675 RID: 1653
	public DataTable dataTable_0;

	// Token: 0x04000676 RID: 1654
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
