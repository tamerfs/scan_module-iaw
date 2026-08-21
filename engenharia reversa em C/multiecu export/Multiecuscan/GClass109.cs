using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

// Token: 0x0200008C RID: 140
public class GClass109 : ProgressBar
{
	// Token: 0x0600046D RID: 1133 RVA: 0x00003A08 File Offset: 0x00001C08
	[CompilerGenerated]
	public GEnum1 method_0()
	{
		return this.genum1_0;
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x00003A10 File Offset: 0x00001C10
	[CompilerGenerated]
	public void method_1(GEnum1 genum1_1)
	{
		this.genum1_0 = genum1_1;
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x00003A19 File Offset: 0x00001C19
	[CompilerGenerated]
	public string method_2()
	{
		return this.string_0;
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x00003A21 File Offset: 0x00001C21
	[CompilerGenerated]
	public void method_3(string string_1)
	{
		this.string_0 = string_1;
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x00003A2A File Offset: 0x00001C2A
	public GClass109()
	{
		base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x000A379C File Offset: 0x000A199C
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Rectangle clientRectangle = base.ClientRectangle;
		Graphics graphics = e.Graphics;
		if (ProgressBarRenderer.IsSupported)
		{
			ProgressBarRenderer.DrawHorizontalBar(graphics, clientRectangle);
		}
		clientRectangle.Inflate(-3, -3);
		if (base.Value > 0)
		{
			Rectangle bounds = new Rectangle(clientRectangle.X, clientRectangle.Y, (int)Math.Round((double)((float)base.Value / (float)base.Maximum * (float)clientRectangle.Width)), clientRectangle.Height);
			if (ProgressBarRenderer.IsSupported)
			{
				ProgressBarRenderer.DrawHorizontalChunks(graphics, bounds);
			}
		}
		int num = (int)((double)(base.Value - base.Minimum) / (double)(base.Maximum - base.Minimum) * 100.0);
		string text = (this.method_0() == (GEnum1)0) ? (num.ToString() + "%") : this.method_2();
		Font font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		SizeF sizeF = graphics.MeasureString(text, font);
		Point p = new Point(Convert.ToInt32((float)(base.Width / 2) - sizeF.Width / 2f), Convert.ToInt32((float)(base.Height / 2) - sizeF.Height / 2f));
		graphics.DrawString(text, font, Brushes.Navy, p);
	}

	// Token: 0x040002F8 RID: 760
	[CompilerGenerated]
	private GEnum1 genum1_0;

	// Token: 0x040002F9 RID: 761
	[CompilerGenerated]
	private string string_0;
}
