using MyUtils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackup
{
	public record BackupConfig(string SourcePath, string DestinationPath, DateTime NextBackupUtc)
	{
		public static BackupConfig FromJson(Dictionary<string, dynamic> json)
		{
			return new BackupConfig(json["sourcePath"], json["destinationPath"], DateTime.ParseExact(json["nextBackupUtc"], "o", null, DateTimeStyles.RoundtripKind));
		}
		public static BackupConfig ReadFrom(string path) => FromJson(JsonUtil.ParseJson(File.ReadAllText(path)));


		public BackupConfig(string sourcePath, string destinationPath) : this(sourcePath, destinationPath, DateTime.UtcNow)
		{
		}




		public Dictionary<string, dynamic> ToJson()
		{
			return new Dictionary<string, dynamic>()
			{
				["sourcePath"] = SourcePath,
				["destinationPath"] = SourcePath,
				["nextBackupUtc"] = NextBackupUtc.ToString("o")
			};
		}

		public void WriteToFile(string path) => FileUtil.SafeWriteAllText(path, JsonUtil.DictonaryToJson(ToJson()));
	}
}
