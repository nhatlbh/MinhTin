using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum FinImportpaymentColumns
    {
           ID,           
           MoneySlipID,           
           ImportInvoiceID,           
           SupplierID,           
           Total,           
           PayDate,           
    }
    public partial class FinImportpaymentContract
    {  

    public static readonly string[] Columns = {"ID","MoneySlipID","ImportInvoiceID","SupplierID","Total","PayDate",};
        public Int32 Id { get; set; }
        public Int32? Moneyslipid { get; set; }
        public Int32? Importinvoiceid { get; set; }
        public Int32? Supplierid { get; set; }
        string _total;
        public string Total { get {return _total!=null?_total:string.Empty;} set{_total=value;} }
        string _paydate;
        public string Paydate { get {return _paydate!=null?_paydate:string.Empty;} set{_paydate=value;} }
    }
}
