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
using System.Text;

namespace ISSSC.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Time table components renderer
        /// </summary>
        private TimetableRenderer timeTableRenderer = new TimetableRenderer();
        private PersonalTimetable personalTimetable = new PersonalTimetable();

        private readonly IEmailService _emailService;
        public SscisContext Db { get; set; }

        public HomeController(SscisContext context, IEmailService emailService)
        {
            Db = context;
            _emailService = emailService;
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


            int userId = 0;

            if (HttpContext.Session.GetInt32("userId").HasValue)
            {
                userId = (int)HttpContext.Session.GetInt32("userId");
            }

            List<Event> myEventsWithoutAttendance = Db.Event.Where(e => (e.IdTutor == userId && e.IsAccepted == true && e.Attendance == null && e.IsCancelled == false && e.TimeTo <= DateTime.Now)).ToList();
            if (myEventsWithoutAttendance.Any())
            {
                ViewBag.EventsWithoutAttendance = true;
                ViewBag.RenderAttendance = personalTimetable.RenderAttendance(Db, userId);
            }


            ViewBag.PublicTimeTable = timeTableRenderer.RenderPublic(Db);
            ViewBag.PersonalTimeTable = personalTimetable.RenderEvents(Db, userId);

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
            StringBuilder builder = new StringBuilder();
            builder.Append("https://maps.googleapis.com/maps/api/js?key=");
            builder.Append(Db.SscisParam.Where(p => p.ParamKey.Equals("MAP_TOKEN")).Single().ParamValue);
            builder.Append("&callback=myMap");



            ViewBag.MapToken = builder.ToString();
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
            int userId = 0;

            if (HttpContext.Session.GetInt32("userId").HasValue)
            {
                userId = (int)HttpContext.Session.GetInt32("userId"); ;
            }

            ViewBag.Title = "Potřebuji pomoc";
            ViewBag.PersonalTimeTable = personalTimetable.RenderEvents(Db, userId);
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
        [SSCISAuthorize(AccessLevels =new[] { AuthorizationRoles.User, AuthorizationRoles.Tutor })]
        public ActionResult HelpMe(MetaEvent model)
        {
            model.Event = new Event();
            if (ModelState.IsValid)
            {
                int userId = (int)HttpContext.Session.GetInt32("userId");

                model.Event.TimeFrom = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.TimeFrom.Hour, model.TimeFrom.Minute, 0);
                if (!BoolParser.Parse(Db.SscisParam.Single(p => p.ParamKey.Equals(SSCISParameters.EXTRA_EVENT_LENGTH)).ParamValue))
                {
                    int hour = Convert.ToInt32(Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.EXTRA_EVENT_LENGTH)).Single().ParamValue);
                    model.Event.TimeTo = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.TimeFrom.Hour + hour, model.TimeFrom.Minute, 0);
                }
                else
                {
                    model.Event.TimeTo = model.Event.TimeFrom.AddHours(1);
                }
                //model.Event.TimeTo = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.TimeFrom.Hour + 1, model.TimeFrom.Minute, 0);
                model.Event.IdSubjectNavigation = Db.EnumSubject.Find(model.SubjectID);
                model.Event.IdTutorNavigation = null;
                model.Event.IdTutor = null;
                model.Event.IsAccepted = false;
                model.Event.IsCancelled = false;
                model.Event.IsExtraLesson = true;
                model.Event.IdApplicantNavigation = Db.SscisUser.Find(userId);

                Db.Event.Add(model.Event);
                Db.SaveChanges();

                int newId = model.Event.Id;

                EmailMessage emailMessage = new EmailMessage();

                //TODO Emaily!!
                //odeslat email všem lidem co ho můžou vyučovat a mají vyplněný email

                EmailAddress emailFrom = new EmailAddress();
                emailFrom.Address = "studentsuportcentre@gmail.com";
                emailFrom.Name = "Student Suport Centre";

                List<EmailAddress> listFrom = new List<EmailAddress>();
                listFrom.Add(emailFrom);

                List<EmailAddress> listTo = new List<EmailAddress>();

                foreach (var item in Db.Approval)
                {
                    if (item.IdSubject == model.SubjectID)
                    {
                        if (item.IdTutorNavigation.Email != null)
                        {
                            EmailAddress emailTo = new EmailAddress();
                            emailTo.Name = item.IdTutorNavigation.Login;
                            emailTo.Address = item.IdTutorNavigation.Email;
                            listTo.Add(emailTo);
                        }
                    }
                }

                string subjectCode = Db.EnumSubject.Where(s => s.Id == model.SubjectID).Single().Code;

                emailMessage.FromAddresses = listFrom;
                emailMessage.ToAddresses = listTo;
                            
                emailMessage.Subject = "Žádost o extra lekci " + subjectCode + " v Student Support Centru";
                emailMessage.Content = "Evidujeme novou žádost o extra lekci z předmětu, který můžeš vyučovat.\n" +
                    "Pokud chceš lekci z " + subjectCode + " přijmout klikni na následující link: https://localhost:44386/ExtraLesson/Accept?id=" + newId;
                
                _emailService.Send(emailMessage);
                return RedirectToAction("HelpMe");
            }
            return RedirectToAction("HelpMe");
        }

        /// <summary>
        /// News
        /// </summary>
        /// <returns>View with news</returns>
        [HttpGet]
        [Route("News")]
        public ActionResult News()
        {
            ViewBag.Title = "Novniky";
            MetaNews model = new MetaNews
            {
                Contents = Db.SscisContent.OrderByDescending(c => c.Created).ToList()
            };

            int userId = 0;

            if (HttpContext.Session.GetInt32("userId").HasValue)
            {
                userId = (int)HttpContext.Session.GetInt32("userId");
            }
            ViewBag.PersonalTimeTable = personalTimetable.RenderEvents(Db, userId);
            return View(model);
        }

        /// <summary>
        /// Login UC
        /// </summary>
        /// <param name="validationMessage">validation message</param>
        /// <returns>View with login form</returns>
        [HttpGet]
        public ActionResult Login(string validationMessage = null, string redirectionUrl = null)
        {
            string redirectUrl = WebUtility.UrlDecode(redirectionUrl);
            bool webauth = BoolParser.Parse(Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.WEB_AUTH_ON)).Single().ParamValue);
            //string redirectUrl = HttpContext.Request.Path.Value + HttpContext.Request.QueryString.Value;
            
            if (webauth)
            {
                
                return Redirect(Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.WEB_AUTH_URL)).Single().ParamValue);
            }
            ViewBag.Title = "Login";
            MetaLogin model = new MetaLogin
            {
                ValidationMessage = validationMessage,
                RedirectionUrl = redirectionUrl
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
                if(model.RedirectionUrl != null)
                {                    
                    return Redirect(model.RedirectionUrl);
                }
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
        [Route("Home/Unauthorized/{redirection}")]
        public ActionResult Unauthorized(string redirection = null)
        {
            ViewData["RedirectionUrl"] = SSCHttpContext.AppBaseUrl + WebUtility.UrlDecode(redirection);
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
