
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatChanelBR : CommonBR
    {
        CatChanelContract catchanelContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catchanelContract = (CatChanelContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatChanelRule catchanelRule = new CatChanelRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catchanelRule.ValidateInstant(catchanelContract));
           // }
        }
    }
}
