
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class BuyPoBR : CommonBR
    {
        BuyPoContract buypoContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.buypoContract = (BuyPoContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            BuyPoRule buypoRule = new BuyPoRule();
           // if (context == "Insert")
           // {
           //     rules.Add(buypoRule.ValidateInstant(buypoContract));
           // }
        }
    }
}
