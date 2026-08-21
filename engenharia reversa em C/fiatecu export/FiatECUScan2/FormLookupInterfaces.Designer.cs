// Token: 0x02000018 RID: 24
public sealed partial class FormLookupInterfaces : global::System.Windows.Forms.Form
{
	// Token: 0x060000E5 RID: 229 RVA: 0x00002B3B File Offset: 0x00000D3B
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x00025354 File Offset: 0x00023554
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		this.textBox1 = new global::System.Windows.Forms.TextBox();
		this.timer_0 = new global::System.Windows.Forms.Timer(this.icontainer_0);
		this.progressBar1 = new global::System.Windows.Forms.ProgressBar();
		this.label1 = new global::System.Windows.Forms.Label();
		this.buttonCancel = new global::System.Windows.Forms.Button();
		this.buttonOK = new global::System.Windows.Forms.Button();
		base.SuspendLayout();
		this.textBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.textBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox1.Location = new global::System.Drawing.Point(15, 15);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.textBox1.Size = new global::System.Drawing.Size(536, 368);
		this.textBox1.TabIndex = 0;
		this.timer_0.Enabled = true;
		this.timer_0.Interval = 300;
		this.timer_0.Tick += new global::System.EventHandler(this.timer_0_Tick);
		this.progressBar1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.progressBar1.Location = new global::System.Drawing.Point(15, 404);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new global::System.Drawing.Size(312, 20);
		this.progressBar1.TabIndex = 12;
		this.label1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
		this.label1.AutoSize = true;
		this.label1.Location = new global::System.Drawing.Point(15, 384);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(17, 16);
		this.label1.TabIndex = 14;
		this.label1.Text = "...";
		this.buttonCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.buttonCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.buttonCancel.Location = new global::System.Drawing.Point(333, 400);
		this.buttonCancel.Name = "buttonCancel";
		this.buttonCancel.Size = new global::System.Drawing.Size(106, 27);
		this.buttonCancel.TabIndex = 17;
		this.buttonCancel.Tag = "8198";
		this.buttonCancel.Text = "Cancel";
		this.buttonCancel.UseVisualStyleBackColor = true;
		this.buttonCancel.Click += new global::System.EventHandler(this.buttonCancel_Click);
		this.buttonOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.buttonOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
		this.buttonOK.Location = new global::System.Drawing.Point(445, 400);
		this.buttonOK.Name = "buttonOK";
		this.buttonOK.Size = new global::System.Drawing.Size(106, 27);
		this.buttonOK.TabIndex = 16;
		this.buttonOK.Tag = "8199";
		this.buttonOK.Text = "OK";
		this.buttonOK.UseVisualStyleBackColor = true;
		this.buttonOK.Click += new global::System.EventHandler(this.buttonOK_Click);
		base.AcceptButton = this.buttonOK;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(564, 438);
		base.ControlBox = false;
		base.Controls.Add(this.buttonCancel);
		base.Controls.Add(this.buttonOK);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.progressBar1);
		base.Controls.Add(this.textBox1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormLookupInterfaces";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Scan For Interfaces";
		base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FormLookupInterfaces_FormClosing);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x040000FA RID: 250
	private global::System.ComponentModel.IContainer icontainer_0 = null;

	// Token: 0x040000FB RID: 251
	private global::System.Windows.Forms.TextBox textBox1;

	// Token: 0x040000FC RID: 252
	private global::System.Windows.Forms.Timer timer_0;

	// Token: 0x040000FD RID: 253
	private global::System.Windows.Forms.ProgressBar progressBar1;

	// Token: 0x040000FE RID: 254
	private global::System.Windows.Forms.Label label1;

	// Token: 0x040000FF RID: 255
	private global::System.Windows.Forms.Button buttonCancel;

	// Token: 0x04000100 RID: 256
	private global::System.Windows.Forms.Button buttonOK;
}
