
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class SelReceiveproductDetailBR : CommonBR
    {
        SelReceiveproductDetailContract selreceiveproductdetailContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.selreceiveproductdetailContract = (SelReceiveproductDetailContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            SelReceiveproductDetailRule selreceiveproductdetailRule = new SelReceiveproductDetailRule();
           // if (context == "Insert")
           // {
           //     rules.Add(selreceiveproductdetailRule.ValidateInstant(selreceiveproductdetailContract));
           // }
        }
    }
}
