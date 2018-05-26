using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TnHSell.DTO;

namespace TnHSell.Model
{
    public class InvoiceFilterModel
    {
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