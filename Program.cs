using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace FontEditor
{
  static class Program
  {
		public const string ProgramName = "Font editor";
		public const int ProgramVersionMajor = 1;
		public const int ProgramVersionMinor = 0;
		public static readonly int ProgramVersionBuild = Assembly.GetExecutingAssembly().GetName().Version.Build;
		public static readonly int ProgramVersionRevision = Assembly.GetExecutingAssembly().GetName().Version.Revision;
		public static readonly DateTime ProgramBuildDateTime = new DateTime(2000, 1, 1)
				.AddDays(Assembly.GetExecutingAssembly().GetName().Version.Build)
				.AddSeconds(Assembly.GetExecutingAssembly().GetName().Version.Revision * 2);

		[STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new FormMain());
    }
  }
}
