using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum AdmRoleColumns
    {
           ID,           
           Name,           
           Code,           
           Description,           
           Disabled,           
           SiteMap,           
           OrderNum,           
    }
    public partial class AdmRoleContract
    {  

    public static readonly string[] Columns = {"ID","Name","Code","Description","Disabled","SiteMap","OrderNum",};
        public Int32 Id { get; set; }
        string _name;
        public string Name { get {return _name!=null?_name:string.Empty;} set{_name=value;} }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _disabled;
        public string Disabled { get {return _disabled!=null?_disabled:string.Empty;} set{_disabled=value;} }
        string _sitemap;
        public string Sitemap { get {return _sitemap!=null?_sitemap:string.Empty;} set{_sitemap=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
