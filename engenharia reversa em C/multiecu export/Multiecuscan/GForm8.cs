using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Multiecuscan;
using PdfSharp.Pdf;

// Token: 0x0200009E RID: 158
public partial class GForm8 : Form
{
	// Token: 0x060004DD RID: 1245 RVA: 0x000B2654 File Offset: 0x000B0854
	private void method_0(object sender, EventArgs e)
	{
		try
		{
			base.Invoke(new GForm8.Delegate4(this.method_20), new object[0]);
		}
		catch (Exception)
		{
			GClass126.smethod_2(GClass107.smethod_3(119353), 0);
		}
	}

	// Token: 0x060004DE RID: 1246 RVA: 0x000B26A0 File Offset: 0x000B08A0
	private void method_1()
	{
		try
		{
			string text = string.Concat(new string[]
			{
				GClass107.smethod_3(114672),
				DateTime.Now.ToString(GClass107.smethod_3(114721)),
				"_",
				GClass126.string_7,
				GClass107.smethod_3(114769)
			});
			text = text.Replace("/", "").Replace("\\", "");
			FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(GClass107.smethod_3(114807) + text);
			ftpWebRequest.Method = "STOR";
			ftpWebRequest.Credentials = new NetworkCredential(GClass107.smethod_3(114856), GClass107.smethod_3(114856));
			Stream requestStream = ftpWebRequest.GetRequestStream();
			try
			{
				byte[] bytes = Encoding.Unicode.GetBytes(GClass126.smethod_7());
				requestStream.Write(bytes, 0, bytes.Length);
			}
			finally
			{
				requestStream.Close();
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(GClass107.smethod_3(114917) + ex.Message, 0);
		}
	}

	// Token: 0x060004DF RID: 1247 RVA: 0x00003DC7 File Offset: 0x00001FC7
	private void method_2()
	{
		if (!GClass126.bool_17)
		{
			this.method_44();
		}
	}

	// Token: 0x060004E0 RID: 1248 RVA: 0x000B27CC File Offset: 0x000B09CC
	private void dataGridView_5_SelectionChanged(object sender, EventArgs e)
	{
		string str = "-1";
		if (this.dataGridView_5.SelectedRows.Count > 0)
		{
			str = (string)this.dataGridView_5.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_5.Name].Value;
			int num = (int)this.dataGridView_5.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_3.Name].Value;
		}
		DataView dataView = (DataView)this.dataGridView_7.DataSource;
		if (dataView == null)
		{
			return;
		}
		dataView.RowFilter = GClass107.smethod_3(111705) + str + ")";
		this.dataGridView_7.DataSource = dataView;
		this.dataGridView_7_SelectionChanged(null, null);
	}

	// Token: 0x060004E1 RID: 1249 RVA: 0x00003DD6 File Offset: 0x00001FD6
	private string method_3()
	{
		return Application.ExecutablePath;
	}

	// Token: 0x060004E2 RID: 1250 RVA: 0x00003DDD File Offset: 0x00001FDD
	private void method_4()
	{
		if (!GClass126.bool_12)
		{
			return;
		}
		GClass126.bool_12 = false;
		if (GClass126.bool_13)
		{
			this.method_46("");
		}
		this.method_18(true, true);
	}

	// Token: 0x060004E3 RID: 1251 RVA: 0x000B2898 File Offset: 0x000B0A98
	private void button_21_Click(object sender, EventArgs e)
	{
		if (!GClass126.bool_13)
		{
			return;
		}
		for (int i = 0; i < this.list_0.Count; i++)
		{
			this.list_0[i].bool_0 = false;
		}
		this.dataGridView_1.Focus();
		this.dataGridView_1.Refresh();
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x00003E07 File Offset: 0x00002007
	private void method_5()
	{
		GClass126.smethod_2(this.string_18, this.int_2[0]);
		MessageBox.Show(GClass121.string_2, GClass121.string_1, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		if (this.int_2[0] < 5)
		{
			base.Close();
		}
	}

	// Token: 0x060004E5 RID: 1253 RVA: 0x000B28EC File Offset: 0x000B0AEC
	private void button_2_Click(object sender, EventArgs e)
	{
		if (this.gform9_0 != null)
		{
			return;
		}
		if (this.gform10_0 != null)
		{
			return;
		}
		if (this.gform11_0 != null)
		{
			return;
		}
		if (this.dataGridView_2.SelectedRows.Count == 0)
		{
			return;
		}
		GClass104 dataItem = ((TableDataRowP)this.dataGridView_2.SelectedRows[0].DataBoundItem).getDataItem();
		if (dataItem.string_2.Contains(GClass107.smethod_3(115529)))
		{
			this.gform9_0 = new GForm9(GClass121.smethod_6("6050"), "", GClass121.smethod_6("1055"), true, 0);
			this.gform9_0.ShowDialog();
			if (this.gform9_0 == null)
			{
				return;
			}
			bool flag = this.gform9_0.method_1();
			this.gform9_0 = null;
			if (!flag)
			{
				return;
			}
		}
		GClass126.smethod_2(GClass121.smethod_6("6101"), 2);
		GClass126.smethod_2(dataItem.string_0, 2);
		string text = " ";
		if (!dataItem.string_2.Contains(GClass107.smethod_3(115537)) && dataItem.byte_0.Length > 1 && !dataItem.string_2.Contains(GClass107.smethod_3(115579)))
		{
			text = GClass121.smethod_6("6059");
		}
		if (this.gclass11_0 == null)
		{
			return;
		}
		this.gform9_0 = new GForm9(GClass121.smethod_6(dataItem.string_4), GClass121.smethod_6("1052"), text, false, 0);
		this.gclass11_0.method_27(dataItem);
		this.gform9_0.ShowDialog();
		this.gform9_0 = null;
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x000B2A68 File Offset: 0x000B0C68
	private void method_6(int int_3)
	{
		List<int> list = new List<int>();
		if (!GClass126.bool_13)
		{
			return;
		}
		for (int i = 0; i < this.list_0.Count; i++)
		{
			if (this.list_0[i].bool_0)
			{
				list.Add(this.list_0[i].int_2);
			}
		}
		GClass125.smethod_118(int_3, list.ToArray());
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x000B2AD0 File Offset: 0x000B0CD0
	private void dataGridView_3_SelectionChanged(object sender, EventArgs e)
	{
		if (this.dataGridView_3.SelectedRows.Count > 0)
		{
			this.textBox_6.Text = ((TableDataRowE)this.dataGridView_3.SelectedRows[0].DataBoundItem).getDataItem().Description;
			this.textBox_3.Text = ((TableDataRowE)this.dataGridView_3.SelectedRows[0].DataBoundItem).getDataItem().string_4;
			return;
		}
		this.textBox_6.Text = "";
		this.textBox_3.Text = "";
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x00003E40 File Offset: 0x00002040
	private void method_7(TabPage tabPage_8)
	{
		if (!this.tabControl_0.TabPages.Contains(tabPage_8) && tabPage_8 != this.tabPage_1)
		{
			this.tabControl_0.TabPages.Add(tabPage_8);
		}
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x000B2B74 File Offset: 0x000B0D74
	private void button_22_Click(object sender, EventArgs e)
	{
		if (!GClass126.bool_13)
		{
			return;
		}
		for (int i = 0; i < this.list_0.Count; i++)
		{
			this.list_0[i].bool_0 = true;
		}
		this.dataGridView_1.Focus();
		this.dataGridView_1.Refresh();
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x000B2BC8 File Offset: 0x000B0DC8
	private void dataGridView_2_SelectionChanged(object sender, EventArgs e)
	{
		if (this.dataGridView_2.SelectedRows.Count > 0)
		{
			this.textBox_2.Text = ((TableDataRowP)this.dataGridView_2.SelectedRows[0].DataBoundItem).getDataItem().string_1;
			this.button_3.Enabled = ((TableDataRowP)this.dataGridView_2.SelectedRows[0].DataBoundItem).getDataItem().string_2.Contains(GClass107.smethod_3(115484));
			this.button_3.Visible = ((TableDataRowP)this.dataGridView_2.SelectedRows[0].DataBoundItem).getDataItem().string_2.Contains(GClass107.smethod_3(115509));
			return;
		}
		this.textBox_2.Text = "";
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x000B2CAC File Offset: 0x000B0EAC
	private void method_8()
	{
		if (this.gform9_0 != null)
		{
			this.gform9_0.Close();
		}
		if (this.gform10_0 != null)
		{
			this.gform10_0.Close();
		}
		if (this.gform11_0 != null)
		{
			this.gform11_0.Close();
		}
		this.gform9_0 = null;
		this.gform10_0 = null;
		this.gform11_0 = null;
	}

	// Token: 0x060004EC RID: 1260 RVA: 0x000B2D08 File Offset: 0x000B0F08
	private void method_9()
	{
		if (this.gclass11_0 == null)
		{
			return;
		}
		if (!this.gclass11_0.method_18())
		{
			return;
		}
		if (this.bool_2)
		{
			return;
		}
		this.bool_2 = true;
		if (this.list_8 == null)
		{
			this.string_12 = "";
		}
		try
		{
			List<GClass102> list = this.gclass11_0.r1();
			if (list == null)
			{
				GClass126.smethod_2(GClass107.smethod_3(114934), 0);
			}
			string text = "";
			if (list != null)
			{
				foreach (GClass102 gclass in list)
				{
					text += gclass.string_0;
				}
			}
			if ((this.string_12 != text || this.string_12 == "") && this.gclass11_0 != null && list != null)
			{
				this.gclass11_0.r7(list, this.list_5);
			}
			if (list != null)
			{
				this.list_8 = list;
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(GClass107.smethod_3(114964) + ex.Message + GClass107.smethod_3(115013) + ex.StackTrace, 0);
		}
		finally
		{
			this.bool_2 = false;
		}
	}

	// Token: 0x060004ED RID: 1261 RVA: 0x00003E6F File Offset: 0x0000206F
	private void button_24_Click(object sender, EventArgs e)
	{
		GClass126.bool_0 = true;
		if (this.button_6.Enabled)
		{
			this.button_6_Click(null, null);
		}
	}

	// Token: 0x060004EE RID: 1262 RVA: 0x000B2E5C File Offset: 0x000B105C
	private void button_29_Click(object sender, EventArgs e)
	{
		GClass126.smethod_2(GClass107.smethod_3(114642), 1);
		this.label_20.Text = GClass121.smethod_6("1206");
		this.label_20.ForeColor = Color.Red;
		if (this.gclass11_0 != null)
		{
			this.gclass11_0.r0(false, true);
		}
		this.label_21.Visible = false;
	}

	// Token: 0x060004EF RID: 1263 RVA: 0x000B2EC0 File Offset: 0x000B10C0
	private void button_8_Click(object sender, EventArgs e)
	{
		List<TableDataRowP> list = new List<TableDataRowP>();
		foreach (GClass104 gclass in this.list_0)
		{
			if (gclass.bool_0)
			{
				list.Add(new TableDataRowP(gclass));
			}
		}
		foreach (GClass104 gclass2 in this.list_0)
		{
			if (!gclass2.bool_0)
			{
				list.Add(new TableDataRowP(gclass2));
			}
		}
		this.dataGridView_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		this.dataGridView_1.DataSource = list;
		this.dataGridView_1.Invalidate();
		this.dataGridView_1.Focus();
		this.dataGridView_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
	}

	// Token: 0x060004F0 RID: 1264 RVA: 0x000B2FB4 File Offset: 0x000B11B4
	private void method_10(string string_20)
	{
		string str = GClass107.smethod_3(111099);
		string str2 = "%";
		Random random = new Random();
		int num = random.Next(0, 100);
		this.label_14.Text = str + random.Next(10, 20).ToString() + str2;
		Application.DoEvents();
		int int_ = 0;
		if (GClass126.bool_10 && GClass126.bool_13)
		{
			int_ = 2;
			GClass125.smethod_64(0);
		}
		else if (GClass126.bool_13)
		{
			int_ = 1;
		}
		else
		{
			GClass125.smethod_17(GClass126.string_5);
		}
		GClass126.smethod_2(GClass107.smethod_3(111124), 0);
		if (GClass125.smethod_69() && !GClass126.bool_13)
		{
			new GForm4().ShowDialog();
			Application.DoEvents();
		}
		typeof(TableDataRowP).GetProperties();
		typeof(TableDataRowE).GetProperties();
		typeof(SimpleValueData).GetProperties();
		typeof(MapRowData).GetProperties();
		this.method_15(string_20, int_);
		this.method_45();
		GClass126.smethod_2(GClass107.smethod_3(111164), 0);
		GClass121.smethod_11(GClass125.smethod_20(), GClass125.smethod_22());
		GClass126.smethod_2(GClass107.smethod_3(111182), 0);
		GClass127.smethod_21(GClass126.string_12, GClass125.smethod_5());
		this.label_14.Text = str + random.Next(25, 40).ToString() + str2;
		Application.DoEvents();
		new Thread(new ThreadStart(this.method_14)).Start();
		this.method_32();
		GClass126.smethod_2(GClass107.smethod_3(111227), 0);
		this.gclass99_0 = new GClass99();
		this.label_14.Text = str + random.Next(50, 70).ToString() + str2;
		Application.DoEvents();
		this.tabControl_0.Visible = true;
		this.label_16.Text = "";
		GClass126.smethod_2(GClass107.smethod_3(111238), 0);
		DataView dataSource = new DataView(this.gclass99_0.dataTable_0);
		DataView dataSource2 = new DataView(this.gclass99_0.dataTable_1);
		DataView dataSource3 = new DataView(this.gclass99_0.dataTable_2);
		DataView dataSource4 = new DataView(this.gclass99_0.dataTable_3);
		GClass126.smethod_2(GClass107.smethod_3(111281), 0);
		this.label_14.Text = str + random.Next(80, 95).ToString() + str2;
		Application.DoEvents();
		this.dataGridView_6.DataSource = dataSource;
		this.dataGridView_5.DataSource = dataSource2;
		this.dataGridView_7.DataSource = dataSource3;
		this.dataGridView_4.DataSource = dataSource4;
		this.tabControl_0_SelectedIndexChanged(null, null);
		this.label_14.Text = str + 100.ToString() + str2;
		Application.DoEvents();
		GClass126.smethod_2(GClass107.smethod_3(111291), 0);
		this.label_14.Visible = false;
		this.panel_11.Visible = false;
		this.label_14.Text = GClass107.smethod_3(111339);
		Application.DoEvents();
		if (!GClass126.bool_13)
		{
			this.comboBox_2.Items.Clear();
			this.comboBox_2.Items.Add(GClass107.smethod_3(111349));
			this.comboBox_2.SelectedIndex = 0;
		}
		this.timer_2.Interval = ((GClass125.smethod_67() == 0) ? 180 : ((GClass125.smethod_67() == 0) ? 500 : 800));
		this.timer_2.Start();
		if (!GClass126.bool_13)
		{
			this.Text += GClass107.smethod_3(111354);
			if (GClass125.smethod_11() == "" && !GClass126.bool_18 && !GClass125.smethod_5().StartsWith(this.string_8) && GClass125.smethod_5() != "")
			{
				MessageBox.Show(string.Format(this.string_3, GClass126.string_0), GClass107.smethod_3(111371), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				GClass125.smethod_6("");
			}
			else if (GClass125.smethod_11() == "" && GClass125.smethod_84())
			{
				GClass126.string_12 = GClass127.smethod_43().Replace(" ", "");
			}
		}
		else if (num < 114 && GClass121.smethod_14(GClass125.smethod_5().ToUpper(), GClass107.smethod_3(111390), false))
		{
			GClass126.bool_13 = (num == 104);
			GClass126.smethod_2(GClass107.smethod_3(111392), 0);
		}
		if (GClass126.bool_18)
		{
			string str3 = "";
			if (GClass126.int_12 > 1000)
			{
				string text = GClass126.int_12.ToString() ?? "";
				string arg = text.Substring(0, text.Length - 3) + "." + text.Substring(text.Length - 3, 1);
				str3 = string.Format(this.string_6, arg);
			}
			if (GClass125.smethod_5().StartsWith("MP"))
			{
				MessageBox.Show(string.Format(this.string_5, GClass126.string_0) + str3, GClass107.smethod_3(111406), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				MessageBox.Show(string.Format(this.string_4, GClass126.string_0) + str3, GClass107.smethod_3(111454), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		if (Screen.PrimaryScreen.Bounds.Width == 1024)
		{
			this.panel_6.Width = this.panel_6.Width - 40;
			this.panel_6.BackgroundImageLayout = ImageLayout.Stretch;
			this.gclass114_1.Width = this.gclass114_1.Width - 40;
			this.gclass114_0.Left = this.gclass114_0.Left - 40;
			this.gclass114_0.Width = this.gclass114_0.Width + 40;
			this.flowLayoutPanel_0.Left = this.flowLayoutPanel_0.Left - 40;
			this.flowLayoutPanel_0.Width = this.flowLayoutPanel_0.Width + 40;
			this.panel_8.Left = this.panel_8.Left - 40;
			this.panel_8.Width = this.panel_8.Width - 10;
			this.panel_7.Left = this.panel_7.Left - 40 - 10;
			this.panel_7.Width = this.panel_7.Width + 40 + 10;
		}
		else if (Screen.PrimaryScreen.Bounds.Width == 800)
		{
			this.panel_6.Width = this.panel_6.Width - 59;
			this.panel_6.BackgroundImageLayout = ImageLayout.Stretch;
			this.gclass114_1.Width = this.gclass114_1.Width - 59;
			this.gclass114_0.Left = this.gclass114_0.Left - 59;
			this.gclass114_0.Width = this.gclass114_0.Width + 59;
			this.flowLayoutPanel_0.Left = this.flowLayoutPanel_0.Left - 59;
			this.flowLayoutPanel_0.Width = this.flowLayoutPanel_0.Width + 59;
			this.panel_8.Left = this.panel_8.Left - 59;
			this.panel_8.Width = this.panel_8.Width - 16;
			this.panel_7.Left = this.panel_7.Left - 59 - 16;
			this.panel_7.Width = this.panel_7.Width + 59 + 16;
			this.label_12.Visible = false;
		}
		else if (Screen.PrimaryScreen.Bounds.Width > 1024 && this.label_6.Height > this.dataGridView_6.Location.Y)
		{
			this.dataGridView_6.Size = new Size(this.dataGridView_6.Size.Width, this.dataGridView_6.Height + this.dataGridView_6.Location.Y - this.label_6.Height);
			this.dataGridView_6.Location = new Point(this.dataGridView_6.Location.X, this.label_6.Height);
			this.dataGridView_5.Size = new Size(this.dataGridView_5.Size.Width, this.dataGridView_6.Height);
			this.dataGridView_5.Location = new Point(this.dataGridView_5.Location.X, this.dataGridView_6.Location.Y);
			this.dataGridView_7.Size = new Size(this.dataGridView_7.Size.Width, this.dataGridView_7.Height + this.dataGridView_7.Location.Y - this.label_6.Height - 2);
			this.dataGridView_7.Location = new Point(this.dataGridView_7.Location.X, this.label_6.Height + 2);
			this.dataGridView_4.Size = new Size(this.dataGridView_4.Size.Width, this.dataGridView_4.Height + this.dataGridView_4.Location.Y - this.label_6.Height - 2);
			this.dataGridView_4.Location = new Point(this.dataGridView_4.Location.X, this.dataGridView_7.Location.Y);
		}
		GClass126.smethod_2(GClass107.smethod_3(111455) + GClass123.int_5.ToString(), 0);
		Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
		GClass124.smethod_19(GClass107.smethod_3(111501), 0);
		if (GClass126.bool_13)
		{
			this.method_49();
		}
		this.button_23.Enabled = true;
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x000B3A14 File Offset: 0x000B1C14
	private void method_11(GClass104 gclass104_0)
	{
		gclass104_0.string_0 = GClass121.smethod_20(GClass127.smethod_37(gclass104_0.string_0.Substring(0, 6)), gclass104_0.string_0.Substring(6));
		gclass104_0.string_1 = GClass121.smethod_20(40000 + GClass127.smethod_37(gclass104_0.string_1.Substring(0, 6)), gclass104_0.string_1.Substring(6));
		gclass104_0.string_3 = GClass121.smethod_4(gclass104_0.string_3, gclass104_0.string_3);
		if (!(gclass104_0.string_2.ToLower() == GClass107.smethod_3(112267)) && !gclass104_0.string_2.ToLower().Contains(GClass107.smethod_3(112281)))
		{
			gclass104_0.string_5 = GClass127.smethod_54(gclass104_0.string_5[0]);
			return;
		}
		gclass104_0.string_5 = GClass127.smethod_47(gclass104_0.string_5[0]);
	}

	// Token: 0x060004F2 RID: 1266 RVA: 0x000B3AF0 File Offset: 0x000B1CF0
	private void button_23_Click(object sender, EventArgs e)
	{
		if (GClass126.bool_13)
		{
			new GForm7(true).ShowDialog();
		}
		else
		{
			new GForm7(false).ShowDialog();
		}
		this.button_20.Visible = (GClass126.smethod_8() > 50);
		this.panel_18.Visible = false;
		this.method_45();
	}

	// Token: 0x060004F3 RID: 1267 RVA: 0x00003E8C File Offset: 0x0000208C
	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		GClass126.bool_16 = this.checkBox_1.Checked;
		this.dataGridView_1.Focus();
	}

	// Token: 0x060004F4 RID: 1268 RVA: 0x000B3B44 File Offset: 0x000B1D44
	private void method_12()
	{
		try
		{
			this.label_9.Visible = true;
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x00003EAA File Offset: 0x000020AA
	private void button_1_Click(object sender, EventArgs e)
	{
		if (GClass126.smethod_0() != null && GClass126.smethod_0().list_3.Count != 0)
		{
			if (this.saveFileDialog_0.ShowDialog() == DialogResult.OK)
			{
				this.method_46(this.saveFileDialog_0.FileName);
			}
			return;
		}
	}

	// Token: 0x060004F6 RID: 1270 RVA: 0x000B3B74 File Offset: 0x000B1D74
	private void method_13()
	{
		int num = GClass125.smethod_81();
		try
		{
			DataRow[] array = ((DataView)this.dataGridView_4.DataSource).Table.Select("SystemID=" + num.ToString(), "");
			int num2 = (int)array[0]["CategoryID"];
			int num3 = (int)array[0]["ModelID"];
			int num4 = (int)((DataView)this.dataGridView_5.DataSource).Table.Select("ModelID=" + num3.ToString(), "")[0]["MakeID"];
			for (int i = 0; i < this.dataGridView_6.Rows.Count; i++)
			{
				if ((int)this.dataGridView_6.Rows[i].Cells[this.dataGridViewTextBoxColumn_0.Name].Value == num4)
				{
					this.dataGridView_6.CurrentCell = this.dataGridView_6.Rows[i].Cells[1];
					this.dataGridView_6.Rows[i].Selected = true;
					this.dataGridView_6.FirstDisplayedScrollingRowIndex = i;
					IL_141:
					this.dataGridView_6_SelectionChanged(null, null);
					for (int j = 0; j < this.dataGridView_5.Rows.Count; j++)
					{
						if ((int)this.dataGridView_5.Rows[j].Cells[this.dataGridViewTextBoxColumn_3.Name].Value == num3)
						{
							this.dataGridView_5.CurrentCell = this.dataGridView_5.Rows[j].Cells[2];
							this.dataGridView_5.Rows[j].Selected = true;
							this.dataGridView_5.FirstDisplayedScrollingRowIndex = j;
							IL_1ED:
							this.dataGridView_5_SelectionChanged(null, null);
							for (int k = 0; k < this.dataGridView_7.Rows.Count; k++)
							{
								if ((int)this.dataGridView_7.Rows[k].Cells[this.dataGridViewTextBoxColumn_6.Name].Value == num2)
								{
									this.dataGridView_7.CurrentCell = this.dataGridView_7.Rows[k].Cells[1];
									this.dataGridView_7.Rows[k].Selected = true;
									this.dataGridView_7.FirstDisplayedScrollingRowIndex = k;
									IL_299:
									this.dataGridView_7_SelectionChanged(null, null);
									for (int l = 0; l < this.dataGridView_4.Rows.Count; l++)
									{
										if ((int)this.dataGridView_4.Rows[l].Cells[this.dataGridViewTextBoxColumn_21.Name].Value == num)
										{
											this.dataGridView_4.CurrentCell = this.dataGridView_4.Rows[l].Cells[3];
											this.dataGridView_4.Rows[l].Selected = true;
											this.dataGridView_4.FirstDisplayedScrollingRowIndex = l;
											IL_345:
											goto IL_378;
										}
									}
									goto IL_345;
								}
							}
							goto IL_299;
						}
					}
					goto IL_1ED;
				}
			}
			goto IL_141;
		}
		catch (Exception)
		{
			this.dataGridView_6.Rows[0].Selected = false;
			this.dataGridView_6.Rows[0].Selected = true;
		}
		IL_378:
		try
		{
			if (!GClass122.smethod_13().ToLower().EndsWith(GClass107.smethod_3(111649)) && !GClass125.smethod_24().ToLower().EndsWith(GClass107.smethod_3(111654)))
			{
				throw new Exception(GClass107.smethod_3(111665));
			}
		}
		catch (Exception)
		{
			this.method_5();
		}
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x000B3F80 File Offset: 0x000B2180
	public static List<Control> smethod_0(Control control_0, int int_3)
	{
		List<Control> list = new List<Control>();
		if (int_3 < 10)
		{
			foreach (object obj in control_0.Controls)
			{
				Control control = (Control)obj;
				list.AddRange(GForm8.smethod_0(control, int_3 + 1));
				list.Add(control);
			}
		}
		return list;
	}

	// Token: 0x060004F8 RID: 1272 RVA: 0x000B3FF8 File Offset: 0x000B21F8
	private void button_13_Click(object sender, EventArgs e)
	{
		if (this.gform9_0 != null)
		{
			return;
		}
		if (this.gform10_0 != null)
		{
			return;
		}
		if (this.gform11_0 != null)
		{
			return;
		}
		if (this.dataGridView_8.SelectedRows.Count == 0)
		{
			return;
		}
		GClass104 dataItem = ((TableDataRowP)this.dataGridView_8.SelectedRows[0].DataBoundItem).getDataItem();
		bool flag = !dataItem.string_2.Contains(GClass107.smethod_3(115672)) && dataItem.byte_0.Length > 1 && !dataItem.string_2.Contains(GClass107.smethod_3(115710));
		if (!GClass126.bool_0 && !GClass126.bool_13)
		{
			this.gform9_0 = new GForm9(GClass107.smethod_3(115727), GClass107.smethod_3(115743), GClass107.smethod_3(115784), true, 3000);
			this.gform9_0.ShowDialog();
			this.gform9_0 = null;
			return;
		}
		if (dataItem.string_2.Contains(GClass107.smethod_3(115806)))
		{
			this.gform9_0 = new GForm9(GClass121.smethod_6("6050"), "", GClass121.smethod_6("1055"), true, 0);
			this.gform9_0.ShowDialog();
			if (this.gform9_0 == null)
			{
				return;
			}
			bool flag2 = this.gform9_0.method_1();
			this.gform9_0 = null;
			if (!flag2)
			{
				return;
			}
		}
		if (dataItem.string_2.Contains(GClass107.smethod_3(115838)))
		{
			this.gform9_0 = new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("6091"), GClass121.smethod_6("1055"), true, 0);
			this.gform9_0.ShowDialog();
			if (this.gform9_0 == null)
			{
				return;
			}
			bool flag3 = this.gform9_0.method_1();
			this.gform9_0 = null;
			if (!flag3)
			{
				return;
			}
		}
		GClass126.smethod_2(GClass121.smethod_6("7101"), 2);
		GClass126.smethod_2(dataItem.string_0, 2);
		string text = "";
		if (dataItem.string_2.Contains(GClass107.smethod_3(115839)) || dataItem.string_2.Contains(GClass107.smethod_3(115846)))
		{
			flag = false;
			if (dataItem.string_2.Contains(GClass107.smethod_3(115848)))
			{
				if (dataItem.string_2.Contains(GClass107.smethod_3(115889)))
				{
					bool flag4 = dataItem.string_2.Contains(GClass107.smethod_3(115907));
					bool flag5 = dataItem.string_2.Contains(GClass107.smethod_3(115955)) || dataItem.string_2.Contains(GClass107.smethod_3(115992));
					if (flag4)
					{
						text = this.gclass11_0.vmethod_0(dataItem.byte_0[0], GClass107.smethod_3(116032), dataItem.int_0, dataItem.int_1, dataItem.string_5, dataItem.string_6);
					}
					else if (flag5)
					{
						text = this.gclass11_0.vmethod_0(dataItem.byte_0[0], GClass107.smethod_3(116043), dataItem.int_0, dataItem.int_1, dataItem.string_5, dataItem.string_6);
					}
					else
					{
						text = this.gclass11_0.vmethod_0(dataItem.byte_0[0], GClass107.smethod_3(116054), dataItem.int_0, dataItem.int_1, dataItem.string_5, dataItem.string_6);
					}
					string text2 = this.gclass11_0.vmethod_0(dataItem.byte_0[0], "raw", dataItem.int_0, dataItem.int_1, dataItem.string_5, dataItem.string_6);
					this.gclass11_0.method_3(GClass127.smethod_32(text2));
				}
				this.gclass11_0.vmethod_0(new byte[]
				{
					2,
					16,
					80
				}, "hex", 0, 1, new string[0], "hex");
			}
			string a;
			if (GClass126.bool_0)
			{
				a = "00";
			}
			else if (dataItem.string_2.Contains(GClass107.smethod_3(116101)))
			{
				a = this.gclass11_0.vmethod_0(new byte[]
				{
					2,
					39,
					3
				}, "hex", 0, 4, new string[0], "hex");
			}
			else
			{
				a = this.gclass11_0.vmethod_0(new byte[]
				{
					2,
					39,
					3
				}, "hex", 1, 1, new string[0], "hex");
			}
			if (a == "")
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6066"), "", true, 3000);
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
				return;
			}
			if (a != "00" || (dataItem.string_2.Contains(GClass107.smethod_3(116110)) && a != GClass107.smethod_3(116146)))
			{
				string[] array = new string[]
				{
					"0",
					"1",
					"2",
					"3",
					"4",
					"5",
					"6",
					"7",
					"8",
					"9"
				};
				string text3 = "00000";
				GClass126.smethod_2(GClass121.smethod_6("6061"), 2);
				GForm2 gform = new GForm2(GClass121.smethod_6("6061"), text3, array, 5);
				if (gform.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				int[] array2 = gform.method_1();
				string text4;
				if (dataItem.string_2.Contains(GClass107.smethod_3(116176)))
				{
					text4 = GClass107.smethod_3(116179);
				}
				else
				{
					text4 = GClass107.smethod_3(116201);
				}
				text4 = string.Concat(new string[]
				{
					text4,
					array[array2[0]],
					array[array2[1]],
					array[array2[2]],
					array[array2[3]],
					array[array2[4]]
				});
				string a2;
				if (GClass126.bool_0)
				{
					a2 = (dataItem.string_2.Contains("SECURITY29") ? "" : "34");
				}
				else if (dataItem.string_2.Contains(GClass107.smethod_3(116229)))
				{
					a2 = this.gclass11_0.vmethod_0(GClass127.smethod_32(text4), GClass107.smethod_3(116272), 0, 1, new string[0], GClass107.smethod_3(116272));
				}
				else
				{
					a2 = this.gclass11_0.vmethod_0(GClass127.smethod_32(text4), GClass107.smethod_3(116336), 1, 1, new string[0], GClass107.smethod_3(116336));
				}
				if (!(a2 == "34") && (!dataItem.string_2.Contains("SECURITY29") || !(a2 == "")))
				{
					if (a2 == "33" || a2 == "35")
					{
						this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6062"), GClass121.smethod_6("6063"), true, 3000);
						this.gform9_0.ShowDialog();
						this.gform9_0 = null;
						GClass126.smethod_2(GClass121.smethod_6("6062"), 2);
						GClass126.smethod_2(GClass121.smethod_6("1093"), 2);
						return;
					}
					if (!(a2 == "36") && !(a2 == "37"))
					{
						this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6066"), GClass121.smethod_6("6067"), true, 3000);
						this.gform9_0.ShowDialog();
						this.gform9_0 = null;
						GClass126.smethod_2(GClass121.smethod_6("1093"), 2);
						return;
					}
					this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6064"), GClass121.smethod_6("6065"), true, 3000);
					this.gform9_0.ShowDialog();
					this.gform9_0 = null;
					GClass126.smethod_2(GClass121.smethod_6("6064"), 2);
					GClass126.smethod_2(GClass121.smethod_6("1093"), 2);
					return;
				}
				else
				{
					GClass126.smethod_2(GClass121.smethod_6("1092"), 2);
				}
			}
		}
		if (dataItem.string_2.Contains(GClass107.smethod_3(116388)))
		{
			flag = false;
			string text5 = "";
			int int_ = 0;
			string a3;
			if (GClass126.bool_0)
			{
				a3 = "00";
			}
			else
			{
				a3 = this.gclass11_0.vmethod_0(new byte[]
				{
					2,
					39,
					5
				}, "hex", 1, 4, new string[0], "hex");
				text5 = this.gclass11_0.ModuleID;
				int_ = this.gclass11_0.method_20();
			}
			if (a3 == "")
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6066"), "", true, 3000);
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
				return;
			}
			if (a3 != GClass107.smethod_3(116429))
			{
				byte[] array3 = GClass127.smethod_32(a3);
				if (array3.Length != 4)
				{
					this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6066"), "", true, 3000);
					this.gform9_0.ShowDialog();
					this.gform9_0 = null;
					return;
				}
				byte[] byte_ = GClass127.smethod_18(array3, "", text5, int_);
				string text6 = GClass107.smethod_3(116471) + GClass127.smethod_11(byte_);
				string a4;
				if (GClass126.bool_0)
				{
					a4 = (dataItem.string_2.Contains("SECURITY0529") ? "" : "34");
				}
				else
				{
					a4 = this.gclass11_0.vmethod_0(GClass127.smethod_32(text6), GClass107.smethod_3(116507), 1, 1, new string[0], GClass107.smethod_3(116507));
				}
				if (a4 == "34")
				{
					GClass126.smethod_2(GClass121.smethod_6("1092"), 0);
				}
				else
				{
					if (a4 == "33" || a4 == "35")
					{
						this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6062"), GClass121.smethod_6("6063"), true, 3000);
						this.gform9_0.ShowDialog();
						this.gform9_0 = null;
						GClass126.smethod_2(GClass121.smethod_6("6062"), 2);
						GClass126.smethod_2(GClass121.smethod_6("1093"), 2);
						return;
					}
					if (!(a4 == "36") && !(a4 == "37"))
					{
						this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6066"), GClass121.smethod_6("6067"), true, 3000);
						this.gform9_0.ShowDialog();
						this.gform9_0 = null;
						GClass126.smethod_2(GClass121.smethod_6("1093"), 2);
						return;
					}
					this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6064"), GClass121.smethod_6("6065"), true, 3000);
					this.gform9_0.ShowDialog();
					this.gform9_0 = null;
					GClass126.smethod_2(GClass121.smethod_6("6064"), 2);
					GClass126.smethod_2(GClass121.smethod_6("1093"), 2);
					return;
				}
			}
		}
		if (dataItem.string_2.Contains(GClass107.smethod_3(116573)))
		{
			flag = false;
			string[] array4 = new string[]
			{
				"0",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9"
			};
			string text7 = "12345";
			GForm2 gform2 = new GForm2(GClass121.smethod_6("6061"), text7, array4, 5);
			if (gform2.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			int[] array5 = gform2.method_1();
			string text8 = GClass107.smethod_3(116610);
			text8 = string.Concat(new string[]
			{
				text8,
				array4[array5[0]],
				array4[array5[1]],
				array4[array5[2]],
				array4[array5[3]],
				array4[array5[4]]
			});
			if (!(this.gclass11_0.vmethod_0(GClass127.smethod_32(text8), GClass107.smethod_3(116614), 1, 1, new string[0], GClass107.smethod_3(116614)) == "00") && !GClass126.bool_0)
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6066"), GClass121.smethod_6("6067"), true, 3000);
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
				GClass126.smethod_2(GClass121.smethod_6("1093"), 2);
				return;
			}
			GClass126.smethod_2(GClass121.smethod_6("1092"), 2);
		}
		if (dataItem.string_2.Contains(GClass107.smethod_3(116654)))
		{
			flag = false;
			string[] array6 = dataItem.string_2.Split(new char[]
			{
				'|'
			});
			string text9 = array6[2];
			int num = GClass127.smethod_37(array6[1]);
			string[] array7 = new string[]
			{
				"0",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9"
			};
			if (this.gclass11_0 == null)
			{
				return;
			}
			string text10 = this.gclass11_0.vmethod_0(dataItem.byte_0[0], text9, dataItem.int_0, dataItem.int_1, dataItem.string_5, dataItem.string_6);
			string str = text10;
			while (text10.Length < num)
			{
				text10 = "0" + text10;
			}
			string str2 = dataItem.string_0;
			if (dataItem.string_3 != "")
			{
				str2 = str2 + " (" + dataItem.string_3 + ")";
			}
			if (text9 == GClass107.smethod_3(116699))
			{
				text10 = text10.Replace("/", "");
				str2 += GClass107.smethod_3(116712);
			}
			GForm2 gform3 = new GForm2(str2, text10, array7, num);
			if (gform3.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			int[] array8 = gform3.method_1();
			string text11 = "";
			for (int i = 0; i < num; i++)
			{
				text11 += array7[array8[i]];
			}
			if (text9.StartsWith("num"))
			{
				decimal d = 1m;
				decimal d2 = 0m;
				string[] array9 = text9.Split(new char[]
				{
					','
				});
				try
				{
					if (array9.Length > 1)
					{
						GClass127.smethod_37(array9[1]);
					}
					if (array9.Length > 2)
					{
						d = Convert.ToDecimal(array9[2], NumberFormatInfo.InvariantInfo);
					}
					if (array9.Length > 3)
					{
						d2 = Convert.ToDecimal(array9[3], NumberFormatInfo.InvariantInfo);
					}
					byte[] array10 = GClass127.smethod_30((long)((GClass127.smethod_29(Convert.ToDecimal(text11), dataItem.string_6) - d2) / d));
					for (int j = 0; j < dataItem.int_1; j++)
					{
						if (dataItem.string_2.Contains(GClass107.smethod_3(116713)))
						{
							dataItem.byte_0[1][j + 3 + dataItem.int_0] = array10[dataItem.int_1 - j - 1];
						}
						else
						{
							dataItem.byte_0[1][j + 2 + dataItem.int_0] = array10[dataItem.int_1 - j - 1];
						}
					}
					goto IL_1344;
				}
				catch (Exception ex)
				{
					GClass126.smethod_2(GClass107.smethod_3(116762) + ex.Message, 1);
					return;
				}
			}
			if (text9 == GClass107.smethod_3(116802))
			{
				try
				{
					byte[] array11 = GClass127.smethod_32(text11);
					int num2 = 2;
					if (dataItem.string_2.Contains(GClass107.smethod_3(116827)))
					{
						num2 = 3;
					}
					dataItem.byte_0[1][num2 + dataItem.int_0] = array11[2];
					dataItem.byte_0[1][1 + num2 + dataItem.int_0] = array11[3];
					dataItem.byte_0[1][2 + num2 + dataItem.int_0] = array11[0];
					dataItem.byte_0[1][3 + num2 + dataItem.int_0] = array11[1];
					goto IL_1344;
				}
				catch (Exception ex2)
				{
					GClass126.smethod_2(GClass107.smethod_3(116846) + ex2.Message, 1);
					return;
				}
			}
			if (text9.StartsWith("eq3"))
			{
				decimal d3 = 0m;
				decimal d4 = 0m;
				decimal d5 = 0m;
				decimal d6 = 0m;
				decimal d7 = 0m;
				decimal d8 = 0m;
				string[] array12 = text9.Split(new char[]
				{
					','
				});
				try
				{
					if (array12.Length > 1)
					{
						GClass127.smethod_37(array12[1]);
					}
					if (array12.Length > 2)
					{
						d3 = Convert.ToDecimal(array12[2], NumberFormatInfo.InvariantInfo);
					}
					if (array12.Length > 3)
					{
						d4 = Convert.ToDecimal(array12[3], NumberFormatInfo.InvariantInfo);
					}
					if (array12.Length > 4)
					{
						d5 = Convert.ToDecimal(array12[4], NumberFormatInfo.InvariantInfo);
					}
					if (array12.Length > 5)
					{
						d6 = Convert.ToDecimal(array12[5], NumberFormatInfo.InvariantInfo);
					}
					if (array12.Length > 6)
					{
						d7 = Convert.ToDecimal(array12[6], NumberFormatInfo.InvariantInfo);
					}
					if (array12.Length > 7)
					{
						d8 = Convert.ToDecimal(array12[7], NumberFormatInfo.InvariantInfo);
					}
					decimal d9 = GClass127.smethod_29(Convert.ToDecimal(text11), dataItem.string_6);
					int num3 = (int)Math.Floor((d9 - d4) / d3);
					int num4 = (int)Math.Floor((d9 - num3 * d3 + d4 - d6) / d5);
					int num5 = (int)Math.Floor((d9 - (num3 * d3 + d4) - (num4 * d5 + d6) - d8) / d7);
					if (num3 < 0 || num3 > 255 || num4 < 0 || num4 > 255 || num5 < 0 || num5 > 255)
					{
						throw new Exception(GClass107.smethod_3(116883));
					}
					if (dataItem.string_2.Contains(GClass107.smethod_3(116917)))
					{
						dataItem.byte_0[1][3 + dataItem.int_0] = (byte)num3;
						dataItem.byte_0[1][4 + dataItem.int_0] = (byte)num4;
						dataItem.byte_0[1][5 + dataItem.int_0] = (byte)num5;
					}
					else
					{
						dataItem.byte_0[1][2 + dataItem.int_0] = (byte)num3;
						dataItem.byte_0[1][3 + dataItem.int_0] = (byte)num4;
						dataItem.byte_0[1][4 + dataItem.int_0] = (byte)num5;
					}
				}
				catch (Exception ex3)
				{
					GClass126.smethod_2(GClass107.smethod_3(116944) + ex3.Message, 1);
					return;
				}
			}
			IL_1344:
			if (this.gclass11_0 == null)
			{
				return;
			}
			string text12 = this.gclass11_0.r4(dataItem.byte_0[1], text9, dataItem.int_0, dataItem.int_1, dataItem.string_5, dataItem.string_6);
			if (dataItem.string_3 != "")
			{
				text12 = text12 + " " + dataItem.string_3;
			}
			this.gform9_0 = new GForm9(GClass121.smethod_6("6058"), dataItem.string_0 + ": " + text12, GClass121.smethod_6("1055"), true, 0);
			this.gform9_0.ShowDialog();
			if (this.gform9_0 == null)
			{
				return;
			}
			bool flag6 = this.gform9_0.method_1();
			this.gform9_0 = null;
			if (!flag6)
			{
				GClass126.smethod_2(GClass121.smethod_6("6060"), 2);
				return;
			}
			if (dataItem.string_2.Contains(GClass107.smethod_3(116978)))
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("1203"), GClass121.smethod_6("1055"), true, 0);
				this.gform9_0.ShowDialog();
				if (this.gform9_0 == null)
				{
					return;
				}
				bool flag7 = this.gform9_0.method_1();
				this.gform9_0 = null;
				if (!flag7)
				{
					GClass126.smethod_2(GClass121.smethod_6("6060"), 2);
					return;
				}
			}
			GClass126.smethod_2(GClass121.smethod_6("7102") + ": " + str, 2);
			GClass126.smethod_2(GClass121.smethod_6("7103") + ": " + text12, 2);
		}
		else if (dataItem.string_2.Contains(GClass107.smethod_3(116987)))
		{
			flag = false;
			bool flag8 = dataItem.string_2.Contains(GClass107.smethod_3(117033));
			bool flag9 = dataItem.string_2.Contains(GClass107.smethod_3(117077)) || dataItem.string_2.Contains(GClass107.smethod_3(117096));
			bool flag10 = dataItem.string_2.Contains(GClass107.smethod_3(117138));
			string[] array13 = new string[dataItem.string_5.Length];
			for (int k = 0; k < array13.Length; k++)
			{
				if (flag8)
				{
					array13[k] = dataItem.string_5[k].Substring(8);
				}
				else
				{
					array13[k] = dataItem.string_5[k].Substring(4);
				}
			}
			if (this.gclass11_0 == null)
			{
				return;
			}
			string text13 = text;
			if (dataItem.string_2.Contains(GClass107.smethod_3(117170)))
			{
				GClass126.smethod_2(GClass107.smethod_3(117192) + text13, 0);
			}
			else if (flag8)
			{
				text13 = this.gclass11_0.vmethod_0(dataItem.byte_0[0], GClass107.smethod_3(117209), dataItem.int_0, dataItem.int_1, dataItem.string_5, dataItem.string_6);
			}
			else if (flag9)
			{
				text13 = this.gclass11_0.vmethod_0(dataItem.byte_0[0], GClass107.smethod_3(117248), dataItem.int_0, dataItem.int_1, dataItem.string_5, dataItem.string_6);
			}
			else if (flag10)
			{
				text13 = this.gclass11_0.vmethod_0(dataItem.byte_0[0], "num", 1, 1, dataItem.string_5, dataItem.string_6) + GClass107.smethod_3(117270);
				if (text13 == GClass107.smethod_3(117277))
				{
					text13 = dataItem.string_5[0].Substring(4);
				}
			}
			else
			{
				text13 = this.gclass11_0.vmethod_0(dataItem.byte_0[0], GClass107.smethod_3(117319), dataItem.int_0, dataItem.int_1, dataItem.string_5, dataItem.string_6);
			}
			if ((this.gclass11_0.ModuleID.StartsWith(GClass107.smethod_3(117359)) || this.gclass11_0.ModuleID.StartsWith(GClass107.smethod_3(117400))) && text13 == "")
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6504"), "", true, 2000);
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
				return;
			}
			string str3 = dataItem.string_0;
			int num6 = dataItem.int_1;
			if (dataItem.string_2.StartsWith(GClass107.smethod_3(117415)))
			{
				array13 = new string[]
				{
					"0",
					"1",
					"2",
					"3",
					"4",
					"5",
					"6",
					"7",
					"8",
					"9"
				};
				str3 += GClass107.smethod_3(117425);
				if (this.gclass11_0 == null)
				{
					return;
				}
				if (this.gclass11_0.ModuleID.StartsWith(GClass107.smethod_3(117430)))
				{
					text13 = GClass127.smethod_11(dataItem.byte_0[0]).Replace(" ", "").Substring(8);
				}
				else
				{
					text13 = GClass127.smethod_11(dataItem.byte_0[0]).Replace(" ", "").Substring(4);
				}
				num6 *= 2;
			}
			if (flag9)
			{
				num6 *= 2;
			}
			if (flag8)
			{
				num6 /= 2;
			}
			GClass126.smethod_2(GClass107.smethod_3(117460) + GClass127.smethod_11(dataItem.byte_0[0]), 0);
			GClass126.smethod_2(GClass107.smethod_3(117481) + text13, 0);
			GForm2 gform4 = new GForm2(str3, text13, array13, num6);
			if (gform4.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			if (this.gclass11_0 == null)
			{
				return;
			}
			int[] array14 = gform4.method_1();
			if (dataItem.string_2.StartsWith(GClass107.smethod_3(117482)))
			{
				string str4 = "";
				for (int l = 0; l < num6; l++)
				{
					str4 += array13[array14[l]];
				}
				byte[] array15 = GClass127.smethod_32(str4);
				for (int m = 0; m < dataItem.int_1; m++)
				{
					if (this.gclass11_0.ModuleID.StartsWith(GClass107.smethod_3(117519)))
					{
						dataItem.byte_0[1][m + 3 + dataItem.int_0] = array15[m];
					}
					else
					{
						dataItem.byte_0[1][m + 1 + dataItem.int_0] = array15[m];
					}
				}
			}
			else
			{
				byte b = 0;
				for (int n = 0; n < num6; n++)
				{
					byte b2 = 0;
					byte b3 = 0;
					string a5 = array13[array14[n]];
					for (int num7 = 0; num7 < dataItem.string_5.Length; num7++)
					{
						if (a5 == array13[num7])
						{
							if (flag9)
							{
								b2 = byte.Parse(dataItem.string_5[num7].Substring(2, 2), NumberStyles.HexNumber);
								if (n % 2 == 0)
								{
									b2 = (byte)(b2 << 4);
									b = b2;
								}
								else
								{
									b2 |= b;
									b = 0;
								}
							}
							else if (flag8)
							{
								b2 = byte.Parse(dataItem.string_5[num7].Substring(4, 2), NumberStyles.HexNumber);
								b3 = byte.Parse(dataItem.string_5[num7].Substring(6, 2), NumberStyles.HexNumber);
							}
							else
							{
								b2 = byte.Parse(dataItem.string_5[num7].Substring(2, 2), NumberStyles.HexNumber);
							}
						}
					}
					if (dataItem.string_2.Contains(GClass107.smethod_3(117523)))
					{
						if (flag9)
						{
							if (n % 2 == 1)
							{
								dataItem.byte_0[1][(n - 1) / 2 + 3 + dataItem.int_0] = b2;
							}
						}
						else
						{
							dataItem.byte_0[1][n + 3 + dataItem.int_0] = b2;
							if (flag8)
							{
								dataItem.byte_0[1][n + 3 + dataItem.int_0 + 1] = b3;
							}
						}
					}
					else if (this.gclass11_0.ModuleID.StartsWith(GClass107.smethod_3(117551)))
					{
						dataItem.byte_0[1][n + 3 + dataItem.int_0] = b2;
					}
					else if (this.gclass11_0.ModuleID.StartsWith(GClass107.smethod_3(117554)))
					{
						dataItem.byte_0[1][n + 1 + dataItem.int_0] = b2;
					}
					else if (flag9)
					{
						if (n % 2 == 1)
						{
							dataItem.byte_0[1][(n - 1) / 2 + 2 + dataItem.int_0] = b2;
						}
					}
					else
					{
						dataItem.byte_0[1][n + 2 + dataItem.int_0] = b2;
					}
				}
			}
			int num8 = dataItem.int_0;
			if (this.gclass11_0.ModuleID.StartsWith(GClass107.smethod_3(117600)))
			{
				num8 += 3;
			}
			else if (this.gclass11_0.ModuleID.StartsWith(GClass107.smethod_3(117635)))
			{
				num8 += 4;
			}
			else if (this.gclass11_0.ModuleID.StartsWith(GClass107.smethod_3(117665)))
			{
				num8 += 2;
			}
			string text14;
			if (dataItem.string_2.StartsWith(GClass107.smethod_3(117677)))
			{
				text14 = this.gclass11_0.r4(dataItem.byte_0[1], GClass107.smethod_3(117723), num8, dataItem.int_1, dataItem.string_5, dataItem.string_6);
			}
			else if (flag8)
			{
				text14 = this.gclass11_0.r4(dataItem.byte_0[1], GClass107.smethod_3(117733), num8, dataItem.int_1, dataItem.string_5, dataItem.string_6);
			}
			else if (flag9)
			{
				text14 = this.gclass11_0.r4(dataItem.byte_0[1], GClass107.smethod_3(117739), num8, dataItem.int_1, dataItem.string_5, dataItem.string_6);
			}
			else
			{
				text14 = this.gclass11_0.r4(dataItem.byte_0[1], GClass107.smethod_3(117740), num8, dataItem.int_1, dataItem.string_5, dataItem.string_6);
			}
			if (dataItem.string_3 != "")
			{
				text14 = text14 + " " + dataItem.string_3;
			}
			this.gform9_0 = new GForm9(GClass121.smethod_6("6058"), dataItem.string_0 + ": " + text14, GClass121.smethod_6("1055"), true, 0);
			this.gform9_0.ShowDialog();
			if (this.gform9_0 == null)
			{
				return;
			}
			bool flag11 = this.gform9_0.method_1();
			this.gform9_0 = null;
			if (!flag11)
			{
				GClass126.smethod_2(GClass121.smethod_6("6060"), 2);
				return;
			}
			GClass126.smethod_2(GClass121.smethod_6("7102") + ": " + text13, 2);
			GClass126.smethod_2(GClass121.smethod_6("7103") + ": " + text14, 2);
			dataItem.method_1(text14);
			for (int num9 = 0; num9 < this.dataGridView_8.Rows.Count; num9++)
			{
				this.dataGridView_8.UpdateCellValue(2, num9);
			}
		}
		if (dataItem.string_2.Contains(GClass107.smethod_3(117743)))
		{
			flag = false;
			if (dataItem.string_2.Contains(GClass107.smethod_3(117751)))
			{
				this.gclass11_0.vmethod_0(new byte[]
				{
					2,
					16,
					64
				}, "hex", 0, 1, new string[0], "hex");
			}
			string text15 = "";
			int int_2 = 0;
			string text16;
			if (GClass126.bool_0)
			{
				text16 = "00";
			}
			else
			{
				text16 = this.gclass11_0.vmethod_0(new byte[]
				{
					2,
					39,
					5
				}, "hex", 0, 4, new string[0], "hex");
				text15 = this.gclass11_0.ModuleID;
				int_2 = this.gclass11_0.method_20();
			}
			GClass126.smethod_2(GClass107.smethod_3(117752) + text16, 0);
			if (text16 == "")
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6066"), "", true, 3000);
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
				return;
			}
			if (text16 != GClass107.smethod_3(117796) && !GClass126.bool_0)
			{
				byte[] array16 = GClass127.smethod_32(text16);
				if (array16.Length != 4)
				{
					this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6066"), "", true, 3000);
					this.gform9_0.ShowDialog();
					this.gform9_0 = null;
					return;
				}
				string text17 = "00000000";
				byte[] array17 = new byte[1];
				int num10 = 0;
				while (num10 < 2)
				{
					array17 = GClass127.smethod_18(array16, text17, text15, int_2);
					if (array17.Length == 1 && array17[0] == 17)
					{
						Thread.Sleep(200);
						array17 = GClass127.smethod_18(array16, text17, text15, int_2);
						if (array17.Length == 1 && array17[0] == 17)
						{
							this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6401"), GClass121.smethod_6("6402"), true, 4000);
							this.gform9_0.ShowDialog();
							this.gform9_0 = null;
							return;
						}
					}
					if (array17.Length == 1 && array17[0] == 153)
					{
						this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6401"), GClass121.smethod_6("6402"), true, 4000);
						this.gform9_0.ShowDialog();
						this.gform9_0 = null;
						return;
					}
					if (array17.Length == 1)
					{
						if (array17[0] == 1)
						{
							this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6403"), GClass121.smethod_6("6406"), true, 4000);
							this.gform9_0.ShowDialog();
							this.gform9_0 = null;
							if (num10 > 0)
							{
								return;
							}
						}
						else if (array17[0] == 2)
						{
							this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6404"), GClass121.smethod_6("6406"), true, 4000);
							this.gform9_0.ShowDialog();
							this.gform9_0 = null;
							if (num10 > 0)
							{
								return;
							}
						}
						else if (array17[0] == 3)
						{
							this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6405"), GClass121.smethod_6("6406"), true, 4000);
							this.gform9_0.ShowDialog();
							this.gform9_0 = null;
							if (num10 > 0)
							{
								return;
							}
						}
						else if (num10 > 0)
						{
							this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6401"), GClass121.smethod_6("6402"), true, 4000);
							this.gform9_0.ShowDialog();
							this.gform9_0 = null;
							return;
						}
						if (num10 == 0)
						{
							string[] array18 = new string[]
							{
								"0",
								"1",
								"2",
								"3",
								"4",
								"5",
								"6",
								"7",
								"8",
								"9",
								"A",
								"B",
								"C",
								"D",
								"E",
								"F",
								"G",
								"H",
								"J",
								"K",
								"L",
								"M",
								"N",
								"P",
								"R",
								"S",
								"T",
								"U",
								"W",
								"X",
								"Y",
								"Z"
							};
							string text18 = "00000000";
							int length = text18.Length;
							GForm17 gform5 = new GForm17(GClass121.smethod_6("6407"), GClass121.smethod_6("6409"), text18, array18, length);
							if (gform5.ShowDialog() != DialogResult.OK)
							{
								return;
							}
							int[] array19 = gform5.method_1();
							text17 = "";
							for (int num11 = 0; num11 < length; num11++)
							{
								text17 += array18[array19[num11]];
							}
							GClass126.smethod_2(GClass107.smethod_3(117843) + text17, 0);
						}
						num10++;
					}
					else
					{
						IL_23E3:
						byte[] byte_2 = new byte[]
						{
							array17[0],
							array17[2],
							array17[4],
							array17[6]
						};
						byte[] byte_3 = new byte[]
						{
							array17[1],
							array17[3],
							array17[5],
							array17[7]
						};
						string text19;
						if (dataItem.string_2.Contains(GClass107.smethod_3(117860)))
						{
							text19 = GClass107.smethod_3(117905) + GClass127.smethod_11(byte_3);
						}
						else
						{
							text19 = GClass107.smethod_3(117950) + GClass127.smethod_11(byte_2);
						}
						string a6 = this.gclass11_0.vmethod_0(GClass127.smethod_32(text19), GClass107.smethod_3(117966), 0, 1, new string[0], GClass107.smethod_3(117966));
						if (a6 == "34" || a6 == "")
						{
							GClass126.smethod_2(GClass121.smethod_6("1092"), 0);
							Thread.Sleep(200);
							goto IL_2646;
						}
						if (a6 == "33" || a6 == "35")
						{
							this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6062"), GClass121.smethod_6("6410"), true, 3000);
							this.gform9_0.ShowDialog();
							this.gform9_0 = null;
							GClass126.smethod_2(GClass121.smethod_6("6062"), 2);
							GClass126.smethod_2(GClass121.smethod_6("1093"), 2);
							return;
						}
						if (!(a6 == "36") && !(a6 == "37"))
						{
							this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6066"), GClass121.smethod_6("6067"), true, 3000);
							this.gform9_0.ShowDialog();
							this.gform9_0 = null;
							GClass126.smethod_2(GClass121.smethod_6("1093"), 2);
							return;
						}
						this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6411"), GClass121.smethod_6("6065"), true, 3000);
						this.gform9_0.ShowDialog();
						this.gform9_0 = null;
						GClass126.smethod_2(GClass121.smethod_6("6064"), 2);
						GClass126.smethod_2(GClass121.smethod_6("1093"), 2);
						return;
					}
				}
				goto IL_23E3;
			}
		}
		IL_2646:
		if (dataItem.string_2.Contains(GClass107.smethod_3(118021)))
		{
			flag = false;
			string a7 = this.gclass11_0.vmethod_0(dataItem.byte_0[0], GClass107.smethod_3(118032), 1, 1, new string[0], GClass107.smethod_3(118032));
			if (!(a7 == "") && !(a7 == "00") && !GClass126.bool_0)
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6067"), "", true, 3000);
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
				return;
			}
			GClass104 gclass = new GClass104();
			gclass.byte_0 = new byte[][]
			{
				dataItem.byte_0[1]
			};
			gclass.string_5 = dataItem.string_5;
			gclass.string_2 = GClass107.smethod_3(118090);
			gclass.int_0 = 1;
			gclass.int_1 = 1;
			bool flag12 = true;
			int num12 = 1;
			while (num12 <= 8 && flag12)
			{
				this.gform9_0 = new GForm9(string.Format(GClass121.smethod_6("6068"), num12), GClass121.smethod_6("6069"), GClass121.smethod_6("6070"), true, 0);
				this.gform9_0.ShowDialog();
				flag12 = this.gform9_0.method_1();
				this.gform9_0 = null;
				if (this.gclass11_0 == null)
				{
					return;
				}
				if (flag12)
				{
					this.gform9_0 = new GForm9(string.Format(GClass121.smethod_6("6071"), num12), GClass121.smethod_6("6072"), "", false, 0);
					this.gclass11_0.method_27(gclass);
					this.gform9_0.ShowDialog();
					this.gform9_0 = null;
					if (this.gclass11_0 == null)
					{
						return;
					}
					if (this.gclass11_0.method_16().StartsWith("00"))
					{
						GClass126.smethod_2(string.Format(GClass121.smethod_6("6071"), num12) + GClass107.smethod_3(118101) + GClass121.smethod_6("1092"), 2);
					}
					else
					{
						GClass126.smethod_2(string.Format(GClass121.smethod_6("6071"), num12) + GClass107.smethod_3(118110) + GClass121.smethod_6("1093"), 2);
					}
				}
				if (this.gclass11_0.method_16().StartsWith("00") || GClass126.bool_0)
				{
					num12++;
				}
			}
			num12--;
			GClass104 gclass2 = new GClass104();
			gclass2.byte_0 = new byte[][]
			{
				dataItem.byte_0[2]
			};
			bool flag13 = false;
			List<string> list = new List<string>();
			for (int num13 = 0; num13 < dataItem.string_5.Length; num13++)
			{
				if (flag13)
				{
					list.Add(dataItem.string_5[num13]);
				}
				if (dataItem.string_5[num13].StartsWith("00000000"))
				{
					flag13 = true;
				}
			}
			gclass2.string_5 = list.ToArray();
			gclass2.string_2 = GClass107.smethod_3(118136);
			gclass2.int_0 = 1;
			gclass2.int_1 = 1;
			if (this.gclass11_0 == null)
			{
				return;
			}
			this.gform9_0 = new GForm9(GClass121.smethod_6("6073"), GClass121.smethod_6("1052"), "", false, 0);
			this.gclass11_0.method_27(gclass2);
			this.gform9_0.ShowDialog();
			this.gform9_0 = null;
			if (this.gclass11_0.method_16().StartsWith("00"))
			{
				GClass126.smethod_2(GClass121.smethod_6("6073") + GClass107.smethod_3(118152) + GClass121.smethod_6("1092"), 2);
				return;
			}
			GClass126.smethod_2(GClass121.smethod_6("6073") + GClass107.smethod_3(118166) + GClass121.smethod_6("1093"), 2);
			return;
		}
		else if (dataItem.string_2.Contains(GClass107.smethod_3(118174)))
		{
			this.gform9_0 = new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("6078"), GClass121.smethod_6("1055"), true, 0);
			this.gform9_0.ShowDialog();
			if (this.gform9_0 == null)
			{
				return;
			}
			if (!this.gform9_0.method_1())
			{
				this.gform9_0 = null;
				return;
			}
			Thread.Sleep(700);
			this.gform9_0 = new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("6079"), GClass121.smethod_6("1055"), true, 0);
			this.gform9_0.ShowDialog();
			if (this.gform9_0 == null)
			{
				return;
			}
			if (!this.gform9_0.method_1())
			{
				this.gform9_0 = null;
				return;
			}
			this.gform9_0 = null;
			flag = false;
			if (this.gclass11_0 == null)
			{
				return;
			}
			string a8;
			if (dataItem.string_2.Contains(GClass107.smethod_3(118187)))
			{
				a8 = this.gclass11_0.vmethod_0(dataItem.byte_0[0], GClass107.smethod_3(118214), 0, 1, new string[0], GClass107.smethod_3(118214));
				if (a8 == "02")
				{
					a8 = "";
				}
			}
			else
			{
				a8 = this.gclass11_0.vmethod_0(dataItem.byte_0[0], GClass107.smethod_3(118267), 1, 1, new string[0], GClass107.smethod_3(118267));
			}
			if (!(a8 == "") && !(a8 == "00") && !GClass126.bool_0)
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6067"), "", true, 3000);
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
				return;
			}
			GClass104 gclass3 = new GClass104();
			gclass3.byte_0 = new byte[][]
			{
				dataItem.byte_0[1]
			};
			gclass3.string_5 = dataItem.string_5;
			gclass3.string_2 = GClass107.smethod_3(118328);
			gclass3.int_0 = 1;
			gclass3.int_1 = 1;
			bool flag14 = true;
			int num14 = 1;
			bool flag15 = false;
			while (num14 <= 8 && flag14)
			{
				this.gform9_0 = new GForm9(string.Format(GClass121.smethod_6("6074"), num14), GClass121.smethod_6("1059"), GClass121.smethod_6("6075"), true, 0);
				this.gform9_0.ShowDialog();
				if (this.gform9_0 == null)
				{
					return;
				}
				flag14 = this.gform9_0.method_1();
				this.gform9_0 = null;
				if (this.gclass11_0 == null)
				{
					return;
				}
				if (flag14)
				{
					this.gform9_0 = new GForm9(string.Format(GClass121.smethod_6("6076"), num14), GClass121.smethod_6("1052"), "", false, 0);
					this.gclass11_0.method_27(gclass3);
					this.gform9_0.ShowDialog();
					this.gform9_0 = null;
					byte[] array20 = GClass127.smethod_32(this.gclass11_0.method_16());
					if (array20.Length == 2 && (array20[1] & 48) == 16)
					{
						flag15 = true;
					}
					if (this.gclass11_0 == null)
					{
						return;
					}
					if (this.gclass11_0.method_16().StartsWith("00"))
					{
						GClass126.smethod_2(string.Format(GClass121.smethod_6("6076"), num14) + GClass107.smethod_3(118351) + GClass121.smethod_6("1092"), 2);
					}
					else
					{
						GClass126.smethod_2(string.Format(GClass121.smethod_6("6076"), num14) + GClass107.smethod_3(118359) + GClass121.smethod_6("1093"), 2);
					}
					if (this.gclass11_0.method_16().StartsWith("00") || GClass126.bool_0)
					{
						num14++;
					}
				}
			}
			num14--;
			bool flag16 = false;
			this.gform9_0 = new GForm9(GClass121.smethod_6("6077"), string.Format(GClass121.smethod_6("6080"), num14), GClass121.smethod_6("1055"), true, 0);
			this.gform9_0.ShowDialog();
			if (this.gform9_0 == null)
			{
				return;
			}
			if (!this.gform9_0.method_1())
			{
				flag16 = true;
			}
			this.gform9_0 = null;
			if (num14 == 0 && !flag16)
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6077"), GClass121.smethod_6("6052"), "", true, 2000);
				this.gform9_0.ShowDialog();
				flag16 = true;
				this.gform9_0 = null;
			}
			if (!flag16 && flag15)
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("6084"), GClass121.smethod_6("1055"), true, 0);
				this.gform9_0.ShowDialog();
				if (this.gform9_0 == null)
				{
					return;
				}
				if (!this.gform9_0.method_1())
				{
					this.gform9_0 = null;
					flag16 = true;
				}
			}
			if (!flag16)
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6077"), GClass121.smethod_6("6083"), GClass121.smethod_6("1055"), true, 0);
				this.gform9_0.ShowDialog();
				if (this.gform9_0 == null)
				{
					return;
				}
				if (!this.gform9_0.method_1())
				{
					this.gform9_0 = null;
					flag16 = true;
				}
			}
			if (flag16)
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6057"), GClass121.smethod_6("6060"), GClass121.smethod_6("1059"), true, 0);
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
				if (this.gclass11_0 == null)
				{
					return;
				}
				this.gclass11_0.method_30(false);
				return;
			}
			else
			{
				GClass104 gclass4 = new GClass104();
				gclass4.byte_0 = new byte[][]
				{
					dataItem.byte_0[2]
				};
				bool flag17 = false;
				List<string> list2 = new List<string>();
				for (int num15 = 0; num15 < dataItem.string_5.Length; num15++)
				{
					if (flag17)
					{
						list2.Add(dataItem.string_5[num15]);
					}
					if (dataItem.string_5[num15].StartsWith("00000000"))
					{
						flag17 = true;
					}
				}
				gclass4.string_5 = list2.ToArray();
				gclass4.string_2 = GClass107.smethod_3(118361);
				gclass4.int_0 = 1;
				gclass4.int_1 = 1;
				if (this.gclass11_0 == null)
				{
					return;
				}
				this.gform9_0 = new GForm9(GClass121.smethod_6("6077"), GClass121.smethod_6("1052"), "", false, 0);
				this.gclass11_0.method_27(gclass4);
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
				if (this.gclass11_0.method_16().StartsWith("00"))
				{
					GClass126.smethod_2(GClass121.smethod_6("6077") + GClass107.smethod_3(118371) + GClass121.smethod_6("1092"), 2);
				}
				else
				{
					GClass126.smethod_2(GClass121.smethod_6("6077") + GClass107.smethod_3(118391) + GClass121.smethod_6("1093"), 2);
				}
				if (this.gclass11_0 == null)
				{
					return;
				}
				this.gclass11_0.method_30(false);
				return;
			}
		}
		else if (dataItem.string_2.Contains(GClass107.smethod_3(118421)))
		{
			this.gform9_0 = new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("6078"), GClass121.smethod_6("1055"), true, 0);
			this.gform9_0.ShowDialog();
			if (this.gform9_0 == null)
			{
				return;
			}
			if (!this.gform9_0.method_1())
			{
				this.gform9_0 = null;
				return;
			}
			this.gform9_0 = null;
			flag = false;
			if (this.gclass11_0 == null)
			{
				return;
			}
			string a9;
			if (dataItem.string_2.Contains(GClass107.smethod_3(118437)))
			{
				a9 = this.gclass11_0.vmethod_0(dataItem.byte_0[0], GClass107.smethod_3(118444), 0, 1, new string[0], GClass107.smethod_3(118444));
				if (a9 == "02")
				{
					a9 = "";
				}
			}
			else
			{
				a9 = this.gclass11_0.vmethod_0(dataItem.byte_0[0], GClass107.smethod_3(118515), 1, 1, new string[0], GClass107.smethod_3(118515));
			}
			if (!(a9 == "") && !(a9 == "00") && !GClass126.bool_0)
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6052"), GClass121.smethod_6("6067"), "", true, 3000);
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
				return;
			}
			GClass104 gclass5 = new GClass104();
			gclass5.byte_0 = new byte[][]
			{
				dataItem.byte_0[1],
				dataItem.byte_0[3],
				dataItem.byte_0[5],
				dataItem.byte_0[7],
				dataItem.byte_0[9]
			};
			gclass5.string_5 = dataItem.string_5;
			gclass5.string_2 = GClass107.smethod_3(118575);
			gclass5.int_0 = 1;
			gclass5.int_1 = 1;
			bool flag18 = true;
			int num16 = 1;
			while (num16 <= 8 && flag18)
			{
				this.gform9_0 = new GForm9(string.Format(GClass121.smethod_6("6085"), num16), GClass121.smethod_6("6086"), GClass121.smethod_6("6087"), true, 0);
				this.gform9_0.ShowDialog();
				if (this.gform9_0 == null)
				{
					return;
				}
				flag18 = this.gform9_0.method_1();
				this.gform9_0 = null;
				if (this.gclass11_0 == null)
				{
					return;
				}
				if (flag18)
				{
					this.gform9_0 = new GForm9(string.Format(GClass121.smethod_6("6088"), num16), GClass121.smethod_6("6089"), "", false, 0);
					this.gclass11_0.method_27(gclass5);
					this.gform9_0.ShowDialog();
					this.gform9_0 = null;
					if (this.gclass11_0 == null)
					{
						return;
					}
					if (this.gclass11_0.method_16().StartsWith("00"))
					{
						GClass126.smethod_2(string.Format(GClass121.smethod_6("6088"), num16) + GClass107.smethod_3(118587) + GClass121.smethod_6("1092"), 2);
					}
					else
					{
						GClass126.smethod_2(string.Format(GClass121.smethod_6("6088"), num16) + GClass107.smethod_3(118624) + GClass121.smethod_6("1093"), 2);
					}
					if (this.gclass11_0.method_16().StartsWith("00") || GClass126.bool_0)
					{
						num16++;
					}
				}
			}
			num16--;
			bool flag19 = false;
			this.gform9_0 = new GForm9(GClass121.smethod_6("6090"), string.Format(GClass121.smethod_6("6092"), num16), GClass121.smethod_6("1055"), true, 0);
			this.gform9_0.ShowDialog();
			if (this.gform9_0 == null)
			{
				return;
			}
			if (!this.gform9_0.method_1())
			{
				flag19 = true;
			}
			this.gform9_0 = null;
			if (num16 == 0 && !flag19)
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6090"), GClass121.smethod_6("6052"), "", true, 2000);
				this.gform9_0.ShowDialog();
				flag19 = true;
				this.gform9_0 = null;
			}
			if (!flag19)
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6090"), GClass121.smethod_6("6083"), GClass121.smethod_6("1055"), true, 0);
				this.gform9_0.ShowDialog();
				if (this.gform9_0 == null)
				{
					return;
				}
				if (!this.gform9_0.method_1())
				{
					this.gform9_0 = null;
					flag19 = true;
				}
			}
			if (flag19)
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6082"), GClass121.smethod_6("6060"), GClass121.smethod_6("1059"), true, 0);
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
				if (this.gclass11_0 == null)
				{
					return;
				}
				this.gclass11_0.method_30(false);
				return;
			}
			else
			{
				GClass104 gclass6 = new GClass104();
				gclass6.byte_0 = new byte[][]
				{
					dataItem.byte_0[2],
					dataItem.byte_0[4],
					dataItem.byte_0[6],
					dataItem.byte_0[8],
					dataItem.byte_0[10]
				};
				bool flag20 = false;
				List<string> list3 = new List<string>();
				for (int num17 = 0; num17 < dataItem.string_5.Length; num17++)
				{
					if (flag20)
					{
						list3.Add(dataItem.string_5[num17]);
					}
					if (dataItem.string_5[num17].StartsWith("00000000"))
					{
						flag20 = true;
					}
				}
				gclass6.string_5 = list3.ToArray();
				gclass6.string_2 = GClass107.smethod_3(118658);
				gclass6.int_0 = 1;
				gclass6.int_1 = 1;
				if (this.gclass11_0 == null)
				{
					return;
				}
				this.gform9_0 = new GForm9(GClass121.smethod_6("6090"), GClass121.smethod_6("1052"), "", false, 0);
				this.gclass11_0.method_27(gclass6);
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
				if (this.gclass11_0 == null)
				{
					return;
				}
				if (this.gclass11_0.method_16().StartsWith("00"))
				{
					GClass126.smethod_2(GClass121.smethod_6("6090") + GClass107.smethod_3(118683) + GClass121.smethod_6("1092"), 2);
				}
				else
				{
					GClass126.smethod_2(GClass121.smethod_6("6090") + GClass107.smethod_3(118717) + GClass121.smethod_6("1093"), 2);
				}
				this.gclass11_0.method_30(false);
				return;
			}
		}
		else if (dataItem.string_2.Contains(GClass107.smethod_3(118718)))
		{
			this.gform9_0 = new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("6078"), GClass121.smethod_6("1055"), true, 0);
			this.gform9_0.ShowDialog();
			if (this.gform9_0 == null)
			{
				return;
			}
			if (!this.gform9_0.method_1())
			{
				this.gform9_0 = null;
				return;
			}
			this.gform9_0 = null;
			flag = false;
			GClass104 gclass7 = new GClass104();
			gclass7.byte_0 = new byte[][]
			{
				dataItem.byte_0[0],
				dataItem.byte_0[2],
				dataItem.byte_0[4],
				dataItem.byte_0[6],
				dataItem.byte_0[8]
			};
			gclass7.string_5 = dataItem.string_5;
			gclass7.string_2 = GClass107.smethod_3(118753);
			gclass7.int_0 = 1;
			gclass7.int_1 = 1;
			GClass104 gclass8 = new GClass104();
			gclass8.byte_0 = new byte[][]
			{
				dataItem.byte_0[1],
				dataItem.byte_0[3],
				dataItem.byte_0[5],
				dataItem.byte_0[7],
				dataItem.byte_0[9]
			};
			bool flag21 = false;
			List<string> list4 = new List<string>();
			for (int num18 = 0; num18 < dataItem.string_5.Length; num18++)
			{
				if (flag21)
				{
					list4.Add(dataItem.string_5[num18]);
				}
				if (dataItem.string_5[num18].StartsWith("0000"))
				{
					flag21 = true;
				}
			}
			gclass8.string_5 = list4.ToArray();
			gclass8.string_2 = GClass107.smethod_3(118771);
			gclass8.int_0 = 1;
			gclass8.int_1 = 1;
			bool flag22 = true;
			int num19 = 1;
			while (num19 <= 8 && flag22)
			{
				this.gform9_0 = new GForm9(string.Format(GClass121.smethod_6("6085"), num19), GClass121.smethod_6("6086"), GClass121.smethod_6("6087"), true, 0);
				this.gform9_0.ShowDialog();
				if (this.gform9_0 == null)
				{
					return;
				}
				flag22 = this.gform9_0.method_1();
				this.gform9_0 = null;
				if (this.gclass11_0 == null)
				{
					return;
				}
				if (flag22)
				{
					this.gform9_0 = new GForm9(string.Format(GClass121.smethod_6("6088"), num19), GClass121.smethod_6("6089"), "", false, 0);
					this.gclass11_0.method_27(gclass7);
					this.gform9_0.ShowDialog();
					this.gform9_0 = null;
					if (this.gclass11_0 == null)
					{
						return;
					}
					if (this.gclass11_0.method_16().StartsWith("00"))
					{
						GClass126.smethod_2(string.Format(GClass121.smethod_6("6088"), num19) + GClass107.smethod_3(118785) + GClass121.smethod_6("1092"), 2);
						Thread.Sleep(100);
						this.gform9_0 = new GForm9(GClass121.smethod_6("6090"), GClass121.smethod_6("1052"), "", false, 0);
						this.gclass11_0.method_27(gclass8);
						this.gform9_0.ShowDialog();
						this.gform9_0 = null;
						if (this.gclass11_0 == null)
						{
							return;
						}
						if (this.gclass11_0.method_16().StartsWith("00"))
						{
							GClass126.smethod_2(GClass121.smethod_6("6090") + GClass107.smethod_3(118811) + GClass121.smethod_6("1092"), 2);
						}
						else
						{
							GClass126.smethod_2(GClass121.smethod_6("6090") + GClass107.smethod_3(118836) + GClass121.smethod_6("1093"), 2);
						}
					}
					else
					{
						GClass126.smethod_2(string.Format(GClass121.smethod_6("6088"), num19) + GClass107.smethod_3(118858) + GClass121.smethod_6("1093"), 2);
					}
					if (this.gclass11_0.method_16().StartsWith("00") || GClass126.bool_0)
					{
						num19++;
					}
				}
			}
			num19--;
			this.gform9_0 = new GForm9(GClass121.smethod_6("6051"), string.Format(GClass121.smethod_6("6093"), num19), GClass121.smethod_6("1059"), true, 0);
			this.gform9_0.ShowDialog();
			this.gform9_0 = null;
			if (this.gclass11_0 == null)
			{
				return;
			}
			this.gclass11_0.method_30(false);
			return;
		}
		else if (dataItem.string_2.Contains(GClass107.smethod_3(118894)))
		{
			flag = false;
			GClass104 gclass9 = new GClass104();
			gclass9.byte_0 = new byte[][]
			{
				dataItem.byte_0[0]
			};
			gclass9.string_5 = dataItem.string_5;
			gclass9.string_2 = "";
			gclass9.int_0 = 1;
			gclass9.int_1 = 1;
			bool flag23 = true;
			int num20 = 1;
			while (num20 <= 8 && flag23)
			{
				this.gform9_0 = new GForm9(string.Format(GClass121.smethod_6("6068"), num20), GClass121.smethod_6("6069"), GClass121.smethod_6("6070"), true, 0);
				this.gform9_0.ShowDialog();
				if (this.gform9_0 == null)
				{
					return;
				}
				flag23 = this.gform9_0.method_1();
				this.gform9_0 = null;
				if (flag23)
				{
					this.gform9_0 = new GForm9(string.Format(GClass121.smethod_6("6071"), num20), GClass121.smethod_6("6072"), "", false, 0);
					this.gclass11_0.method_27(gclass9);
					this.gform9_0.ShowDialog();
					this.gform9_0 = null;
					if (this.gclass11_0.method_16() == "00")
					{
						GClass126.smethod_2(string.Format(GClass121.smethod_6("6071"), num20) + GClass107.smethod_3(118924) + GClass121.smethod_6("1092"), 2);
					}
					else
					{
						GClass126.smethod_2(string.Format(GClass121.smethod_6("6071"), num20) + GClass107.smethod_3(118969) + GClass121.smethod_6("1093"), 2);
					}
				}
				if (this.gclass11_0.method_16() == "00" || GClass126.bool_0)
				{
					num20++;
				}
			}
			GClass104 gclass10 = new GClass104();
			gclass10.byte_0 = new byte[][]
			{
				dataItem.byte_0[1]
			};
			gclass10.string_5 = dataItem.string_5;
			gclass10.string_2 = "";
			gclass10.int_0 = 1;
			gclass10.int_1 = 1;
			GClass104 gclass11 = new GClass104();
			gclass11.byte_0 = new byte[][]
			{
				dataItem.byte_0[2]
			};
			gclass11.string_5 = dataItem.string_5;
			gclass11.string_2 = "";
			gclass11.int_0 = 1;
			gclass11.int_1 = 1;
			this.gform9_0 = new GForm9(GClass121.smethod_6("6073"), GClass121.smethod_6("1052"), "", false, 0);
			this.gclass11_0.method_27(gclass10);
			this.gclass11_0.method_27(gclass11);
			this.gform9_0.ShowDialog();
			this.gform9_0 = null;
			if (this.gclass11_0.method_16() == "00")
			{
				GClass126.smethod_2(GClass121.smethod_6("6073") + GClass107.smethod_3(119017) + GClass121.smethod_6("1092"), 2);
				return;
			}
			GClass126.smethod_2(GClass121.smethod_6("6073") + GClass107.smethod_3(119054) + GClass121.smethod_6("1093"), 2);
			return;
		}
		else
		{
			string text20 = " ";
			if (dataItem.string_2.Contains(GClass107.smethod_3(119079)))
			{
				text20 = GClass121.smethod_6("1059");
			}
			else if (flag)
			{
				text20 = GClass121.smethod_6("6059");
			}
			if (dataItem.string_2.Contains(GClass107.smethod_3(119089)))
			{
				string b4 = "0";
				if (dataItem.string_2.Contains(GClass107.smethod_3(119134)))
				{
					b4 = "1";
				}
				if (dataItem.string_2.Contains(GClass107.smethod_3(119160)))
				{
					b4 = "2";
				}
				if (dataItem.string_2.Contains(GClass107.smethod_3(119166)))
				{
					b4 = "3";
				}
				if (dataItem.string_2.Contains(GClass107.smethod_3(119210)))
				{
					b4 = "4";
				}
				List<TableDataRowP> list5 = new List<TableDataRowP>();
				int num21 = 0;
				while (num21 < this.list_0.Count && GClass126.bool_13)
				{
					GClass104 gclass12 = this.list_0[num21];
					if (gclass12.string_4 == b4)
					{
						gclass12.bool_0 = true;
						list5.Add(new TableDataRowP(gclass12));
					}
					else
					{
						gclass12.bool_0 = false;
					}
					num21++;
				}
				GClass126.bool_22 = true;
				this.method_18(true, false);
				GClass126.smethod_0().string_0 = GClass107.smethod_3(119248);
				this.comboBox_3.Items[this.comboBox_3.Items.Count - 1] = GClass126.smethod_0().string_0;
				this.comboBox_3.SelectedIndex = this.comboBox_3.Items.Count - 1;
				GClass126.bool_12 = true;
				GClass126.int_5 = 0;
				if (this.gclass11_0 == null)
				{
					return;
				}
				this.gform10_0 = new GForm10(GClass121.smethod_6(dataItem.string_4), GClass121.smethod_6("1052"), text20, false, 0, list5);
				this.gclass11_0.method_27(dataItem);
				this.gform10_0.ShowDialog();
				this.gform10_0 = null;
				this.method_4();
				for (int num22 = 0; num22 < this.list_0.Count; num22++)
				{
					this.list_0[num22].bool_0 = false;
				}
				GClass126.bool_22 = false;
			}
			else
			{
				if (this.gclass11_0 == null)
				{
					return;
				}
				this.gform9_0 = new GForm9(GClass121.smethod_6(dataItem.string_4), GClass121.smethod_6("1052"), text20, false, 0);
				this.gclass11_0.method_27(dataItem);
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
			}
			if (dataItem.string_2.Contains(GClass107.smethod_3(119292)) && this.gclass11_0.method_17())
			{
				this.gform9_0 = new GForm9(GClass121.smethod_6("6057"), "", GClass121.smethod_6("1059"), true, 0);
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
				if (this.gclass11_0 != null)
				{
					this.gclass11_0.r0(false, true);
				}
			}
		}
	}

	// Token: 0x060004F9 RID: 1273 RVA: 0x000B82BC File Offset: 0x000B64BC
	private void method_14()
	{
		if (GClass127.smethod_42())
		{
			try
			{
				base.Invoke(new GForm8.Delegate5(this.method_12), new object[0]);
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x060004FA RID: 1274 RVA: 0x000B8300 File Offset: 0x000B6500
	private void tabControl_0_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Right && !e.Alt && this.tabControl_0.SelectedTab == this.tabPage_4)
		{
			e.Handled = true;
			for (int i = 0; i < this.gclass114_0.Controls.Count; i++)
			{
				((GClass115)this.gclass114_0.Controls[i]).ScrollIncrease(e.Control);
			}
			this.gclass114_0.Invalidate();
			this.gclass114_0.Focus();
			return;
		}
		if (e.KeyCode == Keys.Left && !e.Alt && this.tabControl_0.SelectedTab == this.tabPage_4)
		{
			e.Handled = true;
			for (int j = 0; j < this.gclass114_0.Controls.Count; j++)
			{
				((GClass115)this.gclass114_0.Controls[j]).ScrollDescrease(e.Control);
			}
			this.gclass114_0.Invalidate();
			this.gclass114_0.Focus();
		}
	}

	// Token: 0x060004FB RID: 1275 RVA: 0x00002F0A File Offset: 0x0000110A
	private void GForm8_KeyUp(object sender, KeyEventArgs e)
	{
	}

	// Token: 0x060004FC RID: 1276 RVA: 0x000B840C File Offset: 0x000B660C
	private void method_15(string string_20, int int_3)
	{
		if (int_3 == 2)
		{
			this.Text = GClass107.smethod_3(110950) + string_20 + GClass107.smethod_3(110991);
			return;
		}
		if (int_3 == 1)
		{
			this.Text = GClass107.smethod_3(111032) + string_20 + GClass107.smethod_3(111066);
		}
	}

	// Token: 0x060004FD RID: 1277 RVA: 0x000B8464 File Offset: 0x000B6664
	private void dataGridView_0_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
	{
		if (((TableDataRowP)this.dataGridView_0.Rows[e.RowIndex].DataBoundItem).getDataItem().string_2 == GClass107.smethod_3(112685))
		{
			this.dataGridView_0.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
			this.dataGridView_0.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
			this.dataGridView_0.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Navy;
			this.dataGridView_0.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Navy;
			return;
		}
		if (((TableDataRowP)this.dataGridView_0.Rows[e.RowIndex].DataBoundItem).getDataItem().string_2 == GClass107.smethod_3(112701))
		{
			this.dataGridView_0.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
			this.dataGridView_0.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
		}
	}

	// Token: 0x060004FE RID: 1278 RVA: 0x000B85CC File Offset: 0x000B67CC
	private void dataGridView_1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
	{
		if (!((TableDataRowP)this.dataGridView_1.Rows[e.RowIndex].DataBoundItem).Selected)
		{
			this.dataGridView_1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Navy;
			this.dataGridView_1.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Navy;
			return;
		}
		this.dataGridView_1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
		this.dataGridView_1.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
	}

	// Token: 0x060004FF RID: 1279 RVA: 0x000B8698 File Offset: 0x000B6898
	private void method_16()
	{
		string moduleName = Process.GetCurrentProcess().MainModule.ModuleName;
		if (GClass126.bool_23)
		{
			this.method_47(moduleName);
			return;
		}
		this.method_41(moduleName);
	}

	// Token: 0x06000500 RID: 1280 RVA: 0x000B86CC File Offset: 0x000B68CC
	private void gclass114_0_Paint(object sender, PaintEventArgs e)
	{
		for (int i = 0; i < this.gclass114_0.Controls.Count; i++)
		{
			this.gclass114_0.Controls[i].Invalidate();
		}
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x000B870C File Offset: 0x000B690C
	private void dataGridView_5_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (this.int_0 == 0)
		{
			this.string_11 = "";
		}
		if (this.timer_2.Interval < 500)
		{
			this.int_0 = 10;
		}
		else
		{
			this.int_0 = 4;
		}
		this.string_11 += e.KeyChar.ToString().ToUpper();
		this.label_16.Text = this.string_11;
		for (int i = 0; i < this.dataGridView_5.Rows.Count; i++)
		{
			if (((string)this.dataGridView_5.Rows[i].Cells[this.dataGridViewTextBoxColumn_4.Name].Value).ToUpper().StartsWith(this.string_11))
			{
				this.dataGridView_5.CurrentCell = this.dataGridView_5.Rows[i].Cells[2];
				this.dataGridView_5.Rows[i].Selected = true;
				this.dataGridView_5.FirstDisplayedScrollingRowIndex = i;
				IL_114:
				this.dataGridView_5_SelectionChanged(null, null);
				return;
			}
		}
		goto IL_114;
	}

	// Token: 0x06000502 RID: 1282 RVA: 0x00003EE4 File Offset: 0x000020E4
	private void method_17(object sender, EventArgs e)
	{
		this.toolTip_0.Active = false;
	}

	// Token: 0x06000503 RID: 1283 RVA: 0x000B8838 File Offset: 0x000B6A38
	private void dataGridView_1_KeyUp(object sender, KeyEventArgs e)
	{
		if (!e.Alt && !e.Control && !e.Shift && e.KeyCode == Keys.Space)
		{
			TableDataRowP tableDataRowP = (TableDataRowP)this.dataGridView_1.SelectedRows[0].DataBoundItem;
			if (!tableDataRowP.Selected && !GClass126.bool_13)
			{
				int num = 0;
				for (int i = 0; i < this.list_0.Count; i++)
				{
					if (this.list_0[i].bool_0)
					{
						num++;
						if (num > 4)
						{
							break;
						}
					}
				}
				if (num < 4)
				{
					tableDataRowP.Selected = !tableDataRowP.Selected;
				}
				else
				{
					MessageBox.Show(GClass121.smethod_6("1073"), GClass121.smethod_6("1070"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				tableDataRowP.Selected = !tableDataRowP.Selected;
			}
			if (this.checkBox_0.Enabled && this.checkBox_0.Checked)
			{
				int firstDisplayedScrollingRowIndex = this.dataGridView_1.FirstDisplayedScrollingRowIndex;
				int index = this.dataGridView_1.SelectedRows[0].Index;
				this.button_8_Click(null, null);
				if (this.dataGridView_1.Rows.Count > index)
				{
					this.dataGridView_1.Rows[index].Selected = true;
					this.dataGridView_1.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
					this.dataGridView_1.CurrentCell = this.dataGridView_1.Rows[index].Cells[0];
				}
			}
			else
			{
				this.dataGridView_1.UpdateCellValue(0, this.dataGridView_1.SelectedRows[0].Index);
			}
			e.Handled = true;
		}
	}

	// Token: 0x06000504 RID: 1284 RVA: 0x000B89EC File Offset: 0x000B6BEC
	private void panel_18_Click(object sender, EventArgs e)
	{
		if (!this.panel_18.Visible)
		{
			return;
		}
		GClass126.smethod_2(GClass107.smethod_3(112477), 0);
		PdfDocument pdfDocument = new GClass129().method_0(GClass126.stringBuilder_1);
		string str = GClass125.smethod_30() + GClass107.smethod_3(112523);
		string text = "";
		int num = 1;
		while (num < 10 && text == "")
		{
			try
			{
				text = str + num.ToString() + GClass107.smethod_3(112547);
				GClass126.smethod_2(GClass107.smethod_3(112555), 0);
				pdfDocument.Save(text);
				num = 100;
			}
			catch (Exception)
			{
				num++;
				text = "";
			}
		}
		if (text == "")
		{
			MessageBox.Show(GClass121.smethod_6("1250"), GClass107.smethod_3(112561), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		try
		{
			Process.Start(GClass107.smethod_3(112599), text);
		}
		catch (Exception)
		{
			MessageBox.Show(GClass121.smethod_6("1251"), GClass107.smethod_3(112640), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	// Token: 0x06000505 RID: 1285 RVA: 0x00003EF2 File Offset: 0x000020F2
	private void button_11_Click(object sender, EventArgs e)
	{
		new GForm7(false).ShowDialog();
		this.button_20.Visible = (GClass126.smethod_8() > 50);
		this.panel_18.Visible = false;
		this.method_45();
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x000B8B18 File Offset: 0x000B6D18
	private void dataGridView_7_Leave(object sender, EventArgs e)
	{
		if (this.dataGridView_6.SelectedRows.Count > 0)
		{
			this.dataGridView_6.SelectedRows[0].DefaultCellStyle.SelectionBackColor = ((this.splitContainer_0.ActiveControl == this.dataGridView_6) ? Color.FromArgb(248, 248, 168) : Color.Gray);
		}
		if (this.dataGridView_5.SelectedRows.Count > 0)
		{
			this.dataGridView_5.SelectedRows[0].DefaultCellStyle.SelectionBackColor = ((this.splitContainer_0.ActiveControl == this.dataGridView_5) ? Color.FromArgb(248, 248, 168) : Color.Gray);
		}
		if (this.dataGridView_7.SelectedRows.Count > 0)
		{
			this.dataGridView_7.SelectedRows[0].DefaultCellStyle.SelectionBackColor = ((this.splitContainer_0.ActiveControl == this.dataGridView_7) ? Color.FromArgb(248, 248, 168) : Color.Gray);
		}
		if (this.dataGridView_4.SelectedRows.Count > 0)
		{
			this.dataGridView_4.SelectedRows[0].DefaultCellStyle.SelectionBackColor = ((this.splitContainer_0.ActiveControl == this.dataGridView_4) ? Color.FromArgb(248, 248, 168) : Color.Gray);
		}
	}

	// Token: 0x06000507 RID: 1287 RVA: 0x000B8C98 File Offset: 0x000B6E98
	private void method_18(bool bool_4, bool bool_5)
	{
		GClass126.bool_12 = false;
		if (bool_4)
		{
			List<GClass104> list = new List<GClass104>();
			for (int i = 0; i < this.list_0.Count; i++)
			{
				GClass104 gclass = this.list_0[i];
				if (gclass.bool_0)
				{
					list.Add(gclass);
					if ((!GClass126.bool_13 && list.Count > 4) || list.Count > 25)
					{
						break;
					}
				}
			}
			if (bool_5)
			{
				this.comboBox_1.Items.Clear();
				this.comboBox_1.Items.Add("MAX");
				int num = 1;
				while (num < GClass126.int_2.Length && GClass126.int_2[num] >= GClass126.int_6)
				{
					this.comboBox_1.Items.Add((60000 / GClass126.int_2[num]).ToString() + "/min");
					num++;
				}
				this.comboBox_1.SelectedIndex = 0;
			}
			GClass126.int_11 = ((GClass126.list_1.Count == 0) ? 0 : (GClass126.list_1.Count - 1));
			if (GClass126.smethod_0() != null && GClass126.smethod_0().list_3.Count <= 0)
			{
				bool flag = true;
				GClass105 gclass2 = GClass126.list_1[GClass126.list_1.Count - 1];
				if (gclass2 != null && gclass2.list_8 != null && gclass2.list_8.Count == list.Count)
				{
					flag = false;
					int num2 = 0;
					while (num2 < gclass2.list_8.Count && num2 < list.Count)
					{
						if (gclass2.list_8[num2].string_0 != list[num2].string_0 || gclass2.list_8[num2].int_2 != list[num2].int_2 || gclass2.list_8[num2].string_1 != list[num2].string_1)
						{
							flag = true;
							break;
						}
						num2++;
					}
				}
				if (flag)
				{
					GClass126.list_1[GClass126.list_1.Count - 1] = new GClass105(this.textBox_4.Text, list);
				}
				GClass126.int_11 = GClass126.list_1.Count - 1;
				this.comboBox_3.SelectedIndex = this.comboBox_3.Items.Count - 1;
			}
			else
			{
				if (!GClass126.bool_13 && GClass126.list_1.Count > 1)
				{
					GClass126.list_1.RemoveAt(0);
					this.comboBox_3.Items.RemoveAt(0);
				}
				GClass126.list_1.Add(new GClass105(this.textBox_4.Text, list));
				GClass126.int_11 = GClass126.list_1.Count - 1;
				this.comboBox_3.Items.Add(GClass107.smethod_3(115313));
				this.comboBox_3.SelectedIndex = this.comboBox_3.Items.Count - 1;
				if (this.textBox_4.Text == "")
				{
					this.textBox_4.Text = GClass107.smethod_3(115346) + (GClass126.int_11 + 1).ToString();
				}
			}
			int num3 = GClass127.smethod_37(this.comboBox_2.SelectedItem);
			GClass126.smethod_0().int_2 = num3;
		}
		this.gclass114_1.Controls.Clear();
		this.gclass114_1.RowStyles.Clear();
		this.gclass114_1.RowCount = GClass126.smethod_0().list_8.Count;
		for (int j = 0; j < GClass126.smethod_0().list_8.Count; j++)
		{
			GClass118 gclass3 = new GClass118(j);
			gclass3.Dock = DockStyle.Fill;
			gclass3.ForeColor = GClass125.smethod_101(j);
			this.gclass114_1.Controls.Add(gclass3);
			this.gclass114_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80f));
		}
		this.gclass114_0.Invalidate();
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x000B90BC File Offset: 0x000B72BC
	private void method_19(string string_20, string string_21, string string_22, bool bool_4, int int_3)
	{
		if (this.gform9_0 != null)
		{
			this.gform9_0.method_8(string_20, string_21, string_22, bool_4, int_3);
		}
		if (this.gform10_0 != null)
		{
			this.gform10_0.method_8(string_20, string_21, string_22, bool_4, int_3);
		}
		if (this.gform11_0 != null)
		{
			this.gform11_0.method_5(string_20, string_21, string_22, bool_4, int_3);
		}
	}

	// Token: 0x06000509 RID: 1289 RVA: 0x000B2CAC File Offset: 0x000B0EAC
	private void method_20()
	{
		if (this.gform9_0 != null)
		{
			this.gform9_0.Close();
		}
		if (this.gform10_0 != null)
		{
			this.gform10_0.Close();
		}
		if (this.gform11_0 != null)
		{
			this.gform11_0.Close();
		}
		this.gform9_0 = null;
		this.gform10_0 = null;
		this.gform11_0 = null;
	}

	// Token: 0x0600050A RID: 1290 RVA: 0x000B9118 File Offset: 0x000B7318
	private void method_21(int int_3)
	{
		int[] array = GClass125.smethod_117(int_3);
		if (!GClass126.bool_13)
		{
			return;
		}
		for (int i = 0; i < this.list_0.Count; i++)
		{
			bool flag = false;
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j] == this.list_0[i].int_2)
				{
					flag = true;
				}
			}
			this.list_0[i].bool_0 = flag;
		}
		this.button_8_Click(null, null);
	}

	// Token: 0x0600050B RID: 1291 RVA: 0x00002F0A File Offset: 0x0000110A
	private void button_25_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x0600050C RID: 1292 RVA: 0x00003F26 File Offset: 0x00002126
	private void label_11_MouseClick(object sender, MouseEventArgs e)
	{
		Process.Start(GClass107.smethod_3(111611));
		this.dataGridView_4.Focus();
	}

	// Token: 0x0600050D RID: 1293 RVA: 0x000B9190 File Offset: 0x000B7390
	private void dataGridView_7_SelectionChanged(object sender, EventArgs e)
	{
		int num = -1;
		int num2 = -1;
		if (this.dataGridView_5.SelectedRows.Count > 0 && this.dataGridView_7.SelectedRows.Count > 0)
		{
			num = (int)this.dataGridView_5.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_3.Name].Value;
			num2 = (int)this.dataGridView_7.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_6.Name].Value;
		}
		DataView dataView = (DataView)this.dataGridView_4.DataSource;
		if (dataView == null)
		{
			return;
		}
		dataView.RowFilter = GClass107.smethod_3(111736) + num.ToString() + GClass107.smethod_3(111759) + num2.ToString();
		dataView.Sort = GClass107.smethod_3(111787);
		this.dataGridView_4.DataSource = dataView;
		this.dataGridView_7_Leave(null, null);
	}

	// Token: 0x0600050E RID: 1294 RVA: 0x000B9290 File Offset: 0x000B7490
	private void method_22()
	{
		if (this.gclass11_0 != null)
		{
			Thread.Sleep(500);
		}
		if (this.gclass11_0 != null)
		{
			this.gclass11_0.r2();
		}
		if (this.gclass11_0 != null)
		{
			Thread.Sleep(500);
		}
		if (this.gclass11_0 != null)
		{
			Thread.Sleep(500);
		}
		if (this.gclass11_0 != null)
		{
			Thread.Sleep(500);
		}
		if (this.gclass11_0 != null)
		{
			Thread.Sleep(500);
		}
		if (this.gclass11_0 != null)
		{
			Thread.Sleep(500);
		}
		base.Invoke(new GForm8.Delegate6(this.method_8), new object[0]);
	}

	// Token: 0x0600050F RID: 1295 RVA: 0x000B9338 File Offset: 0x000B7538
	private void dataGridView_8_SelectionChanged(object sender, EventArgs e)
	{
		if (this.dataGridView_8.SelectedRows.Count > 0)
		{
			this.textBox_5.Text = ((TableDataRowP)this.dataGridView_8.SelectedRows[0].DataBoundItem).getDataItem().string_1;
			return;
		}
		this.textBox_5.Text = "";
	}

	// Token: 0x06000510 RID: 1296 RVA: 0x000B939C File Offset: 0x000B759C
	private void method_23()
	{
		this.button_0.Text = (GClass126.bool_12 ? GClass121.smethod_6("5006") : GClass121.smethod_6("5005"));
		this.button_0.Enabled = (((!GClass126.bool_12 && GClass126.smethod_0().list_8.Count > 0) || GClass126.bool_12) && this.gclass11_0 != null);
		this.comboBox_1.Enabled = (!GClass126.bool_12 && this.gclass11_0 != null);
		this.button_1.Enabled = (GClass126.smethod_0() != null && !GClass126.bool_12 && GClass126.smethod_0().list_0.Count > 0 && GClass126.smethod_0().list_3.Count > 0);
		this.button_12.Enabled = !GClass126.bool_12;
		if (!GClass126.bool_12)
		{
			if (GClass126.smethod_0() != null)
			{
				this.label_3.Text = (GClass126.smethod_0().int_1 / 1000).ToString("F0");
			}
			else
			{
				this.label_3.Text = "";
			}
		}
		this.textBox_4.Enabled = !GClass126.bool_12;
		this.comboBox_3.Enabled = !GClass126.bool_12;
	}

	// Token: 0x06000511 RID: 1297 RVA: 0x000B94E8 File Offset: 0x000B76E8
	private void GForm8_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (this.gclass11_0 != null)
		{
			this.gclass11_0.r0(false, true);
		}
		if (!GClass126.bool_13 && !GClass126.bool_10)
		{
			GClass125.smethod_17("");
		}
		for (int i = 0; i < 10; i++)
		{
			GClass125.smethod_120(i, this.list_7[i].Value);
		}
		GClass125.smethod_138();
		GClass125.smethod_136();
		GClass125.smethod_133();
		GClass126.smethod_14();
		if (GClass126.stopwatch_0 != null && GClass126.stopwatch_0.IsRunning)
		{
			GClass126.stopwatch_0.Stop();
		}
		if (this.bool_0)
		{
			Thread.Sleep(200);
			Process.Start(new ProcessStartInfo(GClass125.smethod_30() + GClass107.smethod_3(111541)));
		}
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x000B95A8 File Offset: 0x000B77A8
	private void button_12_Click(object sender, EventArgs e)
	{
		if (this.openFileDialog_0.ShowDialog() == DialogResult.OK)
		{
			StreamReader streamReader = new StreamReader(File.Open(this.openFileDialog_0.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
			string text = (GClass125.smethod_18() == "Tab") ? GClass107.smethod_3(115431) : GClass125.smethod_18();
			try
			{
				List<GClass104> list = new List<GClass104>();
				string text2 = streamReader.ReadLine();
				string[] array = text2.Split(new string[]
				{
					text
				}, StringSplitOptions.None);
				text2 = streamReader.ReadLine();
				string[] array2 = text2.Split(new string[]
				{
					text
				}, StringSplitOptions.None);
				for (int i = 1; i < array.Length - 1; i++)
				{
					GClass104 gclass = new GClass104();
					gclass.string_0 = array[i].Replace("\"", "");
					gclass.string_3 = array2[i].Replace("\"", "");
					gclass.string_2 = ((gclass.string_3 == "") ? "" : "num");
					if (gclass.string_0 != "DTC" && gclass.string_0 != "TAG")
					{
						list.Add(gclass);
					}
				}
				GClass105 gclass2 = new GClass105(this.openFileDialog_0.SafeFileName, list);
				while ((text2 = streamReader.ReadLine()) != null)
				{
					string[] array3 = text2.Split(new string[]
					{
						text
					}, StringSplitOptions.None);
					for (int j = 0; j < list.Count; j++)
					{
						list[j].method_1(array3[j + 1]);
					}
					int int_ = (int)(Convert.ToDecimal(array3[0]) * 1000m);
					gclass2.method_2(int_);
					if (array3.Length > list.Count + 1 && array3[list.Count + 1].Length > 0)
					{
						gclass2.method_0(array3[list.Count + 1].Replace("\"", ""));
					}
					if (array3.Length > list.Count + 2 && array3[list.Count + 2].Length > 0)
					{
						gclass2.method_1(array3[list.Count + 2].Replace("\"", ""));
					}
				}
				GClass126.list_1.Insert(GClass126.list_1.Count - 1, gclass2);
				this.comboBox_3.Items.Insert(this.comboBox_3.Items.Count - 1, gclass2.string_0);
				GClass126.int_11 = GClass126.list_1.Count - 1;
				this.comboBox_3.SelectedIndex = this.comboBox_3.Items.Count - 2;
				this.comboBox_3_SelectedIndexChanged(null, null);
			}
			catch (Exception)
			{
				MessageBox.Show(GClass107.smethod_3(115437), GClass107.smethod_3(115469), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				streamReader.Close();
			}
		}
	}

	// Token: 0x06000513 RID: 1299 RVA: 0x000B98CC File Offset: 0x000B7ACC
	private void method_24(string string_20)
	{
		if (this.gform9_0 != null)
		{
			string text = this.gform9_0.method_4();
			string text2 = this.gform9_0.method_6();
			this.gform9_0.method_8(text, text2, string_20, false, 0);
		}
		if (this.gform10_0 != null)
		{
			string text3 = this.gform10_0.method_4();
			string text4 = this.gform10_0.method_6();
			this.gform10_0.method_8(text3, text4, string_20, false, 0);
		}
		if (this.gform11_0 != null)
		{
			string text5 = this.gform11_0.method_1();
			string text6 = this.gform11_0.method_3();
			this.gform11_0.method_5(text5, text6, string_20, false, 0);
		}
	}

	// Token: 0x06000514 RID: 1300 RVA: 0x000B9970 File Offset: 0x000B7B70
	private void dataGridView_3_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
	{
		if (((TableDataRowE)this.dataGridView_3.Rows[e.RowIndex].DataBoundItem).getDataItem() != null)
		{
			if (((TableDataRowE)this.dataGridView_3.Rows[e.RowIndex].DataBoundItem).getDataItem().string_0 == "0000")
			{
				if (((TableDataRowE)this.dataGridView_3.Rows[e.RowIndex].DataBoundItem).getDataItem().string_3 == "")
				{
					this.dataGridView_3.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.LightGray;
					this.dataGridView_3.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.LightGray;
					return;
				}
				this.dataGridView_3.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
				this.dataGridView_3.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.DarkGreen;
				return;
			}
			else
			{
				if (!((TableDataRowE)this.dataGridView_3.Rows[e.RowIndex].DataBoundItem).getDataItem().bool_0)
				{
					this.dataGridView_3.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Navy;
					this.dataGridView_3.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Navy;
					return;
				}
				this.dataGridView_3.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
				this.dataGridView_3.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
			}
		}
	}

	// Token: 0x06000515 RID: 1301 RVA: 0x000B9B70 File Offset: 0x000B7D70
	private void timer_2_Tick(object sender, EventArgs e)
	{
		if (!GClass126.bool_13 && GClass126.smethod_1() > 1202018)
		{
			this.timer_2.Enabled = false;
			this.timer_0.Enabled = false;
			MessageBox.Show(GClass121.smethod_6("1072"), GClass121.smethod_6("1070"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			base.Close();
		}
		if (!GClass126.bool_13 && GClass126.smethod_1() > 1134982 && !this.bool_3)
		{
			this.timer_2.Enabled = false;
			MessageBox.Show(GClass121.smethod_6("1071"), GClass121.smethod_6("1070"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			if (this.bool_3)
			{
				base.Close();
			}
			this.bool_3 = true;
			this.timer_2.Enabled = true;
		}
		if (this.int_0 > 0)
		{
			this.int_0--;
		}
		else
		{
			this.label_16.Text = "";
			this.string_13 = "";
		}
		if (GClass126.bool_13 && GClass125.int_18[3] == 3 && GClass126.smethod_1() > 50984)
		{
			GClass125.int_18[3] = 5;
			string a = GClass127.smethod_4().ToLower();
			if (a == GClass107.smethod_3(115194) || a == GClass107.smethod_3(115242))
			{
				GClass125.int_18[3] = 9;
			}
			if (GClass125.int_18[3] < 9)
			{
				GClass126.bool_13 = !GClass126.bool_13;
				GClass126.smethod_2(GClass107.smethod_3(115278), 0);
			}
		}
		if (this.tabControl_0.SelectedTab != this.tabPage_4)
		{
			return;
		}
		if (GClass126.bool_12 && this.gclass11_0 != null && this.gclass11_0.method_7())
		{
			this.label_3.Text = (GClass126.smethod_0().int_1 / 1000).ToString("F0");
			int num = GClass126.smethod_0().int_1 / 600;
			num = Math.Abs(num % 6 - 3);
			this.panel_16.Visible = (num == 0);
			this.panel_14.Visible = (num == 1);
			this.panel_15.Visible = (num == 2);
			this.panel_13.Visible = (num == 3);
			this.gclass114_0.Invalidate();
			this.gclass114_1.Invalidate();
			GClass126.bool_14 = false;
		}
		if (this.gclass11_0 != null && this.gclass11_0.method_7())
		{
			this.gclass11_0.method_8(false);
			this.gclass114_1.Refresh();
		}
		if (GClass126.bool_14)
		{
			GClass126.bool_14 = false;
			this.gclass114_0.Invalidate();
		}
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x000B9E04 File Offset: 0x000B8004
	private int method_25(Label label_22)
	{
		return Convert.ToInt32(label_22.CreateGraphics().MeasureString(label_22.Text, label_22.Font).Width);
	}

	// Token: 0x06000517 RID: 1303 RVA: 0x000B9E38 File Offset: 0x000B8038
	private void method_26(string string_20, string string_21, string string_22, string string_23, byte byte_0, int int_3, int int_4)
	{
		int num = GClass126.smethod_1();
		try
		{
			if (GClass121.smethod_14(string_20, "789006" + string_20, false) || GClass121.smethod_14(string_21, "3490123" + string_21, true))
			{
				this.method_1();
			}
			bool flag = false;
			try
			{
				flag = GClass96.smethod_5(string_20);
			}
			catch (Exception)
			{
				this.string_0 = GClass121.smethod_6("6060");
				this.string_1 = "  ";
				base.Invoke(new GForm8.Delegate11(this.method_50), new object[]
				{
					true
				});
				return;
			}
			if (!flag)
			{
				this.string_0 = GClass121.smethod_6("1095");
				if (string_20.Contains("CAN"))
				{
					this.string_1 = GClass121.smethod_6("1061");
				}
				else if (string_20 == GClass107.smethod_3(112723) || string_20 == GClass107.smethod_3(112762) || string_20 == GClass107.smethod_3(112764))
				{
					this.string_1 = GClass121.smethod_6("1062");
				}
				while (2000 + num > GClass126.smethod_1() && !GClass126.bool_25)
				{
					Thread.Sleep(100);
				}
				base.Invoke(new GForm8.Delegate11(this.method_50), new object[]
				{
					true
				});
			}
			else
			{
				string text = "";
				if (GClass125.smethod_44() > 0 && GClass125.smethod_44() < GClass125.string_1.Length)
				{
					text = GClass125.string_1[GClass125.smethod_44()];
				}
				GClass126.bool_24 = false;
				this.gform9_0.method_8(GClass121.smethod_6("1051"), GClass121.smethod_6("1052"), text, false, 0);
				if (!GClass126.bool_0)
				{
					base.Invoke(new GForm8.Delegate7(this.method_45));
				}
				int num2 = GClass126.smethod_1();
				while (1000 + num2 > GClass126.smethod_1() && !GClass126.bool_25)
				{
					Thread.Sleep(100);
				}
				string text2 = "70";
				if (string_20 == GClass107.smethod_3(112781) && int_3 == 3)
				{
					text2 = "19";
				}
				else if (string_20 == GClass107.smethod_3(112829))
				{
					text2 = "6E";
				}
				else if (string_21 == GClass107.smethod_3(112833) && string_20 == GClass107.smethod_3(112858) && int_3 == 0)
				{
					text2 = "6E";
				}
				else if (string_21 == GClass107.smethod_3(112906) && string_20 == GClass107.smethod_3(112916) && int_3 == 0)
				{
					text2 = "6E";
				}
				else if (string_20 == GClass107.smethod_3(112920))
				{
					text2 = "19";
				}
				else if (int_3 == 5)
				{
					text2 = "3B";
				}
				else if (int_3 == 6)
				{
					text2 = "CD";
				}
				else if (string_20 == GClass107.smethod_3(112964))
				{
					text2 = "6E";
				}
				else if (string_20 == GClass107.smethod_3(112989))
				{
					text2 = "6E";
				}
				else if (string_20 == GClass107.smethod_3(113012))
				{
					text2 = "6E";
				}
				else if (string_20 == GClass107.smethod_3(113028))
				{
					text2 = "3E";
				}
				else if (int_3 == 0)
				{
					text2 = "70";
				}
				else if (int_3 == 9)
				{
					text2 = "70";
				}
				else if (int_4 == 0)
				{
					text2 = "70";
				}
				else if (int_4 == 1)
				{
					text2 = "10";
				}
				else if (int_4 == 3)
				{
					text2 = "30";
				}
				else if (int_4 == 7)
				{
					text2 = "70";
				}
				else if (int_4 == 9)
				{
					text2 = "90";
				}
				else if (int_4 == 11)
				{
					text2 = "B0";
				}
				else if (int_4 == 12)
				{
					text2 = "C0";
				}
				else if (int_4 == 13)
				{
					text2 = "D0";
				}
				if (GClass125.smethod_61())
				{
					GClass126.smethod_2("c4", 0);
					bool bool_ = GClass126.bool_10;
					bool flag2 = GClass125.smethod_44() == 15;
					string a = "";
					if (int_3 == 1 && !bool_)
					{
						a = string.Format(GClass121.smethod_6("1041"), int_4);
					}
					else if (int_3 == 2 && !bool_)
					{
						a = string.Format(GClass121.smethod_6("1042"), int_4);
					}
					else if (int_3 == 3 && !bool_ && !flag2)
					{
						a = string.Format(GClass121.smethod_6("1043"), int_4);
					}
					else if (int_3 == 4 && !bool_)
					{
						a = string.Format(GClass121.smethod_6("1046"), int_4);
					}
					else if (int_3 == 5 && !bool_ && !flag2)
					{
						a = string.Format(GClass121.smethod_6("1047"), int_4);
					}
					else if (int_3 == 6 && !bool_ && !flag2)
					{
						a = string.Format(GClass121.smethod_6("1048"), int_4);
					}
					else if (int_3 == 9)
					{
						a = GClass121.smethod_6("1044");
					}
					string text3 = "";
					if (a != "")
					{
						GClass126.bool_24 = false;
						GClass126.bool_25 = false;
						this.gform9_0.method_8(a, text3, GClass121.smethod_6("1055"), false, 0);
						int num3 = 1200;
						while (!GClass126.bool_24 && !GClass126.bool_25 && num3 > 0)
						{
							num3--;
							Thread.Sleep(100);
						}
						if (!GClass126.bool_24)
						{
							this.string_0 = GClass121.smethod_6("6060");
							base.Invoke(new GForm8.Delegate11(this.method_50), new object[]
							{
								true
							});
							return;
						}
					}
				}
				if (string_20 == GClass107.smethod_3(113050))
				{
					GClass126.bool_24 = false;
					GClass126.bool_25 = false;
					this.gform9_0.method_8(GClass121.smethod_6("6057"), "", GClass121.smethod_6("1055"), false, 0);
					int num4 = 1200;
					while (!GClass126.bool_24 && !GClass126.bool_25 && num4 > 0)
					{
						num4--;
						Thread.Sleep(100);
					}
					if (!GClass126.bool_24)
					{
						this.string_0 = GClass121.smethod_6("6060");
						base.Invoke(new GForm8.Delegate11(this.method_50), new object[]
						{
							true
						});
						return;
					}
				}
				if (string_20 == GClass107.smethod_3(113095) && string_21 == GClass107.smethod_3(113135))
				{
					GClass126.bool_24 = false;
					GClass126.bool_25 = false;
					this.gform9_0.method_8(GClass121.smethod_6("1070"), GClass121.smethod_6("1208"), GClass121.smethod_6("1055"), false, 0);
					int num5 = 1200;
					while (!GClass126.bool_24 && !GClass126.bool_25 && num5 > 0)
					{
						num5--;
						Thread.Sleep(100);
					}
					if (!GClass126.bool_24)
					{
						this.string_0 = GClass121.smethod_6("6060");
						base.Invoke(new GForm8.Delegate11(this.method_50), new object[]
						{
							true
						});
						return;
					}
					Thread.Sleep(200);
					GClass126.bool_24 = false;
					GClass126.bool_25 = false;
					this.gform9_0.method_8(GClass121.smethod_6("1070"), GClass121.smethod_6("1209"), GClass121.smethod_6("1055"), false, 0);
					num5 = 1200;
					while (!GClass126.bool_24 && !GClass126.bool_25 && num5 > 0)
					{
						num5--;
						Thread.Sleep(100);
					}
					if (!GClass126.bool_24)
					{
						this.string_0 = GClass121.smethod_6("6060");
						base.Invoke(new GForm8.Delegate11(this.method_50), new object[]
						{
							true
						});
						return;
					}
				}
				GClass126.bool_24 = false;
				this.gform9_0.method_8(GClass121.smethod_6("1051"), GClass121.smethod_6("1052"), GClass121.smethod_6("1053"), false, 0);
				if (string_21.StartsWith(GClass107.smethod_3(113183)) && string_20 == GClass107.smethod_3(113203))
				{
					this.gclass11_0 = new GClass95(byte_0, string_23, this.list_3, this.list_0, text2);
				}
				else if (string_21.StartsWith(GClass107.smethod_3(113236)) && string_20 == GClass107.smethod_3(113246))
				{
					this.gclass11_0 = new GClass94(string_20, byte_0, string_23, this.list_3, this.list_0, text2);
				}
				else if (string_21.StartsWith(GClass107.smethod_3(113262)) && string_20 == GClass107.smethod_3(113284))
				{
					this.gclass11_0 = new GClass94(string_20, byte_0, string_23, this.list_3, this.list_0, text2);
				}
				else
				{
					this.gclass11_0 = GClass11.smethod_0(string_20, string_23, byte_0, this.list_3, this.list_0, text2, this.list_2);
				}
				this.gclass11_0.ModuleID = string_21;
				this.gclass11_0.ProtocolID = string_20;
				this.gclass11_0.Event_1 += this.method_48;
				this.gclass11_0.Event_0 += new GDelegate4(this.method_0);
				this.gclass11_0.Event_2 += this.method_33;
				this.gclass11_0.Event_3 += this.method_38;
				if ((GClass125.smethod_44() == 4 || GClass125.smethod_44() == 5) && !GClass126.bool_0)
				{
					if (GClass125.smethod_44() == 5 || GClass125.smethod_44() == 10)
					{
						for (int i = 0; i < 30; i++)
						{
							if (this.gform9_0 == null || this.gform9_0.method_0())
							{
								base.Invoke(new GForm8.Delegate11(this.method_50), new object[]
								{
									true
								});
								this.string_0 = GClass121.smethod_6("6060");
								return;
							}
							Thread.Sleep(100);
						}
					}
					if (!GClass96.smethod_3() && this.gform9_0 != null)
					{
						GClass126.bool_24 = false;
						this.gform9_0.method_8(GClass121.smethod_6("1070"), GClass121.smethod_6("1074"), GClass121.smethod_6("1075"), false, 0);
						int num6 = 1200;
						while (!GClass126.bool_24 && num6 > 0)
						{
							num6--;
							Thread.Sleep(100);
						}
						if (num6 == 0)
						{
							base.Invoke(new GForm8.Delegate11(this.method_50), new object[]
							{
								true
							});
							this.string_0 = GClass107.smethod_3(113310);
							return;
						}
						GClass126.bool_24 = false;
						this.gform9_0.method_8(GClass121.smethod_6("1051"), GClass121.smethod_6("1052"), GClass121.smethod_6("1053"), false, 0);
						GClass96.smethod_1(true);
						int num7 = 10;
						if (GClass125.smethod_44() == 5 || GClass125.smethod_44() == 10)
						{
							num7 = 40;
						}
						for (int j = 0; j < num7; j++)
						{
							if (this.gform9_0 == null || this.gform9_0.method_0())
							{
								base.Invoke(new GForm8.Delegate11(this.method_50), new object[]
								{
									true
								});
								this.string_0 = GClass121.smethod_6("6060");
								return;
							}
							Thread.Sleep(100);
						}
					}
				}
				if (GClass125.smethod_49() && !GClass126.bool_0)
				{
					for (int k = 0; k < 15; k++)
					{
						if (this.gform9_0 == null || this.gform9_0.method_0())
						{
							base.Invoke(new GForm8.Delegate11(this.method_50), new object[]
							{
								true
							});
							this.string_0 = GClass121.smethod_6("6060");
							return;
						}
						Thread.Sleep(100);
					}
					bool flag3;
					if (GClass126.bool_19 && (string_20 == GClass107.smethod_3(113355) || string_20 == GClass107.smethod_3(113357) || string_20 == GClass107.smethod_3(113368)) && (text2 == "70" || text2 == "30"))
					{
						if (text2 == "30")
						{
							flag3 = GClass96.smethod_7();
						}
						else
						{
							flag3 = GClass96.smethod_8();
						}
						GClass125.smethod_45(1);
						this.gclass11_0 = GClass11.smethod_0(string_20, string_23, byte_0, this.list_3, this.list_0, text2, this.list_2);
						if (string_20 == GClass107.smethod_3(113370))
						{
							this.gclass11_0 = new GClass93(byte_0, this.list_3, this.list_0);
						}
						else if (string_20 == GClass107.smethod_3(113382))
						{
							this.gclass11_0 = new GClass89(byte_0, this.list_3, this.list_0);
						}
						else
						{
							this.gclass11_0 = new GClass92(byte_0, this.list_3, this.list_0);
						}
						this.gclass11_0.ModuleID = string_21;
						this.gclass11_0.ProtocolID = string_20;
						this.gclass11_0.Event_1 += this.method_48;
						this.gclass11_0.Event_0 += new GDelegate4(this.method_0);
						this.gclass11_0.Event_2 += this.method_33;
						this.gclass11_0.Event_3 += this.method_38;
					}
					else
					{
						flag3 = GClass96.smethod_6();
					}
					if (!flag3)
					{
						this.string_0 = GClass121.smethod_6("1252");
						while (2000 + num > GClass126.smethod_1() && !GClass126.bool_25)
						{
							Thread.Sleep(100);
						}
						base.Invoke(new GForm8.Delegate11(this.method_50), new object[]
						{
							true
						});
						return;
					}
					bool flag4 = GClass127.smethod_24();
					GClass126.smethod_2("CTV" + (flag4 ? "Y" : "N"), 0);
					if (!flag4)
					{
						GClass126.bool_11 = !flag4;
					}
				}
				this.gclass11_0.method_31();
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(GClass107.smethod_3(113386) + ex.Message, 0);
			base.Invoke(new GForm8.Delegate11(this.method_50), new object[]
			{
				true
			});
			this.string_0 = GClass107.smethod_3(113425);
		}
	}

	// Token: 0x06000518 RID: 1304 RVA: 0x000BAC9C File Offset: 0x000B8E9C
	private void button_9_Click(object sender, EventArgs e)
	{
		List<TableDataRowP> dataSource = GClass127.smethod_31(this.list_0);
		Class7.smethod_1(dataSource);
		this.dataGridView_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		this.dataGridView_1.DataSource = dataSource;
		this.dataGridView_1.Invalidate();
		this.dataGridView_1.Focus();
		this.dataGridView_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
	}

	// Token: 0x06000519 RID: 1305 RVA: 0x000BACF8 File Offset: 0x000B8EF8
	private void button_5_Click(object sender, EventArgs e)
	{
		string a = GClass125.smethod_20();
		string a2 = GClass127.smethod_49(GClass125.smethod_26()) + GClass127.smethod_49(GClass125.smethod_28());
		if (new GForm13().ShowDialog() == DialogResult.OK)
		{
			string b = GClass127.smethod_49(GClass125.smethod_26()) + GClass127.smethod_49(GClass125.smethod_28());
			if (a != GClass125.smethod_20() || a2 != b)
			{
				this.method_32();
			}
		}
		this.timer_2.Interval = ((GClass125.smethod_67() == 0) ? 180 : ((GClass125.smethod_67() == 0) ? 500 : 800));
	}

	// Token: 0x0600051A RID: 1306 RVA: 0x000BAD94 File Offset: 0x000B8F94
	private void button_0_Click(object sender, EventArgs e)
	{
		if (GClass126.bool_12)
		{
			this.method_4();
			this.method_23();
			if (this.comboBox_3.Items.Count > 1)
			{
				this.comboBox_3.SelectedIndex = this.comboBox_3.Items.Count - 2;
			}
			this.panel_13.Visible = false;
			this.panel_15.Visible = false;
			this.panel_14.Visible = false;
			this.panel_16.Visible = false;
			return;
		}
		GClass126.int_5 = GClass126.int_2[this.comboBox_1.SelectedIndex];
		this.method_18(true, false);
		GClass126.smethod_0().string_0 = this.textBox_4.Text;
		this.comboBox_3.Items[this.comboBox_3.Items.Count - 1] = GClass126.smethod_0().string_0;
		this.comboBox_3.SelectedIndex = this.comboBox_3.Items.Count - 1;
		this.textBox_4.Text = "";
		this.gclass114_0.Invalidate();
		GClass126.bool_12 = true;
		GClass126.int_5 = GClass126.int_2[this.comboBox_1.SelectedIndex];
		this.method_23();
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x000BAED0 File Offset: 0x000B90D0
	private void method_27(int int_3)
	{
		string text = GClass125.smethod_119(int_3);
		GClass105 gclass = GClass126.smethod_0();
		if (!GClass126.bool_12 || gclass == null || gclass.list_3.Count == 0)
		{
			return;
		}
		if (text.Length != 0 && GClass126.bool_13)
		{
			gclass.method_0(text);
			return;
		}
	}

	// Token: 0x0600051C RID: 1308 RVA: 0x000BAF1C File Offset: 0x000B911C
	private void button_6_Click(object sender, EventArgs e)
	{
		GForm8.Class9 @class = new GForm8.Class9();
		@class.<>4__this = this;
		if (this.gclass11_0 != null)
		{
			return;
		}
		if (this.gform9_0 != null)
		{
			return;
		}
		if (this.gform10_0 != null)
		{
			return;
		}
		if (this.gform11_0 != null)
		{
			return;
		}
		if (sender != null && e != null)
		{
			GClass126.bool_0 = (Control.ModifierKeys == Keys.Control);
		}
		@class.protocolID = this.dataGridView_4.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_25.Name].Value.ToString();
		@class.moduleID = this.dataGridView_4.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_24.Name].Value.ToString();
		@class.ECUAddressString = this.dataGridView_4.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_26.Name].Value.ToString();
		@class.CANAddressString = this.dataGridView_4.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_28.Name].Value.ToString();
		@class.ecuAddress = byte.Parse(@class.ECUAddressString, NumberStyles.HexNumber);
		int num = GClass127.smethod_37(this.dataGridView_4.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_30.Name].Value.ToString());
		GClass126.bool_11 = false;
		@class.adapterType = 0;
		@class.obdpin = 0;
		for (int i = 9; i > 0; i--)
		{
			if (num >= 100 * i)
			{
				@class.adapterType = i;
				@class.obdpin = num - 100 * i;
				IL_1A9:
				this.button_6.Enabled = false;
				this.button_24.Enabled = false;
				this.button_11.Enabled = false;
				this.button_23.Enabled = false;
				this.button_7.Enabled = true;
				this.button_5.Enabled = false;
				this.button_4.Enabled = false;
				this.label_18.Visible = false;
				GClass126.smethod_5();
				if (GClass126.int_7 > 0)
				{
					this.method_5();
				}
				GClass125.smethod_82((int)this.dataGridView_4.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_21.Name].Value);
				GClass126.string_7 = this.method_36() + " " + this.dataGridView_5.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_4.Name].Value.ToString();
				GClass126.string_6 = this.dataGridView_4.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_23.Name].Value.ToString();
				if (GClass126.bool_13)
				{
					GClass126.bool_13 = (GClass125.smethod_5() != GClass107.smethod_3(113462));
					GClass126.smethod_2(GClass107.smethod_3(113470), 0);
				}
				this.label_20.Text = GClass121.smethod_6("1050");
				this.label_20.ForeColor = Color.DarkGreen;
				GClass126.smethod_2(GClass107.smethod_3(113494), 0);
				this.method_37();
				GClass126.smethod_2(GClass107.smethod_3(113529), 0);
				this.string_0 = "";
				this.string_1 = "";
				if (GClass126.bool_0)
				{
					GClass125.smethod_39(3, GClass125.smethod_44());
					GClass125.smethod_41(3, GClass125.smethod_55());
					GClass125.smethod_43(3, GClass125.smethod_57());
				}
				this.gform9_0 = new GForm9(GClass121.smethod_6("1051"), GClass121.smethod_6("1052"), GClass121.smethod_6("8303"), false, 0);
				new Thread(new ThreadStart(@class.method_0)).Start();
				this.gform9_0.ShowDialog();
				this.gform9_0 = null;
				if (!GClass126.bool_0)
				{
					this.method_45();
				}
				if (this.gclass11_0 != null && this.gclass11_0.method_18())
				{
					GClass125.smethod_100((int)this.dataGridView_5.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_3.Name].Value);
					if (!GClass121.smethod_14(@class.protocolID, "788006" + @class.protocolID, false) && !GClass121.smethod_14(@class.moduleID, "3440123" + @class.moduleID, true))
					{
						if (@class.moduleID.StartsWith(GClass107.smethod_3(113554)))
						{
							this.dataGridView_0.DataSource = GClass127.smethod_31(this.list_3);
							this.dataGridView_0.Columns[2].Visible = true;
						}
						else
						{
							this.dataGridView_0.Columns[2].Visible = true;
						}
						this.dataGridView_0.Refresh();
						this.label_5.Text = GClass126.string_7;
						this.label_4.Text = GClass126.string_6;
						if (@class.moduleID.StartsWith(GClass107.smethod_3(113589)))
						{
							this.dataGridView_1.DataSource = GClass127.smethod_31(this.list_0);
						}
						if (this.tabControl_0.SelectedTab == this.tabPage_7)
						{
							this.method_35(true);
							this.tabControl_0.TabPages.Remove(this.tabPage_7);
							if (!@class.moduleID.StartsWith(GClass107.smethod_3(113604)))
							{
								this.method_7(this.tabPage_0);
							}
							if (this.list_4.Count > 0 && (GClass126.bool_15 || GClass126.bool_13))
							{
								this.method_7(this.tabPage_2);
								this.dataGridView_3.DataSource = GClass127.smethod_14(new List<GClass102>());
								this.dataGridView_3.Invalidate();
								this.list_8 = null;
							}
							if (this.list_0.Count > 0 && (GClass126.bool_15 || GClass126.bool_13))
							{
								this.method_7(this.tabPage_3);
							}
							this.method_7(this.tabPage_4);
							if (this.list_1.Count > 0 && (GClass126.bool_15 || GClass126.bool_13))
							{
								this.method_7(this.tabPage_5);
							}
							if (this.list_2.Count > 0 && (GClass126.bool_15 || GClass126.bool_13))
							{
								this.method_7(this.tabPage_6);
							}
							this.method_7(this.tabPage_1);
							this.label_20.ForeColor = Color.DarkGreen;
							this.label_20.Text = string.Concat(new string[]
							{
								GClass126.string_7,
								" - ",
								GClass126.string_6,
								GClass107.smethod_3(113636),
								this.gclass11_0.method_11(),
								"]"
							});
							GClass126.smethod_2("(" + GClass126.string_0 + ")", 2);
							GClass126.smethod_2(DateTime.Now.ToString(), 2);
							GClass126.smethod_2(GClass126.string_7, 2);
							GClass126.smethod_2(GClass126.string_6, 2);
							if (GClass126.bool_0)
							{
								GClass126.smethod_2(GClass121.smethod_6("1207"), 2);
							}
							GClass126.smethod_2(GClass107.smethod_3(113670), 2);
							GClass126.smethod_2("", 2);
						}
						for (int j = 0; j < this.list_3.Count; j++)
						{
							GClass126.smethod_2(this.list_3[j].string_0 + ": " + this.list_3[j].method_0(), 2);
						}
						bool flag = false;
						int k = 0;
						while (k < this.list_6.Count)
						{
							if (!(this.list_6[k] == this.gclass11_0.method_11()))
							{
								k++;
							}
							else
							{
								flag = true;
								IL_7C5:
								if (@class.moduleID.StartsWith(GClass107.smethod_3(113698)) || @class.moduleID.StartsWith(GClass107.smethod_3(113728)) || @class.moduleID.StartsWith(GClass107.smethod_3(113741)) || @class.moduleID.StartsWith(GClass107.smethod_3(113784)) || this.gclass11_0.method_11() == "" || GClass126.bool_0)
								{
									flag = true;
								}
								string text = "";
								if (!flag)
								{
									DataRow[] array = this.gclass99_0.dataTable_4.Select(GClass107.smethod_3(113786) + this.gclass11_0.method_11() + "'");
									for (int l = 0; l < array.Length; l++)
									{
										int num2 = (int)array[l]["SystemID2"];
										DataRow[] array2 = this.gclass99_0.dataTable_3.Select("SystemID2=" + num2.ToString());
										if (array2.Length != 0)
										{
											text = (string)array2[0]["SystemDesc"];
											string text2 = (string)array2[0]["ModuleID"];
											if ((!@class.moduleID.StartsWith("SVC") || text2.StartsWith("SVC")) && (!@class.moduleID.StartsWith(GClass107.smethod_3(113818)) || text2.StartsWith(GClass107.smethod_3(113818))))
											{
												break;
											}
										}
									}
								}
								bool flag2 = text.Length > 0;
								this.timer_0.Enabled = true;
								if (this.list_4.Count > 0)
								{
									this.timer_1.Enabled = true;
								}
								this.label_21.Visible = !flag;
								if (!flag)
								{
									if (flag2)
									{
										this.label_21.Text = GClass121.smethod_6("2004");
									}
									else
									{
										this.label_21.Text = GClass121.smethod_6("2003");
									}
									GClass126.smethod_2(this.label_21.Text, 2);
								}
								GClass126.smethod_2("", 2);
								if (GClass126.bool_0)
								{
									this.label_21.Text = GClass121.smethod_6("1207");
									this.label_21.Visible = true;
								}
								if (!flag)
								{
									if (text.Length > 0)
									{
										text = GClass121.smethod_6("1204") + " " + text;
									}
									else
									{
										text = GClass121.smethod_6("2004");
									}
									this.gform9_0 = new GForm9(GClass121.smethod_6("1054"), text, GClass121.smethod_6("1055"), true, 0);
									this.gform9_0.ShowDialog();
									if (this.gform9_0 != null && (this.gform9_0.method_2() || this.gform9_0.method_0()))
									{
										GClass126.smethod_2(GClass107.smethod_3(113852), 1);
										this.gclass11_0.method_30(false);
									}
									this.gform9_0 = null;
								}
								if (!GClass126.bool_15 && !GClass126.bool_13 && this.gclass11_0 != null)
								{
									this.gform9_0 = new GForm9(GClass107.smethod_3(113865), GClass107.smethod_3(113881), GClass107.smethod_3(113920), true, 4000);
									this.gform9_0.ShowDialog();
									GClass126.smethod_2(GClass107.smethod_3(113941), 1);
									this.gclass11_0.method_30(false);
									this.gform9_0 = null;
								}
								if (!GClass126.string_2.Contains(GClass107.smethod_3(113954)) && this.gclass11_0 != null)
								{
									this.gform9_0 = new GForm9(GClass107.smethod_3(113961), GClass107.smethod_3(113967), GClass107.smethod_3(113984), true, 4000);
									this.gform9_0.ShowDialog();
									GClass126.smethod_2(GClass107.smethod_3(114009), 1);
									this.gclass11_0.method_30(false);
									this.gform9_0 = null;
								}
								if (GClass126.bool_10 && GClass126.bool_11 && this.gclass11_0 != null)
								{
									this.gform9_0 = new GForm9(GClass107.smethod_3(114030), GClass107.smethod_3(114077), GClass107.smethod_3(114119), true, 4000);
									this.gform9_0.ShowDialog();
									GClass126.smethod_2(GClass107.smethod_3(114142), 1);
									this.gclass11_0.method_30(false);
									this.gform9_0 = null;
								}
								else if (this.gclass11_0 != null)
								{
									if (@class.moduleID.StartsWith(GClass107.smethod_3(114178)) && @class.protocolID == GClass107.smethod_3(114184))
									{
										if (((GClass95)this.gclass11_0).int_5 > 2)
										{
											GClass126.smethod_2(GClass121.smethod_6("1070") + ": " + GClass121.smethod_6("1081"), 2);
											this.gform9_0 = new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("1081"), GClass121.smethod_6("1059"), true, 0);
											this.gform9_0.ShowDialog();
											this.gform9_0 = null;
										}
										if (((GClass95)this.gclass11_0).int_6 > 2)
										{
											GClass126.smethod_2(GClass121.smethod_6("1070") + ": " + GClass121.smethod_6("1082"), 2);
											this.gform9_0 = new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("1082"), GClass121.smethod_6("1059"), true, 0);
											this.gform9_0.ShowDialog();
											this.gform9_0 = null;
										}
										if (((GClass95)this.gclass11_0).bool_6)
										{
											GClass126.smethod_2(GClass121.smethod_6("1070") + ": " + GClass121.smethod_6("1083"), 2);
											this.gform9_0 = new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("1083"), GClass121.smethod_6("1059"), true, 0);
											this.gform9_0.ShowDialog();
											this.gform9_0 = null;
										}
									}
									else if (@class.moduleID.StartsWith(GClass107.smethod_3(114199)) && (@class.protocolID == GClass107.smethod_3(114207) || @class.protocolID == GClass107.smethod_3(114224)))
									{
										if (((GClass94)this.gclass11_0).int_5 > 2)
										{
											GClass126.smethod_2(GClass121.smethod_6("1070") + ": " + GClass121.smethod_6("1081"), 2);
											this.gform9_0 = new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("1081"), GClass121.smethod_6("1059"), true, 0);
											this.gform9_0.ShowDialog();
											this.gform9_0 = null;
										}
										if (((GClass94)this.gclass11_0).int_6 > 2)
										{
											GClass126.smethod_2(GClass121.smethod_6("1070") + ": " + GClass121.smethod_6("1082"), 2);
											this.gform9_0 = new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("1082"), GClass121.smethod_6("1059"), true, 0);
											this.gform9_0.ShowDialog();
											this.gform9_0 = null;
										}
										if (((GClass94)this.gclass11_0).bool_6)
										{
											GClass126.smethod_2(GClass121.smethod_6("1070") + ": " + GClass121.smethod_6("1083"), 2);
											this.gform9_0 = new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("1083"), GClass121.smethod_6("1059"), true, 0);
											this.gform9_0.ShowDialog();
											this.gform9_0 = null;
										}
										if (((GClass94)this.gclass11_0).bool_7)
										{
											GClass126.smethod_2(GClass121.smethod_6("1070") + ": " + GClass107.smethod_3(114273), 2);
											this.gform9_0 = new GForm9(GClass121.smethod_6("1070"), GClass107.smethod_3(114303), GClass121.smethod_6("1059"), true, 0);
											this.gform9_0.ShowDialog();
											this.gform9_0 = null;
										}
									}
									if (@class.moduleID.StartsWith(GClass107.smethod_3(114309)))
									{
										foreach (GClass104 gclass in this.list_2)
										{
											if (gclass.string_2.Contains(GClass107.smethod_3(114345)))
											{
												gclass.method_1(this.gclass11_0.vmethod_0(gclass.byte_0[0], GClass107.smethod_3(114351), gclass.int_0, gclass.int_1, gclass.string_5, gclass.string_6));
											}
										}
									}
								}
								this.dataGridView_8.Columns[2].Visible = (@class.moduleID.StartsWith(GClass107.smethod_3(114385)) || @class.moduleID.StartsWith(GClass107.smethod_3(114423)));
								if (GClass126.int_13 != -1)
								{
									this.tabControl_0.SelectedTab = this.tabPage_3;
									this.method_21(GClass126.int_13);
									return;
								}
								return;
							}
						}
						goto IL_7C5;
					}
					throw new Exception(GClass107.smethod_3(113545));
				}
				else
				{
					this.method_7(this.tabPage_1);
					if (this.string_1 == "")
					{
						this.string_1 = GClass121.smethod_6("1258");
					}
					else if (this.string_1.Contains(GClass107.smethod_3(114471)))
					{
						this.string_1 = GClass121.smethod_6("1253");
					}
					else if (this.string_1.Contains(GClass107.smethod_3(114503)))
					{
						this.string_1 = GClass121.smethod_6("1254");
					}
					else if (this.string_1.Contains(GClass107.smethod_3(114538)) && this.string_1.Contains(GClass107.smethod_3(114547)))
					{
						this.string_1 = GClass121.smethod_6("1255");
					}
					else if (this.string_1.Contains(GClass107.smethod_3(114580)))
					{
						this.string_1 = GClass121.smethod_6("1256");
					}
					else if (this.string_1.Contains(GClass107.smethod_3(114623)))
					{
						this.string_1 = GClass121.smethod_6("1257");
					}
					else if (this.string_1 == "  ")
					{
						this.string_1 = "";
					}
					this.gform9_0 = new GForm9(GClass121.smethod_6("1056"), this.string_0, this.string_1, false, 6000);
					this.gform9_0.ShowDialog();
					this.gform9_0 = null;
				}
				return;
			}
		}
		goto IL_1A9;
	}

	// Token: 0x0600051D RID: 1309 RVA: 0x00002F0A File Offset: 0x0000110A
	private void tabControl_0_KeyPress(object sender, KeyPressEventArgs e)
	{
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x000BC1A8 File Offset: 0x000BA3A8
	private void dataGridView_6_SelectionChanged(object sender, EventArgs e)
	{
		int num = -1;
		if (this.dataGridView_6.SelectedRows.Count > 0)
		{
			num = (int)this.dataGridView_6.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_0.Name].Value;
		}
		DataView dataView = (DataView)this.dataGridView_5.DataSource;
		if (dataView == null)
		{
			return;
		}
		if (num == 999 && GClass125.smethod_98().Length > 0)
		{
			dataView.RowFilter = GClass107.smethod_3(111667) + GClass125.smethod_98() + ")";
		}
		else
		{
			dataView.RowFilter = GClass107.smethod_3(111685) + num.ToString();
		}
		this.dataGridView_5.DataSource = dataView;
		this.dataGridView_7_Leave(null, null);
	}

	// Token: 0x0600051F RID: 1311 RVA: 0x000BC278 File Offset: 0x000BA478
	private void method_28(string string_20, string string_21, string string_22)
	{
		if (this.gform9_0 != null)
		{
			this.gform9_0.method_8(string_20, string_21, string_22, false, 0);
		}
		if (this.gform10_0 != null)
		{
			this.gform10_0.method_8(string_20, string_21, string_22, false, 0);
		}
		if (this.gform11_0 != null)
		{
			this.gform11_0.method_5(string_20, string_21, string_22, false, 0);
		}
	}

	// Token: 0x06000520 RID: 1312 RVA: 0x000BC2D0 File Offset: 0x000BA4D0
	private void method_29()
	{
		try
		{
			string text = string.Concat(new string[]
			{
				"FL_",
				DateTime.Now.ToString(GClass107.smethod_3(109991)),
				"_",
				GClass126.string_7,
				GClass107.smethod_3(110034)
			});
			text = text.Replace("/", "").Replace("\\", "");
			FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(GClass107.smethod_3(110065) + text);
			ftpWebRequest.Method = "STOR";
			ftpWebRequest.Credentials = new NetworkCredential(GClass107.smethod_3(110096), GClass107.smethod_3(110096));
			Stream requestStream = ftpWebRequest.GetRequestStream();
			try
			{
				byte[] bytes = Encoding.Unicode.GetBytes(GClass126.smethod_7());
				requestStream.Write(bytes, 0, bytes.Length);
				GClass126.smethod_6();
			}
			finally
			{
				requestStream.Close();
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(GClass107.smethod_3(110185) + ex.Message, 0);
			base.Invoke(new GForm8.Delegate10(this.method_19), new object[]
			{
				GClass121.smethod_6("1080"),
				"",
				"",
				false,
				0
			});
			Thread.Sleep(2000);
		}
		base.Invoke(new GForm8.Delegate6(this.method_8));
	}

	// Token: 0x06000521 RID: 1313 RVA: 0x000BC460 File Offset: 0x000BA660
	private void comboBox_3_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (GClass126.int_11 != this.comboBox_3.SelectedIndex)
		{
			GClass126.int_11 = this.comboBox_3.SelectedIndex;
			this.method_18(false, true);
			this.comboBox_2.SelectedItem = (GClass126.smethod_0().int_2.ToString() ?? "");
			this.method_23();
			this.gclass114_0.Invalidate();
		}
	}

	// Token: 0x06000522 RID: 1314 RVA: 0x000BC4CC File Offset: 0x000BA6CC
	private void method_30()
	{
		GClass126.smethod_2(GClass107.smethod_3(110779), 0);
		base.WindowState = FormWindowState.Maximized;
		this.label_20.ForeColor = Color.Red;
		this.label_21.Visible = false;
		Version version = Assembly.GetExecutingAssembly().GetName().Version;
		int revision = version.Revision;
		int minor = version.Minor;
		string text = version.Major.ToString() + "." + minor.ToString() + "E";
		if (revision > 0)
		{
			text = text + "R" + revision.ToString();
		}
		GClass126.string_1 = "A" + minor.ToString() + revision.ToString();
		GClass126.string_0 = GClass107.smethod_3(110801) + text;
		this.Text = GClass126.string_0;
		GClass126.smethod_2(GClass107.smethod_3(110827), 0);
		GClass125.smethod_31(Application.StartupPath);
		GClass125.smethod_131();
		GClass125.smethod_25(Application.ExecutablePath);
		GClass126.string_10 = GClass127.smethod_43().Replace(" ", "");
		GClass126.smethod_2(GClass107.smethod_3(110854), 0);
		this.label_14.Font = new Font(GClass125.smethod_28().FontFamily, this.label_14.Font.Size, this.label_14.Font.Style);
		GClass125.smethod_137();
		this.list_7.Clear();
		foreach (int int_ in this.int_2)
		{
			this.list_7.Add(new SimpleValueData(int_, GClass125.smethod_119(int_)));
		}
		this.dataGridView_10.DataSource = this.list_7;
		GClass125.smethod_134();
		GClass126.smethod_2(GClass107.smethod_3(110887), 0);
		if (GClass125.smethod_13().Length == 0)
		{
			GClass125.smethod_85(GClass125.smethod_69());
		}
		GClass126.string_12 = GClass127.smethod_46().Replace(" ", "");
		GClass126.bool_13 = (this.list_7.Count < 0);
		this.method_16();
		GClass126.smethod_2(GClass107.smethod_3(110896), 0);
		this.method_51(text);
	}

	// Token: 0x06000523 RID: 1315 RVA: 0x00003F44 File Offset: 0x00002144
	private void method_31()
	{
		if (GClass126.bool_17)
		{
			this.method_30();
		}
	}

	// Token: 0x06000524 RID: 1316 RVA: 0x000BC700 File Offset: 0x000BA900
	private void method_32()
	{
		Cursor.Current = Cursors.WaitCursor;
		List<Control> list = GForm8.smethod_0(this, 1);
		list.AddRange(GForm8.smethod_1(this.tabPage_0));
		list.AddRange(GForm8.smethod_1(this.tabPage_2));
		list.AddRange(GForm8.smethod_1(this.tabPage_3));
		list.AddRange(GForm8.smethod_1(this.tabPage_4));
		list.AddRange(GForm8.smethod_1(this.tabPage_5));
		list.AddRange(GForm8.smethod_1(this.tabPage_6));
		list.AddRange(GForm8.smethod_1(this.tabPage_1));
		foreach (Control control in list)
		{
			if (control.Tag != null)
			{
				string text = GClass121.smethod_6(control.Tag.ToString());
				string text2 = GClass121.smethod_6(control.Tag.ToString() + "T");
				if (text2 != null && text2 != "" && (control is Button || control is CheckBox || control is ComboBox))
				{
					this.toolTip_0.SetToolTip(control, text2.Replace("\\r", Environment.NewLine));
				}
				if (text != null)
				{
					if (control is Label)
					{
						((Label)control).Text = text;
					}
					else if (control is Button)
					{
						((Button)control).Text = text;
					}
					else if (control is CheckBox)
					{
						((CheckBox)control).Text = text;
					}
				}
			}
		}
		foreach (Control control2 in list)
		{
			if (control2 is Button)
			{
				Button button = (Button)control2;
				if (button.Name != this.button_19.Name && button.Name != this.button_20.Name)
				{
					button.Font = GClass125.smethod_28();
				}
			}
			else if (control2 is CheckBox)
			{
				((CheckBox)control2).Font = GClass125.smethod_28();
			}
			else
			{
				if (control2 is DataGridView)
				{
					DataGridView dataGridView = (DataGridView)control2;
					if (dataGridView.Tag != null && dataGridView.Tag.ToString() == "3")
					{
						continue;
					}
					dataGridView.RowTemplate.DefaultCellStyle.Font = GClass125.smethod_26();
					using (IEnumerator enumerator2 = ((IEnumerable)dataGridView.Rows).GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							object obj = enumerator2.Current;
							((DataGridViewRow)obj).DefaultCellStyle.Font = GClass125.smethod_26();
						}
						continue;
					}
				}
				if (control2 is ComboBox)
				{
					ComboBox comboBox = (ComboBox)control2;
					if ((comboBox.Tag == null || !(comboBox.Tag.ToString() == "3")) && (comboBox.Tag == null || !(comboBox.Tag.ToString() == "5041")) && (comboBox.Tag == null || !comboBox.Tag.ToString().StartsWith("50")))
					{
						comboBox.Font = GClass125.smethod_28();
					}
				}
				else if (control2 is Label)
				{
					Label label = (Label)control2;
					label.Font = new Font(GClass125.smethod_28().FontFamily, label.Font.Size, label.Font.Style);
				}
				else if (control2 is TextBox)
				{
					TextBox textBox = (TextBox)control2;
					textBox.Font = new Font(GClass125.smethod_28().FontFamily, textBox.Font.Size, textBox.Font.Style);
				}
			}
		}
		this.tabControl_0.Font = GClass125.smethod_28();
		List<TabPage> list2 = new List<TabPage>();
		list2.Add(this.tabPage_7);
		list2.Add(this.tabPage_0);
		list2.Add(this.tabPage_2);
		list2.Add(this.tabPage_3);
		list2.Add(this.tabPage_4);
		list2.Add(this.tabPage_5);
		list2.Add(this.tabPage_6);
		list2.Add(this.tabPage_1);
		for (int i = 0; i < list2.Count; i++)
		{
			TabPage tabPage = list2[i];
			string text3 = GClass121.smethod_6((i + 1).ToString() + "001");
			if (text3 != null)
			{
				tabPage.Text = text3;
			}
		}
		this.label_18.Text = GClass121.smethod_6("1060");
		this.label_20.Text = " ";
		Cursor.Current = Cursors.Default;
	}

	// Token: 0x06000525 RID: 1317 RVA: 0x000BCC28 File Offset: 0x000BAE28
	private void method_33(object sender, GEventArgs5 e)
	{
		try
		{
			if (e.method_2() != "")
			{
				base.Invoke(new GForm8.Delegate9(this.method_28), new object[]
				{
					e.method_1(),
					e.method_0() ? GClass121.smethod_6("1052") : "",
					e.method_2()
				});
			}
			else
			{
				base.Invoke(new GForm8.Delegate8(this.method_24), new object[]
				{
					e.method_1()
				});
			}
		}
		catch (Exception)
		{
			GClass126.smethod_2(GClass107.smethod_3(119299), 0);
		}
	}

	// Token: 0x06000526 RID: 1318 RVA: 0x000BCCD8 File Offset: 0x000BAED8
	private void button_20_Click(object sender, EventArgs e)
	{
		if (this.gform9_0 != null)
		{
			return;
		}
		this.gform9_0 = new GForm9(GClass121.smethod_6("1076"), GClass121.smethod_6("1077"), GClass121.smethod_6("1078"), true, 0);
		this.gform9_0.ShowDialog();
		if (this.gform9_0.method_1())
		{
			this.gform9_0 = new GForm9(GClass121.smethod_6("1079"), GClass121.smethod_6("1052"), "", true, 0);
			new Thread(new ThreadStart(this.method_29)).Start();
			this.gform9_0.ShowDialog();
			if (GClass126.smethod_8() < 10)
			{
				this.button_20.Visible = false;
			}
		}
		this.gform9_0 = null;
	}

	// Token: 0x06000527 RID: 1319 RVA: 0x000BCD98 File Offset: 0x000BAF98
	private void button_17_Click(object sender, EventArgs e)
	{
		List<SimpleValueData> list = new List<SimpleValueData>();
		for (int i = 0; i < 10; i++)
		{
			int[] array = GClass125.smethod_117(i);
			string text = "";
			int j = 0;
			IL_8C:
			while (j < this.list_0.Count)
			{
				for (int k = 0; k < array.Length; k++)
				{
					if (array[k] == this.list_0[j].int_2)
					{
						if (text.Length > 0)
						{
							text += GClass107.smethod_3(115169);
						}
						text += this.list_0[j].string_0;
						IL_86:
						j++;
						goto IL_8C;
					}
				}
				goto IL_86;
			}
			if (text == "")
			{
				text = "N/D";
			}
			list.Add(new SimpleValueData(i, text));
		}
		if (!GClass126.bool_13)
		{
			return;
		}
		new GForm14(list).ShowDialog();
		this.dataGridView_1.Focus();
	}

	// Token: 0x06000528 RID: 1320 RVA: 0x000BCE8C File Offset: 0x000BB08C
	private void GForm8_Shown(object sender, EventArgs e)
	{
		this.label_14.Location = new Point((base.Width - this.label_14.Width) / 2, (base.Height - this.label_14.Height) / 2);
		Application.DoEvents();
		GClass126.list_0 = this.list_0;
		Version version = Assembly.GetExecutingAssembly().GetName().Version;
		int revision = version.Revision;
		int minor = version.Minor;
		string text = version.Major.ToString() + "." + minor.ToString() + "E";
		if (revision > 0)
		{
			text = text + "R" + revision.ToString();
		}
		GClass126.string_1 = "A" + minor.ToString() + revision.ToString();
		GClass126.string_0 = GClass107.smethod_3(109954) + text;
		this.method_31();
		if (!GClass126.bool_17)
		{
			this.method_44();
		}
		GClass126.smethod_2(GClass107.smethod_3(109979), 0);
		if (GClass126.bool_23)
		{
			this.method_10(text);
		}
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		for (int i = 0; i < commandLineArgs.Length; i++)
		{
			string[] array = commandLineArgs[i].Split(new char[]
			{
				'='
			});
			if (array.Length == 2 && array[0].ToLower() == "/t")
			{
				int num = GClass127.smethod_37(array[1]);
				if (GClass125.smethod_117(num).Length != 0)
				{
					GClass126.int_13 = num;
					Thread.Sleep(200);
					this.button_6_Click(null, null);
				}
				else
				{
					base.Close();
				}
			}
		}
	}

	// Token: 0x06000529 RID: 1321 RVA: 0x000BD020 File Offset: 0x000BB220
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (this.gclass11_0 != null && this.gclass11_0.method_18())
		{
			if (this.gclass11_0.method_9() > 0)
			{
				if (!this.label_18.Visible)
				{
					this.label_18.Visible = true;
				}
				if (this.label_18.ForeColor == Color.Red)
				{
					this.label_18.ForeColor = Color.White;
				}
				else
				{
					this.label_18.ForeColor = Color.Red;
				}
				GClass11 gclass = this.gclass11_0;
				int num = gclass.method_9();
				gclass.method_10(num - 1);
			}
			else if (this.label_18.Visible)
			{
				this.label_18.Visible = false;
			}
			if (this.label_21.Visible)
			{
				if (this.label_21.ForeColor == Color.Red)
				{
					this.label_21.ForeColor = Color.White;
				}
				else
				{
					this.label_21.ForeColor = Color.Red;
				}
			}
			if (this.tabControl_0.SelectedTab == this.tabPage_3 && (this.gclass11_0.method_7() || GClass126.int_4 + 2000 < GClass126.smethod_1()))
			{
				int num2 = 100;
				while (GClass125.smethod_67() == 2 && GClass125.smethod_44() == 1 && this.gclass11_0.method_19() && num2 > 0)
				{
					Thread.Sleep(1);
					num2--;
				}
				bool flag = this.gclass11_0.method_7();
				this.gclass11_0.method_8(false);
				GClass126.int_4 = GClass126.smethod_1();
				bool flag2 = false;
				for (int i = 0; i < this.dataGridView_1.Rows.Count; i++)
				{
					if (((TableDataRowP)this.dataGridView_1.Rows[i].DataBoundItem).Selected)
					{
						this.dataGridView_1.UpdateCellValue(2, i);
						flag2 = true;
					}
					else if (this.gclass11_0.ModuleID.StartsWith(GClass107.smethod_3(115117)))
					{
						this.dataGridView_1.UpdateCellValue(2, i);
					}
				}
				if (flag2 && flag)
				{
					GClass126.smethod_2(GClass121.smethod_6("4050"), 2);
					for (int j = 0; j < this.list_0.Count; j++)
					{
						if (this.list_0[j].bool_0)
						{
							GClass126.smethod_2(string.Concat(new string[]
							{
								this.list_0[j].string_0,
								this.string_14,
								this.list_0[j].method_0(),
								this.string_15,
								this.list_0[j].string_3
							}), 2);
						}
					}
					GClass126.smethod_2(this.string_16, 2);
				}
				if (this.string_13 != this.string_16)
				{
					this.label_17.Visible = true;
					this.label_17.Text = this.string_13;
				}
				else if (GClass126.bool_16 && this.gclass11_0.method_13() != this.string_16)
				{
					this.label_17.Visible = true;
					this.label_17.Text = GClass121.smethod_6(this.string_17) + Environment.NewLine + this.gclass11_0.method_13();
				}
				else
				{
					this.label_17.Visible = false;
				}
			}
			if (this.tabControl_0.SelectedTab == this.tabPage_5 && this.gclass11_0.method_7())
			{
				this.gclass11_0.method_8(false);
				this.dataGridView_9.Invalidate();
			}
			if (this.tabControl_0.SelectedTab == this.tabPage_6 && this.gclass11_0.ModuleID.StartsWith(GClass107.smethod_3(115128)) && GClass126.int_4 + 2000 < GClass126.smethod_1())
			{
				GClass126.int_4 = GClass126.smethod_1();
				for (int k = 0; k < this.dataGridView_8.Rows.Count; k++)
				{
					this.dataGridView_8.UpdateCellValue(2, k);
				}
			}
			return;
		}
		this.timer_0.Enabled = false;
		this.timer_1.Enabled = false;
		GClass126.smethod_2(GClass107.smethod_3(115078), 1);
	}

	// Token: 0x0600052A RID: 1322 RVA: 0x000BD450 File Offset: 0x000BB650
	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		GClass126.int_5 = GClass126.int_2[this.comboBox_1.SelectedIndex];
		this.label_3.Text = "";
		this.button_1.Enabled = false;
		this.gclass114_0.Invalidate();
		this.gclass114_0.Focus();
	}

	// Token: 0x0600052B RID: 1323 RVA: 0x000BD4A8 File Offset: 0x000BB6A8
	private void dataGridView_8_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
	{
		bool flag = false;
		if (this.gclass11_0 != null && this.gclass11_0.ModuleID.StartsWith(GClass107.smethod_3(115636)))
		{
			flag = true;
		}
		if (flag && ((TableDataRowP)this.dataGridView_8.Rows[e.RowIndex].DataBoundItem).getDataItem().string_2.Contains(GClass107.smethod_3(115648)))
		{
			this.dataGridView_8.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
			this.dataGridView_8.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
			return;
		}
		this.dataGridView_8.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Navy;
		this.dataGridView_8.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Navy;
	}

	// Token: 0x0600052C RID: 1324 RVA: 0x00003F53 File Offset: 0x00002153
	private void method_34()
	{
		this.method_2();
	}

	// Token: 0x0600052D RID: 1325 RVA: 0x000BD5B4 File Offset: 0x000BB7B4
	private void method_35(bool bool_4)
	{
		this.tabControl_0.TabPages.Remove(this.tabPage_0);
		this.tabControl_0.TabPages.Remove(this.tabPage_2);
		this.tabControl_0.TabPages.Remove(this.tabPage_3);
		this.tabControl_0.TabPages.Remove(this.tabPage_4);
		this.tabControl_0.TabPages.Remove(this.tabPage_5);
		this.tabControl_0.TabPages.Remove(this.tabPage_6);
		if (bool_4)
		{
			this.tabControl_0.TabPages.Remove(this.tabPage_1);
		}
	}

	// Token: 0x0600052E RID: 1326 RVA: 0x000BD660 File Offset: 0x000BB860
	private void button_3_Click(object sender, EventArgs e)
	{
		if (this.gform9_0 != null)
		{
			return;
		}
		if (this.gform10_0 != null)
		{
			return;
		}
		if (this.gform11_0 != null)
		{
			return;
		}
		if (this.dataGridView_2.SelectedRows.Count == 0)
		{
			return;
		}
		GClass104 dataItem = ((TableDataRowP)this.dataGridView_2.SelectedRows[0].DataBoundItem).getDataItem();
		if (dataItem.string_2.Contains(GClass107.smethod_3(115607)))
		{
			this.gform9_0 = new GForm9(GClass121.smethod_6("6050"), "", GClass121.smethod_6("1055"), true, 0);
			this.gform9_0.ShowDialog();
			if (this.gform9_0 == null)
			{
				return;
			}
			bool flag = this.gform9_0.method_1();
			this.gform9_0 = null;
			if (!flag)
			{
				return;
			}
		}
		GClass126.smethod_2(GClass121.smethod_6("6101"), 2);
		GClass126.smethod_2(dataItem.string_0, 2);
		string text = GClass121.smethod_6("6059");
		this.gform11_0 = new GForm11(dataItem.string_0, " ", text, dataItem, this.gclass11_0);
		this.gform11_0.ShowDialog();
		this.gform11_0 = null;
	}

	// Token: 0x0600052F RID: 1327 RVA: 0x000BD77C File Offset: 0x000BB97C
	private string method_36()
	{
		string result = "";
		int num = GClass127.smethod_37(this.dataGridView_5.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_2.Name].Value);
		for (int i = 0; i < this.dataGridView_6.Rows.Count; i++)
		{
			if ((int)this.dataGridView_6.Rows[i].Cells[this.dataGridViewTextBoxColumn_0.Name].Value == num)
			{
				result = this.dataGridView_6.Rows[i].Cells[this.dataGridViewTextBoxColumn_1.Name].Value.ToString();
				return result;
			}
		}
		return result;
	}

	// Token: 0x06000530 RID: 1328 RVA: 0x000BD844 File Offset: 0x000BBA44
	private void button_4_Click(object sender, EventArgs e)
	{
		this.button_4.Enabled = false;
		this.gform9_0 = new GForm9(GClass121.smethod_6("3050"), GClass121.smethod_6("1052"), "", false, 0);
		GClass126.smethod_2(GClass121.smethod_6("3050") + "...", 2);
		GClass126.smethod_2("", 2);
		this.bool_1 = false;
		new Thread(new ThreadStart(this.method_22)).Start();
		this.gform9_0.ShowDialog();
		this.gform9_0 = null;
		if (this.gclass11_0 != null && this.gclass11_0.ProtocolID == GClass107.smethod_3(115061))
		{
			this.gform9_0 = new GForm9(GClass121.smethod_6("6057"), "", GClass121.smethod_6("1059"), true, 0);
			this.gform9_0.ShowDialog();
			this.gform9_0 = null;
			if (this.gclass11_0 != null)
			{
				this.gclass11_0.r0(false, true);
			}
		}
	}

	// Token: 0x06000531 RID: 1329 RVA: 0x000BD94C File Offset: 0x000BBB4C
	private void tabControl_0_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F2 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab != this.tabPage_7)
		{
			e.Handled = true;
			if (this.tabControl_0.Contains(this.tabPage_7))
			{
				this.tabControl_0.SelectedTab = this.tabPage_7;
			}
		}
		if (e.KeyCode == Keys.F2 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab != this.tabPage_0)
		{
			e.Handled = true;
			if (this.tabControl_0.Contains(this.tabPage_0))
			{
				this.tabControl_0.SelectedTab = this.tabPage_0;
				return;
			}
		}
		else if (e.KeyCode == Keys.F3 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab != this.tabPage_2)
		{
			e.Handled = true;
			if (this.tabControl_0.Contains(this.tabPage_2))
			{
				this.tabControl_0.SelectedTab = this.tabPage_2;
				return;
			}
		}
		else if (e.KeyCode == Keys.F4 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab != this.tabPage_3)
		{
			e.Handled = true;
			if (this.tabControl_0.Contains(this.tabPage_3))
			{
				this.tabControl_0.SelectedTab = this.tabPage_3;
				return;
			}
		}
		else if (e.KeyCode == Keys.F5 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab != this.tabPage_4)
		{
			e.Handled = true;
			if (this.tabControl_0.Contains(this.tabPage_4))
			{
				this.tabControl_0.SelectedTab = this.tabPage_4;
				return;
			}
		}
		else if (e.KeyCode == Keys.F6 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab != this.tabPage_5)
		{
			e.Handled = true;
			if (this.tabControl_0.Contains(this.tabPage_5))
			{
				this.tabControl_0.SelectedTab = this.tabPage_5;
				return;
			}
		}
		else if (e.KeyCode == Keys.F7 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab != this.tabPage_6)
		{
			e.Handled = true;
			if (this.tabControl_0.Contains(this.tabPage_6))
			{
				this.tabControl_0.SelectedTab = this.tabPage_6;
				return;
			}
		}
		else if (e.KeyCode == Keys.F10 && !e.Alt && this.tabControl_0.SelectedTab == this.tabPage_7)
		{
			e.Handled = true;
			GClass126.bool_0 = e.Control;
			GClass126.bool_19 = e.Shift;
			if (this.button_6.Enabled)
			{
				this.button_6_Click(null, null);
				return;
			}
		}
		else if (e.KeyCode == Keys.F9 && !e.Alt && this.tabControl_0.SelectedTab == this.tabPage_7)
		{
			e.Handled = true;
			if (e.Shift && e.Control)
			{
				this.label_20.Text = this.string_7;
				return;
			}
			if (this.button_5.Enabled)
			{
				this.button_5_Click(null, null);
				return;
			}
		}
		else if (e.KeyCode == Keys.F11 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab == this.tabPage_7)
		{
			e.Handled = true;
			if (this.button_11.Enabled)
			{
				this.button_11_Click(null, null);
				return;
			}
		}
		else if (e.KeyCode == Keys.F12 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab == this.tabPage_7)
		{
			e.Handled = true;
			GClass126.bool_19 = e.Shift;
			if (this.button_23.Enabled)
			{
				this.button_23_Click(null, null);
				return;
			}
		}
		else
		{
			if (e.KeyCode == Keys.P && !e.Alt && e.Control && this.tabControl_0.SelectedTab == this.tabPage_7)
			{
				e.Handled = true;
				this.panel_18_Click(null, null);
				return;
			}
			if (e.KeyCode == Keys.F11 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab != this.tabPage_7 && this.gclass11_0 != null && this.gclass11_0.method_18())
			{
				e.Handled = true;
				if (this.button_7.Enabled)
				{
					this.button_29_Click(null, null);
					return;
				}
			}
			else if (e.KeyCode == Keys.F10 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab == this.tabPage_2)
			{
				e.Handled = true;
				if (this.button_4.Enabled)
				{
					this.button_4_Click(null, null);
					return;
				}
			}
			else if (e.KeyCode == Keys.F9 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab == this.tabPage_5)
			{
				e.Handled = true;
				if (this.button_3.Enabled)
				{
					this.button_3_Click(null, null);
					return;
				}
			}
			else if (e.KeyCode == Keys.F10 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab == this.tabPage_5)
			{
				e.Handled = true;
				if (this.button_2.Enabled)
				{
					this.button_2_Click(null, null);
					return;
				}
			}
			else if (e.KeyCode == Keys.V && e.Alt && e.Control && this.tabControl_0.SelectedTab == this.tabPage_5)
			{
				e.Handled = true;
				if (this.button_2.Enabled && this.gclass11_0 != null)
				{
					new GForm0(this.gclass11_0).ShowDialog();
					return;
				}
			}
			else if (e.KeyCode == Keys.F10 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab == this.tabPage_6)
			{
				e.Handled = true;
				if (this.button_13.Enabled)
				{
					this.button_13_Click(null, null);
					return;
				}
			}
			else if (e.KeyCode == Keys.C && e.Alt && e.Control && this.tabControl_0.SelectedTab == this.tabPage_6)
			{
				e.Handled = true;
				if (this.button_13.Enabled && this.gclass11_0 != null && this.gclass11_0.ModuleID.StartsWith(GClass107.smethod_3(111568)))
				{
					string a = GClass127.smethod_11(this.gclass11_0.method_35());
					GForm1 gform = new GForm1(a);
					if (gform.ShowDialog() == DialogResult.OK)
					{
						if (a != gform.method_0())
						{
							GClass126.smethod_2(GClass107.smethod_3(111596), 2);
							GClass126.smethod_2(gform.method_0(), 2);
						}
						a = gform.method_0();
						this.gclass11_0.method_3(GClass127.smethod_32(a));
						return;
					}
				}
			}
			else if (e.KeyCode == Keys.S && !e.Alt && !e.Control && !e.Shift && this.tabControl_0.SelectedTab == this.tabPage_3)
			{
				e.Handled = true;
				if (this.button_8.Enabled)
				{
					this.button_8_Click(null, null);
					return;
				}
			}
			else if (e.KeyCode == Keys.U && !e.Alt && !e.Control && !e.Shift && this.tabControl_0.SelectedTab == this.tabPage_3)
			{
				e.Handled = true;
				if (this.button_10.Enabled)
				{
					this.button_10_Click(null, null);
					return;
				}
			}
			else if (e.KeyCode == Keys.L && !e.Alt && !e.Control && !e.Shift && this.tabControl_0.SelectedTab == this.tabPage_3)
			{
				e.Handled = true;
				if (this.button_9.Enabled)
				{
					this.button_9_Click(null, null);
					return;
				}
			}
			else if (e.KeyCode == Keys.T && !e.Alt && !e.Control && !e.Shift && this.tabControl_0.SelectedTab == this.tabPage_3)
			{
				e.Handled = true;
				if (this.button_17.Enabled)
				{
					this.button_17_Click(null, null);
					return;
				}
			}
			else if (e.KeyCode == Keys.R && !e.Alt && !e.Control && !e.Shift && this.tabControl_0.SelectedTab == this.tabPage_3)
			{
				e.Handled = true;
				if (this.checkBox_0.Enabled)
				{
					this.checkBox_0.Checked = !this.checkBox_0.Checked;
					return;
				}
			}
			else if (e.KeyCode == Keys.E && !e.Alt && !e.Control && !e.Shift && this.tabControl_0.SelectedTab == this.tabPage_3)
			{
				e.Handled = true;
				if (this.checkBox_1.Enabled)
				{
					this.checkBox_1.Checked = !this.checkBox_1.Checked;
					return;
				}
			}
			else if (e.KeyCode == Keys.A && !e.Alt && !e.Control && !e.Shift && this.tabControl_0.SelectedTab == this.tabPage_3)
			{
				e.Handled = true;
				if (this.button_22.Enabled)
				{
					this.button_22_Click(null, null);
					return;
				}
			}
			else if (e.KeyCode == Keys.N && !e.Alt && !e.Control && !e.Shift && this.tabControl_0.SelectedTab == this.tabPage_3)
			{
				e.Handled = true;
				if (this.button_21.Enabled)
				{
					this.button_21_Click(null, null);
					return;
				}
			}
			else
			{
				if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && !e.Alt && !e.Control && !e.Shift && this.tabControl_0.SelectedTab == this.tabPage_3)
				{
					e.Handled = true;
					this.method_21(e.KeyCode - Keys.D0);
					return;
				}
				if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && !e.Alt && e.Control && this.tabControl_0.SelectedTab == this.tabPage_3)
				{
					e.Handled = true;
					this.method_6(e.KeyCode - Keys.D0);
					return;
				}
				if (e.KeyCode == Keys.V && e.Alt && e.Control && !e.Shift && this.tabControl_0.SelectedTab == this.tabPage_3)
				{
					e.Handled = true;
					if (this.gclass11_0 != null)
					{
						new GForm0(this.gclass11_0).ShowDialog();
						return;
					}
				}
				else if (e.KeyCode == Keys.F10 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab == this.tabPage_4)
				{
					e.Handled = true;
					if (this.button_0.Enabled)
					{
						this.button_0_Click(null, null);
						return;
					}
				}
				else if (this.tabControl_0.SelectedTab != this.tabPage_4 || (!this.textBox_4.Focused && !this.dataGridView_10.Focused && !this.dataGridView_10.IsCurrentCellInEditMode))
				{
					if (e.KeyCode == Keys.E && !e.Alt && !e.Control && this.tabControl_0.SelectedTab == this.tabPage_4)
					{
						e.Handled = true;
						if (this.button_1.Enabled)
						{
							this.button_1_Click(null, null);
							return;
						}
					}
					else if (e.KeyCode == Keys.R && !e.Alt && !e.Control && this.tabControl_0.SelectedTab == this.tabPage_4)
					{
						e.Handled = true;
						if (this.comboBox_1.Enabled)
						{
							this.comboBox_1.Focus();
							this.comboBox_1.DroppedDown = true;
							return;
						}
					}
					else if (e.KeyCode == Keys.S && !e.Alt && !e.Control && this.tabControl_0.SelectedTab == this.tabPage_4)
					{
						e.Handled = true;
						if (this.comboBox_0.Enabled)
						{
							this.comboBox_0.Focus();
							this.comboBox_0.DroppedDown = true;
							return;
						}
					}
					else if (e.KeyCode == Keys.G && !e.Alt && !e.Control && this.tabControl_0.SelectedTab == this.tabPage_4)
					{
						e.Handled = true;
						if (this.comboBox_2.Enabled)
						{
							this.comboBox_2.Focus();
							this.comboBox_2.DroppedDown = true;
							return;
						}
					}
					else if (e.KeyCode == Keys.T && !e.Alt && !e.Control && this.tabControl_0.SelectedTab == this.tabPage_4)
					{
						e.Handled = true;
						if (GClass126.bool_13)
						{
							this.method_40();
							return;
						}
					}
					else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && !e.Alt && !e.Control && this.tabControl_0.SelectedTab == this.tabPage_4)
					{
						e.Handled = true;
						this.method_27(e.KeyCode - Keys.D0);
					}
				}
			}
		}
	}

	// Token: 0x06000532 RID: 1330 RVA: 0x000BE6A0 File Offset: 0x000BC8A0
	private void timer_1_Tick(object sender, EventArgs e)
	{
		if (this.tabControl_0.SelectedTab != this.tabPage_2)
		{
			return;
		}
		if (this.gclass11_0 == null)
		{
			return;
		}
		if (!this.gclass11_0.method_18())
		{
			return;
		}
		string text = "";
		if (this.list_8 != null)
		{
			foreach (GClass102 gclass in this.list_8)
			{
				text += gclass.string_0;
			}
		}
		if (this.list_8 == null)
		{
			this.button_4.Enabled = false;
		}
		else if (!(text != this.string_12) && !(this.string_12 == ""))
		{
			this.button_4.Enabled = (this.list_8.Count > 0);
		}
		else
		{
			foreach (GClass102 gclass2 in this.list_8)
			{
				foreach (GClass102 gclass3 in this.list_4)
				{
					if (gclass3.string_0 == gclass2.string_0)
					{
						if (gclass2.string_2 != "")
						{
							GClass102 gclass4 = gclass2;
							gclass4.string_2 += " - ";
						}
						GClass102 gclass5 = gclass2;
						gclass5.string_2 += GClass121.smethod_20(gclass3.int_0, gclass3.string_2);
						gclass2.string_3 = GClass121.smethod_20(40000 + gclass3.int_1, gclass3.string_3) + Environment.NewLine + gclass2.string_3;
						break;
					}
				}
			}
			if (this.list_8.Count == 0)
			{
				this.list_8.Add(new GClass102("0000", GClass121.smethod_6("3003"), GClass121.smethod_6("3004")));
				this.button_4.Enabled = false;
				if (!this.bool_1)
				{
					GClass126.smethod_2(GClass121.smethod_6("3049"), 2);
					GClass126.smethod_2(GClass121.smethod_6("3003"), 2);
					GClass126.smethod_2("", 2);
					this.bool_1 = true;
				}
			}
			else
			{
				this.button_4.Enabled = true;
				GClass126.smethod_2(GClass121.smethod_6("3049"), 2);
				for (int i = 0; i < this.list_8.Count; i++)
				{
					GClass126.smethod_2((i + 1).ToString() + ". " + this.list_8[i].method_0(), 2);
					if (this.list_8[i].string_4 != "")
					{
						GClass126.smethod_2("  " + this.list_8[i].string_4.Replace("\n", GClass107.smethod_3(115047)), 2);
					}
				}
				GClass126.smethod_2("", 2);
				this.bool_1 = false;
			}
			this.string_12 = text;
			this.dataGridView_3.DataSource = GClass127.smethod_14(this.list_8);
			this.dataGridView_3.Invalidate();
		}
		new Thread(new ThreadStart(this.method_9)).Start();
	}

	// Token: 0x06000533 RID: 1331 RVA: 0x000BEA34 File Offset: 0x000BCC34
	private void comboBox_2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (GClass127.smethod_48(this.comboBox_2.SelectedItem).Contains("MAP"))
		{
			int num = GClass127.smethod_37(GClass127.smethod_48(this.comboBox_2.SelectedItem).Replace("/MAP", ""));
			GClass105 gclass = GClass126.smethod_0();
			if (gclass != null)
			{
				gclass.int_2 = num;
			}
			this.gclass114_1.Refresh();
			this.gclass114_0.Controls.Clear();
			this.gclass114_0.RowStyles.Clear();
			this.gclass114_0.RowCount = num;
			float float_ = Convert.ToSingle(this.comboBox_0.SelectedItem.ToString().Replace("x", ""), NumberFormatInfo.InvariantInfo);
			float height = (float)(100 / num);
			for (int i = 0; i < num; i++)
			{
				GClass115 gclass2 = new GClass117(i);
				gclass2.Dock = DockStyle.Fill;
				gclass2.method_1(float_);
				this.gclass114_0.Controls.Add(gclass2);
				this.gclass114_0.RowStyles.Add(new RowStyle(SizeType.Percent, height));
			}
			this.gclass114_0.Focus();
			return;
		}
		int num2 = GClass127.smethod_37(GClass127.smethod_48(this.comboBox_2.SelectedItem).Replace("/2D", ""));
		GClass105 gclass3 = GClass126.smethod_0();
		if (gclass3 != null)
		{
			gclass3.int_2 = num2;
		}
		this.gclass114_1.Refresh();
		this.gclass114_0.Controls.Clear();
		this.gclass114_0.RowStyles.Clear();
		this.gclass114_0.RowCount = num2;
		float float_2 = Convert.ToSingle(this.comboBox_0.SelectedItem.ToString().Replace("x", ""), NumberFormatInfo.InvariantInfo);
		float height2 = (float)(100 / num2);
		for (int j = 0; j < num2; j++)
		{
			GClass115 gclass4 = new GClass116(j);
			gclass4.Dock = DockStyle.Fill;
			gclass4.method_1(float_2);
			this.gclass114_0.Controls.Add(gclass4);
			this.gclass114_0.RowStyles.Add(new RowStyle(SizeType.Percent, height2));
		}
		this.gclass114_0.Focus();
	}

	// Token: 0x06000534 RID: 1332 RVA: 0x000BEC64 File Offset: 0x000BCE64
	private void dataGridView_1_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == 0 && e.RowIndex >= 0)
		{
			TableDataRowP tableDataRowP = (TableDataRowP)this.dataGridView_1.Rows[e.RowIndex].DataBoundItem;
			if (!tableDataRowP.Selected && !GClass126.bool_13)
			{
				int num = 0;
				for (int i = 0; i < this.list_0.Count; i++)
				{
					if (this.list_0[i].bool_0)
					{
						num++;
						if (num > 4)
						{
							break;
						}
					}
				}
				if (num < 4)
				{
					tableDataRowP.Selected = !tableDataRowP.Selected;
				}
				else
				{
					MessageBox.Show(GClass121.smethod_6("1073"), GClass121.smethod_6("1070"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				tableDataRowP.Selected = !tableDataRowP.Selected;
			}
			if (this.checkBox_0.Enabled && this.checkBox_0.Checked)
			{
				int firstDisplayedScrollingRowIndex = this.dataGridView_1.FirstDisplayedScrollingRowIndex;
				this.button_8_Click(null, null);
				if (this.dataGridView_1.Rows.Count > e.RowIndex)
				{
					this.dataGridView_1.Rows[e.RowIndex].Selected = true;
					this.dataGridView_1.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
					this.dataGridView_1.CurrentCell = this.dataGridView_1.Rows[e.RowIndex].Cells[0];
					return;
				}
			}
			else
			{
				this.dataGridView_1.UpdateCellValue(0, this.dataGridView_1.SelectedRows[0].Index);
			}
			return;
		}
	}

	// Token: 0x06000535 RID: 1333 RVA: 0x000BEDF4 File Offset: 0x000BCFF4
	private void dataGridView_1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
		{
			if (this.int_0 == 0)
			{
				this.string_13 = "";
			}
			if (this.timer_2.Interval < 500)
			{
				this.int_0 = 10;
			}
			else
			{
				this.int_0 = 4;
			}
			this.string_13 += e.KeyChar.ToString().ToUpper();
			this.label_17.Text = this.string_13;
			this.label_17.Visible = true;
			if (this.string_13.Length > 2)
			{
				List<TableDataRowP> list = new List<TableDataRowP>();
				List<TableDataRowP> list2 = new List<TableDataRowP>();
				foreach (GClass104 gclass in this.list_0)
				{
					if (gclass.string_0.ToUpper().Contains(this.string_13))
					{
						gclass.bool_0 = (GClass126.bool_13 || list.Count < 4);
						list.Add(new TableDataRowP(gclass));
					}
					else
					{
						gclass.bool_0 = false;
						list2.Add(new TableDataRowP(gclass));
					}
				}
				list.AddRange(list2);
				this.dataGridView_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
				this.dataGridView_1.DataSource = list;
				this.dataGridView_1.Invalidate();
				this.dataGridView_1.Focus();
				this.dataGridView_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			}
		}
	}

	// Token: 0x06000536 RID: 1334 RVA: 0x000BEF84 File Offset: 0x000BD184
	private void method_37()
	{
		GForm8.Class10 @class = new GForm8.Class10();
		@class.<>4__this = this;
		@class.moduleID = this.dataGridView_4.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_24.Name].Value.ToString();
		this.dataGridView_4.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_25.Name].Value.ToString();
		string s = this.dataGridView_4.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_26.Name].Value.ToString();
		this.dataGridView_4.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_28.Name].Value.ToString();
		GClass126.bool_15 = (this.dataGridView_4.SelectedRows[0].Cells[this.dataGridViewTextBoxColumn_29.Name].Value.ToString() == "1");
		if (GClass126.bool_0)
		{
			GClass126.bool_15 = true;
		}
		this.list_3.Clear();
		this.list_0.Clear();
		this.list_1.Clear();
		this.list_2.Clear();
		this.list_5.Clear();
		GClass97 gclass = null;
		try
		{
			if (!GClass126.bool_15 && !GClass123.bool_10 && GClass126.bool_13)
			{
				gclass = new GClass97();
			}
			else
			{
				gclass = new GClass97(@class.moduleID);
			}
		}
		catch (Exception)
		{
			MessageBox.Show(GClass107.smethod_3(111799), GClass107.smethod_3(111821), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			base.Close();
		}
		foreach (object obj in new DataView(gclass.dataTable_0))
		{
			DataRowView dataRowView = (DataRowView)obj;
			int num = GClass127.smethod_37(dataRowView["CmdType"]);
			GClass104 gclass2 = new GClass104();
			gclass2.byte_0 = GClass127.smethod_5(GClass127.smethod_48(dataRowView["Commands"]));
			gclass2.int_0 = GClass127.smethod_37(dataRowView["StartByte"]);
			gclass2.int_1 = GClass127.smethod_37(dataRowView["NumOfBytes"]);
			gclass2.string_0 = string.Format("{0:000000}", GClass127.smethod_37(dataRowView["MessageID"])) + GClass127.smethod_48(dataRowView["ParamName"]);
			gclass2.string_2 = GClass127.smethod_48(dataRowView["ResultFormat"]);
			gclass2.string_3 = GClass127.smethod_48(dataRowView["Units"]);
			gclass2.string_4 = GClass127.smethod_48(dataRowView["MsgExec"]);
			gclass2.string_5 = new string[]
			{
				GClass127.smethod_48(dataRowView["BitResults"])
			};
			gclass2.string_1 = string.Format("{0:000000}", GClass127.smethod_37(dataRowView["DescID"])) + GClass127.smethod_48(dataRowView["Description"]);
			gclass2.int_2 = GClass127.smethod_37(dataRowView["MessageID"]);
			gclass2.string_6 = gclass2.string_3.ToLower();
			if (GClass125.smethod_71())
			{
				if (gclass2.string_6 == GClass107.smethod_3(111848))
				{
					gclass2.string_3 = "mph";
				}
				if (gclass2.string_6 == "km")
				{
					gclass2.string_3 = "mi";
				}
			}
			if (GClass125.smethod_73() && gclass2.string_6 == "°c")
			{
				gclass2.string_3 = "°F";
			}
			if (GClass125.smethod_75())
			{
				if (gclass2.string_6 == "bar")
				{
					gclass2.string_3 = "psi";
				}
				if (gclass2.string_6 == GClass107.smethod_3(111854))
				{
					gclass2.string_3 = "psi";
				}
			}
			if (GClass125.smethod_79())
			{
				if (gclass2.string_6 == "mm")
				{
					gclass2.string_3 = "in";
				}
				if (gclass2.string_6 == GClass107.smethod_3(111896))
				{
					gclass2.string_3 = GClass107.smethod_3(111909);
				}
				if (gclass2.string_6 == "m")
				{
					gclass2.string_3 = "ft";
				}
				if (gclass2.string_6 == GClass107.smethod_3(111915))
				{
					gclass2.string_3 = GClass107.smethod_3(111957);
				}
			}
			if (GClass125.smethod_77())
			{
				if (gclass2.string_6 == "kg")
				{
					gclass2.string_3 = "lb";
				}
				if (gclass2.string_6 == GClass107.smethod_3(111992))
				{
					gclass2.string_3 = GClass107.smethod_3(111998);
				}
			}
			if (num == 1)
			{
				this.list_3.Add(gclass2);
			}
			else if (num == 2)
			{
				this.list_0.Add(gclass2);
			}
			else if (num == 3)
			{
				this.list_1.Add(gclass2);
			}
			else if (num == 4)
			{
				this.list_2.Add(gclass2);
			}
			else if (num == 9)
			{
				this.list_5.Add(gclass2);
			}
		}
		byte.Parse(s, NumberStyles.HexNumber);
		this.dataGridView_1.DataSource = GClass127.smethod_31(this.list_0);
		this.dataGridView_0.DataSource = GClass127.smethod_31(this.list_3);
		this.dataGridView_2.DataSource = GClass127.smethod_31(this.list_1);
		this.dataGridView_8.DataSource = GClass127.smethod_31(this.list_2);
		int num2 = (int)new FileInfo(GClass125.smethod_30() + GClass107.smethod_3(112037)).Length;
		if ((long)num2 != GClass125.smethod_93())
		{
			GClass125.smethod_94((long)num2);
		}
		GClass126.smethod_2(GClass107.smethod_3(112051) + num2.ToString(), 0);
		new Thread(new ThreadStart(@class.method_0)).Start();
	}

	// Token: 0x06000537 RID: 1335 RVA: 0x000BF5D8 File Offset: 0x000BD7D8
	private void method_38(object sender, GEventArgs5 e)
	{
		GClass126.smethod_2(e.method_1(), 2);
		GClass126.smethod_2(e.method_2(), 2);
		GClass126.smethod_2("", 2);
		try
		{
			base.Invoke(new GForm8.Delegate10(this.method_19), new object[]
			{
				e.method_1(),
				e.method_2(),
				e.method_0() ? GClass121.smethod_6("1059") : "",
				e.method_0(),
				e.method_0() ? 0 : 3000
			});
		}
		catch (Exception)
		{
			GClass126.smethod_2(GClass107.smethod_3(119315), 0);
		}
	}

	// Token: 0x06000538 RID: 1336 RVA: 0x000BF69C File Offset: 0x000BD89C
	private void method_39()
	{
		this.tabControl_0.Visible = false;
		this.panel_11.Visible = true;
		this.method_35(true);
		this.method_7(this.tabPage_4);
		GClass122.smethod_14(this.method_3());
		GClass126.byte_3 = GClass123.byte_0;
		this.button_24.Enabled = true;
		this.button_6.Enabled = true;
		this.button_7.Enabled = false;
		this.button_5.Enabled = true;
	}

	// Token: 0x06000539 RID: 1337 RVA: 0x000BF71C File Offset: 0x000BD91C
	private void dataGridView_1_SelectionChanged(object sender, EventArgs e)
	{
		if (this.dataGridView_1.SelectedRows.Count > 0)
		{
			this.textBox_1.Text = ((TableDataRowP)this.dataGridView_1.SelectedRows[0].DataBoundItem).getDataItem().string_1;
			return;
		}
		this.textBox_1.Text = "";
	}

	// Token: 0x0600053A RID: 1338 RVA: 0x000BF780 File Offset: 0x000BD980
	private void method_40()
	{
		if (this.dataGridView_10.Visible)
		{
			this.dataGridView_10.Visible = false;
			this.gclass114_0.Width = this.flowLayoutPanel_0.Width;
			return;
		}
		this.dataGridView_10.Visible = true;
		this.gclass114_0.Width = this.flowLayoutPanel_0.Width - this.dataGridView_10.Width - 5;
	}

	// Token: 0x0600053B RID: 1339 RVA: 0x000BF7F0 File Offset: 0x000BD9F0
	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		float float_ = Convert.ToSingle(this.comboBox_0.SelectedItem.ToString().Replace("x", ""), NumberFormatInfo.InvariantInfo);
		for (int i = 0; i < this.gclass114_0.Controls.Count; i++)
		{
			((GClass115)this.gclass114_0.Controls[i]).method_1(float_);
		}
		this.gclass114_0.Invalidate();
		this.gclass114_0.Focus();
	}

	// Token: 0x0600053C RID: 1340 RVA: 0x000BF878 File Offset: 0x000BDA78
	private void dataGridView_4_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
	{
		string a = this.dataGridView_4.Rows[e.RowIndex].Cells[this.dataGridViewTextBoxColumn_29.Name].Value.ToString();
		if (!GClass126.bool_13 && !(a == this.string_9))
		{
			this.dataGridView_4.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
			this.dataGridView_4.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
			return;
		}
		this.dataGridView_4.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Navy;
		this.dataGridView_4.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Navy;
	}

	// Token: 0x0600053D RID: 1341 RVA: 0x000BF968 File Offset: 0x000BDB68
	private void label_14_VisibleChanged(object sender, EventArgs e)
	{
		if (this.label_14.Visible)
		{
			return;
		}
		if (GClass122.smethod_13() != GClass125.smethod_24())
		{
			this.method_5();
		}
		if (!GClass126.bool_13)
		{
			return;
		}
		try
		{
			double num = 4.92;
			GClass123.bool_10 = (GClass123.string_2 != "");
			if (GClass123.string_3 == "")
			{
				num /= 3.33;
			}
			if (GClass123.string_2 == "")
			{
				num -= 1.96;
			}
			if (GClass123.string_2 != GClass123.string_3)
			{
				num -= 3.96;
			}
			num = ((num < 0.0) ? 0.0 : (num * 2.56));
			GClass123.int_1 = 256 / (int)num;
		}
		catch (Exception)
		{
			this.method_5();
		}
	}

	// Token: 0x0600053E RID: 1342 RVA: 0x000BFA64 File Offset: 0x000BDC64
	private void method_41(string string_20)
	{
		string text = "";
		string text2 = text;
		string text3 = text;
		string text4 = text2;
		GClass126.smethod_2(this.string_19, 1);
		string text5 = GClass127.smethod_46().Replace(" ", "");
		bool flag = string_20.ToLower() == GClass127.string_11 + GClass127.string_12;
		GClass126.smethod_2(this.string_19, 0);
		GClass121.smethod_7();
		string text6 = GClass121.smethod_2(text5, GClass126.string_10);
		GClass127.smethod_9();
		new Random().Next(0, 50);
		GClass126.smethod_2(this.string_19, 0);
		text3 = GClass127.smethod_2(text6, GClass125.smethod_5());
		text = GClass127.smethod_21(text6, GClass125.smethod_5());
		bool flag2 = false;
		try
		{
			text4 = GClass121.smethod_12("", text3);
			text2 = GClass127.smethod_57("", text);
			flag2 = (string_20.ToLower() == GClass127.string_11 + GClass127.string_9 + GClass127.string_12);
			GClass126.smethod_3();
		}
		catch (Exception)
		{
			this.method_5();
		}
		GClass126.smethod_2(this.string_19, 0);
		this.comboBox_0.SelectedIndex = 4;
		this.comboBox_1.SelectedIndex = this.comboBox_1.Items.Count - 1;
		this.label_3.Text = "0";
		this.panel_13.Visible = false;
		this.panel_15.Visible = false;
		this.panel_14.Visible = false;
		this.panel_16.Visible = false;
		this.comboBox_2.SelectedIndex = 0;
		this.comboBox_2_SelectedIndexChanged(null, null);
		GClass126.bool_21 = GClass121.smethod_14(text2, text, false);
		GClass126.bool_20 = GClass121.smethod_14(text4, text3, true);
		GClass126.smethod_4(GClass107.smethod_3(110646), 0);
		GClass126.bool_21 = GClass126.bool_13;
		GClass126.smethod_4(GClass107.smethod_3(110675), 0);
		GClass127.smethod_0();
		GClass121.smethod_2(GClass107.smethod_3(110691), "OFF");
		if ((!GClass121.smethod_14(GClass107.smethod_3(110729), "180000", false) || !GClass121.smethod_14(GClass107.smethod_3(110729), "170000", true)) && !flag && !flag2)
		{
			this.method_5();
		}
	}

	// Token: 0x0600053F RID: 1343 RVA: 0x000BFC8C File Offset: 0x000BDE8C
	private void button_19_Click(object sender, EventArgs e)
	{
		string a = GClass125.smethod_11();
		if (new GForm12().ShowDialog() == DialogResult.OK || a != GClass125.smethod_11())
		{
			this.bool_0 = true;
			base.Close();
		}
	}

	// Token: 0x06000540 RID: 1344 RVA: 0x000BFCC8 File Offset: 0x000BDEC8
	private void method_42(string string_20)
	{
		foreach (GClass104 gclass104_ in this.list_3)
		{
			this.method_11(gclass104_);
		}
		foreach (GClass104 gclass104_2 in this.list_0)
		{
			this.method_11(gclass104_2);
		}
		foreach (GClass104 gclass104_3 in this.list_1)
		{
			this.method_11(gclass104_3);
		}
		foreach (GClass104 gclass104_4 in this.list_2)
		{
			this.method_11(gclass104_4);
		}
		foreach (GClass104 gclass104_5 in this.list_5)
		{
			this.method_11(gclass104_5);
		}
		if (string_20.StartsWith(GClass107.smethod_3(112073)))
		{
			foreach (GClass104 gclass in this.list_0)
			{
				gclass.string_8 = GClass127.smethod_11(gclass.byte_0[0]).Replace(" ", "");
			}
			using (List<GClass104>.Enumerator enumerator = this.list_2.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass104 gclass2 = enumerator.Current;
					gclass2.string_8 = GClass127.smethod_11(gclass2.byte_0[0]).Replace(" ", "").Substring(0, 8);
				}
				goto IL_29C;
			}
		}
		if (string_20.StartsWith(GClass107.smethod_3(112079)))
		{
			foreach (GClass104 gclass3 in this.list_0)
			{
				gclass3.string_8 = GClass127.smethod_11(gclass3.byte_0[0]).Replace(" ", "").Substring(1);
			}
			foreach (GClass104 gclass4 in this.list_2)
			{
				gclass4.string_8 = GClass127.smethod_11(gclass4.byte_0[0]).Replace(" ", "").Substring(1, 3);
			}
		}
		IL_29C:
		this.list_6 = new List<string>();
		foreach (DataRow dataRow in this.gclass99_0.dataTable_4.Select(GClass107.smethod_3(112087) + string_20 + "'"))
		{
			this.list_6.Add(GClass127.smethod_48(dataRow["ISOCode"]));
		}
		this.list_4 = new List<GClass102>();
		if (!string_20.StartsWith(GClass107.smethod_3(112113)) && !string_20.StartsWith(GClass107.smethod_3(112133)) && !string_20.StartsWith(GClass107.smethod_3(112143)) && !string_20.StartsWith(GClass107.smethod_3(112171)))
		{
			GClass98 gclass5 = new GClass98(string_20);
			this.string_7 = GClass107.smethod_3(112199);
			this.string_7 += GClass107.smethod_3(112203);
			this.string_7 += GClass107.smethod_3(112242);
			GClass102 gclass6 = new GClass102();
			DataView dataView = new DataView(gclass5.dataTable_0);
			bool flag = false;
			foreach (object obj in dataView)
			{
				DataRowView dataRowView = (DataRowView)obj;
				if (GClass127.smethod_48(dataRowView["ErrorCode"]) == "0000")
				{
					if (GClass127.smethod_48(dataRowView["Error"]) != GClass125.smethod_95() && GClass125.smethod_95() != GClass107.smethod_3(112249))
					{
						GClass126.int_1++;
					}
					if ((long)GClass127.smethod_37(dataRowView["MessageID"]) != GClass125.smethod_93() && GClass125.smethod_95() != GClass107.smethod_3(112254))
					{
						GClass126.int_1++;
					}
					flag = true;
					if (GClass125.smethod_97())
					{
						GClass126.int_1 += 3;
					}
					this.string_7 = GClass127.smethod_48(dataRowView["Description"]);
				}
				else
				{
					gclass6 = new GClass102();
					gclass6.string_0 = GClass127.smethod_48(dataRowView["ErrorCode"]);
					gclass6.string_2 = GClass127.smethod_48(dataRowView["Error"]);
					gclass6.int_0 = GClass127.smethod_37(dataRowView["MessageID"]);
					gclass6.string_3 = GClass127.smethod_48(dataRowView["Description"]);
					gclass6.int_1 = GClass127.smethod_37(dataRowView["DescID"]);
					this.list_4.Add(gclass6);
				}
			}
			if (!flag)
			{
				GClass126.smethod_2(GClass107.smethod_3(112265), 0);
			}
		}
	}

	// Token: 0x06000541 RID: 1345 RVA: 0x000C0334 File Offset: 0x000BE534
	private void button_10_Click(object sender, EventArgs e)
	{
		List<TableDataRowP> dataSource = GClass127.smethod_31(this.list_0);
		Class7.smethod_2(dataSource);
		this.dataGridView_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		this.dataGridView_1.DataSource = dataSource;
		this.dataGridView_1.Invalidate();
		this.dataGridView_1.Focus();
		this.dataGridView_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
	}

	// Token: 0x06000542 RID: 1346 RVA: 0x00003F5B File Offset: 0x0000215B
	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		this.dataGridView_1.Focus();
	}

	// Token: 0x06000543 RID: 1347 RVA: 0x00003F69 File Offset: 0x00002169
	private void method_43(object sender, EventArgs e)
	{
		this.toolTip_0.Active = true;
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x000C0390 File Offset: 0x000BE590
	private void method_44()
	{
		GClass126.string_12 = GClass127.smethod_46().Replace(" ", "");
		this.list_7.Clear();
		for (int i = 0; i < 10; i++)
		{
			this.list_7.Add(new SimpleValueData(i, GClass125.smethod_119(i)));
		}
		this.dataGridView_10.DataSource = this.list_7;
		this.button_6.Enabled = true;
		this.button_24.Enabled = true;
		this.button_5.Enabled = true;
		this.button_7.Enabled = false;
		GClass126.smethod_2(GClass107.smethod_3(110216), 0);
		this.label_14.Text = GClass107.smethod_3(110259);
		Application.DoEvents();
		this.method_35(true);
		this.method_7(this.tabPage_4);
		GClass121.smethod_7();
		GClass127.smethod_9();
		GClass126.smethod_2(GClass107.smethod_3(110276), 0);
		this.label_14.Text = GClass107.smethod_3(110314);
		Application.DoEvents();
		string text = GClass127.smethod_46().Replace(" ", "");
		string text2 = GClass127.smethod_2(text, GClass125.smethod_5());
		string text3 = GClass127.smethod_21(text, GClass125.smethod_5());
		string text4 = "";
		string text5 = text4;
		try
		{
			text5 = GClass121.smethod_12("", text2);
			text4 = GClass121.smethod_15("", text3);
			GClass126.smethod_3();
		}
		catch (Exception)
		{
			MessageBox.Show(GClass107.smethod_3(110328), GClass107.smethod_3(110355), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			base.Close();
			return;
		}
		GClass126.smethod_2(GClass107.smethod_3(110391), 0);
		this.label_14.Text = GClass107.smethod_3(110419);
		Application.DoEvents();
		this.label_3.Text = "0";
		this.comboBox_0.SelectedIndex = 4;
		this.comboBox_1.SelectedIndex = this.comboBox_1.Items.Count - 1;
		this.comboBox_2.SelectedIndex = 0;
		this.comboBox_2_SelectedIndexChanged(null, null);
		GClass126.bool_21 = GClass121.smethod_14(text4, text3, false);
		GClass126.bool_20 = GClass121.smethod_14(text5, text2, true);
		GClass126.smethod_10(GClass126.bool_21);
		this.label_14.Text = GClass107.smethod_3(110420);
		Application.DoEvents();
		GClass126.bool_13 = GClass126.bool_21;
		GClass127.smethod_0();
		if (!GClass121.smethod_14(GClass107.smethod_3(110448), "789006", false) || !GClass121.smethod_14(GClass107.smethod_3(110459), "3490123", true))
		{
			string moduleName = Process.GetCurrentProcess().MainModule.ModuleName;
			if (!(moduleName.ToLower() == GClass127.string_11 + GClass127.string_12) && moduleName.ToLower() != GClass127.string_11 + GClass127.string_9 + GClass127.string_12)
			{
				MessageBox.Show(GClass107.smethod_3(110506) + moduleName);
				throw new Exception("---");
			}
		}
		this.label_14.Text = GClass107.smethod_3(110526);
		Application.DoEvents();
	}

	// Token: 0x06000545 RID: 1349 RVA: 0x000C06A8 File Offset: 0x000BE8A8
	private void method_45()
	{
		if (GClass125.smethod_44() == 0)
		{
			this.label_19.Text = "";
			return;
		}
		try
		{
			this.label_19.Text = GClass125.string_1[GClass125.smethod_44()];
			if (GClass125.smethod_49())
			{
				Label label = this.label_19;
				label.Text = label.Text + "  " + GClass125.string_31 + " ";
			}
			if (GClass125.smethod_47())
			{
				Label label2 = this.label_19;
				label2.Text = label2.Text + " >> " + GClass125.smethod_55();
			}
			else if (GClass125.smethod_52())
			{
				Label label3 = this.label_19;
				label3.Text += GClass107.smethod_3(111539);
			}
		}
		catch (Exception)
		{
			this.label_19.Text = "";
		}
	}

	// Token: 0x06000546 RID: 1350 RVA: 0x000C0788 File Offset: 0x000BE988
	private void tabControl_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.tabControl_0.SelectedTab == this.tabPage_7)
		{
			this.dataGridView_4.Focus();
			this.method_13();
		}
		else if (this.tabControl_0.SelectedTab == this.tabPage_1)
		{
			this.textBox_0.Text = GClass126.smethod_7();
		}
		else if (this.tabControl_0.SelectedTab == this.tabPage_2)
		{
			if (this.dataGridView_3.Rows.Count == 0)
			{
				List<GClass102> list = new List<GClass102>();
				list.Add(new GClass102("0000", GClass121.smethod_6("3048"), ""));
				this.dataGridView_3.DataSource = GClass127.smethod_14(list);
				this.dataGridView_3.Invalidate();
			}
			new Thread(new ThreadStart(this.method_9)).Start();
			this.dataGridView_3.Focus();
		}
		else if (this.tabControl_0.SelectedTab == this.tabPage_3)
		{
			GClass126.int_4 = 0;
			this.button_17.Enabled = GClass126.bool_13;
			this.checkBox_0.Enabled = GClass126.bool_13;
			this.checkBox_1.Enabled = GClass126.bool_13;
			this.button_22.Enabled = GClass126.bool_13;
			this.button_21.Enabled = GClass126.bool_13;
			if (this.checkBox_1.Enabled)
			{
				this.checkBox_1.Checked = GClass126.bool_16;
			}
			this.label_17.Visible = false;
			this.dataGridView_1.Focus();
		}
		else if (this.tabControl_0.SelectedTab == this.tabPage_5)
		{
			this.dataGridView_2.Focus();
		}
		else if (this.tabControl_0.SelectedTab == this.tabPage_6)
		{
			this.dataGridView_8.Focus();
		}
		if (this.tabControl_0.SelectedTab == this.tabPage_4)
		{
			this.method_18(true, true);
			if (this.gclass11_0 != null)
			{
				this.gclass11_0.method_8(true);
			}
		}
		if (this.tabControl_0.SelectedTab == this.tabPage_4)
		{
			this.method_23();
		}
		if (this.tabControl_0.SelectedTab != this.tabPage_4)
		{
			this.method_4();
		}
		if (this.tabControl_0.SelectedTab == this.tabPage_5)
		{
			List<TableDataRowP> list2 = new List<TableDataRowP>();
			int num = 0;
			while (num < this.list_0.Count && GClass126.bool_13)
			{
				GClass104 gclass = this.list_0[num];
				if (gclass.bool_0)
				{
					list2.Add(new TableDataRowP(gclass));
					if (list2.Count > 8)
					{
						break;
					}
				}
				num++;
			}
			this.dataGridView_9.DataSource = list2;
			this.gclass11_0.method_8(true);
		}
		GClass126.bool_22 = (this.tabControl_0.SelectedTab == this.tabPage_3 || this.tabControl_0.SelectedTab == this.tabPage_4 || this.tabControl_0.SelectedTab == this.tabPage_5);
	}

	// Token: 0x06000547 RID: 1351 RVA: 0x000C0A74 File Offset: 0x000BEC74
	private void method_46(string string_20)
	{
		GClass105 gclass = GClass126.smethod_0();
		if (gclass == null || gclass.list_3.Count == 0)
		{
			return;
		}
		if (gclass.bool_0 && string_20 == "")
		{
			return;
		}
		gclass.bool_0 = true;
		string text = (GClass125.smethod_18() == "Tab") ? GClass107.smethod_3(115347) : GClass125.smethod_18();
		DateTime now = DateTime.Now;
		if (string_20 == "")
		{
			string_20 = string.Concat(new string[]
			{
				now.ToString(GClass107.smethod_3(115393)),
				"_",
				GClass126.string_7,
				"_",
				gclass.string_0
			});
			string_20 = GClass125.smethod_32() + "\\FESExp_" + string_20.Replace("\\", "_").Replace("/", "_").Replace(".", "_") + ".csv";
		}
		StreamWriter streamWriter;
		try
		{
			streamWriter = new StreamWriter(string_20, false, Encoding.Unicode);
		}
		catch (Exception)
		{
			return;
		}
		try
		{
			string text2 = "\"" + GClass121.smethod_6("4101") + "\"";
			for (int i = 0; i < gclass.list_0.Count; i++)
			{
				text2 += text;
				text2 = text2 + "\"" + gclass.list_0[i] + "\"";
			}
			text2 = text2 + text + "\"TAG\"";
			if (GClass126.bool_16)
			{
				text2 = text2 + text + "\"DTC\"";
			}
			streamWriter.WriteLine(text2);
			text2 = "\"" + GClass121.smethod_6("sec") + "\"";
			for (int j = 0; j < gclass.list_0.Count; j++)
			{
				text2 += text;
				if (gclass.list_1[j] == "")
				{
					text2 += "\" \"";
				}
				else
				{
					text2 = text2 + "\"" + gclass.list_1[j] + "\"";
				}
			}
			text2 = text2 + text + "\" \"";
			if (GClass126.bool_16)
			{
				text2 = text2 + text + "\" \"";
			}
			streamWriter.WriteLine(text2);
			for (int k = 0; k < gclass.list_3.Count; k++)
			{
				text2 = ((float)gclass.list_3[k].int_0 / 1000f).ToString("F2");
				for (int l = 0; l < gclass.list_0.Count; l++)
				{
					text2 += text;
					if (!gclass.list_8[l].string_2.StartsWith("num") && !gclass.list_8[l].string_2.StartsWith("equ"))
					{
						text2 += gclass.list_3[k].list_0[l];
					}
					else
					{
						text2 += string.Format(GClass107.smethod_3(115420), gclass.list_3[k].list_1[l]);
					}
				}
				text2 = string.Concat(new string[]
				{
					text2,
					text,
					"\"",
					gclass.list_3[k].string_0,
					"\""
				});
				if (GClass126.bool_16)
				{
					text2 = string.Concat(new string[]
					{
						text2,
						text,
						"\"",
						gclass.list_3[k].string_1,
						"\""
					});
				}
				streamWriter.WriteLine(text2);
			}
		}
		finally
		{
			streamWriter.Close();
		}
	}

	// Token: 0x06000548 RID: 1352 RVA: 0x000C0EA0 File Offset: 0x000BF0A0
	public GForm8()
	{
		GClass126.stopwatch_0 = Stopwatch.StartNew();
		this.method_52();
		this.method_39();
		this.button_24.Enabled = true;
		this.panel_11.Dock = DockStyle.Fill;
	}

	// Token: 0x06000549 RID: 1353 RVA: 0x000C1058 File Offset: 0x000BF258
	private void method_47(string string_20)
	{
		string text = "";
		string text2 = text;
		string text3 = text;
		string text4 = GClass126.string_12;
		string text5 = text;
		GClass126.smethod_2(GClass107.smethod_3(110537), 0);
		string moduleName = Process.GetCurrentProcess().MainModule.ModuleName;
		text4 = GClass127.smethod_46().Replace(" ", "");
		bool flag = string_20.ToLower() == GClass127.string_11 + GClass127.string_12;
		GClass126.smethod_2(GClass107.smethod_3(110548), 0);
		GClass121.smethod_7();
		if (moduleName != string_20)
		{
			flag = false;
		}
		GClass127.smethod_9();
		GClass126.smethod_2(GClass107.smethod_3(110578), 0);
		text3 = GClass127.smethod_2(text4, GClass125.smethod_5());
		text = GClass127.smethod_21(text4, GClass125.smethod_5());
		bool flag2 = false;
		try
		{
			text5 = GClass121.smethod_12("", text3);
			text2 = GClass121.smethod_15("", text);
			flag2 = (string_20.ToLower() == GClass127.string_11 + GClass127.string_9 + GClass127.string_12);
			GClass126.smethod_3();
		}
		catch (Exception)
		{
			this.method_5();
		}
		GClass126.smethod_2(GClass107.smethod_3(110610), 0);
		this.label_3.Text = "0";
		this.comboBox_0.SelectedIndex = 4;
		this.comboBox_1.SelectedIndex = this.comboBox_1.Items.Count - 1;
		this.comboBox_2.SelectedIndex = 0;
		this.comboBox_2_SelectedIndexChanged(null, null);
		GClass126.bool_21 = GClass121.smethod_14(text2, text, false);
		GClass126.bool_20 = GClass121.smethod_14(text5, text3, true);
		GClass126.smethod_4(GClass107.smethod_3(110640), 0);
		GClass126.bool_21 = GClass126.bool_13;
		GClass126.smethod_4(GClass107.smethod_3(110642), 0);
		GClass127.smethod_0();
		if (!flag && !flag2)
		{
			this.method_5();
		}
	}

	// Token: 0x0600054A RID: 1354 RVA: 0x000C1228 File Offset: 0x000BF428
	private void method_48(object sender, GEventArgs4 e)
	{
		try
		{
			base.Invoke(new GForm8.Delegate11(this.method_50), new object[]
			{
				e.method_0()
			});
		}
		catch (Exception)
		{
			GClass126.smethod_2(GClass107.smethod_3(119397), 0);
		}
	}

	// Token: 0x0600054B RID: 1355 RVA: 0x00003F77 File Offset: 0x00002177
	public static List<Control> smethod_1(Control control_0)
	{
		List<Control> list = GForm8.smethod_0(control_0, 1);
		list.Add(control_0);
		return list;
	}

	// Token: 0x0600054C RID: 1356 RVA: 0x000C1284 File Offset: 0x000BF484
	private void method_49()
	{
		if (GClass126.bool_10)
		{
			return;
		}
		if (GClass125.smethod_38(0) == 0 && GClass125.smethod_38(1) == 0)
		{
			this.gform9_0 = new GForm9(GClass121.smethod_6("1220"), GClass121.smethod_6("1221"), GClass121.smethod_6("1055"), true, 0);
			this.gform9_0.ShowDialog();
			if (this.gform9_0.method_1())
			{
				this.gform9_0 = null;
				try
				{
					GForm6 gform = new GForm6();
					if (gform.ShowDialog() == DialogResult.OK)
					{
						if (gform.list_0.Count > 0)
						{
							GClass125.smethod_39(0, gform.list_0[0]);
							GClass125.smethod_41(0, gform.list_1[0]);
							GClass125.smethod_43(0, gform.list_2[0]);
						}
						else
						{
							GClass125.smethod_39(0, 0);
						}
						if (gform.list_0.Count > 1)
						{
							GClass125.smethod_39(1, gform.list_0[1]);
							GClass125.smethod_41(1, gform.list_1[1]);
							GClass125.smethod_43(1, gform.list_2[1]);
						}
						else
						{
							GClass125.smethod_39(1, 0);
						}
					}
				}
				catch (Exception ex)
				{
					GClass126.smethod_2(GClass107.smethod_3(110925) + ex.Message, 0);
				}
			}
			this.gform9_0 = null;
		}
	}

	// Token: 0x0600054D RID: 1357 RVA: 0x000C13E0 File Offset: 0x000BF5E0
	private void method_50(bool bool_4)
	{
		if (this.gform9_0 != null)
		{
			this.gform9_0.Close();
		}
		if (this.gform10_0 != null)
		{
			this.gform10_0.Close();
		}
		if (this.gform11_0 != null)
		{
			this.gform11_0.Close();
		}
		this.gform9_0 = null;
		this.gform10_0 = null;
		this.gform11_0 = null;
		if (this.gclass11_0 != null && (this.gclass11_0.method_14() == "KA" || this.gclass11_0.method_14() == "DE"))
		{
			this.gform9_0 = new GForm9(GClass121.smethod_6("1222"), "", "", false, 3500);
			this.gform9_0.ShowDialog();
			this.gform9_0 = null;
		}
		base.SuspendLayout();
		this.button_6.Enabled = true;
		this.button_24.Enabled = true;
		this.button_11.Enabled = true;
		this.button_23.Enabled = true;
		this.button_7.Enabled = false;
		this.button_5.Enabled = true;
		this.label_20.Text = " ";
		this.label_20.ForeColor = Color.Red;
		this.label_21.Visible = false;
		if (GClass126.smethod_1() > 600000)
		{
			GClass126.int_7 = GClass126.int_1;
		}
		if (!this.tabControl_0.TabPages.Contains(this.tabPage_7))
		{
			this.panel_11.Visible = true;
			this.tabControl_0.TabPages.Insert(0, this.tabPage_7);
			this.tabControl_0.SelectedTab = this.tabPage_7;
		}
		if (!GClass126.bool_0 || bool_4)
		{
			this.method_35(true);
		}
		this.method_7(this.tabPage_4);
		this.method_7(this.tabPage_1);
		base.ResumeLayout();
		this.panel_11.Visible = false;
		if (!GClass126.bool_0 || bool_4)
		{
			this.timer_1.Enabled = false;
			this.timer_0.Enabled = false;
		}
		if (this.string_0 == "" && this.gclass11_0 != null)
		{
			this.string_0 = this.gclass11_0.method_14();
		}
		if (this.string_1 == "" && this.gclass11_0 != null)
		{
			this.string_1 = this.gclass11_0.method_15();
		}
		this.button_20.Visible = (GClass126.smethod_8() > 20);
		this.panel_18.Visible = (GClass126.smethod_9() > 50);
		GClass126.smethod_11();
		if (GClass126.int_7 != 0)
		{
			new Thread(new ThreadStart(this.method_14)).Start();
		}
		if (GClass126.bool_0)
		{
			GClass125.smethod_45(GClass125.smethod_38(3));
			GClass125.smethod_56(GClass125.smethod_40(3));
			GClass125.smethod_58(GClass125.smethod_42(3));
			this.method_45();
			GClass125.smethod_39(3, 0);
		}
		GClass126.bool_0 = false;
		GClass126.bool_19 = false;
		this.gclass11_0 = null;
		if (this.gform9_0 != null)
		{
			this.gform9_0.Close();
		}
		if (this.gform10_0 != null)
		{
			this.gform10_0.Close();
		}
		if (this.gform11_0 != null)
		{
			this.gform11_0.Close();
		}
		this.gform9_0 = null;
		this.gform10_0 = null;
		this.gform11_0 = null;
		if (GClass126.int_13 != -1)
		{
			base.Close();
		}
	}

	// Token: 0x0600054E RID: 1358 RVA: 0x00003F87 File Offset: 0x00002187
	private void method_51(string string_20)
	{
		this.method_10(string_20);
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x000C172C File Offset: 0x000BF92C
	private void method_52()
	{
		this.icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GForm8));
		this.tabControl_0 = new TabControl();
		this.tabPage_7 = new TabPage();
		this.splitContainer_0 = new SplitContainer();
		this.dataGridView_6 = new DataGridView();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridView_5 = new DataGridView();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		this.label_16 = new Label();
		this.label_8 = new Label();
		this.label_6 = new Label();
		this.dataGridView_4 = new DataGridView();
		this.dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_22 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_23 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_24 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_25 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_26 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_27 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_28 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_29 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_30 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_31 = new DataGridViewTextBoxColumn();
		this.dataGridView_7 = new DataGridView();
		this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		this.flowLayoutPanel_1 = new FlowLayoutPanel();
		this.button_6 = new Button();
		this.imageList_0 = new ImageList(this.icontainer_0);
		this.button_11 = new Button();
		this.button_23 = new Button();
		this.button_24 = new Button();
		this.panel_18 = new Panel();
		this.button_20 = new Button();
		this.button_19 = new Button();
		this.label_11 = new Label();
		this.panel_2 = new Panel();
		this.label_9 = new Label();
		this.panel_1 = new Panel();
		this.panel_12 = new Panel();
		this.button_5 = new Button();
		this.label_10 = new Label();
		this.label_7 = new Label();
		this.tabPage_0 = new TabPage();
		this.panel_3 = new Panel();
		this.panel_0 = new Panel();
		this.label_5 = new Label();
		this.label_4 = new Label();
		this.button_7 = new Button();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
		this.tabPage_2 = new TabPage();
		this.flowLayoutPanel_2 = new FlowLayoutPanel();
		this.button_4 = new Button();
		this.button_26 = new Button();
		this.splitContainer_1 = new SplitContainer();
		this.dataGridView_3 = new DataGridView();
		this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
		this.textBox_6 = new TextBox();
		this.textBox_3 = new TextBox();
		this.panel_4 = new Panel();
		this.tabPage_3 = new TabPage();
		this.flowLayoutPanel_3 = new FlowLayoutPanel();
		this.button_17 = new Button();
		this.button_27 = new Button();
		this.splitContainer_2 = new SplitContainer();
		this.dataGridView_1 = new DataGridView();
		this.dataGridViewCheckBoxColumn_1 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
		this.label_17 = new Label();
		this.button_22 = new Button();
		this.button_21 = new Button();
		this.checkBox_0 = new CheckBox();
		this.checkBox_1 = new CheckBox();
		this.textBox_1 = new TextBox();
		this.button_8 = new Button();
		this.button_10 = new Button();
		this.button_9 = new Button();
		this.panel_5 = new Panel();
		this.tabPage_4 = new TabPage();
		this.dataGridView_10 = new DataGridView();
		this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
		this.flowLayoutPanel_0 = new FlowLayoutPanel();
		this.label_12 = new Label();
		this.button_14 = new Button();
		this.comboBox_2 = new ComboBox();
		this.label_2 = new Label();
		this.button_15 = new Button();
		this.comboBox_1 = new ComboBox();
		this.label_0 = new Label();
		this.button_16 = new Button();
		this.comboBox_0 = new ComboBox();
		this.button_18 = new Button();
		this.label_15 = new Label();
		this.panel_7 = new Panel();
		this.panel_16 = new Panel();
		this.panel_14 = new Panel();
		this.panel_15 = new Panel();
		this.panel_13 = new Panel();
		this.button_25 = new Button();
		this.textBox_4 = new TextBox();
		this.button_0 = new Button();
		this.label_1 = new Label();
		this.label_3 = new Label();
		this.panel_8 = new Panel();
		this.button_1 = new Button();
		this.label_13 = new Label();
		this.comboBox_3 = new ComboBox();
		this.button_12 = new Button();
		this.panel_6 = new Panel();
		this.gclass114_0 = new GClass114();
		this.gclass114_1 = new GClass114();
		this.tabPage_5 = new TabPage();
		this.flowLayoutPanel_4 = new FlowLayoutPanel();
		this.button_2 = new Button();
		this.button_3 = new Button();
		this.button_28 = new Button();
		this.splitContainer_3 = new SplitContainer();
		this.dataGridView_2 = new DataGridView();
		this.dataGridViewCheckBoxColumn_2 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_32 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_33 = new DataGridViewTextBoxColumn();
		this.dataGridView_9 = new DataGridView();
		this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
		this.textBox_2 = new TextBox();
		this.panel_9 = new Panel();
		this.tabPage_6 = new TabPage();
		this.flowLayoutPanel_5 = new FlowLayoutPanel();
		this.button_13 = new Button();
		this.button_29 = new Button();
		this.splitContainer_4 = new SplitContainer();
		this.dataGridView_8 = new DataGridView();
		this.dataGridViewCheckBoxColumn_3 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_34 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_35 = new DataGridViewTextBoxColumn();
		this.textBox_5 = new TextBox();
		this.panel_10 = new Panel();
		this.tabPage_1 = new TabPage();
		this.textBox_0 = new TextBox();
		this.menuStrip_0 = new MenuStrip();
		this.toolStripMenuItem_0 = new ToolStripMenuItem();
		this.toolStripMenuItem_1 = new ToolStripMenuItem();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.timer_1 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.saveFileDialog_0 = new SaveFileDialog();
		this.timer_2 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.label_14 = new Label();
		this.openFileDialog_0 = new OpenFileDialog();
		this.toolTip_0 = new ToolTip(this.icontainer_0);
		this.panel_11 = new Panel();
		this.label_18 = new Label();
		this.label_19 = new Label();
		this.label_20 = new Label();
		this.panel_17 = new Panel();
		this.flowLayoutPanel_6 = new FlowLayoutPanel();
		this.label_21 = new Label();
		this.tabControl_0.SuspendLayout();
		this.tabPage_7.SuspendLayout();
		this.splitContainer_0.Panel1.SuspendLayout();
		this.splitContainer_0.Panel2.SuspendLayout();
		this.splitContainer_0.SuspendLayout();
		((ISupportInitialize)this.dataGridView_6).BeginInit();
		((ISupportInitialize)this.dataGridView_5).BeginInit();
		((ISupportInitialize)this.dataGridView_4).BeginInit();
		((ISupportInitialize)this.dataGridView_7).BeginInit();
		this.flowLayoutPanel_1.SuspendLayout();
		this.panel_1.SuspendLayout();
		this.tabPage_0.SuspendLayout();
		this.panel_0.SuspendLayout();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		this.tabPage_2.SuspendLayout();
		this.flowLayoutPanel_2.SuspendLayout();
		this.splitContainer_1.Panel1.SuspendLayout();
		this.splitContainer_1.Panel2.SuspendLayout();
		this.splitContainer_1.SuspendLayout();
		((ISupportInitialize)this.dataGridView_3).BeginInit();
		this.tabPage_3.SuspendLayout();
		this.flowLayoutPanel_3.SuspendLayout();
		this.splitContainer_2.Panel1.SuspendLayout();
		this.splitContainer_2.Panel2.SuspendLayout();
		this.splitContainer_2.SuspendLayout();
		((ISupportInitialize)this.dataGridView_1).BeginInit();
		this.tabPage_4.SuspendLayout();
		((ISupportInitialize)this.dataGridView_10).BeginInit();
		this.flowLayoutPanel_0.SuspendLayout();
		this.panel_7.SuspendLayout();
		this.panel_8.SuspendLayout();
		this.tabPage_5.SuspendLayout();
		this.flowLayoutPanel_4.SuspendLayout();
		this.splitContainer_3.Panel1.SuspendLayout();
		this.splitContainer_3.Panel2.SuspendLayout();
		this.splitContainer_3.SuspendLayout();
		((ISupportInitialize)this.dataGridView_2).BeginInit();
		((ISupportInitialize)this.dataGridView_9).BeginInit();
		this.tabPage_6.SuspendLayout();
		this.flowLayoutPanel_5.SuspendLayout();
		this.splitContainer_4.Panel1.SuspendLayout();
		this.splitContainer_4.Panel2.SuspendLayout();
		this.splitContainer_4.SuspendLayout();
		((ISupportInitialize)this.dataGridView_8).BeginInit();
		this.tabPage_1.SuspendLayout();
		this.menuStrip_0.SuspendLayout();
		this.panel_11.SuspendLayout();
		this.panel_17.SuspendLayout();
		this.flowLayoutPanel_6.SuspendLayout();
		base.SuspendLayout();
		this.tabControl_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.tabControl_0.Appearance = TabAppearance.FlatButtons;
		this.tabControl_0.Controls.Add(this.tabPage_7);
		this.tabControl_0.Controls.Add(this.tabPage_0);
		this.tabControl_0.Controls.Add(this.tabPage_2);
		this.tabControl_0.Controls.Add(this.tabPage_3);
		this.tabControl_0.Controls.Add(this.tabPage_4);
		this.tabControl_0.Controls.Add(this.tabPage_5);
		this.tabControl_0.Controls.Add(this.tabPage_6);
		this.tabControl_0.Controls.Add(this.tabPage_1);
		this.tabControl_0.Font = new Font(GClass107.smethod_3(120642), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.tabControl_0.HotTrack = true;
		this.tabControl_0.ImageList = this.imageList_0;
		this.tabControl_0.Location = new Point(12, 12);
		this.tabControl_0.Name = GClass107.smethod_3(120670);
		this.tabControl_0.SelectedIndex = 0;
		this.tabControl_0.Size = new Size(858, 462);
		this.tabControl_0.TabIndex = 0;
		this.tabControl_0.Tag = "";
		this.tabControl_0.SelectedIndexChanged += this.tabControl_0_SelectedIndexChanged;
		this.tabControl_0.KeyDown += this.tabControl_0_KeyDown;
		this.tabControl_0.KeyPress += this.tabControl_0_KeyPress;
		this.tabControl_0.KeyUp += this.tabControl_0_KeyUp;
		this.tabPage_7.BackColor = Color.White;
		this.tabPage_7.Controls.Add(this.splitContainer_0);
		this.tabPage_7.ImageKey = GClass107.smethod_3(120689);
		this.tabPage_7.Location = new Point(4, 45);
		this.tabPage_7.Name = GClass107.smethod_3(120695);
		this.tabPage_7.Size = new Size(850, 413);
		this.tabPage_7.TabIndex = 8;
		this.tabPage_7.Tag = "";
		this.tabPage_7.Text = GClass107.smethod_3(120699);
		this.tabPage_7.UseVisualStyleBackColor = true;
		this.splitContainer_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.splitContainer_0.BackColor = Color.Navy;
		this.splitContainer_0.Location = new Point(3, 3);
		this.splitContainer_0.Name = GClass107.smethod_3(120726);
		this.splitContainer_0.Orientation = Orientation.Horizontal;
		this.splitContainer_0.Panel1.BackColor = Color.White;
		this.splitContainer_0.Panel1.Controls.Add(this.dataGridView_6);
		this.splitContainer_0.Panel1.Controls.Add(this.dataGridView_5);
		this.splitContainer_0.Panel1.Controls.Add(this.label_16);
		this.splitContainer_0.Panel1.Controls.Add(this.label_8);
		this.splitContainer_0.Panel1.Controls.Add(this.label_6);
		this.splitContainer_0.Panel2.BackColor = Color.White;
		this.splitContainer_0.Panel2.Controls.Add(this.dataGridView_4);
		this.splitContainer_0.Panel2.Controls.Add(this.dataGridView_7);
		this.splitContainer_0.Panel2.Controls.Add(this.flowLayoutPanel_1);
		this.splitContainer_0.Panel2.Controls.Add(this.button_20);
		this.splitContainer_0.Panel2.Controls.Add(this.button_19);
		this.splitContainer_0.Panel2.Controls.Add(this.label_11);
		this.splitContainer_0.Panel2.Controls.Add(this.panel_2);
		this.splitContainer_0.Panel2.Controls.Add(this.label_9);
		this.splitContainer_0.Panel2.Controls.Add(this.panel_1);
		this.splitContainer_0.Panel2.Controls.Add(this.button_5);
		this.splitContainer_0.Panel2.Controls.Add(this.label_10);
		this.splitContainer_0.Panel2.Controls.Add(this.label_7);
		this.splitContainer_0.Size = new Size(841, 410);
		this.splitContainer_0.SplitterDistance = 170;
		this.splitContainer_0.TabIndex = 19;
		this.dataGridView_6.AllowUserToAddRows = false;
		this.dataGridView_6.AllowUserToDeleteRows = false;
		this.dataGridView_6.AllowUserToResizeRows = false;
		this.dataGridView_6.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
		this.dataGridView_6.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		this.dataGridView_6.BackgroundColor = Color.White;
		this.dataGridView_6.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		this.dataGridView_6.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_6.ColumnHeadersVisible = false;
		this.dataGridView_6.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1
		});
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.White;
		dataGridViewCellStyle.Font = new Font(GClass107.smethod_3(120750), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(248, 248, 168);
		dataGridViewCellStyle.SelectionForeColor = Color.Navy;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		this.dataGridView_6.DefaultCellStyle = dataGridViewCellStyle;
		this.dataGridView_6.Location = new Point(0, 33);
		this.dataGridView_6.MultiSelect = false;
		this.dataGridView_6.Name = GClass107.smethod_3(120788);
		this.dataGridView_6.ReadOnly = true;
		this.dataGridView_6.RowHeadersVisible = false;
		this.dataGridView_6.RowTemplate.DefaultCellStyle.BackColor = Color.White;
		this.dataGridView_6.RowTemplate.DefaultCellStyle.Font = new Font(GClass107.smethod_3(120831), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.dataGridView_6.RowTemplate.DefaultCellStyle.ForeColor = Color.Navy;
		this.dataGridView_6.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 248, 168);
		this.dataGridView_6.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Navy;
		this.dataGridView_6.RowTemplate.Height = 24;
		this.dataGridView_6.ScrollBars = ScrollBars.Vertical;
		this.dataGridView_6.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_6.ShowEditingIcon = false;
		this.dataGridView_6.Size = new Size(223, 134);
		this.dataGridView_6.StandardTab = true;
		this.dataGridView_6.TabIndex = 0;
		this.dataGridView_6.SelectionChanged += this.dataGridView_6_SelectionChanged;
		this.dataGridView_6.Enter += this.dataGridView_7_Leave;
		this.dataGridView_6.Leave += this.dataGridView_7_Leave;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = GClass107.smethod_3(120878);
		this.dataGridViewTextBoxColumn_0.HeaderText = GClass107.smethod_3(120898);
		this.dataGridViewTextBoxColumn_0.Name = GClass107.smethod_3(120899);
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = GClass107.smethod_3(120927);
		this.dataGridViewTextBoxColumn_1.HeaderText = GClass107.smethod_3(120973);
		this.dataGridViewTextBoxColumn_1.Name = GClass107.smethod_3(121006);
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridView_5.AllowUserToAddRows = false;
		this.dataGridView_5.AllowUserToDeleteRows = false;
		this.dataGridView_5.AllowUserToResizeRows = false;
		this.dataGridView_5.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_5.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		this.dataGridView_5.BackgroundColor = Color.White;
		this.dataGridView_5.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		this.dataGridView_5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_5.ColumnHeadersVisible = false;
		this.dataGridView_5.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewTextBoxColumn_3,
			this.dataGridViewTextBoxColumn_4,
			this.dataGridViewTextBoxColumn_5
		});
		this.dataGridView_5.Location = new Point(229, 33);
		this.dataGridView_5.MultiSelect = false;
		this.dataGridView_5.Name = GClass107.smethod_3(121035);
		this.dataGridView_5.ReadOnly = true;
		this.dataGridView_5.RowHeadersVisible = false;
		this.dataGridView_5.RowTemplate.DefaultCellStyle.BackColor = Color.White;
		this.dataGridView_5.RowTemplate.DefaultCellStyle.Font = new Font(GClass107.smethod_3(121058), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.dataGridView_5.RowTemplate.DefaultCellStyle.ForeColor = Color.Navy;
		this.dataGridView_5.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 248, 168);
		this.dataGridView_5.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Navy;
		this.dataGridView_5.RowTemplate.Height = 24;
		this.dataGridView_5.ScrollBars = ScrollBars.Vertical;
		this.dataGridView_5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_5.ShowEditingIcon = false;
		this.dataGridView_5.Size = new Size(612, 134);
		this.dataGridView_5.StandardTab = true;
		this.dataGridView_5.TabIndex = 1;
		this.dataGridView_5.SelectionChanged += this.dataGridView_5_SelectionChanged;
		this.dataGridView_5.Enter += this.dataGridView_7_Leave;
		this.dataGridView_5.KeyPress += this.dataGridView_5_KeyPress;
		this.dataGridView_5.Leave += this.dataGridView_7_Leave;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = GClass107.smethod_3(121098);
		this.dataGridViewTextBoxColumn_2.HeaderText = GClass107.smethod_3(121133);
		this.dataGridViewTextBoxColumn_2.Name = GClass107.smethod_3(121151);
		this.dataGridViewTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewTextBoxColumn_2.Visible = false;
		this.dataGridViewTextBoxColumn_3.DataPropertyName = GClass107.smethod_3(121171);
		this.dataGridViewTextBoxColumn_3.HeaderText = GClass107.smethod_3(121186);
		this.dataGridViewTextBoxColumn_3.Name = GClass107.smethod_3(121209);
		this.dataGridViewTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewTextBoxColumn_3.Visible = false;
		this.dataGridViewTextBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_4.DataPropertyName = GClass107.smethod_3(121253);
		this.dataGridViewTextBoxColumn_4.HeaderText = GClass107.smethod_3(121296);
		this.dataGridViewTextBoxColumn_4.Name = GClass107.smethod_3(121303);
		this.dataGridViewTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewTextBoxColumn_5.DataPropertyName = GClass107.smethod_3(121346);
		this.dataGridViewTextBoxColumn_5.HeaderText = GClass107.smethod_3(121392);
		this.dataGridViewTextBoxColumn_5.Name = GClass107.smethod_3(121423);
		this.dataGridViewTextBoxColumn_5.ReadOnly = true;
		this.dataGridViewTextBoxColumn_5.Visible = false;
		this.label_16.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.label_16.AutoSize = true;
		this.label_16.FlatStyle = FlatStyle.Flat;
		this.label_16.Font = new Font(GClass107.smethod_3(121451), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_16.ForeColor = Color.DarkGray;
		this.label_16.Location = new Point(637, 2);
		this.label_16.MaximumSize = new Size(200, 0);
		this.label_16.MinimumSize = new Size(200, 0);
		this.label_16.Name = GClass107.smethod_3(121485);
		this.label_16.Size = new Size(200, 33);
		this.label_16.TabIndex = 15;
		this.label_16.Tag = "";
		this.label_16.Text = GClass107.smethod_3(121531);
		this.label_16.TextAlign = ContentAlignment.TopRight;
		this.label_8.AutoSize = true;
		this.label_8.FlatStyle = FlatStyle.Flat;
		this.label_8.Font = new Font(GClass107.smethod_3(121554), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_8.ForeColor = Color.DarkGreen;
		this.label_8.Location = new Point(229, 2);
		this.label_8.Name = GClass107.smethod_3(121586);
		this.label_8.Size = new Size(207, 33);
		this.label_8.TabIndex = 14;
		this.label_8.Tag = "1003";
		this.label_8.Text = GClass107.smethod_3(121631);
		this.label_6.AutoSize = true;
		this.label_6.FlatStyle = FlatStyle.Flat;
		this.label_6.Font = new Font(GClass107.smethod_3(121677), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_6.ForeColor = Color.DarkGreen;
		this.label_6.Location = new Point(2, 2);
		this.label_6.Name = GClass107.smethod_3(121681);
		this.label_6.Size = new Size(88, 33);
		this.label_6.TabIndex = 0;
		this.label_6.Tag = "1002";
		this.label_6.Text = GClass107.smethod_3(121711);
		this.dataGridView_4.AllowUserToAddRows = false;
		this.dataGridView_4.AllowUserToDeleteRows = false;
		this.dataGridView_4.AllowUserToResizeRows = false;
		this.dataGridView_4.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		this.dataGridView_4.BackgroundColor = Color.White;
		this.dataGridView_4.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.LightGray;
		dataGridViewCellStyle2.Font = new Font(GClass107.smethod_3(121738), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridViewCellStyle2.ForeColor = Color.DarkGreen;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		this.dataGridView_4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridView_4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_4.ColumnHeadersVisible = false;
		this.dataGridView_4.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_21,
			this.dataGridViewTextBoxColumn_22,
			this.dataGridViewTextBoxColumn_23,
			this.dataGridViewTextBoxColumn_24,
			this.dataGridViewTextBoxColumn_25,
			this.dataGridViewTextBoxColumn_26,
			this.dataGridViewTextBoxColumn_27,
			this.dataGridViewTextBoxColumn_28,
			this.dataGridViewTextBoxColumn_29,
			this.dataGridViewTextBoxColumn_30,
			this.dataGridViewTextBoxColumn_31
		});
		this.dataGridView_4.EnableHeadersVisualStyles = false;
		this.dataGridView_4.Location = new Point(329, 37);
		this.dataGridView_4.MultiSelect = false;
		this.dataGridView_4.Name = GClass107.smethod_3(121756);
		this.dataGridView_4.ReadOnly = true;
		this.dataGridView_4.RowHeadersVisible = false;
		this.dataGridView_4.RowTemplate.DefaultCellStyle.BackColor = Color.White;
		this.dataGridView_4.RowTemplate.DefaultCellStyle.Font = new Font(GClass107.smethod_3(121780), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.dataGridView_4.RowTemplate.DefaultCellStyle.ForeColor = Color.Navy;
		this.dataGridView_4.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 248, 168);
		this.dataGridView_4.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Navy;
		this.dataGridView_4.RowTemplate.Height = 24;
		this.dataGridView_4.ScrollBars = ScrollBars.Vertical;
		this.dataGridView_4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_4.ShowEditingIcon = false;
		this.dataGridView_4.Size = new Size(512, 70);
		this.dataGridView_4.StandardTab = true;
		this.dataGridView_4.TabIndex = 1;
		this.dataGridView_4.RowPrePaint += this.dataGridView_4_RowPrePaint;
		this.dataGridView_4.Enter += this.dataGridView_7_Leave;
		this.dataGridView_4.Leave += this.dataGridView_7_Leave;
		this.dataGridViewTextBoxColumn_21.DataPropertyName = GClass107.smethod_3(121829);
		this.dataGridViewTextBoxColumn_21.HeaderText = GClass107.smethod_3(121861);
		this.dataGridViewTextBoxColumn_21.Name = GClass107.smethod_3(121874);
		this.dataGridViewTextBoxColumn_21.ReadOnly = true;
		this.dataGridViewTextBoxColumn_21.Visible = false;
		this.dataGridViewTextBoxColumn_22.DataPropertyName = GClass107.smethod_3(121899);
		this.dataGridViewTextBoxColumn_22.HeaderText = GClass107.smethod_3(121925);
		this.dataGridViewTextBoxColumn_22.Name = GClass107.smethod_3(121952);
		this.dataGridViewTextBoxColumn_22.ReadOnly = true;
		this.dataGridViewTextBoxColumn_22.Visible = false;
		this.dataGridViewTextBoxColumn_23.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_23.DataPropertyName = GClass107.smethod_3(121999);
		this.dataGridViewTextBoxColumn_23.HeaderText = "ECU";
		this.dataGridViewTextBoxColumn_23.Name = GClass107.smethod_3(122004);
		this.dataGridViewTextBoxColumn_23.ReadOnly = true;
		this.dataGridViewTextBoxColumn_24.DataPropertyName = GClass107.smethod_3(122019);
		this.dataGridViewTextBoxColumn_24.HeaderText = GClass107.smethod_3(122052);
		this.dataGridViewTextBoxColumn_24.Name = GClass107.smethod_3(122078);
		this.dataGridViewTextBoxColumn_24.ReadOnly = true;
		this.dataGridViewTextBoxColumn_24.Visible = false;
		this.dataGridViewTextBoxColumn_25.DataPropertyName = GClass107.smethod_3(122082);
		this.dataGridViewTextBoxColumn_25.HeaderText = GClass107.smethod_3(122109);
		this.dataGridViewTextBoxColumn_25.Name = GClass107.smethod_3(122121);
		this.dataGridViewTextBoxColumn_25.ReadOnly = true;
		this.dataGridViewTextBoxColumn_25.Visible = false;
		this.dataGridViewTextBoxColumn_26.DataPropertyName = GClass107.smethod_3(122137);
		this.dataGridViewTextBoxColumn_26.HeaderText = GClass107.smethod_3(122143);
		this.dataGridViewTextBoxColumn_26.Name = GClass107.smethod_3(122167);
		this.dataGridViewTextBoxColumn_26.ReadOnly = true;
		this.dataGridViewTextBoxColumn_26.Visible = false;
		this.dataGridViewTextBoxColumn_27.DataPropertyName = GClass107.smethod_3(122180);
		this.dataGridViewTextBoxColumn_27.HeaderText = GClass107.smethod_3(122227);
		this.dataGridViewTextBoxColumn_27.Name = GClass107.smethod_3(122260);
		this.dataGridViewTextBoxColumn_27.ReadOnly = true;
		this.dataGridViewTextBoxColumn_27.Visible = false;
		this.dataGridViewTextBoxColumn_28.DataPropertyName = GClass107.smethod_3(122287);
		this.dataGridViewTextBoxColumn_28.HeaderText = GClass107.smethod_3(122295);
		this.dataGridViewTextBoxColumn_28.Name = GClass107.smethod_3(122310);
		this.dataGridViewTextBoxColumn_28.ReadOnly = true;
		this.dataGridViewTextBoxColumn_28.Visible = false;
		this.dataGridViewTextBoxColumn_29.DataPropertyName = GClass107.smethod_3(122323);
		this.dataGridViewTextBoxColumn_29.HeaderText = GClass107.smethod_3(122347);
		this.dataGridViewTextBoxColumn_29.Name = GClass107.smethod_3(122374);
		this.dataGridViewTextBoxColumn_29.ReadOnly = true;
		this.dataGridViewTextBoxColumn_29.Visible = false;
		this.dataGridViewTextBoxColumn_30.DataPropertyName = GClass107.smethod_3(122419);
		this.dataGridViewTextBoxColumn_30.HeaderText = GClass107.smethod_3(122421);
		this.dataGridViewTextBoxColumn_30.Name = GClass107.smethod_3(122457);
		this.dataGridViewTextBoxColumn_30.ReadOnly = true;
		this.dataGridViewTextBoxColumn_30.Visible = false;
		this.dataGridViewTextBoxColumn_31.DataPropertyName = GClass107.smethod_3(122483);
		this.dataGridViewTextBoxColumn_31.HeaderText = GClass107.smethod_3(122526);
		this.dataGridViewTextBoxColumn_31.Name = GClass107.smethod_3(122539);
		this.dataGridViewTextBoxColumn_31.ReadOnly = true;
		this.dataGridViewTextBoxColumn_31.Visible = false;
		this.dataGridView_7.AllowUserToAddRows = false;
		this.dataGridView_7.AllowUserToDeleteRows = false;
		this.dataGridView_7.AllowUserToResizeRows = false;
		this.dataGridView_7.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
		this.dataGridView_7.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		this.dataGridView_7.BackgroundColor = Color.White;
		this.dataGridView_7.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = Color.DarkGreen;
		dataGridViewCellStyle3.Font = new Font(GClass107.smethod_3(122556), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridViewCellStyle3.ForeColor = Color.White;
		dataGridViewCellStyle3.SelectionBackColor = Color.White;
		dataGridViewCellStyle3.SelectionForeColor = Color.DarkGreen;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		this.dataGridView_7.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		this.dataGridView_7.ColumnHeadersHeight = 36;
		this.dataGridView_7.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		this.dataGridView_7.ColumnHeadersVisible = false;
		this.dataGridView_7.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_6,
			this.dataGridViewTextBoxColumn_7
		});
		this.dataGridView_7.EnableHeadersVisualStyles = false;
		this.dataGridView_7.Location = new Point(0, 37);
		this.dataGridView_7.MultiSelect = false;
		this.dataGridView_7.Name = GClass107.smethod_3(122599);
		this.dataGridView_7.ReadOnly = true;
		this.dataGridView_7.RowHeadersVisible = false;
		this.dataGridView_7.RowTemplate.DefaultCellStyle.BackColor = Color.White;
		this.dataGridView_7.RowTemplate.DefaultCellStyle.Font = new Font(GClass107.smethod_3(122620), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.dataGridView_7.RowTemplate.DefaultCellStyle.ForeColor = Color.Navy;
		this.dataGridView_7.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 248, 168);
		this.dataGridView_7.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Navy;
		this.dataGridView_7.RowTemplate.Height = 24;
		this.dataGridView_7.ScrollBars = ScrollBars.Vertical;
		this.dataGridView_7.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_7.ShowEditingIcon = false;
		this.dataGridView_7.Size = new Size(323, 122);
		this.dataGridView_7.StandardTab = true;
		this.dataGridView_7.TabIndex = 0;
		this.dataGridView_7.SelectionChanged += this.dataGridView_7_SelectionChanged;
		this.dataGridView_7.Enter += this.dataGridView_7_Leave;
		this.dataGridView_7.Leave += this.dataGridView_7_Leave;
		this.dataGridViewTextBoxColumn_6.DataPropertyName = GClass107.smethod_3(122652);
		this.dataGridViewTextBoxColumn_6.HeaderText = GClass107.smethod_3(122662);
		this.dataGridViewTextBoxColumn_6.Name = GClass107.smethod_3(122681);
		this.dataGridViewTextBoxColumn_6.ReadOnly = true;
		this.dataGridViewTextBoxColumn_6.Visible = false;
		this.dataGridViewTextBoxColumn_7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_7.DataPropertyName = GClass107.smethod_3(122699);
		this.dataGridViewTextBoxColumn_7.HeaderText = GClass107.smethod_3(122729);
		this.dataGridViewTextBoxColumn_7.Name = GClass107.smethod_3(122774);
		this.dataGridViewTextBoxColumn_7.ReadOnly = true;
		this.flowLayoutPanel_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.flowLayoutPanel_1.Controls.Add(this.button_6);
		this.flowLayoutPanel_1.Controls.Add(this.button_11);
		this.flowLayoutPanel_1.Controls.Add(this.button_23);
		this.flowLayoutPanel_1.Controls.Add(this.button_24);
		this.flowLayoutPanel_1.Controls.Add(this.panel_18);
		this.flowLayoutPanel_1.FlowDirection = FlowDirection.RightToLeft;
		this.flowLayoutPanel_1.Location = new Point(329, 113);
		this.flowLayoutPanel_1.Margin = new Padding(0);
		this.flowLayoutPanel_1.Name = GClass107.smethod_3(122815);
		this.flowLayoutPanel_1.Size = new Size(512, 46);
		this.flowLayoutPanel_1.TabIndex = 25;
		this.flowLayoutPanel_1.WrapContents = false;
		this.button_6.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_6.AutoSize = true;
		this.button_6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_6.FlatAppearance.BorderSize = 2;
		this.button_6.Font = new Font(GClass107.smethod_3(122831), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_6.ForeColor = Color.DarkGreen;
		this.button_6.ImageKey = GClass107.smethod_3(122876);
		this.button_6.ImageList = this.imageList_0;
		this.button_6.Location = new Point(431, 0);
		this.button_6.Margin = new Padding(0);
		this.button_6.MaximumSize = new Size(0, 46);
		this.button_6.MinimumSize = new Size(0, 46);
		this.button_6.Name = GClass107.smethod_3(122884);
		this.button_6.Size = new Size(81, 46);
		this.button_6.TabIndex = 2;
		this.button_6.Tag = "1006";
		this.button_6.Text = "C";
		this.button_6.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_6.UseVisualStyleBackColor = false;
		this.button_6.Click += this.button_6_Click;
		this.imageList_0.ImageStream = (ImageListStreamer)componentResourceManager.GetObject(GClass107.smethod_3(122926));
		this.imageList_0.TransparentColor = Color.Transparent;
		this.imageList_0.Images.SetKeyName(0, GClass107.smethod_3(122972));
		this.imageList_0.Images.SetKeyName(1, GClass107.smethod_3(122993));
		this.imageList_0.Images.SetKeyName(2, GClass107.smethod_3(123023));
		this.imageList_0.Images.SetKeyName(3, GClass107.smethod_3(123063));
		this.imageList_0.Images.SetKeyName(4, GClass107.smethod_3(123092));
		this.imageList_0.Images.SetKeyName(5, GClass107.smethod_3(123110));
		this.imageList_0.Images.SetKeyName(6, GClass107.smethod_3(123140));
		this.imageList_0.Images.SetKeyName(7, GClass107.smethod_3(123175));
		this.imageList_0.Images.SetKeyName(8, GClass107.smethod_3(123222));
		this.imageList_0.Images.SetKeyName(9, GClass107.smethod_3(123263));
		this.imageList_0.Images.SetKeyName(10, GClass107.smethod_3(123280));
		this.imageList_0.Images.SetKeyName(11, GClass107.smethod_3(123281));
		this.imageList_0.Images.SetKeyName(12, GClass107.smethod_3(123283));
		this.imageList_0.Images.SetKeyName(13, GClass107.smethod_3(123331));
		this.imageList_0.Images.SetKeyName(14, GClass107.smethod_3(123362));
		this.imageList_0.Images.SetKeyName(15, GClass107.smethod_3(123408));
		this.imageList_0.Images.SetKeyName(16, GClass107.smethod_3(123426));
		this.imageList_0.Images.SetKeyName(17, GClass107.smethod_3(123465));
		this.imageList_0.Images.SetKeyName(18, GClass107.smethod_3(123505));
		this.imageList_0.Images.SetKeyName(19, GClass107.smethod_3(123519));
		this.imageList_0.Images.SetKeyName(20, GClass107.smethod_3(123556));
		this.imageList_0.Images.SetKeyName(21, GClass107.smethod_3(123589));
		this.imageList_0.Images.SetKeyName(22, GClass107.smethod_3(123630));
		this.imageList_0.Images.SetKeyName(23, GClass107.smethod_3(123663));
		this.button_11.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_11.AutoSize = true;
		this.button_11.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_11.FlatAppearance.BorderSize = 2;
		this.button_11.Font = new Font(GClass107.smethod_3(123709), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_11.ForeColor = Color.DarkGreen;
		this.button_11.ImageKey = GClass107.smethod_3(123714);
		this.button_11.ImageList = this.imageList_0;
		this.button_11.Location = new Point(343, 0);
		this.button_11.Margin = new Padding(0, 0, 8, 0);
		this.button_11.MaximumSize = new Size(0, 46);
		this.button_11.MinimumSize = new Size(0, 46);
		this.button_11.Name = GClass107.smethod_3(123759);
		this.button_11.Size = new Size(80, 46);
		this.button_11.TabIndex = 3;
		this.button_11.Tag = "1010";
		this.button_11.Text = "S";
		this.button_11.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_11.UseVisualStyleBackColor = false;
		this.button_11.Visible = false;
		this.button_11.Click += this.button_11_Click;
		this.button_23.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_23.AutoSize = true;
		this.button_23.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_23.FlatAppearance.BorderSize = 2;
		this.button_23.Font = new Font(GClass107.smethod_3(123777), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_23.ForeColor = Color.DarkGreen;
		this.button_23.ImageKey = GClass107.smethod_3(123815);
		this.button_23.ImageList = this.imageList_0;
		this.button_23.Location = new Point(216, 0);
		this.button_23.Margin = new Padding(0, 0, 8, 0);
		this.button_23.MaximumSize = new Size(0, 46);
		this.button_23.MinimumSize = new Size(0, 46);
		this.button_23.Name = GClass107.smethod_3(123850);
		this.button_23.Size = new Size(119, 46);
		this.button_23.TabIndex = 4;
		this.button_23.Tag = "1010";
		this.button_23.Text = "DTC";
		this.button_23.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_23.UseVisualStyleBackColor = false;
		this.button_23.Click += this.button_23_Click;
		this.button_24.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_24.AutoSize = true;
		this.button_24.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_24.FlatAppearance.BorderSize = 2;
		this.button_24.Font = new Font(GClass107.smethod_3(123891), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_24.ForeColor = Color.DarkGreen;
		this.button_24.ImageKey = GClass107.smethod_3(123911);
		this.button_24.ImageList = this.imageList_0;
		this.button_24.Location = new Point(94, 0);
		this.button_24.Margin = new Padding(0, 0, 8, 0);
		this.button_24.MaximumSize = new Size(0, 46);
		this.button_24.MinimumSize = new Size(0, 46);
		this.button_24.Name = GClass107.smethod_3(123917);
		this.button_24.Size = new Size(114, 46);
		this.button_24.TabIndex = 5;
		this.button_24.Tag = "1016";
		this.button_24.Text = "Sim";
		this.button_24.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_24.UseVisualStyleBackColor = false;
		this.button_24.Click += this.button_24_Click;
		this.panel_18.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
		this.panel_18.BackgroundImage = (Image)componentResourceManager.GetObject(GClass107.smethod_3(123948));
		this.panel_18.BackgroundImageLayout = ImageLayout.None;
		this.panel_18.Cursor = Cursors.Hand;
		this.panel_18.Location = new Point(40, 0);
		this.panel_18.Margin = new Padding(0, 0, 8, 0);
		this.panel_18.Name = GClass107.smethod_3(123978);
		this.panel_18.Size = new Size(46, 46);
		this.panel_18.TabIndex = 26;
		this.panel_18.Visible = false;
		this.panel_18.Click += this.panel_18_Click;
		this.button_20.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_20.BackColor = Color.Red;
		this.button_20.FlatStyle = FlatStyle.Popup;
		this.button_20.Font = new Font(GClass107.smethod_3(124003), 8.064f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.button_20.ForeColor = Color.White;
		this.button_20.Location = new Point(395, 176);
		this.button_20.Name = GClass107.smethod_3(124024);
		this.button_20.Size = new Size(168, 25);
		this.button_20.TabIndex = 24;
		this.button_20.Tag = "1011";
		this.button_20.Text = GClass107.smethod_3(124069);
		this.button_20.UseVisualStyleBackColor = false;
		this.button_20.Visible = false;
		this.button_20.Click += this.button_20_Click;
		this.button_19.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_19.BackColor = Color.Navy;
		this.button_19.FlatStyle = FlatStyle.Flat;
		this.button_19.Font = new Font(GClass107.smethod_3(124115), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_19.ForeColor = Color.White;
		this.button_19.Location = new Point(0, 161);
		this.button_19.Name = GClass107.smethod_3(124140);
		this.button_19.Size = new Size(216, 27);
		this.button_19.TabIndex = 23;
		this.button_19.Text = GClass107.smethod_3(124173);
		this.button_19.UseVisualStyleBackColor = false;
		this.button_19.Click += this.button_19_Click;
		this.label_11.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_11.AutoSize = true;
		this.label_11.Cursor = Cursors.Hand;
		this.label_11.Font = new Font(GClass107.smethod_3(124204), 10.944f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_11.ForeColor = Color.Navy;
		this.label_11.Location = new Point(220, 211);
		this.label_11.Name = GClass107.smethod_3(124250);
		this.label_11.Size = new Size(247, 26);
		this.label_11.TabIndex = 22;
		this.label_11.Text = GClass107.smethod_3(124279);
		this.label_11.MouseClick += this.label_11_MouseClick;
		this.panel_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_2.BackColor = Color.Navy;
		this.panel_2.Location = new Point(222, 168);
		this.panel_2.Name = GClass107.smethod_3(124294);
		this.panel_2.Size = new Size(392, 5);
		this.panel_2.TabIndex = 21;
		this.label_9.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_9.AutoSize = true;
		this.label_9.BackColor = Color.Red;
		this.label_9.Font = new Font(GClass107.smethod_3(124303), 9.216f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_9.ForeColor = Color.White;
		this.label_9.Location = new Point(224, 192);
		this.label_9.Name = GClass107.smethod_3(124321);
		this.label_9.Size = new Size(396, 22);
		this.label_9.TabIndex = 17;
		this.label_9.Tag = "1009";
		this.label_9.Text = GClass107.smethod_3(124340);
		this.label_9.Visible = false;
		this.panel_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.panel_1.BackgroundImage = (Image)componentResourceManager.GetObject(GClass107.smethod_3(124388));
		this.panel_1.BackgroundImageLayout = ImageLayout.None;
		this.panel_1.Controls.Add(this.panel_12);
		this.panel_1.Location = new Point(571, 165);
		this.panel_1.Name = GClass107.smethod_3(124436);
		this.panel_1.Size = new Size(270, 70);
		this.panel_1.TabIndex = 20;
		this.panel_12.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.panel_12.BackColor = Color.Navy;
		this.panel_12.Location = new Point(130, 5);
		this.panel_12.Name = GClass107.smethod_3(124459);
		this.panel_12.Size = new Size(140, 5);
		this.panel_12.TabIndex = 26;
		this.button_5.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_5.FlatAppearance.BorderSize = 2;
		this.button_5.Font = new Font(GClass107.smethod_3(124485), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_5.ImageKey = GClass107.smethod_3(124490);
		this.button_5.ImageList = this.imageList_0;
		this.button_5.Location = new Point(0, 189);
		this.button_5.Name = GClass107.smethod_3(124534);
		this.button_5.Size = new Size(216, 46);
		this.button_5.TabIndex = 4;
		this.button_5.Tag = "1008";
		this.button_5.Text = GClass107.smethod_3(124539);
		this.button_5.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_5.UseVisualStyleBackColor = false;
		this.button_5.Click += this.button_5_Click;
		this.label_10.AutoSize = true;
		this.label_10.FlatStyle = FlatStyle.Flat;
		this.label_10.Font = new Font(GClass107.smethod_3(124553), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_10.ForeColor = Color.DarkGreen;
		this.label_10.Location = new Point(328, 4);
		this.label_10.Name = GClass107.smethod_3(124583);
		this.label_10.Size = new Size(222, 33);
		this.label_10.TabIndex = 2;
		this.label_10.Tag = "1005";
		this.label_10.Text = GClass107.smethod_3(124629);
		this.label_10.TextAlign = ContentAlignment.BottomLeft;
		this.label_7.AutoSize = true;
		this.label_7.FlatStyle = FlatStyle.Flat;
		this.label_7.Font = new Font(GClass107.smethod_3(124673), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_7.ForeColor = Color.DarkGreen;
		this.label_7.Location = new Point(2, 4);
		this.label_7.Name = GClass107.smethod_3(124697);
		this.label_7.Size = new Size(116, 33);
		this.label_7.TabIndex = 0;
		this.label_7.Tag = "1004";
		this.label_7.Text = GClass107.smethod_3(124720);
		this.label_7.TextAlign = ContentAlignment.BottomLeft;
		this.tabPage_0.BackColor = Color.White;
		this.tabPage_0.Controls.Add(this.panel_3);
		this.tabPage_0.Controls.Add(this.panel_0);
		this.tabPage_0.Controls.Add(this.button_7);
		this.tabPage_0.Controls.Add(this.dataGridView_0);
		this.tabPage_0.ImageKey = GClass107.smethod_3(124733);
		this.tabPage_0.Location = new Point(4, 45);
		this.tabPage_0.Name = GClass107.smethod_3(124779);
		this.tabPage_0.Padding = new Padding(3);
		this.tabPage_0.Size = new Size(850, 413);
		this.tabPage_0.TabIndex = 0;
		this.tabPage_0.Tag = "";
		this.tabPage_0.Text = GClass107.smethod_3(124791);
		this.tabPage_0.UseVisualStyleBackColor = true;
		this.panel_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.panel_3.BackgroundImage = (Image)componentResourceManager.GetObject(GClass107.smethod_3(124792));
		this.panel_3.BackgroundImageLayout = ImageLayout.Center;
		this.panel_3.Location = new Point(4, 367);
		this.panel_3.Name = GClass107.smethod_3(124839);
		this.panel_3.Size = new Size(242, 44);
		this.panel_3.TabIndex = 16;
		this.panel_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_0.BackColor = Color.FromArgb(240, 240, 192);
		this.panel_0.Controls.Add(this.label_5);
		this.panel_0.Controls.Add(this.label_4);
		this.panel_0.Location = new Point(6, 6);
		this.panel_0.Name = GClass107.smethod_3(124883);
		this.panel_0.Size = new Size(838, 88);
		this.panel_0.TabIndex = 14;
		this.label_5.AutoSize = true;
		this.label_5.FlatStyle = FlatStyle.Flat;
		this.label_5.Font = new Font(GClass107.smethod_3(124903), 19.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_5.ForeColor = Color.DarkGreen;
		this.label_5.Location = new Point(6, 5);
		this.label_5.Name = GClass107.smethod_3(124921);
		this.label_5.Size = new Size(632, 46);
		this.label_5.TabIndex = 13;
		this.label_5.Text = GClass107.smethod_3(124928);
		this.label_4.AutoSize = true;
		this.label_4.FlatStyle = FlatStyle.Flat;
		this.label_4.Font = new Font(GClass107.smethod_3(124954), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_4.ForeColor = Color.DarkGreen;
		this.label_4.Location = new Point(9, 49);
		this.label_4.Name = GClass107.smethod_3(124977);
		this.label_4.Size = new Size(448, 33);
		this.label_4.TabIndex = 12;
		this.label_4.Text = GClass107.smethod_3(125019);
		this.button_7.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_7.AutoSize = true;
		this.button_7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_7.Font = new Font(GClass107.smethod_3(125034), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_7.ForeColor = Color.Red;
		this.button_7.ImageKey = GClass107.smethod_3(125064);
		this.button_7.ImageList = this.imageList_0;
		this.button_7.Location = new Point(632, 363);
		this.button_7.MaximumSize = new Size(0, 46);
		this.button_7.MinimumSize = new Size(0, 46);
		this.button_7.Name = GClass107.smethod_3(125070);
		this.button_7.Size = new Size(212, 46);
		this.button_7.TabIndex = 9;
		this.button_7.Tag = "2002";
		this.button_7.Text = GClass107.smethod_3(125107);
		this.button_7.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_7.UseVisualStyleBackColor = false;
		this.button_7.Click += this.button_29_Click;
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.AllowUserToResizeRows = false;
		this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_0.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		this.dataGridView_0.BackgroundColor = Color.White;
		this.dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.ColumnHeadersVisible = false;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_8,
			this.dataGridViewTextBoxColumn_9,
			this.dataGridViewTextBoxColumn_10
		});
		this.dataGridView_0.Location = new Point(6, 100);
		this.dataGridView_0.Name = GClass107.smethod_3(125119);
		this.dataGridView_0.ReadOnly = true;
		this.dataGridView_0.RowHeadersVisible = false;
		this.dataGridView_0.RowTemplate.DefaultCellStyle.BackColor = Color.White;
		this.dataGridView_0.RowTemplate.DefaultCellStyle.Font = new Font(GClass107.smethod_3(125137), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.dataGridView_0.RowTemplate.DefaultCellStyle.ForeColor = Color.Navy;
		this.dataGridView_0.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 248, 168);
		this.dataGridView_0.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Navy;
		this.dataGridView_0.RowTemplate.Height = 24;
		this.dataGridView_0.ScrollBars = ScrollBars.Vertical;
		this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_0.ShowEditingIcon = false;
		this.dataGridView_0.Size = new Size(838, 259);
		this.dataGridView_0.TabIndex = 1;
		this.dataGridView_0.RowPrePaint += this.dataGridView_0_RowPrePaint;
		this.dataGridViewTextBoxColumn_8.DataPropertyName = GClass107.smethod_3(125174);
		this.dataGridViewTextBoxColumn_8.HeaderText = GClass107.smethod_3(125211);
		this.dataGridViewTextBoxColumn_8.Name = GClass107.smethod_3(125237);
		this.dataGridViewTextBoxColumn_8.ReadOnly = true;
		this.dataGridViewTextBoxColumn_8.Visible = false;
		this.dataGridViewTextBoxColumn_9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_9.DataPropertyName = GClass107.smethod_3(125256);
		this.dataGridViewTextBoxColumn_9.FillWeight = 40f;
		this.dataGridViewTextBoxColumn_9.HeaderText = GClass107.smethod_3(125295);
		this.dataGridViewTextBoxColumn_9.Name = GClass107.smethod_3(125307);
		this.dataGridViewTextBoxColumn_9.ReadOnly = true;
		this.dataGridViewTextBoxColumn_10.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_10.DataPropertyName = GClass107.smethod_3(125322);
		this.dataGridViewTextBoxColumn_10.FillWeight = 60f;
		this.dataGridViewTextBoxColumn_10.HeaderText = GClass107.smethod_3(125337);
		this.dataGridViewTextBoxColumn_10.Name = GClass107.smethod_3(125348);
		this.dataGridViewTextBoxColumn_10.ReadOnly = true;
		this.tabPage_2.BackColor = Color.White;
		this.tabPage_2.Controls.Add(this.flowLayoutPanel_2);
		this.tabPage_2.Controls.Add(this.splitContainer_1);
		this.tabPage_2.Controls.Add(this.panel_4);
		this.tabPage_2.ImageKey = GClass107.smethod_3(125374);
		this.tabPage_2.Location = new Point(4, 45);
		this.tabPage_2.Name = GClass107.smethod_3(125391);
		this.tabPage_2.Padding = new Padding(3);
		this.tabPage_2.Size = new Size(850, 413);
		this.tabPage_2.TabIndex = 2;
		this.tabPage_2.Tag = "";
		this.tabPage_2.Text = GClass107.smethod_3(125435);
		this.tabPage_2.UseVisualStyleBackColor = true;
		this.flowLayoutPanel_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.flowLayoutPanel_2.Controls.Add(this.button_4);
		this.flowLayoutPanel_2.Controls.Add(this.button_26);
		this.flowLayoutPanel_2.FlowDirection = FlowDirection.RightToLeft;
		this.flowLayoutPanel_2.Location = new Point(252, 365);
		this.flowLayoutPanel_2.Name = GClass107.smethod_3(125459);
		this.flowLayoutPanel_2.Size = new Size(592, 46);
		this.flowLayoutPanel_2.TabIndex = 19;
		this.flowLayoutPanel_2.WrapContents = false;
		this.button_4.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_4.AutoSize = true;
		this.button_4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_4.Font = new Font(GClass107.smethod_3(125461), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_4.ImageKey = GClass107.smethod_3(125483);
		this.button_4.ImageList = this.imageList_0;
		this.button_4.Location = new Point(368, 0);
		this.button_4.Margin = new Padding(0);
		this.button_4.MaximumSize = new Size(0, 46);
		this.button_4.MinimumSize = new Size(0, 46);
		this.button_4.Name = GClass107.smethod_3(125486);
		this.button_4.Size = new Size(224, 46);
		this.button_4.TabIndex = 2;
		this.button_4.Tag = "3002";
		this.button_4.Text = GClass107.smethod_3(125507);
		this.button_4.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_4.UseVisualStyleBackColor = false;
		this.button_4.Click += this.button_4_Click;
		this.button_26.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_26.AutoSize = true;
		this.button_26.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_26.Font = new Font(GClass107.smethod_3(125542), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_26.ForeColor = Color.Red;
		this.button_26.ImageKey = GClass107.smethod_3(125576);
		this.button_26.ImageList = this.imageList_0;
		this.button_26.Location = new Point(146, 0);
		this.button_26.Margin = new Padding(0, 0, 10, 0);
		this.button_26.MaximumSize = new Size(0, 46);
		this.button_26.MinimumSize = new Size(0, 46);
		this.button_26.Name = GClass107.smethod_3(125605);
		this.button_26.Size = new Size(212, 46);
		this.button_26.TabIndex = 10;
		this.button_26.Tag = "2002";
		this.button_26.Text = GClass107.smethod_3(125623);
		this.button_26.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_26.UseVisualStyleBackColor = false;
		this.button_26.Click += this.button_29_Click;
		this.splitContainer_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.splitContainer_1.BackColor = Color.Navy;
		this.splitContainer_1.Location = new Point(6, 6);
		this.splitContainer_1.Name = GClass107.smethod_3(125637);
		this.splitContainer_1.Orientation = Orientation.Horizontal;
		this.splitContainer_1.Panel1.BackColor = Color.White;
		this.splitContainer_1.Panel1.Controls.Add(this.dataGridView_3);
		this.splitContainer_1.Panel2.BackColor = Color.White;
		this.splitContainer_1.Panel2.Controls.Add(this.textBox_6);
		this.splitContainer_1.Panel2.Controls.Add(this.textBox_3);
		this.splitContainer_1.Size = new Size(838, 353);
		this.splitContainer_1.SplitterDistance = 162;
		this.splitContainer_1.TabIndex = 18;
		this.dataGridView_3.AllowUserToAddRows = false;
		this.dataGridView_3.AllowUserToDeleteRows = false;
		this.dataGridView_3.AllowUserToResizeRows = false;
		this.dataGridView_3.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		this.dataGridView_3.BackgroundColor = Color.White;
		this.dataGridView_3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_3.ColumnHeadersVisible = false;
		this.dataGridView_3.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_15,
			this.dataGridViewTextBoxColumn_16,
			this.dataGridViewTextBoxColumn_17,
			this.dataGridViewTextBoxColumn_18
		});
		this.dataGridView_3.Location = new Point(0, 0);
		this.dataGridView_3.MultiSelect = false;
		this.dataGridView_3.Name = GClass107.smethod_3(125685);
		this.dataGridView_3.ReadOnly = true;
		this.dataGridView_3.RowHeadersVisible = false;
		this.dataGridView_3.RowTemplate.DefaultCellStyle.BackColor = Color.White;
		this.dataGridView_3.RowTemplate.DefaultCellStyle.Font = new Font(GClass107.smethod_3(125686), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.dataGridView_3.RowTemplate.DefaultCellStyle.ForeColor = Color.Navy;
		this.dataGridView_3.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 248, 168);
		this.dataGridView_3.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Navy;
		this.dataGridView_3.RowTemplate.Height = 24;
		this.dataGridView_3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_3.ShowEditingIcon = false;
		this.dataGridView_3.Size = new Size(838, 159);
		this.dataGridView_3.TabIndex = 0;
		this.dataGridView_3.RowPrePaint += this.dataGridView_3_RowPrePaint;
		this.dataGridView_3.SelectionChanged += this.dataGridView_3_SelectionChanged;
		this.dataGridViewTextBoxColumn_15.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_15.DataPropertyName = GClass107.smethod_3(125728);
		this.dataGridViewTextBoxColumn_15.FillWeight = 70f;
		this.dataGridViewTextBoxColumn_15.HeaderText = GClass107.smethod_3(125751);
		this.dataGridViewTextBoxColumn_15.MinimumWidth = 500;
		this.dataGridViewTextBoxColumn_15.Name = GClass107.smethod_3(125752);
		this.dataGridViewTextBoxColumn_15.ReadOnly = true;
		this.dataGridViewTextBoxColumn_15.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_16.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		this.dataGridViewTextBoxColumn_16.DataPropertyName = GClass107.smethod_3(125786);
		this.dataGridViewTextBoxColumn_16.HeaderText = GClass107.smethod_3(125826);
		this.dataGridViewTextBoxColumn_16.Name = GClass107.smethod_3(125840);
		this.dataGridViewTextBoxColumn_16.ReadOnly = true;
		this.dataGridViewTextBoxColumn_16.Width = 5;
		this.dataGridViewTextBoxColumn_17.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		this.dataGridViewTextBoxColumn_17.DataPropertyName = GClass107.smethod_3(125889);
		this.dataGridViewTextBoxColumn_17.HeaderText = GClass107.smethod_3(125915);
		this.dataGridViewTextBoxColumn_17.Name = GClass107.smethod_3(125933);
		this.dataGridViewTextBoxColumn_17.ReadOnly = true;
		this.dataGridViewTextBoxColumn_17.Width = 5;
		this.dataGridViewTextBoxColumn_18.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		this.dataGridViewTextBoxColumn_18.DataPropertyName = GClass107.smethod_3(125962);
		this.dataGridViewTextBoxColumn_18.HeaderText = GClass107.smethod_3(125970);
		this.dataGridViewTextBoxColumn_18.Name = GClass107.smethod_3(126007);
		this.dataGridViewTextBoxColumn_18.ReadOnly = true;
		this.dataGridViewTextBoxColumn_18.Width = 5;
		this.textBox_6.AcceptsReturn = true;
		this.textBox_6.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_6.BackColor = Color.FromArgb(248, 248, 168);
		this.textBox_6.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_6.Font = new Font(GClass107.smethod_3(126053), 9.792f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.textBox_6.ForeColor = Color.DarkSlateBlue;
		this.textBox_6.Location = new Point(472, 2);
		this.textBox_6.Multiline = true;
		this.textBox_6.Name = GClass107.smethod_3(126096);
		this.textBox_6.ReadOnly = true;
		this.textBox_6.ScrollBars = ScrollBars.Vertical;
		this.textBox_6.Size = new Size(364, 184);
		this.textBox_6.TabIndex = 2;
		this.textBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
		this.textBox_3.BackColor = Color.FromArgb(248, 248, 168);
		this.textBox_3.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_3.Font = new Font(GClass107.smethod_3(126104), 9.792f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.textBox_3.ForeColor = Color.DarkSlateBlue;
		this.textBox_3.Location = new Point(0, 3);
		this.textBox_3.Multiline = true;
		this.textBox_3.Name = GClass107.smethod_3(126153);
		this.textBox_3.ReadOnly = true;
		this.textBox_3.ScrollBars = ScrollBars.Vertical;
		this.textBox_3.Size = new Size(466, 184);
		this.textBox_3.TabIndex = 1;
		this.panel_4.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.panel_4.BackgroundImage = (Image)componentResourceManager.GetObject(GClass107.smethod_3(126188));
		this.panel_4.BackgroundImageLayout = ImageLayout.Center;
		this.panel_4.Location = new Point(4, 367);
		this.panel_4.Name = GClass107.smethod_3(126220);
		this.panel_4.Size = new Size(242, 44);
		this.panel_4.TabIndex = 17;
		this.tabPage_3.BackColor = Color.White;
		this.tabPage_3.Controls.Add(this.flowLayoutPanel_3);
		this.tabPage_3.Controls.Add(this.splitContainer_2);
		this.tabPage_3.Controls.Add(this.panel_5);
		this.tabPage_3.ImageKey = GClass107.smethod_3(126253);
		this.tabPage_3.Location = new Point(4, 45);
		this.tabPage_3.Name = GClass107.smethod_3(126296);
		this.tabPage_3.Size = new Size(850, 413);
		this.tabPage_3.TabIndex = 3;
		this.tabPage_3.Tag = "";
		this.tabPage_3.Text = GClass107.smethod_3(126298);
		this.tabPage_3.UseVisualStyleBackColor = true;
		this.flowLayoutPanel_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.flowLayoutPanel_3.Controls.Add(this.button_17);
		this.flowLayoutPanel_3.Controls.Add(this.button_27);
		this.flowLayoutPanel_3.FlowDirection = FlowDirection.RightToLeft;
		this.flowLayoutPanel_3.Location = new Point(252, 365);
		this.flowLayoutPanel_3.Name = GClass107.smethod_3(126310);
		this.flowLayoutPanel_3.Size = new Size(592, 46);
		this.flowLayoutPanel_3.TabIndex = 30;
		this.flowLayoutPanel_3.WrapContents = false;
		this.button_17.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_17.AutoSize = true;
		this.button_17.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_17.Font = new Font(GClass107.smethod_3(126312), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_17.ImageKey = GClass107.smethod_3(126333);
		this.button_17.ImageList = this.imageList_0;
		this.button_17.Location = new Point(392, 0);
		this.button_17.Margin = new Padding(0);
		this.button_17.MaximumSize = new Size(0, 46);
		this.button_17.MinimumSize = new Size(0, 46);
		this.button_17.Name = GClass107.smethod_3(126353);
		this.button_17.Size = new Size(200, 46);
		this.button_17.TabIndex = 29;
		this.button_17.Tag = "4009";
		this.button_17.Text = GClass107.smethod_3(126365);
		this.button_17.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_17.UseVisualStyleBackColor = false;
		this.button_17.Click += this.button_17_Click;
		this.button_27.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_27.AutoSize = true;
		this.button_27.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_27.Font = new Font(GClass107.smethod_3(126374), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_27.ForeColor = Color.Red;
		this.button_27.ImageKey = GClass107.smethod_3(126395);
		this.button_27.ImageList = this.imageList_0;
		this.button_27.Location = new Point(170, 0);
		this.button_27.Margin = new Padding(0, 0, 10, 0);
		this.button_27.MaximumSize = new Size(0, 46);
		this.button_27.MinimumSize = new Size(0, 46);
		this.button_27.Name = GClass107.smethod_3(126398);
		this.button_27.Size = new Size(212, 46);
		this.button_27.TabIndex = 10;
		this.button_27.Tag = "2002";
		this.button_27.Text = GClass107.smethod_3(126431);
		this.button_27.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_27.UseVisualStyleBackColor = false;
		this.button_27.Click += this.button_29_Click;
		this.splitContainer_2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.splitContainer_2.BackColor = Color.Navy;
		this.splitContainer_2.Location = new Point(6, 6);
		this.splitContainer_2.Name = GClass107.smethod_3(126480);
		this.splitContainer_2.Panel1.BackColor = Color.White;
		this.splitContainer_2.Panel1.Controls.Add(this.dataGridView_1);
		this.splitContainer_2.Panel2.BackColor = Color.White;
		this.splitContainer_2.Panel2.Controls.Add(this.label_17);
		this.splitContainer_2.Panel2.Controls.Add(this.button_22);
		this.splitContainer_2.Panel2.Controls.Add(this.button_21);
		this.splitContainer_2.Panel2.Controls.Add(this.checkBox_0);
		this.splitContainer_2.Panel2.Controls.Add(this.checkBox_1);
		this.splitContainer_2.Panel2.Controls.Add(this.textBox_1);
		this.splitContainer_2.Panel2.Controls.Add(this.button_8);
		this.splitContainer_2.Panel2.Controls.Add(this.button_10);
		this.splitContainer_2.Panel2.Controls.Add(this.button_9);
		this.splitContainer_2.Size = new Size(838, 353);
		this.splitContainer_2.SplitterDistance = 592;
		this.splitContainer_2.TabIndex = 19;
		this.dataGridView_1.AllowUserToAddRows = false;
		this.dataGridView_1.AllowUserToDeleteRows = false;
		this.dataGridView_1.AllowUserToResizeRows = false;
		this.dataGridView_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		this.dataGridView_1.BackgroundColor = Color.White;
		this.dataGridView_1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_1.ColumnHeadersVisible = false;
		this.dataGridView_1.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewCheckBoxColumn_1,
			this.dataGridViewTextBoxColumn_13,
			this.dataGridViewTextBoxColumn_14
		});
		this.dataGridView_1.Location = new Point(0, 0);
		this.dataGridView_1.MultiSelect = false;
		this.dataGridView_1.Name = GClass107.smethod_3(126503);
		this.dataGridView_1.ReadOnly = true;
		this.dataGridView_1.RowHeadersVisible = false;
		this.dataGridView_1.RowTemplate.DefaultCellStyle.BackColor = Color.White;
		this.dataGridView_1.RowTemplate.DefaultCellStyle.Font = new Font(GClass107.smethod_3(126541), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.dataGridView_1.RowTemplate.DefaultCellStyle.ForeColor = Color.Navy;
		this.dataGridView_1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 248, 168);
		this.dataGridView_1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Navy;
		this.dataGridView_1.RowTemplate.Height = 24;
		this.dataGridView_1.ScrollBars = ScrollBars.Vertical;
		this.dataGridView_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_1.ShowEditingIcon = false;
		this.dataGridView_1.Size = new Size(589, 353);
		this.dataGridView_1.StandardTab = true;
		this.dataGridView_1.TabIndex = 0;
		this.dataGridView_1.CellClick += this.dataGridView_1_CellClick;
		this.dataGridView_1.RowPrePaint += this.dataGridView_1_RowPrePaint;
		this.dataGridView_1.SelectionChanged += this.dataGridView_1_SelectionChanged;
		this.dataGridView_1.KeyUp += this.dataGridView_1_KeyUp;
		this.dataGridView_1.KeyPress += this.dataGridView_1_KeyPress;
		this.dataGridViewCheckBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		this.dataGridViewCheckBoxColumn_1.DataPropertyName = GClass107.smethod_3(126566);
		this.dataGridViewCheckBoxColumn_1.HeaderText = GClass107.smethod_3(126593);
		this.dataGridViewCheckBoxColumn_1.MinimumWidth = 40;
		this.dataGridViewCheckBoxColumn_1.Name = GClass107.smethod_3(126609);
		this.dataGridViewCheckBoxColumn_1.ReadOnly = true;
		this.dataGridViewCheckBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewCheckBoxColumn_1.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewCheckBoxColumn_1.Width = 40;
		this.dataGridViewTextBoxColumn_13.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_13.DataPropertyName = GClass107.smethod_3(126621);
		this.dataGridViewTextBoxColumn_13.FillWeight = 65f;
		this.dataGridViewTextBoxColumn_13.HeaderText = GClass107.smethod_3(126652);
		this.dataGridViewTextBoxColumn_13.Name = GClass107.smethod_3(126677);
		this.dataGridViewTextBoxColumn_13.ReadOnly = true;
		this.dataGridViewTextBoxColumn_14.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_14.DataPropertyName = GClass107.smethod_3(126724);
		this.dataGridViewTextBoxColumn_14.FillWeight = 35f;
		this.dataGridViewTextBoxColumn_14.HeaderText = GClass107.smethod_3(126751);
		this.dataGridViewTextBoxColumn_14.Name = GClass107.smethod_3(126791);
		this.dataGridViewTextBoxColumn_14.ReadOnly = true;
		this.dataGridViewTextBoxColumn_14.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.label_17.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.label_17.AutoSize = true;
		this.label_17.FlatStyle = FlatStyle.Flat;
		this.label_17.Font = new Font(GClass107.smethod_3(126818), 8.064f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_17.ForeColor = Color.Red;
		this.label_17.Location = new Point(1, 211);
		this.label_17.Name = GClass107.smethod_3(126863);
		this.label_17.Size = new Size(262, 19);
		this.label_17.TabIndex = 30;
		this.label_17.Tag = "4011";
		this.label_17.Text = GClass107.smethod_3(126907);
		this.label_17.Visible = false;
		this.button_22.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_22.AutoSize = true;
		this.button_22.Font = new Font(GClass107.smethod_3(126942), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_22.ImageKey = GClass107.smethod_3(126949);
		this.button_22.ImageList = this.imageList_0;
		this.button_22.Location = new Point(103, 307);
		this.button_22.Name = GClass107.smethod_3(126977);
		this.button_22.Size = new Size(44, 46);
		this.button_22.TabIndex = 31;
		this.button_22.Tag = "4012";
		this.button_22.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_22.UseVisualStyleBackColor = false;
		this.button_22.Click += this.button_22_Click;
		this.button_21.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_21.AutoSize = true;
		this.button_21.Font = new Font(GClass107.smethod_3(127004), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_21.ImageKey = GClass107.smethod_3(127038);
		this.button_21.ImageList = this.imageList_0;
		this.button_21.Location = new Point(153, 307);
		this.button_21.Name = GClass107.smethod_3(127081);
		this.button_21.Size = new Size(44, 46);
		this.button_21.TabIndex = 30;
		this.button_21.Tag = "4013";
		this.button_21.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_21.UseVisualStyleBackColor = false;
		this.button_21.Click += this.button_21_Click;
		this.checkBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.checkBox_0.Appearance = Appearance.Button;
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Enabled = false;
		this.checkBox_0.ImageKey = GClass107.smethod_3(127116);
		this.checkBox_0.ImageList = this.imageList_0;
		this.checkBox_0.Location = new Point(53, 255);
		this.checkBox_0.MaximumSize = new Size(0, 46);
		this.checkBox_0.MinimumSize = new Size(0, 46);
		this.checkBox_0.Name = GClass107.smethod_3(127147);
		this.checkBox_0.Size = new Size(168, 46);
		this.checkBox_0.TabIndex = 28;
		this.checkBox_0.Tag = "4005";
		this.checkBox_0.Text = GClass107.smethod_3(127152);
		this.checkBox_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.checkBox_0.UseVisualStyleBackColor = false;
		this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
		this.checkBox_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.checkBox_1.Appearance = Appearance.Button;
		this.checkBox_1.AutoSize = true;
		this.checkBox_1.Enabled = false;
		this.checkBox_1.ImageKey = GClass107.smethod_3(127201);
		this.checkBox_1.ImageList = this.imageList_0;
		this.checkBox_1.Location = new Point(3, 163);
		this.checkBox_1.MaximumSize = new Size(0, 46);
		this.checkBox_1.MinimumSize = new Size(0, 46);
		this.checkBox_1.Name = GClass107.smethod_3(127231);
		this.checkBox_1.Size = new Size(246, 46);
		this.checkBox_1.TabIndex = 29;
		this.checkBox_1.Tag = "4010";
		this.checkBox_1.Text = GClass107.smethod_3(127253);
		this.checkBox_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.checkBox_1.UseVisualStyleBackColor = false;
		this.checkBox_1.CheckedChanged += this.checkBox_1_CheckedChanged;
		this.textBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_1.BackColor = Color.FromArgb(248, 248, 168);
		this.textBox_1.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_1.Font = new Font(GClass107.smethod_3(127282), 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.textBox_1.ForeColor = Color.DarkSlateBlue;
		this.textBox_1.Location = new Point(3, 0);
		this.textBox_1.Multiline = true;
		this.textBox_1.Name = GClass107.smethod_3(127296);
		this.textBox_1.ReadOnly = true;
		this.textBox_1.ScrollBars = ScrollBars.Vertical;
		this.textBox_1.Size = new Size(239, 156);
		this.textBox_1.TabIndex = 1;
		this.button_8.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_8.AutoSize = true;
		this.button_8.Font = new Font(GClass107.smethod_3(127324), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_8.ImageKey = GClass107.smethod_3(127329);
		this.button_8.ImageList = this.imageList_0;
		this.button_8.Location = new Point(3, 255);
		this.button_8.Name = GClass107.smethod_3(127357);
		this.button_8.Size = new Size(44, 46);
		this.button_8.TabIndex = 2;
		this.button_8.Tag = "4002";
		this.button_8.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_8.UseVisualStyleBackColor = false;
		this.button_8.Click += this.button_8_Click;
		this.button_10.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_10.AutoSize = true;
		this.button_10.Font = new Font(GClass107.smethod_3(127381), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_10.ImageKey = GClass107.smethod_3(127415);
		this.button_10.ImageList = this.imageList_0;
		this.button_10.Location = new Point(53, 307);
		this.button_10.Name = GClass107.smethod_3(127444);
		this.button_10.Size = new Size(44, 46);
		this.button_10.TabIndex = 4;
		this.button_10.Tag = "4004";
		this.button_10.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_10.UseVisualStyleBackColor = false;
		this.button_10.Click += this.button_10_Click;
		this.button_9.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_9.AutoSize = true;
		this.button_9.Font = new Font(GClass107.smethod_3(127478), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_9.ImageKey = GClass107.smethod_3(127526);
		this.button_9.ImageList = this.imageList_0;
		this.button_9.Location = new Point(3, 307);
		this.button_9.Name = GClass107.smethod_3(127548);
		this.button_9.Size = new Size(44, 46);
		this.button_9.TabIndex = 3;
		this.button_9.Tag = "4003";
		this.button_9.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_9.UseVisualStyleBackColor = false;
		this.button_9.Click += this.button_9_Click;
		this.panel_5.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.panel_5.BackgroundImage = (Image)componentResourceManager.GetObject(GClass107.smethod_3(127564));
		this.panel_5.BackgroundImageLayout = ImageLayout.Center;
		this.panel_5.Location = new Point(4, 367);
		this.panel_5.Name = GClass107.smethod_3(127605);
		this.panel_5.Size = new Size(242, 44);
		this.panel_5.TabIndex = 18;
		this.tabPage_4.BackColor = Color.White;
		this.tabPage_4.Controls.Add(this.dataGridView_10);
		this.tabPage_4.Controls.Add(this.flowLayoutPanel_0);
		this.tabPage_4.Controls.Add(this.panel_7);
		this.tabPage_4.Controls.Add(this.panel_8);
		this.tabPage_4.Controls.Add(this.panel_6);
		this.tabPage_4.Controls.Add(this.gclass114_0);
		this.tabPage_4.Controls.Add(this.gclass114_1);
		this.tabPage_4.ImageKey = GClass107.smethod_3(127643);
		this.tabPage_4.Location = new Point(4, 45);
		this.tabPage_4.Name = GClass107.smethod_3(127648);
		this.tabPage_4.Size = new Size(850, 413);
		this.tabPage_4.TabIndex = 4;
		this.tabPage_4.Tag = "";
		this.tabPage_4.Text = GClass107.smethod_3(127656);
		this.tabPage_4.UseVisualStyleBackColor = true;
		this.dataGridView_10.AllowUserToAddRows = false;
		this.dataGridView_10.AllowUserToDeleteRows = false;
		this.dataGridView_10.AllowUserToResizeRows = false;
		this.dataGridView_10.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
		this.dataGridView_10.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		this.dataGridView_10.BackgroundColor = Color.White;
		this.dataGridView_10.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_10.ColumnHeadersVisible = false;
		this.dataGridView_10.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_19,
			this.dataGridViewTextBoxColumn_20
		});
		this.dataGridView_10.Location = new Point(545, 6);
		this.dataGridView_10.MultiSelect = false;
		this.dataGridView_10.Name = GClass107.smethod_3(127692);
		this.dataGridView_10.RowHeadersVisible = false;
		this.dataGridView_10.RowTemplate.Height = 24;
		this.dataGridView_10.ScrollBars = ScrollBars.Vertical;
		this.dataGridView_10.ShowEditingIcon = false;
		this.dataGridView_10.Size = new Size(300, 273);
		this.dataGridView_10.StandardTab = true;
		this.dataGridView_10.TabIndex = 29;
		this.dataGridView_10.Visible = false;
		this.dataGridViewTextBoxColumn_19.DataPropertyName = "ID";
		this.dataGridViewTextBoxColumn_19.HeaderText = GClass107.smethod_3(127708);
		this.dataGridViewTextBoxColumn_19.Name = GClass107.smethod_3(127719);
		this.dataGridViewTextBoxColumn_19.ReadOnly = true;
		this.dataGridViewTextBoxColumn_19.Width = 30;
		this.dataGridViewTextBoxColumn_20.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_20.DataPropertyName = GClass107.smethod_3(127754);
		this.dataGridViewTextBoxColumn_20.HeaderText = GClass107.smethod_3(127761);
		this.dataGridViewTextBoxColumn_20.Name = GClass107.smethod_3(127788);
		this.flowLayoutPanel_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.flowLayoutPanel_0.Controls.Add(this.label_12);
		this.flowLayoutPanel_0.Controls.Add(this.button_14);
		this.flowLayoutPanel_0.Controls.Add(this.comboBox_2);
		this.flowLayoutPanel_0.Controls.Add(this.label_2);
		this.flowLayoutPanel_0.Controls.Add(this.button_15);
		this.flowLayoutPanel_0.Controls.Add(this.comboBox_1);
		this.flowLayoutPanel_0.Controls.Add(this.label_0);
		this.flowLayoutPanel_0.Controls.Add(this.button_16);
		this.flowLayoutPanel_0.Controls.Add(this.comboBox_0);
		this.flowLayoutPanel_0.Controls.Add(this.button_18);
		this.flowLayoutPanel_0.Controls.Add(this.label_15);
		this.flowLayoutPanel_0.Location = new Point(252, 285);
		this.flowLayoutPanel_0.Name = GClass107.smethod_3(127823);
		this.flowLayoutPanel_0.Size = new Size(593, 33);
		this.flowLayoutPanel_0.TabIndex = 28;
		this.label_12.AutoSize = true;
		this.label_12.Dock = DockStyle.Fill;
		this.label_12.Font = new Font(GClass107.smethod_3(127829), 10.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_12.Location = new Point(3, 0);
		this.label_12.Margin = new Padding(3, 0, 0, 0);
		this.label_12.Name = GClass107.smethod_3(127860);
		this.label_12.Size = new Size(91, 38);
		this.label_12.TabIndex = 20;
		this.label_12.Tag = "5020";
		this.label_12.Text = GClass107.smethod_3(127903);
		this.label_12.TextAlign = ContentAlignment.MiddleLeft;
		this.button_14.Dock = DockStyle.Fill;
		this.button_14.FlatAppearance.BorderSize = 0;
		this.button_14.FlatStyle = FlatStyle.Flat;
		this.button_14.ImageKey = GClass107.smethod_3(127922);
		this.button_14.ImageList = this.imageList_0;
		this.button_14.Location = new Point(94, 0);
		this.button_14.Margin = new Padding(0);
		this.button_14.Name = GClass107.smethod_3(127962);
		this.button_14.Size = new Size(33, 38);
		this.button_14.TabIndex = 26;
		this.button_14.UseVisualStyleBackColor = true;
		this.comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_2.FlatStyle = FlatStyle.Flat;
		this.comboBox_2.Font = new Font(GClass107.smethod_3(127977), 10.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Items.AddRange(new object[]
		{
			GClass107.smethod_3(128019),
			GClass107.smethod_3(128052),
			GClass107.smethod_3(128078),
			GClass107.smethod_3(128125),
			GClass107.smethod_3(128169)
		});
		this.comboBox_2.Location = new Point(130, 3);
		this.comboBox_2.Name = GClass107.smethod_3(128201);
		this.comboBox_2.Size = new Size(88, 32);
		this.comboBox_2.TabIndex = 19;
		this.comboBox_2.Tag = "5020";
		this.comboBox_2.SelectedIndexChanged += this.comboBox_2_SelectedIndexChanged;
		this.label_2.AutoSize = true;
		this.label_2.Dock = DockStyle.Fill;
		this.label_2.Font = new Font(GClass107.smethod_3(128218), 10.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_2.Location = new Point(224, 0);
		this.label_2.Margin = new Padding(3, 0, 0, 0);
		this.label_2.Name = GClass107.smethod_3(128264);
		this.label_2.Size = new Size(63, 38);
		this.label_2.TabIndex = 14;
		this.label_2.Tag = "5021";
		this.label_2.Text = GClass107.smethod_3(128306);
		this.label_2.TextAlign = ContentAlignment.MiddleLeft;
		this.button_15.Dock = DockStyle.Fill;
		this.button_15.FlatAppearance.BorderSize = 0;
		this.button_15.FlatStyle = FlatStyle.Flat;
		this.button_15.ImageKey = GClass107.smethod_3(128354);
		this.button_15.ImageList = this.imageList_0;
		this.button_15.Location = new Point(287, 0);
		this.button_15.Margin = new Padding(0);
		this.button_15.Name = GClass107.smethod_3(128371);
		this.button_15.Size = new Size(33, 38);
		this.button_15.TabIndex = 27;
		this.button_15.UseVisualStyleBackColor = true;
		this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_1.FlatStyle = FlatStyle.Flat;
		this.comboBox_1.Font = new Font(GClass107.smethod_3(128413), 10.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Items.AddRange(new object[]
		{
			GClass107.smethod_3(128429),
			GClass107.smethod_3(128439),
			GClass107.smethod_3(128475),
			GClass107.smethod_3(128509),
			GClass107.smethod_3(128521),
			GClass107.smethod_3(128557)
		});
		this.comboBox_1.Location = new Point(323, 3);
		this.comboBox_1.Name = GClass107.smethod_3(128602);
		this.comboBox_1.Size = new Size(105, 32);
		this.comboBox_1.TabIndex = 2;
		this.comboBox_1.Tag = "5021";
		this.comboBox_1.SelectedIndexChanged += this.comboBox_1_SelectedIndexChanged;
		this.label_0.AutoSize = true;
		this.label_0.Dock = DockStyle.Fill;
		this.label_0.Font = new Font(GClass107.smethod_3(128641), 10.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_0.ImageAlign = ContentAlignment.MiddleRight;
		this.label_0.ImageKey = GClass107.smethod_3(128668);
		this.label_0.Location = new Point(434, 0);
		this.label_0.Margin = new Padding(3, 0, 0, 0);
		this.label_0.Name = GClass107.smethod_3(128712);
		this.label_0.Size = new Size(72, 38);
		this.label_0.TabIndex = 7;
		this.label_0.Tag = "5022";
		this.label_0.Text = GClass107.smethod_3(128750);
		this.label_0.TextAlign = ContentAlignment.MiddleLeft;
		this.button_16.Dock = DockStyle.Fill;
		this.button_16.FlatAppearance.BorderSize = 0;
		this.button_16.FlatStyle = FlatStyle.Flat;
		this.button_16.ImageKey = GClass107.smethod_3(128788);
		this.button_16.ImageList = this.imageList_0;
		this.button_16.Location = new Point(506, 0);
		this.button_16.Margin = new Padding(0);
		this.button_16.Name = GClass107.smethod_3(128832);
		this.button_16.Size = new Size(33, 38);
		this.button_16.TabIndex = 28;
		this.button_16.UseVisualStyleBackColor = true;
		this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_0.FlatStyle = FlatStyle.Flat;
		this.comboBox_0.Font = new Font(GClass107.smethod_3(128847), 10.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Items.AddRange(new object[]
		{
			"150x",
			"100x",
			"50x",
			"20x",
			"10x",
			"5x",
			"2x",
			"1x",
			"0.5x",
			"0.25x",
			"0.1x",
			"0.01x"
		});
		this.comboBox_0.Location = new Point(3, 41);
		this.comboBox_0.Name = GClass107.smethod_3(128849);
		this.comboBox_0.Size = new Size(72, 32);
		this.comboBox_0.TabIndex = 3;
		this.comboBox_0.Tag = "5022";
		this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
		this.button_18.Dock = DockStyle.Fill;
		this.button_18.FlatAppearance.BorderSize = 0;
		this.button_18.FlatStyle = FlatStyle.Flat;
		this.button_18.ImageKey = GClass107.smethod_3(128878);
		this.button_18.ImageList = this.imageList_0;
		this.button_18.Location = new Point(83, 38);
		this.button_18.Margin = new Padding(5, 0, 0, 0);
		this.button_18.Name = GClass107.smethod_3(128901);
		this.button_18.Size = new Size(33, 38);
		this.button_18.TabIndex = 27;
		this.button_18.UseVisualStyleBackColor = true;
		this.label_15.AutoSize = true;
		this.label_15.Dock = DockStyle.Fill;
		this.label_15.Font = new Font(GClass107.smethod_3(128925), 10.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_15.Location = new Point(119, 38);
		this.label_15.Margin = new Padding(3, 0, 0, 0);
		this.label_15.Name = GClass107.smethod_3(128960);
		this.label_15.Size = new Size(58, 38);
		this.label_15.TabIndex = 26;
		this.label_15.Tag = "5030";
		this.label_15.Text = GClass107.smethod_3(128965);
		this.label_15.TextAlign = ContentAlignment.MiddleLeft;
		this.panel_7.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_7.BorderStyle = BorderStyle.FixedSingle;
		this.panel_7.Controls.Add(this.panel_16);
		this.panel_7.Controls.Add(this.panel_14);
		this.panel_7.Controls.Add(this.panel_15);
		this.panel_7.Controls.Add(this.panel_13);
		this.panel_7.Controls.Add(this.button_25);
		this.panel_7.Controls.Add(this.textBox_4);
		this.panel_7.Controls.Add(this.button_0);
		this.panel_7.Controls.Add(this.label_1);
		this.panel_7.Controls.Add(this.label_3);
		this.panel_7.Location = new Point(591, 320);
		this.panel_7.MinimumSize = new Size(200, 90);
		this.panel_7.Name = GClass107.smethod_3(129009);
		this.panel_7.Size = new Size(254, 90);
		this.panel_7.TabIndex = 27;
		this.panel_16.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.panel_16.BackColor = Color.Green;
		this.panel_16.Location = new Point(207, 24);
		this.panel_16.Name = GClass107.smethod_3(129024);
		this.panel_16.Size = new Size(10, 10);
		this.panel_16.TabIndex = 33;
		this.panel_14.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.panel_14.BackColor = Color.Green;
		this.panel_14.Location = new Point(217, 24);
		this.panel_14.Name = GClass107.smethod_3(129066);
		this.panel_14.Size = new Size(10, 10);
		this.panel_14.TabIndex = 32;
		this.panel_15.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.panel_15.BackColor = Color.Green;
		this.panel_15.Location = new Point(227, 24);
		this.panel_15.Name = GClass107.smethod_3(129081);
		this.panel_15.Size = new Size(10, 10);
		this.panel_15.TabIndex = 31;
		this.panel_13.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.panel_13.BackColor = Color.Green;
		this.panel_13.Location = new Point(237, 24);
		this.panel_13.Name = GClass107.smethod_3(129127);
		this.panel_13.Size = new Size(10, 10);
		this.panel_13.TabIndex = 30;
		this.button_25.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.button_25.Font = new Font(GClass107.smethod_3(129146), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_25.ImageKey = GClass107.smethod_3(129192);
		this.button_25.ImageList = this.imageList_0;
		this.button_25.Location = new Point(3, 10);
		this.button_25.Name = GClass107.smethod_3(129199);
		this.button_25.Size = new Size(86, 30);
		this.button_25.TabIndex = 29;
		this.button_25.Tag = "5009";
		this.button_25.Text = GClass107.smethod_3(129236);
		this.button_25.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_25.UseVisualStyleBackColor = false;
		this.button_25.Visible = false;
		this.button_25.Click += this.button_25_Click;
		this.textBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_4.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_4.ForeColor = Color.Navy;
		this.textBox_4.Location = new Point(6, 47);
		this.textBox_4.MaximumSize = new Size(0, 35);
		this.textBox_4.MinimumSize = new Size(0, 35);
		this.textBox_4.Name = GClass107.smethod_3(129248);
		this.textBox_4.Size = new Size(78, 35);
		this.textBox_4.TabIndex = 28;
		this.button_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.button_0.AutoSize = true;
		this.button_0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_0.Font = new Font(GClass107.smethod_3(129292), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_0.ImageKey = GClass107.smethod_3(129310);
		this.button_0.ImageList = this.imageList_0;
		this.button_0.Location = new Point(89, 40);
		this.button_0.MaximumSize = new Size(0, 46);
		this.button_0.MinimumSize = new Size(160, 46);
		this.button_0.Name = GClass107.smethod_3(129354);
		this.button_0.Size = new Size(160, 46);
		this.button_0.TabIndex = 0;
		this.button_0.Tag = "5005";
		this.button_0.Text = GClass107.smethod_3(129397);
		this.button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_0.UseVisualStyleBackColor = false;
		this.button_0.Click += this.button_0_Click;
		this.label_1.AutoSize = true;
		this.label_1.Font = new Font(GClass107.smethod_3(129437), 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_1.ForeColor = Color.Green;
		this.label_1.Location = new Point(3, 4);
		this.label_1.Name = GClass107.smethod_3(129455);
		this.label_1.Size = new Size(170, 29);
		this.label_1.TabIndex = 11;
		this.label_1.Text = GClass107.smethod_3(129503);
		this.label_1.Visible = false;
		this.label_3.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.label_3.AutoSize = true;
		this.label_3.Font = new Font(GClass107.smethod_3(129524), 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_3.ForeColor = Color.Green;
		this.label_3.Location = new Point(90, 10);
		this.label_3.Name = GClass107.smethod_3(129544);
		this.label_3.Size = new Size(65, 29);
		this.label_3.TabIndex = 15;
		this.label_3.Text = "0000";
		this.label_3.TextAlign = ContentAlignment.TopRight;
		this.panel_8.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.panel_8.BorderStyle = BorderStyle.FixedSingle;
		this.panel_8.Controls.Add(this.button_1);
		this.panel_8.Controls.Add(this.label_13);
		this.panel_8.Controls.Add(this.comboBox_3);
		this.panel_8.Controls.Add(this.button_12);
		this.panel_8.Location = new Point(252, 320);
		this.panel_8.Name = GClass107.smethod_3(129551);
		this.panel_8.Size = new Size(333, 90);
		this.panel_8.TabIndex = 26;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.button_1.Font = new Font(GClass107.smethod_3(129574), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_1.ImageKey = GClass107.smethod_3(129575);
		this.button_1.ImageList = this.imageList_0;
		this.button_1.Location = new Point(3, 40);
		this.button_1.MaximumSize = new Size(158, 46);
		this.button_1.MinimumSize = new Size(158, 46);
		this.button_1.Name = GClass107.smethod_3(129612);
		this.button_1.Size = new Size(158, 46);
		this.button_1.TabIndex = 5;
		this.button_1.Tag = "5007";
		this.button_1.Text = GClass107.smethod_3(129660);
		this.button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_1.UseVisualStyleBackColor = false;
		this.button_1.Click += this.button_1_Click;
		this.label_13.AutoSize = true;
		this.label_13.Font = new Font(GClass107.smethod_3(129705), 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_13.Location = new Point(3, 8);
		this.label_13.Name = GClass107.smethod_3(129742);
		this.label_13.Size = new Size(62, 29);
		this.label_13.TabIndex = 24;
		this.label_13.Tag = "5004";
		this.label_13.Text = GClass107.smethod_3(129745);
		this.comboBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBox_3.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_3.FlatStyle = FlatStyle.Flat;
		this.comboBox_3.Font = new Font(GClass107.smethod_3(129775), 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.comboBox_3.FormattingEnabled = true;
		this.comboBox_3.Location = new Point(88, 4);
		this.comboBox_3.MaximumSize = new Size(239, 0);
		this.comboBox_3.MinimumSize = new Size(239, 0);
		this.comboBox_3.Name = GClass107.smethod_3(129805);
		this.comboBox_3.Size = new Size(239, 37);
		this.comboBox_3.TabIndex = 22;
		this.comboBox_3.Tag = "5004";
		this.comboBox_3.SelectedIndexChanged += this.comboBox_3_SelectedIndexChanged;
		this.button_12.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.button_12.Font = new Font(GClass107.smethod_3(129843), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_12.ImageKey = GClass107.smethod_3(129867);
		this.button_12.ImageList = this.imageList_0;
		this.button_12.Location = new Point(167, 40);
		this.button_12.MaximumSize = new Size(160, 46);
		this.button_12.MinimumSize = new Size(160, 46);
		this.button_12.Name = GClass107.smethod_3(129886);
		this.button_12.Size = new Size(160, 46);
		this.button_12.TabIndex = 25;
		this.button_12.Tag = "5008";
		this.button_12.Text = GClass107.smethod_3(129900);
		this.button_12.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_12.UseVisualStyleBackColor = false;
		this.button_12.Click += this.button_12_Click;
		this.panel_6.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.panel_6.BackgroundImage = (Image)componentResourceManager.GetObject(GClass107.smethod_3(129912));
		this.panel_6.BackgroundImageLayout = ImageLayout.Center;
		this.panel_6.Location = new Point(4, 367);
		this.panel_6.Name = GClass107.smethod_3(129959);
		this.panel_6.Size = new Size(242, 44);
		this.panel_6.TabIndex = 23;
		this.gclass114_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.gclass114_0.ColumnCount = 1;
		this.gclass114_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		this.gclass114_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
		this.gclass114_0.Location = new Point(252, 3);
		this.gclass114_0.Name = GClass107.smethod_3(129961);
		this.gclass114_0.RowCount = 1;
		this.gclass114_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		this.gclass114_0.Size = new Size(593, 279);
		this.gclass114_0.TabIndex = 18;
		this.gclass114_0.Paint += this.gclass114_0_Paint;
		this.gclass114_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
		this.gclass114_1.AutoScroll = true;
		this.gclass114_1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
		this.gclass114_1.ColumnCount = 1;
		this.gclass114_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		this.gclass114_1.Location = new Point(7, 6);
		this.gclass114_1.Name = GClass107.smethod_3(129979);
		this.gclass114_1.RowCount = 1;
		this.gclass114_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 364f));
		this.gclass114_1.Size = new Size(239, 355);
		this.gclass114_1.TabIndex = 21;
		this.tabPage_5.BackColor = Color.White;
		this.tabPage_5.Controls.Add(this.flowLayoutPanel_4);
		this.tabPage_5.Controls.Add(this.splitContainer_3);
		this.tabPage_5.Controls.Add(this.panel_9);
		this.tabPage_5.ImageKey = GClass107.smethod_3(130000);
		this.tabPage_5.Location = new Point(4, 45);
		this.tabPage_5.Name = GClass107.smethod_3(130038);
		this.tabPage_5.Size = new Size(850, 413);
		this.tabPage_5.TabIndex = 6;
		this.tabPage_5.Tag = "";
		this.tabPage_5.Text = GClass107.smethod_3(130080);
		this.tabPage_5.UseVisualStyleBackColor = true;
		this.flowLayoutPanel_4.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.flowLayoutPanel_4.Controls.Add(this.button_2);
		this.flowLayoutPanel_4.Controls.Add(this.button_3);
		this.flowLayoutPanel_4.Controls.Add(this.button_28);
		this.flowLayoutPanel_4.FlowDirection = FlowDirection.RightToLeft;
		this.flowLayoutPanel_4.Location = new Point(252, 365);
		this.flowLayoutPanel_4.Name = GClass107.smethod_3(130120);
		this.flowLayoutPanel_4.Size = new Size(592, 46);
		this.flowLayoutPanel_4.TabIndex = 31;
		this.flowLayoutPanel_4.WrapContents = false;
		this.button_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_2.AutoSize = true;
		this.button_2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_2.Font = new Font(GClass107.smethod_3(130159), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_2.ImageKey = GClass107.smethod_3(130161);
		this.button_2.ImageList = this.imageList_0;
		this.button_2.Location = new Point(422, 0);
		this.button_2.Margin = new Padding(0);
		this.button_2.MaximumSize = new Size(0, 46);
		this.button_2.MinimumSize = new Size(0, 46);
		this.button_2.Name = GClass107.smethod_3(130177);
		this.button_2.Size = new Size(170, 46);
		this.button_2.TabIndex = 3;
		this.button_2.Tag = "6002";
		this.button_2.Text = GClass107.smethod_3(130226);
		this.button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_2.UseVisualStyleBackColor = false;
		this.button_2.Click += this.button_2_Click;
		this.button_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_3.AutoSize = true;
		this.button_3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_3.Font = new Font(GClass107.smethod_3(130247), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_3.ImageKey = GClass107.smethod_3(130291);
		this.button_3.ImageList = this.imageList_0;
		this.button_3.Location = new Point(252, 0);
		this.button_3.Margin = new Padding(0, 0, 10, 0);
		this.button_3.MaximumSize = new Size(0, 46);
		this.button_3.MinimumSize = new Size(0, 46);
		this.button_3.Name = GClass107.smethod_3(130293);
		this.button_3.Size = new Size(160, 46);
		this.button_3.TabIndex = 2;
		this.button_3.Tag = "6003";
		this.button_3.Text = GClass107.smethod_3(130317);
		this.button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_3.UseVisualStyleBackColor = false;
		this.button_3.Click += this.button_3_Click;
		this.button_28.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_28.AutoSize = true;
		this.button_28.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_28.Font = new Font(GClass107.smethod_3(130351), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_28.ForeColor = Color.Red;
		this.button_28.ImageKey = GClass107.smethod_3(130381);
		this.button_28.ImageList = this.imageList_0;
		this.button_28.Location = new Point(30, 0);
		this.button_28.Margin = new Padding(0, 0, 10, 0);
		this.button_28.MaximumSize = new Size(0, 46);
		this.button_28.MinimumSize = new Size(0, 46);
		this.button_28.Name = GClass107.smethod_3(130383);
		this.button_28.Size = new Size(212, 46);
		this.button_28.TabIndex = 10;
		this.button_28.Tag = "2002";
		this.button_28.Text = GClass107.smethod_3(130387);
		this.button_28.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_28.UseVisualStyleBackColor = false;
		this.button_28.Click += this.button_29_Click;
		this.splitContainer_3.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.splitContainer_3.BackColor = Color.Navy;
		this.splitContainer_3.Location = new Point(6, 6);
		this.splitContainer_3.Name = GClass107.smethod_3(130415);
		this.splitContainer_3.Panel1.BackColor = Color.White;
		this.splitContainer_3.Panel1.Controls.Add(this.dataGridView_2);
		this.splitContainer_3.Panel2.BackColor = Color.White;
		this.splitContainer_3.Panel2.Controls.Add(this.dataGridView_9);
		this.splitContainer_3.Panel2.Controls.Add(this.textBox_2);
		this.splitContainer_3.Size = new Size(838, 353);
		this.splitContainer_3.SplitterDistance = 494;
		this.splitContainer_3.TabIndex = 20;
		this.dataGridView_2.AllowUserToAddRows = false;
		this.dataGridView_2.AllowUserToDeleteRows = false;
		this.dataGridView_2.AllowUserToResizeRows = false;
		this.dataGridView_2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		this.dataGridView_2.BackgroundColor = Color.White;
		this.dataGridView_2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_2.ColumnHeadersVisible = false;
		this.dataGridView_2.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewCheckBoxColumn_2,
			this.dataGridViewTextBoxColumn_32,
			this.dataGridViewTextBoxColumn_33
		});
		this.dataGridView_2.Location = new Point(0, 0);
		this.dataGridView_2.MultiSelect = false;
		this.dataGridView_2.Name = GClass107.smethod_3(130447);
		this.dataGridView_2.ReadOnly = true;
		this.dataGridView_2.RowHeadersVisible = false;
		this.dataGridView_2.RowTemplate.DefaultCellStyle.BackColor = Color.White;
		this.dataGridView_2.RowTemplate.DefaultCellStyle.Font = new Font(GClass107.smethod_3(130490), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.dataGridView_2.RowTemplate.DefaultCellStyle.ForeColor = Color.Navy;
		this.dataGridView_2.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 248, 168);
		this.dataGridView_2.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Navy;
		this.dataGridView_2.RowTemplate.Height = 24;
		this.dataGridView_2.ScrollBars = ScrollBars.Vertical;
		this.dataGridView_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_2.ShowEditingIcon = false;
		this.dataGridView_2.Size = new Size(491, 353);
		this.dataGridView_2.StandardTab = true;
		this.dataGridView_2.TabIndex = 0;
		this.dataGridView_2.SelectionChanged += this.dataGridView_2_SelectionChanged;
		this.dataGridViewCheckBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.dataGridViewCheckBoxColumn_2.DataPropertyName = GClass107.smethod_3(130517);
		this.dataGridViewCheckBoxColumn_2.HeaderText = GClass107.smethod_3(130560);
		this.dataGridViewCheckBoxColumn_2.Name = GClass107.smethod_3(130580);
		this.dataGridViewCheckBoxColumn_2.ReadOnly = true;
		this.dataGridViewCheckBoxColumn_2.Resizable = DataGridViewTriState.True;
		this.dataGridViewCheckBoxColumn_2.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewCheckBoxColumn_2.Visible = false;
		this.dataGridViewTextBoxColumn_32.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_32.DataPropertyName = GClass107.smethod_3(130589);
		this.dataGridViewTextBoxColumn_32.FillWeight = 70f;
		this.dataGridViewTextBoxColumn_32.HeaderText = GClass107.smethod_3(130606);
		this.dataGridViewTextBoxColumn_32.Name = GClass107.smethod_3(130623);
		this.dataGridViewTextBoxColumn_32.ReadOnly = true;
		this.dataGridViewTextBoxColumn_32.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_33.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_33.DataPropertyName = GClass107.smethod_3(130649);
		this.dataGridViewTextBoxColumn_33.FillWeight = 30f;
		this.dataGridViewTextBoxColumn_33.HeaderText = GClass107.smethod_3(130698);
		this.dataGridViewTextBoxColumn_33.Name = GClass107.smethod_3(130736);
		this.dataGridViewTextBoxColumn_33.ReadOnly = true;
		this.dataGridViewTextBoxColumn_33.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_33.Visible = false;
		this.dataGridView_9.AllowUserToAddRows = false;
		this.dataGridView_9.AllowUserToDeleteRows = false;
		this.dataGridView_9.AllowUserToResizeRows = false;
		this.dataGridView_9.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_9.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
		this.dataGridView_9.BackgroundColor = Color.White;
		this.dataGridView_9.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_9.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_9.ColumnHeadersVisible = false;
		this.dataGridView_9.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewCheckBoxColumn_0,
			this.dataGridViewTextBoxColumn_11,
			this.dataGridViewTextBoxColumn_12
		});
		this.dataGridView_9.Location = new Point(3, 217);
		this.dataGridView_9.MultiSelect = false;
		this.dataGridView_9.Name = GClass107.smethod_3(130762);
		this.dataGridView_9.ReadOnly = true;
		this.dataGridView_9.RowHeadersVisible = false;
		this.dataGridView_9.RowTemplate.DefaultCellStyle.BackColor = Color.White;
		this.dataGridView_9.RowTemplate.DefaultCellStyle.Font = new Font(GClass107.smethod_3(130766), 10.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.dataGridView_9.RowTemplate.DefaultCellStyle.ForeColor = Color.Navy;
		this.dataGridView_9.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 248, 168);
		this.dataGridView_9.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Navy;
		this.dataGridView_9.RowTemplate.Height = 24;
		this.dataGridView_9.ScrollBars = ScrollBars.Vertical;
		this.dataGridView_9.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_9.ShowEditingIcon = false;
		this.dataGridView_9.Size = new Size(337, 136);
		this.dataGridView_9.StandardTab = true;
		this.dataGridView_9.TabIndex = 2;
		this.dataGridView_9.Tag = "3";
		this.dataGridViewCheckBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		this.dataGridViewCheckBoxColumn_0.DataPropertyName = GClass107.smethod_3(130798);
		this.dataGridViewCheckBoxColumn_0.HeaderText = GClass107.smethod_3(130843);
		this.dataGridViewCheckBoxColumn_0.MinimumWidth = 40;
		this.dataGridViewCheckBoxColumn_0.Name = GClass107.smethod_3(130882);
		this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
		this.dataGridViewCheckBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewCheckBoxColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewCheckBoxColumn_0.Visible = false;
		this.dataGridViewCheckBoxColumn_0.Width = 40;
		this.dataGridViewTextBoxColumn_11.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_11.DataPropertyName = GClass107.smethod_3(130883);
		this.dataGridViewTextBoxColumn_11.FillWeight = 70f;
		this.dataGridViewTextBoxColumn_11.HeaderText = GClass107.smethod_3(130911);
		this.dataGridViewTextBoxColumn_11.Name = GClass107.smethod_3(130943);
		this.dataGridViewTextBoxColumn_11.ReadOnly = true;
		this.dataGridViewTextBoxColumn_12.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_12.DataPropertyName = GClass107.smethod_3(130971);
		this.dataGridViewTextBoxColumn_12.FillWeight = 30f;
		this.dataGridViewTextBoxColumn_12.HeaderText = GClass107.smethod_3(130988);
		this.dataGridViewTextBoxColumn_12.Name = GClass107.smethod_3(131021);
		this.dataGridViewTextBoxColumn_12.ReadOnly = true;
		this.dataGridViewTextBoxColumn_12.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_2.BackColor = Color.FromArgb(248, 248, 168);
		this.textBox_2.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_2.Font = new Font(GClass107.smethod_3(131070), 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.textBox_2.ForeColor = Color.DarkSlateBlue;
		this.textBox_2.Location = new Point(3, 0);
		this.textBox_2.Multiline = true;
		this.textBox_2.Name = GClass107.smethod_3(131091);
		this.textBox_2.ReadOnly = true;
		this.textBox_2.ScrollBars = ScrollBars.Vertical;
		this.textBox_2.Size = new Size(334, 211);
		this.textBox_2.TabIndex = 1;
		this.panel_9.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.panel_9.BackgroundImage = (Image)componentResourceManager.GetObject(GClass107.smethod_3(131139));
		this.panel_9.BackgroundImageLayout = ImageLayout.Center;
		this.panel_9.Location = new Point(4, 367);
		this.panel_9.Name = GClass107.smethod_3(131163);
		this.panel_9.Size = new Size(242, 44);
		this.panel_9.TabIndex = 19;
		this.tabPage_6.BackColor = Color.White;
		this.tabPage_6.Controls.Add(this.flowLayoutPanel_5);
		this.tabPage_6.Controls.Add(this.splitContainer_4);
		this.tabPage_6.Controls.Add(this.panel_10);
		this.tabPage_6.ImageKey = GClass107.smethod_3(131205);
		this.tabPage_6.Location = new Point(4, 45);
		this.tabPage_6.Name = GClass107.smethod_3(131207);
		this.tabPage_6.Size = new Size(850, 413);
		this.tabPage_6.TabIndex = 7;
		this.tabPage_6.Tag = "";
		this.tabPage_6.Text = GClass107.smethod_3(131213);
		this.tabPage_6.UseVisualStyleBackColor = true;
		this.flowLayoutPanel_5.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.flowLayoutPanel_5.Controls.Add(this.button_13);
		this.flowLayoutPanel_5.Controls.Add(this.button_29);
		this.flowLayoutPanel_5.FlowDirection = FlowDirection.RightToLeft;
		this.flowLayoutPanel_5.Location = new Point(252, 365);
		this.flowLayoutPanel_5.Name = GClass107.smethod_3(131259);
		this.flowLayoutPanel_5.Size = new Size(592, 46);
		this.flowLayoutPanel_5.TabIndex = 32;
		this.flowLayoutPanel_5.WrapContents = false;
		this.button_13.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_13.AutoSize = true;
		this.button_13.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_13.Font = new Font(GClass107.smethod_3(131267), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_13.ImageKey = GClass107.smethod_3(131289);
		this.button_13.ImageList = this.imageList_0;
		this.button_13.Location = new Point(422, 0);
		this.button_13.Margin = new Padding(0);
		this.button_13.MaximumSize = new Size(0, 46);
		this.button_13.MinimumSize = new Size(0, 46);
		this.button_13.Name = GClass107.smethod_3(131305);
		this.button_13.Size = new Size(170, 46);
		this.button_13.TabIndex = 22;
		this.button_13.Tag = "7002";
		this.button_13.Text = GClass107.smethod_3(131341);
		this.button_13.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_13.UseVisualStyleBackColor = false;
		this.button_13.Click += this.button_13_Click;
		this.button_29.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_29.AutoSize = true;
		this.button_29.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.button_29.Font = new Font(GClass107.smethod_3(131370), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_29.ForeColor = Color.Red;
		this.button_29.ImageKey = GClass107.smethod_3(131375);
		this.button_29.ImageList = this.imageList_0;
		this.button_29.Location = new Point(200, 0);
		this.button_29.Margin = new Padding(0, 0, 10, 0);
		this.button_29.MaximumSize = new Size(0, 46);
		this.button_29.MinimumSize = new Size(0, 46);
		this.button_29.Name = GClass107.smethod_3(131399);
		this.button_29.Size = new Size(212, 46);
		this.button_29.TabIndex = 10;
		this.button_29.Tag = "2002";
		this.button_29.Text = GClass107.smethod_3(131423);
		this.button_29.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_29.UseVisualStyleBackColor = false;
		this.button_29.Click += this.button_29_Click;
		this.splitContainer_4.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.splitContainer_4.BackColor = Color.Navy;
		this.splitContainer_4.Location = new Point(6, 6);
		this.splitContainer_4.Name = GClass107.smethod_3(131424);
		this.splitContainer_4.Panel1.BackColor = Color.White;
		this.splitContainer_4.Panel1.Controls.Add(this.dataGridView_8);
		this.splitContainer_4.Panel2.BackColor = Color.White;
		this.splitContainer_4.Panel2.Controls.Add(this.textBox_5);
		this.splitContainer_4.Size = new Size(838, 353);
		this.splitContainer_4.SplitterDistance = 437;
		this.splitContainer_4.TabIndex = 21;
		this.dataGridView_8.AllowUserToAddRows = false;
		this.dataGridView_8.AllowUserToDeleteRows = false;
		this.dataGridView_8.AllowUserToResizeRows = false;
		this.dataGridView_8.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_8.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		this.dataGridView_8.BackgroundColor = Color.White;
		this.dataGridView_8.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_8.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_8.ColumnHeadersVisible = false;
		this.dataGridView_8.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewCheckBoxColumn_3,
			this.dataGridViewTextBoxColumn_34,
			this.dataGridViewTextBoxColumn_35
		});
		this.dataGridView_8.Location = new Point(0, 0);
		this.dataGridView_8.MultiSelect = false;
		this.dataGridView_8.Name = GClass107.smethod_3(131453);
		this.dataGridView_8.ReadOnly = true;
		this.dataGridView_8.RowHeadersVisible = false;
		this.dataGridView_8.RowTemplate.DefaultCellStyle.BackColor = Color.White;
		this.dataGridView_8.RowTemplate.DefaultCellStyle.Font = new Font(GClass107.smethod_3(131479), 16.2f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.dataGridView_8.RowTemplate.DefaultCellStyle.ForeColor = Color.Navy;
		this.dataGridView_8.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 248, 168);
		this.dataGridView_8.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Navy;
		this.dataGridView_8.RowTemplate.Height = 24;
		this.dataGridView_8.ScrollBars = ScrollBars.Vertical;
		this.dataGridView_8.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_8.ShowEditingIcon = false;
		this.dataGridView_8.Size = new Size(434, 353);
		this.dataGridView_8.StandardTab = true;
		this.dataGridView_8.TabIndex = 0;
		this.dataGridView_8.RowPrePaint += this.dataGridView_8_RowPrePaint;
		this.dataGridView_8.SelectionChanged += this.dataGridView_8_SelectionChanged;
		this.dataGridViewCheckBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		this.dataGridViewCheckBoxColumn_3.DataPropertyName = GClass107.smethod_3(131503);
		this.dataGridViewCheckBoxColumn_3.HeaderText = GClass107.smethod_3(131517);
		this.dataGridViewCheckBoxColumn_3.Name = GClass107.smethod_3(131520);
		this.dataGridViewCheckBoxColumn_3.ReadOnly = true;
		this.dataGridViewCheckBoxColumn_3.Resizable = DataGridViewTriState.True;
		this.dataGridViewCheckBoxColumn_3.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewCheckBoxColumn_3.Visible = false;
		this.dataGridViewTextBoxColumn_34.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_34.DataPropertyName = GClass107.smethod_3(131548);
		this.dataGridViewTextBoxColumn_34.FillWeight = 70f;
		this.dataGridViewTextBoxColumn_34.HeaderText = GClass107.smethod_3(131572);
		this.dataGridViewTextBoxColumn_34.Name = GClass107.smethod_3(131590);
		this.dataGridViewTextBoxColumn_34.ReadOnly = true;
		this.dataGridViewTextBoxColumn_34.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_35.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_35.DataPropertyName = GClass107.smethod_3(131602);
		this.dataGridViewTextBoxColumn_35.FillWeight = 30f;
		this.dataGridViewTextBoxColumn_35.HeaderText = GClass107.smethod_3(131608);
		this.dataGridViewTextBoxColumn_35.Name = GClass107.smethod_3(131643);
		this.dataGridViewTextBoxColumn_35.ReadOnly = true;
		this.dataGridViewTextBoxColumn_35.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_35.Visible = false;
		this.textBox_5.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_5.BackColor = Color.FromArgb(248, 248, 168);
		this.textBox_5.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_5.Font = new Font(GClass107.smethod_3(131676), 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.textBox_5.ForeColor = Color.DarkSlateBlue;
		this.textBox_5.Location = new Point(3, 0);
		this.textBox_5.Multiline = true;
		this.textBox_5.Name = GClass107.smethod_3(131679);
		this.textBox_5.ReadOnly = true;
		this.textBox_5.ScrollBars = ScrollBars.Vertical;
		this.textBox_5.Size = new Size(394, 353);
		this.textBox_5.TabIndex = 1;
		this.panel_10.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.panel_10.BackgroundImage = (Image)componentResourceManager.GetObject(GClass107.smethod_3(131698));
		this.panel_10.BackgroundImageLayout = ImageLayout.Center;
		this.panel_10.Location = new Point(4, 367);
		this.panel_10.Name = GClass107.smethod_3(131723);
		this.panel_10.Size = new Size(242, 44);
		this.panel_10.TabIndex = 20;
		this.tabPage_1.BackColor = Color.White;
		this.tabPage_1.Controls.Add(this.textBox_0);
		this.tabPage_1.ImageKey = GClass107.smethod_3(131734);
		this.tabPage_1.Location = new Point(4, 45);
		this.tabPage_1.Name = GClass107.smethod_3(131783);
		this.tabPage_1.Padding = new Padding(3);
		this.tabPage_1.Size = new Size(850, 413);
		this.tabPage_1.TabIndex = 1;
		this.tabPage_1.Tag = "";
		this.tabPage_1.Text = "Log";
		this.tabPage_1.UseVisualStyleBackColor = true;
		this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.Location = new Point(6, 6);
		this.textBox_0.Multiline = true;
		this.textBox_0.Name = GClass107.smethod_3(131827);
		this.textBox_0.ScrollBars = ScrollBars.Vertical;
		this.textBox_0.Size = new Size(838, 401);
		this.textBox_0.TabIndex = 0;
		this.menuStrip_0.Enabled = false;
		this.menuStrip_0.ImageScalingSize = new Size(24, 24);
		this.menuStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripMenuItem_0
		});
		this.menuStrip_0.Location = new Point(0, 0);
		this.menuStrip_0.Name = GClass107.smethod_3(131834);
		this.menuStrip_0.Size = new Size(826, 28);
		this.menuStrip_0.TabIndex = 1;
		this.menuStrip_0.Text = GClass107.smethod_3(131879);
		this.menuStrip_0.Visible = false;
		this.toolStripMenuItem_0.DropDownItems.AddRange(new ToolStripItem[]
		{
			this.toolStripMenuItem_1
		});
		this.toolStripMenuItem_0.Name = GClass107.smethod_3(131925);
		this.toolStripMenuItem_0.Size = new Size(50, 24);
		this.toolStripMenuItem_0.Text = GClass107.smethod_3(131942);
		this.toolStripMenuItem_1.Name = GClass107.smethod_3(131957);
		this.toolStripMenuItem_1.Size = new Size(123, 30);
		this.toolStripMenuItem_1.Text = GClass107.smethod_3(131968);
		this.timer_0.Interval = 300;
		this.timer_0.Tick += this.timer_0_Tick;
		this.timer_1.Interval = 1000;
		this.timer_1.Tick += this.timer_1_Tick;
		this.saveFileDialog_0.DefaultExt = GClass107.smethod_3(131997);
		this.saveFileDialog_0.Filter = GClass107.smethod_3(132038);
		this.saveFileDialog_0.RestoreDirectory = true;
		this.saveFileDialog_0.Title = GClass107.smethod_3(132054);
		this.timer_2.Tick += this.timer_2_Tick;
		this.label_14.AutoSize = true;
		this.label_14.Font = new Font(GClass107.smethod_3(132065), 24f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_14.ForeColor = Color.Navy;
		this.label_14.Location = new Point(7, 6);
		this.label_14.Name = GClass107.smethod_3(132082);
		this.label_14.Size = new Size(417, 56);
		this.label_14.TabIndex = 3;
		this.label_14.Text = GClass107.smethod_3(132085);
		this.label_14.TextAlign = ContentAlignment.MiddleCenter;
		this.label_14.VisibleChanged += this.label_14_VisibleChanged;
		this.openFileDialog_0.DefaultExt = GClass107.smethod_3(132126);
		this.openFileDialog_0.Filter = GClass107.smethod_3(132141);
		this.openFileDialog_0.RestoreDirectory = true;
		this.openFileDialog_0.Title = GClass107.smethod_3(132168);
		this.toolTip_0.AutoPopDelay = 20000;
		this.toolTip_0.BackColor = Color.White;
		this.toolTip_0.ForeColor = Color.Navy;
		this.toolTip_0.InitialDelay = 500;
		this.toolTip_0.IsBalloon = true;
		this.toolTip_0.ReshowDelay = 100;
		this.panel_11.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_11.Controls.Add(this.label_14);
		this.panel_11.Location = new Point(0, 0);
		this.panel_11.Name = GClass107.smethod_3(132195);
		this.panel_11.Size = new Size(40, 33);
		this.panel_11.TabIndex = 4;
		this.panel_11.Visible = false;
		this.label_18.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.label_18.AutoSize = true;
		this.label_18.Font = new Font(GClass107.smethod_3(132199), 7.488f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_18.ForeColor = Color.Red;
		this.label_18.Location = new Point(660, 3);
		this.label_18.MaximumSize = new Size(200, 0);
		this.label_18.MinimumSize = new Size(200, 0);
		this.label_18.Name = GClass107.smethod_3(132202);
		this.label_18.Size = new Size(200, 36);
		this.label_18.TabIndex = 5;
		this.label_18.Tag = "1060";
		this.label_18.Text = GClass107.smethod_3(132245);
		this.label_18.TextAlign = ContentAlignment.TopRight;
		this.label_18.Visible = false;
		this.label_19.AutoSize = true;
		this.label_19.Location = new Point(3, 3);
		this.label_19.Margin = new Padding(3);
		this.label_19.Name = GClass107.smethod_3(132265);
		this.label_19.Size = new Size(107, 20);
		this.label_19.ForeColor = Color.DarkBlue;
		this.label_19.TabIndex = 6;
		this.label_19.Text = GClass107.smethod_3(132311);
		this.label_20.AutoSize = true;
		this.label_20.Location = new Point(3, 3);
		this.label_20.Margin = new Padding(3);
		this.label_20.Name = GClass107.smethod_3(132354);
		this.label_20.Size = new Size(107, 20);
		this.label_20.TabIndex = 6;
		this.label_20.Text = GClass107.smethod_3(132379);
		this.panel_17.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_17.BackColor = SystemColors.ControlLight;
		this.panel_17.Controls.Add(this.label_18);
		this.panel_17.Controls.Add(this.flowLayoutPanel_6);
		this.panel_17.Location = new Point(0, 480);
		this.panel_17.Name = GClass107.smethod_3(132385);
		this.panel_17.Size = new Size(882, 24);
		this.panel_17.TabIndex = 7;
		this.flowLayoutPanel_6.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.flowLayoutPanel_6.Controls.Add(this.label_19);
		this.flowLayoutPanel_6.Controls.Add(this.label_20);
		this.flowLayoutPanel_6.Controls.Add(this.label_21);
		this.flowLayoutPanel_6.Location = new Point(19, 0);
		this.flowLayoutPanel_6.Margin = new Padding(0);
		this.flowLayoutPanel_6.Name = GClass107.smethod_3(132416);
		this.flowLayoutPanel_6.Size = new Size(841, 24);
		this.flowLayoutPanel_6.TabIndex = 7;
		this.flowLayoutPanel_6.WrapContents = false;
		this.label_21.AutoSize = true;
		this.label_21.Font = new Font(GClass107.smethod_3(132461), 7.488f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.label_21.ForeColor = Color.Red;
		this.label_21.Location = new Point(123, 3);
		this.label_21.Margin = new Padding(10, 3, 3, 3);
		this.label_21.Name = GClass107.smethod_3(132482);
		this.label_21.Size = new Size(436, 18);
		this.label_21.TabIndex = 9;
		this.label_21.Tag = "2003";
		this.label_21.Text = GClass107.smethod_3(132496);
		base.AutoScaleMode = AutoScaleMode.None;
		this.BackColor = Color.White;
		base.ClientSize = new Size(882, 504);
		base.Controls.Add(this.panel_17);
		base.Controls.Add(this.panel_11);
		base.Controls.Add(this.tabControl_0);
		base.Controls.Add(this.menuStrip_0);
		base.Icon = (Icon)componentResourceManager.GetObject(GClass107.smethod_3(132502));
		base.MainMenuStrip = this.menuStrip_0;
		this.MinimumSize = new Size(800, 500);
		base.Name = GClass107.smethod_3(132505);
		this.Text = GClass107.smethod_3(132545);
		base.WindowState = FormWindowState.Maximized;
		base.FormClosing += this.GForm8_FormClosing;
		base.Shown += this.GForm8_Shown;
		base.KeyUp += this.GForm8_KeyUp;
		this.tabControl_0.ResumeLayout(false);
		this.tabPage_7.ResumeLayout(false);
		this.splitContainer_0.Panel1.ResumeLayout(false);
		this.splitContainer_0.Panel1.PerformLayout();
		this.splitContainer_0.Panel2.ResumeLayout(false);
		this.splitContainer_0.Panel2.PerformLayout();
		this.splitContainer_0.ResumeLayout(false);
		((ISupportInitialize)this.dataGridView_6).EndInit();
		((ISupportInitialize)this.dataGridView_5).EndInit();
		((ISupportInitialize)this.dataGridView_4).EndInit();
		((ISupportInitialize)this.dataGridView_7).EndInit();
		this.flowLayoutPanel_1.ResumeLayout(false);
		this.flowLayoutPanel_1.PerformLayout();
		this.panel_1.ResumeLayout(false);
		this.tabPage_0.ResumeLayout(false);
		this.tabPage_0.PerformLayout();
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		this.tabPage_2.ResumeLayout(false);
		this.flowLayoutPanel_2.ResumeLayout(false);
		this.flowLayoutPanel_2.PerformLayout();
		this.splitContainer_1.Panel1.ResumeLayout(false);
		this.splitContainer_1.Panel2.ResumeLayout(false);
		this.splitContainer_1.Panel2.PerformLayout();
		this.splitContainer_1.ResumeLayout(false);
		((ISupportInitialize)this.dataGridView_3).EndInit();
		this.tabPage_3.ResumeLayout(false);
		this.flowLayoutPanel_3.ResumeLayout(false);
		this.flowLayoutPanel_3.PerformLayout();
		this.splitContainer_2.Panel1.ResumeLayout(false);
		this.splitContainer_2.Panel2.ResumeLayout(false);
		this.splitContainer_2.Panel2.PerformLayout();
		this.splitContainer_2.ResumeLayout(false);
		((ISupportInitialize)this.dataGridView_1).EndInit();
		this.tabPage_4.ResumeLayout(false);
		((ISupportInitialize)this.dataGridView_10).EndInit();
		this.flowLayoutPanel_0.ResumeLayout(false);
		this.flowLayoutPanel_0.PerformLayout();
		this.panel_7.ResumeLayout(false);
		this.panel_7.PerformLayout();
		this.panel_8.ResumeLayout(false);
		this.panel_8.PerformLayout();
		this.tabPage_5.ResumeLayout(false);
		this.flowLayoutPanel_4.ResumeLayout(false);
		this.flowLayoutPanel_4.PerformLayout();
		this.splitContainer_3.Panel1.ResumeLayout(false);
		this.splitContainer_3.Panel2.ResumeLayout(false);
		this.splitContainer_3.Panel2.PerformLayout();
		this.splitContainer_3.ResumeLayout(false);
		((ISupportInitialize)this.dataGridView_2).EndInit();
		((ISupportInitialize)this.dataGridView_9).EndInit();
		this.tabPage_6.ResumeLayout(false);
		this.flowLayoutPanel_5.ResumeLayout(false);
		this.flowLayoutPanel_5.PerformLayout();
		this.splitContainer_4.Panel1.ResumeLayout(false);
		this.splitContainer_4.Panel2.ResumeLayout(false);
		this.splitContainer_4.Panel2.PerformLayout();
		this.splitContainer_4.ResumeLayout(false);
		((ISupportInitialize)this.dataGridView_8).EndInit();
		this.tabPage_1.ResumeLayout(false);
		this.tabPage_1.PerformLayout();
		this.menuStrip_0.ResumeLayout(false);
		this.menuStrip_0.PerformLayout();
		this.panel_11.ResumeLayout(false);
		this.panel_11.PerformLayout();
		this.panel_17.ResumeLayout(false);
		this.panel_17.PerformLayout();
		this.flowLayoutPanel_6.ResumeLayout(false);
		this.flowLayoutPanel_6.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000378 RID: 888
	private List<GClass104> list_0 = new List<GClass104>();

	// Token: 0x04000379 RID: 889
	private List<GClass104> list_1 = new List<GClass104>();

	// Token: 0x0400037A RID: 890
	private List<GClass104> list_2 = new List<GClass104>();

	// Token: 0x0400037B RID: 891
	private List<GClass104> list_3 = new List<GClass104>();

	// Token: 0x0400037C RID: 892
	private List<GClass102> list_4 = new List<GClass102>();

	// Token: 0x0400037D RID: 893
	private List<GClass104> list_5 = new List<GClass104>();

	// Token: 0x0400037E RID: 894
	private List<string> list_6 = new List<string>();

	// Token: 0x0400037F RID: 895
	private List<SimpleValueData> list_7 = new List<SimpleValueData>();

	// Token: 0x04000380 RID: 896
	private bool bool_0;

	// Token: 0x04000381 RID: 897
	private GClass11 gclass11_0;

	// Token: 0x04000382 RID: 898
	private GClass99 gclass99_0;

	// Token: 0x04000383 RID: 899
	private GForm9 gform9_0;

	// Token: 0x04000384 RID: 900
	private GForm10 gform10_0;

	// Token: 0x04000385 RID: 901
	private GForm11 gform11_0;

	// Token: 0x04000386 RID: 902
	private List<GClass102> list_8;

	// Token: 0x04000387 RID: 903
	private string string_0 = "";

	// Token: 0x04000388 RID: 904
	private string string_1 = "";

	// Token: 0x04000389 RID: 905
	private string string_2 = GClass107.smethod_3(112316);

	// Token: 0x0400038A RID: 906
	private string string_3 = GClass107.smethod_3(112326);

	// Token: 0x0400038B RID: 907
	private string string_4 = GClass107.smethod_3(112352);

	// Token: 0x0400038C RID: 908
	private string string_5 = GClass107.smethod_3(112392);

	// Token: 0x0400038D RID: 909
	private string string_6 = GClass107.smethod_3(112409);

	// Token: 0x0400038E RID: 910
	private string string_7 = GClass107.smethod_3(112446);

	// Token: 0x0400038F RID: 911
	private string string_8 = GClass107.smethod_3(112472);

	// Token: 0x04000390 RID: 912
	private string string_9 = "1";

	// Token: 0x04000391 RID: 913
	private string string_10 = "";

	// Token: 0x04000392 RID: 914
	private string string_11 = "";

	// Token: 0x04000393 RID: 915
	private int int_0;

	// Token: 0x04000394 RID: 916
	private bool bool_1;

	// Token: 0x04000395 RID: 917
	private bool bool_2;

	// Token: 0x04000396 RID: 918
	private string string_12 = "";

	// Token: 0x04000397 RID: 919
	private bool bool_3;

	// Token: 0x04000398 RID: 920
	private int int_1;

	// Token: 0x04000399 RID: 921
	private string string_13 = "";

	// Token: 0x0400039A RID: 922
	private string string_14 = ": ";

	// Token: 0x0400039B RID: 923
	private string string_15 = " ";

	// Token: 0x0400039C RID: 924
	private string string_16 = "";

	// Token: 0x0400039D RID: 925
	private string string_17 = "4011";

	// Token: 0x0400039E RID: 926
	private int[] int_2 = new int[]
	{
		0,
		1,
		2,
		3,
		4,
		5,
		6,
		7,
		8,
		9
	};

	// Token: 0x0400039F RID: 927
	private string string_18 = GClass107.smethod_3(110530);

	// Token: 0x040003A0 RID: 928
	private string string_19 = ".";

	// Token: 0x040003A2 RID: 930
	private TabControl tabControl_0;

	// Token: 0x040003A3 RID: 931
	private TabPage tabPage_0;

	// Token: 0x040003A4 RID: 932
	private MenuStrip menuStrip_0;

	// Token: 0x040003A5 RID: 933
	private ToolStripMenuItem toolStripMenuItem_0;

	// Token: 0x040003A6 RID: 934
	private ToolStripMenuItem toolStripMenuItem_1;

	// Token: 0x040003A7 RID: 935
	private DataGridView dataGridView_0;

	// Token: 0x040003A8 RID: 936
	private TabPage tabPage_1;

	// Token: 0x040003A9 RID: 937
	private TabPage tabPage_2;

	// Token: 0x040003AA RID: 938
	private TabPage tabPage_3;

	// Token: 0x040003AB RID: 939
	private TabPage tabPage_4;

	// Token: 0x040003AC RID: 940
	private DataGridView dataGridView_1;

	// Token: 0x040003AD RID: 941
	private System.Windows.Forms.Timer timer_0;

	// Token: 0x040003AE RID: 942
	private TextBox textBox_0;

	// Token: 0x040003AF RID: 943
	private Label label_0;

	// Token: 0x040003B0 RID: 944
	private ComboBox comboBox_0;

	// Token: 0x040003B1 RID: 945
	private Button button_0;

	// Token: 0x040003B2 RID: 946
	private Button button_1;

	// Token: 0x040003B3 RID: 947
	private Label label_1;

	// Token: 0x040003B4 RID: 948
	private TextBox textBox_1;

	// Token: 0x040003B5 RID: 949
	private TabPage tabPage_5;

	// Token: 0x040003B6 RID: 950
	private TabPage tabPage_6;

	// Token: 0x040003B7 RID: 951
	private TextBox textBox_2;

	// Token: 0x040003B8 RID: 952
	private DataGridView dataGridView_2;

	// Token: 0x040003B9 RID: 953
	private Label label_2;

	// Token: 0x040003BA RID: 954
	private ComboBox comboBox_1;

	// Token: 0x040003BB RID: 955
	private Button button_2;

	// Token: 0x040003BC RID: 956
	private Button button_3;

	// Token: 0x040003BD RID: 957
	private Label label_3;

	// Token: 0x040003BE RID: 958
	private Button button_4;

	// Token: 0x040003BF RID: 959
	private TextBox textBox_3;

	// Token: 0x040003C0 RID: 960
	private DataGridView dataGridView_3;

	// Token: 0x040003C1 RID: 961
	private System.Windows.Forms.Timer timer_1;

	// Token: 0x040003C2 RID: 962
	private SaveFileDialog saveFileDialog_0;

	// Token: 0x040003C3 RID: 963
	private TabPage tabPage_7;

	// Token: 0x040003C4 RID: 964
	private Button button_5;

	// Token: 0x040003C5 RID: 965
	private Button button_6;

	// Token: 0x040003C6 RID: 966
	private DataGridView dataGridView_4;

	// Token: 0x040003C7 RID: 967
	private Button button_7;

	// Token: 0x040003C8 RID: 968
	private Label label_4;

	// Token: 0x040003C9 RID: 969
	private Label label_5;

	// Token: 0x040003CA RID: 970
	private Panel panel_0;

	// Token: 0x040003CB RID: 971
	private Button button_8;

	// Token: 0x040003CC RID: 972
	private Label label_6;

	// Token: 0x040003CD RID: 973
	private DataGridView dataGridView_5;

	// Token: 0x040003CE RID: 974
	private DataGridView dataGridView_6;

	// Token: 0x040003CF RID: 975
	private Label label_7;

	// Token: 0x040003D0 RID: 976
	private Label label_8;

	// Token: 0x040003D1 RID: 977
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	// Token: 0x040003D2 RID: 978
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	// Token: 0x040003D3 RID: 979
	private Button button_9;

	// Token: 0x040003D4 RID: 980
	private Button button_10;

	// Token: 0x040003D5 RID: 981
	private Label label_9;

	// Token: 0x040003D6 RID: 982
	private ImageList imageList_0;

	// Token: 0x040003D7 RID: 983
	private DataGridView dataGridView_7;

	// Token: 0x040003D8 RID: 984
	private Label label_10;

	// Token: 0x040003D9 RID: 985
	private SplitContainer splitContainer_0;

	// Token: 0x040003DA RID: 986
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	// Token: 0x040003DB RID: 987
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	// Token: 0x040003DC RID: 988
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	// Token: 0x040003DD RID: 989
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	// Token: 0x040003DE RID: 990
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	// Token: 0x040003DF RID: 991
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	// Token: 0x040003E0 RID: 992
	private Button button_11;

	// Token: 0x040003E1 RID: 993
	private Panel panel_1;

	// Token: 0x040003E2 RID: 994
	private Panel panel_2;

	// Token: 0x040003E3 RID: 995
	private Label label_11;

	// Token: 0x040003E4 RID: 996
	private Panel panel_3;

	// Token: 0x040003E5 RID: 997
	private Panel panel_4;

	// Token: 0x040003E6 RID: 998
	private Panel panel_5;

	// Token: 0x040003E7 RID: 999
	private SplitContainer splitContainer_1;

	// Token: 0x040003E8 RID: 1000
	private SplitContainer splitContainer_2;

	// Token: 0x040003E9 RID: 1001
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	// Token: 0x040003EA RID: 1002
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

	// Token: 0x040003EB RID: 1003
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

	// Token: 0x040003EC RID: 1004
	private GClass114 gclass114_0;

	// Token: 0x040003ED RID: 1005
	private Label label_12;

	// Token: 0x040003EE RID: 1006
	private ComboBox comboBox_2;

	// Token: 0x040003EF RID: 1007
	private GClass114 gclass114_1;

	// Token: 0x040003F0 RID: 1008
	private Panel panel_6;

	// Token: 0x040003F1 RID: 1009
	private ComboBox comboBox_3;

	// Token: 0x040003F2 RID: 1010
	private Label label_13;

	// Token: 0x040003F3 RID: 1011
	private Button button_12;

	// Token: 0x040003F4 RID: 1012
	private Panel panel_7;

	// Token: 0x040003F5 RID: 1013
	private Panel panel_8;

	// Token: 0x040003F6 RID: 1014
	private TextBox textBox_4;

	// Token: 0x040003F7 RID: 1015
	private SplitContainer splitContainer_3;

	// Token: 0x040003F8 RID: 1016
	private Panel panel_9;

	// Token: 0x040003F9 RID: 1017
	private Panel panel_10;

	// Token: 0x040003FA RID: 1018
	private SplitContainer splitContainer_4;

	// Token: 0x040003FB RID: 1019
	private DataGridView dataGridView_8;

	// Token: 0x040003FC RID: 1020
	private TextBox textBox_5;

	// Token: 0x040003FD RID: 1021
	private Button button_13;

	// Token: 0x040003FE RID: 1022
	private CheckBox checkBox_0;

	// Token: 0x040003FF RID: 1023
	private DataGridView dataGridView_9;

	// Token: 0x04000400 RID: 1024
	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	// Token: 0x04000401 RID: 1025
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

	// Token: 0x04000402 RID: 1026
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

	// Token: 0x04000403 RID: 1027
	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_1;

	// Token: 0x04000404 RID: 1028
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

	// Token: 0x04000405 RID: 1029
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

	// Token: 0x04000406 RID: 1030
	private FlowLayoutPanel flowLayoutPanel_0;

	// Token: 0x04000407 RID: 1031
	private System.Windows.Forms.Timer timer_2;

	// Token: 0x04000408 RID: 1032
	private Label label_14;

	// Token: 0x04000409 RID: 1033
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

	// Token: 0x0400040A RID: 1034
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

	// Token: 0x0400040B RID: 1035
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

	// Token: 0x0400040C RID: 1036
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

	// Token: 0x0400040D RID: 1037
	private Button button_14;

	// Token: 0x0400040E RID: 1038
	private Button button_15;

	// Token: 0x0400040F RID: 1039
	private Button button_16;

	// Token: 0x04000410 RID: 1040
	private Button button_17;

	// Token: 0x04000411 RID: 1041
	private Button button_18;

	// Token: 0x04000412 RID: 1042
	private Label label_15;

	// Token: 0x04000413 RID: 1043
	private DataGridView dataGridView_10;

	// Token: 0x04000414 RID: 1044
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

	// Token: 0x04000415 RID: 1045
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

	// Token: 0x04000416 RID: 1046
	private OpenFileDialog openFileDialog_0;

	// Token: 0x04000417 RID: 1047
	private Button button_19;

	// Token: 0x04000418 RID: 1048
	private Button button_20;

	// Token: 0x04000419 RID: 1049
	private Label label_16;

	// Token: 0x0400041A RID: 1050
	private CheckBox checkBox_1;

	// Token: 0x0400041B RID: 1051
	private Label label_17;

	// Token: 0x0400041C RID: 1052
	private ToolTip toolTip_0;

	// Token: 0x0400041D RID: 1053
	private Panel panel_11;

	// Token: 0x0400041E RID: 1054
	private Button button_21;

	// Token: 0x0400041F RID: 1055
	private Button button_22;

	// Token: 0x04000420 RID: 1056
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

	// Token: 0x04000421 RID: 1057
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_22;

	// Token: 0x04000422 RID: 1058
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_23;

	// Token: 0x04000423 RID: 1059
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_24;

	// Token: 0x04000424 RID: 1060
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_25;

	// Token: 0x04000425 RID: 1061
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_26;

	// Token: 0x04000426 RID: 1062
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_27;

	// Token: 0x04000427 RID: 1063
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_28;

	// Token: 0x04000428 RID: 1064
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_29;

	// Token: 0x04000429 RID: 1065
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_30;

	// Token: 0x0400042A RID: 1066
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_31;

	// Token: 0x0400042B RID: 1067
	private FlowLayoutPanel flowLayoutPanel_1;

	// Token: 0x0400042C RID: 1068
	private Button button_23;

	// Token: 0x0400042D RID: 1069
	private TextBox textBox_6;

	// Token: 0x0400042E RID: 1070
	private Panel panel_12;

	// Token: 0x0400042F RID: 1071
	private Button button_24;

	// Token: 0x04000430 RID: 1072
	private Button button_25;

	// Token: 0x04000431 RID: 1073
	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_2;

	// Token: 0x04000432 RID: 1074
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_32;

	// Token: 0x04000433 RID: 1075
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_33;

	// Token: 0x04000434 RID: 1076
	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_3;

	// Token: 0x04000435 RID: 1077
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_34;

	// Token: 0x04000436 RID: 1078
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_35;

	// Token: 0x04000437 RID: 1079
	private FlowLayoutPanel flowLayoutPanel_2;

	// Token: 0x04000438 RID: 1080
	private Button button_26;

	// Token: 0x04000439 RID: 1081
	private FlowLayoutPanel flowLayoutPanel_3;

	// Token: 0x0400043A RID: 1082
	private Button button_27;

	// Token: 0x0400043B RID: 1083
	private FlowLayoutPanel flowLayoutPanel_4;

	// Token: 0x0400043C RID: 1084
	private Button button_28;

	// Token: 0x0400043D RID: 1085
	private FlowLayoutPanel flowLayoutPanel_5;

	// Token: 0x0400043E RID: 1086
	private Button button_29;

	// Token: 0x0400043F RID: 1087
	private Panel panel_13;

	// Token: 0x04000440 RID: 1088
	private Panel panel_14;

	// Token: 0x04000441 RID: 1089
	private Panel panel_15;

	// Token: 0x04000442 RID: 1090
	private Panel panel_16;

	// Token: 0x04000443 RID: 1091
	private Label label_18;

	// Token: 0x04000444 RID: 1092
	private Label label_19;

	// Token: 0x04000445 RID: 1093
	private Label label_20;

	// Token: 0x04000446 RID: 1094
	private Panel panel_17;

	// Token: 0x04000447 RID: 1095
	private FlowLayoutPanel flowLayoutPanel_6;

	// Token: 0x04000448 RID: 1096
	private Label label_21;

	// Token: 0x04000449 RID: 1097
	private Panel panel_18;

	// Token: 0x0200009F RID: 159
	// (Invoke) Token: 0x06000552 RID: 1362
	private delegate void Delegate4();

	// Token: 0x020000A0 RID: 160
	// (Invoke) Token: 0x06000556 RID: 1366
	private delegate void Delegate5();

	// Token: 0x020000A1 RID: 161
	// (Invoke) Token: 0x0600055A RID: 1370
	private delegate void Delegate6();

	// Token: 0x020000A2 RID: 162
	// (Invoke) Token: 0x0600055E RID: 1374
	private delegate void Delegate7();

	// Token: 0x020000A3 RID: 163
	// (Invoke) Token: 0x06000562 RID: 1378
	private delegate void Delegate8(string message3);

	// Token: 0x020000A4 RID: 164
	// (Invoke) Token: 0x06000566 RID: 1382
	private delegate void Delegate9(string message1, string message2, string message3);

	// Token: 0x020000A5 RID: 165
	// (Invoke) Token: 0x0600056A RID: 1386
	private delegate void Delegate10(string message1, string message2, string message3, bool closeOnKeyPress, int autoCloseTimeMS);

	// Token: 0x020000A6 RID: 166
	// (Invoke) Token: 0x0600056E RID: 1390
	private delegate void Delegate11(bool forcedInTestMode);

	// Token: 0x020000A7 RID: 167
	[CompilerGenerated]
	private sealed class Class9
	{
		// Token: 0x06000572 RID: 1394 RVA: 0x00003FAF File Offset: 0x000021AF
		internal void method_0()
		{
			this.<>4__this.method_26(this.protocolID, this.moduleID, this.ECUAddressString, this.CANAddressString, this.ecuAddress, this.adapterType, this.obdpin);
		}

		// Token: 0x0400044A RID: 1098
		public GForm8 <>4__this;

		// Token: 0x0400044B RID: 1099
		public string protocolID;

		// Token: 0x0400044C RID: 1100
		public string moduleID;

		// Token: 0x0400044D RID: 1101
		public string ECUAddressString;

		// Token: 0x0400044E RID: 1102
		public string CANAddressString;

		// Token: 0x0400044F RID: 1103
		public byte ecuAddress;

		// Token: 0x04000450 RID: 1104
		public int adapterType;

		// Token: 0x04000451 RID: 1105
		public int obdpin;
	}

	// Token: 0x020000A8 RID: 168
	[CompilerGenerated]
	private sealed class Class10
	{
		// Token: 0x06000574 RID: 1396 RVA: 0x00003FE6 File Offset: 0x000021E6
		internal void method_0()
		{
			this.<>4__this.method_42(this.moduleID);
		}

		// Token: 0x04000452 RID: 1106
		public GForm8 <>4__this;

		// Token: 0x04000453 RID: 1107
		public string moduleID;
	}
}
