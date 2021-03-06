﻿using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum CatIocodeColumns
    {
           ID,           
           Code,           
           Name,           
           Description,           
           OrderNum,           
    }
    public partial class CatIocodeContract
    {  

    public static readonly string[] Columns = {"ID","Code","Name","Description","OrderNum",};
        public Int32 Id { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        string _name;
        public string Name { get {return _name!=null?_name:string.Empty;} set{_name=value;} }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
