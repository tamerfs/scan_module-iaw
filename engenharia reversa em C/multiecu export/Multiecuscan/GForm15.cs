using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Foundation;

// Token: 0x020000B6 RID: 182
public partial class GForm15 : Form
{
	// Token: 0x060005F4 RID: 1524 RVA: 0x000D7FE8 File Offset: 0x000D61E8
	public GForm15(string string_2, int int_2, int int_3)
	{
		this.method_14();
		this.string_1 = string_2;
		this.int_0 = int_2;
		this.int_1 = int_3;
		if ((int_3 == 4 || int_3 == 5) && !GClass96.smethod_4(string_2, int_2))
		{
			new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("1074"), GClass121.smethod_6("1075"), true, 0).ShowDialog();
		}
		if (int_3 == 1)
		{
			new Thread(new ThreadStart(this.method_2)).Start();
			return;
		}
		if (int_3 != 6)
		{
			if (int_3 != 13)
			{
				new Thread(new ThreadStart(this.method_0)).Start();
				return;
			}
		}
		new Thread(new ThreadStart(this.method_1)).Start();
	}

	// Token: 0x060005F5 RID: 1525 RVA: 0x000D80E0 File Offset: 0x000D62E0
	private void method_0()
	{
		if (this.int_1 == 5)
		{
			this.string_0 = this.string_0 + "Waiting for OBDKey..." + Environment.NewLine;
			this.bool_0 = false;
			Thread.Sleep(4000);
		}
		if (this.int_1 == 4 || this.int_1 == 5)
		{
			this.string_0 = this.string_0 + "Testing OBDKey..." + Environment.NewLine;
			this.bool_0 = false;
			GClass96.smethod_2(true, this.string_1, this.int_0);
			Thread.Sleep(4000);
		}
		try
		{
			if (this.int_1 != 9 && this.int_1 != 10)
			{
				if (this.int_1 != 12)
				{
					if (!this.string_1.StartsWith("BLE"))
					{
						this.string_0 = this.string_0 + "Connecting to device..." + Environment.NewLine;
						this.bool_0 = false;
						this.serialPort_0 = new SerialPort(this.string_1, this.int_0, Parity.None, 8, StopBits.One);
						this.serialPort_0.WriteBufferSize = 2;
						this.serialPort_0.WriteTimeout = 2000;
						this.serialPort_0.ReceivedBytesThreshold = 1000;
						this.serialPort_0.Handshake = Handshake.None;
						if (this.int_1 != 4)
						{
							if (this.int_1 != 5)
							{
								this.serialPort_0.NewLine = "\r";
								goto IL_44E;
							}
						}
						this.serialPort_0.NewLine = "\r";
						IL_44E:
						this.serialPort_0.Open();
						this.serialPort_0.ReadTimeout = 2000;
						goto IL_520;
					}
					GForm15.Class13 @class = new GForm15.Class13();
					this.string_0 = this.string_0 + "Connecting to Bluetooth LE device..." + Environment.NewLine;
					this.bool_0 = false;
					GClass126.smethod_2("Searching for BLE devices ...", 0);
					@class.foundBLEDeviceID = "";
					TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs> handler = new TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>(@class.method_0);
					BluetoothLEAdvertisementWatcher bluetoothLEAdvertisementWatcher = new BluetoothLEAdvertisementWatcher();
					bluetoothLEAdvertisementWatcher.put_ScanningMode(1);
					BluetoothLEAdvertisementWatcher bluetoothLEAdvertisementWatcher2 = bluetoothLEAdvertisementWatcher;
					BluetoothLEAdvertisementWatcher @object = bluetoothLEAdvertisementWatcher2;
					WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>>(new Func<TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>, EventRegistrationToken>(@object.add_Received), new Action<EventRegistrationToken>(@object.remove_Received), handler);
					bluetoothLEAdvertisementWatcher2.Start();
					long num = (long)(GClass126.smethod_1() + 10000);
					while (@class.foundBLEDeviceID == "" && num > (long)GClass126.smethod_1())
					{
						Thread.Sleep(50);
					}
					bluetoothLEAdvertisementWatcher2.Stop();
					if (@class.foundBLEDeviceID == "")
					{
						throw new Exception("Bluetooth LE device not found!");
					}
					GClass126.smethod_2("BLE: Connect1", 0);
					this.bluetoothLEDevice_0 = WindowsRuntimeSystemExtensions.AsTask<BluetoothLEDevice>(BluetoothLEDevice.FromBluetoothAddressAsync(ulong.Parse(@class.foundBLEDeviceID, NumberStyles.HexNumber))).GetAwaiter().GetResult();
					GClass126.smethod_2("BLE: Connect2", 0);
					GattDeviceServicesResult result = WindowsRuntimeSystemExtensions.AsTask<GattDeviceServicesResult>(this.bluetoothLEDevice_0.GetGattServicesForUuidAsync(Guid.Parse(GClass125.string_8), 1)).GetAwaiter().GetResult();
					if (result.Status == null)
					{
						GClass126.smethod_2("BLE: Connect gatt service", 0);
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
							GClass126.smethod_2("BLE: Characteristics found", 0);
						}
						else
						{
							GClass126.smethod_2("BLE: Characteristic ERROR", 0);
						}
						WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(this.gattCharacteristic_0.WriteClientCharacteristicConfigurationDescriptorWithResultAsync(1)).GetAwaiter();
						GattCharacteristic object2 = this.gattCharacteristic_0;
						WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>>(new Func<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>, EventRegistrationToken>(object2.add_ValueChanged), new Action<EventRegistrationToken>(object2.remove_ValueChanged), new TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>(this.method_15));
						for (int i = 0; i < 5; i++)
						{
							if (GClass126.bool_25)
							{
								throw new Exception("ESC");
							}
							Thread.Sleep(100);
						}
					}
					if (this.bluetoothLEDevice_0 == null || this.gattDeviceService_0 == null || this.gattCharacteristic_1 == null)
					{
						throw new Exception("Bluetooth LE device not connected!");
					}
					goto IL_520;
				}
			}
			this.string_0 = this.string_0 + "Connecting to WiFi device..." + Environment.NewLine;
			this.bool_0 = false;
			this.tcpClient_0 = new TcpClient();
			int num2 = this.string_1.IndexOf(':');
			if (num2 < 10 || num2 > 18)
			{
				throw new Exception("Invalid IP address!");
			}
			this.tcpClient_0.Connect(this.string_1.Substring(2, num2 - 2), GClass127.smethod_37(this.string_1.Substring(num2 + 1)));
			if (!this.tcpClient_0.Connected)
			{
				throw new Exception("WiFi device not connected!");
			}
			GClass126.smethod_2("WiFi device connect successfull!", 0);
			for (int j = 0; j < 5; j++)
			{
				Thread.Sleep(100);
			}
			IL_520:
			this.method_7("ATZ", true);
			if (this.int_1 == 4)
			{
				this.serialPort_0.ReadTimeout = 100;
				this.method_6("ATBRD16");
				string text = ((char)this.serialPort_0.ReadByte()).ToString() ?? "";
				while (!text.Contains("OK\r") && !text.Contains("?") && text.Length < 20)
				{
					text += ((char)this.serialPort_0.ReadByte()).ToString();
				}
				this.serialPort_0.BaudRate = 250000;
				this.serialPort_0.ReadTimeout = 100;
				text = (((char)this.serialPort_0.ReadByte()).ToString() ?? "");
				while (!text.Contains("\r") && text.Length < 20)
				{
					text += ((char)this.serialPort_0.ReadByte()).ToString();
				}
				this.method_7("", false);
			}
			if (this.int_1 == 11)
			{
				this.string_0 = this.string_0 + "Switching ELM to 230400 bps..." + Environment.NewLine + Environment.NewLine;
				this.bool_0 = false;
				this.serialPort_0.ReadTimeout = 100;
				this.method_6("ATBRD11");
				string text2 = ((char)this.serialPort_0.ReadByte()).ToString() ?? "";
				while (!text2.Contains("OK\r") && !text2.Contains("?") && text2.Length < 20)
				{
					text2 += ((char)this.serialPort_0.ReadByte()).ToString();
				}
				this.serialPort_0.BaudRate = 230400;
				this.serialPort_0.ReadTimeout = 100;
				text2 = (((char)this.serialPort_0.ReadByte()).ToString() ?? "");
				while (!text2.Contains("\r") && text2.Length < 20)
				{
					text2 += ((char)this.serialPort_0.ReadByte()).ToString();
				}
				this.method_7("", false);
			}
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 1000;
			}
			bool flag = true;
			bool flag2 = true;
			bool flag3 = false;
			if (this.method_7("ATI", true).Contains("OBDKey"))
			{
				flag3 = true;
			}
			if (!this.method_7("ATE0", true).Contains("OK"))
			{
				flag = false;
			}
			if (!this.method_7("ATL0", true).Contains("OK"))
			{
				flag = false;
			}
			if (!this.method_7("ATH0", true).Contains("OK"))
			{
				flag = false;
			}
			if (!this.method_7("ATSPC", true).Contains("OK"))
			{
				flag = false;
			}
			if (!this.method_7("ATS0", true).Contains("OK"))
			{
				flag = false;
			}
			if (!this.method_7("ATCAF0", true).Contains("OK"))
			{
				flag = false;
			}
			if (!this.method_7("ATCFC0", true).Contains("OK"))
			{
				flag = false;
			}
			if (!this.method_7("ATCRA 7B0", true).Contains("OK"))
			{
				flag = false;
			}
			if (!this.method_7("ATSH 7B0", true).Contains("OK"))
			{
				flag = false;
			}
			if (!this.method_7("ATAT1", true).Contains("OK"))
			{
				flag = false;
			}
			if (!this.method_7("ATST41", true).Contains("OK"))
			{
				flag = false;
			}
			if (!this.method_7("ATBI", true).Contains("OK"))
			{
				flag = false;
			}
			if (!this.method_7("ATSP4", false).Contains("OK"))
			{
				flag2 = false;
			}
			if (!this.method_7("ATIB48", false).Contains("OK"))
			{
				flag2 = false;
			}
			try
			{
				if (this.serialPort_0 != null)
				{
					this.serialPort_0.ReadTimeout = 100;
				}
				this.method_7("ATZ", false);
			}
			catch (Exception)
			{
			}
			if (flag3)
			{
				this.string_0 = (this.string_0 ?? "");
			}
			else if (flag && flag2)
			{
				this.string_0 = this.string_0 + GClass121.smethod_6("1202") + Environment.NewLine;
			}
			else if (flag)
			{
				this.string_0 = this.string_0 + GClass121.smethod_6("1201") + Environment.NewLine;
			}
			else
			{
				this.string_0 = this.string_0 + GClass121.smethod_6("1200") + Environment.NewLine;
			}
			this.bool_0 = false;
		}
		catch (Exception ex)
		{
			try
			{
				this.string_0 = this.string_0 + ex.Message + Environment.NewLine;
				this.bool_0 = false;
			}
			catch (Exception)
			{
			}
		}
		finally
		{
			if (this.tcpClient_0 != null && this.tcpClient_0.Connected)
			{
				try
				{
					this.tcpClient_0.Close();
				}
				catch (Exception ex2)
				{
					GClass126.smethod_2("ERROR: Failed to close TCP connection: " + ex2.Message, 1);
				}
			}
			if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
			{
				try
				{
					this.serialPort_0.Close();
					GClass126.smethod_2("Serial port closed!", 1);
				}
				catch (Exception ex3)
				{
					GClass126.smethod_2("ERROR: Failed to close serial port: " + ex3.Message, 1);
				}
			}
			if (this.bluetoothLEDevice_0 != null)
			{
				if (this.gattDeviceService_0 != null)
				{
					try
					{
						this.gattDeviceService_0.Session.Dispose();
						this.gattDeviceService_0.Dispose();
						GClass126.smethod_2("BLE gatt service closed!", 0);
					}
					catch (Exception ex4)
					{
						GClass126.smethod_2("ERROR: Failed to close BLE service: " + ex4.Message, 1);
					}
				}
				try
				{
					this.bluetoothLEDevice_0.Dispose();
					GClass126.smethod_2("BLE device closed!", 0);
				}
				catch (Exception ex5)
				{
					GClass126.smethod_2("ERROR: Failed to close BLE connection: " + ex5.Message, 1);
				}
			}
		}
	}

	// Token: 0x060005F6 RID: 1526 RVA: 0x000D8CE4 File Offset: 0x000D6EE4
	private void method_1()
	{
		try
		{
			if (this.int_1 == 13)
			{
				this.tcpClient_0 = new TcpClient();
				int num = this.string_1.IndexOf(':');
				if (num < 10 || num > 18)
				{
					throw new Exception("Invalid IP address!");
				}
				if (!this.tcpClient_0.BeginConnect(this.string_1.Substring(2, num - 2), GClass127.smethod_37(this.string_1.Substring(num + 1)), null, null).AsyncWaitHandle.WaitOne(2000) || !this.tcpClient_0.Connected)
				{
					throw new Exception("WiFi device not connected!");
				}
				GClass126.smethod_2("WiFi device connect successfull!", 0);
				for (int i = 0; i < 5; i++)
				{
					Thread.Sleep(100);
				}
			}
			else if (this.string_1.StartsWith("BLE"))
			{
				GForm15.Class14 @class = new GForm15.Class14();
				GClass126.smethod_2("Searching for BLE devices ...", 0);
				@class.foundBLEDeviceID = "";
				TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs> handler = new TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>(@class.method_0);
				BluetoothLEAdvertisementWatcher bluetoothLEAdvertisementWatcher = new BluetoothLEAdvertisementWatcher();
				bluetoothLEAdvertisementWatcher.put_ScanningMode(1);
				BluetoothLEAdvertisementWatcher bluetoothLEAdvertisementWatcher2 = bluetoothLEAdvertisementWatcher;
				BluetoothLEAdvertisementWatcher @object = bluetoothLEAdvertisementWatcher2;
				WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>>(new Func<TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>, EventRegistrationToken>(@object.add_Received), new Action<EventRegistrationToken>(@object.remove_Received), handler);
				bluetoothLEAdvertisementWatcher2.Start();
				long num2 = (long)(GClass126.smethod_1() + 10000);
				while (@class.foundBLEDeviceID == "" && num2 > (long)GClass126.smethod_1())
				{
					Thread.Sleep(50);
				}
				bluetoothLEAdvertisementWatcher2.Stop();
				if (@class.foundBLEDeviceID == "")
				{
					throw new Exception("Bluetooth LE device not found!");
				}
				GClass126.smethod_2("BLE: Connect1", 0);
				this.bluetoothLEDevice_0 = WindowsRuntimeSystemExtensions.AsTask<BluetoothLEDevice>(BluetoothLEDevice.FromBluetoothAddressAsync(ulong.Parse(@class.foundBLEDeviceID, NumberStyles.HexNumber))).GetAwaiter().GetResult();
				GClass126.smethod_2("BLE: Connect2", 0);
				GattDeviceServicesResult result = WindowsRuntimeSystemExtensions.AsTask<GattDeviceServicesResult>(this.bluetoothLEDevice_0.GetGattServicesForUuidAsync(Guid.Parse(GClass125.string_5), 1)).GetAwaiter().GetResult();
				if (result.Status == null)
				{
					GClass126.smethod_2("BLE: Connect gatt service", 0);
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
						GClass126.smethod_2("BLE: Characteristics found", 0);
					}
					else
					{
						GClass126.smethod_2("BLE: Characteristic ERROR", 0);
					}
					WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(this.gattCharacteristic_0.WriteClientCharacteristicConfigurationDescriptorWithResultAsync(1)).GetAwaiter();
					GattCharacteristic object2 = this.gattCharacteristic_0;
					WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>>(new Func<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>, EventRegistrationToken>(object2.add_ValueChanged), new Action<EventRegistrationToken>(object2.remove_ValueChanged), new TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>(this.method_16));
					for (int j = 0; j < 5; j++)
					{
						if (GClass126.bool_25)
						{
							throw new Exception("ESC");
						}
						Thread.Sleep(100);
					}
				}
				if (this.bluetoothLEDevice_0 == null || this.gattDeviceService_0 == null || this.gattCharacteristic_1 == null)
				{
					throw new Exception("Bluetooth LE device not connected!");
				}
			}
			else
			{
				this.serialPort_0 = new SerialPort(this.string_1, this.int_0, Parity.None, 8, StopBits.One);
				this.serialPort_0.WriteBufferSize = 2;
				this.serialPort_0.WriteTimeout = 1000;
				this.serialPort_0.ReceivedBytesThreshold = 1000;
				this.serialPort_0.Handshake = Handshake.None;
				this.serialPort_0.NewLine = "\r";
				this.serialPort_0.Open();
				this.serialPort_0.ReadTimeout = 1000;
			}
			this.method_7("ATZ", false);
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 1000;
			}
			this.method_6("!tieCAR_SC_T");
			string text = this.method_9();
			if (!text.Contains("ERROR"))
			{
				this.string_0 = this.string_0 + Environment.NewLine + Environment.NewLine + "OK! NO ERRORS FOUND!";
			}
			else
			{
				this.string_0 = this.string_0 + Environment.NewLine + Environment.NewLine + "ERRORS FOUND!";
				if (text.Contains("UI:9.") || text.Contains("UI:10.") || text.Contains("UI:11.") || text.Contains("UI:12.") || text.Contains("UI:13.") || text.Contains("UI:15.") || text.Contains("UI:16.") || text.Contains("UI:17.") || text.Contains("UI:8."))
				{
					this.string_0 = this.string_0 + Environment.NewLine + "PLEASE DISCONNECT INTERFACE FROM CAR! THE TEST IS NOT VALID WHEN CANTIECAR IS CONNECTED TO A CAR!" + Environment.NewLine;
				}
			}
			this.bool_0 = false;
		}
		catch (Exception ex)
		{
			try
			{
				this.string_0 = this.string_0 + ex.Message + Environment.NewLine;
				this.bool_0 = false;
			}
			catch (Exception)
			{
			}
		}
		finally
		{
			if (this.tcpClient_0 != null && this.tcpClient_0.Connected)
			{
				try
				{
					this.tcpClient_0.Close();
				}
				catch (Exception ex2)
				{
					GClass126.smethod_2("ERROR: Failed to close TCP connection: " + ex2.Message, 1);
				}
			}
			if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
			{
				try
				{
					this.serialPort_0.Close();
					GClass126.smethod_2("Serial port closed!", 1);
				}
				catch (Exception ex3)
				{
					GClass126.smethod_2("ERROR: Failed to close serial port: " + ex3.Message, 1);
				}
			}
			if (this.bluetoothLEDevice_0 != null)
			{
				if (this.gattDeviceService_0 != null)
				{
					try
					{
						this.gattDeviceService_0.Session.Dispose();
						this.gattDeviceService_0.Dispose();
						GClass126.smethod_2("BLE gatt service closed!", 0);
					}
					catch (Exception ex4)
					{
						GClass126.smethod_2("ERROR: Failed to close BLE service: " + ex4.Message, 1);
					}
				}
				try
				{
					this.bluetoothLEDevice_0.Dispose();
					GClass126.smethod_2("BLE device closed!", 0);
				}
				catch (Exception ex5)
				{
					GClass126.smethod_2("ERROR: Failed to close BLE connection: " + ex5.Message, 1);
				}
			}
		}
	}

	// Token: 0x060005F7 RID: 1527 RVA: 0x000D9428 File Offset: 0x000D7628
	private void method_2()
	{
		try
		{
			this.serialPort_0 = new SerialPort(this.string_1, this.int_0, Parity.None, 8, StopBits.One);
			this.serialPort_0.WriteBufferSize = 2;
			this.serialPort_0.WriteTimeout = 2000;
			this.serialPort_0.ReceivedBytesThreshold = 1000;
			this.serialPort_0.Handshake = Handshake.None;
			this.serialPort_0.Open();
			this.serialPort_0.ReadTimeout = 100;
			this.string_0 = this.string_0 + "VagCom/KKL" + Environment.NewLine;
			this.string_0 += Environment.NewLine;
			this.string_0 = this.string_0 + "Testing latency with 200 bytes of data..." + Environment.NewLine;
			this.bool_0 = false;
			this.method_5(170);
			this.method_5(170);
			int num = 1000;
			int num2 = 0;
			for (int i = 0; i < 200; i++)
			{
				int num3 = GClass126.smethod_1();
				this.method_5(170);
				int num4 = GClass126.smethod_1() - num3;
				if (num4 < num)
				{
					num = num4;
				}
				if (num4 > num2)
				{
					num2 = num4;
				}
			}
			this.string_0 = this.string_0 + "Min latency: " + num.ToString() + Environment.NewLine;
			this.string_0 = this.string_0 + "Max latency: " + num2.ToString() + Environment.NewLine;
			this.string_0 += Environment.NewLine;
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
			this.string_0 = this.string_0 + "Testing timers..." + Environment.NewLine;
			this.string_0 = this.string_0 + "(The acceptable tolerance for results is ~5 ms)" + Environment.NewLine;
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
			if (Stopwatch.IsHighResolution)
			{
				this.string_0 = this.string_0 + "System supports high resolution timer." + Environment.NewLine;
			}
			else
			{
				this.string_0 = this.string_0 + "System DOES NOT support high resolution timer!!! This system may not work properly with VagCom/KKL interface!!!" + Environment.NewLine;
			}
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
			this.string_0 = this.string_0 + "Testing timer with 1000 ms..." + Environment.NewLine;
			this.bool_0 = false;
			Thread.Sleep(50);
			int num5 = GClass126.smethod_1();
			Thread.Sleep(1000);
			int num6 = GClass126.smethod_1() - num5;
			this.string_0 = string.Concat(new string[]
			{
				this.string_0,
				"..result: ",
				num6.ToString(),
				" ms",
				Environment.NewLine
			});
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
			this.serialPort_0.Close();
			this.string_0 = this.string_0 + "Testing timer with 250 ms..." + Environment.NewLine;
			this.bool_0 = false;
			this.serialPort_0 = new SerialPort(this.string_1, 1200, Parity.None, 8, StopBits.One);
			this.serialPort_0.WriteBufferSize = 2;
			this.serialPort_0.WriteTimeout = 2000;
			this.serialPort_0.ReceivedBytesThreshold = 1000;
			this.serialPort_0.Handshake = Handshake.None;
			this.serialPort_0.Open();
			this.serialPort_0.ReadTimeout = 250;
			num5 = GClass126.smethod_1();
			this.serialPort_0.Write("123456789012345678901234567890");
			for (int j = 0; j < 30; j++)
			{
				this.serialPort_0.ReadByte();
			}
			num6 = GClass126.smethod_1() - num5 - 2;
			this.string_0 = string.Concat(new string[]
			{
				this.string_0,
				"..result: ",
				num6.ToString(),
				" ms",
				Environment.NewLine
			});
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
			this.string_0 = this.string_0 + "Testing timer with 750 ms..." + Environment.NewLine;
			this.bool_0 = false;
			num5 = GClass126.smethod_1();
			this.serialPort_0.Write("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
			for (int k = 0; k < 90; k++)
			{
				this.serialPort_0.ReadByte();
			}
			num6 = GClass126.smethod_1() - num5 - 2;
			this.string_0 = string.Concat(new string[]
			{
				this.string_0,
				"..result: ",
				num6.ToString(),
				" ms",
				Environment.NewLine
			});
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
			this.string_0 = this.string_0 + "Testing timer with 100 ms..." + Environment.NewLine;
			this.bool_0 = false;
			num5 = GClass126.smethod_1();
			this.serialPort_0.Write("1234567890123456789012");
			for (int l = 0; l < 12; l++)
			{
				this.serialPort_0.ReadByte();
			}
			num6 = GClass126.smethod_1() - num5 - 2;
			this.string_0 = string.Concat(new string[]
			{
				this.string_0,
				"..result: ",
				num6.ToString(),
				" ms",
				Environment.NewLine
			});
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
		}
		catch (Exception ex)
		{
			this.string_0 = this.string_0 + ex.Message + Environment.NewLine;
			this.bool_0 = false;
		}
		finally
		{
			try
			{
				this.serialPort_0.Close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x060005F8 RID: 1528 RVA: 0x000D9A3C File Offset: 0x000D7C3C
	private void method_3(string string_2)
	{
		GClass126.smethod_2("Send: " + string_2, 0);
		byte[] bytes = Encoding.ASCII.GetBytes(string_2 + "\r");
		byte[] array = new byte[1];
		for (int i = 0; i < bytes.Length; i++)
		{
			array[0] = bytes[i];
			this.tcpClient_0.Client.Send(array);
		}
	}

	// Token: 0x060005F9 RID: 1529 RVA: 0x000D9AA0 File Offset: 0x000D7CA0
	private void method_4(string string_2)
	{
		GClass126.smethod_2("Send (BLE): " + string_2, 0);
		byte[] bytes = Encoding.ASCII.GetBytes(string_2 + "\r");
		if (this.stringBuilder_0.Length > 0)
		{
			GClass126.smethod_2("CLEAR PREVIOUS RESPONSES: " + this.stringBuilder_0.ToString() + "\r-------------", 0);
		}
		this.stringBuilder_0.Clear();
		WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(this.gattCharacteristic_1.WriteValueWithResultAsync(WindowsRuntimeBufferExtensions.AsBuffer(bytes))).GetAwaiter().GetResult();
	}

	// Token: 0x060005FA RID: 1530 RVA: 0x000D9B34 File Offset: 0x000D7D34
	private void method_5(byte byte_0)
	{
		this.serialPort_0.Write(new byte[]
		{
			byte_0
		}, 0, 1);
		byte b = (byte)this.serialPort_0.ReadByte();
		if (byte_0 != b)
		{
			this.string_0 = this.string_0 + "DATA ERROR!!!" + Environment.NewLine;
			this.bool_0 = false;
		}
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x000D9B8C File Offset: 0x000D7D8C
	private void method_6(string string_2)
	{
		if (this.int_1 != 9 && this.int_1 != 10 && this.int_1 != 12)
		{
			if (this.int_1 != 13)
			{
				if (this.string_1.StartsWith("BLE"))
				{
					this.method_4(string_2);
					return;
				}
				for (int i = 0; i < string_2.Length; i++)
				{
					this.serialPort_0.Write(string_2.Substring(i, 1));
				}
				this.serialPort_0.Write(this.serialPort_0.NewLine);
				return;
			}
		}
		this.method_3(string_2);
	}

	// Token: 0x060005FC RID: 1532 RVA: 0x000D9C20 File Offset: 0x000D7E20
	private string method_7(string string_2, bool bool_1)
	{
		this.method_6(string_2);
		if (bool_1)
		{
			this.string_0 = this.string_0 + "COMMAND: " + string_2 + Environment.NewLine;
		}
		this.bool_0 = false;
		string text = this.method_8();
		if (bool_1)
		{
			this.string_0 = string.Concat(new string[]
			{
				this.string_0,
				"RESPONSE: ",
				text,
				Environment.NewLine,
				Environment.NewLine
			});
		}
		this.bool_0 = false;
		return text;
	}

	// Token: 0x060005FD RID: 1533 RVA: 0x000D9CA4 File Offset: 0x000D7EA4
	private string method_8()
	{
		if (this.int_1 != 9 && this.int_1 != 10 && this.int_1 != 12)
		{
			if (this.int_1 != 13)
			{
				if (this.string_1.StartsWith("BLE"))
				{
					return this.method_12();
				}
				string text = "";
				byte b = 32;
				while (b != 62 && b != 0 && text.Length < 1500)
				{
					b = (byte)this.serialPort_0.ReadByte();
					if (b != 0)
					{
						string str = text;
						char c = (char)b;
						text = str + c.ToString();
					}
				}
				return text;
			}
		}
		return this.method_11();
	}

	// Token: 0x060005FE RID: 1534 RVA: 0x000D9D40 File Offset: 0x000D7F40
	private string method_9()
	{
		if (this.int_1 != 9 && this.int_1 != 10 && this.int_1 != 12)
		{
			if (this.int_1 != 13)
			{
				if (this.string_1.StartsWith("BLE"))
				{
					return this.method_13();
				}
				string text = "";
				string text2 = "";
				while (!text.EndsWith("\r>") && text.Length < 8000)
				{
					try
					{
						text2 += ((char)this.serialPort_0.ReadByte()).ToString();
					}
					catch (Exception)
					{
						break;
					}
					if (text2.EndsWith("\r"))
					{
						text += text2;
						this.string_0 += text2.Replace("!tieCAR_SC_T", "");
						text2 = "";
						this.bool_0 = false;
					}
				}
				return text;
			}
		}
		return this.method_10();
	}

	// Token: 0x060005FF RID: 1535 RVA: 0x000D9E40 File Offset: 0x000D8040
	private string method_10()
	{
		string text = "";
		string text2 = "";
		long num = (long)(GClass126.smethod_1() + 2500);
		while (!text.EndsWith("\r>") && text.Length < 8000 && num > (long)GClass126.smethod_1())
		{
			if (this.tcpClient_0.Client.Available > 0)
			{
				int num2 = this.tcpClient_0.GetStream().ReadByte();
				if (num2 != -1)
				{
					text2 += ((char)num2).ToString();
				}
				num = (long)(GClass126.smethod_1() + 2000);
			}
			else
			{
				Thread.Sleep(5);
			}
			if (text2.EndsWith("\r"))
			{
				text += text2;
				this.string_0 += text2.Replace("!tieCAR_SC_T", "");
				text2 = "";
				this.bool_0 = false;
			}
		}
		GClass126.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x06000600 RID: 1536 RVA: 0x000D9F40 File Offset: 0x000D8140
	private string method_11()
	{
		string text = "";
		long num = (long)(GClass126.smethod_1() + 2500);
		while (!text.EndsWith(">") && num > (long)GClass126.smethod_1())
		{
			if (this.tcpClient_0.Client.Available > 0)
			{
				int num2 = this.tcpClient_0.GetStream().ReadByte();
				if (num2 != -1)
				{
					text += ((char)num2).ToString();
				}
				num = (long)(GClass126.smethod_1() + 2000);
			}
			else
			{
				Thread.Sleep(5);
			}
		}
		GClass126.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x06000601 RID: 1537 RVA: 0x000D9FDC File Offset: 0x000D81DC
	private string method_12()
	{
		string text = "";
		if (this.gattDeviceService_0 == null)
		{
			throw new Exception("Peripheral disconnected!");
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
		GClass126.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x06000602 RID: 1538 RVA: 0x000DA094 File Offset: 0x000D8294
	private string method_13()
	{
		string text = "";
		string text2 = "";
		if (this.gattDeviceService_0 == null)
		{
			throw new Exception("Peripheral disconnected!");
		}
		long num = (long)(GClass126.smethod_1() + 3500);
		while (!text.EndsWith("\r>") && num > (long)GClass126.smethod_1() && text.Length < 8000)
		{
			if (this.stringBuilder_0.Length > 0)
			{
				text2 += this.stringBuilder_0[0].ToString();
				this.stringBuilder_0.Remove(0, 1);
				num = (long)(GClass126.smethod_1() + 2500);
			}
			else
			{
				Thread.Sleep(5);
			}
			if (text2.EndsWith("\r"))
			{
				text += text2;
				this.string_0 += text2.Replace("!tieCAR_SC_T", "");
				text2 = "";
				this.bool_0 = false;
			}
		}
		GClass126.smethod_2("Response: " + text, 0);
		return text;
	}

	// Token: 0x06000603 RID: 1539 RVA: 0x000DA1A0 File Offset: 0x000D83A0
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!this.bool_0)
		{
			this.bool_0 = true;
			this.textBox_0.Text = this.string_0;
			this.textBox_0.SelectionStart = this.textBox_0.Text.Length;
			this.textBox_0.ScrollToCaret();
		}
	}

	// Token: 0x06000604 RID: 1540 RVA: 0x00002F0A File Offset: 0x0000110A
	private void button_0_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x06000606 RID: 1542 RVA: 0x000DA1F4 File Offset: 0x000D83F4
	private void method_14()
	{
		this.icontainer_0 = new Container();
		this.textBox_0 = new TextBox();
		this.button_0 = new Button();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		base.SuspendLayout();
		this.textBox_0.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_0.Location = new System.Drawing.Point(14, 15);
		this.textBox_0.Margin = new Padding(3, 4, 3, 4);
		this.textBox_0.Multiline = true;
		this.textBox_0.Name = GClass107.smethod_3(148824);
		this.textBox_0.ScrollBars = ScrollBars.Vertical;
		this.textBox_0.Size = new System.Drawing.Size(692, 471);
		this.textBox_0.TabIndex = 0;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new System.Drawing.Point(602, 508);
		this.button_0.Margin = new Padding(3, 4, 3, 4);
		this.button_0.Name = GClass107.smethod_3(148834);
		this.button_0.Size = new System.Drawing.Size(104, 34);
		this.button_0.TabIndex = 2;
		this.button_0.Tag = "8199";
		this.button_0.Text = "OK";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.timer_0.Enabled = true;
		this.timer_0.Interval = 200;
		this.timer_0.Tick += this.timer_0_Tick;
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.AutoSize = true;
		base.ClientSize = new System.Drawing.Size(718, 555);
		base.ControlBox = false;
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.textBox_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Margin = new Padding(3, 4, 3, 4);
		base.Name = GClass107.smethod_3(148842);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = GClass107.smethod_3(148850);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x06000607 RID: 1543 RVA: 0x00004449 File Offset: 0x00002649
	[CompilerGenerated]
	private void method_15(GattCharacteristic gattCharacteristic_2, GattValueChangedEventArgs gattValueChangedEventArgs_0)
	{
		this.stringBuilder_0.Append(Encoding.ASCII.GetString(WindowsRuntimeBufferExtensions.ToArray(gattValueChangedEventArgs_0.CharacteristicValue)));
	}

	// Token: 0x06000608 RID: 1544 RVA: 0x00004449 File Offset: 0x00002649
	[CompilerGenerated]
	private void method_16(GattCharacteristic gattCharacteristic_2, GattValueChangedEventArgs gattValueChangedEventArgs_0)
	{
		this.stringBuilder_0.Append(Encoding.ASCII.GetString(WindowsRuntimeBufferExtensions.ToArray(gattValueChangedEventArgs_0.CharacteristicValue)));
	}

	// Token: 0x04000530 RID: 1328
	private SerialPort serialPort_0;

	// Token: 0x04000531 RID: 1329
	private string string_0 = "";

	// Token: 0x04000532 RID: 1330
	private bool bool_0;

	// Token: 0x04000533 RID: 1331
	private string string_1 = "COM1";

	// Token: 0x04000534 RID: 1332
	private int int_0 = 9600;

	// Token: 0x04000535 RID: 1333
	private int int_1 = 2;

	// Token: 0x04000536 RID: 1334
	protected TcpClient tcpClient_0;

	// Token: 0x04000537 RID: 1335
	protected BluetoothLEDevice bluetoothLEDevice_0;

	// Token: 0x04000538 RID: 1336
	protected GattDeviceService gattDeviceService_0;

	// Token: 0x04000539 RID: 1337
	protected GattCharacteristic gattCharacteristic_0;

	// Token: 0x0400053A RID: 1338
	protected GattCharacteristic gattCharacteristic_1;

	// Token: 0x0400053B RID: 1339
	protected StringBuilder stringBuilder_0 = new StringBuilder(1000);

	// Token: 0x0400053D RID: 1341
	private TextBox textBox_0;

	// Token: 0x0400053E RID: 1342
	private Button button_0;

	// Token: 0x0400053F RID: 1343
	private System.Windows.Forms.Timer timer_0;

	// Token: 0x020000B7 RID: 183
	[CompilerGenerated]
	private sealed class Class13
	{
		// Token: 0x0600060A RID: 1546 RVA: 0x000DA458 File Offset: 0x000D8658
		internal void method_0(BluetoothLEAdvertisementWatcher s, BluetoothLEAdvertisementReceivedEventArgs e)
		{
			GClass126.smethod_2("BLE: " + e.Advertisement.LocalName, 0);
			if (e.Advertisement.LocalName.StartsWith("IOS-Vlink") || e.Advertisement.LocalName.StartsWith("vLinker"))
			{
				this.foundBLEDeviceID = e.BluetoothAddress.ToString("x").ToUpper();
			}
		}

		// Token: 0x04000540 RID: 1344
		public string foundBLEDeviceID;
	}

	// Token: 0x020000B8 RID: 184
	[CompilerGenerated]
	private sealed class Class14
	{
		// Token: 0x0600060C RID: 1548 RVA: 0x000DA4CC File Offset: 0x000D86CC
		internal void method_0(BluetoothLEAdvertisementWatcher s, BluetoothLEAdvertisementReceivedEventArgs e)
		{
			GClass126.smethod_2("BLE: " + e.Advertisement.LocalName, 0);
			if (e.Advertisement.LocalName.StartsWith("CANtieCAR"))
			{
				this.foundBLEDeviceID = e.BluetoothAddress.ToString("x").ToUpper();
			}
		}

		// Token: 0x04000541 RID: 1345
		public string foundBLEDeviceID;
	}
}
