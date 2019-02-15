using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class EnumRole
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }

        public virtual SscisUser SscisUser { get; set; }
    }
}
