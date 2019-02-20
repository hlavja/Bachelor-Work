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
    /// Controller for Parameters management
    /// </summary>
    public class SSCISParamsController : Controller
    {
        /// <summary>
        /// Database context
        /// </summary>
        private SscisContext db = new SscisContext();

        /// <summary>
        /// List of params
        /// </summary>
        /// <returns>View with all params</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Index()
        {
            return View(db.SscisParam.ToList());
        }

        /// <summary>
        /// Detail of system parameter
        /// </summary>
        /// <param name="id">Parameter ID</param>
        /// <returns>View with detail</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            SscisParam sSCISParam = db.SscisParam.Find(id);
            if (sSCISParam == null)
            {
                return NotFound();
            }
            return View(sSCISParam);
        }

        /// <summary>
        /// Form for creation of new parameter
        /// </summary>
        /// <returns>View with form</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates new system parameter
        /// </summary>
        /// <param name="sSCISParam">Parameter model</param>
        /// <returns>Redirection to list</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Create([Bind("Id","ParamKey","ParamValue","Description")] SscisParam sSCISParam)
        {
            if (ModelState.IsValid)
            {
                db.SscisParam.Add(sSCISParam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sSCISParam);
        }

        /// <summary>
        /// Form for editing existing parameter
        /// </summary>
        /// <param name="id">Parameter ID</param>
        /// <returns>View with form</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            SscisParam sSCISParam = db.SscisParam.Find(id);
            if (sSCISParam == null)
            {
                return NotFound();
            }
            return View(sSCISParam);
        }

        /// <summary>
        /// Saves changes from editatoin of parameter
        /// </summary>
        /// <param name="sSCISParam">Parameter model</param>
        /// <returns>Redirection to list</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Edit([Bind("Id","ParamKey","ParamValue","Description")] SscisParam sSCISParam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sSCISParam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sSCISParam);
        }

        /// <summary>
        /// Deletion of existing parameter form
        /// </summary>
        /// <param name="id">Parameter ID</param>
        /// <returns>View with deletion dialogue</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            SscisParam sSCISParam = db.SscisParam.Find(id);
            if (sSCISParam == null)
            {
                return NotFound();
            }
            return View(sSCISParam);
        }

        /// <summary>
        /// Deletes existing parameter
        /// </summary>
        /// <param name="id">Parameter ID</param>
        /// <returns>Redirection to list</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult DeleteConfirmed(int id)
        {
            SscisParam sSCISParam = db.SscisParam.Find(id);
            db.SscisParam.Remove(sSCISParam);
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

