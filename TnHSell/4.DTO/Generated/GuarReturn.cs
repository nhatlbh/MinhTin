using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum GuarReturnColumns
    {
           ID,           
           SaleStaffID,           
           CustomerID,           
           GuaranteeID,           
           Code,           
           CreateDate,           
           Description,           
           OrderNum,           
    }
    public partial class GuarReturnContract
    {  

    public static readonly string[] Columns = {"ID","SaleStaffID","CustomerID","GuaranteeID","Code","CreateDate","Description","OrderNum",};
        public Int32 Id { get; set; }
        public Int32? Salestaffid { get; set; }
        public Int32? Customerid { get; set; }
        public Int32? Guaranteeid { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        string _createdate;
        public string Createdate { get {return _createdate!=null?_createdate:string.Empty;} set{_createdate=value;} }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
