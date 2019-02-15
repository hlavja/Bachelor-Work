using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
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
    /// Static contents controller
    /// </summary>
    public class ContentsController : Controller
    {
        /// <summary>
        /// Database context
        /// </summary>
        private SscisContext db = new SscisContext();

        /// <summary>
        /// Content detail
        /// </summary>
        /// <param name="id">content id</param>
        /// <returns>View with content detail</returns>
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            SscisContent sSCISContent = db.SscisContent.Find(id);
            if (sSCISContent == null)
            {
                return NotFound();
            }
            return View(sSCISContent);
        }

        /// <summary>
        /// Creates new content
        /// </summary>
        /// <returns>View with form</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Create()
        {
            SscisContent model = new SscisContent();
            return View(model);
        }

        /// <summary>
        /// Creates new content and saves it to db
        /// </summary>
        /// <param name="sSCISContent">Content model</param>
        /// <returns>Redirection to List</returns>
        [HttpPost]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Create(SscisContent model)
        {
            if (ModelState.IsValid)
            {
                model.Created = DateTime.Now;
                int authorID = 1;
                //authorID = (int)HttpContext.Session.GetInt32("userID");
                model.IdAuthorNavigation = db.SscisUser.Find((int)authorID);
                model.IdEditedByNavigation = null;
                db.SscisContent.Add(model);
                db.SaveChanges();
                return RedirectToAction("News", "Home");
            }
            return View(model);
        }

        /// <summary>
        /// Editation of existing content
        /// </summary>
        /// <param name="id">Content ID</param>
        /// <returns>Editation form view</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            SscisContent sSCISContent = db.SscisContent.Find(id);
            if (sSCISContent == null)
            {
                return NotFound();
            }
            return View(sSCISContent);
        }

        /// <summary>
        /// Editation of existing content - saves changes
        /// </summary>
        /// <param name="sSCISContent">Content model</param>
        /// <returns>Redirection to list</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Edit([Bind("Id","IdAuthor","IdEditedBy","Created","Edited","TextContent","Header")] SscisContent model)
        {
            if (ModelState.IsValid)
            {
                string header = model.Header;
                string text = model.TextContent;
                model = db.SscisContent.Find(model.Id);
                model.Header = header;
                model.TextContent = text;
                model.Edited = DateTime.Now;

                //int authorID = (int)HttpContext.Session.GetInt32("userID");
                int authorID = 1;
                model.IdEditedByNavigation = db.SscisUser.Find(authorID);
                db.SaveChanges();
                return RedirectToAction("News", "Home");
            }
            return View(model);
        }

        /// <summary>
        /// Deletion dialog
        /// </summary>
        /// <param name="id">Content id</param>
        /// <returns>View with deletion digalog</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            SscisContent sSCISContent = db.SscisContent.Find(id);
            if (sSCISContent == null)
            {
                return NotFound();
            }
            return View(sSCISContent);
        }

        /// <summary>
        /// Delete existing content
        /// </summary>
        /// <param name="id">Content id</param>
        /// <returns>Redirectio to list</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult DeleteConfirmed(int id)
        {
            SscisContent sSCISContent = db.SscisContent.Find(id);
            db.SscisContent.Remove(sSCISContent);
            db.SaveChanges();
            return RedirectToAction("News", "Home");
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
