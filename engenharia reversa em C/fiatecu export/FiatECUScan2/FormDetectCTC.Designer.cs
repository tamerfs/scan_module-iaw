// Token: 0x0200001C RID: 28
public sealed partial class FormDetectCTC : global::System.Windows.Forms.Form
{
	// Token: 0x06000127 RID: 295 RVA: 0x00002B83 File Offset: 0x00000D83
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000128 RID: 296 RVA: 0x0003474C File Offset: 0x0003294C
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		this.progressBar1 = new global::System.Windows.Forms.ProgressBar();
		this.buttonCancel = new global::System.Windows.Forms.Button();
		this.label1 = new global::System.Windows.Forms.Label();
		this.textBox1 = new global::System.Windows.Forms.TextBox();
		this.timer_0 = new global::System.Windows.Forms.Timer(this.icontainer_0);
		base.SuspendLayout();
		this.progressBar1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.progressBar1.Location = new global::System.Drawing.Point(12, 38);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new global::System.Drawing.Size(418, 23);
		this.progressBar1.TabIndex = 0;
		this.buttonCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.buttonCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.buttonCancel.Location = new global::System.Drawing.Point(315, 138);
		this.buttonCancel.Name = "buttonCancel";
		this.buttonCancel.Size = new global::System.Drawing.Size(115, 27);
		this.buttonCancel.TabIndex = 25;
		this.buttonCancel.Text = "Cancel";
		this.buttonCancel.UseVisualStyleBackColor = true;
		this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
		this.label1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.label1.AutoSize = true;
		this.label1.Location = new global::System.Drawing.Point(12, 16);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(204, 16);
		this.label1.TabIndex = 26;
		this.label1.Text = "Detecting CANtieCAR interface ...";
		this.textBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.textBox1.BackColor = global::System.Drawing.Color.White;
		this.textBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
		this.textBox1.Location = new global::System.Drawing.Point(12, 67);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.ReadOnly = true;
		this.textBox1.Size = new global::System.Drawing.Size(418, 65);
		this.textBox1.TabIndex = 27;
		this.textBox1.Text = "Please make sure that the interface is connected to the USB port and the driver is properly installed!";
		this.textBox1.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
		this.timer_0.Interval = 300;
		this.timer_0.Tick += new global::System.EventHandler(this.timer_0_Tick);
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.Color.White;
		base.ClientSize = new global::System.Drawing.Size(442, 177);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.buttonCancel);
		base.Controls.Add(this.progressBar1);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Name = "FormDetectCTC";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "CANtieCAR";
		base.Shown += new global::System.EventHandler(this.FormDetectCTC_Shown);
		base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FormDetectCTC_FormClosing);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x04000110 RID: 272
	private global::System.ComponentModel.IContainer icontainer_0 = null;

	// Token: 0x04000111 RID: 273
	private global::System.Windows.Forms.ProgressBar progressBar1;

	// Token: 0x04000112 RID: 274
	private global::System.Windows.Forms.Button buttonCancel;

	// Token: 0x04000113 RID: 275
	private global::System.Windows.Forms.Label label1;

	// Token: 0x04000114 RID: 276
	private global::System.Windows.Forms.TextBox textBox1;

	// Token: 0x04000115 RID: 277
	private global::System.Windows.Forms.Timer timer_0;
}
