using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Data;
using TnHSell.DTContract;
using TnHSell.DT;
using Util;
using TnHSell.BR;
using DTA;
using System.Data.SqlClient;
using TnHSell.DFR;

namespace TnHSell.Controller
{
   public partial class CatManagementgroupController: ApiController
    {
        CatManagementgroupDT dta = new CatManagementgroupDT();
        IBaseBR businessRule = BRFactory.GenerateBRObject(typeof(CatManagementgroupBR));
        [Route("CatManagementgroup/GetAll")]
        [HttpGet, HttpPost]
         public HttpResponseMessage GetAll()
        {
            try
            {
              return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dta.GetAll())); 
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        
        [Route("CatManagementgroup/GetGridData")]
        [HttpGet, HttpPost]
         public HttpResponseMessage GetGridData(string sessionKey,string cond = "", string order="")
        {
            try
            {
              return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dta.GetGridData(CatManagementgroupDFR.GetGridData(sessionKey, cond, out order), order))); 
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
      
        [Route("CatManagementgroup/GetByID")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetByID(string id)
        {
            try
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dta.GetByID(id))); 
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        
        [Route("CatManagementgroup/Save")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Save(string catmanagementgroupJson)
        {
          string errMessage = string.Empty;
          try
            {  CatManagementgroupContract catmanagementgroup = JsonConvert.DeserializeObject<CatManagementgroupContract>(catmanagementgroupJson);           
                businessRule.RegistInstants(catmanagementgroup);
                if (catmanagementgroup.Id == 0)
                {
                    businessRule.RegistRule("Insert");
                    if (businessRule.CheckRules(out errMessage))
                        return  Request.CreateResponse<string>(HttpStatusCode.OK,dta.Insert(catmanagementgroup));
                    else
                        return handleBRFailed(errMessage);
                }
                else
                {
                    businessRule.RegistRule("Update");
                    if (businessRule.CheckRules(out errMessage))
                        return  Request.CreateResponse<string>(HttpStatusCode.OK,dta.Update(catmanagementgroup));
                    else
                        return handleBRFailed(errMessage);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return  Request.CreateResponse<string>(HttpStatusCode.OK,"Có lỗi xảy ra trên chương trình.");
            }
        }

        [Route("CatManagementgroup/Delete")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Delete(string id)
        {
          try
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, dta.Delete(id).ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return Request.CreateResponse<string>(HttpStatusCode.OK,"");
            }
        }
        
        [Route("CatManagementgroup/GetComboboxData")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetComboboxData(string sessionKey,string cond="", string order="")
        {
          try
            {
                string columns = "";
                cond = CatManagementgroupDFR.GetComboboxData(sessionKey,out columns,cond, out order);
                return Request.CreateResponse<string>(HttpStatusCode.OK,JsonConvert.SerializeObject(dta.GetComboboxData(columns, cond, order)));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        
        HttpResponseMessage handleBRFailed(string message, SqlTransaction tran=null)
        {
            if(tran != null)
            {
                DataProvider.RollbackTrans(tran);
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, message);
        }
    }
}


