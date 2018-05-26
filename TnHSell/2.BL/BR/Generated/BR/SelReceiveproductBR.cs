
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class SelReceiveproductBR : CommonBR
    {
        SelReceiveproductContract selreceiveproductContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.selreceiveproductContract = (SelReceiveproductContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            SelReceiveproductRule selreceiveproductRule = new SelReceiveproductRule();
           // if (context == "Insert")
           // {
           //     rules.Add(selreceiveproductRule.ValidateInstant(selreceiveproductContract));
           // }
        }
    }
}
