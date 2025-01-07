using Hyldahl.Hashing.SpamSum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyBackup
{
	public class FuzzyHash
	{
		private SpamSumSignature Value { get; }

		public static FuzzyHash CalcFuzzyHash(string filePath)
		{
			using FileStream stream = new FileInfo(filePath).OpenRead();
			return CalcFuzzyHash(stream);
		}
		public static FuzzyHash CalcFuzzyHash(Stream stream)
		{
			return new(FuzzyHashing.Calculate(stream));
		}

		public static FuzzyHash FromJson(dynamic json)
		{
			return new(new SpamSumSignature((string)json));
		}

		public FuzzyHash(SpamSumSignature value)
		{
			Value = value;
		}

		public int CalcScore(FuzzyHash other) => FuzzyHashing.Compare(Value, other.Value);

		public string ToJson() => ToString();

		public override string ToString() => Value.ToString();
	}
}
