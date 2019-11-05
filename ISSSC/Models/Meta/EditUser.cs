using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISSSC.Models.Meta
{
    public class EditUser
    {
        public SscisUser User { get; set; }

        public List<MetaApproval> Approvals { get; set; }

        public List<EnumRole> Roles { get; set; }
    }
}
