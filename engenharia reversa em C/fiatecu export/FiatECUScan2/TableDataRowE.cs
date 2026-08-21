using System;

namespace FiatECUScan2
{
	// Token: 0x02000095 RID: 149
	public class TableDataRowE
	{
		// Token: 0x06000564 RID: 1380 RVA: 0x00003A67 File Offset: 0x00001C67
		public TableDataRowE(GClass64 gclass64_1)
		{
			this.gclass64_0 = gclass64_1;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000565 RID: 1381 RVA: 0x0009EE20 File Offset: 0x0009D020
		// (set) Token: 0x06000566 RID: 1382 RVA: 0x00003A76 File Offset: 0x00001C76
		public string Name
		{
			get
			{
				return this.gclass64_0.string_1;
			}
			set
			{
				this.gclass64_0.string_1 = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000567 RID: 1383 RVA: 0x0009EE3C File Offset: 0x0009D03C
		// (set) Token: 0x06000568 RID: 1384 RVA: 0x00003A84 File Offset: 0x00001C84
		public string Status1
		{
			get
			{
				return this.gclass64_0.method_4();
			}
			set
			{
				this.gclass64_0.method_5(value);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000569 RID: 1385 RVA: 0x0009EE58 File Offset: 0x0009D058
		// (set) Token: 0x0600056A RID: 1386 RVA: 0x00003A92 File Offset: 0x00001C92
		public string Status2
		{
			get
			{
				return this.gclass64_0.method_6();
			}
			set
			{
				this.gclass64_0.method_7(value);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600056B RID: 1387 RVA: 0x0009EE74 File Offset: 0x0009D074
		// (set) Token: 0x0600056C RID: 1388 RVA: 0x00003AA0 File Offset: 0x00001CA0
		public string Status3
		{
			get
			{
				return this.gclass64_0.method_8();
			}
			set
			{
				this.gclass64_0.method_9(value);
			}
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0009EE90 File Offset: 0x0009D090
		public GClass64 getDataItem()
		{
			return this.gclass64_0;
		}

		// Token: 0x040006A7 RID: 1703
		private GClass64 gclass64_0;
	}
}
