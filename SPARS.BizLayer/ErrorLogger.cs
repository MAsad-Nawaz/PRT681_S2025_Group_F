using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SSS.BizLayer
{
    public class ErrorLogger
    {
        private static readonly object _LockObj = new object();
        public static void WriteToErrorLog(string msg, string stkTrace)
        {
            try
            {
                System.DateTime l_ServerDate = DateTime.Now;
                string l_FileName = l_ServerDate.Month + "-" + l_ServerDate.Day + "-" + l_ServerDate.Year + "-" + GlobalDeclarations.g_UserID;
                string l_Path   = Path.Combine(GlobalDeclarations.g_ApplicationLogPath, "BizLayer");

                lock (_LockObj)
                {
                    if (!Directory.Exists(l_Path))
                    {
                        System.IO.Directory.CreateDirectory(l_Path);
                    }

                    StreamWriter s1 = new StreamWriter(new FileStream(Path.Combine(l_Path, l_FileName + "_Errors.txt"), FileMode.Append, FileAccess.Write));

                    s1.Write("Date/Time: " + DateTime.Now.ToString() + Environment.NewLine);
                    s1.Write("Message: " + msg + Environment.NewLine);
                    s1.Write("StackTrace: " + stkTrace + Environment.NewLine);
                    s1.Write("===========================================================================================" + Environment.NewLine);

                    s1.Close();
                }
            }
            catch (Exception)
            {
                
                
            }
            
        }
    }

    public class QueryLogger
    {
        private static readonly object _LockObj = new object();

        public static void WriteToQueryLog(string query, string timeSpan = "")
        {
            try
            {
                System.DateTime l_ServerDate = DateTime.Now;
                string l_FileName = l_ServerDate.Month + "-" + l_ServerDate.Day + "-" + l_ServerDate.Year + "-" + GlobalDeclarations.g_UserID;
                string l_Path = Path.Combine(GlobalDeclarations.g_ApplicationLogPath, "BizLayer");

                lock (_LockObj)
                {
                    if (!Directory.Exists(l_Path))
                    {
                        Directory.CreateDirectory(l_Path);
                    }

                    using (StreamWriter s1 = new StreamWriter(new FileStream(Path.Combine(l_Path, l_FileName + "_Queries.txt"), FileMode.Append, FileAccess.Write)))
                    {
                        if (string.IsNullOrEmpty(timeSpan))
                        {
                            s1.Write(DateTime.Now.ToString() + ": " + query + Environment.NewLine);
                        }
                        else
                        {
                            s1.Write("\\*" + DateTime.Now.ToString() + " TimeSpan: " + timeSpan + " ms *\\: " + query + Environment.NewLine);
                        }
                    }
                }
            }
            catch (Exception)
            {
                
               
            }
           
        }
    }
}
