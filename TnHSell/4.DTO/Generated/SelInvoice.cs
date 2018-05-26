using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum SelInvoiceColumns
    {
           ID,           
           SaleStaffID,           
           Code,           
           StoreID,           
           CustomerID,           
           IOCodeID,           
           DeliveryAddress,           
           FinanceFileNum,           
           FileNum,           
           ReceiptNum,           
           IncomeDate,           
           Description,           
           PercentDiscount,           
           ValueDiscount,           
           TotalDiscount,           
           Total,           
           TotalDebt,           
           OrderNum,           
           IsDelivered,           
           DeliverDate,           
           CreateDate,           
    }
    public partial class SelInvoiceContract
    {  

    public static readonly string[] Columns = {"ID","SaleStaffID","Code","StoreID","CustomerID","IOCodeID","DeliveryAddress","FinanceFileNum","FileNum","ReceiptNum","IncomeDate","Description","PercentDiscount","ValueDiscount","TotalDiscount","Total","TotalDebt","OrderNum","IsDelivered","DeliverDate","CreateDate",};
        public Int32 Id { get; set; }
        public Int32? Salestaffid { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        public Int32? Storeid { get; set; }
        public Int32? Customerid { get; set; }
        public Int32? Iocodeid { get; set; }
        string _deliveryaddress;
        public string Deliveryaddress { get {return _deliveryaddress!=null?_deliveryaddress:string.Empty;} set{_deliveryaddress=value;} }
        string _financefilenum;
        public string Financefilenum { get {return _financefilenum!=null?_financefilenum:string.Empty;} set{_financefilenum=value;} }
        string _filenum;
        public string Filenum { get {return _filenum!=null?_filenum:string.Empty;} set{_filenum=value;} }
        string _receiptnum;
        public string Receiptnum { get {return _receiptnum!=null?_receiptnum:string.Empty;} set{_receiptnum=value;} }
        string _incomedate;
        public string Incomedate { get {return _incomedate!=null?_incomedate:string.Empty;} set{_incomedate=value;} }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _percentdiscount;
        public string Percentdiscount { get {return _percentdiscount!=null?_percentdiscount:string.Empty;} set{_percentdiscount=value;} }
        string _valuediscount;
        public string Valuediscount { get {return _valuediscount!=null?_valuediscount:string.Empty;} set{_valuediscount=value;} }
        string _totaldiscount;
        public string Totaldiscount { get {return _totaldiscount!=null?_totaldiscount:string.Empty;} set{_totaldiscount=value;} }
        string _total;
        public string Total { get {return _total!=null?_total:string.Empty;} set{_total=value;} }
        string _totaldebt;
        public string Totaldebt { get {return _totaldebt!=null?_totaldebt:string.Empty;} set{_totaldebt=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
        string _isdelivered;
        public string Isdelivered { get {return _isdelivered!=null?_isdelivered:string.Empty;} set{_isdelivered=value;} }
        string _deliverdate;
        public string Deliverdate { get {return _deliverdate!=null?_deliverdate:string.Empty;} set{_deliverdate=value;} }
        string _createdate;
        public string Createdate { get {return _createdate!=null?_createdate:string.Empty;} set{_createdate=value;} }
    }
}
