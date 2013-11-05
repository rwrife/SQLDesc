using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

namespace SQLDesc
{
	public partial class SqlDesc : Form
	{		
		DataAccess da = null;
		System.Collections.Hashtable changedVals = new System.Collections.Hashtable();
		ExtendedProp currentExProp = null;

		public void DataAcess_DatabaseMessage(object sender, string message)
		{
			AppOutput.Text += message + "\n\r\n\r";
			while(AppOutput.Text.Length > 10000)
			{
				AppOutput.Text = AppOutput.Text.Substring(AppOutput.Text.IndexOf("\n\r") + 4);
			}
			AppOutput.SelectionStart = AppOutput.Text.Length;
			AppOutput.ScrollToCaret();
		}

		public SqlDesc()
		{
			InitializeComponent();
		}

		private void Connect_Click(object sender, EventArgs e)
		{
			da = new DataAccess();
			da.DatabaseMessage += new MessageEventHandler(this.DataAcess_DatabaseMessage);
			if (da.Connect(Server.Text, Database.Text, Username.Text, Password.Text))
			{
				ConnectPanel.Visible = false;
				SchemaPanel.Visible = true;
				RefreshSchemaTree();
			}
			else
				MessageBox.Show("Unable to connect to server or database, check the names and credentials and try again.");
		}

		private void RefreshSchemaTree()
		{
			SchemaTree.Nodes.Clear();
			SchemaTree.Nodes.Add("U", "Tables","Folder","Folder");
			SchemaTree.Nodes.Add("P", "Procedures", "Folder", "Folder");
			SchemaTree.Nodes.Add("V", "Views", "Folder", "Folder");
			SchemaTree.Nodes.Add("IF','FN','TF", "Functions", "Folder", "Folder");			
		}

		private void PopulateChildNode(TreeNode pNode, string Type, string Parent)
		{
			TreeNode objNode = pNode;

			if (Parent == "INDEX")
			{
				Parent = pNode.Parent.Name;
				Type = "PK";
			}

			if (Parent == "FK")
			{
				Parent = pNode.Parent.Name;
				Type = "F";
			}

			if (Parent == "TRIG")
			{
				Parent = pNode.Parent.Name;
				Type = "TR";
			}

			if (Parent == "COL")
			{
				PopulateColumnNodes(pNode, pNode.Parent.Text);
				return;
			}

			if (Type.ToLower() != "index" && Type.ToLower() != "col")
			{
				DataView dv = da.GetDataView("Select * From sysobjects Where xtype <> 'S' " +
					(Parent != "" ? " and parent_obj = " + Parent + " " : " and parent_obj = 0 ") +
					(Type != "" ? "and xtype In('" + Type + "') " : "") +
					"Order By xtype, name", "sysobjects");
				DataTable dt = dv.Table;
				if (dt != null && dt.Rows.Count > 0)
				{
					string imageKey = "";
					switch(Type.ToLower())
					{
						case "u":
							imageKey = "Table";
							break;
						case "p":
							imageKey = "Procedure";
							break;
						case "f":
							imageKey = "Constraint";
							break;
						case "tr":
							imageKey = "Trigger";
							break;
						case "pk":
							imageKey = "Index";
							break;
						case "v":
							imageKey = "View";
							break;
						case "if','fn','tf":
							imageKey = "Function";
							break;
						default:
							imageKey = "";
							break;
					}
				

					foreach (DataRow dr in dt.Rows)
					{
						TreeNode node;
						if(imageKey != "")
							 node =	objNode.Nodes.Add(dr["id"].ToString(), dr["name"].ToString(), imageKey, imageKey);
						else						
							node =	objNode.Nodes.Add(dr["id"].ToString(), dr["name"].ToString(), -1);

						if (Type.ToLower() == "u")
						{
							node.Nodes.Add("COL", "Columns", "Folder", "Folder");
							node.Nodes.Add("INDEX", "Indexes", "Folder", "Folder");
							node.Nodes.Add("TRIG", "Triggers", "Folder", "Folder");
							node.Nodes.Add("FK", "Foreign Keys", "Folder", "Folder");
						}
						
//							PopulateColumnNodes(colNode, dr["name"].ToString());
					}
				}
			}			
		}

