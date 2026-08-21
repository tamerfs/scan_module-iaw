using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Multiecuscan.Properties
{
	// Token: 0x020000CD RID: 205
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x000053AA File Offset: 0x000035AA
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040006E6 RID: 1766
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
