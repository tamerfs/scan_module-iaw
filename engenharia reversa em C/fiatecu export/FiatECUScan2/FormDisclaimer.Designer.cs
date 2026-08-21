// Token: 0x0200005D RID: 93
public sealed partial class FormDisclaimer : global::System.Windows.Forms.Form
{
	// Token: 0x06000288 RID: 648 RVA: 0x00002FA5 File Offset: 0x000011A5
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000289 RID: 649 RVA: 0x00063240 File Offset: 0x00061440
	private void InitializeComponent()
	{
		this.chkShow = new global::System.Windows.Forms.CheckBox();
		this.btnClose = new global::System.Windows.Forms.Button();
		this.panel1 = new global::System.Windows.Forms.Panel();
		this.rtbDisclaimer = new global::System.Windows.Forms.RichTextBox();
		this.textBox1 = new global::System.Windows.Forms.TextBox();
		this.label1 = new global::System.Windows.Forms.Label();
		this.label2 = new global::System.Windows.Forms.Label();
		this.lblLink = new global::System.Windows.Forms.Label();
		this.label3 = new global::System.Windows.Forms.Label();
		this.panel1.SuspendLayout();
		base.SuspendLayout();
		this.chkShow.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.chkShow.AutoSize = true;
		this.chkShow.Checked = true;
		this.chkShow.CheckState = global::System.Windows.Forms.CheckState.Checked;
		this.chkShow.Location = new global::System.Drawing.Point(12, 450);
		this.chkShow.Name = "chkShow";
		this.chkShow.Size = new global::System.Drawing.Size(244, 20);
		this.chkShow.TabIndex = 0;
		this.chkShow.Text = "Show this message on every startup";
		this.chkShow.UseVisualStyleBackColor = true;
		this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.btnClose.DialogResult = global::System.Windows.Forms.DialogResult.OK;
		this.btnClose.Location = new global::System.Drawing.Point(465, 445);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new global::System.Drawing.Size(97, 27);
		this.btnClose.TabIndex = 1;
		this.btnClose.Text = "Close";
		this.btnClose.UseVisualStyleBackColor = true;
		this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
		this.panel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel1.Controls.Add(this.rtbDisclaimer);
		this.panel1.Location = new global::System.Drawing.Point(12, 76);
		this.panel1.Name = "panel1";
		this.panel1.Size = new global::System.Drawing.Size(550, 256);
		this.panel1.TabIndex = 2;
		this.rtbDisclaimer.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.rtbDisclaimer.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
		this.rtbDisclaimer.Location = new global::System.Drawing.Point(3, 3);
		this.rtbDisclaimer.Name = "rtbDisclaimer";
		this.rtbDisclaimer.ReadOnly = true;
		this.rtbDisclaimer.Size = new global::System.Drawing.Size(542, 248);
		this.rtbDisclaimer.TabIndex = 1;
		this.rtbDisclaimer.Text = string.Empty;
		this.rtbDisclaimer.LinkClicked += new global::System.Windows.Forms.LinkClickedEventHandler(this.rtbDisclaimer_LinkClicked);
		this.textBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.textBox1.BackColor = global::System.Drawing.Color.Red;
		this.textBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox1.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.textBox1.ForeColor = global::System.Drawing.Color.White;
		this.textBox1.Location = new global::System.Drawing.Point(12, 12);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.ReadOnly = true;
		this.textBox1.Size = new global::System.Drawing.Size(550, 58);
		this.textBox1.TabIndex = 3;
		this.textBox1.Text = "This is a FREE version. No one has the rights to sell it either as a bundle with cable or separate product!!!";
		this.textBox1.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
		this.label1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.label1.AutoSize = true;
		this.label1.Font = new global::System.Drawing.Font("Arial", 9.216f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label1.ForeColor = global::System.Drawing.Color.Red;
		this.label1.Location = new global::System.Drawing.Point(9, 343);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(504, 19);
		this.label1.TabIndex = 4;
		this.label1.Text = "You can purchase a License for the FULL version at our web site:";
		this.label2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.label2.AutoSize = true;
		this.label2.Font = new global::System.Drawing.Font("Arial", 9.216f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label2.ForeColor = global::System.Drawing.Color.Red;
		this.label2.Location = new global::System.Drawing.Point(9, 395);
		this.label2.Name = "label2";
		this.label2.Size = new global::System.Drawing.Size(401, 19);
		this.label2.TabIndex = 5;
		this.label2.Text = "Or, you can purchase it from one of the distributors:";
		this.lblLink.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.lblLink.AutoSize = true;
		this.lblLink.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.lblLink.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblLink.ForeColor = global::System.Drawing.Color.Navy;
		this.lblLink.Location = new global::System.Drawing.Point(34, 365);
		this.lblLink.Name = "lblLink";
		this.lblLink.Size = new global::System.Drawing.Size(319, 19);
		this.lblLink.TabIndex = 29;
		this.lblLink.Text = "http://www.fiatecuscan.net/Register.aspx";
		this.lblLink.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.lblLink_MouseClick);
		this.label3.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.label3.AutoSize = true;
		this.label3.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.label3.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label3.ForeColor = global::System.Drawing.Color.Navy;
		this.label3.Location = new global::System.Drawing.Point(34, 418);
		this.label3.Name = "label3";
		this.label3.Size = new global::System.Drawing.Size(346, 19);
		this.label3.TabIndex = 30;
		this.label3.Text = "http://www.fiatecuscan.net/Distributors.aspx";
		this.label3.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.label3_MouseClick);
		base.AcceptButton = this.btnClose;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(574, 484);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.lblLink);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.btnClose);
		base.Controls.Add(this.chkShow);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormDisclaimer";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Disclaimer";
		this.panel1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x040003E5 RID: 997
	private global::System.ComponentModel.IContainer icontainer_0 = null;

	// Token: 0x040003E6 RID: 998
	private global::System.Windows.Forms.CheckBox chkShow;

	// Token: 0x040003E7 RID: 999
	private global::System.Windows.Forms.Button btnClose;

	// Token: 0x040003E8 RID: 1000
	private global::System.Windows.Forms.Panel panel1;

	// Token: 0x040003E9 RID: 1001
	private global::System.Windows.Forms.RichTextBox rtbDisclaimer;

	// Token: 0x040003EA RID: 1002
	private global::System.Windows.Forms.TextBox textBox1;

	// Token: 0x040003EB RID: 1003
	private global::System.Windows.Forms.Label label1;

	// Token: 0x040003EC RID: 1004
	private global::System.Windows.Forms.Label label2;

	// Token: 0x040003ED RID: 1005
	private global::System.Windows.Forms.Label lblLink;

	// Token: 0x040003EE RID: 1006
	private global::System.Windows.Forms.Label label3;
}
