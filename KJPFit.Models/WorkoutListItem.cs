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
        [Display(Name = "Workout Name")]
        public string WorkoutName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [UIHint("Starred")]
        [Display(Name = "Favorited Workout")]
        public bool IsFavorited { get; set; } 

        
    }
}
