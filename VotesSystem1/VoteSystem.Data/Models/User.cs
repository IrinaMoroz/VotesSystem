using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Data
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Login { get; set; }

        public virtual ICollection<Vote> Vote { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
