   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class GuarReturnDetailDT
    {
        string TableName = "Guar_Return_Detail";
        /// <summary>
        /// Liệt kê tất cả đối tượng trong database
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(string order="")
        {
            string query = @"SELECT * FROM " + TableName;
            if(order != "")
            {
                query += " ORDER BY " + order;
            }
            DataTable dt = DataProvider.ExecuteQuery( query);
            return dt;
        }
        /// <summary>
        /// Liệt kê dữ liệu hiển thị lên lưới.
        /// </summary>
        /// <param name="cond">Điều kiện để lọc dữ liệu</param>
        /// <returns></returns>
        public DataTable GetGridData(string cond, string order="", SqlTransaction  tran = null )
        {
            string query = @"SELECT * FROM (
                            SELECT 
                            Guar_Return_Detail.ID,Guar_Return_Detail.GuarReturnID,Guar_Return_Detail.ProductID,Guar_Return_Detail.Quantity,Guar_Return_Detail.OrderNum,Guar_Return_Detail.Deleted,convert(varchar(10),Guar_Return_Detail.DeletedOn,103) as DeletedOn 
                              , Guar_Return.Code as Guar_Return_Name
                            FROM " + TableName +   @" Guar_Return_Detail   Left Join Guar_Return on  Guar_Return_Detail.GuarReturnID = Guar_Return.ID 
			  "
                            + ") AS grd_Guar_Return_Detail  WHERE 1=1";
            if (cond != null && cond != string.Empty)
            {
                query += " AND " + cond;
            }
            if(order != "")
            {
                query += " ORDER BY " + order;
            }
            DataTable dt;
            if(tran==null)
                dt= DataProvider.ExecuteQuery(query);
            else  
                dt= DataProvider.ExecuteQueryWithTransaction(query,tran);
            return dt;
        }
        /// <summary>
        /// Truy xuất đối tượng qua id của đối tượng
        /// </summary>
        /// <param name="id">ID của đối tượng</param>
        /// <returns></returns>
        public DataTable GetByID(string id)
        {
            string query = @"SELECT Guar_Return_Detail.ID,Guar_Return_Detail.GuarReturnID,Guar_Return_Detail.ProductID,Guar_Return_Detail.Quantity,Guar_Return_Detail.OrderNum,Guar_Return_Detail.Deleted,convert(varchar(10),Guar_Return_Detail.DeletedOn,103) as DeletedOn FROM Guar_Return_Detail WHERE ID = " + id;
            DataTable dt = DataProvider.ExecuteQuery(query);
            return dt;
        }
        /// <summary>
        /// Truy xuất danh sách đối tượng qua điều kiện tùy ý
        /// </summary>
        /// <param name="id">ID của đối tượng</param>
        /// <returns></returns>
        public DataTable GetByCond(string cond, string order="", SqlTransaction  tran = null)
        {
            string query = @"SELECT Guar_Return_Detail.ID,Guar_Return_Detail.GuarReturnID,Guar_Return_Detail.ProductID,Guar_Return_Detail.Quantity,Guar_Return_Detail.OrderNum,Guar_Return_Detail.Deleted,convert(varchar(10),Guar_Return_Detail.DeletedOn,103) as DeletedOn FROM Guar_Return_Detail WHERE 1=1 ";
            if (cond != null && cond != string.Empty)
            {
                query += " and " + cond;
            };
            if(order != "")
            {
                query += " ORDER BY " + order;
            }
            DataTable dt;
            if(tran==null)
                dt= DataProvider.ExecuteQuery(query);
            else  
                dt= DataProvider.ExecuteQueryWithTransaction(query,tran);
            return dt;
        }
        /// <summary>
        /// Insert đối tượng vào database
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public string Insert(GuarReturnDetailContract guarreturndetail, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Guar_Return_Detail
                                        VALUES ({0},{1},{2},{3},{4},convert(datetime,{5},103))",
								
								(guarreturndetail.Guarreturnid != null? guarreturndetail.Guarreturnid.ToString() : "null").ToString(),
								(guarreturndetail.Productid.Trim() != String.Empty ? guarreturndetail.Productid.ToString() : "null").ToString(),
								(guarreturndetail.Quantity.Trim() != String.Empty ? guarreturndetail.Quantity.ToString() : "null").ToString(),
								(guarreturndetail.Ordernum.Trim() != String.Empty ? guarreturndetail.Ordernum.ToString() : "null").ToString(),
								(guarreturndetail.Deleted != null? "'" + SQLHelper.RejectInjection( guarreturndetail.Deleted.ToString() ) + "'" : "null").ToString(),
								(guarreturndetail.Deletedon != null? "'" + SQLHelper.RejectInjection( guarreturndetail.Deletedon.ToString() ) + "'" : "null").ToString());
            query += " ; select SCOPE_IDENTITY();";                            
            if (tran == null)
            {
                dtResult=DataProvider.ExecuteQuery(query);
            }
            else
            {
                dtResult=DataProvider.ExecuteQueryWithTransaction(query, tran);
            }
            if(dtResult != null && dtResult.Rows.Count>0)
            {
                return dtResult.Rows[0][0].ToString();
            }
            return "";
        }
        /// <summary>
        /// Cập nhật thông tin đối tượng
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public string Update(GuarReturnDetailContract guarreturndetail, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET GuarReturnID={0},ProductID={1},Quantity={2},OrderNum={3},Deleted={4},DeletedOn=convert(datetime,{5},103)
                            WHERE ID=" + guarreturndetail.Id.ToString(),
								(guarreturndetail.Guarreturnid != null? guarreturndetail.Guarreturnid.ToString() : "null").ToString(),
								(guarreturndetail.Productid.Trim() != String.Empty ? guarreturndetail.Productid.ToString() : "null").ToString(),
								(guarreturndetail.Quantity.Trim() != String.Empty ? guarreturndetail.Quantity.ToString() : "null").ToString(),
								(guarreturndetail.Ordernum.Trim() != String.Empty ? guarreturndetail.Ordernum.ToString() : "null").ToString(),
								(guarreturndetail.Deleted != null? "'" + SQLHelper.RejectInjection( guarreturndetail.Deleted.ToString() ) + "'" : "null").ToString(),
								(guarreturndetail.Deletedon != null? "'" + SQLHelper.RejectInjection( guarreturndetail.Deletedon.ToString() ) + "'" : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return guarreturndetail.Id.ToString();
        }
        
        /// <summary>
        /// Cập nhật các trường chỉ định  theo điều kiện
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        /// 
        public string Update(string[] columns, string[] values, string cond, SqlTransaction  tran = null)
        {
            if (cond != "")
            {
                string query = "UPDATE " + TableName + " SET ";
                string[] setExp = new string[columns.Length];
                for (int i = 0; i < columns.Length; i++)
                {
                    if (values.Length > i && values[i] != "")
                        setExp[i] = columns[i] + "=" + SQLHelper.RejectValueInjection(values[i]);
                    else
                        setExp[i] = columns[i] + "=null";
                }
                query += string.Join(",", setExp);
                query += " WHERE " + cond;
                if (tran == null)
                {
                    return DataProvider.ExecuteNonQuery( query).ToString();
                }
                else
                {
                    return DataProvider.ExecuteNonQueryWithTransaction(query, tran).ToString();
                }    
            }
            else
            {
                throw new Exception("Cập nhật đối tượng không có điều kiện.");
            }

        }
        
        
        /// <summary>
        /// Xóa đối tượng thông qua id đối tượng 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id, SqlTransaction  tran = null)
        {
            string query = "DELETE FROM " + TableName + " WHERE ID=" + id;
            if (tran == null)
            {
                return DataProvider.ExecuteNonQuery(query);                
            }
            else
            {
                return DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            
        }
        /// <summary>
        /// Xóa nhiều đối tượng bằng điều kiện
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteViaCond(string cond, SqlTransaction  tran = null)
        {
            if(cond !=null && cond!=string.Empty)
            {
                string query = "DELETE FROM " + TableName + " WHERE " + cond;
                if (tran == null)
                {
                    return DataProvider.ExecuteNonQuery(query);
                }
                else
                {
                    return DataProvider.ExecuteNonQueryWithTransaction(query, tran);
                }
            }
            else
            {
                throw(new Exception("Delete multiple records without condition."));
            }
        }
        /// <summary>
        /// Liệt kê dữ liệu hiển thị lên combobox
        /// </summary>
        /// <param name="cond">Điều kiện lọc dữ liệu</param>
        /// <returns></returns>
        public DataTable GetComboboxData(string columns="", string cond="", string order = "")
        {
            string selectedColumns = columns != ""?columns:"ID, Name, OrderNum";
            string query = String.Format(@"SELECT {0} FROM {1} WHERE 1=1 ", selectedColumns, TableName);
            if (cond != null && cond != string.Empty)
            {
                query += " and " + cond;
            }
            if(order != null && order != string.Empty)
            {
                 query += " order by " + order;
            }
            DataTable dt = DataProvider.ExecuteQuery(query);
            return dt;
        }
    }
}