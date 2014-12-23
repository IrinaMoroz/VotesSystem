using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Data
{
    public class User
    {
        public int ID { get; set; }
        
        public string Name { get; set; }

        public string Login { get; set; }

        public virtual ICollection<Vote> Vote { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
