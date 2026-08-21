using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

// Token: 0x02000092 RID: 146
public partial class GForm0 : Form
{
	// Token: 0x0600047C RID: 1148 RVA: 0x00003AA4 File Offset: 0x00001CA4
	private void button_0_Click(object sender, EventArgs e)
	{
		this.bool_0 = true;
		Thread.Sleep(50);
	}

	// Token: 0x0600047D RID: 1149 RVA: 0x000A38EC File Offset: 0x000A1AEC
	private void button_1_Click(object sender, EventArgs e)
	{
		this.textBox_1.Text = "";
		if (this.textBox_0.Text.Contains("[xx"))
		{
			this.string_0 = this.textBox_0.Text;
			this.bool_0 = false;
			this.button_1.Enabled = false;
			new Thread(new ThreadStart(this.method_0)).Start();
			return;
		}
		byte[] array = new byte[0];
		try
		{
			array = GClass127.smethod_32("00 " + this.textBox_0.Text);
			array[0] = (byte)(array.Length - 1);
		}
		catch (Exception)
		{
		}
		if (array.Length >= 2 && array.Length <= 255)
		{
			string text = this.gclass11_0.vmethod_0(array, "raw", 0, 1, new string[0], "hex");
			this.textBox_1.Text = text;
			return;
		}
		MessageBox.Show(GClass107.smethod_3(76790), GClass107.smethod_3(76808), MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	// Token: 0x0600047E RID: 1150 RVA: 0x00002F0A File Offset: 0x0000110A
	private void GForm0_FormClosing(object sender, FormClosingEventArgs e)
	{
	}

	// Token: 0x0600047F RID: 1151 RVA: 0x000A39F4 File Offset: 0x000A1BF4
	private void method_0()
	{
		byte[] array = new byte[0];
		try
		{
			int startIndex = this.string_0.IndexOf("[xx");
			string text = this.string_0.Substring(startIndex, 8);
			byte[] array2 = GClass127.smethod_32(text.Substring(3, 4));
			byte b = array2[0];
			while (b <= array2[1] && !this.bool_0)
			{
				string str = this.string_0.Replace(text, GClass127.smethod_23(b));
				array = GClass127.smethod_32("00 " + str);
				array[0] = (byte)(array.Length - 1);
				string text2 = this.gclass11_0.vmethod_0(array, "raw", 0, 1, new string[0], "hex");
				if (this.bool_0)
				{
					break;
				}
				base.Invoke(new GForm0.Delegate0(this.method_1), new object[]
				{
					text2
				});
				b += 1;
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(GClass107.smethod_3(76816) + ex.Message, 0);
		}
		base.Invoke(new GForm0.Delegate0(this.method_1), new object[]
		{
			GClass107.smethod_3(76843)
		});
	}

	// Token: 0x06000480 RID: 1152 RVA: 0x00003AB4 File Offset: 0x00001CB4
	public GForm0(GClass11 gclass11_1)
	{
		this.method_2();
		this.gclass11_0 = gclass11_1;
	}

	// Token: 0x06000481 RID: 1153 RVA: 0x00003ADB File Offset: 0x00001CDB
	private void method_1(string string_1)
	{
		this.textBox_1.Text = string_1;
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x00002F0A File Offset: 0x0000110A
	private void label_1_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x000A3B2C File Offset: 0x000A1D2C
	private void method_2()
	{
		this.textBox_0 = new TextBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.label_2 = new Label();
		this.textBox_1 = new TextBox();
		this.label_3 = new Label();
		base.SuspendLayout();
		this.textBox_0.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_0.Font = new Font(GClass107.smethod_3(78061), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.textBox_0.ForeColor = Color.Navy;
		this.textBox_0.Location = new Point(14, 99);
		this.textBox_0.Margin = new Padding(3, 4, 3, 4);
		this.textBox_0.Multiline = true;
		this.textBox_0.Name = GClass107.smethod_3(78103);
		this.textBox_0.ScrollBars = ScrollBars.Vertical;
		this.textBox_0.Size = new Size(814, 112);
		this.textBox_0.TabIndex = 0;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(701, 308);
		this.button_0.Margin = new Padding(3, 4, 3, 4);
		this.button_0.Name = GClass107.smethod_3(78107);
		this.button_0.Size = new Size(127, 34);
		this.button_0.TabIndex = 2;
		this.button_0.Tag = "8198";
		this.button_0.Text = GClass107.smethod_3(78147);
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Location = new Point(525, 308);
		this.button_1.Margin = new Padding(3, 4, 3, 4);
		this.button_1.Name = GClass107.smethod_3(78162);
		this.button_1.Size = new Size(170, 34);
		this.button_1.TabIndex = 5;
		this.button_1.Tag = "6002";
		this.button_1.Text = GClass107.smethod_3(78205);
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(17, 75);
		this.label_0.Name = GClass107.smethod_3(78229);
		this.label_0.Size = new Size(791, 20);
		this.label_0.TabIndex = 6;
		this.label_0.Text = GClass107.smethod_3(78266) + GClass107.smethod_3(78289);
		this.label_1.AutoSize = true;
		this.label_1.ForeColor = Color.Red;
		this.label_1.Location = new Point(17, 18);
		this.label_1.Name = GClass107.smethod_3(78307);
		this.label_1.Size = new Size(766, 20);
		this.label_1.TabIndex = 7;
		this.label_1.Text = GClass107.smethod_3(78319) + GClass107.smethod_3(78345);
		this.label_1.Click += this.label_1_Click;
		this.label_2.AutoSize = true;
		this.label_2.ForeColor = Color.Red;
		this.label_2.Location = new Point(17, 44);
		this.label_2.Name = GClass107.smethod_3(78371);
		this.label_2.Size = new Size(256, 20);
		this.label_2.TabIndex = 8;
		this.label_2.Text = GClass107.smethod_3(78398);
		this.textBox_1.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_1.Font = new Font(GClass107.smethod_3(78431), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.textBox_1.ForeColor = Color.Red;
		this.textBox_1.Location = new Point(13, 243);
		this.textBox_1.Margin = new Padding(3, 4, 3, 4);
		this.textBox_1.Multiline = true;
		this.textBox_1.Name = GClass107.smethod_3(78433);
		this.textBox_1.ScrollBars = ScrollBars.Vertical;
		this.textBox_1.Size = new Size(814, 57);
		this.textBox_1.TabIndex = 9;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(13, 219);
		this.label_3.Name = GClass107.smethod_3(78453);
		this.label_3.Size = new Size(230, 20);
		this.label_3.TabIndex = 10;
		this.label_3.Text = GClass107.smethod_3(78469);
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.AutoSize = true;
		base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		base.ClientSize = new Size(841, 355);
		base.ControlBox = false;
		base.Controls.Add(this.label_3);
		base.Controls.Add(this.textBox_1);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.textBox_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Margin = new Padding(3, 4, 3, 4);
		base.Name = GClass107.smethod_3(78483);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = GClass107.smethod_3(78516);
		base.FormClosing += this.GForm0_FormClosing;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x040002FC RID: 764
	private GClass11 gclass11_0;

	// Token: 0x040002FD RID: 765
	private string string_0 = "";

	// Token: 0x040002FE RID: 766
	private bool bool_0 = true;

	// Token: 0x04000300 RID: 768
	private TextBox textBox_0;

	// Token: 0x04000301 RID: 769
	private Button button_0;

	// Token: 0x04000302 RID: 770
	private Button button_1;

	// Token: 0x04000303 RID: 771
	private Label label_0;

	// Token: 0x04000304 RID: 772
	private Label label_1;

	// Token: 0x04000305 RID: 773
	private Label label_2;

	// Token: 0x04000306 RID: 774
	private TextBox textBox_1;

	// Token: 0x04000307 RID: 775
	private Label label_3;

	// Token: 0x02000093 RID: 147
	// (Invoke) Token: 0x06000486 RID: 1158
	private delegate void Delegate0(string message);
}
