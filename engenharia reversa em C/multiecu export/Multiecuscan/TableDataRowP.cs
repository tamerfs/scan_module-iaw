using System;

namespace Multiecuscan
{
	// Token: 0x0200008A RID: 138
	public class TableDataRowP
	{
		// Token: 0x06000465 RID: 1125 RVA: 0x0000398B File Offset: 0x00001B8B
		public TableDataRowP(GClass104 gclass104_0)
		{
			this.dataItem = gclass104_0;
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000466 RID: 1126 RVA: 0x0000399A File Offset: 0x00001B9A
		// (set) Token: 0x06000467 RID: 1127 RVA: 0x000039A7 File Offset: 0x00001BA7
		public bool Selected
		{
			get
			{
				return this.dataItem.bool_0;
			}
			set
			{
				this.dataItem.bool_0 = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000468 RID: 1128 RVA: 0x000039B5 File Offset: 0x00001BB5
		// (set) Token: 0x06000469 RID: 1129 RVA: 0x000039C2 File Offset: 0x00001BC2
		public string Name
		{
			get
			{
				return this.dataItem.string_0;
			}
			set
			{
				this.dataItem.string_0 = value;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600046A RID: 1130 RVA: 0x000039D0 File Offset: 0x00001BD0
		// (set) Token: 0x0600046B RID: 1131 RVA: 0x000039F2 File Offset: 0x00001BF2
		public string Value
		{
			get
			{
				return this.dataItem.method_0() + " " + this.dataItem.string_3;
			}
			set
			{
				this.dataItem.method_1(value);
			}
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00003A00 File Offset: 0x00001C00
		public GClass104 getDataItem()
		{
			return this.dataItem;
		}

		// Token: 0x040002F6 RID: 758
		private GClass104 dataItem;
	}
}
