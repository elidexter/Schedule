﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concert.Models
{
    public class CalendarModel
    {        
        public string Id { get; set; }

        public string Title { get; set; }
        public bool AllDay { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }        
    }
}