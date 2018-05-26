using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum CusConversationColumns
    {
           ID,           
           Code,           
           Title,           
           SaleStaffID,           
           CustomerID,           
           Conv_Content,           
           ChanelID,           
           ConvResultID,           
           CreatedOn,           
           Note,           
           OrderNum,           
    }
    public partial class CusConversationContract
    {  

    public static readonly string[] Columns = {"ID","Code","Title","SaleStaffID","CustomerID","Conv_Content","ChanelID","ConvResultID","CreatedOn","Note","OrderNum",};
        public Int32 Id { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        string _title;
        public string Title { get {return _title!=null?_title:string.Empty;} set{_title=value;} }
        public Int32? Salestaffid { get; set; }
        public Int32? Customerid { get; set; }
        string _convContent;
        public string ConvContent { get {return _convContent!=null?_convContent:string.Empty;} set{_convContent=value;} }
        public Int32? Chanelid { get; set; }
        public Int32? Convresultid { get; set; }
        string _createdon;
        public string Createdon { get {return _createdon!=null?_createdon:string.Empty;} set{_createdon=value;} }
        string _note;
        public string Note { get {return _note!=null?_note:string.Empty;} set{_note=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
