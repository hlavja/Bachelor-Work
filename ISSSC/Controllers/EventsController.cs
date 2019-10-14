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
using System.Net;

namespace ISSSC.Controllers
{
    /// <summary>
    /// Events controller
    /// </summary>
    public class EventsController : Controller
    {
        /// <summary>
        /// Database context
        /// </summary>
        private SscisContext db = new SscisContext();

        /// <summary>
        /// Timetable component renderer
        /// </summary>
        private TimetableRenderer timetableRenderer = new TimetableRenderer();

        /// <summary>
        /// List of created events
        /// </summary>
        /// <returns>View with list of events</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Tutor)]
        public ActionResult Index()
        {
            DateTime now = DateTime.Now;
            var eventModel = db.Event.Where(e => e.TimeFrom > now /*&& e.IsExtraLesson == false*/).Include(@e => @e.IdSubjectNavigation).Include(@e => @e.IdTutorNavigation);
            return View(eventModel.ToList());
        }

        #region Unused
        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }
        #endregion

        [Route("ExtraLesson/Accept")]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Tutor)]
        [HttpGet]
        public ActionResult AcceptLesson(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        /// <summary>
        /// Acceptation of created event
        /// </summary>
        /// <param name="id">Event ID</param>
        /// <returns>Redirection to list of events</returns>
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Tutor)]
        [HttpGet]
        public ActionResult AcceptLessonConfirm(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return NotFound();
            }
            int userId = (int)HttpContext.Session.GetInt32("userId");
            @event.IdTutorNavigation = db.SscisUser.Find(id = userId);
            @event.IsAccepted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Creates new event
        /// </summary>
        /// <returns>Form view</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Tutor)]
        public ActionResult Create()
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            List<Approval> approvals = db.Approval.Where(a => a.IdTutor == userId).ToList();
            List<int> subjectsIds = new List<int>();
            foreach (Approval app in approvals)
            {
                subjectsIds.Add(app.IdSubject);
            }
            ViewBag.SubjectID = new SelectList(db.EnumSubject.Where(s => subjectsIds.Contains(s.Id)), "Id", "Code");


            if (db.SscisUser.Find(userId).IdRoleNavigation == db.EnumRole.Single(r => r.Role.Equals(SSCISResources.Resources.ADMIN)))
            {
                ViewBag.TutorID = new SelectList(db.SscisUser, "Id", "Login");
            } else
            {
                ViewBag.TutorID = new SelectList(db.SscisUser.Where(t => t.Id == userId), "Id", "Login");
            }
            return View();
        }

        /// <summary>
        /// Cretes new event
        /// </summary>
        /// <param name="@event">Event model</param>
        /// <returns>Creation result</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Tutor)]
        public ActionResult Create(MetaEvent model)
        {
            model.Event = new Event();
            if (ModelState.IsValid && model.Date >= DateTime.Now)
            {
                //int userId = (int)HttpContext.Session.GetInt32("userId");

                for (int i = 0; i < model.Recurrence; i++)
                {
                    Event newEvent = new Event();
                    newEvent.IdTutorNavigation = db.SscisUser.Find(model.TutorID);
                    newEvent.IdTutor = model.TutorID;
                    newEvent.IsCancelled = false;
                    if (newEvent.IdTutorNavigation.IdRoleNavigation.Role.Equals(SSCISResources.Resources.ADMIN))
                    {
                        newEvent.IsAccepted = true;
                    }
                    else
                    {
                        newEvent.IsAccepted = false;
                    }                   
                    newEvent.IsExtraLesson = false;
                    newEvent.TimeFrom = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.TimeFrom.Hour, model.TimeFrom.Minute, 0);
                    //model.Event.TimeTo = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.TimeTo.Hour, model.TimeTo.Minute, 0);

                    if (!BoolParser.Parse(db.SscisParam.Single(p => p.ParamKey.Equals(SSCISParameters.STANDART_EVENT_LENGTH)).ParamValue))
                    {
                        int hour = Convert.ToInt32(db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.STANDART_EVENT_LENGTH)).Single().ParamValue);
                        newEvent.TimeTo = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.TimeFrom.Hour + hour, model.TimeFrom.Minute, 0);
                    }
                    else
                    {
                        newEvent.TimeTo = model.Event.TimeFrom.AddHours(2);
                    }

                    newEvent.IdSubjectNavigation = db.EnumSubject.Find(model.SubjectID);
                    newEvent.IdSubject = (int)model.SubjectID;
                    newEvent.IdApplicantNavigation = null;
                    newEvent.IdApplicant = null;

                    int increase = i * 7;
                    newEvent.TimeFrom = newEvent.TimeFrom.AddDays(increase);
                    newEvent.TimeTo = newEvent.TimeTo.AddDays(increase);

                    db.Event.Add(newEvent);
                    db.SaveChanges();
                }
                return RedirectToAction("TutorEvents");
            }
            return RedirectToAction("Create");
        }

        /// <summary>
        /// Acceptation of created event
        /// </summary>
        /// <param name="id">Event ID</param>
        /// <returns>Redirection to list of events</returns>
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        [HttpGet]
        public ActionResult Accept(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return NotFound();
            }
            @event.IsAccepted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Cancellation of created event form
        /// </summary>
        /// <param name="id">Event ID</param>
        /// <returns>View with form</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Cancel(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        /// <summary>
        /// Cancellation of created event
        /// </summary>
        /// <param name="model">Event model</param>
        /// <returns>Redirection to list</returns>
        [HttpPost]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Cancel(Event model)
        {
            Event @event = db.Event.Find(model.Id);
            if (@event == null)
            {
                return NotFound();
            }
            @event.IsCancelled = true;
            @event.CancelationComment = model.CancelationComment;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Shows tutors events
        /// </summary>
        /// <returns>Tutors events view</returns>
        [Route("MyEvents")]
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Tutor)]
        public ActionResult TutorEvents()
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            ViewBag.TutorEventsTable = timetableRenderer.RenderTutor(db, userId);
            return View();
        }

        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Tutor)]
        public ActionResult Attendance(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewBag.SubjectID = new SelectList(db.EnumSubject, "Id", "Code", @event.IdSubject);
            ViewBag.TutorID = new SelectList(db.SscisUser, "Id", "Login", @event.IdTutor);
            return View(@event);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Tutor)]
        public ActionResult Attendance([Bind("Id","TimeFrom","TimeTo","IdSubject","IdTutor","IsAccepted","IsCancelled","CancellationComment", "Attendance")] Event model)
        {
            if (ModelState.IsValid)
            {
                int? attendance = model.Attendance;
                model = db.Event.Find(model.Id);
                model.Attendance = attendance;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        #region Unused
        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewBag.SubjectID = new SelectList(db.EnumSubject, "Id", "Code", @event.IdSubject);
            ViewBag.TutorID = new SelectList(db.SscisUser, "Id", "Login", @event.IdTutor);
            return View(@event);
        }

       
        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("ID,TimeFrom,TimeTo,SubjectID,TutorID,IsAccepted,IsCancelled,CancellationComment")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectID = new SelectList(db.EnumSubject, "ID", "Code", @event.IdSubject);
            ViewBag.TutorID = new SelectList(db.SscisUser, "ID", "Login", @event.IdTutor);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Event.Find(id);
            db.Event.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        /// <summary>
        /// Disposed controller
        /// </summary>
        /// <param name="disposing">dispose db context</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
