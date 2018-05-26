using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum CatSalestaffColumns
    {
           ID,           
           Code,           
           Name,           
           BranchID,           
           UserID,           
           Address,           
           Phone,           
           Email,           
           Mobile,           
           SocialNum,           
           Sex,           
           BirthDate,           
           IsQuit,           
           Description,           
           OrderNum,           
    }
    public partial class CatSalestaffContract
    {  

    public static readonly string[] Columns = {"ID","Code","Name","BranchID","UserID","Address","Phone","Email","Mobile","SocialNum","Sex","BirthDate","IsQuit","Description","OrderNum",};
        public Int32 Id { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        string _name;
        public string Name { get {return _name!=null?_name:string.Empty;} set{_name=value;} }
        public Int32? Branchid { get; set; }
        public Int32? Userid { get; set; }
        string _address;
        public string Address { get {return _address!=null?_address:string.Empty;} set{_address=value;} }
        string _phone;
        public string Phone { get {return _phone!=null?_phone:string.Empty;} set{_phone=value;} }
        string _email;
        public string Email { get {return _email!=null?_email:string.Empty;} set{_email=value;} }
        string _mobile;
        public string Mobile { get {return _mobile!=null?_mobile:string.Empty;} set{_mobile=value;} }
        string _socialnum;
        public string Socialnum { get {return _socialnum!=null?_socialnum:string.Empty;} set{_socialnum=value;} }
        string _sex;
        public string Sex { get {return _sex!=null?_sex:string.Empty;} set{_sex=value;} }
        string _birthdate;
        public string Birthdate { get {return _birthdate!=null?_birthdate:string.Empty;} set{_birthdate=value;} }
        string _isquit;
        public string Isquit { get {return _isquit!=null?_isquit:string.Empty;} set{_isquit=value;} }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
