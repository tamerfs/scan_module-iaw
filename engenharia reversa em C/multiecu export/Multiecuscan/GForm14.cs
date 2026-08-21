using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Multiecuscan;

// Token: 0x020000B5 RID: 181
public partial class GForm14 : Form
{
	// Token: 0x060005EF RID: 1519 RVA: 0x000043E4 File Offset: 0x000025E4
	public GForm14(List<SimpleValueData> list_0)
	{
		this.method_0();
		this.dataGridView_0.DataSource = list_0;
	}

	// Token: 0x060005F0 RID: 1520 RVA: 0x00002F0A File Offset: 0x0000110A
	private void button_0_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x060005F1 RID: 1521 RVA: 0x000043FE File Offset: 0x000025FE
	private void GForm14_Shown(object sender, EventArgs e)
	{
		this.dataGridView_0.Refresh();
	}

	// Token: 0x060005F3 RID: 1523 RVA: 0x000D7BDC File Offset: 0x000D5DDC
	private void method_0()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.button_0 = new Button();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		base.SuspendLayout();
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.AllowUserToResizeRows = false;
		this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_0.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.ColumnHeadersVisible = false;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1
		});
		this.dataGridView_0.Location = new Point(12, 12);
		this.dataGridView_0.MultiSelect = false;
		this.dataGridView_0.Name = GClass107.smethod_3(146909);
		this.dataGridView_0.ReadOnly = true;
		this.dataGridView_0.RowHeadersVisible = false;
		this.dataGridView_0.RowTemplate.DefaultCellStyle.BackColor = Color.White;
		this.dataGridView_0.RowTemplate.DefaultCellStyle.Font = new Font(GClass107.smethod_3(146957), 7.8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.dataGridView_0.RowTemplate.DefaultCellStyle.ForeColor = Color.Navy;
		this.dataGridView_0.RowTemplate.Height = 24;
		this.dataGridView_0.ScrollBars = ScrollBars.Vertical;
		this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_0.ShowEditingIcon = false;
		this.dataGridView_0.Size = new Size(570, 310);
		this.dataGridView_0.StandardTab = true;
		this.dataGridView_0.TabIndex = 0;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "ID";
		this.dataGridViewTextBoxColumn_0.HeaderText = GClass107.smethod_3(146999);
		this.dataGridViewTextBoxColumn_0.Name = GClass107.smethod_3(147024);
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Width = 50;
		this.dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = GClass107.smethod_3(147040);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		this.dataGridViewTextBoxColumn_1.DefaultCellStyle = dataGridViewCellStyle;
		this.dataGridViewTextBoxColumn_1.HeaderText = GClass107.smethod_3(147084);
		this.dataGridViewTextBoxColumn_1.Name = GClass107.smethod_3(147087);
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(249, 341);
		this.button_0.Name = GClass107.smethod_3(147132);
		this.button_0.Size = new Size(96, 27);
		this.button_0.TabIndex = 1;
		this.button_0.Text = "OK";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(8f, 16f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.White;
		base.ClientSize = new Size(594, 380);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.dataGridView_0);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = GClass107.smethod_3(147154);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		this.Text = GClass107.smethod_3(147174);
		base.Shown += this.GForm14_Shown;
		((ISupportInitialize)this.dataGridView_0).EndInit();
		base.ResumeLayout(false);
	}

	// Token: 0x0400052C RID: 1324
	private DataGridView dataGridView_0;

	// Token: 0x0400052D RID: 1325
	private Button button_0;

	// Token: 0x0400052E RID: 1326
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	// Token: 0x0400052F RID: 1327
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;
}
