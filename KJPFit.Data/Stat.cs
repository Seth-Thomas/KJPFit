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

        [ForeignKey(nameof(User))]
        public int UserStatId { get; set; }
        public virtual User User { get; set; }
        
        [Required]
        public int Weight{ get; set; }
        public DateTimeOffset WeightDate { get; set; }
        [MaxLength(5000)]
        public string GoalMessage { get; set; }
        
    }
}
