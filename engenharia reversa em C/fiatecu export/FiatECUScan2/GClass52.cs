using System;
using System.Data;
using System.IO;
using System.Text;

// Token: 0x02000023 RID: 35
public sealed class GClass52
{
	// Token: 0x06000183 RID: 387 RVA: 0x00002DAF File Offset: 0x00000FAF
	public GClass52()
	{
		this.method_0();
		this.method_2();
	}

	// Token: 0x06000184 RID: 388 RVA: 0x00002DC3 File Offset: 0x00000FC3
	public GClass52(string string_0)
	{
		this.method_0();
		this.method_1(string_0);
	}

	// Token: 0x06000185 RID: 389 RVA: 0x00039D74 File Offset: 0x00037F74
	private void method_0()
	{
		this.dataTable_0 = new DataTable();
		this.dataTable_0.Columns.Add("ModuleID", typeof(string));
		this.dataTable_0.Columns.Add("ErrorCode", typeof(string));
		this.dataTable_0.Columns.Add("Error", typeof(string));
		this.dataTable_0.Columns.Add("Description", typeof(string));
		this.dataTable_0.Columns.Add("MessageID", typeof(int));
	}

	// Token: 0x06000186 RID: 390 RVA: 0x00039E2C File Offset: 0x0003802C
	private void method_1(string string_0)
	{
		int num = 0;
		int num2 = -1;
		for (int i = 0; i < GClass16.smethod_10().Length; i++)
		{
			if (GClass16.smethod_10()[i].StartsWith("lang"))
			{
				num++;
			}
			if (num == 1)
			{
				num2++;
			}
			if (num > 1)
			{
				num2 = num + 1;
			}
			if (num == 2)
			{
				num2 = num - 2;
			}
			if (num != 3 && (num != 2 || num > 3) && num != 1 && !GClass16.smethod_10()[i].StartsWith("lang0"))
			{
				FileStream fileStream = new FileStream(GClass61.smethod_22() + "\\Files\\" + GClass16.smethod_10()[i] + ".dat", FileMode.Open, FileAccess.Read);
				byte[] array = new byte[12];
				while (fileStream.Position < fileStream.Length)
				{
					fileStream.Read(array, 0, array.Length);
					byte[] array2 = array;
					int num3 = 2;
					array2[num3] ^= array[3];
					byte[] array3 = array;
					int num4 = 9;
					array3[num4] ^= array[3];
					byte[] array4 = array;
					int num5 = 7;
					array4[num5] ^= array[2];
					byte[] array5 = array;
					int num6 = 6;
					array5[num6] ^= array[2];
					byte[] array6 = array;
					int num7 = 11;
					array6[num7] ^= array[0];
					byte[] array7 = array;
					int num8 = 4;
					array7[num8] ^= array[1];
					byte[] array8 = array;
					int num9 = 11;
					array8[num9] ^= array[10];
					byte[] array9 = array;
					int num10 = 8;
					array9[num10] ^= array[9];
					byte[] array10 = array;
					int num11 = 5;
					array10[num11] ^= array[8];
					byte[] array11 = array;
					int num12 = 3;
					array11[num12] ^= array[1];
					byte[] array12 = array;
					int num13 = 3;
					array12[num13] ^= array[0];
					int num14 = (int)array[3] + 256 * (int)array[2];
					int num15 = (int)array[6] + 256 * (int)array[10];
					int num16 = (int)array[1] + 256 * (int)array[7];
					int num17 = (int)array[11] + 256 * (int)array[5];
					int num18 = (int)array[9] + 256 * (int)array[4];
					byte[] array13 = new byte[num14];
					byte[] array14 = new byte[num15];
					byte[] array15 = new byte[num16];
					byte[] array16 = new byte[num17];
					byte[] array17 = new byte[num18];
					fileStream.Read(array13, 0, array13.Length);
					array13 = GClass66.smethod_0(array13);
					fileStream.Read(array14, 0, array14.Length);
					fileStream.Read(array15, 0, array15.Length);
					fileStream.Read(array16, 0, array16.Length);
					fileStream.Read(array17, 0, array17.Length);
					bool bool_ = string_0 != Encoding.Unicode.GetString(array13) && Encoding.Unicode.GetString(array13) != "ZZGEN";
					array14 = GClass66.smethod_1(array14, bool_);
					array15 = GClass66.smethod_1(array15, bool_);
					array16 = GClass66.smethod_1(array16, bool_);
					array17 = GClass66.smethod_1(array17, bool_);
					if (array14 != null)
					{
						this.dataTable_0.Rows.Add(new object[]
						{
							Encoding.Unicode.GetString(array13),
							Encoding.Unicode.GetString(array14),
							Encoding.Unicode.GetString(array15),
							Encoding.Unicode.GetString(array16),
							GClass16.smethod_5(Encoding.Unicode.GetString(array17))
						});
					}
				}
				fileStream.Close();
			}
		}
	}

