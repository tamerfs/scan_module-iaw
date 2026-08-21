using System;

namespace FiatECUScan2
{
	// Token: 0x02000094 RID: 148
	public class SimpleValueData
	{
		// Token: 0x0600055E RID: 1374 RVA: 0x00003A34 File Offset: 0x00001C34
		public SimpleValueData(int id, string value)
		{
			this.id = id;
			this.value = value;
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600055F RID: 1375 RVA: 0x0009EDF0 File Offset: 0x0009CFF0
		// (set) Token: 0x06000560 RID: 1376 RVA: 0x00003A55 File Offset: 0x00001C55
		public int ID
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000561 RID: 1377 RVA: 0x0009EE08 File Offset: 0x0009D008
		// (set) Token: 0x06000562 RID: 1378 RVA: 0x00003A5E File Offset: 0x00001C5E
		public string Value
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
			}
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0009EE08 File Offset: 0x0009D008
		public override string ToString()
		{
			return this.value;
		}

		// Token: 0x040006A5 RID: 1701
		private int id;

		// Token: 0x040006A6 RID: 1702
		private string value = string.Empty;
	}
}
