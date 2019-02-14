using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class SscisSession
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime Expiration { get; set; }
        public string Hash { get; set; }

        public SscisUser IdUserNavigation { get; set; }
    }
}
