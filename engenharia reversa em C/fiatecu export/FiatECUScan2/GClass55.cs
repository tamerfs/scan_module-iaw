using System;
using System.IO.Ports;
using System.Management;
using System.Threading;

// Token: 0x02000054 RID: 84
public static class GClass55
{
	// Token: 0x06000223 RID: 547 RVA: 0x0005BFB8 File Offset: 0x0005A1B8
	public static void smethod_0()
	{
		SerialPort serialPort = null;
		try
		{
			GClass3.smethod_2("Switching OBDkey to VagCom mode....", 1);
			serialPort = new SerialPort(GClass61.smethod_39(), GClass61.smethod_41(), Parity.None, 8, StopBits.One);
			serialPort.WriteBufferSize = 2;
			serialPort.ReceivedBytesThreshold = 1000;
			serialPort.Handshake = Handshake.None;
			serialPort.NewLine = "\r";
			serialPort.Open();
			GClass3.smethod_2("Serial port opened!", 1);
			serialPort.ReadTimeout = 5000;
			GClass55.smethod_10(serialPort, "ATZ");
			string text = GClass55.smethod_12(serialPort);
			if (!text.Contains("OBDKey"))
			{
				GClass3.smethod_2("Invalid OBDKey interface!", 1);
				throw new Exception("Invalid OBDKey interface!");
			}
			GClass55.smethod_10(serialPort, "ATL");
			serialPort.ReadTimeout = 500;
			byte b = 0;
			while (b != 6)
			{
				b = (byte)serialPort.ReadByte();
				GClass3.smethod_2("Received: " + GClass16.smethod_0(b), 0);
			}
			serialPort.Write(new byte[]
			{
				3
			}, 0, 1);
			GClass3.smethod_2("Sent: 03 03", 0);
			serialPort.Write(new byte[]
			{
				3
			}, 0, 1);
			GClass3.smethod_2("Sent: 03 03", 0);
			GClass3.smethod_2("... done!", 1);
		}
		catch (Exception ex)
		{
			GClass3.smethod_2(ex.Message, 1);
			GClass3.smethod_2(".... failed!", 1);
		}
		finally
		{
			if (serialPort != null && serialPort.IsOpen)
			{
				try
				{
					serialPort.Close();
					GClass3.smethod_2("Serial port closed!", 1);
				}
				catch (Exception ex2)
				{
					GClass3.smethod_2("ERROR: Failed to close serial port: " + ex2.Message, 1);
				}
				GClass3.smethod_2("-------------------------------------", 1);
				GClass3.smethod_2(" ", 1);
			}
		}
	}

	// Token: 0x06000224 RID: 548 RVA: 0x00002F0C File Offset: 0x0000110C
	public static void smethod_1(bool bool_0)
	{
		GClass55.smethod_2(bool_0, string.Empty, 0);
	}

	// Token: 0x06000225 RID: 549 RVA: 0x0005C1A8 File Offset: 0x0005A3A8
	public static void smethod_2(bool bool_0, string string_2, int int_0)
	{
		SerialPort serialPort = null;
		try
		{
			GClass3.smethod_2("Switching OBDkey to ELM mode....", 1);
			if (string_2 == string.Empty)
			{
				serialPort = new SerialPort(GClass61.smethod_39(), GClass61.smethod_41(), Parity.None, 8, StopBits.One);
			}
			else
			{
				serialPort = new SerialPort(string_2, int_0, Parity.None, 8, StopBits.One);
			}
			serialPort.WriteBufferSize = 2;
			serialPort.ReceivedBytesThreshold = 1000;
			serialPort.Handshake = Handshake.None;
			serialPort.NewLine = "\r";
			serialPort.Open();
			GClass3.smethod_2("Serial port opened!", 1);
			serialPort.ReadTimeout = 50;
			GClass55.smethod_10(serialPort, "A");
			if (!bool_0)
			{
				Thread.Sleep(2000);
			}
			GClass3.smethod_2("... done!", 1);
		}
		catch (Exception ex)
		{
			GClass3.smethod_2(ex.Message, 1);
			GClass3.smethod_2(".... failed!", 1);
		}
		finally
		{
			if (serialPort != null && serialPort.IsOpen)
			{
				try
				{
					serialPort.Close();
					GClass3.smethod_2("Serial port closed!", 1);
				}
				catch (Exception ex2)
				{
					GClass3.smethod_2("ERROR: Failed to close serial port: " + ex2.Message, 1);
				}
				GClass3.smethod_2("-------------------------------------", 1);
				GClass3.smethod_2(" ", 1);
			}
		}
	}

