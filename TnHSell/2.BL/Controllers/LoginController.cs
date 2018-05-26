using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TnHSell.BL;
using TnHSell.DT;
using TnHSell.DTContract;
using Util;

namespace TnHSell.Controllers
{
    public class LoginController : ApiController
    {
        AdmUserDT userDT = new AdmUserDT();
        LoginSessionDT sessionDT = new LoginSessionDT();

        [Route("Login/Login")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Login(string sessionId, string SessionKey)
        {
            try
            {
                string message = loginMessage(sessionId);
                if (message == "")
                {
                    sessionDT.Update(new string[] { "SessionID" }, new string[] { "'" + SessionKey + "'" }, "ID=" + sessionId);
                    return Request.CreateResponse<string>(HttpStatusCode.OK, "Success");
                }
                else
                {
                    return Request.CreateResponse<string>(HttpStatusCode.OK, message);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, "Failed");
        }
        string loginMessage(string sessionId)
        {
            DataTable session = sessionDT.GetByID(sessionId);
            if (session == null || session.Rows.Count == 0)
            {
                return "Session chưa được cấp token. Vui lòng đăng nhập lại.";
            }
            if (session != null && session.Rows.Count > 0 && session.Rows[0]["SessionID"].ToString() != "")
            {
                return "Token đã được cấp cho 1 session khác. Vui lòng đăng nhập lại.";
            }
            return "";
        }

    }
}
