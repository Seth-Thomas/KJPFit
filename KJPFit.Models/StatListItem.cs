﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Models
{
    public class StatListItem
    {
        public int StatId { get; set; }
        public decimal? Weight { get; set; }
        public DateTimeOffset WeightDate { get; set; }
    }
}
