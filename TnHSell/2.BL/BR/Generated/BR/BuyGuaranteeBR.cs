
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class BuyGuaranteeBR : CommonBR
    {
        BuyGuaranteeContract buyguaranteeContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.buyguaranteeContract = (BuyGuaranteeContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            BuyGuaranteeRule buyguaranteeRule = new BuyGuaranteeRule();
           // if (context == "Insert")
           // {
           //     rules.Add(buyguaranteeRule.ValidateInstant(buyguaranteeContract));
           // }
        }
    }
}
