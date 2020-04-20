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
        public HtmlString Render(List<Event> myEvents, List<Event> myExtraEvents, List<Event> myEventsWithoutAttendace, int userId, bool showState = false)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<h4>Moje lekce</h4>");
            builder.Append("<div class=\"table-responsive\">");
            builder.Append("<table class=\"table table-responsive\">");
            builder.Append("<tr>");
            builder.Append("<th>Čas od</th>");
            builder.Append("<th>Čas do</th>");
            builder.Append("<th>Předmět</th>");
            builder.Append("</tr>");

            foreach (var item in myEvents)
            {
                if (item.IsCancelled == false && item.IsAccepted == true && item.TimeFrom >= DateTime.Now)
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
            builder.Append("</div>");

            if (myExtraEvents.Any())
            {
                builder.Append("<h4>Přijaté lekce</h4>");
                builder.Append("<div class=\"table-responsive\">");
                builder.Append("<table class=\"table table-responsive\">");
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
                builder.Append("</div>");


                builder.Append("<h4>Žádosti o lekce</h4>");
                builder.Append("<div class=\"table-responsive\">");
                builder.Append("<table class=\"table table-responsive\">");
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
                builder.Append("</div>");
            }
            if (myEventsWithoutAttendace.Any()) { 
                builder.Append("<h4>Nevyplněné návštěvnosti</h4>");
                builder.Append("<div class=\"table-responsive\">");
                builder.Append("<table class=\"table table-responsive\">");
                builder.Append("<tr>");
                builder.Append("<th>Čas od</th>");
                builder.Append("<th>Předmět</th>");
                builder.Append("<th>Vyplnit</th>");
                builder.Append("</tr>");

                foreach (var item in myEventsWithoutAttendace)
                {
                        builder.Append("<tr>");
                        builder.Append("<td>");
                        builder.Append(item.TimeFrom.ToString("d") + " " + item.TimeFrom.ToString("t"));
                        builder.Append("</td>");
                        builder.Append("<td>");
                        builder.Append(item.IdSubjectNavigation.Code);
                        builder.Append("</td>");
                        builder.Append("<td>");
                        builder.Append("<a href=\"/Events/Attendance/"+item.Id+"\" > Vyplnit</a>");
                        builder.Append("</td>");
                        builder.Append("</tr>");
                }

                builder.Append("</table>");
                builder.Append("</div>");
            }
            return new HtmlString(builder.ToString());
        }

        /// <summary>
        /// Renders attendance component
        /// </summary>
        /// <param name="events">List of my events without attendance</param>
        /// <returns>rendered component</returns>
        public HtmlString RenderAttendance(List<Event> myEventsWithoutAttendace)
        {
            StringBuilder builder = new StringBuilder();


            builder.Append("<h4>Nevyplněné návštěvnosti</h4>");
            builder.Append("<div class=\"table-responsive\">");
            builder.Append("<table class=\"table table-responsive\">");
            builder.Append("<tr>");
            builder.Append("<th class=\"col-md-5\">Čas od</th>");
            builder.Append("<th class=\"col-md-3\">Předmět</th>");
            builder.Append("<th>Vyplnit</th>");
            builder.Append("</tr>");

            foreach (var item in myEventsWithoutAttendace)
            {
                builder.Append("<tr>");
                builder.Append("<td class=\"col-md-3\">");
                builder.Append(item.TimeFrom.ToString("d") + " " + item.TimeFrom.ToString("t"));
                builder.Append("</td>");
                builder.Append("<td class=\"col-md-3\">");
                builder.Append(item.IdSubjectNavigation.Code);
                builder.Append("</td>");
                builder.Append("<td>");
                builder.Append("<a href=\"/Events/Attendance/" + item.Id + "\" > Vyplnit</a>");
                builder.Append("</td>");
                builder.Append("</tr>");
            }

            builder.Append("</table>");
            builder.Append("</div>");
            return new HtmlString(builder.ToString());
        }

        /// <summary>
        /// Renders attendance component
        /// </summary>
        /// <param name="db">Database context</param>
        /// <param name="userID">Logged user ID</param>
        /// <param name="weeks">Number of weeks</param>
        /// <returns>Html component</returns>
        public HtmlString RenderAttendance(SscisContext db, int userID, int weeks = 0)
        {
            List<Event> myEventsWithoutAttendance = db.Event.Where(e => (e.IdTutor == userID && e.IsAccepted == true && e.Attendance == null && e.IsCancelled == false && e.TimeTo <= DateTime.Now)).ToList();
            return RenderAttendance(myEventsWithoutAttendance);
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

            List<Event> myEvents = db.Event.Where(e => e.IdTutor == userID && e.IsAccepted == true).ToList();
            List<Event> myExtraEvents = db.Event.Where(e => e.IdApplicant == userID).ToList();
            List<Event> myEventsWithoutAttendance = db.Event.Where(e => (e.IdTutor == userID && e.IsAccepted == true && e.Attendance == null && e.IsCancelled == false && e.TimeTo <= DateTime.Now)).ToList();
            return Render(myEvents, myExtraEvents, myEventsWithoutAttendance, userID);
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