using System;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;  

namespace SQLDesc
{
	public delegate void MessageEventHandler(object sender, string message);

	class DataAccess
	{
		private string connString = "";
		public event MessageEventHandler DatabaseMessage;

		public bool Connect(string Server, string Database, string Username, string Password)
		{
			try
			{
				SqlConnection conn;
				if(Username != "" && Password != "")
					connString = "Password=" + Password + ";User ID=" + Username + ";data source=" + Server + ";initial catalog=" + Database + ";integrated security=SSPI;persist security info=False";
				else
					connString = "data source=" + Server + ";initial catalog=" + Database + ";integrated security=SSPI;persist security info=False";
				conn = new SqlConnection(connString);
				conn.Open();
				conn.Close();
				if (DatabaseMessage != null)
					DatabaseMessage(this, "Connected to " + Database + " on " + Server + ".");
				return true;
			}
			catch
			{
				return false;
			}
		}

        public DataSet GetDataSet(string[] ProcName , string[] DataTable)
        {
			DataSet dstEorder ;
			SqlConnection conn;
			SqlDataAdapter dadEorder; 
			try
			{
				int intCnt = ProcName.GetUpperBound(0);
				dstEorder = new DataSet();
				conn = new SqlConnection(connString);
				if(intCnt == 0)
				{
					dadEorder = new SqlDataAdapter(ProcName[0], conn);
					dadEorder.Fill(dstEorder, DataTable[0]);
				}
				else
				{
					conn.Open();
					dadEorder = new SqlDataAdapter(ProcName[0], conn);                                         
					dadEorder.Fill(dstEorder, DataTable[0]);
					for(int i=1 ;i< (intCnt +1) ;i++)
					{
					dadEorder.SelectCommand = new SqlCommand(ProcName[i], conn);
					dadEorder.Fill(dstEorder, DataTable[i]);
					}                                  
					conn.Close();
					}
					if (DatabaseMessage != null)
						DatabaseMessage(this, "Executed '" + ProcName[0] + "'.");
					return dstEorder;
				}
				catch ( Exception objError)
				{
					if (DatabaseMessage != null)
						DatabaseMessage(this, "Unable to execute '" + ProcName[0] + "'.");
					WriteToEventLog(objError);
					throw;                                       
				}
            }

        public void RunProc(string ProcName)
        {
            string strCommandText= ProcName;
            SqlConnection objConnect =new SqlConnection(connString);
            SqlCommand objCommand =new SqlCommand(strCommandText, objConnect);
            try
            {
                objConnect.Open();
                objCommand.ExecuteNonQuery();
				if (DatabaseMessage != null)
					DatabaseMessage(this, "Executed '" + ProcName + "'.");
            }
            catch(Exception objError)
            {
				if (DatabaseMessage != null)
					DatabaseMessage(this, "Unable to execute '" + ProcName + "'.");
				WriteToEventLog(objError);
				throw;
            }
            finally
            {
				objConnect.Close();
            }
        }  

        public SqlDataReader GetDataReader(string ProcName) 
        {
            string strCommandText= ProcName;
            SqlDataReader objDataReader;
            SqlConnection objConnect =new SqlConnection(connString);
            SqlCommand objCommand = new SqlCommand(strCommandText, objConnect);
            try
            {
                objConnect.Open();
                objDataReader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if (DatabaseMessage != null)
					DatabaseMessage(this, "Executed '" + ProcName + "'.");
            }
            catch( Exception objError)
            {
				if (DatabaseMessage != null)
					DatabaseMessage(this, "Unable to execute '" + ProcName + "'.");
				WriteToEventLog(objError);
                throw;
            }
            return objDataReader;
        } 

        public DataView GetDataView(string ProcName,string DataSetTable)
        {          
            string strCommandText= ProcName;
            SqlConnection objConnect = new SqlConnection(connString);
            SqlCommand objCommand= new  SqlCommand(strCommandText, objConnect);
            SqlDataAdapter objDataAdapter = new SqlDataAdapter();
            try
            {
				objConnect.Open();
				objDataAdapter.SelectCommand = objCommand;
            }
            catch(Exception objError)
            {
				if (DatabaseMessage != null)
					DatabaseMessage(this, "Unable to execute '" + ProcName + "'.");
				WriteToEventLog(objError);
				throw;
            }
            DataSet objDataSet;
            objDataSet = new DataSet(DataSetTable);
            objDataAdapter.Fill(objDataSet);
            DataView objDataView ;
            objDataView = new DataView(objDataSet.Tables[0]);
            objConnect.Close();
			if (DatabaseMessage != null)
				DatabaseMessage(this, "Executed '" + ProcName + "'.");
            return objDataView;
        } 

        private void WriteToEventLog( Exception objError)
        {
			System.Diagnostics.EventLog objEventLog = new System.Diagnostics.EventLog();
			objEventLog.Source = "Your Application Name";
			objEventLog.WriteEntry(objError.Message.ToString());
			if (DatabaseMessage != null)
				DatabaseMessage(this, objError.Message);
        }
	}
}
