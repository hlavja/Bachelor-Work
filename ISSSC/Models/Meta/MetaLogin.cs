using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ISSSC.Models.Meta
{
    public class MetaLogin
    {
        public string Login { get; set; }
        public string ValidationMessage { get; set; }
        public string RedirectionUrl { get; set; }
    }
}
