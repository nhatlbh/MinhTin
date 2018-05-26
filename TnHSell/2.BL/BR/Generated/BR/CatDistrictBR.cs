
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatDistrictBR : CommonBR
    {
        CatDistrictContract catdistrictContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catdistrictContract = (CatDistrictContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatDistrictRule catdistrictRule = new CatDistrictRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catdistrictRule.ValidateInstant(catdistrictContract));
           // }
        }
    }
}
