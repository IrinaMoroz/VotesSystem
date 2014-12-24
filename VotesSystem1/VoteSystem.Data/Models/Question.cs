using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Data
{
    public class Question
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int VoitCounts { get; set; }
        public virtual Vote Vote { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
