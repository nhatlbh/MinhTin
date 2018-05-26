
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class AdmRoleBR : CommonBR
    {
        AdmRoleContract admroleContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.admroleContract = (AdmRoleContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            AdmRoleRule admroleRule = new AdmRoleRule();
           // if (context == "Insert")
           // {
           //     rules.Add(admroleRule.ValidateInstant(admroleContract));
           // }
        }
    }
}
