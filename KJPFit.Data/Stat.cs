using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJPFit.Data
{
    public class Stat
    {
        [Key]
        public int StatId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public int Weight{ get; set; }
        public DateTimeOffset WeightDate { get; set; }

        public string GoalMessage { get; set; }
        //[ForeignKey]
        //public int UserId { get; set; }
    }
}
