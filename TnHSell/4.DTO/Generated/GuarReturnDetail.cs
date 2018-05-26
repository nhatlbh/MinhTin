using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum GuarReturnDetailColumns
    {
           ID,           
           GuarReturnID,           
           ProductID,           
           Quantity,           
           OrderNum,           
           Deleted,           
           DeletedOn,           
    }
    public partial class GuarReturnDetailContract
    {  

    public static readonly string[] Columns = {"ID","GuarReturnID","ProductID","Quantity","OrderNum","Deleted","DeletedOn",};
        public Int32 Id { get; set; }
        public Int32? Guarreturnid { get; set; }
        string _productid;
        public string Productid { get {return _productid!=null?_productid:string.Empty;} set{_productid=value;} }
        string _quantity;
        public string Quantity { get {return _quantity!=null?_quantity:string.Empty;} set{_quantity=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
        string _deleted;
        public string Deleted { get {return _deleted!=null?_deleted:string.Empty;} set{_deleted=value;} }
        string _deletedon;
        public string Deletedon { get {return _deletedon!=null?_deletedon:string.Empty;} set{_deletedon=value;} }
    }
}
