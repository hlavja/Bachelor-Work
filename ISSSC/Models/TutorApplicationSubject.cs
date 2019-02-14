using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class TutorApplicationSubject
    {
        public int Id { get; set; }
        public int IdSubject { get; set; }
        public int IdApplication { get; set; }
        public byte? Degree { get; set; }

        public TutorApplication IdApplicationNavigation { get; set; }
        public EnumSubject IdSubjectNavigation { get; set; }
    }
}
