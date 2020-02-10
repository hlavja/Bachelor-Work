using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISSSC.Models.Meta
{
    public class MetaTimetable
    {

        public List<DateTime> dateTimes { get; set; }

        public List<SscisUser> tutors { get; set; }

        public Dictionary<SscisUser, List<Event>> attendance { get; set; }
    }
}