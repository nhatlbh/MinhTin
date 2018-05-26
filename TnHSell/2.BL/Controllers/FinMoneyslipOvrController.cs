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
using TnHSell.DT;
using TnHSell.DTContract;
using TnHSell.Model;
using Util;

namespace TnHSell.Controllers
{
    public class FinMoneyslipOvrController : ApiController
    {
        FinMoneyslipDT moneyslipDT = new FinMoneyslipDT();
        FinReceivepaymentDT revPaymentDT = new FinReceivepaymentDT();
        FinImportpaymentDT impPaymentDT = new FinImportpaymentDT();
        [Route("FinMoneyslipOvr/Save")]
        [HttpGet, HttpPost]
        public HttpResponseMessage Save(string moneyslipJson, string moneyslipDetailJson)
        {
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                FinMoneyslipContract moneyslipDTO = JsonConvert.DeserializeObject<FinMoneyslipContract>(moneyslipJson);
                int moneyslipId = moneyslipDTO.Id;
                if (moneyslipId == 0)
                {
                    {
                        moneyslipId = Converter.ToInt32(moneyslipDT.Insert(moneyslipDTO, tran));
                    }
                    if (moneyslipDTO.Type == "1")
                    {
                        SaveImportPayment(moneyslipId, moneyslipDetailJson, tran);
                    }
                   else if (moneyslipDTO.Type == "2")
                    {
                        SaveSuppReceipt(moneyslipId, moneyslipDetailJson, tran);
                    }
                }
                tran.Commit();
                return Request.CreateResponse<string>(HttpStatusCode.OK, moneyslipId.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                tran.Rollback();
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Lỗi: Không lưu thành công."); ;
            }
        }

        [Route("FinMoneyslipOvr/GetDetail")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetDetail(string moneyslipId)
        {
            try
            {
                MoneySlipDetailDT mslDetailDT = new MoneySlipDetailDT();
                DataTable dtReceipt = moneyslipDT.GetByCond("ID=" + moneyslipId);
                DataTable dtDetail = new DataTable();
                if (dtReceipt != null)
                {
                    if (dtReceipt.Rows[0]["Type"].ToString() == "1")
                    {
                        dtDetail = mslDetailDT.GetImportPayment(moneyslipId);
                    }
                    else if (dtReceipt.Rows[0]["Type"].ToString() == "2")
                    {
                        dtDetail = mslDetailDT.GetReceivePayment(moneyslipId);
                    }
                }
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dtDetail));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Lỗi: Không đọc được chi tiết phiếu thu."); ;
            }
        }

        [Route("FinMoneyslipOvr/GetImportInvoice")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetImportInvoice(string supplierId)
        {
            try
            {
                MoneySlipDetailDT mslDetailDT = new MoneySlipDetailDT();
                DataTable dt = mslDetailDT.GetImportInvoice("Cat_SupplierID=" + supplierId);
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dt));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        [Route("FinMoneyslipOvr/GetReceiveProduct")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetReceiveProduct(string customerId)
        {
            try
            {
                MoneySlipDetailDT mslDetailDT = new MoneySlipDetailDT();
                DataTable dt = mslDetailDT.GetReceiveProduct("CustomerId=" + customerId);
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dt));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }


        [Route("FinMoneyslipOvr/GetCode")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetCode()
        {
            try
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, CodeModel.GetMoneySlipCode());
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        void SaveImportPayment(int moneyslipId, string invPaymentJson, SqlTransaction tran)
        {
            try
            {
                BuyImportinvoiceDT imporInvDT = new BuyImportinvoiceDT();
                List<FinImportpaymentContract> invPayments = JsonConvert.DeserializeObject<List<FinImportpaymentContract>>(invPaymentJson);
                foreach (FinImportpaymentContract invPayment in invPayments)
                {
                    invPayment.Moneyslipid = moneyslipId;
                    imporInvDT.Update(new string[] { " TotalDebt" }, new string[] { " TotalDebt-" + invPayment.Total }, " ID=" + invPayment.Importinvoiceid, tran);
                    impPaymentDT.Insert(invPayment, tran);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        void SaveSuppReceipt(int moneyslipId, string invPaymentJson, SqlTransaction tran)
        {
            try
            {
                SelReceiveproductDT  rcvProductDT = new SelReceiveproductDT();
                List<FinReceivepaymentContract> rcvPayments = JsonConvert.DeserializeObject<List<FinReceivepaymentContract>>(invPaymentJson);
                foreach (FinReceivepaymentContract rcvPayment in rcvPayments)
                {
                    rcvPayment.Moneyslipid = moneyslipId;
                    rcvProductDT.Update(new string[] { " TotalReturn" }, new string[] { " TotalReturn-" + rcvPayment.Total }, " ID=" + rcvPayment.Receiveproductid);
                    revPaymentDT.Insert(rcvPayment, tran);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
