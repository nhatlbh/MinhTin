
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatProductgroupBR : CommonBR
    {
        CatProductgroupContract catproductgroupContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catproductgroupContract = (CatProductgroupContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatProductgroupRule catproductgroupRule = new CatProductgroupRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catproductgroupRule.ValidateInstant(catproductgroupContract));
           // }
        }
    }
}
