using System;
using System.Runtime.Serialization;

namespace TnHSell.DTContract
{
    public enum StaffMgntgroupColumns
    {
           ID,           
           SaleStaffID,           
           ManagementGroupID,           
    }
    public partial class StaffMgntgroupContract
    {  

    public static readonly string[] Columns = {"ID","SaleStaffID","ManagementGroupID",};
        public Int32 Id { get; set; }
        public Int32? Salestaffid { get; set; }
        public Int32? Managementgroupid { get; set; }
    }
}
