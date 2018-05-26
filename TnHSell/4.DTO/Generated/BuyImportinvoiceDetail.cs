using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum BuyImportinvoiceDetailColumns
    {
           ID,           
           ImportInvoiceID,           
           ProductID,           
           Quantity,           
           Price,           
           VAT,           
           OrderNum,           
    }
    public partial class BuyImportinvoiceDetailContract
    {  

    public static readonly string[] Columns = {"ID","ImportInvoiceID","ProductID","Quantity","Price","VAT","OrderNum",};
        public Int32 Id { get; set; }
        public Int32? Importinvoiceid { get; set; }
        public Int32? Productid { get; set; }
        string _quantity;
        public string Quantity { get {return _quantity!=null?_quantity:string.Empty;} set{_quantity=value;} }
        string _price;
        public string Price { get {return _price!=null?_price:string.Empty;} set{_price=value;} }
        string _vat;
        public string Vat { get {return _vat!=null?_vat:string.Empty;} set{_vat=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
