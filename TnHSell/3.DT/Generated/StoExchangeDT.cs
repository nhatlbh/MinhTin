   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class StoExchangeDT
    {
        string TableName = "Sto_Exchange";
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
                            Sto_Exchange.ID,Sto_Exchange.SaleStaffID,Sto_Exchange.Code,Sto_Exchange.FromStoreID,Sto_Exchange.ToStoreID,convert(varchar(10),Sto_Exchange.CreateDate,103) as CreateDate,Sto_Exchange.Description,Sto_Exchange.OrderNum 
                             , Cat_Store.Name as Cat_Store_Name_From, Cat_SaleStaff.Name as Cat_SaleStaff_Name, stt.Name as Cat_Store_Name_To
                            FROM " + TableName + @" Sto_Exchange   Left Join Cat_Store on  Sto_Exchange.FromStoreID = Cat_Store.ID 
			 Left Join Cat_SaleStaff on  Sto_Exchange.SaleStaffID = Cat_SaleStaff.ID 
			 Left Join Cat_Store stt on  Sto_Exchange.ToStoreID = stt.ID 
			  "
                            + ") AS grd_Sto_Exchange  WHERE 1=1";
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
            string query = @"SELECT Sto_Exchange.ID,Sto_Exchange.SaleStaffID,Sto_Exchange.Code,Sto_Exchange.FromStoreID,Sto_Exchange.ToStoreID,convert(varchar(10),Sto_Exchange.CreateDate,103) as CreateDate,Sto_Exchange.Description,Sto_Exchange.OrderNum FROM Sto_Exchange WHERE ID = " + id;
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
            string query = @"SELECT Sto_Exchange.ID,Sto_Exchange.SaleStaffID,Sto_Exchange.Code,Sto_Exchange.FromStoreID,Sto_Exchange.ToStoreID,convert(varchar(10),Sto_Exchange.CreateDate,103) as CreateDate,Sto_Exchange.Description,Sto_Exchange.OrderNum FROM Sto_Exchange WHERE 1=1 ";
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
        public string Insert(StoExchangeContract stoexchange, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Sto_Exchange
                                        VALUES ({0},{1},{2},{3},convert(datetime,{4},103),{5},{6})",
								
								(stoexchange.Salestaffid != null? stoexchange.Salestaffid.ToString() : "null").ToString(),
								(stoexchange.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( stoexchange.Code.ToString() ) + "'" : "null").ToString(),
								(stoexchange.Fromstoreid != null? stoexchange.Fromstoreid.ToString() : "null").ToString(),
								(stoexchange.Tostoreid != null? stoexchange.Tostoreid.ToString() : "null").ToString(),
								(stoexchange.Createdate != null? "'" + SQLHelper.RejectInjection( stoexchange.Createdate.ToString() ) + "'" : "null").ToString(),
								(stoexchange.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( stoexchange.Description.ToString() ) + "'" : "null").ToString(),
								(stoexchange.Ordernum.Trim() != String.Empty ? stoexchange.Ordernum.ToString() : "null").ToString());
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
        public string Update(StoExchangeContract stoexchange, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET SaleStaffID={0},Code={1},FromStoreID={2},ToStoreID={3},CreateDate=convert(datetime,{4},103),Description={5},OrderNum={6}
                            WHERE ID=" + stoexchange.Id.ToString(),
								(stoexchange.Salestaffid != null? stoexchange.Salestaffid.ToString() : "null").ToString(),
								(stoexchange.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( stoexchange.Code.ToString() ) + "'" : "null").ToString(),
								(stoexchange.Fromstoreid != null? stoexchange.Fromstoreid.ToString() : "null").ToString(),
								(stoexchange.Tostoreid != null? stoexchange.Tostoreid.ToString() : "null").ToString(),
								(stoexchange.Createdate != null? "'" + SQLHelper.RejectInjection( stoexchange.Createdate.ToString() ) + "'" : "null").ToString(),
								(stoexchange.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( stoexchange.Description.ToString() ) + "'" : "null").ToString(),
								(stoexchange.Ordernum.Trim() != String.Empty ? stoexchange.Ordernum.ToString() : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return stoexchange.Id.ToString();
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