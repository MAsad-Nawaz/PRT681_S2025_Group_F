using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSS.BizLayer;
using System.IdentityModel.Tokens;
using System.ServiceModel.Security.Tokens;
using Newtonsoft.Json;
using System.Security.Claims;
using SSS.Mobile.API.Controllers.Application;
using System.IdentityModel.Protocols.WSTrust;

namespace SSS.Mobile.API.Models.SPARSToken
{
    public class SPARSUserToken
    {

        public int UserNo;

        public string AccessTokenId;

        public DateTime ExpireTime;

        public DateTime TokenIssueDateTime;
    }
    public static class SPARSToken
    {
        static List<SPARSUserToken> m_UserTokenList = new List<SPARSUserToken>();
        static byte[] m_SecurityKey = GetBytes(GlobalDeclarations.g_SecurityKey);

        private static byte[] GetBytes(string str)
        {
           
            if (string.IsNullOrEmpty(str))
            { 
                return null;
            }

            byte[] bytes = new byte[] 
            {
                (byte)((str.Length * 2) - 1)
            };

            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;

        }

        private static bool AddUserToKenList(LoginInfo p_LoginInfo, string p_AccessTokenKey, ref DateTime p_ExpireTime)
        {
            try
            {
                SPARSUserToken l_UserToken;

                l_UserToken = m_UserTokenList.SingleOrDefault(x => x.AccessTokenId == p_AccessTokenKey);
                if (l_UserToken != null)
                {

                    l_UserToken.ExpireTime = p_ExpireTime;
                    return true;
                }

                l_UserToken = new SPARSUserToken();
                l_UserToken.UserNo = p_LoginInfo.UserNo;
                l_UserToken.AccessTokenId = p_AccessTokenKey;
                l_UserToken.ExpireTime = p_ExpireTime.AddMinutes(GlobalDeclarations.g_UserTokenExpireTime);
                l_UserToken.TokenIssueDateTime = DateTime.Now;
                m_UserTokenList.Add(l_UserToken);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }

            return false;
        }
        public static string CreateToken(ref LoginInfo p_LoginInfo, bool p_IsRenew = false, string p_UserTick = null)
        {
            try
            {
                JwtSecurityTokenHandler l_TokenHandler = new JwtSecurityTokenHandler();
                ClaimsIdentity l_ClaimsIdentity = new ClaimsIdentity();

                if (m_SecurityKey.Length < 128)
                {
                    Array.Resize(ref m_SecurityKey, 128);
                }


                SecurityKey l_SigningKey = new InMemorySymmetricSecurityKey(m_SecurityKey);
                SigningCredentials l_SigningCredentials = new SigningCredentials(l_SigningKey, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);
                SecurityTokenDescriptor l_SecurityTokenDescriptor = new SecurityTokenDescriptor();
                DateTime l_DateNow = DateTime.UtcNow;
                string l_SignedAndEncodedToken;

                SecurityToken l_PlainToken;
                string l_AccessKey = (p_LoginInfo.UserNo.ToString() + ("_" + HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]));

              
                if (string.IsNullOrEmpty(p_LoginInfo.AccessToken))
                {
                    p_LoginInfo.AccessToken = Guid.NewGuid().ToString();
                }

                if (AlreadyExist(p_LoginInfo.AccessToken, l_AccessKey) && p_IsRenew == false)
                {
                    l_AccessKey = (l_AccessKey + ("_" + l_DateNow.Ticks.ToString()));
                    l_ClaimsIdentity.AddClaim(new Claim("UserTick", l_DateNow.Ticks.ToString(), ClaimValueTypes.String));
                }

                if ((p_IsRenew == true))
                {
                    if (p_UserTick != null)
                    {
                        l_AccessKey = (l_AccessKey + ("_" + p_UserTick));
                        l_ClaimsIdentity.AddClaim(new Claim("UserTick", p_UserTick, ClaimValueTypes.String));
                    }

                    GlobalDeclarations.AccessTokens.Remove(l_AccessKey);
                }

                l_DateNow = l_DateNow.AddMinutes(GlobalDeclarations.g_UserTokenExpireTime);

                SPARSToken.AddUserToKenList(p_LoginInfo, l_AccessKey, ref l_DateNow);
                GlobalDeclarations.AccessTokens.Add(l_AccessKey, p_LoginInfo);
                l_ClaimsIdentity.AddClaim(new Claim(ClaimTypes.UserData, Convert.ToString(p_LoginInfo.UserNo), ClaimValueTypes.String));
                l_ClaimsIdentity.AddClaim(new Claim("AccTkn", p_LoginInfo.AccessToken, ClaimValueTypes.String));
                l_SecurityTokenDescriptor.AppliesToAddress = "";
                l_SecurityTokenDescriptor.AppliesToAddress = GlobalDeclarations.g_SiteURL;
                l_SecurityTokenDescriptor.TokenIssuerName = GlobalDeclarations.g_SiteURL;
                l_SecurityTokenDescriptor.Subject = l_ClaimsIdentity;
                l_SecurityTokenDescriptor.SigningCredentials = l_SigningCredentials;
                l_SecurityTokenDescriptor.Lifetime = new Lifetime(DateTime.UtcNow, l_DateNow);
                l_PlainToken = l_TokenHandler.CreateToken(l_SecurityTokenDescriptor);
                l_SignedAndEncodedToken = l_TokenHandler.WriteToken(l_PlainToken);
                return l_SignedAndEncodedToken;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }

