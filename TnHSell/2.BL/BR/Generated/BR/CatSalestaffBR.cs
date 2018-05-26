
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatSalestaffBR : CommonBR
    {
        CatSalestaffContract catsalestaffContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catsalestaffContract = (CatSalestaffContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatSalestaffRule catsalestaffRule = new CatSalestaffRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catsalestaffRule.ValidateInstant(catsalestaffContract));
           // }
        }
    }
}
