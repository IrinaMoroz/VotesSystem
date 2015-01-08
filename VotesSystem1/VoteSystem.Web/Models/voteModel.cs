using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Data.Models
{
    public class VoteModel
    {
        public VoteModel() { }
        public VoteModel(Vote vote, ICollection<Category> categories) 
        {
            Vote = vote;
            Categories = categories;
        }

        public Question Question { get; set; }
        public Vote Vote { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
