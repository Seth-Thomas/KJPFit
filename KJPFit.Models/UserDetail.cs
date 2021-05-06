using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Models
{
    public class UserDetail
    {
        public int UserId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Height(inches)")]
        public int? HeightInInches { get; set; }
        [Display(Name = "Date Joined")]
        public DateTimeOffset? Joined { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? Modified { get; set; }
    }
}