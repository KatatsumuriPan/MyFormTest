using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MyBackup
{
	public partial class NewBackupForm : Form
	{
		public static (string name, BackupConfig config) Do()
		{
			NewBackupForm form = new();
			form.ShowDialog();
			return form.result;
		}

		private NewBackupForm()
		{
			InitializeComponent();
		}

		private (string name, BackupConfig config) result;

		private void button1_Click(object sender, EventArgs e)
		{
			if (Program.Configs.ContainsKey(tb_name.Text))
			{
				MessageBox.Show("既に存在する名前です");
				return;
			}
			BackupConfig config = new(tb_src.Text, tb_dst.Text);
			result = (tb_name.Text, config);
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			tb_src.Text = PickFolder() ?? tb_src.Text;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			tb_dst.Text = PickFolder() ?? tb_dst.Text;
		}


		private static string? PickFolder()
		{
			using (CommonOpenFileDialog cofd = new())
			{
				cofd.IsFolderPicker = true;

				if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
					return cofd.FileName;
				else
					return null;
			}
		}

	}
}
