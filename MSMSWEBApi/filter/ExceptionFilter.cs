using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using System;

namespace MSMSWEBApi.filter
{
    public class MyExceptionFilter:ExceptionFilterAttribute
    {
        public static string ErrorlineNo, Errormsg, extype, ErrorLocation;
        public static void SendErrorToText(Exception ex)
        {
            var line = Environment.NewLine + Environment.NewLine;

            ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
            Errormsg = ex.GetType().Name.ToString();
            extype = ex.GetType().ToString();
            ErrorLocation = ex.Message.ToString();



            try
            {
                System.IO.Directory.GetCurrentDirectory();
                string Filepath = Path.GetFullPath("ErrorLogFile/");

                if (!Directory.Exists(Filepath))
                {
                    Directory.CreateDirectory(Filepath);
                }
                Filepath = Filepath + "ErrorLog-" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                if (!File.Exists(Filepath))
                {
                    File.Create(Filepath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(Filepath))
                {
                    string error = "Log Written Date:" + " " + DateTime.Now.ToString() + line + "Error Line No :" + " " + ErrorlineNo + line + "Error Message : " + Errormsg + " Error type: " + extype + " Error Location : " + ErrorLocation;
                    sw.WriteLine("----------Exception Details on " + " " + DateTime.Now.ToString() + "---------------------");
                    sw.WriteLine("----------------------------------------------------------------------------------------");
                    sw.WriteLine(line);
                    sw.WriteLine(error);
                    sw.WriteLine("----------------------End------------------------------");
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



        public override void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;
            SendErrorToText(ex);
            context.Result = new ObjectResult(ex.Message)
            {
                StatusCode = 400
            };
            context.ExceptionHandled = true;
        }
    }
}
