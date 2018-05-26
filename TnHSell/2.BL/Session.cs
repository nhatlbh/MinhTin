using System.Web;

namespace TnHSell.BL
{
    public class Session
    {
        public static object UserID
        {
            get
            {
                return HttpContext.Current.Session["UserId"] == null ? "" : HttpContext.Current.Session["UserId"];
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }
    }
}