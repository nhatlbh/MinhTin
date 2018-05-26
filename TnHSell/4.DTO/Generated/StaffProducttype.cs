using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum StaffProducttypeColumns
    {
           ID,           
           ProductTypeID,           
           SaleStaffID,           
           SeeAll,           
    }
    public partial class StaffProducttypeContract
    {  

    public static readonly string[] Columns = {"ID","ProductTypeID","SaleStaffID","SeeAll",};
        public Int32 Id { get; set; }
        public Int32? Producttypeid { get; set; }
        public Int32? Salestaffid { get; set; }
        string _seeall;
        public string Seeall { get {return _seeall!=null?_seeall:string.Empty;} set{_seeall=value;} }
    }
}
