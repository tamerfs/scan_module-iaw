// Token: 0x02000010 RID: 16
public sealed partial class FormNotify : global::System.Windows.Forms.Form
{
	// Token: 0x0600006B RID: 107 RVA: 0x00002824 File Offset: 0x00000A24
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x0600006C RID: 108 RVA: 0x0001D30C File Offset: 0x0001B50C
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		this.panel1 = new global::System.Windows.Forms.Panel();
		this.lblMessage3 = new global::System.Windows.Forms.Label();
		this.lblMessage2 = new global::System.Windows.Forms.Label();
		this.lblMessage1 = new global::System.Windows.Forms.Label();
		this.tableLayoutPanelButtons = new global::System.Windows.Forms.TableLayoutPanel();
		this.btnCenter = new global::System.Windows.Forms.Button();
		this.btnLeft = new global::System.Windows.Forms.Button();
		this.btnRight = new global::System.Windows.Forms.Button();
		this.timer_0 = new global::System.Windows.Forms.Timer(this.icontainer_0);
		this.panel2 = new global::System.Windows.Forms.Panel();
		this.panel1.SuspendLayout();
		this.tableLayoutPanelButtons.SuspendLayout();
		this.panel2.SuspendLayout();
		base.SuspendLayout();
		this.panel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.panel1.BackColor = global::System.Drawing.Color.Black;
		this.panel1.Controls.Add(this.lblMessage3);
		this.panel1.Controls.Add(this.lblMessage2);
		this.panel1.Controls.Add(this.lblMessage1);
		this.panel1.ForeColor = global::System.Drawing.Color.Red;
		this.panel1.Location = new global::System.Drawing.Point(12, 12);
		this.panel1.Name = "panel1";
		this.panel1.Size = new global::System.Drawing.Size(821, 160);
		this.panel1.TabIndex = 0;
		this.lblMessage3.AutoSize = true;
		this.lblMessage3.Font = new global::System.Drawing.Font("Arial", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblMessage3.ForeColor = global::System.Drawing.Color.White;
		this.lblMessage3.Location = new global::System.Drawing.Point(76, 113);
		this.lblMessage3.Name = "lblMessage3";
		this.lblMessage3.Size = new global::System.Drawing.Size(229, 34);
		this.lblMessage3.TabIndex = 2;
		this.lblMessage3.Text = "Test message 3";
		this.lblMessage2.AutoSize = true;
		this.lblMessage2.Font = new global::System.Drawing.Font("Arial", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblMessage2.ForeColor = global::System.Drawing.Color.White;
		this.lblMessage2.Location = new global::System.Drawing.Point(76, 76);
		this.lblMessage2.Name = "lblMessage2";
		this.lblMessage2.Size = new global::System.Drawing.Size(229, 34);
		this.lblMessage2.TabIndex = 1;
		this.lblMessage2.Text = "Test message 2";
		this.lblMessage1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.lblMessage1.AutoSize = true;
		this.lblMessage1.BackColor = global::System.Drawing.Color.Transparent;
		this.lblMessage1.Font = new global::System.Drawing.Font("Arial", 28.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblMessage1.Location = new global::System.Drawing.Point(35, 16);
		this.lblMessage1.Name = "lblMessage1";
		this.lblMessage1.Size = new global::System.Drawing.Size(383, 56);
		this.lblMessage1.TabIndex = 0;
		this.lblMessage1.Text = "Test message 1";
		this.lblMessage1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.tableLayoutPanelButtons.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.tableLayoutPanelButtons.ColumnCount = 3;
		this.tableLayoutPanelButtons.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.tableLayoutPanelButtons.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.tableLayoutPanelButtons.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.tableLayoutPanelButtons.Controls.Add(this.btnCenter, 1, 0);
		this.tableLayoutPanelButtons.Controls.Add(this.btnLeft, 0, 0);
		this.tableLayoutPanelButtons.Controls.Add(this.btnRight, 2, 0);
		this.tableLayoutPanelButtons.Location = new global::System.Drawing.Point(0, 8);
		this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
		this.tableLayoutPanelButtons.RowCount = 1;
		this.tableLayoutPanelButtons.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanelButtons.Size = new global::System.Drawing.Size(845, 48);
		this.tableLayoutPanelButtons.TabIndex = 7;
		this.btnCenter.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.btnCenter.AutoSize = true;
		this.btnCenter.BackColor = global::System.Drawing.Color.Silver;
		this.btnCenter.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.btnCenter.ForeColor = global::System.Drawing.Color.Black;
		this.btnCenter.ImageKey = "(none)";
		this.btnCenter.Location = new global::System.Drawing.Point(284, 3);
		this.btnCenter.Name = "btnCenter";
		this.btnCenter.Size = new global::System.Drawing.Size(275, 42);
		this.btnCenter.TabIndex = 7;
		this.btnCenter.Tag = string.Empty;
		this.btnCenter.Text = "ESC";
		this.btnCenter.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.btnCenter.UseVisualStyleBackColor = false;
		this.btnCenter.Click += new global::System.EventHandler(this.btnCenter_Click);
		this.btnLeft.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.btnLeft.AutoSize = true;
		this.btnLeft.BackColor = global::System.Drawing.Color.Silver;
		this.btnLeft.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.btnLeft.ForeColor = global::System.Drawing.Color.Red;
		this.btnLeft.ImageKey = "(none)";
		this.btnLeft.Location = new global::System.Drawing.Point(3, 3);
		this.btnLeft.Name = "btnLeft";
		this.btnLeft.Size = new global::System.Drawing.Size(275, 42);
		this.btnLeft.TabIndex = 6;
		this.btnLeft.Tag = string.Empty;
		this.btnLeft.Text = "N";
		this.btnLeft.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.btnLeft.UseVisualStyleBackColor = false;
		this.btnLeft.Click += new global::System.EventHandler(this.btnLeft_Click);
		this.btnRight.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.btnRight.AutoSize = true;
		this.btnRight.BackColor = global::System.Drawing.Color.Silver;
		this.btnRight.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.btnRight.ForeColor = global::System.Drawing.Color.Green;
		this.btnRight.ImageKey = "(none)";
		this.btnRight.Location = new global::System.Drawing.Point(565, 3);
		this.btnRight.Name = "btnRight";
		this.btnRight.Size = new global::System.Drawing.Size(277, 42);
		this.btnRight.TabIndex = 5;
		this.btnRight.Tag = string.Empty;
		this.btnRight.Text = "Y";
		this.btnRight.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.btnRight.UseVisualStyleBackColor = false;
		this.btnRight.Click += new global::System.EventHandler(this.btnRight_Click);
		this.timer_0.Enabled = true;
		this.timer_0.Interval = 400;
		this.timer_0.Tick += new global::System.EventHandler(this.timer_0_Tick);
		this.panel2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.panel2.BackColor = global::System.Drawing.Color.White;
		this.panel2.Controls.Add(this.tableLayoutPanelButtons);
		this.panel2.Location = new global::System.Drawing.Point(0, 185);
		this.panel2.Name = "panel2";
		this.panel2.Size = new global::System.Drawing.Size(845, 62);
		this.panel2.TabIndex = 1;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.AutoSize = true;
		this.BackColor = global::System.Drawing.Color.Red;
		base.ClientSize = new global::System.Drawing.Size(845, 246);
		base.ControlBox = false;
		base.Controls.Add(this.panel2);
		base.Controls.Add(this.panel1);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormNotify";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
		base.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.FormNotify_KeyUp);
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.tableLayoutPanelButtons.ResumeLayout(false);
		this.tableLayoutPanelButtons.PerformLayout();
		this.panel2.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	// Token: 0x0400007A RID: 122
	private global::System.ComponentModel.IContainer icontainer_0 = null;

	// Token: 0x0400007B RID: 123
	private global::System.Windows.Forms.Panel panel1;

	// Token: 0x0400007C RID: 124
	private global::System.Windows.Forms.Label lblMessage2;

	// Token: 0x0400007D RID: 125
	private global::System.Windows.Forms.Label lblMessage1;

	// Token: 0x0400007E RID: 126
	private global::System.Windows.Forms.Label lblMessage3;

	// Token: 0x0400007F RID: 127
	private global::System.Windows.Forms.Timer timer_0;

	// Token: 0x04000080 RID: 128
	private global::System.Windows.Forms.Button btnRight;

	// Token: 0x04000081 RID: 129
	private global::System.Windows.Forms.Button btnLeft;

	// Token: 0x04000082 RID: 130
	private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;

	// Token: 0x04000083 RID: 131
	private global::System.Windows.Forms.Button btnCenter;

	// Token: 0x04000084 RID: 132
	private global::System.Windows.Forms.Panel panel2;
}
