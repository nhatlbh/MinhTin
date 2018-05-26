using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum CatProductPriceColumns
    {
           ID,           
           ProductID,           
           IOCodeID,           
           Price,           
    }
    public partial class CatProductPriceContract
    {  

    public static readonly string[] Columns = {"ID","ProductID","IOCodeID","Price",};
        public Int32 Id { get; set; }
        public Int32? Productid { get; set; }
        public Int32? Iocodeid { get; set; }
        string _price;
        public string Price { get {return _price!=null?_price:string.Empty;} set{_price=value;} }
    }
}
