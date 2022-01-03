using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Common
{
    public static class Elog
    {
        public static void save(object obj, Exception ex)
        {
            string fecha = System.DateTime.Now.ToString("yyyyMMdd");
            string hora = System.DateTime.Now.ToString("HH:mm:ss");
            string path = HttpContext.Current.Request.MapPath("~/log/" + fecha + ".txt");

            if (!Directory.Exists(HttpContext.Current.Request.MapPath("~/log/")))
            {
                Directory.CreateDirectory(HttpContext.Current.Request.MapPath("~/log/"));
            }

            StreamWriter sw = new StreamWriter(path, true);

            StackTrace stacktrace = new StackTrace();
            sw.WriteLine(obj.GetType().FullName + " " + hora);
            sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name + " - " + ex.Message);
            sw.WriteLine("");

            sw.Flush();
            sw.Close();
        }
    }
}
