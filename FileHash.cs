using Hyldahl.Hashing.SpamSum;
using MyExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Hashing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyBackup
{
	public readonly struct FileHash : IEquatable<FileHash>
	{
		public static FileHash CalsHash(string filePath)
		{
			return CalsHash(new FileInfo(filePath));
		}
		public static FileHash CalsHash(FileInfo fileInfo)
		{
			using FileStream stream = fileInfo.OpenRead();
			return CalsHash(stream);
		}
		public static FileHash CalsHash(byte[] data)
		{
			using MemoryStream stream = new(data);
			return CalsHash(stream);
		}
		public static FileHash CalsHash(Stream stream)
		{
			return new(GetXxHash3(stream));
		}

		public static FileHash FromJson(dynamic json) => new(json);

		public string Value { get; }

		public FileHash(string value)
		{
			Value = value;
		}

		public string ToJson() => ToString();

		public override bool Equals(object? obj) => obj is FileHash other && Equals(other);
		public bool Equals(FileHash other) => Value == other.Value;
		public override int GetHashCode() => HashCode.Combine(Value);
		public override string ToString() => Value;
		public static bool operator ==(in FileHash left, in FileHash right) => left.Equals(right);
		public static bool operator !=(in FileHash left, in FileHash right) => !(left == right);


		private static string GetXxHash3(Stream stream)
		{
			XxHash3 xxHash = new();
			const int BUFFER_SIZE = 1024 * 1024; //=1MB
			var buffer = new byte[BUFFER_SIZE];

			while (true)
			{
				var bytesRead = stream.Read(buffer, 0, buffer.Length);
				if (bytesRead == 0)
					break;
				// AsSpanを使って読み込んだデータだけAppendする。
				xxHash.Append(buffer.AsSpan(0, bytesRead));
			}
			return xxHash.GetHashAndReset().Select(b => b.ToStringHEX(2, false)).JoinToString("");
		}
	}
}
