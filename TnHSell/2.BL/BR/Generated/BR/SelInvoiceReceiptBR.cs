
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class SelInvoiceReceiptBR : CommonBR
    {
        SelInvoiceReceiptContract selinvoicereceiptContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.selinvoicereceiptContract = (SelInvoiceReceiptContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            SelInvoiceReceiptRule selinvoicereceiptRule = new SelInvoiceReceiptRule();
           // if (context == "Insert")
           // {
           //     rules.Add(selinvoicereceiptRule.ValidateInstant(selinvoicereceiptContract));
           // }
        }
    }
}
