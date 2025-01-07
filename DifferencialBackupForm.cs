using BsDiff;
using Hyldahl.Hashing.SpamSum;
using MyExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Logger;

namespace MyBackup
{
	public partial class DifferencialBackupForm : Form
	{
		public static void Do(BackupConfig config)
		{
			DifferencialBackupForm form = new(config);
			form.ShowDialog();
		}

		private readonly BackupConfig config;
		private readonly BackupManager backupManager;
		private LogListener Listener { get; }

		private DifferencialBackupForm(BackupConfig config)
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
			backupManager.BackupUpdatedAll();
			backupManager.LoggerNullable!.LogListeners -= Listener;
			Invoke(() =>
			{
				MessageBox.Show("完了しました");
			});
		}

		private void DifferencialBackupForm_Shown(object sender, EventArgs e)
		{
			Task.Run(StartBackup);
		}
	}
}
