using System;

namespace Multiecuscan
{
	// Token: 0x02000082 RID: 130
	public class MapRowData
	{
		// Token: 0x06000418 RID: 1048 RVA: 0x0000359E File Offset: 0x0000179E
		public string GetCol(int int_0)
		{
			if (int_0 >= 0 && int_0 <= this.cols.Length)
			{
				return this.cols[int_0];
			}
			return "";
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000035BD File Offset: 0x000017BD
		public void SetCol(int int_0, string string_0)
		{
			if (int_0 >= 0 && int_0 <= this.cols.Length)
			{
				this.cols[int_0] = string_0;
				return;
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x000035D8 File Offset: 0x000017D8
		public byte GetColStyle(int int_0)
		{
			if (int_0 >= 0 && int_0 <= this.colStyles.Length)
			{
				return this.colStyles[int_0];
			}
			return 0;
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x000035F3 File Offset: 0x000017F3
		public void SetColStyle(int int_0, byte byte_0)
		{
			if (int_0 >= 0 && int_0 <= this.colStyles.Length)
			{
				this.colStyles[int_0] = byte_0;
				return;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x0000360E File Offset: 0x0000180E
		// (set) Token: 0x0600041D RID: 1053 RVA: 0x00003618 File Offset: 0x00001818
		public string Col0
		{
			get
			{
				return this.cols[0];
			}
			set
			{
				this.cols[0] = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00003623 File Offset: 0x00001823
		// (set) Token: 0x0600041F RID: 1055 RVA: 0x0000362D File Offset: 0x0000182D
		public string Col1
		{
			get
			{
				return this.cols[1];
			}
			set
			{
				this.cols[1] = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x00003638 File Offset: 0x00001838
		// (set) Token: 0x06000421 RID: 1057 RVA: 0x00003642 File Offset: 0x00001842
		public string Col2
		{
			get
			{
				return this.cols[2];
			}
			set
			{
				this.cols[2] = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000422 RID: 1058 RVA: 0x0000364D File Offset: 0x0000184D
		// (set) Token: 0x06000423 RID: 1059 RVA: 0x00003657 File Offset: 0x00001857
		public string Col3
		{
			get
			{
				return this.cols[3];
			}
			set
			{
				this.cols[3] = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x00003662 File Offset: 0x00001862
		// (set) Token: 0x06000425 RID: 1061 RVA: 0x0000366C File Offset: 0x0000186C
		public string Col4
		{
			get
			{
				return this.cols[4];
			}
			set
			{
				this.cols[4] = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x00003677 File Offset: 0x00001877
		// (set) Token: 0x06000427 RID: 1063 RVA: 0x00003681 File Offset: 0x00001881
		public string Col5
		{
			get
			{
				return this.cols[5];
			}
			set
			{
				this.cols[5] = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x0000368C File Offset: 0x0000188C
		// (set) Token: 0x06000429 RID: 1065 RVA: 0x00003696 File Offset: 0x00001896
		public string Col6
		{
			get
			{
				return this.cols[6];
			}
			set
			{
				this.cols[6] = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x000036A1 File Offset: 0x000018A1
		// (set) Token: 0x0600042B RID: 1067 RVA: 0x000036AB File Offset: 0x000018AB
		public string Col7
		{
			get
			{
				return this.cols[7];
			}
			set
			{
				this.cols[7] = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x000036B6 File Offset: 0x000018B6
		// (set) Token: 0x0600042D RID: 1069 RVA: 0x000036C0 File Offset: 0x000018C0
		public string Col8
		{
			get
			{
				return this.cols[8];
			}
			set
			{
				this.cols[8] = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600042E RID: 1070 RVA: 0x000036CB File Offset: 0x000018CB
		// (set) Token: 0x0600042F RID: 1071 RVA: 0x000036D6 File Offset: 0x000018D6
		public string Col9
		{
			get
			{
				return this.cols[9];
			}
			set
			{
				this.cols[9] = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x000036E2 File Offset: 0x000018E2
		// (set) Token: 0x06000431 RID: 1073 RVA: 0x000036ED File Offset: 0x000018ED
		public string Col10
		{
			get
			{
				return this.cols[10];
			}
			set
			{
				this.cols[10] = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x000036F9 File Offset: 0x000018F9
		// (set) Token: 0x06000433 RID: 1075 RVA: 0x00003704 File Offset: 0x00001904
		public string Col11
		{
			get
			{
				return this.cols[11];
			}
			set
			{
				this.cols[11] = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x00003710 File Offset: 0x00001910
		// (set) Token: 0x06000435 RID: 1077 RVA: 0x0000371B File Offset: 0x0000191B
		public string Col12
		{
			get
			{
				return this.cols[12];
			}
			set
			{
				this.cols[12] = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000436 RID: 1078 RVA: 0x00003727 File Offset: 0x00001927
		// (set) Token: 0x06000437 RID: 1079 RVA: 0x00003732 File Offset: 0x00001932
		public string Col13
		{
			get
			{
				return this.cols[13];
			}
			set
			{
				this.cols[13] = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000438 RID: 1080 RVA: 0x0000373E File Offset: 0x0000193E
		// (set) Token: 0x06000439 RID: 1081 RVA: 0x00003749 File Offset: 0x00001949
		public string Col14
		{
			get
			{
				return this.cols[14];
			}
			set
			{
				this.cols[14] = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x00003755 File Offset: 0x00001955
		// (set) Token: 0x0600043B RID: 1083 RVA: 0x00003760 File Offset: 0x00001960
		public string Col15
		{
			get
			{
				return this.cols[15];
			}
			set
			{
				this.cols[15] = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x0000376C File Offset: 0x0000196C
		// (set) Token: 0x0600043D RID: 1085 RVA: 0x00003777 File Offset: 0x00001977
		public string Col16
		{
			get
			{
				return this.cols[16];
			}
			set
			{
				this.cols[16] = value;
			}
		}

		// Token: 0x040002CB RID: 715
		private string[] cols = new string[33];

		// Token: 0x040002CC RID: 716
		private byte[] colStyles = new byte[33];
	}
}
