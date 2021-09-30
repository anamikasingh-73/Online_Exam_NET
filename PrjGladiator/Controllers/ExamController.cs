using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrjGladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjGladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        AppDBContext _context;

        public ExamController(AppDBContext db)
        {
            _context = db;

        }
        [HttpGet("GetExamQuestion/{subject_name}/{level}")]
        
        public List<Question> GetExamQuestion(string subject_name, int level)
        {
            Subject subject = _context.Subjects.FirstOrDefault(s => s.Subject_Name == subject_name);
            
            QuestionSet questionSet = _context.QuestionSets.FirstOrDefault(s => (s.Subject == subject && s.Level == level));

            return _context.Questions.Where(q => q.QuestionSet == questionSet).ToList();
           //return _context.Questions.Select(q =>new UserModel { }).ToList();

        }
            
        
            [HttpPost]
        public IActionResult CalculateScore([FromBody] ReportRequest rr  )
        {
            string email = rr.email;
            string subject_name = rr.subject_name;
            string selectedAnswers = rr.selectedAnswers;
            int level = rr.level;
            int score = 0;
            Subject subject = _context.Subjects.FirstOrDefault(s => s.Subject_Name == subject_name);

            QuestionSet questionSet = _context.QuestionSets.FirstOrDefault(s => (s.Subject == subject && s.Level == level));

            List<Question> questions =  _context.Questions.Where(q => q.QuestionSet == questionSet).ToList();
           

            for(int i=0;i<selectedAnswers.Length && i<questions.Count;i++)
            {
                if (string.Compare(selectedAnswers[i].ToString(), questions[i].Correct_Option)==0)
                {
                    score++;
                }

                        
            }
            ReportController rc = new ReportController(_context);
            rc.Post(email, subject_name, level, score * 10);
            return Ok(score);
        }

    }
}
