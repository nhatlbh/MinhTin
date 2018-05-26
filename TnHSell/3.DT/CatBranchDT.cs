using System.Collections.Generic;
using System.Data;
using Util;

namespace TnHSell.DT
{
    public partial class CatBranchDT
    {
        public List<string> GetBranchTree(string branchID)
        {
            List<string> result = new List<string>();
            List<string> childBrandIds = new List<string>();
            result.Add(branchID);
            childBrandIds = getChildBranch(branchID);
            result.Concat<string>(childBrandIds);
            return result;
        }
        List<string> getChildBranch(string branchID)
        {
            try
            {
                List<string> result = new List<string>();
                result = GetByCond("ParentBranchID=" + branchID).ColToListString("ID");
                return result;
            }
            catch
            {
                return null;
            }
        }

    }
}