	// Token: 0x06000226 RID: 550 RVA: 0x00002F1A File Offset: 0x0000111A
	public static bool smethod_3()
	{
		return GClass55.smethod_4(string.Empty, 0);
	}

	// Token: 0x06000227 RID: 551 RVA: 0x0005C2F0 File Offset: 0x0005A4F0
	public static bool smethod_4(string string_2, int int_0)
	{
		bool flag = false;
		SerialPort serialPort = null;
		try
		{
			GClass3.smethod_2("Checking OBDkey for ELM mode....", 1);
			try
			{
				if (string_2 == string.Empty)
				{
					serialPort = new SerialPort(GClass61.smethod_39(), GClass61.smethod_41(), Parity.None, 8, StopBits.One);
				}
				else
				{
					serialPort = new SerialPort(string_2, int_0, Parity.None, 8, StopBits.One);
				}
				serialPort.WriteBufferSize = 2;
				serialPort.ReceivedBytesThreshold = 1000;
				serialPort.Handshake = Handshake.None;
				serialPort.NewLine = "\r";
				serialPort.Open();
			}
			catch (Exception ex)
			{
				flag = true;
				throw ex;
			}
			GClass3.smethod_2("Serial port opened!", 1);
			if (GClass61.smethod_36() == 5)
			{
				serialPort.ReadTimeout = 1000;
			}
			else
			{
				serialPort.ReadTimeout = 200;
			}
			string text = GClass55.smethod_11(serialPort, "AT");
			flag = (text.Contains("OK") || text.Contains("?"));
			GClass3.smethod_2("The mode is " + (flag ? "ELM!" : "not ELM!"), 1);
			GClass3.smethod_2("... done!", 1);
		}
		catch (Exception ex2)
		{
			GClass3.smethod_2(ex2.Message, 1);
			GClass3.smethod_2(".... failed!", 1);
		}
		finally
		{
			if (serialPort != null && serialPort.IsOpen)
			{
				try
				{
					serialPort.Close();
					GClass3.smethod_2("Serial port closed!", 1);
				}
				catch (Exception ex3)
				{
					GClass3.smethod_2("ERROR: Failed to close serial port: " + ex3.Message, 1);
				}
				GClass3.smethod_2("-------------------------------------", 1);
				GClass3.smethod_2(" ", 1);
			}
		}
		return flag;
	}

