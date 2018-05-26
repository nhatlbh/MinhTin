
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TnHSell.DT;
using TnHSell.DTO;
using Util;

namespace TnHSell.Model
{
    public class AuthModel
    {
        static LoginSessionDT sessionDT = new LoginSessionDT();
        static CatSalestaffDT staffDT = new CatSalestaffDT();
        static StaffProducttypeDT staffProducTypeDT = new StaffProducttypeDT();
        static StaffMgntgroupDT staffMgntGroupDT = new StaffMgntgroupDT();
        static AdmUserDT userDT = new AdmUserDT();
        static AdmUserroleDT userRoleDt = new AdmUserroleDT();
        static AdmRolerightDT roleRightDT = new AdmRolerightDT();
        public static AuthInfo GetAuthInfo(string sessionKey)
        {
            string sessionCond = "SessionID='" + sessionKey + "'";
            DataTable dtSession = sessionDT.GetByCond(sessionCond);
            if (dtSession != null && dtSession.Rows.Count > 0)
            {
                string getUserCond = "ID=" + dtSession.Rows[0]["UserID"].ToString();
                DataTable dtUser = userDT.GetByCond(getUserCond);
                if (dtUser != null && dtSession.Rows.Count > 0)
                {
                    string userId = dtUser.Rows[0]["ID"].ToString();
                    string getStaffCond = "UserID=" + userId;
                    DataTable dtStaff = staffDT.GetByCond(getStaffCond);
                    if (dtStaff != null && dtStaff.Rows.Count > 0)
                    {
                        string staffGroupCond = "SaleStaffID=" + dtStaff.Rows[0]["ID"].ToString();
                        string getUserRoleCond = "UserID=" + userId;
                        DataTable dtUserRole = userRoleDt.GetByCond(getUserRoleCond);
                        string getUserRightCond = "RoleID in (" + string.Join(",", dtUserRole.ColToListString("RoleID").ToArray()) + ")";
                        DataTable dtUserRight = roleRightDT.GetByCond(getUserRightCond);
                        DataTable dtStaffMgtGroup = staffMgntGroupDT.GetByCond(staffGroupCond);
                        DataTable dtStaffProductType = staffProducTypeDT.GetByCond(staffGroupCond);
                        AuthInfo authInfo = new AuthInfo();
                        authInfo.StaffId = dtStaff.Rows[0]["ID"].ToString();
                        authInfo.UserId = dtStaff.Rows[0]["UserID"].ToString();
                        authInfo.BranchId = dtStaff.Rows[0]["BranchID"].ToString();
                        authInfo.StaffMgntGroupIds = dtStaffMgtGroup.ColToListString("ManagementGroupID");
                        authInfo.StaffProductTypeIds = dtStaffProductType.ColToListString("ProductTypeID");
                        authInfo.UserRightIds = dtUserRight.Distinct("RightID").ColToListString("RightID");
                        return authInfo;
                    }
                }
            }
            return null;
        }
    }
}