		private void PopulateColumnNodes(TreeNode ColumnNode, String TableName)
		{
			DataView dv = da.GetDataView("Select * From INFORMATION_SCHEMA.Columns Where table_name = '" + TableName + "'", "tablecolumns");
			DataTable dt = dv.Table;
			if (dt != null && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					ColumnNode.Nodes.Add("",dr["column_name"].ToString(), "Column", "Column");
				}
			}
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			RefreshSchemaTree();
		}

		private void SchemaTree_DoubleClick(object sender, EventArgs e)
		{
			if (SchemaTree.SelectedNode.Nodes.Count == 0 )
			{
				if (SchemaTree.SelectedNode.Name == "") return;

				if (SchemaTree.SelectedNode.Parent == null)
				{
					SchemaTree.SelectedNode.Nodes.Clear();
					PopulateChildNode(SchemaTree.SelectedNode, SchemaTree.SelectedNode.Name, "");
				}
				else
				{
					SchemaTree.SelectedNode.Nodes.Clear();
					PopulateChildNode(SchemaTree.SelectedNode, "", SchemaTree.SelectedNode.Name);
				}
			}
		}

		private void Generate_Click(object sender, EventArgs e)
		{
			string outScript = GenerateScript(SchemaTree.SelectedNode, SchemaDesc.Text);

			if (outScript != "")
			{
				if (changedVals.ContainsKey(SchemaTree.SelectedNode))
				{
					string oldScript = ((ExtendedProp)changedVals[SchemaTree.SelectedNode]).updatescript;
					OutputScript.Text = OutputScript.Text.Replace(oldScript, outScript) + "\n\r";
					((ExtendedProp)changedVals[SchemaTree.SelectedNode]).updatescript = outScript;
					((ExtendedProp)changedVals[SchemaTree.SelectedNode]).value = SchemaDesc.Text;
				}
				else
				{
					currentExProp.value = SchemaDesc.Text;
					currentExProp.updatescript = outScript;
					changedVals.Add(SchemaTree.SelectedNode, currentExProp);
					OutputScript.Text += outScript + "\r\n\r\n";
				}
			}
		}

		private string GenerateScript(TreeNode sNode, String Description)
		{
			string outScript = "";

			//table
			if (sNode.Parent != null && sNode.Parent.Name.ToLower() == "u")
			{
				outScript = SetObjectDesc("TABLE", sNode.Text, Description);
			}
			//column
			if (sNode.Parent != null && sNode.Parent.Name.ToLower() == "col")
			{
				outScript = SetTableObjectDesc("COLUMN", sNode.Text, sNode.Parent.Parent.Text, Description);
			}
			//index
			if (sNode.Parent != null && sNode.Parent.Name.ToLower() == "index")
			{
				outScript = SetTableObjectDesc("INDEX", sNode.Text, sNode.Parent.Parent.Text, Description);
			}
			//fk
			if (sNode.Parent != null && sNode.Parent.Name.ToLower() == "fk")
			{
				outScript = SetTableObjectDesc("CONSTRAINT", sNode.Text, sNode.Parent.Parent.Text, Description);
			}
			//trigger
			if (sNode.Parent != null && sNode.Parent.Name.ToLower() == "trig")
			{
				outScript = SetTableObjectDesc("TRIGGER", sNode.Text, sNode.Parent.Parent.Text, Description);
			}
			//stored proc
			if (sNode.Parent != null && sNode.Parent.Name.ToLower() == "p")
			{
				outScript = SetObjectDesc("PROCEDURE", sNode.Text, Description);
			}
			//view
			if (sNode.Parent != null && sNode.Parent.Name.ToLower() == "v")
			{
				outScript = SetObjectDesc("VIEW", sNode.Text, Description);
			}
			//function
			if (sNode.Parent != null && sNode.Parent.Name.ToLower() == "if','fn','tf")
			{
				outScript = SetObjectDesc("FUNCTION", sNode.Text, Description);
			}

			return outScript;
		}

		private void panel2_Resize(object sender, EventArgs e)
		{
			SchemaDesc.Width = panel2.Width - 12;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			SchemaDesc.Width = panel2.Width - 12;
		}

