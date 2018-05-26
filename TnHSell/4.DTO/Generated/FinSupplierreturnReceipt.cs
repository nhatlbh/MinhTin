using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum FinSupplierreturnReceiptColumns
    {
           ID,           
           ReceiptID,           
           SupplierReturnID,           
           SupplierID,           
           Total,           
           IncomeDate,           
    }
    public partial class FinSupplierreturnReceiptContract
    {  

    public static readonly string[] Columns = {"ID","ReceiptID","SupplierReturnID","SupplierID","Total","IncomeDate",};
        public Int32 Id { get; set; }
        public Int32? Receiptid { get; set; }
        public Int32? Supplierreturnid { get; set; }
        public Int32? Supplierid { get; set; }
        string _total;
        public string Total { get {return _total!=null?_total:string.Empty;} set{_total=value;} }
        string _incomedate;
        public string Incomedate { get {return _incomedate!=null?_incomedate:string.Empty;} set{_incomedate=value;} }
    }
}
