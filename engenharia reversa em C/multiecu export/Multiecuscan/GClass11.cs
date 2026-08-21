using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Foundation;

// Token: 0x0200002C RID: 44
public abstract class GClass11
{
	// Token: 0x06000246 RID: 582 RVA: 0x00002FB2 File Offset: 0x000011B2
	public void method_0()
	{
		GClass126.bool_25 = false;
		this.genum0_0 = (GEnum0)1;
		this.vmethod_1();
	}

	// Token: 0x06000247 RID: 583 RVA: 0x00002FC7 File Offset: 0x000011C7
	public void method_1()
	{
		GClass126.bool_25 = false;
		this.genum0_0 = (GEnum0)4;
		this.vmethod_1();
	}

	// Token: 0x06000248 RID: 584 RVA: 0x00039B10 File Offset: 0x00037D10
	private void method_2(string string_22)
	{
		GClass126.smethod_2(GClass107.smethod_3(161779) + string_22, 0);
		byte[] bytes = Encoding.ASCII.GetBytes(string_22 + this.string_12);
		byte[] array = new byte[1];
		if (GClass125.smethod_44() != 9)
		{
			if (GClass125.smethod_44() != 10)
			{
				this.tcpClient_0.Client.Send(bytes);
				return;
			}
		}
		for (int i = 0; i < bytes.Length; i++)
		{
			array[0] = bytes[i];
			this.tcpClient_0.Client.Send(array);
		}
	}

	// Token: 0x06000249 RID: 585 RVA: 0x00002FDC File Offset: 0x000011DC
	public void method_3(byte[] byte_3)
	{
		this.byte_2 = byte_3;
	}

	// Token: 0x0600024A RID: 586 RVA: 0x00039BA0 File Offset: 0x00037DA0
	protected string method_4()
	{
		if (GClass125.smethod_48())
		{
			return this.method_29();
		}
		if (GClass125.smethod_52())
		{
			return this.method_6();
		}
		if (this.serialPort_0 == null)
		{
			return "";
		}
		string text = "";
		while (!text.EndsWith(">") && !text.EndsWith("\r") && !text.EndsWith("\n") && text.Length < 250)
		{
			text += ((char)this.serialPort_0.ReadByte()).ToString();
		}
		GClass126.smethod_2(GClass107.smethod_3(161846) + text, 0);
		return text;
	}

	// Token: 0x0600024B RID: 587 RVA: 0x00039C48 File Offset: 0x00037E48
	private string method_5()
	{
		string text = "";
		long num = (long)(GClass126.smethod_1() + 3500);
		while (!text.EndsWith(">") && num > (long)GClass126.smethod_1() && text.Length < 6000)
		{
			if (this.tcpClient_0.Client.Available > 0)
			{
				int num2 = this.tcpClient_0.GetStream().ReadByte();
				if (num2 != -1)
				{
					text += ((char)num2).ToString();
				}
				num = (long)(GClass126.smethod_1() + 2500);
			}
			else
			{
				Thread.Sleep(5);
			}
		}
		if (text == "" && num <= (long)GClass126.smethod_1())
		{
			throw new Exception(GClass107.smethod_3(161807));
		}
		GClass126.smethod_2(GClass107.smethod_3(161845) + text, 0);
		return text;
	}

	// Token: 0x0600024C RID: 588 RVA: 0x00039D1C File Offset: 0x00037F1C
	protected virtual void r9(string string_22)
	{
		string text = string_22.Replace(" ", "");
		if (GClass125.smethod_48())
		{
			this.method_2(text);
			return;
		}
		if (GClass125.smethod_52())
		{
			this.method_24(text);
			return;
		}
		GClass126.smethod_2("Send: " + text, 0);
		if (GClass125.smethod_44() != 2 && GClass125.smethod_44() != 4 && GClass125.smethod_44() != 8 && !GClass125.smethod_49())
		{
			for (int i = 0; i < text.Length; i++)
			{
				this.serialPort_0.Write(text.Substring(i, 1));
			}
			this.serialPort_0.Write(this.serialPort_0.NewLine);
			return;
		}
		this.serialPort_0.WriteLine(text);
	}

	// Token: 0x0600024D RID: 589 RVA: 0x00039DD0 File Offset: 0x00037FD0
	private string method_6()
	{
		string text = "";
		if (this.gattDeviceService_0 == null)
		{
			throw new Exception(GClass107.smethod_3(162026));
		}
		long num = (long)(GClass126.smethod_1() + 3500);
		while (!text.EndsWith(">") && !text.EndsWith("\r") && !text.EndsWith("\n") && text.Length < 250 && num > (long)GClass126.smethod_1())
		{
			if (this.stringBuilder_0.Length > 0)
			{
				text += this.stringBuilder_0[0].ToString();
				this.stringBuilder_0.Remove(0, 1);
				num = (long)(GClass126.smethod_1() + 2500);
			}
			else
			{
				Thread.Sleep(5);
			}
		}
		GClass126.smethod_2(GClass107.smethod_3(162041) + text, 0);
		return text;
	}

	// Token: 0x0600024E RID: 590 RVA: 0x00039EB0 File Offset: 0x000380B0
	protected virtual string ra(string string_22)
	{
		if (this.serialPort_0 != null && this.serialPort_0.BytesToRead > 0)
		{
			try
			{
				this.serialPort_0.ReadExisting();
			}
			catch (Exception)
			{
			}
		}
		this.r9(string_22);
		string text = this.rb();
		if (!text.Contains("OK"))
		{
			GClass126.smethod_2("[" + string_22 + "] failed!", 0);
			if (GClass125.smethod_46())
			{
				this.r9(string_22);
				text = this.rb();
			}
		}
		this.int_0 = GClass126.smethod_1();
		return text;
	}

