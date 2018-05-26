
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class BuyGuaranteeDetailBR : CommonBR
    {
        BuyGuaranteeDetailContract buyguaranteedetailContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.buyguaranteedetailContract = (BuyGuaranteeDetailContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            BuyGuaranteeDetailRule buyguaranteedetailRule = new BuyGuaranteeDetailRule();
           // if (context == "Insert")
           // {
           //     rules.Add(buyguaranteedetailRule.ValidateInstant(buyguaranteedetailContract));
           // }
        }
    }
}
