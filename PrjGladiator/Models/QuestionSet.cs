using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PrjGladiator.Models
{
    public class QuestionSet
    {   
        [Key]
        public int QuestionSet_Id { get; set; }
        public int Level { get; set; }
        [ForeignKey("Subject")]
        public int SubjectRef_Id { get; set; }
        public Subject Subject { get; set; }
        public ICollection <Question> Questions { get; set; }
    }
}
