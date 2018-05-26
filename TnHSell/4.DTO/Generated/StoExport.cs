using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum StoExportColumns
    {
           ID,           
           SaleStaffID,           
           Code,           
           StoreID,           
           Reason,           
           Description,           
           CreateDate,           
           OrderNum,           
    }
    public partial class StoExportContract
    {  

    public static readonly string[] Columns = {"ID","SaleStaffID","Code","StoreID","Reason","Description","CreateDate","OrderNum",};
        public Int32 Id { get; set; }
        public Int32? Salestaffid { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        public Int32? Storeid { get; set; }
        string _reason;
        public string Reason { get {return _reason!=null?_reason:string.Empty;} set{_reason=value;} }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _createdate;
        public string Createdate { get {return _createdate!=null?_createdate:string.Empty;} set{_createdate=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
