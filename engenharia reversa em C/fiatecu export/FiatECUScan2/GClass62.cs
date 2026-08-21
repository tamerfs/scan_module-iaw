using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

// Token: 0x0200007F RID: 127
public static class GClass62
{
	// Token: 0x0600049F RID: 1183 RVA: 0x0008BCE8 File Offset: 0x00089EE8
	public static string smethod_0(string string_2, string string_3)
	{
		string text = GClass62.smethod_1(string_2);
		if (text == string.Empty)
		{
			text = string_3;
		}
		return text;
	}

	// Token: 0x060004A0 RID: 1184 RVA: 0x0008BD14 File Offset: 0x00089F14
	public static string smethod_1(string string_2)
	{
		string result;
		if (string_2 == string.Empty)
		{
			result = string.Empty;
		}
		else
		{
			string text = string.Empty;
			try
			{
				text = GClass62.sortedList_2[string_2];
			}
			catch (Exception)
			{
			}
			result = text;
		}
		return result;
	}

	// Token: 0x060004A1 RID: 1185 RVA: 0x0008BD64 File Offset: 0x00089F64
	public static string smethod_2(string string_2)
	{
		string result;
		if (string_2 == string.Empty)
		{
			result = string.Empty;
		}
		else
		{
			string text = string_2;
			try
			{
				text = GClass62.sortedList_3[string_2.ToLower()];
			}
			catch (Exception)
			{
			}
			result = text;
		}
		return result;
	}

	// Token: 0x060004A2 RID: 1186 RVA: 0x0008BDB4 File Offset: 0x00089FB4
	public static string smethod_3(int int_1)
	{
		return GClass62.smethod_4(int_1, string.Empty);
	}

	// Token: 0x060004A3 RID: 1187 RVA: 0x0008BDD0 File Offset: 0x00089FD0
	public static string smethod_4(int int_1, string string_2)
	{
		string result;
		if (int_1 == 0)
		{
			result = string.Empty;
		}
		else
		{
			string text = string_2;
			try
			{
				text = GClass62.sortedList_4[int_1];
			}
			catch (Exception)
			{
			}
			result = text;
		}
		return result;
	}

