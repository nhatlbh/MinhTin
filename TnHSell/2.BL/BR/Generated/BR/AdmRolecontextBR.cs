
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class AdmRolecontextBR : CommonBR
    {
        AdmRolecontextContract admrolecontextContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.admrolecontextContract = (AdmRolecontextContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            AdmRolecontextRule admrolecontextRule = new AdmRolecontextRule();
           // if (context == "Insert")
           // {
           //     rules.Add(admrolecontextRule.ValidateInstant(admrolecontextContract));
           // }
        }
    }
}
