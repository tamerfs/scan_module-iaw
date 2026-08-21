using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Multiecuscan.Properties
{
	// Token: 0x020000CC RID: 204
	[CompilerGenerated]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	public class Resources
	{
		// Token: 0x060007FD RID: 2045 RVA: 0x00002E97 File Offset: 0x00001097
		internal Resources()
		{
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060007FE RID: 2046 RVA: 0x0000533D File Offset: 0x0000353D
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Multiecuscan.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060007FF RID: 2047 RVA: 0x0000536A File Offset: 0x0000356A
		// (set) Token: 0x06000800 RID: 2048 RVA: 0x00005371 File Offset: 0x00003571
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000801 RID: 2049 RVA: 0x00005379 File Offset: 0x00003579
		public static Bitmap Logo3xx5
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("Logo3xx5", Resources.resourceCulture);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000802 RID: 2050 RVA: 0x00005394 File Offset: 0x00003594
		public static string StringDisclaimer
		{
			get
			{
				return Resources.ResourceManager.GetString("StringDisclaimer", Resources.resourceCulture);
			}
		}

		// Token: 0x040006E4 RID: 1764
		private static ResourceManager resourceMan;

		// Token: 0x040006E5 RID: 1765
		private static CultureInfo resourceCulture;
	}
}
