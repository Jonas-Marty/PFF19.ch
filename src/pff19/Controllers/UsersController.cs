using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pff19.DataAccess.Models;
using pff19.DataAccess.Repositories;

namespace pff19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private const string GetUserRoutName = "GetUser";
        private readonly UsersRepository _userRepository;

        public UsersController(UsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userRepository.GetAll().ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = GetUserRoutName)]
        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        // POST: api/News
        [HttpPost]
        public IActionResult Post(User user)
        {
            _userRepository.Add(user);
            return CreatedAtRoute(GetUserRoutName, new { id = user.Id }, user);
        }

        // PUT: api/News/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            var existingUser = _userRepository.Get(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Mail = user.Mail;
            existingUser.FirstName = user.FirstName;
            existingUser.IsAdmin = user.IsAdmin;
            existingUser.Name = user.Name;
            existingUser.Ressort = user.Ressort;
            existingUser.ScoutName = user.ScoutName;

            _userRepository.Update(existingUser);

            return NoContent();
        }

        // DELETE: api/news/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingUser = _userRepository.Get(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _userRepository.Delete(existingUser);

            return NoContent();
        }
    }
}
