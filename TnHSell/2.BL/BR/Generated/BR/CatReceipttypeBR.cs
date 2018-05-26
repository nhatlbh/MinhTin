
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatReceipttypeBR : CommonBR
    {
        CatReceipttypeContract catreceipttypeContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catreceipttypeContract = (CatReceipttypeContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatReceipttypeRule catreceipttypeRule = new CatReceipttypeRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catreceipttypeRule.ValidateInstant(catreceipttypeContract));
           // }
        }
    }
}
