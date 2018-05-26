using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum AdmContextColumns
    {
           ID,           
           Code,           
           Name,           
           DevName,           
           MapID,           
           Type,           
           RootMap,           
           OrderNum,           
    }
    public partial class AdmContextContract
    {  

    public static readonly string[] Columns = {"ID","Code","Name","DevName","MapID","Type","RootMap","OrderNum",};
        public Int32 Id { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        string _name;
        public string Name { get {return _name!=null?_name:string.Empty;} set{_name=value;} }
        string _devname;
        public string Devname { get {return _devname!=null?_devname:string.Empty;} set{_devname=value;} }
        public Int32? Mapid { get; set; }
        string _type;
        public string Type { get {return _type!=null?_type:string.Empty;} set{_type=value;} }
        string _rootmap;
        public string Rootmap { get {return _rootmap!=null?_rootmap:string.Empty;} set{_rootmap=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
