
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class AdmContextBR : CommonBR
    {
        AdmContextContract admcontextContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.admcontextContract = (AdmContextContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            AdmContextRule admcontextRule = new AdmContextRule();
           // if (context == "Insert")
           // {
           //     rules.Add(admcontextRule.ValidateInstant(admcontextContract));
           // }
        }
    }
}
