
using TnHSell.DTContract;

namespace TnHSell.BR
{
    public partial class CatManagementgroupBR : CommonBR
    {
        CatManagementgroupContract catmanagementgroupContract;

        override public void RegistInstants(params object[] instants)
        {
            if (instants.Length > 0)
                this.catmanagementgroupContract = (CatManagementgroupContract)(instants[0]);
        }

        override public void RegistRule(string context)
        {
            CatManagementgroupRule catmanagementgroupRule = new CatManagementgroupRule();
           // if (context == "Insert")
           // {
           //     rules.Add(catmanagementgroupRule.ValidateInstant(catmanagementgroupContract));
           // }
        }
    }
}
