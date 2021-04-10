using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Data
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }
        [Required]
        public string WorkoutName { get; set; }
        //[DefaultValue(false)]
        //public bool IsFavorited { get; set; }
        [Required]
        public DateTimeOffset Created { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
