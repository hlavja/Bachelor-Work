using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class EnumSubject
    {
        public EnumSubject()
        {
            InverseIdParentNavigation = new HashSet<EnumSubject>();
            TutorApplicationSubject = new HashSet<TutorApplicationSubject>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Lesson { get; set; }
        public int? IdParent { get; set; }

        public virtual EnumSubject IdParentNavigation { get; set; }
        public virtual Approval Approval { get; set; }
        public virtual Event Event { get; set; }
        public virtual ICollection<EnumSubject> InverseIdParentNavigation { get; set; }
        public virtual ICollection<TutorApplicationSubject> TutorApplicationSubject { get; set; }
    }
}
