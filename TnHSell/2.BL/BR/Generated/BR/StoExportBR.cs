
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class StoExportBR : CommonBR
    {
        StoExportContract stoexportContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.stoexportContract = (StoExportContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            StoExportRule stoexportRule = new StoExportRule();
           // if (context == "Insert")
           // {
           //     rules.Add(stoexportRule.ValidateInstant(stoexportContract));
           // }
        }
    }
}
