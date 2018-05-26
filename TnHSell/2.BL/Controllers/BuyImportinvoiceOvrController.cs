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
    public class BuyImportinvoiceOvrController : ApiController
    {
        BuyImportinvoiceDT invoiceDT = new BuyImportinvoiceDT();
        BuyImportinvoiceDetailDT invoiceDetailDT = new BuyImportinvoiceDetailDT();
        IBaseBR businessRule = BRFactory.GenerateBRObject(typeof(BuyImportinvoiceBR));
        [Route("BuyImportinvoiceOvr/Save")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Save(string importInvoceJson, string invoiceDetailsJson)
        {
            string invoiceId = "";
            string errMessage = "";
            BuyImportinvoiceContract invoiceDTO = JsonConvert.DeserializeObject<BuyImportinvoiceContract>(importInvoceJson);
            BuyImportinvoiceDetailContract[] invoiceDetailDTOs = JsonConvert.DeserializeObject<BuyImportinvoiceDetailContract[]>(invoiceDetailsJson);
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                businessRule.RegistInstants(invoiceDTO);
                if (invoiceDTO.Id > 0)
                {
                    invoiceId = invoiceDT.Update(invoiceDTO, tran);
                }
                else
                {
                    businessRule.RegistRule("Insert");
                    if (businessRule.CheckRules(out errMessage))
                        invoiceId = invoiceDT.Insert(invoiceDTO, tran);
                    else
                        return handleBRFailed(errMessage, tran);
                }
                if (Converter.ToInt32(invoiceId) > 0)
                {
                    foreach (BuyImportinvoiceDetailContract invoiceDetailDTO in invoiceDetailDTOs)
                    {
                        invoiceDetailDTO.Importinvoiceid = Converter.ToInt32(invoiceId);
                        invoiceDetailDT.Insert(invoiceDetailDTO, tran);
                        StoreModel.Import(invoiceDTO, invoiceDetailDTO, tran);
                    }
                }
                DataProvider.CommitTrans(tran);
            }
            catch (Exception e)
            {
                DataProvider.RollbackTrans(tran);
                ExceptionHandler.Log(e);
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, errMessage != string.Empty ? errMessage : invoiceId);
        }

        [Route("BuyImportinvoiceOvr/GetDetail")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetDetail(string invoiceId)
        {
            try
            {
                InvoiceDetailDT invDetailDT = new InvoiceDetailDT();
                DataTable dt = invDetailDT.GetGridData("BuyImportInvoice", "ImportInvoiceID =" + invoiceId, " OrderNum ASC");
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dt));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }

        [Route("BuyImportinvoiceOvr/GetCode")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetCode()
        {
            try
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, CodeModel.GetImportInvoiceCode());
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
