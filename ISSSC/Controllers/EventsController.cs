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
            var eventModel = db.Event.Where(e => e.TimeFrom > now).Include(@e => @e.IdSubjectNavigation).Include(@e => @e.IdTutorNavigation);
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
            ViewBag.TutorID = new SelectList(db.SscisUser.Where(t => t.Id == userId), "Id", "Login");
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
            if (ModelState.IsValid)
            {
                int userId = (int)HttpContext.Session.GetInt32("userId");
                model.Event.IdTutorNavigation = null;

                model.Event.IsCancelled = false;
                model.Event.IsAccepted = false;
                model.Event.IsExtraLesson = false;
                model.Event.TimeFrom = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.TimeFrom.Hour, model.TimeFrom.Minute, 0);
                model.Event.TimeTo = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.TimeTo.Hour, model.TimeTo.Minute, 0);
                model.Event.IdSubjectNavigation = db.EnumSubject.Find(model.SubjectID);
                db.Event.Add(model.Event);
                db.SaveChanges();
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
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Tutor)]
        public ActionResult TutorEvents()
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            ViewBag.TutorEventsTable = timetableRenderer.RenderTutor(db, userId);
            return View();
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
