using DTA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TnHSell.BR;
using TnHSell.DT;
using TnHSell.DTContract;
using TnHSell.Model;
using Util;

namespace _2.BL.Controllers
{
    public class StoExchangeOvrController : ApiController
    {
        StoExchangeDT exchangeDT = new StoExchangeDT();
        StoExchangeDetailDT exchangeDetailDT = new StoExchangeDetailDT();
        IBaseBR businessRule = BRFactory.GenerateBRObject(typeof(StoExchangeBR));
        [Route("StoExchangeOvr/Save")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Save(string exchangeJson, string exchangeDetailsJson)
        {
            string exchangeId = "";
            string errMessage = "";
            StoExchangeContract exchangeDTO = JsonConvert.DeserializeObject<StoExchangeContract>(exchangeJson);
            StoExchangeDetailContract[] exchangeDetailDTOs = JsonConvert.DeserializeObject<StoExchangeDetailContract[]>(exchangeDetailsJson);
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                businessRule.RegistInstants(exchangeDTO);
                if (exchangeDTO.Id > 0)
                {
                    exchangeId = exchangeDT.Update(exchangeDTO, tran);
                }
                else
                {
                    businessRule.RegistRule("Insert");
                    if (businessRule.CheckRules(out errMessage))
                        exchangeId = exchangeDT.Insert(exchangeDTO, tran);
                    else
                        return handleBRFailed(errMessage, tran);
                }
                if (Converter.ToInt32(exchangeId) > 0)
                {
                    foreach (StoExchangeDetailContract exchangeDetailDTO in exchangeDetailDTOs)
                    {
                        exchangeDetailDTO.Exchangeid = Converter.ToInt32(exchangeId);
                        exchangeDetailDT.Insert(exchangeDetailDTO, tran);
                        errMessage = StoreModel.Exchange(exchangeDTO, exchangeDetailDTO, tran);
                        if (errMessage != "")
                        {
                            DataProvider.RollbackTrans(tran);
                            return Request.CreateResponse<string>(HttpStatusCode.OK, errMessage);
                        }
                    }
                }
                DataProvider.CommitTrans(tran);
            }
            catch (Exception e)
            {
                DataProvider.RollbackTrans(tran);
                ExceptionHandler.Log(e);
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, errMessage != string.Empty ? errMessage : exchangeId);
        }

        [Route("StoExchangeOvr/GetDetail")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetDetail(string exchangeId)
        {
            try
            {
                InvoiceDetailDT invDetailDT = new InvoiceDetailDT();
                DataTable dt = invDetailDT.GetGridData("StoExchange","ExchangeID =" + exchangeId, " OrderNum ASC");
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dt));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }

        [Route("StoExchangeOvr/GetCode")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetCode()
        {
            try
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, CodeModel.GetStoreExchangeCode());
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
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
