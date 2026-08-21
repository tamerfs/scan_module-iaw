// Token: 0x02000057 RID: 87
public sealed partial class FormTestELMData : global::System.Windows.Forms.Form
{
	// Token: 0x06000261 RID: 609 RVA: 0x00002F33 File Offset: 0x00001133
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000262 RID: 610 RVA: 0x000605AC File Offset: 0x0005E7AC
	private void InitializeComponent()
	{
		this.icontainer_0 = new global::System.ComponentModel.Container();
		this.textBox1 = new global::System.Windows.Forms.TextBox();
		this.buttonOk = new global::System.Windows.Forms.Button();
		this.timer_0 = new global::System.Windows.Forms.Timer(this.icontainer_0);
		this.buttonStart = new global::System.Windows.Forms.Button();
		base.SuspendLayout();
		this.textBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox1.Location = new global::System.Drawing.Point(12, 12);
		this.textBox1.Multiline = true;
		this.textBox1.Name = "textBox1";
		this.textBox1.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.textBox1.Size = new global::System.Drawing.Size(440, 377);
		this.textBox1.TabIndex = 0;
		this.buttonOk.DialogResult = global::System.Windows.Forms.DialogResult.OK;
		this.buttonOk.Location = new global::System.Drawing.Point(186, 404);
		this.buttonOk.Name = "buttonOk";
		this.buttonOk.Size = new global::System.Drawing.Size(92, 27);
		this.buttonOk.TabIndex = 2;
		this.buttonOk.Tag = "8199";
		this.buttonOk.Text = "OK";
		this.buttonOk.UseVisualStyleBackColor = true;
		this.buttonOk.Click += new global::System.EventHandler(this.buttonOk_Click);
		this.timer_0.Enabled = true;
		this.timer_0.Interval = 200;
		this.timer_0.Tick += new global::System.EventHandler(this.timer_0_Tick);
		this.buttonStart.Location = new global::System.Drawing.Point(12, 404);
		this.buttonStart.Name = "buttonStart";
		this.buttonStart.Size = new global::System.Drawing.Size(106, 27);
		this.buttonStart.TabIndex = 3;
		this.buttonStart.Text = "Stop";
		this.buttonStart.UseVisualStyleBackColor = true;
		this.buttonStart.Click += new global::System.EventHandler(this.buttonStart_Click);
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.AutoSize = true;
		base.ClientSize = new global::System.Drawing.Size(465, 444);
		base.ControlBox = false;
		base.Controls.Add(this.buttonStart);
		base.Controls.Add(this.buttonOk);
		base.Controls.Add(this.textBox1);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Name = "FormTestELMData";
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Test ELM Connection";
		base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FormTestELMData_FormClosing);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x040003B6 RID: 950
	private global::System.ComponentModel.IContainer icontainer_0 = null;

	// Token: 0x040003B7 RID: 951
	private global::System.Windows.Forms.TextBox textBox1;

	// Token: 0x040003B8 RID: 952
	private global::System.Windows.Forms.Button buttonOk;

	// Token: 0x040003B9 RID: 953
	private global::System.Windows.Forms.Timer timer_0;

	// Token: 0x040003BA RID: 954
	private global::System.Windows.Forms.Button buttonStart;
}
