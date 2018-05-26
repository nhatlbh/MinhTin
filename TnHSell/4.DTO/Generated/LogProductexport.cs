using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum LogProductexportColumns
    {
           ID,           
           StoreID,           
           ProductID,           
           ImportCode,           
           Quantity,           
           ExportDate,           
           ExportCode,           
           ImportPrice,           
           ExportPrice,           
    }
    public partial class LogProductexportContract
    {  

    public static readonly string[] Columns = {"ID","StoreID","ProductID","ImportCode","Quantity","ExportDate","ExportCode","ImportPrice","ExportPrice",};
        public Int32 Id { get; set; }
        string _storeid;
        public string Storeid { get {return _storeid!=null?_storeid:string.Empty;} set{_storeid=value;} }
        string _productid;
        public string Productid { get {return _productid!=null?_productid:string.Empty;} set{_productid=value;} }
        string _importcode;
        public string Importcode { get {return _importcode!=null?_importcode:string.Empty;} set{_importcode=value;} }
        string _quantity;
        public string Quantity { get {return _quantity!=null?_quantity:string.Empty;} set{_quantity=value;} }
        string _exportdate;
        public string Exportdate { get {return _exportdate!=null?_exportdate:string.Empty;} set{_exportdate=value;} }
        string _exportcode;
        public string Exportcode { get {return _exportcode!=null?_exportcode:string.Empty;} set{_exportcode=value;} }
        string _importprice;
        public string Importprice { get {return _importprice!=null?_importprice:string.Empty;} set{_importprice=value;} }
        string _exportprice;
        public string Exportprice { get {return _exportprice!=null?_exportprice:string.Empty;} set{_exportprice=value;} }
    }
}
