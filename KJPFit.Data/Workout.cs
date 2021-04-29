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
    public class Workout //Order
    {
        //One to Many FK for user and workout/exercises?
        //Many to Many FK for workout and exercise?
        [Key]
        public int WorkoutId { get; set; }
        //[Required]
        //public Guid OwnerId { get; set; }
        //[ForeignKey("User")]
        //public int UserId { get; set; }
        //public virtual User User { get; set; }
        [Required]
        public string WorkoutName { get; set; }
        [DefaultValue(false)]
        public bool IsFavorited { get; set; }
        [Required]
        public DateTimeOffset Created { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        public Workout()
        {
            Exercises = new HashSet<Exercise>();
        }
    }
}
