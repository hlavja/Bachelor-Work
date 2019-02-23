using System;
using System.Collections.Generic;

namespace ISSSC.sakila
{
    public partial class Event
    {
        public Event()
        {
            Participation = new HashSet<Participation>();
        }

        public int Id { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public int IdSubject { get; set; }
        public int? IdTutor { get; set; }
        public byte? IsAccepted { get; set; }
        public byte? IsCancelled { get; set; }
        public string CancelationComment { get; set; }
        public byte? IsExtraLesson { get; set; }
        public int? IdApplicant { get; set; }

        public virtual SscisUser IdApplicantNavigation { get; set; }
        public virtual EnumSubject IdSubjectNavigation { get; set; }
        public virtual SscisUser IdTutorNavigation { get; set; }
        public virtual ICollection<Participation> Participation { get; set; }
    }
}
