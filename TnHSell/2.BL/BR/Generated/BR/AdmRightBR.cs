
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class AdmRightBR : CommonBR
    {
        AdmRightContract admrightContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.admrightContract = (AdmRightContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            AdmRightRule admrightRule = new AdmRightRule();
           // if (context == "Insert")
           // {
           //     rules.Add(admrightRule.ValidateInstant(admrightContract));
           // }
        }
    }
}
