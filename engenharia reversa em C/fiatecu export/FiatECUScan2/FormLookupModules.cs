using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

// Token: 0x02000002 RID: 2
public sealed partial class FormLookupModules : Form
{
	// Token: 0x06000001 RID: 1 RVA: 0x00003AF4 File Offset: 0x00001CF4
	public FormLookupModules(bool bool_5)
	{
		this.InitializeComponent();
		this.bool_4 = bool_5;
		this.dataTable_0.Columns.Add("CategoryDesc", typeof(string));
		this.dataTable_0.Columns.Add("Protocol", typeof(string));
		this.dataTable_0.Columns.Add("ECUAddress", typeof(byte));
		this.dataTable_0.Columns.Add("CANAddress", typeof(string));
		this.dataTable_0.Columns.Add("PIN", typeof(string));
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1101"),
			"KWP2000Fast",
			16,
			string.Empty,
			"70"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1101"),
			"KWP2000Fast",
			10,
			string.Empty,
			"70"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1101"),
			"CCAN29",
			16,
			string.Empty,
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1102"),
			"KWP2000Fast",
			32,
			string.Empty,
			"10"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1102"),
			"CCAN29",
			40,
			string.Empty,
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1104"),
			"KWP2000Fast",
			233,
			string.Empty,
			"90"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1104"),
			"KWP2000Fast",
			233,
			string.Empty,
			"C0"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1104"),
			"BCAN",
			233,
			"7C2",
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1104"),
			"CCAN29",
			48,
			string.Empty,
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1103"),
			"BCAN",
			1,
			"7DA",
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1103"),
			"BCAN29",
			192,
			string.Empty,
			"19"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1105"),
			"KWP2000Fast",
			2,
			string.Empty,
			"70"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1105"),
			"CCAN29",
			24,
			string.Empty,
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1107"),
			"BCAN",
			4,
			"7C0",
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1107"),
			"BCAN29",
			64,
			string.Empty,
			"19"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1106"),
			"BCAN",
			133,
			"7C3",
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1106"),
			"BCAN",
			157,
			"7C7",
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1106"),
			"BCAN29",
			96,
			string.Empty,
			"19"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1106"),
			"BCAN29",
			97,
			string.Empty,
			"19"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1110"),
			"KWP2000Fast",
			8,
			string.Empty,
			"90"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1110"),
			"BCAN",
			8,
			"7CA",
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1110"),
			"BCAN29",
			152,
			string.Empty,
			"19"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1109"),
			"KWP2000Fast",
			25,
			string.Empty,
			"C0"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1109"),
			"KWP2000Fast",
			41,
			string.Empty,
			"C0"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1109"),
			"KWP2000Fast",
			59,
			string.Empty,
			"D0"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1109"),
			"KWP2000Fast",
			155,
			string.Empty,
			"D0"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1109"),
			"KWP2000Fast",
			176,
			string.Empty,
			"D0"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1111"),
			"BCAN",
			14,
			"7C8",
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1111"),
			"BCAN",
			13,
			"7D1",
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1111"),
			"BCAN",
			138,
			"7C9",
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1111"),
			"BCAN",
			134,
			"7D8",
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1111"),
			"BCAN",
			157,
			"7C7",
			"6E"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1111"),
			"BCAN29",
			160,
			string.Empty,
			"19"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1111"),
			"KWP2000Fast",
			157,
			string.Empty,
			"90"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1106"),
			"ISO9141",
			133,
			string.Empty,
			"70"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1110"),
			"ISO9141",
			8,
			string.Empty,
			"70"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1103"),
			"ISO9141",
			0,
			string.Empty,
			"30"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1103"),
			"ISO9141",
			0,
			string.Empty,
			"70"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1103"),
			"KW01",
			0,
			string.Empty,
			"30"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1103"),
			"KW01",
			0,
			string.Empty,
			"70"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1101"),
			"KWP71",
			16,
			string.Empty,
			"70"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1102"),
			"KWP71",
			32,
			string.Empty,
			"10"
		});
		this.dataTable_0.Rows.Add(new object[]
		{
			GClass62.smethod_1("1102"),
			"KWP71",
			32,
			string.Empty,
			"70"
		});
		this.progressBar1.Maximum = this.dataTable_0.Rows.Count;
		this.progressBar1.Value = 0;
		new Thread(new ThreadStart(this.method_0)).Start();
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00004874 File Offset: 0x00002A74
	private void method_0()
	{
		GClass3.smethod_2(GClass62.smethod_1("1099"), 2);
		this.string_0 = this.string_0 + GClass62.smethod_1("1099") + Environment.NewLine + Environment.NewLine;
		this.bool_0 = false;
		GClass55.smethod_5("KWP2000Fast");
		bool flag;
		if (GClass61.smethod_36() != 4)
		{
			if (GClass61.smethod_36() != 5)
			{
				flag = true;
				goto IL_61;
			}
		}
		flag = GClass3.bool_0;
		IL_61:
		if (!flag)
		{
			if (GClass61.smethod_36() == 5)
			{
				for (int i = 0; i < 30; i++)
				{
					if (this.bool_1)
					{
						this.bool_2 = true;
						return;
					}
					Thread.Sleep(100);
				}
			}
			if (!GClass55.smethod_3())
			{
				GClass3.bool_13 = false;
				this.bool_3 = true;
				int i = 1200;
				while (!GClass3.bool_13 && i > 0 && !this.bool_1)
				{
					i--;
					Thread.Sleep(100);
				}
				if (i == 0 || this.bool_1)
				{
					return;
				}
				GClass3.bool_13 = false;
				GClass55.smethod_1(true);
				int num = 10;
				if (GClass61.smethod_36() == 5)
				{
					num = 40;
				}
				for (int j = 0; j < num; j++)
				{
					if (this.bool_1)
					{
						this.bool_2 = true;
						return;
					}
					Thread.Sleep(100);
				}
			}
		}
		for (int j = 0; j < 5; j++)
		{
			if (this.bool_1)
			{
				this.bool_2 = true;
				return;
			}
			Thread.Sleep(100);
		}
		GClass2 gclass = new GClass2();
		int num2 = 0;
		byte b = 0;
		string b2 = string.Empty;
		string b3 = string.Empty;
		for (int k = 0; k < this.dataTable_0.Rows.Count; k++)
		{
			if (this.bool_1)
			{
				this.bool_2 = true;
				return;
			}
			this.int_0 = k;
			byte b4 = (byte)this.dataTable_0.Rows[k]["ECUAddress"];
			string text = (string)this.dataTable_0.Rows[k]["Protocol"];
			string string_ = (string)this.dataTable_0.Rows[k]["CANAddress"];
			string text2 = (string)this.dataTable_0.Rows[k]["CategoryDesc"];
			string string_2 = (string)this.dataTable_0.Rows[k]["PIN"];
			if (b4 != b || !(text == b2) || !(text2 == b3) || GClass61.smethod_36() == 6)
			{
				b = b4;
				b2 = text;
				b3 = text2;
				if ((num2 != 1 || !text.Contains("CAN29")) && (GClass61.smethod_36() == 6 || ((num2 != 2 || !text.Contains("CCAN29")) && (num2 != 3 || !text.Contains("BCAN29")))) && (num2 <= 1 || text.Contains("CAN29") || b4 == 41 || b4 == 25))
				{
					GClass3.bool_0 = false;
					List<GClass58> list = new List<GClass58>();
					List<GClass58> list_ = new List<GClass58>();
					GClass58 gclass2 = new GClass58();
					gclass2.byte_0 = new byte[][]
					{
						new byte[]
						{
							2,
							26,
							151
						}
					};
					if (text.Contains("CAN29"))
					{
						gclass2.byte_0 = new byte[][]
						{
							new byte[]
							{
								3,
								34,
								241,
								165
							}
						};
					}
					gclass2.int_0 = 1;
					gclass2.int_1 = 5;
					gclass2.string_0 = "ISO Code";
					gclass2.string_2 = "hex";
					gclass2.string_3 = string.Empty;
					gclass2.string_4 = string.Empty;
					gclass2.string_5 = new string[]
					{
						string.Empty
					};
					gclass2.string_1 = string.Empty;
					gclass2.int_2 = 1770;
					list.Add(gclass2);
					GClass19 gclass3 = GClass19.smethod_0(text, string_, b4, list, list_, string_2);
					if (gclass3 != null)
					{
						if (this.bool_1)
						{
							this.bool_2 = true;
							return;
						}
						if (text == "KWP2000Fast" || text == "ISO9141" || text == "KWP71" || text == "KW01")
						{
							for (int l = 0; l < 20; l++)
							{
								Thread.Sleep(100);
								if (this.bool_1)
								{
									this.bool_2 = true;
									return;
								}
							}
						}
						if (GClass61.smethod_38())
						{
							for (int j = 0; j < 20; j++)
							{
								if (this.bool_1)
								{
									this.bool_2 = true;
									return;
								}
								Thread.Sleep(100);
							}
						}
						if (this.bool_4)
						{
							gclass3.method_25();
						}
						else
						{
							gclass3.method_24();
						}
						if (this.bool_1)
						{
							this.bool_2 = true;
							return;
						}
						if (gclass3.method_4() != string.Empty)
						{
							string text3 = "UNKNOWN/UNSUPPORTED";
							string text4 = string.Empty;
							DataRow[] array = gclass.dataTable_4.Select("ISOCode='" + gclass3.method_4() + "'");
							if (array.Length > 0)
							{
								int num3 = (int)array[0]["SystemID2"];
								array = gclass.dataTable_3.Select("SystemID2=" + num3);
								if (array.Length > 0)
								{
									text3 = (string)array[0]["SystemDesc"];
									text4 = (string)array[0]["ModuleID"];
								}
							}
							string text5 = this.string_0;
							this.string_0 = string.Concat(new string[]
							{
								text5,
								text2,
								Environment.NewLine,
								text3,
								Environment.NewLine,
								"ISO Code: ",
								gclass3.method_4(),
								Environment.NewLine
							});
							this.bool_0 = false;
							GClass3.smethod_2(text2, 2);
							GClass3.smethod_2(text3, 2);
							GClass3.smethod_2("ISO Code: " + gclass3.method_4(), 2);
							if (this.bool_4 && gclass3.method_5() != null && gclass3.method_5().Count > 0)
							{
								List<GClass64> list2 = new List<GClass64>();
								GClass52 gclass4 = new GClass52(text4);
								GClass64 gclass5 = new GClass64();
								DataView dataView = new DataView(gclass4.dataTable_0);
								foreach (object obj in dataView)
								{
									DataRowView dataRowView = (DataRowView)obj;
									list2.Add(new GClass64
									{
										string_0 = GClass16.smethod_3(dataRowView["ErrorCode"]),
										string_1 = GClass16.smethod_3(dataRowView["Error"]),
										int_0 = GClass16.smethod_5(dataRowView["MessageID"])
									});
								}
								GClass3.smethod_2("Errors found: ", 2);
								this.string_0 = this.string_0 + "Errors found: " + Environment.NewLine;
								foreach (GClass64 gclass6 in gclass3.method_5())
								{
									foreach (GClass64 gclass7 in list2)
									{
										if (gclass7.string_0 == gclass6.string_0)
										{
											if (gclass6.string_1 != string.Empty)
											{
												GClass64 gclass8 = gclass6;
												gclass8.string_1 += " - ";
											}
											GClass64 gclass9 = gclass6;
											gclass9.string_1 += GClass62.smethod_4(gclass7.int_0, gclass7.string_1);
											break;
										}
									}
									GClass3.smethod_2(gclass6.string_1, 2);
									this.string_0 = this.string_0 + gclass6.string_1 + Environment.NewLine;
								}
							}
							this.string_0 += Environment.NewLine;
							this.bool_0 = false;
							if (text.Contains("BCAN29"))
							{
								num2 = 2;
							}
							if (text.Contains("CCAN29"))
							{
								num2 = 3;
							}
							else if (num2 == 0)
							{
								num2 = 1;
							}
						}
					}
				}
			}
		}
		this.string_0 = this.string_0 + GClass62.smethod_1("6051") + Environment.NewLine;
		this.bool_0 = false;
		this.int_0++;
		this.bool_2 = true;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000051D8 File Offset: 0x000033D8
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (this.bool_3)
		{
			this.bool_3 = false;
			new FormNotify(GClass62.smethod_1("1070"), GClass62.smethod_1("1074"), GClass62.smethod_1("1075"), true, 120000).ShowDialog();
		}
		if (!this.bool_0)
		{
			this.bool_0 = true;
			this.textBox1.Text = this.string_0;
			this.textBox1.SelectionStart = this.textBox1.Text.Length;
			this.textBox1.ScrollToCaret();
		}
		if (this.progressBar1.Value < this.int_0)
		{
			this.progressBar1.Value = this.int_0;
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00005298 File Offset: 0x00003498
	private void FormLookupModules_FormClosing(object sender, FormClosingEventArgs e)
	{
		this.bool_1 = true;
		int num = 50;
		while (num > 0 && !this.bool_2)
		{
			Thread.Sleep(100);
			num--;
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x000026DC File Offset: 0x000008DC
	private void buttonDisconnect_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x04000001 RID: 1
	private string string_0 = string.Empty;

	// Token: 0x04000002 RID: 2
	private bool bool_0 = true;

	// Token: 0x04000003 RID: 3
	private DataTable dataTable_0 = new DataTable();

	// Token: 0x04000004 RID: 4
	private bool bool_1 = false;

	// Token: 0x04000005 RID: 5
	private bool bool_2 = false;

	// Token: 0x04000006 RID: 6
	private bool bool_3 = false;

	// Token: 0x04000007 RID: 7
	private int int_0 = 0;

	// Token: 0x04000008 RID: 8
	private bool bool_4 = false;
}
