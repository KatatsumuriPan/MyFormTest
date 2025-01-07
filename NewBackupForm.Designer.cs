namespace MyBackup
{
	partial class NewBackupForm
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
			label1 = new Label();
			tb_name = new TextBox();
			label2 = new Label();
			tb_src = new TextBox();
			label3 = new Label();
			tb_dst = new TextBox();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(51, 36);
			label1.Name = "label1";
			label1.Size = new Size(90, 20);
			label1.TabIndex = 0;
			label1.Text = "バックアップ名";
			// 
			// tb_name
			// 
			tb_name.Location = new Point(51, 59);
			tb_name.Name = "tb_name";
			tb_name.Size = new Size(469, 27);
			tb_name.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(51, 104);
			label2.Name = "label2";
			label2.Size = new Size(90, 20);
			label2.TabIndex = 0;
			label2.Text = "バックアップ元";
			// 
			// tb_src
			// 
			tb_src.Location = new Point(51, 127);
			tb_src.Name = "tb_src";
			tb_src.Size = new Size(469, 27);
			tb_src.TabIndex = 1;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(51, 178);
			label3.Name = "label3";
			label3.Size = new Size(90, 20);
			label3.TabIndex = 0;
			label3.Text = "バックアップ先";
			// 
			// tb_dst
			// 
			tb_dst.Location = new Point(51, 201);
			tb_dst.Name = "tb_dst";
			tb_dst.Size = new Size(469, 27);
			tb_dst.TabIndex = 1;
			// 
			// button1
			// 
			button1.Location = new Point(206, 234);
			button1.Name = "button1";
			button1.Size = new Size(176, 50);
			button1.TabIndex = 2;
			button1.Text = "バックアップ開始";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Location = new Point(526, 125);
			button2.Name = "button2";
			button2.Size = new Size(77, 29);
			button2.TabIndex = 3;
			button2.Text = "参照";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// button3
			// 
			button3.Location = new Point(526, 199);
			button3.Name = "button3";
			button3.Size = new Size(77, 29);
			button3.TabIndex = 3;
			button3.Text = "参照";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// NewBackupForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(626, 296);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(tb_dst);
			Controls.Add(label3);
			Controls.Add(tb_src);
			Controls.Add(label2);
			Controls.Add(tb_name);
			Controls.Add(label1);
			Name = "NewBackupForm";
			Text = "NewBackupForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		public TextBox tb_name;
		private Label label2;
		public TextBox tb_src;
		private Label label3;
		public TextBox tb_dst;
		private Button button1;
		private Button button2;
		private Button button3;
	}
}