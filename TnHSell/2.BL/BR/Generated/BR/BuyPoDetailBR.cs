
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class BuyPoDetailBR : CommonBR
    {
        BuyPoDetailContract buypodetailContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.buypodetailContract = (BuyPoDetailContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            BuyPoDetailRule buypodetailRule = new BuyPoDetailRule();
           // if (context == "Insert")
           // {
           //     rules.Add(buypodetailRule.ValidateInstant(buypodetailContract));
           // }
        }
    }
}