	// Token: 0x0600024F RID: 591 RVA: 0x00039F48 File Offset: 0x00038148
	public static GClass11 smethod_0(string string_22, string string_23, byte byte_3, List<GClass104> list_6, List<GClass104> list_7, string string_24, List<GClass104> list_8)
	{
		GClass11 gclass = null;
		string text = "";
		switch (GClass125.smethod_44())
		{
		case 1:
			text = "KL";
			break;
		case 2:
		case 3:
		case 8:
		case 9:
		case 11:
			text = "ELM";
			break;
		case 4:
			text = GClass107.smethod_3(159489);
			break;
		case 5:
		case 10:
			text = GClass107.smethod_3(159496);
			break;
		case 6:
		case 13:
			text = "CTC";
			break;
		case 7:
		case 12:
			text = GClass107.smethod_3(159504);
			break;
		case 15:
			text = "VGM";
			break;
		}
		if (GClass126.bool_10 && text != "")
		{
			text = "CTC";
		}
		if (!GClass126.bool_10 && text == "CTC")
		{
			text = "";
		}
		if ((string_22 == GClass107.smethod_3(159543) || string_22 == GClass107.smethod_3(159590)) && GClass126.bool_13 && !GClass123.bool_17)
		{
			bool flag = true;
			if (GClass125.smethod_5().ToUpper().StartsWith(GClass122.string_3))
			{
				GClass126.smethod_2(GClass107.smethod_3(159631), 0);
			}
			else
			{
				flag = false;
			}
			if (flag)
			{
				if (string_22 == GClass107.smethod_3(159656))
				{
					string_22 = GClass107.smethod_3(159672);
				}
				else
				{
					string_22 = GClass107.smethod_3(159686);
				}
			}
		}
		text = text + "_" + string_22;
		uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
		if (num <= 2140589232U)
		{
			if (num <= 1095660314U)
			{
				if (num <= 477805166U)
				{
					if (num <= 170411615U)
					{
						if (num <= 111575793U)
						{
							if (num != 34484212U)
							{
								if (num != 69103747U)
								{
									if (num == 111575793U)
									{
										if (text == "CTC_CANDETECT")
										{
											gclass = new GClass45();
										}
									}
								}
								else if (text == "CTC_CCANPN")
								{
									gclass = new GClass49();
								}
							}
							else if (text == "VGM_CANSCAN29")
							{
								gclass = new GClass43();
							}
						}
						else if (num != 146877845U)
						{
							if (num != 160969671U)
							{
								if (num == 170411615U)
								{
									if (text == "ELM_CCANPNKWP")
									{
										gclass = new GClass61();
									}
								}
							}
							else if (text == "CTC_MONBCAN29")
							{
								gclass = new GClass37();
							}
						}
						else if (text == "CTC_CANSCANPN")
						{
							gclass = new GClass68();
						}
					}
					else if (num <= 232860861U)
					{
						if (num != 191161794U)
						{
							if (num != 195201597U)
							{
								if (num == 232860861U)
								{
									if (text == "CTC_KWP01")
									{
										gclass = new GClass78();
									}
								}
							}
							else if (text == "OKEY_CCANPN")
							{
								gclass = new GClass53();
							}
						}
						else if (text == "OLNK_BCAN")
						{
							gclass = new GClass16();
						}
					}
					else if (num <= 310866977U)
					{
						if (num != 310322327U)
						{
							if (num == 310866977U)
							{
								if (text == "OLNK_CCANPNKWP")
								{
									gclass = new GClass65();
								}
							}
						}
						else if (text == "OLNK_CANSCANPN")
						{
							gclass = new GClass69();
						}
					}
					else if (num != 359469822U)
					{
						if (num == 477805166U)
						{
							if (text == "ELM_BHCANPN")
							{
								gclass = new GClass50();
							}
						}
					}
					else if (text == "CTC_CANSCAN29")
					{
						gclass = new GClass41();
					}
				}
				else if (num <= 685087357U)
				{
					if (num <= 656729795U)
					{
						if (num != 530260577U)
						{
							if (num != 593627204U)
							{
								if (num == 656729795U)
								{
									if (text == "OKEY_KWIAW")
									{
										gclass = null;
									}
								}
							}
							else if (text == "OKEY_BHCANPN")
							{
								gclass = new GClass52();
							}
						}
						else if (text == "CTC_KWIAW")
						{
							gclass = new GClass80();
						}
					}
					else if (num != 658368540U)
					{
						if (num != 658759658U)
						{
							if (num == 685087357U)
							{
								if (text == "ELM_CANSCANPN")
								{
									gclass = new GClass69();
								}
							}
						}
						else if (text == "OKEY_BHCANPNKWP")
						{
							gclass = new GClass62();
						}
					}
					else if (text == "ELM_CCAN29")
					{
						gclass = new GClass29();
					}
				}
				else if (num <= 816377850U)
				{
					if (num != 699789021U)
					{
						if (num != 761307152U)
						{
							if (num == 816377850U)
							{
								if (text == "ELM_KWP71")
								{
									gclass = null;
								}
							}
						}
						else if (text == "OLNK_BHCANPN")
						{
							gclass = new GClass54();
						}
					}
					else if (text == "VGM_CCANPN")
					{
						gclass = new GClass55();
					}
				}
				else if (num <= 940343891U)
				{
					if (num != 934231622U)
					{
						if (num == 940343891U)
						{
							if (text == "OLNK_BHCAN29")
							{
								gclass = new GClass28();
							}
						}
					}
					else if (text == "OKEY_CCAN29")
					{
						gclass = new GClass32();
					}
				}
				else if (num != 1028180299U)
				{
					if (num == 1095660314U)
					{
						if (text == "OKEY_ISO9141")
						{
							gclass = new GClass75();
						}
					}
				}
				else if (text == "OKEYUSB_OBDII")
				{
					gclass = new GClass72();
				}
			}
			else if (num <= 1406926415U)
			{
				if (num <= 1246180714U)
				{
					if (num <= 1188484811U)
					{
						if (num != 1145725627U)
						{
							if (num != 1176698539U)
							{
								if (num == 1188484811U)
								{
									if (text == "OLNK_BCAN29")
									{
										gclass = new GClass27();
									}
								}
							}
							else if (text == "VGM_KWP01")
							{
								gclass = null;
							}
						}
						else if (text == "OKEYUSB_BHCAN29")
						{
							gclass = new GClass31();
						}
					}
					else if (num != 1202691489U)
					{
						if (num != 1238550000U)
						{
							if (num == 1246180714U)
							{
								if (text == "OKEYUSB_CCAN29")
								{
									gclass = new GClass32();
								}
							}
						}
						else if (text == "CTC_BHCANPNKWP")
						{
							gclass = new GClass58();
						}
					}
					else if (text == "KL_ISO9141")
					{
						gclass = new GClass89(byte_3, list_6, list_7);
					}
				}
				else if (num <= 1306339558U)
				{
					if (num != 1272558368U)
					{
						if (num != 1301659718U)
						{
							if (num == 1306339558U)
							{
								if (text == "CTC_BHCANPN")
								{
									gclass = new GClass48();
								}
							}
						}
						else if (text == "VGM_BCAN")
						{
							gclass = new GClass17();
						}
					}
					else if (text == "OLNK_KWP71")
					{
						gclass = null;
					}
				}
				else if (num <= 1357952645U)
				{
					if (num != 1312052324U)
					{
						if (num == 1357952645U)
						{
							if (text == "VGM_MONBCAN29")
							{
								gclass = new GClass39();
							}
						}
					}
					else if (text == "VGM_KWP71")
					{
						gclass = null;
					}
				}
				else if (num != 1369178913U)
				{
					if (num == 1406926415U)
					{
						if (text == "OLNK_KWP01")
						{
							gclass = null;
						}
					}
				}
				else if (text == "OLNK_MONBCAN29")
				{
					gclass = new GClass38();
				}
			}
			else if (num <= 1799407524U)
			{
				if (num <= 1513915288U)
				{
					if (num != 1423162196U)
					{
						if (num != 1443768703U)
						{
							if (num == 1513915288U)
							{
								if (text == "OKEYUSB_BHCANPN")
								{
									gclass = new GClass52();
								}
							}
						}
						else if (text == "OKEY_BHCAN29")
						{
							gclass = new GClass31();
						}
					}
					else if (text == "CTC_CCAN29")
					{
						gclass = new GClass26();
					}
				}
				else if (num <= 1643195962U)
				{
					if (num != 1586123999U)
					{
						if (num == 1643195962U)
						{
							if (text == "OKEYUSB_BCAN")
							{
								gclass = new GClass15();
							}
						}
					}
					else if (text == "VGM_BHCAN29")
					{
						gclass = new GClass34();
					}
				}
				else if (num != 1719753249U)
				{
					if (num == 1799407524U)
					{
						if (text == "VGM_BHCANPN")
						{
							gclass = new GClass56();
						}
					}
				}
				else if (text == "OLNK_CCANPN")
				{
					gclass = new GClass55();
				}
			}
			else if (num <= 1911968035U)
			{
				if (num != 1809914656U)
				{
					if (num != 1892921198U)
					{
						if (num == 1911968035U)
						{
							if (text == "VGM_CANSCANPN")
							{
								gclass = new GClass69();
							}
						}
					}
					else if (text == "ELM_KWP2000Fast")
					{
						gclass = new GClass83();
					}
				}
				else if (text == "ELM_BCAN")
				{
					gclass = new GClass14();
				}
			}
			else if (num <= 2112395474U)
			{
				if (num != 1952347049U)
				{
					if (num == 2112395474U)
					{
						if (text == "CTC_KWP71")
						{
							gclass = new GClass86();
						}
					}
				}
				else if (text == "OKEYUSB_CCANPN")
				{
					gclass = new GClass53();
				}
			}
			else if (num != 2136879781U)
			{
				if (num == 2140589232U)
				{
					if (text == "KL_KWP01")
					{
						gclass = new GClass90(byte_3, list_6, list_7);
					}
				}
			}
			else if (text == "OKEY_MONBCAN29")
			{
				gclass = new GClass38();
			}
		}
		else if (num <= 3072736171U)
		{
			if (num <= 2543717606U)
			{
				if (num <= 2398603208U)
				{
					if (num <= 2274957279U)
					{
						if (num != 2161797110U)
						{
							if (num != 2170475965U)
							{
								if (num == 2274957279U)
								{
									if (text == "KL_KWP71")
									{
										gclass = new GClass93(byte_3, list_6, list_7);
									}
								}
							}
							else if (text == "ELM_BCAN29")
							{
								gclass = new GClass27();
							}
						}
						else if (text == "ELM_MONBCAN")
						{
							gclass = new GClass20();
						}
					}
					else if (num != 2291954435U)
					{
						if (num != 2312776231U)
						{
							if (num == 2398603208U)
							{
								if (text == "OKEYUSB_KWP71")
								{
									gclass = new GClass87();
								}
							}
						}
						else if (text == "OKEYUSB_KWIAW")
						{
							gclass = new GClass91(byte_3, list_6, list_7);
						}
					}
					else if (text == "OLNK_OBDII")
					{
						gclass = new GClass72();
					}
				}
				else if (num <= 2438615070U)
				{
					if (num != 2423756904U)
					{
						if (num != 2426012124U)
						{
							if (num == 2438615070U)
							{
								if (text == "CTC_MONBCAN")
								{
									gclass = new GClass19();
								}
							}
						}
						else if (text == "OKEYUSB_MONBCAN")
						{
							gclass = new GClass21();
						}
					}
					else if (text == "CTC_BCAN")
					{
						gclass = new GClass13();
					}
				}
				else if (num <= 2532971255U)
				{
					if (num != 2462549153U)
					{
						if (num == 2532971255U)
						{
							if (text == "OKEYUSB_KWP01")
							{
								gclass = new GClass90(byte_3, list_6, list_7);
							}
						}
					}
					else if (text == "ELM_OBDII")
					{
						gclass = new GClass72();
					}
				}
				else if (num != 2533936247U)
				{
					if (num == 2543717606U)
					{
						if (text == "VGM_CCAN29")
						{
							gclass = new GClass35();
						}
					}
				}
				else if (text == "OKEY_OBDII")
				{
					gclass = new GClass72();
				}
			}
			else if (num <= 2713734712U)
			{
				if (num <= 2596423223U)
				{
					if (num != 2555072190U)
					{
						if (num != 2565846666U)
						{
							if (num == 2596423223U)
							{
								if (text == "CTC_CCANPNKWP")
								{
									gclass = new GClass59();
								}
							}
						}
						else if (text == "VGM_BHCANPNKWP")
						{
							gclass = new GClass64();
						}
					}
					else if (text == "OKEYUSB_BHCANPNKWP")
					{
						gclass = new GClass62();
					}
				}
				else if (num <= 2664591612U)
				{
					if (num != 2649330908U)
					{
						if (num == 2664591612U)
						{
							if (text == "KL_KWIAW")
							{
								gclass = new GClass91(byte_3, list_6, list_7);
							}
						}
					}
					else if (text == "OKEYUSB_KWP2000Fast")
					{
						gclass = new GClass84();
					}
				}
				else if (num != 2694926725U)
				{
					if (num == 2713734712U)
					{
						if (text == "ELM_BHCANPNKWP")
						{
							gclass = new GClass60();
						}
					}
				}
				else if (text == "ELM_KWP01")
				{
					gclass = null;
				}
			}
			else if (num <= 2869169165U)
			{
				if (num != 2813394170U)
				{
					if (num != 2850754246U)
					{
						if (num == 2869169165U)
						{
							if (text == "OKEY_CCANPNKWP")
							{
								gclass = new GClass63();
							}
						}
					}
					else if (text == "OLNK_ISO9141")
					{
						gclass = new GClass76();
					}
				}
				else if (text == "VGM_ISO9141")
				{
					gclass = new GClass76();
				}
			}
			else if (num <= 3042720949U)
			{
				if (num != 2968239987U)
				{
					if (num == 3042720949U)
					{
						if (text == "CTC_BCAN29")
						{
							gclass = new GClass24();
						}
					}
				}
				else if (text == "OKEYUSB_BCAN29")
				{
					gclass = new GClass30();
				}
			}
			else if (num != 3069174036U)
			{
				if (num == 3072736171U)
				{
					if (text == "ELM_CCANPN")
					{
						gclass = new GClass51();
					}
				}
			}
			else if (text == "OLNK_KWP2000Fast")
			{
				gclass = new GClass83();
			}
		}
		else if (num <= 3783466918U)
		{
			if (num <= 3274881088U)
			{
				if (num <= 3163726577U)
				{
					if (num != 3151153840U)
					{
						if (num != 3153458123U)
						{
							if (num == 3163726577U)
							{
								if (text == "CTC_BHCAN29")
								{
									gclass = new GClass25();
								}
							}
						}
						else if (text == "OKEY_KWP01")
						{
							gclass = null;
						}
					}
					else if (text == "OLNK_CANSCAN29")
					{
						gclass = new GClass42();
					}
				}
				else if (num != 3216111085U)
				{
					if (num != 3269143896U)
					{
						if (num == 3274881088U)
						{
							if (text == "VGM_KWP2000Fast")
							{
								gclass = new GClass83();
							}
						}
					}
					else if (text == "OKEY_MONBCAN")
					{
						gclass = new GClass21();
					}
				}
				else if (text == "VGM_CCANPNKWP")
				{
					gclass = new GClass65();
				}
			}
			else if (num <= 3384327929U)
			{
				if (num != 3288811908U)
				{
					if (num != 3348482766U)
					{
						if (num == 3384327929U)
						{
							if (text == "CTC_OBDII")
							{
								gclass = new GClass71();
							}
						}
					}
					else if (text == "OKEYUSB_ISO9141")
					{
						gclass = new GClass75();
					}
				}
				else if (text == "OKEY_KWP71")
				{
					gclass = new GClass87();
				}
			}
			else if (num <= 3605727763U)
			{
				if (num != 3592440966U)
				{
					if (num == 3605727763U)
					{
						if (text == "KL_KWP2000Fast")
						{
							gclass = new GClass92(byte_3, list_6, list_7);
						}
					}
				}
				else if (text == "ELM_CANSCAN29")
				{
					gclass = new GClass42();
				}
			}
			else if (num != 3768033751U)
			{
				if (num == 3783466918U)
				{
					if (text == "OKEY_BCAN")
					{
						gclass = new GClass15();
					}
				}
			}
			else if (text == "VGM_OBDII")
			{
				gclass = new GClass72();
			}
		}
		else if (num <= 3994511136U)
		{
			if (num <= 3843783992U)
			{
				if (num != 3800093508U)
				{
					if (num != 3838216694U)
					{
						if (num == 3843783992U)
						{
							if (text == "VGM_MONBCAN")
							{
								gclass = new GClass22();
							}
						}
					}
					else if (text == "OLNK_BHCANPNKWP")
					{
						gclass = new GClass64();
					}
				}
				else if (text == "ELM_ISO9141")
				{
					gclass = null;
				}
			}
			else if (num <= 3980088809U)
			{
				if (num != 3945843609U)
				{
					if (num == 3980088809U)
					{
						if (text == "OKEYUSB_CCANPNKWP")
						{
							gclass = new GClass63();
						}
					}
				}
				else if (text == "ELM_BHCAN29")
				{
					gclass = new GClass28();
				}
			}
			else if (num != 3994306918U)
			{
				if (num == 3994511136U)
				{
					if (text == "OKEY_KWP2000Fast")
					{
						gclass = new GClass84();
					}
				}
			}
			else if (text == "CTC_KWP2000Fast")
			{
				gclass = new GClass82();
			}
		}
		else if (num <= 4060825023U)
		{
			if (num != 4029920580U)
			{
				if (num != 4042611324U)
				{
					if (num == 4060825023U)
					{
						if (text == "VGM_BCAN29")
						{
							gclass = new GClass33();
						}
					}
				}
				else if (text == "CTC_ISO9141")
				{
					gclass = new GClass74();
				}
			}
			else if (text == "OLNK_MONBCAN")
			{
				gclass = new GClass22();
			}
		}
		else if (num <= 4227605791U)
		{
			if (num != 4109505129U)
			{
				if (num == 4227605791U)
				{
					if (text == "OKEY_BCAN29")
					{
						gclass = new GClass30();
					}
				}
			}
			else if (text == "OKEYUSB_MONBCAN29")
			{
				gclass = new GClass38();
			}
		}
		else if (num != 4234786594U)
		{
			if (num == 4287641583U)
			{
				if (text == "ELM_MONBCAN29")
				{
					gclass = new GClass38();
				}
			}
		}
		else if (text == "OLNK_CCAN29")
		{
			gclass = new GClass29();
		}
		if (gclass != null)
		{
			gclass.byte_0 = byte_3;
			gclass.string_2 = string_23;
			gclass.list_0 = list_7;
			gclass.list_1 = list_6;
			gclass.string_3 = string_24;
			gclass.list_2 = list_8;
		}
		return gclass;
	}

	// Token: 0x06000250 RID: 592 RVA: 0x00002FE5 File Offset: 0x000011E5
	public bool method_7()
	{
		return this.bool_4;
	}

	// Token: 0x06000251 RID: 593 RVA: 0x00002FED File Offset: 0x000011ED
	public void method_8(bool bool_6)
	{
		this.bool_4 = bool_6;
	}

	// Token: 0x06000252 RID: 594 RVA: 0x00002FF6 File Offset: 0x000011F6
	public int method_9()
	{
		return this.int_3;
	}

	// Token: 0x06000253 RID: 595 RVA: 0x00002FFE File Offset: 0x000011FE
	public void method_10(int int_5)
	{
		this.int_3 = int_5;
	}

	// Token: 0x06000254 RID: 596 RVA: 0x00003007 File Offset: 0x00001207
	public string method_11()
	{
		return this.string_7;
	}

	// Token: 0x06000255 RID: 597 RVA: 0x0000300F File Offset: 0x0000120F
	public List<GClass102> method_12()
	{
		return this.list_4;
	}

	// Token: 0x06000256 RID: 598 RVA: 0x00003017 File Offset: 0x00001217
	public string method_13()
	{
		return this.string_11;
	}

	// Token: 0x06000257 RID: 599 RVA: 0x0000301F File Offset: 0x0000121F
	public string method_14()
	{
		return this.string_8;
	}

	// Token: 0x06000258 RID: 600 RVA: 0x00003027 File Offset: 0x00001227
	public string method_15()
	{
		return this.string_9;
	}

	// Token: 0x06000259 RID: 601 RVA: 0x0000302F File Offset: 0x0000122F
	public string method_16()
	{
		return this.string_10;
	}

	// Token: 0x0600025A RID: 602 RVA: 0x00003037 File Offset: 0x00001237
	public bool method_17()
	{
		return this.bool_5;
	}

	// Token: 0x0600025B RID: 603 RVA: 0x0000303F File Offset: 0x0000123F
	public bool method_18()
	{
		return this.bool_0 && !this.bool_1;
	}

