
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatStoreBR : CommonBR
    {
        CatStoreContract catstoreContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catstoreContract = (CatStoreContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatStoreRule catstoreRule = new CatStoreRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catstoreRule.ValidateInstant(catstoreContract));
           // }
        }
    }
}