	// Token: 0x06000228 RID: 552 RVA: 0x0005C4CC File Offset: 0x0005A6CC
	public static bool smethod_5(string string_2)
	{
		SerialPort serialPort = null;
		bool flag = false;
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (GClass61.smethod_30(i) > 0)
			{
				num++;
			}
		}
		for (int i = 0; i < 4; i++)
		{
			if (GClass61.smethod_30(i) != 0)
			{
				GClass61.smethod_37(GClass61.smethod_30(i));
				GClass61.smethod_40(GClass61.smethod_32(i));
				GClass61.smethod_42(GClass61.smethod_34(i));
				try
				{
					GClass3.smethod_2("Testing for interface " + (i + 1), 0);
					GClass3.smethod_2("Interface type:  " + GClass61.string_0[GClass61.smethod_30(i)], 0);
					if (GClass19.smethod_0(string_2, string.Empty, 0, null, null, string.Empty) == null)
					{
						throw new Exception("Module communication protocol not supported by this interface!");
					}
					if (GClass3.bool_0)
					{
						return true;
					}
					if (num == 1)
					{
						flag = true;
						goto IL_423;
					}
					serialPort = new SerialPort(GClass61.smethod_32(i), GClass61.smethod_34(i), Parity.None, 8, StopBits.One);
					serialPort.WriteBufferSize = 2;
					serialPort.ReceivedBytesThreshold = 1000;
					serialPort.Handshake = Handshake.None;
					serialPort.NewLine = "\r\n";
					serialPort.Open();
					GClass3.smethod_2("Serial port opened!", 0);
					if (GClass61.smethod_30(i) == 2 || GClass61.smethod_30(i) == 3 || GClass61.smethod_30(i) == 7)
					{
						serialPort.NewLine = "\r\n";
						serialPort.ReadTimeout = 5000;
						GClass55.smethod_10(serialPort, "ATI");
						string text = GClass55.smethod_12(serialPort);
						if (text.Contains("?"))
						{
							GClass55.smethod_10(serialPort, "ATI");
							try
							{
								text = GClass55.smethod_12(serialPort);
							}
							catch (Exception)
							{
								text = string.Empty;
							}
						}
						if (!text.Contains("ELM"))
						{
							throw new Exception("Not an ELM interface!");
						}
					}
					if (GClass61.smethod_30(i) == 6)
					{
						serialPort.NewLine = "\r\n";
						serialPort.ReadTimeout = 5000;
						GClass55.smethod_10(serialPort, "ATI");
						string text = GClass55.smethod_12(serialPort);
						if (text.Contains("?"))
						{
							GClass55.smethod_10(serialPort, "ATI");
							try
							{
								text = GClass55.smethod_12(serialPort);
							}
							catch (Exception)
							{
								text = string.Empty;
							}
						}
						if (!text.Contains("FiatECUScan v3.4+"))
						{
							throw new Exception("Not a CANtieCAR interface!");
						}
					}
					else if (GClass61.smethod_30(i) == 4 || GClass61.smethod_30(i) == 5)
					{
						serialPort.NewLine = "\r";
						serialPort.ReadTimeout = 5000;
						GClass55.smethod_10(serialPort, "ATZ");
						string text = string.Empty;
						try
						{
							text = GClass55.smethod_12(serialPort);
						}
						catch (Exception)
						{
							text = string.Empty;
						}
						if (text.Contains("?"))
						{
							GClass55.smethod_10(serialPort, "ATZ");
							try
							{
								text = GClass55.smethod_12(serialPort);
							}
							catch (Exception)
							{
								text = string.Empty;
							}
						}
						if (text == string.Empty)
						{
							serialPort.ReadTimeout = 50;
							serialPort.ReadExisting();
							serialPort.Write(new byte[]
							{
								1
							}, 0, 1);
							byte b = (byte)serialPort.ReadByte();
							if (b != 1)
							{
								throw new Exception("Not an OBDKey interface! Echo: (" + GClass16.smethod_0(b) + ")");
							}
						}
						else if (!text.Contains("OBDKey"))
						{
							throw new Exception("Not an OBDKey interface!");
						}
					}
					else if (GClass61.smethod_30(i) == 1)
					{
						serialPort.ReadTimeout = 50;
						SerialPort serialPort2 = serialPort;
						byte[] buffer = new byte[1];
						serialPort2.Write(buffer, 0, 1);
						byte b = (byte)serialPort.ReadByte();
						if (b != 0)
						{
							throw new Exception("Invalid echo (" + GClass16.smethod_0(b) + "). Not VagCom!");
						}
					}
					flag = true;
					GClass3.smethod_2("... done!", 0);
				}
				catch (Exception ex)
				{
					GClass3.smethod_2(ex.Message, 0);
					GClass3.smethod_2(".... failed!", 0);
				}
				finally
				{
					if (serialPort != null && serialPort.IsOpen)
					{
						try
						{
							serialPort.Close();
							GClass3.smethod_2("Serial port closed!", 0);
						}
						catch (Exception ex2)
						{
							GClass3.smethod_2("ERROR: Failed to close serial port: " + ex2.Message, 0);
						}
						GClass3.smethod_2("-------------------------------------", 0);
						GClass3.smethod_2(" ", 0);
					}
				}
				if (flag)
				{
					break;
				}
			}
			IL_423:;
		}
		GClass3.smethod_2("****************************************************", 0);
		GClass3.smethod_2(GClass3.string_0, 0);
		if (flag)
		{
			GClass3.smethod_2("SELECTED INTERFACE TYPE: " + GClass61.string_0[GClass61.smethod_36()], 0);
		}
		else
		{
			GClass3.smethod_2("SUITABLE INTERFACE NOT FOUND!!!", 0);
		}
		GClass3.smethod_2("****************************************************", 0);
		return flag;
	}

	// Token: 0x06000229 RID: 553 RVA: 0x00002F27 File Offset: 0x00001127
	public static void smethod_6()
	{
		GClass55.smethod_7(GClass55.string_0);
	}

	// Token: 0x0600022A RID: 554 RVA: 0x0005CA0C File Offset: 0x0005AC0C
	public static void smethod_7(string string_2)
	{
		SerialPort serialPort = null;
		string text = string.Empty;
		string text2 = string.Empty;
		string str = GClass61.smethod_5();
		try
		{
			GClass3.smethod_2("Checking CANtieCAR mode....", 1);
			try
			{
				serialPort = new SerialPort(GClass61.smethod_39(), GClass61.smethod_41(), Parity.None, 8, StopBits.One);
				serialPort.WriteBufferSize = 2;
				serialPort.ReceivedBytesThreshold = 1000;
				serialPort.Handshake = Handshake.None;
				serialPort.NewLine = "\n\r";
				serialPort.Open();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			GClass3.smethod_2("Serial port opened!", 1);
			serialPort.ReadTimeout = 1000;
			text = GClass55.smethod_11(serialPort, "!tieCAR_SC_M" + string_2);
			text2 = GClass55.smethod_11(serialPort, "AT@2");
		}
		catch (Exception ex2)
		{
			GClass3.smethod_2(ex2.Message, 1);
			GClass3.smethod_2(".... failed!", 1);
		}
		finally
		{
			if (serialPort != null && serialPort.IsOpen)
			{
				try
				{
					serialPort.Close();
					GClass3.smethod_2("Serial port closed!", 1);
				}
				catch (Exception ex3)
				{
					GClass3.smethod_2("ERROR: Failed to close serial port: " + ex3.Message, 1);
				}
			}
		}
		int num = 0;
		string text3 = string.Empty;
		string[] array = new string[]
		{
			"CR:",
			"ID:",
			"SN:",
			"BW:",
			"HW:",
			"FW:",
			"Selected Mode:"
		};
		if (text.Length > 5)
		{
			while (text.IndexOf('\r', num) > -1)
			{
				int num2 = text.IndexOf('\r', num);
				if (num2 > 0)
				{
					text3 = text.Substring(num, num2 - num).Trim(GClass55.char_0);
					for (int i = 0; i < array.Length; i++)
					{
						if (text3.StartsWith(array[i]))
						{
							array[i] = text3.Substring(array[i].Length);
							break;
						}
					}
				}
				num = num2 + 1;
			}
			for (int j = 0; j < array.Length; j++)
			{
				GClass3.smethod_2(array[j], 1);
			}
		}
		GClass3.string_5 = array[2];
		text2 = text2.Replace("AT@2", string.Empty).Replace(">", string.Empty);
		text2 = text2.Trim(GClass55.char_0);
		string string_3 = str + "_" + text2;
		GClass3.byte_2 = GClass16.smethod_24(string_3);
		if (!array[6].Contains(string_2))
		{
			Thread.Sleep(1000);
		}
		GClass61.smethod_60(text2);
		GClass3.smethod_2("... done!", 1);
		GClass3.smethod_2("-------------------------------------", 1);
		GClass3.smethod_2(" ", 1);
	}

	// Token: 0x0600022B RID: 555 RVA: 0x0005CCE4 File Offset: 0x0005AEE4
	public static bool smethod_8()
	{
		bool result = false;
		ManagementObjectCollection managementObjectCollection;
		using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * From Win32_USBHub"))
		{
			managementObjectCollection = managementObjectSearcher.Get();
		}
		foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
		{
			string text = (string)managementBaseObject.GetPropertyValue("DeviceID");
			string text2 = (string)managementBaseObject.GetPropertyValue("PNPDeviceID");
			if (!text.Contains("VID_03EB") || !text.Contains("PID_6132"))
			{
				if (!text2.Contains("VID_03EB") || !text2.Contains("PID_6132"))
				{
					continue;
				}
				result = true;
			}
			else
			{
				result = true;
			}
			break;
		}
		managementObjectCollection.Dispose();
		return result;
	}

	// Token: 0x0600022C RID: 556 RVA: 0x0005CDD4 File Offset: 0x0005AFD4
	public static void smethod_9()
	{
		ManagementObjectCollection managementObjectCollection;
		using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * From Win32_SerialPort"))
		{
			managementObjectCollection = managementObjectSearcher.Get();
		}
		foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
		{
			string text = (string)managementBaseObject.GetPropertyValue("DeviceID");
			string text2 = (string)managementBaseObject.GetPropertyValue("PNPDeviceID");
			if (text2.Contains("VID_03EB") && text2.Contains("PID_6132"))
			{
				string text3 = text;
				for (int i = 31; i > 0; i--)
				{
					if (text3.Contains("COM" + i))
					{
						text3 = "COM" + i;
						IL_CB:
						GClass61.smethod_31(0, 6);
						GClass61.smethod_31(1, 0);
						GClass61.smethod_31(2, 0);
						GClass61.smethod_31(3, 0);
						GClass61.smethod_33(0, text3);
						GClass61.smethod_35(0, 115200);
						goto IL_FA;
					}
				}
				goto IL_CB;
				IL_FA:
				break;
			}
		}
		managementObjectCollection.Dispose();
	}

	// Token: 0x0600022D RID: 557 RVA: 0x0005CF0C File Offset: 0x0005B10C
	private static void smethod_10(SerialPort serialPort_0, string string_2)
	{
		GClass3.smethod_2("Send: " + string_2, 0);
		for (int i = 0; i < string_2.Length; i++)
		{
			serialPort_0.Write(string_2.Substring(i, 1));
		}
		serialPort_0.Write(serialPort_0.NewLine);
	}

	// Token: 0x0600022E RID: 558 RVA: 0x0005CF58 File Offset: 0x0005B158
	private static string smethod_11(SerialPort serialPort_0, string string_2)
	{
		GClass55.smethod_10(serialPort_0, string_2);
		string text = GClass55.smethod_12(serialPort_0);
		if (!text.Contains("OK"))
		{
			GClass3.smethod_2("[" + string_2 + "] failed!", 0);
		}
		return text;
	}

	// Token: 0x0600022F RID: 559 RVA: 0x0005CF9C File Offset: 0x0005B19C
	private static string smethod_12(SerialPort serialPort_0)
	{
		string text = string.Empty;
		while (!text.EndsWith(">"))
		{
			text += (char)serialPort_0.ReadByte();
		}
		GClass3.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x04000390 RID: 912
	public static string string_0 = "FES";

	// Token: 0x04000391 RID: 913
	public static string string_1 = "KK0";

	// Token: 0x04000392 RID: 914
	private static char[] char_0 = new char[]
	{
		'\r',
		'\n',
		' '
	};
}
