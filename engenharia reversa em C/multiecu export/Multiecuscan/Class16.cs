using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

// Token: 0x020000CB RID: 203
internal static class Class16
{
	// Token: 0x060007F8 RID: 2040 RVA: 0x000F4914 File Offset: 0x000F2B14
	[STAThread]
	private static void Main()
	{
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		string fileName = Process.GetCurrentProcess().MainModule.FileName;
		string moduleName = Process.GetCurrentProcess().MainModule.ModuleName;
		GClass126.byte_3 = GClass123.byte_3;
		for (int i = 0; i < commandLineArgs.Length; i++)
		{
			string[] array = commandLineArgs[i].Split(new char[]
			{
				'='
			});
			if (array.Length > 1 && array[0].ToLower() == "/u")
			{
				string str = array[1];
				Process.Start(new ProcessStartInfo(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\msiexec.exe", "/x " + str));
				Application.Exit();
				return;
			}
		}
		int major = Environment.OSVersion.Version.Major;
		try
		{
			if (Environment.OSVersion.Version.Major >= 6 && !moduleName.ToLower().Contains("vshost"))
			{
				Class16.SetProcessDPIAware();
			}
		}
		catch (Exception)
		{
		}
		int num = GClass123.smethod_0();
		Application.ThreadException += Class16.smethod_0;
		AppDomain.CurrentDomain.UnhandledException += Class16.smethod_1;
		GClass107.smethod_0();
		if (num >= 6)
		{
			GClass123.bool_17 = false;
		}
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Application.Run(new GForm8());
	}

	// Token: 0x060007F9 RID: 2041 RVA: 0x000F4A64 File Offset: 0x000F2C64
	private static void smethod_0(object sender, ThreadExceptionEventArgs e)
	{
		Exception exception = e.Exception;
		GClass126.smethod_2("GLOBAL APP EXCEPTION!", 0);
		GClass126.smethod_2("M1: " + exception.Message, 0);
		GClass126.smethod_2("M2: " + exception.TargetSite.ToString(), 0);
		Class16.smethod_2();
	}

	// Token: 0x060007FA RID: 2042 RVA: 0x000F4ABC File Offset: 0x000F2CBC
	private static void smethod_1(object sender, UnhandledExceptionEventArgs e)
	{
		Exception ex = e.ExceptionObject as Exception;
		GClass126.smethod_2("GLOBAL APP EXCEPTION", 0);
		GClass126.smethod_2("M1: " + ex.Message, 0);
		GClass126.smethod_2("M2: " + ex.TargetSite.ToString(), 0);
		Class16.smethod_2();
	}

	// Token: 0x060007FB RID: 2043 RVA: 0x00005321 File Offset: 0x00003521
	private static void smethod_2()
	{
		if (MessageBox.Show(GClass126.string_3, "Fatal error", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
		{
			GClass126.smethod_13();
		}
	}

	// Token: 0x060007FC RID: 2044
	[DllImport("user32.dll")]
	private static extern bool SetProcessDPIAware();
}
