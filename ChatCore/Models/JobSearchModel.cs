﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.Models
{
    public class JobSearchModel
    {
        public String Keyword { get; set; }
        public String Location { get; set; }
        public int PageIndex { get; set; }
    }
}