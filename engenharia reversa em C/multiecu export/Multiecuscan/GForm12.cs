using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Foundation;

// Token: 0x020000AF RID: 175
public partial class GForm12 : Form
{
	// Token: 0x060005B9 RID: 1465 RVA: 0x000CF2E8 File Offset: 0x000CD4E8
	private void GForm12_Shown(object sender, EventArgs e)
	{
		string text = GClass126.string_12;
		byte[] array = GClass127.smethod_32(text);
		this.method_0();
		for (int i = 0; i < array.Length; i++)
		{
			byte[] array2 = array;
			int num = i;
			array2[num] ^= 49;
			text += GClass127.smethod_23(array[i]);
			if (i == 5 || i == 9 || i == 14)
			{
				text += "-";
			}
		}
		if (this.textBox_4.Visible)
		{
			this.textBox_1.Text = GClass125.smethod_13();
		}
		this.textBox_1.Text = text.Substring(array.Length * 2);
		if (GClass126.bool_10 && GClass126.bool_13)
		{
			this.textBox_3.Text = GClass126.string_0 + this.string_0[2];
			this.textBox_3.ForeColor = Color.Green;
			this.textBox_0.ReadOnly = true;
			this.textBox_0.Text = GClass125.smethod_5();
			this.button_0.Enabled = false;
			if (GClass125.string_31.Length > 4)
			{
				this.textBox_1.Text = GClass125.string_31;
				this.label_0.Text = GClass107.smethod_3(137231);
			}
		}
		else if (GClass126.bool_13)
		{
			this.textBox_3.Text = GClass126.string_0 + this.string_0[0];
			this.textBox_3.ForeColor = Color.Green;
			this.textBox_0.ReadOnly = true;
			this.textBox_0.Text = GClass125.smethod_5();
			this.button_0.Enabled = false;
		}
		this.string_4 = text.Substring(array.Length * 2);
		this.bool_1 = true;
		new Thread(new ThreadStart(this.method_1)).Start();
	}

