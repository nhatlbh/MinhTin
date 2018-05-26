using System;
using System.Data;
using System.Data.SqlClient;

namespace DTA
{
    public class DataProvider
    {
        static SqlConnection conn;
        static SqlTransaction tran;
        int tranCounter = 0;
        static string getConnnectionString()
        {
            return @"Server=n\n;Database=ADMIN;User Id=sa;Password=n123;";
        }
        static void openConnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection();
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.ConnectionString = getConnnectionString();
            conn.Open();
        }
        static void closeConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        public static SqlTransaction Tran
        {
            get { return tran; }
        }
        public void CommitTran()
        {
            tran.Commit();
        }
        public void RollbackTran()
        {
            tran.Rollback();
        }
        public static DataTable ExecuteQuery(string query)
        {
            DataSet result = new DataSet();
            SqlDataAdapter adapSQL = new SqlDataAdapter();
            try
            {

                openConnection();
                adapSQL = new SqlDataAdapter(query, conn);
                adapSQL.Fill(result);
                if (result != null && result.Tables.Count > 0)
                {
                    return result.Tables[0];
                }
                return null;
            }
            catch (SqlException e)
            {
                return null;
                throw e;
            }
            finally
            {
                adapSQL.Dispose();
                closeConnection();
            }
        }
        public static DataTable ExecuteQueryWithTransaction(string query, string transactionName)
        {
            DataSet result = new DataSet();
            SqlDataAdapter adapSQL = new SqlDataAdapter();
            try
            {
                openConnection();
                tran = conn.BeginTransaction(transactionName);
                adapSQL.SelectCommand.Transaction = tran;
                adapSQL = new SqlDataAdapter(query, conn);
                adapSQL.Fill(result);
                if (result != null && result.Tables.Count > 0)
                {
                    return result.Tables[0];
                }
                return null;
            }
            catch (SqlException e)
            {
                return null;
                throw e;
            }
            finally
            {
                adapSQL.Dispose();
                closeConnection();
            }

        }
        public static int ExecuteNonQuery(string query)
        {
            SqlCommand cmdSQL = new SqlCommand();
            try
            {
                openConnection();
                cmdSQL = new SqlCommand(query, conn);
                return cmdSQL.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                closeConnection();
                cmdSQL.Dispose();
            }
        }
        public static int ExecuteNonQueryWithTransaction(string query,string transactionName)
        {
            SqlCommand cmdSQL = new SqlCommand();
            try
            {
                openConnection();
                tran = conn.BeginTransaction(transactionName);
                cmdSQL = new SqlCommand(query, conn);
                cmdSQL.Transaction = tran;
                return cmdSQL.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                closeConnection();
                cmdSQL.Dispose();
            }
        }
    }
}
