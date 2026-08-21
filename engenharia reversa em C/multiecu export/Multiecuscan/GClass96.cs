using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Foundation;

// Token: 0x0200005E RID: 94
public static class GClass96
{
	// Token: 0x06000371 RID: 881 RVA: 0x00057E1C File Offset: 0x0005601C
	public static void smethod_0()
	{
		SerialPort serialPort = null;
		try
		{
			GClass126.smethod_2("Switching OBDkey to VagCom mode....", 1);
			serialPort = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
			serialPort.WriteBufferSize = 2;
			serialPort.WriteTimeout = 5000;
			serialPort.ReceivedBytesThreshold = 1000;
			serialPort.Handshake = Handshake.None;
			serialPort.NewLine = "\r";
			serialPort.Open();
			GClass126.smethod_2("Serial port opened!", 1);
			serialPort.ReadTimeout = 5000;
			GClass96.smethod_20(serialPort, null, null, "ATZ");
			if (!GClass96.smethod_23(serialPort, null, null).Contains("OBDKey"))
			{
				GClass126.smethod_2("Invalid OBDKey interface!", 1);
				throw new Exception("Invalid OBDKey interface!");
			}
			GClass96.smethod_20(serialPort, null, null, "ATL");
			serialPort.ReadTimeout = 500;
			byte b = 0;
			while (b != 6)
			{
				b = (byte)serialPort.ReadByte();
				GClass126.smethod_2("Received: " + GClass127.smethod_23(b), 0);
			}
			serialPort.Write(new byte[]
			{
				3
			}, 0, 1);
			serialPort.Write(new byte[]
			{
				3
			}, 0, 1);
			GClass126.smethod_2("Sent: 03 03", 0);
			GClass126.smethod_2("... done!", 1);
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			GClass126.smethod_2(".... failed!", 1);
		}
		finally
		{
			if (serialPort != null && serialPort.IsOpen)
			{
				try
				{
					serialPort.Close();
					GClass126.smethod_2("Serial port closed!", 1);
				}
				catch (Exception ex2)
				{
					GClass126.smethod_2("ERROR: Failed to close serial port: " + ex2.Message, 1);
				}
				GClass126.smethod_2("-------------------------------------", 1);
				GClass126.smethod_2(" ", 1);
			}
		}
	}

	// Token: 0x06000372 RID: 882 RVA: 0x0000327D File Offset: 0x0000147D
	public static void smethod_1(bool bool_0)
	{
		GClass96.smethod_2(bool_0, "", 0);
	}

	// Token: 0x06000373 RID: 883 RVA: 0x00057FF8 File Offset: 0x000561F8
	public static void smethod_2(bool bool_0, string string_4, int int_2)
	{
		SerialPort serialPort = null;
		try
		{
			GClass126.smethod_2("Switching OBDkey to ELM mode....", 1);
			if (string_4 == "")
			{
				serialPort = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
			}
			else
			{
				serialPort = new SerialPort(string_4, int_2, Parity.None, 8, StopBits.One);
			}
			serialPort.WriteBufferSize = 2;
			serialPort.WriteTimeout = 5000;
			serialPort.ReceivedBytesThreshold = 1000;
			serialPort.Handshake = Handshake.None;
			serialPort.NewLine = "\r";
			serialPort.Open();
			GClass126.smethod_2("Serial port opened!", 1);
			serialPort.ReadTimeout = 50;
			GClass96.smethod_20(serialPort, null, null, "A");
			if (!bool_0)
			{
				Thread.Sleep(2000);
			}
			GClass126.smethod_2("... done!", 1);
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			GClass126.smethod_2(".... failed!", 1);
		}
		finally
		{
			if (serialPort != null && serialPort.IsOpen)
			{
				try
				{
					serialPort.Close();
					GClass126.smethod_2("Serial port closed!", 1);
				}
				catch (Exception ex2)
				{
					GClass126.smethod_2("ERROR: Failed to close serial port: " + ex2.Message, 1);
				}
				GClass126.smethod_2("-------------------------------------", 1);
				GClass126.smethod_2(" ", 1);
			}
		}
	}

	// Token: 0x06000374 RID: 884 RVA: 0x0000328B File Offset: 0x0000148B
	public static bool smethod_3()
	{
		return GClass96.smethod_4("", 0);
	}

