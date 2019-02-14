using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ISSSC.Models;
using ISSSC.Attributes;
using ISSSC.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SSCIS.Controllers
{
    /// <summary>
    /// Users management controller
    /// </summary>
    public class UsersController : Controller
    {
        /// <summary>
        /// Database context
        /// </summary>
        private SscisContext db = new SscisContext();

        

        /// <summary>
        /// Users list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Index()
        {
            var sSCISUser = db.SscisUser.Include(s => s.IdRoleNavigation).Include(s => s.IsActivatedByNavigation);
            return View(sSCISUser.ToList());
        }

        /// <summary>
        /// Users detail
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>View with user detail</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            SscisUser sSCISUser = db.SscisUser.Find(id);
            if (sSCISUser == null)
            {
                return NotFound();
            }
            return View(sSCISUser);
        }

        /// <summary>
        /// Lgged users detail
        /// </summary>
        /// <returns>View with logged user detail</returns>
        [HttpGet]
        public ActionResult Profil()
        {
            //int? id = (int)Session["userID"];
            int? id = (int)HttpContext.Session.GetInt32("userID");
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            SscisUser sSCISUser = db.SscisUser.Find(id);
            if (sSCISUser == null)
            {
                return NotFound();
            }
            return View("Details", sSCISUser);
        }

        /// <summary>
        /// Editation of existing user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>View with form for editation</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            SscisUser sSCISUser = db.SscisUser.Find(id);
            if (sSCISUser == null)
            {
                return NotFound();
            }
            ViewBag.RoleID = new SelectList(db.EnumRole, "ID", "RoleCode", sSCISUser.IdRole);
            ViewBag.ActivatedByID = new SelectList(db.SscisUser, "ID", "Login", sSCISUser.IsActivatedBy);
            return View(sSCISUser);
        }

        /// <summary>
        /// Saves changes from editation of user
        /// </summary>
        /// <param name="sSCISUser">User model</param>
        /// <returns>Redirection to list</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        //TODO public ActionResult Edit([Bind(Include = "ID,Login,Firstname,Lastname,Password,RoleID,IsActive,Created,Activated,ActivatedByID,StudentNumber")] SSCISUser sSCISUser)
        public ActionResult Edit([Bind("Id,Login,Firstname,Lastname,IdRole,IsActive,Created,Activated,StudentNumber,IsActivatedBy")] SscisUser sSCISUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sSCISUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.EnumRole, "ID", "RoleCode", sSCISUser.IdRole);
            ViewBag.ActivatedByID = new SelectList(db.SscisUser, "ID", "Login", sSCISUser.IsActivatedBy);
            return View(sSCISUser);
        }

        /// <summary>
        /// Deletion dialog of existing user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Dialog view</returns>
        [HttpGet]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            SscisUser sSCISUser = db.SscisUser.Find(id);
            if (sSCISUser == null)
            {
                return NotFound();
            }
            return View(sSCISUser);
        }

        /// <summary>
        /// Deletes existing user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Redirection to list</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Approval.RemoveRange(db.Approval.Where(a => a.IdTutor == id));
            SscisUser sSCISUser = db.SscisUser.Find(id);
            try
            {
                db.SscisSession.RemoveRange(db.SscisSession.Where(s => s.IdUser == id));
                db.SscisUser.Remove(sSCISUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("DeleteFailed");
            }

        }

        /// <summary>
        /// Disposes controller
        /// </summary>
        /// <param name="disposing">Dispose database context</param>
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
