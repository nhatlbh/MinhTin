   
using System;
using System.Data;
using System.Data.SqlClient;
using TnHSell.DTContract;
using DTA;
using Util;
namespace TnHSell.DT
{
    public partial class CusConversationDT
    {
        string TableName = "Cus_Conversation";
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
                            Cus_Conversation.ID,Cus_Conversation.Code,Cus_Conversation.Title,Cus_Conversation.SaleStaffID,Cus_Conversation.CustomerID,Cus_Conversation.Conv_Content,Cus_Conversation.ChanelID,Cus_Conversation.ConvResultID,convert(varchar(10),Cus_Conversation.CreatedOn,103) as CreatedOn,Cus_Conversation.Note,Cus_Conversation.OrderNum 
                             , Cat_SaleStaff.Name as Cat_SaleStaff_Name, Cat_ConvResult.Name as Cat_ConvResult_Name, Cat_Chanel.Name as Cat_Chanel_Name, Cat_Customer.Name as Cat_Customer_Name
                            FROM " + TableName +   @" Cus_Conversation   Left Join Cat_SaleStaff on  Cus_Conversation.SaleStaffID = Cat_SaleStaff.ID 
			 Left Join Cat_ConvResult on  Cus_Conversation.ConvResultID = Cat_ConvResult.ID 
			 Left Join Cat_Chanel on  Cus_Conversation.ChanelID = Cat_Chanel.ID 
			 Left Join Cat_Customer on  Cus_Conversation.CustomerID = Cat_Customer.ID 
			  "
                            + ") AS grd_Cus_Conversation  WHERE 1=1";
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
            string query = @"SELECT Cus_Conversation.ID,Cus_Conversation.Code,Cus_Conversation.Title,Cus_Conversation.SaleStaffID,Cus_Conversation.CustomerID,Cus_Conversation.Conv_Content,Cus_Conversation.ChanelID,Cus_Conversation.ConvResultID,convert(varchar(10),Cus_Conversation.CreatedOn,103) as CreatedOn,Cus_Conversation.Note,Cus_Conversation.OrderNum FROM Cus_Conversation WHERE ID = " + id;
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
            string query = @"SELECT Cus_Conversation.ID,Cus_Conversation.Code,Cus_Conversation.Title,Cus_Conversation.SaleStaffID,Cus_Conversation.CustomerID,Cus_Conversation.Conv_Content,Cus_Conversation.ChanelID,Cus_Conversation.ConvResultID,convert(varchar(10),Cus_Conversation.CreatedOn,103) as CreatedOn,Cus_Conversation.Note,Cus_Conversation.OrderNum FROM Cus_Conversation WHERE 1=1 ";
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
        public string Insert(CusConversationContract cusconversation, SqlTransaction  tran = null)
        {
            DataTable dtResult = null;
            string query = string.Format(@"INSERT INTO Cus_Conversation
                                        VALUES ({0},{1},{2},{3},{4},{5},{6},convert(datetime,{7},103),{8},{9})",
								
								(cusconversation.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( cusconversation.Code.ToString() ) + "'" : "null").ToString(),
								(cusconversation.Title.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( cusconversation.Title.ToString() ) + "'" : "null").ToString(),
								(cusconversation.Salestaffid != null? cusconversation.Salestaffid.ToString() : "null").ToString(),
								(cusconversation.Customerid != null? cusconversation.Customerid.ToString() : "null").ToString(),
								(cusconversation.ConvContent.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( cusconversation.ConvContent.ToString() ) + "'" : "null").ToString(),
								(cusconversation.Chanelid != null? cusconversation.Chanelid.ToString() : "null").ToString(),
								(cusconversation.Convresultid != null? cusconversation.Convresultid.ToString() : "null").ToString(),
								(cusconversation.Createdon != null? "'" + SQLHelper.RejectInjection( cusconversation.Createdon.ToString() ) + "'" : "null").ToString(),
								(cusconversation.Note.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( cusconversation.Note.ToString() ) + "'" : "null").ToString(),
								(cusconversation.Ordernum.Trim() != String.Empty ? cusconversation.Ordernum.ToString() : "null").ToString());
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
        public string Update(CusConversationContract cusconversation, SqlTransaction  tran = null)
        {
            string query = String.Format("UPDATE " + TableName + @" SET Code={0},Title={1},SaleStaffID={2},CustomerID={3},Conv_Content={4},ChanelID={5},ConvResultID={6},CreatedOn=convert(datetime,{7},103),Note={8},OrderNum={9}
                            WHERE ID=" + cusconversation.Id.ToString(),
								(cusconversation.Code.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( cusconversation.Code.ToString() ) + "'" : "null").ToString(),
								(cusconversation.Title.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( cusconversation.Title.ToString() ) + "'" : "null").ToString(),
								(cusconversation.Salestaffid != null? cusconversation.Salestaffid.ToString() : "null").ToString(),
								(cusconversation.Customerid != null? cusconversation.Customerid.ToString() : "null").ToString(),
								(cusconversation.ConvContent.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( cusconversation.ConvContent.ToString() ) + "'" : "null").ToString(),
								(cusconversation.Chanelid != null? cusconversation.Chanelid.ToString() : "null").ToString(),
								(cusconversation.Convresultid != null? cusconversation.Convresultid.ToString() : "null").ToString(),
								(cusconversation.Createdon != null? "'" + SQLHelper.RejectInjection( cusconversation.Createdon.ToString() ) + "'" : "null").ToString(),
								(cusconversation.Note.Trim() != String.Empty? "N'" + SQLHelper.RejectInjection( cusconversation.Note.ToString() ) + "'" : "null").ToString(),
								(cusconversation.Ordernum.Trim() != String.Empty ? cusconversation.Ordernum.ToString() : "null").ToString());                                               
            if (tran == null)
            {
                DataProvider.ExecuteNonQuery(query);
            }
            else
            {
                DataProvider.ExecuteNonQueryWithTransaction(query, tran);
            }
            return cusconversation.Id.ToString();
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