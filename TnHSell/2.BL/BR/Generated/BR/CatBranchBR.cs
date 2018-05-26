
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatBranchBR : CommonBR
    {
        CatBranchContract catbranchContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catbranchContract = (CatBranchContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatBranchRule catbranchRule = new CatBranchRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catbranchRule.ValidateInstant(catbranchContract));
           // }
        }
    }
}
