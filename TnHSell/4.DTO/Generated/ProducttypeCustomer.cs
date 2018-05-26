using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum ProducttypeCustomerColumns
    {
           ID,           
           ProductTypeID,           
           CustomerID,           
           GetinDate,           
    }
    public partial class ProducttypeCustomerContract
    {  

    public static readonly string[] Columns = {"ID","ProductTypeID","CustomerID","GetinDate",};
        public Int32 Id { get; set; }
        public Int32? Producttypeid { get; set; }
        public Int32? Customerid { get; set; }
        string _getindate;
        public string Getindate { get {return _getindate!=null?_getindate:string.Empty;} set{_getindate=value;} }
    }
}
