
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class StoExportDetailBR : CommonBR
    {
        StoExportDetailContract stoexportdetailContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.stoexportdetailContract = (StoExportDetailContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            StoExportDetailRule stoexportdetailRule = new StoExportDetailRule();
           // if (context == "Insert")
           // {
           //     rules.Add(stoexportdetailRule.ValidateInstant(stoexportdetailContract));
           // }
        }
    }
}
