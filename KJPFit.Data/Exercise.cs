using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Data
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        [Required]
        public string ExerciseName { get; set; }
        [Required]
        public int? Sets { get; set; }
        [Required]
        public int? Reps { get; set; }
        [Required]
        public int? Weight { get; set; }
        [Required]
        public int? Distance { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
        
    }
}
