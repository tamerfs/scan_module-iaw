using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

// Token: 0x02000083 RID: 131
public sealed class GClass65 : Panel
{
	// Token: 0x060004C4 RID: 1220 RVA: 0x00003888 File Offset: 0x00001A88
	public GClass65()
	{
		this.method_0();
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x000038B6 File Offset: 0x00001AB6
	public GClass65(int int_2)
	{
		this.int_0 = int_2;
		this.method_0();
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x0008E028 File Offset: 0x0008C228
	private void method_0()
	{
		this.hsbGraph = new HScrollBar();
		this.drawingPanel = new GClass63();
		base.SuspendLayout();
		base.BorderStyle = BorderStyle.FixedSingle;
		base.Paint += this.GClass65_Paint;
		this.BackColor = Color.White;
		this.drawingPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.drawingPanel.Location = new Point(2, 2);
		this.drawingPanel.Size = new Size(base.Width - 4, base.Height - 19);
		this.drawingPanel.Name = "drawingPanel";
		this.drawingPanel.Paint += this.drawingPanel_Paint;
		this.drawingPanel.MouseClick += this.drawingPanel_MouseClick;
		this.drawingPanel.BackColor = Color.Black;
		base.Controls.Add(this.drawingPanel);
		this.hsbGraph.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.hsbGraph.Location = new Point(2, base.Height - 17);
		this.hsbGraph.Name = "hsbGraph";
		this.hsbGraph.Size = new Size(base.Width - 4, 15);
		this.hsbGraph.Scroll += this.hsbGraph_Scroll;
		this.hsbGraph.TabIndex = 0;
		base.Controls.Add(this.hsbGraph);
		base.ResumeLayout(false);
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x0008E1A0 File Offset: 0x0008C3A0
	public float method_1()
	{
		return this.float_0;
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x000038EB File Offset: 0x00001AEB
	public void method_2(float float_1)
	{
		this.float_0 = float_1;
	}

	// Token: 0x060004C9 RID: 1225 RVA: 0x0008E1B8 File Offset: 0x0008C3B8
	public int method_3()
	{
		return this.int_0;
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x000038F4 File Offset: 0x00001AF4
	public void method_4(int int_2)
	{
		this.int_0 = int_2;
	}

	// Token: 0x060004CB RID: 1227 RVA: 0x0008E1D0 File Offset: 0x0008C3D0
	public void method_5(bool bool_1)
	{
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

	// Token: 0x060004CC RID: 1228 RVA: 0x0008E2A8 File Offset: 0x0008C4A8
	public void method_6(bool bool_1)
	{
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

	// Token: 0x060004CD RID: 1229 RVA: 0x000038FD File Offset: 0x00001AFD
	private void hsbGraph_Scroll(object sender, ScrollEventArgs e)
	{
		this.drawingPanel.Invalidate();
	}

	// Token: 0x060004CE RID: 1230 RVA: 0x0008E358 File Offset: 0x0008C558
	private void method_7(Graphics graphics_0)
	{
		if (!GClass3.bool_4 && GClass61.smethod_51() < 2)
		{
			graphics_0.SmoothingMode = SmoothingMode.HighQuality;
		}
		else
		{
			graphics_0.SmoothingMode = SmoothingMode.None;
		}
		float num = graphics_0.VisibleClipBounds.Width - 60f - 4f;
		float num2 = graphics_0.VisibleClipBounds.Height - 20f - 4f;
		float num3 = this.float_0;
		if (num3 != 0f)
		{
			int num4 = 40;
			if (this.int_1 < 0)
			{
				this.int_1 = 0;
			}
			if ((float)this.int_1 > num)
			{
				this.int_1 = (int)num;
			}
			GClass0 gclass = GClass3.smethod_0();
			if (gclass != null && gclass.list_0.Count != 0)
			{
				if (gclass.list_3.Count > 0)
				{
					int num5 = (int)((float)gclass.list_3.Count * num3);
					bool flag = this.hsbGraph.Value > this.hsbGraph.Maximum - 30 && GClass3.bool_4;
					if ((float)num5 > num)
					{
						this.hsbGraph.Maximum = gclass.list_3.Count - (int)(num / num3);
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
				int i;
				for (i = 0; i < gclass.list_0.Count; i++)
				{
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
								IL_23A:
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
									list3.Add(GClass61.smethod_69(i));
									goto IL_41A;
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
								goto IL_41A;
							}
						}
						goto IL_23A;
					}
					IL_41A:;
				}
				if (GClass61.smethod_51() == 2)
				{
					Thread.Sleep(3);
				}
				else
				{
					Thread.Sleep(1);
				}
				this.drawingPanel.BackColor = GClass61.smethod_71();
				Pen pen = new Pen(GClass61.smethod_73(), 1f);
				pen.DashStyle = DashStyle.Dot;
				graphics_0.DrawLine(pen, 60f, 4f, 60f, num2 + 4f);
				graphics_0.DrawLine(pen, num + 60f, 4f, num + 60f, num2 + 4f);
				i = 100;
				while ((float)i < num + 60f)
				{
					graphics_0.DrawLine(pen, (float)i, 4f, (float)i, num2 + 4f);
					i += 40;
				}
				Pen pen2 = new Pen(GClass61.smethod_73(), 1f);
				pen2.DashStyle = DashStyle.Dot;
				graphics_0.DrawLine(pen, 60f, 4f, num + 60f, 4f);
				graphics_0.DrawLine(pen, 60f, num2 + 4f, num + 60f, num2 + 4f);
				i = (int)(num2 + 4f - (float)num4);
				while ((float)i > 4f)
				{
					graphics_0.DrawLine(pen, 60f, (float)i, num + 60f, (float)i);
					i -= num4;
				}
				Font font = GClass61.smethod_79();
				int num8 = (int)graphics_0.MeasureString("1290", font).Height;
				StringFormat stringFormat = new StringFormat();
				stringFormat.Alignment = StringAlignment.Far;
				for (int j = 0; j < list2.Count; j++)
				{
					SolidBrush brush = new SolidBrush(list3[j]);
					i = (int)(num2 + 4f);
					while ((float)i > 4f)
					{
						string format = "{0:0.000}";
						double num9 = (double)((float)list4[j] + (num2 + 4f - (float)i) / list2[j]);
						if (Math.Abs(num9) > 10.0)
						{
							format = "{0:0.00}";
						}
						if (Math.Abs(num9) > 100.0)
						{
							format = "{0:0.0}";
						}
						if (Math.Abs(num9) > 1000.0)
						{
							format = "{0:0}";
						}
						graphics_0.DrawString(string.Format(format, num9) + " " + list[j], font, brush, 58f, (float)(i - j * 10), stringFormat);
						i -= num4;
					}
				}
				Font font2 = GClass61.smethod_83();
				stringFormat = new StringFormat();
				stringFormat.Alignment = StringAlignment.Far;
				int num10 = 9;
				int num11 = (int)graphics_0.MeasureString("Test", font2).Height;
				for (i = 0; i < gclass.list_0.Count; i++)
				{
					if (gclass.list_2[i][this.int_0])
					{
						SolidBrush brush2 = new SolidBrush(GClass61.smethod_69(i));
						graphics_0.DrawString(gclass.list_0[i], font2, brush2, 60f + num - 3f, (float)num10, stringFormat);
						num10 += num11;
					}
				}
				Font font3 = GClass61.smethod_81();
				stringFormat = new StringFormat();
				stringFormat.Alignment = StringAlignment.Center;
				SolidBrush brush3 = new SolidBrush(GClass61.smethod_75());
				StringFormat stringFormat2 = new StringFormat();
				stringFormat2.Alignment = StringAlignment.Near;
				bool flag2 = false;
				Pen pen3 = new Pen(Color.Red, 1f);
				pen3.DashStyle = DashStyle.Dash;
				SolidBrush brush4 = new SolidBrush(Color.Red);
				for (i = 0; i < gclass.list_0.Count; i++)
				{
					if (GClass61.smethod_51() == 2)
					{
						Thread.Sleep(2);
					}
					else
					{
						Thread.Sleep(1);
					}
					if (gclass.list_2[i][this.int_0])
					{
						Pen pen4 = new Pen(GClass61.smethod_69(i), (float)GClass61.smethod_77());
						int num12 = this.hsbGraph.Value;
						if (gclass.list_3.Count < num12)
						{
							num12 = gclass.list_3.Count;
						}
						float y = num2 + 4f;
						float num13 = 60f - num3;
						float num14 = num2 + 4f;
						int num15 = 0;
						float num16 = 1f;
						decimal d = 0m;
						for (int j = 0; j < list.Count; j++)
						{
							if (list[j] == gclass.list_1[i])
							{
								num16 = list2[j];
								d = list4[j];
								IL_8CF:
								int num17 = 100;
								j = num12;
								while (j < gclass.list_3.Count && j < num12 + (int)(num / num3))
								{
									float num18 = num13;
									y = num14;
									num13 += num3;
									num14 = num2 + 4f - decimal.ToSingle(gclass.list_3[j].list_1[i] - d) * num16;
									if (num15 > 0)
									{
										graphics_0.DrawLine(pen4, num18, y, num13, num14);
									}
									if (num13 >= (float)num17 && num18 < (float)num17)
									{
										graphics_0.DrawString(string.Format("{0:0.0}", (double)((float)gclass.list_3[j].int_0) / 1000.0), font3, brush3, num13, num2 + 4f + 3f, stringFormat);
										num17 += 40;
									}
									if (gclass.list_3[j].string_0 != null && gclass.list_3[j].string_0.Length > 0)
									{
										graphics_0.DrawString(gclass.list_3[j].string_0, font3, brush3, num13, num14, stringFormat);
									}
									if (gclass.list_3[j].string_1 != null && gclass.list_3[j].string_1.Length > 0 && (j < 1 || gclass.list_3[j].string_1 != gclass.list_3[j - 1].string_1) && i == 0)
									{
										graphics_0.DrawString(gclass.list_3[j].string_1, font, brush4, num13, num2 + 4f - (float)num8 - 2f, stringFormat2);
										graphics_0.DrawLine(pen3, num13, 4f, num13, num2 + 4f);
									}
									if (!GClass3.bool_4 && (float)this.int_1 > num13 - num3 / 2f && (float)this.int_1 < num13 + num3 / 2f && (float)this.int_1 >= 60f)
									{
										decimal num19 = gclass.list_3[j].list_1[i];
										string format2 = "{0:0.000}";
										if (Math.Abs(num19) > 10m)
										{
											format2 = "{0:0.00}";
										}
										if (Math.Abs(num19) > 100m)
										{
											format2 = "{0:0.0}";
										}
										if (Math.Abs(num19) > 1000m)
										{
											format2 = "{0:0}";
										}
										SolidBrush brush5 = new SolidBrush(GClass61.smethod_69(i));
										graphics_0.DrawString(string.Format(format2, num19) + " " + gclass.list_1[i], font3, brush5, num13 + 2f, num14, stringFormat2);
										this.int_1 = (int)num13;
										flag2 = true;
									}
									num15++;
									j++;
								}
								goto IL_C08;
							}
						}
						goto IL_8CF;
					}
					IL_C08:;
				}
				if (flag2)
				{
					graphics_0.DrawLine(new Pen(GClass61.smethod_75(), 1f)
					{
						DashStyle = DashStyle.Dash
					}, (float)this.int_1, 4f, (float)this.int_1, num2 + 4f);
				}
			}
		}
	}

	// Token: 0x060004CF RID: 1231 RVA: 0x0008EFCC File Offset: 0x0008D1CC
	private void drawingPanel_Paint(object sender, PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		this.method_7(graphics);
	}

	// Token: 0x060004D0 RID: 1232 RVA: 0x000038FD File Offset: 0x00001AFD
	private void GClass65_Paint(object sender, PaintEventArgs e)
	{
		this.drawingPanel.Invalidate();
	}

	// Token: 0x060004D1 RID: 1233 RVA: 0x0000390A File Offset: 0x00001B0A
	private void drawingPanel_MouseClick(object sender, MouseEventArgs e)
	{
		this.int_1 = e.X;
		this.drawingPanel.Invalidate();
	}

	// Token: 0x04000642 RID: 1602
	private bool bool_0 = true;

	// Token: 0x04000643 RID: 1603
	private HScrollBar hsbGraph;

	// Token: 0x04000644 RID: 1604
	private GClass63 drawingPanel;

	// Token: 0x04000645 RID: 1605
	private float float_0 = 1f;

	// Token: 0x04000646 RID: 1606
	private int int_0 = 0;

	// Token: 0x04000647 RID: 1607
	private int int_1 = 0;
}
