
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class BuySupplierreturnDetailBR : CommonBR
    {
        BuySupplierreturnDetailContract buysupplierreturndetailContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.buysupplierreturndetailContract = (BuySupplierreturnDetailContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            BuySupplierreturnDetailRule buysupplierreturndetailRule = new BuySupplierreturnDetailRule();
           // if (context == "Insert")
           // {
           //     rules.Add(buysupplierreturndetailRule.ValidateInstant(buysupplierreturndetailContract));
           // }
        }
    }
}
