
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class GuarReturnBR : CommonBR
    {
        GuarReturnContract guarreturnContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.guarreturnContract = (GuarReturnContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            GuarReturnRule guarreturnRule = new GuarReturnRule();
           // if (context == "Insert")
           // {
           //     rules.Add(guarreturnRule.ValidateInstant(guarreturnContract));
           // }
        }
    }
}
