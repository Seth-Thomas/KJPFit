using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Models
{
    public class UserListItem
    {
        public  int  UserId { get; set; }
        public Guid OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? HeightInInches { get; set; }
        public DateTimeOffset Joined { get; set; }
    }
}
