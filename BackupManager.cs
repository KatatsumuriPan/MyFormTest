using MyExtensions;
using MyUtils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackup
{
	public class BackupManager
	{
		private BackupConfig Config { get; }
		private readonly List<BackupOptionFilter> backupOptionFilters = new();
		private readonly SortedDictionary<int, BackupFileInfoManager> age2fileInfoManager = new();
		private readonly BackupDataManager dataManager;
		public Logger? LoggerNullable => GetLatestFileInfoManager()?.Logger;

		public BackupManager(BackupConfig config)
		{
			Config = config;
			dataManager = new(Path.Combine(config.DestinationPath, "data"));
			age2fileInfoManager.AddAll(
				BackupFileInfoManager.LoadAll(Config.SourcePath, GetFileInfoDirPath())
					.Select(bfim => KeyValuePair.Create(bfim.Age, bfim))
			);
			ReloadOptionFilters();
		}

		public void BackupAll()
		{
			LoggerNullable?.Info("全バックアップ開始");
			if (!GetLatestAge(out int age))
				age = 0;
			BackupFileInfoManager fileInfoManager = new(Config.SourcePath, GetFileInfoDirPath(), age);
			fileInfoManager.StartBackup();

			List<string> targets = ListFiles();

			//バックアップ
			foreach (string fileFullPath in targets)
			{
				BackupOption option = GetBackupOption(fileFullPath);
				if (option.BackupFile(dataManager, fileFullPath))
				{
					LoggerNullable?.Debug("バックアップ：" + fileFullPath);
					fileInfoManager.AddFile(fileFullPath);
				}
			}
			fileInfoManager.FinishBackup();
			//dataManager.FlushAll();
			LoggerNullable?.Info("完了");
			LoggerNullable?.Info("バックアップファイル数：" + targets.Count);

			return;

			List<string> ListFiles()
			{
				//全てのフィルタの読み込み
				ReloadOptionFilters();

				List<string> targets = new();
				int ignoredNum = 0;
				foreach (string fileFullPath in Directory.EnumerateFiles(Config.SourcePath, "*", SearchOption.AllDirectories))
				{
					BackupOption option = GetBackupOption(fileFullPath);
					if (!option.IsIgnored)
					{
						targets.Add(fileFullPath);
						LoggerNullable?.Debug("target:" + fileFullPath);
					}
					else
					{
						LoggerNullable?.Debug("ignored:" + fileFullPath);
						ignoredNum++;
					}
				}

				LoggerNullable?.Debug("対象：" + targets.Count + "ファイル");
				LoggerNullable?.Debug("無視：" + ignoredNum + "ファイル");

				return targets;
			}
		}

		public void BackupUpdatedAll()
		{
			LoggerNullable?.Info("差分バックアップ開始");
			if (!GetLatestAge(out int age))
				age = 0;
			BackupFileInfoManager fileInfoManager = new(Config.SourcePath, GetFileInfoDirPath(), age);
			fileInfoManager.StartBackup();
			(List<string> targets, List<string> latests) = ListFiles();

			//バックアップ
			foreach (string fileFullPath in targets)
			{
				BackupOption option = GetBackupOption(fileFullPath);
				if (option.BackupFile(dataManager, fileFullPath))
				{
					LoggerNullable?.Debug("バックアップ：" + fileFullPath);
					fileInfoManager.AddFile(fileFullPath);
				}
			}

			//更新不要ファイルの参照更新
			foreach (string fileFullPath in latests)
			{
				dataManager.IncrementReference(fileInfoManager.Get(fileFullPath).Hash);
			}

			fileInfoManager.FinishBackup();
			//dataManager.FlushAll();
			LoggerNullable?.Info("完了");
			LoggerNullable?.Info("バックアップファイル数：" + targets.Count);
			LoggerNullable?.Info("更新不要ファイル数：" + latests.Count);

			return;

			(List<string> targets, List<string> alreadyLatest) ListFiles()
			{
				//全てのフィルタの読み込み
				ReloadOptionFilters();

				List<string> targets = new();
				List<string> latests = new();
				int ignoredNum = 0;
				foreach (string fileFullPath in Directory.EnumerateFiles(Config.SourcePath, "*", SearchOption.AllDirectories))
				{
					BackupOption option = GetBackupOption(fileFullPath);
					if (!option.IsIgnored)
					{
						if (fileInfoManager.IsLatest(new FileInfo(fileFullPath)))
						{
							latests.Add(fileFullPath);
							LoggerNullable?.Debug("latest:" + fileFullPath);
						}
						else
						{
							targets.Add(fileFullPath);
							LoggerNullable?.Debug("target:" + fileFullPath);
						}
					}
					else
					{
						LoggerNullable?.Debug("ignored:" + fileFullPath);
						ignoredNum++;
					}
				}

				LoggerNullable?.Debug("対象：" + targets.Count + "ファイル");
				LoggerNullable?.Debug("更新不要：" + latests.Count + "ファイル");
				LoggerNullable?.Debug("無視：" + ignoredNum + "ファイル");
				return (targets, latests);
			}
		}

		public void ReloadOptionFilters()
		{
			backupOptionFilters.Clear();
			foreach (string path in Directory.EnumerateFiles(Config.SourcePath, ".backupoption", SearchOption.AllDirectories))
			{
				BackupOptionFilter.ReadFrom(path);
			}
		}

		public IReadOnlyCollection<BackupFileInfo> GetAllInfos()
		{
			BackupFileInfoManager? backupFileInfoManager = GetLatestFileInfoManager();
			return backupFileInfoManager is not null ? backupFileInfoManager.GetAllInfos() : EmptyUtil<BackupFileInfo>.Array;
		}

		public byte[] Extract(string fileFullPath) => dataManager.GetData(GetLatestFileInfoManager()!.Get(fileFullPath).Hash);

		private bool GetLatestAge(out int age)
		{
			age = -1;
			if (age2fileInfoManager.IsEmpty())
				return false;
			age = age2fileInfoManager.Keys.Last();
			return true;
		}

		private BackupFileInfoManager? GetLatestFileInfoManager()
		{
			if (!GetLatestAge(out int age))
				return null;
			return age2fileInfoManager[age];
		}

		private BackupOption GetBackupOption(string fileFullPath)
		{
			BackupOption option = new();
			foreach (var filter in backupOptionFilters)
			{
				filter.Apply(option, fileFullPath);
			}
			return option;
		}

		private string GetFileInfoDirPath() => Path.Combine(Config.DestinationPath, "fileInfo");

		private class BackupFileInfoManager
		{
			public static IEnumerable<BackupFileInfoManager> LoadAll(string backupSourceDirPath, string fileInfoDirPath)
			{
				string agesDirPath = GetAgesDirPath(fileInfoDirPath);
				if (!Directory.Exists(agesDirPath))
					yield break;
				foreach (var ageDir in Directory.EnumerateDirectories(agesDirPath))
				{
					int age = Path.GetFileName(ageDir).ToInt();
					BackupFileInfoManager manager = new(backupSourceDirPath, fileInfoDirPath, age);

					Dictionary<string, dynamic> json = JsonUtil.ParseJson(File.ReadAllText(manager.GetAgeInfoPath()));
					manager.backupStartedTimeUtc = DateTimeUtil.ParseUtc(json["backupStartedTimeUtc"]);

					foreach (Dictionary<string, dynamic> item in json["items"])
					{
						BackupFileInfo info = BackupFileInfo.FromJson(item);
						manager.fileRelPath2info[info.FileRelPath] = info;
					}
					yield return manager;
				}
			}

			public Logger Logger { get; } = new();

			public int Age { get; }
			private readonly string backupSourceDirPath;
			private readonly string fileInfoDirPath;
			private readonly Dictionary<string, BackupFileInfo> fileRelPath2info = new();
			private DateTime? backupStartedTimeUtc = null;

			public BackupFileInfoManager(string backupSourceDirPath, string fileInfoDirPath, int age)
			{
				this.backupSourceDirPath = backupSourceDirPath;
				this.fileInfoDirPath = fileInfoDirPath;
				Age = age;
			}

			public void StartBackup()
			{
				backupStartedTimeUtc = DateTime.UtcNow;
				Logger.OpenLogFile(Path.Combine(GetAgeDirPath(), "log.txt"));
			}

			public void AddFile(string fileFullPath)
			{
				FileInfo fileInfo = new(fileFullPath);
				BackupFileInfo backupFileInfo = BackupFileInfo.Create(fileInfo, backupSourceDirPath, Age);
				fileRelPath2info[ToRelPath(fileFullPath)] = backupFileInfo;
			}

			public bool IsLatest(FileInfo fileInfo)
			{
				if (!fileRelPath2info.TryGetValue(ToRelPath(fileInfo.FullName), out BackupFileInfo? info))
					return false;
				if (fileInfo.Length != info.FileSize)
					return false;
				if (fileInfo.LastWriteTimeUtc != info.LastModifiedTimeUtc)
					return false;
				return true;
			}

			public IReadOnlyCollection<BackupFileInfo> GetAllInfos() => fileRelPath2info.Values;

			public BackupFileInfo Get(string fileFullPath) => fileRelPath2info[ToRelPath(fileFullPath)];

			public void FinishBackup()
			{
				StoreInfos();
				backupStartedTimeUtc = null;
				Logger.CloseLogFile();
			}

			private void StoreInfos()
			{
				//global
				{
					Dictionary<string, dynamic> json = new();
					json["latestBackupAge"] = Age;
					FileUtil.SafeWriteAllText(GetGlobalInfoPath(), JsonUtil.DictonaryToJson(json));
				}
				//ages
				{
					string latestAgeInfoPath = GetAgeInfoPath();
					Dictionary<string, dynamic> json = new();
					json["backupStartedTimeUtc"] = backupStartedTimeUtc!.Value.ToStringUtc();
					json["backupFinishedTimeUtc"] = DateTime.UtcNow.ToStringUtc();
					json["items"] = fileRelPath2info.Values.Select(i => i.ToJson()).ToArray();
					FileUtil.SafeWriteAllText(latestAgeInfoPath, JsonUtil.DictonaryToJson(json));
				}
			}

			private string ToRelPath(string fullPath) => Path.GetRelativePath(backupSourceDirPath, fullPath);

			private string GetGlobalInfoPath() => GetGlobalInfoPath(fileInfoDirPath);
			private string GetAgeDirPath() => GetAgeDirPath(GetAgesDirPath(fileInfoDirPath), Age);
			private string GetAgeInfoPath() => GetAgeInfoPath(GetAgeDirPath());
			private static string GetGlobalInfoPath(string fileInfoDirPath) => Path.Combine(fileInfoDirPath, "info.json");
			private static string GetAgesDirPath(string fileInfoDirPath) => Path.Combine(fileInfoDirPath, "ages");
			private static string GetAgeDirPath(string agesDirPath, int age) => Path.Combine(agesDirPath, age.ToString());
			private static string GetAgeInfoPath(string ageDirPath) => Path.Combine(ageDirPath, "info.json");
		}
	}
}
