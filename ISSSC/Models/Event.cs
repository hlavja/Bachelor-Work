using System;
using System.Collections.Generic;

namespace ISSSC.Models
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
        public Nullable<bool> IsAccepted { get; set; }
        public int? Attendance { get; set; }
        public Nullable<bool> IsCancelled { get; set; }
        public string CancelationComment { get; set; }
        public Nullable<bool> IsExtraLesson { get; set; }
        public int? IdApplicant { get; set; }

        public virtual SscisUser IdApplicantNavigation { get; set; }
        public virtual EnumSubject IdSubjectNavigation { get; set; }
        public virtual SscisUser IdTutorNavigation { get; set; }
        public virtual ICollection<Participation> Participation { get; set; }
    }
}
