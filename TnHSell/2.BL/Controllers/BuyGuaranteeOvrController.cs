using DTA;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TnHSell.BR;
using TnHSell.DT;
using TnHSell.DTContract;
using TnHSell.Model;
using Util;

namespace TnHSell.Controllers
{
    public class BuyGuaranteeOvrController : ApiController
    {
        BuyGuaranteeDT guaranteeDT = new BuyGuaranteeDT();
        BuyGuaranteeDetailDT guaranteeDetailDT = new BuyGuaranteeDetailDT();
        IBaseBR businessRule = BRFactory.GenerateBRObject(typeof(BuyGuaranteeBR));
        [Route("BuyGuaranteeOvr/Save")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Save(string guaranteeJson, string guaranteeDetailsJson)
        {
            string guaranteeId = "";
            string errMessage = "";
            BuyGuaranteeContract guaranteeDTO = JsonConvert.DeserializeObject<BuyGuaranteeContract>(guaranteeJson);
            BuyGuaranteeDetailContract[] guaranteeDetailDTOs = JsonConvert.DeserializeObject<BuyGuaranteeDetailContract[]>(guaranteeDetailsJson);
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                businessRule.RegistInstants(guaranteeDTO);
                if (guaranteeDTO.Id > 0)
                {
                    guaranteeId = guaranteeDT.Update(guaranteeDTO, tran);
                }
                else
                {
                    businessRule.RegistRule("Insert");
                    if (businessRule.CheckRules(out errMessage))
                        guaranteeId = guaranteeDT.Insert(guaranteeDTO, tran);
                    else
                        return handleBRFailed(errMessage, tran);
                }
                if (Converter.ToInt32(guaranteeId) > 0)
                {
                    deleteDetail(guaranteeId,tran);
                    foreach (BuyGuaranteeDetailContract invoiceDetailDTO in guaranteeDetailDTOs)
                    {
                        invoiceDetailDTO.Guaranteeid = Converter.ToInt32(guaranteeId);
                        guaranteeDetailDT.Insert(invoiceDetailDTO, tran);
                    }
                }
                DataProvider.CommitTrans(tran);
            }
            catch (Exception e)
            {
                DataProvider.RollbackTrans(tran);
                ExceptionHandler.Log(e);
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, errMessage != string.Empty ? errMessage : guaranteeId);
        }

        [Route("BuyGuaranteeOvr/GetDetail")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetDetail(string guaranteeId)
        {
            try
            {
                InvoiceDetailDT invDetailDT = new InvoiceDetailDT();
                DataTable dt = invDetailDT.GetGridData("BuyGuarantee", "GuaranteeID =" + guaranteeId, " OrderNum ASC");
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dt));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        [Route("BuyGuaranteeOvr/GetCode")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetCode()
        {
            try
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, CodeModel.GetGuaranteeCode());
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }

        void deleteDetail(string guaranteeId, SqlTransaction tran)
        {
            try
            {
                string todate = DateTime.Now.ToString("dd/MM/yyyy");
                guaranteeDetailDT.Update(new string[] {"Deleted","DeletedOn" },new string[] {"1", "convert(datetime,   '" + todate + "', 103)" }, "GuaranteeID =" + guaranteeId, tran);
            }
            catch (Exception e)
            {
                throw e;
            }
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
                ExceptionHandler.Log(e);
                return null;
            }
        }
    }
}
