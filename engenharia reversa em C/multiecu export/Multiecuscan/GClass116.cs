using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

// Token: 0x020000BC RID: 188
public class GClass116 : GClass115
{
	// Token: 0x06000627 RID: 1575 RVA: 0x000044DF File Offset: 0x000026DF
	public GClass116()
	{
		this.method_4();
	}

	// Token: 0x06000628 RID: 1576 RVA: 0x000044FF File Offset: 0x000026FF
	public GClass116(int int_2)
	{
		this.int_0 = int_2;
		this.method_4();
	}

	// Token: 0x06000629 RID: 1577 RVA: 0x000DCE30 File Offset: 0x000DB030
	private void method_4()
	{
		this.hsbGraph = new HScrollBar();
		this.cbXAxisParameter = new ComboBox();
		this.drawingPanel = new GClass113();
		base.SuspendLayout();
		base.BorderStyle = BorderStyle.FixedSingle;
		base.Paint += this.GClass116_Paint;
		this.BackColor = Color.White;
		this.drawingPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.drawingPanel.Location = new Point(2, 2);
		this.drawingPanel.Size = new Size(base.Width - 4, base.Height - 26);
		this.drawingPanel.Name = "drawingPanel";
		this.drawingPanel.Paint += this.drawingPanel_Paint;
		this.drawingPanel.MouseClick += this.drawingPanel_MouseClick;
		this.drawingPanel.BackColor = Color.Black;
		base.Controls.Add(this.drawingPanel);
		this.cbXAxisParameter.DropDownStyle = ComboBoxStyle.DropDownList;
		this.cbXAxisParameter.FlatStyle = FlatStyle.Flat;
		this.cbXAxisParameter.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.cbXAxisParameter.FormattingEnabled = true;
		GClass105 gclass = GClass126.smethod_0();
		this.cbXAxisParameter.Items.Add(GClass121.smethod_6("5041"));
		this.string_0 = "";
		if (gclass != null)
		{
			for (int i = 0; i < gclass.list_0.Count; i++)
			{
				this.cbXAxisParameter.Items.Add(gclass.list_0[i]);
				this.string_0 = this.string_0 + gclass.list_0[i] + "|";
			}
		}
		this.cbXAxisParameter.SelectedIndex = 0;
		this.cbXAxisParameter.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.cbXAxisParameter.Location = new Point(base.Width - 197, base.Height - 24);
		this.cbXAxisParameter.Name = "cbXAxisParameter";
		this.cbXAxisParameter.Size = new Size(195, 22);
		this.cbXAxisParameter.BackColor = Color.FromArgb(248, 248, 168);
		this.cbXAxisParameter.TabIndex = 2;
		this.cbXAxisParameter.Tag = "5041";
		this.cbXAxisParameter.SelectedIndexChanged += this.cbXAxisParameter_SelectedIndexChanged;
		base.Controls.Add(this.cbXAxisParameter);
		this.hsbGraph.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.hsbGraph.Location = new Point(2, base.Height - 24);
		this.hsbGraph.Name = "hsbGraph";
		this.hsbGraph.Size = new Size(base.Width - 201, 22);
		this.hsbGraph.Scroll += this.hsbGraph_Scroll;
		this.hsbGraph.TabIndex = 0;
		base.Controls.Add(this.hsbGraph);
		base.ResumeLayout(false);
	}

	// Token: 0x0600062A RID: 1578 RVA: 0x000DD148 File Offset: 0x000DB348
	public override void ScrollIncrease(bool bool_1)
	{
		if (!this.hsbGraph.Visible)
		{
			return;
		}
		int num = this.hsbGraph.Value + (bool_1 ? this.hsbGraph.LargeChange : this.hsbGraph.SmallChange);
		if (num > this.hsbGraph.Maximum)
		{
			num = this.hsbGraph.Maximum;
			this.int_1 += (int)((float)(bool_1 ? this.hsbGraph.LargeChange : this.hsbGraph.SmallChange) * this.float_0);
		}
		if (num < this.hsbGraph.Minimum)
		{
			num = this.hsbGraph.Minimum;
		}
		if (this.int_1 < 70)
		{
			this.int_1 = 60 + (int)(2f * this.float_0);
		}
		this.hsbGraph.Value = num;
	}

