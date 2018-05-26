
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class StoExchangeBR : CommonBR
    {
        StoExchangeContract stoexchangeContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.stoexchangeContract = (StoExchangeContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            StoExchangeRule stoexchangeRule = new StoExchangeRule();
           // if (context == "Insert")
           // {
           //     rules.Add(stoexchangeRule.ValidateInstant(stoexchangeContract));
           // }
        }
    }
}
