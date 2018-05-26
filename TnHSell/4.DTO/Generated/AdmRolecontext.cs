using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum AdmRolecontextColumns
    {
           ID,           
           ContextID,           
           RoleID,           
           Permission,           
           OrderNum,           
    }
    public partial class AdmRolecontextContract
    {  

    public static readonly string[] Columns = {"ID","ContextID","RoleID","Permission","OrderNum",};
        public Int32 Id { get; set; }
        public Int32? Contextid { get; set; }
        public Int32? Roleid { get; set; }
        string _permission;
        public string Permission { get {return _permission!=null?_permission:string.Empty;} set{_permission=value;} }
        string _ordernum;
        public string Ordernum { get {return _ordernum!=null?_ordernum:string.Empty;} set{_ordernum=value;} }
    }
}
