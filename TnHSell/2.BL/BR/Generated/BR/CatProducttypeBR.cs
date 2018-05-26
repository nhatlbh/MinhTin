
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatProducttypeBR : CommonBR
    {
        CatProducttypeContract catproducttypeContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catproducttypeContract = (CatProducttypeContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatProducttypeRule catproducttypeRule = new CatProducttypeRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catproducttypeRule.ValidateInstant(catproducttypeContract));
           // }
        }
    }
}
