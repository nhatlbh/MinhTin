
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class BuySupplierreturnBR : CommonBR
    {
        BuySupplierreturnContract buysupplierreturnContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.buysupplierreturnContract = (BuySupplierreturnContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            BuySupplierreturnRule buysupplierreturnRule = new BuySupplierreturnRule();
           // if (context == "Insert")
           // {
           //     rules.Add(buysupplierreturnRule.ValidateInstant(buysupplierreturnContract));
           // }
        }
    }
}
