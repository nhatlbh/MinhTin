   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class AdmUserDT
    {
        string TableName = "Adm_User";
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
                            Adm_User.ID,Adm_User.Code,Adm_User.Name,Adm_User.Password,Adm_User.Description,convert(varchar(10),Adm_User.CreateDate,103) as CreateDate,convert(varchar(10),Adm_User.ExpireDate,103) as ExpireDate,Adm_User.SiteMap,Adm_User.Disabled,Adm_User.OrderNum 
                            
                            FROM " + TableName +   @" Adm_User    "
                            + ") AS grd_Adm_User  WHERE 1=1";
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
            string query = @"SELECT Adm_User.ID,Adm_User.Code,Adm_User.Name,Adm_User.Password,Adm_User.Description,convert(varchar(10),Adm_User.CreateDate,103) as CreateDate,convert(varchar(10),Adm_User.ExpireDate,103) as ExpireDate,Adm_User.SiteMap,Adm_User.Disabled,Adm_User.OrderNum FROM Adm_User WHERE ID = " + id;
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
            string query = @"SELECT Adm_User.ID,Adm_User.Code,Adm_User.Name,Adm_User.Password,Adm_User.Description,convert(varchar(10),Adm_User.CreateDate,103) as CreateDate,convert(varchar(10),Adm_User.ExpireDate,103) as ExpireDate,Adm_User.SiteMap,Adm_User.Disabled,Adm_User.OrderNum FROM Adm_User WHERE 1=1 ";
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
        public string Insert(AdmUserContract admuser, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Adm_User
                                        VALUES ({0},{1},{2},{3},convert(datetime,{4},103),convert(datetime,{5},103),{6},{7},{8})",
								
								(admuser.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( admuser.Code.ToString() ) + "'" : "null").ToString(),
								(admuser.Name.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( admuser.Name.ToString() ) + "'" : "null").ToString(),
								(admuser.Password.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( admuser.Password.ToString() ) + "'" : "null").ToString(),
								(admuser.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( admuser.Description.ToString() ) + "'" : "null").ToString(),
								(admuser.Createdate != null? "'" + SQLHelper.RejectInjection( admuser.Createdate.ToString() ) + "'" : "null").ToString(),
								(admuser.Expiredate != null? "'" + SQLHelper.RejectInjection( admuser.Expiredate.ToString() ) + "'" : "null").ToString(),
								(admuser.Sitemap.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( admuser.Sitemap.ToString() ) + "'" : "null").ToString(),
								(admuser.Disabled != null? "'" + SQLHelper.RejectInjection( admuser.Disabled.ToString() ) + "'" : "null").ToString(),
								(admuser.Ordernum.Trim() != String.Empty ? admuser.Ordernum.ToString() : "null").ToString());
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
        public string Update(AdmUserContract admuser, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET Code={0},Name={1},Password={2},Description={3},CreateDate=convert(datetime,{4},103),ExpireDate=convert(datetime,{5},103),SiteMap={6},Disabled={7},OrderNum={8}
                            WHERE ID=" + admuser.Id.ToString(),
								(admuser.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( admuser.Code.ToString() ) + "'" : "null").ToString(),
								(admuser.Name.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( admuser.Name.ToString() ) + "'" : "null").ToString(),
								(admuser.Password.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( admuser.Password.ToString() ) + "'" : "null").ToString(),
								(admuser.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( admuser.Description.ToString() ) + "'" : "null").ToString(),
								(admuser.Createdate != null? "'" + SQLHelper.RejectInjection( admuser.Createdate.ToString() ) + "'" : "null").ToString(),
								(admuser.Expiredate != null? "'" + SQLHelper.RejectInjection( admuser.Expiredate.ToString() ) + "'" : "null").ToString(),
								(admuser.Sitemap.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( admuser.Sitemap.ToString() ) + "'" : "null").ToString(),
								(admuser.Disabled != null? "'" + SQLHelper.RejectInjection( admuser.Disabled.ToString() ) + "'" : "null").ToString(),
								(admuser.Ordernum.Trim() != String.Empty ? admuser.Ordernum.ToString() : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return admuser.Id.ToString();
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