using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISSSC.Models;
using ISSSC.Models.Meta;
using ISSSC.Class;
using ISSSC.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http.Headers;

namespace ISSSC.Controllers
{
    /// <summary>
    /// Entry point controller for logging users in application
    /// </summary>
    public class EntryController : Controller
    {
        /// <summary>
        /// Database context
        /// </summary>
        private SscisContext db = new SscisContext();

        /// <summary>
        /// Session manager
        /// </summary>
        private SSCISSessionManager sessionManager = new SSCISSessionManager();

        /// <summary>
        /// Username request key
        /// </summary>
        private const string USERNAME_KEY = "SHIB_REMOTEUSER";

        /// <summary>
        /// Email request key
        /// </summary>
        private const string EMAIL_KEY = "SHIB_EMAIL";

        /// <summary>
        /// WebAuth user verification key
        /// </summary>
        private const string WEB_AUTH_USER = "X-webauth_proxy_user";


        /// <summary>
        /// SSO Authentification
        /// </summary>
        /// <returns>HomePage</returns>
        public ActionResult Index()
        {
            if (HttpContext.Request.Headers["WEB_AUTH_USER"].Equals("")) return RedirectToAction("Index", "Home");
            string username = Request.Headers[USERNAME_KEY];
            var count = db.SscisUser.Count(usr => usr.Login.Equals(username));
            if (count < 1)
            {
                string email = Request.Headers[EMAIL_KEY];
                SscisUser user = new SscisUser();
                user.Created = DateTime.Now;
                user.Activated = DateTime.Now;
                user.Login = username;
                user.IsActive = true;
                user.Email = email;
                user.IdRoleNavigation = db.EnumRole.Where(r => r.Role.Equals(AuthorizationRoles.User)).Single();
                db.SscisUser.Add(user);
                db.SaveChanges();
            }

            int sessionId = new SSCISSessionManager().SessionStart(username, HttpContext);

            ViewBag.SessionId = sessionId;
            SscisSession session = db.SscisSession.Find(sessionId);

            ViewBag.UserId = session.IdUser;
            ViewBag.Hash = session.Hash;
            ViewBag.Role = session.IdUserNavigation.IdRoleNavigation.Role;
            ViewBag.Login = session.IdUserNavigation.Login;

            return View("Logged");

            //StringBuilder sb = new StringBuilder();
            //foreach (var key in Request.Headers.AllKeys)
            //{
            //    var val = Request.Headers[key];
            //    sb.Append(key);
            //    sb.Append(" = ");
            //    sb.Append(val);
            //    sb.Append("\n");
            //}
            //return Content(sb.ToString());
        }

        /// <summary>
        /// Info for testing purposes SSO authentification
        /// </summary>
        /// <returns>HomePage</returns>
        public ActionResult Info()
        {
            if (HttpContext.Request.Headers["WEB_AUTH_USER"].Equals("")) return RedirectToAction("Index", "Home");
            string username = Request.Headers[USERNAME_KEY];
            var count = db.SscisUser.Count(usr => usr.Login.Equals(username));
            if (count < 1)
            {
                //string email = Request.Headers[EMAIL_KEY];
                SscisUser user = new SscisUser();
                user.Created = DateTime.Now;
                user.Activated = DateTime.Now;
                user.Login = username;
                user.IsActive = true;
                //user.Email = email; //TODO dodat do db
                user.IdRoleNavigation = db.EnumRole.Where(r => r.Role.Equals(AuthorizationRoles.User)).Single();
                db.SscisUser.Add(user);
                db.SaveChanges();
            }

            int sessionId = new SSCISSessionManager().SessionStart(username, HttpContext);

            ViewBag.SessionId = sessionId;
            SscisSession session = db.SscisSession.Find(sessionId);

            ViewBag.UserId = session.IdUser;
            ViewBag.Hash = session.Hash;
            ViewBag.Role = session.IdUserNavigation.IdRoleNavigation.Role;
            ViewBag.Login = session.IdUserNavigation.Login;

            return View("Logged");

            //return RedirectToAction("Index", "Home");

            //StringBuilder sb = new StringBuilder();
            //foreach (var key in Request.Headers.AllKeys)
            //{
            //    var val = Request.Headers[key];
            //    sb.Append(key);
            //    sb.Append(" = ");
            //    sb.Append(val);
            //    sb.Append("\n");
            //}
            //return Content(sb.ToString());
        }

        /// <summary>
        /// Stores parameters into users local session
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        /// <param name="userId">User ID</param>
        /// <param name="hash">Hash</param>
        /// <param name="role">User role code</param>
        /// <param name="login">User login</param>
        /// <returns>Redirection to Homepage</returns>
        public ActionResult StoreData(int sessionId, int userId, string hash, string role, string login)
        {
            HttpContext.Session.SetInt32("sessionId", sessionId);
            HttpContext.Session.SetString("role", role);
            HttpContext.Session.SetString("hash", hash);
            HttpContext.Session.SetString("login", login);
            HttpContext.Session.SetInt32("userId", userId);
            return RedirectToAction("Index", "Home");
        }

    }
}
