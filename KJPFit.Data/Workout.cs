using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Data
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        public string WorkoutName { get; set; }
        [DefaultValue(false)]
        public bool IsFavorited { get; set; }
        [Required]
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public virtual List<Exercise> Exercises { get; set; }
       
    }
}
