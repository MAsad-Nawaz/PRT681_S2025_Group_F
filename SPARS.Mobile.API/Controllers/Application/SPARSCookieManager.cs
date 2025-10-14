using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SSS.Mobile.API.Controllers.Application
{
    public class SPARSCookieManager
    {
        public static void CreateCookie(string name, int durationInMonth, string value) {
        HttpCookie cookie = new HttpCookie(name);
        cookie.Value = value;
        cookie.Expires = DateTime.Now.AddMonths(durationInMonth);
        HttpContext.Current.Response.Cookies.Add(cookie);
    }
    
    // '' <summary>
    // '' this creates domain cookie so that we can access cookie in API layer
    // '' </summary>
    // '' <param name="name"></param>
    // '' <param name="durationInMinutes"></param>
    // '' <param name="value"></param>
    public static void CreateAndUpdateDomainCookie(string name, double durationInMinutes, string value) 
    {
        if (HttpContext.Current.Request.Cookies[name] != null && !string.IsNullOrWhiteSpace(HttpContext.Current.Request.Cookies[name].ToString()))
        {
            var cookie  = HttpContext.Current.Request.Cookies[name];
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddMinutes(durationInMinutes);
            cookie.Domain = FormsAuthentication.CookieDomain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        else 
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddMinutes(durationInMinutes);
            cookie.Domain = FormsAuthentication.CookieDomain;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        
    }
    
    public static void CreateAndUpdateCookie(string name, double durationInMinutes, string value, bool isPersistent = false) 
    {
        if (HttpContext.Current.Request.Cookies[name] != null && !string.IsNullOrWhiteSpace(HttpContext.Current.Request.Cookies[name].ToString()))
        {
            var cookie = HttpContext.Current.Request.Cookies[name];
            cookie.Value = value;

            if ((isPersistent == false)) 
            {
                cookie.Expires = DateTime.Now.AddMinutes(durationInMinutes);
            }
            else 
            {
                cookie.Expires = DateTime.MaxValue;
            }
            
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        else 
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Value = value;

            if ((isPersistent == false)) 
            {
                cookie.Expires = DateTime.Now.AddMinutes(durationInMinutes);
            }
            else {
                cookie.Expires = DateTime.MaxValue;
            }
            
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        
    }
    
    public static void CreateAndUpdateCookie(string name, string value) 
    {
        if (HttpContext.Current.Request.Cookies[name] != null && !string.IsNullOrWhiteSpace(HttpContext.Current.Request.Cookies[name].ToString()))
        {
            var cookie = HttpContext.Current.Request.Cookies[name];
            cookie.Value = value;
            cookie.Domain = FormsAuthentication.CookieDomain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        else 
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Value = value;
            cookie.Domain = FormsAuthentication.CookieDomain;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        
    }
    
    public static void ExpireCookie(string name) 
    {
        if (HttpContext.Current.Request.Cookies[name] != null && !string.IsNullOrWhiteSpace(HttpContext.Current.Request.Cookies[name].ToString()))
        {
            var cookie = HttpContext.Current.Request.Cookies[name];
            cookie.Value = null;
            cookie.Expires = DateTime.Now.AddDays(-10);
            HttpContext.Current.Response.SetCookie(cookie);
        }
        
    }
    
    public static string GetCookieValue(string name) 
    {
        string data = String.Empty;
        if (HttpContext.Current.Request.Cookies[name] != null && !string.IsNullOrWhiteSpace(HttpContext.Current.Request.Cookies[name].ToString())) 
        {
            data = HttpContext.Current.Request.Cookies[name].Value;
        }
        
        return data;
    }
    
    public static void UpdateCookie(string name, int durationInMonth, string value) 
    {
        if (HttpContext.Current.Request.Cookies[name] != null && !string.IsNullOrWhiteSpace(HttpContext.Current.Request.Cookies[name].ToString()))
        {
            var cookie = HttpContext.Current.Request.Cookies[name];
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddDays(durationInMonth);
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        
    }
    
    public static bool IsCookieExist(string name) 
    {
        bool exist = false;
        if (HttpContext.Current.Request.Cookies[name] != null) 
        {
            exist = true;
        }
        
        return exist;
    }
   }
}