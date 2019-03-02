using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISSSC.Models.Meta
{
    public class MetaTutor
    {
        public int Id { get; set; }

        public int Lessons { get; set; }
        public int MathLessons { get; set; }
        public int MechLessons { get; set; }
        public int InfLessons { get; set; }

        public int LessonsHours { get; set; }


        public virtual SscisUser IdTutorNavigation { get; set; }
    }
}