            return String.Empty;
        }

        public static LoginInfo ReadToken(string p_Token, int p_ErrorCode = -1)
        {
            if (string.IsNullOrEmpty(p_Token))
            {
                return null;
                // Warning!!! Optional parameters not supported
            }

            LoginInfo l_LoginInfo = null;
            JwtSecurityTokenHandler l_TokenHandler = new JwtSecurityTokenHandler();
            string l_AccessKey = String.Empty;
            var l_ValidationParameters = new TokenValidationParameters();
            SecurityToken l_SecurityToken = null;
            Claim l_ClaimLoginData;
            Claim l_ClaimAccessToken;
            Claim l_ClaimUserTick;
            TimeSpan l_elapsedSpan;
            string l_UserTick = null;
            ClaimsPrincipal l_Principal;

            l_ValidationParameters.ValidAudience = GlobalDeclarations.g_SiteURL;

            if (m_SecurityKey.Length < 128)
            {
                Array.Resize(ref m_SecurityKey, 128);
            }

            l_ValidationParameters.IssuerSigningToken = new BinarySecretSecurityToken(m_SecurityKey);
            l_ValidationParameters.ValidIssuer = GlobalDeclarations.g_SiteURL;

            try
            {
                l_Principal = l_TokenHandler.ValidateToken(p_Token, l_ValidationParameters, out l_SecurityToken);
                //p_ErrorCode = (int)GlobalDeclarations.ErrorCodes.NoSession;

                if (l_SecurityToken.ValidTo > DateTime.UtcNow)
                {
                    l_ClaimLoginData = l_Principal.Claims.SingleOrDefault(x => x.Type == ClaimTypes.UserData && x.ValueType == ClaimValueTypes.String);
                    l_ClaimAccessToken = l_Principal.Claims.SingleOrDefault(x => x.Type == "AccTkn" && x.ValueType == ClaimValueTypes.String);
                    l_ClaimUserTick = l_Principal.Claims.SingleOrDefault(x => x.Type == "UserTick" && x.ValueType == ClaimValueTypes.String);

                    //p_ErrorCode = (int)GlobalDeclarations.ErrorCodes.NotAuthorize;
                    if (l_ClaimLoginData != null && l_ClaimAccessToken != null)
                    {
                        l_AccessKey = (l_ClaimLoginData.Value + ("_" + HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]));

                        if (l_ClaimUserTick != null)
                        {

                            l_AccessKey = (l_AccessKey + ("_" + l_ClaimUserTick.Value));
                            l_UserTick = l_ClaimUserTick.Value;
                        }

                        if (!GlobalDeclarations.AccessTokens.ContainsKey(l_AccessKey))
                        {
                            //p_ErrorCode = (int)GlobalDeclarations.ErrorCodes.NotAuthorize;
                            return null;
                        }

                        l_LoginInfo = GlobalDeclarations.AccessTokens[l_AccessKey];
                        if (l_LoginInfo != null)
                        {
                            if ((l_LoginInfo.AccessToken != l_ClaimAccessToken.Value))
                            {
                                //p_ErrorCode = (int)GlobalDeclarations.ErrorCodes.NotAuthorize;
                                return null;
                            }

                            l_elapsedSpan = new TimeSpan(l_SecurityToken.ValidTo.Ticks - DateTime.UtcNow.Ticks);

                            if ((l_elapsedSpan.TotalMinutes <= GlobalDeclarations.g_UserTokenRenewTime))
                            {
                                if ((RenewAccessToken(l_LoginInfo, l_UserTick) == false))
                                {
                                    //p_ErrorCode = (int)GlobalDeclarations.ErrorCodes.NoSession;
                                    return null;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorLogger.WriteToErrorLog(exception.Message, exception.StackTrace);
            }

            //p_ErrorCode = (int)GlobalDeclarations.ErrorCodes.NoSession;
            return l_LoginInfo;
        }

        public static bool RenewAccessToken(LoginInfo p_LoginInfo, string p_UserTick = null)
        {
            try
            {
                SPARSCookie.SetUserCookie(CreateToken(ref p_LoginInfo, true, p_UserTick));
                // Warning!!! Optional parameters not supported
                return true;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }

            return false;
        }

        private static bool AlreadyExist(string p_AccessToken, string p_AccessTokenKey)
        {
            try
            {
                if ((m_UserTokenList == null))
                {
                    m_UserTokenList = new List<SPARSUserToken>();
                    return false;
                }

                RemoveUserData(p_AccessToken, p_AccessTokenKey);
                if (GlobalDeclarations.AccessTokens.ContainsKey(p_AccessTokenKey))
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }

            return false;
        }

        private static bool RemoveUserData(string p_AccessToken, string p_AccessTokenKey, bool p_IsLogOff = false) 
        {
            return true;
            
        }

        public static bool RemoveToken(string p_Token)
        {
            if (string.IsNullOrEmpty(p_Token))
            {
                return false;
            }

            LoginInfo l_LoginInfo;
            JwtSecurityTokenHandler l_TokenHandler = new JwtSecurityTokenHandler();
            string l_AccessKey = String.Empty;
            TokenValidationParameters l_ValidationParameters = new TokenValidationParameters();
            SecurityToken l_SecurityToken;
            Claim l_ClaimLoginData;
            Claim l_ClaimAccessToken;
            Claim l_ClaimUserTick;
            ClaimsPrincipal l_Principal;
            l_ValidationParameters.ValidAudience = GlobalDeclarations.g_SiteURL;
            l_ValidationParameters.IssuerSigningToken = new BinarySecretSecurityToken(m_SecurityKey);
            l_ValidationParameters.ValidIssuer = GlobalDeclarations.g_SiteURL;
            // l_ValidationParameters.RequireExpirationTime = True
            try
            {
                l_Principal = l_TokenHandler.ValidateToken(p_Token, l_ValidationParameters, out l_SecurityToken);
                l_ClaimLoginData = l_Principal.Claims.SingleOrDefault(x => x.Type == ClaimTypes.UserData && x.ValueType == ClaimValueTypes.String);
                l_ClaimAccessToken = l_Principal.Claims.SingleOrDefault(x => x.Type == "AccTkn" && x.ValueType == ClaimValueTypes.String);
                l_ClaimUserTick = l_Principal.Claims.SingleOrDefault(x => x.Type == "UserTick" && x.ValueType == ClaimValueTypes.String);

                if (l_ClaimLoginData != null && l_ClaimAccessToken != null)
                {
                    l_AccessKey = (l_ClaimLoginData.Value + ("_" + HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]));
                    if (l_ClaimUserTick != null)
                    {
                        l_AccessKey = (l_AccessKey + ("_" + l_ClaimUserTick.Value));
                    }

                    if (!GlobalDeclarations.AccessTokens.ContainsKey(l_AccessKey))
                    {
                        return false;
                    }

                    l_LoginInfo = GlobalDeclarations.AccessTokens[l_AccessKey];
                    if (l_LoginInfo != null)
                    {
                        return RemoveUserData(l_AccessKey, l_AccessKey, true);
                    }

                }

            }
            catch (Exception exception)
            {
                ErrorLogger.WriteToErrorLog(exception.Message, exception.StackTrace);
            }

            return false;
        }

    }
}