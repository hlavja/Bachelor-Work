using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISSSC.Models.Meta
{
    public class MetaStat
    {
        public int Id { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public int FeedbacksCount { get; set; }
        
        public virtual Event IdEventNavigation { get; set; }
        public virtual SscisUser IdTutorNavigation { get; set; }
        public virtual EnumSubject IdSubjectNavigation { get; set; }
    }
}