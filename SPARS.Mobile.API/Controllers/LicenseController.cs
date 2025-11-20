using Newtonsoft.Json;
using SSS.BizLayer;
using SSS.Mobile.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace SSS.Mobile.API.Controllers
{
    [RoutePrefix("api/LicenseController")]
    public class LicenseController : ApiController
    {
        /// <summary>
        /// This method is used for Authnticate Users.
        /// </summary>
        [HttpGet]
        [Route("VerifyLicense")]
        public bool VerifyLicense()
        {
            bool l_Response = false;


            try
            {
                if (GlobalDeclarations.g_AllowedLogin == "Y")
                {
                    l_Response = true;
                }
                else
                {
                    l_Response = false;
                }

            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_Response = false;
                throw;
            }

            return l_Response;
        }

    }
}
