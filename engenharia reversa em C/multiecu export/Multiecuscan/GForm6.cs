using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Management;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

// Token: 0x02000099 RID: 153
public partial class GForm6 : Form
{
	// Token: 0x060004AF RID: 1199 RVA: 0x00003CA9 File Offset: 0x00001EA9
	private void button_0_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	// Token: 0x060004B0 RID: 1200 RVA: 0x000A7704 File Offset: 0x000A5904
	private void method_0(string string_2)
	{
		this.serialPort_0.ReadExisting();
		for (int i = 0; i < string_2.Length; i++)
		{
			this.serialPort_0.Write(string_2.Substring(i, 1));
		}
		this.serialPort_0.Write(this.serialPort_0.NewLine);
		GClass126.smethod_2(GClass107.smethod_3(91069) + string_2, 0);
	}

	// Token: 0x060004B1 RID: 1201 RVA: 0x000A7770 File Offset: 0x000A5970
	public GForm6()
	{
		this.method_8();
		this.progressBar_0.Maximum = 1;
		this.button_1.Enabled = false;
		this.button_1.Text = GClass121.smethod_6(this.button_1.Tag.ToString());
		this.button_0.Text = GClass121.smethod_6(this.button_0.Tag.ToString());
		this.Text = GClass121.smethod_6("8127");
		this.progressBar_0.Value = this.int_0;
		new Thread(new ThreadStart(this.method_4)).Start();
	}

	// Token: 0x060004B2 RID: 1202 RVA: 0x00003CB8 File Offset: 0x00001EB8
	private void method_1(string string_2)
	{
		this.string_0 = this.string_0 + string_2 + Environment.NewLine;
		this.bool_0 = false;
	}

	// Token: 0x060004B3 RID: 1203 RVA: 0x000A789C File Offset: 0x000A5A9C
	private void GForm6_FormClosing(object sender, FormClosingEventArgs e)
	{
		this.bool_1 = true;
		if (this.bool_1)
		{
			this.timer_0.Enabled = false;
		}
		Thread.Sleep(20);
		int num = 20;
		while (num > 0 && !this.bool_2)
		{
			Thread.Sleep(100);
			num--;
		}
	}

