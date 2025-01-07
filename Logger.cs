using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Logger
{
	/// <summary>
	/// ログレベル
	/// </summary>
	public enum EnumLogLevel
	{
		ERROR,
		WARN,
		INFO,
		DEBUG
	}

	public delegate void LogListener(EnumLogLevel logLevel, string message, string fullMsg);

	private readonly object lockObj = new();
	public StreamWriter? Stream { get; private set; } = null;
	public EnumLogLevel LogLevel { get; set; } = EnumLogLevel.DEBUG;
	public event LogListener? LogListeners;

	/// <summary>
	/// コンストラクタ
	/// </summary>
	public Logger()
	{
	}

	public void OpenLogFile(string logFilePath)
	{
		// ログファイルを生成する
		if (!Directory.Exists(Path.GetDirectoryName(logFilePath)))
		{
			Directory.CreateDirectory(Path.GetDirectoryName(logFilePath)!);
		}

		Stream = new StreamWriter(logFilePath, true, Encoding.UTF8)
		{
			AutoFlush = true
		};
	}


	/// <summary>
	/// ERRORレベルのログを出力する
	/// </summary>
	/// <param name="msg">メッセージ</param>
	public void Error(string msg)
	{
		if (EnumLogLevel.ERROR <= LogLevel)
		{
			Out(EnumLogLevel.ERROR, msg);
		}
	}

	/// <summary>
	/// ERRORレベルのスタックトレースログを出力する
	/// </summary>
	/// <param name="ex">例外オブジェクト</param>
	public void Error(Exception ex)
	{
		if (EnumLogLevel.ERROR <= LogLevel)
		{
			Out(EnumLogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
		}
	}

	/// <summary>
	/// WARNレベルのログを出力する
	/// </summary>
	/// <param name="msg">メッセージ</param>
	public void Warn(string msg)
	{
		if (EnumLogLevel.WARN <= LogLevel)
		{
			Out(EnumLogLevel.WARN, msg);
		}
	}

	/// <summary>
	/// INFOレベルのログを出力する
	/// </summary>
	/// <param name="msg">メッセージ</param>
	public void Info(string msg)
	{
		if (EnumLogLevel.INFO <= LogLevel)
		{
			Out(EnumLogLevel.INFO, msg);
		}
	}

	/// <summary>
	/// DEBUGレベルのログを出力する
	/// </summary>
	/// <param name="msg">メッセージ</param>
	public void Debug(string msg)
	{
		if (EnumLogLevel.DEBUG <= LogLevel)
		{
			Out(EnumLogLevel.DEBUG, msg);
		}
	}

	/// <summary>
	/// ログを出力する
	/// </summary>
	/// <param name="level">ログレベル</param>
	/// <param name="msg">メッセージ</param>
	private void Out(EnumLogLevel level, string msg)
	{
		int tid = Thread.CurrentThread.ManagedThreadId;
		string fullMsg = string.Format("[{0}][{1}][{2}] {3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), tid, level.ToString(), msg);

		lock (lockObj)
		{
			Stream?.WriteLine(fullMsg);
			LogListeners?.Invoke(level, msg, fullMsg);
		}
	}

	public void CloseLogFile()
	{
		lock (lockObj)
		{
			Stream?.Close();
			Stream = null;
		}
	}
}

