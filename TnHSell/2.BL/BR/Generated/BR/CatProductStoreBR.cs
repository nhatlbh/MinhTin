
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatProductStoreBR : CommonBR
    {
        CatProductStoreContract catproductstoreContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catproductstoreContract = (CatProductStoreContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatProductStoreRule catproductstoreRule = new CatProductStoreRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catproductstoreRule.ValidateInstant(catproductstoreContract));
           // }
        }
    }
}
