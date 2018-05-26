
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class AdmMapBR : CommonBR
    {
        AdmMapContract admmapContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.admmapContract = (AdmMapContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            AdmMapRule admmapRule = new AdmMapRule();
           // if (context == "Insert")
           // {
           //     rules.Add(admmapRule.ValidateInstant(admmapContract));
           // }
        }
    }
}