	// Token: 0x060005BA RID: 1466 RVA: 0x000CF4AC File Offset: 0x000CD6AC
	private void button_0_Click(object sender, EventArgs e)
	{
		GClass127.smethod_46().Replace("5", "-");
		string text = GClass127.smethod_21(GClass126.string_12, this.textBox_0.Text.ToUpper());
		string text2 = this.textBox_4.Text.ToUpper();
		string text3 = this.textBox_5.Text.ToUpper();
		if (!this.textBox_4.Visible || !text2.StartsWith("MP-"))
		{
			text2 = "";
			text3 = "";
		}
		if (!this.textBox_5.Visible || !text3.StartsWith("MP-"))
		{
			text3 = "";
		}
		string text4 = this.textBox_0.Text.ToUpper().Trim();
		if (text4.StartsWith("MP-"))
		{
			if (!this.bool_0)
			{
				GForm3 gform = new GForm3();
				gform.ShowDialog();
				if (!gform.bool_1)
				{
					MessageBox.Show(GClass107.smethod_3(137148), GClass107.smethod_3(137161), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					base.DialogResult = DialogResult.None;
					return;
				}
			}
			GClass125.smethod_39(0, 16);
			GClass125.smethod_39(1, 13);
			GClass125.smethod_39(2, 0);
			GClass125.smethod_39(3, 0);
			GClass125.smethod_64(0);
		}
		string text5 = GClass127.smethod_57("", text);
		if (text5.StartsWith(text))
		{
			GClass125.smethod_6(this.textBox_0.Text.ToUpper());
			GClass125.smethod_8(text2);
			GClass125.smethod_10(text3);
			GClass125.smethod_12("");
			GClass125.smethod_14("-");
			GClass125.smethod_23(GClass125.smethod_20());
			base.DialogResult = DialogResult.OK;
		}
		else if (!GClass126.bool_17 && !GClass126.bool_13)
		{
			text4 = this.string_4 + text4.Replace("5", "");
			text4 = text4.Replace("-", "");
			List<string> list = new List<string>();
			for (int i = 0; i < list.Count; i++)
			{
				if (text4 == list[i])
				{
					text5 = text;
					GClass125.smethod_6(this.textBox_0.Text.ToUpper());
					break;
				}
			}
		}
		if (text5 != text)
		{
			MessageBox.Show(GClass107.smethod_3(137188), GClass107.smethod_3(137198), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			base.DialogResult = DialogResult.None;
			return;
		}
		GClass125.smethod_45(0);
		GClass125.smethod_14("-");
		GClass125.smethod_12("");
		base.DialogResult = DialogResult.OK;
	}

	// Token: 0x060005BB RID: 1467 RVA: 0x000CF710 File Offset: 0x000CD910
	private void method_0()
	{
		string text = "";
		string text2 = "";
		this.label_3.Visible = false;
		this.textBox_4.Text = GClass125.smethod_11();
		this.textBox_4.Visible = (GClass125.smethod_11().Length > 0);
		if (GClass126.bool_10 && GClass126.bool_13)
		{
			this.textBox_3.Text = GClass126.string_0 + this.string_0[2];
			this.textBox_3.ForeColor = Color.Navy;
			this.textBox_0.ReadOnly = true;
			text2 = GClass125.smethod_9();
			text = GClass125.smethod_7();
			this.textBox_0.Text = GClass125.smethod_5();
			this.button_0.Enabled = false;
			if (!text.StartsWith("MP-"))
			{
				text = "";
				text2 = "";
			}
			if (!text2.StartsWith("MP-"))
			{
				text2 = "";
			}
			this.button_3.Visible = false;
			if (GClass125.string_31.Length > 4)
			{
				this.textBox_1.Text = GClass125.string_31;
				this.label_0.Text = GClass107.smethod_3(136859);
			}
		}
		else if (GClass126.bool_13)
		{
			this.textBox_1.Text = this.string_4;
			this.label_0.Text = GClass107.smethod_3(136898);
			this.textBox_3.Text = GClass126.string_0 + this.string_0[0];
			this.textBox_3.ForeColor = Color.Green;
			this.textBox_0.ReadOnly = true;
			this.textBox_0.Text = GClass125.smethod_5();
			this.button_0.Enabled = false;
			this.button_3.Visible = false;
		}
		else
		{
			this.textBox_1.Text = this.string_4;
			this.label_0.Text = GClass107.smethod_3(136937);
			this.textBox_3.Text = GClass126.string_0 + this.string_0[1];
			this.textBox_3.ForeColor = Color.Red;
			this.textBox_0.ReadOnly = false;
			this.textBox_0.Text = "";
			this.button_0.Enabled = true;
			this.button_3.Visible = true;
		}
		this.button_2.Enabled = !this.button_0.Enabled;
		if (this.button_2.Enabled && GClass126.bool_10)
		{
			this.textBox_2.Text = GClass107.smethod_3(136946);
		}
		else if (this.button_2.Enabled)
		{
			this.textBox_2.Text = GClass107.smethod_3(136952);
		}
		if (!this.button_2.Enabled && this.textBox_4.Visible)
		{
			this.textBox_2.Text = GClass107.smethod_3(136979);
			this.label_3.Visible = true;
			this.textBox_0.Text = GClass125.smethod_5();
		}
		this.label_2.Visible = this.textBox_4.Visible;
		this.label_4.Visible = false;
		this.textBox_5.Visible = false;
		if (text2.StartsWith("MP-"))
		{
			this.textBox_5.Visible = true;
			this.label_4.Visible = this.textBox_5.Visible;
			this.textBox_5.Text = GClass125.smethod_9();
			this.textBox_5.ReadOnly = this.textBox_0.ReadOnly;
		}
		if (text.StartsWith("MP-"))
		{
			this.textBox_4.Visible = true;
			this.label_2.Visible = this.textBox_4.Visible;
			this.label_2.Text = this.label_4.Text.Replace("3", "2");
			this.textBox_4.Text = GClass125.smethod_7();
			this.textBox_4.ReadOnly = this.textBox_0.ReadOnly;
		}
	}

	// Token: 0x060005BC RID: 1468 RVA: 0x000042C1 File Offset: 0x000024C1
	private void button_3_Click(object sender, EventArgs e)
	{
		GClass127.smethod_39();
		Process.Start(GClass107.smethod_3(137404) + GClass125.smethod_91() + GClass107.smethod_3(137453) + this.textBox_1.Text);
	}

	// Token: 0x060005BD RID: 1469 RVA: 0x000CFB10 File Offset: 0x000CDD10
	private void button_2_Click(object sender, EventArgs e)
	{
		string text = this.string_1;
		if (GClass126.bool_10 && GClass126.bool_13)
		{
			text = this.string_2;
		}
		if (MessageBox.Show(text, GClass107.smethod_3(137249), MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
		{
			if (!GClass126.bool_10)
			{
				GClass125.smethod_12(GClass127.smethod_19(GClass126.string_12));
				GClass125.smethod_14(this.textBox_1.Text);
				this.textBox_4.Text = GClass125.smethod_11();
			}
			else
			{
				GClass125.smethod_6("");
				this.textBox_5.Text = "";
				this.textBox_4.Text = "";
				this.textBox_5.Visible = false;
				this.textBox_4.Visible = false;
				this.label_4.Visible = this.textBox_5.Visible;
				this.label_2.Visible = this.textBox_4.Visible;
			}
			GClass126.bool_13 = false;
			this.method_0();
		}
	}

	// Token: 0x060005BE RID: 1470 RVA: 0x000CFC04 File Offset: 0x000CDE04
	public GForm12()
	{
		this.method_3();
	}

	// Token: 0x060005BF RID: 1471 RVA: 0x000CFC8C File Offset: 0x000CDE8C
	private void label_3_MouseClick(object sender, MouseEventArgs e)
	{
		Process.Start(string.Concat(new string[]
		{
			GClass107.smethod_3(137294),
			this.textBox_1.Text,
			GClass107.smethod_3(137329),
			GClass125.smethod_5(),
			GClass107.smethod_3(137375),
			GClass125.smethod_11()
		}));
	}

	// Token: 0x060005C0 RID: 1472 RVA: 0x000042F7 File Offset: 0x000024F7
	private void GForm12_FormClosing(object sender, FormClosingEventArgs e)
	{
		this.bool_1 = false;
	}

	// Token: 0x060005C1 RID: 1473 RVA: 0x00002F0A File Offset: 0x0000110A
	private void button_1_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x060005C2 RID: 1474 RVA: 0x000CFCF0 File Offset: 0x000CDEF0
	private void textBox_0_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Y && e.Alt && e.Control && (this.textBox_0.Text == "" || this.textBox_0.Text.StartsWith("MP-")))
		{
			e.Handled = true;
			this.textBox_5.Visible = true;
			this.label_4.Visible = this.textBox_5.Visible;
			this.textBox_4.Visible = true;
			this.label_2.Visible = this.textBox_4.Visible;
			this.label_2.Text = this.label_4.Text.Replace("3", "2");
			this.textBox_4.Text = GClass125.smethod_7();
			this.textBox_5.Text = GClass125.smethod_9();
			this.textBox_4.ReadOnly = this.textBox_0.ReadOnly;
			this.textBox_5.ReadOnly = this.textBox_0.ReadOnly;
		}
	}

	// Token: 0x060005C3 RID: 1475 RVA: 0x000CFE10 File Offset: 0x000CE010
	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (this.textBox_0.Text.StartsWith("MP-") && !this.textBox_0.ReadOnly)
		{
			this.textBox_5.Visible = true;
			this.label_4.Visible = this.textBox_5.Visible;
			this.textBox_4.Visible = true;
			this.label_2.Visible = this.textBox_4.Visible;
			this.label_2.Text = this.label_4.Text.Replace("3", "2");
			this.textBox_4.Text = GClass107.smethod_3(137480);
			this.textBox_5.Text = GClass107.smethod_3(137491);
			this.textBox_4.ReadOnly = this.textBox_0.ReadOnly;
			this.textBox_5.ReadOnly = this.textBox_0.ReadOnly;
			this.toolTip_0.SetToolTip(this.textBox_0, this.string_3.Replace("\\r", Environment.NewLine));
			this.toolTip_0.SetToolTip(this.textBox_4, this.string_3.Replace("\\r", Environment.NewLine));
			this.toolTip_0.SetToolTip(this.textBox_5, this.string_3.Replace("\\r", Environment.NewLine));
			return;
		}
		this.toolTip_0.SetToolTip(this.textBox_0, null);
		this.toolTip_0.SetToolTip(this.textBox_4, null);
		this.toolTip_0.SetToolTip(this.textBox_5, null);
	}

	// Token: 0x060005C4 RID: 1476 RVA: 0x000CFFB0 File Offset: 0x000CE1B0
	private void method_1()
	{
		this.bool_0 = false;
		SerialPort serialPort = null;
		string text = "";
		while (!this.bool_0 && this.bool_1 && !GClass126.bool_10 && !GClass126.bool_13)
		{
			try
			{
				string text2 = GClass96.smethod_13();
				if (text2 != "")
				{
					serialPort = new SerialPort(text2, 115200, Parity.None, 8, StopBits.One);
					serialPort.WriteBufferSize = 2;
					serialPort.ReadTimeout = 1000;
					serialPort.WriteTimeout = 1000;
					serialPort.ReceivedBytesThreshold = 1000;
					serialPort.Handshake = Handshake.None;
					serialPort.NewLine = "\r";
					serialPort.Open();
					Thread.Sleep(200);
					string text3 = GClass107.smethod_3(137527);
					for (int i = 0; i < text3.Length; i++)
					{
						serialPort.Write(text3.Substring(i, 1));
					}
					serialPort.Write(serialPort.NewLine);
					string text4 = "";
					while (!text4.EndsWith(">"))
					{
						text4 += ((char)serialPort.ReadByte()).ToString();
					}
					if (text4.Contains(GClass107.smethod_3(137549)))
					{
						text = text4.Replace(">", "").Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("AT@4", "").Replace("CANtieCAR", "").Replace("_", "");
						this.bool_0 = true;
					}
				}
				goto IL_5A6;
			}
			catch (Exception)
			{
				goto IL_5A6;
			}
			finally
			{
				if (serialPort != null && serialPort.IsOpen)
				{
					try
					{
						serialPort.Close();
					}
					catch (Exception)
					{
					}
				}
			}
			goto IL_1BC;
			IL_573:
			for (int j = 0; j < 10; j++)
			{
				if (!this.bool_1 || this.bool_0)
				{
					break;
				}
				Thread.Sleep(100);
			}
			continue;
			IL_1BC:
			BluetoothLEDevice bluetoothLEDevice = null;
			GattDeviceService gattDeviceService = null;
			GattCharacteristic gattCharacteristic = null;
			GattCharacteristic gattCharacteristic2 = null;
			try
			{
				GForm12.Class11 @class = new GForm12.Class11();
				@class.foundBLEDeviceID = "";
				TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs> handler = new TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>(@class.method_0);
				BluetoothLEAdvertisementWatcher bluetoothLEAdvertisementWatcher = new BluetoothLEAdvertisementWatcher();
				bluetoothLEAdvertisementWatcher.put_ScanningMode(1);
				BluetoothLEAdvertisementWatcher bluetoothLEAdvertisementWatcher2 = bluetoothLEAdvertisementWatcher;
				BluetoothLEAdvertisementWatcher @object = bluetoothLEAdvertisementWatcher2;
				WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>>(new Func<TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>, EventRegistrationToken>(@object.add_Received), new Action<EventRegistrationToken>(@object.remove_Received), handler);
				bluetoothLEAdvertisementWatcher2.Start();
				long num = (long)(GClass126.smethod_1() + 8000);
				while (this.bool_1 && @class.foundBLEDeviceID == "" && num > (long)GClass126.smethod_1())
				{
					Thread.Sleep(50);
				}
				bluetoothLEAdvertisementWatcher2.Stop();
				if (@class.foundBLEDeviceID != "" && this.bool_1)
				{
					bluetoothLEDevice = WindowsRuntimeSystemExtensions.AsTask<BluetoothLEDevice>(BluetoothLEDevice.FromBluetoothAddressAsync(ulong.Parse(@class.foundBLEDeviceID, NumberStyles.HexNumber))).GetAwaiter().GetResult();
					GattDeviceServicesResult result = WindowsRuntimeSystemExtensions.AsTask<GattDeviceServicesResult>(bluetoothLEDevice.GetGattServicesForUuidAsync(Guid.Parse(GClass125.string_5), 1)).GetAwaiter().GetResult();
					if (result.Status == null)
					{
						GForm12.Class12 class2 = new GForm12.Class12();
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
						class2.sbBLEPeripheralReceivedData = new StringBuilder(1000);
						WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(gattCharacteristic.WriteClientCharacteristicConfigurationDescriptorWithResultAsync(1)).GetAwaiter();
						GattCharacteristic object2 = gattCharacteristic;
						WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>>(new Func<TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>, EventRegistrationToken>(object2.add_ValueChanged), new Action<EventRegistrationToken>(object2.remove_ValueChanged), new TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs>(class2.method_0));
						Thread.Sleep(100);
						byte[] bytes = Encoding.ASCII.GetBytes(GClass107.smethod_3(137605));
						WindowsRuntimeSystemExtensions.AsTask<GattWriteResult>(gattCharacteristic2.WriteValueWithResultAsync(WindowsRuntimeBufferExtensions.AsBuffer(bytes))).GetAwaiter().GetResult();
						string text5 = "";
						long num2 = (long)(GClass126.smethod_1() + 3500);
						while (!text5.EndsWith(">") && num2 > (long)GClass126.smethod_1() && text5.Length < 6000)
						{
							if (class2.sbBLEPeripheralReceivedData.Length > 0)
							{
								text5 += class2.sbBLEPeripheralReceivedData[0].ToString();
								class2.sbBLEPeripheralReceivedData.Remove(0, 1);
								num2 = (long)(GClass126.smethod_1() + 2500);
							}
							else
							{
								Thread.Sleep(5);
							}
						}
						if (text5.Contains(GClass107.smethod_3(137627)))
						{
							text = text5.Replace(">", "").Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("AT@4", "").Replace("CANtieCAR", "").Replace("_", "");
							this.bool_0 = true;
						}
					}
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				if (bluetoothLEDevice != null)
				{
					if (gattDeviceService != null)
					{
						try
						{
							gattDeviceService.Session.Dispose();
							gattDeviceService.Dispose();
							gattDeviceService = null;
						}
						catch (Exception)
						{
						}
					}
					try
					{
						bluetoothLEDevice.Dispose();
						bluetoothLEDevice = null;
					}
					catch (Exception)
					{
					}
				}
			}
			goto IL_573;
			IL_5A6:
			if (!this.bool_0)
			{
				goto IL_1BC;
			}
			goto IL_573;
		}
		if (this.bool_1)
		{
			base.Invoke(new GForm12.Delegate15(this.method_2), new object[]
			{
				text
			});
		}
	}

	// Token: 0x060005C5 RID: 1477 RVA: 0x00004300 File Offset: 0x00002500
	private void method_2(string string_5)
	{
		if (string_5.Length > 4)
		{
			this.textBox_1.Text = string_5;
			this.label_0.Text = GClass107.smethod_3(137674);
			this.button_3.Visible = false;
			GClass125.string_31 = string_5;
		}
	}

	// Token: 0x060005C7 RID: 1479 RVA: 0x000D065C File Offset: 0x000CE85C
	private void method_3()
	{
		this.icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GForm12));
		this.panel_0 = new Panel();
		this.label_4 = new Label();
		this.textBox_5 = new TextBox();
		this.button_3 = new Button();
		this.label_3 = new Label();
		this.label_2 = new Label();
		this.textBox_4 = new TextBox();
		this.button_2 = new Button();
		this.button_1 = new Button();
		this.textBox_3 = new TextBox();
		this.panel_1 = new Panel();
		this.textBox_2 = new TextBox();
		this.button_0 = new Button();
		this.label_1 = new Label();
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.textBox_1 = new TextBox();
		this.toolTip_0 = new ToolTip(this.icontainer_0);
		this.panel_0.SuspendLayout();
		base.SuspendLayout();
		this.panel_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_0.BorderStyle = BorderStyle.FixedSingle;
		this.panel_0.Controls.Add(this.label_4);
		this.panel_0.Controls.Add(this.textBox_5);
		this.panel_0.Controls.Add(this.button_3);
		this.panel_0.Controls.Add(this.label_3);
		this.panel_0.Controls.Add(this.label_2);
		this.panel_0.Controls.Add(this.textBox_4);
		this.panel_0.Controls.Add(this.button_2);
		this.panel_0.Controls.Add(this.button_1);
		this.panel_0.Controls.Add(this.textBox_3);
		this.panel_0.Controls.Add(this.panel_1);
		this.panel_0.Controls.Add(this.textBox_2);
		this.panel_0.Controls.Add(this.button_0);
		this.panel_0.Controls.Add(this.label_1);
		this.panel_0.Controls.Add(this.label_0);
		this.panel_0.Controls.Add(this.textBox_0);
		this.panel_0.Controls.Add(this.textBox_1);
		this.panel_0.Location = new System.Drawing.Point(14, 15);
		this.panel_0.Margin = new Padding(3, 4, 3, 4);
		this.panel_0.Name = GClass107.smethod_3(138241);
		this.panel_0.Size = new System.Drawing.Size(477, 542);
		this.panel_0.TabIndex = 0;
		this.label_4.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_4.AutoSize = true;
		this.label_4.Location = new System.Drawing.Point(15, 452);
		this.label_4.Name = GClass107.smethod_3(138243);
		this.label_4.Size = new System.Drawing.Size(107, 20);
		this.label_4.TabIndex = 31;
		this.label_4.Text = GClass107.smethod_3(138275);
		this.label_4.Visible = false;
		this.textBox_5.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_5.Location = new System.Drawing.Point(130, 448);
		this.textBox_5.Margin = new Padding(3, 4, 3, 4);
		this.textBox_5.Name = GClass107.smethod_3(138285);
		this.textBox_5.Size = new System.Drawing.Size(329, 26);
		this.textBox_5.TabIndex = 30;
		this.textBox_5.Visible = false;
		this.button_3.Location = new System.Drawing.Point(130, 207);
		this.button_3.Margin = new Padding(3, 4, 3, 4);
		this.button_3.Name = GClass107.smethod_3(138305);
		this.button_3.Size = new System.Drawing.Size(329, 34);
		this.button_3.TabIndex = 29;
		this.button_3.Text = GClass107.smethod_3(138326);
		this.button_3.UseVisualStyleBackColor = true;
		this.button_3.Click += this.button_3_Click;
		this.label_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_3.AutoSize = true;
		this.label_3.Cursor = Cursors.Hand;
		this.label_3.Font = new Font(GClass107.smethod_3(138366), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_3.ForeColor = Color.Navy;
		this.label_3.Location = new System.Drawing.Point(17, 340);
		this.label_3.Name = GClass107.smethod_3(138392);
		this.label_3.Size = new System.Drawing.Size(453, 21);
		this.label_3.TabIndex = 28;
		this.label_3.Text = GClass107.smethod_3(138407);
		this.label_3.MouseClick += this.label_3_MouseClick;
		this.label_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_2.AutoSize = true;
		this.label_2.Location = new System.Drawing.Point(15, 418);
		this.label_2.Name = GClass107.smethod_3(138423);
		this.label_2.Size = new System.Drawing.Size(101, 20);
		this.label_2.TabIndex = 27;
		this.label_2.Text = GClass107.smethod_3(138452);
		this.textBox_4.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_4.Location = new System.Drawing.Point(130, 414);
		this.textBox_4.Margin = new Padding(3, 4, 3, 4);
		this.textBox_4.Name = GClass107.smethod_3(138468);
		this.textBox_4.Size = new System.Drawing.Size(329, 26);
		this.textBox_4.TabIndex = 26;
		this.button_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_2.Location = new System.Drawing.Point(18, 493);
		this.button_2.Margin = new Padding(3, 4, 3, 4);
		this.button_2.Name = GClass107.smethod_3(138513);
		this.button_2.Size = new System.Drawing.Size(118, 34);
		this.button_2.TabIndex = 25;
		this.button_2.Text = GClass107.smethod_3(138526);
		this.button_2.UseVisualStyleBackColor = true;
		this.button_2.Click += this.button_2_Click;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new System.Drawing.Point(362, 493);
		this.button_1.Margin = new Padding(3, 4, 3, 4);
		this.button_1.Name = GClass107.smethod_3(138557);
		this.button_1.Size = new System.Drawing.Size(98, 34);
		this.button_1.TabIndex = 24;
		this.button_1.Text = GClass107.smethod_3(138585);
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.textBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_3.BackColor = Color.White;
		this.textBox_3.BorderStyle = BorderStyle.None;
		this.textBox_3.Enabled = false;
		this.textBox_3.Font = new Font(GClass107.smethod_3(138612), 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.textBox_3.ForeColor = Color.Red;
		this.textBox_3.Location = new System.Drawing.Point(3, 132);
		this.textBox_3.Margin = new Padding(3, 4, 3, 4);
		this.textBox_3.Multiline = true;
		this.textBox_3.Name = GClass107.smethod_3(138616);
		this.textBox_3.ReadOnly = true;
		this.textBox_3.Size = new System.Drawing.Size(468, 32);
		this.textBox_3.TabIndex = 23;
		this.textBox_3.Text = GClass107.smethod_3(138664);
		this.textBox_3.TextAlign = HorizontalAlignment.Center;
		this.panel_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_1.BackgroundImage = (Image)componentResourceManager.GetObject(GClass107.smethod_3(138706));
		this.panel_1.BackgroundImageLayout = ImageLayout.Center;
		this.panel_1.Location = new System.Drawing.Point(3, 4);
		this.panel_1.Margin = new Padding(3, 4, 3, 4);
		this.panel_1.Name = GClass107.smethod_3(138745);
		this.panel_1.Size = new System.Drawing.Size(468, 116);
		this.panel_1.TabIndex = 21;
		this.textBox_2.BackColor = Color.White;
		this.textBox_2.BorderStyle = BorderStyle.None;
		this.textBox_2.Enabled = false;
		this.textBox_2.Location = new System.Drawing.Point(18, 251);
		this.textBox_2.Margin = new Padding(3, 4, 3, 4);
		this.textBox_2.Multiline = true;
		this.textBox_2.Name = GClass107.smethod_3(138773);
		this.textBox_2.ReadOnly = true;
		this.textBox_2.Size = new System.Drawing.Size(442, 87);
		this.textBox_2.TabIndex = 6;
		this.textBox_2.Text = GClass107.smethod_3(138816) + GClass107.smethod_3(138827) + GClass107.smethod_3(138836);
		this.textBox_2.TextAlign = HorizontalAlignment.Center;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.Location = new System.Drawing.Point(189, 493);
		this.button_0.Margin = new Padding(3, 4, 3, 4);
		this.button_0.Name = GClass107.smethod_3(138865);
		this.button_0.Size = new System.Drawing.Size(98, 34);
		this.button_0.TabIndex = 4;
		this.button_0.Text = GClass107.smethod_3(138881);
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.label_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_1.AutoSize = true;
		this.label_1.Location = new System.Drawing.Point(15, 383);
		this.label_1.Name = GClass107.smethod_3(138898);
		this.label_1.Size = new System.Drawing.Size(94, 20);
		this.label_1.TabIndex = 3;
		this.label_1.Text = GClass107.smethod_3(138910);
		this.label_0.AutoSize = true;
		this.label_0.Location = new System.Drawing.Point(15, 178);
		this.label_0.Name = GClass107.smethod_3(138925);
		this.label_0.Size = new System.Drawing.Size(108, 20);
		this.label_0.TabIndex = 2;
		this.label_0.Text = GClass107.smethod_3(138944);
		this.textBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.Location = new System.Drawing.Point(130, 379);
		this.textBox_0.Margin = new Padding(3, 4, 3, 4);
		this.textBox_0.Name = GClass107.smethod_3(138965);
		this.textBox_0.Size = new System.Drawing.Size(329, 26);
		this.textBox_0.TabIndex = 1;
		this.textBox_0.TextChanged += this.textBox_0_TextChanged;
		this.textBox_0.KeyUp += this.textBox_0_KeyUp;
		this.textBox_1.Location = new System.Drawing.Point(130, 174);
		this.textBox_1.Margin = new Padding(3, 4, 3, 4);
		this.textBox_1.Name = GClass107.smethod_3(139008);
		this.textBox_1.ReadOnly = true;
		this.textBox_1.Size = new System.Drawing.Size(329, 26);
		this.textBox_1.TabIndex = 0;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.White;
		base.CancelButton = this.button_1;
		base.ClientSize = new System.Drawing.Size(504, 573);
		base.Controls.Add(this.panel_0);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = GClass107.smethod_3(139036);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		this.Text = GClass107.smethod_3(139085);
		base.FormClosing += this.GForm12_FormClosing;
		base.Shown += this.GForm12_Shown;
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		base.ResumeLayout(false);
	}

	// Token: 0x040004A6 RID: 1190
	private string[] string_0 = new string[]
	{
		GClass107.smethod_3(136982),
		GClass107.smethod_3(137015),
		GClass107.smethod_3(137037)
	};

	// Token: 0x040004A7 RID: 1191
	private string string_1 = GClass107.smethod_3(137056);

	// Token: 0x040004A8 RID: 1192
	private string string_2 = GClass107.smethod_3(137099);

	// Token: 0x040004A9 RID: 1193
	private string string_3 = GClass107.smethod_3(137140);

	// Token: 0x040004AA RID: 1194
	private bool bool_0;

	// Token: 0x040004AB RID: 1195
	private bool bool_1;

	// Token: 0x040004AC RID: 1196
	private string string_4 = "";

	// Token: 0x040004AE RID: 1198
	private Panel panel_0;

	// Token: 0x040004AF RID: 1199
	private Label label_0;

	// Token: 0x040004B0 RID: 1200
	private TextBox textBox_0;

	// Token: 0x040004B1 RID: 1201
	private TextBox textBox_1;

	// Token: 0x040004B2 RID: 1202
	private Label label_1;

	// Token: 0x040004B3 RID: 1203
	private Button button_0;

	// Token: 0x040004B4 RID: 1204
	private TextBox textBox_2;

	// Token: 0x040004B5 RID: 1205
	private Panel panel_1;

	// Token: 0x040004B6 RID: 1206
	private TextBox textBox_3;

	// Token: 0x040004B7 RID: 1207
	private Button button_1;

	// Token: 0x040004B8 RID: 1208
	private Button button_2;

	// Token: 0x040004B9 RID: 1209
	private Label label_2;

	// Token: 0x040004BA RID: 1210
	private TextBox textBox_4;

	// Token: 0x040004BB RID: 1211
	private Label label_3;

	// Token: 0x040004BC RID: 1212
	private Button button_3;

	// Token: 0x040004BD RID: 1213
	private Label label_4;

	// Token: 0x040004BE RID: 1214
	private TextBox textBox_5;

	// Token: 0x040004BF RID: 1215
	private ToolTip toolTip_0;

	// Token: 0x020000B0 RID: 176
	// (Invoke) Token: 0x060005C9 RID: 1481
	private delegate void Delegate15(string ctcsn);

	// Token: 0x020000B1 RID: 177
	[CompilerGenerated]
	private sealed class Class11
	{
		// Token: 0x060005CD RID: 1485 RVA: 0x000D1424 File Offset: 0x000CF624
		internal void method_0(BluetoothLEAdvertisementWatcher s, BluetoothLEAdvertisementReceivedEventArgs e)
		{
			if (e.Advertisement.LocalName.StartsWith(GClass107.smethod_3(137556)))
			{
				this.foundBLEDeviceID = e.BluetoothAddress.ToString("x").ToUpper();
			}
		}

		// Token: 0x040004C0 RID: 1216
		public string foundBLEDeviceID;
	}

	// Token: 0x020000B2 RID: 178
	[CompilerGenerated]
	private sealed class Class12
	{
		// Token: 0x060005CF RID: 1487 RVA: 0x0000435D File Offset: 0x0000255D
		internal void method_0(GattCharacteristic sender, GattValueChangedEventArgs args)
		{
			this.sbBLEPeripheralReceivedData.Append(Encoding.ASCII.GetString(WindowsRuntimeBufferExtensions.ToArray(args.CharacteristicValue)));
		}

		// Token: 0x040004C1 RID: 1217
		public StringBuilder sbBLEPeripheralReceivedData;
	}
}
