using System.IO;
using System;

//using context = DoubleCache.SystemWebHttpCache;
namespace VS_Master_API.Models
{
    public class ExceptionLogging
    {

        public ExceptionLogging() { }
        private static String ErrorlineNo = "", Errormsg = "", extype = "", ErrorLocation = "";

        public static void SendErrorToText(Exception ex)
        {
            var line = Environment.NewLine + Environment.NewLine;


            Errormsg = ex.GetType().Name.ToString();
            extype = ex.GetType().ToString();
            // exurl = context.Current.Request.Url.ToString();
            ErrorLocation = ex.Message.ToString();
            ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
            try
            {
                // \\ExceptionDetailsFile\\"
                string filepath = Environment.CurrentDirectory.ToString() + "VSM_API_log";  //Text File Path

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);

                }
                filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();

                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    string error = "Log Written Date:" + " " + DateTime.Now.ToString() + line + "Error Line No :" + " " + ErrorlineNo + line + "Error Message:" + " " + Errormsg + line + "Exception Type:" + " " + extype + line + "Error Location :" + " " + ErrorLocation + line + line;
                    sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                    sw.WriteLine("-------------------------------------------------------------------------------------");
                    sw.WriteLine(line);
                    sw.WriteLine(error);
                    sw.WriteLine("--------------------------------*End*------------------------------------------");
                    sw.WriteLine(line);
                    sw.Flush();
                    sw.Close();

                }

            }
            catch (Exception e)
            {
                e.ToString();

            }
        }
    }
}
