using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pff19.DataAccess.Models;
using pff19.DataAccess.Repositories;
using pff19.Models;

namespace pff19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        private const string GetUserRoutName = "GetUser";
        private readonly UsersRepository _userRepository;

        public UsersController(UsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userRepository.GetAll().ToList();
        }

        // GET: api/User/5
        [Authorize]
        [HttpGet("{id}", Name = GetUserRoutName)]
        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        // POST: api/Users
        [Authorize]
        [HttpPost]
        public IActionResult Post(CreateUserModel createUserModel)
        {
            var currentUser = _userRepository.Get(GetUserId());

            User user = new User
            {
                FirstName = createUserModel.FirstName,
                IsAdmin = createUserModel.IsAdmin,
                Mail = createUserModel.Mail,
                Name = createUserModel.Name,
                Ressort = createUserModel.Ressort,
                ScoutName = createUserModel.ScoutName
            };
            _userRepository.Add(user, createUserModel.Password);
            return CreatedAtRoute(GetUserRoutName, new { id = user.Id }, user);
        }

        // PUT: api/Users/5
        [Authorize]
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
        [Authorize]
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
