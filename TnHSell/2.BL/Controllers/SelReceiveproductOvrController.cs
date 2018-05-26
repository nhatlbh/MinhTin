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

namespace TnHSell.Controllers
{
    public class SelReceiveproductOvrController : ApiController
    {
        SelReceiveproductDT recvProductDT = new SelReceiveproductDT();
        SelReceiveproductDetailDT rvcProductDetailDT = new SelReceiveproductDetailDT();
        IBaseBR businessRule = BRFactory.GenerateBRObject(typeof(SelReceiveproductBR));
        [Route("SelReceiveproductOvr/Save")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Save(string recvProductJson, string recvProductDetailsJson)
        {
            string recvProductId = "";
            string errMessage = "";
            SelReceiveproductContract recvProductDTO = JsonConvert.DeserializeObject<SelReceiveproductContract>(recvProductJson);
            SelReceiveproductDetailContract[] suppReturnDetailDTOs = JsonConvert.DeserializeObject<SelReceiveproductDetailContract[]>(recvProductDetailsJson);
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                businessRule.RegistInstants(recvProductDTO);
                if (recvProductDTO.Id > 0)
                {
                    recvProductId = recvProductDT.Update(recvProductDTO, tran);
                }
                else
                {
                    businessRule.RegistRule("Insert");
                    if (businessRule.CheckRules(out errMessage))
                        recvProductId = recvProductDT.Insert(recvProductDTO, tran);
                    else
                        return handleBRFailed(errMessage, tran);
                }
                if (Converter.ToInt32(recvProductId) > 0)
                {
                    foreach (SelReceiveproductDetailContract invoiceDetailDTO in suppReturnDetailDTOs)
                    {
                        invoiceDetailDTO.Receiveproductid = Converter.ToInt32(recvProductId);
                        rvcProductDetailDT.Insert(invoiceDetailDTO, tran);
                        StoreModel.Return(recvProductDTO,invoiceDetailDTO, tran);
                    }
                }
                DataProvider.CommitTrans(tran);
            }
            catch (Exception e)
            {
                DataProvider.RollbackTrans(tran);
                ExceptionHandler.Log(e);
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, errMessage != string.Empty ? errMessage : recvProductId);
        }
        [Route("SelReceiveproductOvr/GetDetail")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetDetail(string recvProductId)
        {
            try
            {
                InvoiceDetailDT invDetailDT = new InvoiceDetailDT();
                DataTable dt = invDetailDT.GetGridData("SelReceiveproduct", "ReceiveProductID =" + recvProductId, " OrderNum ASC");
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dt));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        [Route("SelReceiveproductOvr/GetCode")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetCode()
        {
            try
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, CodeModel.GetReceiveProductCode());
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
