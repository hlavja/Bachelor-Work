using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class SscisUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int IdRole { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Activated { get; set; }
        public string StudentNumber { get; set; }
        public int? IsActivatedBy { get; set; }

        public EnumRole IdRoleNavigation { get; set; }
        public SscisUser IsActivatedByNavigation { get; set; }
        public Approval Approval { get; set; }
        public Event Event { get; set; }
        public SscisUser InverseIsActivatedByNavigation { get; set; }
        public Participation Participation { get; set; }
        public SscisContent SscisContentIdAuthorNavigation { get; set; }
        public SscisContent SscisContentIdEditedByNavigation { get; set; }
        public SscisSession SscisSession { get; set; }
        public TutorApplication TutorApplicationAcceptedBy { get; set; }
        public TutorApplication TutorApplicationIdUserNavigation { get; set; }
    }
}
