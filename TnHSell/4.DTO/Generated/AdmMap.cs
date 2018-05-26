using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum AdmMapColumns
    {
           ID,           
           Code,           
           Name,           
           Path,           
           ParentID,           
           PathLevel,           
           OrderNum,           
    }
    public partial class AdmMapContract
    {  

    public static readonly string[] Columns = {"ID","Code","Name","Path","ParentID","PathLevel","OrderNum",};
        public Int32 Id { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        string _name;
        public string Name { get {return _name!=null?_name:string.Empty;} set{_name=value;} }
        string _path;
        public string Path { get {return _path!=null?_path:string.Empty;} set{_path=value;} }
        public Int32? Parentid { get; set; }
        string _pathlevel;
        public string Pathlevel { get {return _pathlevel!=null?_pathlevel:string.Empty;} set{_pathlevel=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
