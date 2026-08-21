using System;

namespace Multiecuscan
{
	// Token: 0x02000086 RID: 134
	public class SimpleValueData
	{
		// Token: 0x0600044A RID: 1098 RVA: 0x00003820 File Offset: 0x00001A20
		public SimpleValueData(int int_0, string string_0)
		{
			this.id = int_0;
			this.value = string_0;
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x00003841 File Offset: 0x00001A41
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x00003849 File Offset: 0x00001A49
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

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x00003852 File Offset: 0x00001A52
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x0000385A File Offset: 0x00001A5A
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

		// Token: 0x0600044F RID: 1103 RVA: 0x00003852 File Offset: 0x00001A52
		public override string ToString()
		{
			return this.value;
		}

		// Token: 0x040002F0 RID: 752
		private int id;

		// Token: 0x040002F1 RID: 753
		private string value = "";
	}
}
