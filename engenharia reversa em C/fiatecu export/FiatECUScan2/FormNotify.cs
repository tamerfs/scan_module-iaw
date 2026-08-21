using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000010 RID: 16
public sealed partial class FormNotify : Form
{
	// Token: 0x0600006A RID: 106 RVA: 0x0001CF54 File Offset: 0x0001B154
	public FormNotify(string string_3, string string_4, string string_5, bool bool_8, int int_2)
	{
		this.InitializeComponent();
		GClass3.bool_13 = false;
		GClass3.bool_14 = false;
		this.string_0 = string_3;
		this.string_1 = string_4;
		this.string_2 = string_5;
		this.bool_6 = string_4.Equals(GClass62.smethod_1("1052"));
		this.lblMessage2.Font = GClass61.smethod_18();
		this.lblMessage3.Font = GClass61.smethod_18();
		this.lblMessage1.Text = string_3;
		this.lblMessage2.Text = string_4 + (this.bool_6 ? " ..." : string.Empty);
		this.lblMessage3.Text = string_5;
		this.bool_3 = bool_8;
		this.int_1 = int_2;
		this.float_0 = this.lblMessage1.Font.Size;
		this.float_1 = this.lblMessage2.Font.Size;
		this.float_2 = this.lblMessage3.Font.Size;
		int num = Screen.PrimaryScreen.Bounds.Width;
		if (num < 640)
		{
			num = 640;
		}
		int num2 = (int)((double)num * 0.9);
		int num3 = (int)((double)num * 0.7);
		if (this.lblMessage1.Width > num2)
		{
			float num4 = (float)num2 / (float)this.lblMessage1.Width;
			this.lblMessage1.Font = new Font(this.lblMessage1.Font.FontFamily, this.float_0 * num4, FontStyle.Bold);
		}
		if (this.lblMessage2.Width > num2)
		{
			float num5 = (float)num2 / (float)this.lblMessage2.Width;
			this.lblMessage2.Font = new Font(this.lblMessage2.Font.FontFamily, this.float_1 * num5, FontStyle.Bold);
		}
		if (this.lblMessage3.Width > num2)
		{
			float num6 = (float)num2 / (float)this.lblMessage3.Width;
			this.lblMessage3.Font = new Font(this.lblMessage3.Font.FontFamily, this.float_2 * num6, FontStyle.Bold);
		}
		int num7 = this.lblMessage1.Width;
		if (this.lblMessage2.Width > num7)
		{
			num7 = this.lblMessage2.Width;
		}
		if (this.lblMessage3.Width > num7)
		{
			num7 = this.lblMessage3.Width;
		}
		num7 += 80;
		base.Width = ((num7 < num3) ? num3 : num7);
		this.lblMessage1.Location = new Point((this.panel1.Width - this.lblMessage1.Width) / 2, this.lblMessage1.Location.Y);
		this.lblMessage2.Location = new Point((this.panel1.Width - this.lblMessage2.Width) / 2, this.lblMessage2.Location.Y);
		this.lblMessage3.Location = new Point((this.panel1.Width - this.lblMessage3.Width) / 2, this.lblMessage3.Location.Y);
	}