	// Token: 0x06000187 RID: 391 RVA: 0x0003A1E4 File Offset: 0x000383E4
	private void method_2()
	{
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0225",
			"TP Sensor/Switch (11)",
			"Throttle Position sensor/switch C circuit malfunction",
			1609
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0226",
			"TP Sensor/Switch (12)",
			"Throttle Position sensor/switch C circuit: range/performance problem",
			1588
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0227",
			"TP Sensor/Switch (13)",
			"Throttle Position sensor/switch C circuit: low input",
			1214
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0228",
			"TP Sensor/Switch (14)",
			"Throttle Position sensor/switch C circuit: high input",
			1214
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0229",
			"TP Sensor/Switch (15)",
			"Throttle Position sensor/switch C circuit intermittent",
			1214
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0230",
			"Fuel Pump (1)",
			"Fuel Pump Primary Circuit.",
			1282
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0231",
			"Fuel Pump (2)",
			"Fuel Pump Secondary circuit: signal low",
			1681
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0232",
			"Fuel Pump (3)",
			"Fuel Pump Secondary circuit: signal high",
			1681
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0233",
			"Fuel Pump (4)",
			"Fuel Pump Secondary circuit: signal intermittent",
			1681
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0234",
			"Boost",
			"Turbo/Super Charge Overboost Condition",
			1264
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0235",
			"Boost Pressure (1)",
			"Boost Pressure sensor A circuit malfunction",
			1461
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0236",
			"Boost Pressure (2)",
			"Boost Pressure sensor A circuit range/performance",
			1353
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0237",
			"Boost Pressure (3)",
			"Boost Pressure sensor A circuit low",
			1353
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0238",
			"Boost Pressure (4)",
			"Boost Pressure sensor A circuit high",
			1451
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0239",
			"Boost Pressure (5)",
			"Boost Pressure sensor B circuit malfunction",
			1353
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0240",
			"Boost Pressure (6)",
			"Boost Pressure sensor B circuit range/performance",
			1353
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0241",
			"Boost Pressure (7)",
			"Boost Pressure sensor B circuit low",
			1353
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0242",
			"Boost Pressure (8)",
			"Boost Pressure sensor B circuit high",
			1353
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0243",
			"Boost Control \u00a0Solenoid Valve (1)",
			"Turbo/Supercharger Wastegate Solenoid A Malfunction",
			1506
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0244",
			"Boost Control \u00a0Solenoid Valve (2)",
			"Turbo/Supercharger Wastegate Solenoid A Range/Performance",
			1506
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0245",
			"Boost Control \u00a0Solenoid Valve (3)",
			"Turbo/Supercharger Wastegate Solenoid A Low",
			1506
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0246",
			"Boost Control \u00a0Solenoid Valve (4)",
			"Turbo/Supercharger Wastegate Solenoid A High",
			1506
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0247",
			"Boost Control \u00a0Solenoid Valve (5)",
			"Turbo/Supercharger Wastegate Solenoid B Malfunction",
			1506
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0248",
			"Boost Control \u00a0Solenoid Valve (6)",
			"Turbo/Supercharger Wastegate Solenoid B Range/Performance",
			1506
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0249",
			"Boost Control \u00a0Solenoid Valve (7)",
			"Turbo/Supercharger Wastegate Solenoid B Low",
			1506
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0250",
			"Boost Control \u00a0Solenoid Valve (8)",
			"Turbo/Supercharger Wastegate Solenoid B High",
			1506
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0251",
			"Injection Pump Rotor/Cam (1)",
			"Injection Pump A Rotor/Cam Malfunction",
			1600
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0252",
			"Injection Pump Rotor/Cam (2)",
			"Injection Pump A Rotor/Cam Range/Function",
			1600
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0253",
			"Injection Pump Rotor/Cam (3)",
			"Injection Pump A Rotor/Cam Low",
			1498
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0254",
			"Injection Pump Rotor/Cam (4)",
			"Injection Pump A Rotor/Cam High",
			1242
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0255",
			"Injection Pump Rotor/Cam (5)",
			"Injection Pump A Rotor/Cam Intermittent",
			1569
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0256",
			"Injection Pump Rotor/Cam (6)",
			"Injection Pump B Rotor/Cam Malfunction",
			1569
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0257",
			"Injection Pump Rotor/Cam (7)",
			"Injection Pump B Rotor/Cam Range/Function",
			1569
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0258",
			"Injection Pump Rotor/Cam (8)",
			"Injection Pump B Rotor/Cam Low",
			1569
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0259",
			"Injection Pump Rotor/Cam (9)",
			"Injection Pump B Rotor/Cam High",
			1569
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0260",
			"Injection Pump Rotor/Cam (10)",
			"Injection Pump B Rotor/Cam Intermittent",
			1569
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0261",
			"Cylinder 1 Injector (2)",
			"Cylinder 1 Injector Circuit Low",
			1658
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0262",
			"Cylinder 1 Injector (3)",
			"Cylinder 1 Injector Circuit High",
			1658
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0263",
			"Cyl.1 Contribution/Balance",
			"Cylinder 1 Contribution/Balance Fault",
			1496
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0264",
			"Cylinder 2 Injector (2)",
			"Cylinder 2 Injector Circuit Low",
			1205
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0265",
			"Cylinder 2 Injector (3)",
			"Cylinder 2 Injector Circuit High",
			1205
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0266",
			"Cyl.2 Contribution/Balance",
			"Cylinder 2 Contribution/Balance Fault",
			1663
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0267",
			"Cylinder 3 Injector (2)",
			"Cylinder 3 Injector Circuit Low",
			1329
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0268",
			"Cylinder 3 Injector (3)",
			"Cylinder 3 Injector Circuit High",
			1329
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0269",
			"Cyl.3 Contribution/Balance",
			"Cylinder 3 Contribution/Balance Fault",
			1418
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0270",
			"Cylinder 4 Injector (2)",
			"Cylinder 4 Injector Circuit Low",
			1708
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0271",
			"Cylinder 4 Injector (3)",
			"Cylinder 4 Injector Circuit High",
			1708
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0272",
			"Cyl.4 Contribution/Balance",
			"Cylinder 4 Contribution/Balance Fault",
			1459
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0273",
			"Cylinder 5 Injector (2)",
			"Cylinder 5 Injector Circuit Low",
			1253
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0274",
			"Cylinder 5 Injector (3)",
			"Cylinder 5 Injector Circuit High",
			1253
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0275",
			"Cyl.5 Contribution/Balance",
			"Cylinder 5 Contribution/Balance Fault",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0276",
			"Cylinder 6 Injector (2)",
			"Cylinder 6 Injector Circuit Low",
			1511
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0277",
			"Cylinder 6 Injector (3)",
			"Cylinder 6 Injector Circuit High",
			1511
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0278",
			"Cyl.6 Contribution/Balance",
			"Cylinder 6 Contribution/Balance Fault",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0279",
			"Cylinder 7 Injector (2)",
			"Cylinder 7 Injector Circuit Low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0280",
			"Cylinder 7 Injector (3)",
			"Cylinder 7 Injector Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0281",
			"Cyl.7 Contribution/Balance",
			"Cylinder 7 Contribution/Balance Fault",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0282",
			"Cylinder 8 Injector (2)",
			"Cylinder 8 Injector Circuit Low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0283",
			"Cylinder 8 Injector (3)",
			"Cylinder 8 Injector Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0284",
			"Cyl.8 Contribution/Balance",
			"Cylinder 8 Contribution/Balance Fault",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0285",
			"Cylinder 9 Injector (2)",
			"Cylinder 9 Injector Circuit Low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0286",
			"Cylinder 9 Injector (3)",
			"Cylinder 9 Injector Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0287",
			"Cyl.9 Contribution/Balance",
			"Cylinder 9 Contribution/Balance Fault",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0288",
			"Cylinder 10 Injector (2)",
			"Cylinder 10 Injector Circuit Low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0289",
			"Cylinder 10 Injector (3)",
			"Cylinder 10 Injector Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0290",
			"Cyl.10 Contribution/Balance",
			"Cylinder 10 Contribution/Balance Fault",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0291",
			"Cylinder 11 Injector (2)",
			"Cylinder 11 Injector Circuit Low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0292",
			"Cylinder 11 Injector (3)",
			"Cylinder 11 Injector Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0293",
			"Cyl.11 Contribution/Balance",
			"Cylinder 11 Contribution/Balance Fault",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0294",
			"Cylinder 12 Injector (2)",
			"Cylinder 12 Injector Circuit Low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0295",
			"Cylinder 12 Injector (3)",
			"Cylinder 12 Injector Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0296",
			"Cyl.12 Contribution/Balance",
			"Cylinder 12 Contribution/Balance Fault",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0297",
			"Excessive vehicle speed",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0298",
			"Engine Oil Temp. (6)",
			"Engine Oil over Temperature",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0299",
			"Boost Pressure too low",
			"No help available at present",
			1353
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0300",
			"Misfires detected (1)",
			"Random/Multiple Cylinder Misfire Detected",
			1555
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0301",
			"Cylinder 1 Misfire",
			"Cylinder 1 Misfire Detected",
			1190
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0302",
			"Cylinder 2 Misfire",
			"Cylinder 2 Misfire Detected",
			1372
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0303",
			"Cylinder 3 Misfire",
			"Cylinder 3 Misfire Detected",
			1682
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0304",
			"Cylinder 4 Misfire",
			"Cylinder 4 Misfire Detected",
			1302
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0305",
			"Cylinder 5 Misfire",
			"Cylinder 5 Misfire Detected",
			1625
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0306",
			"Cylinder 6 Misfire",
			"Cylinder 6 Misfire Detected",
			1314
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0307",
			"Cylinder 7 Misfire",
			"Cylinder 7 Misfire Detected",
			1175
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0308",
			"Cylinder 8 Misfire",
			"Cylinder 8 Misfire Detected",
			1175
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0309",
			"Cylinder 9 Misfire",
			"Cylinder 9 Misfire Detected",
			1175
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0310",
			"Cylinder 10 Misfire",
			"Cylinder 10 Misfire Detected",
			1175
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0311",
			"Cylinder 11 Misfire",
			"Cylinder 11 Misfire Detected",
			1175
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0312",
			"Cylinder 12 Misfire",
			"Cylinder 12 Misfire Detected",
			1175
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0313",
			"Misfire detected (2)",
			"Misfire Detected with Low Fuel",
			1175
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0314",
			"Misfire detected (3)",
			"Single Cylinder Misfire (Cylinder not Specified)",
			1175
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0315",
			"Crank Pos. Syst. Variation Not Learned",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0316",
			"Start Misfire Detected (1st 1000 Rev.s)",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0317",
			"Rough Road Hardware Not Present",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0318",
			"Rough Road Sensor A Signal Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0319",
			"Rough Road Sensor B",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0320",
			"Engine speed (1)",
			"Ignition/Distributor Engine Speed Input Circuit Malfunction",
			1433
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0321",
			"Engine speed (2)",
			"Ignition/Distributor Engine Speed Input Circuit Range/",
			1433
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0322",
			"Engine speed (3)",
			"Ignition/Distributor Engine Speed Input Circuit No Signal",
			1395
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0323",
			"Engine speed (4)",
			"Ignition/Distributor Engine Speed Input Circuit Interm",
			1433
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0324",
			"Knock Control",
			"Knock Control System Circuit",
			1181
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0325",
			"Knock Sensor (1)",
			"Knock Sensor 1 Circuit Malfunction (Bank 1/Single Sensor)",
			1272
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0326",
			"Knock Sensor (2)",
			"Knock Sensor 1 Circuit Range/Performance (Bank 1/Single Sensor)",
			1272
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0327",
			"Knock Sensor (3)",
			"Knock Sensor 1 Circuit Low Input (Bank 1/Single Sensor)",
			1272
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0328",
			"Knock Sensor (4)",
			"Knock Sensor 1 Circuit High Input (Bank 1/Single Sensor)",
			1272
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0329",
			"Knock Sensor (5)",
			"Knock Sensor 1 Circuit Input Intermittent (Bank 1/Single Sensor)",
			1272
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0330",
			"Knock Sensor (6)",
			"Knock Sensor 2 Circuit Malfunction (Bank 2)",
			1604
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0331",
			"Knock Sensor (7)",
			"Knock Sensor 2 Circuit Range/Performance (Bank 2)",
			1604
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0332",
			"Knock Sensor (8)",
			"Knock Sensor 2 Circuit Low Input (Bank 2)",
			1604
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0333",
			"Knock Sensor (9)",
			"Knock Sensor 2 Circuit High Input (Bank 2)",
			1604
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0334",
			"Knock Sensor (10)",
			"Knock Sensor 2 Circuit Input Intermittent (Bank 2)",
			1604
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0335",
			"Crankshaft Position (1)",
			"Crankshaft Position Sensor A circuit malfunction",
			1395
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0336",
			"Crankshaft Position (2)",
			"Crankshaft Position Sensor A circuit range/performance",
			1395
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0337",
			"Crankshaft Position (3)",
			"Crankshaft Position Sensor A circuit low input",
			1395
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0338",
			"Crankshaft Position (4)",
			"Crankshaft Position Sensor A circuit high input",
			1395
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0339",
			"Crankshaft Position (5)",
			"Crankshaft Position Sensor A circuit intermittent",
			1395
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0340",
			"Camshaft Position (1)",
			"Camshaft Position Sensor A circuit malfunction (Bank 1 or Single Sensor)",
			1247
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0341",
			"Camshaft Position (2)",
			"Camshaft Position Sensor A circuit range/performance (Bank 1 or Single Sensor)",
			1247
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0342",
			"Camshaft Position (3)",
			"Camshaft Position Sensor A circuit low input (Bank 1 or Single Sensor)",
			1516
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0343",
			"Camshaft Position (4)",
			"Camshaft Position Sensor A circuit high input (Bank 1 or Single Sensor)",
			1516
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0344",
			"Camshaft Position (5)",
			"Camshaft Position Sensor A circuit intermittent (Bank 1 or Single Sensor)",
			1400
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0345",
			"Camshaft Position (6)",
			"Camshaft Position Sensor A circuit (Bank 2)",
			1404
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0346",
			"Camshaft Position (7)",
			"Camshaft Position Sensor A Circuit range/performance (Bank 2)",
			1247
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0347",
			"Camshaft Position (8)",
			"Camshaft Position Sensor A circuit low input (Bank 2)",
			1247
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0348",
			"Camshaft Position (9)",
			"Camshaft Position Sensor A circuit high input (Bank 2)",
			1247
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0349",
			"Camshaft Position (10)",
			"Camshaft Position Sensor A circuit intermittent (Bank 2)",
			1247
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0350",
			"Ignition Coil (1)",
			"Ignition Coil Primary/Secondary Circuit Malfunction",
			1426
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0351",
			"Ignition Coil (2)",
			"Ignition Coil A / 1 Primary/Secondary Circuit malfunction",
			1584
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0352",
			"Ignition Coil (3)",
			"Ignition Coil B / 2 Primary/Secondary Circuit malfunction",
			1615
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0353",
			"Ignition Coil (4)",
			"Ignition Coil C / 3 Primary/Secondary Circuit malfunction",
			1379
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0354",
			"Ignition Coil (5)",
			"Ignition Coil D / 4 Primary/Secondary Circuit malfunction",
			1561
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0355",
			"Ignition Coil (6)",
			"Ignition Coil E / 5 Primary/Secondary Circuit malfunction",
			1309
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0356",
			"Ignition Coil (7)",
			"Ignition Coil F / 6 Primary/Secondary Circuit malfunction",
			1479
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0357",
			"Ignition Coil (8)",
			"Ignition Coil G / 7 Primary/Secondary Circuit malfunction",
			1426
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0358",
			"Ignition Coil (9)",
			"Ignition Coil H / 8 Primary/Secondary Circuit malfunction",
			1426
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0359",
			"Ignition Coil (10)",
			"Ignition Coil I / 9 Primary/Secondary Circuit malfunction",
			1426
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0360",
			"Ignition Coil (11)",
			"Ignition Coil J / 10 Primary/Secondary Circuit malfunction",
			1426
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0361",
			"Ignition Coil (12)",
			"Ignition Coil K / 11 Primary/Secondary Circuit malfunction",
			1426
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0362",
			"Ignition Coil (13)",
			"Ignition Coil L / 12 Primary/Secondary Circuit malfunction",
			1426
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0363",
			"Misfire Detected-Fuel Disabled",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0364",
			"ISO/SAE reserved",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0365",
			"Camshaft Position (11)",
			"Camshaft Position Sensor B Circuit (Bank 1)",
			1462
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0366",
			"Camshaft Position (12)",
			"Camshaft Position Sensor B Circuit Range Performance (Bank 1)",
			1462
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0367",
			"Camshaft Position (13)",
			"Camshaft Position Sensor B Circuit Low Input (Bank 1)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0368",
			"Camshaft Position (14)",
			"Camshaft Position Sensor B Circuit High Input (Bank 1)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0369",
			"Camshaft Position (15)",
			"Camshaft Position Sensor B Circuit Intermittent (Bank 1)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0370",
			"Timing Reference (1)",
			"Timing Ref High Resolution Signal A Malfunction",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0371",
			"Timing Reference (2)",
			"Timing Ref High Resolution Signal A Too Many Pulse",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0372",
			"Timing Reference (3)",
			"Timing Ref High Resolution Signal A Too Few Pulses",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0373",
			"Timing Reference (4)",
			"Timing Ref High Resolution Signal A Intermittent/Erratic Pulses",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0374",
			"Timing Reference (5)",
			"Timing Ref High Resolution Signal A No Pulses",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0375",
			"Timing Reference (6)",
			"Timing Ref High Resolution Signal B Malfunction",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0376",
			"Timing Reference (7)",
			"Timing Ref High Resolution Signal B Too Many Pulse",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0377",
			"Timing Reference (8)",
			"Timing Ref High Resolution Signal B Too Few Pulses",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0378",
			"Timing Reference (9)",
			"Timing Ref High Resolution Signal B Intermittent/Erratic Pulses",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0379",
			"Timing Reference (10)",
			"Timing Ref High Resolution Signal B No Pulses",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0380",
			"Glow Plug/Heater Circuit (1)",
			"Glow Plug/Heater Circuit Malfunction",
			1318
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0381",
			"Glow Plug/Heater Circuit (2)",
			"Glow Plug/Heater Indicator Circuit Malfunction",
			1283
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0382",
			"Glow Plug/Heater Circuit (3)",
			"Glow Plug/Heater Circuit B",
			1375
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0383",
			"Glow plug control module: low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0384",
			"Glow plug control module: high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0385",
			"Crankshaft Position (6)",
			"Crankshaft Position Sensor B circuit malfunction",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0386",
			"Crankshaft Position (7)",
			"Crankshaft Position Sensor B circuit range/performance",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0387",
			"Crankshaft Position (8)",
			"Crankshaft Position Sensor B circuit low input",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0388",
			"Crankshaft Position (9)",
			"Crankshaft Position Sensor B circuit high input",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0389",
			"Crankshaft Position (10)",
			"Crankshaft Position Sensor B circuit intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0390",
			"Camshaft Position (16)",
			"Camshaft Position Sensor B circuit (Bank 2)",
			1515
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0391",
			"Camshaft Position (17)",
			"Camshaft Position Sensor B circuit range/performance (Bank 2)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0392",
			"Camshaft Position (18)",
			"Camshaft Position Sensor B circuit low input (Bank 2)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0393",
			"Camshaft Position (19)",
			"Camshaft Position Sensor B circuit high input (Bank 2)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0394",
			"Camshaft Position (20)",
			"Camshaft Position Sensor B circuit intermittent (Bank 2)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0400",
			"E.G.R. device (1)",
			"EGR: Flow Malfunction",
			1507
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0401",
			"E.G.R. device (2)",
			"Exhaust Gas Recirculation Flow Insufficient Detected",
			1507
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0402",
			"E.G.R. device (3)",
			"Exhaust Gas Recirculation Flow Excessive Detected",
			1507
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0403",
			"E.G.R. device (4)",
			"Exhaust Gas Recirculation Circuit Malfunction",
			1471
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0404",
			"E.G.R. device (5)",
			"Exhaust Gas Recirculation Circuit Range/Performance",
			1471
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0405",
			"E.G.R. device (6)",
			"Exhaust Gas Recirculation Sensor A circuit low",
			1308
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0406",
			"E.G.R. device (7)",
			"Exhaust Gas Recirculation Sensor A circuit high",
			1308
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0407",
			"E.G.R. device (8)",
			"Exhaust Gas Recirculation Sensor B circuit low",
			1308
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0408",
			"E.G.R. device (9)",
			"Exhaust Gas Recirculation Sensor B circuit high",
			1308
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0409",
			"E.G.R. device (10)",
			"Exhaust Gas Recirculation Sensor A circuit",
			1308
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0410",
			"Sec Air Injection Sys (1)",
			"Sec Air Injection Sys Malfunction",
			1331
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0411",
			"Sec Air Injection Sys (2)",
			"Sec Air Injection Sys Incorrect Flow Detected",
			1331
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0412",
			"Sec Air injection Sys (3)",
			"Sec. Air Injection System Switching Valve A circuit malfunction",
			1510
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0413",
			"Sec Air injection Sys (4)",
			"Sec. Air Injection System Switching Valve A circuit open",
			1510
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0414",
			"Sec Air injection Sys (5)",
			"Sec. Air Injection System Switching Valve A circuit shorted",
			1510
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0415",
			"Sec Air injection Sys (6)",
			"Sec. Air Injection System Switching Valve B circuit malfunction",
			1510
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0416",
			"Sec Air injection Sys (7)",
			"Sec. Air Injection System Switching Valve B circuit open",
			1510
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0417",
			"Sec Air injection Sys (8)",
			"Sec. Air Injection System Switching Valve B circuit shorted",
			1510
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0418",
			"Sec Air Injection Sys (9)",
			"Secondary Air Injection System relay A circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0419",
			"Sec Air Injection Sys (10)",
			"Secondary Air Injection System relay B circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0420",
			"Catalytic converter (1)",
			"Catalyst System Effeciency Below Threshold (Bank 1)",
			1383
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0421",
			"Catalytic converter (2)",
			"Warm Up Catalyst Effeciency Below Threshold (Bank 1)",
			1383
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0422",
			"Catalytic converter (3)",
			"Main Catalyst Effeciency Below Threshold (Bank 1)",
			1383
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0423",
			"Catalytic converter (4)",
			"Heated Catalyst Effeciency Below Threshold (Bank 1)",
			1383
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0424",
			"Catalytic converter (5)",
			"Heated Catalyst Temperature Below Threshold (Bank 1)",
			1383
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0425",
			"Catalytic converter (6)",
			"Catalyst Temperature Sensor (Bank 1)",
			1383
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0426",
			"Catalytic converter (7)",
			"Catalyst Temperature Sensor Range/Performance (Bank 1)",
			1383
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0427",
			"Catalytic converter (8)",
			"Catalyst Temperature Sensor Low Input (Bank1)",
			1383
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0428",
			"Catalytic converter (9)",
			"Catalyst Temperature Sensor High Input (Bank1)",
			1383
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0429",
			"Catalytic converter (10)",
			"Catalyst Heater Control Circuit (Bank 1)",
			1383
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0430",
			"Catalytic converter (11)",
			"Catalyst System Effeciency Below Threshold (Bank 2)",
			1405
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0431",
			"Catalytic converter (12)",
			"Warm Up Catalyst Effeciency Below Threshold (Bank 2)",
			1405
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0432",
			"Catalytic converter (13)",
			"Main Catalyst Effeciency Below Threshold (Bank 2)",
			1405
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0433",
			"Catalytic converter (14)",
			"Heated Catalyst Effeciency Below Threshold (Bank 2)",
			1405
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0434",
			"Catalytic converter (15)",
			"Heated Catalyst Temperature Below Threshold (Bank 2)",
			1405
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0435",
			"Catalytic converter (16)",
			"Catalyst Temperature Sensor (Bank 2)",
			1405
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0436",
			"Catalytic converter (17)",
			"Catalyst Temperature Sensor Range/Performance (Bank 2)",
			1405
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0437",
			"Catalytic converter (18)",
			"Catalyst Temperature Sensor Low Input (Bank 2)",
			1405
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0438",
			"Catalytic converter (19)",
			"Catalyst Temperature Sensor High Input (Bank 2)",
			1405
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0439",
			"Catalytic converter (20)",
			"Catalyst Heater Control Circuit (Bank 2)",
			1405
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0440",
			"EVAP circuit (1)",
			"EVAP Control System Malfunction",
			1719
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0441",
			"EVAP circuit (2)",
			"EVAP Control System Insufficient Purge Flow",
			1719
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0442",
			"EVAP circuit (3)",
			"EVAP Control System Leak Detected (small leak)",
			1719
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0443",
			"EVAP circuit (4)",
			"EVAP Control System Purge Control Valve Circuit Malfunction",
			1719
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0444",
			"EVAP circuit (5)",
			"EVAP Control System Purge Control Valve Circuit Open",
			1719
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0445",
			"EVAP circuit (6)",
			"EVAP Control System Purge Control Valve Circuit Shorted",
			1719
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0446",
			"EVAP circuit (7)",
			"EVAP Control System Vent Control Circuit",
			1719
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0447",
			"EVAP circuit (8)",
			"EVAP Control System Vent Control Circuit Open",
			1719
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0448",
			"EVAP circuit (9)",
			"EVAP Control System Vent Control Circuit Shorted",
			1719
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0449",
			"EVAP circuit (10)",
			"EVAP Control System Vent Valve/Solenoid Circuit",
			1719
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0450",
			"EVAP circuit (11)",
			"EVAP Control System Pressure Sensor Malfunction",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0451",
			"EVAP circuit (12)",
			"EVAP Control System Pressure Sensor Range/Performance",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0452",
			"EVAP circuit (13)",
			"EVAP Control System Pressure Sensor Low Input",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0453",
			"EVAP circuit (14)",
			"EVAP Control System Pressure Sensor High Input",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0454",
			"EVAP circuit (15)",
			"EVAP Control system Pressure Sensor Intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0455",
			"EVAP circuit (16)",
			"EVAP Control System Leak Detected (gross leak)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0456",
			"EVAP circuit (17)",
			"EVAP Control System Leak Detected (very small leak)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0457",
			"EVAP circuit (18)",
			"EVAP Control System Leak Detected (fuel cap loose/off)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0458",
			"Evap. Purge Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0459",
			"Evap. Purge Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0460",
			"Fuel Level Sensor (1)",
			"Fuel Level Sensor Circuit Malfunction",
			1720
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0461",
			"Fuel Level Sensor (2)",
			"Fuel Level Sensor Circuit Range/Performance",
			1720
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0462",
			"Fuel Level Sensor (3)",
			"Fuel Level Sensor Circuit Low Input",
			1720
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0463",
			"Fuel Level Sensor (4)",
			"Fuel Level Sensor Circuit High Input",
			1720
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0464",
			"Fuel Level Sensor (5)",
			"Fuel Level Sensor Circuit Intermittent",
			1720
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0465",
			"EVAP Control Sys (19)",
			"Purge Flow Sensor Circuit Malfunction",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0466",
			"EVAP Control Sys (20)",
			"Purge Flow Sensor Circuit Range/Performance",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0467",
			"EVAP Control Sys (21)",
			"Purge Flow Sensor Circuit Low Input",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0468",
			"EVAP Control Sys (22)",
			"Purge Flow Sensor Circuit High Input",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0469",
			"EVAP Control Sys (23)",
			"Purge Flow Sensor Circuit Intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0470",
			"Exhaust Pressure (1)",
			"Exhaust Pressure Sensor Circuit Malfunction",
			1456
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0471",
			"Exhaust Pressure (2)",
			"Exhaust Pressure Sensor Circuit Range/Performance",
			1456
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0472",
			"Exhaust Pressure (3)",
			"Exhaust Pressure Sensor Circuit Low Input",
			1456
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0473",
			"Exhaust Pressure (4)",
			"Exhaust Pressure Sensor Circuit High Input",
			1456
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0474",
			"Exhaust Pressure (5)",
			"Exhaust Pressure Sensor Circuit Intermittent",
			1456
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0475",
			"Exhaust Pressure (6)",
			"Exhaust Pressure Control Valve Malfunction",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0476",
			"Exhaust Pressure (7)",
			"Exhaust Pressure Control Valve Range/Performance",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0477",
			"Exhaust Pressure (8)",
			"Exhaust Pressure Control Valve Low Input",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0478",
			"Exhaust Pressure (9)",
			"Exhaust Pressure Control Valve High Input",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0479",
			"Exhaust Pressure (10)",
			"Exhaust Pressure Control Valve Intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0480",
			"Cooling Fan (1)",
			"Cooling Fan 1 Control Circuit",
			1358
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0481",
			"Cooling Fan (2)",
			"Cooling Fan 2 Control Circuit",
			1541
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0482",
			"Cooling Fan (3)",
			"Cooling Fan 3 Control Circuit",
			1490
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0483",
			"Cooling Fan (4)",
			"Cooling Fan Rationality Check",
			1215
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0484",
			"Cooling Fan (5)",
			"Cooling Fan Circuit Over Current",
			1215
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0485",
			"Cooling Fan (6)",
			"Cooling Fan Power/Ground Circuit",
			1591
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0486",
			"E.G.R. device (11)",
			"Exhaust Gas Recirculation Sensor B Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0487",
			"E.G.R. device (12)",
			"Exhaust Gas Recirculation Throttle Position Control Cct",
			1507
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0488",
			"E.G.R. device (13)",
			"Exhaust Gas Recirculation Throttle Position Control Range/Performance",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0489",
			"EGR Control Circuit Low",
			"EGR Control Circuit low",
			1471
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0490",
			"EGR Control Circuit High",
			"EGR Control Circuit high",
			1471
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0491",
			"Sec Air Injection Sys (11)",
			"Secondary Air Injection System (Bank 1)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0492",
			"Sec Air Injection Sys (12)",
			"Secondary Air Injection System (Bank 2)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0493",
			"Fan Overspeed",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0494",
			"Fan Speed Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0495",
			"Fan Speed High",
			"Fan Speed High",
			1410
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0496",
			"Evap. Purge Flow High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0497",
			"Evap. Purge Flow Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0498",
			"Evap. Vent Valve Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0499",
			"Evap. Vent Valve Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0500",
			"Vehicle Speed Sensor (1)",
			"Vehicle Speed Sensor Malfunction",
			1514
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0501",
			"Vehicle Speed Sensor (2)",
			"Vehicle Speed Sensor Range/Peroformance",
			1299
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0502",
			"Vehicle Speed Sensor (3)",
			"Vehicle Speed Sensor Low Input",
			1299
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0503",
			"Vehicle Speed Sensor (4)",
			"Vehicle Speed Sensor Intermittent/Erractic/High",
			1299
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0504",
			"Brake switch A/B match",
			"Brake switch A/B match",
			1196
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0505",
			"Idle Control sys (1)",
			"Idle Control system Malfunction",
			1545
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0506",
			"Idle Control sys (2)",
			"Idle Control system: value below desired",
			1354
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0507",
			"Idle Control sys (3)",
			"Idle Control system: value above desired",
			1545
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0508",
			"Idle Control Sys (4)",
			"Idle Control System Circuit Low",
			1545
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0509",
			"Idle Control Sys (5)",
			"Idle Control System Circuit High",
			1545
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0510",
			"Idle Control Sys (6)",
			"Closed Throttle Position Switch Malfunction",
			1545
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0511",
			"Idle Air Control Circuit",
			"Idle Air Control Circuit",
			1545
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0512",
			"Starter Circuit (1)",
			"Starter Request Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0513",
			"Immobilizer device (1)",
			"Incorrect Immobilizer Key",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0514",
			"Battery temp. sensor range/funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0515",
			"Battery Temperature (1)",
			"Battery Temperature Sensor Circuit\r\nNOTE for Ford Diesel models:\r\nThis fault may be confused with Intake Air Temp. Sensor/Circuit defect.",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0516",
			"Battery Temperature (2)",
			"Battery Temperature Sensor Circuit Low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0517",
			"Battery Temperature (3)",
			"Battery Temperature Sensor Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0518",
			"Idle Air Control Circuit Intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0519",
			"Idle Air Control System Function",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0520",
			"Engine Oil Pressure (1)",
			"Engine Oil Pressure Sensor/Switch Circuit",
			1207
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0521",
			"Engine Oil Pressure (2)",
			"Engine Oil Pressure Sensor/Switch Range/Performance",
			1706
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0522",
			"Engine Oil Pressure (3)",
			"Engine Oil Pressure Sensor/Switch Low Voltage",
			1706
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0523",
			"Engine Oil Pressure (4)",
			"Engine Oil Pressure Sensor/Switch High Voltage",
			1706
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0524",
			"Engine Oil Pressure (5)",
			"Engine Oil Pressure Too Low",
			1706
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0525",
			"Cruise Control Servo Circuit Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0526",
			"Fan RPM Sensor Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0527",
			"Fan RPM Sensor Circuit Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0528",
			"Fan RPM Sensor: No Signal",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0529",
			"Fan RPM Sensor Circuit Intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0530",
			"A/C pressure sensor",
			"The AC system pressure signal is missing or out of range. This may be caused by a circuit problem between the sensor and the ECU, defective sensor, or wrong pressure. Check the connectors and wiring, and the sensor itself.\r\nREMARK: Insufficient refrigerant quantity may result in too low pressure, while system contamination may cause excessive pressure. Ensure correct amount of clean refrigerant, and that none of the system components (filter/dryer, evaporator, condenser) is blocked.\r\nCAUTION: the system is under high pressure. Observe safety and environmental instructions",
			1652
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0531",
			"A/C Refrigerant Pressure (2)",
			"The AC system pressure signal is missing or out of range. This may be caused by a circuit problem between the sensor and the ECU, defective sensor, or wrong pressure. Check the connectors and wiring, and the sensor itself.\r\nREMARK: Insufficient refrigerant quantity may result in too low pressure, while system contamination may cause excessive pressure. Ensure correct amount of clean refrigerant, and that none of the system components (filter/dryer, evaporator, condenser) is blocked.\r\nCAUTION: the system is under high pressure. Observe safety and environmental instructions",
			1178
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0532",
			"A/C Refrigerant Pressure (3)",
			"The AC system pressure signal is TOO LOW. This may be caused by a circuit problem between the sensor and the ECU, defective sensor, or wrong pressure. Check the connectors and wiring, and the sensor itself.\r\nREMARK: Insufficient refrigerant quantity may result in too low pressure, while system contamination may cause excessive pressure. Ensure correct amount of clean refrigerant, and that none of the system components (filter/dryer, evaporator, condenser) is blocked.\r\nCAUTION: the system is under high pressure. Observe safety and environmental instructions",
			1178
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0533",
			"A/C Refrigerant Pressure (4)",
			"The AC system pressure signal is TOO HIGH. This may be caused by a circuit problem between the sensor and the ECU, defective sensor, or wrong pressure. Check the connectors and wiring, and the sensor itself.\r\nREMARK: Insufficient refrigerant quantity may result in too low pressure, while system contamination may cause excessive pressure. Ensure correct amount of clean refrigerant, and that none of the system components (filter/dryer, evaporator, condenser) is blocked.\r\nCAUTION: the system is under high pressure. Observe safety and environmental instructions",
			1178
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0534",
			"A/C Refrigerant Pressure (5)",
			"Air Conditioner Refrigerant Charge Loss",
			1178
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0535",
			"A/C Evap. Temp. Sensor Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0536",
			"A/C Evap. T. Sensor Circuit Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0537",
			"A/C Evap. Temp. Sensor Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0538",
			"A/C Evap. Temp. Sensor Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0539",
			"A/C Evap. T. Sensor Circuit Intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0540",
			"Intake air heater (1)",
			"Intake Air Heater Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0541",
			"Intake air heater (2)",
			"Intake Air Heater Circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0542",
			"Intake air heater (3)",
			"Intake Air Heater Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0543",
			"Intake Air Heater A Circuit Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0544",
			"Exhaust Gas Temp. (1)",
			"Exhaust Gas Temperature Sensor Circuit (Bank 1)",
			1324
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0545",
			"Exhaust Gas Temp. (2)",
			"Exhaust Gas Temperature Sensor Circuit Low (Bank 1)",
			1324
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0546",
			"Exhaust Gas Temp. (3)",
			"Exhaust Gas Temperature Sensor Circuit High (Bank 1)",
			1324
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0547",
			"Exhaust Gas Temp. (4)",
			"Exhaust Gas Temperature Sensor Circuit (Bank 2)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0548",
			"Exhaust Gas Temp. (5)",
			"Exhaust Gas Temperature Sensor Circuit Low (Bank 2)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0549",
			"Exhaust Gas Temp. (6)",
			"Exhaust Gas Temperature Sensor Circuit High (Bank 2)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0550",
			"Power Steering Press. (1)",
			"Power Steering Pressure Sensor Malfunction",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0551",
			"Power Steering Press. (2)",
			"Power Steering Pressure Sensor Range/Performance",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0552",
			"Power Steering Press. (3)",
			"Power Steering Pressure Sensor Low Input",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0553",
			"Power Steering Press. (4)",
			"Power Steering Pressure Sensor High Input",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0554",
			"Power Steering Press. (5)",
			"Power Steering Pressure Sensor Circuit intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0555",
			"Brake Boost Press. Sensor Circuit",
			"Brake Boost Press. Sensor Circuit",
			1231
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0556",
			"Brake Boost Sensor Circuit Range/Funct.",
			"Brake Boost Sensor Circuit Range/Funct.",
			1420
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0557",
			"Brake Boost Sensor Signal/Circuit Low",
			"Brake Boost Sensor Signal/Circuit Low",
			1231
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0558",
			"Brake Boost Sensor Signal/Circuit High",
			"Brake Boost Sensor Signal/Circuit High",
			1231
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0559",
			"Brake Boost Sensor Circuit Intermitent",
			"Brake Boost Sensor Circuit Intermitent",
			1231
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0560",
			"System Voltage (1)",
			"The ECU supply voltage is below or above the specifications.\r\nCheck the voltage between all the ECU harness positive and negative terminals key on, engine off, during cranking, and when the engine runs. Further, measure the voltages with and without the electric loads turned on, and verify that there are no ground differences when under load. Check the charging system voltage and the battery and cable condition.\r\nPlease Note: Disconnected battery or cranking the engine with weak battery may also set the code.",
			1557
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0561",
			"System Voltage (2)",
			"System Voltage Unstable",
			1165
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0562",
			"System Voltage (3)",
			"System Voltage Low",
			1165
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0563",
			"System Voltage (4)",
			"System Voltage High",
			1165
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0564",
			"Cruise Control (1)",
			"Cruise Cpntrol Multi-Function Input Signal",
			1347
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0565",
			"Cruise Control (2)",
			"Cruise Control On Signal Malfunction",
			1220
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0566",
			"Cruise Control (3)",
			"Cruise Control Off Signal Malfunction",
			1220
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0567",
			"Cruise Control (4)",
			"Cruise Control Resume Signal Malfunction",
			1220
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0568",
			"Cruise Control (5)",
			"Cruise Control Set Signal Malfunction",
			1220
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0569",
			"Cruise Control (6)",
			"Cruise Control Coast Signal Malfunction",
			1220
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0570",
			"Cruise Control (7)",
			"Cruise Control Accel Signal Malfunction",
			1220
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0571",
			"Cruise Control (8)",
			"Cruise Control/Brake Switch A Circuit Malfunction",
			1220
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0572",
			"Cruise Control (9)",
			"Cruise Control/Brake Switch A Circuit Low",
			1220
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0573",
			"Cruise Control (10)",
			"Cruise Control/Brake Switch A Circuit High",
			1220
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0574",
			"Cruise Control (11)",
			"Cruise Control System - Vehicle Speed Too High",
			1220
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0575",
			"Cruise Control (12)",
			"Cruise Control Input Circuit",
			1419
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0576",
			"Cruise Control (13)",
			"Cruise Control Input Circuit Low",
			1697
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0577",
			"Cruise Control (14)",
			"Cruise Control Input Circuit High",
			1220
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0578",
			"Res. for Cruise Control codes",
			"Cruise Control Multi-Function Input A Circuit Stuck",
			1220
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0579",
			"Res. for Cruise Control codes",
			"Cruise Control Multi-Function Input A Circuit Range/Performance",
			1220
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0580",
			"Res. for Cruise Control codes",
			"Cruise Control Multi-Function Input 'A' Circuit Low",
			1307
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0581",
			"Cruise Control Switch A / Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0582",
			"Cruise Control Vacuum Control Circuit Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0583",
			"Cruise Control Vacuum Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0584",
			"Cruise Control Vacuum Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0585",
			"Cruise Control Sw. A/B Circuit Mismatch",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0586",
			"Cruise Control Vent Circuit/Open",
			"Cruise Control Vent Control Circuit open",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0587",
			"Cruise Control Vent Circuit Low",
			"Cruise Control Vent Control circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0588",
			"Cruise Control Vent Circuit High",
			"Cruise Control Vent Control Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0589",
			"Cruise Control Multi-Funct. Input B Circuit",
			"Cruise Control Multi-Function Input 'B' Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0590",
			"Cruise Control Switch B / Circuit Stuck",
			"Cruise Control Multi-Function Input 'B' Circuit stuck",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0591",
			"Cruise Control Sw. Circuit B Range/Funct.",
			"Cruise Control Multi-Function Input 'B' Circuit Range/Function",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0592",
			"Cruise Control Switch B / Circuit Low",
			"Cruise Control Multi-Function Input 'B' Circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0593",
			"Cruise Control Switch B / Circuit High",
			"Cruise Control Multi-Function Input 'B' Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0594",
			"Cruise Control Servo Control Circuit/Open",
			"Cruise Control Servo Control Circuit open",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0595",
			"Cruise Control Servo Control Circuit Low",
			"Cruise Control Servo Control Circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0596",
			"Cruise Control Servo Control Circuit High",
			"Cruise Control Servo Control Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0597",
			"Thermostat Heater Control Circuit/Open",
			"Heater Control Thermostat Circuit open",
			1209
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0598",
			"Thermostat Heater Control Circuit Low",
			"Heater Control Thermostat Circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0599",
			"Thermostat Heater Control Circuit High",
			"Heater Control Thermostat Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0600",
			"Serial Communication Link",
			"Serial Communication Link Malfunction",
			1315
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0601",
			"ECU faulty (1)",
			"ECU Memory Checksum Error",
			1578
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0602",
			"ECU faulty (2)",
			"ECU: internal defect or programming error",
			1259
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0603",
			"ECU faulty (3)",
			"ECU Keep Alive Memory (KAM) internal error",
			1554
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0604",
			"ECU faulty (4)",
			"ECU random access memory (RAM) error",
			1618
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0605",
			"ECU faulty (5)",
			"ECU Read Only Memory (ROM) error",
			1366
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0606",
			"ECU faulty (6)",
			"PCM/ECM Processor Fault",
			1294
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0607",
			"ECU Performance",
			"ECU function",
			1275
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0608",
			"Control Module VSS (1)",
			"Control Module VSS Output A",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0609",
			"Control Module VSS (2)",
			"Control Module VSS Output B",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0610",
			"Vehicle Options",
			"Control Module Vehicle Options Error",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0611",
			"Fuel Injector Control Module Function",
			"Fuel Injector ECU function",
			1540
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0612",
			"Fuel Inj. Driver Module Relay Control",
			"Fuel Injector ECU control relay",
			1540
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0613",
			"TCM Processor",
			"TCM (Traction) ECU processor",
			1294
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0614",
			"ECM/TCM Incompatible",
			"Engine ECU/TCM ECU Incompatible",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0615",
			"Starter Circuit (2)",
			"Starter Relay Circuit",
			1388
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0616",
			"Starter Circuit (3)",
			"Starter Relay Circuit Low",
			1724
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0617",
			"Starter Circuit (4)",
			"Starter Relay Circuit High",
			1724
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0618",
			"Alternative Fuel (1)",
			"Alternative Fuel Control Module KAM Error",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0619",
			"Alternative Fuel (2)",
			"Alternative Fuel Control Module RAM/ROM Error",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0620",
			"Generator Control Circuit (1)",
			"Generator Control Circuit",
			1316
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0621",
			"Generator Control Circuit (2)",
			"Generator Lamp 'L' Terminal Control Circuit",
			1316
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0622",
			"Generator Control Circuit (3)",
			"Generator Field 'F' Terminal Control Circuit",
			1316
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0623",
			"Generator Control Circuit (4)",
			"Generator Lamp Control Circuit",
			1316
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0624",
			"Fuel Cap Lamp Control Cct",
			"Fuel Cap Lamp Control Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0625",
			"Generator Field/F Terminal Circuit Low",
			"Generator Field/F Terminal Circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0626",
			"Generator Field/F Terminal Circuit High",
			"Generator Field/F Terminal Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0627",
			"Fuel Pump A Control Circuit /Open",
			"Fuel Pump 'A' Control Circuit open",
			1282
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0628",
			"Fuel Pump A Control Circuit Low",
			"Fuel Pump 'A' Control Circuit low",
			1282
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0629",
			"Fuel Pump A Control Circuit High",
			"Fuel Pump 'A' Control Circuit high",
			1282
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0630",
			"VIN (1)",
			"VIN Not Programmed or Mismatch - ECM/PCM",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0631",
			"VIN (2)",
			"VIN Not Programmed or Mismatch - TCM",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0632",
			"Odometer Not Programmed - ECM/PCM",
			"Odometer Not Programmed - ECM/PCM",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0633",
			"Immob. Key Not Programmed - ECM/PCM",
			"Immobilizer Key Not Programmed - ECM/PCM",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0634",
			"PCM/ECM/TCM Temp. Too High",
			"PCM/ECM/TCM Internal Temperature too high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0635",
			"Power Steering (1)",
			"Power Steering Control Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0636",
			"Power Steering (2)",
			"Power Steering Control Circuit Low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0637",
			"Power Steering (3)",
			"Power Steering Control Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0638",
			"Throttle Actuator (1)",
			"Throttle Actuator Control Range/Performance (Bank 1)",
			1736
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0639",
			"Throttle Actuator (2)",
			"Throttle Actuator Control Range/Performance (Bank 2)",
			1394
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0640",
			"Intake Air Heater (4)",
			"Intake Air Heater Control Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0641",
			"Sensor Ref. Voltage A Circuit/Open",
			"Sensor Reference Voltage 'A' Circuit open",
			1526
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0642",
			"Sensor Ref. Voltage A Circuit Low",
			"Sensor Reference Voltage 'A' Circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0643",
			"Sensor Ref. Voltage A Circuit High",
			"Sensor Reference Voltage 'A' Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0644",
			"Driver Display data comm. circuit",
			"Driver Display data circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0645",
			"A/C Clutch Relay (1)",
			"A/C Clutch Relay Control Circuit",
			1729
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0646",
			"A/C Clutch Relay (2)",
			"A/C Clutch Relay Control Circuit Low",
			1729
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0647",
			"A/C Clutch Relay (3)",
			"A/C Clutch Relay Control Circuit High",
			1729
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0648",
			"Immobilizer device (2)",
			"Immobilizer Lamp Control Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0649",
			"Speed Control Light",
			"Speed Control Lamp Control Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0650",
			"MIL circuit",
			"Malfunction Indicator Light (MIL) control circuit",
			1638
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0651",
			"Sensor Reference Voltage B Circuit Open",
			"Sensor Reference Voltage 'B' Circuit open",
			1267
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0652",
			"Sensor Reference Voltage B Circuit Low",
			"Sensor Reference Voltage 'B' Circuit low",
			1267
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0653",
			"Sensor Reference Voltage B Circuit High",
			"Sensor Reference Voltage 'B' Circuit high",
			1267
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0654",
			"Engine speed (5)",
			"Engine RPM Out Circuit",
			1517
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0655",
			"Engine Overheat Light circuit",
			"Engine Hot Lamp Output Control Circuit",
			1624
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0656",
			"Fuel Level sensor (6)",
			"Fuel Level Output Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0657",
			"Actuator Supply Voltage A Circuit/Open",
			"Actuator Supply Voltage 'A' Circuit open",
			1172
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0658",
			"Actuator Supply Voltage A Circuit Low",
			"Actuator Supply Voltage 'A' Circuit low",
			1172
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0659",
			"Actuator Supply Voltage A Circuit High",
			"Actuator Supply Voltage 'A' Circuit high",
			1172
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0660",
			"IMT Valve (1)",
			"Intake Manifold Tuning Valve Control Circuit (Bank 1)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0661",
			"IMT Valve (2)",
			"Intake Manifold Tuning Valve Control Circuit Low (Bank 1)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0662",
			"IMT Valve (3)",
			"Intake Manifold Tuning Valve Control Circuit High (Bank 1)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0663",
			"IMT Valve (4)",
			"Intake Manifold Tuning Valve Control Circuit (Bank 2)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0664",
			"IMT Valve (5)",
			"Intake Manifold Tuning Valve Control Circuit Low (Bank 2)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0665",
			"IMT Valve (6)",
			"Intake Manifold Tuning Valve Control Circuit High (Bank 2)",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0666",
			"PCM/ECM/TCM Case Temp. Sensor Circuit",
			"PCM/ECM/TCM Internal Temperature Sensor circuit",
			1660
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0667",
			"PCM/ECM/TCM Temp. S. Range/Funct.",
			"PCM/ECM/TCM Internal Temperature Sensor Range/Function",
			1660
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0668",
			"PCM/ECM/TCM Temp. Sensor Circuit Low",
			"PCM/ECM/TCM Internal Temperature Sensor signal low",
			1660
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0669",
			"PCM/ECM/TCM Temp. Sensor Circuit High",
			"PCM/ECM/TCM Internal Temperature Sensor signal high",
			1660
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0670",
			"Glow plug module control circuit open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0671",
			"Cyl. 1 glow plug circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0672",
			"Cyl. 2 glow plug circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0673",
			"Cyl. 3 glow plug circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0674",
			"Cyl. 4 glow plug circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0675",
			"Cyl. 5 glow plug circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0676",
			"Cyl. 6 glow plug circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0677",
			"Cyl. 7 glow plug circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0678",
			"Cyl. 8 glow plug circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0679",
			"Cyl. 9 glow plug circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0680",
			"Cyl. 10 glow plug circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0681",
			"Cyl. 11 glow plug circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0682",
			"Cyl. 12 glow plug circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0683",
			"Engine ECU - Glow unit communication",
			"Engine ECU - Glow unit communication",
			1572
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0684",
			"Engine ECU - Glow unit comm. function",
			"Engine ECU - Glow unit comm. function",
			1572
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0685",
			"ECM/PCM power relay comm. open",
			"ECM/PCM power relay comm. open",
			1592
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0686",
			"ECM/PCM power relay comm. circuit low",
			"ECM/PCM power relay comm. circuit low",
			1607
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0687",
			"ECM/PCM power relay comm. circuit high",
			"ECM/PCM power relay comm. circuit high",
			1607
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0688",
			"ECM/PCM pwr relay control circuit open",
			"ECM/PCM pwr relay control circuit open",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0689",
			"ECM/PCM pwr relay control circuit low",
			"ECM/PCM pwr relay control circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0690",
			"ECM/PCM pwr relay control circuit high",
			"ECM/PCM pwr relay control circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0691",
			"Low circ. fan 1 control",
			"Low circ. fan 1 control",
			1448
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0692",
			"High circ. fan 1 control",
			"High circ. fan 1 control",
			1448
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0693",
			"Fan 2 control circuit low",
			"Fan 2 control circuit low",
			1654
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0694",
			"Fan 2 control circuit high",
			"Fan 2 control circuit high",
			1654
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0695",
			"Fan 3 control circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0696",
			"Fan 3 control circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0697",
			"Sensor C ref. voltage circuit open",
			"Sensor C ref. voltage circuit open",
			1278
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0698",
			"Sensor C ref. voltage circuit low",
			"Sensor C ref. voltage circuit low",
			1278
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0699",
			"Sensor C ref. voltage circuit high",
			"Sensor C ref. voltage circuit high",
			1278
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0700",
			"Transmission/Gear Sys (1)",
			"Transmission Control Malfunction: MIL request",
			1238
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0701",
			"Transmission/Gear Sys (2)",
			"Transmission Control System Range/Performance",
			1657
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0702",
			"Transmission/Gear Sys (3)",
			"Transmission Control System Electrical",
			1657
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0703",
			"Transmission/Gear Sys (4)",
			"Torque Converter/Brake Pedal Switch B Circuit Malfunction",
			1657
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0704",
			"Transmission/Gear Sys (5)",
			"Clutch Pedal Switch Signal Circuit Malfunction",
			1562
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0705",
			"Transmission/Gear Sys (6)",
			"A/T Range Selector Circuit fault (PRNDL Input)",
			1311
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0706",
			"Transmission/Gear Sys (7)",
			"A/T Range Selector (PRDNL) Circuit Range/Function",
			1311
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0707",
			"Transmission/Gear Sys (8)",
			"A/T Range Selector (PRDNL) Circuit input low",
			1698
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0708",
			"Transmission/Gear Sys (9)",
			"A/T Range Selector (PRDNL) Circuit input high",
			1712
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0709",
			"Transmission/Gear Sys (10)",
			"Transmisison Range Selector Circuit intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0710",
			"Transmission Fluid Temp (1)",
			"Transmission Fluid Temp Sensor Circuit Malfunction",
			1268
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0711",
			"Transmission Fluid Temp (2)",
			"Transmission Fluid Temp Sensor Circuit Range/Performance",
			1739
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0712",
			"Transmission Fluid Temp (3)",
			"Transmission Fluid Temp Sensor Circuit Low Input",
			1739
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0713",
			"Transmission Fluid Temp (4)",
			"Transmission Fluid Temp Sensor Circuit High Input",
			1739
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0714",
			"Transmission Fluid Temp (5)",
			"Transmission Fluid Temp Sensor Circuit Intermittent",
			1739
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0715",
			"Turbine Speed Sensor (1)",
			"A/T Input/Turbine Speed Sensor Circuit fault",
			1342
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0716",
			"Turbine Speed Sensor (2)",
			"A/T Input/Turbine Speed Sensor Circuit Range/Function",
			1342
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0717",
			"Turbine Speed Sensor (3)",
			"A/T Input/Turbine Speed Sensor Circuit: no signal",
			1342
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0718",
			"Turbine Speed Sensor (4)",
			"A/T Input/Turbine Speed Sensor Circuit intermittent",
			1342
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0719",
			"Transmission/Gear Sys (11)",
			"Torque Converter/Brake Switch B circuit low",
			1228
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0720",
			"Transmission/Gear Sys (12)",
			"A/T Output Speed Sensor Circuit fault",
			1387
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0721",
			"Transmission/Gear Sys (13)",
			"A/T Output Speed Sensor Circuit Range/Function",
			1447
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0722",
			"Transmission/Gear Sys (14)",
			"A/T Output Speed Sensor Circuit: no signal",
			1447
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0723",
			"Transmission/Gear Sys (15)",
			"A/T Output Speed Sensor Circuit intermittent",
			1447
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0724",
			"Transmission/Gear Sys (16)",
			"Torque Converter/Brake Switch B circuit high",
			1228
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0725",
			"Engine Speed (6)",
			"Engine Speed Input Circuit Malfunction",
			1433
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0726",
			"Engine Speed (7)",
			"Engine Speed Input Circuit Range/Performance",
			1269
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0727",
			"Engine Speed (8)",
			"Engine Speed Input Circuit No Signal",
			1433
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0728",
			"Engine Speed (9)",
			"Engine Speed Input Circuit Intermittent",
			1433
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0729",
			"6 gear shift contr./ratio plausibility",
			"6 gear shift contr./ratio plausibility",
			1304
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0730",
			"Gear Ratio (1)",
			"Gear Ratio control/correlation",
			1704
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0731",
			"Gear Ratio (2)",
			"Gear 1 Ratio control/correlation",
			1257
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0732",
			"Gear Ratio (3)",
			"Gear 2 Ratio control/correlation",
			1518
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0733",
			"Gear Ratio (4)",
			"Gear 3 Ratio control/correlation",
			1707
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0734",
			"Gear Ratio (5)",
			"Gear 4 Ratio control/correlation",
			1237
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0735",
			"Gear Ratio (6)",
			"Gear 5 Ratio control/correlation",
			1699
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0736",
			"Gear Ratio (7)",
			"Reverse Gear Ratio control/correlation",
			1233
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0737",
			"Transmission/Gear Sys (100)",
			"Tansmission control module (TCM) Engine Speed Output Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0738",
			"Transmission/Gear Sys (101)",
			"Tansmission control module (TCM) Engine Speed Output Circuit Low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0739",
			"Transmission/Gear Sys (102)",
			"Tansmission control module (TCM) Engine Speed Output Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0740",
			"Torque Conv. Clutch (1)",
			"Torque Converter Clutch Circuit Malfunction",
			1700
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0741",
			"Torque Conv. Clutch (2)",
			"Torque Converter Clutch Circuit Performance or Stuck Off",
			1486
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0742",
			"Torque Conv. Clutch (3)",
			"Torque Converter Clutch Circuit Stuck On",
			1486
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0743",
			"Torque Conv. Clutch (4)",
			"Torque Converter Clutch Circuit Electrical",
			1700
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0744",
			"Torque Conv. Clutch (5)",
			"Torque Converter Clutch Circuit intermittent",
			1700
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0745",
			"Transmission/Gear Sys (17)",
			"Pressure Control Solenoid Malfunction",
			1208
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0746",
			"Transmission/Gear Sys (18)",
			"Pressure Control Solenoid Performance or Stuck Off",
			1208
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0747",
			"Transmission/Gear Sys (19)",
			"Pressure Control Solenoid Stuck On",
			1208
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0748",
			"Transmission/Gear Sys (20)",
			"Pressure Control Solenoid Electrical",
			1208
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0749",
			"Transmission/Gear Sys (21)",
			"Pressure Control Solenoid Intermittent",
			1208
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0750",
			"Transmission/Gear Sys (22)",
			"Shift Solenoid A Malfunction",
			1581
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0751",
			"Transmission/Gear Sys (23)",
			"Shift Solenoid A Performance or Stuck Off",
			1445
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0752",
			"Transmission/Gear Sys (24)",
			"Shift Solenoid A Stuck On",
			1445
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0753",
			"Transmission/Gear Sys (25)",
			"Shift Solenoid A Electrical",
			1531
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0754",
			"Transmission/Gear Sys (26)",
			"Shift Solenoid A Intermittent",
			1320
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0755",
			"Transmission/Gear Sys (27)",
			"Shift Solenoid B Malfunction",
			1335
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0756",
			"Transmission/Gear Sys (28)",
			"Shift Solenoid B Performance or Stuck Off",
			1477
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0757",
			"Transmission/Gear Sys (29)",
			"Shift Solenoid B Stuck On",
			1477
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0758",
			"Transmission/Gear Sys (30)",
			"Shift Solenoid B Electrical",
			1200
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0759",
			"Transmission/Gear Sys (31)",
			"Shift Solenoid B Intermittent",
			1477
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0760",
			"Transmission/Gear Sys (32)",
			"Shift Solenoid C Malfunction",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0761",
			"Transmission/Gear Sys (33)",
			"Shift Solenoid C Performance or Stuck Off",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0762",
			"Transmission/Gear Sys (34)",
			"Shift Solenoid C Stuck On",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0763",
			"Transmission/Gear Sys (35)",
			"Shift Solenoid C Electrical",
			1325
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0764",
			"Transmission/Gear Sys (36)",
			"Shift Solenoid C Intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0765",
			"Transmission/Gear Sys (37)",
			"Shift Solenoid D Malfunction",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0766",
			"Transmission/Gear Sys (38)",
			"Shift Solenoid D Performance or Stuck Off",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0767",
			"Transmission/Gear Sys (39)",
			"Shift Solenoid D Stuck On",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0768",
			"Transmission/Gear Sys (40)",
			"Shift Solenoid D Electrical",
			1702
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0769",
			"Transmission/Gear Sys (41)",
			"Shift Solenoid D Intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0770",
			"Transmission/Gear Sys (42)",
			"Shift Solenoid E Malfunction",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0771",
			"Transmission/Gear Sys (43)",
			"Shift Solenoid E Performance or Stuck Off",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0772",
			"Transmission/Gear Sys (44)",
			"Shift Solenoid E Stuck On",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0773",
			"Transmission/Gear Sys (45)",
			"Shift Solenoid E Electrical",
			1235
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0774",
			"Transmission/Gear Sys (46)",
			"Shift Solenoid E Intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0775",
			"Transmission/Gear Sys (47)",
			"Pressure Control Solenoid B",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0776",
			"Transmission/Gear Sys (48)",
			"Pressure Control Solenoid B Performance or Stuck Off",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0777",
			"Transmission/Gear Sys (49)",
			"Pressure Control Solenoid B Stuck On",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0778",
			"Transmission/Gear Sys (50)",
			"Pressure Control Solenoid B Electrical",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0779",
			"Transmission/Gear Sys (51)",
			"Pressure Control Solenoid B Intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0780",
			"Transmission/Gear Sys (52)",
			"Shift Malfunction",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0781",
			"Transmission/Gear Sys (53)",
			"1-2 Shift Malfunction",
			1491
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0782",
			"Transmission/Gear Sys (54)",
			"2-3 Shift Malfunction",
			1606
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0783",
			"Transmission/Gear Sys (55)",
			"3-4 Shift Malfunction",
			1412
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0784",
			"Transmission/Gear Sys (56)",
			"4-5 Shift Malfunction",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0785",
			"Transmission/Gear Sys (57)",
			"Shift/Timing Solenoid Malfunction",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0786",
			"Transmission/Gear Sys (58)",
			"Shift/Timing Solenoid Range/Performance",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0787",
			"Transmission/Gear Sys (59)",
			"Shift/Timing Solenoid Low",
			1273
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0788",
			"Transmission/Gear Sys (60)",
			"Shift/Timing Solenoid High",
			1273
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0789",
			"Transmission/Gear Sys (61)",
			"Shift/Timing Solenoid Intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0790",
			"Transmission/Gear Sys (62)",
			"Normal/Performance Switch Circuit Malfunction",
			1292
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0791",
			"Transmission/Gear Sys (63)",
			"Intermediate Shaft Speed Sensor Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0792",
			"Transmission/Gear Sys (64)",
			"Intermediate Shaft Speed Sensor Circuit Range/Performance",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0793",
			"Transmission/Gear Sys (65)",
			"Intermediate Shaft Speed Sensor Circuit No Signal",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0794",
			"Transmission/Gear Sys (66)",
			"Intermediate Shaft Speed Sensor Circuit Intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0795",
			"Transmission/Gear Sys (67)",
			"Pressure Control Solenoid C",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0796",
			"Transmission/Gear Sys (68)",
			"Pressure Control Solenoid C Performance or Stuck Off",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0797",
			"Transmission/Gear Sys (69)",
			"Pressure Control Solenoid C Stuck On",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0798",
			"Transmission/Gear Sys (70)",
			"Pressure Control Solenoid C Electrical",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0799",
			"Transmission/Gear Sys (71)",
			"Pressure Control Solenoid C Intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0800",
			"Transfer Case ECU MIL request",
			"Transfer Case Control System: MIL request",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0801",
			"Transmission/Gear Sys (72)",
			"Reverse Inhibit Control Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0803",
			"Transmission/Gear Sys (73)",
			"1-4 Upshift (Skipp Shift) Solenoid Control Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0804",
			"Transmission/Gear Sys (74)",
			"1-4 Upshift (Skipp Shift) Lamp Control Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0805",
			"Transmission/Gear Sys (75)",
			"Clutch Position Sensor Circuit",
			1417
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0806",
			"Transmission/Gear Sys (76)",
			"Clutch Position Sensor Circuit Range/Performance",
			1417
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0807",
			"Transmission/Gear Sys (77)",
			"Clutch Position Sensor Circuit Low",
			1417
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0808",
			"Transmission/Gear Sys (78)",
			"Clutch Position Sensor Circuit High",
			1417
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0809",
			"Transmission/Gear Sys (79)",
			"Clutch Position Sensor Circuit Intermittent",
			1417
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0810",
			"Transmission/Gear Sys (80)",
			"Clutch Position Control Error",
			1417
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0811",
			"Transmission/Gear Sys (81)",
			"Excessive Clutch Slippage",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0812",
			"Transmission/Gear Sys (82)",
			"Reverse Input Circuit",
			1356
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0813",
			"Transmission/Gear Sys (83)",
			"Reverse Output Circuit",
			1202
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0814",
			"Transmission/Gear Sys (84)",
			"Transmission Range Display Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0815",
			"Transmission/Gear Sys (85)",
			"Upshift Switch Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0816",
			"Transmission/Gear Sys (86)",
			"Downshift Switch Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0817",
			"Starter Circuit (5)",
			"Starter Disable Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0818",
			"Transmission/Gear Sys (87)",
			"Driveline Disconnect Switch Input Circuit",
			1391
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0820",
			"Transmission/Gear Sys (88)",
			"Gear Lever X-Y Position Sensor Circuit",
			1201
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0821",
			"Transmission/Gear Sys (89)",
			"Gear Lever X Position Circuit",
			1326
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0822",
			"Transmission/Gear Sys (90)",
			"Gear Lever Y Position Circuit",
			1568
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0823",
			"Transmission/Gear Sys (91)",
			"Gear Lever X Position Circuit Intermittent",
			1236
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0824",
			"Transmission/Gear Sys (92)",
			"Gear Lever Y Position Circuit Intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0825",
			"Transmission/Gear Sys (93)",
			"Gear Lever Push-Pull Switch (Shift Anticipate)",
			1521
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0830",
			"Transmission/Gear Sys (94)",
			"Clutch Pedal Switch A Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0831",
			"Transmission/Gear Sys (95)",
			"Clutch Pedal Switch A Circuit Low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0832",
			"Transmission/Gear Sys (96)",
			"Clutch Pedal Switch A Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0833",
			"Transmission/Gear Sys (97)",
			"Clutch Pedal Switch B Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0834",
			"Transmission/Gear Sys (98)",
			"Clutch Pedal Switch B Circuit Low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0835",
			"Transmission/Gear Sys (99)",
			"Clutch Pedal Switch B Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0836",
			"Four Wheel Drive (1)",
			"Four Wheels Drive (4WD) Switch Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0837",
			"Four Wheel Drive (2)",
			"Four Wheels Drive (4WD) Switch Circuit Range/Performance",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0838",
			"Four Wheel Drive (3)",
			"Four Wheels Drive (4WD) Switch Circuit Low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0839",
			"Four Wheel Drive (4)",
			"Four Wheels Drive (4WD) Switch Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0840",
			"Trasmission Fluid Press (1)",
			"Trasmission Fluid Pressure Sensor/Switch A Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0841",
			"Trasmission Fluid Press (2)",
			"Trasmission Fluid Pressure Sensor/Switch A Circuit Range/Performance",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0842",
			"Trasmission Fluid Press (3)",
			"Trasmission Fluid Pressure Sensor/Switch A Circuit Low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0843",
			"Trasmission Fluid Press (4)",
			"Trasmission Fluid Pressure Sensor/Switch A Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0844",
			"Trasmission Fluid Press (5)",
			"Trasmission Fluid Pressure Sensor/Switch A Circuit Intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0845",
			"Trasmission Fluid Press (6)",
			"Trasmission Fluid Pressure Sensor/Switch B Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0846",
			"Trasmission Fluid Press (7)",
			"Trasmission Fluid Pressure Sensor/Switch B Circuit Range/Performance",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0847",
			"Trasmission Fluid Press (8)",
			"Trasmission Fluid Pressure Sensor/Switch B Circuit Low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0848",
			"Trasmission Fluid Press (9)",
			"Trasmission Fluid Pressure Sensor/Switch B Circuit High",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0849",
			"Trasmission Fluid Press (10)",
			"Trasmission Fluid Pressure Sensor/Switch B Circuit Intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0850",
			"P/N Switch Input Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0851",
			"P/N Switch Input Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0852",
			"P/N Switch Input Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0853",
			"Drive Switch Input Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0854",
			"Drive Switch Input Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0855",
			"Drive Switch Input Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0856",
			"Traction Control Input Signal",
			"Traction Control Input Signal",
			1469
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0857",
			"Tract. Control Input Sign. Range/Funct.",
			"Traction Control Input Signal Range/Function",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0858",
			"Traction Control Input Signal Low",
			"Traction Control Input Signal low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0859",
			"Traction Control Input Signal High",
			"Traction Control Input Signal high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0860",
			"Gearshift Module Comm. Circuit",
			"Gear Shift Module Communication Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0861",
			"Gearshift Module Comm. Circuit Low",
			"Gear Shift Module Communication Circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0862",
			"Gearshift Module Comm. Circuit High",
			"Gear Shift Module Communication Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0863",
			"TCM Comm. Circuit",
			"TCM Communication Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0864",
			"TCM Comm. Circuit Range/Funct.",
			"TCM Communication Circuit Range/Function",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0865",
			"TCM Comm. Circuit Low",
			"TCM Communication Circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0866",
			"TCM Comm. Circuit High",
			"TCM Communication Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0867",
			"A/T Pressure",
			"Transmission Fluid Pressure",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0868",
			"A/T Pressure Low",
			"Transmission Fluid Pressure low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0869",
			"A/T Pressure High",
			"Transmission Fluid Pressure high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0870",
			"A/T Press. Sensor/Sw. Circuit C",
			"A/T Fluid Pressure Sensor/Switch 'C' Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0871",
			"A/T Press. Signal Circuit C Range/Funct.",
			"A/T Fluid Pressure Sensor/Switch 'C' Circuit Range/Function",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0872",
			"A/T Press. Sensor/Sw. Circuit C Low",
			"A/T Fluid Pressure Sensor/Switch 'C' Circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0873",
			"A/T Press. Sensor/Sw. Circuit C High",
			"A/T Fluid Pressure Sensor/Switch 'C' Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0874",
			"A/T Press. Signal / Circuit C Intermittent",
			"A/T Fluid Pressure Sensor/Switch 'C' Circuit Intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0875",
			"A/T Press. Sensor/Sw. Circuit D",
			"A/T Fluid Pressure Sensor/Switch 'D' Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0876",
			"A/T Press. Signal Circuit D Range/Funct.",
			"A/T Fluid Pressure Sensor/Switch 'D' Circuit Range/Function",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0877",
			"A/T Press. Sensor/Sw. Circuit D Low",
			"A/T Fluid Pressure Sensor/Switch 'D' Circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0878",
			"A/T Press. Sensor/Sw. Circuit D High",
			"A/T Fluid Pressure Sensor/Switch 'D' Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0879",
			"A/T Press. Signal / Circuit D Intermittent",
			"A/T Fluid Pressure Sensor/Switch 'D' Circuit intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0880",
			"TCM Power Input Signal",
			"A/T Fluid Pressure Sensor/Switch 'D' Circuit intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0881",
			"TCM Power Input Signal Range/Funct.",
			"TCM Power Input Signal Range/Function",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0882",
			"TCM Power Input Signal Low",
			"TCM Power Input Signal low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0883",
			"TCM Power Input Signal High",
			"TCM Power Input Signal high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0884",
			"TCM Power Input Signal Intermittent",
			"TCM Power Imput Signal intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0885",
			"TCM Power Relay Control Circuit/Open",
			"TCM Power Relay Control Circuit open",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0886",
			"TCM Power Relay Control Circuit Low",
			"TCM Power Relay Control Circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0887",
			"TCM Power Relay Control Circuit High",
			"TCM Power Relay Control Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0888",
			"TCM Power Relay Sense Circuit",
			"TCM Power Relay monitoring circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0889",
			"TCM Pwr Relay Sense Circuit Range/Funct.",
			"TCM Power Relay Monitoring Circuit Range/Function",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0890",
			"TCM Power Relay Sense Circuit Low",
			"TCM Power Relay Monitoring Circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0891",
			"TCM Power Relay Sense Circuit High",
			"TCM Power Relay Monitoring Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0892",
			"TCM Power Relay Sense Circuit Intermittent",
			"TCM Power Relay Monitoring Circuit intermittent",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0893",
			"Multiple Gears Engaged",
			"Multiple Gears engaged",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0894",
			"A/T Component Slipping",
			"A/T clutch/band slipping",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0895",
			"Shift Time Too Short",
			"Shift Time too short",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0896",
			"Shift Time Too Long",
			"Shift Time too long",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0897",
			"A/T Fluid Deteriorated",
			"Transmission Fluid deteriorated",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0898",
			"Trans. ECU MIL Request Circuit Low",
			"A/T ECU MIL Request Circuit low",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0899",
			"Trans. ECU MIL Request Circuit High",
			"A/T ECU MIL Request Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0900",
			"Clutch Actuator Circuit Open",
			"Clutch Actuator Circuit open",
			1203
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0901",
			"Clutch Actuator Circuit Range/Funct.",
			"Clutch Actuator Circuit Range/Function",
			1203
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0902",
			"Clutch Actuator Circuit Low",
			"Clutch Actuator Circuit low",
			1203
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0903",
			"Clutch Actuator Circuit High",
			"Clutch Actuator Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0904",
			"Gate Select Pos. Circuit",
			"Gate Select Position Circuit",
			1737
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0905",
			"Gate Select Pos. Circuit",
			"Gate Select Position Circuit",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0906",
			"Gate Select Pos. Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0907",
			"Gate Select Pos. Circuit High",
			"Gate Select Position Circuit high",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0908",
			"Gate Select Pos. Circuit Intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0909",
			"Gate Select Control Error",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0910",
			"Gate Select Actuator Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0911",
			"Gate Select Actuator Circuit Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0912",
			"Gate Select Actuator Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0913",
			"Gate Select Actuator Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0914",
			"Shifter Pos. Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0915",
			"Shifter Pos. Circuit Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0916",
			"Shifter Pos. Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0917",
			"Shifter Pos. Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0918",
			"Shifter Pos. Circuit Intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0919",
			"Shifter Pos. Control Error",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0920",
			"Shifter Forw. Act. Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0921",
			"Shifter Forw. Act. Circuit Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0922",
			"Shifter Forw. Act. Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0923",
			"Shifter Forw. Act. Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0924",
			"Shifter Rev. Act. Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0925",
			"Shifter Rev. Act. Circuit Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0926",
			"Shifter Rev. Act. Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0927",
			"Shifter Rev. Act. Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0928",
			"Shifter Lock Solenoid Circuit Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0929",
			"Shifter Lock Solenoid Circuit Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0930",
			"Shifter Lock Solenoid Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0931",
			"Shifter Lock Solenoid Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0932",
			"Hydr. Pressure Sensor Circuit",
			"No help available at present",
			1532
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0933",
			"Hydr. Pressure Sensor Range/Funct.",
			"Hydr. Pressure Sensor Range/Funct.",
			1532
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0934",
			"Hydr. Pressure Sensor Circuit Low",
			"Hydr. Pressure Sensor Circuit Low",
			1532
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0935",
			"Hydr. Pressure Sensor Circuit High",
			"Hydr. Pressure Sensor Circuit High",
			1532
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0936",
			"Hydr. Press. Sensor Circuit Intermittent",
			"Hydr. Press. Sensor Circuit Intermittent",
			1532
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0937",
			"Hydr. Oil Temp. Sensor Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0938",
			"Hydr. Oil Temp. Sensor Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0939",
			"Hydr. Oil Temp. Sensor Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0940",
			"Hydr. Oil Temperature Sensor Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0941",
			"Hydr. Oil Temp. Sensor Circuit Intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0942",
			"Hydr. Pressure Unit",
			"No help available at present",
			1552
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0943",
			"Hydr. Press. Unit Cycling Period Short",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0944",
			"Hydr. Unit: Pressure Loss",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0945",
			"Hydr. Pump Relay Circuit Open",
			"Hydr. Pump Relay Circuit Open",
			1533
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0946",
			"Hydr. Pump Relay Circuit Range/Funct.",
			"Hydr. Pump Relay Circuit Range/Funct.",
			1533
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0947",
			"Hydr. Pump Relay Circuit Low",
			"Hydr. Pump Relay Circuit Low",
			1533
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0948",
			"Hydr. Pump Relay Circuit High",
			"Hydr. Pump Relay Circuit High",
			1533
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0949",
			"AutoShift Manual Learn Incomplete",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0950",
			"AutoShift Manual Control Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0951",
			"AutoShift Manual Shift Circuit Range/Funct",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0952",
			"AutoShift Manual Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0953",
			"AutoShift Manual Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0954",
			"AutoShift Manual Shift Circuit Intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0955",
			"AutoShift Manual Mode Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0956",
			"AutoShift Manual Mode Circuit Range/Funct",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0957",
			"AutoShift Manual Mode Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0958",
			"AutoShift Manual Mode Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0959",
			"AutoShift Manual Mode Circuit Intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0960",
			"Pressure Solenoid A Circuit/Open",
			"Pressure Solenoid A Circuit/Open",
			1731
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0961",
			"Pressure Solenoid A Circuit Range/Funct.",
			"Pressure Solenoid A Circuit Range/Funct.",
			1731
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0962",
			"Pressure Solenoid A Circuit Low",
			"Pressure Solenoid A Circuit Low",
			1731
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0963",
			"Pressure Solenoid A Circuit High",
			"Pressure Solenoid A Circuit High",
			1731
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0964",
			"Pressure Solenoid B Circuit/Open",
			"Pressure Solenoid B Circuit/Open",
			1731
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0965",
			"Pressure Solenoid B Circuit Range/Funct.",
			"Pressure Solenoid B Circuit Range/Funct.",
			1731
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0966",
			"Pressure Solenoid B Circuit Low",
			"Pressure Solenoid B Circuit Low",
			1731
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0967",
			"Pressure Solenoid B Circuit High",
			"Pressure Solenoid B Circuit High",
			1731
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0968",
			"Pressure Solenoid C Circuit/Open",
			"Pressure Solenoid C Circuit/Open",
			1731
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0969",
			"Pressure Solenoid C Circuit Range/Funct.",
			"Pressure Solenoid C Circuit Range/Funct.",
			1731
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0970",
			"Pressure Solenoid C Circuit Low",
			"Pressure Solenoid C Circuit Low",
			1731
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0971",
			"Pressure Solenoid C Circuit High",
			"Pressure Solenoid C Circuit High",
			1731
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0972",
			"Shift Solenoid A Circuit Range/Funct.",
			"Shift Solenoid A Circuit Range/Funct.",
			1445
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0973",
			"Shift Solenoid A Circuit Low",
			"Shift Solenoid A Circuit Low",
			1445
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0974",
			"Shift Solenoid A Circuit High",
			"Shift Solenoid A Circuit High",
			1445
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0975",
			"Shift Solenoid B Circuit Range/Funct.",
			"Shift Solenoid B Circuit Range/Funct.",
			1477
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0976",
			"Shift Solenoid B Circuit Low",
			"Shift Solenoid B Circuit Low",
			1477
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0977",
			"Shift Solenoid B Circuit High",
			"Shift Solenoid B Circuit High",
			1477
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0978",
			"Shift Solenoid C Circuit Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0979",
			"Shift Solenoid C Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0980",
			"Shift Solenoid C Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0981",
			"Shift Solenoid D Circuit Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0982",
			"Shift Solenoid D Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0983",
			"Shift Solenoid D Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0984",
			"Shift Solenoid E Circuit Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0985",
			"Shift Solenoid E Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0986",
			"Shift Solenoid E Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0987",
			"A/T Fluid Press. Sensor/Switch E Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0988",
			"A/T Pressure Sign. Circuit E Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0989",
			"A/T Pressure Signal/Circuit E Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0990",
			"A/T Pressure Signal/Circuit E High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0991",
			"A/T Pressure Signal Circuit E Intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0992",
			"A/T Fluid Press. Sensor/Switch F Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0993",
			"A/T Pressure Sign. Circuit F Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0994",
			"A/T Pressure Signal/Circuit F Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0995",
			"A/T Pressure Signal/Circuit F High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0996",
			"A/T Pressure Signal/Circuit F Intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0997",
			"Shift Solenoid F Circuit Range/Funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0998",
			"Shift Solenoid F Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0999",
			"Shift Solenoid F Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A00",
			"ECT Mot. Electronics Sensor Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A01",
			"ECT Electronics Sens. Circuit Range/Funct",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A02",
			"ECT Mot. Electronics Sens. Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A03",
			"ECT Mot. Electronics Sens. Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A04",
			"ECT Mot. Electronics Sens. Circuit Intermitt",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A05",
			"Mot. Electr. Coolant Pump Ctrl Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A06",
			"Coolant pump electric motor circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A07",
			"Mot. Electr. Coolant Pump Ctrl Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A08",
			"DC/DC Converter Status Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A09",
			"DC/DC Converter Status Circuit Low Input",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A10",
			"DC/DC Converter Status Circuit High Input",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A11",
			"DC/DC Converter Enable Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A12",
			"DC/DC Converter Enable Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A13",
			"DC/DC Converter Enable Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A14",
			"Engine Mount Control Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A15",
			"Engine Mount Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A16",
			"Engine Mount Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A17",
			"Motor Torque Sensor Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A18",
			"Motor Torque Sensor Circuit Range/Funct",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A19",
			"Motor Torque Sensor Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A20",
			"Motor Torque Sensor Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A21",
			"Motor Torque Sensor Circuit Intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A22",
			"Generator Torque Sensor Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A23",
			"Generat. Torque Sen. Circuit Range/Funct",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A24",
			"Generator Torque Sensor Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A25",
			"Generator Torque Sensor Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A26",
			"Generator Torque Sensor Circuit Intermitt",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A27",
			"Battery Power Off Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A28",
			"Battery Power Off Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"0A29",
			"Battery Power Off Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2000",
			"NOx Trap Efficiency below limit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2001",
			"NOx Trap Efficiency below limit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2002",
			"Particle Trap Efficiency below limit B1",
			"Particle Trap Efficiency below limit B1",
			1535
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2003",
			"Particle Trap Efficiency below limit B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2004",
			"Variable Intake Control stuck open B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2005",
			"Variable Intake Control stuck open B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2006",
			"Variable Intake Control stuck closed B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2007",
			"Variable Intake Control stuck closed B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2008",
			"Variable Intake Control stuck closed",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2009",
			"Variable Intake Control circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2010",
			"Variable Intake Control circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2011",
			"Variable Intake Control circuit/open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2012",
			"Variable Intake Control circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2013",
			"Variable Intake Control circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2014",
			"Var. Intake Pos. Sensor/Switch/Ckt",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2015",
			"Var. Intake Pos. Sensor/Sw. circuit funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2016",
			"Variable Intake Pos. signal/circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2017",
			"Variable Intake Pos. signal/circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2018",
			"Var. Intake Pos. signal/circuit intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2019",
			"Variable Intake Pos. Signal/Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2020",
			"Var. Intake Pos. Sensor/Sw. circuit funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2021",
			"Variable Intake Pos. signal/circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2022",
			"Variable Intake Pos. signal/circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2023",
			"Var. Intake Pos. signal/circuit intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2024",
			"EVAP Fuel Vapor Temp sensor/circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2025",
			"Fuel/Air temp. sensor",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2026",
			"EVAP Fuel Vapor Temp signal/circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2027",
			"EVAP Fuel Vapor Temp signal/circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2028",
			"EVAP Fuel Vapor Temp signal intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2029",
			"Fuel-burning Aux. Heater Disabled",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2030",
			"Fuel-burning aux. heater performance",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2031",
			"Exhaust Gas Temp. Sensor circuit",
			"Exhaust Gas Temp. Sensor circuit",
			1487
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2032",
			"Exhaust Gas Temp. Sensor circuit low",
			"Exhaust Gas Temp. Sensor circuit low",
			1487
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2033",
			"Exhaust Gas Temp. Sensor circuit high",
			"Exhaust Gas Temp. Sensor circuit high",
			1487
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2034",
			"Exhaust Gas Temp. Sensor circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2035",
			"Exhaust Gas Temp. Sensor circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2036",
			"Exhaust Gas Temp. Sensor circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2037",
			"Reductant Inj. Air Press. Sensor circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2038",
			"Reductant Inj. Air Press. Sensor funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2039",
			"Reductant Inj. Air Press. Signal/Circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2040",
			"Reductant Inj.Air Press. Sign./Circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2041",
			"Reductant Inj. Air Press. Signal interm.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2042",
			"Reductant Temperature Sensor Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2043",
			"Reductant Temp Sens/circuit range/funct",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2044",
			"Reductant Temp Signal/Circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2045",
			"Reductant Temp Signal/Circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2046",
			"Reductant Temp Signal intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2047",
			"Reductant Injector Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2048",
			"Reductant Injector Circuit low B1U1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2049",
			"Reductant Injector Circuit high B1U1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2050",
			"Reductant Injector Circuit/Open B1U1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2051",
			"Reductant Injector Circuit low B2U1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2052",
			"Reductant Injector Circuit high B2U1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2053",
			"Reductant Injector Circuit/Open B1U2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2054",
			"Reductant Injector Circuit low B1U2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2055",
			"Reductant Injector Circuit high B1U2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2056",
			"Reductant Injector Circuit/open B2U2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2057",
			"Reductant Injector Circuit low B2U2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2058",
			"Reductant Injector Circuit high B2U2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2059",
			"Air Inj./Reductant Pump circuit open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2060",
			"Reductant Inj. Air Pump Control Circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2061",
			"Reductant Inj.Air Pump Control Circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2062",
			"Reductant Supply Control Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2063",
			"Reductant Supply Control Circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2064",
			"Reductant Supply Control Circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2065",
			"Fuel Level Sensor B Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2066",
			"Fuel Level Sensor B Performance",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2067",
			"Fuel Level Sensor B Circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2068",
			"Fuel Level Sensor B Circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2069",
			"Fuel Level Sensor B Circuit intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2070",
			"In. Manifold/IMT Valve stuck open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2071",
			"In. Manifold/IMT Valve stuck closed",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2075",
			"In. Manifold/IMT Valve Pos. signal circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2076",
			"IMT solenoid switch/pos. sensor",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2077",
			"In. Manifold/IMT Valve Pos. signal low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2078",
			"In. Manifold/IMT Valve Pos. signal high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2079",
			"In. Manifold/IMT Valve Pos. signal interm.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2080",
			"Ex. Gas Temp Sensor Circuit function B1S1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2081",
			"Ex. Gas Temp Sensor Circuit intermitt. B1S1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2082",
			"Ex. Gas Temp Sensor Circuit function B2S1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2083",
			"Ex. Gas Temp Sensor Circuit intermitt. B2S1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2084",
			"Ex. Gas Temp Sensor Circuit function B1S2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2085",
			"Ex. Gas Temp Sensor Circuit intermitt. B1S2",
			"Ex. Gas Temp Sensor Circuit intermitt. B1S2",
			1483
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2086",
			"Ex. Gas Temp Sensor Circuit function B2S2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2087",
			"Ex. Gas Temp Sensor Circuit intermitt. B2S2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2088",
			"A Camshaft Pos. Actuator Circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2089",
			"A Camshaft Pos. Actuator Circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2090",
			"B Camshaft Pos. Actuator Circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2091",
			"B Camshaft Pos. Actuator Circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2092",
			"A Camshaft Pos. Actuator Circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2093",
			"A Camshaft Pos. Actuator Circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2094",
			"B Camshaft Pos. Actuator Circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2095",
			"B Camshaft Pos. Actuator Circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2096",
			"Post Catalyst Fuel Trim Sys lean B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2097",
			"Post Catalyst Fuel Trim Sys rich B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2098",
			"Post Catalyst Fuel Trim Sys lean B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2099",
			"Post Catalyst Fuel Trim Sys rich B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2100",
			"Throttle Act. Control Motor Circuit/Open",
			"Throttle Act. Control Motor Circuit/Open",
			1548
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2101",
			"Throttle Act. Ctrl Mot. Circuit Range/Funct",
			"Throttle Act. Ctrl Mot. Circuit Range/Funct",
			1548
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2102",
			"Throttle Actuator Contr. Motor Circuit Low",
			"Throttle Actuator Contr. Motor Circuit Low",
			1548
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2103",
			"Throttle Actuator Contr. Motor Circuit High",
			"Throttle Actuator Contr. Motor Circuit High",
			1548
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2104",
			"Throttle Act. Contr. Syst. - Forced Idle",
			"Throttle Act. Contr. Syst. - Forced Idle",
			1548
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2105",
			"Throttle Control - Forced shutdown",
			"Throttle Control - Forced shutdown",
			1548
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2106",
			"Motor throttle Ctrl.-power limiter",
			"Motor throttle Ctrl.-power limiter",
			1548
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2107",
			"Throttle Act. Control Module Processor",
			"Throttle Act. Control Module Processor",
			1548
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2108",
			"Throttle Act. Control Module Perform.",
			"Throttle Act. Control Module Perform.",
			1548
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2109",
			"TPS/Pedal Sensor A MIN Stop Perform.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2110",
			"Throttle Act. Ctrl Sys.- Forced Lim. RPM",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2111",
			"Throttle Actuator Ctrl Sys -Stuck Open",
			"Throttle Actuator Ctrl Sys -Stuck Open",
			1548
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2112",
			"Throttle Act. Ctrl System -Stuck Closed",
			"Throttle Act. Ctrl System -Stuck Closed",
			1548
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2113",
			"TPS/Pedal Sensor B MIN Stop Perform.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2114",
			"TPS/Pedal Sensor C MIN Stop Perform.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2115",
			"TPS/Pedal Sensor D MIN Stop Perform.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2116",
			"TPS/Pedal Sensor E MIN Stop Perform.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2117",
			"TPS/Pedal Sensor F MIN Stop Perform.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2118",
			"Throttle Act.Ctrl Mot. AMP Range/Funct",
			"Throttle Act.Ctrl Mot. AMP Range/Funct",
			1548
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2119",
			"Throttle Act. Ctrl TB Range/Perform.",
			"Throttle Act. Ctrl TB Range/Perform.",
			1548
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2120",
			"TPS/Pedal Position Sensor/Switch D Circuit",
			"TPS/Pedal Position Sensor/Switch D Circuit",
			1589
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2121",
			"TPS/Ped.Pos.Sen./Sw D Circuit Range/Per.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2122",
			"TPS/Ped. Pos. Sen./Sw D Circuit Low Imput",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2123",
			"TPS/Ped. Pos. Sen./Sw D Circuit High Imput",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2124",
			"TPS/Ped. Pos. Sen./Sw D Circuit Intermitt.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2125",
			"TPS/Pedal Position Sensor/Switch E Circuit",
			"TPS/Pedal Position Sensor/Switch E Circuit",
			1192
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2126",
			"TPS/Ped.Pos.Sen./Sw E Circuit Range/Per.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2127",
			"TPS/Ped. Pos. Sen./Sw E Circuit Low Imput",
			"TPS/Ped. Pos. Sen./Sw E Circuit Low Imput",
			1609
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2128",
			"TPS/Ped. Pos. Sen./Sw E Circuit High Imput",
			"TPS/Ped. Pos. Sen./Sw E Circuit High Imput",
			1609
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2129",
			"TPS/Ped. Pos. Sen./Sw E Circuit Intermitt.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2130",
			"TPS/Pedal Position Sensor/Switch F Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2131",
			"TPS/Ped.Pos.Sen./Sw F Circuit Range/Per.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2132",
			"TPS/Ped. Pos. Sen./Sw F Circuit Low Imput",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2133",
			"TPS/Ped. Pos. Sen./Sw F Circuit High Imput",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2134",
			"TPS/Ped. Pos. Sen./Sw F Circuit Intermitt.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2135",
			"TPS/Ped. Pos.Sen./Sw A/B Volts Correl.",
			"TPS/Ped. Pos.Sen./Sw A/B Volts Correl.",
			1588
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2136",
			"TPS/Ped. Pos.Sen./Sw A/C Volts Correl.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2137",
			"TPS/Ped. Pos.Sen./Sw B/C Volts Correl.",
			"TPS/Ped. Pos.Sen./Sw B/C Volts Correl.",
			1336
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2138",
			"TPS/Ped. Pos.Sen./Sw D/E Volts Correl.",
			"TPS/Ped. Pos.Sen./Sw D/E Volts Correl.",
			1588
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2139",
			"TPS/Ped. Pos.Sen./Sw D/F Volts Correl.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2140",
			"TPS/Ped. Pos.Sen./Sw E/F Volts Correl.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2141",
			"EGR Throttle Control Circuit Low",
			"EGR Throttle Control Circuit Low",
			1696
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2142",
			"EGR Throttle Control Circuit High",
			"EGR Throttle Control Circuit High",
			1696
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2143",
			"EGR Vent Control Circuit/Open",
			"EGR Vent Control Circuit/Open",
			1471
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2144",
			"EGR Vent Control Circuit Low",
			"EGR Vent Control Circuit Low",
			1471
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2145",
			"EGR Vent Control Circuit High",
			"EGR Vent Control Circuit High",
			1471
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2146",
			"Fuel Injector Gr. A Supp. Volts Circuit/Open",
			"Fuel Injector Gr. A Supp. Volts Circuit/Open",
			1485
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2147",
			"Fuel Injector Gr. A Supply Volts Circuit Low",
			"Fuel Injector Gr. A Supply Volts Circuit Low",
			1684
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2148",
			"Fuel Injector Gr. A Supply Volts Circuit High",
			"Fuel Injector Gr. A Supply Volts Circuit High",
			1684
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2149",
			"Fuel Injector Gr. B Supp. Volts Circuit/Open",
			"Fuel Injector Gr. B Supp. Volts Circuit/Open",
			1222
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2150",
			"Fuel Injector Gr. B Supply Volts Circuit Low",
			"Fuel Injector Gr. B Supply Volts Circuit Low",
			1222
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2151",
			"Fuel Injector Gr. B Supply Volts Circuit High",
			"Fuel Injector Gr. B Supply Volts Circuit High",
			1222
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2152",
			"Fuel Injector Gr. C Supp. Volts Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2153",
			"Fuel Injector Gr. C Supply Volts Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2154",
			"Fuel Injector Gr. C Supply Volts Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2155",
			"Fuel Injector Gr. D Supp. Volts Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2156",
			"Fuel Injector Gr. D Supply Volts Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2157",
			"Fuel Injector Gr. D Supply Volts Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2158",
			"Vehicle Speed Sensor B",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2159",
			"VSS B Range/Performance",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2160",
			"VSS B Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2161",
			"VSS B Intermittent/Erratic",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2162",
			"VSS A / B Correlation",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2163",
			"TPS/Pedal Pos.Sens. A MAX Stop funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2164",
			"TPS/Pedal Pos.Sen. B MAX Stop funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2165",
			"TPS/Pedal Pos.Sen. C MAX Stop funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2166",
			"TPS/Pedal Pos.Sen. D MAX Stop funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2167",
			"TPS/Pedal Pos.Sen. E MAX Stop funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2168",
			"TPS/Pedal Pos.Sen. F MAX Stop funct.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2169",
			"Ex. Press. Reg. Vent Solenoid Ctrl Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2170",
			"Ex. gas press. reg. solenoid circuit low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2171",
			"Ex. gas press. reg. solenoid circuit high",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2172",
			"Throttle Act. Ctrl Sys-Sudden HI Airflow",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2173",
			"Throttle Act. Ctrl Sys - High Airflow",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2174",
			"Throttle Act.Ctrl Sys-Sudden LO Airflow",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2175",
			"Throttle Act. Ctrl Sys - Low Airflow",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2176",
			"Throttle Act.Ctrl Sys - Idle Not Learned",
			"Throttle Act.Ctrl Sys - Idle Not Learned",
			1339
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2177",
			"System Too Lean Off Idle B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2178",
			"System Too Rich Off Idle B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2179",
			"System Too Lean Off Idle B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2180",
			"System Too Rich Off Idle B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2181",
			"Cooling System Performance",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2182",
			"ECT Sensor 2 Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2183",
			"ECT Sensor 2 Circuit Range/Performance",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2184",
			"ECT Sensor 2 Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2185",
			"ECT Sensor 2 Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2186",
			"ECT Sensor 2 Circuit Intermittent/Erratic",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2187",
			"System Too Lean at Idle B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2188",
			"System Too Rich at Idle B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2189",
			"System Too Lean at Idle B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2190",
			"System Too Rich at Idle B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2191",
			"System Too Lean at Higher Load B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2192",
			"System Too Rich at Higher Load B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2193",
			"System Too Lean at Higher Load B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2194",
			"System Too Rich at Higher Load B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2195",
			"O2 Sensor Signal Stuck Lean B1S1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2196",
			"O2 Sensor Signal Stuck Rich B1S1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2197",
			"O2 Sensor Signal Stuck Lean B2S1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2198",
			"O2 Sensor Signal Stuck Rich B2S1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2199",
			"IAT Sensor 1 / 2 Correlation",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2200",
			"NOx Sensor Circuit B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2201",
			"NOx Sensor Circuit Range/Performance B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2202",
			"NOx Sensor Circuit Low Input B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2203",
			"NOx Sensor Circuit High Input B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2204",
			"NOx Sensor Circuit Intermittent Input B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2205",
			"NOx Sensor Heater Control Circuit/Open B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2206",
			"NOx Sensor Heater Ctrl Circuit Low B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2207",
			"NOx Sensor Heater Ctrl Circuit High B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2208",
			"NOx Sensor Heater Sense Circuit B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2209",
			"NOx Sensor Htr Sense Circuit Ran/funct B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2210",
			"NOx Sensor Htr Sense Circuit Low Input B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2211",
			"NOx Sensor Htr Sense Circuit High Input B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2212",
			"NOx Sensor Htr Sense Circuit Intermitt. B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2213",
			"NOx Sensor Circuit B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2214",
			"NOx Sensor Circuit Range/Performance B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2215",
			"NOx Sensor Circuit Low Input B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2216",
			"NOx Sensor Circuit High Input B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2217",
			"NOx Sensor Circuit Intermittent Input B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2218",
			"NOx Sensor Heater Ctrl Circuit/Open B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2219",
			"NOx Sensor Heater Ctrl Circuit Low B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2220",
			"NOx Sensor Heater Ctrl Circuit High B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2221",
			"NOx Sensor Heater Sense Circuit B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2222",
			"NOx Sensor Htr Sense Circuit Ran/Perf. B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2223",
			"NOx Sensor Heater Sense Circuit Low B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2224",
			"NOx Sensor Heater Sense Circuit High B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2225",
			"NOx Sensor Heater Sense Circuit Interm. B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2226",
			"Barometric Pressure Circuit",
			"Barometric Pressure Circuit",
			1482
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2227",
			"BARO Press. Circuit Range/Performance",
			"BARO Press. Circuit Range/Performance",
			1348
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2228",
			"Barometric Pressure Circuit Low",
			"Barometric Pressure Circuit Low",
			1348
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2229",
			"Barometric Pressure Circuit High",
			"Barometric Pressure Circuit High",
			1348
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2230",
			"Barometric Pressure Circuit Intermittent",
			"Barometric Pressure Circuit Intermittent",
			1348
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2231",
			"O2S Signal Circuit Shorted to HTR Circuit B1S1",
			"O2S Signal Circuit Shorted to HTR Circuit B1S1",
			1603
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2232",
			"O2S Signal Circuit Shorted to HTR Circuit B1S2",
			"O2S Signal Circuit Shorted to HTR Circuit B1S2",
			1603
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2233",
			"O2S Signal Circuit Shorted to HTR Circuit B1S3",
			"O2S Signal Circuit Shorted to HTR Circuit B1S3",
			1603
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2234",
			"O2S Signal Circuit Shorted to HTR Circuit B2S1",
			"O2S Signal Circuit Shorted to HTR Circuit B2S1",
			1603
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2235",
			"O2S Signal Circuit Shorted to HTR Circuit B2S2",
			"O2S Signal Circuit Shorted to HTR Circuit B2S2",
			1603
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2236",
			"O2S Signal Circuit Shorted to HTR Circuit B2S3",
			"O2S Signal Circuit Shorted to HTR Circuit B2S3",
			1603
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2237",
			"O2S Posit. Current Ctrl Circuit/Open B1S1",
			"O2S Posit. Current Ctrl Circuit/Open B1S1",
			1617
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2238",
			"O2S Posit. Current Ctrl Circuit Low B1S1",
			"O2S Posit. Current Ctrl Circuit Low B1S1",
			1617
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2239",
			"O2S Posit. Current Ctrl Circuit High B1S1",
			"O2S Posit. Current Ctrl Circuit High B1S1",
			1617
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2240",
			"O2S Posit. Current Ctrl Circuit/Open B2S1",
			"O2S Posit. Current Ctrl Circuit/Open B2S1",
			1368
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2241",
			"O2S Posit. Current Ctrl Circuit Low B2S1",
			"O2S Posit. Current Ctrl Circuit Low B2S1",
			1368
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2242",
			"O2S Posit. Current Ctrl Circuit High B2S1",
			"O2S Posit. Current Ctrl Circuit High B2S1",
			1368
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2243",
			"O2S Ref. Voltage Circuit/Open B1S1",
			"O2S Ref. Voltage Circuit/Open B1S1",
			1176
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2244",
			"O2S Reference Voltage Perform. B1S1",
			"O2S Reference Voltage Perform. B1S1",
			1234
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2245",
			"O2S Reference Voltage Circuit Low B1S1",
			"O2S Reference Voltage Circuit Low B1S1",
			1234
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2246",
			"O2S Reference Voltage Circuit High B1S1",
			"O2S Reference Voltage Circuit High B1S1",
			1234
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2247",
			"O2S Reference Voltage Circuit/Open B2S1",
			"O2S Reference Voltage Circuit/Open B2S1",
			1711
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2248",
			"O2S Reference Voltage Perform. B2S1",
			"O2S Reference Voltage Perform. B2S1",
			1234
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2249",
			"O2S Reference Voltage Circuit Low B2S1",
			"O2S Reference Voltage Circuit Low B2S1",
			1234
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2250",
			"O2S Reference Voltage Circuit High B2S1",
			"O2S Reference Voltage Circuit High B2S1",
			1234
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2251",
			"O2S Neg. Current Ctrl Circuit/Open B1S1",
			"O2S Neg. Current Ctrl Circuit/Open B1S1",
			1333
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2252",
			"O2S Neg. Current Ctrl Circuit Low B1S1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2253",
			"O2S Neg. Current Ctrl Circuit High B1S1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2254",
			"O2S Neg. Current Ctrl Circuit/Open B2S1",
			"O2S Neg. Current Ctrl Circuit/Open B2S1",
			1499
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2255",
			"O2S Neg. Current Ctrl Circuit Low B2S1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2256",
			"O2S Neg. Current Ctrl Circuit High B2S1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2257",
			"Sec. Air Inject. System Ctrl A Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2258",
			"Sec. Air Inject. System Ctrl A Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2259",
			"Sec. Air Inject. System Ctrl B Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2260",
			"Sec. Air Inject. System Ctrl B Circuit High",
			"Sec. Air Inject. System Ctrl B Circuit High",
			1721
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2261",
			"Turbo/S.Charger Bypass Valve -Mech.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2262",
			"Turbo Boost Press. Not Detect -Mech.",
			"Turbo Boost Press. Not Detect -Mech.",
			1254
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2263",
			"Turbo/S.Charger Boost Sys Perform.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2264",
			"Water in Fuel Sensor Circuit",
			"No help available at present",
			1414
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2265",
			"Water in fuel sensor function problem",
			"Water in fuel sensor function problem",
			1414
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2266",
			"Fuel H2O detection sensor -Low",
			"Fuel H2O detection sensor -Low",
			1414
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2267",
			"Water in Fuel Sensor Circuit High",
			"Water in Fuel Sensor Circuit High",
			1414
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2268",
			"H2O in Fuel Sensor Circuit Intermittent",
			"H2O in Fuel Sensor Circuit Intermittent",
			1414
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2269",
			"Water in Fuel Condition",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2270",
			"O2 Sensor Signal Stuck Lean B1S2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2271",
			"O2 Sensor Signal Stuck Rich B1S2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2272",
			"O2 Sensor Signal Stuck Lean B2S2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2273",
			"O2 Sensor Signal Stuck Rich B2S2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2274",
			"O2 Sensor Signal Stuck Lean B1S3",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2275",
			"O2 Sensor Signal Stuck Rich B1S3",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2276",
			"O2 Sensor Signal Stuck Lean B2S3",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2277",
			"O2 Sensor Signal Stuck Rich B2S3",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2278",
			"O2S Signals Swapped B1S3 / B2S3",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2279",
			"Intake Air System Leak",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2280",
			"AirFlow Restr./AirFilter-MAF -Air Leak",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2281",
			"Air Leak \u00a0MAF - Throttle Body",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2282",
			"Air Leak Throttle Body - \u00a0Intake Valves",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2283",
			"Injector Control Pressure Sensor Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2284",
			"Inj. Ctrl Press. Sensor Circuit Range/Perf.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2285",
			"Injector Ctrl Pressure Sensor Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2286",
			"Injector Circuit Pressure Sensor Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2287",
			"Injector Ctrl Press. Sensor Circuit Interm.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2288",
			"Injector Control Pressure Too High",
			"Injector Control Pressure Too High",
			1166
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2289",
			"Inject. Ctrl Press. Too High-Engine Off",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2290",
			"Injector Control Pressure Too Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2291",
			"Inj. Ctrl Press. Too Low -Engine Crank",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2292",
			"Injector Control Pressure Erratic",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2293",
			"Fuel Press. Regulator 2 Performance",
			"Fuel Press. Regulator 2 Performance",
			1536
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2294",
			"Fuel Pressure Regulator 2 Control Circuit",
			"Fuel Pressure Regulator 2 Control Circuit",
			1166
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2295",
			"Fuel Press. Regulator 2 Control Circuit Low",
			"Fuel Press. Regulator 2 Control Circuit Low",
			1166
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2296",
			"Fuel Press. Regulator 2 Control Circuit High",
			"Fuel Press. Regulator 2 Control Circuit High",
			1262
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2297",
			"O2S Out of Range-Deceleration B1S1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2298",
			"O2S Out of Range-Deceleration B2S1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2299",
			"Brake Pedal Position/APP Incompatible",
			"Brake Pedal Position/APP Incompatible",
			1466
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2300",
			"Ignition Coil A Primary Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2301",
			"Ignition Coil A Primary Control Ctrl High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2302",
			"Ignition Coil A Secondary Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2303",
			"Ignition Coil B Primary Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2304",
			"Ignition Coil B Primary Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2305",
			"Ignition Coil B Secondary Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2306",
			"Ignition Coil C Primary Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2307",
			"Ignition Coil C Primary Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2308",
			"Ignition Coil C Secondary Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2309",
			"Ignition Coil D Primary Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2310",
			"Ignition Coil D Primary Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2311",
			"Ignition Coil D Secondary Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2312",
			"Ignition Coil E Primary Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2313",
			"Ignition Coil E Primary Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2314",
			"Ignition Coil E Secondary Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2315",
			"Ignition Coil F Primary Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2316",
			"Ignition Coil F Primary Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2317",
			"Ignition Coil F Secondary Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2318",
			"Ignition Coil G Primary Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2319",
			"Ignition Coil G Primary Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2320",
			"Ignition Coil G Secondary Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2321",
			"Ignition Coil H Primary Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2322",
			"Ignition Coil H Primary Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2323",
			"Ignition Coil H Secondary Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2324",
			"Ignition Coil I Primary Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2325",
			"Ignition Coil I Primary Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2326",
			"Ignition Coil I Secondary Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2327",
			"Ignition Coil J Primary Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2328",
			"Ignition Coil J Primary Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2329",
			"Ignition Coil J Secondary Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2330",
			"Ignition Coil K Primary Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2331",
			"Ignition Coil K Primary Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2332",
			"Ignition Coil K Secondary Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2333",
			"Ignition Coil L Primary Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2334",
			"Ignition Coil L Primary Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2335",
			"Ignition Coil L Secondary Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2336",
			"Cylinder 1 Above Knock Threshold",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2337",
			"Cylinder 2 Above Knock Threshold",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2338",
			"Cylinder 3 Above Knock Threshold",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2339",
			"Cylinder 3 Above Knock Threshold",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2340",
			"Cylinder 5 Above Knock Threshold",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2341",
			"Cylinder 6 Above Knock Threshold",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2342",
			"Cylinder 7 Above Knock Threshold",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2343",
			"Cylinder 8 Above Knock Threshold",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2344",
			"Cylinder 9 Above Knock Threshold",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2345",
			"Cylinder 11 Above Knock Threshold",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2346",
			"Cylinder 10 Above Knock Threshold",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2347",
			"Cylinder 12 Above Knock Threshold",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2400",
			"EVAP Leak Detect. Pump Ctrl Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2401",
			"EVAP Leak Detect. Pump Ctrl Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2402",
			"EVAP Leak Detect. Pump Ctrl Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2403",
			"EVAP Leak Detect.Pump Sense Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2404",
			"EVAP Leak Detect. Pump Sense Circuit R/P",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2405",
			"EVAP Leak Detect. Pump Sense Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2406",
			"EVAP Leak Detect. Pump Sense Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2407",
			"EVAP Leak Det. Pump Sense Circuit Int/Err.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2408",
			"Fuel Cap Sensor/Switch Circuit",
			"Fuel Cap Sensor/Switch Circuit",
			1323
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2409",
			"Fuel Cap Sens./Switch Circuit Range/Funct",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2410",
			"Fuel Cap Sensor/Switch Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2411",
			"Fuel Cap Sensor/Switch Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2412",
			"Fuel Cap Sens./Switch Circuit Interm/Err.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2413",
			"EGR Performance",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2414",
			"O2S Exhaust Sample Error B1S1",
			"O2S Exhaust Sample Error B1S1",
			1582
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2415",
			"O2S Exhaust Sample Error B2S1",
			"O2S Exhaust Sample Error B2S1",
			1675
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2416",
			"O2S Signals Swapped B1S2/B1S3",
			"O2S Signals Swapped B1S2/B1S3",
			1185
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2417",
			"O2S Signals Swapped B2S2/B2S3",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2418",
			"EVAP Switching Valve Ctrl Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2419",
			"EVAP Switching Valve Ctrl Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2420",
			"EVAP Switching Valve Ctrl Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2421",
			"EVAP Vent Valve Stuck Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2422",
			"EVAP Vent Valve Stuck Closed",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2423",
			"HC Adsorption Cat. Effic. Below limit B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2424",
			"HC Adsorption Cat. Effic. Below limit B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2425",
			"EGR Cooling Valve Control Circuit/Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2426",
			"EGR Cooling Valve Control Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2427",
			"EGR Cooling Valve Control Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2428",
			"Exhaust Gas Temperature Too High B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2429",
			"Exhaust Gas Temperature Too High B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2430",
			"SAS Air Flow/Pressure Sensor Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2431",
			"SAS Air Flow/Press. Sensor Circuit R/P B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2432",
			"SAS Air Flow/Press. Sensor Circuit Low B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2433",
			"SAS Air Flow/Press. Sensor Circuit High B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2434",
			"SAS Air Flow/Pr. Sensor Circuit Int/Err. B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2435",
			"SAS Air Flow/Press. Sensor Circuit B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2436",
			"SAS Air Flow/Press. Sensor Circuit R/P B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2437",
			"SAS Air Flow/Press. Sensor Circuit Low B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2438",
			"SAS Air Flow/Press. Sensor Circuit High B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2439",
			"SAS Air Flow/Pr. Sensor Circuit Int/Err. B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2440",
			"SAS Switching Valve Stuck Open B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2441",
			"SAS Switching Valve Stuck Closed B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2442",
			"SAS Switching Valve Stuck Open B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2443",
			"SAS Switching Valve Stuck Closed B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2444",
			"SAS Pump Stuck On B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2445",
			"SAS Pump Stuck Off B1",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2446",
			"SAS Pump Stuck On B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2447",
			"SAS Pump Stuck Off B2",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2500",
			"Generator Lamp/L-Terminal Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2501",
			"Generator Lamp/L-Terminal Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2502",
			"Charging System Voltage",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2503",
			"Charging System Voltage Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2504",
			"Charging System Voltage High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2505",
			"ECM/PCM Power Input Signal",
			"ECM/PCM Power Input Signal",
			1177
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2506",
			"ECM/PCM Pwr Input Signal Range/Perf.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2507",
			"ECM/PCM Power Input Signal Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2508",
			"ECM/PCM Power Input Signal High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2509",
			"ECM/PCM Pwr Input Signal Intermittent",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2510",
			"ECM/PCM Pwr Relay Sense Circuit R/Perf.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2511",
			"ECM/PCM Pwr Relay Sense Circuit Int.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2512",
			"Event Data Rec Request Circuit/ Open",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2513",
			"Event Data Rec Request Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2514",
			"Event Data Rec Request Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2515",
			"A/C Refrigerant Press. Sensor B Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2516",
			"A/C Press. sensor B/circuit function",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2517",
			"A/C Refrigerant Press. Sens. B Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2518",
			"A/C Refrigerant Press. Sens. B Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2519",
			"A/C Request A Circuit",
			"A/C Request A Circuit",
			1349
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2520",
			"A/C Request A Circuit Low",
			"A/C Request A Circuit Low",
			1349
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2521",
			"A/C Request A Circuit High",
			"A/C Request A Circuit High",
			1349
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2522",
			"A/C Request B Circuit",
			"A/C Request B Circuit",
			1349
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2523",
			"A/C Request B Circuit Low",
			"A/C Request B Circuit Low",
			1349
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2524",
			"A/C Request B Circuit High",
			"A/C Request B Circuit High",
			1349
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2525",
			"Vacuum Reservoir Press. Sensor Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2526",
			"VAC Reservoir Press. Sens. Circuit R/Perf.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2527",
			"VAC Reservoir Press. Sensor Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2528",
			"VAC Reservoir Press. Sensor Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2529",
			"VAC Reservoir Press. Sens. Circuit Interm.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2530",
			"Ignition Switch Run Position Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2531",
			"Ignition Switch Run Position Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2532",
			"Ignition Switch Run Position Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2533",
			"Ignition Switch Run/Start Position Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2534",
			"Ign. Switch Run/Start Position Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2535",
			"Ign. Switch Run/Start Position Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2536",
			"Ignition Switch Accessory Position Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2537",
			"Ignition Switch Accessory Pos. Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2538",
			"Ignition Switch Accessory Pos. Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2539",
			"Low Pressure Fuel Sys. Sensor Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2540",
			"Low Press. Fuel Sys S. Circuit Range/Perf.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2541",
			"Low Press. Fuel Sys Sensor Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2542",
			"Low Press. Fuel Sys Sensor Circuit High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2543",
			"Low Press. Fuel Sys Sensor Circuit Interm.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2544",
			"Torque Managem. Request Input Signal A",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2545",
			"Torq. Manag. Req. Input \u00a0A Range/Perf.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2546",
			"Torque Manag. Request Input \u00a0A -Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2547",
			"Torque Manag. Request Input \u00a0A -High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2548",
			"Torque Manag. Request Input Signal B",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2549",
			"Torq. Manag. Req. Input B Range/Perf.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2550",
			"Torque Manag. Request Input S. B Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2551",
			"Torque Manag. Request Input S. B High",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2552",
			"Throttle/Fuel Inhibit Circuit",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2553",
			"Throttle/Fuel Inhibit Circuit Range/Perf.",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2554",
			"Throttle/Fuel Inhibit Circuit Low",
			"No help available at present",
			0
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			"GEN",
			"2555",
			"Throttle/Fuel Inhibit Circuit High",
			"No help available at present",
			0
		});
	}

	// Token: 0x0400015E RID: 350
	public DataTable dataTable_0;
}
