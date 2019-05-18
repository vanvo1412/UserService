using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public AppDbContext _dbContext { get; set; }
        public UsersController(AppDbContext context)
        {
            _dbContext = context;
        }
        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dbContext.Users;
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == id);
            if (user != null)
            {
                return user;
            }
            return new User();
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] UserViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = new User()
            {
                Address = value.Address,
                Age = value.Age,
                Name = value.Name
            };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == id);
            if (user != null)
            {
                var userToUpdate = new User()
                {
                    Address = user.Address,
                    Age = user.Age,
                    Name = user.Name
                };
                _dbContext.Update(userToUpdate);
                _dbContext.SaveChanges();
            }
            return NotFound();
        }
    }
}
