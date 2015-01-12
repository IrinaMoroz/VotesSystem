using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Data.Models
{
    public class QuestionModel
    {
        public int ID { get; set; }
        public int VoteID{get; set;}
        public Vote vote { get; set; }
        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
