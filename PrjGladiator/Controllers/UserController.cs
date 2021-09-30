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
    public class UserController : ControllerBase
    {
        AppDBContext _context;

        public UserController(AppDBContext db)
        {
            _context = db;


        }

        [HttpGet]
        public List<User> GetUsers()
        {
            using (var context = _context)
            {

                return context.Users.ToList();

            }
        }
        [HttpPost]
        public IActionResult AddUser(string user_email)
        {
            var user = new User
            {
                Email = user_email,

            };
            using (var context = _context)
            {

                context.Users.Add(user);
                context.SaveChanges();
            }
            return Ok(user);

        }
        [HttpDelete]
        public IActionResult DeleteUser(string user_email)
        {

            User user = _context.Users.FirstOrDefault(s => s.Email == user_email);
            if (user== null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok(user);
        }
    }
}
    

