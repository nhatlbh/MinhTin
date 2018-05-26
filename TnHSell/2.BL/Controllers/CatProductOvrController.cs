using DTA;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TnHSell.DT;
using TnHSell.DTContract;
using Util;

namespace TnHSell.Controller
{
    public partial class CatProductOvrController : ApiController
    {
        CatProductDT productDT = new CatProductDT();
        CatProductPriceDT priceDT = new CatProductPriceDT();
        [Route("CatProductOvr/GetProductPrice")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetProductPrice(string productId)
        {
            try
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(priceDT.GetProductPrice(productId)));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
        [Route("CatProductOvr/SaveProduct")]
        [HttpGet, HttpPost]
        public HttpResponseMessage SaveProduct(string productJson, string priceJson)
        {
            string productId = "";
            SqlTransaction tran = DataProvider.beginTrans();
            try
            {
                CatProductContract product = JsonConvert.DeserializeObject<CatProductContract>(productJson);
                CatProductPriceContract[] prices = JsonConvert.DeserializeObject<CatProductPriceContract[]>(priceJson);
                if (product.Id > 0)
                {
                    productId = productDT.Update(product, tran);
                }
                else
                {
                    productId = productDT.Insert(product, tran);
                }
                deleteOldPrice(productId, tran);
                foreach (CatProductPriceContract price in prices)
                {
                    price.Productid = Converter.ToInt32(productId);
                    priceDT.Insert(price, tran);
                }
                DataProvider.CommitTrans(tran);
            }
            catch (Exception e)
            {
                DataProvider.RollbackTrans(tran);
                ExceptionHandler.Log(e);
                return null;
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, productId);
        }
        void deleteOldPrice(string productId, SqlTransaction tran)
        {
            try
            {
                priceDT.DeleteViaCond(CatProductPriceContract.Columns[(int)CatProductPriceColumns.ProductID] + " = " + productId, tran);
            }
            catch (Exception e)
            { throw e; }
        }
    }
}
