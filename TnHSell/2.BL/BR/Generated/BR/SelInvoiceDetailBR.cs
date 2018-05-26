
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class SelInvoiceDetailBR : CommonBR
    {
        SelInvoiceDetailContract selinvoicedetailContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.selinvoicedetailContract = (SelInvoiceDetailContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            SelInvoiceDetailRule selinvoicedetailRule = new SelInvoiceDetailRule();
           // if (context == "Insert")
           // {
           //     rules.Add(selinvoicedetailRule.ValidateInstant(selinvoicedetailContract));
           // }
        }
    }
}
