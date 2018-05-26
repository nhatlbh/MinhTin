   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class CatProductDT
    {
        string TableName = "Cat_Product";
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
                            Cat_Product.ID,Cat_Product.Code,Cat_Product.Name,Cat_Product.UnitID,Cat_Product.ColorID,Cat_Product.SupplierID,Cat_Product.ManufactureID,Cat_Product.ProductTypeID,Cat_Product.ProductGroupID,Cat_Product.BranchID,Cat_Product.Description,Cat_Product.Blocked,Cat_Product.IsComponent,Cat_Product.Barcode,Cat_Product.WarningNum,Cat_Product.OrderNum 
                             , Cat_Branch.Name as Cat_Branch_Name, Cat_ProductGroup.Name as Cat_ProductGroup_Name, Cat_ProductType.Name as Cat_ProductType_Name, Cat_Supplier.Name as Cat_Supplier_Name, Cat_Color.Name as Cat_Color_Name, Cat_Unit.Name as Cat_Unit_Name, Cat_Manufacture.Name as Cat_Manufacture_Name
                            FROM " + TableName +   @" Cat_Product   Left Join Cat_Branch on  Cat_Product.BranchID = Cat_Branch.ID 
			 Left Join Cat_ProductGroup on  Cat_Product.ProductGroupID = Cat_ProductGroup.ID 
			 Left Join Cat_ProductType on  Cat_Product.ProductTypeID = Cat_ProductType.ID 
			 Left Join Cat_Supplier on  Cat_Product.SupplierID = Cat_Supplier.ID 
			 Left Join Cat_Color on  Cat_Product.ColorID = Cat_Color.ID 
			 Left Join Cat_Unit on  Cat_Product.UnitID = Cat_Unit.ID 
			 Left Join Cat_Manufacture on  Cat_Product.ManufactureID = Cat_Manufacture.ID 
			  "
                            + ") AS grd_Cat_Product  WHERE 1=1";
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
            string query = @"SELECT Cat_Product.ID,Cat_Product.Code,Cat_Product.Name,Cat_Product.UnitID,Cat_Product.ColorID,Cat_Product.SupplierID,Cat_Product.ManufactureID,Cat_Product.ProductTypeID,Cat_Product.ProductGroupID,Cat_Product.BranchID,Cat_Product.Description,Cat_Product.Blocked,Cat_Product.IsComponent,Cat_Product.Barcode,Cat_Product.WarningNum,Cat_Product.OrderNum FROM Cat_Product WHERE ID = " + id;
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
            string query = @"SELECT Cat_Product.ID,Cat_Product.Code,Cat_Product.Name,Cat_Product.UnitID,Cat_Product.ColorID,Cat_Product.SupplierID,Cat_Product.ManufactureID,Cat_Product.ProductTypeID,Cat_Product.ProductGroupID,Cat_Product.BranchID,Cat_Product.Description,Cat_Product.Blocked,Cat_Product.IsComponent,Cat_Product.Barcode,Cat_Product.WarningNum,Cat_Product.OrderNum FROM Cat_Product WHERE 1=1 ";
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
        public string Insert(CatProductContract catproduct, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Cat_Product
                                        VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14})",
								
								(catproduct.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catproduct.Code.ToString() ) + "'" : "null").ToString(),
								(catproduct.Name.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catproduct.Name.ToString() ) + "'" : "null").ToString(),
								(catproduct.Unitid != null? catproduct.Unitid.ToString() : "null").ToString(),
								(catproduct.Colorid != null? catproduct.Colorid.ToString() : "null").ToString(),
								(catproduct.Supplierid != null? catproduct.Supplierid.ToString() : "null").ToString(),
								(catproduct.Manufactureid != null? catproduct.Manufactureid.ToString() : "null").ToString(),
								(catproduct.Producttypeid != null? catproduct.Producttypeid.ToString() : "null").ToString(),
								(catproduct.Productgroupid != null? catproduct.Productgroupid.ToString() : "null").ToString(),
								(catproduct.Branchid != null? catproduct.Branchid.ToString() : "null").ToString(),
								(catproduct.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catproduct.Description.ToString() ) + "'" : "null").ToString(),
								(catproduct.Blocked != null? "'" + SQLHelper.RejectInjection( catproduct.Blocked.ToString() ) + "'" : "null").ToString(),
								(catproduct.Iscomponent != null? "'" + SQLHelper.RejectInjection( catproduct.Iscomponent.ToString() ) + "'" : "null").ToString(),
								(catproduct.Barcode.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catproduct.Barcode.ToString() ) + "'" : "null").ToString(),
								(catproduct.Warningnum.Trim() != String.Empty ? catproduct.Warningnum.ToString() : "null").ToString(),
								(catproduct.Ordernum.Trim() != String.Empty ? catproduct.Ordernum.ToString() : "null").ToString());
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
        public string Update(CatProductContract catproduct, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET Code={0},Name={1},UnitID={2},ColorID={3},SupplierID={4},ManufactureID={5},ProductTypeID={6},ProductGroupID={7},BranchID={8},Description={9},Blocked={10},IsComponent={11},Barcode={12},WarningNum={13},OrderNum={14}
                            WHERE ID=" + catproduct.Id.ToString(),
								(catproduct.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catproduct.Code.ToString() ) + "'" : "null").ToString(),
								(catproduct.Name.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catproduct.Name.ToString() ) + "'" : "null").ToString(),
								(catproduct.Unitid != null? catproduct.Unitid.ToString() : "null").ToString(),
								(catproduct.Colorid != null? catproduct.Colorid.ToString() : "null").ToString(),
								(catproduct.Supplierid != null? catproduct.Supplierid.ToString() : "null").ToString(),
								(catproduct.Manufactureid != null? catproduct.Manufactureid.ToString() : "null").ToString(),
								(catproduct.Producttypeid != null? catproduct.Producttypeid.ToString() : "null").ToString(),
								(catproduct.Productgroupid != null? catproduct.Productgroupid.ToString() : "null").ToString(),
								(catproduct.Branchid != null? catproduct.Branchid.ToString() : "null").ToString(),
								(catproduct.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catproduct.Description.ToString() ) + "'" : "null").ToString(),
								(catproduct.Blocked != null? "'" + SQLHelper.RejectInjection( catproduct.Blocked.ToString() ) + "'" : "null").ToString(),
								(catproduct.Iscomponent != null? "'" + SQLHelper.RejectInjection( catproduct.Iscomponent.ToString() ) + "'" : "null").ToString(),
								(catproduct.Barcode.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( catproduct.Barcode.ToString() ) + "'" : "null").ToString(),
								(catproduct.Warningnum.Trim() != String.Empty ? catproduct.Warningnum.ToString() : "null").ToString(),
								(catproduct.Ordernum.Trim() != String.Empty ? catproduct.Ordernum.ToString() : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return catproduct.Id.ToString();
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