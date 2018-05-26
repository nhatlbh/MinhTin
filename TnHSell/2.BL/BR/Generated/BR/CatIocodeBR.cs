
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatIocodeBR : CommonBR
    {
        CatIocodeContract catiocodeContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catiocodeContract = (CatIocodeContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatIocodeRule catiocodeRule = new CatIocodeRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catiocodeRule.ValidateInstant(catiocodeContract));
           // }
        }
    }
}
