using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum BuySupplierreturnColumns
    {
           ID,           
           SaleStaffID,           
           Code,           
           ImportInvoiceID,           
           SupplierID,           
           CreateDate,           
           Description,           
           TotalDebt,           
           OrderNum,           
    }
    public partial class BuySupplierreturnContract
    {  

    public static readonly string[] Columns = {"ID","SaleStaffID","Code","ImportInvoiceID","SupplierID","CreateDate","Description","TotalDebt","OrderNum",};
        public Int32 Id { get; set; }
        public Int32? Salestaffid { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        public Int32? Importinvoiceid { get; set; }
        public Int32? Supplierid { get; set; }
        string _createdate;
        public string Createdate { get {return _createdate!=null?_createdate:string.Empty;} set{_createdate=value;} }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _totaldebt;
        public string Totaldebt { get {return _totaldebt!=null?_totaldebt:string.Empty;} set{_totaldebt=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
