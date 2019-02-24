using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISSSC.Models.Meta
{
    public class Statistics
    {
        public List<MetaStat> Event { get; set; }

        [DisplayName("Od")]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }

        [DisplayName("Do")]
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
    }
}