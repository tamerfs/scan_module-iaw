using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

// Token: 0x0200001B RID: 27
internal static class Class1
{
	// Token: 0x06000125 RID: 293 RVA: 0x00034684 File Offset: 0x00032884
	[STAThread]
	private static void Main()
	{
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		string text = string.Empty;
		foreach (string text in commandLineArgs)
		{
			string[] array = text.Split(new char[]
			{
				'='
			});
			if (array.Length > 1 && array[0].ToLower() == "/u")
			{
				string str = array[1];
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
				Process.Start(new ProcessStartInfo(folderPath + "\\msiexec.exe", "/x " + str));
				Application.Exit();
				return;
			}
		}
		RuntimeHelpers.InitializeArray(new char[17], fieldof(Class3.struct15_0).FieldHandle);
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Application.Run(new FormMain());
	}
}
