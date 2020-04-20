using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ISSSC.Models.Meta;
using ISSSC.Models;
using ISSSC.Class;
using ISSSC.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ISSSC.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Time table components renderer
        /// </summary>
        private TimetableRenderer timeTableRenderer = new TimetableRenderer();
        private PersonalTimetable personalTimetable = new PersonalTimetable();

        private readonly PasswordHash aa = new PasswordHash();
        readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        public SscisContext Db { get; set; }

        public HomeController(SscisContext context, IEmailService emailService, IConfiguration configuration)
        {
            Db = context;
            _emailService = emailService;
            _configuration = configuration;
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

            string text = Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.INDEXHTML, StringComparison.OrdinalIgnoreCase)).Single().ParamValue;
            ViewBag.TextIndex = WebUtility.HtmlDecode(text);
            ViewBag.PublicTimeTable = timeTableRenderer.RenderPublic(Db);
            ViewBag.PersonalTimeTable = personalTimetable.RenderEvents(Db, userId);

            return View(model);
        }

        /// <summary>
        /// About page
        /// </summary>
        /// <returns>About view</returns>
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
            builder.Append(Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.MAPTOKEN, StringComparison.OrdinalIgnoreCase)).Single().ParamValue);
            builder.Append("&callback=myMap");

            string text = Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.KONTAKTHTML, StringComparison.OrdinalIgnoreCase)).Single().ParamValue;
            ViewBag.Text = WebUtility.HtmlDecode(text);
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
   
            ViewBag.SubjectID = new SelectList(Db.EnumSubject.Where(s => s.IdParent == null), "Id", "Code");
            int userId = 0;

            if (HttpContext.Session.GetInt32("userId").HasValue)
            {
                userId = (int)HttpContext.Session.GetInt32("userId"); ;
            }

            bool extraLessonEnable = true;
            extraLessonEnable = BoolParser.Parse(Db.SscisParam.Single(p => p.ParamKey.Equals(SSCISParameters.EXTRALESSONENABLE, StringComparison.OrdinalIgnoreCase)).ParamValue);
            string text = Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.POTREBUJIPOMOCHTML, StringComparison.OrdinalIgnoreCase)).Single().ParamValue;
            ViewBag.TextHelpMe = WebUtility.HtmlDecode(text);

            ViewBag.Title = "Potřebuji pomoc";
            ViewBag.PersonalTimeTable = personalTimetable.RenderEvents(Db, userId);
            ViewBag.PublicTimeTable = timeTableRenderer.RenderPublic(Db);
            ViewBag.ExtraLessonEnable = extraLessonEnable;
            return View();
        }


    
        /// <summary>
        /// Cretes new event
        /// </summary>
        /// <param name="@event">Event model</param>
        /// <returns>Creation result</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevels = new[] { AuthorizationRoles.User, AuthorizationRoles.Tutor, AuthorizationRoles.Administrator })]
        public ActionResult HelpMe(MetaEvent model)
        {
            if(model != null)
            {
                model.Event = new Event();
            
            if (ModelState.IsValid)
            {
                int userId = (int)HttpContext.Session.GetInt32("userId");

                model.Event.TimeFrom = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.TimeFrom.Hour, model.TimeFrom.Minute, 0);
                if (!BoolParser.Parse(Db.SscisParam.Single(p => p.ParamKey.Equals(SSCISParameters.EXTRAEVENTLENGTH, StringComparison.OrdinalIgnoreCase)).ParamValue))
                {
                    int hour = Convert.ToInt32(Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.EXTRAEVENTLENGTH, StringComparison.OrdinalIgnoreCase)).Single().ParamValue);
                    model.Event.TimeTo = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.TimeFrom.Hour + hour, model.TimeFrom.Minute, 0);
                }
                else
                {
                    model.Event.TimeTo = model.Event.TimeFrom.AddHours(1);
                }
                model.Event.IdSubjectNavigation = Db.EnumSubject.Find(model.SubjectID);
                model.Event.IdTutorNavigation = null;
                model.Event.IdTutor = null;
                model.Event.IsAccepted = false;
                model.Event.IsCancelled = false;
                model.Event.IsExtraLesson = true;
                model.Event.IdApplicantNavigation = Db.SscisUser.Find(userId);
                string comment = model.Comment.ToString();
                model.Event.ExtraComment= model.Comment.ToString();

                Db.Event.Add(model.Event);
                Db.SaveChanges();

                int newId = model.Event.Id;

                EmailMessage emailMessage = new EmailMessage();
                List<EmailAddress> listTo = new List<EmailAddress>();

                foreach (var item in Db.Approval)
                {
                    if (item.IdSubject == model.SubjectID)
                    {
                        if (item.IdTutorNavigation.Email != null && item.IdTutorNavigation.Email.Length > 2)
                        {
                            EmailAddress emailTo = new EmailAddress();
                            emailTo.Name = item.IdTutorNavigation.Login;
                            emailTo.Address = item.IdTutorNavigation.Email;
                            listTo.Add(emailTo);
                        }
                    }
                }

                string subjectCode = Db.EnumSubject.Where(s => s.Id == model.SubjectID).Single().Code;

                emailMessage.ToAddresses = listTo;

                emailMessage.Subject = string.Format(_configuration.GetValue<string>("EmailMessageConfigs:ExtraLectionEmail:Subject"), subjectCode);
                emailMessage.Content = string.Format(_configuration.GetValue<string>("EmailMessageConfigs:ExtraLectionEmail:Content"), comment, subjectCode, SSCHttpContext.AppBaseUrl, newId);
                
                _emailService.Send(emailMessage);
                return RedirectToAction("HelpMe");
            }
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
            bool webauth = BoolParser.Parse(Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.WEBAUTHON, StringComparison.OrdinalIgnoreCase)).Single().ParamValue);
            string testAuthParametr;

            if (webauth)
            {
                string webAuth = Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.WEBAUTHURL)).Single().ParamValue.ToString();

                if (redirectionUrl != null)
                {
                    testAuthParametr = webAuth + "?redirect=" + WebUtility.UrlEncode(redirectionUrl);
                } else
                {
                    testAuthParametr = webAuth;
                }
                

                return Redirect(testAuthParametr);
                
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
            var count = Db.SscisUser.Count(usr => usr.Login.Equals(model.Login, StringComparison.OrdinalIgnoreCase));
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
            string version = Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.VERSION, StringComparison.OrdinalIgnoreCase)).Single().ParamValue;
            return Content(version);
        }


        /// <summary>
        /// Login Admin
        /// </summary>
        /// <param name="validationMessage">validation message</param>
        /// <returns>View with login form</returns>
        [HttpGet]
        [Route("AdminLogin")]
        public ActionResult AdminLogin(string validationMessage = null, string redirectionUrl = null)
        {
            SscisParam pass = Db.SscisParam.SingleOrDefault(p => p.ParamKey.Equals(SSCISParameters.ADMINPASSWORD, StringComparison.OrdinalIgnoreCase));
            if (pass == null)
            {
                SscisParam password = new SscisParam();
                password.Description = "Admin password!";
                password.ParamKey = SSCISParameters.ADMINPASSWORD;
                password.ParamValue = new PasswordHash().Encode("VasaAdmin"); ;
                Db.SscisParam.Add(password);
                Db.SaveChanges();
            }

            string redirectUrl = WebUtility.UrlDecode(redirectionUrl);
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
        [Route("AdminLogin")]
        public ActionResult AdminLogin(MetaLogin model)
        {

            // Fetch the stored value
            string password = "";
            string savedPasswordHash = Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.ADMINPASSWORD, StringComparison.OrdinalIgnoreCase)).Single().ParamValue;
            if(model != null && !string.IsNullOrEmpty(model.Password))
            {
                password = model.Password;
            }

            bool match = new PasswordHash().Decode(savedPasswordHash, password);

            if (match)
            {
                var count = Db.SscisUser.Count(usr => usr.Login.Equals(model.Login, StringComparison.OrdinalIgnoreCase));
                if (count == 1)
                {
                    new SSCISSessionManager().SessionStart(model.Login, HttpContext);
                    if (model.RedirectionUrl != null)
                    {
                        return Redirect(model.RedirectionUrl);
                    }
                    return RedirectToAction("Index");
                }
                return AdminLogin("Invalid login");
            }
            else
            {
                return AdminLogin("Invalid login");
                throw new UnauthorizedAccessException();
            }
        }
    }
}
