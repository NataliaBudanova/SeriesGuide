﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public class Review
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int AccountId { get; set; }
    }
}

