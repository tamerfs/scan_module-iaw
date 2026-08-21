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
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FiatECUScan2;

// Token: 0x02000074 RID: 116
public sealed partial class FormMain : Form
{
	// Token: 0x060003B6 RID: 950 RVA: 0x0007938C File Offset: 0x0007758C
	public FormMain()
	{
		this.InitializeComponent();
		this.panelLoading.Visible = true;
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x000794A8 File Offset: 0x000776A8
	private void FormMain_Shown(object sender, EventArgs e)
	{
		this.panelLoading.Size = new Size(base.Width, base.Height);
		this.lblLoading.Location = new Point((base.Width - this.lblLoading.Width) / 2, (base.Height - this.lblLoading.Height) / 2);
		GClass3.list_0 = this.list_0;
		GClass3.stopwatch_0 = Stopwatch.StartNew();
		GClass3.smethod_2("Start 1", 0);
		base.WindowState = FormWindowState.Maximized;
		this.ttslMsg.Text = "Disconnected";
		this.tsslAction.Text = string.Empty;
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		string text = executingAssembly.GetName().Version.ToString();
		GClass3.string_0 = "FiatECUScan " + text.Replace(".0", string.Empty);
		this.Text = GClass3.string_0;
		GClass61.smethod_23(Application.StartupPath);
		GClass61.smethod_17(Application.ExecutablePath);
		GClass3.string_6 = GClass16.smethod_18();
		GClass61.smethod_99();
		GClass61.smethod_105();
		GClass61.smethod_102();
		this.method_24();
		this.method_25(text);
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		string text2 = string.Empty;
		foreach (string text2 in commandLineArgs)
		{
			string[] array = text2.Split(new char[]
			{
				'='
			});
			if (array.Length == 2 && array[0].ToLower() == "/t")
			{
				int num = GClass16.smethod_5(array[1]);
				if (GClass61.smethod_87(num) != string.Empty)
				{
					GClass3.int_8 = num;
					Thread.Sleep(200);
					this.buttonConnect_Click(null, null);
				}
				else
				{
					base.Close();
				}
			}
		}
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x00079674 File Offset: 0x00077874
	private void method_0()
	{
		if (GClass16.smethod_25())
		{
			try
			{
				base.Invoke(new FormMain.Delegate1(this.method_27), new object[0]);
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x060003B9 RID: 953 RVA: 0x000796BC File Offset: 0x000778BC
	private void buttonUploadReport_Click(object sender, EventArgs e)
	{
		if (this.formNotify_0 == null)
		{
			this.formNotify_0 = new FormNotify(GClass62.smethod_1("1076"), GClass62.smethod_1("1077"), GClass62.smethod_1("1078"), true, 0);
			this.formNotify_0.ShowDialog();
			if (this.formNotify_0.method_1())
			{
				this.formNotify_0 = new FormNotify(GClass62.smethod_1("1079"), GClass62.smethod_1("1052"), string.Empty, true, 0);
				new Thread(new ThreadStart(this.method_1)).Start();
				this.formNotify_0.ShowDialog();
				if (GClass3.smethod_7() < 10)
				{
					this.buttonUploadReport.Visible = false;
				}
			}
			this.formNotify_0 = null;
		}
	}

	// Token: 0x060003BA RID: 954 RVA: 0x00079788 File Offset: 0x00077988
	private void method_1()
	{
		try
		{
			string text = string.Concat(new string[]
			{
				"FL_",
				DateTime.Now.ToString("yyMMddHHmmss"),
				"_",
				GClass3.string_2,
				".txt"
			});
			text = text.Replace("/", string.Empty).Replace("\\", string.Empty);
			FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://ftp.fiatecuscan.net/" + text);
			ftpWebRequest.Method = "STOR";
			ftpWebRequest.Credentials = new NetworkCredential("reports", "reports");
			Stream requestStream = ftpWebRequest.GetRequestStream();
			try
			{
				byte[] bytes = Encoding.Unicode.GetBytes(GClass3.smethod_6());
				requestStream.Write(bytes, 0, bytes.Length);
				GClass3.smethod_5();
			}
			finally
			{
				requestStream.Close();
			}
		}
		catch (Exception ex)
		{
			GClass3.smethod_2("Failed to send diagnostic report: " + ex.Message, 0);
			base.Invoke(new FormMain.Delegate3(this.method_31), new object[]
			{
				GClass62.smethod_1("1080"),
				string.Empty,
				string.Empty,
				false,
				0
			});
			Thread.Sleep(2000);
		}
		base.Invoke(new FormMain.Delegate2(this.method_28));
	}

	// Token: 0x060003BB RID: 955 RVA: 0x0000339A File Offset: 0x0000159A
	private void method_2(object sender, EventArgs e)
	{
		this.toolTip_0.Active = true;
	}

	// Token: 0x060003BC RID: 956 RVA: 0x000033A8 File Offset: 0x000015A8
	private void method_3(object sender, EventArgs e)
	{
		this.toolTip_0.Active = false;
	}

	// Token: 0x060003BD RID: 957 RVA: 0x00079910 File Offset: 0x00077B10
	private void method_4()
	{
		Cursor.Current = Cursors.WaitCursor;
		List<Control> list = FormMain.smethod_1(this, 1);
		list.AddRange(FormMain.smethod_0(this.tabPageInfo));
		list.AddRange(FormMain.smethod_0(this.tabPageErrors));
		list.AddRange(FormMain.smethod_0(this.tabPageParams));
		list.AddRange(FormMain.smethod_0(this.tabPageGraph));
		list.AddRange(FormMain.smethod_0(this.tabPageActuators));
		list.AddRange(FormMain.smethod_0(this.tabPageAdjustments));
		list.AddRange(FormMain.smethod_0(this.tabPageLog));
		foreach (Control control in list)
		{
			if (control.Tag != null)
			{
				string text = GClass62.smethod_1(control.Tag.ToString());
				string text2 = GClass62.smethod_1(control.Tag.ToString() + "T");
				if (text2 != null && text2 != string.Empty && (control is Button || control is CheckBox || control is ComboBox))
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
		foreach (Control control in list)
		{
			if (control is Button)
			{
				Button button = (Button)control;
				if (button.Name != this.buttonRegister.Name && button.Name != this.buttonUploadReport.Name)
				{
					button.Font = GClass61.smethod_20();
				}
			}
			else if (control is CheckBox)
			{
				((CheckBox)control).Font = GClass61.smethod_20();
			}
			else
			{
				if (control is DataGridView)
				{
					DataGridView dataGridView = (DataGridView)control;
					if (dataGridView.Tag != null && dataGridView.Tag.ToString() == "3")
					{
						continue;
					}
					dataGridView.RowTemplate.DefaultCellStyle.Font = GClass61.smethod_18();
					using (IEnumerator enumerator2 = ((IEnumerable)dataGridView.Rows).GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							object obj = enumerator2.Current;
							DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
							dataGridViewRow.DefaultCellStyle.Font = GClass61.smethod_18();
						}
						continue;
					}
				}
				if (control is ComboBox)
				{
					ComboBox comboBox = (ComboBox)control;
					if ((comboBox.Tag == null || !(comboBox.Tag.ToString() == "3")) && (comboBox.Tag == null || !comboBox.Tag.ToString().StartsWith("50")))
					{
						comboBox.Font = GClass61.smethod_20();
					}
				}
			}
		}
		this.tabControlMain.Font = GClass61.smethod_20();
		List<TabPage> list2 = new List<TabPage>();
		list2.Add(this.tabPageSelect);
		list2.Add(this.tabPageInfo);
		list2.Add(this.tabPageErrors);
		list2.Add(this.tabPageParams);
		list2.Add(this.tabPageGraph);
		list2.Add(this.tabPageActuators);
		list2.Add(this.tabPageAdjustments);
		list2.Add(this.tabPageLog);
		for (int i = 0; i < list2.Count; i++)
		{
			TabPage tabPage = list2[i];
			string text = GClass62.smethod_1(i + 1 + "001");
			if (text != null)
			{
				tabPage.Text = text;
			}
		}
		this.tsslConnProblem.Text = GClass62.smethod_1("1060");
		Cursor.Current = Cursors.Default;
	}

	// Token: 0x060003BE RID: 958 RVA: 0x00079DD0 File Offset: 0x00077FD0
	public static List<Control> smethod_0(Control control_0)
	{
		List<Control> list = FormMain.smethod_1(control_0, 1);
		list.Add(control_0);
		return list;
	}

	// Token: 0x060003BF RID: 959 RVA: 0x00079DF0 File Offset: 0x00077FF0
	public static List<Control> smethod_1(Control control_0, int int_1)
	{
		List<Control> list = new List<Control>();
		if (int_1 < 10)
		{
			foreach (object obj in control_0.Controls)
			{
				Control control = (Control)obj;
				list.AddRange(FormMain.smethod_1(control, int_1 + 1));
				list.Add(control);
			}
		}
		return list;
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x00079E74 File Offset: 0x00078074
	private void buttonRegister_Click(object sender, EventArgs e)
	{
		string a = GClass61.smethod_7();
		if (new FormRegistration().ShowDialog() == DialogResult.OK || a != GClass61.smethod_7())
		{
			this.bool_0 = true;
			base.Close();
		}
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x00079EB4 File Offset: 0x000780B4
	private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (this.gclass19_0 != null)
		{
			this.gclass19_0.vmethod_2(false, true);
		}
		for (int i = 0; i < 10; i++)
		{
			GClass61.smethod_88(i, this.list_7[i].Value);
		}
		GClass61.smethod_106();
		GClass61.smethod_104();
		GClass61.smethod_101();
		GClass3.smethod_9();
		if (GClass3.stopwatch_0 != null && GClass3.stopwatch_0.IsRunning)
		{
			GClass3.stopwatch_0.Stop();
		}
		if (this.bool_0)
		{
			Process.Start(new ProcessStartInfo(GClass61.smethod_22() + "\\FiatECUScan2.exe"));
		}
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x000026DC File Offset: 0x000008DC
	private void FormMain_KeyUp(object sender, KeyEventArgs e)
	{
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x000026DC File Offset: 0x000008DC
	private void tabControlMain_KeyPress(object sender, KeyPressEventArgs e)
	{
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x00079F5C File Offset: 0x0007815C
	private void tabControlMain_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Right && !e.Alt && this.tabControlMain.SelectedTab == this.tabPageGraph)
		{
			e.Handled = true;
			for (int i = 0; i < this.tableLayoutPanelGraphs.Controls.Count; i++)
			{
				((GClass65)this.tableLayoutPanelGraphs.Controls[i]).method_5(e.Control);
			}
			this.tableLayoutPanelGraphs.Invalidate();
			this.tableLayoutPanelGraphs.Focus();
		}
		else if (e.KeyCode == Keys.Left && !e.Alt && this.tabControlMain.SelectedTab == this.tabPageGraph)
		{
			e.Handled = true;
			for (int i = 0; i < this.tableLayoutPanelGraphs.Controls.Count; i++)
			{
				((GClass65)this.tableLayoutPanelGraphs.Controls[i]).method_6(e.Control);
			}
			this.tableLayoutPanelGraphs.Invalidate();
			this.tableLayoutPanelGraphs.Focus();
		}
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x0007A080 File Offset: 0x00078280
	private void tabControlMain_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F2 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab != this.tabPageSelect)
		{
			e.Handled = true;
			if (this.tabControlMain.Contains(this.tabPageInfo))
			{
				this.tabControlMain.SelectedTab = this.tabPageInfo;
			}
		}
		else if (e.KeyCode == Keys.F3 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab != this.tabPageErrors)
		{
			e.Handled = true;
			if (this.tabControlMain.Contains(this.tabPageErrors))
			{
				this.tabControlMain.SelectedTab = this.tabPageErrors;
			}
		}
		else if (e.KeyCode == Keys.F4 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab != this.tabPageParams)
		{
			e.Handled = true;
			if (this.tabControlMain.Contains(this.tabPageParams))
			{
				this.tabControlMain.SelectedTab = this.tabPageParams;
			}
		}
		else if (e.KeyCode == Keys.F5 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab != this.tabPageGraph)
		{
			e.Handled = true;
			if (this.tabControlMain.Contains(this.tabPageGraph))
			{
				this.tabControlMain.SelectedTab = this.tabPageGraph;
			}
		}
		else if (e.KeyCode == Keys.F6 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab != this.tabPageActuators)
		{
			e.Handled = true;
			if (this.tabControlMain.Contains(this.tabPageActuators))
			{
				this.tabControlMain.SelectedTab = this.tabPageActuators;
			}
		}
		else if (e.KeyCode == Keys.F7 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab != this.tabPageAdjustments)
		{
			e.Handled = true;
			if (this.tabControlMain.Contains(this.tabPageAdjustments))
			{
				this.tabControlMain.SelectedTab = this.tabPageAdjustments;
			}
		}
		else if (e.KeyCode == Keys.F10 && !e.Alt && this.tabControlMain.SelectedTab == this.tabPageSelect)
		{
			e.Handled = true;
			GClass3.bool_0 = e.Control;
			if (this.buttonConnect.Enabled)
			{
				this.buttonConnect_Click(null, null);
			}
		}
		else if (e.KeyCode == Keys.F9 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageSelect)
		{
			e.Handled = true;
			if (this.buttonSettings.Enabled)
			{
				this.buttonSettings_Click(null, null);
			}
		}
		else if (e.KeyCode == Keys.F11 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageSelect)
		{
			e.Handled = true;
			if (this.buttonConnectAuto.Enabled)
			{
				this.buttonConnectAuto_Click(null, null);
			}
		}
		else if (e.KeyCode == Keys.F12 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageSelect)
		{
			e.Handled = true;
			if (this.buttonScanDTC.Enabled)
			{
				this.buttonScanDTC_Click(null, null);
			}
		}
		else if (e.KeyCode == Keys.F11 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab != this.tabPageSelect && this.gclass19_0 != null && this.gclass19_0.method_10())
		{
			e.Handled = true;
			if (this.buttonDisconnect.Enabled)
			{
				this.buttonDisconnect_Click(null, null);
			}
		}
		else if (e.KeyCode == Keys.F10 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageErrors)
		{
			e.Handled = true;
			if (this.btnErrorsClear.Enabled)
			{
				this.btnErrorsClear_Click(null, null);
			}
		}
		else if (e.KeyCode == Keys.F10 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageActuators)
		{
			e.Handled = true;
			if (this.btnActuatorsExecute.Enabled)
			{
				this.btnActuatorsExecute_Click(null, null);
			}
		}
		else if (e.KeyCode == Keys.F10 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageAdjustments)
		{
			e.Handled = true;
			if (this.btnAdjustmentsExecute.Enabled)
			{
				this.btnAdjustmentsExecute_Click(null, null);
			}
		}
		else if (e.KeyCode == Keys.S && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageParams)
		{
			e.Handled = true;
			if (this.btnParamsArrange.Enabled)
			{
				this.btnParamsArrange_Click(null, null);
			}
		}
		else if (e.KeyCode == Keys.U && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageParams)
		{
			e.Handled = true;
			if (this.btnArrangeUnits.Enabled)
			{
				this.btnArrangeUnits_Click(null, null);
			}
		}
		else if (e.KeyCode == Keys.L && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageParams)
		{
			e.Handled = true;
			if (this.btnArrangeName.Enabled)
			{
				this.btnArrangeName_Click(null, null);
			}
		}
		else if (e.KeyCode == Keys.T && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageParams)
		{
			e.Handled = true;
			if (this.btnTemplateLoad.Enabled)
			{
				this.btnTemplateLoad_Click(null, null);
			}
		}
		else if (e.KeyCode == Keys.R && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageParams)
		{
			e.Handled = true;
			if (this.chkParamsAutoUp.Enabled)
			{
				this.chkParamsAutoUp.Checked = !this.chkParamsAutoUp.Checked;
			}
		}
		else if (e.KeyCode == Keys.E && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageParams)
		{
			e.Handled = true;
			if (this.chkMonitorErrors.Enabled)
			{
				this.chkMonitorErrors.Checked = !this.chkMonitorErrors.Checked;
			}
		}
		else if (e.KeyCode == Keys.A && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageParams)
		{
			e.Handled = true;
			if (this.buttonSelectAll.Enabled)
			{
				this.buttonSelectAll_Click(null, null);
			}
		}
		else if (e.KeyCode == Keys.N && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageParams)
		{
			e.Handled = true;
			if (this.buttonSelectNone.Enabled)
			{
				this.buttonSelectNone_Click(null, null);
			}
		}
		else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageParams)
		{
			e.Handled = true;
			this.method_16(e.KeyCode - Keys.D0);
		}
		else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && !e.Alt && e.Control && this.tabControlMain.SelectedTab == this.tabPageParams)
		{
			e.Handled = true;
			this.method_17(e.KeyCode - Keys.D0);
		}
		else if (e.KeyCode == Keys.F10 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageGraph)
		{
			e.Handled = true;
			if (this.buttonGraphStart.Enabled)
			{
				this.buttonGraphStart_Click(null, null);
			}
		}
		else if (this.tabControlMain.SelectedTab != this.tabPageGraph || (!this.tbRecordingName.Focused && !this.dgvTags.Focused && !this.dgvTags.IsCurrentCellInEditMode))
		{
			if (e.KeyCode == Keys.E && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageGraph)
			{
				e.Handled = true;
				if (this.btnExportGraph.Enabled)
				{
					this.btnExportGraph_Click(null, null);
				}
			}
			else if (e.KeyCode == Keys.R && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageGraph)
			{
				e.Handled = true;
				if (this.cbGraphRate.Enabled)
				{
					this.cbGraphRate.Focus();
					this.cbGraphRate.DroppedDown = true;
				}
			}
			else if (e.KeyCode == Keys.S && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageGraph)
			{
				e.Handled = true;
				if (this.cbGraphScale.Enabled)
				{
					this.cbGraphScale.Focus();
					this.cbGraphScale.DroppedDown = true;
				}
			}
			else if (e.KeyCode == Keys.G && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageGraph)
			{
				e.Handled = true;
				if (this.cbGraphCount.Enabled)
				{
					this.cbGraphCount.Focus();
					this.cbGraphCount.DroppedDown = true;
				}
			}
			else if (e.KeyCode == Keys.T && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageGraph)
			{
				e.Handled = true;
				if (GClass3.bool_3)
				{
					this.method_22();
				}
			}
			else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && !e.Alt && !e.Control && this.tabControlMain.SelectedTab == this.tabPageGraph)
			{
				e.Handled = true;
				this.method_23(e.KeyCode - Keys.D0);
			}
		}
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x000033B6 File Offset: 0x000015B6
	private void lblLink_MouseClick(object sender, MouseEventArgs e)
	{
		Process.Start("http://www.fiatecuscan.net");
		this.dgvSelectECU.Focus();
	}

	// Token: 0x060003C7 RID: 967 RVA: 0x0007AC90 File Offset: 0x00078E90
	private void method_5()
	{
		int num = GClass61.smethod_57();
		try
		{
			DataRow[] array = ((DataView)this.dgvSelectECU.DataSource).Table.Select("SystemID=" + num, string.Empty);
			int num2 = (int)array[0]["CategoryID"];
			int num3 = (int)array[0]["ModelID"];
			array = ((DataView)this.dgvSelectModel.DataSource).Table.Select("ModelID=" + num3, string.Empty);
			int num4 = (int)array[0]["MakeID"];
			for (int i = 0; i < this.dgvSelectMake.Rows.Count; i++)
			{
				if ((int)this.dgvSelectMake.Rows[i].Cells[this.colMake01.Name].Value == num4)
				{
					this.dgvSelectMake.CurrentCell = this.dgvSelectMake.Rows[i].Cells[1];
					this.dgvSelectMake.Rows[i].Selected = true;
					this.dgvSelectMake.FirstDisplayedScrollingRowIndex = i;
					IL_14A:
					this.dgvSelectMake_SelectionChanged(null, null);
					for (i = 0; i < this.dgvSelectModel.Rows.Count; i++)
					{
						if ((int)this.dgvSelectModel.Rows[i].Cells[this.colModel02.Name].Value == num3)
						{
							this.dgvSelectModel.CurrentCell = this.dgvSelectModel.Rows[i].Cells[2];
							this.dgvSelectModel.Rows[i].Selected = true;
							this.dgvSelectModel.FirstDisplayedScrollingRowIndex = i;
							IL_1FB:
							this.dgvSelectModel_SelectionChanged(null, null);
							for (i = 0; i < this.dgvSelectSystem.Rows.Count; i++)
							{
								if ((int)this.dgvSelectSystem.Rows[i].Cells[this.colCategory01.Name].Value == num2)
								{
									this.dgvSelectSystem.CurrentCell = this.dgvSelectSystem.Rows[i].Cells[1];
									this.dgvSelectSystem.Rows[i].Selected = true;
									this.dgvSelectSystem.FirstDisplayedScrollingRowIndex = i;
									IL_2AC:
									this.dgvSelectSystem_SelectionChanged(null, null);
									for (i = 0; i < this.dgvSelectECU.Rows.Count; i++)
									{
										if ((int)this.dgvSelectECU.Rows[i].Cells[this.colSystem01.Name].Value == num)
										{
											this.dgvSelectECU.CurrentCell = this.dgvSelectECU.Rows[i].Cells[3];
											this.dgvSelectECU.Rows[i].Selected = true;
											this.dgvSelectECU.FirstDisplayedScrollingRowIndex = i;
											IL_35D:
											return;
										}
									}
									goto IL_35D;
								}
							}
							goto IL_2AC;
						}
					}
					goto IL_1FB;
				}
			}
			goto IL_14A;
		}
		catch (Exception)
		{
			this.dgvSelectMake.Rows[0].Selected = false;
			this.dgvSelectMake.Rows[0].Selected = true;
		}
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x0007B04C File Offset: 0x0007924C
	private void dgvSelectMake_SelectionChanged(object sender, EventArgs e)
	{
		int num = -1;
		if (this.dgvSelectMake.SelectedRows.Count > 0)
		{
			num = (int)this.dgvSelectMake.SelectedRows[0].Cells[this.colMake01.Name].Value;
		}
		DataView dataView = (DataView)this.dgvSelectModel.DataSource;
		if (dataView != null)
		{
			if (num == 4 && GClass61.smethod_66().Length > 0)
			{
				dataView.RowFilter = "ModelID in (" + GClass61.smethod_66() + ")";
			}
			else
			{
				dataView.RowFilter = "MakeID=" + num;
			}
			this.dgvSelectModel.DataSource = dataView;
			this.dgvSelectSystem_Leave(null, null);
		}
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x0007B120 File Offset: 0x00079320
	private void dgvSelectModel_SelectionChanged(object sender, EventArgs e)
	{
		string str = "-1";
		if (this.dgvSelectModel.SelectedRows.Count > 0)
		{
			str = (string)this.dgvSelectModel.SelectedRows[0].Cells[this.colModel04.Name].Value;
			int num = (int)this.dgvSelectModel.SelectedRows[0].Cells[this.colModel02.Name].Value;
		}
		DataView dataView = (DataView)this.dgvSelectSystem.DataSource;
		if (dataView != null)
		{
			dataView.RowFilter = "CategoryID in (" + str + ")";
			this.dgvSelectSystem.DataSource = dataView;
			this.dgvSelectSystem_SelectionChanged(null, null);
		}
	}

	// Token: 0x060003CA RID: 970 RVA: 0x0007B1F4 File Offset: 0x000793F4
	private void dgvSelectSystem_SelectionChanged(object sender, EventArgs e)
	{
		int num = -1;
		int num2 = -1;
		if (this.dgvSelectModel.SelectedRows.Count > 0 && this.dgvSelectSystem.SelectedRows.Count > 0)
		{
			num = (int)this.dgvSelectModel.SelectedRows[0].Cells[this.colModel02.Name].Value;
			num2 = (int)this.dgvSelectSystem.SelectedRows[0].Cells[this.colCategory01.Name].Value;
		}
		DataView dataView = (DataView)this.dgvSelectECU.DataSource;
		if (dataView != null)
		{
			dataView.RowFilter = string.Concat(new object[]
			{
				"ModelID=",
				num,
				" and CategoryID=",
				num2
			});
			dataView.Sort = "SystemDesc";
			this.dgvSelectECU.DataSource = dataView;
			this.dgvSelectSystem_Leave(null, null);
		}
	}

	// Token: 0x060003CB RID: 971 RVA: 0x0007B304 File Offset: 0x00079504
	private void dgvSelectSystem_Leave(object sender, EventArgs e)
	{
		if (this.dgvSelectMake.SelectedRows.Count > 0)
		{
			this.dgvSelectMake.SelectedRows[0].DefaultCellStyle.SelectionBackColor = ((this.splitContainer1.ActiveControl == this.dgvSelectMake) ? Color.FromArgb(255, 255, 128) : Color.Gray);
		}
		if (this.dgvSelectModel.SelectedRows.Count > 0)
		{
			this.dgvSelectModel.SelectedRows[0].DefaultCellStyle.SelectionBackColor = ((this.splitContainer1.ActiveControl == this.dgvSelectModel) ? Color.FromArgb(255, 255, 128) : Color.Gray);
		}
		if (this.dgvSelectSystem.SelectedRows.Count > 0)
		{
			this.dgvSelectSystem.SelectedRows[0].DefaultCellStyle.SelectionBackColor = ((this.splitContainer1.ActiveControl == this.dgvSelectSystem) ? Color.FromArgb(255, 255, 128) : Color.Gray);
		}
		if (this.dgvSelectECU.SelectedRows.Count > 0)
		{
			this.dgvSelectECU.SelectedRows[0].DefaultCellStyle.SelectionBackColor = ((this.splitContainer1.ActiveControl == this.dgvSelectECU) ? Color.FromArgb(255, 255, 128) : Color.Gray);
		}
	}

	// Token: 0x060003CC RID: 972 RVA: 0x0007B498 File Offset: 0x00079698
	private void method_6()
	{
		FormMain.Class13 @class = new FormMain.Class13();
		@class.formMain_0 = this;
		@class.string_0 = this.dgvSelectECU.SelectedRows[0].Cells[this.colSystem04.Name].Value.ToString();
		this.dgvSelectECU.SelectedRows[0].Cells[this.colSystem05.Name].Value.ToString();
		string s = this.dgvSelectECU.SelectedRows[0].Cells[this.colSystem06.Name].Value.ToString();
		this.dgvSelectECU.SelectedRows[0].Cells[this.colSystem08.Name].Value.ToString();
		string a = this.dgvSelectECU.SelectedRows[0].Cells[this.colSystem09.Name].Value.ToString();
		GClass3.bool_6 = (a == "1");
		this.list_3.Clear();
		this.list_0.Clear();
		this.list_1.Clear();
		this.list_2.Clear();
		this.list_5.Clear();
		GClass69 gclass = null;
		try
		{
			gclass = new GClass69(@class.string_0);
		}
		catch (Exception)
		{
			MessageBox.Show("Data file error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			base.Close();
		}
		DataView dataView = new DataView(gclass.dataTable_0);
		foreach (object obj in dataView)
		{
			DataRowView dataRowView = (DataRowView)obj;
			int num = GClass16.smethod_5(dataRowView["CmdType"]);
			GClass58 gclass2 = new GClass58();
			gclass2.byte_0 = GClass16.smethod_11(GClass16.smethod_3(dataRowView["Commands"]));
			gclass2.int_0 = GClass16.smethod_5(dataRowView["StartByte"]);
			gclass2.int_1 = GClass16.smethod_5(dataRowView["NumOfBytes"]);
			gclass2.string_0 = string.Format("{0:000000}", GClass16.smethod_5(dataRowView["MessageID"])) + GClass16.smethod_3(dataRowView["ParamName"]);
			gclass2.string_2 = GClass16.smethod_3(dataRowView["ResultFormat"]);
			gclass2.string_3 = GClass16.smethod_3(dataRowView["Units"]);
			gclass2.string_4 = GClass16.smethod_3(dataRowView["MsgExec"]);
			gclass2.string_5 = new string[]
			{
				GClass16.smethod_3(dataRowView["BitResults"])
			};
			gclass2.string_1 = GClass16.smethod_3(dataRowView["Description"]);
			gclass2.int_2 = GClass16.smethod_5(dataRowView["MessageID"]);
			gclass2.string_6 = gclass2.string_3.ToLower();
			if (GClass61.smethod_55())
			{
				if (gclass2.string_6 == "km/h")
				{
					gclass2.string_3 = "mph";
				}
				if (gclass2.string_6 == "km")
				{
					gclass2.string_3 = "mi";
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
		this.dgvParams.DataSource = GClass16.smethod_30(this.list_0);
		this.dgvInfo.DataSource = GClass16.smethod_30(this.list_3);
		this.dgvActuators.DataSource = GClass16.smethod_30(this.list_1);
		this.dgvAdjustments.DataSource = GClass16.smethod_30(this.list_2);
		Thread thread = new Thread(new ThreadStart(@class.method_0));
		thread.Start();
		if (GClass3.bool_0)
		{
			GClass3.bool_6 = true;
		}
	}

	// Token: 0x060003CD RID: 973 RVA: 0x0007B950 File Offset: 0x00079B50
	private void method_7(GClass58 gclass58_0)
	{
		gclass58_0.string_0 = GClass62.smethod_4(GClass16.smethod_5(gclass58_0.string_0.Substring(0, 6)), gclass58_0.string_0.Substring(6));
		gclass58_0.string_3 = GClass62.smethod_0(gclass58_0.string_3, gclass58_0.string_3);
		gclass58_0.string_5 = GClass16.smethod_17(gclass58_0.string_5[0]);
	}

	// Token: 0x060003CE RID: 974 RVA: 0x0007B9B0 File Offset: 0x00079BB0
	private void method_8(string string_10)
	{
		foreach (GClass58 gclass58_ in this.list_3)
		{
			this.method_7(gclass58_);
		}
		foreach (GClass58 gclass58_ in this.list_0)
		{
			this.method_7(gclass58_);
		}
		foreach (GClass58 gclass58_ in this.list_1)
		{
			this.method_7(gclass58_);
		}
		foreach (GClass58 gclass58_ in this.list_2)
		{
			this.method_7(gclass58_);
		}
		foreach (GClass58 gclass58_ in this.list_5)
		{
			this.method_7(gclass58_);
		}
		this.list_6 = new List<string>();
		GClass2 gclass = new GClass2();
		foreach (DataRow dataRow in gclass.dataTable_4.Select("ModuleID='" + string_10 + "'"))
		{
			this.list_6.Add(GClass16.smethod_3(dataRow["ISOCode"]));
		}
		this.list_4 = new List<GClass64>();
		if (!string_10.StartsWith("SVCRST") && !string_10.StartsWith("CANINFO") && !string_10.StartsWith("PROXI"))
		{
			GClass52 gclass2 = new GClass52(string_10);
			GClass64 gclass3 = new GClass64();
			DataView dataView = new DataView(gclass2.dataTable_0);
			bool flag = false;
			foreach (object obj in dataView)
			{
				DataRowView dataRowView = (DataRowView)obj;
				if (GClass16.smethod_3(dataRowView["ErrorCode"]) == "0000")
				{
					if (GClass16.smethod_3(dataRowView["Error"]) != GClass61.smethod_63() && GClass61.smethod_63() != "Proba123")
					{
						GClass3.int_0++;
					}
					if ((long)GClass16.smethod_5(dataRowView["MessageID"]) != GClass61.smethod_61() && GClass61.smethod_63() != "Proba123")
					{
						GClass3.int_0++;
					}
					flag = true;
					if (GClass61.smethod_65())
					{
						GClass3.int_0 += 3;
					}
				}
				else
				{
					gclass3 = new GClass64();
					gclass3.string_0 = GClass16.smethod_3(dataRowView["ErrorCode"]);
					gclass3.string_1 = GClass16.smethod_3(dataRowView["Error"]);
					gclass3.int_0 = GClass16.smethod_5(dataRowView["MessageID"]);
					gclass3.string_2 = GClass16.smethod_3(dataRowView["Description"]);
					this.list_4.Add(gclass3);
				}
			}
			if (!flag)
			{
				GClass3.smethod_2("ERROR: Missing error code 0000!!!", 0);
			}
		}
	}

	// Token: 0x060003CF RID: 975 RVA: 0x0007BDA4 File Offset: 0x00079FA4
	private void dgvSelectECU_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
	{
		string a = this.dgvSelectECU.Rows[e.RowIndex].Cells[this.colSystem09.Name].Value.ToString();
		if (GClass3.bool_3 || a == this.string_1)
		{
			this.dgvSelectECU.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Navy;
			this.dgvSelectECU.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Navy;
		}
		else
		{
			this.dgvSelectECU.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
			this.dgvSelectECU.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
		}
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x000033CF File Offset: 0x000015CF
	private void buttonConnectAuto_Click(object sender, EventArgs e)
	{
		new FormLookupModules(false).ShowDialog();
		this.buttonUploadReport.Visible = (GClass3.smethod_7() > 50);
	}

	// Token: 0x060003D1 RID: 977 RVA: 0x000033F1 File Offset: 0x000015F1
	private void buttonScanDTC_Click(object sender, EventArgs e)
	{
		if (GClass3.bool_3)
		{
			new FormLookupModules(true).ShowDialog();
			this.buttonUploadReport.Visible = (GClass3.smethod_7() > 50);
		}
	}

	// Token: 0x060003D2 RID: 978 RVA: 0x0007BE98 File Offset: 0x0007A098
	private void dgvSelectModel_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (this.int_0 == 0)
		{
			this.string_3 = string.Empty;
		}
		if (this.timer_2.Interval < 500)
		{
			this.int_0 = 10;
		}
		else
		{
			this.int_0 = 4;
		}
		this.string_3 += e.KeyChar.ToString().ToUpper();
		this.label10.Text = this.string_3;
		for (int i = 0; i < this.dgvSelectModel.Rows.Count; i++)
		{
			if (((string)this.dgvSelectModel.Rows[i].Cells[this.colModel03.Name].Value).StartsWith(this.string_3))
			{
				this.dgvSelectModel.CurrentCell = this.dgvSelectModel.Rows[i].Cells[2];
				this.dgvSelectModel.Rows[i].Selected = true;
				this.dgvSelectModel.FirstDisplayedScrollingRowIndex = i;
				IL_11F:
				this.dgvSelectModel_SelectionChanged(null, null);
				return;
			}
		}
		goto IL_11F;
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x0000341A File Offset: 0x0000161A
	private void method_9(TabPage tabPage_0)
	{
		if (!this.tabControlMain.TabPages.Contains(tabPage_0) && tabPage_0 != this.tabPageLog)
		{
			this.tabControlMain.TabPages.Add(tabPage_0);
		}
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x0007BFCC File Offset: 0x0007A1CC
	private void method_10(bool bool_4)
	{
		this.tabControlMain.TabPages.Remove(this.tabPageInfo);
		this.tabControlMain.TabPages.Remove(this.tabPageErrors);
		this.tabControlMain.TabPages.Remove(this.tabPageParams);
		this.tabControlMain.TabPages.Remove(this.tabPageGraph);
		this.tabControlMain.TabPages.Remove(this.tabPageActuators);
		this.tabControlMain.TabPages.Remove(this.tabPageAdjustments);
		if (bool_4)
		{
			this.tabControlMain.TabPages.Remove(this.tabPageLog);
		}
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x0007C07C File Offset: 0x0007A27C
	private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.tabControlMain.SelectedTab == this.tabPageSelect)
		{
			this.dgvSelectECU.Focus();
			this.method_5();
		}
		else if (this.tabControlMain.SelectedTab == this.tabPageLog)
		{
			this.textBoxLog.Text = GClass3.smethod_6();
		}
		else if (this.tabControlMain.SelectedTab == this.tabPageErrors)
		{
			if (this.dgvErrors.Rows.Count == 0)
			{
				List<GClass64> list = new List<GClass64>();
				list.Add(new GClass64("0000", GClass62.smethod_1("3048"), string.Empty));
				this.dgvErrors.DataSource = GClass16.smethod_31(list);
				this.dgvErrors.Invalidate();
			}
			new Thread(new ThreadStart(this.method_13)).Start();
			this.dgvErrors.Focus();
		}
		else if (this.tabControlMain.SelectedTab == this.tabPageParams)
		{
			this.btnTemplateLoad.Enabled = GClass3.bool_3;
			this.chkParamsAutoUp.Enabled = GClass3.bool_3;
			this.chkMonitorErrors.Enabled = GClass3.bool_3;
			this.buttonSelectAll.Enabled = GClass3.bool_3;
			this.buttonSelectNone.Enabled = GClass3.bool_3;
			if (this.chkMonitorErrors.Enabled)
			{
				this.chkMonitorErrors.Checked = GClass3.bool_7;
			}
			this.lblDTCsPresent.Visible = false;
			this.dgvParams.Focus();
		}
		else if (this.tabControlMain.SelectedTab == this.tabPageActuators)
		{
			this.dgvActuators.Focus();
		}
		else if (this.tabControlMain.SelectedTab == this.tabPageAdjustments)
		{
			this.dgvAdjustments.Focus();
		}
		if (this.tabControlMain.SelectedTab == this.tabPageGraph)
		{
			this.method_19(true, true);
			if (this.gclass19_0 != null)
			{
				this.gclass19_0.method_1(true);
			}
		}
		if (this.tabControlMain.SelectedTab == this.tabPageGraph)
		{
			this.method_18();
		}
		if (this.tabControlMain.SelectedTab != this.tabPageGraph)
		{
			this.method_20();
		}
		if (this.tabControlMain.SelectedTab == this.tabPageActuators)
		{
			List<TableDataRowP> list2 = new List<TableDataRowP>();
			int num = 0;
			while (num < this.list_0.Count && GClass3.bool_3)
			{
				GClass58 gclass = this.list_0[num];
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
			this.dgvActParams.DataSource = list2;
			this.gclass19_0.method_1(true);
		}
		GClass3.bool_11 = (this.tabControlMain.SelectedTab == this.tabPageParams || this.tabControlMain.SelectedTab == this.tabPageGraph || this.tabControlMain.SelectedTab == this.tabPageActuators);
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x0007C3A8 File Offset: 0x0007A5A8
	private void dgvInfo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
	{
		if (((TableDataRowP)this.dgvInfo.Rows[e.RowIndex].DataBoundItem).getDataItem().string_2 == "header")
		{
			this.dgvInfo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
			this.dgvInfo.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
			this.dgvInfo.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Navy;
			this.dgvInfo.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Navy;
		}
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x0007C488 File Offset: 0x0007A688
	private string method_11()
	{
		string result = string.Empty;
		int num = GClass16.smethod_5(this.dgvSelectModel.SelectedRows[0].Cells[this.colModel01.Name].Value);
		for (int i = 0; i < this.dgvSelectMake.Rows.Count; i++)
		{
			if ((int)this.dgvSelectMake.Rows[i].Cells[this.colMake01.Name].Value == num)
			{
				result = this.dgvSelectMake.Rows[i].Cells[this.colMake02.Name].Value.ToString();
				return result;
			}
		}
		return result;
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x0007C558 File Offset: 0x0007A758
	private void method_12(string string_10, string string_11, string string_12, string string_13, byte byte_0, int int_1, int int_2)
	{
		int num = GClass3.smethod_1();
		if (!GClass55.smethod_5(string_10))
		{
			bool flag = GClass61.smethod_36() == 2 || GClass61.smethod_36() == 3 || GClass61.smethod_36() == 4 || GClass61.smethod_36() == 5 || GClass61.smethod_36() == 6 || GClass61.smethod_36() == 7;
			bool flag2 = GClass61.smethod_36() == 1 || GClass61.smethod_36() == 4 || GClass61.smethod_36() == 6;
			this.string_4 = GClass62.smethod_1("1095");
			if (string_10 == "BCAN" && !flag)
			{
				this.string_4 = GClass62.smethod_1("1061");
			}
			if ((string_10 == "KWP71" || string_10 == "ISO9141" || string_10 == "KW01") && !flag2)
			{
				this.string_4 = GClass62.smethod_1("1062");
			}
			if ((string_10 == "BCAN29" || string_10 == "CCAN29") && !flag)
			{
				this.string_4 = GClass62.smethod_1("1061");
			}
			while (2000 + num > GClass3.smethod_1())
			{
				Thread.Sleep(100);
			}
			base.Invoke(new FormMain.Delegate6(this.method_36), new object[]
			{
				true
			});
		}
		else
		{
			string text = "70";
			if (string_10 == "BCAN")
			{
				text = "6E";
			}
			else if (string_10 == "BCAN29")
			{
				text = "19";
			}
			else if (string_10 == "CCAN29")
			{
				text = "6E";
			}
			else if (int_1 == 0)
			{
				text = "70";
			}
			else if (int_1 == 9)
			{
				text = "70";
			}
			else if (int_2 == 0)
			{
				text = "70";
			}
			else if (int_2 == 1)
			{
				text = "10";
			}
			else if (int_2 == 3)
			{
				text = "30";
			}
			else if (int_2 == 7)
			{
				text = "70";
			}
			else if (int_2 == 9)
			{
				text = "90";
			}
			else if (int_2 == 11)
			{
				text = "B0";
			}
			else if (int_2 == 12)
			{
				text = "C0";
			}
			else if (int_2 == 13)
			{
				text = "D0";
			}
			if (string_11.StartsWith("PROXI") && string_10 == "BCAN")
			{
				this.gclass19_0 = new GClass50(byte_0, string_13, this.list_3, this.list_0);
			}
			else if (string_11.StartsWith("PROXI") && string_10 == "BCAN29")
			{
				this.gclass19_0 = new GClass45(byte_0, string_13, this.list_3, this.list_0);
			}
			else
			{
				this.gclass19_0 = GClass19.smethod_0(string_10, string_13, byte_0, this.list_3, this.list_0, text);
			}
			this.gclass19_0.method_13(string_11);
			this.gclass19_0.method_16(new GDelegate3(this.method_35));
			this.gclass19_0.method_14(new GDelegate4(this.method_33));
			this.gclass19_0.method_18(new GDelegate5(this.method_29));
			this.gclass19_0.method_20(new GDelegate5(this.method_30));
			bool flag3;
			if (GClass61.smethod_36() != 4)
			{
				if (GClass61.smethod_36() != 5)
				{
					flag3 = true;
					goto IL_382;
				}
			}
			flag3 = GClass3.bool_0;
			IL_382:
			if (!flag3)
			{
				if (GClass61.smethod_36() == 5)
				{
					for (int i = 0; i < 30; i++)
					{
						if (this.formNotify_0 == null || this.formNotify_0.method_0())
						{
							base.Invoke(new FormMain.Delegate6(this.method_36), new object[]
							{
								true
							});
							this.string_4 = GClass62.smethod_1("6060");
							return;
						}
						Thread.Sleep(100);
					}
				}
				if (!GClass55.smethod_3() && this.formNotify_0 != null)
				{
					GClass3.bool_13 = false;
					this.formNotify_0.method_8(GClass62.smethod_1("1070"), GClass62.smethod_1("1074"), GClass62.smethod_1("1075"), false, 0);
					int i = 1200;
					while (!GClass3.bool_13 && i > 0)
					{
						i--;
						Thread.Sleep(100);
					}
					if (i == 0)
					{
						base.Invoke(new FormMain.Delegate6(this.method_36), new object[]
						{
							true
						});
						this.string_4 = "Timeout!";
						return;
					}
					GClass3.bool_13 = false;
					this.formNotify_0.method_8(GClass62.smethod_1("1051"), GClass62.smethod_1("1052"), GClass62.smethod_1("1053"), false, 0);
					GClass55.smethod_1(true);
					int num2 = 10;
					if (GClass61.smethod_36() == 5)
					{
						num2 = 40;
					}
					for (int j = 0; j < num2; j++)
					{
						if (this.formNotify_0 == null || this.formNotify_0.method_0())
						{
							base.Invoke(new FormMain.Delegate6(this.method_36), new object[]
							{
								true
							});
							this.string_4 = GClass62.smethod_1("6060");
							return;
						}
						Thread.Sleep(100);
					}
				}
			}
			if (GClass61.smethod_36() == 6 && !GClass3.bool_0)
			{
				for (int i = 0; i < 15; i++)
				{
					if (this.formNotify_0 == null || this.formNotify_0.method_0())
					{
						base.Invoke(new FormMain.Delegate6(this.method_36), new object[]
						{
							true
						});
						this.string_4 = GClass62.smethod_1("6060");
						return;
					}
					Thread.Sleep(100);
				}
				GClass55.smethod_6();
				bool flag4;
				if (!(flag4 = GClass16.smethod_33()))
				{
					GClass3.bool_1 = !flag4;
				}
			}
			this.gclass19_0.vmethod_1((GEnum0)0);
		}
	}

	// Token: 0x060003D9 RID: 985 RVA: 0x0007CB80 File Offset: 0x0007AD80
	private void buttonConnect_Click(object sender, EventArgs e)
	{
		FormMain.Class14 @class = new FormMain.Class14();
		@class.formMain_0 = this;
		if (this.gclass19_0 == null && this.formNotify_0 == null)
		{
			if (sender != null && e != null)
			{
				GClass3.bool_0 = (Control.ModifierKeys == Keys.Control);
			}
			@class.string_0 = this.dgvSelectECU.SelectedRows[0].Cells[this.colSystem05.Name].Value.ToString();
			@class.string_1 = this.dgvSelectECU.SelectedRows[0].Cells[this.colSystem04.Name].Value.ToString();
			@class.string_2 = this.dgvSelectECU.SelectedRows[0].Cells[this.colSystem06.Name].Value.ToString();
			@class.string_3 = this.dgvSelectECU.SelectedRows[0].Cells[this.colSystem08.Name].Value.ToString();
			@class.byte_0 = byte.Parse(@class.string_2, NumberStyles.HexNumber);
			int num = GClass16.smethod_5(this.dgvSelectECU.SelectedRows[0].Cells[this.colSystem10.Name].Value.ToString());
			@class.int_0 = 0;
			@class.int_1 = 0;
			int i = 9;
			while (i > 0)
			{
				if (num < 100 * i)
				{
					i--;
				}
				else
				{
					@class.int_0 = i;
					@class.int_1 = num - 100 * i;
					IL_1A5:
					if (GClass61.smethod_45())
					{
						bool flag = true;
						i = 0;
						while (i < 4)
						{
							if (GClass61.smethod_30(i) <= 0 || GClass61.smethod_30(i) == 6)
							{
								i++;
							}
							else
							{
								flag = false;
								IL_1DD:
								string a = string.Empty;
								if (@class.int_0 == 1 && !flag)
								{
									a = string.Format(GClass62.smethod_1("1041"), @class.int_1);
								}
								else if (@class.int_0 == 2 && !flag)
								{
									a = string.Format(GClass62.smethod_1("1042"), @class.int_1);
								}
								else if (@class.int_0 == 3 && !flag)
								{
									a = string.Format(GClass62.smethod_1("1043"), @class.int_1);
								}
								else if (@class.int_0 == 9)
								{
									a = GClass62.smethod_1("1044");
								}
								string empty = string.Empty;
								if (!(a != string.Empty))
								{
									goto IL_2E5;
								}
								this.formNotify_0 = new FormNotify(a, empty, GClass62.smethod_1("1055"), true, 0);
								this.formNotify_0.ShowDialog();
								if (!this.formNotify_0.method_1())
								{
									this.formNotify_0 = null;
									return;
								}
								this.formNotify_0 = null;
								goto IL_2E5;
							}
						}
						goto IL_1DD;
					}
					IL_2E5:
					this.buttonConnect.Enabled = false;
					this.buttonConnectAuto.Enabled = false;
					this.buttonScanDTC.Enabled = false;
					this.buttonDisconnect.Enabled = true;
					this.buttonSettings.Enabled = false;
					this.btnErrorsClear.Enabled = false;
					this.tsslConnProblem.Visible = false;
					GClass3.smethod_4();
					GClass61.smethod_58((int)this.dgvSelectECU.SelectedRows[0].Cells[this.colSystem01.Name].Value);
					GClass3.string_2 = this.method_11() + " " + this.dgvSelectModel.SelectedRows[0].Cells[this.colModel03.Name].Value.ToString();
					GClass3.string_3 = this.dgvSelectECU.SelectedRows[0].Cells[this.colSystem03.Name].Value.ToString();
					this.ttslMsg.Text = GClass62.smethod_1("1050");
					GClass3.smethod_2("LOAD DATA 1", 0);
					this.method_6();
					GClass3.smethod_2("LOAD DATA 2", 0);
					this.string_4 = string.Empty;
					this.formNotify_0 = new FormNotify(GClass62.smethod_1("1051"), GClass62.smethod_1("1052"), GClass62.smethod_1("1053"), false, 0);
					Thread thread = new Thread(new ThreadStart(@class.method_0));
					thread.Start();
					this.formNotify_0.ShowDialog();
					this.formNotify_0 = null;
					if (this.gclass19_0 != null && this.gclass19_0.method_10())
					{
						GClass61.smethod_68((int)this.dgvSelectModel.SelectedRows[0].Cells[this.colModel02.Name].Value);
						if (@class.string_1.StartsWith("PROXI"))
						{
							this.dgvInfo.DataSource = GClass16.smethod_30(this.list_3);
							this.dgvInfo.Columns[2].Visible = false;
						}
						else
						{
							this.dgvInfo.Columns[2].Visible = true;
						}
						this.dgvInfo.Refresh();
						this.lblSelectedInfo.Text = GClass3.string_2;
						this.lblSelectedInfo2.Text = GClass3.string_3;
						if (this.tabControlMain.SelectedTab == this.tabPageSelect)
						{
							this.method_10(true);
							this.tabControlMain.TabPages.Remove(this.tabPageSelect);
							this.method_9(this.tabPageInfo);
							if (this.list_4.Count > 0 && (GClass3.bool_6 || GClass3.bool_3))
							{
								this.method_9(this.tabPageErrors);
								this.dgvErrors.DataSource = GClass16.smethod_31(new List<GClass64>());
								this.dgvErrors.Invalidate();
								this.list_8 = null;
							}
							if (this.list_0.Count > 0 && (GClass3.bool_6 || GClass3.bool_3))
							{
								this.method_9(this.tabPageParams);
							}
							this.method_9(this.tabPageGraph);
							if (this.list_1.Count > 0 && (GClass3.bool_6 || GClass3.bool_3))
							{
								this.method_9(this.tabPageActuators);
							}
							if (this.list_2.Count > 0 && (GClass3.bool_6 || GClass3.bool_3))
							{
								this.method_9(this.tabPageAdjustments);
							}
							this.method_9(this.tabPageLog);
							this.ttslMsg.Text = GClass3.string_2 + " / " + GClass3.string_3;
							GClass3.smethod_2(DateTime.Now.ToString(), 2);
							GClass3.smethod_2("CONNECTED TO: ", 2);
							GClass3.smethod_2(GClass3.string_2, 2);
							GClass3.smethod_2(GClass3.string_3, 2);
							if (GClass3.bool_0)
							{
								GClass3.smethod_2("SIMULATION MODE!!!", 2);
							}
							GClass3.smethod_2("--------------------------------------------------------------", 2);
							GClass3.smethod_2(string.Empty, 2);
						}
						for (i = 0; i < this.list_3.Count; i++)
						{
							GClass3.smethod_2(this.list_3[i].string_0 + ": " + this.list_3[i].method_0(), 2);
						}
						bool flag2 = false;
						i = 0;
						while (i < this.list_6.Count)
						{
							if (!(this.list_6[i] == this.gclass19_0.method_4()))
							{
								i++;
							}
							else
							{
								flag2 = true;
								IL_7B1:
								if (@class.string_1.StartsWith("CANINFO") || @class.string_1.StartsWith("PROXI") || this.gclass19_0.method_4() == string.Empty)
								{
									flag2 = true;
								}
								this.timer_0.Enabled = true;
								if (this.list_4.Count > 0)
								{
									this.timer_1.Enabled = true;
								}
								this.lblISOError.Visible = !flag2;
								if (!flag2)
								{
									GClass3.smethod_2(this.lblISOError.Text, 2);
								}
								GClass3.smethod_2(string.Empty, 2);
								if (!flag2)
								{
									this.formNotify_0 = new FormNotify(GClass62.smethod_1("1054"), string.Empty, GClass62.smethod_1("1055"), true, 0);
									this.formNotify_0.ShowDialog();
									if (this.formNotify_0 != null && this.formNotify_0.method_2())
									{
										GClass3.smethod_2("Terminate 3", 1);
										this.gclass19_0.method_22(false);
									}
									this.formNotify_0 = null;
									if (GClass3.bool_0)
									{
										this.gclass19_0.method_3(25);
									}
								}
								if (!GClass3.bool_6 && !GClass3.bool_3)
								{
									this.formNotify_0 = new FormNotify("FREE VERSION RESTRICTION", "This module requires REGISTERED version!", "You can run it in 'simulation' (CTRL+F10) mode only!", true, 4000);
									this.formNotify_0.ShowDialog();
									GClass3.smethod_2("Terminate 9", 1);
									this.gclass19_0.method_22(false);
									this.formNotify_0 = null;
								}
								if (GClass3.bool_2 && GClass3.bool_1)
								{
									this.formNotify_0 = new FormNotify("CANtieCAR INTERFACE ERROR", "License validation failed!", "Please contact support@fiatecuscan.net for more information", true, 4000);
									this.formNotify_0.ShowDialog();
									GClass3.smethod_2("Terminate 9", 1);
									this.gclass19_0.method_22(false);
									this.formNotify_0 = null;
								}
								else if (@class.string_1.StartsWith("PROXI") && @class.string_0 == "BCAN")
								{
									if (((GClass50)this.gclass19_0).int_5 > 2)
									{
										GClass3.smethod_2(GClass62.smethod_1("1070") + ": " + GClass62.smethod_1("1081"), 2);
										this.formNotify_0 = new FormNotify(GClass62.smethod_1("1070"), GClass62.smethod_1("1081"), GClass62.smethod_1("1059"), true, 0);
										this.formNotify_0.ShowDialog();
										this.formNotify_0 = null;
									}
									if (((GClass50)this.gclass19_0).int_6 > 2)
									{
										GClass3.smethod_2(GClass62.smethod_1("1070") + ": " + GClass62.smethod_1("1082"), 2);
										this.formNotify_0 = new FormNotify(GClass62.smethod_1("1070"), GClass62.smethod_1("1082"), GClass62.smethod_1("1059"), true, 0);
										this.formNotify_0.ShowDialog();
										this.formNotify_0 = null;
									}
									if (((GClass50)this.gclass19_0).bool_5)
									{
										GClass3.smethod_2(GClass62.smethod_1("1070") + ": " + GClass62.smethod_1("1083"), 2);
										this.formNotify_0 = new FormNotify(GClass62.smethod_1("1070"), GClass62.smethod_1("1083"), GClass62.smethod_1("1059"), true, 0);
										this.formNotify_0.ShowDialog();
										this.formNotify_0 = null;
									}
								}
								else if (@class.string_1.StartsWith("PROXI") && @class.string_0 == "BCAN29")
								{
									if (((GClass45)this.gclass19_0).int_5 > 2)
									{
										GClass3.smethod_2(GClass62.smethod_1("1070") + ": " + GClass62.smethod_1("1081"), 2);
										this.formNotify_0 = new FormNotify(GClass62.smethod_1("1070"), GClass62.smethod_1("1081"), GClass62.smethod_1("1059"), true, 0);
										this.formNotify_0.ShowDialog();
										this.formNotify_0 = null;
									}
									if (((GClass45)this.gclass19_0).int_6 > 2)
									{
										GClass3.smethod_2(GClass62.smethod_1("1070") + ": " + GClass62.smethod_1("1082"), 2);
										this.formNotify_0 = new FormNotify(GClass62.smethod_1("1070"), GClass62.smethod_1("1082"), GClass62.smethod_1("1059"), true, 0);
										this.formNotify_0.ShowDialog();
										this.formNotify_0 = null;
									}
									if (((GClass45)this.gclass19_0).bool_5)
									{
										GClass3.smethod_2(GClass62.smethod_1("1070") + ": " + GClass62.smethod_1("1083"), 2);
										this.formNotify_0 = new FormNotify(GClass62.smethod_1("1070"), GClass62.smethod_1("1083"), GClass62.smethod_1("1059"), true, 0);
										this.formNotify_0.ShowDialog();
										this.formNotify_0 = null;
									}
								}
								if (GClass3.int_8 != -1)
								{
									this.tabControlMain.SelectedTab = this.tabPageParams;
									this.method_16(GClass3.int_8);
									return;
								}
								return;
							}
						}
						goto IL_7B1;
					}
					this.method_9(this.tabPageLog);
					this.formNotify_0 = new FormNotify(GClass62.smethod_1("1056"), this.string_4, GClass62.smethod_1("1057"), false, 4000);
					this.formNotify_0.ShowDialog();
					this.formNotify_0 = null;
					return;
				}
			}
			goto IL_1A5;
		}
	}

	// Token: 0x060003DA RID: 986 RVA: 0x0000344B File Offset: 0x0000164B
	private void buttonDisconnect_Click(object sender, EventArgs e)
	{
		GClass3.smethod_2("Terminate 2", 1);
		this.gclass19_0.vmethod_2(false, true);
		this.ttslMsg.Text = string.Empty;
	}

	// Token: 0x060003DB RID: 987 RVA: 0x0007D8D0 File Offset: 0x0007BAD0
	private void buttonSettings_Click(object sender, EventArgs e)
	{
		string a = GClass61.smethod_12();
		string a2 = GClass16.smethod_32(GClass61.smethod_18()) + GClass16.smethod_32(GClass61.smethod_20());
		FormSettings formSettings = new FormSettings();
		if (formSettings.ShowDialog() == DialogResult.OK)
		{
			string b = GClass16.smethod_32(GClass61.smethod_18()) + GClass16.smethod_32(GClass61.smethod_20());
			if (a != GClass61.smethod_12() || a2 != b)
			{
				this.method_4();
			}
		}
		this.timer_2.Interval = ((GClass61.smethod_51() == 0) ? 180 : ((GClass61.smethod_51() == 0) ? 500 : 800));
	}

	// Token: 0x060003DC RID: 988 RVA: 0x0007D97C File Offset: 0x0007BB7C
	private void method_13()
	{
		if (this.gclass19_0 != null && this.gclass19_0.method_10() && !this.bool_2)
		{
			this.bool_2 = true;
			if (this.list_8 == null)
			{
				this.string_5 = string.Empty;
			}
			try
			{
				List<GClass64> list = this.gclass19_0.vmethod_3();
				if (list == null)
				{
					GClass3.smethod_2("ERROR: Empty error list", 0);
				}
				string text = string.Empty;
				if (list != null)
				{
					foreach (GClass64 gclass in list)
					{
						text += gclass.string_0;
					}
				}
				if (this.string_5 != text || this.string_5 == string.Empty)
				{
					this.gclass19_0.vmethod_4(list, this.list_5);
				}
				this.list_8 = list;
			}
			finally
			{
				this.bool_2 = false;
			}
		}
	}

	// Token: 0x060003DD RID: 989 RVA: 0x0007DAA4 File Offset: 0x0007BCA4
	private void timer_1_Tick(object sender, EventArgs e)
	{
		if (this.tabControlMain.SelectedTab == this.tabPageErrors && this.gclass19_0 != null && this.gclass19_0.method_10())
		{
			string text = string.Empty;
			if (this.list_8 != null)
			{
				foreach (GClass64 gclass in this.list_8)
				{
					text += gclass.string_0;
				}
			}
			if (this.list_8 == null)
			{
				this.btnErrorsClear.Enabled = false;
			}
			else if (text != this.string_5 || this.string_5 == string.Empty)
			{
				foreach (GClass64 gclass2 in this.list_8)
				{
					foreach (GClass64 gclass3 in this.list_4)
					{
						if (gclass3.string_0 == gclass2.string_0)
						{
							if (gclass2.string_1 != string.Empty)
							{
								GClass64 gclass4 = gclass2;
								gclass4.string_1 += " - ";
							}
							GClass64 gclass5 = gclass2;
							gclass5.string_1 += GClass62.smethod_4(gclass3.int_0, gclass3.string_1);
							gclass2.string_2 = gclass3.string_2 + Environment.NewLine + gclass2.string_2;
							break;
						}
					}
				}
				if (this.list_8.Count == 0)
				{
					this.list_8.Add(new GClass64("0000", GClass62.smethod_1("3003"), GClass62.smethod_1("3004")));
					this.btnErrorsClear.Enabled = false;
					if (!this.bool_1)
					{
						GClass3.smethod_2(GClass62.smethod_1("3049"), 2);
						GClass3.smethod_2(GClass62.smethod_1("3003"), 2);
						GClass3.smethod_2(string.Empty, 2);
						this.bool_1 = true;
					}
				}
				else
				{
					this.btnErrorsClear.Enabled = true;
					GClass3.smethod_2(GClass62.smethod_1("3049"), 2);
					for (int i = 0; i < this.list_8.Count; i++)
					{
						GClass3.smethod_2(i + 1 + ": " + this.list_8[i].method_0(), 2);
						if (this.list_8[i].string_3 != string.Empty)
						{
							GClass3.smethod_2(this.list_8[i].string_3, 2);
						}
						GClass3.smethod_2(this.list_8[i].string_2, 2);
					}
					GClass3.smethod_2(string.Empty, 2);
					this.bool_1 = false;
				}
				this.string_5 = text;
				this.dgvErrors.DataSource = GClass16.smethod_31(this.list_8);
				this.dgvErrors.Invalidate();
			}
			else
			{
				this.btnErrorsClear.Enabled = (this.list_8.Count > 0);
			}
			new Thread(new ThreadStart(this.method_13)).Start();
		}
	}

	// Token: 0x060003DE RID: 990 RVA: 0x0007DE44 File Offset: 0x0007C044
	private void btnErrorsClear_Click(object sender, EventArgs e)
	{
		this.btnErrorsClear.Enabled = false;
		this.formNotify_0 = new FormNotify(GClass62.smethod_1("3050"), GClass62.smethod_1("1052"), string.Empty, false, 0);
		GClass3.smethod_2(GClass62.smethod_1("3050") + "...", 2);
		GClass3.smethod_2(string.Empty, 2);
		this.bool_1 = false;
		new Thread(new ThreadStart(this.method_14)).Start();
		this.formNotify_0.ShowDialog();
		this.formNotify_0 = null;
	}

	// Token: 0x060003DF RID: 991 RVA: 0x00003475 File Offset: 0x00001675
	private void method_14()
	{
		Thread.Sleep(500);
		this.gclass19_0.vmethod_5();
		Thread.Sleep(900);
		base.Invoke(new FormMain.Delegate2(this.method_28), new object[0]);
	}

	// Token: 0x060003E0 RID: 992 RVA: 0x0007DED8 File Offset: 0x0007C0D8
	private void dgvErrors_SelectionChanged(object sender, EventArgs e)
	{
		if (this.dgvErrors.SelectedRows.Count > 0)
		{
			this.tbErrorsDesc.Text = ((TableDataRowE)this.dgvErrors.SelectedRows[0].DataBoundItem).getDataItem().method_2();
			this.tbErrorsDetails.Text = ((TableDataRowE)this.dgvErrors.SelectedRows[0].DataBoundItem).getDataItem().string_3;
		}
		else
		{
			this.tbErrorsDesc.Text = string.Empty;
			this.tbErrorsDetails.Text = string.Empty;
		}
	}

	// Token: 0x060003E1 RID: 993 RVA: 0x0007DF80 File Offset: 0x0007C180
	private void dgvParams_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == 0 && e.RowIndex >= 0)
		{
			TableDataRowP tableDataRowP = (TableDataRowP)this.dgvParams.Rows[e.RowIndex].DataBoundItem;
			if (tableDataRowP.Selected || GClass3.bool_3)
			{
				tableDataRowP.Selected = !tableDataRowP.Selected;
			}
			else
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
					MessageBox.Show(GClass62.smethod_1("1073"), GClass62.smethod_1("1070"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			if (this.chkParamsAutoUp.Enabled && this.chkParamsAutoUp.Checked)
			{
				int firstDisplayedScrollingRowIndex = this.dgvParams.FirstDisplayedScrollingRowIndex;
				this.btnParamsArrange_Click(null, null);
				if (this.dgvParams.Rows.Count > e.RowIndex)
				{
					this.dgvParams.Rows[e.RowIndex].Selected = true;
					this.dgvParams.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
					this.dgvParams.CurrentCell = this.dgvParams.Rows[e.RowIndex].Cells[0];
				}
			}
			else
			{
				this.dgvParams.UpdateCellValue(0, this.dgvParams.SelectedRows[0].Index);
			}
		}
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x0007E130 File Offset: 0x0007C330
	private void dgvParams_KeyUp(object sender, KeyEventArgs e)
	{
		if (!e.Alt && !e.Control && e.KeyCode == Keys.Space)
		{
			TableDataRowP tableDataRowP = (TableDataRowP)this.dgvParams.SelectedRows[0].DataBoundItem;
			if (tableDataRowP.Selected || GClass3.bool_3)
			{
				tableDataRowP.Selected = !tableDataRowP.Selected;
			}
			else
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
					MessageBox.Show(GClass62.smethod_1("1073"), GClass62.smethod_1("1070"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			if (this.chkParamsAutoUp.Enabled && this.chkParamsAutoUp.Checked)
			{
				int firstDisplayedScrollingRowIndex = this.dgvParams.FirstDisplayedScrollingRowIndex;
				int index = this.dgvParams.SelectedRows[0].Index;
				this.btnParamsArrange_Click(null, null);
				if (this.dgvParams.Rows.Count > index)
				{
					this.dgvParams.Rows[index].Selected = true;
					this.dgvParams.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
					this.dgvParams.CurrentCell = this.dgvParams.Rows[index].Cells[0];
				}
			}
			else
			{
				this.dgvParams.UpdateCellValue(0, this.dgvParams.SelectedRows[0].Index);
			}
			e.Handled = true;
		}
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x0007E2F8 File Offset: 0x0007C4F8
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (this.gclass19_0 == null || !this.gclass19_0.method_10())
		{
			this.timer_0.Enabled = false;
			this.timer_1.Enabled = false;
			GClass3.smethod_2("PMT: Connection terminated!", 1);
		}
		else
		{
			if (this.gclass19_0.method_2() > 0)
			{
				if (!this.tsslConnProblem.Visible)
				{
					this.tsslConnProblem.Visible = true;
				}
				if (this.tsslConnProblem.ForeColor == Color.Red)
				{
					this.tsslConnProblem.ForeColor = Color.White;
				}
				else
				{
					this.tsslConnProblem.ForeColor = Color.Red;
				}
				GClass19 gclass = this.gclass19_0;
				gclass.method_3(gclass.method_2() - 1);
			}
			else if (this.tsslConnProblem.Visible)
			{
				this.tsslConnProblem.Visible = false;
			}
			if (this.tabControlMain.SelectedTab == this.tabPageParams && (this.gclass19_0.method_0() || GClass3.int_3 + 2000 < GClass3.smethod_1()))
			{
				int num = 100;
				while (GClass61.smethod_51() == 2 && GClass61.smethod_36() == 1 && this.gclass19_0.method_11() && num > 0)
				{
					Thread.Sleep(1);
					num--;
				}
				bool flag = this.gclass19_0.method_0();
				this.gclass19_0.method_1(false);
				GClass3.int_3 = GClass3.smethod_1();
				bool flag2 = false;
				for (int i = 0; i < this.dgvParams.Rows.Count; i++)
				{
					if (((TableDataRowP)this.dgvParams.Rows[i].DataBoundItem).Selected)
					{
						this.dgvParams.UpdateCellValue(2, i);
						flag2 = true;
					}
				}
				if (flag2 && flag)
				{
					GClass3.smethod_2(GClass62.smethod_1("4050"), 2);
					for (int i = 0; i < this.list_0.Count; i++)
					{
						if (this.list_0[i].bool_0)
						{
							GClass3.smethod_2(string.Concat(new string[]
							{
								this.list_0[i].string_0,
								this.string_6,
								this.list_0[i].method_0(),
								this.string_7,
								this.list_0[i].string_3
							}), 2);
						}
					}
					GClass3.smethod_2(this.string_8, 2);
				}
				if (GClass3.bool_7 && this.gclass19_0.method_6() != this.string_8)
				{
					this.lblDTCsPresent.Visible = true;
					this.lblDTCsPresent.Text = GClass62.smethod_1(this.string_9) + Environment.NewLine + this.gclass19_0.method_6();
				}
				else
				{
					this.lblDTCsPresent.Visible = false;
				}
			}
			if (this.tabControlMain.SelectedTab == this.tabPageActuators && this.gclass19_0.method_0())
			{
				this.gclass19_0.method_1(false);
				this.dgvActParams.Invalidate();
			}
		}
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x000026DC File Offset: 0x000008DC
	private void method_15()
	{
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x0007E63C File Offset: 0x0007C83C
	private void dgvParams_SelectionChanged(object sender, EventArgs e)
	{
		if (this.dgvParams.SelectedRows.Count > 0)
		{
			this.tbParamDescription.Text = ((TableDataRowP)this.dgvParams.SelectedRows[0].DataBoundItem).getDataItem().string_1;
		}
		else
		{
			this.tbParamDescription.Text = string.Empty;
		}
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x0007E6A4 File Offset: 0x0007C8A4
	private void dgvParams_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
	{
		if (!((TableDataRowP)this.dgvParams.Rows[e.RowIndex].DataBoundItem).Selected)
		{
			this.dgvParams.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Navy;
			this.dgvParams.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Navy;
		}
		else
		{
			this.dgvParams.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
			this.dgvParams.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
		}
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x0007E770 File Offset: 0x0007C970
	private void btnParamsArrange_Click(object sender, EventArgs e)
	{
		List<TableDataRowP> list = new List<TableDataRowP>();
		foreach (GClass58 gclass in this.list_0)
		{
			if (gclass.bool_0)
			{
				list.Add(new TableDataRowP(gclass));
			}
		}
		foreach (GClass58 gclass in this.list_0)
		{
			if (!gclass.bool_0)
			{
				list.Add(new TableDataRowP(gclass));
			}
		}
		this.dgvParams.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		this.dgvParams.DataSource = list;
		this.dgvParams.Invalidate();
		this.dgvParams.Focus();
		this.dgvParams.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
	}

	// Token: 0x060003E8 RID: 1000 RVA: 0x0007E868 File Offset: 0x0007CA68
	private void btnArrangeName_Click(object sender, EventArgs e)
	{
		List<TableDataRowP> list = GClass16.smethod_30(this.list_0);
		List<TableDataRowP> list2 = list;
		if (FormMain.comparison_0 == null)
		{
			FormMain.comparison_0 = new Comparison<TableDataRowP>(FormMain.smethod_2);
		}
		list2.Sort(FormMain.comparison_0);
		this.dgvParams.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		this.dgvParams.DataSource = list;
		this.dgvParams.Invalidate();
		this.dgvParams.Focus();
		this.dgvParams.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
	}

	// Token: 0x060003E9 RID: 1001 RVA: 0x0007E8E0 File Offset: 0x0007CAE0
	private void btnArrangeUnits_Click(object sender, EventArgs e)
	{
		List<TableDataRowP> list = GClass16.smethod_30(this.list_0);
		List<TableDataRowP> list2 = list;
		if (FormMain.comparison_1 == null)
		{
			FormMain.comparison_1 = new Comparison<TableDataRowP>(FormMain.smethod_3);
		}
		list2.Sort(FormMain.comparison_1);
		this.dgvParams.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		this.dgvParams.DataSource = list;
		this.dgvParams.Invalidate();
		this.dgvParams.Focus();
		this.dgvParams.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x0007E958 File Offset: 0x0007CB58
	private void buttonSelectAll_Click(object sender, EventArgs e)
	{
		if (GClass3.bool_3)
		{
			for (int i = 0; i < this.list_0.Count; i++)
			{
				this.list_0[i].bool_0 = true;
			}
			this.dgvParams.Refresh();
		}
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x0007E9A4 File Offset: 0x0007CBA4
	private void buttonSelectNone_Click(object sender, EventArgs e)
	{
		if (GClass3.bool_3)
		{
			for (int i = 0; i < this.list_0.Count; i++)
			{
				this.list_0[i].bool_0 = false;
			}
			this.dgvParams.Refresh();
		}
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x0007E9F0 File Offset: 0x0007CBF0
	private void method_16(int int_1)
	{
		int[] array = GClass61.smethod_85(int_1);
		if (GClass3.bool_3)
		{
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
			this.btnParamsArrange_Click(null, null);
		}
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x0007EA70 File Offset: 0x0007CC70
	private void method_17(int int_1)
	{
		List<int> list = new List<int>();
		if (GClass3.bool_3)
		{
			for (int i = 0; i < this.list_0.Count; i++)
			{
				if (this.list_0[i].bool_0)
				{
					list.Add(this.list_0[i].int_2);
				}
			}
			GClass61.smethod_86(int_1, list.ToArray());
		}
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x0007EADC File Offset: 0x0007CCDC
	private void btnTemplateLoad_Click(object sender, EventArgs e)
	{
		List<SimpleValueData> list = new List<SimpleValueData>();
		string text = string.Empty;
		for (int i = 0; i < 10; i++)
		{
			int[] array = GClass61.smethod_85(i);
			text = string.Empty;
			int j = 0;
			IL_91:
			while (j < this.list_0.Count)
			{
				for (int k = 0; k < array.Length; k++)
				{
					if (array[k] == this.list_0[j].int_2)
					{
						if (text.Length > 0)
						{
							text += "\r\n";
						}
						text += this.list_0[j].string_0;
						IL_8B:
						j++;
						goto IL_91;
					}
				}
				goto IL_8B;
			}
			if (text == string.Empty)
			{
				text = "N/D";
			}
			list.Add(new SimpleValueData(i, text));
		}
		if (GClass3.bool_3)
		{
			FormTemplates formTemplates = new FormTemplates(list);
			formTemplates.ShowDialog();
		}
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x000034AF File Offset: 0x000016AF
	private void chkMonitorErrors_CheckedChanged(object sender, EventArgs e)
	{
		GClass3.bool_7 = this.chkMonitorErrors.Checked;
	}

	// Token: 0x060003F0 RID: 1008 RVA: 0x0007EBD4 File Offset: 0x0007CDD4
	private void buttonGraphStart_Click(object sender, EventArgs e)
	{
		if (GClass3.bool_4)
		{
			this.method_20();
			this.method_18();
			if (this.cbGraphFiles.Items.Count > 1)
			{
				this.cbGraphFiles.SelectedIndex = this.cbGraphFiles.Items.Count - 2;
			}
		}
		else
		{
			GClass3.int_4 = GClass3.int_1[this.cbGraphRate.SelectedIndex];
			this.method_19(true, false);
			GClass3.smethod_0().string_0 = this.tbRecordingName.Text;
			this.cbGraphFiles.Items[this.cbGraphFiles.Items.Count - 1] = GClass3.smethod_0().string_0;
			this.cbGraphFiles.SelectedIndex = this.cbGraphFiles.Items.Count - 1;
			this.tbRecordingName.Text = string.Empty;
			this.tableLayoutPanelGraphs.Invalidate();
			GClass3.bool_4 = true;
			GClass3.int_4 = GClass3.int_1[this.cbGraphRate.SelectedIndex];
			this.method_18();
		}
	}

	// Token: 0x060003F1 RID: 1009 RVA: 0x0007ECF0 File Offset: 0x0007CEF0
	private void method_18()
	{
		this.buttonGraphStart.Text = (GClass3.bool_4 ? GClass62.smethod_1("5006") : GClass62.smethod_1("5005"));
		this.buttonGraphStart.Enabled = (((!GClass3.bool_4 && GClass3.smethod_0().list_8.Count > 0) || GClass3.bool_4) && this.gclass19_0 != null);
		this.cbGraphRate.Enabled = (!GClass3.bool_4 && this.gclass19_0 != null);
		this.lblGraphStatus.Text = ((!GClass3.bool_4 || this.gclass19_0 == null) ? "Stopped" : "Recording ...");
		this.lblGraphStatus.ForeColor = ((!GClass3.bool_4 || this.gclass19_0 == null) ? Color.Red : Color.Green);
		this.btnExportGraph.Enabled = (GClass3.smethod_0() != null && !GClass3.bool_4 && GClass3.smethod_0().list_0.Count > 0 && GClass3.smethod_0().list_3.Count > 0);
		this.btnImportGraph.Enabled = !GClass3.bool_4;
		if (!GClass3.bool_4)
		{
			if (GClass3.smethod_0() != null)
			{
				this.lblGraphTime.Text = (GClass3.smethod_0().int_1 / 1000).ToString("F0");
			}
			else
			{
				this.lblGraphTime.Text = string.Empty;
			}
		}
		this.tbRecordingName.Enabled = !GClass3.bool_4;
		this.cbGraphFiles.Enabled = !GClass3.bool_4;
	}

	// Token: 0x060003F2 RID: 1010 RVA: 0x0007EE90 File Offset: 0x0007D090
	private void cbGraphScale_SelectedIndexChanged(object sender, EventArgs e)
	{
		float float_ = Convert.ToSingle(this.cbGraphScale.SelectedItem.ToString().Replace("x", string.Empty));
		for (int i = 0; i < this.tableLayoutPanelGraphs.Controls.Count; i++)
		{
			((GClass65)this.tableLayoutPanelGraphs.Controls[i]).method_2(float_);
		}
		this.tableLayoutPanelGraphs.Invalidate();
		this.tableLayoutPanelGraphs.Focus();
	}

	// Token: 0x060003F3 RID: 1011 RVA: 0x0007EF14 File Offset: 0x0007D114
	private void cbGraphRate_SelectedIndexChanged(object sender, EventArgs e)
	{
		GClass3.int_4 = GClass3.int_1[this.cbGraphRate.SelectedIndex];
		this.lblGraphTime.Text = string.Empty;
		this.btnExportGraph.Enabled = false;
		this.tableLayoutPanelGraphs.Invalidate();
		this.tableLayoutPanelGraphs.Focus();
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x0007EF6C File Offset: 0x0007D16C
	private void tableLayoutPanelGraphs_Paint(object sender, PaintEventArgs e)
	{
		for (int i = 0; i < this.tableLayoutPanelGraphs.Controls.Count; i++)
		{
			this.tableLayoutPanelGraphs.Controls[i].Invalidate();
		}
	}

	// Token: 0x060003F5 RID: 1013 RVA: 0x0007EFAC File Offset: 0x0007D1AC
	private void cbGraphCount_SelectedIndexChanged(object sender, EventArgs e)
	{
		int num = GClass16.smethod_5(this.cbGraphCount.SelectedItem);
		GClass0 gclass = GClass3.smethod_0();
		if (gclass != null)
		{
			gclass.int_2 = num;
		}
		this.tableLayoutPanelGraphParams.Refresh();
		this.tableLayoutPanelGraphs.Controls.Clear();
		this.tableLayoutPanelGraphs.RowStyles.Clear();
		this.tableLayoutPanelGraphs.RowCount = num;
		float float_ = Convert.ToSingle(this.cbGraphScale.SelectedItem.ToString().Replace("x", string.Empty));
		float height = (float)(100 / num);
		for (int i = 0; i < num; i++)
		{
			GClass65 gclass2 = new GClass65(i);
			gclass2.Dock = DockStyle.Fill;
			gclass2.method_2(float_);
			this.tableLayoutPanelGraphs.Controls.Add(gclass2);
			this.tableLayoutPanelGraphs.RowStyles.Add(new RowStyle(SizeType.Percent, height));
		}
		this.tableLayoutPanelGraphs.Focus();
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x0007F0A0 File Offset: 0x0007D2A0
	private void cbGraphFiles_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (GClass3.int_7 != this.cbGraphFiles.SelectedIndex)
		{
			GClass3.int_7 = this.cbGraphFiles.SelectedIndex;
			this.method_19(false, true);
			this.cbGraphCount.SelectedItem = string.Concat(GClass3.smethod_0().int_2);
			this.method_18();
			this.tableLayoutPanelGraphs.Invalidate();
		}
	}

	// Token: 0x060003F7 RID: 1015 RVA: 0x0007F10C File Offset: 0x0007D30C
	private void timer_2_Tick(object sender, EventArgs e)
	{
		if (this.int_0 > 0)
		{
			this.int_0--;
		}
		else
		{
			this.label10.Text = string.Empty;
		}
		if (!GClass3.bool_3 && GClass3.smethod_1() > 1201035)
		{
			this.timer_2.Enabled = false;
			this.timer_0.Enabled = false;
			MessageBox.Show(GClass62.smethod_1("1072"), GClass62.smethod_1("1070"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			base.Close();
		}
		if (!GClass3.bool_3 && GClass3.smethod_1() > 1135021 && !this.bool_3)
		{
			this.timer_2.Enabled = false;
			MessageBox.Show(GClass62.smethod_1("1071"), GClass62.smethod_1("1070"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			if (this.bool_3)
			{
				base.Close();
			}
			this.bool_3 = true;
			this.timer_2.Enabled = true;
		}
		if (this.tabControlMain.SelectedTab == this.tabPageGraph)
		{
			if (GClass3.bool_4 && this.gclass19_0 != null && this.gclass19_0.method_0())
			{
				this.lblGraphTime.Text = (GClass3.smethod_0().int_1 / 1000).ToString("F0");
				this.tableLayoutPanelGraphs.Invalidate();
				this.tableLayoutPanelGraphParams.Invalidate();
				GClass3.bool_5 = false;
			}
			if (this.gclass19_0 != null && this.gclass19_0.method_0())
			{
				this.gclass19_0.method_1(false);
				this.tableLayoutPanelGraphParams.Refresh();
			}
			if (GClass3.bool_5)
			{
				GClass3.bool_5 = false;
				this.tableLayoutPanelGraphs.Invalidate();
			}
		}
	}

	// Token: 0x060003F8 RID: 1016 RVA: 0x0007F2D4 File Offset: 0x0007D4D4
	private void method_19(bool bool_4, bool bool_5)
	{
		GClass3.bool_4 = false;
		if (bool_4)
		{
			List<GClass58> list = new List<GClass58>();
			for (int i = 0; i < this.list_0.Count; i++)
			{
				GClass58 gclass = this.list_0[i];
				if (gclass.bool_0)
				{
					list.Add(gclass);
					if ((!GClass3.bool_3 && list.Count > 4) || list.Count > 10)
					{
						break;
					}
				}
			}
			if (bool_5)
			{
				this.cbGraphRate.Items.Clear();
				this.cbGraphRate.Items.Add(60000 / GClass3.int_1[0] + "/min");
				int i = 1;
				while (i < GClass3.int_1.Length && GClass3.int_1[i] >= GClass3.int_5)
				{
					this.cbGraphRate.Items.Add(60000 / GClass3.int_1[i] + "/min");
					i++;
				}
				this.cbGraphRate.SelectedIndex = this.cbGraphRate.Items.Count - 1;
			}
			GClass3.int_7 = ((GClass3.list_1.Count == 0) ? 0 : (GClass3.list_1.Count - 1));
			if (GClass3.smethod_0() == null || GClass3.smethod_0().list_3.Count > 0)
			{
				if (!GClass3.bool_3 && GClass3.list_1.Count > 1)
				{
					GClass3.list_1.RemoveAt(0);
					this.cbGraphFiles.Items.RemoveAt(0);
				}
				GClass3.list_1.Add(new GClass0(this.tbRecordingName.Text, list));
				GClass3.int_7 = GClass3.list_1.Count - 1;
				this.cbGraphFiles.Items.Add("<new>");
				this.cbGraphFiles.SelectedIndex = this.cbGraphFiles.Items.Count - 1;
				if (this.tbRecordingName.Text == string.Empty)
				{
					this.tbRecordingName.Text = "File" + (GClass3.int_7 + 1);
				}
			}
			else
			{
				bool flag = true;
				GClass0 gclass2 = GClass3.list_1[GClass3.list_1.Count - 1];
				if (gclass2 != null && gclass2.list_8 != null && gclass2.list_8.Count == list.Count)
				{
					flag = false;
					int i = 0;
					while (i < gclass2.list_8.Count && i < list.Count)
					{
						if (gclass2.list_8[i].string_0 != list[i].string_0 || gclass2.list_8[i].int_2 != list[i].int_2 || gclass2.list_8[i].string_1 != list[i].string_1)
						{
							flag = true;
							break;
						}
						i++;
					}
				}
				if (flag)
				{
					GClass3.list_1[GClass3.list_1.Count - 1] = new GClass0(this.tbRecordingName.Text, list);
				}
				GClass3.int_7 = GClass3.list_1.Count - 1;
				this.cbGraphFiles.SelectedIndex = this.cbGraphFiles.Items.Count - 1;
			}
			int int_ = GClass16.smethod_5(this.cbGraphCount.SelectedItem);
			GClass3.smethod_0().int_2 = int_;
		}
		this.tableLayoutPanelGraphParams.Controls.Clear();
		this.tableLayoutPanelGraphParams.RowStyles.Clear();
		this.tableLayoutPanelGraphParams.RowCount = GClass3.smethod_0().list_8.Count;
		for (int i = 0; i < GClass3.smethod_0().list_8.Count; i++)
		{
			GClass15 gclass3 = new GClass15(i);
			gclass3.Dock = DockStyle.Fill;
			gclass3.ForeColor = GClass61.smethod_69(i);
			this.tableLayoutPanelGraphParams.Controls.Add(gclass3);
			this.tableLayoutPanelGraphParams.RowStyles.Add(new RowStyle(SizeType.Absolute, 80f));
		}
		this.tableLayoutPanelGraphs.Invalidate();
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x000034C1 File Offset: 0x000016C1
	private void method_20()
	{
		if (GClass3.bool_4)
		{
			GClass3.bool_4 = false;
			if (GClass3.bool_3)
			{
				this.method_21(string.Empty);
			}
			this.method_19(true, true);
		}
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x0007F740 File Offset: 0x0007D940
	private void method_21(string string_10)
	{
		GClass0 gclass = GClass3.smethod_0();
		if (gclass != null && gclass.list_3.Count != 0 && (!gclass.bool_0 || !(string_10 == string.Empty)))
		{
			gclass.bool_0 = true;
			string text = (GClass61.smethod_10() == "Tab") ? "\t" : GClass61.smethod_10();
			DateTime now = DateTime.Now;
			if (string_10 == string.Empty)
			{
				string_10 = string.Concat(new string[]
				{
					now.ToString("yyMMddHHmm"),
					"_",
					GClass3.string_2,
					"_",
					gclass.string_0
				});
				string_10 = GClass61.smethod_24() + "\\FESExp_" + string_10.Replace("\\", "_").Replace("/", "_").Replace(".", "_") + ".csv";
			}
			StreamWriter streamWriter;
			try
			{
				streamWriter = new StreamWriter(string_10, false, Encoding.Unicode);
			}
			catch (Exception)
			{
				return;
			}
			try
			{
				string text2 = "\"" + GClass62.smethod_1("4101") + "\"";
				for (int i = 0; i < gclass.list_0.Count; i++)
				{
					text2 += text;
					text2 = text2 + "\"" + gclass.list_0[i] + "\"";
				}
				text2 = text2 + text + "\"TAG\"";
				if (GClass3.bool_7)
				{
					text2 = text2 + text + "\"DTC\"";
				}
				streamWriter.WriteLine(text2);
				text2 = "\"" + GClass62.smethod_1("sec") + "\"";
				for (int i = 0; i < gclass.list_0.Count; i++)
				{
					text2 += text;
					if (gclass.list_1[i] == string.Empty)
					{
						text2 += "\" \"";
					}
					else
					{
						text2 = text2 + "\"" + gclass.list_1[i] + "\"";
					}
				}
				text2 = text2 + text + "\" \"";
				if (GClass3.bool_7)
				{
					text2 = text2 + text + "\" \"";
				}
				streamWriter.WriteLine(text2);
				for (int j = 0; j < gclass.list_3.Count; j++)
				{
					text2 = ((float)gclass.list_3[j].int_0 / 1000f).ToString("F2");
					for (int i = 0; i < gclass.list_0.Count; i++)
					{
						text2 += text;
						if (gclass.list_8[i].string_2.StartsWith("num") || gclass.list_8[i].string_2.StartsWith("equ"))
						{
							text2 += string.Format("{0:0.0000}", gclass.list_3[j].list_1[i]);
						}
						else
						{
							text2 += gclass.list_3[j].list_0[i];
						}
					}
					string text3 = text2;
					text2 = string.Concat(new string[]
					{
						text3,
						text,
						"\"",
						gclass.list_3[j].string_0,
						"\""
					});
					if (GClass3.bool_7)
					{
						text3 = text2;
						text2 = string.Concat(new string[]
						{
							text3,
							text,
							"\"",
							gclass.list_3[j].string_1,
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
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x0007FB98 File Offset: 0x0007DD98
	private void btnExportGraph_Click(object sender, EventArgs e)
	{
		if (GClass3.smethod_0() != null && GClass3.smethod_0().list_3.Count != 0 && this.saveFileDialog_0.ShowDialog() == DialogResult.OK)
		{
			this.method_21(this.saveFileDialog_0.FileName);
		}
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x0007FBEC File Offset: 0x0007DDEC
	private void btnImportGraph_Click(object sender, EventArgs e)
	{
		if (this.openFileDialog_0.ShowDialog() == DialogResult.OK)
		{
			Stream stream = File.Open(this.openFileDialog_0.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			StreamReader streamReader = new StreamReader(stream);
			string text = (GClass61.smethod_10() == "Tab") ? "\t" : GClass61.smethod_10();
			try
			{
				List<GClass58> list = new List<GClass58>();
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
					GClass58 gclass = new GClass58();
					gclass.string_0 = array[i].Replace("\"", string.Empty);
					gclass.string_3 = array2[i].Replace("\"", string.Empty);
					gclass.string_2 = ((gclass.string_3 == string.Empty) ? string.Empty : "num");
					if (gclass.string_0 != "DTC" && gclass.string_0 != "TAG")
					{
						list.Add(gclass);
					}
				}
				GClass0 gclass2 = new GClass0(this.openFileDialog_0.SafeFileName, list);
				while ((text2 = streamReader.ReadLine()) != null)
				{
					string[] array3 = text2.Split(new string[]
					{
						text
					}, StringSplitOptions.None);
					for (int i = 0; i < list.Count; i++)
					{
						list[i].method_1(array3[i + 1]);
					}
					int int_ = (int)(Convert.ToDecimal(array3[0]) * 1000m);
					gclass2.method_2(int_);
					if (array3.Length > list.Count + 1 && array3[list.Count + 1].Length > 0)
					{
						gclass2.method_0(array3[list.Count + 1].Replace("\"", string.Empty));
					}
					if (array3.Length > list.Count + 2 && array3[list.Count + 2].Length > 0)
					{
						gclass2.method_1(array3[list.Count + 2].Replace("\"", string.Empty));
					}
				}
				GClass3.list_1.Insert(GClass3.list_1.Count - 1, gclass2);
				this.cbGraphFiles.Items.Insert(this.cbGraphFiles.Items.Count - 1, gclass2.string_0);
				GClass3.int_7 = GClass3.list_1.Count - 1;
				this.cbGraphFiles.SelectedIndex = this.cbGraphFiles.Items.Count - 2;
				this.cbGraphFiles_SelectedIndexChanged(null, null);
			}
			catch (Exception)
			{
				MessageBox.Show("File format error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				streamReader.Close();
			}
		}
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x0007FF40 File Offset: 0x0007E140
	private void method_22()
	{
		if (this.dgvTags.Visible)
		{
			this.dgvTags.Visible = false;
			this.tableLayoutPanelGraphs.Width = this.flowLayoutPanel2.Width;
		}
		else
		{
			this.dgvTags.Visible = true;
			this.tableLayoutPanelGraphs.Width = this.flowLayoutPanel2.Width - this.dgvTags.Width - 5;
		}
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x0007FFB4 File Offset: 0x0007E1B4
	private void method_23(int int_1)
	{
		string text = GClass61.smethod_87(int_1);
		GClass0 gclass = GClass3.smethod_0();
		if (GClass3.bool_4 && gclass != null && gclass.list_3.Count != 0 && (text.Length != 0 && GClass3.bool_3))
		{
			gclass.method_0(text);
		}
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x00080008 File Offset: 0x0007E208
	private void dgvActuators_SelectionChanged(object sender, EventArgs e)
	{
		if (this.dgvActuators.SelectedRows.Count > 0)
		{
			this.tbActuatorsDesc.Text = ((TableDataRowP)this.dgvActuators.SelectedRows[0].DataBoundItem).getDataItem().string_1;
		}
		else
		{
			this.tbActuatorsDesc.Text = string.Empty;
		}
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x00080070 File Offset: 0x0007E270
	private void btnActuatorsExecute_Click(object sender, EventArgs e)
	{
		if (this.formNotify_0 == null && this.dgvActuators.SelectedRows.Count != 0)
		{
			GClass58 dataItem = ((TableDataRowP)this.dgvActuators.SelectedRows[0].DataBoundItem).getDataItem();
			if (dataItem.string_2.Contains("READNOTES"))
			{
				this.formNotify_0 = new FormNotify(GClass62.smethod_1("6050"), string.Empty, GClass62.smethod_1("1055"), true, 0);
				this.formNotify_0.ShowDialog();
				bool flag = this.formNotify_0.method_1();
				this.formNotify_0 = null;
				if (!flag)
				{
					return;
				}
			}
			GClass3.smethod_2(GClass62.smethod_1("6101"), 2);
			GClass3.smethod_2(dataItem.string_0, 2);
			string text = " ";
			if (!dataItem.string_2.Contains("IORESULT") && dataItem.byte_0.Length > 1 && !dataItem.string_2.Contains("NOABORT"))
			{
				text = GClass62.smethod_1("6059");
			}
			this.formNotify_0 = new FormNotify(GClass62.smethod_1(dataItem.string_4), GClass62.smethod_1("1052"), text, false, 0);
			this.gclass19_0.method_23(dataItem);
			this.formNotify_0.ShowDialog();
			this.formNotify_0 = null;
		}
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x000801D0 File Offset: 0x0007E3D0
	private void dgvAdjustments_SelectionChanged(object sender, EventArgs e)
	{
		if (this.dgvAdjustments.SelectedRows.Count > 0)
		{
			this.tbAdjDesc.Text = ((TableDataRowP)this.dgvAdjustments.SelectedRows[0].DataBoundItem).getDataItem().string_1;
		}
		else
		{
			this.tbAdjDesc.Text = string.Empty;
		}
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x00080238 File Offset: 0x0007E438
	private void btnAdjustmentsExecute_Click(object sender, EventArgs e)
	{
		if (this.formNotify_0 == null && this.dgvAdjustments.SelectedRows.Count != 0)
		{
			GClass58 dataItem = ((TableDataRowP)this.dgvAdjustments.SelectedRows[0].DataBoundItem).getDataItem();
			bool flag = !dataItem.string_2.Contains("IORESULT") && dataItem.byte_0.Length > 1 && !dataItem.string_2.Contains("NOABORT");
			if (!GClass3.bool_0 && !GClass3.bool_3)
			{
				this.formNotify_0 = new FormNotify("FREE VERSION RESTRICTION", "This function requires REGISTERED version!", "You can run it in 'simulation' (CTRL+F10) mode only!", true, 3000);
				this.formNotify_0.ShowDialog();
				this.formNotify_0 = null;
			}
			else
			{
				if (dataItem.string_2.Contains("READNOTES"))
				{
					this.formNotify_0 = new FormNotify(GClass62.smethod_1("6050"), string.Empty, GClass62.smethod_1("1055"), true, 0);
					this.formNotify_0.ShowDialog();
					bool flag2 = this.formNotify_0.method_1();
					this.formNotify_0 = null;
					if (!flag2)
					{
						return;
					}
				}
				GClass3.smethod_2(GClass62.smethod_1("7101"), 2);
				GClass3.smethod_2(dataItem.string_0, 2);
				if (dataItem.string_2.Contains("SECURITY1") || dataItem.string_2.Contains("SECURITY29"))
				{
					flag = false;
					string a = string.Empty;
					if (dataItem.string_2.Contains("SECURITY29"))
					{
						a = this.gclass19_0.vmethod_0(new byte[]
						{
							2,
							39,
							3
						}, "hex", 0, 4, new string[0], "hex");
					}
					else
					{
						a = this.gclass19_0.vmethod_0(new byte[]
						{
							2,
							39,
							3
						}, "hex", 1, 1, new string[0], "hex");
					}
					if (a == string.Empty && !GClass3.bool_0)
					{
						this.formNotify_0 = new FormNotify(GClass62.smethod_1("6052"), GClass62.smethod_1("6066"), string.Empty, true, 3000);
						this.formNotify_0.ShowDialog();
						this.formNotify_0 = null;
						return;
					}
					if (a != "00" || (dataItem.string_2.Contains("SECURITY29") && a != "00 00 00 00") || GClass3.bool_0)
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
						string text = "00000";
						FormDataEntry formDataEntry = new FormDataEntry(GClass62.smethod_1("6061"), text, array, 5);
						if (formDataEntry.ShowDialog() != DialogResult.OK)
						{
							return;
						}
						int[] array2 = formDataEntry.method_1();
						string text2 = string.Empty;
						if (dataItem.string_2.Contains("SECURITY29"))
						{
							text2 = "06 27 04 00 0";
						}
						else
						{
							text2 = "05 27 04 0";
						}
						string text3 = text2;
						text2 = string.Concat(new string[]
						{
							text3,
							array[array2[0]],
							array[array2[1]],
							array[array2[2]],
							array[array2[3]],
							array[array2[4]]
						});
						string a2 = string.Empty;
						if (dataItem.string_2.Contains("SECURITY29"))
						{
							a2 = this.gclass19_0.vmethod_0(GClass16.smethod_2(text2), "hex3", 0, 1, new string[0], "hex3");
						}
						else
						{
							a2 = this.gclass19_0.vmethod_0(GClass16.smethod_2(text2), "hex3", 1, 1, new string[0], "hex3");
						}
						if (a2 == "34" || (dataItem.string_2.Contains("SECURITY29") && a2 == string.Empty) || GClass3.bool_0)
						{
							GClass3.smethod_2(GClass62.smethod_1("1092"), 2);
						}
						else
						{
							if (a2 == "33" || a2 == "35")
							{
								this.formNotify_0 = new FormNotify(GClass62.smethod_1("6052"), GClass62.smethod_1("6062"), GClass62.smethod_1("6063"), true, 3000);
								this.formNotify_0.ShowDialog();
								this.formNotify_0 = null;
								GClass3.smethod_2(GClass62.smethod_1("6062"), 2);
								GClass3.smethod_2(GClass62.smethod_1("1093"), 2);
								return;
							}
							if (a2 == "36" || a2 == "37")
							{
								this.formNotify_0 = new FormNotify(GClass62.smethod_1("6052"), GClass62.smethod_1("6064"), GClass62.smethod_1("6065"), true, 3000);
								this.formNotify_0.ShowDialog();
								this.formNotify_0 = null;
								GClass3.smethod_2(GClass62.smethod_1("6064"), 2);
								GClass3.smethod_2(GClass62.smethod_1("1093"), 2);
								return;
							}
							this.formNotify_0 = new FormNotify(GClass62.smethod_1("6052"), GClass62.smethod_1("6066"), GClass62.smethod_1("6067"), true, 3000);
							this.formNotify_0.ShowDialog();
							this.formNotify_0 = null;
							GClass3.smethod_2(GClass62.smethod_1("1093"), 2);
							return;
						}
					}
				}
				if (dataItem.string_2.Contains("RWUSERENTRYNUM"))
				{
					flag = false;
					string[] array3 = dataItem.string_2.Split(new char[]
					{
						'|'
					});
					string text4 = array3[2];
					int num = GClass16.smethod_5(array3[1]);
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
					string text = this.gclass19_0.vmethod_0(dataItem.byte_0[0], text4, dataItem.int_0, dataItem.int_1, dataItem.string_5, dataItem.string_6);
					string str = text;
					while (text.Length < num)
					{
						text = "0" + text;
					}
					string str2 = dataItem.string_0;
					if (dataItem.string_3 != string.Empty)
					{
						str2 = str2 + " (" + dataItem.string_3 + ")";
					}
					if (text4 == "date")
					{
						text = text.Replace("/", string.Empty);
						str2 += " [ddmmyyyy]";
					}
					FormDataEntry formDataEntry = new FormDataEntry(str2, text, array, num);
					if (formDataEntry.ShowDialog() != DialogResult.OK)
					{
						return;
					}
					int[] array2 = formDataEntry.method_1();
					string text5 = string.Empty;
					for (int i = 0; i < num; i++)
					{
						text5 += array[array2[i]];
					}
					if (text4.StartsWith("num"))
					{
						decimal d = 1m;
						decimal d2 = 0m;
						string[] array4 = text4.Split(new char[]
						{
							','
						});
						try
						{
							if (array4.Length > 1)
							{
								GClass16.smethod_5(array4[1]);
							}
							if (array4.Length > 2)
							{
								d = Convert.ToDecimal(array4[2], NumberFormatInfo.InvariantInfo);
							}
							if (array4.Length > 3)
							{
								d2 = Convert.ToDecimal(array4[3], NumberFormatInfo.InvariantInfo);
							}
							decimal d3 = Convert.ToDecimal(text5);
							if (GClass61.smethod_55() && (dataItem.string_6 == "km" || dataItem.string_6 == "km/h"))
							{
								d3 /= 0.621371192237m;
							}
							long long_ = (long)((d3 - d2) / d);
							byte[] array5 = GClass16.smethod_7(long_);
							for (int i = 0; i < dataItem.int_1; i++)
							{
								if (dataItem.string_2.Contains("RWUSERENTRYNUM29"))
								{
									dataItem.byte_0[1][i + 3 + dataItem.int_0] = array5[dataItem.int_1 - i - 1];
								}
								else
								{
									dataItem.byte_0[1][i + 2 + dataItem.int_0] = array5[dataItem.int_1 - i - 1];
								}
							}
							goto IL_9D0;
						}
						catch (Exception ex)
						{
							GClass3.smethod_2("Parameter format error(1): " + ex.Message, 1);
							return;
						}
					}
					if (text4 == "date")
					{
						try
						{
							byte[] array5 = GClass16.smethod_2(text5);
							int num2 = 2;
							if (dataItem.string_2.Contains("RWUSERENTRYNUM29"))
							{
								num2 = 3;
							}
							dataItem.byte_0[1][num2 + dataItem.int_0] = array5[2];
							dataItem.byte_0[1][1 + num2 + dataItem.int_0] = array5[3];
							dataItem.byte_0[1][2 + num2 + dataItem.int_0] = array5[0];
							dataItem.byte_0[1][3 + num2 + dataItem.int_0] = array5[1];
						}
						catch (Exception ex)
						{
							GClass3.smethod_2("Parameter format error(2): " + ex.Message, 1);
							return;
						}
					}
					IL_9D0:
					string text6 = this.gclass19_0.vmethod_7(dataItem.byte_0[1], text4, dataItem.int_0, dataItem.int_1, dataItem.string_5, dataItem.string_6);
					if (dataItem.string_3 != string.Empty)
					{
						text6 = text6 + " " + dataItem.string_3;
					}
					this.formNotify_0 = new FormNotify(GClass62.smethod_1("6058"), dataItem.string_0 + ": " + text6, GClass62.smethod_1("1055"), true, 0);
					this.formNotify_0.ShowDialog();
					bool flag2 = this.formNotify_0.method_1();
					this.formNotify_0 = null;
					if (!flag2)
					{
						GClass3.smethod_2(GClass62.smethod_1("6060"), 2);
						return;
					}
					if (dataItem.string_2.Contains("ODOWARNING"))
					{
						this.formNotify_0 = new FormNotify(GClass62.smethod_1("1070"), GClass62.smethod_1("1203"), GClass62.smethod_1("1055"), true, 0);
						this.formNotify_0.ShowDialog();
						bool flag3 = this.formNotify_0.method_1();
						this.formNotify_0 = null;
						if (!flag3)
						{
							GClass3.smethod_2(GClass62.smethod_1("6060"), 2);
							return;
						}
					}
					GClass3.smethod_2(GClass62.smethod_1("7102") + ": " + str, 2);
					GClass3.smethod_2(GClass62.smethod_1("7103") + ": " + text6, 2);
				}
				else if (dataItem.string_2.Contains("RWUSERENTRY"))
				{
					flag = false;
					string[] array = new string[dataItem.string_5.Length];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = dataItem.string_5[i].Substring(4);
					}
					string text = this.gclass19_0.vmethod_0(dataItem.byte_0[0], "bitchars", dataItem.int_0, dataItem.int_1, dataItem.string_5, dataItem.string_6);
					FormDataEntry formDataEntry = new FormDataEntry(dataItem.string_0, text, array, dataItem.int_1);
					if (formDataEntry.ShowDialog() != DialogResult.OK)
					{
						return;
					}
					int[] array2 = formDataEntry.method_1();
					for (int i = 0; i < dataItem.int_1; i++)
					{
						byte b = 0;
						string a3 = array[array2[i]];
						for (int j = 0; j < dataItem.string_5.Length; j++)
						{
							if (a3 == array[j])
							{
								b = byte.Parse(dataItem.string_5[j].Substring(2, 2), NumberStyles.HexNumber);
							}
						}
						if (dataItem.string_2.Contains("RWUSERENTRY29"))
						{
							dataItem.byte_0[1][i + 3 + dataItem.int_0] = b;
						}
						else
						{
							dataItem.byte_0[1][i + 2 + dataItem.int_0] = b;
						}
					}
					int num3 = dataItem.int_0;
					if (this.gclass19_0.method_12().StartsWith("PROXI"))
					{
						num3 += 3;
					}
					string text6 = this.gclass19_0.vmethod_7(dataItem.byte_0[1], "bitchars", num3, dataItem.int_1, dataItem.string_5, dataItem.string_6);
					if (dataItem.string_3 != string.Empty)
					{
						text6 = text6 + " " + dataItem.string_3;
					}
					this.formNotify_0 = new FormNotify(GClass62.smethod_1("6058"), dataItem.string_0 + ": " + text6, GClass62.smethod_1("1055"), true, 0);
					this.formNotify_0.ShowDialog();
					bool flag2 = this.formNotify_0.method_1();
					this.formNotify_0 = null;
					if (!flag2)
					{
						GClass3.smethod_2(GClass62.smethod_1("6060"), 2);
						return;
					}
					GClass3.smethod_2(GClass62.smethod_1("7102") + ": " + text, 2);
					GClass3.smethod_2(GClass62.smethod_1("7103") + ": " + text6, 2);
				}
				if (dataItem.string_2.Contains("PROGRAM1"))
				{
					flag = false;
					string a4 = this.gclass19_0.vmethod_0(dataItem.byte_0[0], "hex3", 1, 1, new string[0], "hex3");
					if (!(a4 == string.Empty) && !(a4 == "00") && !GClass3.bool_0)
					{
						this.formNotify_0 = new FormNotify(GClass62.smethod_1("6052"), GClass62.smethod_1("6067"), string.Empty, true, 3000);
						this.formNotify_0.ShowDialog();
						this.formNotify_0 = null;
					}
					else
					{
						GClass58 gclass = new GClass58();
						gclass.byte_0 = new byte[][]
						{
							dataItem.byte_0[1]
						};
						gclass.string_5 = dataItem.string_5;
						gclass.string_2 = "FUNC";
						gclass.int_0 = 1;
						gclass.int_1 = 1;
						bool flag4 = true;
						int num4 = 1;
						while (num4 <= 8 && flag4)
						{
							this.formNotify_0 = new FormNotify(string.Format(GClass62.smethod_1("6068"), num4), GClass62.smethod_1("6069"), GClass62.smethod_1("6070"), true, 0);
							this.formNotify_0.ShowDialog();
							flag4 = this.formNotify_0.method_1();
							this.formNotify_0 = null;
							if (flag4)
							{
								this.formNotify_0 = new FormNotify(string.Format(GClass62.smethod_1("6071"), num4), GClass62.smethod_1("6072"), string.Empty, false, 0);
								this.gclass19_0.method_23(gclass);
								this.formNotify_0.ShowDialog();
								this.formNotify_0 = null;
								if (this.gclass19_0.method_8() == "00")
								{
									GClass3.smethod_2(string.Format(GClass62.smethod_1("6071"), num4) + "... " + GClass62.smethod_1("1092"), 2);
								}
								else
								{
									GClass3.smethod_2(string.Format(GClass62.smethod_1("6071"), num4) + "... " + GClass62.smethod_1("1093"), 2);
								}
							}
							if (this.gclass19_0.method_8() == "00" || GClass3.bool_0)
							{
								num4++;
							}
						}
						GClass58 gclass2 = new GClass58();
						gclass2.byte_0 = new byte[][]
						{
							dataItem.byte_0[2]
						};
						gclass2.string_5 = dataItem.string_5;
						gclass2.string_2 = "FUNC";
						gclass2.int_0 = 1;
						gclass2.int_1 = 1;
						this.formNotify_0 = new FormNotify(GClass62.smethod_1("6073"), GClass62.smethod_1("1052"), string.Empty, false, 0);
						this.gclass19_0.method_23(gclass2);
						this.formNotify_0.ShowDialog();
						this.formNotify_0 = null;
						if (this.gclass19_0.method_8() == "00")
						{
							GClass3.smethod_2(GClass62.smethod_1("6073") + "... " + GClass62.smethod_1("1092"), 2);
						}
						else
						{
							GClass3.smethod_2(GClass62.smethod_1("6073") + "... " + GClass62.smethod_1("1093"), 2);
						}
					}
				}
				else
				{
					string text7 = " ";
					if (dataItem.string_2.Contains("WAITY"))
					{
						text7 = GClass62.smethod_1("1059");
					}
					else if (flag)
					{
						text7 = GClass62.smethod_1("6059");
					}
					this.formNotify_0 = new FormNotify(GClass62.smethod_1(dataItem.string_4), GClass62.smethod_1("1052"), text7, false, 0);
					this.gclass19_0.method_23(dataItem);
					this.formNotify_0.ShowDialog();
					this.formNotify_0 = null;
					if (dataItem.string_2.Contains("DISCONNECTONSUCCESS") && this.gclass19_0.method_9())
					{
						this.formNotify_0 = new FormNotify(GClass62.smethod_1("6057"), string.Empty, GClass62.smethod_1("1059"), true, 0);
						this.formNotify_0.ShowDialog();
						this.formNotify_0 = null;
						this.gclass19_0.method_22(false);
					}
				}
			}
		}
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x000814A8 File Offset: 0x0007F6A8
	private void method_24()
	{
		GClass3.string_7 = GClass16.smethod_9().Replace(" ", string.Empty);
		this.list_7.Clear();
		for (int i = 0; i < 10; i++)
		{
			this.list_7.Add(new SimpleValueData(i, GClass61.smethod_87(i)));
		}
		this.dgvTags.DataSource = this.list_7;
		this.buttonConnect.Enabled = true;
		this.buttonSettings.Enabled = true;
		this.buttonDisconnect.Enabled = false;
		GClass3.smethod_2("Start 5", 0);
		this.method_10(true);
		this.method_9(this.tabPageGraph);
		GClass62.smethod_7();
		GClass16.smethod_34();
		GClass3.smethod_2("Start 7", 0);
		string text = GClass16.smethod_9().Replace(" ", string.Empty);
		string text2 = GClass16.smethod_27(text, GClass61.smethod_5());
		string text3 = GClass16.smethod_21(text, GClass61.smethod_5());
		string text4 = string.Empty;
		string text5 = text4;
		try
		{
			text5 = GClass62.smethod_15(string.Empty, text2);
			text4 = GClass62.smethod_17(string.Empty, text3);
			GClass3.smethod_3();
		}
		catch (Exception)
		{
			MessageBox.Show("Data file error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			base.Close();
			return;
		}
		GClass3.smethod_2("Start 8", 0);
		this.lblGraphStatus.Text = string.Empty;
		this.lblGraphTime.Text = "0";
		this.cbGraphScale.SelectedIndex = 2;
		this.cbGraphRate.SelectedIndex = this.cbGraphRate.Items.Count - 1;
		this.cbGraphCount.SelectedIndex = 0;
		this.cbGraphCount_SelectedIndexChanged(null, null);
		GClass3.bool_10 = GClass62.smethod_18(text4, text3, true);
		GClass3.bool_9 = GClass62.smethod_18(text5, text2, true);
		GClass3.smethod_2("Start 9", 0);
		GClass3.bool_3 = GClass3.bool_10;
		GClass16.smethod_22();
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x00081690 File Offset: 0x0007F890
	private void method_25(string string_10)
	{
		if (GClass61.smethod_53() && !GClass3.bool_3)
		{
			new FormDisclaimer().ShowDialog();
			Application.DoEvents();
		}
		int int_ = 0;
		if (GClass3.bool_2 && GClass3.bool_3)
		{
			int_ = 2;
		}
		else if (GClass3.bool_3)
		{
			int_ = 1;
		}
		typeof(TableDataRowP).GetProperties();
		typeof(TableDataRowE).GetProperties();
		typeof(SimpleValueData).GetProperties();
		this.method_26(string_10, int_);
		GClass62.smethod_8(GClass61.smethod_12(), GClass61.smethod_14());
		GClass3.smethod_2("Start 10", 0);
		GClass16.smethod_21(GClass3.string_7, GClass61.smethod_5());
		this.method_4();
		GClass3.smethod_2("Start 11", 0);
		GClass2 gclass = new GClass2();
		this.lblLoading.Visible = false;
		this.panelLoading.Visible = false;
		this.label10.Text = string.Empty;
		GClass3.smethod_2("Start 12", 0);
		DataView dataSource = new DataView(gclass.dataTable_0);
		DataView dataSource2 = new DataView(gclass.dataTable_1);
		DataView dataSource3 = new DataView(gclass.dataTable_2);
		DataView dataSource4 = new DataView(gclass.dataTable_3);
		this.dgvSelectMake.DataSource = dataSource;
		this.dgvSelectModel.DataSource = dataSource2;
		this.dgvSelectSystem.DataSource = dataSource3;
		this.dgvSelectECU.DataSource = dataSource4;
		this.tabControlMain_SelectedIndexChanged(null, null);
		GClass3.smethod_2("Start 13", 0);
		if (!GClass3.bool_3)
		{
			this.cbGraphCount.Items.Clear();
			this.cbGraphCount.Items.Add("1");
			this.cbGraphCount.SelectedIndex = 0;
		}
		this.timer_2.Interval = ((GClass61.smethod_51() == 0) ? 180 : ((GClass61.smethod_51() == 0) ? 500 : 800));
		this.timer_2.Start();
		Thread thread = new Thread(new ThreadStart(this.method_0));
		thread.Start();
		if (!GClass3.bool_3)
		{
			this.Text += " - FREE at www.fiatecuscan.net";
			if (GClass3.bool_9)
			{
				MessageBox.Show(this.string_0, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
		if (Screen.PrimaryScreen.Bounds.Width == 800)
		{
			this.panel2.Width = this.panel2.Width - 59;
			this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
			this.tableLayoutPanelGraphParams.Width = this.tableLayoutPanelGraphParams.Width - 59;
			this.tableLayoutPanelGraphs.Left = this.tableLayoutPanelGraphs.Left - 59;
			this.tableLayoutPanelGraphs.Width = this.tableLayoutPanelGraphs.Width + 59;
			this.flowLayoutPanel2.Left = this.flowLayoutPanel2.Left - 59;
			this.flowLayoutPanel2.Width = this.flowLayoutPanel2.Width + 59;
			this.panel8.Left = this.panel8.Left - 59;
			this.panel8.Width = this.panel8.Width - 16;
			this.panel9.Left = this.panel9.Left - 59 - 16;
			this.panel9.Width = this.panel9.Width + 59 + 16;
			this.label8.Visible = false;
		}
		if (Screen.PrimaryScreen.Bounds.Width == 1024)
		{
			this.panel2.Width = this.panel2.Width - 40;
			this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
			this.tableLayoutPanelGraphParams.Width = this.tableLayoutPanelGraphParams.Width - 40;
			this.tableLayoutPanelGraphs.Left = this.tableLayoutPanelGraphs.Left - 40;
			this.tableLayoutPanelGraphs.Width = this.tableLayoutPanelGraphs.Width + 40;
			this.flowLayoutPanel2.Left = this.flowLayoutPanel2.Left - 40;
			this.flowLayoutPanel2.Width = this.flowLayoutPanel2.Width + 40;
			this.panel8.Left = this.panel8.Left - 40;
			this.panel8.Width = this.panel8.Width - 10;
			this.panel9.Left = this.panel9.Left - 40 - 10;
			this.panel9.Width = this.panel9.Width + 40 + 10;
		}
		this.buttonScanDTC.Enabled = GClass3.bool_3;
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x00081B54 File Offset: 0x0007FD54
	private void method_26(string string_10, int int_1)
	{
		if (int_1 == 2)
		{
			this.Text = "FiatECUScan " + string_10.Replace(".0", string.Empty) + " MULTIPLEXED";
		}
		else if (int_1 == 1)
		{
			this.Text = "FiatECUScan " + string_10.Replace(".0", string.Empty) + " REGISTERED";
		}
	}

	// Token: 0x06000406 RID: 1030 RVA: 0x000034ED File Offset: 0x000016ED
	private void method_27()
	{
		this.lblNewVersionMessage.Visible = true;
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x000034FB File Offset: 0x000016FB
	private void method_28()
	{
		if (this.formNotify_0 != null)
		{
			this.formNotify_0.Close();
		}
		this.formNotify_0 = null;
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x00081BC0 File Offset: 0x0007FDC0
	private void method_29(object sender, GEventArgs5 e)
	{
		base.Invoke(new FormMain.Delegate5(this.method_32), new object[]
		{
			e.method_1()
		});
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x00081BF4 File Offset: 0x0007FDF4
	private void method_30(object sender, GEventArgs5 e)
	{
		GClass3.smethod_2(e.method_1(), 2);
		GClass3.smethod_2(e.method_2(), 2);
		GClass3.smethod_2(string.Empty, 2);
		base.Invoke(new FormMain.Delegate3(this.method_31), new object[]
		{
			e.method_1(),
			e.method_2(),
			e.method_0() ? GClass62.smethod_1("1059") : string.Empty,
			e.method_0(),
			e.method_0() ? 0 : 2000
		});
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x0000351A File Offset: 0x0000171A
	private void method_31(string string_10, string string_11, string string_12, bool bool_4, int int_1)
	{
		if (this.formNotify_0 != null)
		{
			this.formNotify_0.method_8(string_10, string_11, string_12, bool_4, int_1);
		}
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x00081C94 File Offset: 0x0007FE94
	private void method_32(string string_10)
	{
		if (this.formNotify_0 != null)
		{
			string text = this.formNotify_0.method_4();
			string text2 = this.formNotify_0.method_6();
			this.formNotify_0.method_8(text, text2, string_10, false, 0);
		}
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x00003539 File Offset: 0x00001739
	private void method_33(object sender, EventArgs e)
	{
		base.Invoke(new FormMain.Delegate4(this.method_34), new object[0]);
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x000034FB File Offset: 0x000016FB
	private void method_34()
	{
		if (this.formNotify_0 != null)
		{
			this.formNotify_0.Close();
		}
		this.formNotify_0 = null;
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x00081CD4 File Offset: 0x0007FED4
	private void method_35(object sender, GEventArgs4 e)
	{
		base.Invoke(new FormMain.Delegate6(this.method_36), new object[]
		{
			e.method_0()
		});
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x00081D0C File Offset: 0x0007FF0C
	private void method_36(bool bool_4)
	{
		base.SuspendLayout();
		this.buttonConnect.Enabled = true;
		this.buttonConnectAuto.Enabled = true;
		this.buttonScanDTC.Enabled = GClass3.bool_3;
		this.buttonDisconnect.Enabled = false;
		this.buttonSettings.Enabled = true;
		this.ttslMsg.Text = GClass62.smethod_1("1058");
		GClass3.int_6 = GClass3.int_0;
		if (!this.tabControlMain.TabPages.Contains(this.tabPageSelect))
		{
			this.panelLoading.Visible = true;
			this.tabControlMain.TabPages.Insert(0, this.tabPageSelect);
			this.tabControlMain.SelectedTab = this.tabPageSelect;
		}
		if (!GClass3.bool_0 || bool_4)
		{
			this.method_10(true);
		}
		this.method_9(this.tabPageGraph);
		this.method_9(this.tabPageLog);
		base.ResumeLayout();
		this.panelLoading.Visible = false;
		if (!GClass3.bool_0 || bool_4)
		{
			this.timer_1.Enabled = false;
			this.timer_0.Enabled = false;
		}
		if (this.string_4 == string.Empty && this.gclass19_0 != null)
		{
			this.string_4 = this.gclass19_0.method_7();
		}
		this.buttonUploadReport.Visible = (GClass3.smethod_7() > 20);
		GClass3.smethod_8();
		if (GClass3.int_6 != 0)
		{
			new Thread(new ThreadStart(this.method_0)).Start();
		}
		GClass3.bool_0 = false;
		this.gclass19_0 = null;
		if (this.formNotify_0 != null)
		{
			this.formNotify_0.Close();
		}
		this.formNotify_0 = null;
		if (GClass3.int_8 != -1)
		{
			base.Close();
		}
	}

	// Token: 0x06000412 RID: 1042 RVA: 0x00089F10 File Offset: 0x00088110
	private static int smethod_2(TableDataRowP tableDataRowP_0, TableDataRowP tableDataRowP_1)
	{
		return tableDataRowP_0.Name.CompareTo(tableDataRowP_1.Name);
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x00089F30 File Offset: 0x00088130
	private static int smethod_3(TableDataRowP tableDataRowP_0, TableDataRowP tableDataRowP_1)
	{
		string text = tableDataRowP_0.getDataItem().string_3;
		string text2 = tableDataRowP_1.getDataItem().string_3;
		if (tableDataRowP_0.getDataItem().string_3 == string.Empty)
		{
			text = "ZZZZZZZZZZZZZZZ";
		}
		if (tableDataRowP_1.getDataItem().string_3 == string.Empty)
		{
			text2 = "ZZZZZZZZZZZZZZZ";
		}
		int result;
		if (text == text2)
		{
			result = tableDataRowP_0.Name.CompareTo(tableDataRowP_1.Name);
		}
		else
		{
			result = text.CompareTo(text2);
		}
		return result;
	}

	// Token: 0x0400053B RID: 1339
	private List<GClass58> list_0 = new List<GClass58>();

	// Token: 0x0400053C RID: 1340
	private List<GClass58> list_1 = new List<GClass58>();

	// Token: 0x0400053D RID: 1341
	private List<GClass58> list_2 = new List<GClass58>();

	// Token: 0x0400053E RID: 1342
	private List<GClass58> list_3 = new List<GClass58>();

	// Token: 0x0400053F RID: 1343
	private List<GClass64> list_4 = new List<GClass64>();

	// Token: 0x04000540 RID: 1344
	private List<GClass58> list_5 = new List<GClass58>();

	// Token: 0x04000541 RID: 1345
	private List<string> list_6 = new List<string>();

	// Token: 0x04000542 RID: 1346
	private List<SimpleValueData> list_7 = new List<SimpleValueData>();

	// Token: 0x04000543 RID: 1347
	private bool bool_0 = false;

	// Token: 0x04000544 RID: 1348
	private GClass19 gclass19_0;

	// Token: 0x04000545 RID: 1349
	private FormNotify formNotify_0;

	// Token: 0x04000546 RID: 1350
	private string string_0 = "Your License Key is not recognized as valid in FiatECUScan 3.4!\r\nPlease send an email to support@fiatecuscan.net to request new License Key.";

	// Token: 0x04000547 RID: 1351
	private string string_1 = "1";

	// Token: 0x04000548 RID: 1352
	private string string_2 = string.Empty;

	// Token: 0x04000549 RID: 1353
	private string string_3 = string.Empty;

	// Token: 0x0400054A RID: 1354
	private int int_0 = 0;

	// Token: 0x0400054B RID: 1355
	private string string_4 = string.Empty;

	// Token: 0x0400054C RID: 1356
	private bool bool_1 = false;

	// Token: 0x0400054D RID: 1357
	private bool bool_2 = false;

	// Token: 0x0400054E RID: 1358
	private string string_5 = string.Empty;

	// Token: 0x0400054F RID: 1359
	private List<GClass64> list_8 = null;

	// Token: 0x04000550 RID: 1360
	private string string_6 = ": ";

	// Token: 0x04000551 RID: 1361
	private string string_7 = " ";

	// Token: 0x04000552 RID: 1362
	private string string_8 = string.Empty;

	// Token: 0x04000553 RID: 1363
	private string string_9 = "4011";

	// Token: 0x04000554 RID: 1364
	private bool bool_3 = false;

	// Token: 0x040005ED RID: 1517
	private static Comparison<TableDataRowP> comparison_0;

	// Token: 0x040005EE RID: 1518
	private static Comparison<TableDataRowP> comparison_1;

	// Token: 0x02000075 RID: 117
	// (Invoke) Token: 0x06000415 RID: 1045
	private delegate void Delegate1();

	// Token: 0x02000076 RID: 118
	// (Invoke) Token: 0x06000419 RID: 1049
	private delegate void Delegate2();

	// Token: 0x02000077 RID: 119
	// (Invoke) Token: 0x0600041D RID: 1053
	private delegate void Delegate3(string string_0, string string_1, string string_2, bool bool_0, int int_0);

	// Token: 0x02000078 RID: 120
	// (Invoke) Token: 0x06000421 RID: 1057
	private delegate void Delegate4();

	// Token: 0x02000079 RID: 121
	// (Invoke) Token: 0x06000425 RID: 1061
	private delegate void Delegate5(string string_0);

	// Token: 0x0200007A RID: 122
	// (Invoke) Token: 0x06000429 RID: 1065
	private delegate void Delegate6(bool bool_0);

	// Token: 0x0200007B RID: 123
	private sealed class Class13
	{
		// Token: 0x0600042D RID: 1069 RVA: 0x00003579 File Offset: 0x00001779
		public void method_0()
		{
			this.formMain_0.method_8(this.string_0);
		}

		// Token: 0x040005EF RID: 1519
		public string string_0;

		// Token: 0x040005F0 RID: 1520
		public FormMain formMain_0;
	}

	// Token: 0x0200007C RID: 124
	private sealed class Class14
	{
		// Token: 0x0600042F RID: 1071 RVA: 0x0000358C File Offset: 0x0000178C
		public void method_0()
		{
			this.formMain_0.method_12(this.string_0, this.string_1, this.string_2, this.string_3, this.byte_0, this.int_0, this.int_1);
		}

		// Token: 0x040005F1 RID: 1521
		public string string_0;

		// Token: 0x040005F2 RID: 1522
		public string string_1;

		// Token: 0x040005F3 RID: 1523
		public string string_2;

		// Token: 0x040005F4 RID: 1524
		public string string_3;

		// Token: 0x040005F5 RID: 1525
		public byte byte_0;

		// Token: 0x040005F6 RID: 1526
		public int int_0;

		// Token: 0x040005F7 RID: 1527
		public int int_1;

		// Token: 0x040005F8 RID: 1528
		public FormMain formMain_0;
	}
}
