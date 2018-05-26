   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class BuySupplierreturnDT
    {
        string TableName = "Buy_SupplierReturn";
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
                            Buy_SupplierReturn.ID,Buy_SupplierReturn.SaleStaffID,Buy_SupplierReturn.Code,Buy_SupplierReturn.ImportInvoiceID,Buy_SupplierReturn.SupplierID,convert(varchar(10),Buy_SupplierReturn.CreateDate,103) as CreateDate,Buy_SupplierReturn.Description,Buy_SupplierReturn.TotalDebt,Buy_SupplierReturn.OrderNum 
                             , Cat_SaleStaff.Name as Cat_SaleStaff_Name , Buy_ImportInvoice.Code as Buy_ImportInvoice_Name, Cat_Supplier.Name as Cat_Supplier_Name
                            FROM " + TableName +   @" Buy_SupplierReturn   Left Join Cat_SaleStaff on  Buy_SupplierReturn.SaleStaffID = Cat_SaleStaff.ID 
			 Left Join Buy_ImportInvoice on  Buy_SupplierReturn.ImportInvoiceID = Buy_ImportInvoice.ID 
			 Left Join Cat_Supplier on  Buy_SupplierReturn.SupplierID = Cat_Supplier.ID 
			  "
                            + ") AS grd_Buy_SupplierReturn  WHERE 1=1";
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
            string query = @"SELECT Buy_SupplierReturn.ID,Buy_SupplierReturn.SaleStaffID,Buy_SupplierReturn.Code,Buy_SupplierReturn.ImportInvoiceID,Buy_SupplierReturn.SupplierID,convert(varchar(10),Buy_SupplierReturn.CreateDate,103) as CreateDate,Buy_SupplierReturn.Description,Buy_SupplierReturn.TotalDebt,Buy_SupplierReturn.OrderNum FROM Buy_SupplierReturn WHERE ID = " + id;
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
            string query = @"SELECT Buy_SupplierReturn.ID,Buy_SupplierReturn.SaleStaffID,Buy_SupplierReturn.Code,Buy_SupplierReturn.ImportInvoiceID,Buy_SupplierReturn.SupplierID,convert(varchar(10),Buy_SupplierReturn.CreateDate,103) as CreateDate,Buy_SupplierReturn.Description,Buy_SupplierReturn.TotalDebt,Buy_SupplierReturn.OrderNum FROM Buy_SupplierReturn WHERE 1=1 ";
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
        public string Insert(BuySupplierreturnContract buysupplierreturn, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Buy_SupplierReturn
                                        VALUES ({0},{1},{2},{3},convert(datetime,{4},103),{5},{6},{7})",
								
								(buysupplierreturn.Salestaffid != null? buysupplierreturn.Salestaffid.ToString() : "null").ToString(),
								(buysupplierreturn.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( buysupplierreturn.Code.ToString() ) + "'" : "null").ToString(),
								(buysupplierreturn.Importinvoiceid != null? buysupplierreturn.Importinvoiceid.ToString() : "null").ToString(),
								(buysupplierreturn.Supplierid != null? buysupplierreturn.Supplierid.ToString() : "null").ToString(),
								(buysupplierreturn.Createdate != null? "'" + SQLHelper.RejectInjection( buysupplierreturn.Createdate.ToString() ) + "'" : "null").ToString(),
								(buysupplierreturn.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( buysupplierreturn.Description.ToString() ) + "'" : "null").ToString(),
								(buysupplierreturn.Totaldebt.Trim() != String.Empty ? buysupplierreturn.Totaldebt.ToString() : "null").ToString(),
								(buysupplierreturn.Ordernum.Trim() != String.Empty ? buysupplierreturn.Ordernum.ToString() : "null").ToString());
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
        public string Update(BuySupplierreturnContract buysupplierreturn, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET SaleStaffID={0},Code={1},ImportInvoiceID={2},SupplierID={3},CreateDate=convert(datetime,{4},103),Description={5},TotalDebt={6},OrderNum={7}
                            WHERE ID=" + buysupplierreturn.Id.ToString(),
								(buysupplierreturn.Salestaffid != null? buysupplierreturn.Salestaffid.ToString() : "null").ToString(),
								(buysupplierreturn.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( buysupplierreturn.Code.ToString() ) + "'" : "null").ToString(),
								(buysupplierreturn.Importinvoiceid != null? buysupplierreturn.Importinvoiceid.ToString() : "null").ToString(),
								(buysupplierreturn.Supplierid != null? buysupplierreturn.Supplierid.ToString() : "null").ToString(),
								(buysupplierreturn.Createdate != null? "'" + SQLHelper.RejectInjection( buysupplierreturn.Createdate.ToString() ) + "'" : "null").ToString(),
								(buysupplierreturn.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( buysupplierreturn.Description.ToString() ) + "'" : "null").ToString(),
								(buysupplierreturn.Totaldebt.Trim() != String.Empty ? buysupplierreturn.Totaldebt.ToString() : "null").ToString(),
								(buysupplierreturn.Ordernum.Trim() != String.Empty ? buysupplierreturn.Ordernum.ToString() : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return buysupplierreturn.Id.ToString();
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