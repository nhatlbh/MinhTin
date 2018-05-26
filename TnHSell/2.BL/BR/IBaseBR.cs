using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnHSell.BR
{
    public interface IBaseBR
    {
        void RegistInstants(params object[] instants );
        void RegistRule(string context);
        Boolean CheckRules(out string message);
    }
}
