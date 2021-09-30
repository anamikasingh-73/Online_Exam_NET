using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjGladiator.Models
{
    public class ReportRequest
    {
        public string email { get; set; }
        public string subject_name { get; set; }
        public int level { get; set; }
        public string selectedAnswers { get; set; }
    }
}
