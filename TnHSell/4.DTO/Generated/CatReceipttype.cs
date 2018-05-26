using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum CatReceipttypeColumns
    {
           ID,           
           Code,           
           Name,           
           Description,           
           Type,           
           OrderNum,           
    }
    public partial class CatReceipttypeContract
    {  

    public static readonly string[] Columns = {"ID","Code","Name","Description","Type","OrderNum",};
        public Int32 Id { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        string _name;
        public string Name { get {return _name!=null?_name:string.Empty;} set{_name=value;} }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _type;
        public string Type { get {return _type!=null?_type:string.Empty;} set{_type=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
