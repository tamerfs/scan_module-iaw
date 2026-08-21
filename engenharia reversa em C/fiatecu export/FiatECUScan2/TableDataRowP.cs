using System;

namespace FiatECUScan2
{
	// Token: 0x02000096 RID: 150
	public class TableDataRowP
	{
		// Token: 0x0600056E RID: 1390 RVA: 0x00003AAE File Offset: 0x00001CAE
		public TableDataRowP(GClass58 gclass58_1)
		{
			this.gclass58_0 = gclass58_1;
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600056F RID: 1391 RVA: 0x00003ABD File Offset: 0x00001CBD
		// (set) Token: 0x06000570 RID: 1392 RVA: 0x00003ACA File Offset: 0x00001CCA
		public bool Selected
		{
			get
			{
				return this.gclass58_0.bool_0;
			}
			set
			{
				this.gclass58_0.bool_0 = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x0009EEA8 File Offset: 0x0009D0A8
		// (set) Token: 0x06000572 RID: 1394 RVA: 0x00003AD8 File Offset: 0x00001CD8
		public string Name
		{
			get
			{
				return this.gclass58_0.string_0;
			}
			set
			{
				this.gclass58_0.string_0 = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x0009EEC4 File Offset: 0x0009D0C4
		// (set) Token: 0x06000574 RID: 1396 RVA: 0x00003AE6 File Offset: 0x00001CE6
		public string Value
		{
			get
			{
				return this.gclass58_0.method_0() + " " + this.gclass58_0.string_3;
			}
			set
			{
				this.gclass58_0.method_1(value);
			}
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0009EEF4 File Offset: 0x0009D0F4
		public GClass58 getDataItem()
		{
			return this.gclass58_0;
		}

		// Token: 0x040006A8 RID: 1704
		private GClass58 gclass58_0;
	}
}
