using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Models
{
    public class StatDetails
    {
        public int StatId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Height(inches)")]
        public int? HeightInInches { get; set; }
        public int? Weight { get; set; }
        [Display(Name = "Weight This Day")]
        public DateTimeOffset? WeightDate { get; set; }
        [Display(Name = "Goal Message")]
        [MaxLength(5000)]
        public string GoalMessage { get; set; }
    }
}
