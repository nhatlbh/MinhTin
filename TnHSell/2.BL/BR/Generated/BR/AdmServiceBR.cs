
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class AdmServiceBR : CommonBR
    {
        AdmServiceContract admserviceContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.admserviceContract = (AdmServiceContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            AdmServiceRule admserviceRule = new AdmServiceRule();
           // if (context == "Insert")
           // {
           //     rules.Add(admserviceRule.ValidateInstant(admserviceContract));
           // }
        }
    }
}
