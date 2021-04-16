using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Models
{
    public class WorkoutListItem
    {
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [UIHint("Favorited")]
        [Display(Name = "Important")]
        public bool IsFavorited { get; set; } 

        // ElevenNote Star 0.01 module after workout is finished
    }
}
