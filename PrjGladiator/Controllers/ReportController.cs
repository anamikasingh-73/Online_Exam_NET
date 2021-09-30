using Microsoft.AspNetCore.Mvc;
using PrjGladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrjGladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        AppDBContext _context;

        public ReportController(AppDBContext db)
        {
            _context = db;

        }
        // GET: api/<ReportController>
        [HttpGet("{email}")]
        public IEnumerable<Report> GetReportsOfUser(string email)
        {
            User user = _context.Users.FirstOrDefault(s => s.Email == email);

            return _context.Reports.Where(r => r.User == user);
        }


       [ HttpGet("{email}/{subject_name}/{level}")]
        public IEnumerable<Report> GetSpecificReport(string email,string subject_name,int level)
        {
            User user = _context.Users.FirstOrDefault(s => s.Email == email);
            Subject subject = _context.Subjects.FirstOrDefault(s => s.Subject_Name == subject_name);
           

            QuestionSet questionSet = _context.QuestionSets.FirstOrDefault(s => (s.Subject == subject && s.Level == level));
            
            return _context.Reports.Where(r => r.User == user&&r.QuestionSet==questionSet);
        }
        // POST api/<ReportController>
        [HttpPost]
        public void Post( string email, string subject_name,int level, int marks)
        {
            User user = _context.Users.FirstOrDefault(s => s.Email == email);
            Subject subject = _context.Subjects.FirstOrDefault(s => s.Subject_Name == subject_name);


            QuestionSet questionSet = _context.QuestionSets.FirstOrDefault(s => (s.Subject == subject && s.Level == level));
            Report report = new Report { Marks = marks, QuestionSet = questionSet, User = user };
            _context.Reports.Add(report);
            _context.SaveChanges();

        }

        

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