	// Token: 0x060004A4 RID: 1188 RVA: 0x0008BE14 File Offset: 0x0008A014
	public static string[] smethod_5()
	{
		List<string> list = new List<string>();
		foreach (string item in GClass62.sortedList_1.Keys)
		{
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x060004A5 RID: 1189 RVA: 0x0008BE78 File Offset: 0x0008A078
	public static string[] smethod_6()
	{
		List<string> list = new List<string>();
		foreach (string item in GClass62.sortedList_0.Keys)
		{
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x060004A6 RID: 1190 RVA: 0x0008BEDC File Offset: 0x0008A0DC
	public static void smethod_7()
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(GClass61.smethod_22() + "\\lang");
		FileInfo[] files = directoryInfo.GetFiles("*.txt");
		GClass62.sortedList_0.Clear();
		foreach (FileInfo fileInfo in files)
		{
			try
			{
				Stream stream = File.OpenRead(fileInfo.FullName);
				StreamReader streamReader = new StreamReader(stream);
				string text = string.Empty;
				while (!streamReader.EndOfStream)
				{
					string text2 = streamReader.ReadLine();
					if (text2 != null && text2.ToLower().StartsWith("title="))
					{
						text = text2.Substring(6);
						IL_9D:
						if (text != string.Empty && !GClass62.sortedList_0.ContainsKey(text))
						{
							GClass62.sortedList_0.Add(text, fileInfo.FullName);
						}
						streamReader.Close();
						goto IL_F2;
					}
				}
				goto IL_9D;
			}
			catch (Exception)
			{
				GClass3.smethod_2("ERROR: Loading of language file failed: " + fileInfo.FullName, 2);
			}
			IL_F2:;
		}
		directoryInfo = new DirectoryInfo(GClass61.smethod_22() + "\\lang");
		files = directoryInfo.GetFiles("*.dat");
		GClass62.sortedList_1.Clear();
		foreach (FileInfo fileInfo in files)
		{
			try
			{
				Stream stream = File.OpenRead(fileInfo.FullName);
				StreamReader streamReader = new StreamReader(stream);
				string text = string.Empty;
				while (!streamReader.EndOfStream)
				{
					string text2 = streamReader.ReadLine();
					if (text2 != null && text2.ToLower().StartsWith("title="))
					{
						text = text2.Substring(6);
						IL_198:
						if (text != string.Empty && !GClass62.sortedList_1.ContainsKey(text))
						{
							GClass62.sortedList_1.Add(text, fileInfo.FullName);
						}
						streamReader.Close();
						goto IL_1ED;
					}
				}
				goto IL_198;
			}
			catch (Exception)
			{
				GClass3.smethod_2("ERROR: Loading of language file failed: " + fileInfo.FullName, 2);
			}
			IL_1ED:;
		}
	}

	// Token: 0x060004A7 RID: 1191 RVA: 0x0008C0FC File Offset: 0x0008A2FC
	public static void smethod_8(string string_2, string string_3)
	{
		GClass62.Class15 @class = new GClass62.Class15();
		@class.string_0 = string_3;
		Thread thread = new Thread(new ThreadStart(@class.method_0));
		thread.Start();
		Thread thread2 = new Thread(new ThreadStart(@class.method_1));
		thread2.Start();
		GClass62.smethod_9(string_2);
	}

	// Token: 0x060004A8 RID: 1192 RVA: 0x0008C14C File Offset: 0x0008A34C
	public static void smethod_9(string string_2)
	{
		if (!GClass62.sortedList_0.ContainsKey(string_2))
		{
			GClass3.smethod_2("ERROR: Language file not found!", 2);
			try
			{
				string_2 = GClass62.sortedList_0.Keys[0];
				if (GClass62.sortedList_0.ContainsKey("English"))
				{
					string_2 = "English";
				}
			}
			catch (Exception ex)
			{
				GClass3.smethod_2("ERROR: LANG FILE LOAD - " + ex.Message, 0);
			}
		}
		try
		{
			Stream stream = File.OpenRead(GClass62.sortedList_0[string_2]);
			StreamReader streamReader = new StreamReader(stream);
			GClass62.sortedList_2.Clear();
			while (!streamReader.EndOfStream)
			{
				string text = streamReader.ReadLine();
				if (text != null)
				{
					int num = text.IndexOf("=");
					if (num > 0 && num + 1 < text.Length)
					{
						string key = text.Substring(0, num);
						string value = text.Substring(num + 1);
						GClass62.sortedList_2.Add(key, value);
					}
				}
			}
			streamReader.Close();
		}
		catch (Exception value2)
		{
			Console.WriteLine(value2);
		}
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x0008C278 File Offset: 0x0008A478
	private static void smethod_10(string string_2, int int_1)
	{
		string text = GClass62.smethod_3(int_1);
		if (text.Length > 0)
		{
			GClass62.sortedList_3.Add(string_2.ToLower(), text);
		}
	}

	// Token: 0x060004AA RID: 1194 RVA: 0x0008C2AC File Offset: 0x0008A4AC
	private static void smethod_11(string string_2)
	{
		GClass62.sortedList_3.Clear();
		GClass62.smethod_10("1st eng. error", 2342);
		GClass62.smethod_10("1st-2nd sel. error", 2339);
		GClass62.smethod_10("2nd eng. error", 2343);
		GClass62.smethod_10("3rd eng. error", 2344);
		GClass62.smethod_10("3rd-4th sel. error", 2341);
		GClass62.smethod_10("4th eng. error", 2345);
		GClass62.smethod_10("5th eng. error", 2346);
		GClass62.smethod_10("5th sel. error", 2212);
		GClass62.smethod_10("5th-6th sel. error", 3170);
		GClass62.smethod_10("5th-R sel. error", 2340);
		GClass62.smethod_10("6th eng. error", 2290);
		GClass62.smethod_10("Absent", 2240);
		GClass62.smethod_10("Acc. Pot. Track 1", 1546);
		GClass62.smethod_10("Acc. Pot. Track 2", 1214);
		GClass62.smethod_10("Accel. Command (button +)", 1859);
		GClass62.smethod_10("Accelerator pedal", 1336);
		GClass62.smethod_10("Activated", 2189);
		GClass62.smethod_10("Active", 2199);
		GClass62.smethod_10("Adjustable (acc)", 2312);
		GClass62.smethod_10("Air control ON", 2302);
		GClass62.smethod_10("Allowed", 2216);
		GClass62.smethod_10("Atm. pressure low", 2305);
		GClass62.smethod_10("AUTO", 2330);
		GClass62.smethod_10("Autom. gearbox", 3435);
		GClass62.smethod_10("Autom./City request", 2315);
		GClass62.smethod_10("Automatic", 2247);
		GClass62.smethod_10("Awaiting Validation", 2201);
		GClass62.smethod_10("Backwards", 2274);
		GClass62.smethod_10("Bat. voltage low", 2307);
		GClass62.smethod_10("Battery Disconnect Error", 2195);
		GClass62.smethod_10("Boost pressure", 2331);
		GClass62.smethod_10("Both tracks faulty", 2301);
		GClass62.smethod_10("Bottom limit", 2223);
		GClass62.smethod_10("Brake pedal switch", 1196);
		GClass62.smethod_10("Broken filter", 2357);
		GClass62.smethod_10("C-CAN", 2478);
		GClass62.smethod_10("City", 2272);
		GClass62.smethod_10("Class 1", 2287);
		GClass62.smethod_10("Class 2", 2288);
		GClass62.smethod_10("Class 3", 2289);
		GClass62.smethod_10("Closed", 2229);
		GClass62.smethod_10("Closed loop", 2328);
		GClass62.smethod_10("Closed loop error", 2356);
		GClass62.smethod_10("Closing", 3437);
		GClass62.smethod_10("Clutch stroke insufficient", 2214);
		GClass62.smethod_10("Clutch switch", 1562);
		GClass62.smethod_10("Clutch valve error", 2351);
		GClass62.smethod_10("Cold", 2221);
		GClass62.smethod_10("Cold start", 2310);
		GClass62.smethod_10("Completed", 2363);
		GClass62.smethod_10("Consumption", 2184);
		GClass62.smethod_10("Correct", 2232);
		GClass62.smethod_10("Counter reset", 2291);
		GClass62.smethod_10("Cruise control", 1220);
		GClass62.smethod_10("Cruise Restore(button RCL)", 1858);
		GClass62.smethod_10("Cut off state", 1748);
		GClass62.smethod_10("Deactivated", 2218);
		GClass62.smethod_10("Decel. Command (button -)", 1860);
		GClass62.smethod_10("Diagnostic Mode", 2252);
		GClass62.smethod_10("Disabled", 2202);
		GClass62.smethod_10("DONE", 2215);
		GClass62.smethod_10("Driver", 2027);
		GClass62.smethod_10("Driver+Passenger", 2254);
		GClass62.smethod_10("Early closing", 3985);
		GClass62.smethod_10("ECU Request", 2311);
		GClass62.smethod_10("Enabled", 2237);
		GClass62.smethod_10("Eng. posit. error", 1645);
		GClass62.smethod_10("Eng. positioning error", 1645);
		GClass62.smethod_10("Engine OFF", 2354);
		GClass62.smethod_10("Error", 2263);
		GClass62.smethod_10("Error due to absence of suitable conditions", 2349);
		GClass62.smethod_10("Error due to clutch closed", 2348);
		GClass62.smethod_10("Error on switch", 2338);
		GClass62.smethod_10("Excessive advance", 3930);
		GClass62.smethod_10("Excessive fuel", 2309);
		GClass62.smethod_10("Facing backwards", 2204);
		GClass62.smethod_10("Facing forward", 2203);
		GClass62.smethod_10("Failed", 2362);
		GClass62.smethod_10("Fastened", 2206);
		GClass62.smethod_10("Faulty", 2250);
		GClass62.smethod_10("Faulty sensor", 2583);
		GClass62.smethod_10("Faulty system", 2194);
		GClass62.smethod_10("Fifth", 2265);
		GClass62.smethod_10("Filter clogged", 2358);
		GClass62.smethod_10("First", 2241);
		GClass62.smethod_10("First/Reverse", 2584);
		GClass62.smethod_10("Fixed", 2313);
		GClass62.smethod_10("Flashing", 2266);
		GClass62.smethod_10("Forwards", 2275);
		GClass62.smethod_10("Fourth", 2244);
		GClass62.smethod_10("Full load", 2647);
		GClass62.smethod_10("Full power", 2226);
		GClass62.smethod_10("Full Throttle", 2226);
		GClass62.smethod_10("Full-lift", 3986);
		GClass62.smethod_10("Fully pressed", 2226);
		GClass62.smethod_10("Gear change", 2303);
		GClass62.smethod_10("Gearbox", 3436);
		GClass62.smethod_10("Gearchange in progress", 2208);
		GClass62.smethod_10("Generic error", 2336);
		GClass62.smethod_10("High", 2782);
		GClass62.smethod_10("High Speed", 2183);
		GClass62.smethod_10("Idle", 2224);
		GClass62.smethod_10("Idle too lean", 2360);
		GClass62.smethod_10("Idle too rich", 2359);
		GClass62.smethod_10("In motion", 2179);
		GClass62.smethod_10("In progress", 2231);
		GClass62.smethod_10("In progress (1)", 2264);
		GClass62.smethod_10("In progress (10)", 2264);
		GClass62.smethod_10("In progress (11)", 2264);
		GClass62.smethod_10("In progress (2)", 2264);
		GClass62.smethod_10("In progress (3)", 2264);
		GClass62.smethod_10("In progress (4)", 2264);
		GClass62.smethod_10("In progress (5)", 2264);
		GClass62.smethod_10("In progress (6)", 2264);
		GClass62.smethod_10("In progress (7)", 2264);
		GClass62.smethod_10("In progress (8)", 2264);
		GClass62.smethod_10("In progress (9)", 2264);
		GClass62.smethod_10("Incorrect", 2227);
		GClass62.smethod_10("Incorrect conditions", 2934);
		GClass62.smethod_10("Initialization", 2193);
		GClass62.smethod_10("Invalid", 2209);
		GClass62.smethod_10("Key on stop", 2355);
		GClass62.smethod_10("km Travelled", 2367);
		GClass62.smethod_10("Late opening", 3983);
		GClass62.smethod_10("Lean", 2220);
		GClass62.smethod_10("Lean Semi-Closed Loop", 2181);
		GClass62.smethod_10("Learning", 2286);
		GClass62.smethod_10("Learnt", 2270);
		GClass62.smethod_10("Less Important Error", 2210);
		GClass62.smethod_10("Lever backwards", 2274);
		GClass62.smethod_10("Lever forwards", 2275);
		GClass62.smethod_10("Long", 2279);
		GClass62.smethod_10("Loose pin error", 2281);
		GClass62.smethod_10("Low", 2196);
		GClass62.smethod_10("Low Speed", 2182);
		GClass62.smethod_10("Manual", 2248);
		GClass62.smethod_10("MAR", 2217);
		GClass62.smethod_10("Medium", 2246);
		GClass62.smethod_10("MIL Light ON", 2200);
		GClass62.smethod_10("Mixed", 3988);
		GClass62.smethod_10("Multilift", 3984);
		GClass62.smethod_10("N eng. error", 2213);
		GClass62.smethod_10("N/R sel. error", 2211);
		GClass62.smethod_10("Neutral", 2239);
		GClass62.smethod_10("Neutral req. from lever", 2276);
		GClass62.smethod_10("NO", 2365);
		GClass62.smethod_10("No error", 2278);
		GClass62.smethod_10("No Errors", 2334);
		GClass62.smethod_10("No Gearchange", 2207);
		GClass62.smethod_10("No lift", 3987);
		GClass62.smethod_10("No Request", 2273);
		GClass62.smethod_10("No signal", 4120);
		GClass62.smethod_10("None/Neutral", 2269);
		GClass62.smethod_10("Normal", 2175);
		GClass62.smethod_10("Normal clogging", 2320);
		GClass62.smethod_10("Not active", 2198);
		GClass62.smethod_10("Not allowed", 2219);
		GClass62.smethod_10("Not available", 2267);
		GClass62.smethod_10("Not clogged", 2319);
		GClass62.smethod_10("Not correct", 2249);
		GClass62.smethod_10("Not enabled", 2238);
		GClass62.smethod_10("Not fastened", 2205);
		GClass62.smethod_10("Not feasible", 2335);
		GClass62.smethod_10("Not learnt", 2271);
		GClass62.smethod_10("Not OK", 2352);
		GClass62.smethod_10("Not performed", 2253);
		GClass62.smethod_10("Not plausible", 2335);
		GClass62.smethod_10("Not present", 2236);
		GClass62.smethod_10("Not programmed", 2188);
		GClass62.smethod_10("Not received", 2190);
		GClass62.smethod_10("Not recharging", 2285);
		GClass62.smethod_10("Not requested", 2174);
		GClass62.smethod_10("Not significant", 2582);
		GClass62.smethod_10("Not started", 2258);
		GClass62.smethod_10("Not synchronized", 2326);
		GClass62.smethod_10("Not valid", 2256);
		GClass62.smethod_10("OFF", 2186);
		GClass62.smethod_10("Off, faults present", 2283);
		GClass62.smethod_10("Off, no faults", 2282);
		GClass62.smethod_10("OK", 2261);
		GClass62.smethod_10("ON", 2185);
		GClass62.smethod_10("On, no faults", 2284);
		GClass62.smethod_10("ON/OFF", 2586);
		GClass62.smethod_10("Open", 2228);
		GClass62.smethod_10("Open circuit", 4118);
		GClass62.smethod_10("Open loop", 2327);
		GClass62.smethod_10("Open loop error", 2329);
		GClass62.smethod_10("Out of idle", 2225);
		GClass62.smethod_10("Out of limits", 2257);
		GClass62.smethod_10("Out of range", 2353);
		GClass62.smethod_10("Overload", 3502);
		GClass62.smethod_10("Parking", 2234);
		GClass62.smethod_10("Part. filter temp. low", 3212);
		GClass62.smethod_10("Passed", 2260);
		GClass62.smethod_10("Performed", 2230);
		GClass62.smethod_10("Phase incorrect", 2249);
		GClass62.smethod_10("Plunger adjustment error", 2350);
		GClass62.smethod_10("Possible", 2649);
		GClass62.smethod_10("Present", 2235);
		GClass62.smethod_10("Press. Sensor Fault", 2318);
		GClass62.smethod_10("Pressed", 2233);
		GClass62.smethod_10("Pressure on pipe", 2297);
		GClass62.smethod_10("Programmed", 2262);
		GClass62.smethod_10("Prolonged idle", 2304);
		GClass62.smethod_10("PWM", 2585);
		GClass62.smethod_10("R eng. error", 2347);
		GClass62.smethod_10("Received", 2191);
		GClass62.smethod_10("Recharging", 2187);
		GClass62.smethod_10("Recognized", 2648);
		GClass62.smethod_10("Regenerat. interrupted", 2322);
		GClass62.smethod_10("Regenerat. not completed", 2323);
		GClass62.smethod_10("Relay error", 2317);
		GClass62.smethod_10("Released", 2176);
		GClass62.smethod_10("Requested", 2173);
		GClass62.smethod_10("Results OK", 2361);
		GClass62.smethod_10("Reverse", 2180);
		GClass62.smethod_10("Reverse req. from lever", 2277);
		GClass62.smethod_10("Rich", 2197);
		GClass62.smethod_10("rpm expected", 2293);
		GClass62.smethod_10("rpm sensor", 1395);
		GClass62.smethod_10("rpm/phase expected", 2292);
		GClass62.smethod_10("Running", 2251);
		GClass62.smethod_10("S.C. to +V", 4123);
		GClass62.smethod_10("S.C. to ground", 4124);
		GClass62.smethod_10("Second", 2242);
		GClass62.smethod_10("Selespeed", 2245);
		GClass62.smethod_10("Semi-Closed Loop", 2177);
		GClass62.smethod_10("Serial line", 2376);
		GClass62.smethod_10("Short", 2280);
		GClass62.smethod_10("Signal not valid", 4121);
		GClass62.smethod_10("Signal too high", 4119);
		GClass62.smethod_10("Signal too low", 4122);
		GClass62.smethod_10("Sixth", 1304);
		GClass62.smethod_10("Slipping", 3438);
		GClass62.smethod_10("Stalled", 2178);
		GClass62.smethod_10("Standstill", 2234);
		GClass62.smethod_10("Start-up status", 2172);
		GClass62.smethod_10("Startups", 2316);
		GClass62.smethod_10("Stop", 2364);
		GClass62.smethod_10("Stored", 2255);
		GClass62.smethod_10("Sync. check", 2294);
		GClass62.smethod_10("Synchronized", 2325);
		GClass62.smethod_10("Synchronized engine", 2296);
		GClass62.smethod_10("System lean", 1285);
		GClass62.smethod_10("System rich", 1463);
		GClass62.smethod_10("Tank Full", 2324);
		GClass62.smethod_10("Terminated", 2259);
		GClass62.smethod_10("Third", 2243);
		GClass62.smethod_10("Timing sensor faut", 2295);
		GClass62.smethod_10("To be regenerated", 2321);
		GClass62.smethod_10("Too high", 2333);
		GClass62.smethod_10("Too low", 2332);
		GClass62.smethod_10("Top Limit", 2222);
		GClass62.smethod_10("Track 1 OK", 2298);
		GClass62.smethod_10("Track1 faulty, Track2 OK", 2299);
		GClass62.smethod_10("Track2 faulty", 2300);
		GClass62.smethod_10("Transition to lean", 3982);
		GClass62.smethod_10("Transition to rich", 3981);
		GClass62.smethod_10("Unclassified", 2268);
		GClass62.smethod_10("Unused", 2337);
		GClass62.smethod_10("Valid", 2192);
		GClass62.smethod_10("Variable", 2314);
		GClass62.smethod_10("Vehicle speed", 1766);
		GClass62.smethod_10("Water temp. high", 2308);
		GClass62.smethod_10("Water temp. low", 2306);
		GClass62.smethod_10("with DPF", 2587);
		GClass62.smethod_10("with DPF and Lambda sensor", 2589);
		GClass62.smethod_10("with Lambda sensor", 2588);
		GClass62.smethod_10("without DPF and Lambda sensor", 2590);
		GClass62.smethod_10("Worn", 2477);
		GClass62.smethod_10("Yes", 2366);
	}

	// Token: 0x060004AB RID: 1195 RVA: 0x0008D2A4 File Offset: 0x0008B4A4
	private static void smethod_12(string string_2)
	{
		if (!GClass62.sortedList_1.ContainsKey(string_2))
		{
			GClass3.smethod_2("ERROR: Language file not found!", 2);
			if (GClass62.sortedList_1.ContainsKey("English"))
			{
				string_2 = "English";
			}
			else
			{
				string_2 = GClass62.sortedList_0.Keys[0];
			}
		}
		if (string_2 == "English" || !GClass3.bool_3)
		{
			GClass62.sortedList_4.Clear();
		}
		else
		{
			try
			{
				Stream stream = File.OpenRead(GClass62.sortedList_1[string_2]);
				StreamReader streamReader = new StreamReader(stream);
				GClass62.sortedList_4.Clear();
				while (!streamReader.EndOfStream)
				{
					string text = streamReader.ReadLine();
					if (text != null && text.IndexOf("=") > 0)
					{
						string value = text.Substring(0, text.IndexOf("="));
						string value2 = text.Substring(text.IndexOf("=") + 1);
						try
						{
							GClass62.sortedList_4.Add(Convert.ToInt32(value), value2);
						}
						catch (Exception)
						{
						}
					}
				}
				streamReader.Close();
			}
			catch (Exception value3)
			{
				Console.WriteLine(value3);
			}
		}
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x0008D3DC File Offset: 0x0008B5DC
	public static string smethod_13(string string_2, string string_3)
	{
		string_2 = string_2.Replace("-", string.Empty);
		byte[] array = GClass16.smethod_2(string_2);
		for (int i = 0; i < array.Length; i++)
		{
			byte[] array2 = array;
			int num = i;
			array2[num] ^= 49;
			byte[] array3 = array;
			int num2 = i;
			array3[num2] ^= 27;
		}
		string_2 = GClass16.smethod_1(array).Replace(" ", string.Empty);
		if (string_2.Length < 16)
		{
			string_2 += "30383936363339323634393236344141";
		}
		string_2 = string_2.Substring(0, 16);
		byte[] array4 = GClass16.smethod_2(string_2);
		byte[] array5 = new byte[array4.Length];
		for (int i = 0; i < array4.Length; i++)
		{
			array5[i] = array4[array4.Length - i - 1];
		}
		Random random = new Random();
		int int_ = random.Next(0, 987);
		string text = GClass62.smethod_20("1234567890", int_);
		byte[] bytes = Encoding.ASCII.GetBytes(text + text);
		byte[] array6 = new byte[6];
		for (int i = 0; i < array6.Length; i++)
		{
			array6[i] = bytes[i];
			byte[] array7 = array6;
			int num3 = i;
			array7[num3] ^= array5[i];
		}
		string text2 = GClass16.smethod_1(array6).Replace(" ", string.Empty);
		return string.Concat(new string[]
		{
			text2.Substring(0, 4),
			"-",
			text2.Substring(4, 3),
			"-",
			text2.Substring(7)
		});
	}

	// Token: 0x060004AD RID: 1197 RVA: 0x0008D584 File Offset: 0x0008B784
	private static void smethod_14(string string_2)
	{
		int num = 0;
		int num2 = 0;
		GClass62.sortedList_4.Clear();
		for (int i = 1; i < GClass62.string_0.Length; i++)
		{
			if (GClass62.string_0[i].ToLower() == string_2.ToLower())
			{
				num = i;
				IL_42:
				for (int j = 0; j < GClass16.smethod_10().Length; j++)
				{
					if (GClass16.smethod_10()[j].StartsWith("lang"))
					{
						num2++;
					}
					if (num2 != 0 && (num2 != 2 || num2 > 3) && num2 == 3 && !GClass16.smethod_10()[j].StartsWith("lang0"))
					{
						FileStream fileStream = new FileStream(GClass61.smethod_22() + "\\Files\\" + GClass16.smethod_10()[j] + ".dat", FileMode.Open, FileAccess.Read);
						byte[] array = new byte[5];
						while (fileStream.Position < fileStream.Length)
						{
							fileStream.Read(array, 0, array.Length);
							byte[] array2 = array;
							int num3 = 4;
							array2[num3] ^= array[1];
							byte[] array3 = array;
							int num4 = 1;
							array3[num4] ^= array[3];
							byte[] array4 = array;
							int num5 = 3;
							array4[num5] ^= array[1];
							byte[] array5 = array;
							int num6 = 3;
							array5[num6] ^= array[0];
							int num7 = (int)array[1] + 256 * (int)array[4];
							int key = (int)array[2] + 256 * (int)array[0];
							byte b = array[3];
							byte[] array6 = new byte[num7];
							fileStream.Read(array6, 0, array6.Length);
							if (num == (int)b && GClass3.bool_3)
							{
								array6 = GClass66.smethod_0(array6);
								GClass62.sortedList_4.Add(key, Encoding.Unicode.GetString(array6));
							}
						}
						fileStream.Close();
					}
				}
				return;
			}
		}
		goto IL_42;
	}

	// Token: 0x060004AE RID: 1198 RVA: 0x0008D760 File Offset: 0x0008B960
	public static string smethod_15(string string_2, string string_3)
	{
		string text = string.Empty;
		int num = 0;
		int num2 = 1;
		while (num2 < GClass62.string_0.Length && !(GClass62.string_0[num2].ToLower() == string_2.ToLower()))
		{
			num2++;
		}
		for (int i = 0; i < GClass16.smethod_10().Length; i++)
		{
			if (GClass16.smethod_10()[i].StartsWith("lang"))
			{
				num++;
			}
			else
			{
				FileStream fileStream = new FileStream(GClass61.smethod_22() + "\\Files\\" + GClass16.smethod_10()[i] + ".dat", FileMode.Open, FileAccess.Read);
				fileStream.Close();
			}
			if (num != 0 && (num != 1 || num > 4) && num == 2 && !GClass16.smethod_10()[i].StartsWith("lang0") && GClass16.smethod_10()[i] == GClass16.smethod_8())
			{
				FileStream fileStream = new FileStream(GClass61.smethod_22() + "\\Files\\" + GClass16.smethod_10()[i] + ".dat", FileMode.Open, FileAccess.Read);
				int num3 = 0;
				byte[] array = new byte[4];
				while (fileStream.Position < fileStream.Length)
				{
					fileStream.Read(array, 0, array.Length);
					byte[] array2 = array;
					int num4 = 1;
					array2[num4] ^= array[2];
					byte[] array3 = array;
					int num5 = 3;
					array3[num5] ^= array[1];
					byte[] array4 = array;
					int num6 = 3;
					array4[num6] ^= array[0];
					int num7 = (int)array[1] + 256 * (int)array[3];
					if (num3 > 1000)
					{
						break;
					}
					num3++;
					byte[] array5 = new byte[num7];
					fileStream.Read(array5, 0, array5.Length);
					array5 = GClass66.smethod_0(array5);
					text = GClass16.smethod_1(array5).Replace(" ", string.Empty);
					if (text.StartsWith(string_3))
					{
						break;
					}
				}
				fileStream.Close();
			}
		}
		return text;
	}

	// Token: 0x060004AF RID: 1199 RVA: 0x0008D95C File Offset: 0x0008BB5C
	private static string smethod_16(byte[] byte_1)
	{
		if (!GClass3.bool_8)
		{
			GClass62.byte_0 = 0;
		}
		for (int i = 0; i < byte_1.Length; i++)
		{
			if (i < 11)
			{
				GClass62.byte_0 += byte_1[i];
			}
			else if (GClass62.byte_0 != byte_1[i])
			{
				throw new Exception(GClass62.string_1);
			}
		}
		return GClass16.smethod_1(byte_1).Substring(0, GClass62.int_0);
	}

	// Token: 0x060004B0 RID: 1200 RVA: 0x0008D9D0 File Offset: 0x0008BBD0
	public static string smethod_17(string string_2, string string_3)
	{
		string text = string.Empty;
		int num = 3;
		byte[] array = new byte[12];
		long offset = (long)array.Length;
		GClass3.smethod_2("LENC1", 0);
		int num2 = 1;
		while (num2 < GClass62.string_0.Length && !(GClass62.string_0[num2].ToLower() == string_2.ToLower()))
		{
			num2++;
		}
		num++;
		offset = 5400L;
		byte[] byte_ = GClass16.smethod_2(string_3);
		string text2 = GClass16.smethod_1(byte_);
		GClass62.byte_0 = (byte)(num - 4);
		if (num != 0 && (num != 1 || num > 4) && num == 4)
		{
			FileStream fileStream = new FileStream(GClass61.smethod_22() + "\\Files\\" + GClass16.smethod_10()[num] + ".dat", FileMode.Open, FileAccess.Read);
			long length = fileStream.Length;
			fileStream.Seek(offset, SeekOrigin.Begin);
			string a = string.Empty;
			while (fileStream.Position < length)
			{
				fileStream.Read(array, 0, array.Length);
				a = GClass62.smethod_16(array);
				if (a == text2)
				{
					text = text2;
				}
			}
			fileStream.Close();
		}
		text = text.Replace(" ", string.Empty);
		text = text.Replace("M", "N");
		GClass3.smethod_2("LENC2", 0);
		GClass3.bool_2 = (!(text == string.Empty) && GClass3.bool_2);
		return text.Replace("Z", "T");
	}

	// Token: 0x060004B1 RID: 1201 RVA: 0x000037F9 File Offset: 0x000019F9
	public static bool smethod_18(string string_2, string string_3, bool bool_0)
	{
		GClass61.smethod_5();
		GClass61.smethod_9();
		return bool_0 ? string_3.StartsWith(string_3) : (string_3 == string_3);
	}

	// Token: 0x060004B2 RID: 1202 RVA: 0x0008DB48 File Offset: 0x0008BD48
	public static string smethod_19(string string_2, string string_3)
	{
		if (string_2.Length < 16)
		{
			string_2 += "30383936363339323634393236344141";
		}
		string_2 = string_2.Substring(0, 16);
		byte[] array = GClass16.smethod_2(string_2);
		byte[] array2 = new byte[array.Length];
		int i;
		for (i = 0; i < array2.Length; i++)
		{
			array2[i] = array[array.Length - i - 1];
		}
		byte[] array3 = GClass16.smethod_2("6A606A197B056117");
		if (GClass61.smethod_69(8).Name == "Black")
		{
			array3 = GClass16.smethod_2("2B796A291B256457");
		}
		if (string_3.Length == 18 && string_3[5] == '-' && string_3[11] == '-' && GClass61.smethod_7().Length == 0)
		{
			try
			{
				string_3 = string_3.Replace("-", string.Empty);
				if (array3[0] == 106)
				{
					array3 = GClass16.smethod_2(string_3);
				}
			}
			catch (Exception)
			{
			}
		}
		i = 0;
		while (i < array2.Length && i < array3.Length)
		{
			byte[] array4 = array2;
			int num = i;
			array4[num] ^= array3[i];
			i++;
		}
		string @string = Encoding.ASCII.GetString(array2);
		int length = @string.Length;
		return GClass16.smethod_1(array2).Replace(" ", string.Empty);
	}

	// Token: 0x060004B3 RID: 1203 RVA: 0x0008DCB0 File Offset: 0x0008BEB0
	public static string smethod_20(string string_2, int int_1)
	{
		string text = string.Empty;
		int num = 0;
		for (int i = 0; i < GClass16.smethod_10().Length; i++)
		{
			if (GClass16.smethod_10()[i].StartsWith("lang"))
			{
				num++;
			}
			else
			{
				FileStream fileStream = new FileStream(GClass61.smethod_22() + "\\Files\\" + GClass16.smethod_10()[i] + ".dat", FileMode.Open, FileAccess.Read);
				fileStream.Close();
			}
			int num2 = 0;
			if (num != 0 && (num != 1 || num > 4) && num == 2 && !GClass16.smethod_10()[i].StartsWith("lang0") && GClass16.smethod_10()[i] == GClass16.smethod_8())
			{
				FileStream fileStream = new FileStream(GClass61.smethod_22() + "\\Files\\" + GClass16.smethod_10()[i] + ".dat", FileMode.Open, FileAccess.Read);
				int num3 = 0;
				byte[] array = new byte[4];
				while (fileStream.Position < fileStream.Length)
				{
					fileStream.Read(array, 0, array.Length);
					byte[] array2 = array;
					int num4 = 1;
					array2[num4] ^= array[2];
					byte[] array3 = array;
					int num5 = 3;
					array3[num5] ^= array[1];
					byte[] array4 = array;
					int num6 = 3;
					array4[num6] ^= array[0];
					int num7 = (int)array[1] + 256 * (int)array[3];
					if (num3 > 1000)
					{
						break;
					}
					num3++;
					byte[] array5 = new byte[num7];
					fileStream.Read(array5, 0, array5.Length);
					array5 = GClass66.smethod_0(array5);
					if (int_1 > 0 && int_1 < 1000)
					{
						text = Encoding.ASCII.GetString(array5);
					}
					else
					{
						text = GClass16.smethod_1(array5).Replace(" ", string.Empty);
					}
					if (int_1 == num2 || text.StartsWith(string_2))
					{
						break;
					}
					num2++;
				}
				fileStream.Close();
			}
		}
		return text;
	}

	// Token: 0x0400062E RID: 1582
	private static SortedList<string, string> sortedList_0 = new SortedList<string, string>();

	// Token: 0x0400062F RID: 1583
	private static SortedList<string, string> sortedList_1 = new SortedList<string, string>();

	// Token: 0x04000630 RID: 1584
	private static SortedList<string, string> sortedList_2 = new SortedList<string, string>();

	// Token: 0x04000631 RID: 1585
	private static SortedList<string, string> sortedList_3 = new SortedList<string, string>();

	// Token: 0x04000632 RID: 1586
	private static SortedList<int, string> sortedList_4 = new SortedList<int, string>();

	// Token: 0x04000633 RID: 1587
	private static string[] string_0 = new string[]
	{
		"English",
		"Français",
		"Deutsch",
		"Русский",
		"Polski",
		"Magyar",
		"Český",
		"Español",
		"Italiano",
		"Български"
	};

	// Token: 0x04000634 RID: 1588
	private static byte byte_0 = 0;

	// Token: 0x04000635 RID: 1589
	private static int int_0 = 32;

	// Token: 0x04000636 RID: 1590
	private static string string_1 = "CS failed";

	// Token: 0x02000080 RID: 128
	private sealed class Class15
	{
		// Token: 0x060004B5 RID: 1205 RVA: 0x00003832 File Offset: 0x00001A32
		public void method_0()
		{
			GClass62.smethod_12(this.string_0);
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0000383F File Offset: 0x00001A3F
		public void method_1()
		{
			GClass62.smethod_11(this.string_0);
		}

		// Token: 0x04000637 RID: 1591
		public string string_0;
	}
}
