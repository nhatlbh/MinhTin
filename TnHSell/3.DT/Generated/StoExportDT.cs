﻿   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class StoExportDT
    {
        string TableName = "Sto_Export";
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
                            Sto_Export.ID,Sto_Export.SaleStaffID,Sto_Export.Code,Sto_Export.StoreID,Sto_Export.Reason,Sto_Export.Description,convert(varchar(10),Sto_Export.CreateDate,103) as CreateDate,Sto_Export.OrderNum 
                             , Cat_Store.Name as Cat_Store_Name, Cat_SaleStaff.Name as Cat_SaleStaff_Name
                            FROM " + TableName +   @" Sto_Export   Left Join Cat_Store on  Sto_Export.StoreID = Cat_Store.ID 
			 Left Join Cat_SaleStaff on  Sto_Export.SaleStaffID = Cat_SaleStaff.ID 
			  "
                            + ") AS grd_Sto_Export  WHERE 1=1";
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
            string query = @"SELECT Sto_Export.ID,Sto_Export.SaleStaffID,Sto_Export.Code,Sto_Export.StoreID,Sto_Export.Reason,Sto_Export.Description,convert(varchar(10),Sto_Export.CreateDate,103) as CreateDate,Sto_Export.OrderNum FROM Sto_Export WHERE ID = " + id;
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
            string query = @"SELECT Sto_Export.ID,Sto_Export.SaleStaffID,Sto_Export.Code,Sto_Export.StoreID,Sto_Export.Reason,Sto_Export.Description,convert(varchar(10),Sto_Export.CreateDate,103) as CreateDate,Sto_Export.OrderNum FROM Sto_Export WHERE 1=1 ";
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
        public string Insert(StoExportContract stoexport, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Sto_Export
                                        VALUES ({0},{1},{2},{3},{4},convert(datetime,{5},103),{6})",
								
								(stoexport.Salestaffid != null? stoexport.Salestaffid.ToString() : "null").ToString(),
								(stoexport.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( stoexport.Code.ToString() ) + "'" : "null").ToString(),
								(stoexport.Storeid != null? stoexport.Storeid.ToString() : "null").ToString(),
								(stoexport.Reason.Trim() != String.Empty ? stoexport.Reason.ToString() : "null").ToString(),
								(stoexport.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( stoexport.Description.ToString() ) + "'" : "null").ToString(),
								(stoexport.Createdate != null? "'" + SQLHelper.RejectInjection( stoexport.Createdate.ToString() ) + "'" : "null").ToString(),
								(stoexport.Ordernum.Trim() != String.Empty ? stoexport.Ordernum.ToString() : "null").ToString());
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
        public string Update(StoExportContract stoexport, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET SaleStaffID={0},Code={1},StoreID={2},Reason={3},Description={4},CreateDate=convert(datetime,{5},103),OrderNum={6}
                            WHERE ID=" + stoexport.Id.ToString(),
								(stoexport.Salestaffid != null? stoexport.Salestaffid.ToString() : "null").ToString(),
								(stoexport.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( stoexport.Code.ToString() ) + "'" : "null").ToString(),
								(stoexport.Storeid != null? stoexport.Storeid.ToString() : "null").ToString(),
								(stoexport.Reason.Trim() != String.Empty ? stoexport.Reason.ToString() : "null").ToString(),
								(stoexport.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( stoexport.Description.ToString() ) + "'" : "null").ToString(),
								(stoexport.Createdate != null? "'" + SQLHelper.RejectInjection( stoexport.Createdate.ToString() ) + "'" : "null").ToString(),
								(stoexport.Ordernum.Trim() != String.Empty ? stoexport.Ordernum.ToString() : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return stoexport.Id.ToString();
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