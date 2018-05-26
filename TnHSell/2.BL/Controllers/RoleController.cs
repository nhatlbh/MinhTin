using TnHSell.DT;
using TnHSell.DTContract;
using TnHSell.BR;
using DTA;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Util;
using Util;

namespace TnHSell.Controllers
{
    public class RoleController : ApiController
    {
        AdmRolecontextDT roleCtx = new AdmRolecontextDT();
        AdmRolerightDT roleRightDT = new AdmRolerightDT();
        AdmRoleDT roleDT = new AdmRoleDT();
        IBaseBR businessRule = BRFactory.GenerateBRObject(typeof(AdmRoleBR));
        [Route("Role/SaveRole")]
        [HttpGet, HttpPost]
        public HttpResponseMessage SaveRole(string roleJson, string contextJson, string rightJson)
        {
            AdmRoleContract roleDTO = new AdmRoleContract();
            roleDTO = JsonConvert.DeserializeObject<AdmRoleContract>(roleJson);
            string[] selectedContexts = JsonConvert.DeserializeObject<string[]>(contextJson);
            string[] rightIds = JsonConvert.DeserializeObject<string[]>(rightJson);
            string roleId = "";
            string errMessage = string.Empty;
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                businessRule.RegistInstants(roleDTO);
                if (roleDTO.Id > 0)
                {
                    roleId = roleDT.Update(roleDTO, tran);
                }
                else
                {
                    businessRule.RegistRule("Insert");
                    if (businessRule.CheckRules(out errMessage))
                        roleId = roleDT.Insert(roleDTO, tran);
                    else
                        return handleBRFailed(errMessage, tran);
                }
                deleteContext(roleDTO.Id.ToString(), tran);
                foreach (string contextId in selectedContexts)
                {
                    AdmRolecontextContract roleCtxDTO = new AdmRolecontextContract();
                    roleCtxDTO.Roleid = Converter.ToInt32(roleId);
                    roleCtxDTO.Contextid = Converter.ToInt32(contextId);
                    roleCtxDTO.Permission = "1";
                    roleCtx.Insert(roleCtxDTO, tran);
                }
                deleteRight(roleDTO.Id.ToString(), tran);
                foreach (string rightId in rightIds)
                {
                    AdmRolerightContract roleRightDTO = new AdmRolerightContract();
                    roleRightDTO.Roleid = Converter.ToInt32(roleId);
                    roleRightDTO.Rightid = Converter.ToInt32(rightId);
                    roleRightDT.Insert(roleRightDTO, tran);
                }
                DataProvider.CommitTrans(tran);
                UpdateUserSitemap(roleDTO.Id.ToString());
            }
            catch (Exception e)
            {
                DataProvider.RollbackTrans(tran);
            }
            finally
            {
                tran.Dispose();
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, errMessage != string.Empty ? errMessage : roleId);
        }

        [Route("Role/GetContexts")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetContexts(string roleId)
        {
            try
            {
                DataTable dt = roleCtx.GetByCond("RoleId = " + roleId);
                return Request.CreateResponse<string[]>(HttpStatusCode.OK, DataTableHelper.ExtractToStringArray(dt, "ContextId"));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }

        [Route("Role/GetRights")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetRights(string roleId)
        {
            try
            {
                DataTable dt = roleRightDT.GetByCond("RoleId = " + roleId, " RightID ASC ");
                return Request.CreateResponse<string[]>(HttpStatusCode.OK, dt.ColToListString("RightID").ToArray());
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        [Route("Role/DeleteRole")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Delete(string roleId)
        {
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                deleteContext(roleId, tran);
                roleDT.Delete(roleId, tran);
                DataProvider.CommitTrans(tran);
            }
            catch (Exception e)
            {
                DataProvider.RollbackTrans(tran);
            }
            finally
            {
                tran.Dispose();
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, "");
        }


        void deleteContext(string roleId, SqlTransaction tran)
        {
            roleCtx.DeleteViaCond("RoleId=" + roleId, tran);
        }
        void deleteRight(string roleId, SqlTransaction tran)
        {
            roleRightDT.DeleteViaCond("RoleId=" + roleId, tran);
        }

        HttpResponseMessage handleBRFailed(string message, SqlTransaction tran)
        {
            DataProvider.RollbackTrans(tran);
            return Request.CreateResponse<string>(HttpStatusCode.OK, message);
        }
        void UpdateUserSitemap(string roleID)
        {
            AdmUserroleDT userRoleDT = new AdmUserroleDT();

            string getUserIdCond = "RoleID = " + roleID;
            DataTable userIds = userRoleDT.GetByCond(getUserIdCond);
            if (userIds != null)
            {
                foreach (DataRow rowUserId in userIds.Rows)
                {
                    string userId = rowUserId["UserID"].ToString();
                    string getRoleIdCond = "UserID = " + userId;
                    DataTable dtRoleIds = userRoleDT.GetByCond(getRoleIdCond);
                    if (dtRoleIds != null)
                    {
                        string[] roleIds = DataTableHelper.ExtractToStringArray(dtRoleIds, "RoleID");
                        string sitemap =  AdmUserOvrController.buildSiteMap(roleIds);
                        AdmUserDT userDT = new AdmUserDT();
                        string userUpdateCond = "ID=" + userId;
                        userDT.Update(new string[] { "SiteMap" }, new string[] {"N'"+ sitemap +"'"}, userUpdateCond);
                    }
                }
            }
        }
    }
}
