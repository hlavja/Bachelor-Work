using System;
using System.Linq;
using ISSSC.Models;
using ISSSC.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Collections;

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
        /// User first name
        /// </summary>
        private const string FIRST_NAME = "SHIB_GIVENNAME";

        /// <summary>
        /// User second name
        /// </summary>
        private const string SECOND_NAME = "SHIB_SN";

        private const string X_SECURE = "TESTAUTH";

        /// <summary>
        /// SSO Authentification
        /// https://proxyauth.zcu.cz/testauth
        /// </summary>
        /// <returns>HomePage</returns>
        public ActionResult Index()
        {
            //Main proxy https://proxyauth.zcu.cz/testauth/
            //Backup https://fkmagion.zcu.cz/testauth/
            //Zajistit na entry se dostat jenom z proxyauth.zcu.cz (147.228.4.80)
            var PROXY_IP = "147.228.4.80";
            var headerValue = Request.Headers[WEB_AUTH_USER];
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            if (headerValue.Any() == false || ip != PROXY_IP)
            {
                return RedirectToAction("Info", "Entry");
            }
            string username = Request.Headers[USERNAME_KEY];
            string firstName = Request.Headers[FIRST_NAME];
            string secondName = Request.Headers[SECOND_NAME];
            string email = Request.Headers[EMAIL_KEY].ToString();

            //find user if already in database
            var count = db.SscisUser.Count(usr => usr.Login.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (count < 1)
            {
                SscisUser user = new SscisUser();
                user.Created = DateTime.Now;
                user.Activated = DateTime.Now;
                user.Login = username;
                user.IsActive = true;
                user.Email = email;
                user.IdRoleNavigation = db.EnumRole.Where(r => r.Role.Equals(AuthorizationRoles.User, StringComparison.OrdinalIgnoreCase)).Single();
                user.Firstname = firstName;
                user.Lastname = secondName;
                db.SscisUser.Add(user);
                db.SaveChanges();
            }

            //start session
            int sessionId = new SSCISSessionManager().SessionStart(username, HttpContext);

            ViewBag.SessionId = sessionId;
            SscisSession session = db.SscisSession.Find(sessionId);
            ViewBag.RedirectUrl = HttpContext.Request.Query["redirect"].ToString();
            ViewBag.UserId = session.IdUser;
            ViewBag.Hash = session.Hash;
            ViewBag.Role = session.IdUserNavigation.IdRoleNavigation.Role;
            ViewBag.Login = session.IdUserNavigation.Login;

            return View("Logged");
        }

        /// <summary>
        /// Info for testing purposes SSO authentification
        /// </summary>
        /// <returns>HomePage</returns>
        public ActionResult Info()
        {           
            StringBuilder sb = new StringBuilder();
            foreach (var key in HttpContext.Request.Headers)
            {
                sb.Append(key.Key);
                sb.Append(" = ");
                sb.Append(string.Join(",", key.Value.ToArray()));
                sb.Append("\n");
            }
            return Content(sb.ToString());
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
        public ActionResult StoreData(int sessionId, int userId, string hash, string role, string login, string redirect)
        {
            HttpContext.Session.SetInt32("sessionId", sessionId);
            HttpContext.Session.SetString("role", role);
            HttpContext.Session.SetString("hash", hash);
            HttpContext.Session.SetString("login", login);
            HttpContext.Session.SetInt32("userId", userId);

            if (redirect != null)
            {
                return Redirect(redirect);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
