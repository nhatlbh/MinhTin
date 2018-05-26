
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class FinImportpaymentBR : CommonBR
    {
        FinImportpaymentContract finimportpaymentContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.finimportpaymentContract = (FinImportpaymentContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            FinImportpaymentRule finimportpaymentRule = new FinImportpaymentRule();
           // if (context == "Insert")
           // {
           //     rules.Add(finimportpaymentRule.ValidateInstant(finimportpaymentContract));
           // }
        }
    }
}
