using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VoteSystem.Data
{
    public class Vote
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Question")]
        public string Description { get; set; }
        [Display(Name = "Private vote")]
        public bool IsPrivate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", 
            ApplyFormatInEditMode = true)]
        public DateTime DateFinish { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Email Recipient")]
        public string EmailRecipient { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public virtual User User { get; set; }
        [Display(Name = "Category: ")]
        public virtual Category Category { get; set; }
        public virtual List<Question> Questions { get; set; }

    }
}
