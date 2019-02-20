using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISSSC.Models
{
    public partial class SscisSession
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime Expiration { get; set; }
        public string Hash { get; set; }

        public virtual SscisUser IdUserNavigation { get; set; }
    }
}
