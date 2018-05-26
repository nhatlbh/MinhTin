
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class AdmRoleserviceBR : CommonBR
    {
        AdmRoleserviceContract admroleserviceContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.admroleserviceContract = (AdmRoleserviceContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            AdmRoleserviceRule admroleserviceRule = new AdmRoleserviceRule();
           // if (context == "Insert")
           // {
           //     rules.Add(admroleserviceRule.ValidateInstant(admroleserviceContract));
           // }
        }
    }
}
