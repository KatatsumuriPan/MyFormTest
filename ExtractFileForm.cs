using Microsoft.WindowsAPICodePack.Dialogs;
using MyUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBackup
{
	public partial class ExtractFileForm : Form
	{
		public static void Do(BackupConfig config)
		{
			ExtractFileForm form = new(config);
			form.ShowDialog();
		}

		private readonly BackupConfig config;
		private readonly BackupManager backupManager;

		public ExtractFileForm(BackupConfig config)
		{
			this.config = config;
			backupManager = new(config);
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			foreach (BackupFileInfo fileInfo in backupManager.GetAllInfos())
			{
				listView1.Items.Add(fileInfo.FileRelPath);
			}
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count == 0)
				return;
			string filePath = listView1.SelectedItems[0].Text;

			using CommonOpenFileDialog cofd = new();
			if (cofd.ShowDialog() != CommonFileDialogResult.Ok)
				return;
			File.WriteAllBytes(cofd.FileName, backupManager.Extract(filePath));
			MessageBox.Show(cofd.FileName);
		}
	}
}
