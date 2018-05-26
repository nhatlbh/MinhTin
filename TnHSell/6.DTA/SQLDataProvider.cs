using System;
using System.Data;
using System.Data.SqlClient;

namespace DTA
{
    public class DataProvider
    {
        static string getConnnectionString()
        {
            return @"Server=.\n;Database=TnHSell;User Id=sa;Password=n123;";
            //return @"Server=103.252.0.81\sqlexpress;Database=TnHSell;User Id=minhtin;Password=123;";
        }

        private static SqlConnection connWithTrans;
        public static SqlTransaction beginTrans()
        {
            connWithTrans = new SqlConnection(getConnnectionString());
            if (connWithTrans.State != ConnectionState.Open)
                connWithTrans.Open();
            return connWithTrans.BeginTransaction();
        }
        public static void CommitTrans(SqlTransaction trans)
        {
            trans.Commit();
            closeConn(connWithTrans);
        }
        public static void RollbackTrans(SqlTransaction trans)
        {
            if (trans.Connection != null)
            {
                trans.Rollback();
                closeConn(connWithTrans);
            }
        }
        static void closeConn(SqlConnection conn)
        {
            conn.Close();
            conn.Dispose();
        }
        public static DataTable ExecuteQuery(string query)
        {
            DataSet result = new DataSet();
            SqlDataAdapter adapSQL = new SqlDataAdapter();
            try
            {
                using (SqlConnection connWithoutTrans = new SqlConnection(getConnnectionString()))
                {
                    adapSQL = new SqlDataAdapter(query, connWithoutTrans);
                    adapSQL.Fill(result);
                    closeConn(connWithoutTrans);
                    if (result != null && result.Tables.Count > 0)
                    {
                        return result.Tables[0];
                    }
                    return null;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                adapSQL.Dispose();
            }
        }
        public static DataTable ExecuteQueryWithTransaction(string query, SqlTransaction tran)
        {
            DataSet result = new DataSet();
            SqlDataAdapter adapSQL = new SqlDataAdapter();
            try
            {
                adapSQL = new SqlDataAdapter(query, connWithTrans);
                adapSQL.SelectCommand.Transaction = tran;
                adapSQL.Fill(result);
                if (result != null && result.Tables.Count > 0)
                {
                    return result.Tables[0];
                }
                return null;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                adapSQL.Dispose();
            }

        }
        public static int ExecuteNonQuery(string query)
        {
            SqlCommand cmdSQL = new SqlCommand();
            try
            {
                int result = 0;
                using (SqlConnection connWithoutTrans = new SqlConnection(getConnnectionString()))
                {
                    connWithoutTrans.Open();
                    cmdSQL = new SqlCommand(query, connWithoutTrans);
                    result = cmdSQL.ExecuteNonQuery();
                    closeConn(connWithoutTrans);
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cmdSQL.Dispose();
            }
        }
        public static int ExecuteNonQueryWithTransaction(string query, SqlTransaction tran)
        {
            SqlCommand cmdSQL = new SqlCommand();
            int result;
            try
            {
                cmdSQL = new SqlCommand(query, connWithTrans);
                cmdSQL.Transaction = tran;
                result = cmdSQL.ExecuteNonQuery();
                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cmdSQL.Dispose();
            }
        }
    }
}
