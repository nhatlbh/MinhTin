using DTA;
using System.Data;

namespace TnHSell.DT
{
    public partial class CatProductPriceDT
    {
        public DataTable GetProductPrice(string productId)
        {
            string query = string.Format(@"SELECT io.ID, io.Code, io.Name, ISNULL(price.Price,0) as Price
                            FROM Cat_IOCode io 
							LEFT JOIN ( SELECT * FROM Cat_Product_Price pr WHERE pr.ProductID={0}) price 
                            ON io.ID=price.IOCodeID ", productId);
            return DataProvider.ExecuteQuery(query);
        }
    }
}
