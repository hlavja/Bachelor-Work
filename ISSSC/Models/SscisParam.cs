﻿using System;
using System.Collections.Generic;

namespace ISSSC.Models
{
    public partial class SscisParam
    {
        public int Id { get; set; }
        public string ParamKey { get; set; }
        public string ParamValue { get; set; }
        public string Description { get; set; }
    }
}
