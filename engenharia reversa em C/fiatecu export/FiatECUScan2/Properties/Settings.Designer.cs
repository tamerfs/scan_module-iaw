using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace FiatECUScan2.Properties
{
	// Token: 0x02000093 RID: 147
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x0009EDDC File Offset: 0x0009CFDC
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040006A4 RID: 1700
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
