using MyExtensions;
using MyUtils;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;

namespace MyBackup
{
	public static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			PreInit();
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(new Form1());
		}


		public static Dictionary<string, BackupConfig> Configs { get; } = new();

		private static void PreInit()
		{
			if (Directory.Exists("config"))
			{
				foreach (string path in Directory.EnumerateFiles("config", "*.config"))
				{
					BackupConfig config = BackupConfig.ReadFrom(path);
					Configs.Add(Path.GetFileNameWithoutExtension(path), config);
				}
			}
		}


	}
}