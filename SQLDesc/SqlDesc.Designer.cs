namespace SQLDesc
{
	partial class SqlDesc
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlDesc));
			this.Server = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Database = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.Connect = new System.Windows.Forms.Button();
			this.ConnectPanel = new System.Windows.Forms.Panel();
			this.Password = new System.Windows.Forms.TextBox();
			this.PasswordLabel = new System.Windows.Forms.Label();
			this.Username = new System.Windows.Forms.TextBox();
			this.UsernameLabel = new System.Windows.Forms.Label();
			this.UseSQLAuth = new System.Windows.Forms.CheckBox();
			this.SchemaPanel = new System.Windows.Forms.SplitContainer();
			this.SchemaTree = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.OutputScript = new System.Windows.Forms.TextBox();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.SaveScript = new System.Windows.Forms.ToolStripButton();
			this.CopyScript = new System.Windows.Forms.ToolStripButton();
			this.ExecuteChanges = new System.Windows.Forms.ToolStripButton();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.AppOutput = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.Generate = new System.Windows.Forms.Button();
			this.SchemaDesc = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.panel1.SuspendLayout();
			this.ConnectPanel.SuspendLayout();
			this.SchemaPanel.Panel1.SuspendLayout();
			this.SchemaPanel.Panel2.SuspendLayout();
			this.SchemaPanel.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// Server
			// 
			this.Server.Location = new System.Drawing.Point(12, 20);
			this.Server.Name = "Server";
			this.Server.Size = new System.Drawing.Size(100, 20);
			this.Server.TabIndex = 0;
			this.Server.Text = "(local)";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Server";
			// 
			// Database
			// 
			this.Database.Location = new System.Drawing.Point(12, 59);
			this.Database.Name = "Database";
			this.Database.Size = new System.Drawing.Size(100, 20);
			this.Database.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Database";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.Connect);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 363);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(10);
			this.panel1.Size = new System.Drawing.Size(875, 50);
			this.panel1.TabIndex = 5;
			// 
			// Connect
			// 
			this.Connect.Dock = System.Windows.Forms.DockStyle.Right;
			this.Connect.Location = new System.Drawing.Point(790, 10);
			this.Connect.Name = "Connect";
			this.Connect.Size = new System.Drawing.Size(75, 30);
			this.Connect.TabIndex = 4;
			this.Connect.Text = "Connect";
			this.Connect.UseVisualStyleBackColor = true;
			this.Connect.Click += new System.EventHandler(this.Connect_Click);
			// 
			// ConnectPanel
			// 
			this.ConnectPanel.Controls.Add(this.panel1);
			this.ConnectPanel.Controls.Add(this.label2);
			this.ConnectPanel.Controls.Add(this.Database);
			this.ConnectPanel.Controls.Add(this.label1);
			this.ConnectPanel.Controls.Add(this.Server);
			this.ConnectPanel.Controls.Add(this.Password);
			this.ConnectPanel.Controls.Add(this.PasswordLabel);
			this.ConnectPanel.Controls.Add(this.Username);
			this.ConnectPanel.Controls.Add(this.UsernameLabel);
			this.ConnectPanel.Controls.Add(this.UseSQLAuth);
			this.ConnectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ConnectPanel.Location = new System.Drawing.Point(0, 0);
			this.ConnectPanel.Name = "ConnectPanel";
			this.ConnectPanel.Size = new System.Drawing.Size(875, 413);
			this.ConnectPanel.TabIndex = 0;
			// 
			// Password
			// 
			this.Password.Enabled = false;
			this.Password.Location = new System.Drawing.Point(117, 126);
			this.Password.Name = "Password";
			this.Password.Size = new System.Drawing.Size(100, 20);
			this.Password.TabIndex = 15;
			this.Password.UseSystemPasswordChar = true;
			// 
			// PasswordLabel
			// 
			this.PasswordLabel.AutoSize = true;
			this.PasswordLabel.Enabled = false;
			this.PasswordLabel.Location = new System.Drawing.Point(115, 110);
			this.PasswordLabel.Name = "PasswordLabel";
			this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
			this.PasswordLabel.TabIndex = 14;
			this.PasswordLabel.Text = "Password";
			// 
			// Username
			// 
			this.Username.Enabled = false;
			this.Username.Location = new System.Drawing.Point(11, 126);
			this.Username.Name = "Username";
			this.Username.Size = new System.Drawing.Size(100, 20);
			this.Username.TabIndex = 13;
			// 
			// UsernameLabel
			// 
			this.UsernameLabel.AutoSize = true;
			this.UsernameLabel.Enabled = false;
			this.UsernameLabel.Location = new System.Drawing.Point(9, 110);
			this.UsernameLabel.Name = "UsernameLabel";
			this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
			this.UsernameLabel.TabIndex = 12;
			this.UsernameLabel.Text = "Username";
			// 
			// UseSQLAuth
			// 
			this.UseSQLAuth.AutoSize = true;
			this.UseSQLAuth.Location = new System.Drawing.Point(12, 85);
			this.UseSQLAuth.Name = "UseSQLAuth";
			this.UseSQLAuth.Size = new System.Drawing.Size(174, 17);
			this.UseSQLAuth.TabIndex = 11;
			this.UseSQLAuth.Text = "Use SQL Server Authentication";
			this.UseSQLAuth.UseVisualStyleBackColor = true;
			this.UseSQLAuth.CheckedChanged += new System.EventHandler(this.UseSQLAuth_CheckedChanged);
			// 
			// SchemaPanel
			// 
			this.SchemaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SchemaPanel.Location = new System.Drawing.Point(0, 0);
			this.SchemaPanel.Name = "SchemaPanel";
			// 
			// SchemaPanel.Panel1
			// 
			this.SchemaPanel.Panel1.Controls.Add(this.SchemaTree);
			this.SchemaPanel.Panel1.Controls.Add(this.toolStrip1);
			// 
			// SchemaPanel.Panel2
			// 
			this.SchemaPanel.Panel2.Controls.Add(this.tabControl1);
			this.SchemaPanel.Panel2.Controls.Add(this.panel2);
			this.SchemaPanel.Size = new System.Drawing.Size(875, 413);
			this.SchemaPanel.SplitterDistance = 291;
			this.SchemaPanel.TabIndex = 1;
			this.SchemaPanel.Visible = false;
			// 
			// SchemaTree
			// 
			this.SchemaTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SchemaTree.ImageIndex = 0;
			this.SchemaTree.ImageList = this.imageList1;
			this.SchemaTree.Location = new System.Drawing.Point(0, 25);
			this.SchemaTree.Name = "SchemaTree";
			this.SchemaTree.SelectedImageIndex = 0;
			this.SchemaTree.Size = new System.Drawing.Size(291, 388);
			this.SchemaTree.TabIndex = 1;
			this.SchemaTree.DoubleClick += new System.EventHandler(this.SchemaTree_DoubleClick);
			this.SchemaTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SchemaTree_AfterSelect);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "data.png");
			this.imageList1.Images.SetKeyName(1, "Folder");
			this.imageList1.Images.SetKeyName(2, "Table");
			this.imageList1.Images.SetKeyName(3, "View");
			this.imageList1.Images.SetKeyName(4, "Index");
			this.imageList1.Images.SetKeyName(5, "Function");
			this.imageList1.Images.SetKeyName(6, "Procedure");
			this.imageList1.Images.SetKeyName(7, "Column");
			this.imageList1.Images.SetKeyName(8, "Constraint");
			this.imageList1.Images.SetKeyName(9, "Trigger");
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(291, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "Refresh View";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 79);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(580, 334);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.OutputScript);
			this.tabPage1.Controls.Add(this.toolStrip2);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(572, 308);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "SQL Script";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// OutputScript
			// 
			this.OutputScript.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OutputScript.Location = new System.Drawing.Point(3, 28);
			this.OutputScript.Multiline = true;
			this.OutputScript.Name = "OutputScript";
			this.OutputScript.ReadOnly = true;
			this.OutputScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.OutputScript.Size = new System.Drawing.Size(566, 277);
			this.OutputScript.TabIndex = 6;
			this.OutputScript.WordWrap = false;
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveScript,
            this.CopyScript,
            this.ExecuteChanges});
			this.toolStrip2.Location = new System.Drawing.Point(3, 3);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(566, 25);
			this.toolStrip2.TabIndex = 0;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// SaveScript
			// 
			this.SaveScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.SaveScript.Image = ((System.Drawing.Image)(resources.GetObject("SaveScript.Image")));
			this.SaveScript.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SaveScript.Name = "SaveScript";
			this.SaveScript.Size = new System.Drawing.Size(23, 22);
			this.SaveScript.Text = "Save To File...";
			this.SaveScript.Click += new System.EventHandler(this.SaveScript_Click);
			// 
			// CopyScript
			// 
			this.CopyScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.CopyScript.Image = ((System.Drawing.Image)(resources.GetObject("CopyScript.Image")));
			this.CopyScript.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.CopyScript.Name = "CopyScript";
			this.CopyScript.Size = new System.Drawing.Size(23, 22);
			this.CopyScript.Text = "Copy To Clipboard";
			this.CopyScript.Click += new System.EventHandler(this.CopyScript_Click);
			// 
			// ExecuteChanges
			// 
			this.ExecuteChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ExecuteChanges.Image = ((System.Drawing.Image)(resources.GetObject("ExecuteChanges.Image")));
			this.ExecuteChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ExecuteChanges.Name = "ExecuteChanges";
			this.ExecuteChanges.Size = new System.Drawing.Size(23, 22);
			this.ExecuteChanges.Text = "Run Changes";
			this.ExecuteChanges.Click += new System.EventHandler(this.ExecuteChanges_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.AppOutput);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(572, 308);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Output";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// AppOutput
			// 
			this.AppOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AppOutput.Location = new System.Drawing.Point(3, 3);
			this.AppOutput.Multiline = true;
			this.AppOutput.Name = "AppOutput";
			this.AppOutput.ReadOnly = true;
			this.AppOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.AppOutput.Size = new System.Drawing.Size(566, 302);
			this.AppOutput.TabIndex = 7;
			this.AppOutput.WordWrap = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.Generate);
			this.panel2.Controls.Add(this.SchemaDesc);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(580, 79);
			this.panel2.TabIndex = 3;
			this.panel2.Resize += new System.EventHandler(this.panel2_Resize);
			// 
			// Generate
			// 
			this.Generate.Enabled = false;
			this.Generate.Location = new System.Drawing.Point(6, 47);
			this.Generate.Name = "Generate";
			this.Generate.Size = new System.Drawing.Size(75, 23);
			this.Generate.TabIndex = 5;
			this.Generate.Text = "Gen Script";
			this.Generate.UseVisualStyleBackColor = true;
			this.Generate.Click += new System.EventHandler(this.Generate_Click);
			// 
			// SchemaDesc
			// 
			this.SchemaDesc.Enabled = false;
			this.SchemaDesc.Location = new System.Drawing.Point(6, 21);
			this.SchemaDesc.Name = "SchemaDesc";
			this.SchemaDesc.Size = new System.Drawing.Size(405, 20);
			this.SchemaDesc.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Description";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "sql";
			this.saveFileDialog1.Title = "Save SQL Script";
			this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
			// 
			// SqlDesc
			// 
			this.AcceptButton = this.Generate;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(875, 413);
			this.Controls.Add(this.SchemaPanel);
			this.Controls.Add(this.ConnectPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SqlDesc";
			this.Text = "SQL Desc";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.ConnectPanel.ResumeLayout(false);
			this.ConnectPanel.PerformLayout();
			this.SchemaPanel.Panel1.ResumeLayout(false);
			this.SchemaPanel.Panel1.PerformLayout();
			this.SchemaPanel.Panel2.ResumeLayout(false);
			this.SchemaPanel.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox Server;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox Database;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button Connect;
		private System.Windows.Forms.Panel ConnectPanel;
		private System.Windows.Forms.SplitContainer SchemaPanel;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.TreeView SchemaTree;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button Generate;
		private System.Windows.Forms.TextBox SchemaDesc;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox Password;
		private System.Windows.Forms.Label PasswordLabel;
		private System.Windows.Forms.TextBox Username;
		private System.Windows.Forms.Label UsernameLabel;
		private System.Windows.Forms.CheckBox UseSQLAuth;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox OutputScript;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton SaveScript;
		private System.Windows.Forms.ToolStripButton CopyScript;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolStripButton ExecuteChanges;
		private System.Windows.Forms.TextBox AppOutput;

	}
}

