using KJPFit.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Models
{
    public class StatListItem
    {
        public int StatId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? HeightInInches { get; set; }
        public int? Weight { get; set; }
        [Display(Name="Weight This Day")]
        public DateTimeOffset WeightDate { get; set; }
        [MaxLength (5000)]
        public string GoalMessage { get; set; }

    }
}
