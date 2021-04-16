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
        public int? Weight { get; set; }
        [Display(Name = "Weight This Day")]
        public DateTimeOffset? WeightDate { get; set; }
        [MaxLength(5000)]
        public string GoalMessage { get; set; }
    }
}