	// Token: 0x060004B4 RID: 1204 RVA: 0x000A78E8 File Offset: 0x000A5AE8
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!this.bool_0)
		{
			this.bool_0 = true;
			this.textBox_0.Text = this.string_0;
			this.textBox_0.SelectionStart = this.textBox_0.Text.Length;
			this.textBox_0.ScrollToCaret();
		}
		if (this.progressBar_0.Maximum == 1 && this.int_1 > 1)
		{
			this.progressBar_0.Maximum = this.int_1;
		}
		if (this.int_0 <= this.progressBar_0.Maximum)
		{
			this.progressBar_0.Value = this.int_0;
		}
		else
		{
			this.progressBar_0.Value = this.progressBar_0.Maximum;
		}
		if (this.bool_1 && !this.bool_2)
		{
			this.label_0.Text = GClass107.smethod_3(91020);
		}
		else if (this.label_0.Text != this.string_1)
		{
			this.label_0.Text = this.string_1;
		}
		if ((this.bool_2 || this.list_0.Count > 0) && !this.button_1.Enabled)
		{
			this.button_1.Enabled = true;
		}
	}

	// Token: 0x060004B5 RID: 1205 RVA: 0x000A7A20 File Offset: 0x000A5C20
	private void method_2(string string_2)
	{
		GClass126.smethod_2(GClass107.smethod_3(91117) + string_2, 0);
		byte[] bytes = Encoding.ASCII.GetBytes(string_2 + "\r");
		byte[] array = new byte[1];
		for (int i = 0; i < bytes.Length; i++)
		{
			array[0] = bytes[i];
			this.tcpClient_0.Client.Send(array);
		}
	}

	// Token: 0x060004B6 RID: 1206 RVA: 0x000A7A88 File Offset: 0x000A5C88
	private void method_3(string string_2)
	{
		this.method_0(string_2);
		this.string_0 = this.string_0 + GClass107.smethod_3(91122) + string_2 + Environment.NewLine;
		string text = this.method_6();
		this.string_0 = string.Concat(new string[]
		{
			this.string_0,
			GClass107.smethod_3(91151),
			text,
			Environment.NewLine,
			Environment.NewLine
		});
		this.bool_0 = false;
	}

	// Token: 0x060004B7 RID: 1207 RVA: 0x000A7B08 File Offset: 0x000A5D08
	private void method_4()
	{
		try
		{
			GClass126.smethod_2(GClass107.smethod_3(89592), 0);
			this.method_1(GClass107.smethod_3(89603));
			this.method_1(GClass121.smethod_6("1099"));
			this.method_1("");
			this.int_1 = 100;
			this.int_0 = 0;
			try
			{
				ManagementObjectCollection managementObjectCollection;
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(GClass107.smethod_3(89640)))
				{
					managementObjectCollection = managementObjectSearcher.Get();
				}
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator())
				{
					IL_164:
					while (enumerator.MoveNext())
					{
						ManagementBaseObject managementBaseObject = enumerator.Current;
						string text = (string)managementBaseObject.GetPropertyValue(GClass107.smethod_3(89684));
						string text2 = text.Substring(text.LastIndexOf(GClass107.smethod_3(89693))).Replace("(", string.Empty).Replace(")", string.Empty);
						GClass126.smethod_2(GClass107.smethod_3(89723) + text + ",   " + (string)managementBaseObject.GetPropertyValue(GClass107.smethod_3(89745)), 0);
						for (int i = 500; i > 0; i--)
						{
							if (text2.Contains("COM" + i.ToString()))
							{
								text2 = "COM" + i.ToString();
								IL_14A:
								this.list_3.Add(text2);
								this.list_4.Add(text);
								goto IL_164;
							}
						}
						goto IL_14A;
					}
				}
				managementObjectCollection.Dispose();
			}
			catch (Exception)
			{
			}
			if (this.bool_1)
			{
				this.bool_2 = true;
				return;
			}
			int j = 500;
			IL_236:
			while (j > 0)
			{
				for (int k = 0; k < this.list_3.Count; k++)
				{
					if (this.list_3[k].StartsWith("COM" + j.ToString()))
					{
						this.list_5.Add("COM" + j.ToString());
						this.list_6.Add(this.list_4[k]);
						this.list_3[k] = "";
						IL_230:
						j--;
						goto IL_236;
					}
				}
				goto IL_230;
			}
			this.int_1 = this.list_5.Count * this.int_2.Length + 2;
			if (this.bool_1)
			{
				this.bool_2 = true;
				return;
			}
			try
			{
				GClass126.smethod_2(GClass107.smethod_3(89761), 0);
				this.string_1 = string.Format(GClass121.smethod_6("1096"), GClass107.smethod_3(89778));
				this.tcpClient_0 = new TcpClient();
				if (!this.tcpClient_0.BeginConnect("192.168.0.10", 35000, null, null).AsyncWaitHandle.WaitOne(2000) || !this.tcpClient_0.Connected)
				{
					throw new Exception(GClass107.smethod_3(89820));
				}
				GClass126.smethod_2(GClass107.smethod_3(89837), 0);
				for (int l = 0; l < 5; l++)
				{
					Thread.Sleep(100);
				}
				this.method_2("ATI");
				string text3 = this.method_7();
				this.method_2("STI");
				string text4 = this.method_7();
				if ((text3.Contains(GClass107.smethod_3(89861)) || text3.Contains("OBD")) && !text4.Contains("STN") && !text3.Contains(GClass107.smethod_3(89881)))
				{
					GClass126.smethod_2(GClass107.smethod_3(89920), 0);
					bool flag = false;
					this.method_2("ATZ");
					text3 = this.method_7();
					int num = GClass126.smethod_1();
					this.method_2(GClass107.smethod_3(89966));
					text3 = this.method_7();
					int num2 = GClass126.smethod_1();
					if (!text3.Contains("OK"))
					{
						flag = true;
					}
					this.method_2(GClass107.smethod_3(90003));
					text3 = this.method_7();
					if (!text3.Contains("OK"))
					{
						flag = true;
					}
					int num3 = num2 - num;
					GClass126.smethod_2(GClass107.smethod_3(90014) + num3.ToString() + " ms", 0);
					this.list_0.Add(9);
					this.list_1.Add(GClass107.smethod_3(90034));
					this.list_2.Add(9600);
					this.method_1(string.Format(GClass121.smethod_6("1098"), GClass125.string_1[9], GClass107.smethod_3(90055), "-"));
					if (flag)
					{
						this.method_1(GClass121.smethod_6("1200"));
					}
					if (num3 > 20)
					{
						this.method_1(GClass121.smethod_6("1060"));
					}
				}
				else if (text4.Contains("STN"))
				{
					GClass126.smethod_2(GClass107.smethod_3(90075), 0);
					this.method_2(GClass107.smethod_3(90124));
					text3 = this.method_7();
					int num4 = GClass126.smethod_1();
					this.method_2(GClass107.smethod_3(90153));
					text3 = this.method_7();
					int num5 = GClass126.smethod_1();
					this.method_2(GClass107.smethod_3(90186));
					text3 = this.method_7();
					int num6 = num5 - num4;
					GClass126.smethod_2(GClass107.smethod_3(90203) + num6.ToString() + " ms", 0);
					this.list_0.Add(12);
					this.list_1.Add(GClass107.smethod_3(90249));
					this.list_2.Add(9600);
					string str = text4.Replace("STI", "").Replace(">", "").Replace("\r", "");
					this.method_1(string.Format(GClass121.smethod_6("1098"), GClass125.string_1[12] + " / " + str, GClass107.smethod_3(90258), "-"));
					if (num6 > 20)
					{
						this.method_1(GClass121.smethod_6("1060"));
					}
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				if (this.tcpClient_0 != null && this.tcpClient_0.Connected)
				{
					try
					{
						this.tcpClient_0.Close();
					}
					catch (Exception ex)
					{
						GClass126.smethod_2(GClass107.smethod_3(90289) + ex.Message, 1);
					}
				}
			}
			if (this.bool_1)
			{
				this.bool_2 = true;
				return;
			}
			this.int_0++;
			string text5 = "";
			for (int m = this.list_5.Count - 1; m >= 0; m--)
			{
				text5 = this.list_5[m];
				string text6 = this.list_6[m];
				bool flag2 = text6.ToLower().Contains(GClass107.smethod_3(90306));
				GClass126.smethod_2(string.Concat(new string[]
				{
					GClass107.smethod_3(90342),
					text5,
					" (",
					text6,
					GClass107.smethod_3(90390)
				}), 0);
				this.string_1 = string.Format(GClass121.smethod_6("1096"), text6);
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = false;
				bool flag8 = false;
				bool flag9 = false;
				bool flag10 = false;
				bool flag11 = false;
				int num7 = 0;
				int num8 = 0;
				string str2 = "";
				for (int n = 0; n < this.int_2.Length; n++)
				{
					int num9 = this.int_2[n];
					this.int_0++;
					if (this.bool_1)
					{
						this.bool_2 = true;
						return;
					}
					if ((!GClass126.bool_10 || num9 == 115200) && !flag3 && (n != 3 || (!flag4 && !flag5 && !flag6)))
					{
						Thread.Sleep(50);
						if (flag4 || flag5 || flag6)
						{
							if (flag7)
							{
								goto IL_FC9;
							}
							for (int num10 = 0; num10 < 40; num10++)
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
								GClass126.smethod_2(GClass107.smethod_3(90404) + num9.ToString() + GClass107.smethod_3(90416), 0);
								this.serialPort_0 = new SerialPort(text5, num9, Parity.None, 8, StopBits.One);
								this.serialPort_0.WriteBufferSize = 2;
								this.serialPort_0.WriteTimeout = ((n == 0) ? 1000 : 500);
								this.serialPort_0.ReceivedBytesThreshold = 1000;
								this.serialPort_0.Handshake = Handshake.None;
								this.serialPort_0.NewLine = "\r";
								flag3 = true;
								this.serialPort_0.Open();
								flag3 = false;
								GClass126.smethod_2(GClass107.smethod_3(90436), 0);
								if (n == 3 && !flag4 && !flag5 && !flag6)
								{
									try
									{
										this.serialPort_0.ReadTimeout = 50;
										int num11 = GClass126.smethod_1();
										this.serialPort_0.Write(new byte[1], 0, 1);
										byte b = (byte)this.serialPort_0.ReadByte();
										this.serialPort_0.Write(new byte[]
										{
											165
										}, 0, 1);
										byte b2 = (byte)this.serialPort_0.ReadByte();
										int num12 = GClass126.smethod_1();
										byte b3 = 55;
										this.serialPort_0.BreakState = true;
										this.serialPort_0.RtsEnable = true;
										for (int num13 = 1; num13 < 10; num13++)
										{
											b3 += 1;
										}
										this.serialPort_0.BreakState = false;
										this.serialPort_0.RtsEnable = false;
										b3 = 55;
										try
										{
											b3 = (byte)this.serialPort_0.ReadByte();
										}
										catch (Exception)
										{
										}
										GClass126.smethod_2(GClass107.smethod_3(90458) + GClass127.smethod_23(b3), 0);
										this.serialPort_0.BreakState = false;
										this.serialPort_0.RtsEnable = false;
										if (b == 0 && b2 == 165)
										{
											if (b3 != 55)
											{
												GClass126.smethod_2(GClass107.smethod_3(90522) + ((num12 - num11) / 2).ToString() + " ms", 0);
												this.method_1(string.Format(GClass121.smethod_6("1097"), text5));
												if ((num12 - num11) / 2 > 15)
												{
													this.method_1(GClass121.smethod_6("1060"));
												}
												if (!GClass126.bool_10)
												{
													this.list_0.Add(1);
													this.list_1.Add(text5);
													this.list_2.Add(9600);
												}
												flag3 = true;
												goto IL_FC9;
											}
										}
										throw new Exception(GClass107.smethod_3(90496));
									}
									catch (Exception ex2)
									{
										GClass126.smethod_2(ex2.Message, 0);
										GClass126.smethod_2(GClass107.smethod_3(90540), 0);
										goto IL_DD6;
									}
								}
								try
								{
									this.serialPort_0.NewLine = "\r";
									this.serialPort_0.ReadTimeout = ((n == 0) ? 1000 : 500);
									this.method_0("");
									this.method_6();
									Thread.Sleep(50);
									this.method_0("ATI");
									string text7 = this.method_6();
									this.method_0("STI");
									string text8 = this.method_6();
									if ((text7.Contains(GClass107.smethod_3(90576)) || text7.Contains("OBD")) && !text8.Contains("STN") && !text7.Contains(GClass107.smethod_3(90613)))
									{
										GClass126.smethod_2(GClass107.smethod_3(90662), 0);
										if (flag4)
										{
											flag7 = true;
										}
										if (flag2)
										{
											flag7 = true;
										}
										if (!flag4)
										{
											this.serialPort_0.ReadTimeout = 2000;
											this.method_0("ATZ");
											text7 = this.method_6();
											int num14 = GClass126.smethod_1();
											this.method_0(GClass107.smethod_3(90674));
											text7 = this.method_6();
											int num15 = GClass126.smethod_1();
											if (!text7.Contains("OK"))
											{
												flag8 = true;
											}
											this.method_0(GClass107.smethod_3(90692));
											text7 = this.method_6();
											if (!text7.Contains("OK"))
											{
												flag8 = true;
											}
											num8 = num15 - num14;
											GClass126.smethod_2(GClass107.smethod_3(90694) + num8.ToString() + " ms", 0);
										}
										flag4 = true;
										num7 = num9;
									}
									else if (text8.Contains("STN"))
									{
										this.method_0("VTI");
										text7 = this.method_6();
										if (flag10 = text7.Contains(GClass107.smethod_3(90704)))
										{
											GClass126.smethod_2(GClass107.smethod_3(90723), 0);
										}
										else
										{
											GClass126.smethod_2(GClass107.smethod_3(90725), 0);
										}
										flag9 = true;
										if (flag4)
										{
											flag7 = true;
										}
										if (flag2)
										{
											flag7 = true;
										}
										str2 = text8.Replace("STI", "").Replace(">", "").Replace("\r", "");
										this.method_0(GClass107.smethod_3(90769));
										text7 = this.method_6();
										int num16 = GClass126.smethod_1();
										this.method_0(GClass107.smethod_3(90777));
										text7 = this.method_6();
										int num17 = GClass126.smethod_1();
										this.method_0(GClass107.smethod_3(90783));
										text7 = this.method_6();
										num8 = num17 - num16;
										GClass126.smethod_2(GClass107.smethod_3(90795) + num8.ToString() + " ms", 0);
										flag4 = true;
										num7 = num9;
									}
									else if (text7.Contains(GClass107.smethod_3(90833)))
									{
										GClass126.smethod_2(GClass107.smethod_3(90845), 0);
										if (flag5)
										{
											flag7 = true;
										}
										if (flag2)
										{
											flag7 = true;
										}
										flag5 = true;
										num7 = num9;
									}
									else if (text7.Contains(GClass107.smethod_3(90871)))
									{
										GClass126.smethod_2(GClass107.smethod_3(90889), 0);
										if (flag6)
										{
											flag7 = true;
										}
										if (flag2)
										{
											flag7 = true;
										}
										flag6 = true;
										num7 = num9;
									}
								}
								catch (Exception ex3)
								{
									GClass126.smethod_2(GClass107.smethod_3(90897) + ex3.Message, 0);
								}
								IL_DD6:;
							}
							catch (Exception ex4)
							{
								GClass126.smethod_2(GClass107.smethod_3(90925) + ex4.Message, 0);
							}
							goto IL_FC9;
						}
						finally
						{
							if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
							{
								try
								{
									this.serialPort_0.Close();
									GClass126.smethod_2(GClass107.smethod_3(90953), 0);
								}
								catch (Exception ex5)
								{
									GClass126.smethod_2(GClass107.smethod_3(90973) + ex5.Message, 0);
								}
								GClass126.smethod_2(" ", 0);
							}
						}
						break;
					}
					IL_FC9:;
				}
				if (flag4 || flag5)
				{
					int num18 = flag5 ? 4 : 2;
					if (flag7)
					{
						num18++;
					}
					if (flag9)
					{
						num18 = 7;
					}
					if (flag10)
					{
						num18 = 15;
					}
					if (flag11 && !flag7)
					{
						num18 = 2;
					}
					if (num18 == 7)
					{
						this.method_1(string.Format(GClass121.smethod_6("1098"), GClass125.string_1[num18] + " / " + str2, text5, num7));
					}
					else
					{
						this.method_1(string.Format(GClass121.smethod_6("1098"), GClass125.string_1[num18], text5, num7));
					}
					if (flag4 && !flag9)
					{
						if (flag8)
						{
							this.method_1(GClass121.smethod_6("1200"));
						}
						if (num8 > 20)
						{
							this.method_1(GClass121.smethod_6("1060"));
						}
					}
					this.method_1("");
					if (!GClass126.bool_10)
					{
						this.list_0.Add(num18);
						this.list_1.Add(text5);
						this.list_2.Add(num7);
					}
				}
				else if (flag6)
				{
					this.method_1(string.Format(GClass121.smethod_6("1098"), GClass125.string_1[6], text5, num7));
					this.method_1("");
					if (GClass126.bool_10)
					{
						this.list_0.Add(6);
						this.list_1.Add(text5);
						this.list_2.Add(num7);
					}
				}
			}
		}
		catch (Exception ex6)
		{
			this.string_0 = this.string_0 + ex6.Message + Environment.NewLine;
			this.bool_0 = false;
		}
		this.method_1(GClass121.smethod_6("6051"));
		this.string_1 = GClass121.smethod_6("6051");
		this.int_0 = 9999;
		this.bool_2 = true;
	}

	// Token: 0x060004B8 RID: 1208 RVA: 0x000A8C94 File Offset: 0x000A6E94
	private void method_5()
	{
		try
		{
			this.method_1(GClass107.smethod_3(88573));
			this.method_1(GClass121.smethod_6("1099"));
			this.method_1("");
			try
			{
				ManagementObjectCollection managementObjectCollection;
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(GClass107.smethod_3(88606)))
				{
					managementObjectCollection = managementObjectSearcher.Get();
				}
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator())
				{
					IL_145:
					while (enumerator.MoveNext())
					{
						ManagementBaseObject managementBaseObject = enumerator.Current;
						string text = (string)managementBaseObject.GetPropertyValue(GClass107.smethod_3(88653));
						string text2 = text.Substring(text.LastIndexOf(GClass107.smethod_3(88688))).Replace("(", string.Empty).Replace(")", string.Empty);
						GClass126.smethod_2(GClass107.smethod_3(88692) + text + ",   " + (string)managementBaseObject.GetPropertyValue(GClass107.smethod_3(88714)), 0);
						for (int i = 500; i > 0; i--)
						{
							if (text2.Contains("COM" + i.ToString()))
							{
								text2 = "COM" + i.ToString();
								IL_12B:
								this.list_3.Add(text2);
								this.list_4.Add(text);
								goto IL_145;
							}
						}
						goto IL_12B;
					}
				}
				managementObjectCollection.Dispose();
			}
			catch (Exception)
			{
			}
			GClass126.smethod_2(GClass107.smethod_3(88737), 0);
			int j = 500;
			IL_235:
			while (j > 0)
			{
				for (int k = 0; k < this.list_3.Count; k++)
				{
					if (this.list_3[k].StartsWith("COM" + j.ToString()))
					{
						this.list_5.Add("COM" + j.ToString());
						this.list_6.Add(this.list_4[k]);
						this.list_3[k] = "";
						GClass126.smethod_2(GClass107.smethod_3(88765) + this.list_4[k], 0);
						IL_22F:
						j--;
						goto IL_235;
					}
				}
				goto IL_22F;
			}
			this.int_1 = this.list_5.Count * this.int_2.Length + 1;
			string text3 = "";
			for (int l = this.list_5.Count - 1; l >= 0; l--)
			{
				text3 = this.list_5[l];
				string text4 = this.list_6[l];
				bool flag = text4.ToLower().Contains(GClass107.smethod_3(88785));
				GClass126.smethod_2(string.Concat(new string[]
				{
					GClass107.smethod_3(88820),
					text3,
					" (",
					text4,
					GClass107.smethod_3(88867)
				}), 0);
				this.string_1 = string.Format(GClass121.smethod_6("1096"), text4);
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = true;
				bool flag8 = true;
				bool flag9 = false;
				bool flag10 = false;
				int num = 0;
				int num2 = 0;
				for (int m = 0; m < this.int_2.Length; m++)
				{
					int num3 = this.int_2[m];
					this.int_0++;
					if (this.bool_1)
					{
						this.bool_2 = true;
						return;
					}
					if ((!GClass126.bool_10 || num3 == 115200) && !flag2 && (m != 3 || (!flag3 && !flag4 && !flag5)))
					{
						Thread.Sleep(100);
						if (flag3 || flag4 || flag5)
						{
							if (flag6)
							{
								goto IL_A6F;
							}
							for (int n = 0; n < 50; n++)
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
								GClass126.smethod_2(GClass107.smethod_3(88913) + num3.ToString() + GClass107.smethod_3(88922), 0);
								this.serialPort_0 = new SerialPort(text3, num3, Parity.None, 8, StopBits.One);
								this.serialPort_0.WriteBufferSize = 2;
								this.serialPort_0.WriteTimeout = 1000;
								this.serialPort_0.ReceivedBytesThreshold = 1000;
								this.serialPort_0.Handshake = Handshake.None;
								this.serialPort_0.NewLine = GClass107.smethod_3(88930);
								flag2 = true;
								this.serialPort_0.Open();
								flag2 = false;
								GClass126.smethod_2(GClass107.smethod_3(88959), 0);
								if (m == 3 && !flag3 && !flag4 && !flag5)
								{
									try
									{
										this.serialPort_0.ReadTimeout = 50;
										int num4 = GClass126.smethod_1();
										this.serialPort_0.Write(new byte[1], 0, 1);
										byte b = (byte)this.serialPort_0.ReadByte();
										this.serialPort_0.Write(new byte[]
										{
											165
										}, 0, 1);
										byte b2 = (byte)this.serialPort_0.ReadByte();
										int num5 = GClass126.smethod_1();
										byte b3 = 55;
										this.serialPort_0.BreakState = true;
										this.serialPort_0.RtsEnable = true;
										for (int num6 = 1; num6 < 10; num6++)
										{
											b3 += 1;
										}
										this.serialPort_0.BreakState = false;
										this.serialPort_0.RtsEnable = false;
										b3 = 55;
										try
										{
											b3 = (byte)this.serialPort_0.ReadByte();
										}
										catch (Exception)
										{
										}
										GClass126.smethod_2(GClass107.smethod_3(89004) + GClass127.smethod_23(b3), 0);
										this.serialPort_0.BreakState = false;
										this.serialPort_0.RtsEnable = false;
										if (b == 0 && b2 == 165)
										{
											if (b3 != 55)
											{
												GClass126.smethod_2(GClass107.smethod_3(89046) + ((num5 - num4) / 2).ToString() + " ms", 0);
												this.method_1(string.Format(GClass121.smethod_6("1097"), text3));
												if ((num5 - num4) / 2 > 15)
												{
													this.method_1(GClass121.smethod_6("1060"));
												}
												if (!GClass126.bool_10)
												{
													this.list_0.Add(1);
													this.list_1.Add(text3);
													this.list_2.Add(9600);
												}
												flag2 = true;
												goto IL_A6F;
											}
										}
										throw new Exception(GClass107.smethod_3(89041));
									}
									catch (Exception ex)
									{
										GClass126.smethod_2(ex.Message, 0);
										GClass126.smethod_2(GClass107.smethod_3(89077), 0);
										goto IL_88D;
									}
								}
								try
								{
									this.serialPort_0.NewLine = "\r";
									this.serialPort_0.ReadTimeout = 1000;
									this.method_0("");
									this.method_6();
									Thread.Sleep(50);
									this.method_0("ATI");
									string text5 = this.method_6();
									if (text5.Contains(GClass107.smethod_3(89122)))
									{
										GClass126.smethod_2(GClass107.smethod_3(89151), 0);
										if (flag3)
										{
											flag6 = true;
										}
										if (flag)
										{
											flag6 = true;
										}
										if (!flag3)
										{
											this.method_0("ATZ");
											text5 = this.method_6();
											this.method_0(GClass107.smethod_3(89185));
											text5 = this.method_6();
											if (text5.Contains(GClass107.smethod_3(89218)))
											{
												flag9 = true;
											}
											int num7 = GClass126.smethod_1();
											this.method_0(GClass107.smethod_3(89236));
											text5 = this.method_6();
											int num8 = GClass126.smethod_1();
											if (!text5.Contains("OK"))
											{
												flag7 = false;
											}
											this.method_0(GClass107.smethod_3(89238));
											text5 = this.method_6();
											if (!text5.Contains("OK"))
											{
												flag8 = false;
											}
											num2 = num8 - num7;
											GClass126.smethod_2(GClass107.smethod_3(89274) + num2.ToString() + " ms", 0);
										}
										flag3 = true;
										num = num3;
									}
									else if (text5.Contains(GClass107.smethod_3(89300)))
									{
										GClass126.smethod_2(GClass107.smethod_3(89314), 0);
										flag10 = true;
										if (flag3)
										{
											flag6 = true;
										}
										if (flag)
										{
											flag6 = true;
										}
										flag3 = true;
										num = num3;
									}
									else if (text5.Contains(GClass107.smethod_3(89360)))
									{
										GClass126.smethod_2(GClass107.smethod_3(89363), 0);
										if (flag4)
										{
											flag6 = true;
										}
										if (flag)
										{
											flag6 = true;
										}
										flag4 = true;
										num = num3;
									}
									else if (text5.Contains(GClass107.smethod_3(89412)))
									{
										GClass126.smethod_2(GClass107.smethod_3(89460), 0);
										if (flag5)
										{
											flag6 = true;
										}
										if (flag)
										{
											flag6 = true;
										}
										flag5 = true;
										num = num3;
									}
								}
								catch (Exception ex2)
								{
									GClass126.smethod_2(GClass107.smethod_3(89492) + ex2.Message, 0);
								}
								IL_88D:;
							}
							catch (Exception ex3)
							{
								GClass126.smethod_2(GClass107.smethod_3(89538) + ex3.Message, 0);
							}
							goto IL_A6F;
						}
						finally
						{
							if (this.serialPort_0 != null && this.serialPort_0.IsOpen)
							{
								try
								{
									this.serialPort_0.Close();
									GClass126.smethod_2(GClass107.smethod_3(89576), 0);
								}
								catch (Exception ex4)
								{
									GClass126.smethod_2(GClass107.smethod_3(89584) + ex4.Message, 0);
								}
								GClass126.smethod_2(" ", 0);
							}
						}
						break;
					}
					IL_A6F:;
				}
				if (flag3 || flag4)
				{
					int num9 = flag4 ? 4 : 2;
					if (flag6)
					{
						num9++;
					}
					if (flag9)
					{
						num9 = 7;
					}
					if (flag10 && !flag6)
					{
						num9 = 8;
					}
					this.method_1(string.Format(GClass121.smethod_6("1098"), GClass125.string_1[num9], text3, num));
					if (flag3 && !flag9)
					{
						if (flag7 && flag8)
						{
							this.method_1(GClass121.smethod_6("1202"));
						}
						else if (flag7)
						{
							this.method_1(GClass121.smethod_6("1201"));
						}
						else
						{
							this.method_1(GClass121.smethod_6("1200"));
						}
						if (!flag6 && num2 > 13)
						{
							this.method_1(GClass121.smethod_6("1060"));
						}
					}
					this.method_1("");
					if (!GClass126.bool_10)
					{
						this.list_0.Add(num9);
						this.list_1.Add(text3);
						this.list_2.Add(num);
					}
				}
				else if (flag5)
				{
					this.method_1(string.Format(GClass121.smethod_6("1098"), GClass125.string_1[6], text3, num));
					this.method_1("");
					if (GClass126.bool_10)
					{
						this.list_0.Add(6);
						this.list_1.Add(text3);
						this.list_2.Add(num);
					}
				}
			}
		}
		catch (Exception ex5)
		{
			this.string_0 = this.string_0 + ex5.Message + Environment.NewLine;
			this.bool_0 = false;
		}
		this.method_1(GClass121.smethod_6("6051"));
		this.string_1 = GClass121.smethod_6("6051");
		this.int_0 = 9999;
		this.bool_2 = true;
	}

	// Token: 0x060004B9 RID: 1209 RVA: 0x00003CD8 File Offset: 0x00001ED8
	private void button_1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x000A9880 File Offset: 0x000A7A80
	private string method_6()
	{
		string text = "";
		byte b = 32;
		while (b != 62 && b != 0 && text.Length < 200)
		{
			b = (byte)this.serialPort_0.ReadByte();
			if (b != 0)
			{
				string str = text;
				char c = (char)b;
				text = str + c.ToString();
			}
		}
		GClass126.smethod_2(GClass107.smethod_3(91169) + text, 0);
		return text;
	}

	// Token: 0x060004BB RID: 1211 RVA: 0x000A98E8 File Offset: 0x000A7AE8
	private string method_7()
	{
		string text = "";
		long num = (long)(GClass126.smethod_1() + 2500);
		while (!text.EndsWith(">") && text.Length < 200 && num > (long)GClass126.smethod_1())
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
		GClass126.smethod_2(GClass107.smethod_3(91197) + text, 0);
		return text;
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x000A9994 File Offset: 0x000A7B94
	private void method_8()
	{
		this.icontainer_0 = new Container();
		this.textBox_0 = new TextBox();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.progressBar_0 = new ProgressBar();
		this.label_0 = new Label();
		this.button_0 = new Button();
		this.button_1 = new Button();
		base.SuspendLayout();
		this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_0.Location = new Point(17, 19);
		this.textBox_0.Margin = new Padding(3, 4, 3, 4);
		this.textBox_0.Multiline = true;
		this.textBox_0.Name = GClass107.smethod_3(91344);
		this.textBox_0.ScrollBars = ScrollBars.Vertical;
		this.textBox_0.Size = new Size(738, 460);
		this.textBox_0.TabIndex = 0;
		this.timer_0.Enabled = true;
		this.timer_0.Interval = 300;
		this.timer_0.Tick += this.timer_0_Tick;
		this.progressBar_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.progressBar_0.Location = new Point(17, 505);
		this.progressBar_0.Margin = new Padding(3, 4, 3, 4);
		this.progressBar_0.Name = GClass107.smethod_3(91392);
		this.progressBar_0.Size = new Size(486, 25);
		this.progressBar_0.TabIndex = 12;
		this.label_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(17, 480);
		this.label_0.Name = GClass107.smethod_3(91393);
		this.label_0.Size = new Size(21, 20);
		this.label_0.TabIndex = 14;
		this.label_0.Text = "...";
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Location = new Point(510, 500);
		this.button_0.Margin = new Padding(3, 4, 3, 4);
		this.button_0.Name = GClass107.smethod_3(91414);
		this.button_0.Size = new Size(119, 34);
		this.button_0.TabIndex = 17;
		this.button_0.Tag = "8198";
		this.button_0.Text = GClass107.smethod_3(91433);
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.OK;
		this.button_1.Location = new Point(636, 500);
		this.button_1.Margin = new Padding(3, 4, 3, 4);
		this.button_1.Name = GClass107.smethod_3(91457);
		this.button_1.Size = new Size(119, 34);
		this.button_1.TabIndex = 16;
		this.button_1.Tag = "8199";
		this.button_1.Text = "OK";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		base.AcceptButton = this.button_1;
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(769, 548);
		base.ControlBox = false;
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.progressBar_0);
		base.Controls.Add(this.textBox_0);
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = GClass107.smethod_3(91490);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		this.Text = GClass107.smethod_3(91512);
		base.FormClosing += this.GForm6_FormClosing;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000345 RID: 837
	private SerialPort serialPort_0;

	// Token: 0x04000346 RID: 838
	protected TcpClient tcpClient_0;

	// Token: 0x04000347 RID: 839
	private string string_0 = "";

	// Token: 0x04000348 RID: 840
	private bool bool_0;

	// Token: 0x04000349 RID: 841
	private int int_0;

	// Token: 0x0400034A RID: 842
	private int int_1 = 1;

	// Token: 0x0400034B RID: 843
	private bool bool_1;

	// Token: 0x0400034C RID: 844
	private bool bool_2;

	// Token: 0x0400034D RID: 845
	private string string_1 = "";

	// Token: 0x0400034E RID: 846
	public List<int> list_0 = new List<int>();

	// Token: 0x0400034F RID: 847
	public List<string> list_1 = new List<string>();

	// Token: 0x04000350 RID: 848
	public List<int> list_2 = new List<int>();

	// Token: 0x04000351 RID: 849
	private int[] int_2 = new int[]
	{
		9600,
		38400,
		115200,
		10400
	};

	// Token: 0x04000352 RID: 850
	private List<string> list_3 = new List<string>();

	// Token: 0x04000353 RID: 851
	private List<string> list_4 = new List<string>();

	// Token: 0x04000354 RID: 852
	private List<string> list_5 = new List<string>();

	// Token: 0x04000355 RID: 853
	private List<string> list_6 = new List<string>();

	// Token: 0x04000357 RID: 855
	private TextBox textBox_0;

	// Token: 0x04000358 RID: 856
	private System.Windows.Forms.Timer timer_0;

	// Token: 0x04000359 RID: 857
	private ProgressBar progressBar_0;

	// Token: 0x0400035A RID: 858
	private Label label_0;

	// Token: 0x0400035B RID: 859
	private Button button_0;

	// Token: 0x0400035C RID: 860
	private Button button_1;
}
