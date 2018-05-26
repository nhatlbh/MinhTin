
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class BuyImportinvoiceDetailBR : CommonBR
    {
        BuyImportinvoiceDetailContract buyimportinvoicedetailContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.buyimportinvoicedetailContract = (BuyImportinvoiceDetailContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            BuyImportinvoiceDetailRule buyimportinvoicedetailRule = new BuyImportinvoiceDetailRule();
           // if (context == "Insert")
           // {
           //     rules.Add(buyimportinvoicedetailRule.ValidateInstant(buyimportinvoicedetailContract));
           // }
        }
    }
}
