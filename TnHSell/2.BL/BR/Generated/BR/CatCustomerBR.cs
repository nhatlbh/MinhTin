
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatCustomerBR : CommonBR
    {
        CatCustomerContract catcustomerContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catcustomerContract = (CatCustomerContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatCustomerRule catcustomerRule = new CatCustomerRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catcustomerRule.ValidateInstant(catcustomerContract));
           // }
        }
    }
}
