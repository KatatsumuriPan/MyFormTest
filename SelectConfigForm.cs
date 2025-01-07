using MyExtensions;
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
	public partial class SelectConfigForm : Form
	{
		public static BackupConfig? Do()
		{
			SelectConfigForm form = new SelectConfigForm();
			form.ShowDialog();
			return form.result;
		}


		private BackupConfig? result = null;
		public SelectConfigForm()
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			foreach (var configName in Program.Configs.Keys)
			{
				listView1.Items.Add(configName);
			}
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count == 0)
				return;
			result = Program.Configs[listView1.SelectedItems[0].Text];
			Close();
		}
	}
}