		private string GetObjectDesc(string ObjType, string ObjName)
		{
			DataView dv = da.GetDataView("SELECT  * FROM  ::fn_listextendedproperty('MS_Description', 'user', 'dbo', '" + ObjType + "', '" + ObjName + "', null, null)", "tabledesc");
			if (dv != null && dv.Table != null && dv.Table.Rows.Count > 0)
			{
				return dv.Table.Rows[0]["value"].ToString();
			}
			else
				return null;
		}

		private string SetObjectDesc(string ObjType, string ObjName, string Description)
		{
			Description = Description.Replace("'", "''");
			return "EXECUTE sp_" + (currentExProp.isnew ? "add" : "update") + "extendedproperty N'MS_Description', N'" + Description + "', N'SCHEMA', N'dbo', N'" + ObjType + "', [" + ObjName + "], NULL, NULL";
		}

		private string SetTableObjectDesc(string ObjType, string ObjName, string TableName, string Description)
		{
			Description = Description.Replace("'", "''");
			string spcall = "EXECUTE sp_" + (currentExProp.isnew ? "add" : "update") + "extendedproperty N'MS_Description', '" + Description + "', N'user', N'dbo', N'table', N'" + TableName + "', N'" + ObjType + "', N'" + ObjName + "'";
			//da.RunProc(spcall);
			return spcall;
		}

		private string GetTableObjectDesc(string ObjType, string ObjName, string TableName)
		{
			DataView dv = da.GetDataView("SELECT  * FROM  ::fn_listextendedproperty('MS_Description', 'user', 'dbo', 'table', N'" + TableName + "', " + (ObjType != "" ? "N'" + ObjType + "'" : "NULL") + ", N'" + ObjName + "')", "coldesc");
			if (dv != null && dv.Table != null && dv.Table.Rows.Count > 0)
			{
				return dv.Table.Rows[0]["value"].ToString();
			}
			else
				return null;
		}

		private void SchemaTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			string schemaText = "";

