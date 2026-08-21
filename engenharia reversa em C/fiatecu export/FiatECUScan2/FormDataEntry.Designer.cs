// Token: 0x02000017 RID: 23
public sealed partial class FormDataEntry : global::System.Windows.Forms.Form
{
	// Token: 0x060000D9 RID: 217 RVA: 0x00002AD8 File Offset: 0x00000CD8
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x060000DA RID: 218 RVA: 0x00023980 File Offset: 0x00021B80
	private void InitializeComponent()
	{
		this.panel1 = new global::System.Windows.Forms.Panel();
		this.tableLayoutPanelButtons = new global::System.Windows.Forms.TableLayoutPanel();
		this.buttonCancel = new global::System.Windows.Forms.Button();
		this.buttonOk = new global::System.Windows.Forms.Button();
		this.panel2 = new global::System.Windows.Forms.Panel();
		this.cbChar2 = new global::System.Windows.Forms.ComboBox();
		this.cbChar9 = new global::System.Windows.Forms.ComboBox();
		this.cbChar1 = new global::System.Windows.Forms.ComboBox();
		this.cbChar8 = new global::System.Windows.Forms.ComboBox();
		this.cbChar3 = new global::System.Windows.Forms.ComboBox();
		this.cbChar7 = new global::System.Windows.Forms.ComboBox();
		this.cbChar4 = new global::System.Windows.Forms.ComboBox();
		this.cbChar6 = new global::System.Windows.Forms.ComboBox();
		this.cbChar5 = new global::System.Windows.Forms.ComboBox();
		this.lblMessage1 = new global::System.Windows.Forms.Label();
		this.panel1.SuspendLayout();
		this.tableLayoutPanelButtons.SuspendLayout();
		this.panel2.SuspendLayout();
		base.SuspendLayout();
		this.panel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.panel1.BackColor = global::System.Drawing.Color.Black;
		this.panel1.Controls.Add(this.tableLayoutPanelButtons);
		this.panel1.Controls.Add(this.panel2);
		this.panel1.Controls.Add(this.lblMessage1);
		this.panel1.ForeColor = global::System.Drawing.Color.Red;
		this.panel1.Location = new global::System.Drawing.Point(12, 12);
		this.panel1.Name = "panel1";
		this.panel1.Size = new global::System.Drawing.Size(626, 194);
		this.panel1.TabIndex = 1;
		this.tableLayoutPanelButtons.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.tableLayoutPanelButtons.ColumnCount = 2;
		this.tableLayoutPanelButtons.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanelButtons.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanelButtons.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
		this.tableLayoutPanelButtons.Controls.Add(this.buttonCancel, 0, 0);
		this.tableLayoutPanelButtons.Controls.Add(this.buttonOk, 1, 0);
		this.tableLayoutPanelButtons.Location = new global::System.Drawing.Point(30, 128);
		this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
		this.tableLayoutPanelButtons.RowCount = 1;
		this.tableLayoutPanelButtons.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanelButtons.Size = new global::System.Drawing.Size(564, 48);
		this.tableLayoutPanelButtons.TabIndex = 8;
		this.buttonCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.buttonCancel.AutoSize = true;
		this.buttonCancel.BackColor = global::System.Drawing.Color.Silver;
		this.buttonCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.buttonCancel.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold);
		this.buttonCancel.ForeColor = global::System.Drawing.Color.Red;
		this.buttonCancel.Location = new global::System.Drawing.Point(3, 3);
		this.buttonCancel.Name = "buttonCancel";
		this.buttonCancel.Size = new global::System.Drawing.Size(276, 42);
		this.buttonCancel.TabIndex = 2;
		this.buttonCancel.Tag = "8198";
		this.buttonCancel.Text = "Cancel";
		this.buttonCancel.UseVisualStyleBackColor = false;
		this.buttonOk.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
		this.buttonOk.AutoSize = true;
		this.buttonOk.BackColor = global::System.Drawing.Color.Silver;
		this.buttonOk.DialogResult = global::System.Windows.Forms.DialogResult.OK;
		this.buttonOk.Font = new global::System.Drawing.Font("Arial", 13.8f, global::System.Drawing.FontStyle.Bold);
		this.buttonOk.ForeColor = global::System.Drawing.Color.Green;
		this.buttonOk.Location = new global::System.Drawing.Point(285, 3);
		this.buttonOk.Name = "buttonOk";
		this.buttonOk.Size = new global::System.Drawing.Size(276, 42);
		this.buttonOk.TabIndex = 1;
		this.buttonOk.Tag = "8199";
		this.buttonOk.Text = "OK";
		this.buttonOk.UseVisualStyleBackColor = false;
		this.buttonOk.Click += new global::System.EventHandler(this.buttonOk_Click);
		this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel2.Controls.Add(this.cbChar2);
		this.panel2.Controls.Add(this.cbChar9);
		this.panel2.Controls.Add(this.cbChar1);
		this.panel2.Controls.Add(this.cbChar8);
		this.panel2.Controls.Add(this.cbChar3);
		this.panel2.Controls.Add(this.cbChar7);
		this.panel2.Controls.Add(this.cbChar4);
		this.panel2.Controls.Add(this.cbChar6);
		this.panel2.Controls.Add(this.cbChar5);
		this.panel2.Location = new global::System.Drawing.Point(30, 55);
		this.panel2.Name = "panel2";
		this.panel2.Size = new global::System.Drawing.Size(564, 50);
		this.panel2.TabIndex = 0;
		this.cbChar2.BackColor = global::System.Drawing.Color.White;
		this.cbChar2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbChar2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.cbChar2.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.cbChar2.ForeColor = global::System.Drawing.Color.Green;
		this.cbChar2.FormattingEnabled = true;
		this.cbChar2.Location = new global::System.Drawing.Point(68, 8);
		this.cbChar2.Name = "cbChar2";
		this.cbChar2.Size = new global::System.Drawing.Size(55, 32);
		this.cbChar2.TabIndex = 1;
		this.cbChar2.SelectedIndexChanged += new global::System.EventHandler(this.cbChar5_SelectedIndexChanged);
		this.cbChar9.BackColor = global::System.Drawing.Color.White;
		this.cbChar9.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbChar9.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.cbChar9.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.cbChar9.ForeColor = global::System.Drawing.Color.Green;
		this.cbChar9.FormattingEnabled = true;
		this.cbChar9.Location = new global::System.Drawing.Point(495, 8);
		this.cbChar9.Name = "cbChar9";
		this.cbChar9.Size = new global::System.Drawing.Size(55, 32);
		this.cbChar9.TabIndex = 8;
		this.cbChar9.SelectedIndexChanged += new global::System.EventHandler(this.cbChar5_SelectedIndexChanged);
		this.cbChar1.BackColor = global::System.Drawing.Color.White;
		this.cbChar1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbChar1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.cbChar1.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.cbChar1.ForeColor = global::System.Drawing.Color.Green;
		this.cbChar1.FormattingEnabled = true;
		this.cbChar1.Location = new global::System.Drawing.Point(7, 8);
		this.cbChar1.Name = "cbChar1";
		this.cbChar1.Size = new global::System.Drawing.Size(55, 32);
		this.cbChar1.TabIndex = 0;
		this.cbChar1.SelectedIndexChanged += new global::System.EventHandler(this.cbChar5_SelectedIndexChanged);
		this.cbChar8.BackColor = global::System.Drawing.Color.White;
		this.cbChar8.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbChar8.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.cbChar8.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.cbChar8.ForeColor = global::System.Drawing.Color.Green;
		this.cbChar8.FormattingEnabled = true;
		this.cbChar8.Location = new global::System.Drawing.Point(434, 8);
		this.cbChar8.Name = "cbChar8";
		this.cbChar8.Size = new global::System.Drawing.Size(55, 32);
		this.cbChar8.TabIndex = 7;
		this.cbChar8.SelectedIndexChanged += new global::System.EventHandler(this.cbChar5_SelectedIndexChanged);
		this.cbChar3.BackColor = global::System.Drawing.Color.White;
		this.cbChar3.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbChar3.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.cbChar3.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.cbChar3.ForeColor = global::System.Drawing.Color.Green;
		this.cbChar3.FormattingEnabled = true;
		this.cbChar3.Location = new global::System.Drawing.Point(129, 8);
		this.cbChar3.Name = "cbChar3";
		this.cbChar3.Size = new global::System.Drawing.Size(55, 32);
		this.cbChar3.TabIndex = 2;
		this.cbChar3.SelectedIndexChanged += new global::System.EventHandler(this.cbChar5_SelectedIndexChanged);
		this.cbChar7.BackColor = global::System.Drawing.Color.White;
		this.cbChar7.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbChar7.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.cbChar7.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.cbChar7.ForeColor = global::System.Drawing.Color.Green;
		this.cbChar7.FormattingEnabled = true;
		this.cbChar7.Location = new global::System.Drawing.Point(373, 8);
		this.cbChar7.Name = "cbChar7";
		this.cbChar7.Size = new global::System.Drawing.Size(55, 32);
		this.cbChar7.TabIndex = 6;
		this.cbChar7.SelectedIndexChanged += new global::System.EventHandler(this.cbChar5_SelectedIndexChanged);
		this.cbChar4.BackColor = global::System.Drawing.Color.White;
		this.cbChar4.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbChar4.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.cbChar4.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.cbChar4.ForeColor = global::System.Drawing.Color.Green;
		this.cbChar4.FormattingEnabled = true;
		this.cbChar4.Location = new global::System.Drawing.Point(190, 8);
		this.cbChar4.Name = "cbChar4";
		this.cbChar4.Size = new global::System.Drawing.Size(55, 32);
		this.cbChar4.TabIndex = 3;
		this.cbChar4.SelectedIndexChanged += new global::System.EventHandler(this.cbChar5_SelectedIndexChanged);
		this.cbChar6.BackColor = global::System.Drawing.Color.White;
		this.cbChar6.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbChar6.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.cbChar6.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.cbChar6.ForeColor = global::System.Drawing.Color.Green;
		this.cbChar6.FormattingEnabled = true;
		this.cbChar6.Location = new global::System.Drawing.Point(312, 8);
		this.cbChar6.Name = "cbChar6";
		this.cbChar6.Size = new global::System.Drawing.Size(55, 32);
		this.cbChar6.TabIndex = 5;
		this.cbChar6.SelectedIndexChanged += new global::System.EventHandler(this.cbChar5_SelectedIndexChanged);
		this.cbChar5.BackColor = global::System.Drawing.Color.White;
		this.cbChar5.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cbChar5.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.cbChar5.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.cbChar5.ForeColor = global::System.Drawing.Color.Green;
		this.cbChar5.FormattingEnabled = true;
		this.cbChar5.Location = new global::System.Drawing.Point(251, 8);
		this.cbChar5.Name = "cbChar5";
		this.cbChar5.Size = new global::System.Drawing.Size(55, 32);
		this.cbChar5.TabIndex = 4;
		this.cbChar5.SelectedIndexChanged += new global::System.EventHandler(this.cbChar5_SelectedIndexChanged);
		this.lblMessage1.AutoSize = true;
		this.lblMessage1.Font = new global::System.Drawing.Font("Arial", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
		this.lblMessage1.Location = new global::System.Drawing.Point(27, 16);
		this.lblMessage1.Name = "lblMessage1";
		this.lblMessage1.Size = new global::System.Drawing.Size(229, 34);
		this.lblMessage1.TabIndex = 0;
		this.lblMessage1.Text = "Test message 1";
		base.AcceptButton = this.buttonOk;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.Color.Red;
		base.CancelButton = this.buttonCancel;
		base.ClientSize = new global::System.Drawing.Size(650, 218);
		base.Controls.Add(this.panel1);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormDataEntry";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "FormDataEntry";
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.tableLayoutPanelButtons.ResumeLayout(false);
		this.tableLayoutPanelButtons.PerformLayout();
		this.panel2.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	// Token: 0x040000DF RID: 223
	private global::System.ComponentModel.IContainer icontainer_0 = null;

	// Token: 0x040000E0 RID: 224
	private global::System.Windows.Forms.Panel panel1;

	// Token: 0x040000E1 RID: 225
	private global::System.Windows.Forms.Label lblMessage1;

	// Token: 0x040000E2 RID: 226
	private global::System.Windows.Forms.Button buttonCancel;

	// Token: 0x040000E3 RID: 227
	private global::System.Windows.Forms.Button buttonOk;

	// Token: 0x040000E4 RID: 228
	private global::System.Windows.Forms.ComboBox cbChar1;

	// Token: 0x040000E5 RID: 229
	private global::System.Windows.Forms.Panel panel2;

	// Token: 0x040000E6 RID: 230
	private global::System.Windows.Forms.ComboBox cbChar9;

	// Token: 0x040000E7 RID: 231
	private global::System.Windows.Forms.ComboBox cbChar8;

	// Token: 0x040000E8 RID: 232
	private global::System.Windows.Forms.ComboBox cbChar7;

	// Token: 0x040000E9 RID: 233
	private global::System.Windows.Forms.ComboBox cbChar6;

	// Token: 0x040000EA RID: 234
	private global::System.Windows.Forms.ComboBox cbChar5;

	// Token: 0x040000EB RID: 235
	private global::System.Windows.Forms.ComboBox cbChar4;

	// Token: 0x040000EC RID: 236
	private global::System.Windows.Forms.ComboBox cbChar3;

	// Token: 0x040000ED RID: 237
	private global::System.Windows.Forms.ComboBox cbChar2;

	// Token: 0x040000EE RID: 238
	private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
}
