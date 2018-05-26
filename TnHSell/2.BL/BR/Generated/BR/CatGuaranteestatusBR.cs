
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatGuaranteestatusBR : CommonBR
    {
        CatGuaranteestatusContract catguaranteestatusContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catguaranteestatusContract = (CatGuaranteestatusContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatGuaranteestatusRule catguaranteestatusRule = new CatGuaranteestatusRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catguaranteestatusRule.ValidateInstant(catguaranteestatusContract));
           // }
        }
    }
}