			if (changedVals.ContainsKey(SchemaTree.SelectedNode))			
			{
				currentExProp = (ExtendedProp) changedVals[SchemaTree.SelectedNode];
				SchemaDesc.Enabled = true;
				Generate.Enabled = true;
				schemaText = ((ExtendedProp)changedVals[SchemaTree.SelectedNode]).value;
			}
			else
			{			
				//table selected
				if (SchemaTree.SelectedNode.Parent != null && SchemaTree.SelectedNode.Parent.Name.ToLower() == "u")
				{
					SchemaDesc.Enabled = true;
					Generate.Enabled = true;
					schemaText = GetObjectDesc("TABLE", SchemaTree.SelectedNode.Text);
					
					currentExProp = new ExtendedProp();
					currentExProp.name = "MS_Description";
					currentExProp.isnew = (schemaText == null);
				}
				//column selected
				else if (SchemaTree.SelectedNode.Parent != null && SchemaTree.SelectedNode.Parent.Name.ToLower() == "col")
				{
					SchemaDesc.Enabled = true;
					Generate.Enabled = true;
					schemaText = GetTableObjectDesc("COLUMN", SchemaTree.SelectedNode.Text, SchemaTree.SelectedNode.Parent.Parent.Text);

					currentExProp = new ExtendedProp();
					currentExProp.name = "MS_Description";
					currentExProp.isnew = (schemaText == null);
				}
				//index selected
				else if (SchemaTree.SelectedNode.Parent != null && SchemaTree.SelectedNode.Parent.Name.ToLower() == "index")
				{
					SchemaDesc.Enabled = true;
					Generate.Enabled = true;
					schemaText = GetTableObjectDesc("INDEX", SchemaTree.SelectedNode.Text, SchemaTree.SelectedNode.Parent.Parent.Text);

					currentExProp = new ExtendedProp();
					currentExProp.name = "MS_Description";
					currentExProp.isnew = (schemaText == null);
				}
				//trigger selected
				else if (SchemaTree.SelectedNode.Parent != null && SchemaTree.SelectedNode.Parent.Name.ToLower() == "trig")
				{
					SchemaDesc.Enabled = true;
					Generate.Enabled = true;
					schemaText = GetTableObjectDesc("TRIGGER", SchemaTree.SelectedNode.Text, SchemaTree.SelectedNode.Parent.Parent.Text);

					currentExProp = new ExtendedProp();
					currentExProp.name = "MS_Description";
					currentExProp.isnew = (schemaText == null);
				}
				//fk selected
				else if (SchemaTree.SelectedNode.Parent != null && SchemaTree.SelectedNode.Parent.Name.ToLower() == "fk")
				{
					SchemaDesc.Enabled = true;
					Generate.Enabled = true;
					schemaText = GetTableObjectDesc("CONSTRAINT", SchemaTree.SelectedNode.Text, SchemaTree.SelectedNode.Parent.Parent.Text);

					currentExProp = new ExtendedProp();
					currentExProp.name = "MS_Description";
					currentExProp.isnew = (schemaText == null);
				}
				//table object selected
				else if (SchemaTree.SelectedNode.Parent != null && SchemaTree.SelectedNode.Parent.Name.ToLower() == "obj")
				{
					SchemaDesc.Enabled = true;
					Generate.Enabled = true;
					schemaText = GetTableObjectDesc("", SchemaTree.SelectedNode.Text, SchemaTree.SelectedNode.Parent.Parent.Text);

					currentExProp = new ExtendedProp();
					currentExProp.name = "MS_Description";
					currentExProp.isnew = (schemaText == null);
				}
				//sp selected
				else if (SchemaTree.SelectedNode.Parent != null && SchemaTree.SelectedNode.Parent.Name.ToLower() == "p")
				{
					SchemaDesc.Enabled = true;
					Generate.Enabled = true;
					schemaText = GetObjectDesc("PROCEDURE", SchemaTree.SelectedNode.Text);

					currentExProp = new ExtendedProp();
					currentExProp.name = "MS_Description";
					currentExProp.isnew = (schemaText == null);
				}
				//func selected
				else if (SchemaTree.SelectedNode.Parent != null && SchemaTree.SelectedNode.Parent.Name.ToLower() == "if','fn','tf")
				{
					SchemaDesc.Enabled = true;
					Generate.Enabled = true;
					schemaText = GetObjectDesc("FUNCTION", SchemaTree.SelectedNode.Text);

					currentExProp = new ExtendedProp();
					currentExProp.name = "MS_Description";
					currentExProp.isnew = (schemaText == null);
				}
				//view selected
				else if (SchemaTree.SelectedNode.Parent != null && SchemaTree.SelectedNode.Parent.Name.ToLower() == "v")
				{
					SchemaDesc.Enabled = true;
					Generate.Enabled = true;
					schemaText = GetObjectDesc("VIEW", SchemaTree.SelectedNode.Text);

					currentExProp = new ExtendedProp();
					currentExProp.name = "MS_Description";
					currentExProp.isnew = (schemaText == null);
				}
				else
				{
					schemaText = "";
					Generate.Enabled = false;
					SchemaDesc.Enabled = false;
					currentExProp = null;
				}
			}

			SchemaDesc.Text = (schemaText == null ? "" : schemaText);
		}

		private void UseSQLAuth_CheckedChanged(object sender, EventArgs e)
		{
			if (UseSQLAuth.Checked)
			{
				Username.Enabled = true;
				Password.Enabled = true;
				PasswordLabel.Enabled = true;
				UsernameLabel.Enabled = true;
			}
			else
			{
				Password.Text = "";
				Username.Text = "";
				Username.Enabled = false;
				Password.Enabled = false;
				PasswordLabel.Enabled = false;
				UsernameLabel.Enabled = false;
			}
		}

		private void CopyScript_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(OutputScript.Text);
		}

		private void SaveScript_Click(object sender, EventArgs e)
		{
			saveFileDialog1.Filter = "SQL Script (*.sql)|*.sql|All Files|";
			saveFileDialog1.ShowDialog();
		}

		private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			System.IO.TextWriter tw = new System.IO.StreamWriter(saveFileDialog1.FileName);
			tw.Write(OutputScript.Text);
			tw.Close();
		}

		private void ExecuteChanges_Click(object sender, EventArgs e)
		{
			foreach (ExtendedProp exp in changedVals.Values)
			{
				da.RunProc(exp.updatescript);
				exp.isnew = false;
			}
		}
	}
}
