
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class FinReceivepaymentBR : CommonBR
    {
        FinReceivepaymentContract finreceivepaymentContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.finreceivepaymentContract = (FinReceivepaymentContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            FinReceivepaymentRule finreceivepaymentRule = new FinReceivepaymentRule();
           // if (context == "Insert")
           // {
           //     rules.Add(finreceivepaymentRule.ValidateInstant(finreceivepaymentContract));
           // }
        }
    }
}
