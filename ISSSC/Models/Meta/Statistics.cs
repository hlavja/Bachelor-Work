using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISSSC.Models.Meta
{
    public class Statistics
    {
        public List<MetaStat> Event { get; set; }

        public int Lessons { get; set; }
        public int MathLessons { get; set; }
        public int MechLessons { get; set; }
        public int InfLessons { get; set; }

        public int LessonsHours { get; set; }
        public int MathLessonsHours { get; set; }
        public int MechLessonsHours { get; set; }
        public int InfLessonsHours { get; set; }

        [DisplayName("Od")]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }

        [DisplayName("Do")]
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
    }
}