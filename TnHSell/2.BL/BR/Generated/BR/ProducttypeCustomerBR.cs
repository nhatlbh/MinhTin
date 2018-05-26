
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class ProducttypeCustomerBR : CommonBR
    {
        ProducttypeCustomerContract producttypecustomerContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.producttypecustomerContract = (ProducttypeCustomerContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            ProducttypeCustomerRule producttypecustomerRule = new ProducttypeCustomerRule();
           // if (context == "Insert")
           // {
           //     rules.Add(producttypecustomerRule.ValidateInstant(producttypecustomerContract));
           // }
        }
    }
}
