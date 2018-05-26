   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class BuyPoDetailDT
    {
        string TableName = "Buy_PO_Detail";
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
                            Buy_PO_Detail.ID,Buy_PO_Detail.POID,Buy_PO_Detail.ProductID,Buy_PO_Detail.Quantity,Buy_PO_Detail.Price,Buy_PO_Detail.OrderNum,Buy_PO_Detail.Deleted,convert(varchar(10),Buy_PO_Detail.DeletedOn,103) as DeletedOn 
                              , Buy_PO.Code as Buy_PO_Name, Cat_Product.Name as Cat_Product_Name
                            FROM " + TableName +   @" Buy_PO_Detail   Left Join Buy_PO on  Buy_PO_Detail.POID = Buy_PO.ID 
			 Left Join Cat_Product on  Buy_PO_Detail.ProductID = Cat_Product.ID 
			  "
                            + ") AS grd_Buy_PO_Detail  WHERE 1=1";
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
            string query = @"SELECT Buy_PO_Detail.ID,Buy_PO_Detail.POID,Buy_PO_Detail.ProductID,Buy_PO_Detail.Quantity,Buy_PO_Detail.Price,Buy_PO_Detail.OrderNum,Buy_PO_Detail.Deleted,convert(varchar(10),Buy_PO_Detail.DeletedOn,103) as DeletedOn FROM Buy_PO_Detail WHERE ID = " + id;
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
            string query = @"SELECT Buy_PO_Detail.ID,Buy_PO_Detail.POID,Buy_PO_Detail.ProductID,Buy_PO_Detail.Quantity,Buy_PO_Detail.Price,Buy_PO_Detail.OrderNum,Buy_PO_Detail.Deleted,convert(varchar(10),Buy_PO_Detail.DeletedOn,103) as DeletedOn FROM Buy_PO_Detail WHERE 1=1 ";
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
        public string Insert(BuyPoDetailContract buypodetail, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Buy_PO_Detail
                                        VALUES ({0},{1},{2},{3},{4},{5},convert(datetime,{6},103))",
								
								(buypodetail.Poid != null? buypodetail.Poid.ToString() : "null").ToString(),
								(buypodetail.Productid != null? buypodetail.Productid.ToString() : "null").ToString(),
								(buypodetail.Quantity.Trim() != String.Empty ? buypodetail.Quantity.ToString() : "null").ToString(),
								(buypodetail.Price.Trim() != String.Empty ? buypodetail.Price.ToString() : "null").ToString(),
								(buypodetail.Ordernum.Trim() != String.Empty ? buypodetail.Ordernum.ToString() : "null").ToString(),
								(buypodetail.Deleted != null? "'" + SQLHelper.RejectInjection( buypodetail.Deleted.ToString() ) + "'" : "null").ToString(),
								(buypodetail.Deletedon != null? "'" + SQLHelper.RejectInjection( buypodetail.Deletedon.ToString() ) + "'" : "null").ToString());
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
        public string Update(BuyPoDetailContract buypodetail, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET POID={0},ProductID={1},Quantity={2},Price={3},OrderNum={4},Deleted={5},DeletedOn=convert(datetime,{6},103)
                            WHERE ID=" + buypodetail.Id.ToString(),
								(buypodetail.Poid != null? buypodetail.Poid.ToString() : "null").ToString(),
								(buypodetail.Productid != null? buypodetail.Productid.ToString() : "null").ToString(),
								(buypodetail.Quantity.Trim() != String.Empty ? buypodetail.Quantity.ToString() : "null").ToString(),
								(buypodetail.Price.Trim() != String.Empty ? buypodetail.Price.ToString() : "null").ToString(),
								(buypodetail.Ordernum.Trim() != String.Empty ? buypodetail.Ordernum.ToString() : "null").ToString(),
								(buypodetail.Deleted != null? "'" + SQLHelper.RejectInjection( buypodetail.Deleted.ToString() ) + "'" : "null").ToString(),
								(buypodetail.Deletedon != null? "'" + SQLHelper.RejectInjection( buypodetail.Deletedon.ToString() ) + "'" : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return buypodetail.Id.ToString();
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