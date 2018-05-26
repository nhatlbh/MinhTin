
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class SelInvoiceBR : CommonBR
    {
        SelInvoiceContract selinvoiceContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.selinvoiceContract = (SelInvoiceContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            SelInvoiceRule selinvoiceRule = new SelInvoiceRule();
           // if (context == "Insert")
           // {
           //     rules.Add(selinvoiceRule.ValidateInstant(selinvoiceContract));
           // }
        }
    }
}