	// Token: 0x0600025C RID: 604 RVA: 0x00003054 File Offset: 0x00001254
	public bool method_19()
	{
		return this.bool_2;
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x0600025D RID: 605 RVA: 0x0000305C File Offset: 0x0000125C
	// (set) Token: 0x0600025E RID: 606 RVA: 0x00003064 File Offset: 0x00001264
	public string ModuleID
	{
		get
		{
			return this.string_0;
		}
		set
		{
			this.string_0 = value;
		}
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x0600025F RID: 607 RVA: 0x0000306D File Offset: 0x0000126D
	// (set) Token: 0x06000260 RID: 608 RVA: 0x00003075 File Offset: 0x00001275
	public string ProtocolID
	{
		get
		{
			return this.string_1;
		}
		set
		{
			this.string_1 = value;
		}
	}

	// Token: 0x06000261 RID: 609 RVA: 0x0000307E File Offset: 0x0000127E
	public int method_20()
	{
		return (int)this.byte_0;
	}

	// Token: 0x06000262 RID: 610 RVA: 0x00003086 File Offset: 0x00001286
	public void method_21(List<GClass100> list_6)
	{
		this.list_5 = list_6;
	}

	// Token: 0x14000005 RID: 5
	// (add) Token: 0x06000263 RID: 611 RVA: 0x0003B258 File Offset: 0x00039458
	// (remove) Token: 0x06000264 RID: 612 RVA: 0x0003B290 File Offset: 0x00039490
	public event GDelegate4 Event_0
	{
		[CompilerGenerated]
		add
		{
			GDelegate4 gdelegate = this.gdelegate4_0;
			GDelegate4 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate4 value2 = (GDelegate4)Delegate.Combine(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate4>(ref this.gdelegate4_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
		[CompilerGenerated]
		remove
		{
			GDelegate4 gdelegate = this.gdelegate4_0;
			GDelegate4 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate4 value2 = (GDelegate4)Delegate.Remove(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate4>(ref this.gdelegate4_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
	}

	// Token: 0x14000006 RID: 6
	// (add) Token: 0x06000265 RID: 613 RVA: 0x0003B2C8 File Offset: 0x000394C8
	// (remove) Token: 0x06000266 RID: 614 RVA: 0x0003B300 File Offset: 0x00039500
	public event GDelegate3 Event_1
	{
		[CompilerGenerated]
		add
		{
			GDelegate3 gdelegate = this.gdelegate3_0;
			GDelegate3 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate3 value2 = (GDelegate3)Delegate.Combine(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate3>(ref this.gdelegate3_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
		[CompilerGenerated]
		remove
		{
			GDelegate3 gdelegate = this.gdelegate3_0;
			GDelegate3 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate3 value2 = (GDelegate3)Delegate.Remove(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate3>(ref this.gdelegate3_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
	}

	// Token: 0x14000007 RID: 7
	// (add) Token: 0x06000267 RID: 615 RVA: 0x0003B338 File Offset: 0x00039538
	// (remove) Token: 0x06000268 RID: 616 RVA: 0x0003B370 File Offset: 0x00039570
	public event GDelegate5 Event_2
	{
		[CompilerGenerated]
		add
		{
			GDelegate5 gdelegate = this.gdelegate5_0;
			GDelegate5 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate5 value2 = (GDelegate5)Delegate.Combine(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate5>(ref this.gdelegate5_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
		[CompilerGenerated]
		remove
		{
			GDelegate5 gdelegate = this.gdelegate5_0;
			GDelegate5 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate5 value2 = (GDelegate5)Delegate.Remove(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate5>(ref this.gdelegate5_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
	}

	// Token: 0x14000008 RID: 8
	// (add) Token: 0x06000269 RID: 617 RVA: 0x0003B3A8 File Offset: 0x000395A8
	// (remove) Token: 0x0600026A RID: 618 RVA: 0x0003B3E0 File Offset: 0x000395E0
	public event GDelegate5 Event_3
	{
		[CompilerGenerated]
		add
		{
			GDelegate5 gdelegate = this.gdelegate5_1;
			GDelegate5 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate5 value2 = (GDelegate5)Delegate.Combine(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate5>(ref this.gdelegate5_1, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
		[CompilerGenerated]
		remove
		{
			GDelegate5 gdelegate = this.gdelegate5_1;
			GDelegate5 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate5 value2 = (GDelegate5)Delegate.Remove(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate5>(ref this.gdelegate5_1, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
	}

	// Token: 0x14000009 RID: 9
	// (add) Token: 0x0600026B RID: 619 RVA: 0x0003B418 File Offset: 0x00039618
	// (remove) Token: 0x0600026C RID: 620 RVA: 0x0003B450 File Offset: 0x00039650
	public event GDelegate6 Event_4
	{
		[CompilerGenerated]
		add
		{
			GDelegate6 gdelegate = this.gdelegate6_0;
			GDelegate6 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate6 value2 = (GDelegate6)Delegate.Combine(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate6>(ref this.gdelegate6_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
		[CompilerGenerated]
		remove
		{
			GDelegate6 gdelegate = this.gdelegate6_0;
			GDelegate6 gdelegate2;
			do
			{
				gdelegate2 = gdelegate;
				GDelegate6 value2 = (GDelegate6)Delegate.Remove(gdelegate2, value);
				gdelegate = Interlocked.CompareExchange<GDelegate6>(ref this.gdelegate6_0, value2, gdelegate2);
			}
			while (gdelegate != gdelegate2);
		}
	}

	// Token: 0x0600026D RID: 621 RVA: 0x0003B488 File Offset: 0x00039688
	protected string method_22(List<byte> list_6)
	{
		this.r9(GClass107.smethod_3(162047));
		string text = "";
		if (GClass125.smethod_48())
		{
			long num = (long)(GClass126.smethod_1() + 3500);
			while (!text.EndsWith(">") && !text.EndsWith(":") && num > (long)GClass126.smethod_1())
			{
				if (this.tcpClient_0.Client.Available > 0)
				{
					int num2 = (int)((byte)this.tcpClient_0.GetStream().ReadByte());
					text += ((char)num2).ToString();
					num = (long)(GClass126.smethod_1() + 2500);
				}
				else
				{
					Thread.Sleep(5);
				}
			}
		}
		else if (GClass125.smethod_52())
		{
			long num3 = (long)(GClass126.smethod_1() + 3500);
			while (!text.EndsWith(">") && !text.EndsWith(":") && num3 > (long)GClass126.smethod_1() && text.Length < 6000)
			{
				if (this.stringBuilder_0.Length > 0)
				{
					text += this.stringBuilder_0[0].ToString();
					this.stringBuilder_0.Remove(0, 1);
					num3 = (long)(GClass126.smethod_1() + 2500);
				}
				else
				{
					Thread.Sleep(5);
				}
			}
		}
		else
		{
			while (!text.EndsWith(">") && !text.EndsWith(":"))
			{
				text += ((char)this.serialPort_0.ReadByte()).ToString();
			}
		}
		GClass126.smethod_2(GClass107.smethod_3(162058) + text, 0);
		byte[] array = new byte[64];
		for (int i = 0; i < 64; i++)
		{
			array[i] = list_6[i];
		}
		GClass127.smethod_44(ref array);
		GClass126.smethod_2(GClass107.smethod_3(162086) + list_6.Count.ToString() + GClass107.smethod_3(162126), 0);
		byte[] array2 = new byte[1];
		if (GClass125.smethod_48())
		{
			for (int j = 0; j < array.Length; j++)
			{
				array2[0] = array[j];
				this.tcpClient_0.Client.Send(array2);
			}
			for (int k = array.Length; k < list_6.Count; k++)
			{
				array2[0] = list_6[k];
				this.tcpClient_0.Client.Send(array2);
			}
			this.tcpClient_0.NoDelay = true;
		}
		else if (GClass125.smethod_52())
		{
			List<byte> list = new List<byte>();
			for (int l = array.Length; l < list_6.Count; l++)
			{
				list.Add(list_6[l]);
			}
			if (this.stringBuilder_0.Length > 0)
			{
				GClass126.smethod_2(GClass107.smethod_3(162143) + this.stringBuilder_0.ToString() + GClass107.smethod_3(162168), 0);
			}
			this.stringBuilder_0.Clear();
			WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(this.gattCharacteristic_1.WriteValueWithResultAsync(WindowsRuntimeBufferExtensions.AsBuffer(array))).GetAwaiter().GetResult();
			WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(this.gattCharacteristic_1.WriteValueWithResultAsync(WindowsRuntimeBufferExtensions.AsBuffer(list.ToArray()))).GetAwaiter().GetResult();
		}
		else
		{
			this.serialPort_0.Write(array, 0, array.Length);
			this.serialPort_0.Write(list_6.ToArray(), array.Length, list_6.Count - array.Length);
		}
		return this.rb();
	}

	// Token: 0x0600026E RID: 622 RVA: 0x0003B810 File Offset: 0x00039A10
	protected virtual string rb()
	{
		if (GClass125.smethod_48())
		{
			return this.method_5();
		}
		if (GClass125.smethod_52())
		{
			return this.method_34();
		}
		string text = "";
		byte b = 32;
		while (b != 62 && b != 0 && text.Length < 6000)
		{
			b = (byte)this.serialPort_0.ReadByte();
			if (b != 0)
			{
				string str = text;
				char c = (char)b;
				text = str + c.ToString();
			}
		}
		GClass126.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x0600026F RID: 623 RVA: 0x0003B890 File Offset: 0x00039A90
	public virtual void r0(bool bool_6, bool bool_7)
	{
		if (this.bool_1)
		{
			return;
		}
		GClass126.smethod_2("Terminating " + (bool_6 ? "with reconnect" : ""), 1);
		if (GClass126.bool_0 && !bool_7)
		{
			return;
		}
		this.bool_1 = true;
		this.bool_0 = false;
		if (this.genum0_0 == (GEnum0)0)
		{
			Thread.Sleep(500);
		}
		if (this.tcpClient_0 != null && this.tcpClient_0.Connected)
		{
			try
			{
				this.ra(GClass107.smethod_3(159710));
			}
			catch (Exception)
			{
			}
			try
			{
				this.tcpClient_0.Close();
				this.tcpClient_0 = null;
			}
			catch (Exception ex)
			{
				GClass126.smethod_2(GClass107.smethod_3(159735) + ex.Message, 1);
			}
		}
		if (this.bluetoothLEDevice_0 != null)
		{
			if (this.gattDeviceService_0 != null)
			{
				try
				{
					this.ra(GClass107.smethod_3(159777));
				}
				catch (Exception)
				{
				}
				try
				{
					this.gattDeviceService_0.Session.Dispose();
					this.gattDeviceService_0.Dispose();
					this.gattDeviceService_0 = null;
					GClass126.smethod_2(GClass107.smethod_3(159804), 0);
				}
				catch (Exception ex2)
				{
					GClass126.smethod_2(GClass107.smethod_3(159841) + ex2.Message, 1);
				}
			}
			try
			{
				this.bluetoothLEDevice_0.Dispose();
				this.bluetoothLEDevice_0 = null;
				GClass126.smethod_2(GClass107.smethod_3(159865), 0);
			}
			catch (Exception ex3)
			{
				GClass126.smethod_2(GClass107.smethod_3(159867) + ex3.Message, 1);
			}
		}
		if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
		{
			try
			{
				this.serialPort_0.ReadTimeout = 100;
				this.serialPort_0.WriteTimeout = 200;
				if (GClass125.smethod_44() == 4)
				{
					this.ra("ATZ");
				}
				else if (GClass125.smethod_44() == 11)
				{
					this.ra("ATZ");
				}
				else
				{
					this.ra(GClass107.smethod_3(159878));
				}
			}
			catch (Exception)
			{
			}
			try
			{
				this.serialPort_0.Close();
				GClass126.smethod_2(GClass107.smethod_3(159910), 1);
				this.serialPort_0 = null;
			}
			catch (Exception ex4)
			{
				GClass126.smethod_2(GClass107.smethod_3(159928) + ex4.Message, 1);
			}
		}
		GClass126.smethod_2(GClass107.smethod_3(159937), 1);
		GClass126.smethod_2(" ", 1);
		this.method_32(bool_7);
	}

	// Token: 0x06000270 RID: 624
	public abstract List<GClass102> r1();

	// Token: 0x06000271 RID: 625 RVA: 0x0000308F File Offset: 0x0000128F
	protected void method_23(string string_22, string string_23)
	{
		this.method_41(string_22, string_23, "", "");
	}

	// Token: 0x06000272 RID: 626 RVA: 0x0003BB48 File Offset: 0x00039D48
	private void method_24(string string_22)
	{
		GClass126.smethod_2(GClass107.smethod_3(161860) + string_22, 0);
		byte[] bytes = Encoding.ASCII.GetBytes(string_22 + this.string_12);
		if (this.stringBuilder_0.Length > 0)
		{
			GClass126.smethod_2(GClass107.smethod_3(161881) + this.stringBuilder_0.ToString() + GClass107.smethod_3(161928), 0);
		}
		this.stringBuilder_0.Clear();
		WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(this.gattCharacteristic_1.WriteValueWithResultAsync(WindowsRuntimeBufferExtensions.AsBuffer(bytes))).GetAwaiter().GetResult();
	}

	// Token: 0x06000273 RID: 627 RVA: 0x000030A3 File Offset: 0x000012A3
	protected void method_25(GClass100 gclass100_0)
	{
		if (this.gdelegate6_0 != null)
		{
			this.gdelegate6_0(this, new GEventArgs6(gclass100_0));
		}
	}

	// Token: 0x06000274 RID: 628 RVA: 0x000030BF File Offset: 0x000012BF
	protected void method_26(string string_22)
	{
		if (this.gdelegate5_0 != null)
		{
			this.gdelegate5_0(this, new GEventArgs5(false, string_22, ""));
		}
	}

	// Token: 0x06000275 RID: 629 RVA: 0x00002F0A File Offset: 0x0000110A
	public virtual void r7(List<GClass102> list_6, List<GClass104> list_7)
	{
	}

	// Token: 0x06000276 RID: 630
	public abstract void r2();

	// Token: 0x06000277 RID: 631
	protected abstract void r3(GClass104 gclass104_1);

	// Token: 0x06000278 RID: 632
	public abstract string r4(byte[] byte_3, string string_22, int int_5, int int_6, string[] string_23, string string_24);

	// Token: 0x06000279 RID: 633 RVA: 0x000030E1 File Offset: 0x000012E1
	public void method_27(GClass104 gclass104_1)
	{
		GClass11.Class1 @class = new GClass11.Class1();
		@class.<>4__this = this;
		@class.command = gclass104_1;
		new Thread(new ThreadStart(@class.method_0)).Start();
	}

	// Token: 0x0600027A RID: 634
	public abstract string vmethod_0(byte[] byte_3, string string_22, int int_5, int int_6, string[] string_23, string string_24);

	// Token: 0x0600027B RID: 635
	public abstract void vmethod_1();

	// Token: 0x0600027C RID: 636 RVA: 0x0000310B File Offset: 0x0000130B
	protected void method_28(bool bool_6, string string_22, string string_23)
	{
		if (this.gdelegate5_1 != null && this.method_18())
		{
			this.gdelegate5_1(this, new GEventArgs5(bool_6, string_22, string_23));
		}
	}

	// Token: 0x0600027D RID: 637 RVA: 0x0003BBEC File Offset: 0x00039DEC
	private string method_29()
	{
		string text = "";
		long num = (long)(GClass126.smethod_1() + 3500);
		while (!text.EndsWith(">") && !text.EndsWith("\r") && !text.EndsWith("\n") && text.Length < 250 && num > (long)GClass126.smethod_1())
		{
			if (this.tcpClient_0.Client.Available > 0)
			{
				int num2 = this.tcpClient_0.GetStream().ReadByte();
				if (num2 != -1)
				{
					text += ((char)num2).ToString();
				}
				num = (long)(GClass126.smethod_1() + 2500);
			}
			else
			{
				Thread.Sleep(1);
			}
		}
		GClass126.smethod_2(GClass107.smethod_3(161859) + text, 0);
		return text;
	}

	// Token: 0x0600027E RID: 638 RVA: 0x00003131 File Offset: 0x00001331
	public void method_30(bool bool_6)
	{
		this.r0(bool_6, false);
	}

	// Token: 0x0600027F RID: 639 RVA: 0x0000313B File Offset: 0x0000133B
	public void method_31()
	{
		this.genum0_0 = (GEnum0)0;
		this.vmethod_1();
	}

	// Token: 0x06000280 RID: 640 RVA: 0x0003BCBC File Offset: 0x00039EBC
	protected void method_32(bool bool_6)
	{
		try
		{
			if (this.gdelegate3_0 != null)
			{
				this.gdelegate3_0(this, new GEventArgs4(bool_6));
			}
		}
		catch (Exception)
		{
			GClass126.smethod_2(GClass107.smethod_3(159953), 0);
		}
		if (!GClass126.bool_0 && GClass126.int_1 > 5)
		{
			GClass125.smethod_102(19, Color.Black);
		}
	}

	// Token: 0x06000281 RID: 641 RVA: 0x0003BD24 File Offset: 0x00039F24
	protected string method_33(byte[] byte_3, string string_22, string[] string_23, string string_24)
	{
		string text = "";
		if (string_22 == "str")
		{
			text = Encoding.ASCII.GetString(byte_3).TrimEnd(this.char_0);
		}
		else if (string_22 == GClass107.smethod_3(159996))
		{
			if (byte_3.Length == 4)
			{
				text = string.Concat(new string[]
				{
					GClass127.smethod_23(byte_3[2]),
					"/",
					GClass127.smethod_23(byte_3[3]),
					"/",
					GClass127.smethod_23(byte_3[0]),
					GClass127.smethod_23(byte_3[1])
				});
			}
			else
			{
				text = GClass127.smethod_11(byte_3);
			}
		}
		else if (string_22 == "hex")
		{
			text = GClass127.smethod_11(byte_3);
		}
		else if (string_22 == GClass107.smethod_3(160004))
		{
			text = GClass127.smethod_11(byte_3).Replace(" ", "");
		}
		else if (string_22 == GClass107.smethod_3(160011))
		{
			byte[] array = new byte[byte_3.Length];
			for (int i = 0; i < byte_3.Length; i++)
			{
				array[byte_3.Length - i - 1] = byte_3[i];
			}
			text = GClass127.smethod_11(array).Replace(" ", "");
		}
		else if (string_22 == GClass107.smethod_3(160040))
		{
			text = GClass127.smethod_11(byte_3).Replace(" ", "");
		}
		else
		{
			if (string_22.StartsWith("num"))
			{
				decimal d = 0m;
				decimal num = 1m;
				if (byte_3.Length == 2 && string_22.StartsWith(GClass107.smethod_3(160052)))
				{
					d = 256 * (int)byte_3[1] + (int)byte_3[0];
				}
				else if (byte_3.Length == 1)
				{
					d = byte_3[0];
					if (string_22.StartsWith(GClass107.smethod_3(160098)) && d >= 128m)
					{
						d = (int)((byte_3[0] & 127) - 128);
					}
				}
				else if (byte_3.Length == 2)
				{
					d = 256 * (int)byte_3[0] + (int)byte_3[1];
					if (string_22.StartsWith(GClass107.smethod_3(160141)) && d >= 32768m)
					{
						d = 256 * (int)(byte_3[0] & 127) + (int)byte_3[1] - 32768;
					}
				}
				else if (byte_3.Length == 3)
				{
					d = 65536 * (int)byte_3[0] + 256 * (int)byte_3[1] + (int)byte_3[2];
				}
				else if (byte_3.Length == 4)
				{
					d = 16777216 * (int)byte_3[0] + 65536 * (int)byte_3[1] + 256 * (int)byte_3[2] + (int)byte_3[3];
				}
				else
				{
					for (int j = byte_3.Length - 1; j >= 0; j--)
					{
						d = byte_3[j] * num;
						num *= 256m;
					}
				}
				num = 1m;
				decimal d2 = 0m;
				int num2 = 0;
				List<string> list = new List<string>();
				StringBuilder stringBuilder = new StringBuilder();
				for (int k = 0; k < string_22.Length; k++)
				{
					if (string_22[k] == ',')
					{
						list.Add(stringBuilder.ToString());
						stringBuilder = new StringBuilder();
					}
					else
					{
						stringBuilder.Append(string_22[k]);
					}
				}
				list.Add(stringBuilder.ToString());
				try
				{
					if (list.Count > 1)
					{
						num2 = GClass127.smethod_37(list[1]);
					}
					if (list.Count > 2)
					{
						num = Convert.ToDecimal(list[2], NumberFormatInfo.InvariantInfo);
					}
					if (list.Count > 3)
					{
						d2 = Convert.ToDecimal(list[3], NumberFormatInfo.InvariantInfo);
					}
					d = d * num + d2;
					decimal d3 = this.decimal_0[num2];
					d /= d3;
					d = GClass127.smethod_45(d, string_24);
					if (GClass125.smethod_75() && string_24 == GClass107.smethod_3(160150))
					{
						num2 += 2;
					}
					if (GClass125.smethod_79() && string_24 == "mm")
					{
						num2 += 2;
					}
					if (GClass125.smethod_79() && string_24 == GClass107.smethod_3(160173))
					{
						num2 += 5;
					}
					text = d.ToString("F" + num2.ToString());
					goto IL_2A5E;
				}
				catch (Exception)
				{
					GClass126.smethod_2(GClass107.smethod_3(160182), 1);
					goto IL_2A5E;
				}
			}
			if (string_22.StartsWith(GClass107.smethod_3(160229)))
			{
				byte b = byte_3[0];
				int l = 0;
				while (l < string_23.Length)
				{
					byte b2 = byte.Parse(string_23[l].Substring(0, 2), NumberStyles.HexNumber);
					byte b3 = byte.Parse(string_23[l].Substring(2, 2), NumberStyles.HexNumber);
					if ((b & b2) != b3)
					{
						if (l != string_23.Length - 1)
						{
							l++;
							continue;
						}
					}
					text = string_23[l].Substring(4);
					break;
				}
			}
			else if (string_22.StartsWith(GClass107.smethod_3(160250)))
			{
				if (byte_3.Length >= 2)
				{
					byte b4 = byte_3[0];
					byte b5 = byte_3[1];
					int m = 0;
					while (m < string_23.Length)
					{
						byte b6 = byte.Parse(string_23[m].Substring(0, 2), NumberStyles.HexNumber);
						byte b7 = byte.Parse(string_23[m].Substring(2, 2), NumberStyles.HexNumber);
						byte b8 = byte.Parse(string_23[m].Substring(4, 2), NumberStyles.HexNumber);
						byte b9 = byte.Parse(string_23[m].Substring(6, 2), NumberStyles.HexNumber);
						if ((b4 & b6) != b8 || (b5 & b7) != b9)
						{
							if (m != string_23.Length - 1)
							{
								m++;
								continue;
							}
						}
						text = string_23[m].Substring(8);
						break;
					}
				}
			}
			else if (string_22 == GClass107.smethod_3(160290))
			{
				text = "";
				int n = 0;
				IL_673:
				while (n < byte_3.Length)
				{
					byte b10 = byte_3[n];
					int num3 = 0;
					while (num3 < string_23.Length)
					{
						byte b11 = byte.Parse(string_23[num3].Substring(0, 2), NumberStyles.HexNumber);
						byte b12 = byte.Parse(string_23[num3].Substring(2, 2), NumberStyles.HexNumber);
						if ((b10 & b11) != b12)
						{
							if (num3 != string_23.Length - 1)
							{
								num3++;
								continue;
							}
						}
						text += string_23[num3].Substring(4);
						IL_66D:
						n++;
						goto IL_673;
					}
					goto IL_66D;
				}
			}
			else if (string_22 == GClass107.smethod_3(160329))
			{
				text = GClass127.smethod_11(byte_3);
				if (text.Length == 2)
				{
					text = text[0].ToString() + "." + text[1].ToString();
				}
				else if (text.Length == 3)
				{
					text = string.Concat(new string[]
					{
						text[0].ToString(),
						".",
						text[1].ToString(),
						".",
						text[2].ToString()
					});
				}
			}
			else if (string_22 == GClass107.smethod_3(160355))
			{
				if (byte_3.Length == 3)
				{
					try
					{
						int year = ((byte_3[0] < 70) ? 2000 : 1900) + (int)byte_3[0];
						int num4 = (int)(byte_3[1] * 16 + byte_3[2] / 16);
						DateTime dateTime = new DateTime(year, 1, 1);
						dateTime = dateTime.AddDays((double)num4);
						text = dateTime.ToString(GClass107.smethod_3(160394));
						goto IL_2A5E;
					}
					catch (Exception)
					{
						text = "";
						goto IL_2A5E;
					}
				}
				text = GClass127.smethod_11(byte_3);
			}
			else if (string_22 == GClass107.smethod_3(160405))
			{
				if (byte_3.Length == 3)
				{
					try
					{
						int num5 = GClass127.smethod_37(GClass127.smethod_23(byte_3[0]));
						int num6 = GClass127.smethod_37(GClass127.smethod_23(byte_3[1]));
						int num7 = GClass127.smethod_37(GClass127.smethod_23(byte_3[2]));
						int year2 = ((num5 < 70) ? 2000 : 1900) + num5;
						int num8 = num6 * 10 + num7 / 10;
						DateTime dateTime2 = new DateTime(year2, 1, 1);
						dateTime2 = dateTime2.AddDays((double)num8);
						text = dateTime2.ToString(GClass107.smethod_3(160453));
						goto IL_2A5E;
					}
					catch (Exception)
					{
						text = "";
						goto IL_2A5E;
					}
				}
				text = GClass127.smethod_11(byte_3);
			}
			else if (string_22 == GClass107.smethod_3(160498))
			{
				if (byte_3.Length == 3)
				{
					try
					{
						int num9 = GClass127.smethod_37(GClass127.smethod_23(byte_3[0]));
						int num10 = GClass127.smethod_37(GClass127.smethod_23(byte_3[1]));
						int num11 = GClass127.smethod_37(GClass127.smethod_23(byte_3[2]));
						int year3 = ((num9 < 70) ? 2000 : 1900) + num9;
						int num12 = num10 * 100 + num11;
						DateTime dateTime3 = new DateTime(year3, 1, 1);
						dateTime3 = dateTime3.AddDays((double)num12);
						text = dateTime3.ToString(GClass107.smethod_3(160502));
						goto IL_2A5E;
					}
					catch (Exception)
					{
						text = "";
						goto IL_2A5E;
					}
				}
				text = GClass127.smethod_11(byte_3);
			}
			else if (string_22 == GClass107.smethod_3(160508))
			{
				if (byte_3.Length == 6)
				{
					text = string.Concat(new string[]
					{
						GClass127.smethod_23(byte_3[1]),
						"/",
						GClass127.smethod_23(byte_3[3]),
						"/",
						GClass127.smethod_23(byte_3[4]),
						GClass127.smethod_23(byte_3[5])
					});
				}
				else
				{
					text = GClass127.smethod_11(byte_3);
				}
			}
			else
			{
				if (string_22.StartsWith(GClass107.smethod_3(160536)))
				{
					if (byte_3.Length != 5)
					{
						goto IL_2A5E;
					}
					try
					{
						int num13 = 2000 + GClass127.smethod_37(byte_3[0]);
						int num14 = GClass127.smethod_37(byte_3[1]);
						int num15 = GClass127.smethod_37(byte_3[2]);
						int num16 = GClass127.smethod_37(byte_3[3]);
						int num17 = GClass127.smethod_37(byte_3[4]);
						text = string.Concat(new string[]
						{
							num15.ToString(),
							"/",
							num14.ToString(),
							"/",
							num13.ToString(),
							"  ",
							num16.ToString(),
							":",
							num17.ToString()
						});
						goto IL_2A5E;
					}
					catch (Exception)
					{
						text = "";
						goto IL_2A5E;
					}
				}
				if (string_22.StartsWith("equ"))
				{
					decimal num18 = 0m;
					decimal d4 = 0m;
					decimal d5 = 0m;
					decimal d6 = 0m;
					decimal d7 = 0m;
					int num19 = 0;
					if (byte_3.Length == 1)
					{
						num18 = byte_3[0];
						if (string_22.StartsWith(GClass107.smethod_3(160567)) && num18 > 128m)
						{
							num18 = (int)((byte_3[0] & 127) - 128);
						}
					}
					else if (byte_3.Length == 2)
					{
						num18 = 256 * (int)byte_3[0] + (int)byte_3[1];
						if (string_22.StartsWith(GClass107.smethod_3(160591)) && num18 > 32768m)
						{
							num18 = 256 * (int)(byte_3[0] & 127) + (int)byte_3[1] - 32768;
						}
					}
					List<string> list2 = new List<string>();
					StringBuilder stringBuilder2 = new StringBuilder();
					for (int num20 = 0; num20 < string_22.Length; num20++)
					{
						if (string_22[num20] == ',')
						{
							list2.Add(stringBuilder2.ToString());
							stringBuilder2 = new StringBuilder();
						}
						else
						{
							stringBuilder2.Append(string_22[num20]);
						}
					}
					list2.Add(stringBuilder2.ToString());
					try
					{
						if (list2.Count > 1)
						{
							num19 = GClass127.smethod_37(list2[1]);
						}
						if (list2.Count > 2)
						{
							d4 = Convert.ToDecimal(list2[2], NumberFormatInfo.InvariantInfo);
						}
						if (list2.Count > 3)
						{
							d5 = Convert.ToDecimal(list2[3], NumberFormatInfo.InvariantInfo);
						}
						if (list2.Count > 4)
						{
							d6 = Convert.ToDecimal(list2[4], NumberFormatInfo.InvariantInfo);
						}
						if (list2.Count > 5)
						{
							d7 = Convert.ToDecimal(list2[5], NumberFormatInfo.InvariantInfo);
						}
						num18 = d4 * (num18 * num18 * num18) + d5 * (num18 * num18) + d6 * num18 + d7;
						text = GClass127.smethod_45(num18, string_24).ToString("F" + num19.ToString());
						goto IL_2A5E;
					}
					catch (Exception)
					{
						GClass126.smethod_2(GClass107.smethod_3(160627), 1);
						goto IL_2A5E;
					}
				}
				if (string_22.StartsWith(GClass107.smethod_3(160669)))
				{
					decimal num21 = 0m;
					decimal d8 = 0m;
					decimal d9 = 0m;
					decimal d10 = 0m;
					decimal d11 = 0m;
					decimal d12 = 0m;
					decimal d13 = 0m;
					int num22 = 0;
					if (byte_3.Length != 2 && byte_3.Length != 1)
					{
						goto IL_2A5E;
					}
					num21 = byte_3[0];
					if (byte_3.Length == 1)
					{
						d8 = num21;
					}
					else
					{
						d8 = byte_3[1];
					}
					List<string> list3 = new List<string>();
					StringBuilder stringBuilder3 = new StringBuilder();
					for (int num23 = 0; num23 < string_22.Length; num23++)
					{
						if (string_22[num23] == ',')
						{
							list3.Add(stringBuilder3.ToString());
							stringBuilder3 = new StringBuilder();
						}
						else
						{
							stringBuilder3.Append(string_22[num23]);
						}
					}
					list3.Add(stringBuilder3.ToString());
					try
					{
						if (list3.Count > 1)
						{
							num22 = GClass127.smethod_37(list3[1]);
						}
						if (list3.Count > 2)
						{
							d9 = Convert.ToDecimal(list3[2], NumberFormatInfo.InvariantInfo);
						}
						if (list3.Count > 3)
						{
							d10 = Convert.ToDecimal(list3[3], NumberFormatInfo.InvariantInfo);
						}
						if (list3.Count > 4)
						{
							d11 = Convert.ToDecimal(list3[4], NumberFormatInfo.InvariantInfo);
						}
						if (list3.Count > 5)
						{
							d12 = Convert.ToDecimal(list3[5], NumberFormatInfo.InvariantInfo);
						}
						if (list3.Count > 6)
						{
							d13 = Convert.ToDecimal(list3[6], NumberFormatInfo.InvariantInfo);
						}
						decimal num24 = (d8 < d9) ? (d8 * d10 + d11) : (num21 * d12 + d13);
						text = GClass127.smethod_45(num24, string_24).ToString("F" + num22.ToString());
						goto IL_2A5E;
					}
					catch (Exception)
					{
						GClass126.smethod_2(GClass107.smethod_3(160677), 1);
						goto IL_2A5E;
					}
				}
				if (string_22.StartsWith(GClass107.smethod_3(160702)))
				{
					decimal num25 = 0m;
					decimal d14 = 0m;
					decimal d15 = 0m;
					decimal d16 = 0m;
					decimal d17 = 0m;
					decimal d18 = 0m;
					decimal d19 = 0m;
					int num26 = 0;
					if (byte_3.Length != 2 && byte_3.Length != 1)
					{
						goto IL_2A5E;
					}
					num25 = byte_3[0];
					if (byte_3.Length == 1)
					{
						d14 = num25;
					}
					else
					{
						d14 = byte_3[1];
					}
					List<string> list4 = new List<string>();
					StringBuilder stringBuilder4 = new StringBuilder();
					for (int num27 = 0; num27 < string_22.Length; num27++)
					{
						if (string_22[num27] == ',')
						{
							list4.Add(stringBuilder4.ToString());
							stringBuilder4 = new StringBuilder();
						}
						else
						{
							stringBuilder4.Append(string_22[num27]);
						}
					}
					list4.Add(stringBuilder4.ToString());
					try
					{
						if (list4.Count > 1)
						{
							num26 = GClass127.smethod_37(list4[1]);
						}
						if (list4.Count > 2)
						{
							d15 = Convert.ToDecimal(list4[2], NumberFormatInfo.InvariantInfo);
						}
						if (list4.Count > 3)
						{
							d16 = Convert.ToDecimal(list4[3], NumberFormatInfo.InvariantInfo);
						}
						if (list4.Count > 4)
						{
							d17 = Convert.ToDecimal(list4[4], NumberFormatInfo.InvariantInfo);
						}
						if (list4.Count > 5)
						{
							d18 = Convert.ToDecimal(list4[5], NumberFormatInfo.InvariantInfo);
						}
						if (list4.Count > 6)
						{
							d19 = Convert.ToDecimal(list4[6], NumberFormatInfo.InvariantInfo);
						}
						decimal num28 = (num25 < d15) ? (d14 * d16 + d17) : (num25 * d18 + d19);
						text = GClass127.smethod_45(num28, string_24).ToString("F" + num26.ToString());
						goto IL_2A5E;
					}
					catch (Exception)
					{
						GClass126.smethod_2(GClass107.smethod_3(160705), 1);
						goto IL_2A5E;
					}
				}
				if (string_22.StartsWith("eq2"))
				{
					decimal d20 = 0m;
					decimal d21 = 0m;
					decimal d22 = 0m;
					decimal d23 = 0m;
					decimal d24 = 0m;
					decimal d25 = 0m;
					int num29 = 0;
					if (byte_3.Length != 2)
					{
						goto IL_2A5E;
					}
					d20 = byte_3[0];
					d21 = byte_3[1];
					List<string> list5 = new List<string>();
					StringBuilder stringBuilder5 = new StringBuilder();
					for (int num30 = 0; num30 < string_22.Length; num30++)
					{
						if (string_22[num30] == ',')
						{
							list5.Add(stringBuilder5.ToString());
							stringBuilder5 = new StringBuilder();
						}
						else
						{
							stringBuilder5.Append(string_22[num30]);
						}
					}
					list5.Add(stringBuilder5.ToString());
					try
					{
						if (list5.Count > 1)
						{
							num29 = GClass127.smethod_37(list5[1]);
						}
						if (list5.Count > 2)
						{
							d22 = Convert.ToDecimal(list5[2], NumberFormatInfo.InvariantInfo);
						}
						if (list5.Count > 3)
						{
							d23 = Convert.ToDecimal(list5[3], NumberFormatInfo.InvariantInfo);
						}
						if (list5.Count > 4)
						{
							d24 = Convert.ToDecimal(list5[4], NumberFormatInfo.InvariantInfo);
						}
						if (list5.Count > 5)
						{
							d25 = Convert.ToDecimal(list5[5], NumberFormatInfo.InvariantInfo);
						}
						decimal num31 = d20 * d22 + d23 + (d21 * d24 + d25);
						text = GClass127.smethod_45(num31, string_24).ToString("F" + num29.ToString());
						goto IL_2A5E;
					}
					catch (Exception)
					{
						GClass126.smethod_2(GClass107.smethod_3(160722), 1);
						goto IL_2A5E;
					}
				}
				if (string_22.StartsWith("eq3"))
				{
					decimal d26 = 0m;
					decimal d27 = 0m;
					decimal d28 = 0m;
					decimal d29 = 0m;
					decimal d30 = 0m;
					decimal d31 = 0m;
					decimal d32 = 0m;
					decimal d33 = 0m;
					decimal d34 = 0m;
					int num32 = 0;
					if (byte_3.Length != 3)
					{
						goto IL_2A5E;
					}
					d26 = byte_3[0];
					d27 = byte_3[1];
					d28 = byte_3[2];
					List<string> list6 = new List<string>();
					StringBuilder stringBuilder6 = new StringBuilder();
					for (int num33 = 0; num33 < string_22.Length; num33++)
					{
						if (string_22[num33] == ',')
						{
							list6.Add(stringBuilder6.ToString());
							stringBuilder6 = new StringBuilder();
						}
						else
						{
							stringBuilder6.Append(string_22[num33]);
						}
					}
					list6.Add(stringBuilder6.ToString());
					try
					{
						if (list6.Count > 1)
						{
							num32 = GClass127.smethod_37(list6[1]);
						}
						if (list6.Count > 2)
						{
							d29 = Convert.ToDecimal(list6[2], NumberFormatInfo.InvariantInfo);
						}
						if (list6.Count > 3)
						{
							d30 = Convert.ToDecimal(list6[3], NumberFormatInfo.InvariantInfo);
						}
						if (list6.Count > 4)
						{
							d31 = Convert.ToDecimal(list6[4], NumberFormatInfo.InvariantInfo);
						}
						if (list6.Count > 5)
						{
							d32 = Convert.ToDecimal(list6[5], NumberFormatInfo.InvariantInfo);
						}
						if (list6.Count > 6)
						{
							d33 = Convert.ToDecimal(list6[6], NumberFormatInfo.InvariantInfo);
						}
						if (list6.Count > 7)
						{
							d34 = Convert.ToDecimal(list6[7], NumberFormatInfo.InvariantInfo);
						}
						decimal num34 = d26 * d29 + d30 + (d27 * d31 + d32) + (d28 * d33 + d34);
						text = GClass127.smethod_45(num34, string_24).ToString("F" + num32.ToString());
						goto IL_2A5E;
					}
					catch (Exception)
					{
						GClass126.smethod_2(GClass107.smethod_3(160732), 1);
						goto IL_2A5E;
					}
				}
				if (string_22 == GClass107.smethod_3(160780))
				{
					string str = GClass107.smethod_3(160821);
					string text2 = this.string_2;
					uint num35 = <PrivateImplementationDetails>.ComputeStringHash(text2);
					if (num35 <= 2292149841U)
					{
						if (num35 <= 1299565007U)
						{
							if (num35 <= 677968311U)
							{
								if (num35 <= 379693315U)
								{
									if (num35 != 18460279U)
									{
										if (num35 != 356418342U)
										{
											if (num35 == 379693315U)
											{
												if (text2 == "7494C9")
												{
													str = "ESM";
												}
											}
										}
										else if (text2 == "620504")
										{
											str = "BCM";
										}
									}
									else if (text2 == "7574D7")
									{
										str = "ADCM";
									}
								}
								else if (num35 != 562341775U)
								{
									if (num35 != 583578915U)
									{
										if (num35 == 677968311U)
										{
											if (text2 == "752772")
											{
												str = "ORC";
											}
										}
									}
									else if (text2 == "75A4DA")
									{
										str = "EPS";
									}
								}
								else if (text2 == "78A50A")
								{
									str = "MSM";
								}
							}
							else if (num35 <= 994510985U)
							{
								if (num35 != 717378442U)
								{
									if (num35 != 737215362U)
									{
										if (num35 == 994510985U)
										{
											if (text2 == "7424C2")
											{
												str = "IPC";
											}
										}
									}
									else if (text2 == "72772F")
									{
										str = "ETM";
									}
								}
								else if (text2 == "7A47A9")
								{
									str = "AMP";
								}
							}
							else if (num35 != 1120428656U)
							{
								if (num35 != 1298468112U)
								{
									if (num35 == 1299565007U)
									{
										if (text2 == "7474C7")
										{
											str = "ABS";
										}
									}
								}
								else if (text2 == "7BF53F")
								{
									str = "TGW";
								}
							}
							else if (text2 == "7C47CC")
							{
								str = "LBSS";
							}
						}
						else if (num35 <= 1587321159U)
						{
							if (num35 <= 1456382787U)
							{
								if (num35 != 1335477003U)
								{
									if (num35 != 1445208999U)
									{
										if (num35 == 1456382787U)
										{
											if (text2 == "74E76E")
											{
												str = "PAM";
											}
										}
									}
									else if (text2 == "785505")
									{
										str = "PDM";
									}
								}
								else if (text2 == "720728")
								{
									str = "IPC";
								}
							}
							else if (num35 != 1485195409U)
							{
								if (num35 != 1562330218U)
								{
									if (num35 == 1587321159U)
									{
										if (text2 == "7534D3")
										{
											str = "ACC";
										}
									}
								}
								else if (text2 == "72672E")
								{
									str = "BCM";
								}
							}
							else if (text2 == "740760")
							{
								str = "ABS";
							}
						}
						else if (num35 <= 1662214053U)
						{
							if (num35 != 1611174976U)
							{
								if (num35 != 1625550365U)
								{
									if (num35 == 1662214053U)
									{
										if (text2 == "791511")
										{
											str = "BSM";
										}
									}
								}
								else if (text2 == "730738")
								{
									str = "EPS";
								}
							}
							else if (text2 == "7C67CE")
							{
								str = "RBSS";
							}
						}
						else if (num35 != 1686770255U)
						{
							if (num35 != 1755048379U)
							{
								if (num35 == 2292149841U)
								{
									if (text2 == "75F4DF")
									{
										str = "EPPM";
									}
								}
							}
							else if (text2 == "792512")
							{
								str = "HSM";
							}
						}
						else if (text2 == "7634E3")
						{
							str = "SCCM";
						}
					}
					else if (num35 <= 3539044911U)
					{
						if (num35 <= 2858541363U)
						{
							if (num35 <= 2526099377U)
							{
								if (num35 != 2413029946U)
								{
									if (num35 != 2474835051U)
									{
										if (num35 == 2526099377U)
										{
											if (text2 == "7444C4")
											{
												str = "ORC";
											}
										}
									}
									else if (text2 == "743763")
									{
										str = "IPC";
									}
								}
								else if (text2 == "7BE53E")
								{
									str = "AMP";
								}
							}
							else if (num35 != 2660481513U)
							{
								if (num35 != 2702240669U)
								{
									if (num35 == 2858541363U)
									{
										if (text2 == "7E17E9")
										{
											str = "TCM";
										}
									}
								}
								else if (text2 == "78F50F")
								{
									str = "ITM";
								}
							}
							else if (text2 == "74B4CB")
							{
								str = "DTCM";
							}
						}
						else if (num35 <= 3380229511U)
						{
							if (num35 != 3026440697U)
							{
								if (num35 != 3209964241U)
								{
									if (num35 == 3380229511U)
									{
										if (text2 == "783503")
										{
											str = "HVAC";
										}
									}
								}
								else if (text2 == "7E07E8")
								{
									str = "PCM";
								}
							}
							else if (text2 == "7404C0")
							{
								str = "RFH";
							}
						}
						else if (num35 != 3426782431U)
						{
							if (num35 != 3481447969U)
							{
								if (num35 == 3539044911U)
								{
									if (text2 == "7434C3")
									{
										str = "TPM";
									}
								}
							}
							else if (text2 == "7684E8")
							{
								str = "AFLS";
							}
						}
						else if (text2 == "731739")
						{
							str = "RFH";
						}
					}
					else if (num35 <= 3983971473U)
					{
						if (num35 <= 3763590373U)
						{
							if (num35 != 3679808388U)
							{
								if (num35 != 3726911747U)
								{
									if (num35 == 3763590373U)
									{
										if (text2 == "799519")
										{
											str = "RBSS";
										}
									}
								}
								else if (text2 == "760768")
								{
									str = "ABS";
								}
							}
							else if (text2 == "73773F")
							{
								str = "ORC";
							}
						}
						else if (num35 != 3961910136U)
						{
							if (num35 != 3968342566U)
							{
								if (num35 == 3983971473U)
								{
									if (text2 == "74D76D")
									{
										str = "BCMX";
									}
								}
							}
							else if (text2 == "7BC53C")
							{
								str = "ICS";
							}
						}
						else if (text2 == "7BB53B")
						{
							str = "VES3";
						}
					}
					else if (num35 <= 4100781105U)
					{
						if (num35 != 3991086841U)
						{
							if (num35 != 4059368323U)
							{
								if (num35 == 4100781105U)
								{
									if (text2 == "7624E2")
									{
										str = "PTS";
									}
								}
							}
							else if (text2 == "745765")
							{
								str = "BCM";
							}
						}
						else if (text2 == "784504")
						{
							str = "DDM";
						}
					}
					else if (num35 != 4154623716U)
					{
						if (num35 != 4234699184U)
						{
							if (num35 == 4291102858U)
							{
								if (text2 == "7B9539")
								{
									str = "HFM";
								}
							}
						}
						else if (text2 == "73473C")
						{
							str = "AFLM";
						}
					}
					else if (text2 == "73373B")
					{
						str = "HVAC";
					}
					text = str + GClass127.smethod_11(byte_3).Replace(" ", "");
				}
				else if (string_22 == GClass107.smethod_3(160849))
				{
					string str2 = GClass107.smethod_3(160885);
					byte b13 = this.byte_0;
					if (b13 <= 98)
					{
						if (b13 <= 31)
						{
							if (b13 != 1)
							{
								if (b13 != 16)
								{
									switch (b13)
									{
									case 24:
										str2 = "TCM";
										break;
									case 26:
										str2 = GClass107.smethod_3(160933);
										break;
									case 29:
										str2 = "PTU";
										break;
									case 30:
										str2 = "RDM";
										break;
									case 31:
										str2 = "ESM";
										break;
									}
								}
								else
								{
									str2 = "ECM";
								}
							}
							else
							{
								str2 = "DCU";
							}
						}
						else if (b13 <= 48)
						{
							switch (b13)
							{
							case 40:
								str2 = "ABS";
								break;
							case 41:
								break;
							case 42:
								str2 = GClass107.smethod_3(160934);
								break;
							case 43:
								str2 = "EPB";
								break;
							default:
								if (b13 == 48)
								{
									str2 = "EPS";
								}
								break;
							}
						}
						else if (b13 != 49)
						{
							switch (b13)
							{
							case 64:
								str2 = "BCM";
								break;
							case 65:
								str2 = GClass107.smethod_3(160979);
								break;
							case 66:
								str2 = GClass107.smethod_3(161023);
								break;
							case 67:
								str2 = "PIM";
								break;
							case 68:
								str2 = GClass107.smethod_3(161055);
								break;
							case 69:
								str2 = "EAC";
								break;
							case 71:
								str2 = GClass107.smethod_3(161063);
								break;
							case 72:
								str2 = "RBC";
								break;
							case 74:
								str2 = "TTM";
								break;
							case 75:
								str2 = "HCP";
								break;
							case 80:
								str2 = GClass107.smethod_3(161103);
								break;
							case 84:
								str2 = GClass107.smethod_3(161119);
								break;
							case 85:
								str2 = GClass107.smethod_3(161146);
								break;
							case 86:
								str2 = GClass107.smethod_3(161167);
								break;
							case 87:
								str2 = GClass107.smethod_3(161204);
								break;
							case 88:
								str2 = "OCM";
								break;
							case 96:
								str2 = "IPC";
								break;
							case 98:
								str2 = GClass107.smethod_3(161251);
								break;
							}
						}
						else
						{
							str2 = GClass107.smethod_3(160944);
						}
					}
					else if (b13 <= 136)
					{
						if (b13 <= 106)
						{
							if (b13 != 101)
							{
								if (b13 == 106)
								{
									str2 = "DSM";
								}
							}
							else
							{
								str2 = GClass107.smethod_3(161298);
							}
						}
						else if (b13 != 113)
						{
							switch (b13)
							{
							case 130:
								str2 = "RRM";
								break;
							case 131:
								str2 = "AMP";
								break;
							case 132:
								str2 = "CDM";
								break;
							case 133:
								str2 = "ICS";
								break;
							case 135:
								str2 = "ETM";
								break;
							case 136:
								str2 = "DTV";
								break;
							}
						}
						else
						{
							str2 = GClass107.smethod_3(161310);
						}
					}
					else if (b13 <= 163)
					{
						if (b13 != 152)
						{
							switch (b13)
							{
							case 160:
								str2 = "PAM";
								break;
							case 161:
								str2 = "TPM";
								break;
							case 162:
								str2 = "MSM";
								break;
							case 163:
								str2 = "PSM";
								break;
							}
						}
						else
						{
							str2 = GClass107.smethod_3(161359);
						}
					}
					else
					{
						switch (b13)
						{
						case 192:
							str2 = "ORC";
							break;
						case 193:
						case 195:
						case 197:
						case 202:
						case 204:
						case 205:
						case 206:
						case 207:
							break;
						case 194:
							str2 = GClass107.smethod_3(161393);
							break;
						case 196:
							str2 = "ESL";
							break;
						case 198:
							str2 = "TBM";
							break;
						case 199:
							str2 = "RFH";
							break;
						case 200:
							str2 = "DDM";
							break;
						case 201:
							str2 = "PDM";
							break;
						case 203:
							str2 = "SGW";
							break;
						case 208:
							str2 = GClass107.smethod_3(161416);
							break;
						default:
							if (b13 == 217)
							{
								str2 = GClass107.smethod_3(161422);
							}
							break;
						}
					}
					if (this.string_2 == "F4")
					{
						text = str2 + "4" + GClass127.smethod_11(byte_3).Replace(" ", "");
					}
					else
					{
						text = str2 + GClass127.smethod_11(byte_3).Replace(" ", "");
					}
				}
				else if (string_22 == GClass107.smethod_3(161433))
				{
					if (byte_3.Length == 1)
					{
						text = (byte_3[0].ToString() ?? "");
					}
					else if (byte_3.Length == 2)
					{
						text = byte_3[0].ToString() + "." + byte_3[1].ToString();
					}
					else if (byte_3.Length == 3)
					{
						text = string.Concat(new string[]
						{
							byte_3[0].ToString(),
							".",
							byte_3[1].ToString(),
							".",
							byte_3[2].ToString()
						});
					}
				}
				else
				{
					if (string_22.StartsWith("nmi"))
					{
						decimal num36 = 0m;
						if (byte_3.Length == 1)
						{
							num36 = byte_3[0];
						}
						else if (byte_3.Length == 2)
						{
							num36 = 256 * (int)byte_3[0] + (int)byte_3[1];
						}
						else if (byte_3.Length == 3)
						{
							num36 = 65536 * (int)byte_3[0] + 256 * (int)byte_3[1] + (int)byte_3[2];
						}
						else if (byte_3.Length == 4)
						{
							num36 = 16777216 * (int)byte_3[0] + 65536 * (int)byte_3[1] + 256 * (int)byte_3[2] + (int)byte_3[3];
						}
						decimal d35 = 1m;
						decimal d36 = 0m;
						int num37 = 0;
						decimal num38 = 0m;
						List<string> list7 = new List<string>();
						StringBuilder stringBuilder7 = new StringBuilder();
						for (int num39 = 0; num39 < string_22.Length; num39++)
						{
							if (string_22[num39] == ',')
							{
								list7.Add(stringBuilder7.ToString());
								stringBuilder7 = new StringBuilder();
							}
							else
							{
								stringBuilder7.Append(string_22[num39]);
							}
						}
						list7.Add(stringBuilder7.ToString());
						try
						{
							if (list7.Count > 1)
							{
								num37 = GClass127.smethod_37(list7[1]);
							}
							if (list7.Count > 2)
							{
								d35 = Convert.ToDecimal(list7[2], NumberFormatInfo.InvariantInfo);
							}
							if (list7.Count > 3)
							{
								d36 = Convert.ToDecimal(list7[3], NumberFormatInfo.InvariantInfo);
							}
							if (list7.Count > 4)
							{
								num38 = Convert.ToDecimal(list7[4], NumberFormatInfo.InvariantInfo);
							}
							if (num36 != 0m)
							{
								num36 = d35 / num36 + d36;
							}
							if (num38 != 0m && num36 < num38)
							{
								num36 = 0m;
							}
							text = num36.ToString("F" + num37.ToString());
							goto IL_2A5E;
						}
						catch (Exception)
						{
							GClass126.smethod_2(GClass107.smethod_3(161448), 1);
							goto IL_2A5E;
						}
					}
					if (string_22.StartsWith("nm"))
					{
						decimal num40 = 0m;
						decimal d37 = 1m;
						decimal d38 = 0m;
						int num41 = 0;
						byte b14 = byte.MaxValue;
						byte b15 = byte.MaxValue;
						byte b16 = byte.MaxValue;
						List<string> list8 = new List<string>();
						StringBuilder stringBuilder8 = new StringBuilder();
						for (int num42 = 0; num42 < string_22.Length; num42++)
						{
							if (string_22[num42] == ',')
							{
								list8.Add(stringBuilder8.ToString());
								stringBuilder8 = new StringBuilder();
							}
							else
							{
								stringBuilder8.Append(string_22[num42]);
							}
						}
						list8.Add(stringBuilder8.ToString());
						try
						{
							if (list8.Count > 1)
							{
								num41 = GClass127.smethod_37(list8[1]);
							}
							if (list8.Count > 2)
							{
								d37 = Convert.ToDecimal(list8[2], NumberFormatInfo.InvariantInfo);
							}
							if (list8.Count > 3)
							{
								d38 = Convert.ToDecimal(list8[3], NumberFormatInfo.InvariantInfo);
							}
							if (list8.Count > 4)
							{
								if (list8[4].Length > 1)
								{
									b14 = byte.Parse(list8[4].Substring(0, 2), NumberStyles.HexNumber);
								}
								if (list8[4].Length > 3)
								{
									b15 = byte.Parse(list8[4].Substring(2, 2), NumberStyles.HexNumber);
								}
								if (list8[4].Length > 5)
								{
									b16 = byte.Parse(list8[4].Substring(4, 2), NumberStyles.HexNumber);
								}
							}
							if (byte_3.Length == 2 && string_22.StartsWith("nmw"))
							{
								num40 = 256 * (int)(byte_3[1] & b15) + (int)(byte_3[0] & b14);
							}
							else if (byte_3.Length == 1)
							{
								num40 = (int)(byte_3[0] & b14);
								if (string_22.StartsWith("nms") && num40 >= 128m)
								{
									num40 = (int)((byte_3[0] & b14 & 127) - 128);
								}
							}
							else if (byte_3.Length == 2)
							{
								num40 = 256 * (int)(byte_3[0] & b14) + (int)(byte_3[1] & b15);
								if (string_22.StartsWith("nms") && num40 >= 32768m)
								{
									num40 = 256 * (int)(byte_3[0] & b14 & 127) + (int)(byte_3[1] & b15) - 32768;
								}
							}
							else if (byte_3.Length == 3)
							{
								num40 = 65536 * (int)(byte_3[0] & b14) + 256 * (int)(byte_3[1] & b15) + (int)(byte_3[2] & b16);
							}
							num40 = num40 * d37 + d38;
							text = string.Format(this.string_13[num41], num40);
							goto IL_2A5E;
						}
						catch (Exception)
						{
							text = "-";
							if (num41 == 1)
							{
								text = "-.-";
							}
							else if (num41 == 2)
							{
								text = GClass107.smethod_3(161475);
							}
							else if (num41 == 3)
							{
								text = GClass107.smethod_3(161507);
							}
							goto IL_2A5E;
						}
					}
					if (string_22.StartsWith("bn1"))
					{
						string text3 = GClass127.smethod_11(byte_3).Replace(" ", "");
						decimal num43 = 0m;
						try
						{
							num43 = 0.1m * Convert.ToInt32(text3.Substring(0, 3));
							text = string.Format(this.string_13[1], num43);
							goto IL_2A5E;
						}
						catch (Exception)
						{
							text = GClass107.smethod_3(161549);
							goto IL_2A5E;
						}
					}
					if (string_22.StartsWith("bn2"))
					{
						string text4 = GClass127.smethod_11(byte_3).Replace(" ", "");
						try
						{
							text = text4.Substring(0, 2) + ":" + text4.Substring(2, 2);
							goto IL_2A5E;
						}
						catch (Exception)
						{
							text = GClass107.smethod_3(161568);
							goto IL_2A5E;
						}
					}
					if (string_22.StartsWith("bn3"))
					{
						string text5 = GClass127.smethod_11(byte_3).Replace(" ", "");
						decimal num44 = 0m;
						try
						{
							num44 = 0.1m * Convert.ToInt32(text5.Substring(1, 3));
							text = string.Format(this.string_13[1], num44);
							goto IL_2A5E;
						}
						catch (Exception)
						{
							text = GClass107.smethod_3(161606);
							goto IL_2A5E;
						}
					}
					if (string_22.StartsWith(GClass107.smethod_3(161624)))
					{
						if (byte_3.Length == 6)
						{
							text = string.Concat(new string[]
							{
								GClass127.smethod_23(byte_3[0]),
								":",
								GClass127.smethod_23(byte_3[1]),
								"  ",
								GClass127.smethod_23(byte_3[2]),
								"/",
								GClass127.smethod_23(byte_3[3]),
								"/",
								GClass127.smethod_23(byte_3[4]),
								GClass127.smethod_23(byte_3[5])
							});
						}
						else
						{
							text = GClass127.smethod_11(byte_3);
						}
					}
					else if (string_22.StartsWith(GClass107.smethod_3(161630)))
					{
						if (byte_3.Length == 4)
						{
							text = string.Concat(new string[]
							{
								GClass127.smethod_23(byte_3[0]),
								"/",
								GClass127.smethod_23(byte_3[1]),
								"/",
								GClass127.smethod_23(byte_3[3]),
								GClass127.smethod_23(byte_3[2])
							});
						}
						else
						{
							text = GClass127.smethod_11(byte_3);
						}
					}
				}
			}
		}
		IL_2A5E:
		if (GClass126.bool_0)
		{
			return text;
		}
		if (GClass126.int_1 != 0 && GClass126.smethod_1() > 15654 + 7298 * GClass126.int_1)
		{
			GClass126.smethod_2(GClass107.smethod_3(161637), 0);
			text = "";
			if (this.bool_1)
			{
				return text;
			}
			GClass126.smethod_2(GClass107.smethod_3(161685), 1);
			this.bool_1 = true;
			this.bool_0 = false;
			Thread.Sleep(850);
			if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
			{
				try
				{
					this.serialPort_0.Close();
					GClass126.smethod_2(GClass107.smethod_3(161733), 1);
				}
				catch (Exception ex)
				{
					GClass126.smethod_2(GClass107.smethod_3(161763) + ex.Message, 1);
				}
				GClass126.smethod_2(GClass107.smethod_3(161776), 1);
				GClass126.smethod_2(" ", 1);
			}
			if (GClass126.int_1 < 12)
			{
				this.method_32(true);
			}
		}
		return text;
	}

	// Token: 0x06000282 RID: 642 RVA: 0x0003EA08 File Offset: 0x0003CC08
	private string method_34()
	{
		string text = "";
		if (this.gattDeviceService_0 == null)
		{
			throw new Exception(GClass107.smethod_3(161965));
		}
		long num = (long)(GClass126.smethod_1() + 3500);
		while (!text.EndsWith(">") && num > (long)GClass126.smethod_1() && text.Length < 6000)
		{
			if (this.stringBuilder_0.Length > 0)
			{
				text += this.stringBuilder_0[0].ToString();
				this.stringBuilder_0.Remove(0, 1);
				num = (long)(GClass126.smethod_1() + 2500);
			}
			else
			{
				Thread.Sleep(5);
			}
		}
		GClass126.smethod_2(GClass107.smethod_3(161980) + text, 0);
		return text;
	}

	// Token: 0x06000283 RID: 643 RVA: 0x0000314A File Offset: 0x0000134A
	public byte[] method_35()
	{
		return this.byte_2;
	}

	// Token: 0x06000284 RID: 644 RVA: 0x0003EAC8 File Offset: 0x0003CCC8
	protected void method_36()
	{
		if (this.gdelegate4_0 != null)
		{
			this.gdelegate4_0(this, new GEventArgs3());
		}
		if (!GClass126.bool_15 && GClass125.smethod_101(19).B == 0)
		{
			this.bool_1 = true;
		}
		if (!GClass126.string_14.StartsWith(GClass122.smethod_2()))
		{
			this.bool_1 = true;
		}
		GClass123.int_6 = 0;
	}

	// Token: 0x06000285 RID: 645 RVA: 0x00003152 File Offset: 0x00001352
	public void method_37(GClass104 gclass104_1)
	{
		this.method_39(gclass104_1, 0);
	}

	// Token: 0x06000286 RID: 646 RVA: 0x0000315C File Offset: 0x0000135C
	protected void method_38(bool bool_6, string string_22, string string_23)
	{
		if (this.gdelegate5_0 != null)
		{
			this.gdelegate5_0(this, new GEventArgs5(bool_6, string_22, string_23));
		}
	}

	// Token: 0x06000287 RID: 647 RVA: 0x0000317A File Offset: 0x0000137A
	public void method_39(GClass104 gclass104_1, int int_5)
	{
		this.gclass104_0 = gclass104_1;
		this.int_4 = int_5;
		this.genum0_0 = (GEnum0)3;
		this.vmethod_1();
	}

	// Token: 0x06000288 RID: 648 RVA: 0x00003197 File Offset: 0x00001397
	public void method_40()
	{
		GClass126.bool_25 = false;
		this.genum0_0 = (GEnum0)2;
		this.vmethod_1();
	}

	// Token: 0x06000289 RID: 649 RVA: 0x0003EB2C File Offset: 0x0003CD2C
	protected void method_41(string string_22, string string_23, string string_24, string string_25)
	{
		if (GClass125.smethod_48())
		{
			this.tcpClient_0 = new TcpClient();
			this.tcpClient_0.SendTimeout = 1000;
			this.tcpClient_0.ReceiveTimeout = 2000;
			if (!this.tcpClient_0.BeginConnect(GClass125.smethod_50(), GClass125.smethod_51(), null, null).AsyncWaitHandle.WaitOne(2000) || !this.tcpClient_0.Connected)
			{
				throw new Exception(GClass107.smethod_3(162194));
			}
			GClass126.smethod_2(GClass107.smethod_3(162229), 0);
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
		}
		else if (GClass125.smethod_52())
		{
			GClass126.smethod_2(GClass107.smethod_3(162247), 0);
			this.bluetoothLEDevice_0 = WindowsRuntimeSystemExtensions.AsTask<BluetoothLEDevice>(BluetoothLEDevice.FromBluetoothAddressAsync(ulong.Parse(GClass125.smethod_53(), NumberStyles.HexNumber))).GetAwaiter().GetResult();
			GClass126.smethod_2(GClass107.smethod_3(162269), 0);
			GattDeviceServicesResult result = WindowsRuntimeSystemExtensions.AsTask<GattDeviceServicesResult>(this.bluetoothLEDevice_0.GetGattServicesForUuidAsync(Guid.Parse(GClass125.string_8), 1)).GetAwaiter().GetResult();
			if (result.Status == null)
			{
				GClass126.smethod_2(GClass107.smethod_3(162291), 0);
				this.gattDeviceService_0 = result.Services[0];
				GattCharacteristicsResult result2 = WindowsRuntimeSystemExtensions.AsTask<GattCharacteristicsResult>(this.gattDeviceService_0.GetCharacteristicsAsync()).GetAwaiter().GetResult();
				if (result2.Status == null)
				{
					foreach (GattCharacteristic gattCharacteristic in result2.Characteristics)
					{
						if (gattCharacteristic.Uuid == Guid.Parse(GClass125.string_9))
						{
							this.gattCharacteristic_0 = gattCharacteristic;
						}
						if (gattCharacteristic.Uuid == Guid.Parse(GClass125.string_10))
						{
							this.gattCharacteristic_1 = gattCharacteristic;
						}
					}
				}
				if (this.gattCharacteristic_1 != null && this.gattCharacteristic_0 != null)
				{
					GClass126.smethod_2(GClass107.smethod_3(162327), 0);
				}
				else
				{
					GClass126.smethod_2(GClass107.smethod_3(162310), 0);
				}
				WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(this.gattCharacteristic_0.WriteClientCharacteristicConfigurationDescriptorWithResultAsync(1)).GetAwaiter();
				GattCharacteristic @object = this.gattCharacteristic_0;
				WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>>(new Func<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>, EventRegistrationToken>(@object.add_ValueChanged), new Action<EventRegistrationToken>(@object.remove_ValueChanged), new TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>(this.method_43));
				if (this.genum0_0 == (GEnum0)0)
				{
					Thread.Sleep(100);
				}
			}
		}
		else
		{
			this.serialPort_0 = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
			this.serialPort_0.WriteTimeout = 5000;
			this.serialPort_0.WriteBufferSize = 2;
			this.serialPort_0.ReadBufferSize = 1000;
			this.serialPort_0.ReceivedBytesThreshold = 1000;
			this.serialPort_0.Handshake = Handshake.None;
			this.serialPort_0.NewLine = "\r";
			this.serialPort_0.Open();
			GClass126.smethod_2(GClass107.smethod_3(162344), 1);
			if (GClass125.smethod_46())
			{
				this.serialPort_0.ReadTimeout = 5000;
			}
			else
			{
				this.serialPort_0.ReadTimeout = 3000;
			}
		}
		this.string_12 = "\r";
		GClass126.smethod_2(GClass107.smethod_3(162350), 1);
		this.r9("ATZ");
		GClass126.smethod_2(GClass107.smethod_3(162364), 1);
		if (!this.rb().Contains(GClass107.smethod_3(162367)))
		{
			GClass126.smethod_2(GClass107.smethod_3(162401), 1);
		}
		if (string_22 != "" && string_23 != "")
		{
			this.ra(GClass107.smethod_3(162418) + string_22);
			this.ra(GClass107.smethod_3(162447));
			this.ra(GClass107.smethod_3(162488) + string_23);
			this.ra(GClass107.smethod_3(162513));
			if (string_24 != "" && string_25 != "")
			{
				this.ra(GClass107.smethod_3(162557) + string_24);
				this.ra(GClass107.smethod_3(162577));
				this.ra(GClass107.smethod_3(162601) + string_25);
				this.ra(GClass107.smethod_3(162650));
			}
			this.r9("ATZ");
			this.rb();
		}
		if (GClass125.smethod_44() == 11)
		{
			this.serialPort_0.ReadTimeout = 100;
			this.r9(GClass107.smethod_3(162672));
			string text = ((char)this.serialPort_0.ReadByte()).ToString() ?? "";
			while (!text.Contains(GClass107.smethod_3(162694)) && !text.Contains("?") && text.Length < 20)
			{
				text += ((char)this.serialPort_0.ReadByte()).ToString();
			}
			this.serialPort_0.BaudRate = 230400;
			this.serialPort_0.ReadTimeout = 80;
			text = (((char)this.serialPort_0.ReadByte()).ToString() ?? "");
			while (!text.Contains("\r") && text.Length < 20)
			{
				text += ((char)this.serialPort_0.ReadByte()).ToString();
			}
			this.ra("");
		}
		if (this.serialPort_0 != null)
		{
			if (GClass125.smethod_46())
			{
				this.serialPort_0.ReadTimeout = 2500;
				return;
			}
			this.serialPort_0.ReadTimeout = 2100;
		}
	}

	// Token: 0x0600028A RID: 650 RVA: 0x0003F12C File Offset: 0x0003D32C
	protected void method_42()
	{
		if (GClass125.smethod_48())
		{
			this.tcpClient_0 = new TcpClient();
			this.tcpClient_0.SendTimeout = 1000;
			this.tcpClient_0.ReceiveTimeout = 2000;
			if (!this.tcpClient_0.BeginConnect(GClass125.smethod_50(), GClass125.smethod_51(), null, null).AsyncWaitHandle.WaitOne(2300) || !this.tcpClient_0.Connected)
			{
				throw new Exception(GClass107.smethod_3(162728));
			}
			GClass126.smethod_2(GClass107.smethod_3(162741), 0);
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
		}
		else if (GClass125.smethod_52())
		{
			GClass126.smethod_2(GClass107.smethod_3(162768), 0);
			this.bluetoothLEDevice_0 = WindowsRuntimeSystemExtensions.AsTask<BluetoothLEDevice>(BluetoothLEDevice.FromBluetoothAddressAsync(ulong.Parse(GClass125.smethod_53(), NumberStyles.HexNumber))).GetAwaiter().GetResult();
			GClass126.smethod_2(GClass107.smethod_3(162780), 0);
			GattDeviceServicesResult result = WindowsRuntimeSystemExtensions.AsTask<GattDeviceServicesResult>(this.bluetoothLEDevice_0.GetGattServicesForUuidAsync(Guid.Parse(GClass125.string_5), 1)).GetAwaiter().GetResult();
			if (result.Status == null)
			{
				GClass126.smethod_2(GClass107.smethod_3(162816), 0);
				this.gattDeviceService_0 = result.Services[0];
				GattCharacteristicsResult result2 = WindowsRuntimeSystemExtensions.AsTask<GattCharacteristicsResult>(this.gattDeviceService_0.GetCharacteristicsAsync()).GetAwaiter().GetResult();
				if (result2.Status == null)
				{
					foreach (GattCharacteristic gattCharacteristic in result2.Characteristics)
					{
						if (gattCharacteristic.Uuid == Guid.Parse(GClass125.string_6))
						{
							this.gattCharacteristic_0 = gattCharacteristic;
						}
						if (gattCharacteristic.Uuid == Guid.Parse(GClass125.string_7))
						{
							this.gattCharacteristic_1 = gattCharacteristic;
						}
					}
				}
				if (this.gattCharacteristic_1 != null && this.gattCharacteristic_0 != null)
				{
					GClass126.smethod_2(GClass107.smethod_3(162856), 0);
				}
				else
				{
					GClass126.smethod_2(GClass107.smethod_3(162843), 0);
				}
				WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(this.gattCharacteristic_0.WriteClientCharacteristicConfigurationDescriptorWithResultAsync(1)).GetAwaiter();
				GattCharacteristic @object = this.gattCharacteristic_0;
				WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>>(new Func<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>, EventRegistrationToken>(@object.add_ValueChanged), new Action<EventRegistrationToken>(@object.remove_ValueChanged), new TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>(this.method_44));
				if (this.genum0_0 == (GEnum0)0)
				{
					Thread.Sleep(100);
				}
			}
		}
		else
		{
			this.serialPort_0 = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
			this.serialPort_0.WriteTimeout = 5000;
			this.serialPort_0.WriteBufferSize = 2;
			this.serialPort_0.ReadBufferSize = 1000;
			this.serialPort_0.ReceivedBytesThreshold = 1000;
			this.serialPort_0.Handshake = Handshake.None;
			this.serialPort_0.NewLine = "\r";
			this.serialPort_0.Open();
			GClass126.smethod_2(GClass107.smethod_3(162884), 1);
			if (GClass125.smethod_46())
			{
				this.serialPort_0.ReadTimeout = 5000;
			}
			else
			{
				this.serialPort_0.ReadTimeout = 3000;
			}
		}
		this.string_12 = "\r";
		GClass126.smethod_2(GClass107.smethod_3(162923), 1);
		this.r9("ATZ");
		GClass126.smethod_2(GClass107.smethod_3(162938), 1);
		if (!this.rb().Contains(GClass107.smethod_3(162977)))
		{
			GClass126.smethod_2(GClass107.smethod_3(163000), 1);
			throw new Exception(GClass107.smethod_3(163023));
		}
		if (this.serialPort_0 != null)
		{
			if (GClass125.smethod_46())
			{
				this.serialPort_0.ReadTimeout = 2500;
				return;
			}
			this.serialPort_0.ReadTimeout = 2100;
		}
	}

	// Token: 0x0600028B RID: 651 RVA: 0x0003F534 File Offset: 0x0003D734
	protected GClass11()
	{
		char[] array = new char[2];
		array[0] = ' ';
		this.char_0 = array;
		base..ctor();
	}

	// Token: 0x0600028C RID: 652 RVA: 0x000031AC File Offset: 0x000013AC
	[CompilerGenerated]
	private void method_43(GattCharacteristic gattCharacteristic_2, GattValueChangedEventArgs gattValueChangedEventArgs_0)
	{
		this.stringBuilder_0.Append(Encoding.ASCII.GetString(WindowsRuntimeBufferExtensions.ToArray(gattValueChangedEventArgs_0.CharacteristicValue)));
	}

	// Token: 0x0600028D RID: 653 RVA: 0x000031AC File Offset: 0x000013AC
	[CompilerGenerated]
	private void method_44(GattCharacteristic gattCharacteristic_2, GattValueChangedEventArgs gattValueChangedEventArgs_0)
	{
		this.stringBuilder_0.Append(Encoding.ASCII.GetString(WindowsRuntimeBufferExtensions.ToArray(gattValueChangedEventArgs_0.CharacteristicValue)));
	}

	// Token: 0x040001A1 RID: 417
	protected byte byte_0;

	// Token: 0x040001A2 RID: 418
	protected bool bool_0;

	// Token: 0x040001A3 RID: 419
	protected bool bool_1;

	// Token: 0x040001A4 RID: 420
	protected bool bool_2;

	// Token: 0x040001A5 RID: 421
	protected bool bool_3;

	// Token: 0x040001A6 RID: 422
	protected int int_0;

	// Token: 0x040001A7 RID: 423
	protected string string_0 = "";

	// Token: 0x040001A8 RID: 424
	protected string string_1 = "";

	// Token: 0x040001A9 RID: 425
	protected string string_2 = "";

	// Token: 0x040001AA RID: 426
	protected string string_3 = "";

	// Token: 0x040001AB RID: 427
	protected List<GClass104> list_0;

	// Token: 0x040001AC RID: 428
	protected List<GClass104> list_1;

	// Token: 0x040001AD RID: 429
	public List<GClass104> list_2;

	// Token: 0x040001AE RID: 430
	protected const string string_4 = "ATGR";

	// Token: 0x040001AF RID: 431
	protected const string string_5 = "72345-67890-A";

	// Token: 0x040001B0 RID: 432
	protected const string string_6 = "Data file corrupted!";

	// Token: 0x040001B1 RID: 433
	protected bool bool_4;

	// Token: 0x040001B2 RID: 434
	protected int int_1;

	// Token: 0x040001B3 RID: 435
	protected int int_2;

	// Token: 0x040001B4 RID: 436
	protected int int_3;

	// Token: 0x040001B5 RID: 437
	protected List<string> list_3 = new List<string>();

	// Token: 0x040001B6 RID: 438
	protected string string_7 = "";

	// Token: 0x040001B7 RID: 439
	protected string string_8 = "";

	// Token: 0x040001B8 RID: 440
	protected string string_9 = "";

	// Token: 0x040001B9 RID: 441
	protected string string_10 = "";

	// Token: 0x040001BA RID: 442
	protected bool bool_5 = true;

	// Token: 0x040001BB RID: 443
	protected string string_11 = "";

	// Token: 0x040001BC RID: 444
	protected List<GClass102> list_4;

	// Token: 0x040001BD RID: 445
	protected List<GClass100> list_5;

	// Token: 0x040001BE RID: 446
	protected Random random_0 = new Random();

	// Token: 0x040001BF RID: 447
	protected SerialPort serialPort_0;

	// Token: 0x040001C0 RID: 448
	protected TcpClient tcpClient_0;

	// Token: 0x040001C1 RID: 449
	protected BluetoothLEDevice bluetoothLEDevice_0;

	// Token: 0x040001C2 RID: 450
	protected GattDeviceService gattDeviceService_0;

	// Token: 0x040001C3 RID: 451
	protected GattCharacteristic gattCharacteristic_0;

	// Token: 0x040001C4 RID: 452
	protected GattCharacteristic gattCharacteristic_1;

	// Token: 0x040001C5 RID: 453
	protected StringBuilder stringBuilder_0 = new StringBuilder(1000);

	// Token: 0x040001C6 RID: 454
	protected string string_12 = GClass107.smethod_3(159182);

	// Token: 0x040001C7 RID: 455
	protected byte[] byte_1 = new byte[]
	{
		1,
		2,
		4,
		8,
		16,
		32,
		64,
		128
	};

	// Token: 0x040001C8 RID: 456
	protected decimal[] decimal_0 = new decimal[]
	{
		1m,
		10m,
		100m,
		1000m,
		10000m,
		100000m,
		1000000m,
		10000000m,
		100000000m,
		1000000000m
	};

	// Token: 0x040001C9 RID: 457
	protected string[] string_13 = new string[]
	{
		"{0:0}",
		GClass107.smethod_3(159226),
		GClass107.smethod_3(159275),
		GClass107.smethod_3(159280),
		GClass107.smethod_3(159307),
		GClass107.smethod_3(159349),
		GClass107.smethod_3(159366),
		GClass107.smethod_3(159415),
		GClass107.smethod_3(159459)
	};

	// Token: 0x040001CA RID: 458
	protected GClass104 gclass104_0;

	// Token: 0x040001CB RID: 459
	protected int int_4;

	// Token: 0x040001CC RID: 460
	protected byte[] byte_2 = new byte[0];

	// Token: 0x040001CD RID: 461
	protected GEnum0 genum0_0;

	// Token: 0x040001CE RID: 462
	[CompilerGenerated]
	private GDelegate4 gdelegate4_0;

	// Token: 0x040001CF RID: 463
	[CompilerGenerated]
	private GDelegate3 gdelegate3_0;

	// Token: 0x040001D0 RID: 464
	[CompilerGenerated]
	private GDelegate5 gdelegate5_0;

	// Token: 0x040001D1 RID: 465
	[CompilerGenerated]
	private GDelegate5 gdelegate5_1;

	// Token: 0x040001D2 RID: 466
	[CompilerGenerated]
	private GDelegate6 gdelegate6_0;

	// Token: 0x040001D3 RID: 467
	private char[] char_0;

	// Token: 0x040001D4 RID: 468
	private const string string_14 = " ";

	// Token: 0x040001D5 RID: 469
	private const string string_15 = "";

	// Token: 0x040001D6 RID: 470
	private const string string_16 = "Send: ";

	// Token: 0x040001D7 RID: 471
	private const string string_17 = "OK";

	// Token: 0x040001D8 RID: 472
	private const string string_18 = "[";

	// Token: 0x040001D9 RID: 473
	private const string string_19 = "] failed!";

	// Token: 0x040001DA RID: 474
	private const string string_20 = ">";

	// Token: 0x040001DB RID: 475
	private const string string_21 = "Response: ";

	// Token: 0x0200002D RID: 45
	[CompilerGenerated]
	private sealed class Class1
	{
		// Token: 0x0600028F RID: 655 RVA: 0x000031CF File Offset: 0x000013CF
		internal void method_0()
		{
			this.<>4__this.r3(this.command);
		}

		// Token: 0x040001DC RID: 476
		public GClass11 <>4__this;

		// Token: 0x040001DD RID: 477
		public GClass104 command;
	}
}
