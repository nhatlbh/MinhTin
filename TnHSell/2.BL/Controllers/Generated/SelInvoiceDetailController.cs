﻿using System;
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
   public partial class SelInvoiceDetailController: ApiController
    {
        SelInvoiceDetailDT dta = new SelInvoiceDetailDT();
        IBaseBR businessRule = BRFactory.GenerateBRObject(typeof(SelInvoiceDetailBR));
        [Route("SelInvoiceDetail/GetAll")]
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
        
        [Route("SelInvoiceDetail/GetGridData")]
        [HttpGet, HttpPost]
         public HttpResponseMessage GetGridData(string sessionKey,string cond = "", string order="")
        {
            try
            {
              return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dta.GetGridData(SelInvoiceDetailDFR.GetGridData(sessionKey, cond, out order), order))); 
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
      
        [Route("SelInvoiceDetail/GetByID")]
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
        
        [Route("SelInvoiceDetail/Save")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Save(string selinvoicedetailJson)
        {
          string errMessage = string.Empty;
          try
            {  SelInvoiceDetailContract selinvoicedetail = JsonConvert.DeserializeObject<SelInvoiceDetailContract>(selinvoicedetailJson);           
                businessRule.RegistInstants(selinvoicedetail);
                if (selinvoicedetail.Id == 0)
                {
                    businessRule.RegistRule("Insert");
                    if (businessRule.CheckRules(out errMessage))
                        return  Request.CreateResponse<string>(HttpStatusCode.OK,dta.Insert(selinvoicedetail));
                    else
                        return handleBRFailed(errMessage);
                }
                else
                {
                    businessRule.RegistRule("Update");
                    if (businessRule.CheckRules(out errMessage))
                        return  Request.CreateResponse<string>(HttpStatusCode.OK,dta.Update(selinvoicedetail));
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

        [Route("SelInvoiceDetail/Delete")]
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
        
        [Route("SelInvoiceDetail/GetComboboxData")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetComboboxData(string sessionKey,string cond="", string order="")
        {
          try
            {
                string columns = "";
                cond = SelInvoiceDetailDFR.GetComboboxData(sessionKey,out columns,cond, out order);
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


