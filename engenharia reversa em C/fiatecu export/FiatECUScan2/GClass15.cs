using System;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000016 RID: 22
public sealed class GClass15 : Panel
{
	// Token: 0x060000CC RID: 204 RVA: 0x00002ACA File Offset: 0x00000CCA
	public GClass15()
	{
		this.method_0();
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00022BD0 File Offset: 0x00020DD0
	public GClass15(int int_1)
	{
		this.int_0 = int_1;
		this.method_0();
		try
		{
			GClass0 gclass = GClass3.smethod_0();
			this.lblParamName.Text = gclass.list_0[this.int_0];
			this.chkGraph1.Checked = gclass.list_2[this.int_0][0];
			this.chkGraph2.Checked = gclass.list_2[this.int_0][1];
			this.chkGraph3.Checked = gclass.list_2[this.int_0][2];
			this.chkGraph4.Checked = gclass.list_2[this.int_0][3];
		}
		catch (Exception)
		{
			GClass3.smethod_2("ERROR: Empty graph parameter!", 1);
		}
		this.lblValue.Text = string.Empty;
	}

	// Token: 0x060000CE RID: 206 RVA: 0x00022CBC File Offset: 0x00020EBC
	private void GClass15_Paint(object sender, PaintEventArgs e)
	{
		GClass0 gclass = GClass3.smethod_0();
		if (gclass != null && gclass.list_0.Count > this.int_0 && gclass.list_0[this.int_0] != null)
		{
			try
			{
				bool flag = gclass.list_8[this.int_0].string_2.StartsWith("num") || gclass.list_8[this.int_0].string_2.StartsWith("equ");
				this.chkGraph1.Visible = (gclass.int_2 > 0 && flag);
				this.chkGraph2.Visible = (gclass.int_2 > 1 && flag);
				this.chkGraph3.Visible = (gclass.int_2 > 2 && flag);
				this.chkGraph4.Visible = (gclass.int_2 > 3 && flag);
				if (!flag)
				{
					gclass.list_2[this.int_0][0] = false;
					gclass.list_2[this.int_0][1] = false;
					gclass.list_2[this.int_0][2] = false;
					gclass.list_2[this.int_0][3] = false;
				}
				if (gclass.list_8[this.int_0].bool_0)
				{
					this.lblValue.Text = gclass.list_8[this.int_0].method_0() + " " + gclass.list_1[this.int_0];
				}
				if (gclass != null && gclass.list_3.Count > 0 && flag)
				{
					this.lblMinValue.Text = GClass62.smethod_1("5002") + ": " + gclass.list_6[this.int_0];
					this.lblMaxValue.Text = GClass62.smethod_1("5003") + ": " + gclass.list_7[this.int_0];
				}
				else
				{
					this.lblMinValue.Text = string.Empty;
					this.lblMaxValue.Text = string.Empty;
				}
			}
			catch (Exception)
			{
				GClass3.smethod_2("ERROR: Empty graph parameter! (1)", 1);
			}
		}
	}

	// Token: 0x060000CF RID: 207 RVA: 0x00022F28 File Offset: 0x00021128
	private void method_0()
	{
		this.lblParamName = new Label();
		this.lblValue = new Label();
		this.lblMinValue = new Label();
		this.lblMaxValue = new Label();
		this.chkGraph1 = new CheckBox();
		this.chkGraph2 = new CheckBox();
		this.chkGraph3 = new CheckBox();
		this.chkGraph4 = new CheckBox();
		base.SuspendLayout();
		this.lblParamName.AutoSize = true;
		this.lblParamName.Font = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.lblParamName.Location = new Point(2, 2);
		this.lblParamName.Name = "lblParamName";
		this.lblParamName.Size = new Size(208, 18);
		this.lblParamName.TabIndex = 0;
		this.lblParamName.Text = "Test Parameter";
		this.lblValue.AutoSize = true;
		this.lblValue.Font = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.lblValue.Location = new Point(2, 30);
		this.lblValue.Name = "lblValue";
		this.lblValue.Size = new Size(76, 17);
		this.lblValue.TabIndex = 0;
		this.lblValue.Text = "1000 RPM";
		this.lblMinValue.AutoSize = true;
		this.lblMinValue.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.lblMinValue.Location = new Point(122, 24);
		this.lblMinValue.Name = "lblMinValue";
		this.lblMinValue.Size = new Size(78, 13);
		this.lblMinValue.TabIndex = 0;
		this.lblMinValue.Text = "Min:  600 RPM";
		this.lblMaxValue.AutoSize = true;
		this.lblMaxValue.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.lblMaxValue.Location = new Point(122, 38);
		this.lblMaxValue.Name = "lblMaxValue";
		this.lblMaxValue.Size = new Size(78, 13);
		this.lblMaxValue.TabIndex = 0;
		this.lblMaxValue.Text = "Max: 1500 RPM";
		this.chkGraph1.AutoSize = true;
		this.chkGraph1.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.chkGraph1.Location = new Point(5, 54);
		this.chkGraph1.Name = "chkGraph1";
		this.chkGraph1.Size = new Size(38, 20);
		this.chkGraph1.TabIndex = 0;
		this.chkGraph1.Text = "1";
		this.chkGraph1.UseVisualStyleBackColor = true;
		this.chkGraph1.CheckedChanged += this.chkGraph1_CheckedChanged;
		this.chkGraph2.AutoSize = true;
		this.chkGraph2.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.chkGraph2.Location = new Point(45, 54);
		this.chkGraph2.Name = "chkGraph2";
		this.chkGraph2.Size = new Size(38, 20);
		this.chkGraph2.TabIndex = 0;
		this.chkGraph2.Text = "2";
		this.chkGraph2.UseVisualStyleBackColor = true;
		this.chkGraph2.CheckedChanged += this.chkGraph2_CheckedChanged;
		this.chkGraph3.AutoSize = true;
		this.chkGraph3.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.chkGraph3.Location = new Point(85, 54);
		this.chkGraph3.Name = "chkGraph3";
		this.chkGraph3.Size = new Size(38, 20);
		this.chkGraph3.TabIndex = 0;
		this.chkGraph3.Text = "3";
		this.chkGraph3.UseVisualStyleBackColor = true;
		this.chkGraph3.CheckedChanged += this.chkGraph3_CheckedChanged;
		this.chkGraph4.AutoSize = true;
		this.chkGraph4.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.chkGraph4.Location = new Point(125, 54);
		this.chkGraph4.Name = "chkGraph4";
		this.chkGraph4.Size = new Size(38, 20);
		this.chkGraph4.TabIndex = 0;
		this.chkGraph4.Text = "4";
		this.chkGraph4.UseVisualStyleBackColor = true;
		this.chkGraph4.CheckedChanged += this.chkGraph4_CheckedChanged;
		base.Controls.Add(this.lblParamName);
		base.Controls.Add(this.lblValue);
		base.Controls.Add(this.lblMinValue);
		base.Controls.Add(this.lblMaxValue);
		base.Controls.Add(this.chkGraph1);
		base.Controls.Add(this.chkGraph2);
		base.Controls.Add(this.chkGraph3);
		base.Controls.Add(this.chkGraph4);
		base.Paint += this.GClass15_Paint;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x000234D0 File Offset: 0x000216D0
	private void chkGraph1_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			GClass0 gclass = GClass3.smethod_0();
			if (gclass != null)
			{
				if (gclass.list_0.Count > this.int_0)
				{
					gclass.list_2[this.int_0][0] = this.chkGraph1.Checked;
					GClass3.bool_5 = true;
				}
			}
		}
		catch (Exception)
		{
			GClass3.smethod_2("ERROR: Empty graph parameter! (2)", 1);
		}
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x0002354C File Offset: 0x0002174C
	private void chkGraph2_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			GClass0 gclass = GClass3.smethod_0();
			if (gclass != null)
			{
				if (gclass.list_0.Count > this.int_0)
				{
					gclass.list_2[this.int_0][1] = this.chkGraph2.Checked;
					GClass3.bool_5 = true;
				}
			}
		}
		catch (Exception)
		{
			GClass3.smethod_2("ERROR: Empty graph parameter! (3)", 1);
		}
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x000235C8 File Offset: 0x000217C8
	private void chkGraph3_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			GClass0 gclass = GClass3.smethod_0();
			if (gclass != null)
			{
				if (gclass.list_0.Count > this.int_0)
				{
					gclass.list_2[this.int_0][2] = this.chkGraph3.Checked;
					GClass3.bool_5 = true;
				}
			}
		}
		catch (Exception)
		{
			GClass3.smethod_2("ERROR: Empty graph parameter! (4)", 1);
		}
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x00023644 File Offset: 0x00021844
	private void chkGraph4_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			GClass0 gclass = GClass3.smethod_0();
			if (gclass != null)
			{
				if (gclass.list_0.Count > this.int_0)
				{
					gclass.list_2[this.int_0][3] = this.chkGraph4.Checked;
					GClass3.bool_5 = true;
				}
			}
		}
		catch (Exception)
		{
			GClass3.smethod_2("ERROR: Empty graph parameter! (5)", 1);
		}
	}

	// Token: 0x040000D3 RID: 211
	private Label lblValue;

	// Token: 0x040000D4 RID: 212
	private Label lblMinValue;

	// Token: 0x040000D5 RID: 213
	private Label lblMaxValue;

	// Token: 0x040000D6 RID: 214
	private CheckBox chkGraph1;

	// Token: 0x040000D7 RID: 215
	private CheckBox chkGraph2;

	// Token: 0x040000D8 RID: 216
	private CheckBox chkGraph3;

	// Token: 0x040000D9 RID: 217
	private CheckBox chkGraph4;

	// Token: 0x040000DA RID: 218
	private Label lblParamName;

	// Token: 0x040000DB RID: 219
	private int int_0;
}
