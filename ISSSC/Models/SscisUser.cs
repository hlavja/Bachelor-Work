using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class SscisUser
    {
        public SscisUser()
        {
            SscisContentIdAuthorNavigation = new HashSet<SscisContent>();
            SscisContentIdEditedByNavigation = new HashSet<SscisContent>();
            TutorApplicationAcceptedBy = new HashSet<TutorApplication>();
            TutorApplicationIdUserNavigation = new HashSet<TutorApplication>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int IdRole { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Activated { get; set; }
        public string StudentNumber { get; set; }
        public int? IsActivatedBy { get; set; }

        public virtual EnumRole IdRoleNavigation { get; set; }
        public virtual SscisUser IsActivatedByNavigation { get; set; }
        public virtual Approval Approval { get; set; }
        public virtual Event Event { get; set; }
        public virtual SscisUser InverseIsActivatedByNavigation { get; set; }
        public virtual Participation Participation { get; set; }
        public virtual SscisSession SscisSession { get; set; }
        public virtual ICollection<SscisContent> SscisContentIdAuthorNavigation { get; set; }
        public virtual ICollection<SscisContent> SscisContentIdEditedByNavigation { get; set; }
        public virtual ICollection<TutorApplication> TutorApplicationAcceptedBy { get; set; }
        public virtual ICollection<TutorApplication> TutorApplicationIdUserNavigation { get; set; }
    }
}
