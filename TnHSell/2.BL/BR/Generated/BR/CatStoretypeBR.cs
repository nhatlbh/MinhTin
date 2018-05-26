
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatStoretypeBR : CommonBR
    {
        CatStoretypeContract catstoretypeContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catstoretypeContract = (CatStoretypeContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatStoretypeRule catstoretypeRule = new CatStoretypeRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catstoretypeRule.ValidateInstant(catstoretypeContract));
           // }
        }
    }
}
