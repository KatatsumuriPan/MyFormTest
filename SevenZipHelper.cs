using MyExtensions;
using MyUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class SevenZipHelper
{
	public static byte[] ExtractAsByteSingle(string archivePath)
	{
		string tempFile = ExtractSingleTemporarily(archivePath);
		byte[] res = File.ReadAllBytes(tempFile);
		File.Delete(tempFile);
		return res;
	}

	public static byte[] ExtractAsByte(string archivePath, string targetPath)
	{
		string tempDir = Path.GetTempFileName();
		Directory.CreateDirectory(tempDir);
		CallExtract(archivePath, targetPath, tempDir);
		string tempFile = Path.Combine(tempDir, Path.GetFileName(targetPath));
		byte[] res = File.ReadAllBytes(tempFile);
		File.Delete(tempFile);
		return res;
	}

	public static void ExtractSingle(string archivePath, string extractedFilePath)
	{
		string tempFile = ExtractSingleTemporarily(archivePath);
		File.Move(tempFile, extractedFilePath);
	}

	public static string ExtractSingleTemporarily(string archivePath)
	{
		string tempDir = Path.GetTempFileName();
		Directory.CreateDirectory(tempDir);
		CallExtractAll(archivePath, tempDir);
		string tempFile = Directory.EnumerateFiles(tempDir).First();
		return tempFile;
	}

	public static void ExtractSingle___(string archivePath, string targetPath, string extractedFilePath)
	{
		string tempFile = ExtractSingleTemporarily___(archivePath, targetPath);
		File.Move(tempFile, extractedFilePath);
	}

	public static string ExtractSingleTemporarily___(string archivePath, string targetPath)
	{
		string tempDir = Path.GetTempFileName();
		Directory.CreateDirectory(tempDir);
		CallExtract(archivePath, targetPath, tempDir);
		string tempFile = Path.Combine(tempDir, Path.GetFileName(targetPath));
		return tempFile;
	}

	public static void AddSingle(string archivePath, string sourcePath, string innerPath)
	{
		CompressSingle(archivePath, sourcePath, innerPath);
	}

	public static void CompressSingle(string archivePath, string sourcePath) => CompressSingle(archivePath, sourcePath, Path.GetFileName(sourcePath));
	public static void CompressSingle(string archivePath, string sourcePath, string innerPath)
	{
		string tempDir = Path.GetTempFileName();
		Directory.CreateDirectory(tempDir);
		string tempFile = Path.Combine(tempDir, innerPath);
		File.Copy(sourcePath, tempFile);
		CallCompressSingle(archivePath, innerPath, tempDir);
		File.Delete(tempFile);
	}

	public static void CompressSingle(string archivePath, byte[] data, string innerPath = "data.bin")
	{
		string tempDir = Path.GetTempFileName();
		Directory.CreateDirectory(tempDir);
		string tempFile = Path.Combine(tempDir, innerPath);
		File.WriteAllBytes(tempFile, data);
		CallCompressSingle(archivePath, innerPath, tempDir);
		File.Delete(tempFile);
	}


	private static void CallExtract(string archivePath, string targetPath, string extractDir)
	{
		SystemUtil.Start(@"C:\Program Files\7-Zip\7z.exe",
					"e",                    //パス無しでその場に抽出
					"-bb3",                 //出力ログレベル3
					"-ssw",                 //共有ファイルも圧縮
					"-y",                   //全ての質問にYesで答える
					$"-o{extractDir}",      //出力ディレクトリ
					$"-i!{targetPath}",     //対象アイテム
					archivePath
					).WaitForExit();
	}

	private static void CallExtractAll(string archivePath, string extractDir)
	{
		SystemUtil.Start(@"C:\Program Files\7-Zip\7z.exe",
					"e",                    //パス無しでその場に抽出
					"-bb3",                 //出力ログレベル3
					"-ssw",                 //共有ファイルも圧縮
					"-y",                   //全ての質問にYesで答える
					$"-o{extractDir}",      //出力ディレクトリ
					archivePath
					).WaitForExit();
	}

	private static void CallCompressSingle(string archivePath, string targetRelativePath, string targetBasePath)
	{
		SystemUtil.StartWithWorkingDir(@"C:\Program Files\7-Zip\7z.exe", targetBasePath,
					"a",                    //圧縮（追加）
					"-bb3",                 //出力ログレベル3
					"-ssw",                 //共有ファイルも圧縮
					"-y",                   //全ての質問にYesで答える
					archivePath,
					targetRelativePath
					).WaitForExit();
	}

}
