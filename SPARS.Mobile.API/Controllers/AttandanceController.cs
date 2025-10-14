using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using SSS.Mobile.API.Models;
using SSS.Mobile.API.Providers;
using SSS.Mobile.API.Results;
using System.Data;
using SSS.BizLayer;
using System.Net;
using SSS.Mobile.API.Models.SPARSToken;
using SSS.Mobile.API.Controllers.Application;
using SSS.Mobile.API.Filters;
using System.Web.Http.Filters;
using System.Xml;
using System.Web.Script.Serialization;
using System.Reflection;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Linq;
//using SPARS.AndroidScannerAPI.Models;


namespace SSS.Mobile.API.Controllers
{
    [AuthorizeUser]
    [RoutePrefix("api/Attandance")]
    public class AttandanceController : ServiceController
    {

        /// <summary>
        /// This method is used for Authnticate Users.
        /// </summary>
        [HttpPost]
        [Route("GetStudentAttandance")]
        public string GetStudentAttandance()
        {
            return "";
        }

    }
}
