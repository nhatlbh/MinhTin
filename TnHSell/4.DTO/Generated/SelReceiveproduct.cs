using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum SelReceiveproductColumns
    {
           ID,           
           SaleStaffID,           
           Code,           
           InvoiceID,           
           CustomerID,           
           StoreID,           
           CreateDate,           
           Description,           
           Total,           
           TotalReturn,           
           Discount,           
           OrderNum,           
    }
    public partial class SelReceiveproductContract
    {  

    public static readonly string[] Columns = {"ID","SaleStaffID","Code","InvoiceID","CustomerID","StoreID","CreateDate","Description","Total","TotalReturn","Discount","OrderNum",};
        public Int32 Id { get; set; }
        public Int32? Salestaffid { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        public Int32? Invoiceid { get; set; }
        public Int32? Customerid { get; set; }
        public Int32? Storeid { get; set; }
        string _createdate;
        public string Createdate { get {return _createdate!=null?_createdate:string.Empty;} set{_createdate=value;} }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _total;
        public string Total { get {return _total!=null?_total:string.Empty;} set{_total=value;} }
        string _totalreturn;
        public string Totalreturn { get {return _totalreturn!=null?_totalreturn:string.Empty;} set{_totalreturn=value;} }
        string _discount;
        public string Discount { get {return _discount!=null?_discount:string.Empty;} set{_discount=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
