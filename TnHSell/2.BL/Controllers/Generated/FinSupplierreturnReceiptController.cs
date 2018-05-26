using DTA;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TnHSell.BR;
using TnHSell.DFR;
using TnHSell.DT;
using TnHSell.DTContract;
using Util;

namespace TnHSell.Controller
{
    public partial class FinSupplierreturnReceiptController: ApiController
    {
        FinSupplierreturnReceiptDT dta = new FinSupplierreturnReceiptDT();
        IBaseBR businessRule = BRFactory.GenerateBRObject(typeof(FinSupplierreturnReceiptBR));
        [Route("FinSupplierreturnReceipt/GetAll")]
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
        
        [Route("FinSupplierreturnReceipt/GetGridData")]
        [HttpGet, HttpPost]
         public HttpResponseMessage GetGridData(string sessionKey,string cond = "", string order="")
        {
            try
            {
              return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dta.GetGridData(FinSupplierreturnReceiptDFR.GetGridData(sessionKey, cond, out order), order))); 
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
      
        [Route("FinSupplierreturnReceipt/GetByID")]
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
        
        [Route("FinSupplierreturnReceipt/Save")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Save(string finsupplierreturnreceiptJson)
        {
          string errMessage = string.Empty;
          try
            {  FinSupplierreturnReceiptContract finsupplierreturnreceipt = JsonConvert.DeserializeObject<FinSupplierreturnReceiptContract>(finsupplierreturnreceiptJson);           
                businessRule.RegistInstants(finsupplierreturnreceipt);
                if (finsupplierreturnreceipt.Id == 0)
                {
                    businessRule.RegistRule("Insert");
                    if (businessRule.CheckRules(out errMessage))
                        return  Request.CreateResponse<string>(HttpStatusCode.OK,dta.Insert(finsupplierreturnreceipt));
                    else
                        return handleBRFailed(errMessage);
                }
                else
                {
                    businessRule.RegistRule("Update");
                    if (businessRule.CheckRules(out errMessage))
                        return  Request.CreateResponse<string>(HttpStatusCode.OK,dta.Update(finsupplierreturnreceipt));
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

        [Route("FinSupplierreturnReceipt/Delete")]
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
        
        [Route("FinSupplierreturnReceipt/GetComboboxData")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetComboboxData(string sessionKey,string cond="", string order="")
        {
          try
            {
                string columns = "";
                cond = FinSupplierreturnReceiptDFR.GetComboboxData(sessionKey,out columns,cond, out order);
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


