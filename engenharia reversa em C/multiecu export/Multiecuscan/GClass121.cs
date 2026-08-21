using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

// Token: 0x020000C1 RID: 193
public static class GClass121
{
	// Token: 0x0600066E RID: 1646 RVA: 0x000E37B0 File Offset: 0x000E19B0
	public static void smethod_0(string string_4)
	{
		if (!GClass121.sortedList_0.ContainsKey(string_4))
		{
			GClass126.smethod_2("ERROR: Language file not found!", 2);
			try
			{
				string_4 = GClass121.sortedList_0.Keys[0];
				if (GClass121.sortedList_0.ContainsKey("English"))
				{
					string_4 = "English";
				}
			}
			catch (Exception ex)
			{
				GClass126.smethod_2("ERROR: LANG FILE LOAD - " + ex.Message, 0);
			}
		}
		try
		{
			StreamReader streamReader = new StreamReader(File.OpenRead(GClass121.sortedList_0[string_4]));
			GClass121.sortedList_2.Clear();
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
						GClass121.sortedList_2.Add(key, value);
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

	// Token: 0x0600066F RID: 1647 RVA: 0x000E38BC File Offset: 0x000E1ABC
	private static void smethod_1(string string_4)
	{
		if (!GClass121.sortedList_1.ContainsKey(string_4))
		{
			GClass126.smethod_2("ERROR: Language file not found!", 2);
			if (GClass121.sortedList_1.ContainsKey("English"))
			{
				string_4 = "English";
			}
			else
			{
				string_4 = GClass121.sortedList_0.Keys[0];
			}
		}
		if (!(string_4 == "English") && GClass126.bool_13)
		{
			GClass121.sortedList_3.Clear();
			try
			{
				StreamReader streamReader = new StreamReader(File.OpenRead(GClass121.sortedList_1[string_4]));
				GClass121.sortedList_4.Clear();
				while (!streamReader.EndOfStream)
				{
					string text = streamReader.ReadLine();
					if (text != null && text.IndexOf("=") > 0)
					{
						string value = text.Substring(0, text.IndexOf("="));
						string value2 = text.Substring(text.IndexOf("=") + 1);
						try
						{
							if (Convert.ToInt32(value) < 40000)
							{
								GClass121.sortedList_4.Add(Convert.ToInt32(value), value2);
							}
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
			if (string_4 == "Polski" || string_4 == "Deutsch" || string_4 == "Türkçe" || string_4 == "Český" || string_4 == "Français" || string_4 == "Italiano")
			{
				GClass121.smethod_13(string_4);
			}
			GClass121.smethod_3(string_4);
			return;
		}
		GClass121.sortedList_4.Clear();
	}

	// Token: 0x06000670 RID: 1648 RVA: 0x00004610 File Offset: 0x00002810
	public static string smethod_2(string string_4, string string_5)
	{
		bool flag = GClass125.smethod_84();
		if (flag)
		{
			GClass126.string_12 = GClass126.string_10;
		}
		if (!flag)
		{
			return string_4;
		}
		return string_5;
	}

	// Token: 0x06000671 RID: 1649 RVA: 0x000E3A50 File Offset: 0x000E1C50
	private static void smethod_3(string string_4)
	{
		GClass121.sortedList_3.Clear();
		GClass121.smethod_18("1st engagement error", 18001);
		GClass121.smethod_18("1st-2nd selection error", 18002);
		GClass121.smethod_18("1st-3rd selection error", 18003);
		GClass121.smethod_18("2nd engagement error", 18004);
		GClass121.smethod_18("2nd-4th selection error", 18005);
		GClass121.smethod_18("3rd engagement error", 18006);
		GClass121.smethod_18("3rd-4th selection error", 18007);
		GClass121.smethod_18("4th engagement error", 18008);
		GClass121.smethod_18("5th engagement error", 18009);
		GClass121.smethod_18("5th selection error", 18010);
		GClass121.smethod_18("5th-6th selection error", 18011);
		GClass121.smethod_18("5th-R selection error", 18012);
		GClass121.smethod_18("6th engagement error", 18013);
		GClass121.smethod_18("6th selection error", 18014);
		GClass121.smethod_18("Abort", 18015);
		GClass121.smethod_18("Absent", 18016);
		GClass121.smethod_18("Track 1", 18017);
		GClass121.smethod_18("Track 2", 18018);
		GClass121.smethod_18("Acceleration (button +)", 18019);
		GClass121.smethod_18("Accelerator pedal", 18020);
		GClass121.smethod_18("Activated", 18021);
		GClass121.smethod_18("Active", 18022);
		GClass121.smethod_18("Adaptive", 18023);
		GClass121.smethod_18("Adaptive cruise control (ACC)", 18024);
		GClass121.smethod_18("Air control ON", 18025);
		GClass121.smethod_18("Alarm", 18026);
		GClass121.smethod_18("Allowed", 18027);
		GClass121.smethod_18("Anomolous speed variation", 18028);
		GClass121.smethod_18("Atm. pressure low", 18029);
		GClass121.smethod_18("AUTO", 18030);
		GClass121.smethod_18("Autom. gearbox", 18031);
		GClass121.smethod_18("Autom./City request", 18032);
		GClass121.smethod_18("Automatic", 18033);
		GClass121.smethod_18("Awaiting Validation", 18034);
		GClass121.smethod_18("Backwards", 18035);
		GClass121.smethod_18("Bat. voltage low", 18036);
		GClass121.smethod_18("Battery Disconnect Error", 18037);
		GClass121.smethod_18("Bi-Level", 18038);
		GClass121.smethod_18("Bi-Level / Floor Mode Midpoint", 18039);
		GClass121.smethod_18("Bi-Level Mode", 18040);
		GClass121.smethod_18("Bi-Level/Floor Midpoint", 18041);
		GClass121.smethod_18("Bilevel", 18042);
		GClass121.smethod_18("Bilevel/Feet Midpoint", 18043);
		GClass121.smethod_18("Boost pressure", 18044);
		GClass121.smethod_18("Both tracks faulty", 18045);
		GClass121.smethod_18("Bottom limit", 18046);
		GClass121.smethod_18("Brake pedal in use", 18047);
		GClass121.smethod_18("Brake pedal switch", 18048);
		GClass121.smethod_18("Brakes are not on", 18049);
		GClass121.smethod_18("Broken filter", 18050);
		GClass121.smethod_18("C-CAN", 18051);
		GClass121.smethod_18("City", 18052);
		GClass121.smethod_18("Class 1", 18053);
		GClass121.smethod_18("Class 2", 18054);
		GClass121.smethod_18("Class 3", 18055);
		GClass121.smethod_18("Closed", 18056);
		GClass121.smethod_18("Closed loop", 18057);
		GClass121.smethod_18("Closed loop error", 18058);
		GClass121.smethod_18("Closing", 18059);
		GClass121.smethod_18("Clutch closed position error (odd gears)", 18060);
		GClass121.smethod_18("Clutch open position error (even gears)", 18061);
		GClass121.smethod_18("Clutch open position error (odd gears)", 18062);
		GClass121.smethod_18("Clutch pedal in use", 18063);
		GClass121.smethod_18("Clutch stroke insufficient", 18064);
		GClass121.smethod_18("Clutch switch", 18065);
		GClass121.smethod_18("Clutch valve error", 18066);
		GClass121.smethod_18("Cold", 18067);
		GClass121.smethod_18("Cold start", 18068);
		GClass121.smethod_18("Completed", 18069);
		GClass121.smethod_18("Completed correctly", 18070);
		GClass121.smethod_18("Consumption", 18071);
		GClass121.smethod_18("Coolant temperature out of range", 18072);
		GClass121.smethod_18("Correct", 18073);
		GClass121.smethod_18("Counter reset", 18074);
		GClass121.smethod_18("Cruise control", 18075);
		GClass121.smethod_18("Cruise excessive acceleration", 18076);
		GClass121.smethod_18("Cruise excessive deceleration", 18077);
		GClass121.smethod_18("Cruise not detected in EEPROM", 18078);
		GClass121.smethod_18("Cruise request not valid", 18079);
		GClass121.smethod_18("Restore (button RCL/RES)", 18080);
		GClass121.smethod_18("Cut off state", 18081);
		GClass121.smethod_18("Deactivated", 18082);
		GClass121.smethod_18("Deceleration (button -)", 18083);
		GClass121.smethod_18("Default", 18084);
		GClass121.smethod_18("Defrost", 18085);
		GClass121.smethod_18("Diagnostic Mode", 18086);
		GClass121.smethod_18("Disabled", 18087);
		GClass121.smethod_18("Disabled key, this transponder is in the list of disabled keys and cannot be learned anymore", 18088);
		GClass121.smethod_18("DONE", 18089);
		GClass121.smethod_18("Door lock", 18090);
		GClass121.smethod_18("DPF with integrated precat.", 18091);
		GClass121.smethod_18("Driver", 18092);
		GClass121.smethod_18("Driver+Passenger", 18093);
		GClass121.smethod_18("DDCT", 18094);
		GClass121.smethod_18("Early closing", 18095);
		GClass121.smethod_18("ECU Request", 18096);
		GClass121.smethod_18("EGR learning system fault", 18097);
		GClass121.smethod_18("EGR position sensor", 18098);
		GClass121.smethod_18("EGR valve", 18099);
		GClass121.smethod_18("EGR valve blocked", 18100);
		GClass121.smethod_18("EGR valve control", 18101);
		GClass121.smethod_18("Enabled", 18102);
		GClass121.smethod_18("Engagement positioning error", 18104);
		GClass121.smethod_18("Engine OFF", 18105);
		GClass121.smethod_18("Engine running", 18106);
		GClass121.smethod_18("Engine speed high", 18107);
		GClass121.smethod_18("Engine speed out of permitted range", 18108);
		GClass121.smethod_18("Engine speed outside minimum condition", 18109);
		GClass121.smethod_18("Engine speed too low", 18110);
		GClass121.smethod_18("Engine temp. sensor fault", 18111);
		GClass121.smethod_18("Error", 18112);
		GClass121.smethod_18("Error due to absence of suitable conditions", 18113);
		GClass121.smethod_18("Error due to clutch closed", 18114);
		GClass121.smethod_18("Error on switch", 18115);
		GClass121.smethod_18("Errors present", 18116);
		GClass121.smethod_18("Excessive advance", 18117);
		GClass121.smethod_18("Excessive fuel", 18118);
		GClass121.smethod_18("Excessive vehicle speed", 18119);
		GClass121.smethod_18("Face", 18120);
		GClass121.smethod_18("Face/Bilevel Midpoint", 18121);
		GClass121.smethod_18("Facing backwards", 18122);
		GClass121.smethod_18("Facing forward", 18123);
		GClass121.smethod_18("Failed", 18124);
		GClass121.smethod_18("Failed - AX out of range", 18125);
		GClass121.smethod_18("Failed - AY out of range", 18126);
		GClass121.smethod_18("Failed - Internal fault", 18127);
		GClass121.smethod_18("Failed - Vehicle is not standstill", 18128);
		GClass121.smethod_18("Failed - YAW error", 18129);
		GClass121.smethod_18("Failed, Battery flat", 18130);
		GClass121.smethod_18("Failed, Corrupted RF data", 18131);
		GClass121.smethod_18("Failed, Key already learned", 18132);
		GClass121.smethod_18("Failed, Key table full", 18133);
		GClass121.smethod_18("Failed, No transponder detected", 18134);
		GClass121.smethod_18("Failed, Remote control already learned", 18135);
		GClass121.smethod_18("Failed, Remote control already stored", 18136);
		GClass121.smethod_18("Failed, Remote control battery flat", 18137);
		GClass121.smethod_18("Failed, Remote control button not pressed correctly, battery flat or remote control faulty", 18138);
		GClass121.smethod_18("Failed, Remote control not valid for this vehicle", 18139);
		GClass121.smethod_18("Failed: Front distribution actuator", 18140);
		GClass121.smethod_18("Failed: Left mixing actuator", 18141);
		GClass121.smethod_18("Failed: Rear distribution/mixing actuators", 18142);
		GClass121.smethod_18("Failed: Recirculation actuator", 18143);
		GClass121.smethod_18("Failed: Right mixing actuator", 18144);
		GClass121.smethod_18("Failed: Timeout", 18145);
		GClass121.smethod_18("Failure in feedback line or OC in command line", 18146);
		GClass121.smethod_18("Fan", 18147);
		GClass121.smethod_18("Fastened", 18148);
		GClass121.smethod_18("Faults are Present", 18149);
		GClass121.smethod_18("Faulty", 18150);
		GClass121.smethod_18("Faulty sensor", 18151);
		GClass121.smethod_18("Faulty system", 18152);
		GClass121.smethod_18("Feet", 18153);
		GClass121.smethod_18("Fifth", 18154);
		GClass121.smethod_18("Filter clogged", 18155);
		GClass121.smethod_18("First", 18156);
		GClass121.smethod_18("First/Reverse", 18157);
		GClass121.smethod_18("Fixed", 18158);
		GClass121.smethod_18("Flashing", 18159);
		GClass121.smethod_18("Flashing (flywheel self learn)", 18160);
		GClass121.smethod_18("Flashing (misfire)", 18161);
		GClass121.smethod_18("Floor", 18162);
		GClass121.smethod_18("Floor Mode", 18163);
		GClass121.smethod_18("Floor/Mix Midpoint", 18164);
		GClass121.smethod_18("Floor/Trilevel Midpoint", 18165);
		GClass121.smethod_18("Forwards", 18166);
		GClass121.smethod_18("Fourth", 18167);
		GClass121.smethod_18("Fresh air", 18168);
		GClass121.smethod_18("Front", 18169);
		GClass121.smethod_18("Front+Rear", 18170);
		GClass121.smethod_18("Full load", 18171);
		GClass121.smethod_18("Full power", 18172);
		GClass121.smethod_18("Full-lift", 18174);
		GClass121.smethod_18("Fully pressed", 18175);
		GClass121.smethod_18("Gear change", 18176);
		GClass121.smethod_18("Gearbox", 18177);
		GClass121.smethod_18("Gearchange in progress", 18178);
		GClass121.smethod_18("Generic error", 18179);
		GClass121.smethod_18("Glow plug 1", 18180);
		GClass121.smethod_18("Glow plug 2", 18181);
		GClass121.smethod_18("Glow plug 3", 18182);
		GClass121.smethod_18("Glow plug 4", 18183);
		GClass121.smethod_18("Glow plug 5", 18184);
		GClass121.smethod_18("High", 18185);
		GClass121.smethod_18("High pollution", 18186);
		GClass121.smethod_18("High speed", 18187);
		GClass121.smethod_18("High temperature", 18188);
		GClass121.smethod_18("High throttle angle", 18189);
		GClass121.smethod_18("Hilevel", 18190);
		GClass121.smethod_18("Hot", 18191);
		GClass121.smethod_18("Idle", 18192);
		GClass121.smethod_18("Idle too lean", 18193);
		GClass121.smethod_18("Idle too rich", 18194);
		GClass121.smethod_18("In motion", 18195);
		GClass121.smethod_18("In progress", 18196);
		GClass121.smethod_18("In progress (1)", 18197);
		GClass121.smethod_18("In progress (10)", 18198);
		GClass121.smethod_18("In progress (11)", 18199);
		GClass121.smethod_18("In progress (2)", 18200);
		GClass121.smethod_18("In progress (3)", 18201);
		GClass121.smethod_18("In progress (4)", 18202);
		GClass121.smethod_18("In progress (5)", 18203);
		GClass121.smethod_18("In progress (6)", 18204);
		GClass121.smethod_18("In progress (7)", 18205);
		GClass121.smethod_18("In progress (8)", 18206);
		GClass121.smethod_18("In progress (9)", 18207);
		GClass121.smethod_18("Incorrect", 18208);
		GClass121.smethod_18("Incorrect conditions", 18209);
		GClass121.smethod_18("Incorrect gear", 18210);
		GClass121.smethod_18("Initialization", 18211);
		GClass121.smethod_18("Injected quantities out of permitted ranges", 18212);
		GClass121.smethod_18("Injector fault", 18213);
		GClass121.smethod_18("Inserted, blocked", 18214);
		GClass121.smethod_18("Inserted, released", 18215);
		GClass121.smethod_18("Inserted, switch error", 18216);
		GClass121.smethod_18("Invalid", 18217);
		GClass121.smethod_18("Key authentication failed, transponder not valid for this vehicle", 18218);
		GClass121.smethod_18("Key on stop", 18219);
		GClass121.smethod_18("Key turned to Stop or Start/Stop button pressed", 18220);
		GClass121.smethod_18("km Travelled", 18221);
		GClass121.smethod_18("Late opening", 18222);
		GClass121.smethod_18("Lean", 18223);
		GClass121.smethod_18("Lean fail", 18224);
		GClass121.smethod_18("Lean Semi-Closed Loop", 18225);
		GClass121.smethod_18("Learning", 18226);
		GClass121.smethod_18("Learned", 18227);
		GClass121.smethod_18("Left", 18228);
		GClass121.smethod_18("Less Important Error", 18229);
		GClass121.smethod_18("Lever backwards", 18230);
		GClass121.smethod_18("Lever forwards", 18231);
		GClass121.smethod_18("Lever position OFF", 18232);
		GClass121.smethod_18("Long", 18233);
		GClass121.smethod_18("Loose pin error", 18234);
		GClass121.smethod_18("Low", 18235);
		GClass121.smethod_18("Low engine RPM", 18236);
		GClass121.smethod_18("Low pollution", 18237);
		GClass121.smethod_18("Low speed", 18238);
		GClass121.smethod_18("Low transmission oil temp", 18239);
		GClass121.smethod_18("Manual", 18240);
		GClass121.smethod_18("MAR", 18241);
		GClass121.smethod_18("Medium", 18242);
		GClass121.smethod_18("MIL Light ON", 18243);
		GClass121.smethod_18("Mix", 18244);
		GClass121.smethod_18("Mix/Defrost Midpoint", 18245);
		GClass121.smethod_18("Mixed", 18246);
		GClass121.smethod_18("Multilift", 18247);
		GClass121.smethod_18("N engagement error", 18248);
		GClass121.smethod_18("N/R selection error", 18249);
		GClass121.smethod_18("Neutral", 18250);
		GClass121.smethod_18("Neutral req. from lever", 18251);
		GClass121.smethod_18("NO", 18252);
		GClass121.smethod_18("No error", 18253);
		GClass121.smethod_18("No errors", 18254);
		GClass121.smethod_18("No gearchange", 18255);
		GClass121.smethod_18("No lift", 18256);
		GClass121.smethod_18("No position sensor", 18257);
		GClass121.smethod_18("No request", 18258);
		GClass121.smethod_18("No signal", 18259);
		GClass121.smethod_18("None/Neutral", 18260);
		GClass121.smethod_18("Normal", 18261);
		GClass121.smethod_18("Normal clogging", 18262);
		GClass121.smethod_18("Not active", 18263);
		GClass121.smethod_18("Not allowed", 18264);
		GClass121.smethod_18("Not available", 18265);
		GClass121.smethod_18("Not clogged", 18266);
		GClass121.smethod_18("Not configured", 18267);
		GClass121.smethod_18("Not correct", 18268);
		GClass121.smethod_18("Not defined", 18269);
		GClass121.smethod_18("Not enabled", 18270);
		GClass121.smethod_18("Not fastened", 18271);
		GClass121.smethod_18("Not feasible", 18272);
		GClass121.smethod_18("Not inserted or error", 18273);
		GClass121.smethod_18("Not learned", 18274);
		GClass121.smethod_18("Not OK", 18275);
		GClass121.smethod_18("Not performed", 18276);
		GClass121.smethod_18("Not plausible", 18277);
		GClass121.smethod_18("Not present", 18278);
		GClass121.smethod_18("Not programmed", 18279);
		GClass121.smethod_18("Not received", 18280);
		GClass121.smethod_18("Not recharging", 18281);
		GClass121.smethod_18("Not requested", 18282);
		GClass121.smethod_18("Not significant", 18283);
		GClass121.smethod_18("Not started", 18284);
		GClass121.smethod_18("Not synchronized", 18285);
		GClass121.smethod_18("Not valid", 18286);
		GClass121.smethod_18("OFF", 18287);
		GClass121.smethod_18("Off, faults present", 18288);
		GClass121.smethod_18("Off, no faults", 18289);
		GClass121.smethod_18("Oil switch fault", 18290);
		GClass121.smethod_18("OK", 18291);
		GClass121.smethod_18("OK, Key 1 learned", 18292);
		GClass121.smethod_18("OK, Key 2 learned", 18293);
		GClass121.smethod_18("OK, Key 3 learned", 18294);
		GClass121.smethod_18("OK, Key 4 learned", 18295);
		GClass121.smethod_18("OK, Key 5 learned", 18296);
		GClass121.smethod_18("OK, Key 6 learned", 18297);
		GClass121.smethod_18("OK, Key 7 learned", 18298);
		GClass121.smethod_18("OK, Key 8 learned", 18299);
		GClass121.smethod_18("OK, Remote control 1 learned", 18300);
		GClass121.smethod_18("OK, Remote control 2 learned", 18301);
		GClass121.smethod_18("OK, Remote control 3 learned", 18302);
		GClass121.smethod_18("OK, Remote control 4 learned", 18303);
		GClass121.smethod_18("OK, Remote control 5 learned", 18304);
		GClass121.smethod_18("OK, Remote control 6 learned", 18305);
		GClass121.smethod_18("OK, Remote control 7 learned", 18306);
		GClass121.smethod_18("OK, Remote control 8 learned", 18307);
		GClass121.smethod_18("OK, RF Key 1 learned", 18308);
		GClass121.smethod_18("OK, RF Key 2 learned", 18309);
		GClass121.smethod_18("OK, RF Key 3 learned", 18310);
		GClass121.smethod_18("OK, RF Key 4 learned", 18311);
		GClass121.smethod_18("OK, RF Key 5 learned", 18312);
		GClass121.smethod_18("OK, RF Key 6 learned", 18313);
		GClass121.smethod_18("OK, RF Key 7 learned", 18314);
		GClass121.smethod_18("OK, RF Key 8 learned", 18315);
		GClass121.smethod_18("OK, Stored 1 key", 18316);
		GClass121.smethod_18("OK, Stored 1 remote control", 18317);
		GClass121.smethod_18("OK, Stored 2 keys", 18318);
		GClass121.smethod_18("OK, Stored 2 remote controls", 18319);
		GClass121.smethod_18("OK, Stored 3 keys", 18320);
		GClass121.smethod_18("OK, Stored 3 remote controls", 18321);
		GClass121.smethod_18("OK, Stored 4 keys", 18322);
		GClass121.smethod_18("OK, Stored 4 remote controls", 18323);
		GClass121.smethod_18("OK, Stored 5 keys", 18324);
		GClass121.smethod_18("OK, Stored 5 remote controls", 18325);
		GClass121.smethod_18("OK, Stored 6 keys", 18326);
		GClass121.smethod_18("OK, Stored 6 remote controls", 18327);
		GClass121.smethod_18("OK, Stored 7 keys", 18328);
		GClass121.smethod_18("OK, Stored 7 remote controls", 18329);
		GClass121.smethod_18("OK, Stored 8 keys", 18330);
		GClass121.smethod_18("OK, Stored 8 remote controls", 18331);
		GClass121.smethod_18("ON", 18332);
		GClass121.smethod_18("On, no faults", 18333);
		GClass121.smethod_18("ON/OFF", 18334);
		GClass121.smethod_18("Open", 18335);
		GClass121.smethod_18("Open circuit", 18336);
		GClass121.smethod_18("Open loop", 18337);
		GClass121.smethod_18("Open loop error", 18338);
		GClass121.smethod_18("Opening", 18339);
		GClass121.smethod_18("Out of idle", 18340);
		GClass121.smethod_18("Out of limits", 18341);
		GClass121.smethod_18("Out of range", 18342);
		GClass121.smethod_18("Overload", 18343);
		GClass121.smethod_18("Paddle+", 18344);
		GClass121.smethod_18("Paddle-", 18345);
		GClass121.smethod_18("Panel", 18346);
		GClass121.smethod_18("Panel / Bi-Level Mode Midpoint", 18347);
		GClass121.smethod_18("Panel Mode", 18348);
		GClass121.smethod_18("Panel/Bi-Level Midpoint", 18349);
		GClass121.smethod_18("Parking", 18350);
		GClass121.smethod_18("Part. filter temp. low", 18351);
		GClass121.smethod_18("Particulate filter temperature not reached", 18352);
		GClass121.smethod_18("Particulate filter temperature too high", 18353);
		GClass121.smethod_18("Passed", 18354);
		GClass121.smethod_18("Performance limitation active", 18355);
		GClass121.smethod_18("Performed", 18356);
		GClass121.smethod_18("Phase incorrect", 18357);
		GClass121.smethod_18("Phase sensor fault", 18358);
		GClass121.smethod_18("Plunger adjustment error", 18359);
		GClass121.smethod_18("Possible", 18360);
		GClass121.smethod_18("Power supply", 18361);
		GClass121.smethod_18("Pre-synchronized", 18362);
		GClass121.smethod_18("Precatalyser temperature too high", 18363);
		GClass121.smethod_18("Preheating control unit", 18364);
		GClass121.smethod_18("Present", 18365);
		GClass121.smethod_18("Pressure sensor faulty", 18366);
		GClass121.smethod_18("Pressed", 18367);
		GClass121.smethod_18("Pressure on pipe", 18368);
		GClass121.smethod_18("Programmed", 18369);
		GClass121.smethod_18("Prolonged idle", 18370);
		GClass121.smethod_18("PWM", 18371);
		GClass121.smethod_18("Quick Learn Procedure is complete", 18372);
		GClass121.smethod_18("Quick Learn Procedure is in progress", 18373);
		GClass121.smethod_18("R engagement error", 18374);
		GClass121.smethod_18("Rear", 18375);
		GClass121.smethod_18("Received", 18376);
		GClass121.smethod_18("Recharging", 18377);
		GClass121.smethod_18("Recirculation", 18378);
		GClass121.smethod_18("Recognized", 18379);
		GClass121.smethod_18("Regenerat. interrupted", 18380);
		GClass121.smethod_18("Regenerat. not completed", 18381);
		GClass121.smethod_18("Relay error", 18382);
		GClass121.smethod_18("Released", 18383);
		GClass121.smethod_18("Requested", 18384);
		GClass121.smethod_18("Results OK", 18385);
		GClass121.smethod_18("Reverse", 18386);
		GClass121.smethod_18("Reverse req. from lever", 18387);
		GClass121.smethod_18("Rich", 18388);
		GClass121.smethod_18("Rich fail", 18389);
		GClass121.smethod_18("Right", 18390);
		GClass121.smethod_18("Risk of engine overheating", 18391);
		GClass121.smethod_18("rpm expected", 18392);
		GClass121.smethod_18("rpm sensor", 18393);
		GClass121.smethod_18("RPM sensor fault", 18394);
		GClass121.smethod_18("rpm/phase expected", 18395);
		GClass121.smethod_18("Running", 18396);
		GClass121.smethod_18("S.C. to +V", 18397);
		GClass121.smethod_18("S.C. to ground", 18398);
		GClass121.smethod_18("SC to Ground", 18399);
		GClass121.smethod_18("SC to V+", 18400);
		GClass121.smethod_18("Second", 18401);
		GClass121.smethod_18("Selection actuator error", 18402);
		GClass121.smethod_18("Selespeed", 18403);
		GClass121.smethod_18("Semi-Closed Loop", 18404);
		GClass121.smethod_18("Serial line", 18405);
		GClass121.smethod_18("SET and RESUME activated simultaneously", 18406);
		GClass121.smethod_18("Shift Lever is not in N", 18407);
		GClass121.smethod_18("Shift Lever moved out of OD", 18408);
		GClass121.smethod_18("Short", 18409);
		GClass121.smethod_18("Signal not valid", 18410);
		GClass121.smethod_18("Signal too high", 18411);
		GClass121.smethod_18("Signal too low", 18412);
		GClass121.smethod_18("Sixth", 18413);
		GClass121.smethod_18("Slipping", 18414);
		GClass121.smethod_18("Speed out of limit", 18415);
		GClass121.smethod_18("Stalled", 18416);
		GClass121.smethod_18("Standard", 18417);
		GClass121.smethod_18("Standstill", 18418);
		GClass121.smethod_18("Start Sequence signal (move Shift Lever to OD)", 18419);
		GClass121.smethod_18("Start-up status", 18420);
		GClass121.smethod_18("Startup", 18421);
		GClass121.smethod_18("Startups", 18422);
		GClass121.smethod_18("Steering wheel effort", 18423);
		GClass121.smethod_18("Stop", 18424);
		GClass121.smethod_18("Stop command received from instrument", 18425);
		GClass121.smethod_18("Stored", 18426);
		GClass121.smethod_18("Sync. check", 18427);
		GClass121.smethod_18("Synchronized", 18428);
		GClass121.smethod_18("Synchronized engine", 18429);
		GClass121.smethod_18("System lean", 18430);
		GClass121.smethod_18("System rich", 18431);
		GClass121.smethod_18("Tank Full", 18432);
		GClass121.smethod_18("Terminated", 18433);
		GClass121.smethod_18("Third", 18434);
		GClass121.smethod_18("Throttle", 18435);
		GClass121.smethod_18("Throttle position sensor", 18436);
		GClass121.smethod_18("Throttle valve blocked", 18437);
		GClass121.smethod_18("Throttle valve control", 18438);
		GClass121.smethod_18("Timeout", 18439);
		GClass121.smethod_18("Timing sensor faut", 18440);
		GClass121.smethod_18("To be regenerated", 18441);
		GClass121.smethod_18("Too high", 18442);
		GClass121.smethod_18("Too low", 18443);
		GClass121.smethod_18("Top Limit", 18444);
		GClass121.smethod_18("Track 1 OK", 18445);
		GClass121.smethod_18("Track 1 faulty, Track 2 OK", 18446);
		GClass121.smethod_18("Track 2 faulty", 18447);
		GClass121.smethod_18("Transition to lean", 18448);
		GClass121.smethod_18("Transition to rich", 18449);
		GClass121.smethod_18("Transmission oil temp too hot", 18450);
		GClass121.smethod_18("Trilevel", 18451);
		GClass121.smethod_18("Trilevel/Windscreen Midpoint", 18452);
		GClass121.smethod_18("Turbo pressure", 18453);
		GClass121.smethod_18("Unclassified", 18454);
		GClass121.smethod_18("UNIAir module fault", 18455);
		GClass121.smethod_18("UNIAir oil temp. sensor fault", 18456);
		GClass121.smethod_18("Unknown", 18457);
		GClass121.smethod_18("Unused", 18458);
		GClass121.smethod_18("Valid", 18459);
		GClass121.smethod_18("Var. slope", 18460);
		GClass121.smethod_18("Variable", 18461);
		GClass121.smethod_18("Vehicle deceleration too slow", 18462);
		GClass121.smethod_18("Vehicle speed", 18463);
		GClass121.smethod_18("Vehicle speed low", 18464);
		GClass121.smethod_18("Vehicle speed measured", 18465);
		GClass121.smethod_18("Virgin", 18466);
		GClass121.smethod_18("Wait", 18467);
		GClass121.smethod_18("Wait RPM stable", 18468);
		GClass121.smethod_18("Waiting", 18469);
		GClass121.smethod_18("Waiting for synchronization", 18470);
		GClass121.smethod_18("Water temp. high", 18471);
		GClass121.smethod_18("Water temp. low", 18472);
		GClass121.smethod_18("Wheel speed sensors", 18473);
		GClass121.smethod_18("Windscreen", 18474);
		GClass121.smethod_18("Windscreen/feet", 18475);
		GClass121.smethod_18("with DPF", 18476);
		GClass121.smethod_18("with DPF and integrated precatalyser", 18477);
		GClass121.smethod_18("with DPF and Lambda sensor", 18478);
		GClass121.smethod_18("with DPF and separate precatalyser", 18479);
		GClass121.smethod_18("with Lambda sensor", 18480);
		GClass121.smethod_18("without DPF and Lambda sensor", 18481);
		GClass121.smethod_18("Worn", 18482);
		GClass121.smethod_18("Yes", 18483);
		GClass121.smethod_18("Front left wheel error", 18484);
		GClass121.smethod_18("Front right wheel error", 18485);
		GClass121.smethod_18("Rear left wheel error", 18486);
		GClass121.smethod_18("Rear right wheel error", 18487);
		GClass121.smethod_18("Activate", 18488);
		GClass121.smethod_18("Deactivate", 18489);
		GClass121.smethod_18("Apply", 18490);
		GClass121.smethod_18("Release", 18491);
		GClass121.smethod_18("Flashing (neutral learn)", 18492);
		GClass121.smethod_18("Flashing (power limitation)", 18493);
		GClass121.smethod_18("Flashing (UniAir self learn)", 18494);
	}

	// Token: 0x06000672 RID: 1650 RVA: 0x000E573C File Offset: 0x000E393C
	public static string smethod_4(string string_4, string string_5)
	{
		string text = GClass121.smethod_6(string_4);
		if (text == "")
		{
			text = string_5;
		}
		return text;
	}

	// Token: 0x06000673 RID: 1651 RVA: 0x000E5760 File Offset: 0x000E3960
	public static string[] smethod_5()
	{
		List<string> list = new List<string>();
		foreach (string item in GClass121.sortedList_1.Keys)
		{
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x06000674 RID: 1652 RVA: 0x000E57C0 File Offset: 0x000E39C0
	public static string smethod_6(string string_4)
	{
		if (string_4 == "")
		{
			return "";
		}
		string result = "";
		try
		{
			result = GClass121.sortedList_2[string_4];
		}
		catch (Exception)
		{
		}
		return result;
	}

	// Token: 0x06000675 RID: 1653 RVA: 0x000E5808 File Offset: 0x000E3A08
	public static void smethod_7()
	{
		FileInfo[] files = new DirectoryInfo(GClass125.smethod_30() + "\\lang").GetFiles("*.txt");
		GClass121.sortedList_0.Clear();
		foreach (FileInfo fileInfo in files)
		{
			try
			{
				StreamReader streamReader = new StreamReader(File.OpenRead(fileInfo.FullName));
				string text = "";
				while (!streamReader.EndOfStream)
				{
					string text2 = streamReader.ReadLine();
					if (text2 != null && text2.ToLower().StartsWith("title="))
					{
						text = text2.Substring(6);
						IL_84:
						if (text != "" && !GClass121.sortedList_0.ContainsKey(text))
						{
							GClass121.sortedList_0.Add(text, fileInfo.FullName);
						}
						streamReader.Close();
						goto IL_D3;
					}
				}
				goto IL_84;
			}
			catch (Exception)
			{
				GClass126.smethod_2("ERROR: Loading of language file failed: " + fileInfo.FullName, 2);
			}
			IL_D3:;
		}
		GClass123.int_3 = (int)new FileInfo(GClass125.smethod_30() + "\\" + GClass122.smethod_25().Replace("nabl", "x")).Length;
		GClass123.int_4 = GClass123.int_3;
		FileInfo[] files2 = new DirectoryInfo(GClass125.smethod_30() + "\\lang").GetFiles("*.dat");
		GClass121.sortedList_1.Clear();
		foreach (FileInfo fileInfo2 in files2)
		{
			try
			{
				StreamReader streamReader2 = new StreamReader(File.OpenRead(fileInfo2.FullName));
				string text = "";
				while (!streamReader2.EndOfStream)
				{
					string text2 = streamReader2.ReadLine();
					if (text2 != null && text2.ToLower().StartsWith("title="))
					{
						text = text2.Substring(6);
						IL_19D:
						if (text != "" && !GClass121.sortedList_1.ContainsKey(text))
						{
							GClass121.sortedList_1.Add(text, fileInfo2.FullName);
						}
						streamReader2.Close();
						goto IL_1EC;
					}
				}
				goto IL_19D;
			}
			catch (Exception)
			{
				GClass126.smethod_2("ERROR: Loading of language file failed: " + fileInfo2.FullName, 2);
			}
			IL_1EC:;
		}
		GClass126.smethod_2("LOAD DATA: Len0: " + GClass123.int_4.ToString(), 0);
	}

	// Token: 0x06000676 RID: 1654 RVA: 0x00004629 File Offset: 0x00002829
	public static string smethod_8(int int_1)
	{
		return GClass121.smethod_20(int_1, "");
	}

	// Token: 0x06000677 RID: 1655 RVA: 0x000E5A40 File Offset: 0x000E3C40
	public static string[] smethod_9()
	{
		List<string> list = new List<string>();
		foreach (string item in GClass121.sortedList_0.Keys)
		{
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x06000678 RID: 1656 RVA: 0x000E5AA0 File Offset: 0x000E3CA0
	public static string smethod_10(string string_4, string string_5)
	{
		string_4 = string_4.Replace("-", "");
		byte[] array = GClass127.smethod_32(string_4);
		for (int i = 0; i < array.Length; i++)
		{
			byte[] array2 = array;
			int num = i;
			array2[num] ^= 49;
			byte[] array3 = array;
			int num2 = i;
			array3[num2] ^= GClass121.byte_1[1];
		}
		string_4 = GClass127.smethod_11(array).Replace(" ", "");
		if (string_4.Length < 16)
		{
			string_4 += "30383936363339323634393236344141";
		}
		string_4 = string_4.Substring(0, 16);
		byte[] array4 = GClass127.smethod_32(string_4);
		byte[] array5 = new byte[array4.Length];
		for (int j = 0; j < array4.Length; j++)
		{
			array5[j] = array4[array4.Length - j - 1];
		}
		int int_ = new Random().Next(0, 987);
		string text = GClass121.smethod_22("1234567890", int_);
		byte[] bytes = Encoding.ASCII.GetBytes(text + text);
		byte[] array6 = new byte[6];
		for (int k = 0; k < array6.Length; k++)
		{
			array6[k] = bytes[k];
			byte[] array7 = array6;
			int num3 = k;
			array7[num3] ^= array5[k];
		}
		string text2 = GClass127.smethod_11(array6).Replace(" ", "");
		return string.Concat(new string[]
		{
			text2.Substring(0, 4),
			"-",
			text2.Substring(4, 3),
			"-",
			text2.Substring(7)
		});
	}

	// Token: 0x06000679 RID: 1657 RVA: 0x00004636 File Offset: 0x00002836
	public static void smethod_11(string string_4, string string_5)
	{
		GClass121.Class15 @class = new GClass121.Class15();
		@class.dataLanguage = string_5;
		new Thread(new ThreadStart(@class.method_0)).Start();
		GClass121.smethod_0(string_4);
	}

	// Token: 0x0600067A RID: 1658 RVA: 0x000E5C24 File Offset: 0x000E3E24
	public static string smethod_12(string string_4, string string_5)
	{
		string text = "";
		int num = 0;
		int num2 = 1;
		while (num2 < GClass121.string_0.Length && !(GClass121.string_0[num2].ToLower() == string_4.ToLower()))
		{
			num2++;
		}
		for (int i = 0; i < GClass127.smethod_51().Length; i++)
		{
			if (GClass127.smethod_51()[i].StartsWith("lang"))
			{
				num++;
			}
			else
			{
				new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.smethod_51()[i] + ".dat", FileMode.Open, FileAccess.Read).Close();
			}
			if (num != 0 && (num != 1 || num > 4) && num == 2 && !GClass127.smethod_51()[i].StartsWith("lang0") && GClass127.smethod_51()[i] == GClass127.smethod_33())
			{
				FileStream fileStream = new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.smethod_51()[i] + ".dat", FileMode.Open, FileAccess.Read);
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
					array5 = GClass103.smethod_0(array5);
					text = GClass127.smethod_11(array5).Replace(" ", "");
					if (text.StartsWith(string_5))
					{
						break;
					}
				}
				fileStream.Close();
			}
		}
		return text;
	}

	// Token: 0x0600067B RID: 1659 RVA: 0x000E5DF4 File Offset: 0x000E3FF4
	private static void smethod_13(string string_4)
	{
		int num = 0;
		for (int i = 0; i < GClass127.smethod_51().Length; i++)
		{
			if (!GClass127.smethod_51()[i].StartsWith("lang"))
			{
				num++;
			}
			if (num != 7 && num > 5 && !GClass127.smethod_51()[i].StartsWith("lang0"))
			{
				FileStream fileStream = new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.smethod_51()[i] + ".dat", FileMode.Open, FileAccess.Read);
				byte[] array = new byte[6];
				int[] array2 = new int[3];
				bool flag = false;
				while (fileStream.Position < fileStream.Length)
				{
					fileStream.Read(array, 0, array.Length);
					byte[] array3 = array;
					int num2 = 4;
					array3[num2] ^= array[3];
					byte[] array4 = array;
					int num3 = 1;
					array4[num3] ^= array[2];
					byte[] array5 = array;
					int num4 = 5;
					array5[num4] ^= array[1];
					byte[] array6 = array;
					int num5 = 2;
					array6[num5] ^= array[3];
					byte[] array7 = array;
					int num6 = 3;
					array7[num6] ^= array[1];
					byte[] array8 = array;
					int num7 = 3;
					array8[num7] ^= array[0];
					array2[0] = (int)array[3] + 256 * (int)array[0];
					array2[1] = (int)array[2] + 256 * (int)array[4];
					array2[2] = (int)array[1] + 256 * (int)array[5];
					byte[] array9 = new byte[array2[1]];
					byte[] array10 = new byte[array2[2]];
					fileStream.Read(array9, 0, array9.Length);
					fileStream.Read(array10, 0, array10.Length);
					array9 = GClass103.smethod_0(array9);
					array10 = GClass103.smethod_0(array10);
					int num8 = GClass127.smethod_37(Encoding.Unicode.GetString(array9));
					if (num8 == 0)
					{
						string @string = Encoding.Unicode.GetString(array10);
						flag = (string_4 == @string);
					}
					if (num8 > 0 && flag && array10.Length > 1)
					{
						GClass121.sortedList_4.Add(num8 + 40000, Encoding.Unicode.GetString(array10));
					}
				}
				fileStream.Close();
			}
		}
	}

	// Token: 0x0600067C RID: 1660 RVA: 0x0000465F File Offset: 0x0000285F
	public static bool smethod_14(string string_4, string string_5, bool bool_0)
	{
		GClass125.smethod_5();
		GClass125.smethod_15();
		if (!bool_0)
		{
			return string_4 == string_5;
		}
		return string_4.StartsWith(string_5);
	}

	// Token: 0x0600067D RID: 1661 RVA: 0x000E5FE4 File Offset: 0x000E41E4
	public static string smethod_15(string string_4, string string_5)
	{
		string text = "";
		long num = 700L;
		byte[] array = new byte[12];
		int num2 = 1;
		while (num2 < GClass121.string_0.Length && !(GClass121.string_0[num2].ToLower() == string_4.ToLower()))
		{
			num2++;
		}
		GClass126.smethod_2("LENC1", 0);
		num = 180L * num;
		string text2 = GClass127.smethod_11(GClass127.smethod_32(string_5));
		GClass121.byte_0 = 0;
		if (GClass122.smethod_13() != GClass125.smethod_24())
		{
			throw new Exception("Data decode failed!");
		}
		FileStream fileStream = new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.smethod_51()[4] + ".dat", FileMode.Open, FileAccess.Read);
		long length = fileStream.Length;
		byte[] array2 = new byte[length];
		fileStream.Read(array2, 0, (int)length);
		fileStream.Close();
		GClass126.smethod_2("LOAD DATA: Len0" + 5.ToString() + ": " + length.ToString(), 0);
		GClass126.int_9 = (int)(length - num);
		byte[] byte_ = SHA1.Create().ComputeHash(array2);
		int num3 = (int)num;
		while ((long)num3 < length - 11L)
		{
			for (int i = 0; i < 12; i++)
			{
				array[i] = array2[num3++];
			}
			string text3 = GClass121.smethod_19(array);
			if (text3 == text2)
			{
				GClass126.int_10 = num3 - (int)num - 12;
				if (GClass125.string_0 == GClass127.smethod_11(byte_))
				{
					GClass123.string_3 = text3;
				}
				text = text2;
				GClass125.int_18[4]++;
				GClass126.string_4 = GClass127.smethod_11(array);
				GClass126.smethod_2("DATA1S: " + text3, 0);
				GClass126.smethod_2("POS: " + GClass126.int_10.ToString(), 0);
			}
		}
		array2 = new byte[1];
		text = text.Replace(" ", "");
		text = text.Replace("V", "J");
		GClass126.smethod_2("LENC2", 0);
		GClass126.bool_10 = (GClass126.bool_10 && !(text == ""));
		return text.Replace("Z", "T");
	}

	// Token: 0x0600067E RID: 1662 RVA: 0x000E622C File Offset: 0x000E442C
	public static string smethod_16(string string_4)
	{
		if (string_4 == "")
		{
			return "";
		}
		string result = string_4;
		try
		{
			result = GClass121.sortedList_3[string_4.ToLower()];
		}
		catch (Exception)
		{
		}
		return result;
	}

	// Token: 0x0600067F RID: 1663 RVA: 0x000E6278 File Offset: 0x000E4478
	private static void smethod_17(string string_4)
	{
		int num = 0;
		int num2 = 0;
		GClass121.sortedList_4.Clear();
		for (int i = 1; i < GClass121.string_0.Length; i++)
		{
			if (GClass121.string_0[i].ToLower() == string_4.ToLower())
			{
				num = i;
				IL_3D:
				for (int j = 0; j < GClass127.smethod_51().Length; j++)
				{
					if (GClass127.smethod_51()[j].StartsWith("lang"))
					{
						num2++;
					}
					if (num2 != 0 && (num2 != 2 || num2 > 3) && num2 == 3 && !GClass127.smethod_51()[j].StartsWith("lang0"))
					{
						FileStream fileStream = new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.smethod_51()[j] + ".dat", FileMode.Open, FileAccess.Read);
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
							if (num == (int)b && GClass126.bool_13)
							{
								array6 = GClass103.smethod_0(array6);
								GClass121.sortedList_4.Add(key, Encoding.Unicode.GetString(array6));
							}
						}
						fileStream.Close();
					}
				}
				return;
			}
		}
		goto IL_3D;
	}

	// Token: 0x06000680 RID: 1664 RVA: 0x000E6428 File Offset: 0x000E4628
	private static void smethod_18(string string_4, int int_1)
	{
		string text = GClass121.smethod_8(int_1);
		if (text.Length > 0)
		{
			GClass121.sortedList_3.Add(string_4.ToLower(), text);
		}
	}

	// Token: 0x06000681 RID: 1665 RVA: 0x000E6458 File Offset: 0x000E4658
	private static string smethod_19(byte[] byte_2)
	{
		if (!GClass126.bool_17)
		{
			GClass121.byte_0 = 0;
		}
		for (int i = 0; i < byte_2.Length; i++)
		{
			if (i < 11)
			{
				GClass121.byte_0 += byte_2[i];
			}
			else if (GClass121.byte_0 != byte_2[i])
			{
				throw new Exception(GClass121.string_3);
			}
		}
		return GClass127.smethod_11(byte_2).Substring(0, GClass121.int_0);
	}

	// Token: 0x06000682 RID: 1666 RVA: 0x000E64C0 File Offset: 0x000E46C0
	public static string smethod_20(int int_1, string string_4)
	{
		if (int_1 == 0)
		{
			return string_4;
		}
		string result = string_4;
		try
		{
			result = GClass121.sortedList_4[int_1];
		}
		catch (Exception)
		{
		}
		return result;
	}

	// Token: 0x06000683 RID: 1667 RVA: 0x000E64F8 File Offset: 0x000E46F8
	public static string smethod_21(string string_4, string string_5)
	{
		if (string_4.Length < 16)
		{
			string_4 += "30383936363339323634393236344141";
		}
		string_4 = string_4.Substring(0, 16);
		byte[] array = GClass127.smethod_32(string_4);
		byte[] array2 = new byte[array.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = array[array.Length - i - 1];
		}
		byte[] array3 = GClass127.smethod_32("6A606A197B056117");
		if (GClass125.smethod_101(18).Name == "Black")
		{
			array3 = GClass127.smethod_32("2B796A291B256457");
		}
		if (string_5.Length == 18 && string_5[5] == '-' && string_5[11] == '-' && GClass125.smethod_11().Length == 0)
		{
			try
			{
				string_5 = string_5.Replace("-", "");
				if (array3[0] == 106)
				{
					array3 = GClass127.smethod_32(string_5);
				}
			}
			catch (Exception)
			{
			}
		}
		int num = 0;
		while (num < array2.Length && num < array3.Length)
		{
			byte[] array4 = array2;
			int num2 = num;
			array4[num2] ^= array3[num];
			num++;
		}
		int length = Encoding.ASCII.GetString(array2).Length;
		return GClass127.smethod_11(array2).Replace(" ", "");
	}

	// Token: 0x06000684 RID: 1668 RVA: 0x000E6638 File Offset: 0x000E4838
	public static string smethod_22(string string_4, int int_1)
	{
		string text = "";
		int num = 0;
		for (int i = 0; i < GClass127.smethod_51().Length; i++)
		{
			if (GClass127.smethod_51()[i].StartsWith("lang"))
			{
				num++;
			}
			else
			{
				new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.smethod_51()[i] + ".dat", FileMode.Open, FileAccess.Read).Close();
			}
			int num2 = 0;
			if (num != 0 && (num != 1 || num > 4) && num == 2 && !GClass127.smethod_51()[i].StartsWith("lang0") && GClass127.smethod_51()[i] == GClass127.smethod_33())
			{
				FileStream fileStream = new FileStream(GClass125.smethod_30() + "\\Files\\" + GClass127.smethod_51()[i] + ".dat", FileMode.Open, FileAccess.Read);
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
					array5 = GClass103.smethod_0(array5);
					if (int_1 > 0 && int_1 < 1000)
					{
						text = Encoding.ASCII.GetString(array5);
					}
					else
					{
						text = GClass127.smethod_11(array5).Replace(" ", "");
					}
					if (int_1 == num2 || text.StartsWith(string_4))
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

	// Token: 0x040005B9 RID: 1465
	private static SortedList<string, string> sortedList_0 = new SortedList<string, string>();

	// Token: 0x040005BA RID: 1466
	private static SortedList<string, string> sortedList_1 = new SortedList<string, string>();

	// Token: 0x040005BB RID: 1467
	private static SortedList<string, string> sortedList_2 = new SortedList<string, string>();

	// Token: 0x040005BC RID: 1468
	private static SortedList<string, string> sortedList_3 = new SortedList<string, string>();

	// Token: 0x040005BD RID: 1469
	private static SortedList<int, string> sortedList_4 = new SortedList<int, string>();

	// Token: 0x040005BE RID: 1470
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

	// Token: 0x040005BF RID: 1471
	public static string string_1 = "ERROR";

	// Token: 0x040005C0 RID: 1472
	public static string string_2 = "Data file error!";

	// Token: 0x040005C1 RID: 1473
	private static byte byte_0 = 0;

	// Token: 0x040005C2 RID: 1474
	private static int int_0 = 32;

	// Token: 0x040005C3 RID: 1475
	private static string string_3 = "CS failed";

	// Token: 0x040005C4 RID: 1476
	private static byte[] byte_1 = new byte[]
	{
		0,
		27,
		6,
		18,
		35,
		86,
		73,
		1
	};

	// Token: 0x020000C2 RID: 194
	[CompilerGenerated]
	private sealed class Class15
	{
		// Token: 0x06000687 RID: 1671 RVA: 0x00004685 File Offset: 0x00002885
		internal void method_0()
		{
			GClass121.smethod_1(this.dataLanguage);
		}

		// Token: 0x040005C5 RID: 1477
		public string dataLanguage;
	}
}