	// Token: 0x0600062B RID: 1579 RVA: 0x000DD21C File Offset: 0x000DB41C
	public override void ScrollDescrease(bool bool_1)
	{
		if (!this.hsbGraph.Visible)
		{
			return;
		}
		int num = this.hsbGraph.Value - (bool_1 ? this.hsbGraph.LargeChange : this.hsbGraph.SmallChange);
		if (num > this.hsbGraph.Maximum)
		{
			num = this.hsbGraph.Maximum;
		}
		if (num < this.hsbGraph.Minimum)
		{
			num = this.hsbGraph.Minimum;
			this.int_1 -= (int)((float)(bool_1 ? this.hsbGraph.LargeChange : this.hsbGraph.SmallChange) * this.float_0);
		}
		this.hsbGraph.Value = num;
	}

	// Token: 0x0600062C RID: 1580 RVA: 0x00004526 File Offset: 0x00002726
	private void hsbGraph_Scroll(object sender, ScrollEventArgs e)
	{
		this.drawingPanel.Invalidate();
	}

	// Token: 0x0600062D RID: 1581 RVA: 0x000DD2D0 File Offset: 0x000DB4D0
	private void method_5(Graphics graphics_0)
	{
		GClass105 gclass = GClass126.smethod_0();
		string text = "";
		if (gclass != null)
		{
			for (int i = 0; i < gclass.list_0.Count; i++)
			{
				text = text + gclass.list_0[i] + "|";
			}
		}
		if (text != this.string_0)
		{
			string b = GClass127.smethod_48(this.cbXAxisParameter.SelectedItem);
			this.cbXAxisParameter.Items.Clear();
			this.cbXAxisParameter.Items.Add(GClass121.smethod_6("5041"));
			this.string_0 = "";
			int selectedIndex = 0;
			if (gclass != null)
			{
				for (int j = 0; j < gclass.list_0.Count; j++)
				{
					this.cbXAxisParameter.Items.Add(gclass.list_0[j]);
					this.string_0 = this.string_0 + gclass.list_0[j] + "|";
					if (gclass.list_0[j] == b)
					{
						selectedIndex = j;
					}
				}
			}
			this.cbXAxisParameter.SelectedIndex = selectedIndex;
		}
		if (!GClass126.bool_12 && GClass125.smethod_67() < 2)
		{
			graphics_0.SmoothingMode = SmoothingMode.HighQuality;
		}
		else
		{
			graphics_0.SmoothingMode = SmoothingMode.None;
		}
		if (this.cbXAxisParameter.SelectedIndex > 0)
		{
			this.method_6(graphics_0);
			return;
		}
		if (gclass == null)
		{
			return;
		}
		if (gclass.list_0.Count == 0)
		{
			return;
		}
		float num = graphics_0.VisibleClipBounds.Width - 60f - 4f;
		float num2 = graphics_0.VisibleClipBounds.Height - 20f - 4f;
		float float_ = this.float_0;
		if (float_ == 0f)
		{
			return;
		}
		int num3 = 40;
		if (this.int_1 < 0)
		{
			this.int_1 = 0;
		}
		if ((float)this.int_1 > num)
		{
			this.int_1 = (int)num;
		}
		if (gclass.list_3.Count > 0)
		{
			float num4 = (float)((int)((float)gclass.list_3.Count * float_));
			bool flag = this.hsbGraph.Value > this.hsbGraph.Maximum - 30 && GClass126.bool_12;
			if (num4 > num)
			{
				this.hsbGraph.Maximum = gclass.list_3.Count - (int)(num / float_);
				this.hsbGraph.Enabled = true;
				if (flag || this.bool_0)
				{
					this.hsbGraph.Value = this.hsbGraph.Maximum;
				}
			}
			else
			{
				this.hsbGraph.Maximum = 0;
				this.hsbGraph.Enabled = false;
			}
		}
		else
		{
			this.hsbGraph.Maximum = 0;
			this.hsbGraph.Enabled = false;
		}
		this.bool_0 = false;
		List<string> list = new List<string>();
		List<float> list2 = new List<float>();
		List<Color> list3 = new List<Color>();
		List<decimal> list4 = new List<decimal>();
		List<decimal> list5 = new List<decimal>();
		for (int k = 0; k < gclass.list_0.Count; k++)
		{
			if (gclass.list_2[k][this.int_0])
			{
				int num5 = -1;
				int l = 0;
				while (l < list.Count)
				{
					if (!(list[l] == gclass.list_1[k]))
					{
						l++;
					}
					else
					{
						num5 = l;
						IL_329:
						float num6 = 1f;
						if (num5 == -1)
						{
							list.Add(gclass.list_1[k]);
							list4.Add(gclass.list_4[k]);
							list5.Add(gclass.list_5[k]);
							if (gclass.list_5[k] - gclass.list_4[k] != 0m)
							{
								num6 = num2 / decimal.ToSingle(gclass.list_5[k] - gclass.list_4[k]);
							}
							if (num6 > 100000f)
							{
								num6 = 100000f;
							}
							if (num6 == 0f)
							{
								num6 = 1f;
							}
							list2.Add(num6);
							list3.Add(GClass125.smethod_101(k));
							goto IL_4D7;
						}
						if (list4[num5] > gclass.list_4[k])
						{
							list4[num5] = gclass.list_4[k];
						}
						if (list5[num5] < gclass.list_5[k])
						{
							list5[num5] = gclass.list_5[k];
						}
						if (list5[num5] - list4[num5] != 0m)
						{
							num6 = num2 / decimal.ToSingle(list5[num5] - list4[num5]);
						}
						if (num6 > 100000f)
						{
							num6 = 100000f;
						}
						if (num6 == 0f)
						{
							num6 = 1f;
						}
						list2[num5] = num6;
						goto IL_4D7;
					}
				}
				goto IL_329;
			}
			IL_4D7:;
		}
		if (GClass125.smethod_67() == 2)
		{
			Thread.Sleep(3);
		}
		else
		{
			Thread.Sleep(1);
		}
		this.drawingPanel.BackColor = GClass125.smethod_103();
		Pen pen = new Pen(GClass125.smethod_105(), 1f);
		pen.DashStyle = DashStyle.Dot;
		graphics_0.DrawLine(pen, 60f, 4f, 60f, num2 + 4f);
		graphics_0.DrawLine(pen, num + 60f, 4f, num + 60f, num2 + 4f);
		int num7 = 100;
		while ((float)num7 < num + 60f)
		{
			graphics_0.DrawLine(pen, (float)num7, 4f, (float)num7, num2 + 4f);
			num7 += 40;
		}
		new Pen(GClass125.smethod_105(), 1f).DashStyle = DashStyle.Dot;
		graphics_0.DrawLine(pen, 60f, 4f, num + 60f, 4f);
		graphics_0.DrawLine(pen, 60f, num2 + 4f, num + 60f, num2 + 4f);
		int num8 = (int)(num2 + 4f - (float)num3);
		while ((float)num8 > 4f)
		{
			graphics_0.DrawLine(pen, 60f, (float)num8, num + 60f, (float)num8);
			num8 -= num3;
		}
		Font font = GClass125.smethod_111();
		int num9 = (int)graphics_0.MeasureString("1290", font).Height;
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Far;
		for (int m = 0; m < list2.Count; m++)
		{
			SolidBrush brush = new SolidBrush(list3[m]);
			int num10 = (int)(num2 + 4f);
			while ((float)num10 > 4f)
			{
				string format = "{0:0.000}";
				double num11 = (double)((float)list4[m] + (num2 + 4f - (float)num10) / list2[m]);
				if (Math.Abs(num11) > 10.0)
				{
					format = "{0:0.00}";
				}
				if (Math.Abs(num11) > 100.0)
				{
					format = "{0:0.0}";
				}
				if (Math.Abs(num11) > 1000.0)
				{
					format = "{0:0}";
				}
				graphics_0.DrawString(string.Format(format, num11) + " " + list[m], font, brush, 58f, (float)(num10 - m * 10), stringFormat);
				num10 -= num3;
			}
		}
		Font font2 = GClass125.smethod_115();
		stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Far;
		int num12 = 9;
		int num13 = (int)graphics_0.MeasureString("Test", font2).Height;
		for (int n = 0; n < gclass.list_0.Count; n++)
		{
			if (gclass.list_2[n][this.int_0])
			{
				SolidBrush brush2 = new SolidBrush(GClass125.smethod_101(n));
				graphics_0.DrawString(gclass.list_0[n], font2, brush2, 60f + num - 3f, (float)num12, stringFormat);
				num12 += num13;
			}
		}
		Font font3 = GClass125.smethod_113();
		stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		SolidBrush brush3 = new SolidBrush(GClass125.smethod_107());
		StringFormat stringFormat2 = new StringFormat();
		stringFormat2.Alignment = StringAlignment.Near;
		bool flag2 = false;
		Pen pen2 = new Pen(Color.Red, 1f);
		pen2.DashStyle = DashStyle.Dash;
		SolidBrush brush4 = new SolidBrush(Color.Red);
		for (int num14 = 0; num14 < gclass.list_0.Count; num14++)
		{
			if (GClass125.smethod_67() == 2)
			{
				Thread.Sleep(2);
			}
			else
			{
				Thread.Sleep(1);
			}
			if (gclass.list_2[num14][this.int_0])
			{
				Pen pen3 = new Pen(GClass125.smethod_101(num14), (float)GClass125.smethod_109());
				int num15 = this.hsbGraph.Value;
				if (gclass.list_3.Count < num15)
				{
					num15 = gclass.list_3.Count;
				}
				float y = num2 + 4f;
				float num16 = 60f - float_;
				float num17 = num2 + 4f;
				int num18 = 0;
				float num19 = 1f;
				decimal d = 0m;
				for (int num20 = 0; num20 < list.Count; num20++)
				{
					if (list[num20] == gclass.list_1[num14])
					{
						num19 = list2[num20];
						d = list4[num20];
						IL_952:
						int num21 = 100;
						int num22 = num15;
						while (num22 < gclass.list_3.Count && num22 < num15 + (int)(num / float_))
						{
							float num23 = num16;
							y = num17;
							num16 += float_;
							num17 = num2 + 4f - decimal.ToSingle(gclass.list_3[num22].list_1[num14] - d) * num19;
							if (num18 > 0)
							{
								graphics_0.DrawLine(pen3, num23, y, num16, num17);
							}
							if (num16 >= (float)num21 && num23 < (float)num21)
							{
								graphics_0.DrawString(string.Format("{0:0.0}", (double)((float)gclass.list_3[num22].int_0) / 1000.0), font3, brush3, num16, num2 + 4f + 3f, stringFormat);
								num21 += 40;
							}
							if (gclass.list_3[num22].string_0 != null && gclass.list_3[num22].string_0.Length > 0)
							{
								graphics_0.DrawString(gclass.list_3[num22].string_0, font3, brush3, num16, num17, stringFormat);
							}
							if (gclass.list_3[num22].string_1 != null && gclass.list_3[num22].string_1.Length > 0 && (num22 < 1 || gclass.list_3[num22].string_1 != gclass.list_3[num22 - 1].string_1) && num14 == 0)
							{
								graphics_0.DrawString(gclass.list_3[num22].string_1, font, brush4, num16, num2 + 4f - (float)num9 - 2f, stringFormat2);
								graphics_0.DrawLine(pen2, num16, 4f, num16, num2 + 4f);
							}
							if (!GClass126.bool_12 && (float)this.int_1 > num16 - float_ / 2f && (float)this.int_1 < num16 + float_ / 2f && (float)this.int_1 >= 60f)
							{
								decimal num24 = gclass.list_3[num22].list_1[num14];
								string format2 = "{0:0.000}";
								if (Math.Abs(num24) > 10m)
								{
									format2 = "{0:0.00}";
								}
								if (Math.Abs(num24) > 100m)
								{
									format2 = "{0:0.0}";
								}
								if (Math.Abs(num24) > 1000m)
								{
									format2 = "{0:0}";
								}
								SolidBrush brush5 = new SolidBrush(GClass125.smethod_101(num14));
								graphics_0.DrawString(string.Format(format2, num24) + " " + gclass.list_1[num14], font3, brush5, num16 + 2f, num17, stringFormat2);
								this.int_1 = (int)num16;
								flag2 = true;
							}
							num18++;
							num22++;
						}
						goto IL_C56;
					}
				}
				goto IL_952;
			}
			IL_C56:;
		}
		if (flag2)
		{
			graphics_0.DrawLine(new Pen(GClass125.smethod_107(), 1f)
			{
				DashStyle = DashStyle.Dash
			}, (float)this.int_1, 4f, (float)this.int_1, num2 + 4f);
		}
	}

