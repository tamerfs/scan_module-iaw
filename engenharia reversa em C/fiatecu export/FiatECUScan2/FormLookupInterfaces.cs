using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

// Token: 0x02000018 RID: 24
public sealed partial class FormLookupInterfaces : Form
{
	// Token: 0x060000DB RID: 219 RVA: 0x0002472C File Offset: 0x0002292C
	public FormLookupInterfaces()
	{
		this.InitializeComponent();
		this.buttonOK.Enabled = false;
		this.buttonOK.Text = GClass62.smethod_1(this.buttonOK.Tag.ToString());
		this.buttonCancel.Text = GClass62.smethod_1(this.buttonCancel.Tag.ToString());
		this.Text = GClass62.smethod_1("8127");
		this.progressBar1.Maximum = SerialPort.GetPortNames().Length * this.int_1.Length + 1;
		this.progressBar1.Value = this.int_0;
		new Thread(new ThreadStart(this.method_1)).Start();
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00002AFD File Offset: 0x00000CFD
	private void method_0(string string_2)
	{
		this.string_0 = this.string_0 + string_2 + Environment.NewLine;
		this.bool_0 = false;
	}

	// Token: 0x060000DD RID: 221 RVA: 0x00024858 File Offset: 0x00022A58
	private void method_1()
	{
		try
		{
			this.method_0(GClass62.smethod_1("1099"));
			this.method_0(string.Empty);
			string[] portNames = SerialPort.GetPortNames();
			List<string> list = new List<string>();
			int i = 1;
			IL_9D:
			while (i < 31)
			{
				for (int j = 0; j < portNames.Length; j++)
				{
					if ((i < 4 && portNames[j] == "COM" + i) || (i > 3 && portNames[j].StartsWith("COM" + i)))
					{
						list.Add("COM" + i);
						IL_99:
						i++;
						goto IL_9D;
					}
				}
				goto IL_99;
			}
			foreach (string text in list)
			{
				GClass3.smethod_2("Testing for interface on " + text + " ...", 0);
				this.string_1 = string.Format(GClass62.smethod_1("1096"), text);
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = true;
				bool flag7 = true;
				bool flag8 = false;
				int num = 0;
				int num2 = 0;
				for (int k = 0; k < this.int_1.Length; k++)
				{
					int num3 = this.int_1[k];
					this.int_0++;
					if (this.bool_1)
					{
						this.bool_2 = true;
						return;
					}
					if (!flag && (k != 3 || (!flag2 && !flag3 && !flag4)))
					{
						Thread.Sleep(100);
						if (flag2 || flag3 || flag4)
						{
							for (i = 0; i < 50; i++)
							{
								if (this.bool_1)
								{
									this.bool_2 = true;
									return;
								}
								Thread.Sleep(100);
							}
						}
						try
						{
							try
							{
								GClass3.smethod_2("Testing at " + num3 + "bps ...", 0);
								this.serialPort_0 = new SerialPort(text, num3, Parity.None, 8, StopBits.One);
								this.serialPort_0.WriteBufferSize = 2;
								this.serialPort_0.WriteTimeout = 2000;
								this.serialPort_0.ReceivedBytesThreshold = 1000;
								this.serialPort_0.Handshake = Handshake.None;
								this.serialPort_0.NewLine = "\r\n";
								flag = true;
								this.serialPort_0.Open();
								flag = false;
								GClass3.smethod_2("Serial port exists", 0);
								if (k == 3 && !flag2 && !flag3 && !flag4)
								{
									try
									{
										this.serialPort_0.ReadTimeout = 50;
										int num4 = GClass3.smethod_1();
										SerialPort serialPort = this.serialPort_0;
										byte[] buffer = new byte[1];
										serialPort.Write(buffer, 0, 1);
										byte b = (byte)this.serialPort_0.ReadByte();
										this.serialPort_0.Write(new byte[]
										{
											165
										}, 0, 1);
										byte b2 = (byte)this.serialPort_0.ReadByte();
										int num5 = GClass3.smethod_1();
										if (b != 0 || b2 != 165)
										{
											throw new Exception("VagCom interface not found... ");
										}
										GClass3.smethod_2("VagCom interface found... Latency: " + (num5 - num4) / 2 + " ms", 0);
										this.method_0(string.Format(GClass62.smethod_1("1097"), text));
										if ((num5 - num4) / 2 > 15)
										{
											this.method_0(GClass62.smethod_1("1060"));
										}
										if (!GClass3.bool_2)
										{
											this.list_0.Add(1);
											this.list_1.Add(text);
											this.list_2.Add(num3);
										}
										flag = true;
										goto IL_732;
									}
									catch (Exception ex)
									{
										GClass3.smethod_2("VagCom interface not found...", 0);
										goto IL_534;
									}
								}
								try
								{
									this.serialPort_0.NewLine = "\r";
									this.serialPort_0.ReadTimeout = 5000;
									this.method_2(string.Empty);
									this.method_4();
									Thread.Sleep(50);
									this.method_2("ATI");
									string text2 = this.method_4();
									if (text2.Contains("ELM327"))
									{
										GClass3.smethod_2("ELM 327 interface found...", 0);
										if (flag2)
										{
											flag5 = true;
										}
										if (!flag2)
										{
											this.method_2("ATZ");
											text2 = this.method_4();
											this.method_2("AT@1");
											text2 = this.method_4();
											if (text2.Contains("SCANTOOL"))
											{
												flag8 = true;
											}
											int num4 = GClass3.smethod_1();
											this.method_2("ATCRA 7B0");
											text2 = this.method_4();
											int num5 = GClass3.smethod_1();
											if (!text2.Contains("OK"))
											{
												flag6 = false;
											}
											this.method_2("ATIB48");
											text2 = this.method_4();
											if (!text2.Contains("OK"))
											{
												flag7 = false;
											}
											num2 = num5 - num4;
											GClass3.smethod_2("Latency: " + num2 + " ms", 0);
										}
										flag2 = true;
										num = num3;
									}
									else if (text2.Contains("OBDKey"))
									{
										GClass3.smethod_2("OBDKey interface found...", 0);
										if (flag3)
										{
											flag5 = true;
										}
										flag3 = true;
										num = num3;
									}
									else if (text2.Contains("FiatECUScan v3.4+"))
									{
										GClass3.smethod_2("CANtieCAR interface found...", 0);
										if (flag4)
										{
											flag5 = true;
										}
										flag4 = true;
										num = num3;
									}
								}
								catch (Exception ex)
								{
									GClass3.smethod_2("ELM interface not found..." + ex.Message, 0);
								}
								IL_534:;
							}
							catch (Exception ex2)
							{
								GClass3.smethod_2("ERROR: " + ex2.Message, 0);
							}
							goto IL_732;
						}
						finally
						{
							if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
							{
								try
								{
									this.serialPort_0.Close();
									GClass3.smethod_2("Serial port closed!", 0);
								}
								catch (Exception ex3)
								{
									GClass3.smethod_2("ERROR: Failed to close serial port: " + ex3.Message, 0);
								}
								GClass3.smethod_2(" ", 0);
							}
						}
						break;
					}
					IL_732:;
				}
				if (flag2 || flag3)
				{
					int num6 = flag3 ? 4 : 2;
					if (flag5)
					{
						num6++;
					}
					if (flag8)
					{
						num6 = 7;
					}
					this.method_0(string.Format(GClass62.smethod_1("1098"), GClass61.string_0[num6], text, num));
					if (flag2 && !flag8)
					{
						if (flag6 && flag7)
						{
							this.method_0(GClass62.smethod_1("1202"));
						}
						else if (flag6)
						{
							this.method_0(GClass62.smethod_1("1201"));
						}
						else
						{
							this.method_0(GClass62.smethod_1("1200"));
						}
						if (!flag5 && num2 > 13)
						{
							this.method_0(GClass62.smethod_1("1060"));
						}
					}
					this.method_0(string.Empty);
					if (!GClass3.bool_2)
					{
						this.list_0.Add(num6);
						this.list_1.Add(text);
						this.list_2.Add(num);
					}
				}
				else if (flag4)
				{
					this.method_0(string.Format(GClass62.smethod_1("1098"), GClass61.string_0[6], text, num));
					this.method_0(string.Empty);
					if (GClass3.bool_2)
					{
						this.list_0.Add(6);
						this.list_1.Add(text);
						this.list_2.Add(num);
					}
				}
			}
		}
		catch (Exception ex4)
		{
			this.string_0 = this.string_0 + ex4.Message + Environment.NewLine;
			this.bool_0 = false;
		}
		this.method_0(GClass62.smethod_1("6051"));
		this.string_1 = GClass62.smethod_1("6051");
		this.int_0 = 9999;
		this.bool_2 = true;
	}

	// Token: 0x060000DE RID: 222 RVA: 0x000250CC File Offset: 0x000232CC
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!this.bool_0)
		{
			this.bool_0 = true;
			this.textBox1.Text = this.string_0;
			this.textBox1.SelectionStart = this.textBox1.Text.Length;
			this.textBox1.ScrollToCaret();
		}
		if (this.int_0 <= this.progressBar1.Maximum)
		{
			this.progressBar1.Value = this.int_0;
		}
		else
		{
			this.progressBar1.Value = this.progressBar1.Maximum;
		}
		if (this.bool_1 && !this.bool_2)
		{
			this.label1.Text = "Cancelling...";
		}
		else if (this.label1.Text != this.string_1)
		{
			this.label1.Text = this.string_1;
		}
		if (this.bool_2 && !this.buttonOK.Enabled)
		{
			this.buttonOK.Enabled = true;
		}
	}

	// Token: 0x060000DF RID: 223 RVA: 0x00002B1D File Offset: 0x00000D1D
	private void buttonCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x00002B2C File Offset: 0x00000D2C
	private void buttonOK_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x000251D4 File Offset: 0x000233D4
	private void method_2(string string_2)
	{
		this.serialPort_0.ReadExisting();
		for (int i = 0; i < string_2.Length; i++)
		{
			this.serialPort_0.Write(string_2.Substring(i, 1));
		}
		this.serialPort_0.Write(this.serialPort_0.NewLine);
		GClass3.smethod_2("Sent: " + string_2, 0);
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x0002523C File Offset: 0x0002343C
	private void method_3(string string_2)
	{
		this.method_2(string_2);
		this.string_0 = this.string_0 + "COMMAND: " + string_2 + Environment.NewLine;
		string text = this.method_4();
		string text2 = this.string_0;
		this.string_0 = string.Concat(new string[]
		{
			text2,
			"RESPONSE: ",
			text,
			Environment.NewLine,
			Environment.NewLine
		});
		this.bool_0 = false;
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x000252B4 File Offset: 0x000234B4
	private string method_4()
	{
		string text = string.Empty;
		while (!text.EndsWith(">") && text.Length < 200)
		{
			text += (char)this.serialPort_0.ReadByte();
		}
		GClass3.smethod_2("Received: " + text, 0);
		return text;
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x00025318 File Offset: 0x00023518
	private void FormLookupInterfaces_FormClosing(object sender, FormClosingEventArgs e)
	{
		this.bool_1 = true;
		int num = 50;
		while (num > 0 && !this.bool_2)
		{
			Thread.Sleep(100);
			num--;
		}
	}

	// Token: 0x040000EF RID: 239
	private SerialPort serialPort_0;

	// Token: 0x040000F0 RID: 240
	private string string_0 = string.Empty;

	// Token: 0x040000F1 RID: 241
	private bool bool_0 = false;

	// Token: 0x040000F2 RID: 242
	private int int_0 = 0;

	// Token: 0x040000F3 RID: 243
	private bool bool_1 = false;

	// Token: 0x040000F4 RID: 244
	private bool bool_2 = false;

	// Token: 0x040000F5 RID: 245
	private string string_1 = string.Empty;

	// Token: 0x040000F6 RID: 246
	public List<int> list_0 = new List<int>();

	// Token: 0x040000F7 RID: 247
	public List<string> list_1 = new List<string>();

	// Token: 0x040000F8 RID: 248
	public List<int> list_2 = new List<int>();

	// Token: 0x040000F9 RID: 249
	private int[] int_1 = new int[]
	{
		9600,
		38400,
		115200,
		10400
	};
}
