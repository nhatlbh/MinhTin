using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TnHSell.DT;
using TnHSell.DTContract;
using TnHSell.Model;
using Util;

namespace TnHSell.Controllers
{
    public class SessionController : ApiController
    {
        static AdmUserDT userDT = new AdmUserDT();
        static LoginSessionDT sessionDT = new LoginSessionDT();

        [Route("Session/Validate")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Validate(string sessionKey)
        {
            DataTable session = sessionDT.GetByCond("SessionID='" + sessionKey + "'");
            if (session == null || session.Rows.Count == 0)
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, "False");
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, "True");
        }
        [Route("Session/UserInfo")]
        [HttpGet, HttpPost]
        public HttpResponseMessage StaffInfo(string sessionKey)
        {
            CatSalestaffDT staffDT = new CatSalestaffDT();
            DataTable dtSession = sessionDT.GetByCond("SessionID='" + sessionKey + "'", " ID DESC");
            if (dtSession != null && dtSession.Rows.Count > 0)
            {
                // DataTable dtStaff = staffDT.GetByCond("UserID=" + dtSession.Rows[0][LoginSessionContract.Columns[(int)LoginSessionColumns.UserID]].ToString());
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(AuthModel.GetAuthInfo(sessionKey)));
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, "{}");
        }
        [Route("Session/RenderMenu")]
        [HttpGet, HttpPost]
        public HttpResponseMessage RenderMenu(string sessionKey)
        {
            AdmUserContract userContract = SessionController.GetUserInfo(sessionKey);
            try
            {
                if (userContract != null)
                {
                    return Request.CreateResponse<string>(HttpStatusCode.OK, userContract.Sitemap);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, "");
        }

        public static AdmUserContract GetUserInfo(string sessionKey)
        {
            DataTable session = sessionDT.GetByCond("SessionID='" + sessionKey + "'", " ID DESC");
            if (session != null && session.Rows.Count != 0)
            {
                DataTable userTable = userDT.GetByID(session.Rows[0]["UserId"].ToString());
                AdmUserContract user = new AdmUserContract();
                if (userTable != null && userTable.Rows.Count > 0)
                {
                    DataRow userRow = userTable.Rows[0];
                    user.Name = userRow["Name"].ToString();
                    user.Sitemap = userRow["Sitemap"].ToString();
                    return user;
                }
            }
            return null;
        }
    }
}
