
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class FinMoneyslipBR : CommonBR
    {
        FinMoneyslipContract finmoneyslipContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.finmoneyslipContract = (FinMoneyslipContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            FinMoneyslipRule finmoneyslipRule = new FinMoneyslipRule();
           // if (context == "Insert")
           // {
           //     rules.Add(finmoneyslipRule.ValidateInstant(finmoneyslipContract));
           // }
        }
    }
}
