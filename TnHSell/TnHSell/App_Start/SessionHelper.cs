using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI
{
    public class SessionHelper
    {
        public static string SessionKey
        {
            get
            {
                try
                {
                    return HttpContext.Current.Session["SessionKey"].ToString();
                }
                catch (Exception e)
                {
                    return "";
                }
            }
            set
            {
                if (HttpContext.Current.Session["SessionKey"] == null || HttpContext.Current.Session["SessionKey"].ToString() == string.Empty)
                {
                    HttpContext.Current.Session["SessionKey"] = value;
                }
            }
        }

    }
}