using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Data.Models
{
    public class VoteModel
    {
        public Vote Vote { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
