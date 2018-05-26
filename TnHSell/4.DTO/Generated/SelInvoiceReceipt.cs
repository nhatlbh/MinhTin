using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum SelInvoiceReceiptColumns
    {
           ID,           
           ReceiptID,           
           InvoiceID,           
           CustomerID,           
           Total,           
           IncomeDate,           
    }
    public partial class SelInvoiceReceiptContract
    {  

    public static readonly string[] Columns = {"ID","ReceiptID","InvoiceID","CustomerID","Total","IncomeDate",};
        public Int32 Id { get; set; }
        public Int32? Receiptid { get; set; }
        public Int32? Invoiceid { get; set; }
        public Int32? Customerid { get; set; }
        string _total;
        public string Total { get {return _total!=null?_total:string.Empty;} set{_total=value;} }
        string _incomedate;
        public string Incomedate { get {return _incomedate!=null?_incomedate:string.Empty;} set{_incomedate=value;} }
    }
}
