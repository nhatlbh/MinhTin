
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class AdmUserroleBR : CommonBR
    {
        AdmUserroleContract admuserroleContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.admuserroleContract = (AdmUserroleContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            AdmUserroleRule admuserroleRule = new AdmUserroleRule();
           // if (context == "Insert")
           // {
           //     rules.Add(admuserroleRule.ValidateInstant(admuserroleContract));
           // }
        }
    }
}
