using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SSS.BizLayer
{
    class DSN
    {
        [DllImport("ODBCCP32.DLL")]
        private static extern int SQLConfigDataSource(int hwndParent, int ByValfRequest, string lpszDriver, string lpszAttributes);

        private const int vbAPINull = 0;

        //  NULL Pointer
        private const short ODBC_ADD_SYS_DSN = 4;

        //  Add data source
        private const short ODBC_REMOVE_SYS_DSN = 6;

        public static MultiItem GetDSNInfo(string DSN)
        {
            MultiItem l_MultiItem = null;
            try
            {
                Microsoft.Win32.RegistryKey key;

                key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(("SOFTWARE\\ODBC\\ODBC.INI\\" + DSN));
                if ((key == null))
                {
                    key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(("Software\\ODBC\\ODBC.INI\\" + DSN));
                    if ((key == null))
                    {
                        // TODO: Exit Function: Warning!!! Need to return the value
                        return l_MultiItem;
                    }

                }

                l_MultiItem.ID = (string)key.GetValue("Server");
                l_MultiItem.Value = (string)key.GetValue("Database");
                key.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return l_MultiItem;
        }

        public static bool SetDSNInfo(string DSN, string DbName)
        {
            bool l_Process = false;
            try
            {
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(("SOFTWARE\\ODBC\\ODBC.INI\\" + DSN));
                if ((key == null))
                {
                    key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(("Software\\ODBC\\ODBC.INI\\" + DSN));
                    if ((key == null))
                    {
                        // TODO: Exit Function: Warning!!! Need to return the value
                        return l_Process;
                    }

                }

                key.SetValue("Database", DbName);
                key.Close();
                l_Process = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return l_Process;
        }

        public static bool AddDSN(string DataSourceName, string DatabaseName, string Description, string LastUser, string Server)
        {
            bool l_Process = false;
            try
            {
                string DriverPath;
                string DriverName = "SQL Server";
                Microsoft.Win32.RegistryKey key;
               
                key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(("SOFTWARE\\ODBC\\ODBC.INI\\" + DataSourceName));
                if (!(key == null))
                {
                    key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(("Software\\ODBC\\ODBC.INI\\" + DataSourceName));
                    if (!(key == null))
                    {
                        // TODO: Exit Function: Warning!!! Need to return the value
                        return l_Process;
                    }

                }

                key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\ODBC\\ODBCINST.INI\\SQL Server");
                if ((key == null))
                {
                    // TODO: Exit Function: Warning!!! Need to return the value
                    return l_Process;
                }

                DriverPath = (string)key.GetValue("Driver");
                key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(("SOFTWARE\\ODBC\\ODBC.INI\\" + DataSourceName));
                key.SetValue("Database", DatabaseName);
                key.SetValue("Description", Description);
                key.SetValue("Driver", DriverPath);
                key.SetValue("LastUser", LastUser);
                key.SetValue("Server", Server);
                key.Close();
                key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources", true);
                if ((key == null))
                {
                    key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources");
                }

                key.SetValue(DataSourceName, DriverName);
                key.Close();
                l_Process = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return l_Process;
        }

        public static bool CreateUserDSN(string DataSourceName, string DatabaseName, string Description, string LastUser, string Server)
        {
            int intRet;
            string Driver;
            string Attributes;
            bool l_Process = false;
            
            Driver = "SQL Server";
            Attributes = ("SERVER="
                        + (Server + ("" + '\0')));
            Attributes = (Attributes + ("DSN="
                        + (DataSourceName + ("" + '\0'))));
            Attributes = (Attributes + ("DATABASE="
                        + (DatabaseName + ("" + '\0'))));
            // To show dialog, use Form1.Hwnd instead of vbAPINull.
            intRet = SQLConfigDataSource(vbAPINull, ODBC_ADD_SYS_DSN, Driver, Attributes);
            if ((intRet != 0))
            {
                l_Process = true;
            }

            return l_Process;
        }

        public static bool RemoveUserDSN(string DataSourceName, string DatabaseName, string Description, string LastUser, string Server)
        {
            string Driver;
            string Attributes;
            bool l_Process = false;
            Driver = "SQL Server";
            Attributes = ("SERVER="
                        + (Server + ("" + '\0')));
            Attributes = (Attributes + ("DSN="
                        + (DataSourceName + ("" + '\0'))));
            Attributes = (Attributes + ("DATABASE="
                        + (DatabaseName + ("" + '\0'))));
            // To show dialog, use Form1.Hwnd instead of vbAPINull.
            SQLConfigDataSource(0, ODBC_REMOVE_SYS_DSN, Driver, Attributes);
            l_Process = true;
            return l_Process;
        }
    }
}
