﻿
using TnHSell.DTContract;
using TnHSell.DTO;
using TnHSell.Model;

namespace TnHSell.DFR
{
    public class CatCustomerDFR
    {
        public static string GetGridData(string sessionKey, string cond, out string order)
        {
            cond = getFilterCond(cond, sessionKey);
            order = " OrderNum DESC, Id DESC";
            return cond;
        }

        public static string GetComboboxData(string sessionKey, out string columns, string cond, out string order)
        {
            cond = getFilterCond(cond, sessionKey);
            columns = "";
            order = "OrderNum DESC";
            return cond;
        }
        public static string getFilterCond(string cond, string sessionKey)
        {
            AuthInfo auth = AuthModel.GetAuthInfo(sessionKey);
            if (auth != null)
            {
                cond += cond == string.Empty ? "" : " AND ";
                cond += " ManagementGroupID in (" + string.Join(",", auth.StaffMgntGroupIds.ToArray()) + ")";
            }
            else
            {
                cond = " 0=1 ";
            }
            return cond;
        }

    }
}
