   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class GuarReturnDT
    {
        string TableName = "Guar_Return";
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
                            Guar_Return.ID,Guar_Return.SaleStaffID,Guar_Return.CustomerID,Guar_Return.GuaranteeID,Guar_Return.Code,convert(varchar(10),Guar_Return.CreateDate,103) as CreateDate,Guar_Return.Description,Guar_Return.OrderNum 
                             , Buy_Guarantee.Name as Buy_Guarantee_Name, Cat_Customer.Name as Cat_Customer_Name, Cat_SaleStaff.Name as Cat_SaleStaff_Name
                            FROM " + TableName +   @" Guar_Return   Left Join Buy_Guarantee on  Guar_Return.GuaranteeID = Buy_Guarantee.ID 
			 Left Join Cat_Customer on  Guar_Return.CustomerID = Cat_Customer.ID 
			 Left Join Cat_SaleStaff on  Guar_Return.SaleStaffID = Cat_SaleStaff.ID 
			  "
                            + ") AS grd_Guar_Return  WHERE 1=1";
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
            string query = @"SELECT Guar_Return.ID,Guar_Return.SaleStaffID,Guar_Return.CustomerID,Guar_Return.GuaranteeID,Guar_Return.Code,convert(varchar(10),Guar_Return.CreateDate,103) as CreateDate,Guar_Return.Description,Guar_Return.OrderNum FROM Guar_Return WHERE ID = " + id;
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
            string query = @"SELECT Guar_Return.ID,Guar_Return.SaleStaffID,Guar_Return.CustomerID,Guar_Return.GuaranteeID,Guar_Return.Code,convert(varchar(10),Guar_Return.CreateDate,103) as CreateDate,Guar_Return.Description,Guar_Return.OrderNum FROM Guar_Return WHERE 1=1 ";
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
        public string Insert(GuarReturnContract guarreturn, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Guar_Return
                                        VALUES ({0},{1},{2},{3},convert(datetime,{4},103),{5},{6})",
								
								(guarreturn.Salestaffid != null? guarreturn.Salestaffid.ToString() : "null").ToString(),
								(guarreturn.Customerid != null? guarreturn.Customerid.ToString() : "null").ToString(),
								(guarreturn.Guaranteeid != null? guarreturn.Guaranteeid.ToString() : "null").ToString(),
								(guarreturn.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( guarreturn.Code.ToString() ) + "'" : "null").ToString(),
								(guarreturn.Createdate != null? "'" + SQLHelper.RejectInjection( guarreturn.Createdate.ToString() ) + "'" : "null").ToString(),
								(guarreturn.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( guarreturn.Description.ToString() ) + "'" : "null").ToString(),
								(guarreturn.Ordernum.Trim() != String.Empty ? guarreturn.Ordernum.ToString() : "null").ToString());
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
        public string Update(GuarReturnContract guarreturn, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET SaleStaffID={0},CustomerID={1},GuaranteeID={2},Code={3},CreateDate=convert(datetime,{4},103),Description={5},OrderNum={6}
                            WHERE ID=" + guarreturn.Id.ToString(),
								(guarreturn.Salestaffid != null? guarreturn.Salestaffid.ToString() : "null").ToString(),
								(guarreturn.Customerid != null? guarreturn.Customerid.ToString() : "null").ToString(),
								(guarreturn.Guaranteeid != null? guarreturn.Guaranteeid.ToString() : "null").ToString(),
								(guarreturn.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( guarreturn.Code.ToString() ) + "'" : "null").ToString(),
								(guarreturn.Createdate != null? "'" + SQLHelper.RejectInjection( guarreturn.Createdate.ToString() ) + "'" : "null").ToString(),
								(guarreturn.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( guarreturn.Description.ToString() ) + "'" : "null").ToString(),
								(guarreturn.Ordernum.Trim() != String.Empty ? guarreturn.Ordernum.ToString() : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return guarreturn.Id.ToString();
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