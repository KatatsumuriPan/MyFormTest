using MyExtensions;
using MyUtils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackup
{
	public record BackupFileInfo(string FileRelPath, long FileSize, DateTime LastModifiedTimeUtc, FileHash Hash, int LastBackedupAge)
	{
		public static BackupFileInfo Create(FileInfo fileInfo, string baseDir, int lastBackedupAge)
		{
			string fileRelPath = Path.GetRelativePath(baseDir, fileInfo.FullName);
			long fileSize = fileInfo.Length;
			DateTime lastModifiedTimeUtc = fileInfo.LastWriteTimeUtc;
			FileHash fileHash = FileHash.CalsHash(fileInfo);
			return new(fileRelPath, fileSize, lastModifiedTimeUtc, fileHash, lastBackedupAge);
		}
		public static BackupFileInfo FromJson(Dictionary<string, dynamic> json)
		{
			string fileRelPath = json["filePath"];
			long fileSize = json["fileSize"];
			DateTime lastModifiedTimeUtc = DateTimeUtil.ParseUtc(json["lastModifiedTimeUtc"]);
			FileHash fileHash = FileHash.FromJson(json["fileHash"]);
			int lastBackedupAge = json["lastBackedupAge"];
			return new(fileRelPath, fileSize, lastModifiedTimeUtc, fileHash, lastBackedupAge);
		}


		public Dictionary<string, dynamic> ToJson()
		{
			Dictionary<string, dynamic> json = new();
			json["filePath"] = FileRelPath;
			json["fileSize"] = FileSize;
			json["lastModifiedTimeUtc"] = LastModifiedTimeUtc.ToStringUtc();
			json["fileHash"] = Hash.ToJson();
			json["lastBackedupAge"] = LastBackedupAge;
			return json;
		}
	}
}
