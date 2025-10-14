using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using SSS.BizLayer;
using SSS.Mobile.API.Controllers.Application;

namespace SSS.Mobile.API
{
    public static class AppPublicFunction
    {
        public static string GetAccessToken()
        {
            try
            {
                string l_AccessToken = String.Empty;
                string [] l_Values;
                var l_QSToken = HttpContext.Current.Request["AccessToken"];
                l_AccessToken = SPARSCookie.GetUserCookie();
                string l_Token = string.Empty;

                if (!string.IsNullOrEmpty(l_AccessToken))
                {
                    l_Token = string.IsNullOrEmpty(l_QSToken) ? l_AccessToken : l_QSToken;
                    return (l_Token);
                }

                l_Values = HttpContext.Current.Request.Headers.GetValues("AccessToken");
                if (!(l_Values == null))
                {
                    if ((l_Values.Length > 0))
                    {
                        l_AccessToken = l_Values[0];
                    }

                }

                if (string.IsNullOrEmpty(l_AccessToken))
                {
                    l_AccessToken = HttpContext.Current.Request["AccessToken"];
                }

                return l_AccessToken;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }

            return String.Empty;
        }
        public static string GetUserIP()
        {
            string VisitorsIPAddr = String.Empty;
            string host = Dns.GetHostName();
            string LocalHostaddress = Dns.GetHostByName(host).AddressList[0].ToString();
            // Dim ipAddress As IPAddress
            // Dim ipHostInfo As IPHostEntry = Dns.Resolve(Dns.GetHostName())
            // ipAddress = ipHostInfo.AddressList(0)
            if ((LocalHostaddress != String.Empty))
            {
                VisitorsIPAddr = LocalHostaddress;
            }
            else if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if ((HttpContext.Current.Request.UserHostAddress.Length != 0))
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }

            return VisitorsIPAddr;
        }
    }
}