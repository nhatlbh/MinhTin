
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class LoginSessionBR : CommonBR
    {
        LoginSessionContract loginsessionContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.loginsessionContract = (LoginSessionContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            LoginSessionRule loginsessionRule = new LoginSessionRule();
           // if (context == "Insert")
           // {
           //     rules.Add(loginsessionRule.ValidateInstant(loginsessionContract));
           // }
        }
    }
}
