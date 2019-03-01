using ISSSC.Models;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace ISSSC.Class
{
    /// <summary>
    /// Class for rendering timetable component
    /// </summary>
    public class PersonalTimetable
    {
        /// <summary>
        /// Renders timetable component
        /// </summary>
        /// <param name="events">List of events to display</param>
        /// <param name="showState">Show state of event</param>
        /// <returns>rendered component</returns>
        public HtmlString Render(List<Event> myEvents, List<Event> myExtraEvents, int userId, bool showState = false)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<h4>Moje lekce</h4>");
            builder.Append("<table class=\"table\">");
            builder.Append("<tr>");
            builder.Append("<th>Čas od</th>");
            builder.Append("<th>Čas do</th>");
            builder.Append("<th>Předmět</th>");
            builder.Append("</tr>");

            foreach (var item in myEvents)
            {
                if (item.IsCancelled == false && item.TimeFrom >= DateTime.Now)
                {
                    builder.Append("<tr>");
                    builder.Append("<td>");
                    builder.Append(item.TimeFrom.ToString("d") + " " + item.TimeFrom.ToString("t"));
                    builder.Append("</td>");
                    builder.Append("<td>");
                    builder.Append(item.TimeTo.ToString("d") + " " + item.TimeTo.ToString("t"));
                    builder.Append("</td>");
                    builder.Append("<td>");
                    builder.Append(item.IdSubjectNavigation.Code);
                    builder.Append("</td>");
                    builder.Append("</tr>");
                }
            }

            builder.Append("</table>");



            builder.Append("<h4>Přijaté lekce</h4>");
            builder.Append("<table class=\"table\">");
            builder.Append("<tr>");
            builder.Append("<th>Čas od</th>");
            builder.Append("<th>Čas do</th>");
            builder.Append("<th>Předmět</th>");
            builder.Append("</tr>");

            foreach (var item in myExtraEvents)
            {
                if (item.IdApplicant == userId && item.IdTutor != null && item.TimeFrom >= DateTime.Now)
                {
                    builder.Append("<tr>");
                    builder.Append("<td>");
                    builder.Append(item.TimeFrom.ToString("d") + " " + item.TimeFrom.ToString("t"));
                    builder.Append("</td>");
                    builder.Append("<td>");
                    builder.Append(item.TimeTo.ToString("d") + " " + item.TimeTo.ToString("t"));
                    builder.Append("</td>");
                    builder.Append("<td>");
                    builder.Append(item.IdSubjectNavigation.Code);
                    builder.Append("</td>");
                    builder.Append("</tr>");
                }
            }

            builder.Append("</table>");



            builder.Append("<h4>Žádosti o lekce</h4>");
            builder.Append("<table class=\"table\">");
            builder.Append("<tr>");
            builder.Append("<th>Čas od</th>");
            builder.Append("<th>Čas do</th>");
            builder.Append("<th>Předmět</th>");
            builder.Append("</tr>");

            foreach (var item in myExtraEvents)
            {
                if (item.IdApplicant == userId && item.IdTutor == null && item.IsAccepted == false && item.TimeFrom >= DateTime.Now)
                {
                    builder.Append("<tr>");
                    builder.Append("<td>");
                    builder.Append(item.TimeFrom.ToString("d") + " " + item.TimeFrom.ToString("t"));
                    builder.Append("</td>");
                    builder.Append("<td>");
                    builder.Append(item.TimeTo.ToString("d") + " " + item.TimeTo.ToString("t"));
                    builder.Append("</td>");
                    builder.Append("<td>");
                    builder.Append(item.IdSubjectNavigation.Code);
                    builder.Append("</td>");
                    builder.Append("</tr>");
                }
            }

            builder.Append("</table>");
            return new HtmlString(builder.ToString());
        }

        /// <summary>
        /// Renders public event timetable component
        /// </summary>
        /// <param name="db">Database context</param>
        /// <param name="weeks">Weeks</param>
        /// <returns>Html component</returns>
        public HtmlString RenderEvents(SscisContext db, int userID, int weeks = 0)
        {
            DateTime now = DateTime.Now;
            now.AddDays(7 * weeks);
            DateTime start = _startOfWeek(now, DayOfWeek.Monday);
            DateTime end = start.AddDays(7);
            DateTime endTime = now.AddDays(7);

            List<Event> myEvents = db.Event.Where(e => e.IdTutor == userID).ToList();
            List<Event> myExtraEvents = db.Event.Where(e => e.IdApplicant == userID).ToList();
            return Render(myEvents, myExtraEvents, userID);
        }

        /// <summary>
        /// Finds start day of week
        /// </summary>
        /// <param name="dt">date</param>
        /// <param name="startOfWeek">start day</param>
        /// <returns>start date</returns>
        private DateTime _startOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

    }
}