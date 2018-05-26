
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatProductPriceBR : CommonBR
    {
        CatProductPriceContract catproductpriceContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catproductpriceContract = (CatProductPriceContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatProductPriceRule catproductpriceRule = new CatProductPriceRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catproductpriceRule.ValidateInstant(catproductpriceContract));
           // }
        }
    }
}
