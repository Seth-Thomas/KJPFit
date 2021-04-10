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
        //[Range(1,10, ErrorMessage="please choose a number between 1 and 10")]
        //[MaxLength(100, ErrorMessage="too many characters in this field")]
        //[Display(Name="Your Name")]
        public Guid OwnerId { get; set; }
        [Required]
        public string WorkoutName { get; set; }
        //[DefaultValue(false)]
        //public bool IsFavorited { get; set; }
        [Required]
        public DateTimeOffset Created { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
