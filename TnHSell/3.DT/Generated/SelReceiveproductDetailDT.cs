   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class SelReceiveproductDetailDT
    {
        string TableName = "Sel_ReceiveProduct_Detail";
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
                            Sel_ReceiveProduct_Detail.ID,Sel_ReceiveProduct_Detail.ReceiveProductID,Sel_ReceiveProduct_Detail.ProductID,Sel_ReceiveProduct_Detail.Quantity,Sel_ReceiveProduct_Detail.Price,Sel_ReceiveProduct_Detail.OrderNum,Sel_ReceiveProduct_Detail.Deleted,convert(varchar(10),Sel_ReceiveProduct_Detail.DeletedOn,103) as DeletedOn 
                             , Cat_Product.Name as Cat_Product_Name , Sel_ReceiveProduct.Code as Sel_ReceiveProduct_Name
                            FROM " + TableName +   @" Sel_ReceiveProduct_Detail   Left Join Cat_Product on  Sel_ReceiveProduct_Detail.ProductID = Cat_Product.ID 
			 Left Join Sel_ReceiveProduct on  Sel_ReceiveProduct_Detail.ReceiveProductID = Sel_ReceiveProduct.ID 
			  "
                            + ") AS grd_Sel_ReceiveProduct_Detail  WHERE 1=1";
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
            string query = @"SELECT Sel_ReceiveProduct_Detail.ID,Sel_ReceiveProduct_Detail.ReceiveProductID,Sel_ReceiveProduct_Detail.ProductID,Sel_ReceiveProduct_Detail.Quantity,Sel_ReceiveProduct_Detail.Price,Sel_ReceiveProduct_Detail.OrderNum,Sel_ReceiveProduct_Detail.Deleted,convert(varchar(10),Sel_ReceiveProduct_Detail.DeletedOn,103) as DeletedOn FROM Sel_ReceiveProduct_Detail WHERE ID = " + id;
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
            string query = @"SELECT Sel_ReceiveProduct_Detail.ID,Sel_ReceiveProduct_Detail.ReceiveProductID,Sel_ReceiveProduct_Detail.ProductID,Sel_ReceiveProduct_Detail.Quantity,Sel_ReceiveProduct_Detail.Price,Sel_ReceiveProduct_Detail.OrderNum,Sel_ReceiveProduct_Detail.Deleted,convert(varchar(10),Sel_ReceiveProduct_Detail.DeletedOn,103) as DeletedOn FROM Sel_ReceiveProduct_Detail WHERE 1=1 ";
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
        public string Insert(SelReceiveproductDetailContract selreceiveproductdetail, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Sel_ReceiveProduct_Detail
                                        VALUES ({0},{1},{2},{3},{4},{5},convert(datetime,{6},103))",
								
								(selreceiveproductdetail.Receiveproductid != null? selreceiveproductdetail.Receiveproductid.ToString() : "null").ToString(),
								(selreceiveproductdetail.Productid != null? selreceiveproductdetail.Productid.ToString() : "null").ToString(),
								(selreceiveproductdetail.Quantity.Trim() != String.Empty ? selreceiveproductdetail.Quantity.ToString() : "null").ToString(),
								(selreceiveproductdetail.Price.Trim() != String.Empty ? selreceiveproductdetail.Price.ToString() : "null").ToString(),
								(selreceiveproductdetail.Ordernum.Trim() != String.Empty ? selreceiveproductdetail.Ordernum.ToString() : "null").ToString(),
								(selreceiveproductdetail.Deleted != null? "'" + SQLHelper.RejectInjection( selreceiveproductdetail.Deleted.ToString() ) + "'" : "null").ToString(),
								(selreceiveproductdetail.Deletedon != null? "'" + SQLHelper.RejectInjection( selreceiveproductdetail.Deletedon.ToString() ) + "'" : "null").ToString());
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
        public string Update(SelReceiveproductDetailContract selreceiveproductdetail, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET ReceiveProductID={0},ProductID={1},Quantity={2},Price={3},OrderNum={4},Deleted={5},DeletedOn=convert(datetime,{6},103)
                            WHERE ID=" + selreceiveproductdetail.Id.ToString(),
								(selreceiveproductdetail.Receiveproductid != null? selreceiveproductdetail.Receiveproductid.ToString() : "null").ToString(),
								(selreceiveproductdetail.Productid != null? selreceiveproductdetail.Productid.ToString() : "null").ToString(),
								(selreceiveproductdetail.Quantity.Trim() != String.Empty ? selreceiveproductdetail.Quantity.ToString() : "null").ToString(),
								(selreceiveproductdetail.Price.Trim() != String.Empty ? selreceiveproductdetail.Price.ToString() : "null").ToString(),
								(selreceiveproductdetail.Ordernum.Trim() != String.Empty ? selreceiveproductdetail.Ordernum.ToString() : "null").ToString(),
								(selreceiveproductdetail.Deleted != null? "'" + SQLHelper.RejectInjection( selreceiveproductdetail.Deleted.ToString() ) + "'" : "null").ToString(),
								(selreceiveproductdetail.Deletedon != null? "'" + SQLHelper.RejectInjection( selreceiveproductdetail.Deletedon.ToString() ) + "'" : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return selreceiveproductdetail.Id.ToString();
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