using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShoppingCart.Common
{
    public class ErrorLogger
    {

        public void ErrorLog(Exception ex, string para = "")
        {
            string fileName = HttpContext.Current.Server.MapPath("\\ErrorLogFile\\");
            if (!Directory.Exists(fileName))
                System.IO.Directory.CreateDirectory(fileName);
            FileStream file = new FileStream(fileName + DateTime.Now.ToString("yyyyMMdd") + "-Error.txt", FileMode.Append, FileAccess.Write);
            if (File.Exists(fileName + DateTime.Now.ToString("yyyyMMdd") + "-Error.txt"))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine(System.Environment.NewLine);
                    writer.WriteLine("[Start Of Error Report]");
                    writer.WriteLine("Time Stamp\t:" + System.DateTime.Now);
                    writer.WriteLine("Machine Name\t:" + System.Environment.MachineName);
                    writer.WriteLine("Error Message\t:" + ex.Message);
                    System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(1);
                    System.Reflection.MethodBase mb = sf.GetMethod();
                    string methodName = sf.GetMethod().DeclaringType.ToString() + "." + mb.Name;
                    string stackTrace = ex.StackTrace;
                    writer.WriteLine("Stack Trace\t:" + stackTrace);
                    writer.WriteLine("Method Name\t:" + methodName);
                    writer.WriteLine("[End Of Error Report]");
                    writer.WriteLine(System.Environment.NewLine);
                    writer.Close();
                    file.Close();
                    file.Dispose();
                }
            }
        }
    }
}