	// Token: 0x0600062E RID: 1582 RVA: 0x000DDF8C File Offset: 0x000DC18C
	private void method_6(Graphics graphics_0)
	{
		float num = graphics_0.VisibleClipBounds.Width - 60f - 4f;
		float num2 = graphics_0.VisibleClipBounds.Height - 20f - 4f;
		GClass105 gclass = GClass126.smethod_0();
		if (gclass == null)
		{
			return;
		}
		if (gclass.list_0.Count == 0)
		{
			return;
		}
		List<string> list = new List<string>();
		List<float> list2 = new List<float>();
		List<Color> list3 = new List<Color>();
		List<decimal> list4 = new List<decimal>();
		List<decimal> list5 = new List<decimal>();
		int num3 = -1;
		decimal num4 = 0m;
		decimal d = 0m;
		float num5 = 0f;
		for (int i = 0; i < gclass.list_0.Count; i++)
		{
			if (this.cbXAxisParameter.SelectedIndex - 1 == i)
			{
				num3 = i;
				num4 = gclass.list_4[i];
				d = gclass.list_5[i];
				num5 = 1f;
				if (gclass.list_5[i] - gclass.list_4[i] != 0m)
				{
					num5 = num / decimal.ToSingle(gclass.list_5[i] - gclass.list_4[i]);
				}
				if (num5 > 100000f)
				{
					num5 = 100000f;
				}
				if (num5 == 0f)
				{
					num5 = 1f;
				}
			}
			if (gclass.list_2[i][this.int_0])
			{
				int num6 = -1;
				int j = 0;
				while (j < list.Count)
				{
					if (!(list[j] == gclass.list_1[i]))
					{
						j++;
					}
					else
					{
						num6 = j;
						IL_197:
						float num7 = 1f;
						if (num6 == -1)
						{
							list.Add(gclass.list_1[i]);
							list4.Add(gclass.list_4[i]);
							list5.Add(gclass.list_5[i]);
							if (gclass.list_5[i] - gclass.list_4[i] != 0m)
							{
								num7 = num2 / decimal.ToSingle(gclass.list_5[i] - gclass.list_4[i]);
							}
							if (num7 > 100000f)
							{
								num7 = 100000f;
							}
							if (num7 == 0f)
							{
								num7 = 1f;
							}
							list2.Add(num7);
							list3.Add(GClass125.smethod_101(i));
							goto IL_344;
						}
						if (list4[num6] > gclass.list_4[i])
						{
							list4[num6] = gclass.list_4[i];
						}
						if (list5[num6] < gclass.list_5[i])
						{
							list5[num6] = gclass.list_5[i];
						}
						if (list5[num6] - list4[num6] != 0m)
						{
							num7 = num2 / decimal.ToSingle(list5[num6] - list4[num6]);
						}
						if (num7 > 100000f)
						{
							num7 = 100000f;
						}
						if (num7 == 0f)
						{
							num7 = 1f;
						}
						list2[num6] = num7;
						goto IL_344;
					}
				}
				goto IL_197;
			}
			IL_344:;
		}
		if (num3 == -1)
		{
			return;
		}
		decimal num8 = d - num4;
		if (num8 == 0.0m)
		{
			return;
		}
		List<GClass101> list6 = new List<GClass101>();
		for (int k = 0; k < gclass.list_3.Count; k++)
		{
			list6.Add(new GClass101(k, gclass.list_3[k].list_1[num3]));
		}
		Class7.smethod_0(list6);
		float num9 = decimal.ToSingle(num8) / num;
		if (num9 == 0f)
		{
			return;
		}
		int num10 = 40;
		int num11 = 40;
		if (this.int_1 < 0)
		{
			this.int_1 = 0;
		}
		if ((float)this.int_1 > num)
		{
			this.int_1 = (int)num;
		}
		if (GClass125.smethod_67() == 2)
		{
			Thread.Sleep(3);
		}
		else
		{
			Thread.Sleep(1);
		}
		this.drawingPanel.BackColor = GClass125.smethod_103();
		Pen pen = new Pen(GClass125.smethod_105(), 1f);
		pen.DashStyle = DashStyle.Dot;
		graphics_0.DrawLine(pen, 60f, 4f, 60f, num2 + 4f);
		graphics_0.DrawLine(pen, num + 60f, 4f, num + 60f, num2 + 4f);
		int num12 = 100;
		while ((float)num12 < num + 60f)
		{
			graphics_0.DrawLine(pen, (float)num12, 4f, (float)num12, num2 + 4f);
			num12 += num10;
		}
		new Pen(GClass125.smethod_105(), 1f).DashStyle = DashStyle.Dot;
		graphics_0.DrawLine(pen, 60f, 4f, num + 60f, 4f);
		graphics_0.DrawLine(pen, 60f, num2 + 4f, num + 60f, num2 + 4f);
		int num13 = (int)(num2 + 4f - (float)num11);
		while ((float)num13 > 4f)
		{
			graphics_0.DrawLine(pen, 60f, (float)num13, num + 60f, (float)num13);
			num13 -= num11;
		}
		Font font = GClass125.smethod_111();
		float height = graphics_0.MeasureString("1290", font).Height;
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Far;
		for (int l = 0; l < list2.Count; l++)
		{
			SolidBrush brush = new SolidBrush(list3[l]);
			int num14 = (int)(num2 + 4f);
			while ((float)num14 > 4f)
			{
				string format = "{0:0.000}";
				double num15 = (double)(decimal.ToSingle(list4[l]) + (num2 + 4f - (float)num14) / list2[l]);
				if (Math.Abs(num15) > 10.0)
				{
					format = "{0:0.00}";
				}
				if (Math.Abs(num15) > 100.0)
				{
					format = "{0:0.0}";
				}
				if (Math.Abs(num15) > 1000.0)
				{
					format = "{0:0}";
				}
				graphics_0.DrawString(string.Format(format, num15) + " " + list[l], font, brush, 58f, (float)(num14 - l * 10), stringFormat);
				num14 -= num11;
			}
		}
		Font font2 = GClass125.smethod_115();
		stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Far;
		int num16 = 9;
		int num17 = (int)graphics_0.MeasureString("Test", font2).Height;
		for (int m = 0; m < gclass.list_0.Count; m++)
		{
			if (gclass.list_2[m][this.int_0])
			{
				SolidBrush brush2 = new SolidBrush(GClass125.smethod_101(m));
				graphics_0.DrawString(gclass.list_0[m], font2, brush2, 60f + num - 3f, (float)num16, stringFormat);
				num16 += num17;
			}
		}
		Font font3 = GClass125.smethod_113();
		stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		SolidBrush brush3 = new SolidBrush(GClass125.smethod_107());
		for (float num18 = 0f; num18 < num; num18 += 40f)
		{
			float num19 = decimal.ToSingle(num4) + num9 * num18;
			string format2 = "{0:0.000}";
			if (Math.Abs(num19) > 10f)
			{
				format2 = "{0:0.00}";
			}
			if (Math.Abs(num19) > 100f)
			{
				format2 = "{0:0.0}";
			}
			if (Math.Abs(num19) > 1000f)
			{
				format2 = "{0:0}";
			}
			graphics_0.DrawString(string.Format(format2, num19), font3, brush3, 60f + num18, num2 + 4f + 3f, stringFormat);
		}
		Font font4 = GClass125.smethod_113();
		stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		StringFormat stringFormat2 = new StringFormat();
		stringFormat2.Alignment = StringAlignment.Near;
		bool flag = false;
		new Pen(Color.Red, 1f).DashStyle = DashStyle.Dash;
		new SolidBrush(Color.Red);
		for (int n = 0; n < gclass.list_0.Count; n++)
		{
			if (GClass125.smethod_67() == 2)
			{
				Thread.Sleep(2);
			}
			else
			{
				Thread.Sleep(1);
			}
			if (gclass.list_2[n][this.int_0])
			{
				Pen pen2 = new Pen(GClass125.smethod_101(n), (float)GClass125.smethod_109());
				float y = num2 + 4f;
				float num20 = 60f;
				float num21 = num2 + 4f;
				float num22 = 1f;
				decimal d2 = 0m;
				for (int num23 = 0; num23 < list.Count; num23++)
				{
					if (list[num23] == gclass.list_1[n])
					{
						num22 = list2[num23];
						d2 = list4[num23];
						IL_8F0:
						for (int num24 = 0; num24 < list6.Count; num24++)
						{
							int int_ = list6[num24].int_0;
							float num25 = num20;
							y = num21;
							num20 = 60f + decimal.ToSingle(gclass.list_3[int_].list_1[num3] - num4) * num5;
							num21 = num2 + 4f - decimal.ToSingle(gclass.list_3[int_].list_1[n] - d2) * num22;
							if (num24 > 0)
							{
								graphics_0.DrawLine(pen2, num25, y, num20, num21);
							}
							if (!GClass126.bool_12 && (float)this.int_1 > num25 && (float)this.int_1 < num20 && (float)this.int_1 >= 60f)
							{
								decimal num26 = gclass.list_3[int_].list_1[n];
								string format3 = "{0:0.000}";
								if (Math.Abs(num26) > 10m)
								{
									format3 = "{0:0.00}";
								}
								if (Math.Abs(num26) > 100m)
								{
									format3 = "{0:0.0}";
								}
								if (Math.Abs(num26) > 1000m)
								{
									format3 = "{0:0}";
								}
								SolidBrush brush4 = new SolidBrush(GClass125.smethod_101(n));
								graphics_0.DrawString(string.Format(format3, num26) + " " + gclass.list_1[n], font4, brush4, num20 + 2f, num21, stringFormat2);
								this.int_1 = (int)num20;
								flag = true;
							}
						}
						goto IL_AA0;
					}
				}
				goto IL_8F0;
			}
			IL_AA0:;
		}
		if (flag)
		{
			graphics_0.DrawLine(new Pen(GClass125.smethod_107(), 1f)
			{
				DashStyle = DashStyle.Dash
			}, (float)this.int_1, 4f, (float)this.int_1, num2 + 4f);
		}
	}

