
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatProvinceBR : CommonBR
    {
        CatProvinceContract catprovinceContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catprovinceContract = (CatProvinceContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatProvinceRule catprovinceRule = new CatProvinceRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catprovinceRule.ValidateInstant(catprovinceContract));
           // }
        }
    }
}
