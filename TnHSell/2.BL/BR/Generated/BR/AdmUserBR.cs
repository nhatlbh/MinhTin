
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class AdmUserBR : CommonBR
    {
        AdmUserContract admuserContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.admuserContract = (AdmUserContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            AdmUserRule admuserRule = new AdmUserRule();
           // if (context == "Insert")
           // {
           //     rules.Add(admuserRule.ValidateInstant(admuserContract));
           // }
        }
    }
}
