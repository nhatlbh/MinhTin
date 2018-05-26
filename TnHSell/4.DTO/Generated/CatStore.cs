using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum CatStoreColumns
    {
           ID,           
           Code,           
           Name,           
           BranchID,           
           StoreTypeID,           
           IsClose,           
           Description,           
           OrderNum,           
    }
    public partial class CatStoreContract
    {  

    public static readonly string[] Columns = {"ID","Code","Name","BranchID","StoreTypeID","IsClose","Description","OrderNum",};
        public Int32 Id { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        string _name;
        public string Name { get {return _name!=null?_name:string.Empty;} set{_name=value;} }
        public Int32? Branchid { get; set; }
        public Int32? Storetypeid { get; set; }
        string _isclose;
        public string Isclose { get {return _isclose!=null?_isclose:string.Empty;} set{_isclose=value;} }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
