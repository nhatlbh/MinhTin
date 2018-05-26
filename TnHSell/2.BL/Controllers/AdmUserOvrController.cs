using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TnHSell.DTContract;
using TnHSell.DT;
using TnHSell.BR;
using Newtonsoft.Json;
using System.Data.SqlClient;
using DTA;
using System.Data;
using Util;
using Util;

namespace TnHSell.Controllers
{
    public class AdmUserOvrController : ApiController
    {
        AdmUserroleDT userRoleDT = new AdmUserroleDT();
        AdmUserDT userDT = new AdmUserDT();
        IBaseBR businessRule = BRFactory.GenerateBRObject(typeof(AdmUserBR));
        [Route("AdmUserOvr/Save")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Save(string userJson, string roleIds)
        {
            string userId = "";
            string errMessage = "";
            AdmUserContract userDTO = JsonConvert.DeserializeObject<AdmUserContract>(userJson);
            string[] selectedRoles = JsonConvert.DeserializeObject<string[]>(roleIds);
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                businessRule.RegistInstants(userDTO);
                userDTO.Sitemap = buildSiteMap(selectedRoles);
                if (userDTO.Id > 0)
                {
                    userId = userDT.Update(userDTO, tran);
                }
                else
                {
                    businessRule.RegistRule("Insert");
                    if (businessRule.CheckRules(out errMessage))
                        userId = userDT.Insert(userDTO);
                    else
                        return handleBRFailed(errMessage, tran);
                }
                if (Converter.ToInt32(userId) > 0)
                {
                    deleteOldRoles(userId, tran);
                    foreach (string roleId in selectedRoles)
                    {
                        AdmUserroleContract userRoleDTO = new AdmUserroleContract() { Userid = Converter.ToInt32(userId), Roleid = Converter.ToInt32(roleId) };
                        userRoleDT.Insert(userRoleDTO, tran);
                    }
                }
                DataProvider.CommitTrans(tran);
            }
            catch (Exception e)
            {
                DataProvider.RollbackTrans(tran);
                ExceptionHandler.Log(e);
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, errMessage != string.Empty ? errMessage : userId);
        }

        [Route("AdmUserOvr/GetRoleList")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetRoleList(string userId)
        {
            try
            {
                DataTable dt = userRoleDT.GetByCond("UserId=" + userId);
                return Request.CreateResponse<string[]>(HttpStatusCode.OK, DataTableHelper.ExtractToStringArray(dt, "RoleId"));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }

        [Route("AdmUserOvr/Delete")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Delete(string userId)
        {
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                deleteOldRoles(userId, tran);
                userDT.Delete(userId, tran);
                DataProvider.CommitTrans(tran);
                return Request.CreateResponse<string>(HttpStatusCode.OK, "");
            }
            catch (Exception e)
            {
                DataProvider.RollbackTrans(tran);
                ExceptionHandler.Log(e);
                return null;
            }
        }

        void deleteOldRoles(string userId, SqlTransaction tran)
        {
            try
            {
                userRoleDT.DeleteViaCond("UserID = " + userId, tran);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string buildSiteMap(string[] roleIDs)
        {
            string result = @"<div class='main'><nav id = 'cbp-hrmenu' class='cbp-hrmenu'><ul>";
            AdmContextDT contextDT = new AdmContextDT();
            AdmRolecontextDT roleContextDT = new AdmRolecontextDT();
            string roleContextCond = " RoleID in (" + String.Join(",", roleIDs) + ")";
            string[] contextIDs = DataTableHelper.ExtractToStringArray(roleContextDT.GetByCond(roleContextCond), "ContextID");
            string contextCond = "ID in (" + String.Join(",", contextIDs) + ")";
            DataTable dtContexts = contextDT.GetByCond(contextCond);
            string[] rootIDs = DataTableHelper.ExtractToStringArray(dtContexts, "RootMap");
            result += buildRootNode(rootIDs, dtContexts);
            result += @"</ul> </nav></div>";
            return result;
        }
        static string buildRootNode(string[] rootIDs, DataTable dtContexts)
        {
            string result = "";
            AdmMapDT mapDT = new AdmMapDT();
            string mapCond = " ID in (" + string.Join(",", rootIDs) + ") ";
            DataTable dtMaps = mapDT.GetByCond(mapCond, "PathLevel, OrderNum ASC");
            foreach (DataRow row in dtMaps.Select("PathLevel=1"))
            {
                result += @" <li><a href='#'>" + row["Name"].ToString() + "</a>";
                DataRow[] childRows = mapDT.GetByCond("ParentID = " + row["ID"].ToString()).Select();
                result += @"<div class='cbp-hrsub'><div class='cbp-hrsub-inner'>";

                if (childRows.Length > 0)
                    foreach (DataRow childRow in childRows)
                    {
                        result += @"<div>";
                        result += " <h4>" + childRow["Name"].ToString() + "</h4><ul> ";
                        result += buildContextNode(row["Path"].ToString(), childRow["ID"].ToString(), dtContexts);
                        result += @"</ul></div>";
                    }
                else
                {
                    result += @"<div>";
                    result += @" <h4></h4><ul>";
                    result += buildContextNode(row["Path"].ToString(), row["ID"].ToString(), dtContexts);
                    result += @"</ul></div>";
                }
                result += @"</div></div></li>";
            }
            return result;
        }
        static string buildContextNode(string rootPath, string mapID, DataTable dtContext)
        {
            string result = "";
            DataRow[] contextRows = dtContext.Select("MapID=" + mapID);
            foreach (DataRow row in contextRows)
            {
                result += "<li><a href='../" + rootPath + row["DevName"].ToString() + "'>" + row["Name"] + "</a></li>";
            }
            return result;
        }
        HttpResponseMessage handleBRFailed(string message, SqlTransaction tran)
        {
            try
            {
                DataProvider.RollbackTrans(tran);
                return Request.CreateResponse<string>(HttpStatusCode.OK, message);
            }
            catch (Exception e)
            {
                return null;
                ExceptionHandler.Log(e);
            }
        }
    }
}