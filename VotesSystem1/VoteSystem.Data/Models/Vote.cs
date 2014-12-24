using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Data
{
    public class Vote
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public string EmailRecipient { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

    }
}
