using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int IdParticipation { get; set; }
        public string Text { get; set; }

        public Participation IdParticipationNavigation { get; set; }
    }
}
