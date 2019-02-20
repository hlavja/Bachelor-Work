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
    public class TutorApplicationSubjectsController : Controller
    {
        private SscisContext db = new SscisContext();

        #region Unused

        // GET: TutorApplicationSubjects
        public ActionResult Index()
        {
            var tutorApplicationSubject = db.TutorApplicationSubject.Include(t => t.IdSubjectNavigation).Include(t => t.IdApplicationNavigation);
            return View(tutorApplicationSubject.ToList());
        }

        // GET: TutorApplicationSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }
            TutorApplicationSubject tutorApplicationSubject = db.TutorApplicationSubject.Find(id);
            if (tutorApplicationSubject == null)
            {
                return NotFound();
            }
            return View(tutorApplicationSubject);
        }

        // GET: TutorApplicationSubjects/Create
        public ActionResult Create()
        {
            ViewBag.SubjectID = new SelectList(db.EnumSubject, "Id", "Code");
            ViewBag.ApplicationID = new SelectList(db.TutorApplication, "Id", "Id");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id","IdSubject","IdApplication","Degree")] TutorApplicationSubject tutorApplicationSubject)
        {
            if (ModelState.IsValid)
            {
                db.TutorApplicationSubject.Add(tutorApplicationSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectID = new SelectList(db.EnumSubject, "ID", "Code", tutorApplicationSubject.IdSubject);
            ViewBag.ApplicationID = new SelectList(db.TutorApplication, "ID", "ID", tutorApplicationSubject.IdApplication);
            return View(tutorApplicationSubject);
        }

        // GET: TutorApplicationSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            TutorApplicationSubject tutorApplicationSubject = db.TutorApplicationSubject.Find(id);
            if (tutorApplicationSubject == null)
            {
                return NotFound();
            }
            ViewBag.SubjectID = new SelectList(db.EnumSubject, "ID", "Code", tutorApplicationSubject.IdSubject);
            ViewBag.ApplicationID = new SelectList(db.TutorApplication, "ID", "ID", tutorApplicationSubject.IdApplication);
            return View(tutorApplicationSubject);
        }

        // POST: TutorApplicationSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id","IdSubject","IdApplication","Degree")] TutorApplicationSubject tutorApplicationSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tutorApplicationSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectID = new SelectList(db.EnumSubject, "ID", "Code", tutorApplicationSubject.IdSubject);
            ViewBag.ApplicationID = new SelectList(db.TutorApplication, "ID", "ID", tutorApplicationSubject.IdApplication);
            return View(tutorApplicationSubject);
        }

        // GET: TutorApplicationSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            TutorApplicationSubject tutorApplicationSubject = db.TutorApplicationSubject.Find(id);
            if (tutorApplicationSubject == null)
            {
                return NotFound();
            }
            return View(tutorApplicationSubject);
        }

        // POST: TutorApplicationSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TutorApplicationSubject tutorApplicationSubject = db.TutorApplicationSubject.Find(id);
            db.TutorApplicationSubject.Remove(tutorApplicationSubject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
