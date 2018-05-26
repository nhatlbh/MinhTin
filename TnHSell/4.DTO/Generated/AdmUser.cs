using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum AdmUserColumns
    {
           ID,           
           Code,           
           Name,           
           Password,           
           Description,           
           CreateDate,           
           ExpireDate,           
           SiteMap,           
           Disabled,           
           OrderNum,           
    }
    public partial class AdmUserContract
    {  

    public static readonly string[] Columns = {"ID","Code","Name","Password","Description","CreateDate","ExpireDate","SiteMap","Disabled","OrderNum",};
        public Int32 Id { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        string _name;
        public string Name { get {return _name!=null?_name:string.Empty;} set{_name=value;} }
        string _password;
        public string Password { get {return _password!=null?_password:string.Empty;} set{_password=value;} }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _createdate;
        public string Createdate { get {return _createdate!=null?_createdate:string.Empty;} set{_createdate=value;} }
        string _expiredate;
        public string Expiredate { get {return _expiredate!=null?_expiredate:string.Empty;} set{_expiredate=value;} }
        string _sitemap;
        public string Sitemap { get {return _sitemap!=null?_sitemap:string.Empty;} set{_sitemap=value;} }
        string _disabled;
        public string Disabled { get {return _disabled!=null?_disabled:string.Empty;} set{_disabled=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
