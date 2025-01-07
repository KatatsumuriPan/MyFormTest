namespace MyBackup
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

			(string name, BackupConfig config) = NewBackupForm.Do();

			//バックアップファイルの保存場所
			string configPath = "config\\" + name + ".config";
			config.WriteToFile(configPath);


			FirstBackupForm.Do(config);
			Program.Configs.Add(name, config);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			BackupConfig? config = SelectConfigForm.Do();
			if (config is not null)
				DifferencialBackupForm.Do(config);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			BackupConfig? config = SelectConfigForm.Do();
			if (config is not null)
				ExtractFileForm.Do(config);
		}
	}
}