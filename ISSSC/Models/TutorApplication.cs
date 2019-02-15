using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class TutorApplication
    {
        public TutorApplication()
        {
            TutorApplicationSubject = new HashSet<TutorApplicationSubject>();
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime ApplicationDate { get; set; }
        public byte? IsAccepted { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public int? AcceptedById { get; set; }

        public virtual SscisUser AcceptedBy { get; set; }
        public virtual SscisUser IdUserNavigation { get; set; }
        public virtual ICollection<TutorApplicationSubject> TutorApplicationSubject { get; set; }
    }
}
