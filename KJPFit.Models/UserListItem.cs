using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Models
{
    public class UserListItem
    {
        public  int  UserId { get; set; }
        public Guid OwnerId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Height(inches)")]
        public int? HeightInInches { get; set; }
        [Display(Name = "Date Joined")]
        public DateTimeOffset Joined { get; set; }
    }
}
