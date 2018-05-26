using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TnHSell.DT;
using Util;

namespace TnHSell.Controllers
{
    public class StoreController : ApiController
    {
        [Route("Store/GetInventory")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetProductPrice(string productId, string storeId)
        {
            try
            {
                CatProductStoreDT storeDT = new CatProductStoreDT();
                DataTable dt = storeDT.GetByCond("ProductID=" + productId + " AND StoreID =" + storeId);
                return Request.CreateResponse<string>(HttpStatusCode.OK, JsonConvert.SerializeObject(dt));
            }
            catch (Exception e)
            {
                ExceptionHandler.Log(e);
                return null;
            }
        }
    }
}
