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
    [RoutePrefix("api/Login")]
    public class LoginController : ServiceController
    {       

        #region LoginScreen

            /// <summary>
            /// This method is used for Authnticate Users.
            /// </summary>
            [HttpPost]
            [Route("VerifyUsers")]
            public RequestData<WarehouseResponse> VerifyUsers()
            {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            int l_RequestID = 0;
            string l_ResponseJson = string.Empty;
            MessageResponse l_MessageResponse = new MessageResponse();
            RequestData<WarehouseResponse> l_WarehouseResponse = new RequestData<WarehouseResponse>();
            l_WarehouseResponse.RequestResults.ResultDetails = new WarehouseResponse();

            try
            {
                l_RequestID = PublicFunction.SMARequestLog(l_UserNo.ToString(), MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_WarehouseResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_WarehouseResponse.RequestResults.ResultDetails = l_CommonFunctions.GetWarehouse(l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<WarehouseResponse>(l_WarehouseResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_WarehouseResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<WarehouseResponse>(l_WarehouseResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured, ex.Message);
                throw;
            }

            return l_WarehouseResponse;
        }

        /// <summary>
        /// This method is used to get list of warehouses against user.
        /// </summary>
        [HttpPost]
        [Route("LogOut")]
        public RequestData<WarehouseResponse> LogOut()
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            int l_RequestID = 0;
            string l_ResponseJson = string.Empty;
            MessageResponse l_MessageResponse = new MessageResponse();
            RequestData<WarehouseResponse> l_WarehouseResponse = new RequestData<WarehouseResponse>();
            l_WarehouseResponse.RequestResults.ResultDetails = new WarehouseResponse();

            //try
            //{
            //    l_RequestID = PublicFunction.SMARequestLog(l_UserNo.ToString(), MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
            //    l_WarehouseResponse.RequestHeader.Id = l_RequestID.ToString();
            //    l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
            //    l_WarehouseResponse.RequestResults.ResultDetails = l_CommonFunctions.GetWarehouse(l_UserNo, ref l_MessageResponse);
            //    l_CommonFunctions.SetResponseType<WarehouseResponse>(l_WarehouseResponse, l_MessageResponse);
            //    l_ResponseJson = JsonConvert.SerializeObject(l_WarehouseResponse);
            //    PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            //}
            //catch (Exception ex)
            //{
            //    ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            //    l_CommonFunctions.SetResponseType<WarehouseResponse>(l_WarehouseResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured, ex.Message);
            //    throw;
            //}

            return l_WarehouseResponse;
        }

        #endregion


    }
}
