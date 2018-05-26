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
    public class GuarReturnOvrController : ApiController
    {
        GuarReturnDT guarReturnDT = new GuarReturnDT();
        GuarReturnDetailDT guarReturnDetailDT = new GuarReturnDetailDT();
        IBaseBR businessRule = BRFactory.GenerateBRObject(typeof(GuarReturnBR));
        [Route("GuarReturnOvr/Save")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Save(string guarReturnJson, string guarReturnDetailsJson)
        {
            string guarReturnId = "";
            string errMessage = "";
            GuarReturnContract guarReturnDTO = JsonConvert.DeserializeObject<GuarReturnContract>(guarReturnJson);
            GuarReturnDetailContract[] guarReturnDetailDTOs = JsonConvert.DeserializeObject<GuarReturnDetailContract[]>(guarReturnDetailsJson);
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                businessRule.RegistInstants(guarReturnDTO);
                if (guarReturnDTO.Id > 0)
                {
                    guarReturnId = guarReturnDT.Update(guarReturnDTO, tran);
                }
                else
                {
                    businessRule.RegistRule("Insert");
                    if (businessRule.CheckRules(out errMessage))
                        guarReturnId = guarReturnDT.Insert(guarReturnDTO, tran);
                    else
                        return handleBRFailed(errMessage, tran);
                }
                if (Converter.ToInt32(guarReturnId) > 0)
                {
                    deleteDetail(guarReturnId, tran);
                    foreach (GuarReturnDetailContract invoiceDetailDTO in guarReturnDetailDTOs)
                    {
                        invoiceDetailDTO.Guarreturnid = Converter.ToInt32(guarReturnId);
                        guarReturnDetailDT.Insert(invoiceDetailDTO, tran);
                    }
                }
                DataProvider.CommitTrans(tran);
            }
            catch (Exception e)
            {
                DataProvider.RollbackTrans(tran);
                ExceptionHandler.Log(e);
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, errMessage != string.Empty ? errMessage : guarReturnId);
        }

        [Route("GuarReturnOvr/GetDetail")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetDetail(string guarReturnId)
        {
            try
            {
                InvoiceDetailDT invDetailDT = new InvoiceDetailDT();
                DataTable dt = invDetailDT.GetGridData("GuarReturn", "guarReturnID =" + guarReturnId, " OrderNum ASC");
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dt));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        [Route("GuarReturnOvr/GetCode")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetCode()
        {
            try
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, CodeModel.GetGuarReturnCode());
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }

        void deleteDetail(string guarReturnId, SqlTransaction tran)
        {
            try
            {
                string todate = DateTime.Now.ToString("dd/MM/yyyy");
                guarReturnDetailDT.Update(new string[] { "Deleted", "DeletedOn" }, new string[] { "1", "convert(datetime,   '" + todate + "', 103)" }, "guarReturnID =" + guarReturnId, tran);
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
