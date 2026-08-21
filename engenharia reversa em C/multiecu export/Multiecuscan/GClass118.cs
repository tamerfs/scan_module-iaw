using System;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x020000BE RID: 190
public class GClass118 : Panel
{
	// Token: 0x06000643 RID: 1603 RVA: 0x0000458D File Offset: 0x0000278D
	public GClass118()
	{
		this.method_0();
	}

	// Token: 0x06000644 RID: 1604 RVA: 0x000E03A0 File Offset: 0x000DE5A0
	public GClass118(int int_1)
	{
		this.int_0 = int_1;
		this.method_0();
		try
		{
			GClass105 gclass = GClass126.smethod_0();
			this.lblParamName.Text = gclass.list_0[this.int_0];
			this.chkGraph1.Checked = gclass.list_2[this.int_0][0];
			this.chkGraph2.Checked = gclass.list_2[this.int_0][1];
			this.chkGraph3.Checked = gclass.list_2[this.int_0][2];
			this.chkGraph4.Checked = gclass.list_2[this.int_0][3];
			this.cbPriority.SelectedItem = (gclass.list_8[this.int_0].int_3.ToString() ?? "");
		}
		catch (Exception)
		{
			GClass126.smethod_2("ERROR: Empty graph parameter!", 1);
		}
		this.lblValue.Text = "";
	}

