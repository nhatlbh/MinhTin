   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class CatSalestaffDT
    {
        string TableName = "Cat_SaleStaff";
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
                            Cat_SaleStaff.ID,Cat_SaleStaff.Code,Cat_SaleStaff.Name,Cat_SaleStaff.BranchID,Cat_SaleStaff.UserID,Cat_SaleStaff.Address,Cat_SaleStaff.Phone,Cat_SaleStaff.Email,Cat_SaleStaff.Mobile,Cat_SaleStaff.SocialNum,Cat_SaleStaff.Sex,convert(varchar(10),Cat_SaleStaff.BirthDate,103) as BirthDate,Cat_SaleStaff.IsQuit,Cat_SaleStaff.Description,Cat_SaleStaff.OrderNum 
                             , Cat_Branch.Name as Cat_Branch_Name, Adm_User.Name as Adm_User_Name
                            FROM " + TableName +   @" Cat_SaleStaff   Left Join Cat_Branch on  Cat_SaleStaff.BranchID = Cat_Branch.ID 
			 Left Join Adm_User on  Cat_SaleStaff.UserID = Adm_User.ID 
			  "
                            + ") AS grd_Cat_SaleStaff  WHERE 1=1";
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
            string query = @"SELECT Cat_SaleStaff.ID,Cat_SaleStaff.Code,Cat_SaleStaff.Name,Cat_SaleStaff.BranchID,Cat_SaleStaff.UserID,Cat_SaleStaff.Address,Cat_SaleStaff.Phone,Cat_SaleStaff.Email,Cat_SaleStaff.Mobile,Cat_SaleStaff.SocialNum,Cat_SaleStaff.Sex,convert(varchar(10),Cat_SaleStaff.BirthDate,103) as BirthDate,Cat_SaleStaff.IsQuit,Cat_SaleStaff.Description,Cat_SaleStaff.OrderNum FROM Cat_SaleStaff WHERE ID = " + id;
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
            string query = @"SELECT Cat_SaleStaff.ID,Cat_SaleStaff.Code,Cat_SaleStaff.Name,Cat_SaleStaff.BranchID,Cat_SaleStaff.UserID,Cat_SaleStaff.Address,Cat_SaleStaff.Phone,Cat_SaleStaff.Email,Cat_SaleStaff.Mobile,Cat_SaleStaff.SocialNum,Cat_SaleStaff.Sex,convert(varchar(10),Cat_SaleStaff.BirthDate,103) as BirthDate,Cat_SaleStaff.IsQuit,Cat_SaleStaff.Description,Cat_SaleStaff.OrderNum FROM Cat_SaleStaff WHERE 1=1 ";
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
        public string Insert(CatSalestaffContract catsalestaff, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Cat_SaleStaff
                                        VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},convert(datetime,{10},103),{11},{12},{13})",
								
								(catsalestaff.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Code.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Name.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Name.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Branchid != null? catsalestaff.Branchid.ToString() : "null").ToString(),
								(catsalestaff.Userid != null? catsalestaff.Userid.ToString() : "null").ToString(),
								(catsalestaff.Address.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Address.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Phone.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Phone.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Email.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Email.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Mobile.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Mobile.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Socialnum.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Socialnum.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Sex.Trim() != String.Empty ? catsalestaff.Sex.ToString() : "null").ToString(),
								(catsalestaff.Birthdate != null? "'" + SQLHelper.RejectInjection( catsalestaff.Birthdate.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Isquit != null? "'" + SQLHelper.RejectInjection( catsalestaff.Isquit.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Description.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Ordernum.Trim() != String.Empty ? catsalestaff.Ordernum.ToString() : "null").ToString());
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
        public string Update(CatSalestaffContract catsalestaff, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET Code={0},Name={1},BranchID={2},UserID={3},Address={4},Phone={5},Email={6},Mobile={7},SocialNum={8},Sex={9},BirthDate=convert(datetime,{10},103),IsQuit={11},Description={12},OrderNum={13}
                            WHERE ID=" + catsalestaff.Id.ToString(),
								(catsalestaff.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Code.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Name.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Name.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Branchid != null? catsalestaff.Branchid.ToString() : "null").ToString(),
								(catsalestaff.Userid != null? catsalestaff.Userid.ToString() : "null").ToString(),
								(catsalestaff.Address.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Address.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Phone.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Phone.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Email.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Email.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Mobile.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Mobile.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Socialnum.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Socialnum.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Sex.Trim() != String.Empty ? catsalestaff.Sex.ToString() : "null").ToString(),
								(catsalestaff.Birthdate != null? "'" + SQLHelper.RejectInjection( catsalestaff.Birthdate.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Isquit != null? "'" + SQLHelper.RejectInjection( catsalestaff.Isquit.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsalestaff.Description.ToString() ) + "'" : "null").ToString(),
								(catsalestaff.Ordernum.Trim() != String.Empty ? catsalestaff.Ordernum.ToString() : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return catsalestaff.Id.ToString();
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