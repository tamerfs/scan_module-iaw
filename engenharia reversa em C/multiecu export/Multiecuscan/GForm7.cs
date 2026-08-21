using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PdfSharp.Pdf;

// Token: 0x0200009A RID: 154
public partial class GForm7 : Form
{
	// Token: 0x060004BE RID: 1214 RVA: 0x000A9E38 File Offset: 0x000A8038
	private void method_0()
	{
		this.bool_2 = false;
		GClass126.smethod_2("", 2);
		GClass126.smethod_2(GClass121.smethod_6("3050") + "...", 2);
		GClass126.smethod_2("", 2);
		this.string_0 = string.Concat(new string[]
		{
			this.string_0,
			Environment.NewLine,
			Environment.NewLine,
			Environment.NewLine,
			Environment.NewLine,
			Environment.NewLine,
			GClass121.smethod_6("3050"),
			Environment.NewLine,
			Environment.NewLine
		});
		this.bool_0 = false;
		for (int i = 0; i < this.list_0.Count; i++)
		{
			GClass100 gclass = this.list_0[i];
			this.string_0 = this.string_0 + gclass.string_2 + Environment.NewLine;
			this.bool_0 = false;
			GClass126.smethod_2(gclass.string_2, 2);
			this.int_0 = i;
			if (this.bool_1)
			{
				this.bool_2 = true;
				return;
			}
			GClass11 gclass2 = GClass11.smethod_0(gclass.string_3, gclass.string_4, gclass.byte_0, new List<GClass104>(), new List<GClass104>(), gclass.string_5, null);
			if (gclass2 != null)
			{
				if (gclass.string_3 == GClass107.smethod_3(93195) || gclass.string_3 == GClass107.smethod_3(93233) || gclass.string_3 == GClass107.smethod_3(93270) || gclass.string_3 == GClass107.smethod_3(93271) || GClass125.smethod_44() == 6 || GClass125.smethod_44() == 7 || GClass125.smethod_46())
				{
					for (int j = 0; j < 20; j++)
					{
						Thread.Sleep(100);
						if (this.bool_1)
						{
							this.bool_2 = true;
							return;
						}
					}
				}
				gclass2.method_1();
				if (gclass2.method_12() != null && gclass2.method_12().Count > 0)
				{
					GClass126.smethod_2(GClass121.smethod_6("1093"), 2);
					this.string_0 = this.string_0 + GClass121.smethod_6("1093") + Environment.NewLine;
					GClass126.smethod_2(GClass121.smethod_6("1210"), 2);
					this.string_0 = this.string_0 + GClass121.smethod_6("1210") + Environment.NewLine;
					foreach (GClass102 gclass3 in gclass2.method_12())
					{
						GClass126.smethod_2(gclass3.string_2, 2);
						this.string_0 = this.string_0 + gclass3.string_2 + Environment.NewLine;
					}
					GClass126.smethod_2("", 2);
					this.bool_0 = false;
				}
				else
				{
					GClass126.smethod_2(GClass121.smethod_6("1092"), 2);
					GClass126.smethod_2("", 2);
					this.string_0 = this.string_0 + GClass121.smethod_6("1092") + Environment.NewLine;
					this.bool_0 = false;
				}
				this.string_0 += Environment.NewLine;
				if (this.bool_1)
				{
					this.bool_2 = true;
					return;
				}
			}
		}
		if (!this.bool_1)
		{
			this.string_0 = this.string_0 + GClass121.smethod_6("6051") + Environment.NewLine;
		}
		else
		{
			this.string_0 = this.string_0 + GClass121.smethod_6("6082") + Environment.NewLine;
		}
		this.bool_0 = false;
		this.int_0++;
		this.bool_2 = true;
		base.Invoke(new GForm7.Delegate2(this.method_1));
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x000AA204 File Offset: 0x000A8404
	private void panel_0_Click(object sender, EventArgs e)
	{
		if (!this.panel_0.Visible)
		{
			return;
		}
		GClass126.smethod_2(GClass107.smethod_3(93278), 0);
		PdfDocument pdfDocument = new GClass129().method_1(GClass126.stringBuilder_1);
		string str = GClass125.smethod_30() + GClass107.smethod_3(93316);
		string text = "";
		int num = 1;
		while (num < 10 && text == "")
		{
			try
			{
				text = str + num.ToString() + GClass107.smethod_3(93349);
				GClass126.smethod_2(GClass107.smethod_3(93380), 0);
				pdfDocument.Save(text);
				num = 100;
			}
			catch (Exception)
			{
				num++;
				text = "";
			}
		}
		if (text == "")
		{
			MessageBox.Show(GClass107.smethod_3(93394), GClass107.smethod_3(93442), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		try
		{
			Process.Start(GClass107.smethod_3(93488), text);
		}
		catch (Exception)
		{
			MessageBox.Show(GClass107.smethod_3(93495), GClass107.smethod_3(93530), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	// Token: 0x060004C0 RID: 1216 RVA: 0x00003D06 File Offset: 0x00001F06
	private void method_1()
	{
		this.button_0.Text = GClass121.smethod_6("8199");
		this.gclass109_0.Visible = false;
		this.panel_0.Visible = true;
		this.button_1.Visible = this.bool_6;
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x000AA330 File Offset: 0x000A8530
	private void method_2()
	{
		try
		{
			string text = GClass107.smethod_3(92989) + DateTime.Now.ToString(GClass107.smethod_3(93000)) + GClass107.smethod_3(93024);
			text = text.Replace("/", "").Replace("\\", "");
			FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(GClass107.smethod_3(93035) + text);
			ftpWebRequest.Method = "STOR";
			ftpWebRequest.Credentials = new NetworkCredential(GClass107.smethod_3(93037), GClass107.smethod_3(93037));
			Stream requestStream = ftpWebRequest.GetRequestStream();
			try
			{
				GClass126.smethod_2(GClass107.smethod_3(93076), 2);
				GClass126.smethod_2(GClass107.smethod_3(93090), 2);
				GClass126.smethod_2(GClass107.smethod_3(93101), 2);
				GClass126.smethod_2(this.string_0, 2);
				byte[] bytes = Encoding.Unicode.GetBytes(GClass126.smethod_7());
				requestStream.Write(bytes, 0, bytes.Length);
				GClass126.smethod_6();
				this.string_0 = this.string_0 + GClass121.smethod_6("1092") + Environment.NewLine;
			}
			finally
			{
				requestStream.Close();
			}
		}
		catch (Exception ex)
		{
			this.string_0 = this.string_0 + GClass121.smethod_6("1080") + Environment.NewLine;
			GClass126.smethod_2(GClass107.smethod_3(93148) + ex.Message, 0);
		}
		this.bool_0 = false;
		base.Invoke(new GForm7.Delegate1(this.method_3));
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x00003D46 File Offset: 0x00001F46
	private void method_3()
	{
		if (GClass126.smethod_8() > 10)
		{
			this.button_1.Visible = true;
		}
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x000AA4F0 File Offset: 0x000A86F0
	private void button_1_Click(object sender, EventArgs e)
	{
		GForm5 gform = new GForm5();
		if (gform.ShowDialog() == DialogResult.OK)
		{
			this.button_1.Visible = false;
			this.string_0 = this.string_0 + GClass107.smethod_3(92860) + gform.method_1() + Environment.NewLine;
			this.string_0 = this.string_0 + GClass107.smethod_3(92907) + gform.method_2() + Environment.NewLine;
			this.string_0 = this.string_0 + GClass107.smethod_3(92951) + gform.method_3() + Environment.NewLine;
			this.string_0 += Environment.NewLine;
			this.string_0 = this.string_0 + GClass121.smethod_6("1079") + GClass107.smethod_3(92965) + Environment.NewLine;
			this.bool_0 = false;
			new Thread(new ThreadStart(this.method_2)).Start();
		}
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x000AA5EC File Offset: 0x000A87EC
	private void button_2_Click(object sender, EventArgs e)
	{
		this.button_0.Text = GClass121.smethod_6("8198");
		this.button_2.Visible = false;
		this.bool_6 = this.button_1.Visible;
		this.button_1.Visible = false;
		this.panel_0.Visible = false;
		this.gclass109_0.Value = 0;
		this.int_0 = 0;
		this.gclass109_0.Maximum = this.list_0.Count;
		this.int_1 = this.list_0.Count;
		this.gclass109_0.Visible = true;
		if (this.list_0.Count > 0)
		{
			new Thread(new ThreadStart(this.method_0)).Start();
		}
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x000AA6B0 File Offset: 0x000A88B0
	private void GForm7_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!this.bool_2)
		{
			this.string_0 = this.string_0 + GClass121.smethod_6("6081") + Environment.NewLine;
			this.bool_0 = false;
		}
		else
		{
			GClass126.smethod_12();
		}
		this.bool_1 = true;
		GClass126.bool_25 = true;
		this.bool_3 = true;
		int num = 10;
		while (num > 0 && !this.bool_2)
		{
			Thread.Sleep(100);
			num--;
		}
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x000AA724 File Offset: 0x000A8924
	private void method_4()
	{
		this.button_0.Text = GClass121.smethod_6("8199");
		this.int_0 = 0;
		this.gclass109_0.Value = 0;
		this.gclass109_0.Visible = false;
		this.button_1.Visible = true;
		this.panel_0.Visible = true;
		this.button_2.Visible = (this.list_0.Count > 0);
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x000AA798 File Offset: 0x000A8998
	private void GForm7_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && !e.Alt && !e.Control)
		{
			if (this.button_0.Enabled)
			{
				base.Close();
			}
			e.Handled = true;
			return;
		}
		if (e.KeyCode == Keys.F10 && !e.Alt && !e.Control)
		{
			if (this.button_2.Enabled && this.button_2.Visible)
			{
				this.button_2_Click(null, null);
			}
			e.Handled = true;
		}
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x00002F0A File Offset: 0x0000110A
	private void button_0_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x060004C9 RID: 1225 RVA: 0x000AA820 File Offset: 0x000A8A20
	private void method_5()
	{
		List<GClass100> list = new List<GClass100>();
		List<GClass104> list2 = new List<GClass104>();
		List<GClass104> list3 = new List<GClass104>();
		List<GClass104> list4 = new List<GClass104>();
		List<GClass104> list5 = new List<GClass104>();
		List<GClass104> list6 = new List<GClass104>();
		List<GClass104> list7 = new List<GClass104>();
		List<GClass104> list8 = new List<GClass104>();
		GClass126.smethod_5();
		GClass126.smethod_2(this.Text + "...", 2);
		GClass126.smethod_2("", 2);
		if (GClass126.bool_19)
		{
			this.string_0 = this.string_0 + GClass107.smethod_3(93572) + Environment.NewLine;
		}
		this.string_0 = this.string_0 + GClass121.smethod_6("8303") + Environment.NewLine;
		this.bool_0 = false;
		try
		{
			GClass96.smethod_5(GClass107.smethod_3(93586));
			if (GClass125.smethod_44() != 0)
			{
				try
				{
					this.string_0 += GClass125.string_1[GClass125.smethod_44()];
					if (GClass125.smethod_47())
					{
						this.string_0 = this.string_0 + GClass107.smethod_3(93615) + GClass125.smethod_55();
					}
					else if (GClass125.smethod_52())
					{
						this.string_0 += GClass107.smethod_3(93619);
					}
					this.string_0 = this.string_0 + Environment.NewLine + Environment.NewLine;
					this.bool_0 = false;
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception ex)
		{
			this.bool_2 = true;
			this.string_0 += GClass107.smethod_3(93629);
			this.bool_0 = false;
			GClass126.smethod_2(GClass107.smethod_3(93655) + ex.Message, 0);
			if (!this.bool_3)
			{
				base.Invoke(new GForm7.Delegate3(this.method_4));
			}
			return;
		}
		this.string_0 = this.string_0 + GClass121.smethod_6("1099") + Environment.NewLine + Environment.NewLine;
		this.bool_0 = false;
		if (GClass125.smethod_49() && !GClass126.bool_0)
		{
			for (int i = 0; i < 20; i++)
			{
				if (this.bool_1)
				{
					this.bool_2 = true;
					return;
				}
				Thread.Sleep(100);
			}
			GClass96.smethod_6();
		}
		if ((GClass125.smethod_44() == 4 || GClass125.smethod_44() == 5 || GClass125.smethod_44() == 10) && !GClass126.bool_0)
		{
			if (GClass125.smethod_44() == 5 || GClass125.smethod_44() == 10)
			{
				for (int j = 0; j < 30; j++)
				{
					if (this.bool_1)
					{
						this.bool_2 = true;
						return;
					}
					Thread.Sleep(100);
				}
			}
			if (!GClass96.smethod_3())
			{
				GClass126.bool_24 = false;
				this.bool_4 = true;
				int num = 1200;
				while (!GClass126.bool_24 && num > 0 && !this.bool_1)
				{
					num--;
					Thread.Sleep(100);
				}
				if (num == 0 || this.bool_1)
				{
					return;
				}
				GClass126.bool_24 = false;
				GClass96.smethod_1(true);
				int num2 = 10;
				if (GClass125.smethod_44() == 5 || GClass125.smethod_44() == 10)
				{
					num2 = 40;
				}
				for (int k = 0; k < num2; k++)
				{
					if (this.bool_1)
					{
						this.bool_2 = true;
						return;
					}
					Thread.Sleep(100);
				}
			}
		}
		for (int l = 0; l < 5; l++)
		{
			if (this.bool_1)
			{
				this.bool_2 = true;
				return;
			}
			Thread.Sleep(100);
		}
		list.Add(new GClass100("", "CANSCAN29", 0, "CCAN29", "6E", "", "[0]"));
		list.Add(new GClass100("", "CANSCAN29", 0, "CCAN29", "CD", "", "[0][3]"));
		list.Add(new GClass100("", "CANSCAN29", 0, "BCAN29", "19", "", "[0][2][CT3]"));
		list.Add(new GClass100("", "CANSCAN29", 0, "BCAN29", "6E", "", "[0][1]"));
		list.Add(new GClass100("", "CANSCAN29", 0, "BHCAN29", "3B", "", "[0][6][CT3]"));
		list.Add(new GClass100("", "CANSCANPN", 0, "CCANPN", "6E", "", "[0]"));
		list.Add(new GClass100("", "CANSCANPN", 0, "BHCANPN", "3B", "", "[0][CT4]"));
		list.Add(new GClass100(GClass121.smethod_6("1101"), "KWP2000Fast", 16, "", "70", "", "[0][1][9]"));
		list.Add(new GClass100(GClass121.smethod_6("1101"), "KWP2000Fast", 10, "", "70", "", "[0][1][9]"));
		list.Add(new GClass100(GClass121.smethod_6("1105"), "KWP2000Fast", 33, "111", "70", "", "[0][9]"));
		list.Add(new GClass100(GClass121.smethod_6("1107"), "KWP2000Fast", 90, "111", "70", "", "[0][9]"));
		list.Add(new GClass100(GClass121.smethod_6("1110"), "KWP2000Fast", 153, "000", "70", "", "[9]"));
		list.Add(new GClass100(GClass121.smethod_6("1104"), "KWP2000Fast", 49, "000", "70", "", "[9]"));
		list.Add(new GClass100(GClass121.smethod_6("1102"), "KWP2000Fast", 41, "000", "70", "", "[9]"));
		list.Add(new GClass100(GClass121.smethod_6("1103"), "KWP2000Fast", 89, "000", "70", "", "[9]"));
		list.Add(new GClass100(GClass121.smethod_6("1101"), GClass107.smethod_3(93704), 16, "F1", "6E", "ECM", GClass107.smethod_3(93709)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(93731), 96, "F1", "6E", GClass107.smethod_3(93734), GClass107.smethod_3(93770)));
		list.Add(new GClass100(GClass121.smethod_6("1101"), GClass107.smethod_3(93795), 16, GClass107.smethod_3(93839), "6E", GClass107.smethod_3(93844), GClass107.smethod_3(93852)));
		list.Add(new GClass100(GClass121.smethod_6("1101"), GClass107.smethod_3(93878), 16, GClass107.smethod_3(93898), "6E", GClass107.smethod_3(93900), GClass107.smethod_3(93934)));
		list.Add(new GClass100(GClass121.smethod_6("1107"), GClass107.smethod_3(93974), 64, "F1", "19", GClass107.smethod_3(93997), GClass107.smethod_3(94019)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(94054), 11, GClass107.smethod_3(94099), "3B", GClass107.smethod_3(94121), GClass107.smethod_3(94123)));
		list.Add(new GClass100(GClass121.smethod_6("1110"), GClass107.smethod_3(94166), 11, "783503", "3B", GClass107.smethod_3(94211), GClass107.smethod_3(94253)));
		list.Add(new GClass100(GClass121.smethod_6("1110"), GClass107.smethod_3(94287), 11, GClass107.smethod_3(94333), "3B", GClass107.smethod_3(94351), GClass107.smethod_3(94368)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(94394), 135, "F1", "3B", GClass107.smethod_3(94426), GClass107.smethod_3(94472)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(94495), 106, "F1", "3B", GClass107.smethod_3(94528), GClass107.smethod_3(94571)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(94609), 130, "F1", "3B", GClass107.smethod_3(94620), GClass107.smethod_3(94663)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(94688), 99, "F1", "3B", GClass107.smethod_3(94724), GClass107.smethod_3(94726)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(94752), 97, "F1", "3B", GClass107.smethod_3(94765), GClass107.smethod_3(94798)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(94823), 133, "F1", "3B", GClass107.smethod_3(94828), GClass107.smethod_3(94872)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(94919), 138, "F1", "3B", GClass107.smethod_3(94931), GClass107.smethod_3(94948)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(94960), 217, "F1", "3B", GClass107.smethod_3(94981), GClass107.smethod_3(95010)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(95043), 131, "F1", "3B", GClass107.smethod_3(95074), GClass107.smethod_3(95082)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(95114), 139, "F1", "3B", GClass107.smethod_3(95119), GClass107.smethod_3(95131)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(95169), 50, "F1", "3B", GClass107.smethod_3(95176), GClass107.smethod_3(95194)));
		list.Add(new GClass100(GClass121.smethod_6("1110"), GClass107.smethod_3(95202), 152, "F1", "3B", GClass107.smethod_3(95220), GClass107.smethod_3(95243)));
		list.Add(new GClass100(GClass121.smethod_6("1110"), GClass107.smethod_3(95254), 153, "F1", "3B", GClass107.smethod_3(95258), GClass107.smethod_3(95295)));
		list.Add(new GClass100(GClass121.smethod_6("1110"), GClass107.smethod_3(95303), 194, "F1", "3B", GClass107.smethod_3(95349), GClass107.smethod_3(95379)));
		list.Add(new GClass100(GClass121.smethod_6("1110"), GClass107.smethod_3(95409), 208, "F1", "3B", GClass107.smethod_3(95455), GClass107.smethod_3(95504)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(95548), 98, "F1", "3B", GClass107.smethod_3(95594), GClass107.smethod_3(95632)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(95642), 101, "F1", "3B", GClass107.smethod_3(95662), GClass107.smethod_3(95699)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(95739), 200, "F1", "3B", GClass107.smethod_3(95788), GClass107.smethod_3(95794)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(95795), 201, "F1", "3B", GClass107.smethod_3(95809), GClass107.smethod_3(95820)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(95838), 162, "F1", "3B", GClass107.smethod_3(95877), GClass107.smethod_3(95879)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(95914), 163, "F1", "3B", GClass107.smethod_3(95921), GClass107.smethod_3(95927)));
		list.Add(new GClass100(GClass121.smethod_6("1102"), GClass107.smethod_3(95959), 43, "F1", "3B", GClass107.smethod_3(95996), GClass107.smethod_3(96025)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(96058), 74, "F1", "3B", GClass107.smethod_3(96076), GClass107.smethod_3(96120)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(96131), 84, "F1", "3B", GClass107.smethod_3(96146), GClass107.smethod_3(96147)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(96155), 85, "F1", "3B", GClass107.smethod_3(96194), GClass107.smethod_3(96210)));
		list.Add(new GClass100(GClass121.smethod_6("1101"), "KWP2000Fast", 18, "", "70", "", "[0][1][3][CT2]"));
		list.Add(new GClass100(GClass121.smethod_6("1101"), "KWP2000Fast", 145, "", "70", "", "[0][1][3][CT2]"));
		list.Add(new GClass100(GClass121.smethod_6("1101"), GClass107.smethod_3(96246), 23, "F1", "6E", GClass107.smethod_3(96278), GClass107.smethod_3(96303)));
		list.Add(new GClass100(GClass121.smethod_6("1101"), GClass107.smethod_3(96332), 66, "F1", "6E", GClass107.smethod_3(96371), GClass107.smethod_3(96406)));
		list.Add(new GClass100(GClass121.smethod_6("1101"), GClass107.smethod_3(96426), 16, "F4", "6E", "ECM", "[0]"));
		list.Add(new GClass100(GClass121.smethod_6("1101"), GClass107.smethod_3(96448), 67, "F1", "6E", GClass107.smethod_3(96483), GClass107.smethod_3(96508)));
		list.Add(new GClass100(GClass121.smethod_6("1101"), GClass107.smethod_3(96556), 68, "F1", "6E", GClass107.smethod_3(96564), GClass107.smethod_3(96576)));
		list.Add(new GClass100(GClass121.smethod_6("1101"), GClass107.smethod_3(96584), 71, "F1", "6E", GClass107.smethod_3(96589), GClass107.smethod_3(96602)));
		list.Add(new GClass100(GClass121.smethod_6("1101"), GClass107.smethod_3(96645), 72, "F1", "6E", GClass107.smethod_3(96660), GClass107.smethod_3(96695)));
		list.Add(new GClass100(GClass121.smethod_6("1101"), GClass107.smethod_3(96718), 69, "F1", "6E", GClass107.smethod_3(96758), GClass107.smethod_3(96782)));
		list.Add(new GClass100(GClass121.smethod_6("1101"), GClass107.smethod_3(96830), 80, "F1", "6E", GClass107.smethod_3(96840), GClass107.smethod_3(96860)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(96871), 86, "F1", "6E", GClass107.smethod_3(96900), GClass107.smethod_3(96943)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(96992), 87, "F1", "6E", GClass107.smethod_3(96997), GClass107.smethod_3(97033)));
		list.Add(new GClass100(GClass121.smethod_6("1101"), GClass107.smethod_3(97066), 75, "F1", "6E", GClass107.smethod_3(97076), GClass107.smethod_3(97116)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(97130), 79, "F1", "6E", GClass107.smethod_3(97162), GClass107.smethod_3(97198)));
		list.Add(new GClass100(GClass121.smethod_6("1101"), GClass107.smethod_3(97237), 1, "F1", "6E", GClass107.smethod_3(97286), GClass107.smethod_3(97302)));
		list.Add(new GClass100(GClass121.smethod_6("1105"), "KWP2000Fast", 2, "", "70", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1105"), GClass107.smethod_3(97318), 24, "F1", "6E", GClass107.smethod_3(97353), GClass107.smethod_3(97374)));
		list.Add(new GClass100(GClass121.smethod_6("1105"), GClass107.smethod_3(97381), 25, "F1", "6E", GClass107.smethod_3(97419), GClass107.smethod_3(97441)));
		list.Add(new GClass100(GClass121.smethod_6("1105"), GClass107.smethod_3(97462), 26, "F1", "6E", GClass107.smethod_3(97472), GClass107.smethod_3(97512)));
		list.Add(new GClass100(GClass121.smethod_6("1105"), GClass107.smethod_3(97559), 33, "F1", "CD", GClass107.smethod_3(97581), GClass107.smethod_3(97617)));
		list.Add(new GClass100(GClass121.smethod_6("1105"), GClass107.smethod_3(97639), 32, "F1", "CD", GClass107.smethod_3(97655), GClass107.smethod_3(97680)));
		list.Add(new GClass100(GClass121.smethod_6("1105"), GClass107.smethod_3(97693), 31, "F1", "6E", GClass107.smethod_3(97727), GClass107.smethod_3(97742)));
		list.Add(new GClass100(GClass121.smethod_6("1107"), GClass107.smethod_3(97751), 64, "F1", "6E", GClass107.smethod_3(97780), GClass107.smethod_3(97787)));
		list.Add(new GClass100(GClass121.smethod_6("1107"), GClass107.smethod_3(97813), 199, "F1", "6E", GClass107.smethod_3(97835), GClass107.smethod_3(97865)));
		list.Add(new GClass100(GClass121.smethod_6("1107"), GClass107.smethod_3(97903), 203, "F1", "6E", GClass107.smethod_3(97919), GClass107.smethod_3(97966)));
		list.Add(new GClass100(GClass121.smethod_6("1107"), GClass107.smethod_3(97988), 203, "F1", "CD", GClass107.smethod_3(98031), GClass107.smethod_3(98053)));
		list.Add(new GClass100(GClass121.smethod_6("1102"), "KWP2000Fast", 32, "", "10", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1102"), GClass107.smethod_3(98079), 40, "F1", "6E", GClass107.smethod_3(98083), GClass107.smethod_3(98099)));
		list.Add(new GClass100(GClass121.smethod_6("1102"), GClass107.smethod_3(98119), 40, "F1", "CD", GClass107.smethod_3(98127), GClass107.smethod_3(98133)));
		list.Add(new GClass100(GClass121.smethod_6("1102"), GClass107.smethod_3(98136), 43, "F1", "6E", GClass107.smethod_3(98177), GClass107.smethod_3(98198)));
		list.Add(new GClass100(GClass121.smethod_6("1102"), GClass107.smethod_3(98246), 63, "F1", "CD", GClass107.smethod_3(98285), GClass107.smethod_3(98304)));
		list.Add(new GClass100(GClass121.smethod_6("1102"), GClass107.smethod_3(98308), 62, "F1", "CD", GClass107.smethod_3(98310), GClass107.smethod_3(98343)));
		list.Add(new GClass100(GClass121.smethod_6("1104"), "KWP2000Fast", 233, "", "90", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1104"), "KWP2000Fast", 233, "", "C0", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1104"), "BCAN", 233, "7C2", "6E", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1104"), "BCAN", 233, "7C2", "19", "", "[CTX3]"));
		list.Add(new GClass100(GClass121.smethod_6("1104"), "BCAN", 168, "7D5", "6E", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1104"), "BCAN", 168, "7D5", "19", "", "[CTX3]"));
		list.Add(new GClass100(GClass121.smethod_6("1104"), GClass107.smethod_3(98344), 48, "F1", "6E", GClass107.smethod_3(98355), GClass107.smethod_3(98398)));
		list.Add(new GClass100(GClass121.smethod_6("1104"), GClass107.smethod_3(98413), 48, "F1", "CD", GClass107.smethod_3(98415), GClass107.smethod_3(98462)));
		list.Add(new GClass100(GClass121.smethod_6("1104"), GClass107.smethod_3(98483), 196, "F1", "CD", GClass107.smethod_3(98513), GClass107.smethod_3(98534)));
		list.Add(new GClass100(GClass121.smethod_6("1104"), GClass107.smethod_3(98543), 134, "F1", "6E", GClass107.smethod_3(98582), GClass107.smethod_3(98595)));
		list.Add(new GClass100(GClass121.smethod_6("1103"), "BCAN", 1, "7DA", "6E", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1103"), "BCAN", 1, "7DA", "19", "", "[CTX3]"));
		list.Add(new GClass100(GClass121.smethod_6("1103"), GClass107.smethod_3(98636), 192, "F1", "19", GClass107.smethod_3(98655), GClass107.smethod_3(98678)));
		list.Add(new GClass100(GClass121.smethod_6("1103"), GClass107.smethod_3(98702), 192, "F1", "6E", GClass107.smethod_3(98751), GClass107.smethod_3(98767)));
		list.Add(new GClass100(GClass121.smethod_6("1103"), GClass107.smethod_3(98785), 192, "F1", "CD", GClass107.smethod_3(98807), GClass107.smethod_3(98825)));
		list.Add(new GClass100(GClass121.smethod_6("1103"), GClass107.smethod_3(98845), 88, "F1", "6E", GClass107.smethod_3(98847), GClass107.smethod_3(98856)));
		list.Add(new GClass100(GClass121.smethod_6("1107"), "BCAN", 4, "7C0", "6E", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1107"), "BCAN", 4, "7C0", "19", "", "[CTX3]"));
		list.Add(new GClass100(GClass121.smethod_6("1107"), "BCAN", 174, "7D4", "6E", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1107"), "BCAN", 174, "7D4", "19", "", "[CTX3]"));
		list.Add(new GClass100(GClass121.smethod_6("1106"), "BCAN", 133, "7C3", "6E", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1106"), "BCAN", 133, "7C3", "19", "", "[CTX3]"));
		list.Add(new GClass100(GClass121.smethod_6("1106"), "BCAN", 157, "7C7", "6E", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1106"), "BCAN", 157, "7C7", "19", "", "[CTX3]"));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(98876), 96, "F1", "19", GClass107.smethod_3(98886), GClass107.smethod_3(98929)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(98973), 97, "F1", "19", GClass107.smethod_3(98983), GClass107.smethod_3(99022)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(99060), 135, "F1", "19", GClass107.smethod_3(99082), GClass107.smethod_3(99102)));
		list.Add(new GClass100(GClass121.smethod_6("1110"), "KWP2000Fast", 8, "", "90", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(99148), 198, "F1", "6E", GClass107.smethod_3(99186), GClass107.smethod_3(99191)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(99196), 132, "F1", "3B", GClass107.smethod_3(99203), GClass107.smethod_3(99245)));
		list.Add(new GClass100(GClass121.smethod_6("1110"), "BCAN", 8, "7CA", "6E", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1110"), "BCAN", 8, "7CA", "19", "", "[CTX3]"));
		list.Add(new GClass100(GClass121.smethod_6("1110"), GClass107.smethod_3(99270), 152, "F1", "19", GClass107.smethod_3(99276), GClass107.smethod_3(99300)));
		list.Add(new GClass100(GClass121.smethod_6("1110"), GClass107.smethod_3(99344), 153, "F1", "19", GClass107.smethod_3(99355), GClass107.smethod_3(99373)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(99415), 112, "F1", "6E", GClass107.smethod_3(99427), GClass107.smethod_3(99449)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(99497), 112, "F1", "CD", GClass107.smethod_3(99521), GClass107.smethod_3(99560)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(99563), 113, "F1", "6E", GClass107.smethod_3(99598), GClass107.smethod_3(99628)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(99644), 160, "F1", "19", GClass107.smethod_3(99674), GClass107.smethod_3(99684)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(99719), 160, "F1", "CD", GClass107.smethod_3(99763), GClass107.smethod_3(99805)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(99810), 160, "F1", "6E", GClass107.smethod_3(99837), GClass107.smethod_3(99857)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(99888), 56, "F1", "CD", GClass107.smethod_3(99909), GClass107.smethod_3(99927)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(99969), 49, "F1", "CD", GClass107.smethod_3(100013), GClass107.smethod_3(100044)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(100062), 65, "F1", "6E", GClass107.smethod_3(100082), GClass107.smethod_3(100124)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(100148), 65, "F1", "CD", GClass107.smethod_3(100191), GClass107.smethod_3(100207)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(100251), 65, "F1", "3B", GClass107.smethod_3(100276), GClass107.smethod_3(100316)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(100356), 42, "F1", "6E", GClass107.smethod_3(100384), GClass107.smethod_3(100431)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(100452), 162, "F1", "19", GClass107.smethod_3(100497), GClass107.smethod_3(100532)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(100581), 162, "F1", "19", GClass107.smethod_3(100616), GClass107.smethod_3(100653)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(100692), 163, "F1", "19", GClass107.smethod_3(100723), GClass107.smethod_3(100731)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(100776), 161, "F1", "19", GClass107.smethod_3(100795), GClass107.smethod_3(100808)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(100857), 161, "F1", "6E", GClass107.smethod_3(100877), GClass107.smethod_3(100905)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(100909), 161, "F1", "CD", GClass107.smethod_3(100923), GClass107.smethod_3(100963)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(100964), 161, "F1", "6E", GClass107.smethod_3(101013), GClass107.smethod_3(101030)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(101071), 30, "F1", "6E", "RDM", GClass107.smethod_3(101101)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(101106), 29, "F1", "6E", "PTU", GClass107.smethod_3(101153)));
		list.Add(new GClass100(GClass121.smethod_6("1109"), "KWP2000Fast", 25, "", "C0", "", "[0][1][2][CT3]"));
		list.Add(new GClass100(GClass121.smethod_6("1109"), "KWP2000Fast", 41, "", "C0", "", "[0][1][2][CT3]"));
		list.Add(new GClass100(GClass121.smethod_6("1109"), "KWP2000Fast", 59, "", "D0", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1109"), "KWP2000Fast", 155, "", "D0", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1109"), "KWP2000Fast", 176, "", "D0", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "BCAN", 14, "7C8", "6E", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "BCAN", 14, "7C8", "19", "", "[CTX3]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "BCAN", 13, "7D1", "6E", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "BCAN", 13, "7D1", "19", "", "[CTX3]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "BCAN", 138, "7C9", "6E", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "BCAN", 138, "7C9", "19", "", "[CTX3]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "BCAN", 134, "7D8", "6E", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "BCAN", 134, "7D8", "19", "", "[CTX3]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "BCAN", 26, "7D2", "6E", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "BCAN", 26, "7D2", "19", "", "[CTX3]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "BCAN", 155, "7D7", "6E", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "BCAN", 155, "7D7", "19", "", "[CTX3]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "KWP2000Fast", 157, "", "90", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1106"), "ISO9141", 133, "", "70", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1110"), "ISO9141", 8, "", "70", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1103"), "ISO9141", 0, "", "30", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1103"), "ISO9141", 0, "", "70", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1101"), "ISO9141", 145, "", "70", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "ISO9141", 28, "", "D0", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1103"), "KW01", 0, "", "30", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1103"), "KW01", 0, "", "70", "", "[0]"));
		list.Add(new GClass100(GClass121.smethod_6("1101"), "KWP71", 16, "", "70", "", "[0]"));
		list.Add(new GClass100(GClass121.smethod_6("1101"), "ISO9141", 16, "", "70", "", "[0]"));
		list.Add(new GClass100(GClass121.smethod_6("1102"), "KWP71", 32, "", "10", "", "[0][1]"));
		list.Add(new GClass100(GClass121.smethod_6("1102"), "KWP71", 32, "", "70", "", "[0]"));
		if (GClass126.bool_19)
		{
			GClass126.bool_19 = false;
			byte b = 0;
			while (b < 241)
			{
				bool flag = false;
				using (List<GClass100>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						GClass100 gclass = enumerator.Current;
						if (gclass.byte_0 == b && gclass.string_4 == "F1" && gclass.string_3 == GClass107.smethod_3(101182) && gclass.string_5 == "6E")
						{
							flag = true;
							break;
						}
					}
					goto IL_298B;
				}
				goto IL_2940;
				IL_297F:
				b += 1;
				continue;
				IL_2940:
				list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(101223), b, "F1", "6E", GClass107.smethod_3(101237), GClass107.smethod_3(101259)));
				goto IL_297F;
				IL_298B:
				if (!flag)
				{
					goto IL_2940;
				}
				goto IL_297F;
			}
			byte b2 = 0;
			while (b2 < 241)
			{
				bool flag2 = false;
				using (List<GClass100>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						GClass100 gclass2 = enumerator.Current;
						if (gclass2.byte_0 == b2 && gclass2.string_4 == "F1" && gclass2.string_3 == GClass107.smethod_3(101264) && gclass2.string_5 == "CD")
						{
							flag2 = true;
							break;
						}
					}
					goto IL_2A69;
				}
				goto IL_2A1E;
				IL_2A5D:
				b2 += 1;
				continue;
				IL_2A1E:
				list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(101283), b2, "F1", "CD", GClass107.smethod_3(101327), GClass107.smethod_3(101344)));
				goto IL_2A5D;
				IL_2A69:
				if (!flag2)
				{
					goto IL_2A1E;
				}
				goto IL_2A5D;
			}
			byte b3 = 0;
			while (b3 < 241)
			{
				bool flag3 = false;
				using (List<GClass100>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						GClass100 gclass3 = enumerator.Current;
						if (gclass3.byte_0 == b3 && gclass3.string_4 == "F1" && gclass3.string_3 == GClass107.smethod_3(101388) && gclass3.string_5 == "3B")
						{
							flag3 = true;
							break;
						}
					}
					goto IL_2B47;
				}
				goto IL_2AFC;
				IL_2B3B:
				b3 += 1;
				continue;
				IL_2AFC:
				list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(101421), b3, "F1", "3B", GClass107.smethod_3(101452), GClass107.smethod_3(101486)));
				goto IL_2B3B;
				IL_2B47:
				if (!flag3)
				{
					goto IL_2AFC;
				}
				goto IL_2B3B;
			}
		}
		list.Add(new GClass100(GClass121.smethod_6("1105"), GClass107.smethod_3(101517), 2, GClass107.smethod_3(101552), "6E", GClass107.smethod_3(101582), GClass107.smethod_3(101585)));
		list.Add(new GClass100(GClass121.smethod_6("1105"), GClass107.smethod_3(101599), 2, GClass107.smethod_3(101622), "6E", GClass107.smethod_3(101645), GClass107.smethod_3(101646)));
		list.Add(new GClass100(GClass121.smethod_6("1105"), GClass107.smethod_3(101676), 8, GClass107.smethod_3(101700), "6E", GClass107.smethod_3(101724), GClass107.smethod_3(101762)));
		list.Add(new GClass100(GClass121.smethod_6("1105"), GClass107.smethod_3(101802), 8, GClass107.smethod_3(101814), "6E", GClass107.smethod_3(101815), GClass107.smethod_3(101855)));
		list.Add(new GClass100(GClass121.smethod_6("1105"), GClass107.smethod_3(101883), 8, GClass107.smethod_3(101914), "6E", GClass107.smethod_3(101944), GClass107.smethod_3(101960)));
		list.Add(new GClass100(GClass121.smethod_6("1105"), GClass107.smethod_3(101991), 11, GClass107.smethod_3(101994), "6E", GClass107.smethod_3(102001), GClass107.smethod_3(102046)));
		list.Add(new GClass100(GClass121.smethod_6("1107"), GClass107.smethod_3(102072), 4, "620504", "6E", GClass107.smethod_3(102082), GClass107.smethod_3(102085)));
		list.Add(new GClass100(GClass121.smethod_6("1102"), GClass107.smethod_3(102112), 32, GClass107.smethod_3(102137), "6E", GClass107.smethod_3(102182), GClass107.smethod_3(102187)));
		list.Add(new GClass100(GClass121.smethod_6("1103"), GClass107.smethod_3(102223), 0, GClass107.smethod_3(102270), "6E", GClass107.smethod_3(102289), GClass107.smethod_3(102321)));
		list.Add(new GClass100(GClass121.smethod_6("1103"), GClass107.smethod_3(102326), 0, GClass107.smethod_3(102346), "6E", GClass107.smethod_3(102392), GClass107.smethod_3(102396)));
		list.Add(new GClass100(GClass121.smethod_6("1104"), GClass107.smethod_3(102414), 13, GClass107.smethod_3(102421), "6E", GClass107.smethod_3(102425), GClass107.smethod_3(102442)));
		list.Add(new GClass100(GClass121.smethod_6("1104"), GClass107.smethod_3(102447), 11, GClass107.smethod_3(102465), "6E", GClass107.smethod_3(102491), GClass107.smethod_3(102522)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(102565), 3, GClass107.smethod_3(102584), "6E", GClass107.smethod_3(102589), GClass107.smethod_3(102627)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(102641), 11, GClass107.smethod_3(102645), "3B", GClass107.smethod_3(102660), GClass107.smethod_3(102664)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(102693), 11, GClass107.smethod_3(102722), "3B", GClass107.smethod_3(102757), GClass107.smethod_3(102784)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(102789), 11, GClass107.smethod_3(102810), "3B", GClass107.smethod_3(102856), GClass107.smethod_3(102882)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(102916), 11, GClass107.smethod_3(102935), "3B", GClass107.smethod_3(102972), GClass107.smethod_3(103013)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(103035), 11, GClass107.smethod_3(103064), "3B", GClass107.smethod_3(103109), GClass107.smethod_3(103129)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(103160), 5, GClass107.smethod_3(103187), "6E", GClass107.smethod_3(103199), GClass107.smethod_3(103209)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(103236), 6, GClass107.smethod_3(103271), "6E", GClass107.smethod_3(103273), GClass107.smethod_3(103300)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(103349), 7, GClass107.smethod_3(103378), "3B", GClass107.smethod_3(103388), GClass107.smethod_3(103397)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(103418), 9, GClass107.smethod_3(103425), "6E", GClass107.smethod_3(103466), GClass107.smethod_3(103498)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(103530), 10, "791511", "3B", GClass107.smethod_3(103546), GClass107.smethod_3(103550)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(103576), 10, "799519", "3B", GClass107.smethod_3(103611), GClass107.smethod_3(103630)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(103679), 11, GClass107.smethod_3(103726), "6E", GClass107.smethod_3(103737), GClass107.smethod_3(103765)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(103797), 11, "792512", "3B", GClass107.smethod_3(103832), GClass107.smethod_3(103862)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(103897), 11, GClass107.smethod_3(103906), "6E", GClass107.smethod_3(103921), GClass107.smethod_3(103944)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(103979), 11, GClass107.smethod_3(103987), "6E", GClass107.smethod_3(104023), GClass107.smethod_3(104064)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(104070), 11, "784504", "3B", GClass107.smethod_3(104096), GClass107.smethod_3(104139)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(104166), 11, "785505", "3B", GClass107.smethod_3(104174), GClass107.smethod_3(104202)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(104228), 11, GClass107.smethod_3(104239), "6E", GClass107.smethod_3(104277), GClass107.smethod_3(104283)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(104311), 11, GClass107.smethod_3(104339), "6E", GClass107.smethod_3(104345), GClass107.smethod_3(104354)));
		list.Add(new GClass100(GClass121.smethod_6("1107"), GClass107.smethod_3(104361), 4, GClass107.smethod_3(104386), "6E", GClass107.smethod_3(104405), GClass107.smethod_3(104439)));
		list.Add(new GClass100(GClass121.smethod_6("1102"), GClass107.smethod_3(104452), 32, "760768", "6E", GClass107.smethod_3(104480), GClass107.smethod_3(104495)));
		list.Add(new GClass100(GClass121.smethod_6("1103"), GClass107.smethod_3(104543), 0, GClass107.smethod_3(104592), "6E", GClass107.smethod_3(104595), GClass107.smethod_3(104612)));
		list.Add(new GClass100(GClass121.smethod_6("1104"), GClass107.smethod_3(104659), 13, "730738", "6E", GClass107.smethod_3(104673), GClass107.smethod_3(104693)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(104738), 3, "720728", "6E", GClass107.smethod_3(104773), GClass107.smethod_3(104809)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(104858), 11, GClass107.smethod_3(104863), "6E", GClass107.smethod_3(104903), GClass107.smethod_3(104929)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(104968), 11, GClass107.smethod_3(104979), "6E", GClass107.smethod_3(105027), GClass107.smethod_3(105055)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(105096), 11, "731739", "6E", GClass107.smethod_3(105119), GClass107.smethod_3(105155)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(105177), 10, GClass107.smethod_3(105200), "3B", GClass107.smethod_3(105205), GClass107.smethod_3(105213)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(105238), 10, GClass107.smethod_3(105264), "3B", GClass107.smethod_3(105267), GClass107.smethod_3(105306)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(105310), 5, GClass107.smethod_3(105311), "6E", GClass107.smethod_3(105355), GClass107.smethod_3(105364)));
		list.Add(new GClass100(GClass121.smethod_6("1107"), GClass107.smethod_3(105391), 4, "745765", "6E", GClass107.smethod_3(105398), GClass107.smethod_3(105424)));
		list.Add(new GClass100(GClass121.smethod_6("1102"), GClass107.smethod_3(105464), 32, "740760", "6E", GClass107.smethod_3(105475), GClass107.smethod_3(105486)));
		list.Add(new GClass100(GClass121.smethod_6("1103"), GClass107.smethod_3(105500), 0, "752772", "6E", GClass107.smethod_3(105506), GClass107.smethod_3(105522)));
		list.Add(new GClass100(GClass121.smethod_6("1106"), GClass107.smethod_3(105526), 3, "743763", "6E", GClass107.smethod_3(105545), GClass107.smethod_3(105573)));
		list.Add(new GClass100(GClass121.smethod_6("1104"), GClass107.smethod_3(105597), 13, "742762", "6E", GClass107.smethod_3(105612), GClass107.smethod_3(105644)));
		list.Add(new GClass100(GClass121.smethod_6("1111"), GClass107.smethod_3(105661), 11, GClass107.smethod_3(105676), "6E", GClass107.smethod_3(105697), GClass107.smethod_3(105704)));
		list.Add(new GClass100(GClass121.smethod_6("1105"), "CCAN29", 24, "F4", "6E", "", "[0][7]"));
		list.Add(new GClass100(GClass121.smethod_6("1107"), "CCAN29", 64, "F4", "6E", "", "[0][7]"));
		list.Add(new GClass100(GClass121.smethod_6("1102"), "CCAN29", 40, "F4", "6E", "", "[0][7]"));
		list.Add(new GClass100(GClass121.smethod_6("1106"), "CCAN29", 96, "F4", "6E", "", "[0][7]"));
		list.Add(new GClass100(GClass121.smethod_6("1104"), "CCAN29", 48, "F4", "6E", "", "[0][7]"));
		list.Add(new GClass100(GClass121.smethod_6("1103"), "CCAN29", 192, "F4", "6E", "", "[0][7]"));
		list.Add(new GClass100(GClass121.smethod_6("1111"), "CCAN29", 160, "F4", "6E", "", "[0][7]"));
		list.Add(new GClass100(GClass121.smethod_6("1106"), "BHCAN29", 135, "F4", "3E", "", "[0][8][CT7]"));
		list.Add(new GClass100(GClass121.smethod_6("1106"), "BCAN29", 96, "F4", "19", "", "[0][2][CT3]"));
		list.Add(new GClass100(GClass121.smethod_6("1106"), "CCAN29", 96, "F4", "6E", "", "[0][3]"));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				165
			}
		}, 1, 5, "ISO Code", "hex", "", "", new string[]
		{
			""
		}, "", 10455));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				135
			}
		}, 1, 1, "ID1", "hex", "", "", new string[]
		{
			""
		}, ""));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				140
			}
		}, 1, 1, "ID2", "hex", "", "", new string[]
		{
			""
		}, ""));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				144
			}
		}, 1, 17, "VIN code", "str", "", "", new string[]
		{
			""
		}, "", 11722));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				146
			}
		}, 1, 11, "Hardware number", "str", "", "", new string[]
		{
			""
		}, "", 10744));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				147
			}
		}, 1, 1, "Hardware version", "hex2", "", "", new string[]
		{
			""
		}, "", 10745));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				148
			}
		}, 1, 11, "Software number", "str", "", "", new string[]
		{
			""
		}, "", 11497));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				149
			}
		}, 1, 2, "Software version", "hex2", "", "", new string[]
		{
			""
		}, "", 11498));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				150
			}
		}, 1, 1, "ID8", "hex", "", "", new string[]
		{
			""
		}, ""));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				160
			}
		}, 1, 1, "ID9", "hex", "", "", new string[]
		{
			""
		}, ""));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				164
			}
		}, 1, 1, "ID10", "hex", "", "", new string[]
		{
			""
		}, ""));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				11
			}
		}, 1, 1, "ID13", "hex", "", "", new string[]
		{
			""
		}, ""));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				84
			}
		}, 1, 1, "ID12", "hex", "", "", new string[]
		{
			""
		}, ""));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				85
			}
		}, 1, 1, "ID12", "hex", "", "", new string[]
		{
			""
		}, ""));
		list2.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				0
			}
		}, 2, 2, "ID2", "isovarver", "", "", new string[]
		{
			""
		}, ""));
		list3.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				0
			}
		}, 2, 2, "ISO Code", "isovarver", "", "", new string[]
		{
			""
		}, "", 10455));
		list3.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				135
			}
		}, 1, 1, "ID1", "hex", "", "", new string[]
		{
			""
		}, ""));
		list3.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				140
			}
		}, 1, 1, "ID12", "hex", "", "", new string[]
		{
			""
		}, ""));
		list3.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				144
			}
		}, 1, 17, "VIN code", "str", "", "", new string[]
		{
			""
		}, "", 11722));
		list3.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				146
			}
		}, 1, 11, "Hardware number", "str", "", "", new string[]
		{
			""
		}, "", 10744));
		list3.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				147
			}
		}, 1, 1, "Hardware version", "hex2", "", "", new string[]
		{
			""
		}, "", 10745));
		list3.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				148
			}
		}, 1, 11, "Software number", "str", "", "", new string[]
		{
			""
		}, "", 11497));
		list3.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				149
			}
		}, 1, 2, "Software version", "hex2", "", "", new string[]
		{
			""
		}, "", 11498));
		list3.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				150
			}
		}, 1, 1, "ID8", "hex", "", "", new string[]
		{
			""
		}, ""));
		list3.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				160
			}
		}, 1, 1, "ID9", "hex", "", "", new string[]
		{
			""
		}, ""));
		list3.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				11
			}
		}, 1, 1, "ID13", "hex", "", "", new string[]
		{
			""
		}, ""));
		list3.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				84
			}
		}, 1, 1, "ID12", "hex", "", "", new string[]
		{
			""
		}, ""));
		list3.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				85
			}
		}, 1, 1, "ID12", "hex", "", "", new string[]
		{
			""
		}, ""));
		list6.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				135
			}
		}, 3, 2, "ISO Code", "isopn", "", "", new string[]
		{
			""
		}, "", 10455));
		list6.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				136
			}
		}, 1, 1, "ID11", "hex", "", "", new string[]
		{
			""
		}, ""));
		list6.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				144
			}
		}, 1, 1, "ID12", "hex", "", "", new string[]
		{
			""
		}, ""));
		list6.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				156
			}
		}, 1, 1, "ID13", "hex", "", "", new string[]
		{
			""
		}, ""));
		list6.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				157
			}
		}, 1, 1, "ID14", "hex", "", "", new string[]
		{
			""
		}, ""));
		list6.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				49,
				1
			}
		}, 1, 1, "ID15", "hex", "", "", new string[]
		{
			""
		}, ""));
		list6.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				135
			}
		}, 6, 2, "Hardware version", "verpn", "", "", new string[]
		{
			""
		}, "", 10745));
		list6.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				135
			}
		}, 8, 3, "Software version", "verpn", "", "", new string[]
		{
			""
		}, "", 11498));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				0
			}
		}, 2, 2, "ISO Code", "isopn", "", "", new string[]
		{
			""
		}, "", 10455));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				144
			}
		}, 1, 1, "ID3", "hex", "", "", new string[]
		{
			""
		}, ""));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				150
			}
		}, 1, 1, "ID8", "hex", "", "", new string[]
		{
			""
		}, ""));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				160
			}
		}, 1, 17, "VIN code", "str", "", "", new string[]
		{
			""
		}, "", 11722));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				11
			}
		}, 1, 1, "ID1", "hex", "", "", new string[]
		{
			""
		}, ""));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				18
			}
		}, 1, 1, "ID4", "hex", "", "", new string[]
		{
			""
		}, ""));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				34
			}
		}, 1, 1, "ID5", "hex", "", "", new string[]
		{
			""
		}, ""));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				50
			}
		}, 1, 1, "ID6", "hex", "", "", new string[]
		{
			""
		}, ""));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				80
			}
		}, 1, 3, "Hardware version", "verpn", "", "", new string[]
		{
			""
		}, "", 10745));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				81
			}
		}, 1, 3, "Software version", "verpn", "", "", new string[]
		{
			""
		}, "", 11498));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				83
			}
		}, 1, 1, "ID11", "hex", "", "", new string[]
		{
			""
		}, ""));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				84
			}
		}, 1, 1, "ID12", "hex", "", "", new string[]
		{
			""
		}, ""));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				85
			}
		}, 1, 1, "ID12", "hex", "", "", new string[]
		{
			""
		}, ""));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				88
			}
		}, 1, 1, "ID13", "hex", "", "", new string[]
		{
			""
		}, ""));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				91
			}
		}, 1, 1, "ID14", "hex", "", "", new string[]
		{
			""
		}, ""));
		list4.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				112
			}
		}, 1, 1, "ID15", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				0
			}
		}, 2, 2, "ISO Code", "isopn", "", "", new string[]
		{
			""
		}, "", 10455));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				144
			}
		}, 1, 1, "ID3", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				150
			}
		}, 1, 1, "ID8", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				160
			}
		}, 1, 17, "VIN code", "str", "", "", new string[]
		{
			""
		}, "", 11722));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				11
			}
		}, 1, 1, "ID1", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				18
			}
		}, 1, 1, "ID4", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				34
			}
		}, 1, 1, "ID5", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				50
			}
		}, 1, 1, "ID6", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				80
			}
		}, 1, 3, "Hardware version", "verpn", "", "", new string[]
		{
			""
		}, "", 10745));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				81
			}
		}, 1, 3, "Software version", "verpn", "", "", new string[]
		{
			""
		}, "", 11498));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				83
			}
		}, 1, 1, "ID11", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				84
			}
		}, 1, 1, "ID12", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				85
			}
		}, 1, 1, "ID12", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				88
			}
		}, 1, 1, "ID13", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				91
			}
		}, 1, 1, "ID14", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				241,
				112
			}
		}, 1, 1, "ID15", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				32
			}
		}, 1, 1, "CF20", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				33
			}
		}, 1, 1, "CF21", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				34
			}
		}, 1, 1, "CF22", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				35
			}
		}, 1, 1, "CF23", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				36
			}
		}, 1, 1, "CF24", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				37
			}
		}, 1, 1, "CF25", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				38
			}
		}, 1, 1, "CF26", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				39
			}
		}, 1, 1, "CF27", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				48
			}
		}, 1, 1, "CF30", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				49
			}
		}, 1, 1, "CF31", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				50
			}
		}, 1, 1, "CF32", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				51
			}
		}, 1, 1, "CF33", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				52
			}
		}, 1, 1, "CF34", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				53
			}
		}, 1, 1, "CF35", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				54
			}
		}, 1, 1, "CF36", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				55
			}
		}, 1, 1, "CF37", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				56
			}
		}, 1, 1, "CF38", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				57
			}
		}, 1, 1, "CF39", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				58
			}
		}, 1, 1, "CF3A", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				59
			}
		}, 1, 1, "CF3B", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				60
			}
		}, 1, 1, "CF3C", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				61
			}
		}, 1, 1, "CF3D", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				62
			}
		}, 1, 1, "CF3E", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				63
			}
		}, 1, 1, "CF3F", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				64
			}
		}, 1, 1, "CF40", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				65
			}
		}, 1, 1, "CF41", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				66
			}
		}, 1, 1, "CF42", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				67
			}
		}, 1, 1, "CF43", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				68
			}
		}, 1, 1, "CF44", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				69
			}
		}, 1, 1, "CF45", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				70
			}
		}, 1, 1, "CF46", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				71
			}
		}, 1, 1, "CF47", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				72
			}
		}, 1, 1, "CF48", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				1,
				73
			}
		}, 1, 1, "CF49", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				160,
				80
			}
		}, 1, 1, "CF50", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				160,
				81
			}
		}, 1, 1, "CF51", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				160,
				82
			}
		}, 1, 1, "CF52", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				160,
				83
			}
		}, 1, 1, "CF53", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				3,
				34,
				160,
				84
			}
		}, 1, 1, "CF54", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				135
			}
		}, 3, 2, "KWPISO Code", "isopn", "", "", new string[]
		{
			""
		}, "", 10455));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				136
			}
		}, 1, 1, "KWPID11", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				144
			}
		}, 1, 1, "KWPID12", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				156
			}
		}, 1, 1, "KWPID13", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				157
			}
		}, 1, 1, "KWPID14", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				49,
				1
			}
		}, 1, 1, "KWPID15", "hex", "", "", new string[]
		{
			""
		}, ""));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				135
			}
		}, 6, 2, "KWPHardware version", "verpn", "", "", new string[]
		{
			""
		}, "", 10745));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				135
			}
		}, 8, 3, "KWPSoftware version", "verpn", "", "", new string[]
		{
			""
		}, "", 11498));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				33,
				128
			}
		}, 10, 2, "RNOISO Code", "isopn", "", "", new string[]
		{
			""
		}, "", 10455));
		list5.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				33,
				129
			}
		}, 2, 17, "RNOVIN code", "str", "", "", new string[]
		{
			""
		}, "", 11722));
		list8.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				138
			}
		}, 1, 16, "ISO Code", "str", "", "", new string[]
		{
			""
		}, "", 10455));
		list7.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				151
			}
		}, 1, 5, "ISO Code", "hex", "", "", new string[]
		{
			""
		}, "", 10455));
		list7.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				128
			}
		}, 1, 1, "ID1", "hex", "", "", new string[]
		{
			""
		}, ""));
		list7.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				146
			}
		}, 1, 11, "Hardware number", "str", "", "", new string[]
		{
			""
		}, "", 10744));
		list7.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				147
			}
		}, 1, 1, "Hardware version", "hex2", "", "", new string[]
		{
			""
		}, "", 10745));
		list7.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				148
			}
		}, 1, 11, "Software number", "str", "", "", new string[]
		{
			""
		}, "", 11497));
		list7.Add(new GClass104(new byte[][]
		{
			new byte[]
			{
				2,
				26,
				149
			}
		}, 1, 2, "Software version", "hex2", "", "", new string[]
		{
			""
		}, "", 11498));
		this.int_1 = list.Count;
		for (int m = 0; m < list.Count; m++)
		{
			if (this.bool_1)
			{
				this.bool_2 = true;
				return;
			}
			if (m > this.int_0)
			{
				this.int_0 = m;
			}
			GClass100 gclass4;
			if (m > 0)
			{
				gclass4 = list[m - 1];
			}
			else
			{
				gclass4 = new GClass100("", "", 0, "", "", "", "");
			}
			GClass100 gclass5 = list[m];
			if (m <= 0 || gclass5.byte_0 != gclass4.byte_0 || !(gclass5.string_3 == gclass4.string_3) || !(gclass5.string_1 == gclass4.string_1) || !(gclass5.string_4 == gclass4.string_4) || GClass125.smethod_49() || GClass125.smethod_44() == 15)
			{
				string item = this.method_6(gclass5);
				if (!this.list_1.Contains(item))
				{
					if (!GClass125.smethod_49())
					{
						if (GClass125.smethod_44() != 15)
						{
							if (gclass5.string_6.Contains("[" + this.int_2.ToString() + "]"))
							{
								goto IL_62A3;
							}
							goto IL_66CA;
						}
					}
					if ((this.bool_8 && gclass5.string_6.Contains(GClass107.smethod_3(105725) + this.int_2.ToString() + "]")) || (!gclass5.string_6.Contains("[" + this.int_2.ToString() + "]") && !gclass5.string_6.Contains("[CT" + this.int_2.ToString() + "]") && !gclass5.string_6.Contains(GClass107.smethod_3(105730) + this.int_2.ToString() + "]")))
					{
						goto IL_66CA;
					}
					IL_62A3:
					if (!this.bool_9 || !gclass5.string_3.Contains("CAN") || gclass5.string_3.Contains(GClass107.smethod_3(105759)))
					{
						GClass126.bool_0 = false;
						if (gclass5.string_3.Contains(GClass107.smethod_3(105785)))
						{
							gclass5.list_0 = list2;
						}
						else if (gclass5.string_3.Contains(GClass107.smethod_3(105812)) && (gclass5.string_4 == "F4" || gclass5.byte_0 == 66 || gclass5.byte_0 == 67 || gclass5.byte_0 == 68 || gclass5.byte_0 == 69 || gclass5.byte_0 == 71 || gclass5.byte_0 == 72))
						{
							gclass5.list_0 = list3;
						}
						else if (gclass5.string_3.Contains(GClass107.smethod_3(105859)))
						{
							gclass5.list_0 = list2;
						}
						else if (gclass5.string_3.Contains(GClass107.smethod_3(105868)))
						{
							gclass5.list_0 = list5;
						}
						else if (gclass5.string_3.Contains(GClass107.smethod_3(105890)))
						{
							gclass5.list_0 = list6;
						}
						else if (gclass5.string_3.Contains(GClass107.smethod_3(105927)))
						{
							if (gclass5.string_4 == "620504")
							{
								gclass5.list_0 = list5;
							}
							else
							{
								gclass5.list_0 = list4;
							}
						}
						else if (!(gclass5.string_4 == "000") && !(gclass5.string_4 == "111"))
						{
							if (gclass5.string_3 == GClass107.smethod_3(105944) || gclass5.string_3 == GClass107.smethod_3(105950))
							{
								gclass5.list_0 = list7;
							}
						}
						else
						{
							gclass5.list_0 = list8;
						}
						if (gclass5.list_0 == null)
						{
							gclass5.list_0 = new List<GClass104>();
						}
						if (gclass5.list_1 == null)
						{
							gclass5.list_1 = new List<GClass104>();
						}
						foreach (GClass104 gclass6 in gclass5.list_0)
						{
							gclass6.method_1("");
						}
						GClass11 gclass7 = GClass11.smethod_0(gclass5.string_3, gclass5.string_4, gclass5.byte_0, gclass5.list_0, gclass5.list_1, gclass5.string_5, null);
						if (gclass7 != null)
						{
							if (this.bool_1)
							{
								this.bool_2 = true;
								return;
							}
							if (gclass5.string_3 == GClass107.smethod_3(105981) || gclass5.string_3 == GClass107.smethod_3(106016) || gclass5.string_3 == GClass107.smethod_3(106021) || gclass5.string_3 == GClass107.smethod_3(106067) || GClass125.smethod_44() == 6 || GClass125.smethod_44() == 7 || GClass125.smethod_46())
							{
								for (int n = 0; n < 20; n++)
								{
									Thread.Sleep(100);
									if (this.bool_1)
									{
										this.bool_2 = true;
										return;
									}
								}
							}
							if (gclass5.string_3.Contains(GClass107.smethod_3(106081)))
							{
								gclass7.method_21(list);
								gclass7.Event_4 += this.method_7;
							}
							if (this.bool_5)
							{
								gclass7.method_40();
							}
							else
							{
								gclass7.method_0();
							}
							if (this.bool_1)
							{
								this.bool_2 = true;
								return;
							}
							if (!gclass5.string_3.Contains(GClass107.smethod_3(106100)))
							{
								gclass5.string_0 = gclass7.method_11();
								gclass5.list_3 = gclass7.method_12();
								this.method_8(gclass5);
							}
							if (gclass5.string_3.Contains(GClass107.smethod_3(106113)) && this.list_1.Count > 0)
							{
								this.bool_9 = true;
								if (this.int_1 <= this.int_0 + 10)
								{
									this.int_1 = this.int_0 + 10;
								}
								this.int_0 += 10;
							}
						}
					}
				}
			}
			IL_66CA:;
		}
		if (this.bool_7)
		{
			GClass126.smethod_2("", 2);
			GClass126.smethod_2(GClass107.smethod_3(106133), 2);
			this.string_0 = this.string_0 + GClass107.smethod_3(106171) + Environment.NewLine + Environment.NewLine;
			this.bool_0 = false;
		}
		if (!this.bool_1)
		{
			this.string_0 = this.string_0 + GClass121.smethod_6("6051") + Environment.NewLine;
		}
		else
		{
			this.string_0 = this.string_0 + GClass121.smethod_6("6082") + Environment.NewLine;
		}
		this.bool_0 = false;
		this.int_0++;
		this.bool_2 = true;
		if (!this.bool_3)
		{
			base.Invoke(new GForm7.Delegate3(this.method_4));
		}
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x00003D5D File Offset: 0x00001F5D
	private string method_6(GClass100 gclass100_0)
	{
		return string.Concat(new string[]
		{
			gclass100_0.string_1,
			"_",
			GClass127.smethod_23(gclass100_0.byte_0),
			"_",
			gclass100_0.string_4
		});
	}

	// Token: 0x060004CB RID: 1227 RVA: 0x000B1050 File Offset: 0x000AF250
	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (this.bool_4)
		{
			this.bool_4 = false;
			new GForm9(GClass121.smethod_6("1070"), GClass121.smethod_6("1074"), GClass121.smethod_6("1075"), true, 120000).ShowDialog();
		}
		if (!this.bool_0)
		{
			this.bool_0 = true;
			this.textBox_0.Text = this.string_0;
			this.textBox_0.SelectionStart = this.textBox_0.Text.Length;
			this.textBox_0.ScrollToCaret();
		}
		if (this.int_1 != this.gclass109_0.Maximum)
		{
			this.gclass109_0.Maximum = this.int_1;
		}
		if (this.gclass109_0.Value < this.int_0)
		{
			this.gclass109_0.Value = this.int_0;
		}
	}

	// Token: 0x060004CC RID: 1228 RVA: 0x000B112C File Offset: 0x000AF32C
	public GForm7(bool bool_10)
	{
		this.method_9();
		this.button_0.Text = GClass121.smethod_6("8198");
		this.button_1.Text = GClass121.smethod_6("1011");
		this.button_2.Text = GClass121.smethod_6("3002");
		if (bool_10)
		{
			this.Text = GClass121.smethod_6(GClass107.smethod_3(92808));
		}
		else
		{
			this.Text = GClass121.smethod_6(GClass107.smethod_3(92836));
		}
		this.button_2.Font = GClass125.smethod_28();
		this.button_0.Font = GClass125.smethod_28();
		this.bool_5 = bool_10;
		GClass126.bool_25 = false;
		int num = (int)((double)Screen.PrimaryScreen.Bounds.Width * 0.8);
		if (num < 640)
		{
			num = 640;
		}
		base.Width = num;
		int num2 = (int)((double)Screen.PrimaryScreen.Bounds.Height * 0.8);
		if (num2 < 500)
		{
			num2 = 500;
		}
		base.Height = num2;
		this.gclass109_0.Maximum = 1;
		this.gclass109_0.Value = 0;
		this.gclass109_0.method_1((GEnum1)0);
		new Thread(new ThreadStart(this.method_5)).Start();
	}

	// Token: 0x060004CD RID: 1229 RVA: 0x00003D9A File Offset: 0x00001F9A
	private void method_7(object sender, GEventArgs6 e)
	{
		this.method_8(e.method_0());
	}

	// Token: 0x060004CE RID: 1230 RVA: 0x000B12C8 File Offset: 0x000AF4C8
	private void method_8(GClass100 gclass100_0)
	{
		if (gclass100_0.string_0 != "")
		{
			if (this.int_1 <= this.int_0)
			{
				this.int_1 = this.int_0 + 1;
			}
			this.int_0++;
			string item = this.method_6(gclass100_0);
			if (this.list_1.Contains(item))
			{
				return;
			}
			this.list_1.Add(item);
			string text = GClass107.smethod_3(106188);
			string text2 = "";
			DataRow[] array = this.gclass99_0.dataTable_4.Select(GClass107.smethod_3(106215) + gclass100_0.string_0 + "'");
			if (array.Length != 0)
			{
				int num = (int)array[0]["SystemID2"];
				array = this.gclass99_0.dataTable_3.Select("SystemID2=" + num.ToString());
				if (array.Length != 0)
				{
					text = (string)array[0]["SystemDesc"];
					text2 = (string)array[0]["ModuleID"];
				}
			}
			string text3 = "";
			if (gclass100_0.string_2 != "")
			{
				text3 = string.Concat(new string[]
				{
					gclass100_0.string_1,
					" / ",
					gclass100_0.string_2,
					Environment.NewLine,
					text,
					Environment.NewLine,
					GClass121.smethod_20(10455, GClass107.smethod_3(106232)),
					": ",
					gclass100_0.string_0
				});
			}
			else
			{
				text3 = string.Concat(new string[]
				{
					gclass100_0.string_1,
					Environment.NewLine,
					text,
					Environment.NewLine,
					GClass121.smethod_20(10455, GClass107.smethod_3(106252)),
					": ",
					gclass100_0.string_0
				});
			}
			string string_ = text3;
			if (text3 != "")
			{
				text3 += Environment.NewLine;
			}
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			string text8 = "";
			foreach (GClass104 gclass in gclass100_0.list_0)
			{
				if (gclass.int_2 == 11722 && text4 == "")
				{
					text4 = gclass.method_0();
				}
				else if (gclass.int_2 == 10744 && text5 == "")
				{
					text5 = gclass.method_0();
				}
				else if (gclass.int_2 == 10745 && text6 == "")
				{
					text6 = gclass.method_0();
				}
				else if (gclass.int_2 == 11497 && text7 == "")
				{
					text7 = gclass.method_0();
				}
				else if (gclass.int_2 == 11498 && text8 == "")
				{
					text8 = gclass.method_0();
				}
			}
			if (text4 != "")
			{
				text3 = string.Concat(new string[]
				{
					text3,
					GClass121.smethod_20(11722, "VIN code"),
					": ",
					text4,
					Environment.NewLine
				});
			}
			if (text5 != "")
			{
				text3 = string.Concat(new string[]
				{
					text3,
					GClass121.smethod_20(10744, "Hardware number"),
					": ",
					text5,
					" - Ver: ",
					text6,
					Environment.NewLine
				});
			}
			else if (text6 != "")
			{
				text3 = string.Concat(new string[]
				{
					text3,
					GClass121.smethod_20(10745, "Hardware version"),
					": ",
					text6,
					Environment.NewLine
				});
			}
			if (text7 != "")
			{
				text3 = string.Concat(new string[]
				{
					text3,
					GClass121.smethod_20(11497, "Software number"),
					": ",
					text7,
					" - Ver: ",
					text8,
					Environment.NewLine
				});
			}
			else if (text8 != "")
			{
				text3 = string.Concat(new string[]
				{
					text3,
					GClass121.smethod_20(11498, "Software version"),
					": ",
					text8,
					Environment.NewLine
				});
			}
			this.string_0 += text3;
			this.bool_0 = false;
			if (gclass100_0.string_2 != "")
			{
				GClass126.smethod_2(gclass100_0.string_1 + " / " + gclass100_0.string_2, 2);
			}
			else
			{
				GClass126.smethod_2(gclass100_0.string_1, 2);
			}
			GClass126.smethod_2(text, 2);
			GClass126.smethod_2(GClass121.smethod_20(10455, GClass107.smethod_3(106271)) + ": " + gclass100_0.string_0, 2);
			if (text4 != "")
			{
				GClass126.smethod_2(GClass121.smethod_20(11722, "VIN code") + ": " + text4, 2);
			}
			if (text5 != "")
			{
				GClass126.smethod_2(string.Concat(new string[]
				{
					GClass121.smethod_20(10744, "Hardware number"),
					": ",
					text5,
					" - Ver: ",
					text6
				}), 2);
			}
			else if (text6 != "")
			{
				GClass126.smethod_2(GClass121.smethod_20(10745, "Hardware version") + ": " + text6, 2);
			}
			if (text7 != "")
			{
				GClass126.smethod_2(string.Concat(new string[]
				{
					GClass121.smethod_20(11497, "Software number"),
					": ",
					text7,
					" - Ver: ",
					text8
				}), 2);
			}
			else if (text8 != "")
			{
				GClass126.smethod_2(GClass121.smethod_20(11498, "Software version") + ": " + text8, 2);
			}
			gclass100_0.string_2 = string_;
			if (this.bool_5 && gclass100_0.list_3 != null && gclass100_0.list_3.Count > 0)
			{
				this.list_0.Add(gclass100_0);
				List<GClass102> list = new List<GClass102>();
				GClass98 gclass2 = new GClass98(text2);
				GClass102 gclass3 = new GClass102();
				foreach (object obj in new DataView(gclass2.dataTable_0))
				{
					DataRowView dataRowView = (DataRowView)obj;
					list.Add(new GClass102
					{
						string_0 = GClass127.smethod_48(dataRowView["ErrorCode"]),
						string_2 = GClass127.smethod_48(dataRowView["Error"]),
						int_0 = GClass127.smethod_37(dataRowView["MessageID"])
					});
				}
				GClass126.smethod_2(GClass121.smethod_6("1210"), 2);
				this.string_0 = this.string_0 + GClass121.smethod_6("1210") + Environment.NewLine;
				foreach (GClass102 gclass4 in gclass100_0.list_3)
				{
					foreach (GClass102 gclass5 in list)
					{
						if (gclass5.string_0 == gclass4.string_0)
						{
							if (gclass4.string_2 != "")
							{
								GClass102 gclass6 = gclass4;
								gclass6.string_2 += " - ";
							}
							GClass102 gclass7 = gclass4;
							gclass7.string_2 += GClass121.smethod_20(gclass5.int_0, gclass5.string_2);
							if (gclass4.string_1 != "" && gclass4.string_5 != "")
							{
								GClass102 gclass8 = gclass4;
								gclass8.string_2 = gclass8.string_2 + " - " + gclass4.string_5;
								break;
							}
							break;
						}
					}
					GClass126.smethod_2(gclass4.string_2, 2);
					this.string_0 = this.string_0 + gclass4.string_2 + Environment.NewLine;
				}
			}
			this.string_0 += Environment.NewLine;
			this.bool_0 = false;
			GClass126.smethod_2("", 2);
			bool flag = gclass100_0.string_3 == GClass107.smethod_3(106275) && gclass100_0.string_5 == "6E" && gclass100_0.byte_0 == 192;
			if (this.int_2 == 0 || gclass100_0.string_4 == "111")
			{
				if (gclass100_0.string_3.Contains(GClass107.smethod_3(106302)) && !flag)
				{
					this.int_2 = 2;
				}
				else if (gclass100_0.string_3.Contains(GClass107.smethod_3(106336)) && gclass100_0.string_4 == "F4")
				{
					this.int_2 = 7;
				}
				else if (gclass100_0.string_3.Contains(GClass107.smethod_3(106347)))
				{
					this.int_2 = 3;
				}
				else if (gclass100_0.string_3.Contains(GClass107.smethod_3(106390)))
				{
					this.int_2 = 4;
				}
				else if (gclass100_0.string_3.Contains(GClass107.smethod_3(106426)))
				{
					this.int_2 = 5;
				}
				else if (gclass100_0.string_3.Contains(GClass107.smethod_3(106451)) && gclass100_0.string_4 == "F4")
				{
					this.int_2 = 8;
				}
				else if (gclass100_0.string_3.Contains(GClass107.smethod_3(106484)))
				{
					this.int_2 = 6;
				}
				else if (gclass100_0.byte_0 == 16 && gclass100_0.string_0 == GClass107.smethod_3(106527))
				{
					this.int_2 = 9;
				}
				else if (gclass100_0.byte_0 == 16 && gclass100_0.string_0 == GClass107.smethod_3(106551))
				{
					this.int_2 = 9;
				}
				else if (gclass100_0.string_4 == "111")
				{
					this.int_2 = 9;
				}
				else if (this.int_2 == 0)
				{
					this.int_2 = 1;
				}
				GClass126.smethod_2(GClass107.smethod_3(106555) + this.int_2.ToString(), 0);
			}
			if (gclass100_0.string_3.Contains(GClass107.smethod_3(106602)))
			{
				this.bool_8 = true;
			}
			if (gclass100_0.byte_0 == 203)
			{
				this.bool_7 = true;
			}
		}
	}

	// Token: 0x060004D0 RID: 1232 RVA: 0x000B1E44 File Offset: 0x000B0044
	private void method_9()
	{
		this.icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GForm7));
		this.textBox_0 = new TextBox();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.button_0 = new Button();
		this.imageList_0 = new ImageList(this.icontainer_0);
		this.button_1 = new Button();
		this.button_2 = new Button();
		this.panel_0 = new Panel();
		this.gclass109_0 = new GClass109();
		base.SuspendLayout();
		this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.BorderStyle = BorderStyle.FixedSingle;
		this.textBox_0.Font = new Font(GClass107.smethod_3(108608), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.textBox_0.ForeColor = Color.Navy;
		this.textBox_0.Location = new Point(14, 15);
		this.textBox_0.Margin = new Padding(3, 4, 3, 4);
		this.textBox_0.Multiline = true;
		this.textBox_0.Name = GClass107.smethod_3(108651);
		this.textBox_0.ScrollBars = ScrollBars.Vertical;
		this.textBox_0.Size = new Size(692, 470);
		this.textBox_0.TabIndex = 0;
		this.timer_0.Enabled = true;
		this.timer_0.Interval = 800;
		this.timer_0.Tick += this.timer_0_Tick;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_0.AutoSize = true;
		this.button_0.BackColor = Color.WhiteSmoke;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Font = new Font(GClass107.smethod_3(108653), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_0.ForeColor = Color.Navy;
		this.button_0.ImageKey = GClass107.smethod_3(108691);
		this.button_0.ImageList = this.imageList_0;
		this.button_0.Location = new Point(465, 509);
		this.button_0.Margin = new Padding(0);
		this.button_0.Name = GClass107.smethod_3(108717);
		this.button_0.Size = new Size(241, 46);
		this.button_0.TabIndex = 10;
		this.button_0.Tag = "8198";
		this.button_0.Text = GClass107.smethod_3(108756);
		this.button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_0.UseVisualStyleBackColor = false;
		this.button_0.Click += this.button_0_Click;
		this.imageList_0.ImageStream = (ImageListStreamer)componentResourceManager.GetObject(GClass107.smethod_3(108766));
		this.imageList_0.TransparentColor = Color.Transparent;
		this.imageList_0.Images.SetKeyName(0, GClass107.smethod_3(108788));
		this.imageList_0.Images.SetKeyName(1, GClass107.smethod_3(108822));
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_1.BackColor = Color.Red;
		this.button_1.FlatStyle = FlatStyle.Popup;
		this.button_1.Font = new Font(GClass107.smethod_3(108845), 8.064f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.button_1.ForeColor = Color.White;
		this.button_1.Location = new Point(14, 509);
		this.button_1.Name = GClass107.smethod_3(108872);
		this.button_1.Size = new Size(168, 36);
		this.button_1.TabIndex = 25;
		this.button_1.Tag = "1011";
		this.button_1.Text = GClass107.smethod_3(108873);
		this.button_1.UseVisualStyleBackColor = false;
		this.button_1.Visible = false;
		this.button_1.Click += this.button_1_Click;
		this.button_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_2.AutoSize = true;
		this.button_2.BackColor = Color.WhiteSmoke;
		this.button_2.Font = new Font(GClass107.smethod_3(108887), 13.8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.button_2.ForeColor = Color.Navy;
		this.button_2.ImageKey = GClass107.smethod_3(108891);
		this.button_2.ImageList = this.imageList_0;
		this.button_2.Location = new Point(115, 509);
		this.button_2.Margin = new Padding(0);
		this.button_2.Name = GClass107.smethod_3(108935);
		this.button_2.Size = new Size(285, 46);
		this.button_2.TabIndex = 26;
		this.button_2.Tag = "3002";
		this.button_2.Text = GClass107.smethod_3(108967);
		this.button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		this.button_2.UseVisualStyleBackColor = false;
		this.button_2.Visible = false;
		this.button_2.Click += this.button_2_Click;
		this.panel_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.panel_0.BackgroundImage = (Image)componentResourceManager.GetObject(GClass107.smethod_3(109006));
		this.panel_0.BackgroundImageLayout = ImageLayout.None;
		this.panel_0.Cursor = Cursors.Hand;
		this.panel_0.Location = new Point(411, 509);
		this.panel_0.Margin = new Padding(0, 0, 8, 0);
		this.panel_0.Name = GClass107.smethod_3(109050);
		this.panel_0.Size = new Size(46, 46);
		this.panel_0.TabIndex = 27;
		this.panel_0.Visible = false;
		this.panel_0.Click += this.panel_0_Click;
		this.gclass109_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.gclass109_0.method_3(null);
		this.gclass109_0.method_1((GEnum1)0);
		this.gclass109_0.ForeColor = Color.Navy;
		this.gclass109_0.Location = new Point(14, 509);
		this.gclass109_0.Margin = new Padding(3, 4, 3, 4);
		this.gclass109_0.Name = GClass107.smethod_3(109087);
		this.gclass109_0.Size = new Size(440, 46);
		this.gclass109_0.TabIndex = 11;
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		this.BackColor = Color.White;
		base.ClientSize = new Size(721, 570);
		base.ControlBox = false;
		base.Controls.Add(this.panel_0);
		base.Controls.Add(this.button_2);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.gclass109_0);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.textBox_0);
		base.KeyPreview = true;
		base.Margin = new Padding(3, 4, 3, 4);
		base.Name = GClass107.smethod_3(109096);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = GClass107.smethod_3(109103);
		base.FormClosing += this.GForm7_FormClosing;
		base.KeyUp += this.GForm7_KeyUp;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x0400035D RID: 861
	private string string_0 = "";

	// Token: 0x0400035E RID: 862
	private bool bool_0 = true;

	// Token: 0x0400035F RID: 863
	private DataTable dataTable_0 = new DataTable();

	// Token: 0x04000360 RID: 864
	private bool bool_1;

	// Token: 0x04000361 RID: 865
	private bool bool_2;

	// Token: 0x04000362 RID: 866
	private bool bool_3;

	// Token: 0x04000363 RID: 867
	private bool bool_4;

	// Token: 0x04000364 RID: 868
	private int int_0;

	// Token: 0x04000365 RID: 869
	private int int_1 = 1;

	// Token: 0x04000366 RID: 870
	private bool bool_5;

	// Token: 0x04000367 RID: 871
	private List<GClass100> list_0 = new List<GClass100>();

	// Token: 0x04000368 RID: 872
	private GClass99 gclass99_0 = new GClass99();

	// Token: 0x04000369 RID: 873
	private bool bool_6;

	// Token: 0x0400036A RID: 874
	private List<string> list_1 = new List<string>();

	// Token: 0x0400036B RID: 875
	private bool bool_7;

	// Token: 0x0400036C RID: 876
	private bool bool_8;

	// Token: 0x0400036D RID: 877
	private int int_2;

	// Token: 0x0400036E RID: 878
	private bool bool_9;

	// Token: 0x04000370 RID: 880
	private TextBox textBox_0;

	// Token: 0x04000371 RID: 881
	private System.Windows.Forms.Timer timer_0;

	// Token: 0x04000372 RID: 882
	private Button button_0;

	// Token: 0x04000373 RID: 883
	private GClass109 gclass109_0;

	// Token: 0x04000374 RID: 884
	private Button button_1;

	// Token: 0x04000375 RID: 885
	private Button button_2;

	// Token: 0x04000376 RID: 886
	private ImageList imageList_0;

	// Token: 0x04000377 RID: 887
	private Panel panel_0;

	// Token: 0x0200009B RID: 155
	// (Invoke) Token: 0x060004D2 RID: 1234
	private delegate void Delegate1();

	// Token: 0x0200009C RID: 156
	// (Invoke) Token: 0x060004D6 RID: 1238
	private delegate void Delegate2();

	// Token: 0x0200009D RID: 157
	// (Invoke) Token: 0x060004DA RID: 1242
	private delegate void Delegate3();
}
