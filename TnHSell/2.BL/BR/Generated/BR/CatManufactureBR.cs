
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatManufactureBR : CommonBR
    {
        CatManufactureContract catmanufactureContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catmanufactureContract = (CatManufactureContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatManufactureRule catmanufactureRule = new CatManufactureRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catmanufactureRule.ValidateInstant(catmanufactureContract));
           // }
        }
    }
}
