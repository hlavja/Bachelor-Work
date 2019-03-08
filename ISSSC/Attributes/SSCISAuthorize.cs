using ISSSC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace ISSSC.Attributes
{
    /// <summary>
    /// Attribute for authorizing controllers actionResult methods
    /// </summary>
    public class SSCISAuthorize : ActionFilterAttribute
    {
        public string AccessLevel { get {
                return AccessLevels != null ? AccessLevels[0] : null;
            }
            set {
                AccessLevels = new string[]{value};
            } }
             
        
        public string[] AccessLevels { get; set; }
        /// <summary>
        /// Session manager
        /// </summary>
        private SSCISSessionManager _sessionManager = new SSCISSessionManager();

        /// <summary>
        /// Contructor
        /// </summary>
        public SSCISAuthorize()
        {
            _sessionManager = new SSCISSessionManager();
        }

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="sessionManager">Session manager</param>
        public SSCISAuthorize(SSCISSessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }


        /// <summary>
        /// Authorizes actionResultMethod
        /// </summary>
        /// <param name="filterContext">authoentification filter context</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AccessLevel != null)
            {
                if (!_sessionManager.VerifySession(filterContext.HttpContext.Session))
                {
                    filterContext.Result = new RedirectResult(string.Format("{0}Home/Login", _addSlash(SSCHttpContext.AppBaseUrl)));
                }
                var role = filterContext.HttpContext.Session.GetString("role");
                if (role == null || !AccessLevels.Contains(role) && !role.Equals(AuthorizationRoles.Administrator))
                    filterContext.Result = new RedirectResult($"{_addSlash(SSCHttpContext.AppBaseUrl)}Home/Unauthorized/{WebUtility.UrlEncode(filterContext.HttpContext.Request.Path.Value+ filterContext.HttpContext.Request.QueryString)}");
            }
        }

        /// <summary>
        /// Adds slash at the end of URL if needed
        /// </summary>
        /// <param name="url">URL string</param>
        /// <returns>Url with slash at the end</returns>
        private string _addSlash(string url)
        {
            return url.EndsWith("/") ? url : url + "/";
        }
    }
}