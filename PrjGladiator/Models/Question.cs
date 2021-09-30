using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace PrjGladiator.Models
{   
    [DataContract]
    public class Question
    {   [Key]
        public int Question_Id { get; set; }
        [DataMember]
        public string Question_Desc { get; set; }
        [DataMember]
        public string Option1 { get; set; }
        [DataMember]
        public string Option2 { get; set; }
        [DataMember]
        public string Option3 { get; set; }
        [DataMember]
        public string Option4 { get; set; }
        public string Correct_Option { get; set; }
        
        [IgnoreDataMember]
        [ForeignKey("QuestionSet")]
        public int QuestionSetRef_Id { get; set; }
        public QuestionSet QuestionSet { get; set; }
    }
}
