// Token: 0x02000088 RID: 136
public sealed partial class FormTemplates : global::System.Windows.Forms.Form
{
	// Token: 0x060004F4 RID: 1268 RVA: 0x00003951 File Offset: 0x00001B51
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x00091EA4 File Offset: 0x000900A4
	private void InitializeComponent()
	{
		global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
		this.dgvTemplates = new global::System.Windows.Forms.DataGridView();
		this.Column1 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column2 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
		this.buttonOK = new global::System.Windows.Forms.Button();
		((global::System.ComponentModel.ISupportInitialize)this.dgvTemplates).BeginInit();
		base.SuspendLayout();
		this.dgvTemplates.AllowUserToAddRows = false;
		this.dgvTemplates.AllowUserToDeleteRows = false;
		this.dgvTemplates.AllowUserToResizeRows = false;
		this.dgvTemplates.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.dgvTemplates.AutoSizeRowsMode = global::System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
		this.dgvTemplates.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvTemplates.ColumnHeadersVisible = false;
		this.dgvTemplates.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
		{
			this.Column1,
			this.Column2
		});
		this.dgvTemplates.Location = new global::System.Drawing.Point(12, 12);
		this.dgvTemplates.MultiSelect = false;
		this.dgvTemplates.Name = "dgvTemplates";
		this.dgvTemplates.ReadOnly = true;
		this.dgvTemplates.RowHeadersVisible = false;
		this.dgvTemplates.RowTemplate.DefaultCellStyle.BackColor = global::System.Drawing.Color.White;
		this.dgvTemplates.RowTemplate.DefaultCellStyle.Font = new global::System.Drawing.Font("Arial", 7.8f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
		this.dgvTemplates.RowTemplate.DefaultCellStyle.ForeColor = global::System.Drawing.Color.Navy;
		this.dgvTemplates.RowTemplate.Height = 24;
		this.dgvTemplates.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
		this.dgvTemplates.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgvTemplates.ShowEditingIcon = false;
		this.dgvTemplates.Size = new global::System.Drawing.Size(570, 310);
		this.dgvTemplates.StandardTab = true;
		this.dgvTemplates.TabIndex = 0;
		this.Column1.DataPropertyName = "ID";
		this.Column1.HeaderText = "Column1";
		this.Column1.Name = "Column1";
		this.Column1.ReadOnly = true;
		this.Column1.Width = 50;
		this.Column2.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.Column2.DataPropertyName = "VALUE";
		dataGridViewCellStyle.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
		this.Column2.DefaultCellStyle = dataGridViewCellStyle;
		this.Column2.HeaderText = "Column2";
		this.Column2.Name = "Column2";
		this.Column2.ReadOnly = true;
		this.buttonOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
		this.buttonOK.Location = new global::System.Drawing.Point(249, 341);
		this.buttonOK.Name = "buttonOK";
		this.buttonOK.Size = new global::System.Drawing.Size(96, 27);
		this.buttonOK.TabIndex = 1;
		this.buttonOK.Text = "OK";
		this.buttonOK.UseVisualStyleBackColor = true;
		this.buttonOK.Click += new global::System.EventHandler(this.buttonOK_Click);
		base.AcceptButton = this.buttonOK;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.Color.White;
		base.ClientSize = new global::System.Drawing.Size(594, 380);
		base.Controls.Add(this.buttonOK);
		base.Controls.Add(this.dgvTemplates);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormTemplates";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Templates";
		base.Shown += new global::System.EventHandler(this.FormTemplates_Shown);
		((global::System.ComponentModel.ISupportInitialize)this.dgvTemplates).EndInit();
		base.ResumeLayout(false);
	}

	// Token: 0x04000659 RID: 1625
	private global::System.ComponentModel.IContainer icontainer_0 = null;

	// Token: 0x0400065A RID: 1626
	private global::System.Windows.Forms.DataGridView dgvTemplates;

	// Token: 0x0400065B RID: 1627
	private global::System.Windows.Forms.Button buttonOK;

	// Token: 0x0400065C RID: 1628
	private global::System.Windows.Forms.DataGridViewTextBoxColumn Column1;

	// Token: 0x0400065D RID: 1629
	private global::System.Windows.Forms.DataGridViewTextBoxColumn Column2;
}
