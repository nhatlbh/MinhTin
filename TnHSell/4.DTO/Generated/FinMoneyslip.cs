using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum FinMoneyslipColumns
    {
           ID,           
           SaleStaffID,           
           Code,           
           PaymentTypeID,           
           TotalPay,           
           CreateDate,           
           Description,           
           Type,           
           OrderNum,           
    }
    public partial class FinMoneyslipContract
    {  

    public static readonly string[] Columns = {"ID","SaleStaffID","Code","PaymentTypeID","TotalPay","CreateDate","Description","Type","OrderNum",};
        public Int32 Id { get; set; }
        public Int32? Salestaffid { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        public Int32? Paymenttypeid { get; set; }
        string _totalpay;
        public string Totalpay { get {return _totalpay!=null?_totalpay:string.Empty;} set{_totalpay=value;} }
        string _createdate;
        public string Createdate { get {return _createdate!=null?_createdate:string.Empty;} set{_createdate=value;} }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _type;
        public string Type { get {return _type!=null?_type:string.Empty;} set{_type=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
