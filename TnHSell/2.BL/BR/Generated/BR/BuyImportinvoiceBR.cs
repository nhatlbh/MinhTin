
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class BuyImportinvoiceBR : CommonBR
    {
        BuyImportinvoiceContract buyimportinvoiceContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.buyimportinvoiceContract = (BuyImportinvoiceContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            BuyImportinvoiceRule buyimportinvoiceRule = new BuyImportinvoiceRule();
           // if (context == "Insert")
           // {
           //     rules.Add(buyimportinvoiceRule.ValidateInstant(buyimportinvoiceContract));
           // }
        }
    }
}
