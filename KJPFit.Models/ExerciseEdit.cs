﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Models
{
    public class ExerciseEdit
    {
        public int ExerciseId { get; set; }
        [Display(Name = "Exercise")]
        public string ExerciseName { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public int? Weight { get; set; }
        [Display(Name = "Distance(miles)")]
        public int? DistanceInMiles { get; set; }
    }
}
