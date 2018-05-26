
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class StaffProducttypeBR : CommonBR
    {
        StaffProducttypeContract staffproducttypeContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.staffproducttypeContract = (StaffProducttypeContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            StaffProducttypeRule staffproducttypeRule = new StaffProducttypeRule();
           // if (context == "Insert")
           // {
           //     rules.Add(staffproducttypeRule.ValidateInstant(staffproducttypeContract));
           // }
        }
    }
}
