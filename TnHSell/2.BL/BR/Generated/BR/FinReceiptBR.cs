
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class FinReceiptBR : CommonBR
    {
        FinReceiptContract finreceiptContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.finreceiptContract = (FinReceiptContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            FinReceiptRule finreceiptRule = new FinReceiptRule();
           // if (context == "Insert")
           // {
           //     rules.Add(finreceiptRule.ValidateInstant(finreceiptContract));
           // }
        }
    }
}
