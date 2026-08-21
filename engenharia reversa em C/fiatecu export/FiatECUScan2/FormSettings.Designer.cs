// Token: 0x02000060 RID: 96
public sealed partial class FormSettings : global::System.Windows.Forms.Form
{
	// Token: 0x060002BA RID: 698 RVA: 0x0000306E File Offset: 0x0000126E
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x060002BB RID: 699 RVA: 0x00067468 File Offset: 0x00065668
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		this.buttonOk = new global::System.Windows.Forms.Button();
		this.buttonCancel = new global::System.Windows.Forms.Button();
		this.label5 = new global::System.Windows.Forms.Label();
		this.cbDataLang = new global::System.Windows.Forms.ComboBox();
		this.label4 = new global::System.Windows.Forms.Label();
		this.cbUILang = new global::System.Windows.Forms.ComboBox();
		this.tabControl1 = new global::System.Windows.Forms.TabControl();
		this.tabPageSettingsGeneral = new global::System.Windows.Forms.TabPage();
		this.groupBox6 = new global::System.Windows.Forms.GroupBox();
		this.cbCSVSeparator = new global::System.Windows.Forms.ComboBox();
		this.tbCSVFolder = new global::System.Windows.Forms.TextBox();
		this.label13 = new global::System.Windows.Forms.Label();
		this.label7 = new global::System.Windows.Forms.Label();
		this.label17 = new global::System.Windows.Forms.Label();
		this.tbLogFolder = new global::System.Windows.Forms.TextBox();
		this.groupBox5 = new global::System.Windows.Forms.GroupBox();
		this.buttonClearRecent = new global::System.Windows.Forms.Button();
		this.cbScreenRepaint = new global::System.Windows.Forms.ComboBox();
		this.label28 = new global::System.Windows.Forms.Label();
		this.chkShowMiles = new global::System.Windows.Forms.CheckBox();
		this.chkShowAdapterMessage = new global::System.Windows.Forms.CheckBox();
		this.buttonChangeUIF2 = new global::System.Windows.Forms.Button();
		this.lblUIF2 = new global::System.Windows.Forms.Label();
		this.label10 = new global::System.Windows.Forms.Label();
		this.buttonChangeUIF1 = new global::System.Windows.Forms.Button();
		this.label19 = new global::System.Windows.Forms.Label();
		this.lblUIF1 = new global::System.Windows.Forms.Label();
		this.tabPageSettingsInterfaces = new global::System.Windows.Forms.TabPage();
		this.groupBox7 = new global::System.Windows.Forms.GroupBox();
		this.chkHighLatency = new global::System.Windows.Forms.CheckBox();
		this.cbKWPTimings = new global::System.Windows.Forms.ComboBox();
		this.label8 = new global::System.Windows.Forms.Label();
		this.buttonScanInterface = new global::System.Windows.Forms.Button();
		this.groupBox4 = new global::System.Windows.Forms.GroupBox();
		this.buttonTest4 = new global::System.Windows.Forms.Button();
		this.label25 = new global::System.Windows.Forms.Label();
		this.cbSerialPort4 = new global::System.Windows.Forms.ComboBox();
		this.label26 = new global::System.Windows.Forms.Label();
		this.cbInterfaceType4 = new global::System.Windows.Forms.ComboBox();
		this.label27 = new global::System.Windows.Forms.Label();
		this.cbPortSpeed4 = new global::System.Windows.Forms.ComboBox();
		this.groupBox3 = new global::System.Windows.Forms.GroupBox();
		this.buttonTest3 = new global::System.Windows.Forms.Button();
		this.label22 = new global::System.Windows.Forms.Label();
		this.cbSerialPort3 = new global::System.Windows.Forms.ComboBox();
		this.label23 = new global::System.Windows.Forms.Label();
		this.cbInterfaceType3 = new global::System.Windows.Forms.ComboBox();
		this.label24 = new global::System.Windows.Forms.Label();
		this.cbPortSpeed3 = new global::System.Windows.Forms.ComboBox();
		this.groupBox2 = new global::System.Windows.Forms.GroupBox();
		this.buttonTest2 = new global::System.Windows.Forms.Button();
		this.label18 = new global::System.Windows.Forms.Label();
		this.cbSerialPort2 = new global::System.Windows.Forms.ComboBox();
		this.label20 = new global::System.Windows.Forms.Label();
		this.cbInterfaceType2 = new global::System.Windows.Forms.ComboBox();
		this.label21 = new global::System.Windows.Forms.Label();
		this.cbPortSpeed2 = new global::System.Windows.Forms.ComboBox();
		this.groupBox1 = new global::System.Windows.Forms.GroupBox();
		this.buttonTest = new global::System.Windows.Forms.Button();
		this.label2 = new global::System.Windows.Forms.Label();
		this.cbSerialPort = new global::System.Windows.Forms.ComboBox();
		this.label1 = new global::System.Windows.Forms.Label();
		this.cbInterfaceType = new global::System.Windows.Forms.ComboBox();
		this.label3 = new global::System.Windows.Forms.Label();
		this.cbPortSpeed = new global::System.Windows.Forms.ComboBox();
		this.chkShowAvailablePorts = new global::System.Windows.Forms.CheckBox();
		this.tabPageSettingsGraph = new global::System.Windows.Forms.TabPage();
		this.cbLineThickness = new global::System.Windows.Forms.ComboBox();
		this.label12 = new global::System.Windows.Forms.Label();
		this.buttonChangePF = new global::System.Windows.Forms.Button();
		this.lblPF = new global::System.Windows.Forms.Label();
		this.label11 = new global::System.Windows.Forms.Label();
		this.buttonChangeXF = new global::System.Windows.Forms.Button();
		this.lblXF = new global::System.Windows.Forms.Label();
		this.label9 = new global::System.Windows.Forms.Label();
		this.buttonChangeYF = new global::System.Windows.Forms.Button();
		this.lblYF = new global::System.Windows.Forms.Label();
		this.label6 = new global::System.Windows.Forms.Label();
		this.label16 = new global::System.Windows.Forms.Label();
		this.panelGC = new global::System.Windows.Forms.Panel();
		this.label15 = new global::System.Windows.Forms.Label();
		this.panelBC = new global::System.Windows.Forms.Panel();
		this.panelGC8 = new global::System.Windows.Forms.Panel();
		this.panelGC7 = new global::System.Windows.Forms.Panel();
		this.panelGC6 = new global::System.Windows.Forms.Panel();
		this.panelGC5 = new global::System.Windows.Forms.Panel();
		this.panelGC4 = new global::System.Windows.Forms.Panel();
		this.panelGC3 = new global::System.Windows.Forms.Panel();
		this.panelGC2 = new global::System.Windows.Forms.Panel();
		this.panelGC1 = new global::System.Windows.Forms.Panel();
		this.label14 = new global::System.Windows.Forms.Label();
		this.fontDialog_0 = new global::System.Windows.Forms.FontDialog();
		this.colorDialog_0 = new global::System.Windows.Forms.ColorDialog();
		this.toolTip_0 = new global::System.Windows.Forms.ToolTip(this.icontainer_0);
		this.tabControl1.SuspendLayout();
		this.tabPageSettingsGeneral.SuspendLayout();
		this.groupBox6.SuspendLayout();
		this.groupBox5.SuspendLayout();
		this.tabPageSettingsInterfaces.SuspendLayout();
		this.groupBox7.SuspendLayout();
		this.groupBox4.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.groupBox1.SuspendLayout();
		this.tabPageSettingsGraph.SuspendLayout();
		base.SuspendLayout();
		this.buttonOk.DialogResult = global::System.Windows.Forms.DialogResult.OK;
		this.buttonOk.Location = new global::System.Drawing.Point(448, 491);
		this.buttonOk.Name = "buttonOk";
		this.buttonOk.Size = new global::System.Drawing.Size(106, 27);
		this.buttonOk.TabIndex = 1;
		this.buttonOk.Tag = "8199";
		this.buttonOk.Text = "OK";
		this.buttonOk.UseVisualStyleBackColor = true;
		this.buttonOk.Click += new global::System.EventHandler(this.buttonOk_Click);
		this.buttonCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.buttonCancel.Location = new global::System.Drawing.Point(336, 491);
		this.buttonCancel.Name = "buttonCancel";
		this.buttonCancel.Size = new global::System.Drawing.Size(106, 27);
		this.buttonCancel.TabIndex = 2;
		this.buttonCancel.Tag = "8198";
		this.buttonCancel.Text = "Cancel";
		this.buttonCancel.UseVisualStyleBackColor = true;
		this.label5.AutoSize = true;
		this.label5.Location = new global::System.Drawing.Point(15, 62);
		this.label5.Name = "label5";
		this.label5.Size = new global::System.Drawing.Size(94, 16);
		this.label5.TabIndex = 12;
		this.label5.Tag = "8105";
		this.label5.Text = "Data Laguage";
		this.cbDataLang.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbDataLang.FormattingEnabled = true;
		this.cbDataLang.Items.AddRange(new object[]
		{
			"English"
		});
		this.cbDataLang.Location = new global::System.Drawing.Point(155, 59);
		this.cbDataLang.Name = "cbDataLang";
		this.cbDataLang.Size = new global::System.Drawing.Size(355, 24);
		this.cbDataLang.TabIndex = 1;
		this.cbDataLang.Tag = "8105";
		this.label4.AutoSize = true;
		this.label4.Location = new global::System.Drawing.Point(15, 32);
		this.label4.Name = "label4";
		this.label4.Size = new global::System.Drawing.Size(78, 16);
		this.label4.TabIndex = 10;
		this.label4.Tag = "8104";
		this.label4.Text = "UI Laguage";
		this.cbUILang.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbUILang.FormattingEnabled = true;
		this.cbUILang.Items.AddRange(new object[]
		{
			"English"
		});
		this.cbUILang.Location = new global::System.Drawing.Point(155, 29);
		this.cbUILang.Name = "cbUILang";
		this.cbUILang.Size = new global::System.Drawing.Size(355, 24);
		this.cbUILang.TabIndex = 0;
		this.cbUILang.Tag = "8104";
		this.cbUILang.SelectedIndexChanged += new global::System.EventHandler(this.cbUILang_SelectedIndexChanged);
		this.tabControl1.Controls.Add(this.tabPageSettingsGeneral);
		this.tabControl1.Controls.Add(this.tabPageSettingsInterfaces);
		this.tabControl1.Controls.Add(this.tabPageSettingsGraph);
		this.tabControl1.Location = new global::System.Drawing.Point(12, 12);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new global::System.Drawing.Size(546, 473);
		this.tabControl1.TabIndex = 0;
		this.tabPageSettingsGeneral.Controls.Add(this.groupBox6);
		this.tabPageSettingsGeneral.Controls.Add(this.groupBox5);
		this.tabPageSettingsGeneral.Location = new global::System.Drawing.Point(4, 25);
		this.tabPageSettingsGeneral.Name = "tabPageSettingsGeneral";
		this.tabPageSettingsGeneral.Padding = new global::System.Windows.Forms.Padding(3);
		this.tabPageSettingsGeneral.Size = new global::System.Drawing.Size(538, 444);
		this.tabPageSettingsGeneral.TabIndex = 0;
		this.tabPageSettingsGeneral.Text = "General";
		this.tabPageSettingsGeneral.UseVisualStyleBackColor = true;
		this.groupBox6.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.groupBox6.Controls.Add(this.cbCSVSeparator);
		this.groupBox6.Controls.Add(this.tbCSVFolder);
		this.groupBox6.Controls.Add(this.label13);
		this.groupBox6.Controls.Add(this.label7);
		this.groupBox6.Controls.Add(this.label17);
		this.groupBox6.Controls.Add(this.tbLogFolder);
		this.groupBox6.Location = new global::System.Drawing.Point(6, 313);
		this.groupBox6.Name = "groupBox6";
		this.groupBox6.Size = new global::System.Drawing.Size(526, 121);
		this.groupBox6.TabIndex = 44;
		this.groupBox6.TabStop = false;
		this.groupBox6.Tag = "8129";
		this.groupBox6.Text = " Export && Logging ";
		this.cbCSVSeparator.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbCSVSeparator.FormattingEnabled = true;
		this.cbCSVSeparator.Items.AddRange(new object[]
		{
			"Tab",
			";",
			","
		});
		this.cbCSVSeparator.Location = new global::System.Drawing.Point(154, 31);
		this.cbCSVSeparator.Name = "cbCSVSeparator";
		this.cbCSVSeparator.Size = new global::System.Drawing.Size(109, 24);
		this.cbCSVSeparator.TabIndex = 0;
		this.cbCSVSeparator.Tag = "8106";
		this.tbCSVFolder.Location = new global::System.Drawing.Point(154, 59);
		this.tbCSVFolder.Name = "tbCSVFolder";
		this.tbCSVFolder.Size = new global::System.Drawing.Size(355, 22);
		this.tbCSVFolder.TabIndex = 1;
		this.tbCSVFolder.Tag = "8107";
		this.label13.AutoSize = true;
		this.label13.Location = new global::System.Drawing.Point(14, 34);
		this.label13.Name = "label13";
		this.label13.Size = new global::System.Drawing.Size(98, 16);
		this.label13.TabIndex = 16;
		this.label13.Tag = "8106";
		this.label13.Text = "CSV Separator";
		this.label7.AutoSize = true;
		this.label7.Location = new global::System.Drawing.Point(14, 90);
		this.label7.Name = "label7";
		this.label7.Size = new global::System.Drawing.Size(77, 16);
		this.label7.TabIndex = 19;
		this.label7.Tag = "8108";
		this.label7.Text = "LOG Folder";
		this.label17.AutoSize = true;
		this.label17.Location = new global::System.Drawing.Point(14, 62);
		this.label17.Name = "label17";
		this.label17.Size = new global::System.Drawing.Size(77, 16);
		this.label17.TabIndex = 17;
		this.label17.Tag = "8107";
		this.label17.Text = "CSV Folder";
		this.tbLogFolder.Location = new global::System.Drawing.Point(154, 87);
		this.tbLogFolder.Name = "tbLogFolder";
		this.tbLogFolder.Size = new global::System.Drawing.Size(355, 22);
		this.tbLogFolder.TabIndex = 2;
		this.tbLogFolder.Tag = "8108";
		this.groupBox5.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.groupBox5.Controls.Add(this.buttonClearRecent);
		this.groupBox5.Controls.Add(this.cbScreenRepaint);
		this.groupBox5.Controls.Add(this.label28);
		this.groupBox5.Controls.Add(this.chkShowMiles);
		this.groupBox5.Controls.Add(this.chkShowAdapterMessage);
		this.groupBox5.Controls.Add(this.cbUILang);
		this.groupBox5.Controls.Add(this.buttonChangeUIF2);
		this.groupBox5.Controls.Add(this.label4);
		this.groupBox5.Controls.Add(this.lblUIF2);
		this.groupBox5.Controls.Add(this.cbDataLang);
		this.groupBox5.Controls.Add(this.label10);
		this.groupBox5.Controls.Add(this.label5);
		this.groupBox5.Controls.Add(this.buttonChangeUIF1);
		this.groupBox5.Controls.Add(this.label19);
		this.groupBox5.Controls.Add(this.lblUIF1);
		this.groupBox5.Location = new global::System.Drawing.Point(6, 5);
		this.groupBox5.Name = "groupBox5";
		this.groupBox5.Size = new global::System.Drawing.Size(526, 302);
		this.groupBox5.TabIndex = 43;
		this.groupBox5.TabStop = false;
		this.groupBox5.Tag = "8128";
		this.groupBox5.Text = " User Interface ";
		this.buttonClearRecent.Location = new global::System.Drawing.Point(18, 266);
		this.buttonClearRecent.Name = "buttonClearRecent";
		this.buttonClearRecent.Size = new global::System.Drawing.Size(492, 27);
		this.buttonClearRecent.TabIndex = 31;
		this.buttonClearRecent.Tag = "8134";
		this.buttonClearRecent.Text = "Clear \"Recent\" vehicles list";
		this.buttonClearRecent.UseVisualStyleBackColor = true;
		this.buttonClearRecent.Click += new global::System.EventHandler(this.buttonClearRecent_Click);
		this.cbScreenRepaint.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbScreenRepaint.FormattingEnabled = true;
		this.cbScreenRepaint.Items.AddRange(new object[]
		{
			"Fast",
			"Normal",
			"Slow"
		});
		this.cbScreenRepaint.Location = new global::System.Drawing.Point(155, 178);
		this.cbScreenRepaint.Name = "cbScreenRepaint";
		this.cbScreenRepaint.Size = new global::System.Drawing.Size(171, 24);
		this.cbScreenRepaint.TabIndex = 29;
		this.cbScreenRepaint.Tag = "8132";
		this.label28.AutoSize = true;
		this.label28.Location = new global::System.Drawing.Point(15, 181);
		this.label28.Name = "label28";
		this.label28.Size = new global::System.Drawing.Size(95, 16);
		this.label28.TabIndex = 30;
		this.label28.Tag = "8132";
		this.label28.Text = "Screen repaint";
		this.chkShowMiles.AutoSize = true;
		this.chkShowMiles.Location = new global::System.Drawing.Point(18, 240);
		this.chkShowMiles.Name = "chkShowMiles";
		this.chkShowMiles.Size = new global::System.Drawing.Size(190, 20);
		this.chkShowMiles.TabIndex = 28;
		this.chkShowMiles.Tag = "8131";
		this.chkShowMiles.Text = "Convert kilometers to miles";
		this.chkShowMiles.UseVisualStyleBackColor = true;
		this.chkShowAdapterMessage.AutoSize = true;
		this.chkShowAdapterMessage.Location = new global::System.Drawing.Point(18, 213);
		this.chkShowAdapterMessage.Name = "chkShowAdapterMessage";
		this.chkShowAdapterMessage.Size = new global::System.Drawing.Size(398, 20);
		this.chkShowAdapterMessage.TabIndex = 27;
		this.chkShowAdapterMessage.Tag = "8130";
		this.chkShowAdapterMessage.Text = "Show \"Please connect adapter...\" message before connecting";
		this.chkShowAdapterMessage.UseVisualStyleBackColor = true;
		this.buttonChangeUIF2.Location = new global::System.Drawing.Point(426, 134);
		this.buttonChangeUIF2.Name = "buttonChangeUIF2";
		this.buttonChangeUIF2.Size = new global::System.Drawing.Size(84, 27);
		this.buttonChangeUIF2.TabIndex = 3;
		this.buttonChangeUIF2.Tag = "8118";
		this.buttonChangeUIF2.Text = "Change";
		this.buttonChangeUIF2.UseVisualStyleBackColor = true;
		this.buttonChangeUIF2.Click += new global::System.EventHandler(this.buttonChangeUIF2_Click);
		this.lblUIF2.AutoSize = true;
		this.lblUIF2.Location = new global::System.Drawing.Point(151, 140);
		this.lblUIF2.Name = "lblUIF2";
		this.lblUIF2.Size = new global::System.Drawing.Size(59, 16);
		this.lblUIF2.TabIndex = 26;
		this.lblUIF2.Text = "Arial, 9pt";
		this.label10.AutoSize = true;
		this.label10.Location = new global::System.Drawing.Point(15, 139);
		this.label10.Name = "label10";
		this.label10.Size = new global::System.Drawing.Size(60, 16);
		this.label10.TabIndex = 25;
		this.label10.Tag = "8120";
		this.label10.Text = "UI Font 2";
		this.buttonChangeUIF1.Location = new global::System.Drawing.Point(426, 95);
		this.buttonChangeUIF1.Name = "buttonChangeUIF1";
		this.buttonChangeUIF1.Size = new global::System.Drawing.Size(84, 27);
		this.buttonChangeUIF1.TabIndex = 2;
		this.buttonChangeUIF1.Tag = "8118";
		this.buttonChangeUIF1.Text = "Change";
		this.buttonChangeUIF1.UseVisualStyleBackColor = true;
		this.buttonChangeUIF1.Click += new global::System.EventHandler(this.buttonChangeUIF1_Click);
		this.label19.AutoSize = true;
		this.label19.Location = new global::System.Drawing.Point(15, 100);
		this.label19.Name = "label19";
		this.label19.Size = new global::System.Drawing.Size(60, 16);
		this.label19.TabIndex = 23;
		this.label19.Tag = "8119";
		this.label19.Text = "UI Font 1";
		this.lblUIF1.AutoSize = true;
		this.lblUIF1.Location = new global::System.Drawing.Point(151, 101);
		this.lblUIF1.Name = "lblUIF1";
		this.lblUIF1.Size = new global::System.Drawing.Size(59, 16);
		this.lblUIF1.TabIndex = 24;
		this.lblUIF1.Text = "Arial, 9pt";
		this.tabPageSettingsInterfaces.Controls.Add(this.groupBox7);
		this.tabPageSettingsInterfaces.Controls.Add(this.buttonScanInterface);
		this.tabPageSettingsInterfaces.Controls.Add(this.groupBox4);
		this.tabPageSettingsInterfaces.Controls.Add(this.groupBox3);
		this.tabPageSettingsInterfaces.Controls.Add(this.groupBox2);
		this.tabPageSettingsInterfaces.Controls.Add(this.groupBox1);
		this.tabPageSettingsInterfaces.Controls.Add(this.chkShowAvailablePorts);
		this.tabPageSettingsInterfaces.Location = new global::System.Drawing.Point(4, 25);
		this.tabPageSettingsInterfaces.Name = "tabPageSettingsInterfaces";
		this.tabPageSettingsInterfaces.Padding = new global::System.Windows.Forms.Padding(3);
		this.tabPageSettingsInterfaces.Size = new global::System.Drawing.Size(538, 444);
		this.tabPageSettingsInterfaces.TabIndex = 2;
		this.tabPageSettingsInterfaces.Text = "Interfaces";
		this.tabPageSettingsInterfaces.UseVisualStyleBackColor = true;
		this.groupBox7.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.groupBox7.Controls.Add(this.chkHighLatency);
		this.groupBox7.Controls.Add(this.cbKWPTimings);
		this.groupBox7.Controls.Add(this.label8);
		this.groupBox7.Location = new global::System.Drawing.Point(6, 353);
		this.groupBox7.Name = "groupBox7";
		this.groupBox7.Size = new global::System.Drawing.Size(526, 50);
		this.groupBox7.TabIndex = 45;
		this.groupBox7.TabStop = false;
		this.groupBox7.Tag = string.Empty;
		this.groupBox7.Text = " K-Line / VAGCOM ";
		this.chkHighLatency.AutoSize = true;
		this.chkHighLatency.Location = new global::System.Drawing.Point(352, 21);
		this.chkHighLatency.Name = "chkHighLatency";
		this.chkHighLatency.Size = new global::System.Drawing.Size(142, 20);
		this.chkHighLatency.TabIndex = 40;
		this.chkHighLatency.Tag = "8133";
		this.chkHighLatency.Text = "High latency mode";
		this.chkHighLatency.UseVisualStyleBackColor = true;
		this.cbKWPTimings.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbKWPTimings.FormattingEnabled = true;
		this.cbKWPTimings.Items.AddRange(new object[]
		{
			"Default",
			"Optimal",
			"Fast",
			"Slow"
		});
		this.cbKWPTimings.Location = new global::System.Drawing.Point(156, 19);
		this.cbKWPTimings.Name = "cbKWPTimings";
		this.cbKWPTimings.Size = new global::System.Drawing.Size(142, 24);
		this.cbKWPTimings.TabIndex = 0;
		this.cbKWPTimings.Tag = "8122";
		this.label8.AutoSize = true;
		this.label8.Location = new global::System.Drawing.Point(16, 22);
		this.label8.Name = "label8";
		this.label8.Size = new global::System.Drawing.Size(117, 16);
		this.label8.TabIndex = 39;
		this.label8.Tag = "8122";
		this.label8.Text = "KWP2000 Timings";
		this.buttonScanInterface.Location = new global::System.Drawing.Point(322, 410);
		this.buttonScanInterface.Name = "buttonScanInterface";
		this.buttonScanInterface.Size = new global::System.Drawing.Size(211, 27);
		this.buttonScanInterface.TabIndex = 1;
		this.buttonScanInterface.Tag = "8127";
		this.buttonScanInterface.Text = "Scan Interfaces";
		this.buttonScanInterface.UseVisualStyleBackColor = true;
		this.buttonScanInterface.Click += new global::System.EventHandler(this.buttonScanInterface_Click);
		this.groupBox4.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.groupBox4.Controls.Add(this.buttonTest4);
		this.groupBox4.Controls.Add(this.label25);
		this.groupBox4.Controls.Add(this.cbSerialPort4);
		this.groupBox4.Controls.Add(this.label26);
		this.groupBox4.Controls.Add(this.cbInterfaceType4);
		this.groupBox4.Controls.Add(this.label27);
		this.groupBox4.Controls.Add(this.cbPortSpeed4);
		this.groupBox4.Location = new global::System.Drawing.Point(6, 267);
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.Size = new global::System.Drawing.Size(526, 80);
		this.groupBox4.TabIndex = 44;
		this.groupBox4.TabStop = false;
		this.groupBox4.Tag = "8126";
		this.groupBox4.Text = " Interface 4 ";
		this.buttonTest4.Location = new global::System.Drawing.Point(426, 18);
		this.buttonTest4.Name = "buttonTest4";
		this.buttonTest4.Size = new global::System.Drawing.Size(85, 27);
		this.buttonTest4.TabIndex = 2;
		this.buttonTest4.Tag = "8197";
		this.buttonTest4.Text = "Test";
		this.buttonTest4.UseVisualStyleBackColor = true;
		this.buttonTest4.Click += new global::System.EventHandler(this.buttonTest4_Click);
		this.label25.AutoSize = true;
		this.label25.Location = new global::System.Drawing.Point(16, 23);
		this.label25.Name = "label25";
		this.label25.Size = new global::System.Drawing.Size(88, 16);
		this.label25.TabIndex = 41;
		this.label25.Tag = "8101";
		this.label25.Text = "Interface type";
		this.cbSerialPort4.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbSerialPort4.FormattingEnabled = true;
		this.cbSerialPort4.Location = new global::System.Drawing.Point(156, 48);
		this.cbSerialPort4.Name = "cbSerialPort4";
		this.cbSerialPort4.Size = new global::System.Drawing.Size(109, 24);
		this.cbSerialPort4.TabIndex = 1;
		this.cbSerialPort4.Tag = "8102";
		this.label26.AutoSize = true;
		this.label26.Location = new global::System.Drawing.Point(16, 51);
		this.label26.Name = "label26";
		this.label26.Size = new global::System.Drawing.Size(69, 16);
		this.label26.TabIndex = 40;
		this.label26.Tag = "8102";
		this.label26.Text = "Serial port";
		this.cbInterfaceType4.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbInterfaceType4.FormattingEnabled = true;
		this.cbInterfaceType4.Items.AddRange(new object[]
		{
			"None",
			"K-Line / VAGCOM",
			"ELM 327 v1.3+",
			"ELM 327 v1.3+ (Bluetooth)",
			"OBDKey 1.40",
			"OBDKey 1.40 (Bluetooth)",
			"CANtieCAR (USB/Bluetooth)",
			"OBDLink (USB/Bluetooth)"
		});
		this.cbInterfaceType4.Location = new global::System.Drawing.Point(156, 20);
		this.cbInterfaceType4.Name = "cbInterfaceType4";
		this.cbInterfaceType4.Size = new global::System.Drawing.Size(239, 24);
		this.cbInterfaceType4.TabIndex = 0;
		this.cbInterfaceType4.Tag = "8101";
		this.cbInterfaceType4.SelectedIndexChanged += new global::System.EventHandler(this.cbInterfaceType_SelectedIndexChanged);
		this.label27.AutoSize = true;
		this.label27.Location = new global::System.Drawing.Point(300, 51);
		this.label27.Name = "label27";
		this.label27.Size = new global::System.Drawing.Size(74, 16);
		this.label27.TabIndex = 42;
		this.label27.Tag = "8103";
		this.label27.Text = "Port speed";
		this.cbPortSpeed4.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbPortSpeed4.FormattingEnabled = true;
		this.cbPortSpeed4.Items.AddRange(new object[]
		{
			"9600",
			"19200",
			"38400",
			"57600",
			"115200",
			"128000",
			"256000"
		});
		this.cbPortSpeed4.Location = new global::System.Drawing.Point(426, 48);
		this.cbPortSpeed4.Name = "cbPortSpeed4";
		this.cbPortSpeed4.Size = new global::System.Drawing.Size(85, 24);
		this.cbPortSpeed4.TabIndex = 3;
		this.cbPortSpeed4.Tag = "8103";
		this.groupBox3.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.groupBox3.Controls.Add(this.buttonTest3);
		this.groupBox3.Controls.Add(this.label22);
		this.groupBox3.Controls.Add(this.cbSerialPort3);
		this.groupBox3.Controls.Add(this.label23);
		this.groupBox3.Controls.Add(this.cbInterfaceType3);
		this.groupBox3.Controls.Add(this.label24);
		this.groupBox3.Controls.Add(this.cbPortSpeed3);
		this.groupBox3.Location = new global::System.Drawing.Point(6, 181);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Size = new global::System.Drawing.Size(526, 80);
		this.groupBox3.TabIndex = 44;
		this.groupBox3.TabStop = false;
		this.groupBox3.Tag = "8125";
		this.groupBox3.Text = " Interface 3 ";
		this.buttonTest3.Location = new global::System.Drawing.Point(426, 18);
		this.buttonTest3.Name = "buttonTest3";
		this.buttonTest3.Size = new global::System.Drawing.Size(85, 27);
		this.buttonTest3.TabIndex = 2;
		this.buttonTest3.Tag = "8197";
		this.buttonTest3.Text = "Test";
		this.buttonTest3.UseVisualStyleBackColor = true;
		this.buttonTest3.Click += new global::System.EventHandler(this.buttonTest3_Click);
		this.label22.AutoSize = true;
		this.label22.Location = new global::System.Drawing.Point(16, 23);
		this.label22.Name = "label22";
		this.label22.Size = new global::System.Drawing.Size(88, 16);
		this.label22.TabIndex = 41;
		this.label22.Tag = "8101";
		this.label22.Text = "Interface type";
		this.cbSerialPort3.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbSerialPort3.FormattingEnabled = true;
		this.cbSerialPort3.Location = new global::System.Drawing.Point(156, 48);
		this.cbSerialPort3.Name = "cbSerialPort3";
		this.cbSerialPort3.Size = new global::System.Drawing.Size(109, 24);
		this.cbSerialPort3.TabIndex = 1;
		this.cbSerialPort3.Tag = "8102";
		this.label23.AutoSize = true;
		this.label23.Location = new global::System.Drawing.Point(16, 51);
		this.label23.Name = "label23";
		this.label23.Size = new global::System.Drawing.Size(69, 16);
		this.label23.TabIndex = 40;
		this.label23.Tag = "8102";
		this.label23.Text = "Serial port";
		this.cbInterfaceType3.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbInterfaceType3.FormattingEnabled = true;
		this.cbInterfaceType3.Items.AddRange(new object[]
		{
			"None",
			"K-Line / VAGCOM",
			"ELM 327 v1.3+",
			"ELM 327 v1.3+ (Bluetooth)",
			"OBDKey 1.40",
			"OBDKey 1.40 (Bluetooth)",
			"CANtieCAR (USB/Bluetooth)",
			"OBDLink (USB/Bluetooth)"
		});
		this.cbInterfaceType3.Location = new global::System.Drawing.Point(156, 20);
		this.cbInterfaceType3.Name = "cbInterfaceType3";
		this.cbInterfaceType3.Size = new global::System.Drawing.Size(239, 24);
		this.cbInterfaceType3.TabIndex = 0;
		this.cbInterfaceType3.Tag = "8101";
		this.cbInterfaceType3.SelectedIndexChanged += new global::System.EventHandler(this.cbInterfaceType_SelectedIndexChanged);
		this.label24.AutoSize = true;
		this.label24.Location = new global::System.Drawing.Point(300, 51);
		this.label24.Name = "label24";
		this.label24.Size = new global::System.Drawing.Size(74, 16);
		this.label24.TabIndex = 42;
		this.label24.Tag = "8103";
		this.label24.Text = "Port speed";
		this.cbPortSpeed3.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbPortSpeed3.FormattingEnabled = true;
		this.cbPortSpeed3.Items.AddRange(new object[]
		{
			"9600",
			"19200",
			"38400",
			"57600",
			"115200",
			"128000",
			"256000"
		});
		this.cbPortSpeed3.Location = new global::System.Drawing.Point(426, 48);
		this.cbPortSpeed3.Name = "cbPortSpeed3";
		this.cbPortSpeed3.Size = new global::System.Drawing.Size(85, 24);
		this.cbPortSpeed3.TabIndex = 3;
		this.cbPortSpeed3.Tag = "8103";
		this.groupBox2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.groupBox2.Controls.Add(this.buttonTest2);
		this.groupBox2.Controls.Add(this.label18);
		this.groupBox2.Controls.Add(this.cbSerialPort2);
		this.groupBox2.Controls.Add(this.label20);
		this.groupBox2.Controls.Add(this.cbInterfaceType2);
		this.groupBox2.Controls.Add(this.label21);
		this.groupBox2.Controls.Add(this.cbPortSpeed2);
		this.groupBox2.Location = new global::System.Drawing.Point(6, 95);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new global::System.Drawing.Size(526, 80);
		this.groupBox2.TabIndex = 43;
		this.groupBox2.TabStop = false;
		this.groupBox2.Tag = "8124";
		this.groupBox2.Text = " Interface 2 ";
		this.buttonTest2.Location = new global::System.Drawing.Point(426, 18);
		this.buttonTest2.Name = "buttonTest2";
		this.buttonTest2.Size = new global::System.Drawing.Size(85, 27);
		this.buttonTest2.TabIndex = 2;
		this.buttonTest2.Tag = "8197";
		this.buttonTest2.Text = "Test";
		this.buttonTest2.UseVisualStyleBackColor = true;
		this.buttonTest2.Click += new global::System.EventHandler(this.buttonTest2_Click);
		this.label18.AutoSize = true;
		this.label18.Location = new global::System.Drawing.Point(16, 23);
		this.label18.Name = "label18";
		this.label18.Size = new global::System.Drawing.Size(88, 16);
		this.label18.TabIndex = 41;
		this.label18.Tag = "8101";
		this.label18.Text = "Interface type";
		this.cbSerialPort2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbSerialPort2.FormattingEnabled = true;
		this.cbSerialPort2.Location = new global::System.Drawing.Point(156, 48);
		this.cbSerialPort2.Name = "cbSerialPort2";
		this.cbSerialPort2.Size = new global::System.Drawing.Size(109, 24);
		this.cbSerialPort2.TabIndex = 1;
		this.cbSerialPort2.Tag = "8102";
		this.label20.AutoSize = true;
		this.label20.Location = new global::System.Drawing.Point(16, 51);
		this.label20.Name = "label20";
		this.label20.Size = new global::System.Drawing.Size(69, 16);
		this.label20.TabIndex = 40;
		this.label20.Tag = "8102";
		this.label20.Text = "Serial port";
		this.cbInterfaceType2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbInterfaceType2.FormattingEnabled = true;
		this.cbInterfaceType2.Items.AddRange(new object[]
		{
			"None",
			"K-Line / VAGCOM",
			"ELM 327 v1.3+",
			"ELM 327 v1.3+ (Bluetooth)",
			"OBDKey 1.40",
			"OBDKey 1.40 (Bluetooth)",
			"CANtieCAR (USB/Bluetooth)",
			"OBDLink (USB/Bluetooth)"
		});
		this.cbInterfaceType2.Location = new global::System.Drawing.Point(156, 20);
		this.cbInterfaceType2.Name = "cbInterfaceType2";
		this.cbInterfaceType2.Size = new global::System.Drawing.Size(239, 24);
		this.cbInterfaceType2.TabIndex = 0;
		this.cbInterfaceType2.Tag = "8101";
		this.cbInterfaceType2.SelectedIndexChanged += new global::System.EventHandler(this.cbInterfaceType_SelectedIndexChanged);
		this.label21.AutoSize = true;
		this.label21.Location = new global::System.Drawing.Point(300, 51);
		this.label21.Name = "label21";
		this.label21.Size = new global::System.Drawing.Size(74, 16);
		this.label21.TabIndex = 42;
		this.label21.Tag = "8103";
		this.label21.Text = "Port speed";
		this.cbPortSpeed2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbPortSpeed2.FormattingEnabled = true;
		this.cbPortSpeed2.Items.AddRange(new object[]
		{
			"9600",
			"19200",
			"38400",
			"57600",
			"115200",
			"128000",
			"256000"
		});
		this.cbPortSpeed2.Location = new global::System.Drawing.Point(426, 48);
		this.cbPortSpeed2.Name = "cbPortSpeed2";
		this.cbPortSpeed2.Size = new global::System.Drawing.Size(85, 24);
		this.cbPortSpeed2.TabIndex = 3;
		this.cbPortSpeed2.Tag = "8103";
		this.groupBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.groupBox1.Controls.Add(this.buttonTest);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.cbSerialPort);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Controls.Add(this.cbInterfaceType);
		this.groupBox1.Controls.Add(this.label3);
		this.groupBox1.Controls.Add(this.cbPortSpeed);
		this.groupBox1.Location = new global::System.Drawing.Point(6, 9);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new global::System.Drawing.Size(526, 80);
		this.groupBox1.TabIndex = 42;
		this.groupBox1.TabStop = false;
		this.groupBox1.Tag = "8123";
		this.groupBox1.Text = " Interface 1 ";
		this.buttonTest.Location = new global::System.Drawing.Point(426, 18);
		this.buttonTest.Name = "buttonTest";
		this.buttonTest.Size = new global::System.Drawing.Size(85, 27);
		this.buttonTest.TabIndex = 2;
		this.buttonTest.Tag = "8197";
		this.buttonTest.Text = "Test";
		this.buttonTest.UseVisualStyleBackColor = true;
		this.buttonTest.Click += new global::System.EventHandler(this.buttonTest_Click);
		this.label2.AutoSize = true;
		this.label2.Location = new global::System.Drawing.Point(16, 23);
		this.label2.Name = "label2";
		this.label2.Size = new global::System.Drawing.Size(88, 16);
		this.label2.TabIndex = 41;
		this.label2.Tag = "8101";
		this.label2.Text = "Interface type";
		this.cbSerialPort.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbSerialPort.FormattingEnabled = true;
		this.cbSerialPort.Location = new global::System.Drawing.Point(156, 48);
		this.cbSerialPort.Name = "cbSerialPort";
		this.cbSerialPort.Size = new global::System.Drawing.Size(109, 24);
		this.cbSerialPort.TabIndex = 1;
		this.cbSerialPort.Tag = "8102";
		this.label1.AutoSize = true;
		this.label1.Location = new global::System.Drawing.Point(16, 51);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(69, 16);
		this.label1.TabIndex = 40;
		this.label1.Tag = "8102";
		this.label1.Text = "Serial port";
		this.cbInterfaceType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbInterfaceType.FormattingEnabled = true;
		this.cbInterfaceType.Items.AddRange(new object[]
		{
			"None",
			"K-Line / VAGCOM",
			"ELM 327 v1.3+",
			"ELM 327 v1.3+ (Bluetooth)",
			"OBDKey 1.40",
			"OBDKey 1.40 (Bluetooth)",
			"CANtieCAR (USB/Bluetooth)",
			"OBDLink (USB/Bluetooth)"
		});
		this.cbInterfaceType.Location = new global::System.Drawing.Point(156, 20);
		this.cbInterfaceType.Name = "cbInterfaceType";
		this.cbInterfaceType.Size = new global::System.Drawing.Size(239, 24);
		this.cbInterfaceType.TabIndex = 0;
		this.cbInterfaceType.Tag = "8101";
		this.cbInterfaceType.SelectedIndexChanged += new global::System.EventHandler(this.cbInterfaceType_SelectedIndexChanged);
		this.label3.AutoSize = true;
		this.label3.Location = new global::System.Drawing.Point(300, 51);
		this.label3.Name = "label3";
		this.label3.Size = new global::System.Drawing.Size(74, 16);
		this.label3.TabIndex = 42;
		this.label3.Tag = "8103";
		this.label3.Text = "Port speed";
		this.cbPortSpeed.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbPortSpeed.FormattingEnabled = true;
		this.cbPortSpeed.Items.AddRange(new object[]
		{
			"9600",
			"19200",
			"38400",
			"57600",
			"115200",
			"128000",
			"256000"
		});
		this.cbPortSpeed.Location = new global::System.Drawing.Point(426, 48);
		this.cbPortSpeed.Name = "cbPortSpeed";
		this.cbPortSpeed.Size = new global::System.Drawing.Size(85, 24);
		this.cbPortSpeed.TabIndex = 3;
		this.cbPortSpeed.Tag = "8103";
		this.chkShowAvailablePorts.AutoSize = true;
		this.chkShowAvailablePorts.Location = new global::System.Drawing.Point(9, 418);
		this.chkShowAvailablePorts.Name = "chkShowAvailablePorts";
		this.chkShowAvailablePorts.Size = new global::System.Drawing.Size(183, 20);
		this.chkShowAvailablePorts.TabIndex = 0;
		this.chkShowAvailablePorts.Tag = "8121";
		this.chkShowAvailablePorts.Text = "Show available ports only";
		this.chkShowAvailablePorts.UseVisualStyleBackColor = true;
		this.tabPageSettingsGraph.Controls.Add(this.cbLineThickness);
		this.tabPageSettingsGraph.Controls.Add(this.label12);
		this.tabPageSettingsGraph.Controls.Add(this.buttonChangePF);
		this.tabPageSettingsGraph.Controls.Add(this.lblPF);
		this.tabPageSettingsGraph.Controls.Add(this.label11);
		this.tabPageSettingsGraph.Controls.Add(this.buttonChangeXF);
		this.tabPageSettingsGraph.Controls.Add(this.lblXF);
		this.tabPageSettingsGraph.Controls.Add(this.label9);
		this.tabPageSettingsGraph.Controls.Add(this.buttonChangeYF);
		this.tabPageSettingsGraph.Controls.Add(this.lblYF);
		this.tabPageSettingsGraph.Controls.Add(this.label6);
		this.tabPageSettingsGraph.Controls.Add(this.label16);
		this.tabPageSettingsGraph.Controls.Add(this.panelGC);
		this.tabPageSettingsGraph.Controls.Add(this.label15);
		this.tabPageSettingsGraph.Controls.Add(this.panelBC);
		this.tabPageSettingsGraph.Controls.Add(this.panelGC8);
		this.tabPageSettingsGraph.Controls.Add(this.panelGC7);
		this.tabPageSettingsGraph.Controls.Add(this.panelGC6);
		this.tabPageSettingsGraph.Controls.Add(this.panelGC5);
		this.tabPageSettingsGraph.Controls.Add(this.panelGC4);
		this.tabPageSettingsGraph.Controls.Add(this.panelGC3);
		this.tabPageSettingsGraph.Controls.Add(this.panelGC2);
		this.tabPageSettingsGraph.Controls.Add(this.panelGC1);
		this.tabPageSettingsGraph.Controls.Add(this.label14);
		this.tabPageSettingsGraph.Location = new global::System.Drawing.Point(4, 25);
		this.tabPageSettingsGraph.Name = "tabPageSettingsGraph";
		this.tabPageSettingsGraph.Padding = new global::System.Windows.Forms.Padding(3);
		this.tabPageSettingsGraph.Size = new global::System.Drawing.Size(538, 444);
		this.tabPageSettingsGraph.TabIndex = 1;
		this.tabPageSettingsGraph.Text = "Graph";
		this.tabPageSettingsGraph.UseVisualStyleBackColor = true;
		this.cbLineThickness.FormattingEnabled = true;
		this.cbLineThickness.Items.AddRange(new object[]
		{
			"1",
			"2",
			"3",
			"4"
		});
		this.cbLineThickness.Location = new global::System.Drawing.Point(226, 212);
		this.cbLineThickness.Name = "cbLineThickness";
		this.cbLineThickness.Size = new global::System.Drawing.Size(66, 24);
		this.cbLineThickness.TabIndex = 3;
		this.label12.AutoSize = true;
		this.label12.Location = new global::System.Drawing.Point(20, 215);
		this.label12.Name = "label12";
		this.label12.Size = new global::System.Drawing.Size(98, 16);
		this.label12.TabIndex = 17;
		this.label12.Tag = "8117";
		this.label12.Text = "Line Thickness";
		this.buttonChangePF.Location = new global::System.Drawing.Point(423, 174);
		this.buttonChangePF.Name = "buttonChangePF";
		this.buttonChangePF.Size = new global::System.Drawing.Size(84, 27);
		this.buttonChangePF.TabIndex = 2;
		this.buttonChangePF.Tag = "8118";
		this.buttonChangePF.Text = "Change";
		this.buttonChangePF.UseVisualStyleBackColor = true;
		this.buttonChangePF.Click += new global::System.EventHandler(this.buttonChangePF_Click);
		this.lblPF.AutoSize = true;
		this.lblPF.Location = new global::System.Drawing.Point(226, 179);
		this.lblPF.Name = "lblPF";
		this.lblPF.Size = new global::System.Drawing.Size(59, 16);
		this.lblPF.TabIndex = 15;
		this.lblPF.Text = "Arial, 9pt";
		this.label11.AutoSize = true;
		this.label11.Location = new global::System.Drawing.Point(20, 179);
		this.label11.Name = "label11";
		this.label11.Size = new global::System.Drawing.Size(100, 16);
		this.label11.TabIndex = 14;
		this.label11.Tag = "8116";
		this.label11.Text = "Parameter Font";
		this.buttonChangeXF.Location = new global::System.Drawing.Point(423, 141);
		this.buttonChangeXF.Name = "buttonChangeXF";
		this.buttonChangeXF.Size = new global::System.Drawing.Size(84, 27);
		this.buttonChangeXF.TabIndex = 1;
		this.buttonChangeXF.Tag = "8118";
		this.buttonChangeXF.Text = "Change";
		this.buttonChangeXF.UseVisualStyleBackColor = true;
		this.buttonChangeXF.Click += new global::System.EventHandler(this.buttonChangeXF_Click);
		this.lblXF.AutoSize = true;
		this.lblXF.Location = new global::System.Drawing.Point(226, 146);
		this.lblXF.Name = "lblXF";
		this.lblXF.Size = new global::System.Drawing.Size(59, 16);
		this.lblXF.TabIndex = 12;
		this.lblXF.Text = "Arial, 9pt";
		this.label9.AutoSize = true;
		this.label9.Location = new global::System.Drawing.Point(20, 146);
		this.label9.Name = "label9";
		this.label9.Size = new global::System.Drawing.Size(74, 16);
		this.label9.TabIndex = 11;
		this.label9.Tag = "8115";
		this.label9.Text = "X-Axis Font";
		this.buttonChangeYF.Location = new global::System.Drawing.Point(423, 108);
		this.buttonChangeYF.Name = "buttonChangeYF";
		this.buttonChangeYF.Size = new global::System.Drawing.Size(84, 27);
		this.buttonChangeYF.TabIndex = 0;
		this.buttonChangeYF.Tag = "8118";
		this.buttonChangeYF.Text = "Change";
		this.buttonChangeYF.UseVisualStyleBackColor = true;
		this.buttonChangeYF.Click += new global::System.EventHandler(this.buttonChangeYF_Click);
		this.lblYF.AutoSize = true;
		this.lblYF.Location = new global::System.Drawing.Point(226, 113);
		this.lblYF.Name = "lblYF";
		this.lblYF.Size = new global::System.Drawing.Size(59, 16);
		this.lblYF.TabIndex = 9;
		this.lblYF.Text = "Arial, 9pt";
		this.label6.AutoSize = true;
		this.label6.Location = new global::System.Drawing.Point(20, 113);
		this.label6.Name = "label6";
		this.label6.Size = new global::System.Drawing.Size(75, 16);
		this.label6.TabIndex = 8;
		this.label6.Tag = "8114";
		this.label6.Text = "Y-Axis Font";
		this.label16.AutoSize = true;
		this.label16.Location = new global::System.Drawing.Point(20, 82);
		this.label16.Name = "label16";
		this.label16.Size = new global::System.Drawing.Size(68, 16);
		this.label16.TabIndex = 7;
		this.label16.Tag = "8113";
		this.label16.Text = "Grid Color";
		this.panelGC.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panelGC.Location = new global::System.Drawing.Point(226, 80);
		this.panelGC.Name = "panelGC";
		this.panelGC.Size = new global::System.Drawing.Size(30, 24);
		this.panelGC.TabIndex = 6;
		this.panelGC.Click += new global::System.EventHandler(this.panelGC1_Click);
		this.label15.AutoSize = true;
		this.label15.Location = new global::System.Drawing.Point(20, 52);
		this.label15.Name = "label15";
		this.label15.Size = new global::System.Drawing.Size(116, 16);
		this.label15.TabIndex = 5;
		this.label15.Tag = "8112";
		this.label15.Text = "Background Color";
		this.panelBC.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panelBC.Location = new global::System.Drawing.Point(226, 50);
		this.panelBC.Name = "panelBC";
		this.panelBC.Size = new global::System.Drawing.Size(30, 24);
		this.panelBC.TabIndex = 4;
		this.panelBC.Click += new global::System.EventHandler(this.panelGC1_Click);
		this.panelGC8.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panelGC8.Location = new global::System.Drawing.Point(477, 20);
		this.panelGC8.Name = "panelGC8";
		this.panelGC8.Size = new global::System.Drawing.Size(30, 24);
		this.panelGC8.TabIndex = 4;
		this.panelGC8.Click += new global::System.EventHandler(this.panelGC1_Click);
		this.panelGC7.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panelGC7.Location = new global::System.Drawing.Point(442, 20);
		this.panelGC7.Name = "panelGC7";
		this.panelGC7.Size = new global::System.Drawing.Size(30, 24);
		this.panelGC7.TabIndex = 4;
		this.panelGC7.Click += new global::System.EventHandler(this.panelGC1_Click);
		this.panelGC6.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panelGC6.Location = new global::System.Drawing.Point(406, 20);
		this.panelGC6.Name = "panelGC6";
		this.panelGC6.Size = new global::System.Drawing.Size(30, 24);
		this.panelGC6.TabIndex = 4;
		this.panelGC6.Click += new global::System.EventHandler(this.panelGC1_Click);
		this.panelGC5.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panelGC5.Location = new global::System.Drawing.Point(370, 20);
		this.panelGC5.Name = "panelGC5";
		this.panelGC5.Size = new global::System.Drawing.Size(30, 24);
		this.panelGC5.TabIndex = 4;
		this.panelGC5.Click += new global::System.EventHandler(this.panelGC1_Click);
		this.panelGC4.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panelGC4.Location = new global::System.Drawing.Point(334, 20);
		this.panelGC4.Name = "panelGC4";
		this.panelGC4.Size = new global::System.Drawing.Size(30, 24);
		this.panelGC4.TabIndex = 4;
		this.panelGC4.Click += new global::System.EventHandler(this.panelGC1_Click);
		this.panelGC3.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panelGC3.Location = new global::System.Drawing.Point(298, 20);
		this.panelGC3.Name = "panelGC3";
		this.panelGC3.Size = new global::System.Drawing.Size(30, 24);
		this.panelGC3.TabIndex = 4;
		this.panelGC3.Click += new global::System.EventHandler(this.panelGC1_Click);
		this.panelGC2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panelGC2.Location = new global::System.Drawing.Point(262, 20);
		this.panelGC2.Name = "panelGC2";
		this.panelGC2.Size = new global::System.Drawing.Size(30, 24);
		this.panelGC2.TabIndex = 4;
		this.panelGC2.Click += new global::System.EventHandler(this.panelGC1_Click);
		this.panelGC1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panelGC1.Location = new global::System.Drawing.Point(226, 20);
		this.panelGC1.Name = "panelGC1";
		this.panelGC1.Size = new global::System.Drawing.Size(30, 24);
		this.panelGC1.TabIndex = 3;
		this.panelGC1.Click += new global::System.EventHandler(this.panelGC1_Click);
		this.label14.AutoSize = true;
		this.label14.Location = new global::System.Drawing.Point(20, 24);
		this.label14.Name = "label14";
		this.label14.Size = new global::System.Drawing.Size(113, 16);
		this.label14.TabIndex = 2;
		this.label14.Tag = "8111";
		this.label14.Text = "Parameter Colors";
		this.toolTip_0.AutoPopDelay = 20000;
		this.toolTip_0.InitialDelay = 500;
		this.toolTip_0.IsBalloon = true;
		this.toolTip_0.ReshowDelay = 100;
		base.AcceptButton = this.buttonOk;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.buttonCancel;
		base.ClientSize = new global::System.Drawing.Size(570, 525);
		base.Controls.Add(this.tabControl1);
		base.Controls.Add(this.buttonCancel);
		base.Controls.Add(this.buttonOk);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Name = "FormSettings";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Settings";
		base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
		this.tabControl1.ResumeLayout(false);
		this.tabPageSettingsGeneral.ResumeLayout(false);
		this.groupBox6.ResumeLayout(false);
		this.groupBox6.PerformLayout();
		this.groupBox5.ResumeLayout(false);
		this.groupBox5.PerformLayout();
		this.tabPageSettingsInterfaces.ResumeLayout(false);
		this.tabPageSettingsInterfaces.PerformLayout();
		this.groupBox7.ResumeLayout(false);
		this.groupBox7.PerformLayout();
		this.groupBox4.ResumeLayout(false);
		this.groupBox4.PerformLayout();
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.tabPageSettingsGraph.ResumeLayout(false);
		this.tabPageSettingsGraph.PerformLayout();
		base.ResumeLayout(false);
	}

	// Token: 0x04000415 RID: 1045
	private global::System.ComponentModel.IContainer icontainer_0 = null;

	// Token: 0x04000416 RID: 1046
	private global::System.Windows.Forms.Button buttonOk;

	// Token: 0x04000417 RID: 1047
	private global::System.Windows.Forms.Button buttonCancel;

	// Token: 0x04000418 RID: 1048
	private global::System.Windows.Forms.Label label4;

	// Token: 0x04000419 RID: 1049
	private global::System.Windows.Forms.ComboBox cbUILang;

	// Token: 0x0400041A RID: 1050
	private global::System.Windows.Forms.Label label5;

	// Token: 0x0400041B RID: 1051
	private global::System.Windows.Forms.ComboBox cbDataLang;

	// Token: 0x0400041C RID: 1052
	private global::System.Windows.Forms.TabControl tabControl1;

	// Token: 0x0400041D RID: 1053
	private global::System.Windows.Forms.TabPage tabPageSettingsGeneral;

	// Token: 0x0400041E RID: 1054
	private global::System.Windows.Forms.TabPage tabPageSettingsGraph;

	// Token: 0x0400041F RID: 1055
	private global::System.Windows.Forms.Panel panelGC8;

	// Token: 0x04000420 RID: 1056
	private global::System.Windows.Forms.Panel panelGC7;

	// Token: 0x04000421 RID: 1057
	private global::System.Windows.Forms.Panel panelGC6;

	// Token: 0x04000422 RID: 1058
	private global::System.Windows.Forms.Panel panelGC5;

	// Token: 0x04000423 RID: 1059
	private global::System.Windows.Forms.Panel panelGC4;

	// Token: 0x04000424 RID: 1060
	private global::System.Windows.Forms.Panel panelGC3;

	// Token: 0x04000425 RID: 1061
	private global::System.Windows.Forms.Panel panelGC2;

	// Token: 0x04000426 RID: 1062
	private global::System.Windows.Forms.Panel panelGC1;

	// Token: 0x04000427 RID: 1063
	private global::System.Windows.Forms.Label label14;

	// Token: 0x04000428 RID: 1064
	private global::System.Windows.Forms.Label label16;

	// Token: 0x04000429 RID: 1065
	private global::System.Windows.Forms.Panel panelGC;

	// Token: 0x0400042A RID: 1066
	private global::System.Windows.Forms.Label label15;

	// Token: 0x0400042B RID: 1067
	private global::System.Windows.Forms.Panel panelBC;

	// Token: 0x0400042C RID: 1068
	private global::System.Windows.Forms.Label label6;

	// Token: 0x0400042D RID: 1069
	private global::System.Windows.Forms.ComboBox cbLineThickness;

	// Token: 0x0400042E RID: 1070
	private global::System.Windows.Forms.Label label12;

	// Token: 0x0400042F RID: 1071
	private global::System.Windows.Forms.Button buttonChangePF;

	// Token: 0x04000430 RID: 1072
	private global::System.Windows.Forms.Label lblPF;

	// Token: 0x04000431 RID: 1073
	private global::System.Windows.Forms.Label label11;

	// Token: 0x04000432 RID: 1074
	private global::System.Windows.Forms.Button buttonChangeXF;

	// Token: 0x04000433 RID: 1075
	private global::System.Windows.Forms.Label lblXF;

	// Token: 0x04000434 RID: 1076
	private global::System.Windows.Forms.Label label9;

	// Token: 0x04000435 RID: 1077
	private global::System.Windows.Forms.Button buttonChangeYF;

	// Token: 0x04000436 RID: 1078
	private global::System.Windows.Forms.Label lblYF;

	// Token: 0x04000437 RID: 1079
	private global::System.Windows.Forms.Label label17;

	// Token: 0x04000438 RID: 1080
	private global::System.Windows.Forms.Label label13;

	// Token: 0x04000439 RID: 1081
	private global::System.Windows.Forms.TextBox tbCSVFolder;

	// Token: 0x0400043A RID: 1082
	private global::System.Windows.Forms.FontDialog fontDialog_0;

	// Token: 0x0400043B RID: 1083
	private global::System.Windows.Forms.ColorDialog colorDialog_0;

	// Token: 0x0400043C RID: 1084
	private global::System.Windows.Forms.Label label7;

	// Token: 0x0400043D RID: 1085
	private global::System.Windows.Forms.TextBox tbLogFolder;

	// Token: 0x0400043E RID: 1086
	private global::System.Windows.Forms.ComboBox cbCSVSeparator;

	// Token: 0x0400043F RID: 1087
	private global::System.Windows.Forms.Button buttonChangeUIF2;

	// Token: 0x04000440 RID: 1088
	private global::System.Windows.Forms.Label lblUIF2;

	// Token: 0x04000441 RID: 1089
	private global::System.Windows.Forms.Label label10;

	// Token: 0x04000442 RID: 1090
	private global::System.Windows.Forms.Button buttonChangeUIF1;

	// Token: 0x04000443 RID: 1091
	private global::System.Windows.Forms.Label lblUIF1;

	// Token: 0x04000444 RID: 1092
	private global::System.Windows.Forms.Label label19;

	// Token: 0x04000445 RID: 1093
	private global::System.Windows.Forms.TabPage tabPageSettingsInterfaces;

	// Token: 0x04000446 RID: 1094
	private global::System.Windows.Forms.Label label8;

	// Token: 0x04000447 RID: 1095
	private global::System.Windows.Forms.ComboBox cbKWPTimings;

	// Token: 0x04000448 RID: 1096
	private global::System.Windows.Forms.CheckBox chkShowAvailablePorts;

	// Token: 0x04000449 RID: 1097
	private global::System.Windows.Forms.GroupBox groupBox1;

	// Token: 0x0400044A RID: 1098
	private global::System.Windows.Forms.Button buttonTest;

	// Token: 0x0400044B RID: 1099
	private global::System.Windows.Forms.Label label2;

	// Token: 0x0400044C RID: 1100
	private global::System.Windows.Forms.ComboBox cbSerialPort;

	// Token: 0x0400044D RID: 1101
	private global::System.Windows.Forms.Label label1;

	// Token: 0x0400044E RID: 1102
	private global::System.Windows.Forms.ComboBox cbInterfaceType;

	// Token: 0x0400044F RID: 1103
	private global::System.Windows.Forms.Label label3;

	// Token: 0x04000450 RID: 1104
	private global::System.Windows.Forms.ComboBox cbPortSpeed;

	// Token: 0x04000451 RID: 1105
	private global::System.Windows.Forms.GroupBox groupBox4;

	// Token: 0x04000452 RID: 1106
	private global::System.Windows.Forms.Button buttonTest4;

	// Token: 0x04000453 RID: 1107
	private global::System.Windows.Forms.Label label25;

	// Token: 0x04000454 RID: 1108
	private global::System.Windows.Forms.ComboBox cbSerialPort4;

	// Token: 0x04000455 RID: 1109
	private global::System.Windows.Forms.Label label26;

	// Token: 0x04000456 RID: 1110
	private global::System.Windows.Forms.ComboBox cbInterfaceType4;

	// Token: 0x04000457 RID: 1111
	private global::System.Windows.Forms.Label label27;

	// Token: 0x04000458 RID: 1112
	private global::System.Windows.Forms.ComboBox cbPortSpeed4;

	// Token: 0x04000459 RID: 1113
	private global::System.Windows.Forms.GroupBox groupBox3;

	// Token: 0x0400045A RID: 1114
	private global::System.Windows.Forms.Button buttonTest3;

	// Token: 0x0400045B RID: 1115
	private global::System.Windows.Forms.Label label22;

	// Token: 0x0400045C RID: 1116
	private global::System.Windows.Forms.ComboBox cbSerialPort3;

	// Token: 0x0400045D RID: 1117
	private global::System.Windows.Forms.Label label23;

	// Token: 0x0400045E RID: 1118
	private global::System.Windows.Forms.ComboBox cbInterfaceType3;

	// Token: 0x0400045F RID: 1119
	private global::System.Windows.Forms.Label label24;

	// Token: 0x04000460 RID: 1120
	private global::System.Windows.Forms.ComboBox cbPortSpeed3;

	// Token: 0x04000461 RID: 1121
	private global::System.Windows.Forms.GroupBox groupBox2;

	// Token: 0x04000462 RID: 1122
	private global::System.Windows.Forms.Button buttonTest2;

	// Token: 0x04000463 RID: 1123
	private global::System.Windows.Forms.Label label18;

	// Token: 0x04000464 RID: 1124
	private global::System.Windows.Forms.ComboBox cbSerialPort2;

	// Token: 0x04000465 RID: 1125
	private global::System.Windows.Forms.Label label20;

	// Token: 0x04000466 RID: 1126
	private global::System.Windows.Forms.ComboBox cbInterfaceType2;

	// Token: 0x04000467 RID: 1127
	private global::System.Windows.Forms.Label label21;

	// Token: 0x04000468 RID: 1128
	private global::System.Windows.Forms.ComboBox cbPortSpeed2;

	// Token: 0x04000469 RID: 1129
	private global::System.Windows.Forms.Button buttonScanInterface;

	// Token: 0x0400046A RID: 1130
	private global::System.Windows.Forms.GroupBox groupBox5;

	// Token: 0x0400046B RID: 1131
	private global::System.Windows.Forms.GroupBox groupBox6;

	// Token: 0x0400046C RID: 1132
	private global::System.Windows.Forms.GroupBox groupBox7;

	// Token: 0x0400046D RID: 1133
	private global::System.Windows.Forms.ToolTip toolTip_0;

	// Token: 0x0400046E RID: 1134
	private global::System.Windows.Forms.CheckBox chkShowAdapterMessage;

	// Token: 0x0400046F RID: 1135
	private global::System.Windows.Forms.CheckBox chkShowMiles;

	// Token: 0x04000470 RID: 1136
	private global::System.Windows.Forms.ComboBox cbScreenRepaint;

	// Token: 0x04000471 RID: 1137
	private global::System.Windows.Forms.Label label28;

	// Token: 0x04000472 RID: 1138
	private global::System.Windows.Forms.CheckBox chkHighLatency;

	// Token: 0x04000473 RID: 1139
	private global::System.Windows.Forms.Button buttonClearRecent;
}