	// Token: 0x0600006D RID: 109 RVA: 0x0001DC1C File Offset: 0x0001BE1C
	private void FormNotify_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.bool_0 = true;
			GClass3.bool_14 = true;
		}
		else if (e.KeyCode == Keys.Y && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.bool_1 = true;
			this.bool_2 = false;
			GClass3.bool_13 = true;
			if (this.bool_3)
			{
				base.DialogResult = DialogResult.OK;
			}
		}
		else if (e.KeyCode == Keys.N && !e.Alt && !e.Control)
		{
			e.Handled = true;
			this.bool_2 = true;
			this.bool_1 = false;
			if (this.bool_3)
			{
				base.DialogResult = DialogResult.OK;
			}
		}
	}

	// Token: 0x0600006E RID: 110 RVA: 0x00002849 File Offset: 0x00000A49
	public bool method_0()
	{
		return this.bool_0;
	}

	// Token: 0x0600006F RID: 111 RVA: 0x00002851 File Offset: 0x00000A51
	public bool method_1()
	{
		return this.bool_1;
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00002859 File Offset: 0x00000A59
	public bool method_2()
	{
		return this.bool_2;
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00002861 File Offset: 0x00000A61
	public void method_3(string string_3)
	{
		this.string_0 = string_3;
		this.bool_4 = true;
	}

	// Token: 0x06000072 RID: 114 RVA: 0x0001DCF0 File Offset: 0x0001BEF0
	public string method_4()
	{
		return this.string_0;
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00002871 File Offset: 0x00000A71
	public void method_5(string string_3)
	{
		this.string_1 = string_3;
		this.bool_5 = true;
	}

	// Token: 0x06000074 RID: 116 RVA: 0x0001DD08 File Offset: 0x0001BF08
	public string method_6()
	{
		return this.string_1;
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00002881 File Offset: 0x00000A81
	public void method_7(string string_3)
	{
		this.string_2 = string_3;
		this.bool_7 = true;
	}

	// Token: 0x06000076 RID: 118 RVA: 0x0001DD20 File Offset: 0x0001BF20
	public void method_8(string string_3, string string_4, string string_5, bool bool_8, int int_2)
	{
		base.Invoke(new FormNotify.Delegate0(this.method_9), new object[]
		{
			string_3,
			string_4,
			string_5,
			bool_8,
			int_2
		});
	}

	// Token: 0x06000077 RID: 119 RVA: 0x0001DD68 File Offset: 0x0001BF68
	public void method_9(string string_3, string string_4, string string_5, bool bool_8, int int_2)
	{
		this.string_0 = string_3;
		this.string_1 = string_4;
		this.string_2 = string_5;
		this.bool_6 = string_4.Equals(GClass62.smethod_1("1052"));
		this.lblMessage1.Text = string_3;
		this.lblMessage2.Text = string_4 + (this.bool_6 ? " ..." : string.Empty);
		this.lblMessage3.Text = string_5;
		this.bool_3 = bool_8;
		this.int_0 = 0;
		this.int_1 = int_2;
		this.bool_0 = false;
		this.bool_1 = false;
		this.bool_2 = false;
		GClass3.bool_13 = false;
		GClass3.bool_14 = false;
		int num = Screen.PrimaryScreen.Bounds.Width;
		if (num < 640)
		{
			num = 640;
		}
		int num2 = (int)((double)num * 0.9);
		int num3 = (int)((double)num * 0.7);
		if (this.lblMessage1.Width > num2)
		{
			float num4 = (float)num2 / (float)this.lblMessage1.Width;
			this.lblMessage1.Font = new Font(this.lblMessage1.Font.FontFamily, this.float_0 * num4, FontStyle.Bold);
		}
		if (this.lblMessage2.Width > num2)
		{
			float num5 = (float)num2 / (float)this.lblMessage2.Width;
			this.lblMessage2.Font = new Font(this.lblMessage2.Font.FontFamily, this.float_1 * num5, FontStyle.Bold);
		}
		if (this.lblMessage3.Width > num2)
		{
			float num6 = (float)num2 / (float)this.lblMessage3.Width;
			this.lblMessage3.Font = new Font(this.lblMessage3.Font.FontFamily, this.float_2 * num6, FontStyle.Bold);
		}
		int num7 = this.lblMessage1.Width;
		if (this.lblMessage2.Width > num7)
		{
			num7 = this.lblMessage2.Width;
		}
		if (this.lblMessage3.Width > num7)
		{
			num7 = this.lblMessage3.Width;
		}
		num7 += 80;
		base.Width = ((num7 < num3) ? num3 : num7);
		this.lblMessage1.Location = new Point((this.panel1.Width - this.lblMessage1.Width) / 2, this.lblMessage1.Location.Y);
		this.lblMessage2.Location = new Point((this.panel1.Width - this.lblMessage2.Width) / 2, this.lblMessage2.Location.Y);
		this.lblMessage3.Location = new Point((this.panel1.Width - this.lblMessage3.Width) / 2, this.lblMessage3.Location.Y);
	}

	// Token: 0x06000078 RID: 120 RVA: 0x0001E060 File Offset: 0x0001C260
	private void timer_0_Tick(object sender, EventArgs e)
	{
		this.int_0 += this.timer_0.Interval;
		if (this.int_1 > 0 && (this.int_0 > this.int_1 || this.bool_0))
		{
			base.Close();
		}
		if (base.Visible)
		{
			if (this.bool_6)
			{
				Label label = this.lblMessage2;
				label.Text += ".";
				if (this.lblMessage2.Text.Length > this.string_1.Length + 6)
				{
					this.lblMessage2.Text = this.string_1 + " .";
				}
			}
			if (this.bool_4)
			{
				this.lblMessage1.Text = this.string_0;
				this.lblMessage1.Location = new Point((this.panel1.Width - this.lblMessage1.Width) / 2, this.lblMessage1.Location.Y);
			}
			if (this.bool_5)
			{
				this.lblMessage2.Text = this.string_1;
				this.lblMessage2.Location = new Point((this.panel1.Width - this.lblMessage2.Width) / 2, this.lblMessage2.Location.Y);
			}
			if (this.bool_7)
			{
				this.lblMessage3.Text = this.string_2;
				this.lblMessage3.Location = new Point((this.panel1.Width - this.lblMessage3.Width) / 2, this.lblMessage3.Location.Y);
			}
		}
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00002891 File Offset: 0x00000A91
	private void btnLeft_Click(object sender, EventArgs e)
	{
		this.bool_2 = true;
		this.bool_1 = false;
		if (this.bool_3)
		{
			base.DialogResult = DialogResult.OK;
		}
	}

	// Token: 0x0600007A RID: 122 RVA: 0x000028B3 File Offset: 0x00000AB3
	private void btnCenter_Click(object sender, EventArgs e)
	{
		this.bool_0 = true;
		GClass3.bool_14 = true;
	}

	// Token: 0x0600007B RID: 123 RVA: 0x000028C2 File Offset: 0x00000AC2
	private void btnRight_Click(object sender, EventArgs e)
	{
		this.bool_1 = true;
		this.bool_2 = false;
		GClass3.bool_13 = true;
		if (this.bool_3)
		{
			base.DialogResult = DialogResult.OK;
		}
	}

	// Token: 0x04000085 RID: 133
	private bool bool_0 = false;

	// Token: 0x04000086 RID: 134
	private bool bool_1 = false;

	// Token: 0x04000087 RID: 135
	private bool bool_2 = false;

	// Token: 0x04000088 RID: 136
	private bool bool_3 = false;

	// Token: 0x04000089 RID: 137
	private string string_0;

	// Token: 0x0400008A RID: 138
	private bool bool_4 = false;

	// Token: 0x0400008B RID: 139
	private string string_1;

	// Token: 0x0400008C RID: 140
	private bool bool_5 = false;

	// Token: 0x0400008D RID: 141
	private bool bool_6 = false;

	// Token: 0x0400008E RID: 142
	private string string_2;

	// Token: 0x0400008F RID: 143
	private bool bool_7 = false;

	// Token: 0x04000090 RID: 144
	private int int_0 = 0;

	// Token: 0x04000091 RID: 145
	private int int_1 = 0;

	// Token: 0x04000092 RID: 146
	private float float_0 = 0f;

	// Token: 0x04000093 RID: 147
	private float float_1 = 0f;

	// Token: 0x04000094 RID: 148
	private float float_2 = 0f;

	// Token: 0x02000011 RID: 17
	// (Invoke) Token: 0x0600007D RID: 125
	private delegate void Delegate0(string string_0, string string_1, string string_2, bool bool_0, int int_0);
}
