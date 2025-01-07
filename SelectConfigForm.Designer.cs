namespace MyBackup
{
	partial class SelectConfigForm
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
			btn_cancel = new Button();
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
			splitContainer1.IsSplitterFixed = true;
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
			splitContainer1.Panel2.Controls.Add(btn_cancel);
			splitContainer1.Size = new Size(618, 691);
			splitContainer1.SplitterDistance = 575;
			splitContainer1.TabIndex = 0;
			// 
			// listView1
			// 
			listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
			listView1.Dock = DockStyle.Fill;
			listView1.Location = new Point(0, 0);
			listView1.MultiSelect = false;
			listView1.Name = "listView1";
			listView1.Size = new Size(618, 575);
			listView1.TabIndex = 0;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = View.Details;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "ファイル名";
			columnHeader1.Width = 614;
			// 
			// btn_ok
			// 
			btn_ok.Location = new Point(374, 72);
			btn_ok.Name = "btn_ok";
			btn_ok.Size = new Size(94, 29);
			btn_ok.TabIndex = 1;
			btn_ok.Text = "OK";
			btn_ok.UseVisualStyleBackColor = true;
			btn_ok.Click += btn_ok_Click;
			// 
			// btn_cancel
			// 
			btn_cancel.Location = new Point(488, 71);
			btn_cancel.Name = "btn_cancel";
			btn_cancel.Size = new Size(94, 29);
			btn_cancel.TabIndex = 0;
			btn_cancel.Text = "キャンセル";
			btn_cancel.UseVisualStyleBackColor = true;
			// 
			// SelectConfigForm
			// 
			AcceptButton = btn_ok;
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btn_cancel;
			ClientSize = new Size(618, 691);
			Controls.Add(splitContainer1);
			Name = "SelectConfigForm";
			Text = "SelectConfigForm";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private Button btn_cancel;
		private ListView listView1;
		private Button btn_ok;
		private ColumnHeader columnHeader1;
	}
}