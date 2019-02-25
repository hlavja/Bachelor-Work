using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISSSC.Models;
using ISSSC.Models.Meta;
using ISSSC.Class;
using ISSSC.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace ISSSC.Controllers
{
    /// <summary>
    /// Subjects management controller
    /// </summary>
    public class SubjectsController : Controller
    {
        /// <summary>
        /// Database context
        /// </summary>
        private SscisContext db = new SscisContext();

        /// <summary>
        /// List of subjects
        /// </summary>
        /// <returns>View with list of subjects</returns>
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Index()
        {
            return View(db.EnumSubject.ToList());
        }

        /// <summary>
        /// Shows detail of subject
        /// </summary>
        /// <param name="id">Subject ID</param>
        /// <returns>View with detail</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            EnumSubject subject = db.EnumSubject.Find(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        /// <summary>
        /// Form for cretation of new subject
        /// </summary>
        /// <returns>View with form</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.EnumSubject.Where(s => s.Lesson == false /*&& s.Lesson.Value*/).ToList(), "Id", "Code");
            return View();
        }

        /// <summary>
        /// Creates new subject
        /// </summary>
        /// <param name="subject">Subject model</param>
        /// <returns>Redirection to list</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Create([Bind("Id","Code","Name")] EnumSubject subject)
        {
            if (ModelState.IsValid && subject.Code != null && subject.Name != null && subject.IdParent != null)
            {
                db.EnumSubject.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subject);
        }

        /// <summary>
        /// From for editation of existing subject
        /// </summary>
        /// <param name="id">Subject ID</param>
        /// <returns>View with form for editation</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            EnumSubject subject = db.EnumSubject.Find(id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewBag.ParentID = new SelectList(db.EnumSubject.Where(s => s.Lesson != null && s.Lesson.Value).ToList(), "Id", "Code");
            return View(subject);
        }

        /// <summary>
        /// Saves changes from editatoin of existing subject
        /// </summary>
        /// <param name="subject">Subject model</param>
        /// <returns>Redirection to list</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Edit(EnumSubject model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        /// <summary>
        /// Dialog for deletion of existing subject
        /// </summary>
        /// <param name="id">Subject ID</param>
        /// <returns>View with dialog</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            EnumSubject subject = db.EnumSubject.Find(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        /// <summary>
        /// Removes existing subject
        /// </summary>
        /// <param name="id">Subject ID</param>
        /// <returns>Redirection to list</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult DeleteConfirmed(int id)
        {
            EnumSubject subject = db.EnumSubject.Find(id);
            db.EnumSubject.Remove(subject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Disposes controller
        /// </summary>
        /// <param name="disposing">Dispose db context</param>
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
