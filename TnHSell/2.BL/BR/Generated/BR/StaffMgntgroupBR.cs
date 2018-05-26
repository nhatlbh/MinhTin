
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class StaffMgntgroupBR : CommonBR
    {
        StaffMgntgroupContract staffmgntgroupContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.staffmgntgroupContract = (StaffMgntgroupContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            StaffMgntgroupRule staffmgntgroupRule = new StaffMgntgroupRule();
           // if (context == "Insert")
           // {
           //     rules.Add(staffmgntgroupRule.ValidateInstant(staffmgntgroupContract));
           // }
        }
    }
}
