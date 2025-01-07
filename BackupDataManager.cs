using BsDiff;
using Hyldahl.Hashing.SpamSum;
using MyExtensions;
using MyUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyBackup
{
	public class BackupDataManager
	{
		private readonly string backupDataDir;
		private Dictionary<FileHash, AbstractDataInfo> backupData = new();

		public BackupDataManager(string backupDataDir)
		{
			this.backupDataDir = backupDataDir;
			LoadAllInfos();
		}

		public void AddData(string fileFullPath)
		{
			FileHash hash = FileHash.CalsHash(fileFullPath);
			if (backupData.TryGetValue(hash, out AbstractDataInfo? info))
			{
				info.IncrementDirectReferenceCount();
				return;
			}
			long fileSize = new FileInfo(fileFullPath).Length;
			FuzzyHash fuzzyHash = FuzzyHash.CalcFuzzyHash(fileFullPath);
			AbstractDataInfo? nearest = FindNearest(fuzzyHash, fileSize);
			if (nearest is not null)
			{
				PatchDataInfo newInfo = PatchDataInfo.Create(this, fileFullPath, fileSize, hash, fuzzyHash, nearest);
				backupData[hash] = newInfo;
			}
			else
			{
				SingleDataInfo newInfo = SingleDataInfo.Create(this, fileFullPath, fileSize, hash, fuzzyHash);
				backupData[hash] = newInfo;
			}
		}

		public void AddData(string fileFullPath, string groupName, long maxSize, int maxDataNum)
		{
			FileHash hash = FileHash.CalsHash(fileFullPath);
			if (backupData.TryGetValue(hash, out AbstractDataInfo? info))
			{
				info.IncrementDirectReferenceCount();
			}
			long fileSize = new FileInfo(fileFullPath).Length;
			FuzzyHash fuzzyHash = FuzzyHash.CalcFuzzyHash(fileFullPath);
			AbstractDataInfo? nearest = FindNearest(fuzzyHash, fileSize);
			if (nearest is not null)
			{
				PatchDataInfo newInfo = PatchDataInfo.Create(this, fileFullPath, fileSize, hash, fuzzyHash, nearest);
				backupData[hash] = newInfo;
			}
			else
			{
				GroupDataInfo newInfo = GroupDataInfo.Create(this, fileFullPath, fileSize, hash, fuzzyHash, groupName, maxSize, maxDataNum);
				backupData[hash] = newInfo;
			}
		}

		public void RemoveData(in FileHash hash)
		{
			AbstractDataInfo info = GetInfoInternal(hash);
			info.DecrementDirectReferenceCount(this);
		}

		public (long fileSize, FuzzyHash fuzzyHash) GetInfo(in FileHash hash)
		{
			AbstractDataInfo info = GetInfoInternal(hash);
			return (info.FileSize, info.FuzzyHash);
		}
		public byte[] GetData(in FileHash hash) => GetInfoInternal(hash).GetData(this);

		public void IncrementReference(in FileHash hash)
		{
			GetInfoInternal(hash).IncrementDirectReferenceCount();
		}

		private AbstractDataInfo GetInfoInternal(in FileHash hash) => backupData[hash];
		private void RemoveInfoInternal(in FileHash hash) => backupData.Remove(hash);
		private void ReplaceInfoInternal(in FileHash hash, AbstractDataInfo newInfo) => backupData[hash] = newInfo;

		private AbstractDataInfo? FindNearest(FuzzyHash fuzzyHash, long fileSize)
		{
			//ファイルサイズが大きすぎる場合はパッチ作成が不可能なのでスキップ
			if (fileSize > (long)1024 * 1024 * 1024 * 2)
				return null;

			AbstractDataInfo? nearest = null;
			int nearestScore = 0; //似てないファイルはscoreが0になるので、0より大きいと似てると考える

			foreach (var other in backupData.Values)
			{
				int score = fuzzyHash.CalcScore(other.FuzzyHash);
				//スコアが大きい or スコア一緒でファイルサイズが近い
				if (score > nearestScore || score == nearestScore && nearest is not null && Math.Abs(fileSize - other.FileSize) < Math.Abs(fileSize - nearest.FileSize))
				{
					nearestScore = score;
					nearest = other;
				}
			}
			return nearest;
		}

		private void LoadAllInfos()
		{
			var singleInfos = SingleDataInfo.LoadAllInfos(this);
			backupData.AddAll(singleInfos.Select(i => KeyValuePair.Create(i.Hash, (AbstractDataInfo)i)));
			var groupInfos = GroupDataInfo.LoadAllInfos(this);
			backupData.AddAll(groupInfos.Select(i => KeyValuePair.Create(i.Hash, (AbstractDataInfo)i)));
			var patchInfos = PatchDataInfo.LoadAllInfos(this);
			backupData.AddAll(patchInfos.Select(i => KeyValuePair.Create(i.Hash, (AbstractDataInfo)i)));
		}

		private abstract class AbstractDataInfo
		{
			public long FileSize { get; }
			public FileHash Hash { get; }
			public FuzzyHash FuzzyHash { get; }
			protected int directReferenceNum;
			protected readonly HashSet<FileHash> patchReferences;

			protected AbstractDataInfo(long fileSize, in FileHash hash, FuzzyHash fuzzyHash) : this(fileSize, hash, fuzzyHash, 1, new())
			{
			}
			protected AbstractDataInfo(long fileSize, in FileHash hash, FuzzyHash fuzzyHash, int directReferenceNum, HashSet<FileHash> patchReferences)
			{
				Hash = hash;
				FuzzyHash = fuzzyHash;
				this.directReferenceNum = directReferenceNum;
				this.patchReferences = patchReferences;
				FileSize = fileSize;
			}

			public abstract byte[] GetData(BackupDataManager dataManager);
			protected abstract void RemoveData(BackupDataManager dataManager);

			public void IncrementDirectReferenceCount()
			{
				directReferenceNum++;
			}

			public void DecrementDirectReferenceCount(BackupDataManager dataManager)
			{
				directReferenceNum--;
				RemoveIfCan(dataManager);
			}

			public void AddPatchReference(PatchDataInfo info)
			{
				patchReferences.Add(info.Hash);
			}

			public void RemovePatchReference(BackupDataManager dataManager, in FileHash hash)
			{
				patchReferences.Remove(hash);
				RemoveIfCan(dataManager);
			}

			private void RemoveIfCan(BackupDataManager dataManager)
			{
				if (directReferenceNum > 0)
					return;
				if (patchReferences.Count == 0)
				{
					//完全に参照なし
					RemoveData(dataManager);
					dataManager.RemoveInfoInternal(Hash);
				}
				else if (patchReferences.Count == 1)
				{
					//パッチ後のデータをSingleとして作り直す
					PatchDataInfo infoAfterPatch = (PatchDataInfo)dataManager.GetInfoInternal(patchReferences.First());
					SingleDataInfo newInfo = infoAfterPatch.ConvertToSingle(dataManager);

					infoAfterPatch.RemoveData(dataManager);
					dataManager.ReplaceInfoInternal(infoAfterPatch.Hash, newInfo);
					RemoveData(dataManager);
					dataManager.RemoveInfoInternal(Hash);
				}
			}
		}

		private class SingleDataInfo : AbstractDataInfo
		{
			public static SingleDataInfo Create(BackupDataManager dataManager, string fileFullPath, long fileSize, in FileHash hash, FuzzyHash fuzzyHash)
			{
				SingleDataInfo res = new(fileSize, hash, fuzzyHash);
				res.StoreInfo(dataManager);
				res.StoreData(dataManager, fileFullPath);
				return res;
			}
			public static SingleDataInfo Create(BackupDataManager dataManager, byte[] data, in FileHash hash, FuzzyHash fuzzyHash, int directReferenceNum, HashSet<FileHash> patchReferences)
			{
				SingleDataInfo res = new(data.Length, hash, fuzzyHash, directReferenceNum, patchReferences);
				res.StoreInfo(dataManager);
				res.StoreData(dataManager, data);
				return res;
			}
			public static IEnumerable<SingleDataInfo> LoadAllInfos(BackupDataManager dataManager)
			{
				string dataDir = Path.Combine(dataManager.backupDataDir, "single", "data");
				if (!Directory.Exists(dataDir))
					yield break;
				foreach (var infoPath in Directory.EnumerateFiles(dataDir, "*.info"))
				{
					Dictionary<string, dynamic> json = JsonUtil.ParseJson(infoPath);
					long fileSize = json["fileSize"];
					FileHash hash = FileHash.FromJson(Path.GetFileNameWithoutExtension(infoPath));
					FuzzyHash fuzzyHash = FuzzyHash.FromJson(json["fuzzyHash"]);
					int directReferenceNum = json["directReferenceNum"];
					HashSet<FileHash> patchReferences = new HashSet<FileHash>(((List<string>)json["patchReferences"]).Select(str => new FileHash(str)));
					yield return new(fileSize, hash, fuzzyHash, directReferenceNum, patchReferences);
				}
			}

			private SingleDataInfo(long fileSize, in FileHash hash, FuzzyHash fuzzyHash) : base(fileSize, hash, fuzzyHash)
			{
			}
			private SingleDataInfo(long fileSize, in FileHash hash, FuzzyHash fuzzyHash, int directReferenceNum, HashSet<FileHash> patchReferences) : base(fileSize, hash, fuzzyHash, directReferenceNum, patchReferences)
			{
			}

			public override byte[] GetData(BackupDataManager dataManager)
			{
				string filePath = GetDataPath(dataManager);
				return SevenZipHelper.ExtractAsByteSingle(filePath);
			}
			protected override void RemoveData(BackupDataManager dataManager)
			{
				File.Delete(GetInfoPath(dataManager));
				File.Delete(GetDataPath(dataManager));
			}

			private string GetInfoPath(BackupDataManager dataManager) => Path.Combine(dataManager.backupDataDir, "single", "data", $"{Hash}.info");
			private string GetDataPath(BackupDataManager dataManager) => Path.Combine(dataManager.backupDataDir, "single", "data", $"{Hash}.bin");
			private void StoreInfo(BackupDataManager dataManager)
			{
				string filePath = GetInfoPath(dataManager);
				Dictionary<string, dynamic> json = new();
				json["fileSize"] = FileSize;
				json["fuzzyHash"] = FuzzyHash.ToJson();
				json["directReferenceNum"] = directReferenceNum;
				json["patchReferences"] = patchReferences.Select(h => h.ToJson()).ToArray();
				string jsonText = JsonUtil.DictonaryToJson(json);
				FileUtil.SafeWriteAllText(filePath, jsonText);
			}
			private void StoreData(BackupDataManager dataManager, string sourceFullPath)
			{
				string filePath = GetDataPath(dataManager);
				SevenZipHelper.CompressSingle(filePath, sourceFullPath);
			}
			private void StoreData(BackupDataManager dataManager, byte[] data)
			{
				string filePath = GetDataPath(dataManager);
				FileUtil.SafeCreateDirectoryOf(filePath);
				SevenZipHelper.CompressSingle(filePath, data);
			}

		}

		private class GroupDataInfo : AbstractDataInfo
		{

			public static GroupDataInfo Create(BackupDataManager dataManager, string fileFullPath, long fileSize, in FileHash hash, FuzzyHash fuzzyHash, string groupName, long maxSize, int maxDataNum)
			{
				Group group = Group.Get(groupName, new FileInfo(fileFullPath), maxSize, maxDataNum);
				return group.AddData(dataManager, fileFullPath, fileSize, hash, fuzzyHash);
			}

			public static IEnumerable<GroupDataInfo> LoadAllInfos(BackupDataManager dataManager) => Group.LoadAllInfos(dataManager);

			private static GroupDataInfo FromJsonInternal(Group parent, Dictionary<string, dynamic> json)
			{
				int fileSize = json["fileSize"];
				FileHash hash = FileHash.FromJson(json["fileHash"]);
				FuzzyHash fuzzyHash = FuzzyHash.FromJson(json["fuzzyHash"]);
				int directReferenceNum = json["directReferenceNum"];
				HashSet<FileHash> patchReferences = new HashSet<FileHash>(((List<string>)json["patchReferences"]).Select(str => new FileHash(str)));
				return new(fileSize, hash, fuzzyHash, directReferenceNum, patchReferences, parent);
			}

			private readonly Group parent;

			private GroupDataInfo(long fileSize, in FileHash hash, FuzzyHash fuzzyHash, Group parent) : base(fileSize, hash, fuzzyHash)
			{
				this.parent = parent;
			}
			private GroupDataInfo(long fileSize, in FileHash hash, FuzzyHash fuzzyHash, int directReferenceNum, HashSet<FileHash> patchReferences, Group parent) : base(fileSize, hash, fuzzyHash, directReferenceNum, patchReferences)
			{
				this.parent = parent;
			}

			public override byte[] GetData(BackupDataManager dataManager)
			{
				return parent.GetData(dataManager, Hash);
			}

			protected override void RemoveData(BackupDataManager dataManager)
			{
				parent.Remove(dataManager, this);
			}

			private Dictionary<string, dynamic> ToJsonInternal()
			{
				Dictionary<string, dynamic> json = new();
				json["fileSize"] = FileSize;
				json["fileHash"] = Hash.ToJson();
				json["fuzzyHash"] = FuzzyHash.ToJson();
				json["directReferenceNum"] = directReferenceNum;
				json["patchReferences"] = patchReferences.Select(h => h.ToJson()).ToArray();
				return json;
			}

			private class Group
			{
				private static readonly Dictionary<string, Group> groups = new();
				public static Group Get(string groupName, FileInfo fileInfo, long maxSize, int maxDataNum)
				{
					int retry = 0;
					while (true)
					{
						string name = CreateGroupName(groupName, retry);
						if (groups.TryGetValue(name, out Group? group))
						{
							if (group.CanAdd(fileInfo))
								return group;
						}
						else
						{
							group = new(name, maxSize, maxDataNum);
							groups[name] = group;
							return group;
						}
						retry++;
					}
				}
				public static IEnumerable<GroupDataInfo> LoadAllInfos(BackupDataManager dataManager)
				{
					string dataDir = Path.Combine(dataManager.backupDataDir, "group", "data");
					if (!Directory.Exists(dataDir))
						yield break;
					foreach (var infoPath in Directory.EnumerateFiles(dataDir, "*.info"))
					{

						Dictionary<string, dynamic> json = JsonUtil.ParseJson(infoPath);
						string groupName = json["groupName"];
						long maxSize = json["maxSize"];
						int maxDataNum = json["maxDataNum"];
						Group group = new(groupName, maxSize, maxDataNum);
						groups[groupName] = group;

						foreach (Dictionary<string, dynamic> item in json["items"])
						{
							GroupDataInfo info = GroupDataInfo.FromJsonInternal(group, item);
							group.infos[info.Hash] = info;
							yield return info;
						}
					}
				}

				private readonly string groupName;
				private readonly long maxSize;
				private readonly int maxDataNum;
				private readonly Dictionary<FileHash, GroupDataInfo> infos = new();
				private long currentSize = 0;
				private long currentDataNum = 0;

				private Group(string groupName, long maxSize, int maxDataNum)
				{
					this.groupName = groupName;
					this.maxSize = maxSize;
					this.maxDataNum = maxDataNum;
				}

				public GroupDataInfo AddData(BackupDataManager dataManager, string fileFullPath, long fileSize, in FileHash hash, FuzzyHash fuzzyHash)
				{
					AddDataToArchive(dataManager, fileFullPath, hash);
					GroupDataInfo info = new(fileSize, hash, fuzzyHash, this);
					infos[hash] = info;
					currentSize += new FileInfo(fileFullPath).Length;
					currentDataNum += 1;
					StoreInfo(dataManager);
					return info;
				}

				public byte[] GetData(BackupDataManager dataManager, in FileHash hash)
				{
					return SevenZipHelper.ExtractAsByte(GetDataPath(dataManager), hash.ToString());
				}

				public void Remove(BackupDataManager dataManager, GroupDataInfo info)
				{
					infos.Remove(info.Hash);
					if (infos.Count == 0)
					{
						File.Delete(GetInfoPath(dataManager));
						File.Delete(GetDataPath(dataManager));
					}
				}

				private bool CanAdd(FileInfo fileInfo)
				{
					if (currentSize + fileInfo.Length > maxSize)
						return false;
					if (currentDataNum + 1 > maxDataNum)
						return false;
					return true;
				}
				private string GetInfoPath(BackupDataManager dataManager) => Path.Combine(dataManager.backupDataDir, "group", "data", $"{groupName}.info");
				private string GetDataPath(BackupDataManager dataManager) => Path.Combine(dataManager.backupDataDir, "group", "data", $"{groupName}.bin");
				private void StoreInfo(BackupDataManager dataManager)
				{
					string filePath = GetInfoPath(dataManager);
					Dictionary<string, dynamic> json = new();
					json["groupName"] = groupName;
					json["maxSize"] = maxSize;
					json["maxDataNum"] = maxDataNum;
					json["items"] = infos.Values.Select(i => i.ToJsonInternal()).ToArray();
					string jsonText = JsonUtil.DictonaryToJson(json);
					FileUtil.SafeWriteAllText(filePath, jsonText);
				}
				private void AddDataToArchive(BackupDataManager dataManager, string sourceFullPath, in FileHash hash)
				{
					string dataFilePath = GetDataPath(dataManager);
					if (File.Exists(dataFilePath))
					{
						SevenZipHelper.AddSingle(dataFilePath, sourceFullPath, hash.ToString());
					}
					else
					{
						SevenZipHelper.CompressSingle(dataFilePath, sourceFullPath, hash.ToString());
					}
				}

				private static string CreateGroupName(string baseName, int retryCount)
				{
					if (retryCount == 0)
						return baseName;
					return $"{baseName}__#{retryCount}";
				}
			}
		}

		private class PatchDataInfo : AbstractDataInfo
		{
			public static PatchDataInfo Create(BackupDataManager dataManager, string fileFullPath, long fileSize, in FileHash hash, FuzzyHash fuzzyHash, AbstractDataInfo nearest)
			{
				PatchDataInfo res = new(fileSize, hash, fuzzyHash, nearest.Hash);
				res.StoreInfo(dataManager);
				res.StoreData(dataManager, nearest.GetData(dataManager), File.ReadAllBytes(fileFullPath));
				return res;
			}

			public static IEnumerable<PatchDataInfo> LoadAllInfos(BackupDataManager dataManager)
			{
				string dataDir = Path.Combine(dataManager.backupDataDir, "patch", "data");
				if (!Directory.Exists(dataDir))
					yield break;
				foreach (var infoPath in Directory.EnumerateFiles(dataDir, "*.info"))
				{
					Dictionary<string, dynamic> json = JsonUtil.ParseJson(infoPath);

					long fileSize = json["fileSize"];
					FileHash hash = new(Path.GetFileNameWithoutExtension(infoPath));
					FuzzyHash fuzzyHash = FuzzyHash.FromJson(json["fuzzyHash"]);
					int directReferenceNum = json["directReferenceNum"];
					HashSet<FileHash> patchReferences = new HashSet<FileHash>(((List<string>)json["patchReferences"]).Select(str => new FileHash(str)));
					FileHash patchSource = new(json["patchSource"]);

					yield return new(fileSize, hash, fuzzyHash, directReferenceNum, patchReferences, patchSource);
				}
			}

			private readonly FileHash patchSource;

			private PatchDataInfo(long fileSize, in FileHash hash, FuzzyHash fuzzyHash, in FileHash patchSource) : base(fileSize, hash, fuzzyHash)
			{
				this.patchSource = patchSource;
			}
			private PatchDataInfo(long fileSize, in FileHash hash, FuzzyHash fuzzyHash, int directReferenceNum, HashSet<FileHash> patchReferences, in FileHash patchSource) : base(fileSize, hash, fuzzyHash, directReferenceNum, patchReferences)
			{
				this.patchSource = patchSource;
			}

			public SingleDataInfo ConvertToSingle(BackupDataManager dataManager)
			{
				return SingleDataInfo.Create(dataManager, GetData(dataManager), Hash, FuzzyHash, directReferenceNum, patchReferences);
			}

			public override byte[] GetData(BackupDataManager dataManager)
			{
				string patchDataPath = GetDataPath(dataManager);
				string tmpPatchDataPath = SevenZipHelper.ExtractSingleTemporarily(patchDataPath);
				using Stream baseByteStream = new MemoryStream(dataManager.GetData(patchSource));
				using MemoryStream outputStream = new();
				BinaryPatch.Apply(baseByteStream, () => File.OpenRead(patchDataPath), outputStream);
				File.Delete(tmpPatchDataPath);
				return outputStream.ToArray();
			}
			protected override void RemoveData(BackupDataManager dataManager)
			{
				File.Delete(GetInfoPath(dataManager));
				File.Delete(GetDataPath(dataManager));
				dataManager.GetInfoInternal(patchSource).RemovePatchReference(dataManager, Hash);
			}

			private string GetInfoPath(BackupDataManager dataManager) => Path.Combine(dataManager.backupDataDir, "patch", "data", $"{Hash}.info");
			private string GetDataPath(BackupDataManager dataManager) => Path.Combine(dataManager.backupDataDir, "patch", "data", $"{Hash}.patch");
			private void StoreInfo(BackupDataManager dataManager)
			{
				string filePath = GetInfoPath(dataManager);
				Dictionary<string, dynamic> json = new();
				json["fileSize"] = FileSize;
				json["fuzzyHash"] = FuzzyHash.ToJson();
				json["directReferenceNum"] = directReferenceNum;
				json["patchReferences"] = patchReferences.Select(h => h.ToJson()).ToArray();
				json["patchSource"] = patchSource;
				string jsonText = JsonUtil.DictonaryToJson(json);
				FileUtil.SafeWriteAllText(filePath, jsonText);
			}
			private void StoreData(BackupDataManager dataManager, byte[] before, byte[] after)
			{
				string filePath = GetDataPath(dataManager);
				string tmpFilePath = filePath + ".tmp";
				using (FileStream patchStream = File.Create(tmpFilePath))
				{
					BinaryPatch.Create(before, after, patchStream);
				}
				SevenZipHelper.CompressSingle(filePath, tmpFilePath, Path.GetFileName(filePath));//innerPathを設定する必要はないが見栄えのため
				File.Delete(tmpFilePath);

			}
		}

	}
}
