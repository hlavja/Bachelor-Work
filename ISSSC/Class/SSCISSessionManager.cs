using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ISSSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ISSSC.Class
{
    /// <summary>
    /// Session managing class
    /// </summary>
    public class SSCISSessionManager
    {
        public SscisContext db { get; set; }
        

        private SessionHashGenerator hashgenerator = new SessionHashGenerator();

        public SSCISSessionManager(SscisContext dbContext = null)
        {
            if (dbContext == null)
            {
                this.db = new SscisContext();
            }
            else
            {
                this.db = dbContext;
            }
        }

        /// <summary>
        /// Starts session for logging user
        /// </summary>
        /// <param name="login">user login</param>
        /// <param name="httpSession">session in request context</param>
        public int SessionStart(string login, HttpContext httpSession)
        {
            CleanSessions();

            SscisSession session = new SscisSession();
            session.SessionStart = DateTime.Now;
            session.Expiration = DateTime.Now.AddSeconds(long.Parse(db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.SESSION_LENGTH)).Single().ParamValue));
            session.Hash = hashgenerator.GenerateHash();
            db.SscisSession.Add(session);
            session.IdUserNavigation = db.SscisUser.Where(u => u.Login.Equals(login)).Single();
            db.SaveChanges();

            if (!BoolParser.Parse(db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.WEB_AUTH_ON)).Single().ParamValue))
            {
                httpSession.Session.SetInt32("sessionId", (int) session.Id);

                //httpSession.Session.SetString("role", session.IdUserNavigation.IdRoleNavigation.Role);

                if(session.IdUserNavigation.IdRole == 1)
                {
                    httpSession.Session.SetString("role", "ADMIN");
                } else if (session.IdUserNavigation.IdRole == 2)
                {
                    httpSession.Session.SetString("role", "TUTOR");
                } else if(session.IdUserNavigation.IdRole == 3)
                {
                    httpSession.Session.SetString("role", "USER");
                }

                httpSession.Session.SetString("hash", session.Hash);
                httpSession.Session.SetString("login", login);
                httpSession.Session.SetInt32("userId", session.IdUser);
            }
            return (int) session.Id;
        }

        /// <summary>
        /// Destroys existing session
        /// Session KAPUT
        /// </summary>
        /// <param name="sessionId">session id</param>
        /// <param name="httpSession">session in request conext</param>
        public void SessionDestroy(long sessionId, HttpContext httpSession)
        {
            db.SscisSession.Remove(db.SscisSession.Find((int)sessionId));
            db.SaveChanges();
            httpSession.Session.Remove("sessionId");
            httpSession.Session.Remove("role");
            httpSession.Session.Remove("hash");
            httpSession.Session.Remove("userId");
        }

        /// <summary>
        /// Verifies if session data stored in request context is correct according to session stored in DB
        /// </summary>
        /// <param name="httpSession">session in request context</param>
        /// <returns>True, if session data is correct, else false</returns>
        public bool VerifySession(ISession httpSession)
        {
            //SSCISSession dbSession = db.SSCISSession.Where(s => s.ID == (int)httpSession["sessionId"]).Single();
            SscisSession dbSession = db.SscisSession.Find(httpSession.GetInt32("sessionId"));
            if (dbSession.Expiration < DateTime.Now) return false;
            if (httpSession.GetString("hash") != null)
            {
                return dbSession.Hash.Equals((string)httpSession.GetString("hash"));
            }
            return false;
        }

        /// <summary>
        /// Clears expired sessions
        /// </summary>
        public void CleanSessions()
        {
            db.SscisSession.RemoveRange(db.SscisSession.Where(x => x.Expiration.CompareTo(DateTime.Now) < 0));
            db.SaveChanges();
        }

    }
}
