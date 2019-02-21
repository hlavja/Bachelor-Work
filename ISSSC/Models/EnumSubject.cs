using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class EnumSubject
    {
        public EnumSubject()
        {
            Approval = new HashSet<Approval>();
            Event = new HashSet<Event>();
            InverseIdParentNavigation = new HashSet<EnumSubject>();
            TutorApplicationSubject = new HashSet<TutorApplicationSubject>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Lesson { get; set; }
        public Nullable<int> IdParent { get; set; }

        public virtual EnumSubject IdParentNavigation { get; set; }
        public virtual ICollection<Approval> Approval { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<EnumSubject> InverseIdParentNavigation { get; set; }
        public virtual ICollection<TutorApplicationSubject> TutorApplicationSubject { get; set; }
    }
}
