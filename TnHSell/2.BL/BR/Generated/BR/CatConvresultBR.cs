
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatConvresultBR : CommonBR
    {
        CatConvresultContract catconvresultContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catconvresultContract = (CatConvresultContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatConvresultRule catconvresultRule = new CatConvresultRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catconvresultRule.ValidateInstant(catconvresultContract));
           // }
        }
    }
}
