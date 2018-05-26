
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CusConversationBR : CommonBR
    {
        CusConversationContract cusconversationContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.cusconversationContract = (CusConversationContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CusConversationRule cusconversationRule = new CusConversationRule();
           // if (context == "Insert")
           // {
           //     rules.Add(cusconversationRule.ValidateInstant(cusconversationContract));
           // }
        }
    }
}