	// Token: 0x06000375 RID: 885 RVA: 0x0005813C File Offset: 0x0005633C
	public static bool smethod_4(string string_4, int int_2)
	{
		bool flag = false;
		SerialPort serialPort = null;
		try
		{
			GClass126.smethod_2("Checking OBDkey for ELM mode....", 1);
			try
			{
				if (string_4 == "")
				{
					serialPort = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
				}
				else
				{
					serialPort = new SerialPort(string_4, int_2, Parity.None, 8, StopBits.One);
				}
				serialPort.WriteBufferSize = 2;
				serialPort.WriteTimeout = 5000;
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
			GClass126.smethod_2("Serial port opened!", 1);
			if (GClass125.smethod_44() == 5)
			{
				serialPort.ReadTimeout = 1000;
			}
			else
			{
				serialPort.ReadTimeout = 200;
			}
			string text = GClass96.smethod_22(serialPort, null, null, null, "AT");
			flag = (text.Contains("OK") || text.Contains("?"));
			GClass126.smethod_2("The mode is " + (flag ? "ELM!" : "not ELM!"), 1);
			GClass126.smethod_2("... done!", 1);
		}
		catch (Exception ex2)
		{
			GClass126.smethod_2(ex2.Message, 1);
			GClass126.smethod_2(".... failed!", 1);
		}
		finally
		{
			if (serialPort != null && serialPort.IsOpen)
			{
				try
				{
					serialPort.Close();
					GClass126.smethod_2("Serial port closed!", 1);
				}
				catch (Exception ex3)
				{
					GClass126.smethod_2("ERROR: Failed to close serial port: " + ex3.Message, 1);
				}
				GClass126.smethod_2("-------------------------------------", 1);
				GClass126.smethod_2(" ", 1);
			}
		}
		return flag;
	}

	// Token: 0x06000376 RID: 886 RVA: 0x0005830C File Offset: 0x0005650C
	public static bool smethod_5(string string_4)
	{
		if (GClass126.bool_0)
		{
			if (!string_4.Contains("CAN") && !string_4.Contains("OBDII"))
			{
				GClass125.smethod_45(1);
				GClass125.smethod_56("COM1");
				GClass125.smethod_58(115200);
			}
			else
			{
				GClass125.smethod_45(2);
				GClass125.smethod_56("COM1");
				GClass125.smethod_58(115200);
			}
			Thread.Sleep(1000);
			return true;
		}
		SerialPort serialPort = null;
		TcpClient tcpClient = null;
		BluetoothLEDevice bluetoothLEDevice = null;
		GattDeviceService gattDeviceService = null;
		bool flag = false;
		int num = 0;
		for (int i = 0; i < 2; i++)
		{
			string[] array = new string[8];
			array[0] = "Interface ";
			int num2 = 1;
			int j = i + 1;
			array[num2] = j.ToString();
			array[2] = ": ";
			array[3] = GClass125.string_1[GClass125.smethod_38(i)];
			array[4] = ", ";
			array[5] = GClass125.smethod_40(i);
			array[6] = ", ";
			int num3 = 7;
			j = GClass125.smethod_42(i);
			array[num3] = j.ToString();
			GClass126.smethod_2(string.Concat(array), 0);
			if (GClass125.smethod_38(i) > 0)
			{
				num++;
			}
		}
		if (GClass126.bool_10 && GClass126.bool_13)
		{
			string b = "";
			if (GClass125.smethod_49())
			{
				try
				{
					if (GClass125.smethod_48())
					{
						GClass96.string_3 = GClass125.smethod_50();
						GClass96.int_0 = GClass125.smethod_51();
						GClass126.smethod_2("Trying to connect to CTC on " + GClass96.string_3 + ":" + GClass96.int_0.ToString(), 0);
						tcpClient = new TcpClient();
						tcpClient.SendTimeout = 1000;
						tcpClient.ReceiveTimeout = 2000;
						if (!tcpClient.BeginConnect(GClass96.string_3, GClass96.int_0, null, null).AsyncWaitHandle.WaitOne(2000) || !tcpClient.Connected)
						{
							throw new Exception("WiFi device not connected!");
						}
						GClass126.smethod_2("WiFi device connect successfull!", 0);
						for (int k = 0; k < 5; k++)
						{
							if (GClass126.bool_25)
							{
								throw new Exception("ESC");
							}
							Thread.Sleep(100);
						}
						if (GClass96.smethod_22(null, tcpClient, null, null, "AT@4").Contains("tieCAR"))
						{
							flag = true;
						}
					}
					else if (GClass125.smethod_52())
					{
						GClass126.smethod_2("Trying to connect to CTC on BLE: " + GClass125.smethod_53() + " ...", 0);
						GClass126.smethod_2("BLE: Connect1", 0);
						bluetoothLEDevice = WindowsRuntimeSystemExtensions.AsTask<BluetoothLEDevice>(BluetoothLEDevice.FromBluetoothAddressAsync(ulong.Parse(GClass125.smethod_53(), NumberStyles.HexNumber))).GetAwaiter().GetResult();
						GClass126.smethod_2("BLE: Connect2", 0);
						GattDeviceServicesResult result = WindowsRuntimeSystemExtensions.AsTask<GattDeviceServicesResult>(bluetoothLEDevice.GetGattServicesForUuidAsync(Guid.Parse(GClass125.string_5), 1)).GetAwaiter().GetResult();
						if (result.Status == null)
						{
							GClass126.smethod_2("BLE: Connect gatt service", 0);
							gattDeviceService = result.Services[0];
							GattCharacteristic gattCharacteristic = null;
							GattCharacteristic gattCharacteristic2 = null;
							GattCharacteristicsResult result2 = WindowsRuntimeSystemExtensions.AsTask<GattCharacteristicsResult>(gattDeviceService.GetCharacteristicsAsync()).GetAwaiter().GetResult();
							if (result2.Status == null)
							{
								foreach (GattCharacteristic gattCharacteristic3 in result2.Characteristics)
								{
									if (gattCharacteristic3.Uuid == Guid.Parse(GClass125.string_6))
									{
										gattCharacteristic = gattCharacteristic3;
									}
									if (gattCharacteristic3.Uuid == Guid.Parse(GClass125.string_7))
									{
										gattCharacteristic2 = gattCharacteristic3;
									}
								}
							}
							if (gattCharacteristic2 != null && gattCharacteristic != null)
							{
								GClass126.smethod_2("BLE: Characteristics found", 0);
							}
							else
							{
								GClass126.smethod_2("BLE: Characteristic ERROR", 0);
							}
							WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(gattCharacteristic.WriteClientCharacteristicConfigurationDescriptorWithResultAsync(1)).GetAwaiter();
							GattCharacteristic @object = gattCharacteristic;
							WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>>(new Func<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>, EventRegistrationToken>(@object.add_ValueChanged), new Action<EventRegistrationToken>(@object.remove_ValueChanged), new TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>(GClass96.Class2.<>9.method_0));
							for (int l = 0; l < 5; l++)
							{
								if (GClass126.bool_25)
								{
									throw new Exception("ESC");
								}
								Thread.Sleep(100);
							}
							if (GClass96.smethod_22(null, null, gattCharacteristic2, gattCharacteristic, "AT@4").Contains("tieCAR"))
							{
								flag = true;
							}
						}
					}
					else
					{
						b = GClass125.smethod_55();
						serialPort = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
						serialPort.WriteBufferSize = 2;
						serialPort.ReadTimeout = 1000;
						serialPort.WriteTimeout = 1000;
						serialPort.ReceivedBytesThreshold = 1000;
						serialPort.Handshake = Handshake.None;
						serialPort.NewLine = "\r";
						serialPort.Open();
						GClass126.smethod_2("CTC Serial port " + GClass125.smethod_55() + " opened!", 0);
						for (int m = 0; m < 5; m++)
						{
							if (GClass126.bool_25)
							{
								throw new Exception("ESC");
							}
							Thread.Sleep(100);
						}
						if (GClass96.smethod_22(serialPort, null, null, null, "AT@4").Contains("tieCAR"))
						{
							flag = true;
						}
					}
				}
				catch (Exception ex)
				{
					GClass126.smethod_2("ERROR: " + ex.Message, 0);
				}
				finally
				{
					if (serialPort != null && serialPort.IsOpen)
					{
						try
						{
							serialPort.Close();
							GClass126.smethod_2("Serial port closed!", 0);
						}
						catch (Exception ex2)
						{
							GClass126.smethod_2("ERROR: Failed to close serial port: " + ex2.Message, 0);
						}
					}
					if (tcpClient != null && tcpClient.Connected)
					{
						try
						{
							tcpClient.Close();
						}
						catch (Exception ex3)
						{
							GClass126.smethod_2("ERROR: Failed to close TCP connection: " + ex3.Message, 1);
						}
					}
					if (bluetoothLEDevice != null)
					{
						if (gattDeviceService != null)
						{
							try
							{
								gattDeviceService.Session.Dispose();
								gattDeviceService.Dispose();
								GClass126.smethod_2("BLE gatt service closed!", 0);
							}
							catch (Exception ex4)
							{
								GClass126.smethod_2("ERROR: Failed to close BLE service: " + ex4.Message, 1);
							}
						}
						try
						{
							bluetoothLEDevice.Dispose();
							GClass126.smethod_2("BLE device closed!", 0);
						}
						catch (Exception ex5)
						{
							GClass126.smethod_2("ERROR: Failed to close BLE connection: " + ex5.Message, 1);
						}
					}
				}
			}
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			if (!flag && GClass125.smethod_40(0) != b && !GClass125.smethod_40(0).StartsWith("BLE") && GClass125.smethod_38(0) == 6)
			{
				try
				{
					GClass126.smethod_2("Trying CTC on port " + GClass125.smethod_40(0) + "...", 0);
					serialPort = new SerialPort(GClass125.smethod_40(0), GClass125.smethod_42(0), Parity.None, 8, StopBits.One);
					serialPort.WriteBufferSize = 2;
					serialPort.ReadTimeout = 1000;
					serialPort.WriteTimeout = 1000;
					serialPort.ReceivedBytesThreshold = 1000;
					serialPort.Handshake = Handshake.None;
					serialPort.NewLine = "\r";
					serialPort.Open();
					GClass126.smethod_2("CTC Serial port " + GClass125.smethod_40(0) + " opened!", 0);
					for (int n = 0; n < 5; n++)
					{
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
					if (GClass96.smethod_22(serialPort, null, null, null, "AT@4").Contains("tieCAR"))
					{
						GClass125.smethod_45(GClass125.smethod_38(0));
						GClass125.smethod_56(GClass125.smethod_40(0));
						GClass125.smethod_58(GClass125.smethod_42(0));
						flag = true;
					}
				}
				catch (Exception ex6)
				{
					GClass126.smethod_2("ERROR: " + ex6.Message, 0);
				}
				finally
				{
					if (serialPort != null && serialPort.IsOpen)
					{
						try
						{
							serialPort.Close();
							GClass126.smethod_2("Serial port closed!", 0);
						}
						catch (Exception ex7)
						{
							GClass126.smethod_2("ERROR: Failed to close serial port: " + ex7.Message, 0);
						}
					}
				}
			}
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			if (!flag)
			{
				try
				{
					string text = GClass96.smethod_13();
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					if (text != "")
					{
						GClass126.smethod_2("Trying CTC on auto port " + text + "...", 0);
						serialPort = new SerialPort(text, 115200, Parity.None, 8, StopBits.One);
						serialPort.WriteBufferSize = 2;
						serialPort.ReadTimeout = 1000;
						serialPort.WriteTimeout = 1000;
						serialPort.ReceivedBytesThreshold = 1000;
						serialPort.Handshake = Handshake.None;
						serialPort.NewLine = "\r";
						serialPort.Open();
						GClass126.smethod_2("CTC PORT CHANGED: " + text, 0);
						GClass126.smethod_2("CTC Serial port " + text + " opened!", 0);
						GClass125.smethod_41(0, text);
						GClass125.smethod_43(0, 115200);
						GClass125.smethod_45(6);
						GClass125.smethod_56(GClass125.smethod_40(0));
						GClass125.smethod_58(GClass125.smethod_42(0));
						flag = true;
					}
				}
				catch (Exception ex8)
				{
					GClass126.smethod_2("ERROR: " + ex8.Message, 0);
				}
				finally
				{
					if (serialPort != null && serialPort.IsOpen)
					{
						try
						{
							serialPort.Close();
							GClass126.smethod_2("Serial port closed!", 0);
						}
						catch (Exception ex9)
						{
							GClass126.smethod_2("ERROR: Failed to close serial port: " + ex9.Message, 0);
						}
					}
				}
			}
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			if (!flag)
			{
				try
				{
					GClass96.Class4 @class = new GClass96.Class4();
					GClass126.smethod_2("Searching for BLE devices ...", 0);
					@class.foundBLEDeviceID = "";
					TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs> handler = new TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>(@class.method_0);
					BluetoothLEAdvertisementWatcher bluetoothLEAdvertisementWatcher = new BluetoothLEAdvertisementWatcher();
					bluetoothLEAdvertisementWatcher.put_ScanningMode(1);
					BluetoothLEAdvertisementWatcher bluetoothLEAdvertisementWatcher2 = bluetoothLEAdvertisementWatcher;
					BluetoothLEAdvertisementWatcher object2 = bluetoothLEAdvertisementWatcher2;
					WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>>(new Func<TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>, EventRegistrationToken>(object2.add_Received), new Action<EventRegistrationToken>(object2.remove_Received), handler);
					bluetoothLEAdvertisementWatcher2.Start();
					long num4 = (long)(GClass126.smethod_1() + 10000);
					while (@class.foundBLEDeviceID == "" && num4 > (long)GClass126.smethod_1())
					{
						Thread.Sleep(50);
					}
					bluetoothLEAdvertisementWatcher2.Stop();
					if (@class.foundBLEDeviceID != "")
					{
						GClass126.smethod_2("Found BLE CTC " + @class.foundBLEDeviceID, 0);
						GClass125.smethod_41(0, "BLE" + @class.foundBLEDeviceID);
						GClass125.smethod_45(6);
						GClass125.smethod_56(GClass125.smethod_40(0));
						flag = true;
					}
				}
				catch (Exception ex10)
				{
					GClass126.smethod_2("ERROR: " + ex10.Message, 0);
				}
			}
			if (!flag)
			{
				try
				{
					GClass125.smethod_56(GClass125.smethod_40(1));
					GClass96.string_3 = GClass125.smethod_50();
					GClass96.int_0 = GClass125.smethod_51();
					GClass126.smethod_2("Trying to connect to CTC on " + GClass96.string_3 + ":" + GClass96.int_0.ToString(), 0);
					tcpClient = new TcpClient();
					tcpClient.SendTimeout = 1000;
					tcpClient.ReceiveTimeout = 2000;
					bool flag2 = tcpClient.BeginConnect(GClass96.string_3, GClass96.int_0, null, null).AsyncWaitHandle.WaitOne(2000);
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					if (!flag2 || !tcpClient.Connected)
					{
						string text2 = GClass96.string_3;
						int num5 = GClass96.int_0;
						GClass96.string_3 = "";
						GClass96.int_0 = 23;
						try
						{
							GClass96.smethod_9();
						}
						catch (Exception ex11)
						{
							GClass96.string_3 = text2;
							GClass96.int_0 = num5;
							throw ex11;
						}
						if (GClass96.string_3 == "")
						{
							GClass96.string_3 = text2;
							GClass96.int_0 = num5;
						}
						else
						{
							GClass125.smethod_56("IP" + GClass96.string_3 + ":" + GClass96.int_0.ToString());
							GClass125.smethod_41(1, GClass125.smethod_55());
							GClass126.smethod_2("Trying to connect to CTC on " + GClass96.string_3 + ":" + GClass96.int_0.ToString(), 0);
							tcpClient = new TcpClient();
							tcpClient.SendTimeout = 1000;
							tcpClient.ReceiveTimeout = 2000;
							flag2 = tcpClient.BeginConnect(GClass96.string_3, GClass96.int_0, null, null).AsyncWaitHandle.WaitOne(2000);
						}
					}
					if (!flag2 || !tcpClient.Connected)
					{
						throw new Exception("WiFi device not connected!");
					}
					GClass126.smethod_2("WiFi device connect successfull!", 0);
					for (int num6 = 0; num6 < 5; num6++)
					{
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
					if (GClass96.smethod_22(null, tcpClient, null, null, "AT@4").Contains("tieCAR"))
					{
						GClass125.smethod_39(1, 13);
						GClass125.smethod_41(1, "IP" + GClass96.string_3 + ":" + GClass96.int_0.ToString());
						GClass125.smethod_45(GClass125.smethod_38(1));
						GClass125.smethod_56(GClass125.smethod_40(1));
						flag = true;
					}
				}
				catch (Exception ex12)
				{
					GClass126.smethod_2("ERROR: " + ex12.Message, 0);
				}
				finally
				{
					if (tcpClient != null && tcpClient.Connected)
					{
						try
						{
							tcpClient.Close();
						}
						catch (Exception ex13)
						{
							GClass126.smethod_2("ERROR: Failed to close TCP connection: " + ex13.Message, 1);
						}
					}
				}
			}
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			if (flag)
			{
				goto IL_2001;
			}
			try
			{
				string[] array2 = GClass96.smethod_14();
				if (GClass126.bool_25)
				{
					throw new Exception("ESC");
				}
				foreach (string text3 in array2)
				{
					GClass126.smethod_2("Trying CTC on BT port " + text3 + "...", 0);
					try
					{
						serialPort = new SerialPort(text3, 115200, Parity.None, 8, StopBits.One);
						serialPort.WriteBufferSize = 2;
						serialPort.ReadTimeout = 2000;
						serialPort.WriteTimeout = 2000;
						serialPort.ReceivedBytesThreshold = 1000;
						serialPort.Handshake = Handshake.None;
						serialPort.NewLine = "\r";
						serialPort.Open();
						GClass126.smethod_2("CTC BT Serial port " + text3 + " opened!", 0);
						for (int num7 = 0; num7 < 5; num7++)
						{
							if (GClass126.bool_25)
							{
								throw new Exception("ESC");
							}
							Thread.Sleep(100);
						}
						if (GClass96.smethod_22(serialPort, null, null, null, "AT@4").Contains("tieCAR"))
						{
							GClass126.smethod_2("CTC BLUETOOTH PORT CHANGED: " + text3, 0);
							GClass125.smethod_41(0, text3);
							GClass125.smethod_43(0, 115200);
							GClass125.smethod_45(6);
							GClass125.smethod_56(GClass125.smethod_40(0));
							GClass125.smethod_58(GClass125.smethod_42(0));
							flag = true;
							break;
						}
					}
					catch (Exception ex14)
					{
						GClass126.smethod_2("ERROR: " + ex14.Message, 0);
					}
					finally
					{
						if (serialPort != null && serialPort.IsOpen)
						{
							try
							{
								serialPort.Close();
								GClass126.smethod_2("Serial port closed!", 0);
							}
							catch (Exception ex15)
							{
								GClass126.smethod_2("ERROR: Failed to close serial port: " + ex15.Message, 0);
							}
						}
					}
				}
				goto IL_2001;
			}
			catch (Exception)
			{
				goto IL_2001;
			}
		}
		if (GClass125.smethod_38(0) == 16 || GClass125.smethod_38(0) == 0)
		{
			if (GClass125.smethod_44() != 0)
			{
				try
				{
					if (GClass125.smethod_48())
					{
						string str = "Trying to connect ELM on ";
						string str2 = GClass125.smethod_50();
						string str3 = ":";
						int j = GClass125.smethod_51();
						GClass126.smethod_2(str + str2 + str3 + j.ToString(), 0);
						tcpClient = new TcpClient();
						tcpClient.SendTimeout = 1000;
						tcpClient.ReceiveTimeout = 2000;
						if (!tcpClient.BeginConnect(GClass125.smethod_50(), GClass125.smethod_51(), null, null).AsyncWaitHandle.WaitOne(2000) || !tcpClient.Connected)
						{
							throw new Exception("WiFi device not connected!");
						}
						GClass126.smethod_2("WiFi device connect successfull!", 0);
						for (int num8 = 0; num8 < 5; num8++)
						{
							if (GClass126.bool_25)
							{
								throw new Exception("ESC");
							}
							Thread.Sleep(100);
						}
						string text4 = GClass96.smethod_22(null, tcpClient, null, null, "ATI");
						if (text4.Contains("ELM32") || text4.Contains("OBD"))
						{
							flag = true;
						}
					}
					else if (GClass125.smethod_52())
					{
						GClass126.smethod_2("Trying to connect to VGATE on BLE: " + GClass125.smethod_53() + " ...", 0);
						GClass126.smethod_2("BLE: Connect1", 0);
						bluetoothLEDevice = WindowsRuntimeSystemExtensions.AsTask<BluetoothLEDevice>(BluetoothLEDevice.FromBluetoothAddressAsync(ulong.Parse(GClass125.smethod_53(), NumberStyles.HexNumber))).GetAwaiter().GetResult();
						GClass126.smethod_2("BLE: Connect2", 0);
						GattDeviceServicesResult result3 = WindowsRuntimeSystemExtensions.AsTask<GattDeviceServicesResult>(bluetoothLEDevice.GetGattServicesForUuidAsync(Guid.Parse(GClass125.string_8), 1)).GetAwaiter().GetResult();
						if (result3.Status == null)
						{
							GClass126.smethod_2("BLE: Connect gatt service", 0);
							gattDeviceService = result3.Services[0];
							GattCharacteristic gattCharacteristic4 = null;
							GattCharacteristic gattCharacteristic5 = null;
							GattCharacteristicsResult result4 = WindowsRuntimeSystemExtensions.AsTask<GattCharacteristicsResult>(gattDeviceService.GetCharacteristicsAsync()).GetAwaiter().GetResult();
							if (result4.Status == null)
							{
								foreach (GattCharacteristic gattCharacteristic6 in result4.Characteristics)
								{
									if (gattCharacteristic6.Uuid == Guid.Parse(GClass125.string_9))
									{
										gattCharacteristic4 = gattCharacteristic6;
									}
									if (gattCharacteristic6.Uuid == Guid.Parse(GClass125.string_10))
									{
										gattCharacteristic5 = gattCharacteristic6;
									}
								}
							}
							if (gattCharacteristic5 != null && gattCharacteristic4 != null)
							{
								GClass126.smethod_2("BLE: Characteristics found", 0);
							}
							else
							{
								GClass126.smethod_2("BLE: Characteristic ERROR", 0);
							}
							WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(gattCharacteristic4.WriteClientCharacteristicConfigurationDescriptorWithResultAsync(1)).GetAwaiter();
							GattCharacteristic @object = gattCharacteristic4;
							WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>>(new Func<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>, EventRegistrationToken>(@object.add_ValueChanged), new Action<EventRegistrationToken>(@object.remove_ValueChanged), new TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>(GClass96.Class2.<>9.method_1));
							for (int num9 = 0; num9 < 5; num9++)
							{
								if (GClass126.bool_25)
								{
									throw new Exception("ESC");
								}
								Thread.Sleep(100);
							}
							string text5 = GClass96.smethod_22(null, null, gattCharacteristic5, gattCharacteristic4, "ATI");
							if (text5.Contains("ELM32") || text5.Contains("OBD"))
							{
								flag = true;
							}
						}
					}
					else
					{
						GClass125.smethod_55();
						serialPort = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
						serialPort.WriteBufferSize = 2;
						serialPort.ReadTimeout = 1000;
						serialPort.WriteTimeout = 1000;
						serialPort.ReceivedBytesThreshold = 1000;
						serialPort.Handshake = Handshake.None;
						serialPort.NewLine = "\r";
						serialPort.Open();
						GClass126.smethod_2("ELM serial port " + GClass125.smethod_55() + " opened!", 0);
						for (int num10 = 0; num10 < 5; num10++)
						{
							if (GClass126.bool_25)
							{
								throw new Exception("ESC");
							}
							Thread.Sleep(100);
						}
						if (GClass125.smethod_44() == 1)
						{
							try
							{
								serialPort.ReadTimeout = 50;
								serialPort.Write(new byte[1], 0, 1);
								byte b2 = (byte)serialPort.ReadByte();
								serialPort.Write(new byte[]
								{
									165
								}, 0, 1);
								byte b3 = (byte)serialPort.ReadByte();
								byte b4 = 55;
								serialPort.BreakState = true;
								serialPort.RtsEnable = true;
								for (int num11 = 1; num11 < 10; num11++)
								{
									b4 += 1;
								}
								serialPort.BreakState = false;
								serialPort.RtsEnable = false;
								b4 = 55;
								try
								{
									b4 = (byte)serialPort.ReadByte();
								}
								catch (Exception)
								{
								}
								serialPort.BreakState = false;
								serialPort.RtsEnable = false;
								if (b2 != 0 || b3 != 165 || b4 == 55)
								{
									throw new Exception("VagCom interface not found... ");
								}
								GClass126.smethod_2("KKL interface found... ", 0);
								flag = true;
							}
							catch (Exception)
							{
							}
						}
						if (!flag)
						{
							serialPort.ReadTimeout = 1000;
							string text6 = GClass96.smethod_22(serialPort, null, null, null, "ATI");
							if (text6.Contains("?"))
							{
								text6 = GClass96.smethod_22(serialPort, null, null, null, "ATI");
							}
							if (text6.Contains("ELM32") || text6.Contains("OBD") || text6.Contains("ECUScan v3.4+"))
							{
								flag = true;
							}
						}
					}
				}
				catch (Exception ex16)
				{
					GClass126.smethod_2("ERROR: " + ex16.Message, 0);
				}
				finally
				{
					if (serialPort != null && serialPort.IsOpen)
					{
						try
						{
							serialPort.Close();
							GClass126.smethod_2("Serial port closed!", 0);
						}
						catch (Exception ex17)
						{
							GClass126.smethod_2("ERROR: Failed to close serial port: " + ex17.Message, 0);
						}
					}
					if (tcpClient != null && tcpClient.Connected)
					{
						try
						{
							tcpClient.Close();
						}
						catch (Exception ex18)
						{
							GClass126.smethod_2("ERROR: Failed to close TCP connection: " + ex18.Message, 1);
						}
					}
					if (bluetoothLEDevice != null)
					{
						if (gattDeviceService != null)
						{
							try
							{
								gattDeviceService.Session.Dispose();
								gattDeviceService.Dispose();
								GClass126.smethod_2("BLE gatt service closed!", 0);
							}
							catch (Exception ex19)
							{
								GClass126.smethod_2("ERROR: Failed to close BLE service: " + ex19.Message, 1);
							}
						}
						try
						{
							bluetoothLEDevice.Dispose();
							GClass126.smethod_2("BLE device closed!", 0);
						}
						catch (Exception ex20)
						{
							GClass126.smethod_2("ERROR: Failed to close BLE connection: " + ex20.Message, 1);
						}
					}
				}
			}
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			if (!flag)
			{
				try
				{
					GClass96.Class5 class2 = new GClass96.Class5();
					GClass126.smethod_2("Searching for BLE devices ...", 0);
					class2.foundBLEDeviceID = "";
					class2.string_0 = "";
					TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs> handler2 = new TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>(class2.method_0);
					BluetoothLEAdvertisementWatcher bluetoothLEAdvertisementWatcher3 = new BluetoothLEAdvertisementWatcher();
					bluetoothLEAdvertisementWatcher3.put_ScanningMode(1);
					BluetoothLEAdvertisementWatcher bluetoothLEAdvertisementWatcher4 = bluetoothLEAdvertisementWatcher3;
					BluetoothLEAdvertisementWatcher object2 = bluetoothLEAdvertisementWatcher4;
					WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>>(new Func<TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>, EventRegistrationToken>(object2.add_Received), new Action<EventRegistrationToken>(object2.remove_Received), handler2);
					bluetoothLEAdvertisementWatcher4.Start();
					long num12 = (long)(GClass126.smethod_1() + 8000);
					while (class2.foundBLEDeviceID == "" && num12 > (long)GClass126.smethod_1())
					{
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(50);
					}
					bluetoothLEAdvertisementWatcher4.Stop();
					if (class2.foundBLEDeviceID != "")
					{
						if (class2.string_0.Contains("vLinker MS"))
						{
							GClass126.smethod_2("Found BLE vLinker MS " + class2.foundBLEDeviceID, 0);
							GClass125.smethod_45(15);
						}
						else
						{
							GClass126.smethod_2("Found BLE Vgate " + class2.foundBLEDeviceID, 0);
							GClass125.smethod_45(7);
						}
						GClass125.smethod_56("BLE" + class2.foundBLEDeviceID);
						flag = true;
					}
				}
				catch (Exception ex21)
				{
					GClass126.smethod_2("ERROR: " + ex21.Message, 0);
				}
			}
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			if (!flag && GClass125.smethod_50() != "192.168.0.10" && GClass125.smethod_51() != 35000)
			{
				try
				{
					string text7 = "192.168.0.10:35000";
					GClass126.smethod_2("Trying to connect ELM/OBDLink/Vgate on " + text7 + " ...", 0);
					tcpClient = new TcpClient();
					tcpClient.SendTimeout = 1000;
					tcpClient.ReceiveTimeout = 2000;
					bool flag3 = tcpClient.BeginConnect("192.168.0.10", 35000, null, null).AsyncWaitHandle.WaitOne(2000);
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					if (!flag3 || !tcpClient.Connected)
					{
						text7 = "192.168.0.74:23";
						GClass126.smethod_2("Trying to connect OBDKey on " + text7 + " ...", 0);
						tcpClient = new TcpClient();
						tcpClient.SendTimeout = 1000;
						tcpClient.ReceiveTimeout = 2000;
						flag3 = tcpClient.BeginConnect("192.168.0.10", 35000, null, null).AsyncWaitHandle.WaitOne(2000);
					}
					if (!flag3 || !tcpClient.Connected)
					{
						throw new Exception("WiFi device not connected!");
					}
					GClass126.smethod_2("WiFi device connect successfull!", 0);
					for (int num13 = 0; num13 < 5; num13++)
					{
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
					string text8 = GClass96.smethod_22(null, tcpClient, null, null, "ATI");
					string text9 = GClass96.smethod_22(null, tcpClient, null, null, "VTI");
					if (text8.Contains("ELM32") || text8.Contains("OBD"))
					{
						if (text7 == "192.168.0.74:23")
						{
							GClass125.smethod_45(10);
						}
						else if (text9.Length > 6 && !text9.Contains("?"))
						{
							GClass125.smethod_45(12);
						}
						else
						{
							GClass125.smethod_45(9);
						}
						GClass125.smethod_56("IP" + text7);
						flag = true;
					}
				}
				catch (Exception ex22)
				{
					GClass126.smethod_2("ERROR: " + ex22.Message, 0);
				}
				finally
				{
					if (tcpClient != null && tcpClient.Connected)
					{
						try
						{
							tcpClient.Close();
						}
						catch (Exception ex23)
						{
							GClass126.smethod_2("ERROR: Failed to close TCP connection: " + ex23.Message, 1);
						}
					}
				}
			}
			if (GClass126.bool_25)
			{
				throw new Exception("ESC");
			}
			if (!flag)
			{
				try
				{
					string[] array3 = GClass96.smethod_19();
					int j = 0;
					while (j < array3.Length)
					{
						string text10 = array3[j];
						if (!GClass126.bool_25)
						{
							string text11 = text10.Substring(2);
							bool flag4 = text10.StartsWith("BT");
							GClass126.smethod_2("Trying ELM on port " + text11 + "...", 0);
							try
							{
								serialPort = new SerialPort(text11, 115200, Parity.None, 8, StopBits.One);
								serialPort.WriteBufferSize = 2;
								serialPort.ReadTimeout = 1000;
								serialPort.WriteTimeout = 1000;
								serialPort.ReceivedBytesThreshold = 1000;
								serialPort.Handshake = Handshake.None;
								serialPort.NewLine = "\r";
								serialPort.Open();
								GClass126.smethod_2("ELM serial port " + text11 + " opened at 115200!", 0);
								for (int num14 = 0; num14 < 5; num14++)
								{
									if (GClass126.bool_25)
									{
										throw new Exception("ESC");
									}
									Thread.Sleep(100);
								}
								string text12 = GClass96.smethod_22(serialPort, null, null, null, "ATI");
								if (text12.Contains("?"))
								{
									text12 = GClass96.smethod_22(serialPort, null, null, null, "ATI");
								}
								string text13 = GClass96.smethod_22(serialPort, null, null, null, "STI");
								string text14 = GClass96.smethod_22(serialPort, null, null, null, "VTI");
								if (text12.Contains("OBDKey"))
								{
									GClass125.smethod_45(flag4 ? 5 : 4);
									GClass125.smethod_56(text11);
									GClass125.smethod_58(115200);
									flag = true;
									break;
								}
								if (text13.Contains("STN"))
								{
									if (text14.Contains("vLinker MS"))
									{
										GClass125.smethod_45(15);
										GClass125.smethod_56(text11);
										GClass125.smethod_58(115200);
										flag = true;
										break;
									}
									GClass125.smethod_45(7);
									GClass125.smethod_56(text11);
									GClass125.smethod_58(115200);
									flag = true;
									break;
								}
								else if (text12.Contains("ELM327") || text12.Contains("OBD") || text12.Contains("ECUScan v3.4+"))
								{
									GClass125.smethod_45(flag4 ? 3 : 2);
									GClass125.smethod_56(text11);
									GClass125.smethod_58(115200);
									flag = true;
									break;
								}
							}
							catch (Exception ex24)
							{
								GClass126.smethod_2("ERROR: " + ex24.Message, 0);
							}
							finally
							{
								if (serialPort != null && serialPort.IsOpen)
								{
									try
									{
										serialPort.Close();
										GClass126.smethod_2("Serial port closed!", 0);
									}
									catch (Exception ex25)
									{
										GClass126.smethod_2("ERROR: Failed to close serial port: " + ex25.Message, 0);
									}
								}
							}
							if (!flag4)
							{
								if (GClass126.bool_25)
								{
									throw new Exception("ESC");
								}
								try
								{
									serialPort = new SerialPort(text11, 38400, Parity.None, 8, StopBits.One);
									serialPort.WriteBufferSize = 2;
									serialPort.ReadTimeout = 1000;
									serialPort.WriteTimeout = 1000;
									serialPort.ReceivedBytesThreshold = 1000;
									serialPort.Handshake = Handshake.None;
									serialPort.NewLine = "\r";
									serialPort.Open();
									GClass126.smethod_2("ELM serial port " + text11 + " opened at 38400!", 0);
									Thread.Sleep(50);
									try
									{
										serialPort.ReadTimeout = 50;
										serialPort.Write(new byte[1], 0, 1);
										byte b5 = (byte)serialPort.ReadByte();
										serialPort.Write(new byte[]
										{
											165
										}, 0, 1);
										byte b6 = (byte)serialPort.ReadByte();
										byte b7 = 55;
										serialPort.BreakState = true;
										serialPort.RtsEnable = true;
										for (int num15 = 1; num15 < 10; num15++)
										{
											b7 += 1;
										}
										serialPort.BreakState = false;
										serialPort.RtsEnable = false;
										b7 = 55;
										try
										{
											b7 = (byte)serialPort.ReadByte();
										}
										catch (Exception)
										{
										}
										serialPort.BreakState = false;
										serialPort.RtsEnable = false;
										if (b5 != 0 || b6 != 165 || b7 == 55)
										{
											throw new Exception("VagCom interface not found... ");
										}
										GClass126.smethod_2("KKL interface found... ", 0);
										GClass125.smethod_45(1);
										GClass125.smethod_56(text11);
										GClass125.smethod_58(10400);
										flag = true;
										break;
									}
									catch (Exception)
									{
									}
									serialPort.ReadTimeout = 1000;
									string text15 = GClass96.smethod_22(serialPort, null, null, null, "ATI");
									if (text15.Contains("?"))
									{
										try
										{
											serialPort.ReadExisting();
										}
										catch (Exception)
										{
										}
										text15 = GClass96.smethod_22(serialPort, null, null, null, "ATI");
									}
									string text16 = GClass96.smethod_22(serialPort, null, null, null, "STI");
									string text17 = GClass96.smethod_22(serialPort, null, null, null, "VTI");
									if (text15.Contains("OBDKey"))
									{
										GClass125.smethod_45(flag4 ? 5 : 4);
										GClass125.smethod_56(text11);
										GClass125.smethod_58(38400);
										flag = true;
										break;
									}
									if (text16.Contains("STN"))
									{
										if (text17.Contains("vLinker MS"))
										{
											GClass125.smethod_45(15);
											GClass125.smethod_56(text11);
											GClass125.smethod_58(38400);
											flag = true;
											break;
										}
										GClass125.smethod_45(7);
										GClass125.smethod_56(text11);
										GClass125.smethod_58(38400);
										flag = true;
										break;
									}
									else if (text15.Contains("ELM327") || text15.Contains("OBD") || text15.Contains("ECUScan v3.4+"))
									{
										GClass125.smethod_45(flag4 ? 3 : 2);
										GClass125.smethod_56(text11);
										GClass125.smethod_58(38400);
										flag = true;
										break;
									}
								}
								catch (Exception ex26)
								{
									GClass126.smethod_2("ERROR: " + ex26.Message, 0);
								}
								finally
								{
									if (serialPort != null && serialPort.IsOpen)
									{
										try
										{
											serialPort.Close();
											GClass126.smethod_2("Serial port closed!", 0);
										}
										catch (Exception ex27)
										{
											GClass126.smethod_2("ERROR: Failed to close serial port: " + ex27.Message, 0);
										}
									}
								}
								if (GClass126.bool_25)
								{
									throw new Exception("ESC");
								}
								try
								{
									serialPort = new SerialPort(text11, 9600, Parity.None, 8, StopBits.One);
									serialPort.WriteBufferSize = 2;
									serialPort.ReadTimeout = 1000;
									serialPort.WriteTimeout = 500;
									serialPort.ReceivedBytesThreshold = 1000;
									serialPort.Handshake = Handshake.None;
									serialPort.NewLine = "\r";
									serialPort.Open();
									GClass126.smethod_2("ELM serial port " + text11 + " opened at 9600!", 0);
									Thread.Sleep(50);
									string text18 = GClass96.smethod_22(serialPort, null, null, null, "");
									text18 = GClass96.smethod_22(serialPort, null, null, null, "ATI");
									if (text18.Contains("?"))
									{
										Thread.Sleep(100);
										try
										{
											serialPort.ReadExisting();
										}
										catch (Exception)
										{
										}
										text18 = GClass96.smethod_22(serialPort, null, null, null, "ATI");
									}
									string text19 = GClass96.smethod_22(serialPort, null, null, null, "STI");
									string text20 = GClass96.smethod_22(serialPort, null, null, null, "VTI");
									if (text18.Contains("OBDKey"))
									{
										GClass125.smethod_45(flag4 ? 5 : 4);
										GClass125.smethod_56(text11);
										GClass125.smethod_58(9600);
										flag = true;
										break;
									}
									if (text19.Contains("STN"))
									{
										if (text20.Contains("vLinker MS"))
										{
											GClass125.smethod_45(15);
											GClass125.smethod_56(text11);
											GClass125.smethod_58(9600);
											flag = true;
											break;
										}
										GClass125.smethod_45(7);
										GClass125.smethod_56(text11);
										GClass125.smethod_58(9600);
										flag = true;
										break;
									}
									else if (text18.Contains("ELM327") || text18.Contains("OBD") || text18.Contains("ECUScan v3.4+"))
									{
										GClass125.smethod_45(flag4 ? 3 : 2);
										GClass125.smethod_56(text11);
										GClass125.smethod_58(9600);
										flag = true;
										break;
									}
								}
								catch (Exception ex28)
								{
									GClass126.smethod_2("ERROR: " + ex28.Message, 0);
								}
								finally
								{
									if (serialPort != null && serialPort.IsOpen)
									{
										try
										{
											serialPort.Close();
											GClass126.smethod_2("Serial port closed!", 0);
										}
										catch (Exception ex29)
										{
											GClass126.smethod_2("ERROR: Failed to close serial port: " + ex29.Message, 0);
										}
									}
								}
							}
							j++;
							continue;
							break;
						}
						throw new Exception("ESC");
					}
				}
				catch (Exception)
				{
				}
			}
			if (flag && GClass11.smethod_0(string_4, "", 0, null, null, "", null) == null)
			{
				flag = false;
				GClass126.smethod_2("Interface does not support requred protocol!", 0);
			}
		}
		IL_2001:
		if (!flag && GClass125.smethod_38(0) != 16)
		{
			string[] array4 = GClass96.smethod_19();
			for (int num16 = 0; num16 < 2; num16++)
			{
				if (GClass125.smethod_38(num16) != 0)
				{
					GClass125.smethod_45(GClass125.smethod_38(num16));
					GClass125.smethod_56(GClass125.smethod_40(num16));
					GClass125.smethod_58(GClass125.smethod_42(num16));
					bool flag5 = false;
					string[] array3 = array4;
					int j = 0;
					while (j < array3.Length)
					{
						if (!(array3[j] == "BT" + GClass125.smethod_55()))
						{
							j++;
						}
						else
						{
							flag5 = true;
							IL_2091:
							try
							{
								string str4 = "Testing for interface ";
								j = num16 + 1;
								GClass126.smethod_2(str4 + j.ToString(), 0);
								if (GClass11.smethod_0(string_4, "", 0, null, null, "", null) == null)
								{
									throw new Exception("Module communication protocol not supported by this interface!");
								}
								if (GClass125.smethod_48())
								{
									GClass96.string_3 = GClass125.smethod_50();
									GClass96.int_0 = GClass125.smethod_51();
									GClass126.smethod_2("Trying to connect to WiFi device on " + GClass96.string_3 + ":" + GClass96.int_0.ToString(), 0);
									tcpClient = new TcpClient();
									tcpClient.SendTimeout = 1000;
									tcpClient.ReceiveTimeout = 2000;
									bool flag6 = tcpClient.BeginConnect(GClass96.string_3, GClass96.int_0, null, null).AsyncWaitHandle.WaitOne(2000);
									if (GClass126.bool_25)
									{
										throw new Exception("ESC");
									}
									if (!flag6 || !tcpClient.Connected)
									{
										flag = true;
										GClass126.smethod_2("... done!", 0);
									}
								}
								else
								{
									if ((GClass125.smethod_44() == 7 || GClass125.smethod_44() == 15) && GClass125.smethod_52())
									{
										try
										{
											GClass96.Class6 class3 = new GClass96.Class6();
											GClass126.smethod_2("Searching for BLE devices ...", 0);
											class3.foundBLEDeviceID = "";
											TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs> handler3 = new TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>(class3.method_0);
											BluetoothLEAdvertisementWatcher bluetoothLEAdvertisementWatcher5 = new BluetoothLEAdvertisementWatcher();
											bluetoothLEAdvertisementWatcher5.put_ScanningMode(1);
											BluetoothLEAdvertisementWatcher bluetoothLEAdvertisementWatcher6 = bluetoothLEAdvertisementWatcher5;
											BluetoothLEAdvertisementWatcher object2 = bluetoothLEAdvertisementWatcher6;
											WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>>(new Func<TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>, EventRegistrationToken>(object2.add_Received), new Action<EventRegistrationToken>(object2.remove_Received), handler3);
											bluetoothLEAdvertisementWatcher6.Start();
											long num17 = (long)(GClass126.smethod_1() + 10000);
											while (class3.foundBLEDeviceID == "" && num17 > (long)GClass126.smethod_1())
											{
												Thread.Sleep(50);
												if (GClass126.bool_25)
												{
													break;
												}
											}
											bluetoothLEAdvertisementWatcher6.Stop();
											if (class3.foundBLEDeviceID != "")
											{
												GClass126.smethod_2("Found BLE device " + class3.foundBLEDeviceID, 0);
												GClass125.smethod_56("BLE" + class3.foundBLEDeviceID);
												flag = true;
											}
											goto IL_2697;
										}
										catch (Exception ex30)
										{
											GClass126.smethod_2("ERROR: " + ex30.Message, 0);
											goto IL_2697;
										}
									}
									if (flag5)
									{
										int num18 = 0;
										while (num18 < 20 && !GClass126.bool_25)
										{
											Thread.Sleep(100);
											num18++;
										}
									}
									serialPort = new SerialPort(GClass125.smethod_40(num16), GClass125.smethod_42(num16), Parity.None, 8, StopBits.One);
									serialPort.WriteBufferSize = 2;
									serialPort.WriteTimeout = 5000;
									serialPort.ReceivedBytesThreshold = 1000;
									serialPort.Handshake = Handshake.None;
									serialPort.NewLine = "\r";
									serialPort.Open();
									GClass126.smethod_2("Serial port opened!", 0);
									if (GClass126.bool_25)
									{
										throw new Exception("ESC");
									}
									if (GClass125.smethod_38(num16) != 2 && GClass125.smethod_38(num16) != 3 && GClass125.smethod_38(num16) != 9 && GClass125.smethod_38(num16) != 8 && GClass125.smethod_38(num16) != 7 && GClass125.smethod_38(num16) != 12)
									{
										if (GClass125.smethod_38(num16) != 15)
										{
											if (GClass125.smethod_38(num16) == 6)
											{
												serialPort.NewLine = "\r";
												serialPort.ReadTimeout = 5000;
												GClass96.smethod_20(serialPort, null, null, "ATI");
												string text21 = "";
												try
												{
													text21 = GClass96.smethod_23(serialPort, null, null);
												}
												catch (Exception)
												{
													text21 = "";
												}
												if (text21.Contains("?"))
												{
													GClass96.smethod_20(serialPort, null, null, "ATI");
													try
													{
														text21 = GClass96.smethod_23(serialPort, null, null);
													}
													catch (Exception)
													{
														text21 = "";
													}
												}
												if (text21 == "")
												{
													GClass126.smethod_2("No response. Checking KKLmode...", 0);
													serialPort.ReadTimeout = 50;
													serialPort.ReadExisting();
													serialPort.Write(new byte[]
													{
														1
													}, 0, 1);
													byte b8 = (byte)serialPort.ReadByte();
													if (b8 != 1)
													{
														throw new Exception("Not a CANtieCAR interface! Echo: (" + GClass127.smethod_23(b8) + ")");
													}
													goto IL_2689;
												}
												else
												{
													if (!text21.Contains("ECUScan v3.4+"))
													{
														throw new Exception("Not a CANtieCAR interface!");
													}
													goto IL_2689;
												}
											}
											else
											{
												if (GClass125.smethod_38(num16) != 4 && GClass125.smethod_38(num16) != 5)
												{
													if (GClass125.smethod_38(num16) != 10)
													{
														if (GClass125.smethod_38(num16) != 1)
														{
															goto IL_2689;
														}
														serialPort.ReadTimeout = 50;
														serialPort.Write(new byte[1], 0, 1);
														byte b9 = (byte)serialPort.ReadByte();
														if (b9 != 0)
														{
															throw new Exception("Invalid echo (" + GClass127.smethod_23(b9) + "). Not VagCom!");
														}
														goto IL_2689;
													}
												}
												serialPort.NewLine = "\r";
												serialPort.ReadTimeout = 5000;
												GClass96.smethod_20(serialPort, null, null, "ATZ");
												string text22 = "";
												try
												{
													text22 = GClass96.smethod_23(serialPort, null, null);
												}
												catch (Exception)
												{
													text22 = "";
												}
												if (text22.Contains("?"))
												{
													GClass96.smethod_20(serialPort, null, null, "ATZ");
													try
													{
														text22 = GClass96.smethod_23(serialPort, null, null);
													}
													catch (Exception)
													{
														text22 = "";
													}
												}
												if (text22 == "")
												{
													GClass126.smethod_2("No response. Checking KKLmode...", 0);
													serialPort.ReadTimeout = 50;
													serialPort.ReadExisting();
													serialPort.Write(new byte[]
													{
														1
													}, 0, 1);
													byte b10 = (byte)serialPort.ReadByte();
													if (b10 != 1)
													{
														throw new Exception("Not an OBDKey interface! Echo: (" + GClass127.smethod_23(b10) + ")");
													}
													goto IL_2689;
												}
												else
												{
													if (!text22.Contains("OBDKey"))
													{
														throw new Exception("Not an OBDKey interface!");
													}
													goto IL_2689;
												}
											}
										}
									}
									serialPort.NewLine = "\r";
									serialPort.ReadTimeout = 5000;
									GClass96.smethod_20(serialPort, null, null, "ATI");
									string text23 = GClass96.smethod_23(serialPort, null, null);
									if (text23.Contains("?"))
									{
										GClass96.smethod_20(serialPort, null, null, "ATI");
										try
										{
											text23 = GClass96.smethod_23(serialPort, null, null);
										}
										catch (Exception)
										{
											text23 = "";
										}
									}
									if (!text23.Contains("ELM") && !text23.Contains("OBD"))
									{
										throw new Exception("Not an ELM interface!");
									}
									IL_2689:
									flag = true;
									GClass126.smethod_2("... done!", 0);
								}
								IL_2697:
								goto IL_274D;
							}
							catch (Exception ex31)
							{
								GClass126.smethod_2(ex31.Message, 0);
								GClass126.smethod_2(".... failed!", 0);
								goto IL_274D;
							}
							finally
							{
								if (serialPort != null && serialPort.IsOpen)
								{
									try
									{
										serialPort.Close();
										GClass126.smethod_2("Serial port closed!", 0);
										if (flag5)
										{
											int num19 = 0;
											while (num19 < 25 && !GClass126.bool_25)
											{
												Thread.Sleep(100);
												num19++;
											}
										}
									}
									catch (Exception ex32)
									{
										GClass126.smethod_2("ERROR: Failed to close serial port: " + ex32.Message, 0);
									}
								}
								if (tcpClient != null && tcpClient.Connected)
								{
									try
									{
										tcpClient.Close();
									}
									catch (Exception ex33)
									{
										GClass126.smethod_2("ERROR: Failed to close TCP connection: " + ex33.Message, 1);
									}
								}
							}
							goto IL_2742;
							IL_274D:
							if (flag)
							{
								goto IL_2751;
							}
							goto IL_2742;
						}
					}
					goto IL_2091;
				}
				IL_2742:;
			}
		}
		IL_2751:
		GClass126.smethod_2("****************************************************", 0);
		GClass126.smethod_2(GClass126.string_0, 0);
		if (flag)
		{
			string[] array5 = new string[6];
			array5[0] = "SELECTED INTERFACE: ";
			array5[1] = GClass125.string_1[GClass125.smethod_44()];
			array5[2] = ", ";
			array5[3] = GClass125.smethod_55();
			array5[4] = ", ";
			int num20 = 5;
			int j = GClass125.smethod_57();
			array5[num20] = j.ToString();
			GClass126.smethod_2(string.Concat(array5), 0);
		}
		else
		{
			GClass126.smethod_2("SUITABLE INTERFACE NOT FOUND!!!", 0);
		}
		GClass126.smethod_2("****************************************************", 0);
		return flag;
	}

	// Token: 0x06000377 RID: 887 RVA: 0x00003298 File Offset: 0x00001498
	public static bool smethod_6()
	{
		return GClass96.smethod_11(GClass96.string_0);
	}

	// Token: 0x06000378 RID: 888 RVA: 0x000032A4 File Offset: 0x000014A4
	public static bool smethod_7()
	{
		return GClass96.smethod_11(GClass96.string_2);
	}

	// Token: 0x06000379 RID: 889 RVA: 0x000032B0 File Offset: 0x000014B0
	public static bool smethod_8()
	{
		return GClass96.smethod_11(GClass96.string_1);
	}

	// Token: 0x0600037A RID: 890 RVA: 0x0005B07C File Offset: 0x0005927C
	private static void smethod_9()
	{
		GClass96.int_1 = 0;
		int num = 0;
		foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
		{
			if (networkInterface.OperationalStatus == OperationalStatus.Up)
			{
				foreach (GatewayIPAddressInformation gatewayIPAddressInformation in networkInterface.GetIPProperties().GatewayAddresses)
				{
					if (!(GClass96.string_3 != ""))
					{
						string text = gatewayIPAddressInformation.Address.ToString();
						GClass126.smethod_2("Network gateway: " + text, 0);
						if (text.StartsWith("192.168.") || text.StartsWith("10.0.") || text.StartsWith("10.10."))
						{
							string[] array = text.Split(new char[]
							{
								'.'
							});
							for (int j = 1; j < 255; j++)
							{
								GClass96.Class3 @class = new GClass96.Class3();
								@class.ip2 = string.Concat(new string[]
								{
									array[0],
									".",
									array[1],
									".",
									array[2],
									".",
									j.ToString()
								});
								if (GClass126.bool_25)
								{
									throw new Exception("ESC");
								}
								if (!(GClass96.string_3 != ""))
								{
									num += 2;
									new Thread(new ThreadStart(@class.method_0)).Start();
									new Thread(new ThreadStart(@class.method_1)).Start();
									if (j % 50 == 0 || j == 255)
									{
										long num2 = (long)(GClass126.smethod_1() + 2800);
										while (GClass96.int_1 < num && num2 > (long)GClass126.smethod_1())
										{
											Thread.Sleep(50);
											if (GClass126.bool_25)
											{
												throw new Exception("ESC");
											}
										}
										if (num2 <= (long)GClass126.smethod_1())
										{
											GClass126.smethod_2("Threads:  " + GClass96.int_1.ToString() + "/" + num.ToString(), 0);
										}
										GClass96.int_1 = num;
									}
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0600037B RID: 891 RVA: 0x0005B2D4 File Offset: 0x000594D4
	private static void smethod_10(string string_4, int int_2)
	{
		try
		{
			GClass126.smethod_2("Tesing WiFi device at " + string_4 + ":" + int_2.ToString(), 0);
			TcpClient tcpClient = new TcpClient();
			if (tcpClient.BeginConnect(string_4, int_2, null, null).AsyncWaitHandle.WaitOne(1500) && tcpClient.Connected)
			{
				GClass126.smethod_2("WiFi device found at " + string_4 + ":" + int_2.ToString(), 0);
				Thread.Sleep(100);
				if (GClass96.smethod_22(null, tcpClient, null, null, "AT@4").Contains("tieCAR"))
				{
					GClass96.string_3 = string_4;
					GClass96.int_0 = int_2;
				}
				try
				{
					tcpClient.Close();
					goto IL_D2;
				}
				catch (Exception ex)
				{
					GClass126.smethod_2("ERROR: Failed to close TCP connection: " + ex.Message, 1);
					goto IL_D2;
				}
			}
			GClass126.smethod_2("Not found at " + string_4 + ":" + int_2.ToString(), 0);
			IL_D2:;
		}
		catch (Exception ex2)
		{
			GClass126.smethod_2(string.Concat(new string[]
			{
				"ERROR(",
				string_4,
				":",
				int_2.ToString(),
				"): ",
				ex2.Message
			}), 1);
		}
		GClass96.int_1++;
	}

	// Token: 0x0600037C RID: 892 RVA: 0x0005B420 File Offset: 0x00059620
	public static bool smethod_11(string string_4)
	{
		SerialPort serialPort = null;
		TcpClient tcpClient = null;
		BluetoothLEDevice bluetoothLEDevice = null;
		GattDeviceService gattDeviceService = null;
		GattCharacteristic gattCharacteristic = null;
		GattCharacteristic gattCharacteristic2 = null;
		string text = "";
		string text2 = "";
		string str = GClass125.smethod_5();
		bool flag = false;
		try
		{
			GClass126.smethod_2("Checking CANtieCAR mode....", 1);
			try
			{
				if (GClass125.smethod_48())
				{
					GClass96.string_3 = GClass125.smethod_50();
					GClass96.int_0 = GClass125.smethod_51();
					GClass126.smethod_2("Trying to connect to CTC on " + GClass96.string_3 + ":" + GClass96.int_0.ToString(), 0);
					tcpClient = new TcpClient();
					tcpClient.SendTimeout = 1000;
					tcpClient.ReceiveTimeout = 2000;
					if (!tcpClient.BeginConnect(GClass96.string_3, GClass96.int_0, null, null).AsyncWaitHandle.WaitOne(2000) || !tcpClient.Connected)
					{
						throw new Exception("WiFi device not connected!");
					}
					GClass126.smethod_2("WiFi device connect successfull!", 0);
					for (int i = 0; i < 5; i++)
					{
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
				}
				else if (GClass125.smethod_52())
				{
					GClass126.smethod_2("BLE: Connect1", 0);
					bluetoothLEDevice = WindowsRuntimeSystemExtensions.AsTask<BluetoothLEDevice>(BluetoothLEDevice.FromBluetoothAddressAsync(ulong.Parse(GClass125.smethod_53(), NumberStyles.HexNumber))).GetAwaiter().GetResult();
					GClass126.smethod_2("BLE: Connect2", 0);
					GattDeviceServicesResult result = WindowsRuntimeSystemExtensions.AsTask<GattDeviceServicesResult>(bluetoothLEDevice.GetGattServicesForUuidAsync(Guid.Parse(GClass125.string_5), 1)).GetAwaiter().GetResult();
					if (result.Status == null)
					{
						GClass126.smethod_2("BLE: Connect gatt service", 0);
						gattDeviceService = result.Services[0];
						GattCharacteristicsResult result2 = WindowsRuntimeSystemExtensions.AsTask<GattCharacteristicsResult>(gattDeviceService.GetCharacteristicsAsync()).GetAwaiter().GetResult();
						if (result2.Status == null)
						{
							foreach (GattCharacteristic gattCharacteristic3 in result2.Characteristics)
							{
								if (gattCharacteristic3.Uuid == Guid.Parse(GClass125.string_6))
								{
									gattCharacteristic = gattCharacteristic3;
								}
								if (gattCharacteristic3.Uuid == Guid.Parse(GClass125.string_7))
								{
									gattCharacteristic2 = gattCharacteristic3;
								}
							}
						}
						if (gattCharacteristic2 != null && gattCharacteristic != null)
						{
							GClass126.smethod_2("BLE: Characteristics found", 0);
						}
						else
						{
							GClass126.smethod_2("BLE: Characteristic ERROR", 0);
						}
						WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(gattCharacteristic.WriteClientCharacteristicConfigurationDescriptorWithResultAsync(1)).GetAwaiter();
						GattCharacteristic @object = gattCharacteristic;
						WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>>(new Func<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>, EventRegistrationToken>(@object.add_ValueChanged), new Action<EventRegistrationToken>(@object.remove_ValueChanged), new TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>(GClass96.Class2.<>9.method_2));
						for (int j = 0; j < 5; j++)
						{
							if (GClass126.bool_25)
							{
								throw new Exception("ESC");
							}
							Thread.Sleep(100);
						}
					}
				}
				else
				{
					try
					{
						serialPort = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
						serialPort.WriteBufferSize = 2;
						serialPort.WriteTimeout = 1000;
						serialPort.ReceivedBytesThreshold = 1000;
						serialPort.Handshake = Handshake.None;
						serialPort.NewLine = "\r";
						serialPort.Open();
						GClass126.smethod_2("Serial port opened!", 1);
					}
					catch (Exception)
					{
					}
					serialPort.ReadTimeout = 1000;
					Thread.Sleep(5);
					try
					{
						serialPort.ReadExisting();
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			if (!(string_4 == GClass96.string_1) && !(string_4 == GClass96.string_2))
			{
				GClass96.smethod_20(serialPort, tcpClient, gattCharacteristic2, "!tieCAR_SC_M" + string_4);
				text = GClass96.smethod_23(serialPort, tcpClient, gattCharacteristic);
				text2 = GClass96.smethod_22(serialPort, tcpClient, gattCharacteristic2, gattCharacteristic, "AT@4");
			}
			else
			{
				GClass96.smethod_20(serialPort, tcpClient, gattCharacteristic2, "!tieCAR_SC_M" + string_4);
				text = GClass96.smethod_24(serialPort, tcpClient);
			}
		}
		catch (Exception ex2)
		{
			GClass126.smethod_2(ex2.Message, 1);
			GClass126.smethod_2(".... failed!", 1);
			flag = true;
		}
		finally
		{
			if (tcpClient != null && tcpClient.Connected)
			{
				try
				{
					tcpClient.Close();
				}
				catch (Exception ex3)
				{
					GClass126.smethod_2("ERROR: Failed to close TCP connection: " + ex3.Message, 1);
				}
			}
			if (serialPort != null && serialPort.IsOpen)
			{
				try
				{
					serialPort.Close();
					GClass126.smethod_2("Serial port closed!", 1);
				}
				catch (Exception ex4)
				{
					GClass126.smethod_2("ERROR: Failed to close serial port: " + ex4.Message, 1);
				}
			}
			if (bluetoothLEDevice != null)
			{
				if (gattDeviceService != null)
				{
					try
					{
						gattDeviceService.Session.Dispose();
						gattDeviceService.Dispose();
						GClass126.smethod_2("BLE gatt service closed!", 0);
					}
					catch (Exception ex5)
					{
						GClass126.smethod_2("ERROR: Failed to close BLE service: " + ex5.Message, 1);
					}
				}
				try
				{
					bluetoothLEDevice.Dispose();
					GClass126.smethod_2("BLE device closed!", 0);
				}
				catch (Exception ex6)
				{
					GClass126.smethod_2("ERROR: Failed to close BLE connection: " + ex6.Message, 1);
				}
			}
		}
		if (flag)
		{
			Thread.Sleep(2800);
			flag = false;
			try
			{
				GClass126.smethod_2("Retrying....", 1);
				if (GClass125.smethod_48())
				{
					GClass126.smethod_2("Trying to connect to CTC on " + GClass96.string_3 + ":" + GClass96.int_0.ToString(), 0);
					tcpClient = new TcpClient();
					tcpClient.SendTimeout = 1000;
					tcpClient.ReceiveTimeout = 2000;
					if (!tcpClient.BeginConnect(GClass96.string_3, GClass96.int_0, null, null).AsyncWaitHandle.WaitOne(2000) || !tcpClient.Connected)
					{
						throw new Exception("WiFi device not connected!");
					}
					GClass126.smethod_2("WiFi device connect successfull!", 0);
					for (int k = 0; k < 5; k++)
					{
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
				}
				else if (GClass125.smethod_52())
				{
					GClass126.smethod_2("BLE: Connect1", 0);
					bluetoothLEDevice = WindowsRuntimeSystemExtensions.AsTask<BluetoothLEDevice>(BluetoothLEDevice.FromBluetoothAddressAsync(ulong.Parse(GClass125.smethod_53(), NumberStyles.HexNumber))).GetAwaiter().GetResult();
					GClass126.smethod_2("BLE: Connect2", 0);
					GattDeviceServicesResult result3 = WindowsRuntimeSystemExtensions.AsTask<GattDeviceServicesResult>(bluetoothLEDevice.GetGattServicesForUuidAsync(Guid.Parse(GClass125.string_5), 1)).GetAwaiter().GetResult();
					if (result3.Status == null)
					{
						GClass126.smethod_2("BLE: Connect gatt service", 0);
						gattDeviceService = result3.Services[0];
						GattCharacteristicsResult result4 = WindowsRuntimeSystemExtensions.AsTask<GattCharacteristicsResult>(gattDeviceService.GetCharacteristicsAsync()).GetAwaiter().GetResult();
						if (result4.Status == null)
						{
							foreach (GattCharacteristic gattCharacteristic4 in result4.Characteristics)
							{
								if (gattCharacteristic4.Uuid == Guid.Parse(GClass125.string_6))
								{
									gattCharacteristic = gattCharacteristic4;
								}
								if (gattCharacteristic4.Uuid == Guid.Parse(GClass125.string_7))
								{
									gattCharacteristic2 = gattCharacteristic4;
								}
							}
						}
						if (gattCharacteristic2 != null && gattCharacteristic != null)
						{
							GClass126.smethod_2("BLE: Characteristics found", 0);
						}
						else
						{
							GClass126.smethod_2("BLE: Characteristic ERROR", 0);
						}
						WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(gattCharacteristic.WriteClientCharacteristicConfigurationDescriptorWithResultAsync(1)).GetAwaiter();
						GattCharacteristic @object = gattCharacteristic;
						WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>>(new Func<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>, EventRegistrationToken>(@object.add_ValueChanged), new Action<EventRegistrationToken>(@object.remove_ValueChanged), new TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>(GClass96.Class2.<>9.method_3));
						for (int l = 0; l < 5; l++)
						{
							if (GClass126.bool_25)
							{
								throw new Exception("ESC");
							}
							Thread.Sleep(100);
						}
					}
				}
				else
				{
					serialPort = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
					serialPort.WriteBufferSize = 2;
					serialPort.WriteTimeout = 1000;
					serialPort.ReceivedBytesThreshold = 1000;
					serialPort.Handshake = Handshake.None;
					serialPort.NewLine = "\r";
					serialPort.Open();
					GClass126.smethod_2("Serial port opened!", 1);
					serialPort.ReadTimeout = 1000;
					Thread.Sleep(5);
					try
					{
						serialPort.ReadExisting();
					}
					catch (Exception)
					{
					}
				}
				if (!(string_4 == GClass96.string_1) && !(string_4 == GClass96.string_2))
				{
					GClass96.smethod_20(serialPort, tcpClient, gattCharacteristic2, "!tieCAR_SC_M" + string_4);
					text = GClass96.smethod_23(serialPort, tcpClient, gattCharacteristic);
					text2 = GClass96.smethod_22(serialPort, tcpClient, gattCharacteristic2, gattCharacteristic, "AT@4");
				}
				else
				{
					GClass96.smethod_20(serialPort, tcpClient, gattCharacteristic2, "!tieCAR_SC_M" + string_4);
					text = GClass96.smethod_24(serialPort, tcpClient);
				}
			}
			catch (Exception ex7)
			{
				GClass126.smethod_2(ex7.Message, 1);
				GClass126.smethod_2(".... failed!", 1);
				flag = true;
			}
			finally
			{
				if (tcpClient != null && tcpClient.Connected)
				{
					try
					{
						tcpClient.Close();
					}
					catch (Exception ex8)
					{
						GClass126.smethod_2("ERROR: Failed to close TCP connection: " + ex8.Message, 1);
					}
				}
				if (serialPort != null && serialPort.IsOpen)
				{
					try
					{
						serialPort.Close();
						GClass126.smethod_2("Serial port closed!", 1);
					}
					catch (Exception ex9)
					{
						GClass126.smethod_2("ERROR: Failed to close serial port: " + ex9.Message, 1);
					}
				}
				if (bluetoothLEDevice != null)
				{
					if (gattDeviceService != null)
					{
						try
						{
							gattDeviceService.Session.Dispose();
							gattDeviceService.Dispose();
							GClass126.smethod_2("BLE gatt service closed!", 0);
						}
						catch (Exception ex10)
						{
							GClass126.smethod_2("ERROR: Failed to close BLE service: " + ex10.Message, 1);
						}
					}
					try
					{
						bluetoothLEDevice.Dispose();
						GClass126.smethod_2("BLE device closed!", 0);
					}
					catch (Exception ex11)
					{
						GClass126.smethod_2("ERROR: Failed to close BLE connection: " + ex11.Message, 1);
					}
				}
			}
		}
		if (flag)
		{
			return false;
		}
		int num = 0;
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
					string text3 = text.Substring(num, num2 - num).Trim(GClass96.char_0);
					for (int m = 0; m < array.Length; m++)
					{
						if (text3.StartsWith(array[m]))
						{
							array[m] = text3.Substring(array[m].Length);
							break;
						}
					}
				}
				num = num2 + 1;
			}
			for (int n = 0; n < array.Length; n++)
			{
				GClass126.smethod_2(array[n], 1);
			}
		}
		GClass126.string_9 = array[2];
		text2 = text2.Replace("AT@4", "").Replace(">", "");
		text2 = text2.Trim(GClass96.char_0);
		if (string_4 == GClass96.string_1 || string_4 == GClass96.string_2)
		{
			text2 = "CANtieCAR_" + GClass126.string_9;
		}
		string text4 = str + "_" + text2;
		string text5 = GClass127.smethod_36(text4);
		text4 = GClass125.smethod_7() + "_" + text2;
		if (text4.Length > text2.Length + 11)
		{
			text5 += GClass127.smethod_36(text4);
		}
		text4 = GClass125.smethod_9() + "_" + text2;
		if (text4.Length > text2.Length + 13)
		{
			text5 += GClass127.smethod_36(text4);
		}
		GClass126.byte_3 = GClass127.smethod_32(text5);
		if (!array[6].Contains(string_4))
		{
			Thread.Sleep(2000);
		}
		GClass125.smethod_87(text2);
		GClass125.string_31 = GClass126.string_9;
		GClass126.smethod_2("... done!", 1);
		GClass126.smethod_2("-------------------------------------", 1);
		GClass126.smethod_2(" ", 1);
		return true;
	}

	// Token: 0x0600037D RID: 893 RVA: 0x0005C124 File Offset: 0x0005A324
	public static bool smethod_12()
	{
		bool result = false;
		try
		{
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
		}
		catch (Exception)
		{
			Thread.Sleep(300);
			result = true;
		}
		return result;
	}

	// Token: 0x0600037E RID: 894 RVA: 0x0005C218 File Offset: 0x0005A418
	public static string smethod_13()
	{
		string result = "";
		try
		{
			ManagementObjectCollection managementObjectCollection;
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0 and Caption LIKE '%(COM%' and PNPDeviceID LIKE '%VID_03EB%'  and PNPDeviceID LIKE '%PID_6132%' "))
			{
				managementObjectCollection = managementObjectSearcher.Get();
			}
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					string text = (string)enumerator.Current.GetPropertyValue("Caption");
					string text2 = text.Substring(text.LastIndexOf("(COM")).Replace("(", string.Empty).Replace(")", string.Empty);
					for (int i = 500; i > 0; i--)
					{
						if (text2.Contains("COM" + i.ToString()))
						{
							result = "COM" + i.ToString();
							break;
						}
					}
				}
			}
			managementObjectCollection.Dispose();
		}
		catch (Exception)
		{
		}
		return result;
	}

	// Token: 0x0600037F RID: 895 RVA: 0x0005C324 File Offset: 0x0005A524
	private static string[] smethod_14()
	{
		List<string> list = new List<string>();
		try
		{
			ManagementObjectCollection managementObjectCollection;
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0 and Caption LIKE '%CANtieCAR%' "))
			{
				managementObjectCollection = managementObjectSearcher.Get();
			}
			ManagementObjectCollection managementObjectCollection2;
			using (ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0 and Caption LIKE '%Bluetooth%(COM%' and PNPDeviceID LIKE '%BTHENUM%' "))
			{
				managementObjectCollection2 = managementObjectSearcher2.Get();
			}
			foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
			{
				string text = (string)managementBaseObject.GetPropertyValue("DeviceID");
				string text2 = text.Substring(text.IndexOf("BLUETOOTHDEVICE_") + 16);
				GClass126.smethod_2("BTSEARCH1: " + text, 0);
				GClass126.smethod_2("BTSEARCH1: " + text2, 0);
				if (text2.Length >= 6)
				{
					foreach (ManagementBaseObject managementBaseObject2 in managementObjectCollection2)
					{
						string text3 = (string)managementBaseObject2.GetPropertyValue("DeviceID");
						GClass126.smethod_2("BTSEARCH2: " + text3, 0);
						if (text3.Contains(text2))
						{
							string text4 = (string)managementBaseObject2.GetPropertyValue("Caption");
							string text5 = text4.Substring(text4.LastIndexOf("(COM")).Replace("(", string.Empty).Replace(")", string.Empty);
							GClass126.smethod_2("BTSEARCH3: " + text5, 0);
							for (int i = 500; i > 0; i--)
							{
								if (text5.Contains("COM" + i.ToString()))
								{
									list.Add("COM" + i.ToString());
									break;
								}
							}
							break;
						}
					}
				}
			}
			managementObjectCollection.Dispose();
			managementObjectCollection2.Dispose();
		}
		catch (Exception)
		{
		}
		return list.ToArray();
	}

	// Token: 0x06000380 RID: 896 RVA: 0x0005C590 File Offset: 0x0005A790
	public static string smethod_15()
	{
		string text = GClass96.smethod_13();
		if (text.Length > 0)
		{
			GClass125.smethod_39(0, 16);
			GClass125.smethod_39(1, 13);
			GClass125.smethod_39(2, 0);
			GClass125.smethod_39(3, 0);
			GClass125.smethod_41(0, text);
			GClass125.smethod_43(0, 115200);
			GClass125.smethod_41(1, "IP10.10.1.1:35000");
		}
		return text;
	}

	// Token: 0x06000381 RID: 897 RVA: 0x0005C5E8 File Offset: 0x0005A7E8
	public static List<byte> smethod_16(List<string> list_0)
	{
		byte[] array = GClass96.smethod_18();
		List<byte> list = new List<byte>();
		list.Add(0);
		list.Add(205);
		list.Add(2);
		list.Add(0);
		for (int i = 0; i < list_0.Count; i++)
		{
			list.AddRange(Encoding.ASCII.GetBytes(list_0[i]));
			list.Add(0);
		}
		GClass126.smethod_2("Data lenght: " + list.Count.ToString(), 0);
		while (list.Count < 1984)
		{
			list.Add(0);
		}
		byte b = 0;
		for (int j = 0; j < list.Count; j++)
		{
			b += list[j];
		}
		list[0] = b;
		byte[] collection = list.ToArray();
		GClass127.smethod_34(ref collection, array);
		list.Clear();
		list.AddRange(array);
		list.AddRange(collection);
		return list;
	}

	// Token: 0x06000382 RID: 898 RVA: 0x0005C6DC File Offset: 0x0005A8DC
	public static List<string> smethod_17(string string_4)
	{
		return new List<string>
		{
			"ATE0\rATL0\rATIB10\rATSP5\rATS0\rATAL\rATAT1\rATST62\rATSH81" + string_4 + "F1",
			"ATFI",
			"ATMI10",
			"ATMI30",
			"ATMI70",
			"ATMI90",
			"ATMIC0",
			" "
		};
	}

	// Token: 0x06000383 RID: 899 RVA: 0x0005C754 File Offset: 0x0005A954
	private static byte[] smethod_18()
	{
		byte[] array = new byte[64];
		Random random = new Random();
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (byte)random.Next(0, 255);
		}
		return array;
	}

	// Token: 0x06000384 RID: 900 RVA: 0x0005C790 File Offset: 0x0005A990
	private static string[] smethod_19()
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		try
		{
			ManagementObjectCollection managementObjectCollection;
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0 and Caption LIKE '%(COM%' "))
			{
				managementObjectCollection = managementObjectSearcher.Get();
			}
			foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
			{
				string text = (string)managementBaseObject.GetPropertyValue("Caption");
				string text2 = text.Substring(text.LastIndexOf("(COM")).Replace("(", string.Empty).Replace(")", string.Empty);
				string text3 = (string)managementBaseObject.GetPropertyValue("PNPDeviceID");
				GClass126.smethod_2("WMI: " + text + ", " + text3, 0);
				bool flag = text.Contains("Bluetooth") || text3.Contains("BTHENUM");
				bool flag2 = text3.Contains("VID_0403") && text3.Contains("PID_60");
				bool flag3 = text3.Contains("VID_10C4") && text3.Contains("PID_EA60");
				bool flag4 = text3.Contains("VID_067B") && text3.Contains("PID_230");
				bool flag5 = text3.Contains("VID_1A86") && text3.Contains("PID_7523");
				bool flag6 = text3.Contains("VID_0918") && text3.Contains("PID_7104");
				if (flag || flag2 || flag3 || flag4 || flag5 || flag6)
				{
					int i = 500;
					while (i > 0)
					{
						if (!text2.Contains("COM" + i.ToString()))
						{
							i--;
						}
						else
						{
							GClass126.smethod_2("PORT OK", 0);
							if (flag)
							{
								list2.Add("BTCOM" + i.ToString());
								break;
							}
							list.Add("USCOM" + i.ToString());
							break;
						}
					}
				}
			}
			managementObjectCollection.Dispose();
		}
		catch (Exception ex)
		{
			GClass126.smethod_2("WMI ERROR: " + ex.Message, 0);
		}
		list.AddRange(list2);
		return list.ToArray();
	}

	// Token: 0x06000385 RID: 901 RVA: 0x0005CA24 File Offset: 0x0005AC24
	private static void smethod_20(SerialPort serialPort_0, TcpClient tcpClient_0, GattCharacteristic gattCharacteristic_0, string string_4)
	{
		if (tcpClient_0 != null)
		{
			GClass96.smethod_25(tcpClient_0, string_4);
			return;
		}
		if (gattCharacteristic_0 != null)
		{
			GClass96.smethod_26(gattCharacteristic_0, string_4);
			return;
		}
		GClass126.smethod_2("Send: " + string_4, 0);
		for (int i = 0; i < string_4.Length; i++)
		{
			serialPort_0.Write(string_4.Substring(i, 1));
		}
		serialPort_0.Write(serialPort_0.NewLine);
	}

	// Token: 0x06000386 RID: 902 RVA: 0x000032BC File Offset: 0x000014BC
	private static void smethod_21(SerialPort serialPort_0, TcpClient tcpClient_0, GattCharacteristic gattCharacteristic_0, string string_4)
	{
		GClass126.smethod_2("Send: " + string_4, 0);
		serialPort_0.WriteLine(string_4);
	}

	// Token: 0x06000387 RID: 903 RVA: 0x000032D6 File Offset: 0x000014D6
	private static string smethod_22(SerialPort serialPort_0, TcpClient tcpClient_0, GattCharacteristic gattCharacteristic_0, GattCharacteristic gattCharacteristic_1, string string_4)
	{
		GClass96.smethod_20(serialPort_0, tcpClient_0, gattCharacteristic_0, string_4);
		string text = GClass96.smethod_23(serialPort_0, tcpClient_0, gattCharacteristic_1);
		if (!text.Contains("OK"))
		{
			GClass126.smethod_2("[" + string_4 + "] failed!", 0);
		}
		return text;
	}

	// Token: 0x06000388 RID: 904 RVA: 0x0005CA84 File Offset: 0x0005AC84
	private static string smethod_23(SerialPort serialPort_0, TcpClient tcpClient_0, GattCharacteristic gattCharacteristic_0)
	{
		if (tcpClient_0 != null)
		{
			return GClass96.smethod_27(tcpClient_0);
		}
		if (gattCharacteristic_0 != null)
		{
			return GClass96.smethod_28(gattCharacteristic_0);
		}
		string text = "";
		while (!text.EndsWith(">"))
		{
			text += ((char)serialPort_0.ReadByte()).ToString();
		}
		GClass126.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x06000389 RID: 905 RVA: 0x0005CAE4 File Offset: 0x0005ACE4
	private static string smethod_24(SerialPort serialPort_0, TcpClient tcpClient_0)
	{
		if (tcpClient_0 != null)
		{
			return GClass96.smethod_29(tcpClient_0);
		}
		string text = "";
		while (!text.EndsWith(">") && !text.EndsWith("\r\n\r\n"))
		{
			text += ((char)serialPort_0.ReadByte()).ToString();
		}
		GClass126.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x0600038A RID: 906 RVA: 0x0005CB48 File Offset: 0x0005AD48
	private static void smethod_25(TcpClient tcpClient_0, string string_4)
	{
		GClass126.smethod_2("Send (TCP): " + string_4, 0);
		byte[] bytes = Encoding.ASCII.GetBytes(string_4 + "\n\r");
		byte[] array = new byte[1];
		for (int i = 0; i < bytes.Length; i++)
		{
			array[0] = bytes[i];
			tcpClient_0.Client.Send(array);
		}
	}

	// Token: 0x0600038B RID: 907 RVA: 0x0005CBA4 File Offset: 0x0005ADA4
	private static void smethod_26(GattCharacteristic gattCharacteristic_0, string string_4)
	{
		GClass126.smethod_2("Send (BLE): " + string_4, 0);
		byte[] bytes = Encoding.ASCII.GetBytes(string_4 + "\r");
		if (GClass96.stringBuilder_0.Length > 0)
		{
			GClass126.smethod_2("CLEAR PREVIOUS RESPONSES: " + GClass96.stringBuilder_0.ToString() + "\r-------------", 0);
		}
		GClass96.stringBuilder_0.Clear();
		WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(gattCharacteristic_0.WriteValueWithResultAsync(WindowsRuntimeBufferExtensions.AsBuffer(bytes))).GetAwaiter().GetResult();
	}

	// Token: 0x0600038C RID: 908 RVA: 0x0005CC30 File Offset: 0x0005AE30
	private static string smethod_27(TcpClient tcpClient_0)
	{
		string text = "";
		long num = (long)(GClass126.smethod_1() + 3500);
		while (!text.EndsWith(">") && num > (long)GClass126.smethod_1())
		{
			if (tcpClient_0.Client.Available > 0)
			{
				int num2 = tcpClient_0.GetStream().ReadByte();
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
		GClass126.smethod_2("Response (TCP): " + text, 0);
		return text;
	}

	// Token: 0x0600038D RID: 909 RVA: 0x0005CCC0 File Offset: 0x0005AEC0
	private static string smethod_28(GattCharacteristic gattCharacteristic_0)
	{
		string text = "";
		long num = (long)(GClass126.smethod_1() + 3500);
		while (!text.EndsWith(">") && num > (long)GClass126.smethod_1() && text.Length < 6000)
		{
			if (GClass96.stringBuilder_0.Length > 0)
			{
				text += GClass96.stringBuilder_0[0].ToString();
				GClass96.stringBuilder_0.Remove(0, 1);
				num = (long)(GClass126.smethod_1() + 2500);
			}
			else
			{
				Thread.Sleep(5);
			}
		}
		GClass126.smethod_2("Response (BLE): " + text, 0);
		return text;
	}

	// Token: 0x0600038E RID: 910 RVA: 0x0005CD60 File Offset: 0x0005AF60
	private static string smethod_29(TcpClient tcpClient_0)
	{
		string text = "";
		long num = (long)(GClass126.smethod_1() + 3500);
		while (!text.EndsWith(">") && !text.EndsWith("\r\n\r\n") && num > (long)GClass126.smethod_1())
		{
			if (tcpClient_0.Client.Available > 0)
			{
				int num2 = tcpClient_0.GetStream().ReadByte();
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
		GClass126.smethod_2("Response (TCP): " + text, 0);
		return text;
	}

	// Token: 0x0600038F RID: 911 RVA: 0x0005CE00 File Offset: 0x0005B000
	private static string smethod_30(GattCharacteristic gattCharacteristic_0)
	{
		string text = "";
		int num = 0;
		long num2 = (long)(GClass126.smethod_1() + 8000);
		while (!text.EndsWith(">") && !text.EndsWith("\r\n\r\n") && num2 > (long)GClass126.smethod_1())
		{
			GattReadResult result = WindowsRuntimeSystemExtensions.AsTask<GattReadResult>(gattCharacteristic_0.ReadValueAsync(0)).GetAwaiter().GetResult();
			text = Encoding.ASCII.GetString(WindowsRuntimeBufferExtensions.ToArray(result.Value));
			if (num != text.Length)
			{
				num = text.Length;
				num2 = (long)(GClass126.smethod_1() + 3500);
			}
			else
			{
				Thread.Sleep(5);
			}
		}
		GClass126.smethod_2("Response (BLE): " + text, 0);
		return text;
	}

	// Token: 0x04000269 RID: 617
	public static string string_0 = "FES";

	// Token: 0x0400026A RID: 618
	public static string string_1 = "KK0";

	// Token: 0x0400026B RID: 619
	public static string string_2 = "K4K";

	// Token: 0x0400026C RID: 620
	private static string string_3 = "";

	// Token: 0x0400026D RID: 621
	private static int int_0 = 23;

	// Token: 0x0400026E RID: 622
	private static int int_1 = 0;

	// Token: 0x0400026F RID: 623
	private static char[] char_0 = new char[]
	{
		'\r',
		'\n',
		' '
	};

	// Token: 0x04000270 RID: 624
	private static StringBuilder stringBuilder_0 = new StringBuilder(1000);

	// Token: 0x0200005F RID: 95
	[CompilerGenerated]
	[Serializable]
	private sealed class Class2
	{
		// Token: 0x06000393 RID: 915 RVA: 0x0000331A File Offset: 0x0000151A
		internal void method_0(GattCharacteristic sender, GattValueChangedEventArgs args)
		{
			GClass96.stringBuilder_0.Append(Encoding.ASCII.GetString(WindowsRuntimeBufferExtensions.ToArray(args.CharacteristicValue)));
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0000331A File Offset: 0x0000151A
		internal void method_1(GattCharacteristic sender, GattValueChangedEventArgs args)
		{
			GClass96.stringBuilder_0.Append(Encoding.ASCII.GetString(WindowsRuntimeBufferExtensions.ToArray(args.CharacteristicValue)));
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0000331A File Offset: 0x0000151A
		internal void method_2(GattCharacteristic sender, GattValueChangedEventArgs args)
		{
			GClass96.stringBuilder_0.Append(Encoding.ASCII.GetString(WindowsRuntimeBufferExtensions.ToArray(args.CharacteristicValue)));
		}

		// Token: 0x06000396 RID: 918 RVA: 0x0000331A File Offset: 0x0000151A
		internal void method_3(GattCharacteristic sender, GattValueChangedEventArgs args)
		{
			GClass96.stringBuilder_0.Append(Encoding.ASCII.GetString(WindowsRuntimeBufferExtensions.ToArray(args.CharacteristicValue)));
		}

		// Token: 0x04000271 RID: 625
		public static readonly GClass96.Class2 <>9 = new GClass96.Class2();

		// Token: 0x04000272 RID: 626
		public static TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs> <>9__5_0;

		// Token: 0x04000273 RID: 627
		public static TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs> <>9__5_2;

		// Token: 0x04000274 RID: 628
		public static TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs> <>9__18_0;

		// Token: 0x04000275 RID: 629
		public static TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs> <>9__18_1;
	}

	// Token: 0x02000060 RID: 96
	[CompilerGenerated]
	private sealed class Class3
	{
		// Token: 0x06000398 RID: 920 RVA: 0x0000333C File Offset: 0x0000153C
		internal void method_0()
		{
			GClass96.smethod_10(this.ip2, 23);
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0000334B File Offset: 0x0000154B
		internal void method_1()
		{
			GClass96.smethod_10(this.ip2, 35000);
		}

		// Token: 0x04000276 RID: 630
		public string ip2;
	}

	// Token: 0x02000061 RID: 97
	[CompilerGenerated]
	private sealed class Class4
	{
		// Token: 0x0600039B RID: 923 RVA: 0x0005CF18 File Offset: 0x0005B118
		internal void method_0(BluetoothLEAdvertisementWatcher s, BluetoothLEAdvertisementReceivedEventArgs e)
		{
			GClass126.smethod_2("BLE: " + e.Advertisement.LocalName, 0);
			if (e.Advertisement.LocalName.StartsWith("CANtieCAR"))
			{
				this.foundBLEDeviceID = e.BluetoothAddress.ToString("x").ToUpper();
			}
		}

		// Token: 0x04000277 RID: 631
		public string foundBLEDeviceID;
	}

	// Token: 0x02000062 RID: 98
	[CompilerGenerated]
	private sealed class Class5
	{
		// Token: 0x0600039D RID: 925 RVA: 0x0005CF78 File Offset: 0x0005B178
		internal void method_0(BluetoothLEAdvertisementWatcher s, BluetoothLEAdvertisementReceivedEventArgs e)
		{
			GClass126.smethod_2("BLE: " + e.Advertisement.LocalName, 0);
			if (e.Advertisement.LocalName.StartsWith("IOS-Vlink") || e.Advertisement.LocalName.StartsWith("vLinker"))
			{
				this.foundBLEDeviceID = e.BluetoothAddress.ToString("x").ToUpper();
				this.string_0 = e.Advertisement.LocalName;
			}
		}

		// Token: 0x04000278 RID: 632
		public string foundBLEDeviceID;

		// Token: 0x04000279 RID: 633
		public string string_0;
	}

	// Token: 0x02000063 RID: 99
	[CompilerGenerated]
	private sealed class Class6
	{
		// Token: 0x0600039F RID: 927 RVA: 0x0005D000 File Offset: 0x0005B200
		internal void method_0(BluetoothLEAdvertisementWatcher s, BluetoothLEAdvertisementReceivedEventArgs e)
		{
			GClass126.smethod_2("BLE: " + e.Advertisement.LocalName, 0);
			if (e.Advertisement.LocalName.StartsWith("IOS-Vlink") || e.Advertisement.LocalName.StartsWith("vLinker"))
			{
				this.foundBLEDeviceID = e.BluetoothAddress.ToString("x").ToUpper();
			}
		}

		// Token: 0x0400027A RID: 634
		public string foundBLEDeviceID;
	}
}
