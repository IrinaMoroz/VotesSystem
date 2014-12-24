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
                new User{ID=0, Name="Name0", Login="Login0"},
                new User{ID=1, Name="Name1", Login="Login1"},
                new User{ID=2, Name="Name2", Login="Login2"}
            };

            var categories = new List<Category>
            {
                new Category{ID=0, Name="Category0"},
                new Category{ID=1, Name="Category1"}
            };
            var questions = new List<Question>
            {
                new Question{ID=0, Name="Question0", VoitCounts=1, Users=new List<User>{users[0]}},
                new Question{ID=1, Name="Question1", VoitCounts=1}
            };
            var votes = new List<Vote>
            {
                new Vote{ID=0, Category=categories[0], Description="description0", EmailRecipient="email0",
                 IsPrivate=false, LastModifiedBy="Olosh", LastModifiedDate=new DateTime(), Name="Vote0", 
                 Questions=new List<Question>{questions[0], questions[1]}, User=users[0]},
                new Vote{ID=1, Category=categories[1], Description="description1", EmailRecipient="email1",
                IsPrivate=true, LastModifiedBy="Olosh1", LastModifiedDate=new DateTime(), Name="Vote1", 
                Questions=new List<Question>{questions[0], questions[1]}, User=users[1]}
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
