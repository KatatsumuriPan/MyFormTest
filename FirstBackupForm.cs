using MyUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Logger;

namespace MyBackup
{
	public partial class FirstBackupForm : Form
	{
		public static void Do(BackupConfig config)
		{
			FirstBackupForm form = new(config);
			form.ShowDialog();
		}

		private readonly BackupConfig config;
		private readonly BackupManager backupManager;
		private LogListener Listener { get; }

		private FirstBackupForm(BackupConfig config)
		{
			this.config = config;
			backupManager = new(config);
			Listener = (logLevel, message, fullMsg) =>
				Log(string.Format("[{0}][{1}]{2}", DateTime.Now.ToString("HH:mm:ss.fff"), logLevel.ToString(), message));
			InitializeComponent();
		}


		private void Log(string message)
		{
			Invoke(() =>
			{
				richTextBox1.HideSelection = false;
				richTextBox1.AppendText(message + "\n");
			});
		}

		private void StartBackup()
		{
			backupManager.LoggerNullable!.LogListeners += Listener;
			backupManager.BackupAll();
			backupManager.LoggerNullable!.LogListeners -= Listener;
			Invoke(() =>
			{
				MessageBox.Show("完了しました");
			});
		}

		private void FirstBackupForm_Shown(object sender, EventArgs e)
		{
			Task.Run(StartBackup);
		}
	}
}
