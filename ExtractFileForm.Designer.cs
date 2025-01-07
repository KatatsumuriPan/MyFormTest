namespace MyBackup
{
	partial class ExtractFileForm
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
			splitContainer1 = new SplitContainer();
			listView1 = new ListView();
			columnHeader1 = new ColumnHeader();
			btn_ok = new Button();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.FixedPanel = FixedPanel.Panel2;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(listView1);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(btn_ok);
			splitContainer1.Size = new Size(528, 778);
			splitContainer1.SplitterDistance = 663;
			splitContainer1.TabIndex = 0;
			// 
			// listView1
			// 
			listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
			listView1.Dock = DockStyle.Fill;
			listView1.Location = new Point(0, 0);
			listView1.MultiSelect = false;
			listView1.Name = "listView1";
			listView1.Size = new Size(528, 663);
			listView1.TabIndex = 0;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = View.Details;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "ファイル";
			columnHeader1.Width = 524;
			// 
			// btn_ok
			// 
			btn_ok.Location = new Point(392, 57);
			btn_ok.Name = "btn_ok";
			btn_ok.Size = new Size(94, 29);
			btn_ok.TabIndex = 0;
			btn_ok.Text = "抽出";
			btn_ok.UseVisualStyleBackColor = true;
			btn_ok.Click += btn_ok_Click;
			// 
			// ExtractFileForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(528, 778);
			Controls.Add(splitContainer1);
			Name = "ExtractFileForm";
			Text = "ExtractFileForm";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private Button btn_ok;
		private ListView listView1;
		private ColumnHeader columnHeader1;
	}
}