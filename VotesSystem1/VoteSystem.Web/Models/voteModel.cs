using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Data.Models
{
    public class VoteModel
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime DateFinish { get; set; }

        public string EmailRecipient { get; set; }
        public int CategoryID { get; set; }
        
        public VoteModel() { }
        public VoteModel(ICollection<Category> categories) 
        {
            Categories = categories;
        }

        public List<Question> Questions { get; set; }
        public Vote Vote { get; set; }
        public ICollection<Category> Categories { get; set; }

        public static implicit operator Vote(VoteModel vm)
        {
            Vote vote = new Vote();
            vote.ID = vm.ID;
            vote.IsPrivate = vm.IsPrivate;
            vote.Name = vm.Name;
            vote.Description = vm.Description;
            vote.DateFinish = vm.DateFinish;
            vote.EmailRecipient = vm.EmailRecipient;
            vote.Questions = vm.Questions;

            return vote;
        }

        public static implicit operator VoteModel(Vote vm)
        {
            VoteModel vote = new VoteModel();
            vote.ID = vm.ID;
            vote.IsPrivate = vm.IsPrivate;
            vote.Name = vm.Name;
            vote.Description = vm.Description;
            vote.DateFinish = vm.DateFinish;
            vote.EmailRecipient = vm.EmailRecipient;
            vote.Questions = vm.Questions;

            return vote;
        }
    }
}
