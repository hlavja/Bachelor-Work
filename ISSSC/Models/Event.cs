using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public int IdSubject { get; set; }
        public int IdTutor { get; set; }
        public bool? IsAccepted { get; set; }
        public bool? IsCancelled { get; set; }
        public string CancelationComment { get; set; }
        public bool? IsExtraLesson { get; set; }

        public EnumSubject IdSubjectNavigation { get; set; }
        public SscisUser IdTutorNavigation { get; set; }
        public Participation Participation { get; set; }
    }
}
