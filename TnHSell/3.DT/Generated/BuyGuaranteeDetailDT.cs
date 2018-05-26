   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class BuyGuaranteeDetailDT
    {
        string TableName = "Buy_Guarantee_Detail";
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
                            Buy_Guarantee_Detail.ID,Buy_Guarantee_Detail.GuaranteeID,Buy_Guarantee_Detail.ProductID,Buy_Guarantee_Detail.Quantity,Buy_Guarantee_Detail.OrderNum,Buy_Guarantee_Detail.Deleted,convert(varchar(10),Buy_Guarantee_Detail.DeletedOn,103) as DeletedOn 
                             , Buy_Guarantee.Name as Buy_Guarantee_Name, Cat_Product.Name as Cat_Product_Name
                            FROM " + TableName +   @" Buy_Guarantee_Detail   Left Join Buy_Guarantee on  Buy_Guarantee_Detail.GuaranteeID = Buy_Guarantee.ID 
			 Left Join Cat_Product on  Buy_Guarantee_Detail.ProductID = Cat_Product.ID 
			  "
                            + ") AS grd_Buy_Guarantee_Detail  WHERE 1=1";
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
            string query = @"SELECT Buy_Guarantee_Detail.ID,Buy_Guarantee_Detail.GuaranteeID,Buy_Guarantee_Detail.ProductID,Buy_Guarantee_Detail.Quantity,Buy_Guarantee_Detail.OrderNum,Buy_Guarantee_Detail.Deleted,convert(varchar(10),Buy_Guarantee_Detail.DeletedOn,103) as DeletedOn FROM Buy_Guarantee_Detail WHERE ID = " + id;
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
            string query = @"SELECT Buy_Guarantee_Detail.ID,Buy_Guarantee_Detail.GuaranteeID,Buy_Guarantee_Detail.ProductID,Buy_Guarantee_Detail.Quantity,Buy_Guarantee_Detail.OrderNum,Buy_Guarantee_Detail.Deleted,convert(varchar(10),Buy_Guarantee_Detail.DeletedOn,103) as DeletedOn FROM Buy_Guarantee_Detail WHERE 1=1 ";
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
        public string Insert(BuyGuaranteeDetailContract buyguaranteedetail, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Buy_Guarantee_Detail
                                        VALUES ({0},{1},{2},{3},{4},convert(datetime,{5},103))",
								
								(buyguaranteedetail.Guaranteeid != null? buyguaranteedetail.Guaranteeid.ToString() : "null").ToString(),
								(buyguaranteedetail.Productid != null? buyguaranteedetail.Productid.ToString() : "null").ToString(),
								(buyguaranteedetail.Quantity.Trim() != String.Empty ? buyguaranteedetail.Quantity.ToString() : "null").ToString(),
								(buyguaranteedetail.Ordernum.Trim() != String.Empty ? buyguaranteedetail.Ordernum.ToString() : "null").ToString(),
								(buyguaranteedetail.Deleted != null? "'" + SQLHelper.RejectInjection( buyguaranteedetail.Deleted.ToString() ) + "'" : "null").ToString(),
								(buyguaranteedetail.Deletedon != null? "'" + SQLHelper.RejectInjection( buyguaranteedetail.Deletedon.ToString() ) + "'" : "null").ToString());
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
        public string Update(BuyGuaranteeDetailContract buyguaranteedetail, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET GuaranteeID={0},ProductID={1},Quantity={2},OrderNum={3},Deleted={4},DeletedOn=convert(datetime,{5},103)
                            WHERE ID=" + buyguaranteedetail.Id.ToString(),
								(buyguaranteedetail.Guaranteeid != null? buyguaranteedetail.Guaranteeid.ToString() : "null").ToString(),
								(buyguaranteedetail.Productid != null? buyguaranteedetail.Productid.ToString() : "null").ToString(),
								(buyguaranteedetail.Quantity.Trim() != String.Empty ? buyguaranteedetail.Quantity.ToString() : "null").ToString(),
								(buyguaranteedetail.Ordernum.Trim() != String.Empty ? buyguaranteedetail.Ordernum.ToString() : "null").ToString(),
								(buyguaranteedetail.Deleted != null? "'" + SQLHelper.RejectInjection( buyguaranteedetail.Deleted.ToString() ) + "'" : "null").ToString(),
								(buyguaranteedetail.Deletedon != null? "'" + SQLHelper.RejectInjection( buyguaranteedetail.Deletedon.ToString() ) + "'" : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return buyguaranteedetail.Id.ToString();
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