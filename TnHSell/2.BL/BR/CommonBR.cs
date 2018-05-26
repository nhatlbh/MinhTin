using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TnHSell.BR
{
    abstract public class CommonBR : IBaseBR
    {
        protected List<BaseRule> rules = new List<BaseRule>();

        public bool CheckRules(out string message)
        {
            message = string.Empty;
            foreach (BaseRule rule in rules)
            {
                if (!rule.IsPassed && !message.Contains(rule.ErrMessage))
                    message += rule.ErrMessage;
            }
            return message == string.Empty;
        }

        abstract public void RegistInstants(params object[] instants);
        abstract public void RegistRule(string context);
    }
}