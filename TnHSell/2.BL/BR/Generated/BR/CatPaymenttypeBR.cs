
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatPaymenttypeBR : CommonBR
    {
        CatPaymenttypeContract catpaymenttypeContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catpaymenttypeContract = (CatPaymenttypeContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatPaymenttypeRule catpaymenttypeRule = new CatPaymenttypeRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catpaymenttypeRule.ValidateInstant(catpaymenttypeContract));
           // }
        }
    }
}
