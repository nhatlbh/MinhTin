
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatSupplierBR : CommonBR
    {
        CatSupplierContract catsupplierContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catsupplierContract = (CatSupplierContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatSupplierRule catsupplierRule = new CatSupplierRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catsupplierRule.ValidateInstant(catsupplierContract));
           // }
        }
    }
}
