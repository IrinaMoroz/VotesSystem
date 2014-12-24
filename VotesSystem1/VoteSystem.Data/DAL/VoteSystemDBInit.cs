using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Data.DAL
{
    public class VoteSystemDBInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<VoteSystemContext>
    {
        protected override void Seed(VoteSystemContext context)
        {
            var users = new List<User>
            {
                new User{Name="Name0", Login="Login0"},
                new User{Name="Name1", Login="Login1"},
                new User{Name="Name2", Login="Login2"}
            };

            var categories = new List<Category>
            {
                new Category{Name="Category0"},
                new Category{Name="Category1"}
            };
            var questions = new List<Question>
            {
                new Question{Name="Question0", VoitCounts=1, Users=new List<User>{users[0]}},
                new Question{Name="Question1", VoitCounts=1}
            };
            var votes = new List<Vote>
            {
                new Vote{Category=categories[0], Description="description0", EmailRecipient="email0",
                 IsPrivate=false, LastModifiedBy="Olosh", LastModifiedDate=DateTime.Now, Name="Vote0", 
                 Questions=new List<Question>{questions[0], questions[1]}, User=users[0], DateFinish=new DateTime(2014, 12, 23, 12,00,00)},
                new Vote{Category=categories[1], Description="description1", EmailRecipient="email1",
                IsPrivate=true, LastModifiedBy="Olosh1", LastModifiedDate=DateTime.Now, Name="Vote1", 
                Questions=new List<Question>{questions[0], questions[1]}, User=users[1],DateFinish=new DateTime(2014, 12, 30, 12,00,00)}
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();
            
            questions.ForEach(s => context.Questions.Add(s));
            context.SaveChanges();
            
            votes.ForEach(s => context.Votes.Add(s));
            context.SaveChanges();
        }
    }
}
