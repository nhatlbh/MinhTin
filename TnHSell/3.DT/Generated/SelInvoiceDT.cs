   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class SelInvoiceDT
    {
        string TableName = "Sel_Invoice";
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
                            Sel_Invoice.ID,Sel_Invoice.SaleStaffID,Sel_Invoice.Code,Sel_Invoice.StoreID,Sel_Invoice.CustomerID,Sel_Invoice.IOCodeID,Sel_Invoice.DeliveryAddress,Sel_Invoice.FinanceFileNum,Sel_Invoice.FileNum,Sel_Invoice.ReceiptNum,convert(varchar(10),Sel_Invoice.IncomeDate,103) as IncomeDate,Sel_Invoice.Description,Sel_Invoice.PercentDiscount,Sel_Invoice.ValueDiscount,Sel_Invoice.TotalDiscount,Sel_Invoice.Total,Sel_Invoice.TotalDebt,Sel_Invoice.OrderNum,Sel_Invoice.IsDelivered,convert(varchar(10),Sel_Invoice.DeliverDate,103) as DeliverDate,convert(varchar(10),Sel_Invoice.CreateDate,103) as CreateDate 
                             , Cat_Store.Name as Cat_Store_Name, Cat_Customer.Name as Cat_Customer_Name, Cat_IOCode.Name as Cat_IOCode_Name, Cat_SaleStaff.Name as Cat_SaleStaff_Name
                            FROM " + TableName +   @" Sel_Invoice   Left Join Cat_Store on  Sel_Invoice.StoreID = Cat_Store.ID 
			 Left Join Cat_Customer on  Sel_Invoice.CustomerID = Cat_Customer.ID 
			 Left Join Cat_IOCode on  Sel_Invoice.IOCodeID = Cat_IOCode.ID 
			 Left Join Cat_SaleStaff on  Sel_Invoice.SaleStaffID = Cat_SaleStaff.ID 
			  "
                            + ") AS grd_Sel_Invoice  WHERE 1=1";
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
            string query = @"SELECT Sel_Invoice.ID,Sel_Invoice.SaleStaffID,Sel_Invoice.Code,Sel_Invoice.StoreID,Sel_Invoice.CustomerID,Sel_Invoice.IOCodeID,Sel_Invoice.DeliveryAddress,Sel_Invoice.FinanceFileNum,Sel_Invoice.FileNum,Sel_Invoice.ReceiptNum,convert(varchar(10),Sel_Invoice.IncomeDate,103) as IncomeDate,Sel_Invoice.Description,Sel_Invoice.PercentDiscount,Sel_Invoice.ValueDiscount,Sel_Invoice.TotalDiscount,Sel_Invoice.Total,Sel_Invoice.TotalDebt,Sel_Invoice.OrderNum,Sel_Invoice.IsDelivered,convert(varchar(10),Sel_Invoice.DeliverDate,103) as DeliverDate,convert(varchar(10),Sel_Invoice.CreateDate,103) as CreateDate FROM Sel_Invoice WHERE ID = " + id;
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
            string query = @"SELECT Sel_Invoice.ID,Sel_Invoice.SaleStaffID,Sel_Invoice.Code,Sel_Invoice.StoreID,Sel_Invoice.CustomerID,Sel_Invoice.IOCodeID,Sel_Invoice.DeliveryAddress,Sel_Invoice.FinanceFileNum,Sel_Invoice.FileNum,Sel_Invoice.ReceiptNum,convert(varchar(10),Sel_Invoice.IncomeDate,103) as IncomeDate,Sel_Invoice.Description,Sel_Invoice.PercentDiscount,Sel_Invoice.ValueDiscount,Sel_Invoice.TotalDiscount,Sel_Invoice.Total,Sel_Invoice.TotalDebt,Sel_Invoice.OrderNum,Sel_Invoice.IsDelivered,convert(varchar(10),Sel_Invoice.DeliverDate,103) as DeliverDate,convert(varchar(10),Sel_Invoice.CreateDate,103) as CreateDate FROM Sel_Invoice WHERE 1=1 ";
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
        public string Insert(SelInvoiceContract selinvoice, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Sel_Invoice
                                        VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},convert(datetime,{9},103),{10},{11},{12},{13},{14},{15},{16},{17},convert(datetime,{18},103),convert(datetime,{19},103))",
								
								(selinvoice.Salestaffid != null? selinvoice.Salestaffid.ToString() : "null").ToString(),
								(selinvoice.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selinvoice.Code.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Storeid != null? selinvoice.Storeid.ToString() : "null").ToString(),
								(selinvoice.Customerid != null? selinvoice.Customerid.ToString() : "null").ToString(),
								(selinvoice.Iocodeid != null? selinvoice.Iocodeid.ToString() : "null").ToString(),
								(selinvoice.Deliveryaddress.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selinvoice.Deliveryaddress.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Financefilenum.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selinvoice.Financefilenum.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Filenum.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selinvoice.Filenum.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Receiptnum.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selinvoice.Receiptnum.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Incomedate != null? "'" + SQLHelper.RejectInjection( selinvoice.Incomedate.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selinvoice.Description.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Percentdiscount.Trim() != String.Empty ? selinvoice.Percentdiscount.ToString() : "null").ToString(),
								(selinvoice.Valuediscount.Trim() != String.Empty ? selinvoice.Valuediscount.ToString() : "null").ToString(),
								(selinvoice.Totaldiscount.Trim() != String.Empty ? selinvoice.Totaldiscount.ToString() : "null").ToString(),
								(selinvoice.Total.Trim() != String.Empty ? selinvoice.Total.ToString() : "null").ToString(),
								(selinvoice.Totaldebt.Trim() != String.Empty ? selinvoice.Totaldebt.ToString() : "null").ToString(),
								(selinvoice.Ordernum.Trim() != String.Empty ? selinvoice.Ordernum.ToString() : "null").ToString(),
								(selinvoice.Isdelivered != null? "'" + SQLHelper.RejectInjection( selinvoice.Isdelivered.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Deliverdate != null? "'" + SQLHelper.RejectInjection( selinvoice.Deliverdate.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Createdate != null? "'" + SQLHelper.RejectInjection( selinvoice.Createdate.ToString() ) + "'" : "null").ToString());
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
        public string Update(SelInvoiceContract selinvoice, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET SaleStaffID={0},Code={1},StoreID={2},CustomerID={3},IOCodeID={4},DeliveryAddress={5},FinanceFileNum={6},FileNum={7},ReceiptNum={8},IncomeDate=convert(datetime,{9},103),Description={10},PercentDiscount={11},ValueDiscount={12},TotalDiscount={13},Total={14},TotalDebt={15},OrderNum={16},IsDelivered={17},DeliverDate=convert(datetime,{18},103),CreateDate=convert(datetime,{19},103)
                            WHERE ID=" + selinvoice.Id.ToString(),
								(selinvoice.Salestaffid != null? selinvoice.Salestaffid.ToString() : "null").ToString(),
								(selinvoice.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selinvoice.Code.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Storeid != null? selinvoice.Storeid.ToString() : "null").ToString(),
								(selinvoice.Customerid != null? selinvoice.Customerid.ToString() : "null").ToString(),
								(selinvoice.Iocodeid != null? selinvoice.Iocodeid.ToString() : "null").ToString(),
								(selinvoice.Deliveryaddress.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selinvoice.Deliveryaddress.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Financefilenum.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selinvoice.Financefilenum.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Filenum.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selinvoice.Filenum.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Receiptnum.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selinvoice.Receiptnum.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Incomedate != null? "'" + SQLHelper.RejectInjection( selinvoice.Incomedate.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Description.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( selinvoice.Description.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Percentdiscount.Trim() != String.Empty ? selinvoice.Percentdiscount.ToString() : "null").ToString(),
								(selinvoice.Valuediscount.Trim() != String.Empty ? selinvoice.Valuediscount.ToString() : "null").ToString(),
								(selinvoice.Totaldiscount.Trim() != String.Empty ? selinvoice.Totaldiscount.ToString() : "null").ToString(),
								(selinvoice.Total.Trim() != String.Empty ? selinvoice.Total.ToString() : "null").ToString(),
								(selinvoice.Totaldebt.Trim() != String.Empty ? selinvoice.Totaldebt.ToString() : "null").ToString(),
								(selinvoice.Ordernum.Trim() != String.Empty ? selinvoice.Ordernum.ToString() : "null").ToString(),
								(selinvoice.Isdelivered != null? "'" + SQLHelper.RejectInjection( selinvoice.Isdelivered.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Deliverdate != null? "'" + SQLHelper.RejectInjection( selinvoice.Deliverdate.ToString() ) + "'" : "null").ToString(),
								(selinvoice.Createdate != null? "'" + SQLHelper.RejectInjection( selinvoice.Createdate.ToString() ) + "'" : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return selinvoice.Id.ToString();
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