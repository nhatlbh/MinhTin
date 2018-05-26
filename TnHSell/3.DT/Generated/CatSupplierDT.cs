   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class CatSupplierDT
    {
        string TableName = "Cat_Supplier";
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
                            Cat_Supplier.ID,Cat_Supplier.Code,Cat_Supplier.Name,Cat_Supplier.Address,Cat_Supplier.TaxCode,Cat_Supplier.Phone,Cat_Supplier.Fax,Cat_Supplier.Email,Cat_Supplier.Contact,Cat_Supplier.ContactPhone,Cat_Supplier.ContactEmail,Cat_Supplier.MaxAllowedDebt,Cat_Supplier.Blocked,Cat_Supplier.Description,Cat_Supplier.OrderNum 
                            
                            FROM " + TableName +   @" Cat_Supplier    "
                            + ") AS grd_Cat_Supplier  WHERE 1=1";
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
            string query = @"SELECT Cat_Supplier.ID,Cat_Supplier.Code,Cat_Supplier.Name,Cat_Supplier.Address,Cat_Supplier.TaxCode,Cat_Supplier.Phone,Cat_Supplier.Fax,Cat_Supplier.Email,Cat_Supplier.Contact,Cat_Supplier.ContactPhone,Cat_Supplier.ContactEmail,Cat_Supplier.MaxAllowedDebt,Cat_Supplier.Blocked,Cat_Supplier.Description,Cat_Supplier.OrderNum FROM Cat_Supplier WHERE ID = " + id;
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
            string query = @"SELECT Cat_Supplier.ID,Cat_Supplier.Code,Cat_Supplier.Name,Cat_Supplier.Address,Cat_Supplier.TaxCode,Cat_Supplier.Phone,Cat_Supplier.Fax,Cat_Supplier.Email,Cat_Supplier.Contact,Cat_Supplier.ContactPhone,Cat_Supplier.ContactEmail,Cat_Supplier.MaxAllowedDebt,Cat_Supplier.Blocked,Cat_Supplier.Description,Cat_Supplier.OrderNum FROM Cat_Supplier WHERE 1=1 ";
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
        public string Insert(CatSupplierContract catsupplier, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Cat_Supplier
                                        VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13})",
								
								(catsupplier.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Code.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Name.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Name.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Address.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Address.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Taxcode.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Taxcode.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Phone.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Phone.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Fax.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Fax.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Email.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Email.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Contact.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Contact.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Contactphone.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Contactphone.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Contactemail.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Contactemail.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Maxalloweddebt.Trim() != String.Empty ? catsupplier.Maxalloweddebt.ToString() : "null").ToString(),
								(catsupplier.Blocked != null? "'" + SQLHelper.RejectInjection( catsupplier.Blocked.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Description.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Ordernum.Trim() != String.Empty ? catsupplier.Ordernum.ToString() : "null").ToString());
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
        public string Update(CatSupplierContract catsupplier, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET Code={0},Name={1},Address={2},TaxCode={3},Phone={4},Fax={5},Email={6},Contact={7},ContactPhone={8},ContactEmail={9},MaxAllowedDebt={10},Blocked={11},Description={12},OrderNum={13}
                            WHERE ID=" + catsupplier.Id.ToString(),
								(catsupplier.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Code.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Name.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Name.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Address.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Address.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Taxcode.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Taxcode.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Phone.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Phone.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Fax.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Fax.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Email.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Email.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Contact.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Contact.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Contactphone.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Contactphone.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Contactemail.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Contactemail.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Maxalloweddebt.Trim() != String.Empty ? catsupplier.Maxalloweddebt.ToString() : "null").ToString(),
								(catsupplier.Blocked != null? "'" + SQLHelper.RejectInjection( catsupplier.Blocked.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catsupplier.Description.ToString() ) + "'" : "null").ToString(),
								(catsupplier.Ordernum.Trim() != String.Empty ? catsupplier.Ordernum.ToString() : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return catsupplier.Id.ToString();
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