// Token: 0x02000052 RID: 82
public sealed partial class FormCrack1 : global::System.Windows.Forms.Form
{
	// Token: 0x0600021E RID: 542 RVA: 0x00002EBB File Offset: 0x000010BB
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x0600021F RID: 543 RVA: 0x0005BC10 File Offset: 0x00059E10
	private void InitializeComponent()
	{
		this.label1 = new global::System.Windows.Forms.Label();
		this.label2 = new global::System.Windows.Forms.Label();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new global::System.Drawing.Font("Segoe UI", 24.192f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label1.Location = new global::System.Drawing.Point(103, 36);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(430, 57);
		this.label1.TabIndex = 0;
		this.label1.Text = "HELLO MR. CRACKER!";
		this.label2.AutoSize = true;
		this.label2.Font = new global::System.Drawing.Font("Segoe UI", 24.192f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
		this.label2.Location = new global::System.Drawing.Point(147, 131);
		this.label2.Name = "label2";
		this.label2.Size = new global::System.Drawing.Size(328, 57);
		this.label2.TabIndex = 1;
		this.label2.Text = "Have a nice day!";
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(633, 244);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Name = "FormCrack1";
		base.ShowInTaskbar = false;
		this.Text = "HELLO MR. CRACKER";
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x0400038D RID: 909
	private global::System.ComponentModel.IContainer icontainer_0 = null;

	// Token: 0x0400038E RID: 910
	private global::System.Windows.Forms.Label label1;

	// Token: 0x0400038F RID: 911
	private global::System.Windows.Forms.Label label2;
}
