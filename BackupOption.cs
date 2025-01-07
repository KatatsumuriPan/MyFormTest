using MyExtensions;
using MyUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyBackup
{
	public class BackupOption
	{
		public bool IsIgnored { get; set; } = false;
		public string? groupName = null;
		public long groupMaxSize = long.MaxValue;
		public int groupMaxDataNum = int.MaxValue;



		public bool BackupFile(BackupDataManager dataManager, string fileFullPath)
		{
			if (IsIgnored)
				return false;
			if (groupName is not null)
				dataManager.AddData(fileFullPath, groupName, groupMaxSize, groupMaxDataNum);
			else
				dataManager.AddData(fileFullPath);
			return true;
		}

	}

	public class BackupOptionFilter : IComparable<BackupOptionFilter>
	{
		public static BackupOptionFilter ReadFrom(string filePath)
		{
			BackupOptionFilter res = new(Path.GetDirectoryName(filePath)!);

			foreach (var line in File.ReadAllLines(filePath))
			{
				string trimmedLine = line[..line.IndexOf('#')].Trim();
				if (trimmedLine.IsEmpty())
					continue;
				res.filters.Add(Filter.Parse(line));
			}
			return res;
		}

		private string dir;
		private List<Filter> filters;

		private BackupOptionFilter(string dir)
		{
			this.dir = dir;
			filters = new();
		}

		public void Apply(BackupOption option, string fileFullPath)
		{
			if (!fileFullPath.StartsWith(dir))
				return;
			string relativePath = fileFullPath[dir.Length..].Replace('\\', '/');
			foreach (Filter f in filters)
			{
				f.Apply(option, relativePath);
			}
		}

		public int CompareTo(BackupOptionFilter? other)
		{
			if (other is null)
				return 1;
			return dir.CompareTo(other.dir);
		}

		private abstract class Filter
		{
			public static Filter Parse(string line)
			{
				string type = line.Contains('\t') ? line.Substring("", "\t") : line;
				switch (type.ToLower())
				{
					case "ignore":
						return IgnoreFilter.Create(line);
					case "add":
						return AddFilter.Create(line);
					case "single":
						return SingleFilter.Create(line);
					case "group":
						return GroupFilter.Create(line);
					default:
						throw new ArgumentException("無効なタイプ：" + type);
				}
			}

			public abstract void Apply(BackupOption option, string filePath);

			private abstract class PathFilter : Filter
			{
				public static Regex ParseGitPattern(string pattern)
				{
					string regexPattern;
					if (pattern.Contains('/'))
					{
						if (pattern.EndsWith('/'))
						{
							if (pattern.IndexOf('/') == pattern.Length - 1)
							{
								//対象：フォルダ
								//再帰：可
								regexPattern = $"^([^/]+/)*{pattern}[^/]+(/[^/]+)*$";
							}
							else
							{
								//対象：フォルダ
								//再帰：不可
								if (pattern.StartsWith('/'))
									pattern = pattern[1..];
								regexPattern = $"^{pattern}[^/]+(/[^/]+)*$";
							}
						}
						else
						{
							//対象：ファイル/フォルダ
							//再帰：不可
							if (pattern.StartsWith('/'))
								pattern = pattern[1..];
							regexPattern = $"^{pattern}(/[^/]+)*$";
						}
					}
					else
					{
						//対象：ファイル/フォルダ
						//再帰：可
						regexPattern = $"^([^/]+/)*{pattern}(/[^/]+)*$";
					}

					return new Regex(regexPattern, RegexOptions.CultureInvariant);
				}
				private readonly Regex pattern;

				protected PathFilter(Regex pattern)
				{
					this.pattern = pattern;
				}

				protected abstract void ApplyInternal(BackupOption option);

				public override void Apply(BackupOption option, string relativePath)
				{
					if (pattern.IsMatch(relativePath))
						ApplyInternal(option);
				}

			}
			private class IgnoreFilter : PathFilter
			{
				public static IgnoreFilter Create(string line)
				{
					string[] split = line.Split('\t');
					return new(ParseGitPattern(split.Length >= 2 ? split[1] : "*"));
				}

				private IgnoreFilter(Regex pattern) : base(pattern)
				{
				}

				protected override void ApplyInternal(BackupOption option)
				{
					option.IsIgnored = true;
				}
			}
			private class AddFilter : PathFilter
			{
				public static AddFilter Create(string line)
				{
					string[] split = line.Split('\t');
					return new(ParseGitPattern(split.Length >= 2 ? split[1] : "*"));
				}

				private AddFilter(Regex pattern) : base(pattern)
				{
				}

				protected override void ApplyInternal(BackupOption option)
				{
					option.IsIgnored = false;
				}
			}
			private class SingleFilter : PathFilter
			{
				public static SingleFilter Create(string line)
				{
					string[] split = line.Split('\t');
					return new(ParseGitPattern(split.Length >= 2 ? split[1] : "*"));
				}

				private SingleFilter(Regex pattern) : base(pattern)
				{
				}

				protected override void ApplyInternal(BackupOption option)
				{
					option.groupName = null;
				}
			}
			private class GroupFilter : PathFilter
			{
				public static GroupFilter Create(string line)
				{
					string[] split = line.Split('\t');
					string groupName = split[1];
					long groupMaxSize = long.Parse(split[2]);
					int groupMaxDataNum = split[3].ToInt();
					Regex pattern = ParseGitPattern(split.Length >= 5 ? split[4] : "*");
					return new(pattern, groupName, groupMaxSize, groupMaxDataNum);
				}

				private readonly string groupName;
				private readonly long groupMaxSize;
				private readonly int groupMaxDataNum;

				private GroupFilter(Regex pattern, string groupName, long groupMaxSize, int groupMaxDataNum) : base(pattern)
				{
					this.groupName = groupName;
					this.groupMaxSize = groupMaxSize;
					this.groupMaxDataNum = groupMaxDataNum;
				}

				protected override void ApplyInternal(BackupOption option)
				{
					option.groupName = groupName;
					option.groupMaxSize = groupMaxSize;
					option.groupMaxDataNum = groupMaxDataNum;
				}
			}
		}
	}
}
