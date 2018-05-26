   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class CatCustomerDT
    {
        string TableName = "Cat_Customer";
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
                            Cat_Customer.ID,Cat_Customer.Code,Cat_Customer.Name,Cat_Customer.ManagementGroupID,Cat_Customer.DistrictID,Cat_Customer.ProvinceID,Cat_Customer.SaleStaffID,convert(varchar(10),Cat_Customer.CreateDate,103) as CreateDate,Cat_Customer.Address,Cat_Customer.DiliverAddress,Cat_Customer.TaxCode,Cat_Customer.Phone,Cat_Customer.Fax,Cat_Customer.Email,Cat_Customer.Contact,Cat_Customer.ContactPhone,Cat_Customer.ContactEmail,Cat_Customer.MaxAllowedDebt,Cat_Customer.Blocked,Cat_Customer.Description,Cat_Customer.OrderNum 
                             , Cat_ManagementGroup.Name as Cat_ManagementGroup_Name, Cat_District.Name as Cat_District_Name, Cat_Province.Name as Cat_Province_Name, Cat_SaleStaff.Name as Cat_SaleStaff_Name
                            FROM " + TableName +   @" Cat_Customer   Left Join Cat_ManagementGroup on  Cat_Customer.ManagementGroupID = Cat_ManagementGroup.ID 
			 Left Join Cat_District on  Cat_Customer.DistrictID = Cat_District.ID 
			 Left Join Cat_Province on  Cat_Customer.ProvinceID = Cat_Province.ID 
			 Left Join Cat_SaleStaff on  Cat_Customer.SaleStaffID = Cat_SaleStaff.ID 
			  "
                            + ") AS grd_Cat_Customer  WHERE 1=1";
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
            string query = @"SELECT Cat_Customer.ID,Cat_Customer.Code,Cat_Customer.Name,Cat_Customer.ManagementGroupID,Cat_Customer.DistrictID,Cat_Customer.ProvinceID,Cat_Customer.SaleStaffID,convert(varchar(10),Cat_Customer.CreateDate,103) as CreateDate,Cat_Customer.Address,Cat_Customer.DiliverAddress,Cat_Customer.TaxCode,Cat_Customer.Phone,Cat_Customer.Fax,Cat_Customer.Email,Cat_Customer.Contact,Cat_Customer.ContactPhone,Cat_Customer.ContactEmail,Cat_Customer.MaxAllowedDebt,Cat_Customer.Blocked,Cat_Customer.Description,Cat_Customer.OrderNum FROM Cat_Customer WHERE ID = " + id;
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
            string query = @"SELECT Cat_Customer.ID,Cat_Customer.Code,Cat_Customer.Name,Cat_Customer.ManagementGroupID,Cat_Customer.DistrictID,Cat_Customer.ProvinceID,Cat_Customer.SaleStaffID,convert(varchar(10),Cat_Customer.CreateDate,103) as CreateDate,Cat_Customer.Address,Cat_Customer.DiliverAddress,Cat_Customer.TaxCode,Cat_Customer.Phone,Cat_Customer.Fax,Cat_Customer.Email,Cat_Customer.Contact,Cat_Customer.ContactPhone,Cat_Customer.ContactEmail,Cat_Customer.MaxAllowedDebt,Cat_Customer.Blocked,Cat_Customer.Description,Cat_Customer.OrderNum FROM Cat_Customer WHERE 1=1 ";
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
        public string Insert(CatCustomerContract catcustomer, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Cat_Customer
                                        VALUES ({0},{1},{2},{3},{4},{5},convert(datetime,{6},103),{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19})",
								
								(catcustomer.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Code.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Name.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Name.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Managementgroupid != null? catcustomer.Managementgroupid.ToString() : "null").ToString(),
								(catcustomer.Districtid != null? catcustomer.Districtid.ToString() : "null").ToString(),
								(catcustomer.Provinceid != null? catcustomer.Provinceid.ToString() : "null").ToString(),
								(catcustomer.Salestaffid != null? catcustomer.Salestaffid.ToString() : "null").ToString(),
								(catcustomer.Createdate != null? "'" + SQLHelper.RejectInjection( catcustomer.Createdate.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Address.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Address.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Diliveraddress.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Diliveraddress.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Taxcode.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Taxcode.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Phone.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Phone.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Fax.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Fax.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Email.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Email.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Contact.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Contact.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Contactphone.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Contactphone.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Contactemail.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Contactemail.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Maxalloweddebt.Trim() != String.Empty ? catcustomer.Maxalloweddebt.ToString() : "null").ToString(),
								(catcustomer.Blocked != null? "'" + SQLHelper.RejectInjection( catcustomer.Blocked.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Description.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Ordernum.Trim() != String.Empty ? catcustomer.Ordernum.ToString() : "null").ToString());
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
        public string Update(CatCustomerContract catcustomer, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET Code={0},Name={1},ManagementGroupID={2},DistrictID={3},ProvinceID={4},SaleStaffID={5},CreateDate=convert(datetime,{6},103),Address={7},DiliverAddress={8},TaxCode={9},Phone={10},Fax={11},Email={12},Contact={13},ContactPhone={14},ContactEmail={15},MaxAllowedDebt={16},Blocked={17},Description={18},OrderNum={19}
                            WHERE ID=" + catcustomer.Id.ToString(),
								(catcustomer.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Code.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Name.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Name.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Managementgroupid != null? catcustomer.Managementgroupid.ToString() : "null").ToString(),
								(catcustomer.Districtid != null? catcustomer.Districtid.ToString() : "null").ToString(),
								(catcustomer.Provinceid != null? catcustomer.Provinceid.ToString() : "null").ToString(),
								(catcustomer.Salestaffid != null? catcustomer.Salestaffid.ToString() : "null").ToString(),
								(catcustomer.Createdate != null? "'" + SQLHelper.RejectInjection( catcustomer.Createdate.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Address.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Address.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Diliveraddress.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Diliveraddress.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Taxcode.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Taxcode.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Phone.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Phone.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Fax.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Fax.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Email.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Email.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Contact.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Contact.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Contactphone.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Contactphone.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Contactemail.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Contactemail.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Maxalloweddebt.Trim() != String.Empty ? catcustomer.Maxalloweddebt.ToString() : "null").ToString(),
								(catcustomer.Blocked != null? "'" + SQLHelper.RejectInjection( catcustomer.Blocked.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catcustomer.Description.ToString() ) + "'" : "null").ToString(),
								(catcustomer.Ordernum.Trim() != String.Empty ? catcustomer.Ordernum.ToString() : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return catcustomer.Id.ToString();
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