	// Token: 0x0600062F RID: 1583 RVA: 0x00004533 File Offset: 0x00002733
	private void cbXAxisParameter_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.hsbGraph.Visible = (this.cbXAxisParameter.SelectedIndex == 0);
		this.drawingPanel.Invalidate();
	}

	// Token: 0x06000630 RID: 1584 RVA: 0x000DEA90 File Offset: 0x000DCC90
	private void drawingPanel_Paint(object sender, PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		this.method_5(graphics);
	}

	// Token: 0x06000631 RID: 1585 RVA: 0x00004526 File Offset: 0x00002726
	private void GClass116_Paint(object sender, PaintEventArgs e)
	{
		this.drawingPanel.Invalidate();
	}

	// Token: 0x06000632 RID: 1586 RVA: 0x00004559 File Offset: 0x00002759
	private void drawingPanel_MouseClick(object sender, MouseEventArgs e)
	{
		this.int_1 = e.X;
		this.drawingPanel.Invalidate();
	}

	// Token: 0x0400056F RID: 1391
	private bool bool_0 = true;

	// Token: 0x04000570 RID: 1392
	private const float float_1 = 60f;

	// Token: 0x04000571 RID: 1393
	private const float float_2 = 20f;

	// Token: 0x04000572 RID: 1394
	private const float float_3 = 4f;

	// Token: 0x04000573 RID: 1395
	private const float float_4 = 4f;

	// Token: 0x04000574 RID: 1396
	private const float float_5 = 40f;

	// Token: 0x04000575 RID: 1397
	private string string_0 = "";

	// Token: 0x04000576 RID: 1398
	private ComboBox cbXAxisParameter;

	// Token: 0x04000577 RID: 1399
	private HScrollBar hsbGraph;

	// Token: 0x04000578 RID: 1400
	private GClass113 drawingPanel;
}
