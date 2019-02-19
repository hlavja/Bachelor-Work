using ISSSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace ISSSC.Class
{
    /// <summary>
    /// Feedback URL generator
    /// </summary>
    public class FeedbackUrlGenerator
    {
        /// <summary>
        /// Generates url for feedback qr code
        /// </summary>
        /// <param name="eventId">Event ID</param>
        /// <param name="db">Database context</param>
        /// <returns>Generated URL</returns>
        public string GenerateURL(int eventId, SscisContext db)
        {
            Event e = db.Event.Find(eventId);
            string code = string.Format("{0}{1}{2}{3}", e.TimeFrom.Year.ToString("0000").Substring(2), e.TimeFrom.Month.ToString("00"), e.TimeFrom.Day.ToString("00"), eventId);
            return string.Format("{0}Feedbacks?code={1}", _addSlash(SSCHttpContext.AppBaseUrl), code);
        }

        /// <summary>
        /// Resolves event id from feedback code
        /// </summary>
        /// <param name="code">Feedback code from end of URL</param>
        /// <returns>Event id</returns>
        public int? ResolveEventID(string code)
        {
            int result = -1;
            if (int.TryParse(code.Substring(6), out result))
            {
                return result;
            }
            return null;
        }

        /// <summary>
        /// Adds slash at the end of URL if needed
        /// </summary>
        /// <param name="url">URL string</param>
        /// <returns>Url with slash at the end</returns>
        private string _addSlash(string url)
        {
            return url.EndsWith("/") ? url : url + "/";
        }
    }
}