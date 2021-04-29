using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Data
{
    
    //public enum Category
    //{
    //   UpperBody,
    //   LowerBody,
    //   Core,
    //   Cardio
    //}
    public class Exercise
    {
        
        [Key]
        public int ExerciseId { get; set; }
        [Required]
        public string ExerciseName { get; set; }
        
        public int? Sets { get; set; }
        
        public int? Reps { get; set; }
        
        public int? Weight { get; set; }
        
        public int? DistanceInMiles { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }

        public Exercise()
        {
            Workouts = new HashSet<Workout>(); 
        }
    }
}
