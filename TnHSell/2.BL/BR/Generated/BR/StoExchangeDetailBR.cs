
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class StoExchangeDetailBR : CommonBR
    {
        StoExchangeDetailContract stoexchangedetailContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.stoexchangedetailContract = (StoExchangeDetailContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            StoExchangeDetailRule stoexchangedetailRule = new StoExchangeDetailRule();
           // if (context == "Insert")
           // {
           //     rules.Add(stoexchangedetailRule.ValidateInstant(stoexchangedetailContract));
           // }
        }
    }
}
