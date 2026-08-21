using System;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

// Token: 0x020000CA RID: 202
public class GClass129
{
	// Token: 0x060007F6 RID: 2038 RVA: 0x000F3F70 File Offset: 0x000F2170
	public PdfDocument method_0(StringBuilder stringBuilder_0)
	{
		string[] array = stringBuilder_0.ToString().Split(new string[]
		{
			Environment.NewLine
		}, StringSplitOptions.None);
		PdfDocument pdfDocument = new PdfDocument();
		pdfDocument.Info.Title = "Multiecuscan report";
		try
		{
			GClass128 gclass = new GClass128(pdfDocument, XUnit.FromCentimeter(2.5), XUnit.FromCentimeter(27.2));
			XUnit value = gclass.method_1(10, 10);
			XUnit value2 = XUnit.FromCentimeter(2.5);
			XUnit value3 = XUnit.FromCentimeter(2.5);
			XUnit value4 = XUnit.FromCentimeter(10.0);
			XUnit value5 = XUnit.FromCentimeter(10.0);
			XUnit value6 = XUnit.FromCentimeter(16.0);
			XPdfFontOptions pdfOptions = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
			XFont font = new XFont("Verdana", 10.0, XFontStyle.Bold, pdfOptions);
			XFont font2 = new XFont("Verdana", 9.0, XFontStyle.Bold, pdfOptions);
			XFont font3 = new XFont("Verdana", 8.0, XFontStyle.Regular, pdfOptions);
			XFont font4 = new XFont("Verdana", 6.0, XFontStyle.Regular, pdfOptions);
			int num = 1;
			int i = 1;
			if (num < array.Length && array[i] != "")
			{
				value = gclass.method_1(8, 16);
				gclass.method_2().DrawString(array[i], font4, XBrushes.Black, value2, value, XStringFormats.TopLeft);
			}
			while (++i < array.Length && array[i] != "")
			{
				if (!array[i].StartsWith("------------"))
				{
					if (array[i].Length < 150)
					{
						value = gclass.method_1(13, 21);
						gclass.method_2().DrawString(array[i], font, XBrushes.Black, value2, value, XStringFormats.TopLeft);
					}
					else
					{
						string text = array[i];
						while (text.Length > 75)
						{
							string s = text.Substring(0, 75);
							text = text.Substring(75);
							value = gclass.method_1(13, 21);
							gclass.method_2().DrawString(s, font, XBrushes.Black, value2, value, XStringFormats.TopLeft);
						}
						value = gclass.method_1(13, 21);
						gclass.method_2().DrawString(text, font, XBrushes.Black, value2, value, XStringFormats.TopLeft);
					}
				}
			}
			while (i < array.Length)
			{
				value = gclass.method_1(11, 8);
				int num2 = -1;
				while (++i < array.Length && array[i] != "")
				{
					num2++;
					int num3 = array[i].IndexOf(": ");
					string text2;
					string text3;
					if (num3 > 0)
					{
						text2 = array[i].Substring(0, num3);
						text3 = array[i].Substring(num3 + 1);
					}
					else
					{
						text2 = array[i];
						text3 = "";
						num2 = -1;
					}
					if (text2.StartsWith("  "))
					{
						value = gclass.method_1(8, 6);
						if (num2 % 3 == 0 && text3 != "")
						{
							gclass.method_2().DrawRectangle(XBrushes.LightGray, value3 - 1.0, value, value4 - value3 - 3.0, 8.0);
							gclass.method_2().DrawRectangle(XBrushes.LightGray, value4 - 1.0, value, value6 - value4 + value3 + 1.0, 8.0);
						}
						gclass.method_2().DrawString(text2, font4, XBrushes.Black, value3, value, XStringFormats.TopLeft);
						gclass.method_2().DrawString(text3, font4, XBrushes.Black, value5, value, XStringFormats.TopLeft);
					}
					else if ((text2.EndsWith(":") || text2.EndsWith("...")) && text3 == "")
					{
						value = gclass.method_1(17, 25);
						gclass.method_2().DrawString(text2, font2, XBrushes.Black, value3, value, XStringFormats.TopLeft);
					}
					else
					{
						value = gclass.method_1(11, 8);
						if (num2 % 3 == 0 && text3 != "")
						{
							gclass.method_2().DrawRectangle(XBrushes.LightGray, value3 - 1.0, value, value4 - value3 - 3.0, 11.0);
							gclass.method_2().DrawRectangle(XBrushes.LightGray, value4 - 1.0, value, value6 - value4 + value3 + 1.0, 11.0);
						}
						gclass.method_2().DrawString(text2, font3, XBrushes.Black, value3, value, XStringFormats.TopLeft);
						gclass.method_2().DrawString(text3, font3, XBrushes.Black, value4, value, XStringFormats.TopLeft);
					}
				}
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2("PDF ERROR: " + ex.Message, 0);
		}
		return pdfDocument;
	}

	// Token: 0x060007F7 RID: 2039 RVA: 0x000F45B8 File Offset: 0x000F27B8
	public PdfDocument method_1(StringBuilder stringBuilder_0)
	{
		string[] array = stringBuilder_0.ToString().Split(new string[]
		{
			Environment.NewLine
		}, StringSplitOptions.None);
		PdfDocument pdfDocument = new PdfDocument();
		pdfDocument.Info.Title = "Multiecuscan report";
		try
		{
			GClass128 gclass = new GClass128(pdfDocument, XUnit.FromCentimeter(2.5), XUnit.FromCentimeter(27.2));
			XUnit value = gclass.method_1(10, 10);
			XUnit.FromCentimeter(2.5);
			XUnit value2 = XUnit.FromCentimeter(2.5);
			XUnit value3 = XUnit.FromCentimeter(6.0);
			XUnit.FromCentimeter(10.0);
			XUnit value4 = XUnit.FromCentimeter(16.0);
			XPdfFontOptions pdfOptions = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
			new XFont("Verdana", 10.0, XFontStyle.Bold, pdfOptions);
			XFont font = new XFont("Verdana", 9.0, XFontStyle.Bold, pdfOptions);
			XFont font2 = new XFont("Verdana", 8.0, XFontStyle.Regular, pdfOptions);
			new XFont("Verdana", 6.0, XFontStyle.Regular, pdfOptions);
			int i = -1;
			string b = GClass121.smethod_6("1210");
			while (i < array.Length)
			{
				value = gclass.method_1(11, 8);
				int num = -1;
				bool flag = false;
				while (++i < array.Length && array[i] != "")
				{
					num++;
					if (array[i] == b)
					{
						flag = true;
					}
					int num2 = array[i].IndexOf(": ");
					string text;
					string text2;
					if (num2 > 0)
					{
						text = array[i].Substring(0, num2 + 1);
						text2 = array[i].Substring(num2 + 1);
					}
					else
					{
						text = array[i];
						text2 = "";
					}
					if (!text.EndsWith("...") && !text.StartsWith("..."))
					{
						value = gclass.method_1(11, 8);
						if (num == 0)
						{
							gclass.method_2().DrawRectangle(XBrushes.LightGray, value2 - 1.0, value, value4 + 1.0, 11.0);
						}
						gclass.method_2().DrawString(text, font2, flag ? XBrushes.Red : XBrushes.Black, value2, value, XStringFormats.TopLeft);
						if (text2 != "")
						{
							gclass.method_2().DrawString(text2, font2, flag ? XBrushes.Red : XBrushes.Black, value3, value, XStringFormats.TopLeft);
						}
					}
					else
					{
						value = gclass.method_1(17, 25);
						gclass.method_2().DrawString(text, font, XBrushes.Black, value2, value, XStringFormats.TopLeft);
					}
				}
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2("PDF ERROR2: " + ex.Message, 0);
		}
		return pdfDocument;
	}

	// Token: 0x040006E0 RID: 1760
	private const int int_0 = 10;

	// Token: 0x040006E1 RID: 1761
	private const int int_1 = 9;

	// Token: 0x040006E2 RID: 1762
	private const int int_2 = 8;

	// Token: 0x040006E3 RID: 1763
	private const int int_3 = 6;
}
