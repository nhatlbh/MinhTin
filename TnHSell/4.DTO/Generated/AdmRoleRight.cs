using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum AdmRolerightColumns
    {
           ID,           
           RoleID,           
           RightID,           
    }
    public partial class AdmRolerightContract
    {  

    public static readonly string[] Columns = {"ID","RoleID","RightID",};
        public Int32 Id { get; set; }
        public Int32? Roleid { get; set; }
        public Int32? Rightid { get; set; }
    }
}
