using System;
using System.IO;
using System.Web;

namespace Util
{
    public class ExceptionHandler
    {
        public static void Log(Exception e, bool pass = false, string moreInfo = "")
        {
            if (!pass)
            {
                string path = HttpContext.Current.Server.MapPath("~/logfile/") + "logfile.txt";
                moreInfo = moreInfo == "" ? "" : "Thông tin thêm: " + moreInfo;
                string error = String.Format(@"



[--------- {0:dd/MM/yyyy hh:mm:ss}
Error: {1}
StackTrace: {2} --------]

{3}


                    ", DateTime.Now, e.Message, e.StackTrace, moreInfo);
                try
                {
                    if (!File.Exists(path))
                    {
                        File.Create(path);
                    }
                    StreamReader srd = new StreamReader(path, System.Text.Encoding.UTF8);
                    string existError = srd.ReadToEnd();
                    srd.Close();
                    using (StreamWriter stw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
                    {
                        error = existError.Insert(0, error);
                        stw.Write(error);
                        stw.Close();
                    }
                }
                catch { };
            }
        }
    }
}
