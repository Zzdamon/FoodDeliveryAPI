//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using FoodDeliveryAPI.Models;
//using System.Net.Http;
//using System.Net;
//using Newtonsoft.Json.Linq;
//using System.Text.Json;

//namespace FoodDeliveryAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly FoodDeliveryDbContext _context;

//        public UsersController(FoodDeliveryDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Users
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
//        {
//            return await _context.Users.ToListAsync();
//        }

//        // GET: api/Users/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<User>> GetUsers(int id)
//        {
//            var users = await _context.Users.FindAsync(id);

//            if (users == null)
//            {
//                return NotFound();
//            }

//            return users;
//        }

//        //WEIRD REQUEST - not sure about this one
//        // GET: api/Users/auth
//        [HttpPost("auth") ]
//        public async Task<ActionResult<User>> Auth(Auth auth)
//        {
//            string email = auth.email;
//            string password = auth.Password;
//            var users = await _context.Users.Where(user => user.email == email)
//               .FirstOrDefaultAsync();

//            if (users == null)
//            {
//                return NotFound("User with the email "+email+"doesn't exist");
//            }

//            //string hashPass = new HashPassword().hashPassword(password, users.email);
//            if (password == users.Password)
//            {
//                return Ok(users);
//            }

//            return NotFound("incorect password");
     
//        }

//        // PUT: api/Users/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutUsers(int id, User users)
//        {
//            if (id != users.UserId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(users).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!UsersExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Users
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<User>> PostUsers(User users)
//        {
//            _context.Users.Add(users);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
//        }

//        // DELETE: api/Users/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<User>> DeleteUsers(int id)
//        {
//            var users = await _context.Users.FindAsync(id);
//            if (users == null)
//            {
//                return NotFound();
//            }

//            _context.Users.Remove(users);
//            await _context.SaveChangesAsync();

//            return users;
//        }

//        // DELETE: api/Users
//        [HttpDelete()]
//        public async Task<ActionResult<IEnumerable<User>>> DeleteUsers()
//        {
//            var users = await _context.Users.ToListAsync();
//            if (users == null)
//            {
//                return NotFound();
//            }

//            _context.Users.RemoveRange(users);
//            await _context.SaveChangesAsync();

//            return users;
//        }

//        private bool UsersExists(int id)
//        {
//            return _context.Users.Any(e => e.UserId == id);
//        }
//    }
//}
