using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISSSC.Models.Meta;
using ISSSC.Models;
using ISSSC.Class;
using ISSSC.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace ISSSC.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Time table components renderer
        /// </summary>
        private TimetableRenderer timeTableRenderer = new TimetableRenderer();

        public SscisContext Db { get; set; }

        public HomeController(SscisContext context)
        {
            Db = context;
        }

        /// <summary>
        /// Home page
        /// </summary>
        /// <returns>Home page view</returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";
            SscisContent model = null;
            if (Db.SscisContent.Count() > 0)
            {
                model = Db.SscisContent.OrderByDescending(c => c.Created).First();
            }
            else
            {
                model = new SscisContent
                {
                    Created = DateTime.Now,
                    TextContent = "Žádná aktualita nebyla nalezena"
                };
            }
            ViewBag.PublicTimeTable = timeTableRenderer.RenderPublic(Db);
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Contact
        /// </summary>
        /// <returns>Contact view</returns>
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.MapToken = Db.SscisParam.Where(p => p.ParamKey.Equals("MAP_TOKEN")).Single().ParamValue;
            ViewBag.Title = "Contact";
            return View();
        }


        /// <summary>
        /// Help me view
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult HelpMe()
        {
            //TODO změna
            ViewBag.SubjectID = new SelectList(Db.EnumSubject.Where(s => s.IdParent == null), "Id", "Code");

            ViewBag.Title = "Potřebuji pomoc";
            ViewBag.PublicTimeTable = timeTableRenderer.RenderPublic(Db);
            return View();
        }


    
        /// <summary>
        /// Cretes new event
        /// </summary>
        /// <param name="@event">Event model</param>
        /// <returns>Creation result</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.User)]
        public ActionResult HelpMe(MetaEvent model)
        {
            model.Event = new Event();
            if (ModelState.IsValid)
            {
                int userId = (int)HttpContext.Session.GetInt32("userId");

                model.Event.TimeFrom = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.TimeFrom.Hour, model.TimeFrom.Minute, 0);
                model.Event.TimeTo = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.TimeFrom.Hour + 1, model.TimeFrom.Minute, 0);
                model.Event.IdSubjectNavigation = Db.EnumSubject.Find(model.SubjectID);
                model.Event.IdTutorNavigation = null;
                model.Event.IdTutor = null;
                model.Event.IsAccepted = false;
                model.Event.IsCancelled = false;
                model.Event.IsExtraLesson = true;
                model.Event.IdApplicantNavigation = Db.SscisUser.Find(userId);

                Db.Event.Add(model.Event);
                Db.SaveChanges();
                return RedirectToAction("HelpMe");
            }
            return RedirectToAction("HelpMe");
        }

        /// <summary>
        /// News
        /// </summary>
        /// <returns>View with news</returns>
        [HttpGet]
        public ActionResult News()
        {
            ViewBag.Title = "Novniky";
            MetaNews model = new MetaNews
            {
                Contents = Db.SscisContent.OrderByDescending(c => c.Created).ToList()
            };
            return View(model);
        }

        /// <summary>
        /// Login UC
        /// </summary>
        /// <param name="validationMessage">validation message</param>
        /// <returns>View with login form</returns>
        [HttpGet]
        public ActionResult Login(string validationMessage = null)
        {
            bool webauth = BoolParser.Parse(Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.WEB_AUTH_ON)).Single().ParamValue);
            if (webauth)
            {
                return Redirect(Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.WEB_AUTH_URL)).Single().ParamValue);
            }
            ViewBag.Title = "Login";
            MetaLogin model = new MetaLogin
            {
                ValidationMessage = validationMessage
            };
            return View(model);
        }

        /// <summary>
        /// Login process
        /// </summary>
        /// <param name="model">Data from login view</param>
        /// <returns>Redirection</returns>
        [HttpPost]
        public ActionResult Login(MetaLogin model)
        {
            var count = Db.SscisUser.Count(usr => usr.Login.Equals(model.Login));
            if (count == 1)
            {
                new SSCISSessionManager().SessionStart(model.Login, HttpContext);
                return RedirectToAction("Index");
            }
            return Login("Invalid login");
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns>Redirection</returns>
        [HttpGet]
        public ActionResult Logout()
        {
            new SSCISSessionManager().SessionDestroy((int)HttpContext.Session.GetInt32("sessionId"), HttpContext);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Unauthorized access view
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Unauthorized()
        {
            return View();
        }

        /// <summary>
        /// Signpost for statistics
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Statistics()
        {
            return View();
        }


        /// <summary>
        /// Checks version of application
        /// </summary>
        /// <returns>Version of application</returns>
        [HttpGet]
        public ActionResult Version()
        {
            string version = Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.VERSION)).Single().ParamValue;
            return Content(version);
        }
    }
}
