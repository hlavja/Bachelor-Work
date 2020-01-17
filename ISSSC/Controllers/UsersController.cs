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
using ISSSC.Models.Meta;

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

            //        subject, emails
            Dictionary<string, string> tutorEmailsLists = new Dictionary<string, string>();
            List<Approval> approvals = db.Approval.ToList();

            foreach (Approval app in approvals)
            {
                string code = app.IdSubjectNavigation.Code;
                string emails = null;
                if (!tutorEmailsLists.TryGetValue(code, out emails))
                {
                    emails = "";
                } else
                {
                    emails = tutorEmailsLists[code];
                }
                emails = emails + app.IdTutorNavigation.Email + ",";
                tutorEmailsLists[code] = emails;
            }

            string tutorEmails = "";

            foreach (var user in sSCISUser)
            {
                if (user.IdRoleNavigation.Role.Equals(SSCISResources.Resources.TUTOR))
                {
                    tutorEmails = tutorEmails + user.Email + ",";
                }
            }
            tutorEmailsLists["TUTORS"] = tutorEmails;


            ViewBag.TutorEmailsLists = tutorEmailsLists;
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
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.User)]
        public ActionResult Profil()
        {
            int? id = (int)HttpContext.Session.GetInt32("userId");
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

            ViewBag.IdRole = new SelectList(db.EnumRole, "Id", "Role", sSCISUser.IdRole);
            ViewBag.ActivatedByID = new SelectList(db.SscisUser, "Id", "Login", sSCISUser.IsActivatedBy);

            List<Approval> approvals = db.Approval.Where(a => a.IdTutor == sSCISUser.Id).ToList();
            List<EnumSubject> subjects = db.EnumSubject.Where(s => s.IdParent == null && s.Lesson == false).ToList();

            EditUser editUser = new EditUser();
            editUser.User = sSCISUser;
            editUser.Roles = db.EnumRole.ToList();
            List<MetaApproval> metaApprovals = new List<MetaApproval>();
            foreach (EnumSubject enumSubject in subjects)
            {
                MetaApproval metaApproval = new MetaApproval();
                foreach (Approval approval in approvals)
                {
                    if (approval.IdSubject == enumSubject.Id)
                    {
                        metaApproval.EnumSubject = enumSubject;
                        metaApproval.Approved = true;
                    }
                }
                if (metaApproval.EnumSubject == null)
                {
                    metaApproval.EnumSubject = enumSubject;
                    metaApproval.Approved = false;
                }
                metaApprovals.Add(metaApproval);
            }
            editUser.Approvals = metaApprovals;

            return View(editUser);

        }

        /// <summary>
        /// Saves changes from editation of user
        /// </summary>
        /// <param name="sSCISUser">User model</param>
        /// <returns>Redirection to list</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SSCISAuthorize(AccessLevel = AuthorizationRoles.Administrator)]
        public ActionResult Edit(EditUser editUser)
        {
            if (ModelState.IsValid)
            {
                editUser.User.IdRoleNavigation = db.EnumRole.Find(editUser.User.IdRole);
                db.Entry(editUser.User).State = EntityState.Modified;
                if (editUser.User.IdRoleNavigation.Role.Equals("USER"))
                {
                    List<Approval> userApproval = db.Approval.Where(a => a.IdTutor == editUser.User.Id).ToList();
                    foreach (Approval approval in userApproval)
                    {
                        db.Approval.Remove(approval);
                    }

                    List<Event> userEvent = db.Event.Where(a => a.IdTutor == editUser.User.Id).ToList();
                    foreach (Event sscisEvent in userEvent)
                    {
                        int authorID = (int)HttpContext.Session.GetInt32("userId");
                        SscisUser currentLoggedUser = db.SscisUser.Find((int)authorID);
                        sscisEvent.IdTutorNavigation = currentLoggedUser;
                        sscisEvent.CancelationComment = "Tutor fired!";
                        sscisEvent.IsCancelled = true;
                    }
                }
                else if (editUser.User.IdRoleNavigation.Role.Equals("ADMIN"))
                {
                    List<Approval> userApproval = db.Approval.Where(a => a.IdTutor == editUser.User.Id).ToList();
                    foreach (Approval approval in userApproval)
                    {
                        db.Approval.Remove(approval);
                    }
                    List<EnumSubject> subjects = db.EnumSubject.Where(s => s.IdParent == null && s.Lesson == false).ToList();
                    foreach (EnumSubject subject in subjects)
                    {
                        Approval newApproval = new Approval();
                        newApproval.IdSubject = subject.Id;
                        newApproval.IdSubjectNavigation = db.EnumSubject.Find(subject.Id);
                        newApproval.IdTutor = editUser.User.Id;
                        newApproval.IdTutorNavigation = db.SscisUser.Find(editUser.User.Id);
                        db.Approval.Add(newApproval);
                        db.SaveChanges();
                    }
                }
                else
                {
                    foreach (MetaApproval app in editUser.Approvals)
                    {
                        if (app.Approved == true)
                        {
                            List<Approval> tmp = db.Approval.Where(a => a.IdTutor == editUser.User.Id && a.IdSubject == app.EnumSubject.Id).ToList();
                            if (tmp.Count == 0)
                            {
                                Approval newApproval = new Approval();
                                newApproval.IdSubject = app.EnumSubject.Id;
                                newApproval.IdSubjectNavigation = db.EnumSubject.Find(app.EnumSubject.Id);
                                newApproval.IdTutor = editUser.User.Id;
                                newApproval.IdTutorNavigation = db.SscisUser.Find(editUser.User.Id);
                                db.Approval.Add(newApproval);
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            List<Approval> tmp = db.Approval.Where(a => a.IdTutor == editUser.User.Id && a.IdSubject == app.EnumSubject.Id).ToList();
                            foreach (Approval app2 in tmp)
                            {
                                db.Approval.Remove(app2);
                            }
                        }
                    }
                }
                editUser.Approvals = null;
                db.Entry(editUser.User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.EnumRole, "Id", "Role", editUser.User.IdRole);
            //ViewBag.RoleID = new SelectList(db.EnumRole.ToList(), "Id", "Role");
            ViewBag.ActivatedByID = new SelectList(db.SscisUser, "Id", "Login", editUser.User.IsActivatedBy);
            return View(editUser.User);
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
            int authorID = (int)HttpContext.Session.GetInt32("userId");
            SscisUser currentLoggedUser = db.SscisUser.Find((int)authorID);
            SscisUser sSCISUser = db.SscisUser.Find(id);

            try
            {
                db.SscisSession.RemoveRange(db.SscisSession.Where(s => s.IdUser == id));
                db.Approval.RemoveRange(db.Approval.Where(s => s.IdTutor == id));

                List<SscisContent> userContent = db.SscisContent.Where(a => a.IdAuthor == id || a.IdEditedBy == id).ToList();
                foreach (SscisContent content in userContent)
                {
                    if (content.IdAuthor == id)
                    {
                        content.IdAuthorNavigation = currentLoggedUser;
                    }
                    if (content.IdEditedBy == id)
                    {
                        content.IdEditedByNavigation = currentLoggedUser;
                    }
                }

                List<Participation> userParticipation = db.Participation.Where(a => a.IdUser == id).ToList();
                foreach (Participation participation in userParticipation)
                {
                    participation.IdUserNavigation = null;
                }

                List<Event> userEvent = db.Event.Where(a => a.IdTutor == id || a.IdApplicant == id).ToList();
                foreach (Event sscisEvent in userEvent)
                {
                    if (sscisEvent.IdTutor == id)
                    {
                        sscisEvent.IdTutorNavigation = currentLoggedUser;
                        sscisEvent.CancelationComment = "Tutor fired!";
                    }
                    if (sscisEvent.IdApplicant == id)
                    {
                        sscisEvent.CancelationComment = "ToS violation!";
                        sscisEvent.IdApplicantNavigation = null;
                    }
                    sscisEvent.IsCancelled = true;
                }

                List<TutorApplication> userAplication = db.TutorApplication.Where(a => a.IdUser == id).ToList();
                foreach (TutorApplication tutorApplication in userAplication)
                {
                    db.TutorApplicationSubject.RemoveRange(db.TutorApplicationSubject.Where(a => a.IdApplication == tutorApplication.Id));
                    db.TutorApplication.Remove(tutorApplication);
                }

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
