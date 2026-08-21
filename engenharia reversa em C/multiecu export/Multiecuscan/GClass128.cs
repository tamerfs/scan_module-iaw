using System;
using System.Runtime.CompilerServices;
using Multiecuscan.Properties;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

// Token: 0x020000C9 RID: 201
public class GClass128
{
	// Token: 0x060007ED RID: 2029 RVA: 0x000052B0 File Offset: 0x000034B0
	public GClass128(PdfDocument pdfDocument_1, XUnit xunit_3, XUnit xunit_4)
	{
		this.pdfDocument_0 = pdfDocument_1;
		this.xunit_0 = xunit_3;
		this.xunit_1 = xunit_4;
		this.xunit_2 = xunit_4 + 10000.0;
	}

	// Token: 0x060007EE RID: 2030 RVA: 0x000052E8 File Offset: 0x000034E8
	public XUnit method_0(XUnit xunit_3)
	{
		return this.method_1(xunit_3, -1.0);
	}

	// Token: 0x060007EF RID: 2031 RVA: 0x000F3BEC File Offset: 0x000F1DEC
	public XUnit method_1(XUnit xunit_3, XUnit xunit_4)
	{
		XUnit value = (xunit_4 == -1.0) ? xunit_3 : xunit_4;
		if (this.xunit_2 + value > this.xunit_1)
		{
			this.method_6();
		}
		XUnit result = this.xunit_2;
		this.xunit_2 += xunit_3;
		return result;
	}

	// Token: 0x060007F0 RID: 2032 RVA: 0x000052FF File Offset: 0x000034FF
	[CompilerGenerated]
	public XGraphics method_2()
	{
		return this.xgraphics_0;
	}

	// Token: 0x060007F1 RID: 2033 RVA: 0x00005307 File Offset: 0x00003507
	[CompilerGenerated]
	private void method_3(XGraphics xgraphics_1)
	{
		this.xgraphics_0 = xgraphics_1;
	}

	// Token: 0x060007F2 RID: 2034 RVA: 0x00005310 File Offset: 0x00003510
	[CompilerGenerated]
	public PdfPage method_4()
	{
		return this.pdfPage_0;
	}

	// Token: 0x060007F3 RID: 2035 RVA: 0x00005318 File Offset: 0x00003518
	[CompilerGenerated]
	private void method_5(PdfPage pdfPage_1)
	{
		this.pdfPage_0 = pdfPage_1;
	}

	// Token: 0x060007F4 RID: 2036 RVA: 0x000F3C5C File Offset: 0x000F1E5C
	private void method_6()
	{
		this.method_5(this.pdfDocument_0.AddPage());
		this.method_4().Size = PageSize.A4;
		this.method_3(XGraphics.FromPdfPage(this.method_4()));
		this.xunit_2 = this.xunit_0;
		XRect layoutRectangle = new XRect(default(XPoint), this.method_2().PageSize);
		layoutRectangle.Inflate(-15.0, -40.0);
		XRect layoutRectangle2 = new XRect(layoutRectangle.X, 15.0, layoutRectangle.Width, layoutRectangle.Y);
		try
		{
			XImage image = XImage.FromFile(GClass125.smethod_30() + "\\report_head.png");
			this.method_2().DrawImage(image, layoutRectangle2.Left, layoutRectangle2.Top, layoutRectangle2.Width, layoutRectangle2.Height);
		}
		catch (Exception)
		{
		}
		XStringFormat xstringFormat = new XStringFormat();
		xstringFormat.LineAlignment = XLineAlignment.Far;
		XPen pen = new XPen(XColors.Navy, 1.0);
		this.method_2().DrawLine(pen, layoutRectangle.Left, layoutRectangle.Top + 16.0, layoutRectangle.Right, layoutRectangle.Top + 16.0);
		this.method_2().DrawLine(pen, layoutRectangle.Left, layoutRectangle.Bottom - 25.0, layoutRectangle.Right, layoutRectangle.Bottom - 25.0);
		layoutRectangle2.Offset(0.0, layoutRectangle2.Height + 3.0);
		XFont font = new XFont("Arial", 6.0, XFontStyle.Regular);
		string text = DateTime.Now.ToString();
		xstringFormat.Alignment = XStringAlignment.Far;
		xstringFormat.LineAlignment = XLineAlignment.Near;
		this.method_2().DrawString(text, font, XBrushes.Black, layoutRectangle2, xstringFormat);
		XImage image2 = XImage.FromGdiPlusImage(Resources.Logo3xx5);
		this.method_2().DrawImage(image2, layoutRectangle.Left, layoutRectangle.Bottom - 23.0);
		xstringFormat.LineAlignment = XLineAlignment.Far;
		layoutRectangle.Offset(0.0, -17.0);
		font = new XFont("Arial", 6.0, XFontStyle.Regular);
		xstringFormat.Alignment = XStringAlignment.Far;
		this.method_2().DrawString("vehicle diagnostics software for italian cars", font, XBrushes.Navy, layoutRectangle, xstringFormat);
		layoutRectangle.Offset(0.0, 10.0);
		font = new XFont("Arial", 8.0);
		xstringFormat.Alignment = XStringAlignment.Center;
		this.method_2().DrawString(this.pdfDocument_0.PageCount.ToString(), font, XBrushes.Black, layoutRectangle, xstringFormat);
		font = new XFont("Arial", 9.0, XFontStyle.Bold);
		xstringFormat.Alignment = XStringAlignment.Far;
		this.method_2().DrawString("www.multiecuscan.net", font, XBrushes.Navy, layoutRectangle, xstringFormat);
	}

	// Token: 0x040006DA RID: 1754
	private readonly PdfDocument pdfDocument_0;

	// Token: 0x040006DB RID: 1755
	private readonly XUnit xunit_0;

	// Token: 0x040006DC RID: 1756
	private readonly XUnit xunit_1;

	// Token: 0x040006DD RID: 1757
	private XUnit xunit_2;

	// Token: 0x040006DE RID: 1758
	[CompilerGenerated]
	private XGraphics xgraphics_0;

	// Token: 0x040006DF RID: 1759
	[CompilerGenerated]
	private PdfPage pdfPage_0;
}
