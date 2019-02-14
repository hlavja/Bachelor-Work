using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class EnumSubject
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Lesson { get; set; }
        public int? IdParent { get; set; }

        public EnumSubject IdParentNavigation { get; set; }
        public Approval Approval { get; set; }
        public Event Event { get; set; }
        public EnumSubject InverseIdParentNavigation { get; set; }
        public TutorApplicationSubject TutorApplicationSubject { get; set; }
    }
}
