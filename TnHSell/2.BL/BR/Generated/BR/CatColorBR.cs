
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatColorBR : CommonBR
    {
        CatColorContract catcolorContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catcolorContract = (CatColorContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatColorRule catcolorRule = new CatColorRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catcolorRule.ValidateInstant(catcolorContract));
           // }
        }
    }
}
