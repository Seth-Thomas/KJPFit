using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Models
{
    public class WorkoutCreate
    {
        [Display(Name = "Workout Name")]
        public string WorkoutName { get; set; }
        
        public List <ExerciseCreate> ExerciseCreates{ get; set; }
    }
}
