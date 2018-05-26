using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using UI;

namespace TnHSell.UC
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static string RenderMenu()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58949/Session/RenderMenu");
            HttpResponseMessage response = client.GetAsync("?sessionKey=" + SessionHelper.SessionKey).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result.Replace(@"""", "") ;
            }
            else
            {
                Console.WriteLine("RenderMenu Error: {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return "";
            }
        }
    }
}