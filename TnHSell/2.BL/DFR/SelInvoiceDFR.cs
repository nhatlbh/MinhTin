
using System.Data;
using TnHSell.DT;
using TnHSell.DTContract;
using TnHSell.DTO;
using TnHSell.Model;
using Util;

namespace TnHSell.DFR
{
    public class SelInvoiceDFR
    {
        public static string GetGridData(string sessionKey, string cond, out string order)
        {
            //cond = cond == string.Empty ? "" : " AND ";
            //cond +=  CatSalestaffContract.Columns[(int)CatSalestaffColumns.ID] + " = 1 ";
            cond = getFilterCond(cond, sessionKey);
            order = "OrderNum DESC, Id DESC";
            return cond;
        }

        public static string GetComboboxData(string sessionKey, out string columns, string cond, out string order)
        {
            //cond = cond == string.Empty ? "" : cond + " AND ";
            //cond += cond + CatSalestaffContract.Columns[(int)CatSalestaffColumns.ID] + " = 1 ";
            cond = getFilterCond(cond, sessionKey);
            columns = " ID, Code ";
            order = "OrderNum DESC";
            return cond;
        }
        static string getFilterCond(string cond, string sessionKey)
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