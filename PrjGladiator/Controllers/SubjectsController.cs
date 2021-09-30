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
    public class SubjectsController : ControllerBase
    {
        AppDBContext _context;

        public SubjectsController(AppDBContext db)
        {
            _context = db;


        }

            [HttpGet]
            public List<string> GetSubjects()
        {
            using (var context = _context)
            {

               return context.Subjects.Select(item=>item.Subject_Name).ToList();
                
            }
        }
            [HttpPost]
        public IActionResult AddSubject(string subject_name)
        {
            var subject = new Subject
            {
                Subject_Name = subject_name,

            };
            using (var context = _context)
            {

                context.Subjects.Add(subject);
                context.SaveChanges();
            }
            return Ok(subject);

        }
            [HttpDelete]
        public IActionResult DeleteSubject(string subject_name)
        {
        
            Subject subject = _context.Subjects.FirstOrDefault( s => s.Subject_Name==subject_name);
            if (subject == null)
            {
                return NotFound();
            }

            _context.Subjects.Remove(subject);
            _context.SaveChanges();

            return Ok(subject);
        }
    }
}
