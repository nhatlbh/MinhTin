using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum CatProductColumns
    {
           ID,           
           Code,           
           Name,           
           UnitID,           
           ColorID,           
           SupplierID,           
           ManufactureID,           
           ProductTypeID,           
           ProductGroupID,           
           BranchID,           
           Description,           
           Blocked,           
           IsComponent,           
           Barcode,           
           WarningNum,           
           OrderNum,           
    }
    public partial class CatProductContract
    {  

    public static readonly string[] Columns = {"ID","Code","Name","UnitID","ColorID","SupplierID","ManufactureID","ProductTypeID","ProductGroupID","BranchID","Description","Blocked","IsComponent","Barcode","WarningNum","OrderNum",};
        public Int32 Id { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        string _name;
        public string Name { get {return _name!=null?_name:string.Empty;} set{_name=value;} }
        public Int32? Unitid { get; set; }
        public Int32? Colorid { get; set; }
        public Int32? Supplierid { get; set; }
        public Int32? Manufactureid { get; set; }
        public Int32? Producttypeid { get; set; }
        public Int32? Productgroupid { get; set; }
        public Int32? Branchid { get; set; }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _blocked;
        public string Blocked { get {return _blocked!=null?_blocked:string.Empty;} set{_blocked=value;} }
        string _iscomponent;
        public string Iscomponent { get {return _iscomponent!=null?_iscomponent:string.Empty;} set{_iscomponent=value;} }
        string _barcode;
        public string Barcode { get {return _barcode!=null?_barcode:string.Empty;} set{_barcode=value;} }
        string _warningnum;
        public string Warningnum { get {return _warningnum!=null?_warningnum:string.Empty;} set{_warningnum=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
