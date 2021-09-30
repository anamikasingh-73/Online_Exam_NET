using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PrjGladiator.Models
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Report_Id { get; set; }
        public int Marks { get; set; }
        [IgnoreDataMember]
        [ForeignKey("QuestionSet")]
        public int QuestionSetRef_Id { get; set; }
        public QuestionSet QuestionSet { get; set; }
        [ForeignKey("User")]
        public int UserRef_Id { get; set; }
        public User User { get; set; }
    }

    
}
