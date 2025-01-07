namespace MyBackup
{
	partial class FirstBackupForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			richTextBox1 = new RichTextBox();
			SuspendLayout();
			// 
			// richTextBox1
			// 
			richTextBox1.Location = new Point(311, 12);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.ReadOnly = true;
			richTextBox1.Size = new Size(817, 515);
			richTextBox1.TabIndex = 0;
			richTextBox1.Text = "";
			richTextBox1.WordWrap = false;
			// 
			// FirstBackupForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1140, 534);
			Controls.Add(richTextBox1);
			Name = "FirstBackupForm";
			Text = "FirstBackupForm";
			Shown += FirstBackupForm_Shown;
			ResumeLayout(false);
		}

		#endregion

		private RichTextBox richTextBox1;
	}
}