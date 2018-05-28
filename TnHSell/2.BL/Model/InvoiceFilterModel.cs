using System.Data;
using TnHSell.DT;
using TnHSell.DTO;
using Util;

namespace TnHSell.Model
{
    public class InvoiceFilterModel
    {
        public static string getFilterCond(string cond, string sessionKey)
        {
            AuthInfo auth = AuthModel.GetAuthInfo(sessionKey);
            CatBranchDT branchDT = new CatBranchDT();
            if (auth != null)
            {
                CatSalestaffDT staffDT = new CatSalestaffDT();
                string branchIds = string.Join(",", branchDT.GetBranchTree(auth.BranchId).ToArray());
                DataTable dtStaff = staffDT.GetByCond("BranchID IN (" + branchIds + ")");
                string staffIds = string.Join(",", dtStaff.ColToListString("ID").ToArray());
                cond += cond == string.Empty ? "" : " AND ";
                if (auth.UserRightIds.Contains("1"))
                {
                    cond += "";
                }
                else if (auth.UserRightIds.Contains("2"))
                {
                    cond += " SaleStaffID in (" + staffIds + ")";
                }
                else if (auth.UserRightIds.Contains("3"))
                {
                    cond += " SaleStaffID=" + auth.StaffId;
                }

            }
            return cond;
        }

    }
}