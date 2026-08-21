// Token: 0x02000061 RID: 97
public sealed partial class FormRegistration : global::System.Windows.Forms.Form
{
	// Token: 0x060002BD RID: 701 RVA: 0x00003093 File Offset: 0x00001293
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x060002BE RID: 702 RVA: 0x0006B098 File Offset: 0x00069298
	private void InitializeComponent()
	{
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::FormRegistration));
		this.panel1 = new global::System.Windows.Forms.Panel();
		this.lblLink = new global::System.Windows.Forms.Label();
		this.label3 = new global::System.Windows.Forms.Label();
		this.tbRemoval = new global::System.Windows.Forms.TextBox();
		this.buttonDeactivate = new global::System.Windows.Forms.Button();
		this.buttonExit = new global::System.Windows.Forms.Button();
		this.textBox4 = new global::System.Windows.Forms.TextBox();
		this.panel2 = new global::System.Windows.Forms.Panel();
		this.textBox3 = new global::System.Windows.Forms.TextBox();
		this.buttonActivate = new global::System.Windows.Forms.Button();
		this.label2 = new global::System.Windows.Forms.Label();
		this.label1 = new global::System.Windows.Forms.Label();
		this.tbSerial = new global::System.Windows.Forms.TextBox();
		this.tbKey = new global::System.Windows.Forms.TextBox();
		this.panel1.SuspendLayout();
		base.SuspendLayout();
		this.panel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel1.Controls.Add(this.lblLink);
		this.panel1.Controls.Add(this.label3);
		this.panel1.Controls.Add(this.tbRemoval);
		this.panel1.Controls.Add(this.buttonDeactivate);
		this.panel1.Controls.Add(this.buttonExit);
		this.panel1.Controls.Add(this.textBox4);
		this.panel1.Controls.Add(this.panel2);
		this.panel1.Controls.Add(this.textBox3);
		this.panel1.Controls.Add(this.buttonActivate);
		this.panel1.Controls.Add(this.label2);
		this.panel1.Controls.Add(this.label1);
		this.panel1.Controls.Add(this.tbSerial);
		this.panel1.Controls.Add(this.tbKey);
		this.panel1.Location = new global::System.Drawing.Point(12, 12);
		this.panel1.Name = "panel1";
		this.panel1.Size = new global::System.Drawing.Size(424, 379);
		this.panel1.TabIndex = 0;
		this.lblLink.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.lblLink.AutoSize = true;
		this.lblLink.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.lblLink.Font = new global::System.Drawing.Font("Arial", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblLink.ForeColor = global::System.Drawing.Color.Navy;
		this.lblLink.Location = new global::System.Drawing.Point(33, 244);
		this.lblLink.Name = "lblLink";
		this.lblLink.Size = new global::System.Drawing.Size(379, 19);
		this.lblLink.TabIndex = 28;
		this.lblLink.Text = "http://www.fiatecuscan.net/TransferLicense.aspx";
		this.lblLink.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.lblLink_MouseClick);
		this.label3.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.label3.AutoSize = true;
		this.label3.Location = new global::System.Drawing.Point(13, 303);
		this.label3.Name = "label3";
		this.label3.Size = new global::System.Drawing.Size(89, 16);
		this.label3.TabIndex = 27;
		this.label3.Text = "Removal Key";
		this.tbRemoval.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.tbRemoval.Location = new global::System.Drawing.Point(116, 300);
		this.tbRemoval.Name = "tbRemoval";
		this.tbRemoval.Size = new global::System.Drawing.Size(293, 22);
		this.tbRemoval.TabIndex = 26;
		this.buttonDeactivate.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.buttonDeactivate.Location = new global::System.Drawing.Point(16, 339);
		this.buttonDeactivate.Name = "buttonDeactivate";
		this.buttonDeactivate.Size = new global::System.Drawing.Size(105, 27);
		this.buttonDeactivate.TabIndex = 25;
		this.buttonDeactivate.Text = "Deactivate";
		this.buttonDeactivate.UseVisualStyleBackColor = true;
		this.buttonDeactivate.Click += new global::System.EventHandler(this.buttonDeactivate_Click);
		this.buttonExit.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.buttonExit.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.buttonExit.Location = new global::System.Drawing.Point(322, 339);
		this.buttonExit.Name = "buttonExit";
		this.buttonExit.Size = new global::System.Drawing.Size(87, 27);
		this.buttonExit.TabIndex = 24;
		this.buttonExit.Text = "Exit";
		this.buttonExit.UseVisualStyleBackColor = true;
		this.buttonExit.Click += new global::System.EventHandler(this.buttonExit_Click);
		this.textBox4.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.textBox4.BackColor = global::System.Drawing.Color.White;
		this.textBox4.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
		this.textBox4.Enabled = false;
		this.textBox4.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.textBox4.ForeColor = global::System.Drawing.Color.Red;
		this.textBox4.Location = new global::System.Drawing.Point(3, 102);
		this.textBox4.Multiline = true;
		this.textBox4.Name = "textBox4";
		this.textBox4.ReadOnly = true;
		this.textBox4.Size = new global::System.Drawing.Size(416, 30);
		this.textBox4.TabIndex = 23;
		this.textBox4.Text = "UNREGISTERED";
		this.textBox4.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
		this.panel2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.panel2.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("panel2.BackgroundImage");
		this.panel2.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
		this.panel2.Location = new global::System.Drawing.Point(3, 3);
		this.panel2.Name = "panel2";
		this.panel2.Size = new global::System.Drawing.Size(416, 93);
		this.panel2.TabIndex = 21;
		this.textBox3.BackColor = global::System.Drawing.Color.White;
		this.textBox3.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
		this.textBox3.Enabled = false;
		this.textBox3.Location = new global::System.Drawing.Point(16, 175);
		this.textBox3.Multiline = true;
		this.textBox3.Name = "textBox3";
		this.textBox3.ReadOnly = true;
		this.textBox3.Size = new global::System.Drawing.Size(393, 81);
		this.textBox3.TabIndex = 6;
		this.textBox3.Text = "Use the key above to purchase a License for this machine.\r\n Then enter the License Key in the box below and click Activate. YOU HAVE TO RESTART FiatECUScan AFTER ACTIVATION!";
		this.textBox3.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
		this.buttonActivate.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.buttonActivate.Location = new global::System.Drawing.Point(168, 339);
		this.buttonActivate.Name = "buttonActivate";
		this.buttonActivate.Size = new global::System.Drawing.Size(87, 27);
		this.buttonActivate.TabIndex = 4;
		this.buttonActivate.Text = "Activate";
		this.buttonActivate.UseVisualStyleBackColor = true;
		this.buttonActivate.Click += new global::System.EventHandler(this.buttonActivate_Click);
		this.label2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.label2.AutoSize = true;
		this.label2.Location = new global::System.Drawing.Point(13, 275);
		this.label2.Name = "label2";
		this.label2.Size = new global::System.Drawing.Size(81, 16);
		this.label2.TabIndex = 3;
		this.label2.Text = "License Key";
		this.label1.AutoSize = true;
		this.label1.Location = new global::System.Drawing.Point(13, 142);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(93, 16);
		this.label1.TabIndex = 2;
		this.label1.Text = "Hardware Key";
		this.tbSerial.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.tbSerial.Location = new global::System.Drawing.Point(116, 272);
		this.tbSerial.Name = "tbSerial";
		this.tbSerial.Size = new global::System.Drawing.Size(293, 22);
		this.tbSerial.TabIndex = 1;
		this.tbKey.Location = new global::System.Drawing.Point(116, 139);
		this.tbKey.Name = "tbKey";
		this.tbKey.ReadOnly = true;
		this.tbKey.Size = new global::System.Drawing.Size(293, 22);
		this.tbKey.TabIndex = 0;
		base.AcceptButton = this.buttonActivate;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.Color.White;
		base.CancelButton = this.buttonExit;
		base.ClientSize = new global::System.Drawing.Size(448, 403);
		base.Controls.Add(this.panel1);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormRegistration";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Registration";
		base.Shown += new global::System.EventHandler(this.FormRegistration_Shown);
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		base.ResumeLayout(false);
	}

	// Token: 0x04000474 RID: 1140
	private global::System.ComponentModel.IContainer icontainer_0 = null;

	// Token: 0x04000475 RID: 1141
	private global::System.Windows.Forms.Panel panel1;

	// Token: 0x04000476 RID: 1142
	private global::System.Windows.Forms.Label label1;

	// Token: 0x04000477 RID: 1143
	private global::System.Windows.Forms.TextBox tbSerial;

	// Token: 0x04000478 RID: 1144
	private global::System.Windows.Forms.TextBox tbKey;

	// Token: 0x04000479 RID: 1145
	private global::System.Windows.Forms.Label label2;

	// Token: 0x0400047A RID: 1146
	private global::System.Windows.Forms.Button buttonActivate;

	// Token: 0x0400047B RID: 1147
	private global::System.Windows.Forms.TextBox textBox3;

	// Token: 0x0400047C RID: 1148
	private global::System.Windows.Forms.Panel panel2;

	// Token: 0x0400047D RID: 1149
	private global::System.Windows.Forms.TextBox textBox4;

	// Token: 0x0400047E RID: 1150
	private global::System.Windows.Forms.Button buttonExit;

	// Token: 0x0400047F RID: 1151
	private global::System.Windows.Forms.Button buttonDeactivate;

	// Token: 0x04000480 RID: 1152
	private global::System.Windows.Forms.Label label3;

	// Token: 0x04000481 RID: 1153
	private global::System.Windows.Forms.TextBox tbRemoval;

	// Token: 0x04000482 RID: 1154
	private global::System.Windows.Forms.Label lblLink;
}
