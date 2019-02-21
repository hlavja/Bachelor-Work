using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class SscisContent
    {
        public int Id { get; set; }
        public int IdAuthor { get; set; }
        public int? IdEditedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Edited { get; set; }
        public string TextContent { get; set; }
        public string Header { get; set; }

        public virtual SscisUser IdAuthorNavigation { get; set; }
        public virtual SscisUser IdEditedByNavigation { get; set; }
    }
}