	// Token: 0x06000645 RID: 1605 RVA: 0x000E04C0 File Offset: 0x000DE6C0
	private void GClass118_Paint(object sender, PaintEventArgs e)
	{
		GClass105 gclass = GClass126.smethod_0();
		if (gclass == null)
		{
			return;
		}
		if (gclass.list_0.Count <= this.int_0)
		{
			return;
		}
		if (gclass.list_0[this.int_0] == null)
		{
			return;
		}
		try
		{
			bool flag = gclass.list_8[this.int_0].string_2.StartsWith("num") || gclass.list_8[this.int_0].string_2.StartsWith("equ") || gclass.list_8[this.int_0].string_2.StartsWith("cond") || gclass.list_8[this.int_0].string_2.StartsWith("nm") || gclass.list_8[this.int_0].string_2.StartsWith("bn1") || gclass.list_8[this.int_0].string_2.StartsWith("bn3");
			this.chkGraph1.Visible = (gclass.int_2 > 0 && flag);
			this.chkGraph2.Visible = (gclass.int_2 > 1 && flag);
			this.chkGraph3.Visible = (gclass.int_2 > 2 && flag);
			this.chkGraph4.Visible = (gclass.int_2 > 3 && flag);
			if (this.bool_0 == GClass126.bool_12)
			{
				this.bool_0 = !GClass126.bool_12;
				this.cbPriority.Enabled = this.bool_0;
			}
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
				this.lblMinValue.Text = GClass121.smethod_6("5002") + ": " + gclass.list_6[this.int_0];
				this.lblMaxValue.Text = GClass121.smethod_6("5003") + ": " + gclass.list_7[this.int_0];
			}
			else
			{
				this.lblMinValue.Text = "";
				this.lblMaxValue.Text = "";
			}
		}
		catch (Exception)
		{
			GClass126.smethod_2("ERROR: Empty graph parameter! (1)", 1);
		}
	}

	// Token: 0x06000646 RID: 1606 RVA: 0x000E07C8 File Offset: 0x000DE9C8
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
		this.cbPriority = new ComboBox();
		base.SuspendLayout();
		this.lblParamName.AutoSize = true;
		this.lblParamName.Font = new Font(GClass125.smethod_28().FontFamily, 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.lblParamName.Location = new Point(2, 2);
		this.lblParamName.Name = "lblParamName";
		this.lblParamName.Size = new Size(208, 18);
		this.lblParamName.TabIndex = 0;
		this.lblParamName.Text = "Test Parameter";
		this.lblValue.AutoSize = true;
		this.lblValue.Font = new Font(GClass125.smethod_28().FontFamily, 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.lblValue.Location = new Point(2, 30);
		this.lblValue.Name = "lblValue";
		this.lblValue.Size = new Size(76, 17);
		this.lblValue.TabIndex = 0;
		this.lblValue.Text = "1000 RPM";
		this.lblMinValue.AutoSize = true;
		this.lblMinValue.Font = new Font(GClass125.smethod_28().FontFamily, 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.lblMinValue.Location = new Point(122, 24);
		this.lblMinValue.Name = "lblMinValue";
		this.lblMinValue.Size = new Size(78, 13);
		this.lblMinValue.TabIndex = 0;
		this.lblMinValue.Text = "Min:  600 RPM";
		this.lblMaxValue.AutoSize = true;
		this.lblMaxValue.Font = new Font(GClass125.smethod_28().FontFamily, 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.lblMaxValue.Location = new Point(122, 38);
		this.lblMaxValue.Name = "lblMaxValue";
		this.lblMaxValue.Size = new Size(78, 13);
		this.lblMaxValue.TabIndex = 0;
		this.lblMaxValue.Text = "Max: 1500 RPM";
		this.chkGraph1.AutoSize = true;
		this.chkGraph1.Font = new Font(GClass125.smethod_28().FontFamily, 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.chkGraph1.Location = new Point(5, 54);
		this.chkGraph1.Name = "chkGraph1";
		this.chkGraph1.Size = new Size(38, 20);
		this.chkGraph1.TabIndex = 0;
		this.chkGraph1.Text = "1";
		this.chkGraph1.UseVisualStyleBackColor = true;
		this.chkGraph1.CheckedChanged += this.chkGraph1_CheckedChanged;
		this.chkGraph2.AutoSize = true;
		this.chkGraph2.Font = new Font(GClass125.smethod_28().FontFamily, 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.chkGraph2.Location = new Point(45, 54);
		this.chkGraph2.Name = "chkGraph2";
		this.chkGraph2.Size = new Size(38, 20);
		this.chkGraph2.TabIndex = 0;
		this.chkGraph2.Text = "2";
		this.chkGraph2.UseVisualStyleBackColor = true;
		this.chkGraph2.CheckedChanged += this.chkGraph2_CheckedChanged;
		this.chkGraph3.AutoSize = true;
		this.chkGraph3.Font = new Font(GClass125.smethod_28().FontFamily, 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.chkGraph3.Location = new Point(85, 54);
		this.chkGraph3.Name = "chkGraph3";
		this.chkGraph3.Size = new Size(38, 20);
		this.chkGraph3.TabIndex = 0;
		this.chkGraph3.Text = "3";
		this.chkGraph3.UseVisualStyleBackColor = true;
		this.chkGraph3.CheckedChanged += this.chkGraph3_CheckedChanged;
		this.chkGraph4.AutoSize = true;
		this.chkGraph4.Font = new Font(GClass125.smethod_28().FontFamily, 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.chkGraph4.Location = new Point(125, 54);
		this.chkGraph4.Name = "chkGraph4";
		this.chkGraph4.Size = new Size(38, 20);
		this.chkGraph4.TabIndex = 0;
		this.chkGraph4.Text = "4";
		this.chkGraph4.UseVisualStyleBackColor = true;
		this.chkGraph4.CheckedChanged += this.chkGraph4_CheckedChanged;
		this.cbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cbPriority.Font = new Font(GClass125.smethod_28().FontFamily, 5f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.cbPriority.FormattingEnabled = true;
		this.cbPriority.Items.AddRange(new object[]
		{
			"1",
			"2",
			"5",
			"10",
			"20"
		});
		this.cbPriority.Location = new Point(165, 54);
		this.cbPriority.Name = "cbPriority";
		this.cbPriority.Size = new Size(45, 20);
		this.cbPriority.TabIndex = 0;
		this.cbPriority.FlatStyle = FlatStyle.Flat;
		this.cbPriority.BackColor = Color.FromArgb(248, 248, 168);
		this.cbPriority.Tag = "";
		this.cbPriority.SelectedIndexChanged += this.cbPriority_SelectedIndexChanged;
		base.Controls.Add(this.lblParamName);
		base.Controls.Add(this.lblValue);
		base.Controls.Add(this.lblMinValue);
		base.Controls.Add(this.lblMaxValue);
		base.Controls.Add(this.chkGraph1);
		base.Controls.Add(this.chkGraph2);
		base.Controls.Add(this.chkGraph3);
		base.Controls.Add(this.chkGraph4);
		base.Controls.Add(this.cbPriority);
		base.Paint += this.GClass118_Paint;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x06000647 RID: 1607 RVA: 0x000E0EC8 File Offset: 0x000DF0C8
	private void chkGraph1_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			GClass105 gclass = GClass126.smethod_0();
			if (gclass != null)
			{
				if (gclass.list_0.Count > this.int_0)
				{
					gclass.list_2[this.int_0][0] = this.chkGraph1.Checked;
					GClass126.bool_14 = true;
				}
			}
		}
		catch (Exception)
		{
			GClass126.smethod_2("ERROR: Empty graph parameter! (2)", 1);
		}
	}

	// Token: 0x06000648 RID: 1608 RVA: 0x000E0F3C File Offset: 0x000DF13C
	private void chkGraph2_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			GClass105 gclass = GClass126.smethod_0();
			if (gclass != null)
			{
				if (gclass.list_0.Count > this.int_0)
				{
					gclass.list_2[this.int_0][1] = this.chkGraph2.Checked;
					GClass126.bool_14 = true;
				}
			}
		}
		catch (Exception)
		{
			GClass126.smethod_2("ERROR: Empty graph parameter! (3)", 1);
		}
	}

	// Token: 0x06000649 RID: 1609 RVA: 0x000E0FB0 File Offset: 0x000DF1B0
	private void chkGraph3_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			GClass105 gclass = GClass126.smethod_0();
			if (gclass != null)
			{
				if (gclass.list_0.Count > this.int_0)
				{
					gclass.list_2[this.int_0][2] = this.chkGraph3.Checked;
					GClass126.bool_14 = true;
				}
			}
		}
		catch (Exception)
		{
			GClass126.smethod_2("ERROR: Empty graph parameter! (4)", 1);
		}
	}

	// Token: 0x0600064A RID: 1610 RVA: 0x000E1024 File Offset: 0x000DF224
	private void chkGraph4_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			GClass105 gclass = GClass126.smethod_0();
			if (gclass != null)
			{
				if (gclass.list_0.Count > this.int_0)
				{
					gclass.list_2[this.int_0][3] = this.chkGraph4.Checked;
					GClass126.bool_14 = true;
				}
			}
		}
		catch (Exception)
		{
			GClass126.smethod_2("ERROR: Empty graph parameter! (5)", 1);
		}
	}

	// Token: 0x0600064B RID: 1611 RVA: 0x000E1098 File Offset: 0x000DF298
	private void cbPriority_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			GClass105 gclass = GClass126.smethod_0();
			if (gclass != null)
			{
				if (gclass.list_0.Count > this.int_0)
				{
					gclass.list_8[this.int_0].int_3 = Convert.ToInt32(this.cbPriority.SelectedItem.ToString());
				}
			}
		}
		catch (Exception)
		{
			GClass126.smethod_2("ERROR: Empty graph parameter! (6)", 1);
		}
	}

	// Token: 0x0400058B RID: 1419
	private Label lblValue;

	// Token: 0x0400058C RID: 1420
	private Label lblMinValue;

	// Token: 0x0400058D RID: 1421
	private Label lblMaxValue;

	// Token: 0x0400058E RID: 1422
	private CheckBox chkGraph1;

	// Token: 0x0400058F RID: 1423
	private CheckBox chkGraph2;

	// Token: 0x04000590 RID: 1424
	private CheckBox chkGraph3;

	// Token: 0x04000591 RID: 1425
	private CheckBox chkGraph4;

	// Token: 0x04000592 RID: 1426
	private Label lblParamName;

	// Token: 0x04000593 RID: 1427
	private ComboBox cbPriority;

	// Token: 0x04000594 RID: 1428
	private bool bool_0 = true;

	// Token: 0x04000595 RID: 1429
	private int int_0;
}
