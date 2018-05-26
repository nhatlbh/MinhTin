using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum SelReceiveproductDetailColumns
    {
           ID,           
           ReceiveProductID,           
           ProductID,           
           Quantity,           
           Price,           
           OrderNum,           
           Deleted,           
           DeletedOn,           
    }
    public partial class SelReceiveproductDetailContract
    {  

    public static readonly string[] Columns = {"ID","ReceiveProductID","ProductID","Quantity","Price","OrderNum","Deleted","DeletedOn",};
        public Int32 Id { get; set; }
        public Int32? Receiveproductid { get; set; }
        public Int32? Productid { get; set; }
        string _quantity;
        public string Quantity { get {return _quantity!=null?_quantity:string.Empty;} set{_quantity=value;} }
        string _price;
        public string Price { get {return _price!=null?_price:string.Empty;} set{_price=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
        string _deleted;
        public string Deleted { get {return _deleted!=null?_deleted:string.Empty;} set{_deleted=value;} }
        string _deletedon;
        public string Deletedon { get {return _deletedon!=null?_deletedon:string.Empty;} set{_deletedon=value;} }
    }
}
