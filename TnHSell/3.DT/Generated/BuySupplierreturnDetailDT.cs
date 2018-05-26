   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class BuySupplierreturnDetailDT
    {
        string TableName = "Buy_SupplierReturn_Detail";
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
                            Buy_SupplierReturn_Detail.ID,Buy_SupplierReturn_Detail.SupplierReturnID,Buy_SupplierReturn_Detail.ProductID,Buy_SupplierReturn_Detail.Quantity,Buy_SupplierReturn_Detail.Price,Buy_SupplierReturn_Detail.VAT,Buy_SupplierReturn_Detail.OrderNum,Buy_SupplierReturn_Detail.Deleted,convert(varchar(10),Buy_SupplierReturn_Detail.DeletedOn,103) as DeletedOn 
                              , Buy_SupplierReturn.Code as Buy_SupplierReturn_Name, Cat_Product.Name as Cat_Product_Name
                            FROM " + TableName +   @" Buy_SupplierReturn_Detail   Left Join Buy_SupplierReturn on  Buy_SupplierReturn_Detail.SupplierReturnID = Buy_SupplierReturn.ID 
			 Left Join Cat_Product on  Buy_SupplierReturn_Detail.ProductID = Cat_Product.ID 
			  "
                            + ") AS grd_Buy_SupplierReturn_Detail  WHERE 1=1";
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
            string query = @"SELECT Buy_SupplierReturn_Detail.ID,Buy_SupplierReturn_Detail.SupplierReturnID,Buy_SupplierReturn_Detail.ProductID,Buy_SupplierReturn_Detail.Quantity,Buy_SupplierReturn_Detail.Price,Buy_SupplierReturn_Detail.VAT,Buy_SupplierReturn_Detail.OrderNum,Buy_SupplierReturn_Detail.Deleted,convert(varchar(10),Buy_SupplierReturn_Detail.DeletedOn,103) as DeletedOn FROM Buy_SupplierReturn_Detail WHERE ID = " + id;
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
            string query = @"SELECT Buy_SupplierReturn_Detail.ID,Buy_SupplierReturn_Detail.SupplierReturnID,Buy_SupplierReturn_Detail.ProductID,Buy_SupplierReturn_Detail.Quantity,Buy_SupplierReturn_Detail.Price,Buy_SupplierReturn_Detail.VAT,Buy_SupplierReturn_Detail.OrderNum,Buy_SupplierReturn_Detail.Deleted,convert(varchar(10),Buy_SupplierReturn_Detail.DeletedOn,103) as DeletedOn FROM Buy_SupplierReturn_Detail WHERE 1=1 ";
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
        public string Insert(BuySupplierreturnDetailContract buysupplierreturndetail, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Buy_SupplierReturn_Detail
                                        VALUES ({0},{1},{2},{3},{4},{5},{6},convert(datetime,{7},103))",
								
								(buysupplierreturndetail.Supplierreturnid != null? buysupplierreturndetail.Supplierreturnid.ToString() : "null").ToString(),
								(buysupplierreturndetail.Productid != null? buysupplierreturndetail.Productid.ToString() : "null").ToString(),
								(buysupplierreturndetail.Quantity.Trim() != String.Empty ? buysupplierreturndetail.Quantity.ToString() : "null").ToString(),
								(buysupplierreturndetail.Price.Trim() != String.Empty ? buysupplierreturndetail.Price.ToString() : "null").ToString(),
								(buysupplierreturndetail.Vat.Trim() != String.Empty ? buysupplierreturndetail.Vat.ToString() : "null").ToString(),
								(buysupplierreturndetail.Ordernum.Trim() != String.Empty ? buysupplierreturndetail.Ordernum.ToString() : "null").ToString(),
								(buysupplierreturndetail.Deleted != null? "'" + SQLHelper.RejectInjection( buysupplierreturndetail.Deleted.ToString() ) + "'" : "null").ToString(),
								(buysupplierreturndetail.Deletedon != null? "'" + SQLHelper.RejectInjection( buysupplierreturndetail.Deletedon.ToString() ) + "'" : "null").ToString());
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
        public string Update(BuySupplierreturnDetailContract buysupplierreturndetail, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET SupplierReturnID={0},ProductID={1},Quantity={2},Price={3},VAT={4},OrderNum={5},Deleted={6},DeletedOn=convert(datetime,{7},103)
                            WHERE ID=" + buysupplierreturndetail.Id.ToString(),
								(buysupplierreturndetail.Supplierreturnid != null? buysupplierreturndetail.Supplierreturnid.ToString() : "null").ToString(),
								(buysupplierreturndetail.Productid != null? buysupplierreturndetail.Productid.ToString() : "null").ToString(),
								(buysupplierreturndetail.Quantity.Trim() != String.Empty ? buysupplierreturndetail.Quantity.ToString() : "null").ToString(),
								(buysupplierreturndetail.Price.Trim() != String.Empty ? buysupplierreturndetail.Price.ToString() : "null").ToString(),
								(buysupplierreturndetail.Vat.Trim() != String.Empty ? buysupplierreturndetail.Vat.ToString() : "null").ToString(),
								(buysupplierreturndetail.Ordernum.Trim() != String.Empty ? buysupplierreturndetail.Ordernum.ToString() : "null").ToString(),
								(buysupplierreturndetail.Deleted != null? "'" + SQLHelper.RejectInjection( buysupplierreturndetail.Deleted.ToString() ) + "'" : "null").ToString(),
								(buysupplierreturndetail.Deletedon != null? "'" + SQLHelper.RejectInjection( buysupplierreturndetail.Deletedon.ToString() ) + "'" : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return buysupplierreturndetail.Id.ToString();
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