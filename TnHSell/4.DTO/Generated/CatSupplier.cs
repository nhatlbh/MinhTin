using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum CatSupplierColumns
    {
           ID,           
           Code,           
           Name,           
           Address,           
           TaxCode,           
           Phone,           
           Fax,           
           Email,           
           Contact,           
           ContactPhone,           
           ContactEmail,           
           MaxAllowedDebt,           
           Blocked,           
           Description,           
           OrderNum,           
    }
    public partial class CatSupplierContract
    {  

    public static readonly string[] Columns = {"ID","Code","Name","Address","TaxCode","Phone","Fax","Email","Contact","ContactPhone","ContactEmail","MaxAllowedDebt","Blocked","Description","OrderNum",};
        public Int32 Id { get; set; }
        string _code;
        public string Code { get {return _code!=null?_code:string.Empty;} set{_code=value;} }
        string _name;
        public string Name { get {return _name!=null?_name:string.Empty;} set{_name=value;} }
        string _address;
        public string Address { get {return _address!=null?_address:string.Empty;} set{_address=value;} }
        string _taxcode;
        public string Taxcode { get {return _taxcode!=null?_taxcode:string.Empty;} set{_taxcode=value;} }
        string _phone;
        public string Phone { get {return _phone!=null?_phone:string.Empty;} set{_phone=value;} }
        string _fax;
        public string Fax { get {return _fax!=null?_fax:string.Empty;} set{_fax=value;} }
        string _email;
        public string Email { get {return _email!=null?_email:string.Empty;} set{_email=value;} }
        string _contact;
        public string Contact { get {return _contact!=null?_contact:string.Empty;} set{_contact=value;} }
        string _contactphone;
        public string Contactphone { get {return _contactphone!=null?_contactphone:string.Empty;} set{_contactphone=value;} }
        string _contactemail;
        public string Contactemail { get {return _contactemail!=null?_contactemail:string.Empty;} set{_contactemail=value;} }
        string _maxalloweddebt;
        public string Maxalloweddebt { get {return _maxalloweddebt!=null?_maxalloweddebt:string.Empty;} set{_maxalloweddebt=value;} }
        string _blocked;
        public string Blocked { get {return _blocked!=null?_blocked:string.Empty;} set{_blocked=value;} }
        string _description;
        public string Description { get {return _description!=null?_description:string.Empty;} set{_description=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
