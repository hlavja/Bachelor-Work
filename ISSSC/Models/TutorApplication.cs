using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class TutorApplication
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime ApplicationDate { get; set; }
        public byte? IsAccepted { get; set; }
        public DateTime AcceptedDate { get; set; }
        public int? AcceptedById { get; set; }

        public SscisUser AcceptedBy { get; set; }
        public SscisUser IdUserNavigation { get; set; }
        public TutorApplicationSubject TutorApplicationSubject { get; set; }
    }
}
