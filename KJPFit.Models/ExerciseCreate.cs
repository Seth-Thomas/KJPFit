using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Models
{
    public class ExerciseCreate
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public int? Weight { get; set; }
        public int? Distance { get; set; }
        //public virtual ICollection<Workout> Workouts { get; set; }
    }
}
