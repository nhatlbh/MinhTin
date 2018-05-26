
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatProductBR : CommonBR
    {
        CatProductContract catproductContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catproductContract = (CatProductContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatProductRule catproductRule = new CatProductRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catproductRule.ValidateInstant(catproductContract));
           // }
        }
    }
}
