using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int HeightInInches { get; set; }
        public DateTimeOffset Joined { get; set; }
        public DateTimeOffset Modified { get; set; }
        
       
    }
}
