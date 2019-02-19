﻿using ISSSC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Hosting;

namespace ISSSC.Attributes
{
    /// <summary>
    /// Attribute for authorizing controllers actionResult methods
    /// </summary>
    public class SSCISAuthorize : ActionFilterAttribute
    {
        public string AccessLevel { get; set; }

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
                if (role == null || !role.Equals(AccessLevel) && !role.Equals(AuthorizationRoles.Administrator))
                    filterContext.Result = new RedirectResult(string.Format("{0}Home/Unauthorized", _addSlash(SSCHttpContext.AppBaseUrl)));
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