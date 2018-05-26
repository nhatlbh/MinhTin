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
    public class BuySupplierReturnOvrController : ApiController
    {
        BuySupplierreturnDT suppReturnDT = new BuySupplierreturnDT();
        BuySupplierreturnDetailDT suppReturnDetailDT = new BuySupplierreturnDetailDT();
        IBaseBR businessRule = BRFactory.GenerateBRObject(typeof(BuySupplierreturnBR));
        [Route("BuySupplierReturnOvr/Save")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Save(string suppReturnJson, string suppReturnDetailsJson)
        {
            string suppReturnId = "";
            string errMessage = "";
            BuySupplierreturnContract suppReturnDTO = JsonConvert.DeserializeObject<BuySupplierreturnContract>(suppReturnJson);
            BuySupplierreturnDetailContract[] suppReturnDetailDTOs = JsonConvert.DeserializeObject<BuySupplierreturnDetailContract[]>(suppReturnDetailsJson);
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                businessRule.RegistInstants(suppReturnDTO);
                if (suppReturnDTO.Id > 0)
                {
                    suppReturnId = suppReturnDT.Update(suppReturnDTO, tran);
                }
                else
                {
                    businessRule.RegistRule("Insert");
                    if (businessRule.CheckRules(out errMessage))
                        suppReturnId = suppReturnDT.Insert(suppReturnDTO, tran);
                    else
                        return handleBRFailed(errMessage, tran);
                }
                if (Converter.ToInt32(suppReturnId) > 0)
                {
                    foreach (BuySupplierreturnDetailContract invoiceDetailDTO in suppReturnDetailDTOs)
                    {
                        invoiceDetailDTO.Supplierreturnid = Converter.ToInt32(suppReturnId);
                        suppReturnDetailDT.Insert(invoiceDetailDTO, tran);
                        //StoreModel.Import(invoiceDetailDTO.Productid.ToString(), invoiceDetailDTO.Quantity, invoiceDetailDTO.Price, tran);
                    }
                }
                DataProvider.CommitTrans(tran);
            }
            catch (Exception e)
            {
                DataProvider.RollbackTrans(tran);
                ExceptionHandler.Log(e);
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, errMessage != string.Empty ? errMessage : suppReturnId);
        }

        [Route("BuySupplierReturnOvr/GetDetail")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetDetail(string suppReturnId)
        {
            try
            {
                InvoiceDetailDT invDetailDT = new InvoiceDetailDT();
                DataTable dt = invDetailDT.GetGridData("BuySupplierReturn", "SupplierReturnID =" + suppReturnId, " OrderNum ASC");
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dt));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        [Route("BuySupplierReturnOvr/GetCode")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetCode()
        {
            try
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, CodeModel.GetSupplierReturnCode());
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
