using System;

namespace Multiecuscan
{
	// Token: 0x02000088 RID: 136
	public class TableDataRowE
	{
		// Token: 0x06000455 RID: 1109 RVA: 0x000038A6 File Offset: 0x00001AA6
		public TableDataRowE(GClass102 gclass102_0)
		{
			this.dataItem = gclass102_0;
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x000038B5 File Offset: 0x00001AB5
		// (set) Token: 0x06000457 RID: 1111 RVA: 0x000038C2 File Offset: 0x00001AC2
		public string Name
		{
			get
			{
				return this.dataItem.string_2;
			}
			set
			{
				this.dataItem.string_2 = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000458 RID: 1112 RVA: 0x000038D0 File Offset: 0x00001AD0
		// (set) Token: 0x06000459 RID: 1113 RVA: 0x000038DD File Offset: 0x00001ADD
		public string Status1
		{
			get
			{
				return this.dataItem.method_2();
			}
			set
			{
				this.dataItem.method_3(value);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x000038EB File Offset: 0x00001AEB
		// (set) Token: 0x0600045B RID: 1115 RVA: 0x000038F8 File Offset: 0x00001AF8
		public string Status2
		{
			get
			{
				return this.dataItem.method_4();
			}
			set
			{
				this.dataItem.method_5(value);
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600045C RID: 1116 RVA: 0x00003906 File Offset: 0x00001B06
		// (set) Token: 0x0600045D RID: 1117 RVA: 0x00003913 File Offset: 0x00001B13
		public string Status3
		{
			get
			{
				return this.dataItem.method_6();
			}
			set
			{
				this.dataItem.method_7(value);
			}
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00003921 File Offset: 0x00001B21
		public GClass102 getDataItem()
		{
			return this.dataItem;
		}

		// Token: 0x040002F4 RID: 756
		private GClass102 dataItem;
	}
}
