// Token: 0x02000002 RID: 2
public sealed partial class FormLookupModules : global::System.Windows.Forms.Form
{
	// Token: 0x06000006 RID: 6 RVA: 0x000026DE File Offset: 0x000008DE
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000052D4 File Offset: 0x000034D4
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		this.textBox1 = new global::System.Windows.Forms.TextBox();
		this.timer_0 = new global::System.Windows.Forms.Timer(this.icontainer_0);
		this.buttonDisconnect = new global::System.Windows.Forms.Button();
		this.progressBar1 = new global::System.Windows.Forms.ProgressBar();
		base.SuspendLayout();
		this.textBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.textBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox1.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
		this.textBox1.ForeColor = global::System.Drawing.Color.Navy;
		this.textBox1.Location = new global::System.Drawing.Point(12, 12);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.textBox1.Size = new global::System.Drawing.Size(557, 389);
		this.textBox1.TabIndex = 0;
		this.timer_0.Enabled = true;
		this.timer_0.Interval = 800;
		this.timer_0.Tick += new global::System.EventHandler(this.timer_0_Tick);
		this.buttonDisconnect.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.buttonDisconnect.AutoSize = true;
		this.buttonDisconnect.DialogResult = global::System.Windows.Forms.DialogResult.OK;
		this.buttonDisconnect.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.buttonDisconnect.ForeColor = global::System.Drawing.Color.Navy;
		this.buttonDisconnect.ImageKey = "(none)";
		this.buttonDisconnect.Location = new global::System.Drawing.Point(452, 407);
		this.buttonDisconnect.Name = "buttonDisconnect";
		this.buttonDisconnect.Size = new global::System.Drawing.Size(117, 37);
		this.buttonDisconnect.TabIndex = 10;
		this.buttonDisconnect.Tag = "8199";
		this.buttonDisconnect.Text = "OK";
		this.buttonDisconnect.UseVisualStyleBackColor = true;
		this.buttonDisconnect.Click += new global::System.EventHandler(this.buttonDisconnect_Click);
		this.progressBar1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.progressBar1.Location = new global::System.Drawing.Point(12, 407);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new global::System.Drawing.Size(434, 37);
		this.progressBar1.TabIndex = 11;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(582, 456);
		base.ControlBox = false;
		base.Controls.Add(this.progressBar1);
		base.Controls.Add(this.buttonDisconnect);
		base.Controls.Add(this.textBox1);
		base.Name = "FormLookupModules";
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Scan Modules";
		base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FormLookupModules_FormClosing);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000009 RID: 9
	private global::System.ComponentModel.IContainer icontainer_0 = null;

	// Token: 0x0400000A RID: 10
	private global::System.Windows.Forms.TextBox textBox1;

	// Token: 0x0400000B RID: 11
	private global::System.Windows.Forms.Timer timer_0;

	// Token: 0x0400000C RID: 12
	private global::System.Windows.Forms.Button buttonDisconnect;

	// Token: 0x0400000D RID: 13
	private global::System.Windows.Forms.ProgressBar progressBar1;
}
