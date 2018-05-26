
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatUnitBR : CommonBR
    {
        CatUnitContract catunitContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catunitContract = (CatUnitContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatUnitRule catunitRule = new CatUnitRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catunitRule.ValidateInstant(catunitContract));
           // }
        }
    }
}
