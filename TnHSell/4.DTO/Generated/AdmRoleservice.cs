using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum AdmRoleserviceColumns
    {
           ID,           
           ServiceID,           
           RoleID,           
           Permission,           
           Message,           
           OrderNum,           
    }
    public partial class AdmRoleserviceContract
    {  

    public static readonly string[] Columns = {"ID","ServiceID","RoleID","Permission","Message","OrderNum",};
        public Int32 Id { get; set; }
        public Int32? Serviceid { get; set; }
        public Int32? Roleid { get; set; }
        string _permission;
        public string Permission { get {return _permission!=null?_permission:string.Empty;} set{_permission=value;} }
        string _message;
        public string Message { get {return _message!=null?_message:string.Empty;} set{_message=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
