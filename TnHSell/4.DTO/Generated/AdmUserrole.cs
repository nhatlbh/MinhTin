using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum AdmUserroleColumns
    {
           ID,           
           UserID,           
           RoleID,           
    }
    public partial class AdmUserroleContract
    {  

    public static readonly string[] Columns = {"ID","UserID","RoleID",};
        public Int32 Id { get; set; }
        public Int32? Userid { get; set; }
        public Int32? Roleid { get; set; }
    }
}
