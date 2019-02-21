using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class EnumRole
    {
        public EnumRole()
        {
            SscisUser = new HashSet<SscisUser>();
        }

        public int Id { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SscisUser> SscisUser { get; set; }
    }
}
