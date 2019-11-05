using Microsoft.AspNetCore.Http;
using ISSSC.Models;
using System;
using System.Linq;

namespace ISSSC.Class
{
    /// <summary>
    /// Session managing class
    /// </summary>
    public class SSCISSessionManager
    {
        public SscisContext db { get; set; }
        
        private readonly SessionHashGenerator hashgenerator = new SessionHashGenerator();

        public SSCISSessionManager(SscisContext dbContext = null)
        {
            this.db = dbContext ?? new SscisContext();
        }

        /// <summary>
        /// Starts session for logging user
        /// </summary>
        /// <param name="login">user login</param>
        /// <param name="httpSession">session in request context</param>
        public int SessionStart(string login, HttpContext httpSession)
        {
            CleanSessions(login);

            var session = new SscisSession
            {
                SessionStart = DateTime.Now,
                Expiration = DateTime.Now.AddSeconds(long.Parse(db.SscisParam.Single(p => p.ParamKey.Equals(SSCISParameters.SESSIONLENGTH)).ParamValue)),
                Hash = hashgenerator.GenerateHash()
            };
            db.SscisSession.Add(session);
            session.IdUserNavigation = db.SscisUser.Single(u => u.Login.Equals(login));
            db.SaveChanges();

            if (!BoolParser.Parse(db.SscisParam.Single(p => p.ParamKey.Equals(SSCISParameters.WEBAUTHON)).ParamValue))
            {
                httpSession.Session.SetInt32("sessionId", (int) session.Id);
                httpSession.Session.SetString("role", session.IdUserNavigation.IdRoleNavigation.Role);
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
            var dbSession = db.SscisSession.Find(httpSession.GetInt32("sessionId"));

            if (dbSession == null || dbSession.Expiration < DateTime.Now)
            {
                return false;
            }

            return httpSession.GetString("hash") != null && dbSession.Hash.Equals((string)httpSession.GetString("hash"));
        }

        /// <summary>
        /// Clears expired sessions
        /// </summary>
        public void CleanSessions(string login = null)
        {
            db.SscisSession.RemoveRange(db.SscisSession.Where(x => x.Expiration.CompareTo(DateTime.Now) < 0));
            if (login != null)
                db.SscisSession.RemoveRange(db.SscisSession.Where(s => s.IdUserNavigation.Login.Equals(login)));
            db.SaveChanges();
        }

    }
}
