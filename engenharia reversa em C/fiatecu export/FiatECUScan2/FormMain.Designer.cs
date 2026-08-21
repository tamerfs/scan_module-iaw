// Token: 0x02000074 RID: 116
public sealed partial class FormMain : global::System.Windows.Forms.Form
{
	// Token: 0x06000410 RID: 1040 RVA: 0x00003554 File Offset: 0x00001754
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000411 RID: 1041 RVA: 0x00081ED8 File Offset: 0x000800D8
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::FormMain));
		global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new global::System.Windows.Forms.DataGridViewCellStyle();
		global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new global::System.Windows.Forms.DataGridViewCellStyle();
		this.tabControlMain = new global::System.Windows.Forms.TabControl();
		this.tabPageSelect = new global::System.Windows.Forms.TabPage();
		this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
		this.label10 = new global::System.Windows.Forms.Label();
		this.label2 = new global::System.Windows.Forms.Label();
		this.label1 = new global::System.Windows.Forms.Label();
		this.dgvSelectModel = new global::System.Windows.Forms.DataGridView();
		this.colModel01 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colModel02 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colModel03 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colModel04 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dgvSelectMake = new global::System.Windows.Forms.DataGridView();
		this.colMake01 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colMake02 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.flowLayoutPanel1 = new global::System.Windows.Forms.FlowLayoutPanel();
		this.buttonConnect = new global::System.Windows.Forms.Button();
		this.imageList_0 = new global::System.Windows.Forms.ImageList(this.icontainer_0);
		this.buttonConnectAuto = new global::System.Windows.Forms.Button();
		this.buttonScanDTC = new global::System.Windows.Forms.Button();
		this.buttonUploadReport = new global::System.Windows.Forms.Button();
		this.buttonRegister = new global::System.Windows.Forms.Button();
		this.lblLink = new global::System.Windows.Forms.Label();
		this.panel4 = new global::System.Windows.Forms.Panel();
		this.lblNewVersionMessage = new global::System.Windows.Forms.Label();
		this.panel1 = new global::System.Windows.Forms.Panel();
		this.buttonSettings = new global::System.Windows.Forms.Button();
		this.label7 = new global::System.Windows.Forms.Label();
		this.label6 = new global::System.Windows.Forms.Label();
		this.dgvSelectECU = new global::System.Windows.Forms.DataGridView();
		this.colSystem01 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colSystem02 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colSystem03 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colSystem04 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colSystem05 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colSystem06 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colSystem07 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colSystem08 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colSystem09 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colSystem10 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colSystem11 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dgvSelectSystem = new global::System.Windows.Forms.DataGridView();
		this.colCategory01 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.colCategory02 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.tabPageInfo = new global::System.Windows.Forms.TabPage();
		this.panel5 = new global::System.Windows.Forms.Panel();
		this.lblISOError = new global::System.Windows.Forms.Label();
		this.panel3 = new global::System.Windows.Forms.Panel();
		this.lblSelectedInfo = new global::System.Windows.Forms.Label();
		this.lblSelectedInfo2 = new global::System.Windows.Forms.Label();
		this.buttonDisconnect = new global::System.Windows.Forms.Button();
		this.dgvInfo = new global::System.Windows.Forms.DataGridView();
		this.Column1 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column2 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column3 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.tabPageErrors = new global::System.Windows.Forms.TabPage();
		this.splitContainer2 = new global::System.Windows.Forms.SplitContainer();
		this.dgvErrors = new global::System.Windows.Forms.DataGridView();
		this.errorNameCol = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column15 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column16 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column17 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.tbErrorsDesc = new global::System.Windows.Forms.TextBox();
		this.tbErrorsDetails = new global::System.Windows.Forms.TextBox();
		this.panel6 = new global::System.Windows.Forms.Panel();
		this.btnErrorsClear = new global::System.Windows.Forms.Button();
		this.tabPageParams = new global::System.Windows.Forms.TabPage();
		this.btnTemplateLoad = new global::System.Windows.Forms.Button();
		this.splitContainer3 = new global::System.Windows.Forms.SplitContainer();
		this.dgvParams = new global::System.Windows.Forms.DataGridView();
		this.paramsColSelect = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn1 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn2 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.lblDTCsPresent = new global::System.Windows.Forms.Label();
		this.buttonSelectAll = new global::System.Windows.Forms.Button();
		this.buttonSelectNone = new global::System.Windows.Forms.Button();
		this.chkParamsAutoUp = new global::System.Windows.Forms.CheckBox();
		this.chkMonitorErrors = new global::System.Windows.Forms.CheckBox();
		this.tbParamDescription = new global::System.Windows.Forms.TextBox();
		this.btnParamsArrange = new global::System.Windows.Forms.Button();
		this.btnArrangeUnits = new global::System.Windows.Forms.Button();
		this.btnArrangeName = new global::System.Windows.Forms.Button();
		this.panel7 = new global::System.Windows.Forms.Panel();
		this.tabPageGraph = new global::System.Windows.Forms.TabPage();
		this.dgvTags = new global::System.Windows.Forms.DataGridView();
		this.Column4 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column5 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.flowLayoutPanel2 = new global::System.Windows.Forms.FlowLayoutPanel();
		this.label8 = new global::System.Windows.Forms.Label();
		this.button2 = new global::System.Windows.Forms.Button();
		this.cbGraphCount = new global::System.Windows.Forms.ComboBox();
		this.label4 = new global::System.Windows.Forms.Label();
		this.button3 = new global::System.Windows.Forms.Button();
		this.cbGraphRate = new global::System.Windows.Forms.ComboBox();
		this.label3 = new global::System.Windows.Forms.Label();
		this.button4 = new global::System.Windows.Forms.Button();
		this.cbGraphScale = new global::System.Windows.Forms.ComboBox();
		this.button5 = new global::System.Windows.Forms.Button();
		this.label9 = new global::System.Windows.Forms.Label();
		this.panel9 = new global::System.Windows.Forms.Panel();
		this.tbRecordingName = new global::System.Windows.Forms.TextBox();
		this.buttonGraphStart = new global::System.Windows.Forms.Button();
		this.lblGraphStatus = new global::System.Windows.Forms.Label();
		this.lblGraphTime = new global::System.Windows.Forms.Label();
		this.panel8 = new global::System.Windows.Forms.Panel();
		this.btnExportGraph = new global::System.Windows.Forms.Button();
		this.label5 = new global::System.Windows.Forms.Label();
		this.cbGraphFiles = new global::System.Windows.Forms.ComboBox();
		this.btnImportGraph = new global::System.Windows.Forms.Button();
		this.panel2 = new global::System.Windows.Forms.Panel();
		this.tableLayoutPanelGraphs = new global::GClass68();
		this.graphPanel1 = new global::GClass65();
		this.tableLayoutPanelGraphParams = new global::GClass68();
		this.tabPageActuators = new global::System.Windows.Forms.TabPage();
		this.splitContainer4 = new global::System.Windows.Forms.SplitContainer();
		this.dgvActuators = new global::System.Windows.Forms.DataGridView();
		this.dataGridViewCheckBoxColumn2 = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn7 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn8 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dgvActParams = new global::System.Windows.Forms.DataGridView();
		this.dataGridViewCheckBoxColumn3 = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn5 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn6 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.tbActuatorsDesc = new global::System.Windows.Forms.TextBox();
		this.panel10 = new global::System.Windows.Forms.Panel();
		this.btnActuatorsExecute = new global::System.Windows.Forms.Button();
		this.tabPageAdjustments = new global::System.Windows.Forms.TabPage();
		this.btnAdjustmentsExecute = new global::System.Windows.Forms.Button();
		this.splitContainer5 = new global::System.Windows.Forms.SplitContainer();
		this.dgvAdjustments = new global::System.Windows.Forms.DataGridView();
		this.dataGridViewCheckBoxColumn1 = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn3 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn4 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.tbAdjDesc = new global::System.Windows.Forms.TextBox();
		this.panel11 = new global::System.Windows.Forms.Panel();
		this.tabPageLog = new global::System.Windows.Forms.TabPage();
		this.textBoxLog = new global::System.Windows.Forms.TextBox();
		this.menuStrip1 = new global::System.Windows.Forms.MenuStrip();
		this.fileToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
		this.exitToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
		this.statusStrip1 = new global::System.Windows.Forms.StatusStrip();
		this.tsslAction = new global::System.Windows.Forms.ToolStripStatusLabel();
		this.tsslConnProblem = new global::System.Windows.Forms.ToolStripStatusLabel();
		this.ttslMsg = new global::System.Windows.Forms.ToolStripStatusLabel();
		this.timer_0 = new global::System.Windows.Forms.Timer(this.icontainer_0);
		this.timer_1 = new global::System.Windows.Forms.Timer(this.icontainer_0);
		this.saveFileDialog_0 = new global::System.Windows.Forms.SaveFileDialog();
		this.timer_2 = new global::System.Windows.Forms.Timer(this.icontainer_0);
		this.lblLoading = new global::System.Windows.Forms.Label();
		this.openFileDialog_0 = new global::System.Windows.Forms.OpenFileDialog();
		this.toolTip_0 = new global::System.Windows.Forms.ToolTip(this.icontainer_0);
		this.panelLoading = new global::System.Windows.Forms.Panel();
		this.tabControlMain.SuspendLayout();
		this.tabPageSelect.SuspendLayout();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.dgvSelectModel).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.dgvSelectMake).BeginInit();
		this.flowLayoutPanel1.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.dgvSelectECU).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.dgvSelectSystem).BeginInit();
		this.tabPageInfo.SuspendLayout();
		this.panel3.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.dgvInfo).BeginInit();
		this.tabPageErrors.SuspendLayout();
		this.splitContainer2.Panel1.SuspendLayout();
		this.splitContainer2.Panel2.SuspendLayout();
		this.splitContainer2.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.dgvErrors).BeginInit();
		this.tabPageParams.SuspendLayout();
		this.splitContainer3.Panel1.SuspendLayout();
		this.splitContainer3.Panel2.SuspendLayout();
		this.splitContainer3.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.dgvParams).BeginInit();
		this.tabPageGraph.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.dgvTags).BeginInit();
		this.flowLayoutPanel2.SuspendLayout();
		this.panel9.SuspendLayout();
		this.panel8.SuspendLayout();
		this.tableLayoutPanelGraphs.SuspendLayout();
		this.tabPageActuators.SuspendLayout();
		this.splitContainer4.Panel1.SuspendLayout();
		this.splitContainer4.Panel2.SuspendLayout();
		this.splitContainer4.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.dgvActuators).BeginInit();
		((global::System.ComponentModel.ISupportInitialize)this.dgvActParams).BeginInit();
		this.tabPageAdjustments.SuspendLayout();
		this.splitContainer5.Panel1.SuspendLayout();
		this.splitContainer5.Panel2.SuspendLayout();
		this.splitContainer5.SuspendLayout();
		((global::System.ComponentModel.ISupportInitialize)this.dgvAdjustments).BeginInit();
		this.tabPageLog.SuspendLayout();
		this.menuStrip1.SuspendLayout();
		this.statusStrip1.SuspendLayout();
		this.panelLoading.SuspendLayout();
		base.SuspendLayout();
		this.tabControlMain.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.tabControlMain.Controls.Add(this.tabPageSelect);
		this.tabControlMain.Controls.Add(this.tabPageInfo);
		this.tabControlMain.Controls.Add(this.tabPageErrors);
		this.tabControlMain.Controls.Add(this.tabPageParams);
		this.tabControlMain.Controls.Add(this.tabPageGraph);
		this.tabControlMain.Controls.Add(this.tabPageActuators);
		this.tabControlMain.Controls.Add(this.tabPageAdjustments);
		this.tabControlMain.Controls.Add(this.tabPageLog);
		this.tabControlMain.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.tabControlMain.HotTrack = true;
		this.tabControlMain.ImageList = this.imageList_0;
		this.tabControlMain.Location = new global::System.Drawing.Point(12, 12);
		this.tabControlMain.Name = "tabControlMain";
		this.tabControlMain.SelectedIndex = 0;
		this.tabControlMain.Size = new global::System.Drawing.Size(857, 460);
		this.tabControlMain.TabIndex = 0;
		this.tabControlMain.Tag = string.Empty;
		this.tabControlMain.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.tabControlMain_KeyUp);
		this.tabControlMain.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tabControlMain_KeyPress);
		this.tabControlMain.SelectedIndexChanged += new global::System.EventHandler(this.tabControlMain_SelectedIndexChanged);
		this.tabControlMain.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tabControlMain_KeyDown);
		this.tabPageSelect.BackColor = global::System.Drawing.Color.White;
		this.tabPageSelect.Controls.Add(this.splitContainer1);
		this.tabPageSelect.ImageKey = "Key_F11.png";
		this.tabPageSelect.Location = new global::System.Drawing.Point(4, 43);
		this.tabPageSelect.Name = "tabPageSelect";
		this.tabPageSelect.Size = new global::System.Drawing.Size(849, 413);
		this.tabPageSelect.TabIndex = 8;
		this.tabPageSelect.Tag = string.Empty;
		this.tabPageSelect.Text = "Select";
		this.tabPageSelect.UseVisualStyleBackColor = true;
		this.splitContainer1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.splitContainer1.BackColor = global::System.Drawing.Color.Navy;
		this.splitContainer1.Location = new global::System.Drawing.Point(3, 3);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.White;
		this.splitContainer1.Panel1.Controls.Add(this.label10);
		this.splitContainer1.Panel1.Controls.Add(this.label2);
		this.splitContainer1.Panel1.Controls.Add(this.label1);
		this.splitContainer1.Panel1.Controls.Add(this.dgvSelectModel);
		this.splitContainer1.Panel1.Controls.Add(this.dgvSelectMake);
		this.splitContainer1.Panel2.BackColor = global::System.Drawing.Color.White;
		this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
		this.splitContainer1.Panel2.Controls.Add(this.buttonUploadReport);
		this.splitContainer1.Panel2.Controls.Add(this.buttonRegister);
		this.splitContainer1.Panel2.Controls.Add(this.lblLink);
		this.splitContainer1.Panel2.Controls.Add(this.panel4);
		this.splitContainer1.Panel2.Controls.Add(this.lblNewVersionMessage);
		this.splitContainer1.Panel2.Controls.Add(this.panel1);
		this.splitContainer1.Panel2.Controls.Add(this.buttonSettings);
		this.splitContainer1.Panel2.Controls.Add(this.label7);
		this.splitContainer1.Panel2.Controls.Add(this.label6);
		this.splitContainer1.Panel2.Controls.Add(this.dgvSelectECU);
		this.splitContainer1.Panel2.Controls.Add(this.dgvSelectSystem);
		this.splitContainer1.Size = new global::System.Drawing.Size(840, 410);
		this.splitContainer1.SplitterDistance = 172;
		this.splitContainer1.TabIndex = 19;
		this.label10.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
		this.label10.AutoSize = true;
		this.label10.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.label10.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label10.ForeColor = global::System.Drawing.Color.DarkGray;
		this.label10.Location = new global::System.Drawing.Point(659, 4);
		this.label10.Name = "label10";
		this.label10.Size = new global::System.Drawing.Size(89, 29);
		this.label10.TabIndex = 15;
		this.label10.Tag = string.Empty;
		this.label10.Text = "search";
		this.label2.AutoSize = true;
		this.label2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.label2.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label2.ForeColor = global::System.Drawing.Color.DarkGreen;
		this.label2.Location = new global::System.Drawing.Point(229, 4);
		this.label2.Name = "label2";
		this.label2.Size = new global::System.Drawing.Size(178, 29);
		this.label2.TabIndex = 14;
		this.label2.Tag = "1003";
		this.label2.Text = "Model/Version";
		this.label1.AutoSize = true;
		this.label1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.label1.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label1.ForeColor = global::System.Drawing.Color.DarkGreen;
		this.label1.Location = new global::System.Drawing.Point(2, 4);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(73, 29);
		this.label1.TabIndex = 0;
		this.label1.Tag = "1002";
		this.label1.Text = "Make";
		this.dgvSelectModel.AllowUserToAddRows = false;
		this.dgvSelectModel.AllowUserToDeleteRows = false;
		this.dgvSelectModel.AllowUserToResizeRows = false;
		this.dgvSelectModel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.dgvSelectModel.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
		this.dgvSelectModel.BackgroundColor = global::System.Drawing.Color.White;
		this.dgvSelectModel.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
		this.dgvSelectModel.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvSelectModel.ColumnHeadersVisible = false;
		this.dgvSelectModel.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
		{
			this.colModel01,
			this.colModel02,
			this.colModel03,
			this.colModel04
		});
		this.dgvSelectModel.Location = new global::System.Drawing.Point(229, 33);
		this.dgvSelectModel.MultiSelect = false;
		this.dgvSelectModel.Name = "dgvSelectModel";
		this.dgvSelectModel.ReadOnly = true;
		this.dgvSelectModel.RowHeadersVisible = false;
		this.dgvSelectModel.RowTemplate.DefaultCellStyle.BackColor = global::System.Drawing.Color.White;
		this.dgvSelectModel.RowTemplate.DefaultCellStyle.Font = new global::System.Drawing.Font("Arial", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.dgvSelectModel.RowTemplate.DefaultCellStyle.ForeColor = global::System.Drawing.Color.Navy;
		this.dgvSelectModel.RowTemplate.DefaultCellStyle.SelectionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.dgvSelectModel.RowTemplate.DefaultCellStyle.SelectionForeColor = global::System.Drawing.Color.Navy;
		this.dgvSelectModel.RowTemplate.Height = 24;
		this.dgvSelectModel.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.dgvSelectModel.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgvSelectModel.ShowEditingIcon = false;
		this.dgvSelectModel.Size = new global::System.Drawing.Size(611, 136);
		this.dgvSelectModel.StandardTab = true;
		this.dgvSelectModel.TabIndex = 1;
		this.dgvSelectModel.Enter += new global::System.EventHandler(this.dgvSelectSystem_Leave);
		this.dgvSelectModel.Leave += new global::System.EventHandler(this.dgvSelectSystem_Leave);
		this.dgvSelectModel.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.dgvSelectModel_KeyPress);
		this.dgvSelectModel.SelectionChanged += new global::System.EventHandler(this.dgvSelectModel_SelectionChanged);
		this.colModel01.DataPropertyName = "MakeID";
		this.colModel01.HeaderText = "MakeID";
		this.colModel01.Name = "colModel01";
		this.colModel01.ReadOnly = true;
		this.colModel01.Visible = false;
		this.colModel02.DataPropertyName = "ModelID";
		this.colModel02.HeaderText = "ModelID";
		this.colModel02.Name = "colModel02";
		this.colModel02.ReadOnly = true;
		this.colModel02.Visible = false;
		this.colModel03.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.colModel03.DataPropertyName = "Model";
		this.colModel03.HeaderText = "Model/Version";
		this.colModel03.Name = "colModel03";
		this.colModel03.ReadOnly = true;
		this.colModel04.DataPropertyName = "CategoryIDs";
		this.colModel04.HeaderText = "CategoryIDs";
		this.colModel04.Name = "colModel04";
		this.colModel04.ReadOnly = true;
		this.colModel04.Visible = false;
		this.dgvSelectMake.AllowUserToAddRows = false;
		this.dgvSelectMake.AllowUserToDeleteRows = false;
		this.dgvSelectMake.AllowUserToResizeRows = false;
		this.dgvSelectMake.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.dgvSelectMake.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
		this.dgvSelectMake.BackgroundColor = global::System.Drawing.Color.White;
		this.dgvSelectMake.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
		this.dgvSelectMake.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvSelectMake.ColumnHeadersVisible = false;
		this.dgvSelectMake.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
		{
			this.colMake01,
			this.colMake02
		});
		dataGridViewCellStyle.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = global::System.Drawing.Color.White;
		dataGridViewCellStyle.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = global::System.Drawing.SystemColors.ControlText;
		dataGridViewCellStyle.SelectionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		dataGridViewCellStyle.SelectionForeColor = global::System.Drawing.Color.Navy;
		dataGridViewCellStyle.WrapMode = global::System.Windows.Forms.DataGridViewTriState.False;
		this.dgvSelectMake.DefaultCellStyle = dataGridViewCellStyle;
		this.dgvSelectMake.Location = new global::System.Drawing.Point(0, 33);
		this.dgvSelectMake.MultiSelect = false;
		this.dgvSelectMake.Name = "dgvSelectMake";
		this.dgvSelectMake.ReadOnly = true;
		this.dgvSelectMake.RowHeadersVisible = false;
		this.dgvSelectMake.RowTemplate.DefaultCellStyle.BackColor = global::System.Drawing.Color.White;
		this.dgvSelectMake.RowTemplate.DefaultCellStyle.Font = new global::System.Drawing.Font("Arial", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.dgvSelectMake.RowTemplate.DefaultCellStyle.ForeColor = global::System.Drawing.Color.Navy;
		this.dgvSelectMake.RowTemplate.DefaultCellStyle.SelectionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.dgvSelectMake.RowTemplate.DefaultCellStyle.SelectionForeColor = global::System.Drawing.Color.Navy;
		this.dgvSelectMake.RowTemplate.Height = 24;
		this.dgvSelectMake.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.dgvSelectMake.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgvSelectMake.ShowEditingIcon = false;
		this.dgvSelectMake.Size = new global::System.Drawing.Size(223, 136);
		this.dgvSelectMake.StandardTab = true;
		this.dgvSelectMake.TabIndex = 0;
		this.dgvSelectMake.Enter += new global::System.EventHandler(this.dgvSelectSystem_Leave);
		this.dgvSelectMake.Leave += new global::System.EventHandler(this.dgvSelectSystem_Leave);
		this.dgvSelectMake.SelectionChanged += new global::System.EventHandler(this.dgvSelectMake_SelectionChanged);
		this.colMake01.DataPropertyName = "MakeID";
		this.colMake01.HeaderText = "MakeID";
		this.colMake01.Name = "colMake01";
		this.colMake01.ReadOnly = true;
		this.colMake01.Visible = false;
		this.colMake02.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.colMake02.DataPropertyName = "Make";
		this.colMake02.HeaderText = "Make";
		this.colMake02.Name = "colMake02";
		this.colMake02.ReadOnly = true;
		this.flowLayoutPanel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.flowLayoutPanel1.AutoSize = true;
		this.flowLayoutPanel1.Controls.Add(this.buttonConnect);
		this.flowLayoutPanel1.Controls.Add(this.buttonConnectAuto);
		this.flowLayoutPanel1.Controls.Add(this.buttonScanDTC);
		this.flowLayoutPanel1.FlowDirection = global::System.Windows.Forms.FlowDirection.RightToLeft;
		this.flowLayoutPanel1.Location = new global::System.Drawing.Point(329, 111);
		this.flowLayoutPanel1.Margin = new global::System.Windows.Forms.Padding(0);
		this.flowLayoutPanel1.Name = "flowLayoutPanel1";
		this.flowLayoutPanel1.Size = new global::System.Drawing.Size(511, 46);
		this.flowLayoutPanel1.TabIndex = 25;
		this.buttonConnect.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.buttonConnect.AutoSize = true;
		this.buttonConnect.FlatAppearance.BorderSize = 2;
		this.buttonConnect.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.buttonConnect.ForeColor = global::System.Drawing.Color.DarkGreen;
		this.buttonConnect.ImageKey = "Key_F10.png";
		this.buttonConnect.ImageList = this.imageList_0;
		this.buttonConnect.Location = new global::System.Drawing.Point(360, 0);
		this.buttonConnect.Margin = new global::System.Windows.Forms.Padding(0);
		this.buttonConnect.Name = "buttonConnect";
		this.buttonConnect.Size = new global::System.Drawing.Size(151, 46);
		this.buttonConnect.TabIndex = 2;
		this.buttonConnect.Tag = "1006";
		this.buttonConnect.Text = "Connect";
		this.buttonConnect.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.buttonConnect.UseVisualStyleBackColor = true;
		this.buttonConnect.Click += new global::System.EventHandler(this.buttonConnect_Click);
		this.imageList_0.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
		this.imageList_0.TransparentColor = global::System.Drawing.Color.Transparent;
		this.imageList_0.Images.SetKeyName(0, "Key_A.png");
		this.imageList_0.Images.SetKeyName(1, "Key_E.png");
		this.imageList_0.Images.SetKeyName(2, "Key_F1.png");
		this.imageList_0.Images.SetKeyName(3, "Key_F2.png");
		this.imageList_0.Images.SetKeyName(4, "Key_F3.png");
		this.imageList_0.Images.SetKeyName(5, "Key_F4.png");
		this.imageList_0.Images.SetKeyName(6, "Key_F5.png");
		this.imageList_0.Images.SetKeyName(7, "Key_F6.png");
		this.imageList_0.Images.SetKeyName(8, "Key_F7.png");
		this.imageList_0.Images.SetKeyName(9, "Key_F8.png");
		this.imageList_0.Images.SetKeyName(10, "Key_F9.png");
		this.imageList_0.Images.SetKeyName(11, "Key_F10.png");
		this.imageList_0.Images.SetKeyName(12, "Key_F11.png");
		this.imageList_0.Images.SetKeyName(13, "Key_F12.png");
		this.imageList_0.Images.SetKeyName(14, "Key_S.png");
		this.imageList_0.Images.SetKeyName(15, "Key_U.png");
		this.imageList_0.Images.SetKeyName(16, "Key_F.png");
		this.imageList_0.Images.SetKeyName(17, "Key_G.png");
		this.imageList_0.Images.SetKeyName(18, "Key_I.png");
		this.imageList_0.Images.SetKeyName(19, "Key_L.png");
		this.imageList_0.Images.SetKeyName(20, "Key_R.png");
		this.imageList_0.Images.SetKeyName(21, "Key_T.png");
		this.imageList_0.Images.SetKeyName(22, "Key_N.png");
		this.buttonConnectAuto.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.buttonConnectAuto.AutoSize = true;
		this.buttonConnectAuto.FlatAppearance.BorderSize = 2;
		this.buttonConnectAuto.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.buttonConnectAuto.ForeColor = global::System.Drawing.Color.DarkGreen;
		this.buttonConnectAuto.ImageKey = "Key_F11.png";
		this.buttonConnectAuto.ImageList = this.imageList_0;
		this.buttonConnectAuto.Location = new global::System.Drawing.Point(231, 0);
		this.buttonConnectAuto.Margin = new global::System.Windows.Forms.Padding(0, 0, 8, 0);
		this.buttonConnectAuto.Name = "buttonConnectAuto";
		this.buttonConnectAuto.Size = new global::System.Drawing.Size(121, 46);
		this.buttonConnectAuto.TabIndex = 3;
		this.buttonConnectAuto.Tag = "1010";
		this.buttonConnectAuto.Text = "Scan";
		this.buttonConnectAuto.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.buttonConnectAuto.UseVisualStyleBackColor = true;
		this.buttonConnectAuto.Click += new global::System.EventHandler(this.buttonConnectAuto_Click);
		this.buttonScanDTC.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.buttonScanDTC.AutoSize = true;
		this.buttonScanDTC.FlatAppearance.BorderSize = 2;
		this.buttonScanDTC.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.buttonScanDTC.ForeColor = global::System.Drawing.Color.DarkGreen;
		this.buttonScanDTC.ImageKey = "Key_F12.png";
		this.buttonScanDTC.ImageList = this.imageList_0;
		this.buttonScanDTC.Location = new global::System.Drawing.Point(55, 0);
		this.buttonScanDTC.Margin = new global::System.Windows.Forms.Padding(0, 0, 8, 0);
		this.buttonScanDTC.Name = "buttonScanDTC";
		this.buttonScanDTC.Size = new global::System.Drawing.Size(168, 46);
		this.buttonScanDTC.TabIndex = 4;
		this.buttonScanDTC.Tag = "1017";
		this.buttonScanDTC.Text = "Scan DTC";
		this.buttonScanDTC.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.buttonScanDTC.UseVisualStyleBackColor = true;
		this.buttonScanDTC.Click += new global::System.EventHandler(this.buttonScanDTC_Click);
		this.buttonUploadReport.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.buttonUploadReport.BackColor = global::System.Drawing.Color.Red;
		this.buttonUploadReport.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
		this.buttonUploadReport.Font = new global::System.Drawing.Font("Arial", 8.064f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
		this.buttonUploadReport.ForeColor = global::System.Drawing.Color.White;
		this.buttonUploadReport.Location = new global::System.Drawing.Point(391, 174);
		this.buttonUploadReport.Name = "buttonUploadReport";
		this.buttonUploadReport.Size = new global::System.Drawing.Size(168, 25);
		this.buttonUploadReport.TabIndex = 24;
		this.buttonUploadReport.Tag = "1011";
		this.buttonUploadReport.Text = "Send Report";
		this.buttonUploadReport.UseVisualStyleBackColor = false;
		this.buttonUploadReport.Visible = false;
		this.buttonUploadReport.Click += new global::System.EventHandler(this.buttonUploadReport_Click);
		this.buttonRegister.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.buttonRegister.BackColor = global::System.Drawing.Color.Navy;
		this.buttonRegister.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.buttonRegister.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.buttonRegister.ForeColor = global::System.Drawing.Color.White;
		this.buttonRegister.Location = new global::System.Drawing.Point(0, 159);
		this.buttonRegister.Name = "buttonRegister";
		this.buttonRegister.Size = new global::System.Drawing.Size(216, 27);
		this.buttonRegister.TabIndex = 23;
		this.buttonRegister.Text = "Register";
		this.buttonRegister.UseVisualStyleBackColor = false;
		this.buttonRegister.Click += new global::System.EventHandler(this.buttonRegister_Click);
		this.lblLink.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.lblLink.AutoSize = true;
		this.lblLink.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.lblLink.Font = new global::System.Drawing.Font("Arial", 12.096f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblLink.ForeColor = global::System.Drawing.Color.Navy;
		this.lblLink.Location = new global::System.Drawing.Point(220, 212);
		this.lblLink.Name = "lblLink";
		this.lblLink.Size = new global::System.Drawing.Size(215, 24);
		this.lblLink.TabIndex = 22;
		this.lblLink.Text = "www.fiatecuscan.net";
		this.lblLink.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.lblLink_MouseClick);
		this.panel4.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.panel4.BackColor = global::System.Drawing.Color.Navy;
		this.panel4.Location = new global::System.Drawing.Point(222, 166);
		this.panel4.Name = "panel4";
		this.panel4.Size = new global::System.Drawing.Size(337, 5);
		this.panel4.TabIndex = 21;
		this.lblNewVersionMessage.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.lblNewVersionMessage.AutoSize = true;
		this.lblNewVersionMessage.BackColor = global::System.Drawing.Color.Red;
		this.lblNewVersionMessage.Font = new global::System.Drawing.Font("Arial", 9.216f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblNewVersionMessage.ForeColor = global::System.Drawing.Color.White;
		this.lblNewVersionMessage.Location = new global::System.Drawing.Point(224, 190);
		this.lblNewVersionMessage.Name = "lblNewVersionMessage";
		this.lblNewVersionMessage.Size = new global::System.Drawing.Size(326, 19);
		this.lblNewVersionMessage.TabIndex = 17;
		this.lblNewVersionMessage.Tag = "1009";
		this.lblNewVersionMessage.Text = "New version of the program is available at";
		this.lblNewVersionMessage.Visible = false;
		this.panel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.panel1.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("panel1.BackgroundImage");
		this.panel1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
		this.panel1.Location = new global::System.Drawing.Point(570, 161);
		this.panel1.Name = "panel1";
		this.panel1.Size = new global::System.Drawing.Size(270, 70);
		this.panel1.TabIndex = 20;
		this.buttonSettings.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.buttonSettings.FlatAppearance.BorderSize = 2;
		this.buttonSettings.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.buttonSettings.ImageKey = "Key_F9.png";
		this.buttonSettings.ImageList = this.imageList_0;
		this.buttonSettings.Location = new global::System.Drawing.Point(0, 187);
		this.buttonSettings.Name = "buttonSettings";
		this.buttonSettings.Size = new global::System.Drawing.Size(216, 46);
		this.buttonSettings.TabIndex = 4;
		this.buttonSettings.Tag = "1008";
		this.buttonSettings.Text = "Settings";
		this.buttonSettings.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.buttonSettings.UseVisualStyleBackColor = true;
		this.buttonSettings.Click += new global::System.EventHandler(this.buttonSettings_Click);
		this.label7.AutoSize = true;
		this.label7.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.label7.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label7.ForeColor = global::System.Drawing.Color.DarkGreen;
		this.label7.Location = new global::System.Drawing.Point(328, 8);
		this.label7.Name = "label7";
		this.label7.Size = new global::System.Drawing.Size(63, 29);
		this.label7.TabIndex = 2;
		this.label7.Tag = "1005";
		this.label7.Text = "ECU";
		this.label7.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
		this.label6.AutoSize = true;
		this.label6.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.label6.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label6.ForeColor = global::System.Drawing.Color.DarkGreen;
		this.label6.Location = new global::System.Drawing.Point(2, 8);
		this.label6.Name = "label6";
		this.label6.Size = new global::System.Drawing.Size(97, 29);
		this.label6.TabIndex = 0;
		this.label6.Tag = "1004";
		this.label6.Text = "System";
		this.label6.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
		this.dgvSelectECU.AllowUserToAddRows = false;
		this.dgvSelectECU.AllowUserToDeleteRows = false;
		this.dgvSelectECU.AllowUserToResizeRows = false;
		this.dgvSelectECU.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.dgvSelectECU.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
		this.dgvSelectECU.BackgroundColor = global::System.Drawing.Color.White;
		this.dgvSelectECU.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle2.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = global::System.Drawing.Color.LightGray;
		dataGridViewCellStyle2.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		dataGridViewCellStyle2.ForeColor = global::System.Drawing.Color.DarkGreen;
		dataGridViewCellStyle2.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
		this.dgvSelectECU.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		this.dgvSelectECU.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvSelectECU.ColumnHeadersVisible = false;
		this.dgvSelectECU.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
		{
			this.colSystem01,
			this.colSystem02,
			this.colSystem03,
			this.colSystem04,
			this.colSystem05,
			this.colSystem06,
			this.colSystem07,
			this.colSystem08,
			this.colSystem09,
			this.colSystem10,
			this.colSystem11
		});
		this.dgvSelectECU.EnableHeadersVisualStyles = false;
		this.dgvSelectECU.Location = new global::System.Drawing.Point(329, 37);
		this.dgvSelectECU.MultiSelect = false;
		this.dgvSelectECU.Name = "dgvSelectECU";
		this.dgvSelectECU.ReadOnly = true;
		this.dgvSelectECU.RowHeadersVisible = false;
		this.dgvSelectECU.RowTemplate.DefaultCellStyle.BackColor = global::System.Drawing.Color.White;
		this.dgvSelectECU.RowTemplate.DefaultCellStyle.Font = new global::System.Drawing.Font("Arial", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.dgvSelectECU.RowTemplate.DefaultCellStyle.ForeColor = global::System.Drawing.Color.Navy;
		this.dgvSelectECU.RowTemplate.DefaultCellStyle.SelectionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.dgvSelectECU.RowTemplate.DefaultCellStyle.SelectionForeColor = global::System.Drawing.Color.Navy;
		this.dgvSelectECU.RowTemplate.Height = 24;
		this.dgvSelectECU.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.dgvSelectECU.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgvSelectECU.ShowEditingIcon = false;
		this.dgvSelectECU.Size = new global::System.Drawing.Size(511, 68);
		this.dgvSelectECU.StandardTab = true;
		this.dgvSelectECU.TabIndex = 1;
		this.dgvSelectECU.Enter += new global::System.EventHandler(this.dgvSelectSystem_Leave);
		this.dgvSelectECU.RowPrePaint += new global::System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvSelectECU_RowPrePaint);
		this.dgvSelectECU.Leave += new global::System.EventHandler(this.dgvSelectSystem_Leave);
		this.colSystem01.DataPropertyName = "SystemID";
		this.colSystem01.HeaderText = "SystemID";
		this.colSystem01.Name = "colSystem01";
		this.colSystem01.ReadOnly = true;
		this.colSystem01.Visible = false;
		this.colSystem02.DataPropertyName = "ModelID";
		this.colSystem02.HeaderText = "ModelID";
		this.colSystem02.Name = "colSystem02";
		this.colSystem02.ReadOnly = true;
		this.colSystem02.Visible = false;
		this.colSystem03.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.colSystem03.DataPropertyName = "SystemDesc";
		this.colSystem03.HeaderText = "ECU";
		this.colSystem03.Name = "colSystem03";
		this.colSystem03.ReadOnly = true;
		this.colSystem04.DataPropertyName = "ModuleID";
		this.colSystem04.HeaderText = "ModuleID";
		this.colSystem04.Name = "colSystem04";
		this.colSystem04.ReadOnly = true;
		this.colSystem04.Visible = false;
		this.colSystem05.DataPropertyName = "ProtocolID";
		this.colSystem05.HeaderText = "ProtocolID";
		this.colSystem05.Name = "colSystem05";
		this.colSystem05.ReadOnly = true;
		this.colSystem05.Visible = false;
		this.colSystem06.DataPropertyName = "ECUAddress";
		this.colSystem06.HeaderText = "ECUAddress";
		this.colSystem06.Name = "colSystem06";
		this.colSystem06.ReadOnly = true;
		this.colSystem06.Visible = false;
		this.colSystem07.DataPropertyName = "CategoryID";
		this.colSystem07.HeaderText = "CategoryID";
		this.colSystem07.Name = "colSystem07";
		this.colSystem07.ReadOnly = true;
		this.colSystem07.Visible = false;
		this.colSystem08.DataPropertyName = "CANAddress";
		this.colSystem08.HeaderText = "CANAddress";
		this.colSystem08.Name = "colSystem08";
		this.colSystem08.ReadOnly = true;
		this.colSystem08.Visible = false;
		this.colSystem09.DataPropertyName = "ShowFree";
		this.colSystem09.HeaderText = "ShowFree";
		this.colSystem09.Name = "colSystem09";
		this.colSystem09.ReadOnly = true;
		this.colSystem09.Visible = false;
		this.colSystem10.DataPropertyName = "InterfaceAdapter";
		this.colSystem10.HeaderText = "InterfaceAdapter";
		this.colSystem10.Name = "colSystem10";
		this.colSystem10.ReadOnly = true;
		this.colSystem10.Visible = false;
		this.colSystem11.DataPropertyName = "SystemID2";
		this.colSystem11.HeaderText = "SystemID2";
		this.colSystem11.Name = "colSystem11";
		this.colSystem11.ReadOnly = true;
		this.colSystem11.Visible = false;
		this.dgvSelectSystem.AllowUserToAddRows = false;
		this.dgvSelectSystem.AllowUserToDeleteRows = false;
		this.dgvSelectSystem.AllowUserToResizeRows = false;
		this.dgvSelectSystem.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.dgvSelectSystem.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
		this.dgvSelectSystem.BackgroundColor = global::System.Drawing.Color.White;
		this.dgvSelectSystem.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle3.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = global::System.Drawing.Color.DarkGreen;
		dataGridViewCellStyle3.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		dataGridViewCellStyle3.ForeColor = global::System.Drawing.Color.White;
		dataGridViewCellStyle3.SelectionBackColor = global::System.Drawing.Color.White;
		dataGridViewCellStyle3.SelectionForeColor = global::System.Drawing.Color.DarkGreen;
		dataGridViewCellStyle3.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
		this.dgvSelectSystem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		this.dgvSelectSystem.ColumnHeadersHeight = 36;
		this.dgvSelectSystem.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		this.dgvSelectSystem.ColumnHeadersVisible = false;
		this.dgvSelectSystem.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
		{
			this.colCategory01,
			this.colCategory02
		});
		this.dgvSelectSystem.EnableHeadersVisualStyles = false;
		this.dgvSelectSystem.Location = new global::System.Drawing.Point(0, 37);
		this.dgvSelectSystem.MultiSelect = false;
		this.dgvSelectSystem.Name = "dgvSelectSystem";
		this.dgvSelectSystem.ReadOnly = true;
		this.dgvSelectSystem.RowHeadersVisible = false;
		this.dgvSelectSystem.RowTemplate.DefaultCellStyle.BackColor = global::System.Drawing.Color.White;
		this.dgvSelectSystem.RowTemplate.DefaultCellStyle.Font = new global::System.Drawing.Font("Arial", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.dgvSelectSystem.RowTemplate.DefaultCellStyle.ForeColor = global::System.Drawing.Color.Navy;
		this.dgvSelectSystem.RowTemplate.DefaultCellStyle.SelectionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.dgvSelectSystem.RowTemplate.DefaultCellStyle.SelectionForeColor = global::System.Drawing.Color.Navy;
		this.dgvSelectSystem.RowTemplate.Height = 24;
		this.dgvSelectSystem.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.dgvSelectSystem.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgvSelectSystem.ShowEditingIcon = false;
		this.dgvSelectSystem.Size = new global::System.Drawing.Size(323, 120);
		this.dgvSelectSystem.StandardTab = true;
		this.dgvSelectSystem.TabIndex = 0;
		this.dgvSelectSystem.Enter += new global::System.EventHandler(this.dgvSelectSystem_Leave);
		this.dgvSelectSystem.Leave += new global::System.EventHandler(this.dgvSelectSystem_Leave);
		this.dgvSelectSystem.SelectionChanged += new global::System.EventHandler(this.dgvSelectSystem_SelectionChanged);
		this.colCategory01.DataPropertyName = "CategoryID";
		this.colCategory01.HeaderText = "CategoryID";
		this.colCategory01.Name = "colCategory01";
		this.colCategory01.ReadOnly = true;
		this.colCategory01.Visible = false;
		this.colCategory02.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.colCategory02.DataPropertyName = "CategoryDesc";
		this.colCategory02.HeaderText = "Category";
		this.colCategory02.Name = "colCategory02";
		this.colCategory02.ReadOnly = true;
		this.tabPageInfo.BackColor = global::System.Drawing.Color.White;
		this.tabPageInfo.Controls.Add(this.panel5);
		this.tabPageInfo.Controls.Add(this.lblISOError);
		this.tabPageInfo.Controls.Add(this.panel3);
		this.tabPageInfo.Controls.Add(this.buttonDisconnect);
		this.tabPageInfo.Controls.Add(this.dgvInfo);
		this.tabPageInfo.ImageKey = "Key_F2.png";
		this.tabPageInfo.Location = new global::System.Drawing.Point(4, 43);
		this.tabPageInfo.Name = "tabPageInfo";
		this.tabPageInfo.Padding = new global::System.Windows.Forms.Padding(3);
		this.tabPageInfo.Size = new global::System.Drawing.Size(849, 413);
		this.tabPageInfo.TabIndex = 0;
		this.tabPageInfo.Tag = string.Empty;
		this.tabPageInfo.Text = "Info";
		this.tabPageInfo.UseVisualStyleBackColor = true;
		this.panel5.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.panel5.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("panel5.BackgroundImage");
		this.panel5.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
		this.panel5.Location = new global::System.Drawing.Point(4, 367);
		this.panel5.Name = "panel5";
		this.panel5.Size = new global::System.Drawing.Size(242, 44);
		this.panel5.TabIndex = 16;
		this.lblISOError.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.lblISOError.AutoSize = true;
		this.lblISOError.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.lblISOError.Font = new global::System.Drawing.Font("Arial", 8.064f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblISOError.ForeColor = global::System.Drawing.Color.Red;
		this.lblISOError.Location = new global::System.Drawing.Point(252, 393);
		this.lblISOError.Name = "lblISOError";
		this.lblISOError.Size = new global::System.Drawing.Size(407, 18);
		this.lblISOError.TabIndex = 15;
		this.lblISOError.Tag = "2003";
		this.lblISOError.Text = "WARNING: Invalid ISO Code for selected vehicle system!";
		this.panel3.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.panel3.BackColor = global::System.Drawing.Color.Khaki;
		this.panel3.Controls.Add(this.lblSelectedInfo);
		this.panel3.Controls.Add(this.lblSelectedInfo2);
		this.panel3.Location = new global::System.Drawing.Point(6, 6);
		this.panel3.Name = "panel3";
		this.panel3.Size = new global::System.Drawing.Size(837, 88);
		this.panel3.TabIndex = 14;
		this.lblSelectedInfo.AutoSize = true;
		this.lblSelectedInfo.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.lblSelectedInfo.Font = new global::System.Drawing.Font("Arial", 19.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblSelectedInfo.ForeColor = global::System.Drawing.Color.DarkGreen;
		this.lblSelectedInfo.Location = new global::System.Drawing.Point(6, 8);
		this.lblSelectedInfo.Name = "lblSelectedInfo";
		this.lblSelectedInfo.Size = new global::System.Drawing.Size(549, 41);
		this.lblSelectedInfo.TabIndex = 13;
		this.lblSelectedInfo.Text = "CAR > SYSTEM > MODEL > ECU";
		this.lblSelectedInfo2.AutoSize = true;
		this.lblSelectedInfo2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.lblSelectedInfo2.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblSelectedInfo2.ForeColor = global::System.Drawing.Color.DarkGreen;
		this.lblSelectedInfo2.Location = new global::System.Drawing.Point(9, 50);
		this.lblSelectedInfo2.Name = "lblSelectedInfo2";
		this.lblSelectedInfo2.Size = new global::System.Drawing.Size(384, 29);
		this.lblSelectedInfo2.TabIndex = 12;
		this.lblSelectedInfo2.Text = "CAR > SYSTEM > MODEL > ECU";
		this.buttonDisconnect.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.buttonDisconnect.AutoSize = true;
		this.buttonDisconnect.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.buttonDisconnect.ForeColor = global::System.Drawing.Color.Red;
		this.buttonDisconnect.ImageKey = "Key_F11.png";
		this.buttonDisconnect.ImageList = this.imageList_0;
		this.buttonDisconnect.Location = new global::System.Drawing.Point(654, 365);
		this.buttonDisconnect.Name = "buttonDisconnect";
		this.buttonDisconnect.Size = new global::System.Drawing.Size(190, 46);
		this.buttonDisconnect.TabIndex = 9;
		this.buttonDisconnect.Tag = "2002";
		this.buttonDisconnect.Text = "Disconnect";
		this.buttonDisconnect.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.buttonDisconnect.UseVisualStyleBackColor = true;
		this.buttonDisconnect.Click += new global::System.EventHandler(this.buttonDisconnect_Click);
		this.dgvInfo.AllowUserToAddRows = false;
		this.dgvInfo.AllowUserToDeleteRows = false;
		this.dgvInfo.AllowUserToResizeRows = false;
		this.dgvInfo.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.dgvInfo.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
		this.dgvInfo.BackgroundColor = global::System.Drawing.Color.White;
		this.dgvInfo.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dgvInfo.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvInfo.ColumnHeadersVisible = false;
		this.dgvInfo.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
		{
			this.Column1,
			this.Column2,
			this.Column3
		});
		this.dgvInfo.Location = new global::System.Drawing.Point(6, 100);
		this.dgvInfo.Name = "dgvInfo";
		this.dgvInfo.ReadOnly = true;
		this.dgvInfo.RowHeadersVisible = false;
		this.dgvInfo.RowTemplate.DefaultCellStyle.BackColor = global::System.Drawing.Color.White;
		this.dgvInfo.RowTemplate.DefaultCellStyle.Font = new global::System.Drawing.Font("Arial", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.dgvInfo.RowTemplate.DefaultCellStyle.ForeColor = global::System.Drawing.Color.Navy;
		this.dgvInfo.RowTemplate.DefaultCellStyle.SelectionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.dgvInfo.RowTemplate.DefaultCellStyle.SelectionForeColor = global::System.Drawing.Color.Navy;
		this.dgvInfo.RowTemplate.Height = 24;
		this.dgvInfo.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.dgvInfo.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgvInfo.ShowEditingIcon = false;
		this.dgvInfo.Size = new global::System.Drawing.Size(837, 259);
		this.dgvInfo.TabIndex = 1;
		this.dgvInfo.RowPrePaint += new global::System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvInfo_RowPrePaint);
		this.Column1.DataPropertyName = "Selected";
		this.Column1.HeaderText = "Selected";
		this.Column1.Name = "Column1";
		this.Column1.ReadOnly = true;
		this.Column1.Visible = false;
		this.Column2.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.Column2.DataPropertyName = "Name";
		this.Column2.FillWeight = 40f;
		this.Column2.HeaderText = "Name";
		this.Column2.Name = "Column2";
		this.Column2.ReadOnly = true;
		this.Column3.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.Column3.DataPropertyName = "Value";
		this.Column3.FillWeight = 60f;
		this.Column3.HeaderText = "Value";
		this.Column3.Name = "Column3";
		this.Column3.ReadOnly = true;
		this.tabPageErrors.BackColor = global::System.Drawing.Color.White;
		this.tabPageErrors.Controls.Add(this.splitContainer2);
		this.tabPageErrors.Controls.Add(this.panel6);
		this.tabPageErrors.Controls.Add(this.btnErrorsClear);
		this.tabPageErrors.ImageKey = "Key_F3.png";
		this.tabPageErrors.Location = new global::System.Drawing.Point(4, 43);
		this.tabPageErrors.Name = "tabPageErrors";
		this.tabPageErrors.Padding = new global::System.Windows.Forms.Padding(3);
		this.tabPageErrors.Size = new global::System.Drawing.Size(849, 413);
		this.tabPageErrors.TabIndex = 2;
		this.tabPageErrors.Tag = string.Empty;
		this.tabPageErrors.Text = "Errors";
		this.tabPageErrors.UseVisualStyleBackColor = true;
		this.splitContainer2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.splitContainer2.BackColor = global::System.Drawing.Color.Navy;
		this.splitContainer2.Location = new global::System.Drawing.Point(6, 6);
		this.splitContainer2.Name = "splitContainer2";
		this.splitContainer2.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer2.Panel1.BackColor = global::System.Drawing.Color.White;
		this.splitContainer2.Panel1.Controls.Add(this.dgvErrors);
		this.splitContainer2.Panel2.BackColor = global::System.Drawing.Color.White;
		this.splitContainer2.Panel2.Controls.Add(this.tbErrorsDesc);
		this.splitContainer2.Panel2.Controls.Add(this.tbErrorsDetails);
		this.splitContainer2.Size = new global::System.Drawing.Size(837, 353);
		this.splitContainer2.SplitterDistance = 204;
		this.splitContainer2.TabIndex = 18;
		this.dgvErrors.AllowUserToAddRows = false;
		this.dgvErrors.AllowUserToDeleteRows = false;
		this.dgvErrors.AllowUserToResizeRows = false;
		this.dgvErrors.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.dgvErrors.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
		this.dgvErrors.BackgroundColor = global::System.Drawing.Color.White;
		this.dgvErrors.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dgvErrors.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvErrors.ColumnHeadersVisible = false;
		this.dgvErrors.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
		{
			this.errorNameCol,
			this.Column15,
			this.Column16,
			this.Column17
		});
		this.dgvErrors.Location = new global::System.Drawing.Point(0, 0);
		this.dgvErrors.MultiSelect = false;
		this.dgvErrors.Name = "dgvErrors";
		this.dgvErrors.ReadOnly = true;
		this.dgvErrors.RowHeadersVisible = false;
		this.dgvErrors.RowTemplate.DefaultCellStyle.BackColor = global::System.Drawing.Color.White;
		this.dgvErrors.RowTemplate.DefaultCellStyle.Font = new global::System.Drawing.Font("Arial", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.dgvErrors.RowTemplate.DefaultCellStyle.ForeColor = global::System.Drawing.Color.Navy;
		this.dgvErrors.RowTemplate.DefaultCellStyle.SelectionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.dgvErrors.RowTemplate.DefaultCellStyle.SelectionForeColor = global::System.Drawing.Color.Navy;
		this.dgvErrors.RowTemplate.Height = 24;
		this.dgvErrors.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgvErrors.ShowEditingIcon = false;
		this.dgvErrors.Size = new global::System.Drawing.Size(837, 201);
		this.dgvErrors.TabIndex = 0;
		this.dgvErrors.SelectionChanged += new global::System.EventHandler(this.dgvErrors_SelectionChanged);
		this.errorNameCol.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.errorNameCol.DataPropertyName = "Name";
		this.errorNameCol.FillWeight = 70f;
		this.errorNameCol.HeaderText = "Error";
		this.errorNameCol.MinimumWidth = 500;
		this.errorNameCol.Name = "errorNameCol";
		this.errorNameCol.ReadOnly = true;
		this.errorNameCol.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.Column15.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		this.Column15.DataPropertyName = "Status1";
		this.Column15.HeaderText = "Symptom";
		this.Column15.Name = "Column15";
		this.Column15.ReadOnly = true;
		this.Column15.Width = 5;
		this.Column16.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		this.Column16.DataPropertyName = "Status2";
		this.Column16.HeaderText = "State";
		this.Column16.Name = "Column16";
		this.Column16.ReadOnly = true;
		this.Column16.Width = 5;
		this.Column17.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		this.Column17.DataPropertyName = "Status3";
		this.Column17.HeaderText = "Dash";
		this.Column17.Name = "Column17";
		this.Column17.ReadOnly = true;
		this.Column17.Width = 5;
		this.tbErrorsDesc.AcceptsReturn = true;
		this.tbErrorsDesc.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.tbErrorsDesc.BackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.tbErrorsDesc.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.tbErrorsDesc.Font = new global::System.Drawing.Font("Arial", 9.792f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.tbErrorsDesc.ForeColor = global::System.Drawing.Color.DarkSlateBlue;
		this.tbErrorsDesc.Location = new global::System.Drawing.Point(351, 2);
		this.tbErrorsDesc.Multiline = true;
		this.tbErrorsDesc.Name = "tbErrorsDesc";
		this.tbErrorsDesc.ReadOnly = true;
		this.tbErrorsDesc.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.tbErrorsDesc.Size = new global::System.Drawing.Size(484, 142);
		this.tbErrorsDesc.TabIndex = 2;
		this.tbErrorsDetails.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.tbErrorsDetails.BackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.tbErrorsDetails.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.tbErrorsDetails.Font = new global::System.Drawing.Font("Arial", 9.792f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.tbErrorsDetails.ForeColor = global::System.Drawing.Color.DarkSlateBlue;
		this.tbErrorsDetails.Location = new global::System.Drawing.Point(0, 3);
		this.tbErrorsDetails.Multiline = true;
		this.tbErrorsDetails.Name = "tbErrorsDetails";
		this.tbErrorsDetails.ReadOnly = true;
		this.tbErrorsDetails.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.tbErrorsDetails.Size = new global::System.Drawing.Size(342, 142);
		this.tbErrorsDetails.TabIndex = 1;
		this.panel6.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.panel6.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("panel6.BackgroundImage");
		this.panel6.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
		this.panel6.Location = new global::System.Drawing.Point(4, 367);
		this.panel6.Name = "panel6";
		this.panel6.Size = new global::System.Drawing.Size(242, 44);
		this.panel6.TabIndex = 17;
		this.btnErrorsClear.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.btnErrorsClear.AutoSize = true;
		this.btnErrorsClear.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.btnErrorsClear.ImageKey = "Key_F10.png";
		this.btnErrorsClear.ImageList = this.imageList_0;
		this.btnErrorsClear.Location = new global::System.Drawing.Point(640, 365);
		this.btnErrorsClear.Name = "btnErrorsClear";
		this.btnErrorsClear.Size = new global::System.Drawing.Size(203, 46);
		this.btnErrorsClear.TabIndex = 2;
		this.btnErrorsClear.Tag = "3002";
		this.btnErrorsClear.Text = "Clear Errors";
		this.btnErrorsClear.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.btnErrorsClear.UseVisualStyleBackColor = true;
		this.btnErrorsClear.Click += new global::System.EventHandler(this.btnErrorsClear_Click);
		this.tabPageParams.BackColor = global::System.Drawing.Color.White;
		this.tabPageParams.Controls.Add(this.btnTemplateLoad);
		this.tabPageParams.Controls.Add(this.splitContainer3);
		this.tabPageParams.Controls.Add(this.panel7);
		this.tabPageParams.ImageKey = "Key_F4.png";
		this.tabPageParams.Location = new global::System.Drawing.Point(4, 43);
		this.tabPageParams.Name = "tabPageParams";
		this.tabPageParams.Size = new global::System.Drawing.Size(849, 413);
		this.tabPageParams.TabIndex = 3;
		this.tabPageParams.Tag = string.Empty;
		this.tabPageParams.Text = "Parameters";
		this.tabPageParams.UseVisualStyleBackColor = true;
		this.btnTemplateLoad.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.btnTemplateLoad.AutoSize = true;
		this.btnTemplateLoad.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.btnTemplateLoad.ImageKey = "Key_T.png";
		this.btnTemplateLoad.ImageList = this.imageList_0;
		this.btnTemplateLoad.Location = new global::System.Drawing.Point(635, 365);
		this.btnTemplateLoad.Name = "btnTemplateLoad";
		this.btnTemplateLoad.Size = new global::System.Drawing.Size(208, 46);
		this.btnTemplateLoad.TabIndex = 29;
		this.btnTemplateLoad.Tag = "4009";
		this.btnTemplateLoad.Text = "Templates";
		this.btnTemplateLoad.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.btnTemplateLoad.UseVisualStyleBackColor = true;
		this.btnTemplateLoad.Click += new global::System.EventHandler(this.btnTemplateLoad_Click);
		this.splitContainer3.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.splitContainer3.BackColor = global::System.Drawing.Color.Navy;
		this.splitContainer3.Location = new global::System.Drawing.Point(6, 6);
		this.splitContainer3.Name = "splitContainer3";
		this.splitContainer3.Panel1.BackColor = global::System.Drawing.Color.White;
		this.splitContainer3.Panel1.Controls.Add(this.dgvParams);
		this.splitContainer3.Panel2.BackColor = global::System.Drawing.Color.White;
		this.splitContainer3.Panel2.Controls.Add(this.lblDTCsPresent);
		this.splitContainer3.Panel2.Controls.Add(this.buttonSelectAll);
		this.splitContainer3.Panel2.Controls.Add(this.buttonSelectNone);
		this.splitContainer3.Panel2.Controls.Add(this.chkParamsAutoUp);
		this.splitContainer3.Panel2.Controls.Add(this.chkMonitorErrors);
		this.splitContainer3.Panel2.Controls.Add(this.tbParamDescription);
		this.splitContainer3.Panel2.Controls.Add(this.btnParamsArrange);
		this.splitContainer3.Panel2.Controls.Add(this.btnArrangeUnits);
		this.splitContainer3.Panel2.Controls.Add(this.btnArrangeName);
		this.splitContainer3.Size = new global::System.Drawing.Size(837, 353);
		this.splitContainer3.SplitterDistance = 592;
		this.splitContainer3.TabIndex = 19;
		this.dgvParams.AllowUserToAddRows = false;
		this.dgvParams.AllowUserToDeleteRows = false;
		this.dgvParams.AllowUserToResizeRows = false;
		this.dgvParams.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.dgvParams.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
		this.dgvParams.BackgroundColor = global::System.Drawing.Color.White;
		this.dgvParams.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dgvParams.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvParams.ColumnHeadersVisible = false;
		this.dgvParams.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
		{
			this.paramsColSelect,
			this.dataGridViewTextBoxColumn1,
			this.dataGridViewTextBoxColumn2
		});
		this.dgvParams.Location = new global::System.Drawing.Point(0, 0);
		this.dgvParams.MultiSelect = false;
		this.dgvParams.Name = "dgvParams";
		this.dgvParams.ReadOnly = true;
		this.dgvParams.RowHeadersVisible = false;
		this.dgvParams.RowTemplate.DefaultCellStyle.BackColor = global::System.Drawing.Color.White;
		this.dgvParams.RowTemplate.DefaultCellStyle.Font = new global::System.Drawing.Font("Arial", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.dgvParams.RowTemplate.DefaultCellStyle.ForeColor = global::System.Drawing.Color.Navy;
		this.dgvParams.RowTemplate.DefaultCellStyle.SelectionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.dgvParams.RowTemplate.DefaultCellStyle.SelectionForeColor = global::System.Drawing.Color.Navy;
		this.dgvParams.RowTemplate.Height = 24;
		this.dgvParams.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.dgvParams.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgvParams.ShowEditingIcon = false;
		this.dgvParams.Size = new global::System.Drawing.Size(589, 353);
		this.dgvParams.StandardTab = true;
		this.dgvParams.TabIndex = 0;
		this.dgvParams.RowPrePaint += new global::System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvParams_RowPrePaint);
		this.dgvParams.CellClick += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParams_CellClick);
		this.dgvParams.SelectionChanged += new global::System.EventHandler(this.dgvParams_SelectionChanged);
		this.dgvParams.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.dgvParams_KeyUp);
		this.paramsColSelect.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		this.paramsColSelect.DataPropertyName = "Selected";
		this.paramsColSelect.HeaderText = "Select";
		this.paramsColSelect.MinimumWidth = 40;
		this.paramsColSelect.Name = "paramsColSelect";
		this.paramsColSelect.ReadOnly = true;
		this.paramsColSelect.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
		this.paramsColSelect.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		this.paramsColSelect.Width = 40;
		this.dataGridViewTextBoxColumn1.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
		this.dataGridViewTextBoxColumn1.FillWeight = 65f;
		this.dataGridViewTextBoxColumn1.HeaderText = "Parameter";
		this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn1.ReadOnly = true;
		this.dataGridViewTextBoxColumn2.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn2.DataPropertyName = "Value";
		this.dataGridViewTextBoxColumn2.FillWeight = 35f;
		this.dataGridViewTextBoxColumn2.HeaderText = "Value";
		this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
		this.dataGridViewTextBoxColumn2.ReadOnly = true;
		this.dataGridViewTextBoxColumn2.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.lblDTCsPresent.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.lblDTCsPresent.AutoSize = true;
		this.lblDTCsPresent.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.lblDTCsPresent.Font = new global::System.Drawing.Font("Arial", 8.064f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblDTCsPresent.ForeColor = global::System.Drawing.Color.Red;
		this.lblDTCsPresent.Location = new global::System.Drawing.Point(1, 207);
		this.lblDTCsPresent.Name = "lblDTCsPresent";
		this.lblDTCsPresent.Size = new global::System.Drawing.Size(238, 18);
		this.lblDTCsPresent.TabIndex = 30;
		this.lblDTCsPresent.Tag = "4011";
		this.lblDTCsPresent.Text = "The following DTCs are present:";
		this.lblDTCsPresent.Visible = false;
		this.buttonSelectAll.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.buttonSelectAll.AutoSize = true;
		this.buttonSelectAll.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.buttonSelectAll.ImageKey = "Key_A.png";
		this.buttonSelectAll.ImageList = this.imageList_0;
		this.buttonSelectAll.Location = new global::System.Drawing.Point(103, 307);
		this.buttonSelectAll.Name = "buttonSelectAll";
		this.buttonSelectAll.Size = new global::System.Drawing.Size(44, 46);
		this.buttonSelectAll.TabIndex = 31;
		this.buttonSelectAll.Tag = "4012";
		this.buttonSelectAll.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.buttonSelectAll.UseVisualStyleBackColor = true;
		this.buttonSelectAll.Click += new global::System.EventHandler(this.buttonSelectAll_Click);
		this.buttonSelectNone.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.buttonSelectNone.AutoSize = true;
		this.buttonSelectNone.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.buttonSelectNone.ImageKey = "Key_N.png";
		this.buttonSelectNone.ImageList = this.imageList_0;
		this.buttonSelectNone.Location = new global::System.Drawing.Point(153, 307);
		this.buttonSelectNone.Name = "buttonSelectNone";
		this.buttonSelectNone.Size = new global::System.Drawing.Size(44, 46);
		this.buttonSelectNone.TabIndex = 30;
		this.buttonSelectNone.Tag = "4013";
		this.buttonSelectNone.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.buttonSelectNone.UseVisualStyleBackColor = true;
		this.buttonSelectNone.Click += new global::System.EventHandler(this.buttonSelectNone_Click);
		this.chkParamsAutoUp.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.chkParamsAutoUp.Appearance = global::System.Windows.Forms.Appearance.Button;
		this.chkParamsAutoUp.AutoSize = true;
		this.chkParamsAutoUp.Enabled = false;
		this.chkParamsAutoUp.ImageKey = "Key_R.png";
		this.chkParamsAutoUp.ImageList = this.imageList_0;
		this.chkParamsAutoUp.Location = new global::System.Drawing.Point(53, 256);
		this.chkParamsAutoUp.Name = "chkParamsAutoUp";
		this.chkParamsAutoUp.Size = new global::System.Drawing.Size(149, 42);
		this.chkParamsAutoUp.TabIndex = 28;
		this.chkParamsAutoUp.Tag = "4005";
		this.chkParamsAutoUp.Text = "Auto Up";
		this.chkParamsAutoUp.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.chkParamsAutoUp.UseVisualStyleBackColor = true;
		this.chkMonitorErrors.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.chkMonitorErrors.Appearance = global::System.Windows.Forms.Appearance.Button;
		this.chkMonitorErrors.AutoSize = true;
		this.chkMonitorErrors.Enabled = false;
		this.chkMonitorErrors.ImageKey = "Key_E.png";
		this.chkMonitorErrors.ImageList = this.imageList_0;
		this.chkMonitorErrors.Location = new global::System.Drawing.Point(3, 162);
		this.chkMonitorErrors.Name = "chkMonitorErrors";
		this.chkMonitorErrors.Size = new global::System.Drawing.Size(214, 42);
		this.chkMonitorErrors.TabIndex = 29;
		this.chkMonitorErrors.Tag = "4010";
		this.chkMonitorErrors.Text = "Monitor DTCs";
		this.chkMonitorErrors.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.chkMonitorErrors.UseVisualStyleBackColor = true;
		this.chkMonitorErrors.CheckedChanged += new global::System.EventHandler(this.chkMonitorErrors_CheckedChanged);
		this.tbParamDescription.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.tbParamDescription.BackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.tbParamDescription.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.tbParamDescription.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.tbParamDescription.ForeColor = global::System.Drawing.Color.DarkSlateBlue;
		this.tbParamDescription.Location = new global::System.Drawing.Point(3, 0);
		this.tbParamDescription.Multiline = true;
		this.tbParamDescription.Name = "tbParamDescription";
		this.tbParamDescription.ReadOnly = true;
		this.tbParamDescription.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.tbParamDescription.Size = new global::System.Drawing.Size(238, 156);
		this.tbParamDescription.TabIndex = 1;
		this.btnParamsArrange.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.btnParamsArrange.AutoSize = true;
		this.btnParamsArrange.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.btnParamsArrange.ImageKey = "Key_S.png";
		this.btnParamsArrange.ImageList = this.imageList_0;
		this.btnParamsArrange.Location = new global::System.Drawing.Point(3, 255);
		this.btnParamsArrange.Name = "btnParamsArrange";
		this.btnParamsArrange.Size = new global::System.Drawing.Size(44, 46);
		this.btnParamsArrange.TabIndex = 2;
		this.btnParamsArrange.Tag = "4002";
		this.btnParamsArrange.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.btnParamsArrange.UseVisualStyleBackColor = true;
		this.btnParamsArrange.Click += new global::System.EventHandler(this.btnParamsArrange_Click);
		this.btnArrangeUnits.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.btnArrangeUnits.AutoSize = true;
		this.btnArrangeUnits.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.btnArrangeUnits.ImageKey = "Key_U.png";
		this.btnArrangeUnits.ImageList = this.imageList_0;
		this.btnArrangeUnits.Location = new global::System.Drawing.Point(53, 307);
		this.btnArrangeUnits.Name = "btnArrangeUnits";
		this.btnArrangeUnits.Size = new global::System.Drawing.Size(44, 46);
		this.btnArrangeUnits.TabIndex = 4;
		this.btnArrangeUnits.Tag = "4004";
		this.btnArrangeUnits.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.btnArrangeUnits.UseVisualStyleBackColor = true;
		this.btnArrangeUnits.Click += new global::System.EventHandler(this.btnArrangeUnits_Click);
		this.btnArrangeName.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.btnArrangeName.AutoSize = true;
		this.btnArrangeName.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.btnArrangeName.ImageKey = "Key_L.png";
		this.btnArrangeName.ImageList = this.imageList_0;
		this.btnArrangeName.Location = new global::System.Drawing.Point(3, 307);
		this.btnArrangeName.Name = "btnArrangeName";
		this.btnArrangeName.Size = new global::System.Drawing.Size(44, 46);
		this.btnArrangeName.TabIndex = 3;
		this.btnArrangeName.Tag = "4003";
		this.btnArrangeName.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.btnArrangeName.UseVisualStyleBackColor = true;
		this.btnArrangeName.Click += new global::System.EventHandler(this.btnArrangeName_Click);
		this.panel7.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.panel7.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("panel7.BackgroundImage");
		this.panel7.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
		this.panel7.Location = new global::System.Drawing.Point(4, 367);
		this.panel7.Name = "panel7";
		this.panel7.Size = new global::System.Drawing.Size(242, 44);
		this.panel7.TabIndex = 18;
		this.tabPageGraph.BackColor = global::System.Drawing.Color.White;
		this.tabPageGraph.Controls.Add(this.dgvTags);
		this.tabPageGraph.Controls.Add(this.flowLayoutPanel2);
		this.tabPageGraph.Controls.Add(this.panel9);
		this.tabPageGraph.Controls.Add(this.panel8);
		this.tabPageGraph.Controls.Add(this.panel2);
		this.tabPageGraph.Controls.Add(this.tableLayoutPanelGraphs);
		this.tabPageGraph.Controls.Add(this.tableLayoutPanelGraphParams);
		this.tabPageGraph.ImageKey = "Key_F5.png";
		this.tabPageGraph.Location = new global::System.Drawing.Point(4, 43);
		this.tabPageGraph.Name = "tabPageGraph";
		this.tabPageGraph.Size = new global::System.Drawing.Size(849, 413);
		this.tabPageGraph.TabIndex = 4;
		this.tabPageGraph.Tag = string.Empty;
		this.tabPageGraph.Text = "Graph";
		this.tabPageGraph.UseVisualStyleBackColor = true;
		this.dgvTags.AllowUserToAddRows = false;
		this.dgvTags.AllowUserToDeleteRows = false;
		this.dgvTags.AllowUserToResizeRows = false;
		this.dgvTags.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.dgvTags.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
		this.dgvTags.BackgroundColor = global::System.Drawing.Color.White;
		this.dgvTags.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvTags.ColumnHeadersVisible = false;
		this.dgvTags.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
		{
			this.Column4,
			this.Column5
		});
		this.dgvTags.Location = new global::System.Drawing.Point(544, 6);
		this.dgvTags.MultiSelect = false;
		this.dgvTags.Name = "dgvTags";
		this.dgvTags.RowHeadersVisible = false;
		this.dgvTags.RowTemplate.Height = 24;
		this.dgvTags.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.dgvTags.ShowEditingIcon = false;
		this.dgvTags.Size = new global::System.Drawing.Size(300, 273);
		this.dgvTags.StandardTab = true;
		this.dgvTags.TabIndex = 29;
		this.dgvTags.Visible = false;
		this.Column4.DataPropertyName = "ID";
		this.Column4.HeaderText = "Column4";
		this.Column4.Name = "Column4";
		this.Column4.ReadOnly = true;
		this.Column4.Width = 30;
		this.Column5.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.Column5.DataPropertyName = "VALUE";
		this.Column5.HeaderText = "Column5";
		this.Column5.Name = "Column5";
		this.flowLayoutPanel2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.flowLayoutPanel2.Controls.Add(this.label8);
		this.flowLayoutPanel2.Controls.Add(this.button2);
		this.flowLayoutPanel2.Controls.Add(this.cbGraphCount);
		this.flowLayoutPanel2.Controls.Add(this.label4);
		this.flowLayoutPanel2.Controls.Add(this.button3);
		this.flowLayoutPanel2.Controls.Add(this.cbGraphRate);
		this.flowLayoutPanel2.Controls.Add(this.label3);
		this.flowLayoutPanel2.Controls.Add(this.button4);
		this.flowLayoutPanel2.Controls.Add(this.cbGraphScale);
		this.flowLayoutPanel2.Controls.Add(this.button5);
		this.flowLayoutPanel2.Controls.Add(this.label9);
		this.flowLayoutPanel2.Location = new global::System.Drawing.Point(252, 285);
		this.flowLayoutPanel2.Name = "flowLayoutPanel2";
		this.flowLayoutPanel2.Size = new global::System.Drawing.Size(592, 33);
		this.flowLayoutPanel2.TabIndex = 28;
		this.label8.AutoSize = true;
		this.label8.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.label8.Font = new global::System.Drawing.Font("Arial", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label8.Location = new global::System.Drawing.Point(3, 0);
		this.label8.Margin = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
		this.label8.Name = "label8";
		this.label8.Size = new global::System.Drawing.Size(80, 35);
		this.label8.TabIndex = 20;
		this.label8.Tag = "5020";
		this.label8.Text = "Graphs:";
		this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.button2.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.button2.FlatAppearance.BorderSize = 0;
		this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.button2.ImageKey = "Key_G.png";
		this.button2.ImageList = this.imageList_0;
		this.button2.Location = new global::System.Drawing.Point(83, 0);
		this.button2.Margin = new global::System.Windows.Forms.Padding(0);
		this.button2.Name = "button2";
		this.button2.Size = new global::System.Drawing.Size(33, 35);
		this.button2.TabIndex = 26;
		this.button2.UseVisualStyleBackColor = true;
		this.cbGraphCount.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbGraphCount.Font = new global::System.Drawing.Font("Arial", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.cbGraphCount.FormattingEnabled = true;
		this.cbGraphCount.Items.AddRange(new object[]
		{
			"1",
			"2",
			"3",
			"4"
		});
		this.cbGraphCount.Location = new global::System.Drawing.Point(119, 3);
		this.cbGraphCount.Name = "cbGraphCount";
		this.cbGraphCount.Size = new global::System.Drawing.Size(46, 29);
		this.cbGraphCount.TabIndex = 19;
		this.cbGraphCount.Tag = "5020";
		this.cbGraphCount.SelectedIndexChanged += new global::System.EventHandler(this.cbGraphCount_SelectedIndexChanged);
		this.label4.AutoSize = true;
		this.label4.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.label4.Font = new global::System.Drawing.Font("Arial", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label4.Location = new global::System.Drawing.Point(171, 0);
		this.label4.Margin = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
		this.label4.Name = "label4";
		this.label4.Size = new global::System.Drawing.Size(57, 35);
		this.label4.TabIndex = 14;
		this.label4.Tag = "5021";
		this.label4.Text = "Rate:";
		this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.button3.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.button3.FlatAppearance.BorderSize = 0;
		this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.button3.ImageKey = "Key_R.png";
		this.button3.ImageList = this.imageList_0;
		this.button3.Location = new global::System.Drawing.Point(228, 0);
		this.button3.Margin = new global::System.Windows.Forms.Padding(0);
		this.button3.Name = "button3";
		this.button3.Size = new global::System.Drawing.Size(33, 35);
		this.button3.TabIndex = 27;
		this.button3.UseVisualStyleBackColor = true;
		this.cbGraphRate.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbGraphRate.Font = new global::System.Drawing.Font("Arial", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.cbGraphRate.FormattingEnabled = true;
		this.cbGraphRate.Items.AddRange(new object[]
		{
			"1/sec",
			"2/sec",
			"5/sec",
			"10/sec",
			"20/sec",
			"30/sec"
		});
		this.cbGraphRate.Location = new global::System.Drawing.Point(264, 3);
		this.cbGraphRate.Name = "cbGraphRate";
		this.cbGraphRate.Size = new global::System.Drawing.Size(105, 29);
		this.cbGraphRate.TabIndex = 2;
		this.cbGraphRate.Tag = "5021";
		this.cbGraphRate.SelectedIndexChanged += new global::System.EventHandler(this.cbGraphRate_SelectedIndexChanged);
		this.label3.AutoSize = true;
		this.label3.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.label3.Font = new global::System.Drawing.Font("Arial", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label3.ImageAlign = global::System.Drawing.ContentAlignment.MiddleRight;
		this.label3.ImageKey = "(none)";
		this.label3.Location = new global::System.Drawing.Point(375, 0);
		this.label3.Margin = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
		this.label3.Name = "label3";
		this.label3.Size = new global::System.Drawing.Size(65, 35);
		this.label3.TabIndex = 7;
		this.label3.Tag = "5022";
		this.label3.Text = "Scale:";
		this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.button4.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.button4.FlatAppearance.BorderSize = 0;
		this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.button4.ImageKey = "Key_S.png";
		this.button4.ImageList = this.imageList_0;
		this.button4.Location = new global::System.Drawing.Point(440, 0);
		this.button4.Margin = new global::System.Windows.Forms.Padding(0);
		this.button4.Name = "button4";
		this.button4.Size = new global::System.Drawing.Size(33, 35);
		this.button4.TabIndex = 28;
		this.button4.UseVisualStyleBackColor = true;
		this.cbGraphScale.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbGraphScale.Font = new global::System.Drawing.Font("Arial", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.cbGraphScale.FormattingEnabled = true;
		this.cbGraphScale.Items.AddRange(new object[]
		{
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
		this.cbGraphScale.Location = new global::System.Drawing.Point(476, 3);
		this.cbGraphScale.Name = "cbGraphScale";
		this.cbGraphScale.Size = new global::System.Drawing.Size(72, 29);
		this.cbGraphScale.TabIndex = 3;
		this.cbGraphScale.Tag = "5022";
		this.cbGraphScale.SelectedIndexChanged += new global::System.EventHandler(this.cbGraphScale_SelectedIndexChanged);
		this.button5.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.button5.FlatAppearance.BorderSize = 0;
		this.button5.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.button5.ImageKey = "Key_T.png";
		this.button5.ImageList = this.imageList_0;
		this.button5.Location = new global::System.Drawing.Point(556, 0);
		this.button5.Margin = new global::System.Windows.Forms.Padding(5, 0, 0, 0);
		this.button5.Name = "button5";
		this.button5.Size = new global::System.Drawing.Size(33, 35);
		this.button5.TabIndex = 27;
		this.button5.UseVisualStyleBackColor = true;
		this.label9.AutoSize = true;
		this.label9.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.label9.Font = new global::System.Drawing.Font("Arial", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label9.Location = new global::System.Drawing.Point(3, 35);
		this.label9.Margin = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
		this.label9.Name = "label9";
		this.label9.Size = new global::System.Drawing.Size(51, 21);
		this.label9.TabIndex = 26;
		this.label9.Tag = "5030";
		this.label9.Text = "Tags";
		this.label9.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
		this.panel9.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.panel9.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel9.Controls.Add(this.tbRecordingName);
		this.panel9.Controls.Add(this.buttonGraphStart);
		this.panel9.Controls.Add(this.lblGraphStatus);
		this.panel9.Controls.Add(this.lblGraphTime);
		this.panel9.Location = new global::System.Drawing.Point(591, 320);
		this.panel9.MinimumSize = new global::System.Drawing.Size(200, 90);
		this.panel9.Name = "panel9";
		this.panel9.Size = new global::System.Drawing.Size(253, 90);
		this.panel9.TabIndex = 27;
		this.tbRecordingName.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.tbRecordingName.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.tbRecordingName.ForeColor = global::System.Drawing.Color.Navy;
		this.tbRecordingName.Location = new global::System.Drawing.Point(3, 3);
		this.tbRecordingName.Name = "tbRecordingName";
		this.tbRecordingName.Size = new global::System.Drawing.Size(245, 35);
		this.tbRecordingName.TabIndex = 28;
		this.buttonGraphStart.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
		this.buttonGraphStart.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.buttonGraphStart.ImageKey = "Key_F10.png";
		this.buttonGraphStart.ImageList = this.imageList_0;
		this.buttonGraphStart.Location = new global::System.Drawing.Point(72, 40);
		this.buttonGraphStart.Name = "buttonGraphStart";
		this.buttonGraphStart.Size = new global::System.Drawing.Size(176, 46);
		this.buttonGraphStart.TabIndex = 0;
		this.buttonGraphStart.Tag = "5005";
		this.buttonGraphStart.Text = "Start";
		this.buttonGraphStart.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.buttonGraphStart.UseVisualStyleBackColor = true;
		this.buttonGraphStart.Click += new global::System.EventHandler(this.buttonGraphStart_Click);
		this.lblGraphStatus.AutoSize = true;
		this.lblGraphStatus.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblGraphStatus.ForeColor = global::System.Drawing.Color.Green;
		this.lblGraphStatus.Location = new global::System.Drawing.Point(-1, 39);
		this.lblGraphStatus.Name = "lblGraphStatus";
		this.lblGraphStatus.Size = new global::System.Drawing.Size(148, 24);
		this.lblGraphStatus.TabIndex = 11;
		this.lblGraphStatus.Text = "Processing ...";
		this.lblGraphTime.AutoSize = true;
		this.lblGraphTime.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblGraphTime.ForeColor = global::System.Drawing.Color.Green;
		this.lblGraphTime.Location = new global::System.Drawing.Point(-1, 63);
		this.lblGraphTime.Name = "lblGraphTime";
		this.lblGraphTime.Size = new global::System.Drawing.Size(58, 24);
		this.lblGraphTime.TabIndex = 15;
		this.lblGraphTime.Text = "0000";
		this.lblGraphTime.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
		this.panel8.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.panel8.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel8.Controls.Add(this.btnExportGraph);
		this.panel8.Controls.Add(this.label5);
		this.panel8.Controls.Add(this.cbGraphFiles);
		this.panel8.Controls.Add(this.btnImportGraph);
		this.panel8.Location = new global::System.Drawing.Point(252, 320);
		this.panel8.Name = "panel8";
		this.panel8.Size = new global::System.Drawing.Size(333, 90);
		this.panel8.TabIndex = 26;
		this.btnExportGraph.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.btnExportGraph.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.btnExportGraph.ImageKey = "Key_E.png";
		this.btnExportGraph.ImageList = this.imageList_0;
		this.btnExportGraph.Location = new global::System.Drawing.Point(3, 40);
		this.btnExportGraph.Name = "btnExportGraph";
		this.btnExportGraph.Size = new global::System.Drawing.Size(158, 46);
		this.btnExportGraph.TabIndex = 5;
		this.btnExportGraph.Tag = "5007";
		this.btnExportGraph.Text = "Export";
		this.btnExportGraph.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.btnExportGraph.UseVisualStyleBackColor = true;
		this.btnExportGraph.Click += new global::System.EventHandler(this.btnExportGraph_Click);
		this.label5.AutoSize = true;
		this.label5.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label5.Location = new global::System.Drawing.Point(3, 8);
		this.label5.Name = "label5";
		this.label5.Size = new global::System.Drawing.Size(52, 24);
		this.label5.TabIndex = 24;
		this.label5.Tag = "5004";
		this.label5.Text = "File:";
		this.cbGraphFiles.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.cbGraphFiles.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbGraphFiles.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.cbGraphFiles.FormattingEnabled = true;
		this.cbGraphFiles.Location = new global::System.Drawing.Point(88, 3);
		this.cbGraphFiles.Name = "cbGraphFiles";
		this.cbGraphFiles.Size = new global::System.Drawing.Size(239, 32);
		this.cbGraphFiles.TabIndex = 22;
		this.cbGraphFiles.Tag = "5004";
		this.cbGraphFiles.SelectedIndexChanged += new global::System.EventHandler(this.cbGraphFiles_SelectedIndexChanged);
		this.btnImportGraph.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.btnImportGraph.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.btnImportGraph.ImageKey = "Key_I.png";
		this.btnImportGraph.ImageList = this.imageList_0;
		this.btnImportGraph.Location = new global::System.Drawing.Point(167, 40);
		this.btnImportGraph.Name = "btnImportGraph";
		this.btnImportGraph.Size = new global::System.Drawing.Size(160, 46);
		this.btnImportGraph.TabIndex = 25;
		this.btnImportGraph.Tag = "5008";
		this.btnImportGraph.Text = "Import";
		this.btnImportGraph.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.btnImportGraph.UseVisualStyleBackColor = true;
		this.btnImportGraph.Click += new global::System.EventHandler(this.btnImportGraph_Click);
		this.panel2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.panel2.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("panel2.BackgroundImage");
		this.panel2.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
		this.panel2.Location = new global::System.Drawing.Point(4, 367);
		this.panel2.Name = "panel2";
		this.panel2.Size = new global::System.Drawing.Size(242, 44);
		this.panel2.TabIndex = 23;
		this.tableLayoutPanelGraphs.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.tableLayoutPanelGraphs.ColumnCount = 1;
		this.tableLayoutPanelGraphs.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanelGraphs.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
		this.tableLayoutPanelGraphs.Controls.Add(this.graphPanel1, 0, 0);
		this.tableLayoutPanelGraphs.Location = new global::System.Drawing.Point(252, 3);
		this.tableLayoutPanelGraphs.Name = "tableLayoutPanelGraphs";
		this.tableLayoutPanelGraphs.RowCount = 1;
		this.tableLayoutPanelGraphs.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanelGraphs.Size = new global::System.Drawing.Size(592, 279);
		this.tableLayoutPanelGraphs.TabIndex = 18;
		this.tableLayoutPanelGraphs.Paint += new global::System.Windows.Forms.PaintEventHandler(this.tableLayoutPanelGraphs_Paint);
		this.graphPanel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.graphPanel1.BackColor = global::System.Drawing.Color.White;
		this.graphPanel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.graphPanel1.method_4(0);
		this.graphPanel1.method_2(1f);
		this.graphPanel1.Location = new global::System.Drawing.Point(3, 50);
		this.graphPanel1.Name = "graphPanel1";
		this.graphPanel1.Size = new global::System.Drawing.Size(586, 226);
		this.graphPanel1.TabIndex = 17;
		this.tableLayoutPanelGraphParams.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.tableLayoutPanelGraphParams.AutoScroll = true;
		this.tableLayoutPanelGraphParams.CellBorderStyle = global::System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
		this.tableLayoutPanelGraphParams.ColumnCount = 1;
		this.tableLayoutPanelGraphParams.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanelGraphParams.Location = new global::System.Drawing.Point(7, 6);
		this.tableLayoutPanelGraphParams.Name = "tableLayoutPanelGraphParams";
		this.tableLayoutPanelGraphParams.RowCount = 1;
		this.tableLayoutPanelGraphParams.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 364f));
		this.tableLayoutPanelGraphParams.Size = new global::System.Drawing.Size(239, 355);
		this.tableLayoutPanelGraphParams.TabIndex = 21;
		this.tabPageActuators.BackColor = global::System.Drawing.Color.White;
		this.tabPageActuators.Controls.Add(this.splitContainer4);
		this.tabPageActuators.Controls.Add(this.panel10);
		this.tabPageActuators.Controls.Add(this.btnActuatorsExecute);
		this.tabPageActuators.ImageKey = "Key_F6.png";
		this.tabPageActuators.Location = new global::System.Drawing.Point(4, 43);
		this.tabPageActuators.Name = "tabPageActuators";
		this.tabPageActuators.Size = new global::System.Drawing.Size(849, 413);
		this.tabPageActuators.TabIndex = 6;
		this.tabPageActuators.Tag = string.Empty;
		this.tabPageActuators.Text = "Actuators";
		this.tabPageActuators.UseVisualStyleBackColor = true;
		this.splitContainer4.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.splitContainer4.BackColor = global::System.Drawing.Color.Navy;
		this.splitContainer4.Location = new global::System.Drawing.Point(6, 6);
		this.splitContainer4.Name = "splitContainer4";
		this.splitContainer4.Panel1.BackColor = global::System.Drawing.Color.White;
		this.splitContainer4.Panel1.Controls.Add(this.dgvActuators);
		this.splitContainer4.Panel2.BackColor = global::System.Drawing.Color.White;
		this.splitContainer4.Panel2.Controls.Add(this.dgvActParams);
		this.splitContainer4.Panel2.Controls.Add(this.tbActuatorsDesc);
		this.splitContainer4.Size = new global::System.Drawing.Size(837, 353);
		this.splitContainer4.SplitterDistance = 494;
		this.splitContainer4.TabIndex = 20;
		this.dgvActuators.AllowUserToAddRows = false;
		this.dgvActuators.AllowUserToDeleteRows = false;
		this.dgvActuators.AllowUserToResizeRows = false;
		this.dgvActuators.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.dgvActuators.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
		this.dgvActuators.BackgroundColor = global::System.Drawing.Color.White;
		this.dgvActuators.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dgvActuators.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvActuators.ColumnHeadersVisible = false;
		this.dgvActuators.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
		{
			this.dataGridViewCheckBoxColumn2,
			this.dataGridViewTextBoxColumn7,
			this.dataGridViewTextBoxColumn8
		});
		this.dgvActuators.Location = new global::System.Drawing.Point(0, 0);
		this.dgvActuators.MultiSelect = false;
		this.dgvActuators.Name = "dgvActuators";
		this.dgvActuators.ReadOnly = true;
		this.dgvActuators.RowHeadersVisible = false;
		this.dgvActuators.RowTemplate.DefaultCellStyle.BackColor = global::System.Drawing.Color.White;
		this.dgvActuators.RowTemplate.DefaultCellStyle.Font = new global::System.Drawing.Font("Arial", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.dgvActuators.RowTemplate.DefaultCellStyle.ForeColor = global::System.Drawing.Color.Navy;
		this.dgvActuators.RowTemplate.DefaultCellStyle.SelectionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.dgvActuators.RowTemplate.DefaultCellStyle.SelectionForeColor = global::System.Drawing.Color.Navy;
		this.dgvActuators.RowTemplate.Height = 24;
		this.dgvActuators.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.dgvActuators.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgvActuators.ShowEditingIcon = false;
		this.dgvActuators.Size = new global::System.Drawing.Size(491, 353);
		this.dgvActuators.StandardTab = true;
		this.dgvActuators.TabIndex = 0;
		this.dgvActuators.SelectionChanged += new global::System.EventHandler(this.dgvActuators_SelectionChanged);
		this.dataGridViewCheckBoxColumn2.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
		this.dataGridViewCheckBoxColumn2.DataPropertyName = "Selected";
		this.dataGridViewCheckBoxColumn2.HeaderText = "Select";
		this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
		this.dataGridViewCheckBoxColumn2.ReadOnly = true;
		this.dataGridViewCheckBoxColumn2.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
		this.dataGridViewCheckBoxColumn2.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		this.dataGridViewCheckBoxColumn2.Visible = false;
		this.dataGridViewTextBoxColumn7.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn7.DataPropertyName = "Name";
		this.dataGridViewTextBoxColumn7.FillWeight = 70f;
		this.dataGridViewTextBoxColumn7.HeaderText = "Parameter";
		this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
		this.dataGridViewTextBoxColumn7.ReadOnly = true;
		this.dataGridViewTextBoxColumn7.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn8.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn8.DataPropertyName = "Value";
		this.dataGridViewTextBoxColumn8.FillWeight = 30f;
		this.dataGridViewTextBoxColumn8.HeaderText = "Value";
		this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
		this.dataGridViewTextBoxColumn8.ReadOnly = true;
		this.dataGridViewTextBoxColumn8.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn8.Visible = false;
		this.dgvActParams.AllowUserToAddRows = false;
		this.dgvActParams.AllowUserToDeleteRows = false;
		this.dgvActParams.AllowUserToResizeRows = false;
		this.dgvActParams.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.dgvActParams.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
		this.dgvActParams.BackgroundColor = global::System.Drawing.Color.White;
		this.dgvActParams.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dgvActParams.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvActParams.ColumnHeadersVisible = false;
		this.dgvActParams.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
		{
			this.dataGridViewCheckBoxColumn3,
			this.dataGridViewTextBoxColumn5,
			this.dataGridViewTextBoxColumn6
		});
		this.dgvActParams.Location = new global::System.Drawing.Point(3, 217);
		this.dgvActParams.MultiSelect = false;
		this.dgvActParams.Name = "dgvActParams";
		this.dgvActParams.ReadOnly = true;
		this.dgvActParams.RowHeadersVisible = false;
		this.dgvActParams.RowTemplate.DefaultCellStyle.BackColor = global::System.Drawing.Color.White;
		this.dgvActParams.RowTemplate.DefaultCellStyle.Font = new global::System.Drawing.Font("Arial", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.dgvActParams.RowTemplate.DefaultCellStyle.ForeColor = global::System.Drawing.Color.Navy;
		this.dgvActParams.RowTemplate.DefaultCellStyle.SelectionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.dgvActParams.RowTemplate.DefaultCellStyle.SelectionForeColor = global::System.Drawing.Color.Navy;
		this.dgvActParams.RowTemplate.Height = 24;
		this.dgvActParams.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.dgvActParams.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgvActParams.ShowEditingIcon = false;
		this.dgvActParams.Size = new global::System.Drawing.Size(336, 136);
		this.dgvActParams.StandardTab = true;
		this.dgvActParams.TabIndex = 2;
		this.dgvActParams.Tag = "3";
		this.dataGridViewCheckBoxColumn3.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		this.dataGridViewCheckBoxColumn3.DataPropertyName = "Selected";
		this.dataGridViewCheckBoxColumn3.HeaderText = "Select";
		this.dataGridViewCheckBoxColumn3.MinimumWidth = 40;
		this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
		this.dataGridViewCheckBoxColumn3.ReadOnly = true;
		this.dataGridViewCheckBoxColumn3.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
		this.dataGridViewCheckBoxColumn3.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		this.dataGridViewCheckBoxColumn3.Visible = false;
		this.dataGridViewCheckBoxColumn3.Width = 40;
		this.dataGridViewTextBoxColumn5.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn5.DataPropertyName = "Name";
		this.dataGridViewTextBoxColumn5.FillWeight = 70f;
		this.dataGridViewTextBoxColumn5.HeaderText = "Parameter";
		this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
		this.dataGridViewTextBoxColumn5.ReadOnly = true;
		this.dataGridViewTextBoxColumn6.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn6.DataPropertyName = "Value";
		this.dataGridViewTextBoxColumn6.FillWeight = 30f;
		this.dataGridViewTextBoxColumn6.HeaderText = "Value";
		this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
		this.dataGridViewTextBoxColumn6.ReadOnly = true;
		this.dataGridViewTextBoxColumn6.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.tbActuatorsDesc.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.tbActuatorsDesc.BackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.tbActuatorsDesc.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.tbActuatorsDesc.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.tbActuatorsDesc.ForeColor = global::System.Drawing.Color.DarkSlateBlue;
		this.tbActuatorsDesc.Location = new global::System.Drawing.Point(3, 0);
		this.tbActuatorsDesc.Multiline = true;
		this.tbActuatorsDesc.Name = "tbActuatorsDesc";
		this.tbActuatorsDesc.ReadOnly = true;
		this.tbActuatorsDesc.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.tbActuatorsDesc.Size = new global::System.Drawing.Size(333, 211);
		this.tbActuatorsDesc.TabIndex = 1;
		this.panel10.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.panel10.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("panel10.BackgroundImage");
		this.panel10.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
		this.panel10.Location = new global::System.Drawing.Point(4, 367);
		this.panel10.Name = "panel10";
		this.panel10.Size = new global::System.Drawing.Size(242, 44);
		this.panel10.TabIndex = 19;
		this.btnActuatorsExecute.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.btnActuatorsExecute.AutoSize = true;
		this.btnActuatorsExecute.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.btnActuatorsExecute.ImageKey = "Key_F10.png";
		this.btnActuatorsExecute.ImageList = this.imageList_0;
		this.btnActuatorsExecute.Location = new global::System.Drawing.Point(687, 365);
		this.btnActuatorsExecute.Name = "btnActuatorsExecute";
		this.btnActuatorsExecute.Size = new global::System.Drawing.Size(156, 46);
		this.btnActuatorsExecute.TabIndex = 2;
		this.btnActuatorsExecute.Tag = "6002";
		this.btnActuatorsExecute.Text = "Execute";
		this.btnActuatorsExecute.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.btnActuatorsExecute.UseVisualStyleBackColor = true;
		this.btnActuatorsExecute.Click += new global::System.EventHandler(this.btnActuatorsExecute_Click);
		this.tabPageAdjustments.BackColor = global::System.Drawing.Color.White;
		this.tabPageAdjustments.Controls.Add(this.btnAdjustmentsExecute);
		this.tabPageAdjustments.Controls.Add(this.splitContainer5);
		this.tabPageAdjustments.Controls.Add(this.panel11);
		this.tabPageAdjustments.ImageKey = "Key_F7.png";
		this.tabPageAdjustments.Location = new global::System.Drawing.Point(4, 43);
		this.tabPageAdjustments.Name = "tabPageAdjustments";
		this.tabPageAdjustments.Size = new global::System.Drawing.Size(849, 413);
		this.tabPageAdjustments.TabIndex = 7;
		this.tabPageAdjustments.Tag = string.Empty;
		this.tabPageAdjustments.Text = "Adjustments";
		this.tabPageAdjustments.UseVisualStyleBackColor = true;
		this.btnAdjustmentsExecute.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.btnAdjustmentsExecute.AutoSize = true;
		this.btnAdjustmentsExecute.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.btnAdjustmentsExecute.ImageKey = "Key_F10.png";
		this.btnAdjustmentsExecute.ImageList = this.imageList_0;
		this.btnAdjustmentsExecute.Location = new global::System.Drawing.Point(686, 365);
		this.btnAdjustmentsExecute.Name = "btnAdjustmentsExecute";
		this.btnAdjustmentsExecute.Size = new global::System.Drawing.Size(157, 46);
		this.btnAdjustmentsExecute.TabIndex = 22;
		this.btnAdjustmentsExecute.Tag = "7002";
		this.btnAdjustmentsExecute.Text = "Execute";
		this.btnAdjustmentsExecute.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.btnAdjustmentsExecute.UseVisualStyleBackColor = true;
		this.btnAdjustmentsExecute.Click += new global::System.EventHandler(this.btnAdjustmentsExecute_Click);
		this.splitContainer5.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.splitContainer5.BackColor = global::System.Drawing.Color.Navy;
		this.splitContainer5.Location = new global::System.Drawing.Point(6, 6);
		this.splitContainer5.Name = "splitContainer5";
		this.splitContainer5.Panel1.BackColor = global::System.Drawing.Color.White;
		this.splitContainer5.Panel1.Controls.Add(this.dgvAdjustments);
		this.splitContainer5.Panel2.BackColor = global::System.Drawing.Color.White;
		this.splitContainer5.Panel2.Controls.Add(this.tbAdjDesc);
		this.splitContainer5.Size = new global::System.Drawing.Size(837, 353);
		this.splitContainer5.SplitterDistance = 437;
		this.splitContainer5.TabIndex = 21;
		this.dgvAdjustments.AllowUserToAddRows = false;
		this.dgvAdjustments.AllowUserToDeleteRows = false;
		this.dgvAdjustments.AllowUserToResizeRows = false;
		this.dgvAdjustments.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.dgvAdjustments.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
		this.dgvAdjustments.BackgroundColor = global::System.Drawing.Color.White;
		this.dgvAdjustments.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dgvAdjustments.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvAdjustments.ColumnHeadersVisible = false;
		this.dgvAdjustments.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
		{
			this.dataGridViewCheckBoxColumn1,
			this.dataGridViewTextBoxColumn3,
			this.dataGridViewTextBoxColumn4
		});
		this.dgvAdjustments.Location = new global::System.Drawing.Point(0, 0);
		this.dgvAdjustments.MultiSelect = false;
		this.dgvAdjustments.Name = "dgvAdjustments";
		this.dgvAdjustments.ReadOnly = true;
		this.dgvAdjustments.RowHeadersVisible = false;
		this.dgvAdjustments.RowTemplate.DefaultCellStyle.BackColor = global::System.Drawing.Color.White;
		this.dgvAdjustments.RowTemplate.DefaultCellStyle.Font = new global::System.Drawing.Font("Arial", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.dgvAdjustments.RowTemplate.DefaultCellStyle.ForeColor = global::System.Drawing.Color.Navy;
		this.dgvAdjustments.RowTemplate.DefaultCellStyle.SelectionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.dgvAdjustments.RowTemplate.DefaultCellStyle.SelectionForeColor = global::System.Drawing.Color.Navy;
		this.dgvAdjustments.RowTemplate.Height = 24;
		this.dgvAdjustments.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.dgvAdjustments.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgvAdjustments.ShowEditingIcon = false;
		this.dgvAdjustments.Size = new global::System.Drawing.Size(434, 353);
		this.dgvAdjustments.StandardTab = true;
		this.dgvAdjustments.TabIndex = 0;
		this.dgvAdjustments.SelectionChanged += new global::System.EventHandler(this.dgvAdjustments_SelectionChanged);
		this.dataGridViewCheckBoxColumn1.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
		this.dataGridViewCheckBoxColumn1.DataPropertyName = "Selected";
		this.dataGridViewCheckBoxColumn1.HeaderText = "Select";
		this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
		this.dataGridViewCheckBoxColumn1.ReadOnly = true;
		this.dataGridViewCheckBoxColumn1.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
		this.dataGridViewCheckBoxColumn1.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		this.dataGridViewCheckBoxColumn1.Visible = false;
		this.dataGridViewTextBoxColumn3.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
		this.dataGridViewTextBoxColumn3.FillWeight = 70f;
		this.dataGridViewTextBoxColumn3.HeaderText = "Parameter";
		this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
		this.dataGridViewTextBoxColumn3.ReadOnly = true;
		this.dataGridViewTextBoxColumn3.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn4.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn4.DataPropertyName = "Value";
		this.dataGridViewTextBoxColumn4.FillWeight = 30f;
		this.dataGridViewTextBoxColumn4.HeaderText = "Value";
		this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
		this.dataGridViewTextBoxColumn4.ReadOnly = true;
		this.dataGridViewTextBoxColumn4.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn4.Visible = false;
		this.tbAdjDesc.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.tbAdjDesc.BackColor = global::System.Drawing.Color.FromArgb(255, 255, 128);
		this.tbAdjDesc.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.tbAdjDesc.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.tbAdjDesc.ForeColor = global::System.Drawing.Color.DarkSlateBlue;
		this.tbAdjDesc.Location = new global::System.Drawing.Point(3, 0);
		this.tbAdjDesc.Multiline = true;
		this.tbAdjDesc.Name = "tbAdjDesc";
		this.tbAdjDesc.ReadOnly = true;
		this.tbAdjDesc.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.tbAdjDesc.Size = new global::System.Drawing.Size(393, 353);
		this.tbAdjDesc.TabIndex = 1;
		this.panel11.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.panel11.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("panel11.BackgroundImage");
		this.panel11.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
		this.panel11.Location = new global::System.Drawing.Point(4, 367);
		this.panel11.Name = "panel11";
		this.panel11.Size = new global::System.Drawing.Size(242, 44);
		this.panel11.TabIndex = 20;
		this.tabPageLog.BackColor = global::System.Drawing.Color.White;
		this.tabPageLog.Controls.Add(this.textBoxLog);
		this.tabPageLog.ImageKey = "Key_F12.png";
		this.tabPageLog.Location = new global::System.Drawing.Point(4, 43);
		this.tabPageLog.Name = "tabPageLog";
		this.tabPageLog.Padding = new global::System.Windows.Forms.Padding(3);
		this.tabPageLog.Size = new global::System.Drawing.Size(849, 413);
		this.tabPageLog.TabIndex = 1;
		this.tabPageLog.Tag = string.Empty;
		this.tabPageLog.Text = "Log";
		this.tabPageLog.UseVisualStyleBackColor = true;
		this.textBoxLog.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.textBoxLog.Location = new global::System.Drawing.Point(6, 6);
		this.textBoxLog.Multiline = true;
		this.textBoxLog.Name = "textBoxLog";
		this.textBoxLog.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.textBoxLog.Size = new global::System.Drawing.Size(837, 401);
		this.textBoxLog.TabIndex = 0;
		this.menuStrip1.Enabled = false;
		this.menuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.fileToolStripMenuItem
		});
		this.menuStrip1.Location = new global::System.Drawing.Point(0, 0);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.Size = new global::System.Drawing.Size(826, 28);
		this.menuStrip1.TabIndex = 1;
		this.menuStrip1.Text = "menuStrip1";
		this.menuStrip1.Visible = false;
		this.fileToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.exitToolStripMenuItem
		});
		this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
		this.fileToolStripMenuItem.Size = new global::System.Drawing.Size(46, 24);
		this.fileToolStripMenuItem.Text = "File";
		this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
		this.exitToolStripMenuItem.Size = new global::System.Drawing.Size(104, 26);
		this.exitToolStripMenuItem.Text = "Exit";
		this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
		{
			this.tsslAction,
			this.tsslConnProblem,
			this.ttslMsg
		});
		this.statusStrip1.Location = new global::System.Drawing.Point(0, 474);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Size = new global::System.Drawing.Size(881, 30);
		this.statusStrip1.TabIndex = 2;
		this.statusStrip1.Text = "statusStrip1";
		this.tsslAction.AutoSize = false;
		this.tsslAction.BorderSides = global::System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
		this.tsslAction.Name = "tsslAction";
		this.tsslAction.Size = new global::System.Drawing.Size(35, 25);
		this.tsslAction.Text = "--";
		this.tsslConnProblem.BorderSides = global::System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
		this.tsslConnProblem.ForeColor = global::System.Drawing.Color.Red;
		this.tsslConnProblem.Name = "tsslConnProblem";
		this.tsslConnProblem.Size = new global::System.Drawing.Size(225, 25);
		this.tsslConnProblem.Tag = "1060";
		this.tsslConnProblem.Text = "Serial Port Latency Too High!!!";
		this.tsslConnProblem.Visible = false;
		this.ttslMsg.BorderSides = global::System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
		this.ttslMsg.Name = "ttslMsg";
		this.ttslMsg.Size = new global::System.Drawing.Size(107, 25);
		this.ttslMsg.Text = "Disconnected";
		this.timer_0.Interval = 300;
		this.timer_0.Tick += new global::System.EventHandler(this.timer_0_Tick);
		this.timer_1.Interval = 1000;
		this.timer_1.Tick += new global::System.EventHandler(this.timer_1_Tick);
		this.saveFileDialog_0.DefaultExt = "*.csv";
		this.saveFileDialog_0.Filter = "CSV Files|*.csv|All files|*.*";
		this.saveFileDialog_0.RestoreDirectory = true;
		this.saveFileDialog_0.Title = "Export CSV file";
		this.timer_2.Tick += new global::System.EventHandler(this.timer_2_Tick);
		this.lblLoading.AutoSize = true;
		this.lblLoading.Font = new global::System.Drawing.Font("Arial", 24f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblLoading.ForeColor = global::System.Drawing.Color.Navy;
		this.lblLoading.Location = new global::System.Drawing.Point(7, 6);
		this.lblLoading.Name = "lblLoading";
		this.lblLoading.Size = new global::System.Drawing.Size(235, 49);
		this.lblLoading.TabIndex = 3;
		this.lblLoading.Text = "Loading ...";
		this.lblLoading.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.openFileDialog_0.DefaultExt = "*.csv";
		this.openFileDialog_0.Filter = "CSV Files|*.csv|All files|*.*";
		this.openFileDialog_0.RestoreDirectory = true;
		this.openFileDialog_0.Title = "Import CSV File";
		this.toolTip_0.AutoPopDelay = 20000;
		this.toolTip_0.BackColor = global::System.Drawing.Color.White;
		this.toolTip_0.ForeColor = global::System.Drawing.Color.Navy;
		this.toolTip_0.InitialDelay = 500;
		this.toolTip_0.IsBalloon = true;
		this.toolTip_0.ReshowDelay = 100;
		this.panelLoading.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.panelLoading.Controls.Add(this.lblLoading);
		this.panelLoading.Location = new global::System.Drawing.Point(0, 0);
		this.panelLoading.Name = "panelLoading";
		this.panelLoading.Size = new global::System.Drawing.Size(39, 33);
		this.panelLoading.TabIndex = 4;
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
		this.BackColor = global::System.Drawing.Color.White;
		base.ClientSize = new global::System.Drawing.Size(881, 504);
		base.Controls.Add(this.panelLoading);
		base.Controls.Add(this.statusStrip1);
		base.Controls.Add(this.tabControlMain);
		base.Controls.Add(this.menuStrip1);
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		base.MainMenuStrip = this.menuStrip1;
		this.MinimumSize = new global::System.Drawing.Size(800, 500);
		base.Name = "FormMain";
		this.Text = "FiatECUScan";
		base.WindowState = global::System.Windows.Forms.FormWindowState.Maximized;
		base.Shown += new global::System.EventHandler(this.FormMain_Shown);
		base.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
		base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
		this.tabControlMain.ResumeLayout(false);
		this.tabPageSelect.ResumeLayout(false);
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel1.PerformLayout();
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.Panel2.PerformLayout();
		this.splitContainer1.ResumeLayout(false);
		((global::System.ComponentModel.ISupportInitialize)this.dgvSelectModel).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.dgvSelectMake).EndInit();
		this.flowLayoutPanel1.ResumeLayout(false);
		this.flowLayoutPanel1.PerformLayout();
		((global::System.ComponentModel.ISupportInitialize)this.dgvSelectECU).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.dgvSelectSystem).EndInit();
		this.tabPageInfo.ResumeLayout(false);
		this.tabPageInfo.PerformLayout();
		this.panel3.ResumeLayout(false);
		this.panel3.PerformLayout();
		((global::System.ComponentModel.ISupportInitialize)this.dgvInfo).EndInit();
		this.tabPageErrors.ResumeLayout(false);
		this.tabPageErrors.PerformLayout();
		this.splitContainer2.Panel1.ResumeLayout(false);
		this.splitContainer2.Panel2.ResumeLayout(false);
		this.splitContainer2.Panel2.PerformLayout();
		this.splitContainer2.ResumeLayout(false);
		((global::System.ComponentModel.ISupportInitialize)this.dgvErrors).EndInit();
		this.tabPageParams.ResumeLayout(false);
		this.tabPageParams.PerformLayout();
		this.splitContainer3.Panel1.ResumeLayout(false);
		this.splitContainer3.Panel2.ResumeLayout(false);
		this.splitContainer3.Panel2.PerformLayout();
		this.splitContainer3.ResumeLayout(false);
		((global::System.ComponentModel.ISupportInitialize)this.dgvParams).EndInit();
		this.tabPageGraph.ResumeLayout(false);
		((global::System.ComponentModel.ISupportInitialize)this.dgvTags).EndInit();
		this.flowLayoutPanel2.ResumeLayout(false);
		this.flowLayoutPanel2.PerformLayout();
		this.panel9.ResumeLayout(false);
		this.panel9.PerformLayout();
		this.panel8.ResumeLayout(false);
		this.panel8.PerformLayout();
		this.tableLayoutPanelGraphs.ResumeLayout(false);
		this.tabPageActuators.ResumeLayout(false);
		this.tabPageActuators.PerformLayout();
		this.splitContainer4.Panel1.ResumeLayout(false);
		this.splitContainer4.Panel2.ResumeLayout(false);
		this.splitContainer4.Panel2.PerformLayout();
		this.splitContainer4.ResumeLayout(false);
		((global::System.ComponentModel.ISupportInitialize)this.dgvActuators).EndInit();
		((global::System.ComponentModel.ISupportInitialize)this.dgvActParams).EndInit();
		this.tabPageAdjustments.ResumeLayout(false);
		this.tabPageAdjustments.PerformLayout();
		this.splitContainer5.Panel1.ResumeLayout(false);
		this.splitContainer5.Panel2.ResumeLayout(false);
		this.splitContainer5.Panel2.PerformLayout();
		this.splitContainer5.ResumeLayout(false);
		((global::System.ComponentModel.ISupportInitialize)this.dgvAdjustments).EndInit();
		this.tabPageLog.ResumeLayout(false);
		this.tabPageLog.PerformLayout();
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		this.panelLoading.ResumeLayout(false);
		this.panelLoading.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000555 RID: 1365
	private global::System.ComponentModel.IContainer icontainer_0 = null;

	// Token: 0x04000556 RID: 1366
	private global::System.Windows.Forms.TabControl tabControlMain;

	// Token: 0x04000557 RID: 1367
	private global::System.Windows.Forms.TabPage tabPageInfo;

	// Token: 0x04000558 RID: 1368
	private global::System.Windows.Forms.MenuStrip menuStrip1;

	// Token: 0x04000559 RID: 1369
	private global::System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;

	// Token: 0x0400055A RID: 1370
	private global::System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

	// Token: 0x0400055B RID: 1371
	private global::System.Windows.Forms.StatusStrip statusStrip1;

	// Token: 0x0400055C RID: 1372
	private global::System.Windows.Forms.DataGridView dgvInfo;

	// Token: 0x0400055D RID: 1373
	private global::System.Windows.Forms.ToolStripStatusLabel ttslMsg;

	// Token: 0x0400055E RID: 1374
	private global::System.Windows.Forms.ToolStripStatusLabel tsslAction;

	// Token: 0x0400055F RID: 1375
	private global::System.Windows.Forms.TabPage tabPageLog;

	// Token: 0x04000560 RID: 1376
	private global::System.Windows.Forms.TabPage tabPageErrors;

	// Token: 0x04000561 RID: 1377
	private global::System.Windows.Forms.TabPage tabPageParams;

	// Token: 0x04000562 RID: 1378
	private global::System.Windows.Forms.TabPage tabPageGraph;

	// Token: 0x04000563 RID: 1379
	private global::System.Windows.Forms.DataGridView dgvParams;

	// Token: 0x04000564 RID: 1380
	private global::System.Windows.Forms.Timer timer_0;

	// Token: 0x04000565 RID: 1381
	private global::System.Windows.Forms.TextBox textBoxLog;

	// Token: 0x04000566 RID: 1382
	private global::System.Windows.Forms.Label label3;

	// Token: 0x04000567 RID: 1383
	private global::System.Windows.Forms.ComboBox cbGraphScale;

	// Token: 0x04000568 RID: 1384
	private global::System.Windows.Forms.Button buttonGraphStart;

	// Token: 0x04000569 RID: 1385
	private global::System.Windows.Forms.Button btnExportGraph;

	// Token: 0x0400056A RID: 1386
	private global::System.Windows.Forms.Label lblGraphStatus;

	// Token: 0x0400056B RID: 1387
	private global::System.Windows.Forms.TextBox tbParamDescription;

	// Token: 0x0400056C RID: 1388
	private global::System.Windows.Forms.TabPage tabPageActuators;

	// Token: 0x0400056D RID: 1389
	private global::System.Windows.Forms.TabPage tabPageAdjustments;

	// Token: 0x0400056E RID: 1390
	private global::System.Windows.Forms.TextBox tbActuatorsDesc;

	// Token: 0x0400056F RID: 1391
	private global::System.Windows.Forms.DataGridView dgvActuators;

	// Token: 0x04000570 RID: 1392
	private global::System.Windows.Forms.Label label4;

	// Token: 0x04000571 RID: 1393
	private global::System.Windows.Forms.ComboBox cbGraphRate;

	// Token: 0x04000572 RID: 1394
	private global::System.Windows.Forms.Button btnActuatorsExecute;

	// Token: 0x04000573 RID: 1395
	private global::System.Windows.Forms.Label lblGraphTime;

	// Token: 0x04000574 RID: 1396
	private global::System.Windows.Forms.Button btnErrorsClear;

	// Token: 0x04000575 RID: 1397
	private global::System.Windows.Forms.TextBox tbErrorsDetails;

	// Token: 0x04000576 RID: 1398
	private global::System.Windows.Forms.DataGridView dgvErrors;

	// Token: 0x04000577 RID: 1399
	private global::System.Windows.Forms.Timer timer_1;

	// Token: 0x04000578 RID: 1400
	private global::System.Windows.Forms.SaveFileDialog saveFileDialog_0;

	// Token: 0x04000579 RID: 1401
	private global::System.Windows.Forms.TabPage tabPageSelect;

	// Token: 0x0400057A RID: 1402
	private global::System.Windows.Forms.Button buttonSettings;

	// Token: 0x0400057B RID: 1403
	private global::System.Windows.Forms.Button buttonConnect;

	// Token: 0x0400057C RID: 1404
	private global::System.Windows.Forms.DataGridView dgvSelectECU;

	// Token: 0x0400057D RID: 1405
	private global::System.Windows.Forms.Button buttonDisconnect;

	// Token: 0x0400057E RID: 1406
	private global::System.Windows.Forms.Label lblSelectedInfo2;

	// Token: 0x0400057F RID: 1407
	private global::System.Windows.Forms.Label lblSelectedInfo;

	// Token: 0x04000580 RID: 1408
	private global::System.Windows.Forms.Panel panel3;

	// Token: 0x04000581 RID: 1409
	private global::System.Windows.Forms.Button btnParamsArrange;

	// Token: 0x04000582 RID: 1410
	private global::System.Windows.Forms.Label label1;

	// Token: 0x04000583 RID: 1411
	private global::System.Windows.Forms.DataGridView dgvSelectModel;

	// Token: 0x04000584 RID: 1412
	private global::System.Windows.Forms.DataGridView dgvSelectMake;

	// Token: 0x04000585 RID: 1413
	private global::System.Windows.Forms.Label label6;

	// Token: 0x04000586 RID: 1414
	private global::System.Windows.Forms.Label label2;

	// Token: 0x04000587 RID: 1415
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colMake01;

	// Token: 0x04000588 RID: 1416
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colMake02;

	// Token: 0x04000589 RID: 1417
	private global::System.Windows.Forms.Label lblISOError;

	// Token: 0x0400058A RID: 1418
	private global::System.Windows.Forms.Button btnArrangeName;

	// Token: 0x0400058B RID: 1419
	private global::System.Windows.Forms.Button btnArrangeUnits;

	// Token: 0x0400058C RID: 1420
	private global::System.Windows.Forms.ToolStripStatusLabel tsslConnProblem;

	// Token: 0x0400058D RID: 1421
	private global::System.Windows.Forms.Label lblNewVersionMessage;

	// Token: 0x0400058E RID: 1422
	private global::System.Windows.Forms.ImageList imageList_0;

	// Token: 0x0400058F RID: 1423
	private global::System.Windows.Forms.DataGridView dgvSelectSystem;

	// Token: 0x04000590 RID: 1424
	private global::System.Windows.Forms.Label label7;

	// Token: 0x04000591 RID: 1425
	private global::System.Windows.Forms.SplitContainer splitContainer1;

	// Token: 0x04000592 RID: 1426
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colModel01;

	// Token: 0x04000593 RID: 1427
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colModel02;

	// Token: 0x04000594 RID: 1428
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colModel03;

	// Token: 0x04000595 RID: 1429
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colModel04;

	// Token: 0x04000596 RID: 1430
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colCategory01;

	// Token: 0x04000597 RID: 1431
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colCategory02;

	// Token: 0x04000598 RID: 1432
	private global::System.Windows.Forms.Button buttonConnectAuto;

	// Token: 0x04000599 RID: 1433
	private global::System.Windows.Forms.Panel panel1;

	// Token: 0x0400059A RID: 1434
	private global::System.Windows.Forms.Panel panel4;

	// Token: 0x0400059B RID: 1435
	private global::System.Windows.Forms.Label lblLink;

	// Token: 0x0400059C RID: 1436
	private global::System.Windows.Forms.Panel panel5;

	// Token: 0x0400059D RID: 1437
	private global::System.Windows.Forms.Panel panel6;

	// Token: 0x0400059E RID: 1438
	private global::System.Windows.Forms.Panel panel7;

	// Token: 0x0400059F RID: 1439
	private global::System.Windows.Forms.SplitContainer splitContainer2;

	// Token: 0x040005A0 RID: 1440
	private global::System.Windows.Forms.SplitContainer splitContainer3;

	// Token: 0x040005A1 RID: 1441
	private global::System.Windows.Forms.DataGridViewTextBoxColumn Column1;

	// Token: 0x040005A2 RID: 1442
	private global::System.Windows.Forms.DataGridViewTextBoxColumn Column2;

	// Token: 0x040005A3 RID: 1443
	private global::System.Windows.Forms.DataGridViewTextBoxColumn Column3;

	// Token: 0x040005A4 RID: 1444
	private global::System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;

	// Token: 0x040005A5 RID: 1445
	private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

	// Token: 0x040005A6 RID: 1446
	private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;

	// Token: 0x040005A7 RID: 1447
	private global::GClass65 graphPanel1;

	// Token: 0x040005A8 RID: 1448
	private global::GClass68 tableLayoutPanelGraphs;

	// Token: 0x040005A9 RID: 1449
	private global::System.Windows.Forms.Label label8;

	// Token: 0x040005AA RID: 1450
	private global::System.Windows.Forms.ComboBox cbGraphCount;

	// Token: 0x040005AB RID: 1451
	private global::GClass68 tableLayoutPanelGraphParams;

	// Token: 0x040005AC RID: 1452
	private global::System.Windows.Forms.Panel panel2;

	// Token: 0x040005AD RID: 1453
	private global::System.Windows.Forms.ComboBox cbGraphFiles;

	// Token: 0x040005AE RID: 1454
	private global::System.Windows.Forms.Label label5;

	// Token: 0x040005AF RID: 1455
	private global::System.Windows.Forms.Button btnImportGraph;

	// Token: 0x040005B0 RID: 1456
	private global::System.Windows.Forms.Panel panel9;

	// Token: 0x040005B1 RID: 1457
	private global::System.Windows.Forms.Panel panel8;

	// Token: 0x040005B2 RID: 1458
	private global::System.Windows.Forms.TextBox tbRecordingName;

	// Token: 0x040005B3 RID: 1459
	private global::System.Windows.Forms.SplitContainer splitContainer4;

	// Token: 0x040005B4 RID: 1460
	private global::System.Windows.Forms.Panel panel10;

	// Token: 0x040005B5 RID: 1461
	private global::System.Windows.Forms.Panel panel11;

	// Token: 0x040005B6 RID: 1462
	private global::System.Windows.Forms.SplitContainer splitContainer5;

	// Token: 0x040005B7 RID: 1463
	private global::System.Windows.Forms.DataGridView dgvAdjustments;

	// Token: 0x040005B8 RID: 1464
	private global::System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;

	// Token: 0x040005B9 RID: 1465
	private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

	// Token: 0x040005BA RID: 1466
	private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

	// Token: 0x040005BB RID: 1467
	private global::System.Windows.Forms.TextBox tbAdjDesc;

	// Token: 0x040005BC RID: 1468
	private global::System.Windows.Forms.Button btnAdjustmentsExecute;

	// Token: 0x040005BD RID: 1469
	private global::System.Windows.Forms.CheckBox chkParamsAutoUp;

	// Token: 0x040005BE RID: 1470
	private global::System.Windows.Forms.DataGridView dgvActParams;

	// Token: 0x040005BF RID: 1471
	private global::System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;

	// Token: 0x040005C0 RID: 1472
	private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

	// Token: 0x040005C1 RID: 1473
	private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

	// Token: 0x040005C2 RID: 1474
	private global::System.Windows.Forms.DataGridViewCheckBoxColumn paramsColSelect;

	// Token: 0x040005C3 RID: 1475
	private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

	// Token: 0x040005C4 RID: 1476
	private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

	// Token: 0x040005C5 RID: 1477
	private global::System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;

	// Token: 0x040005C6 RID: 1478
	private global::System.Windows.Forms.Timer timer_2;

	// Token: 0x040005C7 RID: 1479
	private global::System.Windows.Forms.Label lblLoading;

	// Token: 0x040005C8 RID: 1480
	private global::System.Windows.Forms.DataGridViewTextBoxColumn errorNameCol;

	// Token: 0x040005C9 RID: 1481
	private global::System.Windows.Forms.DataGridViewTextBoxColumn Column15;

	// Token: 0x040005CA RID: 1482
	private global::System.Windows.Forms.DataGridViewTextBoxColumn Column16;

	// Token: 0x040005CB RID: 1483
	private global::System.Windows.Forms.DataGridViewTextBoxColumn Column17;

	// Token: 0x040005CC RID: 1484
	private global::System.Windows.Forms.Button button2;

	// Token: 0x040005CD RID: 1485
	private global::System.Windows.Forms.Button button3;

	// Token: 0x040005CE RID: 1486
	private global::System.Windows.Forms.Button button4;

	// Token: 0x040005CF RID: 1487
	private global::System.Windows.Forms.Button btnTemplateLoad;

	// Token: 0x040005D0 RID: 1488
	private global::System.Windows.Forms.Button button5;

	// Token: 0x040005D1 RID: 1489
	private global::System.Windows.Forms.Label label9;

	// Token: 0x040005D2 RID: 1490
	private global::System.Windows.Forms.DataGridView dgvTags;

	// Token: 0x040005D3 RID: 1491
	private global::System.Windows.Forms.DataGridViewTextBoxColumn Column4;

	// Token: 0x040005D4 RID: 1492
	private global::System.Windows.Forms.DataGridViewTextBoxColumn Column5;

	// Token: 0x040005D5 RID: 1493
	private global::System.Windows.Forms.OpenFileDialog openFileDialog_0;

	// Token: 0x040005D6 RID: 1494
	private global::System.Windows.Forms.Button buttonRegister;

	// Token: 0x040005D7 RID: 1495
	private global::System.Windows.Forms.Button buttonUploadReport;

	// Token: 0x040005D8 RID: 1496
	private global::System.Windows.Forms.Label label10;

	// Token: 0x040005D9 RID: 1497
	private global::System.Windows.Forms.CheckBox chkMonitorErrors;

	// Token: 0x040005DA RID: 1498
	private global::System.Windows.Forms.Label lblDTCsPresent;

	// Token: 0x040005DB RID: 1499
	private global::System.Windows.Forms.ToolTip toolTip_0;

	// Token: 0x040005DC RID: 1500
	private global::System.Windows.Forms.Panel panelLoading;

	// Token: 0x040005DD RID: 1501
	private global::System.Windows.Forms.Button buttonSelectNone;

	// Token: 0x040005DE RID: 1502
	private global::System.Windows.Forms.Button buttonSelectAll;

	// Token: 0x040005DF RID: 1503
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colSystem01;

	// Token: 0x040005E0 RID: 1504
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colSystem02;

	// Token: 0x040005E1 RID: 1505
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colSystem03;

	// Token: 0x040005E2 RID: 1506
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colSystem04;

	// Token: 0x040005E3 RID: 1507
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colSystem05;

	// Token: 0x040005E4 RID: 1508
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colSystem06;

	// Token: 0x040005E5 RID: 1509
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colSystem07;

	// Token: 0x040005E6 RID: 1510
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colSystem08;

	// Token: 0x040005E7 RID: 1511
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colSystem09;

	// Token: 0x040005E8 RID: 1512
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colSystem10;

	// Token: 0x040005E9 RID: 1513
	private global::System.Windows.Forms.DataGridViewTextBoxColumn colSystem11;

	// Token: 0x040005EA RID: 1514
	private global::System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

	// Token: 0x040005EB RID: 1515
	private global::System.Windows.Forms.Button buttonScanDTC;

	// Token: 0x040005EC RID: 1516
	private global::System.Windows.Forms.TextBox tbErrorsDesc;
}
