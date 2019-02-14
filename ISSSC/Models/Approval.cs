using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class Approval
    {
        public int Id { get; set; }
        public int IdTutor { get; set; }
        public int IdSubject { get; set; }

        public EnumSubject IdSubjectNavigation { get; set; }
        public SscisUser IdTutorNavigation { get; set; }
    }
}
