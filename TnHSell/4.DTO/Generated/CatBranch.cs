using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum CatBranchColumns
    {
           ID,           
           Code,           
           Name,           
           ParentBranchID,           
           Description,           
           Address,           
           Phone,           
           OrderNum,           
    }
    public partial class CatBranchContract
    {  

    public static readonly string[] Columns = {"ID","Code","Name","ParentBranchID","Description","Address","Phone","OrderNum",};
        public Int32 Id { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        string _name;
        public string Name { get {return _name!=null?_name:string.Empty;} set{_name=value;} }
        public Int32? Parentbranchid { get; set; }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _address;
        public string Address { get {return _address!=null?_address:string.Empty;} set{_address=value;} }
        string _phone;
        public string Phone { get {return _phone!=null?_phone:string.Empty;} set{_phone=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
