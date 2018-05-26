using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum CatProductStoreColumns
    {
           ID,           
           ProductID,           
           StoreID,           
           ImportDate,           
           Quantity,           
           Inventory,           
           ImportCode,           
           Price,           
           OrderNum,           
    }
    public partial class CatProductStoreContract
    {  

    public static readonly string[] Columns = {"ID","ProductID","StoreID","ImportDate","Quantity","Inventory","ImportCode","Price","OrderNum",};
        public Int32 Id { get; set; }
        public Int32? Productid { get; set; }
        public Int32? Storeid { get; set; }
        string _importdate;
        public string Importdate { get {return _importdate!=null?_importdate:string.Empty;} set{_importdate=value;} }
        string _quantity;
        public string Quantity { get {return _quantity!=null?_quantity:string.Empty;} set{_quantity=value;} }
        string _inventory;
        public string Inventory { get {return _inventory!=null?_inventory:string.Empty;} set{_inventory=value;} }
        string _importcode;
        public string Importcode { get {return _importcode!=null?_importcode:string.Empty;} set{_importcode=value;} }
        string _price;
        public string Price { get {return _price!=null?_price:string.Empty;} set{_price=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
