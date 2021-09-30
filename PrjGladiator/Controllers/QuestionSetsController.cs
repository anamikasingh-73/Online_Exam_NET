using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrjGladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Question for particular subject and level

namespace PrjGladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionSetsController : ControllerBase
    {
        AppDBContext _context;

        public QuestionSetsController(AppDBContext db)
        {
            _context = db;


        }
        [HttpPost]
        public IActionResult AddQuestionSet(string subject_name,int level)
        {
            Subject subject = _context.Subjects.FirstOrDefault(s => s.Subject_Name == subject_name);
            if (subject == null)
            {
                return NotFound();
            }
            var question_set = new QuestionSet
            {
                Subject = subject,
                Level = level

            };
            using (var context = _context)
            {

                context.QuestionSets.Add(question_set);
                context.SaveChanges();
            }
            return Ok(subject);

        }
        [HttpDelete]
        public IActionResult DeleteQuestionSet(string subject_name, int level)
        {
            Subject subject = _context.Subjects.FirstOrDefault(s => s.Subject_Name == subject_name );
            if (subject == null)
            {
                return NotFound();
            }

            QuestionSet questionSet = _context.QuestionSets.FirstOrDefault(s => (s.Subject == subject && s.Level == level));
            if (questionSet == null)
            {
                return NotFound();
            }

            _context.QuestionSets.Remove(questionSet);
            _context.SaveChanges();

            return Ok(subject);
        }
    }
}
