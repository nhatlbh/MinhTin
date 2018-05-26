   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class SelReceiveproductDT
    {
        string TableName = "Sel_ReceiveProduct";
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
                            Sel_ReceiveProduct.ID,Sel_ReceiveProduct.SaleStaffID,Sel_ReceiveProduct.Code,Sel_ReceiveProduct.InvoiceID,Sel_ReceiveProduct.CustomerID,Sel_ReceiveProduct.StoreID,convert(varchar(10),Sel_ReceiveProduct.CreateDate,103) as CreateDate,Sel_ReceiveProduct.Description,Sel_ReceiveProduct.Total,Sel_ReceiveProduct.TotalReturn,Sel_ReceiveProduct.Discount,Sel_ReceiveProduct.OrderNum 
                              , Sel_Invoice.Code as Sel_Invoice_Name, Cat_SaleStaff.Name as Cat_SaleStaff_Name, Cat_Customer.Name as Cat_Customer_Name, Cat_Store.Name as Cat_Store_Name
                            FROM " + TableName +   @" Sel_ReceiveProduct   Left Join Sel_Invoice on  Sel_ReceiveProduct.InvoiceID = Sel_Invoice.ID 
			 Left Join Cat_SaleStaff on  Sel_ReceiveProduct.SaleStaffID = Cat_SaleStaff.ID 
			 Left Join Cat_Customer on  Sel_ReceiveProduct.CustomerID = Cat_Customer.ID 
			 Left Join Cat_Store on  Sel_ReceiveProduct.StoreID = Cat_Store.ID 
			  "
                            + ") AS grd_Sel_ReceiveProduct  WHERE 1=1";
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
            string query = @"SELECT Sel_ReceiveProduct.ID,Sel_ReceiveProduct.SaleStaffID,Sel_ReceiveProduct.Code,Sel_ReceiveProduct.InvoiceID,Sel_ReceiveProduct.CustomerID,Sel_ReceiveProduct.StoreID,convert(varchar(10),Sel_ReceiveProduct.CreateDate,103) as CreateDate,Sel_ReceiveProduct.Description,Sel_ReceiveProduct.Total,Sel_ReceiveProduct.TotalReturn,Sel_ReceiveProduct.Discount,Sel_ReceiveProduct.OrderNum FROM Sel_ReceiveProduct WHERE ID = " + id;
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
            string query = @"SELECT Sel_ReceiveProduct.ID,Sel_ReceiveProduct.SaleStaffID,Sel_ReceiveProduct.Code,Sel_ReceiveProduct.InvoiceID,Sel_ReceiveProduct.CustomerID,Sel_ReceiveProduct.StoreID,convert(varchar(10),Sel_ReceiveProduct.CreateDate,103) as CreateDate,Sel_ReceiveProduct.Description,Sel_ReceiveProduct.Total,Sel_ReceiveProduct.TotalReturn,Sel_ReceiveProduct.Discount,Sel_ReceiveProduct.OrderNum FROM Sel_ReceiveProduct WHERE 1=1 ";
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
        public string Insert(SelReceiveproductContract selreceiveproduct, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Sel_ReceiveProduct
                                        VALUES ({0},{1},{2},{3},{4},convert(datetime,{5},103),{6},{7},{8},{9},{10})",
								
								(selreceiveproduct.Salestaffid != null? selreceiveproduct.Salestaffid.ToString() : "null").ToString(),
								(selreceiveproduct.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selreceiveproduct.Code.ToString() ) + "'" : "null").ToString(),
								(selreceiveproduct.Invoiceid != null? selreceiveproduct.Invoiceid.ToString() : "null").ToString(),
								(selreceiveproduct.Customerid != null? selreceiveproduct.Customerid.ToString() : "null").ToString(),
								(selreceiveproduct.Storeid != null? selreceiveproduct.Storeid.ToString() : "null").ToString(),
								(selreceiveproduct.Createdate != null? "'" + SQLHelper.RejectInjection( selreceiveproduct.Createdate.ToString() ) + "'" : "null").ToString(),
								(selreceiveproduct.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selreceiveproduct.Description.ToString() ) + "'" : "null").ToString(),
								(selreceiveproduct.Total.Trim() != String.Empty ? selreceiveproduct.Total.ToString() : "null").ToString(),
								(selreceiveproduct.Totalreturn.Trim() != String.Empty ? selreceiveproduct.Totalreturn.ToString() : "null").ToString(),
								(selreceiveproduct.Discount.Trim() != String.Empty ? selreceiveproduct.Discount.ToString() : "null").ToString(),
								(selreceiveproduct.Ordernum.Trim() != String.Empty ? selreceiveproduct.Ordernum.ToString() : "null").ToString());
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
        public string Update(SelReceiveproductContract selreceiveproduct, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET SaleStaffID={0},Code={1},InvoiceID={2},CustomerID={3},StoreID={4},CreateDate=convert(datetime,{5},103),Description={6},Total={7},TotalReturn={8},Discount={9},OrderNum={10}
                            WHERE ID=" + selreceiveproduct.Id.ToString(),
								(selreceiveproduct.Salestaffid != null? selreceiveproduct.Salestaffid.ToString() : "null").ToString(),
								(selreceiveproduct.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selreceiveproduct.Code.ToString() ) + "'" : "null").ToString(),
								(selreceiveproduct.Invoiceid != null? selreceiveproduct.Invoiceid.ToString() : "null").ToString(),
								(selreceiveproduct.Customerid != null? selreceiveproduct.Customerid.ToString() : "null").ToString(),
								(selreceiveproduct.Storeid != null? selreceiveproduct.Storeid.ToString() : "null").ToString(),
								(selreceiveproduct.Createdate != null? "'" + SQLHelper.RejectInjection( selreceiveproduct.Createdate.ToString() ) + "'" : "null").ToString(),
								(selreceiveproduct.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selreceiveproduct.Description.ToString() ) + "'" : "null").ToString(),
								(selreceiveproduct.Total.Trim() != String.Empty ? selreceiveproduct.Total.ToString() : "null").ToString(),
								(selreceiveproduct.Totalreturn.Trim() != String.Empty ? selreceiveproduct.Totalreturn.ToString() : "null").ToString(),
								(selreceiveproduct.Discount.Trim() != String.Empty ? selreceiveproduct.Discount.ToString() : "null").ToString(),
								(selreceiveproduct.Ordernum.Trim() != String.Empty ? selreceiveproduct.Ordernum.ToString() : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return selreceiveproduct.Id.ToString();
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